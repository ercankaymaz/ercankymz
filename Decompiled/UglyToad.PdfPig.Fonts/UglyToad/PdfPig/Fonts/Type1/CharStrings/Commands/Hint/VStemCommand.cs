namespace UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands.Hint;

internal static class VStemCommand
{
	public const string Name = "vstem";

	public static readonly byte First = 3;

	public static readonly byte? Second = null;

	public static bool TakeFromStackBottom { get; } = true;

	public static bool ClearsOperandStack { get; } = true;

	public static LazyType1Command Lazy { get; } = new LazyType1Command("vstem", Run);

	public static void Run(Type1BuildCharContext context)
	{
		context.Stack.PopBottom();
		context.Stack.PopBottom();
		context.Stack.Clear();
	}
}
