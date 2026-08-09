using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands.PathConstruction;

internal static class VLineToCommand
{
	public const string Name = "vlineto";

	public static readonly byte First = 7;

	public static readonly byte? Second = null;

	public static bool TakeFromStackBottom { get; } = true;

	public static bool ClearsOperandStack { get; } = true;

	public static LazyType1Command Lazy { get; } = new LazyType1Command("vlineto", Run);

	public static void Run(Type1BuildCharContext context)
	{
		double num = context.Stack.PopBottom();
		double y = context.CurrentPosition.Y + num;
		context.Path[context.Path.Count - 1].LineTo(context.CurrentPosition.X, y);
		context.CurrentPosition = new PdfPoint(context.CurrentPosition.X, y);
		context.Stack.Clear();
	}
}
