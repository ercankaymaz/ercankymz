using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Extensions.Logging;

[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(1)]
[ComVisible(true)]
public interface ISupportExternalScope
{
	void SetScopeProvider(IExternalScopeProvider scopeProvider);
}
