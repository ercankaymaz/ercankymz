// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.ReplaceMultipleTextCommand
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns0;
using ns7;
using System;
using System.Collections.Generic;

#nullable disable
namespace buMutliTextbox;

public class ReplaceMultipleTextCommand : UndoableCommand
{
  private List<ReplaceMultipleTextCommand.ReplaceRange> ranges;
  private List<string> list_0 = new List<string>();

  public ReplaceMultipleTextCommand(
    TextSource ts,
    List<ReplaceMultipleTextCommand.ReplaceRange> ranges)
    : base(ts)
  {
    ranges.Sort((Comparison<ReplaceMultipleTextCommand.ReplaceRange>) ((replaceRange_0, replaceRange_1) => replaceRange_0.ReplacedRange.Start.iLine != replaceRange_1.ReplacedRange.Start.iLine ? replaceRange_0.ReplacedRange.Start.iLine.CompareTo(replaceRange_1.ReplacedRange.Start.iLine) : replaceRange_0.ReplacedRange.Start.iChar.CompareTo(replaceRange_1.ReplacedRange.Start.iChar)));
    this.ranges = ranges;
    this.class1_1 = this.class1_0 = new Class1(ts.CurrentTB.Selection);
  }

  public override void Undo()
  {
    buMultiTextBox currentTb = this.ts.CurrentTB;
    this.ts.OnTextChanging();
    currentTb.Selection.BeginUpdate();
    for (int index1 = 0; index1 < this.ranges.Count; ++index1)
    {
      currentTb.Selection.Start = this.ranges[index1].ReplacedRange.Start;
      for (int index2 = 0; index2 < this.ranges[index1].ReplaceText.Length; ++index2)
        currentTb.Selection.GoRight(true);
      Class39.smethod_348(this.ts);
      Class39.smethod_351(this.list_0[this.ranges.Count - 1 - index1], this.ts);
      this.ts.OnTextChanged(this.ranges[index1].ReplacedRange.Start.iLine, this.ranges[index1].ReplacedRange.Start.iLine);
    }
    currentTb.Selection.EndUpdate();
    this.ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));
  }

  public override void Execute()
  {
    buMultiTextBox currentTb = this.ts.CurrentTB;
    this.list_0.Clear();
    this.ts.OnTextChanging();
    currentTb.Selection.BeginUpdate();
    for (int index = this.ranges.Count - 1; index >= 0; --index)
    {
      currentTb.Selection.Start = this.ranges[index].ReplacedRange.Start;
      currentTb.Selection.End = this.ranges[index].ReplacedRange.End;
      this.list_0.Add(currentTb.Selection.Text);
      Class39.smethod_348(this.ts);
      Class39.smethod_351(this.ranges[index].ReplaceText, this.ts);
      this.ts.OnTextChanged(this.ranges[index].ReplacedRange.Start.iLine, this.ranges[index].ReplacedRange.End.iLine);
    }
    currentTb.Selection.EndUpdate();
    this.ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));
    this.class1_1 = new Class1(currentTb.Selection);
  }

  public override UndoableCommand Clone()
  {
    return (UndoableCommand) new ReplaceMultipleTextCommand(this.ts, new List<ReplaceMultipleTextCommand.ReplaceRange>((IEnumerable<ReplaceMultipleTextCommand.ReplaceRange>) this.ranges));
  }

  public class ReplaceRange
  {
    public Range ReplacedRange { get; set; }

    public string ReplaceText { get; set; }
  }
}
