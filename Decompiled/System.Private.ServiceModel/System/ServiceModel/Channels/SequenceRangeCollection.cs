using System.Collections.Generic;
using System.Text;

namespace System.ServiceModel.Channels;

internal abstract class SequenceRangeCollection
{
	private class EmptyRangeCollection : SequenceRangeCollection
	{
		public override SequenceRange this[int index]
		{
			get
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("index"));
			}
		}

		public override int Count => 0;

		public override bool Contains(long number)
		{
			return false;
		}

		public override SequenceRangeCollection MergeWith(long number)
		{
			return new SingleItemRangeCollection(number, number);
		}

		public override SequenceRangeCollection MergeWith(SequenceRange range)
		{
			return new SingleItemRangeCollection(range);
		}
	}

	private class MultiItemRangeCollection : SequenceRangeCollection
	{
		private readonly SequenceRange[] _ranges;

		public override SequenceRange this[int index]
		{
			get
			{
				if (index < 0 || index >= _ranges.Length)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("index", index, System.SR.Format(System.SR.ValueMustBeInRange, 0, _ranges.Length - 1)));
				}
				return _ranges[index];
			}
		}

		public override int Count => _ranges.Length;

		public MultiItemRangeCollection(SequenceRange[] sortedRanges)
		{
			_ranges = sortedRanges;
		}

		public override bool Contains(long number)
		{
			if (_ranges.Length == 0)
			{
				return false;
			}
			if (_ranges.Length == 1)
			{
				return _ranges[0].Contains(number);
			}
			int num = Array.BinarySearch(value: new SequenceRange(number), array: _ranges, comparer: s_lowerComparer);
			if (num >= 0)
			{
				return true;
			}
			num = ~num;
			if (num == 0)
			{
				return false;
			}
			return _ranges[num - 1].Upper >= number;
		}

		public override SequenceRangeCollection MergeWith(long number)
		{
			return MergeWith(new SequenceRange(number));
		}

		public override SequenceRangeCollection MergeWith(SequenceRange newRange)
		{
			return GeneralMerge(_ranges, newRange);
		}
	}

	private class SingleItemRangeCollection : SequenceRangeCollection
	{
		private SequenceRange _range;

		public override SequenceRange this[int index]
		{
			get
			{
				if (index != 0)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("index"));
				}
				return _range;
			}
		}

		public override int Count => 1;

		public SingleItemRangeCollection(SequenceRange range)
		{
			_range = range;
		}

		public SingleItemRangeCollection(long lower, long upper)
		{
			_range = new SequenceRange(lower, upper);
		}

		public override bool Contains(long number)
		{
			return _range.Contains(number);
		}

		public override SequenceRangeCollection MergeWith(long number)
		{
			if (number == _range.Upper + 1)
			{
				return new SingleItemRangeCollection(_range.Lower, number);
			}
			return MergeWith(new SequenceRange(number));
		}

		public override SequenceRangeCollection MergeWith(SequenceRange newRange)
		{
			if (newRange.Lower == _range.Upper + 1)
			{
				return new SingleItemRangeCollection(_range.Lower, newRange.Upper);
			}
			if (_range.Contains(newRange))
			{
				return this;
			}
			if (newRange.Contains(_range))
			{
				return new SingleItemRangeCollection(newRange);
			}
			if (newRange.Upper == _range.Lower - 1)
			{
				return new SingleItemRangeCollection(newRange.Lower, _range.Upper);
			}
			return GeneralMerge(new SequenceRange[1] { _range }, newRange);
		}
	}

	private class LowerComparer : IComparer<SequenceRange>
	{
		public int Compare(SequenceRange x, SequenceRange y)
		{
			if (x.Lower < y.Lower)
			{
				return -1;
			}
			if (x.Lower > y.Lower)
			{
				return 1;
			}
			return 0;
		}
	}

	private class UpperComparer : IComparer<SequenceRange>
	{
		public int Compare(SequenceRange x, SequenceRange y)
		{
			if (x.Upper < y.Upper)
			{
				return -1;
			}
			if (x.Upper > y.Upper)
			{
				return 1;
			}
			return 0;
		}
	}

	private static readonly LowerComparer s_lowerComparer = new LowerComparer();

	private static readonly UpperComparer s_upperComparer = new UpperComparer();

	public static SequenceRangeCollection Empty { get; } = new EmptyRangeCollection();

	public abstract SequenceRange this[int index] { get; }

	public abstract int Count { get; }

	public abstract bool Contains(long number);

	public abstract SequenceRangeCollection MergeWith(long number);

	public abstract SequenceRangeCollection MergeWith(SequenceRange range);

	private static SequenceRangeCollection GeneralCreate(SequenceRange[] sortedRanges)
	{
		if (sortedRanges.Length == 0)
		{
			return Empty;
		}
		if (sortedRanges.Length == 1)
		{
			return new SingleItemRangeCollection(sortedRanges[0]);
		}
		return new MultiItemRangeCollection(sortedRanges);
	}

	private static SequenceRangeCollection GeneralMerge(SequenceRange[] sortedRanges, SequenceRange range)
	{
		if (sortedRanges.Length == 0)
		{
			return new SingleItemRangeCollection(range);
		}
		int num = ((sortedRanges.Length != 1) ? Array.BinarySearch(sortedRanges, new SequenceRange(range.Lower), s_upperComparer) : ((range.Lower != sortedRanges[0].Upper) ? ((range.Lower >= sortedRanges[0].Upper) ? (-2) : (-1)) : 0));
		if (num < 0)
		{
			num = ~num;
			if (num > 0 && sortedRanges[num - 1].Upper == range.Lower - 1)
			{
				num--;
			}
			if (num == sortedRanges.Length)
			{
				SequenceRange[] array = new SequenceRange[sortedRanges.Length + 1];
				Array.Copy(sortedRanges, array, sortedRanges.Length);
				array[sortedRanges.Length] = range;
				return GeneralCreate(array);
			}
		}
		int num2 = ((sortedRanges.Length != 1) ? Array.BinarySearch(sortedRanges, new SequenceRange(range.Upper), s_lowerComparer) : ((range.Upper != sortedRanges[0].Lower) ? ((range.Upper >= sortedRanges[0].Lower) ? (-2) : (-1)) : 0));
		if (num2 < 0)
		{
			num2 = ~num2;
			if (num2 > 0)
			{
				if (num2 == sortedRanges.Length || sortedRanges[num2].Lower != range.Upper + 1)
				{
					num2--;
				}
			}
			else if (sortedRanges[0].Lower > range.Upper + 1)
			{
				SequenceRange[] array2 = new SequenceRange[sortedRanges.Length + 1];
				Array.Copy(sortedRanges, 0, array2, 1, sortedRanges.Length);
				array2[0] = range;
				return GeneralCreate(array2);
			}
		}
		long lower = ((range.Lower < sortedRanges[num].Lower) ? range.Lower : sortedRanges[num].Lower);
		long upper = ((range.Upper > sortedRanges[num2].Upper) ? range.Upper : sortedRanges[num2].Upper);
		int num3 = num2 - num + 1;
		int num4 = sortedRanges.Length - num3 + 1;
		if (num4 == 1)
		{
			return new SingleItemRangeCollection(lower, upper);
		}
		SequenceRange[] array3 = new SequenceRange[num4];
		Array.Copy(sortedRanges, array3, num);
		array3[num] = new SequenceRange(lower, upper);
		Array.Copy(sortedRanges, num2 + 1, array3, num + 1, sortedRanges.Length - num2 - 1);
		return GeneralCreate(array3);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < Count; i++)
		{
			SequenceRange sequenceRange = this[i];
			if (i > 0)
			{
				stringBuilder.Append(',');
			}
			stringBuilder.Append(sequenceRange.Lower);
			stringBuilder.Append('-');
			stringBuilder.Append(sequenceRange.Upper);
		}
		return stringBuilder.ToString();
	}
}
