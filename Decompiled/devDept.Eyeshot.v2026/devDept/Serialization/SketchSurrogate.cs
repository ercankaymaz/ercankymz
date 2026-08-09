using System;
using System.Collections.Generic;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class SketchSurrogate : Surrogate<Sketch>
{
	public List<SketchCurve> CurveList;

	public Constraint[] Constraints;

	public Plane Plane;

	public SketchSurrogate(Sketch sketch)
		: base(sketch)
	{
	}

	protected override Sketch ConvertToObject()
	{
		Sketch sketch = new Sketch(Plane);
		CopyDataToObject(sketch);
		return sketch;
	}

	protected override void CopyDataToObject(Sketch obj)
	{
		if (CurveList != null)
		{
			foreach (SketchCurve curve in CurveList)
			{
				obj._sketchInternal._0023_003DzRCrpdGA_003D(curve);
				curve._0023_003Dz4rsUxOLl8ATWosrQiQ_003D_003D(obj._sketchInternal);
				obj._sketchInternal.idGenerator._0023_003Dzuxxvjv8_003D = Math.Max(obj._sketchInternal.idGenerator._0023_003Dzuxxvjv8_003D, curve._0023_003DzDQs07gDx7oDr().value);
			}
		}
		if (Constraints == null)
		{
			return;
		}
		Constraint[] constraints = Constraints;
		foreach (Constraint constraint in constraints)
		{
			obj._sketchInternal._0023_003Dz55vCXok_003D(constraint);
			constraint._0023_003Dz4rsUxOLl8ATWosrQiQ_003D_003D(obj._sketchInternal);
			obj._sketchInternal.idGenerator._0023_003Dzuxxvjv8_003D = Math.Max(obj._sketchInternal.idGenerator._0023_003Dzuxxvjv8_003D, constraint._0023_003DzDQs07gDx7oDr().value);
			foreach (IdPath id in constraint._ids)
			{
				if (obj._sketchInternal._0023_003DzXKRytQoXWc2o(id, 0) is SketchCurve sketchCurve)
				{
					sketchCurve._0023_003Dz55vCXok_003D(constraint);
				}
			}
		}
	}

	protected override void CopyDataFromObject(Sketch sketch)
	{
		CurveList = sketch.CurveList;
		Constraints = sketch.Constraints;
		Plane = sketch.SketchPlane;
	}

	public static implicit operator Sketch(SketchSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator SketchSurrogate(Sketch source)
	{
		return source?.ConvertToSurrogate();
	}
}
