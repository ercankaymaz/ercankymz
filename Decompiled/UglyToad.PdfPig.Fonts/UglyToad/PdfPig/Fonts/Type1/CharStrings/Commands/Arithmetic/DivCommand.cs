namespace UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands.Arithmetic;

internal static class DivCommand
{
	public const string Name = "div";

	public static readonly byte First = 12;

	public static readonly byte? Second = (byte)12;

	public static bool TakeFromStackBottom { get; } = false;

	public static bool ClearsOperandStack { get; } = false;

	public static LazyType1Command Lazy { get; } = new LazyType1Command("div", Run);

	public static void Run(Type1BuildCharContext context)
	{
		double num = context.Stack.PopTop();
		double value = context.Stack.PopTop() / num;
		context.Stack.Push(value);
	}
}
