// Decompiled with JetBrains decompiler
// Type: DevAge.Windows.Forms.DevAgeRichTextBox
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.ComponentModel.Validator;
using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
public class DevAgeRichTextBox : RichTextBox
{
  protected const int CFM_BOLD = 1;
  protected const int CFM_ITALIC = 2;
  protected const int CFM_UNDERLINE = 4;
  protected const uint CFM_FACE = 536870912 /*0x20000000*/;
  protected const uint CFM_SIZE = 2147483648 /*0x80000000*/;
  protected const uint CFM_SUPERSCRIPT = 196608 /*0x030000*/;
  protected const uint CFE_SUPERSCRIPT = 131072 /*0x020000*/;
  protected const uint CFM_SUBSCRIPT = 196608 /*0x030000*/;
  protected const uint CFE_SUBSCRIPT = 65536 /*0x010000*/;
  protected const int CFM_UNDERLINETYPE = 8388608 /*0x800000*/;
  protected const int EM_SETCHARFORMAT = 1092;
  protected const int EM_GETCHARFORMAT = 1082;
  protected const int SCF_SELECTION = 1;
  protected const int EM_FORMATRANGE = 1081;
  protected const int WM_USER = 1024 /*0x0400*/;
  protected const int EM_SETEVENTMASK = 1073;
  protected const int EM_GETPARAFORMAT = 1085;
  protected const int EM_SETPARAFORMAT = 1095;
  protected const int EM_SETTYPOGRAPHYOPTIONS = 1226;
  protected const int WM_SETREDRAW = 11;
  protected const int TO_ADVANCEDTYPOGRAPHY = 1;
  private IValidator ivalidator_0 = (IValidator) null;
  private int int_0 = 0;
  private int int_1 = 0;

  protected internal void SetCharFormatMessage(ref DevAgeRichTextBox.CHARFORMAT fmt)
  {
    Class39.SendMessage_1(new HandleRef((object) this, this.Handle), 1092, 1, ref fmt);
  }

  public UnderlineStyle SelectionUnderlineStyle
  {
    get
    {
      DevAgeRichTextBox.CHARFORMAT charformat_0 = new DevAgeRichTextBox.CHARFORMAT();
      charformat_0.cbSize = Marshal.SizeOf<DevAgeRichTextBox.CHARFORMAT>(charformat_0);
      Class39.SendMessage_1(new HandleRef((object) this, this.Handle), 1082, 1, ref charformat_0);
      return ((int) charformat_0.dwMask & 8388608 /*0x800000*/) != 0 ? (UnderlineStyle) (byte) ((uint) charformat_0.bUnderlineType & 15U) : UnderlineStyle.None;
    }
    set
    {
      UnderlineColor underlineColor = this.SelectionUnderlineColor;
      if (value == UnderlineStyle.None)
        underlineColor = UnderlineColor.Black;
      DevAgeRichTextBox.CHARFORMAT charformat_0 = new DevAgeRichTextBox.CHARFORMAT();
      charformat_0.cbSize = Marshal.SizeOf<DevAgeRichTextBox.CHARFORMAT>(charformat_0);
      charformat_0.dwMask = 8388608U /*0x800000*/;
      charformat_0.bUnderlineType = (byte) ((uint) (byte) value | (uint) (byte) underlineColor);
      Class39.SendMessage_1(new HandleRef((object) this, this.Handle), 1092, 1, ref charformat_0);
    }
  }

  public UnderlineColor SelectionUnderlineColor
  {
    get
    {
      DevAgeRichTextBox.CHARFORMAT charformat_0 = new DevAgeRichTextBox.CHARFORMAT();
      charformat_0.cbSize = Marshal.SizeOf<DevAgeRichTextBox.CHARFORMAT>(charformat_0);
      Class39.SendMessage_1(new HandleRef((object) this, this.Handle), 1082, 1, ref charformat_0);
      return ((int) charformat_0.dwMask & 8388608 /*0x800000*/) != 0 ? (UnderlineColor) (byte) ((uint) charformat_0.bUnderlineType & 240U /*0xF0*/) : UnderlineColor.Black;
    }
    set
    {
      UnderlineStyle selectionUnderlineStyle = this.SelectionUnderlineStyle;
      if (selectionUnderlineStyle == UnderlineStyle.None)
        value = UnderlineColor.Black;
      DevAgeRichTextBox.CHARFORMAT charformat_0 = new DevAgeRichTextBox.CHARFORMAT();
      charformat_0.cbSize = Marshal.SizeOf<DevAgeRichTextBox.CHARFORMAT>(charformat_0);
      charformat_0.dwMask = 8388608U /*0x800000*/;
      charformat_0.bUnderlineType = (byte) ((uint) (byte) selectionUnderlineStyle | (uint) (byte) value);
      Class39.SendMessage_1(new HandleRef((object) this, this.Handle), 1092, 1, ref charformat_0);
    }
  }

