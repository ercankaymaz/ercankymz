using System;

namespace SixLabors.ImageSharp.Processing;

public static class KnownFilterMatrices
{
	public static ColorMatrix AchromatomalyFilter { get; } = new ColorMatrix
	{
		M11 = 0.618f,
		M12 = 0.163f,
		M13 = 0.163f,
		M21 = 0.32f,
		M22 = 0.775f,
		M23 = 0.32f,
		M31 = 0.062f,
		M32 = 0.062f,
		M33 = 0.516f,
		M44 = 1f
	};

	public static ColorMatrix AchromatopsiaFilter { get; } = new ColorMatrix
	{
		M11 = 0.299f,
		M12 = 0.299f,
		M13 = 0.299f,
		M21 = 0.587f,
		M22 = 0.587f,
		M23 = 0.587f,
		M31 = 0.114f,
		M32 = 0.114f,
		M33 = 0.114f,
		M44 = 1f
	};

	public static ColorMatrix DeuteranomalyFilter { get; } = new ColorMatrix
	{
		M11 = 0.8f,
		M12 = 0.258f,
		M21 = 0.2f,
		M22 = 0.742f,
		M23 = 0.142f,
		M33 = 0.858f,
		M44 = 1f
	};

	public static ColorMatrix DeuteranopiaFilter { get; } = new ColorMatrix
	{
		M11 = 0.625f,
		M12 = 0.7f,
		M21 = 0.375f,
		M22 = 0.3f,
		M23 = 0.3f,
		M33 = 0.7f,
		M44 = 1f
	};

	public static ColorMatrix ProtanomalyFilter { get; } = new ColorMatrix
	{
		M11 = 0.817f,
		M12 = 0.333f,
		M21 = 0.183f,
		M22 = 0.667f,
		M23 = 0.125f,
		M33 = 0.875f,
		M44 = 1f
	};

	public static ColorMatrix ProtanopiaFilter { get; } = new ColorMatrix
	{
		M11 = 0.567f,
		M12 = 0.558f,
		M21 = 0.433f,
		M22 = 0.442f,
		M23 = 0.242f,
		M33 = 0.758f,
		M44 = 1f
	};

	public static ColorMatrix TritanomalyFilter { get; } = new ColorMatrix
	{
		M11 = 0.967f,
		M21 = 0.33f,
		M22 = 0.733f,
		M23 = 0.183f,
		M32 = 0.267f,
		M33 = 0.817f,
		M44 = 1f
	};

	public static ColorMatrix TritanopiaFilter { get; } = new ColorMatrix
	{
		M11 = 0.95f,
		M21 = 0.05f,
		M22 = 0.433f,
		M23 = 0.475f,
		M32 = 0.567f,
		M33 = 0.525f,
		M44 = 1f
	};

	public static ColorMatrix BlackWhiteFilter { get; } = new ColorMatrix
	{
		M11 = 1.5f,
		M12 = 1.5f,
		M13 = 1.5f,
		M21 = 1.5f,
		M22 = 1.5f,
		M23 = 1.5f,
		M31 = 1.5f,
		M32 = 1.5f,
		M33 = 1.5f,
		M44 = 1f,
		M51 = -1f,
		M52 = -1f,
		M53 = -1f
	};

	public static ColorMatrix KodachromeFilter { get; } = new ColorMatrix
	{
		M11 = 0.7297023f,
		M22 = 0.6109577f,
		M33 = 0.597218f,
		M44 = 1f,
		M51 = 0.105f,
		M52 = 0.145f,
		M53 = 0.155f
	} * CreateSaturateFilter(1.2f) * CreateContrastFilter(1.35f);

	public static ColorMatrix LomographFilter { get; } = new ColorMatrix
	{
		M11 = 1.5f,
		M22 = 1.45f,
		M33 = 1.16f,
		M44 = 1f,
		M51 = -0.1f,
		M52 = -0.02f,
		M53 = -0.07f
	} * CreateSaturateFilter(1.1f) * CreateContrastFilter(1.33f);

	public static ColorMatrix PolaroidFilter { get; } = new ColorMatrix
	{
		M11 = 1.538f,
		M12 = -0.062f,
		M13 = -0.262f,
		M21 = -0.022f,
		M22 = 1.578f,
		M23 = -0.022f,
		M31 = 0.216f,
		M32 = -0.16f,
		M33 = 1.5831f,
		M44 = 1f,
		M51 = 0.02f,
		M52 = -0.05f,
		M53 = -0.05f
	};

	public static ColorMatrix CreateBrightnessFilter(float amount)
	{
		Guard.MustBeGreaterThanOrEqualTo(amount, 0f, "amount");
		return new ColorMatrix
		{
			M11 = amount,
			M22 = amount,
			M33 = amount,
			M44 = 1f
		};
	}

	public static ColorMatrix CreateContrastFilter(float amount)
	{
		Guard.MustBeGreaterThanOrEqualTo(amount, 0f, "amount");
		float num = -0.5f * amount + 0.5f;
		return new ColorMatrix
		{
			M11 = amount,
			M22 = amount,
			M33 = amount,
			M44 = 1f,
			M51 = num,
			M52 = num,
			M53 = num
		};
	}

