// Decompiled with JetBrains decompiler
// Type: Opc.Ua.JsonWriterGroupMessageState
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
public class JsonWriterGroupMessageState(NodeState parent) : WriterGroupMessageState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAIgAAAEpzb25Xcml0ZXJHcm91cE1lc3NhZ2VUeXBlSW5zdGFuY2UBAIZSAQCGUoZSAAD/////AQAAABVgiQoCAAAAAAAZAAAATmV0d29ya01lc3NhZ2VDb250ZW50TWFzawEAh1IALgBEh1IAAAEAJj3/////AQH/////AAAAAA==";
  private PropertyState<uint> m_networkMessageContentMask;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 21126U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAIgAAAEpzb25Xcml0ZXJHcm91cE1lc3NhZ2VUeXBlSW5zdGFuY2UBAIZSAQCGUoZSAAD/////AQAAABVgiQoCAAAAAAAZAAAATmV0d29ya01lc3NhZ2VDb250ZW50TWFzawEAh1IALgBEh1IAAAEAJj3/////AQH/////AAAAAA==");
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

  public PropertyState<uint> NetworkMessageContentMask
  {
    get => this.m_networkMessageContentMask;
    set
    {
      if (this.m_networkMessageContentMask != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_networkMessageContentMask = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_networkMessageContentMask != null)
      children.Add((BaseInstanceState) this.m_networkMessageContentMask);
    base.GetChildren(context, children);
  }

  protected override BaseInstanceState FindChild(
    ISystemContext context,
    QualifiedName browseName,
    bool createOrReplace,
    BaseInstanceState replacement)
  {
    if (QualifiedName.IsNull(browseName))
      return (BaseInstanceState) null;
    BaseInstanceState baseInstanceState = (BaseInstanceState) null;
    if (browseName.Name == "NetworkMessageContentMask")
    {
      if (createOrReplace && this.NetworkMessageContentMask == null)
        this.NetworkMessageContentMask = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.NetworkMessageContentMask;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
