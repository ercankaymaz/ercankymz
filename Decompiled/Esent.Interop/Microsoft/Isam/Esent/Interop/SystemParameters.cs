namespace Microsoft.Isam.Esent.Interop;

public static class SystemParameters
{
	public const int BaseNameLength = 3;

	public const int NameMost = 64;

	public const int ColumnMost = 255;

	public const int ColumnsMost = 65248;

	public const int ColumnsFixedMost = 127;

	public const int ColumnsVarMost = 128;

	public const int ColumnsTaggedMost = 64993;

	public const int PageTempDBSmallest = 14;

	public const int LocaleNameMaxLength = 85;

	public static int CacheSizeMax
	{
		get
		{
			return GetIntegerParameter(JET_param.CacheSizeMax);
		}
		set
		{
			SetIntegerParameter(JET_param.CacheSizeMax, value);
		}
	}

	public static int CacheSize
	{
		get
		{
			return GetIntegerParameter(JET_param.CacheSize);
		}
		set
		{
			SetIntegerParameter(JET_param.CacheSize, value);
		}
	}

	public static int DatabasePageSize
	{
		get
		{
			return GetIntegerParameter(JET_param.DatabasePageSize);
		}
		set
		{
			SetIntegerParameter(JET_param.DatabasePageSize, value);
		}
	}

	public static int CacheSizeMin
	{
		get
		{
			return GetIntegerParameter(JET_param.CacheSizeMin);
		}
		set
		{
			SetIntegerParameter(JET_param.CacheSizeMin, value);
		}
	}

	public static int OutstandingIOMax
	{
		get
		{
			return GetIntegerParameter(JET_param.OutstandingIOMax);
		}
		set
		{
			SetIntegerParameter(JET_param.OutstandingIOMax, value);
		}
	}

	public static int StartFlushThreshold
	{
		get
		{
			return GetIntegerParameter(JET_param.StartFlushThreshold);
		}
		set
		{
			SetIntegerParameter(JET_param.StartFlushThreshold, value);
		}
	}

	public static int StopFlushThreshold
	{
		get
		{
			return GetIntegerParameter(JET_param.StopFlushThreshold);
		}
		set
		{
			SetIntegerParameter(JET_param.StopFlushThreshold, value);
		}
	}

	public static int MaxInstances
	{
		get
		{
			return GetIntegerParameter(JET_param.MaxInstances);
		}
		set
		{
			SetIntegerParameter(JET_param.MaxInstances, value);
		}
	}

	public static int EventLoggingLevel
	{
		get
		{
			return GetIntegerParameter(JET_param.EventLoggingLevel);
		}
		set
		{
			SetIntegerParameter(JET_param.EventLoggingLevel, value);
		}
	}

	public static int KeyMost
	{
		get
		{
			if (EsentVersion.SupportsVistaFeatures)
			{
				return GetIntegerParameter((JET_param)134);
			}
			return 255;
		}
	}

	public static int ColumnsKeyMost => Api.Impl.Capabilities.ColumnsKeyMost;

	public static int BookmarkMost => checked(KeyMost + 1);

	public static int LVChunkSizeMost
	{
		get
		{
			if (EsentVersion.SupportsWindows7Features)
			{
				return GetIntegerParameter((JET_param)163);
			}
			return checked(GetIntegerParameter(JET_param.DatabasePageSize) - 82);
		}
	}

	public static int Configuration
	{
		get
		{
			if (EsentVersion.SupportsVistaFeatures)
			{
				return GetIntegerParameter((JET_param)129);
			}
			return 1;
		}
		set
		{
			if (EsentVersion.SupportsVistaFeatures)
			{
				SetIntegerParameter((JET_param)129, value);
			}
		}
	}

	public static bool EnableAdvanced
	{
		get
		{
			if (EsentVersion.SupportsVistaFeatures)
			{
				return GetBoolParameter((JET_param)130);
			}
			return true;
		}
		set
		{
			if (EsentVersion.SupportsVistaFeatures)
			{
				SetBoolParameter((JET_param)130, value);
			}
		}
	}

	public static int LegacyFileNames
	{
		get
		{
			if (EsentVersion.SupportsVistaFeatures)
			{
				return GetIntegerParameter((JET_param)136);
			}
			return 1;
		}
		set
		{
			if (EsentVersion.SupportsVistaFeatures)
			{
				SetIntegerParameter((JET_param)136, value);
			}
		}
	}

	public static JET_ExceptionAction ExceptionAction
	{
		get
		{
			return (JET_ExceptionAction)GetIntegerParameter(JET_param.ExceptionAction);
		}
		set
		{
			SetIntegerParameter(JET_param.ExceptionAction, (int)value);
		}
	}

	public static bool EnableFileCache
	{
		get
		{
			if (EsentVersion.SupportsVistaFeatures)
			{
				return GetBoolParameter((JET_param)126);
			}
			return false;
		}
		set
		{
			if (EsentVersion.SupportsVistaFeatures)
			{
				SetBoolParameter((JET_param)126, value);
			}
		}
	}

	public static bool EnableViewCache
	{
		get
		{
			if (EsentVersion.SupportsVistaFeatures)
			{
				return GetBoolParameter((JET_param)127);
			}
			return false;
		}
		set
		{
			if (EsentVersion.SupportsVistaFeatures)
			{
				SetBoolParameter((JET_param)127, value);
			}
		}
	}

	public static int MinDataForXpress
	{
		get
		{
			return GetIntegerParameter((JET_param)183);
		}
		set
		{
			SetIntegerParameter((JET_param)183, value);
		}
	}

	public static int HungIOThreshold
	{
		get
		{
			return GetIntegerParameter((JET_param)181);
		}
		set
		{
			SetIntegerParameter((JET_param)181, value);
		}
	}

	public static int HungIOActions
	{
		get
		{
			return GetIntegerParameter((JET_param)182);
		}
		set
		{
			SetIntegerParameter((JET_param)182, value);
		}
	}

	public static string ProcessFriendlyName
	{
		get
		{
			return GetStringParameter((JET_param)186);
		}
		set
		{
			SetStringParameter((JET_param)186, value);
		}
	}

	private static void SetStringParameter(JET_param param, string value)
	{
		Api.JetSetSystemParameter(JET_INSTANCE.Nil, JET_SESID.Nil, param, 0, value);
	}

	private static string GetStringParameter(JET_param param)
	{
		int paramValue = 0;
		Api.JetGetSystemParameter(JET_INSTANCE.Nil, JET_SESID.Nil, param, ref paramValue, out var paramString, 1024);
		return paramString;
	}

	private static void SetIntegerParameter(JET_param param, int value)
	{
		Api.JetSetSystemParameter(JET_INSTANCE.Nil, JET_SESID.Nil, param, value, null);
	}

	private static int GetIntegerParameter(JET_param param)
	{
		int paramValue = 0;
		Api.JetGetSystemParameter(JET_INSTANCE.Nil, JET_SESID.Nil, param, ref paramValue, out var _, 0);
		return paramValue;
	}

	private static void SetBoolParameter(JET_param param, bool value)
	{
		int paramValue = (value ? 1 : 0);
		Api.JetSetSystemParameter(JET_INSTANCE.Nil, JET_SESID.Nil, param, paramValue, null);
	}

	private static bool GetBoolParameter(JET_param param)
	{
		int paramValue = 0;
		Api.JetGetSystemParameter(JET_INSTANCE.Nil, JET_SESID.Nil, param, ref paramValue, out var _, 0);
		return paramValue != 0;
	}
}
