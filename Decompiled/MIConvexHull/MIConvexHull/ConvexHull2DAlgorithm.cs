using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MIConvexHull;

internal static class ConvexHull2DAlgorithm
{
	internal static List<TVertex> Create<TVertex>(IList<TVertex> points) where TVertex : IVertex2D, new()
	{
		int count = points.Count;
		if (count == 2)
		{
			return points.ToList();
		}
		if (count < 2)
		{
			throw new ArgumentException("Cannot define the 2D convex hull for less than two points.");
		}
		double num = double.NegativeInfinity;
		int num2 = -1;
		double num3 = double.NegativeInfinity;
		int num4 = -1;
		double num5 = double.NegativeInfinity;
		int num6 = -1;
		double num7 = double.NegativeInfinity;
		int num8 = -1;
		double num9 = double.PositiveInfinity;
		int num10 = -1;
		double num11 = double.PositiveInfinity;
		int num12 = -1;
		double num13 = double.PositiveInfinity;
		int num14 = -1;
		double num15 = double.PositiveInfinity;
		int num16 = -1;
		for (int i = 0; i < count; i++)
		{
			TVertex val = points[i];
			double x = val.X;
			double y = val.Y;
			double num17 = x + y;
			double num18 = x - y;
			if (x < num9)
			{
				num10 = i;
				num9 = x;
			}
			if (y < num11)
			{
				num12 = i;
				num11 = y;
			}
			if (x > num)
			{
				num2 = i;
				num = x;
			}
			if (y > num3)
			{
				num4 = i;
				num3 = y;
			}
			if (num17 < num13)
			{
				num14 = i;
				num13 = num17;
			}
			if (num18 < num15)
			{
				num16 = i;
				num15 = num18;
			}
			if (num17 > num5)
			{
				num6 = i;
				num5 = num17;
			}
			if (num18 > num7)
			{
				num8 = i;
				num7 = num18;
			}
		}
		if (num11 == num3)
		{
			num12 = (num4 = num10);
		}
		if (num9 == num)
		{
			num10 = (num2 = num12);
		}
		List<int> list = new List<int>(new int[8] { num10, num14, num12, num8, num2, num6, num4, num16 });
		int num19 = 8;
		for (int num20 = num19 - 1; num20 >= 0; num20--)
		{
			int num21 = list[num20];
			int num22 = ((num20 == num19 - 1) ? list[0] : list[num20 + 1]);
			if (num21 == num22)
			{
				num19--;
				list.RemoveAt(num20);
			}
		}
		int[] array = list.OrderBy((int result) => result).ToArray();
		List<TVertex> list2 = new List<TVertex>();
		if (num19 == 2)
		{
			list2 = FindIntermediatePointsForLongSkinny(points, count, array[0], array[1], out var newUsedIndices);
			if (!newUsedIndices.Any())
			{
				return new List<TVertex>
				{
					points[array[0]],
					points[array[1]]
				};
			}
			newUsedIndices.Add(array[0]);
			newUsedIndices.Add(array[1]);
			array = newUsedIndices.OrderBy((int result) => result).ToArray();
			num19 = array.Length;
		}
		else
		{
			for (int num23 = num19 - 1; num23 >= 0; num23--)
			{
				TVertex item = points[list[num23]];
				TVertex val2 = points[(num23 == 0) ? list[num19 - 1] : list[num23 - 1]];
				TVertex val3 = points[(num23 == num19 - 1) ? list[0] : list[num23 + 1]];
				if ((val3.X - item.X) * (val2.Y - item.Y) + (val3.Y - item.Y) * (item.X - val2.X) > 0.0)
				{
					list2.Insert(0, item);
				}
				else
				{
					num19--;
					list.RemoveAt(num23);
				}
			}
		}
		TVertex val4 = list2[0];
		double x2 = val4.X;
		double y2 = val4.Y;
		TVertex val5 = list2[1];
		double x3 = val5.X;
		double y3 = val5.Y;
		double num24 = 0.0;
		double num25 = 0.0;
		double num26 = 0.0;
		double num27 = 0.0;
		double num28 = 0.0;
		double num29 = 0.0;
		double num30 = 0.0;
		double num31 = 0.0;
		double num32 = 0.0;
		double num33 = 0.0;
		double num34 = 0.0;
		double num35 = 0.0;
		double edgeVectorX = x3 - x2;
		double edgeVectorY = y3 - y2;
		double edgeVectorX2 = 0.0;
		double edgeVectorY2 = 0.0;
		double edgeVectorX3 = 0.0;
		double edgeVectorY3 = 0.0;
		double edgeVectorX4 = 0.0;
		double edgeVectorY4 = 0.0;
		double edgeVectorX5 = 0.0;
		double edgeVectorY5 = 0.0;
		double edgeVectorX6 = 0.0;
		double edgeVectorY6 = 0.0;
		double edgeVectorX7 = 0.0;
		double edgeVectorY7 = 0.0;
		double edgeVectorX8;
		double edgeVectorY8;
		if (num19 > 2)
		{
			TVertex val6 = list2[2];
			num24 = val6.X;
			num25 = val6.Y;
			edgeVectorX8 = num24 - x3;
			edgeVectorY8 = num25 - y3;
			if (num19 > 3)
			{
				TVertex val7 = list2[3];
				num26 = val7.X;
				num27 = val7.Y;
				edgeVectorX2 = num26 - num24;
				edgeVectorY2 = num27 - num25;
				if (num19 > 4)
				{
					TVertex val8 = list2[4];
					num28 = val8.X;
					num29 = val8.Y;
					edgeVectorX3 = num28 - num26;
					edgeVectorY3 = num29 - num27;
					if (num19 > 5)
					{
						TVertex val9 = list2[5];
						num30 = val9.X;
						num31 = val9.Y;
						edgeVectorX4 = num30 - num28;
						edgeVectorY4 = num31 - num29;
						if (num19 > 6)
						{
							TVertex val10 = list2[6];
							num32 = val10.X;
							num33 = val10.Y;
							edgeVectorX5 = num32 - num30;
							edgeVectorY5 = num33 - num31;
							if (num19 > 7)
							{
								TVertex val11 = list2[7];
								num34 = val11.X;
								num35 = val11.Y;
								edgeVectorX6 = num34 - num32;
								edgeVectorY6 = num35 - num33;
								edgeVectorX7 = x2 - num34;
								edgeVectorY7 = y2 - num35;
							}
							else
							{
								edgeVectorX6 = x2 - num32;
								edgeVectorY6 = y2 - num33;
							}
						}
						else
						{
							edgeVectorX5 = x2 - num30;
							edgeVectorY5 = y2 - num31;
						}
					}
					else
					{
						edgeVectorX4 = x2 - num28;
						edgeVectorY4 = y2 - num29;
					}
				}
				else
				{
					edgeVectorX3 = x2 - num26;
					edgeVectorY3 = y2 - num27;
				}
			}
			else
			{
				edgeVectorX2 = x2 - num24;
				edgeVectorY2 = y2 - num25;
			}
		}
		else
		{
			edgeVectorX8 = x2 - x3;
			edgeVectorY8 = y2 - y3;
		}
		TVertex[][] array2 = new TVertex[num19][];
		double[][] array3 = new double[num19][];
		int[] array4 = new int[num19];
		for (int num36 = 0; num36 < num19; num36++)
		{
			array4[num36] = 0;
			array2[num36] = new TVertex[count];
			array3[num36] = new double[count];
		}
		int num37 = 0;
		int num38 = array[num37++];
		for (int num39 = 0; num39 < count; num39++)
		{
			if (num37 < array.Length && num39 == num38)
			{
				num38 = array[num37++];
				continue;
			}
			TVertex newPoint = points[num39];
			double x4 = newPoint.X;
			double y4 = newPoint.Y;
			if (!AddToListAlong(array2[0], array3[0], ref array4[0], newPoint, x4, y4, x2, y2, edgeVectorX, edgeVectorY) && !AddToListAlong(array2[1], array3[1], ref array4[1], newPoint, x4, y4, x3, y3, edgeVectorX8, edgeVectorY8) && !AddToListAlong(array2[2], array3[2], ref array4[2], newPoint, x4, y4, num24, num25, edgeVectorX2, edgeVectorY2) && num19 != 3 && !AddToListAlong(array2[3], array3[3], ref array4[3], newPoint, x4, y4, num26, num27, edgeVectorX3, edgeVectorY3) && num19 != 4 && !AddToListAlong(array2[4], array3[4], ref array4[4], newPoint, x4, y4, num28, num29, edgeVectorX4, edgeVectorY4) && num19 != 5 && !AddToListAlong(array2[5], array3[5], ref array4[5], newPoint, x4, y4, num30, num31, edgeVectorX5, edgeVectorY5) && num19 != 6 && !AddToListAlong(array2[6], array3[6], ref array4[6], newPoint, x4, y4, num32, num33, edgeVectorX6, edgeVectorY6) && num19 != 7)
			{
				AddToListAlong(array2[7], array3[7], ref array4[7], newPoint, x4, y4, num34, num35, edgeVectorX7, edgeVectorY7);
			}
		}
		for (int num40 = num19 - 1; num40 >= 0; num40--)
		{
			int num41 = array4[num40];
			if (num41 == 1)
			{
				list2.Insert(num40 + 1, array2[num40][0]);
			}
			else if (num41 > 1)
			{
				List<TVertex> list3 = new List<TVertex>();
				list3.Add(list2[num40]);
				for (int num42 = 0; num42 < num41; num42++)
				{
					list3.Add(array2[num40][num42]);
				}
				if (num40 == num19 - 1)
				{
					list3.Add(list2[0]);
				}
				else
				{
					list3.Add(list2[num40 + 1]);
				}
				int num43 = num41;
				while (num43 > 0)
				{
					double num44 = list3[num43].X - list3[num43 - 1].X;
					double num45 = list3[num43].Y - list3[num43 - 1].Y;
					double num46 = list3[num43 + 1].X - list3[num43].X;
					double num47 = list3[num43 + 1].Y - list3[num43].Y;
					if (num44 * num47 - num45 * num46 <= 0.0)
					{
						list3.RemoveAt(num43);
						if (num43 == list3.Count - 1)
						{
							num43--;
						}
					}
					else
					{
						num43--;
					}
				}
				for (num43 = list3.Count - 2; num43 > 0; num43--)
				{
					list2.Insert(num40 + 1, list3[num43]);
				}
			}
		}
		return list2;
	}

