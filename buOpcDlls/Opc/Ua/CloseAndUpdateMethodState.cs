// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CloseAndUpdateMethodState
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
public class CloseAndUpdateMethodState(NodeState parent) : MethodState(parent)
{
  private const string InitializationString = "//////////8EYYIKBAAAAAAAGAAAAENsb3NlQW5kVXBkYXRlTWV0aG9kVHlwZQEA5DAALwEA5DDkMAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAKAxAC4ARKAxAACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDlMAAuAETlMAAAlgEAAAABACoBASMAAAAUAAAAQXBwbHlDaGFuZ2VzUmVxdWlyZWQAAf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";
  public CloseAndUpdateMethodStateMethodCallHandler OnCall;

  public new static NodeState Construct(NodeState parent)
  {
    return (NodeState) new CloseAndUpdateMethodState(parent);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYYIKBAAAAAAAGAAAAENsb3NlQW5kVXBkYXRlTWV0aG9kVHlwZQEA5DAALwEA5DDkMAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAKAxAC4ARKAxAACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDlMAAuAETlMAAAlgEAAAABACoBASMAAAAUAAAAQXBwbHlDaGFuZ2VzUmVxdWlyZWQAAf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
    uint inputArgument = (uint) _inputArguments[0];
    bool outputArgument = (bool) _outputArguments[0];
    if (this.OnCall != null)
      serviceResult = this.OnCall(_context, (MethodState) this, _objectId, inputArgument, ref outputArgument);
    _outputArguments[0] = (object) outputArgument;
    return serviceResult;
  }
}
