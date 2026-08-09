using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ProtoBuf;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class CompositeCurveSurrogate : EntitySurrogate
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<Entity, bool> _0023_003Dz_oT3R3YLF01T8K0fjw_003D_003D;

		internal bool _0023_003DzTtFEB3A8lyFk1sP1xOuD9hg_003D(Entity _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D is Ghost;
		}
	}

	internal GCompositeCurve Primitive;

	internal LinearPath[] GraphicalCurves;

	public List<Entity> CurveList;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point3D[] _0023_003DzEToMUVSZ9oPyQ5pgeoQb_0024L0_003D;

	public CompositeCurveSurrogate(CompositeCurve compositeCurve)
		: base(compositeCurve)
	{
	}

	protected internal List<Entity> GetCurveList()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return CurveList;
		}
		return GEntity.CreateEntitiesFromPrimitives(Primitive.CurveList);
	}

	protected override Entity ConvertToObject()
	{
		if (base.Content == contentType.Tessellation)
		{
			List<Entity> curveList = GetCurveList();
			if (curveList.Any(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzTtFEB3A8lyFk1sP1xOuD9hg_003D))
			{
				return _0023_003Dz3_0024Us2DfJD5IJ(typeof(CompositeCurve));
			}
			List<ICurve> _0023_003DzpIZC_0024x5EiUBN = curveList.Cast<ICurve>().ToList();
			if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
			{
				_0023_003DzRg_0024kh6sN6YXfeaJKgQ_003D_003D(_0023_003DzpIZC_0024x5EiUBN, GraphicalCurves);
			}
			_0023_003DzEToMUVSZ9oPyQ5pgeoQb_0024L0_003D = _0023_003DzLj_Zc6ddky1N(_0023_003DzpIZC_0024x5EiUBN);
			return CreateLinearPathOrGhostEntity(_0023_003DzEToMUVSZ9oPyQ5pgeoQb_0024L0_003D, typeof(CompositeCurve));
		}
		CompositeCurve compositeCurve = new CompositeCurve(this);
		CopyDataToObject(compositeCurve);
		return compositeCurve;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		if (entity is CompositeCurve compositeCurve)
		{
			if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
			{
				_0023_003DzRg_0024kh6sN6YXfeaJKgQ_003D_003D(compositeCurve.CurveList, GraphicalCurves);
			}
			compositeCurve.Vertices = _0023_003DzLj_Zc6ddky1N(compositeCurve.CurveList);
		}
		base.CopyDataToObject(entity);
	}

	private static Point3D[] _0023_003DzLj_Zc6ddky1N(IList<ICurve> _0023_003DzpIZC_0024x5EiUBN)
	{
		int num = 0;
		Point3D[][] array = new Point3D[_0023_003DzpIZC_0024x5EiUBN.Count][];
		bool flag = false;
		for (int i = 0; i < _0023_003DzpIZC_0024x5EiUBN.Count; i++)
		{
			Entity entity = (Entity)_0023_003DzpIZC_0024x5EiUBN[i];
			if (entity.Vertices == null || entity.Vertices.Length == 0)
			{
				flag = true;
				break;
			}
			num += entity.Vertices.Length - 1;
			array[i] = entity.Vertices;
		}
		if (!flag)
		{
			return CompositeCurve._0023_003DzZTx6Or_0024_0024RWbzeZoJBQ_003D_003D(num, array);
		}
		return null;
	}

	internal static void _0023_003DzRg_0024kh6sN6YXfeaJKgQ_003D_003D(List<ICurve> _0023_003DzpIZC_0024x5EiUBN, LinearPath[] _0023_003Dzo_0024xWUJx_5NFZ)
	{
		if (_0023_003DzpIZC_0024x5EiUBN == null)
		{
			return;
		}
		Point3D[][] array = null;
		if (_0023_003Dzo_0024xWUJx_5NFZ != null)
		{
			array = new Point3D[_0023_003Dzo_0024xWUJx_5NFZ.Length][];
			for (int i = 0; i < _0023_003Dzo_0024xWUJx_5NFZ.Length; i++)
			{
				array[i] = _0023_003Dzo_0024xWUJx_5NFZ[i].Vertices;
			}
		}
		_0023_003DzRg_0024kh6sN6YXfeaJKgQ_003D_003D(_0023_003DzpIZC_0024x5EiUBN, array);
	}

	internal static void _0023_003DzRg_0024kh6sN6YXfeaJKgQ_003D_003D(List<ICurve> _0023_003DzpIZC_0024x5EiUBN, Point3D[][] _0023_003Dzo_0024xWUJx_5NFZ)
	{
		if (_0023_003DzpIZC_0024x5EiUBN == null)
		{
			return;
		}
		for (int i = 0; i < _0023_003DzpIZC_0024x5EiUBN.Count; i++)
		{
			Entity entity = (Entity)_0023_003DzpIZC_0024x5EiUBN[i];
			if (_0023_003Dzo_0024xWUJx_5NFZ != null)
			{
				entity.Vertices = _0023_003Dzo_0024xWUJx_5NFZ[i];
			}
			if (entity._0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D())
			{
				entity.UpdateBoundingBox(null);
				entity.RegenMode = regenType.CompileOnly;
			}
		}
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		CompositeCurve compositeCurve = (CompositeCurve)entity;
		CurveList = compositeCurve.CurveList.Cast<Entity>().ToList();
		_0023_003DzEToMUVSZ9oPyQ5pgeoQb_0024L0_003D = compositeCurve.Vertices;
		base.CopyDataFromObject(entity);
	}

	protected override bool CheckSurrogateData(string logMessage = null)
	{
		if (base.Content == contentType.Tessellation && (_0023_003DzEToMUVSZ9oPyQ5pgeoQb_0024L0_003D == null || _0023_003DzEToMUVSZ9oPyQ5pgeoQb_0024L0_003D.Length == 0))
		{
			WriteLog(logMessage ?? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302670139));
			return false;
		}
		return true;
	}

	protected override void AfterDeserialize(SerializationContext serializationContext)
	{
		base.AfterDeserialize(serializationContext);
		if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version) && Primitive?.EntityData != null)
		{
			EntityData = new ProtoObject(Primitive.EntityData);
		}
	}
}
