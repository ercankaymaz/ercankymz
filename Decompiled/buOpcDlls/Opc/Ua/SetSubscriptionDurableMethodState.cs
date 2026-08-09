using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SetSubscriptionDurableMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAIAAAAFNldFN1YnNjcmlwdGlvbkR1cmFibGVNZXRob2RUeXBlAQDQMQAvAQDQMdAxAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA0TEALgBE0TEAAJYCAAAAAQAqAQEdAAAADgAAAFN1YnNjcmlwdGlvbklkAAf/////AAAAAAABACoBAR4AAAAPAAAATGlmZXRpbWVJbkhvdXJzAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDSMQAuAETSMQAAlgEAAAABACoBASUAAAAWAAAAUmV2aXNlZExpZmV0aW1lSW5Ib3VycwAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	public SetSubscriptionDurableMethodStateMethodCallHandler OnCall;

	public SetSubscriptionDurableMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new SetSubscriptionDurableMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAIAAAAFNldFN1YnNjcmlwdGlvbkR1cmFibGVNZXRob2RUeXBlAQDQMQAvAQDQMdAxAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA0TEALgBE0TEAAJYCAAAAAQAqAQEdAAAADgAAAFN1YnNjcmlwdGlvbklkAAf/////AAAAAAABACoBAR4AAAAPAAAATGlmZXRpbWVJbkhvdXJzAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDSMQAuAETSMQAAlgEAAAABACoBASUAAAAWAAAAUmV2aXNlZExpZmV0aW1lSW5Ib3VycwAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
		InitializeOptionalChildren(context);
	}

	protected override void InitializeOptionalChildren(ISystemContext context)
	{
		base.InitializeOptionalChildren(context);
	}

	protected override ServiceResult Call(ISystemContext _context, NodeId _objectId, IList<object> _inputArguments, IList<object> _outputArguments)
	{
		if (OnCall == null)
		{
			return base.Call(_context, _objectId, _inputArguments, _outputArguments);
		}
		ServiceResult result = null;
		uint subscriptionId = (uint)_inputArguments[0];
		uint lifetimeInHours = (uint)_inputArguments[1];
		uint revisedLifetimeInHours = (uint)_outputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, subscriptionId, lifetimeInHours, ref revisedLifetimeInHours);
		}
		_outputArguments[0] = revisedLifetimeInHours;
		return result;
	}
}
