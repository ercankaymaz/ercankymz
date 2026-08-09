using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands.PathConstruction;

internal static class VMoveToCommand
{
	public const string Name = "vmoveto";

	public static readonly byte First = 4;

	public static readonly byte? Second = null;

	public static bool TakeFromStackBottom { get; } = true;

	public static bool ClearsOperandStack { get; } = true;

	public static LazyType1Command Lazy { get; } = new LazyType1Command("vmoveto", Run);

	public static void Run(Type1BuildCharContext context)
	{
		double num = context.Stack.PopBottom();
		if (context.IsFlexing)
		{
			context.AddFlexPoint(new PdfPoint(0.0, num));
		}
		else
		{
			double y = context.CurrentPosition.Y + num;
			double x = context.CurrentPosition.X;
			context.CurrentPosition = new PdfPoint(x, y);
			context.Path.Add(new PdfSubpath());
			context.Path[context.Path.Count - 1].MoveTo(x, y);
		}
		context.Stack.Clear();
	}
}
