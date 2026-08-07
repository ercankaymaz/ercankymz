// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Notepad.F_Notepad
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buCore;
using buMutliTextbox;
using ns7;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

#nullable disable
namespace buControls.Forms.WinControlForms.Notepad;

public class F_Notepad : Form
{
  public static List<string> Messages = new List<string>();
  public static List<string> Captions = new List<string>();
  public string LastSavedDirectory = Application.StartupPath;
  public bool FormTopMost = false;
  public bool ReadOnly = false;
  public bool ScreenCenter = true;
  public string TextValue = "";
  private string string_0 = "CSharp (custom highlighter)";
  internal TextStyle textStyle_0 = new TextStyle(Brushes.Blue, (Brush) null, FontStyle.Regular);
  internal TextStyle textStyle_1 = new TextStyle((Brush) null, (Brush) null, FontStyle.Bold | FontStyle.Underline);
  internal TextStyle textStyle_2 = new TextStyle(Brushes.Gray, (Brush) null, FontStyle.Regular);
  internal TextStyle textStyle_3 = new TextStyle(Brushes.Magenta, (Brush) null, FontStyle.Regular);
  internal TextStyle textStyle_4 = new TextStyle(Brushes.Green, (Brush) null, FontStyle.Italic);
  internal TextStyle textStyle_5 = new TextStyle(Brushes.Brown, (Brush) null, FontStyle.Italic);
  private TextStyle textStyle_6 = new TextStyle(Brushes.Maroon, (Brush) null, FontStyle.Regular);
  internal MarkerStyle markerStyle_0 = new MarkerStyle((Brush) new SolidBrush(Color.FromArgb(40, Color.Gray)));
  internal bool bool_0;
  internal string string_1 = "";
  private Random random_0 = new Random();
  internal IContainer icontainer_0 = (IContainer) null;
  internal MenuStrip menuStrip_0;
  internal ToolStripMenuItem toolStripMenuItem_0;
  internal ToolStripMenuItem toolStripMenuItem_1;
  internal ToolStripMenuItem toolStripMenuItem_2;
  internal ToolStripMenuItem toolStripMenuItem_3;
  internal ToolStripMenuItem toolStripMenuItem_4;
  internal ToolStripMenuItem toolStripMenuItem_5;
  internal ToolStripSeparator toolStripSeparator_0;
  internal ToolStripMenuItem toolStripMenuItem_6;
  internal ToolStripMenuItem toolStripMenuItem_7;
  internal ToolStripMenuItem toolStripMenuItem_8;
  internal ToolStripMenuItem toolStripMenuItem_9;
  internal ToolStripMenuItem toolStripMenuItem_10;
  internal ToolStripMenuItem toolStripMenuItem_11;
  internal ToolStripMenuItem toolStripMenuItem_12;
  internal ToolStripMenuItem toolStripMenuItem_13;
  internal ToolStripSeparator toolStripSeparator_1;
  internal ToolStripMenuItem toolStripMenuItem_14;
  internal ToolStripMenuItem toolStripMenuItem_15;
  internal ToolStripMenuItem toolStripMenuItem_16;
  internal ToolStripMenuItem toolStripMenuItem_17;
  internal ToolStripMenuItem toolStripMenuItem_18;
  internal ToolStripMenuItem toolStripMenuItem_19;
  internal ToolStripMenuItem toolStripMenuItem_20;
  internal ToolStripSeparator toolStripSeparator_2;
  internal ToolStripMenuItem toolStripMenuItem_21;
  internal ToolStripSeparator toolStripSeparator_3;
  internal ToolStripMenuItem toolStripMenuItem_22;
  internal ToolStripMenuItem toolStripMenuItem_23;
  internal ToolStripSeparator toolStripSeparator_4;
  internal ToolStripMenuItem toolStripMenuItem_24;
  internal ToolStripMenuItem toolStripMenuItem_25;
  internal ToolStripSeparator toolStripSeparator_5;
  internal ToolStripMenuItem toolStripMenuItem_26;
  internal ToolStripMenuItem toolStripMenuItem_27;
  internal ToolStripMenuItem toolStripMenuItem_28;
  internal ToolStripMenuItem toolStripMenuItem_29;
  internal ToolStripSeparator toolStripSeparator_6;
  internal ToolStripMenuItem toolStripMenuItem_30;
  internal ToolStripMenuItem toolStripMenuItem_31;
  internal ToolStripSeparator toolStripSeparator_7;
  internal ToolStripMenuItem toolStripMenuItem_32;
  internal ToolStripMenuItem toolStripMenuItem_33;
  internal ToolStripSeparator toolStripSeparator_8;
  internal ToolStripMenuItem toolStripMenuItem_34;
  internal ToolStripMenuItem toolStripMenuItem_35;
  internal ToolStripMenuItem toolStripMenuItem_36;
  internal ToolStripMenuItem toolStripMenuItem_37;
  internal ToolStripSeparator toolStripSeparator_9;
  internal ToolStripMenuItem toolStripMenuItem_38;
  internal ToolStripMenuItem toolStripMenuItem_39;
  internal ToolStripMenuItem toolStripMenuItem_40;
  internal ToolStripMenuItem toolStripMenuItem_41;
  internal ToolStripSeparator toolStripSeparator_10;
  internal ToolStripMenuItem toolStripMenuItem_42;
  internal ToolStripMenuItem toolStripMenuItem_43;
  internal ToolStripSeparator toolStripSeparator_11;
  internal ToolStripMenuItem toolStripMenuItem_44;
  internal ToolStripMenuItem toolStripMenuItem_45;
  internal ToolStripSeparator toolStripSeparator_12;
  internal ToolStripMenuItem toolStripMenuItem_46;
  internal ToolStripSeparator toolStripSeparator_13;
  internal ToolStripMenuItem toolStripMenuItem_47;
  internal ToolStripMenuItem toolStripMenuItem_48;
  internal ToolStripSeparator toolStripSeparator_14;
  internal ToolStripSeparator toolStripSeparator_15;
  internal ToolStripMenuItem toolStripMenuItem_49;
  internal ImageList imageList_0;
  internal ToolStrip toolStrip_0;
  internal ToolStripButton toolStripButton_0;
  internal ToolStripButton toolStripButton_1;
  internal ToolStripButton toolStripButton_2;
  internal ToolStripButton toolStripButton_3;
  internal ToolStripSeparator toolStripSeparator_16;
  internal ToolStripButton toolStripButton_4;
  internal ToolStripButton toolStripButton_5;
  internal ToolStripSeparator toolStripSeparator_17;
  internal ToolStripButton toolStripButton_6;
  internal ToolStripButton toolStripButton_7;
  internal ToolStripButton toolStripButton_8;
  internal ToolStripSeparator toolStripSeparator_18;
  internal ToolStripButton toolStripButton_9;
  public buMultiTextBox buMultiTextBox1;

