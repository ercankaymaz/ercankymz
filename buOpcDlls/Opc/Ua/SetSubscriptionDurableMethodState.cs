// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SetSubscriptionDurableMethodState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SetSubscriptionDurableMethodState(NodeState parent) : MethodState(parent)
{
  private const string InitializationString = "//////////8EYYIKBAAAAAAAIAAAAFNldFN1YnNjcmlwdGlvbkR1cmFibGVNZXRob2RUeXBlAQDQMQAvAQDQMdAxAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA0TEALgBE0TEAAJYCAAAAAQAqAQEdAAAADgAAAFN1YnNjcmlwdGlvbklkAAf/////AAAAAAABACoBAR4AAAAPAAAATGlmZXRpbWVJbkhvdXJzAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDSMQAuAETSMQAAlgEAAAABACoBASUAAAAWAAAAUmV2aXNlZExpZmV0aW1lSW5Ib3VycwAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  public SetSubscriptionDurableMethodStateMethodCallHandler OnCall;

  public new static NodeState Construct(NodeState parent)
  {
    return (NodeState) new SetSubscriptionDurableMethodState(parent);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYYIKBAAAAAAAIAAAAFNldFN1YnNjcmlwdGlvbkR1cmFibGVNZXRob2RUeXBlAQDQMQAvAQDQMdAxAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA0TEALgBE0TEAAJYCAAAAAQAqAQEdAAAADgAAAFN1YnNjcmlwdGlvbklkAAf/////AAAAAAABACoBAR4AAAAPAAAATGlmZXRpbWVJbkhvdXJzAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDSMQAuAETSMQAAlgEAAAABACoBASUAAAAWAAAAUmV2aXNlZExpZmV0aW1lSW5Ib3VycwAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
    this.InitializeOptionalChildren(context);
  }

  protected override void InitializeOptionalChildren(ISystemContext context)
  {
    base.InitializeOptionalChildren(context);
  }

  protected override ServiceResult Call(
    ISystemContext _context,
    NodeId _objectId,
    IList<object> _inputArguments,
    IList<object> _outputArguments)
  {
    if (this.OnCall == null)
      return base.Call(_context, _objectId, _inputArguments, _outputArguments);
    ServiceResult serviceResult = (ServiceResult) null;
    uint inputArgument1 = (uint) _inputArguments[0];
    uint inputArgument2 = (uint) _inputArguments[1];
    uint outputArgument = (uint) _outputArguments[0];
    if (this.OnCall != null)
      serviceResult = this.OnCall(_context, (MethodState) this, _objectId, inputArgument1, inputArgument2, ref outputArgument);
    _outputArguments[0] = (object) outputArgument;
    return serviceResult;
  }
}
