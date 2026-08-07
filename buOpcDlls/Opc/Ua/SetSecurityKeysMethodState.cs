// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SetSecurityKeysMethodState
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
public class SetSecurityKeysMethodState(NodeState parent) : MethodState(parent)
{
  private const string InitializationString = "//////////8EYYIKBAAAAAAAGQAAAFNldFNlY3VyaXR5S2V5c01ldGhvZFR5cGUBAJJDAC8BAJJDkkMAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCTQwAuAESTQwAAlgcAAAABACoBAR4AAAAPAAAAU2VjdXJpdHlHcm91cElkAAz/////AAAAAAABACoBASAAAAARAAAAU2VjdXJpdHlQb2xpY3lVcmkADP////8AAAAAAAEAKgEBHwAAAA4AAABDdXJyZW50VG9rZW5JZAEAIAH/////AAAAAAABACoBARkAAAAKAAAAQ3VycmVudEtleQAP/////wAAAAAAAQAqAQEdAAAACgAAAEZ1dHVyZUtleXMADwEAAAABAAAAAAAAAAABACoBAR4AAAANAAAAVGltZVRvTmV4dEtleQEAIgH/////AAAAAAABACoBARwAAAALAAAAS2V5TGlmZXRpbWUBACIB/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  public SetSecurityKeysMethodStateMethodCallHandler OnCall;

  public new static NodeState Construct(NodeState parent)
  {
    return (NodeState) new SetSecurityKeysMethodState(parent);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYYIKBAAAAAAAGQAAAFNldFNlY3VyaXR5S2V5c01ldGhvZFR5cGUBAJJDAC8BAJJDkkMAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCTQwAuAESTQwAAlgcAAAABACoBAR4AAAAPAAAAU2VjdXJpdHlHcm91cElkAAz/////AAAAAAABACoBASAAAAARAAAAU2VjdXJpdHlQb2xpY3lVcmkADP////8AAAAAAAEAKgEBHwAAAA4AAABDdXJyZW50VG9rZW5JZAEAIAH/////AAAAAAABACoBARkAAAAKAAAAQ3VycmVudEtleQAP/////wAAAAAAAQAqAQEdAAAACgAAAEZ1dHVyZUtleXMADwEAAAABAAAAAAAAAAABACoBAR4AAAANAAAAVGltZVRvTmV4dEtleQEAIgH/////AAAAAAABACoBARwAAAALAAAAS2V5TGlmZXRpbWUBACIB/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
    string inputArgument2 = (string) _inputArguments[1];
    uint inputArgument3 = (uint) _inputArguments[2];
    byte[] inputArgument4 = (byte[]) _inputArguments[3];
    byte[][] inputArgument5 = (byte[][]) _inputArguments[4];
    double inputArgument6 = (double) _inputArguments[5];
    double inputArgument7 = (double) _inputArguments[6];
    if (this.OnCall != null)
      serviceResult = this.OnCall(_context, (MethodState) this, _objectId, inputArgument1, inputArgument2, inputArgument3, inputArgument4, inputArgument5, inputArgument6, inputArgument7);
    return serviceResult;
  }
}
