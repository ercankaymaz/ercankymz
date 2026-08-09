using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands.PathConstruction;

namespace UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands.Arithmetic;

internal static class CallOtherSubrCommand
{
	private const int FlexEnd = 0;

	private const int FlexBegin = 1;

	private const int FlexMiddle = 2;

	private const int HintReplacement = 3;

	public const string Name = "callothersubr";

	public static readonly byte First = 12;

	public static readonly byte? Second = (byte)16;

	public static bool TakeFromStackBottom { get; } = false;

	public static bool ClearsOperandStack { get; } = false;

	public static LazyType1Command Lazy { get; } = new LazyType1Command("callothersubr", Run);

	public static void Run(Type1BuildCharContext context)
	{
		int num = (int)context.Stack.PopTop();
		int num2 = (int)context.Stack.PopTop();
		List<double> list = new List<double>(num2);
		for (int i = 0; i < num2; i++)
		{
			list.Add(context.Stack.PopTop());
		}
		switch (num)
		{
		case 0:
		{
			context.IsFlexing = false;
			if (context.FlexPoints.Count < 7)
			{
				throw new NotSupportedException("There must be at least 7 flex points defined by an other subroutine.");
			}
			PdfPoint pdfPoint = context.FlexPoints[0].Translate(context.CurrentPosition.X, context.CurrentPosition.Y);
			PdfPoint pdfPoint2 = context.FlexPoints[1].Translate(pdfPoint.X, pdfPoint.Y).Translate(0.0 - context.CurrentPosition.X, 0.0 - context.CurrentPosition.Y);
			context.Stack.Push(pdfPoint2.X);
			context.Stack.Push(pdfPoint2.Y);
			context.Stack.Push(context.FlexPoints[2].X);
			context.Stack.Push(context.FlexPoints[2].Y);
			context.Stack.Push(context.FlexPoints[3].X);
			context.Stack.Push(context.FlexPoints[3].Y);
			RelativeRCurveToCommand.Run(context);
			context.Stack.Push(context.FlexPoints[4].X);
			context.Stack.Push(context.FlexPoints[4].Y);
			context.Stack.Push(context.FlexPoints[5].X);
			context.Stack.Push(context.FlexPoints[5].Y);
			context.Stack.Push(context.FlexPoints[6].X);
			context.Stack.Push(context.FlexPoints[6].Y);
			RelativeRCurveToCommand.Run(context);
			context.ClearFlexPoints();
			break;
		}
		case 1:
			context.PostscriptStack.Clear();
			context.PostscriptStack.Push(context.CurrentPosition.X);
			context.PostscriptStack.Push(context.CurrentPosition.Y);
			context.IsFlexing = true;
			break;
		case 2:
			context.PostscriptStack.Push(context.CurrentPosition.X);
			context.PostscriptStack.Push(context.CurrentPosition.Y);
			break;
		case 3:
			if (list.Count != 1)
			{
				throw new InvalidOperationException("The hint replacement subroutine only takes a single argument.");
			}
			context.PostscriptStack.Clear();
			context.PostscriptStack.Push(list[0]);
			break;
		default:
		{
			context.PostscriptStack.Clear();
			for (int j = 0; j < list.Count; j++)
			{
				context.PostscriptStack.Push(list[j]);
			}
			break;
		}
		}
	}
}
