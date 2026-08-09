using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Fem;

public abstract class SolverBase : WorkUnit
{
	private sealed class _0023_003Dz1hJs_eYOlCbNZaKaGq4SmFc_003D
	{
		public SolverBase _0023_003DzopRx0_MBcTQs;

		public bool _0023_003Dz6lNmKJpyuXKwcmbAjw_003D_003D;

		internal void _0023_003DznoTt_hvUOj6XVrPp1w_003D_003D(int _0023_003Dz437_00244ak_003D)
		{
			_0023_003DzopRx0_MBcTQs.femMesh.elements[_0023_003Dz437_00244ak_003D].CalcStiffness(_0023_003DzopRx0_MBcTQs.femMesh._vertices, _0023_003Dz437_00244ak_003D);
			if (_0023_003DzopRx0_MBcTQs._0023_003DzMnDbz804W8yeOXxvHQ_003D_003D() == (_0023_003DzSx8c8OMfZIP3)1)
			{
				_0023_003DzopRx0_MBcTQs.femMesh.elements[_0023_003Dz437_00244ak_003D].CalcMass(_0023_003DzopRx0_MBcTQs.femMesh._vertices, _0023_003Dz437_00244ak_003D, _0023_003Dz6lNmKJpyuXKwcmbAjw_003D_003D);
			}
		}
	}

	private protected enum _0023_003DzSx8c8OMfZIP3
	{

	}

	protected FemMesh femMesh;

	protected int numberOfDimensions;

