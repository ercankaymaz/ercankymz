using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis;

public class KdTree : KdTree<PdfPoint>
{
	public KdTree(IReadOnlyList<PdfPoint> points)
		: base(points, (Func<PdfPoint, PdfPoint>)((PdfPoint p) => p))
	{
	}

	public PdfPoint FindNearestNeighbour(PdfPoint pivot, Func<PdfPoint, PdfPoint, double> distanceMeasure, out int index, out double distance)
	{
		return FindNearestNeighbour(pivot, (PdfPoint p) => p, distanceMeasure, out index, out distance);
	}

	public IReadOnlyList<(PdfPoint, int, double)> FindNearestNeighbours(PdfPoint pivot, int k, Func<PdfPoint, PdfPoint, double> distanceMeasure)
	{
		return FindNearestNeighbours(pivot, k, (PdfPoint p) => p, distanceMeasure);
	}
}
public class KdTree<T>
{
	private class KNearestNeighboursQueue : SortedList<double, HashSet<KdTreeNode<T>>>
	{
		public readonly int K;

		public KdTreeNode<T> LastElement { get; private set; }

		public double LastDistance { get; private set; }

		public bool IsFull => base.Count >= K;

		public KNearestNeighboursQueue(int k)
			: base(k)
		{
			K = k;
			LastDistance = double.PositiveInfinity;
		}

		public void Add(double key, KdTreeNode<T> value)
		{
			if (key > LastDistance && IsFull)
			{
				return;
			}
			if (!ContainsKey(key))
			{
				Add(key, new HashSet<KdTreeNode<T>>());
				if (base.Count > K)
				{
					RemoveAt(base.Count - 1);
				}
			}
			if (base[key].Add(value))
			{
				KeyValuePair<double, HashSet<KdTreeNode<T>>> keyValuePair = this.Last();
				LastElement = keyValuePair.Value.Last();
				LastDistance = keyValuePair.Key;
			}
		}
	}

	internal readonly struct KdTreeElement<R>
	{
		public int Index { get; }

		public PdfPoint Value { get; }

		public R Element { get; }

		internal KdTreeElement(int index, PdfPoint point, R value)
		{
			Index = index;
			Value = point;
			Element = value;
		}
	}

	private sealed class KdTreeComparerY : IComparer<KdTreeElement<T>>
	{
		public int Compare(KdTreeElement<T> p0, KdTreeElement<T> p1)
		{
			return p0.Value.Y.CompareTo(p1.Value.Y);
		}
	}

	private sealed class KdTreeComparerX : IComparer<KdTreeElement<T>>
	{
		public int Compare(KdTreeElement<T> p0, KdTreeElement<T> p1)
		{
			return p0.Value.X.CompareTo(p1.Value.X);
		}
	}

	public class KdTreeLeaf<Q> : KdTreeNode<Q>
	{
		public override bool IsLeaf => true;

		internal KdTreeLeaf(KdTreeElement<Q> point, int depth)
			: base((KdTreeNode<Q>)null, (KdTreeNode<Q>)null, point, depth)
		{
		}

		public override string ToString()
		{
			return "Leaf->" + base.Value;
		}
	}

	public class KdTreeNode<Q>
	{
		public double L
		{
			get
			{
				if (!IsAxisCutX)
				{
					return Value.Y;
				}
				return Value.X;
			}
		}

		public PdfPoint Value { get; }

		public KdTreeNode<Q> LeftChild { get; internal set; }

		public KdTreeNode<Q> RightChild { get; internal set; }

		public Q Element { get; }

		public bool IsAxisCutX { get; }

		public int Depth { get; }

		public virtual bool IsLeaf => false;

		public int Index { get; }

		internal KdTreeNode(KdTreeNode<Q> leftChild, KdTreeNode<Q> rightChild, KdTreeElement<Q> point, int depth)
		{
			LeftChild = leftChild;
			RightChild = rightChild;
			Value = point.Value;
			Element = point.Element;
			Depth = depth;
			IsAxisCutX = depth % 2 == 0;
			Index = point.Index;
		}

		public IEnumerable<KdTreeLeaf<Q>> GetLeaves()
		{
			List<KdTreeLeaf<Q>> leaves = new List<KdTreeLeaf<Q>>();
			RecursiveGetLeaves(LeftChild, ref leaves);
			RecursiveGetLeaves(RightChild, ref leaves);
			return leaves;
		}