  public F_Notepad() => Class39.smethod_823(this);

  internal void method_0(object sender, TextChangedEventArgs e)
  {
    this.bool_0 = true;
    if (!(this.string_0 == "CSharp (custom highlighter)"))
      return;
    Class39.smethod_437(this, e);
  }

  internal void method_1(object sender, EventArgs e) => this.buMultiTextBox1.ShowFindDialog();

  internal void method_2(object sender, EventArgs e) => this.buMultiTextBox1.ShowReplaceDialog();

  internal void method_3(object sender, EventArgs e)
  {
    foreach (ToolStripMenuItem dropDownItem in (ArrangedElementCollection) this.toolStripMenuItem_3.DropDownItems)
      dropDownItem.Checked = dropDownItem.Text == this.string_0;
  }

  internal void method_4(object sender, EventArgs e)
  {
    this.string_0 = (sender as ToolStripMenuItem).Text;
    this.buMultiTextBox1.ClearStylesBuffer();
    this.buMultiTextBox1.Range.ClearStyle(StyleIndex.All);
    Class39.smethod_364(this);
    this.buMultiTextBox1.AutoIndentNeeded -= new EventHandler<AutoIndentEventArgs>(this.method_17);
    string string0 = this.string_0;
    switch (Class39.smethod_599(string0))
    {
      case 18818719:
        if (string0 == "SQL")
        {
          this.buMultiTextBox1.Language = Language.SQL;
          break;
        }
        break;
      case 348642512:
        if (string0 == "HTML")
        {
          this.buMultiTextBox1.Language = Language.HTML;
          break;
        }
        break;
      case 1039209162:
        if (string0 == "JS")
        {
          this.buMultiTextBox1.Language = Language.JS;
          break;
        }
        break;
      case 1727679921:
        if (string0 == "VB")
        {
          this.buMultiTextBox1.Language = Language.VB;
          break;
        }
        break;
      case 2683950351:
        if (string0 == "PHP")
        {
          this.buMultiTextBox1.Language = Language.PHP;
          break;
        }
        break;
      case 3223109505:
        if (string0 == "Lua")
        {
          this.buMultiTextBox1.Language = Language.Lua;
          break;
        }
        break;
      case 3845047600:
        if (string0 == "CSharp (built-in highlighter)")
        {
          this.buMultiTextBox1.Language = Language.CSharp;
          break;
        }
        break;
      case 3877699969:
        if (string0 == "CSharp (custom highlighter)")
        {
          this.buMultiTextBox1.Language = Language.Custom;
          this.buMultiTextBox1.CommentPrefix = "//";
          this.buMultiTextBox1.AutoIndentNeeded += new EventHandler<AutoIndentEventArgs>(this.method_17);
          this.buMultiTextBox1.OnTextChanged();
          break;
        }
        break;
    }
    this.buMultiTextBox1.OnSyntaxHighlight(new TextChangedEventArgs(this.buMultiTextBox1.Range));
    this.toolStripMenuItem_12.Enabled = this.string_0 != "CSharp (custom highlighter)";
  }

