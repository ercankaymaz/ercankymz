// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RequestServerStateChangeMethodState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RequestServerStateChangeMethodState(NodeState parent) : MethodState(parent)
{
  private const string InitializationString = "//////////8EYYIKBAAAAAAAIgAAAFJlcXVlc3RTZXJ2ZXJTdGF0ZUNoYW5nZU1ldGhvZFR5cGUBAFgyAC8BAFgyWDIAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBZMgAuAERZMgAAlgUAAAABACoBARYAAAAFAAAAU3RhdGUBAFQD/////wAAAAAAAQAqAQEiAAAAEwAAAEVzdGltYXRlZFJldHVyblRpbWUADf////8AAAAAAAEAKgEBIgAAABMAAABTZWNvbmRzVGlsbFNodXRkb3duAAf/////AAAAAAABACoBARUAAAAGAAAAUmVhc29uABX/////AAAAAAABACoBARYAAAAHAAAAUmVzdGFydAAB/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  public RequestServerStateChangeMethodStateMethodCallHandler OnCall;

  public new static NodeState Construct(NodeState parent)
  {
    return (NodeState) new RequestServerStateChangeMethodState(parent);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYYIKBAAAAAAAIgAAAFJlcXVlc3RTZXJ2ZXJTdGF0ZUNoYW5nZU1ldGhvZFR5cGUBAFgyAC8BAFgyWDIAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBZMgAuAERZMgAAlgUAAAABACoBARYAAAAFAAAAU3RhdGUBAFQD/////wAAAAAAAQAqAQEiAAAAEwAAAEVzdGltYXRlZFJldHVyblRpbWUADf////8AAAAAAAEAKgEBIgAAABMAAABTZWNvbmRzVGlsbFNodXRkb3duAAf/////AAAAAAABACoBARUAAAAGAAAAUmVhc29uABX/////AAAAAAABACoBARYAAAAHAAAAUmVzdGFydAAB/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
    ServerState inputArgument1 = (ServerState) _inputArguments[0];
    DateTime inputArgument2 = (DateTime) _inputArguments[1];
    uint inputArgument3 = (uint) _inputArguments[2];
    LocalizedText inputArgument4 = (LocalizedText) _inputArguments[3];
    bool inputArgument5 = (bool) _inputArguments[4];
    if (this.OnCall != null)
      serviceResult = this.OnCall(_context, (MethodState) this, _objectId, inputArgument1, inputArgument2, inputArgument3, inputArgument4, inputArgument5);
    return serviceResult;
  }
}