		private void RecursiveGetLeaves(KdTreeNode<Q> leaf, ref List<KdTreeLeaf<Q>> leaves)
		{
			if (leaf != null)
			{
				if (leaf is KdTreeLeaf<Q> item)
				{
					leaves.Add(item);
					return;
				}
				RecursiveGetLeaves(leaf.LeftChild, ref leaves);
				RecursiveGetLeaves(leaf.RightChild, ref leaves);
			}
		}

		public override string ToString()
		{
			return "Node->" + Value;
		}
	}

	private readonly KdTreeComparerY kdTreeComparerY = new KdTreeComparerY();

	private readonly KdTreeComparerX kdTreeComparerX = new KdTreeComparerX();

	public readonly KdTreeNode<T> Root;

	public readonly int Count;

	public KdTree(IReadOnlyList<T> elements, Func<T, PdfPoint> elementsPointFunc)
	{
		if (elements == null || elements.Count == 0)
		{
			throw new ArgumentException("KdTree(): candidates cannot be null or empty.", "elements");
		}
		Count = elements.Count;
		KdTreeElement<T>[] array = new KdTreeElement<T>[Count];
		for (int i = 0; i < Count; i++)
		{
			T val = elements[i];
			array[i] = new KdTreeElement<T>(i, elementsPointFunc(val), val);
		}
		Root = BuildTree(new ArraySegment<KdTreeElement<T>>(array));
	}

	private KdTreeNode<T> BuildTree(ArraySegment<KdTreeElement<T>> P, int depth = 0)
	{
		if (P.Count == 0)
		{
			return null;
		}
		if (P.Count == 1)
		{
			return new KdTreeLeaf<T>(P.GetAt(0), depth);
		}
		if (depth % 2 == 0)
		{
			P.Sort(kdTreeComparerX);
		}
		else
		{
			P.Sort(kdTreeComparerY);
		}
		if (P.Count == 2)
		{
			return new KdTreeNode<T>(new KdTreeLeaf<T>(P.GetAt(0), depth + 1), null, P.GetAt(1), depth);
		}
		int num = P.Count / 2;
		KdTreeNode<T> leftChild = BuildTree(P.Take(num), depth + 1);
		KdTreeNode<T> rightChild = BuildTree(P.Skip(num + 1), depth + 1);
		return new KdTreeNode<T>(leftChild, rightChild, P.GetAt(num), depth);
	}

	public T FindNearestNeighbour(T pivot, Func<T, PdfPoint> pivotPointFunc, Func<PdfPoint, PdfPoint, double> distanceMeasure, out int index, out double distance)
	{
		(KdTreeNode<T>, double?) tuple = FindNearestNeighbour(Root, pivot, pivotPointFunc, distanceMeasure);
		index = ((tuple.Item1 != null) ? tuple.Item1.Index : (-1));
		distance = tuple.Item2 ?? double.NaN;
		if (tuple.Item1 == null)
		{
			return default(T);
		}
		return tuple.Item1.Element;
	}

	private static (KdTreeNode<T>, double?) FindNearestNeighbour(KdTreeNode<T> node, T pivot, Func<T, PdfPoint> pivotPointFunc, Func<PdfPoint, PdfPoint, double> distance)
	{
		if (node == null)
		{
			return (null, null);
		}
		if (node.IsLeaf)
		{
			if (node.Element.Equals(pivot))
			{
				return (null, null);
			}
			return (node, distance(node.Value, pivotPointFunc(pivot)));
		}
		PdfPoint arg = pivotPointFunc(pivot);
		KdTreeNode<T> item = node;
		double num = distance(node.Value, arg);
		KdTreeNode<T> kdTreeNode = null;
		double? num2 = null;
		double num3 = (node.IsAxisCutX ? arg.X : arg.Y);
		if (num3 < node.L)
		{
			(kdTreeNode, num2) = FindNearestNeighbour(node.LeftChild, pivot, pivotPointFunc, distance);
			if (num2.HasValue && num2 <= num && !kdTreeNode.Element.Equals(pivot))
			{
				num = num2.Value;
				item = kdTreeNode;
			}
			if (node.RightChild != null && num3 + num >= node.L)
			{
				(kdTreeNode, num2) = FindNearestNeighbour(node.RightChild, pivot, pivotPointFunc, distance);
			}
		}
		else
		{
			(kdTreeNode, num2) = FindNearestNeighbour(node.RightChild, pivot, pivotPointFunc, distance);
			if (num2.HasValue && num2 <= num && !kdTreeNode.Element.Equals(pivot))
			{
				num = num2.Value;
				item = kdTreeNode;
			}
			if (node.LeftChild != null && num3 - num <= node.L)
			{
				(kdTreeNode, num2) = FindNearestNeighbour(node.LeftChild, pivot, pivotPointFunc, distance);
			}
		}
		if (num2.HasValue && num2 <= num && !kdTreeNode.Element.Equals(pivot))
		{
			num = num2.Value;
			item = kdTreeNode;
		}
		return (item, num);
	}

