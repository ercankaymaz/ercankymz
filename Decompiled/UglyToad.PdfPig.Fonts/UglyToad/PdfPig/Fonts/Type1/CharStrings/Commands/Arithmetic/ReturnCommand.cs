namespace UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands.Arithmetic;

internal static class ReturnCommand
{
	public const string Name = "return";

	public static readonly byte First = 11;

	public static readonly byte? Second = null;

	public static bool TakeFromStackBottom { get; } = false;

	public static bool ClearsOperandStack { get; } = false;

	public static LazyType1Command Lazy { get; } = new LazyType1Command("return", Run);

	public static void Run(Type1BuildCharContext context)
	{
	}
}
