namespace ACadSharp.Objects.Collections;

public class MaterialCollection : ObjectDictionaryCollection<Material>
{
	public MaterialCollection(CadDictionary dictionary)
		: base(dictionary)
	{
	}

	public void CreateDefaults()
	{
		_dictionary.TryAdd(new Material("Global"));
		_dictionary.TryAdd(new Material("ByLayer"));
		_dictionary.TryAdd(new Material("ByBlock"));
	}
}
