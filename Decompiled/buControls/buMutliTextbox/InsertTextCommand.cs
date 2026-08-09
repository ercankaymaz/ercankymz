using ns27;

namespace buMutliTextbox;

public class InsertTextCommand : UndoableCommand
{
	public string InsertedText;

	public InsertTextCommand(TextSource ts, string insertedText)
		: base(ts)
	{
		InsertedText = insertedText;
	}

	public override void Undo()
	{
		ts.CurrentTB.Selection.Start = class38_0.method_0();
		ts.CurrentTB.Selection.End = class38_1.method_0();
		ts.OnTextChanging();
		Class76.smethod_348(ts);
		base.Undo();
	}

	public override void Execute()
	{
		ts.OnTextChanging(ref InsertedText);
		Class76.smethod_351(InsertedText, ts);
		base.Execute();
	}

	public override UndoableCommand Clone()
	{
		return new InsertTextCommand(ts, InsertedText);
	}
}
