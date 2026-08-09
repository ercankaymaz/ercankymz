namespace UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands.StartFinishOutline;

internal static class EndCharCommand
{
	public const string Name = "endchar";

	public static readonly byte First = 14;

	public static readonly byte? Second = null;

	public static bool TakeFromStackBottom { get; } = false;

	public static bool ClearsOperandStack { get; } = true;

	public static LazyType1Command Lazy { get; } = new LazyType1Command("endchar", Run);

	public static void Run(Type1BuildCharContext context)
	{
		context.Stack.Clear();
	}
}
