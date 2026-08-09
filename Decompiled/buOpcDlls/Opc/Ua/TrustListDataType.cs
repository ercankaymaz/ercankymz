using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

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

	[DataMember(Name = "SpecifiedLists", IsRequired = false, Order = 1)]
	public uint SpecifiedLists
	{
		get
		{
			return m_specifiedLists;
		}
		set
		{
			m_specifiedLists = value;
		}
	}

	[DataMember(Name = "TrustedCertificates", IsRequired = false, Order = 2)]
	public ByteStringCollection TrustedCertificates
	{
		get
		{
			return m_trustedCertificates;
		}
		set
		{
			m_trustedCertificates = value;
			if (value == null)
			{
				m_trustedCertificates = new ByteStringCollection();
			}
		}
	}

	[DataMember(Name = "TrustedCrls", IsRequired = false, Order = 3)]
	public ByteStringCollection TrustedCrls
	{
		get
		{
			return m_trustedCrls;
		}
		set
		{
			m_trustedCrls = value;
			if (value == null)
			{
				m_trustedCrls = new ByteStringCollection();
			}
		}
	}

	[DataMember(Name = "IssuerCertificates", IsRequired = false, Order = 4)]
	public ByteStringCollection IssuerCertificates
	{
		get
		{
			return m_issuerCertificates;
		}
		set
		{
			m_issuerCertificates = value;
			if (value == null)
			{
				m_issuerCertificates = new ByteStringCollection();
			}
		}
	}

	[DataMember(Name = "IssuerCrls", IsRequired = false, Order = 5)]
	public ByteStringCollection IssuerCrls
	{
		get
		{
			return m_issuerCrls;
		}
		set
		{
			m_issuerCrls = value;
			if (value == null)
			{
				m_issuerCrls = new ByteStringCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.TrustListDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.TrustListDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.TrustListDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.TrustListDataType_Encoding_DefaultJson;

	public TrustListDataType()
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
		m_specifiedLists = 0u;
		m_trustedCertificates = new ByteStringCollection();
		m_trustedCrls = new ByteStringCollection();
		m_issuerCertificates = new ByteStringCollection();
		m_issuerCrls = new ByteStringCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteUInt32("SpecifiedLists", SpecifiedLists);
		encoder.WriteByteStringArray("TrustedCertificates", TrustedCertificates);
		encoder.WriteByteStringArray("TrustedCrls", TrustedCrls);
		encoder.WriteByteStringArray("IssuerCertificates", IssuerCertificates);
		encoder.WriteByteStringArray("IssuerCrls", IssuerCrls);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		SpecifiedLists = decoder.ReadUInt32("SpecifiedLists");
		TrustedCertificates = decoder.ReadByteStringArray("TrustedCertificates");
		TrustedCrls = decoder.ReadByteStringArray("TrustedCrls");
		IssuerCertificates = decoder.ReadByteStringArray("IssuerCertificates");
		IssuerCrls = decoder.ReadByteStringArray("IssuerCrls");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is TrustListDataType trustListDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_specifiedLists, trustListDataType.m_specifiedLists))
		{
			return false;
		}
		if (!Utils.IsEqual(m_trustedCertificates, trustListDataType.m_trustedCertificates))
		{
			return false;
		}
		if (!Utils.IsEqual(m_trustedCrls, trustListDataType.m_trustedCrls))
		{
			return false;
		}
		if (!Utils.IsEqual(m_issuerCertificates, trustListDataType.m_issuerCertificates))
		{
			return false;
		}
		if (!Utils.IsEqual(m_issuerCrls, trustListDataType.m_issuerCrls))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (TrustListDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		TrustListDataType obj = (TrustListDataType)base.MemberwiseClone();
		obj.m_specifiedLists = (uint)Utils.Clone(m_specifiedLists);
		obj.m_trustedCertificates = (ByteStringCollection)Utils.Clone(m_trustedCertificates);
		obj.m_trustedCrls = (ByteStringCollection)Utils.Clone(m_trustedCrls);
		obj.m_issuerCertificates = (ByteStringCollection)Utils.Clone(m_issuerCertificates);
		obj.m_issuerCrls = (ByteStringCollection)Utils.Clone(m_issuerCrls);
		return obj;
	}
}
