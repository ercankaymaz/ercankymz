using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Graphics.Operations;
using UglyToad.PdfPig.Logging;

namespace UglyToad.PdfPig.Parser;

public interface IPageContentParser
{
	IReadOnlyList<IGraphicsStateOperation> Parse(int pageNumber, IInputBytes inputBytes, ILog log);
}
