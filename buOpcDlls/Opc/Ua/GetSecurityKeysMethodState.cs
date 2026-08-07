// Decompiled with JetBrains decompiler
// Type: Opc.Ua.GetSecurityKeysMethodState
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
public class GetSecurityKeysMethodState(NodeState parent) : MethodState(parent)
{
  private const string InitializationString = "//////////8EYYIKBAAAAAAAGQAAAEdldFNlY3VyaXR5S2V5c01ldGhvZFR5cGUBAHI7AC8BAHI7cjsAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBzOwAuAERzOwAAlgMAAAABACoBAR4AAAAPAAAAU2VjdXJpdHlHcm91cElkAAz/////AAAAAAABACoBASAAAAAPAAAAU3RhcnRpbmdUb2tlbklkAQAgAf////8AAAAAAAEAKgEBIAAAABEAAABSZXF1ZXN0ZWRLZXlDb3VudAAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAdDsALgBEdDsAAJYFAAAAAQAqAQEgAAAAEQAAAFNlY3VyaXR5UG9saWN5VXJpAAz/////AAAAAAABACoBAR0AAAAMAAAARmlyc3RUb2tlbklkAQAgAf////8AAAAAAAEAKgEBFwAAAAQAAABLZXlzAA8BAAAAAQAAAAAAAAAAAQAqAQEeAAAADQAAAFRpbWVUb05leHRLZXkBACIB/////wAAAAAAAQAqAQEcAAAACwAAAEtleUxpZmV0aW1lAQAiAf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";
  public GetSecurityKeysMethodStateMethodCallHandler OnCall;

  public new static NodeState Construct(NodeState parent)
  {
    return (NodeState) new GetSecurityKeysMethodState(parent);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYYIKBAAAAAAAGQAAAEdldFNlY3VyaXR5S2V5c01ldGhvZFR5cGUBAHI7AC8BAHI7cjsAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBzOwAuAERzOwAAlgMAAAABACoBAR4AAAAPAAAAU2VjdXJpdHlHcm91cElkAAz/////AAAAAAABACoBASAAAAAPAAAAU3RhcnRpbmdUb2tlbklkAQAgAf////8AAAAAAAEAKgEBIAAAABEAAABSZXF1ZXN0ZWRLZXlDb3VudAAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAdDsALgBEdDsAAJYFAAAAAQAqAQEgAAAAEQAAAFNlY3VyaXR5UG9saWN5VXJpAAz/////AAAAAAABACoBAR0AAAAMAAAARmlyc3RUb2tlbklkAQAgAf////8AAAAAAAEAKgEBFwAAAAQAAABLZXlzAA8BAAAAAQAAAAAAAAAAAQAqAQEeAAAADQAAAFRpbWVUb05leHRLZXkBACIB/////wAAAAAAAQAqAQEcAAAACwAAAEtleUxpZmV0aW1lAQAiAf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
    uint inputArgument2 = (uint) _inputArguments[1];
    uint inputArgument3 = (uint) _inputArguments[2];
    string outputArgument1 = (string) _outputArguments[0];
    uint outputArgument2 = (uint) _outputArguments[1];
    byte[][] outputArgument3 = (byte[][]) _outputArguments[2];
    double outputArgument4 = (double) _outputArguments[3];
    double outputArgument5 = (double) _outputArguments[4];
    if (this.OnCall != null)
      serviceResult = this.OnCall(_context, (MethodState) this, _objectId, inputArgument1, inputArgument2, inputArgument3, ref outputArgument1, ref outputArgument2, ref outputArgument3, ref outputArgument4, ref outputArgument5);
    _outputArguments[0] = (object) outputArgument1;
    _outputArguments[1] = (object) outputArgument2;
    _outputArguments[2] = (object) outputArgument3;
    _outputArguments[3] = (object) outputArgument4;
    _outputArguments[4] = (object) outputArgument5;
    return serviceResult;
  }
}
