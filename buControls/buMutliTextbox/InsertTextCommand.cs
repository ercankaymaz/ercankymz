// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.InsertTextCommand
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;

#nullable disable
namespace buMutliTextbox;

public class InsertTextCommand : UndoableCommand
{
  public string InsertedText;

  public InsertTextCommand(TextSource ts, string insertedText)
    : base(ts)
  {
    this.InsertedText = insertedText;
  }

  public override void Undo()
  {
    this.ts.CurrentTB.Selection.Start = this.class1_0.method_0();
    this.ts.CurrentTB.Selection.End = this.class1_1.method_0();
    this.ts.OnTextChanging();
    Class39.smethod_348(this.ts);
    base.Undo();
  }

  public override void Execute()
  {
    this.ts.OnTextChanging(ref this.InsertedText);
    Class39.smethod_351(this.InsertedText, this.ts);
    base.Execute();
  }

  public override UndoableCommand Clone()
  {
    return (UndoableCommand) new InsertTextCommand(this.ts, this.InsertedText);
  }
}
