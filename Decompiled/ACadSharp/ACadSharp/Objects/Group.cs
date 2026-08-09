using System;
using System.Collections.Generic;
using ACadSharp.Attributes;
using ACadSharp.Entities;
using CSUtilities.Extensions;

namespace ACadSharp.Objects;

[DxfName("GROUP")]
[DxfSubClass("AcDbGroup")]
public class Group : NonGraphicalObject
{
	private List<Entity> _entities = new List<Entity>();

	[DxfCodeValue(new int[] { 300 })]
	public string Description { get; set; } = string.Empty;

	[DxfCollectionCodeValue(DxfReferenceType.Handle, new int[] { 340 })]
	public IEnumerable<Entity> Entities => _entities;

	[DxfCodeValue(new int[] { 70 })]
	public bool IsUnnamed
	{
		get
		{
			if (!Name.IsNullOrWhiteSpace())
			{
				return Name.StartsWith("*");
			}
			return true;
		}
	}

	public override string ObjectName => "GROUP";

	public override ObjectType ObjectType => ObjectType.GROUP;

	[DxfCodeValue(new int[] { 71 })]
	public bool Selectable { get; set; } = true;

	public override string SubclassMarker => "AcDbGroup";

	public Group()
	{
	}

	public Group(string name)
		: base(name)
	{
	}

	public void Add(Entity entity)
	{
		if (base.Document != entity.Document)
		{
			throw new InvalidOperationException("The Group and the entity must belong to the same document.");
		}
		_entities.Add(entity);
		entity.AddReactor(this);
	}

	public void AddRange(IEnumerable<Entity> entities)
	{
		foreach (Entity entity in entities)
		{
			Add(entity);
		}
	}

	public void Clear()
	{
		foreach (Entity entity in _entities)
		{
			entity.RemoveReactor(this);
		}
		_entities.Clear();
	}

	public bool Remove(Entity entity)
	{
		entity.RemoveReactor(this);
		return _entities.Remove(entity);
	}

	public override CadObject Clone()
	{
		Group obj = (Group)base.Clone();
		obj._entities = new List<Entity>();
		return obj;
	}

	internal override void AssignDocument(CadDocument doc)
	{
		base.AssignDocument(doc);
	}

	internal override void UnassignDocument()
	{
		base.UnassignDocument();
		foreach (Entity entity in _entities)
		{
			entity.RemoveReactor(this);
		}
		_entities.Clear();
	}
}
