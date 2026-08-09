using System.Configuration;
using System.Runtime.Versioning;

namespace System.Runtime.Caching.Configuration;

[UnsupportedOSPlatform("browser")]
internal sealed class MemoryCacheSection : ConfigurationSection
{
	private static readonly ConfigurationProperty s_propNamedCaches = new ConfigurationProperty("namedCaches", typeof(MemoryCacheSettingsCollection), (object)null, (ConfigurationPropertyOptions)0);

	private static readonly ConfigurationPropertyCollection s_properties;

	protected override ConfigurationPropertyCollection Properties => s_properties;

	[ConfigurationProperty("namedCaches")]
	public MemoryCacheSettingsCollection NamedCaches => (MemoryCacheSettingsCollection)((ConfigurationElement)this)[s_propNamedCaches];

	static MemoryCacheSection()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		ConfigurationPropertyCollection val = new ConfigurationPropertyCollection();
		val.Add(s_propNamedCaches);
		s_properties = val;
	}
}
