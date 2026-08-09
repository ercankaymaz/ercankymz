using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;

namespace System.ServiceModel.Description;

[DebuggerDisplay("Name={XmlName}, IsInitiating={IsInitiating}, IsTerminating={IsTerminating}")]
public class OperationDescription
{
	internal const string SessionOpenedAction = "http://schemas.microsoft.com/2011/02/session/onopen";

	private bool _isSessionOpenNotificationEnabled;

	private ContractDescription _declaringContract;

	private MethodInfo _taskMethod;

	private bool _hasNoDisposableParameters;

	public KeyedCollection<Type, IOperationBehavior> OperationBehaviors => Behaviors;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public KeyedByTypeCollection<IOperationBehavior> Behaviors { get; }

	public MethodInfo TaskMethod
	{
		get
		{
			return _taskMethod;
		}
		set
		{
			_taskMethod = value;
		}
	}

	public MethodInfo SyncMethod { get; set; }

	public MethodInfo BeginMethod { get; set; }

	internal MethodInfo OperationMethod
	{
		get
		{
			if (SyncMethod == null)
			{
				return TaskMethod ?? BeginMethod;
			}
			return SyncMethod;
		}
	}

	internal bool HasNoDisposableParameters
	{
		get
		{
			return _hasNoDisposableParameters;
		}
		set
		{
			_hasNoDisposableParameters = value;
		}
	}

	public MethodInfo EndMethod { get; set; }

	public ContractDescription DeclaringContract
	{
		get
		{
			return _declaringContract;
		}
		set
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("DeclaringContract");
			}
			_declaringContract = value;
		}
	}

	public FaultDescriptionCollection Faults { get; }

	public bool IsOneWay => Messages.Count == 1;

	public bool IsInitiating { get; set; }

	public bool IsTerminating { get; set; }

	public Collection<Type> KnownTypes { get; }

	public MessageDescriptionCollection Messages { get; }

	internal XmlName XmlName { get; }

	internal string CodeName => XmlName.DecodedName;

	public string Name => XmlName.EncodedName;

	internal bool IsValidateRpcWrapperName { get; } = true;

	internal Type TaskTResult { get; set; }

	internal bool HasOutputParameters
	{
		get
		{
			if (Messages.Count > 1)
			{
				return Messages[1].Body.Parts.Count > 0;
			}
			return false;
		}
	}

	internal bool IsSessionOpenNotificationEnabled
	{
		get
		{
			return _isSessionOpenNotificationEnabled;
		}
		set
		{
			_isSessionOpenNotificationEnabled = value;
		}
	}

	public OperationDescription(string name, ContractDescription declaringContract)
	{
		if (name == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("name");
		}
		if (name.Length == 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("name", System.SR.SFxOperationDescriptionNameCannotBeEmpty));
		}
		XmlName = new XmlName(name, isEncoded: true);
		_declaringContract = declaringContract ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("declaringContract");
		IsInitiating = true;
		IsTerminating = false;
		Faults = new FaultDescriptionCollection();
		Messages = new MessageDescriptionCollection();
		Behaviors = new KeyedByTypeCollection<IOperationBehavior>();
		KnownTypes = new Collection<Type>();
	}

	internal OperationDescription(string name, ContractDescription declaringContract, bool validateRpcWrapperName)
		: this(name, declaringContract)
	{
		IsValidateRpcWrapperName = validateRpcWrapperName;
	}

	internal bool IsServerInitiated()
	{
		EnsureInvariants();
		return Messages[0].Direction == MessageDirection.Output;
	}

	internal void EnsureInvariants()
	{
		if (Messages.Count != 1 && Messages.Count != 2)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxOperationMustHaveOneOrTwoMessages, Name)));
		}
	}
}
