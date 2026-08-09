using System;
using System.Runtime.CompilerServices;

namespace buPop3.Common.Logging;

public static class DefaultLogger
{
	[CompilerGenerated]
	private static ILog ilog_0;

	public static ILog Log
	{
		[CompilerGenerated]
		get
		{
			return ilog_0;
		}
		[CompilerGenerated]
		private set
		{
			ilog_0 = value;
		}
	}

	static DefaultLogger()
	{
		Log = new DiagnosticsLogger();
	}

	public static void SetLog(ILog newLogger)
	{
		if (newLogger == null)
		{
			throw new ArgumentNullException("newLogger");
		}
		Log = newLogger;
	}
}
