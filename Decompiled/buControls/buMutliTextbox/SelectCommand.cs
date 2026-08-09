using ns20;

namespace buMutliTextbox;

public class SelectCommand : UndoableCommand
{
	public SelectCommand(TextSource ts)
		: base(ts)
	{
	}

	public override void Execute()
	{
		class38_1 = new Class38(ts.CurrentTB.Selection);
	}

	protected override void OnTextChanged(bool invert)
	{
	}

	public override void Undo()
	{
		ts.CurrentTB.Selection = new Range(ts.CurrentTB, class38_1.method_0(), class38_1.method_2());
	}

	public override UndoableCommand Clone()
	{
		SelectCommand selectCommand = new SelectCommand(ts);
		if (class38_1 != null)
		{
			selectCommand.class38_1 = new Class38(new Range(ts.CurrentTB, class38_1.method_0(), class38_1.method_2()));
		}
		return selectCommand;
	}
}
