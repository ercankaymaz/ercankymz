namespace UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands.Arithmetic;

internal static class SetCurrentPointCommand
{
	public const string Name = "setcurrentpoint";

	public static readonly byte First = 12;

	public static readonly byte? Second = (byte)33;

	public static bool TakeFromStackBottom { get; } = true;

	public static bool ClearsOperandStack { get; } = true;

	public static LazyType1Command Lazy { get; } = new LazyType1Command("setcurrentpoint", Run);

	public static void Run(Type1BuildCharContext context)
	{
		context.Stack.PopBottom();
		context.Stack.PopBottom();
		context.Stack.Clear();
	}
}
