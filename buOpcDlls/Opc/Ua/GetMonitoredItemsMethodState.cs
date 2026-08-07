// Decompiled with JetBrains decompiler
// Type: Opc.Ua.GetMonitoredItemsMethodState
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
public class GetMonitoredItemsMethodState(NodeState parent) : MethodState(parent)
{
  private const string InitializationString = "//////////8EYYIKBAAAAAAAGwAAAEdldE1vbml0b3JlZEl0ZW1zTWV0aG9kVHlwZQEA5ywALwEA5yznLAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAOgsAC4AROgsAACWAQAAAAEAKgEBHQAAAA4AAABTdWJzY3JpcHRpb25JZAAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEA6SwALgBE6SwAAJYCAAAAAQAqAQEgAAAADQAAAFNlcnZlckhhbmRsZXMABwEAAAABAAAAAAAAAAABACoBASAAAAANAAAAQ2xpZW50SGFuZGxlcwAHAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";
  public GetMonitoredItemsMethodStateMethodCallHandler OnCall;

  public new static NodeState Construct(NodeState parent)
  {
    return (NodeState) new GetMonitoredItemsMethodState(parent);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYYIKBAAAAAAAGwAAAEdldE1vbml0b3JlZEl0ZW1zTWV0aG9kVHlwZQEA5ywALwEA5yznLAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAOgsAC4AROgsAACWAQAAAAEAKgEBHQAAAA4AAABTdWJzY3JpcHRpb25JZAAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEA6SwALgBE6SwAAJYCAAAAAQAqAQEgAAAADQAAAFNlcnZlckhhbmRsZXMABwEAAAABAAAAAAAAAAABACoBASAAAAANAAAAQ2xpZW50SGFuZGxlcwAHAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
    uint[] outputArgument1 = (uint[]) _outputArguments[0];
    uint[] outputArgument2 = (uint[]) _outputArguments[1];
    if (this.OnCall != null)
      serviceResult = this.OnCall(_context, (MethodState) this, _objectId, inputArgument, ref outputArgument1, ref outputArgument2);
    _outputArguments[0] = (object) outputArgument1;
    _outputArguments[1] = (object) outputArgument2;
    return serviceResult;
  }
}
