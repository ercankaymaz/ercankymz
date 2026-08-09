using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Graphics.Colors;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Graphics;

public interface IColorSpaceContext : IDeepCloneable<IColorSpaceContext>
{
	ColorSpaceDetails CurrentStrokingColorSpace { get; }

	ColorSpaceDetails CurrentNonStrokingColorSpace { get; }

	void SetStrokingColorspace(NameToken colorspace, DictionaryToken? dictionary = null);

	void SetNonStrokingColorspace(NameToken colorspace, DictionaryToken? dictionary = null);

	void SetStrokingColor(IReadOnlyList<double> operands, NameToken? patternName = null);

	void SetStrokingColorGray(double gray);

	void SetStrokingColorRgb(double r, double g, double b);

	void SetStrokingColorCmyk(double c, double m, double y, double k);

	void SetNonStrokingColor(IReadOnlyList<double> operands, NameToken? patternName = null);

	void SetNonStrokingColorGray(double gray);

	void SetNonStrokingColorRgb(double r, double g, double b);

	void SetNonStrokingColorCmyk(double c, double m, double y, double k);
}
