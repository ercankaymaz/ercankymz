using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ProgramDiagnosticDataType : IEncodeable, ICloneable, IJsonEncodeable
{
	private NodeId m_createSessionId;

	private string m_createClientName;

	private DateTime m_invocationCreationTime;

	private DateTime m_lastTransitionTime;

	private string m_lastMethodCall;

	private NodeId m_lastMethodSessionId;

	private ArgumentCollection m_lastMethodInputArguments;

	private ArgumentCollection m_lastMethodOutputArguments;

	private DateTime m_lastMethodCallTime;

	private StatusResult m_lastMethodReturnStatus;

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

	[DataMember(Name = "LastMethodCallTime", IsRequired = false, Order = 9)]
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

	[DataMember(Name = "LastMethodReturnStatus", IsRequired = false, Order = 10)]
	public StatusResult LastMethodReturnStatus
	{
		get
		{
			return m_lastMethodReturnStatus;
		}
		set
		{
			m_lastMethodReturnStatus = value;
			if (value == null)
			{
				m_lastMethodReturnStatus = new StatusResult();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.ProgramDiagnosticDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ProgramDiagnosticDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ProgramDiagnosticDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ProgramDiagnosticDataType_Encoding_DefaultJson;

	public ProgramDiagnosticDataType()
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
		m_lastMethodCallTime = DateTime.MinValue;
		m_lastMethodReturnStatus = new StatusResult();
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
		encoder.WriteDateTime("LastMethodCallTime", LastMethodCallTime);
		encoder.WriteEncodeable("LastMethodReturnStatus", LastMethodReturnStatus, typeof(StatusResult));
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
		LastMethodCallTime = decoder.ReadDateTime("LastMethodCallTime");
		LastMethodReturnStatus = (StatusResult)decoder.ReadEncodeable("LastMethodReturnStatus", typeof(StatusResult));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ProgramDiagnosticDataType programDiagnosticDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_createSessionId, programDiagnosticDataType.m_createSessionId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_createClientName, programDiagnosticDataType.m_createClientName))
		{
			return false;
		}
		if (!Utils.IsEqual(m_invocationCreationTime, programDiagnosticDataType.m_invocationCreationTime))
		{
			return false;
		}
		if (!Utils.IsEqual(m_lastTransitionTime, programDiagnosticDataType.m_lastTransitionTime))
		{
			return false;
		}
		if (!Utils.IsEqual(m_lastMethodCall, programDiagnosticDataType.m_lastMethodCall))
		{
			return false;
		}
		if (!Utils.IsEqual(m_lastMethodSessionId, programDiagnosticDataType.m_lastMethodSessionId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_lastMethodInputArguments, programDiagnosticDataType.m_lastMethodInputArguments))
		{
			return false;
		}
		if (!Utils.IsEqual(m_lastMethodOutputArguments, programDiagnosticDataType.m_lastMethodOutputArguments))
		{
			return false;
		}
		if (!Utils.IsEqual(m_lastMethodCallTime, programDiagnosticDataType.m_lastMethodCallTime))
		{
			return false;
		}
		if (!Utils.IsEqual(m_lastMethodReturnStatus, programDiagnosticDataType.m_lastMethodReturnStatus))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (ProgramDiagnosticDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ProgramDiagnosticDataType obj = (ProgramDiagnosticDataType)base.MemberwiseClone();
		obj.m_createSessionId = (NodeId)Utils.Clone(m_createSessionId);
		obj.m_createClientName = (string)Utils.Clone(m_createClientName);
		obj.m_invocationCreationTime = (DateTime)Utils.Clone(m_invocationCreationTime);
		obj.m_lastTransitionTime = (DateTime)Utils.Clone(m_lastTransitionTime);
		obj.m_lastMethodCall = (string)Utils.Clone(m_lastMethodCall);
		obj.m_lastMethodSessionId = (NodeId)Utils.Clone(m_lastMethodSessionId);
		obj.m_lastMethodInputArguments = (ArgumentCollection)Utils.Clone(m_lastMethodInputArguments);
		obj.m_lastMethodOutputArguments = (ArgumentCollection)Utils.Clone(m_lastMethodOutputArguments);
		obj.m_lastMethodCallTime = (DateTime)Utils.Clone(m_lastMethodCallTime);
		obj.m_lastMethodReturnStatus = (StatusResult)Utils.Clone(m_lastMethodReturnStatus);
		return obj;
	}
}
