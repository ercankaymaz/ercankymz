using System;

namespace ModuleWorks;

[Serializable]
public struct VerifierToolBehavior
{
	public enum FiveAxisCuttingToleranceModeType
	{
		CUTTING_TOLERANCE_ONLY_FOR_TOOL_TIP,
		CUTTING_TOLERANCE_FOR_FULL_TOOL
	}

	public enum SpindleDirectionType
	{
		CW,
		CCW
	}

	public VerifierToolElementBehavior Flute { get; set; }

	public VerifierToolElementBehavior Shaft { get; set; }

	public VerifierToolElementBehavior Arbor { get; set; }

	public VerifierToolElementBehavior Holder { get; set; }

	public VerifierEccentricToolSpindleMode EccentricToolSpindleMode { get; set; }

	public Vectorf EccentricToolSpindleAxisPosition { get; set; }

	public Vectorf EccentricToolSpindleAxisDirection { get; set; }

	public FiveAxisCuttingToleranceModeType FiveAxisCuttingToleranceMode { get; set; }

	public Vectorf PaintDirection { get; set; }

	public SpindleDirectionType SpindleDirection { get; set; }

	public VerifierToolBehavior(VerifierToolElementBehavior flute, VerifierToolElementBehavior shaft, VerifierToolElementBehavior arbor, VerifierToolElementBehavior holder)
	{
		this = default(VerifierToolBehavior);
		Flute = flute;
		Shaft = shaft;
		Arbor = arbor;
		Holder = holder;
		EccentricToolSpindleMode = VerifierEccentricToolSpindleMode.ToolSpindleOff;
		EccentricToolSpindleAxisPosition = new Vectorf(0f, 0f, 0f);
		EccentricToolSpindleAxisDirection = new Vectorf(0f, 0f, 1f);
		FiveAxisCuttingToleranceMode = FiveAxisCuttingToleranceModeType.CUTTING_TOLERANCE_ONLY_FOR_TOOL_TIP;
		PaintDirection = new Vectorf(0f, 0f, -1f);
		SpindleDirection = SpindleDirectionType.CW;
	}

	public VerifierToolBehavior(VerifierToolElementBehavior flute, VerifierToolElementBehavior shaft, VerifierToolElementBehavior arbor, VerifierToolElementBehavior holder, VerifierEccentricToolSpindleMode eccentricToolSpindleMode, Vectorf eccentricToolSpindleAxisPosition, Vectorf eccentricToolSpindleAxisDirection)
	{
		this = default(VerifierToolBehavior);
		Flute = flute;
		Shaft = shaft;
		Arbor = arbor;
		Holder = holder;
		EccentricToolSpindleMode = eccentricToolSpindleMode;
		EccentricToolSpindleAxisPosition = eccentricToolSpindleAxisPosition;
		EccentricToolSpindleAxisDirection = eccentricToolSpindleAxisDirection;
		FiveAxisCuttingToleranceMode = FiveAxisCuttingToleranceModeType.CUTTING_TOLERANCE_ONLY_FOR_TOOL_TIP;
		PaintDirection = new Vectorf(0f, 0f, -1f);
		SpindleDirection = SpindleDirectionType.CW;
	}

	public static bool operator ==(VerifierToolBehavior a, VerifierToolBehavior b)
	{
		if (a.Flute == b.Flute && a.Shaft == b.Shaft && a.Arbor == b.Arbor && a.Holder == b.Holder && a.EccentricToolSpindleMode == b.EccentricToolSpindleMode && ((a.EccentricToolSpindleAxisPosition == null && b.EccentricToolSpindleAxisPosition == null) || (a.EccentricToolSpindleAxisPosition != null && b.EccentricToolSpindleAxisPosition != null && a.EccentricToolSpindleAxisPosition.Equals(b.EccentricToolSpindleAxisPosition))) && a.FiveAxisCuttingToleranceMode == b.FiveAxisCuttingToleranceMode && ((a.PaintDirection == null && b.PaintDirection == null) || (a.PaintDirection != null && b.PaintDirection != null && a.PaintDirection.Equals(b.PaintDirection))))
		{
			return a.SpindleDirection == b.SpindleDirection;
		}
		return false;
	}

	public static bool operator !=(VerifierToolBehavior a, VerifierToolBehavior b)
	{
		return !(a == b);
	}

	public override bool Equals(object obj)
	{
		if (obj is VerifierToolBehavior)
		{
			return this == (VerifierToolBehavior)obj;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Flute.GetHashCode() | Shaft.GetHashCode() | Arbor.GetHashCode() | Holder.GetHashCode() | EccentricToolSpindleMode.GetHashCode() | ((EccentricToolSpindleAxisPosition != null) ? EccentricToolSpindleAxisPosition.GetHashCode() : 0) | ((EccentricToolSpindleAxisDirection != null) ? EccentricToolSpindleAxisDirection.GetHashCode() : 0) | FiveAxisCuttingToleranceMode.GetHashCode() | ((PaintDirection != null) ? PaintDirection.GetHashCode() : 0) | SpindleDirection.GetHashCode();
	}
}
