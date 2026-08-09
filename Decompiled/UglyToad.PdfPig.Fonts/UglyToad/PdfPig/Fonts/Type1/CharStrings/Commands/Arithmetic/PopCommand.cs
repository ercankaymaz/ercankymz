namespace UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands.Arithmetic;

internal static class PopCommand
{
	public const string Name = "pop";

	public static readonly byte First = 12;

	public static readonly byte? Second = (byte)17;

	public static bool TakeFromStackBottom { get; } = false;

	public static bool ClearsOperandStack { get; } = false;

	public static LazyType1Command Lazy { get; } = new LazyType1Command("pop", Run);

	public static void Run(Type1BuildCharContext context)
	{
		double value = context.PostscriptStack.PopTop();
		context.Stack.Push(value);
	}
}
