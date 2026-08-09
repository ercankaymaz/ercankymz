using System.Collections.Generic;

namespace buMutliTextbox;

public struct LineInfo(int startY)
{
	private List<int> list_0 = null;

	internal int startY = startY;

	internal int int_0 = 0;

	internal int int_1 = 0;

	public VisibleState VisibleState = VisibleState.Visible;

	public List<int> CutOffPositions
	{
		get
		{
			if (list_0 == null)
			{
				list_0 = new List<int>();
			}
			return list_0;
		}
	}

	public int WordWrapStringsCount
	{
		get
		{
			switch (VisibleState)
			{
			case VisibleState.Hidden:
				return 0;
			default:
				return 0;
			case VisibleState.Visible:
				if (list_0 != null)
				{
					return list_0.Count + 1;
				}
				return 1;
			case VisibleState.StartOfHiddenBlock:
				return 1;
			}
		}
	}

	internal int method_0(int int_2)
	{
		return (int_2 != 0) ? CutOffPositions[int_2 - 1] : 0;
	}

	internal int method_1(int int_2, Line line_0)
	{
		if (WordWrapStringsCount > 0)
		{
			return (int_2 != WordWrapStringsCount - 1) ? (CutOffPositions[int_2] - 1) : (line_0.Count - 1);
		}
		return 0;
	}

	public int GetWordWrapStringIndex(int iChar)
	{
		if (list_0 != null && list_0.Count != 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				if (list_0[i] > iChar)
				{
					return i;
				}
			}
			return list_0.Count;
		}
		return 0;
	}
}
