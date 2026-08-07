// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AddPublishedEventsMethodState
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
public class AddPublishedEventsMethodState(NodeState parent) : MethodState(parent)
{
  private const string InitializationString = "//////////8EYYIKBAAAAAAAHAAAAEFkZFB1Ymxpc2hlZEV2ZW50c01ldGhvZFR5cGUBAKg4AC8BAKg4qDgAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCpOAAuAESpOAAAlgYAAAABACoBARMAAAAEAAAATmFtZQAM/////wAAAAAAAQAqAQEcAAAADQAAAEV2ZW50Tm90aWZpZXIAEf////8AAAAAAAEAKgEBIwAAABAAAABGaWVsZE5hbWVBbGlhc2VzAAwBAAAAAQAAAAAAAAAAAQAqAQEfAAAACgAAAEZpZWxkRmxhZ3MBACA+AQAAAAEAAAAAAAAAAAEAKgEBIwAAAA4AAABTZWxlY3RlZEZpZWxkcwEAWQIBAAAAAQAAAAAAAAAAAQAqAQEXAAAABgAAAEZpbHRlcgEASgL/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCqOAAuAESqOAAAlgIAAAABACoBASUAAAAUAAAAQ29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAqAQEcAAAADQAAAERhdGFTZXROb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";
  public AddPublishedEventsMethodStateMethodCallHandler OnCall;

  public new static NodeState Construct(NodeState parent)
  {
    return (NodeState) new AddPublishedEventsMethodState(parent);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYYIKBAAAAAAAHAAAAEFkZFB1Ymxpc2hlZEV2ZW50c01ldGhvZFR5cGUBAKg4AC8BAKg4qDgAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCpOAAuAESpOAAAlgYAAAABACoBARMAAAAEAAAATmFtZQAM/////wAAAAAAAQAqAQEcAAAADQAAAEV2ZW50Tm90aWZpZXIAEf////8AAAAAAAEAKgEBIwAAABAAAABGaWVsZE5hbWVBbGlhc2VzAAwBAAAAAQAAAAAAAAAAAQAqAQEfAAAACgAAAEZpZWxkRmxhZ3MBACA+AQAAAAEAAAAAAAAAAAEAKgEBIwAAAA4AAABTZWxlY3RlZEZpZWxkcwEAWQIBAAAAAQAAAAAAAAAAAQAqAQEXAAAABgAAAEZpbHRlcgEASgL/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCqOAAuAESqOAAAlgIAAAABACoBASUAAAAUAAAAQ29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAqAQEcAAAADQAAAERhdGFTZXROb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
    NodeId inputArgument2 = (NodeId) _inputArguments[1];
    string[] inputArgument3 = (string[]) _inputArguments[2];
    ushort[] inputArgument4 = (ushort[]) _inputArguments[3];
    SimpleAttributeOperand[] array = (SimpleAttributeOperand[]) ExtensionObject.ToArray(_inputArguments[4], typeof (SimpleAttributeOperand));
    ContentFilter encodeable = (ContentFilter) ExtensionObject.ToEncodeable((ExtensionObject) _inputArguments[5]);
    ConfigurationVersionDataType outputArgument1 = (ConfigurationVersionDataType) _outputArguments[0];
    NodeId outputArgument2 = (NodeId) _outputArguments[1];
    if (this.OnCall != null)
      serviceResult = this.OnCall(_context, (MethodState) this, _objectId, inputArgument1, inputArgument2, inputArgument3, inputArgument4, array, encodeable, ref outputArgument1, ref outputArgument2);
    _outputArguments[0] = (object) outputArgument1;
    _outputArguments[1] = (object) outputArgument2;
    return serviceResult;
  }
}
