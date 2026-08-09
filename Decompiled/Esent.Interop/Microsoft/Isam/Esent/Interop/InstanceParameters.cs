using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Isam.Esent.Interop.Windows8;
using Microsoft.Isam.Esent.Interop.Windows81;

namespace Microsoft.Isam.Esent.Interop;

public class InstanceParameters
{
	private readonly JET_INSTANCE instance;

	private readonly JET_SESID sesid;

	public string SystemDirectory
	{
		get
		{
			return Util.AddTrailingDirectorySeparator(GetStringParameter(JET_param.SystemPath));
		}
		set
		{
			SetStringParameter(JET_param.SystemPath, Util.AddTrailingDirectorySeparator(value));
		}
	}

	public string TempDirectory
	{
		get
		{
			return Util.AddTrailingDirectorySeparator(Path.GetDirectoryName(GetStringParameter(JET_param.TempPath)));
		}
		set
		{
			SetStringParameter(JET_param.TempPath, Util.AddTrailingDirectorySeparator(value));
		}
	}

	public string LogFileDirectory
	{
		get
		{
			return Util.AddTrailingDirectorySeparator(GetStringParameter(JET_param.LogFilePath));
		}
		set
		{
			SetStringParameter(JET_param.LogFilePath, Util.AddTrailingDirectorySeparator(value));
		}
	}

	public string AlternateDatabaseRecoveryDirectory
	{
		get
		{
			if (EsentVersion.SupportsServer2003Features)
			{
				return Util.AddTrailingDirectorySeparator(GetStringParameter((JET_param)113));
			}
			return null;
		}
		set
		{
			if (EsentVersion.SupportsServer2003Features)
			{
				SetStringParameter((JET_param)113, Util.AddTrailingDirectorySeparator(value));
			}
		}
	}

	public string BaseName
	{
		get
		{
			return GetStringParameter(JET_param.BaseName);
		}
		set
		{
			SetStringParameter(JET_param.BaseName, value);
		}
	}

	public string EventSource
	{
		get
		{
			return GetStringParameter(JET_param.EventSource);
		}
		set
		{
			SetStringParameter(JET_param.EventSource, value);
		}
	}

	public int MaxSessions
	{
		get
		{
			return GetIntegerParameter(JET_param.MaxSessions);
		}
		set
		{
			SetIntegerParameter(JET_param.MaxSessions, value);
		}
	}

	public int MaxOpenTables
	{
		get
		{
			return GetIntegerParameter(JET_param.MaxOpenTables);
		}
		set
		{
			SetIntegerParameter(JET_param.MaxOpenTables, value);
		}
	}

	public int MaxCursors
	{
		get
		{
			return GetIntegerParameter(JET_param.MaxCursors);
		}
		set
		{
			SetIntegerParameter(JET_param.MaxCursors, value);
		}
	}

	public int MaxVerPages
	{
		get
		{
			return GetIntegerParameter(JET_param.MaxVerPages);
		}
		set
		{
			SetIntegerParameter(JET_param.MaxVerPages, value);
		}
	}

	public int PreferredVerPages
	{
		get
		{
			return GetIntegerParameter(JET_param.PreferredVerPages);
		}
		set
		{
			SetIntegerParameter(JET_param.PreferredVerPages, value);
		}
	}

	public int VersionStoreTaskQueueMax
	{
		get
		{
			return GetIntegerParameter(JET_param.VersionStoreTaskQueueMax);
		}
		set
		{
			SetIntegerParameter(JET_param.VersionStoreTaskQueueMax, value);
		}
	}

	public int MaxTemporaryTables
	{
		get
		{
			return GetIntegerParameter(JET_param.MaxTemporaryTables);
		}
		set
		{
			SetIntegerParameter(JET_param.MaxTemporaryTables, value);
		}
	}

	public int LogFileSize
	{
		get
		{
			return GetIntegerParameter(JET_param.LogFileSize);
		}
		set
		{
			SetIntegerParameter(JET_param.LogFileSize, value);
		}
	}

	public int LogBuffers
	{
		get
		{
			return GetIntegerParameter(JET_param.LogBuffers);
		}
		set
		{
			SetIntegerParameter(JET_param.LogBuffers, value);
		}
	}

	public bool CircularLog
	{
		get
		{
			return GetBoolParameter(JET_param.CircularLog);
		}
		set
		{
			SetBoolParameter(JET_param.CircularLog, value);
		}
	}

