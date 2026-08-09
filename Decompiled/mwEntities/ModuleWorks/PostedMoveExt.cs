using System;

namespace ModuleWorks;

public class PostedMoveExt
{
	public Vectord AbsoluteMachinePosition { get; set; }

	public bool HasPotentialSurfaceContactPoint { get; set; }

	[CLSCompliant(false)]
	public uint NonDeterminateSurfaceId { get; set; }

	[CLSCompliant(false)]
	public uint PotentialSurfaceID { get; set; }

	public Vectord PotentialSurfaceContactPoint { get; set; }

	public Vectord PotentialSurfaceContactPointOrientation { get; set; }

	public double FeedRate { get; set; }

	public Vectord Orientation { get; set; }

	public Vectord PartPosition { get; set; }

	public bool IsRapid { get; set; }

	public double Time { get; set; }

	public float SpindleSpeed { get; set; }

	[CLSCompliant(false)]
	public uint ReferenceToOriginalToolpath { get; set; }

	public bool WasAddedByPost { get; set; }

	public bool IsArcMove { get; set; }

	public double[] RotationAxisValues { get; set; }

	public bool HasReport { get; set; }

	public PostedMoveExt()
	{
		AbsoluteMachinePosition = new Vectord();
		Orientation = new Vectord();
		PartPosition = new Vectord();
		RotationAxisValues = new double[0];
	}
}
