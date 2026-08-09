using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis;

public static class Clustering
{
	public static IEnumerable<IReadOnlyList<T>> NearestNeighbours<T>(IReadOnlyList<T> elements, Func<PdfPoint, PdfPoint, double> distMeasure, Func<T, T, double> maxDistanceFunction, Func<T, PdfPoint> pivotPoint, Func<T, PdfPoint> candidatesPoint, Func<T, bool> filterPivot, Func<T, T, bool> filterFinal, int maxDegreeOfParallelism)
	{
		int[] indexes = Enumerable.Repeat(-1, elements.Count).ToArray();
		KdTree<T> kdTree = new KdTree<T>(elements, candidatesPoint);
		ParallelOptions parallelOptions = new ParallelOptions
		{
			MaxDegreeOfParallelism = maxDegreeOfParallelism
		};
		Parallel.For(0, elements.Count, parallelOptions, delegate(int e)
		{
			T val = elements[e];
			if (filterPivot(val))
			{
				int index;
				double distance;
				T arg = kdTree.FindNearestNeighbour(val, pivotPoint, distMeasure, out index, out distance);
				if (index != -1 && filterFinal(val, arg) && distance < maxDistanceFunction(val, arg))
				{
					indexes[e] = index;
				}
			}
		});
		foreach (List<int> item in GroupIndexes(indexes))
		{
			yield return item.Select((int i) => elements[i]).ToList();
		}
	}

	public static IEnumerable<IReadOnlyList<T>> NearestNeighbours<T>(IReadOnlyList<T> elements, int k, Func<PdfPoint, PdfPoint, double> distMeasure, Func<T, T, double> maxDistanceFunction, Func<T, PdfPoint> pivotPoint, Func<T, PdfPoint> candidatesPoint, Func<T, bool> filterPivot, Func<T, T, bool> filterFinal, int maxDegreeOfParallelism)
	{
		int[] indexes = Enumerable.Repeat(-1, elements.Count).ToArray();
		KdTree<T> kdTree = new KdTree<T>(elements, candidatesPoint);
		ParallelOptions parallelOptions = new ParallelOptions
		{
			MaxDegreeOfParallelism = maxDegreeOfParallelism
		};
		Parallel.For(0, elements.Count, parallelOptions, delegate(int e)
		{
			T val = elements[e];
			if (filterPivot(val))
			{
				foreach (var item in kdTree.FindNearestNeighbours(val, k, pivotPoint, distMeasure))
				{
					if (filterFinal(val, item.Item1) && item.Item3 < maxDistanceFunction(val, item.Item1))
					{
						indexes[e] = item.Item2;
						break;
					}
				}
			}
		});
		foreach (List<int> item2 in GroupIndexes(indexes))
		{
			yield return item2.Select((int i) => elements[i]).ToList();
		}
	}

	public static IEnumerable<IReadOnlyList<T>> NearestNeighbours<T>(IReadOnlyList<T> elements, Func<PdfLine, PdfLine, double> distMeasure, Func<T, T, double> maxDistanceFunction, Func<T, PdfLine> pivotLine, Func<T, PdfLine> candidatesLine, Func<T, bool> filterPivot, Func<T, T, bool> filterFinal, int maxDegreeOfParallelism)
	{
		int[] indexes = Enumerable.Repeat(-1, elements.Count).ToArray();
		ParallelOptions parallelOptions = new ParallelOptions
		{
			MaxDegreeOfParallelism = maxDegreeOfParallelism
		};
		Parallel.For(0, elements.Count, parallelOptions, delegate(int e)
		{
			T val = elements[e];
			if (filterPivot(val))
			{
				double distance;
				int num = Distances.FindIndexNearest(val, elements, pivotLine, candidatesLine, distMeasure, out distance);
				if (num != -1)
				{
					T arg = elements[num];
					if (filterFinal(val, arg) && distance < maxDistanceFunction(val, arg))
					{
						indexes[e] = num;
					}
				}
			}
		});
		foreach (List<int> item in GroupIndexes(indexes))
		{
			yield return item.Select((int i) => elements[i]).ToList();
		}
	}

	internal static List<List<int>> GroupIndexes(int[] edges)
	{
		List<int>[] array = new List<int>[edges.Length];
		for (int i = 0; i < edges.Length; i++)
		{
			array[i] = new List<int>();
		}
		for (int j = 0; j < edges.Length; j++)
		{
			int num = edges[j];
			if (num != -1)
			{
				array[j].Add(num);
				array[num].Add(j);
			}
		}
		List<List<int>> list = new List<List<int>>();
		bool[] isDone = new bool[edges.Length];
		for (int k = 0; k < edges.Length; k++)
		{
			if (!isDone[k])
			{
				list.Add(DfsIterative(k, array, ref isDone));
			}
		}
		return list;
	}

	private static List<int> DfsIterative(int s, List<int>[] adj, ref bool[] isDone)
	{
		List<int> list = new List<int>();
		Stack<int> stack = new Stack<int>(4);
		stack.Push(s);
		isDone[s] = true;
		while (stack.Count > 0)
		{
			int num = stack.Pop();
			list.Add(num);
			List<int> list2 = adj[num];
			int count = list2.Count;
			for (int i = 0; i < count; i++)
			{
				int num2 = list2[i];
				ref bool reference = ref isDone[num2];
				if (!reference)
				{
					stack.Push(num2);
					reference = true;
				}
			}
		}
		return list;
	}
}
