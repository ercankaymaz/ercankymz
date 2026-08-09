using System;
using System.Collections.Generic;
using ModuleWorks;
using buClass;

namespace buMW;

public class AbsRenderr : IndexedAbstractRenderer
{
	public static Dictionary<int, List<RenderedTriangle>> Triangles;

	public static Dictionary<int, List<RenderedLine>> Lines;

	public static Dictionary<int, bool> Visiblity;

	public static List<TriangleIndex> MeshTriangles;

	public static List<Pnt3D> MeshVertices;

	public static List<Triangle3D> MeshTri;

	public override void DeleteGroup(int groupId)
	{
	}

	public override void DrawLines(int groupId, RenderedLineVertex[] vertices, int[] indices)
	{
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		while (true)
		{
			Lines[groupId] = new List<RenderedLine>();
			if (false)
			{
				goto IL_010b;
			}
			int num = 0;
			goto IL_0113;
			IL_0113:
			bool flag = num <= indices.Length - 1;
			if (false)
			{
				continue;
			}
			int num2 = (flag ? 1 : 0);
			goto IL_0128;
			IL_010b:
			num2 = num;
			if (2u != 0)
			{
				num = num2 + 2;
				goto IL_0113;
			}
			goto IL_0128;
			IL_0128:
			if (num2 == 0)
			{
				break;
			}
			RenderedLine val;
			RenderedLineVertex val2;
			RenderedLineVertex val3;
			while (true)
			{
				val = new RenderedLine();
				val2 = vertices[indices[num]];
				while (uint.MaxValue != 0)
				{
					val3 = vertices[indices[num + 1]];
					if (0 == 0)
					{
						goto end_IL_014e;
					}
				}
				continue;
				end_IL_014e:
				break;
			}
			_0015_0003._007E_0090_0013(val, new RenderedVector[2]
			{
				new RenderedVector(_0013_0003._007E_008B_0013(val2).X, _0013_0003._007E_008B_0013(val2).Y, _0013_0003._007E_008B_0013(val2).Z)
				{
					Color = _0014_0003._007E_008E_0013(val2)
				},
				new RenderedVector(_0013_0003._007E_008B_0013(val3).X, _0013_0003._007E_008B_0013(val3).Y, _0013_0003._007E_008B_0013(val3).Z)
				{
					Color = _0014_0003._007E_008E_0013(val3)
				}
			});
			do
			{
				Lines[groupId].Add(val);
			}
			while (false);
			goto IL_010b;
		}
	}

