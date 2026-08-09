using ns20;

namespace buMutliTextbox;

public abstract class UndoableCommand : Command
{
	internal Class38 class38_0;

	internal Class38 class38_1;

	internal bool bool_0;

	public UndoableCommand(TextSource ts)
	{
		base.ts = ts;
		class38_0 = new Class38(ts.CurrentTB.Selection);
	}

	public virtual void Undo()
	{
		OnTextChanged(invert: true);
	}

	public override void Execute()
	{
		class38_1 = new Class38(ts.CurrentTB.Selection);
		OnTextChanged(invert: false);
	}

	protected virtual void OnTextChanged(bool invert)
	{
		bool flag = class38_0.method_0().iLine < class38_1.method_0().iLine;
		if (!invert)
		{
			if (!flag)
			{
				ts.OnTextChanged(class38_1.method_0().iLine, class38_1.method_0().iLine);
			}
			else
			{
				ts.OnTextChanged(class38_0.method_0().iLine, class38_1.method_0().iLine);
			}
		}
		else if (!flag)
		{
			ts.OnTextChanged(class38_0.method_0().iLine, class38_1.method_0().iLine);
		}
		else
		{
			ts.OnTextChanged(class38_0.method_0().iLine, class38_0.method_0().iLine);
		}
	}

	public abstract UndoableCommand Clone();
}
