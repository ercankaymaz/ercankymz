using System;
using System.IO;
using UglyToad.PdfPig.Graphics.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Graphics.Operations.General;

public class SetColorRenderingIntent : IGraphicsStateOperation
{
	public const string Symbol = "ri";

	public string Operator => "ri";

	public NameToken RenderingIntent { get; }

	public SetColorRenderingIntent(NameToken renderingIntent)
	{
		RenderingIntent = renderingIntent ?? throw new ArgumentNullException("renderingIntent");
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.GetCurrentState().RenderingIntent = RenderingIntentExtensions.ToRenderingIntent(RenderingIntent);
	}

	public void Write(Stream stream)
	{
		stream.WriteText("/" + RenderingIntent.Data + " ri");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return string.Format("{0} {1}", RenderingIntent, "ri");
	}
}
