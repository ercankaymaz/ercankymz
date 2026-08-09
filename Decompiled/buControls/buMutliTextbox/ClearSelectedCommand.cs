using System;
using ns20;
using ns27;

namespace buMutliTextbox;

public class ClearSelectedCommand : UndoableCommand
{
	private string string_0;

	public ClearSelectedCommand(TextSource ts)
		: base(ts)
	{
	}

	public override void Undo()
	{
		ts.CurrentTB.Selection.Start = new Place(Class76.smethod_539(class38_0), Math.Min(class38_0.method_0().iLine, class38_0.method_2().iLine));
		ts.OnTextChanging();
		Class76.smethod_351(string_0, ts);
		ts.OnTextChanged(class38_0.method_0().iLine, class38_0.method_2().iLine);
		ts.CurrentTB.Selection.Start = class38_0.method_0();
		ts.CurrentTB.Selection.End = class38_0.method_2();
	}

	public override void Execute()
	{
		buMultiTextBox currentTB = ts.CurrentTB;
		string text = null;
		ts.OnTextChanging(ref text);
		if (text == "")
		{
			throw new ArgumentOutOfRangeException();
		}
		string_0 = currentTB.Selection.Text;
		Class76.smethod_348(ts);
		class38_1 = new Class38(currentTB.Selection);
		ts.OnTextChanged(class38_1.method_0().iLine, class38_1.method_0().iLine);
	}

	public override UndoableCommand Clone()
	{
		return new ClearSelectedCommand(ts);
	}
}
