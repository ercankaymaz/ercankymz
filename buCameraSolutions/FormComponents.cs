// Decompiled with JetBrains decompiler
// Type: buCameraSolutions.FormComponents
// Assembly: buCameraSolutions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81083553-F2AE-41B0-A4DA-8E8442C4C023
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\Camera\Canon\buCameraSolutions.dll

using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

#nullable enable
namespace buCameraSolutions;

internal class FormComponents
{
  public void RemoveArrows(NumericUpDown nud)
  {
    foreach (Control control in (ArrangedElementCollection) nud.Controls)
    {
      if (control.GetType().Name == "UpDownButtons")
      {
        control.Visible = false;
      }
      else
      {
        control.AutoSize = false;
        control.Dock = DockStyle.Fill;
      }
    }
  }

  private void ApplyInternalFix(NumericUpDown nud)
  {
    foreach (Control control in (ArrangedElementCollection) nud.Controls)
    {
      if (control.GetType().Name == "UpDownButtons")
      {
        control.Visible = false;
      }
      else
      {
        control.Width = nud.Width;
        control.Refresh();
      }
    }
    nud.Refresh();
  }

  public class FlatNumericUpDown : NumericUpDown
  {
    protected override void OnHandleCreated(EventArgs e)
    {
      base.OnHandleCreated(e);
      this.HideArrows();
    }

    private void HideArrows()
    {
      foreach (Control control in (ArrangedElementCollection) this.Controls)
      {
        if (control.GetType().Name == "UpDownButtons")
          control.Visible = false;
        else
          control.Width = this.Width;
      }
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
      this.HideArrows();
    }
  }

  public class NumericTextBox : TextBox
  {
    private Decimal _value = 0M;
    private Decimal _minimum = 0M;
    private Decimal _maximum = 100M;

    [field: DebuggerBrowsable]
    public event EventHandler ValueChanged;

    public Decimal Minimum
    {
      get => this._minimum;
      set => this._minimum = value;
    }

    public Decimal Maximum
    {
      get => this._maximum;
      set => this._maximum = value;
    }

    public Decimal Value
    {
      get => this._value;
      set
      {
        Decimal num = value;
        if (num < this._minimum)
          num = this._minimum;
        if (num > this._maximum)
          num = this._maximum;
        if (!(this._value != num))
          return;
        this._value = num;
        this.Text = this._value.ToString();
        EventHandler valueChanged = this.ValueChanged;
        if (valueChanged != null)
          valueChanged((object) this, EventArgs.Empty);
      }
    }

    public NumericTextBox()
    {
      this.BorderStyle = BorderStyle.None;
      this.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
      this.ForeColor = Color.White;
      this.Text = "0";
    }

    protected override void OnTextChanged(EventArgs e)
    {
      base.OnTextChanged(e);
      Decimal result;
      if (this.Text == "-" || string.IsNullOrWhiteSpace(this.Text) || !Decimal.TryParse(this.Text, out result) || !(result >= this._minimum) || !(result <= this._maximum))
        return;
      this._value = result;
      EventHandler valueChanged = this.ValueChanged;
      if (valueChanged != null)
        valueChanged((object) this, EventArgs.Empty);
    }

    protected override void OnKeyPress(KeyPressEventArgs e)
    {
      base.OnKeyPress(e);
      if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '-')
        return;
      e.Handled = true;
    }

    protected override void OnLostFocus(EventArgs e)
    {
      base.OnLostFocus(e);
      Decimal result;
      if (Decimal.TryParse(this.Text, out result))
        this.Value = result;
      else
        this.Text = this._value.ToString();
    }
  }
}
