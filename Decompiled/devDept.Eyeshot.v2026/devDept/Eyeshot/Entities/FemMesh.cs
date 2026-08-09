using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using devDept.Eyeshot.Fem;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class FemMesh : Entity, IFace, ICloneable
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<Element, bool> _0023_003DzSxQAZRyZzYck3F8g_0024Q_003D_003D;

		internal bool _0023_003DzilTcOzWF2IZkvAvPlS9mDCgJVM3b(Element _0023_003DzBJFJHwk_003D)
		{
			if (!(_0023_003DzBJFJHwk_003D is Truss) && !(_0023_003DzBJFJHwk_003D is Beam { beamVerts: not null }) && !(_0023_003DzBJFJHwk_003D is Truss2D))
			{
				if (_0023_003DzBJFJHwk_003D is Beam2D beam2D)
				{
					return beam2D != null;
				}
				return false;
			}
			return true;
		}
	}

	private sealed class _0023_003DzFIL5egV6HutA45oxHQ_003D_003D : Mesh.DrawEdgesInternalParams
	{
		private ILegend _0023_003DzSDfjTDRQcWF_jHUeyQ_003D_003D;

		public ILegend _0023_003DzPSXhlRzLAPhX()
		{
			return _0023_003DzSDfjTDRQcWF_jHUeyQ_003D_003D;
		}

		public void _0023_003Dz4vK0VMtpHANN(ILegend _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzSDfjTDRQcWF_jHUeyQ_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}
	}

	public enum clippingMethodType
	{
		Planar,
		ByElement
	}

	public enum plotType
	{
		Mesh,
		Ux,
		Uy,
		Uz,
		U,
		Sx,
		Sy,
		Sz,
		Txy,
		Tyz,
		Txz,
		P1,
		P2,
		P3,
		VonMises,
		Tresca,
		Rx,
		Ry,
		Rz,
		AxialForce,
		ShearForceV,
		ShearForceW,
		TorsionMoment,
		BeamBendingMomentV,
		BeamBendingMomentW,
		TwistAngle
	}

	internal Mesh skin;

	private List<Mesh> _elementsSlices = new List<Mesh>();

	private Plane _clippingPlane;

	private clippingMethodType _clippingMethod = _0023_003DzYZiDrYtPyU3U();

	internal double minEdgeLen;

	internal int[] boundaryNodes;

	private double minValue;

	private double maxValue;

	private clippingMethodType _prevMethod = _0023_003DzYZiDrYtPyU3U();

	private Plane _prevPlane;

	internal int[,] isoEdges;

	private TextureBase texture1D;

	internal bool solved;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static Vector3D _0023_003Dzqbyy3C2zuui1RfLd1w_003D_003D;

	private int numVertices;

	private int numElements;

	internal Element[] elements;

	private EntityGraphicsData drawSelected;

	private EntityGraphicsData drawMesh;

	private EntityGraphicsData drawSolved;

	private EntityGraphicsData[] drawSolvedFrames;

	private EntityGraphicsData drawEdges;

	private EntityGraphicsData[] drawEdgesFrames;

	private EntityGraphicsData drawIsocurves;

	private EntityGraphicsData[] drawIsocurvesFrames;

	private double _ampFactor = 1.0;

	private double _optimalSymbolSize;

	private double _optimalAmpFactor;

	private int _minNode = -1;

	private int _maxNode = -1;

	private plotType plotMode;

	private bool nodalAverages = true;

	private bool contourPlot = true;

	private double maxArrowLen;

	private double symbolSize = 1.0;

	private int _modeIndex;

	public Plane ClippingPlane
	{
		get
		{
			return _clippingPlane;
		}
		set
		{
			if (!IsTrussStudy && !IsBeamStudy)
			{
				_prevPlane = _clippingPlane;
				_clippingPlane = value;
				_elementsSlices.Clear();
				if (_clippingMethod == clippingMethodType.ByElement)
				{
					RegenMode = regenType.RegenAndCompile;
				}
				else if (regenMode == regenType.NotNeeded)
				{
					RegenMode = regenType.CompileOnly;
				}
			}
		}
	}

	public clippingMethodType ClippingMethod
	{
		get
		{
			return _clippingMethod;
		}
		set
		{
			switch (value)
			{
			case clippingMethodType.ByElement:
				_0023_003Dz2590AGndWcVccsIaNg_003D_003D();
				RegenMode = regenType.RegenAndCompile;
				break;
			case clippingMethodType.Planar:
				RegenMode = regenType.CompileOnly;
				break;
			}
			_prevMethod = _clippingMethod;
			_clippingMethod = value;
		}
	}

	public int FrameNumber { get; set; }

	public bool Solved => solved;

	public bool IsBeamStudy
	{
		get
		{
			if (elements != null && elements.Length != 0)
			{
				if (!(elements[0] is Beam))
				{
					return elements[0] is Beam2D;
				}
				return true;
			}
			return false;
		}
	}

	public bool IsTrussStudy
	{
		get
		{
			if (elements != null && elements.Length != 0)
			{
				if (!(elements[0] is Truss))
				{
					return elements[0] is Truss2D;
				}
				return true;
			}
			return false;
		}
	}

	public bool IsBeam2DStudy
	{
		get
		{
			if (elements != null && elements.Length != 0)
			{
				return elements[0] is Beam2D;
			}
			return false;
		}
	}

	public double OptimalAmplificationFactor => _optimalAmpFactor;

	public double[] NaturalFrequencies { get; }

	public plotType PlotMode
	{
		get
		{
			return plotMode;
		}
		set
		{
			plotMode = value;
			UpdateBoundingBox(null);
			if (RegenMode == regenType.NotNeeded)
			{
				RegenMode = regenType.CompileOnly;
			}
		}
	}

	public bool NodalAverages
	{
		get
		{
			return nodalAverages;
		}
		set
		{
			nodalAverages = value;
			if (RegenMode == regenType.NotNeeded)
			{
				RegenMode = regenType.CompileOnly;
			}
		}
	}

	public bool ContourPlot
	{
		get
		{
			return contourPlot;
		}
		set
		{
			contourPlot = value;
			if (RegenMode == regenType.NotNeeded)
			{
				RegenMode = regenType.CompileOnly;
			}
		}
	}

	public double AmplificationFactor
	{
		get
		{
			return _ampFactor;
		}
		set
		{
			_ampFactor = value;
			UpdateBoundingBox(null);
			if (RegenMode == regenType.NotNeeded)
			{
				RegenMode = regenType.CompileOnly;
			}
		}
	}

	public Element[] Elements
	{
		get
		{
			return elements;
		}
		set
		{
			elements = value;
		}
	}

	[Browsable(false)]
	public int MinNodeIndex => _minNode;

	[Browsable(false)]
	public int MaxNodeIndex => _maxNode;

	public int NumberOfDimensions
	{
		get
		{
			if (elements[0] is Beam2D || (elements[0] is Element2D && !(Vertices[0] is NodeBeam)))
			{
				return 2;
			}
			return 3;
		}
	}

	public int NumberOfDegreesOfFreedom
	{
		get
		{
			if (elements[0] is Element2D && !(Vertices[0] is NodeBeam))
			{
				return 2;
			}
			if (elements[0] is Beam || (elements[0] is Element2D && !(elements[0] is Beam2D)))
			{
				return 6;
			}
			return 3;
		}
	}

	public Mesh BoundaryMesh => skin;

	public double SymbolSize
	{
		get
		{
			return symbolSize;
		}
		set
		{
			symbolSize = value;
			if (symbolSize > 1.0)
			{
				symbolSize = 1.0;
			}
		}
	}

	public HistogramData ElementShapeQualities { get; set; }

	public HistogramData EdgeShapeQualities { get; set; }

	static FemMesh()
	{
		_0023_003Dzqbyy3C2zuui1RfLd1w_003D_003D = 9.80665 * Vector3D.AxisMinusZ;
		plotType.Mesh.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969239));
		plotType.Ux.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969220));
		plotType.Uy.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969227));
		plotType.Uz.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968950));
		plotType.U.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911455));
		plotType.Sx.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968957));
		plotType.Sy.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968942));
		plotType.Sz.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968923));
		plotType.Txy.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968908));
		plotType.Tyz.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968889));
		plotType.Txz.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968874));
		plotType.P1.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968855));
		plotType.P2.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968847));
		plotType.P3.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969070));
		plotType.VonMises.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969030));
		plotType.Tresca.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969014));
		plotType.Rx.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968993));
		plotType.Ry.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969004));
		plotType.Rz.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968979));
		plotType.AxialForce.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968990));
		plotType.ShearForceV.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968976));
		plotType.ShearForceW.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969700));
		plotType.TorsionMoment.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969688));
		plotType.BeamBendingMomentV.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969675));
		plotType.BeamBendingMomentW.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969636));
		plotType.TwistAngle.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969625));
	}

	public FemMesh(int numVertices, int numElements)
		: this()
	{
		this.numVertices = numVertices;
		this.numElements = numElements;
		_vertices = new Point3D[this.numVertices];
		elements = new Element[this.numElements];
	}

	public FemMesh(IList<Point3D> theNodes, IList<Element> theElements)
		: this()
	{
		numVertices = theNodes.Count;
		numElements = theElements.Count;
		_vertices = theNodes.ToArray();
		elements = theElements.ToArray();
	}

	private FemMesh()
		: base(entityNatureType.RichPolygon)
	{
		_0023_003DzCBXaK_002496NUpX(4);
	}

	protected FemMesh(FemMesh another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_vertices = new Point3D[another._vertices.Length];
		for (int i = 0; i < _vertices.Length; i++)
		{
			_vertices[i] = (Node)another._vertices[i].Clone();
		}
		elements = new Element[another.elements.Length];
		for (int j = 0; j < elements.Length; j++)
		{
			elements[j] = (Element)another.elements[j].Clone();
		}
		plotMode = another.plotMode;
		nodalAverages = another.nodalAverages;
		contourPlot = another.contourPlot;
		if (keepTessellation)
		{
			_0023_003Dz1mGkvCqedA2D(another);
		}
	}

	protected internal FemMesh(FemMeshSurrogate surrogate)
		: this(surrogate.Vertices, surrogate.Elements)
	{
	}

	protected FemMesh(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		numVertices = info.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969611));
		_vertices = (Point3D[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969830), typeof(object[]));
		numElements = info.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969810));
		elements = (Element[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969801), typeof(object[]));
	}

	private static clippingMethodType _0023_003DzYZiDrYtPyU3U()
	{
		return clippingMethodType.Planar;
	}

	public override void Regen(RegenParams data)
	{
		bool flag = ClippingMethod == clippingMethodType.ByElement;
		List<int[]> list = new List<int[]>();
		for (int i = 0; i < elements.Length; i++)
		{
			Element element = elements[i];
			element._0023_003DzrZebj3Heywbr();
			if (flag && ClippingPlane != null && _0023_003Dz0UFBJGrat4P3(element))
			{
				continue;
			}
			if (element is Tria3)
			{
				list.Add(new int[5]
				{
					element._0023_003Dz50rnh9I_003D(0, 0),
					element._0023_003Dz50rnh9I_003D(0, 1),
					element._0023_003Dz50rnh9I_003D(0, 2),
					i,
					0
				});
			}
			else if (element is Quad4)
			{
				list.Add(new int[6]
				{
					element._0023_003Dz50rnh9I_003D(0, 0),
					element._0023_003Dz50rnh9I_003D(0, 1),
					element._0023_003Dz50rnh9I_003D(0, 2),
					element._0023_003Dz50rnh9I_003D(0, 3),
					i,
					0
				});
			}
			else if (element is Tria6)
			{
				list.Add(new int[5]
				{
					element._0023_003Dz50rnh9I_003D(0, 0),
					element._0023_003Dz50rnh9I_003D(0, 2),
					element._0023_003Dz50rnh9I_003D(0, 4),
					i,
					0
				});
			}
			else if (element is Quad8)
			{
				list.Add(new int[6]
				{
					element._0023_003Dz50rnh9I_003D(0, 0),
					element._0023_003Dz50rnh9I_003D(0, 2),
					element._0023_003Dz50rnh9I_003D(0, 4),
					element._0023_003Dz50rnh9I_003D(0, 6),
					i,
					0
				});
			}
			if (element is Tetra4)
			{
				for (byte b = 0; b < 4; b++)
				{
					list.Add(new int[5]
					{
						element._0023_003Dz50rnh9I_003D(b, 0),
						element._0023_003Dz50rnh9I_003D(b, 1),
						element._0023_003Dz50rnh9I_003D(b, 2),
						i,
						b
					});
				}
			}
			else if (element is Tetra10)
			{
				for (byte b2 = 0; b2 < 4; b2++)
				{
					list.Add(new int[5]
					{
						element._0023_003Dz50rnh9I_003D(b2, 0),
						element._0023_003Dz50rnh9I_003D(b2, 2),
						element._0023_003Dz50rnh9I_003D(b2, 4),
						i,
						b2
					});
				}
			}
			else if (element is Penta6)
			{
				list.Add(new int[5]
				{
					element._0023_003Dz50rnh9I_003D(0, 0),
					element._0023_003Dz50rnh9I_003D(0, 1),
					element._0023_003Dz50rnh9I_003D(0, 2),
					i,
					0
				});
				for (byte b3 = 1; b3 < 4; b3++)
				{
					list.Add(new int[6]
					{
						element._0023_003Dz50rnh9I_003D(b3, 0),
						element._0023_003Dz50rnh9I_003D(b3, 1),
						element._0023_003Dz50rnh9I_003D(b3, 2),
						element._0023_003Dz50rnh9I_003D(b3, 3),
						i,
						b3
					});
				}
				list.Add(new int[5]
				{
					element._0023_003Dz50rnh9I_003D(4, 0),
					element._0023_003Dz50rnh9I_003D(4, 1),
					element._0023_003Dz50rnh9I_003D(4, 2),
					i,
					4
				});
			}
			else if (element is Penta15)
			{
				list.Add(new int[5]
				{
					element._0023_003Dz50rnh9I_003D(0, 0),
					element._0023_003Dz50rnh9I_003D(0, 2),
					element._0023_003Dz50rnh9I_003D(0, 4),
					i,
					0
				});
				for (byte b4 = 1; b4 < 4; b4++)
				{
					list.Add(new int[6]
					{
						element._0023_003Dz50rnh9I_003D(b4, 0),
						element._0023_003Dz50rnh9I_003D(b4, 2),
						element._0023_003Dz50rnh9I_003D(b4, 4),
						element._0023_003Dz50rnh9I_003D(b4, 6),
						i,
						b4
					});
				}
				list.Add(new int[5]
				{
					element._0023_003Dz50rnh9I_003D(4, 0),
					element._0023_003Dz50rnh9I_003D(4, 2),
					element._0023_003Dz50rnh9I_003D(4, 4),
					i,
					4
				});
			}
			else if (element is Hexa8)
			{
				for (byte b5 = 0; b5 < 6; b5++)
				{
					list.Add(new int[6]
					{
						element._0023_003Dz50rnh9I_003D(b5, 0),
						element._0023_003Dz50rnh9I_003D(b5, 1),
						element._0023_003Dz50rnh9I_003D(b5, 2),
						element._0023_003Dz50rnh9I_003D(b5, 3),
						i,
						b5
					});
				}
			}
			else if (element is Hexa20)
			{
				for (byte b6 = 0; b6 < 6; b6++)
				{
					list.Add(new int[6]
					{
						element._0023_003Dz50rnh9I_003D(b6, 0),
						element._0023_003Dz50rnh9I_003D(b6, 2),
						element._0023_003Dz50rnh9I_003D(b6, 4),
						element._0023_003Dz50rnh9I_003D(b6, 6),
						i,
						b6
					});
				}
			}
		}
		LinkedList<SharedFace>[] facesPerVertex;
		int[][] skinFaces = Utility.GetSkinFaces(list.ToArray(), _vertices.Length, out facesPerVertex);
		Mesh mesh = new Mesh(_vertices.Length, skinFaces.Length, Mesh.natureType.Smooth);
		mesh.Vertices = _vertices;
		List<IndexTriangle> list2 = new List<IndexTriangle>();
		int[][] array = skinFaces;
		foreach (int[] array2 in array)
		{
			int num = array2.Length;
			int num2 = array2[num - 2];
			byte b7 = (byte)array2[num - 1];
			Element element2 = elements[num2];
			if (element2 is Truss2D || element2 is Truss || element2 is Beam2D || element2 is Beam || (ClippingPlane != null && _0023_003Dz0UFBJGrat4P3(element2) && flag))
			{
				continue;
			}
			element2.Faces[b7].Visible = true;
			element2.Faces[b7].ComputeCentroid(element2, _vertices);
			if (element2 is Tria3)
			{
				SmoothTriangle smoothTriangle = new SmoothTriangle(element2._0023_003Dz50rnh9I_003D(b7, 0), element2._0023_003Dz50rnh9I_003D(b7, 1), element2._0023_003Dz50rnh9I_003D(b7, 2));
				element2.Faces[b7].Triangles = new SmoothTriangle[1] { smoothTriangle };
				list2.Add(smoothTriangle);
			}
			else if (element2 is Tria6)
			{
				SmoothTriangle smoothTriangle2 = new SmoothTriangle(element2._0023_003Dz50rnh9I_003D(b7, 0), element2._0023_003Dz50rnh9I_003D(b7, 2), element2._0023_003Dz50rnh9I_003D(b7, 4));
				element2.Faces[b7].Triangles = new SmoothTriangle[1] { smoothTriangle2 };
				list2.Add(smoothTriangle2);
			}
			else if (element2 is Quad4)
			{
				element2.Faces[b7].Triangles = new SmoothTriangle[2];
				SmoothTriangle smoothTriangle3 = new SmoothTriangle(element2._0023_003Dz50rnh9I_003D(b7, 0), element2._0023_003Dz50rnh9I_003D(b7, 1), element2._0023_003Dz50rnh9I_003D(b7, 2));
				element2.Faces[b7].Triangles[0] = smoothTriangle3;
				list2.Add(smoothTriangle3);
				SmoothTriangle smoothTriangle4 = new SmoothTriangle(element2._0023_003Dz50rnh9I_003D(b7, 0), element2._0023_003Dz50rnh9I_003D(b7, 2), element2._0023_003Dz50rnh9I_003D(b7, 3));
				element2.Faces[b7].Triangles[1] = smoothTriangle4;
				list2.Add(smoothTriangle4);
			}
			else if (element2 is Quad8)
			{
				element2.Faces[b7].Triangles = new SmoothTriangle[2];
				SmoothTriangle smoothTriangle5 = new SmoothTriangle(element2._0023_003Dz50rnh9I_003D(b7, 0), element2._0023_003Dz50rnh9I_003D(b7, 2), element2._0023_003Dz50rnh9I_003D(b7, 4));
				element2.Faces[b7].Triangles[0] = smoothTriangle5;
				list2.Add(smoothTriangle5);
				SmoothTriangle smoothTriangle6 = new SmoothTriangle(element2._0023_003Dz50rnh9I_003D(b7, 0), element2._0023_003Dz50rnh9I_003D(b7, 4), element2._0023_003Dz50rnh9I_003D(b7, 6));
				element2.Faces[b7].Triangles[1] = smoothTriangle6;
				list2.Add(smoothTriangle6);
			}
			else if (element2 is Tetra4)
			{
				SmoothTriangle smoothTriangle7 = new SmoothTriangle(element2._0023_003Dz50rnh9I_003D(b7, 0), element2._0023_003Dz50rnh9I_003D(b7, 1), element2._0023_003Dz50rnh9I_003D(b7, 2));
				element2.Faces[b7].Triangles = new SmoothTriangle[1] { smoothTriangle7 };
				list2.Add(smoothTriangle7);
			}
			else if (element2 is Tetra10)
			{
				SmoothTriangle smoothTriangle8 = new SmoothTriangle(element2._0023_003Dz50rnh9I_003D(b7, 0), element2._0023_003Dz50rnh9I_003D(b7, 2), element2._0023_003Dz50rnh9I_003D(b7, 4));
				element2.Faces[b7].Triangles = new SmoothTriangle[1] { smoothTriangle8 };
				list2.Add(smoothTriangle8);
			}
			else if (element2 is Penta6)
			{
				if (b7 == 0 || b7 == 4)
				{
					SmoothTriangle smoothTriangle9 = new SmoothTriangle(element2._0023_003Dz50rnh9I_003D(b7, 0), element2._0023_003Dz50rnh9I_003D(b7, 1), element2._0023_003Dz50rnh9I_003D(b7, 2));
					element2.Faces[b7].Triangles = new SmoothTriangle[1] { smoothTriangle9 };
					list2.Add(smoothTriangle9);
				}
				else
				{
					element2.Faces[b7].Triangles = new SmoothTriangle[2];
					SmoothTriangle smoothTriangle10 = new SmoothTriangle(element2._0023_003Dz50rnh9I_003D(b7, 0), element2._0023_003Dz50rnh9I_003D(b7, 1), element2._0023_003Dz50rnh9I_003D(b7, 2));
					element2.Faces[b7].Triangles[0] = smoothTriangle10;
					list2.Add(smoothTriangle10);
					SmoothTriangle smoothTriangle11 = new SmoothTriangle(element2._0023_003Dz50rnh9I_003D(b7, 0), element2._0023_003Dz50rnh9I_003D(b7, 2), element2._0023_003Dz50rnh9I_003D(b7, 3));
					element2.Faces[b7].Triangles[1] = smoothTriangle11;
					list2.Add(smoothTriangle11);
				}
			}
			else if (element2 is Penta15)
			{
				if (b7 == 0 || b7 == 4)
				{
					SmoothTriangle smoothTriangle12 = new SmoothTriangle(element2._0023_003Dz50rnh9I_003D(b7, 0), element2._0023_003Dz50rnh9I_003D(b7, 2), element2._0023_003Dz50rnh9I_003D(b7, 4));
					element2.Faces[b7].Triangles = new SmoothTriangle[1] { smoothTriangle12 };
					list2.Add(smoothTriangle12);
				}
				else
				{
					element2.Faces[b7].Triangles = new SmoothTriangle[2];
					SmoothTriangle smoothTriangle13 = new SmoothTriangle(element2._0023_003Dz50rnh9I_003D(b7, 0), element2._0023_003Dz50rnh9I_003D(b7, 2), element2._0023_003Dz50rnh9I_003D(b7, 4));
					element2.Faces[b7].Triangles[0] = smoothTriangle13;
					list2.Add(smoothTriangle13);
					SmoothTriangle smoothTriangle14 = new SmoothTriangle(element2._0023_003Dz50rnh9I_003D(b7, 0), element2._0023_003Dz50rnh9I_003D(b7, 4), element2._0023_003Dz50rnh9I_003D(b7, 6));
					element2.Faces[b7].Triangles[1] = smoothTriangle14;
					list2.Add(smoothTriangle14);
				}
			}
			else if (element2 is Hexa8)
			{
				element2.Faces[b7].Triangles = new SmoothTriangle[2];
				SmoothTriangle smoothTriangle15 = new SmoothTriangle(element2._0023_003Dz50rnh9I_003D(b7, 0), element2._0023_003Dz50rnh9I_003D(b7, 1), element2._0023_003Dz50rnh9I_003D(b7, 2));
				element2.Faces[b7].Triangles[0] = smoothTriangle15;
				list2.Add(smoothTriangle15);
				SmoothTriangle smoothTriangle16 = new SmoothTriangle(element2._0023_003Dz50rnh9I_003D(b7, 0), element2._0023_003Dz50rnh9I_003D(b7, 2), element2._0023_003Dz50rnh9I_003D(b7, 3));
				element2.Faces[b7].Triangles[1] = smoothTriangle16;
				list2.Add(smoothTriangle16);
			}
			else if (element2 is Hexa20)
			{
				element2.Faces[b7].Triangles = new SmoothTriangle[2];
				SmoothTriangle smoothTriangle17 = new SmoothTriangle(element2._0023_003Dz50rnh9I_003D(b7, 0), element2._0023_003Dz50rnh9I_003D(b7, 2), element2._0023_003Dz50rnh9I_003D(b7, 4));
				element2.Faces[b7].Triangles[0] = smoothTriangle17;
				list2.Add(smoothTriangle17);
				SmoothTriangle smoothTriangle18 = new SmoothTriangle(element2._0023_003Dz50rnh9I_003D(b7, 0), element2._0023_003Dz50rnh9I_003D(b7, 4), element2._0023_003Dz50rnh9I_003D(b7, 6));
				element2.Faces[b7].Triangles[1] = smoothTriangle18;
				list2.Add(smoothTriangle18);
			}
		}
		mesh.Triangles = list2.ToArray();
		mesh.UpdateNormals();
		for (int k = 0; k < skinFaces.Length; k++)
		{
			int[] array3 = skinFaces[k];
			int num3 = array3.Length;
			int num4 = array3[num3 - 2];
			byte b8 = (byte)array3[num3 - 1];
			Element element3 = elements[num4];
			if (element3 is Truss2D || element3 is Truss || element3 is Beam2D || element3 is Beam || (ClippingPlane != null && _0023_003Dz0UFBJGrat4P3(element3) && flag))
			{
				continue;
			}
			if (element3 is Tria3 || element3 is Tria6)
			{
				IndexTriangle[] triangles = mesh.Triangles;
				for (int j = 0; j < triangles.Length; j++)
				{
					SmoothTriangle smoothTriangle19 = (SmoothTriangle)triangles[j];
					if ((smoothTriangle19.V1 == element3.Connection[0] && smoothTriangle19.V2 == element3.Connection[1] && smoothTriangle19.V3 == element3.Connection[2]) || (element3.Connection.Length > 3 && smoothTriangle19.V1 == element3.Connection[0] && smoothTriangle19.V2 == element3.Connection[2] && smoothTriangle19.V3 == element3.Connection[4]))
					{
						element3.Faces[b8].CornerNormals = new Vector3D[3]
						{
							mesh.Normals[smoothTriangle19.N1],
							mesh.Normals[smoothTriangle19.N2],
							mesh.Normals[smoothTriangle19.N3]
						};
						break;
					}
				}
			}
			else if (element3 is Tetra4 || element3 is Tetra10)
			{
				SmoothTriangle smoothTriangle20 = (SmoothTriangle)mesh.Triangles[k];
				element3.Faces[b8].CornerNormals = new Vector3D[3]
				{
					mesh.Normals[smoothTriangle20.N1],
					mesh.Normals[smoothTriangle20.N2],
					mesh.Normals[smoothTriangle20.N3]
				};
			}
			else if (element3 is Penta6 || element3 is Penta15)
			{
				if (b8 == 0 || b8 == 4)
				{
					SmoothTriangle smoothTriangle21 = element3.Faces[b8].Triangles[0];
					element3.Faces[b8].CornerNormals = new Vector3D[3]
					{
						mesh.Normals[smoothTriangle21.N1],
						mesh.Normals[smoothTriangle21.N2],
						mesh.Normals[smoothTriangle21.N3]
					};
				}
				else
				{
					SmoothTriangle smoothTriangle22 = element3.Faces[b8].Triangles[0];
					SmoothTriangle smoothTriangle23 = element3.Faces[b8].Triangles[1];
					element3.Faces[b8].CornerNormals = new Vector3D[4]
					{
						mesh.Normals[smoothTriangle22.N1],
						mesh.Normals[smoothTriangle22.N2],
						mesh.Normals[smoothTriangle22.N3],
						mesh.Normals[smoothTriangle23.N3]
					};
				}
			}
			else if (element3 is Quad4 || element3 is Quad8 || element3 is Hexa8 || element3 is Hexa20)
			{
				SmoothTriangle smoothTriangle24 = element3.Faces[b8].Triangles[0];
				SmoothTriangle smoothTriangle25 = element3.Faces[b8].Triangles[1];
				element3.Faces[b8].CornerNormals = new Vector3D[4]
				{
					mesh.Normals[smoothTriangle24.N1],
					mesh.Normals[smoothTriangle24.N2],
					mesh.Normals[smoothTriangle24.N3],
					mesh.Normals[smoothTriangle25.N3]
				};
			}
		}
		list.Clear();
		Element[] array4 = elements;
		foreach (Element element4 in array4)
		{
			if (element4 is Joint2D)
			{
				continue;
			}
			Element element5 = element4;
			if (ClippingPlane != null && _0023_003Dz0UFBJGrat4P3(element5) && flag)
			{
				continue;
			}
			if (element5 is Tria3)
			{
				list.Add(new int[3]
				{
					element5._0023_003Dz50rnh9I_003D(0, 0),
					element5._0023_003Dz50rnh9I_003D(0, 1),
					element5._0023_003Dz50rnh9I_003D(0, 2)
				});
			}
			else if (element5 is Tria6)
			{
				list.Add(new int[6]
				{
					element5._0023_003Dz50rnh9I_003D(0, 0),
					element5._0023_003Dz50rnh9I_003D(0, 1),
					element5._0023_003Dz50rnh9I_003D(0, 2),
					element5._0023_003Dz50rnh9I_003D(0, 3),
					element5._0023_003Dz50rnh9I_003D(0, 4),
					element5._0023_003Dz50rnh9I_003D(0, 5)
				});
			}
			else if (element5 is Quad4)
			{
				list.Add(new int[4]
				{
					element5._0023_003Dz50rnh9I_003D(0, 0),
					element5._0023_003Dz50rnh9I_003D(0, 1),
					element5._0023_003Dz50rnh9I_003D(0, 2),
					element5._0023_003Dz50rnh9I_003D(0, 3)
				});
			}
			else if (element5 is Quad8)
			{
				list.Add(new int[8]
				{
					element5._0023_003Dz50rnh9I_003D(0, 0),
					element5._0023_003Dz50rnh9I_003D(0, 1),
					element5._0023_003Dz50rnh9I_003D(0, 2),
					element5._0023_003Dz50rnh9I_003D(0, 3),
					element5._0023_003Dz50rnh9I_003D(0, 4),
					element5._0023_003Dz50rnh9I_003D(0, 5),
					element5._0023_003Dz50rnh9I_003D(0, 6),
					element5._0023_003Dz50rnh9I_003D(0, 7)
				});
			}
			else if (element5 is Tetra4)
			{
				for (byte b9 = 0; b9 < 4; b9++)
				{
					list.Add(new int[3]
					{
						element5._0023_003Dz50rnh9I_003D(b9, 0),
						element5._0023_003Dz50rnh9I_003D(b9, 1),
						element5._0023_003Dz50rnh9I_003D(b9, 2)
					});
				}
			}
			else if (element5 is Tetra10)
			{
				for (byte b10 = 0; b10 < 4; b10++)
				{
					list.Add(new int[6]
					{
						element5._0023_003Dz50rnh9I_003D(b10, 0),
						element5._0023_003Dz50rnh9I_003D(b10, 1),
						element5._0023_003Dz50rnh9I_003D(b10, 2),
						element5._0023_003Dz50rnh9I_003D(b10, 3),
						element5._0023_003Dz50rnh9I_003D(b10, 4),
						element5._0023_003Dz50rnh9I_003D(b10, 5)
					});
				}
			}
			else if (element5 is Penta6)
			{
				list.Add(new int[3]
				{
					element5._0023_003Dz50rnh9I_003D(0, 0),
					element5._0023_003Dz50rnh9I_003D(0, 1),
					element5._0023_003Dz50rnh9I_003D(0, 2)
				});
				for (byte b11 = 1; b11 < 4; b11++)
				{
					list.Add(new int[4]
					{
						element5._0023_003Dz50rnh9I_003D(b11, 0),
						element5._0023_003Dz50rnh9I_003D(b11, 1),
						element5._0023_003Dz50rnh9I_003D(b11, 2),
						element5._0023_003Dz50rnh9I_003D(b11, 3)
					});
				}
				list.Add(new int[3]
				{
					element5._0023_003Dz50rnh9I_003D(4, 0),
					element5._0023_003Dz50rnh9I_003D(4, 1),
					element5._0023_003Dz50rnh9I_003D(4, 2)
				});
			}
			else if (element5 is Penta15)
			{
				list.Add(new int[6]
				{
					element5._0023_003Dz50rnh9I_003D(0, 0),
					element5._0023_003Dz50rnh9I_003D(0, 1),
					element5._0023_003Dz50rnh9I_003D(0, 2),
					element5._0023_003Dz50rnh9I_003D(0, 3),
					element5._0023_003Dz50rnh9I_003D(0, 4),
					element5._0023_003Dz50rnh9I_003D(0, 5)
				});
				for (byte b12 = 1; b12 < 4; b12++)
				{
					list.Add(new int[8]
					{
						element5._0023_003Dz50rnh9I_003D(b12, 0),
						element5._0023_003Dz50rnh9I_003D(b12, 1),
						element5._0023_003Dz50rnh9I_003D(b12, 2),
						element5._0023_003Dz50rnh9I_003D(b12, 3),
						element5._0023_003Dz50rnh9I_003D(b12, 4),
						element5._0023_003Dz50rnh9I_003D(b12, 5),
						element5._0023_003Dz50rnh9I_003D(b12, 6),
						element5._0023_003Dz50rnh9I_003D(b12, 7)
					});
				}
				list.Add(new int[6]
				{
					element5._0023_003Dz50rnh9I_003D(4, 0),
					element5._0023_003Dz50rnh9I_003D(4, 1),
					element5._0023_003Dz50rnh9I_003D(4, 2),
					element5._0023_003Dz50rnh9I_003D(4, 3),
					element5._0023_003Dz50rnh9I_003D(4, 4),
					element5._0023_003Dz50rnh9I_003D(4, 5)
				});
			}
			else if (element5 is Hexa8)
			{
				for (byte b13 = 0; b13 < 6; b13++)
				{
					list.Add(new int[4]
					{
						element5._0023_003Dz50rnh9I_003D(b13, 0),
						element5._0023_003Dz50rnh9I_003D(b13, 1),
						element5._0023_003Dz50rnh9I_003D(b13, 2),
						element5._0023_003Dz50rnh9I_003D(b13, 3)
					});
				}
			}
			else if (element5 is Hexa20)
			{
				for (byte b14 = 0; b14 < 6; b14++)
				{
					list.Add(new int[8]
					{
						element5._0023_003Dz50rnh9I_003D(b14, 0),
						element5._0023_003Dz50rnh9I_003D(b14, 1),
						element5._0023_003Dz50rnh9I_003D(b14, 2),
						element5._0023_003Dz50rnh9I_003D(b14, 3),
						element5._0023_003Dz50rnh9I_003D(b14, 4),
						element5._0023_003Dz50rnh9I_003D(b14, 5),
						element5._0023_003Dz50rnh9I_003D(b14, 6),
						element5._0023_003Dz50rnh9I_003D(b14, 7)
					});
				}
			}
		}
		if (list.Count > 0)
		{
			isoEdges = Utility.GetEdgesWithoutDuplicates(list.ToArray(), _vertices.Length, out var _);
			_0023_003Dz37SpqHylDgPQodlpFQ_003D_003D(out var _0023_003Dz_0024l3htGIWl48n, out var _0023_003DzQBMUUF5hX6Y_0024);
			if (skin != null)
			{
				_0023_003Dz9ctHTXjAW5QC(skin);
			}
			skin = new Mesh(_0023_003Dz_0024l3htGIWl48n, _0023_003DzQBMUUF5hX6Y_0024);
			skin.Edges = _0023_003DzLfUvlgjC8bTq();
		}
		base.Regen(data);
		if (!flag)
		{
			if (ClippingPlane != null)
			{
				_0023_003DzRZsNU9uHQp3MDRUD_0024A_003D_003D(null);
			}
			else
			{
				_0023_003Dz2590AGndWcVccsIaNg_003D_003D();
			}
		}
		if (IsBeamStudy)
		{
			array4 = elements;
			foreach (Element _0023_003Dzx63Fsgc_003D in array4)
			{
				_0023_003Dz0O3lrHddCoqsbDjWiCCMBuo_003D(_0023_003Dzx63Fsgc_003D, data.Deviation);
			}
		}
	}

	private void _0023_003Dz2590AGndWcVccsIaNg_003D_003D()
	{
		foreach (Mesh elementsSlice in _elementsSlices)
		{
			elementsSlice.Dispose();
		}
		_elementsSlices.Clear();
	}

	private void _0023_003Dz0O3lrHddCoqsbDjWiCCMBuo_003D(Element _0023_003Dzx63Fsgc_003D, double _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D)
	{
		if (_0023_003Dzx63Fsgc_003D is Beam || _0023_003Dzx63Fsgc_003D is Beam2D)
		{
			double _0023_003DzELnUZQyM6IsC;
			Vector3D _0023_003Dz_eY3Y4c_003D;
			Vector3D _0023_003DzAvn2b38_003D;
			Node no;
			Vector3D _0023_003Dz77g161c_003D;
			if (_0023_003Dzx63Fsgc_003D is Beam)
			{
				Beam beam = (Beam)_0023_003Dzx63Fsgc_003D;
				beam._0023_003Dz_Pv10jaRctc_0024nexujUC_0024laXwGnjU(_vertices, out _0023_003DzELnUZQyM6IsC, out var _, out _0023_003Dz_eY3Y4c_003D, out _0023_003DzAvn2b38_003D);
				no = (Node)_vertices[beam.Connection[0]];
				_0023_003Dz77g161c_003D = beam.v;
			}
			else
			{
				Beam2D beam2D = (Beam2D)_0023_003Dzx63Fsgc_003D;
				beam2D._0023_003Dz9N71tA5ZWS90YBI87g_003D_003D(_vertices, out _0023_003Dz_eY3Y4c_003D, out _0023_003Dz77g161c_003D, out _0023_003DzAvn2b38_003D, out _0023_003DzELnUZQyM6IsC);
				no = (Node)_vertices[beam2D.Connection[0]];
			}
			((MaterialBeam)_0023_003Dzx63Fsgc_003D.Material).ComputeBeamVertices(_0023_003Dzx63Fsgc_003D, _0023_003Dz77g161c_003D, _0023_003DzAvn2b38_003D, no, _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D);
		}
	}

	internal IndexLine[] _0023_003DzLfUvlgjC8bTq()
	{
		if (skin.sharedEdges == null)
		{
			skin._0023_003Dz_0024YeSaS1uGUxB(_0023_003DzEkR_P10_003D: true);
		}
		_0023_003DzdyubMA3Q6tQG();
		int[,] sharedEdges = skin.sharedEdges;
		List<IndexLine> list = new List<IndexLine>(sharedEdges.GetLength(0));
		double num = Math.Cos(skin.SmoothingAngle);
		Vector3D[] array = Mesh._0023_003Dz9PT4tNs9owGLO14COg_003D_003D(skin.Vertices, skin.Triangles);
		for (int i = 0; i < sharedEdges.GetLength(0); i++)
		{
			int num2 = sharedEdges[i, 3];
			if (num2 == -1)
			{
				list.Add(new IndexLine(sharedEdges[i, 0], sharedEdges[i, 1]));
				continue;
			}
			int num3 = sharedEdges[i, 2];
			_0023_003DzdbCY_Ol_2RiGerZYwGcKL3V5U09dFmFFez1WZYE_003D _0023_003DzdbCY_Ol_2RiGerZYwGcKL3V5U09dFmFFez1WZYE_003D2 = (_0023_003DzdbCY_Ol_2RiGerZYwGcKL3V5U09dFmFFez1WZYE_003D)skin.Triangles[num3];
			_0023_003DzdbCY_Ol_2RiGerZYwGcKL3V5U09dFmFFez1WZYE_003D _0023_003DzdbCY_Ol_2RiGerZYwGcKL3V5U09dFmFFez1WZYE_003D3 = (_0023_003DzdbCY_Ol_2RiGerZYwGcKL3V5U09dFmFFez1WZYE_003D)skin.Triangles[num2];
			bool flag = elements[_0023_003DzdbCY_Ol_2RiGerZYwGcKL3V5U09dFmFFez1WZYE_003D2._0023_003DzZpBiVcbHFG6Q()].Material.Equals(elements[_0023_003DzdbCY_Ol_2RiGerZYwGcKL3V5U09dFmFFez1WZYE_003D3._0023_003DzZpBiVcbHFG6Q()].Material);
			if (array[num3] * array[num2] <= num || !flag)
			{
				list.Add(new IndexLine(sharedEdges[i, 0], sharedEdges[i, 1]));
			}
		}
		return list.ToArray();
	}

	internal void _0023_003DzdyubMA3Q6tQG()
	{
		double num = double.MaxValue;
		int length = skin.sharedEdges.GetLength(0);
		for (int i = 0; i < length; i++)
		{
			double num2 = Point3D.DistanceSquared(skin.Vertices[skin.sharedEdges[i, 0]], skin.Vertices[skin.sharedEdges[i, 1]]);
			if (num2 < num)
			{
				num = num2;
			}
		}
		minEdgeLen = Math.Sqrt(num);
	}

	private bool _0023_003Dz0UFBJGrat4P3(Element _0023_003Dzx63Fsgc_003D)
	{
		int[] connection = _0023_003Dzx63Fsgc_003D.Connection;
		foreach (int num in connection)
		{
			if (ClippingPlane.DistanceTo(_vertices[num]) > 0.0)
			{
				return true;
			}
		}
		return false;
	}

	internal void _0023_003Dz37SpqHylDgPQodlpFQ_003D_003D(out Point3D[] _0023_003Dz_0024l3htGIWl48n, out List<IndexTriangle> _0023_003DzQBMUUF5hX6Y_0024)
	{
		_0023_003DzQBMUUF5hX6Y_0024 = new List<IndexTriangle>(elements.Length);
		List<Point3D> list = new List<Point3D>(elements.Length);
		for (int i = 0; i < elements.Length; i++)
		{
			Element element = elements[i];
			if (!(element is Joint2D))
			{
				_0023_003DzQBMUUF5hX6Y_0024.AddRange(element.GetTriangles(i, _vertices, _ampFactor, list));
			}
		}
		_0023_003Dz_0024l3htGIWl48n = new Point3D[_vertices.Length + list.Count];
		_vertices.CopyTo(_0023_003Dz_0024l3htGIWl48n, 0);
		list.CopyTo(0, _0023_003Dz_0024l3htGIWl48n, _vertices.Length, list.Count);
		if (list.Count > 0)
		{
			foreach (IndexTriangle item in _0023_003DzQBMUUF5hX6Y_0024)
			{
				if (item.V3 < 0)
				{
					item.V3 = -item.V3 - 1 + _vertices.Length;
				}
			}
		}
		boundaryNodes = new int[_vertices.Length + list.Count];
		foreach (IndexTriangle item2 in _0023_003DzQBMUUF5hX6Y_0024)
		{
			boundaryNodes[item2.V1]++;
			boundaryNodes[item2.V2]++;
			boundaryNodes[item2.V3]++;
		}
	}

	public IList<HitTriangle> FindClosestTriangle(Transformation transf, Segment3D seg)
	{
		SortedList<double, HitTriangle> sortedList = new SortedList<double, HitTriangle>();
		for (int i = 0; i < elements.Length; i++)
		{
			Element element = elements[i];
			for (int j = 0; j < element.Faces.Length; j++)
			{
				Element.Face face = element.Faces[j];
				if (!face.Visible)
				{
					continue;
				}
				for (int k = 0; k < face.Triangles.Length; k++)
				{
					IndexTriangle indexTriangle = face.Triangles[k];
					if (transf == null || transf.IsIdentity())
					{
						Point3D p = _vertices[indexTriangle.V1];
						Point3D p2 = _vertices[indexTriangle.V2];
						Point3D p3 = _vertices[indexTriangle.V3];
						if (seg.IntersectWith(p, p2, p3, out var intPoint))
						{
							try
							{
								sortedList.Add(Point3D.Distance(intPoint, seg.P0), new HitTriangle(intPoint, k, j, i));
							}
							catch (ArgumentException)
							{
							}
						}
						continue;
					}
					Point3D p4 = transf * _vertices[indexTriangle.V1];
					Point3D p5 = transf * _vertices[indexTriangle.V2];
					Point3D p6 = transf * _vertices[indexTriangle.V3];
					if (seg.IntersectWith(p4, p5, p6, out var intPoint2))
					{
						try
						{
							sortedList.Add(Point3D.Distance(intPoint2, seg.P0), new HitTriangle(intPoint2, k, j, i));
						}
						catch (ArgumentException)
						{
						}
					}
				}
			}
		}
		return sortedList.Values;
	}

	public ICurve[] Section(Plane pln, double tol)
	{
		return skin.Section(pln, tol);
	}

	public int[] GetNodesByFace(int index, Brep brep)
	{
		brep.Rebuild(0.0, soft: true);
		Brep.Face face = brep.Faces[index];
		HashSet<int> hashSet = new HashSet<int>(skin.Vertices.Length);
		double num = minEdgeLen / 10.0;
		for (int i = 0; i < _vertices.Length; i++)
		{
			if (boundaryNodes[i] == 0)
			{
				continue;
			}
			Point3D point3D = skin.Vertices[i];
			Surface[] parametric = face.Parametric;
			foreach (Surface surface in parametric)
			{
				if (surface.Project(point3D, num, false, out double u, out double v) && Point3D.DistanceSquared(surface.PointAt(u, v), point3D) < num * num && ((surface._0023_003DzMiVPRBIpFOpe() != null && surface._0023_003DzMiVPRBIpFOpe().IsPointInside(new Point2D(u, v))) || surface.Trimming.IsPointInside(new Point2D(u, v))))
				{
					hashSet.Add(i);
				}
			}
			Brep.Loop[] loops = face.Loops;
			for (int j = 0; j < loops.Length; j++)
			{
				Brep.OrientedEdge[] segments = loops[j].Segments;
				for (int k = 0; k < segments.Length; k++)
				{
					Brep.OrientedEdge orientedEdge = segments[k];
					Brep.Edge edge = brep.Edges[orientedEdge.CurveIndex];
					if (edge.Curve.Project(point3D, out var t))
					{
						Point3D a = edge.Curve.PointAt(t);
						if (edge.Curve.Domain.Includes(t, testOpenInterval: false) && Point3D.DistanceSquared(a, point3D) < num * num)
						{
							hashSet.Add(i);
						}
					}
				}
			}
		}
		return hashSet.ToArray();
	}

	public int[] GetNodesByEdge(int index, Brep brep)
	{
		brep.Rebuild(0.0, soft: true);
		List<int> list = new List<int>(skin.Vertices.Length);
		double num = minEdgeLen / 10.0;
		for (int i = 0; i < _vertices.Length; i++)
		{
			Point3D point3D = skin.Vertices[i];
			Brep.Edge edge = brep.Edges[index];
			if (edge.Curve.Project(point3D, out var t))
			{
				Point3D a = edge.Curve.PointAt(t);
				if (edge.Curve.Domain.Includes(t, testOpenInterval: false) && Point3D.DistanceSquared(a, point3D) < num * num)
				{
					list.Add(i);
				}
			}
		}
		return list.ToArray();
	}

	public int[] GetNodesByVertex(int index, Brep brep)
	{
		brep.Rebuild(0.0, soft: true);
		List<int> list = new List<int>(skin.Vertices.Length);
		double num = minEdgeLen / 10.0;
		for (int i = 0; i < _vertices.Length; i++)
		{
			Point3D b = skin.Vertices[i];
			if (Point3D.DistanceSquared((Brep.Vertex)brep.Vertices[index], b) < num * num)
			{
				list.Add(i);
			}
		}
		return list.ToArray();
	}

	public void ComputePlot(IWorkspace simulation, ILegend theLegend, bool postProcessingOnly)
	{
		if (postProcessingOnly)
		{
			solved = true;
		}
		ComputePlot(simulation, theLegend);
	}

	public void ComputePlot(IWorkspace simulation, ILegend legend, int mode = 0)
	{
		_modeIndex = mode;
		ResetAnimation();
		isDirtyForFlattenTree = true;
		if ((!IsBeamStudy && !(Vertices[0] is NodeBeam) && (plotMode == plotType.Rx || plotMode == plotType.Ry || plotMode == plotType.Rz || plotMode == plotType.AxialForce || plotMode == plotType.BeamBendingMomentV || plotMode == plotType.BeamBendingMomentW || plotMode == plotType.TwistAngle || plotMode == plotType.TorsionMoment || plotMode == plotType.ShearForceV || plotMode == plotType.ShearForceW)) || (IsBeamStudy && (plotMode == plotType.P1 || plotMode == plotType.P2 || plotMode == plotType.P3 || plotMode == plotType.Sx || plotMode == plotType.Sy || plotMode == plotType.Sz || plotMode == plotType.Txy || plotMode == plotType.Txz || plotMode == plotType.Tyz || plotMode == plotType.VonMises || plotMode == plotType.Tresca)) || (IsBeam2DStudy && (plotMode == plotType.Rx || plotMode == plotType.Ry || plotMode == plotType.BeamBendingMomentV || plotMode == plotType.TwistAngle || plotMode == plotType.TorsionMoment || plotMode == plotType.ShearForceW)))
		{
			return;
		}
		if (ClippingPlane != null)
		{
			if ((_prevMethod != ClippingMethod || _prevPlane != ClippingPlane) && ClippingMethod == clippingMethodType.ByElement)
			{
				Regen(0.0);
			}
			UpdateBoundingBox(null);
		}
		minValue = double.MaxValue;
		maxValue = double.MinValue;
		switch (plotMode)
		{
		case plotType.Ux:
		{
			for (int num36 = 0; num36 < _vertices.Length; num36++)
			{
				Node node7 = (Node)_vertices[num36];
				_0023_003DzSD2VGcFsye5d(node7.Unknowns[mode][0], num36);
			}
			if (IsBeamStudy)
			{
				if (IsBeam2DStudy)
				{
					for (int num37 = 0; num37 < elements.Length; num37++)
					{
						Beam2D _0023_003Dz88Es_0024d16WeJr2 = (Beam2D)elements[num37];
						_0023_003DzMtTmuFaMSNrq20IuN3wt6W_0024zp2ic(_0023_003Dz88Es_0024d16WeJr2);
					}
				}
				else
				{
					for (int num38 = 0; num38 < elements.Length; num38++)
					{
						Beam _0023_003Dzol5oTDIn1k8K2 = (Beam)elements[num38];
						_0023_003DzIMfwKDW6RVB7Cvl0YIgNbYirSNqw(_0023_003Dzol5oTDIn1k8K2);
					}
				}
			}
			_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969786), ref minValue, ref maxValue);
			Point3D[] vertices = _vertices;
			for (int i = 0; i < vertices.Length; i++)
			{
				Node obj7 = (Node)vertices[i];
				obj7._0023_003DzefHtJcxwG1M2((float)obj7.Unknowns[mode][0]);
			}
			_0023_003DzxO9qSfXUosQy_0024ALvucLaCCw_003D(plotType.Ux);
			break;
		}
		case plotType.Uy:
		{
			for (int num14 = 0; num14 < _vertices.Length; num14++)
			{
				Node node3 = (Node)_vertices[num14];
				_0023_003DzSD2VGcFsye5d(node3.Unknowns[mode][1], num14);
			}
			if (IsBeamStudy)
			{
				if (IsBeam2DStudy)
				{
					for (int num15 = 0; num15 < elements.Length; num15++)
					{
						Beam2D _0023_003Dz88Es_0024d16WeJr = (Beam2D)elements[num15];
						_0023_003DzMtTmuFaMSNrq20IuN3wt6W_0024zp2ic(_0023_003Dz88Es_0024d16WeJr);
					}
				}
				else
				{
					for (int num16 = 0; num16 < elements.Length; num16++)
					{
						Beam _0023_003Dzol5oTDIn1k8K = (Beam)elements[num16];
						_0023_003DzIMfwKDW6RVB7Cvl0YIgNbYirSNqw(_0023_003Dzol5oTDIn1k8K);
					}
				}
			}
			_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969773), ref minValue, ref maxValue);
			Point3D[] vertices = _vertices;
			for (int i = 0; i < vertices.Length; i++)
			{
				Node obj3 = (Node)vertices[i];
				obj3._0023_003DzefHtJcxwG1M2((float)obj3.Unknowns[mode][1]);
			}
			_0023_003DzxO9qSfXUosQy_0024ALvucLaCCw_003D(plotType.Uy);
			break;
		}
		case plotType.Uz:
		{
			for (int num56 = 0; num56 < _vertices.Length; num56++)
			{
				Node node9 = (Node)_vertices[num56];
				_0023_003DzSD2VGcFsye5d(node9.Unknowns[mode][2], num56);
			}
			if (IsBeamStudy)
			{
				if (IsBeam2DStudy)
				{
					for (int num57 = 0; num57 < elements.Length; num57++)
					{
						Beam2D obj11 = (Beam2D)elements[num57];
						obj11._0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(new float[obj11.SubdivisionNumber]);
					}
				}
				else
				{
					for (int num58 = 0; num58 < elements.Length; num58++)
					{
						Beam _0023_003Dzol5oTDIn1k8K4 = (Beam)elements[num58];
						_0023_003DzIMfwKDW6RVB7Cvl0YIgNbYirSNqw(_0023_003Dzol5oTDIn1k8K4);
					}
				}
			}
			_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969732), ref minValue, ref maxValue);
			Point3D[] vertices = _vertices;
			for (int i = 0; i < vertices.Length; i++)
			{
				Node obj12 = (Node)vertices[i];
				obj12._0023_003DzefHtJcxwG1M2((float)obj12.Unknowns[mode][2]);
			}
			_0023_003DzxO9qSfXUosQy_0024ALvucLaCCw_003D(plotType.Uz);
			break;
		}
		case plotType.U:
		{
			for (int num47 = 0; num47 < _vertices.Length; num47++)
			{
				Node obj9 = (Node)_vertices[num47];
				double num48 = obj9.Unknowns[mode][0];
				double num49 = obj9.Unknowns[mode][1];
				double num50 = obj9.Unknowns[mode][2];
				double _0023_003Dzik60_0024SI_003D = num48 * num48 + num49 * num49 + num50 * num50;
				_0023_003DzSD2VGcFsye5d(_0023_003Dzik60_0024SI_003D, num47);
			}
			minValue = Math.Sqrt(minValue);
			maxValue = Math.Sqrt(maxValue);
			if (IsBeamStudy)
			{
				if (IsBeam2DStudy)
				{
					for (int num51 = 0; num51 < elements.Length; num51++)
					{
						Beam2D _0023_003Dz88Es_0024d16WeJr3 = (Beam2D)elements[num51];
						_0023_003DzMtTmuFaMSNrq20IuN3wt6W_0024zp2ic(_0023_003Dz88Es_0024d16WeJr3);
					}
				}
				else
				{
					for (int num52 = 0; num52 < elements.Length; num52++)
					{
						Beam _0023_003Dzol5oTDIn1k8K3 = (Beam)elements[num52];
						_0023_003DzIMfwKDW6RVB7Cvl0YIgNbYirSNqw(_0023_003Dzol5oTDIn1k8K3);
					}
				}
			}
			_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969463), ref minValue, ref maxValue);
			Point3D[] vertices = _vertices;
			for (int i = 0; i < vertices.Length; i++)
			{
				Node obj10 = (Node)vertices[i];
				double num53 = obj10.Unknowns[mode][0];
				double num54 = obj10.Unknowns[mode][1];
				double num55 = obj10.Unknowns[mode][2];
				obj10._0023_003DzefHtJcxwG1M2((float)Math.Sqrt(num53 * num53 + num54 * num54 + num55 * num55));
			}
			_0023_003DzxO9qSfXUosQy_0024ALvucLaCCw_003D(plotType.U);
			break;
		}
		case plotType.Rx:
			if (IsBeamStudy)
			{
				if (IsBeam2DStudy)
				{
					for (int num99 = 0; num99 < elements.Length; num99++)
					{
						Beam2D obj20 = (Beam2D)elements[num99];
						obj20._0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(new float[obj20.SubdivisionNumber]);
					}
					break;
				}
				Element[] array = elements;
				for (int i = 0; i < array.Length; i++)
				{
					Beam beam9 = (Beam)array[i];
					NodeBeam nodeBeam7 = (NodeBeam)_vertices[beam9.Connection[0]];
					NodeBeam nodeBeam8 = (NodeBeam)_vertices[beam9.Connection[1]];
					_0023_003DzSD2VGcFsye5d(nodeBeam7.Rx);
					_0023_003DzSD2VGcFsye5d(nodeBeam8.Rx);
					int subdivisionNumber11 = beam9.SubdivisionNumber;
					double num100 = (nodeBeam8.Rx - nodeBeam7.Rx) / (double)(subdivisionNumber11 - 1);
					beam9._0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(new float[subdivisionNumber11]);
					for (int num101 = 0; num101 < subdivisionNumber11; num101++)
					{
						beam9.PlotValues[num101] = (float)(nodeBeam7.Rx + num100 * (double)num101);
					}
				}
				_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969430), ref minValue, ref maxValue);
				_0023_003DzxO9qSfXUosQy_0024ALvucLaCCw_003D(plotType.Rx);
			}
			else
			{
				for (int num102 = 0; num102 < _vertices.Length; num102++)
				{
					NodeBeam nodeBeam9 = (NodeBeam)_vertices[num102];
					_0023_003DzSD2VGcFsye5d(nodeBeam9.Unknowns[mode][3], num102);
				}
				_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969430), ref minValue, ref maxValue);
				Point3D[] vertices = _vertices;
				for (int i = 0; i < vertices.Length; i++)
				{
					NodeBeam obj21 = (NodeBeam)vertices[i];
					obj21._0023_003DzefHtJcxwG1M2((float)obj21.Unknowns[mode][3]);
				}
			}
			break;
		case plotType.Ry:
			if (IsBeamStudy)
			{
				if (IsBeam2DStudy)
				{
					for (int num70 = 0; num70 < elements.Length; num70++)
					{
						Beam2D obj14 = (Beam2D)elements[num70];
						obj14._0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(new float[obj14.SubdivisionNumber]);
					}
					break;
				}
				Element[] array = elements;
				for (int i = 0; i < array.Length; i++)
				{
					Beam beam7 = (Beam)array[i];
					NodeBeam nodeBeam = (NodeBeam)_vertices[beam7.Connection[0]];
					NodeBeam nodeBeam2 = (NodeBeam)_vertices[beam7.Connection[1]];
					_0023_003DzSD2VGcFsye5d(nodeBeam.Ry);
					_0023_003DzSD2VGcFsye5d(nodeBeam2.Ry);
					int subdivisionNumber8 = beam7.SubdivisionNumber;
					double num71 = (nodeBeam2.Ry - nodeBeam.Ry) / (double)(subdivisionNumber8 - 1);
					beam7._0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(new float[subdivisionNumber8]);
					for (int num72 = 0; num72 < subdivisionNumber8; num72++)
					{
						beam7.PlotValues[num72] = (float)(nodeBeam.Ry + num71 * (double)num72);
					}
				}
				_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969413), ref minValue, ref maxValue);
				_0023_003DzxO9qSfXUosQy_0024ALvucLaCCw_003D(plotType.Ry);
			}
			else
			{
				for (int num73 = 0; num73 < _vertices.Length; num73++)
				{
					NodeBeam nodeBeam3 = (NodeBeam)_vertices[num73];
					_0023_003DzSD2VGcFsye5d(nodeBeam3.Unknowns[mode][4], num73);
				}
				_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969413), ref minValue, ref maxValue);
				Point3D[] vertices = _vertices;
				for (int i = 0; i < vertices.Length; i++)
				{
					NodeBeam obj15 = (NodeBeam)vertices[i];
					obj15._0023_003DzefHtJcxwG1M2((float)obj15.Unknowns[mode][4]);
				}
			}
			break;
		case plotType.Rz:
			if (IsBeamStudy)
			{
				Element[] array = elements;
				foreach (Element element28 in array)
				{
					NodeBeam nodeBeam4 = (NodeBeam)_vertices[element28.Connection[0]];
					NodeBeam nodeBeam5 = (NodeBeam)_vertices[element28.Connection[1]];
					_0023_003DzSD2VGcFsye5d(nodeBeam4.Rz);
					_0023_003DzSD2VGcFsye5d(nodeBeam5.Rz);
					int num95 = ((!IsBeam2DStudy) ? ((Beam)element28).SubdivisionNumber : ((Beam2D)element28).SubdivisionNumber);
					double num96 = (nodeBeam5.Rz - nodeBeam4.Rz) / (double)(num95 - 1);
					element28._0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(new float[num95]);
					for (int num97 = 0; num97 < num95; num97++)
					{
						element28.PlotValues[num97] = (float)(nodeBeam4.Rz + num96 * (double)num97);
					}
				}
				_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969400), ref minValue, ref maxValue);
				_0023_003DzxO9qSfXUosQy_0024ALvucLaCCw_003D(plotType.Rz);
			}
			else
			{
				for (int num98 = 0; num98 < _vertices.Length; num98++)
				{
					NodeBeam nodeBeam6 = (NodeBeam)_vertices[num98];
					_0023_003DzSD2VGcFsye5d(nodeBeam6.Unknowns[mode][5], num98);
				}
				_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969400), ref minValue, ref maxValue);
				Point3D[] vertices = _vertices;
				for (int i = 0; i < vertices.Length; i++)
				{
					NodeBeam obj19 = (NodeBeam)vertices[i];
					obj19._0023_003DzefHtJcxwG1M2((float)obj19.Unknowns[mode][5]);
				}
			}
			break;
		case plotType.Sx:
		{
			if (nodalAverages)
			{
				for (int num30 = 0; num30 < _vertices.Length; num30++)
				{
					Node node6 = (Node)_vertices[num30];
					_0023_003DzSD2VGcFsye5d(node6.Sx, num30);
				}
				_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969383), ref minValue, ref maxValue);
				Point3D[] vertices = _vertices;
				for (int i = 0; i < vertices.Length; i++)
				{
					Node obj6 = (Node)vertices[i];
					obj6._0023_003DzefHtJcxwG1M2((float)obj6.Sx);
				}
				_0023_003DzbhZ5iCYD51mVLiieTGxMri4_003D(_0023_003DzZPsw1geFKzdjHjOctA_003D_003D: true, plotType.Sx);
				break;
			}
			for (int num31 = 0; num31 < elements.Length; num31++)
			{
				Element element12 = elements[num31];
				if (!(element12 is Joint2D))
				{
					for (int num32 = 0; num32 < element12.NumberOfNodes; num32++)
					{
						_0023_003DzSD2VGcFsye5d(element12.Stress[num32, 0], element12, num32);
					}
				}
			}
			_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969345), ref minValue, ref maxValue);
			Element[] array = elements;
			foreach (Element element13 in array)
			{
				if (!(element13 is Joint2D))
				{
					element13._0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(new float[element13.NumberOfNodes]);
					for (int num33 = 0; num33 < element13.NumberOfNodes; num33++)
					{
						element13.PlotValues[num33] = (float)element13.Stress[num33, 0];
					}
				}
			}
			_0023_003DzbhZ5iCYD51mVLiieTGxMri4_003D(_0023_003DzZPsw1geFKzdjHjOctA_003D_003D: false, plotType.Sx);
			break;
		}
		case plotType.Sy:
		{
			if (nodalAverages)
			{
				for (int num66 = 0; num66 < _vertices.Length; num66++)
				{
					Node node10 = (Node)_vertices[num66];
					_0023_003DzSD2VGcFsye5d(node10.Sy, num66);
				}
				_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969586), ref minValue, ref maxValue);
				Point3D[] vertices = _vertices;
				for (int i = 0; i < vertices.Length; i++)
				{
					Node obj13 = (Node)vertices[i];
					obj13._0023_003DzefHtJcxwG1M2((float)obj13.Sy);
				}
				_0023_003DzbhZ5iCYD51mVLiieTGxMri4_003D(_0023_003DzZPsw1geFKzdjHjOctA_003D_003D: true, plotType.Sy);
				break;
			}
			for (int num67 = 0; num67 < elements.Length; num67++)
			{
				Element element19 = elements[num67];
				if (!(element19 is Joint2D))
				{
					for (int num68 = 0; num68 < element19.NumberOfNodes; num68++)
					{
						_0023_003DzSD2VGcFsye5d(element19.Stress[num68, 1], element19, num68);
					}
				}
			}
			_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969580), ref minValue, ref maxValue);
			Element[] array = elements;
			foreach (Element element20 in array)
			{
				if (!(element20 is Joint2D))
				{
					element20._0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(new float[element20.NumberOfNodes]);
					for (int num69 = 0; num69 < element20.NumberOfNodes; num69++)
					{
						element20.PlotValues[num69] = (float)element20.Stress[num69, 1];
					}
				}
			}
			_0023_003DzbhZ5iCYD51mVLiieTGxMri4_003D(_0023_003DzZPsw1geFKzdjHjOctA_003D_003D: false, plotType.Sy);
			break;
		}
		case plotType.Sz:
		{
			if (nodalAverages)
			{
				for (int num17 = 0; num17 < _vertices.Length; num17++)
				{
					Node node4 = (Node)_vertices[num17];
					_0023_003DzSD2VGcFsye5d(node4.Sz, num17);
				}
				_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969561), ref minValue, ref maxValue);
				Point3D[] vertices = _vertices;
				for (int i = 0; i < vertices.Length; i++)
				{
					Node obj4 = (Node)vertices[i];
					obj4._0023_003DzefHtJcxwG1M2((float)obj4.Sz);
				}
				_0023_003DzbhZ5iCYD51mVLiieTGxMri4_003D(_0023_003DzZPsw1geFKzdjHjOctA_003D_003D: true, plotType.Sz);
				break;
			}
			for (int num18 = 0; num18 < elements.Length; num18++)
			{
				Element element7 = elements[num18];
				if (!(element7 is Joint2D))
				{
					for (int num19 = 0; num19 < element7.NumberOfNodes; num19++)
					{
						_0023_003DzSD2VGcFsye5d(element7.Stress[num19, 2], element7, num19);
					}
				}
			}
			_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969523), ref minValue, ref maxValue);
			Element[] array = elements;
			foreach (Element element8 in array)
			{
				if (!(element8 is Joint2D))
				{
					element8._0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(new float[element8.NumberOfNodes]);
					for (int num20 = 0; num20 < element8.NumberOfNodes; num20++)
					{
						element8.PlotValues[num20] = (float)element8.Stress[num20, 2];
					}
				}
			}
			_0023_003DzbhZ5iCYD51mVLiieTGxMri4_003D(_0023_003DzZPsw1geFKzdjHjOctA_003D_003D: false, plotType.Sz);
			break;
		}
		case plotType.Txy:
		{
			if (nodalAverages)
			{
				for (int num103 = 0; num103 < _vertices.Length; num103++)
				{
					Node node14 = (Node)_vertices[num103];
					_0023_003DzSD2VGcFsye5d(node14.Txy, num103);
				}
				_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969508), ref minValue, ref maxValue);
				Point3D[] vertices = _vertices;
				for (int i = 0; i < vertices.Length; i++)
				{
					Node obj22 = (Node)vertices[i];
					obj22._0023_003DzefHtJcxwG1M2((float)obj22.Txy);
				}
				_0023_003DzbhZ5iCYD51mVLiieTGxMri4_003D(_0023_003DzZPsw1geFKzdjHjOctA_003D_003D: true, plotType.Txy);
				break;
			}
			for (int num104 = 0; num104 < elements.Length; num104++)
			{
				Element element29 = elements[num104];
				if (!(element29 is Joint2D))
				{
					for (int num105 = 0; num105 < element29.NumberOfNodes; num105++)
					{
						double _0023_003Dzik60_0024SI_003D3 = element29.Stress[num105, 3];
						_0023_003DzSD2VGcFsye5d(_0023_003Dzik60_0024SI_003D3, element29, num105);
					}
				}
			}
			_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969502), ref minValue, ref maxValue);
			Element[] array = elements;
			foreach (Element element30 in array)
			{
				if (!(element30 is Joint2D))
				{
					element30._0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(new float[element30.NumberOfNodes]);
					for (int num106 = 0; num106 < element30.NumberOfNodes; num106++)
					{
						element30.PlotValues[num106] = (float)element30.Stress[num106, 3];
					}
				}
			}
			_0023_003DzbhZ5iCYD51mVLiieTGxMri4_003D(_0023_003DzZPsw1geFKzdjHjOctA_003D_003D: false, plotType.Txy);
			break;
		}
		case plotType.Tyz:
		{
			if (nodalAverages)
			{
				for (int num6 = 0; num6 < _vertices.Length; num6++)
				{
					Node node2 = (Node)_vertices[num6];
					_0023_003DzSD2VGcFsye5d(node2.Tyz, num6);
				}
				_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969483), ref minValue, ref maxValue);
				Point3D[] vertices = _vertices;
				for (int i = 0; i < vertices.Length; i++)
				{
					Node obj2 = (Node)vertices[i];
					obj2._0023_003DzefHtJcxwG1M2((float)obj2.Tyz);
				}
				_0023_003DzbhZ5iCYD51mVLiieTGxMri4_003D(_0023_003DzZPsw1geFKzdjHjOctA_003D_003D: true, plotType.Tyz);
				break;
			}
			for (int num7 = 0; num7 < elements.Length; num7++)
			{
				Element element4 = elements[num7];
				if (!(element4 is Joint2D))
				{
					for (int num8 = 0; num8 < element4.NumberOfNodes; num8++)
					{
						_0023_003DzSD2VGcFsye5d(element4.Stress[num8, 4], element4, num8);
					}
				}
			}
			_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970213), ref minValue, ref maxValue);
			Element[] array = elements;
			foreach (Element element5 in array)
			{
				if (!(element5 is Joint2D))
				{
					element5._0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(new float[element5.NumberOfNodes]);
					for (int num9 = 0; num9 < element5.NumberOfNodes; num9++)
					{
						element5.PlotValues[num9] = (float)element5.Stress[num9, 4];
					}
				}
			}
			_0023_003DzbhZ5iCYD51mVLiieTGxMri4_003D(_0023_003DzZPsw1geFKzdjHjOctA_003D_003D: false, plotType.Tyz);
			break;
		}
		case plotType.Txz:
		{
			if (nodalAverages)
			{
				for (int num26 = 0; num26 < _vertices.Length; num26++)
				{
					Node node5 = (Node)_vertices[num26];
					_0023_003DzSD2VGcFsye5d(node5.Txz, num26);
				}
				_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970198), ref minValue, ref maxValue);
				Point3D[] vertices = _vertices;
				for (int i = 0; i < vertices.Length; i++)
				{
					Node obj5 = (Node)vertices[i];
					obj5._0023_003DzefHtJcxwG1M2((float)obj5.Txz);
				}
				_0023_003DzbhZ5iCYD51mVLiieTGxMri4_003D(_0023_003DzZPsw1geFKzdjHjOctA_003D_003D: true, plotType.Txz);
				break;
			}
			for (int num27 = 0; num27 < elements.Length; num27++)
			{
				Element element10 = elements[num27];
				if (!(element10 is Joint2D))
				{
					for (int num28 = 0; num28 < element10.NumberOfNodes; num28++)
					{
						_0023_003DzSD2VGcFsye5d(element10.Stress[num28, 5], element10, num28);
					}
				}
			}
			_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970192), ref minValue, ref maxValue);
			Element[] array = elements;
			foreach (Element element11 in array)
			{
				if (!(element11 is Joint2D))
				{
					element11._0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(new float[element11.NumberOfNodes]);
					for (int num29 = 0; num29 < element11.NumberOfNodes; num29++)
					{
						element11.PlotValues[num29] = (float)element11.Stress[num29, 5];
					}
				}
			}
			_0023_003DzbhZ5iCYD51mVLiieTGxMri4_003D(_0023_003DzZPsw1geFKzdjHjOctA_003D_003D: false, plotType.Txz);
			break;
		}
		case plotType.P1:
		{
			if (nodalAverages)
			{
				for (int num86 = 0; num86 < _vertices.Length; num86++)
				{
					Node node12 = (Node)_vertices[num86];
					_0023_003DzSD2VGcFsye5d(node12.P1, num86);
				}
				_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970173), ref minValue, ref maxValue);
				Point3D[] vertices = _vertices;
				for (int i = 0; i < vertices.Length; i++)
				{
					Node obj17 = (Node)vertices[i];
					obj17._0023_003DzefHtJcxwG1M2((float)obj17.P1);
				}
				_0023_003DzbhZ5iCYD51mVLiieTGxMri4_003D(_0023_003DzZPsw1geFKzdjHjOctA_003D_003D: true, plotType.P1);
				break;
			}
			for (int num87 = 0; num87 < elements.Length; num87++)
			{
				Element element24 = elements[num87];
				if (!(element24 is Joint2D))
				{
					for (int num88 = 0; num88 < element24.NumberOfNodes; num88++)
					{
						_0023_003DzSD2VGcFsye5d(element24.Principals[num88, 0], element24, num88);
					}
				}
			}
			_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970119), ref minValue, ref maxValue);
			Element[] array = elements;
			foreach (Element element25 in array)
			{
				if (!(element25 is Joint2D))
				{
					element25._0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(new float[element25.NumberOfNodes]);
					for (int num89 = 0; num89 < element25.NumberOfNodes; num89++)
					{
						element25.PlotValues[num89] = (float)element25.Principals[num89, 0];
					}
				}
			}
			_0023_003DzbhZ5iCYD51mVLiieTGxMri4_003D(_0023_003DzZPsw1geFKzdjHjOctA_003D_003D: false, plotType.P1);
			break;
		}
		case plotType.P2:
		{
			if (nodalAverages)
			{
				for (int num82 = 0; num82 < _vertices.Length; num82++)
				{
					Node node11 = (Node)_vertices[num82];
					_0023_003DzSD2VGcFsye5d(node11.P2, num82);
				}
				_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970344), ref minValue, ref maxValue);
				Point3D[] vertices = _vertices;
				for (int i = 0; i < vertices.Length; i++)
				{
					Node obj16 = (Node)vertices[i];
					obj16._0023_003DzefHtJcxwG1M2((float)obj16.P2);
				}
				_0023_003DzbhZ5iCYD51mVLiieTGxMri4_003D(_0023_003DzZPsw1geFKzdjHjOctA_003D_003D: true, plotType.P2);
				break;
			}
			for (int num83 = 0; num83 < elements.Length; num83++)
			{
				Element element22 = elements[num83];
				if (!(element22 is Joint2D))
				{
					for (int num84 = 0; num84 < element22.NumberOfNodes; num84++)
					{
						_0023_003DzSD2VGcFsye5d(element22.Principals[num84, 1], element22, num84);
					}
				}
			}
			_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970293), ref minValue, ref maxValue);
			Element[] array = elements;
			foreach (Element element23 in array)
			{
				if (!(element23 is Joint2D))
				{
					element23._0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(new float[element23.NumberOfNodes]);
					for (int num85 = 0; num85 < element23.NumberOfNodes; num85++)
					{
						element23.PlotValues[num85] = (float)element23.Principals[num85, 1];
					}
				}
			}
			_0023_003DzbhZ5iCYD51mVLiieTGxMri4_003D(_0023_003DzZPsw1geFKzdjHjOctA_003D_003D: false, plotType.P2);
			break;
		}
		case plotType.P3:
		{
			if (nodalAverages)
			{
				for (int l = 0; l < _vertices.Length; l++)
				{
					Node node = (Node)_vertices[l];
					_0023_003DzSD2VGcFsye5d(node.P3, l);
				}
				_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970265), ref minValue, ref maxValue);
				Point3D[] vertices = _vertices;
				for (int i = 0; i < vertices.Length; i++)
				{
					Node obj = (Node)vertices[i];
					obj._0023_003DzefHtJcxwG1M2((float)obj.P3);
				}
				_0023_003DzbhZ5iCYD51mVLiieTGxMri4_003D(_0023_003DzZPsw1geFKzdjHjOctA_003D_003D: true, plotType.P3);
				break;
			}
			for (int m = 0; m < elements.Length; m++)
			{
				Element element2 = elements[m];
				if (!(element2 is Joint2D))
				{
					for (int n = 0; n < element2.NumberOfNodes; n++)
					{
						_0023_003DzSD2VGcFsye5d(element2.Principals[n, 2], element2, n);
					}
				}
			}
			_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969955), ref minValue, ref maxValue);
			Element[] array = elements;
			foreach (Element element3 in array)
			{
				if (!(element3 is Joint2D))
				{
					element3._0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(new float[element3.NumberOfNodes]);
					for (int num5 = 0; num5 < element3.NumberOfNodes; num5++)
					{
						element3.PlotValues[num5] = (float)element3.Principals[num5, 2];
					}
				}
			}
			_0023_003DzbhZ5iCYD51mVLiieTGxMri4_003D(_0023_003DzZPsw1geFKzdjHjOctA_003D_003D: false, plotType.P3);
			break;
		}
		case plotType.VonMises:
		{
			if (nodalAverages)
			{
				for (int num39 = 0; num39 < _vertices.Length; num39++)
				{
					Node node8 = (Node)_vertices[num39];
					_0023_003DzSD2VGcFsye5d(node8.VonMises, num39);
				}
				_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969924), ref minValue, ref maxValue);
				Point3D[] vertices = _vertices;
				for (int i = 0; i < vertices.Length; i++)
				{
					Node obj8 = (Node)vertices[i];
					obj8._0023_003DzefHtJcxwG1M2((float)obj8.VonMises);
				}
				_0023_003DzbhZ5iCYD51mVLiieTGxMri4_003D(_0023_003DzZPsw1geFKzdjHjOctA_003D_003D: true, plotType.VonMises);
				break;
			}
			for (int num40 = 0; num40 < elements.Length; num40++)
			{
				Element element15 = elements[num40];
				if (!(element15 is Joint2D))
				{
					for (int num41 = 0; num41 < element15.NumberOfNodes; num41++)
					{
						_0023_003DzSD2VGcFsye5d(element15.VonMises[num41], element15, num41);
					}
				}
			}
			_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969030), ref minValue, ref maxValue);
			Element[] array = elements;
			foreach (Element element16 in array)
			{
				if (!(element16 is Joint2D))
				{
					element16._0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(new float[element16.NumberOfNodes]);
					for (int num42 = 0; num42 < element16.NumberOfNodes; num42++)
					{
						element16.PlotValues[num42] = (float)element16.VonMises[num42];
					}
				}
			}
			_0023_003DzbhZ5iCYD51mVLiieTGxMri4_003D(_0023_003DzZPsw1geFKzdjHjOctA_003D_003D: false, plotType.VonMises);
			break;
		}
		case plotType.Tresca:
		{
			if (nodalAverages)
			{
				for (int num90 = 0; num90 < _vertices.Length; num90++)
				{
					Node node13 = (Node)_vertices[num90];
					_0023_003DzSD2VGcFsye5d(node13.Tresca, num90);
				}
				_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969917), ref minValue, ref maxValue);
				Point3D[] vertices = _vertices;
				for (int i = 0; i < vertices.Length; i++)
				{
					Node obj18 = (Node)vertices[i];
					obj18._0023_003DzefHtJcxwG1M2((float)obj18.Tresca);
				}
				_0023_003DzbhZ5iCYD51mVLiieTGxMri4_003D(_0023_003DzZPsw1geFKzdjHjOctA_003D_003D: true, plotType.Tresca);
				break;
			}
			for (int num91 = 0; num91 < elements.Length; num91++)
			{
				Element element26 = elements[num91];
				if (!(element26 is Joint2D))
				{
					for (int num92 = 0; num92 < element26.NumberOfNodes; num92++)
					{
						double _0023_003Dzik60_0024SI_003D2 = _0023_003DzOVvHcTmyizH3(num92, element26.Principals);
						_0023_003DzSD2VGcFsye5d(_0023_003Dzik60_0024SI_003D2, element26, num92);
					}
				}
			}
			_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969014), ref minValue, ref maxValue);
			Element[] array = elements;
			foreach (Element element27 in array)
			{
				if (!(element27 is Joint2D))
				{
					element27._0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(new float[element27.NumberOfNodes]);
					for (int num93 = 0; num93 < element27.NumberOfNodes; num93++)
					{
						double num94 = _0023_003DzOVvHcTmyizH3(num93, element27.Principals);
						element27.PlotValues[num93] = (float)num94;
					}
				}
			}
			_0023_003DzbhZ5iCYD51mVLiieTGxMri4_003D(_0023_003DzZPsw1geFKzdjHjOctA_003D_003D: false, plotType.Tresca);
			break;
		}
		case plotType.AxialForce:
		{
			List<double[]> list5 = new List<double[]>();
			for (int num74 = 0; num74 < elements.Length; num74++)
			{
				Element element21 = elements[num74];
				if (element21 is Beam)
				{
					Beam beam8 = (Beam)element21;
					int subdivisionNumber9 = beam8.SubdivisionNumber;
					double[] array12 = new double[subdivisionNumber9];
					double _0023_003DzEWLeis8_003D5;
					double[] _0023_003Dzt38nTwk_003D5 = beam8._0023_003DzCTqivyHg5Fub33EJ0BT3WnE_003D(_vertices, _modeIndex, out _0023_003DzEWLeis8_003D5);
					double num75 = _0023_003DzEWLeis8_003D5 * _0023_003DzEWLeis8_003D5;
					double _0023_003DzVSAhiYo_003D5 = num75 * _0023_003DzEWLeis8_003D5;
					MaterialBeam materialBeam5 = (MaterialBeam)beam8.Material;
					double num76 = _0023_003DzEWLeis8_003D5 / (double)(subdivisionNumber9 - 1);
					beam8._0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(new float[array12.Length]);
					for (int num77 = 0; num77 < subdivisionNumber9; num77++)
					{
						double num78 = beam8._0023_003DzpcKMlWweRfLzTRPmCg_003D_003D(_0023_003Dzt38nTwk_003D5, num76 * (double)num77, _0023_003DzEWLeis8_003D5, num75, _0023_003DzVSAhiYo_003D5, materialBeam5.SectionArea);
						array12[num77] = num78;
						beam8.PlotValues[num77] = (float)array12[num77];
						_0023_003DzSD2VGcFsye5d(array12[num77]);
					}
					list5.Add(array12);
				}
				else if (element21 is Beam2D)
				{
					Beam2D beam2D3 = (Beam2D)element21;
					int subdivisionNumber10 = beam2D3.SubdivisionNumber;
					double[] array13 = new double[subdivisionNumber10];
					double num79 = _vertices[beam2D3.Connection[0]].DistanceTo(_vertices[beam2D3.Connection[1]]) / (double)(subdivisionNumber10 - 1);
					beam2D3._0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(new float[array13.Length]);
					for (int num80 = 0; num80 < subdivisionNumber10; num80++)
					{
						double num81 = (array13[num80] = beam2D3.CalcAxialForce(_vertices, num79 * (double)num80));
						beam2D3.PlotValues[num80] = (float)num81;
						_0023_003DzSD2VGcFsye5d(array13[num80]);
					}
					list5.Add(array13);
				}
			}
			_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968990), ref minValue, ref maxValue);
			break;
		}
		case plotType.ShearForceV:
		{
			List<double[]> list4 = new List<double[]>();
			for (int num59 = 0; num59 < elements.Length; num59++)
			{
				Element element18 = elements[num59];
				if (element18 is Beam)
				{
					Beam beam6 = (Beam)element18;
					int subdivisionNumber6 = beam6.SubdivisionNumber;
					double[] array9 = new double[subdivisionNumber6];
					double _0023_003DzEWLeis8_003D4;
					double[] _0023_003Dzt38nTwk_003D4 = beam6._0023_003DzCTqivyHg5Fub33EJ0BT3WnE_003D(_vertices, _modeIndex, out _0023_003DzEWLeis8_003D4);
					double num60 = _0023_003DzEWLeis8_003D4 * _0023_003DzEWLeis8_003D4;
					double _0023_003DzVSAhiYo_003D4 = num60 * _0023_003DzEWLeis8_003D4;
					MaterialBeam materialBeam4 = (MaterialBeam)beam6.Material;
					double _0023_003DzzFgDFp4_003D4 = beam6.Material.Young * materialBeam4.Iv;
					double _0023_003DzoeWcMeQ_003D4 = beam6.Material.Young * materialBeam4.Iw;
					double num61 = _0023_003DzEWLeis8_003D4 / (double)(subdivisionNumber6 - 1);
					beam6._0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(new float[array9.Length]);
					for (int num62 = 0; num62 < subdivisionNumber6; num62++)
					{
						double[] array10 = beam6._0023_003DzOT1tuyIX5bhD25A0EKaDWOA_003D(_0023_003Dzt38nTwk_003D4, num61 * (double)num62, _0023_003DzEWLeis8_003D4, num60, _0023_003DzVSAhiYo_003D4, _0023_003DzzFgDFp4_003D4, _0023_003DzoeWcMeQ_003D4);
						array9[num62] = array10[0];
						beam6.PlotValues[num62] = (float)array9[num62];
						_0023_003DzSD2VGcFsye5d(array9[num62]);
					}
					list4.Add(array9);
				}
				else if (element18 is Beam2D)
				{
					Beam2D beam2D2 = (Beam2D)element18;
					int subdivisionNumber7 = beam2D2.SubdivisionNumber;
					double[] array11 = new double[subdivisionNumber7];
					double num63 = _vertices[beam2D2.Connection[0]].DistanceTo(_vertices[beam2D2.Connection[1]]) / (double)(subdivisionNumber7 - 1);
					beam2D2._0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(new float[array11.Length]);
					for (int num64 = 0; num64 < subdivisionNumber7; num64++)
					{
						double num65 = (array11[num64] = beam2D2.CalcShearForce(_vertices, num63 * (double)num64));
						beam2D2.PlotValues[num64] = (float)num65;
						_0023_003DzSD2VGcFsye5d(array11[num64]);
					}
					list4.Add(array11);
				}
			}
			_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968976), ref minValue, ref maxValue);
			break;
		}
		case plotType.ShearForceW:
		{
			List<double[]> list3 = new List<double[]>();
			for (int num43 = 0; num43 < elements.Length; num43++)
			{
				Element element17 = elements[num43];
				if (element17 is Beam)
				{
					Beam beam5 = (Beam)element17;
					int subdivisionNumber5 = beam5.SubdivisionNumber;
					double[] array7 = new double[subdivisionNumber5];
					double _0023_003DzEWLeis8_003D3;
					double[] _0023_003Dzt38nTwk_003D3 = beam5._0023_003DzCTqivyHg5Fub33EJ0BT3WnE_003D(_vertices, _modeIndex, out _0023_003DzEWLeis8_003D3);
					double num44 = _0023_003DzEWLeis8_003D3 * _0023_003DzEWLeis8_003D3;
					double _0023_003DzVSAhiYo_003D3 = num44 * _0023_003DzEWLeis8_003D3;
					MaterialBeam materialBeam3 = (MaterialBeam)beam5.Material;
					double _0023_003DzzFgDFp4_003D3 = beam5.Material.Young * materialBeam3.Iv;
					double _0023_003DzoeWcMeQ_003D3 = beam5.Material.Young * materialBeam3.Iw;
					double num45 = _0023_003DzEWLeis8_003D3 / (double)(subdivisionNumber5 - 1);
					beam5._0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(new float[array7.Length]);
					for (int num46 = 0; num46 < subdivisionNumber5; num46++)
					{
						double[] array8 = beam5._0023_003DzOT1tuyIX5bhD25A0EKaDWOA_003D(_0023_003Dzt38nTwk_003D3, num45 * (double)num46, _0023_003DzEWLeis8_003D3, num44, _0023_003DzVSAhiYo_003D3, _0023_003DzzFgDFp4_003D3, _0023_003DzoeWcMeQ_003D3);
						array7[num46] = array8[1];
						beam5.PlotValues[num46] = (float)array7[num46];
						_0023_003DzSD2VGcFsye5d(array7[num46]);
					}
					list3.Add(array7);
				}
			}
			_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969700), ref minValue, ref maxValue);
			break;
		}
		case plotType.TorsionMoment:
		{
			for (int num34 = 0; num34 < elements.Length; num34++)
			{
				Element element14 = elements[num34];
				if (element14 is Beam)
				{
					Beam beam4 = (Beam)element14;
					beam4._0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(new float[beam4.SubdivisionNumber]);
					for (int num35 = 0; num35 < beam4.SubdivisionNumber; num35++)
					{
						beam4.PlotValues[num35] = (float)beam4.TorsionMoment;
					}
					_0023_003DzSD2VGcFsye5d(beam4.TorsionMoment);
				}
			}
			_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969688), ref minValue, ref maxValue);
			break;
		}
		case plotType.TwistAngle:
		{
			for (int num21 = 0; num21 < elements.Length; num21++)
			{
				Element element9 = elements[num21];
				if (element9 is Beam)
				{
					Beam beam3 = (Beam)element9;
					int subdivisionNumber4 = beam3.SubdivisionNumber;
					beam3._0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(new float[subdivisionNumber4]);
					double num22 = beam3.TwistAngle[0];
					double num23 = beam3.TwistAngle[1];
					_0023_003DzSD2VGcFsye5d(num22);
					_0023_003DzSD2VGcFsye5d(num23);
					double num24 = (num23 - num22) / (double)(subdivisionNumber4 - 1);
					for (int num25 = 0; num25 < subdivisionNumber4; num25++)
					{
						beam3.PlotValues[num25] = (float)(num22 + num24 * (double)num25);
					}
				}
			}
			_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969625), ref minValue, ref maxValue);
			break;
		}
		case plotType.BeamBendingMomentV:
		{
			List<double[]> list2 = new List<double[]>();
			for (int num10 = 0; num10 < elements.Length; num10++)
			{
				Element element6 = elements[num10];
				if (element6 is Beam)
				{
					Beam beam2 = (Beam)element6;
					int subdivisionNumber3 = beam2.SubdivisionNumber;
					double[] array5 = new double[subdivisionNumber3];
					double _0023_003DzEWLeis8_003D2;
					double[] _0023_003Dzt38nTwk_003D2 = beam2._0023_003DzCTqivyHg5Fub33EJ0BT3WnE_003D(_vertices, _modeIndex, out _0023_003DzEWLeis8_003D2);
					double num11 = _0023_003DzEWLeis8_003D2 * _0023_003DzEWLeis8_003D2;
					double _0023_003DzVSAhiYo_003D2 = num11 * _0023_003DzEWLeis8_003D2;
					MaterialBeam materialBeam2 = (MaterialBeam)beam2.Material;
					double _0023_003DzzFgDFp4_003D2 = beam2.Material.Young * materialBeam2.Iv;
					double _0023_003DzoeWcMeQ_003D2 = beam2.Material.Young * materialBeam2.Iw;
					double num12 = _0023_003DzEWLeis8_003D2 / (double)(subdivisionNumber3 - 1);
					beam2._0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(new float[array5.Length]);
					for (int num13 = 0; num13 < subdivisionNumber3; num13++)
					{
						double[] array6 = beam2._0023_003Dz65_0024aHioBxzZmkAvYSKHCVwz_wCIY(_0023_003Dzt38nTwk_003D2, num12 * (double)num13, _0023_003DzEWLeis8_003D2, num11, _0023_003DzVSAhiYo_003D2, _0023_003DzzFgDFp4_003D2, _0023_003DzoeWcMeQ_003D2);
						array5[num13] = array6[1];
						beam2.PlotValues[num13] = (float)array5[num13];
						_0023_003DzSD2VGcFsye5d(array5[num13]);
					}
					list2.Add(array5);
				}
			}
			_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969877), ref minValue, ref maxValue);
			break;
		}
		case plotType.BeamBendingMomentW:
		{
			List<double[]> list = new List<double[]>();
			Element[] array = elements;
			foreach (Element element in array)
			{
				if (element is Beam)
				{
					Beam beam = (Beam)element;
					int subdivisionNumber = beam.SubdivisionNumber;
					double[] array2 = new double[subdivisionNumber];
					double _0023_003DzEWLeis8_003D;
					double[] _0023_003Dzt38nTwk_003D = beam._0023_003DzCTqivyHg5Fub33EJ0BT3WnE_003D(_vertices, _modeIndex, out _0023_003DzEWLeis8_003D);
					double num = _0023_003DzEWLeis8_003D * _0023_003DzEWLeis8_003D;
					double _0023_003DzVSAhiYo_003D = num * _0023_003DzEWLeis8_003D;
					MaterialBeam materialBeam = (MaterialBeam)beam.Material;
					double _0023_003DzzFgDFp4_003D = beam.Material.Young * materialBeam.Iv;
					double _0023_003DzoeWcMeQ_003D = beam.Material.Young * materialBeam.Iw;
					double num2 = _0023_003DzEWLeis8_003D / (double)(subdivisionNumber - 1);
					beam._0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(new float[array2.Length]);
					for (int j = 0; j < subdivisionNumber; j++)
					{
						double[] array3 = beam._0023_003Dz65_0024aHioBxzZmkAvYSKHCVwz_wCIY(_0023_003Dzt38nTwk_003D, num2 * (double)j, _0023_003DzEWLeis8_003D, num, _0023_003DzVSAhiYo_003D, _0023_003DzzFgDFp4_003D, _0023_003DzoeWcMeQ_003D);
						array2[j] = array3[0];
						beam.PlotValues[j] = (float)array2[j];
						_0023_003DzSD2VGcFsye5d(array2[j]);
					}
					list.Add(array2);
				}
				else if (element is Beam2D)
				{
					Beam2D beam2D = (Beam2D)element;
					int subdivisionNumber2 = beam2D.SubdivisionNumber;
					double[] array4 = new double[subdivisionNumber2];
					double num3 = _vertices[beam2D.Connection[0]].DistanceTo(_vertices[beam2D.Connection[1]]) / (double)(subdivisionNumber2 - 1);
					beam2D._0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(new float[array4.Length]);
					for (int k = 0; k < subdivisionNumber2; k++)
					{
						double num4 = (array4[k] = beam2D.CalcBendingMoment(_vertices, num3 * (double)k));
						beam2D.PlotValues[k] = (float)num4;
						_0023_003DzSD2VGcFsye5d(array4[k]);
					}
					list.Add(array4);
				}
			}
			_0023_003DzR9P7GK5550gG(legend, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969870), ref minValue, ref maxValue);
			break;
		}
		}
		if (contourPlot || plotMode != plotType.Mesh)
		{
			Color[] colorTable = legend.GetColorTable();
			if (texture1D != null)
			{
				texture1D.Dispose();
			}
			textureFilteringFunctionType textureFilteringFunctionType2 = ((!contourPlot) ? textureFilteringFunctionType.Linear : textureFilteringFunctionType.Nearest);
			if (colorTable.Length != 0)
			{
				texture1D = simulation.RenderContext.CreateTexture1D(colorTable, textureFilteringFunctionType2, textureFilteringFunctionType2, anisotropicFiltering: false, repeatX: false);
			}
		}
		CompileParams data = new CompileParams(simulation.RenderContext, simulation.Document.MaxPatternRepetitions, simulation.CompileWires, legend);
		if (ClippingPlane != null && (_prevMethod != ClippingMethod || _prevPlane != ClippingPlane) && ClippingMethod == clippingMethodType.Planar)
		{
			_0023_003DzRZsNU9uHQp3MDRUD_0024A_003D_003D((plotMode == plotType.Mesh || !solved) ? null : legend);
		}
		Compile(data);
		RegenMode = regenType.NotNeeded;
	}

	public void ResetAnimation()
	{
		_0023_003DzluATrA4_003D();
		drawSolvedFrames = null;
		drawEdgesFrames = null;
		drawIsocurvesFrames = null;
	}

	public void PrepareAnimation(int numberOfFrames, IWorkspace simulation, ILegend legend)
	{
		if (drawSolvedFrames == null || drawEdgesFrames == null || drawIsocurvesFrames == null)
		{
			drawSolvedFrames = new EntityGraphicsData[numberOfFrames];
			drawEdgesFrames = new EntityGraphicsData[numberOfFrames];
			drawIsocurvesFrames = new EntityGraphicsData[numberOfFrames];
			CompileParams _0023_003DzELu0Pss_003D = new CompileParams(simulation.RenderContext, simulation.Document.MaxPatternRepetitions, simulation.CompileWires, legend);
			for (int i = 0; i < numberOfFrames; i++)
			{
				_0023_003DzmHTSerA_003D(ref drawSolvedFrames[i], ref drawEdgesFrames[i], ref drawIsocurvesFrames[i], _0023_003DzjBGFesJwBZiw(i, numberOfFrames), _modeIndex, _0023_003DzELu0Pss_003D);
			}
		}
	}

	private double _0023_003DzjBGFesJwBZiw(int _0023_003Dz437_00244ak_003D, int _0023_003DzUROWvPuTAryL)
	{
		if (NaturalFrequencies != null)
		{
			double a = (double)_0023_003Dz437_00244ak_003D * (Math.PI * 2.0) / (double)_0023_003DzUROWvPuTAryL;
			return _optimalAmpFactor * Math.Sin(a);
		}
		double num = (double)_0023_003Dz437_00244ak_003D / (double)_0023_003DzUROWvPuTAryL;
		if (num < 0.5)
		{
			return 2.0 * _optimalAmpFactor * num;
		}
		return 2.0 * _optimalAmpFactor * (1.0 - num);
	}

	private void _0023_003DzIMfwKDW6RVB7Cvl0YIgNbYirSNqw(Beam _0023_003Dzol5oTDIn1k8K)
	{
		Node node = (Node)_vertices[_0023_003Dzol5oTDIn1k8K.Connection[0]];
		Node p = (Node)_vertices[_0023_003Dzol5oTDIn1k8K.Connection[1]];
		Vector3D vector3D = new Vector3D(node, p);
		double length = vector3D.Length;
		int subdivisionNumber = _0023_003Dzol5oTDIn1k8K.SubdivisionNumber;
		double num = length / (double)(subdivisionNumber - 1);
		vector3D.Normalize();
		Vector3D vector3D2 = Vector3D.Cross(vector3D, _0023_003Dzol5oTDIn1k8K.v);
		vector3D2.Normalize();
		_0023_003Dzol5oTDIn1k8K._0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(new float[subdivisionNumber]);
		for (int i = 0; i < subdivisionNumber; i++)
		{
			double num2 = num * (double)i;
			Point3D point3D = node + num2 * vector3D;
			double[] array = _0023_003Dzol5oTDIn1k8K.CalcDisplacementsAlongTheBeam(_vertices, num2);
			Point3D point3D2 = point3D + vector3D * array[0] + _0023_003Dzol5oTDIn1k8K.v * array[1] + vector3D2 * array[2];
			double num3 = ((plotMode != plotType.Ux) ? ((plotMode != plotType.Uy) ? ((plotMode != plotType.Uz) ? Point3D.Distance(point3D2, point3D) : (point3D2.Z - point3D.Z)) : (point3D2.Y - point3D.Y)) : (point3D2.X - point3D.X));
			_0023_003Dzol5oTDIn1k8K.PlotValues[i] = (float)num3;
			_0023_003DzSD2VGcFsye5d(num3);
		}
	}

	private void _0023_003DzMtTmuFaMSNrq20IuN3wt6W_0024zp2ic(Beam2D _0023_003Dz88Es_0024d16WeJr)
	{
		Node node = (Node)_vertices[_0023_003Dz88Es_0024d16WeJr.Connection[0]];
		_0023_003Dz88Es_0024d16WeJr._0023_003Dz9N71tA5ZWS90YBI87g_003D_003D(_vertices, out var _0023_003Dz_eY3Y4c_003D, out var _0023_003Dz77g161c_003D, out var _, out var _0023_003DzELnUZQyM6IsC);
		int subdivisionNumber = _0023_003Dz88Es_0024d16WeJr.SubdivisionNumber;
		double num = _0023_003DzELnUZQyM6IsC / (double)(subdivisionNumber - 1);
		_0023_003Dz88Es_0024d16WeJr._0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(new float[subdivisionNumber]);
		for (int i = 0; i < subdivisionNumber; i++)
		{
			double num2 = num * (double)i;
			Point3D point3D = node + num2 * _0023_003Dz_eY3Y4c_003D;
			double[] array = _0023_003Dz88Es_0024d16WeJr.CalcDisplacementsAlongTheBeam(_vertices, num2);
			Point3D point3D2 = point3D + _0023_003Dz_eY3Y4c_003D * array[0] + _0023_003Dz77g161c_003D * array[1];
			double num3 = ((plotMode != plotType.Ux) ? ((plotMode != plotType.Uy) ? Point3D.Distance(point3D2, point3D) : (point3D2.Y - point3D.Y)) : (point3D2.X - point3D.X));
			_0023_003Dz88Es_0024d16WeJr.PlotValues[i] = (float)num3;
			_0023_003DzSD2VGcFsye5d(num3);
		}
	}

	private void _0023_003DzxO9qSfXUosQy_0024ALvucLaCCw_003D(plotType _0023_003DzgIAHZxx_JqDYLChMeA_003D_003D)
	{
		Element[] array = elements;
		foreach (Element element in array)
		{
			if (!(element is Joint2D) && !(element is Hexa8) && !(element is Tetra4) && !(element is Penta6) && !(element is Tria3) && !(element is Quad4) && !(element is Tetra10) && !(element is Tria6))
			{
				_0023_003DzidR7r3sOwJRYbTCkSg_003D_003D(element, _0023_003DzgIAHZxx_JqDYLChMeA_003D_003D, 0);
			}
		}
	}

	private void _0023_003DzbhZ5iCYD51mVLiieTGxMri4_003D(bool _0023_003DzZPsw1geFKzdjHjOctA_003D_003D, plotType _0023_003DzgIAHZxx_JqDYLChMeA_003D_003D)
	{
		Element[] array = elements;
		foreach (Element element in array)
		{
			if (element is Quad8 || element is Hexa20 || element is Penta15)
			{
				_0023_003DzgJLLerjNt80M48b5bQ_003D_003D(element, _0023_003DzZPsw1geFKzdjHjOctA_003D_003D, _0023_003DzgIAHZxx_JqDYLChMeA_003D_003D);
			}
		}
	}

	private void _0023_003DzidR7r3sOwJRYbTCkSg_003D_003D(Element _0023_003Dz9j4kMjs_003D, plotType _0023_003DzgIAHZxx_JqDYLChMeA_003D_003D, int _0023_003DznXXM9vk_003D)
	{
		byte b = 0;
		byte b2 = (byte)_0023_003Dz9j4kMjs_003D.Faces.Length;
		if (_0023_003Dz9j4kMjs_003D is Penta15)
		{
			b = 1;
			b2--;
		}
		for (byte b3 = b; b3 < b2; b3++)
		{
			Element.Face face = _0023_003Dz9j4kMjs_003D.Faces[b3];
			if (_0023_003Dz9j4kMjs_003D.Faces[b3].Visible)
			{
				face.UpdateCentroidUnknowns(_0023_003Dz9j4kMjs_003D, _vertices, _0023_003DznXXM9vk_003D);
				switch (_0023_003DzgIAHZxx_JqDYLChMeA_003D_003D)
				{
				case plotType.Ux:
					face.Centroid._0023_003DzefHtJcxwG1M2((float)_0023_003Dz9j4kMjs_003D.Faces[b3].Centroid.Unknowns[_0023_003DznXXM9vk_003D][0]);
					break;
				case plotType.Uy:
					face.Centroid._0023_003DzefHtJcxwG1M2((float)_0023_003Dz9j4kMjs_003D.Faces[b3].Centroid.Unknowns[_0023_003DznXXM9vk_003D][1]);
					break;
				case plotType.Uz:
					face.Centroid._0023_003DzefHtJcxwG1M2((float)_0023_003Dz9j4kMjs_003D.Faces[b3].Centroid.Unknowns[_0023_003DznXXM9vk_003D][2]);
					break;
				case plotType.U:
				{
					double num = _0023_003Dz9j4kMjs_003D.Faces[b3].Centroid.Unknowns[_0023_003DznXXM9vk_003D][0];
					double num2 = _0023_003Dz9j4kMjs_003D.Faces[b3].Centroid.Unknowns[_0023_003DznXXM9vk_003D][1];
					double num3 = _0023_003Dz9j4kMjs_003D.Faces[b3].Centroid.Unknowns[_0023_003DznXXM9vk_003D][2];
					face.Centroid._0023_003DzefHtJcxwG1M2((float)Math.Sqrt(num * num + num2 * num2 + num3 * num3));
					break;
				}
				}
			}
		}
	}

	private void _0023_003DzgJLLerjNt80M48b5bQ_003D_003D(Element _0023_003Dz9j4kMjs_003D, bool _0023_003DzZPsw1geFKzdjHjOctA_003D_003D, plotType _0023_003DzgIAHZxx_JqDYLChMeA_003D_003D)
	{
		byte b = 0;
		byte b2 = (byte)_0023_003Dz9j4kMjs_003D.Faces.Length;
		if (_0023_003Dz9j4kMjs_003D is Penta15)
		{
			b = 1;
			b2--;
		}
		for (byte b3 = b; b3 < b2; b3++)
		{
			Element.Face face = _0023_003Dz9j4kMjs_003D.Faces[b3];
			if (face.Visible)
			{
				switch (_0023_003DzgIAHZxx_JqDYLChMeA_003D_003D)
				{
				case plotType.Sx:
					_0023_003DzKqkSlxtTjyaSeN2FtUn9w00_003D(b3, 0, _0023_003Dz9j4kMjs_003D, face, _0023_003DzZPsw1geFKzdjHjOctA_003D_003D);
					break;
				case plotType.Sy:
					_0023_003DzKqkSlxtTjyaSeN2FtUn9w00_003D(b3, 1, _0023_003Dz9j4kMjs_003D, face, _0023_003DzZPsw1geFKzdjHjOctA_003D_003D);
					break;
				case plotType.Sz:
					_0023_003DzKqkSlxtTjyaSeN2FtUn9w00_003D(b3, 2, _0023_003Dz9j4kMjs_003D, face, _0023_003DzZPsw1geFKzdjHjOctA_003D_003D);
					break;
				case plotType.Txy:
					_0023_003DzKqkSlxtTjyaSeN2FtUn9w00_003D(b3, 3, _0023_003Dz9j4kMjs_003D, face, _0023_003DzZPsw1geFKzdjHjOctA_003D_003D);
					break;
				case plotType.Tyz:
					_0023_003DzKqkSlxtTjyaSeN2FtUn9w00_003D(b3, 4, _0023_003Dz9j4kMjs_003D, face, _0023_003DzZPsw1geFKzdjHjOctA_003D_003D);
					break;
				case plotType.Txz:
					_0023_003DzKqkSlxtTjyaSeN2FtUn9w00_003D(b3, 5, _0023_003Dz9j4kMjs_003D, face, _0023_003DzZPsw1geFKzdjHjOctA_003D_003D);
					break;
				case plotType.P1:
					_0023_003Dz_00245y52SJLEpdnVnOIc7Tml8k_003D(b3, 0, _0023_003Dz9j4kMjs_003D, face, _0023_003DzZPsw1geFKzdjHjOctA_003D_003D);
					break;
				case plotType.P2:
					_0023_003Dz_00245y52SJLEpdnVnOIc7Tml8k_003D(b3, 1, _0023_003Dz9j4kMjs_003D, face, _0023_003DzZPsw1geFKzdjHjOctA_003D_003D);
					break;
				case plotType.P3:
					_0023_003Dz_00245y52SJLEpdnVnOIc7Tml8k_003D(b3, 2, _0023_003Dz9j4kMjs_003D, face, _0023_003DzZPsw1geFKzdjHjOctA_003D_003D);
					break;
				case plotType.VonMises:
					_0023_003DzBn8WjQnDgANWUSbODzFhVf0_003D(b3, _0023_003Dz9j4kMjs_003D, face, _0023_003DzZPsw1geFKzdjHjOctA_003D_003D);
					break;
				case plotType.Tresca:
					_0023_003Dz_0024nQ6ZH2ySA7HVRy20isb_00245_gM14p(b3, _0023_003Dz9j4kMjs_003D, face, _0023_003DzZPsw1geFKzdjHjOctA_003D_003D);
					break;
				}
			}
		}
	}

	private void _0023_003DzKqkSlxtTjyaSeN2FtUn9w00_003D(byte _0023_003Dz437_00244ak_003D, int _0023_003DzVzS_0024neo_003D, Element _0023_003Dz9j4kMjs_003D, Element.Face _0023_003Dz0tskLJQ_003D, bool _0023_003DzZPsw1geFKzdjHjOctA_003D_003D)
	{
		double num = (_0023_003DzZPsw1geFKzdjHjOctA_003D_003D ? ((_0023_003Dz0tskLJQ_003D.Indices.Length != 6) ? Element.WeightedAverage(_0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 0, _vertices).Stress[_0023_003DzVzS_0024neo_003D], _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 1, _vertices).Stress[_0023_003DzVzS_0024neo_003D], _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 2, _vertices).Stress[_0023_003DzVzS_0024neo_003D], _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 3, _vertices).Stress[_0023_003DzVzS_0024neo_003D], _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 4, _vertices).Stress[_0023_003DzVzS_0024neo_003D], _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 5, _vertices).Stress[_0023_003DzVzS_0024neo_003D], _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 6, _vertices).Stress[_0023_003DzVzS_0024neo_003D], _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 7, _vertices).Stress[_0023_003DzVzS_0024neo_003D]) : Element.WeightedAverage(_0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 0, _vertices).Stress[_0023_003DzVzS_0024neo_003D], _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 1, _vertices).Stress[_0023_003DzVzS_0024neo_003D], _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 2, _vertices).Stress[_0023_003DzVzS_0024neo_003D], _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 3, _vertices).Stress[_0023_003DzVzS_0024neo_003D], _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 4, _vertices).Stress[_0023_003DzVzS_0024neo_003D], _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 5, _vertices).Stress[_0023_003DzVzS_0024neo_003D])) : ((_0023_003Dz0tskLJQ_003D.Indices.Length != 6) ? Element.WeightedAverage(_0023_003Dz9j4kMjs_003D.Stress[_0023_003Dz0tskLJQ_003D.Indices[0], _0023_003DzVzS_0024neo_003D], _0023_003Dz9j4kMjs_003D.Stress[_0023_003Dz0tskLJQ_003D.Indices[1], _0023_003DzVzS_0024neo_003D], _0023_003Dz9j4kMjs_003D.Stress[_0023_003Dz0tskLJQ_003D.Indices[2], _0023_003DzVzS_0024neo_003D], _0023_003Dz9j4kMjs_003D.Stress[_0023_003Dz0tskLJQ_003D.Indices[3], _0023_003DzVzS_0024neo_003D], _0023_003Dz9j4kMjs_003D.Stress[_0023_003Dz0tskLJQ_003D.Indices[4], _0023_003DzVzS_0024neo_003D], _0023_003Dz9j4kMjs_003D.Stress[_0023_003Dz0tskLJQ_003D.Indices[5], _0023_003DzVzS_0024neo_003D], _0023_003Dz9j4kMjs_003D.Stress[_0023_003Dz0tskLJQ_003D.Indices[6], _0023_003DzVzS_0024neo_003D], _0023_003Dz9j4kMjs_003D.Stress[_0023_003Dz0tskLJQ_003D.Indices[7], _0023_003DzVzS_0024neo_003D]) : Element.WeightedAverage(_0023_003Dz9j4kMjs_003D.Stress[_0023_003Dz0tskLJQ_003D.Indices[0], _0023_003DzVzS_0024neo_003D], _0023_003Dz9j4kMjs_003D.Stress[_0023_003Dz0tskLJQ_003D.Indices[1], _0023_003DzVzS_0024neo_003D], _0023_003Dz9j4kMjs_003D.Stress[_0023_003Dz0tskLJQ_003D.Indices[2], _0023_003DzVzS_0024neo_003D], _0023_003Dz9j4kMjs_003D.Stress[_0023_003Dz0tskLJQ_003D.Indices[3], _0023_003DzVzS_0024neo_003D], _0023_003Dz9j4kMjs_003D.Stress[_0023_003Dz0tskLJQ_003D.Indices[4], _0023_003DzVzS_0024neo_003D], _0023_003Dz9j4kMjs_003D.Stress[_0023_003Dz0tskLJQ_003D.Indices[5], _0023_003DzVzS_0024neo_003D])));
		_0023_003Dz0tskLJQ_003D.Centroid._0023_003DzefHtJcxwG1M2((float)num);
	}

	private void _0023_003Dz_00245y52SJLEpdnVnOIc7Tml8k_003D(byte _0023_003Dz437_00244ak_003D, int _0023_003DzZr_0024OD0HMV2Sb, Element _0023_003Dz9j4kMjs_003D, Element.Face _0023_003Dz0tskLJQ_003D, bool _0023_003DzZPsw1geFKzdjHjOctA_003D_003D)
	{
		double num = (_0023_003DzZPsw1geFKzdjHjOctA_003D_003D ? ((_0023_003Dz0tskLJQ_003D.Indices.Length != 6) ? Element.WeightedAverage(_0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 0, _vertices).Principals[_0023_003DzZr_0024OD0HMV2Sb], _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 1, _vertices).Principals[_0023_003DzZr_0024OD0HMV2Sb], _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 2, _vertices).Principals[_0023_003DzZr_0024OD0HMV2Sb], _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 3, _vertices).Principals[_0023_003DzZr_0024OD0HMV2Sb], _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 4, _vertices).Principals[_0023_003DzZr_0024OD0HMV2Sb], _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 5, _vertices).Principals[_0023_003DzZr_0024OD0HMV2Sb], _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 6, _vertices).Principals[_0023_003DzZr_0024OD0HMV2Sb], _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 7, _vertices).Principals[_0023_003DzZr_0024OD0HMV2Sb]) : Element.WeightedAverage(_0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 0, _vertices).Principals[_0023_003DzZr_0024OD0HMV2Sb], _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 1, _vertices).Principals[_0023_003DzZr_0024OD0HMV2Sb], _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 2, _vertices).Principals[_0023_003DzZr_0024OD0HMV2Sb], _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 3, _vertices).Principals[_0023_003DzZr_0024OD0HMV2Sb], _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 4, _vertices).Principals[_0023_003DzZr_0024OD0HMV2Sb], _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 5, _vertices).Principals[_0023_003DzZr_0024OD0HMV2Sb])) : ((_0023_003Dz0tskLJQ_003D.Indices.Length != 6) ? Element.WeightedAverage(_0023_003Dz9j4kMjs_003D.Principals[_0023_003Dz9j4kMjs_003D.Faces[_0023_003Dz437_00244ak_003D].Indices[0], _0023_003DzZr_0024OD0HMV2Sb], _0023_003Dz9j4kMjs_003D.Principals[_0023_003Dz9j4kMjs_003D.Faces[_0023_003Dz437_00244ak_003D].Indices[1], _0023_003DzZr_0024OD0HMV2Sb], _0023_003Dz9j4kMjs_003D.Principals[_0023_003Dz9j4kMjs_003D.Faces[_0023_003Dz437_00244ak_003D].Indices[2], _0023_003DzZr_0024OD0HMV2Sb], _0023_003Dz9j4kMjs_003D.Principals[_0023_003Dz9j4kMjs_003D.Faces[_0023_003Dz437_00244ak_003D].Indices[3], _0023_003DzZr_0024OD0HMV2Sb], _0023_003Dz9j4kMjs_003D.Principals[_0023_003Dz9j4kMjs_003D.Faces[_0023_003Dz437_00244ak_003D].Indices[4], _0023_003DzZr_0024OD0HMV2Sb], _0023_003Dz9j4kMjs_003D.Principals[_0023_003Dz9j4kMjs_003D.Faces[_0023_003Dz437_00244ak_003D].Indices[5], _0023_003DzZr_0024OD0HMV2Sb], _0023_003Dz9j4kMjs_003D.Principals[_0023_003Dz9j4kMjs_003D.Faces[_0023_003Dz437_00244ak_003D].Indices[6], _0023_003DzZr_0024OD0HMV2Sb], _0023_003Dz9j4kMjs_003D.Principals[_0023_003Dz9j4kMjs_003D.Faces[_0023_003Dz437_00244ak_003D].Indices[7], _0023_003DzZr_0024OD0HMV2Sb]) : Element.WeightedAverage(_0023_003Dz9j4kMjs_003D.Principals[_0023_003Dz9j4kMjs_003D.Faces[_0023_003Dz437_00244ak_003D].Indices[0], _0023_003DzZr_0024OD0HMV2Sb], _0023_003Dz9j4kMjs_003D.Principals[_0023_003Dz9j4kMjs_003D.Faces[_0023_003Dz437_00244ak_003D].Indices[1], _0023_003DzZr_0024OD0HMV2Sb], _0023_003Dz9j4kMjs_003D.Principals[_0023_003Dz9j4kMjs_003D.Faces[_0023_003Dz437_00244ak_003D].Indices[2], _0023_003DzZr_0024OD0HMV2Sb], _0023_003Dz9j4kMjs_003D.Principals[_0023_003Dz9j4kMjs_003D.Faces[_0023_003Dz437_00244ak_003D].Indices[3], _0023_003DzZr_0024OD0HMV2Sb], _0023_003Dz9j4kMjs_003D.Principals[_0023_003Dz9j4kMjs_003D.Faces[_0023_003Dz437_00244ak_003D].Indices[4], _0023_003DzZr_0024OD0HMV2Sb], _0023_003Dz9j4kMjs_003D.Principals[_0023_003Dz9j4kMjs_003D.Faces[_0023_003Dz437_00244ak_003D].Indices[5], _0023_003DzZr_0024OD0HMV2Sb])));
		_0023_003Dz0tskLJQ_003D.Centroid._0023_003DzefHtJcxwG1M2((float)num);
	}

	private void _0023_003DzBn8WjQnDgANWUSbODzFhVf0_003D(byte _0023_003Dz437_00244ak_003D, Element _0023_003Dz9j4kMjs_003D, Element.Face _0023_003Dz0tskLJQ_003D, bool _0023_003DzZPsw1geFKzdjHjOctA_003D_003D)
	{
		double num = (_0023_003DzZPsw1geFKzdjHjOctA_003D_003D ? ((_0023_003Dz0tskLJQ_003D.Indices.Length != 6) ? Element.WeightedAverage(_0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 0, _vertices).VonMises, _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 1, _vertices).VonMises, _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 2, _vertices).VonMises, _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 3, _vertices).VonMises, _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 4, _vertices).VonMises, _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 5, _vertices).VonMises, _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 6, _vertices).VonMises, _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 7, _vertices).VonMises) : Element.WeightedAverage(_0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 0, _vertices).VonMises, _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 1, _vertices).VonMises, _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 2, _vertices).VonMises, _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 3, _vertices).VonMises, _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 4, _vertices).VonMises, _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 5, _vertices).VonMises)) : ((_0023_003Dz0tskLJQ_003D.Indices.Length != 6) ? Element.WeightedAverage(_0023_003Dz9j4kMjs_003D.VonMises[_0023_003Dz0tskLJQ_003D.Indices[0]], _0023_003Dz9j4kMjs_003D.VonMises[_0023_003Dz0tskLJQ_003D.Indices[1]], _0023_003Dz9j4kMjs_003D.VonMises[_0023_003Dz0tskLJQ_003D.Indices[2]], _0023_003Dz9j4kMjs_003D.VonMises[_0023_003Dz0tskLJQ_003D.Indices[3]], _0023_003Dz9j4kMjs_003D.VonMises[_0023_003Dz0tskLJQ_003D.Indices[4]], _0023_003Dz9j4kMjs_003D.VonMises[_0023_003Dz0tskLJQ_003D.Indices[5]], _0023_003Dz9j4kMjs_003D.VonMises[_0023_003Dz0tskLJQ_003D.Indices[6]], _0023_003Dz9j4kMjs_003D.VonMises[_0023_003Dz0tskLJQ_003D.Indices[7]]) : Element.WeightedAverage(_0023_003Dz9j4kMjs_003D.VonMises[_0023_003Dz0tskLJQ_003D.Indices[0]], _0023_003Dz9j4kMjs_003D.VonMises[_0023_003Dz0tskLJQ_003D.Indices[1]], _0023_003Dz9j4kMjs_003D.VonMises[_0023_003Dz0tskLJQ_003D.Indices[2]], _0023_003Dz9j4kMjs_003D.VonMises[_0023_003Dz0tskLJQ_003D.Indices[3]], _0023_003Dz9j4kMjs_003D.VonMises[_0023_003Dz0tskLJQ_003D.Indices[4]], _0023_003Dz9j4kMjs_003D.VonMises[_0023_003Dz0tskLJQ_003D.Indices[5]])));
		_0023_003Dz0tskLJQ_003D.Centroid._0023_003DzefHtJcxwG1M2((float)num);
	}

	private void _0023_003Dz_0024nQ6ZH2ySA7HVRy20isb_00245_gM14p(byte _0023_003Dz437_00244ak_003D, Element _0023_003Dz9j4kMjs_003D, Element.Face _0023_003Dz0tskLJQ_003D, bool _0023_003DzZPsw1geFKzdjHjOctA_003D_003D)
	{
		double num = (_0023_003DzZPsw1geFKzdjHjOctA_003D_003D ? ((_0023_003Dz0tskLJQ_003D.Indices.Length != 6) ? Element.WeightedAverage(_0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 0, _vertices).Tresca, _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 1, _vertices).Tresca, _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 2, _vertices).Tresca, _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 3, _vertices).Tresca, _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 4, _vertices).Tresca, _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 5, _vertices).Tresca, _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 6, _vertices).Tresca, _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 7, _vertices).Tresca) : Element.WeightedAverage(_0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 0, _vertices).Tresca, _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 1, _vertices).Tresca, _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 2, _vertices).Tresca, _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 3, _vertices).Tresca, _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 4, _vertices).Tresca, _0023_003Dz9j4kMjs_003D._0023_003DzlW6M2e9BpjZg(_0023_003Dz437_00244ak_003D, 5, _vertices).Tresca)) : ((_0023_003Dz0tskLJQ_003D.Indices.Length != 6) ? Element.WeightedAverage(_0023_003DzOVvHcTmyizH3(_0023_003Dz0tskLJQ_003D.Indices[0], _0023_003Dz9j4kMjs_003D.Principals), _0023_003DzOVvHcTmyizH3(_0023_003Dz0tskLJQ_003D.Indices[1], _0023_003Dz9j4kMjs_003D.Principals), _0023_003DzOVvHcTmyizH3(_0023_003Dz0tskLJQ_003D.Indices[2], _0023_003Dz9j4kMjs_003D.Principals), _0023_003DzOVvHcTmyizH3(_0023_003Dz0tskLJQ_003D.Indices[3], _0023_003Dz9j4kMjs_003D.Principals), _0023_003DzOVvHcTmyizH3(_0023_003Dz0tskLJQ_003D.Indices[4], _0023_003Dz9j4kMjs_003D.Principals), _0023_003DzOVvHcTmyizH3(_0023_003Dz0tskLJQ_003D.Indices[5], _0023_003Dz9j4kMjs_003D.Principals), _0023_003DzOVvHcTmyizH3(_0023_003Dz0tskLJQ_003D.Indices[6], _0023_003Dz9j4kMjs_003D.Principals), _0023_003DzOVvHcTmyizH3(_0023_003Dz0tskLJQ_003D.Indices[7], _0023_003Dz9j4kMjs_003D.Principals)) : Element.WeightedAverage(_0023_003DzOVvHcTmyizH3(_0023_003Dz0tskLJQ_003D.Indices[0], _0023_003Dz9j4kMjs_003D.Principals), _0023_003DzOVvHcTmyizH3(_0023_003Dz0tskLJQ_003D.Indices[1], _0023_003Dz9j4kMjs_003D.Principals), _0023_003DzOVvHcTmyizH3(_0023_003Dz0tskLJQ_003D.Indices[2], _0023_003Dz9j4kMjs_003D.Principals), _0023_003DzOVvHcTmyizH3(_0023_003Dz0tskLJQ_003D.Indices[3], _0023_003Dz9j4kMjs_003D.Principals), _0023_003DzOVvHcTmyizH3(_0023_003Dz0tskLJQ_003D.Indices[4], _0023_003Dz9j4kMjs_003D.Principals), _0023_003DzOVvHcTmyizH3(_0023_003Dz0tskLJQ_003D.Indices[5], _0023_003Dz9j4kMjs_003D.Principals))));
		_0023_003Dz0tskLJQ_003D.Centroid._0023_003DzefHtJcxwG1M2((float)num);
	}

	private double _0023_003DzOVvHcTmyizH3(int _0023_003DzyzK8swU_003D, double[,] _0023_003DzO0AO3iPnQw1B)
	{
		return _0023_003DzO0AO3iPnQw1B[_0023_003DzyzK8swU_003D, 0] - _0023_003DzO0AO3iPnQw1B[_0023_003DzyzK8swU_003D, 2];
	}

	private void _0023_003DzSD2VGcFsye5d(double _0023_003Dzik60_0024SI_003D, int _0023_003DzAdg8iZA_003D)
	{
		if (_0023_003Dzik60_0024SI_003D < minValue)
		{
			minValue = _0023_003Dzik60_0024SI_003D;
			_minNode = _0023_003DzAdg8iZA_003D;
		}
		if (_0023_003Dzik60_0024SI_003D > maxValue)
		{
			maxValue = _0023_003Dzik60_0024SI_003D;
			_maxNode = _0023_003DzAdg8iZA_003D;
		}
	}

	private void _0023_003DzSD2VGcFsye5d(double _0023_003Dzik60_0024SI_003D, Element _0023_003Dz9j4kMjs_003D, int _0023_003DzAdg8iZA_003D)
	{
		if (_0023_003Dzik60_0024SI_003D < minValue)
		{
			minValue = _0023_003Dzik60_0024SI_003D;
			_minNode = _0023_003Dz9j4kMjs_003D.Connection[_0023_003DzAdg8iZA_003D];
		}
		if (_0023_003Dzik60_0024SI_003D > maxValue)
		{
			maxValue = _0023_003Dzik60_0024SI_003D;
			_maxNode = _0023_003Dz9j4kMjs_003D.Connection[_0023_003DzAdg8iZA_003D];
		}
	}

	private void _0023_003DzSD2VGcFsye5d(double _0023_003Dzik60_0024SI_003D)
	{
		if (_0023_003Dzik60_0024SI_003D < minValue)
		{
			minValue = _0023_003Dzik60_0024SI_003D;
		}
		if (_0023_003Dzik60_0024SI_003D > maxValue)
		{
			maxValue = _0023_003Dzik60_0024SI_003D;
		}
	}

	public override void Compile(CompileParams data)
	{
		InitGraphicsData(data.RenderContext);
		_0023_003DzSrny2FmSPIa7();
		if (plotMode != plotType.Mesh)
		{
			Element[] array = elements;
			foreach (Element element in array)
			{
				if (element.Faces == null)
				{
					continue;
				}
				Element.Face[] faces = element.Faces;
				foreach (Element.Face face in faces)
				{
					if (face.Visible)
					{
						face.UpdateCentroidUnknowns(element, _vertices, _modeIndex);
					}
				}
			}
		}
		double num = ((plotMode == plotType.Mesh || ClippingPlane != null) ? 0.0 : _ampFactor);
		if (!_0023_003DzYRjT6IDEacGA(drawSolved ?? drawMesh, drawEdges, drawIsocurves, _ampFactor, num, _modeIndex, data))
		{
			data.RenderContext.Compile(drawMesh, _0023_003DzjQZcReUZZAAF, num);
		}
		if (ClippingPlane != null)
		{
			foreach (Mesh elementsSlice in _elementsSlices)
			{
				elementsSlice.Compile(data);
			}
		}
		RegenMode = regenType.NotNeeded;
	}

	private void _0023_003DzmHTSerA_003D(ref EntityGraphicsData _0023_003Dz_Bn_pNI_003D, ref EntityGraphicsData _0023_003DzU3hosSAzkxO7, ref EntityGraphicsData _0023_003DzK0CBHhifjry5CAw04w_003D_003D, double _0023_003DzEza9bR0ay362, int _0023_003Dzg9C1BOA_003D, CompileParams _0023_003DzELu0Pss_003D)
	{
		if (_0023_003Dz_Bn_pNI_003D == null)
		{
			_0023_003Dz_Bn_pNI_003D = _0023_003DzELu0Pss_003D.RenderContext.CreateEntityGraphicsData(this);
		}
		if (_0023_003DzU3hosSAzkxO7 == null)
		{
			_0023_003DzU3hosSAzkxO7 = _0023_003DzELu0Pss_003D.RenderContext.CreateEntityGraphicsData(this);
		}
		if (_0023_003DzK0CBHhifjry5CAw04w_003D_003D == null)
		{
			_0023_003DzK0CBHhifjry5CAw04w_003D_003D = _0023_003DzELu0Pss_003D.RenderContext.CreateEntityGraphicsData(this);
		}
		if (plotMode != plotType.Mesh && !(ClippingPlane != null))
		{
			_0023_003DzYRjT6IDEacGA(_0023_003Dz_Bn_pNI_003D, _0023_003DzU3hosSAzkxO7, _0023_003DzK0CBHhifjry5CAw04w_003D_003D, _ampFactor, _0023_003DzEza9bR0ay362, _0023_003Dzg9C1BOA_003D, _0023_003DzELu0Pss_003D);
			RegenMode = regenType.NotNeeded;
		}
	}

	private bool _0023_003DzYRjT6IDEacGA(EntityGraphicsData _0023_003Dz_Bn_pNI_003D, EntityGraphicsData _0023_003DzU3hosSAzkxO7, EntityGraphicsData _0023_003DzK0CBHhifjry5CAw04w_003D_003D, double _0023_003DzdtLaKqS_0024RfjJ, double _0023_003DzEza9bR0ay362, int _0023_003Dzg9C1BOA_003D, CompileParams _0023_003DzELu0Pss_003D)
	{
		bool result = false;
		if (solved && _0023_003DzELu0Pss_003D.Legend != null && plotMode != plotType.Mesh)
		{
			_0023_003DzFIL5egV6HutA45oxHQ_003D_003D _0023_003DzFIL5egV6HutA45oxHQ_003D_003D2 = new _0023_003DzFIL5egV6HutA45oxHQ_003D_003D();
			_0023_003DzFIL5egV6HutA45oxHQ_003D_003D2.ampFactor = _0023_003DzEza9bR0ay362;
			_0023_003DzFIL5egV6HutA45oxHQ_003D_003D2.Mode = _0023_003Dzg9C1BOA_003D;
			_0023_003DzFIL5egV6HutA45oxHQ_003D_003D2._0023_003Dz4vK0VMtpHANN(_0023_003DzELu0Pss_003D.Legend);
			_0023_003DzFIL5egV6HutA45oxHQ_003D_003D2.floatPerSingleVertex = new int[3] { 3, 3, 1 };
			_0023_003DzFIL5egV6HutA45oxHQ_003D_003D myParams = _0023_003DzFIL5egV6HutA45oxHQ_003D_003D2;
			_0023_003DzELu0Pss_003D.RenderContext.Compile(_0023_003Dz_Bn_pNI_003D, DrawEntity, myParams);
			result = true;
		}
		if (IsBeamStudy)
		{
			if (solved)
			{
				_0023_003DzELu0Pss_003D.RenderContext.Compile(_0023_003DzU3hosSAzkxO7, _0023_003DzORJwJTTDWJwL6xEBzSbuX80_003D, new Mesh.DrawEdgesInternalParams
				{
					ampFactor = _0023_003DzEza9bR0ay362,
					Mode = _0023_003Dzg9C1BOA_003D
				});
			}
			else
			{
				_0023_003DzELu0Pss_003D.RenderContext.Compile(drawEdges, _0023_003DzEwB1FnodY9X3QmPmnA_003D_003D, _ampFactor);
			}
		}
		else if (_0023_003Dz_Bn_pNI_003D != null)
		{
			_0023_003DzELu0Pss_003D.RenderContext.Compile(_0023_003DzU3hosSAzkxO7, _0023_003DzaB7C7dEFLEMV, new Mesh.DrawEdgesInternalParams
			{
				ampFactor = _0023_003DzEza9bR0ay362,
				Mode = _0023_003Dzg9C1BOA_003D
			});
		}
		if (skin != null)
		{
			_0023_003DzELu0Pss_003D.RenderContext.Compile(_0023_003DzK0CBHhifjry5CAw04w_003D_003D, delegate(RenderContextBase _0023_003DzB8iS0QA_003D, object _0023_003DzmPmPjCPqZ3T3)
			{
				Mesh.DrawEdgesInternalParams drawEdgesInternalParams = (Mesh.DrawEdgesInternalParams)_0023_003DzmPmPjCPqZ3T3;
				int length = isoEdges.GetLength(0);
				if (length > 0)
				{
					Point3D[] array = new Point3D[length * 2];
					int num = 0;
					for (int i = 0; i < isoEdges.GetLength(0); i++)
					{
						array[num++] = (Node)_vertices[isoEdges[i, 0]];
						array[num++] = (Node)_vertices[isoEdges[i, 1]];
					}
					double ampFactor = ((ClippingPlane != null) ? 0.0 : drawEdgesInternalParams.ampFactor);
					int mode = drawEdgesInternalParams.Mode;
					_0023_003DzB8iS0QA_003D.DrawLinesWithDisplacement(array, ampFactor, mode);
				}
			}, new Mesh.DrawEdgesInternalParams
			{
				ampFactor = _0023_003DzEza9bR0ay362,
				Mode = _0023_003Dzg9C1BOA_003D
			});
		}
		if (IsBeamStudy && solved && plotMode != plotType.Mesh)
		{
			_0023_003DzELu0Pss_003D.RenderContext.Compile(drawSelected, _0023_003DzrL9aDqyMSvbW3ZWvvfXcRBw_003D, new Mesh.DrawEdgesInternalParams
			{
				ampFactor = _0023_003DzEza9bR0ay362
			});
		}
		else
		{
			_0023_003DzELu0Pss_003D.RenderContext.Compile(drawSelected, _0023_003Dz98HbA5UMZagp, new Mesh.DrawEdgesInternalParams
			{
				ampFactor = _0023_003DzEza9bR0ay362,
				Mode = _0023_003Dzg9C1BOA_003D
			});
		}
		silhoData = null;
		return result;
	}

	private void _0023_003DzrL9aDqyMSvbW3ZWvvfXcRBw_003D(RenderContextBase _0023_003DzQdnFby4_003D, object _0023_003DzmPmPjCPqZ3T3)
	{
		_0023_003DzEPZjC6M4LrX_0024(_0023_003DzQdnFby4_003D, _0023_003DzmPmPjCPqZ3T3, _0023_003Dzz1fGUs2oBc0E: false);
	}

	private void _0023_003Dz98HbA5UMZagp(RenderContextBase _0023_003DzB8iS0QA_003D, object _0023_003DzmPmPjCPqZ3T3)
	{
		Mesh.DrawEdgesInternalParams drawEdgesInternalParams = (Mesh.DrawEdgesInternalParams)_0023_003DzmPmPjCPqZ3T3;
		int mode = drawEdgesInternalParams.Mode;
		Element[] array = elements;
		foreach (Element element in array)
		{
			if (element is Element2D)
			{
				Vector3D singleNormal = Vector3D.AxisZ;
				if (element.Connection.Length > 2)
				{
					singleNormal = new Vector3D(_vertices[element.Connection[0]], _vertices[element.Connection[1]], _vertices[element.Connection[2]]);
				}
				element.Draw(_0023_003DzB8iS0QA_003D, singleNormal, _vertices, drawEdgesInternalParams.ampFactor, mode);
			}
			else
			{
				element.Draw(_0023_003DzB8iS0QA_003D, null, _vertices, drawEdgesInternalParams.ampFactor, mode);
			}
		}
	}

	private void _0023_003DzjQZcReUZZAAF(RenderContextBase _0023_003DzB8iS0QA_003D, object _0023_003DzmPmPjCPqZ3T3)
	{
		_0023_003DzB8iS0QA_003D.ColorMaterialMode = colorMaterialType.FrontAndBackFaceDiffuse;
		Vector3D singleNormal = Vector3D.AxisZ;
		int numberOfDimensions = NumberOfDimensions;
		if ((uint)(numberOfDimensions - 2) <= 1u || numberOfDimensions == 6)
		{
			Element[] array = elements;
			foreach (Element element in array)
			{
				if (!(element is Joint2D))
				{
					if (element.Connection.Length > 2)
					{
						singleNormal = new Vector3D(_vertices[element.Connection[0]], _vertices[element.Connection[1]], _vertices[element.Connection[2]]);
					}
					element.Draw(_0023_003DzB8iS0QA_003D, singleNormal, element.Material.Diffuse, _vertices, (double)_0023_003DzmPmPjCPqZ3T3, _modeIndex);
				}
			}
		}
		_0023_003DzB8iS0QA_003D.ColorMaterialMode = colorMaterialType.Disabled;
	}

	private void _0023_003DzaB7C7dEFLEMV(RenderContextBase _0023_003DzB8iS0QA_003D, object _0023_003DzmPmPjCPqZ3T3)
	{
		if (skin != null)
		{
			Mesh.DrawEdgesInternalParams drawEdgesInternalParams = (Mesh.DrawEdgesInternalParams)_0023_003DzmPmPjCPqZ3T3;
			if (drawEdgesInternalParams.ampFactor == 0.0)
			{
				_0023_003DzB8iS0QA_003D.DrawIndexLines(skin.Edges, skin.Vertices);
			}
			else if (skin.Edges.Length != 0)
			{
				_0023_003DzB8iS0QA_003D.DrawIndexLinesWithDisplacement(skin.Edges, skin.Vertices, drawEdgesInternalParams.ampFactor, drawEdgesInternalParams.Mode);
			}
		}
	}

	private void _0023_003DzUTJEzV_0024I3Dc0OtqjrQ1FdU4_003D(RenderContextBase _0023_003DzB8iS0QA_003D, object _0023_003DzmPmPjCPqZ3T3)
	{
		Mesh.DrawEdgesInternalParams drawEdgesInternalParams = (Mesh.DrawEdgesInternalParams)_0023_003DzmPmPjCPqZ3T3;
		int length = isoEdges.GetLength(0);
		if (length > 0)
		{
			Point3D[] array = new Point3D[length * 2];
			int num = 0;
			for (int i = 0; i < isoEdges.GetLength(0); i++)
			{
				array[num++] = (Node)_vertices[isoEdges[i, 0]];
				array[num++] = (Node)_vertices[isoEdges[i, 1]];
			}
			double ampFactor = ((ClippingPlane != null) ? 0.0 : drawEdgesInternalParams.ampFactor);
			int mode = drawEdgesInternalParams.Mode;
			_0023_003DzB8iS0QA_003D.DrawLinesWithDisplacement(array, ampFactor, mode);
		}
	}

	protected override void DrawEntity(RenderContextBase context, object myParams)
	{
		_0023_003DzEPZjC6M4LrX_0024(context, myParams, _0023_003Dzz1fGUs2oBc0E: true);
	}

	private void _0023_003DzEPZjC6M4LrX_0024(RenderContextBase _0023_003DzB8iS0QA_003D, object _0023_003DzmPmPjCPqZ3T3, bool _0023_003Dzz1fGUs2oBc0E)
	{
		Vector3D axisZ = Vector3D.AxisZ;
		Mesh.DrawEdgesInternalParams drawEdgesInternalParams = (Mesh.DrawEdgesInternalParams)_0023_003DzmPmPjCPqZ3T3;
		double _0023_003DzEza9bR0ay = ((ClippingPlane != null) ? 0.0 : drawEdgesInternalParams.ampFactor);
		ILegend _0023_003DzmPmPjCPqZ3T4 = ((drawEdgesInternalParams is _0023_003DzFIL5egV6HutA45oxHQ_003D_003D _0023_003DzFIL5egV6HutA45oxHQ_003D_003D2) ? _0023_003DzFIL5egV6HutA45oxHQ_003D_003D2._0023_003DzPSXhlRzLAPhX() : null);
		int mode = drawEdgesInternalParams.Mode;
		if (IsBeamStudy)
		{
			if (plotMode == plotType.U || plotMode == plotType.Ux || plotMode == plotType.Uy || plotMode == plotType.Uz || plotMode == plotType.Rx || plotMode == plotType.Ry || plotMode == plotType.Rz)
			{
				if (_0023_003Dzz1fGUs2oBc0E)
				{
					_0023_003DzjIcxbNvgTTdRDSMKZQ_003D_003D(_0023_003DzB8iS0QA_003D, axisZ, _0023_003DzmPmPjCPqZ3T4, _0023_003DzEza9bR0ay, mode);
				}
				else
				{
					_0023_003DzdkRFMwdBsNVK9b8euA_003D_003D(_0023_003DzB8iS0QA_003D, _0023_003DzEza9bR0ay, mode);
				}
			}
			else if (_0023_003Dzz1fGUs2oBc0E)
			{
				_0023_003DzcA4TY9RfBw2sh4Z63g_003D_003D(_0023_003DzB8iS0QA_003D, axisZ, _0023_003DzmPmPjCPqZ3T4, _0023_003DzEza9bR0ay, mode);
			}
			else
			{
				_0023_003DzdkRFMwdBsNVK9b8euA_003D_003D(_0023_003DzB8iS0QA_003D, _0023_003DzEza9bR0ay, mode);
			}
		}
		else if (nodalAverages || plotMode == plotType.U || plotMode == plotType.Ux || plotMode == plotType.Uy || plotMode == plotType.Uz)
		{
			_0023_003DzjIcxbNvgTTdRDSMKZQ_003D_003D(_0023_003DzB8iS0QA_003D, axisZ, _0023_003DzmPmPjCPqZ3T4, _0023_003DzEza9bR0ay, mode);
		}
		else
		{
			_0023_003DzcA4TY9RfBw2sh4Z63g_003D_003D(_0023_003DzB8iS0QA_003D, axisZ, _0023_003DzmPmPjCPqZ3T4, _0023_003DzEza9bR0ay, mode);
		}
	}

	private void _0023_003DzORJwJTTDWJwL6xEBzSbuX80_003D(RenderContextBase _0023_003DzB8iS0QA_003D, object _0023_003DzmPmPjCPqZ3T3)
	{
		Mesh.DrawEdgesInternalParams drawEdgesInternalParams = (Mesh.DrawEdgesInternalParams)_0023_003DzmPmPjCPqZ3T3;
		if (IsBeam2DStudy)
		{
			Element[] array = elements;
			for (int i = 0; i < array.Length; i++)
			{
				((Beam2D)array[i])._0023_003DzKfIdo2NWu204LV9ttQ_003D_003D(_0023_003DzB8iS0QA_003D, _vertices, drawEdgesInternalParams.ampFactor, drawEdgesInternalParams.Mode);
			}
		}
		else
		{
			Element[] array = elements;
			for (int i = 0; i < array.Length; i++)
			{
				((Beam)array[i])._0023_003DzKfIdo2NWu204LV9ttQ_003D_003D(_0023_003DzB8iS0QA_003D, _vertices, drawEdgesInternalParams.ampFactor, drawEdgesInternalParams.Mode);
			}
		}
	}

	private void _0023_003DzEwB1FnodY9X3QmPmnA_003D_003D(RenderContextBase _0023_003DzB8iS0QA_003D, object _0023_003DzmPmPjCPqZ3T3)
	{
		if (IsBeam2DStudy)
		{
			Element[] array = elements;
			for (int i = 0; i < array.Length; i++)
			{
				Beam2D beam2D = (Beam2D)array[i];
				beam2D._0023_003DzkneD3LGNB66GilGpDvl14cU_003D(_0023_003DzB8iS0QA_003D, (Node)_vertices[beam2D.Connection[0]], (Node)_vertices[beam2D.Connection[1]]);
			}
		}
		else
		{
			Element[] array = elements;
			for (int i = 0; i < array.Length; i++)
			{
				Beam beam = (Beam)array[i];
				beam._0023_003DzkneD3LGNB66GilGpDvl14cU_003D(_0023_003DzB8iS0QA_003D, (Node)_vertices[beam.Connection[0]], (Node)_vertices[beam.Connection[1]]);
			}
		}
	}

	private void _0023_003DzcA4TY9RfBw2sh4Z63g_003D_003D(RenderContextBase _0023_003DzB8iS0QA_003D, Vector3D _0023_003DzSJ5J1_uojj_s, object _0023_003DzmPmPjCPqZ3T3, double _0023_003DzEza9bR0ay362, int _0023_003Dzg9C1BOA_003D)
	{
		Element[] array = elements;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].DrawWithSharpColorElement(_0023_003DzB8iS0QA_003D, _0023_003DzSJ5J1_uojj_s, _vertices, minValue, maxValue, _0023_003DzEza9bR0ay362, _0023_003Dzg9C1BOA_003D);
		}
	}

	private void _0023_003DzdkRFMwdBsNVK9b8euA_003D_003D(RenderContextBase _0023_003DzB8iS0QA_003D, double _0023_003DzEza9bR0ay362, int _0023_003Dzg9C1BOA_003D)
	{
		Element[] array = elements;
		for (int i = 0; i < array.Length; i++)
		{
			array[i]._0023_003DzunNCduq2e6bD2pZW0evxPv0_003D(_0023_003DzB8iS0QA_003D, _vertices, _0023_003DzEza9bR0ay362, _0023_003Dzg9C1BOA_003D);
		}
	}

	private void _0023_003DzjIcxbNvgTTdRDSMKZQ_003D_003D(RenderContextBase _0023_003DzB8iS0QA_003D, Vector3D _0023_003DzSJ5J1_uojj_s, object _0023_003DzmPmPjCPqZ3T3, double _0023_003DzEza9bR0ay362, int _0023_003Dzg9C1BOA_003D)
	{
		Element[] array = elements;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].DrawWithSharpColor(_0023_003DzB8iS0QA_003D, _0023_003DzSJ5J1_uojj_s, _vertices, minValue, maxValue, _0023_003DzEza9bR0ay362, _0023_003Dzg9C1BOA_003D);
		}
	}

	protected internal override void DrawFlat(DrawParams data)
	{
		if (data.ShaderParams != null || data.RenderContext.IsDirect3D)
		{
			data.ShaderParams.RenderContext.PushShader();
			SetShader(data);
		}
		_0023_003DzMasDKnav2nxX(data, _0023_003DzpdX56LA_003D: true);
		if (data.ShaderParams != null || data.RenderContext.IsDirect3D)
		{
			data.ShaderParams.RenderContext.PopShader();
		}
	}

	protected internal override void Draw(DrawParams data)
	{
		_0023_003DzMasDKnav2nxX(data, _0023_003DzpdX56LA_003D: false);
	}

	private void _0023_003DzMasDKnav2nxX(DrawParams _0023_003DzELu0Pss_003D, bool _0023_003DzpdX56LA_003D)
	{
		if (_0023_003DzELu0Pss_003D.ForceGray)
		{
			_0023_003DzELu0Pss_003D.RenderContext.Draw(drawSelected);
			return;
		}
		if (plotMode != plotType.Mesh && solved && drawSolved.IsValid())
		{
			_0023_003DzJEiCNqlYb39U(contourPlot, texture1D, _0023_003DzELu0Pss_003D, _0023_003DzpdX56LA_003D, out var _0023_003DzkaLw0SPLbhK0W9uDYA_003D_003D, out var _0023_003DzQjF9MKbOP7L, out var _0023_003DzHHapgdI86YwJ);
			_0023_003Dz8Fgh2f0_003D(_0023_003DzELu0Pss_003D, out var _0023_003DznJIGqTg0iaIrNJ1XXA_003D_003D);
			if (ClippingPlane == null && drawSolvedFrames != null && drawSolvedFrames[FrameNumber] != null)
			{
				_0023_003DzELu0Pss_003D.RenderContext.Draw(drawSolvedFrames[FrameNumber]);
			}
			else
			{
				_0023_003DzELu0Pss_003D.RenderContext.Draw(drawSolved);
			}
			_0023_003Dzx3KKsq6OhWKT(_0023_003DzELu0Pss_003D, _0023_003DznJIGqTg0iaIrNJ1XXA_003D_003D);
			foreach (Mesh elementsSlice in _elementsSlices)
			{
				elementsSlice.Draw(_0023_003DzELu0Pss_003D);
			}
			_0023_003DzabFld05zU9Mg(texture1D, _0023_003DzELu0Pss_003D, _0023_003DzkaLw0SPLbhK0W9uDYA_003D_003D, _0023_003DzQjF9MKbOP7L, _0023_003DzHHapgdI86YwJ);
			return;
		}
		_0023_003Dz8Fgh2f0_003D(_0023_003DzELu0Pss_003D, out var _0023_003DznJIGqTg0iaIrNJ1XXA_003D_003D2);
		_0023_003DzELu0Pss_003D.RenderContext.Draw(drawMesh);
		_0023_003DzELu0Pss_003D.RenderContext.ResetColorDiffuse();
		_0023_003Dzx3KKsq6OhWKT(_0023_003DzELu0Pss_003D, _0023_003DznJIGqTg0iaIrNJ1XXA_003D_003D2);
		foreach (Mesh elementsSlice2 in _elementsSlices)
		{
			elementsSlice2.Draw(_0023_003DzELu0Pss_003D);
		}
	}

	internal static void _0023_003DzJEiCNqlYb39U(bool _0023_003Dzdenf_0024oLiBhwsN1SrJQ_003D_003D, TextureBase _0023_003Dz8IhIScfiD2b0, DrawParams _0023_003DzELu0Pss_003D, bool _0023_003DzpdX56LA_003D, out Color _0023_003DzkaLw0SPLbhK0W9uDYA_003D_003D, out Color _0023_003DzQjF9MKbOP7L6, out Color _0023_003DzHHapgdI86YwJ)
	{
		_0023_003DzkaLw0SPLbhK0W9uDYA_003D_003D = _0023_003DzELu0Pss_003D.RenderContext.CurrentMaterial.Diffuse;
		_0023_003DzQjF9MKbOP7L6 = _0023_003DzELu0Pss_003D.RenderContext.CurrentMaterial.Ambient;
		_0023_003DzHHapgdI86YwJ = _0023_003DzELu0Pss_003D.RenderContext.CurrentBackMaterial.Ambient;
		Material defaultMaterial = _0023_003DzELu0Pss_003D.viewportInternal.parent.DefaultMaterial;
		Color ambient = Color.FromArgb(25, 25, 25);
		_0023_003DzELu0Pss_003D.RenderContext.SetMaterial(defaultMaterial.Diffuse, defaultMaterial.Diffuse, ambient, defaultMaterial.Specular, defaultMaterial.Shininess);
		if (_0023_003Dz8IhIScfiD2b0 != null)
		{
			_0023_003DzELu0Pss_003D.RenderContext.SetTexture(_0023_003Dz8IhIScfiD2b0);
			_0023_003DzELu0Pss_003D.RenderContext.SetMaterialFrontAndBackDiffuse(Color.FromArgb(_0023_003DzkaLw0SPLbhK0W9uDYA_003D_003D.A, 255, 255, 255));
			if (_0023_003DzpdX56LA_003D)
			{
				_0023_003DzELu0Pss_003D.RenderContext.SetMaterialFrontAmbient(Color.White);
				_0023_003DzELu0Pss_003D.RenderContext.SetMaterialBackAmbient(Color.White);
			}
		}
		if (_0023_003Dz8IhIScfiD2b0 != null)
		{
			_0023_003DzELu0Pss_003D.RenderContext.SetTexture1DWrapMode(clamp: true);
		}
		else
		{
			_0023_003DzELu0Pss_003D.RenderContext.ColorMaterialMode = colorMaterialType.FrontAndBackFaceDiffuse;
		}
	}

	internal static void _0023_003DzabFld05zU9Mg(TextureBase _0023_003Dz8IhIScfiD2b0, DrawParams _0023_003DzELu0Pss_003D, Color _0023_003DzkaLw0SPLbhK0W9uDYA_003D_003D, Color _0023_003DzQjF9MKbOP7L6, Color _0023_003DzHHapgdI86YwJ)
	{
		if (_0023_003Dz8IhIScfiD2b0 != null)
		{
			_0023_003DzELu0Pss_003D.RenderContext.SetTexture1DWrapMode(clamp: false);
			_0023_003DzELu0Pss_003D.RenderContext.CloseTexture();
		}
		else
		{
			_0023_003DzELu0Pss_003D.RenderContext.ColorMaterialMode = colorMaterialType.Disabled;
			_0023_003DzELu0Pss_003D.RenderContext.ResetColorDiffuse();
		}
		_0023_003DzELu0Pss_003D.RenderContext.SetMaterialFrontAndBackDiffuse(_0023_003DzkaLw0SPLbhK0W9uDYA_003D_003D);
		_0023_003DzELu0Pss_003D.RenderContext.SetMaterialFrontAmbient(_0023_003DzQjF9MKbOP7L6);
		_0023_003DzELu0Pss_003D.RenderContext.SetMaterialBackAmbient(_0023_003DzHHapgdI86YwJ);
	}

	private void _0023_003Dzx3KKsq6OhWKT(DrawParams _0023_003DzELu0Pss_003D, ClippingPlane _0023_003DznJIGqTg0iaIrNJ1XXA_003D_003D)
	{
		bool flag = ClippingMethod == clippingMethodType.ByElement;
		if (ClippingPlane != null && !flag && RegenMode != regenType.RegenAndCompile)
		{
			IViewportInternal viewportInternal = _0023_003DzELu0Pss_003D.viewportInternal;
			viewportInternal.parent.ClippingPlane1 = _0023_003DznJIGqTg0iaIrNJ1XXA_003D_003D;
			_0023_003DzELu0Pss_003D.RenderContext.ProcessClippingPlanes(viewportInternal.parent.clippingPlanes, updateGraphics: true);
		}
	}

	private void _0023_003Dz8Fgh2f0_003D(DrawParams _0023_003DzELu0Pss_003D, out ClippingPlane _0023_003DznJIGqTg0iaIrNJ1XXA_003D_003D)
	{
		_0023_003DznJIGqTg0iaIrNJ1XXA_003D_003D = null;
		bool flag = ClippingMethod == clippingMethodType.ByElement;
		if (ClippingPlane != null && !flag && RegenMode != regenType.RegenAndCompile)
		{
			IViewportInternal viewportInternal = _0023_003DzELu0Pss_003D.viewportInternal;
			_0023_003DznJIGqTg0iaIrNJ1XXA_003D_003D = viewportInternal.parent.ClippingPlane1;
			viewportInternal.parent.ClippingPlane1 = new ClippingPlane(ClippingPlane, active: true);
			_0023_003DzELu0Pss_003D.RenderContext.ProcessClippingPlanes(viewportInternal.parent.clippingPlanes, updateGraphics: true);
		}
	}

	protected internal override void SetShader(DrawParams data)
	{
		if (data.Selected || data.ForceGray)
		{
			base.SetShader(data);
		}
		else if (plotMode == plotType.Mesh || !solved)
		{
			if (!data.ShaderParams.Lighting)
			{
				data.ShaderParams.MulticolorNoLightsWithNormals = true;
			}
			else
			{
				data.ShaderParams.Multicolor = true;
			}
			base.SetShader(data);
			data.ShaderParams.MulticolorNoLightsWithNormals = false;
			data.ShaderParams.Multicolor = false;
		}
		else
		{
			data.ShaderParams.Texture1D = true;
			base.SetShader(data);
			data.ShaderParams.Texture1D = false;
		}
	}

	protected internal override void DrawWireframe(DrawParams data)
	{
		if (skin != null)
		{
			_0023_003Dz8Fgh2f0_003D(data, out var _0023_003DznJIGqTg0iaIrNJ1XXA_003D_003D);
			if (ClippingPlane == null && drawIsocurvesFrames != null && drawIsocurvesFrames[FrameNumber] != null)
			{
				data.RenderContext.Draw(drawIsocurvesFrames[FrameNumber]);
			}
			else
			{
				data.RenderContext.Draw(drawIsocurves);
			}
			_0023_003Dzx3KKsq6OhWKT(data, _0023_003DznJIGqTg0iaIrNJ1XXA_003D_003D);
		}
		data.RenderContext.PushShader();
		data.RenderContext.SetShader(shaderType.MultiColorNoLights);
		_0023_003DzlYxz_0024XngiT_x6iwgAw_003D_003D(data.RenderContext);
		data.RenderContext.PopShader();
	}

	private void _0023_003DzlYxz_0024XngiT_x6iwgAw_003D_003D(RenderContextBase _0023_003DzB8iS0QA_003D)
	{
		double diagonal = new Size3D(localMin, localMax).Diagonal;
		Element[] array = elements;
		foreach (Element element in array)
		{
			if (element is Truss2D)
			{
				((Truss2D)element)._0023_003DzaXawPti23jEv(_0023_003DzB8iS0QA_003D, _vertices, _ampFactor);
			}
			else if (element is Truss)
			{
				((Truss)element)._0023_003DzaXawPti23jEv(_0023_003DzB8iS0QA_003D, _vertices, _ampFactor);
			}
			else if (element is Beam)
			{
				((Beam)element)._0023_003DzaXawPti23jEv(_0023_003DzB8iS0QA_003D, _vertices, _ampFactor, diagonal);
			}
			else if (element is Beam2D)
			{
				((Beam2D)element)._0023_003DzaXawPti23jEv(_0023_003DzB8iS0QA_003D, _vertices, _ampFactor, diagonal);
			}
		}
	}

	protected internal override void DrawIsocurves(DrawParams data)
	{
		if (skin != null)
		{
			_0023_003Dz8Fgh2f0_003D(data, out var _0023_003DznJIGqTg0iaIrNJ1XXA_003D_003D);
			if (ClippingPlane == null && PlotMode != plotType.Mesh && drawIsocurvesFrames != null && drawIsocurvesFrames[FrameNumber] != null)
			{
				data.RenderContext.Draw(drawIsocurvesFrames[FrameNumber]);
			}
			else
			{
				data.RenderContext.Draw(drawIsocurves);
			}
			_0023_003Dzx3KKsq6OhWKT(data, _0023_003DznJIGqTg0iaIrNJ1XXA_003D_003D);
		}
		foreach (Mesh elementsSlice in _elementsSlices)
		{
			elementsSlice.DrawIsocurves(data);
		}
	}

	protected internal override void DrawIsocurvesForFlat(DrawParams data)
	{
		DrawIsocurves(data);
	}

	protected internal override void DrawSelected(DrawParams data)
	{
		data.RenderContext.Draw(drawSelected);
	}

	protected internal override void DrawForDepthPass(DrawParams data)
	{
		_0023_003DzMasDKnav2nxX(data, _0023_003DzpdX56LA_003D: false);
	}

	protected internal override void DrawForShadow(RenderParams data)
	{
		_0023_003Dz8Fgh2f0_003D(data, out var _0023_003DznJIGqTg0iaIrNJ1XXA_003D_003D);
		data.RenderContext.Draw(drawSelected);
		_0023_003Dzx3KKsq6OhWKT(data, _0023_003DznJIGqTg0iaIrNJ1XXA_003D_003D);
		foreach (Mesh elementsSlice in _elementsSlices)
		{
			elementsSlice.DrawSelected(data);
		}
	}

	protected internal override void DrawEdges(DrawParams data)
	{
		if (IsBeamStudy)
		{
			if (data.Viewport.DisplayMode != displayType.Wireframe)
			{
				if (plotMode == plotType.Mesh && drawEdges.IsValid())
				{
					data.RenderContext.Draw(drawEdges);
				}
				else if (drawEdgesFrames != null && drawEdgesFrames[FrameNumber] != null)
				{
					data.RenderContext.Draw(drawEdgesFrames[FrameNumber]);
				}
				else
				{
					data.RenderContext.Draw(drawEdges);
				}
			}
		}
		else if (skin != null)
		{
			if (ClippingPlane == null && PlotMode != plotType.Mesh && drawEdgesFrames != null && drawEdgesFrames[FrameNumber] != null)
			{
				data.RenderContext.Draw(drawEdgesFrames[FrameNumber]);
			}
			else
			{
				data.RenderContext.Draw(drawEdges);
			}
		}
	}

	protected internal override void DrawForSelection(DrawForSelectionParams data)
	{
		_0023_003Dz8Fgh2f0_003D(data, out var _0023_003DznJIGqTg0iaIrNJ1XXA_003D_003D);
		data.RenderContext.Draw(drawSelected);
		_0023_003Dzx3KKsq6OhWKT(data, _0023_003DznJIGqTg0iaIrNJ1XXA_003D_003D);
	}

	internal override SilhoWireData _0023_003DzEt1XHB_xc_BLLBoMbJmskWU_003D(PreProcessSilhouettesParams _0023_003DzELu0Pss_003D)
	{
		return HiddenLinesView._0023_003DzHN4TT0c7MLm_0024AVFCx8_L2g4_003D(this, _0023_003DzELu0Pss_003D.Parents);
	}

	protected internal override void DrawHiddenLinesMaterial(RenderParams data)
	{
		data.RenderContext.PushShader();
		SetShader(data);
		_0023_003DzMasDKnav2nxX(data, !data.viewportInternal.parent.HiddenLines.Lighting);
		data.RenderContext.PopShader();
	}

	protected internal override void DrawHiddenLinesMaterialFast(RenderParams data)
	{
		data.RenderContext.PushShader();
		SetShader(data);
		IViewportInternal viewportInternal = data.viewportInternal;
		if (base.entityNature == entityNatureType.Polygon || base.entityNature == entityNatureType.RichPolygon)
		{
			data.RenderContext.PushRasterizerState();
			data.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceFront_PolygonOffset_1_1);
			_0023_003DzMasDKnav2nxX(data, !viewportInternal.parent.HiddenLines.Lighting);
			data.RenderContext.PopRasterizerState();
		}
		_0023_003DzMasDKnav2nxX(data, !viewportInternal.parent.HiddenLines.Lighting);
		data.RenderContext.PopShader();
	}

	protected internal override void DrawHiddenLines(DrawParams data)
	{
		IViewportInternal viewportInternal = (IViewportInternal)data.Viewport;
		if (viewportInternal.parent.HiddenLines.ColorMethod != hiddenLinesColorMethodType.SingleColor)
		{
			data.RenderContext.PushShader();
			SetShader(data);
			_0023_003DzMasDKnav2nxX(data, !viewportInternal.parent.HiddenLines.Lighting);
			data.RenderContext.PopShader();
			return;
		}
		_0023_003Dz8Fgh2f0_003D(data, out var _0023_003DznJIGqTg0iaIrNJ1XXA_003D_003D);
		data.RenderContext.Draw(drawSelected);
		_0023_003Dzx3KKsq6OhWKT(data, _0023_003DznJIGqTg0iaIrNJ1XXA_003D_003D);
		foreach (Mesh elementsSlice in _elementsSlices)
		{
			elementsSlice.DrawSelected(data);
		}
	}

	protected internal override void DrawSilhouettes(DrawSilhouettesParams data)
	{
		HiddenLinesView._0023_003DzY9TYF9sTjnZYO51HtXX26S0_003D(this, data);
	}

	protected internal void DrawRestraints(RenderContextBase context, EntityGraphicsData drawRestraintSymbol, EntityGraphicsData drawTraRestraint, EntityGraphicsData drawRotRestraint)
	{
		double[] array = new double[16];
		for (int i = 0; i < _vertices.Length; i++)
		{
			Node node = (Node)_vertices[i];
			if (node is NodeBeam)
			{
				NodeBeam nodeBeam = (NodeBeam)node;
				if (!nodeBeam.Restrained && !nodeBeam.RotationRestrained)
				{
					continue;
				}
				bool _0023_003DzRBp0ovQaJTSK = false;
				if (nodeBeam.Rotation != null)
				{
					devDept.Geometry.Rotation rotation = nodeBeam.Rotation;
					array[0] = rotation.Matrix[0, 0];
					array[1] = rotation.Matrix[0, 1];
					array[2] = rotation.Matrix[0, 2];
					array[4] = rotation.Matrix[1, 0];
					array[5] = rotation.Matrix[1, 1];
					array[6] = rotation.Matrix[1, 2];
					array[8] = rotation.Matrix[2, 0];
					array[9] = rotation.Matrix[2, 1];
					array[10] = rotation.Matrix[2, 2];
					array[15] = 1.0;
					_0023_003DzRBp0ovQaJTSK = true;
				}
				if (!nodeBeam.Restrained)
				{
					if (nodeBeam.rotationRestraints[0])
					{
						_0023_003Dzaj1GQEvXFp9J9kuIyyEhE7suJlc6(context, i, drawRotRestraint, _0023_003DzRBp0ovQaJTSK, array);
					}
					if (nodeBeam.rotationRestraints[1])
					{
						_0023_003DzSSaJeMHPVFzKj_0024plvGpPwGApGkPT(context, i, drawRotRestraint, _0023_003DzRBp0ovQaJTSK, array);
					}
					if (NumberOfDimensions > 2 && nodeBeam.rotationRestraints[2])
					{
						_0023_003DzW8SlabN0ylvaCjwK3Il9MNKRjYtO(context, i, drawRotRestraint, _0023_003DzRBp0ovQaJTSK, array);
					}
					continue;
				}
				if (!nodeBeam.RotationRestrained)
				{
					if (node.Restraints[0])
					{
						_0023_003Dzaj1GQEvXFp9J9kuIyyEhE7suJlc6(context, i, drawTraRestraint, _0023_003DzRBp0ovQaJTSK, array);
					}
					if (node.Restraints[1])
					{
						_0023_003DzSSaJeMHPVFzKj_0024plvGpPwGApGkPT(context, i, drawTraRestraint, _0023_003DzRBp0ovQaJTSK, array);
					}
					if (NumberOfDimensions > 2 && node.Restraints[2])
					{
						_0023_003DzW8SlabN0ylvaCjwK3Il9MNKRjYtO(context, i, drawTraRestraint, _0023_003DzRBp0ovQaJTSK, array);
					}
					continue;
				}
				if (nodeBeam.Restraints[0] && nodeBeam.rotationRestraints[0])
				{
					_0023_003Dzaj1GQEvXFp9J9kuIyyEhE7suJlc6(context, i, drawRestraintSymbol, _0023_003DzRBp0ovQaJTSK, array);
				}
				else if (nodeBeam.Restraints[0] && !nodeBeam.rotationRestraints[0])
				{
					_0023_003Dzaj1GQEvXFp9J9kuIyyEhE7suJlc6(context, i, drawTraRestraint, _0023_003DzRBp0ovQaJTSK, array);
				}
				else if (!nodeBeam.Restraints[0] && nodeBeam.rotationRestraints[0])
				{
					_0023_003Dzaj1GQEvXFp9J9kuIyyEhE7suJlc6(context, i, drawRotRestraint, _0023_003DzRBp0ovQaJTSK, array);
				}
				if (nodeBeam.Restraints[1] && nodeBeam.rotationRestraints[1])
				{
					_0023_003DzSSaJeMHPVFzKj_0024plvGpPwGApGkPT(context, i, drawRestraintSymbol, _0023_003DzRBp0ovQaJTSK, array);
				}
				else if (nodeBeam.Restraints[1] && !nodeBeam.rotationRestraints[1])
				{
					_0023_003DzSSaJeMHPVFzKj_0024plvGpPwGApGkPT(context, i, drawTraRestraint, _0023_003DzRBp0ovQaJTSK, array);
				}
				else if (!nodeBeam.Restraints[1] && nodeBeam.rotationRestraints[1])
				{
					_0023_003DzSSaJeMHPVFzKj_0024plvGpPwGApGkPT(context, i, drawRotRestraint, _0023_003DzRBp0ovQaJTSK, array);
				}
				if (NumberOfDimensions > 2 && nodeBeam.Restraints[2] && nodeBeam.rotationRestraints[2])
				{
					_0023_003DzW8SlabN0ylvaCjwK3Il9MNKRjYtO(context, i, drawRestraintSymbol, _0023_003DzRBp0ovQaJTSK, array);
				}
				else if (nodeBeam.Restraints[2] && !nodeBeam.rotationRestraints[2])
				{
					_0023_003DzW8SlabN0ylvaCjwK3Il9MNKRjYtO(context, i, drawTraRestraint, _0023_003DzRBp0ovQaJTSK, array);
				}
				else if (!nodeBeam.Restraints[2] && nodeBeam.rotationRestraints[2])
				{
					_0023_003DzW8SlabN0ylvaCjwK3Il9MNKRjYtO(context, i, drawRotRestraint, _0023_003DzRBp0ovQaJTSK, array);
				}
			}
			else if (node.Restrained)
			{
				bool _0023_003DzRBp0ovQaJTSK2 = false;
				if (node.Rotation != null)
				{
					devDept.Geometry.Rotation rotation2 = node.Rotation;
					array[0] = rotation2.Matrix[0, 0];
					array[1] = rotation2.Matrix[0, 1];
					array[2] = rotation2.Matrix[0, 2];
					array[4] = rotation2.Matrix[1, 0];
					array[5] = rotation2.Matrix[1, 1];
					array[6] = rotation2.Matrix[1, 2];
					array[8] = rotation2.Matrix[2, 0];
					array[9] = rotation2.Matrix[2, 1];
					array[10] = rotation2.Matrix[2, 2];
					array[15] = 1.0;
					_0023_003DzRBp0ovQaJTSK2 = true;
				}
				if (node.Restraints[0])
				{
					_0023_003Dzaj1GQEvXFp9J9kuIyyEhE7suJlc6(context, i, drawTraRestraint, _0023_003DzRBp0ovQaJTSK2, array);
				}
				if (node.Restraints[1])
				{
					_0023_003DzSSaJeMHPVFzKj_0024plvGpPwGApGkPT(context, i, drawTraRestraint, _0023_003DzRBp0ovQaJTSK2, array);
				}
				if (NumberOfDimensions > 2 && node.Restraints[2])
				{
					_0023_003DzW8SlabN0ylvaCjwK3Il9MNKRjYtO(context, i, drawTraRestraint, _0023_003DzRBp0ovQaJTSK2, array);
				}
			}
		}
	}

	protected internal void DrawLoads(RenderContextBase context, EntityGraphicsData drawLoadSymbolData, EntityGraphicsData drawMomentSymbolData)
	{
		double[] array = new double[16];
		for (int i = 0; i < _vertices.Length; i++)
		{
			Node node = _vertices[i] as Node;
			if (node.Loaded)
			{
				bool _0023_003DzRBp0ovQaJTSK = false;
				if (node.Rotation != null)
				{
					devDept.Geometry.Rotation rotation = node.Rotation;
					array[0] = rotation.Matrix[0, 0];
					array[1] = rotation.Matrix[0, 1];
					array[2] = rotation.Matrix[0, 2];
					array[4] = rotation.Matrix[1, 0];
					array[5] = rotation.Matrix[1, 1];
					array[6] = rotation.Matrix[1, 2];
					array[8] = rotation.Matrix[2, 0];
					array[9] = rotation.Matrix[2, 1];
					array[10] = rotation.Matrix[2, 2];
					array[15] = 1.0;
					_0023_003DzRBp0ovQaJTSK = true;
				}
				_0023_003DzICWjdqy2zYFt(context, i, drawLoadSymbolData, _0023_003DzRBp0ovQaJTSK, array);
			}
			if (!(node is NodeBeam))
			{
				continue;
			}
			NodeBeam nodeBeam = (NodeBeam)node;
			bool _0023_003DzRBp0ovQaJTSK2 = false;
			if (nodeBeam.Rotation != null)
			{
				devDept.Geometry.Rotation rotation2 = nodeBeam.Rotation;
				array[0] = rotation2.Matrix[0, 0];
				array[1] = rotation2.Matrix[0, 1];
				array[2] = rotation2.Matrix[0, 2];
				array[4] = rotation2.Matrix[1, 0];
				array[5] = rotation2.Matrix[1, 1];
				array[6] = rotation2.Matrix[1, 2];
				array[8] = rotation2.Matrix[2, 0];
				array[9] = rotation2.Matrix[2, 1];
				array[10] = rotation2.Matrix[2, 2];
				array[15] = 1.0;
				_0023_003DzRBp0ovQaJTSK2 = true;
			}
			if (!nodeBeam.MomentLoaded)
			{
				continue;
			}
			if (NumberOfDimensions > 2)
			{
				if (nodeBeam.momentLoad[0] != 0.0)
				{
					Transformation _0023_003DzLS0sR0pzioXc = new devDept.Geometry.Rotation(Math.PI / 2.0, Vector3D.AxisY);
					_0023_003DzX_00249b4bh51I12qd2V7A_003D_003D(context, i, drawMomentSymbolData, _0023_003DzRBp0ovQaJTSK2, array, _0023_003DzLS0sR0pzioXc);
				}
				if (nodeBeam.momentLoad[1] != 0.0)
				{
					Transformation _0023_003DzLS0sR0pzioXc2 = new devDept.Geometry.Rotation(Utility.DegToRad(270.0), Vector3D.AxisX);
					_0023_003DzX_00249b4bh51I12qd2V7A_003D_003D(context, i, drawMomentSymbolData, _0023_003DzRBp0ovQaJTSK2, array, _0023_003DzLS0sR0pzioXc2);
				}
			}
			if (nodeBeam.momentLoad[2] != 0.0)
			{
				_0023_003DzX_00249b4bh51I12qd2V7A_003D_003D(context, i, drawMomentSymbolData, _0023_003DzRBp0ovQaJTSK2, array, null);
			}
		}
	}

	protected internal void DrawLoadsPress(RenderContextBase context, EntityGraphicsData drawLoadSymbolData)
	{
		double[] _0023_003DzKPUTl6c_003D = new double[16];
		for (int i = 0; i < elements.Length; i++)
		{
			Element element = elements[i];
			if (element.distLoad == null)
			{
				continue;
			}
			if (element is Element2D)
			{
				Element2D element2D = (Element2D)element;
				Element2D.Edge[] edges = element2D.Edges;
				foreach (Element2D.Edge edge in edges)
				{
					if (edge.NormalPressure != 0.0)
					{
						edge._0023_003DzC6uJhr2aAtLiXUpnqQ_003D_003D(_vertices, element2D.Connection, out var _0023_003DzCJkr8nY_003D, out var _0023_003DzaA_FhnNUXoi);
						Vector3D vector3D = Vector3D.Cross(Vector3D.AxisZ, _0023_003DzCJkr8nY_003D);
						if (vector3D.Normalize())
						{
							_0023_003DzxZpCkwvGc0mA(context, _0023_003DzaA_FhnNUXoi, Math.Sign(edge.NormalPressure) * vector3D, drawLoadSymbolData, _0023_003DzRBp0ovQaJTSK: false, _0023_003DzKPUTl6c_003D);
						}
					}
					if (edge.Pressure != null)
					{
						edge._0023_003DzC6uJhr2aAtLiXUpnqQ_003D_003D(_vertices, element2D.Connection, out var _, out var _0023_003DzaA_FhnNUXoi2);
						Vector3D vector3D2 = new Vector3D(edge.Pressure[0], edge.Pressure[1], 0.0);
						if (vector3D2.Normalize())
						{
							_0023_003DzxZpCkwvGc0mA(context, _0023_003DzaA_FhnNUXoi2, vector3D2, drawLoadSymbolData, _0023_003DzRBp0ovQaJTSK: false, _0023_003DzKPUTl6c_003D);
						}
					}
				}
			}
			else
			{
				if (!(element is Element3D))
				{
					continue;
				}
				Element.Face[] faces = element.Faces;
				foreach (Element.Face face in faces)
				{
					if (face.NormalPressure != 0.0)
					{
						face.ComputeCentroid(element, _vertices);
						if (element is Beam)
						{
							_0023_003DzxZpCkwvGc0mA(context, face.Centroid, Math.Sign(face.NormalPressure) * ((Beam)element).v, drawLoadSymbolData, _0023_003DzRBp0ovQaJTSK: false, _0023_003DzKPUTl6c_003D);
						}
						else
						{
							Vector3D vector3D3 = face._0023_003DzVfPopQvXf7dp_0024HjsGImY_B0_003D(_vertices, element.Connection);
							if (vector3D3.Normalize())
							{
								_0023_003DzxZpCkwvGc0mA(context, face.Centroid, -Math.Sign(face.NormalPressure) * vector3D3, drawLoadSymbolData, _0023_003DzRBp0ovQaJTSK: false, _0023_003DzKPUTl6c_003D);
							}
						}
					}
					if (face.Pressure != null)
					{
						face.ComputeCentroid(element, _vertices);
						Vector3D vector3D4 = new Vector3D(face.Pressure[0], face.Pressure[1], face.Pressure[2]);
						if (vector3D4.Normalize())
						{
							_0023_003DzxZpCkwvGc0mA(context, face.Centroid, vector3D4, drawLoadSymbolData, _0023_003DzRBp0ovQaJTSK: false, _0023_003DzKPUTl6c_003D);
						}
					}
				}
			}
		}
	}

	protected internal void DrawPunctualForce(RenderContextBase context, EntityGraphicsData drawLoadSymbolData)
	{
		double[] _0023_003DzKPUTl6c_003D = new double[16];
		for (int i = 0; i < elements.Length; i++)
		{
			Element element = elements[i];
			if (element is Beam2D && ((Beam2D)element)._alongBeamLoad.Value != null)
			{
				Beam2D beam2D = (Beam2D)element;
				Vector3D vector3D = new Vector3D(_vertices[beam2D.Connection[0]], _vertices[beam2D.Connection[1]]);
				vector3D.Normalize();
				Vector3D vector3D2 = Vector3D.Cross(Vector3D.AxisZ, vector3D);
				vector3D2.Normalize();
				Transformation xform = new Align3D(new Plane(Point3D.Origin, vector3D, vector3D2), Plane.XY);
				Vector3D vector3D3 = (Vector3D)beam2D._alongBeamLoad.Value.Clone();
				vector3D3.TransformBy(xform);
				Point3D _0023_003DzoMNiNRw_003D = _vertices[beam2D.Connection[0]] + vector3D * beam2D._alongBeamLoad.Key;
				_0023_003DzxZpCkwvGc0mA(context, _0023_003DzoMNiNRw_003D, vector3D3, drawLoadSymbolData, _0023_003DzRBp0ovQaJTSK: false, _0023_003DzKPUTl6c_003D);
			}
			else if (element is Beam && ((Beam)element)._alongBeamLoad.Value != null)
			{
				Beam beam = (Beam)element;
				Vector3D vector3D4 = new Vector3D(_vertices[beam.Connection[0]], _vertices[beam.Connection[1]]);
				vector3D4.Normalize();
				Vector3D v = beam.v;
				Transformation xform2 = new Align3D(new Plane(Point3D.Origin, vector3D4, v), Plane.XY);
				Vector3D vector3D5 = (Vector3D)beam._alongBeamLoad.Value.Clone();
				vector3D5.TransformBy(xform2);
				Point3D _0023_003DzoMNiNRw_003D2 = _vertices[beam.Connection[0]] + vector3D4 * beam._alongBeamLoad.Key;
				_0023_003DzxZpCkwvGc0mA(context, _0023_003DzoMNiNRw_003D2, vector3D5, drawLoadSymbolData, _0023_003DzRBp0ovQaJTSK: false, _0023_003DzKPUTl6c_003D);
			}
		}
	}

	protected internal void DrawJoints(RenderContextBase context, EntityGraphicsData drawList2D, EntityGraphicsData drawList3D)
	{
		double[] array = new double[16];
		for (int i = 0; i < elements.Length; i++)
		{
			Element element = elements[i];
			if (element is Joint2D)
			{
				Joint2D joint2D = (Joint2D)element;
				array[0] = joint2D.rot[0, 0];
				array[1] = joint2D.rot[0, 1];
				array[2] = joint2D.rot[0, 2];
				array[4] = joint2D.rot[1, 0];
				array[5] = joint2D.rot[1, 1];
				array[6] = joint2D.rot[1, 2];
				array[8] = joint2D.rot[2, 0];
				array[9] = joint2D.rot[2, 1];
				array[10] = joint2D.rot[2, 2];
				array[15] = 1.0;
				if (joint2D is Joint3D)
				{
					_0023_003Dz9YDJ40RKEsW5(context, joint2D.Connection[0], drawList3D, _0023_003DzRBp0ovQaJTSK: true, array, 90f);
				}
				else
				{
					_0023_003Dz9YDJ40RKEsW5(context, joint2D.Connection[0], drawList2D, _0023_003DzRBp0ovQaJTSK: true, array, 90f);
				}
			}
		}
	}

	protected internal override void DrawVertices(DrawParams data)
	{
		data.RenderContext.DrawPoints(_vertices);
	}

	protected internal override void DrawNormals(DrawParams data)
	{
		double normalLength = GetNormalLength();
		Element[] array = elements;
		foreach (Element element in array)
		{
			Element.Face[] faces = element.Faces;
			foreach (Element.Face face in faces)
			{
				if (face.Visible && face.CornerNormals != null)
				{
					for (int k = 0; k < face.Indices.Length; k++)
					{
						Point3D point3D = Vertices[element.Connection[face.Indices[k]]];
						Vector3D vector3D = face.CornerNormals[k];
						data.RenderContext.DrawLine(point3D, point3D + vector3D * normalLength);
					}
				}
			}
		}
	}

	public void Extrude(Vector3D amount, int slices = 1)
	{
		int[] array = new int[elements.Length];
		for (int i = 0; i < elements.Length; i++)
		{
			array[i] = i;
		}
		Extrude(array, amount, slices);
	}

	public void Extrude(Plane pln, double inflateBy, Vector3D amount, int slices = 1)
	{
		Tuple<int, int>[] faces = GetFaces(pln, inflateBy);
		Extrude(faces, amount, slices);
	}

	public void Extrude(Plane plane, Interval alongX, Interval alongY, double inflateBy, Vector3D amount, int slices = 1)
	{
		Tuple<int, int>[] faces = GetFaces(plane, alongX, alongY, inflateBy);
		Extrude(faces, amount, slices);
	}

	public void Extrude(Point3D min, Point3D max, double inflateBy, Vector3D amount, int slices = 1)
	{
		Tuple<int, int>[] faces = GetFaces(min, max, inflateBy);
		Extrude(faces, amount, slices);
	}

	public void Extrude(Tuple<int, int>[] indices, Vector3D amount, int slices = 1)
	{
		List<int> list = new List<int>(indices.Length);
		foreach (Tuple<int, int> tuple in indices)
		{
			Element element = Elements[tuple.Item1];
			Element.Face face = element.Faces[tuple.Item2];
			int[] array = new int[face.Indices.Length];
			for (int j = 0; j < face.Indices.Length; j++)
			{
				array[j] = element.Connection[face.Indices[j]];
			}
			face._0023_003DzFPVyG4Y9TGyH(amount, slices, array, element.Material, this);
			if (element is Element2D)
			{
				list.Add(tuple.Item1);
			}
		}
		if (list.Count > 0)
		{
			List<Element> list2 = new List<Element>(Elements);
			for (int num = list2.Count - 1; num >= 0; num--)
			{
				if (list.Contains(num))
				{
					list2.RemoveAt(num);
				}
			}
			Elements = list2.ToArray();
		}
		MergeNearbyNodes();
	}

	public void Extrude(IList<int> elIndices, Vector3D amount, int slices)
	{
		if (_0023_003DzDhTB_nuhxQX3yjZQSJCZH_Y_003D(amount))
		{
			_0023_003Dza2ukdm_Uy8ai();
		}
		List<Element2D> list = new List<Element2D>(Elements.Length / 2);
		foreach (int elIndex in elIndices)
		{
			try
			{
				Element2D element2D = (Element2D)Elements[elIndex];
				list.Add(element2D);
				element2D.Extrude(amount, slices, this);
			}
			catch (Exception)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970083) + elIndex + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970068));
			}
		}
		List<Element> list2 = Elements.ToList();
		foreach (Element2D item in list)
		{
			list2.Remove(item);
		}
		Elements = list2.ToArray();
		MergeNearbyNodes();
	}

	public void MergeNearbyNodes()
	{
		Utility.ComputeBoundingBox(Vertices, out var boxMin, out var boxMax);
		double tol = new Size3D(boxMin, boxMax).Diagonal * Utility._0023_003DzheSR8QM7q9ya;
		MergeNearbyNodes(tol);
	}

	public void MergeNearbyNodes(double tol)
	{
		int _0023_003DzyDhNd0FB6wv = Vertices.Length;
		Point3D[] vertices = Vertices;
		Point3D[] sourceArray = _0023_003DzWu_o2hD_0024VlVY(vertices, ref _0023_003DzyDhNd0FB6wv, tol);
		Element[] array = Elements;
		foreach (Element element in array)
		{
			for (int j = 0; j < element.Connection.Length; j++)
			{
				element.Connection[j] = (int)vertices[element.Connection[j]].X;
			}
		}
		Vertices = new Point3D[_0023_003DzyDhNd0FB6wv];
		Array.Copy(sourceArray, Vertices, _0023_003DzyDhNd0FB6wv);
	}

	private void _0023_003Dz3_0024MJgZrKIeKZStxVbQ_003D_003D(int _0023_003DzlVBJOHWrwdu_2sxx2Q_003D_003D)
	{
		Utility.ComputeBoundingBox(Vertices, out var boxMin, out var boxMax);
		double _0023_003Dzm0CYiiE_003D = new Size3D(boxMin, boxMax).Diagonal * Utility._0023_003DzheSR8QM7q9ya;
		_0023_003Dz3_0024MJgZrKIeKZStxVbQ_003D_003D(_0023_003DzlVBJOHWrwdu_2sxx2Q_003D_003D, _0023_003Dzm0CYiiE_003D);
	}

	private void _0023_003Dz3_0024MJgZrKIeKZStxVbQ_003D_003D(int _0023_003DzlVBJOHWrwdu_2sxx2Q_003D_003D, double _0023_003Dzm0CYiiE_003D)
	{
		int _0023_003DzyDhNd0FB6wv = Vertices.Length;
		Point3D[] vertices = Vertices;
		Point3D[] sourceArray = _0023_003DzpIe_KLqxlfHnkbyIE1pNkck_003D(vertices, ref _0023_003DzyDhNd0FB6wv, _0023_003Dzm0CYiiE_003D, _0023_003DzlVBJOHWrwdu_2sxx2Q_003D_003D);
		Element[] array = Elements;
		foreach (Element element in array)
		{
			for (int j = 0; j < element.Connection.Length; j++)
			{
				element.Connection[j] = (int)vertices[element.Connection[j]].X;
			}
		}
		Vertices = new Point3D[_0023_003DzyDhNd0FB6wv];
		Array.Copy(sourceArray, Vertices, _0023_003DzyDhNd0FB6wv);
	}

	public void Revolve(Plane pln, double inflateBy, double angle, Vector3D axis, Point3D center, int slices = 1)
	{
		Tuple<int, int>[] faces = GetFaces(pln, inflateBy);
		Revolve(faces, angle, axis, center, slices);
	}

	public void Revolve(Plane plane, Interval alongX, Interval alongY, double inflateBy, double angle, Vector3D axis, Point3D center, int slices = 1)
	{
		Tuple<int, int>[] faces = GetFaces(plane, alongX, alongY, inflateBy);
		Revolve(faces, angle, axis, center, slices);
	}

	public void Revolve(Point3D min, Point3D max, double inflateBy, double angle, Vector3D axis, Point3D center, int slices = 1)
	{
		Tuple<int, int>[] faces = GetFaces(min, max, inflateBy);
		Revolve(faces, angle, axis, center, slices);
	}

	public void Revolve(Tuple<int, int>[] indices, double angle, Vector3D axis, Point3D center, int slices = 1)
	{
		List<int> list = new List<int>(indices.Length);
		foreach (Tuple<int, int> tuple in indices)
		{
			Element element = Elements[tuple.Item1];
			Element.Face face = element.Faces[tuple.Item2];
			int[] array = new int[face.Indices.Length];
			for (int j = 0; j < face.Indices.Length; j++)
			{
				array[j] = element.Connection[face.Indices[j]];
			}
			face._0023_003DzZsKpvYbXHCDE(angle, axis, center, slices, array, element.Material, this);
			if (element is Element2D)
			{
				list.Add(tuple.Item1);
			}
		}
		if (list.Count > 0)
		{
			List<Element> list2 = new List<Element>(Elements);
			for (int num = list2.Count - 1; num >= 0; num--)
			{
				if (list.Contains(num))
				{
					list2.RemoveAt(num);
				}
			}
			Elements = list2.ToArray();
		}
		MergeNearbyNodes();
	}

	public void Revolve(double angle, Vector3D axis, Point3D center, int slices = 1)
	{
		int[] array = new int[elements.Length];
		for (int i = 0; i < elements.Length; i++)
		{
			array[i] = i;
		}
		Revolve(array, angle, axis, center, slices);
	}

	public void Revolve(IList<int> elIndices, double angle, Vector3D axis, Point3D center, int slices = 1)
	{
		if (_0023_003DznAOVtCjJfaab(axis, center) ^ (angle < 0.0))
		{
			_0023_003Dza2ukdm_Uy8ai();
		}
		List<Element2D> list = new List<Element2D>(Elements.Length / 2);
		foreach (int elIndex in elIndices)
		{
			try
			{
				Element2D item = (Element2D)Elements[elIndex];
				list.Add(item);
				((Element2D)Elements[elIndex]).Revolve(angle, axis, center, slices, this);
			}
			catch (Exception)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970083) + elIndex + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970068));
			}
		}
		List<Element> list2 = Elements.ToList();
		foreach (Element2D item2 in list)
		{
			list2.Remove(item2);
		}
		Elements = list2.ToArray();
		MergeNearbyNodes();
	}

	private bool _0023_003DzDhTB_nuhxQX3yjZQSJCZH_Y_003D(Vector3D _0023_003DzxuJqjrs_003D)
	{
		Element element = Elements[0];
		Point3D[] array = new Point3D[3];
		if (element is Quad4)
		{
			array[0] = Vertices[element.Connection[0]];
			array[1] = Vertices[element.Connection[1]];
			array[2] = Vertices[element.Connection[3]];
		}
		else if (element is Quad8)
		{
			array[0] = Vertices[element.Connection[0]];
			array[1] = Vertices[element.Connection[2]];
			array[2] = Vertices[element.Connection[6]];
		}
		else if (element is Tria3)
		{
			array[0] = Vertices[element.Connection[0]];
			array[1] = Vertices[element.Connection[1]];
			array[2] = Vertices[element.Connection[2]];
		}
		else if (element is Tria6)
		{
			array[0] = Vertices[element.Connection[0]];
			array[1] = Vertices[element.Connection[2]];
			array[2] = Vertices[element.Connection[4]];
		}
		Plane plane = new Plane(array[0], array[1], array[2]);
		Vector3D vector3D = (Vector3D)_0023_003DzxuJqjrs_003D.Clone();
		vector3D.Normalize();
		if (Vector3D.AngleBetween(plane.AxisZ, vector3D) > Math.PI / 2.0)
		{
			return true;
		}
		return false;
	}

	private bool _0023_003DznAOVtCjJfaab(Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D)
	{
		Element element = Elements[0];
		Point3D[] array = new Point3D[element.NumberOfNodes];
		for (int i = 0; i < element.NumberOfNodes; i++)
		{
			array[i] = _vertices[element.Connection[i]];
		}
		return _0023_003Dz1_HSIV8Wmh99(array, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D);
	}

	private static bool _0023_003Dz1_HSIV8Wmh99(IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D)
	{
		Segment3D seg = new Segment3D(_0023_003DzbUvT9Pc_003D, _0023_003DzbUvT9Pc_003D + _0023_003DzxuJqjrs_003D);
		double num = double.MinValue;
		Plane plane = null;
		foreach (Point3D item in _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
		{
			Point3D point3D = item.ProjectTo(seg);
			double num2 = Math.Abs(Point3D.Distance(item, point3D));
			if (num2 > num)
			{
				num = num2;
				plane = new Plane(point3D, new Vector3D(point3D, item), new Vector3D(point3D, point3D + _0023_003DzxuJqjrs_003D));
			}
		}
		Transformation transformation = new Transformation();
		transformation.Rotation(plane, Plane.XY);
		int count = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count;
		Point3D[] array = new Point3D[count];
		for (int i = 0; i < count; i++)
		{
			Point3D point3D2 = (Point3D)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i].Clone();
			point3D2.TransformBy(transformation);
			array[i] = point3D2;
		}
		return !Utility.IsOrientedClockwise(array);
	}

	private void _0023_003Dza2ukdm_Uy8ai()
	{
		Element[] array = Elements;
		foreach (Element element in array)
		{
			List<int> list = new List<int>();
			list.Add(element.Connection[0]);
			for (int num = element.Connection.Length - 1; num > 0; num--)
			{
				list.Add(element.Connection[num]);
			}
			element.Connection = list.ToArray();
		}
	}

	public void RefineElements(int r, int s, int t = 1)
	{
		int num = elements.Length;
		int[] array = new int[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = i;
		}
		RefineElements(array, r, s, t);
	}

	public void RefineElements(IList<int> elIndices, int r, int s, int t = 1)
	{
		List<Element> list = new List<Element>(Elements.Length / 2);
		foreach (int elIndex in elIndices)
		{
			Element element = Elements[elIndex];
			list.Add(element);
			element.Refine(r, s, t, this);
		}
		List<Element> list2 = Elements.ToList();
		foreach (Element item in list)
		{
			list2.Remove(item);
		}
		Elements = list2.ToArray();
		MergeNearbyNodes();
	}

	public void DeleteUnusedNodes()
	{
		bool[] array = new bool[Vertices.Length];
		int[] array2 = new int[Vertices.Length];
		List<Point3D> list = new List<Point3D>();
		Element[] array3 = Elements;
		foreach (Element element in array3)
		{
			for (int j = 0; j < element.Connection.Length; j++)
			{
				int num = element.Connection[j];
				if (!array[num])
				{
					array[num] = true;
					array2[num] = list.Count;
					list.Add(Vertices[num]);
				}
				element.Connection[j] = array2[num];
			}
		}
		Vertices = list.ToArray();
	}

	public Tuple<int, int>[] GetFaces(Point3D min, Point3D max, double inflateBy)
	{
		min = new Point3D(min.X - inflateBy, min.Y - inflateBy, min.Z - inflateBy);
		max = new Point3D(max.X + inflateBy, max.Y + inflateBy, max.Z + inflateBy);
		List<Tuple<int, int>> list = new List<Tuple<int, int>>();
		for (int i = 0; i < Elements.Length; i++)
		{
			Element element = Elements[i];
			if (element.Faces == null)
			{
				continue;
			}
			for (int j = 0; j < element.Faces.Length; j++)
			{
				Element.Face face = element.Faces[j];
				int num = 0;
				byte[] indices = face.Indices;
				foreach (byte b in indices)
				{
					if (_vertices[element.Connection[b]].IsInside(min, max))
					{
						num++;
					}
				}
				if (num == face.Indices.Length)
				{
					list.Add(new Tuple<int, int>(i, j));
				}
			}
		}
		return list.ToArray();
	}

	public Tuple<int, int>[] GetFaces(Plane plane, double inflateBy)
	{
		return GetFaces(plane, new Interval(double.MinValue, double.MaxValue), new Interval(double.MinValue, double.MaxValue), inflateBy);
	}

	public Tuple<int, int>[] GetFaces(Plane plane, Interval alongX, Interval alongY, double inflateBy)
	{
		List<Tuple<int, int>> list = new List<Tuple<int, int>>();
		for (int i = 0; i < Elements.Length; i++)
		{
			Element element = Elements[i];
			if (element.Faces == null)
			{
				continue;
			}
			for (int j = 0; j < element.Faces.Length; j++)
			{
				Element.Face face = element.Faces[j];
				int num = 0;
				byte[] indices = face.Indices;
				foreach (byte b in indices)
				{
					Point3D point3D = _vertices[element.Connection[b]];
					double num2 = plane.DistanceTo(point3D);
					Point2D point2D = plane.Project(point3D);
					if (num2 <= inflateBy && num2 >= 0.0 - inflateBy && alongX.Low - inflateBy < point2D.X && point2D.X < alongX.High + inflateBy && alongY.Low - inflateBy < point2D.Y && point2D.Y < alongY.High + inflateBy)
					{
						num++;
					}
				}
				if (num == face.Indices.Length)
				{
					list.Add(new Tuple<int, int>(i, j));
				}
			}
		}
		return list.ToArray();
	}

	public Tuple<int, int>[] GetEdges(Point3D min, Point3D max, double inflateBy)
	{
		List<Tuple<int, int>> list = new List<Tuple<int, int>>();
		Segment3D segment3D = new Segment3D(min, max);
		double length = segment3D.Length;
		for (int i = 0; i < Elements.Length; i++)
		{
			Element element = Elements[i];
			int num = ((element.NumberOfNodes != 6 && element.NumberOfNodes != 8) ? 1 : 2);
			if (element.Faces == null)
			{
				continue;
			}
			for (int j = 0; j < element.Faces.Length; j++)
			{
				Element.Face face = element.Faces[j];
				for (int k = 0; k < face.Indices.Length; k += num)
				{
					int num2 = 0;
					byte b = face.Indices[k];
					Point3D point3D = _vertices[element.Connection[b]];
					double num3 = point3D.DistanceTo(segment3D);
					double num4 = segment3D.Project(point3D);
					if (num3 <= inflateBy && num4 >= (0.0 - inflateBy) / length && num4 <= 1.0 + inflateBy / length)
					{
						num2++;
					}
					b = face.Indices[(k + num != element.NumberOfNodes) ? (k + num) : 0];
					Point3D point3D2 = _vertices[element.Connection[b]];
					double num5 = point3D2.DistanceTo(segment3D);
					num4 = segment3D.Project(point3D2);
					if (num5 <= inflateBy && num4 >= (0.0 - inflateBy) / length && num4 <= 1.0 + inflateBy / length)
					{
						num2++;
					}
					if (num2 == 2)
					{
						list.Add(new Tuple<int, int>(i, k / num));
					}
				}
			}
		}
		return list.ToArray();
	}

	public Tuple<int, int>[] GetFaces(Point3D center, Vector3D axis, Vector3D refDir, double radius, double inflateBy)
	{
		return GetFaces(center, axis, refDir, radius, new Interval(0.0, Math.PI * 2.0), new Interval(double.MinValue, double.MaxValue), inflateBy);
	}

	public Tuple<int, int>[] GetFaces(Point3D center, Vector3D axis, Vector3D refDir, double radius, Interval angle, double inflateBy)
	{
		return GetFaces(center, axis, refDir, radius, angle, new Interval(double.MinValue, double.MaxValue), inflateBy);
	}

	public Tuple<int, int>[] GetFaces(Point3D center, Vector3D axis, Vector3D refDir, double radius, Interval angle, Interval distance, double inflateBy)
	{
		Plane plane = new Plane(center, refDir, Vector3D.Cross(axis, refDir));
		List<Tuple<int, int>> list = new List<Tuple<int, int>>();
		for (int i = 0; i < Elements.Length; i++)
		{
			Element element = Elements[i];
			if (element.Faces == null)
			{
				continue;
			}
			for (int j = 0; j < element.Faces.Length; j++)
			{
				Element.Face face = element.Faces[j];
				int num = 0;
				byte[] indices = face.Indices;
				foreach (byte b in indices)
				{
					Point3D point3D = _vertices[element.Connection[b]];
					Point2D point2D = plane.Project(point3D);
					double _0023_003DzFAg3lSY_003D = Utility.ArcTanProblem(point2D.X, point2D.Y);
					double length = new Vector2D(point2D.X, point2D.Y).Length;
					double _0023_003DzdBPA0pFHdNz9Ruu_7Q_003D_003D = plane.DistanceTo(point3D);
					if (_0023_003DzUgLqFy3mUCWMFbl0k4iGVTPAZ3Qt(_0023_003DzFAg3lSY_003D, length, radius, _0023_003DzdBPA0pFHdNz9Ruu_7Q_003D_003D, angle, distance, inflateBy))
					{
						num++;
					}
				}
				if (num == face.Indices.Length)
				{
					list.Add(new Tuple<int, int>(i, j));
				}
			}
		}
		return list.ToArray();
	}

	internal Tuple<int, int>[] _0023_003DzYm_0024NZRCNgy0n(IList<int> _0023_003DzDvuIQCU_003D)
	{
		List<Tuple<int, int>> list = new List<Tuple<int, int>>();
		for (int i = 0; i < Elements.Length; i++)
		{
			Element element = Elements[i];
			if (element.Faces == null)
			{
				continue;
			}
			for (int j = 0; j < element.Faces.Length; j++)
			{
				Element.Face face = element.Faces[j];
				bool flag = true;
				byte[] indices = face.Indices;
				foreach (byte b in indices)
				{
					if (!_0023_003DzDvuIQCU_003D.Contains(element.Connection[b]))
					{
						flag = false;
					}
				}
				if (flag)
				{
					list.Add(new Tuple<int, int>(i, j));
				}
			}
		}
		return list.ToArray();
	}

	public int[] GetNodes(Point3D min, Point3D max, double inflateBy)
	{
		min = new Point3D(min.X - inflateBy, min.Y - inflateBy, min.Z - inflateBy);
		max = new Point3D(max.X + inflateBy, max.Y + inflateBy, max.Z + inflateBy);
		List<int> list = new List<int>();
		for (int i = 0; i < Vertices.Length; i++)
		{
			if (Vertices[i].IsInside(min, max))
			{
				list.Add(i);
			}
		}
		return list.ToArray();
	}

	public int[] GetNodes(Plane plane, Interval alongX, Interval alongY, double inflateBy)
	{
		List<int> list = new List<int>();
		for (int i = 0; i < Vertices.Length; i++)
		{
			Point3D point3D = Vertices[i];
			double num = plane.DistanceTo(point3D);
			Point2D point2D = plane.Project(point3D);
			if (num <= inflateBy && num >= 0.0 - inflateBy && alongX.Low - inflateBy < point2D.X && point2D.X < alongX.High + inflateBy && alongY.Low - inflateBy < point2D.Y && point2D.Y < alongY.High + inflateBy)
			{
				list.Add(i);
			}
		}
		return list.ToArray();
	}

	public int[] GetNodes(Plane plane, double inflateBy)
	{
		return GetNodes(plane, new Interval(double.MinValue, double.MaxValue), new Interval(double.MinValue, double.MaxValue), inflateBy);
	}

	public int[] GetNodes(Point3D center, Vector3D axis, Vector3D refDir, double radius, double inflateBy)
	{
		return GetNodes(center, axis, refDir, radius, new Interval(0.0, Math.PI * 2.0), new Interval(double.MinValue, double.MaxValue), inflateBy);
	}

	public int[] GetNodes(Point3D center, Vector3D axis, Vector3D refDir, double radius, Interval angle, double inflateBy)
	{
		return GetNodes(center, axis, refDir, radius, angle, new Interval(double.MinValue, double.MaxValue), inflateBy);
	}

	public int[] GetNodes(Point3D center, Vector3D axis, Vector3D refDir, double radius, Interval angle, Interval distance, double inflateBy)
	{
		Plane plane = new Plane(center, refDir, Vector3D.Cross(axis, refDir));
		List<int> list = new List<int>();
		for (int i = 0; i < Vertices.Length; i++)
		{
			Point3D point3D = Vertices[i];
			Point2D point2D = plane.Project(point3D);
			double _0023_003DzFAg3lSY_003D = Utility.ArcTanProblem(point2D.X, point2D.Y);
			double length = new Vector2D(point2D.X, point2D.Y).Length;
			double _0023_003DzdBPA0pFHdNz9Ruu_7Q_003D_003D = plane.DistanceTo(point3D);
			if (_0023_003DzUgLqFy3mUCWMFbl0k4iGVTPAZ3Qt(_0023_003DzFAg3lSY_003D, length, radius, _0023_003DzdBPA0pFHdNz9Ruu_7Q_003D_003D, angle, distance, inflateBy))
			{
				list.Add(i);
			}
		}
		return list.ToArray();
	}

	private bool _0023_003DzUgLqFy3mUCWMFbl0k4iGVTPAZ3Qt(double _0023_003DzFAg3lSY_003D, double _0023_003Dz736ekIs_003D, double _0023_003DzEGKj_0024SNUUihi, double _0023_003DzdBPA0pFHdNz9Ruu_7Q_003D_003D, Interval _0023_003DzB9KeeIRujdWw, Interval _0023_003DzP5ixRzfF39kJ, double _0023_003DzsjDQiYI_003D)
	{
		if (_0023_003DzFAg3lSY_003D >= _0023_003DzB9KeeIRujdWw.Low && _0023_003DzFAg3lSY_003D <= _0023_003DzB9KeeIRujdWw.High && _0023_003Dz736ekIs_003D > _0023_003DzEGKj_0024SNUUihi - _0023_003DzsjDQiYI_003D && _0023_003Dz736ekIs_003D < _0023_003DzEGKj_0024SNUUihi + _0023_003DzsjDQiYI_003D && _0023_003DzdBPA0pFHdNz9Ruu_7Q_003D_003D > _0023_003DzP5ixRzfF39kJ.Low - _0023_003DzsjDQiYI_003D)
		{
			return _0023_003DzdBPA0pFHdNz9Ruu_7Q_003D_003D < _0023_003DzP5ixRzfF39kJ.High + _0023_003DzsjDQiYI_003D;
		}
		return false;
	}

	public void FixAllNodes(Point3D min, Point3D max, double inflateBy)
	{
		int[] nodes = GetNodes(min, max, inflateBy);
		FixAllNodes(nodes);
	}

	public void FixAllNodes(Plane plane, Interval alongX, Interval alongY, double inflateBy)
	{
		int[] nodes = GetNodes(plane, alongX, alongY, inflateBy);
		FixAllNodes(nodes);
	}

	public void FixAllNodes(Plane plane, double inflateBy)
	{
		int[] nodes = GetNodes(plane, inflateBy);
		FixAllNodes(nodes);
	}

	public void FixAllNodes(Point3D center, Vector3D axis, Vector3D refDir, double radius, double inflateBy)
	{
		int[] nodes = GetNodes(center, axis, refDir, radius, inflateBy);
		FixAllNodes(nodes);
	}

	public void FixAllNodes(Point3D center, Vector3D axis, Vector3D refDir, double radius, Interval angle, double inflateBy)
	{
		int[] nodes = GetNodes(center, axis, refDir, radius, angle, inflateBy);
		FixAllNodes(nodes);
	}

	public void FixAllNodes(Point3D center, Vector3D axis, Vector3D refDir, double radius, Interval angle, Interval distance, double inflateBy)
	{
		int[] nodes = GetNodes(center, axis, refDir, radius, angle, distance, inflateBy);
		FixAllNodes(nodes);
	}

	public void FixAllNodes(int[] nodeIndices)
	{
		for (int i = 0; i < nodeIndices.Length; i++)
		{
			((Node)_vertices[nodeIndices[i]]).SetRestraint(inX: true, inY: true, inZ: true);
		}
	}

	public void FixNodes(Point3D min, Point3D max, double inflateBy, bool x, bool y, bool z)
	{
		int[] nodes = GetNodes(min, max, inflateBy);
		FixNodes(nodes, x, y, z);
	}

	public void FixNodes(Plane plane, Interval alongX, Interval alongY, double inflateBy, bool x, bool y, bool z)
	{
		int[] nodes = GetNodes(plane, alongX, alongY, inflateBy);
		FixNodes(nodes, x, y, z);
	}

	public void FixNodes(Plane plane, double inflateBy, bool x, bool y, bool z)
	{
		int[] nodes = GetNodes(plane, inflateBy);
		FixNodes(nodes, x, y, z);
	}

	public void FixNodes(Point3D center, Vector3D axis, Vector3D refDir, double radius, double inflateBy, bool x, bool y, bool z)
	{
		int[] nodes = GetNodes(center, axis, refDir, radius, inflateBy);
		FixNodes(nodes, x, y, z);
	}

	public void FixNodes(Point3D center, Vector3D axis, Vector3D refDir, double radius, Interval angle, double inflateBy, bool x, bool y, bool z)
	{
		int[] nodes = GetNodes(center, axis, refDir, radius, angle, inflateBy);
		FixNodes(nodes, x, y, z);
	}

	public void FixNodes(Point3D center, Vector3D axis, Vector3D refDir, double radius, Interval angle, Interval distance, double inflateBy, bool x, bool y, bool z)
	{
		int[] nodes = GetNodes(center, axis, refDir, radius, angle, distance, inflateBy);
		FixNodes(nodes, x, y, z);
	}

	public void FixNodes(int[] nodeIndices, bool x, bool y, bool z)
	{
		for (int i = 0; i < nodeIndices.Length; i++)
		{
			((Node)_vertices[nodeIndices[i]]).SetRestraint(x, y, z);
		}
	}

	public int FixAll(Plane pln, double inflateBy)
	{
		Tuple<int, int>[] faces = GetFaces(pln, inflateBy);
		return FixAll(faces);
	}

	public int FixAll(Plane pln, Interval alongX, Interval alongY, double inflateBy)
	{
		Tuple<int, int>[] faces = GetFaces(pln, alongX, alongY, inflateBy);
		return FixAll(faces);
	}

	public int FixAll(Point3D min, Point3D max, double inflateBy)
	{
		Tuple<int, int>[] array = GetFaces(min, max, inflateBy);
		if (array.Length == 0)
		{
			array = GetEdges(min, max, inflateBy);
		}
		return FixAll(array);
	}

	public int FixAll(Point3D center, Vector3D axis, Vector3D refDir, double radius, double inflateBy)
	{
		Tuple<int, int>[] faces = GetFaces(center, axis, refDir, radius, inflateBy);
		return FixAll(faces);
	}

	public int FixAll(Point3D center, Vector3D axis, Vector3D refDir, double radius, Interval angle, double inflateBy)
	{
		Tuple<int, int>[] faces = GetFaces(center, axis, refDir, radius, angle, inflateBy);
		return FixAll(faces);
	}

	public int FixAll(Point3D center, Vector3D axis, Vector3D refDir, double radius, Interval angle, Interval distance, double inflateBy)
	{
		Tuple<int, int>[] faces = GetFaces(center, axis, refDir, radius, angle, distance, inflateBy);
		return FixAll(faces);
	}

	public int FixAll(Tuple<int, int>[] indices)
	{
		int num = 0;
		foreach (Tuple<int, int> tuple in indices)
		{
			Element element = Elements[tuple.Item1];
			int item = tuple.Item2;
			if (element is Element2D)
			{
				Element.Face face = element.Faces[0];
				if (element.NumberOfNodes == 6 || element.NumberOfNodes == 8)
				{
					((Node)_vertices[element.Connection[face.Indices[item * 2]]]).SetRestraint(inX: true, inY: true);
					((Node)_vertices[element.Connection[face.Indices[item * 2 + 1]]]).SetRestraint(inX: true, inY: true);
					((Node)_vertices[element.Connection[face.Indices[(item * 2 + 2 == 6) ? (item * 2) : (item * 2 + 2)]]]).SetRestraint(inX: true, inY: true);
				}
				else
				{
					((Node)_vertices[element.Connection[face.Indices[item]]]).SetRestraint(inX: true, inY: true);
					((Node)_vertices[element.Connection[face.Indices[(item + 1 == 3) ? item : (item + 1)]]]).SetRestraint(inX: true, inY: true);
				}
				num++;
			}
			else
			{
				Element.Face face2 = element.Faces[item];
				for (int j = 0; j < face2.Indices.Length; j++)
				{
					((Node)_vertices[element.Connection[face2.Indices[j]]]).SetRestraint(inX: true, inY: true, inZ: true);
					num++;
				}
			}
		}
		return num;
	}

	public int Fix(Plane plane, double inflateBy, bool x, bool y, bool z)
	{
		Tuple<int, int>[] faces = GetFaces(plane, inflateBy);
		return Fix(faces, x, y, z);
	}

	public int Fix(Plane plane, Interval alongX, Interval alongY, double inflateBy, bool x, bool y, bool z)
	{
		Tuple<int, int>[] faces = GetFaces(plane, alongX, alongY, inflateBy);
		return Fix(faces, x, y, z);
	}

	public int Fix(Point3D min, Point3D max, double inflateBy, bool x, bool y, bool z)
	{
		Tuple<int, int>[] faces = GetFaces(min, max, inflateBy);
		return Fix(faces, x, y, z);
	}

	public int Fix(Point3D center, Vector3D axis, Vector3D refDir, double radius, double inflateBy, bool x, bool y, bool z)
	{
		Tuple<int, int>[] faces = GetFaces(center, axis, refDir, radius, inflateBy);
		return Fix(faces, x, y, z);
	}

	public int Fix(Point3D center, Vector3D axis, Vector3D refDir, double radius, Interval angle, double inflateBy, bool x, bool y, bool z)
	{
		Tuple<int, int>[] faces = GetFaces(center, axis, refDir, radius, angle, inflateBy);
		return Fix(faces, x, y, z);
	}

	public int Fix(Point3D center, Vector3D axis, Vector3D refDir, double radius, Interval angle, Interval distance, double inflateBy, bool x, bool y, bool z)
	{
		Tuple<int, int>[] faces = GetFaces(center, axis, refDir, radius, angle, distance, inflateBy);
		return Fix(faces, x, y, z);
	}

	public int Fix(Tuple<int, int>[] indices, bool x, bool y, bool z)
	{
		int num = 0;
		foreach (Tuple<int, int> tuple in indices)
		{
			Element element = Elements[tuple.Item1];
			Element.Face face = element.Faces[tuple.Item2];
			for (int j = 0; j < face.Indices.Length; j++)
			{
				((Node)_vertices[element.Connection[face.Indices[j]]]).SetRestraint(x, y, z);
				num++;
			}
		}
		return num;
	}

	public int SetPressure(Plane pln, double inflateBy, double pressure)
	{
		Tuple<int, int>[] faces = GetFaces(pln, inflateBy);
		return SetPressure(faces, pressure);
	}

	public int SetPressure(Plane pln, Interval alongX, Interval alongY, double inflateBy, double pressure)
	{
		Tuple<int, int>[] faces = GetFaces(pln, alongX, alongY, inflateBy);
		return SetPressure(faces, pressure);
	}

	public int SetPressure(Point3D min, Point3D max, double inflateBy, double pressure)
	{
		Tuple<int, int>[] array = GetFaces(min, max, inflateBy);
		if (array.Length == 0)
		{
			array = GetEdges(min, max, inflateBy);
		}
		return SetPressure(array, pressure);
	}

	public int SetPressure(Point3D center, Vector3D axis, Vector3D refDir, double radius, double inflateBy, double pressure)
	{
		Tuple<int, int>[] faces = GetFaces(center, axis, refDir, radius, inflateBy);
		return SetPressure(faces, pressure);
	}

	public int SetPressure(Point3D center, Vector3D axis, Vector3D refDir, double radius, Interval angle, double inflateBy, double pressure)
	{
		Tuple<int, int>[] faces = GetFaces(center, axis, refDir, radius, angle, inflateBy);
		return SetPressure(faces, pressure);
	}

	public int SetPressure(Point3D center, Vector3D axis, Vector3D refDir, double radius, Interval angle, Interval distance, double inflateBy, double pressure)
	{
		Tuple<int, int>[] faces = GetFaces(center, axis, refDir, radius, angle, distance, inflateBy);
		return SetPressure(faces, pressure);
	}

	public int SetPressure(Tuple<int, int>[] indices, double pressure)
	{
		int num = 0;
		foreach (Tuple<int, int> tuple in indices)
		{
			Elements[tuple.Item1].SetPressure(tuple.Item2, pressure, _vertices);
			num++;
		}
		return num;
	}

	public int SetPressure(Plane pln, double inflateBy, Vector3D pressure)
	{
		Tuple<int, int>[] faces = GetFaces(pln, inflateBy);
		return SetPressure(faces, pressure);
	}

	public int SetPressure(Plane pln, Interval alongX, Interval alongY, double inflateBy, Vector3D pressure)
	{
		Tuple<int, int>[] faces = GetFaces(pln, alongX, alongY, inflateBy);
		return SetPressure(faces, pressure);
	}

	public int SetPressure(Point3D min, Point3D max, double inflateBy, Vector3D pressure)
	{
		Tuple<int, int>[] array = GetFaces(min, max, inflateBy);
		if (array.Length == 0)
		{
			array = GetEdges(min, max, inflateBy);
		}
		return SetPressure(array, pressure);
	}

	public int SetPressure(Point3D center, Vector3D axis, Vector3D refDir, double radius, double inflateBy, Vector3D pressure)
	{
		Tuple<int, int>[] faces = GetFaces(center, axis, refDir, radius, inflateBy);
		return SetPressure(faces, pressure);
	}

	public int SetPressure(Point3D center, Vector3D axis, Vector3D refDir, double radius, Interval angle, double inflateBy, Vector3D pressure)
	{
		Tuple<int, int>[] faces = GetFaces(center, axis, refDir, radius, angle, inflateBy);
		return SetPressure(faces, pressure);
	}

	public int SetPressure(Point3D center, Vector3D axis, Vector3D refDir, double radius, Interval angle, Interval distance, double inflateBy, Vector3D pressure)
	{
		Tuple<int, int>[] faces = GetFaces(center, axis, refDir, radius, angle, distance, inflateBy);
		return SetPressure(faces, pressure);
	}

	public int SetPressureOnFace(Vector3D amount, int index, Brep brep)
	{
		int[] nodesByFace = GetNodesByFace(index, brep);
		Tuple<int, int>[] indices = _0023_003DzYm_0024NZRCNgy0n(nodesByFace);
		return SetPressure(indices, amount);
	}

	public int SetForceOnFace(Vector3D amount, int index, Brep brep)
	{
		int[] nodesByFace = GetNodesByFace(index, brep);
		int num = nodesByFace.Length;
		int[] array = nodesByFace;
		foreach (int num2 in array)
		{
			((Node)Vertices[num2]).SetForce(amount.X / (double)num, amount.Y / (double)num, amount.Z / (double)num);
		}
		return nodesByFace.Length;
	}

	public int SetRestraintOnFace(bool onX, bool onY, bool onZ, int index, Brep brep, double amountInX = 0.0, double amountInY = 0.0, double amountInZ = 0.0)
	{
		int[] nodesByFace = GetNodesByFace(index, brep);
		int[] array = nodesByFace;
		foreach (int num in array)
		{
			((Node)Vertices[num]).SetRestraint(onX, onY, onZ, amountInX, amountInY, amountInZ);
		}
		return nodesByFace.Length;
	}

	public int SetForceOnEdge(Vector3D amount, int index, Brep brep)
	{
		int[] nodesByEdge = GetNodesByEdge(index, brep);
		int num = nodesByEdge.Length;
		int[] array = nodesByEdge;
		foreach (int num2 in array)
		{
			((Node)Vertices[num2]).SetForce(amount.X / (double)num, amount.Y / (double)num, amount.Z / (double)num);
		}
		return nodesByEdge.Length;
	}

	public int SetRestraintOnEdge(bool onX, bool onY, bool onZ, int index, Brep brep, double amountInX = 0.0, double amountInY = 0.0, double amountInZ = 0.0)
	{
		int[] nodesByEdge = GetNodesByEdge(index, brep);
		int[] array = nodesByEdge;
		foreach (int num in array)
		{
			((Node)Vertices[num]).SetRestraint(onX, onY, onZ, amountInX, amountInY, amountInZ);
		}
		return nodesByEdge.Length;
	}

	public int SetForceOnVertex(Vector3D amount, int index, Brep brep)
	{
		int[] nodesByVertex = GetNodesByVertex(index, brep);
		((Node)Vertices[nodesByVertex[0]]).SetForce(amount.X, amount.Y, amount.Z);
		return 1;
	}

	public int SetRestraintOnVertex(bool onX, bool onY, bool onZ, int index, Brep brep, double amountInX = 0.0, double amountInY = 0.0, double amountInZ = 0.0)
	{
		int[] nodesByVertex = GetNodesByVertex(index, brep);
		((Node)Vertices[nodesByVertex[0]]).SetRestraint(onX, onY, onZ, amountInX, amountInY, amountInZ);
		return 1;
	}

	private double[] _0023_003DzQPM8328W1NhdOBFhqA_003D_003D()
	{
		double[] array = new double[Vertices.Length];
		Element[] array2 = Elements;
		foreach (Element element in array2)
		{
			int[] connection = element.Connection;
			if (!(element is Tetra4))
			{
				if (!(element is Tetra10))
				{
					if (!(element is Penta6))
					{
						if (!(element is Penta15))
						{
							if (!(element is Hexa8))
							{
								if (element is Hexa20)
								{
									int num = connection[0];
									int num2 = connection[2];
									int num3 = connection[4];
									int num4 = connection[6];
									int num5 = connection[12];
									int num6 = connection[14];
									int num7 = connection[16];
									int num8 = connection[18];
									double num9 = Utility.HexahedronVolume(Vertices[num], Vertices[num2], Vertices[num3], Vertices[num4], Vertices[num5], Vertices[num6], Vertices[num7], Vertices[num8]) * element.Material.Density / 8.0;
									array[num] += num9;
									array[num2] += num9;
									array[num3] += num9;
									array[num4] += num9;
									array[num5] += num9;
									array[num6] += num9;
									array[num7] += num9;
									array[num8] += num9;
								}
							}
							else
							{
								int num10 = connection[0];
								int num11 = connection[1];
								int num12 = connection[2];
								int num13 = connection[3];
								int num14 = connection[4];
								int num15 = connection[5];
								int num16 = connection[6];
								int num17 = connection[7];
								double num18 = Utility.HexahedronVolume(Vertices[num10], Vertices[num11], Vertices[num12], Vertices[num13], Vertices[num14], Vertices[num15], Vertices[num16], Vertices[num17]) * element.Material.Density / 8.0;
								array[num10] += num18;
								array[num11] += num18;
								array[num12] += num18;
								array[num13] += num18;
								array[num14] += num18;
								array[num15] += num18;
								array[num16] += num18;
								array[num17] += num18;
							}
						}
						else
						{
							int num19 = connection[0];
							int num20 = connection[2];
							int num21 = connection[4];
							int num22 = connection[9];
							int num23 = connection[11];
							int num24 = connection[13];
							double num25 = Utility.PentahedronVolume(Vertices[num19], Vertices[num20], Vertices[num21], Vertices[num22], Vertices[num23], Vertices[num24]) * element.Material.Density / 6.0;
							array[num19] += num25;
							array[num20] += num25;
							array[num21] += num25;
							array[num22] += num25;
							array[num23] += num25;
							array[num24] += num25;
						}
					}
					else
					{
						int num26 = connection[0];
						int num27 = connection[1];
						int num28 = connection[2];
						int num29 = connection[3];
						int num30 = connection[4];
						int num31 = connection[5];
						double num32 = Utility.PentahedronVolume(Vertices[num26], Vertices[num27], Vertices[num28], Vertices[num29], Vertices[num30], Vertices[num31]) * element.Material.Density / 6.0;
						array[num26] += num32;
						array[num27] += num32;
						array[num28] += num32;
						array[num29] += num32;
						array[num30] += num32;
						array[num31] += num32;
					}
				}
				else
				{
					int num33 = connection[0];
					int num34 = connection[2];
					int num35 = connection[4];
					int num36 = connection[9];
					double num37 = Utility.TetrahedronVolume(Vertices[num33], Vertices[num34], Vertices[num35], Vertices[num36]) * element.Material.Density / 4.0;
					array[num33] += num37;
					array[num34] += num37;
					array[num35] += num37;
					array[num36] += num37;
				}
			}
			else
			{
				int num38 = connection[0];
				int num39 = connection[1];
				int num40 = connection[2];
				int num41 = connection[3];
				double num42 = Utility.TetrahedronVolume(Vertices[num38], Vertices[num39], Vertices[num40], Vertices[num41]) * element.Material.Density / 4.0;
				array[num38] += num42;
				array[num39] += num42;
				array[num40] += num42;
				array[num41] += num42;
			}
		}
		return array;
	}

	public Vector3D[] ComputeGravity()
	{
		return ComputeGravity(_0023_003Dzqbyy3C2zuui1RfLd1w_003D_003D);
	}

	public Vector3D[] ComputeGravity(Vector3D acceleration)
	{
		double[] array = _0023_003DzQPM8328W1NhdOBFhqA_003D_003D();
		int num = Vertices.Length;
		Vector3D[] array2 = new Vector3D[num];
		for (int i = 0; i < num; i++)
		{
			array2[i] = array[i] * acceleration;
		}
		return array2;
	}

	public void SetGravity()
	{
		SetGravity(_0023_003Dzqbyy3C2zuui1RfLd1w_003D_003D);
	}

	public void SetGravity(Vector3D acceleration)
	{
		Vector3D[] array = ComputeGravity(acceleration);
		for (int i = 0; i < Vertices.Length; i++)
		{
			Node node = (Node)Vertices[i];
			if (!node.Restrained && !array[i].IsZero)
			{
				node.SetForce(array[i]);
			}
		}
	}

	public int SetPressure(Tuple<int, int>[] indices, Vector3D pressure)
	{
		int num = 0;
		foreach (Tuple<int, int> tuple in indices)
		{
			Elements[tuple.Item1].SetPressure(tuple.Item2, pressure, _vertices);
			num++;
		}
		return num;
	}

	public void SetForce(Plane plane, double inflateBy, Vector3D amount)
	{
		int[] nodes = GetNodes(plane, inflateBy);
		_0023_003Dzt_OA2YE_003D(nodes, amount / nodes.Length);
	}

	public void SetForce(Plane plane, Interval alongX, Interval alongY, double inflateBy, Vector3D amount)
	{
		int[] nodes = GetNodes(plane, alongX, alongY, inflateBy);
		_0023_003Dzt_OA2YE_003D(nodes, amount / nodes.Length);
	}

	public void SetForce(Point3D min, Point3D max, double inflateBy, Vector3D amount)
	{
		int[] nodes = GetNodes(min, max, inflateBy);
		_0023_003Dzt_OA2YE_003D(nodes, amount / nodes.Length);
	}

	public void SetForce(Point3D center, Vector3D axis, Vector3D refDir, double radius, double inflateBy, Vector3D amount)
	{
		int[] nodes = GetNodes(center, axis, refDir, radius, inflateBy);
		_0023_003Dzt_OA2YE_003D(nodes, amount / nodes.Length);
	}

	public void SetForce(Point3D center, Vector3D axis, Vector3D refDir, double radius, Interval angle, double inflateBy, Vector3D amount)
	{
		int[] nodes = GetNodes(center, axis, refDir, radius, angle, inflateBy);
		_0023_003Dzt_OA2YE_003D(nodes, amount / nodes.Length);
	}

	public void SetForce(Point3D center, Vector3D axis, Vector3D refDir, double radius, Interval angle, Interval distance, double inflateBy, Vector3D amount)
	{
		int[] nodes = GetNodes(center, axis, refDir, radius, angle, distance, inflateBy);
		_0023_003Dzt_OA2YE_003D(nodes, amount / nodes.Length);
	}

	internal void _0023_003Dzt_OA2YE_003D(int[] _0023_003DzPJoLKSA_003D, Vector3D _0023_003DzYNjcavt9guh2)
	{
		int num = _0023_003DzPJoLKSA_003D.Length;
		for (int i = 0; i < num; i++)
		{
			((Node)Vertices[_0023_003DzPJoLKSA_003D[i]]).SetForce(_0023_003DzYNjcavt9guh2.X / (double)num, _0023_003DzYNjcavt9guh2.Y / (double)num, _0023_003DzYNjcavt9guh2.Z / (double)num);
		}
	}

	public void ConvertElementsToHexa20()
	{
		List<Point3D> list = Vertices.ToList();
		for (int i = 0; i < Elements.Length; i++)
		{
			Element element = Elements[i];
			if (element is Hexa8)
			{
				Elements[i] = ((Hexa8)element)._0023_003DzuqZUnnjQavZDSny_xA_003D_003D(element.Connection, list);
			}
		}
		int _0023_003DzlVBJOHWrwdu_2sxx2Q_003D_003D = Vertices.Length;
		Vertices = list.ToArray();
		_0023_003Dz3_0024MJgZrKIeKZStxVbQ_003D_003D(_0023_003DzlVBJOHWrwdu_2sxx2Q_003D_003D);
	}

	public void ConvertElementsToTetra10()
	{
		List<Point3D> list = Vertices.ToList();
		for (int i = 0; i < Elements.Length; i++)
		{
			Element element = Elements[i];
			if (element is Tetra4)
			{
				Elements[i] = ((Tetra4)element)._0023_003Dz7vpNB_ppVHTPtkqc4A_003D_003D(element.Connection, list);
			}
		}
		int _0023_003DzlVBJOHWrwdu_2sxx2Q_003D_003D = Vertices.Length;
		Vertices = list.ToArray();
		_0023_003Dz3_0024MJgZrKIeKZStxVbQ_003D_003D(_0023_003DzlVBJOHWrwdu_2sxx2Q_003D_003D);
	}

	public void ConvertElementsToPenta15()
	{
		List<Point3D> list = Vertices.ToList();
		for (int i = 0; i < Elements.Length; i++)
		{
			Element element = Elements[i];
			if (element is Penta6)
			{
				Elements[i] = ((Penta6)element)._0023_003DzOcMObUT_0024_0024_0024bvC7ZwCg_003D_003D(element.Connection, list);
			}
		}
		int _0023_003DzlVBJOHWrwdu_2sxx2Q_003D_003D = Vertices.Length;
		Vertices = list.ToArray();
		_0023_003Dz3_0024MJgZrKIeKZStxVbQ_003D_003D(_0023_003DzlVBJOHWrwdu_2sxx2Q_003D_003D);
	}

	public void ConvertElementsToTria6()
	{
		List<Point3D> list = Vertices.ToList();
		for (int i = 0; i < Elements.Length; i++)
		{
			Element element = Elements[i];
			if (element is Tria3)
			{
				Elements[i] = ((Tria3)element)._0023_003Dzjfhd66VFBfATvheb_g_003D_003D(element.Connection, list);
			}
		}
		int _0023_003DzlVBJOHWrwdu_2sxx2Q_003D_003D = Vertices.Length;
		Vertices = list.ToArray();
		_0023_003Dz3_0024MJgZrKIeKZStxVbQ_003D_003D(_0023_003DzlVBJOHWrwdu_2sxx2Q_003D_003D);
	}

	public void ConvertElementsToQuad8()
	{
		List<Point3D> list = Vertices.ToList();
		for (int i = 0; i < Elements.Length; i++)
		{
			Element element = Elements[i];
			if (element is Quad4)
			{
				Elements[i] = ((Quad4)element)._0023_003DzjKLmeSIGqK0l(element.Connection, list);
			}
		}
		int _0023_003DzlVBJOHWrwdu_2sxx2Q_003D_003D = Vertices.Length;
		Vertices = list.ToArray();
		_0023_003Dz3_0024MJgZrKIeKZStxVbQ_003D_003D(_0023_003DzlVBJOHWrwdu_2sxx2Q_003D_003D);
	}

	public void CreateCircularPlate(Point3D center, double radius, int subdivisionLevel, Material material)
	{
		CreateCircularPlate(center, radius, subdivisionLevel, material, quadrant1: true, quadrant2: true, quadrant3: true, quadrant4: true);
	}

	public void CreateCircularPlate(Point3D center, double radius, int subdivisionLevel, Material material, bool quadrant1, bool quadrant2, bool quadrant3, bool quadrant4)
	{
		int num = subdivisionLevel * 2;
		Line line = new Line(center, new Point3D(center.X + radius, center.Y, center.Z));
		Line line2 = new Line(center, new Point3D(center.X, center.Y + radius, center.Z));
		Arc arc = new Arc(center, radius, Math.PI / 2.0);
		Point3D midPoint = line.MidPoint;
		Point3D point3D = line.PointAt(line.Domain.ParameterAt(0.56));
		devDept.Geometry.Rotation xform = new devDept.Geometry.Rotation(Math.PI / 4.0, Vector3D.AxisZ, center);
		point3D.TransformBy(xform);
		Point3D midPoint2 = line2.MidPoint;
		List<Point3D> list = new List<Point3D>();
		Node item = new Node(center.X, center.Y, center.Z);
		Node item2 = new Node(midPoint.X, midPoint.Y, midPoint.Z);
		Node item3 = new Node(point3D.X, point3D.Y, point3D.Z);
		Node item4 = new Node(midPoint2.X, midPoint2.Y, midPoint2.Z);
		list.Add(item);
		list.Add(item2);
		list.Add(item3);
		list.Add(item4);
		Quad4 item5 = new Quad4(new List<int> { 0, 1, 2, 3 }, material);
		FemMesh femMesh = new FemMesh(list, new List<Element> { item5 });
		femMesh.RefineElements(new List<int> { 0 }, num / 2, num / 2);
		double num2 = arc.Domain.Length / (double)num;
		List<Point3D> list2 = new List<Point3D>();
		for (int i = 0; i <= num; i++)
		{
			Point3D point3D2 = arc.PointAt(num2 * (double)i);
			list2.Add(new Node(point3D2.X, point3D2.Y, point3D2.Z));
		}
		List<Point3D> list3 = new List<Point3D>();
		list3.AddRange(femMesh.Vertices);
		for (int j = 0; j <= num / 2; j++)
		{
			Point3D point3D3 = new Segment3D(point3D, midPoint2).PointAt((double)j / (double)(num / 2));
			Segment3D segment3D = new Segment3D(point3D3, list2[j + num / 2]);
			list3.Add(new Node(point3D3.X, point3D3.Y, point3D3.Z));
			for (int k = 0; k < num / 2; k++)
			{
				Point3D point3D4 = segment3D.PointAt((double)k / (double)(num / 2));
				list3.Add(new Node(point3D4.X, point3D4.Y, point3D4.Z));
			}
			list3.Add((Node)list2[j + num / 2].Clone());
		}
		int num3 = list3.Count + 1;
		for (int l = 0; l <= num / 2; l++)
		{
			Point3D point3D5 = new Segment3D(midPoint, point3D).PointAt((double)l / (double)(num / 2));
			Segment3D segment3D2 = new Segment3D(point3D5, list2[l]);
			list3.Add(new Node(point3D5.X, point3D5.Y, point3D5.Z));
			for (int m = 0; m < num / 2; m++)
			{
				Point3D point3D6 = segment3D2.PointAt((double)m / (double)(num / 2));
				list3.Add(new Node(point3D6.X, point3D6.Y, point3D6.Z));
			}
			list3.Add((Node)list2[l].Clone());
		}
		List<Element> list4 = new List<Element>();
		list4.AddRange(femMesh.Elements);
		int num4 = num / 2 + 2;
		int num5 = femMesh.Vertices.Length + 1;
		for (int n = 0; n < num / 2; n++)
		{
			for (int num6 = 0; num6 < num / 2; num6++)
			{
				Quad4 item6 = new Quad4(num5 + num4 * n + num6, num5 + num4 * n + num6 + 1, num5 + num4 * (n + 1) + num6 + 1, num5 + num4 * (n + 1) + num6, material);
				list4.Add(item6);
			}
		}
		for (int num7 = 0; num7 < num / 2; num7++)
		{
			for (int num8 = 0; num8 < num / 2; num8++)
			{
				Quad4 item7 = new Quad4(num3 + num4 * num7 + num8, num3 + num4 * num7 + num8 + 1, num3 + num4 * (num7 + 1) + num8 + 1, num3 + num4 * (num7 + 1) + num8, material);
				list4.Add(item7);
			}
		}
		femMesh.Vertices = list3.ToArray();
		femMesh.Elements = list4.ToArray();
		_0023_003Dzen6KLjjxOsYA(quadrant1, quadrant2, quadrant3, quadrant4, center, femMesh);
	}

	private void _0023_003Dzen6KLjjxOsYA(bool _0023_003Dz4muMDpJq8mwyEP3H2w_003D_003D, bool _0023_003DzVkCN55OGdagRhIFkag_003D_003D, bool _0023_003DztKbVBLiXGGuD6GF8iw_003D_003D, bool _0023_003DzJcryEFn007CksNXJjw_003D_003D, Point3D _0023_003DzbUvT9Pc_003D, FemMesh _0023_003Dzkx0ud14_003D)
	{
		Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new Point3D[0];
		Element[] array = new Element[0];
		if (_0023_003Dz4muMDpJq8mwyEP3H2w_003D_003D)
		{
			FemMesh femMesh = (FemMesh)_0023_003Dzkx0ud14_003D.Clone();
			AddElementsAndNodesToCurrentMesh(femMesh.Vertices, femMesh.Elements);
		}
		if (_0023_003DzVkCN55OGdagRhIFkag_003D_003D)
		{
			array = _0023_003Dz1DXj_wTnLbG_0024(_0023_003Dzkx0ud14_003D, _0023_003DzbUvT9Pc_003D, out _0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
			AddElementsAndNodesToCurrentMesh(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, array);
		}
		if (_0023_003DztKbVBLiXGGuD6GF8iw_003D_003D)
		{
			array = _0023_003DzJNyPp_veuVbX(_0023_003Dzkx0ud14_003D, _0023_003DzbUvT9Pc_003D, out _0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
			AddElementsAndNodesToCurrentMesh(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, array);
		}
		if (_0023_003DzJcryEFn007CksNXJjw_003D_003D)
		{
			array = _0023_003DzqL3VqLn3oFnO(_0023_003Dzkx0ud14_003D, _0023_003DzbUvT9Pc_003D, out _0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
			AddElementsAndNodesToCurrentMesh(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, array);
		}
		MergeNearbyNodes();
	}

	public void AddElementsAndNodesToCurrentMesh(Point3D[] pointsArray, Element[] elementsArray)
	{
		List<Point3D> list = new List<Point3D>();
		if (Vertices != null)
		{
			list.AddRange(Vertices);
		}
		List<Element> list2 = new List<Element>();
		if (Elements != null)
		{
			list2.AddRange(Elements);
		}
		int count = list.Count;
		list.AddRange(pointsArray);
		foreach (Element element in elementsArray)
		{
			for (int j = 0; j < element.Connection.Length; j++)
			{
				int num = element.Connection[j];
				element.Connection[j] = num + count;
			}
			list2.Add(element);
		}
		Elements = list2.ToArray();
		Vertices = list.ToArray();
	}

	private static Element[] _0023_003Dz1DXj_wTnLbG_0024(FemMesh _0023_003Dzkx0ud14_003D, Point3D _0023_003DzbUvT9Pc_003D, out Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		FemMesh femMesh = (FemMesh)_0023_003Dzkx0ud14_003D.Clone();
		femMesh.Rotate(Math.PI / 2.0, Vector3D.AxisZ, _0023_003DzbUvT9Pc_003D);
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = femMesh.Vertices;
		return femMesh.Elements;
	}

	private static Element[] _0023_003DzJNyPp_veuVbX(FemMesh _0023_003Dzkx0ud14_003D, Point3D _0023_003DzbUvT9Pc_003D, out Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		FemMesh femMesh = (FemMesh)_0023_003Dzkx0ud14_003D.Clone();
		femMesh.Rotate(Math.PI, Vector3D.AxisZ, _0023_003DzbUvT9Pc_003D);
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = femMesh.Vertices;
		return femMesh.Elements;
	}

	private static Element[] _0023_003DzqL3VqLn3oFnO(FemMesh _0023_003Dzkx0ud14_003D, Point3D _0023_003DzbUvT9Pc_003D, out Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		FemMesh femMesh = (FemMesh)_0023_003Dzkx0ud14_003D.Clone();
		femMesh.Rotate(4.71238898038469, Vector3D.AxisZ, _0023_003DzbUvT9Pc_003D);
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = femMesh.Vertices;
		return femMesh.Elements;
	}

	public void CreateSquarePlateWithCircularHole(double size, Point3D center, double radius, Material material)
	{
		CreateSquarePlateWithCircularHole(size, center, radius, material, quadrant1: true, quadrant2: true, quadrant3: true, quadrant4: true);
	}

	public void CreateSquarePlateWithCircularHole(double size, Point3D center, double radius, Material material, bool quadrant1, bool quadrant2, bool quadrant3, bool quadrant4)
	{
		int num = 8;
		int num2 = 4;
		Arc arc = new Arc(center, radius, Math.PI / 2.0);
		double num3 = arc.Domain.Length / (double)num;
		List<Point3D> list = new List<Point3D>();
		for (int i = 0; i <= num; i++)
		{
			Point3D point3D = arc.PointAt(num3 * (double)i);
			list.Add(new Node(point3D.X, point3D.Y, point3D.Z));
		}
		List<Point3D> list2 = new List<Point3D>();
		for (int j = 0; j <= num2; j++)
		{
			Segment3D segment3D = new Segment3D(new Segment3D(new Point3D(size / 2.0 + center.X, center.Y, center.Z), new Point3D(size / 2.0 + center.X, size / 2.0 + center.Y, center.Z)).PointAt((double)j / (double)num2), list[j]);
			for (int k = 0; k < 2; k++)
			{
				Point3D point3D2 = segment3D.PointAt((double)k / 2.0);
				list2.Add(new Node(point3D2.X, point3D2.Y, point3D2.Z));
			}
			list2.Add((Node)list[j].Clone());
		}
		int count = list2.Count;
		for (int l = 0; l <= num2; l++)
		{
			Segment3D segment3D2 = new Segment3D(new Segment3D(new Point3D(size / 2.0 + center.X, size / 2.0 + center.Y, center.Z), new Point3D(center.X, size / 2.0 + center.Y, center.Z)).PointAt((double)l / (double)num2), list[l + 4]);
			for (int m = 0; m < 2; m++)
			{
				Point3D point3D3 = segment3D2.PointAt((double)m / 2.0);
				list2.Add(new Node(point3D3.X, point3D3.Y, point3D3.Z));
			}
			list2.Add((Node)list[l + 4].Clone());
		}
		List<Element> list3 = new List<Element>();
		int num4 = num2 - 1;
		for (int n = 0; n < num2; n++)
		{
			for (int num5 = 0; num5 < 2; num5++)
			{
				Quad4 item = new Quad4(num4 * (n + 1) + num5, num4 * (n + 1) + num5 + 1, num4 * n + num5 + 1, num4 * n + num5, material);
				list3.Add(item);
			}
		}
		for (int num6 = 0; num6 < num2; num6++)
		{
			for (int num7 = 0; num7 < 2; num7++)
			{
				Quad4 item2 = new Quad4(count + num4 * (num6 + 1) + num7, count + num4 * (num6 + 1) + num7 + 1, count + num4 * num6 + num7 + 1, count + num4 * num6 + num7, material);
				list3.Add(item2);
			}
		}
		FemMesh _0023_003Dzkx0ud14_003D = new FemMesh(list2, list3);
		_0023_003Dzen6KLjjxOsYA(quadrant1, quadrant2, quadrant3, quadrant4, center, _0023_003Dzkx0ud14_003D);
	}

	public void RemoveElements(Plane plane, double distance, double inflateBy)
	{
		Tuple<int, int>[] faces = GetFaces(plane, inflateBy);
		RemoveElements(faces);
	}

	public void RemoveElements(Plane plane, Interval alongX, Interval alongY, double inflateBy)
	{
		Tuple<int, int>[] faces = GetFaces(plane, alongX, alongY, inflateBy);
		RemoveElements(faces);
	}

	public void RemoveElements(Point3D min, Point3D max, double inflateBy)
	{
		Tuple<int, int>[] faces = GetFaces(min, max, inflateBy);
		RemoveElements(faces);
	}

	public void RemoveElements(Point3D center, Vector3D axis, Vector3D refDir, double radius, double inflateBy)
	{
		Tuple<int, int>[] faces = GetFaces(center, axis, refDir, radius, inflateBy);
		RemoveElements(faces);
	}

	public void RemoveElements(Point3D center, Vector3D axis, Vector3D refDir, double radius, Interval angle, double inflateBy)
	{
		Tuple<int, int>[] faces = GetFaces(center, axis, refDir, radius, angle, inflateBy);
		RemoveElements(faces);
	}

	public void RemoveElements(Point3D center, Vector3D axis, Vector3D refDir, double radius, Interval angle, Interval distance, double inflateBy)
	{
		Tuple<int, int>[] faces = GetFaces(center, axis, refDir, radius, angle, distance, inflateBy);
		RemoveElements(faces);
	}

	public void RemoveElements(Tuple<int, int>[] faces)
	{
		int[,] array = new int[Elements.Length, 1];
		List<Element> list = new List<Element>();
		foreach (Tuple<int, int> tuple in faces)
		{
			array[tuple.Item1, 0] = array[tuple.Item1, 0] + 1;
		}
		for (int j = 0; j < array.Length; j++)
		{
			if (array[j, 0] != Elements[j].Faces.Length)
			{
				list.Add(Elements[j]);
			}
		}
		Elements = list.ToArray();
		DeleteUnusedNodes();
	}

	public void Translate(double dx, double dy, double dz, bool copy)
	{
		_0023_003Dz5leUDCA82SaIO40nLQ_003D_003D(out var _0023_003DzDvuIQCU_003D, out var _0023_003DzpPOEJqcAh7Lr);
		_0023_003DzacB01ck_003D(_0023_003DzpPOEJqcAh7Lr, _0023_003DzDvuIQCU_003D, dx, dy, dz, copy);
	}

	public void Translate(Plane plane, double inflateBy, double dx, double dy, double dz, bool copy)
	{
		int[] nodes = GetNodes(plane, inflateBy);
		Tuple<int, int>[] faces = GetFaces(plane, inflateBy);
		_0023_003DzacB01ck_003D(faces, nodes, dx, dy, dz, copy);
	}

	public void Translate(Plane plane, Interval alongX, Interval alongY, double inflateBy, double dx, double dy, double dz, bool copy)
	{
		int[] nodes = GetNodes(plane, alongX, alongY, inflateBy);
		Tuple<int, int>[] faces = GetFaces(plane, alongX, alongY, inflateBy);
		_0023_003DzacB01ck_003D(faces, nodes, dx, dy, dz, copy);
	}

	public void Translate(Point3D min, Point3D max, double inflateBy, double dx, double dy, double dz, bool copy)
	{
		int[] nodes = GetNodes(min, max, inflateBy);
		Tuple<int, int>[] faces = GetFaces(min, max, inflateBy);
		_0023_003DzacB01ck_003D(faces, nodes, dx, dy, dz, copy);
	}

	public void Translate(Point3D center, Vector3D axis, Vector3D refDir, double radius, double inflateBy, double dx, double dy, double dz, bool copy)
	{
		int[] nodes = GetNodes(center, axis, refDir, radius, inflateBy);
		Tuple<int, int>[] faces = GetFaces(center, axis, refDir, radius, inflateBy);
		_0023_003DzacB01ck_003D(faces, nodes, dx, dy, dz, copy);
	}

	public void Translate(Point3D center, Vector3D axis, Vector3D refDir, double radius, Interval angle, double inflateBy, double dx, double dy, double dz, bool copy)
	{
		int[] nodes = GetNodes(center, axis, refDir, radius, angle, inflateBy);
		Tuple<int, int>[] faces = GetFaces(center, axis, refDir, radius, angle, inflateBy);
		_0023_003DzacB01ck_003D(faces, nodes, dx, dy, dz, copy);
	}

	public void Translate(Point3D center, Vector3D axis, Vector3D refDir, double radius, Interval angle, Interval distance, double inflateBy, double dx, double dy, double dz, bool copy)
	{
		int[] nodes = GetNodes(center, axis, refDir, radius, angle, distance, inflateBy);
		Tuple<int, int>[] faces = GetFaces(center, axis, refDir, radius, angle, distance, inflateBy);
		_0023_003DzacB01ck_003D(faces, nodes, dx, dy, dz, copy);
	}

	private void _0023_003DzacB01ck_003D(Tuple<int, int>[] _0023_003DzpPOEJqcAh7Lr, int[] _0023_003DzDvuIQCU_003D, double _0023_003DzaQ_y9PQ_003D, double _0023_003DzD47R4_0_003D, double _0023_003DzLpcnctI_003D, bool _0023_003Dzl_0024kBRC0_003D)
	{
		if (_0023_003Dzl_0024kBRC0_003D)
		{
			List<Element> list = new List<Element>();
			list.AddRange(Elements);
			int[] array = new int[Vertices.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = -1;
			}
			List<Point3D> list2 = new List<Point3D>();
			list2.AddRange(Vertices);
			List<int> list3 = new List<int>();
			foreach (int num in _0023_003DzDvuIQCU_003D)
			{
				Point3D item = (Point3D)Vertices[num].Clone();
				list3.Add(list2.Count);
				array[num] = list2.Count;
				list2.Add(item);
			}
			Vertices = list2.ToArray();
			_0023_003DzacB01ck_003D(list3, _0023_003DzaQ_y9PQ_003D, _0023_003DzD47R4_0_003D, _0023_003DzLpcnctI_003D);
			int[] array2 = new int[Elements.Length];
			foreach (Tuple<int, int> tuple in _0023_003DzpPOEJqcAh7Lr)
			{
				array2[tuple.Item1] = array2[tuple.Item1] + 1;
			}
			for (int l = 0; l < array2.Length; l++)
			{
				if (array2[l] == Elements[l].Faces.Length)
				{
					int[] array3 = new int[Elements[l].Connection.Length];
					for (int m = 0; m < Elements[l].Connection.Length; m++)
					{
						int num2 = Elements[l].Connection[m];
						array3[m] = array[num2];
					}
					list.Add(_0023_003DzjighX5w_003D(Elements[l], array3));
				}
			}
			Elements = list.ToArray();
		}
		else
		{
			_0023_003DzacB01ck_003D(_0023_003DzDvuIQCU_003D.ToList(), _0023_003DzaQ_y9PQ_003D, _0023_003DzD47R4_0_003D, _0023_003DzLpcnctI_003D);
		}
	}

	private Element _0023_003DzjighX5w_003D(Element _0023_003Dzx63Fsgc_003D, int[] _0023_003Dz9lD46Pg_003D)
	{
		Element result = null;
		if (_0023_003Dzx63Fsgc_003D is Quad4)
		{
			result = new Quad4(_0023_003Dz9lD46Pg_003D, _0023_003Dzx63Fsgc_003D.Material);
		}
		else if (_0023_003Dzx63Fsgc_003D is Quad8)
		{
			result = new Quad8(_0023_003Dz9lD46Pg_003D, _0023_003Dzx63Fsgc_003D.Material);
		}
		else if (_0023_003Dzx63Fsgc_003D is Tria3)
		{
			result = new Tria3(_0023_003Dz9lD46Pg_003D, _0023_003Dzx63Fsgc_003D.Material);
		}
		else if (_0023_003Dzx63Fsgc_003D is Tria6)
		{
			result = new Tria6(_0023_003Dz9lD46Pg_003D, _0023_003Dzx63Fsgc_003D.Material);
		}
		else if (_0023_003Dzx63Fsgc_003D is Hexa8)
		{
			result = new Hexa8(_0023_003Dz9lD46Pg_003D, _0023_003Dzx63Fsgc_003D.Material);
		}
		else if (_0023_003Dzx63Fsgc_003D is Hexa20)
		{
			result = new Hexa20(_0023_003Dz9lD46Pg_003D, _0023_003Dzx63Fsgc_003D.Material);
		}
		else if (_0023_003Dzx63Fsgc_003D is Tetra4)
		{
			result = new Tetra4(_0023_003Dz9lD46Pg_003D, _0023_003Dzx63Fsgc_003D.Material);
		}
		else if (_0023_003Dzx63Fsgc_003D is Tetra10)
		{
			result = new Tetra10(_0023_003Dz9lD46Pg_003D, _0023_003Dzx63Fsgc_003D.Material);
		}
		else if (_0023_003Dzx63Fsgc_003D is Penta6)
		{
			result = new Penta6(_0023_003Dz9lD46Pg_003D, _0023_003Dzx63Fsgc_003D.Material);
		}
		else if (_0023_003Dzx63Fsgc_003D is Penta15)
		{
			result = new Penta15(_0023_003Dz9lD46Pg_003D, _0023_003Dzx63Fsgc_003D.Material);
		}
		return result;
	}

	private void _0023_003DzacB01ck_003D(List<int> _0023_003DzPJoLKSA_003D, double _0023_003DzaQ_y9PQ_003D, double _0023_003DzD47R4_0_003D, double _0023_003DzLpcnctI_003D)
	{
		foreach (int item in _0023_003DzPJoLKSA_003D)
		{
			Vertices[item].TransformBy(new Translation(_0023_003DzaQ_y9PQ_003D, _0023_003DzD47R4_0_003D, _0023_003DzLpcnctI_003D));
		}
	}

	public void Mirror(Plane plane, double inflateBy, Plane mirrorPlane, bool copy)
	{
		int[] nodes = GetNodes(plane, inflateBy);
		Tuple<int, int>[] faces = GetFaces(plane, inflateBy);
		_0023_003Dzsi8a9T8_003D(nodes, faces, mirrorPlane, copy);
	}

	public void Mirror(Plane plane, Interval alongX, Interval alongY, double inflateBy, Plane mirrorPlane, bool copy)
	{
		int[] nodes = GetNodes(plane, alongX, alongY, inflateBy);
		Tuple<int, int>[] faces = GetFaces(plane, alongX, alongY, inflateBy);
		_0023_003Dzsi8a9T8_003D(nodes, faces, mirrorPlane, copy);
	}

	public void Mirror(Plane mirrorPlane, bool copy)
	{
		_0023_003Dz5leUDCA82SaIO40nLQ_003D_003D(out var _0023_003DzDvuIQCU_003D, out var _0023_003DzpPOEJqcAh7Lr);
		_0023_003Dzsi8a9T8_003D(_0023_003DzDvuIQCU_003D, _0023_003DzpPOEJqcAh7Lr, mirrorPlane, copy);
	}

	private void _0023_003Dz5leUDCA82SaIO40nLQ_003D_003D(out int[] _0023_003DzDvuIQCU_003D, out Tuple<int, int>[] _0023_003DzpPOEJqcAh7Lr)
	{
		_0023_003DzDvuIQCU_003D = new int[_vertices.Length];
		for (int i = 0; i < _vertices.Length; i++)
		{
			_0023_003DzDvuIQCU_003D[i] = i;
		}
		List<Tuple<int, int>> list = new List<Tuple<int, int>>();
		for (int j = 0; j < elements.Length; j++)
		{
			for (int k = 0; k < elements[j].Faces.Length; k++)
			{
				list.Add(new Tuple<int, int>(j, k));
			}
		}
		_0023_003DzpPOEJqcAh7Lr = list.ToArray();
	}

	public void Mirror(Point3D min, Point3D max, double inflateBy, Plane mirrorPlane, bool copy)
	{
		int[] nodes = GetNodes(min, max, inflateBy);
		Tuple<int, int>[] faces = GetFaces(min, max, inflateBy);
		_0023_003Dzsi8a9T8_003D(nodes, faces, mirrorPlane, copy);
	}

	public void Mirror(Point3D center, Vector3D axis, Vector3D refDir, double radius, double inflateBy, Plane mirrorPlane, bool copy)
	{
		int[] nodes = GetNodes(center, axis, refDir, radius, inflateBy);
		Tuple<int, int>[] faces = GetFaces(center, axis, refDir, radius, inflateBy);
		_0023_003Dzsi8a9T8_003D(nodes, faces, mirrorPlane, copy);
	}

	public void Mirror(Point3D center, Vector3D axis, Vector3D refDir, double radius, Interval angle, double inflateBy, Plane mirrorPlane, bool copy)
	{
		int[] nodes = GetNodes(center, axis, refDir, radius, angle, inflateBy);
		Tuple<int, int>[] faces = GetFaces(center, axis, refDir, radius, angle, inflateBy);
		_0023_003Dzsi8a9T8_003D(nodes, faces, mirrorPlane, copy);
	}

	public void Mirror(Point3D center, Vector3D axis, Vector3D refDir, double radius, Interval angle, Interval distance, double inflateBy, Plane mirrorPlane, bool copy)
	{
		int[] nodes = GetNodes(center, axis, refDir, radius, angle, distance, inflateBy);
		Tuple<int, int>[] faces = GetFaces(center, axis, refDir, radius, angle, distance, inflateBy);
		_0023_003Dzsi8a9T8_003D(nodes, faces, mirrorPlane, copy);
	}

	private void _0023_003Dzsi8a9T8_003D(int[] _0023_003DzDvuIQCU_003D, Tuple<int, int>[] _0023_003DzpPOEJqcAh7Lr, Plane _0023_003DzMIsh4wEqXUSrgwVUBg_003D_003D, bool _0023_003Dzl_0024kBRC0_003D)
	{
		List<Element> list = new List<Element>();
		int[] array = new int[Vertices.Length];
		if (_0023_003Dzl_0024kBRC0_003D)
		{
			list.AddRange(Elements);
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = -1;
			}
			List<Point3D> list2 = new List<Point3D>();
			list2.AddRange(Vertices);
			List<int> list3 = new List<int>();
			int[] array2 = _0023_003DzDvuIQCU_003D;
			foreach (int num in array2)
			{
				Point3D item = (Point3D)Vertices[num].Clone();
				list3.Add(list2.Count);
				array[num] = list2.Count;
				list2.Add(item);
			}
			Vertices = list2.ToArray();
			_0023_003Dzsi8a9T8_003D(list3, _0023_003DzMIsh4wEqXUSrgwVUBg_003D_003D);
		}
		else
		{
			_0023_003Dzsi8a9T8_003D(_0023_003DzDvuIQCU_003D.ToList(), _0023_003DzMIsh4wEqXUSrgwVUBg_003D_003D);
			int[] array2 = _0023_003DzDvuIQCU_003D;
			foreach (int num2 in array2)
			{
				array[num2] = num2;
			}
		}
		int[] array3 = new int[Elements.Length];
		foreach (Tuple<int, int> tuple in _0023_003DzpPOEJqcAh7Lr)
		{
			array3[tuple.Item1] = array3[tuple.Item1] + 1;
		}
		for (int l = 0; l < array3.Length; l++)
		{
			if (array3[l] == Elements[l].Faces.Length)
			{
				int[] _0023_003DzfYMyE9c_003D = new int[Elements[l].Connection.Length];
				for (int m = 0; m < Elements[l].Connection.Length; m++)
				{
					int num3 = Elements[l].Connection[m];
					_0023_003DzfYMyE9c_003D[m] = array[num3];
				}
				if (Elements[l] is Element2D)
				{
					Array.Reverse(_0023_003DzfYMyE9c_003D);
				}
				else
				{
					_0023_003Dz54IA43uj6Exz4R2D0g_003D_003D(ref _0023_003DzfYMyE9c_003D, Elements[l]);
				}
				if (_0023_003Dzl_0024kBRC0_003D)
				{
					list.Add(_0023_003DzjighX5w_003D(Elements[l], _0023_003DzfYMyE9c_003D));
				}
				else
				{
					Elements[l].Connection = _0023_003DzfYMyE9c_003D;
				}
			}
		}
		if (_0023_003Dzl_0024kBRC0_003D)
		{
			Elements = list.ToArray();
		}
	}

	private void _0023_003Dzsi8a9T8_003D(List<int> _0023_003DzPJoLKSA_003D, Plane _0023_003DzMIsh4wEqXUSrgwVUBg_003D_003D)
	{
		foreach (int item in _0023_003DzPJoLKSA_003D)
		{
			Vertices[item].TransformBy(new Mirror(_0023_003DzMIsh4wEqXUSrgwVUBg_003D_003D));
		}
	}

	private static void _0023_003Dz54IA43uj6Exz4R2D0g_003D_003D(ref int[] _0023_003DzfYMyE9c_003D, Element _0023_003Dzx63Fsgc_003D)
	{
		if (_0023_003Dzx63Fsgc_003D is Hexa8 || _0023_003Dzx63Fsgc_003D is Penta6)
		{
			int num = _0023_003DzfYMyE9c_003D.Length / 2;
			int[] array = new int[_0023_003DzfYMyE9c_003D.Length];
			int num2 = 0;
			for (int num3 = num - 1; num3 >= 0; num3--)
			{
				array[num2] = _0023_003DzfYMyE9c_003D[num3];
				num2++;
			}
			for (int num4 = _0023_003DzfYMyE9c_003D.Length - 1; num4 >= num; num4--)
			{
				array[num2] = _0023_003DzfYMyE9c_003D[num4];
				num2++;
			}
			_0023_003DzfYMyE9c_003D = array;
		}
		else if (_0023_003Dzx63Fsgc_003D is Hexa20)
		{
			int[] array2 = new int[_0023_003DzfYMyE9c_003D.Length];
			int num5 = _0023_003DzfYMyE9c_003D.Length - 1;
			for (int num6 = 7; num6 >= 0; num6--)
			{
				array2[num5] = _0023_003DzfYMyE9c_003D[num6];
				num5--;
			}
			for (int num7 = 11; num7 >= 8; num7--)
			{
				array2[num5] = _0023_003DzfYMyE9c_003D[num7];
				num5--;
			}
			for (int num8 = _0023_003DzfYMyE9c_003D.Length - 1; num8 >= 12; num8--)
			{
				array2[num5] = _0023_003DzfYMyE9c_003D[num8];
				num5--;
			}
			_0023_003DzfYMyE9c_003D = array2;
		}
		else if (_0023_003Dzx63Fsgc_003D is Tetra4)
		{
			int[] array3 = new int[_0023_003DzfYMyE9c_003D.Length];
			int num9 = 0;
			for (int num10 = 2; num10 >= 0; num10--)
			{
				array3[num9] = _0023_003DzfYMyE9c_003D[num10];
				num9++;
			}
			array3[num9] = _0023_003DzfYMyE9c_003D[_0023_003DzfYMyE9c_003D.Length - 1];
			_0023_003DzfYMyE9c_003D = array3;
		}
		else if (_0023_003Dzx63Fsgc_003D is Tetra10)
		{
			int[] array4 = new int[_0023_003DzfYMyE9c_003D.Length];
			int num11 = 0;
			array4[num11] = _0023_003DzfYMyE9c_003D[0];
			num11++;
			for (int num12 = 5; num12 > 0; num12--)
			{
				array4[num11] = _0023_003DzfYMyE9c_003D[num12];
				num11++;
			}
			array4[num11] = _0023_003DzfYMyE9c_003D[6];
			num11++;
			for (int num13 = 8; num13 >= 7; num13--)
			{
				array4[num11] = _0023_003DzfYMyE9c_003D[num13];
				num11++;
			}
			array4[num11] = _0023_003DzfYMyE9c_003D[_0023_003DzfYMyE9c_003D.Length - 1];
			_0023_003DzfYMyE9c_003D = array4;
		}
		else if (_0023_003Dzx63Fsgc_003D is Penta15)
		{
			int[] array5 = new int[_0023_003DzfYMyE9c_003D.Length];
			int num14 = _0023_003DzfYMyE9c_003D.Length - 1;
			for (int num15 = 5; num15 >= 0; num15--)
			{
				array5[num14] = _0023_003DzfYMyE9c_003D[num15];
				num14--;
			}
			for (int num16 = 8; num16 >= 6; num16--)
			{
				array5[num14] = _0023_003DzfYMyE9c_003D[num16];
				num14--;
			}
			for (int num17 = _0023_003DzfYMyE9c_003D.Length - 1; num17 >= 9; num17--)
			{
				array5[num14] = _0023_003DzfYMyE9c_003D[num17];
				num14--;
			}
			_0023_003DzfYMyE9c_003D = array5;
		}
	}

	public void Rotate(double angle, Vector3D axis, Point3D center, bool copy)
	{
		_0023_003Dz5leUDCA82SaIO40nLQ_003D_003D(out var _0023_003DzDvuIQCU_003D, out var _0023_003DzpPOEJqcAh7Lr);
		_0023_003Dz6dFS2Jo_003D(_0023_003DzDvuIQCU_003D, _0023_003DzpPOEJqcAh7Lr, angle, axis, center, copy);
	}

	public void Rotate(Plane plane, double inflateBy, double angle, Vector3D axis, Point3D center, bool copy)
	{
		int[] nodes = GetNodes(plane, inflateBy);
		Tuple<int, int>[] faces = GetFaces(plane, inflateBy);
		_0023_003Dz6dFS2Jo_003D(nodes, faces, angle, axis, center, copy);
	}

	public void Rotate(Plane plane, Interval alongX, Interval alongY, double inflateBy, double angle, Vector3D axis, Point3D center, bool copy)
	{
		int[] nodes = GetNodes(plane, alongX, alongY, inflateBy);
		Tuple<int, int>[] faces = GetFaces(plane, alongX, alongY, inflateBy);
		_0023_003Dz6dFS2Jo_003D(nodes, faces, angle, axis, center, copy);
	}

	public void Rotate(Point3D min, Point3D max, double inflateBy, double angleInRadians, Vector3D rotationAxis, Point3D rotationCenter, bool copy)
	{
		int[] nodes = GetNodes(min, max, inflateBy);
		Tuple<int, int>[] faces = GetFaces(min, max, inflateBy);
		_0023_003Dz6dFS2Jo_003D(nodes, faces, angleInRadians, rotationAxis, rotationCenter, copy);
	}

	public void Rotate(Point3D center, Vector3D axis, Vector3D refDir, double radius, double inflateBy, double angleInRadians, Vector3D rotationAxis, Point3D rotationCenter, bool copy)
	{
		int[] nodes = GetNodes(center, axis, refDir, radius, inflateBy);
		Tuple<int, int>[] faces = GetFaces(center, axis, refDir, radius, inflateBy);
		_0023_003Dz6dFS2Jo_003D(nodes, faces, angleInRadians, rotationAxis, rotationCenter, copy);
	}

	public void Rotate(Point3D center, Vector3D axis, Vector3D refDir, double radius, Interval angle, double inflateBy, double angleInRadians, Vector3D rotationAxis, Point3D rotationCenter, bool copy)
	{
		int[] nodes = GetNodes(center, axis, refDir, radius, angle, inflateBy);
		Tuple<int, int>[] faces = GetFaces(center, axis, refDir, radius, angle, inflateBy);
		_0023_003Dz6dFS2Jo_003D(nodes, faces, angleInRadians, rotationAxis, rotationCenter, copy);
	}

	public void Rotate(Point3D center, Vector3D axis, Vector3D refDir, double radius, Interval angle, Interval distance, double inflateBy, double angleInRadians, Vector3D rotationAxis, Point3D rotationCenter, bool copy)
	{
		int[] nodes = GetNodes(center, axis, refDir, radius, angle, distance, inflateBy);
		Tuple<int, int>[] faces = GetFaces(center, axis, refDir, radius, angle, distance, inflateBy);
		_0023_003Dz6dFS2Jo_003D(nodes, faces, angleInRadians, rotationAxis, rotationCenter, copy);
	}

	private void _0023_003Dz6dFS2Jo_003D(int[] _0023_003DzDvuIQCU_003D, Tuple<int, int>[] _0023_003DzpPOEJqcAh7Lr, double _0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D, Vector3D _0023_003Dz_0024w9jM1UEOK_U, Point3D _0023_003DzyNZquWXQaPzE, bool _0023_003Dzl_0024kBRC0_003D)
	{
		List<Element> list = new List<Element>();
		int[] array = new int[Vertices.Length];
		if (_0023_003Dzl_0024kBRC0_003D)
		{
			list.AddRange(Elements);
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = -1;
			}
			List<Point3D> list2 = new List<Point3D>();
			list2.AddRange(Vertices);
			List<int> list3 = new List<int>();
			int[] array2 = _0023_003DzDvuIQCU_003D;
			foreach (int num in array2)
			{
				Point3D item = (Point3D)Vertices[num].Clone();
				list3.Add(list2.Count);
				array[num] = list2.Count;
				list2.Add(item);
			}
			Vertices = list2.ToArray();
			_0023_003Dz6dFS2Jo_003D(list3, _0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D, _0023_003Dz_0024w9jM1UEOK_U, _0023_003DzyNZquWXQaPzE);
		}
		else
		{
			_0023_003Dz6dFS2Jo_003D(_0023_003DzDvuIQCU_003D.ToList(), _0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D, _0023_003Dz_0024w9jM1UEOK_U, _0023_003DzyNZquWXQaPzE);
			int[] array2 = _0023_003DzDvuIQCU_003D;
			foreach (int num2 in array2)
			{
				array[num2] = num2;
			}
		}
		int[] array3 = new int[Elements.Length];
		foreach (Tuple<int, int> tuple in _0023_003DzpPOEJqcAh7Lr)
		{
			array3[tuple.Item1] = array3[tuple.Item1] + 1;
		}
		for (int l = 0; l < array3.Length; l++)
		{
			if (array3[l] == Elements[l].Faces.Length)
			{
				int[] array4 = new int[Elements[l].Connection.Length];
				for (int m = 0; m < Elements[l].Connection.Length; m++)
				{
					int num3 = Elements[l].Connection[m];
					array4[m] = array[num3];
				}
				if (_0023_003Dzl_0024kBRC0_003D)
				{
					list.Add(_0023_003DzjighX5w_003D(Elements[l], array4));
				}
				else
				{
					Elements[l].Connection = array4;
				}
			}
		}
		if (_0023_003Dzl_0024kBRC0_003D)
		{
			Elements = list.ToArray();
		}
		MergeNearbyNodes();
	}

	private void _0023_003Dz6dFS2Jo_003D(List<int> _0023_003DzPJoLKSA_003D, double _0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D)
	{
		foreach (int item in _0023_003DzPJoLKSA_003D)
		{
			Vertices[item].TransformBy(new devDept.Geometry.Rotation(_0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D));
		}
	}

	public void CreateRectangularRegion(Point3D startPoint, double width, double height, int widthElementNum, int heigthElementNum, Material material)
	{
		double elementWidth = width / (double)widthElementNum;
		double elementHeight = height / (double)heigthElementNum;
		FemMesh femMesh = CreateRectangleQuad4(width, height, elementWidth, elementHeight, material);
		femMesh.Translate(startPoint.X, startPoint.Y, startPoint.Z);
		AddElementsAndNodesToCurrentMesh(femMesh.Vertices, femMesh.Elements);
		MergeNearbyNodes();
	}

	public void ElevateElementOrder()
	{
		List<Point3D> list = Vertices.ToList();
		for (int i = 0; i < Elements.Length; i++)
		{
			Element element = Elements[i];
			if (element is Quad4)
			{
				Elements[i] = ((Quad4)element)._0023_003DzjKLmeSIGqK0l(element.Connection, list);
			}
			else if (element is Tria3)
			{
				Elements[i] = ((Tria3)element)._0023_003Dzjfhd66VFBfATvheb_g_003D_003D(element.Connection, list);
			}
			else if (element is Tetra4)
			{
				Elements[i] = ((Tetra4)element)._0023_003Dz7vpNB_ppVHTPtkqc4A_003D_003D(element.Connection, list);
			}
			else if (element is Penta6)
			{
				Elements[i] = ((Penta6)element)._0023_003DzOcMObUT_0024_0024_0024bvC7ZwCg_003D_003D(element.Connection, list);
			}
			else if (element is Hexa8)
			{
				Elements[i] = ((Hexa8)element)._0023_003DzuqZUnnjQavZDSny_xA_003D_003D(element.Connection, list);
			}
		}
		int _0023_003DzlVBJOHWrwdu_2sxx2Q_003D_003D = Vertices.Length;
		Vertices = list.ToArray();
		_0023_003Dz3_0024MJgZrKIeKZStxVbQ_003D_003D(_0023_003DzlVBJOHWrwdu_2sxx2Q_003D_003D);
	}

	public static FemMesh CreateRectangleQuad4(double width, double height, double elementWidth, double elementHeight, Material mat)
	{
		double num = Math.Round(width / elementWidth);
		double num2 = width / num;
		double num3 = Math.Round(height / elementHeight);
		double num4 = height / num3;
		double num5 = 0.0;
		double num6 = num * num3;
		FemMesh femMesh = new FemMesh((int)((num + 1.0) * (num3 + 1.0)), (int)num6);
		int num7 = 0;
		for (int i = 0; (double)i <= num; i++)
		{
			double num8 = num4 * num3;
			for (int j = 0; (double)j <= num3; j++)
			{
				femMesh.Vertices[num7] = new Node(num5, num8, 0.0);
				num8 -= num4;
				num7++;
			}
			num5 += num2;
		}
		num7 = 0;
		for (int k = 0; (double)k < num; k++)
		{
			for (int l = 0; (double)l < num3; l++)
			{
				int num9 = k * ((int)num3 + 1) + l;
				int num10 = num9 + (int)num3 + 2;
				femMesh.Elements[num7] = new Quad4(num9, num9 + 1, num10, num10 - 1, mat);
				num7++;
			}
		}
		return femMesh;
	}

	public static FemMesh CreateRectangleTria3(double width, double height, double elementWidth, double elementHeight, Material mat)
	{
		double num = Math.Round(width / elementWidth);
		double num2 = width / num;
		double num3 = Math.Round(height / elementHeight);
		double num4 = height / num3;
		double num5 = 0.0;
		double num6 = num * num3 * 2.0;
		FemMesh femMesh = new FemMesh((int)((num + 1.0) * (num3 + 1.0)), (int)num6);
		int num7 = 0;
		for (int i = 0; (double)i <= num; i++)
		{
			double num8 = num4 * num3;
			for (int j = 0; (double)j <= num3; j++)
			{
				femMesh.Vertices[num7] = new Node(num5, num8, 0.0);
				num8 -= num4;
				num7++;
			}
			num5 += num2;
		}
		num7 = 0;
		for (int k = 0; (double)k < num; k++)
		{
			for (int l = 0; (double)l < num3; l++)
			{
				int num9 = k * ((int)num3 + 1) + l;
				int num10 = num9 + (int)num3 + 2;
				femMesh.Elements[num7] = new Tria3(num9, num10, num10 - 1, mat);
				femMesh.Elements[num7 + 1] = new Tria3(num9, num9 + 1, num10, mat);
				num7 += 2;
			}
		}
		return femMesh;
	}

	public static void CreateRectangleQuad8(double width, double height, double elementWidth, double elementHeight, Material mat, out FemMesh fm)
	{
		double num = Math.Round(width / elementWidth);
		double num2 = width / num;
		double num3 = Math.Round(height / elementHeight);
		double num4 = height / num3;
		double num5 = 0.0;
		double num6 = num * num3;
		double num7 = (num + 1.0) * (num3 + 1.0) + num * (num3 + 1.0) + (num + 1.0) * num3;
		fm = new FemMesh((int)num7, (int)num6);
		int num8 = 0;
		for (int i = 0; (double)i <= num; i++)
		{
			double num9 = num4 * num3;
			for (int j = 0; (double)j <= num3 * 2.0; j++)
			{
				fm.Vertices[num8] = new Node(num5, num9, 0.0);
				num9 -= num4 / 2.0;
				num8++;
			}
			if (i != (int)num)
			{
				num5 += num2 / 2.0;
				num9 = num4 * num3;
				for (int k = 0; (double)k <= num3; k++)
				{
					fm.Vertices[num8] = new Node(num5, num9, 0.0);
					num9 -= num4;
					num8++;
				}
				num5 += num2 / 2.0;
			}
		}
		num8 = 0;
		for (int l = 0; (double)l < num; l++)
		{
			for (int m = 0; (double)m < num3; m++)
			{
				int num10 = l * ((int)num3 * 2 + 1) + l * ((int)num3 + 1) + m * 2;
				int num11 = num10 + 2 * ((int)num3 - m) + m + 1;
				int num12 = num11 + ((int)num3 - m) + 2 * m + 1;
				fm.Elements[num8] = new Quad8(num10, num10 + 1, num10 + 2, num11 + 1, num12 + 2, num12 + 1, num12, num11, mat);
				num8++;
			}
		}
	}

	public static void CreateRectangleTria6(double width, double height, double elementWidth, double elementHeight, Material mat, out FemMesh fm)
	{
		double num = Math.Round(width / elementWidth);
		double num2 = width / num;
		double num3 = Math.Round(height / elementHeight);
		double num4 = height / num3;
		double num5 = 0.0;
		double num6 = num * num3 * 2.0;
		double num7 = (num * 2.0 + 1.0) * (num3 * 2.0 + 1.0);
		fm = new FemMesh((int)num7, (int)num6);
		int num8 = 0;
		for (int i = 0; (double)i <= num * 2.0; i++)
		{
			double num9 = num4 * num3;
			for (int j = 0; (double)j <= num3 * 2.0; j++)
			{
				fm.Vertices[num8] = new Node(num5, num9, 0.0);
				num9 -= num4 / 2.0;
				num8++;
			}
			num5 += num2 / 2.0;
		}
		num8 = 0;
		for (int k = 0; (double)k < num; k++)
		{
			for (int l = 0; (double)l < num3; l++)
			{
				int num10 = k * ((int)num3 * 2 + 1) * 2 + l * 2;
				int num11 = num10 + 2 * ((int)num3 - l) + l * 2 + 1;
				int num12 = num11 + 2 * ((int)num3 - l) + 2 * l + 1;
				fm.Elements[num8] = new Tria6(num10, num11 + 1, num12 + 2, num12 + 1, num12, num11, mat);
				fm.Elements[num8 + 1] = new Tria6(num10, num10 + 1, num10 + 2, num11 + 2, num12 + 2, num11 + 1, mat);
				num8 += 2;
			}
		}
	}

	public static FemMesh CreateRectangle(double width, double height)
	{
		return CreateRectangle(0.0, 0.0, width, height);
	}

	public static FemMesh CreateRectangle(double x, double y, double width, double height)
	{
		FemMesh femMesh = new FemMesh(4, 1);
		femMesh.Vertices = new Point3D[4]
		{
			new Node(x, y),
			new Node(x + width, y),
			new Node(x + width, y + height),
			new Node(x, y + height)
		};
		femMesh.Elements = new Element[1]
		{
			new Quad4(0, 1, 2, 3, Material.StructuralSteel)
		};
		return femMesh;
	}

	protected override void InitGraphicsData(RenderContextBase renderContext)
	{
		base.InitGraphicsData(renderContext);
		if (drawSelected == null)
		{
			drawSelected = renderContext.CreateEntityGraphicsData(this);
		}
		if (drawMesh == null)
		{
			drawMesh = renderContext.CreateEntityGraphicsData(this);
		}
		if (drawSolved == null)
		{
			drawSolved = renderContext.CreateEntityGraphicsData(this);
		}
		if (drawEdges == null)
		{
			drawEdges = renderContext.CreateEntityGraphicsData(this);
		}
		if (drawIsocurves == null)
		{
			drawIsocurves = renderContext.CreateEntityGraphicsData(this);
		}
		if (drawEdges == null)
		{
			drawEdges = renderContext.CreateEntityGraphicsData(this);
		}
	}

	internal void _0023_003DzBnXSyF_0024bas8jFaKSdwSEVBn31F2BZu8IRT_0024yevo_003D(double _0023_003DzPzO_0024GUk_003D)
	{
		_optimalAmpFactor = _0023_003DzPzO_0024GUk_003D;
	}

	internal void _0023_003Dzzf5jb4sXwuH_86CXUvpzOpU_003D(double[] _0023_003DzPzO_0024GUk_003D)
	{
		NaturalFrequencies = _0023_003DzPzO_0024GUk_003D;
	}

	public override object Clone()
	{
		return new FemMesh(this);
	}

	public override object CloneWithTessellation()
	{
		return new FemMesh(this, RegenMode != regenType.RegenAndCompile);
	}

	private void _0023_003Dz1mGkvCqedA2D(Entity _0023_003Dzb7SPTpc_003D)
	{
		FemMesh femMesh = (FemMesh)_0023_003Dzb7SPTpc_003D;
		if (femMesh.skin != null)
		{
			skin = (Mesh)femMesh.skin.CloneWithTessellation();
			isoEdges = new int[femMesh.isoEdges.GetLength(0), femMesh.isoEdges.GetLength(1)];
			Array.Copy(femMesh.isoEdges, isoEdges, femMesh.isoEdges.Length);
		}
		for (int i = 0; i < femMesh.elements.Length; i++)
		{
			Element element = femMesh.elements[i];
			Element element2 = elements[i];
			for (int j = 0; j < element.Faces.Length; j++)
			{
				Element.Face face = element.Faces[j];
				Element.Face face2 = element2.Faces[j];
				if (face.CornerNormals != null)
				{
					face2.CornerNormals = Utility._0023_003DzuKHw7_00241xg_0024SB(face.CornerNormals);
				}
				if (face.Centroid != null)
				{
					face2.Centroid = (Node)face.Centroid.Clone();
				}
				face2.Visible = face.Visible;
				if (face.Triangles != null)
				{
					face2.Triangles = new SmoothTriangle[face.Triangles.Length];
					for (int k = 0; k < face.Triangles.Length; k++)
					{
						face2.Triangles[k] = (SmoothTriangle)face.Triangles[k].Clone();
					}
				}
			}
			if (element is Beam2D beam2D)
			{
				((Beam2D)element2).beamVerts = Utility._0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(beam2D.beamVerts);
			}
			else if (element is Beam beam)
			{
				((Beam)element2).beamVerts = Utility._0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(beam.beamVerts);
			}
		}
		UpdateBoundingBox(null);
	}

	private protected override void _0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(Entity _0023_003Dzb7SPTpc_003D)
	{
	}

	[SpecialName]
	internal override bool _0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D()
	{
		if (base._0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D())
		{
			if (skin == null)
			{
				return Elements.All(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzilTcOzWF2IZkvAvPlS9mDCgJVM3b);
			}
			return true;
		}
		return false;
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new FemMeshSurrogate(this);
	}

	public override void Dispose()
	{
		if (texture1D != null)
		{
			texture1D.Dispose();
		}
		drawSelected?.Dispose();
		drawMesh?.Dispose();
		drawSolved?.Dispose();
		drawEdges?.Dispose();
		if (skin != null)
		{
			skin.Dispose();
		}
		drawIsocurves?.Dispose();
		_0023_003Dz2590AGndWcVccsIaNg_003D_003D();
		_0023_003DzluATrA4_003D();
		base.Dispose();
	}

	private void _0023_003DzluATrA4_003D()
	{
		_0023_003DzluATrA4_003D(drawSolvedFrames);
		_0023_003DzluATrA4_003D(drawEdgesFrames);
		_0023_003DzluATrA4_003D(drawIsocurvesFrames);
	}

	private void _0023_003DzluATrA4_003D(EntityGraphicsData[] _0023_003DziUD4gJmt9upv)
	{
		if (_0023_003DziUD4gJmt9upv != null)
		{
			for (int i = 0; i < _0023_003DziUD4gJmt9upv.Length; i++)
			{
				_0023_003DziUD4gJmt9upv[i]?.Dispose();
			}
		}
	}

	public double GetArea(out Point3D centroid)
	{
		if (skin != null)
		{
			return skin.GetArea(out centroid);
		}
		centroid = null;
		return 0.0;
	}

	public double GetVolume(out Point3D centroid)
	{
		if (skin != null)
		{
			return skin.GetVolume(out centroid);
		}
		centroid = null;
		return 0.0;
	}

	public void GetPrincipalAxes(out Vector3D axisX, out Vector3D axisY, out Vector3D axisZ, out double ix, out double iy, out double iz)
	{
		if (skin != null)
		{
			skin.GetPrincipalAxes(out axisX, out axisY, out axisZ, out ix, out iy, out iz);
			return;
		}
		axisX = null;
		axisY = null;
		axisZ = null;
		ix = double.NaN;
		iy = double.NaN;
		iz = double.NaN;
	}

	public void GetPrincipalAxes(out Vector3D axisX, out Vector3D axisY, out Vector3D axisZ)
	{
		GetPrincipalAxes(out axisX, out axisY, out axisZ, out var _, out var _, out var _);
	}

	public double GetMass(Material material, linearUnitsType linearUnits, massUnitsType massUnits, out double convertedDensity)
	{
		throw new NotImplementedException();
	}

	public void FlipNormal()
	{
	}

	public Mesh[] GetTessellation()
	{
		if (skin == null)
		{
			return null;
		}
		return skin.GetTessellation();
	}

	public Mesh ConvertToMesh(double deviation = 0.0, double angle = 0.0, Mesh.natureType nature = Mesh.natureType.Smooth, bool weld = true)
	{
		if (skin == null)
		{
			return null;
		}
		return (Mesh)skin.Clone();
	}

	public Brep ConvertToBrep(bool mergeFaces = true, bool mergeEdges = true)
	{
		return ConvertToMesh().ConvertToBrep(mergeFaces, mergeEdges);
	}

	public Mesh ConvertToMesh(bool deformed, ILegend legend, MaterialKeyedCollection materials, string matName)
	{
		if (materials._0023_003DzS1c2DBtqRnrg96IXUROj_00249c_003D() != null)
		{
			byte[] texture = materials._0023_003DzS1c2DBtqRnrg96IXUROj_00249c_003D().BitmapFromColors(legend.GetColorTable());
			materials.Add(matName, texture);
		}
		Mesh mesh = _0023_003DzjwyQTVXErsM0(deformed, legend);
		mesh.ColorMethod = colorMethodType.byEntity;
		mesh.Color = Color.White;
		mesh.MaterialName = matName;
		return mesh;
	}

	internal void _0023_003DzAyVSuNeHrMWU(Mesh _0023_003DzPzO_0024GUk_003D)
	{
		skin = _0023_003DzPzO_0024GUk_003D;
	}

	public override void TransformBy(Transformation xform)
	{
		foreach (Mesh elementsSlice in _elementsSlices)
		{
			elementsSlice.TransformBy(xform);
		}
		base.TransformBy(xform);
	}

	private protected override void _0023_003DzW6DreOuCtoN4OdSR3r_0024aPf8_003D(Transformation _0023_003DzLS0sR0pzioXc, bool _0023_003DzfHX6qJ20RY9Zf_2BYw_003D_003D)
	{
		TransformAllVertices(_0023_003DzLS0sR0pzioXc);
	}

	public void MergeWith(FemMesh other, bool weldNow, double tol = 1E-09)
	{
		int num = _vertices.Length;
		int num2 = other._vertices.Length;
		Array.Resize(ref _vertices, num + num2);
		for (int i = 0; i < num2; i++)
		{
			_vertices[i + num] = (Point3D)other._vertices[i].Clone();
		}
		int num3 = elements.Length;
		Array.Resize(ref elements, num3 + other.elements.Length);
		for (int j = 0; j < other.elements.Length; j++)
		{
			elements[j + num3] = (Element)other.elements[j].Clone();
			for (int k = 0; k < elements[j + num3].Connection.Length; k++)
			{
				elements[j + num3].Connection[k] += num;
			}
		}
		RegenMode = regenType.RegenAndCompile;
		if (weldNow)
		{
			_0023_003Dz6tNTbj2n_0024gTT(ref _vertices, elements, tol);
		}
	}

	private static void _0023_003Dz6tNTbj2n_0024gTT(ref Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, Element[] _0023_003DztIKjFz8_003D, double _0023_003Dzm0CYiiE_003D)
	{
		Utility.ComputeBoundingBox(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out var boxMin, out var boxMax);
		Size3D size3D = new Size3D(boxMin, boxMax);
		int _0023_003DzyDhNd0FB6wv = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length;
		Point3D[] array = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D;
		Point3D[] sourceArray = _0023_003DzWu_o2hD_0024VlVY(array, ref _0023_003DzyDhNd0FB6wv, size3D.Diagonal * _0023_003Dzm0CYiiE_003D);
		foreach (Element element in _0023_003DztIKjFz8_003D)
		{
			for (int j = 0; j < element.Connection.Length; j++)
			{
				element.Connection[j] = (int)array[element.Connection[j]].X;
			}
		}
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new Point3D[_0023_003DzyDhNd0FB6wv];
		Array.Copy(sourceArray, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzyDhNd0FB6wv);
	}

	private static Point3D[] _0023_003DzWu_o2hD_0024VlVY(Point3D[] _0023_003DzT531JqWrKLWb, ref int _0023_003DzyDhNd0FB6wv9, double _0023_003Dzm0CYiiE_003D)
	{
		double num = _0023_003Dzm0CYiiE_003D * _0023_003Dzm0CYiiE_003D;
		Point3D[] array = new Point3D[_0023_003DzyDhNd0FB6wv9];
		for (int i = 0; i < _0023_003DzyDhNd0FB6wv9; i++)
		{
			array[i] = (Point3D)_0023_003DzT531JqWrKLWb[i].Clone();
		}
		int num2 = 0;
		for (int j = 0; j < _0023_003DzyDhNd0FB6wv9; j++)
		{
			int num3 = 0;
			while (true)
			{
				if (num3 < num2)
				{
					double num4 = Math.Abs(_0023_003DzT531JqWrKLWb[j].X - array[num3].X);
					if (num4 < _0023_003Dzm0CYiiE_003D)
					{
						double num5 = Math.Abs(_0023_003DzT531JqWrKLWb[j].Y - array[num3].Y);
						if (num5 < _0023_003Dzm0CYiiE_003D)
						{
							double num6 = Math.Abs(_0023_003DzT531JqWrKLWb[j].Z - array[num3].Z);
							if (num6 < _0023_003Dzm0CYiiE_003D && num4 * num4 + num5 * num5 + num6 * num6 < num)
							{
								break;
							}
						}
					}
					num3++;
					continue;
				}
				array[num2] = (Point3D)_0023_003DzT531JqWrKLWb[j].Clone();
				num3 = num2;
				num2++;
				break;
			}
			_0023_003DzT531JqWrKLWb[j].X = num3;
		}
		_0023_003DzyDhNd0FB6wv9 = num2;
		return array;
	}

	private static Point3D[] _0023_003DzpIe_KLqxlfHnkbyIE1pNkck_003D(Point3D[] _0023_003DzT531JqWrKLWb, ref int _0023_003DzyDhNd0FB6wv9, double _0023_003Dzm0CYiiE_003D, int _0023_003DzlVBJOHWrwdu_2sxx2Q_003D_003D)
	{
		double num = _0023_003Dzm0CYiiE_003D * _0023_003Dzm0CYiiE_003D;
		Point3D[] array = new Point3D[_0023_003DzyDhNd0FB6wv9];
		for (int i = 0; i < _0023_003DzyDhNd0FB6wv9; i++)
		{
			array[i] = (Point3D)_0023_003DzT531JqWrKLWb[i].Clone();
			if (i < _0023_003DzlVBJOHWrwdu_2sxx2Q_003D_003D)
			{
				_0023_003DzT531JqWrKLWb[i].X = i;
			}
		}
		int num2 = _0023_003DzlVBJOHWrwdu_2sxx2Q_003D_003D;
		for (int j = _0023_003DzlVBJOHWrwdu_2sxx2Q_003D_003D; j < _0023_003DzyDhNd0FB6wv9; j++)
		{
			int num3 = _0023_003DzlVBJOHWrwdu_2sxx2Q_003D_003D;
			while (true)
			{
				if (num3 < num2)
				{
					double num4 = Math.Abs(_0023_003DzT531JqWrKLWb[j].X - array[num3].X);
					if (num4 < _0023_003Dzm0CYiiE_003D)
					{
						double num5 = Math.Abs(_0023_003DzT531JqWrKLWb[j].Y - array[num3].Y);
						if (num5 < _0023_003Dzm0CYiiE_003D)
						{
							double num6 = Math.Abs(_0023_003DzT531JqWrKLWb[j].Z - array[num3].Z);
							if (num6 < _0023_003Dzm0CYiiE_003D && num4 * num4 + num5 * num5 + num6 * num6 < num)
							{
								break;
							}
						}
					}
					num3++;
					continue;
				}
				array[num2] = (Point3D)_0023_003DzT531JqWrKLWb[j].Clone();
				num3 = num2;
				num2++;
				break;
			}
			_0023_003DzT531JqWrKLWb[j].X = num3;
		}
		_0023_003DzyDhNd0FB6wv9 = num2;
		return array;
	}

	internal override _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[] _0023_003DzAKDLnmImamFN(Color _0023_003Dz1MMYB1g_003D, Dictionary<string, List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>> _0023_003DzISRR3MaRx1qQ, linearUnitsType _0023_003DzsAi4oSk_003D)
	{
		Mesh mesh = _0023_003DzjwyQTVXErsM0(_0023_003Dz3bCzmTlYFzClTXfCZQ_003D_003D: false, null);
		if (mesh == null)
		{
			return new _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[0];
		}
		return mesh._0023_003DzAKDLnmImamFN(_0023_003Dz1MMYB1g_003D, _0023_003DzISRR3MaRx1qQ, _0023_003DzsAi4oSk_003D);
	}

	public void DrawTriangle(RenderContextBase context, int index)
	{
		Element element = elements[index];
		context.DrawTriangles(new Point3D[3]
		{
			_vertices[element.Connection[0]],
			_vertices[element.Connection[1]],
			_vertices[element.Connection[2]]
		}, new Vector3D(0.0, 0.0, 1.0));
	}

	internal static void _0023_003DzU4BYt20QnSgw_0024cltkw_003D_003D(RenderContextBase _0023_003DzB8iS0QA_003D, double _0023_003Dzu2WOTs7Tkxr9, double _0023_003DztxiQyb1nzdKs, double _0023_003Dz736ekIs_003D, int _0023_003Dz9q272VY_003D)
	{
		double a = Math.Atan2(0.0 - (_0023_003DztxiQyb1nzdKs - _0023_003Dzu2WOTs7Tkxr9), _0023_003Dz736ekIs_003D);
		Point3D[] array = new Point3D[_0023_003Dz9q272VY_003D * 4];
		Vector3D[] array2 = new Vector3D[_0023_003Dz9q272VY_003D * 4];
		int num = 0;
		for (int i = 0; i < _0023_003Dz9q272VY_003D; i++)
		{
			double num2 = (double)(i * 2) * Math.PI / (double)_0023_003Dz9q272VY_003D;
			double num3 = Math.Cos(num2);
			double num4 = Math.Sin(num2);
			double num5 = (double)((i + 1) * 2) * Math.PI / (double)_0023_003Dz9q272VY_003D;
			double num6 = Math.Cos(num5);
			double num7 = Math.Sin(num5);
			array2[num] = new Vector3D(num3, num4, Math.Tan(a));
			array[num++] = new Point3D(num3 * _0023_003DztxiQyb1nzdKs, num4 * _0023_003DztxiQyb1nzdKs, _0023_003Dz736ekIs_003D);
			array2[num] = new Vector3D(num3, num4, Math.Tan(a));
			array[num++] = new Point3D(num3 * _0023_003Dzu2WOTs7Tkxr9, num4 * _0023_003Dzu2WOTs7Tkxr9);
			array2[num] = new Vector3D(num6, num7, Math.Tan(a));
			array[num++] = new Point3D(num6 * _0023_003DztxiQyb1nzdKs, num7 * _0023_003DztxiQyb1nzdKs, _0023_003Dz736ekIs_003D);
			array2[num] = new Vector3D(num6, num7, Math.Tan(a));
			array[num++] = new Point3D(num6 * _0023_003Dzu2WOTs7Tkxr9, num7 * _0023_003Dzu2WOTs7Tkxr9);
		}
		_0023_003DzB8iS0QA_003D.DrawQuadStrip(array, array2);
	}

	internal static void _0023_003Dzpdjk_0024b7Elixi(RenderContextBase _0023_003DzB8iS0QA_003D, double _0023_003DzobiuKb8PuTBU, double _0023_003DznW4EU1BCrSeB, int _0023_003Dz9q272VY_003D)
	{
		Point3D[] array = new Point3D[_0023_003Dz9q272VY_003D * 4];
		Vector3D[] array2 = new Vector3D[_0023_003Dz9q272VY_003D * 4];
		int num = 0;
		for (int i = 0; i < _0023_003Dz9q272VY_003D; i++)
		{
			double num2 = (double)(i * 2) * Math.PI / (double)_0023_003Dz9q272VY_003D;
			double num3 = Math.Cos(num2);
			double num4 = Math.Sin(num2);
			double num5 = (double)((i + 1) * 2) * Math.PI / (double)_0023_003Dz9q272VY_003D;
			double num6 = Math.Cos(num5);
			double num7 = Math.Sin(num5);
			array2[num] = new Vector3D(0.0, 0.0, 1.0);
			array[num++] = new Point3D(num3 * _0023_003DzobiuKb8PuTBU, num4 * _0023_003DzobiuKb8PuTBU);
			array2[num] = new Vector3D(0.0, 0.0, 1.0);
			array[num++] = new Point3D(num3 * _0023_003DznW4EU1BCrSeB, num4 * _0023_003DznW4EU1BCrSeB);
			array2[num] = new Vector3D(0.0, 0.0, 1.0);
			array[num++] = new Point3D(num6 * _0023_003DzobiuKb8PuTBU, num7 * _0023_003DzobiuKb8PuTBU);
			array2[num] = new Vector3D(0.0, 0.0, 1.0);
			array[num++] = new Point3D(num6 * _0023_003DznW4EU1BCrSeB, num7 * _0023_003DznW4EU1BCrSeB);
			array2[num] = new Vector3D(0.0, 0.0, 1.0);
			array[num++] = new Point3D(num6 * _0023_003DzobiuKb8PuTBU, num7 * _0023_003DzobiuKb8PuTBU);
			_0023_003DzB8iS0QA_003D.DrawQuadStrip(array, array2);
		}
		_0023_003DzB8iS0QA_003D.DrawQuadStrip(array, array2);
	}

	private void _0023_003Dzaj1GQEvXFp9J9kuIyyEhE7suJlc6(RenderContextBase _0023_003DzB8iS0QA_003D, int _0023_003DzAdg8iZA_003D, EntityGraphicsData _0023_003DzuclK_gkP_Ud7H0EjsAuQ_0024y0_003D, bool _0023_003DzRBp0ovQaJTSK, double[] _0023_003DzKPUTl6c_003D)
	{
		_0023_003DzB8iS0QA_003D.PushModelView();
		_0023_003DzB8iS0QA_003D.MultMatrixModelView(new Translation(_vertices[_0023_003DzAdg8iZA_003D].X, _vertices[_0023_003DzAdg8iZA_003D].Y, _vertices[_0023_003DzAdg8iZA_003D].Z));
		if (_0023_003DzRBp0ovQaJTSK)
		{
			_0023_003DzB8iS0QA_003D.MultMatrixModelView(_0023_003DzKPUTl6c_003D);
		}
		_0023_003DzB8iS0QA_003D.MultMatrixModelView(new devDept.Geometry.Rotation(Math.PI / 2.0, Vector3D.AxisY));
		double num = _optimalSymbolSize * symbolSize;
		_0023_003DzB8iS0QA_003D.MultMatrixModelView(new Scaling(num, num, num));
		_0023_003DzB8iS0QA_003D.Draw(_0023_003DzuclK_gkP_Ud7H0EjsAuQ_0024y0_003D);
		_0023_003DzB8iS0QA_003D.PopModelView();
	}

	private void _0023_003DzSSaJeMHPVFzKj_0024plvGpPwGApGkPT(RenderContextBase _0023_003DzB8iS0QA_003D, int _0023_003DzAdg8iZA_003D, EntityGraphicsData _0023_003DzuclK_gkP_Ud7H0EjsAuQ_0024y0_003D, bool _0023_003DzRBp0ovQaJTSK, double[] _0023_003DzKPUTl6c_003D)
	{
		_0023_003DzB8iS0QA_003D.PushModelView();
		_0023_003DzB8iS0QA_003D.MultMatrixModelView(new Translation(_vertices[_0023_003DzAdg8iZA_003D].X, _vertices[_0023_003DzAdg8iZA_003D].Y, _vertices[_0023_003DzAdg8iZA_003D].Z));
		if (_0023_003DzRBp0ovQaJTSK)
		{
			_0023_003DzB8iS0QA_003D.MultMatrixModelView(_0023_003DzKPUTl6c_003D);
		}
		_0023_003DzB8iS0QA_003D.MultMatrixModelView(new devDept.Geometry.Rotation(Utility.DegToRad(270.0), Vector3D.AxisX));
		double num = _optimalSymbolSize * symbolSize;
		_0023_003DzB8iS0QA_003D.MultMatrixModelView(new Scaling(num, num, num));
		_0023_003DzB8iS0QA_003D.Draw(_0023_003DzuclK_gkP_Ud7H0EjsAuQ_0024y0_003D);
		_0023_003DzB8iS0QA_003D.PopModelView();
	}

	private void _0023_003DzW8SlabN0ylvaCjwK3Il9MNKRjYtO(RenderContextBase _0023_003DzB8iS0QA_003D, int _0023_003DzAdg8iZA_003D, EntityGraphicsData _0023_003DzuclK_gkP_Ud7H0EjsAuQ_0024y0_003D, bool _0023_003DzRBp0ovQaJTSK, double[] _0023_003DzKPUTl6c_003D)
	{
		_0023_003DzB8iS0QA_003D.PushModelView();
		_0023_003DzB8iS0QA_003D.MultMatrixModelView(new Translation(_vertices[_0023_003DzAdg8iZA_003D].X, _vertices[_0023_003DzAdg8iZA_003D].Y, _vertices[_0023_003DzAdg8iZA_003D].Z));
		if (_0023_003DzRBp0ovQaJTSK)
		{
			_0023_003DzB8iS0QA_003D.MultMatrixModelView(_0023_003DzKPUTl6c_003D);
		}
		double num = _optimalSymbolSize * symbolSize;
		_0023_003DzB8iS0QA_003D.MultMatrixModelView(new Scaling(num, num, num));
		_0023_003DzB8iS0QA_003D.Draw(_0023_003DzuclK_gkP_Ud7H0EjsAuQ_0024y0_003D);
		_0023_003DzB8iS0QA_003D.PopModelView();
	}

	private void _0023_003DzX_00249b4bh51I12qd2V7A_003D_003D(RenderContextBase _0023_003DzB8iS0QA_003D, int _0023_003DzAdg8iZA_003D, EntityGraphicsData _0023_003DzR365zY_0024RjwTQ6juh1w_003D_003D, bool _0023_003DzRBp0ovQaJTSK, double[] _0023_003DzKPUTl6c_003D, Transformation _0023_003DzLS0sR0pzioXc)
	{
		_0023_003DzB8iS0QA_003D.PushModelView();
		_0023_003DzB8iS0QA_003D.MultMatrixModelView(new Translation(_vertices[_0023_003DzAdg8iZA_003D].X, _vertices[_0023_003DzAdg8iZA_003D].Y, _vertices[_0023_003DzAdg8iZA_003D].Z));
		if (_0023_003DzRBp0ovQaJTSK)
		{
			_0023_003DzB8iS0QA_003D.MultMatrixModelView(_0023_003DzKPUTl6c_003D);
		}
		if (_0023_003DzLS0sR0pzioXc != null)
		{
			_0023_003DzB8iS0QA_003D.MultMatrixModelView(_0023_003DzLS0sR0pzioXc);
		}
		double num = _optimalSymbolSize * symbolSize;
		_0023_003DzB8iS0QA_003D.MultMatrixModelView(new Scaling(num, num, num));
		_0023_003DzB8iS0QA_003D.Draw(_0023_003DzR365zY_0024RjwTQ6juh1w_003D_003D);
		_0023_003DzB8iS0QA_003D.PopModelView();
	}

	private void _0023_003DzICWjdqy2zYFt(RenderContextBase _0023_003DzB8iS0QA_003D, int _0023_003DzAdg8iZA_003D, EntityGraphicsData _0023_003DzL8zLm7vHAATQ, bool _0023_003DzRBp0ovQaJTSK, double[] _0023_003DzKPUTl6c_003D)
	{
		Node node = _vertices[_0023_003DzAdg8iZA_003D] as Node;
		Vector3D vector3D = new Vector3D(node.load[0], node.load[1], node.load[2]);
		_0023_003DzB8iS0QA_003D.PushModelView();
		_0023_003DzB8iS0QA_003D.MultMatrixModelView(new Translation(_vertices[_0023_003DzAdg8iZA_003D].X, _vertices[_0023_003DzAdg8iZA_003D].Y, _vertices[_0023_003DzAdg8iZA_003D].Z));
		if (_0023_003DzRBp0ovQaJTSK)
		{
			_0023_003DzB8iS0QA_003D.MultMatrixModelView(_0023_003DzKPUTl6c_003D);
		}
		_0023_003DzB8iS0QA_003D.MultMatrixModelView(new devDept.Geometry.Rotation(vector3D.AngleInXY, Vector3D.AxisZ));
		_0023_003DzB8iS0QA_003D.MultMatrixModelView(new devDept.Geometry.Rotation(vector3D.AngleFromXY + Math.PI / 2.0, -1.0 * Vector3D.AxisY));
		double length = new Vector3D(node.load).Length;
		double num = _optimalSymbolSize * length / maxArrowLen * symbolSize;
		_0023_003DzB8iS0QA_003D.MultMatrixModelView(new Scaling(num, num, num));
		_0023_003DzB8iS0QA_003D.Draw(_0023_003DzL8zLm7vHAATQ);
		_0023_003DzB8iS0QA_003D.PopModelView();
	}

	private void _0023_003DzxZpCkwvGc0mA(RenderContextBase _0023_003DzB8iS0QA_003D, Point3D _0023_003DzoMNiNRw_003D, Vector3D _0023_003Dz77g161c_003D, EntityGraphicsData _0023_003DzL8zLm7vHAATQ, bool _0023_003DzRBp0ovQaJTSK, double[] _0023_003DzKPUTl6c_003D)
	{
		_0023_003DzB8iS0QA_003D.PushModelView();
		_0023_003DzB8iS0QA_003D.MultMatrixModelView(new Translation(_0023_003DzoMNiNRw_003D.X, _0023_003DzoMNiNRw_003D.Y, _0023_003DzoMNiNRw_003D.Z));
		if (_0023_003DzRBp0ovQaJTSK)
		{
			_0023_003DzB8iS0QA_003D.MultMatrixModelView(_0023_003DzKPUTl6c_003D);
		}
		_0023_003DzB8iS0QA_003D.MultMatrixModelView(new devDept.Geometry.Rotation(_0023_003Dz77g161c_003D.AngleInXY, Vector3D.AxisZ));
		_0023_003DzB8iS0QA_003D.MultMatrixModelView(new devDept.Geometry.Rotation(_0023_003Dz77g161c_003D.AngleFromXY + Math.PI / 2.0, -1.0 * Vector3D.AxisY));
		double num = _optimalSymbolSize * symbolSize;
		_0023_003DzB8iS0QA_003D.MultMatrixModelView(new Scaling(num, num, num));
		_0023_003DzB8iS0QA_003D.Draw(_0023_003DzL8zLm7vHAATQ);
		_0023_003DzB8iS0QA_003D.PopModelView();
	}

	private void _0023_003Dz6Fr7YJlmkfjk7B_tKYlB5P0_003D(RenderContextBase _0023_003DzB8iS0QA_003D, int _0023_003DzAdg8iZA_003D, EntityGraphicsData _0023_003DzL8zLm7vHAATQ, bool _0023_003DzRBp0ovQaJTSK, double[] _0023_003DzKPUTl6c_003D, Vector3D _0023_003Dz77g161c_003D)
	{
		_ = _vertices[_0023_003DzAdg8iZA_003D];
		_0023_003DzB8iS0QA_003D.PushModelView();
		_0023_003DzB8iS0QA_003D.TranslateMatrixModelView(_vertices[_0023_003DzAdg8iZA_003D].X, _vertices[_0023_003DzAdg8iZA_003D].Y, _vertices[_0023_003DzAdg8iZA_003D].Z);
		if (_0023_003DzRBp0ovQaJTSK)
		{
			_0023_003DzB8iS0QA_003D.MultMatrixModelView(_0023_003DzKPUTl6c_003D);
		}
		_0023_003DzB8iS0QA_003D.RotateMatrixModelView(Utility.RadToDeg(_0023_003Dz77g161c_003D.AngleInXY), 0.0, 0.0, 1.0);
		_0023_003DzB8iS0QA_003D.RotateMatrixModelView(Utility.RadToDeg(_0023_003Dz77g161c_003D.AngleFromXY) + 90.0, 0.0, -1.0, 0.0);
		double num = Utility.Max(Math.Abs(_0023_003Dz77g161c_003D.X), Math.Abs(_0023_003Dz77g161c_003D.Y), Math.Abs(_0023_003Dz77g161c_003D.Z));
		_0023_003DzB8iS0QA_003D.ScaleMatrixModelView(num / 10000.0, num / 10000.0, num / 10000.0);
		_0023_003DzB8iS0QA_003D.Draw(_0023_003DzL8zLm7vHAATQ);
		_0023_003DzB8iS0QA_003D.PopModelView();
	}

	private void _0023_003Dz9YDJ40RKEsW5(RenderContextBase _0023_003DzB8iS0QA_003D, int _0023_003DzAdg8iZA_003D, EntityGraphicsData _0023_003Dz5afXaSMuru2h, bool _0023_003DzRBp0ovQaJTSK, double[] _0023_003DzKPUTl6c_003D, float _0023_003Dzx8iXvXkP28j5)
	{
		_0023_003DzB8iS0QA_003D.PushModelView();
		_0023_003DzB8iS0QA_003D.TranslateMatrixModelView(_vertices[_0023_003DzAdg8iZA_003D].X, _vertices[_0023_003DzAdg8iZA_003D].Y, _vertices[_0023_003DzAdg8iZA_003D].Z);
		if (_0023_003DzRBp0ovQaJTSK)
		{
			_0023_003DzB8iS0QA_003D.MultMatrixModelView(_0023_003DzKPUTl6c_003D);
		}
		_0023_003DzB8iS0QA_003D.MultMatrixModelView(new devDept.Geometry.Rotation(Utility.DegToRad(_0023_003Dzx8iXvXkP28j5), Vector3D.AxisY));
		_0023_003DzB8iS0QA_003D.Draw(_0023_003Dz5afXaSMuru2h);
		_0023_003DzB8iS0QA_003D.PopModelView();
	}

	internal static IndexLine[] _0023_003DzLfUvlgjC8bTq(double _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D, int[][] _0023_003DzpPOEJqcAh7Lr, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, Vector3D[] _0023_003Dzg0c6BAOiZbTlEm4Tgw_003D_003D)
	{
		LinkedList<SharedEdge>[] edgesPerVertex;
		List<IndexLine> list = new List<IndexLine>(Utility.GetEdgesWithoutDuplicates(_0023_003DzpPOEJqcAh7Lr, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length, out edgesPerVertex).GetLength(0));
		double num = Math.Cos(_0023_003DznDeo9kRSCPBn8AZYIA_003D_003D);
		for (int i = 0; i < edgesPerVertex.Length; i++)
		{
			for (LinkedListNode<SharedEdge> linkedListNode = edgesPerVertex[i].First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				if (linkedListNode.Value.Dad == -1)
				{
					list.Add(new IndexLine(i, linkedListNode.Value.V2));
				}
				else if (_0023_003Dzg0c6BAOiZbTlEm4Tgw_003D_003D[linkedListNode.Value.Mum] * _0023_003Dzg0c6BAOiZbTlEm4Tgw_003D_003D[linkedListNode.Value.Dad] <= num)
				{
					list.Add(new IndexLine(i, linkedListNode.Value.V2));
				}
			}
		}
		return list.ToArray();
	}

	private void _0023_003DzR9P7GK5550gG(ILegend _0023_003DzK_lIM315NEeH, string _0023_003Dz7krrKyA_003D, ref double _0023_003DzF7v9r2A_003D, ref double _0023_003Dz8dK2uhU_003D)
	{
		_0023_003DzK_lIM315NEeH.Title = _0023_003Dz7krrKyA_003D;
		if (_0023_003DzK_lIM315NEeH.Slave)
		{
			_0023_003DzK_lIM315NEeH.SetRange(_0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
			return;
		}
		_0023_003DzF7v9r2A_003D = _0023_003DzK_lIM315NEeH.Min;
		_0023_003Dz8dK2uhU_003D = _0023_003DzK_lIM315NEeH.Max;
	}

	protected internal override bool InsideOrCrossingFrustum(FrustumParams data)
	{
		if (data.Transformation == null)
		{
			Element[] array = elements;
			foreach (Element element in array)
			{
				Point3D point3D = _vertices[element.Connection[0]];
				Point3D point3D2 = _vertices[element.Connection[1]];
				Segment3D segment = new Segment3D(point3D, point3D2);
				if (Utility.IsSegmentInsideOrCrossing(data.Frustum, segment))
				{
					AddSelectedItemLeaf(data);
					return true;
				}
				if (element.Connection.Length > 2)
				{
					Point3D point3D3 = _vertices[element.Connection[2]];
					segment = new Segment3D(point3D2, point3D3);
					if (Utility.IsSegmentInsideOrCrossing(data.Frustum, segment))
					{
						AddSelectedItemLeaf(data);
						return true;
					}
					segment = new Segment3D(point3D3, point3D);
					if (Utility.IsSegmentInsideOrCrossing(data.Frustum, segment))
					{
						AddSelectedItemLeaf(data);
						return true;
					}
				}
			}
		}
		else
		{
			Element[] array = elements;
			foreach (Element element2 in array)
			{
				Point3D point3D4 = data.Transformation * _vertices[element2.Connection[0]];
				Point3D point3D5 = data.Transformation * _vertices[element2.Connection[1]];
				Segment3D segment = new Segment3D(point3D4, point3D5);
				if (Utility.IsSegmentInsideOrCrossing(data.Frustum, segment))
				{
					AddSelectedItemLeaf(data);
					return true;
				}
				if (element2.Connection.Length > 2)
				{
					Point3D point3D6 = data.Transformation * _vertices[element2.Connection[2]];
					segment = new Segment3D(point3D5, point3D6);
					if (Utility.IsSegmentInsideOrCrossing(data.Frustum, segment))
					{
						AddSelectedItemLeaf(data);
						return true;
					}
					segment = new Segment3D(point3D6, point3D4);
					if (Utility.IsSegmentInsideOrCrossing(data.Frustum, segment))
					{
						AddSelectedItemLeaf(data);
						return true;
					}
				}
			}
		}
		return false;
	}

	protected internal override bool ThroughTriangle(FrustumParams data)
	{
		if (skin != null && skin.ThroughTriangle(data))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	internal override void _0023_003Dz_0024_0024rGbexgW9YV(IList<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003Dza_SABTbwi5q2, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, ref int _0023_003DzyzK8swU_003D)
	{
		_0023_003DzjwyQTVXErsM0(_0023_003Dz3bCzmTlYFzClTXfCZQ_003D_003D: false, null)?._0023_003Dz_0024_0024rGbexgW9YV(_0023_003Dza_SABTbwi5q2, _0023_003DzJO1FWlQ_003D, ref _0023_003DzyzK8swU_003D);
	}

	internal Mesh _0023_003DzjwyQTVXErsM0(bool _0023_003Dz3bCzmTlYFzClTXfCZQ_003D_003D, ILegend _0023_003DzK_lIM315NEeH)
	{
		if (skin == null)
		{
			return null;
		}
		Mesh mesh = (Mesh)skin.Clone();
		if (_0023_003DzK_lIM315NEeH != null)
		{
			mesh.TextureCoords = new PointF[skin.Vertices.Length];
		}
		for (int i = 0; i < mesh.Vertices.Length; i++)
		{
			Node node = (Node)mesh.Vertices[i];
			if (_0023_003Dz3bCzmTlYFzClTXfCZQ_003D_003D)
			{
				Node node2 = (Node)skin.Vertices[i];
				mesh.Vertices[i] = new Point3D(node2.X + node2.Unknowns[_modeIndex][0] * _ampFactor, node2.Y + node2.Unknowns[_modeIndex][1] * _ampFactor, node2.Z + node2.Unknowns[_modeIndex][2] * _ampFactor);
			}
			if (_0023_003DzK_lIM315NEeH != null)
			{
				mesh.TextureCoords[i] = new PointF((float)_0023_003DzK_lIM315NEeH.Normalize(node.PlotValue), 0f);
				for (int j = 0; j < mesh.Triangles.Length; j++)
				{
					IndexTriangle indexTriangle = mesh.Triangles[j];
					RichSmoothTriangle richSmoothTriangle = new RichSmoothTriangle(indexTriangle.V1, indexTriangle.V2, indexTriangle.V3, indexTriangle.V1, indexTriangle.V2, indexTriangle.V3, indexTriangle.V1, indexTriangle.V2, indexTriangle.V3);
					mesh.Triangles[j] = richSmoothTriangle;
				}
			}
		}
		Utility.Compact(mesh.Vertices, mesh.Triangles, out var compacted);
		mesh.Vertices = compacted;
		mesh.UpdateNormals();
		mesh.ComputeEdges();
		mesh.CopyAttributes(this);
		return mesh;
	}

	protected internal override bool GetAllVertices(TraversalParams data, out IList<float> verticesCoords)
	{
		Utility._0023_003Dzyx35VoBSR6flPmM7uA_003D_003D(_vertices, out var _0023_003DzTbDlaOM_003D);
		verticesCoords = _0023_003DzTbDlaOM_003D;
		return true;
	}

	protected internal override bool ComputeBoundingBox(TraversalParams data, out Point3D boxMin, out Point3D boxMax)
	{
		boxMin = Point3D.MaxValue;
		boxMax = Point3D.MinValue;
		Point3D point3D = Point3D.MaxValue;
		Point3D point3D2 = Point3D.MinValue;
		Node node = new Node(0.0, 0.0, 0.0);
		if (_vertices != null && _vertices.Length != 0 && _vertices[0] != null)
		{
			if (data == null || data.Transformation == null || data.Transformation.IsIdentity())
			{
				Element[] array = elements;
				for (int i = 0; i < array.Length; i++)
				{
					int[] connection = array[i].Connection;
					foreach (int num in connection)
					{
						Node node2 = (Node)_vertices[num];
						Utility.UpdateMinMaxSlow(node2, boxMin, boxMax);
						Utility.UpdateMinMaxSlow(node2, point3D, point3D2);
						if (plotMode != plotType.Mesh)
						{
							node.X = node2.X;
							node.Y = node2.Y;
							node.Z = node2.Z;
							Utility.UpdateMinMaxSlow(node, boxMin, boxMax);
						}
					}
				}
			}
			else
			{
				Element[] array = elements;
				for (int i = 0; i < array.Length; i++)
				{
					int[] connection = array[i].Connection;
					foreach (int num2 in connection)
					{
						Node node3 = (Node)_vertices[num2];
						Utility.UpdateMinMaxSlow(data.Transformation * node3, boxMin, boxMax);
						Utility.UpdateMinMaxSlow(data.Transformation * node3, point3D, point3D2);
						if (plotMode != plotType.Mesh)
						{
							node.X = node3.X;
							node.Y = node3.Y;
							node.Z = node3.Z;
							Utility.UpdateMinMaxSlow(data.Transformation * node, boxMin, boxMax);
						}
					}
				}
			}
			if (data.Transformation == null || data.Transformation.IsIdentity())
			{
				double diagonal = new Size3D(point3D, point3D2).Diagonal;
				_optimalSymbolSize = diagonal * 0.01;
			}
			maxArrowLen = 0.0;
			Point3D[] vertices = _vertices;
			for (int i = 0; i < vertices.Length; i++)
			{
				Node node4 = (Node)vertices[i];
				if (node4.Loaded)
				{
					double length = new Vector3D(node4.load).Length;
					if (length > maxArrowLen)
					{
						maxArrowLen = length;
					}
				}
			}
			localOffset = _optimalSymbolSize * 16.0;
			if (IsBeamStudy)
			{
				double num3 = 0.0;
				Element[] array = elements;
				for (int i = 0; i < array.Length; i++)
				{
					double num4 = ((MaterialBeam)array[i].Material)._0023_003DzTrLVFlqX2Sem;
					if (num4 > num3)
					{
						num3 = num4;
					}
				}
				localOffset = Math.Max(localOffset, num3);
			}
		}
		return true;
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969611), numVertices);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969830), _vertices);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969810), numElements);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969801), elements);
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode != regenType.RegenAndCompile)
		{
			return new Point3D[2] { base.BoxMin, base.BoxMax };
		}
		return Utility.GetSampling(_vertices);
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, layers, materials, blocks));
		stringBuilder.Append(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970018) + elements.Length);
		Dictionary<Material, int> dictionary = new Dictionary<Material, int>();
		Element[] array = elements;
		foreach (Element element in array)
		{
			if (dictionary.ContainsKey(element.Material))
			{
				dictionary[element.Material]++;
			}
			else
			{
				dictionary.Add(element.Material, 1);
			}
		}
		stringBuilder.Append(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302934389));
		foreach (KeyValuePair<Material, int> item in dictionary)
		{
			stringBuilder.Append(item.Value + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + item.Key.Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908108));
		}
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956848) + linearUnits.ToString().ToLower());
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956804) + massUnits.ToString().ToLower());
		Point3D centroid;
		double area = GetArea(out centroid);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958549) + centroid);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958561) + area.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957036) + linearUnits.ToString().ToLower());
		Point3D centroid2;
		double volume = GetVolume(out centroid2);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958539) + volume.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956962) + linearUnits.ToString().ToLower());
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958524) + centroid2);
		return stringBuilder.ToString();
	}

	public Mesh ConvertToMesh(bool includeDisplacements)
	{
		return _0023_003DzjwyQTVXErsM0(includeDisplacements, null);
	}

	private void _0023_003DzRZsNU9uHQp3MDRUD_0024A_003D_003D(ILegend _0023_003DzK_lIM315NEeH)
	{
		_0023_003Dz2590AGndWcVccsIaNg_003D_003D();
		bool flag = solved && plotMode != plotType.Mesh;
		Element[] array = Elements;
		foreach (Element element in array)
		{
			if (!(element is Element3D))
			{
				continue;
			}
			Element3D element3D = (Element3D)element;
			if (element3D._0023_003DzrBgJrTjgFFt3MwQiAChxhcoHohTg(ClippingPlane, element3D.Connection, Vertices))
			{
				Mesh mesh = element3D.SliceElementWithPlane(flag, ClippingPlane, Vertices, base.BoxSize, _0023_003DzK_lIM315NEeH);
				if (mesh != null)
				{
					mesh.UpdateNormals();
					_elementsSlices.Add(mesh);
				}
			}
		}
	}

	public Mesh Slice(Plane pln, ILegend legend, double radius = 0.001)
	{
		bool flag = solved && plotMode != plotType.Mesh;
		Mesh mesh = null;
		Element[] array = Elements;
		foreach (Element element in array)
		{
			if (!(element is Element3D))
			{
				continue;
			}
			Element3D element3D = (Element3D)element;
			if (!element3D._0023_003DzrBgJrTjgFFt3MwQiAChxhcoHohTg(pln, element3D.Connection, Vertices))
			{
				continue;
			}
			Mesh mesh2 = element3D.SliceElementWithPlane(flag, pln, Vertices, base.BoxSize, legend);
			if (mesh2 != null)
			{
				if (mesh == null)
				{
					mesh = ((!flag) ? new FemMeshSlice(mesh2.Vertices, mesh2.Triangles) : new FemMeshSliceContour(legend, contourPlot)
					{
						Vertices = mesh2.Vertices,
						Triangles = mesh2.Triangles,
						TextureCoords = mesh2.TextureCoords,
						Normals = mesh2.Normals
					});
					mesh.CopyAttributes(this);
				}
				else
				{
					mesh.MergeWith(mesh2, weldNow: false, recomputeEdges: false);
				}
			}
		}
		if (mesh != null)
		{
			mesh.Weld(radius);
			mesh.EdgeStyle = Mesh.edgeStyleType.Free;
			mesh.ComputeEdges();
		}
		return mesh;
	}

	private bool _0023_003DzXZywQjX8A5Ga(int[] _0023_003DzPJoLKSA_003D, out int _0023_003DzKAXXKpk_003D, out int _0023_003Dzj6OQ9jH7xx3g)
	{
		return _0023_003DzXZywQjX8A5Ga(_0023_003DzPJoLKSA_003D, elements, out _0023_003DzKAXXKpk_003D, out _0023_003Dzj6OQ9jH7xx3g);
	}

	internal static bool _0023_003DzXZywQjX8A5Ga(int[] _0023_003DzPJoLKSA_003D, Element[] _0023_003DztIKjFz8_003D, out int _0023_003DzKAXXKpk_003D, out int _0023_003Dzj6OQ9jH7xx3g)
	{
		_0023_003DzKAXXKpk_003D = -1;
		_0023_003Dzj6OQ9jH7xx3g = -1;
		for (int i = 0; i < _0023_003DztIKjFz8_003D.Length; i++)
		{
			Element element = _0023_003DztIKjFz8_003D[i];
			int num = 0;
			int[] array = _0023_003DzPJoLKSA_003D;
			foreach (int _0023_003DzyzK8swU_003D in array)
			{
				if (_0023_003Dzxbr8_0024Jk_003D(element.Connection, _0023_003DzyzK8swU_003D))
				{
					num++;
				}
			}
			if (num != _0023_003DzPJoLKSA_003D.Length)
			{
				continue;
			}
			_0023_003DzKAXXKpk_003D = i;
			if (element is Element2D)
			{
				Element2D element2D = (Element2D)element;
				for (int k = 0; k < element2D.Edges.Length; k++)
				{
					Element2D.Edge edge = element2D.Edges[k];
					num = 0;
					array = _0023_003DzPJoLKSA_003D;
					foreach (int _0023_003DzyzK8swU_003D2 in array)
					{
						if (_0023_003Dzxbr8_0024Jk_003D(edge.Indices, _0023_003DzyzK8swU_003D2, element2D.Connection))
						{
							num++;
						}
					}
					if (num == _0023_003DzPJoLKSA_003D.Length)
					{
						_0023_003Dzj6OQ9jH7xx3g = k;
						return true;
					}
				}
				continue;
			}
			Element3D element3D = (Element3D)element;
			for (int l = 0; l < element3D.Faces.Length; l++)
			{
				Element.Face face = element3D.Faces[l];
				num = 0;
				array = _0023_003DzPJoLKSA_003D;
				foreach (int _0023_003DzyzK8swU_003D3 in array)
				{
					if (_0023_003Dzxbr8_0024Jk_003D(face.Indices, _0023_003DzyzK8swU_003D3, element3D.Connection))
					{
						num++;
					}
				}
				if (num == _0023_003DzPJoLKSA_003D.Length)
				{
					_0023_003Dzj6OQ9jH7xx3g = l;
					return true;
				}
			}
		}
		return false;
	}

	private static bool _0023_003Dzxbr8_0024Jk_003D(int[] _0023_003DzTbDlaOM_003D, int _0023_003DzyzK8swU_003D)
	{
		for (int i = 0; i < _0023_003DzTbDlaOM_003D.Length; i++)
		{
			if (_0023_003DzTbDlaOM_003D[i] == _0023_003DzyzK8swU_003D)
			{
				return true;
			}
		}
		return false;
	}

	private static bool _0023_003Dzxbr8_0024Jk_003D(byte[] _0023_003DzTbDlaOM_003D, int _0023_003DzyzK8swU_003D, int[] _0023_003DzfYMyE9c_003D)
	{
		for (int i = 0; i < _0023_003DzTbDlaOM_003D.Length; i++)
		{
			if (_0023_003DzfYMyE9c_003D[_0023_003DzTbDlaOM_003D[i]] == _0023_003DzyzK8swU_003D)
			{
				return true;
			}
		}
		return false;
	}

	public void GetTightBBox(out Point3D boxMin, out Point3D boxMax)
	{
		ComputeBoundingBox(null, out boxMin, out boxMax);
	}
}
