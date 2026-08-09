using System;
using System.Runtime.CompilerServices;

namespace SixLabors.ImageSharp.Formats.Jpeg.Components;

internal static class ScaledFloatingPointDCT
{
	private const float FP32_0_541196100 = 0.5411961f;

	private const float FP32_0_765366865 = 0.76536685f;

	private const float FP32_1_847759065 = 1.847759f;

	private const float FP32_0_211164243 = 0.21116424f;

	private const float FP32_1_451774981 = 1.451775f;

	private const float FP32_2_172734803 = 2.1727347f;

	private const float FP32_1_061594337 = 1.0615944f;

	private const float FP32_0_509795579 = 0.5097956f;

	private const float FP32_0_601344887 = 0.6013449f;

	private const float FP32_0_899976223 = 0.8999762f;

	private const float FP32_2_562915447 = 2.5629156f;

	private const float FP32_0_720959822 = 0.72095984f;

	private const float FP32_0_850430095 = 0.8504301f;

	private const float FP32_1_272758580 = 1.2727586f;

	private const float FP32_3_624509785 = 3.6245098f;

	public static void AdjustToIDCT(ref Block8x8F quantTable)
	{
		ref float source = ref Unsafe.As<Block8x8F, float>(ref quantTable);
		for (nuint num = 0u; num < 64; num++)
		{
			ref float reference = ref Unsafe.Add(ref source, num);
			reference = 0.125f * reference;
		}
		quantTable.TransposeInplace();
	}

	public static void TransformIDCT_4x4(ref Block8x8F block, ref Block8x8F dequantTable, float normalizationValue, float maxValue)
	{
		for (int i = 0; i < 8; i++)
		{
			if (i != 4)
			{
				float num = block[i * 8] * dequantTable[i * 8] * 2f;
				float num2 = block[i * 8 + 2] * dequantTable[i * 8 + 2];
				float num3 = block[i * 8 + 6] * dequantTable[i * 8 + 6];
				float num4 = num2 * 1.847759f + num3 * -0.76536685f;
				float num5 = num + num4;
				float num6 = num - num4;
				float num7 = block[i * 8 + 7] * dequantTable[i * 8 + 7];
				num2 = block[i * 8 + 5] * dequantTable[i * 8 + 5];
				num3 = block[i * 8 + 3] * dequantTable[i * 8 + 3];
				float num8 = block[i * 8 + 1] * dequantTable[i * 8 + 1];
				num = num7 * -0.21116424f + num2 * 1.451775f + num3 * -2.1727347f + num8 * 1.0615944f;
				num4 = num7 * -0.5097956f + num2 * -0.6013449f + num3 * 0.8999762f + num8 * 2.5629156f;
				block[i * 8 + 4] = (num5 + num4) * 0.5f;
				block[i * 8 + 3 + 4] = (num5 - num4) * 0.5f;
				block[i * 8 + 1 + 4] = (num6 + num) * 0.5f;
				block[i * 8 + 2 + 4] = (num6 - num) * 0.5f;
			}
		}
		for (int j = 0; j < 4; j++)
		{
			float num9 = block[j + 4] * 2f;
			float num10 = block[j + 16 + 4] * 1.847759f + block[j + 48 + 4] * -0.76536685f;
			float num11 = num9 + num10;
			float num12 = num9 - num10;
			float num13 = block[j + 56 + 4];
			float num14 = block[j + 40 + 4];
			float num15 = block[j + 24 + 4];
			float num16 = block[j + 8 + 4];
			num9 = num13 * -0.21116424f + num14 * 1.451775f + num15 * -2.1727347f + num16 * 1.0615944f;
			num10 = num13 * -0.5097956f + num14 * -0.6013449f + num15 * 0.8999762f + num16 * 2.5629156f;
			block[j * 8] = MathF.Round(Numerics.Clamp((num11 + num10) * 0.5f + normalizationValue, 0f, maxValue));
			block[j * 8 + 3] = MathF.Round(Numerics.Clamp((num11 - num10) * 0.5f + normalizationValue, 0f, maxValue));
			block[j * 8 + 1] = MathF.Round(Numerics.Clamp((num12 + num9) * 0.5f + normalizationValue, 0f, maxValue));
			block[j * 8 + 2] = MathF.Round(Numerics.Clamp((num12 - num9) * 0.5f + normalizationValue, 0f, maxValue));
		}
	}

	public static void TransformIDCT_2x2(ref Block8x8F block, ref Block8x8F dequantTable, float normalizationValue, float maxValue)
	{
		for (int i = 0; i < 8; i++)
		{
			if (i != 2 && i != 4 && i != 6)
			{
				float num = block[i * 8] * dequantTable[i * 8];
				float num2 = num * 4f;
				num = block[i * 8 + 7] * dequantTable[i * 8 + 7];
				float num3 = num * -0.72095984f;
				num = block[i * 8 + 5] * dequantTable[i * 8 + 5];
				num3 += num * 0.8504301f;
				num = block[i * 8 + 3] * dequantTable[i * 8 + 3];
				num3 += num * -1.2727586f;
				num = block[i * 8 + 1] * dequantTable[i * 8 + 1];
				num3 += num * 3.6245098f;
				block[i * 8 + 2] = (num2 + num3) * 0.25f;
				block[i * 8 + 3] = (num2 - num3) * 0.25f;
			}
		}
		for (int j = 0; j < 2; j++)
		{
			float num4 = block[j + 2] * 4f;
			float num5 = block[j + 56 + 2] * -0.72095984f + block[j + 40 + 2] * 0.8504301f + block[j + 24 + 2] * -1.2727586f + block[j + 8 + 2] * 3.6245098f;
			block[j * 8] = MathF.Round(Numerics.Clamp((num4 + num5) * 0.25f + normalizationValue, 0f, maxValue));
			block[j * 8 + 1] = MathF.Round(Numerics.Clamp((num4 - num5) * 0.25f + normalizationValue, 0f, maxValue));
		}
	}

	public static float TransformIDCT_1x1(float dc, float dequantizer, float normalizationValue, float maxValue)
	{
		return MathF.Round(Numerics.Clamp(dc * dequantizer + normalizationValue, 0f, maxValue));
	}
}
