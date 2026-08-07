// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.SelectCommand
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns0;

#nullable disable
namespace buMutliTextbox;

public class SelectCommand(TextSource ts) : UndoableCommand(ts)
{
  public override void Execute() => this.class1_1 = new Class1(this.ts.CurrentTB.Selection);

  protected override void OnTextChanged(bool invert)
  {
  }

  public override void Undo()
  {
    this.ts.CurrentTB.Selection = new Range(this.ts.CurrentTB, this.class1_1.method_0(), this.class1_1.method_2());
  }

  public override UndoableCommand Clone()
  {
    SelectCommand selectCommand = new SelectCommand(this.ts);
    if (this.class1_1 != null)
      selectCommand.class1_1 = new Class1(new Range(this.ts.CurrentTB, this.class1_1.method_0(), this.class1_1.method_2()));
    return (UndoableCommand) selectCommand;
  }
}
