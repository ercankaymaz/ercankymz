namespace ACadSharp.Objects.Collections;

public class MLineStyleCollection : ObjectDictionaryCollection<MLineStyle>
{
	public MLineStyleCollection(CadDictionary dictionary)
		: base(dictionary)
	{
	}

	public void CreateDefaults()
	{
		_dictionary.TryAdd(MLineStyle.Default);
	}
}
