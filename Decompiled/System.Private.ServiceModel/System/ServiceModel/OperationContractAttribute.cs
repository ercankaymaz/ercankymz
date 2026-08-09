using System.Net.Security;
using System.Reflection;
using System.ServiceModel.Security;

namespace System.ServiceModel;

[AttributeUsage(AttributeTargets.Method)]
public sealed class OperationContractAttribute : Attribute
{
	private string _name;

	private string _action;

	private string _replyAction;

	private bool _isOneWay;

	private ProtectionLevel _protectionLevel;

	internal const string ActionPropertyName = "Action";

	internal const string ProtectionLevelPropertyName = "ProtectionLevel";

	internal const string ReplyActionPropertyName = "ReplyAction";

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
			if (value == "")
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", System.SR.SFxNameCannotBeEmpty));
			}
			_name = value;
		}
	}

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

	public string ReplyAction
	{
		get
		{
			return _replyAction;
		}
		set
		{
			_replyAction = value ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
		}
	}

	public bool AsyncPattern { get; set; }

	public bool IsOneWay
	{
		get
		{
			return _isOneWay;
		}
		set
		{
			_isOneWay = value;
		}
	}

	public bool IsInitiating { get; set; } = true;

	public bool IsTerminating { get; set; }

	internal bool IsSessionOpenNotificationEnabled => Action == "http://schemas.microsoft.com/2011/02/session/onopen";

	internal void EnsureInvariants(MethodInfo methodInfo, string operationName)
	{
		if (IsSessionOpenNotificationEnabled && (!IsOneWay || !IsInitiating || methodInfo.GetParameters().Length != 0))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.ContractIsNotSelfConsistentWhenIsSessionOpenNotificationEnabled, operationName, "Action", "http://schemas.microsoft.com/2011/02/session/onopen", "IsOneWay", "IsInitiating")));
		}
	}
}
