namespace SixLabors.ImageSharp.ColorSpaces;

public static class Illuminants
{
	public static readonly CieXyz A = new CieXyz(1.0985f, 1f, 0.35585f);

	public static readonly CieXyz B = new CieXyz(0.99072f, 1f, 0.85223f);

	public static readonly CieXyz C = new CieXyz(0.98074f, 1f, 1.18232f);

	public static readonly CieXyz D50 = new CieXyz(0.96422f, 1f, 0.82521f);

	public static readonly CieXyz D55 = new CieXyz(0.95682f, 1f, 0.92149f);

	public static readonly CieXyz D65 = new CieXyz(0.95047f, 1f, 1.08883f);

	public static readonly CieXyz D75 = new CieXyz(0.94972f, 1f, 1.22638f);

	public static readonly CieXyz E = new CieXyz(1f, 1f, 1f);

	public static readonly CieXyz F2 = new CieXyz(0.99186f, 1f, 0.67393f);

	public static readonly CieXyz F7 = new CieXyz(0.95041f, 1f, 1.08747f);

	public static readonly CieXyz F11 = new CieXyz(1.00962f, 1f, 0.6435f);
}