  public EffectType SelectionEffect
  {
    set
    {
      switch (value)
      {
        case EffectType.Subscript:
          Class39.smethod_835(this);
          break;
        case EffectType.Superscript:
          Class39.smethod_104(this);
          break;
        default:
          Class39.smethod_727(this);
          break;
      }
    }
  }

  protected override void OnValidating(CancelEventArgs e)
  {
    base.OnValidating(e);
    if (this.IsValidValue(out RichText _))
      return;
    e.Cancel = true;
  }

  [DefaultValue(null)]
  public IValidator Validator
  {
    get => this.ivalidator_0;
    set
    {
      if (this.ivalidator_0 == value)
        return;
      if (this.ivalidator_0 != null)
        this.ivalidator_0.Changed -= new EventHandler(this.ivalidator_0_Changed);
      this.ivalidator_0 = value;
      this.ivalidator_0.Changed += new EventHandler(this.ivalidator_0_Changed);
      this.ApplyValidatorRules();
    }
  }

  private void ivalidator_0_Changed(object sender, EventArgs e) => this.ApplyValidatorRules();

  protected virtual void ApplyValidatorRules()
  {
  }

  public bool IsValidValue(out RichText convertedValue)
  {
    bool flag1;
    if (this.Validator != null)
    {
      object p_ValueConverted = (object) null;
      bool flag2 = false;
      if (this.Validator.IsValidObject((object) new RichText(this.Rtf), out p_ValueConverted))
        flag2 = true;
      convertedValue = p_ValueConverted as RichText;
      flag1 = flag2;
    }
    else
    {
      convertedValue = new RichText(this.Rtf);
      flag1 = true;
    }
    return flag1;
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public RichText Value
  {
    get
    {
      RichText convertedValue;
      if (!this.IsValidValue(out convertedValue))
        throw new ArgumentOutOfRangeException("Text");
      return convertedValue;
    }
    set
    {
      if (this.Validator != null)
      {
        RichText richText = (RichText) this.Validator.ValueToObject((object) value, typeof (RichText));
        if (richText == null)
          this.Text = string.Empty;
        else
          this.Rtf = richText.Rtf;
      }
      else if (value == null)
        this.Text = string.Empty;
      else
        this.Text = value.ToString();
    }
  }

  public void BeginUpdate()
  {
    ++this.int_0;
    if (this.int_0 > 1)
      return;
    this.int_1 = Class39.SendMessage_5(new HandleRef((object) this, this.Handle), 1073, 0, 0);
    Class39.SendMessage_5(new HandleRef((object) this, this.Handle), 11, 0, 0);
  }

  public void EndUpdate()
  {
    --this.int_0;
    if (this.int_0 > 0)
      return;
    Class39.SendMessage_5(new HandleRef((object) this, this.Handle), 11, 1, 0);
    Class39.SendMessage_5(new HandleRef((object) this, this.Handle), 1073, 0, this.int_1);
    this.Refresh();
  }

  public bool InternalUpdating => this.int_0 != 0;

  public void AppendText(string text, FontStyle fontStyle)
  {
    int length = this.Text.Length;
    this.AppendText(text);
    this.Select(length, text.Length);
    this.SelectionFont = new Font(this.Font, fontStyle);
  }

  public void RemoveFormats(bool withWhitespaces)
  {
    string rtf = this.Rtf;
    this.Text = string.Empty;
    if (withWhitespaces)
      this.Text = RichTextConversion.RichTextToStringStripWhitespaces(new RichText(rtf));
    else
      this.Text = RichTextConversion.RichTextToString(new RichText(rtf));
  }

  public SizeF MeasureTextBoxContent(Font font)
  {
    return this.CreateGraphics().MeasureString(this.Text, font, new SizeF((float) this.Width, 400f), new StringFormat(), out int _, out int _);
  }

  protected internal struct CHARFORMAT
  {
    public int cbSize;
    public uint dwMask;
    public uint dwEffects;
    public int yHeight;
    public int yOffset;
    public int crTextColor;
    public byte bCharSet;
    public byte bPitchAndFamily;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32 /*0x20*/)]
    public char[] szFaceName;
    public short wWeight;
    public short sSpacing;
    public int crBackColor;
    public int LCID;
    public uint dwReserved;
    public short sStyle;
    public short wKerning;
    public byte bUnderlineType;
    public byte bAnimation;
    public byte bRevAuthor;
  }
}
