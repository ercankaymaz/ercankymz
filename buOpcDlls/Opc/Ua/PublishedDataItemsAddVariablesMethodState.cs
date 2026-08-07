// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PublishedDataItemsAddVariablesMethodState
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
public class PublishedDataItemsAddVariablesMethodState(NodeState parent) : MethodState(parent)
{
  private const string InitializationString = "//////////8EYYIKBAAAAAAAKAAAAFB1Ymxpc2hlZERhdGFJdGVtc0FkZFZhcmlhYmxlc01ldGhvZFR5cGUBAOQ4AC8BAOQ45DgAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDlOAAuAETlOAAAlgQAAAABACoBASUAAAAUAAAAQ29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAqAQEjAAAAEAAAAEZpZWxkTmFtZUFsaWFzZXMADAEAAAABAAAAAAAAAAABACoBASEAAAAOAAAAUHJvbW90ZWRGaWVsZHMAAQEAAAABAAAAAAAAAAABACoBASMAAAAOAAAAVmFyaWFibGVzVG9BZGQBAME3AQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAOY4AC4AROY4AACWAgAAAAEAKgEBKAAAABcAAABOZXdDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBAR0AAAAKAAAAQWRkUmVzdWx0cwATAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";
  public PublishedDataItemsAddVariablesMethodStateMethodCallHandler OnCall;

  public new static NodeState Construct(NodeState parent)
  {
    return (NodeState) new PublishedDataItemsAddVariablesMethodState(parent);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYYIKBAAAAAAAKAAAAFB1Ymxpc2hlZERhdGFJdGVtc0FkZFZhcmlhYmxlc01ldGhvZFR5cGUBAOQ4AC8BAOQ45DgAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDlOAAuAETlOAAAlgQAAAABACoBASUAAAAUAAAAQ29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAqAQEjAAAAEAAAAEZpZWxkTmFtZUFsaWFzZXMADAEAAAABAAAAAAAAAAABACoBASEAAAAOAAAAUHJvbW90ZWRGaWVsZHMAAQEAAAABAAAAAAAAAAABACoBASMAAAAOAAAAVmFyaWFibGVzVG9BZGQBAME3AQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAOY4AC4AROY4AACWAgAAAAEAKgEBKAAAABcAAABOZXdDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBAR0AAAAKAAAAQWRkUmVzdWx0cwATAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
    PublishedVariableDataType[] array = (PublishedVariableDataType[]) ExtensionObject.ToArray(_inputArguments[3], typeof (PublishedVariableDataType));
    ConfigurationVersionDataType outputArgument1 = (ConfigurationVersionDataType) _outputArguments[0];
    StatusCode[] outputArgument2 = (StatusCode[]) _outputArguments[1];
    if (this.OnCall != null)
      serviceResult = this.OnCall(_context, (MethodState) this, _objectId, encodeable, inputArgument1, inputArgument2, array, ref outputArgument1, ref outputArgument2);
    _outputArguments[0] = (object) outputArgument1;
    _outputArguments[1] = (object) outputArgument2;
    return serviceResult;
  }
}
