// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.InsertCharCommand
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;

#nullable disable
namespace buMutliTextbox;

public class InsertCharCommand : UndoableCommand
{
  public char c;
  private char char_0 = char.MinValue;

  public InsertCharCommand(TextSource ts, char c)
    : base(ts)
  {
    this.c = c;
  }

  public override void Undo()
  {
    this.ts.OnTextChanging();
    switch (this.c)
    {
      case '\b':
        this.ts.CurrentTB.Selection.Start = this.class1_1.method_0();
        char minValue = char.MinValue;
        if (this.char_0 > char.MinValue)
        {
          this.ts.CurrentTB.ExpandBlock(this.ts.CurrentTB.Selection.Start.iLine);
          Class39.smethod_383(this.char_0, ref minValue, this.ts);
          goto case '\r';
        }
        goto case '\r';
      case '\t':
        this.ts.CurrentTB.ExpandBlock(this.class1_0.method_0().iLine);
        for (int index = Class39.smethod_539(this.class1_0); index < Class39.smethod_539(this.class1_1); ++index)
          this.ts[this.class1_0.method_0().iLine].RemoveAt(this.class1_0.method_0().iChar);
        this.ts.CurrentTB.Selection.Start = this.class1_0.method_0();
        goto case '\r';
      case '\n':
        Class39.smethod_350(this.class1_0.method_0().iLine, this.ts);
        goto case '\r';
      case '\r':
        this.ts.NeedRecalc(new TextSource.TextChangedEventArgs(this.class1_0.method_0().iLine, this.class1_0.method_0().iLine));
        base.Undo();
        break;
      default:
        this.ts.CurrentTB.ExpandBlock(this.class1_0.method_0().iLine);
        this.ts[this.class1_0.method_0().iLine].RemoveAt(this.class1_0.method_0().iChar);
        this.ts.CurrentTB.Selection.Start = this.class1_0.method_0();
        goto case '\r';
    }
  }

  public override void Execute()
  {
    this.ts.CurrentTB.ExpandBlock(this.ts.CurrentTB.Selection.Start.iLine);
    string text = this.c.ToString();
    this.ts.OnTextChanging(ref text);
    if (text.Length == 1)
      this.c = text[0];
    if (string.IsNullOrEmpty(text))
      throw new ArgumentOutOfRangeException();
    if (this.ts.Count == 0)
      Class39.smethod_668(this.ts);
    Class39.smethod_383(this.c, ref this.char_0, this.ts);
    this.ts.NeedRecalc(new TextSource.TextChangedEventArgs(this.ts.CurrentTB.Selection.Start.iLine, this.ts.CurrentTB.Selection.Start.iLine));
    base.Execute();
  }

  public override UndoableCommand Clone()
  {
    return (UndoableCommand) new InsertCharCommand(this.ts, this.c);
  }
}
