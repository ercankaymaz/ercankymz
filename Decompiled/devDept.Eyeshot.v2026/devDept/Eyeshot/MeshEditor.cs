using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using devDept.Geometry;

namespace devDept.Eyeshot;

public class MeshEditor
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<SharedEdge, int> _0023_003DzXPzGEwjBMtIuXM3_mg_003D_003D;

		internal int _0023_003Dz5nW7gxmqQB9e8DjjBg_003D_003D(SharedEdge _0023_003DzbfrNXYE_003D)
		{
			return _0023_003DzbfrNXYE_003D.V2;
		}
	}

	private sealed class _0023_003DzLzxjCf3eY9SG7oiVOgRdcEk_003D
	{
		public SharedEdge _0023_003DzTx2aqr8_003D;

		public MeshEditor _0023_003DzopRx0_MBcTQs;

		internal bool _0023_003DzRIhARU_0024OkBmOkAg9Mg_003D_003D(int _0023_003DzNDQ_E88_003D)
		{
			return _0023_003DzopRx0_MBcTQs.Triangles[_0023_003DzNDQ_E88_003D]._0023_003DzXscMLpk_003D(_0023_003DzTx2aqr8_003D.V2);
		}
	}

	private readonly ref struct _0023_003DzoJbmpvH3qHaD(int _0023_003Dz77g161c_003D, SharedEdge _0023_003Dz2T4sy2I_003D, SharedEdge _0023_003DzO91j_0024fQ_003D)
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly int _0023_003Dz61IPlm0_003D = _0023_003Dz77g161c_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly SharedEdge _0023_003DzDBy2B88_003D = _0023_003Dz2T4sy2I_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly SharedEdge _0023_003DzGZKh520_003D = _0023_003DzO91j_0024fQ_003D;

		public bool _0023_003DzVtaVpwk_003D()
		{
			if (_0023_003DzDBy2B88_003D.Dad < 0)
			{
				return _0023_003DzGZKh520_003D.Dad >= 0;
			}
			return true;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point3D[] _0023_003DzOy7x6nKmJG_0024PzP1zikqcql_pFqjr;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IndexTriangle[] _0023_003DzED4AA72m_syxjEpBgdNshr3XvJZN;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private LinkedList<SharedEdge>[] _0023_003Dzi8wSwVcEjI99;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private LinkedList<int>[] _0023_003DzVADK_00243zQ_xucjCTCgQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly IndexTriangle _0023_003DzbnsaKPfMhr1s;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Point3D _0023_003DzBGfisEH3_fwG;

	public Point3D[] Vertices
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzOy7x6nKmJG_0024PzP1zikqcql_pFqjr;
		}
	}

	public IndexTriangle[] Triangles
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzED4AA72m_syxjEpBgdNshr3XvJZN;
		}
	}

	public LinkedList<SharedEdge>[] SharedEdges => _0023_003Dzi8wSwVcEjI99;

	public LinkedList<int>[] Adjacency => _0023_003DzVADK_00243zQ_xucjCTCgQ_003D_003D;

	public MeshEditor(Point3D[] vertices, IndexTriangle[] triangles)
	{
		_0023_003DzbnsaKPfMhr1s = (IndexTriangle)triangles[0].Clone();
		_0023_003DzBGfisEH3_fwG = (Point3D)vertices[0].Clone();
		_0023_003DzbnsaKPfMhr1s.V1 = 0;
		_0023_003DzbnsaKPfMhr1s.V2 = 0;
		_0023_003DzbnsaKPfMhr1s.V3 = 0;
		_0023_003DzBGfisEH3_fwG.X = 0.0;
		_0023_003DzBGfisEH3_fwG.Y = 0.0;
		_0023_003DzBGfisEH3_fwG.Z = 0.0;
		_0023_003DzLwMfQ4FStYIc3oDNag_003D_003D(vertices);
		_0023_003Dzg8NPq_0024Bv7ANvyfVpbA_003D_003D(triangles);
		_0023_003Dz_ll_40k_003D();
	}

	private void _0023_003DzLwMfQ4FStYIc3oDNag_003D_003D(Point3D[] _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzOy7x6nKmJG_0024PzP1zikqcql_pFqjr = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003Dzg8NPq_0024Bv7ANvyfVpbA_003D_003D(IndexTriangle[] _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzED4AA72m_syxjEpBgdNshr3XvJZN = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003Dz_ll_40k_003D()
	{
		Utility.GetEdgesWithoutDuplicates(Triangles, Vertices.Length, out _0023_003Dzi8wSwVcEjI99);
		_0023_003DzVADK_00243zQ_xucjCTCgQ_003D_003D = new LinkedList<int>[Vertices.Length];
		for (int i = 0; i < Vertices.Length; i++)
		{
			_0023_003DzVADK_00243zQ_xucjCTCgQ_003D_003D[i] = new LinkedList<int>();
		}
		for (int j = 0; j < Triangles.Length; j++)
		{
			_0023_003Dz7C7GRAA18v39(j);
		}
		if (_0023_003DzNOJaEu0_003D() != 0)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989629));
		}
	}

	private void _0023_003Dz7C7GRAA18v39(int _0023_003DzyzK8swU_003D)
	{
		IndexTriangle indexTriangle = Triangles[_0023_003DzyzK8swU_003D];
		_0023_003DzVADK_00243zQ_xucjCTCgQ_003D_003D[indexTriangle.V1].AddLast(_0023_003DzyzK8swU_003D);
		_0023_003DzVADK_00243zQ_xucjCTCgQ_003D_003D[indexTriangle.V2].AddLast(_0023_003DzyzK8swU_003D);
		_0023_003DzVADK_00243zQ_xucjCTCgQ_003D_003D[indexTriangle.V3].AddLast(_0023_003DzyzK8swU_003D);
	}

	public static int[] Quad(IndexTriangle mum, IndexTriangle dad)
	{
		var (e, e2) = mum._0023_003DzQSvDYSY_003D(dad);
		return Quad(mum, dad, e, e2);
	}

	public static int[] Quad(IndexTriangle mum, IndexTriangle dad, int e1, int e2)
	{
		int num = dad._0023_003DzI2fnrdw_003D(e1, e2);
		if (dad._0023_003Dzg_0024_0024HtRw_003D(num) == e1)
		{
			e1 = e2;
		}
		if (mum.V1 != e1)
		{
			if (mum.V2 != e1)
			{
				return new int[4] { mum.V3, num, mum.V1, mum.V2 };
			}
			return new int[4] { mum.V2, num, mum.V3, mum.V1 };
		}
		return new int[4] { mum.V1, num, mum.V2, mum.V3 };
	}

	public HashSet<int> Connected(int v1)
	{
		HashSet<int> hashSet = new HashSet<int>();
		foreach (int item in _0023_003DzVADK_00243zQ_xucjCTCgQ_003D_003D[v1])
		{
			IndexTriangle indexTriangle = Triangles[item];
			hashSet.Add(indexTriangle.V1);
			hashSet.Add(indexTriangle.V2);
			hashSet.Add(indexTriangle.V3);
		}
		hashSet.Remove(v1);
		return hashSet;
	}

	public void SortAdjacency(int v)
	{
		LinkedList<int> linkedList = Adjacency[v];
		if (linkedList.Count < 1)
		{
			return;
		}
		LinkedListNode<int> linkedListNode = linkedList.First;
		while (linkedListNode != null)
		{
			LinkedListNode<int> linkedListNode2;
			for (linkedListNode2 = linkedListNode; linkedListNode2 != null; linkedListNode2 = linkedListNode2.Next)
			{
				int to = Triangles[linkedListNode2.Value]._0023_003Dzg_0024_0024HtRw_003D(v);
				if (GetEdge(v, to).Dad < 0)
				{
					break;
				}
			}
			if (linkedListNode2 == null)
			{
				linkedListNode2 = linkedList.First;
			}
			else if (linkedListNode != linkedListNode2)
			{
				linkedList.Remove(linkedListNode2);
				linkedList.AddBefore(linkedListNode, linkedListNode2);
			}
			LinkedListNode<int> linkedListNode3;
			while ((linkedListNode3 = _0023_003DzPq45nGk_003D(linkedListNode2, v, Triangles[linkedListNode2.Value]._0023_003DzMqZZWVg_003D(v))) != null)
			{
				linkedList.Remove(linkedListNode3);
				linkedList.AddAfter(linkedListNode2, linkedListNode3);
				linkedListNode2 = linkedListNode3;
			}
			linkedListNode = linkedListNode2.Next;
		}
	}

	private LinkedListNode<int> _0023_003DzPq45nGk_003D(LinkedListNode<int> _0023_003DzAqOpw0w_003D, int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D)
	{
		while (_0023_003DzAqOpw0w_003D != null && Triangles[_0023_003DzAqOpw0w_003D.Value]._0023_003Dzg_0024_0024HtRw_003D(_0023_003DzffqPLNQ_003D) != _0023_003Dz5Azd7L8_003D)
		{
			_0023_003DzAqOpw0w_003D = _0023_003DzAqOpw0w_003D.Next;
		}
		return _0023_003DzAqOpw0w_003D;
	}

	public int[] Cell(int v)
	{
		LinkedList<int> linkedList = _0023_003DzVADK_00243zQ_xucjCTCgQ_003D_003D[v];
		if (linkedList.Count < 1)
		{
			return Array.Empty<int>();
		}
		int[] array = new int[linkedList.Count];
		LinkedListNode<int> linkedListNode = linkedList.First;
		LinkedListNode<int> next = linkedList.First.Next;
		int num = 0;
		do
		{
			int num2 = Triangles[linkedListNode.Value]._0023_003DzMqZZWVg_003D(v);
			array[num++] = num2;
			next = _0023_003DzPq45nGk_003D(next, v, num2);
			if (next == null)
			{
				return Array.Empty<int>();
			}
			linkedList.Remove(next);
			linkedList.AddAfter(linkedListNode, next);
			linkedListNode = next;
			next = linkedListNode.Next;
		}
		while (next != null);
		array[num] = Triangles[linkedListNode.Value]._0023_003DzMqZZWVg_003D(v);
		if (array[num] != Triangles[linkedList.First.Value]._0023_003Dzg_0024_0024HtRw_003D(v))
		{
			return Array.Empty<int>();
		}
		return array;
	}

	public int[] Cell(int v1, int v2)
	{
		int[] array = Cell(v1);
		int[] array2 = Cell(v2);
		if (array.Length == 0 || array2.Length == 0)
		{
			return Array.Empty<int>();
		}
		int[] array3 = new int[array.Length + array2.Length - 4];
		int i;
		for (i = 0; array[i] != v2; i++)
		{
		}
		for (int j = 1; j < array.Length - 1; j++)
		{
			array3[j - 1] = array[(j + i) % array.Length];
		}
		for (i = 0; array2[i] != v1; i++)
		{
		}
		for (int k = 1; k < array2.Length - 1; k++)
		{
			array3[array.Length + k - 3] = array2[(k + i) % array2.Length];
		}
		return array3;
	}

	public SharedEdge GetEdge(int from, int to, out int v1)
	{
		v1 = from;
		foreach (SharedEdge item in _0023_003Dzi8wSwVcEjI99[from])
		{
			if (item.V2 == to)
			{
				return item;
			}
		}
		v1 = to;
		foreach (SharedEdge item2 in _0023_003Dzi8wSwVcEjI99[to])
		{
			if (item2.V2 == from)
			{
				return item2;
			}
		}
		return null;
	}

	public SharedEdge GetEdge(int from, int to)
	{
		int v;
		return GetEdge(from, to, out v);
	}

	public bool Flip(int v1, int v2)
	{
		int v3;
		SharedEdge edge = GetEdge(v1, v2, out v3);
		if (edge != null)
		{
			return Flip(v3, edge);
		}
		return false;
	}

	public bool Flip(int v1, SharedEdge edge)
	{
		IndexTriangle mum = Triangles[edge.Mum];
		IndexTriangle dad = Triangles[edge.Dad];
		int[] _0023_003DzCjKvDZD851nk = Quad(mum, dad, v1, edge.V2);
		return _0023_003Dz46iWwIQ_003D(v1, edge, _0023_003DzCjKvDZD851nk);
	}

	private bool _0023_003Dz46iWwIQ_003D(int _0023_003DzffqPLNQ_003D, SharedEdge _0023_003DzTx2aqr8_003D, int[] _0023_003DzCjKvDZD851nk)
	{
		IndexTriangle indexTriangle = Triangles[_0023_003DzTx2aqr8_003D.Mum];
		IndexTriangle indexTriangle2 = Triangles[_0023_003DzTx2aqr8_003D.Dad];
		if (GetEdge(_0023_003DzCjKvDZD851nk[1], _0023_003DzCjKvDZD851nk[3]) != null)
		{
			return false;
		}
		indexTriangle.V1 = _0023_003DzCjKvDZD851nk[1];
		indexTriangle.V2 = _0023_003DzCjKvDZD851nk[2];
		indexTriangle.V3 = _0023_003DzCjKvDZD851nk[3];
		indexTriangle2.V1 = indexTriangle.V3;
		indexTriangle2.V2 = _0023_003DzCjKvDZD851nk[0];
		indexTriangle2.V3 = indexTriangle.V1;
		_0023_003DzVADK_00243zQ_xucjCTCgQ_003D_003D[_0023_003DzCjKvDZD851nk[0]].Remove(_0023_003DzTx2aqr8_003D.Mum);
		_0023_003DzVADK_00243zQ_xucjCTCgQ_003D_003D[_0023_003DzCjKvDZD851nk[1]].AddLast(_0023_003DzTx2aqr8_003D.Mum);
		_0023_003DzVADK_00243zQ_xucjCTCgQ_003D_003D[_0023_003DzCjKvDZD851nk[2]].Remove(_0023_003DzTx2aqr8_003D.Dad);
		_0023_003DzVADK_00243zQ_xucjCTCgQ_003D_003D[_0023_003DzCjKvDZD851nk[3]].AddLast(_0023_003DzTx2aqr8_003D.Dad);
		_0023_003Dzi8wSwVcEjI99[_0023_003DzffqPLNQ_003D].Remove(_0023_003DzTx2aqr8_003D);
		_0023_003Dzi8wSwVcEjI99[_0023_003DzCjKvDZD851nk[1]].AddLast(_0023_003DzTx2aqr8_003D);
		_0023_003DzTx2aqr8_003D.V2 = _0023_003DzCjKvDZD851nk[3];
		GetEdge(_0023_003DzCjKvDZD851nk[1], _0023_003DzCjKvDZD851nk[2])._0023_003DzhF_UisQ_003D(_0023_003DzTx2aqr8_003D.Dad, _0023_003DzTx2aqr8_003D.Mum);
		GetEdge(_0023_003DzCjKvDZD851nk[3], _0023_003DzCjKvDZD851nk[0])._0023_003DzhF_UisQ_003D(_0023_003DzTx2aqr8_003D.Mum, _0023_003DzTx2aqr8_003D.Dad);
		if (_0023_003DzNOJaEu0_003D() != 0)
		{
			throw new Exception();
		}
		return true;
	}

	public bool Dissolvable4(int vertex, out int[] quad)
	{
		quad = Cell(vertex);
		if (quad.Length != 4)
		{
			return false;
		}
		return GetEdge(quad[0], quad[2]) == null;
	}

	public bool Dissolve4(int vertex)
	{
		if (!Dissolvable4(vertex, out var quad))
		{
			return false;
		}
		if ((object)Vertices[vertex] == _0023_003DzBGfisEH3_fwG)
		{
			throw new Exception();
		}
		LinkedListNode<int> first = _0023_003DzVADK_00243zQ_xucjCTCgQ_003D_003D[vertex].First;
		int value = first.Value;
		LinkedListNode<int> next = first.Next;
		int value2 = next.Value;
		LinkedListNode<int> next2 = next.Next;
		int value3 = next2.Value;
		int value4 = next2.Next.Value;
		IndexTriangle indexTriangle = Triangles[value];
		IndexTriangle indexTriangle2 = Triangles[value2];
		_0023_003Dzi5O3kJahwYwD(value, _0023_003DzWk2X_g_pf229: false);
		_0023_003Dzi5O3kJahwYwD(value2, _0023_003DzWk2X_g_pf229: false);
		_0023_003Dzi5O3kJahwYwD(value3, _0023_003DzWk2X_g_pf229: true);
		_0023_003Dzi5O3kJahwYwD(value4, _0023_003DzWk2X_g_pf229: true);
		_0023_003Dz_0024nDSZHUDGsWV(vertex);
		indexTriangle.V1 = quad[0];
		indexTriangle.V2 = quad[1];
		indexTriangle.V3 = quad[2];
		indexTriangle2.V1 = quad[0];
		indexTriangle2.V2 = quad[2];
		indexTriangle2.V3 = quad[3];
		_0023_003Dz7C7GRAA18v39(value);
		_0023_003Dz7C7GRAA18v39(value2);
		_0023_003DzVADK_00243zQ_xucjCTCgQ_003D_003D[vertex].Clear();
		_0023_003Dzi8wSwVcEjI99[vertex].Clear();
		for (int i = 0; i < 4; i++)
		{
			_0023_003DzgXM2klc_003D(_0023_003Dzi8wSwVcEjI99[quad[i]], vertex);
		}
		_0023_003Dzi8wSwVcEjI99[quad[0]].AddLast(new SharedEdge
		{
			V2 = quad[2],
			Mum = value,
			Dad = value2
		});
		for (int j = 1; j < 3; j++)
		{
			SharedEdge edge = GetEdge(quad[j - 1], quad[j]);
			if (!edge._0023_003DzhF_UisQ_003D(value4, value) && !edge._0023_003DzhF_UisQ_003D(value3, value))
			{
				edge._0023_003DzhF_UisQ_003D(value2, value);
			}
		}
		for (int k = 3; k < 5; k++)
		{
			SharedEdge edge2 = GetEdge(quad[k - 1], quad[k % 4]);
			if (!edge2._0023_003DzhF_UisQ_003D(value4, value2) && !edge2._0023_003DzhF_UisQ_003D(value3, value2))
			{
				edge2._0023_003DzhF_UisQ_003D(value, value2);
			}
		}
		if (_0023_003DzNOJaEu0_003D() != 0)
		{
			throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989592));
		}
		return true;
	}

	public bool Dissolvable3(int vertex)
	{
		int v;
		int v2;
		int v3;
		return Dissolvable3(vertex, out v, out v2, out v3);
	}

	public bool Dissolvable3(int vertex, out int v1, out int v2, out int v3)
	{
		v1 = (v2 = (v3 = -1));
		if (_0023_003DzVADK_00243zQ_xucjCTCgQ_003D_003D[vertex].Count != 3)
		{
			return false;
		}
		LinkedListNode<int> first = _0023_003DzVADK_00243zQ_xucjCTCgQ_003D_003D[vertex].First;
		IndexTriangle _0023_003DznnnQx3RwjThsBRPB9w_003D_003D = Triangles[first.Value];
		IndexTriangle first2 = Triangles[(first = first.Next).Value];
		IndexTriangle second = Triangles[first.Next.Value];
		v1 = _0023_003DznnnQx3RwjThsBRPB9w_003D_003D._0023_003Dzg_0024_0024HtRw_003D(vertex);
		v2 = _0023_003DznnnQx3RwjThsBRPB9w_003D_003D._0023_003DzMqZZWVg_003D(vertex);
		if (!first2._0023_003DzXscMLpk_003D(v2))
		{
			Utility.Swap(ref first2, ref second);
		}
		if (!first2._0023_003DzXscMLpk_003D(v2))
		{
			return false;
		}
		v3 = first2._0023_003Dzg_0024_0024HtRw_003D(v2);
		if (second._0023_003Dzg_0024_0024HtRw_003D(vertex) == v3)
		{
			return second._0023_003DzMqZZWVg_003D(vertex) == v1;
		}
		return false;
	}

	public bool Dissolve3(int vertex)
	{
		if (!Dissolvable3(vertex, out var v, out var v2, out var v3))
		{
			return false;
		}
		LinkedListNode<int> first = _0023_003DzVADK_00243zQ_xucjCTCgQ_003D_003D[vertex].First;
		int value = first.Value;
		LinkedListNode<int> next = first.Next;
		int value2 = next.Value;
		int value3 = next.Next.Value;
		IndexTriangle indexTriangle = Triangles[value];
		_0023_003Dzi5O3kJahwYwD(value2, _0023_003DzWk2X_g_pf229: true);
		_0023_003Dzi5O3kJahwYwD(value3, _0023_003DzWk2X_g_pf229: true);
		_0023_003Dz_0024nDSZHUDGsWV(vertex);
		indexTriangle.V1 = v;
		indexTriangle.V2 = v2;
		indexTriangle.V3 = v3;
		_0023_003DzVADK_00243zQ_xucjCTCgQ_003D_003D[v3].AddLast(value);
		_0023_003DzVADK_00243zQ_xucjCTCgQ_003D_003D[vertex].Clear();
		_0023_003Dzi8wSwVcEjI99[vertex].Clear();
		_0023_003DzgXM2klc_003D(_0023_003Dzi8wSwVcEjI99[v], vertex);
		_0023_003DzgXM2klc_003D(_0023_003Dzi8wSwVcEjI99[v2], vertex);
		_0023_003DzgXM2klc_003D(_0023_003Dzi8wSwVcEjI99[v3], vertex);
		SharedEdge edge = GetEdge(v2, v3);
		SharedEdge edge2 = GetEdge(v3, v);
		if (edge._0023_003DzhF_UisQ_003D(value2, value))
		{
			edge2._0023_003DzhF_UisQ_003D(value3, value);
		}
		else
		{
			edge._0023_003DzhF_UisQ_003D(value3, value);
			edge2._0023_003DzhF_UisQ_003D(value2, value);
		}
		if (_0023_003DzNOJaEu0_003D() != 0)
		{
			throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989592));
		}
		return true;
	}

	public bool Collapse(int v1, int v2, Point3D newPosition = null)
	{
		int v3;
		SharedEdge edge = GetEdge(v1, v2, out v3);
		if (edge != null)
		{
			return Collapse(v3, edge, newPosition);
		}
		return false;
	}

	public bool Collapse(int v1, SharedEdge edge, Point3D newPosition = null)
	{
		if (newPosition == null)
		{
			newPosition = (Vertices[v1] + Vertices[edge.V2]) / 2.0;
		}
		int num = Triangles[edge.Mum]._0023_003DzI2fnrdw_003D(v1, edge.V2);
		if (_0023_003DzJpZBzgM_003D(v1, edge.V2) > ((edge.Dad <= -1) ? 1 : 2))
		{
			return false;
		}
		if (_0023_003DzVADK_00243zQ_xucjCTCgQ_003D_003D[num].Count == 1)
		{
			return false;
		}
		_0023_003DzoJbmpvH3qHaD _0023_003Dzjm85u4E_003D = _0023_003DzV9H2g8hVQorP(v1, num, edge.V2);
		if (!_0023_003Dzjm85u4E_003D._0023_003DzVtaVpwk_003D())
		{
			return false;
		}
		if (edge.Dad > -1)
		{
			int num2 = Triangles[edge.Dad]._0023_003DzI2fnrdw_003D(v1, edge.V2);
			if (_0023_003DzVADK_00243zQ_xucjCTCgQ_003D_003D[num2].Count == 1)
			{
				return false;
			}
			_0023_003DzoJbmpvH3qHaD _0023_003Dzjm85u4E_003D2 = _0023_003DzV9H2g8hVQorP(v1, num2, edge.V2);
			if (!_0023_003Dzjm85u4E_003D2._0023_003DzVtaVpwk_003D())
			{
				return false;
			}
			_0023_003Dzi5O3kJahwYwD(edge.Dad, _0023_003DzWk2X_g_pf229: true);
			_0023_003DzyH5GeTBFx6Dn(_0023_003Dzjm85u4E_003D2);
		}
		_0023_003Dzi5O3kJahwYwD(edge.Mum, _0023_003DzWk2X_g_pf229: true);
		_0023_003DzyH5GeTBFx6Dn(_0023_003Dzjm85u4E_003D);
		_0023_003Dz_0024nDSZHUDGsWV(edge.V2);
		_0023_003Dzi8wSwVcEjI99[v1].Remove(edge);
		_0023_003DzrexOuiI_003D(edge.V2, v1);
		_0023_003DzVADK_00243zQ_xucjCTCgQ_003D_003D[edge.V2].Clear();
		Vertices[v1] = newPosition;
		if (_0023_003DzNOJaEu0_003D() != 0)
		{
			throw new Exception();
		}
		return true;
	}

	public void Apply(bool updateData = true)
	{
		Apply(out var _, out var _, updateData);
	}

	public void Apply(out NullMap vertexMap, out NullMap triangleMap, bool updateData = true)
	{
		_0023_003DzLwMfQ4FStYIc3oDNag_003D_003D(NullMap.RemoveNulls(Vertices, _0023_003DzBGfisEH3_fwG, out vertexMap));
		_0023_003Dzg8NPq_0024Bv7ANvyfVpbA_003D_003D(NullMap.RemoveNulls(Triangles, _0023_003DzbnsaKPfMhr1s, out triangleMap));
		IndexTriangle[] triangles = Triangles;
		foreach (IndexTriangle indexTriangle in triangles)
		{
			indexTriangle.V1 = vertexMap.Map(indexTriangle.V1);
			indexTriangle.V2 = vertexMap.Map(indexTriangle.V2);
			indexTriangle.V3 = vertexMap.Map(indexTriangle.V3);
		}
		if (updateData)
		{
			_0023_003Dz_ll_40k_003D();
		}
	}

	public bool IsVertexDead(int vertex)
	{
		return (object)Vertices[vertex] == _0023_003DzBGfisEH3_fwG;
	}

	public bool IsTriangleDead(int triangle)
	{
		return (object)Triangles[triangle] == _0023_003DzbnsaKPfMhr1s;
	}

	private void _0023_003Dzi5O3kJahwYwD(int _0023_003DznnnQx3RwjThsBRPB9w_003D_003D, bool _0023_003DzWk2X_g_pf229)
	{
		IndexTriangle indexTriangle = Triangles[_0023_003DznnnQx3RwjThsBRPB9w_003D_003D];
		_0023_003DzVADK_00243zQ_xucjCTCgQ_003D_003D[indexTriangle.V1].Remove(_0023_003DznnnQx3RwjThsBRPB9w_003D_003D);
		_0023_003DzVADK_00243zQ_xucjCTCgQ_003D_003D[indexTriangle.V2].Remove(_0023_003DznnnQx3RwjThsBRPB9w_003D_003D);
		_0023_003DzVADK_00243zQ_xucjCTCgQ_003D_003D[indexTriangle.V3].Remove(_0023_003DznnnQx3RwjThsBRPB9w_003D_003D);
		if (_0023_003DzWk2X_g_pf229)
		{
			Triangles[_0023_003DznnnQx3RwjThsBRPB9w_003D_003D] = _0023_003DzbnsaKPfMhr1s;
		}
	}

	public void DeleteTriangle(int triangle, bool keepOrphans = false)
	{
		IndexTriangle indexTriangle = Triangles[triangle];
		_0023_003Dzg37Vwc8fEFIl(triangle, indexTriangle.V1, indexTriangle.V2);
		_0023_003Dzg37Vwc8fEFIl(triangle, indexTriangle.V2, indexTriangle.V3);
		_0023_003Dzg37Vwc8fEFIl(triangle, indexTriangle.V3, indexTriangle.V1);
		if (!keepOrphans)
		{
			if (Adjacency[indexTriangle.V1].Count == 1)
			{
				_0023_003Dz_0024nDSZHUDGsWV(indexTriangle.V1);
			}
			if (Adjacency[indexTriangle.V2].Count == 1)
			{
				_0023_003Dz_0024nDSZHUDGsWV(indexTriangle.V2);
			}
			if (Adjacency[indexTriangle.V3].Count == 1)
			{
				_0023_003Dz_0024nDSZHUDGsWV(indexTriangle.V3);
			}
		}
		_0023_003Dzi5O3kJahwYwD(triangle, _0023_003DzWk2X_g_pf229: true);
	}

	private void _0023_003Dzg37Vwc8fEFIl(int _0023_003DzEzv5_0024vo_003D, int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D)
	{
		SharedEdge edge = GetEdge(_0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, out _0023_003DzffqPLNQ_003D);
		if (edge.Mum == _0023_003DzEzv5_0024vo_003D)
		{
			Utility.Swap(ref edge.Mum, ref edge.Dad);
		}
		if (edge.Dad == _0023_003DzEzv5_0024vo_003D)
		{
			edge.Dad = -1;
		}
		if (edge.Mum < 0)
		{
			_0023_003DzgXM2klc_003D(_0023_003Dzi8wSwVcEjI99[_0023_003DzffqPLNQ_003D], edge.V2);
		}
	}

	public void ReplaceTriangle(int i, IndexTriangle triangle)
	{
		if (!IsTriangleDead(i))
		{
			throw new ArgumentException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989577), i) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989762), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989719));
		}
		Triangles[i] = triangle;
		_0023_003Dz7C7GRAA18v39(i);
		if (!_0023_003Dzxc2pSHY_003D(i, triangle.V1, triangle.V2) || !_0023_003Dzxc2pSHY_003D(i, triangle.V2, triangle.V3) || !_0023_003Dzxc2pSHY_003D(i, triangle.V3, triangle.V1))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989700), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989316));
		}
	}

	public void DeleteOrphanVertex(int v)
	{
		if (Adjacency[v].Any())
		{
			throw new ArgumentException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302989325), v));
		}
		_0023_003Dz_0024nDSZHUDGsWV(v);
	}

	private bool _0023_003Dzxc2pSHY_003D(int _0023_003DzEzv5_0024vo_003D, int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D)
	{
		int v;
		SharedEdge edge = GetEdge(_0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, out v);
		if (edge == null)
		{
			SharedEdges[_0023_003DzffqPLNQ_003D].AddFirst(new SharedEdge
			{
				Mum = _0023_003DzEzv5_0024vo_003D,
				V2 = _0023_003Dz5Azd7L8_003D
			});
			return true;
		}
		if (edge.Dad >= 0)
		{
			return false;
		}
		edge.Dad = _0023_003DzEzv5_0024vo_003D;
		return true;
	}

	private void _0023_003Dz_0024nDSZHUDGsWV(int _0023_003DzkEYxO1SuR1Kw)
	{
		Vertices[_0023_003DzkEYxO1SuR1Kw] = _0023_003DzBGfisEH3_fwG;
	}

	private void _0023_003DzgXM2klc_003D(LinkedList<SharedEdge> _0023_003DzU3hosSAzkxO7, int _0023_003Dz5Azd7L8_003D)
	{
		foreach (SharedEdge item in _0023_003DzU3hosSAzkxO7)
		{
			if (item.V2 == _0023_003Dz5Azd7L8_003D)
			{
				_0023_003DzU3hosSAzkxO7.Remove(item);
				break;
			}
		}
	}

	private int _0023_003DzJpZBzgM_003D(int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D)
	{
		HashSet<int> hashSet = Connected(_0023_003Dz5Azd7L8_003D);
		int num = 0;
		foreach (int item in Connected(_0023_003DzffqPLNQ_003D))
		{
			if (hashSet.Contains(item))
			{
				num++;
			}
		}
		return num;
	}

	private _0023_003DzoJbmpvH3qHaD _0023_003DzV9H2g8hVQorP(int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D, int _0023_003DzZe6oCrQ_003D)
	{
		int v;
		SharedEdge edge = GetEdge(_0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, out v);
		int v2;
		SharedEdge edge2 = GetEdge(_0023_003Dz5Azd7L8_003D, _0023_003DzZe6oCrQ_003D, out v2);
		return new _0023_003DzoJbmpvH3qHaD(v2, edge, edge2);
	}

	private void _0023_003DzyH5GeTBFx6Dn(_0023_003DzoJbmpvH3qHaD _0023_003Dzjm85u4E_003D)
	{
		_0023_003Dzi8wSwVcEjI99[_0023_003Dzjm85u4E_003D._0023_003Dz61IPlm0_003D].Remove(_0023_003Dzjm85u4E_003D._0023_003DzGZKh520_003D);
		if (_0023_003Dzjm85u4E_003D._0023_003DzDBy2B88_003D.Mum == _0023_003Dzjm85u4E_003D._0023_003DzGZKh520_003D.Mum)
		{
			_0023_003Dzjm85u4E_003D._0023_003DzDBy2B88_003D.Mum = _0023_003Dzjm85u4E_003D._0023_003DzGZKh520_003D.Dad;
		}
		else if (_0023_003Dzjm85u4E_003D._0023_003DzDBy2B88_003D.Mum == _0023_003Dzjm85u4E_003D._0023_003DzGZKh520_003D.Dad)
		{
			_0023_003Dzjm85u4E_003D._0023_003DzDBy2B88_003D.Mum = _0023_003Dzjm85u4E_003D._0023_003DzGZKh520_003D.Mum;
		}
		else if (_0023_003Dzjm85u4E_003D._0023_003DzDBy2B88_003D.Dad == _0023_003Dzjm85u4E_003D._0023_003DzGZKh520_003D.Mum)
		{
			_0023_003Dzjm85u4E_003D._0023_003DzDBy2B88_003D.Dad = _0023_003Dzjm85u4E_003D._0023_003DzGZKh520_003D.Dad;
		}
		else if (_0023_003Dzjm85u4E_003D._0023_003DzDBy2B88_003D.Dad == _0023_003Dzjm85u4E_003D._0023_003DzGZKh520_003D.Dad)
		{
			_0023_003Dzjm85u4E_003D._0023_003DzDBy2B88_003D.Dad = _0023_003Dzjm85u4E_003D._0023_003DzGZKh520_003D.Mum;
		}
		if (_0023_003Dzjm85u4E_003D._0023_003DzDBy2B88_003D.Mum < 0)
		{
			Utility.Swap(ref _0023_003Dzjm85u4E_003D._0023_003DzDBy2B88_003D.Mum, ref _0023_003Dzjm85u4E_003D._0023_003DzDBy2B88_003D.Dad);
		}
		_0023_003Dzjm85u4E_003D._0023_003DzGZKh520_003D.Mum = -1;
	}

	private void _0023_003DzrexOuiI_003D(int _0023_003DzAJYZcKw_003D, int _0023_003DzqhsKlJc_003D)
	{
		LinkedList<SharedEdge> linkedList = _0023_003Dzi8wSwVcEjI99[_0023_003DzAJYZcKw_003D];
		LinkedListNode<SharedEdge> first;
		while ((first = linkedList.First) != null)
		{
			linkedList.Remove(first);
			_0023_003Dzi8wSwVcEjI99[_0023_003DzqhsKlJc_003D].AddLast(first);
		}
		foreach (int item in _0023_003DzVADK_00243zQ_xucjCTCgQ_003D_003D[_0023_003DzAJYZcKw_003D])
		{
			IndexTriangle _0023_003DznnnQx3RwjThsBRPB9w_003D_003D = Triangles[item];
			var (num, num2) = _0023_003DznnnQx3RwjThsBRPB9w_003D_003D._0023_003DzI2fnrdw_003D(_0023_003DzAJYZcKw_003D);
			_0023_003DzrexOuiI_003D(_0023_003Dzi8wSwVcEjI99[num], _0023_003DzAJYZcKw_003D, _0023_003DzqhsKlJc_003D);
			_0023_003DzrexOuiI_003D(_0023_003Dzi8wSwVcEjI99[num2], _0023_003DzAJYZcKw_003D, _0023_003DzqhsKlJc_003D);
			_0023_003DznnnQx3RwjThsBRPB9w_003D_003D._0023_003DzhF_UisQ_003D(_0023_003DzAJYZcKw_003D, _0023_003DzqhsKlJc_003D);
			_0023_003DzVADK_00243zQ_xucjCTCgQ_003D_003D[_0023_003DzqhsKlJc_003D].AddLast(item);
		}
	}

	private void _0023_003DzrexOuiI_003D(LinkedList<SharedEdge> _0023_003DzcDEsV8s_003D, int _0023_003DzAJYZcKw_003D, int _0023_003DzqhsKlJc_003D)
	{
		for (LinkedListNode<SharedEdge> linkedListNode = _0023_003DzcDEsV8s_003D.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
		{
			SharedEdge value = linkedListNode.Value;
			if (value.V2 == _0023_003DzAJYZcKw_003D)
			{
				value.V2 = _0023_003DzqhsKlJc_003D;
				break;
			}
		}
	}

	private int _0023_003DzNOJaEu0_003D()
	{
		return 0;
	}
}
