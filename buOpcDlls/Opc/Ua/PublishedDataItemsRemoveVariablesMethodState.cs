// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PublishedDataItemsRemoveVariablesMethodState
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
public class PublishedDataItemsRemoveVariablesMethodState(NodeState parent) : MethodState(parent)
{
  private const string InitializationString = "//////////8EYYIKBAAAAAAAKwAAAFB1Ymxpc2hlZERhdGFJdGVtc1JlbW92ZVZhcmlhYmxlc01ldGhvZFR5cGUBAOc4AC8BAOc45zgAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDoOAAuAEToOAAAlgIAAAABACoBASUAAAAUAAAAQ29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAqAQEkAAAAEQAAAFZhcmlhYmxlc1RvUmVtb3ZlAAcBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEA6TgALgBE6TgAAJYCAAAAAQAqAQEoAAAAFwAAAE5ld0NvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBIAAAAA0AAABSZW1vdmVSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  public PublishedDataItemsRemoveVariablesMethodStateMethodCallHandler OnCall;

  public new static NodeState Construct(NodeState parent)
  {
    return (NodeState) new PublishedDataItemsRemoveVariablesMethodState(parent);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYYIKBAAAAAAAKwAAAFB1Ymxpc2hlZERhdGFJdGVtc1JlbW92ZVZhcmlhYmxlc01ldGhvZFR5cGUBAOc4AC8BAOc45zgAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDoOAAuAEToOAAAlgIAAAABACoBASUAAAAUAAAAQ29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAqAQEkAAAAEQAAAFZhcmlhYmxlc1RvUmVtb3ZlAAcBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEA6TgALgBE6TgAAJYCAAAAAQAqAQEoAAAAFwAAAE5ld0NvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBIAAAAA0AAABSZW1vdmVSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
    ConfigurationVersionDataType encodeable = (ConfigurationVersionDataType) ExtensionObject.ToEncodeable((ExtensionObject) _inputArguments[0]);
    uint[] inputArgument = (uint[]) _inputArguments[1];
    ConfigurationVersionDataType outputArgument1 = (ConfigurationVersionDataType) _outputArguments[0];
    StatusCode[] outputArgument2 = (StatusCode[]) _outputArguments[1];
    if (this.OnCall != null)
      serviceResult = this.OnCall(_context, (MethodState) this, _objectId, encodeable, inputArgument, ref outputArgument1, ref outputArgument2);
    _outputArguments[0] = (object) outputArgument1;
    _outputArguments[1] = (object) outputArgument2;
    return serviceResult;
  }
}
