using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using devDept.Diagnostic;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Control;

[Serializable]
public class TempEntityList : EyeshotCollection<Entity>
{
	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Point3D _0023_003Dze4TpmVqI26AF;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Point3D _0023_003DzD4HjvLi8HsVr;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzTdK_0024hceWvKq_;

	public override Entity this[int index]
	{
		get
		{
			return base[index];
		}
		set
		{
			_0023_003DzTdK_0024hceWvKq_ = true;
			base[index] = value;
		}
	}

	public override void Clear()
	{
		_0023_003DzTdK_0024hceWvKq_ = true;
		base.Clear();
	}

	public void InvalidateBoundingBox()
	{
		_0023_003DzTdK_0024hceWvKq_ = true;
	}

	internal void _0023_003DzCJy6o9PkJ45N()
	{
		_0023_003Dze4TpmVqI26AF = Point3D.MaxValue;
		_0023_003DzD4HjvLi8HsVr = Point3D.MinValue;
		List<Entity> list = baseList;
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			Entity entity = list[i];
			Utility.UpdateMinMaxQuick(entity.BoxMin, _0023_003Dze4TpmVqI26AF, _0023_003DzD4HjvLi8HsVr);
			Utility.UpdateMinMaxQuick(entity.BoxMax, _0023_003Dze4TpmVqI26AF, _0023_003DzD4HjvLi8HsVr);
		}
		if (count == 0 || Utility.InvalidOGLPoint(_0023_003Dze4TpmVqI26AF) || Utility.InvalidOGLPoint(_0023_003DzD4HjvLi8HsVr))
		{
			Utility.ResetBBox(out var min, out var max);
			_0023_003Dze4TpmVqI26AF = min;
			_0023_003DzD4HjvLi8HsVr = max;
		}
		if (Point3D.DistanceSquared(_0023_003Dze4TpmVqI26AF, _0023_003DzD4HjvLi8HsVr) == 0.0)
		{
			_0023_003DzD4HjvLi8HsVr = _0023_003Dze4TpmVqI26AF + new Point3D(1.0, 1.0, 1.0);
		}
		_0023_003DzTdK_0024hceWvKq_ = false;
		if (count > 0)
		{
			Telemetry.Instance.AddUsage(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590607), Telemetry.moduleType.Generic);
		}
	}

	public void Add(Entity entity, Color color)
	{
		entity.ColorMethod = colorMethodType.byEntity;
		entity.Color = color;
		_0023_003Dz8WOq4C_xMX3QWOorCQ_003D_003D(entity);
		_0023_003DzTdK_0024hceWvKq_ = true;
		Add(entity);
	}

	public override void Add(Entity entity)
	{
		_0023_003Dz8WOq4C_xMX3QWOorCQ_003D_003D(entity);
		_0023_003DzTdK_0024hceWvKq_ = true;
		base.Add(entity);
	}

	public void AddRange<T>(IEnumerable<T> collection, Color color) where T : Entity
	{
		IList<T> list = collection as IList<T>;
		if (list == null)
		{
			list = collection.ToList();
		}
		foreach (T item in list)
		{
			item.ColorMethod = colorMethodType.byEntity;
			item.Color = color;
			_0023_003Dz8WOq4C_xMX3QWOorCQ_003D_003D(item);
		}
		_0023_003DzTdK_0024hceWvKq_ = true;
		AddRange(list);
	}

	public override void AddRange(IEnumerable<Entity> collection)
	{
		IList<Entity> list = (collection as IList<Entity>) ?? collection.ToList();
		foreach (Entity item in list)
		{
			_0023_003Dz8WOq4C_xMX3QWOorCQ_003D_003D(item);
		}
		_0023_003DzTdK_0024hceWvKq_ = true;
		base.AddRange(list);
	}

	public override void Insert(int index, Entity item)
	{
		_0023_003Dz8WOq4C_xMX3QWOorCQ_003D_003D(item);
		_0023_003DzTdK_0024hceWvKq_ = true;
		base.Insert(index, item);
	}

	public override void InsertRange(int index, IEnumerable<Entity> collection)
	{
		IList<Entity> list = (collection as IList<Entity>) ?? collection.ToList();
		foreach (Entity item in list)
		{
			_0023_003Dz8WOq4C_xMX3QWOorCQ_003D_003D(item);
		}
		_0023_003DzTdK_0024hceWvKq_ = true;
		base.InsertRange(index, list);
	}

	public override void RemoveAt(int index)
	{
		_0023_003DzTdK_0024hceWvKq_ = true;
		base.RemoveAt(index);
	}

	public override int RemoveAll(Predicate<Entity> match)
	{
		_0023_003DzTdK_0024hceWvKq_ = true;
		return base.RemoveAll(match);
	}

	public override bool Remove(Entity item)
	{
		_0023_003DzTdK_0024hceWvKq_ = true;
		return base.Remove(item);
	}

	public override void RemoveRange(int index, int count)
	{
		_0023_003DzTdK_0024hceWvKq_ = true;
		base.RemoveRange(index, count);
	}

	private static void _0023_003Dz8WOq4C_xMX3QWOorCQ_003D_003D(Entity _0023_003DzpWC0efg_003D)
	{
		if (_0023_003DzpWC0efg_003D.RegenMode == regenType.RegenAndCompile)
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590620));
		}
	}
}
