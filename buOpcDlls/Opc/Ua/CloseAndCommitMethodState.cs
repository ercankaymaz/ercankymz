// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CloseAndCommitMethodState
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
public class CloseAndCommitMethodState(NodeState parent) : MethodState(parent)
{
  private const string InitializationString = "//////////8EYYIKBAAAAAAAGAAAAENsb3NlQW5kQ29tbWl0TWV0aG9kVHlwZQEAuD0ALwEAuD24PQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBALk9AC4ARLk9AACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQC6PQAuAES6PQAAlgEAAAABACoBASUAAAAWAAAAQ29tcGxldGlvblN0YXRlTWFjaGluZQAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  public CloseAndCommitMethodStateMethodCallHandler OnCall;

  public new static NodeState Construct(NodeState parent)
  {
    return (NodeState) new CloseAndCommitMethodState(parent);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYYIKBAAAAAAAGAAAAENsb3NlQW5kQ29tbWl0TWV0aG9kVHlwZQEAuD0ALwEAuD24PQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBALk9AC4ARLk9AACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQC6PQAuAES6PQAAlgEAAAABACoBASUAAAAWAAAAQ29tcGxldGlvblN0YXRlTWFjaGluZQAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
    uint inputArgument = (uint) _inputArguments[0];
    NodeId outputArgument = (NodeId) _outputArguments[0];
    if (this.OnCall != null)
      serviceResult = this.OnCall(_context, (MethodState) this, _objectId, inputArgument, ref outputArgument);
    _outputArguments[0] = (object) outputArgument;
    return serviceResult;
  }
}
