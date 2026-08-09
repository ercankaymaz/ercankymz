using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonDropButton), "ToolboxBitmaps.KryptonDropButton.bmp")]
[DefaultEvent("Click")]
[DefaultProperty("Text")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonDropButtonDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[Description("Raises an event when the user clicks it.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonDropButton : VisualSimpleBase, IButtonControl, IContentValues
{
	private ViewDrawButton _drawButton;

	private ButtonStyle _style;

	private ButtonValues _buttonValues;

	private ButtonController _buttonController;

	private PaletteRedirectDropDownButton _paletteDropDownButtonImages;

	private PaletteTripleRedirect _stateCommon;

	private PaletteTriple _stateDisabled;

	private PaletteTriple _stateNormal;

	private PaletteTriple _stateTracking;

	private PaletteTriple _statePressed;

	private PaletteTripleRedirect _stateDefault;

	private PaletteTripleRedirect _stateFocus;

	private PaletteTripleOverride _overrideFocus;

	private PaletteTripleOverride _overrideNormal;

	private PaletteTripleOverride _overrideTracking;

	private PaletteTripleOverride _overridePressed;

	private DropDownButtonImages _images;

	private DialogResult _dialogResult;

	private KryptonCommand _command;

	private bool _isDefault;

	private bool _useMnemonic;

	private bool _wasEnabled;

	[Browsable(true)]
	[Localizable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[RefreshProperties(RefreshProperties.All)]
	public override bool AutoSize
	{
		get
		{
			return base.AutoSize;
		}
		set
		{
			base.AutoSize = value;
		}
	}

	[Browsable(false)]
	[Localizable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new Padding Padding
	{
		get
		{
			return base.Padding;
		}
		set
		{
			base.Padding = value;
		}
	}

	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	public override string Text
	{
		get
		{
			return _buttonValues.Text;
		}
		set
		{
			_buttonValues.Text = value;
		}
	}

	[Category("Visuals")]
	[Description("Visual orientation of the control.")]
	[DefaultValue(typeof(VisualOrientation), "Top")]
	public VisualOrientation ButtonOrientation
	{
		get
		{
			return _drawButton.Orientation;
		}
		set
		{
			if (_drawButton.Orientation != value)
			{
				_drawButton.Orientation = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Position of the drop arrow within the button.")]
	[DefaultValue(typeof(VisualOrientation), "Right")]
	public VisualOrientation DropDownPosition
	{
		get
		{
			return _drawButton.DropDownPosition;
		}
		set
		{
			if (_drawButton.DropDownPosition != value)
			{
				_drawButton.DropDownPosition = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Orientation of the drop arrow within the button.")]
	[DefaultValue(typeof(VisualOrientation), "Bottom")]
	public VisualOrientation DropDownOrientation
	{
		get
		{
			return _drawButton.DropDownOrientation switch
			{
				VisualOrientation.Bottom => VisualOrientation.Top, 
				VisualOrientation.Left => VisualOrientation.Right, 
				VisualOrientation.Right => VisualOrientation.Left, 
				_ => VisualOrientation.Bottom, 
			};
		}
		set
		{
			VisualOrientation visualOrientation = value;
			visualOrientation = value switch
			{
				VisualOrientation.Top => VisualOrientation.Bottom, 
				VisualOrientation.Right => VisualOrientation.Left, 
				VisualOrientation.Left => VisualOrientation.Right, 
				_ => VisualOrientation.Top, 
			};
			if (_drawButton.DropDownOrientation != visualOrientation)
			{
				_drawButton.DropDownOrientation = visualOrientation;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Determine if button acts as a splitter or just a drop down.")]
	[DefaultValue(true)]
	public bool Splitter
	{
		get
		{
			return _drawButton.Splitter;
		}
		set
		{
			if (_drawButton.Splitter != value)
			{
				_drawButton.Splitter = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Button style.")]
	public ButtonStyle ButtonStyle
	{
		get
		{
			return _style;
		}
		set
		{
			if (_style != value)
			{
				_style = value;
				SetStyles(_style);
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Button values")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public ButtonValues Values => _buttonValues;

	[Category("Visuals")]
	[Description("Image value overrides.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public DropDownButtonImages Images => _images;

	[Category("Visuals")]
	[Description("Overrides for defining common button appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleRedirect StateCommon => _stateCommon;

	[Category("Visuals")]
	[Description("Overrides for defining disabled button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateDisabled => _stateDisabled;

	[Category("Visuals")]
	[Description("Overrides for defining normal button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateNormal => _stateNormal;

	[Category("Visuals")]
	[Description("Overrides for defining hot tracking button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateTracking => _stateTracking;

	[Category("Visuals")]
	[Description("Overrides for defining pressed button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StatePressed => _statePressed;

	[Category("Visuals")]
	[Description("Overrides for defining normal button appearance when default.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleRedirect OverrideDefault => _stateDefault;

	[Category("Visuals")]
	[Description("Overrides for defining button appearance when it has focus.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleRedirect OverrideFocus => _stateFocus;

	[Category("Behavior")]
	[Description("The dialog-box result produced in a modal form by clicking the button.")]
	[DefaultValue(typeof(DialogResult), "None")]
	public DialogResult DialogResult
	{
		get
		{
			return _dialogResult;
		}
		set
		{
			_dialogResult = value;
		}
	}

	[Category("Behavior")]
	[Description("Command associated with the drop button.")]
	[DefaultValue(null)]
	public virtual KryptonCommand KryptonCommand
	{
		get
		{
			return _command;
		}
		set
		{
			if (_command != value)
			{
				if (_command != null)
				{
					_command.PropertyChanged -= OnCommandPropertyChanged;
				}
				else
				{
					_wasEnabled = base.Enabled;
				}
				_command = value;
				OnKryptonCommandChanged(EventArgs.Empty);
				if (_command != null)
				{
					_command.PropertyChanged += OnCommandPropertyChanged;
				}
				else
				{
					base.Enabled = _wasEnabled;
				}
			}
		}
	}

	[Category("Appearance")]
	[Description("When true the first character after an ampersand will be used as a mnemonic.")]
	[DefaultValue(true)]
	public bool UseMnemonic
	{
		get
		{
			return _useMnemonic;
		}
		set
		{
			if (_useMnemonic != value)
			{
				_useMnemonic = value;
				_drawButton.UseMnemonic = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new ImeMode ImeMode
	{
		get
		{
			return base.ImeMode;
		}
		set
		{
			base.ImeMode = value;
		}
	}

	protected override Size DefaultSize => new Size(90, 25);

	protected override ImeMode DefaultImeMode => ImeMode.Disable;

	protected virtual ViewDrawButton ViewDrawButton => _drawButton;

	[Category("Action")]
	[Description("Occurs when the drop down portion of the button is pressed.")]
	public event EventHandler<ContextPositionMenuArgs> DropDown;

	[Category("Property Changed")]
	[Description("Occurs when the value of the KryptonCommand property changes.")]
	public event EventHandler KryptonCommandChanged;

	public KryptonDropButton()
	{
		SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, value: false);
		_style = ButtonStyle.Standalone;
		_dialogResult = DialogResult.None;
		_useMnemonic = true;
		_buttonValues = CreateButtonValues(base.NeedPaintDelegate);
		_buttonValues.TextChanged += OnButtonTextChanged;
		_images = new DropDownButtonImages(base.NeedPaintDelegate);
		_paletteDropDownButtonImages = new PaletteRedirectDropDownButton(base.Redirector, _images);
		_stateCommon = new PaletteTripleRedirect(base.Redirector, PaletteBackStyle.ButtonStandalone, PaletteBorderStyle.ButtonStandalone, PaletteContentStyle.ButtonStandalone, base.NeedPaintDelegate);
		_stateDisabled = new PaletteTriple(_stateCommon, base.NeedPaintDelegate);
		_stateNormal = new PaletteTriple(_stateCommon, base.NeedPaintDelegate);
		_stateTracking = new PaletteTriple(_stateCommon, base.NeedPaintDelegate);
		_statePressed = new PaletteTriple(_stateCommon, base.NeedPaintDelegate);
		_stateDefault = new PaletteTripleRedirect(base.Redirector, PaletteBackStyle.ButtonStandalone, PaletteBorderStyle.ButtonStandalone, PaletteContentStyle.ButtonStandalone, base.NeedPaintDelegate);
		_stateFocus = new PaletteTripleRedirect(base.Redirector, PaletteBackStyle.ButtonStandalone, PaletteBorderStyle.ButtonStandalone, PaletteContentStyle.ButtonStandalone, base.NeedPaintDelegate);
		_overrideFocus = new PaletteTripleOverride(_stateFocus, _stateNormal, PaletteState.FocusOverride);
		_overrideNormal = new PaletteTripleOverride(_stateDefault, _overrideFocus, PaletteState.NormalDefaultOverride);
		_overrideTracking = new PaletteTripleOverride(_stateFocus, _stateTracking, PaletteState.FocusOverride);
		_overridePressed = new PaletteTripleOverride(_stateFocus, _statePressed, PaletteState.FocusOverride);
		_drawButton = new ViewDrawButton(_stateDisabled, _overrideNormal, _overrideTracking, _overridePressed, new PaletteMetricRedirect(base.Redirector), this, VisualOrientation.Top, UseMnemonic);
		_drawButton.DropDown = true;
		_drawButton.Splitter = true;
		_drawButton.TestForFocusCues = true;
		_drawButton.DropDownPalette = _paletteDropDownButtonImages;
		_buttonController = new ButtonController(_drawButton, base.NeedPaintDelegate);
		_buttonController.BecomesFixed = true;
		_drawButton.MouseController = _buttonController;
		_drawButton.KeyController = _buttonController;
		_drawButton.SourceController = _buttonController;
		_buttonController.Click += OnButtonClick;
		_buttonController.MouseSelect += OnButtonSelect;
		base.ViewManager = new ViewManager(this, _drawButton);
	}

	private bool ShouldSerializeText()
	{
		return false;
	}

	public override void ResetText()
	{
		_buttonValues.ResetText();
	}

	private void ResetButtonStyle()
	{
		ButtonStyle = ButtonStyle.Standalone;
	}

	private bool ShouldSerializeButtonStyle()
	{
		return ButtonStyle != ButtonStyle.Standalone;
	}

	private bool ShouldSerializeValues()
	{
		return !_buttonValues.IsDefault;
	}

	private bool ShouldSerializeImages()
	{
		return !_images.IsDefault;
	}

	private bool ShouldSerializeStateCommon()
	{
		return !_stateCommon.IsDefault;
	}

	private bool ShouldSerializeStateDisabled()
	{
		return !_stateDisabled.IsDefault;
	}

	private bool ShouldSerializeStateNormal()
	{
		return !_stateNormal.IsDefault;
	}

	private bool ShouldSerializeStateTracking()
	{
		return !_stateTracking.IsDefault;
	}

	private bool ShouldSerializeStatePressed()
	{
		return !_statePressed.IsDefault;
	}

	private bool ShouldSerializeOverrideDefault()
	{
		return !_stateDefault.IsDefault;
	}

	private bool ShouldSerializeOverrideFocus()
	{
		return !_stateFocus.IsDefault;
	}

	public void NotifyDefault(bool value)
	{
		if (!ViewDrawButton.IsFixed && _isDefault != value)
		{
			_isDefault = value;
			_overrideNormal.Apply = value;
			PerformNeedPaint(needLayout: true);
		}
	}

	public void PerformClick()
	{
		if (base.CanSelect)
		{
			OnClick(EventArgs.Empty);
		}
	}

	public void PerformDropDown()
	{
		if (base.CanSelect)
		{
			ShowDropDown();
		}
	}

	public void SetFixedState(PaletteState state)
	{
		if (state == PaletteState.NormalDefaultOverride)
		{
			_overrideFocus.Apply = true;
			_overrideNormal.Apply = true;
			state = PaletteState.Normal;
		}
		_drawButton.FixedState = state;
	}

	public string GetShortText()
	{
		if (KryptonCommand != null)
		{
			return KryptonCommand.Text;
		}
		return _buttonValues.GetShortText();
	}

	public string GetLongText()
	{
		if (KryptonCommand != null)
		{
			return KryptonCommand.ExtraText;
		}
		return _buttonValues.GetLongText();
	}

	public Image GetImage(PaletteState state)
	{
		if (KryptonCommand != null)
		{
			return KryptonCommand.ImageSmall;
		}
		return _buttonValues.GetImage(state);
	}

	public Color GetImageTransparentColor(PaletteState state)
	{
		if (KryptonCommand != null)
		{
			return KryptonCommand.ImageTransparentColor;
		}
		return _buttonValues.GetImageTransparentColor(state);
	}

	protected override void OnEnabledChanged(EventArgs e)
	{
		_drawButton.Enabled = base.Enabled;
		PerformNeedPaint(needLayout: true);
		base.OnEnabledChanged(e);
	}

	protected override void OnGotFocus(EventArgs e)
	{
		if (!ViewDrawButton.IsFixed)
		{
			_overrideFocus.Apply = true;
			_overrideTracking.Apply = true;
			_overridePressed.Apply = true;
			PerformNeedPaint(needLayout: false);
		}
		base.OnGotFocus(e);
	}

	protected override void OnLostFocus(EventArgs e)
	{
		if (!ViewDrawButton.IsFixed)
		{
			_overrideFocus.Apply = false;
			_overrideTracking.Apply = false;
			_overridePressed.Apply = false;
			PerformNeedPaint(needLayout: false);
		}
		base.OnLostFocus(e);
	}

	protected override void OnClick(EventArgs e)
	{
		Form form = FindForm();
		if (form != null)
		{
			form.DialogResult = DialogResult;
		}
		base.OnClick(e);
		if (KryptonCommand != null)
		{
			KryptonCommand.PerformExecute();
		}
	}

	protected override bool ProcessMnemonic(char charCode)
	{
		if (UseMnemonic && CanProcessMnemonic() && Control.IsMnemonic(charCode, Values.Text))
		{
			if (!Splitter)
			{
				PerformDropDown();
			}
			else
			{
				PerformClick();
			}
			return true;
		}
		return base.ProcessMnemonic(charCode);
	}

	protected override void ContextMenuClosed()
	{
		_buttonController.RemoveFixed();
	}

	protected override void WndProc(ref Message m)
	{
		if (m.Msg != 123)
		{
			base.WndProc(ref m);
		}
	}

	protected virtual void OnDropDown(ContextPositionMenuArgs e)
	{
		if (this.DropDown != null)
		{
			this.DropDown(this, e);
		}
	}

	protected virtual void OnKryptonCommandChanged(EventArgs e)
	{
		if (this.KryptonCommandChanged != null)
		{
			this.KryptonCommandChanged(this, e);
		}
		if (KryptonCommand != null)
		{
			base.Enabled = KryptonCommand.Enabled;
		}
		PerformNeedPaint(needLayout: true);
	}

	protected virtual void OnCommandPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "Enabled":
			base.Enabled = KryptonCommand.Enabled;
			break;
		case "Text":
		case "ExtraText":
		case "ImageSmall":
		case "ImageTransparentColor":
			PerformNeedPaint(needLayout: true);
			break;
		}
	}

	protected virtual void SetStyles(ButtonStyle buttonStyle)
	{
		_stateCommon.SetStyles(buttonStyle);
		_stateDefault.SetStyles(buttonStyle);
		_stateFocus.SetStyles(buttonStyle);
	}

	protected virtual ButtonValues CreateButtonValues(NeedPaintHandler needPaint)
	{
		return new ButtonValues(needPaint);
	}

	private void OnButtonTextChanged(object sender, EventArgs e)
	{
		OnTextChanged(EventArgs.Empty);
	}

	private void OnButtonClick(object sender, MouseEventArgs e)
	{
		bool flag = false;
		if (!Splitter || (Splitter && _drawButton.SplitRectangle.Contains(e.Location)))
		{
			flag = ShowDropDown();
		}
		else
		{
			OnClick(EventArgs.Empty);
			OnMouseClick(e);
		}
		if (!flag)
		{
			ContextMenuClosed();
		}
	}

	private bool ShowDropDown()
	{
		bool result = false;
		if (KryptonContextMenu != null)
		{
			if (base.PaletteMode != PaletteMode.Custom)
			{
				KryptonContextMenu.PaletteMode = base.PaletteMode;
			}
			else
			{
				KryptonContextMenu.Palette = base.Palette;
			}
		}
		ContextPositionMenuArgs contextPositionMenuArgs = new ContextPositionMenuArgs(ContextMenuStrip, KryptonContextMenu, GetPositionH(), GetPositionV());
		OnDropDown(contextPositionMenuArgs);
		if (!contextPositionMenuArgs.Cancel)
		{
			if (contextPositionMenuArgs.KryptonContextMenu != null)
			{
				Rectangle screenRect = RectangleToScreen(base.ClientRectangle);
				if (CommonHelper.ValidKryptonContextMenu(contextPositionMenuArgs.KryptonContextMenu))
				{
					switch (contextPositionMenuArgs.PositionV)
					{
					case KryptonContextMenuPositionV.Above:
						screenRect.Y--;
						break;
					case KryptonContextMenuPositionV.Below:
						screenRect.Height++;
						break;
					}
					switch (contextPositionMenuArgs.PositionH)
					{
					case KryptonContextMenuPositionH.Before:
						screenRect.X--;
						break;
					case KryptonContextMenuPositionH.After:
						screenRect.Width++;
						break;
					}
					result = true;
					contextPositionMenuArgs.KryptonContextMenu.Closed += OnKryptonContextMenuClosed;
					contextPositionMenuArgs.KryptonContextMenu.Show(this, screenRect, contextPositionMenuArgs.PositionH, contextPositionMenuArgs.PositionV);
				}
			}
			else if (contextPositionMenuArgs.ContextMenuStrip != null)
			{
				Rectangle rectangle = RectangleToScreen(base.ClientRectangle);
				if (CommonHelper.ValidContextMenuStrip(contextPositionMenuArgs.ContextMenuStrip))
				{
					result = true;
					VisualPopupManager.Singleton.ShowContextMenuStrip(contextPositionMenuArgs.ContextMenuStrip, new Point(rectangle.X, rectangle.Bottom + 1), OnContextMenuClosed);
				}
			}
		}
		return result;
	}

	private KryptonContextMenuPositionH GetPositionH()
	{
		return DropDownOrientation switch
		{
			VisualOrientation.Left => KryptonContextMenuPositionH.Before, 
			VisualOrientation.Right => KryptonContextMenuPositionH.After, 
			_ => KryptonContextMenuPositionH.Left, 
		};
	}

	private KryptonContextMenuPositionV GetPositionV()
	{
		switch (DropDownOrientation)
		{
		default:
			return KryptonContextMenuPositionV.Below;
		case VisualOrientation.Top:
			return KryptonContextMenuPositionV.Above;
		case VisualOrientation.Left:
		case VisualOrientation.Right:
			return KryptonContextMenuPositionV.Top;
		}
	}

	private void OnContextMenuClosed(object sender, EventArgs e)
	{
		ContextMenuClosed();
	}

	private void OnKryptonContextMenuClosed(object sender, EventArgs e)
	{
		KryptonContextMenu kryptonContextMenu = (KryptonContextMenu)sender;
		kryptonContextMenu.Closed -= OnKryptonContextMenuClosed;
		ContextMenuClosed();
	}

	private void OnButtonSelect(object sender, MouseEventArgs e)
	{
		if (base.CanFocus)
		{
			Focus();
		}
	}
}