  internal void method_5(object sender, EventArgs e)
  {
    this.buMultiTextBox1.CollapseBlock(this.buMultiTextBox1.Selection.Start.iLine, this.buMultiTextBox1.Selection.End.iLine);
  }

  internal void method_6(object sender, EventArgs e)
  {
    if (!this.string_0.StartsWith("CSharp"))
      return;
    for (int iLine = 0; iLine < this.buMultiTextBox1.LinesCount; ++iLine)
    {
      if (this.buMultiTextBox1[iLine].FoldingStartMarker == "#region\\b")
        this.buMultiTextBox1.CollapseFoldingBlock(iLine);
    }
  }

  internal void method_7(object sender, EventArgs e)
  {
    if (!this.string_0.StartsWith("CSharp"))
      return;
    for (int iLine = 0; iLine < this.buMultiTextBox1.LinesCount; ++iLine)
    {
      if (this.buMultiTextBox1[iLine].FoldingStartMarker == "#region\\b")
        this.buMultiTextBox1.ExpandFoldedBlock(iLine);
    }
  }

  internal void method_8(object sender, EventArgs e) => this.buMultiTextBox1.IncreaseIndent();

  internal void method_9(object sender, EventArgs e) => this.buMultiTextBox1.DecreaseIndent();

  internal void method_10(object sender, EventArgs e)
  {
    SaveFileDialog saveFileDialog = new SaveFileDialog();
    saveFileDialog.Filter = "HTML with <PRE> tag|*.html|HTML without <PRE> tag|*.html";
    if (saveFileDialog.ShowDialog() != DialogResult.OK)
      return;
    string contents = "";
    if (saveFileDialog.FilterIndex == 1)
      contents = this.buMultiTextBox1.Html;
    if (saveFileDialog.FilterIndex == 2)
      contents = new ExportToHTML()
      {
        UseBr = true,
        UseNbsp = false,
        UseForwardNbsp = true,
        UseStyleTag = true
      }.GetHtml(this.buMultiTextBox1);
    File.WriteAllText(saveFileDialog.FileName, contents);
  }

