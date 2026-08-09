using System.Collections.Generic;
using ns20;
using ns27;

namespace buMutliTextbox;

public class ReplaceTextCommand : UndoableCommand
{
	private string insertedText;

	private List<Range> ranges;

	private List<string> list_0 = new List<string>();

	public ReplaceTextCommand(TextSource ts, List<Range> ranges, string insertedText)
		: base(ts)
	{
		ranges.Sort((Range range_0, Range range_1) => (range_0.Start.iLine != range_1.Start.iLine) ? range_0.Start.iLine.CompareTo(range_1.Start.iLine) : range_0.Start.iChar.CompareTo(range_1.Start.iChar));
		this.ranges = ranges;
		this.insertedText = insertedText;
		class38_1 = (class38_0 = new Class38(ts.CurrentTB.Selection));
	}

	public override void Undo()
	{
		buMultiTextBox currentTB = ts.CurrentTB;
		ts.OnTextChanging();
		currentTB.BeginUpdate();
		currentTB.Selection.BeginUpdate();
		for (int i = 0; i < ranges.Count; i++)
		{
			currentTB.Selection.Start = ranges[i].Start;
			for (int j = 0; j < insertedText.Length; j++)
			{
				currentTB.Selection.GoRight(shift: true);
			}
			Class76.smethod_405(ts);
			Class76.smethod_351(list_0[list_0.Count - i - 1], ts);
		}
		currentTB.Selection.EndUpdate();
		currentTB.EndUpdate();
		if (ranges.Count > 0)
		{
			ts.OnTextChanged(ranges[0].Start.iLine, ranges[ranges.Count - 1].End.iLine);
		}
		ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));
	}

	public override void Execute()
	{
		buMultiTextBox currentTB = ts.CurrentTB;
		list_0.Clear();
		ts.OnTextChanging(ref insertedText);
		currentTB.Selection.BeginUpdate();
		currentTB.BeginUpdate();
		for (int num = ranges.Count - 1; num >= 0; num--)
		{
			currentTB.Selection.Start = ranges[num].Start;
			currentTB.Selection.End = ranges[num].End;
			list_0.Add(currentTB.Selection.Text);
			Class76.smethod_405(ts);
			if (insertedText != "")
			{
				Class76.smethod_351(insertedText, ts);
			}
		}
		if (ranges.Count > 0)
		{
			ts.OnTextChanged(ranges[0].Start.iLine, ranges[ranges.Count - 1].End.iLine);
		}
		currentTB.EndUpdate();
		currentTB.Selection.EndUpdate();
		ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));
		class38_1 = new Class38(currentTB.Selection);
	}

	public override UndoableCommand Clone()
	{
		return new ReplaceTextCommand(ts, new List<Range>(ranges), insertedText);
	}
}
