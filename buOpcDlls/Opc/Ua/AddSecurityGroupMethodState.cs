// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AddSecurityGroupMethodState
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
public class AddSecurityGroupMethodState(NodeState parent) : MethodState(parent)
{
  private const string InitializationString = "//////////8EYYIKBAAAAAAAGgAAAEFkZFNlY3VyaXR5R3JvdXBNZXRob2RUeXBlAQBqPAAvAQBqPGo8AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAazwALgBEazwAAJYFAAAAAQAqAQEgAAAAEQAAAFNlY3VyaXR5R3JvdXBOYW1lAAz/////AAAAAAABACoBARwAAAALAAAAS2V5TGlmZXRpbWUBACIB/////wAAAAAAAQAqAQEgAAAAEQAAAFNlY3VyaXR5UG9saWN5VXJpAAz/////AAAAAAABACoBASAAAAARAAAATWF4RnV0dXJlS2V5Q291bnQAB/////8AAAAAAAEAKgEBHgAAAA8AAABNYXhQYXN0S2V5Q291bnQAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAGw8AC4ARGw8AACWAgAAAAEAKgEBHgAAAA8AAABTZWN1cml0eUdyb3VwSWQADP////8AAAAAAAEAKgEBIgAAABMAAABTZWN1cml0eUdyb3VwTm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  public AddSecurityGroupMethodStateMethodCallHandler OnCall;

  public new static NodeState Construct(NodeState parent)
  {
    return (NodeState) new AddSecurityGroupMethodState(parent);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYYIKBAAAAAAAGgAAAEFkZFNlY3VyaXR5R3JvdXBNZXRob2RUeXBlAQBqPAAvAQBqPGo8AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAazwALgBEazwAAJYFAAAAAQAqAQEgAAAAEQAAAFNlY3VyaXR5R3JvdXBOYW1lAAz/////AAAAAAABACoBARwAAAALAAAAS2V5TGlmZXRpbWUBACIB/////wAAAAAAAQAqAQEgAAAAEQAAAFNlY3VyaXR5UG9saWN5VXJpAAz/////AAAAAAABACoBASAAAAARAAAATWF4RnV0dXJlS2V5Q291bnQAB/////8AAAAAAAEAKgEBHgAAAA8AAABNYXhQYXN0S2V5Q291bnQAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAGw8AC4ARGw8AACWAgAAAAEAKgEBHgAAAA8AAABTZWN1cml0eUdyb3VwSWQADP////8AAAAAAAEAKgEBIgAAABMAAABTZWN1cml0eUdyb3VwTm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
    double inputArgument2 = (double) _inputArguments[1];
    string inputArgument3 = (string) _inputArguments[2];
    uint inputArgument4 = (uint) _inputArguments[3];
    uint inputArgument5 = (uint) _inputArguments[4];
    string outputArgument1 = (string) _outputArguments[0];
    NodeId outputArgument2 = (NodeId) _outputArguments[1];
    if (this.OnCall != null)
      serviceResult = this.OnCall(_context, (MethodState) this, _objectId, inputArgument1, inputArgument2, inputArgument3, inputArgument4, inputArgument5, ref outputArgument1, ref outputArgument2);
    _outputArguments[0] = (object) outputArgument1;
    _outputArguments[1] = (object) outputArgument2;
    return serviceResult;
  }
}
