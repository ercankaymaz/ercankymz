using System;
using System.Collections.Generic;
using ns27;

namespace SourceGrid.Selection;

public class RangeMergerByCells
{
	internal List<Range> list_0 = new List<Range>();

	internal bool method_0(RangeRegion rangeRegion_0)
	{
		foreach (Range item in list_0)
		{
			RangeRegion pRange = null;
			Range pRange2 = Range.Empty;
			bool flag = false;
			foreach (Range item2 in rangeRegion_0)
			{
				if (item.IntersectsWith(item2))
				{
					pRange = item2.Exclude(item);
					flag = true;
					pRange2 = item2;
					break;
				}
			}
			if (flag)
			{
				rangeRegion_0.Remove(pRange2);
				rangeRegion_0.Add(pRange);
				return true;
			}
		}
		return false;
	}

	public RangeMergerByCells AddRange(Range rangeToAdd)
	{
		RangeRegion rangeRegion = Class76.smethod_266(new RangeRegion(rangeToAdd), this);
		foreach (Range item in rangeRegion)
		{
			list_0.Add(item);
		}
		Class76.smethod_60(this);
		return this;
	}

	internal bool method_1()
	{
		List<Range> list = new List<Range>(list_0);
		foreach (Range item in list)
		{
			foreach (Range item2 in list_0)
			{
				if (!item2.Equals(item))
				{
					if (item2.Start.Row == item.Start.Row && item2.End.Row == item.End.Row && Math.Abs(item2.Start.Column - item.End.Column) == 1)
					{
						Class76.smethod_617(item2, item, this);
						return true;
					}
					if (item2.Start.Column == item.Start.Column && item2.End.Column == item.End.Column && Math.Abs(item2.Start.Row - item.End.Row) == 1)
					{
						Class76.smethod_617(item2, item, this);
						return true;
					}
				}
			}
		}
		return false;
	}

	public List<Range> GetSelectedRowRegions()
	{
		return list_0;
	}
}
