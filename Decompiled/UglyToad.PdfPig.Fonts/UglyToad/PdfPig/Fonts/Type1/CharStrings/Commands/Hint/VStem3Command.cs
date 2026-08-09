namespace UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands.Hint;

internal class VStem3Command
{
	public const string Name = "vstem3";

	public static readonly byte First = 12;

	public static readonly byte? Second = (byte)1;

	public static bool TakeFromStackBottom { get; } = true;

	public static bool ClearsOperandStack { get; } = true;

	public static LazyType1Command Lazy { get; } = new LazyType1Command("vstem3", Run);

	public static void Run(Type1BuildCharContext context)
	{
		context.Stack.PopBottom();
		context.Stack.PopBottom();
		context.Stack.PopBottom();
		context.Stack.PopBottom();
		context.Stack.PopBottom();
		context.Stack.PopBottom();
		context.Stack.Clear();
	}
}
