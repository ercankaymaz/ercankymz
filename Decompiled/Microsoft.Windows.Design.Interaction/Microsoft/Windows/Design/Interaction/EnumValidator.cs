namespace Microsoft.Windows.Design.Interaction;

internal static class EnumValidator
{
	public static bool IsValid(AdornerPlacementDimension value)
	{
		if (value >= AdornerPlacementDimension.Left)
		{
			return value <= AdornerPlacementDimension.Height;
		}
		return false;
	}

	public static bool IsValid(AdornerStretch value)
	{
		if (value >= AdornerStretch.None)
		{
			return value <= AdornerStretch.Stretch;
		}
		return false;
	}

	public static bool IsValid(NudgeIntent value)
	{
		if (value >= NudgeIntent.Left)
		{
			return value <= NudgeIntent.Down;
		}
		return false;
	}

	public static bool IsValid(ToolAction value)
	{
		if (value >= ToolAction.None)
		{
			return value <= ToolAction.DragOutside;
		}
		return false;
	}
}
