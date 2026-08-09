using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DevAge.ComponentModel.Validator;
using ns27;

namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
public class DevAgeRichTextBox : RichTextBox
{
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

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
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

	protected const int CFM_BOLD = 1;

	protected const int CFM_ITALIC = 2;

	protected const int CFM_UNDERLINE = 4;

	protected const uint CFM_FACE = 536870912u;

	protected const uint CFM_SIZE = 2147483648u;

	protected const uint CFM_SUPERSCRIPT = 196608u;

	protected const uint CFE_SUPERSCRIPT = 131072u;

	protected const uint CFM_SUBSCRIPT = 196608u;

	protected const uint CFE_SUBSCRIPT = 65536u;

	protected const int CFM_UNDERLINETYPE = 8388608;

	protected const int EM_SETCHARFORMAT = 1092;

	protected const int EM_GETCHARFORMAT = 1082;

	protected const int SCF_SELECTION = 1;

	protected const int EM_FORMATRANGE = 1081;

	protected const int WM_USER = 1024;

	protected const int EM_SETEVENTMASK = 1073;

	protected const int EM_GETPARAFORMAT = 1085;

	protected const int EM_SETPARAFORMAT = 1095;

	protected const int EM_SETTYPOGRAPHYOPTIONS = 1226;

	protected const int WM_SETREDRAW = 11;

	protected const int TO_ADVANCEDTYPOGRAPHY = 1;

	private IValidator ivalidator_0 = null;

	private int int_0 = 0;

	private int int_1 = 0;

	public UnderlineStyle SelectionUnderlineStyle
	{
		get
		{
			CHARFORMAT charformat_ = default(CHARFORMAT);
			charformat_.cbSize = Marshal.SizeOf(charformat_);
			Class76.SendMessage_1(new HandleRef(this, base.Handle), 1082, 1, ref charformat_);
			if ((charformat_.dwMask & 0x800000) != 0)
			{
				return (UnderlineStyle)(byte)(charformat_.bUnderlineType & 0xF);
			}
			return UnderlineStyle.None;
		}
		set
		{
			UnderlineColor underlineColor = SelectionUnderlineColor;
			if (value == UnderlineStyle.None)
			{
				underlineColor = UnderlineColor.Black;
			}
			CHARFORMAT charformat_ = default(CHARFORMAT);
			charformat_.cbSize = Marshal.SizeOf(charformat_);
			charformat_.dwMask = 8388608u;
			charformat_.bUnderlineType = (byte)((byte)value | (byte)underlineColor);
			Class76.SendMessage_1(new HandleRef(this, base.Handle), 1092, 1, ref charformat_);
		}
	}

	public UnderlineColor SelectionUnderlineColor
	{
		get
		{
			CHARFORMAT charformat_ = default(CHARFORMAT);
			charformat_.cbSize = Marshal.SizeOf(charformat_);
			Class76.SendMessage_1(new HandleRef(this, base.Handle), 1082, 1, ref charformat_);
			if ((charformat_.dwMask & 0x800000) != 0)
			{
				return (UnderlineColor)(byte)(charformat_.bUnderlineType & 0xF0);
			}
			return UnderlineColor.Black;
		}
		set
		{
			UnderlineStyle selectionUnderlineStyle = SelectionUnderlineStyle;
			if (selectionUnderlineStyle == UnderlineStyle.None)
			{
				value = UnderlineColor.Black;
			}
			CHARFORMAT charformat_ = default(CHARFORMAT);
			charformat_.cbSize = Marshal.SizeOf(charformat_);
			charformat_.dwMask = 8388608u;
			charformat_.bUnderlineType = (byte)((byte)selectionUnderlineStyle | (byte)value);
			Class76.SendMessage_1(new HandleRef(this, base.Handle), 1092, 1, ref charformat_);
		}
	}

	public EffectType SelectionEffect
	{
		set
		{
			switch (value)
			{
			case EffectType.Subscript:
				Class76.smethod_835(this);
				break;
			case EffectType.Superscript:
				Class76.smethod_104(this);
				break;
			default:
				Class76.smethod_727(this);
				break;
			}
		}
	}

	[DefaultValue(null)]
	public IValidator Validator
	{
		get
		{
			return ivalidator_0;
		}
		set
		{
			if (ivalidator_0 != value)
			{
				if (ivalidator_0 != null)
				{
					ivalidator_0.Changed -= ivalidator_0_Changed;
				}
				ivalidator_0 = value;
				ivalidator_0.Changed += ivalidator_0_Changed;
				ApplyValidatorRules();
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RichText Value
	{
		get
		{
			if (!IsValidValue(out var convertedValue))
			{
				throw new ArgumentOutOfRangeException("Text");
			}
			return convertedValue;
		}
		set
		{
			if (Validator == null)
			{
				if (value != null)
				{
					Text = value.ToString();
				}
				else
				{
					Text = string.Empty;
				}
				return;
			}
			RichText richText = (RichText)Validator.ValueToObject(value, typeof(RichText));
			if (richText != null)
			{
				base.Rtf = richText.Rtf;
			}
			else
			{
				Text = string.Empty;
			}
		}
	}

	public bool InternalUpdating => int_0 != 0;

	protected internal void SetCharFormatMessage(ref CHARFORMAT fmt)
	{
		Class76.SendMessage_1(new HandleRef(this, base.Handle), 1092, 1, ref fmt);
	}

	protected override void OnValidating(CancelEventArgs e)
	{
		base.OnValidating(e);
		if (!IsValidValue(out var _))
		{
			e.Cancel = true;
		}
	}

	private void ivalidator_0_Changed(object sender, EventArgs e)
	{
		ApplyValidatorRules();
	}

	protected virtual void ApplyValidatorRules()
	{
	}

	public bool IsValidValue(out RichText convertedValue)
	{
		if (Validator == null)
		{
			convertedValue = new RichText(base.Rtf);
			return true;
		}
		object p_ValueConverted = null;
		bool result = false;
		if (Validator.IsValidObject(new RichText(base.Rtf), out p_ValueConverted))
		{
			result = true;
		}
		convertedValue = p_ValueConverted as RichText;
		return result;
	}

	public void BeginUpdate()
	{
		int_0++;
		if (int_0 <= 1)
		{
			int_1 = Class76.SendMessage_5(new HandleRef(this, base.Handle), 1073, 0, 0);
			Class76.SendMessage_5(new HandleRef(this, base.Handle), 11, 0, 0);
		}
	}

	public void EndUpdate()
	{
		int_0--;
		if (int_0 <= 0)
		{
			Class76.SendMessage_5(new HandleRef(this, base.Handle), 11, 1, 0);
			Class76.SendMessage_5(new HandleRef(this, base.Handle), 1073, 0, int_1);
			Refresh();
		}
	}

	public void AppendText(string text, FontStyle fontStyle)
	{
		int length = Text.Length;
		AppendText(text);
		Select(length, text.Length);
		base.SelectionFont = new Font(Font, fontStyle);
	}

	public void RemoveFormats(bool withWhitespaces)
	{
		string rtf = base.Rtf;
		Text = string.Empty;
		if (!withWhitespaces)
		{
			Text = RichTextConversion.RichTextToString(new RichText(rtf));
		}
		else
		{
			Text = RichTextConversion.RichTextToStringStripWhitespaces(new RichText(rtf));
		}
	}

	public SizeF MeasureTextBoxContent(Font font)
	{
		Graphics graphics = CreateGraphics();
		int charactersFitted;
		int linesFilled;
		return graphics.MeasureString(Text, font, new SizeF(base.Width, 400f), new StringFormat(), out charactersFitted, out linesFilled);
	}
}
