using System.Runtime.InteropServices;

namespace Microsoft.Extensions.Logging;

[ComVisible(true)]
public class LogDefineOptions
{
	public bool SkipEnabledCheck { get; set; }
}
