using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands.PathConstruction;

internal static class VhCurveToCommand
{
	public const string Name = "vhcurveto";

	public static readonly byte First = 30;

	public static readonly byte? Second = null;

	public static bool TakeFromStackBottom { get; } = true;

	public static bool ClearsOperandStack { get; } = true;

	public static LazyType1Command Lazy { get; } = new LazyType1Command("vhcurveto", Run);

	public static void Run(Type1BuildCharContext context)
	{
		double num = context.Stack.PopBottom();
		double num2 = context.Stack.PopBottom();
		double num3 = context.Stack.PopBottom();
		double num4 = context.Stack.PopBottom();
		double x = context.CurrentPosition.X;
		double num5 = context.CurrentPosition.Y + num;
		double num6 = x + num2;
		double num7 = num5 + num3;
		double num8 = num6 + num4;
		double num9 = num7;
		context.Path[context.Path.Count - 1].BezierCurveTo(x, num5, num6, num7, num8, num9);
		context.CurrentPosition = new PdfPoint(num8, num9);
		context.Stack.Clear();
	}
}
