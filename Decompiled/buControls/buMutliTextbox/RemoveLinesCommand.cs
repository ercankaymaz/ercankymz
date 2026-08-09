using System.Collections.Generic;
using ns20;
using ns27;

namespace buMutliTextbox;

public class RemoveLinesCommand : UndoableCommand
{
	private List<int> iLines;

	private List<string> list_0 = new List<string>();

	public RemoveLinesCommand(TextSource ts, List<int> iLines)
		: base(ts)
	{
		iLines.Sort();
		this.iLines = iLines;
		class38_1 = (class38_0 = new Class38(ts.CurrentTB.Selection));
	}

	public override void Undo()
	{
		buMultiTextBox currentTB = ts.CurrentTB;
		ts.OnTextChanging();
		currentTB.Selection.BeginUpdate();
		for (int i = 0; i < iLines.Count; i++)
		{
			int num = iLines[i];
			if (num >= ts.Count)
			{
				currentTB.Selection.Start = new Place(ts[ts.Count - 1].Count, ts.Count - 1);
			}
			else
			{
				currentTB.Selection.Start = new Place(0, num);
			}
			Class76.smethod_668(ts);
			currentTB.Selection.Start = new Place(0, num);
			string text = list_0[list_0.Count - i - 1];
			Class76.smethod_351(text, ts);
			ts[num].IsChanged = true;
			if (num >= ts.Count - 1)
			{
				ts[num - 1].IsChanged = true;
			}
			else
			{
				ts[num + 1].IsChanged = true;
			}
			if (text.Trim() != string.Empty)
			{
				ts.OnTextChanged(num, num);
			}
		}
		currentTB.Selection.EndUpdate();
		ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));
	}

	public override void Execute()
	{
		buMultiTextBox currentTB = ts.CurrentTB;
		list_0.Clear();
		ts.OnTextChanging();
		currentTB.Selection.BeginUpdate();
		for (int num = iLines.Count - 1; num >= 0; num--)
		{
			int num2 = iLines[num];
			list_0.Add(ts[num2].Text);
			ts.RemoveLine(num2);
		}
		currentTB.Selection.Start = new Place(0, 0);
		currentTB.Selection.EndUpdate();
		ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));
		class38_1 = new Class38(currentTB.Selection);
	}

	public override UndoableCommand Clone()
	{
		return new RemoveLinesCommand(ts, new List<int>(iLines));
	}
}
