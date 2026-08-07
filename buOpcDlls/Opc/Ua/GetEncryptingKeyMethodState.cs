// Decompiled with JetBrains decompiler
// Type: Opc.Ua.GetEncryptingKeyMethodState
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
public class GetEncryptingKeyMethodState(NodeState parent) : MethodState(parent)
{
  private const string InitializationString = "//////////8EYYIKBAAAAAAAGgAAAEdldEVuY3J5cHRpbmdLZXlNZXRob2RUeXBlAQB7RAAvAQB7RHtEAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAfEQALgBEfEQAAJYCAAAAAQAqAQEbAAAADAAAAENyZWRlbnRpYWxJZAAM/////wAAAAAAAQAqAQEpAAAAGgAAAFJlcXVlc3RlZFNlY3VyaXR5UG9saWN5VXJpAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQB9RAAuAER9RAAAlgIAAAABACoBARgAAAAJAAAAUHVibGljS2V5AA//////AAAAAAABACoBAScAAAAYAAAAUmV2aXNlZFNlY3VyaXR5UG9saWN5VXJpABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  public GetEncryptingKeyMethodStateMethodCallHandler OnCall;

  public new static NodeState Construct(NodeState parent)
  {
    return (NodeState) new GetEncryptingKeyMethodState(parent);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYYIKBAAAAAAAGgAAAEdldEVuY3J5cHRpbmdLZXlNZXRob2RUeXBlAQB7RAAvAQB7RHtEAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAfEQALgBEfEQAAJYCAAAAAQAqAQEbAAAADAAAAENyZWRlbnRpYWxJZAAM/////wAAAAAAAQAqAQEpAAAAGgAAAFJlcXVlc3RlZFNlY3VyaXR5UG9saWN5VXJpAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQB9RAAuAER9RAAAlgIAAAABACoBARgAAAAJAAAAUHVibGljS2V5AA//////AAAAAAABACoBAScAAAAYAAAAUmV2aXNlZFNlY3VyaXR5UG9saWN5VXJpABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
    byte[] outputArgument1 = (byte[]) _outputArguments[0];
    NodeId outputArgument2 = (NodeId) _outputArguments[1];
    if (this.OnCall != null)
      serviceResult = this.OnCall(_context, (MethodState) this, _objectId, inputArgument1, inputArgument2, ref outputArgument1, ref outputArgument2);
    _outputArguments[0] = (object) outputArgument1;
    _outputArguments[1] = (object) outputArgument2;
    return serviceResult;
  }
}
