using System.Net.Security;
using System.ServiceModel.Description;
using System.ServiceModel.Security;

namespace System.ServiceModel;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
public sealed class FaultContractAttribute : Attribute
{
	private string _action;

	private string _name;

	private string _ns;

	private ProtectionLevel _protectionLevel;

	internal const string ProtectionLevelPropertyName = "ProtectionLevel";

	public Type DetailType { get; }

	public string Action
	{
		get
		{
			return _action;
		}
		set
		{
			_action = value ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
		}
	}

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
			}
			if (value == string.Empty)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", System.SR.SFxNameCannotBeEmpty));
			}
			_name = value;
		}
	}

	public string Namespace
	{
		get
		{
			return _ns;
		}
		set
		{
			if (!string.IsNullOrEmpty(value))
			{
				NamingHelper.CheckUriProperty(value, "Namespace");
			}
			_ns = value;
		}
	}

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

	public FaultContractAttribute(Type detailType)
	{
		DetailType = detailType ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("detailType"));
	}
}
