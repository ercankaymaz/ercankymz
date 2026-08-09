using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ACadSharp.Attributes;
using ACadSharp.Entities;
using ACadSharp.Tables;

namespace ACadSharp.Objects;

[DxfName("SORTENTSTABLE")]
[DxfSubClass("AcDbSortentsTable")]
public class SortEntitiesTable : NonGraphicalObject, IEnumerable<SortEntitiesTable.Sorter>, IEnumerable
{
	public class Sorter : IComparable<Sorter>
	{
		[DxfCodeValue(new int[] { 5 })]
		public ulong SortHandle { get; set; }

		[DxfCodeValue(new int[] { 331 })]
		public Entity Entity { get; set; }

		public Sorter(Entity entity, ulong handle)
		{
			Entity = entity;
			SortHandle = handle;
		}

		public override string ToString()
		{
			return $"{SortHandle} | {Entity?.ToString()}";
		}

		public int CompareTo(Sorter other)
		{
			if (SortHandle < other.SortHandle)
			{
				return -1;
			}
			if (SortHandle > other.SortHandle)
			{
				return 1;
			}
			return 0;
		}
	}

	public const string DictionaryEntryName = "ACAD_SORTENTS";

	private List<Sorter> _sorters = new List<Sorter>();

	[DxfCodeValue(new int[] { 330 })]
	public BlockRecord BlockOwner { get; internal set; }

	public override string ObjectName => "SORTENTSTABLE";

	public override ObjectType ObjectType => ObjectType.UNLISTED;

	public override string SubclassMarker => "AcDbSortentsTable";

	internal SortEntitiesTable()
	{
		Name = "ACAD_SORTENTS";
	}

	internal SortEntitiesTable(BlockRecord owner)
		: this()
	{
		BlockOwner = owner;
	}

	public void Add(Entity entity, ulong sorterHandle)
	{
		_sorters.Add(new Sorter(entity, sorterHandle));
	}

	public void Clear()
	{
		_sorters.Clear();
	}

	public override CadObject Clone()
	{
		SortEntitiesTable obj = (SortEntitiesTable)base.Clone();
		obj._sorters = new List<Sorter>();
		return obj;
	}

	public IEnumerator<Sorter> GetEnumerator()
	{
		_sorters.Sort();
		return _sorters.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public ulong GetSorterHandle(Entity entity)
	{
		return _sorters.FirstOrDefault((Sorter s) => s.Entity.Equals(entity))?.SortHandle ?? entity.Handle;
	}

	public bool Remove(Entity entity)
	{
		Sorter sorter = _sorters.FirstOrDefault((Sorter s) => s.Entity.Equals(entity));
		if (sorter == null)
		{
			return false;
		}
		return _sorters.Remove(sorter);
	}
}
