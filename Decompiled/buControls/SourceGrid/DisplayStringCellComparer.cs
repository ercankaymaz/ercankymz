using System;
using System.Collections;
using SourceGrid.Cells;

namespace SourceGrid;

public class DisplayStringCellComparer : IComparer
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
							string displayText = ((ICell)x).DisplayText;
							string displayText2 = ((ICell)y).DisplayText;
							if (displayText != null || displayText2 != null)
							{
								if (displayText != null)
								{
									if (displayText2 != null)
									{
										return displayText.CompareTo(displayText2);
									}
									return 1;
								}
								return -1;
							}
							return 0;
						}
						return -1 * ((IComparable)y).CompareTo(x);
					}
					return ((IComparable)x).CompareTo(y);
				}
				return 1;
			}
			return -1;
		}
		return 0;
	}
}
