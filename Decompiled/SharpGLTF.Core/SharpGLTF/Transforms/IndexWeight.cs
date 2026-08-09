using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace SharpGLTF.Transforms;

[DebuggerDisplay("{Index} = {Weight}")]
internal readonly struct IndexWeight : IEquatable<IndexWeight>
{
	public readonly int Index;

	public readonly float Weight;

	public static implicit operator IndexWeight((int Index, float Weight) pair)
	{
		return new IndexWeight(pair.Index, pair.Weight);
	}

	public static implicit operator IndexWeight(KeyValuePair<int, float> pair)
	{
		return new IndexWeight(pair.Key, pair.Value);
	}

	public IndexWeight((int Index, float Weight) pair)
	{
		(Index, Weight) = pair;
	}

	public IndexWeight(KeyValuePair<int, float> pair)
	{
		Index = pair.Key;
		Weight = pair.Value;
	}

	public IndexWeight(int i, float w)
	{
		Index = i;
		Weight = w;
	}

	public override int GetHashCode()
	{
		int index = Index;
		int hashCode = index.GetHashCode();
		float weight = Weight;
		return hashCode ^ weight.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is IndexWeight other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(IndexWeight other)
	{
		if (Index == other.Index)
		{
			return Weight == other.Weight;
		}
		return false;
	}

	public bool IsGreaterThan(in IndexWeight other)
	{
		float num = Math.Abs(Weight);
		float num2 = Math.Abs(other.Weight);
		if (num > num2)
		{
			return true;
		}
		if (num == num2 && Index < other.Index)
		{
			return true;
		}
		return false;
	}

	public static IndexWeight operator +(IndexWeight a, IndexWeight b)
	{
		if (a.Index != b.Index)
		{
			throw new InvalidOperationException("b");
		}
		return new IndexWeight(a.Index, a.Weight + b.Weight);
	}

	public static IndexWeight operator +(IndexWeight a, float w)
	{
		return new IndexWeight(a.Index, a.Weight + w);
	}

	public static bool IsWellFormed(ReadOnlySpan<IndexWeight> iw, out string err)
	{
		for (int i = 0; i < iw.Length; i++)
		{
			IndexWeight indexWeight = iw[i];
			if (indexWeight.Weight == 0f)
			{
				if (indexWeight.Index != 0)
				{
					err = "weightless items must have index 0.";
					return false;
				}
				continue;
			}
			for (int j = 0; j < i; j++)
			{
				IndexWeight indexWeight2 = iw[j];
				if (indexWeight2.Weight != 0f && indexWeight.Index == indexWeight2.Index)
				{
					err = "indices must be unique.";
					return false;
				}
			}
		}
		err = null;
		return true;
	}

	public static int InsertSorted(Span<IndexWeight> buffer, int length, IndexWeight item)
	{
		if (item.Weight == 0f)
		{
			return length;
		}
		for (int i = 0; i < length; i++)
		{
			if (buffer[i].Index != item.Index)
			{
				continue;
			}
			buffer[i] += item;
			IndexWeight indexWeight;
			for (; i > 1; indexWeight = buffer[i - 1], buffer[i - 1] = buffer[i], buffer[i] = indexWeight, i--)
			{
				switch (Math.Abs(buffer[i - 1].Weight).CompareTo(buffer[i].Weight))
				{
				case 0:
					if (buffer[i - 1].Index >= item.Index)
					{
						continue;
					}
					break;
				default:
					continue;
				case 1:
					break;
				}
				break;
			}
			return length;
		}
		int num = length;
		float value = Math.Abs(item.Weight);
		for (int j = 0; j < length; j++)
		{
			int num2 = Math.Abs(buffer[j].Weight).CompareTo(value);
			if (num2 != 1 && (num2 != 0 || buffer[j].Index >= item.Index))
			{
				num = j;
				break;
			}
		}
		if (num >= buffer.Length)
		{
			return buffer.Length;
		}
		length = Math.Min(length + 1, buffer.Length);
		for (int num3 = length - 1; num3 > num; num3--)
		{
			buffer[num3] = buffer[num3 - 1];
		}
		buffer[num] = item;
		return length;
	}

	public static int InsertUnsorted(Span<IndexWeight> sparse, in Vector4 idx0123, in Vector4 wgt0123)
	{
		int num = 0;
		if (wgt0123.X != 0f)
		{
			sparse[0] = (Index: (int)idx0123.X, Weight: wgt0123.X);
			num++;
		}
		if (wgt0123.Y != 0f)
		{
			int num2 = (int)idx0123.Y;
			if (num == 1 && sparse[0].Index == num2)
			{
				sparse[0] += (IndexWeight)(Index: num2, Weight: wgt0123.Y);
			}
			else
			{
				sparse[num++] = (Index: num2, Weight: wgt0123.Y);
			}
		}
		if (wgt0123.Z != 0f)
		{
			int num3 = (int)idx0123.Z;
			if (num > 0 && sparse[0].Index == num3)
			{
				sparse[0] += (IndexWeight)(Index: num3, Weight: wgt0123.Z);
			}
			else if (num > 1 && sparse[1].Index == num3)
			{
				sparse[1] += (IndexWeight)(Index: num3, Weight: wgt0123.Z);
			}
			else
			{
				sparse[num++] = (Index: num3, Weight: wgt0123.Z);
			}
		}
		if (wgt0123.W != 0f)
		{
			int num4 = (int)idx0123.W;
			if (num > 0 && sparse[0].Index == num4)
			{
				sparse[0] += (IndexWeight)(Index: num4, Weight: wgt0123.W);
			}
			else if (num > 1 && sparse[1].Index == num4)
			{
				sparse[1] += (IndexWeight)(Index: num4, Weight: wgt0123.W);
			}
			else if (num > 2 && sparse[2].Index == num4)
			{
				sparse[2] += (IndexWeight)(Index: num4, Weight: wgt0123.W);
			}
			else
			{
				sparse[num++] = (Index: num4, Weight: wgt0123.W);
			}
		}
		return num;
	}

	public static int InsertUnsorted(Span<IndexWeight> buffer, int length, IndexWeight item)
	{
		if (item.Weight == 0f)
		{
			return length;
		}
		for (int i = 0; i < length; i++)
		{
			if (buffer[i].Index == item.Index)
			{
				float num = buffer[i].Weight + item.Weight;
				buffer[i] = ((num == 0f) ? default(IndexWeight) : new IndexWeight(item.Index, num));
				return length;
			}
		}
		if (length < buffer.Length)
		{
			buffer[length] = item;
			return length + 1;
		}
		int num2 = -1;
		IndexWeight other = item;
		for (int j = 0; j < buffer.Length; j++)
		{
			if (!buffer[j].IsGreaterThan(in other))
			{
				num2 = j;
				other = buffer[j];
			}
		}
		if (num2 >= 0)
		{
			buffer[num2] = item;
		}
		return length;
	}

	public static int CopyTo(in SparseWeight8 src, Span<int> dstIndices, Span<float> dstWeights, int dstLength)
	{
		foreach (IndexWeight item in src._GetPairs())
		{
			int num = dstIndices.Slice(0, dstLength).IndexOf(item.Index);
			if (num < 0)
			{
				dstIndices[dstLength] = item.Index;
				dstWeights[dstLength] = item.Weight;
				dstLength++;
			}
			else
			{
				dstWeights[num] += item.Weight;
			}
		}
		return dstLength;
	}

	public static void BubbleSortByWeight(Span<IndexWeight> pairs)
	{
		for (int i = 0; i < pairs.Length - 1; i++)
		{
			bool flag = true;
			for (int j = 1; j < pairs.Length; j++)
			{
				int index = j - 1;
				IndexWeight indexWeight = pairs[index];
				IndexWeight other = pairs[j];
				if (!indexWeight.IsGreaterThan(in other))
				{
					pairs[index] = other;
					pairs[j] = indexWeight;
					flag = false;
				}
			}
			if (flag)
			{
				break;
			}
		}
	}

	public static void BubbleSortByIndex(Span<IndexWeight> pairs)
	{
		for (int i = 0; i < pairs.Length - 1; i++)
		{
			bool flag = true;
			for (int j = 1; j < pairs.Length; j++)
			{
				int index = j - 1;
				IndexWeight indexWeight = pairs[index];
				IndexWeight indexWeight2 = pairs[j];
				if (indexWeight.Index >= indexWeight2.Index && (indexWeight.Index != indexWeight2.Index || !(indexWeight.Weight > indexWeight2.Weight)))
				{
					pairs[index] = indexWeight2;
					pairs[j] = indexWeight;
					flag = false;
				}
			}
			if (flag)
			{
				break;
			}
		}
	}
}
