using System;
using System.Collections.Generic;
using System.Drawing;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Fem;

[Serializable]
public abstract class Element
{
	[Serializable]
	public class Face
	{
		public byte[] Indices;

		[NonSerialized]
		public Vector3D[] CornerNormals;

		[NonSerialized]
		public bool Visible;

		[NonSerialized]
		public Node Centroid;

		[NonSerialized]
		public SmoothTriangle[] Triangles;

		public bool[] Restraints;

		internal double[] displacement;

		public double NormalPressure;

		public double[] Pressure;

		public Face(byte[] indices)
		{
			Indices = indices;
		}

		protected Face(Face another)
		{
			Indices = another.Indices;
			if (another.Restraints != null)
			{
				Restraints = new bool[another.Restraints.Length];
				another.Restraints.CopyTo(Restraints, 0);
			}
			if (another.displacement != null)
			{
				displacement = new double[another.displacement.Length];
				another.displacement.CopyTo(displacement, 0);
			}
			NormalPressure = another.NormalPressure;
			if (another.Pressure != null)
			{
				Pressure = new double[another.Pressure.Length];
				another.Pressure.CopyTo(Pressure, 0);
			}
		}

		public virtual object Clone()
		{
			return new Face(this);
		}

		public virtual FemFaceSurrogate ConvertToSurrogate()
		{
			return new FemFaceSurrogate(this);
		}

		public void ComputeCentroid(Element father, Point3D[] vertices)
		{
			int[] connection = father.Connection;
			switch (Indices.Length)
			{
			case 2:
			{
				Node a = (Node)vertices[connection[Indices[0]]];
				Node b = (Node)vertices[connection[Indices[1]]];
				Point3D point3D3 = Point3D.MidPoint(a, b);
				Centroid = new Node(point3D3.X, point3D3.Y, point3D3.Z);
				break;
			}
			case 3:
			{
				Node obj2 = (Node)vertices[connection[Indices[0]]];
				Node node11 = (Node)vertices[connection[Indices[1]]];
				Node node12 = (Node)vertices[connection[Indices[2]]];
				Point3D point3D2 = (obj2 + node11 + node12) / 3.0;
				Centroid = new Node(point3D2.X, point3D2.Y, point3D2.Z);
				break;
			}
			case 4:
			{
				Node obj = (Node)vertices[connection[Indices[0]]];
				Node node8 = (Node)vertices[connection[Indices[1]]];
				Node node9 = (Node)vertices[connection[Indices[2]]];
				Node node10 = (Node)vertices[connection[Indices[3]]];
				Point3D point3D = (obj + node8 + node9 + node10) / 4.0;
				Centroid = new Node(point3D.X, point3D.Y, point3D.Z);
				break;
			}
			case 6:
			{
				Node node2 = (Node)vertices[connection[Indices[0]]];
				Node node3 = (Node)vertices[connection[Indices[1]]];
				Node node4 = (Node)vertices[connection[Indices[2]]];
				Node node5 = (Node)vertices[connection[Indices[3]]];
				Node node6 = (Node)vertices[connection[Indices[4]]];
				Node node7 = (Node)vertices[connection[Indices[5]]];
				Centroid = new Node(WeightedAverage(node2.X, node3.X, node4.X, node5.X, node6.X, node7.X), WeightedAverage(node2.Y, node3.Y, node4.Y, node5.Y, node6.Y, node7.Y), WeightedAverage(node2.Z, node3.Z, node4.Z, node5.Z, node6.Z, node7.Z));
				break;
			}
			case 8:
			{
				double[] array = father._0023_003DzzIzJffApVWY5wxS3LQ_003D_003D(this);
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				for (int i = 0; i < connection.Length; i++)
				{
					Node node = (Node)vertices[connection[i]];
					num += array[i] * node.X;
					num2 += array[i] * node.Y;
					num3 += array[i] * node.Z;
				}
				if (Centroid == null)
				{
					Centroid = new Node(num, num2, num3);
					break;
				}
				Centroid.X = num;
				Centroid.Y = num2;
				Centroid.Z = num3;
				break;
			}
			case 5:
			case 7:
				break;
			}
		}

