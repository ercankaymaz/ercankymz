// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.SyntaxHighlighter
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Xml;

#nullable disable
namespace buMutliTextbox;

public class SyntaxHighlighter : IDisposable
{
  protected static readonly Platform platformType = PlatformType.GetOperationSystemPlatform();
  public readonly Style BlueBoldStyle = (Style) new TextStyle(Brushes.Blue, (Brush) null, FontStyle.Bold);
  public readonly Style BlueStyle = (Style) new TextStyle(Brushes.Blue, (Brush) null, FontStyle.Regular);
  public readonly Style BoldStyle = (Style) new TextStyle((Brush) null, (Brush) null, FontStyle.Bold | FontStyle.Underline);
  public readonly Style BrownStyle = (Style) new TextStyle(Brushes.Brown, (Brush) null, FontStyle.Italic);
  public readonly Style GrayStyle = (Style) new TextStyle(Brushes.Gray, (Brush) null, FontStyle.Regular);
  public readonly Style GreenStyle = (Style) new TextStyle(Brushes.Green, (Brush) null, FontStyle.Italic);
  public readonly Style MagentaStyle = (Style) new TextStyle(Brushes.Magenta, (Brush) null, FontStyle.Regular);
  public readonly Style MaroonStyle = (Style) new TextStyle(Brushes.Maroon, (Brush) null, FontStyle.Regular);
  public readonly Style RedStyle = (Style) new TextStyle(Brushes.Red, (Brush) null, FontStyle.Regular);
  public readonly Style BlackStyle = (Style) new TextStyle(Brushes.Black, (Brush) null, FontStyle.Regular);
  protected readonly Dictionary<string, SyntaxDescriptor> descByXMLfileNames = new Dictionary<string, SyntaxDescriptor>();
  protected readonly List<Style> resilientStyles = new List<Style>(5);
  protected Regex CSharpAttributeRegex;
  protected Regex CSharpClassNameRegex;
  protected Regex CSharpCommentRegex1;
  protected Regex CSharpCommentRegex2;
  protected Regex CSharpCommentRegex3;
  protected Regex CSharpKeywordRegex;
  protected Regex CSharpNumberRegex;
  protected Regex CSharpStringRegex;
  protected Regex HTMLAttrRegex;
  protected Regex HTMLAttrValRegex;
  protected Regex HTMLCommentRegex1;
  protected Regex HTMLCommentRegex2;
  protected Regex HTMLEndTagRegex;
  protected Regex HTMLEntityRegex;
  protected Regex HTMLTagContentRegex;
  protected Regex HTMLTagNameRegex;
  protected Regex HTMLTagRegex;
  protected Regex XMLAttrRegex;
  protected Regex XMLAttrValRegex;
  protected Regex XMLCommentRegex1;
  protected Regex XMLCommentRegex2;
  protected Regex XMLEndTagRegex;
  protected Regex XMLEntityRegex;
  protected Regex XMLTagContentRegex;
  protected Regex XMLTagNameRegex;
  protected Regex XMLTagRegex;
  protected Regex XMLCDataRegex;
  protected internal Regex XMLFoldingRegex;
  protected Regex JScriptCommentRegex1;
  protected Regex JScriptCommentRegex2;
  protected Regex JScriptCommentRegex3;
  protected Regex JScriptKeywordRegex;
  protected Regex JScriptNumberRegex;
  protected Regex JScriptStringRegex;
  protected Regex LuaCommentRegex1;
  protected Regex LuaCommentRegex2;
  protected Regex LuaCommentRegex3;
  protected Regex LuaKeywordRegex;
  protected Regex LuaNumberRegex;
  protected Regex LuaStringRegex;
  protected Regex LuaFunctionsRegex;
  protected Regex PHPCommentRegex1;
  protected Regex PHPCommentRegex2;
  protected Regex PHPCommentRegex3;
  protected Regex PHPKeywordRegex1;
  protected Regex PHPKeywordRegex2;
  protected Regex PHPKeywordRegex3;
  protected Regex PHPNumberRegex;
  protected Regex PHPStringRegex;
  protected Regex PHPVarRegex;
  protected Regex SQLCommentRegex1;
  protected Regex SQLCommentRegex2;
  protected Regex SQLCommentRegex3;
  protected Regex SQLCommentRegex4;
  protected Regex SQLFunctionsRegex;
  protected Regex SQLKeywordsRegex;
  protected Regex SQLNumberRegex;
  protected Regex SQLStatementsRegex;
  protected Regex SQLStringRegex;
  protected Regex SQLTypesRegex;
  protected Regex SQLVarRegex;
  protected Regex VBClassNameRegex;
  protected Regex VBCommentRegex;
  protected Regex VBKeywordRegex;
  protected Regex VBNumberRegex;
  protected Regex VBStringRegex;
  protected buMultiTextBox currentTb;

  public static RegexOptions RegexCompiledOption
  {
    get
    {
      return SyntaxHighlighter.platformType != Platform.X86 ? RegexOptions.None : RegexOptions.Compiled;
    }
  }

  public SyntaxHighlighter(buMultiTextBox currentTb) => this.currentTb = currentTb;

  public void Dispose()
  {
    foreach (SyntaxDescriptor syntaxDescriptor in this.descByXMLfileNames.Values)
      syntaxDescriptor.Dispose();
  }

  public virtual void HighlightSyntax(Language language, Range range)
  {
    switch (language)
    {
      case Language.CSharp:
        this.CSharpSyntaxHighlight(range);
        break;
      case Language.VB:
        this.VBSyntaxHighlight(range);
        break;
      case Language.HTML:
        this.HTMLSyntaxHighlight(range);
        break;
      case Language.XML:
        this.XMLSyntaxHighlight(range);
        break;
      case Language.SQL:
        this.SQLSyntaxHighlight(range);
        break;
      case Language.PHP:
        this.PHPSyntaxHighlight(range);
        break;
      case Language.JS:
        this.JScriptSyntaxHighlight(range);
        break;
      case Language.Lua:
        this.LuaSyntaxHighlight(range);
        break;
    }
  }

