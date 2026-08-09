using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace System.ServiceModel.Description;

public class FaultDescriptionCollection : Collection<FaultDescription>
{
	internal FaultDescriptionCollection()
	{
	}

	public FaultDescription Find(string action)
	{
		using (IEnumerator<FaultDescription> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				FaultDescription current = enumerator.Current;
				if (current != null && action == current.Action)
				{
					return current;
				}
			}
		}
		return null;
	}

	public Collection<FaultDescription> FindAll(string action)
	{
		Collection<FaultDescription> collection = new Collection<FaultDescription>();
		using IEnumerator<FaultDescription> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			FaultDescription current = enumerator.Current;
			if (current != null && action == current.Action)
			{
				collection.Add(current);
			}
		}
		return collection;
	}
}
