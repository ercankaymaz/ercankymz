using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands.PathConstruction;

internal static class RelativeRCurveToCommand
{
	public const string Name = "rrcurveto";

	public static readonly byte First = 8;

	public static readonly byte? Second = null;

	public static bool TakeFromStackBottom { get; } = true;

	public static bool ClearsOperandStack { get; } = true;

	public static LazyType1Command Lazy { get; } = new LazyType1Command("rrcurveto", Run);

	public static void Run(Type1BuildCharContext context)
	{
		double num = context.Stack.PopBottom();
		double num2 = context.Stack.PopBottom();
		double num3 = context.Stack.PopBottom();
		double num4 = context.Stack.PopBottom();
		double num5 = context.Stack.PopBottom();
		double num6 = context.Stack.PopBottom();
		double num7 = context.CurrentPosition.X + num;
		double num8 = context.CurrentPosition.Y + num2;
		double num9 = num7 + num3;
		double num10 = num8 + num4;
		double num11 = num9 + num5;
		double num12 = num10 + num6;
		context.Path[context.Path.Count - 1].BezierCurveTo(num7, num8, num9, num10, num11, num12);
		context.CurrentPosition = new PdfPoint(num11, num12);
		context.Stack.Clear();
	}
}
