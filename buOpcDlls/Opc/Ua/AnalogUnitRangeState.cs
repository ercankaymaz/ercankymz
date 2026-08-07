// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AnalogUnitRangeState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AnalogUnitRangeState(NodeState parent) : AnalogItemState(parent)
{
  private const string InitializationString = "//////////8VYIECAgAAAAAAGwAAAEFuYWxvZ1VuaXRSYW5nZVR5cGVJbnN0YW5jZQEAokQBAKJEokQAAAAaAQH/////AgAAABVgiQoCAAAAAAAHAAAARVVSYW5nZQEApkQALgBEpkQAAAEAdAP/////AQH/////AAAAABVgiQoCAAAAAAAQAAAARW5naW5lZXJpbmdVbml0cwEAp0QALgBEp0QAAAEAdwP/////AQH/////AAAAAA==";

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 17570U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 26U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIECAgAAAAAAGwAAAEFuYWxvZ1VuaXRSYW5nZVR5cGVJbnN0YW5jZQEAokQBAKJEokQAAAAaAQH/////AgAAABVgiQoCAAAAAAAHAAAARVVSYW5nZQEApkQALgBEpkQAAAEAdAP/////AQH/////AAAAABVgiQoCAAAAAAAQAAAARW5naW5lZXJpbmdVbml0cwEAp0QALgBEp0QAAAEAdwP/////AQH/////AAAAAA==");
    this.InitializeOptionalChildren(context);
  }

  protected override void Initialize(ISystemContext context, NodeState source)
  {
    this.InitializeOptionalChildren(context);
    base.Initialize(context, source);
  }

  protected override void InitializeOptionalChildren(ISystemContext context)
  {
    base.InitializeOptionalChildren(context);
  }
}
