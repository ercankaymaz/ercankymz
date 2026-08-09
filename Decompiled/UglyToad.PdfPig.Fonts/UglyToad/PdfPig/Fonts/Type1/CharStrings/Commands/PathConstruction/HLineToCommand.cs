using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands.PathConstruction;

internal static class HLineToCommand
{
	public const string Name = "hlineto";

	public static readonly byte First = 6;

	public static readonly byte? Second = null;

	public static bool TakeFromStackBottom { get; } = true;

	public static bool ClearsOperandStack { get; } = true;

	public static LazyType1Command Lazy { get; } = new LazyType1Command("hlineto", Run);

	public static void Run(Type1BuildCharContext context)
	{
		double num = context.Stack.PopBottom();
		double x = context.CurrentPosition.X + num;
		context.Path[context.Path.Count - 1].LineTo(x, context.CurrentPosition.Y);
		context.CurrentPosition = new PdfPoint(x, context.CurrentPosition.Y);
		context.Stack.Clear();
	}
}
