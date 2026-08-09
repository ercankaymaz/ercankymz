using System.Runtime.InteropServices;

namespace Microsoft.Extensions.Logging;

[ComVisible(true)]
public enum LogLevel
{
	Trace,
	Debug,
	Information,
	Warning,
	Error,
	Critical,
	None
}
