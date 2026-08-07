// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataSetReaderTypeCreateDataSetMirrorMethodState
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
public class DataSetReaderTypeCreateDataSetMirrorMethodState(NodeState parent) : MethodState(parent)
{
  private const string InitializationString = "//////////8EYYIKBAAAAAAALgAAAERhdGFTZXRSZWFkZXJUeXBlQ3JlYXRlRGF0YVNldE1pcnJvck1ldGhvZFR5cGUBAPNDAC8BAPND80MAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQD0QwAuAET0QwAAlgIAAAABACoBAR0AAAAOAAAAUGFyZW50Tm9kZU5hbWUADP////8AAAAAAAEAKgEBIgAAAA8AAABSb2xlUGVybWlzc2lvbnMAYAEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQD1QwAuAET1QwAAlgEAAAABACoBARsAAAAMAAAAUGFyZW50Tm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  public DataSetReaderTypeCreateDataSetMirrorMethodStateMethodCallHandler OnCall;

  public new static NodeState Construct(NodeState parent)
  {
    return (NodeState) new DataSetReaderTypeCreateDataSetMirrorMethodState(parent);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYYIKBAAAAAAALgAAAERhdGFTZXRSZWFkZXJUeXBlQ3JlYXRlRGF0YVNldE1pcnJvck1ldGhvZFR5cGUBAPNDAC8BAPND80MAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQD0QwAuAET0QwAAlgIAAAABACoBAR0AAAAOAAAAUGFyZW50Tm9kZU5hbWUADP////8AAAAAAAEAKgEBIgAAAA8AAABSb2xlUGVybWlzc2lvbnMAYAEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQD1QwAuAET1QwAAlgEAAAABACoBARsAAAAMAAAAUGFyZW50Tm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
    string inputArgument = (string) _inputArguments[0];
    RolePermissionType[] array = (RolePermissionType[]) ExtensionObject.ToArray(_inputArguments[1], typeof (RolePermissionType));
    NodeId outputArgument = (NodeId) _outputArguments[0];
    if (this.OnCall != null)
      serviceResult = this.OnCall(_context, (MethodState) this, _objectId, inputArgument, array, ref outputArgument);
    _outputArguments[0] = (object) outputArgument;
    return serviceResult;
  }
}
