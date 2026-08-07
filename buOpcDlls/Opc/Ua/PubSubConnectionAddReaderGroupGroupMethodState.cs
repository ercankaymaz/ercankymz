// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PubSubConnectionAddReaderGroupGroupMethodState
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
public class PubSubConnectionAddReaderGroupGroupMethodState(NodeState parent) : MethodState(parent)
{
  private const string InitializationString = "//////////8EYYIKBAAAAAAALQAAAFB1YlN1YkNvbm5lY3Rpb25BZGRSZWFkZXJHcm91cEdyb3VwTWV0aG9kVHlwZQEA3kQALwEA3kTeRAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAN9EAC4ARN9EAACWAQAAAAEAKgEBHgAAAA0AAABDb25maWd1cmF0aW9uAQCgPP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBADhFAC4ARDhFAACWAQAAAAEAKgEBFgAAAAcAAABHcm91cElkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  public PubSubConnectionAddReaderGroupGroupMethodStateMethodCallHandler OnCall;

  public new static NodeState Construct(NodeState parent)
  {
    return (NodeState) new PubSubConnectionAddReaderGroupGroupMethodState(parent);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYYIKBAAAAAAALQAAAFB1YlN1YkNvbm5lY3Rpb25BZGRSZWFkZXJHcm91cEdyb3VwTWV0aG9kVHlwZQEA3kQALwEA3kTeRAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAN9EAC4ARN9EAACWAQAAAAEAKgEBHgAAAA0AAABDb25maWd1cmF0aW9uAQCgPP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBADhFAC4ARDhFAACWAQAAAAEAKgEBFgAAAAcAAABHcm91cElkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
    ReaderGroupDataType encodeable = (ReaderGroupDataType) ExtensionObject.ToEncodeable((ExtensionObject) _inputArguments[0]);
    NodeId outputArgument = (NodeId) _outputArguments[0];
    if (this.OnCall != null)
      serviceResult = this.OnCall(_context, (MethodState) this, _objectId, encodeable, ref outputArgument);
    _outputArguments[0] = (object) outputArgument;
    return serviceResult;
  }
}
