using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ns20;
using ns27;

namespace buMutliTextbox;

public class ReplaceMultipleTextCommand : UndoableCommand
{
	public class ReplaceRange
	{
		[CompilerGenerated]
		private Range range_0;

		[CompilerGenerated]
		private string string_0;

		public Range ReplacedRange
		{
			[CompilerGenerated]
			get
			{
				return range_0;
			}
			[CompilerGenerated]
			set
			{
				range_0 = value;
			}
		}

		public string ReplaceText
		{
			[CompilerGenerated]
			get
			{
				return string_0;
			}
			[CompilerGenerated]
			set
			{
				string_0 = value;
			}
		}
	}

	private List<ReplaceRange> ranges;

	private List<string> list_0 = new List<string>();

	public ReplaceMultipleTextCommand(TextSource ts, List<ReplaceRange> ranges)
		: base(ts)
	{
		ranges.Sort((ReplaceRange replaceRange_0, ReplaceRange replaceRange_1) => (replaceRange_0.ReplacedRange.Start.iLine != replaceRange_1.ReplacedRange.Start.iLine) ? replaceRange_0.ReplacedRange.Start.iLine.CompareTo(replaceRange_1.ReplacedRange.Start.iLine) : replaceRange_0.ReplacedRange.Start.iChar.CompareTo(replaceRange_1.ReplacedRange.Start.iChar));
		this.ranges = ranges;
		class38_1 = (class38_0 = new Class38(ts.CurrentTB.Selection));
	}

	public override void Undo()
	{
		buMultiTextBox currentTB = ts.CurrentTB;
		ts.OnTextChanging();
		currentTB.Selection.BeginUpdate();
		for (int i = 0; i < ranges.Count; i++)
		{
			currentTB.Selection.Start = ranges[i].ReplacedRange.Start;
			for (int j = 0; j < ranges[i].ReplaceText.Length; j++)
			{
				currentTB.Selection.GoRight(shift: true);
			}
			Class76.smethod_348(ts);
			int index = ranges.Count - 1 - i;
			Class76.smethod_351(list_0[index], ts);
			ts.OnTextChanged(ranges[i].ReplacedRange.Start.iLine, ranges[i].ReplacedRange.Start.iLine);
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
		for (int num = ranges.Count - 1; num >= 0; num--)
		{
			currentTB.Selection.Start = ranges[num].ReplacedRange.Start;
			currentTB.Selection.End = ranges[num].ReplacedRange.End;
			list_0.Add(currentTB.Selection.Text);
			Class76.smethod_348(ts);
			Class76.smethod_351(ranges[num].ReplaceText, ts);
			ts.OnTextChanged(ranges[num].ReplacedRange.Start.iLine, ranges[num].ReplacedRange.End.iLine);
		}
		currentTB.Selection.EndUpdate();
		ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));
		class38_1 = new Class38(currentTB.Selection);
	}

	public override UndoableCommand Clone()
	{
		return new ReplaceMultipleTextCommand(ts, new List<ReplaceRange>(ranges));
	}
}
