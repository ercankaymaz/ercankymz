using System.Configuration;
using System.Runtime.Versioning;

namespace System.Runtime.Caching.Configuration;

[UnsupportedOSPlatform("browser")]
[ConfigurationCollection(/*Could not decode attribute arguments.*/)]
internal sealed class MemoryCacheSettingsCollection : ConfigurationElementCollection
{
	private static readonly ConfigurationPropertyCollection s_properties = new ConfigurationPropertyCollection();

	protected override ConfigurationPropertyCollection Properties => s_properties;

	public MemoryCacheElement this[int index]
	{
		get
		{
			return (MemoryCacheElement)(object)((ConfigurationElementCollection)this).BaseGet(index);
		}
		set
		{
			if (((ConfigurationElementCollection)this).BaseGet(index) != null)
			{
				((ConfigurationElementCollection)this).BaseRemoveAt(index);
			}
			((ConfigurationElementCollection)this).BaseAdd(index, (ConfigurationElement)(object)value);
		}
	}

	public MemoryCacheElement this[string key] => (MemoryCacheElement)(object)((ConfigurationElementCollection)this).BaseGet((object)key);

	public override ConfigurationElementCollectionType CollectionType => (ConfigurationElementCollectionType)3;

	public int IndexOf(MemoryCacheElement cache)
	{
		return ((ConfigurationElementCollection)this).BaseIndexOf((ConfigurationElement)(object)cache);
	}

	public void Add(MemoryCacheElement cache)
	{
		((ConfigurationElementCollection)this).BaseAdd((ConfigurationElement)(object)cache);
	}

	public void Remove(MemoryCacheElement cache)
	{
		((ConfigurationElementCollection)this).BaseRemove((object)cache.Name);
	}

	public void RemoveAt(int index)
	{
		((ConfigurationElementCollection)this).BaseRemoveAt(index);
	}

	public void Clear()
	{
		((ConfigurationElementCollection)this).BaseClear();
	}

	protected override ConfigurationElement CreateNewElement()
	{
		return (ConfigurationElement)(object)new MemoryCacheElement();
	}

	protected override ConfigurationElement CreateNewElement(string elementName)
	{
		return (ConfigurationElement)(object)new MemoryCacheElement(elementName);
	}

	protected override object GetElementKey(ConfigurationElement element)
	{
		return ((MemoryCacheElement)(object)element).Name;
	}
}
