using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace System.ServiceModel.Description;

public class MessageDescriptionCollection : Collection<MessageDescription>
{
	internal MessageDescriptionCollection()
	{
	}

	public MessageDescription Find(string action)
	{
		using (IEnumerator<MessageDescription> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				MessageDescription current = enumerator.Current;
				if (current != null && action == current.Action)
				{
					return current;
				}
			}
		}
		return null;
	}

	public Collection<MessageDescription> FindAll(string action)
	{
		Collection<MessageDescription> collection = new Collection<MessageDescription>();
		using IEnumerator<MessageDescription> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			MessageDescription current = enumerator.Current;
			if (current != null && action == current.Action)
			{
				collection.Add(current);
			}
		}
		return collection;
	}
}
