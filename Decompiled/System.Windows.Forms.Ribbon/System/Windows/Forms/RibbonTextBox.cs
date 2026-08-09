using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms;

public class RibbonTextBox : RibbonItem
{
	private const int spacing = 3;

	internal TextBox _actualTextBox;

	internal bool _removingTxt;

	internal bool _labelVisible;

	internal bool _imageVisible;

	internal Rectangle _labelBounds;

	internal Rectangle _imageBounds;

	internal int _textboxWidth;

	internal int _labelWidth;

	internal Rectangle _textBoxBounds;

	internal string _textBoxText;

	internal bool _AllowTextEdit = true;

	internal bool _disableTextboxCursor;

	private char _passwordChar;

	[Description("Allow Test Edit")]
	[Category("Behavior")]
	[DefaultValue(true)]
	public bool AllowTextEdit
	{
		get
		{
			return _AllowTextEdit;
		}
		set
		{
			_AllowTextEdit = value;
			if (base.Canvas != null)
			{
				base.Canvas.Cursor = (AllowTextEdit ? Cursors.IBeam : Cursors.Default);
			}
		}
	}

	[DefaultValue('\0')]
	[Category("Behavior")]
	[Localizable(true)]
	[RefreshProperties(RefreshProperties.Repaint)]
	public char PasswordChar
	{
		get
		{
			return _passwordChar;
		}
		set
		{
			_passwordChar = value;
			if (_actualTextBox != null)
			{
				_actualTextBox.PasswordChar = value;
			}
		}
	}

