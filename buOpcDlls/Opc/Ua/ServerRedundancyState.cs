// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ServerRedundancyState
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
public class ServerRedundancyState(NodeState parent) : BaseObjectState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAHAAAAFNlcnZlclJlZHVuZGFuY3lUeXBlSW5zdGFuY2UBAPIHAQDyB/IHAAD/////AQAAABVgiQoCAAAAAAARAAAAUmVkdW5kYW5jeVN1cHBvcnQBAPMHAC4ARPMHAAABAFMD/////wEB/////wAAAAA=";
  private PropertyState<Opc.Ua.RedundancySupport> m_redundancySupport;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2034U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAHAAAAFNlcnZlclJlZHVuZGFuY3lUeXBlSW5zdGFuY2UBAPIHAQDyB/IHAAD/////AQAAABVgiQoCAAAAAAARAAAAUmVkdW5kYW5jeVN1cHBvcnQBAPMHAC4ARPMHAAABAFMD/////wEB/////wAAAAA=");
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

  public PropertyState<Opc.Ua.RedundancySupport> RedundancySupport
  {
    get => this.m_redundancySupport;
    set
    {
      if (this.m_redundancySupport != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_redundancySupport = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_redundancySupport != null)
      children.Add((BaseInstanceState) this.m_redundancySupport);
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
    if (browseName.Name == "RedundancySupport")
    {
      if (createOrReplace && this.RedundancySupport == null)
        this.RedundancySupport = replacement != null ? (PropertyState<Opc.Ua.RedundancySupport>) replacement : new PropertyState<Opc.Ua.RedundancySupport>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.RedundancySupport;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