	public static ColorMatrix CreateGrayscaleBt601Filter(float amount)
	{
		Guard.MustBeBetweenOrEqualTo(amount, 0f, 1f, "amount");
		amount = 1f - amount;
		ColorMatrix result = default(ColorMatrix);
		result.M11 = 0.299f + 0.701f * amount;
		result.M21 = 0.587f - 0.587f * amount;
		result.M31 = 1f - (result.M11 + result.M21);
		result.M12 = 0.299f - 0.299f * amount;
		result.M22 = 0.587f + 0.2848f * amount;
		result.M32 = 1f - (result.M12 + result.M22);
		result.M13 = 0.299f - 0.299f * amount;
		result.M23 = 0.587f - 0.587f * amount;
		result.M33 = 1f - (result.M13 + result.M23);
		result.M44 = 1f;
		return result;
	}

	public static ColorMatrix CreateGrayscaleBt709Filter(float amount)
	{
		Guard.MustBeBetweenOrEqualTo(amount, 0f, 1f, "amount");
		amount = 1f - amount;
		ColorMatrix result = default(ColorMatrix);
		result.M11 = 0.2126f + 0.7874f * amount;
		result.M21 = 0.7152f - 0.7152f * amount;
		result.M31 = 1f - (result.M11 + result.M21);
		result.M12 = 0.2126f - 0.2126f * amount;
		result.M22 = 0.7152f + 0.2848f * amount;
		result.M32 = 1f - (result.M12 + result.M22);
		result.M13 = 0.2126f - 0.2126f * amount;
		result.M23 = 0.7152f - 0.7152f * amount;
		result.M33 = 1f - (result.M13 + result.M23);
		result.M44 = 1f;
		return result;
	}

	public static ColorMatrix CreateHueFilter(float degrees)
	{
		for (degrees %= 360f; degrees < 0f; degrees += 360f)
		{
		}
		float x = GeometryUtilities.DegreeToRadian(degrees);
		float num = MathF.Cos(x);
		float num2 = MathF.Sin(x);
		return new ColorMatrix
		{
			M11 = 0.213f + num * 0.787f - num2 * 0.213f,
			M21 = 0.715f - num * 0.715f - num2 * 0.715f,
			M31 = 0.072f - num * 0.072f + num2 * 0.928f,
			M12 = 0.213f - num * 0.213f + num2 * 0.143f,
			M22 = 0.715f + num * 0.285f + num2 * 0.14f,
			M32 = 0.072f - num * 0.072f - num2 * 0.283f,
			M13 = 0.213f - num * 0.213f - num2 * 0.787f,
			M23 = 0.715f - num * 0.715f + num2 * 0.715f,
			M33 = 0.072f + num * 0.928f + num2 * 0.072f,
			M44 = 1f
		};
	}

	public static ColorMatrix CreateInvertFilter(float amount)
	{
		Guard.MustBeBetweenOrEqualTo(amount, 0f, 1f, "amount");
		float num = 1f - 2f * amount;
		return new ColorMatrix
		{
			M11 = num,
			M22 = num,
			M33 = num,
			M44 = 1f,
			M51 = amount,
			M52 = amount,
			M53 = amount
		};
	}

	public static ColorMatrix CreateOpacityFilter(float amount)
	{
		Guard.MustBeBetweenOrEqualTo(amount, 0f, 1f, "amount");
		return new ColorMatrix
		{
			M11 = 1f,
			M22 = 1f,
			M33 = 1f,
			M44 = amount
		};
	}

	public static ColorMatrix CreateSaturateFilter(float amount)
	{
		Guard.MustBeGreaterThanOrEqualTo(amount, 0f, "amount");
		ColorMatrix result = default(ColorMatrix);
		result.M11 = 0.213f + 0.787f * amount;
		result.M21 = 0.715f - 0.715f * amount;
		result.M31 = 1f - (result.M11 + result.M21);
		result.M12 = 0.213f - 0.213f * amount;
		result.M22 = 0.715f + 0.285f * amount;
		result.M32 = 1f - (result.M12 + result.M22);
		result.M13 = 0.213f - 0.213f * amount;
		result.M23 = 0.715f - 0.715f * amount;
		result.M33 = 1f - (result.M13 + result.M23);
		result.M44 = 1f;
		return result;
	}

	public static ColorMatrix CreateLightnessFilter(float amount)
	{
		Guard.MustBeGreaterThanOrEqualTo(amount, 0f, "amount");
		amount -= 1f;
		return new ColorMatrix
		{
			M11 = 1f,
			M22 = 1f,
			M33 = 1f,
			M44 = 1f,
			M51 = amount,
			M52 = amount,
			M53 = amount
		};
	}

	public static ColorMatrix CreateSepiaFilter(float amount)
	{
		Guard.MustBeBetweenOrEqualTo(amount, 0f, 1f, "amount");
		amount = 1f - amount;
		return new ColorMatrix
		{
			M11 = 0.393f + 0.607f * amount,
			M21 = 0.769f - 0.769f * amount,
			M31 = 0.189f - 0.189f * amount,
			M12 = 0.349f - 0.349f * amount,
			M22 = 0.686f + 0.314f * amount,
			M32 = 0.168f - 0.168f * amount,
			M13 = 0.272f - 0.272f * amount,
			M23 = 0.534f - 0.534f * amount,
			M33 = 0.131f + 0.869f * amount,
			M44 = 1f
		};
	}
}
