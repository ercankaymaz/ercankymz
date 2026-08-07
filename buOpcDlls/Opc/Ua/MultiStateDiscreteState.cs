// Decompiled with JetBrains decompiler
// Type: Opc.Ua.MultiStateDiscreteState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class MultiStateDiscreteState(NodeState parent) : DiscreteItemState(parent)
{
  private const string InitializationString = "//////////8VYIECAgAAAAAAHgAAAE11bHRpU3RhdGVEaXNjcmV0ZVR5cGVJbnN0YW5jZQEASAkBAEgJSAkAAAAcAQH/////AQAAABdgiQoCAAAAAAALAAAARW51bVN0cmluZ3MBAEkJAC4AREkJAAAAFQEAAAABAAAAAAAAAAEB/////wAAAAA=";

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2376U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 28U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIECAgAAAAAAHgAAAE11bHRpU3RhdGVEaXNjcmV0ZVR5cGVJbnN0YW5jZQEASAkBAEgJSAkAAAAcAQH/////AQAAABdgiQoCAAAAAAALAAAARW51bVN0cmluZ3MBAEkJAC4AREkJAAAAFQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
