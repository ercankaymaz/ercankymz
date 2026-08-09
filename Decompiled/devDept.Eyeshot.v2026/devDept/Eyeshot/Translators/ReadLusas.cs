using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Fem;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class ReadLusas : ReadFileAsync
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int[,] _0023_003DzjJfp4TX_00246Ai5;

	public override supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.Unitless;

	public ReadLusas(string filePath)
		: base(filePath)
	{
	}

	public ReadLusas(Stream stream)
		: base(stream)
	{
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		byte b = 4;
		object[] array = null;
		array = new object[3] { b, this, flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "$N9u(q\"acA", array);
		_0023_003DzMz4XYJCbCYCd(progress, ct);
	}

	private void _0023_003DzMz4XYJCbCYCd(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		List<devDept.Geometry.Rotation> list = null;
		char[] value = new char[84]
		{
			'Q', 'P', 'M', '4', 'Q', 'P', 'M', '8', 'T', 'P',
			'M', '3', 'T', 'P', 'M', '6', 'Q', 'P', 'N', '8',
			'T', 'P', 'N', '6', 'Q', 'A', 'X', '8', 'T', 'A',
			'X', '6', 'T', 'H', '1', '0', 'P', 'N', '1', '5',
			'H', 'X', '2', '0', 'H', 'X', '8', 'M', 'T', 'H',
			'4', ' ', 'P', 'N', '6', ' ', 'Q', 'P', 'N', '4',
			'T', 'P', 'N', '3', 'Q', 'A', 'X', '4', 'T', 'A',
			'X', '3', 'J', 'N', 'T', '3', 'J', 'A', 'X', '3',
			'J', 'N', 'T', '4'
		};
		int[,] array = new int[6, 21]
		{
			{
				4, 8, 3, 6, 8, 6, 8, 6, 10, 15,
				20, 8, 4, 6, 4, 3, 4, 3, 2, 2,
				2
			},
			{
				2, 2, 2, 2, 2, 2, 2, 2, 3, 3,
				3, 3, 3, 3, 2, 2, 2, 2, 2, 2,
				3
			},
			{
				4, 4, 1, 3, 4, 3, 4, 3, 4, 6,
				8, 8, 1, 6, 4, 1, 4, 1, 0, 0,
				0
			},
			{
				2, 2, 2, 2, 2, 2, 2, 2, 3, 3,
				3, 3, 3, 3, 2, 2, 2, 2, 2, 2,
				3
			},
			{
				3, 3, 3, 3, 3, 3, 4, 4, 6, 6,
				6, 6, 6, 6, 3, 3, 4, 4, 0, 0,
				0
			},
			{
				2, 2, 2, 2, 1, 1, 3, 3, 4, 4,
				4, 4, 4, 4, 1, 1, 3, 3, 0, 0,
				0
			}
		};
		string text = null;
		bool result = false;
		TextReader textReader = new StreamReader(base.Stream, Encoding.ASCII);
		try
		{
			FemMesh femMesh = new FemMesh(0, 0);
			try
			{
				int num = 0;
				int num2 = 0;
				int num3 = 1;
				int num4 = 0;
				int num5 = 0;
				int num6 = 0;
				int num7 = 0;
				int num8 = 0;
				int num9 = 0;
				int num10 = 0;
				int num11 = 0;
				int num12 = 0;
				int num13 = 0;
				int num14;
				int num15;
				while (num3 > -1)
				{
					text = textReader.ReadLine();
					num3 = text.IndexOf('C');
					num14 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009729));
					if (num14 > -1)
					{
						string[] array2 = text.Split('=');
						num = int.Parse(array2[1]);
						femMesh.Vertices = new Point3D[num];
					}
					num15 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009713));
					if (num15 > -1)
					{
						string[] array2 = text.Split('=');
						int num16 = int.Parse(array2[1]);
						if (num16 > 0)
						{
							num2 = num16;
							femMesh.Elements = new Element[num2];
							for (int i = 0; i < 21; i++)
							{
								string value2 = new string(value, i * 4, 4);
								if (text.IndexOf(value2) > 0)
								{
									if (array[0, i] > num6)
									{
										num6 = array[0, i];
									}
									if (array[1, i] > num7)
									{
										num7 = array[1, i];
									}
									if (array[2, i] > num8)
									{
										num8 = array[2, i];
									}
									if (array[3, i] > num4)
									{
										num4 = array[3, i];
									}
									if (array[4, i] > num9)
									{
										num9 = array[4, i];
									}
									num5 = array[5, i];
									break;
								}
							}
						}
					}
					if (text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009698)) > -1)
					{
						string[] array2 = text.Split('=');
						num10 = int.Parse(array2[1]);
					}
					if (text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009711)) > 0)
					{
						string[] array2 = text.Split('=');
						num13 = int.Parse(array2[1]);
						list = new List<devDept.Geometry.Rotation>(num13);
					}
					if (text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009670)) > -1)
					{
						string[] array2 = text.Split('=');
						num11 = int.Parse(array2[1]);
					}
					if (text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009398)) > 0)
					{
						string[] array2 = text.Split('=');
						num12 = int.Parse(array2[1]);
					}
				}
				Material material = new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984991));
				List<int[]> list2 = new List<int[]>();
				int num17 = 0;
				int num18 = -1;
				int num19 = 100;
				int num20 = 0;
				while (num18 == -1)
				{
					num18 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009380));
					if (num18 == -1)
					{
						num17 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009364));
						if (num17 > -1)
						{
							for (int j = 1; j <= 21; j++)
							{
								string value3 = new string(value, (j - 1) * 4, 4);
								if (text.IndexOf(value3) > -1)
								{
									num19 = array[0, j - 1];
									num20 = j;
									break;
								}
							}
							num17 = 0;
							text = textReader.ReadLine();
						}
						if (num19 != 100)
						{
							if (num20 == 19 || num20 == 20)
							{
								string[] array2 = text.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
								list2.Add(new int[4]
								{
									int.Parse(array2[0]) - 1,
									int.Parse(array2[1]) - 1,
									int.Parse(array2[2]) - 1,
									int.Parse(array2[3]) - 1
								});
							}
							if (num20 == 21)
							{
								string[] array2 = text.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
								list2.Add(new int[5]
								{
									int.Parse(array2[0]) - 1,
									int.Parse(array2[1]) - 1,
									int.Parse(array2[2]) - 1,
									int.Parse(array2[3]) - 1,
									int.Parse(array2[4]) - 1
								});
							}
						}
						if (num19 < 9 && num20 < 19)
						{
							string[] array2 = text.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
							switch (num20)
							{
							case 13:
								femMesh.Elements[int.Parse(array2[0]) - 1] = new Tetra4(int.Parse(array2[1]) - 1, int.Parse(array2[2]) - 1, int.Parse(array2[3]) - 1, int.Parse(array2[4]) - 1, material);
								break;
							case 14:
								femMesh.Elements[int.Parse(array2[0]) - 1] = new Penta6(int.Parse(array2[1]) - 1, int.Parse(array2[2]) - 1, int.Parse(array2[3]) - 1, int.Parse(array2[4]) - 1, int.Parse(array2[5]) - 1, int.Parse(array2[6]) - 1, material);
								break;
							case 15:
								material.ElementType = elementType.PlaneStrain;
								femMesh.Elements[int.Parse(array2[0]) - 1] = new Quad4(int.Parse(array2[1]) - 1, int.Parse(array2[2]) - 1, int.Parse(array2[3]) - 1, int.Parse(array2[4]) - 1, material);
								break;
							case 1:
								material.ElementType = elementType.PlaneStress;
								femMesh.Elements[int.Parse(array2[0]) - 1] = new Quad4(int.Parse(array2[1]) - 1, int.Parse(array2[2]) - 1, int.Parse(array2[3]) - 1, int.Parse(array2[4]) - 1, material);
								break;
							case 17:
								material.ElementType = elementType.Axisymmetric;
								femMesh.Elements[int.Parse(array2[0]) - 1] = new Quad4(int.Parse(array2[1]) - 1, int.Parse(array2[2]) - 1, int.Parse(array2[3]) - 1, int.Parse(array2[4]) - 1, material);
								break;
							case 2:
								material.ElementType = elementType.PlaneStress;
								femMesh.Elements[int.Parse(array2[0]) - 1] = new Quad8(int.Parse(array2[1]) - 1, int.Parse(array2[2]) - 1, int.Parse(array2[3]) - 1, int.Parse(array2[4]) - 1, int.Parse(array2[5]) - 1, int.Parse(array2[6]) - 1, int.Parse(array2[7]) - 1, int.Parse(array2[8]) - 1, material);
								break;
							case 12:
								femMesh.Elements[int.Parse(array2[0]) - 1] = new Hexa8(int.Parse(array2[1]) - 1, int.Parse(array2[2]) - 1, int.Parse(array2[3]) - 1, int.Parse(array2[4]) - 1, int.Parse(array2[5]) - 1, int.Parse(array2[6]) - 1, int.Parse(array2[7]) - 1, int.Parse(array2[8]) - 1, material);
								break;
							case 5:
								material.ElementType = elementType.PlaneStrain;
								femMesh.Elements[int.Parse(array2[0]) - 1] = new Quad8(int.Parse(array2[1]) - 1, int.Parse(array2[2]) - 1, int.Parse(array2[3]) - 1, int.Parse(array2[4]) - 1, int.Parse(array2[5]) - 1, int.Parse(array2[6]) - 1, int.Parse(array2[7]) - 1, int.Parse(array2[8]) - 1, material);
								break;
							case 7:
								material.ElementType = elementType.Axisymmetric;
								femMesh.Elements[int.Parse(array2[0]) - 1] = new Quad8(int.Parse(array2[1]) - 1, int.Parse(array2[2]) - 1, int.Parse(array2[3]) - 1, int.Parse(array2[4]) - 1, int.Parse(array2[5]) - 1, int.Parse(array2[6]) - 1, int.Parse(array2[7]) - 1, int.Parse(array2[8]) - 1, material);
								break;
							case 4:
								material.ElementType = elementType.PlaneStress;
								femMesh.Elements[int.Parse(array2[0]) - 1] = new Tria6(int.Parse(array2[1]) - 1, int.Parse(array2[2]) - 1, int.Parse(array2[3]) - 1, int.Parse(array2[4]) - 1, int.Parse(array2[5]) - 1, int.Parse(array2[6]) - 1, material);
								break;
							case 6:
								material.ElementType = elementType.PlaneStrain;
								femMesh.Elements[int.Parse(array2[0]) - 1] = new Tria6(int.Parse(array2[1]) - 1, int.Parse(array2[2]) - 1, int.Parse(array2[3]) - 1, int.Parse(array2[4]) - 1, int.Parse(array2[5]) - 1, int.Parse(array2[6]) - 1, material);
								break;
							case 8:
								material.ElementType = elementType.Axisymmetric;
								femMesh.Elements[int.Parse(array2[0]) - 1] = new Tria6(int.Parse(array2[1]) - 1, int.Parse(array2[2]) - 1, int.Parse(array2[3]) - 1, int.Parse(array2[4]) - 1, int.Parse(array2[5]) - 1, int.Parse(array2[6]) - 1, material);
								break;
							case 3:
								material.ElementType = elementType.PlaneStress;
								femMesh.Elements[int.Parse(array2[0]) - 1] = new Tria3(int.Parse(array2[1]) - 1, int.Parse(array2[2]) - 1, int.Parse(array2[3]) - 1, material);
								break;
							case 16:
								material.ElementType = elementType.PlaneStrain;
								femMesh.Elements[int.Parse(array2[0]) - 1] = new Tria3(int.Parse(array2[1]) - 1, int.Parse(array2[2]) - 1, int.Parse(array2[3]) - 1, material);
								break;
							case 18:
								material.ElementType = elementType.Axisymmetric;
								femMesh.Elements[int.Parse(array2[0]) - 1] = new Tria3(int.Parse(array2[1]) - 1, int.Parse(array2[2]) - 1, int.Parse(array2[3]) - 1, material);
								break;
							}
						}
						if (num19 == 20)
						{
							string[] array2 = text.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
							text = textReader.ReadLine();
							string[] array3 = text.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
							if (num20 == 11)
							{
								femMesh.Elements[int.Parse(array2[0]) - 1] = new Hexa20(int.Parse(array2[1]) - 1, int.Parse(array2[2]) - 1, int.Parse(array2[3]) - 1, int.Parse(array2[4]) - 1, int.Parse(array2[5]) - 1, int.Parse(array2[6]) - 1, int.Parse(array2[7]) - 1, int.Parse(array2[8]) - 1, int.Parse(array2[9]) - 1, int.Parse(array2[10]) - 1, int.Parse(array3[0]) - 1, int.Parse(array3[1]) - 1, int.Parse(array3[2]) - 1, int.Parse(array3[3]) - 1, int.Parse(array3[4]) - 1, int.Parse(array3[5]) - 1, int.Parse(array3[6]) - 1, int.Parse(array3[7]) - 1, int.Parse(array3[8]) - 1, int.Parse(array3[9]) - 1, material);
							}
						}
						if (num19 == 10)
						{
							string[] array2 = text.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
							femMesh.Elements[int.Parse(array2[0]) - 1] = new Tetra10(int.Parse(array2[1]) - 1, int.Parse(array2[2]) - 1, int.Parse(array2[3]) - 1, int.Parse(array2[4]) - 1, int.Parse(array2[5]) - 1, int.Parse(array2[6]) - 1, int.Parse(array2[7]) - 1, int.Parse(array2[8]) - 1, int.Parse(array2[9]) - 1, int.Parse(array2[10]) - 1, material);
						}
						if (num19 == 15)
						{
							string[] array2 = text.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
							text = textReader.ReadLine();
							string[] array4 = text.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
							femMesh.Elements[int.Parse(array2[0]) - 1] = new Penta15(int.Parse(array2[1]) - 1, int.Parse(array2[2]) - 1, int.Parse(array2[3]) - 1, int.Parse(array2[4]) - 1, int.Parse(array2[5]) - 1, int.Parse(array2[6]) - 1, int.Parse(array2[7]) - 1, int.Parse(array2[8]) - 1, int.Parse(array2[9]) - 1, int.Parse(array2[10]) - 1, int.Parse(array4[0]) - 1, int.Parse(array4[1]) - 1, int.Parse(array4[2]) - 1, int.Parse(array4[3]) - 1, int.Parse(array4[4]) - 1, material);
						}
					}
					text = textReader.ReadLine();
				}
				for (num17 = -1; num17 == -1; num17 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009345)))
				{
					text = textReader.ReadLine();
				}
				for (int k = 1; k <= num; k++)
				{
					text = textReader.ReadLine();
					string[] array2 = text.Split(new char[1] { ' ' }, 1 + num4 + 1, StringSplitOptions.RemoveEmptyEntries);
					switch (num4)
					{
					case 2:
						femMesh.Vertices[int.Parse(array2[0]) - 1] = new Node(Utility.DoubleParse(array2[1]), Utility.DoubleParse(array2[2]));
						break;
					case 3:
						femMesh.Vertices[int.Parse(array2[0]) - 1] = new Node(Utility.DoubleParse(array2[1]), Utility.DoubleParse(array2[2]), Utility.DoubleParse(array2[3]));
						break;
					}
				}
				foreach (int[] item in list2)
				{
					if (item.Length == 4)
					{
						femMesh.Elements[item[0]] = new Joint2D(item[1], item[2], new devDept.Geometry.Rotation(item[1], item[3], femMesh.Vertices), new double[2]);
					}
					else
					{
						femMesh.Elements[item[0]] = new Joint3D(item[1], item[2], new devDept.Geometry.Rotation(item[1], item[3], item[4], femMesh.Vertices), new double[3]);
					}
				}
				double num21 = 0.0;
				int num22 = -1;
				int num23 = -1;
				while (num22 == -1 && num23 == -1)
				{
					text = textReader.ReadLine();
					num22 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009330));
					num23 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009314));
				}
				double[,] array5 = new double[4, 110];
				int[] array6;
				if (num22 != -1)
				{
					int num24 = -1;
					while (num24 == -1)
					{
						if (num22 > -1)
						{
							text = textReader.ReadLine();
							num24 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009327));
							if (num24 == -1)
							{
								string[] array2 = text.Split(new char[1] { ' ' }, 4, StringSplitOptions.RemoveEmptyEntries);
								int num25 = int.Parse(array2[0]);
								num21 = (array5[2, num25 - 1] = Utility.DoubleParse(array2[1]));
							}
						}
					}
					int num26 = -1;
					array6 = null;
					while (num26 == -1)
					{
						text = textReader.ReadLine();
						num26 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009314));
						if (num26 == -1)
						{
							string[] array2 = text.Split(new char[1] { ' ' }, 4, StringSplitOptions.RemoveEmptyEntries);
							int num27 = int.Parse(array2[0]);
							int num28 = int.Parse(array2[1]);
							int num29 = int.Parse(array2[2]);
							int num30 = int.Parse(array2[3]);
							array6 = new int[num28];
							for (int l = num27 - 1; l < num28; l += num29)
							{
								array6[l] = num30;
							}
						}
					}
				}
				for (int m = 1; m <= num10; m++)
				{
					text = textReader.ReadLine();
					string[] array2 = text.Split(new char[1] { ' ' }, 5, StringSplitOptions.RemoveEmptyEntries);
					int num31 = int.Parse(array2[0]);
					array5[num31 - 1, 0] = Utility.DoubleParse(array2[1]);
					array5[num31 - 1, 1] = Utility.DoubleParse(array2[2]);
					array5[num31 - 1, 2] = Utility.DoubleParse(array2[3]);
					array5[num31 - 1, 3] = Utility.DoubleParse(array2[4]);
					if (num5 == 2)
					{
						array5[num31 - 1, 50] = num21;
					}
				}
				int num32 = 0;
				text = textReader.ReadLine();
				num17 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009281));
				if (num17 != -1)
				{
					for (int n = 1; n <= num12; n++)
					{
						text = textReader.ReadLine();
						string[] array2 = text.Split(new char[1] { ' ' }, 4, StringSplitOptions.RemoveEmptyEntries);
						num32 = int.Parse(array2[0]);
						if (num4 == 2)
						{
							double num33 = Utility.DoubleParse(array2[1]);
							double num34 = Utility.DoubleParse(array2[2]);
							array5[num32 - 1, 0] = num33;
							array5[num32 - 1, 1] = num34;
						}
						else
						{
							double num33 = Utility.DoubleParse(array2[1]);
							double num34 = Utility.DoubleParse(array2[2]);
							double num35 = Utility.DoubleParse(array2[3]);
							array5[num32 - 1, 0] = num33;
							array5[num32 - 1, 1] = num34;
							array5[num32 - 1, 2] = num35;
						}
					}
				}
				num17 = -1;
				while (num17 == -1)
				{
					num17 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009327));
					text = textReader.ReadLine();
				}
				int num36 = 0;
				array6 = null;
				num14 = -1;
				num15 = -1;
				while (num14 == -1 && num15 == -1)
				{
					num14 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009293));
					num15 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009530));
					if (num14 != -1 || num15 != -1)
					{
						continue;
					}
					string[] array2 = text.Split(new char[1] { ' ' }, 4, StringSplitOptions.RemoveEmptyEntries);
					int num37 = int.Parse(array2[0]);
					num36 = int.Parse(array2[1]);
					int num38 = int.Parse(array2[2]);
					int num39 = int.Parse(array2[3]);
					for (int num40 = num37 - 1; num40 < num36; num40 += num38)
					{
						Element element = femMesh.Elements[num40];
						if (!(element is Joint2D))
						{
							element.Material = new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984991), Color.Gray, array5[num39 - 1, 0], array5[num39 - 1, 1], 0.0, array5[num39 - 1, 2], array5[num39 - 1, 3]);
							if (element is Element2D)
							{
								Element2D obj = (Element2D)element;
								obj.Material.ElementType = material.ElementType;
								obj.Material.ElementThickness = array5[num39 - 1, 50];
							}
						}
					}
					for (int num41 = num37 - 1; num41 < num36; num41 += num38)
					{
						Element element2 = femMesh.Elements[num41];
						if (element2 is Joint2D)
						{
							if (element2 is Joint3D)
							{
								((Joint3D)element2).Stiffness = new double[3]
								{
									array5[num39 - 1, 0],
									array5[num39 - 1, 1],
									array5[num39 - 1, 2]
								};
							}
							else
							{
								((Joint2D)element2).Stiffness = new double[2]
								{
									array5[num39 - 1, 0],
									array5[num39 - 1, 1]
								};
							}
						}
					}
					text = textReader.ReadLine();
				}
				_0023_003DzjJfp4TX_00246Ai5 = new int[num4, 1];
				if (num13 > 0)
				{
					num17 = -1;
					while (num17 == -1)
					{
						num17 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009507));
						text = textReader.ReadLine();
					}
					for (int num42 = 1; num42 <= num13; num42++)
					{
						if (num4 == 2)
						{
							string[] array2 = text.Split(new char[1] { ' ' }, 3, StringSplitOptions.RemoveEmptyEntries);
							list.Add(new devDept.Geometry.Rotation(int.Parse(array2[1]) - 1, int.Parse(array2[2]) - 1, femMesh.Vertices));
						}
						else
						{
							string[] array2 = text.Split(new char[1] { ' ' }, 4, StringSplitOptions.RemoveEmptyEntries);
							list.Add(new devDept.Geometry.Rotation(int.Parse(array2[1]) - 1, int.Parse(array2[2]) - 1, int.Parse(array2[3]) - 1, femMesh.Vertices));
						}
						text = textReader.ReadLine();
					}
					num17 = -1;
					while (num17 == -1)
					{
						num17 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009491));
						text = textReader.ReadLine();
					}
					num17 = -1;
					while (num17 == -1)
					{
						num17 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009477));
						if (num17 != -1)
						{
							continue;
						}
						string[] array2 = text.Split(new char[1] { ' ' }, 4, StringSplitOptions.RemoveEmptyEntries);
						int num43 = int.Parse(array2[0]);
						int num44 = int.Parse(array2[1]);
						int num45 = int.Parse(array2[2]);
						int num46 = int.Parse(array2[3]);
						if (num44 > 0)
						{
							for (int num47 = num43 - 1; num47 < num44; num47 += num45)
							{
								((Node)femMesh.Vertices[num47]).Rotation = list[num46 - 1];
							}
						}
						else
						{
							((Node)femMesh.Vertices[num43 - 1]).Rotation = list[num46 - 1];
						}
						text = textReader.ReadLine();
					}
				}
				num17 = -1;
				while (num17 == -1)
				{
					num17 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009477));
					text = textReader.ReadLine();
				}
				int num48 = 1;
				if (num4 != 2)
				{
					if (num4 == 3)
					{
						while (num48 <= num11)
						{
							for (int num49 = 1; num49 <= 3; num49++)
							{
								num14 = text.IndexOf('S');
								if (num14 > -1)
								{
									text = text.Replace('S', '2');
								}
								num14 = text.IndexOf('R');
								if (num14 > -1)
								{
									text = text.Replace('R', '1');
								}
								num14 = text.IndexOf('F');
								if (num14 > -1)
								{
									text = text.Replace('F', '0');
								}
							}
							string[] array2 = text.Split(new char[1] { ' ' }, 9, StringSplitOptions.RemoveEmptyEntries);
							int num50 = int.Parse(array2[0]);
							int num51 = int.Parse(array2[1]);
							int num52 = int.Parse(array2[2]);
							int num53 = int.Parse(array2[3]);
							int num54 = int.Parse(array2[4]);
							int num55 = int.Parse(array2[5]);
							double amountInX = Utility.DoubleParse(array2[6]);
							double amountInY = Utility.DoubleParse(array2[7]);
							double amountInZ = Utility.DoubleParse(array2[8]);
							if (num51 > 0)
							{
								for (int num56 = num50; num56 <= num51; num56 += num52)
								{
									((Node)femMesh.Vertices[num56 - 1]).SetRestraint(num53 == 1, num54 == 1, num55 == 1, amountInX, amountInY, amountInZ);
									num48++;
								}
							}
							else
							{
								((Node)femMesh.Vertices[num50 - 1]).SetRestraint(num53 == 1, num54 == 1, num55 == 1, amountInX, amountInY, amountInZ);
								num48++;
							}
							text = textReader.ReadLine();
						}
					}
				}
				else
				{
					while (num48 <= num11)
					{
						for (int num57 = 1; num57 <= 2; num57++)
						{
							num14 = text.IndexOf('S');
							if (num14 > -1)
							{
								text = text.Replace('S', '2');
							}
							num14 = text.IndexOf('R');
							if (num14 > -1)
							{
								text = text.Replace('R', '1');
							}
							num14 = text.IndexOf('F');
							if (num14 > -1)
							{
								text = text.Replace('F', '0');
							}
						}
						string[] array2 = text.Split(new char[1] { ' ' }, 7, StringSplitOptions.RemoveEmptyEntries);
						int num58 = int.Parse(array2[0]);
						int num59 = int.Parse(array2[1]);
						int num60 = int.Parse(array2[2]);
						int num61 = int.Parse(array2[3]);
						int num62 = int.Parse(array2[4]);
						double amountInX2 = Utility.DoubleParse(array2[5]);
						double amountInY2 = Utility.DoubleParse(array2[6]);
						if (num59 > 0)
						{
							for (int num63 = num58; num63 <= num59; num63 += num60)
							{
								((Node)femMesh.Vertices[num63 - 1]).SetRestraint(num61 == 1, num62 == 1, amountInX2, amountInY2);
								num48++;
							}
						}
						else
						{
							((Node)femMesh.Vertices[num58 - 1]).SetRestraint(num61 == 1, num62 == 1, amountInX2, amountInY2);
							num48++;
						}
						text = textReader.ReadLine();
					}
				}
				num17 = -1;
				num14 = -1;
				int num64 = -1;
				bool flag = false;
				while (num14 == -1 && num64 == -1)
				{
					num17 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009459));
					num14 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009471));
					num64 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009449));
					if (text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009428)) > -1 && num17 == -1)
					{
						flag = true;
						break;
					}
					text = textReader.ReadLine();
				}
				if (num64 > -1)
				{
					num14 = -1;
					num15 = -1;
					int num65 = -1;
					int num66 = -1;
					while (num14 == -1 && num15 == -1 && num65 == -1 && num66 == -1)
					{
						num14 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009437));
						num15 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009415));
						num65 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010164));
						num66 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009428));
						if (num66 != -1)
						{
							flag = true;
						}
						if (num14 == -1 && num15 == -1 && num65 == -1 && num66 == -1)
						{
							int num67 = 0;
							double num68 = 0.0;
							double num69 = 0.0;
							double num70 = 0.0;
							switch (num4)
							{
							case 2:
							{
								string[] array2 = text.Split(new char[1] { ' ' }, 5, StringSplitOptions.RemoveEmptyEntries);
								num67 = int.Parse(array2[0]);
								num68 = Utility.DoubleParse(array2[3]);
								num69 = Utility.DoubleParse(array2[4]);
								((Node)femMesh.Vertices[num67 - 1]).SetForce(num68, num69);
								break;
							}
							case 3:
							{
								string[] array2 = text.Split(new char[1] { ' ' }, 6, StringSplitOptions.RemoveEmptyEntries);
								num67 = int.Parse(array2[0]);
								num68 = Utility.DoubleParse(array2[3]);
								num69 = Utility.DoubleParse(array2[4]);
								num70 = Utility.DoubleParse(array2[5]);
								((Node)femMesh.Vertices[num67 - 1]).SetForce(num68, num69, num70);
								break;
							}
							}
							text = textReader.ReadLine();
						}
					}
				}
				if (flag)
				{
					int num71 = -1;
					int num72 = -1;
					while (num71 == -1 && num72 == -1)
					{
						text = textReader.ReadLine();
						int num73 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009428));
						num71 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009437));
						num72 = text.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009415));
						if (num71 != -1 || num72 != -1 || num73 != -1)
						{
							continue;
						}
						string[] array2 = text.Split(new char[1] { ' ' }, 6, StringSplitOptions.RemoveEmptyEntries);
						int num27 = int.Parse(array2[0]);
						int num74 = int.Parse(array2[1]);
						int num75 = int.Parse(array2[2]);
						double temperature = Utility.DoubleParse(array2[3]);
						if (num74 == 0)
						{
							((Node)femMesh.Vertices[num27 - 1]).Temperature = temperature;
							continue;
						}
						for (int num76 = num27 - 1; num76 < num74; num76 += num75)
						{
							((Node)femMesh.Vertices[num76]).Temperature = temperature;
						}
					}
				}
				result = true;
				base.Entities.Add(femMesh);
			}
			finally
			{
				CloseStream();
			}
		}
		finally
		{
			((IDisposable)textReader).Dispose();
		}
		base.Result = result;
	}
}