	public bool CleanupMismatchedLogFiles
	{
		get
		{
			return GetBoolParameter(JET_param.CleanupMismatchedLogFiles);
		}
		set
		{
			SetBoolParameter(JET_param.CleanupMismatchedLogFiles, value);
		}
	}

	public int PageTempDBMin
	{
		get
		{
			return GetIntegerParameter(JET_param.PageTempDBMin);
		}
		set
		{
			SetIntegerParameter(JET_param.PageTempDBMin, value);
		}
	}

	public int CheckpointDepthMax
	{
		get
		{
			return GetIntegerParameter(JET_param.CheckpointDepthMax);
		}
		set
		{
			SetIntegerParameter(JET_param.CheckpointDepthMax, value);
		}
	}

	public int DbExtensionSize
	{
		get
		{
			return GetIntegerParameter(JET_param.DbExtensionSize);
		}
		set
		{
			SetIntegerParameter(JET_param.DbExtensionSize, value);
		}
	}

	public bool Recovery
	{
		get
		{
			return string.Compare(GetStringParameter(JET_param.Recovery), "on", StringComparison.OrdinalIgnoreCase) == 0;
		}
		set
		{
			if (value)
			{
				SetStringParameter(JET_param.Recovery, "on");
			}
			else
			{
				SetStringParameter(JET_param.Recovery, "off");
			}
		}
	}

	public bool EnableOnlineDefrag
	{
		get
		{
			return GetBoolParameter(JET_param.EnableOnlineDefrag);
		}
		set
		{
			SetBoolParameter(JET_param.EnableOnlineDefrag, value);
		}
	}

	public bool EnableIndexChecking
	{
		get
		{
			return GetBoolParameter(JET_param.EnableIndexChecking);
		}
		set
		{
			SetBoolParameter(JET_param.EnableIndexChecking, value);
		}
	}

	public string EventSourceKey
	{
		get
		{
			return GetStringParameter(JET_param.EventSourceKey);
		}
		set
		{
			SetStringParameter(JET_param.EventSourceKey, value);
		}
	}

	public bool NoInformationEvent
	{
		get
		{
			return GetBoolParameter(JET_param.NoInformationEvent);
		}
		set
		{
			SetBoolParameter(JET_param.NoInformationEvent, value);
		}
	}

	public EventLoggingLevels EventLoggingLevel
	{
		get
		{
			return (EventLoggingLevels)GetIntegerParameter(JET_param.EventLoggingLevel);
		}
		set
		{
			SetIntegerParameter(JET_param.EventLoggingLevel, (int)value);
		}
	}

	public bool OneDatabasePerSession
	{
		get
		{
			return GetBoolParameter(JET_param.OneDatabasePerSession);
		}
		set
		{
			SetBoolParameter(JET_param.OneDatabasePerSession, value);
		}
	}

	public bool CreatePathIfNotExist
	{
		get
		{
			return GetBoolParameter(JET_param.CreatePathIfNotExist);
		}
		set
		{
			SetBoolParameter(JET_param.CreatePathIfNotExist, value);
		}
	}

	public int CachedClosedTables
	{
		get
		{
			if (EsentVersion.SupportsVistaFeatures)
			{
				return GetIntegerParameter((JET_param)125);
			}
			return 0;
		}
		set
		{
			if (EsentVersion.SupportsVistaFeatures)
			{
				SetIntegerParameter((JET_param)125, value);
			}
		}
	}

	public int WaypointLatency
	{
		get
		{
			if (EsentVersion.SupportsWindows7Features)
			{
				return GetIntegerParameter((JET_param)153);
			}
			return 0;
		}
		set
		{
			if (EsentVersion.SupportsWindows7Features)
			{
				SetIntegerParameter((JET_param)153, value);
			}
		}
	}

	public bool EnableIndexCleanup
	{
		get
		{
			return GetBoolParameter(JET_param.EnableIndexCleanup);
		}
		set
		{
			SetBoolParameter(JET_param.EnableIndexCleanup, value);
		}
	}

	public ShrinkDatabaseGrbit EnableShrinkDatabase
	{
		get
		{
			return (ShrinkDatabaseGrbit)GetIntegerParameter((JET_param)184);
		}
		set
		{
			SetIntegerParameter((JET_param)184, (int)value);
		}
	}

