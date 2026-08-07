// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TargetVariablesTypeRemoveTargetVariablesMethodState
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
public class TargetVariablesTypeRemoveTargetVariablesMethodState(NodeState parent) : MethodState(parent)
{
  private const string InitializationString = "//////////8EYYIKBAAAAAAAMgAAAFRhcmdldFZhcmlhYmxlc1R5cGVSZW1vdmVUYXJnZXRWYXJpYWJsZXNNZXRob2RUeXBlAQAUOwAvAQAUOxQ7AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAFTsALgBEFTsAAJYCAAAAAQAqAQElAAAAFAAAAENvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBIgAAAA8AAABUYXJnZXRzVG9SZW1vdmUABwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQAWOwAuAEQWOwAAlgEAAAABACoBASAAAAANAAAAUmVtb3ZlUmVzdWx0cwATAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";
  public TargetVariablesTypeRemoveTargetVariablesMethodStateMethodCallHandler OnCall;

  public new static NodeState Construct(NodeState parent)
  {
    return (NodeState) new TargetVariablesTypeRemoveTargetVariablesMethodState(parent);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYYIKBAAAAAAAMgAAAFRhcmdldFZhcmlhYmxlc1R5cGVSZW1vdmVUYXJnZXRWYXJpYWJsZXNNZXRob2RUeXBlAQAUOwAvAQAUOxQ7AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAFTsALgBEFTsAAJYCAAAAAQAqAQElAAAAFAAAAENvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBIgAAAA8AAABUYXJnZXRzVG9SZW1vdmUABwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQAWOwAuAEQWOwAAlgEAAAABACoBASAAAAANAAAAUmVtb3ZlUmVzdWx0cwATAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
    StatusCode[] outputArgument = (StatusCode[]) _outputArguments[0];
    if (this.OnCall != null)
      serviceResult = this.OnCall(_context, (MethodState) this, _objectId, encodeable, inputArgument, ref outputArgument);
    _outputArguments[0] = (object) outputArgument;
    return serviceResult;
  }
}
