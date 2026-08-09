namespace ACadSharp.Objects.Collections;

public class MLeaderStyleCollection : ObjectDictionaryCollection<MultiLeaderStyle>
{
	public MLeaderStyleCollection(CadDictionary dictionary)
		: base(dictionary)
	{
	}

	public void CreateDefaults()
	{
		_dictionary.TryAdd(MultiLeaderStyle.Default);
	}
}
