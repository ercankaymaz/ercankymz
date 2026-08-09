using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ProgramDiagnostic2DataType : IEncodeable, ICloneable, IJsonEncodeable
{
	private NodeId m_createSessionId;

	private string m_createClientName;

	private DateTime m_invocationCreationTime;

	private DateTime m_lastTransitionTime;

	private string m_lastMethodCall;

	private NodeId m_lastMethodSessionId;

	private ArgumentCollection m_lastMethodInputArguments;

	private ArgumentCollection m_lastMethodOutputArguments;

	private VariantCollection m_lastMethodInputValues;

	private VariantCollection m_lastMethodOutputValues;

	private DateTime m_lastMethodCallTime;

	private StatusCode m_lastMethodReturnStatus;

	[DataMember(Name = "CreateSessionId", IsRequired = false, Order = 1)]
	public NodeId CreateSessionId
	{
		get
		{
			return m_createSessionId;
		}
		set
		{
			m_createSessionId = value;
		}
	}

	[DataMember(Name = "CreateClientName", IsRequired = false, Order = 2)]
	public string CreateClientName
	{
		get
		{
			return m_createClientName;
		}
		set
		{
			m_createClientName = value;
		}
	}

	[DataMember(Name = "InvocationCreationTime", IsRequired = false, Order = 3)]
	public DateTime InvocationCreationTime
	{
		get
		{
			return m_invocationCreationTime;
		}
		set
		{
			m_invocationCreationTime = value;
		}
	}

	[DataMember(Name = "LastTransitionTime", IsRequired = false, Order = 4)]
	public DateTime LastTransitionTime
	{
		get
		{
			return m_lastTransitionTime;
		}
		set
		{
			m_lastTransitionTime = value;
		}
	}

	[DataMember(Name = "LastMethodCall", IsRequired = false, Order = 5)]
	public string LastMethodCall
	{
		get
		{
			return m_lastMethodCall;
		}
		set
		{
			m_lastMethodCall = value;
		}
	}

	[DataMember(Name = "LastMethodSessionId", IsRequired = false, Order = 6)]
	public NodeId LastMethodSessionId
	{
		get
		{
			return m_lastMethodSessionId;
		}
		set
		{
			m_lastMethodSessionId = value;
		}
	}

	[DataMember(Name = "LastMethodInputArguments", IsRequired = false, Order = 7)]
	public ArgumentCollection LastMethodInputArguments
	{
		get
		{
			return m_lastMethodInputArguments;
		}
		set
		{
			m_lastMethodInputArguments = value;
			if (value == null)
			{
				m_lastMethodInputArguments = new ArgumentCollection();
			}
		}
	}

	[DataMember(Name = "LastMethodOutputArguments", IsRequired = false, Order = 8)]
	public ArgumentCollection LastMethodOutputArguments
	{
		get
		{
			return m_lastMethodOutputArguments;
		}
		set
		{
			m_lastMethodOutputArguments = value;
			if (value == null)
			{
				m_lastMethodOutputArguments = new ArgumentCollection();
			}
		}
	}

	[DataMember(Name = "LastMethodInputValues", IsRequired = false, Order = 9)]
	public VariantCollection LastMethodInputValues
	{
		get
		{
			return m_lastMethodInputValues;
		}
		set
		{
			m_lastMethodInputValues = value;
			if (value == null)
			{
				m_lastMethodInputValues = new VariantCollection();
			}
		}
	}

	[DataMember(Name = "LastMethodOutputValues", IsRequired = false, Order = 10)]
	public VariantCollection LastMethodOutputValues
	{
		get
		{
			return m_lastMethodOutputValues;
		}
		set
		{
			m_lastMethodOutputValues = value;
			if (value == null)
			{
				m_lastMethodOutputValues = new VariantCollection();
			}
		}
	}

	[DataMember(Name = "LastMethodCallTime", IsRequired = false, Order = 11)]
	public DateTime LastMethodCallTime
	{
		get
		{
			return m_lastMethodCallTime;
		}
		set
		{
			m_lastMethodCallTime = value;
		}
	}

	[DataMember(Name = "LastMethodReturnStatus", IsRequired = false, Order = 12)]
	public StatusCode LastMethodReturnStatus
	{
		get
		{
			return m_lastMethodReturnStatus;
		}
		set
		{
			m_lastMethodReturnStatus = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.ProgramDiagnostic2DataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ProgramDiagnostic2DataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ProgramDiagnostic2DataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ProgramDiagnostic2DataType_Encoding_DefaultJson;

	public ProgramDiagnostic2DataType()
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
		m_createSessionId = null;
		m_createClientName = null;
		m_invocationCreationTime = DateTime.MinValue;
		m_lastTransitionTime = DateTime.MinValue;
		m_lastMethodCall = null;
		m_lastMethodSessionId = null;
		m_lastMethodInputArguments = new ArgumentCollection();
		m_lastMethodOutputArguments = new ArgumentCollection();
		m_lastMethodInputValues = new VariantCollection();
		m_lastMethodOutputValues = new VariantCollection();
		m_lastMethodCallTime = DateTime.MinValue;
		m_lastMethodReturnStatus = 0u;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("CreateSessionId", CreateSessionId);
		encoder.WriteString("CreateClientName", CreateClientName);
		encoder.WriteDateTime("InvocationCreationTime", InvocationCreationTime);
		encoder.WriteDateTime("LastTransitionTime", LastTransitionTime);
		encoder.WriteString("LastMethodCall", LastMethodCall);
		encoder.WriteNodeId("LastMethodSessionId", LastMethodSessionId);
		encoder.WriteEncodeableArray("LastMethodInputArguments", LastMethodInputArguments.ToArray(), typeof(Argument));
		encoder.WriteEncodeableArray("LastMethodOutputArguments", LastMethodOutputArguments.ToArray(), typeof(Argument));
		encoder.WriteVariantArray("LastMethodInputValues", LastMethodInputValues);
		encoder.WriteVariantArray("LastMethodOutputValues", LastMethodOutputValues);
		encoder.WriteDateTime("LastMethodCallTime", LastMethodCallTime);
		encoder.WriteStatusCode("LastMethodReturnStatus", LastMethodReturnStatus);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		CreateSessionId = decoder.ReadNodeId("CreateSessionId");
		CreateClientName = decoder.ReadString("CreateClientName");
		InvocationCreationTime = decoder.ReadDateTime("InvocationCreationTime");
		LastTransitionTime = decoder.ReadDateTime("LastTransitionTime");
		LastMethodCall = decoder.ReadString("LastMethodCall");
		LastMethodSessionId = decoder.ReadNodeId("LastMethodSessionId");
		LastMethodInputArguments = (Argument[])decoder.ReadEncodeableArray("LastMethodInputArguments", typeof(Argument));
		LastMethodOutputArguments = (Argument[])decoder.ReadEncodeableArray("LastMethodOutputArguments", typeof(Argument));
		LastMethodInputValues = decoder.ReadVariantArray("LastMethodInputValues");
		LastMethodOutputValues = decoder.ReadVariantArray("LastMethodOutputValues");
		LastMethodCallTime = decoder.ReadDateTime("LastMethodCallTime");
		LastMethodReturnStatus = decoder.ReadStatusCode("LastMethodReturnStatus");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ProgramDiagnostic2DataType programDiagnostic2DataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_createSessionId, programDiagnostic2DataType.m_createSessionId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_createClientName, programDiagnostic2DataType.m_createClientName))
		{
			return false;
		}
		if (!Utils.IsEqual(m_invocationCreationTime, programDiagnostic2DataType.m_invocationCreationTime))
		{
			return false;
		}
		if (!Utils.IsEqual(m_lastTransitionTime, programDiagnostic2DataType.m_lastTransitionTime))
		{
			return false;
		}
		if (!Utils.IsEqual(m_lastMethodCall, programDiagnostic2DataType.m_lastMethodCall))
		{
			return false;
		}
		if (!Utils.IsEqual(m_lastMethodSessionId, programDiagnostic2DataType.m_lastMethodSessionId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_lastMethodInputArguments, programDiagnostic2DataType.m_lastMethodInputArguments))
		{
			return false;
		}
		if (!Utils.IsEqual(m_lastMethodOutputArguments, programDiagnostic2DataType.m_lastMethodOutputArguments))
		{
			return false;
		}
		if (!Utils.IsEqual(m_lastMethodInputValues, programDiagnostic2DataType.m_lastMethodInputValues))
		{
			return false;
		}
		if (!Utils.IsEqual(m_lastMethodOutputValues, programDiagnostic2DataType.m_lastMethodOutputValues))
		{
			return false;
		}
		if (!Utils.IsEqual(m_lastMethodCallTime, programDiagnostic2DataType.m_lastMethodCallTime))
		{
			return false;
		}
		if (!Utils.IsEqual(m_lastMethodReturnStatus, programDiagnostic2DataType.m_lastMethodReturnStatus))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (ProgramDiagnostic2DataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ProgramDiagnostic2DataType obj = (ProgramDiagnostic2DataType)base.MemberwiseClone();
		obj.m_createSessionId = (NodeId)Utils.Clone(m_createSessionId);
		obj.m_createClientName = (string)Utils.Clone(m_createClientName);
		obj.m_invocationCreationTime = (DateTime)Utils.Clone(m_invocationCreationTime);
		obj.m_lastTransitionTime = (DateTime)Utils.Clone(m_lastTransitionTime);
		obj.m_lastMethodCall = (string)Utils.Clone(m_lastMethodCall);
		obj.m_lastMethodSessionId = (NodeId)Utils.Clone(m_lastMethodSessionId);
		obj.m_lastMethodInputArguments = (ArgumentCollection)Utils.Clone(m_lastMethodInputArguments);
		obj.m_lastMethodOutputArguments = (ArgumentCollection)Utils.Clone(m_lastMethodOutputArguments);
		obj.m_lastMethodInputValues = (VariantCollection)Utils.Clone(m_lastMethodInputValues);
		obj.m_lastMethodOutputValues = (VariantCollection)Utils.Clone(m_lastMethodOutputValues);
		obj.m_lastMethodCallTime = (DateTime)Utils.Clone(m_lastMethodCallTime);
		obj.m_lastMethodReturnStatus = (StatusCode)Utils.Clone(m_lastMethodReturnStatus);
		return obj;
	}
}
