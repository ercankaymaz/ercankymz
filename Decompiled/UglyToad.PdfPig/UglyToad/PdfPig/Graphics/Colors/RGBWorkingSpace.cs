using System;

namespace UglyToad.PdfPig.Graphics.Colors;

internal class RGBWorkingSpace
{
	internal class XYZReferenceWhite
	{
		public readonly (double X, double Y, double Z) A = (X: 1.0985, Y: 1.0, Z: 0.35585);

		public readonly (double X, double Y, double Z) B = (X: 0.99072, Y: 1.0, Z: 0.85223);

		public readonly (double X, double Y, double Z) C = (X: 0.98074, Y: 1.0, Z: 1.18232);

		public readonly (double X, double Y, double Z) D50 = (X: 0.96422, Y: 1.0, Z: 0.82521);

		public readonly (double X, double Y, double Z) D55 = (X: 0.95682, Y: 1.0, Z: 0.92149);

		public readonly (double X, double Y, double Z) D65 = (X: 0.95047, Y: 1.0, Z: 1.08883);

		public readonly (double X, double Y, double Z) D75 = (X: 0.94972, Y: 1.0, Z: 1.22638);

		public readonly (double X, double Y, double Z) E = (X: 1.0, Y: 1.0, Z: 1.0);

		public readonly (double X, double Y, double Z) F2 = (X: 0.99186, Y: 1.0, Z: 0.67393);

		public readonly (double X, double Y, double Z) F7 = (X: 0.95041, Y: 1.0, Z: 1.08747);

		public readonly (double X, double Y, double Z) F11 = (X: 1.00962, Y: 1.0, Z: 0.6435);

		internal XYZReferenceWhite()
		{
		}
	}

	public static readonly XYZReferenceWhite ReferenceWhites = new XYZReferenceWhite();

	public static readonly RGBWorkingSpace AdobeRGB1998 = new RGBWorkingSpace
	{
		GammaCorrection = CreateGammaFunc(2.2),
		ReferenceWhite = ReferenceWhites.D65,
		RedPrimary = (x: 0.64, y: 0.33, Y: 0.297361),
		GreenPrimary = (x: 0.21, y: 0.71, Y: 0.627355),
		BluePrimary = (x: 0.15, y: 0.06, Y: 0.075285)
	};

	public static readonly RGBWorkingSpace AppleRGB = new RGBWorkingSpace
	{
		GammaCorrection = CreateGammaFunc(1.8),
		ReferenceWhite = ReferenceWhites.D65,
		RedPrimary = (x: 0.625, y: 0.34, Y: 0.244634),
		GreenPrimary = (x: 0.28, y: 0.595, Y: 0.672034),
		BluePrimary = (x: 0.155, y: 0.07, Y: 0.083332)
	};

	public static readonly RGBWorkingSpace BestRGB = new RGBWorkingSpace
	{
		GammaCorrection = CreateGammaFunc(2.2),
		ReferenceWhite = ReferenceWhites.D50,
		RedPrimary = (x: 0.7347, y: 0.2653, Y: 0.228457),
		GreenPrimary = (x: 0.215, y: 0.775, Y: 0.737352),
		BluePrimary = (x: 0.13, y: 0.035, Y: 0.034191)
	};

	public static readonly RGBWorkingSpace BetaRGB = new RGBWorkingSpace
	{
		GammaCorrection = CreateGammaFunc(2.2),
		ReferenceWhite = ReferenceWhites.D50,
		RedPrimary = (x: 0.6888, y: 0.3112, Y: 0.303273),
		GreenPrimary = (x: 0.1986, y: 0.7551, Y: 0.663786),
		BluePrimary = (x: 0.1265, y: 0.0352, Y: 0.032941)
	};

	public static readonly RGBWorkingSpace BruceRGB = new RGBWorkingSpace
	{
		GammaCorrection = CreateGammaFunc(2.2),
		ReferenceWhite = ReferenceWhites.D65,
		RedPrimary = (x: 0.64, y: 0.33, Y: 0.240995),
		GreenPrimary = (x: 0.28, y: 0.65, Y: 0.683554),
		BluePrimary = (x: 0.15, y: 0.06, Y: 0.075452)
	};

	public static readonly RGBWorkingSpace CIE_RGB = new RGBWorkingSpace
	{
		GammaCorrection = CreateGammaFunc(2.2),
		ReferenceWhite = ReferenceWhites.E,
		RedPrimary = (x: 0.735, y: 0.265, Y: 0.176204),
		GreenPrimary = (x: 0.274, y: 0.717, Y: 0.812985),
		BluePrimary = (x: 0.167, y: 0.009, Y: 0.010811)
	};

