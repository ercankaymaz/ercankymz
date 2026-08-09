using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Runtime.Caching.Hosting;
using System.Runtime.Caching.Resources;
using System.Text;
using System.Threading;

namespace System.Runtime.Caching;

public sealed class HostFileChangeMonitor : FileChangeMonitor
{
	private const int MAX_CHAR_COUNT_OF_LONG_CONVERTED_TO_HEXADECIMAL_STRING = 16;

	private static IFileChangeNotificationSystem s_fcn;

	private readonly ReadOnlyCollection<string> _filePaths;

	private string _uniqueId;

	private object _fcnState;

	private DateTimeOffset _lastModified;

	public override ReadOnlyCollection<string> FilePaths => _filePaths;

	public override string UniqueId => _uniqueId;

	public override DateTimeOffset LastModified => _lastModified;

	private HostFileChangeMonitor()
	{
	}

	private void InitDisposableMembers()
	{
		bool flag = true;
		try
		{
			string text = null;
			if (_filePaths.Count == 1)
			{
				string text2 = _filePaths[0];
				s_fcn.StartMonitoring(text2, base.OnChanged, out _fcnState, out var lastWriteTime, out var fileSize);
				text = $"{text2}{lastWriteTime.UtcDateTime.Ticks:X}{fileSize:X}";
				_lastModified = lastWriteTime;
			}
			else
			{
				int num = 0;
				foreach (string filePath in _filePaths)
				{
					num += filePath.Length + 32;
				}
				Hashtable hashtable = (Hashtable)(_fcnState = new Hashtable(_filePaths.Count));
				StringBuilder stringBuilder = new StringBuilder(num);
				foreach (string filePath2 in _filePaths)
				{
					if (!hashtable.Contains(filePath2))
					{
						s_fcn.StartMonitoring(filePath2, base.OnChanged, out var state, out var lastWriteTime2, out var fileSize2);
						hashtable[filePath2] = state;
						stringBuilder.Append(filePath2);
						stringBuilder.Append(lastWriteTime2.UtcDateTime.Ticks.ToString("X", CultureInfo.InvariantCulture));
						stringBuilder.Append(fileSize2.ToString("X", CultureInfo.InvariantCulture));
						if (lastWriteTime2 > _lastModified)
						{
							_lastModified = lastWriteTime2;
						}
					}
				}
				text = stringBuilder.ToString();
			}
			_uniqueId = text;
			flag = false;
		}
		finally
		{
			InitializationComplete();
			if (flag)
			{
				Dispose();
			}
		}
	}

	private static void InitFCN()
	{
		if (s_fcn != null)
		{
			return;
		}
		IFileChangeNotificationSystem fileChangeNotificationSystem = null;
		IServiceProvider host = ObjectCache.Host;
		if (host != null)
		{
			fileChangeNotificationSystem = host.GetService(typeof(IFileChangeNotificationSystem)) as IFileChangeNotificationSystem;
		}
		if (fileChangeNotificationSystem == null)
		{
			if (OperatingSystem.IsBrowser() || (OperatingSystem.IsIOS() && !OperatingSystem.IsMacCatalyst()) || OperatingSystem.IsTvOS())
			{
				throw new PlatformNotSupportedException();
			}
			fileChangeNotificationSystem = new FileChangeNotificationSystem();
		}
		Interlocked.CompareExchange(ref s_fcn, fileChangeNotificationSystem, null);
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing || s_fcn == null || _filePaths == null || _fcnState == null)
		{
			return;
		}
		if (_filePaths.Count > 1)
		{
			Hashtable hashtable = _fcnState as Hashtable;
			{
				foreach (string filePath in _filePaths)
				{
					if (filePath != null)
					{
						object obj = hashtable[filePath];
						if (obj != null)
						{
							s_fcn.StopMonitoring(filePath, obj);
						}
					}
				}
				return;
			}
		}
		string text = _filePaths[0];
		if (text != null && _fcnState != null)
		{
			s_fcn.StopMonitoring(text, _fcnState);
		}
	}

	public HostFileChangeMonitor(IList<string> filePaths)
	{
		if (filePaths == null)
		{
			throw new ArgumentNullException("filePaths");
		}
		if (filePaths.Count == 0)
		{
			throw new ArgumentException(RH.Format(System.SR.Empty_collection, "filePaths"));
		}
		_filePaths = SanitizeFilePathsList(filePaths);
		InitFCN();
		InitDisposableMembers();
	}

	private static ReadOnlyCollection<string> SanitizeFilePathsList(IList<string> filePaths)
	{
		List<string> list = new List<string>(filePaths.Count);
		foreach (string filePath in filePaths)
		{
			if (string.IsNullOrEmpty(filePath))
			{
				throw new ArgumentException(RH.Format(System.SR.Collection_contains_null_or_empty_string, "filePaths"));
			}
			list.Add(filePath);
		}
		return list.AsReadOnly();
	}
}
