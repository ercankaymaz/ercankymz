using System;
using System.Collections.Generic;

namespace UglyToad.PdfPig.Fonts;

public abstract class AdobeStylePrivateDictionary
{
	public abstract class BaseBuilder
	{
		public IReadOnlyList<int> BlueValues { get; set; }

		public IReadOnlyList<int> OtherBlues { get; set; }

		public IReadOnlyList<int> FamilyBlues { get; set; }

		public IReadOnlyList<int> FamilyOtherBlues { get; set; }

		public double? BlueScale { get; set; }

		public int? BlueShift { get; set; }

		public int? BlueFuzz { get; set; }

		public double? StandardHorizontalWidth { get; set; }

		public double? StandardVerticalWidth { get; set; }

		public IReadOnlyList<double> StemSnapHorizontalWidths { get; set; }

		public IReadOnlyList<double> StemSnapVerticalWidths { get; set; }

		public bool? ForceBold { get; set; }

		public int? LanguageGroup { get; set; }

		public double? ExpansionFactor { get; set; }
	}

	public static readonly double DefaultBlueScale = 0.039625;

	public static readonly double DefaultExpansionFactor = 0.06;

	public const int DefaultBlueFuzz = 1;

	public const int DefaultBlueShift = 7;

	public const int DefaultLanguageGroup = 0;

	public IReadOnlyList<int> BlueValues { get; }

	public IReadOnlyList<int> OtherBlues { get; }

	public IReadOnlyList<int> FamilyBlues { get; }

	public IReadOnlyList<int> FamilyOtherBlues { get; }

	public double BlueScale { get; }

	public int BlueShift { get; }

	public int BlueFuzz { get; }

	public double? StandardHorizontalWidth { get; }

	public double? StandardVerticalWidth { get; }

	public IReadOnlyList<double> StemSnapHorizontalWidths { get; }

	public IReadOnlyList<double> StemSnapVerticalWidths { get; }

	public bool ForceBold { get; }

	public int LanguageGroup { get; }

	public double ExpansionFactor { get; }

	protected AdobeStylePrivateDictionary(BaseBuilder builder)
	{
		if (builder == null)
		{
			throw new ArgumentNullException("builder");
		}
		BlueValues = builder.BlueValues ?? Array.Empty<int>();
		OtherBlues = builder.OtherBlues ?? Array.Empty<int>();
		FamilyBlues = builder.FamilyBlues ?? Array.Empty<int>();
		FamilyOtherBlues = builder.FamilyOtherBlues ?? Array.Empty<int>();
		BlueScale = builder.BlueScale ?? DefaultBlueScale;
		BlueFuzz = builder.BlueFuzz ?? 1;
		BlueShift = builder.BlueShift ?? 7;
		StandardHorizontalWidth = builder.StandardHorizontalWidth;
		StandardVerticalWidth = builder.StandardVerticalWidth;
		StemSnapHorizontalWidths = builder.StemSnapHorizontalWidths ?? Array.Empty<double>();
		StemSnapVerticalWidths = builder.StemSnapVerticalWidths ?? Array.Empty<double>();
		ForceBold = builder.ForceBold == true;
		LanguageGroup = builder.LanguageGroup.GetValueOrDefault();
		ExpansionFactor = builder.ExpansionFactor ?? DefaultExpansionFactor;
	}
}
