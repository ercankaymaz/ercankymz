using System;
using System.Numerics;

namespace SixLabors.ImageSharp.Metadata.Profiles.Icc;

internal sealed class IccMeasurementTagDataEntry : IccTagDataEntry, IEquatable<IccMeasurementTagDataEntry>
{
	public IccStandardObserver Observer { get; }

	public Vector3 XyzBacking { get; }

	public IccMeasurementGeometry Geometry { get; }

	public float Flare { get; }

	public IccStandardIlluminant Illuminant { get; }

	public IccMeasurementTagDataEntry(IccStandardObserver observer, Vector3 xyzBacking, IccMeasurementGeometry geometry, float flare, IccStandardIlluminant illuminant)
		: this(observer, xyzBacking, geometry, flare, illuminant, IccProfileTag.Unknown)
	{
	}//IL_0002: Unknown result type (might be due to invalid IL or missing references)


	public IccMeasurementTagDataEntry(IccStandardObserver observer, Vector3 xyzBacking, IccMeasurementGeometry geometry, float flare, IccStandardIlluminant illuminant, IccProfileTag tagSignature)
		: base(IccTypeSignature.Measurement, tagSignature)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		Observer = observer;
		XyzBacking = xyzBacking;
		Geometry = geometry;
		Flare = flare;
		Illuminant = illuminant;
	}

	public override bool Equals(IccTagDataEntry? other)
	{
		if (other is IccMeasurementTagDataEntry other2)
		{
			return Equals(other2);
		}
		return false;
	}

	public bool Equals(IccMeasurementTagDataEntry? other)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		if (other == null)
		{
			return false;
		}
		if (this == other)
		{
			return true;
		}
		if (base.Equals(other) && Observer == other.Observer)
		{
			Vector3 xyzBacking = XyzBacking;
			if (((Vector3)(ref xyzBacking)).Equals(other.XyzBacking) && Geometry == other.Geometry && Flare.Equals(other.Flare))
			{
				return Illuminant == other.Illuminant;
			}
		}
		return false;
	}

	public override bool Equals(object? obj)
	{
		if (obj is IccMeasurementTagDataEntry other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		return HashCode.Combine<IccTypeSignature, IccStandardObserver, Vector3, IccMeasurementGeometry, float, IccStandardIlluminant>(base.Signature, Observer, XyzBacking, Geometry, Flare, Illuminant);
	}
}
