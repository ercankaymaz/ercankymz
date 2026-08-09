using System;
using System.Collections.Generic;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Fem;

public class DirectSolver : SolverBase
{
	public DirectSolver(FemMesh femMesh)
	{
		base.femMesh = femMesh;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		byte b = 4;
		object[] array = null;
		array = new object[3] { b, this, flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "$N9u(q\"acA", array);
		int num = femMesh.Vertices.Length;
		int num2 = femMesh.NumberOfDimensions;
		int num3 = femMesh.NumberOfDegreesOfFreedom;
		int num4 = femMesh.Elements.Length;
		int num5 = num4;
		isBeamStudy = femMesh.IsBeamStudy;
		if (isBeamStudy && !(femMesh.Vertices[0] is NodeBeam))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984287));
		}
		if (PreProcessing(progress, ct, out var _, out var _, out var hasTemperature, out var firstElType))
		{
			return;
		}
		int num6 = num * num3;
		int num7 = 1;
		char[] array2 = new char[num - 1 + 1];
		for (int i = 0; i < num; i++)
		{
			array2[i] = ' ';
		}
		int[] array3 = new int[num6];
		double[] array4 = new double[num6];
		int num8 = 0;
		Point3D[] vertices = femMesh.Vertices;
		for (int j = 0; j < vertices.Length; j++)
		{
			Node node = (Node)vertices[j];
			if (node.Restrained || (node is NodeBeam && ((NodeBeam)node).RotationRestrained))
			{
				num8++;
			}
		}
		int[] array5 = new int[num8];
		int[] array6 = new int[num8 * num3];
		double[] array7 = new double[num8 * num3];
		int num9 = 0;
		for (int k = 0; k < femMesh.Vertices.Length; k++)
		{
			Node node2 = (Node)femMesh.Vertices[k];
			if (node2.Restrained)
			{
				array5[num9] = k;
				if (node2.restraints[0])
				{
					array6[num9] = 1;
					array7[num9] = node2.Displacement[0];
				}
				if (node2.restraints[1])
				{
					array6[num8 + num9] = 1;
					array7[num8 + num9] = node2.Displacement[1];
				}
				if (num2 > 2 && node2.restraints[2])
				{
					array6[num8 * 2 + num9] = 1;
					array7[num8 * 2 + num9] = node2.Displacement[2];
				}
			}
			if (node2 is NodeBeam { RotationRestrained: not false } nodeBeam)
			{
				array5[num9] = k;
				if (num3 == 3)
				{
					if (nodeBeam.rotationRestraints[0])
					{
						array6[num8 * 2 + num9] = 1;
						array7[num8 * 2 + num9] = nodeBeam.rotationDisplacement[0];
					}
				}
				else
				{
					if (num3 > 3 && nodeBeam.rotationRestraints[0])
					{
						array6[num8 * 3 + num9] = 1;
						array7[num8 * 3 + num9] = nodeBeam.rotationDisplacement[0];
					}
					if (num3 > 4 && nodeBeam.rotationRestraints[1])
					{
						array6[num8 * 4 + num9] = 1;
						array7[num8 * 4 + num9] = nodeBeam.rotationDisplacement[1];
					}
					if (num3 > 5 && nodeBeam.rotationRestraints[2])
					{
						array6[num8 * 5 + num9] = 1;
						array7[num8 * 5 + num9] = nodeBeam.rotationDisplacement[2];
					}
				}
			}
			if (node2.Restrained || (node2 is NodeBeam && ((NodeBeam)node2).RotationRestrained))
			{
				num9++;
			}
		}
		int num10 = num8;
		for (int l = 0; l < num8; l++)
		{
			int num11 = array5[l] * num3;
			for (int m = 0; m < num3; m++)
			{
				int num12 = num11 + m;
				if (array6[l + m * num10] == 1)
				{
					array3[num12] = array6[l + m * num10];
					array4[num12] = array7[l + m * num10];
				}
			}
		}
		int num13 = 0;
		Element[] elements = femMesh.Elements;
		foreach (Element element in elements)
		{
			if (element.NumberOfNodes > num13)
			{
				num13 = element.NumberOfNodes;
			}
		}
		int[] array8 = new int[num13 * num4];
		for (int n = 0; n < num4; n++)
		{
			Element element2 = femMesh.elements[n];
			for (int num14 = 0; num14 < element2.NumberOfNodes; num14++)
			{
				array8[num14 * num4 + n] = element2.Connection[num14] + 1;
			}
		}
		double[] array9 = new double[num4 * num13 * num3];
		for (int num15 = 0; num15 < num4; num15++)
		{
			Element element3 = femMesh.Elements[num15];
			for (int num16 = 0; num16 < element3.load.Length; num16++)
			{
				array9[num4 * num16 + num15] = element3.load[num16];
			}
		}
		int[] array10 = new int[num4];
		for (int num17 = 1; num17 <= num4; num17++)
		{
			array10[num17 - 1] = num17;
		}
		int _0023_003DzlO7zf3TwjOHb = 0;
		_0023_003Dz19qxjZ0_003D(array8, array10, ref _0023_003DzlO7zf3TwjOHb, femMesh);
		_0023_003DzUWazFZpAf9c6(array8, array10, ref _0023_003DzlO7zf3TwjOHb);
		for (int num18 = 1; num18 <= num4; num18++)
		{
			int num19 = num4 - num18 + 1;
			int num20 = array10[num19 - 1];
			int numberOfNodes = femMesh.Elements[num20 - 1].NumberOfNodes;
			for (int num21 = 0; num21 < numberOfNodes; num21++)
			{
				int num22 = array8[num20 - 1 + num21 * num5] - 1;
				if (array2[num22] != 'L')
				{
					array2[num22 - 1 + 1] = 'L';
					array8[num20 - 1 + num21 * num5] *= -1;
				}
			}
		}
		int num23 = _0023_003DzlO7zf3TwjOHb;
		int num24 = 0;
		elements = femMesh.Elements;
		foreach (Element element4 in elements)
		{
			if (element4.TotalDof > num24)
			{
				num24 = element4.TotalDof;
			}
		}
		double[] array11 = new double[num23 * (num23 + 1) / 2];
		double[] array12 = new double[num23];
		double[] array13 = new double[num23];
		double[] array14 = new double[num23];
		int[] array15 = new int[num23];
		_0023_003DzlO7zf3TwjOHb = 1;
		int num25 = 0;
		List<double> list = new List<double>();
		List<double> list2 = new List<double>();
		List<int> list3 = new List<int>();
		List<int> list4 = new List<int>();
		for (int num26 = 1; num26 <= num4; num26++)
		{
			int num27 = array10[num26 - 1];
			int num28 = 0;
			int numberOfNodes2 = femMesh.Elements[num27 - 1].NumberOfNodes;
			int numberOfDofPerNode = femMesh.Elements[num27 - 1].NumberOfDofPerNode;
			int totalDof = femMesh.Elements[num27 - 1].TotalDof;
			double[] array16 = new double[num24 * num24];
			for (int num29 = 0; num29 < totalDof; num29++)
			{
				for (int num30 = 0; num30 < totalDof; num30++)
				{
					array16[num29 + num30 * num24] = femMesh.Elements[num27 - 1].StiffnessMatrix[num29, num30];
				}
			}
			int[] array17 = new int[totalDof];
			for (int num31 = 0; num31 < numberOfNodes2; num31++)
			{
				for (int num32 = 1; num32 <= numberOfDofPerNode; num32++)
				{
					int num33 = num31 * num3 + num32;
					int num34 = array8[num27 - 1 + num31 * num5];
					if (num34 > 0)
					{
						array17[num33 - 1] = (num34 - 1) * num3 + num32;
					}
					if (num34 < 0)
					{
						array17[num33 - 1] = (num34 + 1) * num3 - num32;
					}
				}
			}
			int[] array18 = new int[totalDof];
			for (int num35 = 0; num35 < totalDof; num35++)
			{
				int num36 = Math.Abs(array17[num35]);
				int num37 = 0;
				for (int num38 = 1; num38 <= _0023_003DzlO7zf3TwjOHb; num38++)
				{
					if (num36 == array15[num38 - 1])
					{
						num28++;
						num37 = 1;
						array18[num28 - 1] = num38;
					}
				}
				if (num37 != 0)
				{
					continue;
				}
				for (int num38 = 1; num38 <= num23; num38++)
				{
					if (array15[num38 - 1] == 0)
					{
						array15[num38 - 1] = num36;
						num28++;
						array18[num28 - 1] = num38;
						break;
					}
				}
				if (array18[num28 - 1] > _0023_003DzlO7zf3TwjOHb)
				{
					_0023_003DzlO7zf3TwjOHb = array18[num28 - 1];
				}
			}
			for (int num39 = 1; num39 <= totalDof; num39++)
			{
				int num40 = array18[num39 - 1];
				array12[num40 - 1] += array9[num27 - 1 + (num39 - 1) * num5];
				if (num7 > 1)
				{
					continue;
				}
				for (int num41 = 0; num41 < num39; num41++)
				{
					int num42 = array18[num41];
					int num43 = (num42 * num42 - num42) / 2 + num40;
					int num44 = (num40 * num40 - num40) / 2 + num42;
					if (num42 >= num40)
					{
						array11[num43 - 1] += array16[num39 - 1 + num41 * num24];
					}
					if (num42 < num40)
					{
						array11[num44 - 1] += array16[num39 - 1 + num41 * num24];
					}
				}
			}
			for (int num45 = 1; num45 <= totalDof; num45++)
			{
				int num36 = -array17[num45 - 1];
				if (num36 <= 0)
				{
					continue;
				}
				for (int num38 = 1; num38 <= _0023_003DzlO7zf3TwjOHb; num38++)
				{
					if (array15[num38 - 1] != num36)
					{
						continue;
					}
					if (num7 <= 1)
					{
						for (int num46 = 1; num46 <= num23; num46++)
						{
							int num47 = 0;
							if (num38 < num46)
							{
								num47 = (num46 * num46 - num46) / 2 + num38;
							}
							if (num38 >= num46)
							{
								num47 = (num38 * num38 - num38) / 2 + num46;
							}
							array13[num46 - 1] = array11[num47 - 1];
							array11[num47 - 1] = 0.0;
						}
					}
					double num48 = array12[num38 - 1];
					array12[num38 - 1] = 0.0;
					num25++;
					if (num7 <= 1)
					{
						list.AddRange(array13);
						list2.Add(num48);
						list3.Add(num38);
						list4.Add(num36);
					}
					double num49 = array13[num38 - 1];
					if (num49 == 0.0)
					{
						num49 = 1.0;
					}
					array13[num38 - 1] = 0.0;
					if (array3[num36 - 1] != 0 && array3[num36 - 1] != 2)
					{
						for (int num50 = 1; num50 <= _0023_003DzlO7zf3TwjOHb; num50++)
						{
							array12[num50 - 1] -= array4[num36 - 1] * array13[num50 - 1];
						}
					}
					else
					{
						for (int num51 = 1; num51 <= _0023_003DzlO7zf3TwjOHb; num51++)
						{
							array12[num51 - 1] -= array13[num51 - 1] * num48 / num49;
							if (num7 <= 1 && (array13[num51 - 1] > 0.0 || array13[num51 - 1] < 0.0))
							{
								int num52 = (num51 * num51 - num51) / 2;
								for (int num53 = 1; num53 <= num51; num53++)
								{
									int num54 = num53 + num52;
									array11[num54 - 1] -= array13[num51 - 1] * array13[num53 - 1] / num49;
								}
							}
						}
					}
					array13[num38 - 1] = num49;
					array15[num38 - 1] = 0;
					break;
				}
				while (array15[_0023_003DzlO7zf3TwjOHb - 1] == 0)
				{
					_0023_003DzlO7zf3TwjOHb--;
					if (_0023_003DzlO7zf3TwjOHb <= 0)
					{
						break;
					}
				}
			}
		}
		double[][] array19 = new double[1][] { new double[num25] };
		for (int num55 = 1; num55 <= num25; num55++)
		{
			for (int num56 = 0; num56 < num23; num56++)
			{
				array13[num56] = list[(num25 - num55) * num23 + num56];
			}
			double num48 = list2[num25 - num55];
			int num38 = list3[num25 - num55];
			int num36 = list4[num25 - num55];
			double num57 = array13[num38 - 1];
			if (num57 == 0.0)
			{
				num57 = 1.0;
			}
			if (array3[num36 - 1] == 1)
			{
				array14[num38 - 1] = array4[num36 - 1];
			}
			if (array3[num36 - 1] == 0)
			{
				array13[num38 - 1] = 0.0;
			}
			for (int num58 = 1; num58 <= num23; num58++)
			{
				num48 -= array14[num58 - 1] * array13[num58 - 1];
			}
			if (array3[num36 - 1] == 0)
			{
				array14[num38 - 1] = num48 / num57;
			}
			if (array3[num36 - 1] == 1)
			{
				array4[num36 - 1] = 0.0 - num48;
			}
			array19[0][num36 - 1] = array14[num38 - 1];
		}
		num9 = 0;
		vertices = femMesh._vertices;
		for (int j = 0; j < vertices.Length; j++)
		{
			Node node3 = (Node)vertices[j];
			if (node3.Reactions == null)
			{
				node3.Reactions = new double[num3];
			}
			node3.Reactions = new double[6]
			{
				array4[num9],
				array4[num9 + 1],
				(num3 > 2) ? array4[num9 + 2] : 0.0,
				(num3 > 3) ? array4[num9 + 3] : 0.0,
				(num3 > 4) ? array4[num9 + 4] : 0.0,
				(num3 > 5) ? array4[num9 + 5] : 0.0
			};
			num9 += num3;
		}
		PostProcessing(progress, ct, array19, hasTemperature, firstElType);
	}

	private void _0023_003DzpMuYgsMqnlKe(int[] _0023_003DznpS3HRUO_0024Jao, int[] _0023_003DzYXH_FvCAxK3o, out int _0023_003Dztql_0024_6Zg4m2E)
	{
		int num = femMesh.Vertices.Length;
		int num2 = femMesh.Elements.Length;
		int num3 = num2;
		_ = femMesh.NumberOfDimensions;
		int num4 = femMesh.NumberOfDegreesOfFreedom;
		int num5 = 1;
		char[] array = new char[num - 1 + 1];
		for (int i = 1; i <= num; i++)
		{
			array[i - 1] = ' ';
		}
		int[] array2 = new int[num2];
		for (int j = 0; j < num2; j++)
		{
			int num6 = _0023_003DzYXH_FvCAxK3o[j];
			int numberOfNodes = femMesh.Elements[num6 - 1].NumberOfNodes;
			for (int k = 0; k < numberOfNodes; k++)
			{
				int num7 = _0023_003DznpS3HRUO_0024Jao[num6 - 1 + k * num3] - 1;
				if (num7 != -1 && array[num7] != 'F')
				{
					array2[num6 - 1] += num4;
					array[num7] = 'F';
				}
			}
		}
		for (int j = 1; j <= num2; j++)
		{
			int num8 = num2 - j + 1;
			int num9 = _0023_003DzYXH_FvCAxK3o[num8 - 1];
			int numberOfNodes = femMesh.Elements[num9 - 1].NumberOfNodes;
			for (int k = 0; k < numberOfNodes; k++)
			{
				int num7 = _0023_003DznpS3HRUO_0024Jao[num9 - 1 + k * num3] - 1;
				if (num7 != -1 && array[num7] != 'L')
				{
					if (num8 < num2)
					{
						array2[_0023_003DzYXH_FvCAxK3o[num8] - 1] -= num4;
					}
					array[num7] = 'L';
				}
			}
		}
		int num10 = 0;
		_0023_003Dztql_0024_6Zg4m2E = 0;
		for (int k = 0; k < num2; k++)
		{
			int num11 = _0023_003DzYXH_FvCAxK3o[k];
			_0023_003Dztql_0024_6Zg4m2E += array2[num11 - num5];
			if (_0023_003Dztql_0024_6Zg4m2E > num10)
			{
				num10 = _0023_003Dztql_0024_6Zg4m2E;
			}
		}
		_0023_003Dztql_0024_6Zg4m2E = num10;
	}

	private void _0023_003Dz19qxjZ0_003D(int[] _0023_003DznpS3HRUO_0024Jao, int[] _0023_003DzYXH_FvCAxK3o, ref int _0023_003DzlO7zf3TwjOHb, FemMesh _0023_003DzGGJSiQk_003D)
	{
		int num = 1;
		int num2 = _0023_003DzGGJSiQk_003D.Vertices.Length;
		int num3 = 1;
		int num4 = _0023_003DzGGJSiQk_003D.Elements.Length;
		int num5 = num4;
		int[] array = new int[num4];
		char[] array2 = new char[num2 - num + 1];
		_ = _0023_003DzGGJSiQk_003D.NumberOfDimensions;
		int num6 = _0023_003DzGGJSiQk_003D.NumberOfDegreesOfFreedom;
		for (int i = 1; i <= num2; i++)
		{
			array2[i - num] = ' ';
		}
		for (int j = 1; j <= num4; j++)
		{
			array[j - num3] = 0;
		}
		for (int k = 0; k < num4; k++)
		{
			int num7 = _0023_003DzYXH_FvCAxK3o[k];
			int numberOfNodes = _0023_003DzGGJSiQk_003D.Elements[num7 - 1].NumberOfNodes;
			for (int l = 0; l < numberOfNodes; l++)
			{
				int num8 = _0023_003DznpS3HRUO_0024Jao[num7 - 1 + l * num5] - 1;
				if (array2[num8] != 'F')
				{
					array[num7 - num3] += num6;
					array2[num8] = 'F';
				}
			}
		}
		for (int k = 1; k <= num4; k++)
		{
			int num9 = num4 - k + 1;
			int num10 = _0023_003DzYXH_FvCAxK3o[num9 - 1];
			int numberOfNodes = _0023_003DzGGJSiQk_003D.Elements[num10 - 1].NumberOfNodes;
			for (int l = 0; l < numberOfNodes; l++)
			{
				int num8 = _0023_003DznpS3HRUO_0024Jao[num10 - 1 + l * num5] - 1;
				if (array2[num8] != 'L')
				{
					if (num9 < num4)
					{
						array[_0023_003DzYXH_FvCAxK3o[num9] - num3] = array[_0023_003DzYXH_FvCAxK3o[num9] - num3] - num6;
					}
					array2[num8] = 'L';
				}
			}
		}
		int num11 = 0;
		int num12 = 0;
		for (int l = 0; l < num4; l++)
		{
			int num13 = _0023_003DzYXH_FvCAxK3o[l];
			num12 += array[num13 - num3];
			if (num12 > num11)
			{
				num11 = num12;
			}
		}
		num12 = num11;
		_0023_003DzlO7zf3TwjOHb = num11;
	}

	private void _0023_003DzUWazFZpAf9c6(int[] _0023_003DznpS3HRUO_0024Jao, int[] _0023_003DzYXH_FvCAxK3o, ref int _0023_003DzlO7zf3TwjOHb)
	{
		int num = 0;
		int num2 = 1;
		int num3 = femMesh.Elements.Length;
		int num4 = num3;
		int num5 = 1;
		int num6 = 1;
		int num7 = 1;
		int num8 = num3;
		int[] array = new int[(num4 - num2 + 1) * (150 - num5 + 1)];
		int[] array2 = new int[num3 - num6 + 1];
		double[] array3 = new double[num8 - num7 + 1];
		int num9 = 1;
		int num10 = 1;
		int num11 = num3;
		int[] array4 = new int[num3 - num9 + 1];
		int[] array5 = new int[num11 - num10 + 1];
		int num12 = 1;
		int num13 = femMesh.Vertices.Length;
		int num14 = num13;
		int num15 = 1;
		int num16 = 1;
		int[] array6 = new int[(num14 - num12 + 1) * (150 - num15 + 1)];
		int[] array7 = new int[num13 - num16 + 1];
		int num17 = 0;
		for (int i = 1; i <= num3; i++)
		{
			array5[i - num10] = _0023_003DzYXH_FvCAxK3o[i - 1];
			for (int j = 1; j <= 150; j++)
			{
				array[i - num2 + (j - num5) * (num4 - num2 + 1)] = 0;
			}
		}
		int num18 = 0;
		int num19 = 1;
		int _0023_003Dztql_0024_6Zg4m2E;
		while (num17 != 5)
		{
			num18++;
			for (int i = 1; i <= num3; i++)
			{
				for (int j = 1; j <= 150; j++)
				{
					array[i - num2 + (j - num5) * (num4 - num2 + 1)] = 0;
				}
			}
			for (int i = 1; i <= num13; i++)
			{
				array7[i - num16] = 0;
				for (int j = 1; j <= 150; j++)
				{
					array6[i - num12 + (j - num15) * (num14 - num12 + 1)] = 0;
				}
			}
			for (int i = 1; i <= num3; i++)
			{
				int num20 = _0023_003DzYXH_FvCAxK3o[i - 1];
				int numberOfNodes = femMesh.Elements[num20 - 1].NumberOfNodes;
				for (int j = 1; j <= numberOfNodes; j++)
				{
					int num21 = _0023_003DznpS3HRUO_0024Jao[num20 - 1 + (j - 1) * num3];
					if (num21 != 0)
					{
						array7[num21 - num16]++;
						array6[num21 - num12 + (array7[num21 - num16] - num15) * (num14 - num12 + 1)] = i;
					}
				}
			}
			for (int i = 1; i <= num3; i++)
			{
				int num20 = _0023_003DzYXH_FvCAxK3o[i - 1];
				int numberOfNodes = femMesh.Elements[num20 - 1].NumberOfNodes;
				for (int j = 1; j <= numberOfNodes; j++)
				{
					int num21 = _0023_003DznpS3HRUO_0024Jao[num20 - 1 + (j - 1) * num3];
					for (int k = 1; k <= 150; k++)
					{
						int num22 = array6[num21 - num12 + (k - num15) * (num14 - num12 + 1)];
						if (num22 > 0)
						{
							int num23 = 1;
							for (int l = 1; l <= 150; l++)
							{
								if (array[i - num2 + (l - num5) * (num4 - num2 + 1)] == 0)
								{
									num = l;
									break;
								}
								if (array[i - num2 + (l - num5) * (num4 - num2 + 1)] == num22)
								{
									num23 = 0;
									break;
								}
							}
							if (num23 == 1)
							{
								array[i - num2 + (num - num5) * (num4 - num2 + 1)] = num22;
							}
						}
						if (num22 == 0)
						{
							break;
						}
					}
				}
			}
			for (int i = 1; i <= num3; i++)
			{
				int num24 = 999999;
				int num25 = 0;
				int num26 = 0;
				int num27 = 0;
				for (int k = 1; k <= 150 && array[i - num2 + (k - num5) * (num4 - num2 + 1)] != 0; k++)
				{
					num27++;
					if (array[i - num2 + (k - num5) * (num4 - num2 + 1)] < num24)
					{
						num24 = array[i - num2 + (k - num5) * (num4 - num2 + 1)];
					}
					if (array[i - num2 + (k - num5) * (num4 - num2 + 1)] > num25)
					{
						num25 = array[i - num2 + (k - num5) * (num4 - num2 + 1)];
					}
					num26 += array[i - num2 + (k - num5) * (num4 - num2 + 1)];
				}
				array2[i - num6] = num25 + num24;
				array4[i - num9] = num26;
				array3[i - num7] = (double)array4[i - num9] / (double)num27;
			}
			int _0023_003Dzx_QhTl6_4wNs;
			if (num19 == 1)
			{
				_0023_003Dz2Gn7hfK4yhkU(_0023_003DzYXH_FvCAxK3o, array2, array3, num3, out _0023_003Dzx_QhTl6_4wNs);
				if (_0023_003Dzx_QhTl6_4wNs == 0)
				{
					num19 = 0;
				}
			}
			else
			{
				_0023_003DzHisFYLhG5XPE(_0023_003DzYXH_FvCAxK3o, array4, array3, num3, out _0023_003Dzx_QhTl6_4wNs);
				if (_0023_003Dzx_QhTl6_4wNs == 0)
				{
					break;
				}
			}
			_0023_003DzpMuYgsMqnlKe(_0023_003DznpS3HRUO_0024Jao, _0023_003DzYXH_FvCAxK3o, out _0023_003Dztql_0024_6Zg4m2E);
			if (_0023_003Dztql_0024_6Zg4m2E >= _0023_003DzlO7zf3TwjOHb)
			{
				num17++;
			}
			if (_0023_003Dztql_0024_6Zg4m2E < _0023_003DzlO7zf3TwjOHb)
			{
				num17 = 0;
				_0023_003DzlO7zf3TwjOHb = _0023_003Dztql_0024_6Zg4m2E;
				for (int m = 1; m <= num3; m++)
				{
					array5[m - num10] = _0023_003DzYXH_FvCAxK3o[m - 1];
				}
			}
		}
		for (int m = 1; m <= num3; m++)
		{
			_0023_003DzYXH_FvCAxK3o[m - 1] = array5[m - num10];
		}
		_0023_003DzpMuYgsMqnlKe(_0023_003DznpS3HRUO_0024Jao, _0023_003DzYXH_FvCAxK3o, out _0023_003Dztql_0024_6Zg4m2E);
	}

	private void _0023_003Dz2Gn7hfK4yhkU(int[] _0023_003Dzm9yP7rA_003D, int[] _0023_003DznBfvgzY_003D, double[] _0023_003Dz6NjNXSFq5ADt, int _0023_003DzwwGJhWE460WM, out int _0023_003Dzx_QhTl6_4wNs)
	{
		_0023_003Dzx_QhTl6_4wNs = 0;
		int num = (int)(Math.Log(_0023_003DzwwGJhWE460WM) * 1.4426950216293335 + 1E-05);
		int num2 = _0023_003DzwwGJhWE460WM;
		for (int i = 1; i <= num; i++)
		{
			num2 /= 2;
			int num3 = _0023_003DzwwGJhWE460WM - num2;
			for (int j = 1; j <= num3; j++)
			{
				int num4 = j;
				do
				{
					int num5 = num4 + num2;
					if (_0023_003DznBfvgzY_003D[num5 - 1] >= _0023_003DznBfvgzY_003D[num4 - 1] && (_0023_003DznBfvgzY_003D[num5 - 1] != _0023_003DznBfvgzY_003D[num4 - 1] || !(_0023_003Dz6NjNXSFq5ADt[num5 - 1] < _0023_003Dz6NjNXSFq5ADt[num4 - 1])))
					{
						break;
					}
					_0023_003Dzx_QhTl6_4wNs++;
					int num6 = _0023_003DznBfvgzY_003D[num4 - 1];
					_0023_003DznBfvgzY_003D[num4 - 1] = _0023_003DznBfvgzY_003D[num5 - 1];
					_0023_003DznBfvgzY_003D[num5 - 1] = num6;
					num6 = _0023_003Dzm9yP7rA_003D[num4 - 1];
					_0023_003Dzm9yP7rA_003D[num4 - 1] = _0023_003Dzm9yP7rA_003D[num5 - 1];
					_0023_003Dzm9yP7rA_003D[num5 - 1] = num6;
					double num7 = _0023_003Dz6NjNXSFq5ADt[num4 - 1];
					_0023_003Dz6NjNXSFq5ADt[num4 - 1] = _0023_003Dz6NjNXSFq5ADt[num5 - 1];
					_0023_003Dz6NjNXSFq5ADt[num5 - 1] = num7;
					num4 -= num2;
				}
				while (num4 >= 1);
			}
		}
	}

	private void _0023_003DzHisFYLhG5XPE(int[] _0023_003Dzm9yP7rA_003D, int[] _0023_003DznBfvgzY_003D, double[] _0023_003Dz6NjNXSFq5ADt, int _0023_003DzwwGJhWE460WM, out int _0023_003Dzx_QhTl6_4wNs)
	{
		_0023_003Dzx_QhTl6_4wNs = 0;
		int num = (int)(Math.Log(_0023_003DzwwGJhWE460WM) * 1.4426950216293335 + 1E-05);
		int num2 = _0023_003DzwwGJhWE460WM;
		for (int i = 1; i <= num; i++)
		{
			num2 /= 2;
			int num3 = _0023_003DzwwGJhWE460WM - num2;
			for (int j = 1; j <= num3; j++)
			{
				int num4 = j;
				do
				{
					int num5 = num4 + num2;
					if (!(_0023_003Dz6NjNXSFq5ADt[num5 - 1] < _0023_003Dz6NjNXSFq5ADt[num4 - 1]) && (!(Math.Abs(_0023_003Dz6NjNXSFq5ADt[num5 - 1] - _0023_003Dz6NjNXSFq5ADt[num4 - 1]) < 1E-06) || _0023_003DznBfvgzY_003D[num5 - 1] >= _0023_003DznBfvgzY_003D[num4 - 1]))
					{
						break;
					}
					_0023_003Dzx_QhTl6_4wNs++;
					int num6 = _0023_003DznBfvgzY_003D[num4 - 1];
					_0023_003DznBfvgzY_003D[num4 - 1] = _0023_003DznBfvgzY_003D[num5 - 1];
					_0023_003DznBfvgzY_003D[num5 - 1] = num6;
					num6 = _0023_003Dzm9yP7rA_003D[num4 - 1];
					_0023_003Dzm9yP7rA_003D[num4 - 1] = _0023_003Dzm9yP7rA_003D[num5 - 1];
					_0023_003Dzm9yP7rA_003D[num5 - 1] = num6;
					double num7 = _0023_003Dz6NjNXSFq5ADt[num4 - 1];
					_0023_003Dz6NjNXSFq5ADt[num4 - 1] = _0023_003Dz6NjNXSFq5ADt[num5 - 1];
					_0023_003Dz6NjNXSFq5ADt[num5 - 1] = num7;
					num4 -= num2;
				}
				while (num4 >= 1);
			}
		}
	}
}
