// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.RemoveLinesCommand
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns0;
using ns7;
using System.Collections.Generic;

#nullable disable
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
    this.class1_1 = this.class1_0 = new Class1(ts.CurrentTB.Selection);
  }

  public override void Undo()
  {
    buMultiTextBox currentTb = this.ts.CurrentTB;
    this.ts.OnTextChanging();
    currentTb.Selection.BeginUpdate();
    for (int index = 0; index < this.iLines.Count; ++index)
    {
      int iLine = this.iLines[index];
      currentTb.Selection.Start = iLine >= this.ts.Count ? new Place(this.ts[this.ts.Count - 1].Count, this.ts.Count - 1) : new Place(0, iLine);
      Class39.smethod_668(this.ts);
      currentTb.Selection.Start = new Place(0, iLine);
      string string_0 = this.list_0[this.list_0.Count - index - 1];
      Class39.smethod_351(string_0, this.ts);
      this.ts[iLine].IsChanged = true;
      if (iLine < this.ts.Count - 1)
        this.ts[iLine + 1].IsChanged = true;
      else
        this.ts[iLine - 1].IsChanged = true;
      if (string_0.Trim() != string.Empty)
        this.ts.OnTextChanged(iLine, iLine);
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
    for (int index = this.iLines.Count - 1; index >= 0; --index)
    {
      int iLine = this.iLines[index];
      this.list_0.Add(this.ts[iLine].Text);
      this.ts.RemoveLine(iLine);
    }
    currentTb.Selection.Start = new Place(0, 0);
    currentTb.Selection.EndUpdate();
    this.ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));
    this.class1_1 = new Class1(currentTb.Selection);
  }

  public override UndoableCommand Clone()
  {
    return (UndoableCommand) new RemoveLinesCommand(this.ts, new List<int>((IEnumerable<int>) this.iLines));
  }
}
