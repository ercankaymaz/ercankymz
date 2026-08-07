// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.ClearSelectedCommand
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns0;
using ns7;
using System;

#nullable disable
namespace buMutliTextbox;

public class ClearSelectedCommand(TextSource ts) : UndoableCommand(ts)
{
  private string string_0;

  public override void Undo()
  {
    this.ts.CurrentTB.Selection.Start = new Place(Class39.smethod_539(this.class1_0), Math.Min(this.class1_0.method_0().iLine, this.class1_0.method_2().iLine));
    this.ts.OnTextChanging();
    Class39.smethod_351(this.string_0, this.ts);
    this.ts.OnTextChanged(this.class1_0.method_0().iLine, this.class1_0.method_2().iLine);
    this.ts.CurrentTB.Selection.Start = this.class1_0.method_0();
    this.ts.CurrentTB.Selection.End = this.class1_0.method_2();
  }

  public override void Execute()
  {
    buMultiTextBox currentTb = this.ts.CurrentTB;
    string text = (string) null;
    this.ts.OnTextChanging(ref text);
    if (text == "")
      throw new ArgumentOutOfRangeException();
    this.string_0 = currentTb.Selection.Text;
    Class39.smethod_348(this.ts);
    this.class1_1 = new Class1(currentTb.Selection);
    this.ts.OnTextChanged(this.class1_1.method_0().iLine, this.class1_1.method_0().iLine);
  }

  public override UndoableCommand Clone() => (UndoableCommand) new ClearSelectedCommand(this.ts);
}
