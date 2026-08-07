// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ModelChangeStructureDataType
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
public class ModelChangeStructureDataType : IEncodeable, ICloneable, IJsonEncodeable
{
  private NodeId m_affected;
  private NodeId m_affectedType;
  private byte m_verb;

  public ModelChangeStructureDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_affected = (NodeId) null;
    this.m_affectedType = (NodeId) null;
    this.m_verb = (byte) 0;
  }

  [DataMember(Name = "Affected", IsRequired = false, Order = 1)]
  public NodeId Affected
  {
    get => this.m_affected;
    set => this.m_affected = value;
  }

  [DataMember(Name = "AffectedType", IsRequired = false, Order = 2)]
  public NodeId AffectedType
  {
    get => this.m_affectedType;
    set => this.m_affectedType = value;
  }

  [DataMember(Name = "Verb", IsRequired = false, Order = 3)]
  public byte Verb
  {
    get => this.m_verb;
    set => this.m_verb = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ModelChangeStructureDataType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ModelChangeStructureDataType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ModelChangeStructureDataType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ModelChangeStructureDataType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("Affected", this.Affected);
    encoder.WriteNodeId("AffectedType", this.AffectedType);
    encoder.WriteByte("Verb", this.Verb);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Affected = decoder.ReadNodeId("Affected");
    this.AffectedType = decoder.ReadNodeId("AffectedType");
    this.Verb = decoder.ReadByte("Verb");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is ModelChangeStructureDataType structureDataType && Utils.IsEqual((object) this.m_affected, (object) structureDataType.m_affected) && Utils.IsEqual((object) this.m_affectedType, (object) structureDataType.m_affectedType) && Utils.IsEqual((object) this.m_verb, (object) structureDataType.m_verb);
  }

  public virtual object Clone() => (object) (ModelChangeStructureDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ModelChangeStructureDataType structureDataType = (ModelChangeStructureDataType) base.MemberwiseClone();
    structureDataType.m_affected = (NodeId) Utils.Clone((object) this.m_affected);
    structureDataType.m_affectedType = (NodeId) Utils.Clone((object) this.m_affectedType);
    structureDataType.m_verb = (byte) Utils.Clone((object) this.m_verb);
    return (object) structureDataType;
  }
}
