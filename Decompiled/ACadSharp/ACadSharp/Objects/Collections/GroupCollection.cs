using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ACadSharp.Entities;

namespace ACadSharp.Objects.Collections;

public class GroupCollection : ObjectDictionaryCollection<Group>
{
	public GroupCollection(CadDictionary dictionary)
		: base(dictionary)
	{
		_dictionary = dictionary;
	}

	public override void Add(Group entry)
	{
		foreach (Entity entity in entry.Entities)
		{
			if (entity.Document != _dictionary.Document)
			{
				throw new InvalidOperationException("Entities in a group must be in the same document as the group being added.");
			}
		}
		if (entry.IsUnnamed)
		{
			int num = 0;
			foreach (Group item in this.Where((Group g) => g.IsUnnamed))
			{
				int num2 = int.Parse(Regex.Match(item.Name, "\\d+").Value);
				if (num2 > num)
				{
					num = num2;
				}
			}
			entry.Name = $"*D{num++}";
		}
		base.Add(entry);
	}

	public Group CreateGroup(IEnumerable<Entity> entities)
	{
		return CreateGroup(string.Empty, entities);
	}

	public Group CreateGroup(string name, IEnumerable<Entity> entities)
	{
		Group obj = new Group(name);
		Add(obj);
		obj.AddRange(entities);
		return obj;
	}
}
