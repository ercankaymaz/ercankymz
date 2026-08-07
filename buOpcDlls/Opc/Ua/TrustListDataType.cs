// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TrustListDataType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class TrustListDataType : IEncodeable, ICloneable, IJsonEncodeable
{
  private uint m_specifiedLists;
  private ByteStringCollection m_trustedCertificates;
  private ByteStringCollection m_trustedCrls;
  private ByteStringCollection m_issuerCertificates;
  private ByteStringCollection m_issuerCrls;

  public TrustListDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_specifiedLists = 0U;
    this.m_trustedCertificates = new ByteStringCollection();
    this.m_trustedCrls = new ByteStringCollection();
    this.m_issuerCertificates = new ByteStringCollection();
    this.m_issuerCrls = new ByteStringCollection();
  }

  [DataMember(Name = "SpecifiedLists", IsRequired = false, Order = 1)]
  public uint SpecifiedLists
  {
    get => this.m_specifiedLists;
    set => this.m_specifiedLists = value;
  }

  [DataMember(Name = "TrustedCertificates", IsRequired = false, Order = 2)]
  public ByteStringCollection TrustedCertificates
  {
    get => this.m_trustedCertificates;
    set
    {
      this.m_trustedCertificates = value;
      if (value != null)
        return;
      this.m_trustedCertificates = new ByteStringCollection();
    }
  }

  [DataMember(Name = "TrustedCrls", IsRequired = false, Order = 3)]
  public ByteStringCollection TrustedCrls
  {
    get => this.m_trustedCrls;
    set
    {
      this.m_trustedCrls = value;
      if (value != null)
        return;
      this.m_trustedCrls = new ByteStringCollection();
    }
  }

  [DataMember(Name = "IssuerCertificates", IsRequired = false, Order = 4)]
  public ByteStringCollection IssuerCertificates
  {
    get => this.m_issuerCertificates;
    set
    {
      this.m_issuerCertificates = value;
      if (value != null)
        return;
      this.m_issuerCertificates = new ByteStringCollection();
    }
  }

  [DataMember(Name = "IssuerCrls", IsRequired = false, Order = 5)]
  public ByteStringCollection IssuerCrls
  {
    get => this.m_issuerCrls;
    set
    {
      this.m_issuerCrls = value;
      if (value != null)
        return;
      this.m_issuerCrls = new ByteStringCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.TrustListDataType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.TrustListDataType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.TrustListDataType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.TrustListDataType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteUInt32("SpecifiedLists", this.SpecifiedLists);
    encoder.WriteByteStringArray("TrustedCertificates", (IList<byte[]>) this.TrustedCertificates);
    encoder.WriteByteStringArray("TrustedCrls", (IList<byte[]>) this.TrustedCrls);
    encoder.WriteByteStringArray("IssuerCertificates", (IList<byte[]>) this.IssuerCertificates);
    encoder.WriteByteStringArray("IssuerCrls", (IList<byte[]>) this.IssuerCrls);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.SpecifiedLists = decoder.ReadUInt32("SpecifiedLists");
    this.TrustedCertificates = decoder.ReadByteStringArray("TrustedCertificates");
    this.TrustedCrls = decoder.ReadByteStringArray("TrustedCrls");
    this.IssuerCertificates = decoder.ReadByteStringArray("IssuerCertificates");
    this.IssuerCrls = decoder.ReadByteStringArray("IssuerCrls");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is TrustListDataType trustListDataType && Utils.IsEqual((object) this.m_specifiedLists, (object) trustListDataType.m_specifiedLists) && Utils.IsEqual((object) this.m_trustedCertificates, (object) trustListDataType.m_trustedCertificates) && Utils.IsEqual((object) this.m_trustedCrls, (object) trustListDataType.m_trustedCrls) && Utils.IsEqual((object) this.m_issuerCertificates, (object) trustListDataType.m_issuerCertificates) && Utils.IsEqual((object) this.m_issuerCrls, (object) trustListDataType.m_issuerCrls);
  }

  public virtual object Clone() => (object) (TrustListDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    TrustListDataType trustListDataType = (TrustListDataType) base.MemberwiseClone();
    trustListDataType.m_specifiedLists = (uint) Utils.Clone((object) this.m_specifiedLists);
    trustListDataType.m_trustedCertificates = (ByteStringCollection) Utils.Clone((object) this.m_trustedCertificates);
    trustListDataType.m_trustedCrls = (ByteStringCollection) Utils.Clone((object) this.m_trustedCrls);
    trustListDataType.m_issuerCertificates = (ByteStringCollection) Utils.Clone((object) this.m_issuerCertificates);
    trustListDataType.m_issuerCrls = (ByteStringCollection) Utils.Clone((object) this.m_issuerCrls);
    return (object) trustListDataType;
  }
}
