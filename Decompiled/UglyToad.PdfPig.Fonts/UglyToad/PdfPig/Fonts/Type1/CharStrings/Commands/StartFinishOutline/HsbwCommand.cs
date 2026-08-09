using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands.StartFinishOutline;

internal static class HsbwCommand
{
	public const string Name = "hsbw";

	public static readonly byte First = 13;

	public static readonly byte? Second = null;

	public static bool TakeFromStackBottom { get; } = true;

	public static bool ClearsOperandStack { get; } = true;

	public static LazyType1Command Lazy { get; } = new LazyType1Command("hsbw", Run);

	public static void Run(Type1BuildCharContext context)
	{
		double num = context.Stack.PopBottom();
		double widthX = context.Stack.PopBottom();
		context.LeftSideBearingX = num;
		context.WidthX = widthX;
		context.CurrentPosition = new PdfPoint(num, 0.0);
		context.Stack.Clear();
	}
}
