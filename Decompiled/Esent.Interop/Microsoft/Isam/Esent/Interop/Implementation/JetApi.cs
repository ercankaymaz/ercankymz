using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Microsoft.Isam.Esent.Interop.Server2003;
using Microsoft.Isam.Esent.Interop.Vista;
using Microsoft.Isam.Esent.Interop.Win32;
using Microsoft.Isam.Esent.Interop.Windows10;
using Microsoft.Isam.Esent.Interop.Windows7;
using Microsoft.Isam.Esent.Interop.Windows8;

namespace Microsoft.Isam.Esent.Interop.Implementation;

internal sealed class JetApi : IJetApi
{
	private static readonly TraceSwitch TraceSwitch;

	private readonly uint versionOverride;

	private readonly CallbackWrappers callbackWrappers = new CallbackWrappers();

	public JetCapabilities Capabilities { get; private set; }

	static JetApi()
	{
		TraceSwitch = new TraceSwitch("ESENT P/Invoke", "P/Invoke calls to ESENT");
		RuntimeHelpers.PrepareMethod(typeof(JetApi).GetMethod("JetCreateInstance").MethodHandle);
		RuntimeHelpers.PrepareMethod(typeof(JetApi).GetMethod("JetCreateInstance2").MethodHandle);
		RuntimeHelpers.PrepareMethod(typeof(JetApi).GetMethod("JetInit").MethodHandle);
		RuntimeHelpers.PrepareMethod(typeof(JetApi).GetMethod("JetInit2").MethodHandle);
		RuntimeHelpers.PrepareMethod(typeof(JetApi).GetMethod("JetInit3").MethodHandle);
		RuntimeHelpers.PrepareMethod(typeof(JetApi).GetMethod("JetTerm").MethodHandle);
		RuntimeHelpers.PrepareMethod(typeof(JetApi).GetMethod("JetTerm2").MethodHandle);
	}

	public JetApi(uint version)
	{
		versionOverride = version;
		DetermineCapabilities();
	}

	public JetApi()
	{
		DetermineCapabilities();
	}

	public int JetCreateInstance(out JET_INSTANCE instance, string name)
	{
		instance.Value = IntPtr.Zero;
		if (Capabilities.SupportsUnicodePaths)
		{
			return Err(NativeMethods.JetCreateInstanceW(out instance.Value, name));
		}
		return Err(NativeMethods.JetCreateInstance(out instance.Value, name));
	}

	public int JetCreateInstance2(out JET_INSTANCE instance, string name, string displayName, CreateInstanceGrbit grbit)
	{
		instance.Value = IntPtr.Zero;
		checked
		{
			if (Capabilities.SupportsUnicodePaths)
			{
				return Err(NativeMethods.JetCreateInstance2W(out instance.Value, name, displayName, (uint)grbit));
			}
			return Err(NativeMethods.JetCreateInstance2(out instance.Value, name, displayName, (uint)grbit));
		}
	}

	public int JetInit(ref JET_INSTANCE instance)
	{
		return Err(NativeMethods.JetInit(ref instance.Value));
	}

	public int JetInit2(ref JET_INSTANCE instance, InitGrbit grbit)
	{
		return Err(NativeMethods.JetInit2(ref instance.Value, checked((uint)grbit)));
	}

