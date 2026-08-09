using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

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

	[DataMember(Name = "ChannelId", IsRequired = false, Order = 1)]
	public uint ChannelId
	{
		get
		{
			return m_channelId;
		}
		set
		{
			m_channelId = value;
		}
	}

	[DataMember(Name = "TokenId", IsRequired = false, Order = 2)]
	public uint TokenId
	{
		get
		{
			return m_tokenId;
		}
		set
		{
			m_tokenId = value;
		}
	}

	[DataMember(Name = "CreatedAt", IsRequired = false, Order = 3)]
	public DateTime CreatedAt
	{
		get
		{
			return m_createdAt;
		}
		set
		{
			m_createdAt = value;
		}
	}

	[DataMember(Name = "RevisedLifetime", IsRequired = false, Order = 4)]
	public uint RevisedLifetime
	{
		get
		{
			return m_revisedLifetime;
		}
		set
		{
			m_revisedLifetime = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.ChannelSecurityToken;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ChannelSecurityToken_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ChannelSecurityToken_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ChannelSecurityToken_Encoding_DefaultJson;

	public ChannelSecurityToken()
	{
		Initialize();
	}

	[OnDeserializing]
	private void Initialize(StreamingContext context)
	{
		Initialize();
	}

	private void Initialize()
	{
		m_channelId = 0u;
		m_tokenId = 0u;
		m_createdAt = DateTime.MinValue;
		m_revisedLifetime = 0u;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteUInt32("ChannelId", ChannelId);
		encoder.WriteUInt32("TokenId", TokenId);
		encoder.WriteDateTime("CreatedAt", CreatedAt);
		encoder.WriteUInt32("RevisedLifetime", RevisedLifetime);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ChannelId = decoder.ReadUInt32("ChannelId");
		TokenId = decoder.ReadUInt32("TokenId");
		CreatedAt = decoder.ReadDateTime("CreatedAt");
		RevisedLifetime = decoder.ReadUInt32("RevisedLifetime");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ChannelSecurityToken channelSecurityToken))
		{
			return false;
		}
		if (!Utils.IsEqual(m_channelId, channelSecurityToken.m_channelId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_tokenId, channelSecurityToken.m_tokenId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_createdAt, channelSecurityToken.m_createdAt))
		{
			return false;
		}
		if (!Utils.IsEqual(m_revisedLifetime, channelSecurityToken.m_revisedLifetime))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (ChannelSecurityToken)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ChannelSecurityToken obj = (ChannelSecurityToken)base.MemberwiseClone();
		obj.m_channelId = (uint)Utils.Clone(m_channelId);
		obj.m_tokenId = (uint)Utils.Clone(m_tokenId);
		obj.m_createdAt = (DateTime)Utils.Clone(m_createdAt);
		obj.m_revisedLifetime = (uint)Utils.Clone(m_revisedLifetime);
		return obj;
	}
}
