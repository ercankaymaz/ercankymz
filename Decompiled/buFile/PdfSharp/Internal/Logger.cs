#define DEBUG
using System.Diagnostics;

namespace PdfSharp.Internal;

internal static class Logger
{
	public static void Log(string format, params object[] args)
	{
		Debug.WriteLine("Log...");
	}
}