	public IReadOnlyList<(T, int, double)> FindNearestNeighbours(T pivot, int k, Func<T, PdfPoint> pivotPointFunc, Func<PdfPoint, PdfPoint, double> distanceMeasure)
	{
		KNearestNeighboursQueue kNearestNeighboursQueue = new KNearestNeighboursQueue(k);
		FindNearestNeighbours(Root, pivot, k, pivotPointFunc, distanceMeasure, kNearestNeighboursQueue);
		return kNearestNeighboursQueue.SelectMany((KeyValuePair<double, HashSet<KdTreeNode<T>>> n) => n.Value.Select((KdTreeNode<T> e) => (Element: e.Element, Index: e.Index, Key: n.Key))).ToArray();
	}

	private static (KdTreeNode<T>, double) FindNearestNeighbours(KdTreeNode<T> node, T pivot, int k, Func<T, PdfPoint> pivotPointFunc, Func<PdfPoint, PdfPoint, double> distance, KNearestNeighboursQueue queue)
	{
		if (node == null)
		{
			return (null, double.NaN);
		}
		if (node.IsLeaf)
		{
			if (node.Element.Equals(pivot))
			{
				return (null, double.NaN);
			}
			double num = distance(node.Value, pivotPointFunc(pivot));
			KdTreeNode<T> kdTreeNode = node;
			if (!queue.IsFull || num <= queue.LastDistance)
			{
				queue.Add(num, kdTreeNode);
				num = queue.LastDistance;
				kdTreeNode = queue.LastElement;
			}
			return (kdTreeNode, num);
		}
		PdfPoint arg = pivotPointFunc(pivot);
		KdTreeNode<T> kdTreeNode2 = node;
		double num2 = distance(node.Value, arg);
		if ((!queue.IsFull || num2 <= queue.LastDistance) && !node.Element.Equals(pivot))
		{
			queue.Add(num2, kdTreeNode2);
			num2 = queue.LastDistance;
			kdTreeNode2 = queue.LastElement;
		}
		KdTreeNode<T> kdTreeNode3 = null;
		double num3 = double.NaN;
		double num4 = (node.IsAxisCutX ? arg.X : arg.Y);
		if (num4 < node.L)
		{
			(kdTreeNode3, num3) = FindNearestNeighbours(node.LeftChild, pivot, k, pivotPointFunc, distance, queue);
			if (!double.IsNaN(num3) && num3 <= num2 && !kdTreeNode3.Element.Equals(pivot))
			{
				queue.Add(num3, kdTreeNode3);
				num2 = queue.LastDistance;
				kdTreeNode2 = queue.LastElement;
			}
			if (node.RightChild != null && num4 + num2 >= node.L)
			{
				(kdTreeNode3, num3) = FindNearestNeighbours(node.RightChild, pivot, k, pivotPointFunc, distance, queue);
			}
		}
		else
		{
			(kdTreeNode3, num3) = FindNearestNeighbours(node.RightChild, pivot, k, pivotPointFunc, distance, queue);
			if (!double.IsNaN(num3) && num3 <= num2 && !kdTreeNode3.Element.Equals(pivot))
			{
				queue.Add(num3, kdTreeNode3);
				num2 = queue.LastDistance;
				kdTreeNode2 = queue.LastElement;
			}
			if (node.LeftChild != null && num4 - num2 <= node.L)
			{
				(kdTreeNode3, num3) = FindNearestNeighbours(node.LeftChild, pivot, k, pivotPointFunc, distance, queue);
			}
		}
		if (!double.IsNaN(num3) && num3 <= num2 && !kdTreeNode3.Element.Equals(pivot))
		{
			queue.Add(num3, kdTreeNode3);
			num2 = queue.LastDistance;
			kdTreeNode2 = queue.LastElement;
		}
		return (kdTreeNode2, num2);
	}
}
