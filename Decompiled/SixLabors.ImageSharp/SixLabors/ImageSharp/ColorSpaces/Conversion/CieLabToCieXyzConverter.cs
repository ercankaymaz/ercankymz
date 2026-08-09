using System.Numerics;
using System.Runtime.CompilerServices;

namespace SixLabors.ImageSharp.ColorSpaces.Conversion;

internal static class CieLabToCieXyzConverter
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static CieXyz Convert(in CieLab input)
	{
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		float l = input.L;
		float a = input.A;
		float b = input.B;
		float num = (l + 16f) / 116f;
		float num2 = a / 500f + num;
		float num3 = num - b / 200f;
		float num4 = Numerics.Pow3(num2);
		float num5 = Numerics.Pow3(num3);
		float num6 = ((num4 > 0.008856452f) ? num4 : ((116f * num2 - 16f) / 903.2963f));
		float num7 = ((l > 8.000001f) ? Numerics.Pow3((l + 16f) / 116f) : (l / 903.2963f));
		float num8 = ((num5 > 0.008856452f) ? num5 : ((116f * num3 - 16f) / 903.2963f));
		Vector3 val = default(Vector3);
		((Vector3)(ref val))._002Ector(input.WhitePoint.X, input.WhitePoint.Y, input.WhitePoint.Z);
		return new CieXyz(Vector3.Clamp(new Vector3(num6, num7, num8), Vector3.Zero, Vector3.One) * val);
	}
}
