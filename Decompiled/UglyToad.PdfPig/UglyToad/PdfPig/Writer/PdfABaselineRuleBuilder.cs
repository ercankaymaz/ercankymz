using System;
using System.Collections.Generic;
using System.Xml.Linq;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Writer.Colors;
using UglyToad.PdfPig.Writer.Xmp;

namespace UglyToad.PdfPig.Writer;

internal static class PdfABaselineRuleBuilder
{
	public static void Obey(Dictionary<NameToken, IToken> catalog, Func<IToken, IndirectReferenceToken> writerFunc, PdfDocumentBuilder.DocumentInformationBuilder documentInformationBuilder, PdfAStandard archiveStandard, double version, XDocument? xmpMetadata)
	{
		catalog[NameToken.OutputIntents] = OutputIntentsFactory.GetOutputIntentsArray(writerFunc);
		StreamToken arg = XmpWriter.GenerateXmpStream(documentInformationBuilder, version, archiveStandard, xmpMetadata);
		IndirectReferenceToken value = writerFunc(arg);
		catalog[NameToken.Metadata] = value;
	}
}