  internal void method_11(object sender, EventArgs e)
  {
    this.buMultiTextBox1.VisibleRange.ClearStyle((Style) this.markerStyle_0);
    if (!this.buMultiTextBox1.Selection.IsEmpty)
      return;
    string text = this.buMultiTextBox1.Selection.GetFragment("\\w").Text;
    if (text.Length == 0)
      return;
    buMutliTextbox.Range[] array = this.buMultiTextBox1.VisibleRange.GetRanges($"\\b{text}\\b").ToArray<buMutliTextbox.Range>();
    if (array.Length <= 1)
      return;
    foreach (buMutliTextbox.Range range in array)
      range.SetStyle((Style) this.markerStyle_0);
  }

  internal void method_12(object sender, EventArgs e) => this.buMultiTextBox1.NavigateForward();

  internal void method_13(object sender, EventArgs e) => this.buMultiTextBox1.NavigateBackward();

  internal void method_14(object sender, EventArgs e) => this.buMultiTextBox1.DoAutoIndent();

  internal void method_15(object sender, EventArgs e)
  {
    Class39.smethod_615('}', this, '{', this.buMultiTextBox1);
  }

  internal void method_16(object sender, EventArgs e)
  {
    Class39.smethod_473(this.buMultiTextBox1, '}', '{', this);
  }

  internal void method_17(object sender, AutoIndentEventArgs e)
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

  internal void method_18(object sender, EventArgs e)
  {
    this.buMultiTextBox1.Print(new PrintDialogSettings()
    {
      ShowPrintPreviewDialog = true
    });
  }

  internal void method_19(object sender, EventArgs e)
  {
    Style[] styleArray = new Style[9]
    {
      this.buMultiTextBox1.SyntaxHighlighter.BlueBoldStyle,
      this.buMultiTextBox1.SyntaxHighlighter.BlueStyle,
      this.buMultiTextBox1.SyntaxHighlighter.BoldStyle,
      this.buMultiTextBox1.SyntaxHighlighter.BrownStyle,
      this.buMultiTextBox1.SyntaxHighlighter.GrayStyle,
      this.buMultiTextBox1.SyntaxHighlighter.GreenStyle,
      this.buMultiTextBox1.SyntaxHighlighter.MagentaStyle,
      this.buMultiTextBox1.SyntaxHighlighter.MaroonStyle,
      this.buMultiTextBox1.SyntaxHighlighter.RedStyle
    };
    this.buMultiTextBox1.SyntaxHighlighter.AttributeStyle = styleArray[this.random_0.Next(styleArray.Length)];
    this.buMultiTextBox1.SyntaxHighlighter.ClassNameStyle = styleArray[this.random_0.Next(styleArray.Length)];
    this.buMultiTextBox1.SyntaxHighlighter.CommentStyle = styleArray[this.random_0.Next(styleArray.Length)];
    this.buMultiTextBox1.SyntaxHighlighter.CommentTagStyle = styleArray[this.random_0.Next(styleArray.Length)];
    this.buMultiTextBox1.SyntaxHighlighter.KeywordStyle = styleArray[this.random_0.Next(styleArray.Length)];
    this.buMultiTextBox1.SyntaxHighlighter.NumberStyle = styleArray[this.random_0.Next(styleArray.Length)];
    this.buMultiTextBox1.SyntaxHighlighter.StringStyle = styleArray[this.random_0.Next(styleArray.Length)];
    this.buMultiTextBox1.OnSyntaxHighlight(new TextChangedEventArgs(this.buMultiTextBox1.Range));
  }

