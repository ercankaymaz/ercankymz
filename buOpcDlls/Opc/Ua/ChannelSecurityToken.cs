// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ChannelSecurityToken
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
public class ChannelSecurityToken : IEncodeable, ICloneable, IJsonEncodeable
{
  private uint m_channelId;
  private uint m_tokenId;
  private DateTime m_createdAt;
  private uint m_revisedLifetime;

  public ChannelSecurityToken() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_channelId = 0U;
    this.m_tokenId = 0U;
    this.m_createdAt = DateTime.MinValue;
    this.m_revisedLifetime = 0U;
  }

  [DataMember(Name = "ChannelId", IsRequired = false, Order = 1)]
  public uint ChannelId
  {
    get => this.m_channelId;
    set => this.m_channelId = value;
  }

  [DataMember(Name = "TokenId", IsRequired = false, Order = 2)]
  public uint TokenId
  {
    get => this.m_tokenId;
    set => this.m_tokenId = value;
  }

  [DataMember(Name = "CreatedAt", IsRequired = false, Order = 3)]
  public DateTime CreatedAt
  {
    get => this.m_createdAt;
    set => this.m_createdAt = value;
  }

  [DataMember(Name = "RevisedLifetime", IsRequired = false, Order = 4)]
  public uint RevisedLifetime
  {
    get => this.m_revisedLifetime;
    set => this.m_revisedLifetime = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ChannelSecurityToken;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ChannelSecurityToken_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ChannelSecurityToken_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ChannelSecurityToken_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteUInt32("ChannelId", this.ChannelId);
    encoder.WriteUInt32("TokenId", this.TokenId);
    encoder.WriteDateTime("CreatedAt", this.CreatedAt);
    encoder.WriteUInt32("RevisedLifetime", this.RevisedLifetime);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ChannelId = decoder.ReadUInt32("ChannelId");
    this.TokenId = decoder.ReadUInt32("TokenId");
    this.CreatedAt = decoder.ReadDateTime("CreatedAt");
    this.RevisedLifetime = decoder.ReadUInt32("RevisedLifetime");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is ChannelSecurityToken channelSecurityToken && Utils.IsEqual((object) this.m_channelId, (object) channelSecurityToken.m_channelId) && Utils.IsEqual((object) this.m_tokenId, (object) channelSecurityToken.m_tokenId) && Utils.IsEqual(this.m_createdAt, channelSecurityToken.m_createdAt) && Utils.IsEqual((object) this.m_revisedLifetime, (object) channelSecurityToken.m_revisedLifetime);
  }

  public virtual object Clone() => (object) (ChannelSecurityToken) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ChannelSecurityToken channelSecurityToken = (ChannelSecurityToken) base.MemberwiseClone();
    channelSecurityToken.m_channelId = (uint) Utils.Clone((object) this.m_channelId);
    channelSecurityToken.m_tokenId = (uint) Utils.Clone((object) this.m_tokenId);
    channelSecurityToken.m_createdAt = (DateTime) Utils.Clone((object) this.m_createdAt);
    channelSecurityToken.m_revisedLifetime = (uint) Utils.Clone((object) this.m_revisedLifetime);
    return (object) channelSecurityToken;
  }
}
