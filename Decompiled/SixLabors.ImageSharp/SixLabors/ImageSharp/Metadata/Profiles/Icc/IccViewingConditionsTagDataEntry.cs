using System;
using System.Numerics;

namespace SixLabors.ImageSharp.Metadata.Profiles.Icc;

internal sealed class IccViewingConditionsTagDataEntry : IccTagDataEntry, IEquatable<IccViewingConditionsTagDataEntry>
{
	public Vector3 IlluminantXyz { get; }

	public Vector3 SurroundXyz { get; }

	public IccStandardIlluminant Illuminant { get; }

	public IccViewingConditionsTagDataEntry(Vector3 illuminantXyz, Vector3 surroundXyz, IccStandardIlluminant illuminant)
		: this(illuminantXyz, surroundXyz, illuminant, IccProfileTag.Unknown)
	{
	}//IL_0001: Unknown result type (might be due to invalid IL or missing references)
	//IL_0002: Unknown result type (might be due to invalid IL or missing references)


	public IccViewingConditionsTagDataEntry(Vector3 illuminantXyz, Vector3 surroundXyz, IccStandardIlluminant illuminant, IccProfileTag tagSignature)
		: base(IccTypeSignature.ViewingConditions, tagSignature)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		IlluminantXyz = illuminantXyz;
		SurroundXyz = surroundXyz;
		Illuminant = illuminant;
	}

	public override bool Equals(IccTagDataEntry? other)
	{
		if (other is IccViewingConditionsTagDataEntry other2)
		{
			return Equals(other2);
		}
		return false;
	}

	public bool Equals(IccViewingConditionsTagDataEntry? other)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		if (other == null)
		{
			return false;
		}
		if (this == other)
		{
			return true;
		}
		if (base.Equals(other))
		{
			Vector3 val = IlluminantXyz;
			if (((Vector3)(ref val)).Equals(other.IlluminantXyz))
			{
				val = SurroundXyz;
				if (((Vector3)(ref val)).Equals(other.SurroundXyz))
				{
					return Illuminant == other.Illuminant;
				}
			}
		}
		return false;
	}

	public override bool Equals(object? obj)
	{
		if (obj is IccViewingConditionsTagDataEntry other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		return HashCode.Combine<IccTypeSignature, Vector3, Vector3, IccStandardIlluminant>(base.Signature, IlluminantXyz, SurroundXyz, Illuminant);
	}
}
