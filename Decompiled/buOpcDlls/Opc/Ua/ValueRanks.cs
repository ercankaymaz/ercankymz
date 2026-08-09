using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public static class ValueRanks
{
	public const int ScalarOrOneDimension = -3;

	public const int Any = -2;

	public const int Scalar = -1;

	public const int OneOrMoreDimensions = 0;

	public const int OneDimension = 1;

	public const int TwoDimensions = 2;

	public static bool IsValid(int actualValueRank, int expectedValueRank)
	{
		if (actualValueRank == expectedValueRank)
		{
			return true;
		}
		switch (expectedValueRank)
		{
		case -2:
			return true;
		case 0:
			if (actualValueRank < 0)
			{
				return false;
			}
			break;
		case -3:
			if (actualValueRank != -1 && actualValueRank != 1)
			{
				return false;
			}
			break;
		default:
			return false;
		}
		return true;
	}

	public static bool IsValid(IList<uint> actualArrayDimensions, int valueRank, IList<uint> expectedArrayDimensions)
	{
		if (actualArrayDimensions == null || actualArrayDimensions.Count == 0)
		{
			if (expectedArrayDimensions != null)
			{
				return expectedArrayDimensions.Count == 0;
			}
			return true;
		}
		switch (valueRank)
		{
		case -1:
			return false;
		case -3:
		case 1:
			if (actualArrayDimensions.Count != 1)
			{
				return false;
			}
			break;
		}
		if (valueRank != 0 && actualArrayDimensions.Count != valueRank)
		{
			return false;
		}
		if (expectedArrayDimensions == null || expectedArrayDimensions.Count == 0)
		{
			return true;
		}
		if (expectedArrayDimensions.Count != actualArrayDimensions.Count)
		{
			return false;
		}
		for (int i = 0; i < expectedArrayDimensions.Count; i++)
		{
			if (expectedArrayDimensions[i] != actualArrayDimensions[i] && expectedArrayDimensions[i] != 0)
			{
				return false;
			}
		}
		return true;
	}
}