	public override void DrawTriangles(int groupId, RenderedTriangleVertex[] vertices, int[] indices, VertexAttributes attributes)
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		Triangles[groupId] = new List<RenderedTriangle>();
		int num;
		if (5u != 0)
		{
			num = 0;
		}
		while (true)
		{
			int num2 = num;
			int num3 = vertices.Length;
			int num4;
			while (true)
			{
				if (num2 <= num3 - 1)
				{
					MeshVertices.Add(new Pnt3D(_0013_0003._007E_008C_0013(vertices[num]).X, _0013_0003._007E_008C_0013(vertices[num]).Y, _0013_0003._007E_008C_0013(vertices[num]).Z));
					num2 = num;
					num3 = 1;
					if (num3 != 0)
					{
						num4 = num2 + num3;
						break;
					}
					continue;
				}
				int num5 = 0;
				while (true)
				{
					if (num5 > indices.Length - 1)
					{
						return;
					}
					RenderedTriangle val;
					RenderedTriangleVertex val2;
					RenderedTriangleVertex val3;
					RenderedTriangleVertex val4;
					TriangleIndex triangleIndex;
					do
					{
						val = new RenderedTriangle();
						val2 = vertices[indices[num5]];
						val3 = vertices[indices[num5 + 1]];
						val4 = vertices[indices[num5 + 2]];
						triangleIndex = new TriangleIndex();
						triangleIndex.V1 = indices[num5];
						if (7u != 0)
						{
							triangleIndex.V2 = indices[num5 + 1];
							continue;
						}
						return;
					}
					while (2 == 0);
					triangleIndex.V3 = indices[num5 + 2];
					MeshTriangles.Add(triangleIndex);
					_0015_0003._007E_0091_0013(val, new RenderedVector[3]
					{
						new RenderedVector(_0013_0003._007E_008C_0013(val2).X, _0013_0003._007E_008C_0013(val2).Y, _0013_0003._007E_008C_0013(val2).Z)
						{
							Color = _0014_0003._007E_008F_0013(val2)
						},
						new RenderedVector(_0013_0003._007E_008C_0013(val3).X, _0013_0003._007E_008C_0013(val3).Y, _0013_0003._007E_008C_0013(val3).Z)
						{
							Color = _0014_0003._007E_008F_0013(val3)
						},
						new RenderedVector(_0013_0003._007E_008C_0013(val4).X, _0013_0003._007E_008C_0013(val4).Y, _0013_0003._007E_008C_0013(val4).Z)
						{
							Color = _0014_0003._007E_008F_0013(val4)
						}
					});
					_0015_0003._007E_0092_0013(val, new RenderedVector[3]
					{
						new RenderedVector(_0013_0003._007E_008D_0013(val2).X, _0013_0003._007E_008D_0013(val2).Y, _0013_0003._007E_008D_0013(val2).Z),
						new RenderedVector(_0013_0003._007E_008D_0013(val3).X, _0013_0003._007E_008D_0013(val3).Y, _0013_0003._007E_008D_0013(val3).Z),
						new RenderedVector(_0013_0003._007E_008D_0013(val4).X, _0013_0003._007E_008D_0013(val4).Y, _0013_0003._007E_008D_0013(val4).Z)
					});
					Triangles[groupId].Add(val);
					num4 = num5 + 3;
					if (5 == 0)
					{
						break;
					}
					num5 = num4;
				}
				break;
			}
			num = num4;
		}
	}

	public override void SetGroupVisibility(int groupId, bool isVisible)
	{
		Visiblity[groupId] = isVisible;
	}

	public static void Dr()
	{
	}

	public static void Draw()
	{
		DrawAllTriangles();
	}

	public static void DrawAllTriangles()
	{
		int num;
		if (2u != 0)
		{
			num = 0;
			MeshTri.Clear();
		}
		using Dictionary<int, List<RenderedTriangle>>.KeyCollection.Enumerator enumerator = Triangles.Keys.GetEnumerator();
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				if (3u != 0)
				{
					break;
				}
				goto IL_0046;
			}
			int current = enumerator.Current;
			goto IL_01a4;
			IL_01a4:
			int num2 = current;
			goto IL_0046;
			IL_0046:
			if (false)
			{
				goto IL_01a4;
			}
			if (false)
			{
				continue;
			}
			List<RenderedTriangle>.Enumerator enumerator2 = Triangles[current].GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					RenderedTriangle current2 = enumerator2.Current;
					double x = _0016_0003._007E_0093_0013(current2)[0].X;
					double y = _0016_0003._007E_0093_0013(current2)[0].Y;
					float z = _0016_0003._007E_0093_0013(current2)[0].Z;
					Pnt3D firstPoint;
					do
					{
						firstPoint = new Pnt3D(x, y, z);
						x = _0016_0003._007E_0093_0013(current2)[1].X;
						y = _0016_0003._007E_0093_0013(current2)[1].Y;
						z = _0016_0003._007E_0093_0013(current2)[1].Z;
					}
					while (7 == 0);
					Pnt3D secondPoint = new Pnt3D(x, y, z);
					Pnt3D thirdPoint = new Pnt3D(_0016_0003._007E_0093_0013(current2)[2].X, _0016_0003._007E_0093_0013(current2)[2].Y, _0016_0003._007E_0093_0013(current2)[2].Z);
					Triangle3D item = new Triangle3D(firstPoint, secondPoint, thirdPoint);
					MeshTri.Add(item);
					int num3 = num;
					do
					{
						num3++;
					}
					while (false);
					num = num3;
				}
			}
			finally
			{
				do
				{
					((IDisposable)enumerator2/*cast due to constrained. prefix*/).Dispose();
				}
				while (2 == 0);
			}
		}
	}

	static AbsRenderr()
	{
		do
		{
			if (8u != 0 && 5u != 0)
			{
				Triangles = new Dictionary<int, List<RenderedTriangle>>();
				Lines = new Dictionary<int, List<RenderedLine>>();
				continue;
			}
			return;
		}
		while (false);
		Visiblity = new Dictionary<int, bool>();
		if (2u != 0)
		{
			MeshTriangles = new List<TriangleIndex>();
		}
		MeshVertices = new List<Pnt3D>();
		MeshTri = new List<Triangle3D>();
	}
}
