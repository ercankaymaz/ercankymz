using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace System.Windows.Forms;

public class RibbonCheckBox : RibbonItem
{
	public enum CheckBoxOrientationEnum
	{
		Left,
		Right
	}

	public enum CheckBoxStyle
	{
		CheckBox,
		RadioButton
	}

	private const int spacing = 3;

	private Rectangle _labelBounds;

	private Rectangle _checkboxBounds;

	private int _labelWidth;

	private int _checkboxSize;

	private CheckBoxOrientationEnum _checkBoxOrientation;

	private CheckBoxStyle _style;

	private bool checkedGlyphSize;

	[DefaultValue(CheckBoxStyle.CheckBox)]
	[Category("Appearance")]
	public CheckBoxStyle Style
	{
		get
		{
			return _style;
		}
		set
		{
			_style = value;
			NotifyOwnerRegionsChanged();
		}
	}

	[DefaultValue(CheckBoxOrientationEnum.Left)]
	[Category("Appearance")]
	public CheckBoxOrientationEnum CheckBoxOrientation
	{
		get
		{
			return _checkBoxOrientation;
		}
		set
		{
			_checkBoxOrientation = value;
			NotifyOwnerRegionsChanged();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual Rectangle LabelBounds => _labelBounds;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool LabelVisible { get; private set; } = true;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual Rectangle CheckBoxBounds => _checkboxBounds;

	[DefaultValue(0)]
	[Category("Appearance")]
	public int LabelWidth
	{
		get
		{
			return _labelWidth;
		}
		set
		{
			_labelWidth = value;
			NotifyOwnerRegionsChanged();
		}
	}

	[Description("Click on text changes the checked state.")]
	[Category("Behavior")]
	[DefaultValue(true)]
	public bool TextClickable { get; set; } = true;

	public event EventHandler CheckBoxCheckChanged;

	public event CancelEventHandler CheckBoxCheckChanging;

	public RibbonCheckBox()
	{
		_checkboxSize = 16;
	}

	protected virtual int MeasureHeight()
	{
		return _checkboxSize + base.Owner.ItemMargin.Vertical;
	}

	public override void OnPaint(object sender, RibbonElementPaintEventArgs e)
	{
		if (base.Owner == null)
		{
			return;
		}
		base.Owner.Renderer.OnRenderRibbonItem(new RibbonItemRenderEventArgs(base.Owner, e.Graphics, base.Bounds, this));
		if (Style == CheckBoxStyle.CheckBox)
		{
			CheckBoxState checkBoxState = ((!Checked) ? CheckBoxState.UncheckedNormal : CheckBoxState.CheckedNormal);
			if (Selected)
			{
				checkBoxState++;
			}
			if (CheckBoxOrientation == CheckBoxOrientationEnum.Left)
			{
				CheckBoxRenderer.DrawCheckBox(e.Graphics, new Point(_checkboxBounds.Left, _checkboxBounds.Top), checkBoxState);
			}
			else
			{
				CheckBoxRenderer.DrawCheckBox(e.Graphics, new Point(_checkboxBounds.Left + 3, _checkboxBounds.Top), checkBoxState);
			}
		}
		else
		{
			RadioButtonState radioButtonState = ((!Checked) ? RadioButtonState.UncheckedNormal : RadioButtonState.CheckedNormal);
			if (Selected)
			{
				radioButtonState++;
			}
			if (CheckBoxOrientation == CheckBoxOrientationEnum.Left)
			{
				RadioButtonRenderer.DrawRadioButton(e.Graphics, new Point(_checkboxBounds.Left, _checkboxBounds.Top), radioButtonState);
			}
			else
			{
				RadioButtonRenderer.DrawRadioButton(e.Graphics, new Point(_checkboxBounds.Left + 3, _checkboxBounds.Top), radioButtonState);
			}
		}
		if (LabelVisible)
		{
			StringFormat stringFormat = new StringFormat();
			if (_checkBoxOrientation == CheckBoxOrientationEnum.Left)
			{
				stringFormat.Alignment = StringAlignment.Near;
			}
			else
			{
				stringFormat.Alignment = StringAlignment.Far;
			}
			stringFormat.LineAlignment = StringAlignment.Far;
			stringFormat.Trimming = StringTrimming.None;
			stringFormat.FormatFlags |= StringFormatFlags.NoWrap;
			base.Owner.Renderer.OnRenderRibbonItemText(new RibbonTextEventArgs(base.Owner, e.Graphics, _labelBounds, this, LabelBounds, Text, stringFormat));
		}
	}

	public override void SetBounds(Rectangle bounds)
	{
		base.SetBounds(bounds);
		if (CheckBoxOrientation == CheckBoxOrientationEnum.Left)
		{
			_checkboxBounds = new Rectangle(bounds.Left + base.Owner.ItemMargin.Left, bounds.Top + base.Owner.ItemMargin.Top + (bounds.Height - _checkboxSize) / 2, _checkboxSize, _checkboxSize);
			int num = ((base.SizeMode == RibbonElementSizeMode.DropDown) ? base.Owner.ItemImageToTextSpacing : 0);
			_labelBounds = Rectangle.FromLTRB(_checkboxBounds.Right + num, bounds.Top + base.Owner.ItemMargin.Top, bounds.Right - base.Owner.ItemMargin.Right, bounds.Bottom - base.Owner.ItemMargin.Bottom);
		}
		else
		{
			_checkboxBounds = new Rectangle(bounds.Right - base.Owner.ItemMargin.Right - _checkboxSize, bounds.Top + base.Owner.ItemMargin.Top + (bounds.Height - _checkboxSize) / 2, _checkboxSize, _checkboxSize);
			_labelBounds = Rectangle.FromLTRB(bounds.Left + base.Owner.ItemMargin.Left, bounds.Top + base.Owner.ItemMargin.Top, _checkboxBounds.Left, bounds.Bottom - base.Owner.ItemMargin.Bottom);
		}
		if (base.SizeMode == RibbonElementSizeMode.Large)
		{
			LabelVisible = true;
		}
		else if (base.SizeMode == RibbonElementSizeMode.Medium)
		{
			LabelVisible = true;
			_labelBounds = Rectangle.Empty;
		}
		else if (base.SizeMode == RibbonElementSizeMode.Compact)
		{
			_labelBounds = Rectangle.Empty;
			LabelVisible = false;
		}
	}

	public override Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e)
	{
		if (!checkedGlyphSize)
		{
			try
			{
				if (Style == CheckBoxStyle.CheckBox)
				{
					_checkboxSize = CheckBoxRenderer.GetGlyphSize(e.Graphics, (!Checked) ? CheckBoxState.UncheckedNormal : CheckBoxState.CheckedNormal).Height + 3;
				}
				else
				{
					_checkboxSize = CheckBoxRenderer.GetGlyphSize(e.Graphics, (!Checked) ? CheckBoxState.UncheckedNormal : CheckBoxState.CheckedNormal).Height + 3;
				}
			}
			catch
			{
			}
			checkedGlyphSize = true;
		}
		if (!Visible && !base.Owner.IsDesignMode())
		{
			SetLastMeasuredSize(new Size(0, 0));
			return base.LastMeasuredSize;
		}
		_ = Size.Empty;
		int horizontal = base.Owner.ItemMargin.Horizontal;
		int num = ((Image != null) ? (Image.Width + 3) : 0);
		int num2 = ((!string.IsNullOrEmpty(Text)) ? ((_labelWidth > 0) ? _labelWidth : e.Graphics.MeasureString(Text, base.Owner.Font).ToSize().Width) : 0);
		horizontal += _checkboxSize;
		switch (e.SizeMode)
		{
		case RibbonElementSizeMode.DropDown:
			horizontal += num + num2 + base.Owner.ItemImageToTextSpacing;
			break;
		case RibbonElementSizeMode.Large:
			horizontal += num + num2;
			break;
		case RibbonElementSizeMode.Medium:
			horizontal += num;
			break;
		}
		SetLastMeasuredSize(new Size(horizontal, MeasureHeight()));
		return base.LastMeasuredSize;
	}

	public override void OnMouseEnter(MouseEventArgs e)
	{
		if (Enabled)
		{
			base.OnMouseEnter(e);
		}
	}

	public override void OnMouseLeave(MouseEventArgs e)
	{
		if (Enabled)
		{
			base.OnMouseLeave(e);
			base.Canvas.Cursor = Cursors.Default;
		}
	}

	public override void OnMouseDown(MouseEventArgs e)
	{
		if (!Enabled)
		{
			return;
		}
		base.OnMouseDown(e);
		if ((TextClickable ? base.Bounds : CheckBoxBounds).Contains(e.X, e.Y))
		{
			CancelEventArgs e2 = new CancelEventArgs();
			OnCheckChanging(e2);
			if (!e2.Cancel)
			{
				Checked = !Checked;
				OnCheckChanged(e);
			}
		}
	}

	public override void OnMouseMove(MouseEventArgs e)
	{
		if (!Enabled)
		{
			return;
		}
		base.OnMouseMove(e);
		if ((TextClickable ? base.Bounds : CheckBoxBounds).Contains(e.X, e.Y))
		{
			base.Canvas.Cursor = Cursors.Hand;
			if (!Selected)
			{
				SetSelected(selected: true);
			}
		}
		else
		{
			base.Canvas.Cursor = Cursors.Default;
			if (Selected)
			{
				SetSelected(selected: false);
			}
		}
	}

	public void OnCheckChanged(EventArgs e)
	{
		if (Enabled)
		{
			NotifyOwnerRegionsChanged();
			if (this.CheckBoxCheckChanged != null)
			{
				this.CheckBoxCheckChanged(this, e);
			}
		}
	}

	public void OnCheckChanging(CancelEventArgs e)
	{
		if (Enabled && this.CheckBoxCheckChanging != null)
		{
			this.CheckBoxCheckChanging(this, e);
		}
	}
}
