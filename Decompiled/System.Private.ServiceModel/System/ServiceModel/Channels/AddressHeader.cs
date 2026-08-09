using System.Runtime.Serialization;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Xml;

namespace System.ServiceModel.Channels;

public abstract class AddressHeader
{
	internal class ParameterHeader : MessageHeader
	{
		private AddressHeader _parameter;

		public override bool IsReferenceParameter => true;

		public override string Name => _parameter.Name;

		public override string Namespace => _parameter.Namespace;

		public ParameterHeader(AddressHeader parameter)
		{
			_parameter = parameter;
		}

		protected override void OnWriteStartHeader(XmlDictionaryWriter writer, MessageVersion messageVersion)
		{
			if (messageVersion == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("messageVersion"));
			}
			WriteStartHeader(writer, _parameter, messageVersion.Addressing);
		}

		protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
		{
			WriteHeaderContents(writer, _parameter);
		}

		internal static void WriteStartHeader(XmlDictionaryWriter writer, AddressHeader parameter, AddressingVersion addressingVersion)
		{
			parameter.WriteStartAddressHeader(writer);
			if (addressingVersion == AddressingVersion.WSAddressing10)
			{
				writer.WriteAttributeString(XD.AddressingDictionary.IsReferenceParameter, XD.Addressing10Dictionary.Namespace, "true");
			}
		}

