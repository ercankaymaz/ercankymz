// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AddPublishedEventsTemplateMethodState
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
public class AddPublishedEventsTemplateMethodState(NodeState parent) : MethodState(parent)
{
  private const string InitializationString = "//////////8EYYIKBAAAAAAAJAAAAEFkZFB1Ymxpc2hlZEV2ZW50c1RlbXBsYXRlTWV0aG9kVHlwZQEAiUIALwEAiUKJQgAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAJNCAC4ARJNCAACWBQAAAAEAKgEBEwAAAAQAAABOYW1lAAz/////AAAAAAABACoBASAAAAAPAAAARGF0YVNldE1ldGFEYXRhAQC7OP////8AAAAAAAEAKgEBHAAAAA0AAABFdmVudE5vdGlmaWVyABH/////AAAAAAABACoBASMAAAAOAAAAU2VsZWN0ZWRGaWVsZHMBAFkCAQAAAAEAAAAAAAAAAAEAKgEBFwAAAAYAAABGaWx0ZXIBAEoC/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAqkIALgBEqkIAAJYBAAAAAQAqAQEcAAAADQAAAERhdGFTZXROb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";
  public AddPublishedEventsTemplateMethodStateMethodCallHandler OnCall;

  public new static NodeState Construct(NodeState parent)
  {
    return (NodeState) new AddPublishedEventsTemplateMethodState(parent);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYYIKBAAAAAAAJAAAAEFkZFB1Ymxpc2hlZEV2ZW50c1RlbXBsYXRlTWV0aG9kVHlwZQEAiUIALwEAiUKJQgAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAJNCAC4ARJNCAACWBQAAAAEAKgEBEwAAAAQAAABOYW1lAAz/////AAAAAAABACoBASAAAAAPAAAARGF0YVNldE1ldGFEYXRhAQC7OP////8AAAAAAAEAKgEBHAAAAA0AAABFdmVudE5vdGlmaWVyABH/////AAAAAAABACoBASMAAAAOAAAAU2VsZWN0ZWRGaWVsZHMBAFkCAQAAAAEAAAAAAAAAAAEAKgEBFwAAAAYAAABGaWx0ZXIBAEoC/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAqkIALgBEqkIAAJYBAAAAAQAqAQEcAAAADQAAAERhdGFTZXROb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
    DataSetMetaDataType encodeable1 = (DataSetMetaDataType) ExtensionObject.ToEncodeable((ExtensionObject) _inputArguments[1]);
    NodeId inputArgument2 = (NodeId) _inputArguments[2];
    SimpleAttributeOperand[] array = (SimpleAttributeOperand[]) ExtensionObject.ToArray(_inputArguments[3], typeof (SimpleAttributeOperand));
    ContentFilter encodeable2 = (ContentFilter) ExtensionObject.ToEncodeable((ExtensionObject) _inputArguments[4]);
    NodeId outputArgument = (NodeId) _outputArguments[0];
    if (this.OnCall != null)
      serviceResult = this.OnCall(_context, (MethodState) this, _objectId, inputArgument1, encodeable1, inputArgument2, array, encodeable2, ref outputArgument);
    _outputArguments[0] = (object) outputArgument;
    return serviceResult;
  }
}
