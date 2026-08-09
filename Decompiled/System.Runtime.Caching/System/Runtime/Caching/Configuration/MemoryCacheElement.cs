using System.ComponentModel;
using System.Configuration;
using System.Runtime.Versioning;

namespace System.Runtime.Caching.Configuration;

[UnsupportedOSPlatform("browser")]
internal sealed class MemoryCacheElement : ConfigurationElement
{
	private static readonly ConfigurationProperty s_propName = new ConfigurationProperty("name", typeof(string), (object)null, (TypeConverter)new WhiteSpaceTrimStringConverter(), (ConfigurationValidatorBase)new StringValidator(1), (ConfigurationPropertyOptions)6);

	private static readonly ConfigurationProperty s_propPhysicalMemoryLimitPercentage = new ConfigurationProperty("physicalMemoryLimitPercentage", typeof(int), (object)0, (TypeConverter)null, (ConfigurationValidatorBase)new IntegerValidator(0, 100), (ConfigurationPropertyOptions)0);

	private static readonly ConfigurationProperty s_propCacheMemoryLimitMegabytes = new ConfigurationProperty("cacheMemoryLimitMegabytes", typeof(int), (object)0, (TypeConverter)null, (ConfigurationValidatorBase)new IntegerValidator(0, int.MaxValue), (ConfigurationPropertyOptions)0);

	private static readonly ConfigurationProperty s_propPollingInterval = new ConfigurationProperty("pollingInterval", typeof(TimeSpan), (object)TimeSpan.FromMilliseconds(120000.0), (TypeConverter)new InfiniteTimeSpanConverter(), (ConfigurationValidatorBase)new PositiveTimeSpanValidator(), (ConfigurationPropertyOptions)0);

	private static readonly ConfigurationPropertyCollection s_properties;

	protected override ConfigurationPropertyCollection Properties => s_properties;

	[ConfigurationProperty("name", DefaultValue = "", IsRequired = true, IsKey = true)]
	[TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
	[StringValidator(MinLength = 1)]
	public string Name
	{
		get
		{
			return (string)((ConfigurationElement)this)["name"];
		}
		set
		{
			((ConfigurationElement)this)["name"] = value;
		}
	}

	[ConfigurationProperty("physicalMemoryLimitPercentage", DefaultValue = 0)]
	[IntegerValidator(MinValue = 0, MaxValue = 100)]
	public int PhysicalMemoryLimitPercentage
	{
		get
		{
			return (int)((ConfigurationElement)this)["physicalMemoryLimitPercentage"];
		}
		set
		{
			((ConfigurationElement)this)["physicalMemoryLimitPercentage"] = value;
		}
	}

	[ConfigurationProperty("cacheMemoryLimitMegabytes", DefaultValue = 0)]
	[IntegerValidator(MinValue = 0)]
	public int CacheMemoryLimitMegabytes
	{
		get
		{
			return (int)((ConfigurationElement)this)["cacheMemoryLimitMegabytes"];
		}
		set
		{
			((ConfigurationElement)this)["cacheMemoryLimitMegabytes"] = value;
		}
	}

	[ConfigurationProperty("pollingInterval", DefaultValue = "00:02:00")]
	[TypeConverter(typeof(InfiniteTimeSpanConverter))]
	public TimeSpan PollingInterval
	{
		get
		{
			return (TimeSpan)((ConfigurationElement)this)["pollingInterval"];
		}
		set
		{
			((ConfigurationElement)this)["pollingInterval"] = value;
		}
	}

	internal MemoryCacheElement()
	{
	}

	public MemoryCacheElement(string name)
	{
		Name = name;
	}

	static MemoryCacheElement()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0021: Expected O, but got Unknown
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		//IL_00ad: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		ConfigurationPropertyCollection val = new ConfigurationPropertyCollection();
		val.Add(s_propName);
		val.Add(s_propPhysicalMemoryLimitPercentage);
		val.Add(s_propCacheMemoryLimitMegabytes);
		val.Add(s_propPollingInterval);
		s_properties = val;
	}
}
