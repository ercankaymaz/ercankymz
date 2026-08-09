using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace buPop3.Common.Logging;

public class FileLogger : ILog
{
	private static readonly object object_0;

	[CompilerGenerated]
	private static bool bool_0;

	[CompilerGenerated]
	private static bool bool_1;

	[CompilerGenerated]
	private static FileInfo fileInfo_0;

	public static bool Enabled
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public static bool Verbose
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	public static FileInfo LogFile
	{
		[CompilerGenerated]
		get
		{
			return fileInfo_0;
		}
		[CompilerGenerated]
		set
		{
			fileInfo_0 = value;
		}
	}

	static FileLogger()
	{
		LogFile = new FileInfo("buPop3.log");
		Enabled = true;
		Verbose = false;
		object_0 = new object();
	}

	private static void smethod_0(string string_0)
	{
		if (string_0 != null)
		{
			lock (object_0)
			{
				using StreamWriter streamWriter = LogFile.AppendText();
				streamWriter.WriteLine(DateTime.Now.ToString() + " " + string_0);
				streamWriter.Flush();
				return;
			}
		}
		throw new ArgumentNullException("text");
	}

	public void LogError(string message)
	{
		if (Enabled)
		{
			smethod_0(message);
		}
	}

	public void LogDebug(string message)
	{
		if (Enabled && Verbose)
		{
			smethod_0("DEBUG: " + message);
		}
	}
}