	[Category("Appearance")]
	[Description("Text on the textbox")]
	public string TextBoxText
	{
		get
		{
			return _textBoxText;
		}
		set
		{
			_textBoxText = value;
			if (_actualTextBox != null)
			{
				_actualTextBox.Text = _textBoxText;
			}
			OnTextChanged(EventArgs.Empty);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual Rectangle TextBoxTextBounds => TextBoxBounds;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Rectangle ImageBounds => _imageBounds;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual Rectangle LabelBounds => _labelBounds;

	[Category("Appearance")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ImageVisible => _imageVisible;

	[Category("Appearance")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool LabelVisible => _labelVisible;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual Rectangle TextBoxBounds => _textBoxBounds;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool Editing => _actualTextBox != null;

	[Category("Appearance")]
	[DefaultValue(100)]
	public int TextBoxWidth
	{
		get
		{
			return _textboxWidth;
		}
		set
		{
			_textboxWidth = value;
			NotifyOwnerRegionsChanged();
		}
	}

	[Category("Appearance")]
	[DefaultValue(0)]
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

	public event EventHandler TextBoxTextChanged;

	public event KeyPressEventHandler TextBoxKeyPress;

	public event KeyEventHandler TextBoxKeyDown;

	public event KeyEventHandler TextBoxKeyUp;

	public event EventHandler TextBoxValidating;

	public event EventHandler TextBoxValidated;

	public RibbonTextBox()
	{
		_textboxWidth = 100;
		_textBoxText = "";
	}

	public void StartEdit()
	{
		PlaceActualTextBox();
		_actualTextBox.SelectAll();
		_actualTextBox.Focus();
	}

	public void EndEdit()
	{
		RemoveActualTextBox();
	}

	protected void PlaceActualTextBox()
	{
		_actualTextBox = new TextBox();
		InitTextBox(_actualTextBox);
		_actualTextBox.TextChanged += _actualTextbox_TextChanged;
		_actualTextBox.KeyDown += _actualTextbox_KeyDown;
		_actualTextBox.KeyUp += _actualTextbox_KeyUp;
		_actualTextBox.KeyPress += _actualTextbox_KeyPress;
		_actualTextBox.LostFocus += _actualTextbox_LostFocus;
		_actualTextBox.VisibleChanged += _actualTextBox_VisibleChanged;
		_actualTextBox.Validating += _actualTextbox_Validating;
		_actualTextBox.Validated += _actualTextbox_Validated;
		_actualTextBox.PasswordChar = PasswordChar;
		_actualTextBox.Visible = true;
		base.Canvas.Controls.Add(_actualTextBox);
		base.Owner.ActiveTextBox = this;
	}

	public void _actualTextBox_VisibleChanged(object sender, EventArgs e)
	{
		if (!(sender as TextBox).Visible && !_removingTxt)
		{
			RemoveActualTextBox();
		}
	}

	protected void RemoveActualTextBox()
	{
		if (_actualTextBox != null && !_removingTxt)
		{
			_removingTxt = true;
			TextBoxText = _actualTextBox.Text;
			_actualTextBox.Visible = false;
			if (_actualTextBox.Parent != null)
			{
				_actualTextBox.Parent.Controls.Remove(_actualTextBox);
			}
			_actualTextBox.Dispose();
			_actualTextBox = null;
			RedrawItem();
			_removingTxt = false;
			base.Owner.ActiveTextBox = null;
		}
	}

	protected virtual void InitTextBox(TextBox t)
	{
		t.Text = TextBoxText;
		t.BorderStyle = BorderStyle.None;
		t.Width = TextBoxBounds.Width - 2;
		t.Location = new Point(TextBoxBounds.Left + 2, base.Bounds.Top + (base.Bounds.Height - t.Height) / 2);
	}

	public void _actualTextbox_LostFocus(object sender, EventArgs e)
	{
		RemoveActualTextBox();
	}

	public void _actualTextbox_KeyDown(object sender, KeyEventArgs e)
	{
		if (this.TextBoxKeyDown != null)
		{
			this.TextBoxKeyDown(this, e);
		}
		if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Return || e.KeyCode == Keys.Escape)
		{
			RemoveActualTextBox();
		}
	}

	public void _actualTextbox_KeyUp(object sender, KeyEventArgs e)
	{
		if (this.TextBoxKeyUp != null)
		{
			this.TextBoxKeyUp(this, e);
		}
		if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Return || e.KeyCode == Keys.Escape)
		{
			RemoveActualTextBox();
		}
	}

	public void _actualTextbox_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (Enabled && this.TextBoxKeyPress != null)
		{
			this.TextBoxKeyPress(this, e);
		}
	}

	public void _actualTextbox_Validating(object sender, CancelEventArgs e)
	{
		if (Enabled && this.TextBoxValidating != null)
		{
			this.TextBoxValidating(this, e);
		}
	}

	public void _actualTextbox_Validated(object sender, EventArgs e)
	{
		if (Enabled && this.TextBoxValidated != null)
		{
			this.TextBoxValidated(this, e);
		}
	}

	public void _actualTextbox_TextChanged(object sender, EventArgs e)
	{
		TextBoxText = (sender as TextBox).Text;
	}

	public virtual int MeasureHeight()
	{
		return 16 + base.Owner.ItemMargin.Vertical;
	}

	public override void OnPaint(object sender, RibbonElementPaintEventArgs e)
	{
		if (base.Owner == null)
		{
			return;
		}
		base.Owner.Renderer.OnRenderRibbonItem(new RibbonItemRenderEventArgs(base.Owner, e.Graphics, base.Bounds, this));
		if (ImageVisible)
		{
			base.Owner.Renderer.OnRenderRibbonItemImage(new RibbonItemBoundsEventArgs(base.Owner, e.Graphics, e.Clip, this, _imageBounds));
		}
		using StringFormat stringFormat = StringFormatFactory.NearCenterNoWrap(StringTrimming.None);
		base.Owner.Renderer.OnRenderRibbonItemText(new RibbonTextEventArgs(base.Owner, e.Graphics, base.Bounds, this, TextBoxTextBounds, TextBoxText, stringFormat));
		if (LabelVisible)
		{
			stringFormat.Alignment = (StringAlignment)base.TextAlignment;
			base.Owner.Renderer.OnRenderRibbonItemText(new RibbonTextEventArgs(base.Owner, e.Graphics, base.Bounds, this, LabelBounds, Text, stringFormat));
		}
	}

	public override void SetBounds(Rectangle bounds)
	{
		base.SetBounds(bounds);
		_textBoxBounds = Rectangle.FromLTRB(bounds.Right - TextBoxWidth, bounds.Top, bounds.Right, bounds.Bottom);
		if (Image != null)
		{
			_imageBounds = new Rectangle(bounds.Left + base.Owner.ItemMargin.Left, bounds.Top + base.Owner.ItemMargin.Top, Image.Width, Image.Height);
		}
		else
		{
			_imageBounds = new Rectangle(bounds.Location, Size.Empty);
		}
		_labelBounds = Rectangle.FromLTRB(_imageBounds.Right + ((_imageBounds.Width > 0) ? 3 : 0), bounds.Top, _textBoxBounds.Left - 3, bounds.Bottom - base.Owner.ItemMargin.Bottom);
		if (base.SizeMode == RibbonElementSizeMode.Large)
		{
			_imageVisible = true;
			_labelVisible = true;
		}
		else if (base.SizeMode == RibbonElementSizeMode.Medium)
		{
			_imageVisible = true;
			_labelVisible = false;
			_labelBounds = Rectangle.Empty;
		}
		else if (base.SizeMode == RibbonElementSizeMode.Compact)
		{
			_imageBounds = Rectangle.Empty;
			_imageVisible = false;
			_labelBounds = Rectangle.Empty;
			_labelVisible = false;
		}
	}

	public override Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e)
	{
		if (!Visible && !base.Owner.IsDesignMode())
		{
			SetLastMeasuredSize(new Size(0, 0));
			return base.LastMeasuredSize;
		}
		_ = Size.Empty;
		int num = 0;
		int num2 = ((Image != null) ? (Image.Width + 3) : 0);
		int num3 = ((!string.IsNullOrEmpty(Text)) ? ((_labelWidth > 0) ? _labelWidth : (e.Graphics.MeasureString(Text, base.Owner.Font).ToSize().Width + 3)) : 0);
		_ = TextBoxWidth;
		num += TextBoxWidth;
		switch (e.SizeMode)
		{
		case RibbonElementSizeMode.Large:
			num += num2 + num3;
			break;
		case RibbonElementSizeMode.Medium:
			num += num2;
			break;
		}
		SetLastMeasuredSize(new Size(num, MeasureHeight()));
		return base.LastMeasuredSize;
	}

	public override void OnMouseEnter(MouseEventArgs e)
	{
		if (Enabled)
		{
			base.OnMouseEnter(e);
			if (TextBoxBounds.Contains(e.Location))
			{
				base.Canvas.Cursor = (AllowTextEdit ? Cursors.IBeam : Cursors.Default);
			}
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
		if (Enabled)
		{
			base.OnMouseDown(e);
			if (TextBoxBounds.Contains(e.X, e.Y) && _AllowTextEdit)
			{
				StartEdit();
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
		if (!_disableTextboxCursor)
		{
			if (TextBoxBounds.Contains(e.X, e.Y) && AllowTextEdit)
			{
				base.Owner.Cursor = Cursors.IBeam;
			}
			else
			{
				base.Owner.Cursor = Cursors.Default;
			}
		}
	}

	public void OnTextChanged(EventArgs e)
	{
		if (Enabled)
		{
			NotifyOwnerRegionsChanged();
			if (this.TextBoxTextChanged != null)
			{
				this.TextBoxTextChanged(this, e);
			}
		}
	}
}