		internal static void WriteHeaderContents(XmlDictionaryWriter writer, AddressHeader parameter)
		{
			parameter.WriteAddressHeaderContents(writer);
		}
	}

	internal class XmlObjectSerializerAddressHeader : AddressHeader
	{
		private XmlObjectSerializer _serializer;

		private object _objectToSerialize;

		private string _name;

		private string _ns;

		public override string Name => _name;

		public override string Namespace => _ns;

		private object ThisLock => this;

		public XmlObjectSerializerAddressHeader(object objectToSerialize, XmlObjectSerializer serializer)
		{
			_serializer = serializer;
			_objectToSerialize = objectToSerialize;
			throw ExceptionHelper.PlatformNotSupported();
		}

		public XmlObjectSerializerAddressHeader(string name, string ns, object objectToSerialize, XmlObjectSerializer serializer)
		{
			if (name == null || name.Length == 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("name"));
			}
			_serializer = serializer;
			_objectToSerialize = objectToSerialize;
			_name = name;
			_ns = ns;
		}

		protected override void OnWriteAddressHeaderContents(XmlDictionaryWriter writer)
		{
			lock (ThisLock)
			{
				_serializer.WriteObjectContent(writer, _objectToSerialize);
			}
		}
	}

	internal class DictionaryAddressHeader : XmlObjectSerializerAddressHeader
	{
		private XmlDictionaryString _name;

		private XmlDictionaryString _ns;

		public DictionaryAddressHeader(XmlDictionaryString name, XmlDictionaryString ns, object value)
			: base(name.Value, ns.Value, value, DataContractSerializerDefaults.CreateSerializer(GetObjectType(value), name, ns, int.MaxValue))
		{
			_name = name;
			_ns = ns;
		}

		protected override void OnWriteStartAddressHeader(XmlDictionaryWriter writer)
		{
			writer.WriteStartElement(_name, _ns);
		}
	}

	private ParameterHeader _header;

	internal bool IsReferenceProperty
	{
		get
		{
			if (this is BufferedAddressHeader bufferedAddressHeader)
			{
				return bufferedAddressHeader.IsReferencePropertyHeader;
			}
			return false;
		}
	}

	public abstract string Name { get; }

	public abstract string Namespace { get; }

	public static AddressHeader CreateAddressHeader(object value)
	{
		Type objectType = GetObjectType(value);
		return CreateAddressHeader(value, DataContractSerializerDefaults.CreateSerializer(objectType, int.MaxValue));
	}

	public static AddressHeader CreateAddressHeader(object value, XmlObjectSerializer serializer)
	{
		if (serializer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("serializer"));
		}
		return new XmlObjectSerializerAddressHeader(value, serializer);
	}

	public static AddressHeader CreateAddressHeader(string name, string ns, object value)
	{
		return CreateAddressHeader(name, ns, value, DataContractSerializerDefaults.CreateSerializer(GetObjectType(value), name, ns, int.MaxValue));
	}

	internal static AddressHeader CreateAddressHeader(XmlDictionaryString name, XmlDictionaryString ns, object value)
	{
		return new DictionaryAddressHeader(name, ns, value);
	}

	public static AddressHeader CreateAddressHeader(string name, string ns, object value, XmlObjectSerializer serializer)
	{
		if (serializer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("serializer"));
		}
		return new XmlObjectSerializerAddressHeader(name, ns, value, serializer);
	}

	private static Type GetObjectType(object value)
	{
		if (value != null)
		{
			return value.GetType();
		}
		return typeof(object);
	}

	public override bool Equals(object obj)
	{
		if (!(obj is AddressHeader addressHeader))
		{
			return false;
		}
		StringBuilder stringBuilder = new StringBuilder();
		string comparableForm = GetComparableForm(stringBuilder);
		stringBuilder.Remove(0, stringBuilder.Length);
		string comparableForm2 = addressHeader.GetComparableForm(stringBuilder);
		if (comparableForm.Length != comparableForm2.Length)
		{
			return false;
		}
		if (string.CompareOrdinal(comparableForm, comparableForm2) != 0)
		{
			return false;
		}
		return true;
	}

	internal string GetComparableForm()
	{
		return GetComparableForm(new StringBuilder());
	}

	internal string GetComparableForm(StringBuilder builder)
	{
		return EndpointAddressProcessor.GetComparableForm(builder, GetComparableReader());
	}

	public override int GetHashCode()
	{
		return GetComparableForm().GetHashCode();
	}

	public T GetValue<T>()
	{
		return GetValue<T>(DataContractSerializerDefaults.CreateSerializer(typeof(T), Name, Namespace, int.MaxValue));
	}

	public T GetValue<T>(XmlObjectSerializer serializer)
	{
		if (serializer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("serializer"));
		}
		using XmlDictionaryReader reader = GetAddressHeaderReader();
		if (serializer.IsStartObject(reader))
		{
			return (T)serializer.ReadObject(reader);
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.ExpectedElementMissing, Name, Namespace)));
	}

	public virtual XmlDictionaryReader GetAddressHeaderReader()
	{
		XmlBuffer xmlBuffer = new XmlBuffer(int.MaxValue);
		XmlDictionaryWriter writer = xmlBuffer.OpenSection(XmlDictionaryReaderQuotas.Max);
		WriteAddressHeader(writer);
		xmlBuffer.CloseSection();
		xmlBuffer.Close();
		return xmlBuffer.GetReader(0);
	}

	private XmlDictionaryReader GetComparableReader()
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	protected virtual void OnWriteStartAddressHeader(XmlDictionaryWriter writer)
	{
		writer.WriteStartElement(Name, Namespace);
	}

	protected abstract void OnWriteAddressHeaderContents(XmlDictionaryWriter writer);

	public MessageHeader ToMessageHeader()
	{
		if (_header == null)
		{
			_header = new ParameterHeader(this);
		}
		return _header;
	}

	public void WriteAddressHeader(XmlWriter writer)
	{
		WriteAddressHeader(XmlDictionaryWriter.CreateDictionaryWriter(writer));
	}

	public void WriteAddressHeader(XmlDictionaryWriter writer)
	{
		if (writer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("writer"));
		}
		WriteStartAddressHeader(writer);
		WriteAddressHeaderContents(writer);
		writer.WriteEndElement();
	}

	public void WriteStartAddressHeader(XmlDictionaryWriter writer)
	{
		if (writer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("writer"));
		}
		OnWriteStartAddressHeader(writer);
	}

	public void WriteAddressHeaderContents(XmlDictionaryWriter writer)
	{
		if (writer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("writer"));
		}
		OnWriteAddressHeaderContents(writer);
	}
}