	internal static ConvexHull<TVertex, TFace> Return2DResults<TVertex, TFace>(IVertex[] vertices) where TVertex : IVertex where TFace : ConvexFace<TVertex, TFace>, new()
	{
		return null;
	}

	private static List<TVertex> FindIntermediatePointsForLongSkinny<TVertex>(IList<TVertex> points, int numPoints, int usedIndex1, int usedIndex2, out List<int> newUsedIndices) where TVertex : IVertex2D
	{
		newUsedIndices = new List<int>();
		double x = points[usedIndex1].X;
		double y = points[usedIndex1].Y;
		double num = points[usedIndex2].X - x;
		double num2 = points[usedIndex2].Y - y;
		double num3 = -1E-10;
		double num4 = 1E-10;
		int num5 = -1;
		int num6 = -1;
		for (int i = 0; i < numPoints; i++)
		{
			if (i != usedIndex1 && i != usedIndex2)
			{
				TVertex val = points[i];
				double num7 = num * (val.Y - y) + num2 * (x - val.X);
				if (num7 < num3)
				{
					num5 = i;
					num3 = num7;
				}
				if (num7 > num4)
				{
					num6 = i;
					num4 = num7;
				}
			}
		}
		List<TVertex> list = new List<TVertex>();
		list.Add(points[usedIndex1]);
		if (num5 != -1)
		{
			newUsedIndices.Add(num5);
			list.Add(points[num5]);
		}
		list.Add(points[usedIndex2]);
		if (num6 != -1)
		{
			newUsedIndices.Add(num6);
			list.Add(points[num6]);
		}
		return list;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool AddToListAlong<TVertex>(TVertex[] sortedPoints, double[] sortedKeys, ref int size, TVertex newPoint, double newPointX, double newPointY, double basePointX, double basePointY, double edgeVectorX, double edgeVectorY) where TVertex : IVertex2D
	{
		double num = newPointX - basePointX;
		double num2 = newPointY - basePointY;
		double num3 = num * edgeVectorY - num2 * edgeVectorX;
		if (num3 <= 0.0)
		{
			return false;
		}
		double num4 = edgeVectorX * num + edgeVectorY * num2;
		int num5 = BinarySearch(sortedKeys, size, num4);
		if (num5 >= 0)
		{
			TVertex val = sortedPoints[num5];
			double num6 = (val.X - basePointX) * edgeVectorY - (val.Y - basePointY) * edgeVectorX;
			if (num3 > num6)
			{
				sortedPoints[num5] = newPoint;
			}
		}
		else
		{
			num5 = ~num5;
			if (num5 == 0)
			{
				for (int num7 = size; num7 > num5; num7--)
				{
					sortedKeys[num7] = sortedKeys[num7 - 1];
					sortedPoints[num7] = sortedPoints[num7 - 1];
				}
				sortedKeys[num5] = num4;
				sortedPoints[num5] = newPoint;
				size++;
			}
			else if (num5 < size)
			{
				TVertex val2 = sortedPoints[num5 - 1];
				TVertex val3 = sortedPoints[num5];
				double num8 = newPointX - val2.X;
				double num9 = newPointY - val2.Y;
				double num10 = val3.X - newPointX;
				double num11 = val3.Y - newPointY;
				if (num8 * num11 - num9 * num10 > 0.0)
				{
					for (int num12 = size; num12 > num5; num12--)
					{
						sortedKeys[num12] = sortedKeys[num12 - 1];
						sortedPoints[num12] = sortedPoints[num12 - 1];
					}
					sortedKeys[num5] = num4;
					sortedPoints[num5] = newPoint;
					size++;
				}
			}
			else
			{
				sortedKeys[num5] = num4;
				sortedPoints[num5] = newPoint;
				size++;
			}
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int BinarySearch(double[] array, int length, double value)
	{
		int num = 0;
		int num2 = length - 1;
		while (num <= num2)
		{
			int num3 = num + (num2 - num >> 1);
			double num4 = array[num3];
			if (num4 == value)
			{
				return num3;
			}
			if (num4 < value)
			{
				num = num3 + 1;
			}
			else
			{
				num2 = num3 - 1;
			}
		}
		return ~num;
	}
}
