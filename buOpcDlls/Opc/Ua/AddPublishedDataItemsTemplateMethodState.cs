// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AddPublishedDataItemsTemplateMethodState
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
public class AddPublishedDataItemsTemplateMethodState(NodeState parent) : MethodState(parent)
{
  private const string InitializationString = "//////////8EYYIKBAAAAAAAJwAAAEFkZFB1Ymxpc2hlZERhdGFJdGVtc1RlbXBsYXRlTWV0aG9kVHlwZQEAhkIALwEAhkKGQgAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAIdCAC4ARIdCAACWAwAAAAEAKgEBEwAAAAQAAABOYW1lAAz/////AAAAAAABACoBASAAAAAPAAAARGF0YVNldE1ldGFEYXRhAQC7OP////8AAAAAAAEAKgEBIwAAAA4AAABWYXJpYWJsZXNUb0FkZAEAwTcBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAiEIALgBEiEIAAJYCAAAAAQAqAQEcAAAADQAAAERhdGFTZXROb2RlSWQAEf////8AAAAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  public AddPublishedDataItemsTemplateMethodStateMethodCallHandler OnCall;

  public new static NodeState Construct(NodeState parent)
  {
    return (NodeState) new AddPublishedDataItemsTemplateMethodState(parent);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYYIKBAAAAAAAJwAAAEFkZFB1Ymxpc2hlZERhdGFJdGVtc1RlbXBsYXRlTWV0aG9kVHlwZQEAhkIALwEAhkKGQgAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAIdCAC4ARIdCAACWAwAAAAEAKgEBEwAAAAQAAABOYW1lAAz/////AAAAAAABACoBASAAAAAPAAAARGF0YVNldE1ldGFEYXRhAQC7OP////8AAAAAAAEAKgEBIwAAAA4AAABWYXJpYWJsZXNUb0FkZAEAwTcBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAiEIALgBEiEIAAJYCAAAAAQAqAQEcAAAADQAAAERhdGFTZXROb2RlSWQAEf////8AAAAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
    string inputArgument = (string) _inputArguments[0];
    DataSetMetaDataType encodeable = (DataSetMetaDataType) ExtensionObject.ToEncodeable((ExtensionObject) _inputArguments[1]);
    PublishedVariableDataType[] array = (PublishedVariableDataType[]) ExtensionObject.ToArray(_inputArguments[2], typeof (PublishedVariableDataType));
    NodeId outputArgument1 = (NodeId) _outputArguments[0];
    StatusCode[] outputArgument2 = (StatusCode[]) _outputArguments[1];
    if (this.OnCall != null)
      serviceResult = this.OnCall(_context, (MethodState) this, _objectId, inputArgument, encodeable, array, ref outputArgument1, ref outputArgument2);
    _outputArguments[0] = (object) outputArgument1;
    _outputArguments[1] = (object) outputArgument2;
    return serviceResult;
  }
}