	public static readonly RGBWorkingSpace ColorMatchRGB = new RGBWorkingSpace
	{
		GammaCorrection = CreateGammaFunc(1.8),
		ReferenceWhite = ReferenceWhites.D50,
		RedPrimary = (x: 0.63, y: 0.34, Y: 0.274884),
		GreenPrimary = (x: 0.295, y: 0.605, Y: 0.658132),
		BluePrimary = (x: 0.15, y: 0.075, Y: 0.066985)
	};

	public static readonly RGBWorkingSpace DonRGB4 = new RGBWorkingSpace
	{
		GammaCorrection = CreateGammaFunc(2.2),
		ReferenceWhite = ReferenceWhites.D50,
		RedPrimary = (x: 0.696, y: 0.3, Y: 0.27835),
		GreenPrimary = (x: 0.215, y: 0.765, Y: 0.68797),
		BluePrimary = (x: 0.13, y: 0.035, Y: 0.03368)
	};

	public static readonly RGBWorkingSpace EktaSpacePS5 = new RGBWorkingSpace
	{
		GammaCorrection = CreateGammaFunc(2.2),
		ReferenceWhite = ReferenceWhites.D50,
		RedPrimary = (x: 0.695, y: 0.305, Y: 0.260629),
		GreenPrimary = (x: 0.26, y: 0.7, Y: 0.734946),
		BluePrimary = (x: 0.11, y: 0.005, Y: 0.004425)
	};

	public static readonly RGBWorkingSpace NTSC_RGB = new RGBWorkingSpace
	{
		GammaCorrection = CreateGammaFunc(2.2),
		ReferenceWhite = ReferenceWhites.C,
		RedPrimary = (x: 0.67, y: 0.33, Y: 0.298839),
		GreenPrimary = (x: 0.21, y: 0.71, Y: 0.586811),
		BluePrimary = (x: 0.14, y: 0.08, Y: 0.11435)
	};

	public static readonly RGBWorkingSpace PAL_SECAM_RGB = new RGBWorkingSpace
	{
		GammaCorrection = CreateGammaFunc(2.2),
		ReferenceWhite = ReferenceWhites.D65,
		RedPrimary = (x: 0.64, y: 0.33, Y: 0.222021),
		GreenPrimary = (x: 0.29, y: 0.6, Y: 0.706645),
		BluePrimary = (x: 0.15, y: 0.06, Y: 0.071334)
	};

	public static readonly RGBWorkingSpace ProPhotoRGB = new RGBWorkingSpace
	{
		GammaCorrection = CreateGammaFunc(1.8),
		ReferenceWhite = ReferenceWhites.D50,
		RedPrimary = (x: 0.7347, y: 0.2653, Y: 0.28804),
		GreenPrimary = (x: 0.1596, y: 0.8404, Y: 0.711874),
		BluePrimary = (x: 0.0366, y: 0.0001, Y: 8.6E-05)
	};

	public static readonly RGBWorkingSpace SMPTE_C_RGB = new RGBWorkingSpace
	{
		GammaCorrection = CreateGammaFunc(2.2),
		ReferenceWhite = ReferenceWhites.D65,
		RedPrimary = (x: 0.63, y: 0.34, Y: 0.212395),
		GreenPrimary = (x: 0.31, y: 0.595, Y: 0.701049),
		BluePrimary = (x: 0.155, y: 0.07, Y: 0.086556)
	};

	public static readonly RGBWorkingSpace sRGB = new RGBWorkingSpace
	{
		GammaCorrection = (double val) => (!(val <= 0.0031308)) ? (1.055 * Math.Pow(val, 5.0 / 12.0) - 0.055) : (12.92 * val),
		ReferenceWhite = ReferenceWhites.D65,
		RedPrimary = (x: 0.64, y: 0.33, Y: 0.212656),
		GreenPrimary = (x: 0.3, y: 0.6, Y: 0.715158),
		BluePrimary = (x: 0.15, y: 0.06, Y: 0.072186)
	};

	public static readonly RGBWorkingSpace WideGamutRGB = new RGBWorkingSpace
	{
		GammaCorrection = CreateGammaFunc(2.2),
		ReferenceWhite = ReferenceWhites.D50,
		RedPrimary = (x: 0.735, y: 0.265, Y: 0.258187),
		GreenPrimary = (x: 0.115, y: 0.826, Y: 0.724938),
		BluePrimary = (x: 0.157, y: 0.018, Y: 0.016875)
	};

	public Func<double, double> GammaCorrection { get; private set; }

	public (double X, double Y, double Z) ReferenceWhite { get; private set; }

	public (double x, double y, double Y) RedPrimary { get; private set; }

	public (double x, double y, double Y) BluePrimary { get; private set; }

	public (double x, double y, double Y) GreenPrimary { get; private set; }

	private static Func<double, double> CreateGammaFunc(double gamma)
	{
		return delegate(double val)
		{
			double num = Math.Pow(val, 1.0 / gamma);
			return (!double.IsNaN(num)) ? num : 0.0;
		};
	}
}
