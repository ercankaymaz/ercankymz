using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ModificationInfo : IEncodeable, ICloneable, IJsonEncodeable
{
	private DateTime m_modificationTime;

	private HistoryUpdateType m_updateType;

	private string m_userName;

	[DataMember(Name = "ModificationTime", IsRequired = false, Order = 1)]
	public DateTime ModificationTime
	{
		get
		{
			return m_modificationTime;
		}
		set
		{
			m_modificationTime = value;
		}
	}

	[DataMember(Name = "UpdateType", IsRequired = false, Order = 2)]
	public HistoryUpdateType UpdateType
	{
		get
		{
			return m_updateType;
		}
		set
		{
			m_updateType = value;
		}
	}

	[DataMember(Name = "UserName", IsRequired = false, Order = 3)]
	public string UserName
	{
		get
		{
			return m_userName;
		}
		set
		{
			m_userName = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.ModificationInfo;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ModificationInfo_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ModificationInfo_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ModificationInfo_Encoding_DefaultJson;

	public ModificationInfo()
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
		m_modificationTime = DateTime.MinValue;
		m_updateType = HistoryUpdateType.Insert;
		m_userName = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteDateTime("ModificationTime", ModificationTime);
		encoder.WriteEnumerated("UpdateType", UpdateType);
		encoder.WriteString("UserName", UserName);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ModificationTime = decoder.ReadDateTime("ModificationTime");
		UpdateType = (HistoryUpdateType)(object)decoder.ReadEnumerated("UpdateType", typeof(HistoryUpdateType));
		UserName = decoder.ReadString("UserName");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ModificationInfo modificationInfo))
		{
			return false;
		}
		if (!Utils.IsEqual(m_modificationTime, modificationInfo.m_modificationTime))
		{
			return false;
		}
		if (!Utils.IsEqual(m_updateType, modificationInfo.m_updateType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_userName, modificationInfo.m_userName))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (ModificationInfo)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ModificationInfo obj = (ModificationInfo)base.MemberwiseClone();
		obj.m_modificationTime = (DateTime)Utils.Clone(m_modificationTime);
		obj.m_updateType = (HistoryUpdateType)Utils.Clone(m_updateType);
		obj.m_userName = (string)Utils.Clone(m_userName);
		return obj;
	}
}
