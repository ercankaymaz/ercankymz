using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using SharpGLTF.Animations;

namespace SharpGLTF.Transforms;

[DebuggerDisplay("{_GetDebuggerDisplay(),nq}")]
public readonly struct SparseWeight8 : IEquatable<SparseWeight8>
{
	public readonly int Index0;

	public readonly float Weight0;

	public readonly int Index1;

	public readonly float Weight1;

	public readonly int Index2;

	public readonly float Weight2;

	public readonly int Index3;

	public readonly float Weight3;

	public readonly int Index4;

	public readonly float Weight4;

	public readonly int Index5;

	public readonly float Weight5;

	public readonly int Index6;

	public readonly float Weight6;

	public readonly int Index7;

	public readonly float Weight7;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public int Count => GetExpandedCount();

	public float this[int index] => GetExpandedAt(index);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public bool IsWeightless => (Weight0 == 0f) & (Weight1 == 0f) & (Weight2 == 0f) & (Weight3 == 0f) & (Weight4 == 0f) & (Weight5 == 0f) & (Weight6 == 0f) & (Weight7 == 0f);

	public float WeightSum => Weight0 + Weight1 + Weight2 + Weight3 + Weight4 + Weight5 + Weight6 + Weight7;

	public int MaxIndex => _GetMaxIndex();

	private string _GetDebuggerDisplay()
	{
		IEnumerable<string> values = from item in GetNonZeroWeights()
			select $"[{item.Index}]={item.Weight}";
		string text = string.Join(" ", values);
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		return "Empty";
	}

	public static SparseWeight8 Create(params float[] weights)
	{
		return Create((IEnumerable<float>)weights);
	}

	public static SparseWeight8 Create(IEnumerable<float> weights)
	{
		if (weights == null)
		{
			return default(SparseWeight8);
		}
		Span<IndexWeight> span = stackalloc IndexWeight[8];
		int num = 0;
		int length = 0;
		foreach (float weight in weights)
		{
			if (weight != 0f)
			{
				length = IndexWeight.InsertUnsorted(span, length, (Index: num, Weight: weight));
			}
			num++;
		}
		return new SparseWeight8(span);
	}

	public static SparseWeight8 Create(params (int Index, float Weight)[] indexedWeights)
	{
		return Create((IEnumerable<(int Index, float Weight)>)indexedWeights);
	}

	public static SparseWeight8 Create(IEnumerable<(int Index, float Weight)> indexedWeights)
	{
		if (indexedWeights == null)
		{
			return default(SparseWeight8);
		}
		Span<IndexWeight> span = stackalloc IndexWeight[8];
		int length = 0;
		foreach (var indexedWeight in indexedWeights)
		{
			if (indexedWeight.Weight != 0f)
			{
				length = IndexWeight.InsertUnsorted(span, length, indexedWeight);
			}
		}
		return new SparseWeight8(span);
	}

	public static SparseWeight8 Create(in Vector4 idx0123, in Vector4 wgt0123)
	{
		Span<IndexWeight> span = stackalloc IndexWeight[8];
		IndexWeight.InsertUnsorted(span, in idx0123, in wgt0123);
		return new SparseWeight8(span);
	}

	public static SparseWeight8 Create(in Vector4 idx0123, in Vector4 idx4567, in Vector4 wgt0123, in Vector4 wgt4567)
	{
		Span<IndexWeight> span = stackalloc IndexWeight[8];
		int length = IndexWeight.InsertUnsorted(span, in idx0123, in wgt0123);
		length = IndexWeight.InsertUnsorted(span, length, (Index: (int)idx4567.X, Weight: wgt4567.X));
		length = IndexWeight.InsertUnsorted(span, length, (Index: (int)idx4567.Y, Weight: wgt4567.Y));
		length = IndexWeight.InsertUnsorted(span, length, (Index: (int)idx4567.Z, Weight: wgt4567.Z));
		length = IndexWeight.InsertUnsorted(span, length, (Index: (int)idx4567.W, Weight: wgt4567.W));
		return new SparseWeight8(span);
	}

	public static SparseWeight8 CreateUnchecked(in Vector4 idx0123, in Vector4 idx4567, in Vector4 wgt0123, in Vector4 wgt4567)
	{
		return new SparseWeight8(in idx0123, in idx4567, in wgt0123, in wgt4567);
	}

	private SparseWeight8(in Vector4 idx0123, in Vector4 idx4567, in Vector4 wgt0123, in Vector4 wgt4567)
	{
		Index0 = (int)idx0123.X;
		Index1 = (int)idx0123.Y;
		Index2 = (int)idx0123.Z;
		Index3 = (int)idx0123.W;
		Index4 = (int)idx4567.X;
		Index5 = (int)idx4567.Y;
		Index6 = (int)idx4567.Z;
		Index7 = (int)idx4567.W;
		Weight0 = wgt0123.X;
		Weight1 = wgt0123.Y;
		Weight2 = wgt0123.Z;
		Weight3 = wgt0123.W;
		Weight4 = wgt4567.X;
		Weight5 = wgt4567.Y;
		Weight6 = wgt4567.Z;
		Weight7 = wgt4567.W;
	}

	private SparseWeight8(ReadOnlySpan<IndexWeight> iw)
	{
		Index0 = iw[0].Index;
		Weight0 = iw[0].Weight;
		Index1 = iw[1].Index;
		Weight1 = iw[1].Weight;
		Index2 = iw[2].Index;
		Weight2 = iw[2].Weight;
		Index3 = iw[3].Index;
		Weight3 = iw[3].Weight;
		Index4 = iw[4].Index;
		Weight4 = iw[4].Weight;
		Index5 = iw[5].Index;
		Weight5 = iw[5].Weight;
		Index6 = iw[6].Index;
		Weight6 = iw[6].Weight;
		Index7 = iw[7].Index;
		Weight7 = iw[7].Weight;
	}

	private SparseWeight8(in SparseWeight8 sparse, float scale)
	{
		Index0 = sparse.Index0;
		Index1 = sparse.Index1;
		Index2 = sparse.Index2;
		Index3 = sparse.Index3;
		Index4 = sparse.Index4;
		Index5 = sparse.Index5;
		Index6 = sparse.Index6;
		Index7 = sparse.Index7;
		Weight0 = sparse.Weight0 * scale;
		Weight1 = sparse.Weight1 * scale;
		Weight2 = sparse.Weight2 * scale;
		Weight3 = sparse.Weight3 * scale;
		Weight4 = sparse.Weight4 * scale;
		Weight5 = sparse.Weight5 * scale;
		Weight6 = sparse.Weight6 * scale;
		Weight7 = sparse.Weight7 * scale;
	}

	public override int GetHashCode()
	{
		float num = 0f;
		float num2 = Math.Abs(Weight0);
		if (num2 > num)
		{
			num = num2;
		}
		num2 = Math.Abs(Weight1);
		if (num2 > num)
		{
			num = num2;
		}
		num2 = Math.Abs(Weight2);
		if (num2 > num)
		{
			num = num2;
		}
		num2 = Math.Abs(Weight3);
		if (num2 > num)
		{
			num = num2;
		}
		num2 = Math.Abs(Weight4);
		if (num2 > num)
		{
			num = num2;
		}
		num2 = Math.Abs(Weight5);
		if (num2 > num)
		{
			num = num2;
		}
		num2 = Math.Abs(Weight6);
		if (num2 > num)
		{
			num = num2;
		}
		num2 = Math.Abs(Weight7);
		if (num2 > num)
		{
			num = num2;
		}
		return num.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is SparseWeight8 y)
		{
			return AreEqual(this, in y);
		}
		return false;
	}

	public bool Equals(SparseWeight8 other)
	{
		return AreEqual(this, in other);
	}

	public static bool operator ==(SparseWeight8 left, SparseWeight8 right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(SparseWeight8 left, SparseWeight8 right)
	{
		return !left.Equals(right);
	}

	internal static bool AreEqual(in SparseWeight8 x, in SparseWeight8 y)
	{
		Span<IndexWeight> dst = stackalloc IndexWeight[8];
		Span<IndexWeight> dst2 = stackalloc IndexWeight[8];
		x.CopyTo(dst);
		y.CopyTo(dst2);
		for (int i = 0; i < 8; i++)
		{
			IndexWeight indexWeight = dst[i];
			if (indexWeight.Weight == 0f)
			{
				continue;
			}
			bool flag = false;
			for (int j = 0; j < 8; j++)
			{
				IndexWeight indexWeight2 = dst2[j];
				if (indexWeight2.Weight != 0f && indexWeight.Index == indexWeight2.Index)
				{
					if (indexWeight.Weight != indexWeight2.Weight)
					{
						return false;
					}
					dst2[j] = default(IndexWeight);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return false;
			}
		}
		for (int k = 0; k < 8; k++)
		{
			if (dst2[k].Weight != 0f)
			{
				return false;
			}
		}
		return true;
	}

	public static SparseWeight8 OrderedByWeight(in SparseWeight8 sparse)
	{
		Span<IndexWeight> span = stackalloc IndexWeight[8];
		span[0] = (Index: sparse.Index0, Weight: sparse.Weight0);
		span[1] = (Index: sparse.Index1, Weight: sparse.Weight1);
		span[2] = (Index: sparse.Index2, Weight: sparse.Weight2);
		span[3] = (Index: sparse.Index3, Weight: sparse.Weight3);
		span[4] = (Index: sparse.Index4, Weight: sparse.Weight4);
		span[5] = (Index: sparse.Index5, Weight: sparse.Weight5);
		span[6] = (Index: sparse.Index6, Weight: sparse.Weight6);
		span[7] = (Index: sparse.Index7, Weight: sparse.Weight7);
		IndexWeight.BubbleSortByWeight(span);
		return new SparseWeight8(span);
	}

	public static SparseWeight8 OrderedByIndex(in SparseWeight8 sparse)
	{
		Span<IndexWeight> span = stackalloc IndexWeight[8];
		IndexWeight.BubbleSortByIndex(span[..sparse.InsertTo(span)]);
		return new SparseWeight8(span);
	}

	public static SparseWeight8 Add(in SparseWeight8 x, in SparseWeight8 y)
	{
		return _OperateLinear(in x, in y, (float xx, float yy) => xx + yy);
	}

	public static SparseWeight8 Subtract(in SparseWeight8 x, in SparseWeight8 y)
	{
		return _OperateLinear(in x, in y, (float xx, float yy) => xx - yy);
	}

	public static SparseWeight8 Multiply(in SparseWeight8 x, in SparseWeight8 y)
	{
		return _OperateLinear(in x, in y, (float xx, float yy) => xx * yy);
	}

	public static SparseWeight8 Multiply(in SparseWeight8 x, float y)
	{
		return new SparseWeight8(in x, y);
	}

	public static SparseWeight8 InterpolateLinear(in SparseWeight8 x, in SparseWeight8 y, float amount)
	{
		float xAmount = 1f - amount;
		float yAmount = amount;
		return _OperateLinear(in x, in y, (float xx, float yy) => xx * xAmount + yy * yAmount);
	}

	public static SparseWeight8 InterpolateCubic(in SparseWeight8 x, in SparseWeight8 xt, in SparseWeight8 y, in SparseWeight8 yt, float amount)
	{
		(float StartPosition, float EndPosition, float StartTangent, float EndTangent) basis = CurveSampler.CreateHermitePointWeights(amount);
		return _OperateCubic(in x, in xt, in y, in yt, (float xx, float xxt, float yy, float yyt) => xx * basis.StartPosition + yy * basis.EndPosition + xxt * basis.StartTangent + yyt * basis.EndTangent);
	}

	public IEnumerable<float> Expand(int count)
	{
		int i = 0;
		while (i < count)
		{
			yield return GetExpandedAt(i);
			int num = i + 1;
			i = num;
		}
	}

	public IEnumerable<(int Index, float Weight)> GetIndexedWeights()
	{
		yield return (Index: Index0, Weight: Weight0);
		yield return (Index: Index1, Weight: Weight1);
		yield return (Index: Index2, Weight: Weight2);
		yield return (Index: Index3, Weight: Weight3);
		yield return (Index: Index4, Weight: Weight4);
		yield return (Index: Index5, Weight: Weight5);
		yield return (Index: Index6, Weight: Weight6);
		yield return (Index: Index7, Weight: Weight7);
	}

	public IEnumerable<(int Index, float Weight)> GetNonZeroWeights()
	{
		if (Weight0 != 0f)
		{
			yield return (Index: Index0, Weight: Weight0);
		}
		if (Weight1 != 0f)
		{
			yield return (Index: Index1, Weight: Weight1);
		}
		if (Weight2 != 0f)
		{
			yield return (Index: Index2, Weight: Weight2);
		}
		if (Weight3 != 0f)
		{
			yield return (Index: Index3, Weight: Weight3);
		}
		if (Weight4 != 0f)
		{
			yield return (Index: Index4, Weight: Weight4);
		}
		if (Weight5 != 0f)
		{
			yield return (Index: Index5, Weight: Weight5);
		}
		if (Weight6 != 0f)
		{
			yield return (Index: Index6, Weight: Weight6);
		}
		if (Weight7 != 0f)
		{
			yield return (Index: Index7, Weight: Weight7);
		}
	}

	public static SparseWeight8 Blend(ReadOnlySpan<SparseWeight8> sparses, ReadOnlySpan<float> weight)
	{
		SparseWeight8 x = default(SparseWeight8);
		for (int i = 0; i < sparses.Length; i++)
		{
			if (!sparses[i].IsWeightless)
			{
				x = Add(in x, Multiply(in sparses[i], weight[i]));
			}
		}
		return x;
	}

	public SparseWeight8 GetTrimmed(int maxWeights)
	{
		Span<IndexWeight> span = stackalloc IndexWeight[8];
		InsertTo(span.Slice(0, maxWeights));
		return new SparseWeight8(span);
	}

	public SparseWeight8 GetNormalized()
	{
		return Multiply(this, 1f / WeightSum);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		int count = Count;
		for (int i = 0; i < count; i++)
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append(' ');
			}
			stringBuilder.Append(this[i]);
		}
		return stringBuilder.ToString();
	}

	private static SparseWeight8 _OperateLinear(in SparseWeight8 x, in SparseWeight8 y, Func<float, float, float> operationFunc)
	{
		Span<int> dstIndices = stackalloc int[16];
		Span<float> dstWeights = stackalloc float[16];
		Span<float> dstWeights2 = stackalloc float[16];
		int dstLength = 0;
		dstLength = IndexWeight.CopyTo(in x, dstIndices, dstWeights, dstLength);
		dstLength = IndexWeight.CopyTo(in y, dstIndices, dstWeights2, dstLength);
		int length = 0;
		Span<IndexWeight> span = stackalloc IndexWeight[8];
		for (int i = 0; i < dstLength; i++)
		{
			float num = operationFunc(dstWeights[i], dstWeights2[i]);
			if (num != 0f)
			{
				length = IndexWeight.InsertUnsorted(span, length, (Index: dstIndices[i], Weight: num));
			}
		}
		return new SparseWeight8(span);
	}

	private static SparseWeight8 _OperateCubic(in SparseWeight8 x, in SparseWeight8 y, in SparseWeight8 z, in SparseWeight8 w, Func<float, float, float, float, float> operationFunc)
	{
		Span<int> dstIndices = stackalloc int[32];
		Span<float> dstWeights = stackalloc float[32];
		Span<float> dstWeights2 = stackalloc float[32];
		Span<float> dstWeights3 = stackalloc float[32];
		Span<float> dstWeights4 = stackalloc float[32];
		int dstLength = 0;
		dstLength = IndexWeight.CopyTo(in x, dstIndices, dstWeights, dstLength);
		dstLength = IndexWeight.CopyTo(in y, dstIndices, dstWeights2, dstLength);
		dstLength = IndexWeight.CopyTo(in z, dstIndices, dstWeights3, dstLength);
		dstLength = IndexWeight.CopyTo(in w, dstIndices, dstWeights4, dstLength);
		int length = 0;
		Span<IndexWeight> span = stackalloc IndexWeight[8];
		for (int i = 0; i < dstLength; i++)
		{
			float num = operationFunc(dstWeights[i], dstWeights2[i], dstWeights3[i], dstWeights4[i]);
			if (num != 0f)
			{
				length = IndexWeight.InsertUnsorted(span, length, (Index: dstIndices[i], Weight: num));
			}
		}
		return new SparseWeight8(span);
	}

	private float GetExpandedAt(int idx)
	{
		if (idx == Index0)
		{
			return Weight0;
		}
		if (idx == Index1)
		{
			return Weight1;
		}
		if (idx == Index2)
		{
			return Weight2;
		}
		if (idx == Index3)
		{
			return Weight3;
		}
		if (idx == Index4)
		{
			return Weight4;
		}
		if (idx == Index5)
		{
			return Weight5;
		}
		if (idx == Index6)
		{
			return Weight6;
		}
		if (idx == Index7)
		{
			return Weight7;
		}
		return 0f;
	}

	private int GetExpandedCount()
	{
		int num = 0;
		if (Weight0 != 0f && num <= Index0)
		{
			num = Index0 + 1;
		}
		if (Weight1 != 0f && num <= Index1)
		{
			num = Index1 + 1;
		}
		if (Weight2 != 0f && num <= Index2)
		{
			num = Index2 + 1;
		}
		if (Weight3 != 0f && num <= Index3)
		{
			num = Index3 + 1;
		}
		if (Weight4 != 0f && num <= Index4)
		{
			num = Index4 + 1;
		}
		if (Weight5 != 0f && num <= Index5)
		{
			num = Index5 + 1;
		}
		if (Weight6 != 0f && num <= Index6)
		{
			num = Index6 + 1;
		}
		if (Weight7 != 0f && num <= Index7)
		{
			num = Index7 + 1;
		}
		return num;
	}

	internal SparseWeight8 GetNormalizedWithComplement(int complementIndex)
	{
		float weightSum = WeightSum;
		if (weightSum >= 1f)
		{
			return this;
		}
		Span<IndexWeight> span = stackalloc IndexWeight[8];
		int length = InsertTo(span);
		length = IndexWeight.InsertUnsorted(span, length, new IndexWeight(complementIndex, 1f - weightSum));
		return new SparseWeight8(span);
	}

	internal int _GetMaxIndex()
	{
		int num = 0;
		if (Weight0 != 0f)
		{
			num = Math.Max(num, Index0);
		}
		if (Weight1 != 0f)
		{
			num = Math.Max(num, Index1);
		}
		if (Weight2 != 0f)
		{
			num = Math.Max(num, Index2);
		}
		if (Weight3 != 0f)
		{
			num = Math.Max(num, Index3);
		}
		if (Weight4 != 0f)
		{
			num = Math.Max(num, Index4);
		}
		if (Weight5 != 0f)
		{
			num = Math.Max(num, Index5);
		}
		if (Weight6 != 0f)
		{
			num = Math.Max(num, Index6);
		}
		if (Weight7 != 0f)
		{
			num = Math.Max(num, Index7);
		}
		return num;
	}

	internal IEnumerable<IndexWeight> _GetPairs()
	{
		if (Weight0 != 0f)
		{
			yield return new IndexWeight(Index0, Weight0);
		}
		if (Weight1 != 0f)
		{
			yield return new IndexWeight(Index1, Weight1);
		}
		if (Weight2 != 0f)
		{
			yield return new IndexWeight(Index2, Weight2);
		}
		if (Weight3 != 0f)
		{
			yield return new IndexWeight(Index3, Weight3);
		}
		if (Weight4 != 0f)
		{
			yield return new IndexWeight(Index4, Weight4);
		}
		if (Weight5 != 0f)
		{
			yield return new IndexWeight(Index5, Weight5);
		}
		if (Weight6 != 0f)
		{
			yield return new IndexWeight(Index6, Weight6);
		}
		if (Weight7 != 0f)
		{
			yield return new IndexWeight(Index7, Weight7);
		}
	}

	internal int InsertTo(Span<IndexWeight> dst)
	{
		int num = 0;
		if (Weight0 != 0f)
		{
			num = IndexWeight.InsertUnsorted(dst, num, (Index: Index0, Weight: Weight0));
		}
		if (Weight1 != 0f)
		{
			num = IndexWeight.InsertUnsorted(dst, num, (Index: Index1, Weight: Weight1));
		}
		if (Weight2 != 0f)
		{
			num = IndexWeight.InsertUnsorted(dst, num, (Index: Index2, Weight: Weight2));
		}
		if (Weight3 != 0f)
		{
			num = IndexWeight.InsertUnsorted(dst, num, (Index: Index3, Weight: Weight3));
		}
		if (Weight4 != 0f)
		{
			num = IndexWeight.InsertUnsorted(dst, num, (Index: Index4, Weight: Weight4));
		}
		if (Weight5 != 0f)
		{
			num = IndexWeight.InsertUnsorted(dst, num, (Index: Index5, Weight: Weight5));
		}
		if (Weight6 != 0f)
		{
			num = IndexWeight.InsertUnsorted(dst, num, (Index: Index6, Weight: Weight6));
		}
		if (Weight7 != 0f)
		{
			num = IndexWeight.InsertUnsorted(dst, num, (Index: Index7, Weight: Weight7));
		}
		return num;
	}

	internal void CopyTo(Span<IndexWeight> dst)
	{
		dst[0] = (Index: Index0, Weight: Weight0);
		dst[1] = (Index: Index1, Weight: Weight1);
		dst[2] = (Index: Index2, Weight: Weight2);
		dst[3] = (Index: Index3, Weight: Weight3);
		dst[4] = (Index: Index4, Weight: Weight4);
		dst[5] = (Index: Index5, Weight: Weight5);
		dst[6] = (Index: Index6, Weight: Weight6);
		dst[7] = (Index: Index7, Weight: Weight7);
	}

	internal static (SparseWeight8 TangentIn, SparseWeight8 Value, SparseWeight8 TangentOut) AsTuple(float[] tangentIn, float[] value, float[] tangentOut)
	{
		return (TangentIn: Create(tangentIn), Value: Create(value), TangentOut: Create(tangentOut));
	}
}
