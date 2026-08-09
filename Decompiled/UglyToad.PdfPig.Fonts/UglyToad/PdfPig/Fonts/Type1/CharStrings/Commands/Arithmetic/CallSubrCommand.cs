using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands.Arithmetic;

internal static class CallSubrCommand
{
	public const string Name = "callsubr";

	public static readonly byte First = 10;

	public static readonly byte? Second = null;

	public static bool TakeFromStackBottom { get; } = false;

	public static bool ClearsOperandStack { get; } = false;

	public static LazyType1Command Lazy { get; } = new LazyType1Command("callsubr", Run);

	public static void Run(Type1BuildCharContext context)
	{
		int key = (int)context.Stack.PopTop();
		foreach (Union<double, LazyType1Command> command in context.Subroutines[key].Commands)
		{
			LazyType1Command b;
			if (command.TryGetFirst(out var a))
			{
				context.Stack.Push(a);
			}
			else if (command.TryGetSecond(out b))
			{
				b.Run(context);
			}
		}
	}
}
