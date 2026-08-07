// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.FindForm
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

#nullable disable
namespace buMutliTextbox;

public class FindForm : Form
{
  internal bool bool_0 = true;
  private Place place_0;
  private buMultiTextBox tb;
  private IContainer icontainer_0 = (IContainer) null;
  internal Button button_0;
  internal Button button_1;
  internal CheckBox checkBox_0;
  internal CheckBox checkBox_1;
  internal Label label_0;
  internal CheckBox checkBox_2;
  public TextBox tbFind;

  public FindForm(buMultiTextBox tb)
  {
    Class39.smethod_541(this);
    this.tb = tb;
  }

  internal void method_0(object sender, EventArgs e) => this.Close();

  internal void method_1(object sender, EventArgs e) => this.FindNext(this.tbFind.Text);

  public virtual void FindNext(string pattern)
  {
    try
    {
      RegexOptions options = this.checkBox_1.Checked ? RegexOptions.None : RegexOptions.IgnoreCase;
      if (!this.checkBox_0.Checked)
        pattern = Regex.Escape(pattern);
      if (this.checkBox_2.Checked)
        pattern = $"\\b{pattern}\\b";
      Range range = this.tb.Selection.Clone();
      range.Normalize();
      if (this.bool_0)
      {
        this.place_0 = range.Start;
        this.bool_0 = false;
      }
      range.Start = range.End;
      range.End = !(range.Start >= this.place_0) ? this.place_0 : new Place(this.tb.GetLineLength(this.tb.LinesCount - 1), this.tb.LinesCount - 1);
      using (IEnumerator<Range> enumerator = range.GetRangesByLines(pattern, options).GetEnumerator())
      {
        if (enumerator.MoveNext())
        {
          this.tb.Selection = enumerator.Current;
          this.tb.DoSelectionVisible();
          this.tb.Invalidate();
          return;
        }
      }
      if ((!(range.Start >= this.place_0) ? 0 : (this.place_0 > Place.Empty ? 1 : 0)) != 0)
      {
        this.tb.Selection.Start = new Place(0, 0);
        this.FindNext(pattern);
      }
      else
      {
        int num = (int) MessageBox.Show("Not found");
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message);
    }
  }

  internal void method_2(object sender, KeyPressEventArgs e)
  {
    if (e.KeyChar == '\r')
    {
      this.button_1.PerformClick();
      e.Handled = true;
    }
    else
    {
      if (e.KeyChar != '\u001B')
        return;
      this.Hide();
      e.Handled = true;
    }
  }

  internal void method_3(object sender, FormClosingEventArgs e)
  {
    if (e.CloseReason == CloseReason.UserClosing)
    {
      e.Cancel = true;
      this.Hide();
    }
    this.tb.Focus();
  }

  protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
  {
    bool flag;
    if (keyData == Keys.Escape)
    {
      this.Close();
      flag = true;
    }
    else
      flag = base.ProcessCmdKey(ref msg, keyData);
    return flag;
  }

  protected override void OnActivated(EventArgs e)
  {
    this.tbFind.Focus();
    this.bool_0 = true;
  }

  internal void method_4(object sender, EventArgs e) => this.bool_0 = true;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
