using System;
using System.Collections.Generic;
using System.Linq;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class SketchEntitySurrogate : EntitySurrogate
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<SketchCurve, Entity> _0023_003DzW6VNWCUPEKb1Yg8DZQ_003D_003D;

		internal Entity _0023_003Dzkl8mqLd_0024hf4ex7qnc10wigk_003D(SketchCurve _0023_003DzbfrNXYE_003D)
		{
			return _0023_003DzbfrNXYE_003D._0023_003DzZ_ilKakl9sw5();
		}
	}

	internal Brep parentBrep;

	internal int faceIndex;

	public Point3D[] Vertices;

	public Entity[] PointList;

	public Sketch Sketch;

	public Entity[] CurveList;

	public SketchEntitySurrogate(SketchEntity sketchEntity)
		: base(sketchEntity)
	{
	}

	protected override Entity ConvertToObject()
	{
		if (base.Content == contentType.Tessellation)
		{
			return new PointCloud(_0023_003DzUYI9ARoZWZQNNRH9Rb6XZik_003D())
			{
				DrawingStyle = PointCloud.drawingStyleType.Lines
			};
		}
		SketchEntity sketchEntity = new SketchEntity(this);
		CopyDataToObject(sketchEntity);
		return sketchEntity;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		if (CurveList == null)
		{
			CurveList = Array.Empty<Entity>();
		}
		if (entity is SketchEntity sketchEntity)
		{
			if (base.Version >= 11 && base.Version <= 15)
			{
				int num = 0;
				int num2 = 0;
				foreach (SketchCurve curve in sketchEntity.Sketch.CurveList)
				{
					if (base.Content != contentType.Geometry)
					{
						Entity _0023_003DzPzO_0024GUk_003D = ((curve is SketchPoint) ? PointList[num++] : CurveList[num2++]);
						curve._0023_003DzTVQeh_2_2lC7(_0023_003DzPzO_0024GUk_003D);
					}
					else
					{
						curve._0023_003DzTVQeh_2_2lC7((Entity)curve._0023_003DzxXXV_0024fQ_003D());
					}
					sketchEntity.CurveList.Add((ICurve)curve._0023_003DzZ_ilKakl9sw5());
				}
			}
			else if (base.Version > 15 || (base.Version < 11 && base.Content != contentType.Geometry))
			{
				for (int i = 0; i < CurveList.Length; i++)
				{
					Entity entity2 = CurveList[i];
					sketchEntity.Sketch.CurveList[i]._0023_003DzTVQeh_2_2lC7(entity2);
					sketchEntity.CurveList.Add((ICurve)entity2);
				}
			}
			else
			{
				foreach (SketchCurve curve2 in sketchEntity.Sketch.CurveList)
				{
					curve2._0023_003DzTVQeh_2_2lC7((Entity)curve2._0023_003DzxXXV_0024fQ_003D());
					sketchEntity.CurveList.Add((ICurve)curve2._0023_003DzZ_ilKakl9sw5());
				}
			}
		}
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		SketchEntity sketchEntity = (SketchEntity)entity;
		Sketch = sketchEntity.Sketch;
		CurveList = Sketch.CurveList.Select((SketchCurve _0023_003DzbfrNXYE_003D) => _0023_003DzbfrNXYE_003D._0023_003DzZ_ilKakl9sw5()).ToArray();
		base.CopyDataFromObject(entity);
	}

	private Point3D[] _0023_003DzUYI9ARoZWZQNNRH9Rb6XZik_003D()
	{
		List<Point3D> list = new List<Point3D>();
		Entity[] curveList = CurveList;
		foreach (Entity entity in curveList)
		{
			if (!(entity is Point))
			{
				for (int j = 0; j < entity.Vertices.Length - 1; j++)
				{
					list.Add(entity.Vertices[j]);
					list.Add(entity.Vertices[j + 1]);
				}
			}
		}
		return list.ToArray();
	}
}
