// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AudioVariableState
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
public class AudioVariableState(NodeState parent) : BaseDataVariableState<byte[]>(parent)
{
  private const string ListId_InitializationString = "//////////8VYIkKAgAAAAAABgAAAExpc3RJZAEAREYALgBEREYAAAAM/////wEB/////wAAAAA=";
  private const string AgencyId_InitializationString = "//////////8VYIkKAgAAAAAACAAAAEFnZW5jeUlkAQBFRgAuAERFRgAAAAz/////AQH/////AAAAAA==";
  private const string VersionId_InitializationString = "//////////8VYIkKAgAAAAAACQAAAFZlcnNpb25JZAEARkYALgBERkYAAAAM/////wEB/////wAAAAA=";
  private const string InitializationString = "//////////8VYIkCAgAAAAAAGQAAAEF1ZGlvVmFyaWFibGVUeXBlSW5zdGFuY2UBAEJGAQBCRkJGAAABALM//////wEB/////wMAAAAVYIkKAgAAAAAABgAAAExpc3RJZAEAREYALgBEREYAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAEFnZW5jeUlkAQBFRgAuAERFRgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAVmVyc2lvbklkAQBGRgAuAERGRgAAAAz/////AQH/////AAAAAA==";
  private PropertyState<string> m_listId;
  private PropertyState<string> m_agencyId;
  private PropertyState<string> m_versionId;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 17986U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 16307U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIkCAgAAAAAAGQAAAEF1ZGlvVmFyaWFibGVUeXBlSW5zdGFuY2UBAEJGAQBCRkJGAAABALM//////wEB/////wMAAAAVYIkKAgAAAAAABgAAAExpc3RJZAEAREYALgBEREYAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAEFnZW5jeUlkAQBFRgAuAERFRgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAVmVyc2lvbklkAQBGRgAuAERGRgAAAAz/////AQH/////AAAAAA==");
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
    if (this.ListId != null)
      this.ListId.Initialize(context, "//////////8VYIkKAgAAAAAABgAAAExpc3RJZAEAREYALgBEREYAAAAM/////wEB/////wAAAAA=");
    if (this.AgencyId != null)
      this.AgencyId.Initialize(context, "//////////8VYIkKAgAAAAAACAAAAEFnZW5jeUlkAQBFRgAuAERFRgAAAAz/////AQH/////AAAAAA==");
    if (this.VersionId == null)
      return;
    this.VersionId.Initialize(context, "//////////8VYIkKAgAAAAAACQAAAFZlcnNpb25JZAEARkYALgBERkYAAAAM/////wEB/////wAAAAA=");
  }

  public PropertyState<string> ListId
  {
    get => this.m_listId;
    set
    {
      if (this.m_listId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_listId = value;
    }
  }

  public PropertyState<string> AgencyId
  {
    get => this.m_agencyId;
    set
    {
      if (this.m_agencyId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_agencyId = value;
    }
  }

  public PropertyState<string> VersionId
  {
    get => this.m_versionId;
    set
    {
      if (this.m_versionId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_versionId = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_listId != null)
      children.Add((BaseInstanceState) this.m_listId);
    if (this.m_agencyId != null)
      children.Add((BaseInstanceState) this.m_agencyId);
    if (this.m_versionId != null)
      children.Add((BaseInstanceState) this.m_versionId);
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
    switch (browseName.Name)
    {
      case "ListId":
        if (createOrReplace && this.ListId == null)
          this.ListId = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ListId;
        break;
      case "AgencyId":
        if (createOrReplace && this.AgencyId == null)
          this.AgencyId = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.AgencyId;
        break;
      case "VersionId":
        if (createOrReplace && this.VersionId == null)
          this.VersionId = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.VersionId;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
