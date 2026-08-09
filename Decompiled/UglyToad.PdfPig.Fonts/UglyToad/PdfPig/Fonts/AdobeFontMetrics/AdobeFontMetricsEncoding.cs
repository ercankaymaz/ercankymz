using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Fonts.Encodings;

namespace UglyToad.PdfPig.Fonts.AdobeFontMetrics;

public class AdobeFontMetricsEncoding : Encoding
{
	public override string EncodingName { get; } = "AFM";

	public AdobeFontMetricsEncoding(AdobeFontMetrics metrics)
	{
		if (metrics == null)
		{
			throw new ArgumentNullException("metrics");
		}
		foreach (KeyValuePair<string, AdobeFontMetricsIndividualCharacterMetric> characterMetric in metrics.CharacterMetrics)
		{
			Add(characterMetric.Value.CharacterCode, characterMetric.Key);
		}
	}
}
