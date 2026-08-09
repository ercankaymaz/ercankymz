using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using devDept.Eyeshot.Fem;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class Mesh : Entity, IFace, ICloneable, ITriangles, IFaceSelectable, ISelectableSubItems
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<_0023_003DzczFDDB3cqe1d, int> _0023_003Dzry4PS7bXBxAp86JaSQ_003D_003D;

		internal int _0023_003DzM74FVoKU1XQA_MIhaHu__0024lYWl6EPYmwY4QzGvwA_003D(_0023_003DzczFDDB3cqe1d _0023_003DzGcl_0024E9o_003D)
		{
			return _0023_003DzGcl_0024E9o_003D._0023_003DzLXzfFx__0024a_DT();
		}
	}

	private sealed class _0023_003DzB0hRnjubCnfd_v5ZLdiOfNM_003D
	{
		public (int, int) _0023_003DzIvSnYaGVdrwK;

		internal bool _0023_003Dzk2aGNKiIkBiRqFR8ymcvs4FrE8f_RtdLIg_003D_003D((int, int) _0023_003DzuwH5j5s_003D)
		{
			return _0023_003DzuwH5j5s_003D.Item1 == _0023_003DzIvSnYaGVdrwK.Item2;
		}
	}

	internal delegate void _0023_003DzBj46ktwYVXnE(DrawParams _0023_003DzELu0Pss_003D);

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003DzHGlGj7oYIL6hV3aiCu4SRzE_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Dictionary<(int, int), int> _0023_003DzAAkdMI4Ul71Y;
	}

	internal sealed class _0023_003DzJ_RTclI3ycMtHeNx7Q_003D_003D : IComparer<_0023_003DzczFDDB3cqe1d>
	{
		public int Compare(_0023_003DzczFDDB3cqe1d _0023_003DziMjqlCo_003D, _0023_003DzczFDDB3cqe1d _0023_003DzI4dRPW0_003D)
		{
			if (_0023_003DziMjqlCo_003D._0023_003DzQW_0024hBdI_003D < _0023_003DzI4dRPW0_003D._0023_003DzQW_0024hBdI_003D)
			{
				return -1;
			}
			if (_0023_003DziMjqlCo_003D._0023_003DzQW_0024hBdI_003D > _0023_003DzI4dRPW0_003D._0023_003DzQW_0024hBdI_003D)
			{
				return 1;
			}
			return 0;
		}
	}

	internal enum _0023_003DzNuun60qGd2Yq
	{

	}

	internal enum _0023_003DzbH4ZsoQ_003D
	{

	}

	internal sealed class _0023_003DzczFDDB3cqe1d
	{
		public SharedEdge _0023_003DzeyQd9LoOUlcN;

		public int _0023_003DzQW_0024hBdI_003D;

		public bool _0023_003DznkPLPRg_003D;

		internal Point3D _0023_003DzIpT00fBdiZkkG9dah6hKpLk_003D;

		public _0023_003DzbH4ZsoQ_003D _0023_003DzJslIhmvq8gUMNVPkXdW9GPU_003D;

		internal _0023_003DzczFDDB3cqe1d()
		{
			_0023_003DzeyQd9LoOUlcN = new SharedEdge();
		}

		internal _0023_003DzczFDDB3cqe1d(int _0023_003DzffqPLNQ_003D, Point3D _0023_003DzLos_0024H_dHfIKMMA5CKrpAhoU_003D, _0023_003DzbH4ZsoQ_003D _0023_003DzJslIhmvq8gUMNVPkXdW9GPU_003D, SharedEdge _0023_003DzeyQd9LoOUlcN)
		{
			_0023_003DzQW_0024hBdI_003D = _0023_003DzffqPLNQ_003D;
			_0023_003DzIpT00fBdiZkkG9dah6hKpLk_003D = _0023_003DzLos_0024H_dHfIKMMA5CKrpAhoU_003D;
			this._0023_003DzeyQd9LoOUlcN = _0023_003DzeyQd9LoOUlcN;
			this._0023_003DzJslIhmvq8gUMNVPkXdW9GPU_003D = _0023_003DzJslIhmvq8gUMNVPkXdW9GPU_003D;
		}

		public void _0023_003DzFITvoaXugyss(int _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzeyQd9LoOUlcN.V2 = _0023_003DzPzO_0024GUk_003D;
		}

		public int _0023_003DzLXzfFx__0024a_DT()
		{
			return _0023_003DzeyQd9LoOUlcN.V2;
		}

		public bool _0023_003DzVrp7M3MhiVzGD__KAw_003D_003D()
		{
			return _0023_003DzJslIhmvq8gUMNVPkXdW9GPU_003D == (_0023_003DzbH4ZsoQ_003D)0;
		}

		public override string ToString()
		{
			return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972368), _0023_003DzQW_0024hBdI_003D, _0023_003DzLXzfFx__0024a_DT(), _0023_003DznkPLPRg_003D);
		}
	}

	private sealed class _0023_003DzfKhYg_pIXj4J : ICloneable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Point3D _0023_003DzvgtE4SU_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public SharedEdge _0023_003Dz_eYYYA0_003D;

		public _0023_003DzfKhYg_pIXj4J(Point3D _0023_003DzlY77YgY_003D, SharedEdge _0023_003DzTx2aqr8_003D)
		{
			_0023_003DzvgtE4SU_003D = _0023_003DzlY77YgY_003D;
			_0023_003Dz_eYYYA0_003D = _0023_003DzTx2aqr8_003D;
		}

		public bool _0023_003Dza0ku3fI_003D(_0023_003DzfKhYg_pIXj4J _0023_003Dzl_0024MIsC0_003D)
		{
			return _0023_003DzvgtE4SU_003D == _0023_003Dzl_0024MIsC0_003D._0023_003DzvgtE4SU_003D;
		}

		public object Clone()
		{
			return new _0023_003DzfKhYg_pIXj4J((Point3D)_0023_003DzvgtE4SU_003D.Clone(), _0023_003Dz_eYYYA0_003D);
		}

		public override bool Equals(object _0023_003DzCX9Hbao_003D)
		{
			if (!(_0023_003DzCX9Hbao_003D is _0023_003DzfKhYg_pIXj4J))
			{
				return false;
			}
			return _0023_003Dza0ku3fI_003D((_0023_003DzfKhYg_pIXj4J)_0023_003DzCX9Hbao_003D);
		}

		public static bool operator ==(_0023_003DzfKhYg_pIXj4J _0023_003DzeMBeuAQ_003D, _0023_003DzfKhYg_pIXj4J _0023_003DznYtQKck_003D)
		{
			return object.Equals(_0023_003DzeMBeuAQ_003D, _0023_003DznYtQKck_003D);
		}

		public static bool operator !=(_0023_003DzfKhYg_pIXj4J _0023_003DzeMBeuAQ_003D, _0023_003DzfKhYg_pIXj4J _0023_003DznYtQKck_003D)
		{
			return !object.Equals(_0023_003DzeMBeuAQ_003D, _0023_003DznYtQKck_003D);
		}
	}

	private struct _0023_003DzuAiGvws_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal int _0023_003DzyzK8swU_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal byte _0023_003DzIuk3IWJaawETf43w_0024g_003D_003D;

		internal _0023_003DzuAiGvws_003D(int _0023_003DzyzK8swU_003D)
		{
			this._0023_003DzyzK8swU_003D = _0023_003DzyzK8swU_003D;
			_0023_003DzIuk3IWJaawETf43w_0024g_003D_003D = 0;
		}

		internal _0023_003DzuAiGvws_003D(int _0023_003DzyzK8swU_003D, byte _0023_003DzIuk3IWJaawETf43w_0024g_003D_003D)
		{
			this._0023_003DzyzK8swU_003D = _0023_003DzyzK8swU_003D;
			this._0023_003DzIuk3IWJaawETf43w_0024g_003D_003D = _0023_003DzIuk3IWJaawETf43w_0024g_003D_003D;
		}
	}

	internal sealed class _0023_003Dzzc0se7Kc60aD : IComparer<_0023_003DzczFDDB3cqe1d>
	{
		public int Compare(_0023_003DzczFDDB3cqe1d _0023_003DziMjqlCo_003D, _0023_003DzczFDDB3cqe1d _0023_003DzI4dRPW0_003D)
		{
			if (_0023_003DziMjqlCo_003D._0023_003DzQW_0024hBdI_003D < _0023_003DzI4dRPW0_003D._0023_003DzQW_0024hBdI_003D)
			{
				return -1;
			}
			if (_0023_003DziMjqlCo_003D._0023_003DzQW_0024hBdI_003D > _0023_003DzI4dRPW0_003D._0023_003DzQW_0024hBdI_003D)
			{
				return 1;
			}
			if (_0023_003DziMjqlCo_003D._0023_003DzLXzfFx__0024a_DT() < _0023_003DzI4dRPW0_003D._0023_003DzLXzfFx__0024a_DT())
			{
				return -1;
			}
			if (_0023_003DziMjqlCo_003D._0023_003DzLXzfFx__0024a_DT() > _0023_003DzI4dRPW0_003D._0023_003DzLXzfFx__0024a_DT())
			{
				return 1;
			}
			return 0;
		}
	}

	internal class DrawEdgesInternalParams
	{
		public double ampFactor;

		public IndexLine[] lines;

		public int Mode;

		public int[] floatPerSingleVertex;
	}

	public class FaceCollection : EyeshotDisposableCollection<FaceElement>
	{
		public void ClearIfNotSelected(List<SelectionInfoSubItems> selectedFaces)
		{
			if (!SelectionInfoSubItems.IsAnySelected(selectedFaces))
			{
				Clear();
			}
		}
	}

	public class FaceElement : IDisposable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private List<int> _0023_003DzED4AA72m_syxjEpBgdNshr3XvJZN;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal EntityGraphicsData _0023_003Dzgv_pSOc_003D;

		public List<int> Triangles
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzED4AA72m_syxjEpBgdNshr3XvJZN;
			}
			[CompilerGenerated]
			set
			{
				_0023_003DzED4AA72m_syxjEpBgdNshr3XvJZN = value;
			}
		}

		public FaceElement(List<int> triangles)
		{
			Triangles = triangles;
		}

		public void Dispose()
		{
			_0023_003Dzgv_pSOc_003D?.Dispose();
		}
	}

	public enum edgeStyleType : byte
	{
		None,
		Free,
		Sharp
	}

	public enum natureType : byte
	{
		Undefined,
		Plain,
		ColorPlain,
		MulticolorPlain,
		RichPlain,
		Smooth,
		ColorSmooth,
		MulticolorSmooth,
		RichSmooth
	}

	public enum normalAveragingType
	{
		Averaged,
		AveragedByAngle
	}

	[CompilerGenerated]
	private TextureMappingData _003CTextureMapping_003Ek__BackingField;

	internal natureType _meshNature;

	internal IndexTriangle[] _triangles;

	private Vector3D[] _normals;

	private PointF[] _texCoords;

	private normalAveragingType _normalAveraging = normalAveragingType.AveragedByAngle;

	private double _smoothingAngle = Math.PI / 6.0;

	private edgeStyleType _edgeStyle = edgeStyleType.Sharp;

	internal IndexLine[] _edges;

	internal int[,] sharedEdges;

	private bool _lightWeight;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static string _0023_003DzCRupKJbhwyN62YPt8Q_003D_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971916);

	protected internal EntityGraphicsData drawEdgesData;

	protected internal EntityGraphicsData drawSelectedData;

	private FaceCollection _faces;

	private selectionFilterType _selectionMode = selectionFilterType.Entity;

	public bool IsClosed
	{
		get
		{
			int[,] array = sharedEdges;
			if (array == null)
			{
				_0023_003Dz_0024YeSaS1uGUxB();
				array = sharedEdges;
				if (LightWeight)
				{
					sharedEdges = null;
				}
			}
			for (int i = 0; i < array.GetLength(0); i++)
			{
				if (array[i, 3] == -1)
				{
					return false;
				}
			}
			return true;
		}
	}

	public bool LightWeight
	{
		get
		{
			return _lightWeight;
		}
		set
		{
			if (value != _lightWeight && !value)
			{
				RegenMode = regenType.RegenAndCompile;
			}
			_lightWeight = value;
			if (value)
			{
				_edges = null;
				drawEdgesData?.Dispose();
				sharedEdges = null;
				silhoData = null;
			}
		}
	}

	public new virtual Point3D[] Vertices
	{
		get
		{
			return _vertices;
		}
		set
		{
			_vertices = value;
			_0023_003DzZTr16fkQpUZHJpROCQ_003D_003D();
			Normals = null;
			Edges = null;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public IndexTriangle[] Triangles
	{
		get
		{
			return _triangles;
		}
		set
		{
			_triangles = value;
			_0023_003DzZTr16fkQpUZHJpROCQ_003D_003D();
			Normals = null;
			Edges = null;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public IndexLine[] Edges
	{
		get
		{
			return _edges;
		}
		set
		{
			_edges = value;
			if (RegenMode == regenType.NotNeeded)
			{
				RegenMode = regenType.CompileOnly;
			}
		}
	}

	public normalAveragingType NormalAveragingMode
	{
		get
		{
			return _normalAveraging;
		}
		set
		{
			if (value != _normalAveraging)
			{
				_normals = null;
			}
			_normalAveraging = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public double SmoothingAngle
	{
		get
		{
			return _smoothingAngle;
		}
		set
		{
			_smoothingAngle = value;
			if (_smoothingAngle <= 0.0)
			{
				_smoothingAngle = Math.PI / 6.0;
			}
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public edgeStyleType EdgeStyle
	{
		get
		{
			return _edgeStyle;
		}
		set
		{
			_edgeStyle = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public Vector3D[] Normals
	{
		get
		{
			return _normals;
		}
		set
		{
			_normals = value;
			if (RegenMode == regenType.NotNeeded)
			{
				RegenMode = regenType.CompileOnly;
			}
			else
			{
				RegenMode = regenType.RegenAndCompile;
			}
		}
	}

	public natureType MeshNature => _meshNature;

	public PointF[] TextureCoords
	{
		get
		{
			return _texCoords;
		}
		set
		{
			_texCoords = value;
			if (RegenMode == regenType.NotNeeded)
			{
				RegenMode = regenType.CompileOnly;
			}
			else
			{
				RegenMode = regenType.RegenAndCompile;
			}
		}
	}

	internal List<SelectionInfoSubItems> FacesSelectionInfo { get; } = new List<SelectionInfoSubItems>();

	public FaceCollection Faces
	{
		get
		{
			return _faces;
		}
		set
		{
			_faces = value;
			FacesSelectionInfo.Clear();
		}
	}

	public selectionFilterType SelectionMode
	{
		get
		{
			return _selectionMode;
		}
		set
		{
			_selectionMode = value;
		}
	}

	public Mesh()
		: base(entityNatureType.Polygon)
	{
		_meshNature = natureType.Plain;
	}

	public Mesh(int numVertices, int numTriangles, natureType meshNature)
		: base(entityNatureType.None)
	{
		_vertices = new Point3D[numVertices];
		_triangles = new IndexTriangle[numTriangles];
		_meshNature = meshNature;
		natureType meshNature2 = _meshNature;
		if (meshNature2 == natureType.Plain || meshNature2 == natureType.Smooth)
		{
			base.entityNature = entityNatureType.Polygon;
		}
		else
		{
			base.entityNature = entityNatureType.RichPolygon;
		}
	}

	public Mesh(natureType meshNature)
		: base(entityNatureType.None)
	{
		_meshNature = meshNature;
		natureType meshNature2 = _meshNature;
		if (meshNature2 == natureType.Plain || meshNature2 == natureType.Smooth)
		{
			base.entityNature = entityNatureType.Polygon;
		}
		else
		{
			base.entityNature = entityNatureType.RichPolygon;
		}
	}

	public Mesh(natureType meshNature, edgeStyleType edgeStyle)
		: base(entityNatureType.None)
	{
		_0023_003DztGdcVOA_003D(meshNature, edgeStyle);
	}

	public Mesh(IList<Point3D> vertices, IList<IndexTriangle> triangles)
		: base(entityNatureType.None)
	{
		_vertices = new Point3D[vertices.Count];
		vertices.CopyTo(_vertices, 0);
		_triangles = new IndexTriangle[triangles.Count];
		triangles.CopyTo(_triangles, 0);
		_0023_003DzZTr16fkQpUZHJpROCQ_003D_003D();
	}

	protected Mesh(Mesh another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_meshNature = another._meshNature;
		if (!(another is Solid.Portion))
		{
			_vertices = new Point3D[another._vertices.Length];
			for (int i = 0; i < another._vertices.Length; i++)
			{
				_vertices[i] = (Point3D)another._vertices[i].Clone();
			}
		}
		if (another._triangles != null)
		{
			_triangles = new IndexTriangle[another._triangles.Length];
			for (int j = 0; j < another._triangles.Length; j++)
			{
				_triangles[j] = (IndexTriangle)another._triangles[j].Clone();
			}
			_normalAveraging = another._normalAveraging;
			_smoothingAngle = another._smoothingAngle;
			if (another._normals != null)
			{
				_normals = new Vector3D[another._normals.Length];
				for (int k = 0; k < another._normals.Length; k++)
				{
					_normals[k] = (Vector3D)another._normals[k].Clone();
				}
			}
			if (another._texCoords != null)
			{
				_texCoords = new PointF[another._texCoords.Length];
				for (int l = 0; l < another._texCoords.Length; l++)
				{
					_texCoords[l] = another._texCoords[l];
				}
			}
			_edgeStyle = another._edgeStyle;
			if (another._edges != null)
			{
				_edges = new IndexLine[another._edges.Length];
				for (int m = 0; m < another._edges.Length; m++)
				{
					_edges[m] = (IndexLine)another._edges[m].Clone();
				}
			}
		}
		LightWeight = another.LightWeight;
		if (another._0023_003DzLC0m8XdzNLv9() != null)
		{
			_0023_003DzUWlvoYKIdqVL((TextureMappingData)another._0023_003DzLC0m8XdzNLv9().Clone());
		}
	}

	protected internal Mesh(MeshSurrogate surrogate)
		: this(surrogate.GetMeshNature(), surrogate.GetEdgeStyle())
	{
	}

	public Mesh(SerializationInfo info, StreamingContext ctxt)
		: base(info, ctxt)
	{
		localMin = (Point3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972330), typeof(Point3D));
		localMax = (Point3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972314), typeof(Point3D));
		if (localMin != null && localMax != null)
		{
			UpdateBoundingBoxSphere();
			RegenMode = regenType.CompileOnly;
		}
		_meshNature = (natureType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972298), typeof(natureType));
		_vertices = (Point3D[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958678), typeof(Point3D[]));
		_triangles = (IndexTriangle[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968413), typeof(IndexTriangle[]));
		_normalAveraging = (normalAveragingType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972028), typeof(normalAveragingType));
		_smoothingAngle = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971992));
		_normals = (Vector3D[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968397), typeof(Vector3D[]));
		_edgeStyle = (edgeStyleType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971982), typeof(edgeStyleType));
		_edges = (IndexLine[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954162), typeof(IndexLine[]));
		_texCoords = (PointF[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971965), typeof(PointF[]));
		_lightWeight = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971927));
	}

	public List<List<int>> GetOpenBoundaries()
	{
		Utility.GetEdgesWithoutDuplicates(Triangles, Vertices.Length, out var edgesPerVertex);
		LinkedList<_0023_003DzRRw8cTuXzARo2_0024FCr6a4OZ1gr_eLH4nP5w_003D_003D>[] array = new LinkedList<_0023_003DzRRw8cTuXzARo2_0024FCr6a4OZ1gr_eLH4nP5w_003D_003D>[edgesPerVertex.Length];
		for (int i = 0; i < edgesPerVertex.Length; i++)
		{
			if (array[i] == null)
			{
				array[i] = new LinkedList<_0023_003DzRRw8cTuXzARo2_0024FCr6a4OZ1gr_eLH4nP5w_003D_003D>();
			}
			foreach (SharedEdge item in edgesPerVertex[i])
			{
				if (item.Dad <= 0)
				{
					if (array[item.V2] == null)
					{
						array[item.V2] = new LinkedList<_0023_003DzRRw8cTuXzARo2_0024FCr6a4OZ1gr_eLH4nP5w_003D_003D>();
					}
					int num = ((Triangles[item.Mum]._0023_003Dzg_0024_0024HtRw_003D(i) == item.V2) ? i : item.V2);
					int _0023_003DzCmn_5Z0_003D = ((num == i) ? item.V2 : i);
					_0023_003DzRRw8cTuXzARo2_0024FCr6a4OZ1gr_eLH4nP5w_003D_003D value = new _0023_003DzRRw8cTuXzARo2_0024FCr6a4OZ1gr_eLH4nP5w_003D_003D
					{
						_0023_003DzQW_0024hBdI_003D = num,
						_0023_003DzCmn_5Z0_003D = _0023_003DzCmn_5Z0_003D
					};
					array[num].AddLast(value);
				}
			}
		}
		List<List<int>> list = new List<List<int>>();
		List<int> list2 = new List<int>();
		for (int j = 0; j < array.Length; j++)
		{
			int num2 = -1;
			foreach (_0023_003DzRRw8cTuXzARo2_0024FCr6a4OZ1gr_eLH4nP5w_003D_003D item2 in array[j])
			{
				if (!item2._0023_003DzCKDF4rs_003D)
				{
					num2 = j;
					break;
				}
			}
			while (num2 >= 0)
			{
				list2.Add(num2);
				int num3 = -1;
				foreach (_0023_003DzRRw8cTuXzARo2_0024FCr6a4OZ1gr_eLH4nP5w_003D_003D item3 in array[num2])
				{
					if (!item3._0023_003DzCKDF4rs_003D)
					{
						item3._0023_003DzCKDF4rs_003D = true;
						num3 = item3._0023_003Dzg_0024_0024HtRw_003D(num2);
						if (list2.Contains(num3))
						{
							int num4 = list2.IndexOf(num3);
							int count = list2.Count - num4;
							List<int> range = list2.GetRange(num4, count);
							list2.RemoveRange(num4, count);
							list.Add(range);
						}
						break;
					}
				}
				num2 = num3;
			}
		}
		return list;
	}

	public void GetOpenBoundaries(out Point3D[][] contours)
	{
		List<List<int>> openBoundaries = GetOpenBoundaries();
		contours = new Point3D[openBoundaries.Count][];
		for (int i = 0; i < contours.Length; i++)
		{
			int count = openBoundaries[i].Count;
			contours[i] = new Point3D[count + 1];
			for (int j = 0; j < count; j++)
			{
				contours[i][j] = Vertices[openBoundaries[i][j]];
			}
			contours[i][count] = (Point3D)contours[i][0].Clone();
		}
	}

	public bool Is2Manifold()
	{
		Dictionary<int, int>[] array = new Dictionary<int, int>[Vertices.Length];
		for (int i = 0; i < Vertices.Length; i++)
		{
			array[i] = new Dictionary<int, int>();
		}
		IndexTriangle[] triangles = Triangles;
		foreach (IndexTriangle indexTriangle in triangles)
		{
			if (_0023_003DzRm7vplc_003D(array, indexTriangle.V1, indexTriangle.V2) > 2)
			{
				return false;
			}
			if (_0023_003DzRm7vplc_003D(array, indexTriangle.V2, indexTriangle.V3) > 2)
			{
				return false;
			}
			if (_0023_003DzRm7vplc_003D(array, indexTriangle.V3, indexTriangle.V1) > 2)
			{
				return false;
			}
		}
		return true;
	}

	private int _0023_003DzRm7vplc_003D(Dictionary<int, int>[] _0023_003DzjCqmL1eEbQrypi4BJSuxWOY_003D, int _0023_003Dz77g161c_003D, int _0023_003DzN6G05Lg_003D)
	{
		if (_0023_003DzjCqmL1eEbQrypi4BJSuxWOY_003D[_0023_003Dz77g161c_003D].ContainsKey(_0023_003DzN6G05Lg_003D))
		{
			_0023_003DzjCqmL1eEbQrypi4BJSuxWOY_003D[_0023_003Dz77g161c_003D][_0023_003DzN6G05Lg_003D]++;
		}
		else
		{
			_0023_003DzjCqmL1eEbQrypi4BJSuxWOY_003D[_0023_003Dz77g161c_003D][_0023_003DzN6G05Lg_003D] = 1;
		}
		if (!_0023_003DzjCqmL1eEbQrypi4BJSuxWOY_003D[_0023_003DzN6G05Lg_003D].ContainsKey(_0023_003Dz77g161c_003D))
		{
			_0023_003DzjCqmL1eEbQrypi4BJSuxWOY_003D[_0023_003DzN6G05Lg_003D][_0023_003Dz77g161c_003D] = 0;
		}
		return _0023_003DzjCqmL1eEbQrypi4BJSuxWOY_003D[_0023_003DzN6G05Lg_003D][_0023_003Dz77g161c_003D] + _0023_003DzjCqmL1eEbQrypi4BJSuxWOY_003D[_0023_003Dz77g161c_003D][_0023_003DzN6G05Lg_003D];
	}

	public static Mesh CreateBox(double width, double depth, double height)
	{
		return CreateBox<Mesh>(width, depth, height, natureType.Plain);
	}

	public static T CreateBox<T>(double width, double depth, double height) where T : Mesh, new()
	{
		T val = CreateBox<T>(width, depth, height, natureType.Plain);
		val.UpdateBoundingBox(null);
		val.RegenMode = regenType.CompileOnly;
		return val;
	}

	public static Mesh CreateBox(double width, double depth, double height, natureType meshNature)
	{
		return CreateBox<Mesh>(width, depth, height, meshNature, edgeStyleType.Sharp);
	}

	public static T CreateBox<T>(double width, double depth, double height, natureType meshNature) where T : Mesh, new()
	{
		return CreateBox<T>(width, depth, height, meshNature, edgeStyleType.Sharp);
	}

	public static Mesh CreateBox(double width, double depth, double height, natureType meshNature, edgeStyleType edgeStyle)
	{
		return CreateBox<Mesh>(width, depth, height, meshNature, edgeStyle);
	}

	public static T CreateBox<T>(double width, double depth, double height, natureType meshNature, edgeStyleType edgeStyle) where T : Mesh, new()
	{
		T val = new T();
		val._0023_003DztGdcVOA_003D(meshNature, edgeStyle);
		if (!val._0023_003Dz4SGxVqPpXSiw(width, depth, height))
		{
			throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972050));
		}
		val.UpdateBoundingBox(null);
		val.RegenMode = regenType.CompileOnly;
		return val;
	}

	private bool _0023_003Dz4SGxVqPpXSiw(double _0023_003Dz6tVBpdk_003D, double _0023_003DzvxHPuJA_003D, double _0023_003DzvAxV_0024Ic_003D)
	{
		if (_0023_003Dz6tVBpdk_003D < Utility._0023_003DzheSR8QM7q9ya || _0023_003DzvxHPuJA_003D < Utility._0023_003DzheSR8QM7q9ya || _0023_003DzvAxV_0024Ic_003D < Utility._0023_003DzheSR8QM7q9ya)
		{
			return false;
		}
		_vertices = new Point3D[8];
		_vertices[0] = Utility.CreateVertex(_meshNature, 0.0, 0.0, 0.0);
		_vertices[1] = Utility.CreateVertex(_meshNature, _0023_003Dz6tVBpdk_003D, 0.0, 0.0);
		_vertices[2] = Utility.CreateVertex(_meshNature, _0023_003Dz6tVBpdk_003D, _0023_003DzvxHPuJA_003D, 0.0);
		_vertices[3] = Utility.CreateVertex(_meshNature, 0.0, _0023_003DzvxHPuJA_003D, 0.0);
		_vertices[4] = Utility.CreateVertex(_meshNature, 0.0, 0.0, _0023_003DzvAxV_0024Ic_003D);
		_vertices[5] = Utility.CreateVertex(_meshNature, _0023_003Dz6tVBpdk_003D, 0.0, _0023_003DzvAxV_0024Ic_003D);
		_vertices[6] = Utility.CreateVertex(_meshNature, _0023_003Dz6tVBpdk_003D, _0023_003DzvxHPuJA_003D, _0023_003DzvAxV_0024Ic_003D);
		_vertices[7] = Utility.CreateVertex(_meshNature, 0.0, _0023_003DzvxHPuJA_003D, _0023_003DzvAxV_0024Ic_003D);
		natureType meshNature = _meshNature;
		if (meshNature - 1 <= natureType.MulticolorPlain)
		{
			_normals = new Vector3D[12];
			_normals[0] = new Vector3D(0.0, 0.0, -1.0);
			_normals[1] = new Vector3D(0.0, 0.0, -1.0);
			_normals[2] = new Vector3D(0.0, -1.0, 0.0);
			_normals[3] = new Vector3D(0.0, -1.0, 0.0);
			_normals[4] = new Vector3D(1.0, 0.0, 0.0);
			_normals[5] = new Vector3D(1.0, 0.0, 0.0);
			_normals[6] = new Vector3D(0.0, 1.0, 0.0);
			_normals[7] = new Vector3D(0.0, 1.0, 0.0);
			_normals[8] = new Vector3D(-1.0, 0.0, 0.0);
			_normals[9] = new Vector3D(-1.0, 0.0, 0.0);
			_normals[10] = new Vector3D(0.0, 0.0, 1.0);
			_normals[11] = new Vector3D(0.0, 0.0, 1.0);
			_triangles = new IndexTriangle[12];
			_triangles[0] = Utility.CreateTriangle(_meshNature, 3, 2, 1);
			_triangles[1] = Utility.CreateTriangle(_meshNature, 3, 1, 0);
			_triangles[2] = Utility.CreateTriangle(_meshNature, 0, 1, 5);
			_triangles[3] = Utility.CreateTriangle(_meshNature, 0, 5, 4);
			_triangles[4] = Utility.CreateTriangle(_meshNature, 1, 2, 6);
			_triangles[5] = Utility.CreateTriangle(_meshNature, 1, 6, 5);
			_triangles[6] = Utility.CreateTriangle(_meshNature, 2, 3, 7);
			_triangles[7] = Utility.CreateTriangle(_meshNature, 2, 7, 6);
			_triangles[8] = Utility.CreateTriangle(_meshNature, 3, 0, 4);
			_triangles[9] = Utility.CreateTriangle(_meshNature, 3, 4, 7);
			_triangles[10] = Utility.CreateTriangle(_meshNature, 4, 5, 6);
			_triangles[11] = Utility.CreateTriangle(_meshNature, 4, 6, 7);
		}
		else
		{
			_normals = new Vector3D[6];
			_normals[0] = new Vector3D(0.0, 0.0, -1.0);
			_normals[1] = new Vector3D(0.0, -1.0, 0.0);
			_normals[2] = new Vector3D(1.0, 0.0, 0.0);
			_normals[3] = new Vector3D(0.0, 1.0, 0.0);
			_normals[4] = new Vector3D(-1.0, 0.0, 0.0);
			_normals[5] = new Vector3D(0.0, 0.0, 1.0);
			_triangles = new IndexTriangle[12];
			_triangles[0] = Utility.CreateTriangle(_meshNature, 3, 2, 1, 0, 0, 0);
			_triangles[1] = Utility.CreateTriangle(_meshNature, 3, 1, 0, 0, 0, 0);
			_triangles[2] = Utility.CreateTriangle(_meshNature, 0, 1, 5, 1, 1, 1);
			_triangles[3] = Utility.CreateTriangle(_meshNature, 0, 5, 4, 1, 1, 1);
			_triangles[4] = Utility.CreateTriangle(_meshNature, 1, 2, 6, 2, 2, 2);
			_triangles[5] = Utility.CreateTriangle(_meshNature, 1, 6, 5, 2, 2, 2);
			_triangles[6] = Utility.CreateTriangle(_meshNature, 2, 3, 7, 3, 3, 3);
			_triangles[7] = Utility.CreateTriangle(_meshNature, 2, 7, 6, 3, 3, 3);
			_triangles[8] = Utility.CreateTriangle(_meshNature, 3, 0, 4, 4, 4, 4);
			_triangles[9] = Utility.CreateTriangle(_meshNature, 3, 4, 7, 4, 4, 4);
			_triangles[10] = Utility.CreateTriangle(_meshNature, 4, 5, 6, 5, 5, 5);
			_triangles[11] = Utility.CreateTriangle(_meshNature, 4, 6, 7, 5, 5, 5);
		}
		if (_edgeStyle == edgeStyleType.Sharp)
		{
			_edges = new IndexLine[12];
			_edges[0] = new IndexLine(0, 1);
			_edges[1] = new IndexLine(1, 2);
			_edges[2] = new IndexLine(2, 3);
			_edges[3] = new IndexLine(3, 0);
			_edges[4] = new IndexLine(4, 5);
			_edges[5] = new IndexLine(5, 6);
			_edges[6] = new IndexLine(6, 7);
			_edges[7] = new IndexLine(7, 4);
			_edges[8] = new IndexLine(0, 4);
			_edges[9] = new IndexLine(1, 5);
			_edges[10] = new IndexLine(2, 6);
			_edges[11] = new IndexLine(3, 7);
		}
		return true;
	}

	public static Mesh CreateCone(double baseRadius, double topRadius, double height, int slices)
	{
		return CreateCone<Mesh>(baseRadius, topRadius, height, slices);
	}

	public static T CreateCone<T>(double baseRadius, double topRadius, double height, int slices) where T : Mesh, new()
	{
		return CreateCone<T>(baseRadius, topRadius, height, slices, natureType.Smooth);
	}

	public static Mesh CreateCone(double baseRadius, double topRadius, double height, int slices, natureType meshNature)
	{
		return CreateCone<Mesh>(baseRadius, topRadius, height, slices, meshNature, edgeStyleType.Sharp);
	}

	public static T CreateCone<T>(double baseRadius, double topRadius, double height, int slices, natureType meshNature) where T : Mesh, new()
	{
		return CreateCone<T>(baseRadius, topRadius, height, slices, meshNature, edgeStyleType.Sharp);
	}

	public static Mesh CreateCone(double baseRadius, double topRadius, double height, int slices, natureType meshNature, edgeStyleType edgeStyle)
	{
		return CreateCone<Mesh>(baseRadius, topRadius, height, slices, meshNature, edgeStyle);
	}

	public static T CreateCone<T>(double baseRadius, double topRadius, double height, int slices, natureType meshNature, edgeStyleType edgeStyle) where T : Mesh, new()
	{
		T val = new T();
		val._0023_003DztGdcVOA_003D(meshNature, edgeStyle);
		if (!val._0023_003DzvYp00FU_Q3AJ(baseRadius, topRadius, height, slices))
		{
			throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971518));
		}
		val.UpdateBoundingBox(null);
		val.RegenMode = regenType.CompileOnly;
		return val;
	}

	public static Mesh CreateCone(double baseRadius, double topRadius, Point3D point1, Point3D point2, int slices)
	{
		return CreateCone<Mesh>(baseRadius, topRadius, point1, point2, slices, natureType.Plain);
	}

	public static T CreateCone<T>(double baseRadius, double topRadius, Point3D point1, Point3D point2, int slices) where T : Mesh, new()
	{
		return CreateCone<T>(baseRadius, topRadius, point1, point2, slices, natureType.Plain);
	}

	public static Mesh CreateCone(double baseRadius, double topRadius, Point3D point1, Point3D point2, int slices, natureType meshNature)
	{
		return CreateCone<Mesh>(baseRadius, topRadius, point1, point2, slices, meshNature, edgeStyleType.Sharp);
	}

	public static T CreateCone<T>(double baseRadius, double topRadius, Point3D point1, Point3D point2, int slices, natureType meshNature) where T : Mesh, new()
	{
		return CreateCone<T>(baseRadius, topRadius, point1, point2, slices, meshNature, edgeStyleType.Sharp);
	}

	public static Mesh CreateCone(double baseRadius, double topRadius, Point3D point1, Point3D point2, int slices, natureType meshNature, edgeStyleType edgeStyle)
	{
		return CreateCone<Mesh>(baseRadius, topRadius, point1, point2, slices, meshNature, edgeStyle);
	}

	public static T CreateCone<T>(double baseRadius, double topRadius, Point3D point1, Point3D point2, int slices, natureType meshNature, edgeStyleType edgeStyle) where T : Mesh, new()
	{
		Vector3D vector3D = Vector3D.Subtract(point2, point1);
		T val = new T();
		val._0023_003DztGdcVOA_003D(meshNature, edgeStyle);
		if (!val._0023_003DzvYp00FU_Q3AJ(baseRadius, topRadius, vector3D.Length, slices))
		{
			throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971518));
		}
		val.TransformBy(Utility.GetOrientationTransformation(point1, vector3D) * new devDept.Geometry.Rotation(Math.PI / 2.0, Vector3D.AxisY));
		val.UpdateBoundingBox(null);
		val.RegenMode = regenType.CompileOnly;
		return val;
	}

	private bool _0023_003DzvYp00FU_Q3AJ(double _0023_003Dzu2WOTs7Tkxr9, double _0023_003DztxiQyb1nzdKs, double _0023_003DzvAxV_0024Ic_003D, int _0023_003DzAPBIJmvn5i5Q)
	{
		if ((_0023_003Dzu2WOTs7Tkxr9 < Utility._0023_003DzheSR8QM7q9ya && _0023_003DztxiQyb1nzdKs < Utility._0023_003DzheSR8QM7q9ya) || _0023_003DzvAxV_0024Ic_003D < Utility._0023_003DzheSR8QM7q9ya || _0023_003DzAPBIJmvn5i5Q < 3)
		{
			return false;
		}
		bool flag = true;
		natureType meshNature = _meshNature;
		if (meshNature - 1 <= natureType.MulticolorPlain)
		{
			flag = false;
		}
		Utility.CreateCone(_meshNature, _0023_003Dzu2WOTs7Tkxr9, _0023_003DztxiQyb1nzdKs, _0023_003DzvAxV_0024Ic_003D, _0023_003DzAPBIJmvn5i5Q, flag, out var firstBaseCenter, out var nCaps, out _vertices, out _triangles, out _normals);
		if (_edgeStyle == edgeStyleType.Sharp)
		{
			_edges = new IndexLine[firstBaseCenter];
			int num = 0;
			for (int i = 0; i < _0023_003DzAPBIJmvn5i5Q; i++)
			{
				if (i + 1 < _0023_003DzAPBIJmvn5i5Q)
				{
					_edges[num++] = new IndexLine(i, i + 1);
				}
				else
				{
					_edges[num++] = new IndexLine(i, 0);
				}
			}
			if (nCaps == 2)
			{
				for (int j = _0023_003DzAPBIJmvn5i5Q; j < _0023_003DzAPBIJmvn5i5Q * 2; j++)
				{
					if (j + 1 < _0023_003DzAPBIJmvn5i5Q * 2)
					{
						_edges[num++] = new IndexLine(j, j + 1);
					}
					else
					{
						_edges[num++] = new IndexLine(j, _0023_003DzAPBIJmvn5i5Q);
					}
				}
			}
		}
		if (!flag)
		{
			UpdateNormals();
		}
		return true;
	}

	public static Mesh CreatePlanar(Plane sketchPlane, IList<Point2D> outer, natureType meshNature)
	{
		return CreatePlanar<Mesh>(sketchPlane, outer, null, meshNature);
	}

	public static T CreatePlanar<T>(Plane sketchPlane, IList<Point2D> outer, natureType meshNature) where T : Mesh, new()
	{
		return CreatePlanar<T>(sketchPlane, outer, null, meshNature);
	}

	public static Mesh CreatePlanar(Plane sketchPlane, IList<Point2D> outer, IList<IList<Point2D>> inners, natureType meshNature)
	{
		return _0023_003DzrXbqquWbOFtc<Point2D, Mesh>(sketchPlane, outer, inners, meshNature);
	}

	public static T CreatePlanar<T>(Plane sketchPlane, IList<Point2D> outer, IList<IList<Point2D>> inners, natureType meshNature) where T : Mesh, new()
	{
		return _0023_003DzrXbqquWbOFtc<Point2D, T>(sketchPlane, outer, inners, meshNature);
	}

	public static Mesh CreatePlanar(IList<Point3D> outer, natureType meshNature)
	{
		return CreatePlanar<Mesh>(outer, null, meshNature);
	}

	public static T CreatePlanar<T>(IList<Point3D> outer, natureType meshNature) where T : Mesh, new()
	{
		return CreatePlanar<T>(outer, null, meshNature);
	}

	public static Mesh CreatePlanar(IList<Point3D> outer, IList<IList<Point3D>> inners, natureType meshNature)
	{
		return _0023_003DzrXbqquWbOFtc<Point3D, Mesh>(null, outer, inners, meshNature);
	}

	public static T CreatePlanar<T>(IList<Point3D> outer, IList<IList<Point3D>> inners, natureType meshNature) where T : Mesh, new()
	{
		return _0023_003DzrXbqquWbOFtc<Point3D, T>(null, outer, inners, meshNature);
	}

	[Obsolete("Use Region.ConvertToMesh() instead.")]
	public static Mesh CreatePlanar(ICurve outer, double tolerance, natureType meshNature)
	{
		return CreatePlanar<Mesh>(outer, null, tolerance, meshNature);
	}

	internal static T _0023_003DzdkFbg3fdF92xAt0JuQ_003D_003D<T>(ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D) where T : Mesh, new()
	{
		Utility._0023_003Dz5qFihJK3ui08U0cFuA_003D_003D(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, out var _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out var _0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D);
		return CreatePlanar<T>(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
	}

	internal static T _0023_003DzranJPDlPiZC7<T>(ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, RegenParams _0023_003DzELu0Pss_003D, natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D) where T : Mesh, new()
	{
		Utility._0023_003Dz5qFihJK3ui08U0cFuA_003D_003D(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzELu0Pss_003D, out var _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out var _0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D);
		return CreatePlanar<T>(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
	}

	[Obsolete("Use Region.ConvertToMesh() instead.")]
	public static Mesh CreatePlanar(ICurve outer, IList<ICurve> inners, double tolerance, natureType meshNature)
	{
		Utility._0023_003Dz5qFihJK3ui08U0cFuA_003D_003D(outer, inners, tolerance, out var _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out var _0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D);
		return CreatePlanar(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D, meshNature);
	}

	[Obsolete("Use Region.ConvertToMesh() instead.")]
	public static T CreatePlanar<T>(ICurve outer, IList<ICurve> inners, double tolerance, natureType meshNature) where T : Mesh, new()
	{
		Utility._0023_003Dz5qFihJK3ui08U0cFuA_003D_003D(outer, inners, tolerance, out var _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out var _0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D);
		return CreatePlanar<T>(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D, meshNature);
	}

	internal static M _0023_003DzrXbqquWbOFtc<T, M>(Plane _0023_003DzJ7Ot5RuMhdMpo_6azw_003D_003D, IList<T> _0023_003Dz_SqBXz8_003D, IList<IList<T>> _0023_003DzWaFlkhfmYCja, natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D) where T : Point2D where M : Mesh, new()
	{
		IList<Point2D> _0023_003DzJB9yXb3atfkL;
		IList<IList<Point2D>> _0023_003DzLYWjuc33iWj_BX5R_0024A_003D_003D;
		Plane plane = _0023_003DzAjvTF_0024wZzMN0keVuvw_003D_003D(_0023_003DzJ7Ot5RuMhdMpo_6azw_003D_003D, _0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, out _0023_003DzJB9yXb3atfkL, out _0023_003DzLYWjuc33iWj_BX5R_0024A_003D_003D);
		if (plane == null)
		{
			return null;
		}
		M val = new M();
		val._0023_003DztGdcVOA_003D(_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, edgeStyleType.Sharp);
		try
		{
			if (Utility.Triangulate(_0023_003DzJB9yXb3atfkL, _0023_003DzLYWjuc33iWj_BX5R_0024A_003D_003D, fixOrientation: false, checkValidity: true, out var vertices, out var triangles))
			{
				val._0023_003DzOwrB4MXYn7Qh4dRPyg5n_yIxBWPX(vertices, triangles);
				_0023_003DzRPB8Ocs_003D(plane, val._vertices, val._vertices.Length);
			}
			else
			{
				val._vertices = new Point3D[0];
				val._triangles = new IndexTriangle[0];
			}
		}
		catch (Exception)
		{
			val._vertices = new Point3D[0];
			val._triangles = new IndexTriangle[0];
		}
		return val;
	}

	internal static Plane _0023_003DzAjvTF_0024wZzMN0keVuvw_003D_003D<T>(Plane _0023_003DzJ7Ot5RuMhdMpo_6azw_003D_003D, IList<T> _0023_003Dz_SqBXz8_003D, IList<IList<T>> _0023_003DzWaFlkhfmYCja, out IList<Point2D> _0023_003DzJB9yXb3atfkL, out IList<IList<Point2D>> _0023_003DzLYWjuc33iWj_BX5R_0024A_003D_003D) where T : Point2D
	{
		_0023_003DzJB9yXb3atfkL = null;
		_0023_003DzLYWjuc33iWj_BX5R_0024A_003D_003D = null;
		bool flag = typeof(T) == typeof(Point3D);
		Plane plane = ((!flag || !(_0023_003DzJ7Ot5RuMhdMpo_6azw_003D_003D == null)) ? _0023_003DzJ7Ot5RuMhdMpo_6azw_003D_003D : Utility.GetContourPlane((IList<Point3D>)_0023_003Dz_SqBXz8_003D));
		_0023_003Dz_SqBXz8_003D = Utility.RemoveDuplicates(_0023_003Dz_SqBXz8_003D);
		if (_0023_003DzWaFlkhfmYCja != null)
		{
			for (int i = 0; i < _0023_003DzWaFlkhfmYCja.Count; i++)
			{
				_0023_003DzWaFlkhfmYCja[i] = Utility.RemoveDuplicates(_0023_003DzWaFlkhfmYCja[i]);
			}
		}
		if (plane != null)
		{
			if (flag)
			{
				_0023_003DzzgKMdKw_003D((IList<Point3D>)_0023_003Dz_SqBXz8_003D, (IList<IList<Point3D>>)_0023_003DzWaFlkhfmYCja, plane, out _0023_003DzJB9yXb3atfkL, out _0023_003DzLYWjuc33iWj_BX5R_0024A_003D_003D);
			}
			else
			{
				_0023_003DzJB9yXb3atfkL = (IList<Point2D>)_0023_003Dz_SqBXz8_003D;
				_0023_003DzLYWjuc33iWj_BX5R_0024A_003D_003D = (IList<IList<Point2D>>)_0023_003DzWaFlkhfmYCja;
			}
		}
		return plane;
	}

	internal TextureMappingData _0023_003DzLC0m8XdzNLv9()
	{
		return _003CTextureMapping_003Ek__BackingField;
	}

	internal void _0023_003DzUWlvoYKIdqVL(TextureMappingData _0023_003DzPzO_0024GUk_003D)
	{
		_003CTextureMapping_003Ek__BackingField = _0023_003DzPzO_0024GUk_003D;
	}

	internal void _0023_003DztGdcVOA_003D(natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, edgeStyleType _0023_003Dzp4s_iREqDk59)
	{
		_meshNature = _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D;
		natureType meshNature = _meshNature;
		if (meshNature == natureType.Plain || meshNature == natureType.Smooth)
		{
			base.entityNature = entityNatureType.Polygon;
		}
		else
		{
			base.entityNature = entityNatureType.RichPolygon;
		}
		_edgeStyle = _0023_003Dzp4s_iREqDk59;
	}

	public override object Clone()
	{
		return new Mesh(this);
	}

	public override object CloneWithTessellation()
	{
		return new Mesh(this, RegenMode != regenType.RegenAndCompile);
	}

	private protected override void _0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(Entity _0023_003Dzb7SPTpc_003D)
	{
	}

	public bool IsPointInside(Point3D point)
	{
		if (base.BoxMin != null && !point.IsInside(base.BoxMin, base.BoxMax))
		{
			return false;
		}
		int num = _0023_003DzVb4wZyDw8mgJ(point, (Utility._0023_003DzwhtOFTk_003D)0);
		if (num != -1)
		{
			return num == 1;
		}
		int num2 = _0023_003DzVb4wZyDw8mgJ(point, (Utility._0023_003DzwhtOFTk_003D)2);
		if (num2 != -1)
		{
			return num2 == 1;
		}
		return _0023_003DzVb4wZyDw8mgJ(point, (Utility._0023_003DzwhtOFTk_003D)1) == 1;
	}

	private int _0023_003DzVb4wZyDw8mgJ(Point3D _0023_003DzlY77YgY_003D, Utility._0023_003DzwhtOFTk_003D _0023_003DzxuJqjrs_003D)
	{
		int num = 0;
		Segment3D[] array = new Segment3D[4];
		Segment3D segment3D = Utility._0023_003DzDoIUcjWkjZQJ(_0023_003DzlY77YgY_003D, _0023_003DzxuJqjrs_003D, _0023_003DzlY77YgY_003D, _0023_003DzlY77YgY_003D, 0.0);
		Segment3D segment3D2 = Utility._0023_003DzDoIUcjWkjZQJ(_0023_003DzlY77YgY_003D, _0023_003DzxuJqjrs_003D, _0023_003DzlY77YgY_003D, _0023_003DzlY77YgY_003D, Utility.DegToRad(10.0));
		array[0] = new Segment3D(_0023_003DzlY77YgY_003D, segment3D.P1);
		array[1] = new Segment3D(_0023_003DzlY77YgY_003D, segment3D.P0);
		array[2] = new Segment3D(_0023_003DzlY77YgY_003D, segment3D2.P1);
		array[3] = new Segment3D(_0023_003DzlY77YgY_003D, segment3D2.P0);
		for (int i = 0; i < array.Length; i++)
		{
			num = new _0023_003DzHmskY20KXdJOW_00243F6wRpODq1NebVl0P4FDPwKYzjyie7(_vertices, _triangles, _edges)._0023_003Dz3WVjyBfqduu95gCh_0024A_003D_003D(array[i], _0023_003DzlY77YgY_003D, (i < 2) ? _0023_003DzxuJqjrs_003D : ((Utility._0023_003DzwhtOFTk_003D)3));
			if (num != -1)
			{
				return num;
			}
		}
		return num;
	}

	public booleanFailureType CutBy(Plane plane)
	{
		booleanFailureType result = _0023_003DzBVSD8WPcX9kp(plane, (_0023_003DzNuun60qGd2Yq)2);
		RegenMode = regenType.RegenAndCompile;
		return result;
	}

	public booleanFailureType CutBy(Plane plane, bool close)
	{
		RegenMode = regenType.RegenAndCompile;
		if (close)
		{
			return _0023_003DzBVSD8WPcX9kp(plane, (_0023_003DzNuun60qGd2Yq)2);
		}
		return _0023_003DzBVSD8WPcX9kp(plane, (_0023_003DzNuun60qGd2Yq)1);
	}

	internal booleanFailureType _0023_003DzBVSD8WPcX9kp(Plane _0023_003Dzrgqz890sj_0024X9, _0023_003DzNuun60qGd2Yq _0023_003DzEKSHIVc_003D)
	{
		if (RegenMode == regenType.RegenAndCompile)
		{
			Regen(0.0);
		}
		bool flag = _0023_003DzEKSHIVc_003D switch
		{
			(_0023_003DzNuun60qGd2Yq)0 => true, 
			(_0023_003DzNuun60qGd2Yq)1 => false, 
			(_0023_003DzNuun60qGd2Yq)2 => IsClosed, 
			_ => IsClosed, 
		};
		ICurve[] array = null;
		if (flag)
		{
			array = Section(_0023_003Dzrgqz890sj_0024X9, 0.0);
			if (array.Length == 0)
			{
				return booleanFailureType.NotIntersecting;
			}
		}
		if (SubdivideBy(_0023_003Dzrgqz890sj_0024X9) == booleanFailureType.NotIntersecting)
		{
			return booleanFailureType.NotIntersecting;
		}
		List<Point3D> list = new List<Point3D>();
		List<IndexTriangle> list2 = new List<IndexTriangle>();
		int[] array2 = new int[_vertices.Length];
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i] = -1;
		}
		int num = 0;
		int _0023_003DzhYy1dJQ_003D = 0;
		int[][] array3 = ((array == null) ? null : new int[array.Length][]);
		if (array3 != null)
		{
			for (int j = 0; j < array.Length; j++)
			{
				int num2 = ((LinearPath)array[j]).Vertices.Length;
				array3[j] = new int[num2];
				for (int k = 0; k < num2; k++)
				{
					array3[j][k] = -1;
				}
			}
		}
		IndexTriangle[] triangles = Triangles;
		foreach (IndexTriangle indexTriangle in triangles)
		{
			Point3D[] array4 = new Point3D[3]
			{
				Vertices[indexTriangle.V1],
				Vertices[indexTriangle.V2],
				Vertices[indexTriangle.V3]
			};
			int[] array5 = new int[3] { indexTriangle.V1, indexTriangle.V2, indexTriangle.V3 };
			Point3D point = _0023_003DzDeCArp_a0IgzwwfUV3LMILs_003D(array4);
			if (!(_0023_003Dzrgqz890sj_0024X9.DistanceTo(point) < 0.0))
			{
				continue;
			}
			if (array != null)
			{
				for (int m = 0; m < array4.Length; m++)
				{
					Point3D point3D = array4[m];
					for (int n = 0; n < array.Length; n++)
					{
						LinearPath linearPath = (LinearPath)array[n];
						int num3;
						for (num3 = 0; num3 < linearPath.Vertices.Length; num3++)
						{
							if (point3D == linearPath.Vertices[num3])
							{
								if (array2[array5[m]] >= 0)
								{
									array3[n][num3] = array2[array5[m]];
								}
								else
								{
									array3[n][num3] = num;
								}
								break;
							}
						}
						if (num3 < linearPath.Vertices.Length)
						{
							break;
						}
					}
					if (array2[array5[m]] < 0)
					{
						num++;
					}
				}
			}
			_0023_003Dz_LICwio_003D(list, list2, ref _0023_003DzhYy1dJQ_003D, array2, indexTriangle, array4);
			num = _0023_003DzhYy1dJQ_003D;
		}
		_vertices = list.ToArray();
		if (flag && array != null)
		{
			Utility._0023_003Dzn4KqhjbmsZs5gdTzPejzj_0024M_003D(array, out var _0023_003DzsdySxIlQLgFZ, out var _0023_003DzWaFlkhfmYCja, 1.0, _0023_003Dzrgqz890sj_0024X9);
			Mesh[] array6 = new Mesh[_0023_003DzsdySxIlQLgFZ.Length];
			for (int num4 = 0; num4 < array6.Length; num4++)
			{
				IList<IList<Point3D>> list3 = new IList<Point3D>[_0023_003DzWaFlkhfmYCja[num4].Length];
				for (int num5 = 0; num5 < _0023_003DzWaFlkhfmYCja[num4].Length; num5++)
				{
					list3[num5] = ((LinearPath)array[_0023_003DzWaFlkhfmYCja[num4][num5]]).Vertices;
				}
				IList<Point3D> vertices = ((LinearPath)array[_0023_003DzsdySxIlQLgFZ[num4]]).Vertices;
				array6[num4] = CreatePlanar(vertices, list3, _meshNature);
				int[] array7 = new int[array6[num4].Vertices.Length];
				for (int num6 = 0; num6 < array6[num4].Vertices.Length; num6++)
				{
					int num7;
					for (num7 = 0; num7 < array.Length; num7++)
					{
						LinearPath linearPath2 = (LinearPath)array[num7];
						int num8;
						for (num8 = 0; num8 < linearPath2.Vertices.Length; num8++)
						{
							if (array6[num4].Vertices[num6] == linearPath2.Vertices[num8])
							{
								array7[num6] = array3[num7][num8];
								break;
							}
						}
						if (num8 < linearPath2.Vertices.Length)
						{
							break;
						}
					}
					if (num7 == array.Length)
					{
						array7[num6] = -1;
					}
				}
				triangles = array6[num4].Triangles;
				foreach (IndexTriangle indexTriangle2 in triangles)
				{
					int num9 = array7[indexTriangle2.V1];
					int num10 = array7[indexTriangle2.V2];
					int num11 = array7[indexTriangle2.V3];
					if (num9 != -1 && num10 != -1 && num11 != -1)
					{
						_0023_003Dz_LICwio_003D(this, num9, num10, num11, list2);
					}
				}
			}
		}
		_triangles = list2.ToArray();
		UpdateNormals();
		RegenMode = regenType.RegenAndCompile;
		sharedEdges = Utility.GetEdgesWithoutDuplicates(_triangles, _vertices.Length);
		_0023_003Dz_T6MNYD65ZA4();
		return booleanFailureType.Success;
	}

	private static void _0023_003Dz_LICwio_003D(Mesh _0023_003DzGGJSiQk_003D, int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D, int _0023_003DzZe6oCrQ_003D, List<IndexTriangle> _0023_003DzbBjzTVaK0Qb44OWa3A_003D_003D, IndexTriangle _0023_003DznnnQx3RwjThsBRPB9w_003D_003D)
	{
		int _0023_003DzsK_Xndk_003D = 0;
		int _0023_003Dz0ADyCos_003D = 0;
		int _0023_003DzoCDsmWk_003D = 0;
		int _0023_003Dz0wAkCmM_003D = 0;
		int _0023_003Dz_0024eRdUwQ_003D = 0;
		int _0023_003Dz5cbO6Ls_003D = 0;
		switch (_0023_003DzGGJSiQk_003D._meshNature)
		{
		case natureType.RichPlain:
		{
			RichTriangle obj2 = (RichTriangle)_0023_003DznnnQx3RwjThsBRPB9w_003D_003D;
			_0023_003DzsK_Xndk_003D = obj2.T1;
			_0023_003Dz0ADyCos_003D = obj2.T2;
			_0023_003DzoCDsmWk_003D = obj2.T3;
			break;
		}
		case natureType.RichSmooth:
		{
			RichSmoothTriangle obj = (RichSmoothTriangle)_0023_003DznnnQx3RwjThsBRPB9w_003D_003D;
			_0023_003DzsK_Xndk_003D = obj.T1;
			_0023_003Dz0ADyCos_003D = obj.T2;
			_0023_003DzoCDsmWk_003D = obj.T3;
			_0023_003Dz0wAkCmM_003D = obj.N1;
			_0023_003Dz_0024eRdUwQ_003D = obj.N2;
			_0023_003Dz5cbO6Ls_003D = obj.N3;
			break;
		}
		}
		_0023_003Dz_LICwio_003D(_0023_003DzGGJSiQk_003D, _0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, _0023_003DzZe6oCrQ_003D, _0023_003DzbBjzTVaK0Qb44OWa3A_003D_003D, _0023_003DzsK_Xndk_003D, _0023_003Dz0ADyCos_003D, _0023_003DzoCDsmWk_003D, _0023_003Dz0wAkCmM_003D, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz5cbO6Ls_003D);
	}

	private static void _0023_003Dz_LICwio_003D(Mesh _0023_003DzGGJSiQk_003D, int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D, int _0023_003DzZe6oCrQ_003D, List<IndexTriangle> _0023_003DzbBjzTVaK0Qb44OWa3A_003D_003D)
	{
		_0023_003Dz_LICwio_003D(_0023_003DzGGJSiQk_003D, _0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, _0023_003DzZe6oCrQ_003D, _0023_003DzbBjzTVaK0Qb44OWa3A_003D_003D, 0, 0, 0, 0, 0, 0);
	}

	private static void _0023_003Dz_LICwio_003D(Mesh _0023_003DzGGJSiQk_003D, int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D, int _0023_003DzZe6oCrQ_003D, List<IndexTriangle> _0023_003DzbBjzTVaK0Qb44OWa3A_003D_003D, int _0023_003DzsK_Xndk_003D, int _0023_003Dz0ADyCos_003D, int _0023_003DzoCDsmWk_003D, int _0023_003Dz0wAkCmM_003D, int _0023_003Dz_0024eRdUwQ_003D, int _0023_003Dz5cbO6Ls_003D)
	{
		switch (_0023_003DzGGJSiQk_003D._meshNature)
		{
		case natureType.Plain:
			_0023_003DzbBjzTVaK0Qb44OWa3A_003D_003D.Add(new IndexTriangle(_0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, _0023_003DzZe6oCrQ_003D));
			break;
		case natureType.ColorPlain:
		case natureType.MulticolorPlain:
			_0023_003DzbBjzTVaK0Qb44OWa3A_003D_003D.Add(new ColorTriangle(_0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, _0023_003DzZe6oCrQ_003D, _0023_003DzGGJSiQk_003D.Color));
			break;
		case natureType.RichPlain:
			_0023_003DzbBjzTVaK0Qb44OWa3A_003D_003D.Add(new RichTriangle(_0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, _0023_003DzZe6oCrQ_003D, _0023_003DzsK_Xndk_003D, _0023_003Dz0ADyCos_003D, _0023_003DzoCDsmWk_003D));
			break;
		case natureType.Smooth:
			_0023_003DzbBjzTVaK0Qb44OWa3A_003D_003D.Add(new SmoothTriangle(_0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, _0023_003DzZe6oCrQ_003D));
			break;
		case natureType.ColorSmooth:
		case natureType.MulticolorSmooth:
			_0023_003DzbBjzTVaK0Qb44OWa3A_003D_003D.Add(new ColorSmoothTriangle(_0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, _0023_003DzZe6oCrQ_003D, _0023_003DzGGJSiQk_003D.Color));
			break;
		case natureType.RichSmooth:
			_0023_003DzbBjzTVaK0Qb44OWa3A_003D_003D.Add(new RichSmoothTriangle(_0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, _0023_003DzZe6oCrQ_003D, _0023_003Dz0wAkCmM_003D, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz5cbO6Ls_003D, _0023_003DzsK_Xndk_003D, _0023_003Dz0ADyCos_003D, _0023_003DzoCDsmWk_003D));
			break;
		default:
			_0023_003DzbBjzTVaK0Qb44OWa3A_003D_003D.Add(new IndexTriangle(_0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, _0023_003DzZe6oCrQ_003D));
			break;
		}
	}

	internal void _0023_003Dz_0024YeSaS1uGUxB()
	{
		sharedEdges = Utility.GetEdgesWithoutDuplicates(_triangles, _vertices.Length);
	}

	private void _0023_003DzZTr16fkQpUZHJpROCQ_003D_003D()
	{
		if (_vertices == null || _vertices.Length == 0 || _vertices[0] == null || _triangles == null || _triangles.Length == 0 || _triangles[0] == null)
		{
			return;
		}
		if (_triangles[0] is _0023_003DzdbCY_Ol_2RiGerZYwGcKL3V5U09dFmFFez1WZYE_003D)
		{
			base.entityNature = entityNatureType.Polygon;
			_meshNature = natureType.Plain;
			return;
		}
		bool flag = _vertices[0] is PointRGB;
		if (!flag && _triangles[0].GetType() == typeof(IndexTriangle))
		{
			base.entityNature = entityNatureType.Polygon;
			_meshNature = natureType.Plain;
		}
		else if (!flag && _triangles[0].GetType() == typeof(ColorTriangle))
		{
			base.entityNature = entityNatureType.RichPolygon;
			_meshNature = natureType.ColorPlain;
		}
		else if (flag && _triangles[0].GetType() == typeof(IndexTriangle))
		{
			base.entityNature = entityNatureType.RichPolygon;
			_meshNature = natureType.MulticolorPlain;
		}
		else if (!flag && _triangles[0].GetType() == typeof(RichTriangle))
		{
			base.entityNature = entityNatureType.RichPolygon;
			_meshNature = natureType.RichPlain;
		}
		else if (!flag && _triangles[0].GetType() == typeof(SmoothTriangle))
		{
			base.entityNature = entityNatureType.Polygon;
			_meshNature = natureType.Smooth;
		}
		else if (!flag && _triangles[0].GetType() == typeof(ColorSmoothTriangle))
		{
			base.entityNature = entityNatureType.RichPolygon;
			_meshNature = natureType.ColorSmooth;
		}
		else if (flag && _triangles[0].GetType() == typeof(SmoothTriangle))
		{
			base.entityNature = entityNatureType.RichPolygon;
			_meshNature = natureType.MulticolorSmooth;
		}
		else if (!flag && _triangles[0].GetType() == typeof(RichSmoothTriangle))
		{
			base.entityNature = entityNatureType.RichPolygon;
			_meshNature = natureType.RichSmooth;
		}
	}

	public virtual void UpdateNormals()
	{
		natureType meshNature = _meshNature;
		if (meshNature - 1 <= natureType.MulticolorPlain)
		{
			_normals = _0023_003Dz9PT4tNs9owGLO14COg_003D_003D(_vertices, _triangles);
		}
		else
		{
			switch (_normalAveraging)
			{
			case normalAveragingType.Averaged:
				_normals = _0023_003DzdPA2_0024gCtew0gz3Njvg_003D_003D(_vertices, _triangles, _0023_003DzJacdlY88rdqoqPbG2g_003D_003D: true);
				break;
			case normalAveragingType.AveragedByAngle:
				_0023_003DzGy94Ib5z2V_00240CgfEINFeq_A_003D();
				break;
			}
		}
		if (RegenMode == regenType.NotNeeded)
		{
			RegenMode = regenType.CompileOnly;
		}
	}

	internal void _0023_003DzGy94Ib5z2V_00240CgfEINFeq_A_003D()
	{
		Vector3D[] array = _0023_003Dz9PT4tNs9owGLO14COg_003D_003D(_vertices, _triangles);
		double num = Math.Cos(_smoothingAngle);
		List<_0023_003DzuAiGvws_003D>[] array2 = new List<_0023_003DzuAiGvws_003D>[_vertices.Length];
		for (int i = 0; i < _vertices.Length; i++)
		{
			array2[i] = new List<_0023_003DzuAiGvws_003D>();
		}
		for (int j = 0; j < _triangles.Length; j++)
		{
			IndexTriangle indexTriangle = _triangles[j];
			array2[indexTriangle.V1].Add(new _0023_003DzuAiGvws_003D(j));
			array2[indexTriangle.V2].Add(new _0023_003DzuAiGvws_003D(j));
			array2[indexTriangle.V3].Add(new _0023_003DzuAiGvws_003D(j));
		}
		List<Vector3D> list = new List<Vector3D>(_triangles.Length * 3);
		for (int k = 0; k < array2.Length; k++)
		{
			int count = array2[k].Count;
			for (int l = 0; l < count; l++)
			{
				_0023_003DzuAiGvws_003D _0023_003DzuAiGvws_003D2 = array2[k][l];
				if (_0023_003DzuAiGvws_003D2._0023_003DzIuk3IWJaawETf43w_0024g_003D_003D == 2)
				{
					continue;
				}
				Vector3D vector3D = array[_0023_003DzuAiGvws_003D2._0023_003DzyzK8swU_003D];
				Vector3D vector3D2 = vector3D;
				bool flag = false;
				for (int m = l + 1; m < count; m++)
				{
					_0023_003DzuAiGvws_003D _0023_003DzuAiGvws_003D3 = array2[k][m];
					if (_0023_003DzuAiGvws_003D3._0023_003DzIuk3IWJaawETf43w_0024g_003D_003D != 2)
					{
						Vector3D vector3D3 = array[_0023_003DzuAiGvws_003D3._0023_003DzyzK8swU_003D];
						if (vector3D.X * vector3D3.X + vector3D.Y * vector3D3.Y + vector3D.Z * vector3D3.Z > num)
						{
							vector3D2 += vector3D3;
							array2[k][l] = new _0023_003DzuAiGvws_003D(_0023_003DzuAiGvws_003D2._0023_003DzyzK8swU_003D, 1);
							array2[k][m] = new _0023_003DzuAiGvws_003D(_0023_003DzuAiGvws_003D3._0023_003DzyzK8swU_003D, 1);
							flag = true;
						}
					}
				}
				if (flag)
				{
					vector3D2.Normalize();
					int num2 = -1;
					for (int n = l; n < count; n++)
					{
						_0023_003DzuAiGvws_003D _0023_003DzuAiGvws_003D4 = array2[k][n];
						if (_0023_003DzuAiGvws_003D4._0023_003DzIuk3IWJaawETf43w_0024g_003D_003D != 1)
						{
							continue;
						}
						if (num2 == -1)
						{
							list.Add(vector3D2);
							num2 = list.Count - 1;
						}
						natureType meshNature = _meshNature;
						if (meshNature - 5 <= natureType.MulticolorPlain)
						{
							if (_triangles[_0023_003DzuAiGvws_003D4._0023_003DzyzK8swU_003D].V1 == k)
							{
								((SmoothTriangle)_triangles[_0023_003DzuAiGvws_003D4._0023_003DzyzK8swU_003D]).N1 = num2;
							}
							else if (_triangles[_0023_003DzuAiGvws_003D4._0023_003DzyzK8swU_003D].V2 == k)
							{
								((SmoothTriangle)_triangles[_0023_003DzuAiGvws_003D4._0023_003DzyzK8swU_003D]).N2 = num2;
							}
							else
							{
								((SmoothTriangle)_triangles[_0023_003DzuAiGvws_003D4._0023_003DzyzK8swU_003D]).N3 = num2;
							}
						}
						array2[k][n] = new _0023_003DzuAiGvws_003D(_0023_003DzuAiGvws_003D4._0023_003DzyzK8swU_003D, 2);
					}
				}
				else
				{
					_0023_003DzuAiGvws_003D _0023_003DzuAiGvws_003D5 = array2[k][l];
					list.Add(array[_0023_003DzuAiGvws_003D5._0023_003DzyzK8swU_003D]);
					int num3 = list.Count - 1;
					if (_triangles[_0023_003DzuAiGvws_003D5._0023_003DzyzK8swU_003D].V1 == k)
					{
						((SmoothTriangle)_triangles[_0023_003DzuAiGvws_003D5._0023_003DzyzK8swU_003D]).N1 = num3;
					}
					else if (_triangles[_0023_003DzuAiGvws_003D5._0023_003DzyzK8swU_003D].V2 == k)
					{
						((SmoothTriangle)_triangles[_0023_003DzuAiGvws_003D5._0023_003DzyzK8swU_003D]).N2 = num3;
					}
					else
					{
						((SmoothTriangle)_triangles[_0023_003DzuAiGvws_003D5._0023_003DzyzK8swU_003D]).N3 = num3;
					}
					array2[k][l] = new _0023_003DzuAiGvws_003D(_0023_003DzuAiGvws_003D5._0023_003DzyzK8swU_003D, 2);
				}
			}
		}
		_normals = list.ToArray();
	}

	private static Vector3D[] _0023_003DzdPA2_0024gCtew0gz3Njvg_003D_003D(Point3D[] _0023_003DzME2BuaSnJsM4mEn84A_003D_003D, IndexTriangle[] _0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D, bool _0023_003DzJacdlY88rdqoqPbG2g_003D_003D)
	{
		Vector3D[] array = _0023_003Dz9PT4tNs9owGLO14COg_003D_003D(_0023_003DzME2BuaSnJsM4mEn84A_003D_003D, _0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D);
		List<_0023_003DzuAiGvws_003D>[] array2 = new List<_0023_003DzuAiGvws_003D>[_0023_003DzME2BuaSnJsM4mEn84A_003D_003D.Length];
		for (int i = 0; i < _0023_003DzME2BuaSnJsM4mEn84A_003D_003D.Length; i++)
		{
			array2[i] = new List<_0023_003DzuAiGvws_003D>();
		}
		for (int j = 0; j < _0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D.Length; j++)
		{
			IndexTriangle indexTriangle = _0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D[j];
			array2[indexTriangle.V1].Add(new _0023_003DzuAiGvws_003D(j));
			array2[indexTriangle.V2].Add(new _0023_003DzuAiGvws_003D(j));
			array2[indexTriangle.V3].Add(new _0023_003DzuAiGvws_003D(j));
		}
		List<Vector3D> list = new List<Vector3D>(_0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D.Length * 3);
		for (int k = 0; k < array2.Length; k++)
		{
			int count = array2[k].Count;
			Vector3D vector3D = new Vector3D();
			for (int l = 0; l < count; l++)
			{
				Vector3D vector3D2 = array[array2[k][l]._0023_003DzyzK8swU_003D];
				vector3D += vector3D2;
			}
			vector3D.Normalize();
			int num = -1;
			for (int m = 0; m < count; m++)
			{
				_0023_003DzuAiGvws_003D _0023_003DzuAiGvws_003D2 = array2[k][m];
				if (num == -1)
				{
					list.Add(vector3D);
					num = list.Count - 1;
				}
				if (_0023_003DzJacdlY88rdqoqPbG2g_003D_003D)
				{
					if (_0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D[_0023_003DzuAiGvws_003D2._0023_003DzyzK8swU_003D].V1 == k)
					{
						((SmoothTriangle)_0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D[_0023_003DzuAiGvws_003D2._0023_003DzyzK8swU_003D]).N1 = num;
					}
					else if (_0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D[_0023_003DzuAiGvws_003D2._0023_003DzyzK8swU_003D].V2 == k)
					{
						((SmoothTriangle)_0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D[_0023_003DzuAiGvws_003D2._0023_003DzyzK8swU_003D]).N2 = num;
					}
					else
					{
						((SmoothTriangle)_0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D[_0023_003DzuAiGvws_003D2._0023_003DzyzK8swU_003D]).N3 = num;
					}
				}
			}
		}
		return list.ToArray();
	}

	internal static Vector3D[] _0023_003Dz9PT4tNs9owGLO14COg_003D_003D(Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, IndexTriangle[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D)
	{
		int num = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Length;
		Vector3D[] array = new Vector3D[num];
		for (int i = 0; i < num; i++)
		{
			IndexTriangle indexTriangle = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[i];
			Point3D point3D = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle.V1];
			Point3D point3D2 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle.V2];
			Point3D point3D3 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle.V3];
			_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D2 = new _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D(point3D.X - point3D3.X, point3D.Y - point3D3.Y, point3D.Z - point3D3.Z);
			_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D3 = new _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D(point3D2.X - point3D.X, point3D2.Y - point3D.Y, point3D2.Z - point3D.Z);
			array[i] = new Vector3D(_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D2._0023_003DzvXOLtKg_003D * _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D3._0023_003Dz8wjMonY_003D - _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D2._0023_003Dz8wjMonY_003D * _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D3._0023_003DzvXOLtKg_003D, _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D2._0023_003Dz8wjMonY_003D * _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D3._0023_003Dzyk2fsPo_003D - _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D2._0023_003Dzyk2fsPo_003D * _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D3._0023_003Dz8wjMonY_003D, _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D2._0023_003Dzyk2fsPo_003D * _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D3._0023_003DzvXOLtKg_003D - _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D2._0023_003DzvXOLtKg_003D * _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D3._0023_003Dzyk2fsPo_003D);
			if (!array[i].Normalize())
			{
				array[i] = Vector3D.AxisX;
			}
		}
		return array;
	}

	public virtual void ComputeEdges()
	{
		_0023_003Dz_T6MNYD65ZA4();
		if (RegenMode == regenType.NotNeeded)
		{
			RegenMode = regenType.CompileOnly;
		}
	}

	private void _0023_003Dz_T6MNYD65ZA4()
	{
		if (!LightWeight)
		{
			switch (_edgeStyle)
			{
			case edgeStyleType.Free:
				_edges = _0023_003Dz2XmFBkdx7sUs(_triangles, _0023_003DzOwwECpkmwVeA: false);
				break;
			case edgeStyleType.Sharp:
				_edges = _0023_003DzLfUvlgjC8bTq(_smoothingAngle, _triangles, _vertices);
				break;
			case edgeStyleType.None:
				break;
			}
		}
	}

	private IndexLine[] _0023_003Dz2XmFBkdx7sUs(IList<IndexTriangle> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, bool _0023_003DzOwwECpkmwVeA)
	{
		if (sharedEdges == null)
		{
			_0023_003Dz_0024YeSaS1uGUxB();
		}
		return _0023_003DzmchTa9BnDhdzblfJaw_003D_003D(_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003DzOwwECpkmwVeA);
	}

	public bool FlipOutward()
	{
		if (GetVolume(out var _) < 0.0)
		{
			FlipNormal();
			return true;
		}
		return false;
	}

	private IndexLine[] _0023_003DzmchTa9BnDhdzblfJaw_003D_003D(IList<IndexTriangle> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, bool _0023_003DzOwwECpkmwVeA)
	{
		List<IndexLine> list = new List<IndexLine>();
		if (_0023_003DzOwwECpkmwVeA)
		{
			for (int i = 0; i < sharedEdges.GetLength(0); i++)
			{
				if (sharedEdges[i, 3] == -1)
				{
					if (_0023_003DzLk5zDeuuLkza(_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[sharedEdges[i, 2]], sharedEdges[i, 0], sharedEdges[i, 1]))
					{
						list.Add(new IndexLine(sharedEdges[i, 1], sharedEdges[i, 0]));
					}
					else
					{
						list.Add(new IndexLine(sharedEdges[i, 0], sharedEdges[i, 1]));
					}
				}
			}
		}
		else
		{
			for (int j = 0; j < sharedEdges.GetLength(0); j++)
			{
				if (sharedEdges[j, 3] == -1)
				{
					list.Add(new IndexLine(sharedEdges[j, 0], sharedEdges[j, 1]));
				}
			}
		}
		return list.ToArray();
	}

	private static bool _0023_003DzLk5zDeuuLkza(IndexTriangle _0023_003DznnnQx3RwjThsBRPB9w_003D_003D, int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D)
	{
		if (_0023_003DzffqPLNQ_003D == _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1 && _0023_003Dz5Azd7L8_003D == _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2)
		{
			return false;
		}
		if (_0023_003DzffqPLNQ_003D == _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2 && _0023_003Dz5Azd7L8_003D == _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V3)
		{
			return false;
		}
		if (_0023_003DzffqPLNQ_003D == _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V3 && _0023_003Dz5Azd7L8_003D == _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1)
		{
			return false;
		}
		return true;
	}

	internal IndexLine[] _0023_003DzLfUvlgjC8bTq(double _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D, IndexTriangle[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		if (sharedEdges == null)
		{
			_0023_003Dz_0024YeSaS1uGUxB();
		}
		return _0023_003DzxAC1dcQ_0024PepvFoRx2Q_003D_003D(_0023_003DznDeo9kRSCPBn8AZYIA_003D_003D, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
	}

	private IndexLine[] _0023_003DzxAC1dcQ_0024PepvFoRx2Q_003D_003D(double _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D, IndexTriangle[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		List<IndexLine> list = new List<IndexLine>(sharedEdges.GetLength(0));
		double num = Math.Cos(_0023_003DznDeo9kRSCPBn8AZYIA_003D_003D);
		Vector3D[] array = _0023_003Dz9PT4tNs9owGLO14COg_003D_003D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D);
		for (int i = 0; i < sharedEdges.GetLength(0); i++)
		{
			if (sharedEdges[i, 3] == -1)
			{
				list.Add(new IndexLine(sharedEdges[i, 0], sharedEdges[i, 1]));
			}
			else if (array[sharedEdges[i, 2]] * array[sharedEdges[i, 3]] <= num)
			{
				list.Add(new IndexLine(sharedEdges[i, 0], sharedEdges[i, 1]));
			}
		}
		return list.ToArray();
	}

	public void FlipNormal()
	{
		Utility.FlipTriangles(_triangles);
		if (_normals != null)
		{
			Vector3D[] normals = _normals;
			for (int i = 0; i < normals.Length; i++)
			{
				normals[i].Negate();
			}
			natureType meshNature = _meshNature;
			if (meshNature - 1 <= natureType.ColorPlain || meshNature - 5 <= natureType.ColorPlain)
			{
				RegenMode = regenType.CompileOnly;
			}
		}
	}

	internal void _0023_003DzDzdRty4_003D(List<Point3D> _0023_003DzerPXTI59l6IWZMLwxA_003D_003D, List<PointF> _0023_003DzravPUDRmVn5tIfK9SQ_003D_003D, List<Vector3D> _0023_003DzZnLG644xWwWmx_0024IZLQ_003D_003D, int _0023_003DzrVpMf93_0024_fEWm3gSAA_003D_003D, int _0023_003Dzyu5XCb7H5jr5YkyOBg_003D_003D, int _0023_003DzU4Qt89VTjUXgy6Do3A_003D_003D)
	{
		int _0023_003DzdSYVn8_XEfvE = 0;
		int[] _0023_003DzazXmgkHphnb_ = _0023_003Dz5UK7dGszUMrc(_0023_003DzerPXTI59l6IWZMLwxA_003D_003D.Count);
		_vertices = new Point3D[_0023_003DzrVpMf93_0024_fEWm3gSAA_003D_003D];
		for (int i = 0; i < _triangles.Length; i++)
		{
			IndexTriangle indexTriangle = _triangles[i];
			indexTriangle.V1 = _0023_003DzpsISx4s_003D(indexTriangle.V1, _0023_003DzerPXTI59l6IWZMLwxA_003D_003D, _vertices, _0023_003DzazXmgkHphnb_, ref _0023_003DzdSYVn8_XEfvE);
			indexTriangle.V2 = _0023_003DzpsISx4s_003D(indexTriangle.V2, _0023_003DzerPXTI59l6IWZMLwxA_003D_003D, _vertices, _0023_003DzazXmgkHphnb_, ref _0023_003DzdSYVn8_XEfvE);
			indexTriangle.V3 = _0023_003DzpsISx4s_003D(indexTriangle.V3, _0023_003DzerPXTI59l6IWZMLwxA_003D_003D, _vertices, _0023_003DzazXmgkHphnb_, ref _0023_003DzdSYVn8_XEfvE);
		}
		if (_0023_003DzZnLG644xWwWmx_0024IZLQ_003D_003D != null)
		{
			_0023_003DzazXmgkHphnb_ = _0023_003Dz5UK7dGszUMrc(_0023_003DzZnLG644xWwWmx_0024IZLQ_003D_003D.Count);
			_0023_003DzdSYVn8_XEfvE = 0;
			_normals = new Vector3D[_0023_003Dzyu5XCb7H5jr5YkyOBg_003D_003D];
			for (int j = 0; j < _triangles.Length; j++)
			{
				SmoothTriangle smoothTriangle = (SmoothTriangle)_triangles[j];
				if (smoothTriangle.N1 > -1)
				{
					smoothTriangle.N1 = _0023_003DzpsISx4s_003D(smoothTriangle.N1, _0023_003DzZnLG644xWwWmx_0024IZLQ_003D_003D, _normals, _0023_003DzazXmgkHphnb_, ref _0023_003DzdSYVn8_XEfvE);
					smoothTriangle.N2 = _0023_003DzpsISx4s_003D(smoothTriangle.N2, _0023_003DzZnLG644xWwWmx_0024IZLQ_003D_003D, _normals, _0023_003DzazXmgkHphnb_, ref _0023_003DzdSYVn8_XEfvE);
					smoothTriangle.N3 = _0023_003DzpsISx4s_003D(smoothTriangle.N3, _0023_003DzZnLG644xWwWmx_0024IZLQ_003D_003D, _normals, _0023_003DzazXmgkHphnb_, ref _0023_003DzdSYVn8_XEfvE);
				}
			}
		}
		if (_0023_003DzravPUDRmVn5tIfK9SQ_003D_003D == null || _0023_003DzravPUDRmVn5tIfK9SQ_003D_003D.Count <= 0 || (_meshNature != natureType.RichPlain && _meshNature != natureType.RichSmooth))
		{
			return;
		}
		_0023_003DzazXmgkHphnb_ = _0023_003Dz5UK7dGszUMrc(_0023_003DzravPUDRmVn5tIfK9SQ_003D_003D.Count);
		_0023_003DzdSYVn8_XEfvE = 0;
		_texCoords = new PointF[_0023_003DzU4Qt89VTjUXgy6Do3A_003D_003D];
		for (int k = 0; k < _triangles.Length; k++)
		{
			RichSmoothTriangle richSmoothTriangle = (RichSmoothTriangle)_triangles[k];
			if (richSmoothTriangle.T1 > -1)
			{
				richSmoothTriangle.T1 = _0023_003DzpsISx4s_003D(richSmoothTriangle.T1, _0023_003DzravPUDRmVn5tIfK9SQ_003D_003D, _texCoords, _0023_003DzazXmgkHphnb_, ref _0023_003DzdSYVn8_XEfvE);
				richSmoothTriangle.T2 = _0023_003DzpsISx4s_003D(richSmoothTriangle.T2, _0023_003DzravPUDRmVn5tIfK9SQ_003D_003D, _texCoords, _0023_003DzazXmgkHphnb_, ref _0023_003DzdSYVn8_XEfvE);
				richSmoothTriangle.T3 = _0023_003DzpsISx4s_003D(richSmoothTriangle.T3, _0023_003DzravPUDRmVn5tIfK9SQ_003D_003D, _texCoords, _0023_003DzazXmgkHphnb_, ref _0023_003DzdSYVn8_XEfvE);
			}
		}
	}

	private int[] _0023_003Dz5UK7dGszUMrc(int _0023_003Dzfsn580w_003D)
	{
		int[] array = new int[_0023_003Dzfsn580w_003D];
		for (int i = 0; i < _0023_003Dzfsn580w_003D; i++)
		{
			array[i] = -1;
		}
		return array;
	}

	private int _0023_003DzpsISx4s_003D<T>(int _0023_003DzAJYZcKw_003D, List<T> _0023_003DzHPJ7oIhgGzIA, T[] _0023_003Dzzwxsafw_003D, int[] _0023_003DzazXmgkHphnb_, ref int _0023_003DzdSYVn8_XEfvE) where T : ICloneable
	{
		int num = _0023_003DzazXmgkHphnb_[_0023_003DzAJYZcKw_003D];
		if (num == -1)
		{
			_0023_003Dzzwxsafw_003D[_0023_003DzdSYVn8_XEfvE] = (T)_0023_003DzHPJ7oIhgGzIA[_0023_003DzAJYZcKw_003D].Clone();
			num = (_0023_003DzazXmgkHphnb_[_0023_003DzAJYZcKw_003D] = _0023_003DzdSYVn8_XEfvE++);
		}
		return num;
	}

	private int _0023_003DzpsISx4s_003D(int _0023_003DzAJYZcKw_003D, List<PointF> _0023_003DzHPJ7oIhgGzIA, PointF[] _0023_003Dzzwxsafw_003D, int[] _0023_003DzazXmgkHphnb_, ref int _0023_003DzdSYVn8_XEfvE)
	{
		int num = _0023_003DzazXmgkHphnb_[_0023_003DzAJYZcKw_003D];
		if (num == -1)
		{
			_0023_003Dzzwxsafw_003D[_0023_003DzdSYVn8_XEfvE] = _0023_003DzHPJ7oIhgGzIA[_0023_003DzAJYZcKw_003D];
			num = (_0023_003DzazXmgkHphnb_[_0023_003DzAJYZcKw_003D] = _0023_003DzdSYVn8_XEfvE++);
		}
		return num;
	}

	public override void TransformBy(Transformation xform)
	{
		base.TransformBy(xform);
		if (xform.HasReflection)
		{
			Utility.FlipTriangles(_triangles);
		}
		if (_normals != null)
		{
			Utility.TransformNormals(xform, _normals);
		}
	}

	public Solid ConvertToSolid()
	{
		return Solid._0023_003DzPOf5fTBvzWMKZihEmQ_003D_003D<Solid>(this);
	}

	public T ConvertToSolid<T>() where T : Solid, new()
	{
		return Solid._0023_003DzPOf5fTBvzWMKZihEmQ_003D_003D<T>(this);
	}

	public void Weld()
	{
		_0023_003DzNfeoW_0024weFDsc(_0023_003DzoZ7QkU98lHkf: false, _0023_003Dzqi3YK5d7X0dWNH6L9RMwK5g_003D: true, _0023_003DzFwalihjMriJGyFaGGg_003D_003D: false);
	}

	public void Weld(double maxGap, bool updateEdges = false)
	{
		_0023_003DzNfeoW_0024weFDsc(maxGap, updateEdges, _0023_003Dzqi3YK5d7X0dWNH6L9RMwK5g_003D: true, _0023_003DzFwalihjMriJGyFaGGg_003D_003D: false);
	}

	[Obsolete("Does not actually skip any vertices anymore. Please use Weld instead.")]
	public void WeldFreeEdges(double maxGap)
	{
		Weld(maxGap);
	}

	[Obsolete("Does not actually skip any vertices anymore. Please use Weld instead.")]
	public void WeldFreeEdges()
	{
		Weld();
	}

	private double _0023_003DzBJ0E5iNDvn3USHgx5A_003D_003D()
	{
		if (!(localMin != null))
		{
			return Utility._0023_003DzKN_0024vjGN5_0024fwYJSS8TN63qBo_003D(_vertices);
		}
		return Utility._0023_003DzKN_0024vjGN5_0024fwYJSS8TN63qBo_003D(base.BoxSize.Diagonal);
	}

	internal void _0023_003DzNfeoW_0024weFDsc(bool _0023_003DzoZ7QkU98lHkf, bool _0023_003Dzqi3YK5d7X0dWNH6L9RMwK5g_003D, bool _0023_003DzFwalihjMriJGyFaGGg_003D_003D)
	{
		_0023_003DzNfeoW_0024weFDsc(_0023_003DzBJ0E5iNDvn3USHgx5A_003D_003D(), _0023_003DzoZ7QkU98lHkf, _0023_003Dzqi3YK5d7X0dWNH6L9RMwK5g_003D, _0023_003DzFwalihjMriJGyFaGGg_003D_003D);
	}

	internal void _0023_003DzNfeoW_0024weFDsc(double _0023_003DzX0qX_IwWxysi, bool _0023_003DzoZ7QkU98lHkf, bool _0023_003Dzqi3YK5d7X0dWNH6L9RMwK5g_003D, bool _0023_003DzFwalihjMriJGyFaGGg_003D_003D)
	{
		Utility._0023_003DzJNADeOQRO6_fPmN4Ig_003D_003D(_triangles, _0023_003DzoZ7QkU98lHkf ? _edges : null, _vertices, out var _0023_003DzPSHPV1adgQcYEwqKXHGDJDXML8EU, out var _0023_003DzrnJjSihyGwPQqq_0024JUA_003D_003D, _0023_003DzX0qX_IwWxysi, _0023_003Dzqi3YK5d7X0dWNH6L9RMwK5g_003D, _0023_003DzFwalihjMriJGyFaGGg_003D_003D);
		_vertices = _0023_003DzrnJjSihyGwPQqq_0024JUA_003D_003D;
		_triangles = _0023_003DzPSHPV1adgQcYEwqKXHGDJDXML8EU;
		if (!_0023_003DzoZ7QkU98lHkf)
		{
			_edges = null;
		}
		RegenMode = regenType.RegenAndCompile;
	}

	public void WeldQuadratic(double maxGap)
	{
		_0023_003DzNfeoW_0024weFDsc(maxGap, _0023_003DzoZ7QkU98lHkf: false, _0023_003Dzqi3YK5d7X0dWNH6L9RMwK5g_003D: true, _0023_003DzFwalihjMriJGyFaGGg_003D_003D: true);
	}

	[Obsolete("Does not actually skip any vertices anymore. Please use WeldQuadratic instead.")]
	public void WeldFreeEdgesQuadratic(double maxGap)
	{
		WeldQuadratic(maxGap);
	}

	public IList<HitTriangle> FindClosestTriangle(Transformation transf, Segment3D seg)
	{
		if (_subdivisionTree == null)
		{
			return Utility.FindClosestTriangle(transf, seg, _vertices, _triangles).Values;
		}
		SortedList<double, HitTriangle> sortedList = new SortedList<double, HitTriangle>();
		((Octree)_subdivisionTree).FindClosestTriangle(seg, transf, sortedList);
		return sortedList.Values;
	}

	public void FromTriangles(Point3D[] v)
	{
		int num = v.Length;
		int[] array = new int[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = -1;
		}
		int num2 = 0;
		for (int j = 0; j < num; j++)
		{
			if (array[j] != -1)
			{
				continue;
			}
			array[j] = num2;
			for (int k = j; k < num; k++)
			{
				if (array[k] == -1 && v[j].X == v[k].X && v[j].Y == v[k].Y && v[j].Z == v[k].Z)
				{
					array[k] = num2;
				}
			}
			num2++;
		}
		int num3 = v.Length / 3;
		IndexTriangle[] triangles = new SmoothTriangle[num3];
		_triangles = triangles;
		for (int l = 0; l < num3; l++)
		{
			_triangles[l] = new SmoothTriangle(array[l * 3], array[l * 3 + 1], array[l * 3 + 2], 0, 0, 0);
		}
		_vertices = new Point3D[num2];
		for (int m = 0; m < v.Length; m++)
		{
			_vertices[array[m]] = v[m];
		}
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new MeshSurrogate(this);
	}

	[SpecialName]
	internal override bool _0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D()
	{
		if (Normals != null && Normals.Length != 0)
		{
			if (EdgeStyle != edgeStyleType.None)
			{
				if (Edges != null)
				{
					return Edges.Length != 0;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
	{
		base.GetObjectData(info, ctxt);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972330), localMin);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972314), localMax);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972298), _meshNature);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958678), _vertices);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968413), _triangles);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972028), _normalAveraging);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971992), _smoothingAngle);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968397), _normals);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971982), _edgeStyle);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954162), _edges);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971965), _texCoords);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971927), _lightWeight);
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode != regenType.RegenAndCompile)
		{
			return new Point3D[2] { base.BoxMin, base.BoxMax };
		}
		return Utility.GetSampling(_vertices);
	}

	public override bool IsValid(StringBuilder log = null)
	{
		if (_meshNature == natureType.Undefined)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972045));
			return false;
		}
		if (_vertices == null)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302960550));
			return false;
		}
		for (int i = 0; i < _vertices.Length; i++)
		{
			if (_vertices[i] == null)
			{
				log?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302960252), i));
				return false;
			}
		}
		if (_triangles == null)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972780));
			return false;
		}
		for (int j = 0; j < _triangles.Length; j++)
		{
			if (_triangles[j] == null)
			{
				log?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972746), j));
				return false;
			}
		}
		return base.IsValid(log);
	}

	public double GetArea(out Point3D centroid)
	{
		AreaProperties areaProperties = new AreaProperties();
		areaProperties.Add(this);
		centroid = areaProperties.Centroid;
		return areaProperties.Area;
	}

	public double GetVolume(out Point3D centroid)
	{
		VolumeProperties volumeProperties = new VolumeProperties();
		volumeProperties.Add(this);
		centroid = volumeProperties.Centroid;
		return volumeProperties.Volume;
	}

	public void GetPrincipalAxes(out Vector3D axisX, out Vector3D axisY, out Vector3D axisZ, out double ix, out double iy, out double iz)
	{
		VolumeProperties volumeProperties = new VolumeProperties();
		volumeProperties.Add(this);
		volumeProperties.GetPrincipalAxes(volumeProperties.Volume, volumeProperties.Centroid, out axisX, out axisY, out axisZ, out ix, out iy, out iz);
	}

	public void GetPrincipalAxes(out Vector3D axisX, out Vector3D axisY, out Vector3D axisZ)
	{
		GetPrincipalAxes(out axisX, out axisY, out axisZ, out var _, out var _, out var _);
	}

	public List<int> GetFaceTriangles(int triangleIndex, double adjacentNormalAngle)
	{
		return _0023_003DzzXyiT8Nl_0024eFpu_0024Eo_0024fvIYPg_003D(triangleIndex, adjacentNormalAngle);
	}

	internal List<int> _0023_003DzzXyiT8Nl_0024eFpu_0024Eo_0024fvIYPg_003D(int _0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D, double _0023_003DzZ47C7T2rLqq4)
	{
		bool[] _0023_003DznkPLPRg_003D = new bool[Triangles.Length];
		List<int> list = new List<int>();
		Utility.GetEdgesWithoutDuplicates(Triangles, Vertices.Length, out var edgesPerVertex);
		_0023_003DzA4JTglXasoEpavp9zCCQtNc_003D(_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D, _0023_003DznkPLPRg_003D, edgesPerVertex, _0023_003DzZ47C7T2rLqq4, list);
		return list;
	}

	private void _0023_003DzA4JTglXasoEpavp9zCCQtNc_003D(int _0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D, bool[] _0023_003DznkPLPRg_003D, LinkedList<SharedEdge>[] _0023_003DzPysnrsiTT_0024jt, double _0023_003Dzm0CYiiE_003D, List<int> _0023_003DzqzOxI2eLSxxwou3qOPDNv9oWI_27)
	{
		LinkedList<int> linkedList = new LinkedList<int>();
		linkedList.AddFirst(_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D);
		while (linkedList.First != null)
		{
			_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D = linkedList.First.Value;
			linkedList.RemoveFirst();
			IndexTriangle indexTriangle = Triangles[_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D];
			Vector3D _0023_003DzZbOaTIM_003D = _0023_003DzCJ9B_0024i3JUvLY(_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D);
			List<int> list = new List<int>(new int[3] { indexTriangle.V1, indexTriangle.V2, indexTriangle.V3 });
			list.Sort();
			int num = list[0];
			int num2 = list[1];
			int num3 = list[2];
			if (_0023_003DznkPLPRg_003D[_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D])
			{
				continue;
			}
			_0023_003DznkPLPRg_003D[_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D] = true;
			_0023_003DzqzOxI2eLSxxwou3qOPDNv9oWI_27.Add(_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D);
			foreach (SharedEdge item in _0023_003DzPysnrsiTT_0024jt[num])
			{
				if (item.V2 == num2)
				{
					_0023_003DzpV1ysWM_003D(_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D, _0023_003DznkPLPRg_003D, _0023_003DzZbOaTIM_003D, _0023_003Dzm0CYiiE_003D, item, linkedList);
				}
				else if (item.V2 == num3)
				{
					_0023_003DzpV1ysWM_003D(_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D, _0023_003DznkPLPRg_003D, _0023_003DzZbOaTIM_003D, _0023_003Dzm0CYiiE_003D, item, linkedList);
				}
			}
			foreach (SharedEdge item2 in _0023_003DzPysnrsiTT_0024jt[num2])
			{
				if (item2.V2 == num3)
				{
					_0023_003DzpV1ysWM_003D(_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D, _0023_003DznkPLPRg_003D, _0023_003DzZbOaTIM_003D, _0023_003Dzm0CYiiE_003D, item2, linkedList);
					break;
				}
			}
		}
	}

	private void _0023_003DzpV1ysWM_003D(int _0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D, bool[] _0023_003DznkPLPRg_003D, Vector3D _0023_003DzZbOaTIM_003D, double _0023_003Dzm0CYiiE_003D, SharedEdge _0023_003DzeyQd9LoOUlcN, LinkedList<int> _0023_003DzGSm7P1R2CVCiC5o802br_9s_003D)
	{
		if (_0023_003DzeyQd9LoOUlcN.Mum == _0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D)
		{
			int dad = _0023_003DzeyQd9LoOUlcN.Dad;
			if (_0023_003DzeyQd9LoOUlcN.Dad >= 0 && !_0023_003DznkPLPRg_003D[dad])
			{
				Vector3D v = _0023_003DzCJ9B_0024i3JUvLY(dad);
				if (Vector3D.AngleBetween(_0023_003DzZbOaTIM_003D, v) < _0023_003Dzm0CYiiE_003D)
				{
					_0023_003DzGSm7P1R2CVCiC5o802br_9s_003D.AddFirst(dad);
				}
			}
		}
		else if (!_0023_003DznkPLPRg_003D[_0023_003DzeyQd9LoOUlcN.Mum])
		{
			int mum = _0023_003DzeyQd9LoOUlcN.Mum;
			Vector3D v2 = _0023_003DzCJ9B_0024i3JUvLY(mum);
			if (Vector3D.AngleBetween(_0023_003DzZbOaTIM_003D, v2) < _0023_003Dzm0CYiiE_003D)
			{
				_0023_003DzGSm7P1R2CVCiC5o802br_9s_003D.AddFirst(mum);
			}
		}
	}

	private Vector3D _0023_003DzCJ9B_0024i3JUvLY(int _0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D)
	{
		IndexTriangle indexTriangle = Triangles[_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D];
		Vector3D vector3D;
		if (indexTriangle is ITriangleSupportsNormals)
		{
			ITriangleSupportsNormals triangleSupportsNormals = (ITriangleSupportsNormals)indexTriangle;
			vector3D = Normals[triangleSupportsNormals.N1] + Normals[triangleSupportsNormals.N2] + Normals[triangleSupportsNormals.N3];
			vector3D.Normalize();
		}
		else
		{
			vector3D = Normals[_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D];
		}
		return vector3D;
	}

	public Mesh ConvertToMesh(double deviation = 0.0, double angle = 0.0, natureType nature = natureType.Smooth, bool weld = true)
	{
		Mesh mesh = new Mesh(0, 0, nature);
		int num = _vertices.Length;
		mesh._vertices = new Point3D[num];
		for (int i = 0; i < num; i++)
		{
			Point3D point3D = _vertices[i];
			if (nature == natureType.MulticolorPlain || nature == natureType.MulticolorSmooth)
			{
				mesh.Vertices[i] = new PointRGB(point3D.X, point3D.Y, point3D.Z, Color.R, Color.G, Color.B);
			}
			else
			{
				mesh.Vertices[i] = new Point3D(point3D.X, point3D.Y, point3D.Z);
			}
		}
		int num2 = _triangles.Length;
		mesh.Triangles = new IndexTriangle[num2];
		for (int j = 0; j < num2; j++)
		{
			IndexTriangle indexTriangle = _triangles[j];
			switch (nature)
			{
			case natureType.Plain:
				mesh.Triangles[j] = new IndexTriangle(indexTriangle.V1, indexTriangle.V2, indexTriangle.V3);
				break;
			case natureType.ColorPlain:
			case natureType.MulticolorPlain:
				mesh.Triangles[j] = new ColorTriangle(indexTriangle.V1, indexTriangle.V2, indexTriangle.V3, Color);
				break;
			case natureType.RichPlain:
				mesh.Triangles[j] = new RichTriangle(indexTriangle.V1, indexTriangle.V2, indexTriangle.V3, indexTriangle.V1, indexTriangle.V2, indexTriangle.V3);
				break;
			case natureType.Smooth:
				mesh.Triangles[j] = new SmoothTriangle(indexTriangle.V1, indexTriangle.V2, indexTriangle.V3);
				break;
			case natureType.ColorSmooth:
			case natureType.MulticolorSmooth:
				mesh.Triangles[j] = new ColorSmoothTriangle(indexTriangle.V1, indexTriangle.V2, indexTriangle.V3, Color);
				break;
			case natureType.RichSmooth:
				mesh.Triangles[j] = new RichSmoothTriangle(indexTriangle.V1, indexTriangle.V2, indexTriangle.V3, indexTriangle.V1, indexTriangle.V2, indexTriangle.V3, indexTriangle.V1, indexTriangle.V2, indexTriangle.V3);
				break;
			}
		}
		mesh.CopyAttributes(this);
		return mesh;
	}

	public Surface[] ConvertToSurfaces()
	{
		Surface[] array = new Surface[_triangles.Length];
		for (int i = 0; i < _triangles.Length; i++)
		{
			IndexTriangle indexTriangle = _triangles[i];
			Plane plane = new Plane(_vertices[indexTriangle.V1], _vertices[indexTriangle.V2], _vertices[indexTriangle.V3]);
			Region region = new Region(new CompositeCurve(new Line[3]
			{
				new Line(plane, plane.Project(_vertices[indexTriangle.V1]), plane.Project(_vertices[indexTriangle.V2])),
				new Line(plane, plane.Project(_vertices[indexTriangle.V2]), plane.Project(_vertices[indexTriangle.V3])),
				new Line(plane, plane.Project(_vertices[indexTriangle.V3]), plane.Project(_vertices[indexTriangle.V1]))
			}, sortAndOrient: false), plane, sortAndOrient: false);
			region.CopyAttributes(this);
			array[i] = region.ConvertToSurface();
		}
		return array;
	}

	public Brep ConvertToBrep(bool mergeFaces = true, bool mergeEdges = true)
	{
		if (mergeFaces)
		{
			return _0023_003DzN6MZu8kyJXBL1r30GN3JBYE_003D(mergeEdges);
		}
		return _0023_003DzuIqZT0wz2vAK2iAQPw_003D_003D();
	}

	private Brep _0023_003DzN6MZu8kyJXBL1r30GN3JBYE_003D(bool _0023_003DzQhPUPBREBDDg)
	{
		if (sharedEdges == null)
		{
			_0023_003Dz_0024YeSaS1uGUxB();
		}
		Plane[] array = new Plane[_triangles.Length];
		for (int i = 0; i < _triangles.Length; i++)
		{
			IndexTriangle indexTriangle = _triangles[i];
			array[i] = new Plane(_vertices[indexTriangle.V1], _vertices[indexTriangle.V2], _vertices[indexTriangle.V3]);
		}
		HashSet<int>[] array2 = new HashSet<int>[_triangles.Length];
		for (int j = 0; j < _triangles.Length; j++)
		{
			array2[j] = new HashSet<int>(3);
		}
		int length = sharedEdges.GetLength(0);
		for (int k = 0; k < length; k++)
		{
			int num = sharedEdges[k, 2];
			int num2 = sharedEdges[k, 3];
			if (num >= 0 && num2 >= 0 && num != num2)
			{
				array2[num].Add(num2);
				array2[num2].Add(num);
			}
		}
		List<List<int>> list = new List<List<int>>(_triangles.Length);
		bool[] array3 = new bool[_triangles.Length];
		int num3 = 0;
		int l = 0;
		Stack<int> stack = new Stack<int>(_triangles.Length);
		while (num3 < _triangles.Length)
		{
			for (; l < _triangles.Length && array3[l]; l++)
			{
			}
			if (l >= _triangles.Length)
			{
				break;
			}
			List<int> list2 = new List<int>();
			stack.Push(l);
			array3[l] = true;
			num3++;
			while (stack.Count > 0)
			{
				int num4 = stack.Pop();
				list2.Add(num4);
				foreach (int item2 in array2[num4])
				{
					if (!array3[item2] && Plane.Intersection(array[num4], array[item2], Utility._0023_003DzmJq0qCkmyW_ojQnBEK6tFMvwPBqiC7SchQ_003D_003D, out var _) == planeIntersectionType.Coincide)
					{
						array3[item2] = true;
						num3++;
						stack.Push(item2);
					}
				}
			}
			list.Add(list2);
		}
		List<Surface> list3 = new List<Surface>();
		for (int m = 0; m < list.Count; m++)
		{
			List<int> list4 = list[m];
			HashSet<(int, int)> hashSet = new HashSet<(int, int)>();
			foreach (int item3 in list4)
			{
				IndexTriangle indexTriangle2 = _triangles[item3];
				if (hashSet.Contains((indexTriangle2.V2, indexTriangle2.V1)))
				{
					hashSet.Remove((indexTriangle2.V2, indexTriangle2.V1));
				}
				else
				{
					hashSet.Add((indexTriangle2.V1, indexTriangle2.V2));
				}
				if (hashSet.Contains((indexTriangle2.V3, indexTriangle2.V2)))
				{
					hashSet.Remove((indexTriangle2.V3, indexTriangle2.V2));
				}
				else
				{
					hashSet.Add((indexTriangle2.V2, indexTriangle2.V3));
				}
				if (hashSet.Contains((indexTriangle2.V1, indexTriangle2.V3)))
				{
					hashSet.Remove((indexTriangle2.V1, indexTriangle2.V3));
				}
				else
				{
					hashSet.Add((indexTriangle2.V3, indexTriangle2.V1));
				}
			}
			List<ICurve> list5 = new List<ICurve>();
			while (hashSet.Count > 0)
			{
				_0023_003DzB0hRnjubCnfd_v5ZLdiOfNM_003D _0023_003DzB0hRnjubCnfd_v5ZLdiOfNM_003D2 = new _0023_003DzB0hRnjubCnfd_v5ZLdiOfNM_003D();
				_0023_003DzB0hRnjubCnfd_v5ZLdiOfNM_003D2._0023_003DzIvSnYaGVdrwK = hashSet.ElementAt(0);
				List<Line> list6 = new List<Line>(1)
				{
					new Line(_vertices[_0023_003DzB0hRnjubCnfd_v5ZLdiOfNM_003D2._0023_003DzIvSnYaGVdrwK.Item1], _vertices[_0023_003DzB0hRnjubCnfd_v5ZLdiOfNM_003D2._0023_003DzIvSnYaGVdrwK.Item2])
				};
				hashSet.Remove(_0023_003DzB0hRnjubCnfd_v5ZLdiOfNM_003D2._0023_003DzIvSnYaGVdrwK);
				int item = _0023_003DzB0hRnjubCnfd_v5ZLdiOfNM_003D2._0023_003DzIvSnYaGVdrwK.Item1;
				while (_0023_003DzB0hRnjubCnfd_v5ZLdiOfNM_003D2._0023_003DzIvSnYaGVdrwK.Item2 != item)
				{
					_0023_003DzB0hRnjubCnfd_v5ZLdiOfNM_003D2._0023_003DzIvSnYaGVdrwK = hashSet.First(_0023_003DzB0hRnjubCnfd_v5ZLdiOfNM_003D2._0023_003Dzk2aGNKiIkBiRqFR8ymcvs4FrE8f_RtdLIg_003D_003D);
					list6.Add(new Line(_vertices[_0023_003DzB0hRnjubCnfd_v5ZLdiOfNM_003D2._0023_003DzIvSnYaGVdrwK.Item1], _vertices[_0023_003DzB0hRnjubCnfd_v5ZLdiOfNM_003D2._0023_003DzIvSnYaGVdrwK.Item2]));
					hashSet.Remove(_0023_003DzB0hRnjubCnfd_v5ZLdiOfNM_003D2._0023_003DzIvSnYaGVdrwK);
				}
				if (_0023_003DzQhPUPBREBDDg)
				{
					List<Line> list7 = new List<Line>();
					bool[] array4 = new bool[list6.Count];
					for (int n = 0; n < list6.Count; n++)
					{
						Line line = list6[n];
						Line line2 = list6[(n + 1) % list6.Count];
						array4[n] = Vector3D.AreCoincident(line.Tangent, line2.Tangent);
					}
					int num5 = 0;
					for (int num6 = 0; num6 < array4.Length; num6++)
					{
						if (!array4[num6])
						{
							num5 = (num6 + 1) % array4.Length;
							break;
						}
					}
					Point3D point3D = null;
					for (int num7 = 0; num7 < list6.Count; num7++)
					{
						int num8 = (num5 + num7) % list6.Count;
						if (point3D == null)
						{
							point3D = list6[num8].StartPoint;
						}
						if (!array4[num8])
						{
							list7.Add(new Line(point3D, list6[num8].EndPoint));
							point3D = null;
						}
					}
					list5.Add(new CompositeCurve(list7));
				}
				else
				{
					list5.Add(new CompositeCurve(list6));
				}
			}
			Plane plane = array[list4[0]];
			Region[] array5 = Utility.DetectRegionsFromContours(list5, plane);
			foreach (Region region in array5)
			{
				list3.Add(region.ConvertToSurface());
			}
		}
		Solidifier solidifier = new Solidifier(list3, Utility._0023_003DzheSR8QM7q9ya);
		solidifier.DoWork();
		Brep result = solidifier.Result;
		result.CopyAttributes(this);
		return result;
	}

	private Brep _0023_003DzuIqZT0wz2vAK2iAQPw_003D_003D()
	{
		Brep.Vertex[] array = new Brep.Vertex[_vertices.Length];
		for (int i = 0; i < _vertices.Length; i++)
		{
			array[i] = new Brep.Vertex(_vertices[i].X, _vertices[i].Y, _vertices[i].Z);
		}
		if (sharedEdges == null)
		{
			_0023_003Dz_0024YeSaS1uGUxB();
		}
		Brep.Edge[] array2 = new Brep.Edge[sharedEdges.GetLength(0)];
		_0023_003DzHGlGj7oYIL6hV3aiCu4SRzE_003D _0023_003DzvXH4wxQ_003D = default(_0023_003DzHGlGj7oYIL6hV3aiCu4SRzE_003D);
		_0023_003DzvXH4wxQ_003D._0023_003DzAAkdMI4Ul71Y = new Dictionary<(int, int), int>();
		for (int j = 0; j < sharedEdges.GetLength(0); j++)
		{
			array2[j] = new Brep.Edge(new Line((Point3D)_vertices[sharedEdges[j, 0]].Clone(), (Point3D)_vertices[sharedEdges[j, 1]].Clone()), sharedEdges[j, 0], sharedEdges[j, 1]);
			_0023_003DzvXH4wxQ_003D._0023_003DzAAkdMI4Ul71Y[(sharedEdges[j, 0], sharedEdges[j, 1])] = j;
		}
		Brep.Face[] array3 = new Brep.Face[_triangles.Length];
		for (int k = 0; k < _triangles.Length; k++)
		{
			IndexTriangle indexTriangle = _triangles[k];
			PlanarSurf surface = new PlanarSurf(new Plane(_vertices[indexTriangle.V1], _vertices[indexTriangle.V2], _vertices[indexTriangle.V3]));
			bool _0023_003Dzx3pYiE0_003D;
			int curveIndex = _0023_003DqOYw_GJIOxYicIbk7_if3kyDHejVsVt3lTACnUPpaYsHPRpQJvQYOIdKRXAb5iX8dqg9BdzZo1UMOCmgzoLB8XQ_003D_003D(indexTriangle.V1, indexTriangle.V2, out _0023_003Dzx3pYiE0_003D, ref _0023_003DzvXH4wxQ_003D);
			bool _0023_003Dzx3pYiE0_003D2;
			int curveIndex2 = _0023_003DqOYw_GJIOxYicIbk7_if3kyDHejVsVt3lTACnUPpaYsHPRpQJvQYOIdKRXAb5iX8dqg9BdzZo1UMOCmgzoLB8XQ_003D_003D(indexTriangle.V2, indexTriangle.V3, out _0023_003Dzx3pYiE0_003D2, ref _0023_003DzvXH4wxQ_003D);
			bool _0023_003Dzx3pYiE0_003D3;
			int curveIndex3 = _0023_003DqOYw_GJIOxYicIbk7_if3kyDHejVsVt3lTACnUPpaYsHPRpQJvQYOIdKRXAb5iX8dqg9BdzZo1UMOCmgzoLB8XQ_003D_003D(indexTriangle.V3, indexTriangle.V1, out _0023_003Dzx3pYiE0_003D3, ref _0023_003DzvXH4wxQ_003D);
			Brep.OrientedEdge[] segments = new Brep.OrientedEdge[3]
			{
				new Brep.OrientedEdge(curveIndex, _0023_003Dzx3pYiE0_003D),
				new Brep.OrientedEdge(curveIndex2, _0023_003Dzx3pYiE0_003D2),
				new Brep.OrientedEdge(curveIndex3, _0023_003Dzx3pYiE0_003D3)
			};
			Brep.Face face = new Brep.Face(surface, new Brep.Loop(segments));
			array3[k] = face;
		}
		Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D = array;
		Brep brep = new Brep(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, array2, array3, _0023_003DzqMxdROkOZ2gG: true, null, _0023_003DzPPoX8HETqTZN: false, _0023_003DzMcq9hcRIFsnaUZ3PgA_003D_003D: false);
		brep.CopyAttributes(this);
		return brep;
	}

	public FemMesh ConvertToFemMesh(Material mat, bool t6)
	{
		FemMesh femMesh = new FemMesh(0, 0);
		if (t6)
		{
			if (Triangles.Length != 0 && Triangles[0] is QuadraticTriangle)
			{
				int num = Vertices.Length;
				femMesh.Vertices = new Point3D[Vertices.Length];
				for (int i = 0; i < num; i++)
				{
					Point3D point3D = Vertices[i];
					femMesh.Vertices[i] = new Node(point3D.X, point3D.Y, point3D.Z);
				}
				num = Triangles.Length;
				femMesh.Elements = new Element[num];
				for (int j = 0; j < num; j++)
				{
					QuadraticTriangle quadraticTriangle = (QuadraticTriangle)Triangles[j];
					femMesh.Elements[j] = new Tria6(quadraticTriangle.V1, quadraticTriangle.V6, quadraticTriangle.V3, quadraticTriangle.V5, quadraticTriangle.V2, quadraticTriangle.V4, mat);
				}
			}
			else
			{
				int edgesWithoutDuplicates = Utility.GetEdgesWithoutDuplicates(Triangles, Vertices.Length, out var edgesPerVertex);
				femMesh.Vertices = new Point3D[Vertices.Length + edgesWithoutDuplicates];
				for (int k = 0; k < Vertices.Length; k++)
				{
					Point3D point3D2 = Vertices[k];
					femMesh.Vertices[k] = new Node(point3D2.X, point3D2.Y, point3D2.Z);
				}
				edgesWithoutDuplicates = Vertices.Length;
				LinkedList<int>[] array = new LinkedList<int>[edgesPerVertex.Length];
				for (int l = 0; l < edgesPerVertex.Length; l++)
				{
					array[l] = new LinkedList<int>();
				}
				for (int m = 0; m < edgesPerVertex.Length; m++)
				{
					LinkedListNode<SharedEdge> linkedListNode = edgesPerVertex[m].First;
					if (linkedListNode != null)
					{
						do
						{
							SharedEdge value = linkedListNode.Value;
							Point3D midPoint = new Segment3D(Vertices[m], Vertices[value.V2]).MidPoint;
							femMesh.Vertices[edgesWithoutDuplicates] = new Node(midPoint.X, midPoint.Y, midPoint.Z);
							array[m].AddLast(edgesWithoutDuplicates);
							edgesWithoutDuplicates++;
							linkedListNode = linkedListNode.Next;
						}
						while (linkedListNode != null);
					}
				}
				femMesh.Elements = new Element[Triangles.Length];
				for (int n = 0; n < Triangles.Length; n++)
				{
					IndexTriangle indexTriangle = Triangles[n];
					int nodeIndex = _0023_003Dzm8zBMCdJjctL(indexTriangle.V1, indexTriangle.V2, edgesPerVertex, array);
					int nodeIndex2 = _0023_003Dzm8zBMCdJjctL(indexTriangle.V2, indexTriangle.V3, edgesPerVertex, array);
					int nodeIndex3 = _0023_003Dzm8zBMCdJjctL(indexTriangle.V3, indexTriangle.V1, edgesPerVertex, array);
					femMesh.Elements[n] = new Tria6(indexTriangle.V1, nodeIndex, indexTriangle.V2, nodeIndex2, indexTriangle.V3, nodeIndex3, mat);
				}
			}
		}
		else
		{
			femMesh.Vertices = new Point3D[Vertices.Length];
			for (int num2 = 0; num2 < Vertices.Length; num2++)
			{
				Point3D point3D3 = Vertices[num2];
				femMesh.Vertices[num2] = new Node(point3D3.X, point3D3.Y, point3D3.Z);
			}
			femMesh.Elements = new Element[Triangles.Length];
			for (int num3 = 0; num3 < Triangles.Length; num3++)
			{
				IndexTriangle indexTriangle2 = Triangles[num3];
				femMesh.Elements[num3] = new Tria3(indexTriangle2.V1, indexTriangle2.V2, indexTriangle2.V3, mat);
			}
		}
		return femMesh;
	}

	private int _0023_003Dzm8zBMCdJjctL(int _0023_003Dz3meCwcU_003D, int _0023_003DzOZnLD38_003D, LinkedList<SharedEdge>[] _0023_003Dzmx8Td5k_003D, LinkedList<int>[] _0023_003DzDPCfzJM_003D)
	{
		if (_0023_003DzOZnLD38_003D < _0023_003Dz3meCwcU_003D)
		{
			int num = _0023_003Dz3meCwcU_003D;
			_0023_003Dz3meCwcU_003D = _0023_003DzOZnLD38_003D;
			_0023_003DzOZnLD38_003D = num;
		}
		LinkedListNode<SharedEdge> linkedListNode = _0023_003Dzmx8Td5k_003D[_0023_003Dz3meCwcU_003D].First;
		LinkedListNode<int> linkedListNode2 = _0023_003DzDPCfzJM_003D[_0023_003Dz3meCwcU_003D].First;
		do
		{
			if (linkedListNode.Value.V2 == _0023_003DzOZnLD38_003D)
			{
				return linkedListNode2.Value;
			}
			linkedListNode = linkedListNode.Next;
			linkedListNode2 = linkedListNode2.Next;
		}
		while (linkedListNode != null);
		return -1;
	}

	public void GetTightBBox(out Point3D boxMin, out Point3D boxMax)
	{
		ComputeBoundingBox(null, out boxMin, out boxMax);
	}

	public static Mesh CreateCylinder(double radius, double height, int slices)
	{
		return CreateCone<Mesh>(radius, radius, height, slices);
	}

	public static T CreateCylinder<T>(double radius, double height, int slices) where T : Mesh, new()
	{
		return CreateCone<T>(radius, radius, height, slices);
	}

	public static Mesh CreateCylinder(double radius, double height, int slices, natureType meshNature)
	{
		return CreateCone<Mesh>(radius, radius, height, slices, meshNature, edgeStyleType.Sharp);
	}

	public static T CreateCylinder<T>(double radius, double height, int slices, natureType meshNature) where T : Mesh, new()
	{
		return CreateCone<T>(radius, radius, height, slices, meshNature, edgeStyleType.Sharp);
	}

	public static Mesh CreateCylinder(double radius, double height, int slices, natureType meshNature, edgeStyleType edgeStyle)
	{
		return CreateCone<Mesh>(radius, radius, height, slices, meshNature, edgeStyle);
	}

	public static T CreateCylinder<T>(double radius, double height, int slices, natureType meshNature, edgeStyleType edgeStyle) where T : Mesh, new()
	{
		return CreateCone<T>(radius, radius, height, slices, meshNature, edgeStyle);
	}

	public static Mesh CreateCylinder(double radius, Point3D point1, Point3D point2, int slices)
	{
		return CreateCone<Mesh>(radius, radius, point1, point2, slices, natureType.Plain);
	}

	public static T CreateCylinder<T>(double radius, Point3D point1, Point3D point2, int slices) where T : Mesh, new()
	{
		return CreateCone<T>(radius, radius, point1, point2, slices, natureType.Plain);
	}

	public static Mesh CreateCylinder(double radius, Point3D point1, Point3D point2, int slices, natureType meshNature)
	{
		return CreateCone<Mesh>(radius, radius, point1, point2, slices, meshNature, edgeStyleType.Sharp);
	}

	public static T CreateCylinder<T>(double radius, Point3D point1, Point3D point2, int slices, natureType meshNature) where T : Mesh, new()
	{
		return CreateCone<T>(radius, radius, point1, point2, slices, meshNature, edgeStyleType.Sharp);
	}

	public static Mesh CreateCylinder(double radius, Point3D point1, Point3D point2, int slices, natureType meshNature, edgeStyleType edgeStyle)
	{
		return CreateCone<Mesh>(radius, radius, point1, point2, slices, meshNature, edgeStyle);
	}

	public static T CreateCylinder<T>(double radius, Point3D point1, Point3D point2, int slices, natureType meshNature, edgeStyleType edgeStyle) where T : Mesh, new()
	{
		return CreateCone<T>(radius, radius, point1, point2, slices, meshNature, edgeStyle);
	}

	internal static void _0023_003DzzgKMdKw_003D(IList<Point3D> _0023_003DzBZc7VVG5asYu, IList<IList<Point3D>> _0023_003DzxZtQCI37epAc, Plane _0023_003Dzrgqz890sj_0024X9, out IList<Point2D> _0023_003DzJB9yXb3atfkL, out IList<IList<Point2D>> _0023_003DzLYWjuc33iWj_BX5R_0024A_003D_003D)
	{
		Transformation transformation = new Transformation();
		transformation.Rotation(_0023_003Dzrgqz890sj_0024X9, Plane.XY);
		_0023_003DzJB9yXb3atfkL = new Point2D[_0023_003DzBZc7VVG5asYu.Count];
		for (int i = 0; i < _0023_003DzBZc7VVG5asYu.Count; i++)
		{
			_0023_003DzJB9yXb3atfkL[i] = transformation * _0023_003DzBZc7VVG5asYu[i];
		}
		_0023_003DzLYWjuc33iWj_BX5R_0024A_003D_003D = null;
		if (_0023_003DzxZtQCI37epAc == null)
		{
			return;
		}
		_0023_003DzLYWjuc33iWj_BX5R_0024A_003D_003D = new Point2D[_0023_003DzxZtQCI37epAc.Count][];
		for (int j = 0; j < _0023_003DzxZtQCI37epAc.Count; j++)
		{
			_0023_003DzLYWjuc33iWj_BX5R_0024A_003D_003D[j] = new Point2D[_0023_003DzxZtQCI37epAc[j].Count];
			for (int k = 0; k < _0023_003DzxZtQCI37epAc[j].Count; k++)
			{
				_0023_003DzLYWjuc33iWj_BX5R_0024A_003D_003D[j][k] = transformation * _0023_003DzxZtQCI37epAc[j][k];
			}
		}
	}

	private void _0023_003DzOwrB4MXYn7Qh4dRPyg5n_yIxBWPX(Point2D[] _0023_003DzY3ahEmgbxOhjQjTWbA_003D_003D, IndexTriangle[] _0023_003DzXT3BRSZezblHON7QOg_003D_003D)
	{
		_vertices = new Point3D[_0023_003DzY3ahEmgbxOhjQjTWbA_003D_003D.Length];
		for (int i = 0; i < _vertices.Length; i++)
		{
			_vertices[i] = Utility.CreateVertex(_meshNature, _0023_003DzY3ahEmgbxOhjQjTWbA_003D_003D[i].X, _0023_003DzY3ahEmgbxOhjQjTWbA_003D_003D[i].Y, 0.0);
		}
		_triangles = new IndexTriangle[_0023_003DzXT3BRSZezblHON7QOg_003D_003D.Length];
		for (int j = 0; j < _0023_003DzXT3BRSZezblHON7QOg_003D_003D.Length; j++)
		{
			IndexTriangle indexTriangle = _0023_003DzXT3BRSZezblHON7QOg_003D_003D[j];
			_triangles[j] = Utility.CreateTriangle(_meshNature, indexTriangle.V1, indexTriangle.V2, indexTriangle.V3);
			_0023_003DzTELBpP5fqJNd(_meshNature, _triangles[j]);
		}
		RegenMode = regenType.RegenAndCompile;
	}

	internal static void _0023_003DzRPB8Ocs_003D(Plane _0023_003Dzrgqz890sj_0024X9, IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, int _0023_003Dz736ekIs_003D)
	{
		Transformation transformation = new Transformation(_0023_003Dzrgqz890sj_0024X9.Origin, _0023_003Dzrgqz890sj_0024X9.AxisX, _0023_003Dzrgqz890sj_0024X9.AxisY, _0023_003Dzrgqz890sj_0024X9.AxisZ);
		if (_0023_003Dz736ekIs_003D <= 0)
		{
			return;
		}
		if (_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0] is PointRGB)
		{
			for (int i = 0; i < _0023_003Dz736ekIs_003D; i++)
			{
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i] = transformation * (PointRGB)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i];
			}
		}
		else
		{
			for (int j = 0; j < _0023_003Dz736ekIs_003D; j++)
			{
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[j] = transformation * _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[j];
			}
		}
	}

	public void MergeWith(Mesh mesh, bool weldNow = true, bool recomputeEdges = true)
	{
		if (_meshNature != natureType.Undefined && mesh._meshNature != natureType.Undefined && _meshNature != mesh._meshNature)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972717) + _meshNature.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972917) + mesh._meshNature.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907930));
		}
		int num = _vertices.Length;
		int num2 = ((!(mesh is Solid.Portion)) ? mesh._vertices.Length : ((Solid.Portion)mesh).vertexCount);
		Array.Resize(ref _vertices, num + num2);
		for (int i = 0; i < num2; i++)
		{
			_vertices[i + num] = (Point3D)mesh._vertices[i].Clone();
		}
		int num3 = 0;
		if (_normals != null && mesh.Normals != null)
		{
			num3 = _normals.Length;
			Array.Resize(ref _normals, num3 + mesh._normals.Length);
			for (int j = 0; j < mesh._normals.Length; j++)
			{
				_normals[j + num3] = (Vector3D)mesh._normals[j].Clone();
			}
		}
		else
		{
			_normals = null;
		}
		int num4 = _triangles.Length;
		Array.Resize(ref _triangles, num4 + mesh._triangles.Length);
		int num5 = 0;
		if (_texCoords != null && _texCoords.Length != 0 && mesh._texCoords != null && mesh._texCoords.Length != 0)
		{
			if (_texCoords == null)
			{
				_texCoords = new PointF[mesh._texCoords.Length];
			}
			else
			{
				num5 = _texCoords.Length;
				Array.Resize(ref _texCoords, num5 + mesh._texCoords.Length);
			}
			for (int k = 0; k < mesh._texCoords.Length; k++)
			{
				_texCoords[k + num5] = mesh._texCoords[k];
			}
		}
		if (_triangles.Length != 0 && _triangles[0] == null)
		{
			_triangles[0] = mesh._triangles[0];
		}
		if (_triangles.Length != 0)
		{
			if (_triangles[0] is RichTriangle)
			{
				for (int l = 0; l < mesh._triangles.Length; l++)
				{
					_triangles[l + num4] = (IndexTriangle)mesh._triangles[l].Clone();
					_triangles[l + num4].V1 += num;
					_triangles[l + num4].V2 += num;
					_triangles[l + num4].V3 += num;
					((RichTriangle)_triangles[l + num4]).T1 += num5;
					((RichTriangle)_triangles[l + num4]).T2 += num5;
					((RichTriangle)_triangles[l + num4]).T3 += num5;
				}
			}
			else if (_triangles[0] is RichSmoothTriangle)
			{
				for (int m = 0; m < mesh._triangles.Length; m++)
				{
					_triangles[m + num4] = (IndexTriangle)mesh._triangles[m].Clone();
					_triangles[m + num4].V1 += num;
					_triangles[m + num4].V2 += num;
					_triangles[m + num4].V3 += num;
					if (num3 > 0)
					{
						((SmoothTriangle)_triangles[m + num4]).N1 += num3;
						((SmoothTriangle)_triangles[m + num4]).N2 += num3;
						((SmoothTriangle)_triangles[m + num4]).N3 += num3;
					}
					((RichSmoothTriangle)_triangles[m + num4]).T1 += num5;
					((RichSmoothTriangle)_triangles[m + num4]).T2 += num5;
					((RichSmoothTriangle)_triangles[m + num4]).T3 += num5;
				}
			}
			else if (_triangles[0] is ColorTriangle)
			{
				for (int n = 0; n < mesh._triangles.Length; n++)
				{
					_triangles[n + num4] = (IndexTriangle)mesh._triangles[n].Clone();
					_triangles[n + num4].V1 += num;
					_triangles[n + num4].V2 += num;
					_triangles[n + num4].V3 += num;
				}
			}
			else if (_triangles[0] is ColorSmoothTriangle)
			{
				for (int num6 = 0; num6 < mesh._triangles.Length; num6++)
				{
					_triangles[num6 + num4] = (ColorSmoothTriangle)mesh._triangles[num6].Clone();
					if (num3 > 0)
					{
						((SmoothTriangle)_triangles[num6 + num4]).N1 += num3;
						((SmoothTriangle)_triangles[num6 + num4]).N2 += num3;
						((SmoothTriangle)_triangles[num6 + num4]).N3 += num3;
					}
					_triangles[num6 + num4].V1 += num;
					_triangles[num6 + num4].V2 += num;
					_triangles[num6 + num4].V3 += num;
				}
			}
			else if (_triangles[0] is SmoothTriangle)
			{
				for (int num7 = 0; num7 < mesh._triangles.Length; num7++)
				{
					_triangles[num7 + num4] = (SmoothTriangle)mesh._triangles[num7].Clone();
					_triangles[num7 + num4].V1 += num;
					_triangles[num7 + num4].V2 += num;
					_triangles[num7 + num4].V3 += num;
					if (num3 > 0)
					{
						((SmoothTriangle)_triangles[num7 + num4]).N1 += num3;
						((SmoothTriangle)_triangles[num7 + num4]).N2 += num3;
						((SmoothTriangle)_triangles[num7 + num4]).N3 += num3;
					}
				}
			}
			else if (_triangles[0] is QuadraticTriangle)
			{
				for (int num8 = 0; num8 < mesh._triangles.Length; num8++)
				{
					_triangles[num8 + num4] = (QuadraticTriangle)mesh._triangles[num8].Clone();
					_triangles[num8 + num4].V1 += num;
					_triangles[num8 + num4].V2 += num;
					_triangles[num8 + num4].V3 += num;
					((QuadraticTriangle)_triangles[num8 + num4]).V4 += num;
					((QuadraticTriangle)_triangles[num8 + num4]).V5 += num;
					((QuadraticTriangle)_triangles[num8 + num4]).V6 += num;
				}
			}
			else if ((object)_triangles[0] != null)
			{
				for (int num9 = 0; num9 < mesh._triangles.Length; num9++)
				{
					_triangles[num9 + num4] = (IndexTriangle)mesh._triangles[num9].Clone();
					_triangles[num9 + num4].V1 += num;
					_triangles[num9 + num4].V2 += num;
					_triangles[num9 + num4].V3 += num;
				}
			}
		}
		if (!recomputeEdges && _edges != null && mesh._edges != null)
		{
			int num10 = _edges.Length;
			Array.Resize(ref _edges, num10 + mesh._edges.Length);
			for (int num11 = 0; num11 < mesh._edges.Length; num11++)
			{
				_edges[num11 + num10] = (IndexLine)mesh._edges[num11].Clone();
				_edges[num11 + num10].V1 += num;
				_edges[num11 + num10].V2 += num;
			}
		}
		RegenMode = regenType.RegenAndCompile;
		if (weldNow)
		{
			Weld();
		}
		if (Normals != null && Normals.Length != 0)
		{
			if (recomputeEdges)
			{
				sharedEdges = null;
				ComputeEdges();
			}
			return;
		}
		Normals = null;
		if (recomputeEdges)
		{
			Edges = null;
		}
		if (Normals != null && Normals.Length != 0)
		{
			RegenMode = regenType.CompileOnly;
			UpdateBoundingBox(null);
		}
		else
		{
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public virtual void MergeWith(Quad quad, bool weldNow)
	{
		int num = ((_vertices != null) ? _vertices.Length : 0);
		Array.Resize(ref _vertices, num + 4);
		Array.Copy(quad.Vertices, 0, _vertices, num, 4);
		int num2 = ((_triangles != null) ? _triangles.Length : 0);
		Array.Resize(ref _triangles, num2 + 2);
		IndexTriangle indexTriangle = new IndexTriangle();
		indexTriangle.V1 = num;
		indexTriangle.V2 = 1 + num;
		indexTriangle.V3 = 2 + num;
		_triangles[num2] = indexTriangle;
		indexTriangle = new IndexTriangle();
		indexTriangle.V1 = num;
		indexTriangle.V2 = 2 + num;
		indexTriangle.V3 = 3 + num;
		_triangles[num2 + 1] = indexTriangle;
		RegenMode = regenType.RegenAndCompile;
		if (weldNow)
		{
			Weld();
		}
		RegenMode = regenType.RegenAndCompile;
	}

	public void MergeWith(Quad quad)
	{
		MergeWith(quad, weldNow: true);
	}

	public virtual void MergeWith(Triangle triangle, bool weldNow)
	{
		int num = ((_vertices != null) ? _vertices.Length : 0);
		Array.Resize(ref _vertices, num + 3);
		Array.Copy(triangle.Vertices, 0, _vertices, num, 3);
		int num2 = ((_triangles != null) ? _triangles.Length : 0);
		Array.Resize(ref _triangles, num2 + 1);
		IndexTriangle indexTriangle = new IndexTriangle();
		indexTriangle.V1 = num;
		indexTriangle.V2 = 1 + num;
		indexTriangle.V3 = 2 + num;
		_triangles[num2] = indexTriangle;
		RegenMode = regenType.RegenAndCompile;
		if (weldNow)
		{
			Weld();
		}
		RegenMode = regenType.RegenAndCompile;
	}

	public void MergeWith(Triangle triangle)
	{
		MergeWith(triangle, weldNow: true);
	}

	internal static T _0023_003DzFPVyG4Y9TGyH<T>(IList<Point3D> _0023_003Dz_SqBXz8_003D, IList<IList<Point3D>> _0023_003DzWaFlkhfmYCja, Vector3D _0023_003DzYNjcavt9guh2, bool _0023_003Dz5q1w0P79Gecn, natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D) where T : Mesh, new()
	{
		return _0023_003DzfMf8mEeGF_Z4ri7PeA_003D_003D<T>(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzYNjcavt9guh2, _0023_003Dz5q1w0P79Gecn, _0023_003Dz5q1w0P79Gecn, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
	}

	internal static T _0023_003DzFPVyG4Y9TGyH<T>(ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, Vector3D _0023_003DzYNjcavt9guh2, bool _0023_003Dz5q1w0P79Gecn, bool _0023_003DzoU94611OyOjnISw50Q_003D_003D, natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, out int _0023_003DzE8d_nHmRn3TvqI_euBbFoJw_003D, out int[] _0023_003DzBo_0024WMFcRxbjB2DsnsM0uBPo_003D) where T : Mesh, new()
	{
		Utility._0023_003Dz5qFihJK3ui08U0cFuA_003D_003D(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, out var _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out var _0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D);
		_0023_003DzE8d_nHmRn3TvqI_euBbFoJw_003D = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count;
		_0023_003DzBo_0024WMFcRxbjB2DsnsM0uBPo_003D = new int[_0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D.Count];
		for (int i = 0; i < _0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D.Count; i++)
		{
			IList<Point3D> list = _0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D[i];
			_0023_003DzBo_0024WMFcRxbjB2DsnsM0uBPo_003D[i] = list.Count;
		}
		return _0023_003DzfMf8mEeGF_Z4ri7PeA_003D_003D<T>(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D, _0023_003DzYNjcavt9guh2, _0023_003Dz5q1w0P79Gecn, _0023_003DzoU94611OyOjnISw50Q_003D_003D, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
	}

	private static M _0023_003DzfMf8mEeGF_Z4ri7PeA_003D_003D<M>(IList<Point3D> _0023_003Dz_SqBXz8_003D, IList<IList<Point3D>> _0023_003DzWaFlkhfmYCja, Vector3D _0023_003DzYNjcavt9guh2, bool _0023_003DzbErHvVw_003D, bool _0023_003DzoU94611OyOjnISw50Q_003D_003D, natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D) where M : Mesh, new()
	{
		M val = null;
		bool flag = false;
		if (Utility.IsClosedProfile(_0023_003Dz_SqBXz8_003D) && _0023_003DzoU94611OyOjnISw50Q_003D_003D)
		{
			val = CreatePlanar<M>(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
			flag = val != null && Utility._0023_003DzORMVE0Xmd0DtzbF76UFKV_0024E_00240xze8ka1xgCJQIc_003D(val._triangles, val._vertices, _0023_003DzYNjcavt9guh2);
			flag = !flag;
		}
		else if (_0023_003DzbErHvVw_003D)
		{
			throw new EyeshotException(_0023_003DzCRupKJbhwyN62YPt8Q_003D_003D);
		}
		if (_0023_003DzbErHvVw_003D)
		{
			if (val != null)
			{
				if (flag)
				{
					Utility.FlipTriangles(val._triangles);
				}
				val._0023_003DzW_hgTMMRD8msOf_0024FYw_003D_003D(_0023_003DzYNjcavt9guh2, _0023_003Dz6psnhQEjSaf8: true, _0023_003DzoU94611OyOjnISw50Q_003D_003D: true);
			}
		}
		else
		{
			val = _0023_003Dz0W_00243aInLje6S34YOiw_003D_003D<M>(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzYNjcavt9guh2, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, _0023_003DzbUVjv_0024_0024ncGq6: false);
			if (flag)
			{
				Utility.FlipTriangles(val._triangles);
			}
		}
		return val;
	}

	private static M _0023_003Dz0W_00243aInLje6S34YOiw_003D_003D<M>(IList<Point3D> _0023_003Dz_SqBXz8_003D, IList<IList<Point3D>> _0023_003DzWaFlkhfmYCja, Vector3D _0023_003DzYNjcavt9guh2, natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, bool _0023_003DzbUVjv_0024_0024ncGq6) where M : Mesh, new()
	{
		M val = new M();
		val._0023_003DztGdcVOA_003D(_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, edgeStyleType.Sharp);
		_0023_003Dz4Uc8QrY0s26CYBs9aQ_003D_003D(_0023_003Dz_SqBXz8_003D, _0023_003DzYNjcavt9guh2, out val._vertices, out val._triangles, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
		if (_0023_003DzWaFlkhfmYCja != null)
		{
			Point3D[][] array = new Point3D[_0023_003DzWaFlkhfmYCja.Count + 1][];
			IndexTriangle[][] array2 = new IndexTriangle[_0023_003DzWaFlkhfmYCja.Count + 1][];
			array[0] = val._vertices;
			array2[0] = val._triangles;
			for (int i = 0; i < _0023_003DzWaFlkhfmYCja.Count; i++)
			{
				_0023_003Dz4Uc8QrY0s26CYBs9aQ_003D_003D(_0023_003DzWaFlkhfmYCja[i], _0023_003DzYNjcavt9guh2, out array[i + 1], out array2[i + 1], _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
			}
			_0023_003DzzyVeZ2JpkYXhOQrH90swHab1jKJWHKtJCQ_003D_003D(array, array2, out val._vertices, out val._triangles, _0023_003DzgM38qBg_003D: false);
		}
		return val;
	}

	private static void _0023_003Dz4Uc8QrY0s26CYBs9aQ_003D_003D(IList<Point3D> _0023_003DzCRq4LBU_003D, Vector3D _0023_003DzYNjcavt9guh2, out Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out IndexTriangle[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D)
	{
		_0023_003Dz0W_00243aInLje6S34YOiw_003D_003D(_0023_003DzCRq4LBU_003D, _0023_003DzYNjcavt9guh2, Utility.IsClosedProfile(_0023_003DzCRq4LBU_003D), out _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
	}

	public void ExtrudePlanar(Vector3D amount)
	{
		if (IsClosed)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972887));
		}
		if (LightWeight)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972845));
		}
		_0023_003DzW_hgTMMRD8msOf_0024FYw_003D_003D(amount, _0023_003Dz6psnhQEjSaf8: true, _0023_003DzoU94611OyOjnISw50Q_003D_003D: true);
	}

	public void ExtrudePlanar(double dx, double dy, double dz)
	{
		ExtrudePlanar(new Vector3D(dx, dy, dz));
	}

	internal void _0023_003DzW_hgTMMRD8msOf_0024FYw_003D_003D(Vector3D _0023_003DzYNjcavt9guh2, bool _0023_003Dz6psnhQEjSaf8, bool _0023_003DzoU94611OyOjnISw50Q_003D_003D)
	{
		int num = _vertices.Length;
		int num2 = _triangles.Length;
		Array.Resize(ref _vertices, num * 2);
		for (int i = num; i < num * 2; i++)
		{
			_vertices[i] = Utility.CreateVertex(_meshNature, _vertices[i - num].X + _0023_003DzYNjcavt9guh2.X, _vertices[i - num].Y + _0023_003DzYNjcavt9guh2.Y, _vertices[i - num].Z + _0023_003DzYNjcavt9guh2.Z);
		}
		IndexLine[] array = _0023_003Dz2XmFBkdx7sUs(_triangles, _0023_003DzOwwECpkmwVeA: true);
		int num3 = ((!_0023_003Dz6psnhQEjSaf8) ? 1 : 2);
		int newSize = num2 * num3 + array.Length * 2;
		Array.Resize(ref _triangles, newSize);
		int _0023_003Dzfsn580w_003D = num2;
		IndexLine[] array2 = array;
		foreach (IndexLine indexLine in array2)
		{
			_0023_003Dz1M62XEYsCzEl0o13yuMSy4E_003D(_triangles, _meshNature, indexLine.V1, indexLine.V2, 0, 1, num, ref _0023_003Dzfsn580w_003D);
		}
		if (_0023_003Dz6psnhQEjSaf8)
		{
			for (int k = 0; k < num2; k++)
			{
				IndexTriangle indexTriangle = _triangles[k];
				_triangles[_0023_003Dzfsn580w_003D++] = Utility.CreateTriangle(_meshNature, indexTriangle.V1 + num, indexTriangle.V3 + num, indexTriangle.V2 + num);
			}
		}
		if (_0023_003DzoU94611OyOjnISw50Q_003D_003D && Utility._0023_003DzORMVE0Xmd0DtzbF76UFKV_0024E_00240xze8ka1xgCJQIc_003D(_triangles, _vertices, _0023_003DzYNjcavt9guh2))
		{
			FlipNormal();
		}
		_normals = null;
		_edges = null;
		if (EdgeStyle == edgeStyleType.Free)
		{
			_edgeStyle = edgeStyleType.Sharp;
		}
		RegenMode = regenType.RegenAndCompile;
	}

	internal static void _0023_003Dz0W_00243aInLje6S34YOiw_003D_003D(IList<Point3D> _0023_003DzrdSL0CI_003D, Vector3D _0023_003DzYNjcavt9guh2, bool _0023_003DzbErHvVw_003D, out Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out IndexTriangle[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D)
	{
		int num = (_0023_003DzbErHvVw_003D ? (_0023_003DzrdSL0CI_003D.Count - 1) : _0023_003DzrdSL0CI_003D.Count);
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new Point3D[num * 2];
		for (int i = 0; i < num; i++)
		{
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i] = _0023_003DzrdSL0CI_003D[i];
		}
		for (int j = 0; j < num; j++)
		{
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[j + num] = Utility.CreateVertex(_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, _0023_003DzrdSL0CI_003D[j].X + _0023_003DzYNjcavt9guh2.X, _0023_003DzrdSL0CI_003D[j].Y + _0023_003DzYNjcavt9guh2.Y, _0023_003DzrdSL0CI_003D[j].Z + _0023_003DzYNjcavt9guh2.Z);
		}
		int num2 = (_0023_003DzrdSL0CI_003D.Count - 1) * 2;
		_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D = new IndexTriangle[num2];
		int _0023_003Dzfsn580w_003D = 0;
		for (int k = 0; k < _0023_003DzrdSL0CI_003D.Count - 1; k++)
		{
			int num3 = k % num;
			int _0023_003DzTnQvLOA_003D = (num3 + 1) % num;
			_0023_003Dz1M62XEYsCzEl0o13yuMSy4E_003D(_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, num3, _0023_003DzTnQvLOA_003D, 1, 0, num, ref _0023_003Dzfsn580w_003D);
		}
	}

	private static void _0023_003DzzyVeZ2JpkYXhOQrH90swHab1jKJWHKtJCQ_003D_003D(IList<IList<Point3D>> _0023_003Dz5MUxwOOGhUG1fE_2cQ_003D_003D, IList<IList<IndexTriangle>> _0023_003DzXh7_0024TClzkDWn4zdlZ1kHIzk_003D, out Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out IndexTriangle[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, bool _0023_003DzgM38qBg_003D)
	{
		int num = _0023_003Dz5MUxwOOGhUG1fE_2cQ_003D_003D[0].Count;
		int num2 = _0023_003DzXh7_0024TClzkDWn4zdlZ1kHIzk_003D[0].Count;
		for (int i = 1; i < _0023_003Dz5MUxwOOGhUG1fE_2cQ_003D_003D.Count; i++)
		{
			if (_0023_003DzgM38qBg_003D)
			{
				for (int j = 0; j < _0023_003DzXh7_0024TClzkDWn4zdlZ1kHIzk_003D[i].Count; j++)
				{
					IndexTriangle indexTriangle = _0023_003DzXh7_0024TClzkDWn4zdlZ1kHIzk_003D[i][j];
					_0023_003DzXh7_0024TClzkDWn4zdlZ1kHIzk_003D[i][j] = new IndexTriangle(indexTriangle.V1 + num, indexTriangle.V2 + num, indexTriangle.V3 + num);
				}
			}
			else
			{
				foreach (IndexTriangle item in _0023_003DzXh7_0024TClzkDWn4zdlZ1kHIzk_003D[i])
				{
					item.V1 += num;
					item.V2 += num;
					item.V3 += num;
				}
			}
			num += _0023_003Dz5MUxwOOGhUG1fE_2cQ_003D_003D[i].Count;
			num2 += _0023_003DzXh7_0024TClzkDWn4zdlZ1kHIzk_003D[i].Count;
		}
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new Point3D[num];
		_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D = new IndexTriangle[num2];
		int num3 = 0;
		int num4 = 0;
		for (int k = 0; k < _0023_003Dz5MUxwOOGhUG1fE_2cQ_003D_003D.Count; k++)
		{
			for (int l = 0; l < _0023_003Dz5MUxwOOGhUG1fE_2cQ_003D_003D[k].Count; l++)
			{
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num3++] = _0023_003Dz5MUxwOOGhUG1fE_2cQ_003D_003D[k][l];
			}
			for (int m = 0; m < _0023_003DzXh7_0024TClzkDWn4zdlZ1kHIzk_003D[k].Count; m++)
			{
				_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[num4++] = _0023_003DzXh7_0024TClzkDWn4zdlZ1kHIzk_003D[k][m];
			}
		}
		int index = _0023_003Dz5MUxwOOGhUG1fE_2cQ_003D_003D.Count - 1;
		for (int n = _0023_003Dz5MUxwOOGhUG1fE_2cQ_003D_003D[index].Count; n < _0023_003Dz5MUxwOOGhUG1fE_2cQ_003D_003D[index].Count; n++)
		{
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num3++] = _0023_003Dz5MUxwOOGhUG1fE_2cQ_003D_003D[index][n];
		}
	}

	internal static Mesh _0023_003DzZsKpvYbXHCDE(IList<Point3D> _0023_003Dz_SqBXz8_003D, double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, int _0023_003DzAPBIJmvn5i5Q, bool _0023_003Dz5q1w0P79Gecn, natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D)
	{
		return _0023_003DzZsKpvYbXHCDE<Mesh>(_0023_003Dz_SqBXz8_003D, _0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003Dz5q1w0P79Gecn, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
	}

	internal static T _0023_003DzZsKpvYbXHCDE<T>(IList<Point3D> _0023_003Dz_SqBXz8_003D, double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, int _0023_003DzAPBIJmvn5i5Q, bool _0023_003Dz5q1w0P79Gecn, natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D) where T : Mesh, new()
	{
		return _0023_003DzZsKpvYbXHCDE<T>(_0023_003Dz_SqBXz8_003D, null, _0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003Dz5q1w0P79Gecn, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
	}

	internal static T _0023_003DzZsKpvYbXHCDE<T>(IList<Point3D> _0023_003Dz_SqBXz8_003D, IList<IList<Point3D>> _0023_003DzWaFlkhfmYCja, double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, int _0023_003DzAPBIJmvn5i5Q, bool _0023_003Dz5q1w0P79Gecn, natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D) where T : Mesh, new()
	{
		bool _0023_003DzJlv_CuAUfJRQ = Utility._0023_003DzSOQm2JeuhlBjZ46sDLoENc_0024rSbvZ(_0023_003Dz_SqBXz8_003D, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003Dz5q1w0P79Gecn);
		return _0023_003Dz_zLhQ7UUHrThF4tt5A_003D_003D<T>(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003Dz5q1w0P79Gecn, _0023_003DzJlv_CuAUfJRQ, _0023_003Dz5q1w0P79Gecn, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
	}

	internal static Mesh _0023_003DzZsKpvYbXHCDE(ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, int _0023_003DzAPBIJmvn5i5Q, bool _0023_003Dz5q1w0P79Gecn, natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D)
	{
		return _0023_003DzZsKpvYbXHCDE<Mesh>(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003Dz5q1w0P79Gecn, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
	}

	internal static T _0023_003DzZsKpvYbXHCDE<T>(ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, int _0023_003DzAPBIJmvn5i5Q, bool _0023_003Dz5q1w0P79Gecn, natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D) where T : Mesh, new()
	{
		Utility._0023_003Dz0U2l9p_0024wMUWMI2xPGxvwVTCSGwVr(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, out var _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out var _0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D, out var _0023_003DzJlv_CuAUfJRQ, _0023_003Dz5q1w0P79Gecn);
		return _0023_003Dz_zLhQ7UUHrThF4tt5A_003D_003D<T>(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D, _0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003Dz5q1w0P79Gecn, _0023_003DzJlv_CuAUfJRQ, _0023_003Dz5q1w0P79Gecn, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
	}

	internal static T _0023_003DzZsKpvYbXHCDE<T>(Region _0023_003Dz7revxoQ_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, int _0023_003DzAPBIJmvn5i5Q, natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D) where T : Mesh, new()
	{
		_0023_003Dz7revxoQ_003D._0023_003DzWFzsryZTA1I_JcqmPg_mY3Wl4l5L(out var _0023_003Dz_SqBXz8_003D, out var _0023_003DzWaFlkhfmYCja);
		return _0023_003DzZsKpvYbXHCDE<T>(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003Dz5q1w0P79Gecn: true, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
	}

	public void RevolvePlanar(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, natureType natureType)
	{
		if (IsClosed)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972887));
		}
		if (LightWeight)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972845));
		}
		_0023_003DzsWEtP9hND0Sx_0024oAjZQ_003D_003D(_vertices, startAngle, deltaAngle, axis, center, slices, _0023_003DzbErHvVw_003D: true, natureType);
	}

	internal static M _0023_003Dz_zLhQ7UUHrThF4tt5A_003D_003D<M>(IList<Point3D> _0023_003Dz_SqBXz8_003D, IList<IList<Point3D>> _0023_003DzWaFlkhfmYCja, double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, int _0023_003DzAPBIJmvn5i5Q, bool _0023_003DzbErHvVw_003D, bool _0023_003DzJlv_CuAUfJRQ, bool _0023_003DzEt2Zcy_TSPx_0024, natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D) where M : Mesh, new()
	{
		bool flag = Math.Abs(_0023_003DzFINJ6s3Z_0024n8G) >= Math.PI * 2.0;
		IList<Point3D> list = _0023_003Dz_SqBXz8_003D;
		if (_0023_003DzbErHvVw_003D && !flag && _0023_003Dz_SqBXz8_003D[0] != _0023_003Dz_SqBXz8_003D[_0023_003Dz_SqBXz8_003D.Count - 1] && _0023_003DzJlv_CuAUfJRQ)
		{
			list = _0023_003DzTz2BUzNxCKpM(_0023_003Dz_SqBXz8_003D);
		}
		M val = null;
		bool flag2 = false;
		if (Utility.IsClosedProfile(list) && _0023_003DzEt2Zcy_TSPx_0024)
		{
			val = CreatePlanar<M>(list, _0023_003DzWaFlkhfmYCja, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
			if (val != null)
			{
				flag2 = Utility._0023_003DzWU235rVAR0aSlJTfp4IMM8ikjdbN(val._triangles, val._vertices, val._vertices.Length, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D);
			}
		}
		if (_0023_003DzbErHvVw_003D && !flag)
		{
			if (val != null)
			{
				if (flag2)
				{
					Utility.FlipTriangles(val._triangles);
				}
				val._0023_003DzsWEtP9hND0Sx_0024oAjZQ_003D_003D(val._vertices, _0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003DzbErHvVw_003D, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
				val.RegenMode = regenType.RegenAndCompile;
			}
		}
		else
		{
			val = _0023_003Dz9lRzhvnitNBcjyl5WA_003D_003D<M>(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
			if (flag2)
			{
				Utility.FlipTriangles(val._triangles);
			}
		}
		if (_0023_003DzJlv_CuAUfJRQ)
		{
			val?.Weld();
		}
		return val;
	}

	private static IList<T> _0023_003DzTz2BUzNxCKpM<T>(IList<T> _0023_003DzCRq4LBU_003D) where T : Point2D
	{
		List<T> list = new List<T>(_0023_003DzCRq4LBU_003D.Count + 1);
		for (int i = 0; i < _0023_003DzCRq4LBU_003D.Count; i++)
		{
			list.Add(_0023_003DzCRq4LBU_003D[i]);
		}
		list.Add(_0023_003DzCRq4LBU_003D[0]);
		return list;
	}

	private static M _0023_003Dz9lRzhvnitNBcjyl5WA_003D_003D<M>(IList<Point3D> _0023_003Dz_SqBXz8_003D, IList<IList<Point3D>> _0023_003DzWaFlkhfmYCja, double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, int _0023_003DzAPBIJmvn5i5Q, natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D) where M : Mesh, new()
	{
		M val = new M();
		val._0023_003DztGdcVOA_003D(_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, edgeStyleType.Sharp);
		_0023_003Dz4qJpAXgh7qi6v0solA_003D_003D(_0023_003Dz_SqBXz8_003D, _0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzAPBIJmvn5i5Q, out val._vertices, out val._triangles, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
		if (_0023_003DzWaFlkhfmYCja != null)
		{
			Point3D[][] array = new Point3D[_0023_003DzWaFlkhfmYCja.Count + 1][];
			IndexTriangle[][] array2 = new IndexTriangle[_0023_003DzWaFlkhfmYCja.Count + 1][];
			array[0] = val._vertices;
			array2[0] = val._triangles;
			for (int i = 0; i < _0023_003DzWaFlkhfmYCja.Count; i++)
			{
				_0023_003Dz4qJpAXgh7qi6v0solA_003D_003D(_0023_003DzWaFlkhfmYCja[i], _0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzAPBIJmvn5i5Q, out array[i + 1], out array2[i + 1], _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
			}
			_0023_003DzzyVeZ2JpkYXhOQrH90swHab1jKJWHKtJCQ_003D_003D(array, array2, out val._vertices, out val._triangles, _0023_003DzgM38qBg_003D: false);
		}
		return val;
	}

	private static void _0023_003Dz4qJpAXgh7qi6v0solA_003D_003D(IList<Point3D> _0023_003DzCRq4LBU_003D, double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, int _0023_003DzAPBIJmvn5i5Q, out Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out IndexTriangle[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D)
	{
		bool _0023_003DzTQkGLL3JF1_U = Utility.IsClosedProfile(_0023_003DzCRq4LBU_003D);
		_0023_003Dz9lRzhvnitNBcjyl5WA_003D_003D(_0023_003DzCRq4LBU_003D, _0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003DzTQkGLL3JF1_U, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, out _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D);
	}

	private void _0023_003DzsWEtP9hND0Sx_0024oAjZQ_003D_003D(IList<Point3D> _0023_003DzCRq4LBU_003D, double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, int _0023_003DzAPBIJmvn5i5Q, bool _0023_003DzbErHvVw_003D, natureType _0023_003DzSndGNmrfbYVbQxkK4A_003D_003D)
	{
		int count = _0023_003DzCRq4LBU_003D.Count;
		int num = ((_triangles != null) ? _triangles.Length : 0);
		int _0023_003Dz_0024uptvCQ_003D = _0023_003DzAPBIJmvn5i5Q + 1;
		_vertices = _0023_003DzDHrk2Rkt7Md0NVVAzTZtVMKO_RTR(_0023_003DzCRq4LBU_003D, _0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzAPBIJmvn5i5Q, count, _0023_003Dz_0024uptvCQ_003D, _0023_003DzSndGNmrfbYVbQxkK4A_003D_003D, _0023_003DzJOQp6USk1BRu: true);
		IndexLine[] array = _0023_003Dz2XmFBkdx7sUs(_triangles, _0023_003DzOwwECpkmwVeA: true);
		int num2 = ((!_0023_003DzbErHvVw_003D) ? 1 : 2);
		int newSize = num * num2 + array.Length * _0023_003DzAPBIJmvn5i5Q * 2;
		Array.Resize(ref _triangles, newSize);
		int _0023_003Dzfsn580w_003D = num;
		IndexLine[] array2 = array;
		foreach (IndexLine indexLine in array2)
		{
			for (int j = 0; j < _0023_003DzAPBIJmvn5i5Q; j++)
			{
				_0023_003Dz1M62XEYsCzEl0o13yuMSy4E_003D(_triangles, _0023_003DzSndGNmrfbYVbQxkK4A_003D_003D, indexLine.V1, indexLine.V2, j, j + 1, count, ref _0023_003Dzfsn580w_003D);
			}
		}
		if (_0023_003DzbErHvVw_003D)
		{
			for (int k = 0; k < num; k++)
			{
				IndexTriangle indexTriangle = _triangles[k];
				_triangles[_0023_003Dzfsn580w_003D++] = Utility.CreateTriangle(_0023_003DzSndGNmrfbYVbQxkK4A_003D_003D, indexTriangle.V1 + _0023_003DzAPBIJmvn5i5Q * count, indexTriangle.V3 + _0023_003DzAPBIJmvn5i5Q * count, indexTriangle.V2 + _0023_003DzAPBIJmvn5i5Q * count);
			}
		}
		if (_0023_003DzbErHvVw_003D)
		{
			FlipOutward();
		}
	}

	internal static void _0023_003Dz9lRzhvnitNBcjyl5WA_003D_003D(IList<Point3D> _0023_003DzCRq4LBU_003D, double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, int _0023_003DzAPBIJmvn5i5Q, bool _0023_003DzTQkGLL3JF1_U, natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, out Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out IndexTriangle[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D)
	{
		bool num = Math.Abs(_0023_003DzFINJ6s3Z_0024n8G) >= Math.PI * 2.0;
		int num2 = (_0023_003DzTQkGLL3JF1_U ? (_0023_003DzCRq4LBU_003D.Count - 1) : _0023_003DzCRq4LBU_003D.Count);
		int num3 = (num ? _0023_003DzAPBIJmvn5i5Q : (_0023_003DzAPBIJmvn5i5Q + 1));
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = _0023_003DzDHrk2Rkt7Md0NVVAzTZtVMKO_RTR(_0023_003DzCRq4LBU_003D, _0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzAPBIJmvn5i5Q, num2, num3, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, _0023_003DzJOQp6USk1BRu: false);
		int num4 = (_0023_003DzCRq4LBU_003D.Count - 1) * _0023_003DzAPBIJmvn5i5Q * 2;
		_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D = new IndexTriangle[num4];
		int _0023_003Dzfsn580w_003D = 0;
		int num5 = (num ? num3 : (num3 - 1));
		for (int i = 0; i < num5; i++)
		{
			int _0023_003DzUW_0024rEUk_003D = (i + 1) % num3;
			for (int j = 0; j < _0023_003DzCRq4LBU_003D.Count - 1; j++)
			{
				int num6 = j % num2;
				int _0023_003DzTnQvLOA_003D = (num6 + 1) % num2;
				_0023_003Dz1M62XEYsCzEl0o13yuMSy4E_003D(_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, num6, _0023_003DzTnQvLOA_003D, i, _0023_003DzUW_0024rEUk_003D, num2, ref _0023_003Dzfsn580w_003D);
			}
		}
	}

	internal static Point3D[] _0023_003DzDHrk2Rkt7Md0NVVAzTZtVMKO_RTR(IList<Point3D> _0023_003DzCRq4LBU_003D, double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, int _0023_003DzAPBIJmvn5i5Q, int _0023_003Dz7EPZNsQ_003D, int _0023_003Dz_0024uptvCQ_003D, natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, bool _0023_003DzJOQp6USk1BRu)
	{
		Interval interval = Utility.FixRevAngle(_0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G);
		Point3D[] array = new Point3D[_0023_003Dz7EPZNsQ_003D * _0023_003Dz_0024uptvCQ_003D];
		for (int i = 0; i < _0023_003Dz7EPZNsQ_003D; i++)
		{
			array[i] = _0023_003DzCRq4LBU_003D[i];
		}
		_0023_003DzxuJqjrs_003D.Normalize();
		int num = _0023_003DzAPBIJmvn5i5Q + 1;
		double[] array2 = new double[num];
		double[] array3 = new double[num];
		double num2 = interval.Min;
		double num3 = interval.Length / (double)_0023_003DzAPBIJmvn5i5Q;
		for (int j = 0; j < _0023_003Dz_0024uptvCQ_003D; j++)
		{
			array2[j] = Math.Cos(num2);
			array3[j] = Math.Sin(num2);
			num2 += num3;
		}
		Segment3D seg = new Segment3D(_0023_003DzbUvT9Pc_003D, _0023_003DzbUvT9Pc_003D + _0023_003DzxuJqjrs_003D);
		int num4 = ((_0023_003DzJOQp6USk1BRu && interval.Min == 0.0) ? 1 : 0);
		for (int k = 0; k < _0023_003Dz7EPZNsQ_003D; k++)
		{
			Point3D point3D = array[k];
			Point3D point3D2 = point3D.ProjectTo(seg);
			Vector3D vector3D = Vector3D.Subtract(point3D, point3D2);
			double length = vector3D.Length;
			if (length > 0.0)
			{
				vector3D.Normalize();
			}
			else
			{
				vector3D.Zero();
			}
			Vector3D vector3D2 = Vector3D.Cross(_0023_003DzxuJqjrs_003D, vector3D);
			for (int l = num4; l < _0023_003Dz_0024uptvCQ_003D; l++)
			{
				int num5 = l * _0023_003Dz7EPZNsQ_003D + k;
				array[num5] = Utility.CreateVertex(_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, point3D2.X + length * array2[l] * vector3D.X + length * array3[l] * vector3D2.X, point3D2.Y + length * array2[l] * vector3D.Y + length * array3[l] * vector3D2.Y, point3D2.Z + length * array2[l] * vector3D.Z + length * array3[l] * vector3D2.Z);
			}
		}
		return array;
	}

	internal static void _0023_003Dz1M62XEYsCzEl0o13yuMSy4E_003D(IndexTriangle[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, int _0023_003DzOeA7xak_003D, int _0023_003DzTnQvLOA_003D, int _0023_003DzLmdZcgY_003D, int _0023_003DzUW_0024rEUk_003D, int _0023_003Dz7EPZNsQ_003D, ref int _0023_003Dzfsn580w_003D)
	{
		_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[_0023_003Dzfsn580w_003D++] = Utility.CreateTriangle(_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, _0023_003DzOeA7xak_003D + _0023_003DzLmdZcgY_003D * _0023_003Dz7EPZNsQ_003D, _0023_003DzTnQvLOA_003D + _0023_003DzUW_0024rEUk_003D * _0023_003Dz7EPZNsQ_003D, _0023_003DzTnQvLOA_003D + _0023_003DzLmdZcgY_003D * _0023_003Dz7EPZNsQ_003D);
		_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[_0023_003Dzfsn580w_003D++] = Utility.CreateTriangle(_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, _0023_003DzOeA7xak_003D + _0023_003DzLmdZcgY_003D * _0023_003Dz7EPZNsQ_003D, _0023_003DzOeA7xak_003D + _0023_003DzUW_0024rEUk_003D * _0023_003Dz7EPZNsQ_003D, _0023_003DzTnQvLOA_003D + _0023_003DzUW_0024rEUk_003D * _0023_003Dz7EPZNsQ_003D);
	}

	public static Mesh CreateSphere(double radius, int slices, int stacks)
	{
		return CreateSphere<Mesh>(radius, slices, stacks);
	}

	public static Mesh CreateSphere(double radius, int slices, int stacks, natureType meshNature)
	{
		return CreateSphere<Mesh>(radius, slices, stacks, meshNature);
	}

	public static T CreateSphere<T>(double radius, int slices, int stacks) where T : Mesh, new()
	{
		return CreateSphere<T>(radius, slices, stacks, natureType.Smooth);
	}

	public static T CreateSphere<T>(double radius, int slices, int stacks, natureType meshNature) where T : Mesh, new()
	{
		T val = new T();
		val._0023_003DztGdcVOA_003D(meshNature, edgeStyleType.None);
		if (!val._0023_003DzC5qPhnJid0UhWtH6kA_003D_003D(radius, slices, stacks))
		{
			throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971518));
		}
		val.UpdateBoundingBox(null);
		val.RegenMode = regenType.CompileOnly;
		return val;
	}

	internal bool _0023_003DzC5qPhnJid0UhWtH6kA_003D_003D(double _0023_003DzEGKj_0024SNUUihi, int _0023_003DzAPBIJmvn5i5Q, int _0023_003DzuIAtZKFfL18G)
	{
		if (_0023_003DzEGKj_0024SNUUihi < Utility._0023_003DzheSR8QM7q9ya || _0023_003DzAPBIJmvn5i5Q < 3 || _0023_003DzuIAtZKFfL18G < 2)
		{
			return false;
		}
		bool flag = true;
		natureType meshNature = _meshNature;
		if (meshNature - 1 <= natureType.MulticolorPlain)
		{
			flag = false;
		}
		Utility.CreateSphere(_meshNature, _0023_003DzEGKj_0024SNUUihi, _0023_003DzAPBIJmvn5i5Q, _0023_003DzuIAtZKFfL18G, flag, computeTextureCoords: false, out _vertices, out _triangles, out _normals, out var _);
		if (!flag)
		{
			UpdateNormals();
		}
		return true;
	}

	internal static T[] _0023_003Dz1A9iP9WIToC5<T>(ICurve _0023_003DzHgrHIfhYCh4p, ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, double _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, bool _0023_003DzbErHvVw_003D, sweepMethodType _0023_003Dzjy_YX_0024o_003D, natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, bool _0023_003DzjepEGXc_003D) where T : Mesh, new()
	{
		Utility._0023_003DzDE7mL_712NEZeE5wpw_003D_003D(_0023_003Dz_SqBXz8_003D, _0023_003DzHgrHIfhYCh4p, _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, _0023_003DzbErHvVw_003D, _0023_003DzGb8kdyZ1x5nj: false);
		if (_0023_003DzWaFlkhfmYCja != null)
		{
			foreach (ICurve item in _0023_003DzWaFlkhfmYCja)
			{
				Utility._0023_003DzDE7mL_712NEZeE5wpw_003D_003D(item, _0023_003DzHgrHIfhYCh4p, _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, _0023_003DzbErHvVw_003D, _0023_003DzGb8kdyZ1x5nj: false);
			}
		}
		Utility._0023_003Dzdh_4OQddxCSDDYZ27Q_003D_003D(_0023_003DzHgrHIfhYCh4p, _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, _0023_003DzFSLBkBecx_0024NX: true, out var _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D, _0023_003Dz6SBnzmNnw6lO: false);
		bool flag = _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D[0].StartPoint == _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D[^1].EndPoint;
		bool flag2 = !flag && _0023_003DzbErHvVw_003D;
		bool flag3 = !_0023_003DzjepEGXc_003D && _0023_003DzbErHvVw_003D;
		T[] array = ((flag2 && _0023_003DzjepEGXc_003D) ? new T[_0023_003DzmO_0024kvb27FfjoVav64A_003D_003D.Length + 2] : new T[_0023_003DzmO_0024kvb27FfjoVav64A_003D_003D.Length]);
		double _0023_003DzC5YR9r5C06bj = Utility._0023_003DzgP4qC37WNH1g(_0023_003Dz_SqBXz8_003D);
		ICurve curve = (ICurve)_0023_003Dz_SqBXz8_003D.Clone();
		ICurve[] array2 = null;
		if (_0023_003DzWaFlkhfmYCja != null)
		{
			array2 = new ICurve[_0023_003DzWaFlkhfmYCja.Count];
			for (int i = 0; i < _0023_003DzWaFlkhfmYCja.Count; i++)
			{
				array2[i] = (ICurve)_0023_003DzWaFlkhfmYCja[i].Clone();
			}
		}
		Plane _0023_003DzStUznlUnGSG = null;
		if (flag2 && !flag3)
		{
			T val = _0023_003DzdkFbg3fdF92xAt0JuQ_003D_003D<T>(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
			if (Utility._0023_003DzORMVE0Xmd0DtzbF76UFKV_0024E_00240xze8ka1xgCJQIc_003D(val._triangles, val._vertices, _0023_003DzHgrHIfhYCh4p.StartTangent))
			{
				val.FlipNormal();
			}
			array[0] = val;
		}
		for (int j = 0; j < _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D.Length; j++)
		{
			ICurve curve2 = _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D[j];
			T val2 = null;
			if (curve2 is Line)
			{
				val2 = _0023_003DzdncxQYEu8hc00O7aiw_003D_003D<T>(_0023_003DzmO_0024kvb27FfjoVav64A_003D_003D, j, curve, array2, _0023_003DzC5YR9r5C06bj, _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, _0023_003DzbErHvVw_003D, flag, flag3, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
			}
			else if (curve2 is Circle)
			{
				val2 = _0023_003DzRLbt9uDCT0W7yo59pg_003D_003D<T>(_0023_003DzmO_0024kvb27FfjoVav64A_003D_003D, j, curve, array2, _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, _0023_003DzbErHvVw_003D, flag, flag3, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
			}
			else if (curve2 is Curve)
			{
				val2 = _0023_003DzriHaSLBwtW75<T>(_0023_003DzmO_0024kvb27FfjoVav64A_003D_003D, j, curve, array2, _0023_003DzC5YR9r5C06bj, _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, _0023_003DzbErHvVw_003D, flag, flag3, _0023_003Dzjy_YX_0024o_003D, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
			}
			ICurve _0023_003DzHXbzvx8ZY9nt = null;
			if (j + 1 < _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D.Length)
			{
				_0023_003DzHXbzvx8ZY9nt = _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D[j + 1];
			}
			if (array2 != null)
			{
				for (int k = 0; k < array2.Length; k++)
				{
					Utility._0023_003DzUF5dE52DL3PQ(array2[k], curve2, _0023_003DzHXbzvx8ZY9nt, ref _0023_003DzStUznlUnGSG, _0023_003Dzjy_YX_0024o_003D, _0023_003Dz3fpuiiI_003D: false);
				}
			}
			Utility._0023_003DzUF5dE52DL3PQ(curve, curve2, _0023_003DzHXbzvx8ZY9nt, ref _0023_003DzStUznlUnGSG, _0023_003Dzjy_YX_0024o_003D, _0023_003Dz3fpuiiI_003D: true);
			if (val2 != null)
			{
				array[(flag2 && !flag3) ? (j + 1) : j] = val2;
			}
		}
		if (flag2 && !flag3)
		{
			T val3 = _0023_003DzdkFbg3fdF92xAt0JuQ_003D_003D<T>(curve, array2, _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
			Vector3D endTangent = _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D[^1].EndTangent;
			endTangent.Negate();
			if (Utility._0023_003DzORMVE0Xmd0DtzbF76UFKV_0024E_00240xze8ka1xgCJQIc_003D(val3.Triangles, val3._vertices, endTangent))
			{
				Utility.FlipTriangles(val3._triangles);
			}
			array[_0023_003DzmO_0024kvb27FfjoVav64A_003D_003D.Length + 1] = val3;
		}
		if (_0023_003DzjepEGXc_003D)
		{
			return new T[1] { _0023_003DzgLmLM40_003D(array) };
		}
		return array;
	}

	private static T _0023_003DzgLmLM40_003D<T>(T[] _0023_003DzIIuKCj1NK1q5) where T : Mesh, new()
	{
		T val = null;
		foreach (T val2 in _0023_003DzIIuKCj1NK1q5)
		{
			if (val2 != null)
			{
				if (val == null)
				{
					val = val2;
				}
				else
				{
					val.MergeWith(val2, weldNow: false, recomputeEdges: false);
				}
			}
		}
		if (val != null)
		{
			val.Edges = val._0023_003Dz2XmFBkdx7sUs(val.Triangles, _0023_003DzOwwECpkmwVeA: false);
			val.Weld();
		}
		return val;
	}

	private static T _0023_003DzriHaSLBwtW75<T>(ICurve[] _0023_003DzHgrHIfhYCh4p, int _0023_003Dz5C_0024cyD9lhEyKEXb3Cw_003D_003D, ICurve _0023_003Dz_SqBXz8_003D, ICurve[] _0023_003DzWaFlkhfmYCja, double _0023_003DzC5YR9r5C06bj, double _0023_003DzAqH9bgFsOafeqpSJ5A_003D_003D, bool _0023_003DzbErHvVw_003D, bool _0023_003DzHbb9s4FIaFfq, bool _0023_003DzcSSP_dM_003D, sweepMethodType _0023_003Dzjy_YX_0024o_003D, natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D) where T : Mesh, new()
	{
		Transformation[] array = new Transformation[2];
		Plane[] array2 = new Plane[2];
		Utility._0023_003Dz7b9TFrXd9rCVnRQEGAbz5MKjvMEiSWk3Sg_003D_003D(_0023_003DzHgrHIfhYCh4p, _0023_003Dz5C_0024cyD9lhEyKEXb3Cw_003D_003D, _0023_003DzC5YR9r5C06bj / 2.0, _0023_003DzHbb9s4FIaFfq, out array2[0], out array2[1], out array[0], out array[1]);
		T val = _0023_003DzFXb0cTg_003D<T>(_0023_003DzHgrHIfhYCh4p, _0023_003Dz5C_0024cyD9lhEyKEXb3Cw_003D_003D, _0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, array, _0023_003DzAqH9bgFsOafeqpSJ5A_003D_003D, _0023_003DzbErHvVw_003D, _0023_003DzcSSP_dM_003D, _0023_003Dzjy_YX_0024o_003D, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
		_0023_003Dz7mr_4Z4_003D(val, array2);
		return val;
	}

	internal static T _0023_003DzFXb0cTg_003D<T>(ICurve[] _0023_003DzHgrHIfhYCh4p, int _0023_003DzYnrMIDOkBgMJ, ICurve _0023_003Dz_SqBXz8_003D, ICurve[] _0023_003DzWaFlkhfmYCja, Transformation[] _0023_003Dzd6BosvE_003D, double _0023_003DzAqH9bgFsOafeqpSJ5A_003D_003D, bool _0023_003DzoU94611OyOjnISw50Q_003D_003D, bool _0023_003DzcSSP_dM_003D, sweepMethodType _0023_003Dzjy_YX_0024o_003D, natureType _0023_003Dzh6f3vSXPc_3fG6eqfA_003D_003D) where T : Mesh, new()
	{
		ICurve curve = (ICurve)_0023_003Dz_SqBXz8_003D.Clone();
		((Entity)curve).Regen(_0023_003DzAqH9bgFsOafeqpSJ5A_003D_003D);
		Plane[] array = Utility._0023_003DzZ9QiwSvQlgr8((Curve)_0023_003DzHgrHIfhYCh4p[_0023_003DzYnrMIDOkBgMJ], null, _0023_003Dzjy_YX_0024o_003D);
		int _0023_003DzztlQhuLq4X3L = (curve.IsClosed ? (((Entity)curve).Vertices.Length + 1) : ((Entity)curve).Vertices.Length);
		int num = array.Length;
		int num2 = 0;
		if (_0023_003Dzd6BosvE_003D[0] != null)
		{
			num2++;
		}
		if (_0023_003Dzd6BosvE_003D[1] != null)
		{
			num2++;
		}
		_0023_003DzuhEx72sbCtUmmTbdAg_003D_003D(_0023_003Dz_SqBXz8_003D, _0023_003Dzd6BosvE_003D[0], _0023_003Dzd6BosvE_003D[1], array, _0023_003DzAqH9bgFsOafeqpSJ5A_003D_003D, out var _0023_003DzJNrFsGPfoe3RoW4PHA_003D_003D);
		_0023_003DzrdLykJXeX_VScOxfBQ_003D_003D(_0023_003DzJNrFsGPfoe3RoW4PHA_003D_003D, _0023_003DzztlQhuLq4X3L, num + num2, _0023_003Dzh6f3vSXPc_3fG6eqfA_003D_003D, out var _0023_003DzVkrKg7m37l3bczXeWA_003D_003D);
		ICurve[] array2 = new ICurve[0];
		if (_0023_003DzWaFlkhfmYCja != null)
		{
			array2 = new ICurve[_0023_003DzWaFlkhfmYCja.Length];
			Point3D[][] array3 = new Point3D[_0023_003DzWaFlkhfmYCja.Length + 1][];
			IndexTriangle[][] array4 = new IndexTriangle[_0023_003DzWaFlkhfmYCja.Length + 1][];
			array3[0] = _0023_003DzJNrFsGPfoe3RoW4PHA_003D_003D;
			array4[0] = _0023_003DzVkrKg7m37l3bczXeWA_003D_003D;
			for (int i = 0; i < _0023_003DzWaFlkhfmYCja.Length; i++)
			{
				array2[i] = (ICurve)_0023_003DzWaFlkhfmYCja[i].Clone();
				((Entity)array2[i]).Regen(_0023_003DzAqH9bgFsOafeqpSJ5A_003D_003D);
				_0023_003DzuhEx72sbCtUmmTbdAg_003D_003D(_0023_003DzWaFlkhfmYCja[i], _0023_003Dzd6BosvE_003D[0], _0023_003Dzd6BosvE_003D[1], array, _0023_003DzAqH9bgFsOafeqpSJ5A_003D_003D, out array3[i + 1]);
				_0023_003DzrdLykJXeX_VScOxfBQ_003D_003D(array3[i + 1], ((Entity)array2[i]).Vertices.Length + 1, num + num2, _0023_003Dzh6f3vSXPc_3fG6eqfA_003D_003D, out array4[i + 1]);
			}
			_0023_003DzzyVeZ2JpkYXhOQrH90swHab1jKJWHKtJCQ_003D_003D(array3, array4, out _0023_003DzJNrFsGPfoe3RoW4PHA_003D_003D, out _0023_003DzVkrKg7m37l3bczXeWA_003D_003D, _0023_003DzgM38qBg_003D: false);
		}
		Utility._0023_003DzJNADeOQRO6_fPmN4Ig_003D_003D(_0023_003DzVkrKg7m37l3bczXeWA_003D_003D, null, _0023_003DzJNrFsGPfoe3RoW4PHA_003D_003D, out var _0023_003DzPSHPV1adgQcYEwqKXHGDJDXML8EU, out var _0023_003DzrnJjSihyGwPQqq_0024JUA_003D_003D, Utility._0023_003DzKN_0024vjGN5_0024fwYJSS8TN63qBo_003D(_0023_003DzJNrFsGPfoe3RoW4PHA_003D_003D), _0023_003Dz5syaaeMy5pLBOZfa4Kfhgq4_003D: true, _0023_003DzFwalihjMriJGyFaGGg_003D_003D: false);
		T val = new T
		{
			_triangles = _0023_003DzPSHPV1adgQcYEwqKXHGDJDXML8EU,
			_vertices = _0023_003DzrnJjSihyGwPQqq_0024JUA_003D_003D,
			_meshNature = _0023_003Dzh6f3vSXPc_3fG6eqfA_003D_003D
		};
		if (_0023_003Dz_SqBXz8_003D.IsClosed && _0023_003DzoU94611OyOjnISw50Q_003D_003D)
		{
			T val2 = _0023_003DzdkFbg3fdF92xAt0JuQ_003D_003D<T>(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzAqH9bgFsOafeqpSJ5A_003D_003D, _0023_003Dzh6f3vSXPc_3fG6eqfA_003D_003D);
			if (_0023_003DzcSSP_dM_003D)
			{
				if (_0023_003Dzd6BosvE_003D[0] != null)
				{
					val2.TransformBy(_0023_003Dzd6BosvE_003D[0]);
				}
				T val3 = _0023_003DzdkFbg3fdF92xAt0JuQ_003D_003D<T>(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzAqH9bgFsOafeqpSJ5A_003D_003D, _0023_003Dzh6f3vSXPc_3fG6eqfA_003D_003D);
				Transformation xform = new Align3D(array[0], array[^1]);
				if (_0023_003Dzd6BosvE_003D[1] != null)
				{
					xform *= _0023_003Dzd6BosvE_003D[1];
				}
				val3.TransformBy(xform);
				val = _0023_003DzgLmLM40_003D(new T[3] { val, val2, val3 });
			}
			if (val2 != null && !Utility._0023_003DzORMVE0Xmd0DtzbF76UFKV_0024E_00240xze8ka1xgCJQIc_003D(val2._triangles, val2._vertices, _0023_003DzHgrHIfhYCh4p[_0023_003DzYnrMIDOkBgMJ].StartTangent))
			{
				Utility.FlipTriangles(val._triangles);
			}
		}
		return val;
	}

	private static void _0023_003DzuhEx72sbCtUmmTbdAg_003D_003D(ICurve _0023_003DzGWdfTV4_003D, Transformation _0023_003DzmYM7oNE_003D, Transformation _0023_003Dz_Li6Rm0_003D, Plane[] _0023_003DzNR5lGJ4_003D, double _0023_003DzAqH9bgFsOafeqpSJ5A_003D_003D, out Point3D[] _0023_003DzJNrFsGPfoe3RoW4PHA_003D_003D)
	{
		Entity entity = (Entity)_0023_003DzGWdfTV4_003D.Clone();
		entity.Regen(_0023_003DzAqH9bgFsOafeqpSJ5A_003D_003D);
		int num = (((ICurve)entity).IsClosed ? (entity.Vertices.Length + 1) : entity.Vertices.Length);
		int num2 = _0023_003DzNR5lGJ4_003D.Length;
		int num3 = 0;
		int num4 = 0;
		if (_0023_003DzmYM7oNE_003D != null)
		{
			num4++;
		}
		if (_0023_003Dz_Li6Rm0_003D != null)
		{
			num4++;
		}
		_0023_003DzJNrFsGPfoe3RoW4PHA_003D_003D = new Point3D[num * (num2 + num4)];
		if (_0023_003DzmYM7oNE_003D != null)
		{
			ICurve curve = (ICurve)entity.Clone();
			((Entity)curve).TransformBy(_0023_003DzmYM7oNE_003D);
			((Entity)curve).Regen(_0023_003DzAqH9bgFsOafeqpSJ5A_003D_003D);
			num3++;
			for (int i = 0; i < num; i++)
			{
				if (!curve.IsClosed || i < num - 1)
				{
					_0023_003DzJNrFsGPfoe3RoW4PHA_003D_003D[i] = (Point3D)((Entity)curve).Vertices[i].Clone();
				}
				else
				{
					_0023_003DzJNrFsGPfoe3RoW4PHA_003D_003D[i] = (Point3D)((Entity)curve).Vertices[0].Clone();
				}
			}
		}
		for (int j = 0; j < num2; j++)
		{
			if (j > 0)
			{
				Transformation transformation = new Transformation();
				transformation.Rotation(_0023_003DzNR5lGJ4_003D[j - 1], _0023_003DzNR5lGJ4_003D[j]);
				entity.TransformBy(transformation);
			}
			entity.Regen(_0023_003DzAqH9bgFsOafeqpSJ5A_003D_003D);
			for (int k = 0; k < num; k++)
			{
				if (!((ICurve)entity).IsClosed || k < num - 1)
				{
					_0023_003DzJNrFsGPfoe3RoW4PHA_003D_003D[k + (j + num3) * num] = (Point3D)entity.Vertices[k].Clone();
				}
				else
				{
					_0023_003DzJNrFsGPfoe3RoW4PHA_003D_003D[k + (j + num3) * num] = (Point3D)entity.Vertices[0].Clone();
				}
			}
		}
		if (!(_0023_003Dz_Li6Rm0_003D != null))
		{
			return;
		}
		ICurve curve2 = (ICurve)entity.Clone();
		((Entity)curve2).TransformBy(_0023_003Dz_Li6Rm0_003D);
		((Entity)curve2).Regen(_0023_003DzAqH9bgFsOafeqpSJ5A_003D_003D);
		for (int l = 0; l < num; l++)
		{
			if (!curve2.IsClosed || l < num - 1)
			{
				_0023_003DzJNrFsGPfoe3RoW4PHA_003D_003D[_0023_003DzJNrFsGPfoe3RoW4PHA_003D_003D.Length - num + l] = (Point3D)((Entity)curve2).Vertices[l].Clone();
			}
			else
			{
				_0023_003DzJNrFsGPfoe3RoW4PHA_003D_003D[_0023_003DzJNrFsGPfoe3RoW4PHA_003D_003D.Length - num + l] = (Point3D)((Entity)curve2).Vertices[0].Clone();
			}
		}
	}

	private static void _0023_003DzrdLykJXeX_VScOxfBQ_003D_003D(Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, int _0023_003DzztlQhuLq4X3L, int _0023_003DzrhHZsFR4hTtO, natureType _0023_003DzL3kjwgWK1Hcy, out IndexTriangle[] _0023_003DzVkrKg7m37l3bczXeWA_003D_003D)
	{
		_0023_003DzVkrKg7m37l3bczXeWA_003D_003D = new IndexTriangle[(_0023_003DzztlQhuLq4X3L - 1) * (_0023_003DzrhHZsFR4hTtO - 1) * 2];
		int num = 0;
		for (int i = 0; i < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length - _0023_003DzztlQhuLq4X3L; i++)
		{
			if (i % _0023_003DzztlQhuLq4X3L != _0023_003DzztlQhuLq4X3L - 1)
			{
				IndexTriangle indexTriangle = Utility.CreateTriangle(_0023_003DzL3kjwgWK1Hcy, i + _0023_003DzztlQhuLq4X3L, i, i + 1);
				_0023_003DzVkrKg7m37l3bczXeWA_003D_003D[num] = indexTriangle;
				num++;
				indexTriangle = Utility.CreateTriangle(_0023_003DzL3kjwgWK1Hcy, i + _0023_003DzztlQhuLq4X3L, i + 1, i + _0023_003DzztlQhuLq4X3L + 1);
				_0023_003DzVkrKg7m37l3bczXeWA_003D_003D[num] = indexTriangle;
				num++;
			}
		}
	}

	private static T _0023_003DzdncxQYEu8hc00O7aiw_003D_003D<T>(ICurve[] _0023_003DzHgrHIfhYCh4p, int _0023_003Dz5C_0024cyD9lhEyKEXb3Cw_003D_003D, ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, double _0023_003DzC5YR9r5C06bj, double _0023_003DzAqH9bgFsOafeqpSJ5A_003D_003D, bool _0023_003DzbErHvVw_003D, bool _0023_003DzHbb9s4FIaFfq, bool _0023_003DzcSSP_dM_003D, natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D) where T : Mesh, new()
	{
		Plane[] array = new Plane[2];
		Utility._0023_003DzaJ_0024f2lo0_00243GgxkJ85CDhnYs_003D(_0023_003DzHgrHIfhYCh4p, _0023_003Dz5C_0024cyD9lhEyKEXb3Cw_003D_003D, _0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzC5YR9r5C06bj, out var _0023_003Dz36E85bQs4X5tLDFyWQ_003D_003D, out var _0023_003DzYsh7vg3YvPj33Pvt8w_003D_003D, out array[0], out array[1], out var _0023_003Dzx5RboRHsRXS, out var _0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D, _0023_003DzHbb9s4FIaFfq);
		Vector3D _0023_003DzYNjcavt9guh = new Vector3D(_0023_003Dz36E85bQs4X5tLDFyWQ_003D_003D.StartPoint, _0023_003DzYsh7vg3YvPj33Pvt8w_003D_003D.EndPoint);
		int[] _0023_003DzBo_0024WMFcRxbjB2DsnsM0uBPo_003D;
		int _0023_003DzE8d_nHmRn3TvqI_euBbFoJw_003D;
		T val = _0023_003DzFPVyG4Y9TGyH<T>(_0023_003Dzx5RboRHsRXS, _0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D, _0023_003DzAqH9bgFsOafeqpSJ5A_003D_003D, _0023_003DzYNjcavt9guh, _0023_003DzcSSP_dM_003D, _0023_003DzbErHvVw_003D, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, out _0023_003DzE8d_nHmRn3TvqI_euBbFoJw_003D, out _0023_003DzBo_0024WMFcRxbjB2DsnsM0uBPo_003D);
		if (_0023_003Dz_SqBXz8_003D.IsClosed)
		{
			_0023_003DzE8d_nHmRn3TvqI_euBbFoJw_003D--;
		}
		if (_0023_003DzcSSP_dM_003D)
		{
			int num = _0023_003DzBo_0024WMFcRxbjB2DsnsM0uBPo_003D.Sum() - _0023_003DzBo_0024WMFcRxbjB2DsnsM0uBPo_003D.Length;
			_0023_003DzaTIYU0nIjdF6cGMpYw_003D_003D(val, array, 0, _0023_003DzE8d_nHmRn3TvqI_euBbFoJw_003D, _0023_003DzE8d_nHmRn3TvqI_euBbFoJw_003D + num);
			if (_0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D != null)
			{
				int num2 = _0023_003DzE8d_nHmRn3TvqI_euBbFoJw_003D;
				for (int i = 0; i < _0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D.Count; i++)
				{
					int num3 = _0023_003DzBo_0024WMFcRxbjB2DsnsM0uBPo_003D[i] - 1;
					_0023_003DzaTIYU0nIjdF6cGMpYw_003D_003D(val, array, num2, num2 + num3, _0023_003DzE8d_nHmRn3TvqI_euBbFoJw_003D + num);
					num2 += num3;
				}
			}
		}
		else
		{
			_0023_003DzaTIYU0nIjdF6cGMpYw_003D_003D(val, array, 0, _0023_003DzE8d_nHmRn3TvqI_euBbFoJw_003D, _0023_003DzE8d_nHmRn3TvqI_euBbFoJw_003D);
			if (_0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D != null)
			{
				int num4 = 2 * _0023_003DzE8d_nHmRn3TvqI_euBbFoJw_003D;
				for (int j = 0; j < _0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D.Count; j++)
				{
					_0023_003DzE8d_nHmRn3TvqI_euBbFoJw_003D = _0023_003DzBo_0024WMFcRxbjB2DsnsM0uBPo_003D[j] - 1;
					_0023_003DzaTIYU0nIjdF6cGMpYw_003D_003D(val, array, num4, num4 + _0023_003DzE8d_nHmRn3TvqI_euBbFoJw_003D, _0023_003DzE8d_nHmRn3TvqI_euBbFoJw_003D);
					num4 += 2 * _0023_003DzE8d_nHmRn3TvqI_euBbFoJw_003D;
				}
			}
		}
		return val;
	}

	private static void _0023_003DzaTIYU0nIjdF6cGMpYw_003D_003D(Mesh _0023_003DzGGJSiQk_003D, Plane[] _0023_003DzO846Fq5qmPew, int _0023_003DzAddCv_o_003D, int _0023_003Dz9iVQ96E_003D, int _0023_003DzfBEBL_o_003D)
	{
		if (_0023_003DzGGJSiQk_003D.BoxMin == null || _0023_003DzGGJSiQk_003D.BoxMax == null)
		{
			_0023_003DzGGJSiQk_003D.Regen(0.0);
		}
		double diagonal = _0023_003DzGGJSiQk_003D.BoxSize.Diagonal;
		foreach (Plane plane in _0023_003DzO846Fq5qmPew)
		{
			if (!(plane == null))
			{
				for (int j = _0023_003DzAddCv_o_003D; j < _0023_003Dz9iVQ96E_003D; j++)
				{
					_0023_003DzJsFdftjTB4EY(_0023_003DzGGJSiQk_003D.Vertices, plane, j, j + _0023_003DzfBEBL_o_003D, diagonal);
				}
			}
		}
	}

	private static bool _0023_003DzJsFdftjTB4EY(Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, Plane _0023_003Dzrgqz890sj_0024X9, int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D, double _0023_003Dz14lzA48_003D)
	{
		double num = _0023_003Dzrgqz890sj_0024X9.DistanceTo(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzffqPLNQ_003D]);
		Point3D intPoint;
		bool num2 = new Segment3D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzffqPLNQ_003D], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz5Azd7L8_003D]).IntersectWith(_0023_003Dzrgqz890sj_0024X9, out intPoint);
		if (num2)
		{
			if (num < 0.0 || Utility.AreEqual(num, 0.0, _0023_003Dz14lzA48_003D))
			{
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz5Azd7L8_003D] = intPoint;
				return num2;
			}
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzffqPLNQ_003D] = intPoint;
			return num2;
		}
		if (_0023_003Dzrgqz890sj_0024X9.DistanceTo(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz5Azd7L8_003D]) > num)
		{
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz5Azd7L8_003D] = (Point3D)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzffqPLNQ_003D].Clone();
			return num2;
		}
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzffqPLNQ_003D] = (Point3D)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz5Azd7L8_003D].Clone();
		return num2;
	}

	private static void _0023_003Dz7mr_4Z4_003D(Mesh _0023_003DzQ3ANCD8_003D, Plane[] _0023_003DzO846Fq5qmPew)
	{
		foreach (Plane plane in _0023_003DzO846Fq5qmPew)
		{
			if (!(plane == null))
			{
				_0023_003DzQ3ANCD8_003D._0023_003DzBVSD8WPcX9kp(plane, (_0023_003DzNuun60qGd2Yq)2);
			}
		}
	}

	private static T _0023_003DzRLbt9uDCT0W7yo59pg_003D_003D<T>(ICurve[] _0023_003DzHgrHIfhYCh4p, int _0023_003Dz5C_0024cyD9lhEyKEXb3Cw_003D_003D, ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, bool _0023_003DzbErHvVw_003D, bool _0023_003DzHbb9s4FIaFfq, bool _0023_003DzcSSP_dM_003D, natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D) where T : Mesh, new()
	{
		Plane[] array = new Plane[2];
		Utility._0023_003Dzi_uJo1YauacTvNQ2CLEP2dc_003D(_0023_003DzHgrHIfhYCh4p, _0023_003Dz5C_0024cyD9lhEyKEXb3Cw_003D_003D, _0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, out var _0023_003Dz5q4tZUlCeE1_P3aNGjVSGDY_003D, out var _0023_003DzU9BmYtsML4TsZeumM2Cxy_0024Q_003D, out array[0], out array[1], out var _0023_003DzPesVNJCLTBDwAAMTkw_003D_003D, out var _0023_003DzNwi0hLXqrQquQeDmpt5VUrs_003D, _0023_003DzHbb9s4FIaFfq, _0023_003DzqZLpJx9EBl4E2J4o3A9hYdM_003D: false);
		ICurve curve = (ICurve)_0023_003DzPesVNJCLTBDwAAMTkw_003D_003D.Clone();
		List<ICurve> list = new List<ICurve>();
		if (_0023_003DzWaFlkhfmYCja != null)
		{
			foreach (ICurve item in _0023_003DzNwi0hLXqrQquQeDmpt5VUrs_003D)
			{
				list.Add((ICurve)item.Clone());
			}
		}
		if (_0023_003DzU9BmYtsML4TsZeumM2Cxy_0024Q_003D == null)
		{
			curve.Reverse();
			for (int i = 0; i < list.Count; i++)
			{
				list[i].Reverse();
			}
		}
		else
		{
			_0023_003DzPesVNJCLTBDwAAMTkw_003D_003D.Reverse();
			for (int j = 0; j < list.Count; j++)
			{
				_0023_003DzNwi0hLXqrQquQeDmpt5VUrs_003D[j].Reverse();
			}
		}
		T val = _0023_003DzckMvsK9P4Br2SeVfrm3XM54_003D<T>(curve, list, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003Dz5q4tZUlCeE1_P3aNGjVSGDY_003D, array[0], (_0023_003DzU9BmYtsML4TsZeumM2Cxy_0024Q_003D == null) ? array[1] : null, _0023_003DzbErHvVw_003D, _0023_003DzcSSP_dM_003D, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
		if (_0023_003DzU9BmYtsML4TsZeumM2Cxy_0024Q_003D == null)
		{
			return val;
		}
		T val2 = _0023_003DzckMvsK9P4Br2SeVfrm3XM54_003D<T>(_0023_003DzPesVNJCLTBDwAAMTkw_003D_003D, _0023_003DzNwi0hLXqrQquQeDmpt5VUrs_003D, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003DzU9BmYtsML4TsZeumM2Cxy_0024Q_003D, array[1], null, _0023_003DzbErHvVw_003D, _0023_003DzcSSP_dM_003D, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
		if (val2 != null)
		{
			val.MergeWith(val2);
		}
		return val;
	}

	private static T _0023_003DzckMvsK9P4Br2SeVfrm3XM54_003D<T>(ICurve _0023_003DzPesVNJCLTBDwAAMTkw_003D_003D, IList<ICurve> _0023_003DzNwi0hLXqrQquQeDmpt5VUrs_003D, double _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, Arc _0023_003DzN4MDZ_0024c_003D, Plane _0023_003Dz1UOOIRi32zbc, Plane _0023_003Dz0mRtGxd84ek0, bool _0023_003DzbErHvVw_003D, bool _0023_003DzcSSP_dM_003D, natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D) where T : Mesh, new()
	{
		int _0023_003DzAPBIJmvn5i5Q = Utility.NumberOfSegments(_0023_003DzN4MDZ_0024c_003D.Radius, _0023_003DzN4MDZ_0024c_003D.AngleInRadians, _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D);
		Utility._0023_003Dz0U2l9p_0024wMUWMI2xPGxvwVTCSGwVr(_0023_003DzPesVNJCLTBDwAAMTkw_003D_003D, _0023_003DzNwi0hLXqrQquQeDmpt5VUrs_003D, _0023_003DzN4MDZ_0024c_003D.Plane.AxisZ, _0023_003DzN4MDZ_0024c_003D.Center, _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, out var _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out var _0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D, out var _0023_003DzJlv_CuAUfJRQ, _0023_003DzbErHvVw_003D);
		Plane[] _0023_003DzO846Fq5qmPew = new Plane[2] { _0023_003Dz1UOOIRi32zbc, _0023_003Dz0mRtGxd84ek0 };
		T obj = _0023_003Dz_zLhQ7UUHrThF4tt5A_003D_003D<T>(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D, 0.0, _0023_003DzN4MDZ_0024c_003D.AngleInRadians, _0023_003DzN4MDZ_0024c_003D.Plane.AxisZ, _0023_003DzN4MDZ_0024c_003D.Center, _0023_003DzAPBIJmvn5i5Q, _0023_003DzcSSP_dM_003D, _0023_003DzJlv_CuAUfJRQ, _0023_003DzbErHvVw_003D, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D) ?? throw new ArithmeticException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972521) + _0023_003DzN4MDZ_0024c_003D.Radius);
		_0023_003Dz7mr_4Z4_003D(obj, _0023_003DzO846Fq5qmPew);
		return obj;
	}

	internal static Mesh _0023_003Dz_0024QJlr0pItQh7PH05vQ_003D_003D(Mesh[] _0023_003DzIIuKCj1NK1q5, natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, bool _0023_003DzgM38qBg_003D)
	{
		Point3D[][] array = new Point3D[_0023_003DzIIuKCj1NK1q5.Length][];
		IndexTriangle[][] array2 = new IndexTriangle[_0023_003DzIIuKCj1NK1q5.Length][];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = _0023_003DzIIuKCj1NK1q5[i]._vertices;
			if (_0023_003DzgM38qBg_003D)
			{
				array2[i] = new IndexTriangle[_0023_003DzIIuKCj1NK1q5[i]._triangles.Length];
				_0023_003DzIIuKCj1NK1q5[i]._triangles.CopyTo(array2[i], 0);
			}
			else
			{
				array2[i] = _0023_003DzIIuKCj1NK1q5[i]._triangles;
			}
		}
		Mesh mesh = new Mesh(_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
		_0023_003DzzyVeZ2JpkYXhOQrH90swHab1jKJWHKtJCQ_003D_003D(array, array2, out mesh._vertices, out mesh._triangles, _0023_003DzgM38qBg_003D);
		return mesh;
	}

	public static Mesh CreateTorus(double majorRadius, double minorRadius, int sides, int rings)
	{
		return CreateTorus<Mesh>(majorRadius, minorRadius, sides, rings);
	}

	public static T CreateTorus<T>(double majorRadius, double minorRadius, int sides, int rings) where T : Mesh, new()
	{
		return CreateTorus<T>(majorRadius, minorRadius, sides, rings, natureType.Smooth);
	}

	public static Mesh CreateTorus(double majorRadius, double minorRadius, int sides, int rings, natureType meshNature)
	{
		return CreateTorus<Mesh>(majorRadius, minorRadius, sides, rings, meshNature);
	}

	public static T CreateTorus<T>(double majorRadius, double minorRadius, int sides, int rings, natureType meshNature) where T : Mesh, new()
	{
		T val = new T();
		val._0023_003DztGdcVOA_003D(meshNature, edgeStyleType.None);
		if (!val._0023_003Dzw73WV7L13sFAT3lHjGcVVkE_003D(majorRadius, minorRadius, sides, rings, 0.0, 1.0, _0023_003DzEXLcE10_003D: true, _0023_003DzbErHvVw_003D: false))
		{
			throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971518));
		}
		val.UpdateBoundingBox(null);
		val.RegenMode = regenType.CompileOnly;
		return val;
	}

	internal bool _0023_003Dzw73WV7L13sFAT3lHjGcVVkE_003D(double _0023_003DzA_8ilLvuROi4, double _0023_003DzZonw8nQGtIca, int _0023_003Dz_C5M_0024TZrmoaK, int _0023_003Dz7ewckDbdfS0PeQ1MBg_003D_003D, double _0023_003DzWCb_GsUb_0024PKW, double _0023_003Dzhgpssj66wX0L, bool _0023_003DzEXLcE10_003D, bool _0023_003DzbErHvVw_003D)
	{
		if (_0023_003DzZonw8nQGtIca < Utility._0023_003DzheSR8QM7q9ya || _0023_003DzA_8ilLvuROi4 < Utility._0023_003DzheSR8QM7q9ya || _0023_003Dz_C5M_0024TZrmoaK < 3 || _0023_003Dz7ewckDbdfS0PeQ1MBg_003D_003D < 2)
		{
			return false;
		}
		bool flag = true;
		natureType meshNature = _meshNature;
		if (meshNature - 1 <= natureType.MulticolorPlain)
		{
			flag = false;
		}
		double num = (double)_0023_003Dz7ewckDbdfS0PeQ1MBg_003D_003D * _0023_003Dzhgpssj66wX0L;
		int num2 = (int)Math.Ceiling(num);
		int num3 = (int)Math.Floor(num);
		if (_0023_003DzWCb_GsUb_0024PKW != 0.0 && num2 == num3)
		{
			num2++;
		}
		int num4 = num2 * _0023_003Dz_C5M_0024TZrmoaK;
		if (_0023_003DzbErHvVw_003D)
		{
			num4 += 2;
		}
		_vertices = new Point3D[num4];
		if (flag)
		{
			_normals = new Vector3D[_vertices.Length];
		}
		double[] array = new double[_0023_003Dz7ewckDbdfS0PeQ1MBg_003D_003D];
		double[] array2 = new double[_0023_003Dz7ewckDbdfS0PeQ1MBg_003D_003D];
		double[] array3 = new double[_0023_003Dz_C5M_0024TZrmoaK];
		double[] array4 = new double[_0023_003Dz_C5M_0024TZrmoaK];
		double num5 = 1.0;
		if (_0023_003DzEXLcE10_003D)
		{
			num5 = -1.0;
		}
		double num6 = 0.0;
		double num7 = num5 * 2.0 * Math.PI / (double)_0023_003Dz7ewckDbdfS0PeQ1MBg_003D_003D;
		for (int i = 0; i < _0023_003Dz7ewckDbdfS0PeQ1MBg_003D_003D; i++)
		{
			array[i] = Math.Cos(num6);
			array2[i] = Math.Sin(num6);
			num6 += num7;
		}
		double num8 = 0.0;
		double num9 = Math.PI * 2.0 / (double)_0023_003Dz_C5M_0024TZrmoaK;
		for (int j = 0; j < _0023_003Dz_C5M_0024TZrmoaK; j++)
		{
			array3[j] = Math.Cos(num8);
			array4[j] = Math.Sin(num8);
			num8 += num9;
		}
		int num10 = num3;
		if (_0023_003DzWCb_GsUb_0024PKW != 0.0)
		{
			num10 = 1;
		}
		int num11 = 0;
		for (int k = 0; k < num10; k++)
		{
			int num12 = 0;
			while (num12 < _0023_003Dz_C5M_0024TZrmoaK)
			{
				Utility._0023_003DzDeutQJrDzJ4h(_meshNature, _0023_003DzA_8ilLvuROi4, _0023_003DzZonw8nQGtIca, num11, array[k % _0023_003Dz7ewckDbdfS0PeQ1MBg_003D_003D], array2[k % _0023_003Dz7ewckDbdfS0PeQ1MBg_003D_003D], array3[num12], array4[num12], flag, _vertices, _normals);
				num8 += num9;
				num12++;
				num11++;
			}
		}
		if (_0023_003DzWCb_GsUb_0024PKW != 0.0)
		{
			_0023_003Dz7tzEx9Nm_0024lFzOKjk0w_003D_003D(num, _0023_003Dz7ewckDbdfS0PeQ1MBg_003D_003D, num2, _0023_003Dz_C5M_0024TZrmoaK, num7, _0023_003DzWCb_GsUb_0024PKW, _0023_003DzA_8ilLvuROi4, _0023_003DzbErHvVw_003D, flag, _0023_003DzEXLcE10_003D);
		}
		int num13 = num3 * _0023_003Dz_C5M_0024TZrmoaK * 2;
		if (_0023_003DzbErHvVw_003D)
		{
			num13 += 2 * _0023_003Dz_C5M_0024TZrmoaK;
		}
		_triangles = new IndexTriangle[num13];
		int num14 = 0;
		num11 = 0;
		for (int l = 0; l < num2 - 1; l++)
		{
			int num15 = 0;
			while (num15 < _0023_003Dz_C5M_0024TZrmoaK)
			{
				int num16 = num11;
				int num17 = num11 + 1;
				int num18 = num11 + _0023_003Dz_C5M_0024TZrmoaK + 1;
				if (num15 == _0023_003Dz_C5M_0024TZrmoaK - 1)
				{
					num17 -= _0023_003Dz_C5M_0024TZrmoaK;
					num18 -= _0023_003Dz_C5M_0024TZrmoaK;
				}
				_triangles[num14++] = Utility.CreateTriangle(_meshNature, num16, num17, num18, num16, num17, num18);
				num17 = num11 + _0023_003Dz_C5M_0024TZrmoaK + 1;
				num18 = num11 + _0023_003Dz_C5M_0024TZrmoaK;
				if (num15 == _0023_003Dz_C5M_0024TZrmoaK - 1)
				{
					num17 -= _0023_003Dz_C5M_0024TZrmoaK;
				}
				_triangles[num14++] = Utility.CreateTriangle(_meshNature, num16, num17, num18, num16, num17, num18);
				num15++;
				num11++;
			}
		}
		if (_0023_003DzWCb_GsUb_0024PKW == 0.0)
		{
			int num19 = 0;
			while (num19 < _0023_003Dz_C5M_0024TZrmoaK)
			{
				int num16 = num11;
				int num17 = num11 + 1;
				int num18 = (num11 + _0023_003Dz_C5M_0024TZrmoaK) % _vertices.Length + 1;
				if (num19 == _0023_003Dz_C5M_0024TZrmoaK - 1)
				{
					num17 -= _0023_003Dz_C5M_0024TZrmoaK;
					num18 -= _0023_003Dz_C5M_0024TZrmoaK;
				}
				_triangles[num14++] = Utility.CreateTriangle(_meshNature, num16, num17, num18, num16, num17, num18);
				num18 = (num11 + _0023_003Dz_C5M_0024TZrmoaK) % _vertices.Length;
				num17 = num18 + 1;
				if (num19 == _0023_003Dz_C5M_0024TZrmoaK - 1)
				{
					num17 -= _0023_003Dz_C5M_0024TZrmoaK;
				}
				_triangles[num14++] = Utility.CreateTriangle(_meshNature, num16, num17, num18, num16, num17, num18);
				num19++;
				num11++;
			}
		}
		if (_0023_003DzbErHvVw_003D)
		{
			int num20 = num2 * _0023_003Dz_C5M_0024TZrmoaK;
			for (int m = 0; m < _0023_003Dz_C5M_0024TZrmoaK; m++)
			{
				_triangles[num14++] = Utility.CreateTriangle(_meshNature, (m + 1) % _0023_003Dz_C5M_0024TZrmoaK, m, num20, num20, num20, num20);
			}
			int num21 = num20 + 1;
			int num22 = (num2 - 1) * _0023_003Dz_C5M_0024TZrmoaK;
			for (int n = num22; n < num22 + _0023_003Dz_C5M_0024TZrmoaK - 1; n++)
			{
				_triangles[num14++] = Utility.CreateTriangle(_meshNature, n, n + 1, num21, num21, num21, num21);
			}
			_triangles[num14++] = Utility.CreateTriangle(_meshNature, num22 + _0023_003Dz_C5M_0024TZrmoaK - 1, num22, num21, num21, num21, num21);
			if (_edgeStyle == edgeStyleType.Sharp)
			{
				_edges = new IndexLine[2 * _0023_003Dz_C5M_0024TZrmoaK];
				for (int num23 = 0; num23 < _0023_003Dz_C5M_0024TZrmoaK; num23++)
				{
					_edges[num23] = new IndexLine((num23 + 1) % _0023_003Dz_C5M_0024TZrmoaK, num23);
				}
				int num24 = _0023_003Dz_C5M_0024TZrmoaK;
				for (int num25 = num22; num25 < num22 + _0023_003Dz_C5M_0024TZrmoaK - 1; num25++)
				{
					_edges[num24++] = new IndexLine(num25, num25 + 1);
				}
				_edges[num24++] = new IndexLine(num22 + _0023_003Dz_C5M_0024TZrmoaK - 1, num22);
			}
		}
		if (!_0023_003DzEXLcE10_003D && _0023_003DzWCb_GsUb_0024PKW != 0.0)
		{
			if (_triangles[0] is SmoothTriangle)
			{
				IndexTriangle[] triangles = Triangles;
				for (int num26 = 0; num26 < triangles.Length; num26++)
				{
					SmoothTriangle obj = (SmoothTriangle)triangles[num26];
					int num16 = obj.V1;
					obj.V1 = obj.V2;
					obj.V2 = num16;
					int n2 = obj.N1;
					obj.N1 = obj.N2;
					obj.N2 = n2;
				}
			}
			else
			{
				IndexTriangle[] triangles = Triangles;
				foreach (IndexTriangle indexTriangle in triangles)
				{
					int num16 = indexTriangle.V1;
					indexTriangle.V1 = indexTriangle.V2;
					indexTriangle.V2 = num16;
				}
			}
		}
		if (!flag)
		{
			UpdateNormals();
		}
		UpdateBoundingBox(null);
		RegenMode = regenType.CompileOnly;
		return true;
	}

	private void _0023_003Dz7tzEx9Nm_0024lFzOKjk0w_003D_003D(double _0023_003Dz6KQ4h9k_003D, int _0023_003Dz7ewckDbdfS0PeQ1MBg_003D_003D, int _0023_003Dzb7wUrtZSQL7U, int _0023_003Dz_C5M_0024TZrmoaK, double _0023_003DzfrBj_0Wg9PsN, double _0023_003DzWCb_GsUb_0024PKW, double _0023_003DzZonw8nQGtIca, bool _0023_003DzbErHvVw_003D, bool _0023_003DztU8XIY9a8QJIXrxx2Q_003D_003D, bool _0023_003DzEXLcE10_003D)
	{
		double num = _0023_003DzWCb_GsUb_0024PKW / (double)_0023_003Dz7ewckDbdfS0PeQ1MBg_003D_003D;
		double num2 = num;
		double num3 = 1.0;
		double num4 = _0023_003Dz6KQ4h9k_003D - Math.Floor(_0023_003Dz6KQ4h9k_003D);
		if (num4 > Utility._0023_003DzheSR8QM7q9ya)
		{
			num2 = num4 * num;
			num3 = num4;
		}
		double num5 = num3 * _0023_003DzfrBj_0Wg9PsN;
		double angleInRadians = Math.Atan(_0023_003DzWCb_GsUb_0024PKW / (Math.PI * 2.0 * _0023_003DzZonw8nQGtIca)) * (double)Math.Sign(_0023_003DzfrBj_0Wg9PsN);
		double num6 = 0.0;
		double num7 = 0.0;
		Transformation transformation = new Transformation();
		transformation.Rotation(angleInRadians, Vector3D.AxisX);
		for (int i = 0; i < _0023_003Dz_C5M_0024TZrmoaK; i++)
		{
			_vertices[i] = transformation * _vertices[i];
		}
		if (_0023_003DztU8XIY9a8QJIXrxx2Q_003D_003D)
		{
			for (int j = 0; j < _0023_003Dz_C5M_0024TZrmoaK; j++)
			{
				_normals[j] = transformation * _normals[j];
			}
		}
		int num8 = _0023_003Dz_C5M_0024TZrmoaK;
		Transformation transformation2;
		Transformation transformation3;
		for (int k = 1; k < _0023_003Dzb7wUrtZSQL7U - 1; k++)
		{
			num7 += _0023_003DzfrBj_0Wg9PsN;
			num6 += num;
			transformation2 = new Transformation();
			transformation2.Rotation(num7, Vector3D.AxisZ);
			transformation3 = new Translation(0.0, 0.0, num6) * transformation2;
			for (int l = 0; l < _0023_003Dz_C5M_0024TZrmoaK; l++)
			{
				_vertices[num8] = transformation3 * _vertices[l];
				if (_0023_003DztU8XIY9a8QJIXrxx2Q_003D_003D)
				{
					_normals[num8] = transformation2 * _normals[l];
				}
				num8++;
			}
		}
		num6 += num2;
		num7 += num5;
		transformation2 = new Transformation();
		transformation2.Rotation(num7, Vector3D.AxisZ);
		transformation3 = new Translation(0.0, 0.0, num6) * transformation2;
		for (int m = 0; m < _0023_003Dz_C5M_0024TZrmoaK; m++)
		{
			_vertices[num8] = transformation3 * _vertices[m];
			if (_0023_003DztU8XIY9a8QJIXrxx2Q_003D_003D)
			{
				_normals[num8] = transformation2 * _normals[m];
			}
			num8++;
		}
		if (_0023_003DzbErHvVw_003D)
		{
			Utility._0023_003DzDeutQJrDzJ4h(_meshNature, _0023_003DzZonw8nQGtIca, 0.0, num8, 1.0, 0.0, 0.0, 1.0, _0023_003DztU8XIY9a8QJIXrxx2Q_003D_003D: false, _vertices, _normals);
			Utility._0023_003DzDeutQJrDzJ4h(_meshNature, _0023_003DzZonw8nQGtIca, 0.0, num8 + 1, Math.Cos(num7), Math.Sin(num7), 0.0, 1.0, _0023_003DztU8XIY9a8QJIXrxx2Q_003D_003D: false, _vertices, _normals);
			_vertices[num8 + 1].Z = num6;
			if (_0023_003DztU8XIY9a8QJIXrxx2Q_003D_003D)
			{
				_normals[num8] = new Vector3D(0.0, 1.0, 0.0);
				_normals[num8] = transformation * _normals[num8];
				_normals[num8 + 1] = transformation2 * _normals[num8];
				_normals[num8 + 1] = _normals[num8 + 1] * -1.0;
			}
		}
	}

	internal static IndexTriangle[] _0023_003DzeVELJPX06XqphX1Zqg_003D_003D(natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, int _0023_003Dzfsn580w_003D)
	{
		switch (_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D)
		{
		case natureType.Plain:
		case natureType.MulticolorPlain:
			return new IndexTriangle[_0023_003Dzfsn580w_003D];
		case natureType.ColorPlain:
			return new ColorTriangle[_0023_003Dzfsn580w_003D];
		case natureType.RichPlain:
			return new RichTriangle[_0023_003Dzfsn580w_003D];
		case natureType.Smooth:
		case natureType.MulticolorSmooth:
			return new SmoothTriangle[_0023_003Dzfsn580w_003D];
		case natureType.ColorSmooth:
			return new ColorSmoothTriangle[_0023_003Dzfsn580w_003D];
		case natureType.RichSmooth:
			return new RichSmoothTriangle[_0023_003Dzfsn580w_003D];
		default:
			return null;
		}
	}

	internal static void _0023_003DzTELBpP5fqJNd(natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, IndexTriangle _0023_003DzRgg6pHuFcFSRwlQQs1Upb8NP2cBl)
	{
		switch (_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D)
		{
		case natureType.ColorPlain:
		{
			ColorTriangle obj2 = (ColorTriangle)_0023_003DzRgg6pHuFcFSRwlQQs1Upb8NP2cBl;
			obj2.R = 245;
			obj2.G = 245;
			obj2.B = 220;
			break;
		}
		case natureType.ColorSmooth:
		{
			ColorSmoothTriangle obj = (ColorSmoothTriangle)_0023_003DzRgg6pHuFcFSRwlQQs1Upb8NP2cBl;
			obj.R = 245;
			obj.G = 245;
			obj.B = 220;
			break;
		}
		}
	}

	public static Mesh CreateArrow(double cylRadius, double cylLength, double coneRadius, double coneLength, int slices, natureType meshNature)
	{
		return CreateArrow<Mesh>(cylRadius, cylLength, coneRadius, coneLength, slices, meshNature, edgeStyleType.Sharp);
	}

	public static T CreateArrow<T>(double cylRadius, double cylLength, double coneRadius, double coneLength, int slices, natureType meshNature) where T : Mesh, new()
	{
		return CreateArrow<T>(cylRadius, cylLength, coneRadius, coneLength, slices, meshNature, edgeStyleType.Sharp);
	}

	public static Mesh CreateArrow(double cylRadius, double cylLength, double coneRadius, double coneLength, int slices, natureType meshNature, edgeStyleType edgeStyle)
	{
		return CreateArrow<Mesh>(cylRadius, cylLength, coneRadius, coneLength, slices, meshNature, edgeStyle);
	}

	public static T CreateArrow<T>(double cylRadius, double cylLength, double coneRadius, double coneLength, int slices, natureType meshNature, edgeStyleType edgeStyle) where T : Mesh, new()
	{
		T val = new T();
		val._0023_003DztGdcVOA_003D(meshNature, edgeStyle);
		if (!val._0023_003DzS9hTCkp_TnIt(cylRadius, cylLength, coneRadius, coneLength, slices))
		{
			throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971518));
		}
		val.UpdateBoundingBox(null);
		val.RegenMode = regenType.CompileOnly;
		return val;
	}

	public static Mesh CreateArrow(Point3D startPoint, Vector3D direction, double cylRadius, double cylLength, double coneRadius, double coneLength, int slices, natureType meshNature, edgeStyleType edgeStyle)
	{
		Mesh mesh = CreateArrow<Mesh>(cylRadius, cylLength, coneRadius, coneLength, slices, meshNature, edgeStyle);
		mesh.TransformBy(Utility.GetOrientationTransformation(startPoint, direction));
		return mesh;
	}

	public static T CreateArrow<T>(Point3D startPoint, Vector3D direction, double cylRadius, double cylLength, double coneRadius, double coneLength, int slices, natureType meshNature, edgeStyleType edgeStyle) where T : Mesh, new()
	{
		T val = CreateArrow<T>(cylRadius, cylLength, coneRadius, coneLength, slices, meshNature, edgeStyle);
		val.TransformBy(Utility.GetOrientationTransformation(startPoint, direction));
		val.UpdateBoundingBox(null);
		val.RegenMode = regenType.CompileOnly;
		return val;
	}

	private bool _0023_003DzS9hTCkp_TnIt(double _0023_003Dzv8q5bvrYZ3IJ, double _0023_003Dz5BwfsTzt5Ojn, double _0023_003DzakqBBO6tymhY, double _0023_003DzxuzOPlsqwGeV, int _0023_003DzAPBIJmvn5i5Q)
	{
		if (_0023_003Dzv8q5bvrYZ3IJ < Utility._0023_003DzheSR8QM7q9ya || _0023_003Dz5BwfsTzt5Ojn < Utility._0023_003DzheSR8QM7q9ya || _0023_003DzakqBBO6tymhY < Utility._0023_003DzheSR8QM7q9ya || _0023_003DzxuzOPlsqwGeV < Utility._0023_003DzheSR8QM7q9ya || _0023_003DzAPBIJmvn5i5Q < 3)
		{
			return false;
		}
		bool flag = true;
		natureType meshNature = _meshNature;
		if (meshNature - 1 <= natureType.MulticolorPlain)
		{
			flag = false;
		}
		_vertices = new Point3D[_0023_003DzAPBIJmvn5i5Q * 3 + 2];
		if (flag)
		{
			_normals = new Vector3D[_0023_003DzAPBIJmvn5i5Q * 2 + 1];
		}
		double a = Math.Atan2(_0023_003DzakqBBO6tymhY, _0023_003DzxuzOPlsqwGeV);
		for (int i = 0; i < _0023_003DzAPBIJmvn5i5Q; i++)
		{
			double num = (double)(i * 2) * Math.PI / (double)_0023_003DzAPBIJmvn5i5Q;
			double num2 = Math.Cos(num);
			double num3 = Math.Sin(num);
			if (flag)
			{
				_normals[i] = new Vector3D(0.0, num2, num3);
				Vector3D vector3D = new Vector3D(Math.Tan(a), num2, num3);
				vector3D.Normalize();
				_normals[i + _0023_003DzAPBIJmvn5i5Q] = vector3D;
			}
			_vertices[i] = Utility.CreateVertex(_meshNature, 0.0, num2 * _0023_003Dzv8q5bvrYZ3IJ, num3 * _0023_003Dzv8q5bvrYZ3IJ);
			_vertices[i + _0023_003DzAPBIJmvn5i5Q] = Utility.CreateVertex(_meshNature, _0023_003Dz5BwfsTzt5Ojn, num2 * _0023_003Dzv8q5bvrYZ3IJ, num3 * _0023_003Dzv8q5bvrYZ3IJ);
			_vertices[i + _0023_003DzAPBIJmvn5i5Q * 2] = Utility.CreateVertex(_meshNature, _0023_003Dz5BwfsTzt5Ojn, num2 * _0023_003DzakqBBO6tymhY, num3 * _0023_003DzakqBBO6tymhY);
		}
		_vertices[_0023_003DzAPBIJmvn5i5Q * 3] = Utility.CreateVertex(_meshNature, 0.0, 0.0, 0.0);
		_vertices[_0023_003DzAPBIJmvn5i5Q * 3 + 1] = Utility.CreateVertex(_meshNature, _0023_003DzxuzOPlsqwGeV + _0023_003Dz5BwfsTzt5Ojn, 0.0, 0.0);
		if (flag)
		{
			_normals[_0023_003DzAPBIJmvn5i5Q * 2] = new Vector3D(-1.0, 0.0, 0.0);
		}
		int num4 = _0023_003DzAPBIJmvn5i5Q * 2 + _0023_003DzAPBIJmvn5i5Q * 2 * 2;
		_triangles = new IndexTriangle[num4];
		int num5 = 0;
		for (int j = 0; j < _0023_003DzAPBIJmvn5i5Q; j++)
		{
			int num6 = j;
			int num7 = ((j + 1 < _0023_003DzAPBIJmvn5i5Q) ? (j + 1) : 0);
			int num8 = ((j + _0023_003DzAPBIJmvn5i5Q + 1 >= _0023_003DzAPBIJmvn5i5Q * 2) ? _0023_003DzAPBIJmvn5i5Q : (j + _0023_003DzAPBIJmvn5i5Q + 1));
			int n = num6;
			int n2 = num7;
			int n3 = num8 - _0023_003DzAPBIJmvn5i5Q;
			_triangles[num5++] = Utility.CreateTriangle(_meshNature, num6, num7, num8, n, n2, n3);
			num6 = j;
			num7 = ((j + _0023_003DzAPBIJmvn5i5Q + 1 >= _0023_003DzAPBIJmvn5i5Q * 2) ? _0023_003DzAPBIJmvn5i5Q : (j + _0023_003DzAPBIJmvn5i5Q + 1));
			num8 = j + _0023_003DzAPBIJmvn5i5Q;
			n = num6;
			n2 = num7 - _0023_003DzAPBIJmvn5i5Q;
			n3 = num8 - _0023_003DzAPBIJmvn5i5Q;
			_triangles[num5++] = Utility.CreateTriangle(_meshNature, num6, num7, num8, n, n2, n3);
			num6 = j + _0023_003DzAPBIJmvn5i5Q;
			num7 = ((j + 1 >= _0023_003DzAPBIJmvn5i5Q) ? _0023_003DzAPBIJmvn5i5Q : (j + _0023_003DzAPBIJmvn5i5Q + 1));
			num8 = ((j + _0023_003DzAPBIJmvn5i5Q + 1 >= _0023_003DzAPBIJmvn5i5Q * 2) ? (_0023_003DzAPBIJmvn5i5Q * 2) : (j + _0023_003DzAPBIJmvn5i5Q * 2 + 1));
			n = _0023_003DzAPBIJmvn5i5Q * 2;
			n2 = _0023_003DzAPBIJmvn5i5Q * 2;
			n3 = _0023_003DzAPBIJmvn5i5Q * 2;
			_triangles[num5++] = Utility.CreateTriangle(_meshNature, num6, num7, num8, n, n2, n3);
			num6 = j + _0023_003DzAPBIJmvn5i5Q;
			num7 = ((j + _0023_003DzAPBIJmvn5i5Q + 1 >= _0023_003DzAPBIJmvn5i5Q * 2) ? (_0023_003DzAPBIJmvn5i5Q * 2) : (j + _0023_003DzAPBIJmvn5i5Q * 2 + 1));
			num8 = j + _0023_003DzAPBIJmvn5i5Q * 2;
			n = _0023_003DzAPBIJmvn5i5Q * 2;
			n2 = _0023_003DzAPBIJmvn5i5Q * 2;
			n3 = _0023_003DzAPBIJmvn5i5Q * 2;
			_triangles[num5++] = Utility.CreateTriangle(_meshNature, num6, num7, num8, n, n2, n3);
			num6 = j + _0023_003DzAPBIJmvn5i5Q * 2;
			num7 = ((j + _0023_003DzAPBIJmvn5i5Q + 1 >= _0023_003DzAPBIJmvn5i5Q * 2) ? (_0023_003DzAPBIJmvn5i5Q * 2) : (j + _0023_003DzAPBIJmvn5i5Q * 2 + 1));
			num8 = _0023_003DzAPBIJmvn5i5Q * 3 + 1;
			n = num6 - _0023_003DzAPBIJmvn5i5Q;
			n2 = num7 - _0023_003DzAPBIJmvn5i5Q;
			n3 = n;
			_triangles[num5++] = Utility.CreateTriangle(_meshNature, num6, num7, num8, n, n2, n3);
			num6 = _0023_003DzAPBIJmvn5i5Q * 3;
			num7 = ((j + 1 < _0023_003DzAPBIJmvn5i5Q) ? (j + 1) : 0);
			num8 = j;
			n = _0023_003DzAPBIJmvn5i5Q * 2;
			n2 = _0023_003DzAPBIJmvn5i5Q * 2;
			n3 = _0023_003DzAPBIJmvn5i5Q * 2;
			_triangles[num5++] = Utility.CreateTriangle(_meshNature, num6, num7, num8, n, n2, n3);
		}
		if (_edgeStyle == edgeStyleType.Sharp)
		{
			Edges = new IndexLine[_0023_003DzAPBIJmvn5i5Q * 3];
			num5 = 0;
			for (int k = 0; k < _0023_003DzAPBIJmvn5i5Q; k++)
			{
				if (k + 1 < _0023_003DzAPBIJmvn5i5Q)
				{
					Edges[num5++] = new IndexLine(k, k + 1);
				}
				else
				{
					Edges[num5++] = new IndexLine(k, 0);
				}
				if (_0023_003DzAPBIJmvn5i5Q + k + 1 < _0023_003DzAPBIJmvn5i5Q * 2)
				{
					Edges[num5++] = new IndexLine(_0023_003DzAPBIJmvn5i5Q + k, _0023_003DzAPBIJmvn5i5Q + k + 1);
				}
				else
				{
					Edges[num5++] = new IndexLine(_0023_003DzAPBIJmvn5i5Q + k, _0023_003DzAPBIJmvn5i5Q);
				}
				if (_0023_003DzAPBIJmvn5i5Q * 2 + k + 1 < _0023_003DzAPBIJmvn5i5Q * 3)
				{
					Edges[num5++] = new IndexLine(_0023_003DzAPBIJmvn5i5Q * 2 + k, _0023_003DzAPBIJmvn5i5Q * 2 + k + 1);
				}
				else
				{
					Edges[num5++] = new IndexLine(_0023_003DzAPBIJmvn5i5Q * 2 + k, _0023_003DzAPBIJmvn5i5Q * 2);
				}
			}
		}
		if (!flag)
		{
			UpdateNormals();
		}
		return true;
	}

	public static Mesh CreateSpring(double radius, double wireRadius, int sides, int rings, double pitch, double turns, bool reverseTwist)
	{
		return CreateSpring<Mesh>(radius, wireRadius, sides, rings, pitch, turns, reverseTwist);
	}

	public static T CreateSpring<T>(double radius, double wireRadius, int sides, int rings, double pitch, double turns, bool reverseTwist) where T : Mesh, new()
	{
		return CreateSpring<T>(radius, wireRadius, sides, rings, pitch, turns, reverseTwist, closed: true, natureType.Smooth);
	}

	public static Mesh CreateSpring(double radius, double wireRadius, int sides, int rings, double pitch, double turns, bool reverseTwist, bool closed, natureType meshNature)
	{
		return CreateSpring<Mesh>(radius, wireRadius, sides, rings, pitch, turns, reverseTwist, closed, meshNature);
	}

	public static T CreateSpring<T>(double radius, double wireRadius, int sides, int rings, double pitch, double turns, bool reverseTwist, bool closed, natureType meshNature) where T : Mesh, new()
	{
		T val = new T();
		val._0023_003DztGdcVOA_003D(meshNature, edgeStyleType.Sharp);
		val._0023_003Dzw73WV7L13sFAT3lHjGcVVkE_003D(radius, wireRadius, sides, rings, pitch, turns, reverseTwist, closed);
		val.UpdateBoundingBox(null);
		val.RegenMode = regenType.CompileOnly;
		return val;
	}

	public ICurve[] Section(Plane plane, double tol)
	{
		return Section(plane.Equation);
	}

	public ICurve[] Section(Plane plane, double tol, LinkedList<SharedEdge>[] edgesPerVertex = null)
	{
		return Section(plane.Equation, edgesPerVertex);
	}

	public ICurve[] Section(PlaneEquation planeEquation, LinkedList<SharedEdge>[] edgesPerVertex = null)
	{
		return _0023_003DzZ5omX40_003D(planeEquation, _triangles, _vertices, edgesPerVertex, (Octree)_subdivisionTree);
	}

	public ICurve[] Section(Plane plane, double tol, out SharedEdge[][] edges)
	{
		return Section(plane.Equation, out edges);
	}

	public ICurve[] Section(PlaneEquation planeEquation, out SharedEdge[][] edges)
	{
		if (_subdivisionTree != null)
		{
			edges = null;
			return _0023_003DzZ5omX40_003D(planeEquation, Triangles, Vertices, null, (Octree)_subdivisionTree);
		}
		return _0023_003DzZ5omX40_003D(planeEquation, _triangles, _vertices, null, out edges);
	}

	internal static ICurve[] _0023_003DzZ5omX40_003D(PlaneEquation _0023_003DzcpmWXV6_RKAxSjs1rCCcX4E_003D, IList<IndexTriangle> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, LinkedList<SharedEdge>[] _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D, Octree _0023_003DzZDdOnHY_0024bfnc)
	{
		List<_0023_003DzfKhYg_pIXj4J[]> list = _0023_003DzPp8HK942cFuX(_0023_003DzcpmWXV6_RKAxSjs1rCCcX4E_003D, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D, _0023_003DzZDdOnHY_0024bfnc);
		ICurve[] array = new ICurve[list.Count];
		for (int i = 0; i < list.Count; i++)
		{
			Point3D[] array2 = new Point3D[list[i].Length];
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = list[i][j]._0023_003DzvgtE4SU_003D;
			}
			array[i] = new LinearPath(array2);
		}
		return array;
	}

	private static ICurve[] _0023_003DzZ5omX40_003D(PlaneEquation _0023_003DzcpmWXV6_RKAxSjs1rCCcX4E_003D, IList<IndexTriangle> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, LinkedList<SharedEdge>[] _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D, out SharedEdge[][] _0023_003DzU3hosSAzkxO7)
	{
		List<_0023_003DzfKhYg_pIXj4J[]> list = _0023_003DzPp8HK942cFuX(_0023_003DzcpmWXV6_RKAxSjs1rCCcX4E_003D, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D, null);
		ICurve[] array = new ICurve[list.Count];
		_0023_003DzU3hosSAzkxO7 = new SharedEdge[list.Count][];
		for (int i = 0; i < list.Count; i++)
		{
			Point3D[] array2 = new Point3D[list[i].Length];
			_0023_003DzU3hosSAzkxO7[i] = new SharedEdge[array2.Length];
			SharedEdge[] array3 = _0023_003DzU3hosSAzkxO7[i];
			for (int j = 0; j < array2.Length; j++)
			{
				_0023_003DzfKhYg_pIXj4J _0023_003DzfKhYg_pIXj4J2 = list[i][j];
				array2[j] = _0023_003DzfKhYg_pIXj4J2._0023_003DzvgtE4SU_003D;
				array3[j] = _0023_003DzfKhYg_pIXj4J2._0023_003Dz_eYYYA0_003D;
			}
			array[i] = new LinearPath(array2);
		}
		return array;
	}

	private static List<_0023_003DzfKhYg_pIXj4J[]> _0023_003DzPp8HK942cFuX(PlaneEquation _0023_003DzcpmWXV6_RKAxSjs1rCCcX4E_003D, IList<IndexTriangle> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, LinkedList<SharedEdge>[] _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D, Octree _0023_003DzZDdOnHY_0024bfnc)
	{
		if (_0023_003DzZDdOnHY_0024bfnc != null)
		{
			_0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D = null;
			int[] array = _0023_003DzgDVTkNeHwdgQSqFjCaNBff9LMKYGKWhpUA_003D_003D(_0023_003DzcpmWXV6_RKAxSjs1rCCcX4E_003D, _0023_003DzZDdOnHY_0024bfnc.Root);
			IndexTriangle[] array2 = new IndexTriangle[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[array[i]];
			}
			_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D = array2;
		}
		_0023_003Dzzc0se7Kc60aD _0023_003Dz4zn204U_003D = new _0023_003Dzzc0se7Kc60aD();
		_0023_003DzJ_RTclI3ycMtHeNx7Q_003D_003D _0023_003Dzj3qWm4cWYbb = new _0023_003DzJ_RTclI3ycMtHeNx7Q_003D_003D();
		List<_0023_003DzczFDDB3cqe1d> list = _0023_003DzIX5nL4R1oEOGtHd7z_8md26xpCQK(_0023_003DzcpmWXV6_RKAxSjs1rCCcX4E_003D, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D);
		bool[] array3 = new bool[_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Count];
		List<_0023_003DzfKhYg_pIXj4J[]> list2 = new List<_0023_003DzfKhYg_pIXj4J[]>();
		_0023_003Dzb2uqYW3hL5d2GbahQmPa3VA_003D(list, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
		for (int j = 0; j < list.Count; j++)
		{
			for (; j < list.Count && list[j]._0023_003DznkPLPRg_003D; j++)
			{
			}
			if (j >= list.Count)
			{
				break;
			}
			_0023_003DzczFDDB3cqe1d _0023_003DzczFDDB3cqe1d2 = list[j];
			LinkedList<_0023_003DzfKhYg_pIXj4J> linkedList = null;
			LinkedList<_0023_003DzfKhYg_pIXj4J> linkedList2 = null;
			if (!array3[_0023_003DzczFDDB3cqe1d2._0023_003DzeyQd9LoOUlcN.Mum])
			{
				linkedList = _0023_003DzaPESqoeuHZB3(j, _0023_003DzczFDDB3cqe1d2._0023_003DzeyQd9LoOUlcN.Mum, list, array3, _0023_003Dz4zn204U_003D, _0023_003Dzj3qWm4cWYbb, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
			}
			if (_0023_003DzczFDDB3cqe1d2._0023_003DzeyQd9LoOUlcN.Dad != -1 && !array3[_0023_003DzczFDDB3cqe1d2._0023_003DzeyQd9LoOUlcN.Dad])
			{
				linkedList2 = _0023_003DzaPESqoeuHZB3(j, _0023_003DzczFDDB3cqe1d2._0023_003DzeyQd9LoOUlcN.Dad, list, array3, _0023_003Dz4zn204U_003D, _0023_003Dzj3qWm4cWYbb, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
			}
			bool _0023_003DzEXLcE10_003D = false;
			if (linkedList != null && linkedList.Count > 1)
			{
				_0023_003DzEXLcE10_003D = _0023_003DzpeLDEdc_003D(_0023_003DzcpmWXV6_RKAxSjs1rCCcX4E_003D, _0023_003DzczFDDB3cqe1d2, linkedList, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
			}
			else if (linkedList2 != null && linkedList2.Count > 1)
			{
				_0023_003DzEXLcE10_003D = _0023_003DzpeLDEdc_003D(_0023_003DzcpmWXV6_RKAxSjs1rCCcX4E_003D, _0023_003DzczFDDB3cqe1d2, linkedList2, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
			}
			if (linkedList != null && linkedList2 != null)
			{
				list2.Add(_0023_003DzBR4MC9dn5eOS(_0023_003DzbYLjU5qPSV45(linkedList, linkedList2), _0023_003DzEXLcE10_003D));
				continue;
			}
			if (linkedList != null)
			{
				list2.Add(_0023_003DzBR4MC9dn5eOS(linkedList, _0023_003DzEXLcE10_003D));
			}
			if (linkedList2 != null)
			{
				list2.Add(_0023_003DzBR4MC9dn5eOS(linkedList2, _0023_003DzEXLcE10_003D));
			}
		}
		return _0023_003DzNgi0DUbqXj_U(list2);
	}

	private static int[] _0023_003DzgDVTkNeHwdgQSqFjCaNBff9LMKYGKWhpUA_003D_003D(PlaneEquation _0023_003DzcpmWXV6_RKAxSjs1rCCcX4E_003D, QuadEntityDataNode _0023_003DzbUgHk7sxFxKe)
	{
		List<int> list = new List<int>();
		_0023_003DzbUgHk7sxFxKe.GetBoudingBox(out var boxMin, out var boxMax);
		if (_0023_003Dz_GLJw01PmbEPgEdC1w_003D_003D(_0023_003DzcpmWXV6_RKAxSjs1rCCcX4E_003D, (Point3D)boxMin, (Point3D)boxMax))
		{
			list.AddRange(_0023_003DzbUgHk7sxFxKe.ElementsIndices);
			if (_0023_003DzbUgHk7sxFxKe.HasChildren)
			{
				QuadEntityDataNode[] children = _0023_003DzbUgHk7sxFxKe.Children;
				foreach (QuadEntityDataNode _0023_003DzbUgHk7sxFxKe2 in children)
				{
					list.AddRange(_0023_003DzgDVTkNeHwdgQSqFjCaNBff9LMKYGKWhpUA_003D_003D(_0023_003DzcpmWXV6_RKAxSjs1rCCcX4E_003D, _0023_003DzbUgHk7sxFxKe2));
				}
			}
		}
		return list.ToArray();
	}

	private static bool _0023_003Dz_GLJw01PmbEPgEdC1w_003D_003D(PlaneEquation _0023_003DzcpmWXV6_RKAxSjs1rCCcX4E_003D, Point3D _0023_003DzDPcjoBJLcqli, Point3D _0023_003Dz_0024N_0024yKptW9BoC)
	{
		Point3D[] boundingBoxCorners = Utility.GetBoundingBoxCorners(_0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC);
		int num = Math.Sign(_0023_003DzcpmWXV6_RKAxSjs1rCCcX4E_003D.ValueAt(boundingBoxCorners[0]));
		for (int i = 1; i < 8; i++)
		{
			int num2 = Math.Sign(_0023_003DzcpmWXV6_RKAxSjs1rCCcX4E_003D.ValueAt(boundingBoxCorners[i]));
			if (num != num2)
			{
				return true;
			}
		}
		return false;
	}

	private static List<_0023_003DzfKhYg_pIXj4J[]> _0023_003DzNgi0DUbqXj_U(List<_0023_003DzfKhYg_pIXj4J[]> _0023_003Dzcv8o5nO25OjS)
	{
		List<_0023_003DzfKhYg_pIXj4J[]> list = new List<_0023_003DzfKhYg_pIXj4J[]>(_0023_003Dzcv8o5nO25OjS.Count);
		List<_0023_003DzfKhYg_pIXj4J[]> list2 = new List<_0023_003DzfKhYg_pIXj4J[]>();
		for (int i = 0; i < _0023_003Dzcv8o5nO25OjS.Count; i++)
		{
			_0023_003DzfKhYg_pIXj4J[] array = _0023_003Dzcv8o5nO25OjS[i];
			if (array[0] == array[^1])
			{
				list.Add(array);
			}
			else
			{
				list2.Add(array);
			}
		}
		if (list2.Count == 0)
		{
			return list;
		}
		while (list2.Count > 0)
		{
			_0023_003DzfKhYg_pIXj4J[] array2 = list2[0];
			bool flag = false;
			for (int j = 1; j < list2.Count; j++)
			{
				_0023_003DzfKhYg_pIXj4J[] array3 = list2[j];
				if (array2[0] == array3[0] || array2[0] == array3[^1] || array2[^1] == array3[0] || array2[^1] == array3[^1])
				{
					_0023_003DzfKhYg_pIXj4J[] value = _0023_003DzwwaTpjGZVwaYfqqggA_003D_003D(array2, array3);
					list2.RemoveAt(j);
					list2[0] = value;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				list.Add(list2[0]);
				list2.RemoveAt(0);
			}
		}
		return list;
	}

	private static _0023_003DzfKhYg_pIXj4J[] _0023_003DzwwaTpjGZVwaYfqqggA_003D_003D(_0023_003DzfKhYg_pIXj4J[] _0023_003DzRI5QzVc_003D, _0023_003DzfKhYg_pIXj4J[] _0023_003DztuiZ_54_003D)
	{
		List<_0023_003DzfKhYg_pIXj4J> list = new List<_0023_003DzfKhYg_pIXj4J>(_0023_003DzRI5QzVc_003D);
		List<_0023_003DzfKhYg_pIXj4J> list2 = new List<_0023_003DzfKhYg_pIXj4J>(_0023_003DztuiZ_54_003D);
		if (list[0] == list2[0])
		{
			list2.Reverse();
			list2.AddRange(list.GetRange(1, list.Count - 1));
			return list2.ToArray();
		}
		if (list[0] == list2[list2.Count - 1])
		{
			list2.AddRange(list.GetRange(1, list.Count - 1));
			return list2.ToArray();
		}
		if (list[list.Count - 1] == list2[0])
		{
			list.AddRange(list2.GetRange(1, list2.Count - 1));
			return list.ToArray();
		}
		if (list[list.Count - 1] == list2[list2.Count - 1])
		{
			list2.Reverse();
			list.AddRange(list2.GetRange(1, list2.Count - 1));
			return list.ToArray();
		}
		return null;
	}

	private static void _0023_003Dzb2uqYW3hL5d2GbahQmPa3VA_003D(List<_0023_003DzczFDDB3cqe1d> _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D, IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		for (int i = 0; i < _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D.Count; i++)
		{
			_0023_003DzczFDDB3cqe1d _0023_003DzczFDDB3cqe1d2 = _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D[i];
			if (_0023_003DzczFDDB3cqe1d2._0023_003DzJslIhmvq8gUMNVPkXdW9GPU_003D == (_0023_003DzbH4ZsoQ_003D)1 || _0023_003DzczFDDB3cqe1d2._0023_003DzJslIhmvq8gUMNVPkXdW9GPU_003D == (_0023_003DzbH4ZsoQ_003D)2)
			{
				_0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D[i]._0023_003DznkPLPRg_003D = true;
			}
		}
	}

	private static List<int> _0023_003DzU7TmvVswG3Hhafzd82CnPU0_003D(IndexTriangle _0023_003DzEzv5_0024vo_003D)
	{
		int v = _0023_003DzEzv5_0024vo_003D.V1;
		int v2 = _0023_003DzEzv5_0024vo_003D.V2;
		int v3 = _0023_003DzEzv5_0024vo_003D.V3;
		List<int> list = new List<int>(new int[3] { v, v2, v3 });
		list.Sort();
		return list;
	}

	private static void _0023_003Dz5bVb3UsiPKPk(int _0023_003Dzhcsretw_003D, List<_0023_003DzczFDDB3cqe1d> _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D, IComparer<_0023_003DzczFDDB3cqe1d> _0023_003Dz4zn204U_003D, IList<IndexTriangle> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D)
	{
		List<int> list = _0023_003DzU7TmvVswG3Hhafzd82CnPU0_003D(_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[_0023_003Dzhcsretw_003D]);
		_0023_003DzczFDDB3cqe1d obj = new _0023_003DzczFDDB3cqe1d();
		obj._0023_003DzQW_0024hBdI_003D = list[0];
		obj._0023_003DzFITvoaXugyss(list[1]);
		_0023_003Dzwe_wOmt4m1cmBRdq6A_003D_003D(obj, _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D, _0023_003Dz4zn204U_003D);
		obj._0023_003DzFITvoaXugyss(list[2]);
		_0023_003Dzwe_wOmt4m1cmBRdq6A_003D_003D(obj, _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D, _0023_003Dz4zn204U_003D);
		obj._0023_003DzQW_0024hBdI_003D = list[1];
		_0023_003Dzwe_wOmt4m1cmBRdq6A_003D_003D(obj, _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D, _0023_003Dz4zn204U_003D);
	}

	private static void _0023_003Dzwe_wOmt4m1cmBRdq6A_003D_003D(_0023_003DzczFDDB3cqe1d _0023_003DzTx2aqr8_003D, List<_0023_003DzczFDDB3cqe1d> _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D, IComparer<_0023_003DzczFDDB3cqe1d> _0023_003Dz4zn204U_003D)
	{
		int num = _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D.BinarySearch(_0023_003DzTx2aqr8_003D, _0023_003Dz4zn204U_003D);
		if (num >= 0 && _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D[num]._0023_003DzJslIhmvq8gUMNVPkXdW9GPU_003D != 0)
		{
			_0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D[num]._0023_003DznkPLPRg_003D = true;
		}
	}

	private static bool _0023_003DzpeLDEdc_003D(PlaneEquation _0023_003DzcpmWXV6_RKAxSjs1rCCcX4E_003D, _0023_003DzczFDDB3cqe1d _0023_003DzTx2aqr8_003D, LinkedList<_0023_003DzfKhYg_pIXj4J> _0023_003DzRI5QzVc_003D, IList<IndexTriangle> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		bool result = false;
		IndexTriangle indexTriangle = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[_0023_003DzTx2aqr8_003D._0023_003DzeyQd9LoOUlcN.Mum];
		int[] array = new int[3] { indexTriangle.V1, indexTriangle.V2, indexTriangle.V3 };
		Point3D _0023_003DzvgtE4SU_003D = _0023_003DzRI5QzVc_003D.First.Value._0023_003DzvgtE4SU_003D;
		Vector3D vector3D = Vector3D.Cross(Vector3D.Subtract(_0023_003DzRI5QzVc_003D.First.Next.Value._0023_003DzvgtE4SU_003D, _0023_003DzvgtE4SU_003D), new Vector3D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[array[0]], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[array[1]], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[array[2]]));
		if (new Plane(new double[4]
		{
			_0023_003DzcpmWXV6_RKAxSjs1rCCcX4E_003D[0],
			_0023_003DzcpmWXV6_RKAxSjs1rCCcX4E_003D[1],
			_0023_003DzcpmWXV6_RKAxSjs1rCCcX4E_003D[2],
			0.0
		}).DistanceTo(vector3D.AsPoint) >= 0.0)
		{
			result = true;
		}
		return result;
	}

	private static List<_0023_003DzczFDDB3cqe1d> _0023_003DzIX5nL4R1oEOGtHd7z_8md26xpCQK(PlaneEquation _0023_003DzcpmWXV6_RKAxSjs1rCCcX4E_003D, IList<IndexTriangle> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, LinkedList<SharedEdge>[] _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D)
	{
		if (_0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D == null)
		{
			Utility.GetEdgesWithoutDuplicates(_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count, out _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D);
		}
		List<_0023_003DzczFDDB3cqe1d> list = new List<_0023_003DzczFDDB3cqe1d>(_0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D.Length);
		Segment3D segment3D = new Segment3D();
		Plane plane = new Plane(_0023_003DzcpmWXV6_RKAxSjs1rCCcX4E_003D.ToArray());
		List<_0023_003DzczFDDB3cqe1d> list2 = new List<_0023_003DzczFDDB3cqe1d>();
		for (int i = 0; i < _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D.Length; i++)
		{
			list2.Clear();
			segment3D.P0 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i];
			for (LinkedListNode<SharedEdge> linkedListNode = _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D[i].First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				segment3D.P1 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[linkedListNode.Value.V2];
				Point3D _0023_003DzLos_0024H_dHfIKMMA5CKrpAhoU_003D;
				_0023_003DzbH4ZsoQ_003D _0023_003DzbH4ZsoQ_003D2 = _0023_003Dznzn_D3eBzHm4(segment3D, _0023_003DzcpmWXV6_RKAxSjs1rCCcX4E_003D, out _0023_003DzLos_0024H_dHfIKMMA5CKrpAhoU_003D);
				switch (_0023_003DzbH4ZsoQ_003D2)
				{
				default:
					list2.Add(new _0023_003DzczFDDB3cqe1d(i, _0023_003DzLos_0024H_dHfIKMMA5CKrpAhoU_003D, _0023_003DzbH4ZsoQ_003D2, linkedListNode.Value));
					break;
				case (_0023_003DzbH4ZsoQ_003D)0:
				{
					double num = 1E-12;
					if (!(Math.Abs(plane.DistanceTo(segment3D.P0)) < num) || !(Math.Abs(plane.DistanceTo(segment3D.P1)) < num))
					{
						break;
					}
					int index = _0023_003DzLu6WxTx_FKUE(_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[linkedListNode.Value.Mum], i, linkedListNode.Value.V2);
					if (!(Math.Abs(plane.DistanceTo(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[index])) < num))
					{
						list2.Add(new _0023_003DzczFDDB3cqe1d(i, null, (_0023_003DzbH4ZsoQ_003D)0, linkedListNode.Value));
					}
					else if (linkedListNode.Value.Dad >= 0)
					{
						index = _0023_003DzLu6WxTx_FKUE(_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[linkedListNode.Value.Dad], i, linkedListNode.Value.V2);
						if (!(Math.Abs(plane.DistanceTo(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[index])) < num))
						{
							list2.Add(new _0023_003DzczFDDB3cqe1d(i, null, (_0023_003DzbH4ZsoQ_003D)0, linkedListNode.Value));
						}
					}
					break;
				}
				case (_0023_003DzbH4ZsoQ_003D)4:
					break;
				}
			}
			list.AddRange(list2.OrderBy((_0023_003DzczFDDB3cqe1d _0023_003DzGcl_0024E9o_003D) => _0023_003DzGcl_0024E9o_003D._0023_003DzLXzfFx__0024a_DT()));
		}
		return list;
	}

	private static _0023_003DzbH4ZsoQ_003D _0023_003Dznzn_D3eBzHm4(Segment3D _0023_003DzFDJdA7A_003D, PlaneEquation _0023_003DzcpmWXV6_RKAxSjs1rCCcX4E_003D, out Point3D _0023_003DzLos_0024H_dHfIKMMA5CKrpAhoU_003D)
	{
		_0023_003DzLos_0024H_dHfIKMMA5CKrpAhoU_003D = null;
		Vector3D vector3D = Vector3D.Subtract(_0023_003DzFDJdA7A_003D.P1, _0023_003DzFDJdA7A_003D.P0);
		double num = _0023_003DzcpmWXV6_RKAxSjs1rCCcX4E_003D * vector3D;
		double num2 = 1E-12;
		if (Math.Abs(num) < num2 * vector3D.Length)
		{
			return (_0023_003DzbH4ZsoQ_003D)0;
		}
		double num3 = (0.0 - _0023_003DzcpmWXV6_RKAxSjs1rCCcX4E_003D.ValueAt(_0023_003DzFDJdA7A_003D.P0)) / num;
		num2 /= Math.Abs(num);
		if (num3 <= num2 || num3 >= 1.0 - num2)
		{
			if (num3 >= 0.0 - num2 && num3 <= num2)
			{
				return (_0023_003DzbH4ZsoQ_003D)1;
			}
			if (num3 >= 1.0 - num2 && num3 <= 1.0 + num2)
			{
				return (_0023_003DzbH4ZsoQ_003D)2;
			}
			return (_0023_003DzbH4ZsoQ_003D)4;
		}
		_0023_003DzLos_0024H_dHfIKMMA5CKrpAhoU_003D = _0023_003DzFDJdA7A_003D.P0 + num3 * vector3D;
		return (_0023_003DzbH4ZsoQ_003D)3;
	}

	private static int _0023_003DzLu6WxTx_FKUE(IndexTriangle _0023_003DzEzv5_0024vo_003D, int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D)
	{
		if (_0023_003DzEzv5_0024vo_003D.V1 != _0023_003DzffqPLNQ_003D && _0023_003DzEzv5_0024vo_003D.V1 != _0023_003Dz5Azd7L8_003D)
		{
			return _0023_003DzEzv5_0024vo_003D.V1;
		}
		if (_0023_003DzEzv5_0024vo_003D.V2 != _0023_003DzffqPLNQ_003D && _0023_003DzEzv5_0024vo_003D.V2 != _0023_003Dz5Azd7L8_003D)
		{
			return _0023_003DzEzv5_0024vo_003D.V2;
		}
		return _0023_003DzEzv5_0024vo_003D.V3;
	}

	private static T[] _0023_003DzBR4MC9dn5eOS<T>(LinkedList<T> _0023_003DzdEvMFOw_003D, bool _0023_003DzEXLcE10_003D) where T : class
	{
		T[] array = new T[_0023_003DzdEvMFOw_003D.Count];
		_0023_003DzdEvMFOw_003D.CopyTo(array, 0);
		if (_0023_003DzEXLcE10_003D)
		{
			List<T> list = new List<T>(array);
			list.Reverse();
			array = list.ToArray();
		}
		return array;
	}

	private static LinkedList<_0023_003DzfKhYg_pIXj4J> _0023_003DzbYLjU5qPSV45(LinkedList<_0023_003DzfKhYg_pIXj4J> _0023_003DzRI5QzVc_003D, LinkedList<_0023_003DzfKhYg_pIXj4J> _0023_003DztuiZ_54_003D)
	{
		LinkedListNode<_0023_003DzfKhYg_pIXj4J> linkedListNode = _0023_003DztuiZ_54_003D.First;
		if (linkedListNode != null)
		{
			linkedListNode = linkedListNode.Next;
		}
		while (linkedListNode != null)
		{
			_0023_003DzRI5QzVc_003D.AddFirst(new LinkedListNode<_0023_003DzfKhYg_pIXj4J>(linkedListNode.Value));
			linkedListNode = linkedListNode.Next;
		}
		return _0023_003DzRI5QzVc_003D;
	}

	private static LinkedList<_0023_003DzfKhYg_pIXj4J> _0023_003DzaPESqoeuHZB3(int _0023_003DzL8NvYU0_003D, int _0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D, List<_0023_003DzczFDDB3cqe1d> _0023_003Dz3l8Vzo3f9xxiZHWqc7CFRCJ1R3am, bool[] _0023_003DzDM7m0UVALDOJZopb9Q_003D_003D, IComparer<_0023_003DzczFDDB3cqe1d> _0023_003Dz4zn204U_003D, _0023_003DzJ_RTclI3ycMtHeNx7Q_003D_003D _0023_003Dzj3qWm4cWYbb3, IList<IndexTriangle> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		if (_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D < 0)
		{
			return null;
		}
		_0023_003DzczFDDB3cqe1d _0023_003DzTx2aqr8_003D = _0023_003Dz3l8Vzo3f9xxiZHWqc7CFRCJ1R3am[_0023_003DzL8NvYU0_003D];
		LinkedList<_0023_003DzfKhYg_pIXj4J> linkedList = new LinkedList<_0023_003DzfKhYg_pIXj4J>();
		linkedList.AddLast(new _0023_003DzfKhYg_pIXj4J(_0023_003DzBRGKWPU_003D(_0023_003DzTx2aqr8_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D), _0023_003DzTx2aqr8_003D._0023_003DzeyQd9LoOUlcN));
		if (_0023_003DzDM7m0UVALDOJZopb9Q_003D_003D[_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D])
		{
			return null;
		}
		while (_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D >= 0)
		{
			_0023_003DzDM7m0UVALDOJZopb9Q_003D_003D[_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D] = true;
			if (_0023_003DzTx2aqr8_003D._0023_003DzVrp7M3MhiVzGD__KAw_003D_003D())
			{
				if (_0023_003Dz3l8Vzo3f9xxiZHWqc7CFRCJ1R3am[_0023_003DzL8NvYU0_003D]._0023_003DznkPLPRg_003D)
				{
					break;
				}
				_0023_003DzbIDY9BOTPqfc(linkedList, new _0023_003DzfKhYg_pIXj4J((Point3D)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTx2aqr8_003D._0023_003DzLXzfFx__0024a_DT()].Clone(), _0023_003DzTx2aqr8_003D._0023_003DzeyQd9LoOUlcN));
				_0023_003Dz3l8Vzo3f9xxiZHWqc7CFRCJ1R3am[_0023_003DzL8NvYU0_003D]._0023_003DznkPLPRg_003D = true;
				int mum = _0023_003DzTx2aqr8_003D._0023_003DzeyQd9LoOUlcN.Mum;
				int dad = _0023_003DzTx2aqr8_003D._0023_003DzeyQd9LoOUlcN.Dad;
				if (mum >= 0)
				{
					_0023_003DzDM7m0UVALDOJZopb9Q_003D_003D[mum] = true;
					_0023_003Dz5bVb3UsiPKPk(mum, _0023_003Dz3l8Vzo3f9xxiZHWqc7CFRCJ1R3am, _0023_003Dz4zn204U_003D, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D);
				}
				if (dad >= 0)
				{
					_0023_003DzDM7m0UVALDOJZopb9Q_003D_003D[dad] = true;
					_0023_003Dz5bVb3UsiPKPk(dad, _0023_003Dz3l8Vzo3f9xxiZHWqc7CFRCJ1R3am, _0023_003Dz4zn204U_003D, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D);
				}
				_0023_003DzL8NvYU0_003D = _0023_003DzX_UWR0sTf8rR(_0023_003Dz3l8Vzo3f9xxiZHWqc7CFRCJ1R3am, _0023_003DzTx2aqr8_003D, _0023_003Dzj3qWm4cWYbb3);
				if (_0023_003DzL8NvYU0_003D < 0)
				{
					break;
				}
				_0023_003DzTx2aqr8_003D = _0023_003Dz3l8Vzo3f9xxiZHWqc7CFRCJ1R3am[_0023_003DzL8NvYU0_003D];
				if (!_0023_003DzTx2aqr8_003D._0023_003DzVrp7M3MhiVzGD__KAw_003D_003D())
				{
					_0023_003DzbIDY9BOTPqfc(linkedList, new _0023_003DzfKhYg_pIXj4J(_0023_003DzBRGKWPU_003D(_0023_003DzTx2aqr8_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D), _0023_003DzTx2aqr8_003D._0023_003DzeyQd9LoOUlcN));
					_0023_003Dz3l8Vzo3f9xxiZHWqc7CFRCJ1R3am[_0023_003DzL8NvYU0_003D]._0023_003DznkPLPRg_003D = true;
					LinkedList<_0023_003DzfKhYg_pIXj4J> linkedList2 = null;
					linkedList2 = _0023_003DzaPESqoeuHZB3(_0023_003DzL8NvYU0_003D, _0023_003DzTx2aqr8_003D._0023_003DzeyQd9LoOUlcN.Mum, _0023_003Dz3l8Vzo3f9xxiZHWqc7CFRCJ1R3am, _0023_003DzDM7m0UVALDOJZopb9Q_003D_003D, _0023_003Dz4zn204U_003D, _0023_003Dzj3qWm4cWYbb3, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
					if (linkedList2 == null)
					{
						linkedList2 = _0023_003DzaPESqoeuHZB3(_0023_003DzL8NvYU0_003D, _0023_003DzTx2aqr8_003D._0023_003DzeyQd9LoOUlcN.Dad, _0023_003Dz3l8Vzo3f9xxiZHWqc7CFRCJ1R3am, _0023_003DzDM7m0UVALDOJZopb9Q_003D_003D, _0023_003Dz4zn204U_003D, _0023_003Dzj3qWm4cWYbb3, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
					}
					if (linkedList2 != null)
					{
						for (LinkedListNode<_0023_003DzfKhYg_pIXj4J> linkedListNode = linkedList2.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
						{
							_0023_003DzbIDY9BOTPqfc(linkedList, linkedListNode.Value);
						}
					}
					return linkedList;
				}
				_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D = _0023_003DzTx2aqr8_003D._0023_003DzeyQd9LoOUlcN.Mum;
			}
			else
			{
				_0023_003DzL8NvYU0_003D = _0023_003Dze8B47vlwxlqNb95ED6zGHAd7XrbeyAn1qg_003D_003D(_0023_003DzTx2aqr8_003D, _0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D, _0023_003Dz3l8Vzo3f9xxiZHWqc7CFRCJ1R3am, _0023_003Dz4zn204U_003D, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
				if (_0023_003DzL8NvYU0_003D < 0)
				{
					break;
				}
				_0023_003DzTx2aqr8_003D = _0023_003Dz3l8Vzo3f9xxiZHWqc7CFRCJ1R3am[_0023_003DzL8NvYU0_003D];
				bool _0023_003DznkPLPRg_003D = _0023_003DzTx2aqr8_003D._0023_003DznkPLPRg_003D;
				if (!_0023_003DzTx2aqr8_003D._0023_003DzVrp7M3MhiVzGD__KAw_003D_003D())
				{
					_0023_003DzTx2aqr8_003D._0023_003DznkPLPRg_003D = true;
				}
				_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D = ((_0023_003DzTx2aqr8_003D._0023_003DzeyQd9LoOUlcN.Mum != _0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D) ? _0023_003DzTx2aqr8_003D._0023_003DzeyQd9LoOUlcN.Mum : _0023_003DzTx2aqr8_003D._0023_003DzeyQd9LoOUlcN.Dad);
				_0023_003DzbIDY9BOTPqfc(linkedList, new _0023_003DzfKhYg_pIXj4J(_0023_003DzBRGKWPU_003D(_0023_003DzTx2aqr8_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D), _0023_003DzTx2aqr8_003D._0023_003DzeyQd9LoOUlcN));
				if (_0023_003DznkPLPRg_003D || (!_0023_003DzTx2aqr8_003D._0023_003DzVrp7M3MhiVzGD__KAw_003D_003D() && (((_0023_003DzTx2aqr8_003D._0023_003DzJslIhmvq8gUMNVPkXdW9GPU_003D == (_0023_003DzbH4ZsoQ_003D)1 || _0023_003DzTx2aqr8_003D._0023_003DzJslIhmvq8gUMNVPkXdW9GPU_003D == (_0023_003DzbH4ZsoQ_003D)2) && (_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D == -1 || _0023_003DzDM7m0UVALDOJZopb9Q_003D_003D[_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D]) && !_0023_003DzGY2qZ9FfHb6ihYt5rypVVfg_003D(_0023_003Dz3l8Vzo3f9xxiZHWqc7CFRCJ1R3am, ref _0023_003DzL8NvYU0_003D, ref _0023_003DzTx2aqr8_003D, ref _0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D, _0023_003DzDM7m0UVALDOJZopb9Q_003D_003D, _0023_003Dzj3qWm4cWYbb3, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)) || _0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D == -1 || _0023_003DzDM7m0UVALDOJZopb9Q_003D_003D[_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D])))
				{
					break;
				}
			}
		}
		if (linkedList.Count == 1)
		{
			return null;
		}
		if (linkedList.First.Value == linkedList.Last.Value)
		{
			linkedList.Last.Value = (_0023_003DzfKhYg_pIXj4J)linkedList.Last.Value.Clone();
		}
		return linkedList;
	}

	private static Point3D _0023_003DzBRGKWPU_003D(_0023_003DzczFDDB3cqe1d _0023_003DzTx2aqr8_003D, IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		return _0023_003DzTx2aqr8_003D._0023_003DzJslIhmvq8gUMNVPkXdW9GPU_003D switch
		{
			(_0023_003DzbH4ZsoQ_003D)3 => _0023_003DzTx2aqr8_003D._0023_003DzIpT00fBdiZkkG9dah6hKpLk_003D, 
			(_0023_003DzbH4ZsoQ_003D)1 => (Point3D)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTx2aqr8_003D._0023_003DzQW_0024hBdI_003D].Clone(), 
			(_0023_003DzbH4ZsoQ_003D)2 => (Point3D)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTx2aqr8_003D._0023_003DzLXzfFx__0024a_DT()].Clone(), 
			(_0023_003DzbH4ZsoQ_003D)0 => (Point3D)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTx2aqr8_003D._0023_003DzQW_0024hBdI_003D].Clone(), 
			_ => throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972492)), 
		};
	}

	private static bool _0023_003DzGY2qZ9FfHb6ihYt5rypVVfg_003D(List<_0023_003DzczFDDB3cqe1d> _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D, ref int _0023_003DzL8NvYU0_003D, ref _0023_003DzczFDDB3cqe1d _0023_003DzTx2aqr8_003D, ref int _0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D, bool[] _0023_003DzAQKXeuJdfZLdtXCO4A_003D_003D, _0023_003DzJ_RTclI3ycMtHeNx7Q_003D_003D _0023_003Dzj3qWm4cWYbb3, IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		int num;
		if (_0023_003DzTx2aqr8_003D._0023_003DzJslIhmvq8gUMNVPkXdW9GPU_003D == (_0023_003DzbH4ZsoQ_003D)1)
		{
			num = _0023_003DzTx2aqr8_003D._0023_003DzQW_0024hBdI_003D;
		}
		else
		{
			num = _0023_003DzTx2aqr8_003D._0023_003DzLXzfFx__0024a_DT();
			_0023_003DzczFDDB3cqe1d _0023_003DzczFDDB3cqe1d2 = new _0023_003DzczFDDB3cqe1d();
			_0023_003DzczFDDB3cqe1d2._0023_003DzQW_0024hBdI_003D = num;
			_0023_003DzL8NvYU0_003D = _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D.BinarySearch(_0023_003DzczFDDB3cqe1d2, _0023_003Dzj3qWm4cWYbb3);
			if (_0023_003DzL8NvYU0_003D < 0)
			{
				return false;
			}
			_0023_003DzTx2aqr8_003D = _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D[_0023_003DzL8NvYU0_003D];
		}
		_0023_003DzdQGAHKMP_G30(_0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D, num, _0023_003DzL8NvYU0_003D, out var _0023_003Dzb9Descs_003D, out var _0023_003Dzz5Z8Ang_003D);
		for (int i = _0023_003Dzb9Descs_003D; i < _0023_003Dzz5Z8Ang_003D; i++)
		{
			_0023_003DzczFDDB3cqe1d _0023_003DzczFDDB3cqe1d3 = _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D[i];
			int mum = _0023_003DzczFDDB3cqe1d3._0023_003DzeyQd9LoOUlcN.Mum;
			if (!_0023_003DzAQKXeuJdfZLdtXCO4A_003D_003D[mum])
			{
				_0023_003DzTx2aqr8_003D = _0023_003DzczFDDB3cqe1d3;
				_0023_003DzL8NvYU0_003D = i;
				_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D = mum;
				return true;
			}
			mum = _0023_003DzczFDDB3cqe1d3._0023_003DzeyQd9LoOUlcN.Dad;
			if (mum >= 0 && !_0023_003DzAQKXeuJdfZLdtXCO4A_003D_003D[mum])
			{
				_0023_003DzTx2aqr8_003D = _0023_003DzczFDDB3cqe1d3;
				_0023_003DzL8NvYU0_003D = i;
				_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D = mum;
				return true;
			}
		}
		return false;
	}

	private static int _0023_003DzX_UWR0sTf8rR(List<_0023_003DzczFDDB3cqe1d> _0023_003Dz3l8Vzo3f9xxiZHWqc7CFRCJ1R3am, _0023_003DzczFDDB3cqe1d _0023_003Dz92qmRCfh8pOU, _0023_003DzJ_RTclI3ycMtHeNx7Q_003D_003D _0023_003Dzj3qWm4cWYbb3)
	{
		_0023_003DzczFDDB3cqe1d _0023_003DzczFDDB3cqe1d2 = new _0023_003DzczFDDB3cqe1d();
		_0023_003DzczFDDB3cqe1d2._0023_003DzQW_0024hBdI_003D = _0023_003Dz92qmRCfh8pOU._0023_003DzLXzfFx__0024a_DT();
		int num = _0023_003Dz3l8Vzo3f9xxiZHWqc7CFRCJ1R3am.BinarySearch(_0023_003DzczFDDB3cqe1d2, _0023_003Dzj3qWm4cWYbb3);
		if (num < 0)
		{
			return -1;
		}
		_0023_003DzdQGAHKMP_G30(_0023_003Dz3l8Vzo3f9xxiZHWqc7CFRCJ1R3am, _0023_003DzczFDDB3cqe1d2._0023_003DzQW_0024hBdI_003D, num, out var _0023_003Dzb9Descs_003D, out var _0023_003Dzz5Z8Ang_003D);
		for (int i = _0023_003Dzb9Descs_003D; i < _0023_003Dzz5Z8Ang_003D; i++)
		{
			if (!_0023_003Dz3l8Vzo3f9xxiZHWqc7CFRCJ1R3am[i]._0023_003DznkPLPRg_003D && _0023_003Dz3l8Vzo3f9xxiZHWqc7CFRCJ1R3am[i]._0023_003DzVrp7M3MhiVzGD__KAw_003D_003D())
			{
				return i;
			}
		}
		for (int j = _0023_003Dzb9Descs_003D; j < _0023_003Dzz5Z8Ang_003D; j++)
		{
			if (!_0023_003Dz3l8Vzo3f9xxiZHWqc7CFRCJ1R3am[j]._0023_003DznkPLPRg_003D)
			{
				return j;
			}
		}
		return -1;
	}

	private static void _0023_003DzdQGAHKMP_G30(List<_0023_003DzczFDDB3cqe1d> _0023_003Dz3l8Vzo3f9xxiZHWqc7CFRCJ1R3am, int _0023_003DzcJpaJQAcgoDn, int _0023_003DzCREyuzFnGFhJ, out int _0023_003Dzb9Descs_003D, out int _0023_003Dzz5Z8Ang_003D)
	{
		int num = _0023_003DzCREyuzFnGFhJ;
		while (num >= 0 && _0023_003Dz3l8Vzo3f9xxiZHWqc7CFRCJ1R3am[num]._0023_003DzQW_0024hBdI_003D == _0023_003DzcJpaJQAcgoDn)
		{
			num--;
		}
		_0023_003Dzb9Descs_003D = num + 1;
		for (num = _0023_003DzCREyuzFnGFhJ; num < _0023_003Dz3l8Vzo3f9xxiZHWqc7CFRCJ1R3am.Count && _0023_003Dz3l8Vzo3f9xxiZHWqc7CFRCJ1R3am[num]._0023_003DzQW_0024hBdI_003D == _0023_003DzcJpaJQAcgoDn; num++)
		{
		}
		_0023_003Dzz5Z8Ang_003D = num;
	}

	private static void _0023_003DzbIDY9BOTPqfc(LinkedList<_0023_003DzfKhYg_pIXj4J> _0023_003DzdEvMFOw_003D, _0023_003DzfKhYg_pIXj4J _0023_003DzMlCq3wk_003D)
	{
		if (_0023_003DzdEvMFOw_003D.Last.Value._0023_003DzvgtE4SU_003D != _0023_003DzMlCq3wk_003D._0023_003DzvgtE4SU_003D)
		{
			_0023_003DzdEvMFOw_003D.AddLast(_0023_003DzMlCq3wk_003D);
		}
	}

	private static void _0023_003DzbIDY9BOTPqfc(LinkedList<Point3D> _0023_003DzdEvMFOw_003D, Point3D _0023_003DzMlCq3wk_003D)
	{
		if (_0023_003DzdEvMFOw_003D.Last.Value != _0023_003DzMlCq3wk_003D)
		{
			_0023_003DzdEvMFOw_003D.AddLast(_0023_003DzMlCq3wk_003D);
		}
	}

	private static int _0023_003Dze8B47vlwxlqNb95ED6zGHAd7XrbeyAn1qg_003D_003D(_0023_003DzczFDDB3cqe1d _0023_003Dz92qmRCfh8pOU, int _0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D, List<_0023_003DzczFDDB3cqe1d> _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D, IComparer<_0023_003DzczFDDB3cqe1d> _0023_003Dz4zn204U_003D, IList<IndexTriangle> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		List<int> list = _0023_003DzU7TmvVswG3Hhafzd82CnPU0_003D(_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D]);
		_0023_003DzczFDDB3cqe1d _0023_003DzczFDDB3cqe1d2 = new _0023_003DzczFDDB3cqe1d();
		_0023_003DzczFDDB3cqe1d _0023_003DzczFDDB3cqe1d3 = new _0023_003DzczFDDB3cqe1d();
		if (_0023_003Dz92qmRCfh8pOU._0023_003DzQW_0024hBdI_003D == list[0])
		{
			_0023_003DzczFDDB3cqe1d2._0023_003DzQW_0024hBdI_003D = _0023_003Dz92qmRCfh8pOU._0023_003DzQW_0024hBdI_003D;
			if (list[1] != _0023_003Dz92qmRCfh8pOU._0023_003DzLXzfFx__0024a_DT())
			{
				_0023_003DzczFDDB3cqe1d2._0023_003DzFITvoaXugyss(list[1]);
			}
			else
			{
				_0023_003DzczFDDB3cqe1d2._0023_003DzFITvoaXugyss(list[2]);
			}
			_0023_003DzczFDDB3cqe1d3._0023_003DzQW_0024hBdI_003D = list[1];
			_0023_003DzczFDDB3cqe1d3._0023_003DzFITvoaXugyss(list[2]);
		}
		else
		{
			_0023_003DzczFDDB3cqe1d2._0023_003DzQW_0024hBdI_003D = list[0];
			_0023_003DzczFDDB3cqe1d2._0023_003DzFITvoaXugyss(_0023_003Dz92qmRCfh8pOU._0023_003DzQW_0024hBdI_003D);
			_0023_003DzczFDDB3cqe1d3._0023_003DzQW_0024hBdI_003D = list[0];
			_0023_003DzczFDDB3cqe1d3._0023_003DzFITvoaXugyss(_0023_003Dz92qmRCfh8pOU._0023_003DzLXzfFx__0024a_DT());
		}
		int num = _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D.BinarySearch(_0023_003DzczFDDB3cqe1d2, _0023_003Dz4zn204U_003D);
		if (num >= 0 && _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D[num]._0023_003DznkPLPRg_003D)
		{
			num = -1;
		}
		if (num < 0)
		{
			num = _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D.BinarySearch(_0023_003DzczFDDB3cqe1d3, _0023_003Dz4zn204U_003D);
		}
		else
		{
			int num2 = _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D.BinarySearch(_0023_003DzczFDDB3cqe1d3, _0023_003Dz4zn204U_003D);
			if (num2 >= 0)
			{
				if (_0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D[num2]._0023_003DznkPLPRg_003D)
				{
					return num;
				}
				_0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D[num2]._0023_003DznkPLPRg_003D = true;
				if (_0023_003DzMAxShrbxTEQp(_0023_003DzBRGKWPU_003D(_0023_003Dz92qmRCfh8pOU, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D), _0023_003DzBRGKWPU_003D(_0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D[num], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)))
				{
					return num2;
				}
			}
		}
		return num;
	}

	private static bool _0023_003DzMAxShrbxTEQp(Point3D _0023_003DzMEwtr_A_003D, Point3D _0023_003DzW7Zyxfc_003D)
	{
		return Vector3D.Subtract(_0023_003DzMEwtr_A_003D, _0023_003DzW7Zyxfc_003D).Length < 1E-12;
	}

	private void _0023_003Dz6FVo1EVGieA1UO_0024jbXLOFBmfxNTQ(IndexTriangle _0023_003DzEzv5_0024vo_003D, List<_0023_003DzczFDDB3cqe1d> _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D, _0023_003Dzzc0se7Kc60aD _0023_003DzWFIcsB57XAY2YQ1Yo4Aklmk_003D, _0023_003DzczFDDB3cqe1d _0023_003DzgIhGu6_0024iUVb6, _0023_003DzczFDDB3cqe1d _0023_003DzHYHZCcD7_0024bKS, List<int> _0023_003DzCIOR5ZGHjiSXHLzQYA_003D_003D, out int _0023_003DzCYlGuqc_003D, out int _0023_003DzM9DHoIE_003D)
	{
		_0023_003DzCIOR5ZGHjiSXHLzQYA_003D_003D.Clear();
		_0023_003DzCIOR5ZGHjiSXHLzQYA_003D_003D.Add(_0023_003DzEzv5_0024vo_003D.V1);
		_0023_003DzCIOR5ZGHjiSXHLzQYA_003D_003D.Add(_0023_003DzEzv5_0024vo_003D.V2);
		_0023_003DzCIOR5ZGHjiSXHLzQYA_003D_003D.Add(_0023_003DzEzv5_0024vo_003D.V3);
		_0023_003DzCIOR5ZGHjiSXHLzQYA_003D_003D.Sort();
		int _0023_003DzQW_0024hBdI_003D = _0023_003DzCIOR5ZGHjiSXHLzQYA_003D_003D[0];
		int num = _0023_003DzCIOR5ZGHjiSXHLzQYA_003D_003D[1];
		int _0023_003DzPzO_0024GUk_003D = _0023_003DzCIOR5ZGHjiSXHLzQYA_003D_003D[2];
		_0023_003DzgIhGu6_0024iUVb6._0023_003DzQW_0024hBdI_003D = _0023_003DzQW_0024hBdI_003D;
		_0023_003DzgIhGu6_0024iUVb6._0023_003DzFITvoaXugyss(num);
		_0023_003DzCYlGuqc_003D = _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D.BinarySearch(_0023_003DzgIhGu6_0024iUVb6, _0023_003DzWFIcsB57XAY2YQ1Yo4Aklmk_003D);
		_0023_003DzM9DHoIE_003D = -1;
		if (_0023_003DzCYlGuqc_003D >= 0)
		{
			_0023_003DzHYHZCcD7_0024bKS._0023_003DzQW_0024hBdI_003D = _0023_003DzQW_0024hBdI_003D;
			_0023_003DzHYHZCcD7_0024bKS._0023_003DzFITvoaXugyss(_0023_003DzPzO_0024GUk_003D);
			_0023_003DzM9DHoIE_003D = _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D.BinarySearch(_0023_003DzHYHZCcD7_0024bKS, _0023_003DzWFIcsB57XAY2YQ1Yo4Aklmk_003D);
			if (_0023_003DzM9DHoIE_003D < 0)
			{
				_0023_003DzHYHZCcD7_0024bKS._0023_003DzQW_0024hBdI_003D = num;
				_0023_003DzHYHZCcD7_0024bKS._0023_003DzFITvoaXugyss(_0023_003DzPzO_0024GUk_003D);
				_0023_003DzM9DHoIE_003D = _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D.BinarySearch(_0023_003DzHYHZCcD7_0024bKS, _0023_003DzWFIcsB57XAY2YQ1Yo4Aklmk_003D);
			}
		}
		else
		{
			_0023_003DzgIhGu6_0024iUVb6._0023_003DzQW_0024hBdI_003D = _0023_003DzQW_0024hBdI_003D;
			_0023_003DzgIhGu6_0024iUVb6._0023_003DzFITvoaXugyss(_0023_003DzPzO_0024GUk_003D);
			_0023_003DzCYlGuqc_003D = _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D.BinarySearch(_0023_003DzgIhGu6_0024iUVb6, _0023_003DzWFIcsB57XAY2YQ1Yo4Aklmk_003D);
			if (_0023_003DzCYlGuqc_003D >= 0)
			{
				_0023_003DzHYHZCcD7_0024bKS._0023_003DzQW_0024hBdI_003D = num;
				_0023_003DzHYHZCcD7_0024bKS._0023_003DzFITvoaXugyss(_0023_003DzPzO_0024GUk_003D);
				_0023_003DzM9DHoIE_003D = _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D.BinarySearch(_0023_003DzHYHZCcD7_0024bKS, _0023_003DzWFIcsB57XAY2YQ1Yo4Aklmk_003D);
			}
		}
	}

	public Mesh[] SplitDisjoint()
	{
		List<Mesh> list = new List<Mesh>();
		Utility.GetEdgesWithoutDuplicates(_triangles, Vertices.Length, out var edgesPerVertex);
		bool[] array = new bool[Triangles.Length];
		int num = 0;
		do
		{
			List<IndexTriangle> list2 = new List<IndexTriangle>(Triangles.Length);
			List<IndexTriangle> list3 = new List<IndexTriangle>(Triangles.Length);
			IndexTriangle item = Triangles[num];
			if (!array[num])
			{
				list3.Add(item);
				array[num] = true;
				int num2;
				for (num2 = 0; num2 < list3.Count; num2++)
				{
					IndexTriangle indexTriangle = list3[num2];
					LinkedList<SharedEdge> linkedList = edgesPerVertex[indexTriangle.V1];
					LinkedList<SharedEdge> linkedList2 = edgesPerVertex[indexTriangle.V2];
					LinkedList<SharedEdge> linkedList3 = edgesPerVertex[indexTriangle.V3];
					list2.Add(indexTriangle);
					foreach (int item3 in _0023_003DzG6e7w9E_003D(new LinkedList<SharedEdge>[3] { linkedList, linkedList2, linkedList3 }, array))
					{
						list3.Add(Triangles[item3]);
						array[item3] = true;
					}
					list3.RemoveAt(num2);
					num2 = -1;
				}
			}
			Mesh item2 = _0023_003DzYSuzxqpUOR9bA6Afbw_003D_003D(list2);
			list.Add(item2);
			list2.Clear();
			for (int i = 0; i < array.Length; i++)
			{
				if (!array[i])
				{
					num = i;
					break;
				}
				if (i == array.Length - 1)
				{
					num = Triangles.Length;
					break;
				}
			}
		}
		while (num < Triangles.Length);
		foreach (Mesh item4 in list)
		{
			item4.CopyAttributes(this);
		}
		return list.ToArray();
	}

	private IEnumerable _0023_003DzG6e7w9E_003D(LinkedList<SharedEdge>[] _0023_003DzJEjOUnYss71r, bool[] _0023_003Dz4sg0Qp0_003D)
	{
		HashSet<int> hashSet = new HashSet<int>();
		for (int i = 0; i < _0023_003DzJEjOUnYss71r.Length; i++)
		{
			for (LinkedListNode<SharedEdge> linkedListNode = _0023_003DzJEjOUnYss71r[i].First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				if (!_0023_003Dz4sg0Qp0_003D[linkedListNode.Value.Mum])
				{
					hashSet.Add(linkedListNode.Value.Mum);
				}
				if (linkedListNode.Value.Dad > 0 && !_0023_003Dz4sg0Qp0_003D[linkedListNode.Value.Dad])
				{
					hashSet.Add(linkedListNode.Value.Dad);
				}
			}
		}
		return hashSet;
	}

	public int FixNormals()
	{
		Utility.GetEdgesWithoutDuplicates(_triangles, _vertices.Length, out var edgesPerVertex);
		bool[] array = new bool[_triangles.Length];
		array[0] = true;
		int num = 1;
		int num2 = 0;
		Stack<int> stack = new Stack<int>();
		stack.Push(0);
		do
		{
			int num3 = stack.Pop();
			IndexTriangle indexTriangle = _triangles[num3];
			LinkedListNode<SharedEdge>[] array2 = new LinkedListNode<SharedEdge>[3]
			{
				_0023_003DzD9SwuyVZa8PlI_A61cID5y4_003D(edgesPerVertex, indexTriangle.V1, indexTriangle.V2),
				_0023_003DzD9SwuyVZa8PlI_A61cID5y4_003D(edgesPerVertex, indexTriangle.V2, indexTriangle.V3),
				_0023_003DzD9SwuyVZa8PlI_A61cID5y4_003D(edgesPerVertex, indexTriangle.V3, indexTriangle.V1)
			};
			for (int i = 0; i < 3; i++)
			{
				if (array2[i] == null)
				{
					continue;
				}
				int num4 = 0;
				int num5 = 0;
				if (i == 0)
				{
					num4 = indexTriangle.V1;
					num5 = indexTriangle.V2;
				}
				if (i == 1)
				{
					num4 = indexTriangle.V2;
					num5 = indexTriangle.V3;
				}
				if (i == 2)
				{
					num4 = indexTriangle.V3;
					num5 = indexTriangle.V1;
				}
				int _0023_003DzQW_0024hBdI_003D;
				int _0023_003DzCmn_5Z0_003D;
				if (!array[array2[i].Value.Mum])
				{
					IndexTriangle indexTriangle2 = _triangles[array2[i].Value.Mum];
					_0023_003Dz_0024_4yLERRgw_NmVkvRYTzs52AL9UbEzWi7g_003D_003D(num4, num5, indexTriangle2, out _0023_003DzQW_0024hBdI_003D, out _0023_003DzCmn_5Z0_003D);
					if (num4 == _0023_003DzQW_0024hBdI_003D && num5 == _0023_003DzCmn_5Z0_003D)
					{
						int v = indexTriangle2.V3;
						indexTriangle2.V3 = indexTriangle2.V2;
						indexTriangle2.V2 = v;
						num2++;
					}
					array[array2[i].Value.Mum] = true;
					num++;
					stack.Push(array2[i].Value.Mum);
				}
				if (array2[i].Value.Dad > 0 && !array[array2[i].Value.Dad])
				{
					IndexTriangle indexTriangle3 = _triangles[array2[i].Value.Dad];
					_0023_003Dz_0024_4yLERRgw_NmVkvRYTzs52AL9UbEzWi7g_003D_003D(num4, num5, indexTriangle3, out _0023_003DzQW_0024hBdI_003D, out _0023_003DzCmn_5Z0_003D);
					if (num4 == _0023_003DzQW_0024hBdI_003D && num5 == _0023_003DzCmn_5Z0_003D)
					{
						int v2 = indexTriangle3.V3;
						indexTriangle3.V3 = indexTriangle3.V2;
						indexTriangle3.V2 = v2;
						num2++;
					}
					array[array2[i].Value.Dad] = true;
					num++;
					stack.Push(array2[i].Value.Dad);
				}
			}
			if (stack.Count != 0 || num >= _triangles.Length)
			{
				continue;
			}
			for (int j = 0; j < _triangles.Length; j++)
			{
				if (!array[j])
				{
					stack.Push(j);
					array[j] = true;
					num++;
					break;
				}
			}
		}
		while (stack.Count > 0);
		if (num2 > 0)
		{
			_normals = null;
			RegenMode = regenType.RegenAndCompile;
		}
		return num2;
	}

	private static void _0023_003Dz_0024_4yLERRgw_NmVkvRYTzs52AL9UbEzWi7g_003D_003D(int _0023_003DzCYlGuqc_003D, int _0023_003DzM9DHoIE_003D, IndexTriangle _0023_003DzalA0_0024_0024U_003D, out int _0023_003DzQW_0024hBdI_003D, out int _0023_003DzCmn_5Z0_003D)
	{
		if (_0023_003DzCYlGuqc_003D == _0023_003DzalA0_0024_0024U_003D.V1 || _0023_003DzM9DHoIE_003D == _0023_003DzalA0_0024_0024U_003D.V1)
		{
			if (_0023_003DzCYlGuqc_003D == _0023_003DzalA0_0024_0024U_003D.V2 || (_0023_003DzM9DHoIE_003D == _0023_003DzalA0_0024_0024U_003D.V2 && _0023_003DzalA0_0024_0024U_003D.V1 != _0023_003DzalA0_0024_0024U_003D.V2))
			{
				_0023_003DzQW_0024hBdI_003D = _0023_003DzalA0_0024_0024U_003D.V1;
				_0023_003DzCmn_5Z0_003D = _0023_003DzalA0_0024_0024U_003D.V2;
			}
			else
			{
				_0023_003DzQW_0024hBdI_003D = _0023_003DzalA0_0024_0024U_003D.V3;
				_0023_003DzCmn_5Z0_003D = _0023_003DzalA0_0024_0024U_003D.V1;
			}
		}
		else
		{
			_0023_003DzQW_0024hBdI_003D = _0023_003DzalA0_0024_0024U_003D.V2;
			_0023_003DzCmn_5Z0_003D = _0023_003DzalA0_0024_0024U_003D.V3;
		}
	}

	private static LinkedListNode<SharedEdge> _0023_003DzD9SwuyVZa8PlI_A61cID5y4_003D(LinkedList<SharedEdge>[] _0023_003DzmnV_0024pJLPOgwq, int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D)
	{
		if (_0023_003DzffqPLNQ_003D > _0023_003Dz5Azd7L8_003D)
		{
			int num = _0023_003DzffqPLNQ_003D;
			_0023_003DzffqPLNQ_003D = _0023_003Dz5Azd7L8_003D;
			_0023_003Dz5Azd7L8_003D = num;
		}
		if (_0023_003DzmnV_0024pJLPOgwq[_0023_003DzffqPLNQ_003D].Count > 0)
		{
			LinkedListNode<SharedEdge> linkedListNode = _0023_003DzmnV_0024pJLPOgwq[_0023_003DzffqPLNQ_003D].First;
			while (linkedListNode.Value.V2 != _0023_003Dz5Azd7L8_003D)
			{
				linkedListNode = linkedListNode.Next;
			}
			return linkedListNode;
		}
		return null;
	}

	private Mesh _0023_003DzYSuzxqpUOR9bA6Afbw_003D_003D(List<IndexTriangle> _0023_003DzjzpdvPcRMYL9)
	{
		int num = 0;
		int num2 = Vertices.Length;
		List<IndexTriangle> list = new List<IndexTriangle>(Triangles.Length / 2);
		List<Point3D> list2 = new List<Point3D>(num2 / 2);
		int[] array = new int[num2];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = -1;
		}
		bool flag = (_meshNature == natureType.RichPlain || _meshNature == natureType.RichSmooth) && TextureCoords != null;
		int num3 = 0;
		List<PointF> list3 = new List<PointF>();
		int[] array2 = new int[0];
		if (flag)
		{
			int num4 = TextureCoords.Length;
			list3 = new List<PointF>(num4 / 2);
			array2 = new int[num4];
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = -1;
			}
		}
		foreach (IndexTriangle item in _0023_003DzjzpdvPcRMYL9)
		{
			int _0023_003DzffqPLNQ_003D;
			if (array[item.V1] == -1)
			{
				array[item.V1] = num;
				_0023_003DzffqPLNQ_003D = num;
				list2.Add((Point3D)Vertices[item.V1].Clone());
				num++;
			}
			else
			{
				_0023_003DzffqPLNQ_003D = array[item.V1];
			}
			int _0023_003Dz5Azd7L8_003D;
			if (array[item.V2] == -1)
			{
				array[item.V2] = num;
				_0023_003Dz5Azd7L8_003D = num;
				list2.Add((Point3D)Vertices[item.V2].Clone());
				num++;
			}
			else
			{
				_0023_003Dz5Azd7L8_003D = array[item.V2];
			}
			int _0023_003DzZe6oCrQ_003D;
			if (array[item.V3] == -1)
			{
				array[item.V3] = num;
				_0023_003DzZe6oCrQ_003D = num;
				list2.Add((Point3D)Vertices[item.V3].Clone());
				num++;
			}
			else
			{
				_0023_003DzZe6oCrQ_003D = array[item.V3];
			}
			if (flag)
			{
				int _0023_003DzsK_Xndk_003D = 0;
				int _0023_003Dz0ADyCos_003D = 0;
				int _0023_003DzoCDsmWk_003D = 0;
				switch (_meshNature)
				{
				case natureType.RichPlain:
				{
					RichTriangle richTriangle = (RichTriangle)item;
					if (array2[richTriangle.T1] == -1)
					{
						array2[richTriangle.T1] = num3;
						_0023_003DzsK_Xndk_003D = num3;
						list3.Add(TextureCoords[richTriangle.T1]);
						num3++;
					}
					else
					{
						_0023_003DzsK_Xndk_003D = array2[richTriangle.T1];
					}
					if (array2[richTriangle.T2] == -1)
					{
						array2[richTriangle.T2] = num3;
						_0023_003Dz0ADyCos_003D = num3;
						list3.Add(TextureCoords[richTriangle.T2]);
						num3++;
					}
					else
					{
						_0023_003Dz0ADyCos_003D = array2[richTriangle.T2];
					}
					if (array2[richTriangle.T3] == -1)
					{
						array2[richTriangle.T3] = num3;
						_0023_003DzoCDsmWk_003D = num3;
						list3.Add(TextureCoords[richTriangle.T3]);
						num3++;
					}
					else
					{
						_0023_003DzoCDsmWk_003D = array2[richTriangle.T3];
					}
					break;
				}
				case natureType.RichSmooth:
				{
					RichSmoothTriangle richSmoothTriangle = (RichSmoothTriangle)item;
					if (array2[richSmoothTriangle.T1] == -1)
					{
						array2[richSmoothTriangle.T1] = num3;
						_0023_003DzsK_Xndk_003D = num3;
						list3.Add(TextureCoords[richSmoothTriangle.T1]);
						num3++;
					}
					else
					{
						_0023_003DzsK_Xndk_003D = array2[richSmoothTriangle.T1];
					}
					if (array2[richSmoothTriangle.T2] == -1)
					{
						array2[richSmoothTriangle.T2] = num3;
						_0023_003Dz0ADyCos_003D = num3;
						list3.Add(TextureCoords[richSmoothTriangle.T2]);
						num3++;
					}
					else
					{
						_0023_003Dz0ADyCos_003D = array2[richSmoothTriangle.T2];
					}
					if (array2[richSmoothTriangle.T3] == -1)
					{
						array2[richSmoothTriangle.T3] = num3;
						_0023_003DzoCDsmWk_003D = num3;
						list3.Add(TextureCoords[richSmoothTriangle.T3]);
						num3++;
					}
					else
					{
						_0023_003DzoCDsmWk_003D = array2[richSmoothTriangle.T3];
					}
					break;
				}
				}
				_0023_003Dz_LICwio_003D(this, _0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, _0023_003DzZe6oCrQ_003D, list, _0023_003DzsK_Xndk_003D, _0023_003Dz0ADyCos_003D, _0023_003DzoCDsmWk_003D, 0, 0, 0);
			}
			else
			{
				_0023_003Dz_LICwio_003D(this, _0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, _0023_003DzZe6oCrQ_003D, list);
			}
		}
		Mesh mesh = new Mesh(list2.ToArray(), list);
		if (flag)
		{
			mesh.TextureCoords = list3.ToArray();
		}
		return mesh;
	}

	public booleanFailureType SplitBy(Plane plane, out Mesh[] splits)
	{
		return SplitBy(plane, splitDisjoint: true, out splits);
	}

	public booleanFailureType SplitBy(Plane plane, bool splitDisjoint, out Mesh[] splits)
	{
		List<Mesh> list = new List<Mesh>();
		Mesh mesh = (Mesh)Clone();
		if (mesh.SubdivideBy(plane) == booleanFailureType.NotIntersecting)
		{
			splits = new Mesh[0];
			return booleanFailureType.NotIntersecting;
		}
		List<Point3D> list2 = new List<Point3D>(mesh._vertices.Length / 2);
		List<IndexTriangle> list3 = new List<IndexTriangle>(mesh._triangles.Length / 2);
		List<Point3D> list4 = new List<Point3D>(mesh._vertices.Length / 2);
		List<IndexTriangle> list5 = new List<IndexTriangle>(mesh._triangles.Length / 2);
		int _0023_003DzhYy1dJQ_003D = 0;
		int _0023_003DzhYy1dJQ_003D2 = 0;
		int num = mesh._vertices.Length;
		int[] array = new int[num];
		int[] array2 = new int[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = -1;
			array2[i] = -1;
		}
		IndexTriangle[] triangles = mesh._triangles;
		foreach (IndexTriangle indexTriangle in triangles)
		{
			Point3D[] array3 = new Point3D[3]
			{
				mesh._vertices[indexTriangle.V1],
				mesh._vertices[indexTriangle.V2],
				mesh._vertices[indexTriangle.V3]
			};
			Point3D point = _0023_003DzDeCArp_a0IgzwwfUV3LMILs_003D(array3);
			if (plane.DistanceTo(point) < 0.0)
			{
				_0023_003Dz_LICwio_003D(list2, list3, ref _0023_003DzhYy1dJQ_003D, array, indexTriangle, array3);
			}
			else
			{
				_0023_003Dz_LICwio_003D(list4, list5, ref _0023_003DzhYy1dJQ_003D2, array2, indexTriangle, array3);
			}
		}
		bool num2 = (_meshNature == natureType.RichPlain || _meshNature == natureType.RichSmooth) && TextureCoords != null;
		Mesh mesh2 = new Mesh(list2, list3);
		if (num2)
		{
			mesh2.TextureCoords = new PointF[TextureCoords.Length];
			Array.Copy(TextureCoords, mesh2.TextureCoords, TextureCoords.Length);
		}
		Mesh mesh3 = new Mesh(list4, list5);
		if (num2)
		{
			mesh3.TextureCoords = new PointF[TextureCoords.Length];
			Array.Copy(TextureCoords, mesh3.TextureCoords, TextureCoords.Length);
		}
		if (splitDisjoint)
		{
			if (mesh2.MeshNature != natureType.Undefined)
			{
				list.AddRange(mesh2.SplitDisjoint());
			}
			if (mesh3.MeshNature != natureType.Undefined)
			{
				list.AddRange(mesh3.SplitDisjoint());
			}
		}
		else
		{
			if (mesh2.MeshNature != natureType.Undefined)
			{
				list.Add(mesh2);
			}
			if (mesh3.MeshNature != natureType.Undefined)
			{
				list.Add(mesh3);
			}
		}
		foreach (Mesh item in list)
		{
			item.CopyAttributes(this);
		}
		splits = list.ToArray();
		return booleanFailureType.Success;
	}

	private void _0023_003Dz_LICwio_003D(List<Point3D> _0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D, List<IndexTriangle> _0023_003DzMR__00244hq5SpOzJBUIBA_003D_003D, ref int _0023_003DzhYy1dJQ_003D, int[] _0023_003DzrD_bXKo7U4LhvW5lTA_003D_003D, IndexTriangle _0023_003DznnnQx3RwjThsBRPB9w_003D_003D, Point3D[] _0023_003DzT27kmxAntj__0024yot19fShpFDbz4_0024H)
	{
		if (_0023_003DzrD_bXKo7U4LhvW5lTA_003D_003D[_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1] < 0)
		{
			Point3D item = (Point3D)_0023_003DzT27kmxAntj__0024yot19fShpFDbz4_0024H[0].Clone();
			_0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D.Add(item);
			_0023_003DzrD_bXKo7U4LhvW5lTA_003D_003D[_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1] = _0023_003DzhYy1dJQ_003D;
			_0023_003DzhYy1dJQ_003D++;
		}
		if (_0023_003DzrD_bXKo7U4LhvW5lTA_003D_003D[_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2] < 0)
		{
			Point3D item2 = (Point3D)_0023_003DzT27kmxAntj__0024yot19fShpFDbz4_0024H[1].Clone();
			_0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D.Add(item2);
			_0023_003DzrD_bXKo7U4LhvW5lTA_003D_003D[_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2] = _0023_003DzhYy1dJQ_003D;
			_0023_003DzhYy1dJQ_003D++;
		}
		if (_0023_003DzrD_bXKo7U4LhvW5lTA_003D_003D[_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V3] < 0)
		{
			Point3D item3 = (Point3D)_0023_003DzT27kmxAntj__0024yot19fShpFDbz4_0024H[2].Clone();
			_0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D.Add(item3);
			_0023_003DzrD_bXKo7U4LhvW5lTA_003D_003D[_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V3] = _0023_003DzhYy1dJQ_003D;
			_0023_003DzhYy1dJQ_003D++;
		}
		_0023_003Dz_LICwio_003D(this, _0023_003DzrD_bXKo7U4LhvW5lTA_003D_003D[_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1], _0023_003DzrD_bXKo7U4LhvW5lTA_003D_003D[_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2], _0023_003DzrD_bXKo7U4LhvW5lTA_003D_003D[_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V3], _0023_003DzMR__00244hq5SpOzJBUIBA_003D_003D, _0023_003DznnnQx3RwjThsBRPB9w_003D_003D);
	}

	private static Point3D _0023_003DzDeCArp_a0IgzwwfUV3LMILs_003D(Point3D[] _0023_003DzJs2WPVlNsiqa)
	{
		return new Point3D
		{
			X = (_0023_003DzJs2WPVlNsiqa[0].X + _0023_003DzJs2WPVlNsiqa[1].X + _0023_003DzJs2WPVlNsiqa[2].X) / 3.0,
			Y = (_0023_003DzJs2WPVlNsiqa[0].Y + _0023_003DzJs2WPVlNsiqa[1].Y + _0023_003DzJs2WPVlNsiqa[2].Y) / 3.0,
			Z = (_0023_003DzJs2WPVlNsiqa[0].Z + _0023_003DzJs2WPVlNsiqa[1].Z + _0023_003DzJs2WPVlNsiqa[2].Z) / 3.0
		};
	}

	public booleanFailureType SubdivideBy(Plane plane)
	{
		LinkedList<SharedEdge>[] edgesPerVertex;
		int num = Utility.GetEdgesWithoutDuplicates(_triangles, _vertices.Length, out edgesPerVertex);
		List<LinkedList<SharedEdge>> list = new List<LinkedList<SharedEdge>>(edgesPerVertex);
		int num2 = edgesPerVertex.Length;
		short[] array = new short[_vertices.Length];
		if (base.BoxMin == null || base.BoxMax == null)
		{
			Regen(0.0);
		}
		double diagonal = base.BoxSize.Diagonal;
		List<Point3D> list2 = new List<Point3D>(_vertices);
		List<IndexTriangle> list3 = new List<IndexTriangle>(_triangles);
		List<Vector3D> list4 = new List<Vector3D>(_normals);
		bool flag = false;
		for (int i = 0; i < _vertices.Length; i++)
		{
			double num3 = plane.DistanceTo(_vertices[i]);
			if (Utility.AreEqual(num3, 0.0, diagonal))
			{
				array[i] = 0;
				flag = true;
			}
			else
			{
				array[i] = (short)Math.Sign(num3);
			}
		}
		booleanFailureType result = booleanFailureType.NotIntersecting;
		if (flag)
		{
			result = booleanFailureType.Success;
		}
		for (int j = 0; j < num2; j++)
		{
			if (array[j] == 0)
			{
				continue;
			}
			LinkedListNode<SharedEdge> linkedListNode = edgesPerVertex[j].First;
			while (linkedListNode != null && linkedListNode.Value.V2 < array.Length)
			{
				if (array[j] * array[linkedListNode.Value.V2] == -1)
				{
					num += _0023_003DzkFn7rl0C0Vc_b1wm2g_003D_003D(_meshNature, plane, j, linkedListNode.Value, list, list2, list3, list4);
				}
				linkedListNode = linkedListNode.Next;
			}
		}
		if (_triangles.Length != list3.Count)
		{
			result = booleanFailureType.Success;
		}
		_vertices = list2.ToArray();
		_triangles = list3.ToArray();
		_normals = list4.ToArray();
		sharedEdges = Utility.GetUniqueEdges(list.ToArray(), num);
		_0023_003Dz_T6MNYD65ZA4();
		silhoData = null;
		RegenMode = regenType.CompileOnly;
		return result;
	}

	private static int _0023_003DzkFn7rl0C0Vc_b1wm2g_003D_003D(natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, Plane _0023_003Dzrgqz890sj_0024X9, int _0023_003DzcJpaJQAcgoDn, SharedEdge _0023_003DzTx2aqr8_003D, List<LinkedList<SharedEdge>> _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D, List<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, List<IndexTriangle> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, List<Vector3D> _0023_003DzztJY0_0024dXEFMk)
	{
		Segment3D segment3D = new Segment3D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzcJpaJQAcgoDn], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTx2aqr8_003D.V2]);
		int num = 0;
		if (!segment3D.IntersectWith(_0023_003Dzrgqz890sj_0024X9, out var intPoint))
		{
			return num;
		}
		Point3D point3D = (Point3D)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0].Clone();
		point3D.X = intPoint.X;
		point3D.Y = intPoint.Y;
		point3D.Z = intPoint.Z;
		int count = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count;
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Add(point3D);
		_0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D.Add(new LinkedList<SharedEdge>());
		int _0023_003Dz6M_KmFm4tm5B9_WL1w_003D_003D;
		if (_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D - 1 <= natureType.MulticolorPlain)
		{
			_0023_003Dz6M_KmFm4tm5B9_WL1w_003D_003D = -1;
		}
		else
		{
			_0023_003Dzo_0024SYBOW2_0024hKAcJFPPw_003D_003D(_0023_003DzcJpaJQAcgoDn, _0023_003DzTx2aqr8_003D.V2, (SmoothTriangle)_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[_0023_003DzTx2aqr8_003D.Mum], out var _0023_003Dz0wAkCmM_003D, out var _0023_003Dz_0024eRdUwQ_003D);
			_0023_003Dz6M_KmFm4tm5B9_WL1w_003D_003D = _0023_003DzztJY0_0024dXEFMk.Count;
			_0023_003DzztJY0_0024dXEFMk.Add(Utility.NormalInterpolation(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzcJpaJQAcgoDn], _0023_003DzztJY0_0024dXEFMk[_0023_003Dz0wAkCmM_003D], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTx2aqr8_003D.V2], _0023_003DzztJY0_0024dXEFMk[_0023_003Dz_0024eRdUwQ_003D], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[count]));
		}
		SharedEdge sharedEdge = new SharedEdge();
		sharedEdge.V2 = count;
		sharedEdge.Mum = _0023_003DzLHR6_wunPv5qJhqMgg_003D_003D(_0023_003DzcJpaJQAcgoDn, _0023_003DzTx2aqr8_003D.V2, count, _0023_003DzTx2aqr8_003D.Mum, _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003DzztJY0_0024dXEFMk, _0023_003Dz6M_KmFm4tm5B9_WL1w_003D_003D);
		num++;
		if (_0023_003DzTx2aqr8_003D.Dad != -1)
		{
			sharedEdge.Dad = _0023_003DzLHR6_wunPv5qJhqMgg_003D_003D(_0023_003DzcJpaJQAcgoDn, _0023_003DzTx2aqr8_003D.V2, count, _0023_003DzTx2aqr8_003D.Dad, _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003DzztJY0_0024dXEFMk, _0023_003Dz6M_KmFm4tm5B9_WL1w_003D_003D);
			num++;
		}
		_0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D[_0023_003DzTx2aqr8_003D.V2].AddLast(sharedEdge);
		_0023_003DzTx2aqr8_003D.V2 = count;
		return num + 1;
	}

	private static int _0023_003DzLHR6_wunPv5qJhqMgg_003D_003D(int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D, int _0023_003DzM8ln9Dk_003D, int _0023_003DzEzv5_0024vo_003D, List<LinkedList<SharedEdge>> _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D, List<IndexTriangle> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, List<Vector3D> _0023_003DzztJY0_0024dXEFMk, int _0023_003Dz6M_KmFm4tm5B9_WL1w_003D_003D)
	{
		IndexTriangle indexTriangle = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[_0023_003DzEzv5_0024vo_003D];
		IndexTriangle indexTriangle2 = (IndexTriangle)indexTriangle.Clone();
		int thirdVertex = indexTriangle.GetThirdVertex(_0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D);
		indexTriangle.ReplaceVertexIndex(_0023_003Dz5Azd7L8_003D, _0023_003DzM8ln9Dk_003D);
		int count = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Count;
		indexTriangle2.ReplaceVertexIndex(_0023_003DzffqPLNQ_003D, _0023_003DzM8ln9Dk_003D);
		_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Add(indexTriangle2);
		if (_0023_003Dz6M_KmFm4tm5B9_WL1w_003D_003D == -1)
		{
			_0023_003DzztJY0_0024dXEFMk.Add((Vector3D)_0023_003DzztJY0_0024dXEFMk[_0023_003DzEzv5_0024vo_003D].Clone());
		}
		else
		{
			_0023_003DzEiQZ1LoQO4os(_0023_003DzM8ln9Dk_003D, _0023_003Dz6M_KmFm4tm5B9_WL1w_003D_003D, (SmoothTriangle)indexTriangle);
			_0023_003DzEiQZ1LoQO4os(_0023_003DzM8ln9Dk_003D, _0023_003Dz6M_KmFm4tm5B9_WL1w_003D_003D, (SmoothTriangle)indexTriangle2);
		}
		Utility.GetMinMax(_0023_003Dz5Azd7L8_003D, thirdVertex, out var min, out var max);
		_0023_003DzrtUa0GKgpr6gDR8pdw_003D_003D(Utility.GetEdge(min, max, _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D), _0023_003DzEzv5_0024vo_003D, count);
		SharedEdge sharedEdge = new SharedEdge();
		sharedEdge.V2 = _0023_003DzM8ln9Dk_003D;
		sharedEdge.Mum = _0023_003DzEzv5_0024vo_003D;
		sharedEdge.Dad = count;
		_0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D[thirdVertex].AddLast(sharedEdge);
		return count;
	}

	private static void _0023_003DzEiQZ1LoQO4os(int _0023_003Dz77g161c_003D, int _0023_003Dz457nmtI_003D, SmoothTriangle _0023_003DzEzv5_0024vo_003D)
	{
		if (_0023_003DzEzv5_0024vo_003D.V1 == _0023_003Dz77g161c_003D)
		{
			_0023_003DzEzv5_0024vo_003D.N1 = _0023_003Dz457nmtI_003D;
		}
		else if (_0023_003DzEzv5_0024vo_003D.V2 == _0023_003Dz77g161c_003D)
		{
			_0023_003DzEzv5_0024vo_003D.N2 = _0023_003Dz457nmtI_003D;
		}
		else
		{
			_0023_003DzEzv5_0024vo_003D.N3 = _0023_003Dz457nmtI_003D;
		}
	}

	private static void _0023_003Dzo_0024SYBOW2_0024hKAcJFPPw_003D_003D(int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D, SmoothTriangle _0023_003Dz3BcI_0024NWhMXKQ, out int _0023_003Dz0wAkCmM_003D, out int _0023_003Dz_0024eRdUwQ_003D)
	{
		if (_0023_003Dz3BcI_0024NWhMXKQ.V1 == _0023_003DzffqPLNQ_003D)
		{
			_0023_003Dz0wAkCmM_003D = _0023_003Dz3BcI_0024NWhMXKQ.N1;
			if (_0023_003Dz3BcI_0024NWhMXKQ.V2 == _0023_003Dz5Azd7L8_003D)
			{
				_0023_003Dz_0024eRdUwQ_003D = _0023_003Dz3BcI_0024NWhMXKQ.N2;
			}
			else
			{
				_0023_003Dz_0024eRdUwQ_003D = _0023_003Dz3BcI_0024NWhMXKQ.N3;
			}
		}
		else if (_0023_003Dz3BcI_0024NWhMXKQ.V2 == _0023_003DzffqPLNQ_003D)
		{
			_0023_003Dz0wAkCmM_003D = _0023_003Dz3BcI_0024NWhMXKQ.N2;
			if (_0023_003Dz3BcI_0024NWhMXKQ.V1 == _0023_003Dz5Azd7L8_003D)
			{
				_0023_003Dz_0024eRdUwQ_003D = _0023_003Dz3BcI_0024NWhMXKQ.N1;
			}
			else
			{
				_0023_003Dz_0024eRdUwQ_003D = _0023_003Dz3BcI_0024NWhMXKQ.N3;
			}
		}
		else
		{
			_0023_003Dz0wAkCmM_003D = _0023_003Dz3BcI_0024NWhMXKQ.N3;
			if (_0023_003Dz3BcI_0024NWhMXKQ.V1 == _0023_003Dz5Azd7L8_003D)
			{
				_0023_003Dz_0024eRdUwQ_003D = _0023_003Dz3BcI_0024NWhMXKQ.N1;
			}
			else
			{
				_0023_003Dz_0024eRdUwQ_003D = _0023_003Dz3BcI_0024NWhMXKQ.N2;
			}
		}
	}

	private static void _0023_003DzrtUa0GKgpr6gDR8pdw_003D_003D(SharedEdge _0023_003DzeQx1kL9qN7ba, int _0023_003DzOQWUgixdT_uA, int _0023_003DzEGZvwL8_003D)
	{
		if (_0023_003DzeQx1kL9qN7ba.Mum == _0023_003DzOQWUgixdT_uA)
		{
			_0023_003DzeQx1kL9qN7ba.Mum = _0023_003DzEGZvwL8_003D;
		}
		else
		{
			_0023_003DzeQx1kL9qN7ba.Dad = _0023_003DzEGZvwL8_003D;
		}
	}

	internal bool _0023_003Dz2rx0bYXAv_0024aP(double _0023_003Dzm0CYiiE_003D, out Plane _0023_003Dzrgqz890sj_0024X9)
	{
		Vector3D vector3D = null;
		_0023_003Dzrgqz890sj_0024X9 = null;
		for (int i = 0; i < _triangles.Length; i++)
		{
			Triangle triangle = new Triangle(Vertices[_triangles[i].V1], Vertices[_triangles[i].V2], Vertices[_triangles[i].V3]);
			triangle.Regen(_0023_003Dzm0CYiiE_003D);
			triangle.Normal.Normalize();
			if (vector3D == null)
			{
				vector3D = triangle.Normal;
			}
			else if (!Vector3D.AreParallel(vector3D, triangle.Normal, _0023_003Dzm0CYiiE_003D))
			{
				return false;
			}
		}
		_0023_003Dzrgqz890sj_0024X9 = new Plane(Vertices[0], vector3D);
		return true;
	}

	public void ApplyTextureMapping(textureMappingType mappingMode, double scaleX, double scaleY, Point3D boxMin, Point3D boxMax)
	{
		ApplyTextureMapping(mappingMode, scaleX, scaleY, boxMin, boxMax, new Identity());
	}

	public void ApplyTextureMapping(TextureMappingData mapping)
	{
		ApplyTextureMapping(mapping.MappingMode, mapping.ScaleX, mapping.ScaleY, mapping.Min, mapping.Max, mapping.Transformation ?? new Identity());
	}

	public void ApplyTextureMapping(textureMappingType mappingMode, double scaleX, double scaleY, Point3D boxMin, Point3D boxMax, Transformation transformation)
	{
		int num = _triangles.Length;
		switch (_meshNature)
		{
		case natureType.Plain:
		case natureType.ColorPlain:
		case natureType.MulticolorPlain:
		{
			RichTriangle[] array2 = new RichTriangle[num];
			for (int j = 0; j < num; j++)
			{
				IndexTriangle indexTriangle = _triangles[j];
				array2[j] = new RichTriangle(indexTriangle.V1, indexTriangle.V2, indexTriangle.V3);
			}
			IndexTriangle[] triangles = array2;
			_triangles = triangles;
			_meshNature = natureType.RichPlain;
			break;
		}
		case natureType.Smooth:
		case natureType.ColorSmooth:
		case natureType.MulticolorSmooth:
		{
			RichSmoothTriangle[] array = new RichSmoothTriangle[num];
			for (int i = 0; i < num; i++)
			{
				SmoothTriangle smoothTriangle = (SmoothTriangle)_triangles[i];
				array[i] = new RichSmoothTriangle(smoothTriangle.V1, smoothTriangle.V2, smoothTriangle.V3, smoothTriangle.N1, smoothTriangle.N2, smoothTriangle.N3, 0, 0, 0);
			}
			IndexTriangle[] triangles = array;
			_triangles = triangles;
			_meshNature = natureType.RichSmooth;
			break;
		}
		}
		if (_normals == null)
		{
			UpdateNormals();
		}
		_texCoords = new PointF[_triangles.Length * 3];
		Size3D size3D = new Size3D(boxMin, boxMax);
		double max = size3D.Max;
		float _0023_003DzAZbTv8c_003D = 1f / (float)scaleX;
		float _0023_003DzirIS_0024oE_003D = 1f / (float)scaleY;
		Point3D _0023_003DzbUvT9Pc_003D = boxMin + size3D / 2.0;
		switch (mappingMode)
		{
		case textureMappingType.Plate:
			_0023_003Dzu5sCiSAljpxX((float)max, _0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D, _0023_003DzbUvT9Pc_003D, transformation);
			break;
		case textureMappingType.Cubic:
			_0023_003DzUZmQYZ7eCxeZ((float)max, _0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D, _0023_003DzbUvT9Pc_003D, transformation);
			break;
		case textureMappingType.Cylindrical:
			_0023_003DzYTqSDRm1isJddaQJb5_0024Sd_c_003D((float)max, _0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D, _0023_003DzbUvT9Pc_003D, transformation);
			break;
		case textureMappingType.Spherical:
			_0023_003DzeJ1C1fJNDOro_00245eK1w_003D_003D(_0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D, transformation);
			break;
		}
		if (RegenMode == regenType.NotNeeded)
		{
			RegenMode = regenType.CompileOnly;
		}
	}

	public void RemoveTextureMapping()
	{
		if (TextureCoords == null)
		{
			return;
		}
		_0023_003DzUWlvoYKIdqVL(null);
		TextureCoords = null;
		int num = _triangles.Length;
		if (MeshNature == natureType.RichPlain)
		{
			IndexTriangle[] array = new IndexTriangle[num];
			for (int i = 0; i < num; i++)
			{
				IndexTriangle indexTriangle = _triangles[i];
				array[i] = new IndexTriangle(indexTriangle.V1, indexTriangle.V2, indexTriangle.V3);
			}
			_triangles = array;
			_meshNature = natureType.Plain;
		}
		else if (MeshNature == natureType.RichSmooth)
		{
			SmoothTriangle[] array2 = new SmoothTriangle[num];
			for (int j = 0; j < num; j++)
			{
				SmoothTriangle smoothTriangle = (SmoothTriangle)_triangles[j];
				array2[j] = new SmoothTriangle(smoothTriangle.V1, smoothTriangle.V2, smoothTriangle.V3, smoothTriangle.N1, smoothTriangle.N2, smoothTriangle.N3);
			}
			IndexTriangle[] triangles = array2;
			_triangles = triangles;
			_meshNature = natureType.Smooth;
		}
		Regen(0.0);
		RegenMode = regenType.CompileOnly;
	}

	private void _0023_003Dzu5sCiSAljpxX(float _0023_003DzAXKeXGcDZTLL, float _0023_003DzAZbTv8c_003D, float _0023_003DzirIS_0024oE_003D, Point3D _0023_003DzbUvT9Pc_003D, Transformation _0023_003Dzptomndc_003D)
	{
		int num = 0;
		for (int i = 0; i < _triangles.Length; i++)
		{
			if (_meshNature == natureType.RichSmooth)
			{
				RichSmoothTriangle richSmoothTriangle = (RichSmoothTriangle)_triangles[i];
				Vector3D _0023_003DzZbOaTIM_003D = _0023_003Dzptomndc_003D * _normals[richSmoothTriangle.N1];
				Vector3D _0023_003DzZbOaTIM_003D2 = _0023_003Dzptomndc_003D * _normals[richSmoothTriangle.N2];
				Vector3D _0023_003DzZbOaTIM_003D3 = _0023_003Dzptomndc_003D * _normals[richSmoothTriangle.N3];
				Point3D _0023_003DzkEYxO1SuR1Kw = _0023_003Dzptomndc_003D * _vertices[richSmoothTriangle.V1];
				Point3D _0023_003DzkEYxO1SuR1Kw2 = _0023_003Dzptomndc_003D * _vertices[richSmoothTriangle.V2];
				Point3D _0023_003DzkEYxO1SuR1Kw3 = _0023_003Dzptomndc_003D * _vertices[richSmoothTriangle.V3];
				_0023_003DzTpFv2M86AB9X2FztbQ_003D_003D(_0023_003DzZbOaTIM_003D, _0023_003DzkEYxO1SuR1Kw, _0023_003DzAXKeXGcDZTLL, _0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D, _0023_003DzbUvT9Pc_003D, out _texCoords[num]);
				richSmoothTriangle.T1 = num++;
				_0023_003DzTpFv2M86AB9X2FztbQ_003D_003D(_0023_003DzZbOaTIM_003D2, _0023_003DzkEYxO1SuR1Kw2, _0023_003DzAXKeXGcDZTLL, _0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D, _0023_003DzbUvT9Pc_003D, out _texCoords[num]);
				richSmoothTriangle.T2 = num++;
				_0023_003DzTpFv2M86AB9X2FztbQ_003D_003D(_0023_003DzZbOaTIM_003D3, _0023_003DzkEYxO1SuR1Kw3, _0023_003DzAXKeXGcDZTLL, _0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D, _0023_003DzbUvT9Pc_003D, out _texCoords[num]);
				richSmoothTriangle.T3 = num++;
			}
			else
			{
				RichTriangle richTriangle = (RichTriangle)_triangles[i];
				Vector3D _0023_003DzZbOaTIM_003D4 = _0023_003Dzptomndc_003D * _normals[i];
				Point3D _0023_003DzkEYxO1SuR1Kw4 = _0023_003Dzptomndc_003D * _vertices[richTriangle.V1];
				Point3D _0023_003DzkEYxO1SuR1Kw5 = _0023_003Dzptomndc_003D * _vertices[richTriangle.V2];
				Point3D _0023_003DzkEYxO1SuR1Kw6 = _0023_003Dzptomndc_003D * _vertices[richTriangle.V3];
				_0023_003DzTpFv2M86AB9X2FztbQ_003D_003D(_0023_003DzZbOaTIM_003D4, _0023_003DzkEYxO1SuR1Kw4, _0023_003DzAXKeXGcDZTLL, _0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D, _0023_003DzbUvT9Pc_003D, out _texCoords[num]);
				richTriangle.T1 = num++;
				_0023_003DzTpFv2M86AB9X2FztbQ_003D_003D(_0023_003DzZbOaTIM_003D4, _0023_003DzkEYxO1SuR1Kw5, _0023_003DzAXKeXGcDZTLL, _0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D, _0023_003DzbUvT9Pc_003D, out _texCoords[num]);
				richTriangle.T2 = num++;
				_0023_003DzTpFv2M86AB9X2FztbQ_003D_003D(_0023_003DzZbOaTIM_003D4, _0023_003DzkEYxO1SuR1Kw6, _0023_003DzAXKeXGcDZTLL, _0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D, _0023_003DzbUvT9Pc_003D, out _texCoords[num]);
				richTriangle.T3 = num++;
			}
		}
	}

	private void _0023_003DzUZmQYZ7eCxeZ(float _0023_003DzAXKeXGcDZTLL, float _0023_003DzAZbTv8c_003D, float _0023_003DzirIS_0024oE_003D, Point3D _0023_003DzbUvT9Pc_003D, Transformation _0023_003Dzptomndc_003D)
	{
		int num = 0;
		for (int i = 0; i < _triangles.Length; i++)
		{
			if (_meshNature == natureType.RichSmooth)
			{
				RichSmoothTriangle richSmoothTriangle = (RichSmoothTriangle)_triangles[i];
				Vector3D _0023_003DzZbOaTIM_003D = _0023_003Dzptomndc_003D * _normals[richSmoothTriangle.N1];
				Vector3D _0023_003DzZbOaTIM_003D2 = _0023_003Dzptomndc_003D * _normals[richSmoothTriangle.N2];
				Vector3D _0023_003DzZbOaTIM_003D3 = _0023_003Dzptomndc_003D * _normals[richSmoothTriangle.N3];
				Point3D _0023_003DzkEYxO1SuR1Kw = _0023_003Dzptomndc_003D * _vertices[richSmoothTriangle.V1];
				Point3D _0023_003DzkEYxO1SuR1Kw2 = _0023_003Dzptomndc_003D * _vertices[richSmoothTriangle.V2];
				Point3D _0023_003DzkEYxO1SuR1Kw3 = _0023_003Dzptomndc_003D * _vertices[richSmoothTriangle.V3];
				_0023_003DzzqvomizsZhBQbvLusSN52Co_003D(_0023_003DzZbOaTIM_003D, _0023_003DzkEYxO1SuR1Kw, _0023_003DzAXKeXGcDZTLL, _0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D, _0023_003DzbUvT9Pc_003D, out _texCoords[num]);
				richSmoothTriangle.T1 = num++;
				_0023_003DzzqvomizsZhBQbvLusSN52Co_003D(_0023_003DzZbOaTIM_003D2, _0023_003DzkEYxO1SuR1Kw2, _0023_003DzAXKeXGcDZTLL, _0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D, _0023_003DzbUvT9Pc_003D, out _texCoords[num]);
				richSmoothTriangle.T2 = num++;
				_0023_003DzzqvomizsZhBQbvLusSN52Co_003D(_0023_003DzZbOaTIM_003D3, _0023_003DzkEYxO1SuR1Kw3, _0023_003DzAXKeXGcDZTLL, _0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D, _0023_003DzbUvT9Pc_003D, out _texCoords[num]);
				richSmoothTriangle.T3 = num++;
			}
			else
			{
				RichTriangle richTriangle = (RichTriangle)_triangles[i];
				Vector3D _0023_003DzZbOaTIM_003D4 = _0023_003Dzptomndc_003D * _normals[i];
				Point3D _0023_003DzkEYxO1SuR1Kw4 = _0023_003Dzptomndc_003D * _vertices[richTriangle.V1];
				Point3D _0023_003DzkEYxO1SuR1Kw5 = _0023_003Dzptomndc_003D * _vertices[richTriangle.V2];
				Point3D _0023_003DzkEYxO1SuR1Kw6 = _0023_003Dzptomndc_003D * _vertices[richTriangle.V3];
				_0023_003DzzqvomizsZhBQbvLusSN52Co_003D(_0023_003DzZbOaTIM_003D4, _0023_003DzkEYxO1SuR1Kw4, _0023_003DzAXKeXGcDZTLL, _0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D, _0023_003DzbUvT9Pc_003D, out _texCoords[num]);
				richTriangle.T1 = num++;
				_0023_003DzzqvomizsZhBQbvLusSN52Co_003D(_0023_003DzZbOaTIM_003D4, _0023_003DzkEYxO1SuR1Kw5, _0023_003DzAXKeXGcDZTLL, _0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D, _0023_003DzbUvT9Pc_003D, out _texCoords[num]);
				richTriangle.T2 = num++;
				_0023_003DzzqvomizsZhBQbvLusSN52Co_003D(_0023_003DzZbOaTIM_003D4, _0023_003DzkEYxO1SuR1Kw6, _0023_003DzAXKeXGcDZTLL, _0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D, _0023_003DzbUvT9Pc_003D, out _texCoords[num]);
				richTriangle.T3 = num++;
			}
		}
	}

	private void _0023_003DzYTqSDRm1isJddaQJb5_0024Sd_c_003D(float _0023_003DzAXKeXGcDZTLL, float _0023_003DzAZbTv8c_003D, float _0023_003DzirIS_0024oE_003D, Point3D _0023_003DzbUvT9Pc_003D, Transformation _0023_003Dzptomndc_003D)
	{
		int num = 0;
		Vector3D _0023_003DzH1SwwS4_003D = _0023_003Dzptomndc_003D * _normals[1];
		for (int i = 0; i < _triangles.Length; i++)
		{
			if (_meshNature == natureType.RichSmooth)
			{
				RichSmoothTriangle richSmoothTriangle = (RichSmoothTriangle)_triangles[i];
				Vector3D vector3D = _0023_003Dzptomndc_003D * _normals[richSmoothTriangle.N1];
				Vector3D vector3D2 = _0023_003Dzptomndc_003D * _normals[richSmoothTriangle.N2];
				Vector3D vector3D3 = _0023_003Dzptomndc_003D * _normals[richSmoothTriangle.N3];
				_0023_003DzH1SwwS4_003D = vector3D + vector3D2 + vector3D3;
				Point3D _0023_003DzkEYxO1SuR1Kw = _0023_003Dzptomndc_003D * _vertices[richSmoothTriangle.V1];
				Point3D _0023_003DzkEYxO1SuR1Kw2 = _0023_003Dzptomndc_003D * _vertices[richSmoothTriangle.V2];
				Point3D _0023_003DzkEYxO1SuR1Kw3 = _0023_003Dzptomndc_003D * _vertices[richSmoothTriangle.V3];
				_0023_003DzVbrhNnZc2bR5B6SqSG7bqMwLzln8(vector3D, _0023_003DzkEYxO1SuR1Kw, _0023_003DzH1SwwS4_003D, _0023_003DzAXKeXGcDZTLL, _0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D, _0023_003DzbUvT9Pc_003D, out _texCoords[num]);
				richSmoothTriangle.T1 = num++;
				_0023_003DzVbrhNnZc2bR5B6SqSG7bqMwLzln8(vector3D2, _0023_003DzkEYxO1SuR1Kw2, _0023_003DzH1SwwS4_003D, _0023_003DzAXKeXGcDZTLL, _0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D, _0023_003DzbUvT9Pc_003D, out _texCoords[num]);
				richSmoothTriangle.T2 = num++;
				_0023_003DzVbrhNnZc2bR5B6SqSG7bqMwLzln8(vector3D3, _0023_003DzkEYxO1SuR1Kw3, _0023_003DzH1SwwS4_003D, _0023_003DzAXKeXGcDZTLL, _0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D, _0023_003DzbUvT9Pc_003D, out _texCoords[num]);
				richSmoothTriangle.T3 = num++;
			}
			else
			{
				RichTriangle richTriangle = (RichTriangle)_triangles[i];
				Vector3D _0023_003DzZbOaTIM_003D = _0023_003Dzptomndc_003D * _normals[i];
				Point3D _0023_003DzkEYxO1SuR1Kw4 = _0023_003Dzptomndc_003D * _vertices[richTriangle.V1];
				Point3D _0023_003DzkEYxO1SuR1Kw5 = _0023_003Dzptomndc_003D * _vertices[richTriangle.V2];
				Point3D _0023_003DzkEYxO1SuR1Kw6 = _0023_003Dzptomndc_003D * _vertices[richTriangle.V3];
				_0023_003DzVbrhNnZc2bR5B6SqSG7bqMwLzln8(_0023_003DzZbOaTIM_003D, _0023_003DzkEYxO1SuR1Kw4, _0023_003DzH1SwwS4_003D, _0023_003DzAXKeXGcDZTLL, _0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D, _0023_003DzbUvT9Pc_003D, out _texCoords[num]);
				richTriangle.T1 = num++;
				_0023_003DzVbrhNnZc2bR5B6SqSG7bqMwLzln8(_0023_003DzZbOaTIM_003D, _0023_003DzkEYxO1SuR1Kw5, _0023_003DzH1SwwS4_003D, _0023_003DzAXKeXGcDZTLL, _0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D, _0023_003DzbUvT9Pc_003D, out _texCoords[num]);
				richTriangle.T2 = num++;
				_0023_003DzVbrhNnZc2bR5B6SqSG7bqMwLzln8(_0023_003DzZbOaTIM_003D, _0023_003DzkEYxO1SuR1Kw6, _0023_003DzH1SwwS4_003D, _0023_003DzAXKeXGcDZTLL, _0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D, _0023_003DzbUvT9Pc_003D, out _texCoords[num]);
				richTriangle.T3 = num++;
			}
		}
	}

	private void _0023_003DzeJ1C1fJNDOro_00245eK1w_003D_003D(float _0023_003DzAZbTv8c_003D, float _0023_003DzirIS_0024oE_003D, Transformation _0023_003Dzptomndc_003D)
	{
		int num = 0;
		for (int i = 0; i < _triangles.Length; i++)
		{
			if (_meshNature == natureType.RichSmooth)
			{
				RichSmoothTriangle richSmoothTriangle = (RichSmoothTriangle)_triangles[i];
				Vector3D vector3D = _0023_003Dzptomndc_003D * _normals[richSmoothTriangle.N1];
				Vector3D vector3D2 = _0023_003Dzptomndc_003D * _normals[richSmoothTriangle.N2];
				Vector3D vector3D3 = _0023_003Dzptomndc_003D * _normals[richSmoothTriangle.N3];
				Vector3D _0023_003DzH1SwwS4_003D = vector3D + vector3D2 + vector3D3;
				_0023_003DzlkTYbEYPmoNRW69pXqY16uY_003D(num, vector3D, _0023_003DzH1SwwS4_003D, _0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D, out _texCoords[num]);
				richSmoothTriangle.T1 = num++;
				_0023_003DzlkTYbEYPmoNRW69pXqY16uY_003D(num, vector3D2, _0023_003DzH1SwwS4_003D, _0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D, out _texCoords[num]);
				richSmoothTriangle.T2 = num++;
				_0023_003DzlkTYbEYPmoNRW69pXqY16uY_003D(num, vector3D3, _0023_003DzH1SwwS4_003D, _0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D, out _texCoords[num]);
				richSmoothTriangle.T3 = num++;
			}
			else
			{
				RichTriangle obj = (RichTriangle)_triangles[i];
				Vector3D vector3D4 = _0023_003Dzptomndc_003D * _normals[i];
				_0023_003DzlkTYbEYPmoNRW69pXqY16uY_003D(num, vector3D4, vector3D4, _0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D, out _texCoords[num]);
				obj.T1 = num++;
				_0023_003DzlkTYbEYPmoNRW69pXqY16uY_003D(num, vector3D4, vector3D4, _0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D, out _texCoords[num]);
				obj.T2 = num++;
				_0023_003DzlkTYbEYPmoNRW69pXqY16uY_003D(num, vector3D4, vector3D4, _0023_003DzAZbTv8c_003D, _0023_003DzirIS_0024oE_003D, out _texCoords[num]);
				obj.T3 = num++;
			}
		}
	}

	private static void _0023_003DzTpFv2M86AB9X2FztbQ_003D_003D(Vector3D _0023_003DzZbOaTIM_003D, Point3D _0023_003DzkEYxO1SuR1Kw, float _0023_003DzAXKeXGcDZTLL, float _0023_003DzAZbTv8c_003D, float _0023_003DzirIS_0024oE_003D, Point3D _0023_003DzbUvT9Pc_003D, out PointF _0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D)
	{
		double num = Math.PI / 2.0 + _0023_003DzZbOaTIM_003D.AngleFromXY;
		float x = (float)(_0023_003DzkEYxO1SuR1Kw.X - _0023_003DzbUvT9Pc_003D.X) / _0023_003DzAXKeXGcDZTLL;
		float y = (float)(_0023_003DzkEYxO1SuR1Kw.Y - _0023_003DzbUvT9Pc_003D.Y) / _0023_003DzAXKeXGcDZTLL;
		if (num >= Math.PI * 3.0 / 4.0)
		{
			_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D = new PointF(x, y);
		}
		else if (num <= Math.PI / 4.0)
		{
			_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D = new PointF(x, y);
		}
		else
		{
			_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D = default(PointF);
		}
		_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D.X *= _0023_003DzAZbTv8c_003D;
		_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D.Y *= _0023_003DzirIS_0024oE_003D;
		_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D.X += 0.5f;
		_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D.Y += 0.5f;
	}

	private static void _0023_003DzzqvomizsZhBQbvLusSN52Co_003D(Vector3D _0023_003DzZbOaTIM_003D, Point3D _0023_003DzkEYxO1SuR1Kw, float _0023_003DzAXKeXGcDZTLL, float _0023_003DzAZbTv8c_003D, float _0023_003DzirIS_0024oE_003D, Point3D _0023_003DzbUvT9Pc_003D, out PointF _0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D)
	{
		double num = _0023_003DzZbOaTIM_003D.AngleInXY;
		double num2 = Math.PI / 2.0 + _0023_003DzZbOaTIM_003D.AngleFromXY;
		float num3 = (float)(_0023_003DzkEYxO1SuR1Kw.X - _0023_003DzbUvT9Pc_003D.X) / _0023_003DzAXKeXGcDZTLL;
		float num4 = (float)(_0023_003DzkEYxO1SuR1Kw.Y - _0023_003DzbUvT9Pc_003D.Y) / _0023_003DzAXKeXGcDZTLL;
		float y = (float)(_0023_003DzkEYxO1SuR1Kw.Z - _0023_003DzbUvT9Pc_003D.Z) / _0023_003DzAXKeXGcDZTLL;
		if (num < 0.0)
		{
			num += Math.PI * 2.0;
		}
		if ((num >= 5.497787143782138 || num < Math.PI / 4.0) && num2 > Math.PI / 4.0 && num2 < Math.PI * 3.0 / 4.0)
		{
			_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D = new PointF(num4, y);
		}
		else if (num >= Math.PI / 4.0 && num < Math.PI * 3.0 / 4.0 && num2 > Math.PI / 4.0 && num2 < Math.PI * 3.0 / 4.0)
		{
			_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D = new PointF(1f - num3, y);
		}
		else if (num >= Math.PI * 3.0 / 4.0 && num < 3.9269908169872414 && num2 > Math.PI / 4.0 && num2 < Math.PI * 3.0 / 4.0)
		{
			_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D = new PointF(1f - num4, y);
		}
		else if (num >= 3.9269908169872414 && num < 5.497787143782138 && num2 > Math.PI / 4.0 && num2 < Math.PI * 3.0 / 4.0)
		{
			_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D = new PointF(num3, y);
		}
		else if (num2 >= Math.PI * 3.0 / 4.0)
		{
			_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D = new PointF(num3, num4);
		}
		else
		{
			_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D = new PointF(num3, 1f - num4);
		}
		_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D.X *= _0023_003DzAZbTv8c_003D;
		_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D.Y *= _0023_003DzirIS_0024oE_003D;
		_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D.X += 0.5f;
		_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D.Y += 0.5f;
	}

	private static void _0023_003DzVbrhNnZc2bR5B6SqSG7bqMwLzln8(Vector3D _0023_003DzZbOaTIM_003D, Point3D _0023_003DzkEYxO1SuR1Kw, Vector3D _0023_003DzH1SwwS4_003D, float _0023_003DzAXKeXGcDZTLL, float _0023_003DzAZbTv8c_003D, float _0023_003DzirIS_0024oE_003D, Point3D _0023_003DzbUvT9Pc_003D, out PointF _0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D)
	{
		double num = Math.PI / 2.0 + _0023_003DzZbOaTIM_003D.AngleFromXY;
		float x = (float)(_0023_003DzkEYxO1SuR1Kw.X - _0023_003DzbUvT9Pc_003D.X) / _0023_003DzAXKeXGcDZTLL;
		float num2 = (float)(_0023_003DzkEYxO1SuR1Kw.Y - _0023_003DzbUvT9Pc_003D.Y) / _0023_003DzAXKeXGcDZTLL;
		float y = (float)(_0023_003DzkEYxO1SuR1Kw.Z - _0023_003DzbUvT9Pc_003D.Z) / _0023_003DzAXKeXGcDZTLL;
		if (num > Math.PI * 3.0 / 4.0)
		{
			_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D = new PointF(x, num2);
		}
		else if (num < Math.PI / 4.0)
		{
			_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D = new PointF(x, 1f - num2);
		}
		else
		{
			double num3 = _0023_003DzZbOaTIM_003D.AngleInXY;
			if (num3 < 0.0)
			{
				num3 += Math.PI * 2.0;
			}
			_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D = new PointF((float)(num3 / (Math.PI * 2.0) - 0.5), 0f);
			if (Math.Abs(num3) < 0.001 && Math.Abs(_0023_003DzZbOaTIM_003D.Y) < 0.001 && _0023_003DzH1SwwS4_003D.Y < 0.0)
			{
				_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D.X = 0.5f;
			}
			_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D.Y = y;
		}
		_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D.X *= _0023_003DzAZbTv8c_003D;
		_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D.Y *= _0023_003DzirIS_0024oE_003D;
		_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D.X += 0.5f;
		_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D.Y += 0.5f;
	}

	private static void _0023_003DzlkTYbEYPmoNRW69pXqY16uY_003D(int _0023_003Dzfsn580w_003D, Vector3D _0023_003DzZbOaTIM_003D, Vector3D _0023_003DzH1SwwS4_003D, float _0023_003DzAZbTv8c_003D, float _0023_003DzirIS_0024oE_003D, out PointF _0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D)
	{
		double num = _0023_003DzZbOaTIM_003D.AngleInXY;
		if (num < 0.0)
		{
			num += Math.PI * 2.0;
		}
		_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D = new PointF((float)(num / (Math.PI * 2.0) - 0.5), 0f);
		if (Math.Abs(num) < 0.001 && Math.Abs(_0023_003DzZbOaTIM_003D.Y) < 0.001 && _0023_003DzH1SwwS4_003D.Y < 0.0)
		{
			_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D.X = 0.5f;
		}
		_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D.Y = (float)((Math.PI / 2.0 + _0023_003DzZbOaTIM_003D.AngleFromXY) / Math.PI - 0.5);
		_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D.X *= _0023_003DzAZbTv8c_003D;
		_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D.Y *= _0023_003DzirIS_0024oE_003D;
		_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D.X += 0.5f;
		_0023_003DzviGwGBQQ8tmRHUA0yQ_003D_003D.Y += 0.5f;
	}

	protected override void InitGraphicsData(RenderContextBase renderContext)
	{
		base.InitGraphicsData(renderContext);
		if (drawEdgesData == null)
		{
			drawEdgesData = renderContext.CreateEntityGraphicsData(this);
		}
		if (drawSelectedData == null)
		{
			drawSelectedData = renderContext.CreateEntityGraphicsData(this);
		}
	}

	public override void Compile(CompileParams data)
	{
		InitGraphicsData(data.RenderContext);
		data.RenderContext.Compile(drawData, DrawEntity, null);
		CompileEdges(0.0, 0, data);
		natureType meshNature = MeshNature;
		if (meshNature - 2 <= natureType.ColorPlain || meshNature - 6 <= natureType.ColorPlain)
		{
			CompileSelected(data);
		}
		if (Faces != null)
		{
			for (int i = 0; i < Faces.Count; i++)
			{
				CompileSelectedFace(data.RenderContext, Faces[i]);
			}
		}
		RegenMode = regenType.NotNeeded;
	}

	protected new virtual void DrawEntity(RenderContextBase context, object myParams)
	{
		switch (MeshNature)
		{
		case natureType.Plain:
			context.DrawPlainTriangles(Triangles, Vertices, Normals);
			break;
		case natureType.Smooth:
			context.DrawSmoothTriangles(Triangles, Vertices, Normals);
			break;
		case natureType.ColorPlain:
			context.DrawColorPlainTriangles(Triangles, Vertices, Normals);
			break;
		case natureType.ColorSmooth:
			context.DrawColorSmoothTriangles(Triangles, Vertices, Normals);
			break;
		case natureType.MulticolorPlain:
			context.DrawMulticolorPlainTriangles(Triangles, Vertices, Normals);
			break;
		case natureType.MulticolorSmooth:
			context.DrawMulticolorSmoothTriangles(Triangles, Vertices, Normals);
			break;
		case natureType.RichPlain:
			context.DrawRichPlainTriangles(Triangles, Vertices, Normals, TextureCoords);
			break;
		case natureType.RichSmooth:
			context.DrawRichSmoothTriangles(Triangles, Vertices, Normals, TextureCoords);
			break;
		}
	}

	protected internal void CompileEdges(double ampFactor, int mode, CompileParams data)
	{
		if (EdgeStyle == edgeStyleType.None || Edges == null)
		{
			Edges = null;
			drawEdgesData.Dispose();
			return;
		}
		if (ampFactor == 0.0)
		{
			data.RenderContext.Compile(drawEdgesData, _0023_003DzwNpJQPn9NtkE, new DrawEdgesInternalParams
			{
				ampFactor = ampFactor,
				lines = Edges
			});
			return;
		}
		data.RenderContext.Compile(drawEdgesData, delegate(RenderContextBase _0023_003DzQdnFby4_003D, object _0023_003DzmPmPjCPqZ3T3)
		{
			DrawEdgesInternalParams drawEdgesInternalParams = (DrawEdgesInternalParams)_0023_003DzmPmPjCPqZ3T3;
			if (drawEdgesInternalParams.lines.Length != 0)
			{
				_0023_003DzQdnFby4_003D.DrawIndexLinesWithDisplacement(drawEdgesInternalParams.lines, Vertices, drawEdgesInternalParams.ampFactor, drawEdgesInternalParams.Mode);
			}
		}, new DrawEdgesInternalParams
		{
			ampFactor = ampFactor,
			lines = Edges,
			Mode = mode
		});
	}

	private void _0023_003DzppEsK_3Q6S_0024X(RenderContextBase _0023_003DzQdnFby4_003D, object _0023_003DzmPmPjCPqZ3T3)
	{
		DrawEdgesInternalParams drawEdgesInternalParams = (DrawEdgesInternalParams)_0023_003DzmPmPjCPqZ3T3;
		if (drawEdgesInternalParams.lines.Length != 0)
		{
			_0023_003DzQdnFby4_003D.DrawIndexLinesWithDisplacement(drawEdgesInternalParams.lines, Vertices, drawEdgesInternalParams.ampFactor, drawEdgesInternalParams.Mode);
		}
	}

	private void _0023_003DzwNpJQPn9NtkE(RenderContextBase _0023_003DzQdnFby4_003D, object _0023_003DzmPmPjCPqZ3T3)
	{
		_0023_003DzQdnFby4_003D.DrawIndexLines(((DrawEdgesInternalParams)_0023_003DzmPmPjCPqZ3T3).lines, Vertices);
	}

	protected virtual void CompileSelected(CompileParams data)
	{
		data.RenderContext.Compile(drawSelectedData, _0023_003DzanB6YgBA_IW1jvjjlB3tzNM_003D, null);
	}

	private void _0023_003DzanB6YgBA_IW1jvjjlB3tzNM_003D(RenderContextBase _0023_003DzQdnFby4_003D, object _0023_003DzmPmPjCPqZ3T3)
	{
		natureType meshNature = MeshNature;
		if (meshNature - 2 <= natureType.ColorPlain)
		{
			_0023_003DzQdnFby4_003D.DrawPlainTrianglesNoColors(Triangles, Vertices, Normals);
		}
		else
		{
			_0023_003DzQdnFby4_003D.DrawSmoothTriangles(Triangles, Vertices, Normals);
		}
	}

	protected internal override void Draw(DrawParams data)
	{
		if (_0023_003DzxsZqpH64pLwL(data, SelectionMode))
		{
			_0023_003DzWrBM_0024AXx6fJO2ag57A_003D_003D(data, this, Faces, FacesSelectionInfo, _0023_003DzXpDbwQkKXyuT);
		}
		else
		{
			data.RenderContext.Draw(drawData);
		}
	}

	private void _0023_003DzabFld05zU9Mg(DrawParams _0023_003DzELu0Pss_003D)
	{
		natureType meshNature = MeshNature;
		if (meshNature - 2 <= natureType.Plain || meshNature - 6 <= natureType.Plain)
		{
			_0023_003DzELu0Pss_003D.RenderContext.ColorMaterialMode = colorMaterialType.Disabled;
		}
	}

	private void _0023_003DzJEiCNqlYb39U(DrawParams _0023_003DzELu0Pss_003D)
	{
		natureType meshNature = MeshNature;
		if (meshNature - 2 <= natureType.Plain || meshNature - 6 <= natureType.Plain)
		{
			_0023_003DzELu0Pss_003D.RenderContext.ColorMaterialMode = colorMaterialType.FrontAndBackFaceDiffuse;
		}
	}

	private void _0023_003Dzdz4qVc5Sdyo4(DrawParams _0023_003DzELu0Pss_003D)
	{
		if (_0023_003DzELu0Pss_003D.Direct3D)
		{
			_0023_003DzELu0Pss_003D.RenderContext.Draw(drawData);
			return;
		}
		natureType meshNature = MeshNature;
		if (meshNature == natureType.Plain || meshNature == natureType.Smooth)
		{
			_0023_003DzELu0Pss_003D.RenderContext.Draw(drawData);
		}
		else
		{
			_0023_003DzELu0Pss_003D.RenderContext.Draw(drawSelectedData);
		}
	}

	protected internal override void SetShader(DrawParams data)
	{
		if (data.RenderContext.Shaders == null)
		{
			return;
		}
		bool flag = false;
		ShaderParameters shaderParams = data.ShaderParams;
		bool texture2D = false;
		bool withNormals = false;
		if (!data.ForceGray && !data.Selected)
		{
			natureType meshNature = MeshNature;
			if (meshNature - 2 <= natureType.Plain || meshNature - 6 <= natureType.Plain)
			{
				texture2D = shaderParams.Texture2D;
				withNormals = shaderParams.WithNormals;
				shaderParams.Texture2D = false;
				shaderParams.Multicolor = true;
				shaderParams.WithNormals = true;
				flag = true;
			}
		}
		bool selected = shaderParams.Selected;
		if (data.Selected)
		{
			texture2D = shaderParams.Texture2D;
			shaderParams.Texture2D = false;
			shaderParams.Selected = true;
			flag = true;
		}
		base.SetShader(data);
		if (flag)
		{
			shaderParams.Multicolor = false;
			shaderParams.Texture2D = texture2D;
			shaderParams.Selected = selected;
			shaderParams.WithNormals = withNormals;
			data.RenderContext.SetBlockRefTransform(data.ShaderParams.BlockRefTansformMatrix);
		}
	}

	protected internal override void Render(RenderParams data)
	{
		_0023_003DzJEiCNqlYb39U(data);
		if (_0023_003DzxsZqpH64pLwL(data, SelectionMode))
		{
			_0023_003DzWrBM_0024AXx6fJO2ag57A_003D_003D(data, this, Faces, FacesSelectionInfo, _0023_003DzXpDbwQkKXyuT);
		}
		else
		{
			data.RenderContext.Draw(drawData);
		}
		if (_0023_003Dzo6ce7KB1fIwf() && !base.Selected)
		{
			data.RenderContext.ResetColorDiffuse();
		}
		_0023_003DzabFld05zU9Mg(data);
	}

	protected internal override void DrawHiddenLinesMaterial(RenderParams data)
	{
		if (_0023_003Dzo6ce7KB1fIwf())
		{
			DrawHiddenLines(data);
		}
		else
		{
			base.DrawHiddenLinesMaterial(data);
		}
	}

	protected internal override void DrawHiddenLines(DrawParams data)
	{
		bool flag = _0023_003Dzo6ce7KB1fIwf();
		IViewportInternal viewportInternal = data.viewportInternal;
		bool flag2 = flag && !data.Selected && viewportInternal.parent.HiddenLines.ColorMethod != hiddenLinesColorMethodType.SingleColor;
		if (flag2)
		{
			SetShader(data);
		}
		if (_0023_003DzxsZqpH64pLwL(data, SelectionMode))
		{
			_0023_003DzWrBM_0024AXx6fJO2ag57A_003D_003D(data, this, Faces, FacesSelectionInfo, _0023_003DzXpDbwQkKXyuT);
			return;
		}
		if (flag)
		{
			if (data.Selected || viewportInternal.parent.HiddenLines.ColorMethod == hiddenLinesColorMethodType.SingleColor)
			{
				_0023_003Dzdz4qVc5Sdyo4(data);
			}
			else if (viewportInternal.parent.Backface.ColorMethod == backfaceColorMethodType.SingleColor)
			{
				data.RenderContext.ColorMaterialMode = colorMaterialType.FrontFaceAmbient;
				data.RenderContext.Draw(drawData);
				data.RenderContext.ColorMaterialMode = colorMaterialType.Disabled;
			}
			else
			{
				_0023_003DzJEiCNqlYb39U(data);
				data.RenderContext.Draw(drawData);
				_0023_003DzabFld05zU9Mg(data);
			}
		}
		else
		{
			data.RenderContext.Draw(drawData);
		}
		if (flag2)
		{
			data.RenderContext.ResetColorDiffuse();
		}
	}

	protected internal override void DrawFlat(DrawParams data)
	{
		bool flag = _0023_003Dzo6ce7KB1fIwf();
		bool flag2 = flag && !base.Selected;
		if (flag2)
		{
			SetShader(data);
		}
		if (_0023_003DzxsZqpH64pLwL(data, SelectionMode))
		{
			_0023_003DzWrBM_0024AXx6fJO2ag57A_003D_003D(data, this, Faces, FacesSelectionInfo, _0023_003DzXpDbwQkKXyuT);
			return;
		}
		if (flag)
		{
			if (data.viewportInternal.parent.Backface.ColorMethod == backfaceColorMethodType.SingleColor)
			{
				data.RenderContext.ColorMaterialMode = colorMaterialType.FrontFaceAmbient;
				data.RenderContext.Draw(drawData);
				data.RenderContext.ColorMaterialMode = colorMaterialType.Disabled;
			}
			else
			{
				_0023_003DzJEiCNqlYb39U(data);
				data.RenderContext.Draw(drawData);
				_0023_003DzabFld05zU9Mg(data);
			}
		}
		else
		{
			data.RenderContext.Draw(drawData);
		}
		if (flag2)
		{
			data.RenderContext.ResetColorDiffuse();
		}
	}

	internal static bool _0023_003DzxsZqpH64pLwL(DrawParams _0023_003DzELu0Pss_003D, selectionFilterType _0023_003DzMUbVFNZrm3OW)
	{
		if (!_0023_003DzELu0Pss_003D.ForceGray && !_0023_003DzELu0Pss_003D.ParentSelected && _0023_003DzELu0Pss_003D.Selected)
		{
			return FlagsHelper.IsSet(_0023_003DzMUbVFNZrm3OW, selectionFilterType.Face);
		}
		return false;
	}

	protected internal override void DrawSelected(DrawParams data)
	{
		if (_0023_003DzxsZqpH64pLwL(data, SelectionMode))
		{
			_0023_003DzWrBM_0024AXx6fJO2ag57A_003D_003D(data, this, Faces, FacesSelectionInfo, _0023_003DzXpDbwQkKXyuT);
		}
		else
		{
			_0023_003DzXpDbwQkKXyuT(data);
		}
	}

	internal static void _0023_003DzWrBM_0024AXx6fJO2ag57A_003D_003D(DrawParams _0023_003DzELu0Pss_003D, ISelectableItem _0023_003DzG1TqnNw_003D, EyeshotDisposableCollection<FaceElement> _0023_003DzpPOEJqcAh7Lr, List<SelectionInfoSubItems> _0023_003DzoGA4X4wccrMEeZb9jatssYQ_003D, _0023_003DzBj46ktwYVXnE _0023_003DzbRo3bwaiUFl3)
	{
		if (!_0023_003DzELu0Pss_003D.IsDrawingForHalo)
		{
			if (_0023_003DzELu0Pss_003D.SelectionStatus == selectionStatusType.Temporary)
			{
				_0023_003DzELu0Pss_003D.RenderContext.PushBlendState();
				_0023_003DzELu0Pss_003D.RenderContext.SetState(blendStateType.ColorMaskOff);
				_0023_003DzbRo3bwaiUFl3(_0023_003DzELu0Pss_003D);
				_0023_003DzELu0Pss_003D.RenderContext.PopBlendState();
			}
			else
			{
				_0023_003DzELu0Pss_003D.RenderContext.PushShader();
				Entity.SetEntityColorForSelection(_0023_003DzELu0Pss_003D);
				_0023_003DzbRo3bwaiUFl3(_0023_003DzELu0Pss_003D);
				_0023_003DzELu0Pss_003D.RenderContext.PopShader();
			}
		}
		SelectionInfoSubItems selectionInfoSubItems = SelectionInfoItemBase.FindInstance(_0023_003DzELu0Pss_003D.Parents, _0023_003DzG1TqnNw_003D, null, _0023_003DzoGA4X4wccrMEeZb9jatssYQ_003D);
		if (selectionInfoSubItems == null)
		{
			return;
		}
		_0023_003DzELu0Pss_003D.RenderContext.PushDepthStencilState();
		if (_0023_003DzELu0Pss_003D.RenderContext.CurrentDepthStencilState != depthStencilStateType.DepthMaskFalse_DepthTestLess && !_0023_003DzELu0Pss_003D.IsDrawingForHalo)
		{
			_0023_003DzELu0Pss_003D.RenderContext.SetState(depthStencilStateType.DepthTestEqual);
		}
		bool lighting = _0023_003DzELu0Pss_003D.RenderContext.LightingEnabled();
		_0023_003DzELu0Pss_003D.RenderContext.PushShader();
		Entity.SetSelectionColorForSelection(_0023_003DzELu0Pss_003D);
		for (int i = 0; i < selectionInfoSubItems.SubItems.Length; i++)
		{
			if (selectionInfoSubItems.SubItems[i].IsFlagSet(_0023_003DzELu0Pss_003D.SelectionStatus))
			{
				_0023_003DzELu0Pss_003D.RenderContext.Draw(_0023_003DzpPOEJqcAh7Lr[i]._0023_003Dzgv_pSOc_003D);
			}
		}
		_0023_003DzELu0Pss_003D.RenderContext.PopShader();
		_0023_003DzELu0Pss_003D.RenderContext.SetLighting(lighting);
		_0023_003DzELu0Pss_003D.RenderContext.PopDepthStencilState();
	}

	public void CompileSelectedFace(RenderContextBase renderContext, FaceElement faceData)
	{
		if (faceData._0023_003Dzgv_pSOc_003D == null)
		{
			faceData._0023_003Dzgv_pSOc_003D = renderContext.CreateEntityGraphicsData(faceData);
		}
		renderContext.Compile(faceData._0023_003Dzgv_pSOc_003D, DrawFace, faceData.Triangles);
	}

	public void DrawFace(RenderContextBase renderContext, object data)
	{
		List<int> list = (List<int>)data;
		if (list.Count == 0)
		{
			return;
		}
		Point3D[] array = new Point3D[list.Count * 3];
		Vector3D[] array2 = new Vector3D[array.Length];
		if (Triangles[0] is ITriangleSupportsNormals)
		{
			int num = 0;
			for (int i = 0; i < list.Count; i++)
			{
				IndexTriangle indexTriangle = Triangles[list[i]];
				array[num] = Vertices[indexTriangle.V1];
				array[num + 1] = Vertices[indexTriangle.V2];
				array[num + 2] = Vertices[indexTriangle.V3];
				ITriangleSupportsNormals triangleSupportsNormals = (ITriangleSupportsNormals)indexTriangle;
				array2[num++] = Normals[triangleSupportsNormals.N1];
				array2[num++] = Normals[triangleSupportsNormals.N2];
				array2[num++] = Normals[triangleSupportsNormals.N3];
			}
		}
		else
		{
			int num2 = 0;
			for (int j = 0; j < list.Count; j++)
			{
				IndexTriangle indexTriangle2 = Triangles[list[j]];
				int num3 = list[j];
				array[num2] = Vertices[indexTriangle2.V1];
				array[num2 + 1] = Vertices[indexTriangle2.V2];
				array[num2 + 2] = Vertices[indexTriangle2.V3];
				array2[num2++] = Normals[num3];
				array2[num2++] = Normals[num3];
				array2[num2++] = Normals[num3];
			}
		}
		renderContext.DrawTriangles(array, array2);
	}

	private void _0023_003DzXpDbwQkKXyuT(DrawParams _0023_003DzELu0Pss_003D)
	{
		if (_0023_003DzELu0Pss_003D.Direct3D)
		{
			_0023_003Dzdz4qVc5Sdyo4(_0023_003DzELu0Pss_003D);
		}
		else if (_0023_003Dzo6ce7KB1fIwf())
		{
			_0023_003DzELu0Pss_003D.RenderContext.Draw(drawSelectedData);
		}
		else
		{
			_0023_003DzELu0Pss_003D.RenderContext.Draw(drawData);
		}
	}

	private bool _0023_003Dzo6ce7KB1fIwf()
	{
		if (MeshNature != natureType.Plain && MeshNature != natureType.Smooth && MeshNature != natureType.RichPlain)
		{
			return MeshNature != natureType.RichSmooth;
		}
		return false;
	}

	protected internal override void DrawWireframe(DrawParams data)
	{
	}

	protected internal override void DrawIsocurves(DrawParams data)
	{
		if (!_0023_003Dz5sgFm90LQ3fISwPMCQ_003D_003D(data, SelectionMode))
		{
			_0023_003Dzdz4qVc5Sdyo4(data);
		}
	}

	protected internal override void DrawForShadow(RenderParams data)
	{
		_0023_003Dzdz4qVc5Sdyo4(data);
	}

	protected internal override void DrawNormals(DrawParams data)
	{
		double normalLength = GetNormalLength();
		_0023_003DzqqLthO6qQNxyQOPS9Q_003D_003D(data, normalLength);
	}

	internal void _0023_003DzUvUzTv6XO92zTU6hSQ_003D_003D(DrawParams _0023_003DzELu0Pss_003D, double _0023_003Dz736ekIs_003D)
	{
		_0023_003DzqqLthO6qQNxyQOPS9Q_003D_003D(_0023_003DzELu0Pss_003D, _0023_003Dz736ekIs_003D);
	}

	private void _0023_003DzqqLthO6qQNxyQOPS9Q_003D_003D(DrawParams _0023_003DzELu0Pss_003D, double _0023_003Dz736ekIs_003D)
	{
		natureType meshNature = MeshNature;
		if (meshNature - 1 <= natureType.MulticolorPlain)
		{
			_0023_003DzELu0Pss_003D.RenderContext.DrawNormals(Vertices, Triangles, Normals, _0023_003Dz736ekIs_003D);
		}
		else if (Triangles != null)
		{
			_0023_003DzELu0Pss_003D.RenderContext.DrawNormalsPerVertex(Vertices, Triangles, Normals, _0023_003Dz736ekIs_003D);
		}
	}

	protected internal override void DrawForSelectionFaces(DrawForSelectionParams data)
	{
		for (int i = 0; i < Triangles.Length; i++)
		{
			IndexTriangle indexTriangle = Triangles[i];
			data.viewportInternal.parent.SetColorDrawForSelectionAndUpdateIdItemsMap<SelectedFace>(data, this, i);
			data.RenderContext.DrawTriangles(new Point3D[3]
			{
				Vertices[indexTriangle.V1],
				Vertices[indexTriangle.V2],
				Vertices[indexTriangle.V3]
			}, Vector3D.AxisZ);
			data.FalseColorIndex++;
		}
	}

	protected internal override void DrawForSelection(DrawForSelectionParams data)
	{
		_0023_003Dzdz4qVc5Sdyo4(data);
	}

	protected internal override void DrawForSelectionWireframe(DrawForSelectionParams data)
	{
		if (data.Isocurves)
		{
			base.DrawForSelectionWireframe(data);
		}
		else
		{
			DrawEdges(data);
		}
	}

	internal static bool _0023_003Dz5sgFm90LQ3fISwPMCQ_003D_003D(DrawParams _0023_003DzELu0Pss_003D, selectionFilterType _0023_003DzMUbVFNZrm3OW)
	{
		if (_0023_003DzELu0Pss_003D.IsDrawingForHalo)
		{
			return true;
		}
		if (!_0023_003DzELu0Pss_003D.ForceGray && _0023_003DzELu0Pss_003D.Selected && !FlagsHelper.IsSet(_0023_003DzMUbVFNZrm3OW, selectionFilterType.Entity))
		{
			_0023_003DzELu0Pss_003D.RenderContext.SetColorWireframe(_0023_003DzELu0Pss_003D.InsideColor);
		}
		return false;
	}

	protected internal override void SetLineWeightForSilhouettes(DrawSilhouettesParams data)
	{
		float num = data.SilhoThickness;
		if (data.Selected && !FlagsHelper.IsSet(SelectionMode, selectionFilterType.Face))
		{
			num *= data.SelectionLineWeightScaleFactor;
		}
		_0023_003Dzw7EU_3iuNJBd(data, num);
	}

	protected internal override void SetLineWeightForEdges(DrawParams data)
	{
		float num = data.EdgeThickness;
		if (data.Selected && !FlagsHelper.IsSet(SelectionMode, selectionFilterType.Face))
		{
			num *= data.SelectionLineWeightScaleFactor;
		}
		_0023_003Dzw7EU_3iuNJBd(data, num);
	}

	protected internal override void DrawEdges(DrawParams data)
	{
		if (EdgeStyle != edgeStyleType.None && !LightWeight && drawEdgesData.IsValid() && !_0023_003Dz5sgFm90LQ3fISwPMCQ_003D_003D(data, SelectionMode))
		{
			data.RenderContext.Draw(drawEdgesData);
		}
	}

	protected internal override void DrawSilhouettes(DrawSilhouettesParams data)
	{
		if (!LightWeight)
		{
			if (sharedEdgesForSilhouettesDraw == null)
			{
				sharedEdgesForSilhouettesDraw = Utility.GetEdgesWithoutDuplicates(Triangles, Vertices.Length);
			}
			if (!_0023_003Dz5sgFm90LQ3fISwPMCQ_003D_003D(data, SelectionMode))
			{
				HiddenLinesView._0023_003DzY9TYF9sTjnZYO51HtXX26S0_003D(this, data);
			}
		}
	}

	public void ApplyMaterial(string matName, textureMappingType mappingMode, double scaleX, double scaleY)
	{
		UpdateBoundingBox(null);
		ApplyMaterial(matName, mappingMode, scaleX, scaleY, localMin, localMax);
	}

	public void ApplyMaterial(string matName, textureMappingType mappingMode, double scaleX, double scaleY, Point3D boxMin, Point3D boxMax)
	{
		MaterialName = matName;
		ColorMethod = colorMethodType.byEntity;
		ApplyTextureMapping(mappingMode, scaleX, scaleY, boxMin, boxMax);
	}

	public void ApplyTextureMapping(textureMappingType mappingMode, double scaleX, double scaleY)
	{
		UpdateBoundingBox(null);
		ApplyTextureMapping(mappingMode, scaleX, scaleY, localMin, localMax);
	}

	public void RemoveMaterial()
	{
		MaterialName = null;
		RemoveTextureMapping();
	}

	public void BuildOctree(int maxNumTriangles = 0)
	{
		if (base.BoxMin == null || base.BoxMax == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972443));
		}
		_subdivisionTree = new Octree(this, maxNumTriangles);
		_subdivisionTree.DoWork();
	}

	public void ClearOctree()
	{
		_subdivisionTree = null;
	}

	public bool GetFaceSelection(int faceIndex, Stack<BlockReference> parents = null)
	{
		return SelectionInfoItemBase._0023_003Dz4SMVPY0ZDXX8(this, Faces, FacesSelectionInfo, faceIndex, parents);
	}

	public bool GetFaceSelection(int shellIndex, int faceIndex, Stack<BlockReference> parents = null)
	{
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972621));
	}

	public void SetFaceSelection(int shellIndex, int faceIndex, bool status, Stack<BlockReference> parents = null)
	{
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972621));
	}

	public void SetFaceSelection(int faceIndex, bool status, Stack<BlockReference> parents = null)
	{
		SelectionInfoSubItems._0023_003DzTaF8sCpHm_00245q(selectionFilterType.Face, faceIndex, status, this, Faces, FacesSelectionInfo, parents);
	}

	public void ClearFacesSelection(Stack<BlockReference> parents = null)
	{
		int num = SelectedItemBase._0023_003DzAdoyA7k_003D(new SelectionInfoSubItems(parents, this), FacesSelectionInfo);
		if (num >= 0)
		{
			FacesSelectionInfo.RemoveAt(num);
		}
	}

	public void ClearFacesSelectionForAllInstances()
	{
		FacesSelectionInfo.Clear();
	}

	internal override bool IsSelected(Stack<BlockReference> _0023_003Dzq5nwX2I_003D, selectionStatusType _0023_003DzLEq8mIc_003D)
	{
		switch (SelectionMode)
		{
		case selectionFilterType.Entity:
			return base.IsSelected(_0023_003Dzq5nwX2I_003D, _0023_003DzLEq8mIc_003D);
		case selectionFilterType.Face:
		{
			if (FacesSelectionInfo.Count > 0 && SelectionInfoItem._0023_003DzAdoyA7k_003D(_0023_003Dzq5nwX2I_003D, this, FacesSelectionInfo, out var _0023_003Dzv0Okb82R5LqH))
			{
				return SelectionInfoSubItems.IsAnySelected(_0023_003Dzv0Okb82R5LqH.SubItems, _0023_003DzLEq8mIc_003D);
			}
			break;
		}
		}
		return false;
	}

	public bool IsAnyFaceSelected()
	{
		return SelectionInfoSubItems.IsAnySelected(FacesSelectionInfo);
	}

	internal override List<SelectionInfoSubItems> _0023_003Dz4NlMyrooY_aHAHG2Ag_003D_003D()
	{
		return FacesSelectionInfo;
	}

	internal override int _0023_003Dz5RPGbcVkdZb3()
	{
		if (Faces == null)
		{
			return base._0023_003Dz5RPGbcVkdZb3();
		}
		return Faces.Count;
	}

	public void ResetSelectionMode()
	{
		if (!IsAnyFaceSelected())
		{
			SelectionMode = selectionFilterType.Entity;
		}
	}

	public override void Dispose()
	{
		base.Dispose();
		drawEdgesData?.Dispose();
		drawSelectedData?.Dispose();
		if (Faces != null)
		{
			Faces.Clear();
		}
	}

	protected internal override bool InsideOrCrossingFrustum(FrustumParams data)
	{
		if (!EvaluateIntersectTriangles(data))
		{
			return false;
		}
		if (Utility.InsideOrCrossingFrustum(data, Vertices, Triangles))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool InsideOrCrossingScreenPolygon(ScreenPolygonParams data)
	{
		if (!EvaluateIntersectTriangles(data))
		{
			return false;
		}
		if (Utility._0023_003DzuQDPXh1pHaNF4I3G_Evhw9Q_003D(Vertices, Triangles, data))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool ThroughTriangle(FrustumParams data)
	{
		if (Entity._0023_003Dzz3lsBX3i0Rg2(data, Vertices, Triangles))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool ThroughTriangleScreenPolygon(ScreenPolygonParams data)
	{
		if (Entity._0023_003DzOejNn2S1Lat5_0024X4DHg_003D_003D(Vertices, Triangles, data))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected override bool EvaluateIntersectEdges(FrustumParams data)
	{
		if (data.DisplayMode == displayType.Wireframe)
		{
			return !data.workspaceInternal.Wireframe.ShowInternalWires;
		}
		return false;
	}

	protected override bool EvaluateIntersectTriangles(FrustumParams data)
	{
		if (data.DisplayMode == displayType.Wireframe)
		{
			return data.workspaceInternal.Wireframe.ShowInternalWires;
		}
		return true;
	}

	internal override bool IntersectEdgeOrIsoline(FrustumParams _0023_003DzELu0Pss_003D)
	{
		if (!EvaluateIntersectEdges(_0023_003DzELu0Pss_003D))
		{
			return false;
		}
		Transformation transformation = _0023_003DzELu0Pss_003D.Transformation;
		if (transformation == null)
		{
			IndexLine[] edges = Edges;
			foreach (IndexLine indexLine in edges)
			{
				if (Utility.IsSegmentInsideOrCrossing(_0023_003DzELu0Pss_003D.Frustum, new Segment3D(Vertices[indexLine.V1], Vertices[indexLine.V2])))
				{
					AddSelectedItemLeaf(_0023_003DzELu0Pss_003D);
					return true;
				}
			}
		}
		else
		{
			IndexLine[] edges = Edges;
			foreach (IndexLine indexLine2 in edges)
			{
				if (Utility.IsSegmentInsideOrCrossing(_0023_003DzELu0Pss_003D.Frustum, new Segment3D(transformation * Vertices[indexLine2.V1], transformation * Vertices[indexLine2.V2])))
				{
					AddSelectedItemLeaf(_0023_003DzELu0Pss_003D);
					return true;
				}
			}
		}
		return false;
	}

	internal override bool IntersectEdgeOrIsolineScreenPolygon(ScreenPolygonParams _0023_003DzELu0Pss_003D)
	{
		if (!EvaluateIntersectEdges(_0023_003DzELu0Pss_003D))
		{
			return false;
		}
		Transformation transformation = _0023_003DzELu0Pss_003D.Transformation;
		if (transformation == null)
		{
			IndexLine[] edges = Edges;
			foreach (IndexLine indexLine in edges)
			{
				if (Utility._0023_003DzCDHgZnw5jGnjOTqKdaPcrb3mQArQ(Vertices[indexLine.V1], Vertices[indexLine.V2], _0023_003DzELu0Pss_003D))
				{
					AddSelectedItemLeaf(_0023_003DzELu0Pss_003D);
					return true;
				}
			}
		}
		else
		{
			IndexLine[] edges = Edges;
			foreach (IndexLine indexLine2 in edges)
			{
				if (Utility._0023_003DzCDHgZnw5jGnjOTqKdaPcrb3mQArQ(transformation * Vertices[indexLine2.V1], transformation * Vertices[indexLine2.V2], _0023_003DzELu0Pss_003D))
				{
					AddSelectedItemLeaf(_0023_003DzELu0Pss_003D);
					return true;
				}
			}
		}
		return false;
	}

	public override void Regen(RegenParams data)
	{
		_0023_003DzZTr16fkQpUZHJpROCQ_003D_003D();
		if (_meshNature == natureType.Undefined)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972577));
		}
		if (_normals == null)
		{
			UpdateNormals();
		}
		if (_edges == null)
		{
			ComputeEdges();
		}
		if (Faces != null)
		{
			Faces.ClearIfNotSelected(FacesSelectionInfo);
		}
		base.Regen(data);
	}

	internal void _0023_003Dz_0024YeSaS1uGUxB(bool _0023_003DzEkR_P10_003D)
	{
		if (_0023_003DzEkR_P10_003D || !LightWeight)
		{
			sharedEdges = Utility.GetEdgesWithoutDuplicates(Triangles, Vertices.Length);
		}
	}

	public FastMesh ConvertToFastMesh(bool indexed = true, bool dynamic = false)
	{
		if (_vertices.Length == 0)
		{
			return new FastMesh(new Point3D[0], new IndexTriangle[0]);
		}
		bool flag = _vertices[0] is PointRGB;
		bool flag2 = _vertices[0] is PointNormalUv;
		Mesh mesh = (Mesh)Clone();
		if (Utility.Compact(mesh.Vertices, mesh.Triangles, out var compacted) > 0)
		{
			mesh.Vertices = compacted;
			mesh.NormalAveragingMode = ((!indexed) ? normalAveragingType.AveragedByAngle : normalAveragingType.Averaged);
			mesh.UpdateNormals();
		}
		byte[] array = null;
		float[] array2 = null;
		FastMesh fastMesh;
		if (!indexed)
		{
			if (mesh.Normals == null)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972546));
			}
			if (flag)
			{
				array = new byte[mesh.Triangles.Length * 9];
			}
			else if (flag2)
			{
				array2 = new float[mesh.Triangles.Length * 2];
			}
			float[] array3 = new float[mesh.Triangles.Length * 9];
			int num = 0;
			int num2 = 0;
			IndexTriangle[] triangles = mesh.Triangles;
			foreach (IndexTriangle indexTriangle in triangles)
			{
				Point3D point3D = mesh.Vertices[indexTriangle.V1];
				array3[num] = (float)point3D.X;
				array3[num + 1] = (float)point3D.Y;
				array3[num + 2] = (float)point3D.Z;
				Point3D point3D2 = mesh.Vertices[indexTriangle.V2];
				array3[num + 3] = (float)point3D2.X;
				array3[num + 4] = (float)point3D2.Y;
				array3[num + 5] = (float)point3D2.Z;
				Point3D point3D3 = mesh.Vertices[indexTriangle.V3];
				array3[num + 6] = (float)point3D3.X;
				array3[num + 7] = (float)point3D3.Y;
				array3[num + 8] = (float)point3D3.Z;
				if (flag)
				{
					PointRGB pointRGB = (PointRGB)point3D;
					array[num] = pointRGB.R;
					array[num + 1] = pointRGB.G;
					array[num + 2] = pointRGB.B;
					PointRGB pointRGB2 = (PointRGB)point3D2;
					array[num + 3] = pointRGB2.R;
					array[num + 4] = pointRGB2.G;
					array[num + 5] = pointRGB2.B;
					PointRGB pointRGB3 = (PointRGB)point3D3;
					array[num + 6] = pointRGB3.R;
					array[num + 7] = pointRGB3.G;
					array[num + 8] = pointRGB3.B;
				}
				else if (flag2 && point3D is PointNormalUv)
				{
					PointNormalUv pointNormalUv = (PointNormalUv)point3D;
					array2[num2++] = (float)pointNormalUv.U;
					array2[num2++] = (float)pointNormalUv.V;
					PointNormalUv pointNormalUv2 = (PointNormalUv)point3D2;
					array2[num2++] = (float)pointNormalUv2.U;
					array2[num2++] = (float)pointNormalUv2.V;
				}
				else if (flag2 && indexTriangle is RichTriangle richTriangle)
				{
					PointF pointF = mesh.TextureCoords[richTriangle.T1];
					array2[num2++] = pointF.X;
					array2[num2++] = pointF.Y;
					PointF pointF2 = mesh.TextureCoords[richTriangle.T2];
					array2[num2++] = pointF2.X;
					array2[num2++] = pointF2.Y;
					PointF pointF3 = mesh.TextureCoords[richTriangle.T3];
					array2[num2++] = pointF3.X;
					array2[num2++] = pointF3.Y;
				}
				else if (flag2 && indexTriangle is RichSmoothTriangle richSmoothTriangle)
				{
					PointF pointF4 = mesh.TextureCoords[richSmoothTriangle.T1];
					array2[num2++] = pointF4.X;
					array2[num2++] = pointF4.Y;
					PointF pointF5 = mesh.TextureCoords[richSmoothTriangle.T2];
					array2[num2++] = pointF5.X;
					array2[num2++] = pointF5.Y;
					PointF pointF6 = mesh.TextureCoords[richSmoothTriangle.T3];
					array2[num2++] = pointF6.X;
					array2[num2++] = pointF6.Y;
				}
				num += 9;
			}
			num = 0;
			float[] array4 = new float[mesh.Triangles.Length * 9];
			switch (mesh.MeshNature)
			{
			case natureType.Smooth:
			case natureType.ColorSmooth:
			case natureType.MulticolorSmooth:
			case natureType.RichSmooth:
			{
				triangles = mesh.Triangles;
				for (int i = 0; i < triangles.Length; i++)
				{
					SmoothTriangle smoothTriangle = (SmoothTriangle)triangles[i];
					Vector3D vector3D2 = mesh.Normals[smoothTriangle.N1];
					array4[num] = (float)vector3D2.X;
					array4[num + 1] = (float)vector3D2.Y;
					array4[num + 2] = (float)vector3D2.Z;
					Vector3D vector3D3 = mesh.Normals[smoothTriangle.N2];
					array4[num + 3] = (float)vector3D3.X;
					array4[num + 4] = (float)vector3D3.Y;
					array4[num + 5] = (float)vector3D3.Z;
					Vector3D vector3D4 = mesh.Normals[smoothTriangle.N3];
					array4[num + 6] = (float)vector3D4.X;
					array4[num + 7] = (float)vector3D4.Y;
					array4[num + 8] = (float)vector3D4.Z;
					num += 9;
				}
				break;
			}
			case natureType.Plain:
			case natureType.ColorPlain:
			case natureType.MulticolorPlain:
			case natureType.RichPlain:
			{
				if (mesh.Triangles.Length != mesh.Normals.Length)
				{
					throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973285));
				}
				for (int j = 0; j < mesh.Normals.Length; j++)
				{
					Vector3D vector3D = mesh.Normals[j];
					array4[num] = (float)vector3D.X;
					array4[num + 1] = (float)vector3D.Y;
					array4[num + 2] = (float)vector3D.Z;
					array4[num + 3] = (float)vector3D.X;
					array4[num + 4] = (float)vector3D.Y;
					array4[num + 5] = (float)vector3D.Z;
					array4[num + 6] = (float)vector3D.X;
					array4[num + 7] = (float)vector3D.Y;
					array4[num + 8] = (float)vector3D.Z;
					num += 9;
				}
				break;
			}
			}
			fastMesh = ((array2 == null) ? new FastMesh(array3, null, array4, array) : new FastMesh(array3, null, array4, array2));
		}
		else
		{
			float[] array5 = null;
			if (flag)
			{
				array = new byte[mesh.Vertices.Length * 3];
			}
			else if (flag2 || (mesh.TextureCoords != null && mesh.TextureCoords.Length == mesh.Vertices.Length))
			{
				array2 = new float[mesh.Vertices.Length * 2];
				array5 = new float[mesh.Vertices.Length * 3];
			}
			int num3 = 0;
			int num4 = 0;
			float[] array6 = new float[mesh.Vertices.Length * 3];
			Point3D[] vertices = mesh.Vertices;
			foreach (Point3D point3D4 in vertices)
			{
				array6[num3] = (float)point3D4.X;
				array6[num3 + 1] = (float)point3D4.Y;
				array6[num3 + 2] = (float)point3D4.Z;
				if (flag)
				{
					PointRGB pointRGB4 = (PointRGB)point3D4;
					array[num3] = pointRGB4.R;
					array[num3 + 1] = pointRGB4.G;
					array[num3 + 2] = pointRGB4.B;
				}
				else if (flag2)
				{
					PointNormalUv pointNormalUv3 = (PointNormalUv)point3D4;
					array5[num3] = (float)pointNormalUv3.Nx;
					array5[num3 + 1] = (float)pointNormalUv3.Ny;
					array5[num3 + 2] = (float)pointNormalUv3.Nz;
					array2[num4++] = (float)pointNormalUv3.U;
					array2[num4++] = (float)pointNormalUv3.V;
				}
				else if (mesh.TextureCoords != null && mesh.TextureCoords.Length == mesh.Vertices.Length)
				{
					array2[num4++] = mesh.TextureCoords[num3 / 3].X;
					array2[num4++] = mesh.TextureCoords[num3 / 3].Y;
				}
				num3 += 3;
			}
			num3 = 0;
			int[] array7 = new int[mesh.Triangles.Length * 3];
			IndexTriangle[] triangles = mesh.Triangles;
			foreach (IndexTriangle indexTriangle2 in triangles)
			{
				array7[num3] = indexTriangle2.V1;
				array7[num3 + 1] = indexTriangle2.V2;
				array7[num3 + 2] = indexTriangle2.V3;
				num3 += 3;
			}
			if (!flag2)
			{
				Vector3D[] array8 = _0023_003DzdPA2_0024gCtew0gz3Njvg_003D_003D(mesh.Vertices, mesh.Triangles, _0023_003DzJacdlY88rdqoqPbG2g_003D_003D: false);
				num3 = 0;
				array5 = new float[array8.Length * 3];
				Vector3D[] array9 = array8;
				foreach (Vector3D vector3D5 in array9)
				{
					array5[num3] = (float)vector3D5.X;
					array5[num3 + 1] = (float)vector3D5.Y;
					array5[num3 + 2] = (float)vector3D5.Z;
					num3 += 3;
				}
			}
			fastMesh = ((array2 != null) ? new FastMesh(array6, array7, array5, array2, dynamic) : ((array == null) ? new FastMesh(array6, array7, array5, dynamic) : new FastMesh(array6, array7, array5, array, dynamic)));
		}
		fastMesh.CopyAttributes(mesh);
		if (localMin != null && localMax != null)
		{
			fastMesh.localMin = (Point3D)localMin.Clone();
			fastMesh.localMax = (Point3D)localMax.Clone();
			fastMesh.UpdateBoundingBoxSphere();
			fastMesh.RegenMode = regenType.CompileOnly;
		}
		return fastMesh;
	}

	internal override void _0023_003Dz_0024_0024rGbexgW9YV(IList<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003Dza_SABTbwi5q2, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, ref int _0023_003DzyzK8swU_003D)
	{
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[] array = _0023_003DzuAMveDQA6vvk();
		foreach (_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D obj in array)
		{
			obj._0023_003DzqkDCo38_003D(ref _0023_003DzyzK8swU_003D, LayerName);
			obj._0023_003DzsxCTpik_003D(ref _0023_003DzyzK8swU_003D);
			obj._0023_003Dzu9FtIMXgxSrQ(_0023_003Dza_SABTbwi5q2);
		}
	}

	internal override _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[] _0023_003DzuAMveDQA6vvk()
	{
		int num = Triangles.Length;
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[] array = new _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[num];
		for (int i = 0; i < num; i++)
		{
			IndexTriangle indexTriangle = Triangles[i];
			Triangle triangle = new Triangle(Vertices[indexTriangle.V1], Vertices[indexTriangle.V2], Vertices[indexTriangle.V3]);
			triangle.CopyAttributes(this);
			array[i] = triangle._0023_003DzuAMveDQA6vvk()[0];
		}
		return array;
	}

	public virtual Mesh[] GetTessellation()
	{
		return new Mesh[1] { this };
	}

	internal override SilhoWireData _0023_003DzEt1XHB_xc_BLLBoMbJmskWU_003D(PreProcessSilhouettesParams _0023_003DzELu0Pss_003D)
	{
		if (!LightWeight)
		{
			return HiddenLinesView._0023_003DzeWZNZhCW691ciXKd0w_003D_003D(this, _0023_003DzELu0Pss_003D.Parents, Vertices, Triangles, Edges, IsClosed, 0.0);
		}
		return null;
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, null, materials));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973226) + _meshNature);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302962751) + IsClosed);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973213) + _edgeStyle);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973426) + NormalAveragingMode);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973423) + _triangles.Length);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973387) + ((_edges != null) ? _edges.Length : 0));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973347) + _smoothingAngle);
		if (_texCoords != null)
		{
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973339) + _texCoords.Length);
		}
		Point3D centroid;
		Point3D centroid2;
		double convertedDensity;
		return _0023_003DzJ7t6sHqYVrbZ(stringBuilder, GetArea(out centroid), centroid, GetVolume(out centroid2), centroid2, GetMass(GetMaterial(materials, layers), linearUnits, massUnits, out convertedDensity), convertedDensity, linearUnits, massUnits, materials, layers).ToString();
	}

	public double GetMass(Material material, linearUnitsType linearUnits, massUnitsType massUnits, out double convertedDensity)
	{
		Point3D centroid;
		return Utility._0023_003DzaWhFDDP5nQ_0024L(material, MaterialName, massUnits, linearUnits, GetVolume(out centroid), out convertedDensity);
	}

	internal override _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[] _0023_003DzAKDLnmImamFN(Color _0023_003Dz1MMYB1g_003D, Dictionary<string, List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>> _0023_003DzISRR3MaRx1qQ, linearUnitsType _0023_003DzsAi4oSk_003D)
	{
		int num = Triangles.Length;
		_0023_003DzAI9YqCWKp0mYYODw1A_003D_003D _0023_003DzAI9YqCWKp0mYYODw1A_003D_003D2 = new _0023_003DzAI9YqCWKp0mYYODw1A_003D_003D();
		for (int i = 0; i < num; i++)
		{
			IndexTriangle indexTriangle = Triangles[i];
			Point3D point3D = Vertices[indexTriangle.V1];
			Point3D point3D2 = Vertices[indexTriangle.V2];
			Point3D point3D3 = Vertices[indexTriangle.V3];
			Vector3D vector3D = new Vector3D(point3D, point3D2, point3D3);
			if (!vector3D.IsZero)
			{
				vector3D.Negate();
				Plane plane = new Plane(point3D, vector3D);
				List<List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu>> list = new List<List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu>>();
				list.Add(new List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu>
				{
					new _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu(point3D.ToArray()),
					new _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu(point3D2.ToArray()),
					new _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu(point3D3.ToArray())
				});
				_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2 = new _0023_003DzbykJA36oCfUxYTgeaw_003D_003D();
				_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DznMfYYu4y2pvS(plane.Origin.ToArray(), plane.AxisZ.ToArray());
				_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DzzFhuPAt59wzG(list);
				_0023_003DzAI9YqCWKp0mYYODw1A_003D_003D2._0023_003DzJ9shYljglKVu.Add(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2);
			}
		}
		_0023_003DzYe_6EnQecc8d(_0023_003DzAI9YqCWKp0mYYODw1A_003D_003D2, _0023_003Dz1MMYB1g_003D, _0023_003DzISRR3MaRx1qQ);
		return new _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[1] { _0023_003DzAI9YqCWKp0mYYODw1A_003D_003D2 };
	}

	protected internal override bool SelectedInternal()
	{
		return SelectionMode != selectionFilterType.Entity;
	}

	internal override void ClearSelectionFaces(selectionStatusType _0023_003DzCYtX6jC7ppkE)
	{
		SelectionInfoSubItems._0023_003DzpeLpar2z_0024ejG(_0023_003DzCYtX6jC7ppkE, this, FacesSelectionInfo);
		if (_0023_003DzCYtX6jC7ppkE == selectionStatusType.Permanent)
		{
			SelectionMode = selectionFilterType.Entity;
		}
	}

	[Obsolete("Use SetFaceSelection()")]
	public void SelectFace(int faceIndex, bool selectionState, Stack<BlockReference> parents = null)
	{
		SelectionInfoSubItems._0023_003DzTaF8sCpHm_00245q(selectionFilterType.Face, faceIndex, selectionState, this, Faces, FacesSelectionInfo, parents);
	}

	internal override List<SelectedSubItem> ClearSelectionFaces(Stack<BlockReference> _0023_003Dzq5nwX2I_003D, selectionStatusType _0023_003DzCYtX6jC7ppkE)
	{
		return _0023_003DzGU9q9iKyIDN73whuiw_003D_003D(_0023_003Dzq5nwX2I_003D, this, FacesSelectionInfo, _0023_003DzCYtX6jC7ppkE, (Faces != null) ? Faces.Count : 0);
	}

	internal static List<SelectedSubItem> _0023_003DzGU9q9iKyIDN73whuiw_003D_003D(Stack<BlockReference> _0023_003Dzq5nwX2I_003D, ISelectableItem _0023_003DzG1TqnNw_003D, List<SelectionInfoSubItems> _0023_003Dz9yGP2QxGG70i, selectionStatusType _0023_003DzCYtX6jC7ppkE, int _0023_003Dz7i3FGtJB1xLt)
	{
		List<SelectedSubItem> list = new List<SelectedSubItem>();
		SelectionInfoSubItems selectionInfoSubItems = SelectionInfoItemBase.FindInstanceOrCreate(_0023_003Dzq5nwX2I_003D, _0023_003DzG1TqnNw_003D, null, _0023_003Dz9yGP2QxGG70i, _0023_003Dz7i3FGtJB1xLt);
		if (selectionInfoSubItems == null || selectionInfoSubItems.SubItems == null || selectionInfoSubItems.SubItems.Length == 0)
		{
			return list;
		}
		for (int i = 0; i < selectionInfoSubItems.SubItems.Length; i++)
		{
			if (selectionInfoSubItems.SubItems[i].IsFlagSet(_0023_003DzCYtX6jC7ppkE))
			{
				list.Add(new SelectedFace(_0023_003Dzq5nwX2I_003D, _0023_003DzG1TqnNw_003D, i));
			}
			selectionInfoSubItems.SubItems[i].UnsetFlag(_0023_003DzCYtX6jC7ppkE);
		}
		return list;
	}

	internal static int _0023_003DqOYw_GJIOxYicIbk7_if3kyDHejVsVt3lTACnUPpaYsHPRpQJvQYOIdKRXAb5iX8dqg9BdzZo1UMOCmgzoLB8XQ_003D_003D(int _0023_003Dzq1tAF_jzmz0C, int _0023_003DzBZMFA5u73tia, out bool _0023_003Dzx3pYiE0_003D, ref _0023_003DzHGlGj7oYIL6hV3aiCu4SRzE_003D _0023_003DzvXH4wxQ_003D)
	{
		_0023_003Dzx3pYiE0_003D = true;
		if (!_0023_003DzvXH4wxQ_003D._0023_003DzAAkdMI4Ul71Y.TryGetValue((_0023_003Dzq1tAF_jzmz0C, _0023_003DzBZMFA5u73tia), out var value))
		{
			value = _0023_003DzvXH4wxQ_003D._0023_003DzAAkdMI4Ul71Y[(_0023_003DzBZMFA5u73tia, _0023_003Dzq1tAF_jzmz0C)];
			_0023_003Dzx3pYiE0_003D = false;
		}
		return value;
	}
}
