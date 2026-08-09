using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class TraceConfiguration
{
	private string m_outputFilePath;

	private bool m_deleteOnLoad;

	private int m_traceMasks;

	[DataMember(IsRequired = false, Order = 0)]
	public string OutputFilePath
	{
		get
		{
			return m_outputFilePath;
		}
		set
		{
			m_outputFilePath = value;
		}
	}

	[DataMember(IsRequired = false, Order = 1)]
	public bool DeleteOnLoad
	{
		get
		{
			return m_deleteOnLoad;
		}
		set
		{
			m_deleteOnLoad = value;
		}
	}

	[DataMember(IsRequired = false, Order = 2)]
	public int TraceMasks
	{
		get
		{
			return m_traceMasks;
		}
		set
		{
			m_traceMasks = value;
		}
	}

	public TraceConfiguration()
	{
		Initialize();
	}

	private void Initialize()
	{
		m_outputFilePath = null;
		m_deleteOnLoad = false;
	}

	[OnDeserializing]
	public void Initialize(StreamingContext context)
	{
		Initialize();
	}

	public void ApplySettings()
	{
		Utils.SetTraceLog(m_outputFilePath, m_deleteOnLoad);
		Utils.SetTraceMask(m_traceMasks);
		if (m_traceMasks == 0)
		{
			Utils.SetTraceOutput(Utils.TraceOutput.Off);
		}
		else
		{
			Utils.SetTraceOutput(Utils.TraceOutput.DebugAndFile);
		}
	}
}
