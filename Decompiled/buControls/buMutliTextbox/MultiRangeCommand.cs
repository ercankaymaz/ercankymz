using System;
using System.Collections.Generic;
using ns27;

namespace buMutliTextbox;

public class MultiRangeCommand : UndoableCommand
{
	internal UndoableCommand command;

	internal Range range_0;

	internal List<UndoableCommand> list_0 = new List<UndoableCommand>();

	public MultiRangeCommand(UndoableCommand command)
		: base(command.ts)
	{
		this.command = command;
		range_0 = ts.CurrentTB.Selection.Clone();
	}

	public override void Execute()
	{
		list_0.Clear();
		Range range = range_0.Clone();
		int int_ = -1;
		int iLine = range.Start.iLine;
		int iLine2 = range.End.iLine;
		ts.CurrentTB.Selection.ColumnSelectionMode = false;
		ts.CurrentTB.Selection.BeginUpdate();
		ts.CurrentTB.BeginUpdate();
		ts.CurrentTB.AllowInsertRemoveLines = false;
		try
		{
			if (!(command is InsertTextCommand))
			{
				if (!(command is InsertCharCommand) || (command as InsertCharCommand).c == '\0' || (command as InsertCharCommand).c == '\b')
				{
					Class76.smethod_651(this, ref int_);
				}
				else
				{
					Class76.smethod_464((command as InsertCharCommand).c.ToString(), ref int_, this);
				}
			}
			else
			{
				Class76.smethod_464((command as InsertTextCommand).InsertedText, ref int_, this);
			}
		}
		catch (ArgumentOutOfRangeException)
		{
		}
		finally
		{
			ts.CurrentTB.AllowInsertRemoveLines = true;
			ts.CurrentTB.EndUpdate();
			ts.CurrentTB.Selection = range_0;
			if (int_ >= 0)
			{
				ts.CurrentTB.Selection.Start = new Place(int_, iLine);
				ts.CurrentTB.Selection.End = new Place(int_, iLine2);
			}
			ts.CurrentTB.Selection.ColumnSelectionMode = true;
			ts.CurrentTB.Selection.EndUpdate();
		}
	}

	public override void Undo()
	{
		ts.CurrentTB.BeginUpdate();
		ts.CurrentTB.Selection.BeginUpdate();
		try
		{
			for (int num = list_0.Count - 1; num >= 0; num--)
			{
				list_0[num].Undo();
			}
		}
		finally
		{
			ts.CurrentTB.Selection.EndUpdate();
			ts.CurrentTB.EndUpdate();
		}
		ts.CurrentTB.Selection = range_0.Clone();
		ts.CurrentTB.OnTextChanged(range_0);
		ts.CurrentTB.OnSelectionChanged();
		ts.CurrentTB.Selection.ColumnSelectionMode = true;
	}

	public override UndoableCommand Clone()
	{
		throw new NotImplementedException();
	}
}