		internal Vector3D _0023_003DzVfPopQvXf7dp_0024HjsGImY_B0_003D(Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, int[] _0023_003DzvXl0C1c_003D)
		{
			if (Indices.Length > 2)
			{
				Node p = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzvXl0C1c_003D[Indices[0]]];
				Node p2 = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzvXl0C1c_003D[Indices[1]]];
				Node p3 = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzvXl0C1c_003D[Indices[Indices.Length - 1]]];
				return Vector3D.Cross(new Vector3D(p, p2), new Vector3D(p, p3));
			}
			return null;
		}

		public void UpdateCentroidUnknowns(Element father, Point3D[] vertices, int mode)
		{
			if (Indices.Length != 8)
			{
				return;
			}
			double[] array = father._0023_003DzzIzJffApVWY5wxS3LQ_003D_003D(this);
			int[] connection = father.Connection;
			for (int i = 0; i < 3; i++)
			{
				Centroid.Unknowns[mode][i] = 0.0;
				for (int j = 0; j < connection.Length; j++)
				{
					Centroid.Unknowns[mode][i] += array[j] * ((Node)vertices[connection[j]]).Unknowns[mode][i];
				}
			}
		}

		internal void _0023_003DzFPVyG4Y9TGyH(Vector3D _0023_003DzYNjcavt9guh2, int _0023_003DzAPBIJmvn5i5Q, int[] _0023_003DzfYMyE9c_003D, Material _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D, FemMesh _0023_003Dzkx0ud14_003D)
		{
			switch (Indices.Length)
			{
			case 3:
				new Tria3(_0023_003DzfYMyE9c_003D, _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D).Extrude(_0023_003DzYNjcavt9guh2, _0023_003DzAPBIJmvn5i5Q, _0023_003Dzkx0ud14_003D);
				break;
			case 4:
				new Quad4(_0023_003DzfYMyE9c_003D, _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D).Extrude(_0023_003DzYNjcavt9guh2, _0023_003DzAPBIJmvn5i5Q, _0023_003Dzkx0ud14_003D);
				break;
			case 6:
				new Tria6(_0023_003DzfYMyE9c_003D, _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D).Extrude(_0023_003DzYNjcavt9guh2, _0023_003DzAPBIJmvn5i5Q, _0023_003Dzkx0ud14_003D);
				break;
			case 8:
				new Quad8(_0023_003DzfYMyE9c_003D, _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D).Extrude(_0023_003DzYNjcavt9guh2, _0023_003DzAPBIJmvn5i5Q, _0023_003Dzkx0ud14_003D);
				break;
			default:
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985024));
			}
		}

		internal void _0023_003DzZsKpvYbXHCDE(double _0023_003Dz6pajdGM_003D, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, int _0023_003DzAPBIJmvn5i5Q, int[] _0023_003DzfYMyE9c_003D, Material _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D, FemMesh _0023_003Dzkx0ud14_003D)
		{
			switch (Indices.Length)
			{
			case 3:
				new Tria3(_0023_003DzfYMyE9c_003D, _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D).Revolve(_0023_003Dz6pajdGM_003D, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003Dzkx0ud14_003D);
				break;
			case 4:
				new Quad4(_0023_003DzfYMyE9c_003D, _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D).Revolve(_0023_003Dz6pajdGM_003D, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003Dzkx0ud14_003D);
				break;
			case 6:
				new Tria6(_0023_003DzfYMyE9c_003D, _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D).Revolve(_0023_003Dz6pajdGM_003D, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003Dzkx0ud14_003D);
				break;
			case 8:
				new Quad8(_0023_003DzfYMyE9c_003D, _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D).Revolve(_0023_003Dz6pajdGM_003D, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003Dzkx0ud14_003D);
				break;
			default:
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985024));
			}
		}

		private int[] _0023_003DzDahzpBEspCmc(FemMesh _0023_003Dzkx0ud14_003D, out Material _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D)
		{
			int[] array = new int[0];
			_0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D = new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984991));
			SmoothTriangle smoothTriangle = Triangles[0];
			bool flag = false;
			Element[] elements = _0023_003Dzkx0ud14_003D.Elements;
			for (int i = 0; i < elements.Length; i++)
			{
				Element3D element3D = (Element3D)elements[i];
				Face[] faces = element3D.Faces;
				foreach (Face face in faces)
				{
					if (face.Triangles != null && face.Triangles[0] == smoothTriangle)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					array = element3D.Connection;
					_0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D = element3D.Material;
					break;
				}
			}
			int[] array2 = new int[Indices.Length];
			for (int k = 0; k < Indices.Length; k++)
			{
				array2[k] = array[Indices[k]];
			}
			return array2;
		}
	}

	public readonly int NumberOfNodes;

	internal int NumberOfDofPerNode;

	protected int NumberOfGaussPoints;

	protected int NumberOfDimensions;

	protected int NumberOfStressesPerNode;

	internal double[] load;

	internal double[] tLoad;

	internal double[] distLoad;

	internal double[,] strin;

	public int[] Connection;

	protected double[,] K;

	protected double[,] B;

	protected double[,,] StressMatrix;

	protected Material mat;

	protected double[,] M;

	internal int minConn;

	internal int maxConn;

	protected internal Face[] elFaces;

	public int TotalDof => NumberOfDofPerNode * NumberOfNodes;

	public float[] PlotValues { get; }

	public double[,] Stress { get; set; }

	public double[,] Principals { get; set; }

	public double[] VonMises { get; set; }

	public Material Material
	{
		get
		{
			return mat;
		}
		set
		{
			mat = value;
		}
	}

	public double[,] StiffnessMatrix => K;

	public double[,] MassMatrix => M;

	public Face[] Faces => elFaces;

	protected internal Element(int numberOfNodes, Material material)
	{
		mat = material;
		NumberOfNodes = numberOfNodes;
		Stress = new double[NumberOfNodes, 6];
		VonMises = new double[NumberOfNodes];
		Principals = new double[NumberOfNodes, 3];
	}

	protected Element(Element another)
	{
		Connection = (int[])another.Connection.Clone();
		mat = another.mat;
		NumberOfNodes = another.NumberOfNodes;
		NumberOfDimensions = another.NumberOfDimensions;
		NumberOfDofPerNode = another.NumberOfDofPerNode;
		NumberOfGaussPoints = another.NumberOfGaussPoints;
		NumberOfStressesPerNode = another.NumberOfStressesPerNode;
		Stress = new double[NumberOfNodes, 6];
		VonMises = new double[NumberOfNodes];
		Principals = new double[NumberOfNodes, 3];
		elFaces = new Face[another.elFaces.Length];
		for (int i = 0; i < elFaces.Length; i++)
		{
			elFaces[i] = (Face)another.elFaces[i].Clone();
		}
		if (another.distLoad != null)
		{
			distLoad = new double[another.distLoad.Length];
			another.distLoad.CopyTo(distLoad, 0);
		}
	}

	internal void _0023_003Dzalwkb_JPNQSOXZDh4A_003D_003D(float[] _0023_003DzPzO_0024GUk_003D)
	{
		PlotValues = _0023_003DzPzO_0024GUk_003D;
	}

	public abstract object Clone();

	public abstract FemElementSurrogate ConvertToSurrogate();

	internal void _0023_003Dzxlnq6Q__3EAt()
	{
		K = null;
	}

	internal void _0023_003Dzj_0024GuASrCwPN4()
	{
		M = null;
	}

	public virtual void CalcStiffness(Point3D[] nodes, int elemIndex)
	{
	}

	public virtual void CalcMass(Point3D[] nodes, int elemIndex, bool lumpMass = false)
	{
	}

	public virtual void CalcStress(Point3D[] nodes, int elemIndex, int[] numberOfElementsPerNode, bool temperature)
	{
	}

	public static void CalcPrincipal(double[] stress, out double vm, out double[] principal)
	{
		CalcPrincipal(stress[0], stress[1], stress[2], stress[3], stress[4], stress[5], out vm, out principal);
	}

	public static void CalcPrincipal(double Sx, double Sy, double Sz, double Txy, double Tyz, double Txz, out double vm, out double[] principal)
	{
		vm = 0.0;
		principal = new double[3];
		double num = Math.Abs(Sx) + Math.Abs(Sy) + Math.Abs(Sz) + Math.Abs(Txy) + Math.Abs(Tyz) + Math.Abs(Txz);
		if (num < 1E-12)
		{
			return;
		}
		double num2 = Txy * Txy;
		double num3 = Tyz * Tyz;
		double num4 = Txz * Txz;
		vm = Math.Sqrt(((Sx - Sy) * (Sx - Sy) + (Sy - Sz) * (Sy - Sz) + (Sz - Sx) * (Sz - Sx)) / 2.0 + 3.0 * (num2 + num3 + num4));
		double num5 = 0.0 - Sx - Sy - Sz;
		double num6 = Sx * Sy + Sy * Sz + Sx * Sz - num2 - num3 - num4;
		double num7 = 0.0 - Sx * Sy * Sz - 2.0 * Txy * Tyz * Txz + Sx * num3 + Sy * num4 + Sz * num2;
		double num8 = Math.Abs(num5) / 3.0;
		while (true)
		{
			double num9 = num8 * num8;
			double num10 = num9 * num8 + num5 * num9 + num6 * num8 + num7;
			double num11 = num9 * 3.0 + num5 * num8 * 2.0 + num6;
			if (Math.Abs(num11) < 1E-12)
			{
				principal[0] = Sx;
				principal[1] = Sy;
				principal[2] = Sz;
				break;
			}
			double num12 = num8 - num10 / num11;
			double num13 = 0.0;
			if (Math.Abs(num12) / num > 1E-06)
			{
				num13 = Math.Abs((num12 - num8) / num12);
			}
			num8 = num12;
			if (!(num13 > 1E-06))
			{
				principal[0] = num8;
				double num14 = 0.0 - num5 - principal[0];
				double num15 = num14 * num14 - (num6 - principal[0] * num14) * 4.0;
				num15 = ((!(num15 >= 0.0)) ? 0.0 : Math.Sqrt(num15));
				principal[1] = (num14 + num15) / 2.0;
				principal[2] = (num14 - num15) / 2.0;
				break;
			}
		}
		int num16;
		do
		{
			num16 = 0;
			for (int i = 2; i <= 3; i++)
			{
				if ((principal[1] - principal[0]) / num > 1E-06)
				{
					num16++;
					num5 = principal[1];
					principal[1] = principal[0];
					principal[0] = num5;
				}
				if ((principal[2] - principal[1]) / num > 1E-06)
				{
					num16++;
					num5 = principal[2];
					principal[2] = principal[1];
					principal[1] = num5;
				}
			}
		}
		while (num16 > 0);
	}

	protected void AssembleMassMatrix(double[] shapeFunc, double dVolume)
	{
		for (int i = 0; i < TotalDof; i++)
		{
			for (int j = 0; j < TotalDof; j++)
			{
				if (i % NumberOfDofPerNode == j % NumberOfDofPerNode)
				{
					M[i, j] += mat.Density * shapeFunc[i / NumberOfDofPerNode] * shapeFunc[j / NumberOfDofPerNode] * dVolume;
				}
			}
		}
	}

	protected void GaussQuadrature(out double[] gpPosition, out double[] gpWeight)
	{
		gpPosition = null;
		gpWeight = null;
		if (NumberOfGaussPoints != 1)
		{
			if (NumberOfNodes == 6 && NumberOfDimensions == 2)
			{
				gpPosition = new double[2] { 0.0, 0.5 };
				gpWeight = new double[3] { 0.333333333333333, 0.333333333333333, 0.333333333333333 };
			}
			if (NumberOfNodes == 6 && NumberOfDimensions == 3)
			{
				gpPosition = new double[2] { -0.577350269189626, 0.577350269189626 };
				gpWeight = new double[2] { 1.0, 1.0 };
			}
			if (NumberOfNodes == 8 || NumberOfNodes == 4 || NumberOfNodes == 20 || NumberOfNodes == 15)
			{
				gpPosition = new double[2] { -0.577350269189626, 0.577350269189626 };
				gpWeight = new double[2] { 1.0, 1.0 };
			}
		}
	}

	internal void _0023_003DzkK3Z3MIFFh9x(Point3D[] _0023_003DzDvuIQCU_003D)
	{
		for (int i = 0; i < NumberOfNodes; i++)
		{
			for (int j = 0; j < NumberOfNodes; j++)
			{
				int num = Connection[i];
				int num2 = Connection[j];
				devDept.Geometry.Rotation rotation = ((Node)_0023_003DzDvuIQCU_003D[num]).Rotation;
				devDept.Geometry.Rotation rotation2 = ((Node)_0023_003DzDvuIQCU_003D[num2]).Rotation;
				if (!(rotation != null) && !(rotation2 != null))
				{
					continue;
				}
				int num3 = i * NumberOfDimensions + 1;
				int num4 = j * NumberOfDimensions + 1;
				double[,] array = new double[NumberOfDimensions, NumberOfDimensions];
				for (int k = 1; k <= NumberOfDimensions; k++)
				{
					for (int l = 1; l <= NumberOfDimensions; l++)
					{
						array[l - 1, k - 1] = K[num4 + l - 2, num3 + k - 2];
					}
				}
				double[,] array2 = new double[NumberOfDimensions, NumberOfDimensions];
				if (rotation != null)
				{
					for (int m = 1; m <= NumberOfDimensions; m++)
					{
						for (int n = 1; n <= NumberOfDimensions; n++)
						{
							array2[n - 1, m - 1] = rotation.Matrix[m - 1, n - 1];
						}
					}
				}
				else
				{
					for (int num5 = 1; num5 <= NumberOfDimensions; num5++)
					{
						for (int num6 = 1; num6 <= NumberOfDimensions; num6++)
						{
							if (num5 == num6)
							{
								array2[num6 - 1, num5 - 1] = 1.0;
							}
							else
							{
								array2[num6 - 1, num5 - 1] = 0.0;
							}
						}
					}
				}
				double[,] array3 = new double[NumberOfDimensions, NumberOfDimensions];
				if (rotation2 != null)
				{
					for (int num7 = 1; num7 <= NumberOfDimensions; num7++)
					{
						for (int num8 = 1; num8 <= NumberOfDimensions; num8++)
						{
							array3[num8 - 1, num7 - 1] = rotation2.Matrix[num8 - 1, num7 - 1];
						}
					}
				}
				else
				{
					for (int num9 = 1; num9 <= NumberOfDimensions; num9++)
					{
						for (int num10 = 1; num10 <= NumberOfDimensions; num10++)
						{
							if (num9 == num10)
							{
								array3[num10 - 1, num9 - 1] = 1.0;
							}
							else
							{
								array3[num10 - 1, num9 - 1] = 0.0;
							}
						}
					}
				}
				double[,] b = Matrix.Multiply(array, array2);
				double[,] array4 = Matrix.Multiply(array3, b);
				for (int num11 = 1; num11 <= NumberOfDimensions; num11++)
				{
					for (int num12 = 1; num12 <= NumberOfDimensions; num12++)
					{
						K[num4 + num12 - 2, num3 + num11 - 2] = array4[num12 - 1, num11 - 1];
					}
				}
			}
		}
	}

	internal void _0023_003Dze2Sxb_0024_0024WiJg5(Point3D[] _0023_003DzDvuIQCU_003D)
	{
		for (int i = 0; i < NumberOfNodes; i++)
		{
			for (int j = 0; j < NumberOfNodes; j++)
			{
				int num = Connection[i];
				int num2 = Connection[j];
				devDept.Geometry.Rotation rotation = ((Node)_0023_003DzDvuIQCU_003D[num]).Rotation;
				devDept.Geometry.Rotation rotation2 = ((Node)_0023_003DzDvuIQCU_003D[num2]).Rotation;
				if (!(rotation != null) && !(rotation2 != null))
				{
					continue;
				}
				int num3 = i * NumberOfDimensions + 1;
				int num4 = j * NumberOfDimensions + 1;
				double[,] array = new double[NumberOfDimensions, NumberOfDimensions];
				for (int k = 1; k <= NumberOfDimensions; k++)
				{
					for (int l = 1; l <= NumberOfDimensions; l++)
					{
						array[l - 1, k - 1] = K[num4 + l - 2, num3 + k - 2];
					}
				}
				double[,] array2 = new double[NumberOfDimensions, NumberOfDimensions];
				if (rotation != null)
				{
					for (int m = 1; m <= NumberOfDimensions; m++)
					{
						for (int n = 1; n <= NumberOfDimensions; n++)
						{
							array2[n - 1, m - 1] = rotation.Matrix[m - 1, n - 1];
						}
					}
				}
				else
				{
					for (int num5 = 1; num5 <= NumberOfDimensions; num5++)
					{
						for (int num6 = 1; num6 <= NumberOfDimensions; num6++)
						{
							if (num5 == num6)
							{
								array2[num6 - 1, num5 - 1] = 1.0;
							}
							else
							{
								array2[num6 - 1, num5 - 1] = 0.0;
							}
						}
					}
				}
				double[,] array3 = new double[NumberOfDimensions, NumberOfDimensions];
				if (rotation2 != null)
				{
					for (int num7 = 1; num7 <= NumberOfDimensions; num7++)
					{
						for (int num8 = 1; num8 <= NumberOfDimensions; num8++)
						{
							array3[num8 - 1, num7 - 1] = rotation2.Matrix[num8 - 1, num7 - 1];
						}
					}
				}
				else
				{
					for (int num9 = 1; num9 <= NumberOfDimensions; num9++)
					{
						for (int num10 = 1; num10 <= NumberOfDimensions; num10++)
						{
							if (num9 == num10)
							{
								array3[num10 - 1, num9 - 1] = 1.0;
							}
							else
							{
								array3[num10 - 1, num9 - 1] = 0.0;
							}
						}
					}
				}
				double[,] b = Matrix.Multiply(array, array2);
				double[,] array4 = Matrix.Multiply(array3, b);
				for (int num11 = 1; num11 <= NumberOfDimensions; num11++)
				{
					for (int num12 = 1; num12 <= NumberOfDimensions; num12++)
					{
						M[num4 + num12 - 2, num3 + num11 - 2] = array4[num12 - 1, num11 - 1];
					}
				}
			}
		}
	}

	internal static void _0023_003Dz3PdJaxsL3lyc(double[,] _0023_003DzjbqS1qE_003D, double[,] _0023_003Dz1v6oPQk_003D, double[,] _0023_003Dzt_m8zV0_003D, int _0023_003DzE26udrs_003D, int _0023_003Dzq3Tmtbs_003D, int _0023_003DzsfkYBuc_003D)
	{
		for (int i = 0; i < _0023_003DzE26udrs_003D; i++)
		{
			for (int j = 0; j < _0023_003Dzq3Tmtbs_003D; j++)
			{
				_0023_003DzjbqS1qE_003D[j, i] = 0.0;
				for (int k = 0; k < _0023_003DzsfkYBuc_003D; k++)
				{
					_0023_003DzjbqS1qE_003D[j, i] += _0023_003Dz1v6oPQk_003D[k, i] * _0023_003Dzt_m8zV0_003D[j, k];
				}
			}
		}
	}

	public void UpdateVonMisesAndPrincipals()
	{
		for (int i = 0; i < NumberOfNodes; i++)
		{
			CalcPrincipal(Stress[i, 0], Stress[i, 1], Stress[i, 2], Stress[i, 3], Stress[i, 4], Stress[i, 5], out var vm, out var principal);
			VonMises[i] = vm;
			Principals[i, 0] = principal[0];
			Principals[i, 1] = principal[1];
			Principals[i, 2] = principal[2];
		}
	}

	public virtual void DrawWithSharpColor(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
	}

	public virtual void DrawWithSharpColorElement(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
	}

	internal double[,] _0023_003DzwTQF9gqyciKw(double[,] _0023_003DzjLs4DXs_003D, double[,] _0023_003Dz_MgHWJs_003D)
	{
		double[,] array = new double[TotalDof, NumberOfStressesPerNode];
		for (int i = 0; i < NumberOfStressesPerNode; i++)
		{
			for (int j = 0; j < TotalDof; j++)
			{
				for (int k = 0; k < NumberOfStressesPerNode; k++)
				{
					if (_0023_003DzjLs4DXs_003D[k, i] != 0.0)
					{
						array[j, i] += _0023_003DzjLs4DXs_003D[k, i] * _0023_003Dz_MgHWJs_003D[j, k];
					}
				}
			}
		}
		return array;
	}

	protected void StiffnessComputation(Point3D[] nodes)
	{
		for (int i = 0; i < TotalDof; i++)
		{
			for (int j = 0; j < TotalDof; j++)
			{
				K[i, j] = K[j, i];
			}
		}
		_0023_003DzkK3Z3MIFFh9x(nodes);
		minConn = int.MaxValue;
		maxConn = int.MinValue;
		int[] connection = Connection;
		foreach (int num in connection)
		{
			if (num < minConn)
			{
				minConn = num;
			}
			if (num > maxConn)
			{
				maxConn = num;
			}
		}
	}

	public virtual void Draw(RenderContextBase context, Vector3D singleNormal, Color singleColor, Point3D[] vertices, double ampFactor, int mode)
	{
	}

	public virtual void Draw(RenderContextBase context, Vector3D singleNormal, Point3D[] vertices, double ampFactor, int mode)
	{
	}

	protected double[] ComputeCartesianStressAtSamplingPoint(int kgasp, Point3D[] nodes)
	{
		double[] array = new double[NumberOfStressesPerNode];
		for (int i = 0; i < NumberOfStressesPerNode; i++)
		{
			int num = 0;
			for (int j = 0; j < NumberOfNodes; j++)
			{
				for (int k = 0; k < NumberOfDofPerNode; k++)
				{
					num++;
					array[i] += StressMatrix[kgasp - 1, num - 1, i] * ((Node)nodes[Connection[j]]).Unknowns[0][k];
				}
			}
		}
		return array;
	}

	public override string ToString()
	{
		string text = Connection[0] + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908108);
		for (int i = 1; i < Connection.Length; i++)
		{
			text = text + Connection[i] + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908108);
		}
		return text;
	}

	public virtual void CalcTemp(int elemIndex, Point3D[] nodes)
	{
	}

	public static double WeightedAverage(double v1, double v2, double v3, double v4, double v5, double v6, double v7, double v8)
	{
		return (v2 + v4 + v6 + v8) / 2.0 - (v1 + v3 + v5 + v7) / 4.0;
	}

	public static double WeightedAverage(double v1, double v2, double v3, double v4, double v5, double v6)
	{
		return (v2 + v4 + v6) / 3.0;
	}

	internal void _0023_003DzKX9_h2E_003D(int _0023_003Dz8iljnAs_003D, int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D, int _0023_003DzZe6oCrQ_003D, Mesh _0023_003DzGGJSiQk_003D)
	{
		_0023_003DzGGJSiQk_003D.Triangles[_0023_003Dz8iljnAs_003D] = new IndexTriangle(_0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, _0023_003DzZe6oCrQ_003D);
	}

	private void _0023_003DzPq45nGk_003D(int _0023_003DzKAXXKpk_003D, int _0023_003Dz8iljnAs_003D, int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D, int _0023_003DzZe6oCrQ_003D, IndexTriangle[] _0023_003DzceNyInx9KKsG)
	{
		_0023_003DzceNyInx9KKsG[_0023_003Dz8iljnAs_003D] = new _0023_003DzdbCY_Ol_2RiGerZYwGcKL3V5U09dFmFFez1WZYE_003D(_0023_003DzKAXXKpk_003D, _0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, _0023_003DzZe6oCrQ_003D);
	}

	internal void _0023_003Dzo5ycBd9ENqPa()
	{
		load = new double[TotalDof];
	}

	internal void _0023_003DzTKtlMWgFyHz_()
	{
		for (int i = 0; i < TotalDof; i++)
		{
			load[i] += tLoad[i];
		}
	}

	internal void _0023_003DzAcG3NerU8u4d()
	{
		for (int i = 0; i < TotalDof; i++)
		{
			load[i] += distLoad[i];
		}
	}

	public virtual IndexTriangle[] GetTriangles(int elIndex, Point3D[] vertices, double ampFactor, List<Point3D> centroids)
	{
		return new IndexTriangle[0];
	}

	internal void _0023_003DzOm2z22ujB4a_0024(RenderContextBase _0023_003DzB8iS0QA_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, int _0023_003DzAPBIJmvn5i5Q, double _0023_003DzXGmnJb5mDXOU, double _0023_003Dzy6Km22i8t1UG, int _0023_003DznXXM9vk_003D)
	{
		_0023_003DzOm2z22ujB4a_0024(_0023_003DzB8iS0QA_003D, Color.Empty, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003DzXGmnJb5mDXOU, _0023_003Dzy6Km22i8t1UG, _0023_003Dzh2DzJAQ_003D: false, _0023_003DznXXM9vk_003D);
	}

	internal void _0023_003DzOm2z22ujB4a_0024(RenderContextBase _0023_003DzB8iS0QA_003D, Color _0023_003DzNMsIQ2k_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, int _0023_003DzAPBIJmvn5i5Q, double _0023_003DzXGmnJb5mDXOU, double _0023_003DzVef8g8WObZjg, int _0023_003DznXXM9vk_003D)
	{
		_0023_003DzOm2z22ujB4a_0024(_0023_003DzB8iS0QA_003D, _0023_003DzNMsIQ2k_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003DzXGmnJb5mDXOU, _0023_003DzVef8g8WObZjg, _0023_003Dzh2DzJAQ_003D: true, _0023_003DznXXM9vk_003D);
	}

	private void _0023_003DzOm2z22ujB4a_0024(RenderContextBase _0023_003DzB8iS0QA_003D, Color _0023_003DzNMsIQ2k_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, int _0023_003DzAPBIJmvn5i5Q, double _0023_003DzXGmnJb5mDXOU, double _0023_003Dzy6Km22i8t1UG, bool _0023_003Dzh2DzJAQ_003D, int _0023_003DznXXM9vk_003D)
	{
		Node _0023_003DzRnnx5m0_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[0]];
		Node _0023_003DzjMJr9AU_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[1]];
		_0023_003Dz9ObkOhBxTfoTbEjzT2M9vWSfnW696ze25w_003D_003D(_0023_003DzRnnx5m0_003D, _0023_003DzjMJr9AU_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003DzXGmnJb5mDXOU, _0023_003Dzy6Km22i8t1UG, _0023_003DznXXM9vk_003D, out var _0023_003DzEGKj_0024SNUUihi, out var _0023_003DzAqOpw0w_003D, out var _0023_003Dzk64JNOo_003D, out var _0023_003Dzz_0024GCZofvnh1q);
		Point3D[] array = new Point3D[6];
		Vector3D[] array2 = new Vector3D[6];
		Color[] colors = null;
		if (_0023_003Dzh2DzJAQ_003D)
		{
			colors = new Color[6] { _0023_003DzNMsIQ2k_003D, _0023_003DzNMsIQ2k_003D, _0023_003DzNMsIQ2k_003D, _0023_003DzNMsIQ2k_003D, _0023_003DzNMsIQ2k_003D, _0023_003DzNMsIQ2k_003D };
		}
		for (int i = 0; i < _0023_003DzAPBIJmvn5i5Q; i++)
		{
			Utility.GetSliceVerticesAndNormals(i, _0023_003DzEGKj_0024SNUUihi, _0023_003DzAPBIJmvn5i5Q, _0023_003DzAqOpw0w_003D, _0023_003Dzk64JNOo_003D, _0023_003Dzz_0024GCZofvnh1q, out var v, out var v2, out var v3, out var v4, out var n, out var n2, out var n3, out var n4);
			array[0] = v;
			array[1] = v2;
			array[2] = v4;
			array[3] = v;
			array[4] = v4;
			array[5] = v3;
			array2[0] = n;
			array2[1] = n2;
			array2[2] = n4;
			array2[3] = n;
			array2[4] = n4;
			array2[5] = n3;
			if (_0023_003Dzh2DzJAQ_003D)
			{
				_0023_003DzB8iS0QA_003D.DrawTrianglesPartial(array, array2, colors);
			}
			else
			{
				_0023_003DzB8iS0QA_003D.DrawTrianglesPartial(array, array2);
			}
		}
	}

	internal void _0023_003DzOm2z22ujB4a_0024(RenderContextBase _0023_003DzB8iS0QA_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, int _0023_003DzAPBIJmvn5i5Q, double _0023_003DzF7v9r2A_003D, double _0023_003Dz8dK2uhU_003D, double _0023_003DzXGmnJb5mDXOU, double _0023_003Dzy6Km22i8t1UG, int _0023_003DznXXM9vk_003D)
	{
		Node node = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[0]];
		Node node2 = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[1]];
		_0023_003Dze2Qf1ZNLbnEK(_0023_003DzB8iS0QA_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D, _0023_003DzXGmnJb5mDXOU, _0023_003Dzy6Km22i8t1UG, node, node2, node.PlotValue, node2.PlotValue, _0023_003DznXXM9vk_003D);
	}

	internal void _0023_003DzrhR_0024jny4mWKP(RenderContextBase _0023_003DzB8iS0QA_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, int _0023_003DzAPBIJmvn5i5Q, double _0023_003DzF7v9r2A_003D, double _0023_003Dz8dK2uhU_003D, double _0023_003DzXGmnJb5mDXOU, double _0023_003Dzy6Km22i8t1UG, int _0023_003DznXXM9vk_003D)
	{
		Node _0023_003DzRnnx5m0_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[0]];
		Node _0023_003DzjMJr9AU_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[1]];
		_0023_003Dze2Qf1ZNLbnEK(_0023_003DzB8iS0QA_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D, _0023_003DzXGmnJb5mDXOU, _0023_003Dzy6Km22i8t1UG, _0023_003DzRnnx5m0_003D, _0023_003DzjMJr9AU_003D, PlotValues[0], PlotValues[1], _0023_003DznXXM9vk_003D);
	}

	private void _0023_003Dze2Qf1ZNLbnEK(RenderContextBase _0023_003DzB8iS0QA_003D, int _0023_003DzAPBIJmvn5i5Q, double _0023_003DzF7v9r2A_003D, double _0023_003Dz8dK2uhU_003D, double _0023_003DzXGmnJb5mDXOU, double _0023_003Dzy6Km22i8t1UG, Node _0023_003DzRnnx5m0_003D, Node _0023_003DzjMJr9AU_003D, double _0023_003Dz913vHewJ7P27, double _0023_003DztPuwZLkeqRvc, int _0023_003DznXXM9vk_003D)
	{
		_0023_003Dz9ObkOhBxTfoTbEjzT2M9vWSfnW696ze25w_003D_003D(_0023_003DzRnnx5m0_003D, _0023_003DzjMJr9AU_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003DzXGmnJb5mDXOU, _0023_003Dzy6Km22i8t1UG, _0023_003DznXXM9vk_003D, out var _0023_003DzEGKj_0024SNUUihi, out var _0023_003DzAqOpw0w_003D, out var _0023_003Dzk64JNOo_003D, out var _0023_003Dzz_0024GCZofvnh1q);
		Point3D[] array = new Point3D[6];
		Vector3D[] array2 = new Vector3D[6];
		float[] array3 = new float[6];
		for (int i = 0; i < _0023_003DzAPBIJmvn5i5Q; i++)
		{
			Utility.GetSliceVerticesAndNormals(i, _0023_003DzEGKj_0024SNUUihi, _0023_003DzAPBIJmvn5i5Q, _0023_003DzAqOpw0w_003D, _0023_003Dzk64JNOo_003D, _0023_003Dzz_0024GCZofvnh1q, out var v, out var v2, out var v3, out var v4, out var n, out var n2, out var n3, out var n4);
			array[0] = v;
			array[1] = v2;
			array[2] = v4;
			array[3] = v;
			array[4] = v4;
			array[5] = v3;
			array2[0] = n;
			array2[1] = n2;
			array2[2] = n4;
			array2[3] = n;
			array2[4] = n4;
			array2[5] = n3;
			array3[0] = Utility._0023_003DzbV1eOjg_003D(_0023_003DztPuwZLkeqRvc, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
			array3[1] = Utility._0023_003DzbV1eOjg_003D(_0023_003Dz913vHewJ7P27, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
			array3[2] = array3[1];
			array3[3] = array3[0];
			array3[4] = array3[1];
			array3[5] = array3[0];
			_0023_003DzB8iS0QA_003D.DrawTrianglesPartial(array, array2, array3);
		}
	}

	internal void _0023_003Dz0BRyXETPH2CY(RenderContextBase _0023_003DzB8iS0QA_003D, Vector3D _0023_003DzZpdQVNE_003D, Point3D _0023_003DzO2ha6ckJVFiD, double _0023_003DzELnUZQyM6IsC, Vector3D _0023_003DzLz7mDrk_003D, Transformation _0023_003DzLS0sR0pzioXc, double _0023_003DzF7v9r2A_003D, double _0023_003Dz8dK2uhU_003D, double _0023_003DzSAVnUgopotmE, double _0023_003Dz913vHewJ7P27, bool _0023_003DzpXqcGaz7sKJt, Color[] _0023_003DzSTzI4Tk_003D, bool _0023_003DzAI3jPBBmCGmn, bool _0023_003DzXiGznWxb_0eQ, Point3D[] _0023_003Dzp__k9THECpRbraKuYg_003D_003D, bool _0023_003Dzz1fGUs2oBc0E, int _0023_003DznXXM9vk_003D)
	{
		List<Point3D> list = new List<Point3D>();
		List<Vector3D> list2 = new List<Vector3D>();
		List<Color> list3 = null;
		List<float> list4 = null;
		Color diffuse = mat.Diffuse;
		if (_0023_003Dzz1fGUs2oBc0E)
		{
			if (!_0023_003DzpXqcGaz7sKJt)
			{
				_0023_003DzB8iS0QA_003D.SetColorWireframe(diffuse);
				list3 = new List<Color>();
			}
			else if (_0023_003DzSTzI4Tk_003D != null)
			{
				list3 = new List<Color>();
			}
			else
			{
				list4 = new List<float>();
			}
		}
		((MaterialBeam)mat).DrawBeam(_0023_003DzB8iS0QA_003D, _0023_003Dzp__k9THECpRbraKuYg_003D_003D, _0023_003DzO2ha6ckJVFiD, _0023_003DzZpdQVNE_003D, _0023_003DzELnUZQyM6IsC, _0023_003DzLz7mDrk_003D, _0023_003DzLS0sR0pzioXc, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D, _0023_003DzSAVnUgopotmE, _0023_003Dz913vHewJ7P27, _0023_003DzpXqcGaz7sKJt, _0023_003DzSTzI4Tk_003D, _0023_003DzAI3jPBBmCGmn, _0023_003DzXiGznWxb_0eQ, list, list2, list3, list4, _0023_003Dzz1fGUs2oBc0E);
		if (!_0023_003Dzz1fGUs2oBc0E)
		{
			_0023_003DzB8iS0QA_003D.DrawTrianglesPartial(list.ToArray(), list2.ToArray());
		}
		else if (_0023_003DzpXqcGaz7sKJt)
		{
			_0023_003DzB8iS0QA_003D.DrawTrianglesPartial(list.ToArray(), list2.ToArray(), list4.ToArray());
		}
		else
		{
			_0023_003DzB8iS0QA_003D.DrawTrianglesPartial(list.ToArray(), list2.ToArray(), list3.ToArray());
		}
	}

	internal void _0023_003DzunNCduq2e6bD2pZW0evxPv0_003D(RenderContextBase _0023_003DzB8iS0QA_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, double _0023_003DzXGmnJb5mDXOU, int _0023_003DznXXM9vk_003D)
	{
		_0023_003Dz2Rmn6Q7FKu93ZtOrp_00247cHG4tddLj(_0023_003DzB8iS0QA_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, 0.0, 0.0, _0023_003DzXGmnJb5mDXOU, null, _0023_003Dzz1fGUs2oBc0E: false, _0023_003DznXXM9vk_003D);
	}

	internal void _0023_003Dzfl9GWk_0024bAGr6_0024mhmcThGjZf4swUh(RenderContextBase _0023_003DzB8iS0QA_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, double _0023_003DzF7v9r2A_003D, double _0023_003Dz8dK2uhU_003D, double _0023_003DzXGmnJb5mDXOU, Color[] _0023_003DzSTzI4Tk_003D, int _0023_003DznXXM9vk_003D)
	{
		_0023_003Dz2Rmn6Q7FKu93ZtOrp_00247cHG4tddLj(_0023_003DzB8iS0QA_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D, _0023_003DzXGmnJb5mDXOU, _0023_003DzSTzI4Tk_003D, _0023_003Dzz1fGUs2oBc0E: true, _0023_003DznXXM9vk_003D);
	}

	internal void _0023_003Dz2Rmn6Q7FKu93ZtOrp_00247cHG4tddLj(RenderContextBase _0023_003DzB8iS0QA_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, double _0023_003DzF7v9r2A_003D, double _0023_003Dz8dK2uhU_003D, double _0023_003DzXGmnJb5mDXOU, Color[] _0023_003DzSTzI4Tk_003D, bool _0023_003Dzz1fGUs2oBc0E, int _0023_003DznXXM9vk_003D)
	{
		Node _0023_003DzRnnx5m0_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[0]];
		double _0023_003DzELnUZQyM6IsC;
		Vector3D _0023_003Dz_eY3Y4c_003D;
		Vector3D _0023_003DzAvn2b38_003D;
		Vector3D _0023_003Dz77g161c_003D;
		Point3D[] beamVerts;
		if (this is Beam)
		{
			Beam obj = (Beam)this;
			obj._0023_003Dz_Pv10jaRctc_0024nexujUC_0024laXwGnjU(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out _0023_003DzELnUZQyM6IsC, out var _, out _0023_003Dz_eY3Y4c_003D, out _0023_003DzAvn2b38_003D);
			_0023_003Dz77g161c_003D = obj.v;
			beamVerts = obj.beamVerts;
		}
		else
		{
			Beam2D obj2 = (Beam2D)this;
			obj2._0023_003Dz9N71tA5ZWS90YBI87g_003D_003D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out _0023_003Dz_eY3Y4c_003D, out _0023_003Dz77g161c_003D, out _0023_003DzAvn2b38_003D, out _0023_003DzELnUZQyM6IsC);
			beamVerts = obj2.beamVerts;
		}
		int num = PlotValues.Length;
		double _0023_003DzxigXYm0EiNwh = _0023_003DzELnUZQyM6IsC / (double)(num - 1);
		for (int i = 0; i < PlotValues.Length - 1; i++)
		{
			Point3D _0023_003DzO2ha6ckJVFiD;
			Vector3D _0023_003DzLz7mDrk_003D;
			Vector3D _0023_003DzZpdQVNE_003D;
			double _0023_003Dz6gJpTukVm_0024VY;
			Transformation _0023_003DzLS0sR0pzioXc = _0023_003DzuX5n6nch_gLr(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzXGmnJb5mDXOU, _0023_003DznXXM9vk_003D, _0023_003Dz_eY3Y4c_003D, _0023_003DzAvn2b38_003D, _0023_003DzxigXYm0EiNwh, i, _0023_003DzRnnx5m0_003D, _0023_003Dz77g161c_003D, out _0023_003DzO2ha6ckJVFiD, out _0023_003DzLz7mDrk_003D, out _0023_003DzZpdQVNE_003D, out _0023_003Dz6gJpTukVm_0024VY);
			if (i == 0)
			{
				if (i == num - 2)
				{
					_0023_003Dz0BRyXETPH2CY(_0023_003DzB8iS0QA_003D, _0023_003DzZpdQVNE_003D, _0023_003DzO2ha6ckJVFiD, _0023_003Dz6gJpTukVm_0024VY, _0023_003DzLz7mDrk_003D, _0023_003DzLS0sR0pzioXc, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D, PlotValues[i], PlotValues[i + 1], _0023_003DzpXqcGaz7sKJt: true, _0023_003DzSTzI4Tk_003D, _0023_003DzAI3jPBBmCGmn: true, _0023_003DzXiGznWxb_0eQ: true, beamVerts, _0023_003Dzz1fGUs2oBc0E, _0023_003DznXXM9vk_003D);
				}
				else
				{
					_0023_003Dz0BRyXETPH2CY(_0023_003DzB8iS0QA_003D, _0023_003DzZpdQVNE_003D, _0023_003DzO2ha6ckJVFiD, _0023_003Dz6gJpTukVm_0024VY, _0023_003DzLz7mDrk_003D, _0023_003DzLS0sR0pzioXc, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D, PlotValues[i], PlotValues[i + 1], _0023_003DzpXqcGaz7sKJt: true, _0023_003DzSTzI4Tk_003D, _0023_003DzAI3jPBBmCGmn: true, _0023_003DzXiGznWxb_0eQ: false, beamVerts, _0023_003Dzz1fGUs2oBc0E, _0023_003DznXXM9vk_003D);
				}
			}
			else if (i == num - 2)
			{
				_0023_003Dz0BRyXETPH2CY(_0023_003DzB8iS0QA_003D, _0023_003DzZpdQVNE_003D, _0023_003DzO2ha6ckJVFiD, _0023_003Dz6gJpTukVm_0024VY, _0023_003DzLz7mDrk_003D, _0023_003DzLS0sR0pzioXc, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D, PlotValues[i], PlotValues[i + 1], _0023_003DzpXqcGaz7sKJt: true, _0023_003DzSTzI4Tk_003D, _0023_003DzAI3jPBBmCGmn: false, _0023_003DzXiGznWxb_0eQ: true, beamVerts, _0023_003Dzz1fGUs2oBc0E, _0023_003DznXXM9vk_003D);
			}
			else
			{
				_0023_003Dz0BRyXETPH2CY(_0023_003DzB8iS0QA_003D, _0023_003DzZpdQVNE_003D, _0023_003DzO2ha6ckJVFiD, _0023_003Dz6gJpTukVm_0024VY, _0023_003DzLz7mDrk_003D, _0023_003DzLS0sR0pzioXc, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D, PlotValues[i], PlotValues[i + 1], _0023_003DzpXqcGaz7sKJt: true, _0023_003DzSTzI4Tk_003D, _0023_003DzAI3jPBBmCGmn: false, _0023_003DzXiGznWxb_0eQ: false, beamVerts, _0023_003Dzz1fGUs2oBc0E, _0023_003DznXXM9vk_003D);
			}
		}
	}

	private Transformation _0023_003DzuX5n6nch_gLr(Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, double _0023_003DzXGmnJb5mDXOU, int _0023_003DznXXM9vk_003D, Vector3D _0023_003Dz_eY3Y4c_003D, Vector3D _0023_003DzAvn2b38_003D, double _0023_003DzxigXYm0EiNwh, int _0023_003Dz437_00244ak_003D, Node _0023_003DzRnnx5m0_003D, Vector3D _0023_003Dz77g161c_003D, out Point3D _0023_003DzO2ha6ckJVFiD, out Vector3D _0023_003DzLz7mDrk_003D, out Vector3D _0023_003DzZpdQVNE_003D, out double _0023_003Dz6gJpTukVm_0024VY)
	{
		Point3D _0023_003DzjdeMMkk_003D;
		if (this is Beam)
		{
			((Beam)this)._0023_003DzoWW7VaZ6bbGLCHQ_0024W_abLcU_003D(_0023_003DzXGmnJb5mDXOU, _0023_003DznXXM9vk_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003Dz_eY3Y4c_003D, _0023_003DzAvn2b38_003D, _0023_003DzxigXYm0EiNwh, _0023_003Dz437_00244ak_003D, out _0023_003DzO2ha6ckJVFiD, out _0023_003DzjdeMMkk_003D, out _0023_003DzLz7mDrk_003D, out _0023_003DzZpdQVNE_003D, out _0023_003Dz6gJpTukVm_0024VY);
		}
		else
		{
			((Beam2D)this)._0023_003DzoWW7VaZ6bbGLCHQ_0024W_abLcU_003D(_0023_003DzXGmnJb5mDXOU, _0023_003DznXXM9vk_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003Dz_eY3Y4c_003D, _0023_003Dz77g161c_003D, _0023_003DzxigXYm0EiNwh, _0023_003Dz437_00244ak_003D, out _0023_003DzO2ha6ckJVFiD, out _0023_003DzjdeMMkk_003D, out _0023_003DzLz7mDrk_003D, out _0023_003DzZpdQVNE_003D, out _0023_003Dz6gJpTukVm_0024VY);
		}
		return new Align3D(new Plane(_0023_003DzRnnx5m0_003D, _0023_003Dz_eY3Y4c_003D, _0023_003DzAvn2b38_003D), new Plane(_0023_003DzO2ha6ckJVFiD, _0023_003DzLz7mDrk_003D, _0023_003DzZpdQVNE_003D));
	}

	internal void _0023_003DzKfIdo2NWu204LV9ttQ_003D_003D(RenderContextBase _0023_003DzB8iS0QA_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, double _0023_003DzXGmnJb5mDXOU, int _0023_003DznXXM9vk_003D)
	{
		Node _0023_003DzRnnx5m0_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[0]];
		double _0023_003DzELnUZQyM6IsC;
		Vector3D _0023_003Dz_eY3Y4c_003D;
		Vector3D _0023_003DzAvn2b38_003D;
		Vector3D _0023_003Dz77g161c_003D;
		int subdivisionNumber;
		if (this is Beam)
		{
			Beam obj = (Beam)this;
			obj._0023_003Dz_Pv10jaRctc_0024nexujUC_0024laXwGnjU(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out _0023_003DzELnUZQyM6IsC, out var _, out _0023_003Dz_eY3Y4c_003D, out _0023_003DzAvn2b38_003D);
			_0023_003Dz77g161c_003D = obj.v;
			subdivisionNumber = obj.SubdivisionNumber;
		}
		else
		{
			Beam2D obj2 = (Beam2D)this;
			obj2._0023_003Dz9N71tA5ZWS90YBI87g_003D_003D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out _0023_003Dz_eY3Y4c_003D, out _0023_003Dz77g161c_003D, out _0023_003DzAvn2b38_003D, out _0023_003DzELnUZQyM6IsC);
			subdivisionNumber = obj2.SubdivisionNumber;
		}
		double _0023_003DzxigXYm0EiNwh = _0023_003DzELnUZQyM6IsC / (double)(subdivisionNumber - 1);
		for (int i = 0; i < subdivisionNumber - 1; i++)
		{
			Point3D _0023_003DzO2ha6ckJVFiD;
			Vector3D _0023_003DzLz7mDrk_003D;
			Vector3D _0023_003DzZpdQVNE_003D;
			double _0023_003Dz6gJpTukVm_0024VY;
			Transformation _0023_003DzLS0sR0pzioXc = _0023_003DzuX5n6nch_gLr(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzXGmnJb5mDXOU, _0023_003DznXXM9vk_003D, _0023_003Dz_eY3Y4c_003D, _0023_003DzAvn2b38_003D, _0023_003DzxigXYm0EiNwh, i, _0023_003DzRnnx5m0_003D, _0023_003Dz77g161c_003D, out _0023_003DzO2ha6ckJVFiD, out _0023_003DzLz7mDrk_003D, out _0023_003DzZpdQVNE_003D, out _0023_003Dz6gJpTukVm_0024VY);
			if (mat is MaterialBeamCircle)
			{
				_0023_003DztzizP0WCYsUH(_0023_003DzB8iS0QA_003D, i, _0023_003DzLS0sR0pzioXc, _0023_003Dz6gJpTukVm_0024VY, _0023_003DzLz7mDrk_003D, _0023_003DzPIUPq2vaEJdN: false, _0023_003DzL3KiMLzit8Kc: false);
			}
			else if (mat is MaterialBeamHollowCircle)
			{
				_0023_003DztzizP0WCYsUH(_0023_003DzB8iS0QA_003D, i, _0023_003DzLS0sR0pzioXc, _0023_003Dz6gJpTukVm_0024VY, _0023_003DzLz7mDrk_003D, _0023_003DzPIUPq2vaEJdN: false, _0023_003DzL3KiMLzit8Kc: true);
			}
			else if (mat is MaterialBeamHollowRect)
			{
				_0023_003DztzizP0WCYsUH(_0023_003DzB8iS0QA_003D, i, _0023_003DzLS0sR0pzioXc, _0023_003Dz6gJpTukVm_0024VY, _0023_003DzLz7mDrk_003D, _0023_003DzPIUPq2vaEJdN: true, _0023_003DzL3KiMLzit8Kc: true);
			}
			else
			{
				_0023_003DztzizP0WCYsUH(_0023_003DzB8iS0QA_003D, i, _0023_003DzLS0sR0pzioXc, _0023_003Dz6gJpTukVm_0024VY, _0023_003DzLz7mDrk_003D, _0023_003DzPIUPq2vaEJdN: true, _0023_003DzL3KiMLzit8Kc: false);
			}
		}
	}

	private void _0023_003DztzizP0WCYsUH(RenderContextBase _0023_003DzB8iS0QA_003D, int _0023_003Dz437_00244ak_003D, Transformation _0023_003DzLS0sR0pzioXc, double _0023_003DzyLbNOOltkddq, Vector3D _0023_003DzLz7mDrk_003D, bool _0023_003DzPIUPq2vaEJdN, bool _0023_003DzL3KiMLzit8Kc)
	{
		int num = ((this is Beam2D) ? ((Beam2D)this).SubdivisionNumber : ((Beam)this).SubdivisionNumber);
		if (_0023_003Dz437_00244ak_003D == 0)
		{
			if (_0023_003Dz437_00244ak_003D == num - 2)
			{
				_0023_003DzwNpJQPn9NtkE(_0023_003DzB8iS0QA_003D, _0023_003DzLS0sR0pzioXc, _0023_003DzyLbNOOltkddq, _0023_003DzLz7mDrk_003D, _0023_003DzJAhbomM_003D: true, _0023_003DzgcrelA4_003D: true, _0023_003DzPIUPq2vaEJdN, _0023_003DzL3KiMLzit8Kc);
			}
			else
			{
				_0023_003DzwNpJQPn9NtkE(_0023_003DzB8iS0QA_003D, _0023_003DzLS0sR0pzioXc, _0023_003DzyLbNOOltkddq, _0023_003DzLz7mDrk_003D, _0023_003DzJAhbomM_003D: true, _0023_003DzgcrelA4_003D: false, _0023_003DzPIUPq2vaEJdN, _0023_003DzL3KiMLzit8Kc);
			}
		}
		else if (_0023_003Dz437_00244ak_003D == num - 2)
		{
			_0023_003DzwNpJQPn9NtkE(_0023_003DzB8iS0QA_003D, _0023_003DzLS0sR0pzioXc, _0023_003DzyLbNOOltkddq, _0023_003DzLz7mDrk_003D, _0023_003DzJAhbomM_003D: false, _0023_003DzgcrelA4_003D: true, _0023_003DzPIUPq2vaEJdN, _0023_003DzL3KiMLzit8Kc);
		}
		else
		{
			_0023_003DzwNpJQPn9NtkE(_0023_003DzB8iS0QA_003D, _0023_003DzLS0sR0pzioXc, _0023_003DzyLbNOOltkddq, _0023_003DzLz7mDrk_003D, _0023_003DzJAhbomM_003D: false, _0023_003DzgcrelA4_003D: false, _0023_003DzPIUPq2vaEJdN, _0023_003DzL3KiMLzit8Kc);
		}
	}

	private void _0023_003DzwNpJQPn9NtkE(RenderContextBase _0023_003DzB8iS0QA_003D, Transformation _0023_003DzLS0sR0pzioXc, double _0023_003DzyLbNOOltkddq, Vector3D _0023_003DzLz7mDrk_003D, bool _0023_003DzJAhbomM_003D, bool _0023_003DzgcrelA4_003D, bool _0023_003DzPIUPq2vaEJdN, bool _0023_003DzL3KiMLzit8Kc)
	{
		Point3D[] array = ((!(this is Beam2D)) ? ((Beam)this).beamVerts : ((Beam2D)this).beamVerts);
		int num = (_0023_003DzPIUPq2vaEJdN ? array.Length : ((!_0023_003DzL3KiMLzit8Kc) ? (array.Length - 1) : (array.Length - 2)));
		Point3D[] array2 = new Point3D[num];
		Point3D[] array3 = new Point3D[num];
		Point3D[] array4 = null;
		Point3D[] array5 = null;
		if (_0023_003DzL3KiMLzit8Kc)
		{
			num /= 2;
			array4 = new Point3D[num];
			array5 = new Point3D[num];
		}
		for (int i = 0; i < num; i++)
		{
			array2[i] = (Point3D)array[i].Clone();
			if (_0023_003DzLS0sR0pzioXc != null)
			{
				array2[i].TransformBy(_0023_003DzLS0sR0pzioXc);
			}
			array3[i] = array2[i] + _0023_003DzyLbNOOltkddq * _0023_003DzLz7mDrk_003D;
			if (_0023_003DzL3KiMLzit8Kc)
			{
				if (_0023_003DzPIUPq2vaEJdN)
				{
					array4[i] = (Point3D)array[i + num].Clone();
				}
				else
				{
					array4[i] = (Point3D)array[i + num + 1].Clone();
				}
				if (_0023_003DzLS0sR0pzioXc != null)
				{
					array4[i].TransformBy(_0023_003DzLS0sR0pzioXc);
				}
				array5[i] = array4[i] + _0023_003DzyLbNOOltkddq * _0023_003DzLz7mDrk_003D;
			}
		}
		if (_0023_003DzJAhbomM_003D)
		{
			_0023_003DzB8iS0QA_003D.DrawLineLoop(array2, 0, num);
			if (_0023_003DzL3KiMLzit8Kc)
			{
				_0023_003DzB8iS0QA_003D.DrawLineLoop(array4, 0, num);
			}
		}
		if (_0023_003DzgcrelA4_003D)
		{
			_0023_003DzB8iS0QA_003D.DrawLineLoop(array3, 0, num);
			if (_0023_003DzL3KiMLzit8Kc)
			{
				_0023_003DzB8iS0QA_003D.DrawLineLoop(array5, 0, num);
			}
		}
		if (!_0023_003DzPIUPq2vaEJdN)
		{
			return;
		}
		for (int j = 0; j < num; j++)
		{
			_0023_003DzB8iS0QA_003D.DrawLine(array2[j], array3[j]);
			if (_0023_003DzL3KiMLzit8Kc)
			{
				_0023_003DzB8iS0QA_003D.DrawLine(array4[j], array5[j]);
			}
		}
	}

	internal void _0023_003DzkneD3LGNB66GilGpDvl14cU_003D(RenderContextBase _0023_003DzB8iS0QA_003D, Node _0023_003DzRnnx5m0_003D, Node _0023_003DzjMJr9AU_003D)
	{
		Vector3D vector3D = new Vector3D(_0023_003DzRnnx5m0_003D, _0023_003DzjMJr9AU_003D);
		double length = vector3D.Length;
		vector3D.Normalize();
		if (mat is MaterialBeamCircle)
		{
			_0023_003DzwNpJQPn9NtkE(_0023_003DzB8iS0QA_003D, null, length, vector3D, _0023_003DzJAhbomM_003D: true, _0023_003DzgcrelA4_003D: true, _0023_003DzPIUPq2vaEJdN: false, _0023_003DzL3KiMLzit8Kc: false);
		}
		else if (mat is MaterialBeamHollowCircle)
		{
			_0023_003DzwNpJQPn9NtkE(_0023_003DzB8iS0QA_003D, null, length, vector3D, _0023_003DzJAhbomM_003D: true, _0023_003DzgcrelA4_003D: true, _0023_003DzPIUPq2vaEJdN: false, _0023_003DzL3KiMLzit8Kc: true);
		}
		else if (mat is MaterialBeamHollowRect)
		{
			_0023_003DzwNpJQPn9NtkE(_0023_003DzB8iS0QA_003D, null, length, vector3D, _0023_003DzJAhbomM_003D: true, _0023_003DzgcrelA4_003D: true, _0023_003DzPIUPq2vaEJdN: true, _0023_003DzL3KiMLzit8Kc: true);
		}
		else
		{
			_0023_003DzwNpJQPn9NtkE(_0023_003DzB8iS0QA_003D, null, length, vector3D, _0023_003DzJAhbomM_003D: true, _0023_003DzgcrelA4_003D: true, _0023_003DzPIUPq2vaEJdN: true, _0023_003DzL3KiMLzit8Kc: false);
		}
	}

	protected void DrawFace3(RenderContextBase context, Color singleColor, int index, Point3D[] vertices, double ampFactor, int mode)
	{
		_0023_003Dz7VV3mDNWz3_0024q(index, vertices, out var _0023_003Dz0wAkCmM_003D, out var _0023_003Dz_0024eRdUwQ_003D, out var _0023_003Dz5cbO6Ls_003D, out var _0023_003DzRnnx5m0_003D, out var _0023_003DzjMJr9AU_003D, out var _0023_003DzW_0024ubBfM_003D);
		_0023_003DzxjHGIv6i1T9l(context, singleColor, _0023_003Dz0wAkCmM_003D, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz5cbO6Ls_003D, _0023_003DzRnnx5m0_003D, _0023_003DzjMJr9AU_003D, _0023_003DzW_0024ubBfM_003D, ampFactor, mode);
	}

	protected void DrawFace3(RenderContextBase context, int index, Point3D[] vertices, double ampFactor, int mode)
	{
		_0023_003Dz7VV3mDNWz3_0024q(index, vertices, out var _0023_003Dz0wAkCmM_003D, out var _0023_003Dz_0024eRdUwQ_003D, out var _0023_003Dz5cbO6Ls_003D, out var _0023_003DzRnnx5m0_003D, out var _0023_003DzjMJr9AU_003D, out var _0023_003DzW_0024ubBfM_003D);
		_0023_003DzxjHGIv6i1T9l(context, _0023_003Dz0wAkCmM_003D, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz5cbO6Ls_003D, _0023_003DzRnnx5m0_003D, _0023_003DzjMJr9AU_003D, _0023_003DzW_0024ubBfM_003D, ampFactor, mode);
	}

	private void _0023_003Dz7VV3mDNWz3_0024q(int _0023_003DzyzK8swU_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out Node _0023_003Dz0wAkCmM_003D, out Node _0023_003Dz_0024eRdUwQ_003D, out Node _0023_003Dz5cbO6Ls_003D, out Vector3D _0023_003DzRnnx5m0_003D, out Vector3D _0023_003DzjMJr9AU_003D, out Vector3D _0023_003DzW_0024ubBfM_003D)
	{
		Face face = elFaces[_0023_003DzyzK8swU_003D];
		byte[] indices = face.Indices;
		Vector3D[] cornerNormals = face.CornerNormals;
		_0023_003Dz0wAkCmM_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[indices[0]]];
		_0023_003Dz_0024eRdUwQ_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[indices[1]]];
		_0023_003Dz5cbO6Ls_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[indices[2]]];
		_0023_003DzRnnx5m0_003D = cornerNormals[0];
		_0023_003DzjMJr9AU_003D = cornerNormals[1];
		_0023_003DzW_0024ubBfM_003D = cornerNormals[2];
	}

	private void _0023_003DzxjHGIv6i1T9l(RenderContextBase _0023_003DzB8iS0QA_003D, Color _0023_003DzNMsIQ2k_003D, Node _0023_003Dz0wAkCmM_003D, Node _0023_003Dz_0024eRdUwQ_003D, Node _0023_003Dz5cbO6Ls_003D, Vector3D _0023_003DzRnnx5m0_003D, Vector3D _0023_003DzjMJr9AU_003D, Vector3D _0023_003DzW_0024ubBfM_003D, double _0023_003DzXGmnJb5mDXOU, int _0023_003DznXXM9vk_003D)
	{
		_0023_003DzB8iS0QA_003D.DrawTrianglesWithDisplacement(new PointWithDisplacement[3] { _0023_003Dz0wAkCmM_003D, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz5cbO6Ls_003D }, new Vector3D[3] { _0023_003DzRnnx5m0_003D, _0023_003DzjMJr9AU_003D, _0023_003DzW_0024ubBfM_003D }, _0023_003DzNMsIQ2k_003D, _0023_003DzXGmnJb5mDXOU, _0023_003DznXXM9vk_003D, addToCurrentBufferPart: true);
	}

	private void _0023_003DzxjHGIv6i1T9l(RenderContextBase _0023_003DzB8iS0QA_003D, Node _0023_003Dz0wAkCmM_003D, Node _0023_003Dz_0024eRdUwQ_003D, Node _0023_003Dz5cbO6Ls_003D, Vector3D _0023_003DzRnnx5m0_003D, Vector3D _0023_003DzjMJr9AU_003D, Vector3D _0023_003DzW_0024ubBfM_003D, double _0023_003DzXGmnJb5mDXOU, int _0023_003DznXXM9vk_003D)
	{
		_0023_003DzB8iS0QA_003D.DrawTrianglesWithDisplacement(new PointWithDisplacement[3] { _0023_003Dz0wAkCmM_003D, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz5cbO6Ls_003D }, new Vector3D[3] { _0023_003DzRnnx5m0_003D, _0023_003DzjMJr9AU_003D, _0023_003DzW_0024ubBfM_003D }, _0023_003DzXGmnJb5mDXOU, _0023_003DznXXM9vk_003D, addToCurrentBufferPart: true);
	}

	protected void DrawFace3(RenderContextBase context, int index, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		Face face = elFaces[index];
		byte[] indices = face.Indices;
		Vector3D[] cornerNormals = face.CornerNormals;
		Node node = (Node)vertices[Connection[indices[0]]];
		Node node2 = (Node)vertices[Connection[indices[1]]];
		Node node3 = (Node)vertices[Connection[indices[2]]];
		PointWithDisplacement[] vertices2 = new PointWithDisplacement[3] { node, node2, node3 };
		float[] tex1DCoords = new float[3]
		{
			Utility._0023_003DzbV1eOjg_003D(node.PlotValue, min, max),
			Utility._0023_003DzbV1eOjg_003D(node2.PlotValue, min, max),
			Utility._0023_003DzbV1eOjg_003D(node3.PlotValue, min, max)
		};
		context.DrawTrianglesWithDisplacement(vertices2, cornerNormals, tex1DCoords, ampFactor, mode, addToCurrentBufferPart: true);
	}

	protected void DrawFaceElement3(RenderContextBase context, int index, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		Face face = elFaces[index];
		byte[] indices = face.Indices;
		Vector3D[] cornerNormals = face.CornerNormals;
		int num = indices[0];
		int num2 = indices[1];
		int num3 = indices[2];
		Node _0023_003Dz0wAkCmM_003D = (Node)vertices[Connection[num]];
		Node _0023_003Dz_0024eRdUwQ_003D = (Node)vertices[Connection[num2]];
		Node _0023_003Dz5cbO6Ls_003D = (Node)vertices[Connection[num3]];
		Vector3D _0023_003DzRnnx5m0_003D = cornerNormals[0];
		Vector3D _0023_003DzjMJr9AU_003D = cornerNormals[1];
		Vector3D _0023_003DzW_0024ubBfM_003D = cornerNormals[2];
		_0023_003DzOtt2oBpNBc1J(context, PlotValues[num], PlotValues[num2], PlotValues[num3], _0023_003Dz0wAkCmM_003D, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz5cbO6Ls_003D, _0023_003DzRnnx5m0_003D, _0023_003DzjMJr9AU_003D, _0023_003DzW_0024ubBfM_003D, min, max, ampFactor, mode);
	}

	protected IndexTriangle[] GetFace3(int elIndex, int index, Point3D[] vertices, double ampFactor, List<Point3D> centroids)
	{
		byte[] indices = elFaces[index].Indices;
		IndexTriangle[] array = new IndexTriangle[1];
		_0023_003DzPq45nGk_003D(elIndex, 0, Connection[indices[0]], Connection[indices[1]], Connection[indices[2]], array);
		return array;
	}

	private static void _0023_003DzQhddrIGPdy0i(RenderContextBase _0023_003DzB8iS0QA_003D, Node _0023_003Dz0wAkCmM_003D, Node _0023_003Dz_0024eRdUwQ_003D, Node _0023_003Dz5cbO6Ls_003D, Vector3D _0023_003DzRnnx5m0_003D, Vector3D _0023_003DzjMJr9AU_003D, Vector3D _0023_003DzW_0024ubBfM_003D, double _0023_003DzF7v9r2A_003D, double _0023_003Dz8dK2uhU_003D, double _0023_003DzXGmnJb5mDXOU, int _0023_003DznXXM9vk_003D)
	{
		_0023_003DzB8iS0QA_003D.DrawTrianglesWithDisplacement(new PointWithDisplacement[3] { _0023_003Dz0wAkCmM_003D, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz5cbO6Ls_003D }, new Vector3D[3] { _0023_003DzRnnx5m0_003D, _0023_003DzjMJr9AU_003D, _0023_003DzW_0024ubBfM_003D }, new float[3]
		{
			Utility._0023_003DzbV1eOjg_003D(_0023_003Dz0wAkCmM_003D.PlotValue, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D),
			Utility._0023_003DzbV1eOjg_003D(_0023_003Dz_0024eRdUwQ_003D.PlotValue, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D),
			Utility._0023_003DzbV1eOjg_003D(_0023_003Dz5cbO6Ls_003D.PlotValue, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D)
		}, _0023_003DzXGmnJb5mDXOU, _0023_003DznXXM9vk_003D, addToCurrentBufferPart: true);
	}

	private static void _0023_003DzOtt2oBpNBc1J(RenderContextBase _0023_003DzB8iS0QA_003D, double _0023_003DzffqPLNQ_003D, double _0023_003Dz5Azd7L8_003D, double _0023_003DzZe6oCrQ_003D, Node _0023_003Dz0wAkCmM_003D, Node _0023_003Dz_0024eRdUwQ_003D, Node _0023_003Dz5cbO6Ls_003D, Vector3D _0023_003DzRnnx5m0_003D, Vector3D _0023_003DzjMJr9AU_003D, Vector3D _0023_003DzW_0024ubBfM_003D, double _0023_003DzF7v9r2A_003D, double _0023_003Dz8dK2uhU_003D, double _0023_003DzXGmnJb5mDXOU, int _0023_003DznXXM9vk_003D)
	{
		_0023_003DzB8iS0QA_003D.DrawTrianglesWithDisplacement(new PointWithDisplacement[3] { _0023_003Dz0wAkCmM_003D, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz5cbO6Ls_003D }, new Vector3D[3] { _0023_003DzRnnx5m0_003D, _0023_003DzjMJr9AU_003D, _0023_003DzW_0024ubBfM_003D }, new float[3]
		{
			Utility._0023_003DzbV1eOjg_003D(_0023_003DzffqPLNQ_003D, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D),
			Utility._0023_003DzbV1eOjg_003D(_0023_003Dz5Azd7L8_003D, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D),
			Utility._0023_003DzbV1eOjg_003D(_0023_003DzZe6oCrQ_003D, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D)
		}, _0023_003DzXGmnJb5mDXOU, _0023_003DznXXM9vk_003D, addToCurrentBufferPart: true);
	}

	private Face _0023_003DzveUvnTiqBOAl(int _0023_003DzyzK8swU_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out Node _0023_003Dz0wAkCmM_003D, out Node _0023_003Dz_0024eRdUwQ_003D, out Node _0023_003Dz5cbO6Ls_003D, out Node _0023_003Dz4BKUbLs_003D, out Node _0023_003DzoumYP2o_003D, out Node _0023_003Dz_FV_0024jMs_003D, out Vector3D _0023_003DzRnnx5m0_003D, out Vector3D _0023_003DzW_0024ubBfM_003D, out Vector3D _0023_003DzQyTjV9Q_003D, out Vector3D _0023_003DzjMJr9AU_003D, out Vector3D _0023_003DzVhH_NPo_003D, out Vector3D _0023_003Dz3x90_C4_003D)
	{
		Face face = elFaces[_0023_003DzyzK8swU_003D];
		byte[] indices = face.Indices;
		Vector3D[] cornerNormals = face.CornerNormals;
		_0023_003Dz0wAkCmM_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[indices[0]]];
		_0023_003Dz_0024eRdUwQ_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[indices[1]]];
		_0023_003Dz5cbO6Ls_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[indices[2]]];
		_0023_003Dz4BKUbLs_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[indices[3]]];
		_0023_003DzoumYP2o_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[indices[4]]];
		_0023_003Dz_FV_0024jMs_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[indices[5]]];
		_0023_003DzRnnx5m0_003D = cornerNormals[0];
		_0023_003DzW_0024ubBfM_003D = cornerNormals[1];
		_0023_003DzQyTjV9Q_003D = cornerNormals[2];
		_0023_003DzjMJr9AU_003D = _0023_003DzRnnx5m0_003D + _0023_003DzW_0024ubBfM_003D;
		_0023_003DzjMJr9AU_003D.Normalize();
		_0023_003DzVhH_NPo_003D = _0023_003DzW_0024ubBfM_003D + _0023_003DzQyTjV9Q_003D;
		_0023_003DzVhH_NPo_003D.Normalize();
		_0023_003Dz3x90_C4_003D = _0023_003DzQyTjV9Q_003D + _0023_003DzRnnx5m0_003D;
		_0023_003Dz3x90_C4_003D.Normalize();
		return face;
	}

	protected void DrawFace6(RenderContextBase context, Color singleColor, int index, Point3D[] vertices, double ampFactor, int mode)
	{
		_0023_003DzveUvnTiqBOAl(index, vertices, out var _0023_003Dz0wAkCmM_003D, out var _0023_003Dz_0024eRdUwQ_003D, out var _0023_003Dz5cbO6Ls_003D, out var _0023_003Dz4BKUbLs_003D, out var _0023_003DzoumYP2o_003D, out var _0023_003Dz_FV_0024jMs_003D, out var _0023_003DzRnnx5m0_003D, out var _0023_003DzW_0024ubBfM_003D, out var _0023_003DzQyTjV9Q_003D, out var _0023_003DzjMJr9AU_003D, out var _0023_003DzVhH_NPo_003D, out var _0023_003Dz3x90_C4_003D);
		_0023_003DzxjHGIv6i1T9l(context, singleColor, _0023_003Dz0wAkCmM_003D, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz_FV_0024jMs_003D, _0023_003DzRnnx5m0_003D, _0023_003DzjMJr9AU_003D, _0023_003Dz3x90_C4_003D, ampFactor, mode);
		_0023_003DzxjHGIv6i1T9l(context, singleColor, _0023_003Dz4BKUbLs_003D, _0023_003DzoumYP2o_003D, _0023_003Dz_FV_0024jMs_003D, _0023_003DzVhH_NPo_003D, _0023_003DzQyTjV9Q_003D, _0023_003Dz3x90_C4_003D, ampFactor, mode);
		_0023_003DzxjHGIv6i1T9l(context, singleColor, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz5cbO6Ls_003D, _0023_003Dz4BKUbLs_003D, _0023_003DzjMJr9AU_003D, _0023_003DzW_0024ubBfM_003D, _0023_003DzVhH_NPo_003D, ampFactor, mode);
		_0023_003DzxjHGIv6i1T9l(context, singleColor, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz4BKUbLs_003D, _0023_003Dz_FV_0024jMs_003D, _0023_003DzjMJr9AU_003D, _0023_003DzVhH_NPo_003D, _0023_003Dz3x90_C4_003D, ampFactor, mode);
	}

	protected void DrawFace6(RenderContextBase context, int index, Point3D[] vertices, double ampFactor, int mode)
	{
		_0023_003DzveUvnTiqBOAl(index, vertices, out var _0023_003Dz0wAkCmM_003D, out var _0023_003Dz_0024eRdUwQ_003D, out var _0023_003Dz5cbO6Ls_003D, out var _0023_003Dz4BKUbLs_003D, out var _0023_003DzoumYP2o_003D, out var _0023_003Dz_FV_0024jMs_003D, out var _0023_003DzRnnx5m0_003D, out var _0023_003DzW_0024ubBfM_003D, out var _0023_003DzQyTjV9Q_003D, out var _0023_003DzjMJr9AU_003D, out var _0023_003DzVhH_NPo_003D, out var _0023_003Dz3x90_C4_003D);
		_0023_003DzxjHGIv6i1T9l(context, _0023_003Dz0wAkCmM_003D, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz_FV_0024jMs_003D, _0023_003DzRnnx5m0_003D, _0023_003DzjMJr9AU_003D, _0023_003Dz3x90_C4_003D, ampFactor, mode);
		_0023_003DzxjHGIv6i1T9l(context, _0023_003Dz4BKUbLs_003D, _0023_003DzoumYP2o_003D, _0023_003Dz_FV_0024jMs_003D, _0023_003DzVhH_NPo_003D, _0023_003DzQyTjV9Q_003D, _0023_003Dz3x90_C4_003D, ampFactor, mode);
		_0023_003DzxjHGIv6i1T9l(context, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz5cbO6Ls_003D, _0023_003Dz4BKUbLs_003D, _0023_003DzjMJr9AU_003D, _0023_003DzW_0024ubBfM_003D, _0023_003DzVhH_NPo_003D, ampFactor, mode);
		_0023_003DzxjHGIv6i1T9l(context, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz4BKUbLs_003D, _0023_003Dz_FV_0024jMs_003D, _0023_003DzjMJr9AU_003D, _0023_003DzVhH_NPo_003D, _0023_003Dz3x90_C4_003D, ampFactor, mode);
	}

	protected void DrawFace6(RenderContextBase context, int index, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		_0023_003DzveUvnTiqBOAl(index, vertices, out var _0023_003Dz0wAkCmM_003D, out var _0023_003Dz_0024eRdUwQ_003D, out var _0023_003Dz5cbO6Ls_003D, out var _0023_003Dz4BKUbLs_003D, out var _0023_003DzoumYP2o_003D, out var _0023_003Dz_FV_0024jMs_003D, out var _0023_003DzRnnx5m0_003D, out var _0023_003DzW_0024ubBfM_003D, out var _0023_003DzQyTjV9Q_003D, out var _0023_003DzjMJr9AU_003D, out var _0023_003DzVhH_NPo_003D, out var _0023_003Dz3x90_C4_003D);
		_0023_003DzQhddrIGPdy0i(context, _0023_003Dz0wAkCmM_003D, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz_FV_0024jMs_003D, _0023_003DzRnnx5m0_003D, _0023_003DzjMJr9AU_003D, _0023_003Dz3x90_C4_003D, min, max, ampFactor, mode);
		_0023_003DzQhddrIGPdy0i(context, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz5cbO6Ls_003D, _0023_003Dz4BKUbLs_003D, _0023_003DzjMJr9AU_003D, _0023_003DzW_0024ubBfM_003D, _0023_003DzVhH_NPo_003D, min, max, ampFactor, mode);
		_0023_003DzQhddrIGPdy0i(context, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz4BKUbLs_003D, _0023_003Dz_FV_0024jMs_003D, _0023_003DzjMJr9AU_003D, _0023_003DzVhH_NPo_003D, _0023_003Dz3x90_C4_003D, min, max, ampFactor, mode);
		_0023_003DzQhddrIGPdy0i(context, _0023_003Dz4BKUbLs_003D, _0023_003DzoumYP2o_003D, _0023_003Dz_FV_0024jMs_003D, _0023_003DzVhH_NPo_003D, _0023_003DzQyTjV9Q_003D, _0023_003Dz3x90_C4_003D, min, max, ampFactor, mode);
	}

	protected void DrawFaceElement6(RenderContextBase context, int index, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		Face face = elFaces[index];
		byte[] indices = face.Indices;
		Vector3D[] cornerNormals = face.CornerNormals;
		int num = indices[0];
		int num2 = indices[1];
		int num3 = indices[2];
		int num4 = indices[3];
		int num5 = indices[4];
		int num6 = indices[5];
		Node _0023_003Dz0wAkCmM_003D = (Node)vertices[Connection[num]];
		Node node = (Node)vertices[Connection[num2]];
		Node _0023_003Dz_0024eRdUwQ_003D = (Node)vertices[Connection[num3]];
		Node node2 = (Node)vertices[Connection[num4]];
		Node _0023_003Dz_0024eRdUwQ_003D2 = (Node)vertices[Connection[num5]];
		Node _0023_003Dz5cbO6Ls_003D = (Node)vertices[Connection[num6]];
		Vector3D vector3D = cornerNormals[0];
		Vector3D vector3D2 = cornerNormals[1];
		Vector3D vector3D3 = cornerNormals[2];
		Vector3D vector3D4 = vector3D + vector3D2;
		vector3D4.Normalize();
		Vector3D vector3D5 = vector3D2 + vector3D3;
		vector3D5.Normalize();
		Vector3D vector3D6 = vector3D3 + vector3D;
		vector3D6.Normalize();
		_0023_003DzOtt2oBpNBc1J(context, PlotValues[num], PlotValues[num2], PlotValues[num6], _0023_003Dz0wAkCmM_003D, node, _0023_003Dz5cbO6Ls_003D, vector3D, vector3D4, vector3D6, min, max, ampFactor, mode);
		_0023_003DzOtt2oBpNBc1J(context, PlotValues[num2], PlotValues[num3], PlotValues[num4], node, _0023_003Dz_0024eRdUwQ_003D, node2, vector3D4, vector3D2, vector3D5, min, max, ampFactor, mode);
		_0023_003DzOtt2oBpNBc1J(context, PlotValues[num2], PlotValues[num4], PlotValues[num6], node, node2, _0023_003Dz5cbO6Ls_003D, vector3D4, vector3D5, vector3D6, min, max, ampFactor, mode);
		_0023_003DzOtt2oBpNBc1J(context, PlotValues[num4], PlotValues[num5], PlotValues[num6], node2, _0023_003Dz_0024eRdUwQ_003D2, _0023_003Dz5cbO6Ls_003D, vector3D5, vector3D3, vector3D6, min, max, ampFactor, mode);
	}

	private Node _0023_003DzI5YVhNKJY91d(int _0023_003DzyzK8swU_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out Node _0023_003Dz_0024eRdUwQ_003D, out Node _0023_003Dz5cbO6Ls_003D, out Node _0023_003Dz4BKUbLs_003D, out Vector3D _0023_003DzRnnx5m0_003D, out Vector3D _0023_003DzjMJr9AU_003D, out Vector3D _0023_003DzW_0024ubBfM_003D, out Vector3D _0023_003DzVhH_NPo_003D)
	{
		Face face = elFaces[_0023_003DzyzK8swU_003D];
		byte[] indices = face.Indices;
		Vector3D[] cornerNormals = face.CornerNormals;
		Node result = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[indices[0]]];
		_0023_003Dz_0024eRdUwQ_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[indices[1]]];
		_0023_003Dz5cbO6Ls_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[indices[2]]];
		_0023_003Dz4BKUbLs_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[indices[3]]];
		_0023_003DzRnnx5m0_003D = cornerNormals[0];
		_0023_003DzjMJr9AU_003D = cornerNormals[1];
		_0023_003DzW_0024ubBfM_003D = cornerNormals[2];
		_0023_003DzVhH_NPo_003D = cornerNormals[3];
		return result;
	}

	protected void DrawFace4(RenderContextBase context, Color singleColor, int index, Point3D[] vertices, double ampFactor, int mode)
	{
		Node _0023_003Dz_0024eRdUwQ_003D;
		Node _0023_003Dz5cbO6Ls_003D;
		Node _0023_003Dz4BKUbLs_003D;
		Vector3D _0023_003DzRnnx5m0_003D;
		Vector3D _0023_003DzjMJr9AU_003D;
		Vector3D _0023_003DzW_0024ubBfM_003D;
		Vector3D _0023_003DzVhH_NPo_003D;
		Node _0023_003Dz0wAkCmM_003D = _0023_003DzI5YVhNKJY91d(index, vertices, out _0023_003Dz_0024eRdUwQ_003D, out _0023_003Dz5cbO6Ls_003D, out _0023_003Dz4BKUbLs_003D, out _0023_003DzRnnx5m0_003D, out _0023_003DzjMJr9AU_003D, out _0023_003DzW_0024ubBfM_003D, out _0023_003DzVhH_NPo_003D);
		_0023_003DzxjHGIv6i1T9l(context, singleColor, _0023_003Dz0wAkCmM_003D, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz5cbO6Ls_003D, _0023_003DzRnnx5m0_003D, _0023_003DzjMJr9AU_003D, _0023_003DzW_0024ubBfM_003D, ampFactor, mode);
		_0023_003DzxjHGIv6i1T9l(context, singleColor, _0023_003Dz0wAkCmM_003D, _0023_003Dz5cbO6Ls_003D, _0023_003Dz4BKUbLs_003D, _0023_003DzRnnx5m0_003D, _0023_003DzW_0024ubBfM_003D, _0023_003DzVhH_NPo_003D, ampFactor, mode);
	}

	protected void DrawFace4(RenderContextBase context, int index, Point3D[] vertices, double ampFactor, int mode)
	{
		Node _0023_003Dz_0024eRdUwQ_003D;
		Node _0023_003Dz5cbO6Ls_003D;
		Node _0023_003Dz4BKUbLs_003D;
		Vector3D _0023_003DzRnnx5m0_003D;
		Vector3D _0023_003DzjMJr9AU_003D;
		Vector3D _0023_003DzW_0024ubBfM_003D;
		Vector3D _0023_003DzVhH_NPo_003D;
		Node _0023_003Dz0wAkCmM_003D = _0023_003DzI5YVhNKJY91d(index, vertices, out _0023_003Dz_0024eRdUwQ_003D, out _0023_003Dz5cbO6Ls_003D, out _0023_003Dz4BKUbLs_003D, out _0023_003DzRnnx5m0_003D, out _0023_003DzjMJr9AU_003D, out _0023_003DzW_0024ubBfM_003D, out _0023_003DzVhH_NPo_003D);
		_0023_003DzxjHGIv6i1T9l(context, _0023_003Dz0wAkCmM_003D, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz5cbO6Ls_003D, _0023_003DzRnnx5m0_003D, _0023_003DzjMJr9AU_003D, _0023_003DzW_0024ubBfM_003D, ampFactor, mode);
		_0023_003DzxjHGIv6i1T9l(context, _0023_003Dz0wAkCmM_003D, _0023_003Dz5cbO6Ls_003D, _0023_003Dz4BKUbLs_003D, _0023_003DzRnnx5m0_003D, _0023_003DzW_0024ubBfM_003D, _0023_003DzVhH_NPo_003D, ampFactor, mode);
	}

	protected void DrawFace4(RenderContextBase context, int index, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		Face face = elFaces[index];
		byte[] indices = face.Indices;
		Vector3D[] cornerNormals = face.CornerNormals;
		Node _0023_003Dz0wAkCmM_003D = (Node)vertices[Connection[indices[0]]];
		Node _0023_003Dz_0024eRdUwQ_003D = (Node)vertices[Connection[indices[1]]];
		Node _0023_003Dz5cbO6Ls_003D = (Node)vertices[Connection[indices[2]]];
		Node _0023_003Dz4BKUbLs_003D = (Node)vertices[Connection[indices[3]]];
		Vector3D _0023_003DzRnnx5m0_003D = cornerNormals[0];
		Vector3D _0023_003DzjMJr9AU_003D = cornerNormals[1];
		Vector3D _0023_003DzW_0024ubBfM_003D = cornerNormals[2];
		Vector3D _0023_003DzVhH_NPo_003D = cornerNormals[3];
		_0023_003DzXi20vtyDcANt(context, _0023_003Dz0wAkCmM_003D, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz5cbO6Ls_003D, _0023_003Dz4BKUbLs_003D, _0023_003DzRnnx5m0_003D, _0023_003DzjMJr9AU_003D, _0023_003DzW_0024ubBfM_003D, _0023_003DzVhH_NPo_003D, min, max, ampFactor, mode);
	}

	protected void DrawFaceElement4(RenderContextBase context, int index, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		Face face = elFaces[index];
		byte[] indices = face.Indices;
		Vector3D[] cornerNormals = face.CornerNormals;
		int num = indices[0];
		int num2 = indices[1];
		int num3 = indices[2];
		int num4 = indices[3];
		Node _0023_003Dz0wAkCmM_003D = (Node)vertices[Connection[num]];
		Node _0023_003Dz_0024eRdUwQ_003D = (Node)vertices[Connection[num2]];
		Node _0023_003Dz5cbO6Ls_003D = (Node)vertices[Connection[num3]];
		Node _0023_003Dz4BKUbLs_003D = (Node)vertices[Connection[num4]];
		Vector3D _0023_003DzRnnx5m0_003D = cornerNormals[0];
		Vector3D _0023_003DzjMJr9AU_003D = cornerNormals[1];
		Vector3D _0023_003DzW_0024ubBfM_003D = cornerNormals[2];
		Vector3D _0023_003DzVhH_NPo_003D = cornerNormals[3];
		_0023_003Dz6oihomIA6__4(context, PlotValues[num], PlotValues[num2], PlotValues[num3], PlotValues[num4], _0023_003Dz0wAkCmM_003D, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz5cbO6Ls_003D, _0023_003Dz4BKUbLs_003D, _0023_003DzRnnx5m0_003D, _0023_003DzjMJr9AU_003D, _0023_003DzW_0024ubBfM_003D, _0023_003DzVhH_NPo_003D, min, max, ampFactor, mode);
	}

	protected IndexTriangle[] GetFace4(int elIndex, int index, Point3D[] vertices, double ampFactor, List<Point3D> centroids)
	{
		byte[] indices = elFaces[index].Indices;
		IndexTriangle[] array = new IndexTriangle[2];
		_0023_003DzPq45nGk_003D(elIndex, 0, Connection[indices[0]], Connection[indices[1]], Connection[indices[2]], array);
		_0023_003DzPq45nGk_003D(elIndex, 1, Connection[indices[0]], Connection[indices[2]], Connection[indices[3]], array);
		return array;
	}

	private Face _0023_003DzOlNwD47TQMAt(int _0023_003DzyzK8swU_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out Node _0023_003Dz0wAkCmM_003D, out Node _0023_003Dz_0024eRdUwQ_003D, out Node _0023_003Dz5cbO6Ls_003D, out Node _0023_003Dz4BKUbLs_003D, out Node _0023_003DzoumYP2o_003D, out Node _0023_003Dz_FV_0024jMs_003D, out Node _0023_003DzL8_U_0024TI_003D, out Node _0023_003DzGaV7K94_003D, out Vector3D _0023_003DzRnnx5m0_003D, out Vector3D _0023_003DzW_0024ubBfM_003D, out Vector3D _0023_003DzQyTjV9Q_003D, out Vector3D _0023_003DzRxmqpY8_003D, out Vector3D _0023_003DzjMJr9AU_003D, out Vector3D _0023_003DzVhH_NPo_003D, out Vector3D _0023_003Dz3x90_C4_003D, out Vector3D _0023_003DzBVmNoYc_003D, out Vector3D _0023_003DzEOW1QaldcTPK62eMAw_003D_003D)
	{
		Face face = elFaces[_0023_003DzyzK8swU_003D];
		byte[] indices = face.Indices;
		Vector3D[] cornerNormals = face.CornerNormals;
		_0023_003Dz0wAkCmM_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[indices[0]]];
		_0023_003Dz_0024eRdUwQ_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[indices[1]]];
		_0023_003Dz5cbO6Ls_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[indices[2]]];
		_0023_003Dz4BKUbLs_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[indices[3]]];
		_0023_003DzoumYP2o_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[indices[4]]];
		_0023_003Dz_FV_0024jMs_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[indices[5]]];
		_0023_003DzL8_U_0024TI_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[indices[6]]];
		_0023_003DzGaV7K94_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[indices[7]]];
		_0023_003DzRnnx5m0_003D = cornerNormals[0];
		_0023_003DzW_0024ubBfM_003D = cornerNormals[1];
		_0023_003DzQyTjV9Q_003D = cornerNormals[2];
		_0023_003DzRxmqpY8_003D = cornerNormals[3];
		_0023_003DzjMJr9AU_003D = _0023_003DzRnnx5m0_003D + _0023_003DzW_0024ubBfM_003D;
		_0023_003DzjMJr9AU_003D.Normalize();
		_0023_003DzVhH_NPo_003D = _0023_003DzW_0024ubBfM_003D + _0023_003DzQyTjV9Q_003D;
		_0023_003DzVhH_NPo_003D.Normalize();
		_0023_003Dz3x90_C4_003D = _0023_003DzQyTjV9Q_003D + _0023_003DzRxmqpY8_003D;
		_0023_003Dz3x90_C4_003D.Normalize();
		_0023_003DzBVmNoYc_003D = _0023_003DzRxmqpY8_003D + _0023_003DzRnnx5m0_003D;
		_0023_003DzBVmNoYc_003D.Normalize();
		_0023_003DzEOW1QaldcTPK62eMAw_003D_003D = _0023_003DzjMJr9AU_003D + _0023_003DzVhH_NPo_003D + _0023_003Dz3x90_C4_003D + _0023_003DzBVmNoYc_003D;
		_0023_003DzEOW1QaldcTPK62eMAw_003D_003D.Normalize();
		return face;
	}

	protected void DrawFace8(RenderContextBase context, Color singleColor, int index, Point3D[] vertices, double ampFactor, int mode)
	{
		Node _0023_003Dz0wAkCmM_003D;
		Node _0023_003Dz_0024eRdUwQ_003D;
		Node _0023_003Dz5cbO6Ls_003D;
		Node _0023_003Dz4BKUbLs_003D;
		Node _0023_003DzoumYP2o_003D;
		Node _0023_003Dz_FV_0024jMs_003D;
		Node _0023_003DzL8_U_0024TI_003D;
		Node _0023_003DzGaV7K94_003D;
		Vector3D _0023_003DzRnnx5m0_003D;
		Vector3D _0023_003DzW_0024ubBfM_003D;
		Vector3D _0023_003DzQyTjV9Q_003D;
		Vector3D _0023_003DzRxmqpY8_003D;
		Vector3D _0023_003DzjMJr9AU_003D;
		Vector3D _0023_003DzVhH_NPo_003D;
		Vector3D _0023_003Dz3x90_C4_003D;
		Vector3D _0023_003DzBVmNoYc_003D;
		Vector3D _0023_003DzEOW1QaldcTPK62eMAw_003D_003D;
		Face face = _0023_003DzOlNwD47TQMAt(index, vertices, out _0023_003Dz0wAkCmM_003D, out _0023_003Dz_0024eRdUwQ_003D, out _0023_003Dz5cbO6Ls_003D, out _0023_003Dz4BKUbLs_003D, out _0023_003DzoumYP2o_003D, out _0023_003Dz_FV_0024jMs_003D, out _0023_003DzL8_U_0024TI_003D, out _0023_003DzGaV7K94_003D, out _0023_003DzRnnx5m0_003D, out _0023_003DzW_0024ubBfM_003D, out _0023_003DzQyTjV9Q_003D, out _0023_003DzRxmqpY8_003D, out _0023_003DzjMJr9AU_003D, out _0023_003DzVhH_NPo_003D, out _0023_003Dz3x90_C4_003D, out _0023_003DzBVmNoYc_003D, out _0023_003DzEOW1QaldcTPK62eMAw_003D_003D);
		_0023_003DzxjHGIv6i1T9l(context, singleColor, _0023_003Dz0wAkCmM_003D, _0023_003Dz_0024eRdUwQ_003D, face.Centroid, _0023_003DzRnnx5m0_003D, _0023_003DzjMJr9AU_003D, _0023_003DzEOW1QaldcTPK62eMAw_003D_003D, ampFactor, mode);
		_0023_003DzxjHGIv6i1T9l(context, singleColor, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz5cbO6Ls_003D, face.Centroid, _0023_003DzjMJr9AU_003D, _0023_003DzW_0024ubBfM_003D, _0023_003DzEOW1QaldcTPK62eMAw_003D_003D, ampFactor, mode);
		_0023_003DzxjHGIv6i1T9l(context, singleColor, _0023_003Dz5cbO6Ls_003D, _0023_003Dz4BKUbLs_003D, face.Centroid, _0023_003DzW_0024ubBfM_003D, _0023_003DzVhH_NPo_003D, _0023_003DzEOW1QaldcTPK62eMAw_003D_003D, ampFactor, mode);
		_0023_003DzxjHGIv6i1T9l(context, singleColor, _0023_003Dz4BKUbLs_003D, _0023_003DzoumYP2o_003D, face.Centroid, _0023_003DzVhH_NPo_003D, _0023_003DzQyTjV9Q_003D, _0023_003DzEOW1QaldcTPK62eMAw_003D_003D, ampFactor, mode);
		_0023_003DzxjHGIv6i1T9l(context, singleColor, _0023_003DzoumYP2o_003D, _0023_003Dz_FV_0024jMs_003D, face.Centroid, _0023_003DzQyTjV9Q_003D, _0023_003Dz3x90_C4_003D, _0023_003DzEOW1QaldcTPK62eMAw_003D_003D, ampFactor, mode);
		_0023_003DzxjHGIv6i1T9l(context, singleColor, _0023_003Dz_FV_0024jMs_003D, _0023_003DzL8_U_0024TI_003D, face.Centroid, _0023_003Dz3x90_C4_003D, _0023_003DzRxmqpY8_003D, _0023_003DzEOW1QaldcTPK62eMAw_003D_003D, ampFactor, mode);
		_0023_003DzxjHGIv6i1T9l(context, singleColor, _0023_003DzL8_U_0024TI_003D, _0023_003DzGaV7K94_003D, face.Centroid, _0023_003DzRxmqpY8_003D, _0023_003DzBVmNoYc_003D, _0023_003DzEOW1QaldcTPK62eMAw_003D_003D, ampFactor, mode);
		_0023_003DzxjHGIv6i1T9l(context, singleColor, _0023_003DzGaV7K94_003D, _0023_003Dz0wAkCmM_003D, face.Centroid, _0023_003DzBVmNoYc_003D, _0023_003DzRnnx5m0_003D, _0023_003DzEOW1QaldcTPK62eMAw_003D_003D, ampFactor, mode);
	}

	protected void DrawFace8(RenderContextBase context, int index, Point3D[] vertices, double ampFactor, int mode)
	{
		Node _0023_003Dz0wAkCmM_003D;
		Node _0023_003Dz_0024eRdUwQ_003D;
		Node _0023_003Dz5cbO6Ls_003D;
		Node _0023_003Dz4BKUbLs_003D;
		Node _0023_003DzoumYP2o_003D;
		Node _0023_003Dz_FV_0024jMs_003D;
		Node _0023_003DzL8_U_0024TI_003D;
		Node _0023_003DzGaV7K94_003D;
		Vector3D _0023_003DzRnnx5m0_003D;
		Vector3D _0023_003DzW_0024ubBfM_003D;
		Vector3D _0023_003DzQyTjV9Q_003D;
		Vector3D _0023_003DzRxmqpY8_003D;
		Vector3D _0023_003DzjMJr9AU_003D;
		Vector3D _0023_003DzVhH_NPo_003D;
		Vector3D _0023_003Dz3x90_C4_003D;
		Vector3D _0023_003DzBVmNoYc_003D;
		Vector3D _0023_003DzEOW1QaldcTPK62eMAw_003D_003D;
		Face face = _0023_003DzOlNwD47TQMAt(index, vertices, out _0023_003Dz0wAkCmM_003D, out _0023_003Dz_0024eRdUwQ_003D, out _0023_003Dz5cbO6Ls_003D, out _0023_003Dz4BKUbLs_003D, out _0023_003DzoumYP2o_003D, out _0023_003Dz_FV_0024jMs_003D, out _0023_003DzL8_U_0024TI_003D, out _0023_003DzGaV7K94_003D, out _0023_003DzRnnx5m0_003D, out _0023_003DzW_0024ubBfM_003D, out _0023_003DzQyTjV9Q_003D, out _0023_003DzRxmqpY8_003D, out _0023_003DzjMJr9AU_003D, out _0023_003DzVhH_NPo_003D, out _0023_003Dz3x90_C4_003D, out _0023_003DzBVmNoYc_003D, out _0023_003DzEOW1QaldcTPK62eMAw_003D_003D);
		_0023_003DzxjHGIv6i1T9l(context, _0023_003Dz0wAkCmM_003D, _0023_003Dz_0024eRdUwQ_003D, face.Centroid, _0023_003DzRnnx5m0_003D, _0023_003DzjMJr9AU_003D, _0023_003DzEOW1QaldcTPK62eMAw_003D_003D, ampFactor, mode);
		_0023_003DzxjHGIv6i1T9l(context, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz5cbO6Ls_003D, face.Centroid, _0023_003DzjMJr9AU_003D, _0023_003DzW_0024ubBfM_003D, _0023_003DzEOW1QaldcTPK62eMAw_003D_003D, ampFactor, mode);
		_0023_003DzxjHGIv6i1T9l(context, _0023_003Dz5cbO6Ls_003D, _0023_003Dz4BKUbLs_003D, face.Centroid, _0023_003DzW_0024ubBfM_003D, _0023_003DzVhH_NPo_003D, _0023_003DzEOW1QaldcTPK62eMAw_003D_003D, ampFactor, mode);
		_0023_003DzxjHGIv6i1T9l(context, _0023_003Dz4BKUbLs_003D, _0023_003DzoumYP2o_003D, face.Centroid, _0023_003DzVhH_NPo_003D, _0023_003DzQyTjV9Q_003D, _0023_003DzEOW1QaldcTPK62eMAw_003D_003D, ampFactor, mode);
		_0023_003DzxjHGIv6i1T9l(context, _0023_003DzoumYP2o_003D, _0023_003Dz_FV_0024jMs_003D, face.Centroid, _0023_003DzQyTjV9Q_003D, _0023_003Dz3x90_C4_003D, _0023_003DzEOW1QaldcTPK62eMAw_003D_003D, ampFactor, mode);
		_0023_003DzxjHGIv6i1T9l(context, _0023_003Dz_FV_0024jMs_003D, _0023_003DzL8_U_0024TI_003D, face.Centroid, _0023_003Dz3x90_C4_003D, _0023_003DzRxmqpY8_003D, _0023_003DzEOW1QaldcTPK62eMAw_003D_003D, ampFactor, mode);
		_0023_003DzxjHGIv6i1T9l(context, _0023_003DzL8_U_0024TI_003D, _0023_003DzGaV7K94_003D, face.Centroid, _0023_003DzRxmqpY8_003D, _0023_003DzBVmNoYc_003D, _0023_003DzEOW1QaldcTPK62eMAw_003D_003D, ampFactor, mode);
		_0023_003DzxjHGIv6i1T9l(context, _0023_003DzGaV7K94_003D, _0023_003Dz0wAkCmM_003D, face.Centroid, _0023_003DzBVmNoYc_003D, _0023_003DzRnnx5m0_003D, _0023_003DzEOW1QaldcTPK62eMAw_003D_003D, ampFactor, mode);
	}

	protected void DrawFace8(RenderContextBase context, int index, Point3D[] vertices, double min, double max, double ampFactor, int mode)
	{
		Face face = elFaces[index];
		byte[] indices = face.Indices;
		Vector3D[] cornerNormals = face.CornerNormals;
		Node _0023_003Dz0wAkCmM_003D = (Node)vertices[Connection[indices[0]]];
		Node node = (Node)vertices[Connection[indices[1]]];
		Node _0023_003Dz_0024eRdUwQ_003D = (Node)vertices[Connection[indices[2]]];
		Node node2 = (Node)vertices[Connection[indices[3]]];
		Node _0023_003Dz5cbO6Ls_003D = (Node)vertices[Connection[indices[4]]];
		Node node3 = (Node)vertices[Connection[indices[5]]];
		Node _0023_003Dz4BKUbLs_003D = (Node)vertices[Connection[indices[6]]];
		Node node4 = (Node)vertices[Connection[indices[7]]];
		Vector3D vector3D = cornerNormals[0];
		Vector3D vector3D2 = cornerNormals[1];
		Vector3D vector3D3 = cornerNormals[2];
		Vector3D vector3D4 = cornerNormals[3];
		Vector3D vector3D5 = vector3D + vector3D2;
		vector3D5.Normalize();
		Vector3D vector3D6 = vector3D2 + vector3D3;
		vector3D6.Normalize();
		Vector3D vector3D7 = vector3D3 + vector3D4;
		vector3D7.Normalize();
		Vector3D vector3D8 = vector3D4 + vector3D;
		vector3D8.Normalize();
		Vector3D vector3D9 = vector3D5 + vector3D6 + vector3D7 + vector3D8;
		vector3D9.Normalize();
		_0023_003DzXi20vtyDcANt(context, _0023_003Dz0wAkCmM_003D, node, face.Centroid, node4, vector3D, vector3D5, vector3D9, vector3D8, min, max, ampFactor, mode);
		_0023_003DzXi20vtyDcANt(context, node, _0023_003Dz_0024eRdUwQ_003D, node2, face.Centroid, vector3D5, vector3D2, vector3D6, vector3D9, min, max, ampFactor, mode);
		_0023_003DzXi20vtyDcANt(context, face.Centroid, node2, _0023_003Dz5cbO6Ls_003D, node3, vector3D9, vector3D6, vector3D3, vector3D7, min, max, ampFactor, mode);
		_0023_003DzXi20vtyDcANt(context, node4, face.Centroid, node3, _0023_003Dz4BKUbLs_003D, vector3D8, vector3D9, vector3D7, vector3D4, min, max, ampFactor, mode);
	}

	private static void _0023_003DzXi20vtyDcANt(RenderContextBase _0023_003DzB8iS0QA_003D, Node _0023_003Dz0wAkCmM_003D, Node _0023_003Dz_0024eRdUwQ_003D, Node _0023_003Dz5cbO6Ls_003D, Node _0023_003Dz4BKUbLs_003D, Vector3D _0023_003DzRnnx5m0_003D, Vector3D _0023_003DzjMJr9AU_003D, Vector3D _0023_003DzW_0024ubBfM_003D, Vector3D _0023_003DzVhH_NPo_003D, double _0023_003DzF7v9r2A_003D, double _0023_003Dz8dK2uhU_003D, double _0023_003DzXGmnJb5mDXOU, int _0023_003DznXXM9vk_003D)
	{
		if (Math.Abs(_0023_003Dz5cbO6Ls_003D.PlotValue - _0023_003Dz0wAkCmM_003D.PlotValue) < Math.Abs(_0023_003Dz4BKUbLs_003D.PlotValue - _0023_003Dz_0024eRdUwQ_003D.PlotValue))
		{
			_0023_003DzQhddrIGPdy0i(_0023_003DzB8iS0QA_003D, _0023_003Dz0wAkCmM_003D, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz5cbO6Ls_003D, _0023_003DzRnnx5m0_003D, _0023_003DzjMJr9AU_003D, _0023_003DzW_0024ubBfM_003D, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D, _0023_003DzXGmnJb5mDXOU, _0023_003DznXXM9vk_003D);
			_0023_003DzQhddrIGPdy0i(_0023_003DzB8iS0QA_003D, _0023_003Dz0wAkCmM_003D, _0023_003Dz5cbO6Ls_003D, _0023_003Dz4BKUbLs_003D, _0023_003DzRnnx5m0_003D, _0023_003DzW_0024ubBfM_003D, _0023_003DzVhH_NPo_003D, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D, _0023_003DzXGmnJb5mDXOU, _0023_003DznXXM9vk_003D);
		}
		else
		{
			_0023_003DzQhddrIGPdy0i(_0023_003DzB8iS0QA_003D, _0023_003Dz0wAkCmM_003D, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz4BKUbLs_003D, _0023_003DzRnnx5m0_003D, _0023_003DzjMJr9AU_003D, _0023_003DzVhH_NPo_003D, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D, _0023_003DzXGmnJb5mDXOU, _0023_003DznXXM9vk_003D);
			_0023_003DzQhddrIGPdy0i(_0023_003DzB8iS0QA_003D, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz5cbO6Ls_003D, _0023_003Dz4BKUbLs_003D, _0023_003DzjMJr9AU_003D, _0023_003DzW_0024ubBfM_003D, _0023_003DzVhH_NPo_003D, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D, _0023_003DzXGmnJb5mDXOU, _0023_003DznXXM9vk_003D);
		}
	}

	internal void _0023_003Dz_0024pRElff8RWIV(RenderContextBase _0023_003DzB8iS0QA_003D, int _0023_003DzyzK8swU_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, double _0023_003DzF7v9r2A_003D, double _0023_003Dz8dK2uhU_003D, double _0023_003DzXGmnJb5mDXOU, int _0023_003DznXXM9vk_003D)
	{
		Face face = elFaces[_0023_003DzyzK8swU_003D];
		byte[] indices = face.Indices;
		Vector3D[] cornerNormals = face.CornerNormals;
		int num = indices[0];
		int num2 = indices[1];
		int num3 = indices[2];
		int num4 = indices[3];
		int num5 = indices[4];
		int num6 = indices[5];
		int num7 = indices[6];
		int num8 = indices[7];
		Node _0023_003Dz0wAkCmM_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[num]];
		Node node = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[num2]];
		Node _0023_003Dz_0024eRdUwQ_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[num3]];
		Node node2 = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[num4]];
		Node _0023_003Dz5cbO6Ls_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[num5]];
		Node node3 = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[num6]];
		Node _0023_003Dz4BKUbLs_003D = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[num7]];
		Node node4 = (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[num8]];
		Vector3D vector3D = cornerNormals[0];
		Vector3D vector3D2 = cornerNormals[1];
		Vector3D vector3D3 = cornerNormals[2];
		Vector3D vector3D4 = cornerNormals[3];
		Vector3D vector3D5 = vector3D + vector3D2;
		vector3D5.Normalize();
		Vector3D vector3D6 = vector3D2 + vector3D3;
		vector3D6.Normalize();
		Vector3D vector3D7 = vector3D3 + vector3D4;
		vector3D7.Normalize();
		Vector3D vector3D8 = vector3D4 + vector3D;
		vector3D8.Normalize();
		Vector3D vector3D9 = vector3D5 + vector3D6 + vector3D7 + vector3D8;
		vector3D9.Normalize();
		_0023_003Dz6oihomIA6__4(_0023_003DzB8iS0QA_003D, PlotValues[num], PlotValues[num2], face.Centroid.PlotValue, PlotValues[num8], _0023_003Dz0wAkCmM_003D, node, face.Centroid, node4, vector3D, vector3D5, vector3D9, vector3D8, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D, _0023_003DzXGmnJb5mDXOU, _0023_003DznXXM9vk_003D);
		_0023_003Dz6oihomIA6__4(_0023_003DzB8iS0QA_003D, PlotValues[num2], PlotValues[num3], PlotValues[num4], face.Centroid.PlotValue, node, _0023_003Dz_0024eRdUwQ_003D, node2, face.Centroid, vector3D5, vector3D2, vector3D6, vector3D9, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D, _0023_003DzXGmnJb5mDXOU, _0023_003DznXXM9vk_003D);
		_0023_003Dz6oihomIA6__4(_0023_003DzB8iS0QA_003D, face.Centroid.PlotValue, PlotValues[num4], PlotValues[num5], PlotValues[num6], face.Centroid, node2, _0023_003Dz5cbO6Ls_003D, node3, vector3D9, vector3D6, vector3D3, vector3D7, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D, _0023_003DzXGmnJb5mDXOU, _0023_003DznXXM9vk_003D);
		_0023_003Dz6oihomIA6__4(_0023_003DzB8iS0QA_003D, PlotValues[num8], face.Centroid.PlotValue, PlotValues[num6], PlotValues[num7], node4, face.Centroid, node3, _0023_003Dz4BKUbLs_003D, vector3D8, vector3D9, vector3D7, vector3D4, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D, _0023_003DzXGmnJb5mDXOU, _0023_003DznXXM9vk_003D);
	}

	private static void _0023_003Dz6oihomIA6__4(RenderContextBase _0023_003DzB8iS0QA_003D, double _0023_003DzffqPLNQ_003D, double _0023_003Dz5Azd7L8_003D, double _0023_003DzZe6oCrQ_003D, double _0023_003DzvPZnhP0_003D, Node _0023_003Dz0wAkCmM_003D, Node _0023_003Dz_0024eRdUwQ_003D, Node _0023_003Dz5cbO6Ls_003D, Node _0023_003Dz4BKUbLs_003D, Vector3D _0023_003DzRnnx5m0_003D, Vector3D _0023_003DzjMJr9AU_003D, Vector3D _0023_003DzW_0024ubBfM_003D, Vector3D _0023_003DzVhH_NPo_003D, double _0023_003DzF7v9r2A_003D, double _0023_003Dz8dK2uhU_003D, double _0023_003DzXGmnJb5mDXOU, int _0023_003DznXXM9vk_003D)
	{
		if (Math.Abs(_0023_003DzZe6oCrQ_003D - _0023_003DzffqPLNQ_003D) < Math.Abs(_0023_003DzvPZnhP0_003D - _0023_003Dz5Azd7L8_003D))
		{
			_0023_003DzOtt2oBpNBc1J(_0023_003DzB8iS0QA_003D, _0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, _0023_003DzZe6oCrQ_003D, _0023_003Dz0wAkCmM_003D, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz5cbO6Ls_003D, _0023_003DzRnnx5m0_003D, _0023_003DzjMJr9AU_003D, _0023_003DzW_0024ubBfM_003D, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D, _0023_003DzXGmnJb5mDXOU, _0023_003DznXXM9vk_003D);
			_0023_003DzOtt2oBpNBc1J(_0023_003DzB8iS0QA_003D, _0023_003DzffqPLNQ_003D, _0023_003DzZe6oCrQ_003D, _0023_003DzvPZnhP0_003D, _0023_003Dz0wAkCmM_003D, _0023_003Dz5cbO6Ls_003D, _0023_003Dz4BKUbLs_003D, _0023_003DzRnnx5m0_003D, _0023_003DzW_0024ubBfM_003D, _0023_003DzVhH_NPo_003D, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D, _0023_003DzXGmnJb5mDXOU, _0023_003DznXXM9vk_003D);
		}
		else
		{
			_0023_003DzOtt2oBpNBc1J(_0023_003DzB8iS0QA_003D, _0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, _0023_003DzvPZnhP0_003D, _0023_003Dz0wAkCmM_003D, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz4BKUbLs_003D, _0023_003DzRnnx5m0_003D, _0023_003DzjMJr9AU_003D, _0023_003DzVhH_NPo_003D, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D, _0023_003DzXGmnJb5mDXOU, _0023_003DznXXM9vk_003D);
			_0023_003DzOtt2oBpNBc1J(_0023_003DzB8iS0QA_003D, _0023_003Dz5Azd7L8_003D, _0023_003DzZe6oCrQ_003D, _0023_003DzvPZnhP0_003D, _0023_003Dz_0024eRdUwQ_003D, _0023_003Dz5cbO6Ls_003D, _0023_003Dz4BKUbLs_003D, _0023_003DzjMJr9AU_003D, _0023_003DzW_0024ubBfM_003D, _0023_003DzVhH_NPo_003D, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D, _0023_003DzXGmnJb5mDXOU, _0023_003DznXXM9vk_003D);
		}
	}

	private void _0023_003Dz9ObkOhBxTfoTbEjzT2M9vWSfnW696ze25w_003D_003D(Node _0023_003DzRnnx5m0_003D, Node _0023_003DzjMJr9AU_003D, int _0023_003DzAPBIJmvn5i5Q, double _0023_003DzXGmnJb5mDXOU, double _0023_003Dzy6Km22i8t1UG, int _0023_003DznXXM9vk_003D, out double _0023_003DzEGKj_0024SNUUihi, out Point3D _0023_003DzAqOpw0w_003D, out Point3D _0023_003Dzk64JNOo_003D, out Point3D[] _0023_003Dzz_0024GCZofvnh1q)
	{
		_0023_003Dzz_0024GCZofvnh1q = new Point3D[_0023_003DzAPBIJmvn5i5Q * 2];
		_0023_003DzAqOpw0w_003D = new Point3D(_0023_003DzRnnx5m0_003D.X + _0023_003DzRnnx5m0_003D.Unknowns[_0023_003DznXXM9vk_003D][0] * _0023_003DzXGmnJb5mDXOU, _0023_003DzRnnx5m0_003D.Y + _0023_003DzRnnx5m0_003D.Unknowns[_0023_003DznXXM9vk_003D][1] * _0023_003DzXGmnJb5mDXOU, _0023_003DzRnnx5m0_003D.Z + _0023_003DzRnnx5m0_003D.Unknowns[_0023_003DznXXM9vk_003D][2] * _0023_003DzXGmnJb5mDXOU);
		_0023_003Dzk64JNOo_003D = new Point3D(_0023_003DzjMJr9AU_003D.X + _0023_003DzjMJr9AU_003D.Unknowns[_0023_003DznXXM9vk_003D][0] * _0023_003DzXGmnJb5mDXOU, _0023_003DzjMJr9AU_003D.Y + _0023_003DzjMJr9AU_003D.Unknowns[_0023_003DznXXM9vk_003D][1] * _0023_003DzXGmnJb5mDXOU, _0023_003DzjMJr9AU_003D.Z + _0023_003DzjMJr9AU_003D.Unknowns[_0023_003DznXXM9vk_003D][2] * _0023_003DzXGmnJb5mDXOU);
		_0023_003DzEGKj_0024SNUUihi = Math.Sqrt(_0023_003Dzy6Km22i8t1UG / Math.PI);
		Vector3D vector3D = Vector3D.Subtract(_0023_003Dzk64JNOo_003D, _0023_003DzAqOpw0w_003D);
		double length = vector3D.Length;
		for (int i = 0; i < _0023_003DzAPBIJmvn5i5Q; i++)
		{
			double num = (double)(i * 2) * Math.PI / (double)_0023_003DzAPBIJmvn5i5Q;
			double num2 = Math.Cos(num);
			double num3 = Math.Sin(num);
			_0023_003Dzz_0024GCZofvnh1q[i] = new Point3D(0.0, num2 * _0023_003DzEGKj_0024SNUUihi, num3 * _0023_003DzEGKj_0024SNUUihi);
			_0023_003Dzz_0024GCZofvnh1q[i + _0023_003DzAPBIJmvn5i5Q] = new Point3D(length, num2 * _0023_003DzEGKj_0024SNUUihi, num3 * _0023_003DzEGKj_0024SNUUihi);
		}
		Transformation orientationTransformation = Utility.GetOrientationTransformation(_0023_003DzAqOpw0w_003D, vector3D);
		for (int j = 0; j < _0023_003DzAPBIJmvn5i5Q; j++)
		{
			_0023_003Dzz_0024GCZofvnh1q[j] = orientationTransformation * _0023_003Dzz_0024GCZofvnh1q[j];
			_0023_003Dzz_0024GCZofvnh1q[_0023_003DzAPBIJmvn5i5Q + j] = orientationTransformation * _0023_003Dzz_0024GCZofvnh1q[_0023_003DzAPBIJmvn5i5Q + j];
		}
	}

	public virtual void Refine(int s, int t, int r, FemMesh fm)
	{
	}

	public virtual void SetPressure(int index, Vector3D pressure, Point3D[] vertices)
	{
		if ((this is Tria3 && vertices[Connection[0]] is NodeBeam) || (this is Quad4 && vertices[Connection[0]] is NodeBeam))
		{
			if (((Element2D)this).elFaces[index].Pressure == null)
			{
				((Element2D)this).elFaces[index].Pressure = new double[3] { pressure.X, pressure.Y, pressure.Z };
			}
			else
			{
				((Element2D)this).elFaces[index].Pressure[0] += pressure.X;
				((Element2D)this).elFaces[index].Pressure[1] += pressure.Y;
				((Element2D)this).elFaces[index].Pressure[2] += pressure.Z;
			}
		}
		else if (this is Element2D && !(this is Truss2D))
		{
			if (((Element2D)this).Edges[index].Pressure == null)
			{
				((Element2D)this).Edges[index].Pressure = new double[2] { pressure.X, pressure.Y };
			}
			else
			{
				((Element2D)this).Edges[index].Pressure[0] += pressure.X;
				((Element2D)this).Edges[index].Pressure[1] += pressure.Y;
			}
		}
		else if (this is Element3D && !(this is Truss))
		{
			if (((Element3D)this).elFaces[index].Pressure == null)
			{
				((Element3D)this).elFaces[index].Pressure = new double[3] { pressure.X, pressure.Y, pressure.Z };
			}
			else
			{
				((Element3D)this).elFaces[index].Pressure[0] += pressure.X;
				((Element3D)this).elFaces[index].Pressure[1] += pressure.Y;
				((Element3D)this).elFaces[index].Pressure[2] += pressure.Z;
			}
		}
	}

	public virtual void SetPressure(int index, double pressure, Point3D[] vertices)
	{
		if ((this is Tria3 && vertices[Connection[0]] is NodeBeam) || (this is Quad4 && vertices[Connection[0]] is NodeBeam))
		{
			((Element2D)this).elFaces[index].NormalPressure += pressure;
		}
		else if (this is Element2D && !(this is Truss2D))
		{
			((Element2D)this).Edges[index].NormalPressure += pressure;
		}
		else if (this is Element3D && !(this is Truss))
		{
			((Element3D)this).elFaces[index].NormalPressure += pressure;
		}
	}

	public virtual void FixEdgeFace(int edgeFaceIndex, bool alongX, bool alongY, bool alongZ)
	{
	}

	public virtual void FixAllEdgeFace(int edgeFaceIndex)
	{
	}

	public virtual void SetRestraintEdgeFace(int edgeFaceIndex, bool alongX, bool alongY, bool alongZ, double amountInX, double amountInY, double amountInZ)
	{
	}

	public virtual void SetRestraintEdgeFaceInX(int edgeFaceIndex, double amountInX)
	{
	}

	public virtual void SetRestraintEdgeFaceInY(int edgeFaceIndex, double amountInY)
	{
	}

	public virtual void SetRestraintEdgeFaceInZ(int edgeFaceIndex, double amountInZ)
	{
	}

	internal void _0023_003DzrZebj3Heywbr()
	{
		if (elFaces != null)
		{
			Face[] array = elFaces;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Visible = false;
			}
		}
	}

	internal int _0023_003Dz50rnh9I_003D(byte _0023_003Dzj6OQ9jH7xx3g, byte _0023_003DzAdg8iZA_003D)
	{
		return Connection[elFaces[_0023_003Dzj6OQ9jH7xx3g].Indices[_0023_003DzAdg8iZA_003D]];
	}

	protected IndexTriangle[] GetFace6(int elIndex, int index, Point3D[] vertices, double ampFactor, List<Point3D> centroids)
	{
		byte[] indices = elFaces[index].Indices;
		IndexTriangle[] array = new IndexTriangle[4];
		_0023_003DzPq45nGk_003D(elIndex, 0, Connection[indices[0]], Connection[indices[1]], Connection[indices[5]], array);
		_0023_003DzPq45nGk_003D(elIndex, 1, Connection[indices[1]], Connection[indices[2]], Connection[indices[3]], array);
		_0023_003DzPq45nGk_003D(elIndex, 2, Connection[indices[1]], Connection[indices[3]], Connection[indices[5]], array);
		_0023_003DzPq45nGk_003D(elIndex, 3, Connection[indices[3]], Connection[indices[4]], Connection[indices[5]], array);
		return array;
	}

	protected IndexTriangle[] GetFace8(int elIndex, int index, Point3D[] vertices, double ampFactor, List<Point3D> centroids)
	{
		Face face = elFaces[index];
		byte[] indices = face.Indices;
		int num = centroids.Count + 1;
		centroids.Add(face.Centroid);
		IndexTriangle[] array = new IndexTriangle[8];
		_0023_003DzPq45nGk_003D(elIndex, 0, Connection[indices[0]], Connection[indices[1]], -num, array);
		_0023_003DzPq45nGk_003D(elIndex, 1, Connection[indices[1]], Connection[indices[2]], -num, array);
		_0023_003DzPq45nGk_003D(elIndex, 2, Connection[indices[2]], Connection[indices[3]], -num, array);
		_0023_003DzPq45nGk_003D(elIndex, 3, Connection[indices[3]], Connection[indices[4]], -num, array);
		_0023_003DzPq45nGk_003D(elIndex, 4, Connection[indices[4]], Connection[indices[5]], -num, array);
		_0023_003DzPq45nGk_003D(elIndex, 5, Connection[indices[5]], Connection[indices[6]], -num, array);
		_0023_003DzPq45nGk_003D(elIndex, 6, Connection[indices[6]], Connection[indices[7]], -num, array);
		_0023_003DzPq45nGk_003D(elIndex, 7, Connection[indices[7]], Connection[indices[0]], -num, array);
		return array;
	}

	internal Node _0023_003DzlW6M2e9BpjZg(byte _0023_003Dzfe2zeQMumw_4, byte _0023_003DzAdg8iZA_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		return (Node)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[Connection[elFaces[_0023_003Dzfe2zeQMumw_4].Indices[_0023_003DzAdg8iZA_003D]]];
	}

	internal virtual double[] _0023_003DzzIzJffApVWY5wxS3LQ_003D_003D(Face _0023_003Dz3PZbRez_mP9t)
	{
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984971));
	}
}
