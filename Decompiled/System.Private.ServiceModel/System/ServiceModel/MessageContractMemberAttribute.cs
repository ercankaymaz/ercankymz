using System.Net.Security;
using System.ServiceModel.Description;
using System.ServiceModel.Security;

namespace System.ServiceModel;

public abstract class MessageContractMemberAttribute : Attribute
{
	private string _name;

	private string _ns;

	private bool _isNamespaceSetExplicit;

	private ProtectionLevel _protectionLevel;

	internal const string NamespacePropertyName = "Namespace";

	internal const string NamePropertyName = "Name";

	internal const string ProtectionLevelPropertyName = "ProtectionLevel";

	public string Namespace
	{
		get
		{
			return _ns;
		}
		set
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
			}
			if (value.Length > 0)
			{
				NamingHelper.CheckUriProperty(value, "Namespace");
			}
			_ns = value;
			_isNamespaceSetExplicit = true;
		}
	}

	internal bool IsNamespaceSetExplicit => _isNamespaceSetExplicit;

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
			IsNameSetExplicit = true;
		}
	}

	internal bool IsNameSetExplicit { get; private set; }

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
}