  public virtual void HighlightSyntax(string XMLdescriptionFile, Range range)
  {
    SyntaxDescriptor desc = (SyntaxDescriptor) null;
    if (!this.descByXMLfileNames.TryGetValue(XMLdescriptionFile, out desc))
    {
      XmlDocument doc = new XmlDocument();
      string path = XMLdescriptionFile;
      if (!File.Exists(path))
        path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.GetFileName(path));
      doc.LoadXml(File.ReadAllText(path));
      desc = SyntaxHighlighter.ParseXmlDescription(doc);
      this.descByXMLfileNames[XMLdescriptionFile] = desc;
    }
    this.HighlightSyntax(desc, range);
  }

  public virtual void AutoIndentNeeded(object sender, AutoIndentEventArgs e)
  {
    switch ((sender as buMultiTextBox).Language)
    {
      case Language.CSharp:
        this.CSharpAutoIndentNeeded(sender, e);
        break;
      case Language.VB:
        this.VBAutoIndentNeeded(sender, e);
        break;
      case Language.HTML:
        this.HTMLAutoIndentNeeded(sender, e);
        break;
      case Language.XML:
        this.XMLAutoIndentNeeded(sender, e);
        break;
      case Language.SQL:
        this.SQLAutoIndentNeeded(sender, e);
        break;
      case Language.PHP:
        this.PHPAutoIndentNeeded(sender, e);
        break;
      case Language.JS:
        this.CSharpAutoIndentNeeded(sender, e);
        break;
      case Language.Lua:
        this.LuaAutoIndentNeeded(sender, e);
        break;
    }
  }

  protected void PHPAutoIndentNeeded(object sender, AutoIndentEventArgs e)
  {
    if (Regex.IsMatch(e.LineText, "^[^\"']*\\{.*\\}[^\"']*$"))
      return;
    if (Regex.IsMatch(e.LineText, "^[^\"']*\\{"))
      e.ShiftNextLines = e.TabLength;
    else if (Regex.IsMatch(e.LineText, "}[^\"']*$"))
    {
      e.Shift = -e.TabLength;
      e.ShiftNextLines = -e.TabLength;
    }
    else
    {
      if (!Regex.IsMatch(e.PrevLineText, "^\\s*(if|for|foreach|while|[\\}\\s]*else)\\b[^{]*$") || Regex.IsMatch(e.PrevLineText, "(;\\s*$)|(;\\s*//)"))
        return;
      e.Shift = e.TabLength;
    }
  }

  protected void SQLAutoIndentNeeded(object sender, AutoIndentEventArgs e)
  {
    (sender as buMultiTextBox).vmethod_0(sender, e);
  }

  protected void HTMLAutoIndentNeeded(object sender, AutoIndentEventArgs e)
  {
    (sender as buMultiTextBox).vmethod_0(sender, e);
  }

  protected void XMLAutoIndentNeeded(object sender, AutoIndentEventArgs e)
  {
    (sender as buMultiTextBox).vmethod_0(sender, e);
  }

  protected void VBAutoIndentNeeded(object sender, AutoIndentEventArgs e)
  {
    if (Regex.IsMatch(e.LineText, "^\\s*(End|EndIf|Next|Loop)\\b", RegexOptions.IgnoreCase))
    {
      e.Shift = -e.TabLength;
      e.ShiftNextLines = -e.TabLength;
    }
    else if (Regex.IsMatch(e.LineText, "\\b(Class|Property|Enum|Structure|Sub|Function|Namespace|Interface|Get)\\b|(Set\\s*\\()", RegexOptions.IgnoreCase))
    {
      e.ShiftNextLines = e.TabLength;
    }
    else
    {
      if (Regex.IsMatch(e.LineText, "\\b(Then)\\s*\\S+", RegexOptions.IgnoreCase))
        return;
      if (Regex.IsMatch(e.LineText, "^\\s*(If|While|For|Do|Try|With|Using|Select)\\b", RegexOptions.IgnoreCase))
        e.ShiftNextLines = e.TabLength;
      else if (Regex.IsMatch(e.LineText, "^\\s*(Else|ElseIf|Case|Catch|Finally)\\b", RegexOptions.IgnoreCase))
      {
        e.Shift = -e.TabLength;
      }
      else
      {
        if (!e.PrevLineText.TrimEnd().EndsWith("_"))
          return;
        e.Shift = e.TabLength;
      }
    }
  }

  protected void CSharpAutoIndentNeeded(object sender, AutoIndentEventArgs e)
  {
    if (Regex.IsMatch(e.LineText, "^[^\"']*\\{.*\\}[^\"']*$"))
      return;
    if (Regex.IsMatch(e.LineText, "^[^\"']*\\{"))
      e.ShiftNextLines = e.TabLength;
    else if (Regex.IsMatch(e.LineText, "}[^\"']*$"))
    {
      e.Shift = -e.TabLength;
      e.ShiftNextLines = -e.TabLength;
    }
    else if ((!Regex.IsMatch(e.LineText, "^\\s*\\w+\\s*:\\s*($|//)") ? 0 : (!Regex.IsMatch(e.LineText, "^\\s*default\\s*:") ? 1 : 0)) != 0)
      e.Shift = -e.TabLength;
    else if (Regex.IsMatch(e.LineText, "^\\s*(case|default)\\b.*:\\s*($|//)"))
    {
      e.Shift = -e.TabLength / 2;
    }
    else
    {
      if (!Regex.IsMatch(e.PrevLineText, "^\\s*(if|for|foreach|while|[\\}\\s]*else)\\b[^{]*$") || Regex.IsMatch(e.PrevLineText, "(;\\s*$)|(;\\s*//)"))
        return;
      e.Shift = e.TabLength;
    }
  }

  public virtual void AddXmlDescription(string descriptionFileName, XmlDocument doc)
  {
    SyntaxDescriptor xmlDescription = SyntaxHighlighter.ParseXmlDescription(doc);
    this.descByXMLfileNames[descriptionFileName] = xmlDescription;
  }

  public virtual void AddResilientStyle(Style style)
  {
    if (this.resilientStyles.Contains(style))
      return;
    this.currentTb.CheckStylesBufferSize();
    this.resilientStyles.Add(style);
  }

  public static SyntaxDescriptor ParseXmlDescription(XmlDocument doc)
  {
    SyntaxDescriptor xmlDescription = new SyntaxDescriptor();
    XmlNode xmlNode = doc.SelectSingleNode("doc/brackets");
    if (xmlNode != null)
    {
      if ((xmlNode.Attributes["left"] == null || xmlNode.Attributes["right"] == null || xmlNode.Attributes["left"].Value == "" ? 1 : (xmlNode.Attributes["right"].Value == "" ? 1 : 0)) != 0)
      {
        xmlDescription.leftBracket = char.MinValue;
        xmlDescription.rightBracket = char.MinValue;
      }
      else
      {
        xmlDescription.leftBracket = xmlNode.Attributes["left"].Value[0];
        xmlDescription.rightBracket = xmlNode.Attributes["right"].Value[0];
      }
      if ((xmlNode.Attributes["left2"] == null || xmlNode.Attributes["right2"] == null || xmlNode.Attributes["left2"].Value == "" ? 1 : (xmlNode.Attributes["right2"].Value == "" ? 1 : 0)) != 0)
      {
        xmlDescription.leftBracket2 = char.MinValue;
        xmlDescription.rightBracket2 = char.MinValue;
      }
      else
      {
        xmlDescription.leftBracket2 = xmlNode.Attributes["left2"].Value[0];
        xmlDescription.rightBracket2 = xmlNode.Attributes["right2"].Value[0];
      }
      int num = xmlNode.Attributes["strategy"] == null ? 1 : (xmlNode.Attributes["strategy"].Value == "" ? 1 : 0);
      xmlDescription.bracketsHighlightStrategy = num == 0 ? (BracketsHighlightStrategy) Enum.Parse(typeof (BracketsHighlightStrategy), xmlNode.Attributes["strategy"].Value) : BracketsHighlightStrategy.Strategy2;
    }
    Dictionary<string, Style> styles = new Dictionary<string, Style>();
    foreach (XmlNode selectNode in doc.SelectNodes("doc/style"))
    {
      Style style = SyntaxHighlighter.ParseStyle(selectNode);
      styles[selectNode.Attributes["name"].Value] = style;
      xmlDescription.styles.Add(style);
    }
    foreach (XmlNode selectNode in doc.SelectNodes("doc/rule"))
      xmlDescription.rules.Add(SyntaxHighlighter.ParseRule(selectNode, styles));
    foreach (XmlNode selectNode in doc.SelectNodes("doc/folding"))
      xmlDescription.foldings.Add(SyntaxHighlighter.ParseFolding(selectNode));
    return xmlDescription;
  }

  protected static FoldingDesc ParseFolding(XmlNode foldingNode)
  {
    FoldingDesc folding = new FoldingDesc();
    folding.startMarkerRegex = foldingNode.Attributes["start"].Value;
    folding.finishMarkerRegex = foldingNode.Attributes["finish"].Value;
    XmlAttribute attribute = foldingNode.Attributes["options"];
    if (attribute != null)
      folding.options = (RegexOptions) Enum.Parse(typeof (RegexOptions), attribute.Value);
    return folding;
  }

  protected static RuleDesc ParseRule(XmlNode ruleNode, Dictionary<string, Style> styles)
  {
    RuleDesc rule = new RuleDesc();
    rule.pattern = ruleNode.InnerText;
    XmlAttribute attribute1 = ruleNode.Attributes["style"];
    XmlAttribute attribute2 = ruleNode.Attributes["options"];
    if (attribute1 == null)
      throw new Exception("Rule must contain style name.");
    if (!styles.ContainsKey(attribute1.Value))
      throw new Exception($"Style '{attribute1.Value}' is not found.");
    rule.style = styles[attribute1.Value];
    if (attribute2 != null)
      rule.options = (RegexOptions) Enum.Parse(typeof (RegexOptions), attribute2.Value);
    return rule;
  }

  protected static Style ParseStyle(XmlNode styleNode)
  {
    XmlAttribute attribute1 = styleNode.Attributes["type"];
    XmlAttribute attribute2 = styleNode.Attributes["color"];
    XmlAttribute attribute3 = styleNode.Attributes["backColor"];
    XmlAttribute attribute4 = styleNode.Attributes["fontStyle"];
    XmlAttribute attribute5 = styleNode.Attributes["name"];
    SolidBrush foreBrush = (SolidBrush) null;
    if (attribute2 != null)
      foreBrush = new SolidBrush(SyntaxHighlighter.ParseColor(attribute2.Value));
    SolidBrush backgroundBrush = (SolidBrush) null;
    if (attribute3 != null)
      backgroundBrush = new SolidBrush(SyntaxHighlighter.ParseColor(attribute3.Value));
    FontStyle fontStyle = FontStyle.Regular;
    if (attribute4 != null)
      fontStyle = (FontStyle) Enum.Parse(typeof (FontStyle), attribute4.Value);
    return (Style) new TextStyle((Brush) foreBrush, (Brush) backgroundBrush, fontStyle);
  }

  protected static Color ParseColor(string s)
  {
    return !s.StartsWith("#") ? Color.FromName(s) : (s.Length > 7 ? Color.FromArgb(int.Parse(s.Substring(1), NumberStyles.AllowHexSpecifier)) : Color.FromArgb((int) byte.MaxValue, Color.FromArgb(int.Parse(s.Substring(1), NumberStyles.AllowHexSpecifier))));
  }

  public void HighlightSyntax(SyntaxDescriptor desc, Range range)
  {
    range.tb.ClearStylesBuffer();
    for (int index = 0; index < desc.styles.Count; ++index)
      range.tb.Styles[index] = desc.styles[index];
    int count = desc.styles.Count;
    for (int index = 0; index < this.resilientStyles.Count; ++index)
      range.tb.Styles[count + index] = this.resilientStyles[index];
    char[] oldBrackets = this.RememberBrackets(range.tb);
    range.tb.LeftBracket = desc.leftBracket;
    range.tb.RightBracket = desc.rightBracket;
    range.tb.LeftBracket2 = desc.leftBracket2;
    range.tb.RightBracket2 = desc.rightBracket2;
    range.ClearStyle(desc.styles.ToArray());
    foreach (RuleDesc rule in desc.rules)
      range.SetStyle(rule.style, rule.Regex);
    range.ClearFoldingMarkers();
    foreach (FoldingDesc folding in desc.foldings)
      range.SetFoldingMarkers(folding.startMarkerRegex, folding.finishMarkerRegex, folding.options);
    this.RestoreBrackets(range.tb, oldBrackets);
  }

  protected void RestoreBrackets(buMultiTextBox tb, char[] oldBrackets)
  {
    tb.LeftBracket = oldBrackets[0];
    tb.RightBracket = oldBrackets[1];
    tb.LeftBracket2 = oldBrackets[2];
    tb.RightBracket2 = oldBrackets[3];
  }

  protected char[] RememberBrackets(buMultiTextBox tb)
  {
    return new char[4]
    {
      tb.LeftBracket,
      tb.RightBracket,
      tb.LeftBracket2,
      tb.RightBracket2
    };
  }

  protected void InitCShaprRegex()
  {
    this.CSharpStringRegex = new Regex("\r\n                            # Character definitions:\r\n                            '\r\n                            (?> # disable backtracking\r\n                              (?:\r\n                                \\\\[^\\r\\n]|    # escaped meta char\r\n                                [^'\\r\\n]      # any character except '\r\n                              )*\r\n                            )\r\n                            '?\r\n                            |\r\n                            # Normal string & verbatim strings definitions:\r\n                            (?<verbatimIdentifier>@)?         # this group matches if it is an verbatim string\r\n                            \"\r\n                            (?> # disable backtracking\r\n                              (?:\r\n                                # match and consume an escaped character including escaped double quote (\") char\r\n                                (?(verbatimIdentifier)        # if it is a verbatim string ...\r\n                                  \"\"|                         #   then: only match an escaped double quote (\") char\r\n                                  \\\\.                         #   else: match an escaped sequence\r\n                                )\r\n                                | # OR\r\n            \r\n                                # match any char except double quote char (\")\r\n                                [^\"]\r\n                              )*\r\n                            )\r\n                            \"\r\n                        ", RegexOptions.ExplicitCapture | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace | SyntaxHighlighter.RegexCompiledOption);
    this.CSharpCommentRegex1 = new Regex("//.*$", RegexOptions.Multiline | SyntaxHighlighter.RegexCompiledOption);
    this.CSharpCommentRegex2 = new Regex("(/\\*.*?\\*/)|(/\\*.*)", RegexOptions.Singleline | SyntaxHighlighter.RegexCompiledOption);
    this.CSharpCommentRegex3 = new Regex("(/\\*.*?\\*/)|(.*\\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft | SyntaxHighlighter.RegexCompiledOption);
    this.CSharpNumberRegex = new Regex("\\b\\d+[\\.]?\\d*([eE]\\-?\\d+)?[lLdDfF]?\\b|\\b0x[a-fA-F\\d]+\\b", SyntaxHighlighter.RegexCompiledOption);
    this.CSharpAttributeRegex = new Regex("^\\s*(?<range>\\[.+?\\])\\s*$", RegexOptions.Multiline | SyntaxHighlighter.RegexCompiledOption);
    this.CSharpClassNameRegex = new Regex("\\b(class|struct|enum|interface)\\s+(?<range>\\w+?)\\b", SyntaxHighlighter.RegexCompiledOption);
    this.CSharpKeywordRegex = new Regex("\\b(abstract|as|base|bool|break|byte|case|catch|char|checked|class|const|continue|decimal|default|delegate|do|double|else|enum|event|explicit|extern|false|finally|fixed|float|for|foreach|goto|if|implicit|in|int|interface|internal|is|lock|long|namespace|new|null|object|operator|out|override|params|private|protected|public|readonly|ref|return|sbyte|sealed|short|sizeof|stackalloc|static|string|struct|switch|this|throw|true|try|typeof|uint|ulong|unchecked|unsafe|ushort|using|virtual|void|volatile|while|add|alias|ascending|descending|dynamic|from|get|global|group|into|join|let|orderby|partial|remove|select|set|value|var|where|yield)\\b|#region\\b|#endregion\\b", SyntaxHighlighter.RegexCompiledOption);
  }

  public void InitStyleSchema(Language lang)
  {
    switch (lang)
    {
      case Language.CSharp:
        this.StringStyle = this.BrownStyle;
        this.CommentStyle = this.GreenStyle;
        this.NumberStyle = this.MagentaStyle;
        this.AttributeStyle = this.GreenStyle;
        this.ClassNameStyle = this.BoldStyle;
        this.KeywordStyle = this.BlueStyle;
        this.CommentTagStyle = this.GrayStyle;
        break;
      case Language.VB:
        this.StringStyle = this.BrownStyle;
        this.CommentStyle = this.GreenStyle;
        this.NumberStyle = this.MagentaStyle;
        this.ClassNameStyle = this.BoldStyle;
        this.KeywordStyle = this.BlueStyle;
        break;
      case Language.HTML:
        this.CommentStyle = this.GreenStyle;
        this.TagBracketStyle = this.BlueStyle;
        this.TagNameStyle = this.MaroonStyle;
        this.AttributeStyle = this.RedStyle;
        this.AttributeValueStyle = this.BlueStyle;
        this.HtmlEntityStyle = this.RedStyle;
        break;
      case Language.XML:
        this.CommentStyle = this.GreenStyle;
        this.XmlTagBracketStyle = this.BlueStyle;
        this.XmlTagNameStyle = this.MaroonStyle;
        this.XmlAttributeStyle = this.RedStyle;
        this.XmlAttributeValueStyle = this.BlueStyle;
        this.XmlEntityStyle = this.RedStyle;
        this.XmlCDataStyle = this.BlackStyle;
        break;
      case Language.SQL:
        this.StringStyle = this.RedStyle;
        this.CommentStyle = this.GreenStyle;
        this.NumberStyle = this.MagentaStyle;
        this.KeywordStyle = this.BlueBoldStyle;
        this.StatementsStyle = this.BlueBoldStyle;
        this.FunctionsStyle = this.MaroonStyle;
        this.VariableStyle = this.MaroonStyle;
        this.TypesStyle = this.BrownStyle;
        break;
      case Language.PHP:
        this.StringStyle = this.RedStyle;
        this.CommentStyle = this.GreenStyle;
        this.NumberStyle = this.RedStyle;
        this.VariableStyle = this.MaroonStyle;
        this.KeywordStyle = this.MagentaStyle;
        this.KeywordStyle2 = this.BlueStyle;
        this.KeywordStyle3 = this.GrayStyle;
        break;
      case Language.JS:
        this.StringStyle = this.BrownStyle;
        this.CommentStyle = this.GreenStyle;
        this.NumberStyle = this.MagentaStyle;
        this.KeywordStyle = this.BlueStyle;
        break;
      case Language.Lua:
        this.StringStyle = this.BrownStyle;
        this.CommentStyle = this.GreenStyle;
        this.NumberStyle = this.MagentaStyle;
        this.KeywordStyle = this.BlueBoldStyle;
        this.FunctionsStyle = this.MaroonStyle;
        break;
    }
  }

  public virtual void CSharpSyntaxHighlight(Range range)
  {
    range.tb.CommentPrefix = "//";
    range.tb.LeftBracket = '(';
    range.tb.RightBracket = ')';
    range.tb.LeftBracket2 = '{';
    range.tb.RightBracket2 = '}';
    range.tb.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;
    range.tb.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]*(?<range>:)\\s*(?<range>[^;]+);\r\n";
    range.ClearStyle(this.StringStyle, this.CommentStyle, this.NumberStyle, this.AttributeStyle, this.ClassNameStyle, this.KeywordStyle);
    if (this.CSharpStringRegex == null)
      this.InitCShaprRegex();
    range.SetStyle(this.StringStyle, this.CSharpStringRegex);
    range.SetStyle(this.CommentStyle, this.CSharpCommentRegex1);
    range.SetStyle(this.CommentStyle, this.CSharpCommentRegex2);
    range.SetStyle(this.CommentStyle, this.CSharpCommentRegex3);
    range.SetStyle(this.NumberStyle, this.CSharpNumberRegex);
    range.SetStyle(this.AttributeStyle, this.CSharpAttributeRegex);
    range.SetStyle(this.ClassNameStyle, this.CSharpClassNameRegex);
    range.SetStyle(this.KeywordStyle, this.CSharpKeywordRegex);
    foreach (Range range1 in range.GetRanges("^\\s*///.*$", RegexOptions.Multiline))
    {
      range1.ClearStyle(StyleIndex.All);
      if (this.HTMLTagRegex == null)
        this.InitHTMLRegex();
      range1.SetStyle(this.CommentStyle);
      foreach (Range range2 in range1.GetRanges(this.HTMLTagContentRegex))
      {
        range2.ClearStyle(StyleIndex.All);
        range2.SetStyle(this.CommentTagStyle);
      }
      foreach (Range range3 in range1.GetRanges("^\\s*///", RegexOptions.Multiline))
      {
        range3.ClearStyle(StyleIndex.All);
        range3.SetStyle(this.CommentTagStyle);
      }
    }
    range.ClearFoldingMarkers();
    range.SetFoldingMarkers("{", "}");
    range.SetFoldingMarkers("#region\\b", "#endregion\\b");
    range.SetFoldingMarkers("/\\*", "\\*/");
  }

  protected void InitVBRegex()
  {
    this.VBStringRegex = new Regex("\"\"|\".*?[^\\\\]\"", SyntaxHighlighter.RegexCompiledOption);
    this.VBCommentRegex = new Regex("'.*$", RegexOptions.Multiline | SyntaxHighlighter.RegexCompiledOption);
    this.VBNumberRegex = new Regex("\\b\\d+[\\.]?\\d*([eE]\\-?\\d+)?\\b", SyntaxHighlighter.RegexCompiledOption);
    this.VBClassNameRegex = new Regex("\\b(Class|Structure|Enum|Interface)[ ]+(?<range>\\w+?)\\b", RegexOptions.IgnoreCase | SyntaxHighlighter.RegexCompiledOption);
    this.VBKeywordRegex = new Regex("\\b(AddHandler|AddressOf|Alias|And|AndAlso|As|Boolean|ByRef|Byte|ByVal|Call|Case|Catch|CBool|CByte|CChar|CDate|CDbl|CDec|Char|CInt|Class|CLng|CObj|Const|Continue|CSByte|CShort|CSng|CStr|CType|CUInt|CULng|CUShort|Date|Decimal|Declare|Default|Delegate|Dim|DirectCast|Do|Double|Each|Else|ElseIf|End|EndIf|Enum|Erase|Error|Event|Exit|False|Finally|For|Friend|Function|Get|GetType|GetXMLNamespace|Global|GoSub|GoTo|Handles|If|Implements|Imports|In|Inherits|Integer|Interface|Is|IsNot|Let|Lib|Like|Long|Loop|Me|Mod|Module|MustInherit|MustOverride|MyBase|MyClass|Namespace|Narrowing|New|Next|Not|Nothing|NotInheritable|NotOverridable|Object|Of|On|Operator|Option|Optional|Or|OrElse|Overloads|Overridable|Overrides|ParamArray|Partial|Private|Property|Protected|Public|RaiseEvent|ReadOnly|ReDim|REM|RemoveHandler|Resume|Return|SByte|Select|Set|Shadows|Shared|Short|Single|Static|Step|Stop|String|Structure|Sub|SyncLock|Then|Throw|To|True|Try|TryCast|TypeOf|UInteger|ULong|UShort|Using|Variant|Wend|When|While|Widening|With|WithEvents|WriteOnly|Xor|Region)\\b|(#Const|#Else|#ElseIf|#End|#If|#Region)\\b", RegexOptions.IgnoreCase | SyntaxHighlighter.RegexCompiledOption);
  }

  public virtual void VBSyntaxHighlight(Range range)
  {
    range.tb.CommentPrefix = "'";
    range.tb.LeftBracket = '(';
    range.tb.RightBracket = ')';
    range.tb.LeftBracket2 = char.MinValue;
    range.tb.RightBracket2 = char.MinValue;
    range.tb.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.\\(\\)]+\\s*(?<range>=)\\s*(?<range>.+)\r\n";
    range.ClearStyle(this.StringStyle, this.CommentStyle, this.NumberStyle, this.ClassNameStyle, this.KeywordStyle);
    if (this.VBStringRegex == null)
      this.InitVBRegex();
    range.SetStyle(this.StringStyle, this.VBStringRegex);
    range.SetStyle(this.CommentStyle, this.VBCommentRegex);
    range.SetStyle(this.NumberStyle, this.VBNumberRegex);
    range.SetStyle(this.ClassNameStyle, this.VBClassNameRegex);
    range.SetStyle(this.KeywordStyle, this.VBKeywordRegex);
    range.ClearFoldingMarkers();
    range.SetFoldingMarkers("#Region\\b", "#End\\s+Region\\b", RegexOptions.IgnoreCase);
    range.SetFoldingMarkers("\\b(Class|Property|Enum|Structure|Interface)[ \\t]+\\S+", "\\bEnd (Class|Property|Enum|Structure|Interface)\\b", RegexOptions.IgnoreCase);
    range.SetFoldingMarkers("^\\s*(?<range>While)[ \\t]+\\S+", "^\\s*(?<range>End While)\\b", RegexOptions.IgnoreCase | RegexOptions.Multiline);
    range.SetFoldingMarkers("\\b(Sub|Function)[ \\t]+[^\\s']+", "\\bEnd (Sub|Function)\\b", RegexOptions.IgnoreCase);
    range.SetFoldingMarkers("(\\r|\\n|^)[ \\t]*(?<range>Get|Set)[ \\t]*(\\r|\\n|$)", "\\bEnd (Get|Set)\\b", RegexOptions.IgnoreCase);
    range.SetFoldingMarkers("^\\s*(?<range>For|For\\s+Each)\\b", "^\\s*(?<range>Next)\\b", RegexOptions.IgnoreCase | RegexOptions.Multiline);
    range.SetFoldingMarkers("^\\s*(?<range>Do)\\b", "^\\s*(?<range>Loop)\\b", RegexOptions.IgnoreCase | RegexOptions.Multiline);
  }

  protected void InitHTMLRegex()
  {
    this.HTMLCommentRegex1 = new Regex("(<!--.*?-->)|(<!--.*)", RegexOptions.Singleline | SyntaxHighlighter.RegexCompiledOption);
    this.HTMLCommentRegex2 = new Regex("(<!--.*?-->)|(.*-->)", RegexOptions.Singleline | RegexOptions.RightToLeft | SyntaxHighlighter.RegexCompiledOption);
    this.HTMLTagRegex = new Regex("<|/>|</|>", SyntaxHighlighter.RegexCompiledOption);
    this.HTMLTagNameRegex = new Regex("<(?<range>[!\\w:]+)", SyntaxHighlighter.RegexCompiledOption);
    this.HTMLEndTagRegex = new Regex("</(?<range>[\\w:]+)>", SyntaxHighlighter.RegexCompiledOption);
    this.HTMLTagContentRegex = new Regex("<[^>]+>", SyntaxHighlighter.RegexCompiledOption);
    this.HTMLAttrRegex = new Regex("(?<range>[\\w\\d\\-]{1,20}?)='[^']*'|(?<range>[\\w\\d\\-]{1,20})=\"[^\"]*\"|(?<range>[\\w\\d\\-]{1,20})=[\\w\\d\\-]{1,20}", SyntaxHighlighter.RegexCompiledOption);
    this.HTMLAttrValRegex = new Regex("[\\w\\d\\-]{1,20}?=(?<range>'[^']*')|[\\w\\d\\-]{1,20}=(?<range>\"[^\"]*\")|[\\w\\d\\-]{1,20}=(?<range>[\\w\\d\\-]{1,20})", SyntaxHighlighter.RegexCompiledOption);
    this.HTMLEntityRegex = new Regex("\\&(amp|gt|lt|nbsp|quot|apos|copy|reg|#[0-9]{1,8}|#x[0-9a-f]{1,8});", SyntaxHighlighter.RegexCompiledOption | RegexOptions.IgnoreCase);
  }

  public virtual void HTMLSyntaxHighlight(Range range)
  {
    range.tb.CommentPrefix = (string) null;
    range.tb.LeftBracket = '<';
    range.tb.RightBracket = '>';
    range.tb.LeftBracket2 = '(';
    range.tb.RightBracket2 = ')';
    range.tb.AutoIndentCharsPatterns = "";
    range.ClearStyle(this.CommentStyle, this.TagBracketStyle, this.TagNameStyle, this.AttributeStyle, this.AttributeValueStyle, this.HtmlEntityStyle);
    if (this.HTMLTagRegex == null)
      this.InitHTMLRegex();
    range.SetStyle(this.CommentStyle, this.HTMLCommentRegex1);
    range.SetStyle(this.CommentStyle, this.HTMLCommentRegex2);
    range.SetStyle(this.TagBracketStyle, this.HTMLTagRegex);
    range.SetStyle(this.TagNameStyle, this.HTMLTagNameRegex);
    range.SetStyle(this.TagNameStyle, this.HTMLEndTagRegex);
    range.SetStyle(this.AttributeStyle, this.HTMLAttrRegex);
    range.SetStyle(this.AttributeValueStyle, this.HTMLAttrValRegex);
    range.SetStyle(this.HtmlEntityStyle, this.HTMLEntityRegex);
    range.ClearFoldingMarkers();
    range.SetFoldingMarkers("<head", "</head>", RegexOptions.IgnoreCase);
    range.SetFoldingMarkers("<body", "</body>", RegexOptions.IgnoreCase);
    range.SetFoldingMarkers("<table", "</table>", RegexOptions.IgnoreCase);
    range.SetFoldingMarkers("<form", "</form>", RegexOptions.IgnoreCase);
    range.SetFoldingMarkers("<div", "</div>", RegexOptions.IgnoreCase);
    range.SetFoldingMarkers("<script", "</script>", RegexOptions.IgnoreCase);
    range.SetFoldingMarkers("<tr", "</tr>", RegexOptions.IgnoreCase);
  }

  protected void InitXMLRegex()
  {
    this.XMLCommentRegex1 = new Regex("(<!--.*?-->)|(<!--.*)", RegexOptions.Singleline | SyntaxHighlighter.RegexCompiledOption);
    this.XMLCommentRegex2 = new Regex("(<!--.*?-->)|(.*-->)", RegexOptions.Singleline | RegexOptions.RightToLeft | SyntaxHighlighter.RegexCompiledOption);
    this.XMLTagRegex = new Regex("<\\?|<|/>|</|>|\\?>", SyntaxHighlighter.RegexCompiledOption);
    this.XMLTagNameRegex = new Regex("<[?](?<range1>[x][m][l]{1})|<(?<range>[!\\w:]+)", SyntaxHighlighter.RegexCompiledOption);
    this.XMLEndTagRegex = new Regex("</(?<range>[\\w:]+)>", SyntaxHighlighter.RegexCompiledOption);
    this.XMLTagContentRegex = new Regex("<[^>]+>", SyntaxHighlighter.RegexCompiledOption);
    this.XMLAttrRegex = new Regex("(?<range>[\\w\\d\\-\\:]+)[ ]*=[ ]*'[^']*'|(?<range>[\\w\\d\\-\\:]+)[ ]*=[ ]*\"[^\"]*\"|(?<range>[\\w\\d\\-\\:]+)[ ]*=[ ]*[\\w\\d\\-\\:]+", SyntaxHighlighter.RegexCompiledOption);
    this.XMLAttrValRegex = new Regex("[\\w\\d\\-]+?=(?<range>'[^']*')|[\\w\\d\\-]+[ ]*=[ ]*(?<range>\"[^\"]*\")|[\\w\\d\\-]+[ ]*=[ ]*(?<range>[\\w\\d\\-]+)", SyntaxHighlighter.RegexCompiledOption);
    this.XMLEntityRegex = new Regex("\\&(amp|gt|lt|nbsp|quot|apos|copy|reg|#[0-9]{1,8}|#x[0-9a-f]{1,8});", SyntaxHighlighter.RegexCompiledOption | RegexOptions.IgnoreCase);
    this.XMLCDataRegex = new Regex("<!\\s*\\[CDATA\\s*\\[(?<text>(?>[^]]+|](?!]>))*)]]>", SyntaxHighlighter.RegexCompiledOption | RegexOptions.IgnoreCase);
    this.XMLFoldingRegex = new Regex("<(?<range>/?\\w+)\\s[^>]*?[^/]>|<(?<range>/?\\w+)\\s*>", RegexOptions.Singleline | SyntaxHighlighter.RegexCompiledOption);
  }

  public virtual void XMLSyntaxHighlight(Range range)
  {
    range.tb.CommentPrefix = (string) null;
    range.tb.LeftBracket = '<';
    range.tb.RightBracket = '>';
    range.tb.LeftBracket2 = '(';
    range.tb.RightBracket2 = ')';
    range.tb.AutoIndentCharsPatterns = "";
    range.ClearStyle(this.CommentStyle, this.XmlTagBracketStyle, this.XmlTagNameStyle, this.XmlAttributeStyle, this.XmlAttributeValueStyle, this.XmlEntityStyle, this.XmlCDataStyle);
    if (this.XMLTagRegex == null)
      this.InitXMLRegex();
    range.SetStyle(this.XmlCDataStyle, this.XMLCDataRegex);
    range.SetStyle(this.CommentStyle, this.XMLCommentRegex1);
    range.SetStyle(this.CommentStyle, this.XMLCommentRegex2);
    range.SetStyle(this.XmlTagBracketStyle, this.XMLTagRegex);
    range.SetStyle(this.XmlTagNameStyle, this.XMLTagNameRegex);
    range.SetStyle(this.XmlTagNameStyle, this.XMLEndTagRegex);
    range.SetStyle(this.XmlAttributeStyle, this.XMLAttrRegex);
    range.SetStyle(this.XmlAttributeValueStyle, this.XMLAttrValRegex);
    range.SetStyle(this.XmlEntityStyle, this.XMLEntityRegex);
    range.ClearFoldingMarkers();
    Class39.smethod_476(this, range);
  }

  protected void InitSQLRegex()
  {
    this.SQLStringRegex = new Regex("\"\"|''|\".*?[^\\\\]\"|'.*?[^\\\\]'", SyntaxHighlighter.RegexCompiledOption);
    this.SQLNumberRegex = new Regex("\\b\\d+[\\.]?\\d*([eE]\\-?\\d+)?\\b", SyntaxHighlighter.RegexCompiledOption);
    this.SQLCommentRegex1 = new Regex("--.*$", RegexOptions.Multiline | SyntaxHighlighter.RegexCompiledOption);
    this.SQLCommentRegex2 = new Regex("(/\\*.*?\\*/)|(/\\*.*)", RegexOptions.Singleline | SyntaxHighlighter.RegexCompiledOption);
    this.SQLCommentRegex3 = new Regex("(/\\*.*?\\*/)|(.*\\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft | SyntaxHighlighter.RegexCompiledOption);
    this.SQLCommentRegex4 = new Regex("#.*$", RegexOptions.Multiline | SyntaxHighlighter.RegexCompiledOption);
    this.SQLVarRegex = new Regex("@[a-zA-Z_\\d]*\\b", SyntaxHighlighter.RegexCompiledOption);
    this.SQLStatementsRegex = new Regex("\\b(ALTER APPLICATION ROLE|ALTER ASSEMBLY|ALTER ASYMMETRIC KEY|ALTER AUTHORIZATION|ALTER BROKER PRIORITY|ALTER CERTIFICATE|ALTER CREDENTIAL|ALTER CRYPTOGRAPHIC PROVIDER|ALTER DATABASE|ALTER DATABASE AUDIT SPECIFICATION|ALTER DATABASE ENCRYPTION KEY|ALTER ENDPOINT|ALTER EVENT SESSION|ALTER FULLTEXT CATALOG|ALTER FULLTEXT INDEX|ALTER FULLTEXT STOPLIST|ALTER FUNCTION|ALTER INDEX|ALTER LOGIN|ALTER MASTER KEY|ALTER MESSAGE TYPE|ALTER PARTITION FUNCTION|ALTER PARTITION SCHEME|ALTER PROCEDURE|ALTER QUEUE|ALTER REMOTE SERVICE BINDING|ALTER RESOURCE GOVERNOR|ALTER RESOURCE POOL|ALTER ROLE|ALTER ROUTE|ALTER SCHEMA|ALTER SERVER AUDIT|ALTER SERVER AUDIT SPECIFICATION|ALTER SERVICE|ALTER SERVICE MASTER KEY|ALTER SYMMETRIC KEY|ALTER TABLE|ALTER TRIGGER|ALTER USER|ALTER VIEW|ALTER WORKLOAD GROUP|ALTER XML SCHEMA COLLECTION|BULK INSERT|CREATE AGGREGATE|CREATE APPLICATION ROLE|CREATE ASSEMBLY|CREATE ASYMMETRIC KEY|CREATE BROKER PRIORITY|CREATE CERTIFICATE|CREATE CONTRACT|CREATE CREDENTIAL|CREATE CRYPTOGRAPHIC PROVIDER|CREATE DATABASE|CREATE DATABASE AUDIT SPECIFICATION|CREATE DATABASE ENCRYPTION KEY|CREATE DEFAULT|CREATE ENDPOINT|CREATE EVENT NOTIFICATION|CREATE EVENT SESSION|CREATE FULLTEXT CATALOG|CREATE FULLTEXT INDEX|CREATE FULLTEXT STOPLIST|CREATE FUNCTION|CREATE INDEX|CREATE LOGIN|CREATE MASTER KEY|CREATE MESSAGE TYPE|CREATE PARTITION FUNCTION|CREATE PARTITION SCHEME|CREATE PROCEDURE|CREATE QUEUE|CREATE REMOTE SERVICE BINDING|CREATE RESOURCE POOL|CREATE ROLE|CREATE ROUTE|CREATE RULE|CREATE SCHEMA|CREATE SERVER AUDIT|CREATE SERVER AUDIT SPECIFICATION|CREATE SERVICE|CREATE SPATIAL INDEX|CREATE STATISTICS|CREATE SYMMETRIC KEY|CREATE SYNONYM|CREATE TABLE|CREATE TRIGGER|CREATE TYPE|CREATE USER|CREATE VIEW|CREATE WORKLOAD GROUP|CREATE XML INDEX|CREATE XML SCHEMA COLLECTION|DELETE|DISABLE TRIGGER|DROP AGGREGATE|DROP APPLICATION ROLE|DROP ASSEMBLY|DROP ASYMMETRIC KEY|DROP BROKER PRIORITY|DROP CERTIFICATE|DROP CONTRACT|DROP CREDENTIAL|DROP CRYPTOGRAPHIC PROVIDER|DROP DATABASE|DROP DATABASE AUDIT SPECIFICATION|DROP DATABASE ENCRYPTION KEY|DROP DEFAULT|DROP ENDPOINT|DROP EVENT NOTIFICATION|DROP EVENT SESSION|DROP FULLTEXT CATALOG|DROP FULLTEXT INDEX|DROP FULLTEXT STOPLIST|DROP FUNCTION|DROP INDEX|DROP LOGIN|DROP MASTER KEY|DROP MESSAGE TYPE|DROP PARTITION FUNCTION|DROP PARTITION SCHEME|DROP PROCEDURE|DROP QUEUE|DROP REMOTE SERVICE BINDING|DROP RESOURCE POOL|DROP ROLE|DROP ROUTE|DROP RULE|DROP SCHEMA|DROP SERVER AUDIT|DROP SERVER AUDIT SPECIFICATION|DROP SERVICE|DROP SIGNATURE|DROP STATISTICS|DROP SYMMETRIC KEY|DROP SYNONYM|DROP TABLE|DROP TRIGGER|DROP TYPE|DROP USER|DROP VIEW|DROP WORKLOAD GROUP|DROP XML SCHEMA COLLECTION|ENABLE TRIGGER|EXEC|EXECUTE|REPLACE|FROM|INSERT|MERGE|OPTION|OUTPUT|SELECT|TOP|TRUNCATE TABLE|UPDATE|UPDATE STATISTICS|WHERE|WITH|INTO|IN|SET)\\b", RegexOptions.IgnoreCase | SyntaxHighlighter.RegexCompiledOption);
    this.SQLKeywordsRegex = new Regex("\\b(ADD|ALL|AND|ANY|AS|ASC|AUTHORIZATION|BACKUP|BEGIN|BETWEEN|BREAK|BROWSE|BY|CASCADE|CHECK|CHECKPOINT|CLOSE|CLUSTERED|COLLATE|COLUMN|COMMIT|COMPUTE|CONSTRAINT|CONTAINS|CONTINUE|CROSS|CURRENT|CURRENT_DATE|CURRENT_TIME|CURSOR|DATABASE|DBCC|DEALLOCATE|DECLARE|DEFAULT|DENY|DESC|DISK|DISTINCT|DISTRIBUTED|DOUBLE|DUMP|ELSE|END|ERRLVL|ESCAPE|EXCEPT|EXISTS|EXIT|EXTERNAL|FETCH|FILE|FILLFACTOR|FOR|FOREIGN|FREETEXT|FULL|FUNCTION|GOTO|GRANT|GROUP|HAVING|HOLDLOCK|IDENTITY|IDENTITY_INSERT|IDENTITYCOL|IF|INDEX|INNER|INTERSECT|IS|JOIN|KEY|KILL|LIKE|LINENO|LOAD|NATIONAL|NOCHECK|NONCLUSTERED|NOT|NULL|OF|OFF|OFFSETS|ON|OPEN|OR|ORDER|OUTER|OVER|PERCENT|PIVOT|PLAN|PRECISION|PRIMARY|PRINT|PROC|PROCEDURE|PUBLIC|RAISERROR|READ|READTEXT|RECONFIGURE|REFERENCES|REPLICATION|RESTORE|RESTRICT|RETURN|REVERT|REVOKE|ROLLBACK|ROWCOUNT|ROWGUIDCOL|RULE|SAVE|SCHEMA|SECURITYAUDIT|SHUTDOWN|SOME|STATISTICS|TABLE|TABLESAMPLE|TEXTSIZE|THEN|TO|TRAN|TRANSACTION|TRIGGER|TSEQUAL|UNION|UNIQUE|UNPIVOT|UPDATETEXT|USE|USER|VALUES|VARYING|VIEW|WAITFOR|WHEN|WHILE|WRITETEXT)\\b", RegexOptions.IgnoreCase | SyntaxHighlighter.RegexCompiledOption);
    this.SQLFunctionsRegex = new Regex("(@@CONNECTIONS|@@CPU_BUSY|@@CURSOR_ROWS|@@DATEFIRST|@@DATEFIRST|@@DBTS|@@ERROR|@@FETCH_STATUS|@@IDENTITY|@@IDLE|@@IO_BUSY|@@LANGID|@@LANGUAGE|@@LOCK_TIMEOUT|@@MAX_CONNECTIONS|@@MAX_PRECISION|@@NESTLEVEL|@@OPTIONS|@@PACKET_ERRORS|@@PROCID|@@REMSERVER|@@ROWCOUNT|@@SERVERNAME|@@SERVICENAME|@@SPID|@@TEXTSIZE|@@TRANCOUNT|@@VERSION)\\b|\\b(ABS|ACOS|APP_NAME|ASCII|ASIN|ASSEMBLYPROPERTY|AsymKey_ID|ASYMKEY_ID|asymkeyproperty|ASYMKEYPROPERTY|ATAN|ATN2|AVG|CASE|CAST|CEILING|Cert_ID|Cert_ID|CertProperty|CHAR|CHARINDEX|CHECKSUM_AGG|COALESCE|COL_LENGTH|COL_NAME|COLLATIONPROPERTY|COLLATIONPROPERTY|COLUMNPROPERTY|COLUMNS_UPDATED|COLUMNS_UPDATED|CONTAINSTABLE|CONVERT|COS|COT|COUNT|COUNT_BIG|CRYPT_GEN_RANDOM|CURRENT_TIMESTAMP|CURRENT_TIMESTAMP|CURRENT_USER|CURRENT_USER|CURSOR_STATUS|DATABASE_PRINCIPAL_ID|DATABASE_PRINCIPAL_ID|DATABASEPROPERTY|DATABASEPROPERTYEX|DATALENGTH|DATALENGTH|DATEADD|DATEDIFF|DATENAME|DATEPART|DAY|DB_ID|DB_NAME|DECRYPTBYASYMKEY|DECRYPTBYCERT|DECRYPTBYKEY|DECRYPTBYKEYAUTOASYMKEY|DECRYPTBYKEYAUTOCERT|DECRYPTBYPASSPHRASE|DEGREES|DENSE_RANK|DIFFERENCE|ENCRYPTBYASYMKEY|ENCRYPTBYCERT|ENCRYPTBYKEY|ENCRYPTBYPASSPHRASE|ERROR_LINE|ERROR_MESSAGE|ERROR_NUMBER|ERROR_PROCEDURE|ERROR_SEVERITY|ERROR_STATE|EVENTDATA|EXP|FILE_ID|FILE_IDEX|FILE_NAME|FILEGROUP_ID|FILEGROUP_NAME|FILEGROUPPROPERTY|FILEPROPERTY|FLOOR|fn_helpcollations|fn_listextendedproperty|fn_servershareddrives|fn_virtualfilestats|fn_virtualfilestats|FORMATMESSAGE|FREETEXTTABLE|FULLTEXTCATALOGPROPERTY|FULLTEXTSERVICEPROPERTY|GETANSINULL|GETDATE|GETUTCDATE|GROUPING|HAS_PERMS_BY_NAME|HOST_ID|HOST_NAME|IDENT_CURRENT|IDENT_CURRENT|IDENT_INCR|IDENT_INCR|IDENT_SEED|IDENTITY\\(|INDEX_COL|INDEXKEY_PROPERTY|INDEXPROPERTY|IS_MEMBER|IS_OBJECTSIGNED|IS_SRVROLEMEMBER|ISDATE|ISDATE|ISNULL|ISNUMERIC|Key_GUID|Key_GUID|Key_ID|Key_ID|KEY_NAME|KEY_NAME|LEFT|LEN|LOG|LOG10|LOWER|LTRIM|MAX|MIN|MONTH|NCHAR|NEWID|NTILE|NULLIF|OBJECT_DEFINITION|OBJECT_ID|OBJECT_NAME|OBJECT_SCHEMA_NAME|OBJECTPROPERTY|OBJECTPROPERTYEX|OPENDATASOURCE|OPENQUERY|OPENROWSET|OPENXML|ORIGINAL_LOGIN|ORIGINAL_LOGIN|PARSENAME|PATINDEX|PATINDEX|PERMISSIONS|PI|POWER|PUBLISHINGSERVERNAME|PWDCOMPARE|PWDENCRYPT|QUOTENAME|RADIANS|RAND|RANK|REPLICATE|REVERSE|RIGHT|ROUND|ROW_NUMBER|ROWCOUNT_BIG|RTRIM|SCHEMA_ID|SCHEMA_ID|SCHEMA_NAME|SCHEMA_NAME|SCOPE_IDENTITY|SERVERPROPERTY|SESSION_USER|SESSION_USER|SESSIONPROPERTY|SETUSER|SIGN|SignByAsymKey|SignByCert|SIN|SOUNDEX|SPACE|SQL_VARIANT_PROPERTY|SQRT|SQUARE|STATS_DATE|STDEV|STDEVP|STR|STUFF|SUBSTRING|SUM|SUSER_ID|SUSER_NAME|SUSER_SID|SUSER_SNAME|SWITCHOFFSET|SYMKEYPROPERTY|symkeyproperty|sys\\.dm_db_index_physical_stats|sys\\.fn_builtin_permissions|sys\\.fn_my_permissions|SYSDATETIME|SYSDATETIMEOFFSET|SYSTEM_USER|SYSTEM_USER|SYSUTCDATETIME|TAN|TERTIARY_WEIGHTS|TEXTPTR|TODATETIMEOFFSET|TRIGGER_NESTLEVEL|TYPE_ID|TYPE_NAME|TYPEPROPERTY|UNICODE|UPDATE\\(|UPPER|USER_ID|USER_NAME|USER_NAME|VAR|VARP|VerifySignedByAsymKey|VerifySignedByCert|XACT_STATE|YEAR)\\b", RegexOptions.IgnoreCase | SyntaxHighlighter.RegexCompiledOption);
    this.SQLTypesRegex = new Regex("\\b(BIGINT|NUMERIC|BIT|SMALLINT|DECIMAL|SMALLMONEY|INT|TINYINT|MONEY|FLOAT|REAL|DATE|DATETIMEOFFSET|DATETIME2|SMALLDATETIME|DATETIME|TIME|CHAR|VARCHAR|TEXT|NCHAR|NVARCHAR|NTEXT|BINARY|VARBINARY|IMAGE|TIMESTAMP|HIERARCHYID|TABLE|UNIQUEIDENTIFIER|SQL_VARIANT|XML)\\b", RegexOptions.IgnoreCase | SyntaxHighlighter.RegexCompiledOption);
  }

  public virtual void SQLSyntaxHighlight(Range range)
  {
    range.tb.CommentPrefix = "--";
    range.tb.LeftBracket = '(';
    range.tb.RightBracket = ')';
    range.tb.LeftBracket2 = char.MinValue;
    range.tb.RightBracket2 = char.MinValue;
    range.tb.AutoIndentCharsPatterns = "";
    range.ClearStyle(this.CommentStyle, this.StringStyle, this.NumberStyle, this.VariableStyle, this.StatementsStyle, this.KeywordStyle, this.FunctionsStyle, this.TypesStyle);
    if (this.SQLStringRegex == null)
      this.InitSQLRegex();
    range.SetStyle(this.CommentStyle, this.SQLCommentRegex1);
    range.SetStyle(this.CommentStyle, this.SQLCommentRegex2);
    range.SetStyle(this.CommentStyle, this.SQLCommentRegex3);
    range.SetStyle(this.CommentStyle, this.SQLCommentRegex4);
    range.SetStyle(this.StringStyle, this.SQLStringRegex);
    range.SetStyle(this.NumberStyle, this.SQLNumberRegex);
    range.SetStyle(this.TypesStyle, this.SQLTypesRegex);
    range.SetStyle(this.VariableStyle, this.SQLVarRegex);
    range.SetStyle(this.StatementsStyle, this.SQLStatementsRegex);
    range.SetStyle(this.KeywordStyle, this.SQLKeywordsRegex);
    range.SetStyle(this.FunctionsStyle, this.SQLFunctionsRegex);
    range.ClearFoldingMarkers();
    range.SetFoldingMarkers("\\bBEGIN\\b", "\\bEND\\b", RegexOptions.IgnoreCase);
    range.SetFoldingMarkers("/\\*", "\\*/");
  }

  protected void InitPHPRegex()
  {
    this.PHPStringRegex = new Regex("\"\"|''|\".*?[^\\\\]\"|'.*?[^\\\\]'", SyntaxHighlighter.RegexCompiledOption);
    this.PHPNumberRegex = new Regex("\\b\\d+[\\.]?\\d*\\b", SyntaxHighlighter.RegexCompiledOption);
    this.PHPCommentRegex1 = new Regex("(//|#).*$", RegexOptions.Multiline | SyntaxHighlighter.RegexCompiledOption);
    this.PHPCommentRegex2 = new Regex("(/\\*.*?\\*/)|(/\\*.*)", RegexOptions.Singleline | SyntaxHighlighter.RegexCompiledOption);
    this.PHPCommentRegex3 = new Regex("(/\\*.*?\\*/)|(.*\\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft | SyntaxHighlighter.RegexCompiledOption);
    this.PHPVarRegex = new Regex("\\$[a-zA-Z_\\d]*\\b", SyntaxHighlighter.RegexCompiledOption);
    this.PHPKeywordRegex1 = new Regex("\\b(die|echo|empty|exit|eval|include|include_once|isset|list|require|require_once|return|print|unset)\\b", SyntaxHighlighter.RegexCompiledOption);
    this.PHPKeywordRegex2 = new Regex("\\b(abstract|and|array|as|break|case|catch|cfunction|class|clone|const|continue|declare|default|do|else|elseif|enddeclare|endfor|endforeach|endif|endswitch|endwhile|extends|final|for|foreach|function|global|goto|if|implements|instanceof|interface|namespace|new|or|private|protected|public|static|switch|throw|try|use|var|while|xor)\\b", SyntaxHighlighter.RegexCompiledOption);
    this.PHPKeywordRegex3 = new Regex("__CLASS__|__DIR__|__FILE__|__LINE__|__FUNCTION__|__METHOD__|__NAMESPACE__", SyntaxHighlighter.RegexCompiledOption);
  }

  public virtual void PHPSyntaxHighlight(Range range)
  {
    range.tb.CommentPrefix = "//";
    range.tb.LeftBracket = '(';
    range.tb.RightBracket = ')';
    range.tb.LeftBracket2 = '{';
    range.tb.RightBracket2 = '}';
    range.tb.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;
    range.ClearStyle(this.StringStyle, this.CommentStyle, this.NumberStyle, this.VariableStyle, this.KeywordStyle, this.KeywordStyle2, this.KeywordStyle3);
    range.tb.AutoIndentCharsPatterns = "\r\n^\\s*\\$[\\w\\.\\[\\]\\'\\\"]+\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n";
    if (this.PHPStringRegex == null)
      this.InitPHPRegex();
    range.SetStyle(this.StringStyle, this.PHPStringRegex);
    range.SetStyle(this.CommentStyle, this.PHPCommentRegex1);
    range.SetStyle(this.CommentStyle, this.PHPCommentRegex2);
    range.SetStyle(this.CommentStyle, this.PHPCommentRegex3);
    range.SetStyle(this.NumberStyle, this.PHPNumberRegex);
    range.SetStyle(this.VariableStyle, this.PHPVarRegex);
    range.SetStyle(this.KeywordStyle, this.PHPKeywordRegex1);
    range.SetStyle(this.KeywordStyle2, this.PHPKeywordRegex2);
    range.SetStyle(this.KeywordStyle3, this.PHPKeywordRegex3);
    range.ClearFoldingMarkers();
    range.SetFoldingMarkers("{", "}");
    range.SetFoldingMarkers("/\\*", "\\*/");
  }

  protected void InitJScriptRegex()
  {
    this.JScriptStringRegex = new Regex("\"\"|''|\".*?[^\\\\]\"|'.*?[^\\\\]'", SyntaxHighlighter.RegexCompiledOption);
    this.JScriptCommentRegex1 = new Regex("//.*$", RegexOptions.Multiline | SyntaxHighlighter.RegexCompiledOption);
    this.JScriptCommentRegex2 = new Regex("(/\\*.*?\\*/)|(/\\*.*)", RegexOptions.Singleline | SyntaxHighlighter.RegexCompiledOption);
    this.JScriptCommentRegex3 = new Regex("(/\\*.*?\\*/)|(.*\\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft | SyntaxHighlighter.RegexCompiledOption);
    this.JScriptNumberRegex = new Regex("\\b\\d+[\\.]?\\d*([eE]\\-?\\d+)?[lLdDfF]?\\b|\\b0x[a-fA-F\\d]+\\b", SyntaxHighlighter.RegexCompiledOption);
    this.JScriptKeywordRegex = new Regex("\\b(true|false|break|case|catch|const|continue|default|delete|do|else|export|for|function|if|in|instanceof|new|null|return|switch|this|throw|try|var|void|while|with|typeof)\\b", SyntaxHighlighter.RegexCompiledOption);
  }

  public virtual void JScriptSyntaxHighlight(Range range)
  {
    range.tb.CommentPrefix = "//";
    range.tb.LeftBracket = '(';
    range.tb.RightBracket = ')';
    range.tb.LeftBracket2 = '{';
    range.tb.RightBracket2 = '}';
    range.tb.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;
    range.tb.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n";
    range.ClearStyle(this.StringStyle, this.CommentStyle, this.NumberStyle, this.KeywordStyle);
    if (this.JScriptStringRegex == null)
      this.InitJScriptRegex();
    range.SetStyle(this.StringStyle, this.JScriptStringRegex);
    range.SetStyle(this.CommentStyle, this.JScriptCommentRegex1);
    range.SetStyle(this.CommentStyle, this.JScriptCommentRegex2);
    range.SetStyle(this.CommentStyle, this.JScriptCommentRegex3);
    range.SetStyle(this.NumberStyle, this.JScriptNumberRegex);
    range.SetStyle(this.KeywordStyle, this.JScriptKeywordRegex);
    range.ClearFoldingMarkers();
    range.SetFoldingMarkers("{", "}");
    range.SetFoldingMarkers("/\\*", "\\*/");
  }

  protected void InitLuaRegex()
  {
    this.LuaStringRegex = new Regex("\"\"|''|\".*?[^\\\\]\"|'.*?[^\\\\]'", SyntaxHighlighter.RegexCompiledOption);
    this.LuaCommentRegex1 = new Regex("--.*$", RegexOptions.Multiline | SyntaxHighlighter.RegexCompiledOption);
    this.LuaCommentRegex2 = new Regex("(--\\[\\[.*?\\]\\])|(--\\[\\[.*)", RegexOptions.Singleline | SyntaxHighlighter.RegexCompiledOption);
    this.LuaCommentRegex3 = new Regex("(--\\[\\[.*?\\]\\])|(.*\\]\\])", RegexOptions.Singleline | RegexOptions.RightToLeft | SyntaxHighlighter.RegexCompiledOption);
    this.LuaNumberRegex = new Regex("\\b\\d+[\\.]?\\d*([eE]\\-?\\d+)?[lLdDfF]?\\b|\\b0x[a-fA-F\\d]+\\b", SyntaxHighlighter.RegexCompiledOption);
    this.LuaKeywordRegex = new Regex("\\b(and|break|do|else|elseif|end|false|for|function|if|in|local|nil|not|or|repeat|return|then|true|until|while)\\b", SyntaxHighlighter.RegexCompiledOption);
    this.LuaFunctionsRegex = new Regex("\\b(assert|collectgarbage|dofile|error|getfenv|getmetatable|ipairs|load|loadfile|loadstring|module|next|pairs|pcall|print|rawequal|rawget|rawset|require|select|setfenv|setmetatable|tonumber|tostring|type|unpack|xpcall)\\b", SyntaxHighlighter.RegexCompiledOption);
  }

  public virtual void LuaSyntaxHighlight(Range range)
  {
    range.tb.CommentPrefix = "--";
    range.tb.LeftBracket = '(';
    range.tb.RightBracket = ')';
    range.tb.LeftBracket2 = '{';
    range.tb.RightBracket2 = '}';
    range.tb.BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;
    range.tb.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>.+)\r\n";
    range.ClearStyle(this.StringStyle, this.CommentStyle, this.NumberStyle, this.KeywordStyle, this.FunctionsStyle);
    if (this.LuaStringRegex == null)
      this.InitLuaRegex();
    range.SetStyle(this.StringStyle, this.LuaStringRegex);
    range.SetStyle(this.CommentStyle, this.LuaCommentRegex1);
    range.SetStyle(this.CommentStyle, this.LuaCommentRegex2);
    range.SetStyle(this.CommentStyle, this.LuaCommentRegex3);
    range.SetStyle(this.NumberStyle, this.LuaNumberRegex);
    range.SetStyle(this.KeywordStyle, this.LuaKeywordRegex);
    range.SetStyle(this.FunctionsStyle, this.LuaFunctionsRegex);
    range.ClearFoldingMarkers();
    range.SetFoldingMarkers("{", "}");
    range.SetFoldingMarkers("--\\[\\[", "\\]\\]");
  }

  protected void LuaAutoIndentNeeded(object sender, AutoIndentEventArgs e)
  {
    if (Regex.IsMatch(e.LineText, "^\\s*(end|until)\\b"))
    {
      e.Shift = -e.TabLength;
      e.ShiftNextLines = -e.TabLength;
    }
    else
    {
      if (Regex.IsMatch(e.LineText, "\\b(then)\\s*\\S+"))
        return;
      if (Regex.IsMatch(e.LineText, "^\\s*(function|do|for|while|repeat|if)\\b"))
      {
        e.ShiftNextLines = e.TabLength;
      }
      else
      {
        if (!Regex.IsMatch(e.LineText, "^\\s*(else|elseif)\\b", RegexOptions.IgnoreCase))
          return;
        e.Shift = -e.TabLength;
      }
    }
  }

  public Style StringStyle { get; set; }

  public Style CommentStyle { get; set; }

  public Style NumberStyle { get; set; }

  public Style AttributeStyle { get; set; }

  public Style ClassNameStyle { get; set; }

  public Style KeywordStyle { get; set; }

  public Style CommentTagStyle { get; set; }

  public Style AttributeValueStyle { get; set; }

  public Style TagBracketStyle { get; set; }

  public Style TagNameStyle { get; set; }

  public Style HtmlEntityStyle { get; set; }

  public Style XmlAttributeStyle { get; set; }

  public Style XmlAttributeValueStyle { get; set; }

  public Style XmlTagBracketStyle { get; set; }

  public Style XmlTagNameStyle { get; set; }

  public Style XmlEntityStyle { get; set; }

  public Style XmlCDataStyle { get; set; }

  public Style VariableStyle { get; set; }

  public Style KeywordStyle2 { get; set; }

  public Style KeywordStyle3 { get; set; }

  public Style StatementsStyle { get; set; }

  public Style FunctionsStyle { get; set; }

  public Style TypesStyle { get; set; }

  internal sealed class Class24
  {
    public string string_0;
    public int int_0;
    public int int_1;

    [SpecialName]
    public string method_0() => this.string_0 + this.int_0.ToString();
  }
}
