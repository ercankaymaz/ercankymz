// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PublishedEventsTypeModifyFieldSelectionMethodState
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
public class PublishedEventsTypeModifyFieldSelectionMethodState(NodeState parent) : MethodState(parent)
{
  private const string InitializationString = "//////////8EYYIKBAAAAAAAMQAAAFB1Ymxpc2hlZEV2ZW50c1R5cGVNb2RpZnlGaWVsZFNlbGVjdGlvbk1ldGhvZFR5cGUBAM46AC8BAM46zjoAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDPOgAuAETPOgAAlgQAAAABACoBASUAAAAUAAAAQ29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAqAQEjAAAAEAAAAEZpZWxkTmFtZUFsaWFzZXMADAEAAAABAAAAAAAAAAABACoBASEAAAAOAAAAUHJvbW90ZWRGaWVsZHMAAQEAAAABAAAAAAAAAAABACoBASMAAAAOAAAAU2VsZWN0ZWRGaWVsZHMBAFkCAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAJ48AC4ARJ48AACWAQAAAAEAKgEBKAAAABcAAABOZXdDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  public PublishedEventsTypeModifyFieldSelectionMethodStateMethodCallHandler OnCall;

  public new static NodeState Construct(NodeState parent)
  {
    return (NodeState) new PublishedEventsTypeModifyFieldSelectionMethodState(parent);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYYIKBAAAAAAAMQAAAFB1Ymxpc2hlZEV2ZW50c1R5cGVNb2RpZnlGaWVsZFNlbGVjdGlvbk1ldGhvZFR5cGUBAM46AC8BAM46zjoAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDPOgAuAETPOgAAlgQAAAABACoBASUAAAAUAAAAQ29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAqAQEjAAAAEAAAAEZpZWxkTmFtZUFsaWFzZXMADAEAAAABAAAAAAAAAAABACoBASEAAAAOAAAAUHJvbW90ZWRGaWVsZHMAAQEAAAABAAAAAAAAAAABACoBASMAAAAOAAAAU2VsZWN0ZWRGaWVsZHMBAFkCAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAJ48AC4ARJ48AACWAQAAAAEAKgEBKAAAABcAAABOZXdDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
    string[] inputArgument1 = (string[]) _inputArguments[1];
    bool[] inputArgument2 = (bool[]) _inputArguments[2];
    SimpleAttributeOperand[] array = (SimpleAttributeOperand[]) ExtensionObject.ToArray(_inputArguments[3], typeof (SimpleAttributeOperand));
    ConfigurationVersionDataType outputArgument = (ConfigurationVersionDataType) _outputArguments[0];
    if (this.OnCall != null)
      serviceResult = this.OnCall(_context, (MethodState) this, _objectId, encodeable, inputArgument1, inputArgument2, array, ref outputArgument);
    _outputArguments[0] = (object) outputArgument;
    return serviceResult;
  }
}
