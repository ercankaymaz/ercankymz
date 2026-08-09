using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ServerStatusDataType : IEncodeable, ICloneable, IJsonEncodeable
{
	private DateTime m_startTime;

	private DateTime m_currentTime;

	private ServerState m_state;

	private BuildInfo m_buildInfo;

	private uint m_secondsTillShutdown;

	private LocalizedText m_shutdownReason;

	[DataMember(Name = "StartTime", IsRequired = false, Order = 1)]
	public DateTime StartTime
	{
		get
		{
			return m_startTime;
		}
		set
		{
			m_startTime = value;
		}
	}

	[DataMember(Name = "CurrentTime", IsRequired = false, Order = 2)]
	public DateTime CurrentTime
	{
		get
		{
			return m_currentTime;
		}
		set
		{
			m_currentTime = value;
		}
	}

	[DataMember(Name = "State", IsRequired = false, Order = 3)]
	public ServerState State
	{
		get
		{
			return m_state;
		}
		set
		{
			m_state = value;
		}
	}

	[DataMember(Name = "BuildInfo", IsRequired = false, Order = 4)]
	public BuildInfo BuildInfo
	{
		get
		{
			return m_buildInfo;
		}
		set
		{
			m_buildInfo = value;
			if (value == null)
			{
				m_buildInfo = new BuildInfo();
			}
		}
	}

	[DataMember(Name = "SecondsTillShutdown", IsRequired = false, Order = 5)]
	public uint SecondsTillShutdown
	{
		get
		{
			return m_secondsTillShutdown;
		}
		set
		{
			m_secondsTillShutdown = value;
		}
	}

	[DataMember(Name = "ShutdownReason", IsRequired = false, Order = 6)]
	public LocalizedText ShutdownReason
	{
		get
		{
			return m_shutdownReason;
		}
		set
		{
			m_shutdownReason = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.ServerStatusDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ServerStatusDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ServerStatusDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ServerStatusDataType_Encoding_DefaultJson;

	public ServerStatusDataType()
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
		m_startTime = DateTime.MinValue;
		m_currentTime = DateTime.MinValue;
		m_state = ServerState.Running;
		m_buildInfo = new BuildInfo();
		m_secondsTillShutdown = 0u;
		m_shutdownReason = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteDateTime("StartTime", StartTime);
		encoder.WriteDateTime("CurrentTime", CurrentTime);
		encoder.WriteEnumerated("State", State);
		encoder.WriteEncodeable("BuildInfo", BuildInfo, typeof(BuildInfo));
		encoder.WriteUInt32("SecondsTillShutdown", SecondsTillShutdown);
		encoder.WriteLocalizedText("ShutdownReason", ShutdownReason);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		StartTime = decoder.ReadDateTime("StartTime");
		CurrentTime = decoder.ReadDateTime("CurrentTime");
		State = (ServerState)(object)decoder.ReadEnumerated("State", typeof(ServerState));
		BuildInfo = (BuildInfo)decoder.ReadEncodeable("BuildInfo", typeof(BuildInfo));
		SecondsTillShutdown = decoder.ReadUInt32("SecondsTillShutdown");
		ShutdownReason = decoder.ReadLocalizedText("ShutdownReason");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ServerStatusDataType serverStatusDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_startTime, serverStatusDataType.m_startTime))
		{
			return false;
		}
		if (!Utils.IsEqual(m_currentTime, serverStatusDataType.m_currentTime))
		{
			return false;
		}
		if (!Utils.IsEqual(m_state, serverStatusDataType.m_state))
		{
			return false;
		}
		if (!Utils.IsEqual(m_buildInfo, serverStatusDataType.m_buildInfo))
		{
			return false;
		}
		if (!Utils.IsEqual(m_secondsTillShutdown, serverStatusDataType.m_secondsTillShutdown))
		{
			return false;
		}
		if (!Utils.IsEqual(m_shutdownReason, serverStatusDataType.m_shutdownReason))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (ServerStatusDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ServerStatusDataType obj = (ServerStatusDataType)base.MemberwiseClone();
		obj.m_startTime = (DateTime)Utils.Clone(m_startTime);
		obj.m_currentTime = (DateTime)Utils.Clone(m_currentTime);
		obj.m_state = (ServerState)Utils.Clone(m_state);
		obj.m_buildInfo = (BuildInfo)Utils.Clone(m_buildInfo);
		obj.m_secondsTillShutdown = (uint)Utils.Clone(m_secondsTillShutdown);
		obj.m_shutdownReason = (LocalizedText)Utils.Clone(m_shutdownReason);
		return obj;
	}
}
