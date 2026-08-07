// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.ReplaceTextCommand
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns0;
using ns7;
using System;
using System.Collections.Generic;

#nullable disable
namespace buMutliTextbox;

public class ReplaceTextCommand : UndoableCommand
{
  private string insertedText;
  private List<Range> ranges;
  private List<string> list_0 = new List<string>();

  public ReplaceTextCommand(TextSource ts, List<Range> ranges, string insertedText)
    : base(ts)
  {
    ranges.Sort((Comparison<Range>) ((range_0, range_1) => range_0.Start.iLine != range_1.Start.iLine ? range_0.Start.iLine.CompareTo(range_1.Start.iLine) : range_0.Start.iChar.CompareTo(range_1.Start.iChar)));
    this.ranges = ranges;
    this.insertedText = insertedText;
    this.class1_1 = this.class1_0 = new Class1(ts.CurrentTB.Selection);
  }

  public override void Undo()
  {
    buMultiTextBox currentTb = this.ts.CurrentTB;
    this.ts.OnTextChanging();
    currentTb.BeginUpdate();
    currentTb.Selection.BeginUpdate();
    for (int index1 = 0; index1 < this.ranges.Count; ++index1)
    {
      currentTb.Selection.Start = this.ranges[index1].Start;
      for (int index2 = 0; index2 < this.insertedText.Length; ++index2)
        currentTb.Selection.GoRight(true);
      Class39.smethod_405(this.ts);
      Class39.smethod_351(this.list_0[this.list_0.Count - index1 - 1], this.ts);
    }
    currentTb.Selection.EndUpdate();
    currentTb.EndUpdate();
    if (this.ranges.Count > 0)
      this.ts.OnTextChanged(this.ranges[0].Start.iLine, this.ranges[this.ranges.Count - 1].End.iLine);
    this.ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));
  }

  public override void Execute()
  {
    buMultiTextBox currentTb = this.ts.CurrentTB;
    this.list_0.Clear();
    this.ts.OnTextChanging(ref this.insertedText);
    currentTb.Selection.BeginUpdate();
    currentTb.BeginUpdate();
    for (int index = this.ranges.Count - 1; index >= 0; --index)
    {
      currentTb.Selection.Start = this.ranges[index].Start;
      currentTb.Selection.End = this.ranges[index].End;
      this.list_0.Add(currentTb.Selection.Text);
      Class39.smethod_405(this.ts);
      if (this.insertedText != "")
        Class39.smethod_351(this.insertedText, this.ts);
    }
    if (this.ranges.Count > 0)
      this.ts.OnTextChanged(this.ranges[0].Start.iLine, this.ranges[this.ranges.Count - 1].End.iLine);
    currentTb.EndUpdate();
    currentTb.Selection.EndUpdate();
    this.ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));
    this.class1_1 = new Class1(currentTb.Selection);
  }

  public override UndoableCommand Clone()
  {
    return (UndoableCommand) new ReplaceTextCommand(this.ts, new List<Range>((IEnumerable<Range>) this.ranges), this.insertedText);
  }
}
