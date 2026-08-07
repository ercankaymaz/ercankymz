// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.RuleDesc
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Text.RegularExpressions;

#nullable disable
namespace buMutliTextbox;

public class RuleDesc
{
  private Regex regex_0;
  public string pattern;
  public RegexOptions options = RegexOptions.None;
  public Style style;

  public Regex Regex
  {
    get
    {
      if (this.regex_0 == null)
        this.regex_0 = new Regex(this.pattern, SyntaxHighlighter.RegexCompiledOption | this.options);
      return this.regex_0;
    }
  }
}
