// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CreateCredentialMethodState
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
public class CreateCredentialMethodState(NodeState parent) : MethodState(parent)
{
  private const string InitializationString = "//////////8EYYIKBAAAAAAAGgAAAENyZWF0ZUNyZWRlbnRpYWxNZXRob2RUeXBlAQCQOwAvAQCQO5A7AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAlTsALgBElTsAAJYDAAAAAQAqAQEaAAAACwAAAFJlc291cmNlVXJpAAz/////AAAAAAABACoBARkAAAAKAAAAUHJvZmlsZVVyaQAM/////wAAAAAAAQAqAQEfAAAADAAAAEVuZHBvaW50VXJscwAMAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAFdEAC4ARFdEAACWAQAAAAEAKgEBHwAAABAAAABDcmVkZW50aWFsTm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  public CreateCredentialMethodStateMethodCallHandler OnCall;

  public new static NodeState Construct(NodeState parent)
  {
    return (NodeState) new CreateCredentialMethodState(parent);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYYIKBAAAAAAAGgAAAENyZWF0ZUNyZWRlbnRpYWxNZXRob2RUeXBlAQCQOwAvAQCQO5A7AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAlTsALgBElTsAAJYDAAAAAQAqAQEaAAAACwAAAFJlc291cmNlVXJpAAz/////AAAAAAABACoBARkAAAAKAAAAUHJvZmlsZVVyaQAM/////wAAAAAAAQAqAQEfAAAADAAAAEVuZHBvaW50VXJscwAMAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAFdEAC4ARFdEAACWAQAAAAEAKgEBHwAAABAAAABDcmVkZW50aWFsTm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
    string inputArgument2 = (string) _inputArguments[1];
    string[] inputArgument3 = (string[]) _inputArguments[2];
    NodeId outputArgument = (NodeId) _outputArguments[0];
    if (this.OnCall != null)
      serviceResult = this.OnCall(_context, (MethodState) this, _objectId, inputArgument1, inputArgument2, inputArgument3, ref outputArgument);
    _outputArguments[0] = (object) outputArgument;
    return serviceResult;
  }
}
