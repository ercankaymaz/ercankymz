// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RemoveIdentityMethodState
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
public class RemoveIdentityMethodState(NodeState parent) : MethodState(parent)
{
  private const string InitializationString = "//////////8EYYIKBAAAAAAAGAAAAFJlbW92ZUlkZW50aXR5TWV0aG9kVHlwZQEAFj0ALwEAFj0WPQAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBABc9AC4ARBc9AACWAQAAAAEAKgEBFQAAAAQAAABSdWxlAQASPf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";
  public RemoveIdentityMethodStateMethodCallHandler OnCall;

  public new static NodeState Construct(NodeState parent)
  {
    return (NodeState) new RemoveIdentityMethodState(parent);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYYIKBAAAAAAAGAAAAFJlbW92ZUlkZW50aXR5TWV0aG9kVHlwZQEAFj0ALwEAFj0WPQAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBABc9AC4ARBc9AACWAQAAAAEAKgEBFQAAAAQAAABSdWxlAQASPf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
    IdentityMappingRuleType encodeable = (IdentityMappingRuleType) ExtensionObject.ToEncodeable((ExtensionObject) _inputArguments[0]);
    if (this.OnCall != null)
      serviceResult = this.OnCall(_context, (MethodState) this, _objectId, encodeable);
    return serviceResult;
  }
}
