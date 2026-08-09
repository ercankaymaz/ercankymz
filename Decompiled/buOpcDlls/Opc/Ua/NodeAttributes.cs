using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class NodeAttributes : IEncodeable, ICloneable, IJsonEncodeable
{
	private uint m_specifiedAttributes;

	private LocalizedText m_displayName;

	private LocalizedText m_description;

	private uint m_writeMask;

	private uint m_userWriteMask;

	[DataMember(Name = "SpecifiedAttributes", IsRequired = false, Order = 1)]
	public uint SpecifiedAttributes
	{
		get
		{
			return m_specifiedAttributes;
		}
		set
		{
			m_specifiedAttributes = value;
		}
	}

	[DataMember(Name = "DisplayName", IsRequired = false, Order = 2)]
	public LocalizedText DisplayName
	{
		get
		{
			return m_displayName;
		}
		set
		{
			m_displayName = value;
		}
	}

	[DataMember(Name = "Description", IsRequired = false, Order = 3)]
	public LocalizedText Description
	{
		get
		{
			return m_description;
		}
		set
		{
			m_description = value;
		}
	}

	[DataMember(Name = "WriteMask", IsRequired = false, Order = 4)]
	public uint WriteMask
	{
		get
		{
			return m_writeMask;
		}
		set
		{
			m_writeMask = value;
		}
	}

	[DataMember(Name = "UserWriteMask", IsRequired = false, Order = 5)]
	public uint UserWriteMask
	{
		get
		{
			return m_userWriteMask;
		}
		set
		{
			m_userWriteMask = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.NodeAttributes;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.NodeAttributes_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.NodeAttributes_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.NodeAttributes_Encoding_DefaultJson;

	public NodeAttributes()
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
		m_specifiedAttributes = 0u;
		m_displayName = null;
		m_description = null;
		m_writeMask = 0u;
		m_userWriteMask = 0u;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteUInt32("SpecifiedAttributes", SpecifiedAttributes);
		encoder.WriteLocalizedText("DisplayName", DisplayName);
		encoder.WriteLocalizedText("Description", Description);
		encoder.WriteUInt32("WriteMask", WriteMask);
		encoder.WriteUInt32("UserWriteMask", UserWriteMask);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		SpecifiedAttributes = decoder.ReadUInt32("SpecifiedAttributes");
		DisplayName = decoder.ReadLocalizedText("DisplayName");
		Description = decoder.ReadLocalizedText("Description");
		WriteMask = decoder.ReadUInt32("WriteMask");
		UserWriteMask = decoder.ReadUInt32("UserWriteMask");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is NodeAttributes nodeAttributes))
		{
			return false;
		}
		if (!Utils.IsEqual(m_specifiedAttributes, nodeAttributes.m_specifiedAttributes))
		{
			return false;
		}
		if (!Utils.IsEqual(m_displayName, nodeAttributes.m_displayName))
		{
			return false;
		}
		if (!Utils.IsEqual(m_description, nodeAttributes.m_description))
		{
			return false;
		}
		if (!Utils.IsEqual(m_writeMask, nodeAttributes.m_writeMask))
		{
			return false;
		}
		if (!Utils.IsEqual(m_userWriteMask, nodeAttributes.m_userWriteMask))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (NodeAttributes)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		NodeAttributes obj = (NodeAttributes)base.MemberwiseClone();
		obj.m_specifiedAttributes = (uint)Utils.Clone(m_specifiedAttributes);
		obj.m_displayName = (LocalizedText)Utils.Clone(m_displayName);
		obj.m_description = (LocalizedText)Utils.Clone(m_description);
		obj.m_writeMask = (uint)Utils.Clone(m_writeMask);
		obj.m_userWriteMask = (uint)Utils.Clone(m_userWriteMask);
		return obj;
	}
}
