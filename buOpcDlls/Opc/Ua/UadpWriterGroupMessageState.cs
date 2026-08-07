// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UadpWriterGroupMessageState
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
public class UadpWriterGroupMessageState(NodeState parent) : WriterGroupMessageState(parent)
{
  private const string SamplingOffset_InitializationString = "//////////8VYIkKAgAAAAAADgAAAFNhbXBsaW5nT2Zmc2V0AQB1UgAuAER1UgAAAQAiAf////8BAf////8AAAAA";
  private const string InitializationString = "//////////8EYIACAQAAAAAAIgAAAFVhZHBXcml0ZXJHcm91cE1lc3NhZ2VUeXBlSW5zdGFuY2UBAHFSAQBxUnFSAAD/////BQAAABVgiQoCAAAAAAAMAAAAR3JvdXBWZXJzaW9uAQByUgAuAERyUgAAAQAGUv////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABEYXRhU2V0T3JkZXJpbmcBAHNSAC4ARHNSAAABALhP/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAE5ldHdvcmtNZXNzYWdlQ29udGVudE1hc2sBAHRSAC4ARHRSAAABABo9/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFNhbXBsaW5nT2Zmc2V0AQB1UgAuAER1UgAAAQAiAf////8BAf////8AAAAAF2CJCgIAAAAAABAAAABQdWJsaXNoaW5nT2Zmc2V0AQB2UgAuAER2UgAAAQAiAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private PropertyState<uint> m_groupVersion;
  private PropertyState<DataSetOrderingType> m_dataSetOrdering;
  private PropertyState<uint> m_networkMessageContentMask;
  private PropertyState<double> m_samplingOffset;
  private PropertyState<double[]> m_publishingOffset;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 21105U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAIgAAAFVhZHBXcml0ZXJHcm91cE1lc3NhZ2VUeXBlSW5zdGFuY2UBAHFSAQBxUnFSAAD/////BQAAABVgiQoCAAAAAAAMAAAAR3JvdXBWZXJzaW9uAQByUgAuAERyUgAAAQAGUv////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABEYXRhU2V0T3JkZXJpbmcBAHNSAC4ARHNSAAABALhP/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAE5ldHdvcmtNZXNzYWdlQ29udGVudE1hc2sBAHRSAC4ARHRSAAABABo9/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFNhbXBsaW5nT2Zmc2V0AQB1UgAuAER1UgAAAQAiAf////8BAf////8AAAAAF2CJCgIAAAAAABAAAABQdWJsaXNoaW5nT2Zmc2V0AQB2UgAuAER2UgAAAQAiAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
    if (this.SamplingOffset == null)
      return;
    this.SamplingOffset.Initialize(context, "//////////8VYIkKAgAAAAAADgAAAFNhbXBsaW5nT2Zmc2V0AQB1UgAuAER1UgAAAQAiAf////8BAf////8AAAAA");
  }

  public PropertyState<uint> GroupVersion
  {
    get => this.m_groupVersion;
    set
    {
      if (this.m_groupVersion != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_groupVersion = value;
    }
  }

  public PropertyState<DataSetOrderingType> DataSetOrdering
  {
    get => this.m_dataSetOrdering;
    set
    {
      if (this.m_dataSetOrdering != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_dataSetOrdering = value;
    }
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

  public PropertyState<double> SamplingOffset
  {
    get => this.m_samplingOffset;
    set
    {
      if (this.m_samplingOffset != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_samplingOffset = value;
    }
  }

  public PropertyState<double[]> PublishingOffset
  {
    get => this.m_publishingOffset;
    set
    {
      if (this.m_publishingOffset != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_publishingOffset = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_groupVersion != null)
      children.Add((BaseInstanceState) this.m_groupVersion);
    if (this.m_dataSetOrdering != null)
      children.Add((BaseInstanceState) this.m_dataSetOrdering);
    if (this.m_networkMessageContentMask != null)
      children.Add((BaseInstanceState) this.m_networkMessageContentMask);
    if (this.m_samplingOffset != null)
      children.Add((BaseInstanceState) this.m_samplingOffset);
    if (this.m_publishingOffset != null)
      children.Add((BaseInstanceState) this.m_publishingOffset);
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
      case "GroupVersion":
        if (createOrReplace && this.GroupVersion == null)
          this.GroupVersion = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.GroupVersion;
        break;
      case "DataSetOrdering":
        if (createOrReplace && this.DataSetOrdering == null)
          this.DataSetOrdering = replacement != null ? (PropertyState<DataSetOrderingType>) replacement : new PropertyState<DataSetOrderingType>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.DataSetOrdering;
        break;
      case "NetworkMessageContentMask":
        if (createOrReplace && this.NetworkMessageContentMask == null)
          this.NetworkMessageContentMask = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.NetworkMessageContentMask;
        break;
      case "SamplingOffset":
        if (createOrReplace && this.SamplingOffset == null)
          this.SamplingOffset = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.SamplingOffset;
        break;
      case "PublishingOffset":
        if (createOrReplace && this.PublishingOffset == null)
          this.PublishingOffset = replacement != null ? (PropertyState<double[]>) replacement : new PropertyState<double[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.PublishingOffset;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
