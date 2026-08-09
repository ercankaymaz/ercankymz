using System.Net.Security;
using System.ServiceModel.Description;
using System.ServiceModel.Security;

namespace System.ServiceModel;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false)]
public sealed class MessageContractAttribute : Attribute
{
	private string _wrappedName;

	private string _wrappedNs;

	private ProtectionLevel _protectionLevel;

	internal const string ProtectionLevelPropertyName = "ProtectionLevel";

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

	public bool IsWrapped { get; set; } = true;

	public string WrapperName
	{
		get
		{
			return _wrappedName;
		}
		set
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
			}
			if (value == string.Empty)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", System.SR.SFxWrapperNameCannotBeEmpty));
			}
			_wrappedName = value;
		}
	}

	public string WrapperNamespace
	{
		get
		{
			return _wrappedNs;
		}
		set
		{
			if (!string.IsNullOrEmpty(value))
			{
				NamingHelper.CheckUriProperty(value, "WrapperNamespace");
			}
			_wrappedNs = value;
		}
	}
}
