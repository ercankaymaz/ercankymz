using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SixLabors.ImageSharp.ColorSpaces.Conversion;

public sealed class VonKriesChromaticAdaptation : IChromaticAdaptation
{
	private readonly CieXyzAndLmsConverter converter;

	public VonKriesChromaticAdaptation()
		: this(new CieXyzAndLmsConverter())
	{
	}

	public VonKriesChromaticAdaptation(Matrix4x4 transformationMatrix)
		: this(new CieXyzAndLmsConverter(transformationMatrix))
	{
	}//IL_0001: Unknown result type (might be due to invalid IL or missing references)


	internal VonKriesChromaticAdaptation(CieXyzAndLmsConverter converter)
	{
		this.converter = converter;
	}

	public CieXyz Transform(in CieXyz source, in CieXyz sourceWhitePoint, in CieXyz destinationWhitePoint)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		if (sourceWhitePoint.Equals(destinationWhitePoint))
		{
			return source;
		}
		Lms lms = converter.Convert(in source);
		Lms lms2 = converter.Convert(in sourceWhitePoint);
		Vector3 val = converter.Convert(in destinationWhitePoint).ToVector3() / lms2.ToVector3();
		Lms input = new Lms(Vector3.Multiply(val, lms.ToVector3()));
		return converter.Convert(in input);
	}

	public void Transform(ReadOnlySpan<CieXyz> source, Span<CieXyz> destination, CieXyz sourceWhitePoint, in CieXyz destinationWhitePoint)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		if (sourceWhitePoint.Equals(destinationWhitePoint))
		{
			source.CopyTo(destination.Slice(0, length));
			return;
		}
		ref CieXyz reference = ref MemoryMarshal.GetReference<CieXyz>(source);
		ref CieXyz reference2 = ref MemoryMarshal.GetReference<CieXyz>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieXyz input = ref Unsafe.Add(ref reference, num);
			ref CieXyz reference3 = ref Unsafe.Add(ref reference2, num);
			Lms lms = converter.Convert(in input);
			Lms lms2 = converter.Convert(in sourceWhitePoint);
			Vector3 val = converter.Convert(in destinationWhitePoint).ToVector3() / lms2.ToVector3();
			Lms input2 = new Lms(Vector3.Multiply(val, lms.ToVector3()));
			reference3 = converter.Convert(in input2);
		}
	}

	CieXyz IChromaticAdaptation.Transform(in CieXyz source, in CieXyz sourceWhitePoint, in CieXyz destinationWhitePoint)
	{
		return Transform(in source, in sourceWhitePoint, in destinationWhitePoint);
	}

	void IChromaticAdaptation.Transform(ReadOnlySpan<CieXyz> source, Span<CieXyz> destination, CieXyz sourceWhitePoint, in CieXyz destinationWhitePoint)
	{
		Transform(source, destination, sourceWhitePoint, in destinationWhitePoint);
	}
}
