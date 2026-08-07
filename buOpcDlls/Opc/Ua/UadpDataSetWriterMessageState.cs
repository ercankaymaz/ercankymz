// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UadpDataSetWriterMessageState
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
public class UadpDataSetWriterMessageState(NodeState parent) : DataSetWriterMessageState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAJAAAAFVhZHBEYXRhU2V0V3JpdGVyTWVzc2FnZVR5cGVJbnN0YW5jZQEAd1IBAHdSd1IAAP////8EAAAAFWCJCgIAAAAAABkAAABEYXRhU2V0TWVzc2FnZUNvbnRlbnRNYXNrAQB4UgAuAER4UgAAAQAePf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABDb25maWd1cmVkU2l6ZQEAeVIALgBEeVIAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAAFAAAAE5ldHdvcmtNZXNzYWdlTnVtYmVyAQB6UgAuAER6UgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAANAAAARGF0YVNldE9mZnNldAEAe1IALgBEe1IAAAAF/////wEB/////wAAAAA=";
  private PropertyState<uint> m_dataSetMessageContentMask;
  private PropertyState<ushort> m_configuredSize;
  private PropertyState<ushort> m_networkMessageNumber;
  private PropertyState<ushort> m_dataSetOffset;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 21111U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAJAAAAFVhZHBEYXRhU2V0V3JpdGVyTWVzc2FnZVR5cGVJbnN0YW5jZQEAd1IBAHdSd1IAAP////8EAAAAFWCJCgIAAAAAABkAAABEYXRhU2V0TWVzc2FnZUNvbnRlbnRNYXNrAQB4UgAuAER4UgAAAQAePf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABDb25maWd1cmVkU2l6ZQEAeVIALgBEeVIAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAAFAAAAE5ldHdvcmtNZXNzYWdlTnVtYmVyAQB6UgAuAER6UgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAANAAAARGF0YVNldE9mZnNldAEAe1IALgBEe1IAAAAF/////wEB/////wAAAAA=");
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

  public PropertyState<uint> DataSetMessageContentMask
  {
    get => this.m_dataSetMessageContentMask;
    set
    {
      if (this.m_dataSetMessageContentMask != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_dataSetMessageContentMask = value;
    }
  }

  public PropertyState<ushort> ConfiguredSize
  {
    get => this.m_configuredSize;
    set
    {
      if (this.m_configuredSize != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_configuredSize = value;
    }
  }

  public PropertyState<ushort> NetworkMessageNumber
  {
    get => this.m_networkMessageNumber;
    set
    {
      if (this.m_networkMessageNumber != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_networkMessageNumber = value;
    }
  }

  public PropertyState<ushort> DataSetOffset
  {
    get => this.m_dataSetOffset;
    set
    {
      if (this.m_dataSetOffset != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_dataSetOffset = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_dataSetMessageContentMask != null)
      children.Add((BaseInstanceState) this.m_dataSetMessageContentMask);
    if (this.m_configuredSize != null)
      children.Add((BaseInstanceState) this.m_configuredSize);
    if (this.m_networkMessageNumber != null)
      children.Add((BaseInstanceState) this.m_networkMessageNumber);
    if (this.m_dataSetOffset != null)
      children.Add((BaseInstanceState) this.m_dataSetOffset);
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
      case "DataSetMessageContentMask":
        if (createOrReplace && this.DataSetMessageContentMask == null)
          this.DataSetMessageContentMask = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.DataSetMessageContentMask;
        break;
      case "ConfiguredSize":
        if (createOrReplace && this.ConfiguredSize == null)
          this.ConfiguredSize = replacement != null ? (PropertyState<ushort>) replacement : new PropertyState<ushort>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ConfiguredSize;
        break;
      case "NetworkMessageNumber":
        if (createOrReplace && this.NetworkMessageNumber == null)
          this.NetworkMessageNumber = replacement != null ? (PropertyState<ushort>) replacement : new PropertyState<ushort>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.NetworkMessageNumber;
        break;
      case "DataSetOffset":
        if (createOrReplace && this.DataSetOffset == null)
          this.DataSetOffset = replacement != null ? (PropertyState<ushort>) replacement : new PropertyState<ushort>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.DataSetOffset;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