	public unsafe int JetInit3(ref JET_INSTANCE instance, JET_RSTINFO recoveryOptions, InitGrbit grbit)
	{
		CheckSupportsVistaFeatures("JetInit3");
		checked
		{
			if (recoveryOptions != null)
			{
				StatusCallbackWrapper statusCallbackWrapper = new StatusCallbackWrapper(recoveryOptions.pfnStatus);
				NATIVE_RSTINFO prstinfo = recoveryOptions.GetNativeRstinfo();
				int num = ((recoveryOptions.rgrstmap != null) ? recoveryOptions.rgrstmap.Length : 0);
				try
				{
					NATIVE_RSTMAP* rgrstmap = stackalloc NATIVE_RSTMAP[num];
					if (num > 0)
					{
						prstinfo.rgrstmap = rgrstmap;
						for (int i = 0; i < num; i++)
						{
							unchecked
							{
								*(NATIVE_RSTMAP*)((byte*)prstinfo.rgrstmap + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_RSTMAP)))) = recoveryOptions.rgrstmap[i].GetNativeRstmap();
							}
						}
					}
					prstinfo.pfnStatus = statusCallbackWrapper.NativeCallback;
					int result = Err(NativeMethods.JetInit3W(ref instance.Value, ref prstinfo, (uint)grbit));
					statusCallbackWrapper.ThrowSavedException();
					return result;
				}
				finally
				{
					if (null != prstinfo.rgrstmap)
					{
						for (int j = 0; j < num; j++)
						{
							unchecked
							{
								((NATIVE_RSTMAP*)((byte*)prstinfo.rgrstmap + checked(unchecked((nint)j) * unchecked((nint)sizeof(NATIVE_RSTMAP)))))->FreeHGlobal();
							}
						}
					}
				}
			}
			return Err(NativeMethods.JetInit3W(ref instance.Value, IntPtr.Zero, (uint)grbit));
		}
	}

	public unsafe int JetGetInstanceInfo(out int numInstances, out JET_INSTANCE_INFO[] instances)
	{
		uint pcInstanceInfo = 0u;
		NATIVE_INSTANCE_INFO* prgInstanceInfo = null;
		int err;
		if (Capabilities.SupportsUnicodePaths)
		{
			err = NativeMethods.JetGetInstanceInfoW(out pcInstanceInfo, out prgInstanceInfo);
			instances = ConvertInstanceInfosUnicode(pcInstanceInfo, prgInstanceInfo);
		}
		else
		{
			err = NativeMethods.JetGetInstanceInfo(out pcInstanceInfo, out prgInstanceInfo);
			instances = ConvertInstanceInfosAscii(pcInstanceInfo, prgInstanceInfo);
		}
		numInstances = instances.Length;
		return Err(err);
	}

	public int JetGetInstanceMiscInfo(JET_INSTANCE instance, out JET_SIGNATURE signature, JET_InstanceMiscInfo infoLevel)
	{
		CheckSupportsVistaFeatures("JetGetInstanceMiscInfo");
		NATIVE_SIGNATURE pvResult = default(NATIVE_SIGNATURE);
		int err = NativeMethods.JetGetInstanceMiscInfo(instance.Value, ref pvResult, checked((uint)NATIVE_SIGNATURE.Size), (uint)infoLevel);
		signature = new JET_SIGNATURE(pvResult);
		return Err(err);
	}

	public int JetStopBackupInstance(JET_INSTANCE instance)
	{
		return Err(NativeMethods.JetStopBackupInstance(instance.Value));
	}

	public int JetStopServiceInstance(JET_INSTANCE instance)
	{
		return Err(NativeMethods.JetStopServiceInstance(instance.Value));
	}

	public int JetStopServiceInstance2(JET_INSTANCE instance, StopServiceGrbit grbit)
	{
		CheckSupportsWindows8Features("JetStopServiceInstance2");
		return Err(NativeMethods.JetStopServiceInstance2(instance.Value, (uint)grbit));
	}

	public int JetTerm(JET_INSTANCE instance)
	{
		callbackWrappers.Collect();
		if (!instance.IsInvalid)
		{
			return Err(NativeMethods.JetTerm(instance.Value));
		}
		return 0;
	}

	public int JetTerm2(JET_INSTANCE instance, TermGrbit grbit)
	{
		callbackWrappers.Collect();
		if (!instance.IsInvalid)
		{
			return Err(NativeMethods.JetTerm2(instance.Value, checked((uint)grbit)));
		}
		return 0;
	}

	public unsafe int JetSetSystemParameter(JET_INSTANCE instance, JET_SESID sesid, JET_param paramid, IntPtr paramValue, string paramString)
	{
		IntPtr* pinstance = ((IntPtr.Zero == instance.Value) ? null : (&instance.Value));
		checked
		{
			if (Capabilities.SupportsUnicodePaths)
			{
				return Err(NativeMethods.JetSetSystemParameterW(pinstance, sesid.Value, (uint)paramid, paramValue, paramString));
			}
			return Err(NativeMethods.JetSetSystemParameter(pinstance, sesid.Value, (uint)paramid, paramValue, paramString));
		}
	}

	public unsafe int JetSetSystemParameter(JET_INSTANCE instance, JET_SESID sesid, JET_param paramid, JET_CALLBACK paramValue, string paramString)
	{
		IntPtr* pinstance = ((IntPtr.Zero == instance.Value) ? null : (&instance.Value));
		checked
		{
			if (paramValue == null)
			{
				return Err(NativeMethods.JetSetSystemParameter(pinstance, sesid.Value, (uint)paramid, IntPtr.Zero, paramString));
			}
			JetCallbackWrapper jetCallbackWrapper = callbackWrappers.Add(paramValue);
			callbackWrappers.Collect();
			IntPtr functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate(jetCallbackWrapper.NativeCallback);
			return Err(NativeMethods.JetSetSystemParameter(pinstance, sesid.Value, (uint)paramid, functionPointerForDelegate, paramString));
		}
	}

	public int JetGetSystemParameter(JET_INSTANCE instance, JET_SESID sesid, JET_param paramid, ref IntPtr paramValue, out string paramString, int maxParam)
	{
		CheckNotNegative(maxParam, "maxParam");
		checked
		{
			uint cbMax = (uint)(Capabilities.SupportsUnicodePaths ? (maxParam * 2) : maxParam);
			StringBuilder stringBuilder = new StringBuilder(maxParam);
			int result = ((!Capabilities.SupportsUnicodePaths) ? Err(NativeMethods.JetGetSystemParameter(instance.Value, sesid.Value, (uint)paramid, ref paramValue, stringBuilder, cbMax)) : Err(NativeMethods.JetGetSystemParameterW(instance.Value, sesid.Value, (uint)paramid, ref paramValue, stringBuilder, cbMax)));
			paramString = stringBuilder.ToString();
			paramString = StringCache.TryToIntern(paramString);
			return result;
		}
	}

	public int JetGetVersion(JET_SESID sesid, out uint version)
	{
		uint dwVersion;
		int result;
		if (versionOverride != 0)
		{
			dwVersion = versionOverride;
			result = 0;
		}
		else
		{
			result = Err(NativeMethods.JetGetVersion(sesid.Value, out dwVersion));
		}
		version = dwVersion;
		return result;
	}

	public int JetCreateDatabase(JET_SESID sesid, string database, string connect, out JET_DBID dbid, CreateDatabaseGrbit grbit)
	{
		CheckNotNull(database, "database");
		dbid = JET_DBID.Nil;
		checked
		{
			if (Capabilities.SupportsUnicodePaths)
			{
				return Err(NativeMethods.JetCreateDatabaseW(sesid.Value, database, connect, out dbid.Value, (uint)grbit));
			}
			return Err(NativeMethods.JetCreateDatabase(sesid.Value, database, connect, out dbid.Value, (uint)grbit));
		}
	}

	public int JetCreateDatabase2(JET_SESID sesid, string database, int maxPages, out JET_DBID dbid, CreateDatabaseGrbit grbit)
	{
		CheckNotNull(database, "database");
		CheckNotNegative(maxPages, "maxPages");
		dbid = JET_DBID.Nil;
		checked
		{
			uint cpgDatabaseSizeMax = (uint)maxPages;
			if (Capabilities.SupportsUnicodePaths)
			{
				return Err(NativeMethods.JetCreateDatabase2W(sesid.Value, database, cpgDatabaseSizeMax, out dbid.Value, (uint)grbit));
			}
			return Err(NativeMethods.JetCreateDatabase2(sesid.Value, database, cpgDatabaseSizeMax, out dbid.Value, (uint)grbit));
		}
	}

	public int JetAttachDatabase(JET_SESID sesid, string database, AttachDatabaseGrbit grbit)
	{
		CheckNotNull(database, "database");
		checked
		{
			if (Capabilities.SupportsUnicodePaths)
			{
				return Err(NativeMethods.JetAttachDatabaseW(sesid.Value, database, (uint)grbit));
			}
			return Err(NativeMethods.JetAttachDatabase(sesid.Value, database, (uint)grbit));
		}
	}

	public int JetAttachDatabase2(JET_SESID sesid, string database, int maxPages, AttachDatabaseGrbit grbit)
	{
		CheckNotNull(database, "database");
		CheckNotNegative(maxPages, "maxPages");
		checked
		{
			if (Capabilities.SupportsUnicodePaths)
			{
				return Err(NativeMethods.JetAttachDatabase2W(sesid.Value, database, (uint)maxPages, (uint)grbit));
			}
			return Err(NativeMethods.JetAttachDatabase2(sesid.Value, database, (uint)maxPages, (uint)grbit));
		}
	}

	public int JetOpenDatabase(JET_SESID sesid, string database, string connect, out JET_DBID dbid, OpenDatabaseGrbit grbit)
	{
		CheckNotNull(database, "database");
		dbid = JET_DBID.Nil;
		checked
		{
			if (Capabilities.SupportsUnicodePaths)
			{
				return Err(NativeMethods.JetOpenDatabaseW(sesid.Value, database, connect, out dbid.Value, (uint)grbit));
			}
			return Err(NativeMethods.JetOpenDatabase(sesid.Value, database, connect, out dbid.Value, (uint)grbit));
		}
	}

	public int JetCloseDatabase(JET_SESID sesid, JET_DBID dbid, CloseDatabaseGrbit grbit)
	{
		return Err(NativeMethods.JetCloseDatabase(sesid.Value, dbid.Value, checked((uint)grbit)));
	}

	public int JetDetachDatabase(JET_SESID sesid, string database)
	{
		if (Capabilities.SupportsUnicodePaths)
		{
			return Err(NativeMethods.JetDetachDatabaseW(sesid.Value, database));
		}
		return Err(NativeMethods.JetDetachDatabase(sesid.Value, database));
	}

	public int JetDetachDatabase2(JET_SESID sesid, string database, DetachDatabaseGrbit grbit)
	{
		checked
		{
			if (Capabilities.SupportsUnicodePaths)
			{
				return Err(NativeMethods.JetDetachDatabase2W(sesid.Value, database, (uint)grbit));
			}
			return Err(NativeMethods.JetDetachDatabase2(sesid.Value, database, (uint)grbit));
		}
	}

	public int JetCompact(JET_SESID sesid, string sourceDatabase, string destinationDatabase, JET_PFNSTATUS statusCallback, object ignored, CompactGrbit grbit)
	{
		CheckNotNull(sourceDatabase, "sourceDatabase");
		CheckNotNull(destinationDatabase, "destinationDatabase");
		if (ignored != null)
		{
			throw new ArgumentException("must be null", "ignored");
		}
		StatusCallbackWrapper statusCallbackWrapper = new StatusCallbackWrapper(statusCallback);
		IntPtr pfnStatus = ((statusCallback == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(statusCallbackWrapper.NativeCallback));
		int result = checked((!Capabilities.SupportsUnicodePaths) ? Err(NativeMethods.JetCompact(sesid.Value, sourceDatabase, destinationDatabase, pfnStatus, IntPtr.Zero, (uint)grbit)) : Err(NativeMethods.JetCompactW(sesid.Value, sourceDatabase, destinationDatabase, pfnStatus, IntPtr.Zero, (uint)grbit)));
		statusCallbackWrapper.ThrowSavedException();
		return result;
	}

	public int JetGrowDatabase(JET_SESID sesid, JET_DBID dbid, int desiredPages, out int actualPages)
	{
		CheckNotNegative(desiredPages, "desiredPages");
		uint pcpgReal = 0u;
		checked
		{
			int result = Err(NativeMethods.JetGrowDatabase(sesid.Value, dbid.Value, (uint)desiredPages, out pcpgReal));
			actualPages = (int)pcpgReal;
			return result;
		}
	}

	public int JetSetDatabaseSize(JET_SESID sesid, string database, int desiredPages, out int actualPages)
	{
		CheckNotNegative(desiredPages, "desiredPages");
		CheckNotNull(database, "database");
		uint pcpgReal = 0u;
		checked
		{
			int result = ((!Capabilities.SupportsUnicodePaths) ? Err(NativeMethods.JetSetDatabaseSize(sesid.Value, database, (uint)desiredPages, out pcpgReal)) : Err(NativeMethods.JetSetDatabaseSizeW(sesid.Value, database, (uint)desiredPages, out pcpgReal)));
			actualPages = (int)pcpgReal;
			return result;
		}
	}

	public int JetGetDatabaseInfo(JET_SESID sesid, JET_DBID dbid, out int value, JET_DbInfo infoLevel)
	{
		return Err(NativeMethods.JetGetDatabaseInfo(sesid.Value, dbid.Value, out value, 4u, checked((uint)infoLevel)));
	}

	public int JetGetDatabaseInfo(JET_SESID sesid, JET_DBID dbid, out JET_DBINFOMISC dbinfomisc, JET_DbInfo infoLevel)
	{
		int num = 0;
		dbinfomisc = null;
		checked
		{
			if (0 == 0)
			{
				if (Capabilities.SupportsWindows7Features)
				{
					num = Err(NativeMethods.JetGetDatabaseInfoW(sesid.Value, dbid.Value, out NATIVE_DBINFOMISC4 dbinfomisc2, (uint)Marshal.SizeOf(typeof(NATIVE_DBINFOMISC4)), (uint)infoLevel));
					dbinfomisc = new JET_DBINFOMISC();
					dbinfomisc.SetFromNativeDbinfoMisc(ref dbinfomisc2);
				}
				else if (Capabilities.SupportsVistaFeatures)
				{
					num = Err(NativeMethods.JetGetDatabaseInfoW(sesid.Value, dbid.Value, out NATIVE_DBINFOMISC dbinfomisc3, (uint)Marshal.SizeOf(typeof(NATIVE_DBINFOMISC)), (uint)infoLevel));
					dbinfomisc = new JET_DBINFOMISC();
					dbinfomisc.SetFromNativeDbinfoMisc(ref dbinfomisc3);
				}
				else
				{
					num = Err(NativeMethods.JetGetDatabaseInfo(sesid.Value, dbid.Value, out NATIVE_DBINFOMISC dbinfomisc4, (uint)Marshal.SizeOf(typeof(NATIVE_DBINFOMISC)), (uint)infoLevel));
					dbinfomisc = new JET_DBINFOMISC();
					dbinfomisc.SetFromNativeDbinfoMisc(ref dbinfomisc4);
				}
			}
			return num;
		}
	}

	public int JetGetDatabaseInfo(JET_SESID sesid, JET_DBID dbid, out string value, JET_DbInfo infoLevel)
	{
		StringBuilder stringBuilder = new StringBuilder(1024);
		int result = checked((!Capabilities.SupportsUnicodePaths) ? Err(NativeMethods.JetGetDatabaseInfo(sesid.Value, dbid.Value, stringBuilder, 1024u, (uint)infoLevel)) : Err(NativeMethods.JetGetDatabaseInfoW(sesid.Value, dbid.Value, stringBuilder, 1024u, (uint)infoLevel)));
		value = stringBuilder.ToString();
		return result;
	}

	public int JetGetDatabaseFileInfo(string databaseName, out int value, JET_DbInfo infoLevel)
	{
		checked
		{
			if (Capabilities.SupportsUnicodePaths)
			{
				return Err(NativeMethods.JetGetDatabaseFileInfoW(databaseName, out value, 4u, (uint)infoLevel));
			}
			return Err(NativeMethods.JetGetDatabaseFileInfo(databaseName, out value, 4u, (uint)infoLevel));
		}
	}

	public int JetGetDatabaseFileInfo(string databaseName, out long value, JET_DbInfo infoLevel)
	{
		checked
		{
			if (Capabilities.SupportsUnicodePaths)
			{
				return Err(NativeMethods.JetGetDatabaseFileInfoW(databaseName, out value, 8u, (uint)infoLevel));
			}
			return Err(NativeMethods.JetGetDatabaseFileInfo(databaseName, out value, 8u, (uint)infoLevel));
		}
	}

	public int JetGetDatabaseFileInfo(string databaseName, out JET_DBINFOMISC dbinfomisc, JET_DbInfo infoLevel)
	{
		int num = 0;
		dbinfomisc = null;
		checked
		{
			if (0 == 0)
			{
				if (Capabilities.SupportsWindows7Features)
				{
					num = Err(NativeMethods.JetGetDatabaseFileInfoW(databaseName, out NATIVE_DBINFOMISC4 dbinfomisc2, (uint)Marshal.SizeOf(typeof(NATIVE_DBINFOMISC4)), (uint)infoLevel));
					dbinfomisc = new JET_DBINFOMISC();
					dbinfomisc.SetFromNativeDbinfoMisc(ref dbinfomisc2);
				}
				else
				{
					num = ((!Capabilities.SupportsUnicodePaths) ? Err(NativeMethods.JetGetDatabaseFileInfo(databaseName, out NATIVE_DBINFOMISC dbinfomisc3, (uint)Marshal.SizeOf(typeof(NATIVE_DBINFOMISC)), (uint)infoLevel)) : Err(NativeMethods.JetGetDatabaseFileInfoW(databaseName, out dbinfomisc3, (uint)Marshal.SizeOf(typeof(NATIVE_DBINFOMISC)), (uint)infoLevel)));
					dbinfomisc = new JET_DBINFOMISC();
					dbinfomisc.SetFromNativeDbinfoMisc(ref dbinfomisc3);
				}
			}
			return num;
		}
	}

	public int JetBackupInstance(JET_INSTANCE instance, string destination, BackupGrbit grbit, JET_PFNSTATUS statusCallback)
	{
		StatusCallbackWrapper statusCallbackWrapper = new StatusCallbackWrapper(statusCallback);
		IntPtr pfnStatus = ((statusCallback == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(statusCallbackWrapper.NativeCallback));
		int result = checked((!Capabilities.SupportsUnicodePaths) ? Err(NativeMethods.JetBackupInstance(instance.Value, destination, (uint)grbit, pfnStatus)) : Err(NativeMethods.JetBackupInstanceW(instance.Value, destination, (uint)grbit, pfnStatus)));
		statusCallbackWrapper.ThrowSavedException();
		return result;
	}

	public int JetRestoreInstance(JET_INSTANCE instance, string source, string destination, JET_PFNSTATUS statusCallback)
	{
		CheckNotNull(source, "source");
		StatusCallbackWrapper statusCallbackWrapper = new StatusCallbackWrapper(statusCallback);
		IntPtr pfn = ((statusCallback == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(statusCallbackWrapper.NativeCallback));
		int result = ((!Capabilities.SupportsUnicodePaths) ? Err(NativeMethods.JetRestoreInstance(instance.Value, source, destination, pfn)) : Err(NativeMethods.JetRestoreInstanceW(instance.Value, source, destination, pfn)));
		statusCallbackWrapper.ThrowSavedException();
		return result;
	}

	public int JetOSSnapshotPrepare(out JET_OSSNAPID snapid, SnapshotPrepareGrbit grbit)
	{
		snapid = JET_OSSNAPID.Nil;
		return Err(NativeMethods.JetOSSnapshotPrepare(out snapid.Value, checked((uint)grbit)));
	}

	public int JetOSSnapshotPrepareInstance(JET_OSSNAPID snapshot, JET_INSTANCE instance, SnapshotPrepareInstanceGrbit grbit)
	{
		CheckSupportsVistaFeatures("JetOSSnapshotPrepareInstance");
		return Err(NativeMethods.JetOSSnapshotPrepareInstance(snapshot.Value, instance.Value, checked((uint)grbit)));
	}

	public unsafe int JetOSSnapshotFreeze(JET_OSSNAPID snapshot, out int numInstances, out JET_INSTANCE_INFO[] instances, SnapshotFreezeGrbit grbit)
	{
		uint pcInstanceInfo = 0u;
		NATIVE_INSTANCE_INFO* prgInstanceInfo = null;
		checked
		{
			int err;
			if (Capabilities.SupportsUnicodePaths)
			{
				err = NativeMethods.JetOSSnapshotFreezeW(snapshot.Value, out pcInstanceInfo, out prgInstanceInfo, (uint)grbit);
				instances = ConvertInstanceInfosUnicode(pcInstanceInfo, prgInstanceInfo);
			}
			else
			{
				err = NativeMethods.JetOSSnapshotFreeze(snapshot.Value, out pcInstanceInfo, out prgInstanceInfo, (uint)grbit);
				instances = ConvertInstanceInfosAscii(pcInstanceInfo, prgInstanceInfo);
			}
			numInstances = instances.Length;
			return Err(err);
		}
	}

	public unsafe int JetOSSnapshotGetFreezeInfo(JET_OSSNAPID snapshot, out int numInstances, out JET_INSTANCE_INFO[] instances, SnapshotGetFreezeInfoGrbit grbit)
	{
		CheckSupportsVistaFeatures("JetOSSnapshotGetFreezeInfo");
		uint pcInstanceInfo = 0u;
		NATIVE_INSTANCE_INFO* prgInstanceInfo = null;
		int err = NativeMethods.JetOSSnapshotGetFreezeInfoW(snapshot.Value, out pcInstanceInfo, out prgInstanceInfo, checked((uint)grbit));
		instances = ConvertInstanceInfosUnicode(pcInstanceInfo, prgInstanceInfo);
		numInstances = instances.Length;
		return Err(err);
	}

	public int JetOSSnapshotThaw(JET_OSSNAPID snapid, SnapshotThawGrbit grbit)
	{
		return Err(NativeMethods.JetOSSnapshotThaw(snapid.Value, checked((uint)grbit)));
	}

	public int JetOSSnapshotTruncateLog(JET_OSSNAPID snapshot, SnapshotTruncateLogGrbit grbit)
	{
		CheckSupportsVistaFeatures("JetOSSnapshotTruncateLog");
		return Err(NativeMethods.JetOSSnapshotTruncateLog(snapshot.Value, checked((uint)grbit)));
	}

	public int JetOSSnapshotTruncateLogInstance(JET_OSSNAPID snapshot, JET_INSTANCE instance, SnapshotTruncateLogGrbit grbit)
	{
		CheckSupportsVistaFeatures("JetOSSnapshotTruncateLogInstance");
		return Err(NativeMethods.JetOSSnapshotTruncateLogInstance(snapshot.Value, instance.Value, checked((uint)grbit)));
	}

	public int JetOSSnapshotEnd(JET_OSSNAPID snapid, SnapshotEndGrbit grbit)
	{
		CheckSupportsVistaFeatures("JetOSSnapshotEnd");
		return Err(NativeMethods.JetOSSnapshotEnd(snapid.Value, checked((uint)grbit)));
	}

	public int JetOSSnapshotAbort(JET_OSSNAPID snapid, SnapshotAbortGrbit grbit)
	{
		CheckSupportsServer2003Features("JetOSSnapshotAbort");
		return Err(NativeMethods.JetOSSnapshotAbort(snapid.Value, checked((uint)grbit)));
	}

	public int JetBeginExternalBackupInstance(JET_INSTANCE instance, BeginExternalBackupGrbit grbit)
	{
		return Err(NativeMethods.JetBeginExternalBackupInstance(instance.Value, checked((uint)grbit)));
	}

	public int JetCloseFileInstance(JET_INSTANCE instance, JET_HANDLE handle)
	{
		return Err(NativeMethods.JetCloseFileInstance(instance.Value, handle.Value));
	}

	public int JetEndExternalBackupInstance(JET_INSTANCE instance)
	{
		return Err(NativeMethods.JetEndExternalBackupInstance(instance.Value));
	}

	public int JetEndExternalBackupInstance2(JET_INSTANCE instance, EndExternalBackupGrbit grbit)
	{
		return Err(NativeMethods.JetEndExternalBackupInstance2(instance.Value, checked((uint)grbit)));
	}

	public int JetGetAttachInfoInstance(JET_INSTANCE instance, out string files, int maxChars, out int actualChars)
	{
		CheckNotNegative(maxChars, "maxChars");
		checked
		{
			int result;
			if (Capabilities.SupportsUnicodePaths)
			{
				uint num = (uint)maxChars * 2;
				byte[] array = new byte[num];
				uint pcbActual = 0u;
				result = Err(NativeMethods.JetGetAttachInfoInstanceW(instance.Value, array, num, out pcbActual));
				unchecked
				{
					actualChars = checked((int)pcbActual) / 2;
				}
				files = Encoding.Unicode.GetString(array, 0, Math.Min(array.Length, (int)pcbActual));
			}
			else
			{
				uint num2 = (uint)maxChars;
				byte[] array2 = new byte[num2];
				uint pcbActual2 = 0u;
				result = Err(NativeMethods.JetGetAttachInfoInstance(instance.Value, array2, num2, out pcbActual2));
				actualChars = (int)pcbActual2;
				files = LibraryHelpers.EncodingASCII.GetString(array2, 0, Math.Min(array2.Length, (int)pcbActual2));
			}
			return result;
		}
	}

	public int JetGetLogInfoInstance(JET_INSTANCE instance, out string files, int maxChars, out int actualChars)
	{
		CheckNotNegative(maxChars, "maxChars");
		checked
		{
			int result;
			if (Capabilities.SupportsUnicodePaths)
			{
				uint num = (uint)maxChars * 2;
				byte[] array = new byte[num];
				uint pcbActual = 0u;
				result = Err(NativeMethods.JetGetLogInfoInstanceW(instance.Value, array, num, out pcbActual));
				unchecked
				{
					actualChars = checked((int)pcbActual) / 2;
				}
				files = Encoding.Unicode.GetString(array, 0, Math.Min(array.Length, (int)pcbActual));
			}
			else
			{
				uint num2 = (uint)maxChars;
				byte[] array2 = new byte[num2];
				uint pcbActual2 = 0u;
				result = Err(NativeMethods.JetGetLogInfoInstance(instance.Value, array2, num2, out pcbActual2));
				actualChars = (int)pcbActual2;
				files = LibraryHelpers.EncodingASCII.GetString(array2, 0, Math.Min(array2.Length, (int)pcbActual2));
			}
			return result;
		}
	}

	public int JetGetTruncateLogInfoInstance(JET_INSTANCE instance, out string files, int maxChars, out int actualChars)
	{
		CheckNotNegative(maxChars, "maxChars");
		checked
		{
			int result;
			if (Capabilities.SupportsUnicodePaths)
			{
				uint num = (uint)maxChars * 2;
				byte[] array = new byte[num];
				uint pcbActual = 0u;
				result = Err(NativeMethods.JetGetTruncateLogInfoInstanceW(instance.Value, array, num, out pcbActual));
				unchecked
				{
					actualChars = checked((int)pcbActual) / 2;
				}
				files = Encoding.Unicode.GetString(array, 0, Math.Min(array.Length, (int)pcbActual));
			}
			else
			{
				uint num2 = (uint)maxChars;
				byte[] array2 = new byte[num2];
				uint pcbActual2 = 0u;
				result = Err(NativeMethods.JetGetTruncateLogInfoInstance(instance.Value, array2, num2, out pcbActual2));
				actualChars = (int)pcbActual2;
				files = LibraryHelpers.EncodingASCII.GetString(array2, 0, Math.Min(array2.Length, (int)pcbActual2));
			}
			return result;
		}
	}

	public int JetOpenFileInstance(JET_INSTANCE instance, string file, out JET_HANDLE handle, out long fileSizeLow, out long fileSizeHigh)
	{
		CheckNotNull(file, "file");
		handle = JET_HANDLE.Nil;
		uint pulFileSizeLow;
		uint pulFileSizeHigh;
		int result = ((!Capabilities.SupportsUnicodePaths) ? Err(NativeMethods.JetOpenFileInstance(instance.Value, file, out handle.Value, out pulFileSizeLow, out pulFileSizeHigh)) : Err(NativeMethods.JetOpenFileInstanceW(instance.Value, file, out handle.Value, out pulFileSizeLow, out pulFileSizeHigh)));
		fileSizeLow = pulFileSizeLow;
		fileSizeHigh = pulFileSizeHigh;
		return result;
	}

	public int JetReadFileInstance(JET_INSTANCE instance, JET_HANDLE file, byte[] buffer, int bufferSize, out int bytesRead)
	{
		CheckNotNull(buffer, "buffer");
		CheckDataSize(buffer, bufferSize, "bufferSize");
		checked
		{
			IntPtr intPtr = Microsoft.Isam.Esent.Interop.Win32.NativeMethods.VirtualAlloc(IntPtr.Zero, (UIntPtr)(ulong)bufferSize, 12288u, 4u);
			Microsoft.Isam.Esent.Interop.Win32.NativeMethods.ThrowExceptionOnNull(intPtr, "VirtualAlloc");
			try
			{
				uint pcbActual = 0u;
				int result = Err(NativeMethods.JetReadFileInstance(instance.Value, file.Value, intPtr, (uint)bufferSize, out pcbActual));
				bytesRead = (int)pcbActual;
				Marshal.Copy(intPtr, buffer, 0, bytesRead);
				return result;
			}
			finally
			{
				Microsoft.Isam.Esent.Interop.Win32.NativeMethods.ThrowExceptionOnFailure(Microsoft.Isam.Esent.Interop.Win32.NativeMethods.VirtualFree(intPtr, UIntPtr.Zero, 32768u), "VirtualFree");
			}
		}
	}

	public int JetTruncateLogInstance(JET_INSTANCE instance)
	{
		return Err(NativeMethods.JetTruncateLogInstance(instance.Value));
	}

	public int JetBeginSession(JET_INSTANCE instance, out JET_SESID sesid, string username, string password)
	{
		sesid = JET_SESID.Nil;
		return Err(NativeMethods.JetBeginSession(instance.Value, out sesid.Value, username, password));
	}

	public int JetSetSessionContext(JET_SESID sesid, IntPtr context)
	{
		return Err(NativeMethods.JetSetSessionContext(sesid.Value, context));
	}

	public int JetResetSessionContext(JET_SESID sesid)
	{
		return Err(NativeMethods.JetResetSessionContext(sesid.Value));
	}

	public int JetEndSession(JET_SESID sesid, EndSessionGrbit grbit)
	{
		return Err(NativeMethods.JetEndSession(sesid.Value, checked((uint)grbit)));
	}

	public int JetDupSession(JET_SESID sesid, out JET_SESID newSesid)
	{
		newSesid = JET_SESID.Nil;
		return Err(NativeMethods.JetDupSession(sesid.Value, out newSesid.Value));
	}

	public unsafe int JetGetThreadStats(out JET_THREADSTATS threadstats)
	{
		CheckSupportsVistaFeatures("JetGetThreadStats");
		fixed (JET_THREADSTATS* pvResult = &threadstats)
		{
			return Err(NativeMethods.JetGetThreadStats(pvResult, checked((uint)JET_THREADSTATS.Size)));
		}
	}

	public int JetOpenTable(JET_SESID sesid, JET_DBID dbid, string tablename, byte[] parameters, int parametersLength, OpenTableGrbit grbit, out JET_TABLEID tableid)
	{
		tableid = JET_TABLEID.Nil;
		CheckNotNull(tablename, "tablename");
		CheckDataSize(parameters, parametersLength, "parametersLength");
		return Err(checked(NativeMethods.JetOpenTable(sesid.Value, dbid.Value, tablename, parameters, (uint)parametersLength, (uint)grbit, out tableid.Value)));
	}

	public int JetCloseTable(JET_SESID sesid, JET_TABLEID tableid)
	{
		return Err(NativeMethods.JetCloseTable(sesid.Value, tableid.Value));
	}

	public int JetDupCursor(JET_SESID sesid, JET_TABLEID tableid, out JET_TABLEID newTableid, DupCursorGrbit grbit)
	{
		newTableid = JET_TABLEID.Nil;
		return Err(NativeMethods.JetDupCursor(sesid.Value, tableid.Value, out newTableid.Value, checked((uint)grbit)));
	}

	public int JetComputeStats(JET_SESID sesid, JET_TABLEID tableid)
	{
		return Err(NativeMethods.JetComputeStats(sesid.Value, tableid.Value));
	}

	public int JetSetLS(JET_SESID sesid, JET_TABLEID tableid, JET_LS ls, LsGrbit grbit)
	{
		return Err(NativeMethods.JetSetLS(sesid.Value, tableid.Value, ls.Value, checked((uint)grbit)));
	}

	public int JetGetLS(JET_SESID sesid, JET_TABLEID tableid, out JET_LS ls, LsGrbit grbit)
	{
		IntPtr pls;
		int err = NativeMethods.JetGetLS(sesid.Value, tableid.Value, out pls, checked((uint)grbit));
		ls = new JET_LS
		{
			Value = pls
		};
		return Err(err);
	}

	public int JetGetCursorInfo(JET_SESID sesid, JET_TABLEID tableid)
	{
		return Err(NativeMethods.JetGetCursorInfo(sesid.Value, tableid.Value, IntPtr.Zero, 0u, 0u));
	}

	public int JetBeginTransaction(JET_SESID sesid)
	{
		return Err(NativeMethods.JetBeginTransaction(sesid.Value));
	}

	public int JetBeginTransaction2(JET_SESID sesid, BeginTransactionGrbit grbit)
	{
		return Err(NativeMethods.JetBeginTransaction2(sesid.Value, (uint)grbit));
	}

	public int JetCommitTransaction(JET_SESID sesid, CommitTransactionGrbit grbit)
	{
		return Err(NativeMethods.JetCommitTransaction(sesid.Value, (uint)grbit));
	}

	public int JetRollback(JET_SESID sesid, RollbackTransactionGrbit grbit)
	{
		return Err(NativeMethods.JetRollback(sesid.Value, (uint)grbit));
	}

	public int JetCreateTable(JET_SESID sesid, JET_DBID dbid, string table, int pages, int density, out JET_TABLEID tableid)
	{
		tableid = JET_TABLEID.Nil;
		CheckNotNull(table, "table");
		return Err(NativeMethods.JetCreateTable(sesid.Value, dbid.Value, table, pages, density, out tableid.Value));
	}

	public int JetDeleteTable(JET_SESID sesid, JET_DBID dbid, string table)
	{
		CheckNotNull(table, "table");
		return Err(NativeMethods.JetDeleteTable(sesid.Value, dbid.Value, table));
	}

	public int JetAddColumn(JET_SESID sesid, JET_TABLEID tableid, string column, JET_COLUMNDEF columndef, byte[] defaultValue, int defaultValueSize, out JET_COLUMNID columnid)
	{
		columnid = JET_COLUMNID.Nil;
		CheckNotNull(column, "column");
		CheckNotNull(columndef, "columndef");
		CheckDataSize(defaultValue, defaultValueSize, "defaultValueSize");
		NATIVE_COLUMNDEF columndef2 = columndef.GetNativeColumndef();
		int result = Err(NativeMethods.JetAddColumn(sesid.Value, tableid.Value, column, ref columndef2, defaultValue, checked((uint)defaultValueSize), out columnid.Value));
		columndef.columnid = new JET_COLUMNID
		{
			Value = columnid.Value
		};
		return result;
	}

	public int JetDeleteColumn(JET_SESID sesid, JET_TABLEID tableid, string column)
	{
		CheckNotNull(column, "column");
		return Err(NativeMethods.JetDeleteColumn(sesid.Value, tableid.Value, column));
	}

	public int JetDeleteColumn2(JET_SESID sesid, JET_TABLEID tableid, string column, DeleteColumnGrbit grbit)
	{
		CheckNotNull(column, "column");
		return Err(NativeMethods.JetDeleteColumn2(sesid.Value, tableid.Value, column, checked((uint)grbit)));
	}

	public int JetCreateIndex(JET_SESID sesid, JET_TABLEID tableid, string indexName, CreateIndexGrbit grbit, string keyDescription, int keyDescriptionLength, int density)
	{
		CheckNotNull(indexName, "indexName");
		CheckNotNegative(keyDescriptionLength, "keyDescriptionLength");
		CheckNotNegative(density, "density");
		checked
		{
			if (keyDescriptionLength > keyDescription.Length + 1)
			{
				throw new ArgumentOutOfRangeException("keyDescriptionLength", keyDescriptionLength, "cannot be greater than keyDescription.Length");
			}
			return Err(NativeMethods.JetCreateIndex(sesid.Value, tableid.Value, indexName, (uint)grbit, keyDescription, (uint)keyDescriptionLength, (uint)density));
		}
	}

	public int JetCreateIndex2(JET_SESID sesid, JET_TABLEID tableid, JET_INDEXCREATE[] indexcreates, int numIndexCreates)
	{
		CheckNotNull(indexcreates, "indexcreates");
		CheckNotNegative(numIndexCreates, "numIndexCreates");
		if (numIndexCreates > indexcreates.Length)
		{
			throw new ArgumentOutOfRangeException("numIndexCreates", numIndexCreates, "numIndexCreates is larger than the number of indexes passed in");
		}
		if (Capabilities.SupportsWindows7Features)
		{
			return CreateIndexes2(sesid, tableid, indexcreates, numIndexCreates);
		}
		if (Capabilities.SupportsVistaFeatures)
		{
			return CreateIndexes1(sesid, tableid, indexcreates, numIndexCreates);
		}
		return CreateIndexes(sesid, tableid, indexcreates, numIndexCreates);
	}

	public int JetDeleteIndex(JET_SESID sesid, JET_TABLEID tableid, string index)
	{
		CheckNotNull(index, "index");
		return Err(NativeMethods.JetDeleteIndex(sesid.Value, tableid.Value, index));
	}

	public int JetOpenTempTable(JET_SESID sesid, JET_COLUMNDEF[] columns, int numColumns, TempTableGrbit grbit, out JET_TABLEID tableid, JET_COLUMNID[] columnids)
	{
		CheckNotNull(columns, "columnns");
		CheckDataSize(columns, numColumns, "numColumns");
		CheckNotNull(columnids, "columnids");
		CheckDataSize(columnids, numColumns, "numColumns");
		tableid = JET_TABLEID.Nil;
		NATIVE_COLUMNDEF[] nativecolumndefs = GetNativecolumndefs(columns, numColumns);
		uint[] array = new uint[numColumns];
		int result = Err(checked(NativeMethods.JetOpenTempTable(sesid.Value, nativecolumndefs, (uint)numColumns, (uint)grbit, out tableid.Value, array)));
		SetColumnids(columns, columnids, array, numColumns);
		return result;
	}

	public int JetOpenTempTable2(JET_SESID sesid, JET_COLUMNDEF[] columns, int numColumns, int lcid, TempTableGrbit grbit, out JET_TABLEID tableid, JET_COLUMNID[] columnids)
	{
		CheckNotNull(columns, "columnns");
		CheckDataSize(columns, numColumns, "numColumns");
		CheckNotNull(columnids, "columnids");
		CheckDataSize(columnids, numColumns, "numColumns");
		tableid = JET_TABLEID.Nil;
		NATIVE_COLUMNDEF[] nativecolumndefs = GetNativecolumndefs(columns, numColumns);
		uint[] array = new uint[numColumns];
		int result = Err(checked(NativeMethods.JetOpenTempTable2(sesid.Value, nativecolumndefs, (uint)numColumns, (uint)lcid, (uint)grbit, out tableid.Value, array)));
		SetColumnids(columns, columnids, array, numColumns);
		return result;
	}

	public int JetOpenTempTable3(JET_SESID sesid, JET_COLUMNDEF[] columns, int numColumns, JET_UNICODEINDEX unicodeindex, TempTableGrbit grbit, out JET_TABLEID tableid, JET_COLUMNID[] columnids)
	{
		CheckNotNull(columns, "columnns");
		CheckDataSize(columns, numColumns, "numColumns");
		CheckNotNull(columnids, "columnids");
		CheckDataSize(columnids, numColumns, "numColumns");
		tableid = JET_TABLEID.Nil;
		NATIVE_COLUMNDEF[] nativecolumndefs = GetNativecolumndefs(columns, numColumns);
		uint[] array = new uint[numColumns];
		checked
		{
			int result;
			if (unicodeindex != null)
			{
				NATIVE_UNICODEINDEX pidxunicode = unicodeindex.GetNativeUnicodeIndex();
				result = Err(NativeMethods.JetOpenTempTable3(sesid.Value, nativecolumndefs, (uint)numColumns, ref pidxunicode, (uint)grbit, out tableid.Value, array));
			}
			else
			{
				result = Err(NativeMethods.JetOpenTempTable3(sesid.Value, nativecolumndefs, (uint)numColumns, IntPtr.Zero, (uint)grbit, out tableid.Value, array));
			}
			SetColumnids(columns, columnids, array, numColumns);
			return result;
		}
	}

	public unsafe int JetOpenTemporaryTable(JET_SESID sesid, JET_OPENTEMPORARYTABLE temporarytable)
	{
		CheckSupportsVistaFeatures("JetOpenTemporaryTable");
		CheckNotNull(temporarytable, "temporarytable");
		NATIVE_OPENTEMPORARYTABLE popentemporarytable = temporarytable.GetNativeOpenTemporaryTable();
		uint[] array = new uint[popentemporarytable.ccolumn];
		NATIVE_COLUMNDEF[] nativecolumndefs = GetNativecolumndefs(temporarytable.prgcolumndef, temporarytable.ccolumn);
		using GCHandleCollection gCHandleCollection = default(GCHandleCollection);
		popentemporarytable.prgcolumndef = (NATIVE_COLUMNDEF*)(void*)gCHandleCollection.Add(nativecolumndefs);
		popentemporarytable.rgcolumnid = (uint*)(void*)gCHandleCollection.Add(array);
		if (temporarytable.pidxunicode != null)
		{
			popentemporarytable.pidxunicode = (NATIVE_UNICODEINDEX*)(void*)gCHandleCollection.Add(temporarytable.pidxunicode.GetNativeUnicodeIndex());
		}
		int result = Err(NativeMethods.JetOpenTemporaryTable(sesid.Value, ref popentemporarytable));
		SetColumnids(temporarytable.prgcolumndef, temporarytable.prgcolumnid, array, temporarytable.ccolumn);
		temporarytable.tableid = new JET_TABLEID
		{
			Value = popentemporarytable.tableid
		};
		return result;
	}

	public int JetCreateTableColumnIndex3(JET_SESID sesid, JET_DBID dbid, JET_TABLECREATE tablecreate)
	{
		CheckNotNull(tablecreate, "tablecreate");
		if (Capabilities.SupportsWindows7Features)
		{
			return CreateTableColumnIndex3(sesid, dbid, tablecreate);
		}
		return CreateTableColumnIndex2(sesid, dbid, tablecreate);
	}

	public int JetGetTableColumnInfo(JET_SESID sesid, JET_TABLEID tableid, string columnName, out JET_COLUMNDEF columndef)
	{
		columndef = new JET_COLUMNDEF();
		CheckNotNull(columnName, "columnName");
		NATIVE_COLUMNDEF columndef2 = new NATIVE_COLUMNDEF
		{
			cbStruct = checked((uint)Marshal.SizeOf(typeof(NATIVE_COLUMNDEF)))
		};
		int result = ((!Capabilities.SupportsVistaFeatures) ? Err(NativeMethods.JetGetTableColumnInfo(sesid.Value, tableid.Value, columnName, ref columndef2, columndef2.cbStruct, 0u)) : Err(NativeMethods.JetGetTableColumnInfoW(sesid.Value, tableid.Value, columnName, ref columndef2, columndef2.cbStruct, 0u)));
		columndef.SetFromNativeColumndef(columndef2);
		return result;
	}

	public int JetGetTableColumnInfo(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, out JET_COLUMNDEF columndef)
	{
		columndef = new JET_COLUMNDEF();
		NATIVE_COLUMNDEF columndef2 = new NATIVE_COLUMNDEF
		{
			cbStruct = checked((uint)Marshal.SizeOf(typeof(NATIVE_COLUMNDEF)))
		};
		int result = ((!Capabilities.SupportsVistaFeatures) ? Err(NativeMethods.JetGetTableColumnInfo(sesid.Value, tableid.Value, ref columnid.Value, ref columndef2, columndef2.cbStruct, 6u)) : Err(NativeMethods.JetGetTableColumnInfoW(sesid.Value, tableid.Value, ref columnid.Value, ref columndef2, columndef2.cbStruct, 6u)));
		columndef.SetFromNativeColumndef(columndef2);
		return result;
	}

	public int JetGetTableColumnInfo(JET_SESID sesid, JET_TABLEID tableid, string columnName, out JET_COLUMNBASE columnbase)
	{
		CheckNotNull(columnName, "columnName");
		checked
		{
			int result;
			if (Capabilities.SupportsVistaFeatures)
			{
				NATIVE_COLUMNBASE_WIDE columnbase2 = new NATIVE_COLUMNBASE_WIDE
				{
					cbStruct = (uint)Marshal.SizeOf(typeof(NATIVE_COLUMNBASE_WIDE))
				};
				result = Err(NativeMethods.JetGetTableColumnInfoW(sesid.Value, tableid.Value, columnName, ref columnbase2, columnbase2.cbStruct, 4u));
				columnbase = new JET_COLUMNBASE(columnbase2);
			}
			else
			{
				NATIVE_COLUMNBASE columnbase3 = new NATIVE_COLUMNBASE
				{
					cbStruct = (uint)Marshal.SizeOf(typeof(NATIVE_COLUMNBASE))
				};
				result = Err(NativeMethods.JetGetTableColumnInfo(sesid.Value, tableid.Value, columnName, ref columnbase3, columnbase3.cbStruct, 4u));
				columnbase = new JET_COLUMNBASE(columnbase3);
			}
			return result;
		}
	}

	public int JetGetTableColumnInfo(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, out JET_COLUMNBASE columnbase)
	{
		CheckSupportsVistaFeatures("JetGetTableColumnInfo");
		NATIVE_COLUMNBASE_WIDE columnbase2 = new NATIVE_COLUMNBASE_WIDE
		{
			cbStruct = checked((uint)Marshal.SizeOf(typeof(NATIVE_COLUMNBASE_WIDE)))
		};
		int result = Err(NativeMethods.JetGetTableColumnInfoW(sesid.Value, tableid.Value, ref columnid.Value, ref columnbase2, columnbase2.cbStruct, 8u));
		columnbase = new JET_COLUMNBASE(columnbase2);
		return result;
	}

	public int JetGetTableColumnInfo(JET_SESID sesid, JET_TABLEID tableid, string ignored, ColInfoGrbit grbit, out JET_COLUMNLIST columnlist)
	{
		columnlist = new JET_COLUMNLIST();
		checked
		{
			NATIVE_COLUMNLIST columnlist2 = new NATIVE_COLUMNLIST
			{
				cbStruct = (uint)Marshal.SizeOf(typeof(NATIVE_COLUMNLIST))
			};
			int result = ((!Capabilities.SupportsWindows8Features) ? Err(NativeMethods.JetGetTableColumnInfo(sesid.Value, tableid.Value, ignored, ref columnlist2, columnlist2.cbStruct, (uint)grbit | 1)) : Err(NativeMethods.JetGetTableColumnInfoW(sesid.Value, tableid.Value, ignored, ref columnlist2, columnlist2.cbStruct, (uint)grbit | 1)));
			columnlist.SetFromNativeColumnlist(columnlist2);
			return result;
		}
	}

	public int JetGetColumnInfo(JET_SESID sesid, JET_DBID dbid, string tablename, string columnName, out JET_COLUMNDEF columndef)
	{
		columndef = new JET_COLUMNDEF();
		CheckNotNull(tablename, "tablename");
		CheckNotNull(columnName, "columnName");
		NATIVE_COLUMNDEF columndef2 = new NATIVE_COLUMNDEF
		{
			cbStruct = checked((uint)Marshal.SizeOf(typeof(NATIVE_COLUMNDEF)))
		};
		int result = ((!Capabilities.SupportsWindows8Features) ? Err(NativeMethods.JetGetColumnInfo(sesid.Value, dbid.Value, tablename, columnName, ref columndef2, columndef2.cbStruct, 0u)) : Err(NativeMethods.JetGetColumnInfoW(sesid.Value, dbid.Value, tablename, columnName, ref columndef2, columndef2.cbStruct, 0u)));
		columndef.SetFromNativeColumndef(columndef2);
		return result;
	}

	public int JetGetColumnInfo(JET_SESID sesid, JET_DBID dbid, string tablename, string ignored, out JET_COLUMNLIST columnlist)
	{
		columnlist = new JET_COLUMNLIST();
		CheckNotNull(tablename, "tablename");
		NATIVE_COLUMNLIST columnlist2 = new NATIVE_COLUMNLIST
		{
			cbStruct = checked((uint)Marshal.SizeOf(typeof(NATIVE_COLUMNLIST)))
		};
		int result = ((!Capabilities.SupportsWindows8Features) ? Err(NativeMethods.JetGetColumnInfo(sesid.Value, dbid.Value, tablename, ignored, ref columnlist2, columnlist2.cbStruct, 1u)) : Err(NativeMethods.JetGetColumnInfoW(sesid.Value, dbid.Value, tablename, ignored, ref columnlist2, columnlist2.cbStruct, 1u)));
		columnlist.SetFromNativeColumnlist(columnlist2);
		return result;
	}

	public int JetGetColumnInfo(JET_SESID sesid, JET_DBID dbid, string tablename, string columnName, out JET_COLUMNBASE columnbase)
	{
		CheckNotNull(tablename, "tablename");
		CheckNotNull(columnName, "columnName");
		checked
		{
			int result;
			if (Capabilities.SupportsWindows8Features)
			{
				NATIVE_COLUMNBASE_WIDE columnbase2 = new NATIVE_COLUMNBASE_WIDE
				{
					cbStruct = (uint)Marshal.SizeOf(typeof(NATIVE_COLUMNBASE_WIDE))
				};
				result = Err(NativeMethods.JetGetColumnInfoW(sesid.Value, dbid.Value, tablename, columnName, ref columnbase2, columnbase2.cbStruct, 4u));
				columnbase = new JET_COLUMNBASE(columnbase2);
			}
			else
			{
				NATIVE_COLUMNBASE columnbase3 = new NATIVE_COLUMNBASE
				{
					cbStruct = (uint)Marshal.SizeOf(typeof(NATIVE_COLUMNBASE))
				};
				result = Err(NativeMethods.JetGetColumnInfo(sesid.Value, dbid.Value, tablename, columnName, ref columnbase3, columnbase3.cbStruct, 4u));
				columnbase = new JET_COLUMNBASE(columnbase3);
			}
			return result;
		}
	}

	public int JetGetColumnInfo(JET_SESID sesid, JET_DBID dbid, string tablename, JET_COLUMNID columnid, out JET_COLUMNBASE columnbase)
	{
		CheckSupportsVistaFeatures("JetGetColumnInfo");
		CheckNotNull(tablename, "tablename");
		checked
		{
			int result;
			if (Capabilities.SupportsWindows8Features)
			{
				NATIVE_COLUMNBASE_WIDE columnbase2 = new NATIVE_COLUMNBASE_WIDE
				{
					cbStruct = (uint)Marshal.SizeOf(typeof(NATIVE_COLUMNBASE_WIDE))
				};
				result = Err(NativeMethods.JetGetColumnInfoW(sesid.Value, dbid.Value, tablename, ref columnid.Value, ref columnbase2, columnbase2.cbStruct, 8u));
				columnbase = new JET_COLUMNBASE(columnbase2);
			}
			else
			{
				NATIVE_COLUMNBASE columnbase3 = new NATIVE_COLUMNBASE
				{
					cbStruct = (uint)Marshal.SizeOf(typeof(NATIVE_COLUMNBASE))
				};
				result = Err(NativeMethods.JetGetColumnInfo(sesid.Value, dbid.Value, tablename, ref columnid.Value, ref columnbase3, columnbase3.cbStruct, 8u));
				columnbase = new JET_COLUMNBASE(columnbase3);
			}
			return result;
		}
	}

	public int JetGetObjectInfo(JET_SESID sesid, JET_DBID dbid, out JET_OBJECTLIST objectlist)
	{
		objectlist = new JET_OBJECTLIST();
		NATIVE_OBJECTLIST objectlist2 = new NATIVE_OBJECTLIST
		{
			cbStruct = checked((uint)Marshal.SizeOf(typeof(NATIVE_OBJECTLIST)))
		};
		int result = ((!Capabilities.SupportsVistaFeatures) ? Err(NativeMethods.JetGetObjectInfo(sesid.Value, dbid.Value, 1u, null, null, ref objectlist2, objectlist2.cbStruct, 1u)) : Err(NativeMethods.JetGetObjectInfoW(sesid.Value, dbid.Value, 1u, null, null, ref objectlist2, objectlist2.cbStruct, 1u)));
		objectlist.SetFromNativeObjectlist(objectlist2);
		return result;
	}

	public int JetGetObjectInfo(JET_SESID sesid, JET_DBID dbid, JET_objtyp objtyp, string objectName, out JET_OBJECTINFO objectinfo)
	{
		objectinfo = new JET_OBJECTINFO();
		checked
		{
			NATIVE_OBJECTINFO value = new NATIVE_OBJECTINFO
			{
				cbStruct = (uint)Marshal.SizeOf(typeof(NATIVE_OBJECTINFO))
			};
			int result = ((!Capabilities.SupportsVistaFeatures) ? Err(NativeMethods.JetGetObjectInfo(sesid.Value, dbid.Value, (uint)objtyp, null, objectName, ref value, value.cbStruct, 5u)) : Err(NativeMethods.JetGetObjectInfoW(sesid.Value, dbid.Value, (uint)objtyp, null, objectName, ref value, value.cbStruct, 5u)));
			objectinfo.SetFromNativeObjectinfo(ref value);
			return result;
		}
	}

	public int JetGetCurrentIndex(JET_SESID sesid, JET_TABLEID tableid, out string indexName, int maxNameLength)
	{
		CheckNotNegative(maxNameLength, "maxNameLength");
		StringBuilder stringBuilder = new StringBuilder(maxNameLength);
		int result = Err(NativeMethods.JetGetCurrentIndex(sesid.Value, tableid.Value, stringBuilder, checked((uint)maxNameLength)));
		indexName = stringBuilder.ToString();
		indexName = StringCache.TryToIntern(indexName);
		return result;
	}

	public int JetGetTableInfo(JET_SESID sesid, JET_TABLEID tableid, out JET_OBJECTINFO result, JET_TblInfo infoLevel)
	{
		NATIVE_OBJECTINFO pvResult = default(NATIVE_OBJECTINFO);
		int result2 = checked((!Capabilities.SupportsVistaFeatures) ? Err(NativeMethods.JetGetTableInfo(sesid.Value, tableid.Value, out pvResult, (uint)Marshal.SizeOf(typeof(NATIVE_OBJECTINFO)), (uint)infoLevel)) : Err(NativeMethods.JetGetTableInfoW(sesid.Value, tableid.Value, out pvResult, (uint)Marshal.SizeOf(typeof(NATIVE_OBJECTINFO)), (uint)infoLevel)));
		result = new JET_OBJECTINFO();
		result.SetFromNativeObjectinfo(ref pvResult);
		return result2;
	}

	public int JetGetTableInfo(JET_SESID sesid, JET_TABLEID tableid, out string result, JET_TblInfo infoLevel)
	{
		StringBuilder stringBuilder = new StringBuilder(65);
		int result2 = checked((!Capabilities.SupportsVistaFeatures) ? Err(NativeMethods.JetGetTableInfo(sesid.Value, tableid.Value, stringBuilder, (uint)stringBuilder.Capacity, (uint)infoLevel)) : Err(NativeMethods.JetGetTableInfoW(sesid.Value, tableid.Value, stringBuilder, (uint)stringBuilder.Capacity * 2, (uint)infoLevel)));
		result = stringBuilder.ToString();
		result = StringCache.TryToIntern(result);
		return result2;
	}

	public int JetGetTableInfo(JET_SESID sesid, JET_TABLEID tableid, out JET_DBID result, JET_TblInfo infoLevel)
	{
		result = JET_DBID.Nil;
		checked
		{
			if (Capabilities.SupportsVistaFeatures)
			{
				return Err(NativeMethods.JetGetTableInfoW(sesid.Value, tableid.Value, out result.Value, 4u, (uint)infoLevel));
			}
			return Err(NativeMethods.JetGetTableInfo(sesid.Value, tableid.Value, out result.Value, 4u, (uint)infoLevel));
		}
	}

	public int JetGetTableInfo(JET_SESID sesid, JET_TABLEID tableid, int[] result, JET_TblInfo infoLevel)
	{
		CheckNotNull(result, "result");
		checked
		{
			uint cbMax = (uint)(result.Length * 4);
			if (Capabilities.SupportsVistaFeatures)
			{
				return Err(NativeMethods.JetGetTableInfoW(sesid.Value, tableid.Value, result, cbMax, (uint)infoLevel));
			}
			return Err(NativeMethods.JetGetTableInfo(sesid.Value, tableid.Value, result, cbMax, (uint)infoLevel));
		}
	}

	public int JetGetTableInfo(JET_SESID sesid, JET_TABLEID tableid, out int result, JET_TblInfo infoLevel)
	{
		uint pvResult;
		int result2 = checked((!Capabilities.SupportsVistaFeatures) ? Err(NativeMethods.JetGetTableInfo(sesid.Value, tableid.Value, out pvResult, 4u, (uint)infoLevel)) : Err(NativeMethods.JetGetTableInfoW(sesid.Value, tableid.Value, out pvResult, 4u, (uint)infoLevel)));
		result = (int)pvResult;
		return result2;
	}

	public int JetGetIndexInfo(JET_SESID sesid, JET_DBID dbid, string tablename, string indexname, out ushort result, JET_IdxInfo infoLevel)
	{
		CheckNotNull(tablename, "tablename");
		checked
		{
			if (Capabilities.SupportsVistaFeatures)
			{
				return Err(NativeMethods.JetGetIndexInfoW(sesid.Value, dbid.Value, tablename, indexname, out result, 2u, (uint)infoLevel));
			}
			return Err(NativeMethods.JetGetIndexInfo(sesid.Value, dbid.Value, tablename, indexname, out result, 2u, (uint)infoLevel));
		}
	}

	public int JetGetIndexInfo(JET_SESID sesid, JET_DBID dbid, string tablename, string indexname, out int result, JET_IdxInfo infoLevel)
	{
		CheckNotNull(tablename, "tablename");
		uint result3;
		int result2 = checked((!Capabilities.SupportsVistaFeatures) ? Err(NativeMethods.JetGetIndexInfo(sesid.Value, dbid.Value, tablename, indexname, out result3, 4u, (uint)infoLevel)) : Err(NativeMethods.JetGetIndexInfoW(sesid.Value, dbid.Value, tablename, indexname, out result3, 4u, (uint)infoLevel)));
		result = (int)result3;
		return result2;
	}

	public int JetGetIndexInfo(JET_SESID sesid, JET_DBID dbid, string tablename, string indexname, out JET_INDEXID result, JET_IdxInfo infoLevel)
	{
		CheckNotNull(tablename, "tablename");
		checked
		{
			if (Capabilities.SupportsVistaFeatures)
			{
				return Err(NativeMethods.JetGetIndexInfoW(sesid.Value, dbid.Value, tablename, indexname, out result, JET_INDEXID.SizeOfIndexId, (uint)infoLevel));
			}
			return Err(NativeMethods.JetGetIndexInfo(sesid.Value, dbid.Value, tablename, indexname, out result, JET_INDEXID.SizeOfIndexId, (uint)infoLevel));
		}
	}

	public int JetGetIndexInfo(JET_SESID sesid, JET_DBID dbid, string tablename, string indexname, out JET_INDEXLIST result, JET_IdxInfo infoLevel)
	{
		CheckNotNull(tablename, "tablename");
		checked
		{
			NATIVE_INDEXLIST result2 = new NATIVE_INDEXLIST
			{
				cbStruct = (uint)Marshal.SizeOf(typeof(NATIVE_INDEXLIST))
			};
			int result3 = ((!Capabilities.SupportsVistaFeatures) ? Err(NativeMethods.JetGetIndexInfo(sesid.Value, dbid.Value, tablename, indexname, ref result2, result2.cbStruct, (uint)infoLevel)) : Err(NativeMethods.JetGetIndexInfoW(sesid.Value, dbid.Value, tablename, indexname, ref result2, result2.cbStruct, (uint)infoLevel)));
			result = new JET_INDEXLIST();
			result.SetFromNativeIndexlist(result2);
			return result3;
		}
	}

	public int JetGetIndexInfo(JET_SESID sesid, JET_DBID dbid, string tablename, string indexname, out string result, JET_IdxInfo infoLevel)
	{
		CheckNotNull(tablename, "tablename");
		uint cbResult = 170u;
		StringBuilder stringBuilder = new StringBuilder(85);
		int result2 = Err(NativeMethods.JetGetIndexInfoW(sesid.Value, dbid.Value, tablename, indexname, stringBuilder, cbResult, checked((uint)infoLevel)));
		result = stringBuilder.ToString();
		result = StringCache.TryToIntern(result);
		return result2;
	}

	public int JetGetTableIndexInfo(JET_SESID sesid, JET_TABLEID tableid, string indexname, out ushort result, JET_IdxInfo infoLevel)
	{
		checked
		{
			if (Capabilities.SupportsVistaFeatures)
			{
				return Err(NativeMethods.JetGetTableIndexInfoW(sesid.Value, tableid.Value, indexname, out result, 2u, (uint)infoLevel));
			}
			return Err(NativeMethods.JetGetTableIndexInfo(sesid.Value, tableid.Value, indexname, out result, 2u, (uint)infoLevel));
		}
	}

	public int JetGetTableIndexInfo(JET_SESID sesid, JET_TABLEID tableid, string indexname, out int result, JET_IdxInfo infoLevel)
	{
		uint result3;
		int result2 = checked((!Capabilities.SupportsVistaFeatures) ? Err(NativeMethods.JetGetTableIndexInfo(sesid.Value, tableid.Value, indexname, out result3, 4u, (uint)infoLevel)) : Err(NativeMethods.JetGetTableIndexInfoW(sesid.Value, tableid.Value, indexname, out result3, 4u, (uint)infoLevel)));
		result = (int)result3;
		return result2;
	}

	public int JetGetTableIndexInfo(JET_SESID sesid, JET_TABLEID tableid, string indexname, out JET_INDEXID result, JET_IdxInfo infoLevel)
	{
		checked
		{
			if (Capabilities.SupportsVistaFeatures)
			{
				return Err(NativeMethods.JetGetTableIndexInfoW(sesid.Value, tableid.Value, indexname, out result, JET_INDEXID.SizeOfIndexId, (uint)infoLevel));
			}
			return Err(NativeMethods.JetGetTableIndexInfo(sesid.Value, tableid.Value, indexname, out result, JET_INDEXID.SizeOfIndexId, (uint)infoLevel));
		}
	}

	public int JetGetTableIndexInfo(JET_SESID sesid, JET_TABLEID tableid, string indexname, out JET_INDEXLIST result, JET_IdxInfo infoLevel)
	{
		checked
		{
			NATIVE_INDEXLIST result2 = new NATIVE_INDEXLIST
			{
				cbStruct = (uint)Marshal.SizeOf(typeof(NATIVE_INDEXLIST))
			};
			int result3 = ((!Capabilities.SupportsVistaFeatures) ? Err(NativeMethods.JetGetTableIndexInfo(sesid.Value, tableid.Value, indexname, ref result2, result2.cbStruct, (uint)infoLevel)) : Err(NativeMethods.JetGetTableIndexInfoW(sesid.Value, tableid.Value, indexname, ref result2, result2.cbStruct, (uint)infoLevel)));
			result = new JET_INDEXLIST();
			result.SetFromNativeIndexlist(result2);
			return result3;
		}
	}

	public int JetGetTableIndexInfo(JET_SESID sesid, JET_TABLEID tableid, string indexname, out string result, JET_IdxInfo infoLevel)
	{
		uint cbResult = 170u;
		StringBuilder stringBuilder = new StringBuilder(85);
		int result2 = Err(NativeMethods.JetGetTableIndexInfoW(sesid.Value, tableid.Value, indexname, stringBuilder, cbResult, checked((uint)infoLevel)));
		result = stringBuilder.ToString();
		result = StringCache.TryToIntern(result);
		return result2;
	}

	public int JetRenameTable(JET_SESID sesid, JET_DBID dbid, string tableName, string newTableName)
	{
		CheckNotNull(tableName, "tableName");
		CheckNotNull(newTableName, "newTableName");
		return Err(NativeMethods.JetRenameTable(sesid.Value, dbid.Value, tableName, newTableName));
	}

	public int JetRenameColumn(JET_SESID sesid, JET_TABLEID tableid, string name, string newName, RenameColumnGrbit grbit)
	{
		CheckNotNull(name, "name");
		CheckNotNull(newName, "newName");
		return Err(NativeMethods.JetRenameColumn(sesid.Value, tableid.Value, name, newName, checked((uint)grbit)));
	}

	public int JetSetColumnDefaultValue(JET_SESID sesid, JET_DBID dbid, string tableName, string columnName, byte[] data, int dataSize, SetColumnDefaultValueGrbit grbit)
	{
		CheckNotNull(tableName, "tableName");
		CheckNotNull(columnName, "columnName");
		CheckDataSize(data, dataSize, "dataSize");
		return Err(checked(NativeMethods.JetSetColumnDefaultValue(sesid.Value, dbid.Value, tableName, columnName, data, (uint)dataSize, (uint)grbit)));
	}

	public int JetGotoBookmark(JET_SESID sesid, JET_TABLEID tableid, byte[] bookmark, int bookmarkSize)
	{
		CheckNotNull(bookmark, "bookmark");
		CheckDataSize(bookmark, bookmarkSize, "bookmarkSize");
		return Err(NativeMethods.JetGotoBookmark(sesid.Value, tableid.Value, bookmark, checked((uint)bookmarkSize)));
	}

	public int JetGotoSecondaryIndexBookmark(JET_SESID sesid, JET_TABLEID tableid, byte[] secondaryKey, int secondaryKeySize, byte[] primaryKey, int primaryKeySize, GotoSecondaryIndexBookmarkGrbit grbit)
	{
		CheckNotNull(secondaryKey, "secondaryKey");
		CheckDataSize(secondaryKey, secondaryKeySize, "secondaryKeySize");
		CheckDataSize(primaryKey, primaryKeySize, "primaryKeySize");
		return Err(checked(NativeMethods.JetGotoSecondaryIndexBookmark(sesid.Value, tableid.Value, secondaryKey, (uint)secondaryKeySize, primaryKey, (uint)primaryKeySize, (uint)grbit)));
	}

	public int JetMakeKey(JET_SESID sesid, JET_TABLEID tableid, IntPtr data, int dataSize, MakeKeyGrbit grbit)
	{
		CheckNotNegative(dataSize, "dataSize");
		return Err(NativeMethods.JetMakeKey(sesid.Value, tableid.Value, data, checked((uint)dataSize), (uint)grbit));
	}

	public int JetSeek(JET_SESID sesid, JET_TABLEID tableid, SeekGrbit grbit)
	{
		return Err(NativeMethods.JetSeek(sesid.Value, tableid.Value, (uint)grbit));
	}

	public int JetMove(JET_SESID sesid, JET_TABLEID tableid, int numRows, MoveGrbit grbit)
	{
		return Err(NativeMethods.JetMove(sesid.Value, tableid.Value, numRows, (uint)grbit));
	}

	public int JetSetIndexRange(JET_SESID sesid, JET_TABLEID tableid, SetIndexRangeGrbit grbit)
	{
		return Err(NativeMethods.JetSetIndexRange(sesid.Value, tableid.Value, (uint)grbit));
	}

	public int JetIntersectIndexes(JET_SESID sesid, JET_INDEXRANGE[] ranges, int numRanges, out JET_RECORDLIST recordlist, IntersectIndexesGrbit grbit)
	{
		CheckNotNull(ranges, "ranges");
		CheckDataSize(ranges, numRanges, "numRanges");
		if (numRanges < 2)
		{
			throw new ArgumentOutOfRangeException("numRanges", numRanges, "JetIntersectIndexes requires at least two index ranges.");
		}
		NATIVE_INDEXRANGE[] array = new NATIVE_INDEXRANGE[numRanges];
		checked
		{
			for (int i = 0; i < numRanges; i++)
			{
				array[i] = ranges[i].GetNativeIndexRange();
			}
			NATIVE_RECORDLIST recordlist2 = new NATIVE_RECORDLIST
			{
				cbStruct = (uint)Marshal.SizeOf(typeof(NATIVE_RECORDLIST))
			};
			int result = Err(NativeMethods.JetIntersectIndexes(sesid.Value, array, (uint)array.Length, ref recordlist2, (uint)grbit));
			recordlist = new JET_RECORDLIST();
			recordlist.SetFromNativeRecordlist(recordlist2);
			return result;
		}
	}

	public int JetSetCurrentIndex(JET_SESID sesid, JET_TABLEID tableid, string index)
	{
		return Err(NativeMethods.JetSetCurrentIndex(sesid.Value, tableid.Value, index));
	}

	public int JetSetCurrentIndex2(JET_SESID sesid, JET_TABLEID tableid, string index, SetCurrentIndexGrbit grbit)
	{
		return Err(NativeMethods.JetSetCurrentIndex2(sesid.Value, tableid.Value, index, checked((uint)grbit)));
	}

	public int JetSetCurrentIndex3(JET_SESID sesid, JET_TABLEID tableid, string index, SetCurrentIndexGrbit grbit, int itagSequence)
	{
		return Err(checked(NativeMethods.JetSetCurrentIndex3(sesid.Value, tableid.Value, index, (uint)grbit, (uint)itagSequence)));
	}

	public int JetSetCurrentIndex4(JET_SESID sesid, JET_TABLEID tableid, string index, JET_INDEXID indexid, SetCurrentIndexGrbit grbit, int itagSequence)
	{
		return Err(checked(NativeMethods.JetSetCurrentIndex4(sesid.Value, tableid.Value, index, ref indexid, (uint)grbit, (uint)itagSequence)));
	}

	public int JetIndexRecordCount(JET_SESID sesid, JET_TABLEID tableid, out int numRecords, int maxRecordsToCount)
	{
		CheckNotNegative(maxRecordsToCount, "maxRecordsToCount");
		uint crec = 0u;
		int result = Err(NativeMethods.JetIndexRecordCount(sesid.Value, tableid.Value, out crec, (uint)maxRecordsToCount));
		numRecords = checked((int)crec);
		return result;
	}

	public int JetIndexRecordCount2(JET_SESID sesid, JET_TABLEID tableid, out long numRecords, long maxRecordsToCount)
	{
		CheckNotNegative(maxRecordsToCount, "maxRecordsToCount");
		ulong crec = 0uL;
		int result = Err(NativeMethods.JetIndexRecordCount2(sesid.Value, tableid.Value, out crec, (ulong)maxRecordsToCount));
		numRecords = checked((long)crec);
		return result;
	}

	public int JetSetTableSequential(JET_SESID sesid, JET_TABLEID tableid, SetTableSequentialGrbit grbit)
	{
		return Err(NativeMethods.JetSetTableSequential(sesid.Value, tableid.Value, checked((uint)grbit)));
	}

	public int JetResetTableSequential(JET_SESID sesid, JET_TABLEID tableid, ResetTableSequentialGrbit grbit)
	{
		return Err(NativeMethods.JetResetTableSequential(sesid.Value, tableid.Value, checked((uint)grbit)));
	}

	public int JetGetRecordPosition(JET_SESID sesid, JET_TABLEID tableid, out JET_RECPOS recpos)
	{
		recpos = new JET_RECPOS();
		NATIVE_RECPOS precpos = recpos.GetNativeRecpos();
		int result = Err(NativeMethods.JetGetRecordPosition(sesid.Value, tableid.Value, out precpos, precpos.cbStruct));
		recpos.SetFromNativeRecpos(precpos);
		return result;
	}

	public int JetGotoPosition(JET_SESID sesid, JET_TABLEID tableid, JET_RECPOS recpos)
	{
		NATIVE_RECPOS precpos = recpos.GetNativeRecpos();
		return Err(NativeMethods.JetGotoPosition(sesid.Value, tableid.Value, ref precpos));
	}

	public unsafe int JetPrereadKeys(JET_SESID sesid, JET_TABLEID tableid, byte[][] keys, int[] keyLengths, int keyIndex, int keyCount, out int keysPreread, PrereadKeysGrbit grbit)
	{
		CheckSupportsWindows7Features("JetPrereadKeys");
		CheckDataSize(keys, keyIndex, "keyIndex", keyCount, "keyCount");
		CheckDataSize(keyLengths, keyIndex, "keyIndex", keyCount, "keyCount");
		CheckNotNull(keys, "keys");
		CheckNotNull(keyLengths, "keyLengths");
		void** ptr = stackalloc void*[keyCount];
		uint* ptr2 = stackalloc uint[keyCount];
		using GCHandleCollection gCHandleCollection = default(GCHandleCollection);
		gCHandleCollection.SetCapacity(keyCount);
		for (int i = 0; i < keyCount; i = checked(i + 1))
		{
			*(void**)((byte*)ptr + checked(unchecked((nint)i) * unchecked((nint)sizeof(void*)))) = (void*)gCHandleCollection.Add(keys[checked(keyIndex + i)]);
			*(uint*)((byte*)ptr2 + checked(unchecked((nint)i) * (nint)4)) = checked((uint)keyLengths[keyIndex + i]);
		}
		return Err(NativeMethods.JetPrereadKeys(sesid.Value, tableid.Value, ptr, ptr2, keyCount, out keysPreread, checked((uint)grbit)));
	}

	public int JetGetBookmark(JET_SESID sesid, JET_TABLEID tableid, byte[] bookmark, int bookmarkSize, out int actualBookmarkSize)
	{
		CheckDataSize(bookmark, bookmarkSize, "bookmarkSize");
		uint cbActual = 0u;
		int result = Err(NativeMethods.JetGetBookmark(sesid.Value, tableid.Value, bookmark, checked((uint)bookmarkSize), out cbActual));
		actualBookmarkSize = GetActualSize(cbActual);
		return result;
	}

	public int JetGetSecondaryIndexBookmark(JET_SESID sesid, JET_TABLEID tableid, byte[] secondaryKey, int secondaryKeySize, out int actualSecondaryKeySize, byte[] primaryKey, int primaryKeySize, out int actualPrimaryKeySize, GetSecondaryIndexBookmarkGrbit grbit)
	{
		CheckDataSize(secondaryKey, secondaryKeySize, "secondaryKeySize");
		CheckDataSize(primaryKey, primaryKeySize, "primaryKeySize");
		uint actualSecondaryKeySize2 = 0u;
		uint actualPrimaryKeySize2 = 0u;
		int result = Err(checked(NativeMethods.JetGetSecondaryIndexBookmark(sesid.Value, tableid.Value, secondaryKey, (uint)secondaryKeySize, out actualSecondaryKeySize2, primaryKey, (uint)primaryKeySize, out actualPrimaryKeySize2, (uint)grbit)));
		actualSecondaryKeySize = GetActualSize(actualSecondaryKeySize2);
		actualPrimaryKeySize = GetActualSize(actualPrimaryKeySize2);
		return result;
	}

	public int JetRetrieveKey(JET_SESID sesid, JET_TABLEID tableid, byte[] data, int dataSize, out int actualDataSize, RetrieveKeyGrbit grbit)
	{
		CheckDataSize(data, dataSize, "dataSize");
		uint cbActual = 0u;
		int result = Err(NativeMethods.JetRetrieveKey(sesid.Value, tableid.Value, data, checked((uint)dataSize), out cbActual, (uint)grbit));
		actualDataSize = GetActualSize(cbActual);
		return result;
	}

	public int JetRetrieveColumn(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, IntPtr data, int dataSize, out int actualDataSize, RetrieveColumnGrbit grbit, JET_RETINFO retinfo)
	{
		CheckNotNegative(dataSize, "dataSize");
		uint cbActual = 0u;
		int result;
		if (retinfo != null)
		{
			NATIVE_RETINFO pretinfo = retinfo.GetNativeRetinfo();
			result = Err(NativeMethods.JetRetrieveColumn(sesid.Value, tableid.Value, columnid.Value, data, checked((uint)dataSize), out cbActual, (uint)grbit, ref pretinfo));
			retinfo.SetFromNativeRetinfo(pretinfo);
		}
		else
		{
			result = Err(NativeMethods.JetRetrieveColumn(sesid.Value, tableid.Value, columnid.Value, data, checked((uint)dataSize), out cbActual, (uint)grbit, IntPtr.Zero));
		}
		actualDataSize = checked((int)cbActual);
		return result;
	}

	public unsafe int JetRetrieveColumns(JET_SESID sesid, JET_TABLEID tableid, NATIVE_RETRIEVECOLUMN* retrievecolumns, int numColumns)
	{
		return Err(NativeMethods.JetRetrieveColumns(sesid.Value, tableid.Value, retrievecolumns, checked((uint)numColumns)));
	}

	public unsafe int JetEnumerateColumns(JET_SESID sesid, JET_TABLEID tableid, int numColumnids, JET_ENUMCOLUMNID[] columnids, out int numColumnValues, out JET_ENUMCOLUMN[] columnValues, JET_PFNREALLOC allocator, IntPtr allocatorContext, int maxDataSize, EnumerateColumnsGrbit grbit)
	{
		CheckNotNull(allocator, "allocator");
		CheckNotNegative(maxDataSize, "maxDataSize");
		CheckDataSize(columnids, numColumnids, "numColumnids");
		NATIVE_ENUMCOLUMNID* ptr = stackalloc NATIVE_ENUMCOLUMNID[numColumnids];
		int num = ConvertEnumColumnids(columnids, numColumnids, ptr);
		uint* tags = stackalloc uint[num];
		ConvertEnumColumnidTags(columnids, numColumnids, ptr, tags);
		uint pcEnumColumn;
		NATIVE_ENUMCOLUMN* prgEnumColumn;
		int err = checked(NativeMethods.JetEnumerateColumns(sesid.Value, tableid.Value, (uint)numColumnids, (numColumnids > 0) ? ptr : null, out pcEnumColumn, out prgEnumColumn, allocator, allocatorContext, (uint)maxDataSize, (uint)grbit));
		ConvertEnumerateColumnsResult(allocator, allocatorContext, pcEnumColumn, prgEnumColumn, out numColumnValues, out columnValues);
		return Err(err);
	}

	public unsafe int JetEnumerateColumns(JET_SESID sesid, JET_TABLEID tableid, EnumerateColumnsGrbit grbit, out IEnumerable<EnumeratedColumn> enumeratedColumns)
	{
		Exception allocatorException = null;
		JET_PFNREALLOC jET_PFNREALLOC = delegate(IntPtr c, IntPtr pv, uint cb)
		{
			try
			{
				if (pv == IntPtr.Zero)
				{
					return Marshal.AllocHGlobal(new IntPtr(cb));
				}
				if (cb == 0)
				{
					Marshal.FreeHGlobal(pv);
					return IntPtr.Zero;
				}
				return Marshal.ReAllocHGlobal(pv, new IntPtr(cb));
			}
			catch (OutOfMemoryException)
			{
				return IntPtr.Zero;
			}
			catch (ThreadAbortException ex2)
			{
				LibraryHelpers.ThreadResetAbort();
				allocatorException = ex2;
				return IntPtr.Zero;
			}
			catch (Exception ex3)
			{
				allocatorException = ex3;
				return IntPtr.Zero;
			}
		};
		uint pcEnumColumn;
		NATIVE_ENUMCOLUMN* prgEnumColumn;
		int err = NativeMethods.JetEnumerateColumns(sesid.Value, tableid.Value, 0u, null, out pcEnumColumn, out prgEnumColumn, jET_PFNREALLOC, IntPtr.Zero, 2147483647u, checked((uint)(grbit & ~EnumerateColumnsGrbit.EnumerateCompressOutput)));
		EnumeratedColumn[] array = new EnumeratedColumn[pcEnumColumn];
		for (int num = 0; num < pcEnumColumn; num = checked(num + 1))
		{
			array[num] = new EnumeratedColumn();
			array[num].Id = new JET_COLUMNID
			{
				Value = ((NATIVE_ENUMCOLUMN*)((byte*)prgEnumColumn + checked(unchecked((nint)num) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMN)))))->columnid
			};
			array[num].Error = ((((NATIVE_ENUMCOLUMN*)((byte*)prgEnumColumn + checked(unchecked((nint)num) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMN)))))->err < 0) ? ((JET_err)((NATIVE_ENUMCOLUMN*)((byte*)prgEnumColumn + checked(unchecked((nint)num) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMN)))))->err) : JET_err.Success);
			array[num].Warning = ((((NATIVE_ENUMCOLUMN*)((byte*)prgEnumColumn + checked(unchecked((nint)num) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMN)))))->err > 0) ? ((JET_wrn)((NATIVE_ENUMCOLUMN*)((byte*)prgEnumColumn + checked(unchecked((nint)num) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMN)))))->err) : JET_wrn.Success);
			if (((NATIVE_ENUMCOLUMN*)((byte*)prgEnumColumn + checked(unchecked((nint)num) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMN)))))->err != 0)
			{
				continue;
			}
			EnumeratedColumn.Value[] array2 = new EnumeratedColumn.Value[((NATIVE_ENUMCOLUMN*)((byte*)prgEnumColumn + checked(unchecked((nint)num) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMN)))))->cEnumColumnValue];
			array[num].Values = array2;
			for (int num2 = 0; num2 < ((NATIVE_ENUMCOLUMN*)((byte*)prgEnumColumn + checked(unchecked((nint)num) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMN)))))->cEnumColumnValue; num2 = checked(num2 + 1))
			{
				array2[num2] = new EnumeratedColumn.Value();
				array2[num2].Ordinal = checked(num2 + 1);
				array2[num2].Warning = (JET_wrn)((NATIVE_ENUMCOLUMNVALUE*)((byte*)((NATIVE_ENUMCOLUMN*)((byte*)prgEnumColumn + checked(unchecked((nint)num) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMN)))))->rgEnumColumnValue + checked(unchecked((nint)num2) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMNVALUE)))))->err;
				checked
				{
					array2[num2].Bytes = new byte[(int)unchecked((NATIVE_ENUMCOLUMNVALUE*)((byte*)((NATIVE_ENUMCOLUMN*)((byte*)prgEnumColumn + checked(unchecked((nint)num) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMN)))))->rgEnumColumnValue + checked(unchecked((nint)num2) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMNVALUE)))))->cbData];
					Marshal.Copy(unchecked((NATIVE_ENUMCOLUMNVALUE*)((byte*)((NATIVE_ENUMCOLUMN*)((byte*)prgEnumColumn + checked(unchecked((nint)num) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMN)))))->rgEnumColumnValue + checked(unchecked((nint)num2) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMNVALUE)))))->pvData, array2[num2].Bytes, 0, (int)unchecked((NATIVE_ENUMCOLUMNVALUE*)((byte*)((NATIVE_ENUMCOLUMN*)((byte*)prgEnumColumn + checked(unchecked((nint)num) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMN)))))->rgEnumColumnValue + checked(unchecked((nint)num2) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMNVALUE)))))->cbData);
				}
				if (((NATIVE_ENUMCOLUMNVALUE*)((byte*)((NATIVE_ENUMCOLUMN*)((byte*)prgEnumColumn + checked(unchecked((nint)num) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMN)))))->rgEnumColumnValue + checked(unchecked((nint)num2) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMNVALUE)))))->pvData != IntPtr.Zero)
				{
					jET_PFNREALLOC(IntPtr.Zero, ((NATIVE_ENUMCOLUMNVALUE*)((byte*)((NATIVE_ENUMCOLUMN*)((byte*)prgEnumColumn + checked(unchecked((nint)num) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMN)))))->rgEnumColumnValue + checked(unchecked((nint)num2) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMNVALUE)))))->pvData, 0u);
				}
			}
			if (((NATIVE_ENUMCOLUMN*)((byte*)prgEnumColumn + checked(unchecked((nint)num) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMN)))))->rgEnumColumnValue != null)
			{
				jET_PFNREALLOC(IntPtr.Zero, new IntPtr(((NATIVE_ENUMCOLUMN*)((byte*)prgEnumColumn + checked(unchecked((nint)num) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMN)))))->rgEnumColumnValue), 0u);
			}
		}
		if (prgEnumColumn != null)
		{
			jET_PFNREALLOC(IntPtr.Zero, new IntPtr(prgEnumColumn), 0u);
		}
		if (allocatorException != null)
		{
			if (allocatorException is ThreadAbortException)
			{
				Thread.CurrentThread.Abort();
			}
			throw allocatorException;
		}
		enumeratedColumns = array;
		return Err(err);
	}

	public int JetGetRecordSize(JET_SESID sesid, JET_TABLEID tableid, ref JET_RECSIZE recsize, GetRecordSizeGrbit grbit)
	{
		CheckSupportsVistaFeatures("JetGetRecordSize");
		checked
		{
			int err;
			if (Capabilities.SupportsWindows7Features)
			{
				NATIVE_RECSIZE2 precsize = recsize.GetNativeRecsize2();
				err = NativeMethods.JetGetRecordSize2(sesid.Value, tableid.Value, ref precsize, (uint)grbit);
				recsize.SetFromNativeRecsize(precsize);
			}
			else
			{
				NATIVE_RECSIZE precsize2 = recsize.GetNativeRecsize();
				err = NativeMethods.JetGetRecordSize(sesid.Value, tableid.Value, ref precsize2, (uint)grbit);
				recsize.SetFromNativeRecsize(precsize2);
			}
			return Err(err);
		}
	}

	public int JetDelete(JET_SESID sesid, JET_TABLEID tableid)
	{
		return Err(NativeMethods.JetDelete(sesid.Value, tableid.Value));
	}

	public int JetPrepareUpdate(JET_SESID sesid, JET_TABLEID tableid, JET_prep prep)
	{
		return Err(NativeMethods.JetPrepareUpdate(sesid.Value, tableid.Value, (uint)prep));
	}

	public int JetUpdate(JET_SESID sesid, JET_TABLEID tableid, byte[] bookmark, int bookmarkSize, out int actualBookmarkSize)
	{
		CheckDataSize(bookmark, bookmarkSize, "bookmarkSize");
		uint cbActual;
		int result = Err(NativeMethods.JetUpdate(sesid.Value, tableid.Value, bookmark, checked((uint)bookmarkSize), out cbActual));
		actualBookmarkSize = GetActualSize(cbActual);
		return result;
	}

	public int JetUpdate2(JET_SESID sesid, JET_TABLEID tableid, byte[] bookmark, int bookmarkSize, out int actualBookmarkSize, UpdateGrbit grbit)
	{
		CheckDataSize(bookmark, bookmarkSize, "bookmarkSize");
		CheckSupportsServer2003Features("JetUpdate2");
		uint cbActual;
		int result = Err(checked(NativeMethods.JetUpdate2(sesid.Value, tableid.Value, bookmark, (uint)bookmarkSize, out cbActual, (uint)grbit)));
		actualBookmarkSize = GetActualSize(cbActual);
		return result;
	}

	public int JetSetColumn(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, IntPtr data, int dataSize, SetColumnGrbit grbit, JET_SETINFO setinfo)
	{
		CheckNotNegative(dataSize, "dataSize");
		if (IntPtr.Zero == data && dataSize > 0 && SetColumnGrbit.SizeLV != (grbit & SetColumnGrbit.SizeLV))
		{
			throw new ArgumentOutOfRangeException("dataSize", dataSize, "cannot be greater than the length of the data (unless the SizeLV option is used)");
		}
		if (setinfo != null)
		{
			NATIVE_SETINFO psetinfo = setinfo.GetNativeSetinfo();
			return Err(NativeMethods.JetSetColumn(sesid.Value, tableid.Value, columnid.Value, data, checked((uint)dataSize), (uint)grbit, ref psetinfo));
		}
		return Err(NativeMethods.JetSetColumn(sesid.Value, tableid.Value, columnid.Value, data, checked((uint)dataSize), (uint)grbit, IntPtr.Zero));
	}

	public unsafe int JetSetColumns(JET_SESID sesid, JET_TABLEID tableid, NATIVE_SETCOLUMN* setcolumns, int numColumns)
	{
		return Err(NativeMethods.JetSetColumns(sesid.Value, tableid.Value, setcolumns, checked((uint)numColumns)));
	}

	public int JetGetLock(JET_SESID sesid, JET_TABLEID tableid, GetLockGrbit grbit)
	{
		return Err(NativeMethods.JetGetLock(sesid.Value, tableid.Value, (uint)grbit));
	}

	public int JetEscrowUpdate(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid, byte[] delta, int deltaSize, byte[] previousValue, int previousValueLength, out int actualPreviousValueLength, EscrowUpdateGrbit grbit)
	{
		CheckNotNull(delta, "delta");
		CheckDataSize(delta, deltaSize, "deltaSize");
		CheckDataSize(previousValue, previousValueLength, "previousValueLength");
		uint cbOldActual = 0u;
		checked
		{
			int result = Err(NativeMethods.JetEscrowUpdate(sesid.Value, tableid.Value, columnid.Value, delta, (uint)deltaSize, previousValue, (uint)previousValueLength, out cbOldActual, unchecked((uint)grbit)));
			actualPreviousValueLength = (int)cbOldActual;
			return result;
		}
	}

	public int JetRegisterCallback(JET_SESID sesid, JET_TABLEID tableid, JET_cbtyp cbtyp, JET_CALLBACK callback, IntPtr context, out JET_HANDLE callbackId)
	{
		CheckNotNull(callback, "callback");
		callbackId = JET_HANDLE.Nil;
		return Err(NativeMethods.JetRegisterCallback(sesid.Value, tableid.Value, (uint)cbtyp, callbackWrappers.Add(callback).NativeCallback, context, out callbackId.Value));
	}

	public int JetUnregisterCallback(JET_SESID sesid, JET_TABLEID tableid, JET_cbtyp cbtyp, JET_HANDLE callbackId)
	{
		callbackWrappers.Collect();
		return Err(NativeMethods.JetUnregisterCallback(sesid.Value, tableid.Value, (uint)cbtyp, callbackId.Value));
	}

	public int JetDefragment(JET_SESID sesid, JET_DBID dbid, string tableName, ref int passes, ref int seconds, DefragGrbit grbit)
	{
		uint pcPasses = (uint)passes;
		uint pcSeconds = (uint)seconds;
		int result = Err(NativeMethods.JetDefragment(sesid.Value, dbid.Value, tableName, ref pcPasses, ref pcSeconds, checked((uint)grbit)));
		passes = (int)pcPasses;
		seconds = (int)pcSeconds;
		return result;
	}

	public int Defragment(JET_SESID sesid, JET_DBID dbid, string tableName, DefragGrbit grbit)
	{
		return Err(NativeMethods.JetDefragment(sesid.Value, dbid.Value, tableName, IntPtr.Zero, IntPtr.Zero, checked((uint)grbit)));
	}

	public int JetDefragment2(JET_SESID sesid, JET_DBID dbid, string tableName, ref int passes, ref int seconds, JET_CALLBACK callback, DefragGrbit grbit)
	{
		uint pcPasses = (uint)passes;
		uint pcSeconds = (uint)seconds;
		int result = Err(NativeMethods.JetDefragment2(callback: (callback != null) ? Marshal.GetFunctionPointerForDelegate(callbackWrappers.Add(callback).NativeCallback) : IntPtr.Zero, sesid: sesid.Value, dbid: dbid.Value, szTableName: tableName, pcPasses: ref pcPasses, pcSeconds: ref pcSeconds, grbit: checked((uint)grbit)));
		passes = (int)pcPasses;
		seconds = (int)pcSeconds;
		callbackWrappers.Collect();
		return result;
	}

	public int JetIdle(JET_SESID sesid, IdleGrbit grbit)
	{
		return Err(NativeMethods.JetIdle(sesid.Value, checked((uint)grbit)));
	}

	public int JetConfigureProcessForCrashDump(CrashDumpGrbit grbit)
	{
		CheckSupportsWindows7Features("JetConfigureProcessForCrashDump");
		return Err(NativeMethods.JetConfigureProcessForCrashDump(checked((uint)grbit)));
	}

	public int JetFreeBuffer(IntPtr buffer)
	{
		return Err(NativeMethods.JetFreeBuffer(buffer));
	}

	internal static int GetActualSize(uint numBytesActual)
	{
		if (-572662307 == (int)numBytesActual)
		{
			return 0;
		}
		return checked((int)numBytesActual);
	}

	private static void CheckDataSize<T>(ICollection<T> data, int dataOffset, string offsetArgumentName, int dataSize, string sizeArgumentName)
	{
		CheckNotNegative(dataSize, sizeArgumentName);
		CheckNotNegative(dataOffset, offsetArgumentName);
		if ((data == null && dataOffset != 0) || (data != null && dataOffset > data.Count))
		{
			throw new ArgumentOutOfRangeException(offsetArgumentName, dataOffset, "cannot be greater than the length of the buffer");
		}
		if ((data == null && dataSize != 0) || (data != null && dataSize > checked(data.Count - dataOffset)))
		{
			throw new ArgumentOutOfRangeException(sizeArgumentName, dataSize, "cannot be greater than the length of the buffer");
		}
	}

	private static void CheckDataSize<T>(ICollection<T> data, int dataSize, string argumentName)
	{
		CheckDataSize(data, 0, string.Empty, dataSize, argumentName);
	}

	private static void CheckNotNull(object o, string paramName)
	{
		if (o == null)
		{
			throw new ArgumentNullException(paramName);
		}
	}

	private static void CheckNotNegative(long i, string paramName)
	{
		if (i < 0)
		{
			throw new ArgumentOutOfRangeException(paramName, i, "cannot be negative");
		}
	}

	private static Exception UnsupportedApiException(string method)
	{
		return new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Method {0} is not supported by this version of ESENT", method));
	}

	[Conditional("TRACE")]
	private static void TraceFunctionCall([CallerMemberName] string function = null)
	{
	}

	private static int Err(int err)
	{
		return err;
	}

	[Conditional("TRACE")]
	private static void TraceErr(int err)
	{
		if (err != 0)
		{
			_ = 0;
		}
	}

	private unsafe static int ConvertEnumColumnids(IList<JET_ENUMCOLUMNID> columnids, int numColumnids, NATIVE_ENUMCOLUMNID* nativecolumnids)
	{
		int num = 0;
		for (int i = 0; i < numColumnids; i = checked(i + 1))
		{
			*(NATIVE_ENUMCOLUMNID*)((byte*)nativecolumnids + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMNID)))) = columnids[i].GetNativeEnumColumnid();
			num = checked(num + columnids[i].ctagSequence);
		}
		return num;
	}

	private unsafe static void ConvertEnumColumnidTags(IList<JET_ENUMCOLUMNID> columnids, int numColumnids, NATIVE_ENUMCOLUMNID* nativecolumnids, uint* tags)
	{
		for (int i = 0; i < numColumnids; i = checked(i + 1))
		{
			((NATIVE_ENUMCOLUMNID*)((byte*)nativecolumnids + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMNID)))))->rgtagSequence = tags;
			for (int j = 0; j < columnids[i].ctagSequence; j = checked(j + 1))
			{
				*(uint*)((byte*)((NATIVE_ENUMCOLUMNID*)((byte*)nativecolumnids + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMNID)))))->rgtagSequence + checked(unchecked((nint)j) * (nint)4)) = checked((uint)columnids[i].rgtagSequence[j]);
			}
			tags = (uint*)checked(unchecked((nuint)tags) + unchecked((nuint)checked(unchecked((nint)columnids[i].ctagSequence) * (nint)4)));
		}
	}

	private unsafe static void ConvertEnumerateColumnsResult(JET_PFNREALLOC allocator, IntPtr allocatorContext, uint numEnumColumn, NATIVE_ENUMCOLUMN* nativeenumcolumns, out int numColumnValues, out JET_ENUMCOLUMN[] columnValues)
	{
		numColumnValues = checked((int)numEnumColumn);
		columnValues = new JET_ENUMCOLUMN[numColumnValues];
		for (int i = 0; i < numColumnValues; i = checked(i + 1))
		{
			columnValues[i] = new JET_ENUMCOLUMN();
			columnValues[i].SetFromNativeEnumColumn(*(NATIVE_ENUMCOLUMN*)((byte*)nativeenumcolumns + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMN)))));
			if (JET_wrn.ColumnSingleValue != columnValues[i].err)
			{
				columnValues[i].rgEnumColumnValue = new JET_ENUMCOLUMNVALUE[columnValues[i].cEnumColumnValue];
				for (int j = 0; j < columnValues[i].cEnumColumnValue; j = checked(j + 1))
				{
					columnValues[i].rgEnumColumnValue[j] = new JET_ENUMCOLUMNVALUE();
					columnValues[i].rgEnumColumnValue[j].SetFromNativeEnumColumnValue(*(NATIVE_ENUMCOLUMNVALUE*)((byte*)((NATIVE_ENUMCOLUMN*)((byte*)nativeenumcolumns + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMN)))))->rgEnumColumnValue + checked(unchecked((nint)j) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMNVALUE)))));
				}
				allocator(allocatorContext, new IntPtr(((NATIVE_ENUMCOLUMN*)((byte*)nativeenumcolumns + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMN)))))->rgEnumColumnValue), 0u);
				((NATIVE_ENUMCOLUMN*)((byte*)nativeenumcolumns + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_ENUMCOLUMN)))))->rgEnumColumnValue = null;
			}
		}
		allocator(allocatorContext, new IntPtr(nativeenumcolumns), 0u);
		nativeenumcolumns = null;
	}

	private static NATIVE_COLUMNDEF[] GetNativecolumndefs(IList<JET_COLUMNDEF> columns, int numColumns)
	{
		NATIVE_COLUMNDEF[] array = new NATIVE_COLUMNDEF[numColumns];
		for (int i = 0; i < numColumns; i = checked(i + 1))
		{
			array[i] = columns[i].GetNativeColumndef();
		}
		return array;
	}

	private static IntPtr GetNativeConditionalColumns(IList<JET_CONDITIONALCOLUMN> conditionalColumns, bool useUnicodeData, ref GCHandleCollection handles)
	{
		if (conditionalColumns == null)
		{
			return IntPtr.Zero;
		}
		NATIVE_CONDITIONALCOLUMN[] array = new NATIVE_CONDITIONALCOLUMN[conditionalColumns.Count];
		for (int i = 0; i < conditionalColumns.Count; i = checked(i + 1))
		{
			array[i] = conditionalColumns[i].GetNativeConditionalColumn();
			if (useUnicodeData)
			{
				array[i].szColumnName = handles.Add(Util.ConvertToNullTerminatedUnicodeByteArray(conditionalColumns[i].szColumnName));
			}
			else
			{
				array[i].szColumnName = handles.Add(Util.ConvertToNullTerminatedAsciiByteArray(conditionalColumns[i].szColumnName));
			}
		}
		return handles.Add(array);
	}

	private static IntPtr GetNativeColumnCreates(IList<JET_COLUMNCREATE> managedColumnCreates, bool useUnicodeData, ref GCHandleCollection handles)
	{
		IntPtr result = IntPtr.Zero;
		if (managedColumnCreates != null && managedColumnCreates.Count > 0)
		{
			NATIVE_COLUMNCREATE[] array = new NATIVE_COLUMNCREATE[managedColumnCreates.Count];
			for (int i = 0; i < managedColumnCreates.Count; i = checked(i + 1))
			{
				if (managedColumnCreates[i] != null)
				{
					JET_COLUMNCREATE jET_COLUMNCREATE = managedColumnCreates[i];
					array[i] = jET_COLUMNCREATE.GetNativeColumnCreate();
					if (useUnicodeData)
					{
						array[i].szColumnName = handles.Add(Util.ConvertToNullTerminatedUnicodeByteArray(jET_COLUMNCREATE.szColumnName));
					}
					else
					{
						array[i].szColumnName = handles.Add(Util.ConvertToNullTerminatedAsciiByteArray(jET_COLUMNCREATE.szColumnName));
					}
					if (jET_COLUMNCREATE.cbDefault > 0)
					{
						array[i].pvDefault = handles.Add(jET_COLUMNCREATE.pvDefault);
					}
				}
			}
			result = handles.Add(array);
		}
		return result;
	}

	private unsafe static JET_INDEXCREATE.NATIVE_INDEXCREATE[] GetNativeIndexCreates(IList<JET_INDEXCREATE> managedIndexCreates, ref GCHandleCollection handles)
	{
		JET_INDEXCREATE.NATIVE_INDEXCREATE[] array = null;
		if (managedIndexCreates != null && managedIndexCreates.Count > 0)
		{
			array = new JET_INDEXCREATE.NATIVE_INDEXCREATE[managedIndexCreates.Count];
			for (int i = 0; i < managedIndexCreates.Count; i = checked(i + 1))
			{
				array[i] = managedIndexCreates[i].GetNativeIndexcreate();
				if (managedIndexCreates[i].pidxUnicode != null)
				{
					NATIVE_UNICODEINDEX nativeUnicodeIndex = managedIndexCreates[i].pidxUnicode.GetNativeUnicodeIndex();
					array[i].pidxUnicode = (NATIVE_UNICODEINDEX*)(void*)handles.Add(nativeUnicodeIndex);
					array[i].grbit |= 2048u;
				}
				array[i].szKey = handles.Add(Util.ConvertToNullTerminatedAsciiByteArray(managedIndexCreates[i].szKey));
				array[i].szIndexName = handles.Add(Util.ConvertToNullTerminatedAsciiByteArray(managedIndexCreates[i].szIndexName));
				array[i].rgconditionalcolumn = GetNativeConditionalColumns(managedIndexCreates[i].rgconditionalcolumn, useUnicodeData: false, ref handles);
			}
		}
		return array;
	}

	private unsafe static JET_INDEXCREATE.NATIVE_INDEXCREATE1[] GetNativeIndexCreate1s(IList<JET_INDEXCREATE> managedIndexCreates, ref GCHandleCollection handles)
	{
		JET_INDEXCREATE.NATIVE_INDEXCREATE1[] array = null;
		checked
		{
			if (managedIndexCreates != null && managedIndexCreates.Count > 0)
			{
				array = new JET_INDEXCREATE.NATIVE_INDEXCREATE1[managedIndexCreates.Count];
				for (int i = 0; i < managedIndexCreates.Count; i++)
				{
					array[i] = managedIndexCreates[i].GetNativeIndexcreate1();
					if (managedIndexCreates[i].pidxUnicode != null)
					{
						NATIVE_UNICODEINDEX nativeUnicodeIndex = managedIndexCreates[i].pidxUnicode.GetNativeUnicodeIndex();
						array[i].indexcreate.pidxUnicode = unchecked((NATIVE_UNICODEINDEX*)(void*)handles.Add(nativeUnicodeIndex));
						array[i].indexcreate.grbit |= 2048u;
					}
					array[i].indexcreate.szKey = handles.Add(Util.ConvertToNullTerminatedUnicodeByteArray(managedIndexCreates[i].szKey));
					array[i].indexcreate.cbKey *= 2u;
					array[i].indexcreate.szIndexName = handles.Add(Util.ConvertToNullTerminatedUnicodeByteArray(managedIndexCreates[i].szIndexName));
					array[i].indexcreate.rgconditionalcolumn = GetNativeConditionalColumns(managedIndexCreates[i].rgconditionalcolumn, useUnicodeData: false, ref handles);
				}
			}
			return array;
		}
	}

	private unsafe static JET_INDEXCREATE.NATIVE_INDEXCREATE2[] GetNativeIndexCreate2s(IList<JET_INDEXCREATE> managedIndexCreates, ref GCHandleCollection handles)
	{
		JET_INDEXCREATE.NATIVE_INDEXCREATE2[] array = null;
		checked
		{
			if (managedIndexCreates != null && managedIndexCreates.Count > 0)
			{
				array = new JET_INDEXCREATE.NATIVE_INDEXCREATE2[managedIndexCreates.Count];
				for (int i = 0; i < managedIndexCreates.Count; i++)
				{
					array[i] = managedIndexCreates[i].GetNativeIndexcreate2();
					if (managedIndexCreates[i].pidxUnicode != null)
					{
						NATIVE_UNICODEINDEX nativeUnicodeIndex = managedIndexCreates[i].pidxUnicode.GetNativeUnicodeIndex();
						array[i].indexcreate1.indexcreate.pidxUnicode = unchecked((NATIVE_UNICODEINDEX*)(void*)handles.Add(nativeUnicodeIndex));
						array[i].indexcreate1.indexcreate.grbit |= 2048u;
					}
					array[i].indexcreate1.indexcreate.szKey = handles.Add(Util.ConvertToNullTerminatedUnicodeByteArray(managedIndexCreates[i].szKey));
					array[i].indexcreate1.indexcreate.cbKey *= 2u;
					array[i].indexcreate1.indexcreate.szIndexName = handles.Add(Util.ConvertToNullTerminatedUnicodeByteArray(managedIndexCreates[i].szIndexName));
					array[i].indexcreate1.indexcreate.rgconditionalcolumn = GetNativeConditionalColumns(managedIndexCreates[i].rgconditionalcolumn, useUnicodeData: true, ref handles);
					if (managedIndexCreates[i].pSpaceHints != null)
					{
						NATIVE_SPACEHINTS nativeSpaceHints = managedIndexCreates[i].pSpaceHints.GetNativeSpaceHints();
						array[i].pSpaceHints = handles.Add(nativeSpaceHints);
					}
				}
			}
			return array;
		}
	}

	private static void SetColumnids(IList<JET_COLUMNDEF> columns, IList<JET_COLUMNID> columnids, IList<uint> nativecolumnids, int numColumns)
	{
		for (int i = 0; i < numColumns; i = checked(i + 1))
		{
			columnids[i] = new JET_COLUMNID
			{
				Value = nativecolumnids[i]
			};
			columns[i].columnid = columnids[i];
		}
	}

	private static int CreateIndexes(JET_SESID sesid, JET_TABLEID tableid, IList<JET_INDEXCREATE> indexcreates, int numIndexCreates)
	{
		GCHandleCollection handles = default(GCHandleCollection);
		try
		{
			JET_INDEXCREATE.NATIVE_INDEXCREATE[] nativeIndexCreates = GetNativeIndexCreates(indexcreates, ref handles);
			return Err(NativeMethods.JetCreateIndex2(sesid.Value, tableid.Value, nativeIndexCreates, checked((uint)numIndexCreates)));
		}
		finally
		{
			handles.Dispose();
		}
	}

	private static int CreateIndexes1(JET_SESID sesid, JET_TABLEID tableid, IList<JET_INDEXCREATE> indexcreates, int numIndexCreates)
	{
		GCHandleCollection handles = default(GCHandleCollection);
		try
		{
			JET_INDEXCREATE.NATIVE_INDEXCREATE1[] nativeIndexCreate1s = GetNativeIndexCreate1s(indexcreates, ref handles);
			return Err(NativeMethods.JetCreateIndex2W(sesid.Value, tableid.Value, nativeIndexCreate1s, checked((uint)numIndexCreates)));
		}
		finally
		{
			handles.Dispose();
		}
	}

	private static int CreateIndexes2(JET_SESID sesid, JET_TABLEID tableid, IList<JET_INDEXCREATE> indexcreates, int numIndexCreates)
	{
		GCHandleCollection handles = default(GCHandleCollection);
		try
		{
			JET_INDEXCREATE.NATIVE_INDEXCREATE2[] nativeIndexCreate2s = GetNativeIndexCreate2s(indexcreates, ref handles);
			return Err(NativeMethods.JetCreateIndex3W(sesid.Value, tableid.Value, nativeIndexCreate2s, checked((uint)numIndexCreates)));
		}
		finally
		{
			handles.Dispose();
		}
	}

	private unsafe static int CreateTableColumnIndex3(JET_SESID sesid, JET_DBID dbid, JET_TABLECREATE tablecreate)
	{
		JET_TABLECREATE.NATIVE_TABLECREATE3 tablecreate2 = tablecreate.GetNativeTableCreate3();
		GCHandleCollection handles = default(GCHandleCollection);
		try
		{
			tablecreate2.rgcolumncreate = (NATIVE_COLUMNCREATE*)(void*)GetNativeColumnCreates(tablecreate.rgcolumncreate, useUnicodeData: true, ref handles);
			JET_INDEXCREATE.NATIVE_INDEXCREATE2[] nativeIndexCreate2s = GetNativeIndexCreate2s(tablecreate.rgindexcreate, ref handles);
			tablecreate2.rgindexcreate = handles.Add(nativeIndexCreate2s);
			if (tablecreate.pSeqSpacehints != null)
			{
				NATIVE_SPACEHINTS nativeSpaceHints = tablecreate.pSeqSpacehints.GetNativeSpaceHints();
				tablecreate2.pSeqSpacehints = (NATIVE_SPACEHINTS*)(void*)handles.Add(nativeSpaceHints);
			}
			if (tablecreate.pLVSpacehints != null)
			{
				NATIVE_SPACEHINTS nativeSpaceHints2 = tablecreate.pLVSpacehints.GetNativeSpaceHints();
				tablecreate2.pLVSpacehints = (NATIVE_SPACEHINTS*)(void*)handles.Add(nativeSpaceHints2);
			}
			int err = NativeMethods.JetCreateTableColumnIndex3W(sesid.Value, dbid.Value, ref tablecreate2);
			tablecreate.tableid = new JET_TABLEID
			{
				Value = tablecreate2.tableid
			};
			checked
			{
				tablecreate.cCreated = (int)tablecreate2.cCreated;
				if (tablecreate.rgcolumncreate != null)
				{
					for (int i = 0; i < tablecreate.rgcolumncreate.Length; i++)
					{
						unchecked
						{
							tablecreate.rgcolumncreate[i].SetFromNativeColumnCreate(ref *(NATIVE_COLUMNCREATE*)((byte*)tablecreate2.rgcolumncreate + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_COLUMNCREATE)))));
						}
					}
				}
				if (tablecreate.rgindexcreate != null)
				{
					for (int j = 0; j < tablecreate.rgindexcreate.Length; j++)
					{
						tablecreate.rgindexcreate[j].SetFromNativeIndexCreate(nativeIndexCreate2s[j]);
					}
				}
				return Err(err);
			}
		}
		finally
		{
			handles.Dispose();
		}
	}

	private unsafe JET_INSTANCE_INFO[] ConvertInstanceInfosUnicode(uint nativeNumInstance, NATIVE_INSTANCE_INFO* nativeInstanceInfos)
	{
		int num = checked((int)nativeNumInstance);
		JET_INSTANCE_INFO[] array = new JET_INSTANCE_INFO[num];
		for (int i = 0; i < num; i = checked(i + 1))
		{
			array[i] = new JET_INSTANCE_INFO();
			array[i].SetFromNativeUnicode(*(NATIVE_INSTANCE_INFO*)((byte*)nativeInstanceInfos + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_INSTANCE_INFO)))));
		}
		JetFreeBuffer(new IntPtr(nativeInstanceInfos));
		return array;
	}

	private unsafe JET_INSTANCE_INFO[] ConvertInstanceInfosAscii(uint nativeNumInstance, NATIVE_INSTANCE_INFO* nativeInstanceInfos)
	{
		int num = checked((int)nativeNumInstance);
		JET_INSTANCE_INFO[] array = new JET_INSTANCE_INFO[num];
		for (int i = 0; i < num; i = checked(i + 1))
		{
			array[i] = new JET_INSTANCE_INFO();
			array[i].SetFromNativeAscii(*(NATIVE_INSTANCE_INFO*)((byte*)nativeInstanceInfos + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_INSTANCE_INFO)))));
		}
		JetFreeBuffer(new IntPtr(nativeInstanceInfos));
		return array;
	}

	private void CheckSupportsServer2003Features(string api)
	{
		if (!Capabilities.SupportsServer2003Features)
		{
			throw UnsupportedApiException(api);
		}
	}

	private void CheckSupportsVistaFeatures(string api)
	{
		if (!Capabilities.SupportsVistaFeatures)
		{
			throw UnsupportedApiException(api);
		}
	}

	private void CheckSupportsWindows7Features(string api)
	{
		if (!Capabilities.SupportsWindows7Features)
		{
			throw UnsupportedApiException(api);
		}
	}

	private void CheckSupportsWindows8Features(string api)
	{
		if (!Capabilities.SupportsWindows8Features)
		{
			throw UnsupportedApiException(api);
		}
	}

	private void CheckSupportsWindows10Features(string api)
	{
		if (!Capabilities.SupportsWindows10Features)
		{
			throw UnsupportedApiException(api);
		}
	}

	private unsafe int CreateTableColumnIndex2(JET_SESID sesid, JET_DBID dbid, JET_TABLECREATE tablecreate)
	{
		JET_TABLECREATE.NATIVE_TABLECREATE2 tablecreate2 = tablecreate.GetNativeTableCreate2();
		GCHandleCollection handles = default(GCHandleCollection);
		try
		{
			JET_INDEXCREATE.NATIVE_INDEXCREATE1[] array = null;
			JET_INDEXCREATE.NATIVE_INDEXCREATE[] array2 = null;
			int err;
			if (Capabilities.SupportsVistaFeatures)
			{
				tablecreate2.rgcolumncreate = (NATIVE_COLUMNCREATE*)(void*)GetNativeColumnCreates(tablecreate.rgcolumncreate, useUnicodeData: true, ref handles);
				array = GetNativeIndexCreate1s(tablecreate.rgindexcreate, ref handles);
				tablecreate2.rgindexcreate = handles.Add(array);
				err = NativeMethods.JetCreateTableColumnIndex2W(sesid.Value, dbid.Value, ref tablecreate2);
			}
			else
			{
				tablecreate2.rgcolumncreate = (NATIVE_COLUMNCREATE*)(void*)GetNativeColumnCreates(tablecreate.rgcolumncreate, useUnicodeData: false, ref handles);
				array2 = GetNativeIndexCreates(tablecreate.rgindexcreate, ref handles);
				tablecreate2.rgindexcreate = handles.Add(array2);
				err = NativeMethods.JetCreateTableColumnIndex2(sesid.Value, dbid.Value, ref tablecreate2);
			}
			tablecreate.tableid = new JET_TABLEID
			{
				Value = tablecreate2.tableid
			};
			checked
			{
				tablecreate.cCreated = (int)tablecreate2.cCreated;
				if (tablecreate.rgcolumncreate != null)
				{
					for (int i = 0; i < tablecreate.rgcolumncreate.Length; i++)
					{
						unchecked
						{
							tablecreate.rgcolumncreate[i].SetFromNativeColumnCreate(ref *(NATIVE_COLUMNCREATE*)((byte*)tablecreate2.rgcolumncreate + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_COLUMNCREATE)))));
						}
					}
				}
				if (tablecreate.rgindexcreate != null)
				{
					for (int j = 0; j < tablecreate.rgindexcreate.Length; j++)
					{
						if (array != null)
						{
							tablecreate.rgindexcreate[j].SetFromNativeIndexCreate(array[j]);
						}
						else
						{
							tablecreate.rgindexcreate[j].SetFromNativeIndexCreate(array2[j]);
						}
					}
				}
				return Err(err);
			}
		}
		finally
		{
			handles.Dispose();
		}
	}

	public int JetGetSessionParameter(JET_SESID sesid, JET_sesparam sesparamid, out JET_OPERATIONCONTEXT operationContext)
	{
		CheckSupportsWindows10Features("JetGetSessionParameter");
		NATIVE_OPERATIONCONTEXT data = default(NATIVE_OPERATIONCONTEXT);
		int num = Marshal.SizeOf(data);
		int actualDataSize;
		int num2 = NativeMethods.JetGetSessionParameter(sesid.Value, checked((uint)sesparamid), out data, num, out actualDataSize);
		if (num2 >= 0 && actualDataSize != num)
		{
			throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Bad return value. Unexpected data size returned. Expected {0}, but received {1}.", num, actualDataSize), "sesparamid");
		}
		operationContext = new JET_OPERATIONCONTEXT(ref data);
		return Err(num2);
	}

	public int JetSetSessionParameter(JET_SESID sesid, JET_sesparam sesparamid, JET_OPERATIONCONTEXT operationContext)
	{
		CheckSupportsWindows10Features("JetSetSessionParameter");
		NATIVE_OPERATIONCONTEXT data = operationContext.GetNativeOperationContext();
		int dataSize = Marshal.SizeOf(data);
		return Err(NativeMethods.JetSetSessionParameter(sesid.Value, checked((uint)sesparamid), ref data, dataSize));
	}

	public unsafe int JetGetThreadStats(out JET_THREADSTATS2 threadstats)
	{
		CheckSupportsVistaFeatures("JetGetThreadStats");
		fixed (JET_THREADSTATS2* pvResult = &threadstats)
		{
			return Err(NativeMethods.JetGetThreadStats(pvResult, checked((uint)JET_THREADSTATS2.Size)));
		}
	}

	public int JetBeginTransaction3(JET_SESID sesid, long userTransactionId, BeginTransactionGrbit grbit)
	{
		return Err(NativeMethods.JetBeginTransaction3(sesid.Value, userTransactionId, (uint)grbit));
	}

	public int JetCommitTransaction2(JET_SESID sesid, CommitTransactionGrbit grbit, TimeSpan durableCommit, out JET_COMMIT_ID commitId)
	{
		CheckSupportsWindows8Features("JetCommitTransaction2");
		uint cmsecDurableCommit = checked((uint)durableCommit.TotalMilliseconds);
		NATIVE_COMMIT_ID pCommitId = default(NATIVE_COMMIT_ID);
		int result = Err(NativeMethods.JetCommitTransaction2(sesid.Value, (uint)grbit, cmsecDurableCommit, ref pCommitId));
		commitId = new JET_COMMIT_ID(pCommitId);
		return result;
	}

	public int JetGetErrorInfo(JET_err error, out JET_ERRINFOBASIC errinfo)
	{
		CheckSupportsWindows8Features("JetGetErrorInfo");
		NATIVE_ERRINFOBASIC pvResult = default(NATIVE_ERRINFOBASIC);
		errinfo = new JET_ERRINFOBASIC();
		pvResult.cbStruct = checked((uint)Marshal.SizeOf(typeof(NATIVE_ERRINFOBASIC)));
		int error2 = (int)error;
		int result = NativeMethods.JetGetErrorInfoW(ref error2, ref pvResult, pvResult.cbStruct, 1u, 0u);
		errinfo.SetFromNative(ref pvResult);
		return result;
	}

	public int JetResizeDatabase(JET_SESID sesid, JET_DBID dbid, int desiredPages, out int actualPages, ResizeDatabaseGrbit grbit)
	{
		CheckSupportsWindows8Features("JetResizeDatabase");
		CheckNotNegative(desiredPages, "desiredPages");
		uint pcpgActual = 0u;
		checked
		{
			int result = Err(NativeMethods.JetResizeDatabase(sesid.Value, dbid.Value, (uint)desiredPages, out pcpgActual, (uint)grbit));
			actualPages = (int)pcpgActual;
			return result;
		}
	}

	public int JetCreateIndex4(JET_SESID sesid, JET_TABLEID tableid, JET_INDEXCREATE[] indexcreates, int numIndexCreates)
	{
		CheckSupportsWindows8Features("JetCreateIndex4");
		CheckNotNull(indexcreates, "indexcreates");
		CheckNotNegative(numIndexCreates, "numIndexCreates");
		if (numIndexCreates > indexcreates.Length)
		{
			throw new ArgumentOutOfRangeException("numIndexCreates", numIndexCreates, "numIndexCreates is larger than the number of indexes passed in");
		}
		return CreateIndexes3(sesid, tableid, indexcreates, numIndexCreates);
	}

	public unsafe int JetOpenTemporaryTable2(JET_SESID sesid, JET_OPENTEMPORARYTABLE temporarytable)
	{
		CheckSupportsWindows8Features("JetOpenTemporaryTable2");
		CheckNotNull(temporarytable, "temporarytable");
		NATIVE_OPENTEMPORARYTABLE2 popentemporarytable = temporarytable.GetNativeOpenTemporaryTable2();
		uint[] array = new uint[popentemporarytable.ccolumn];
		NATIVE_COLUMNDEF[] nativecolumndefs = GetNativecolumndefs(temporarytable.prgcolumndef, temporarytable.ccolumn);
		using GCHandleCollection gCHandleCollection = default(GCHandleCollection);
		popentemporarytable.prgcolumndef = (NATIVE_COLUMNDEF*)(void*)gCHandleCollection.Add(nativecolumndefs);
		popentemporarytable.rgcolumnid = (uint*)(void*)gCHandleCollection.Add(array);
		if (temporarytable.pidxunicode != null)
		{
			NATIVE_UNICODEINDEX2 nativeUnicodeIndex = temporarytable.pidxunicode.GetNativeUnicodeIndex2();
			nativeUnicodeIndex.szLocaleName = gCHandleCollection.Add(Util.ConvertToNullTerminatedUnicodeByteArray(temporarytable.pidxunicode.GetEffectiveLocaleName()));
			popentemporarytable.pidxunicode = (NATIVE_UNICODEINDEX2*)(void*)gCHandleCollection.Add(nativeUnicodeIndex);
		}
		int result = Err(NativeMethods.JetOpenTemporaryTable2(sesid.Value, ref popentemporarytable));
		SetColumnids(temporarytable.prgcolumndef, temporarytable.prgcolumnid, array, temporarytable.ccolumn);
		temporarytable.tableid = new JET_TABLEID
		{
			Value = popentemporarytable.tableid
		};
		return result;
	}

	public int JetCreateTableColumnIndex4(JET_SESID sesid, JET_DBID dbid, JET_TABLECREATE tablecreate)
	{
		CheckSupportsWindows8Features("JetCreateTableColumnIndex4");
		CheckNotNull(tablecreate, "tablecreate");
		return CreateTableColumnIndex4(sesid, dbid, tablecreate);
	}

	public int JetGetSessionParameter(JET_SESID sesid, JET_sesparam sesparamid, out int value)
	{
		CheckSupportsWindows8Features("JetGetSessionParameter");
		int actualDataSize;
		int num = NativeMethods.JetGetSessionParameter(sesid.Value, checked((uint)sesparamid), out value, 4, out actualDataSize);
		if (num >= 0 && actualDataSize != 4)
		{
			throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Bad return value. Unexpected data size returned. Expected {0}, but received {1}.", 4, actualDataSize), "sesparamid");
		}
		return Err(num);
	}

	public int JetGetSessionParameter(JET_SESID sesid, JET_sesparam sesparamid, byte[] data, int length, out int actualDataSize)
	{
		CheckSupportsWindows8Features("JetGetSessionParameter");
		CheckDataSize(data, length, "length");
		return Err(NativeMethods.JetGetSessionParameter(sesid.Value, checked((uint)sesparamid), data, length, out actualDataSize));
	}

	public int JetSetSessionParameter(JET_SESID sesid, JET_sesparam sesparamid, int valueToSet)
	{
		CheckSupportsWindows8Features("JetSetSessionParameter");
		return Err(NativeMethods.JetSetSessionParameter(sesid.Value, checked((uint)sesparamid), ref valueToSet, 4));
	}

	public int JetSetSessionParameter(JET_SESID sesid, JET_sesparam sesparamid, byte[] data, int dataSize)
	{
		CheckSupportsWindows8Features("JetSetSessionParameter");
		CheckNotNegative(dataSize, "dataSize");
		CheckDataSize(data, dataSize, "dataSize");
		return Err(NativeMethods.JetSetSessionParameter(sesid.Value, checked((uint)sesparamid), data, dataSize));
	}

	public int JetGetIndexInfo(JET_SESID sesid, JET_DBID dbid, string tablename, string indexname, out JET_INDEXCREATE result, JET_IdxInfo infoLevel)
	{
		CheckNotNull(tablename, "tablename");
		if ((uint)(infoLevel - 11) > 2u)
		{
			throw new ArgumentException(string.Format("{0} is not a valid value JET_IdxInfo for this JET_INDEXCREATE overload."));
		}
		checked
		{
			int result2;
			if (Capabilities.SupportsWindows8Features)
			{
				int num = 10 * Marshal.SizeOf(typeof(NATIVE_INDEXCREATE3));
				IntPtr intPtr = Marshal.AllocHGlobal(num);
				try
				{
					infoLevel = (JET_IdxInfo)13;
					result2 = Err(NativeMethods.JetGetIndexInfoW(sesid.Value, dbid.Value, tablename, indexname, intPtr, (uint)num, (uint)infoLevel));
					NATIVE_INDEXCREATE3 value = (NATIVE_INDEXCREATE3)Marshal.PtrToStructure(intPtr, typeof(NATIVE_INDEXCREATE3));
					result = new JET_INDEXCREATE();
					result.SetAllFromNativeIndexCreate(ref value);
				}
				finally
				{
					Marshal.FreeHGlobal(intPtr);
				}
			}
			else
			{
				result = null;
				result2 = Err(-1001);
			}
			return result2;
		}
	}

	public int JetGetTableIndexInfo(JET_SESID sesid, JET_TABLEID tableid, string indexname, out JET_INDEXCREATE result, JET_IdxInfo infoLevel)
	{
		if ((uint)(infoLevel - 11) > 2u)
		{
			throw new ArgumentException(string.Format("{0} is not a valid value JET_IdxInfo for this JET_INDEXCREATE overload."));
		}
		checked
		{
			int result2;
			if (Capabilities.SupportsWindows8Features)
			{
				int num = 10 * Marshal.SizeOf(typeof(NATIVE_INDEXCREATE3));
				IntPtr intPtr = Marshal.AllocHGlobal(num);
				try
				{
					infoLevel = (JET_IdxInfo)13;
					result2 = Err(NativeMethods.JetGetTableIndexInfoW(sesid.Value, tableid.Value, indexname, intPtr, (uint)num, (uint)infoLevel));
					NATIVE_INDEXCREATE3 value = (NATIVE_INDEXCREATE3)Marshal.PtrToStructure(intPtr, typeof(NATIVE_INDEXCREATE3));
					result = new JET_INDEXCREATE();
					result.SetAllFromNativeIndexCreate(ref value);
				}
				finally
				{
					Marshal.FreeHGlobal(intPtr);
				}
			}
			else
			{
				result = null;
				result2 = Err(-1001);
			}
			return result2;
		}
	}

	public int JetPrereadIndexRanges(JET_SESID sesid, JET_TABLEID tableid, JET_INDEX_RANGE[] indexRanges, int rangeIndex, int rangeCount, out int rangesPreread, JET_COLUMNID[] columnsPreread, PrereadIndexRangesGrbit grbit)
	{
		CheckSupportsWindows8Features("JetPrereadIndexRanges");
		CheckNotNull(indexRanges, "indexRanges");
		CheckDataSize(indexRanges, rangeIndex, "rangeIndex", rangeCount, "rangeCount");
		GCHandleCollection handles = default(GCHandleCollection);
		checked
		{
			try
			{
				NATIVE_INDEX_RANGE[] array = new NATIVE_INDEX_RANGE[rangeCount];
				for (int i = 0; i < rangeCount; i++)
				{
					array[i] = indexRanges[i + rangeIndex].GetNativeIndexRange(ref handles);
				}
				if (columnsPreread != null)
				{
					uint[] array2 = new uint[columnsPreread.Length];
					for (int j = 0; j < columnsPreread.Length; j++)
					{
						array2[j] = columnsPreread[j].Value;
					}
					return Err(NativeMethods.JetPrereadIndexRanges(sesid.Value, tableid.Value, array, (uint)rangeCount, out rangesPreread, array2, (uint)columnsPreread.Length, (uint)grbit));
				}
				return Err(NativeMethods.JetPrereadIndexRanges(sesid.Value, tableid.Value, array, (uint)rangeCount, out rangesPreread, null, 0u, (uint)grbit));
			}
			finally
			{
				handles.Dispose();
			}
		}
	}

	public int JetPrereadKeyRanges(JET_SESID sesid, JET_TABLEID tableid, byte[][] keysStart, int[] keyStartLengths, byte[][] keysEnd, int[] keyEndLengths, int rangeIndex, int rangeCount, out int rangesPreread, JET_COLUMNID[] columnsPreread, PrereadIndexRangesGrbit grbit)
	{
		CheckSupportsWindows8Features("JetPrereadKeyRanges");
		CheckDataSize(keysStart, rangeIndex, "rangeIndex", rangeCount, "rangeCount");
		CheckDataSize(keyStartLengths, rangeIndex, "rangeIndex", rangeCount, "rangeCount");
		CheckNotNull(keysStart, "keysStart");
		if (keysEnd != null)
		{
			CheckNotNull(keyEndLengths, "keyEndLengths");
			CheckDataSize(keysEnd, rangeIndex, "rangeIndex", rangeCount, "rangeCount");
		}
		if (keyEndLengths != null)
		{
			CheckNotNull(keysEnd, "keysEnd");
			CheckDataSize(keyEndLengths, rangeIndex, "rangeIndex", rangeCount, "rangeCount");
		}
		grbit |= PrereadIndexRangesGrbit.NormalizedKey;
		checked
		{
			using GCHandleCollection gCHandleCollection = default(GCHandleCollection);
			NATIVE_INDEX_RANGE[] array = new NATIVE_INDEX_RANGE[rangeCount];
			for (int i = 0; i < rangeCount; i++)
			{
				NATIVE_INDEX_COLUMN[] array2 = new NATIVE_INDEX_COLUMN[1];
				array2[0].pvData = gCHandleCollection.Add(keysStart[i + rangeIndex]);
				array2[0].cbData = (uint)keyStartLengths[i + rangeIndex];
				array[i].rgStartColumns = gCHandleCollection.Add(array2);
				array[i].cStartColumns = 1u;
				if (keysEnd != null)
				{
					NATIVE_INDEX_COLUMN[] array3 = new NATIVE_INDEX_COLUMN[1];
					array3[0].pvData = gCHandleCollection.Add(keysEnd[i + rangeIndex]);
					array3[0].cbData = (uint)keyEndLengths[i + rangeIndex];
					array[i].rgEndColumns = gCHandleCollection.Add(array3);
					array[i].cEndColumns = 1u;
				}
			}
			if (columnsPreread != null)
			{
				uint[] array4 = new uint[columnsPreread.Length];
				for (int j = 0; j < columnsPreread.Length; j++)
				{
					array4[j] = columnsPreread[j].Value;
				}
				return Err(NativeMethods.JetPrereadIndexRanges(sesid.Value, tableid.Value, array, (uint)rangeCount, out rangesPreread, array4, (uint)columnsPreread.Length, (uint)grbit));
			}
			return Err(NativeMethods.JetPrereadIndexRanges(sesid.Value, tableid.Value, array, (uint)rangeCount, out rangesPreread, null, 0u, (uint)grbit));
		}
	}

	public int JetSetCursorFilter(JET_SESID sesid, JET_TABLEID tableid, JET_INDEX_COLUMN[] filters, CursorFilterGrbit grbit)
	{
		CheckSupportsWindows8Features("JetSetCursorFilter");
		checked
		{
			if (filters == null || filters.Length == 0)
			{
				return Err(NativeMethods.JetSetCursorFilter(sesid.Value, tableid.Value, null, 0u, (uint)grbit));
			}
			GCHandleCollection handles = default(GCHandleCollection);
			try
			{
				NATIVE_INDEX_COLUMN[] array = new NATIVE_INDEX_COLUMN[filters.Length];
				for (int i = 0; i < filters.Length; i++)
				{
					array[i] = filters[i].GetNativeIndexColumn(ref handles);
				}
				return Err(NativeMethods.JetSetCursorFilter(sesid.Value, tableid.Value, array, (uint)filters.Length, (uint)grbit));
			}
			finally
			{
				handles.Dispose();
			}
		}
	}

	private unsafe static NATIVE_INDEXCREATE3[] GetNativeIndexCreate3s(IList<JET_INDEXCREATE> managedIndexCreates, ref GCHandleCollection handles)
	{
		NATIVE_INDEXCREATE3[] array = null;
		if (managedIndexCreates != null && managedIndexCreates.Count > 0)
		{
			array = new NATIVE_INDEXCREATE3[managedIndexCreates.Count];
			for (int i = 0; i < managedIndexCreates.Count; i = checked(i + 1))
			{
				array[i] = managedIndexCreates[i].GetNativeIndexcreate3();
				if (managedIndexCreates[i].pidxUnicode != null)
				{
					NATIVE_UNICODEINDEX2 nativeUnicodeIndex = managedIndexCreates[i].pidxUnicode.GetNativeUnicodeIndex2();
					nativeUnicodeIndex.szLocaleName = handles.Add(Util.ConvertToNullTerminatedUnicodeByteArray(managedIndexCreates[i].pidxUnicode.GetEffectiveLocaleName()));
					array[i].pidxUnicode = (NATIVE_UNICODEINDEX2*)(void*)handles.Add(nativeUnicodeIndex);
					array[i].grbit |= 2048u;
				}
				array[i].szKey = handles.Add(Util.ConvertToNullTerminatedUnicodeByteArray(managedIndexCreates[i].szKey));
				array[i].szIndexName = handles.Add(Util.ConvertToNullTerminatedUnicodeByteArray(managedIndexCreates[i].szIndexName));
				array[i].rgconditionalcolumn = GetNativeConditionalColumns(managedIndexCreates[i].rgconditionalcolumn, useUnicodeData: true, ref handles);
				if (managedIndexCreates[i].pSpaceHints != null)
				{
					NATIVE_SPACEHINTS nativeSpaceHints = managedIndexCreates[i].pSpaceHints.GetNativeSpaceHints();
					array[i].pSpaceHints = handles.Add(nativeSpaceHints);
				}
			}
		}
		return array;
	}

	private static int CreateIndexes3(JET_SESID sesid, JET_TABLEID tableid, IList<JET_INDEXCREATE> indexcreates, int numIndexCreates)
	{
		GCHandleCollection handles = default(GCHandleCollection);
		try
		{
			NATIVE_INDEXCREATE3[] nativeIndexCreate3s = GetNativeIndexCreate3s(indexcreates, ref handles);
			return Err(NativeMethods.JetCreateIndex4W(sesid.Value, tableid.Value, nativeIndexCreate3s, checked((uint)numIndexCreates)));
		}
		finally
		{
			handles.Dispose();
		}
	}

	private unsafe static int CreateTableColumnIndex4(JET_SESID sesid, JET_DBID dbid, JET_TABLECREATE tablecreate)
	{
		NATIVE_TABLECREATE4 tablecreate2 = tablecreate.GetNativeTableCreate4();
		GCHandleCollection handles = default(GCHandleCollection);
		try
		{
			tablecreate2.rgcolumncreate = (NATIVE_COLUMNCREATE*)(void*)GetNativeColumnCreates(tablecreate.rgcolumncreate, useUnicodeData: true, ref handles);
			NATIVE_INDEXCREATE3[] nativeIndexCreate3s = GetNativeIndexCreate3s(tablecreate.rgindexcreate, ref handles);
			tablecreate2.rgindexcreate = handles.Add(nativeIndexCreate3s);
			if (tablecreate.pSeqSpacehints != null)
			{
				NATIVE_SPACEHINTS nativeSpaceHints = tablecreate.pSeqSpacehints.GetNativeSpaceHints();
				tablecreate2.pSeqSpacehints = (NATIVE_SPACEHINTS*)(void*)handles.Add(nativeSpaceHints);
			}
			if (tablecreate.pLVSpacehints != null)
			{
				NATIVE_SPACEHINTS nativeSpaceHints2 = tablecreate.pLVSpacehints.GetNativeSpaceHints();
				tablecreate2.pLVSpacehints = (NATIVE_SPACEHINTS*)(void*)handles.Add(nativeSpaceHints2);
			}
			int err = NativeMethods.JetCreateTableColumnIndex4W(sesid.Value, dbid.Value, ref tablecreate2);
			tablecreate.tableid = new JET_TABLEID
			{
				Value = tablecreate2.tableid
			};
			checked
			{
				tablecreate.cCreated = (int)tablecreate2.cCreated;
				if (tablecreate.rgcolumncreate != null)
				{
					for (int i = 0; i < tablecreate.rgcolumncreate.Length; i++)
					{
						unchecked
						{
							tablecreate.rgcolumncreate[i].SetFromNativeColumnCreate(ref *(NATIVE_COLUMNCREATE*)((byte*)tablecreate2.rgcolumncreate + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_COLUMNCREATE)))));
						}
					}
				}
				if (tablecreate.rgindexcreate != null)
				{
					for (int j = 0; j < tablecreate.rgindexcreate.Length; j++)
					{
						tablecreate.rgindexcreate[j].SetFromNativeIndexCreate(ref nativeIndexCreate3s[j]);
					}
				}
				return Err(err);
			}
		}
		finally
		{
			handles.Dispose();
		}
	}

	internal static void ReportUnhandledException(Exception exception, string description)
	{
	}

	private void DetermineCapabilities()
	{
		Capabilities = new JetCapabilities
		{
			ColumnsKeyMost = 12
		};
		uint versionFromEsent = versionOverride;
		if (versionFromEsent == 0)
		{
			versionFromEsent = GetVersionFromEsent();
		}
		int num = checked((int)((versionFromEsent & 0xFFFFFF) >> 8));
		if (num >= 2700)
		{
			Capabilities.SupportsServer2003Features = true;
		}
		if (num >= 6000)
		{
			Capabilities.SupportsVistaFeatures = true;
			Capabilities.SupportsUnicodePaths = true;
			Capabilities.SupportsLargeKeys = true;
			Capabilities.ColumnsKeyMost = 16;
		}
		if (num >= 7000)
		{
			Capabilities.SupportsWindows7Features = true;
		}
		if (num >= 8000)
		{
			Capabilities.SupportsWindows8Features = true;
		}
		if (num >= 9300)
		{
			Capabilities.SupportsWindows81Features = true;
		}
		if (num >= 9900)
		{
			Capabilities.SupportsWindows10Features = true;
		}
	}

	private uint GetVersionFromEsent()
	{
		string name = string.Format(CultureInfo.InvariantCulture, "GettingEsentVersion{0}", LibraryHelpers.GetCurrentManagedThreadId());
		JET_INSTANCE instance = JET_INSTANCE.Nil;
		RuntimeHelpers.PrepareConstrainedRegions();
		try
		{
			JetCreateInstance(out instance, name);
			JetSetSystemParameter(instance, JET_SESID.Nil, JET_param.Recovery, new IntPtr(0), "off");
			JetSetSystemParameter(instance, JET_SESID.Nil, JET_param.NoInformationEvent, new IntPtr(1), null);
			JetSetSystemParameter(instance, JET_SESID.Nil, JET_param.MaxTemporaryTables, new IntPtr(0), null);
			JetSetSystemParameter(instance, JET_SESID.Nil, JET_param.MaxCursors, new IntPtr(16), null);
			JetSetSystemParameter(instance, JET_SESID.Nil, JET_param.MaxOpenTables, new IntPtr(16), null);
			JetSetSystemParameter(instance, JET_SESID.Nil, JET_param.MaxVerPages, new IntPtr(4), null);
			JetSetSystemParameter(instance, JET_SESID.Nil, JET_param.MaxSessions, new IntPtr(1), null);
			JetInit(ref instance);
			JetBeginSession(instance, out var sesid, string.Empty, string.Empty);
			try
			{
				JetGetVersion(sesid, out var version);
				return version;
			}
			finally
			{
				JetEndSession(sesid, EndSessionGrbit.None);
			}
		}
		finally
		{
			if (JET_INSTANCE.Nil != instance)
			{
				JetTerm(instance);
			}
		}
	}
}
