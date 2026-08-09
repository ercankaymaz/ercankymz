namespace ACadSharp.Objects.Collections;

public class DictionaryVariableCollection : ObjectDictionaryCollection<DictionaryVariable>
{
	public DictionaryVariableCollection(CadDictionary dictionary)
		: base(dictionary)
	{
	}

	public void AddOrUpdateVariable(string name, string value)
	{
		if (TryGet(name, out var entry))
		{
			entry.Value = value;
		}
		else
		{
			Add(new DictionaryVariable(name, value));
		}
	}

	public void AddVariable(string name, string value)
	{
		if (!ContainsKey(name))
		{
			Add(new DictionaryVariable(name, value));
		}
	}

	public void CreateDefaults()
	{
		AddVariable("CMLEADERSTYLE", "Standard");
		AddVariable("CANNOSCALE", "1:1");
		AddVariable("CTABLESTYLE", "Standard");
		AddVariable("WIPEOUTFRAME", 1.ToString());
		AddVariable("CVIEWDETAILSTYLE", "Metric50");
		AddVariable("CVIEWSECTIONSTYLE", "Metric50");
	}

	public string GetValue(string name)
	{
		if (TryGet(name, out var entry))
		{
			return entry.Value;
		}
		return null;
	}
}
