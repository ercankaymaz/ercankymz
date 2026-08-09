using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class HistoryData : IEncodeable, ICloneable, IJsonEncodeable
{
	private DataValueCollection m_dataValues;

	[DataMember(Name = "DataValues", IsRequired = false, Order = 1)]
	public DataValueCollection DataValues
	{
		get
		{
			return m_dataValues;
		}
		set
		{
			m_dataValues = value;
			if (value == null)
			{
				m_dataValues = new DataValueCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.HistoryData;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.HistoryData_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.HistoryData_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.HistoryData_Encoding_DefaultJson;

	public HistoryData()
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
		m_dataValues = new DataValueCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteDataValueArray("DataValues", DataValues);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		DataValues = decoder.ReadDataValueArray("DataValues");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is HistoryData historyData))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataValues, historyData.m_dataValues))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (HistoryData)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		HistoryData obj = (HistoryData)base.MemberwiseClone();
		obj.m_dataValues = (DataValueCollection)Utils.Clone(m_dataValues);
		return obj;
	}
}
