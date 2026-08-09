using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class ConfigurationWatcherEventArgs : EventArgs
{
	private ApplicationConfiguration m_configuration;

	private string m_filePath;

	public ApplicationConfiguration Configuration => m_configuration;

	public string FilePath => m_filePath;

	public ConfigurationWatcherEventArgs(ApplicationConfiguration configuration, string filePath)
	{
		m_configuration = configuration;
		m_filePath = filePath;
	}
}
