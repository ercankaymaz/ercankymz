using System.Collections.Generic;
using UglyToad.PdfPig.Graphics.Operations;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Graphics;

public interface IGraphicsStateOperationFactory
{
	IGraphicsStateOperation? Create(OperatorToken op, IReadOnlyList<IToken> operands);
}
