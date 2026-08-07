// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AddPublishedDataItemsMethodState
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
public class AddPublishedDataItemsMethodState(NodeState parent) : MethodState(parent)
{
  private const string InitializationString = "//////////8EYYIKBAAAAAAAHwAAAEFkZFB1Ymxpc2hlZERhdGFJdGVtc01ldGhvZFR5cGUBAKU4AC8BAKU4pTgAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCmOAAuAESmOAAAlgQAAAABACoBARMAAAAEAAAATmFtZQAM/////wAAAAAAAQAqAQEjAAAAEAAAAEZpZWxkTmFtZUFsaWFzZXMADAEAAAABAAAAAAAAAAABACoBAR8AAAAKAAAARmllbGRGbGFncwEAID4BAAAAAQAAAAAAAAAAAQAqAQEjAAAADgAAAFZhcmlhYmxlc1RvQWRkAQDBNwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCnOAAuAESnOAAAlgMAAAABACoBARwAAAANAAAARGF0YVNldE5vZGVJZAAR/////wAAAAAAAQAqAQElAAAAFAAAAENvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  public AddPublishedDataItemsMethodStateMethodCallHandler OnCall;

  public new static NodeState Construct(NodeState parent)
  {
    return (NodeState) new AddPublishedDataItemsMethodState(parent);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYYIKBAAAAAAAHwAAAEFkZFB1Ymxpc2hlZERhdGFJdGVtc01ldGhvZFR5cGUBAKU4AC8BAKU4pTgAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCmOAAuAESmOAAAlgQAAAABACoBARMAAAAEAAAATmFtZQAM/////wAAAAAAAQAqAQEjAAAAEAAAAEZpZWxkTmFtZUFsaWFzZXMADAEAAAABAAAAAAAAAAABACoBAR8AAAAKAAAARmllbGRGbGFncwEAID4BAAAAAQAAAAAAAAAAAQAqAQEjAAAADgAAAFZhcmlhYmxlc1RvQWRkAQDBNwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCnOAAuAESnOAAAlgMAAAABACoBARwAAAANAAAARGF0YVNldE5vZGVJZAAR/////wAAAAAAAQAqAQElAAAAFAAAAENvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
    string[] inputArgument2 = (string[]) _inputArguments[1];
    ushort[] inputArgument3 = (ushort[]) _inputArguments[2];
    PublishedVariableDataType[] array = (PublishedVariableDataType[]) ExtensionObject.ToArray(_inputArguments[3], typeof (PublishedVariableDataType));
    NodeId outputArgument1 = (NodeId) _outputArguments[0];
    ConfigurationVersionDataType outputArgument2 = (ConfigurationVersionDataType) _outputArguments[1];
    StatusCode[] outputArgument3 = (StatusCode[]) _outputArguments[2];
    if (this.OnCall != null)
      serviceResult = this.OnCall(_context, (MethodState) this, _objectId, inputArgument1, inputArgument2, inputArgument3, array, ref outputArgument1, ref outputArgument2, ref outputArgument3);
    _outputArguments[0] = (object) outputArgument1;
    _outputArguments[1] = (object) outputArgument2;
    _outputArguments[2] = (object) outputArgument3;
    return serviceResult;
  }
}
