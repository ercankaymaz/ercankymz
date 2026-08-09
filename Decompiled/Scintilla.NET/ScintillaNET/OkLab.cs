using System;

namespace ScintillaNET;

internal struct OkLab(float L, float a, float b)
{
	public float L = L;

	public float a = a;

	public float b = b;

	public readonly Srgb ToLinearSrgb()
	{
		float num = L + 0.39633778f * a + 0.21580376f * b;
		float num2 = L - 0.105561346f * a - 0.06385417f * b;
		float num3 = L - 0.08948418f * a - 1.2914855f * b;
		float num4 = num * num * num;
		float num5 = num2 * num2 * num2;
		float num6 = num3 * num3 * num3;
		return new Srgb(Helpers.Clamp(4.0767417f * num4 - 3.3077116f * num5 + 0.23096994f * num6, 0f, 1f), Helpers.Clamp(-1.268438f * num4 + 2.6097574f * num5 - 0.34131938f * num6, 0f, 1f), Helpers.Clamp(-0.0041960864f * num4 - 0.7034186f * num5 + 1.7076147f * num6, 0f, 1f));
	}

	public override readonly string ToString()
	{
		return FormattableString.Invariant($"(L:{L}, a:{a}, b:{b})");
	}
}
