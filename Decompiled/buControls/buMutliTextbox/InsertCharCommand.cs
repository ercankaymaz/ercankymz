using System;
using ns27;

namespace buMutliTextbox;

public class InsertCharCommand : UndoableCommand
{
	public char c;

	private char char_0 = '\0';

	public InsertCharCommand(TextSource ts, char c)
		: base(ts)
	{
		this.c = c;
	}

	public override void Undo()
	{
		ts.OnTextChanging();
		switch (c)
		{
		case '\n':
			Class76.smethod_350(class38_0.method_0().iLine, ts);
			break;
		case '\b':
		{
			ts.CurrentTB.Selection.Start = class38_1.method_0();
			char char_ = '\0';
			if (char_0 != 0)
			{
				ts.CurrentTB.ExpandBlock(ts.CurrentTB.Selection.Start.iLine);
				Class76.smethod_383(char_0, ref char_, ts);
			}
			break;
		}
		case '\t':
		{
			ts.CurrentTB.ExpandBlock(class38_0.method_0().iLine);
			for (int i = Class76.smethod_539(class38_0); i < Class76.smethod_539(class38_1); i++)
			{
				ts[class38_0.method_0().iLine].RemoveAt(class38_0.method_0().iChar);
			}
			ts.CurrentTB.Selection.Start = class38_0.method_0();
			break;
		}
		default:
			ts.CurrentTB.ExpandBlock(class38_0.method_0().iLine);
			ts[class38_0.method_0().iLine].RemoveAt(class38_0.method_0().iChar);
			ts.CurrentTB.Selection.Start = class38_0.method_0();
			break;
		case '\r':
			break;
		}
		ts.NeedRecalc(new TextSource.TextChangedEventArgs(class38_0.method_0().iLine, class38_0.method_0().iLine));
		base.Undo();
	}

	public override void Execute()
	{
		ts.CurrentTB.ExpandBlock(ts.CurrentTB.Selection.Start.iLine);
		string text = c.ToString();
		ts.OnTextChanging(ref text);
		if (text.Length == 1)
		{
			c = text[0];
		}
		if (!string.IsNullOrEmpty(text))
		{
			if (ts.Count == 0)
			{
				Class76.smethod_668(ts);
			}
			Class76.smethod_383(c, ref char_0, ts);
			ts.NeedRecalc(new TextSource.TextChangedEventArgs(ts.CurrentTB.Selection.Start.iLine, ts.CurrentTB.Selection.Start.iLine));
			base.Execute();
			return;
		}
		throw new ArgumentOutOfRangeException();
	}

	public override UndoableCommand Clone()
	{
		return new InsertCharCommand(ts, c);
	}
}
