using System;
using System.Collections;
using SourceGrid.Cells;

namespace SourceGrid;

public class ValueCellComparer : IComparer
{
	public virtual int Compare(object x, object y)
	{
		if (x != null || y != null)
		{
			if (x != null)
			{
				if (y != null)
				{
					if (!(x is IComparable))
					{
						if (!(y is IComparable))
						{
							object value = ((ICell)x).Value;
							object value2 = ((ICell)y).Value;
							if (value != null || value2 != null)
							{
								if (value != null)
								{
									if (value2 != null)
									{
										if (!(value is IComparable))
										{
											if (!(value2 is IComparable))
											{
												throw new ArgumentException("Invalid cell object, no IComparable interface found");
											}
											if (value.GetType().Equals(value2.GetType()))
											{
												return -1 * ((IComparable)value2).CompareTo(value);
											}
											return -1;
										}
										if (value.GetType().Equals(value2.GetType()))
										{
											return ((IComparable)value).CompareTo(value2);
										}
										return -1;
									}
									return 1;
								}
								return -1;
							}
							return 0;
						}
						if (x.GetType().Equals(y.GetType()))
						{
							return -1 * ((IComparable)y).CompareTo(x);
						}
						return -1;
					}
					if (x.GetType().Equals(y.GetType()))
					{
						return ((IComparable)x).CompareTo(y);
					}
					return -1;
				}
				return 1;
			}
			return -1;
		}
		return 0;
	}
}
