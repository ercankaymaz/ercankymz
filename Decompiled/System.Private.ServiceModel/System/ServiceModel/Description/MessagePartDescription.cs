using System.ComponentModel;
using System.Diagnostics;
using System.Net.Security;
using System.Reflection;
using System.ServiceModel.Security;

namespace System.ServiceModel.Description;

[DebuggerDisplay("Name={XmlName}, Namespace={Namespace}, Type={Type}, Index={Index}}")]
public class MessagePartDescription
{
	private ProtectionLevel _protectionLevel;

	private ICustomAttributeProvider _additionalAttributesProvider;

	private string _uniquePartName;

	internal string BaseType { get; set; }

	internal XmlName XmlName { get; }

	internal string CodeName => XmlName.DecodedName;

	public string Name => XmlName.EncodedName;

	public string Namespace { get; }

	public Type Type { get; set; }

	public int Index { get; set; }

	[DefaultValue(false)]
	public bool Multiple { get; set; }

	public ProtectionLevel ProtectionLevel
	{
		get
		{
			return _protectionLevel;
		}
		set
		{
			if (!ProtectionLevelHelper.IsDefined(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value"));
			}
			_protectionLevel = value;
			HasProtectionLevel = true;
		}
	}

	public bool HasProtectionLevel { get; private set; }

	public MemberInfo MemberInfo { get; set; }

	internal ICustomAttributeProvider AdditionalAttributesProvider
	{
		get
		{
			return _additionalAttributesProvider ?? MemberInfo;
		}
		set
		{
			_additionalAttributesProvider = value;
		}
	}

	internal string UniquePartName
	{
		get
		{
			return _uniquePartName;
		}
		set
		{
			_uniquePartName = value;
		}
	}

	internal int SerializationPosition { get; set; }

	public MessagePartDescription(string name, string ns)
	{
		if (name == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("name", System.SR.SFxParameterNameCannotBeNull);
		}
		XmlName = new XmlName(name, isEncoded: true);
		if (!string.IsNullOrEmpty(ns))
		{
			NamingHelper.CheckUriParameter(ns, "ns");
		}
		Namespace = ns;
	}

	internal MessagePartDescription(MessagePartDescription other)
	{
		XmlName = other.XmlName;
		Namespace = other.Namespace;
		Index = other.Index;
		Type = other.Type;
		SerializationPosition = other.SerializationPosition;
		HasProtectionLevel = other.HasProtectionLevel;
		_protectionLevel = other._protectionLevel;
		MemberInfo = other.MemberInfo;
		Multiple = other.Multiple;
		_additionalAttributesProvider = other._additionalAttributesProvider;
		BaseType = other.BaseType;
		_uniquePartName = other._uniquePartName;
	}

	internal virtual MessagePartDescription Clone()
	{
		return new MessagePartDescription(this);
	}

	internal void ResetProtectionLevel()
	{
		_protectionLevel = ProtectionLevel.None;
		HasProtectionLevel = false;
	}
}
