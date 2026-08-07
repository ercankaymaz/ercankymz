// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataTypeDescription
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
public class DataTypeDescription : IEncodeable, ICloneable, IJsonEncodeable
{
  private NodeId m_dataTypeId;
  private QualifiedName m_name;

  public DataTypeDescription() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_dataTypeId = (NodeId) null;
    this.m_name = (QualifiedName) null;
  }

  [DataMember(Name = "DataTypeId", IsRequired = false, Order = 1)]
  public NodeId DataTypeId
  {
    get => this.m_dataTypeId;
    set => this.m_dataTypeId = value;
  }

  [DataMember(Name = "Name", IsRequired = false, Order = 2)]
  public QualifiedName Name
  {
    get => this.m_name;
    set => this.m_name = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.DataTypeDescription;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DataTypeDescription_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DataTypeDescription_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DataTypeDescription_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("DataTypeId", this.DataTypeId);
    encoder.WriteQualifiedName("Name", this.Name);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.DataTypeId = decoder.ReadNodeId("DataTypeId");
    this.Name = decoder.ReadQualifiedName("Name");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is DataTypeDescription dataTypeDescription && Utils.IsEqual((object) this.m_dataTypeId, (object) dataTypeDescription.m_dataTypeId) && Utils.IsEqual((object) this.m_name, (object) dataTypeDescription.m_name);
  }

  public virtual object Clone() => (object) (DataTypeDescription) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DataTypeDescription dataTypeDescription = (DataTypeDescription) base.MemberwiseClone();
    dataTypeDescription.m_dataTypeId = (NodeId) Utils.Clone((object) this.m_dataTypeId);
    dataTypeDescription.m_name = (QualifiedName) Utils.Clone((object) this.m_name);
    return (object) dataTypeDescription;
  }
}
