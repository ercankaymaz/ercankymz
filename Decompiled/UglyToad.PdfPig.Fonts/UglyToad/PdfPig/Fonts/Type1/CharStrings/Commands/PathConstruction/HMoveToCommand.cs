using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands.PathConstruction;

internal static class HMoveToCommand
{
	public const string Name = "hmoveto";

	public static readonly byte First = 22;

	public static readonly byte? Second = null;

	public static bool TakeFromStackBottom { get; } = true;

	public static bool ClearsOperandStack { get; } = true;

	public static LazyType1Command Lazy { get; } = new LazyType1Command("hmoveto", Run);

	public static void Run(Type1BuildCharContext context)
	{
		double num = context.Stack.PopBottom();
		if (context.IsFlexing)
		{
			context.AddFlexPoint(new PdfPoint(num, 0.0));
		}
		else
		{
			double x = context.CurrentPosition.X + num;
			double y = context.CurrentPosition.Y;
			context.CurrentPosition = new PdfPoint(x, y);
			context.Path.Add(new PdfSubpath());
			context.Path[context.Path.Count - 1].MoveTo(x, y);
		}
		context.Stack.Clear();
	}
}
