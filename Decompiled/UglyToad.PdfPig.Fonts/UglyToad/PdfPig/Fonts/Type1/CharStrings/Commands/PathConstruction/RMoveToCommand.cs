using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands.PathConstruction;

internal static class RMoveToCommand
{
	public const string Name = "rmoveto";

	public static readonly byte First = 21;

	public static readonly byte? Second = null;

	public static bool TakeFromStackBottom { get; } = true;

	public static bool ClearsOperandStack { get; } = true;

	public static LazyType1Command Lazy { get; } = new LazyType1Command("rmoveto", Run);

	public static void Run(Type1BuildCharContext context)
	{
		double num = context.Stack.PopBottom();
		double num2 = context.Stack.PopBottom();
		if (context.IsFlexing)
		{
			context.AddFlexPoint(new PdfPoint(num, num2));
		}
		else
		{
			double x = context.CurrentPosition.X + num;
			double y = context.CurrentPosition.Y + num2;
			context.CurrentPosition = new PdfPoint(x, y);
			context.Path.Add(new PdfSubpath());
			context.Path[context.Path.Count - 1].MoveTo(x, y);
		}
		context.Stack.Clear();
	}
}
