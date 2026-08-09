using System.Net.Security;
using System.ServiceModel.Description;
using System.ServiceModel.Security;

namespace System.ServiceModel;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, Inherited = false, AllowMultiple = false)]
public sealed class ServiceContractAttribute : Attribute
{
	private string _configurationName;

	private string _name;

	private string _ns;

	private SessionMode _sessionMode;

	private ProtectionLevel _protectionLevel;

	public string ConfigurationName
	{
		get
		{
			return _configurationName;
		}
		set
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
			}
			if (value == string.Empty)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", System.SR.SFxConfigurationNameCannotBeEmpty));
			}
			_configurationName = value;
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

	public SessionMode SessionMode
	{
		get
		{
			return _sessionMode;
		}
		set
		{
			if (!SessionModeHelper.IsDefined(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value"));
			}
			_sessionMode = value;
		}
	}

	public Type CallbackContract { get; set; }
}
