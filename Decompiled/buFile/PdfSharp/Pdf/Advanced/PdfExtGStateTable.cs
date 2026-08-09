using System.Collections.Generic;

namespace PdfSharp.Pdf.Advanced;

public sealed class PdfExtGStateTable(PdfDocument document) : PdfResourceTable(document)
{
	private readonly Dictionary<string, PdfExtGState> _strokeAlphaValues = new Dictionary<string, PdfExtGState>();

	private readonly Dictionary<string, PdfExtGState> _nonStrokeStates = new Dictionary<string, PdfExtGState>();

	public PdfExtGState GetExtGStateStroke(double alpha, bool overprint)
	{
		string key = PdfExtGState.MakeKey(alpha, overprint);
		if (!_strokeAlphaValues.TryGetValue(key, out var value))
		{
			value = new PdfExtGState(base.Owner);
			value.StrokeAlpha = alpha;
			if (overprint)
			{
				value.StrokeOverprint = true;
				value.Elements.SetInteger("/OPM", 1);
			}
			_strokeAlphaValues[key] = value;
		}
		return value;
	}

	public PdfExtGState GetExtGStateNonStroke(double alpha, bool overprint)
	{
		string key = PdfExtGState.MakeKey(alpha, overprint);
		if (!_nonStrokeStates.TryGetValue(key, out var value))
		{
			value = new PdfExtGState(base.Owner);
			value.NonStrokeAlpha = alpha;
			if (overprint)
			{
				value.NonStrokeOverprint = true;
				value.Elements.SetInteger("/OPM", 1);
			}
			_nonStrokeStates[key] = value;
		}
		return value;
	}
}
