namespace UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands.Hint;

internal static class DotSectionCommand
{
	public const string Name = "dotsection";

	public static readonly byte First = 12;

	public static readonly byte? Second = 0;

	public static bool TakeFromStackBottom { get; } = false;

	public static bool ClearsOperandStack { get; } = true;

	public static LazyType1Command Lazy { get; } = new LazyType1Command("dotsection", Run);

	public static void Run(Type1BuildCharContext context)
	{
		context.Stack.Clear();
	}
}
