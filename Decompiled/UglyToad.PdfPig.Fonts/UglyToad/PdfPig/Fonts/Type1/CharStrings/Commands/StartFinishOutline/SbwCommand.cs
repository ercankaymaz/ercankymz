using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands.StartFinishOutline;

internal static class SbwCommand
{
	public const string Name = "sbw";

	public static readonly byte First = 12;

	public static readonly byte? Second = (byte)7;

	public static bool TakeFromStackBottom { get; } = true;

	public static bool ClearsOperandStack { get; } = true;

	public static LazyType1Command Lazy { get; } = new LazyType1Command("sbw", Run);

	public static void Run(Type1BuildCharContext context)
	{
		double num = context.Stack.PopBottom();
		double num2 = context.Stack.PopBottom();
		double widthX = context.Stack.PopBottom();
		double widthY = context.Stack.PopBottom();
		context.LeftSideBearingX = num;
		context.LeftSideBearingY = num2;
		context.WidthX = widthX;
		context.WidthY = widthY;
		context.CurrentPosition = new PdfPoint(num, num2);
		context.Stack.Clear();
	}
}
