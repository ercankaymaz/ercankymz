using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class Joint : Entity, IFace, ICloneable, ITriangles
{
	internal Point3D pos;

	internal double radius;

	private byte _subdivisionLevel;

	private IndexTriangle[] _triangles;

	public Point3D Position
	{
		get
		{
			return pos;
		}
		set
		{
			pos = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public double Radius
	{
		get
		{
			return radius;
		}
		set
		{
			radius = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public byte SubdivisionLevel
	{
		get
		{
			return _subdivisionLevel;
		}
		set
		{
			_subdivisionLevel = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public IndexTriangle[] Triangles => _triangles;

	[CLSCompliant(false)]
	[Obsolete("Use the constructor that accepts the subdivisionLevel parameter as byte instead.")]
	public Joint(double x, double y, double z, double radius, uint subdivisionLevel)
		: this(x, y, z, radius, (byte)subdivisionLevel)
	{
	}

	public Joint(double x, double y, double z, double radius, byte subdivisionLevel)
		: base(entityNatureType.Polygon)
	{
		pos = new Point3D(x, y, z);
		this.radius = radius;
		SubdivisionLevel = subdivisionLevel;
	}

	[CLSCompliant(false)]
	[Obsolete("Use the constructor that accepts the subdivisionLevel parameter as byte instead.")]
	public Joint(Point3D center, double radius, uint subdivisionLevel)
		: this(center, radius, (byte)subdivisionLevel)
	{
	}

	public Joint(Point3D center, double radius, byte subdivisionLevel)
		: base(entityNatureType.Polygon)
	{
		pos = center;
		this.radius = radius;
		SubdivisionLevel = subdivisionLevel;
	}

	[CLSCompliant(false)]
	[Obsolete("Use the constructor that accepts the subdivisionLevel parameter as byte instead.")]
	public Joint(Plane pln, Point2D center, double radius, uint subdivisionLevel)
		: this(pln, center, radius, (byte)subdivisionLevel)
	{
	}

	[CLSCompliant(false)]
	public Joint(Plane pln, Point2D center, double radius, byte subdivisionLevel)
		: base(entityNatureType.Polygon)
	{
		pos = pln.PointAt(center);
		this.radius = radius;
		SubdivisionLevel = subdivisionLevel;
	}

	protected Joint(Joint another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		pos = (Point3D)another.pos.Clone();
		radius = another.radius;
		_subdivisionLevel = another.SubdivisionLevel;
		if (keepTessellation)
		{
			_0023_003Dzg8NPq_0024Bv7ANvyfVpbA_003D_003D(Utility._0023_003DzX42kjXfbzdxuD8Dt7A_003D_003D(another.Triangles));
		}
	}

	protected internal Joint(JointSurrogate surrogate)
		: this(surrogate.Position, surrogate.Radius, surrogate.SubdivisionLevel)
	{
	}

	protected Joint(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		pos = (Point3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971174), typeof(Point3D));
		radius = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955843));
		SubdivisionLevel = info.GetByte(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971159));
	}

	internal void _0023_003Dzg8NPq_0024Bv7ANvyfVpbA_003D_003D(IndexTriangle[] _0023_003DzPzO_0024GUk_003D)
	{
		_triangles = _0023_003DzPzO_0024GUk_003D;
	}

	public override object Clone()
	{
		return new Joint(this);
	}

	public override object CloneWithTessellation()
	{
		return new Joint(this, RegenMode != regenType.RegenAndCompile);
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, layers, materials, blocks));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971148) + pos);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956041) + radius);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971390) + SubdivisionLevel);
		double _0023_003DzXWCF4rA_003D = double.NaN;
		Point3D centroid = null;
		double _0023_003DzhKcriekaIolc = double.NaN;
		Point3D centroid2 = null;
		double _0023_003DzZZ1x4JqOx = double.NaN;
		double convertedDensity = double.NaN;
		if (regenMode == regenType.RegenAndCompile)
		{
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971351));
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		}
		else
		{
			_0023_003DzXWCF4rA_003D = GetArea(out centroid);
			_0023_003DzhKcriekaIolc = GetVolume(out centroid2);
			_0023_003DzZZ1x4JqOx = GetMass(GetMaterial(materials, layers), linearUnits, massUnits, out convertedDensity);
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956197) + _triangles.Length);
		}
		stringBuilder = _0023_003DzJ7t6sHqYVrbZ(stringBuilder, _0023_003DzXWCF4rA_003D, centroid, _0023_003DzhKcriekaIolc, centroid2, _0023_003DzZZ1x4JqOx, convertedDensity, linearUnits, massUnits, materials, layers);
		return stringBuilder.ToString();
	}

	public double GetArea(out Point3D centroid)
	{
		AreaProperties areaProperties = new AreaProperties();
		areaProperties.Add(GetTessellation());
		centroid = areaProperties.Centroid;
		return areaProperties.Area;
	}

	public double GetVolume(out Point3D centroid)
	{
		VolumeProperties volumeProperties = new VolumeProperties();
		volumeProperties.Add(GetTessellation());
		centroid = volumeProperties.Centroid;
		return volumeProperties.Volume;
	}

	public void GetPrincipalAxes(out Vector3D axisX, out Vector3D axisY, out Vector3D axisZ, out double ix, out double iy, out double iz)
	{
		VolumeProperties volumeProperties = new VolumeProperties();
		volumeProperties.Add(GetTessellation());
		volumeProperties.GetPrincipalAxes(volumeProperties.Volume, volumeProperties.Centroid, out axisX, out axisY, out axisZ, out ix, out iy, out iz);
	}

	public void GetPrincipalAxes(out Vector3D axisX, out Vector3D axisY, out Vector3D axisZ)
	{
		GetPrincipalAxes(out axisX, out axisY, out axisZ, out var _, out var _, out var _);
	}

	public double GetMass(Material material, linearUnitsType linearUnits, massUnitsType massUnits, out double convertedDensity)
	{
		Point3D centroid;
		return Utility._0023_003DzaWhFDDP5nQ_0024L(material, MaterialName, massUnits, linearUnits, GetVolume(out centroid), out convertedDensity);
	}

	protected internal override void DrawWireframe(DrawParams data)
	{
	}

	internal void _0023_003DzMzbvW9fa761u_0024bL3NG1DUx0_003D()
	{
		double num = 0.5257311121191336;
		double num2 = 0.8506508083520399;
		_vertices = new Point3D[12]
		{
			new Point3D(0.0 - num, 0.0, num2),
			new Point3D(num, 0.0, num2),
			new Point3D(0.0 - num, 0.0, 0.0 - num2),
			new Point3D(num, 0.0, 0.0 - num2),
			new Point3D(0.0, num2, num),
			new Point3D(0.0, num2, 0.0 - num),
			new Point3D(0.0, 0.0 - num2, num),
			new Point3D(0.0, 0.0 - num2, 0.0 - num),
			new Point3D(num2, num, 0.0),
			new Point3D(0.0 - num2, num, 0.0),
			new Point3D(num2, 0.0 - num, 0.0),
			new Point3D(0.0 - num2, 0.0 - num, 0.0)
		};
		_triangles = new IndexTriangle[20]
		{
			new IndexTriangle(0, 1, 4),
			new IndexTriangle(0, 4, 9),
			new IndexTriangle(9, 4, 5),
			new IndexTriangle(4, 8, 5),
			new IndexTriangle(4, 1, 8),
			new IndexTriangle(8, 1, 10),
			new IndexTriangle(8, 10, 3),
			new IndexTriangle(5, 8, 3),
			new IndexTriangle(5, 3, 2),
			new IndexTriangle(2, 3, 7),
			new IndexTriangle(7, 3, 10),
			new IndexTriangle(7, 10, 6),
			new IndexTriangle(7, 6, 11),
			new IndexTriangle(11, 6, 0),
			new IndexTriangle(0, 6, 1),
			new IndexTriangle(6, 10, 1),
			new IndexTriangle(9, 11, 0),
			new IndexTriangle(9, 2, 11),
			new IndexTriangle(9, 5, 2),
			new IndexTriangle(7, 11, 2)
		};
		Point3D[] array = new Point3D[_triangles.Length * 3];
		int num3 = 0;
		for (int i = 0; i < _triangles.Length; i++)
		{
			array[num3++] = _vertices[_triangles[i].V1];
			array[num3++] = _vertices[_triangles[i].V2];
			array[num3++] = _vertices[_triangles[i].V3];
		}
		int num4 = 0;
		while (num4 < SubdivisionLevel)
		{
			Point3D[] array2 = new Point3D[array.Length * 4];
			int num5 = 0;
			for (int j = 0; j < array.Length; j += 3)
			{
				Point3D point3D = array[j];
				Point3D point3D2 = array[j + 1];
				Point3D point3D3 = array[j + 2];
				Vector3D vector3D = new Vector3D((point3D.X + point3D2.X) / 2.0, (point3D.Y + point3D2.Y) / 2.0, (point3D.Z + point3D2.Z) / 2.0);
				Vector3D vector3D2 = new Vector3D((point3D2.X + point3D3.X) / 2.0, (point3D2.Y + point3D3.Y) / 2.0, (point3D2.Z + point3D3.Z) / 2.0);
				Vector3D vector3D3 = new Vector3D((point3D3.X + point3D.X) / 2.0, (point3D3.Y + point3D.Y) / 2.0, (point3D3.Z + point3D.Z) / 2.0);
				vector3D.Normalize();
				vector3D2.Normalize();
				vector3D3.Normalize();
				array2[num5++] = point3D;
				array2[num5++] = vector3D.AsPoint;
				array2[num5++] = vector3D3.AsPoint;
				array2[num5++] = point3D2;
				array2[num5++] = vector3D2.AsPoint;
				array2[num5++] = vector3D.AsPoint;
				array2[num5++] = point3D3;
				array2[num5++] = vector3D3.AsPoint;
				array2[num5++] = vector3D2.AsPoint;
				array2[num5++] = vector3D.AsPoint;
				array2[num5++] = vector3D2.AsPoint;
				array2[num5++] = vector3D3.AsPoint;
			}
			num4++;
			array = array2;
		}
		Utility.TrianglesToIndexedTriangles(array, out _vertices, out _triangles, Mesh.natureType.Plain);
		for (int k = 0; k < _vertices.Length; k++)
		{
			_vertices[k].X *= radius;
			_vertices[k].Y *= radius;
			_vertices[k].Z *= radius;
			_vertices[k].X += pos.X;
			_vertices[k].Y += pos.Y;
			_vertices[k].Z += pos.Z;
		}
	}

	protected internal override bool InsideOrCrossingFrustum(FrustumParams data)
	{
		if (Utility.InsideOrCrossingFrustum(data, _vertices, _triangles))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool InsideOrCrossingScreenPolygon(ScreenPolygonParams data)
	{
		if (Utility._0023_003DzuQDPXh1pHaNF4I3G_Evhw9Q_003D(_vertices, _triangles, data))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool ThroughTriangle(FrustumParams data)
	{
		if (Entity._0023_003Dzz3lsBX3i0Rg2(data, _vertices, _triangles))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool ThroughTriangleScreenPolygon(ScreenPolygonParams data)
	{
		if (Entity._0023_003DzOejNn2S1Lat5_0024X4DHg_003D_003D(_vertices, _triangles, data))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	public void FlipNormal()
	{
	}

	protected internal override void DrawSilhouettes(DrawSilhouettesParams data)
	{
		HiddenLinesView._0023_003DzY9TYF9sTjnZYO51HtXX26S0_003D(this, data);
	}

	protected internal override void DrawIsocurves(DrawParams data)
	{
		base.DrawWireframe(data);
	}

	protected internal override void DrawNormals(DrawParams data)
	{
		_0023_003Dz_0024B4aBrhAQ9pMnKBcfw_003D_003D(out var _0023_003DzrH1N0x4_003D);
		data.RenderContext.DrawLines(_0023_003DzrH1N0x4_003D);
	}

	internal Vector3D[] _0023_003Dz_0024B4aBrhAQ9pMnKBcfw_003D_003D(out float[] _0023_003DzrH1N0x4_003D)
	{
		double normalLength = GetNormalLength();
		Vector3D[] array = new Vector3D[_vertices.Length];
		_0023_003DzrH1N0x4_003D = new float[_vertices.Length * 6];
		int num = 0;
		for (int i = 0; i < _vertices.Length; i++)
		{
			Point3D point3D = _vertices[i];
			Vector3D vector3D = Vector3D.Subtract(point3D, pos);
			vector3D.Normalize();
			array[i] = vector3D;
			_0023_003DzrH1N0x4_003D[num++] = (float)point3D.X;
			_0023_003DzrH1N0x4_003D[num++] = (float)point3D.Y;
			_0023_003DzrH1N0x4_003D[num++] = (float)point3D.Z;
			_0023_003DzrH1N0x4_003D[num++] = (float)(point3D.X + vector3D.X * normalLength);
			_0023_003DzrH1N0x4_003D[num++] = (float)(point3D.Y + vector3D.Y * normalLength);
			_0023_003DzrH1N0x4_003D[num++] = (float)(point3D.Z + vector3D.Z * normalLength);
		}
		return array;
	}

	public double Area()
	{
		return Math.PI * 4.0 * radius * radius;
	}

	public double Volume()
	{
		return 4.1887902047863905 * radius * radius * radius;
	}

	public override void Regen(RegenParams data)
	{
		_0023_003DzMzbvW9fa761u_0024bL3NG1DUx0_003D();
		base.Regen(data);
	}

	protected override void DrawEntity(RenderContextBase context, object myParams)
	{
		Point3D[] array = new Point3D[_triangles.Length * 3];
		Vector3D[] array2 = new Vector3D[_triangles.Length * 3];
		int num = 0;
		for (int i = 0; i < _triangles.Length; i++)
		{
			Vector3D vector3D = new Vector3D();
			Vector3D vector3D2 = new Vector3D();
			Vector3D vector3D3 = new Vector3D();
			new Vector3D();
			GetTriangleVerticesAndNormals(i, out var _0023_003DzDVubtvo_003D, out var _0023_003DzFj_0024IqDQ_003D, out var _0023_003DzjdeMMkk_003D, vector3D, vector3D2, vector3D3);
			array[num] = _0023_003DzDVubtvo_003D;
			array2[num] = vector3D;
			num++;
			array[num] = _0023_003DzFj_0024IqDQ_003D;
			array2[num] = vector3D2;
			num++;
			array[num] = _0023_003DzjdeMMkk_003D;
			array2[num] = vector3D3;
			num++;
		}
		context.DrawTriangles(array, array2);
	}

	internal void GetTriangleVerticesAndNormals(int _0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D, out Point3D _0023_003DzDVubtvo_003D, out Point3D _0023_003DzFj_0024IqDQ_003D, out Point3D _0023_003DzjdeMMkk_003D, Vector3D _0023_003Dzuz8BZRU_003D, Vector3D _0023_003Dz0wAkCmM_003D, Vector3D _0023_003Dz_0024eRdUwQ_003D)
	{
		_0023_003DzDVubtvo_003D = _vertices[_triangles[_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D].V1];
		_0023_003DzFj_0024IqDQ_003D = _vertices[_triangles[_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D].V2];
		_0023_003DzjdeMMkk_003D = _vertices[_triangles[_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D].V3];
		_0023_003Dzuz8BZRU_003D.X = (_0023_003DzDVubtvo_003D.X - pos.X) / radius;
		_0023_003Dzuz8BZRU_003D.Y = (_0023_003DzDVubtvo_003D.Y - pos.Y) / radius;
		_0023_003Dzuz8BZRU_003D.Z = (_0023_003DzDVubtvo_003D.Z - pos.Z) / radius;
		_0023_003Dz0wAkCmM_003D.X = (_0023_003DzFj_0024IqDQ_003D.X - pos.X) / radius;
		_0023_003Dz0wAkCmM_003D.Y = (_0023_003DzFj_0024IqDQ_003D.Y - pos.Y) / radius;
		_0023_003Dz0wAkCmM_003D.Z = (_0023_003DzFj_0024IqDQ_003D.Z - pos.Z) / radius;
		_0023_003Dz_0024eRdUwQ_003D.X = (_0023_003DzjdeMMkk_003D.X - pos.X) / radius;
		_0023_003Dz_0024eRdUwQ_003D.Y = (_0023_003DzjdeMMkk_003D.Y - pos.Y) / radius;
		_0023_003Dz_0024eRdUwQ_003D.Z = (_0023_003DzjdeMMkk_003D.Z - pos.Z) / radius;
	}

	public override void TransformBy(Transformation xform)
	{
		double[] array = xform.ActOnLeft(pos.X, pos.Y, pos.Z, 1.0);
		double num = ((array[3] != 0.0) ? (1.0 / array[3]) : 1.0);
		pos.X = num * array[0];
		pos.Y = num * array[1];
		pos.Z = num * array[2];
		radius *= xform.ScaleFactorX;
		if (Triangles != null && xform.HasReflection)
		{
			Utility.FlipTriangles(Triangles);
		}
		base.TransformBy(xform);
	}

	internal override void _0023_003Dz_0024_0024rGbexgW9YV(IList<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003Dza_SABTbwi5q2, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, ref int _0023_003DzyzK8swU_003D)
	{
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D obj = _0023_003DzuAMveDQA6vvk()[0];
		obj._0023_003DzqkDCo38_003D(ref _0023_003DzyzK8swU_003D, LayerName);
		obj._0023_003DzsxCTpik_003D(ref _0023_003DzyzK8swU_003D);
		obj._0023_003Dzu9FtIMXgxSrQ(_0023_003Dza_SABTbwi5q2);
	}

	internal override _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[] _0023_003DzuAMveDQA6vvk()
	{
		Surface surface = ConvertToSurface();
		surface.CopyAttributes(this);
		return surface._0023_003DzuAMveDQA6vvk();
	}

	public Surface ConvertToSurface()
	{
		return new Arc(Plane.XZ, Position, Radius, Utility.DegToRad(270.0), Utility.DegToRad(90.0)).RevolveAsSurface(0.0, Math.PI * 2.0, Vector3D.AxisZ, Position)[0];
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new JointSurrogate(this);
	}

	[SpecialName]
	internal override bool _0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D()
	{
		if (base._0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D() && Triangles != null)
		{
			return Triangles.Length != 0;
		}
		return false;
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971174), pos);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955843), radius);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971159), SubdivisionLevel);
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode == regenType.RegenAndCompile)
		{
			Point3D point3D = new Point3D(pos.X - radius, pos.Y - radius, pos.Z - radius);
			Point3D point3D2 = new Point3D(pos.X + radius, pos.Y + radius, pos.Z + radius);
			return new Point3D[2] { point3D, point3D2 };
		}
		return new Point3D[2] { base.BoxMin, base.BoxMax };
	}

	internal override bool _0023_003Dz1owWudHkrMNo9ZKfxq18_OA_003D(TraversalParams _0023_003DzELu0Pss_003D, out Point2D[] _0023_003DzrdSL0CI_003D, out bool _0023_003DzD5Gs7jmmc9uK, out int _0023_003DzHhJEwwk_003D, bool _0023_003DzjZRgeJk_003D = false)
	{
		_0023_003DzHhJEwwk_003D = 1;
		double num = radius * 2.0;
		Point3D origin = new Point3D(pos.X - radius, pos.Y - radius, pos.Z - radius);
		if (_localOB != null && !_localOB._0023_003DziQOhVy0_003D && (RegenMode == regenType.NotNeeded || _0023_003DzjZRgeJk_003D))
		{
			_0023_003DzD5Gs7jmmc9uK = false;
		}
		else
		{
			_0023_003DzD5Gs7jmmc9uK = true;
		}
		_localOB = new OrientedBoundingBox(origin, num, num, num);
		Point2D[] array = _vertices ?? ((Point3D[])_localOB.GetVertices());
		_0023_003DzrdSL0CI_003D = array;
		return true;
	}

	internal override SilhoWireData _0023_003DzEt1XHB_xc_BLLBoMbJmskWU_003D(PreProcessSilhouettesParams _0023_003DzELu0Pss_003D)
	{
		return HiddenLinesView._0023_003DzeWZNZhCW691ciXKd0w_003D_003D(this, _0023_003DzELu0Pss_003D.Parents, Vertices, Triangles, null, _0023_003DzbErHvVw_003D: true, 0.0);
	}

	protected internal override void DrawVertices(DrawParams data)
	{
	}

	public Mesh[] GetTessellation()
	{
		return new Mesh[1]
		{
			new Mesh(_vertices, _triangles)
		};
	}

	public IList<HitTriangle> FindClosestTriangle(Transformation transf, Segment3D seg)
	{
		return Utility.FindClosestTriangle(transf, seg, _vertices, _triangles).Values;
	}

	public ICurve[] Section(Plane pln, double tol)
	{
		return new Mesh(_vertices, _triangles).Section(pln, tol);
	}

	public Mesh ConvertToMesh(double deviation = 0.0, double angle = 0.0, Mesh.natureType nature = Mesh.natureType.Smooth, bool weld = true)
	{
		Mesh mesh = new Mesh(0, 0, nature);
		mesh.Vertices = Utility.DeepCopy(_vertices);
		mesh.Triangles = Utility.DeepCopy(_triangles);
		mesh.CopyAttributes(this);
		return mesh;
	}

	public Brep ConvertToBrep(bool mergeFaces = true, bool mergeEdges = true)
	{
		return ConvertToMesh().ConvertToBrep(mergeFaces, mergeEdges);
	}

	public void GetTightBBox(out Point3D boxMin, out Point3D boxMax)
	{
		ComputeBoundingBox(null, out boxMin, out boxMax);
	}
}
