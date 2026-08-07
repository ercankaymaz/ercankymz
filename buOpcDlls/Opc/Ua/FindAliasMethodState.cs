// Decompiled with JetBrains decompiler
// Type: Opc.Ua.FindAliasMethodState
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
public class FindAliasMethodState(NodeState parent) : MethodState(parent)
{
  private const string InitializationString = "//////////8EYYIKBAAAAAAAEwAAAEZpbmRBbGlhc01ldGhvZFR5cGUBAKlbAC8BAKlbqVsAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCqWwAuAESqWwAAlgIAAAABACoBASUAAAAWAAAAQWxpYXNOYW1lU2VhcmNoUGF0dGVybgAM/////wAAAAAAAQAqAQEiAAAAEwAAAFJlZmVyZW5jZVR5cGVGaWx0ZXIAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAKtbAC4ARKtbAACWAQAAAAEAKgEBIgAAAA0AAABBbGlhc05vZGVMaXN0AQCsWwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  public FindAliasMethodStateMethodCallHandler OnCall;

  public new static NodeState Construct(NodeState parent)
  {
    return (NodeState) new FindAliasMethodState(parent);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYYIKBAAAAAAAEwAAAEZpbmRBbGlhc01ldGhvZFR5cGUBAKlbAC8BAKlbqVsAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCqWwAuAESqWwAAlgIAAAABACoBASUAAAAWAAAAQWxpYXNOYW1lU2VhcmNoUGF0dGVybgAM/////wAAAAAAAQAqAQEiAAAAEwAAAFJlZmVyZW5jZVR5cGVGaWx0ZXIAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAKtbAC4ARKtbAACWAQAAAAEAKgEBIgAAAA0AAABBbGlhc05vZGVMaXN0AQCsWwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
    string inputArgument1 = (string) _inputArguments[0];
    NodeId inputArgument2 = (NodeId) _inputArguments[1];
    AliasNameDataType[] outputArgument = (AliasNameDataType[]) _outputArguments[0];
    if (this.OnCall != null)
      serviceResult = this.OnCall(_context, (MethodState) this, _objectId, inputArgument1, inputArgument2, ref outputArgument);
    _outputArguments[0] = (object) outputArgument;
    return serviceResult;
  }
}
