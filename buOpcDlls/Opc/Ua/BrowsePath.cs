// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BrowsePath
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
public class BrowsePath : IEncodeable, ICloneable, IJsonEncodeable
{
  private NodeId m_startingNode;
  private RelativePath m_relativePath;
  private object m_handle;

  public BrowsePath() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_startingNode = (NodeId) null;
    this.m_relativePath = new RelativePath();
  }

  [DataMember(Name = "StartingNode", IsRequired = false, Order = 1)]
  public NodeId StartingNode
  {
    get => this.m_startingNode;
    set => this.m_startingNode = value;
  }

  [DataMember(Name = "RelativePath", IsRequired = false, Order = 2)]
  public RelativePath RelativePath
  {
    get => this.m_relativePath;
    set
    {
      this.m_relativePath = value;
      if (value != null)
        return;
      this.m_relativePath = new RelativePath();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.BrowsePath;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrowsePath_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrowsePath_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrowsePath_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("StartingNode", this.StartingNode);
    encoder.WriteEncodeable("RelativePath", (IEncodeable) this.RelativePath, typeof (RelativePath));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.StartingNode = decoder.ReadNodeId("StartingNode");
    this.RelativePath = (RelativePath) decoder.ReadEncodeable("RelativePath", typeof (RelativePath));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is BrowsePath browsePath && Utils.IsEqual((object) this.m_startingNode, (object) browsePath.m_startingNode) && Utils.IsEqual((object) this.m_relativePath, (object) browsePath.m_relativePath);
  }

  public virtual object Clone() => (object) (BrowsePath) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    BrowsePath browsePath = (BrowsePath) base.MemberwiseClone();
    browsePath.m_startingNode = (NodeId) Utils.Clone((object) this.m_startingNode);
    browsePath.m_relativePath = (RelativePath) Utils.Clone((object) this.m_relativePath);
    return (object) browsePath;
  }

  public object Handle
  {
    get => this.m_handle;
    set => this.m_handle = value;
  }
}
