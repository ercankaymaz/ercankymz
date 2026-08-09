using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands.PathConstruction;

internal static class HvCurveToCommand
{
	public const string Name = "hvcurveto";

	public static readonly byte First = 31;

	public static readonly byte? Second = null;

	public static bool TakeFromStackBottom { get; } = true;

	public static bool ClearsOperandStack { get; } = true;

	public static LazyType1Command Lazy { get; } = new LazyType1Command("hvcurveto", Run);

	public static void Run(Type1BuildCharContext context)
	{
		double num = context.Stack.PopBottom();
		double num2 = context.Stack.PopBottom();
		double num3 = context.Stack.PopBottom();
		double num4 = context.Stack.PopBottom();
		double num5 = context.CurrentPosition.X + num;
		double y = context.CurrentPosition.Y;
		double num6 = num5 + num2;
		double num7 = y + num3;
		double num8 = num6;
		double num9 = num7 + num4;
		context.Path[context.Path.Count - 1].BezierCurveTo(num5, y, num6, num7, num8, num9);
		context.CurrentPosition = new PdfPoint(num8, num9);
		context.Stack.Clear();
	}
}
