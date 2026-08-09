using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using ProtoBuf.Meta;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public abstract class Serializer
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly int[] _0023_003Dz5WUHxZA_003D;

	public static int LastVersion;

	public static int FirstVersion;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static ConcurrentDictionary<int, _0023_003DzjWkQXHiLFkoUV1jogfMYfik_003D> _0023_003Dz3ZEjPLo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dzepgmuj7PenoVN3cFTQ_003D_003D = -1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz3HBVCFKV0ohizcwXIEeXLLQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RuntimeTypeModel _0023_003DzrjNfpzO6syLC2D9jbA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal StringBuilder _0023_003DzZ9xh1dFMrWh_0024 = new StringBuilder();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzsmJJt2ZJUxtB;

	protected internal int HeaderVersion
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzepgmuj7PenoVN3cFTQ_003D_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003Dzepgmuj7PenoVN3cFTQ_003D_003D = value;
		}
	}

	protected internal string HeaderTag
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz3HBVCFKV0ohizcwXIEeXLLQ_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003Dz3HBVCFKV0ohizcwXIEeXLLQ_003D = value;
		}
	}

	[CLSCompliant(false)]
	public RuntimeTypeModel Model
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzrjNfpzO6syLC2D9jbA_003D_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003DzrjNfpzO6syLC2D9jbA_003D_003D = value;
		}
	}

	public string Log => _0023_003DzZ9xh1dFMrWh_0024.ToString();

	static Serializer()
	{
		_0023_003Dz5WUHxZA_003D = new int[22]
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
			21, 22
		};
		LastVersion = _0023_003Dz5WUHxZA_003D.Last();
		FirstVersion = _0023_003Dz5WUHxZA_003D.First();
		ResizeCache();
	}

	public static bool IsValidVersion(int version)
	{
		if (version >= FirstVersion)
		{
			return version <= LastVersion;
		}
		return false;
	}

	internal static bool _0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(int _0023_003DzQ3hPewo_003D)
	{
		if (_0023_003DzQ3hPewo_003D >= 10)
		{
			return _0023_003DzQ3hPewo_003D <= 12;
		}
		return false;
	}

	public static void ResizeCache(int size = 500)
	{
		if (_0023_003Dz3ZEjPLo_003D != null)
		{
			foreach (KeyValuePair<int, _0023_003DzjWkQXHiLFkoUV1jogfMYfik_003D> item in _0023_003Dz3ZEjPLo_003D)
			{
				item.Value._0023_003DzUal_0024ApYHAIaM();
			}
		}
		_0023_003Dz3ZEjPLo_003D = new ConcurrentDictionary<int, _0023_003DzjWkQXHiLFkoUV1jogfMYfik_003D>();
		for (int i = 0; i < size; i++)
		{
			_0023_003Dz3ZEjPLo_003D.TryAdd(i, new _0023_003DzjWkQXHiLFkoUV1jogfMYfik_003D());
		}
	}

	public static void AddToCache(object objKey, ISurrogateWithReferenceId objValue)
	{
		_0023_003Dz3ZEjPLo_003D[Thread.CurrentThread.ManagedThreadId]._0023_003Dz6KIxThd6CQ0k(objKey, objValue);
	}

	public static void AddToCache(ISurrogateWithReferenceId objKey, object objValue)
	{
		_0023_003Dz3ZEjPLo_003D[Thread.CurrentThread.ManagedThreadId]._0023_003Dz6KIxThd6CQ0k(objKey, objValue);
	}

	public static void AddToObjectsCache(object objKey, object objValue)
	{
		_0023_003Dz3ZEjPLo_003D[Thread.CurrentThread.ManagedThreadId]._0023_003DzveKV_pyJHw6N(objKey, objValue);
	}

	public static void ResetCache()
	{
		_0023_003Dz3ZEjPLo_003D[Thread.CurrentThread.ManagedThreadId]._0023_003DzUal_0024ApYHAIaM();
	}

	public static ISurrogateWithReferenceId GetCachedObjectWithReferenceId(object obj)
	{
		return _0023_003Dz3ZEjPLo_003D[Thread.CurrentThread.ManagedThreadId]._0023_003DzwGxc2HXlQamU(obj);
	}

	public static object GetCachedObject(ISurrogateWithReferenceId surrogateWithReferenceId)
	{
		return _0023_003Dz3ZEjPLo_003D[Thread.CurrentThread.ManagedThreadId]._0023_003DzK6wBUO2c7QzU(surrogateWithReferenceId);
	}

	public static object GetCachedObject(object key)
	{
		return _0023_003Dz3ZEjPLo_003D[Thread.CurrentThread.ManagedThreadId]._0023_003DzK6wBUO2c7QzU(key);
	}

	protected void InitializeModel(bool headerOnly = false)
	{
		if (Model == null)
		{
			Model = RuntimeTypeModel.Create();
			FillHeaderModel();
			if (!headerOnly)
			{
				FillModel();
			}
		}
	}

	protected void SetProtobufModel(RuntimeTypeModel protobufModel)
	{
		Model = protobufModel;
		_0023_003DzsmJJt2ZJUxtB = true;
	}

	public bool Contains(Type type)
	{
		if (type != null && Model != null)
		{
			if (!Model.CanSerializeContractType(type))
			{
				return Model.CanSerializeBasicType(type);
			}
			return true;
		}
		return false;
	}

	public void WriteLog(string message)
	{
		if (!string.IsNullOrEmpty(message))
		{
			_0023_003DzZ9xh1dFMrWh_0024.AppendLine(message);
		}
	}

	protected virtual void FillHeaderModel()
	{
		if (!_0023_003DzsmJJt2ZJUxtB)
		{
			Model.Add(typeof(Color), applyDefaultBehaviour: false).SetSurrogate(typeof(SystemDrawingColorSurrogate));
			Model[typeof(SystemDrawingColorSurrogate)].Add(1, "Argb").SetCallbacks(null, null, "BeforeDeserialize", null).UseConstructor = false;
			Model.Add(typeof(Point), applyDefaultBehaviour: false).SetSurrogate(typeof(SystemDrawingPointSurrogate));
			Model[typeof(SystemDrawingPointSurrogate)].Add(1, "X").Add(2, "Y").SetCallbacks(null, null, "BeforeDeserialize", null)
				.UseConstructor = false;
			Model.Add(typeof(PointF), applyDefaultBehaviour: false).SetSurrogate(typeof(SystemDrawingPointFSurrogate));
			Model[typeof(SystemDrawingPointFSurrogate)].Add(1, "X").Add(2, "Y").SetCallbacks(null, null, "BeforeDeserialize", null)
				.UseConstructor = false;
			Model.Add(typeof(RectangleF), applyDefaultBehaviour: false).SetSurrogate(typeof(SystemDrawingRectangleFSurrogate));
			Model[typeof(SystemDrawingRectangleFSurrogate)].Add(1, "X").Add(2, "Y").Add(3, "Width")
				.Add(4, "Height")
				.SetCallbacks(null, null, "BeforeDeserialize", null)
				.UseConstructor = false;
			Model.Add(typeof(Image), applyDefaultBehaviour: false).SetSurrogate(typeof(SystemDrawingImageSurrogate));
			Model[typeof(SystemDrawingImageSurrogate)].Add(1, "Data").SetCallbacks(null, null, "BeforeDeserialize", null).UseConstructor = false;
			Model.Add(typeof(Bitmap), applyDefaultBehaviour: false).SetSurrogate(typeof(SystemDrawingBitmapSurrogate));
			Model[typeof(SystemDrawingBitmapSurrogate)].Add(1, "Data").SetCallbacks(null, null, "BeforeDeserialize", null).UseConstructor = false;
			Model.Add(typeof(Size), applyDefaultBehaviour: false).SetSurrogate(typeof(SystemDrawingSizeSurrogate));
			Model[typeof(SystemDrawingSizeSurrogate)].Add(1, "Width").Add(2, "Height").SetCallbacks(null, null, "BeforeDeserialize", null)
				.UseConstructor = false;
		}
	}

	protected virtual void FillModel()
	{
		if (!_0023_003DzsmJJt2ZJUxtB)
		{
			Model.Add(typeof(ProtoObject), applyDefaultBehaviour: false).SetSurrogate(typeof(ProtoObjectSurrogate));
			Model[typeof(ProtoObjectSurrogate)].Add(1, "_object").SetCallbacks("BeforeSerialize", null, "BeforeDeserialize", "AfterDeserialize").UseConstructor = false;
			Model.Add(typeof(Point2D), applyDefaultBehaviour: false).AddSubType(201, typeof(Point3D)).SetSurrogate(typeof(Point2DSurrogate));
			Model[typeof(Point2DSurrogate)].Add(1, "X").Add(2, "Y").AddSubType(201, typeof(Point3DSurrogate))
				.SetCallbacks(null, null, "BeforeDeserialize", null)
				.UseConstructor = false;
			if (HeaderVersion < 7)
			{
				Model.Add(typeof(Point2D_V6Surrogate), applyDefaultBehaviour: false).Add(1, "X").Add(2, "Y")
					.AddSubType(201, typeof(Point3D_V6Surrogate))
					.AddSubType(202, typeof(Vector2D_V6Surrogate))
					.SetCallbacks(null, null, "BeforeDeserialize", null)
					.UseConstructor = false;
				Model[typeof(Point3D_V6Surrogate)].Add(1, "Z").AddSubType(201, typeof(Vector3D_V6Surrogate)).UseConstructor = false;
				Model[typeof(Vector3D_V6Surrogate)].UseConstructor = false;
				Model.Add(typeof(Vector2D), applyDefaultBehaviour: false).SetSurrogate(typeof(Vector2D_V6Surrogate));
				Model[typeof(Vector2D_V6Surrogate)].UseConstructor = false;
				Model.Add(typeof(Vector3D), applyDefaultBehaviour: false).AddSubType(201, typeof(PlaneEquation)).SetSurrogate(typeof(Vector3D_V6Surrogate));
				Model[typeof(Vector3D_V6Surrogate)].AddSubType(201, typeof(PlaneEquation_V6Surrogate)).UseConstructor = false;
				Model[typeof(PlaneEquation_V6Surrogate)].Add(1, "D").UseConstructor = false;
			}
			else
			{
				Model.Add(typeof(Vector2D), applyDefaultBehaviour: false).AddSubType(201, typeof(Vector3D)).SetSurrogate(typeof(Vector2DSurrogate));
				Model[typeof(Vector2DSurrogate)].Add(1, "X").Add(2, "Y").AddSubType(201, typeof(Vector3DSurrogate))
					.SetCallbacks(null, null, "BeforeDeserialize", null)
					.UseConstructor = false;
				Model[typeof(Vector3D)].AddSubType(201, typeof(PlaneEquation));
				Model[typeof(Vector3DSurrogate)].Add(1, "Z").AddSubType(201, typeof(PlaneEquationSurrogate)).UseConstructor = false;
				Model[typeof(PlaneEquationSurrogate)].Add(1, "D").UseConstructor = false;
			}
			Model[typeof(Point3D)].AddSubType(202, typeof(PointRGB)).AddSubType(203, typeof(PointTangent)).AddSubType(204, typeof(Point4D))
				.AddSubType(205, typeof(PointU))
				.AddSubType(206, typeof(PointNormal))
				.AddSubType(208, typeof(PointWithDisplacement));
			Model[typeof(Point3DSurrogate)].Add(1, "Z").AddSubType(202, typeof(PointRGBSurrogate)).AddSubType(203, typeof(PointTangentSurrogate))
				.AddSubType(204, typeof(Point4DSurrogate))
				.AddSubType(205, typeof(PointUSurrogate))
				.AddSubType(206, typeof(PointNormalSurrogate))
				.AddSubType(208, typeof(PointWithDisplacementSurrogate))
				.UseConstructor = false;
			Model[typeof(PointWithDisplacementSurrogate)].UseConstructor = false;
			Model[typeof(PointTangent)].AddSubType(201, typeof(PointTangentU));
			Model[typeof(PointTangentSurrogate)].AddSubType(201, typeof(PointTangentUSurrogate)).Add(1, "Tx").Add(2, "Ty")
				.Add(3, "Tz")
				.UseConstructor = false;
			Model[typeof(PointTangentUSurrogate)].Add(1, "U").UseConstructor = false;
			Model[typeof(Point4DSurrogate)].Add(1, "W").UseConstructor = false;
			MetaType metaType = Model[typeof(PointU)].AddSubType(201, typeof(PointUv));
			metaType = Model[typeof(PointUSurrogate)].AddSubType(201, typeof(PointUvSurrogate));
			metaType.Add(1, "U");
			metaType.UseConstructor = false;
			metaType = Model[typeof(PointUv)].AddSubType(201, typeof(PointNormalUv));
			metaType = Model[typeof(PointUvSurrogate)].AddSubType(201, typeof(PointNormalUvSurrogate));
			metaType.Add(1, "V");
			metaType.UseConstructor = false;
			Model[typeof(PointNormalUvSurrogate)].Add(1, "Nx").Add(2, "Ny").Add(3, "Nz")
				.Add(4, "PlotValue")
				.Add(5, "ColorIndex")
				.Add(6, "Index")
				.UseConstructor = false;
			Model[typeof(PointNormalSurrogate)].Add(1, "Nx").Add(2, "Ny").Add(3, "Nz")
				.UseConstructor = false;
			Model[typeof(PointRGBSurrogate)].Add(1, "R").Add(2, "G").Add(3, "B")
				.UseConstructor = false;
			Model.Add(typeof(Plane), applyDefaultBehaviour: false).SetSurrogate(typeof(PlaneSurrogate));
			Model[typeof(PlaneSurrogate)].Add(1, "Origin").Add(2, "AxisX").Add(3, "AxisY")
				.SetCallbacks(null, null, "BeforeDeserialize", null)
				.UseConstructor = false;
			Model.Add(typeof(Interval), applyDefaultBehaviour: false).SetSurrogate(typeof(IntervalSurrogate));
			Model[typeof(IntervalSurrogate)].Add(1, "t0").Add(2, "t1").SetCallbacks(null, null, "BeforeDeserialize", null)
				.UseConstructor = false;
			Model.Add(typeof(IndexLine), applyDefaultBehaviour: false).AddSubType(201, typeof(IndexTriangle)).SetSurrogate(typeof(IndexLineSurrogate));
			Model[typeof(IndexLineSurrogate)].Add(1, "V1").Add(2, "V2").AddSubType(201, typeof(IndexTriangleSurrogate))
				.SetCallbacks(null, null, "BeforeDeserialize", null)
				.UseConstructor = false;
			Model[typeof(IndexTriangle)].AddSubType(201, typeof(RichTriangle)).AddSubType(202, typeof(SmoothTriangle)).AddSubType(203, typeof(ColorTriangle));
			Model[typeof(IndexTriangleSurrogate)].Add(1, "V3").AddSubType(201, typeof(RichTriangleSurrogate)).AddSubType(202, typeof(SmoothTriangleSurrogate))
				.AddSubType(203, typeof(ColorTriangleSurrogate))
				.UseConstructor = false;
			Model[typeof(RichTriangleSurrogate)].Add(1, "T1").Add(2, "T2").Add(3, "T3")
				.UseConstructor = false;
			Model[typeof(SmoothTriangle)].AddSubType(201, typeof(ColorSmoothTriangle)).AddSubType(202, typeof(RichSmoothTriangle));
			Model[typeof(SmoothTriangleSurrogate)].Add(1, "N1").Add(2, "N2").Add(3, "N3")
				.AddSubType(201, typeof(ColorSmoothTriangleSurrogate))
				.AddSubType(202, typeof(RichSmoothTriangleSurrogate))
				.UseConstructor = false;
			Model[typeof(ColorTriangleSurrogate)].Add(1, "R").Add(2, "G").Add(3, "B")
				.UseConstructor = false;
			Model[typeof(ColorSmoothTriangleSurrogate)].Add(1, "R").Add(2, "G").Add(3, "B")
				.UseConstructor = false;
			Model[typeof(RichSmoothTriangleSurrogate)].Add(1, "T1").Add(2, "T2").Add(3, "T3")
				.UseConstructor = false;
			Model.Add(typeof(Transformation), applyDefaultBehaviour: false).SetSurrogate(typeof(TransformationSurrogate));
			Model[typeof(TransformationSurrogate)].Add(1, "Matrix").SetCallbacks(null, null, "BeforeDeserialize", null).UseConstructor = false;
			Model.Add(typeof(Quaternion), applyDefaultBehaviour: false).SetSurrogate(typeof(QuaternionSurrogate));
			Model[typeof(QuaternionSurrogate)].Add(1, "X").Add(2, "Y").Add(3, "Z")
				.Add(4, "W")
				.SetCallbacks(null, null, "BeforeDeserialize", null)
				.UseConstructor = false;
			Model.Add(typeof(Polygon2D), applyDefaultBehaviour: false).SetSurrogate(typeof(Polygon2DSurrogate));
			metaType = Model[typeof(Polygon2DSurrogate)];
			metaType.Add(1, "Points");
			metaType.Add(2, "Min");
			metaType.Add(3, "Max");
			metaType.SetCallbacks(null, null, "BeforeDeserialize", null);
			metaType.UseConstructor = false;
			Model.Add(typeof(Segment2D), applyDefaultBehaviour: false).SetSurrogate(typeof(Segment2DSurrogate));
			Model[typeof(Segment2DSurrogate)].Add(1, "P0").Add(2, "P1").SetCallbacks(null, null, "BeforeDeserialize", null)
				.UseConstructor = false;
			Model.Add(typeof(Segment3D), applyDefaultBehaviour: false).SetSurrogate(typeof(Segment3DSurrogate));
			Model[typeof(Segment3DSurrogate)].Add(1, "P0").Add(2, "P1").SetCallbacks(null, null, "BeforeDeserialize", null)
				.UseConstructor = false;
			metaType = Model.Add(typeof(GEntity), applyDefaultBehaviour: false);
			metaType.AddSubType(201, typeof(GPlanarEntity));
			metaType.AddSubType(202, typeof(GPoint));
			metaType.AddSubType(203, typeof(GLine));
			metaType.AddSubType(204, typeof(GTriangle));
			metaType.AddSubType(205, typeof(GQuad));
			metaType.AddSubType(206, typeof(GLinearPath));
			metaType.AddSubType(207, typeof(GCompositeCurve));
			metaType.AddSubType(210, typeof(GPointCloud));
			metaType.AddSubType(212, typeof(GMesh));
			metaType.AddSubType(214, typeof(GSolid));
			metaType.AddSubType(215, typeof(GNurbsBase));
			metaType.AddSubType(216, typeof(GBrep));
			metaType.SetSurrogate(typeof(GEntitySurrogate));
			metaType = Model[typeof(GEntitySurrogate)];
			metaType.UseConstructor = false;
			metaType.Add(1, "EntityData");
			AddReferenceIdField(metaType);
			metaType.SetCallbacks("BeforeSerialize", null, "BeforeDeserialize", null).UseConstructor = false;
			metaType.AddSubType(201, typeof(GPlanarEntitySurrogate));
			metaType.AddSubType(202, typeof(GCircleSurrogate));
			metaType.AddSubType(203, typeof(GEllipseSurrogate));
			metaType.AddSubType(207, typeof(GRegionSurrogate));
			metaType.AddSubType(208, typeof(GPointSurrogate));
			metaType.AddSubType(209, typeof(GLineSurrogate));
			metaType.AddSubType(210, typeof(GTriangleSurrogate));
			metaType.AddSubType(211, typeof(GQuadSurrogate));
			metaType.AddSubType(212, typeof(GLinearPathSurrogate));
			metaType.AddSubType(213, typeof(GCompositeCurveSurrogate));
			metaType.AddSubType(216, typeof(GPointCloudSurrogate));
			metaType.AddSubType(218, typeof(GMeshSurrogate));
			metaType.AddSubType(220, typeof(GSolidSurrogate));
			metaType.AddSubType(221, typeof(GPortionSurrogate));
			metaType.AddSubType(222, typeof(GNurbsBaseSurrogate));
			metaType.AddSubType(223, typeof(GBrepSurrogate));
			Model[typeof(GPlanarEntity)].AddSubType(201, typeof(GCircle)).AddSubType(202, typeof(GEllipse)).AddSubType(206, typeof(GRegion));
			metaType = Model[typeof(GPlanarEntitySurrogate)];
			AddPlaneField(metaType);
			metaType.UseConstructor = false;
			Model[typeof(GCircle)].AddSubType(201, typeof(GArc));
			metaType = Model[typeof(GCircleSurrogate)].AddSubType(201, typeof(GArcSurrogate));
			metaType.UseConstructor = false;
			metaType.Add(1, "Radius");
			AddPlaneField(metaType);
			metaType = Model[typeof(GArcSurrogate)];
			metaType.UseConstructor = false;
			metaType.Add(1, "Domain");
			Model[typeof(GEllipse)].AddSubType(201, typeof(GEllipticalArc));
			metaType = Model[typeof(GEllipseSurrogate)].AddSubType(201, typeof(GEllipticalArcSurrogate));
			metaType.UseConstructor = false;
			metaType.Add(1, "RadiusX");
			metaType.Add(2, "RadiusY");
			AddPlaneField(metaType);
			metaType = Model[typeof(GEllipticalArcSurrogate)];
			metaType.Add(1, "Domain");
			metaType.UseConstructor = false;
			metaType = Model[typeof(GRegionSurrogate)];
			metaType.UseConstructor = false;
			metaType.Add(1, "ContourList");
			AddPlaneField(metaType);
			metaType = Model[typeof(GPointSurrogate)];
			metaType.Add(1, "Position");
			metaType.UseConstructor = false;
			metaType = Model[typeof(GTriangleSurrogate)];
			metaType.Add(1, "V1");
			metaType.Add(2, "V2");
			metaType.Add(3, "V3");
			AddNormalField(metaType);
			metaType.UseConstructor = false;
			metaType = Model[typeof(GQuadSurrogate)];
			metaType.Add(1, "V1");
			metaType.Add(2, "V2");
			metaType.Add(3, "V3");
			metaType.Add(4, "V4");
			AddNormalField(metaType);
			metaType.UseConstructor = false;
			metaType = Model[typeof(GLineSurrogate)];
			metaType.Add(1, "StartPoint");
			metaType.Add(2, "EndPoint");
			metaType.UseConstructor = false;
			metaType = Model[typeof(GMeshSurrogate)].Add(1, "MeshNature").Add(2, "EdgeStyle").Add(3, "SmoothingAngle")
				.Add(4, "LightWeight");
			AddVerticesField(metaType);
			AddTrianglesField(metaType);
			AddTextureCoordsField(metaType);
			AddNormalsField(metaType);
			AddEdgesField(metaType);
			metaType.UseConstructor = false;
			Model[typeof(GMesh)].AddSubType(201, typeof(GSolid.Portion));
			metaType = Model[typeof(GPortionSurrogate)];
			metaType.Add(1, "MeshNature");
			metaType.Add(2, "EdgeStyle");
			metaType.Add(3, "SmoothingAngle");
			metaType.Add(4, "LightWeight");
			AddVerticesField(metaType);
			metaType.Add(11, "Id");
			metaType.Add(12, "EdgeDatas");
			metaType.Add(13, "Faces");
			metaType.Add(14, "Cycles");
			metaType.Add(15, "vertexCount");
			metaType.Add(16, "edgeCount");
			metaType.Add(17, "faceCount");
			metaType.Add(18, "contourCount");
			metaType.Add(19, "MaxNov");
			metaType.Add(20, "MaxNoe");
			metaType.Add(21, "MaxNof");
			metaType.Add(22, "MaxNoc");
			metaType.Add(23, "novTemp");
			metaType.Add(24, "isoCurves");
			metaType.UseConstructor = false;
			metaType = Model[typeof(GSolidSurrogate)];
			metaType.Add(1, "Portions");
			metaType.Add(2, "BRepMode");
			metaType.Add(3, "TextureMapping");
			metaType.Add(4, "SmoothingAngle");
			metaType.UseConstructor = false;
			metaType = Model[typeof(GLinearPathSurrogate)];
			AddVerticesField(metaType);
			metaType.UseConstructor = false;
			metaType = Model[typeof(GCompositeCurveSurrogate)];
			metaType.UseConstructor = false;
			metaType.Add(1, "CurveList");
			metaType = Model[typeof(GPointCloudSurrogate)];
			metaType.UseConstructor = false;
			AddVerticesField(metaType);
			Model[typeof(GNurbsBase)].AddSubType(201, typeof(GCurve)).AddSubType(202, typeof(GSurface));
			Model[typeof(GNurbsBaseSurrogate)].AddSubType(201, typeof(GCurveSurrogate)).AddSubType(202, typeof(GSurfaceSurrogate)).Add(1, "p")
				.Add(2, "U")
				.UseConstructor = false;
			Model[typeof(GCurve)].AddSubType(201, typeof(GTrimCurve));
			Model[typeof(GCurveSurrogate)].AddSubType(201, typeof(GTrimCurveSurrogate)).Add(1, "Pw").UseConstructor = false;
			Model[typeof(GTrimCurveSurrogate)].Add(1, "Edge").UseConstructor = false;
			Model[typeof(GSurface)].AddSubType(201, typeof(GPlanarSurface)).AddSubType(202, typeof(GTabulatedSurface)).AddSubType(203, typeof(GRevolvedSurface));
			metaType = Model[typeof(GSurfaceSurrogate)].AddSubType(201, typeof(GPlanarSurfaceSurrogate)).AddSubType(202, typeof(GTabulatedSurfaceSurrogate)).AddSubType(203, typeof(GRevolvedSurfaceSurrogate));
			metaType.Add(1, "TextureScaleU");
			metaType.Add(2, "TextureScaleV");
			metaType.Add(3, "TextureOffsetU");
			metaType.Add(4, "TextureOffsetV");
			metaType.Add(5, "ControlPoints");
			metaType.Add(6, "DegreeV");
			metaType.Add(7, "KnotVectorV");
			metaType.Add(8, "Trimming");
			metaType.UseConstructor = false;
			metaType = Model[typeof(GPlanarSurfaceSurrogate)];
			metaType.UseConstructor = false;
			AddPlaneField(metaType);
			metaType = Model[typeof(GTabulatedSurfaceSurrogate)];
			metaType.UseConstructor = false;
			metaType.Add(1, "Generatrix");
			metaType.Add(2, "Directrix");
			Model[typeof(GRevolvedSurface)].AddSubType(201, typeof(GCylindricalSurface)).AddSubType(202, typeof(GSphericalSurface));
			metaType = Model[typeof(GRevolvedSurfaceSurrogate)].AddSubType(201, typeof(GCylindricalSurfaceSurrogate)).AddSubType(202, typeof(GSphericalSurfaceSurrogate));
			metaType.UseConstructor = false;
			metaType.Add(1, "Generatrix");
			metaType.Add(2, "SeamPlane");
			Model[typeof(GCylindricalSurface)].AddSubType(201, typeof(GConicalSurface));
			metaType = Model[typeof(GCylindricalSurfaceSurrogate)].AddSubType(201, typeof(GConicalSurfaceSurrogate));
			metaType.UseConstructor = false;
			metaType.Add(1, "Radius");
			Model[typeof(GSphericalSurface)].AddSubType(201, typeof(GToroidalSurface));
			metaType = Model[typeof(GSphericalSurfaceSurrogate)].AddSubType(201, typeof(GToroidalSurfaceSurrogate));
			metaType.UseConstructor = false;
			metaType.Add(1, "Radius");
			metaType = Model[typeof(GConicalSurfaceSurrogate)];
			metaType.UseConstructor = false;
			metaType.Add(1, "HalfAngle");
			metaType.Add(2, "Tip");
			metaType = Model[typeof(GToroidalSurfaceSurrogate)];
			metaType.UseConstructor = false;
			metaType.Add(1, "MajorRadius");
			metaType = Model[typeof(GBrepSurrogate)];
			metaType.UseConstructor = false;
			metaType.Add(1, "Faces");
			metaType.Add(2, "Inners");
			metaType.Add(3, "Edges");
			metaType.Add(4, "RebuildTolerance");
			AddVerticesField(metaType);
			Model.Add(typeof(Sketch), applyDefaultBehaviour: false).SetSurrogate(typeof(SketchSurrogate));
			Model[typeof(SketchSurrogate)].Add(1, "CurveList").Add(2, "Constraints").Add(3, "Plane")
				.SetCallbacks(null, null, "BeforeDeserialize", null)
				.UseConstructor = false;
			Model.Add(typeof(SketchItem), applyDefaultBehaviour: false).AddSubType(201, typeof(SketchCurve)).AddSubType(202, typeof(Constraint))
				.SetSurrogate(typeof(SketchItemSurrogate));
			metaType = Model[typeof(SketchItemSurrogate)];
			metaType.UseConstructor = false;
			metaType.Add(1, "guid");
			metaType.SetCallbacks(null, null, "BeforeDeserialize", null);
			metaType.UseConstructor = false;
			AddReferenceIdField(metaType);
			metaType.AddSubType(201, typeof(SketchCurveSurrogate));
			metaType.AddSubType(202, typeof(ConstraintSurrogate));
			metaType = Model[typeof(Constraint)];
			metaType.AddSubType(201, typeof(PointFixedConstraint));
			metaType.AddSubType(202, typeof(ParallelConstraint));
			metaType.AddSubType(203, typeof(TangentConstraint));
			metaType.AddSubType(204, typeof(PerpendicularConstraint));
			metaType.AddSubType(205, typeof(ValueConstraint));
			metaType.AddSubType(206, typeof(CoincidentConstraint));
			metaType.AddSubType(207, typeof(HVConstraint));
			metaType.AddSubType(208, typeof(MirrorConstraint));
			metaType.AddSubType(209, typeof(CollinearConstraint));
			metaType.AddSubType(210, typeof(PolygonConstraint));
			metaType = Model[typeof(ConstraintSurrogate)];
			metaType.UseConstructor = false;
			metaType.AddSubType(201, typeof(PointFixedConstraintSurrogate));
			metaType.AddSubType(202, typeof(ParallelConstraintSurrogate));
			metaType.AddSubType(203, typeof(TangentConstraintSurrogate));
			metaType.AddSubType(204, typeof(PerpendicularConstraintSurrogate));
			metaType.AddSubType(205, typeof(ValueConstraintSurrogate));
			metaType.AddSubType(206, typeof(CoincidentConstraintSurrogate));
			metaType.AddSubType(207, typeof(HVConstraintSurrogate));
			metaType.AddSubType(208, typeof(MirrorConstraintSurrogate));
			metaType.AddSubType(209, typeof(CollinearConstraintSurrogate));
			metaType.AddSubType(210, typeof(PolygonConstraintSurrogate));
			metaType.Add(1, "Ids");
			metaType.Add(2, "Visible");
			metaType = Model[typeof(PolygonConstraintSurrogate)];
			metaType.UseConstructor = false;
			metaType = Model[typeof(CollinearConstraintSurrogate)];
			metaType.UseConstructor = false;
			metaType = Model[typeof(ValueConstraint)];
			metaType.AddSubType(201, typeof(PointOnConstraint));
			metaType.AddSubType(202, typeof(AngleConstraint));
			metaType.AddSubType(203, typeof(PointsDistanceConstraint));
			metaType.AddSubType(204, typeof(LinesDistanceConstraint));
			metaType.AddSubType(205, typeof(LengthConstraint));
			metaType.AddSubType(206, typeof(EqualConstraint));
			metaType.AddSubType(207, typeof(RadiusConstraint));
			metaType.AddSubType(208, typeof(PointLineDistanceConstraint));
			metaType.AddSubType(209, typeof(ConcentricCirclesDistanceConstraint));
			metaType = Model[typeof(ValueConstraintSurrogate)];
			metaType.AddSubType(201, typeof(PointOnConstraintSurrogate));
			metaType.AddSubType(202, typeof(AngleConstraintSurrogate));
			metaType.AddSubType(203, typeof(PointsDistanceConstraintSurrogate));
			metaType.AddSubType(204, typeof(LinesDistanceConstraintSurrogate));
			metaType.AddSubType(205, typeof(LengthConstraintSurrogate));
			metaType.AddSubType(206, typeof(EqualConstraintSurrogate));
			metaType.AddSubType(207, typeof(RadiusConstraintSurrogate));
			metaType.AddSubType(208, typeof(PointLineDistanceConstraintSurrogate));
			metaType.AddSubType(209, typeof(ConcentricCirclesDistanceConstraintSurrogate));
			metaType.Add(1, "DimPos");
			metaType.Add(2, "Reference");
			metaType.Add(3, "Value");
			metaType.UseConstructor = false;
			metaType = Model[typeof(ConcentricCirclesDistanceConstraintSurrogate)];
			metaType.UseConstructor = false;
			metaType = Model[typeof(PointLineDistanceConstraintSurrogate)];
			metaType.UseConstructor = false;
			metaType = Model[typeof(RadiusConstraint)];
			metaType.AddSubType(201, typeof(DiameterConstraint));
			metaType = Model[typeof(RadiusConstraintSurrogate)];
			metaType.AddSubType(201, typeof(DiameterConstraintSurrogate));
			metaType.UseConstructor = false;
			metaType = Model[typeof(DiameterConstraintSurrogate)];
			metaType.UseConstructor = false;
			metaType = Model[typeof(EqualConstraintSurrogate)];
			metaType.Add(1, "FirstLengthType");
			metaType.Add(2, "SecondLengthType");
			metaType.UseConstructor = false;
			metaType = Model[typeof(AngleConstraintSurrogate)];
			metaType.Add(1, "Supplementary");
			metaType.UseConstructor = false;
			metaType = Model[typeof(PointOnConstraintSurrogate)];
			metaType.AddSubType(201, typeof(PointAtConstraintSurrogate));
			metaType.UseConstructor = false;
			metaType = Model[typeof(PointOnConstraint)];
			metaType.AddSubType(201, typeof(PointAtConstraint));
			metaType = Model[typeof(PointAtConstraintSurrogate)];
			metaType.AddSubType(201, typeof(MidPointConstraintSurrogate));
			metaType.UseConstructor = false;
			metaType = Model[typeof(PointAtConstraint)];
			metaType.AddSubType(201, typeof(MidPointConstraint));
			Model[typeof(MidPointConstraintSurrogate)].UseConstructor = false;
			metaType = Model[typeof(PointsDistanceConstraint)];
			metaType.AddSubType(201, typeof(HorizontalPointsDistanceConstraint));
			metaType.AddSubType(202, typeof(VerticalPointsDistanceConstraint));
			metaType = Model[typeof(PointsDistanceConstraintSurrogate)];
			metaType.AddSubType(201, typeof(HorizontalPointsDistanceConstraintSurrogate));
			metaType.AddSubType(202, typeof(VerticalPointsDistanceConstraintSurrogate));
			metaType.UseConstructor = false;
			metaType = Model[typeof(HorizontalPointsDistanceConstraintSurrogate)];
			metaType.UseConstructor = false;
			metaType = Model[typeof(VerticalPointsDistanceConstraintSurrogate)];
			metaType.UseConstructor = false;
			metaType = Model[typeof(LinesDistanceConstraintSurrogate)];
			metaType.UseConstructor = false;
			metaType = Model[typeof(LengthConstraintSurrogate)];
			metaType.UseConstructor = false;
			metaType = Model[typeof(HVConstraintSurrogate)];
			metaType.Add(1, "Orientation");
			metaType.UseConstructor = false;
			metaType = Model[typeof(PointFixedConstraintSurrogate)];
			metaType.Add(1, "X");
			metaType.Add(2, "Y");
			metaType.UseConstructor = false;
			metaType = Model[typeof(MirrorConstraintSurrogate)];
			metaType.UseConstructor = false;
			metaType = Model[typeof(CoincidentConstraintSurrogate)];
			metaType.UseConstructor = false;
			metaType = Model[typeof(ParallelConstraintSurrogate)];
			metaType.Add(1, "Option");
			metaType.UseConstructor = false;
			metaType = Model[typeof(TangentConstraintSurrogate)];
			metaType.Add(1, "t0");
			metaType.Add(2, "t1");
			metaType.Add(3, "Option");
			metaType.UseConstructor = false;
			metaType = Model[typeof(PerpendicularConstraintSurrogate)];
			metaType.Add(1, "Option");
			metaType.UseConstructor = false;
			metaType = Model[typeof(HVConstraint)];
			metaType.AddSubType(201, typeof(CollinearPointsConstraint));
			metaType = Model[typeof(HVConstraintSurrogate)];
			metaType.AddSubType(201, typeof(CollinearPointsConstraintSurrogate));
			metaType.UseConstructor = false;
			metaType = Model[typeof(CollinearPointsConstraintSurrogate)];
			metaType.UseConstructor = false;
			metaType = Model[typeof(SketchCurve)];
			metaType.AddSubType(201, typeof(SketchPoint));
			metaType.AddSubType(202, typeof(SketchLine));
			metaType.AddSubType(203, typeof(SketchCircle));
			metaType.AddSubType(204, typeof(SketchEllipse));
			metaType.AddSubType(205, typeof(SketchSpline));
			metaType = Model[typeof(SketchCurveSurrogate)];
			metaType.UseConstructor = false;
			metaType.AddSubType(201, typeof(SketchPointSurrogate));
			metaType.AddSubType(202, typeof(SketchLineSurrogate));
			metaType.AddSubType(203, typeof(SketchCircleSurrogate));
			metaType.AddSubType(204, typeof(SketchEllipseSurrogate));
			metaType.AddSubType(205, typeof(SketchSplineSurrogate));
			metaType.Add(1, "Construction");
			metaType.Add(2, "children");
			metaType.Add(3, "Projected");
			metaType.Add(4, "linkedCurves");
			metaType.Add(5, "Fixed");
			Model[typeof(SketchSplineSurrogate)].Add(1, "ControlPoints").UseConstructor = false;
			Model[typeof(SketchPointSurrogate)].Add(1, "PlanePosition").UseConstructor = false;
			Model[typeof(SketchLineSurrogate)].Add(1, "StartPoint").Add(2, "EndPoint").UseConstructor = false;
			metaType = Model[typeof(SketchEllipse)];
			metaType.AddSubType(201, typeof(SketchEllipticalArc));
			metaType = Model[typeof(SketchEllipseSurrogate)];
			metaType.AddSubType(201, typeof(SketchEllipticalArcSurrogate));
			metaType.Add(1, "Center");
			metaType.Add(2, "RadiusX");
			metaType.Add(3, "RadiusY");
			metaType.Add(4, "px");
			metaType.Add(5, "py");
			metaType.Add(6, "ux");
			metaType.Add(7, "uy");
			metaType.Add(8, "vx");
			metaType.Add(9, "vy");
			metaType.UseConstructor = false;
			Model[typeof(SketchEllipticalArcSurrogate)].Add(1, "StartPoint").Add(2, "EndPoint").UseConstructor = false;
			metaType = Model[typeof(SketchCircle)];
			metaType.AddSubType(201, typeof(SketchArc));
			metaType = Model[typeof(SketchCircleSurrogate)];
			metaType.AddSubType(201, typeof(SketchArcSurrogate));
			metaType.Add(1, "Radius");
			metaType.Add(2, "Center");
			metaType.UseConstructor = false;
			Model[typeof(SketchArcSurrogate)].Add(1, "StartPoint").Add(2, "EndPoint").UseConstructor = false;
			Model.Add(typeof(Id), applyDefaultBehaviour: false).SetSurrogate(typeof(IdSurrogate));
			Model[typeof(IdSurrogate)].Add(1, "value").Add(2, "second").SetCallbacks(null, null, "BeforeDeserialize", null)
				.UseConstructor = false;
			Model.Add(typeof(IdPath), applyDefaultBehaviour: false).SetSurrogate(typeof(IdPathSurrogate));
			Model[typeof(IdPathSurrogate)].Add(1, "Paths").SetCallbacks(null, null, "BeforeDeserialize", null).UseConstructor = false;
		}
	}

	protected void AddPlaneField(MetaType metaType)
	{
		metaType.Add(50, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974845));
	}

	protected void AddVerticesField(MetaType metaType)
	{
		metaType.Add(51, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958678));
	}

	protected void AddTrianglesField(MetaType metaType)
	{
		metaType.Add(52, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968413));
	}

	protected void AddNormalsField(MetaType metaType)
	{
		metaType.Add(53, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968397));
	}

	protected void AddTextureCoordsField(MetaType metaType)
	{
		metaType.Add(54, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302672739));
	}

	protected void AddEdgesField(MetaType metaType)
	{
		metaType.Add(55, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954162));
	}

	protected void AddNormalField(MetaType metaType)
	{
		metaType.Add(56, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953809));
	}

	protected internal void CompileModel()
	{
		if (Model == null)
		{
			throw new NullReferenceException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302672727));
		}
		if (!_0023_003DzsmJJt2ZJUxtB)
		{
			Model.CompileInPlace();
			_0023_003DzsmJJt2ZJUxtB = true;
		}
	}

	public bool ModelIsCompiled()
	{
		return _0023_003DzsmJJt2ZJUxtB;
	}

	protected void ResetModel()
	{
		Model = null;
		_0023_003DzsmJJt2ZJUxtB = false;
	}

	public Type GetType(string assemblyQualifiedName)
	{
		if (string.IsNullOrEmpty(assemblyQualifiedName))
		{
			return null;
		}
		Type type = null;
		string typeName = assemblyQualifiedName;
		int num = assemblyQualifiedName.IndexOf(',', 0);
		if (num != -1)
		{
			typeName = assemblyQualifiedName.Substring(0, num);
		}
		try
		{
			type = GetTypeForObject(typeName);
		}
		catch (Exception)
		{
			type = null;
		}
		if (type == null)
		{
			try
			{
				type = GetTypeForObject(assemblyQualifiedName);
			}
			catch (Exception)
			{
				type = null;
			}
		}
		return type;
	}

	protected virtual Type GetTypeForObject(string typeName)
	{
		return Type.GetType(typeName, throwOnError: false, ignoreCase: true);
	}

	protected void AddReferenceIdField(MetaType metaType)
	{
		metaType.Add(100, "ReferenceId");
	}
}
