// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.SyntaxDescriptor
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buMutliTextbox;

public class SyntaxDescriptor : IDisposable
{
  public char leftBracket = '(';
  public char rightBracket = ')';
  public char leftBracket2 = '{';
  public char rightBracket2 = '}';
  public BracketsHighlightStrategy bracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;
  public readonly List<Style> styles = new List<Style>();
  public readonly List<RuleDesc> rules = new List<RuleDesc>();
  public readonly List<FoldingDesc> foldings = new List<FoldingDesc>();

  public void Dispose()
  {
    foreach (Style style in this.styles)
      style.Dispose();
  }
}
