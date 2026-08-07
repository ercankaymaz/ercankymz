// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ViewDescription
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ViewDescription : IEncodeable, ICloneable, IJsonEncodeable
{
  private NodeId m_viewId;
  private DateTime m_timestamp;
  private uint m_viewVersion;
  private object m_handle;

  public ViewDescription() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_viewId = (NodeId) null;
    this.m_timestamp = DateTime.MinValue;
    this.m_viewVersion = 0U;
  }

  [DataMember(Name = "ViewId", IsRequired = false, Order = 1)]
  public NodeId ViewId
  {
    get => this.m_viewId;
    set => this.m_viewId = value;
  }

  [DataMember(Name = "Timestamp", IsRequired = false, Order = 2)]
  public DateTime Timestamp
  {
    get => this.m_timestamp;
    set => this.m_timestamp = value;
  }

  [DataMember(Name = "ViewVersion", IsRequired = false, Order = 3)]
  public uint ViewVersion
  {
    get => this.m_viewVersion;
    set => this.m_viewVersion = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ViewDescription;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ViewDescription_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ViewDescription_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ViewDescription_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("ViewId", this.ViewId);
    encoder.WriteDateTime("Timestamp", this.Timestamp);
    encoder.WriteUInt32("ViewVersion", this.ViewVersion);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ViewId = decoder.ReadNodeId("ViewId");
    this.Timestamp = decoder.ReadDateTime("Timestamp");
    this.ViewVersion = decoder.ReadUInt32("ViewVersion");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is ViewDescription viewDescription && Utils.IsEqual((object) this.m_viewId, (object) viewDescription.m_viewId) && Utils.IsEqual(this.m_timestamp, viewDescription.m_timestamp) && Utils.IsEqual((object) this.m_viewVersion, (object) viewDescription.m_viewVersion);
  }

  public virtual object Clone() => (object) (ViewDescription) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ViewDescription viewDescription = (ViewDescription) base.MemberwiseClone();
    viewDescription.m_viewId = (NodeId) Utils.Clone((object) this.m_viewId);
    viewDescription.m_timestamp = (DateTime) Utils.Clone((object) this.m_timestamp);
    viewDescription.m_viewVersion = (uint) Utils.Clone((object) this.m_viewVersion);
    return (object) viewDescription;
  }

  public object Handle
  {
    get => this.m_handle;
    set => this.m_handle = value;
  }

  public static bool IsDefault(ViewDescription view)
  {
    return view == null || NodeId.IsNull(view.m_viewId) && view.m_viewVersion == 0U && view.m_timestamp == DateTime.MinValue;
  }
}
