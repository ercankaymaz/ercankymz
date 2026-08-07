// Decompiled with JetBrains decompiler
// Type: Opc.Ua.QueryDataDescription
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
public class QueryDataDescription : IEncodeable, ICloneable, IJsonEncodeable
{
  private RelativePath m_relativePath;
  private uint m_attributeId;
  private string m_indexRange;

  public QueryDataDescription() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_relativePath = new RelativePath();
    this.m_attributeId = 0U;
    this.m_indexRange = (string) null;
  }

  [DataMember(Name = "RelativePath", IsRequired = false, Order = 1)]
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

  [DataMember(Name = "AttributeId", IsRequired = false, Order = 2)]
  public uint AttributeId
  {
    get => this.m_attributeId;
    set => this.m_attributeId = value;
  }

  [DataMember(Name = "IndexRange", IsRequired = false, Order = 3)]
  public string IndexRange
  {
    get => this.m_indexRange;
    set => this.m_indexRange = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.QueryDataDescription;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.QueryDataDescription_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.QueryDataDescription_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.QueryDataDescription_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RelativePath", (IEncodeable) this.RelativePath, typeof (RelativePath));
    encoder.WriteUInt32("AttributeId", this.AttributeId);
    encoder.WriteString("IndexRange", this.IndexRange);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RelativePath = (RelativePath) decoder.ReadEncodeable("RelativePath", typeof (RelativePath));
    this.AttributeId = decoder.ReadUInt32("AttributeId");
    this.IndexRange = decoder.ReadString("IndexRange");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is QueryDataDescription queryDataDescription && Utils.IsEqual((object) this.m_relativePath, (object) queryDataDescription.m_relativePath) && Utils.IsEqual((object) this.m_attributeId, (object) queryDataDescription.m_attributeId) && Utils.IsEqual((object) this.m_indexRange, (object) queryDataDescription.m_indexRange);
  }

  public virtual object Clone() => (object) (QueryDataDescription) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    QueryDataDescription queryDataDescription = (QueryDataDescription) base.MemberwiseClone();
    queryDataDescription.m_relativePath = (RelativePath) Utils.Clone((object) this.m_relativePath);
    queryDataDescription.m_attributeId = (uint) Utils.Clone((object) this.m_attributeId);
    queryDataDescription.m_indexRange = (string) Utils.Clone((object) this.m_indexRange);
    return (object) queryDataDescription;
  }

  public NumericRange ParsedIndexRange { get; set; }
}
