// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RemoveEndpointMethodState
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
public class RemoveEndpointMethodState(NodeState parent) : MethodState(parent)
{
  private const string InitializationString = "//////////8EYYIKBAAAAAAAGAAAAFJlbW92ZUVuZHBvaW50TWV0aG9kVHlwZQEAPj8ALwEAPj8+PwAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAD8/AC4ARD8/AACWAQAAAAEAKgEBGQAAAAgAAABFbmRwb2ludAEAqDz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  public RemoveEndpointMethodStateMethodCallHandler OnCall;

  public new static NodeState Construct(NodeState parent)
  {
    return (NodeState) new RemoveEndpointMethodState(parent);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYYIKBAAAAAAAGAAAAFJlbW92ZUVuZHBvaW50TWV0aG9kVHlwZQEAPj8ALwEAPj8+PwAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAD8/AC4ARD8/AACWAQAAAAEAKgEBGQAAAAgAAABFbmRwb2ludAEAqDz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
    EndpointType encodeable = (EndpointType) ExtensionObject.ToEncodeable((ExtensionObject) _inputArguments[0]);
    if (this.OnCall != null)
      serviceResult = this.OnCall(_context, (MethodState) this, _objectId, encodeable);
    return serviceResult;
  }
}
