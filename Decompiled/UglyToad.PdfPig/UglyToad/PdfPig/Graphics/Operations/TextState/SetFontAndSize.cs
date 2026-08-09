using System;
using System.Globalization;
using System.IO;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Graphics.Operations.TextState;

public class SetFontAndSize : IGraphicsStateOperation
{
	public const string Symbol = "Tf";

	public string Operator => "Tf";

	public NameToken Font { get; }

	public double Size { get; }

	public SetFontAndSize(NameToken font, double size)
	{
		Font = font ?? throw new ArgumentNullException("font");
		Size = size;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.SetFontAndSize(Font, Size);
	}

	public void Write(Stream stream)
	{
		stream.WriteText(Font.ToString());
		stream.WriteWhiteSpace();
		stream.WriteNumberText(Size, "Tf");
	}

	public override string ToString()
	{
		return string.Format("{0} {1} {2}", Font, Size.ToString("G", CultureInfo.InvariantCulture), "Tf");
	}
}
