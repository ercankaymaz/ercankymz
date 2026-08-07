// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CreateSigningRequestMethodState
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
public class CreateSigningRequestMethodState(NodeState parent) : MethodState(parent)
{
  private const string InitializationString = "//////////8EYYIKBAAAAAAAHgAAAENyZWF0ZVNpZ25pbmdSZXF1ZXN0TWV0aG9kVHlwZQEAxTEALwEAxTHFMQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAMYxAC4ARMYxAACWBQAAAAEAKgEBIQAAABIAAABDZXJ0aWZpY2F0ZUdyb3VwSWQAEf////8AAAAAAAEAKgEBIAAAABEAAABDZXJ0aWZpY2F0ZVR5cGVJZAAR/////wAAAAAAAQAqAQEaAAAACwAAAFN1YmplY3ROYW1lAAz/////AAAAAAABACoBASMAAAAUAAAAUmVnZW5lcmF0ZVByaXZhdGVLZXkAAf////8AAAAAAAEAKgEBFAAAAAUAAABOb25jZQAP/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAxzEALgBExzEAAJYBAAAAAQAqAQEhAAAAEgAAAENlcnRpZmljYXRlUmVxdWVzdAAP/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  public CreateSigningRequestMethodStateMethodCallHandler OnCall;

  public new static NodeState Construct(NodeState parent)
  {
    return (NodeState) new CreateSigningRequestMethodState(parent);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYYIKBAAAAAAAHgAAAENyZWF0ZVNpZ25pbmdSZXF1ZXN0TWV0aG9kVHlwZQEAxTEALwEAxTHFMQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAMYxAC4ARMYxAACWBQAAAAEAKgEBIQAAABIAAABDZXJ0aWZpY2F0ZUdyb3VwSWQAEf////8AAAAAAAEAKgEBIAAAABEAAABDZXJ0aWZpY2F0ZVR5cGVJZAAR/////wAAAAAAAQAqAQEaAAAACwAAAFN1YmplY3ROYW1lAAz/////AAAAAAABACoBASMAAAAUAAAAUmVnZW5lcmF0ZVByaXZhdGVLZXkAAf////8AAAAAAAEAKgEBFAAAAAUAAABOb25jZQAP/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAxzEALgBExzEAAJYBAAAAAQAqAQEhAAAAEgAAAENlcnRpZmljYXRlUmVxdWVzdAAP/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
    NodeId inputArgument1 = (NodeId) _inputArguments[0];
    NodeId inputArgument2 = (NodeId) _inputArguments[1];
    string inputArgument3 = (string) _inputArguments[2];
    bool inputArgument4 = (bool) _inputArguments[3];
    byte[] inputArgument5 = (byte[]) _inputArguments[4];
    byte[] outputArgument = (byte[]) _outputArguments[0];
    if (this.OnCall != null)
      serviceResult = this.OnCall(_context, (MethodState) this, _objectId, inputArgument1, inputArgument2, inputArgument3, inputArgument4, inputArgument5, ref outputArgument);
    _outputArguments[0] = (object) outputArgument;
    return serviceResult;
  }
}