  internal void method_20(object sender, EventArgs e)
  {
    this.buMultiTextBox1.Selection.ReadOnly = true;
  }

  internal void method_21(object sender, EventArgs e)
  {
    this.buMultiTextBox1.Selection.ReadOnly = false;
  }

  internal void method_22(object sender, EventArgs e)
  {
    this.buMultiTextBox1.MacrosManager.IsRecording = !this.buMultiTextBox1.MacrosManager.IsRecording;
  }

  internal void method_23(object sender, EventArgs e)
  {
    this.buMultiTextBox1.MacrosManager.ExecuteMacros();
  }

  internal void method_24(object sender, EventArgs e)
  {
    HotkeysEditorForm hotkeysEditorForm = new HotkeysEditorForm(this.buMultiTextBox1.HotkeysMapping);
    if (hotkeysEditorForm.ShowDialog() != DialogResult.OK)
      return;
    this.buMultiTextBox1.HotkeysMapping = hotkeysEditorForm.GetHotkeys();
  }

  internal void method_25(object sender, EventArgs e)
  {
    SaveFileDialog saveFileDialog = new SaveFileDialog();
    saveFileDialog.Filter = "RTF|*.rtf";
    if (saveFileDialog.ShowDialog() != DialogResult.OK)
      return;
    string rtf = this.buMultiTextBox1.Rtf;
    File.WriteAllText(saveFileDialog.FileName, rtf);
  }

  internal void method_26(object sender, CustomActionEventArgs e)
  {
    int num = (int) MessageBox.Show(e.Action.ToString());
  }

  internal void method_27(object sender, EventArgs e)
  {
    this.buMultiTextBox1.InsertLinePrefix(this.buMultiTextBox1.CommentPrefix);
  }

  internal void method_28(object sender, EventArgs e)
  {
    this.buMultiTextBox1.RemoveLinePrefix(this.buMultiTextBox1.CommentPrefix);
  }

  internal void method_29(object sender, EventArgs e)
  {
  }

  public void Init()
  {
    this.LoadLanguage();
    this.TopMost = this.FormTopMost;
    if (!this.ScreenCenter)
      return;
    this.StartPosition = FormStartPosition.CenterScreen;
  }

  public void Init(string text)
  {
    this.buMultiTextBox1.WordWrap = true;
    this.buMultiTextBox1.Language = Language.HTML;
    this.buMultiTextBox1.Text = text;
    this.LoadLanguage();
    this.TopMost = this.FormTopMost;
    if (!this.ScreenCenter)
      return;
    this.StartPosition = FormStartPosition.CenterScreen;
  }

  public void Init(List<string> text)
  {
    this.buMultiTextBox1.WordWrap = true;
    this.buMultiTextBox1.Language = Language.HTML;
    StringBuilder stringBuilder = new StringBuilder();
    foreach (object obj in text)
      stringBuilder.Append(obj);
    this.buMultiTextBox1.Text = stringBuilder.ToString();
    this.LoadLanguage();
    this.TopMost = this.FormTopMost;
    if (!this.ScreenCenter)
      return;
    this.StartPosition = FormStartPosition.CenterScreen;
  }

  public void Init(ArrayList text)
  {
    this.buMultiTextBox1.WordWrap = true;
    this.buMultiTextBox1.Language = Language.HTML;
    StringBuilder stringBuilder = new StringBuilder();
    this.buMultiTextBox1.Text = buString.ArrayListToString(text, true);
    this.LoadLanguage();
    this.TopMost = this.FormTopMost;
    if (!this.ScreenCenter)
      return;
    this.StartPosition = FormStartPosition.CenterScreen;
  }

