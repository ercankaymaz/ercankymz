using System.Diagnostics;
using System.Net.Security;
using System.ServiceModel.Security;

namespace System.ServiceModel.Description;

[DebuggerDisplay("Name={_name}, Action={Action}, DetailType={DetailType}")]
public class FaultDescription
{
	private XmlName _name;

	private ProtectionLevel _protectionLevel;

	public string Action { get; internal set; }

	public Type DetailType { get; set; }

	public string Name
	{
		get
		{
			return _name.EncodedName;
		}
		set
		{
			SetNameAndElement(new XmlName(value, isEncoded: true));
		}
	}

	public string Namespace { get; set; }

	internal XmlName ElementName { get; set; }

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

	public FaultDescription(string action)
	{
		Action = action ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("action"));
	}

	public bool ShouldSerializeProtectionLevel()
	{
		return HasProtectionLevel;
	}

	internal void ResetProtectionLevel()
	{
		_protectionLevel = ProtectionLevel.None;
		HasProtectionLevel = false;
	}

	internal void SetNameAndElement(XmlName name)
	{
		ElementName = (_name = name);
	}

	internal void SetNameOnly(XmlName name)
	{
		_name = name;
	}
}
