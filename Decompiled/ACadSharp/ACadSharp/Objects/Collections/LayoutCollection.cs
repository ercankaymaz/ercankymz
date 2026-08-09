using System;

namespace ACadSharp.Objects.Collections;

public class LayoutCollection : ObjectDictionaryCollection<Layout>
{
	public LayoutCollection(CadDictionary dictionary)
		: base(dictionary)
	{
		_dictionary = dictionary;
	}

	public override bool Remove(string name, out Layout entry)
	{
		if (name.Equals("Model", StringComparison.InvariantCultureIgnoreCase) || name.Equals("Layout1", StringComparison.InvariantCultureIgnoreCase))
		{
			throw new ArgumentException("The Layout " + name + " cannot be removed.");
		}
		return base.Remove(name, out entry);
	}
}
