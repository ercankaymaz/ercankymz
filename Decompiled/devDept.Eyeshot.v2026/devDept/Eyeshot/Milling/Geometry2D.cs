using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Milling;

public class Geometry2D : GeometryBase
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly List<ICurve> _0023_003DzCRokDE7etknL;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dzd4otXJ2tEZjxBV1FYw_003D_003D;

	public bool Flip
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzd4otXJ2tEZjxBV1FYw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzd4otXJ2tEZjxBV1FYw_003D_003D = value;
		}
	}

	public Geometry2D(ICurve curve, double deviation = 0.0, double angleInRadians = 0.0)
		: this(new ICurve[1] { curve }, deviation, angleInRadians)
	{
	}

	public Geometry2D(IList<ICurve> curveList, double deviation = 0.0, double angleInRadians = 0.0)
	{
		base.deviation = deviation;
		angle = angleInRadians;
		_0023_003DzCRokDE7etknL = curveList.ToList();
	}

	public Geometry2D(IList<Entity> entList, double deviation = 0.0, double angleInRadians = 0.0)
	{
		base.deviation = deviation;
		angle = angleInRadians;
		_0023_003DzCRokDE7etknL = new List<ICurve>(entList.Count);
		foreach (Entity ent in entList)
		{
			if (ent is ICurve item)
			{
				_0023_003DzCRokDE7etknL.Add(item);
			}
		}
	}

	public Geometry2D(Document document, double deviation = 0.0, double angleInRadians = 0.0)
	{
		base.deviation = deviation;
		angle = angleInRadians;
		List<Entity> list = new List<Entity>();
		foreach (Entity entity in document.Entities)
		{
			if (entity is BlockReference blockReference)
			{
				bool keepTessellation = deviation == 0.0 && angleInRadians == 0.0;
				list.AddRange(blockReference.ExplodeDeep(document.Blocks, keepTessellation));
			}
			else
			{
				list.Add(entity);
			}
		}
		_0023_003DzCRokDE7etknL = new List<ICurve>(list.Count);
		foreach (Entity item2 in list)
		{
			if (item2 is ICurve item)
			{
				_0023_003DzCRokDE7etknL.Add(item);
			}
		}
	}

	public Point2D[][] GetPolylines(Setup setup)
	{
		return ((_0023_003Dz_rgAQEsYyTJocBy0cikFl_PtLsOJxXWOcV4oKz3K_0024LuQ)_0023_003Dz0uCq1ns_003D[setup.Transformation])._0023_003Dz0_y2MGuBseHDNXdEcQ_003D_003D;
	}

	private protected override void _0023_003DzjMq_0024wgdZc_00245l(Setup _0023_003Dz9cS3uG0_003D)
	{
		_0023_003Dz_rgAQEsYyTJocBy0cikFl_PtLsOJxXWOcV4oKz3K_0024LuQ _0023_003Dz_rgAQEsYyTJocBy0cikFl_PtLsOJxXWOcV4oKz3K_0024LuQ2 = new _0023_003Dz_rgAQEsYyTJocBy0cikFl_PtLsOJxXWOcV4oKz3K_0024LuQ();
		_0023_003Dz_rgAQEsYyTJocBy0cikFl_PtLsOJxXWOcV4oKz3K_0024LuQ2._0023_003Dz0_y2MGuBseHDNXdEcQ_003D_003D = new Point2D[_0023_003DzCRokDE7etknL.Count][];
		_0023_003Dz_rgAQEsYyTJocBy0cikFl_PtLsOJxXWOcV4oKz3K_0024LuQ2._0023_003DzLXv_WdC_s03R = new List<Entity>();
		_0023_003Dz_rgAQEsYyTJocBy0cikFl_PtLsOJxXWOcV4oKz3K_0024LuQ2._0023_003DzDPcjoBJLcqli = Point3D.MaxValue;
		_0023_003Dz_rgAQEsYyTJocBy0cikFl_PtLsOJxXWOcV4oKz3K_0024LuQ2._0023_003Dz_0024N_0024yKptW9BoC = Point3D.MinValue;
		for (int i = 0; i < _0023_003DzCRokDE7etknL.Count; i++)
		{
			Entity entity = (Entity)_0023_003DzCRokDE7etknL[i];
			if (deviation != 0.0 || angle != 0.0)
			{
				entity = (Entity)_0023_003DzCRokDE7etknL[i].Clone();
				entity.Regen(new RegenParams(deviation, angle));
			}
			Entity entity2 = new LinearPath(entity.Vertices);
			_0023_003Dz_rgAQEsYyTJocBy0cikFl_PtLsOJxXWOcV4oKz3K_0024LuQ2._0023_003DzLXv_WdC_s03R.Add(entity2);
			if (!_0023_003Dz9cS3uG0_003D._0023_003DzylonwpI_003D.IsIdentity())
			{
				entity2 = (Entity)entity2.Clone();
				entity2.TransformBy(_0023_003Dz9cS3uG0_003D._0023_003DzylonwpI_003D);
			}
			_0023_003DzNKw2dpKrk09r(entity2, _0023_003Dz_rgAQEsYyTJocBy0cikFl_PtLsOJxXWOcV4oKz3K_0024LuQ2._0023_003DzDPcjoBJLcqli, _0023_003Dz_rgAQEsYyTJocBy0cikFl_PtLsOJxXWOcV4oKz3K_0024LuQ2._0023_003Dz_0024N_0024yKptW9BoC);
			Point2D[][] _0023_003Dz0_y2MGuBseHDNXdEcQ_003D_003D = _0023_003Dz_rgAQEsYyTJocBy0cikFl_PtLsOJxXWOcV4oKz3K_0024LuQ2._0023_003Dz0_y2MGuBseHDNXdEcQ_003D_003D;
			int num = i;
			Point2D[] vertices = entity2.Vertices;
			_0023_003Dz0_y2MGuBseHDNXdEcQ_003D_003D[num] = vertices;
		}
		_0023_003Dz0uCq1ns_003D.Add(_0023_003Dz9cS3uG0_003D.Transformation, _0023_003Dz_rgAQEsYyTJocBy0cikFl_PtLsOJxXWOcV4oKz3K_0024LuQ2);
	}

	private protected void _0023_003DzNKw2dpKrk09r(Entity _0023_003Dzs_0024uS8LA_003D, Point3D _0023_003DzDPcjoBJLcqli, Point3D _0023_003Dz_0024N_0024yKptW9BoC)
	{
		_0023_003Dzs_0024uS8LA_003D.UpdateBoundingBox(new TraversalParams());
		if (_0023_003Dzs_0024uS8LA_003D.BoxMin.X < _0023_003DzDPcjoBJLcqli.X)
		{
			_0023_003DzDPcjoBJLcqli.X = _0023_003Dzs_0024uS8LA_003D.BoxMin.X;
		}
		if (_0023_003Dzs_0024uS8LA_003D.BoxMin.Y < _0023_003DzDPcjoBJLcqli.Y)
		{
			_0023_003DzDPcjoBJLcqli.Y = _0023_003Dzs_0024uS8LA_003D.BoxMin.Y;
		}
		if (_0023_003Dzs_0024uS8LA_003D.BoxMin.Z < _0023_003DzDPcjoBJLcqli.Z)
		{
			_0023_003DzDPcjoBJLcqli.Z = _0023_003Dzs_0024uS8LA_003D.BoxMin.Z;
		}
		if (_0023_003Dzs_0024uS8LA_003D.BoxMax.X > _0023_003Dz_0024N_0024yKptW9BoC.X)
		{
			_0023_003Dz_0024N_0024yKptW9BoC.X = _0023_003Dzs_0024uS8LA_003D.BoxMax.X;
		}
		if (_0023_003Dzs_0024uS8LA_003D.BoxMax.Y > _0023_003Dz_0024N_0024yKptW9BoC.Y)
		{
			_0023_003Dz_0024N_0024yKptW9BoC.Y = _0023_003Dzs_0024uS8LA_003D.BoxMax.Y;
		}
		if (_0023_003Dzs_0024uS8LA_003D.BoxMax.Z > _0023_003Dz_0024N_0024yKptW9BoC.Z)
		{
			_0023_003Dz_0024N_0024yKptW9BoC.Z = _0023_003Dzs_0024uS8LA_003D.BoxMax.Z;
		}
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994594), ((_0023_003Dz_rgAQEsYyTJocBy0cikFl_PtLsOJxXWOcV4oKz3K_0024LuQ)_0023_003Dz0uCq1ns_003D.Values.First())._0023_003Dz0_y2MGuBseHDNXdEcQ_003D_003D.Length);
	}
}
