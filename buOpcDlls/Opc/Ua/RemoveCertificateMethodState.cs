// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RemoveCertificateMethodState
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
public class RemoveCertificateMethodState(NodeState parent) : MethodState(parent)
{
  private const string InitializationString = "//////////8EYYIKBAAAAAAAGwAAAFJlbW92ZUNlcnRpZmljYXRlTWV0aG9kVHlwZQEA6DAALwEA6DDoMAAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAOkwAC4AROkwAACWAgAAAAEAKgEBGQAAAAoAAABUaHVtYnByaW50AAz/////AAAAAAABACoBASMAAAAUAAAASXNUcnVzdGVkQ2VydGlmaWNhdGUAAf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";
  public RemoveCertificateMethodStateMethodCallHandler OnCall;

  public new static NodeState Construct(NodeState parent)
  {
    return (NodeState) new RemoveCertificateMethodState(parent);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYYIKBAAAAAAAGwAAAFJlbW92ZUNlcnRpZmljYXRlTWV0aG9kVHlwZQEA6DAALwEA6DDoMAAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAOkwAC4AROkwAACWAgAAAAEAKgEBGQAAAAoAAABUaHVtYnByaW50AAz/////AAAAAAABACoBASMAAAAUAAAASXNUcnVzdGVkQ2VydGlmaWNhdGUAAf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
    string inputArgument1 = (string) _inputArguments[0];
    bool inputArgument2 = (bool) _inputArguments[1];
    if (this.OnCall != null)
      serviceResult = this.OnCall(_context, (MethodState) this, _objectId, inputArgument1, inputArgument2);
    return serviceResult;
  }
}
