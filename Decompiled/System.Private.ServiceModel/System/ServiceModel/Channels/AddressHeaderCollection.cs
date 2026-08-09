using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml;

namespace System.ServiceModel.Channels;

public sealed class AddressHeaderCollection : ReadOnlyCollection<AddressHeader>
{
	internal static AddressHeaderCollection EmptyHeaderCollection { get; } = new AddressHeaderCollection();

	private int InternalCount
	{
		get
		{
			if (this == EmptyHeaderCollection)
			{
				return 0;
			}
			return base.Count;
		}
	}

	internal bool HasReferenceProperties
	{
		get
		{
			for (int i = 0; i < InternalCount; i++)
			{
				if (base[i].IsReferenceProperty)
				{
					return true;
				}
			}
			return false;
		}
	}

	internal bool HasNonReferenceProperties
	{
		get
		{
			for (int i = 0; i < InternalCount; i++)
			{
				if (!base[i].IsReferenceProperty)
				{
					return true;
				}
			}
			return false;
		}
	}

	public AddressHeaderCollection()
		: base((IList<AddressHeader>)new List<AddressHeader>())
	{
	}

	public AddressHeaderCollection(IEnumerable<AddressHeader> addressHeaders)
		: base((IList<AddressHeader>)new List<AddressHeader>(addressHeaders))
	{
		if (addressHeaders is IList<AddressHeader> list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] == null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.MessageHeaderIsNull0));
				}
			}
			return;
		}
		foreach (AddressHeader addressHeader in addressHeaders)
		{
			if (addressHeaders == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.MessageHeaderIsNull0));
			}
		}
	}

	public void AddHeadersTo(Message message)
	{
		if (message == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("message");
		}
		for (int i = 0; i < InternalCount; i++)
		{
			message.Headers.Add(base[i].ToMessageHeader());
		}
	}

	public AddressHeader[] FindAll(string name, string ns)
	{
		if (name == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("name"));
		}
		if (ns == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("ns"));
		}
		List<AddressHeader> list = new List<AddressHeader>();
		for (int i = 0; i < base.Count; i++)
		{
			AddressHeader addressHeader = base[i];
			if (addressHeader.Name == name && addressHeader.Namespace == ns)
			{
				list.Add(addressHeader);
			}
		}
		return list.ToArray();
	}

	public AddressHeader FindHeader(string name, string ns)
	{
		if (name == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("name"));
		}
		if (ns == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("ns"));
		}
		AddressHeader addressHeader = null;
		for (int i = 0; i < base.Count; i++)
		{
			AddressHeader addressHeader2 = base[i];
			if (addressHeader2.Name == name && addressHeader2.Namespace == ns)
			{
				if (addressHeader != null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.Format(System.SR.MultipleMessageHeaders, name, ns)));
				}
				addressHeader = addressHeader2;
			}
		}
		return addressHeader;
	}

	internal bool IsEquivalent(AddressHeaderCollection col)
	{
		if (InternalCount != col.InternalCount)
		{
			return false;
		}
		StringBuilder builder = new StringBuilder();
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		PopulateHeaderDictionary(builder, dictionary);
		Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
		col.PopulateHeaderDictionary(builder, dictionary2);
		if (dictionary.Count != dictionary2.Count)
		{
			return false;
		}
		foreach (KeyValuePair<string, int> item in dictionary)
		{
			if (dictionary2.TryGetValue(item.Key, out var value))
			{
				if (value != item.Value)
				{
					return false;
				}
				continue;
			}
			return false;
		}
		return true;
	}

	internal void PopulateHeaderDictionary(StringBuilder builder, Dictionary<string, int> headers)
	{
		for (int i = 0; i < InternalCount; i++)
		{
			builder.Remove(0, builder.Length);
			string comparableForm = base[i].GetComparableForm(builder);
			if (headers.ContainsKey(comparableForm))
			{
				headers[comparableForm]++;
			}
			else
			{
				headers.Add(comparableForm, 1);
			}
		}
	}

	internal static AddressHeaderCollection ReadServiceParameters(XmlDictionaryReader reader)
	{
		return ReadServiceParameters(reader, isReferenceProperty: false);
	}

	internal static AddressHeaderCollection ReadServiceParameters(XmlDictionaryReader reader, bool isReferenceProperty)
	{
		reader.MoveToContent();
		if (reader.IsEmptyElement)
		{
			reader.Skip();
			return null;
		}
		reader.ReadStartElement();
		List<AddressHeader> list = new List<AddressHeader>();
		while (reader.IsStartElement())
		{
			list.Add(new BufferedAddressHeader(reader, isReferenceProperty));
		}
		reader.ReadEndElement();
		return new AddressHeaderCollection(list);
	}

	internal void WriteReferencePropertyContentsTo(XmlDictionaryWriter writer)
	{
		for (int i = 0; i < InternalCount; i++)
		{
			if (base[i].IsReferenceProperty)
			{
				base[i].WriteAddressHeader(writer);
			}
		}
	}

	internal void WriteNonReferencePropertyContentsTo(XmlDictionaryWriter writer)
	{
		for (int i = 0; i < InternalCount; i++)
		{
			if (!base[i].IsReferenceProperty)
			{
				base[i].WriteAddressHeader(writer);
			}
		}
	}

	internal void WriteContentsTo(XmlDictionaryWriter writer)
	{
		for (int i = 0; i < InternalCount; i++)
		{
			base[i].WriteAddressHeader(writer);
		}
	}
}