	public int MaxTransactionSize
	{
		get
		{
			return GetIntegerParameter((JET_param)178);
		}
		set
		{
			SetIntegerParameter((JET_param)178, value);
		}
	}

	public int EnableDbScanInRecovery
	{
		get
		{
			return GetIntegerParameter((JET_param)169);
		}
		set
		{
			SetIntegerParameter((JET_param)169, value);
		}
	}

	public bool EnableDBScanSerialization
	{
		get
		{
			return GetBoolParameter((JET_param)180);
		}
		set
		{
			SetBoolParameter((JET_param)180, value);
		}
	}

	public int DbScanThrottle
	{
		get
		{
			return GetIntegerParameter((JET_param)170);
		}
		set
		{
			SetIntegerParameter((JET_param)170, value);
		}
	}

	public int DbScanIntervalMinSec
	{
		get
		{
			return GetIntegerParameter((JET_param)171);
		}
		set
		{
			SetIntegerParameter((JET_param)171, value);
		}
	}

	public int DbScanIntervalMaxSec
	{
		get
		{
			return GetIntegerParameter((JET_param)172);
		}
		set
		{
			SetIntegerParameter((JET_param)172, value);
		}
	}

	public int CachePriority
	{
		get
		{
			return GetIntegerParameter((JET_param)177);
		}
		set
		{
			SetIntegerParameter((JET_param)177, value);
		}
	}

	public int PrereadIOMax
	{
		get
		{
			return GetIntegerParameter((JET_param)179);
		}
		set
		{
			SetIntegerParameter((JET_param)179, value);
		}
	}

	public InstanceParameters(JET_INSTANCE instance)
	{
		this.instance = instance;
		sesid = JET_SESID.Nil;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "InstanceParameters (0x{0:x})", instance.Value);
	}

	private void SetStringParameter(JET_param param, string value)
	{
		Api.JetSetSystemParameter(instance, sesid, param, 0, value);
	}

	private string GetStringParameter(JET_param param)
	{
		int paramValue = 0;
		Api.JetGetSystemParameter(instance, sesid, param, ref paramValue, out var paramString, 1024);
		return paramString;
	}

	private void SetIntegerParameter(JET_param param, int value)
	{
		Api.JetSetSystemParameter(instance, sesid, param, value, null);
	}

	private int GetIntegerParameter(JET_param param)
	{
		int paramValue = 0;
		Api.JetGetSystemParameter(instance, sesid, param, ref paramValue, out var _, 0);
		return paramValue;
	}

	private void SetBoolParameter(JET_param param, bool value)
	{
		if (value)
		{
			Api.JetSetSystemParameter(instance, sesid, param, 1, null);
		}
		else
		{
			Api.JetSetSystemParameter(instance, sesid, param, 0, null);
		}
	}

	private bool GetBoolParameter(JET_param param)
	{
		int paramValue = 0;
		Api.JetGetSystemParameter(instance, sesid, param, ref paramValue, out var _, 0);
		return paramValue != 0;
	}

	internal NATIVE_JET_PFNDURABLECOMMITCALLBACK GetDurableCommitCallback()
	{
		NATIVE_JET_PFNDURABLECOMMITCALLBACK result = null;
		IntPtr intPtrParameter = GetIntPtrParameter((JET_param)187);
		if (intPtrParameter != IntPtr.Zero)
		{
			result = (NATIVE_JET_PFNDURABLECOMMITCALLBACK)Marshal.GetDelegateForFunctionPointer(intPtrParameter, typeof(NATIVE_JET_PFNDURABLECOMMITCALLBACK));
		}
		return result;
	}

	internal void SetDurableCommitCallback(NATIVE_JET_PFNDURABLECOMMITCALLBACK callback)
	{
		IntPtr value = ((callback == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(callback));
		SetIntPtrParameter((JET_param)187, value);
	}

	private IntPtr GetIntPtrParameter(JET_param param)
	{
		IntPtr paramValue = IntPtr.Zero;
		Api.JetGetSystemParameter(instance, sesid, param, ref paramValue, out var _, 0);
		return paramValue;
	}

	private void SetIntPtrParameter(JET_param param, IntPtr value)
	{
		Api.JetSetSystemParameter(instance, sesid, param, value, null);
	}
}
