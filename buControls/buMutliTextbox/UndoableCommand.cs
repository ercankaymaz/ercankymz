// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.UndoableCommand
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns0;

#nullable disable
namespace buMutliTextbox;

public abstract class UndoableCommand : Command
{
  internal Class1 class1_0;
  internal Class1 class1_1;
  internal bool bool_0;

  public UndoableCommand(TextSource ts)
  {
    this.ts = ts;
    this.class1_0 = new Class1(ts.CurrentTB.Selection);
  }

  public virtual void Undo() => this.OnTextChanged(true);

  public override void Execute()
  {
    this.class1_1 = new Class1(this.ts.CurrentTB.Selection);
    this.OnTextChanged(false);
  }

  protected virtual void OnTextChanged(bool invert)
  {
    bool flag = this.class1_0.method_0().iLine < this.class1_1.method_0().iLine;
    if (invert)
    {
      if (flag)
        this.ts.OnTextChanged(this.class1_0.method_0().iLine, this.class1_0.method_0().iLine);
      else
        this.ts.OnTextChanged(this.class1_0.method_0().iLine, this.class1_1.method_0().iLine);
    }
    else if (flag)
      this.ts.OnTextChanged(this.class1_0.method_0().iLine, this.class1_1.method_0().iLine);
    else
      this.ts.OnTextChanged(this.class1_1.method_0().iLine, this.class1_1.method_0().iLine);
  }

  public abstract UndoableCommand Clone();
}