  public void LoadLanguage()
  {
    string callMethod = "Notepad LoadLanguage";
    try
    {
      if (F_Notepad.Captions.Count < 45)
        return;
      this.Text = F_Notepad.Captions[0];
      this.toolStripMenuItem_19.Text = F_Notepad.Captions[1];
      this.toolStripMenuItem_20.Text = F_Notepad.Captions[2];
      this.toolStripButton_0.ToolTipText = F_Notepad.Captions[2];
      this.toolStripMenuItem_21.Text = F_Notepad.Captions[3];
      this.toolStripButton_1.ToolTipText = F_Notepad.Captions[3];
      this.toolStripMenuItem_22.Text = F_Notepad.Captions[4];
      this.toolStripButton_2.ToolTipText = F_Notepad.Captions[4];
      this.toolStripMenuItem_23.Text = F_Notepad.Captions[5];
      this.toolStripMenuItem_24.Text = F_Notepad.Captions[6];
      this.toolStripButton_3.ToolTipText = F_Notepad.Captions[6];
      this.toolStripMenuItem_25.Text = F_Notepad.Captions[7];
      this.toolStripMenuItem_26.Text = F_Notepad.Captions[8];
      this.toolStripMenuItem_0.Text = F_Notepad.Captions[9];
      this.toolStripMenuItem_37.Text = F_Notepad.Captions[10];
      this.toolStripButton_4.ToolTipText = F_Notepad.Captions[10];
      this.toolStripMenuItem_36.Text = F_Notepad.Captions[11];
      this.toolStripButton_5.ToolTipText = F_Notepad.Captions[11];
      this.toolStripMenuItem_27.Text = F_Notepad.Captions[12];
      this.toolStripButton_6.ToolTipText = F_Notepad.Captions[12];
      this.toolStripMenuItem_28.Text = F_Notepad.Captions[13];
      this.toolStripButton_8.ToolTipText = F_Notepad.Captions[13];
      this.toolStripMenuItem_29.Text = F_Notepad.Captions[14];
      this.toolStripButton_7.ToolTipText = F_Notepad.Captions[14];
      this.toolStripMenuItem_1.Text = F_Notepad.Captions[15];
      this.toolStripMenuItem_2.Text = F_Notepad.Captions[16 /*0x10*/];
      this.toolStripMenuItem_38.Text = F_Notepad.Captions[17];
      this.toolStripMenuItem_49.Text = F_Notepad.Captions[18];
      this.toolStripMenuItem_39.Text = F_Notepad.Captions[19];
      this.toolStripMenuItem_14.Text = F_Notepad.Captions[20];
      this.toolStripMenuItem_15.Text = F_Notepad.Captions[21];
      this.toolStripMenuItem_40.Text = F_Notepad.Captions[22];
      this.toolStripMenuItem_41.Text = F_Notepad.Captions[23];
      this.toolStripMenuItem_42.Text = F_Notepad.Captions[24];
      this.toolStripMenuItem_43.Text = F_Notepad.Captions[25];
      this.toolStripMenuItem_44.Text = F_Notepad.Captions[26];
      this.toolStripMenuItem_45.Text = F_Notepad.Captions[27];
      this.toolStripMenuItem_46.Text = F_Notepad.Captions[28];
      this.toolStripMenuItem_47.Text = F_Notepad.Captions[29];
      this.toolStripMenuItem_48.Text = F_Notepad.Captions[30];
      this.toolStripMenuItem_30.Text = F_Notepad.Captions[31 /*0x1F*/];
      this.toolStripMenuItem_31.Text = F_Notepad.Captions[32 /*0x20*/];
      this.toolStripMenuItem_32.Text = F_Notepad.Captions[33];
      this.toolStripButton_9.ToolTipText = F_Notepad.Captions[33];
      this.toolStripMenuItem_33.Text = F_Notepad.Captions[34];
      this.toolStripMenuItem_34.Text = F_Notepad.Captions[35];
      this.toolStripMenuItem_35.Text = F_Notepad.Captions[36];
      this.toolStripMenuItem_3.Text = F_Notepad.Captions[37];
      this.toolStripMenuItem_4.Text = F_Notepad.Captions[38];
      this.toolStripMenuItem_6.Text = F_Notepad.Captions[39];
      this.toolStripMenuItem_13.Text = F_Notepad.Captions[40];
      this.toolStripMenuItem_7.Text = F_Notepad.Captions[41];
      this.toolStripMenuItem_12.Text = F_Notepad.Captions[42];
      this.toolStripMenuItem_16.Text = F_Notepad.Captions[43];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void method_30(object sender, FormClosingEventArgs e)
  {
    this.TextValue = this.buMultiTextBox1.Text;
    e.Cancel = true;
    this.Visible = false;
  }

  internal void method_31(object sender, EventArgs e) => this.buMultiTextBox1.Copy();

  internal void method_32(object sender, EventArgs e) => this.buMultiTextBox1.Cut();

  internal void method_33(object sender, EventArgs e) => this.buMultiTextBox1.Paste();

  internal void method_34(object sender, EventArgs e) => this.buMultiTextBox1.SelectAll();

  internal void method_35(object sender, EventArgs e) => this.buMultiTextBox1.Undo();

  internal void method_36(object sender, EventArgs e) => this.buMultiTextBox1.Redo();

  internal void method_37(object sender, EventArgs e)
  {
    if (!this.bool_0)
    {
      this.buMultiTextBox1.Text = "";
      this.bool_0 = false;
      this.string_1 = "";
    }
    else
    {
      string Message = "Do You Want to Save File";
      if (F_Notepad.Messages.Count > 0)
        Message = F_Notepad.Messages[0];
      DialogResult dialogResult = buString.MessageBoxQuestionYesNoCancel(Message);
      if (dialogResult == DialogResult.Cancel)
        return;
      if (dialogResult == DialogResult.No)
      {
        this.buMultiTextBox1.Text = "";
        this.bool_0 = false;
        this.string_1 = "";
      }
      if (dialogResult != DialogResult.Yes)
        return;
      Class39.smethod_440(this);
      this.buMultiTextBox1.Text = "";
      this.bool_0 = false;
      this.string_1 = "";
    }
  }

  internal void method_38(object sender, EventArgs e) => this.buMultiTextBox1.ShowGoToDialog();

  internal void method_39(object sender, EventArgs e)
  {
    if (!this.bool_0)
    {
      Class39.smethod_546(this);
    }
    else
    {
      string Message = "Do You Want to Save File";
      if (F_Notepad.Messages.Count > 0)
        Message = F_Notepad.Messages[0];
      DialogResult dialogResult = buString.MessageBoxQuestionYesNoCancel(Message);
      if (dialogResult == DialogResult.Cancel)
        return;
      if (dialogResult == DialogResult.No)
        Class39.smethod_546(this);
      if (dialogResult != DialogResult.Yes)
        return;
      Class39.smethod_440(this);
      Class39.smethod_546(this);
    }
  }

  internal void method_40(object sender, EventArgs e) => Class39.smethod_440(this);

  internal void method_41(object sender, EventArgs e) => Class39.smethod_240(this);

  internal void method_42(object sender, EventArgs e)
  {
  }

  internal void method_43(object sender, EventArgs e) => this.Visible = false;

  internal void method_44(object sender, EventArgs e)
  {
    PrintDocument printDocument = new PrintDocument();
    printDocument.PrintPage += new PrintPageEventHandler(this.method_45);
    if (new PrintDialog().ShowDialog() != DialogResult.OK)
      return;
    printDocument.Print();
  }

  private void method_45(object sender, PrintPageEventArgs e)
  {
    e.Graphics.DrawString(this.buMultiTextBox1.Text, this.buMultiTextBox1.Font, Brushes.Black, 10f, 10f);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
