// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.MultiRangeCommand
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Collections.Generic;

#nullable disable
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
    this.range_0 = this.ts.CurrentTB.Selection.Clone();
  }

  public override void Execute()
  {
    this.list_0.Clear();
    Range range = this.range_0.Clone();
    int int_0 = -1;
    int iLine1 = range.Start.iLine;
    int iLine2 = range.End.iLine;
    this.ts.CurrentTB.Selection.ColumnSelectionMode = false;
    this.ts.CurrentTB.Selection.BeginUpdate();
    this.ts.CurrentTB.BeginUpdate();
    this.ts.CurrentTB.AllowInsertRemoveLines = false;
    try
    {
      if (this.command is InsertTextCommand)
        Class39.smethod_464((this.command as InsertTextCommand).InsertedText, ref int_0, this);
      else if ((!(this.command is InsertCharCommand) || (this.command as InsertCharCommand).c == char.MinValue ? 0 : ((this.command as InsertCharCommand).c != '\b' ? 1 : 0)) != 0)
        Class39.smethod_464((this.command as InsertCharCommand).c.ToString(), ref int_0, this);
      else
        Class39.smethod_651(this, ref int_0);
    }
    catch (ArgumentOutOfRangeException ex)
    {
    }
    finally
    {
      this.ts.CurrentTB.AllowInsertRemoveLines = true;
      this.ts.CurrentTB.EndUpdate();
      this.ts.CurrentTB.Selection = this.range_0;
      if (int_0 >= 0)
      {
        this.ts.CurrentTB.Selection.Start = new Place(int_0, iLine1);
        this.ts.CurrentTB.Selection.End = new Place(int_0, iLine2);
      }
      this.ts.CurrentTB.Selection.ColumnSelectionMode = true;
      this.ts.CurrentTB.Selection.EndUpdate();
    }
  }

  public override void Undo()
  {
    this.ts.CurrentTB.BeginUpdate();
    this.ts.CurrentTB.Selection.BeginUpdate();
    try
    {
      for (int index = this.list_0.Count - 1; index >= 0; --index)
        this.list_0[index].Undo();
    }
    finally
    {
      this.ts.CurrentTB.Selection.EndUpdate();
      this.ts.CurrentTB.EndUpdate();
    }
    this.ts.CurrentTB.Selection = this.range_0.Clone();
    this.ts.CurrentTB.OnTextChanged(this.range_0);
    this.ts.CurrentTB.OnSelectionChanged();
    this.ts.CurrentTB.Selection.ColumnSelectionMode = true;
  }

  public override UndoableCommand Clone() => throw new NotImplementedException();
}
