using System;

namespace buClass.Apps;

[Serializable]
public class BendingItem : buSerilization
{
	public double X = 0.0;

	public double Offset = 0.0;

	public double OffsetMachine = 0.0;

	public int ToolNo = 0;

	public int Action = 0;

	public bool LastCut = false;

	public int Mode = 0;

	public int PartIndex = -1;

	public double PtValue = 0.0;

	public int Option = 0;

	public static void Copy(BendingItem RefItem, ref BendingItem CopiedItem)
	{
		if (RefItem.GetType() == typeof(BendingBendPoint))
		{
			CopiedItem = new BendingBendPoint((BendingBendPoint)RefItem);
		}
		if (RefItem.GetType() == typeof(BendingBroachPoint))
		{
			CopiedItem = new BendingBroachPoint((BendingBroachPoint)RefItem);
		}
		if (RefItem.GetType() == typeof(BendingNickPoint))
		{
			CopiedItem = new BendingNickPoint((BendingNickPoint)RefItem);
		}
		if (RefItem.GetType() == typeof(BendingBridgePoint))
		{
			CopiedItem = new BendingBridgePoint((BendingBridgePoint)RefItem);
		}
		if (RefItem.GetType() == typeof(BendingPunchPoint))
		{
			CopiedItem = new BendingPunchPoint((BendingPunchPoint)RefItem);
		}
		if (RefItem.GetType() == typeof(BendingScissorsPoint))
		{
			CopiedItem = new BendingScissorsPoint((BendingScissorsPoint)RefItem);
		}
		if (RefItem.GetType() == typeof(BendingTrimcutPoint))
		{
			CopiedItem = new BendingTrimcutPoint((BendingTrimcutPoint)RefItem);
		}
		if (RefItem.GetType() == typeof(BendingBendCut))
		{
			CopiedItem = new BendingBendCut((BendingBendCut)RefItem);
		}
		if (RefItem.GetType() == typeof(BendingPerfoCombiPoint))
		{
			CopiedItem = new BendingPerfoCombiPoint((BendingPerfoCombiPoint)RefItem);
		}
	}
}
