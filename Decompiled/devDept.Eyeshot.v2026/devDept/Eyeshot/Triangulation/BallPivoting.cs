using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Triangulation;

public class BallPivoting : WorkUnit
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<_0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D, bool> _0023_003DzR9_gZJxS2TkzDO_00243tA_003D_003D;

		internal bool _0023_003Dz8IgnQYuiq7SKUgwfTQqFe3alhCt7wo9P_VgGmfHT3j_002473XWu_0024A_003D_003D(_0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D _0023_003DzBJFJHwk_003D)
		{
			return !_0023_003DzBJFJHwk_003D._0023_003DzwKt32wM_003D;
		}
	}

	private enum _0023_003Dz5A3bbQQ_003D
	{

	}

	private sealed class _0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D : IndexTriangle
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzNPS2Q4c_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Vector3D _0023_003Dz9T2qChw_003D;

		public _0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D(int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D, int _0023_003DzZe6oCrQ_003D)
			: base(_0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, _0023_003DzZe6oCrQ_003D)
		{
			_0023_003DzNPS2Q4c_003D = 0;
			_0023_003Dz9T2qChw_003D = null;
		}

		public _0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D(int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D, int _0023_003DzZe6oCrQ_003D, int _0023_003DzhyZURwQ_003D, Vector3D _0023_003Dzn8G7AOUeiIgL)
			: base(_0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, _0023_003DzZe6oCrQ_003D)
		{
			_0023_003DzNPS2Q4c_003D = _0023_003DzhyZURwQ_003D;
			_0023_003Dz9T2qChw_003D = _0023_003Dzn8G7AOUeiIgL;
		}

		protected _0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D(_0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D _0023_003DzySgeilxprQOK)
			: base(_0023_003DzySgeilxprQOK)
		{
			_0023_003DzNPS2Q4c_003D = _0023_003DzySgeilxprQOK._0023_003DzNPS2Q4c_003D;
			_0023_003Dz9T2qChw_003D = (Vector3D)_0023_003DzySgeilxprQOK._0023_003Dz9T2qChw_003D.Clone();
		}

		public override object Clone()
		{
			return new _0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D(this);
		}

		internal void _0023_003Dz0wcqTpk_003D()
		{
			int v = V2;
			V2 = V3;
			V3 = v;
			if (_0023_003Dz9T2qChw_003D != null)
			{
				_0023_003Dz9T2qChw_003D.Negate();
			}
		}
	}

	private sealed class _0023_003DzJg1dS43G0JHg : IndexLine, IEquatable<_0023_003DzJg1dS43G0JHg>
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003Dz2CwKCVa_kVAH = -1;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzGTfQPRCBlDaHPcBcVA_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Point3D _0023_003Dzyb0dBFAYdBen;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003Dz5A3bbQQ_003D _0023_003Dz9pre6_0024c_003D;

		public _0023_003DzJg1dS43G0JHg(int _0023_003DzroqKq5Y_003D, int _0023_003Dzb6jyG_Y_003D, int _0023_003Dz9lul62LmuNJW1H805w_003D_003D, Point3D _0023_003DzTQKWZlKLX_yc, int _0023_003DzaVdhZnN1qyr9)
		{
			V1 = _0023_003DzroqKq5Y_003D;
			V2 = _0023_003Dzb6jyG_Y_003D;
			_0023_003DzGTfQPRCBlDaHPcBcVA_003D_003D = _0023_003Dz9lul62LmuNJW1H805w_003D_003D;
			_0023_003Dzyb0dBFAYdBen = _0023_003DzTQKWZlKLX_yc;
			_0023_003Dz2CwKCVa_kVAH = _0023_003DzaVdhZnN1qyr9;
			_0023_003Dz9pre6_0024c_003D = (_0023_003Dz5A3bbQQ_003D)0;
		}

		public int _0023_003DzNc67xInN3I5x()
		{
			return V1;
		}

		public void _0023_003DzyN4TSLkeF5Tz(int _0023_003DzPzO_0024GUk_003D)
		{
			V1 = _0023_003DzPzO_0024GUk_003D;
		}

		public int _0023_003Dznqtw2c4nckQi()
		{
			return V2;
		}

		public void _0023_003DzZsbNAaIzgb0A(int _0023_003DzPzO_0024GUk_003D)
		{
			V2 = _0023_003DzPzO_0024GUk_003D;
		}

		public void _0023_003Dz0wcqTpk_003D()
		{
			int v = V1;
			V1 = V2;
			V2 = v;
		}

		public bool Equals(_0023_003DzJg1dS43G0JHg _0023_003Dzl_0024MIsC0_003D)
		{
			if (_0023_003Dzl_0024MIsC0_003D.V1 == V1)
			{
				return _0023_003Dzl_0024MIsC0_003D.V2 == V2;
			}
			return false;
		}
	}

	private sealed class _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D : Point3D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly int _0023_003Dz_NdRtMQ_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003Dzt__TDBUJ98AJ;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public byte _0023_003DzAYqOj_Y_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public byte _0023_003DzFmiij5k_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public byte _0023_003DzH9VU2k0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzwKt32wM_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public List<_0023_003DzJg1dS43G0JHg> _0023_003DzO5dKkT0hsWIy;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public List<int> _0023_003DzoR2_vtHc8SYueITipw_003D_003D;

		public _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003DzId5C3LA_003D, int _0023_003DzzAmXSOmX12Vj)
			: base(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, _0023_003DzId5C3LA_003D)
		{
			_0023_003Dz_NdRtMQ_003D = _0023_003DzzAmXSOmX12Vj;
			_0023_003Dzt__TDBUJ98AJ = 0;
			_0023_003DzO5dKkT0hsWIy = new List<_0023_003DzJg1dS43G0JHg>();
			_0023_003DzoR2_vtHc8SYueITipw_003D_003D = new List<int>();
		}

		public _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003DzId5C3LA_003D, byte _0023_003DzRpXgovo_003D, byte _0023_003Dz5rQzobg_003D, byte _0023_003Dz1v6oPQk_003D, int _0023_003DzzAmXSOmX12Vj)
			: base(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, _0023_003DzId5C3LA_003D)
		{
			_0023_003Dz_NdRtMQ_003D = _0023_003DzzAmXSOmX12Vj;
			_0023_003Dzt__TDBUJ98AJ = 0;
			_0023_003DzO5dKkT0hsWIy = new List<_0023_003DzJg1dS43G0JHg>();
			_0023_003DzoR2_vtHc8SYueITipw_003D_003D = new List<int>();
			_0023_003DzAYqOj_Y_003D = _0023_003DzRpXgovo_003D;
			_0023_003DzFmiij5k_003D = _0023_003Dz5rQzobg_003D;
			_0023_003DzH9VU2k0_003D = _0023_003Dz1v6oPQk_003D;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly StringBuilder _0023_003DzVy4cXgY_003D = new StringBuilder();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dzp_00242ikS9_0024_lpS9O9f3qoajOg_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015562);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzhyZURwQ_003D = -1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Mesh.natureType _0023_003DzSCp_i6HgfNf6K9v6CQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<_0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D = new List<_0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<int>[,,] _0023_003DzgYhCuHM3lqSw;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dzrf5YV8a6cCAg;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzQGz7TQAY_JX_0024;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point3D _0023_003DzZh8SRdGSxXy2;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double[] _0023_003DzCvoS5JZNY_HE;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double[] _0023_003DzvBVd92nl7ZRtXOodBA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzHvAfpUm5f0OK;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzeObW70tsLUirP_00244LqA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzNDNPd73F3DLFeLWrmA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzYj_vsfVr7IXPrp3r6w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Mesh _0023_003DzOLHnb2M_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzDr1MUxo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Size3D _0023_003Dz14lzA48_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzEGKj_0024SNUUihi;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dzg_h72rRM798oluKqlg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzltwEPbggNwEV = Math.Cos(Math.PI * 2.0 / 3.0);

	public new string Log => _0023_003DzVy4cXgY_003D.ToString();

	public string TriangulatingText
	{
		get
		{
			return _0023_003Dzp_00242ikS9_0024_lpS9O9f3qoajOg_003D;
		}
		set
		{
			_0023_003Dzp_00242ikS9_0024_lpS9O9f3qoajOg_003D = value;
		}
	}

	public Mesh.natureType OutputType
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzSCp_i6HgfNf6K9v6CQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzSCp_i6HgfNf6K9v6CQ_003D_003D = value;
		}
	}

	public Mesh Result => _0023_003DzOLHnb2M_003D;

	public double MinAngle
	{
		get
		{
			return Math.Acos(_0023_003DzltwEPbggNwEV);
		}
		set
		{
			_0023_003DzltwEPbggNwEV = Math.Cos(value);
		}
	}

	public BallPivoting(FastPointCloud fpc, double[] radii)
		: this(fpc.PointArray, fpc.ColorArray, radii)
	{
	}

	public BallPivoting(FastPointCloud fpc, double radius)
		: this(fpc.PointArray, fpc.ColorArray, radius)
	{
	}

	public BallPivoting(FastPointCloud fpc)
		: this(fpc.PointArray, fpc.ColorArray, null)
	{
	}

	public BallPivoting(PointCloud pc, double[] radii)
	{
		FastPointCloud fastPointCloud = pc.ConvertToFastPointCloud();
		_0023_003DztGdcVOA_003D(fastPointCloud.PointArray, fastPointCloud.ColorArray, radii);
	}

	public BallPivoting(PointCloud pc, double radius)
	{
		FastPointCloud fastPointCloud = pc.ConvertToFastPointCloud();
		_0023_003DztGdcVOA_003D(fastPointCloud.PointArray, fastPointCloud.ColorArray, new double[1] { radius });
	}

	public BallPivoting(PointCloud pc)
	{
		FastPointCloud fastPointCloud = pc.ConvertToFastPointCloud();
		_0023_003DztGdcVOA_003D(fastPointCloud.PointArray, fastPointCloud.ColorArray, null);
	}

	public BallPivoting(float[] pointArray, byte[] rgbArray, double radius)
	{
		_0023_003DztGdcVOA_003D(pointArray, rgbArray, new double[1] { radius });
	}

	public BallPivoting(float[] pointArray, byte[] rgbArray, double[] radii)
	{
		_0023_003DztGdcVOA_003D(pointArray, rgbArray, radii);
	}

	public BallPivoting(float[] pointArray, byte[] rgbArray)
		: this(pointArray, rgbArray, 0.0)
	{
	}

	private void _0023_003Dz5TzMnG42cLnS(double[] _0023_003DzpnhK84zLbX_F)
	{
		if (_0023_003DzpnhK84zLbX_F == null || _0023_003DzpnhK84zLbX_F.Length == 0)
		{
			double num = Math.Sqrt(_0023_003Dz14lzA48_003D.Diagonal * _0023_003Dz14lzA48_003D.Diagonal / (double)_0023_003Dzrf5YV8a6cCAg);
			_0023_003DzCvoS5JZNY_HE = new double[1] { num };
		}
		else
		{
			_0023_003DzCvoS5JZNY_HE = new double[_0023_003DzpnhK84zLbX_F.Length];
			for (int i = 0; i < _0023_003DzpnhK84zLbX_F.Length; i++)
			{
				_0023_003DzCvoS5JZNY_HE[i] = _0023_003DzpnhK84zLbX_F[i];
				if (_0023_003DzCvoS5JZNY_HE[i] <= 0.0)
				{
					throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303016319));
				}
			}
		}
		_0023_003DzvBVd92nl7ZRtXOodBA_003D_003D = new double[_0023_003DzCvoS5JZNY_HE.Length];
		for (int j = 0; j < _0023_003DzCvoS5JZNY_HE.Length; j++)
		{
			_0023_003DzvBVd92nl7ZRtXOodBA_003D_003D[j] = _0023_003DzCvoS5JZNY_HE[j] * _0023_003DzCvoS5JZNY_HE[j];
		}
	}

	protected Mesh MakeMesh()
	{
		Mesh mesh = new Mesh(OutputType);
		Point3D point3D = Utility.CreateVertex(OutputType, 0.0, 0.0, 0.0);
		if (point3D is PointRGB && !(point3D is PointRGB))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303016271));
		}
		_0023_003DzI9CoeA4_003D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, out var _0023_003DzD4IyP8IGLZk8FQjtcQ_003D_003D);
		mesh.Vertices = new Point3D[_0023_003DzD4IyP8IGLZk8FQjtcQ_003D_003D.Length];
		Mesh.natureType outputType = OutputType;
		if (outputType == Mesh.natureType.MulticolorPlain || outputType == Mesh.natureType.MulticolorSmooth)
		{
			for (int i = 0; i < _0023_003DzD4IyP8IGLZk8FQjtcQ_003D_003D.Length; i++)
			{
				mesh.Vertices[i] = _0023_003DzD4IyP8IGLZk8FQjtcQ_003D_003D[i];
			}
		}
		else
		{
			for (int j = 0; j < _0023_003DzD4IyP8IGLZk8FQjtcQ_003D_003D.Length; j++)
			{
				PointRGB pointRGB = _0023_003DzD4IyP8IGLZk8FQjtcQ_003D_003D[j];
				mesh.Vertices[j] = new Point3D(pointRGB.X, pointRGB.Y, pointRGB.Z);
			}
		}
		mesh.Triangles = new IndexTriangle[_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Count];
		mesh.Normals = new Vector3D[_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Count];
		for (int k = 0; k < _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Count; k++)
		{
			_0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D _0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D2 = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[k];
			mesh.Triangles[k] = Utility.CreateTriangle(OutputType, _0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D2.V1, _0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D2.V2, _0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D2.V3);
			mesh.Normals[k] = _0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D2._0023_003Dz9T2qChw_003D;
		}
		mesh.EdgeStyle = Mesh.edgeStyleType.Free;
		if (mesh.MeshNature == Mesh.natureType.Plain || mesh.MeshNature == Mesh.natureType.MulticolorPlain || mesh.MeshNature == Mesh.natureType.ColorPlain || mesh.MeshNature == Mesh.natureType.RichPlain)
		{
			mesh.ComputeEdges();
			mesh.UpdateBoundingBox(null);
			mesh.RegenMode = regenType.CompileOnly;
		}
		return mesh;
	}

	private static void _0023_003DzI9CoeA4_003D(_0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D[] _0023_003DzUdJvKusPpdHoJ6nGug_003D_003D, IList<_0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, out PointRGB[] _0023_003DzD4IyP8IGLZk8FQjtcQ_003D_003D)
	{
		int[] array = new int[_0023_003DzUdJvKusPpdHoJ6nGug_003D_003D.Length];
		int num = 0;
		for (int i = 0; i < _0023_003DzUdJvKusPpdHoJ6nGug_003D_003D.Length; i++)
		{
			if (_0023_003DzUdJvKusPpdHoJ6nGug_003D_003D[i]._0023_003DzwKt32wM_003D)
			{
				array[i] = num;
				num++;
			}
			else
			{
				array[i] = -1;
			}
		}
		_0023_003DzD4IyP8IGLZk8FQjtcQ_003D_003D = new PointRGB[num];
		for (int j = 0; j < _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Count; j++)
		{
			_0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D _0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D2 = (_0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D)_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[j].Clone();
			_0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D2.V1 = array[_0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D2.V1];
			_0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D2.V2 = array[_0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D2.V2];
			_0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D2.V3 = array[_0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D2.V3];
			_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[j] = _0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D2;
		}
		num = 0;
		for (int k = 0; k < _0023_003DzUdJvKusPpdHoJ6nGug_003D_003D.Length; k++)
		{
			if (_0023_003DzUdJvKusPpdHoJ6nGug_003D_003D[k]._0023_003DzwKt32wM_003D)
			{
				_0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2 = _0023_003DzUdJvKusPpdHoJ6nGug_003D_003D[k];
				_0023_003DzD4IyP8IGLZk8FQjtcQ_003D_003D[num] = new PointRGB(_0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2.X, _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2.Y, _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2.Z, _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2._0023_003DzAYqOj_Y_003D, _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2._0023_003DzFmiij5k_003D, _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2._0023_003DzH9VU2k0_003D);
				num++;
			}
		}
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"ac>", array);
		_0023_003DzOLHnb2M_003D = _0023_003DzzVtYb0rkEtX8sfYw8aH3n0JwpkPbtkaIVmq1wus_003D(progress, ct);
	}

	private Mesh _0023_003DzzVtYb0rkEtX8sfYw8aH3n0JwpkPbtkaIVmq1wus_003D(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		for (int i = 0; i < _0023_003DzCvoS5JZNY_HE.Length; i++)
		{
			_0023_003DzEGKj_0024SNUUihi = _0023_003DzCvoS5JZNY_HE[i];
			_0023_003Dzg_h72rRM798oluKqlg_003D_003D = _0023_003DzvBVd92nl7ZRtXOodBA_003D_003D[i];
			_0023_003DzTwaamv1IrHM2brkj_0024A_003D_003D();
			_0023_003DzyeKdLfc_003D();
			_0023_003DzKrXpvLKAuePIDPEgpaJr0Lk_003D(_0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
		}
		_0023_003DzVy4cXgY_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303016222) + _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count((_0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D _0023_003DzBJFJHwk_003D) => !_0023_003DzBJFJHwk_003D._0023_003DzwKt32wM_003D));
		return MakeMesh();
	}

	private void _0023_003DztGdcVOA_003D(float[] _0023_003DzrH1N0x4_003D, byte[] _0023_003Dz10j_0024rZU_003D, double[] _0023_003DzpnhK84zLbX_F)
	{
		if (_0023_003Dz10j_0024rZU_003D != null && _0023_003Dz10j_0024rZU_003D.Length == _0023_003DzrH1N0x4_003D.Length)
		{
			OutputType = Mesh.natureType.MulticolorPlain;
		}
		else
		{
			OutputType = Mesh.natureType.Plain;
		}
		if (_0023_003DzrH1N0x4_003D == null)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303016436));
		}
		Utility.ComputeBoundingBox(new Identity(), _0023_003DzrH1N0x4_003D, _0023_003DzrH1N0x4_003D.Length, 0, out _0023_003DzZh8SRdGSxXy2, out var boxMax);
		_0023_003Dz14lzA48_003D = new Size3D(_0023_003DzZh8SRdGSxXy2, boxMax);
		_0023_003Dzrf5YV8a6cCAg = _0023_003DzrH1N0x4_003D.Length / 3;
		_0023_003DzQGz7TQAY_JX_0024 = 0;
		_0023_003Dz5TzMnG42cLnS(_0023_003DzpnhK84zLbX_F);
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D[_0023_003Dzrf5YV8a6cCAg];
		int num = 0;
		for (int i = 0; i < _0023_003Dzrf5YV8a6cCAg; i++)
		{
			_0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2 = ((_0023_003Dz10j_0024rZU_003D == null || _0023_003Dz10j_0024rZU_003D.Length != _0023_003DzrH1N0x4_003D.Length || Utility._0023_003DziO8_0024N5HjLOoQRQgn7nLiej4gvs_amz7Myw_003D_003D(_0023_003DzrH1N0x4_003D, _0023_003Dz10j_0024rZU_003D)) ? new _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D(_0023_003DzrH1N0x4_003D[num], _0023_003DzrH1N0x4_003D[num + 1], _0023_003DzrH1N0x4_003D[num + 2], i) : new _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D(_0023_003DzrH1N0x4_003D[num], _0023_003DzrH1N0x4_003D[num + 1], _0023_003DzrH1N0x4_003D[num + 2], _0023_003Dz10j_0024rZU_003D[num], _0023_003Dz10j_0024rZU_003D[num + 1], _0023_003Dz10j_0024rZU_003D[num + 2], i));
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i] = _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2;
			num += 3;
		}
	}

	private void _0023_003DzTwaamv1IrHM2brkj_0024A_003D_003D()
	{
		_0023_003DzHvAfpUm5f0OK = _0023_003DzEGKj_0024SNUUihi * 2.0;
		_0023_003DzeObW70tsLUirP_00244LqA_003D_003D = (int)(_0023_003Dz14lzA48_003D.X / _0023_003DzHvAfpUm5f0OK) + 1;
		_0023_003DzNDNPd73F3DLFeLWrmA_003D_003D = (int)(_0023_003Dz14lzA48_003D.Y / _0023_003DzHvAfpUm5f0OK) + 1;
		_0023_003DzYj_vsfVr7IXPrp3r6w_003D_003D = (int)(_0023_003Dz14lzA48_003D.Z / _0023_003DzHvAfpUm5f0OK) + 1;
		_0023_003DzgYhCuHM3lqSw = new List<int>[_0023_003DzeObW70tsLUirP_00244LqA_003D_003D, _0023_003DzNDNPd73F3DLFeLWrmA_003D_003D, _0023_003DzYj_vsfVr7IXPrp3r6w_003D_003D];
		for (int i = 0; i < _0023_003DzeObW70tsLUirP_00244LqA_003D_003D; i++)
		{
			for (int j = 0; j < _0023_003DzNDNPd73F3DLFeLWrmA_003D_003D; j++)
			{
				for (int k = 0; k < _0023_003DzYj_vsfVr7IXPrp3r6w_003D_003D; k++)
				{
					_0023_003DzgYhCuHM3lqSw[i, j, k] = new List<int>();
				}
			}
		}
		int num = 0;
		for (int l = 0; l < _0023_003Dzrf5YV8a6cCAg; l++)
		{
			_0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[l];
			if (!_0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2._0023_003DzwKt32wM_003D || _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2._0023_003Dzt__TDBUJ98AJ > 0)
			{
				num++;
				_0023_003DzgYhCuHM3lqSw[(int)((_0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2.X - _0023_003DzZh8SRdGSxXy2.X) / _0023_003DzHvAfpUm5f0OK), (int)((_0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2.Y - _0023_003DzZh8SRdGSxXy2.Y) / _0023_003DzHvAfpUm5f0OK), (int)((_0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2.Z - _0023_003DzZh8SRdGSxXy2.Z) / _0023_003DzHvAfpUm5f0OK)].Add(_0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2._0023_003Dz_NdRtMQ_003D);
			}
		}
		_0023_003DzVy4cXgY_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303016429) + _0023_003DzEGKj_0024SNUUihi + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303016411) + num);
		_0023_003DzDr1MUxo_003D = 0;
	}

	private void _0023_003DzyeKdLfc_003D()
	{
		_0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D[] array = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D;
		foreach (_0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2 in array)
		{
			if (!_0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2._0023_003DzwKt32wM_003D || _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2._0023_003Dzt__TDBUJ98AJ <= 0)
			{
				continue;
			}
			foreach (_0023_003DzJg1dS43G0JHg item in _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2._0023_003DzO5dKkT0hsWIy)
			{
				item._0023_003Dz9pre6_0024c_003D = (_0023_003Dz5A3bbQQ_003D)0;
			}
		}
	}

	private void _0023_003DzKrXpvLKAuePIDPEgpaJr0Lk_003D(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		if (!UpdateProgressAndCheckCancelled(_0023_003DzQGz7TQAY_JX_0024, _0023_003Dzrf5YV8a6cCAg, _0023_003Dzp_00242ikS9_0024_lpS9O9f3qoajOg_003D + _0023_003DzEGKj_0024SNUUihi.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994676)), _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
		{
			return;
		}
		do
		{
			_0023_003DzJg1dS43G0JHg _0023_003DzJg1dS43G0JHg2 = _0023_003DzvBYfcOcqBa4e();
			int _0023_003DzZpm_0024ltUkzcNd;
			Point3D _0023_003DzbUvT9Pc_003D;
			while (_0023_003DzJg1dS43G0JHg2 != null)
			{
				_0023_003DzEMk2AS98ky5Z(_0023_003DzJg1dS43G0JHg2, out _0023_003DzZpm_0024ltUkzcNd, out _0023_003DzbUvT9Pc_003D, out var _0023_003Dzn8G7AOUeiIgL);
				if (_0023_003DzZpm_0024ltUkzcNd != -1)
				{
					bool flag = false;
					if (_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzZpm_0024ltUkzcNd]._0023_003DzwKt32wM_003D)
					{
						foreach (int item in _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzZpm_0024ltUkzcNd]._0023_003DzoR2_vtHc8SYueITipw_003D_003D)
						{
							_0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D _0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D2 = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[item];
							_0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D _0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D3 = new _0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D(_0023_003DzJg1dS43G0JHg2._0023_003DzNc67xInN3I5x(), _0023_003DzZpm_0024ltUkzcNd, _0023_003DzJg1dS43G0JHg2._0023_003Dznqtw2c4nckQi());
							if (!(Vector3D.Dot(_0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D2._0023_003Dz9T2qChw_003D, _0023_003Dzn8G7AOUeiIgL) < 0.0 - _0023_003DzltwEPbggNwEV))
							{
								continue;
							}
							if (_0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D2._0023_003DzNPS2Q4c_003D != _0023_003DzhyZURwQ_003D)
							{
								_0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D3._0023_003Dz0wcqTpk_003D();
								Vector3D vector3D = new Vector3D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D3.V1], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D3.V2], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D3.V3]);
								vector3D.Normalize();
								if (Vector3D.Dot(_0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D2._0023_003Dz9T2qChw_003D, vector3D) >= 0.0 - _0023_003DzltwEPbggNwEV)
								{
									_0023_003Dz8itQqlUWdbkr9s0dBg_003D_003D(_0023_003DzhyZURwQ_003D, _0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D2._0023_003DzNPS2Q4c_003D);
								}
							}
							_0023_003DzcPyJEcUAaiSA(_0023_003DzJg1dS43G0JHg2);
							_0023_003DzJg1dS43G0JHg2 = _0023_003Dzj7kMO8dOcUv9(_0023_003DzZpm_0024ltUkzcNd);
							flag = true;
							break;
						}
					}
					if (flag)
					{
						continue;
					}
					int num = _0023_003DzYv7Upc0yYEpt(_0023_003DzJg1dS43G0JHg2._0023_003DzNc67xInN3I5x(), _0023_003DzZpm_0024ltUkzcNd, _0023_003DzJg1dS43G0JHg2._0023_003Dznqtw2c4nckQi(), _0023_003Dzn8G7AOUeiIgL);
					_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[num]._0023_003DzNPS2Q4c_003D = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[_0023_003DzJg1dS43G0JHg2._0023_003Dz2CwKCVa_kVAH]._0023_003DzNPS2Q4c_003D;
					_0023_003DzU8n8_0024pIm_rPr(_0023_003DzJg1dS43G0JHg2);
					if (!_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzZpm_0024ltUkzcNd]._0023_003DzwKt32wM_003D)
					{
						_0023_003DzPjuUiWk_003D(_0023_003DzJg1dS43G0JHg2, _0023_003DzZpm_0024ltUkzcNd, _0023_003DzbUvT9Pc_003D, num);
						_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzZpm_0024ltUkzcNd]._0023_003DzwKt32wM_003D = true;
						_0023_003DzQGz7TQAY_JX_0024++;
					}
					else
					{
						_0023_003DzteM505EuogGq(_0023_003DzJg1dS43G0JHg2, _0023_003DzZpm_0024ltUkzcNd, _0023_003DzbUvT9Pc_003D, num);
					}
					if (!UpdateProgressAndCheckCancelled(_0023_003DzQGz7TQAY_JX_0024, _0023_003Dzrf5YV8a6cCAg, _0023_003Dzp_00242ikS9_0024_lpS9O9f3qoajOg_003D + _0023_003DzEGKj_0024SNUUihi.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994676)), _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
					{
						break;
					}
				}
				else
				{
					_0023_003DzcPyJEcUAaiSA(_0023_003DzJg1dS43G0JHg2);
				}
				_0023_003DzJg1dS43G0JHg2 = _0023_003Dzj7kMO8dOcUv9(_0023_003DzJg1dS43G0JHg2._0023_003DzNc67xInN3I5x());
			}
			if (_0023_003DzkVFF5DAMh_0024um(out var _0023_003DzFNv10ndShqpu, out var _0023_003DzFzSqpAxXboaS, out _0023_003DzZpm_0024ltUkzcNd, out _0023_003DzbUvT9Pc_003D))
			{
				_0023_003DzhyZURwQ_003D++;
				Vector3D _0023_003DzZbOaTIM_003D = new Vector3D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzFNv10ndShqpu], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzFzSqpAxXboaS], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzZpm_0024ltUkzcNd]);
				int _0023_003DzaVdhZnN1qyr = _0023_003DzYv7Upc0yYEpt(_0023_003DzFNv10ndShqpu, _0023_003DzFzSqpAxXboaS, _0023_003DzZpm_0024ltUkzcNd, _0023_003DzZbOaTIM_003D);
				_0023_003DzQrAhblV5duL9(_0023_003DzZpm_0024ltUkzcNd, _0023_003DzFNv10ndShqpu, _0023_003DzFzSqpAxXboaS, _0023_003DzbUvT9Pc_003D, _0023_003DzaVdhZnN1qyr, _0023_003Dz1l0EiMs_003D: true);
				_0023_003DzQrAhblV5duL9(_0023_003DzFzSqpAxXboaS, _0023_003DzZpm_0024ltUkzcNd, _0023_003DzFNv10ndShqpu, _0023_003DzbUvT9Pc_003D, _0023_003DzaVdhZnN1qyr, _0023_003Dz1l0EiMs_003D: true);
				_0023_003DzQrAhblV5duL9(_0023_003DzFNv10ndShqpu, _0023_003DzFzSqpAxXboaS, _0023_003DzZpm_0024ltUkzcNd, _0023_003DzbUvT9Pc_003D, _0023_003DzaVdhZnN1qyr, _0023_003Dz1l0EiMs_003D: true);
				continue;
			}
			break;
		}
		while (UpdateProgressAndCheckCancelled(_0023_003DzQGz7TQAY_JX_0024, _0023_003Dzrf5YV8a6cCAg, _0023_003Dzp_00242ikS9_0024_lpS9O9f3qoajOg_003D + _0023_003DzEGKj_0024SNUUihi.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994676)), _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D));
	}

	private void _0023_003DzU8n8_0024pIm_rPr(_0023_003DzJg1dS43G0JHg _0023_003DzTx2aqr8_003D)
	{
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTx2aqr8_003D._0023_003DzNc67xInN3I5x()]._0023_003Dzt__TDBUJ98AJ--;
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTx2aqr8_003D._0023_003Dznqtw2c4nckQi()]._0023_003Dzt__TDBUJ98AJ--;
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTx2aqr8_003D._0023_003DzNc67xInN3I5x()]._0023_003DzO5dKkT0hsWIy.Remove(_0023_003DzTx2aqr8_003D);
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTx2aqr8_003D._0023_003Dznqtw2c4nckQi()]._0023_003DzO5dKkT0hsWIy.Remove(_0023_003DzTx2aqr8_003D);
	}

	private void _0023_003DzO9nIxGAjpuSC(_0023_003DzJg1dS43G0JHg _0023_003DzTx2aqr8_003D)
	{
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTx2aqr8_003D._0023_003DzNc67xInN3I5x()]._0023_003Dzt__TDBUJ98AJ++;
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTx2aqr8_003D._0023_003Dznqtw2c4nckQi()]._0023_003Dzt__TDBUJ98AJ++;
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTx2aqr8_003D._0023_003DzNc67xInN3I5x()]._0023_003DzO5dKkT0hsWIy.Add(_0023_003DzTx2aqr8_003D);
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTx2aqr8_003D._0023_003Dznqtw2c4nckQi()]._0023_003DzO5dKkT0hsWIy.Add(_0023_003DzTx2aqr8_003D);
	}

	private _0023_003DzJg1dS43G0JHg _0023_003DzQrAhblV5duL9(int _0023_003DzFNv10ndShqpu, int _0023_003DzFzSqpAxXboaS, int _0023_003DzZpm_0024ltUkzcNd, Point3D _0023_003DzbUvT9Pc_003D, int _0023_003DzaVdhZnN1qyr9, bool _0023_003Dz1l0EiMs_003D)
	{
		_0023_003DzJg1dS43G0JHg _0023_003DzJg1dS43G0JHg2 = new _0023_003DzJg1dS43G0JHg(_0023_003DzFNv10ndShqpu, _0023_003DzFzSqpAxXboaS, _0023_003DzZpm_0024ltUkzcNd, _0023_003DzbUvT9Pc_003D, _0023_003DzaVdhZnN1qyr9);
		if (_0023_003Dz1l0EiMs_003D)
		{
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzFNv10ndShqpu]._0023_003Dzt__TDBUJ98AJ++;
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzFzSqpAxXboaS]._0023_003Dzt__TDBUJ98AJ++;
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzFNv10ndShqpu]._0023_003DzO5dKkT0hsWIy.Add(_0023_003DzJg1dS43G0JHg2);
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzFzSqpAxXboaS]._0023_003DzO5dKkT0hsWIy.Add(_0023_003DzJg1dS43G0JHg2);
		}
		return _0023_003DzJg1dS43G0JHg2;
	}

	private void _0023_003DzPjuUiWk_003D(_0023_003DzJg1dS43G0JHg _0023_003DzTx2aqr8_003D, int _0023_003DzZpm_0024ltUkzcNd, Point3D _0023_003DzbUvT9Pc_003D, int _0023_003DzaVdhZnN1qyr9)
	{
		_0023_003DzQrAhblV5duL9(_0023_003DzTx2aqr8_003D._0023_003DzNc67xInN3I5x(), _0023_003DzZpm_0024ltUkzcNd, _0023_003DzTx2aqr8_003D._0023_003Dznqtw2c4nckQi(), _0023_003DzbUvT9Pc_003D, _0023_003DzaVdhZnN1qyr9, _0023_003Dz1l0EiMs_003D: true);
		_0023_003DzQrAhblV5duL9(_0023_003DzZpm_0024ltUkzcNd, _0023_003DzTx2aqr8_003D._0023_003Dznqtw2c4nckQi(), _0023_003DzTx2aqr8_003D._0023_003DzNc67xInN3I5x(), _0023_003DzbUvT9Pc_003D, _0023_003DzaVdhZnN1qyr9, _0023_003Dz1l0EiMs_003D: true);
	}

	private void _0023_003DzteM505EuogGq(_0023_003DzJg1dS43G0JHg _0023_003DzTx2aqr8_003D, int _0023_003DzZpm_0024ltUkzcNd, Point3D _0023_003DzbUvT9Pc_003D, int _0023_003DzaVdhZnN1qyr9)
	{
		_0023_003DzJg1dS43G0JHg _0023_003DzbxU6JuvUsaVO = _0023_003DzQrAhblV5duL9(_0023_003DzTx2aqr8_003D._0023_003DzNc67xInN3I5x(), _0023_003DzZpm_0024ltUkzcNd, _0023_003DzTx2aqr8_003D._0023_003Dznqtw2c4nckQi(), _0023_003DzbUvT9Pc_003D, _0023_003DzaVdhZnN1qyr9, _0023_003Dz1l0EiMs_003D: false);
		_0023_003DzNgyxEHYIQbP_0024(_0023_003DzbxU6JuvUsaVO);
		_0023_003DzJg1dS43G0JHg _0023_003DzbxU6JuvUsaVO2 = _0023_003DzQrAhblV5duL9(_0023_003DzZpm_0024ltUkzcNd, _0023_003DzTx2aqr8_003D._0023_003Dznqtw2c4nckQi(), _0023_003DzTx2aqr8_003D._0023_003DzNc67xInN3I5x(), _0023_003DzbUvT9Pc_003D, _0023_003DzaVdhZnN1qyr9, _0023_003Dz1l0EiMs_003D: false);
		_0023_003DzNgyxEHYIQbP_0024(_0023_003DzbxU6JuvUsaVO2);
	}

	private void _0023_003DzNgyxEHYIQbP_0024(_0023_003DzJg1dS43G0JHg _0023_003DzbxU6JuvUsaVO)
	{
		_0023_003DzKQycJe8Juxn1(_0023_003DzbxU6JuvUsaVO._0023_003DzNc67xInN3I5x(), _0023_003DzbxU6JuvUsaVO, out var _0023_003DzIH0nSl3s3_0024xs);
		if (!_0023_003DzIH0nSl3s3_0024xs)
		{
			_0023_003DzKQycJe8Juxn1(_0023_003DzbxU6JuvUsaVO._0023_003Dznqtw2c4nckQi(), _0023_003DzbxU6JuvUsaVO, out _0023_003DzIH0nSl3s3_0024xs);
		}
		if (!_0023_003DzIH0nSl3s3_0024xs)
		{
			_0023_003DzO9nIxGAjpuSC(_0023_003DzbxU6JuvUsaVO);
		}
	}

	private void _0023_003DzKQycJe8Juxn1(int _0023_003DzqDTr2JY_003D, _0023_003DzJg1dS43G0JHg _0023_003DzbxU6JuvUsaVO, out bool _0023_003DzIH0nSl3s3_0024xs)
	{
		_0023_003DzIH0nSl3s3_0024xs = false;
		foreach (_0023_003DzJg1dS43G0JHg item in _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzqDTr2JY_003D]._0023_003DzO5dKkT0hsWIy)
		{
			if (item.V1 == _0023_003DzbxU6JuvUsaVO.V2 && item.V2 == _0023_003DzbxU6JuvUsaVO.V1)
			{
				_0023_003DzU8n8_0024pIm_rPr(item);
				_0023_003DzIH0nSl3s3_0024xs = true;
				if (_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[item._0023_003Dz2CwKCVa_kVAH]._0023_003DzNPS2Q4c_003D != _0023_003DzhyZURwQ_003D)
				{
					_0023_003DzPfW6LU9pXtQQOUdeSw_003D_003D(_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[item._0023_003Dz2CwKCVa_kVAH]._0023_003DzNPS2Q4c_003D, _0023_003DzhyZURwQ_003D);
				}
				break;
			}
		}
	}

	private void _0023_003DzPfW6LU9pXtQQOUdeSw_003D_003D(int _0023_003DzKV5V6WI_003D, int _0023_003Dz8SEdsjQ_003D)
	{
		foreach (_0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D item in _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D)
		{
			if (item._0023_003DzNPS2Q4c_003D == _0023_003DzKV5V6WI_003D)
			{
				item._0023_003DzNPS2Q4c_003D = _0023_003Dz8SEdsjQ_003D;
			}
		}
	}

	private void _0023_003Dz8itQqlUWdbkr9s0dBg_003D_003D(int _0023_003DzFo_U0NUl4WHZ, int _0023_003DzyKCZuJmgxR0g)
	{
		foreach (_0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D item in _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D)
		{
			if (item._0023_003DzNPS2Q4c_003D != _0023_003DzFo_U0NUl4WHZ)
			{
				continue;
			}
			item._0023_003DzNPS2Q4c_003D = _0023_003DzyKCZuJmgxR0g;
			item._0023_003Dz0wcqTpk_003D();
			foreach (_0023_003DzJg1dS43G0JHg item2 in _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[item.V1]._0023_003DzO5dKkT0hsWIy)
			{
				if (item2.V1 == item.V2)
				{
					item2._0023_003Dz0wcqTpk_003D();
				}
				else if (item2.V2 == item.V2)
				{
					item2._0023_003Dz0wcqTpk_003D();
				}
			}
			foreach (_0023_003DzJg1dS43G0JHg item3 in _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[item.V2]._0023_003DzO5dKkT0hsWIy)
			{
				if (item3.V1 == item.V3)
				{
					item3._0023_003Dz0wcqTpk_003D();
				}
				else if (item3.V2 == item.V3)
				{
					item3._0023_003Dz0wcqTpk_003D();
				}
			}
			foreach (_0023_003DzJg1dS43G0JHg item4 in _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[item.V3]._0023_003DzO5dKkT0hsWIy)
			{
				if (item4.V1 == item.V1)
				{
					item4._0023_003Dz0wcqTpk_003D();
				}
				else if (item4.V2 == item.V1)
				{
					item4._0023_003Dz0wcqTpk_003D();
				}
			}
		}
	}

	private void _0023_003DzcPyJEcUAaiSA(_0023_003DzJg1dS43G0JHg _0023_003DzbxU6JuvUsaVO)
	{
		foreach (_0023_003DzJg1dS43G0JHg item in _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzbxU6JuvUsaVO.V1]._0023_003DzO5dKkT0hsWIy)
		{
			if (item.V1 == _0023_003DzbxU6JuvUsaVO.V1 && item.V2 == _0023_003DzbxU6JuvUsaVO.V2)
			{
				item._0023_003Dz9pre6_0024c_003D = (_0023_003Dz5A3bbQQ_003D)1;
				break;
			}
		}
		foreach (_0023_003DzJg1dS43G0JHg item2 in _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzbxU6JuvUsaVO.V2]._0023_003DzO5dKkT0hsWIy)
		{
			if (item2.V1 == _0023_003DzbxU6JuvUsaVO.V1 && item2.V2 == _0023_003DzbxU6JuvUsaVO.V2)
			{
				item2._0023_003Dz9pre6_0024c_003D = (_0023_003Dz5A3bbQQ_003D)1;
				break;
			}
		}
	}

	private void _0023_003DzEMk2AS98ky5Z(_0023_003DzJg1dS43G0JHg _0023_003DzTzxnbjXO0S11Q1gFlA_003D_003D, out int _0023_003DzZpm_0024ltUkzcNd, out Point3D _0023_003DzbUvT9Pc_003D, out Vector3D _0023_003Dzn8G7AOUeiIgL)
	{
		_0023_003DzbUvT9Pc_003D = null;
		_0023_003Dzn8G7AOUeiIgL = null;
		_0023_003DzZpm_0024ltUkzcNd = -1;
		double num = 2.0 * _0023_003DzEGKj_0024SNUUihi * (2.0 * _0023_003DzEGKj_0024SNUUihi);
		Point3D point3D = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTzxnbjXO0S11Q1gFlA_003D_003D._0023_003DzNc67xInN3I5x()];
		Point3D point3D2 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTzxnbjXO0S11Q1gFlA_003D_003D._0023_003Dznqtw2c4nckQi()];
		Point3D _0023_003Dz1v6oPQk_003D = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTzxnbjXO0S11Q1gFlA_003D_003D._0023_003DzGTfQPRCBlDaHPcBcVA_003D_003D];
		Point3D point3D3 = Point3D.MidPoint(point3D2, point3D);
		Vector3D vector3D = _0023_003Dzpm9tjtBJvE3c(point3D, _0023_003Dz1v6oPQk_003D, point3D2);
		vector3D.Normalize();
		double num2 = Math.PI * 2.0;
		int[] array = _0023_003DzpaBrLMD2fNgjJqmnC4Z_N_Y_003D(point3D3, _0023_003DzoQcRoMY_003D: false, new int[3]
		{
			_0023_003DzTzxnbjXO0S11Q1gFlA_003D_003D._0023_003DzNc67xInN3I5x(),
			_0023_003DzTzxnbjXO0S11Q1gFlA_003D_003D._0023_003Dznqtw2c4nckQi(),
			_0023_003DzTzxnbjXO0S11Q1gFlA_003D_003D._0023_003DzGTfQPRCBlDaHPcBcVA_003D_003D
		});
		foreach (int num3 in array)
		{
			_0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num3];
			if ((_0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2._0023_003DzwKt32wM_003D && _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2._0023_003Dzt__TDBUJ98AJ == 0) || Vector3D.Subtract(_0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2, point3D3).LengthSquared >= num || !_0023_003Dz11_00246mjXyKCARKX4kI78_ISntHPmFePJ1_Q_003D_003D(_0023_003DzTzxnbjXO0S11Q1gFlA_003D_003D, num3) || !_0023_003DzBPfSf_sTCXxM4AlGjQ_003D_003D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTzxnbjXO0S11Q1gFlA_003D_003D._0023_003DzNc67xInN3I5x()], _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTzxnbjXO0S11Q1gFlA_003D_003D._0023_003Dznqtw2c4nckQi()], out var _0023_003DzbUvT9Pc_003D2))
			{
				continue;
			}
			int[] _0023_003DzXqLHJJNLZNqRvw5DJOf6HmI_003D = _0023_003DzpaBrLMD2fNgjJqmnC4Z_N_Y_003D(_0023_003DzbUvT9Pc_003D2, _0023_003DzoQcRoMY_003D: false, new int[3]
			{
				_0023_003DzTzxnbjXO0S11Q1gFlA_003D_003D._0023_003DzNc67xInN3I5x(),
				_0023_003DzTzxnbjXO0S11Q1gFlA_003D_003D._0023_003Dznqtw2c4nckQi(),
				num3
			});
			if (!_0023_003Dz7GrnXpAS0j2D(_0023_003DzXqLHJJNLZNqRvw5DJOf6HmI_003D, _0023_003DzbUvT9Pc_003D2))
			{
				continue;
			}
			Vector3D vector3D2 = Vector3D.Subtract(_0023_003DzTzxnbjXO0S11Q1gFlA_003D_003D._0023_003Dzyb0dBFAYdBen, point3D3);
			Vector3D a = Vector3D.Subtract(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTzxnbjXO0S11Q1gFlA_003D_003D._0023_003Dznqtw2c4nckQi()], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTzxnbjXO0S11Q1gFlA_003D_003D._0023_003DzNc67xInN3I5x()]);
			Plane _0023_003Dzpyw2kZk_003D = new Plane(point3D3, vector3D2, Vector3D.Cross(a, vector3D2));
			if (!_0023_003DzLJl1Anp8Xqarc88cEC_AuoA_003D(_0023_003DzbUvT9Pc_003D2, _0023_003DzTzxnbjXO0S11Q1gFlA_003D_003D._0023_003Dzyb0dBFAYdBen, _0023_003Dzpyw2kZk_003D, out var _0023_003DzIeOqf2k_003D, out var _0023_003Dz9yCvG38_003D))
			{
				continue;
			}
			double num4 = Utility.ArcTanProblem(_0023_003DzIeOqf2k_003D.X, _0023_003DzIeOqf2k_003D.Y);
			if (num4 < num2)
			{
				num2 = num4;
				_0023_003DzbUvT9Pc_003D = _0023_003DzbUvT9Pc_003D2;
				_0023_003DzZpm_0024ltUkzcNd = num3;
			}
			if (_0023_003Dz9yCvG38_003D != null)
			{
				num4 = Utility.ArcTanProblem(_0023_003Dz9yCvG38_003D.X, _0023_003Dz9yCvG38_003D.Y);
				if (num4 < num2)
				{
					num2 = num4;
					_0023_003DzbUvT9Pc_003D = _0023_003DzbUvT9Pc_003D2;
					_0023_003DzZpm_0024ltUkzcNd = num3;
				}
			}
		}
		if (_0023_003DzZpm_0024ltUkzcNd != -1)
		{
			_0023_003Dzn8G7AOUeiIgL = new Vector3D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTzxnbjXO0S11Q1gFlA_003D_003D._0023_003DzNc67xInN3I5x()], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzZpm_0024ltUkzcNd], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTzxnbjXO0S11Q1gFlA_003D_003D._0023_003Dznqtw2c4nckQi()]);
			if (Vector3D.Dot(vector3D, _0023_003Dzn8G7AOUeiIgL) > _0023_003DzltwEPbggNwEV)
			{
				_0023_003DzZpm_0024ltUkzcNd = -1;
			}
		}
	}

	private bool _0023_003Dz11_00246mjXyKCARKX4kI78_ISntHPmFePJ1_Q_003D_003D(_0023_003DzJg1dS43G0JHg _0023_003Dz3M06frs_003D, int _0023_003DzZpm_0024ltUkzcNd)
	{
		IndexTriangle indexTriangle = new IndexTriangle(_0023_003Dz3M06frs_003D._0023_003DzNc67xInN3I5x(), _0023_003DzZpm_0024ltUkzcNd, _0023_003Dz3M06frs_003D._0023_003Dznqtw2c4nckQi());
		foreach (int item in _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzZpm_0024ltUkzcNd]._0023_003DzoR2_vtHc8SYueITipw_003D_003D)
		{
			IndexTriangle indexTriangle2 = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[item];
			for (int i = 0; i < 3; i++)
			{
				IndexLine indexLine = i switch
				{
					0 => new IndexLine(indexTriangle2.V1, indexTriangle2.V2), 
					1 => new IndexLine(indexTriangle2.V2, indexTriangle2.V3), 
					_ => new IndexLine(indexTriangle2.V3, indexTriangle2.V1), 
				};
				for (int j = 0; j < 3; j++)
				{
					IndexLine indexLine2 = j switch
					{
						0 => new IndexLine(indexTriangle.V1, indexTriangle.V2), 
						1 => new IndexLine(indexTriangle.V2, indexTriangle.V3), 
						_ => new IndexLine(indexTriangle.V3, indexTriangle.V1), 
					};
					if (indexLine.V1 == indexLine2.V1 && indexLine.V2 == indexLine2.V2)
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	private bool _0023_003Dz7GrnXpAS0j2D(int[] _0023_003DzXqLHJJNLZNqRvw5DJOf6HmI_003D, Point3D _0023_003DzbUvT9Pc_003D)
	{
		bool result = true;
		foreach (int num in _0023_003DzXqLHJJNLZNqRvw5DJOf6HmI_003D)
		{
			if (Vector3D.Subtract(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num], _0023_003DzbUvT9Pc_003D).LengthSquared < _0023_003Dzg_h72rRM798oluKqlg_003D_003D)
			{
				result = false;
				break;
			}
		}
		return result;
	}

	private bool _0023_003DzLJl1Anp8Xqarc88cEC_AuoA_003D(Point3D _0023_003DzlY77YgY_003D, Point3D _0023_003DzTQKWZlKLX_yc, Plane _0023_003Dzpyw2kZk_003D, out Point2D _0023_003DzIeOqf2k_003D, out Point2D _0023_003Dz9yCvG38_003D)
	{
		_0023_003DzIeOqf2k_003D = null;
		_0023_003Dz9yCvG38_003D = null;
		Point2D point2D = _0023_003Dzpyw2kZk_003D.Project(_0023_003DzTQKWZlKLX_yc);
		double radius = Math.Sqrt(point2D.X * point2D.X + point2D.Y * point2D.Y);
		Circle arc = new Circle(_0023_003Dzpyw2kZk_003D, radius);
		if (_0023_003DzaaUKTkjX2jRfWDnM7hR3Q2o_003D(_0023_003Dzpyw2kZk_003D, _0023_003DzlY77YgY_003D, _0023_003DzEGKj_0024SNUUihi, out var _0023_003Dz0_I2qEVS6EC1pT94Vw_003D_003D))
		{
			Point2D center = _0023_003Dzpyw2kZk_003D.Project(_0023_003DzlY77YgY_003D);
			Circle arc2 = new Circle(_0023_003Dzpyw2kZk_003D, center, _0023_003Dz0_I2qEVS6EC1pT94Vw_003D_003D);
			if (Utility.IntersectionCircleCircle(arc, arc2, _0023_003Dzpyw2kZk_003D, out var i, out var i2))
			{
				_0023_003DzIeOqf2k_003D = _0023_003Dzpyw2kZk_003D.Project(i);
				if (i2 != null)
				{
					_0023_003Dz9yCvG38_003D = _0023_003Dzpyw2kZk_003D.Project(i2);
				}
				return true;
			}
			return false;
		}
		return false;
	}

	private int[] _0023_003DzpaBrLMD2fNgjJqmnC4Z_N_Y_003D(Point3D _0023_003DzMlCq3wk_003D, bool _0023_003DzoQcRoMY_003D, int[] _0023_003Dzldw1EYw_003D)
	{
		Array.Sort(_0023_003Dzldw1EYw_003D);
		_0023_003DzL9woobs_003D(_0023_003DzMlCq3wk_003D, out var _0023_003Dzk8kWavc_003D, out var _0023_003DzdV1szTs_003D, out var _0023_003Dzc_0024dH8eA_003D, out var _0023_003DzDHgNxvo_003D, out var _0023_003DzkdVpuAA_003D, out var _0023_003Dz348qKC4_003D);
		Dictionary<double, int> dictionary = null;
		List<int> list = null;
		if (_0023_003DzoQcRoMY_003D)
		{
			dictionary = new Dictionary<double, int>(27);
		}
		else
		{
			list = new List<int>(27);
		}
		for (int i = _0023_003DzkdVpuAA_003D; i < _0023_003Dz348qKC4_003D; i++)
		{
			for (int j = _0023_003Dzc_0024dH8eA_003D; j < _0023_003DzDHgNxvo_003D; j++)
			{
				for (int k = _0023_003Dzk8kWavc_003D; k < _0023_003DzdV1szTs_003D; k++)
				{
					if (_0023_003DzoQcRoMY_003D)
					{
						foreach (int item in _0023_003DzgYhCuHM3lqSw[k, j, i])
						{
							double lengthSquared = Vector3D.Subtract(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[item], _0023_003DzMlCq3wk_003D).LengthSquared;
							if (!dictionary.ContainsKey(lengthSquared) && Array.BinarySearch(_0023_003Dzldw1EYw_003D, item) < 0)
							{
								dictionary.Add(lengthSquared, item);
							}
						}
						continue;
					}
					foreach (int item2 in _0023_003DzgYhCuHM3lqSw[k, j, i])
					{
						if (Array.BinarySearch(_0023_003Dzldw1EYw_003D, item2) < 0)
						{
							list.Add(item2);
						}
					}
				}
			}
		}
		int[] array;
		if (_0023_003DzoQcRoMY_003D)
		{
			array = new int[dictionary.Values.Count];
			dictionary.Values.CopyTo(array, 0);
		}
		else
		{
			array = list.ToArray();
		}
		return array;
	}

	private void _0023_003DzL9woobs_003D(Point3D _0023_003DzMlCq3wk_003D, out int _0023_003Dzk8kWavc_003D, out int _0023_003DzdV1szTs_003D, out int _0023_003Dzc_0024dH8eA_003D, out int _0023_003DzDHgNxvo_003D, out int _0023_003DzkdVpuAA_003D, out int _0023_003Dz348qKC4_003D)
	{
		int num = (int)((_0023_003DzMlCq3wk_003D.X - _0023_003DzZh8SRdGSxXy2.X) / _0023_003DzHvAfpUm5f0OK);
		int num2 = (int)((_0023_003DzMlCq3wk_003D.Y - _0023_003DzZh8SRdGSxXy2.Y) / _0023_003DzHvAfpUm5f0OK);
		int num3 = (int)((_0023_003DzMlCq3wk_003D.Z - _0023_003DzZh8SRdGSxXy2.Z) / _0023_003DzHvAfpUm5f0OK);
		_0023_003Dzk8kWavc_003D = ((num != 0) ? (num - 1) : 0);
		_0023_003DzdV1szTs_003D = ((num < _0023_003DzeObW70tsLUirP_00244LqA_003D_003D - 2) ? (num + 2) : ((num < num - 1) ? (num + 1) : _0023_003DzeObW70tsLUirP_00244LqA_003D_003D));
		_0023_003Dzc_0024dH8eA_003D = ((num2 != 0) ? (num2 - 1) : 0);
		_0023_003DzDHgNxvo_003D = ((num2 < _0023_003DzNDNPd73F3DLFeLWrmA_003D_003D - 2) ? (num2 + 2) : ((num2 < num2 - 1) ? (num2 + 1) : _0023_003DzNDNPd73F3DLFeLWrmA_003D_003D));
		_0023_003DzkdVpuAA_003D = ((num3 != 0) ? (num3 - 1) : 0);
		_0023_003Dz348qKC4_003D = ((num3 < _0023_003DzYj_vsfVr7IXPrp3r6w_003D_003D - 2) ? (num3 + 2) : ((num3 < num3 - 1) ? (num3 + 1) : _0023_003DzYj_vsfVr7IXPrp3r6w_003D_003D));
	}

	private _0023_003DzJg1dS43G0JHg _0023_003Dzj7kMO8dOcUv9(int _0023_003DzZpm_0024ltUkzcNd)
	{
		_0023_003DzJg1dS43G0JHg _0023_003DzJg1dS43G0JHg2 = _0023_003Dz2OpOUN7v5RidHQ_0024jqOhDPxt5PDS7(_0023_003DzZpm_0024ltUkzcNd);
		if (_0023_003DzJg1dS43G0JHg2 != null)
		{
			return _0023_003DzJg1dS43G0JHg2;
		}
		return _0023_003DzvBYfcOcqBa4e();
	}

	private _0023_003DzJg1dS43G0JHg _0023_003DzvBYfcOcqBa4e()
	{
		_0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D[] array = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D;
		foreach (_0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2 in array)
		{
			if (!_0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2._0023_003DzwKt32wM_003D || _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2._0023_003Dzt__TDBUJ98AJ <= 0)
			{
				continue;
			}
			foreach (_0023_003DzJg1dS43G0JHg item in _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2._0023_003DzO5dKkT0hsWIy)
			{
				if (item._0023_003Dz9pre6_0024c_003D == (_0023_003Dz5A3bbQQ_003D)0)
				{
					return item;
				}
			}
		}
		return null;
	}

	private _0023_003DzJg1dS43G0JHg _0023_003Dz2OpOUN7v5RidHQ_0024jqOhDPxt5PDS7(int _0023_003DzZpm_0024ltUkzcNd)
	{
		int[] array = _0023_003DzpaBrLMD2fNgjJqmnC4Z_N_Y_003D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzZpm_0024ltUkzcNd], _0023_003DzoQcRoMY_003D: false, new int[0]);
		foreach (int num in array)
		{
			_0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num];
			if (!_0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2._0023_003DzwKt32wM_003D || _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2._0023_003Dzt__TDBUJ98AJ <= 0)
			{
				continue;
			}
			foreach (_0023_003DzJg1dS43G0JHg item in _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2._0023_003DzO5dKkT0hsWIy)
			{
				if (item._0023_003Dz9pre6_0024c_003D == (_0023_003Dz5A3bbQQ_003D)0)
				{
					return item;
				}
			}
		}
		return null;
	}

	private int _0023_003DzYv7Upc0yYEpt(int _0023_003DzFNv10ndShqpu, int _0023_003DzFzSqpAxXboaS, int _0023_003DzZpm_0024ltUkzcNd, Vector3D _0023_003DzZbOaTIM_003D)
	{
		_0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D item = new _0023_003DzAeeGWU9Q9uYVkzYmnomso6k_003D(_0023_003DzFNv10ndShqpu, _0023_003DzFzSqpAxXboaS, _0023_003DzZpm_0024ltUkzcNd, _0023_003DzhyZURwQ_003D, _0023_003DzZbOaTIM_003D);
		int count = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Count;
		_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Add(item);
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzFNv10ndShqpu]._0023_003DzoR2_vtHc8SYueITipw_003D_003D.Add(count);
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzFzSqpAxXboaS]._0023_003DzoR2_vtHc8SYueITipw_003D_003D.Add(count);
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzZpm_0024ltUkzcNd]._0023_003DzoR2_vtHc8SYueITipw_003D_003D.Add(count);
		return count;
	}

	private bool _0023_003DzkVFF5DAMh_0024um(out int _0023_003DzFNv10ndShqpu, out int _0023_003DzFzSqpAxXboaS, out int _0023_003DzZpm_0024ltUkzcNd, out Point3D _0023_003DzbUvT9Pc_003D)
	{
		_0023_003DzFNv10ndShqpu = -1;
		_0023_003DzFzSqpAxXboaS = -1;
		_0023_003DzZpm_0024ltUkzcNd = -1;
		_0023_003DzbUvT9Pc_003D = null;
		while (_0023_003DzDr1MUxo_003D < _0023_003Dzrf5YV8a6cCAg)
		{
			int num = _0023_003DzDr1MUxo_003D++;
			_0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num];
			if (_0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2._0023_003DzwKt32wM_003D)
			{
				continue;
			}
			int[] array = _0023_003DzpaBrLMD2fNgjJqmnC4Z_N_Y_003D(_0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2, _0023_003DzoQcRoMY_003D: true, new int[1] { _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2._0023_003Dz_NdRtMQ_003D });
			int _0023_003DzAFLumEs_003D = 0;
			do
			{
				int num2 = _0023_003DzHlAvuREAmupJ(ref _0023_003DzAFLumEs_003D, array, new int[1] { _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2._0023_003Dz_NdRtMQ_003D });
				int num3 = _0023_003DzHlAvuREAmupJ(ref _0023_003DzAFLumEs_003D, array, new int[2] { _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2._0023_003Dz_NdRtMQ_003D, num2 });
				if (num2 != -1 && num3 != -1 && _0023_003DzBPfSf_sTCXxM4AlGjQ_003D_003D(_0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D2, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num2], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num3], out _0023_003DzbUvT9Pc_003D))
				{
					int[] array2 = new int[3] { num, num2, num3 };
					Array.Sort(array2);
					int[] _0023_003DzXqLHJJNLZNqRvw5DJOf6HmI_003D = _0023_003DzpaBrLMD2fNgjJqmnC4Z_N_Y_003D(_0023_003DzbUvT9Pc_003D, _0023_003DzoQcRoMY_003D: false, array2);
					if (_0023_003Dz7GrnXpAS0j2D(_0023_003DzXqLHJJNLZNqRvw5DJOf6HmI_003D, _0023_003DzbUvT9Pc_003D))
					{
						_0023_003DzFNv10ndShqpu = num;
						_0023_003DzFzSqpAxXboaS = num2;
						_0023_003DzZpm_0024ltUkzcNd = num3;
						_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzFNv10ndShqpu]._0023_003DzwKt32wM_003D = true;
						_0023_003DzQGz7TQAY_JX_0024++;
						_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzFzSqpAxXboaS]._0023_003DzwKt32wM_003D = true;
						_0023_003DzQGz7TQAY_JX_0024++;
						_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzZpm_0024ltUkzcNd]._0023_003DzwKt32wM_003D = true;
						_0023_003DzQGz7TQAY_JX_0024++;
						return true;
					}
				}
			}
			while (_0023_003DzAFLumEs_003D++ < array.Length);
		}
		return false;
	}

	private int _0023_003DzHlAvuREAmupJ(ref int _0023_003DzAFLumEs_003D, int[] _0023_003DzfB65z6vhM2L8, int[] _0023_003Dzldw1EYw_003D)
	{
		Array.Sort(_0023_003Dzldw1EYw_003D);
		for (int i = _0023_003DzAFLumEs_003D; i < _0023_003DzfB65z6vhM2L8.Length; i++)
		{
			int num = _0023_003DzfB65z6vhM2L8[i];
			if (!_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num]._0023_003DzwKt32wM_003D && Array.BinarySearch(_0023_003Dzldw1EYw_003D, num) < 0)
			{
				return num;
			}
		}
		return -1;
	}

	private Vector3D _0023_003Dzpm9tjtBJvE3c(Point3D _0023_003DzjbqS1qE_003D, Point3D _0023_003Dz1v6oPQk_003D, Point3D _0023_003Dzt_m8zV0_003D)
	{
		return Vector3D.Cross(Vector3D.Subtract(_0023_003Dz1v6oPQk_003D, _0023_003DzjbqS1qE_003D), Vector3D.Subtract(_0023_003Dzt_m8zV0_003D, _0023_003DzjbqS1qE_003D));
	}

	private static bool _0023_003DzaaUKTkjX2jRfWDnM7hR3Q2o_003D(Plane _0023_003Dzpyw2kZk_003D, Point3D _0023_003DzvMU08Yh_0024z_n401OuCg_003D_003D, double _0023_003Dz5g3Wi1dh6jWM4KvEuA_003D_003D, out double _0023_003Dz0_I2qEVS6EC1pT94Vw_003D_003D)
	{
		_0023_003Dz0_I2qEVS6EC1pT94Vw_003D_003D = 0.0;
		double num = _0023_003Dzpyw2kZk_003D.DistanceTo(_0023_003DzvMU08Yh_0024z_n401OuCg_003D_003D);
		if (Math.Abs(num) < _0023_003Dz5g3Wi1dh6jWM4KvEuA_003D_003D)
		{
			_0023_003Dz0_I2qEVS6EC1pT94Vw_003D_003D = Math.Sqrt(_0023_003Dz5g3Wi1dh6jWM4KvEuA_003D_003D * _0023_003Dz5g3Wi1dh6jWM4KvEuA_003D_003D - num * num);
			return true;
		}
		return false;
	}

	private bool _0023_003DzBPfSf_sTCXxM4AlGjQ_003D_003D(_0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D _0023_003DzFj_0024IqDQ_003D, _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D _0023_003DzjdeMMkk_003D, _0023_003Dzp38s1e_0024OT05G15DFW_EOvtw_003D _0023_003Dzm4eSPQQ_003D, out Point3D _0023_003DzbUvT9Pc_003D)
	{
		_0023_003DzbUvT9Pc_003D = null;
		Vector3D vector3D = Vector3D.Subtract(_0023_003DzjdeMMkk_003D, _0023_003DzFj_0024IqDQ_003D);
		Vector3D vector3D2 = Vector3D.Subtract(_0023_003Dzm4eSPQQ_003D, _0023_003DzFj_0024IqDQ_003D);
		Vector3D vector3D3 = Vector3D.Cross(vector3D, vector3D2);
		if (!vector3D3.Normalize())
		{
			return false;
		}
		double num = Vector3D.Dot(vector3D, vector3D);
		double num2 = Vector3D.Dot(vector3D, vector3D2);
		double num3 = Vector3D.Dot(vector3D2, vector3D2);
		double num4 = 4.0 * (num * num3 - num2 * num2);
		if (num4 < 1E-20)
		{
			return false;
		}
		double num5 = 2.0 * (num * num3 - num3 * num2) / num4;
		double num6 = 2.0 * (num * num3 - num2 * num) / num4;
		Vector3D vector3D4 = vector3D * num5 + vector3D2 * num6;
		double length = vector3D4.Length;
		if (length > _0023_003DzEGKj_0024SNUUihi)
		{
			return false;
		}
		double num7 = Math.Sqrt(_0023_003Dzg_h72rRM798oluKqlg_003D_003D - length * length);
		_0023_003DzbUvT9Pc_003D = vector3D4 + _0023_003DzFj_0024IqDQ_003D + vector3D3 * num7;
		return true;
	}
}
