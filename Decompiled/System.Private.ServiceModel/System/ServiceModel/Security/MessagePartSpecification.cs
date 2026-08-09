using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel.Channels;
using System.Xml;

namespace System.ServiceModel.Security;

public class MessagePartSpecification
{
	private List<XmlQualifiedName> _headerTypes;

	private bool _isBodyIncluded;

	private static MessagePartSpecification s_noParts;

	public ICollection<XmlQualifiedName> HeaderTypes
	{
		get
		{
			if (_headerTypes == null)
			{
				_headerTypes = new List<XmlQualifiedName>();
			}
			if (IsReadOnly)
			{
				return new ReadOnlyCollection<XmlQualifiedName>(_headerTypes);
			}
			return _headerTypes;
		}
	}

	internal bool HasHeaders
	{
		get
		{
			if (_headerTypes != null)
			{
				return _headerTypes.Count > 0;
			}
			return false;
		}
	}

	public bool IsBodyIncluded
	{
		get
		{
			return _isBodyIncluded;
		}
		set
		{
			if (IsReadOnly)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ObjectIsReadOnly));
			}
			_isBodyIncluded = value;
		}
	}

	public bool IsReadOnly { get; private set; }

	public static MessagePartSpecification NoParts
	{
		get
		{
			if (s_noParts == null)
			{
				MessagePartSpecification messagePartSpecification = new MessagePartSpecification();
				messagePartSpecification.MakeReadOnly();
				s_noParts = messagePartSpecification;
			}
			return s_noParts;
		}
	}

	public void Clear()
	{
		if (IsReadOnly)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ObjectIsReadOnly));
		}
		if (_headerTypes != null)
		{
			_headerTypes.Clear();
		}
		_isBodyIncluded = false;
	}

	public void Union(MessagePartSpecification specification)
	{
		if (IsReadOnly)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.ObjectIsReadOnly));
		}
		if (specification == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("specification");
		}
		_isBodyIncluded |= specification.IsBodyIncluded;
		List<XmlQualifiedName> headerTypes = specification._headerTypes;
		if (headerTypes != null && headerTypes.Count > 0)
		{
			if (_headerTypes == null)
			{
				_headerTypes = new List<XmlQualifiedName>(headerTypes.Count);
			}
			for (int i = 0; i < headerTypes.Count; i++)
			{
				XmlQualifiedName item = headerTypes[i];
				_headerTypes.Add(item);
			}
		}
	}

	public void MakeReadOnly()
	{
		if (IsReadOnly)
		{
			return;
		}
		if (_headerTypes != null)
		{
			List<XmlQualifiedName> list = new List<XmlQualifiedName>(_headerTypes.Count);
			for (int i = 0; i < _headerTypes.Count; i++)
			{
				XmlQualifiedName xmlQualifiedName = _headerTypes[i];
				if (!(xmlQualifiedName != null))
				{
					continue;
				}
				bool flag = true;
				for (int j = 0; j < list.Count; j++)
				{
					XmlQualifiedName xmlQualifiedName2 = list[j];
					if (xmlQualifiedName.Name == xmlQualifiedName2.Name && xmlQualifiedName.Namespace == xmlQualifiedName2.Namespace)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					list.Add(xmlQualifiedName);
				}
			}
			_headerTypes = list;
		}
		IsReadOnly = true;
	}

	public MessagePartSpecification()
	{
	}

	public MessagePartSpecification(bool isBodyIncluded)
	{
		_isBodyIncluded = isBodyIncluded;
	}

	public MessagePartSpecification(params XmlQualifiedName[] headerTypes)
		: this(isBodyIncluded: false, headerTypes)
	{
	}

	public MessagePartSpecification(bool isBodyIncluded, params XmlQualifiedName[] headerTypes)
	{
		_isBodyIncluded = isBodyIncluded;
		if (headerTypes != null && headerTypes.Length != 0)
		{
			_headerTypes = new List<XmlQualifiedName>(headerTypes.Length);
			for (int i = 0; i < headerTypes.Length; i++)
			{
				_headerTypes.Add(headerTypes[i]);
			}
		}
	}

	internal bool IsHeaderIncluded(MessageHeader header)
	{
		if (header == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("header");
		}
		return IsHeaderIncluded(header.Name, header.Namespace);
	}

	internal bool IsHeaderIncluded(string name, string ns)
	{
		if (name == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("name");
		}
		if (ns == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("ns");
		}
		if (_headerTypes != null)
		{
			for (int i = 0; i < _headerTypes.Count; i++)
			{
				XmlQualifiedName xmlQualifiedName = _headerTypes[i];
				if (string.IsNullOrEmpty(xmlQualifiedName.Name))
				{
					if (xmlQualifiedName.Namespace == ns)
					{
						return true;
					}
				}
				else if (xmlQualifiedName.Name == name && xmlQualifiedName.Namespace == ns)
				{
					return true;
				}
			}
		}
		return false;
	}

	internal bool IsEmpty()
	{
		if (_headerTypes != null && _headerTypes.Count > 0)
		{
			return false;
		}
		return !IsBodyIncluded;
	}
}
