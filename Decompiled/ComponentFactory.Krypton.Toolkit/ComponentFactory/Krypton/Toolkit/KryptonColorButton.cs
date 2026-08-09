using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit.Properties;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonColorButton), "ToolboxBitmaps.KryptonColorButton.bmp")]
[DefaultEvent("SelectedColorChanged")]
[DefaultProperty("SelectedColor")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonColorButtonDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[Description("Raises an event when the user clicks it.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonColorButton : VisualSimpleBase, IButtonControl, IContentValues
{
	private ViewDrawButton _drawButton;

	private ButtonStyle _style;

	private ColorButtonValues _buttonValues;

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

	private PaletteColorButtonStrings _strings;

	private KryptonCommand _command;

	private DropDownButtonImages _images;

	private DialogResult _dialogResult;

	private Rectangle _selectedRect;

	private Color _selectedColor;

	private Color _emptyBorderColor;

	private ColorScheme _schemeThemes;

	private ColorScheme _schemeStandard;

	private List<Color> _recentColors;

	private int _maxRecentColors;

	private Image _wasImage;

	private bool _wasEnabled;

	private bool _autoRecentColors;

	private bool _visibleThemes;

	private bool _visibleStandard;

	private bool _visibleRecent;

	private bool _visibleNoColor;

	private bool _visibleMoreColors;

	private bool _isDefault;

	private bool _useMnemonic;

	private KryptonContextMenu _kryptonContextMenu;

	private KryptonContextMenuSeparator _separatorTheme;

	private KryptonContextMenuSeparator _separatorStandard;

	private KryptonContextMenuSeparator _separatorRecent;

	private KryptonContextMenuHeading _headingTheme;

	private KryptonContextMenuHeading _headingStandard;

	private KryptonContextMenuHeading _headingRecent;

	private KryptonContextMenuColorColumns _colorsTheme;

	private KryptonContextMenuColorColumns _colorsStandard;

	private KryptonContextMenuColorColumns _colorsRecent;

	private KryptonContextMenuSeparator _separatorNoColor;

	private KryptonContextMenuItems _itemsNoColor;

	private KryptonContextMenuItem _itemNoColor;

	private KryptonContextMenuSeparator _separatorMoreColors;

	private KryptonContextMenuItems _itemsMoreColors;

	private KryptonContextMenuItem _itemMoreColors;

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

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override ContextMenuStrip ContextMenuStrip
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override KryptonContextMenu KryptonContextMenu
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	[Category("Behavior")]
	[Description("Determine the maximum number of recent colors to store and display.")]
	[DefaultValue(10)]
	public int MaxRecentColors
	{
		get
		{
			return _maxRecentColors;
		}
		set
		{
			_maxRecentColors = value;
		}
	}

	[Category("Behavior")]
	[Description("Determine the visible state of the themes color set.")]
	[DefaultValue(true)]
	public bool VisibleThemes
	{
		get
		{
			return _visibleThemes;
		}
		set
		{
			_visibleThemes = value;
		}
	}

	[Category("Behavior")]
	[Description("Determine the visible state of the standard color set.")]
	[DefaultValue(true)]
	public bool VisibleStandard
	{
		get
		{
			return _visibleStandard;
		}
		set
		{
			_visibleStandard = value;
		}
	}

	[Category("Behavior")]
	[Description("Determine the visible state of the recent color set.")]
	[DefaultValue(true)]
	public bool VisibleRecent
	{
		get
		{
			return _visibleRecent;
		}
		set
		{
			_visibleRecent = value;
		}
	}

	[Category("Behavior")]
	[Description("Determine if the 'No Color' menu item is used.")]
	[DefaultValue(true)]
	public bool VisibleNoColor
	{
		get
		{
			return _visibleNoColor;
		}
		set
		{
			_visibleNoColor = value;
		}
	}

	[Category("Behavior")]
	[Description("Determine if the 'More Colors...' menu item is used.")]
	[DefaultValue(true)]
	public bool VisibleMoreColors
	{
		get
		{
			return _visibleMoreColors;
		}
		set
		{
			_visibleMoreColors = value;
		}
	}

	[Category("Behavior")]
	[Description("Should recent colors be automatically updated.")]
	[DefaultValue(true)]
	public bool AutoRecentColors
	{
		get
		{
			return _autoRecentColors;
		}
		set
		{
			_autoRecentColors = value;
		}
	}

	[Category("Behavior")]
	[Description("Color scheme to use for the themes color set.")]
	[DefaultValue(typeof(ColorScheme), "OfficeThemes")]
	public ColorScheme SchemeThemes
	{
		get
		{
			return _schemeThemes;
		}
		set
		{
			_schemeThemes = value;
		}
	}

	[Category("Behavior")]
	[Description("Color scheme to use for the standard color set.")]
	[DefaultValue(typeof(ColorScheme), "OfficeStandard")]
	public ColorScheme SchemeStandard
	{
		get
		{
			return _schemeStandard;
		}
		set
		{
			_schemeStandard = value;
		}
	}

	[Bindable(true)]
	[Category("Appearance")]
	[Description("Selected color.")]
	[DefaultValue(typeof(Color), "Red")]
	public Color SelectedColor
	{
		get
		{
			return _selectedColor;
		}
		set
		{
			if (value != _selectedColor)
			{
				_selectedColor = value;
				_buttonValues.SelectedColor = value;
				UpdateRecentColors(_selectedColor);
				OnSelectedColorChanged(_selectedColor);
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Bindable(true)]
	[Category("Appearance")]
	[Description("Border color of selected block when selected color is empty.")]
	[DefaultValue(typeof(Color), "DarkGray")]
	public Color EmptyBorderColor
	{
		get
		{
			return _emptyBorderColor;
		}
		set
		{
			if (value != _emptyBorderColor)
			{
				_emptyBorderColor = value;
				_buttonValues.EmptyBorderColor = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Bindable(true)]
	[Category("Appearance")]
	[Description("Selected color drawing rectangle.")]
	[DefaultValue(typeof(Rectangle), "0,12,16,4")]
	public Rectangle SelectedRect
	{
		get
		{
			return _selectedRect;
		}
		set
		{
			_selectedRect = value;
			_buttonValues.SelectedRect = value;
			PerformNeedPaint(needLayout: true);
		}
	}

	[Category("Visuals")]
	[Description("Visual orientation of the control.")]
	[DefaultValue(typeof(VisualOrientation), "Top")]
	public virtual VisualOrientation ButtonOrientation
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
	[Description("Position of the drop arrow within the color button.")]
	[DefaultValue(typeof(VisualOrientation), "Right")]
	public virtual VisualOrientation DropDownPosition
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
	[Description("Orientation of the drop arrow within the color button.")]
	[DefaultValue(typeof(VisualOrientation), "Bottom")]
	public virtual VisualOrientation DropDownOrientation
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
	[Description("Determine if color button acts as a splitter or just a drop down.")]
	[DefaultValue(true)]
	public virtual bool Splitter
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
	[Description("Color button style.")]
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
	[Description("Color button values")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public ColorButtonValues Values => _buttonValues;

	[Category("Visuals")]
	[Description("Image value overrides.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public DropDownButtonImages Images => _images;

	[Category("Visuals")]
	[Description("Context menu display strings.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteColorButtonStrings Strings => _strings;

	[Category("Visuals")]
	[Description("Overrides for defining common color button appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleRedirect StateCommon => _stateCommon;

	[Category("Visuals")]
	[Description("Overrides for defining disabled color button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateDisabled => _stateDisabled;

	[Category("Visuals")]
	[Description("Overrides for defining normal color button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateNormal => _stateNormal;

	[Category("Visuals")]
	[Description("Overrides for defining hot tracking color button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateTracking => _stateTracking;

	[Category("Visuals")]
	[Description("Overrides for defining pressed color button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StatePressed => _statePressed;

	[Category("Visuals")]
	[Description("Overrides for defining normal color button appearance when default.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleRedirect OverrideDefault => _stateDefault;

	[Category("Visuals")]
	[Description("Overrides for defining color button appearance when it has focus.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleRedirect OverrideFocus => _stateFocus;

	[Category("Behavior")]
	[Description("The dialog-box result produced in a modal form by clicking the color button.")]
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
	[Description("Command associated with the color button.")]
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
					_wasImage = Values.Image;
				}
				_command = value;
				OnKryptonCommandChanged(EventArgs.Empty);
				if (_command != null)
				{
					_command.PropertyChanged += OnCommandPropertyChanged;
					return;
				}
				base.Enabled = _wasEnabled;
				Values.Image = _wasImage;
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
	[Description("Occurs when the drop down portion of the color button is pressed.")]
	public event EventHandler<ContextPositionMenuArgs> DropDown;

	[Category("Property Changed")]
	[Description("Occurs when the value of the KryptonCommand property changes.")]
	public event EventHandler KryptonCommandChanged;

	[Category("Property Changed")]
	[Description("Occurs when the SelectedColor property changes value.")]
	public event EventHandler<ColorEventArgs> SelectedColorChanged;

	[Category("Action")]
	[Description("Occurs when user is tracking over a color.")]
	public event EventHandler<ColorEventArgs> TrackingColor;

	[Category("Action")]
	[Description("Occurs when user selects the more colors option.")]
	public event CancelEventHandler MoreColors;

	public KryptonColorButton()
	{
		SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, value: false);
		_style = ButtonStyle.Standalone;
		_visibleThemes = true;
		_visibleStandard = true;
		_visibleRecent = true;
		_visibleNoColor = true;
		_visibleMoreColors = true;
		_autoRecentColors = true;
		_schemeThemes = ColorScheme.OfficeThemes;
		_schemeStandard = ColorScheme.OfficeStandard;
		_selectedRect = new Rectangle(0, 12, 16, 4);
		_selectedColor = Color.Red;
		_emptyBorderColor = Color.DarkGray;
		_dialogResult = DialogResult.None;
		_useMnemonic = true;
		_maxRecentColors = 10;
		_recentColors = new List<Color>();
		_kryptonContextMenu = new KryptonContextMenu();
		_separatorTheme = new KryptonContextMenuSeparator();
		_headingTheme = new KryptonContextMenuHeading("Theme Colors");
		_colorsTheme = new KryptonContextMenuColorColumns(ColorScheme.OfficeThemes);
		_separatorStandard = new KryptonContextMenuSeparator();
		_headingStandard = new KryptonContextMenuHeading("Standard Colors");
		_colorsStandard = new KryptonContextMenuColorColumns(ColorScheme.OfficeStandard);
		_separatorRecent = new KryptonContextMenuSeparator();
		_headingRecent = new KryptonContextMenuHeading("Recent Colors");
		_colorsRecent = new KryptonContextMenuColorColumns(ColorScheme.None);
		_separatorNoColor = new KryptonContextMenuSeparator();
		_itemNoColor = new KryptonContextMenuItem("&No Color", Resources.ButtonNoColor, OnClickNoColor);
		_itemsNoColor = new KryptonContextMenuItems();
		_itemsNoColor.Items.Add(_itemNoColor);
		_separatorMoreColors = new KryptonContextMenuSeparator();
		_itemMoreColors = new KryptonContextMenuItem("&More Colors...", OnClickMoreColors);
		_itemsMoreColors = new KryptonContextMenuItems();
		_itemsMoreColors.Items.Add(_itemMoreColors);
		_kryptonContextMenu.Items.AddRange(new KryptonContextMenuItemBase[13]
		{
			_separatorTheme, _headingTheme, _colorsTheme, _separatorStandard, _headingStandard, _colorsStandard, _separatorRecent, _headingRecent, _colorsRecent, _separatorNoColor,
			_itemsNoColor, _separatorMoreColors, _itemsMoreColors
		});
		_buttonValues = CreateButtonValues(base.NeedPaintDelegate);
		_buttonValues.TextChanged += OnButtonTextChanged;
		_images = new DropDownButtonImages(base.NeedPaintDelegate);
		_paletteDropDownButtonImages = new PaletteRedirectDropDownButton(base.Redirector, _images);
		_strings = new PaletteColorButtonStrings();
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

	private bool ShouldSerializeButtonStyle()
	{
		return ButtonStyle != ButtonStyle.Standalone;
	}

	private void ResetButtonStyle()
	{
		ButtonStyle = ButtonStyle.Standalone;
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

	public virtual void SetFixedState(PaletteState state)
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

	protected virtual void OnSelectedColorChanged(Color selectedColor)
	{
		if (this.SelectedColorChanged != null)
		{
			this.SelectedColorChanged(this, new ColorEventArgs(selectedColor));
		}
	}

	protected virtual void OnTrackingColor(ColorEventArgs e)
	{
		if (this.TrackingColor != null)
		{
			this.TrackingColor(this, e);
		}
	}

	protected virtual void OnMoreColors(CancelEventArgs e)
	{
		if (this.MoreColors != null)
		{
			this.MoreColors(this, e);
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
			Values.Image = KryptonCommand.ImageSmall;
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
		case "ImageSmall":
			Values.Image = KryptonCommand.ImageSmall;
			PerformNeedPaint(needLayout: true);
			break;
		case "Text":
		case "ExtraText":
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

	protected virtual ColorButtonValues CreateButtonValues(NeedPaintHandler needPaint)
	{
		return new ColorButtonValues(needPaint);
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
		UpdateContextMenu();
		if (_kryptonContextMenu != null)
		{
			if (base.PaletteMode != PaletteMode.Custom)
			{
				_kryptonContextMenu.PaletteMode = base.PaletteMode;
			}
			else
			{
				_kryptonContextMenu.Palette = base.Palette;
			}
		}
		ContextPositionMenuArgs contextPositionMenuArgs = new ContextPositionMenuArgs(null, _kryptonContextMenu, GetPositionH(), GetPositionV());
		OnDropDown(contextPositionMenuArgs);
		if (!contextPositionMenuArgs.Cancel && contextPositionMenuArgs.KryptonContextMenu != null)
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
				DecideOnVisible(_separatorTheme, _colorsTheme);
				DecideOnVisible(_separatorStandard, _colorsStandard);
				DecideOnVisible(_separatorRecent, _colorsRecent);
				DecideOnVisible(_separatorNoColor, _itemsNoColor);
				DecideOnVisible(_separatorMoreColors, _itemsMoreColors);
				HookContextMenuEvents(_kryptonContextMenu.Items, hook: true);
				contextPositionMenuArgs.KryptonContextMenu.Closed += OnKryptonContextMenuClosed;
				contextPositionMenuArgs.KryptonContextMenu.Show(this, screenRect, contextPositionMenuArgs.PositionH, contextPositionMenuArgs.PositionV);
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
		HookContextMenuEvents(_kryptonContextMenu.Items, hook: false);
	}

	private void OnButtonSelect(object sender, MouseEventArgs e)
	{
		if (base.CanFocus)
		{
			Focus();
		}
	}

	private void HookContextMenuEvents(KryptonContextMenuCollection collection, bool hook)
	{
		foreach (KryptonContextMenuItemBase item in collection)
		{
			if (item is KryptonContextMenuColorColumns)
			{
				KryptonContextMenuColorColumns kryptonContextMenuColorColumns = (KryptonContextMenuColorColumns)item;
				kryptonContextMenuColorColumns.SelectedColor = _selectedColor;
				if (hook)
				{
					kryptonContextMenuColorColumns.TrackingColor += OnColumnsTrackingColor;
					kryptonContextMenuColorColumns.SelectedColorChanged += OnColumnsSelectedColorChanged;
				}
				else
				{
					kryptonContextMenuColorColumns.TrackingColor -= OnColumnsTrackingColor;
					kryptonContextMenuColorColumns.SelectedColorChanged -= OnColumnsSelectedColorChanged;
				}
			}
		}
	}

	private void UpdateRecentColors(Color color)
	{
		if (!AutoRecentColors)
		{
			return;
		}
		foreach (KryptonContextMenuItemBase item in _kryptonContextMenu.Items)
		{
			if (item is KryptonContextMenuColorColumns && item != _colorsRecent)
			{
				KryptonContextMenuColorColumns kryptonContextMenuColorColumns = (KryptonContextMenuColorColumns)item;
				if ((item != _colorsTheme || VisibleThemes) && (item != _colorsStandard || VisibleStandard) && kryptonContextMenuColorColumns.ContainsColor(color))
				{
					return;
				}
			}
		}
		if (color.Equals(Color.Empty))
		{
			return;
		}
		bool flag = false;
		foreach (Color recentColor in _recentColors)
		{
			if (recentColor.Equals(color))
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			_recentColors.Insert(0, color);
			if (_recentColors.Count > MaxRecentColors)
			{
				_recentColors.RemoveRange(MaxRecentColors, _recentColors.Count - MaxRecentColors);
			}
		}
	}

	private void UpdateContextMenu()
	{
		KryptonContextMenuSeparator separatorTheme = _separatorTheme;
		KryptonContextMenuHeading headingTheme = _headingTheme;
		bool flag = (_colorsTheme.Visible = _visibleThemes);
		bool visible = (headingTheme.Visible = flag);
		separatorTheme.Visible = visible;
		KryptonContextMenuSeparator separatorStandard = _separatorStandard;
		KryptonContextMenuHeading headingStandard = _headingStandard;
		flag = (_colorsStandard.Visible = _visibleStandard);
		visible = (headingStandard.Visible = flag);
		separatorStandard.Visible = visible;
		KryptonContextMenuSeparator separatorRecent = _separatorRecent;
		KryptonContextMenuHeading headingRecent = _headingRecent;
		flag = (_colorsRecent.Visible = _visibleRecent && _recentColors.Count > 0);
		visible = (headingRecent.Visible = flag);
		separatorRecent.Visible = visible;
		_itemsNoColor.Visible = _visibleNoColor;
		_itemsMoreColors.Visible = _visibleMoreColors;
		_headingTheme.Text = Strings.ThemeColors;
		_headingStandard.Text = Strings.StandardColors;
		_headingRecent.Text = Strings.RecentColors;
		_itemNoColor.Text = Strings.NoColor;
		_itemMoreColors.Text = Strings.MoreColors;
		_colorsTheme.ColorScheme = SchemeThemes;
		_colorsStandard.ColorScheme = SchemeStandard;
		if (_recentColors.Count == 0)
		{
			_colorsRecent.SetCustomColors(null);
		}
		else
		{
			Color[][] array = new Color[_recentColors.Count][];
			for (int i = 0; i < _recentColors.Count; i++)
			{
				array[i] = new Color[1] { _recentColors[i] };
			}
			_colorsRecent.SetCustomColors(array);
		}
		_itemNoColor.Checked = _selectedColor.Equals(Color.Empty);
	}

	private void DecideOnVisible(KryptonContextMenuItemBase visible, KryptonContextMenuItemBase target)
	{
		bool visible2 = false;
		if (target.Visible)
		{
			foreach (KryptonContextMenuItemBase item in _kryptonContextMenu.Items)
			{
				if (item == target)
				{
					break;
				}
				if (!(item is KryptonContextMenuSeparator) && !(item is KryptonContextMenuHeading) && item.Visible)
				{
					visible2 = true;
					break;
				}
			}
		}
		visible.Visible = visible2;
	}

	private void OnColumnsTrackingColor(object sender, ColorEventArgs e)
	{
		OnTrackingColor(new ColorEventArgs(e.Color));
	}

	private void OnColumnsSelectedColorChanged(object sender, ColorEventArgs e)
	{
		SelectedColor = e.Color;
	}

	private void OnClickNoColor(object sender, EventArgs e)
	{
		SelectedColor = Color.Empty;
	}

	private void OnClickMoreColors(object sender, EventArgs e)
	{
		CancelEventArgs e2 = new CancelEventArgs();
		OnMoreColors(e2);
		if (!e2.Cancel)
		{
			ColorDialog colorDialog = new ColorDialog();
			colorDialog.Color = SelectedColor;
			colorDialog.FullOpen = true;
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				SelectedColor = colorDialog.Color;
			}
		}
	}
}
