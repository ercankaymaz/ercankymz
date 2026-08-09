using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace Opc.Ua;

[ComVisible(true)]
public class ConfigurationWatcher : IDisposable
{
	private readonly object m_lock = new object();

	private ApplicationConfiguration m_configuration;

	private Timer m_watcher;

	private DateTime m_lastWriteTime;

	public event EventHandler<ConfigurationWatcherEventArgs> Changed
	{
		add
		{
			lock (m_lock)
			{
				m_Changed += value;
			}
		}
		remove
		{
			lock (m_lock)
			{
				m_Changed -= value;
			}
		}
	}

	private event EventHandler<ConfigurationWatcherEventArgs> m_Changed;

	public ConfigurationWatcher(ApplicationConfiguration configuration)
	{
		if (configuration == null)
		{
			throw new ArgumentNullException("configuration");
		}
		FileInfo fileInfo = new FileInfo(configuration.SourceFilePath);
		if (!fileInfo.Exists)
		{
			throw new FileNotFoundException("Could not load configuration file", configuration.SourceFilePath);
		}
		m_configuration = configuration;
		m_lastWriteTime = fileInfo.LastWriteTimeUtc;
		m_watcher = new Timer(Watcher_Changed, null, 5000, 5000);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing && m_watcher != null)
		{
			m_watcher.Dispose();
			m_watcher = null;
		}
	}

	private void Watcher_Changed(object state)
	{
		try
		{
			FileInfo fileInfo = new FileInfo(m_configuration.SourceFilePath);
			if (fileInfo.Exists && !(fileInfo.LastWriteTimeUtc <= m_lastWriteTime))
			{
				m_lastWriteTime = fileInfo.LastWriteTimeUtc;
				this.m_Changed?.Invoke(this, new ConfigurationWatcherEventArgs(m_configuration, m_configuration.SourceFilePath));
			}
		}
		catch (Exception exception)
		{
			Utils.LogError(exception, "Unexpected error raising configuration file changed event.");
		}
	}
}
