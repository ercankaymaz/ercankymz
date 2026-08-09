using System.Configuration;
using System.Runtime.Versioning;

namespace System.Runtime.Caching.Configuration;

[UnsupportedOSPlatform("browser")]
internal sealed class CachingSectionGroup : ConfigurationSectionGroup
{
	[ConfigurationProperty("memoryCache")]
	public MemoryCacheSection MemoryCaches => (MemoryCacheSection)(object)((ConfigurationSectionGroup)this).Sections["memoryCache"];
}
