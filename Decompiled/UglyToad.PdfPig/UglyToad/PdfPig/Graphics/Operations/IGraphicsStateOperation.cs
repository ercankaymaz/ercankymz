using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations;

public interface IGraphicsStateOperation
{
	string Operator { get; }

	void Write(Stream stream);

	void Run(IOperationContext operationContext);
}