	protected int numberOfDegreesOfFreedom;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzCQbQAOvsEe9PPFGI_g_003D_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985387);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dzj2D_bNChJ_cFkTqdBVWKU2U_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985358);

	protected bool isBeamStudy;

	protected bool isBeam2DStudy;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzSx8c8OMfZIP3 _0023_003DzDLDReOwG0MRQ_cPa1cNJAveNbc_00241;

	public FemMesh Mesh
	{
		get
		{
			return femMesh;
		}
		set
		{
			femMesh = value;
		}
	}

	public string SolvingPreprocessingText
	{
		get
		{
			return _0023_003DzCQbQAOvsEe9PPFGI_g_003D_003D;
		}
		set
		{
			_0023_003DzCQbQAOvsEe9PPFGI_g_003D_003D = value;
		}
	}

	public string SolvingStressesText
	{
		get
		{
			return _0023_003Dzj2D_bNChJ_cFkTqdBVWKU2U_003D;
		}
		set
		{
			_0023_003Dzj2D_bNChJ_cFkTqdBVWKU2U_003D = value;
		}
	}

	private protected _0023_003DzSx8c8OMfZIP3 _0023_003DzMnDbz804W8yeOXxvHQ_003D_003D()
	{
		return _0023_003DzDLDReOwG0MRQ_cPa1cNJAveNbc_00241;
	}

	private protected void _0023_003DzSyKpZB7iGSdW_aNQJQ_003D_003D(_0023_003DzSx8c8OMfZIP3 _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzDLDReOwG0MRQ_cPa1cNJAveNbc_00241 = _0023_003DzPzO_0024GUk_003D;
	}

	internal static void _0023_003DzXVGnMutmqwegrH_PXRhv88DpTz9lBSbBsl6SNpQ_003D(int _0023_003DzEiQaM4PlWiDN, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, double[] _0023_003DzBJFJHwk_003D)
	{
		switch (_0023_003DzEiQaM4PlWiDN)
		{
		case 2:
		{
			for (int i = 0; i < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length; i++)
			{
				Node node2 = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i];
				if (node2.Rotation != null)
				{
					int num = i * 2 + 1;
					double num2 = node2.Rotation.Matrix[0, 0];
					double num3 = node2.Rotation.Matrix[1, 0];
					double num5 = node2.Rotation.Matrix[0, 1];
					double num6 = node2.Rotation.Matrix[1, 1];
					double num11 = num2 * _0023_003DzBJFJHwk_003D[num - 1] + num3 * _0023_003DzBJFJHwk_003D[num];
					double num12 = num5 * _0023_003DzBJFJHwk_003D[num - 1] + num6 * _0023_003DzBJFJHwk_003D[num];
					_0023_003DzBJFJHwk_003D[num - 1] = num11;
					_0023_003DzBJFJHwk_003D[num] = num12;
					if (node2.Reactions != null)
					{
						num11 = num2 * node2.Reactions[0] + num3 * node2.Reactions[1];
						num12 = num5 * node2.Reactions[0] + num6 * node2.Reactions[1];
						node2.Reactions[0] = num11;
						node2.Reactions[1] = num12;
					}
				}
			}
			break;
		}
		case 3:
		{
			for (int i = 0; i < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length; i++)
			{
				Node node = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i];
				if (node.Rotation != null)
				{
					int num = i * 3 + 1;
					double num2 = node.Rotation.Matrix[0, 0];
					double num3 = node.Rotation.Matrix[1, 0];
					double num4 = node.Rotation.Matrix[2, 0];
					double num5 = node.Rotation.Matrix[0, 1];
					double num6 = node.Rotation.Matrix[1, 1];
					double num7 = node.Rotation.Matrix[2, 1];
					double num8 = node.Rotation.Matrix[0, 2];
					double num9 = node.Rotation.Matrix[1, 2];
					double num10 = node.Rotation.Matrix[2, 2];
					double num11 = num2 * _0023_003DzBJFJHwk_003D[num - 1] + num3 * _0023_003DzBJFJHwk_003D[num] + num4 * _0023_003DzBJFJHwk_003D[num + 1];
					double num12 = num5 * _0023_003DzBJFJHwk_003D[num - 1] + num6 * _0023_003DzBJFJHwk_003D[num] + num7 * _0023_003DzBJFJHwk_003D[num + 1];
					double num13 = num8 * _0023_003DzBJFJHwk_003D[num - 1] + num9 * _0023_003DzBJFJHwk_003D[num] + num10 * _0023_003DzBJFJHwk_003D[num + 1];
					_0023_003DzBJFJHwk_003D[num - 1] = num11;
					_0023_003DzBJFJHwk_003D[num] = num12;
					_0023_003DzBJFJHwk_003D[num + 1] = num13;
					if (node.Reactions != null)
					{
						num11 = num2 * node.Reactions[0] + num3 * node.Reactions[1] + num4 * node.Reactions[2];
						num12 = num5 * node.Reactions[0] + num6 * node.Reactions[1] + num7 * node.Reactions[2];
						num13 = num8 * node.Reactions[0] + num9 * node.Reactions[1] + num10 * node.Reactions[2];
						node.Reactions[0] = num11;
						node.Reactions[1] = num12;
						node.Reactions[2] = num13;
					}
				}
			}
			break;
		}
		}
	}

	private static void _0023_003DzhS7SIpoFd2oH(int _0023_003DzEiQaM4PlWiDN, double[] _0023_003Dz1v6oPQk_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, Element[] _0023_003DztIKjFz8_003D)
	{
		double[,] array = new double[_0023_003DzEiQaM4PlWiDN, _0023_003DzEiQaM4PlWiDN];
		double[,] array2 = new double[_0023_003DzEiQaM4PlWiDN, _0023_003DzEiQaM4PlWiDN];
		foreach (Element element in _0023_003DztIKjFz8_003D)
		{
			if (element is Joint2D)
			{
				continue;
			}
			for (int j = 0; j < element.NumberOfNodes; j++)
			{
				Node node = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[element.Connection[j]];
				if (node.Rotation != null)
				{
					for (int k = 0; k < _0023_003DzEiQaM4PlWiDN; k++)
					{
						array[0, k] = element.tLoad[j * _0023_003DzEiQaM4PlWiDN + k];
					}
					double[,] _0023_003Dz1v6oPQk_003D2 = Matrix.Transpose(node.Rotation.Matrix);
					Element._0023_003Dz3PdJaxsL3lyc(array2, _0023_003Dz1v6oPQk_003D2, array, _0023_003DzEiQaM4PlWiDN, 1, _0023_003DzEiQaM4PlWiDN);
					for (int l = 0; l < _0023_003DzEiQaM4PlWiDN; l++)
					{
						element.tLoad[j * _0023_003DzEiQaM4PlWiDN + l] = array2[0, l];
					}
				}
			}
		}
	}

	protected void PostProcessing(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct, double[][] x, bool hasTemperature, elementType firstElType)
	{
		int num = 0;
		int length = x.GetLength(0);
		if (isBeamStudy || femMesh._vertices[0] is NodeBeam)
		{
			Point3D[] vertices = femMesh._vertices;
			for (int i = 0; i < vertices.Length; i++)
			{
				Node node = (Node)vertices[i];
				node.Unknowns = new double[length][];
				for (int j = 0; j < length; j++)
				{
					node.Unknowns[j] = new double[6]
					{
						x[j][num],
						x[j][num + 1],
						isBeam2DStudy ? 0.0 : x[j][num + 2],
						isBeam2DStudy ? 0.0 : x[j][num + 3],
						isBeam2DStudy ? 0.0 : x[j][num + 4],
						isBeam2DStudy ? x[j][num + 2] : x[j][num + 5]
					};
				}
				node.Stress = new double[6];
				num += numberOfDegreesOfFreedom;
			}
		}
		else
		{
			Point3D[] vertices = femMesh._vertices;
			for (int i = 0; i < vertices.Length; i++)
			{
				Node node2 = (Node)vertices[i];
				node2.Unknowns = new double[length][];
				for (int k = 0; k < length; k++)
				{
					node2.Unknowns[k] = new double[3]
					{
						x[k][num],
						x[k][num + 1],
						(numberOfDegreesOfFreedom > 2) ? x[k][num + 2] : 0.0
					};
				}
				node2.Stress = new double[6];
				num += numberOfDegreesOfFreedom;
			}
		}
		TransformDisplacementsAndReactions(numberOfDimensions, femMesh._vertices, out var min, out var max, out var maxLen);
		num = 0;
		int[] numberOfElementsPerNode = new int[femMesh._vertices.Length];
		for (int l = 0; l < femMesh.Elements.Length; l++)
		{
			Element element = femMesh.Elements[l];
			if (!(element is Joint2D))
			{
				element.CalcStress(femMesh.Vertices, l, numberOfElementsPerNode, hasTemperature);
			}
			UpdateProgress(num, femMesh.Elements.Length, _0023_003Dzj2D_bNChJ_cFkTqdBVWKU2U_003D, progress);
			if (Cancelled(ct))
			{
				return;
			}
		}
		AverageNodeStress(numberOfDimensions, firstElType, numberOfElementsPerNode);
		femMesh.solved = true;
		femMesh._0023_003DzBnXSyF_0024bas8jFaKSdwSEVBn31F2BZu8IRT_0024yevo_003D(_0023_003DztYQMQQfhE4WzgdPKwu_0024JPiQoceHg(min, max, maxLen));
		femMesh.AmplificationFactor = femMesh.OptimalAmplificationFactor;
	}

	protected bool PreProcessing(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct, out int maxNodeId, out int order, out bool hasTemperature, out elementType firstElType, bool lumpMass = false)
	{
		_0023_003Dz1hJs_eYOlCbNZaKaGq4SmFc_003D _0023_003Dz1hJs_eYOlCbNZaKaGq4SmFc_003D2 = new _0023_003Dz1hJs_eYOlCbNZaKaGq4SmFc_003D();
		_0023_003Dz1hJs_eYOlCbNZaKaGq4SmFc_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003Dz1hJs_eYOlCbNZaKaGq4SmFc_003D2._0023_003Dz6lNmKJpyuXKwcmbAjw_003D_003D = lumpMass;
		femMesh.solved = false;
		numberOfDimensions = femMesh.NumberOfDimensions;
		numberOfDegreesOfFreedom = femMesh.NumberOfDegreesOfFreedom;
		isBeamStudy = femMesh.IsBeamStudy;
		isBeam2DStudy = femMesh.IsBeam2DStudy;
		if (isBeamStudy && !(femMesh.Vertices[0] is NodeBeam))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984287));
		}
		maxNodeId = 0;
		Element[] elements = femMesh.elements;
		foreach (Element element in elements)
		{
			if (element is Tria3 tria)
			{
				tria._0023_003DzyWdJ4nflae0e(femMesh.Vertices);
			}
			else if (element is Quad4 quad)
			{
				quad._0023_003DzyWdJ4nflae0e(femMesh.Vertices);
			}
			element._0023_003Dzo5ycBd9ENqPa();
			int[] connection = element.Connection;
			foreach (int num in connection)
			{
				if (num > maxNodeId)
				{
					maxNodeId = num;
				}
			}
			if (element is Element2D && !(element is Truss2D))
			{
				Element2D.Edge[] edges = ((Element2D)element).Edges;
				foreach (Element2D.Edge edge in edges)
				{
					if (edge.Restraints == null)
					{
						continue;
					}
					for (int k = 0; k < edge.Indices.Length; k++)
					{
						int num2 = element.Connection[edge.Indices[k]];
						if (edge.Restraints[0])
						{
							((Node)femMesh._vertices[num2])._0023_003DzBQLVxDib9_iB(edge.displacement[0]);
						}
						if (edge.Restraints[1])
						{
							((Node)femMesh._vertices[num2])._0023_003Dzd9lfsXbEXe5u(edge.displacement[1]);
						}
					}
				}
			}
			else
			{
				if (!(element is Element3D) || element is Truss)
				{
					continue;
				}
				Element.Face[] faces = ((Element3D)element).Faces;
				foreach (Element.Face face in faces)
				{
					if (face.Restraints == null)
					{
						continue;
					}
					for (int l = 0; l < face.Indices.Length; l++)
					{
						int num3 = element.Connection[face.Indices[l]];
						if (face.Restraints[0])
						{
							((Node)femMesh._vertices[num3])._0023_003DzBQLVxDib9_iB(face.displacement[0]);
						}
						if (face.Restraints[1])
						{
							((Node)femMesh._vertices[num3])._0023_003Dzd9lfsXbEXe5u(face.displacement[1]);
						}
						if (face.Restraints[2])
						{
							((Node)femMesh._vertices[num3])._0023_003DzKv_0024B85OU7Q_00246(face.displacement[2]);
						}
					}
				}
			}
		}
		order = (maxNodeId + 1) * numberOfDegreesOfFreedom;
		int num4 = 0;
		hasTemperature = false;
		if (isBeamStudy)
		{
			if (isBeam2DStudy)
			{
				elements = femMesh.Elements;
				for (int i = 0; i < elements.Length; i++)
				{
					if (((Beam2D)elements[i]).Temperature != 0.0)
					{
						hasTemperature = true;
						break;
					}
				}
			}
			else
			{
				elements = femMesh.Elements;
				for (int i = 0; i < elements.Length; i++)
				{
					if (((Beam)elements[i]).Temperature != 0.0)
					{
						hasTemperature = true;
						break;
					}
				}
			}
		}
		else
		{
			for (int m = 0; m <= maxNodeId; m++)
			{
				Node obj = (Node)femMesh._vertices[m];
				obj.index = num4++;
				if (obj.Temperature != 0.0)
				{
					hasTemperature = true;
				}
			}
		}
		firstElType = elementType.PlaneStrain;
		if (numberOfDimensions == 2)
		{
			firstElType = femMesh.elements[0].Material.ElementType;
		}
		double[] _0023_003Dz1v6oPQk_003D = null;
		for (int n = 0; n <= maxNodeId; n++)
		{
			Node node = (Node)femMesh._vertices[n];
			if (node.Loaded || (node is NodeBeam && ((NodeBeam)node).MomentLoaded))
			{
				for (int num5 = 0; num5 < femMesh.elements.Length; num5++)
				{
					Element element2 = femMesh.elements[num5];
					if (element2 is Joint2D)
					{
						continue;
					}
					int numberOfNodes = element2.NumberOfNodes;
					int num6 = 0;
					while (num6 < numberOfNodes)
					{
						if (element2.Connection[num6] != n)
						{
							num6++;
							continue;
						}
						goto IL_04d0;
					}
					continue;
					IL_04d0:
					if (num5 > femMesh.elements.Length)
					{
						return true;
					}
					int num7 = num6 * numberOfDegreesOfFreedom;
					if (node.Load != null)
					{
						for (int num8 = 0; num8 < numberOfDimensions; num8++)
						{
							element2.load[num7 + num8] += node.Load[num8];
						}
					}
					if (!isBeamStudy)
					{
						break;
					}
					NodeBeam nodeBeam = (NodeBeam)node;
					if (nodeBeam.momentLoad == null)
					{
						break;
					}
					if (isBeam2DStudy)
					{
						element2.load[num7 + numberOfDimensions] += nodeBeam.momentLoad[2];
						break;
					}
					for (int num9 = numberOfDimensions; num9 < numberOfDegreesOfFreedom; num9++)
					{
						element2.load[num7 + num9] += nodeBeam.momentLoad[num9 - numberOfDimensions];
					}
					break;
				}
			}
			UpdateProgress(n, maxNodeId + 1, _0023_003DzCQbQAOvsEe9PPFGI_g_003D_003D, progress);
			if (Cancelled(ct))
			{
				return true;
			}
		}
		elementType elType = firstElType;
		object obj2 = null;
		elements = femMesh.elements;
		foreach (Element element3 in elements)
		{
			if (!(element3 is Joint2D) && element3.Material != obj2)
			{
				if (element3.Material != null)
				{
					element3.Material.CalcMaterialPropertyMatrix(numberOfDimensions, elType);
				}
				obj2 = element3.Material;
			}
		}
		Parallel.For(0, femMesh.elements.Length, _0023_003Dz1hJs_eYOlCbNZaKaGq4SmFc_003D2._0023_003DznoTt_hvUOj6XVrPp1w_003D_003D);
		Array.Resize(ref femMesh._vertices, maxNodeId + 1);
		if (hasTemperature)
		{
			for (int num10 = 0; num10 < femMesh.elements.Length; num10++)
			{
				Element element4 = femMesh.elements[num10];
				if (!(element4 is Joint2D))
				{
					element4.CalcTemp(num10, femMesh._vertices);
				}
			}
			_0023_003DzhS7SIpoFd2oH(numberOfDegreesOfFreedom, _0023_003Dz1v6oPQk_003D, femMesh._vertices, femMesh.elements);
			elements = femMesh.elements;
			foreach (Element element5 in elements)
			{
				if (!(element5 is Joint2D))
				{
					element5._0023_003DzTKtlMWgFyHz_();
				}
			}
		}
		elements = femMesh.elements;
		foreach (Element element6 in elements)
		{
			if (!(element6 is Joint2D) && element6.distLoad != null)
			{
				element6._0023_003DzAcG3NerU8u4d();
			}
		}
		if (femMesh.IsBeamStudy)
		{
			if (femMesh.IsBeam2DStudy)
			{
				elements = femMesh.elements;
				foreach (Element element7 in elements)
				{
					if (((Beam2D)element7)._alongBeamLoad.Value != null)
					{
						for (int num11 = 0; num11 < 6; num11++)
						{
							element7.load[num11] += ((Beam2D)element7)._alongBeamLoads[num11];
						}
					}
				}
			}
			else
			{
				elements = femMesh.elements;
				foreach (Element element8 in elements)
				{
					if (((Beam)element8)._alongBeamLoad.Value != null)
					{
						for (int num12 = 0; num12 < 12; num12++)
						{
							element8.load[num12] += ((Beam)element8)._alongBeamLoads[num12];
						}
					}
				}
			}
		}
		return false;
	}

	protected static void TransformDisplacementsAndReactions(int numberOfDims, Point3D[] vertices, out Point3D min, out Point3D max, out double maxLen)
	{
		maxLen = double.MinValue;
		min = Point3D.MaxValue;
		max = Point3D.MinValue;
		switch (numberOfDims)
		{
		case 2:
		{
			for (int i = 0; i < vertices.Length; i++)
			{
				Node node2 = (Node)vertices[i];
				if (node2.Rotation != null)
				{
					double num = node2.Rotation.Matrix[0, 0];
					double num2 = node2.Rotation.Matrix[1, 0];
					double num4 = node2.Rotation.Matrix[0, 1];
					double num5 = node2.Rotation.Matrix[1, 1];
					double num10 = num * node2.Unknowns[0][0] + num2 * node2.Unknowns[0][1];
					double num11 = num4 * node2.Unknowns[0][0] + num5 * node2.Unknowns[0][1];
					node2.Unknowns[0][0] = num10;
					node2.Unknowns[0][1] = num11;
					if (node2.Reactions != null)
					{
						num10 = num * node2.Reactions[0] + num2 * node2.Reactions[1];
						num11 = num4 * node2.Reactions[0] + num5 * node2.Reactions[1];
						node2.Reactions[0] = num10;
						node2.Reactions[1] = num11;
					}
				}
				_0023_003DzaE2MdMIktaEJ(node2, min, max);
				Vector2D vector2D = new Vector2D(node2.Unknowns[0][0], node2.Unknowns[0][1]);
				if (vector2D.Length > maxLen)
				{
					maxLen = vector2D.Length;
				}
			}
			break;
		}
		case 3:
		{
			for (int i = 0; i < vertices.Length; i++)
			{
				Node node = (Node)vertices[i];
				if (node.Rotation != null)
				{
					double num = node.Rotation.Matrix[0, 0];
					double num2 = node.Rotation.Matrix[1, 0];
					double num3 = node.Rotation.Matrix[2, 0];
					double num4 = node.Rotation.Matrix[0, 1];
					double num5 = node.Rotation.Matrix[1, 1];
					double num6 = node.Rotation.Matrix[2, 1];
					double num7 = node.Rotation.Matrix[0, 2];
					double num8 = node.Rotation.Matrix[1, 2];
					double num9 = node.Rotation.Matrix[2, 2];
					double num10 = num * node.Unknowns[0][0] + num2 * node.Unknowns[0][1] + num3 * node.Unknowns[0][2];
					double num11 = num4 * node.Unknowns[0][0] + num5 * node.Unknowns[0][1] + num6 * node.Unknowns[0][2];
					double num12 = num7 * node.Unknowns[0][0] + num8 * node.Unknowns[0][1] + num9 * node.Unknowns[0][2];
					node.Unknowns[0][0] = num10;
					node.Unknowns[0][1] = num11;
					node.Unknowns[0][2] = num12;
					if (node.Reactions != null)
					{
						num10 = num * node.Reactions[0] + num2 * node.Reactions[1] + num3 * node.Reactions[2];
						num11 = num4 * node.Reactions[0] + num5 * node.Reactions[1] + num6 * node.Reactions[2];
						num12 = num7 * node.Reactions[0] + num8 * node.Reactions[1] + num9 * node.Reactions[2];
						node.Reactions[0] = num10;
						node.Reactions[1] = num11;
						node.Reactions[2] = num12;
					}
				}
				_0023_003DzaE2MdMIktaEJ(node, min, max);
				Vector3D vector3D = new Vector3D(node.Unknowns[0][0], node.Unknowns[0][1], node.Unknowns[0][2]);
				if (vector3D.Length > maxLen)
				{
					maxLen = vector3D.Length;
				}
			}
			break;
		}
		}
	}

	private static void _0023_003DzaE2MdMIktaEJ(Point3D _0023_003DzMlCq3wk_003D, Point3D _0023_003DzF7v9r2A_003D, Point3D _0023_003Dz8dK2uhU_003D)
	{
		if (_0023_003DzMlCq3wk_003D.X < _0023_003DzF7v9r2A_003D.X)
		{
			_0023_003DzF7v9r2A_003D.X = _0023_003DzMlCq3wk_003D.X;
		}
		if (_0023_003DzMlCq3wk_003D.X > _0023_003Dz8dK2uhU_003D.X)
		{
			_0023_003Dz8dK2uhU_003D.X = _0023_003DzMlCq3wk_003D.X;
		}
		if (_0023_003DzMlCq3wk_003D.Y < _0023_003DzF7v9r2A_003D.Y)
		{
			_0023_003DzF7v9r2A_003D.Y = _0023_003DzMlCq3wk_003D.Y;
		}
		if (_0023_003DzMlCq3wk_003D.Y > _0023_003Dz8dK2uhU_003D.Y)
		{
			_0023_003Dz8dK2uhU_003D.Y = _0023_003DzMlCq3wk_003D.Y;
		}
		if (_0023_003DzMlCq3wk_003D.Z < _0023_003DzF7v9r2A_003D.Z)
		{
			_0023_003DzF7v9r2A_003D.Z = _0023_003DzMlCq3wk_003D.Z;
		}
		if (_0023_003DzMlCq3wk_003D.Z > _0023_003Dz8dK2uhU_003D.Z)
		{
			_0023_003Dz8dK2uhU_003D.Z = _0023_003DzMlCq3wk_003D.Z;
		}
	}

	private double _0023_003DztYQMQQfhE4WzgdPKwu_0024JPiQoceHg(Point3D _0023_003DzF7v9r2A_003D, Point3D _0023_003Dz8dK2uhU_003D, double _0023_003Dz77aYB0c553wg)
	{
		if (_0023_003Dz77aYB0c553wg == 0.0)
		{
			return 1.0;
		}
		return new Size3D(_0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D).Diagonal * 0.1 / _0023_003Dz77aYB0c553wg;
	}

	protected void AverageNodeStress(int dof, elementType firstElType, int[] numberOfElementsPerNode)
	{
		for (int i = 0; i < femMesh._vertices.Length; i++)
		{
			Node node = (Node)femMesh._vertices[i];
			for (int j = 0; j < 6; j++)
			{
				node.Stress[j] /= numberOfElementsPerNode[i];
			}
			Element.CalcPrincipal(node.Stress, out var vm, out var principal);
			node.VonMises = vm;
			if (dof == 2 && firstElType == elementType.PlaneStress)
			{
				Element2D._0023_003DzE4Mg1WoLAeiM(node.Stress[0], node.Stress[1], node.Stress[3], principal);
			}
			node.Principals = principal;
		}
	}
}
