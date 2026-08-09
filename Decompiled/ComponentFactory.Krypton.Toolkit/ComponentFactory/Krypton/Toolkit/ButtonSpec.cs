#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
[DesignTimeVisible(false)]
[ToolboxBitmap(typeof(ButtonSpec), "ToolboxBitmaps.KryptonButtonSpec.bmp")]
[DefaultEvent("Click")]
[DefaultProperty("Style")]
public abstract class ButtonSpec : Component, IButtonSpecValues, ICloneable
{
	private Image _image;

	private Image _toolTipImage;

	private Color _colorMap;

	private Color _imageTransparentColor;

	private Color _toolTipImageTransparentColor;

	private object _owner;

	private object _tag;

	private string _text;

	private string _extraText;

	private string _uniqueName;

	private string _toolTipTitle;

	private string _toolTipBody;

	private bool _allowInheritImage;

	private bool _allowInheritText;

	private bool _allowInheritExtraText;

	private bool _allowInheritToolTipTitle;

	private ViewBase _buttonSpecView;

	private LabelStyle _toolTipStyle;

	private KryptonCommand _command;

	private PaletteButtonStyle _style;

	private PaletteButtonOrientation _orientation;

	private PaletteButtonSpecStyle _type;

	private PaletteRelativeEdgeAlign _edge;

	private CheckButtonImageStates _imageStates;

	private ContextMenuStrip _contextMenuStrip;

	private KryptonContextMenu _kryptonContextMenu;

	[Browsable(false)]
	public virtual bool IsDefault => _imageStates.IsDefault && Image == null && ToolTipImage == null && ColorMap == Color.Empty && ImageTransparentColor == Color.Empty && ToolTipImageTransparentColor == Color.Empty && Text == string.Empty && ExtraText == string.Empty && ToolTipTitle == string.Empty && ToolTipBody == string.Empty && ToolTipStyle == LabelStyle.ToolTip && Style == PaletteButtonStyle.Inherit && Orientation == PaletteButtonOrientation.Inherit && Edge == PaletteRelativeEdgeAlign.Inherit && ContextMenuStrip == null && AllowInheritImage && AllowInheritText && AllowInheritExtraText && AllowInheritToolTipTitle;

	[Localizable(true)]
	[Category("Appearance")]
	[Description("Button image.")]
	public Image Image
	{
		get
		{
			return _image;
		}
		set
		{
			if (_image != value)
			{
				_image = value;
				OnButtonSpecPropertyChanged("Image");
			}
		}
	}

	[Localizable(true)]
	[Category("Appearance")]
	[Description("Button image transparent color.")]
	[KryptonDefaultColor]
	public Color ImageTransparentColor
	{
		get
		{
			return _imageTransparentColor;
		}
		set
		{
			if (_imageTransparentColor != value)
			{
				_imageTransparentColor = value;
				OnButtonSpecPropertyChanged("ImageTransparentColor");
			}
		}
	}

	[Category("Appearance")]
	[Description("State specific images for the button.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public ButtonImageStates ImageStates => _imageStates;

	[Localizable(true)]
	[Category("Appearance")]
	[Description("Button text.")]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	public string Text
	{
		get
		{
			return _text;
		}
		set
		{
			if (_text != value)
			{
				_text = value;
				OnButtonSpecPropertyChanged("Text");
			}
		}
	}

	[Localizable(true)]
	[Category("Appearance")]
	[Description("Button extra text.")]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	public string ExtraText
	{
		get
		{
			return _extraText;
		}
		set
		{
			if (_extraText != value)
			{
				_extraText = value;
				OnButtonSpecPropertyChanged("ExtraText");
			}
		}
	}

	[Localizable(true)]
	[Category("ToolTip")]
	[Description("Button tooltip image.")]
	[DefaultValue(null)]
	public Image ToolTipImage
	{
		get
		{
			return _toolTipImage;
		}
		set
		{
			if (_toolTipImage != value)
			{
				_toolTipImage = value;
				OnButtonSpecPropertyChanged("ToolTipImage");
			}
		}
	}

	[Localizable(true)]
	[Category("ToolTip")]
	[Description("Button image transparent color.")]
	[KryptonDefaultColor]
	public Color ToolTipImageTransparentColor
	{
		get
		{
			return _toolTipImageTransparentColor;
		}
		set
		{
			if (_toolTipImageTransparentColor != value)
			{
				_toolTipImageTransparentColor = value;
				OnButtonSpecPropertyChanged("ToolTipImageTransparentColor");
			}
		}
	}

	[Localizable(true)]
	[Category("ToolTip")]
	[Description("Button tooltip title text.")]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DefaultValue("")]
	public string ToolTipTitle
	{
		get
		{
			return _toolTipTitle;
		}
		set
		{
			if (_toolTipTitle != value)
			{
				_toolTipTitle = value;
				OnButtonSpecPropertyChanged("ToolTipTitle");
			}
		}
	}

	[Localizable(true)]
	[Category("ToolTip")]
	[Description("Button tooltip body text.")]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DefaultValue("")]
	public string ToolTipBody
	{
		get
		{
			return _toolTipBody;
		}
		set
		{
			if (_toolTipBody != value)
			{
				_toolTipBody = value;
				OnButtonSpecPropertyChanged("ToolTipBody");
			}
		}
	}

	[Category("ToolTip")]
	[Description("Button tooltip label style.")]
	[DefaultValue(typeof(LabelStyle), "Tooltip")]
	public LabelStyle ToolTipStyle
	{
		get
		{
			return _toolTipStyle;
		}
		set
		{
			_toolTipStyle = value;
		}
	}

	[Category("Data")]
	[Description("The unique name of the ButtonSpec.")]
	public string UniqueName
	{
		get
		{
			return _uniqueName;
		}
		set
		{
			_uniqueName = value;
		}
	}

	[Localizable(true)]
	[Category("Inherit")]
	[Description("Should button image be inherited if defined as null.")]
	[DefaultValue(true)]
	public bool AllowInheritImage
	{
		get
		{
			return _allowInheritImage;
		}
		set
		{
			if (_allowInheritImage != value)
			{
				_allowInheritImage = value;
				OnButtonSpecPropertyChanged("Image");
			}
		}
	}

	[Localizable(true)]
	[Category("Inherit")]
	[Description("Should button text be inherited if defined as empty.")]
	[DefaultValue(true)]
	public bool AllowInheritText
	{
		get
		{
			return _allowInheritText;
		}
		set
		{
			if (_allowInheritText != value)
			{
				_allowInheritText = value;
				OnButtonSpecPropertyChanged("Text");
			}
		}
	}

	[Localizable(true)]
	[Category("Inherit")]
	[Description("Should button extra text be inherited if defined as empty.")]
	[DefaultValue(true)]
	public bool AllowInheritExtraText
	{
		get
		{
			return _allowInheritExtraText;
		}
		set
		{
			if (_allowInheritExtraText != value)
			{
				_allowInheritExtraText = value;
				OnButtonSpecPropertyChanged("ExtraText");
			}
		}
	}

	[Localizable(true)]
	[Category("Inherit")]
	[Description("Should button tooltip title text be inherited if defined as empty.")]
	[DefaultValue(true)]
	public bool AllowInheritToolTipTitle
	{
		get
		{
			return _allowInheritToolTipTitle;
		}
		set
		{
			if (_allowInheritToolTipTitle != value)
			{
				_allowInheritToolTipTitle = value;
				OnButtonSpecPropertyChanged("ToolTipTitle");
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual bool AllowComponent => true;

	[Localizable(true)]
	[Category("Appearance")]
	[Description("Image color to remap to container foreground.")]
	[KryptonDefaultColor]
	public Color ColorMap
	{
		get
		{
			return _colorMap;
		}
		set
		{
			if (_colorMap != value)
			{
				_colorMap = value;
				OnButtonSpecPropertyChanged("ColorMap");
			}
		}
	}

	[Localizable(true)]
	[Category("Behavior")]
	[Description("Button style.")]
	[DefaultValue(typeof(PaletteButtonStyle), "Inherit")]
	public PaletteButtonStyle Style
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
				OnButtonSpecPropertyChanged("Style");
			}
		}
	}

	[Localizable(true)]
	[Category("Behavior")]
	[Description("Defines the button orientation.")]
	[RefreshProperties(RefreshProperties.All)]
	public PaletteButtonOrientation Orientation
	{
		get
		{
			return _orientation;
		}
		set
		{
			if (_orientation != value)
			{
				_orientation = value;
				OnButtonSpecPropertyChanged("Orientation");
			}
		}
	}

	[Localizable(true)]
	[Category("Behavior")]
	[Description("The header edge to display the button against.")]
	[RefreshProperties(RefreshProperties.All)]
	public PaletteRelativeEdgeAlign Edge
	{
		get
		{
			return _edge;
		}
		set
		{
			if (_edge != value)
			{
				_edge = value;
				OnButtonSpecPropertyChanged("Edge");
			}
		}
	}

	[Localizable(true)]
	[Category("Behavior")]
	[Description("ContextMenuStrip to show when the button is pressed.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(null)]
	public ContextMenuStrip ContextMenuStrip
	{
		get
		{
			return _contextMenuStrip;
		}
		set
		{
			_contextMenuStrip = value;
		}
	}

	[Localizable(true)]
	[Category("Behavior")]
	[Description("KryptonContextMenu to show when the button is pressed.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(null)]
	public KryptonContextMenu KryptonContextMenu
	{
		get
		{
			return _kryptonContextMenu;
		}
		set
		{
			_kryptonContextMenu = value;
		}
	}

	[Category("Behavior")]
	[Description("Command associated with the button.")]
	[RefreshProperties(RefreshProperties.All)]
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
				_command = value;
				OnButtonSpecPropertyChanged("KryptonCommand");
				if (_command != null)
				{
					_command.PropertyChanged += OnCommandPropertyChanged;
				}
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public object Owner
	{
		get
		{
			return _owner;
		}
		set
		{
			_owner = value;
		}
	}

	[Category("Data")]
	[Description("User-defined data associated with the object.")]
	[TypeConverter(typeof(StringConverter))]
	[DefaultValue(null)]
	public object Tag
	{
		get
		{
			return _tag;
		}
		set
		{
			_tag = value;
		}
	}

	protected PaletteButtonSpecStyle ProtectedType
	{
		get
		{
			return _type;
		}
		set
		{
			_type = value;
		}
	}

	[Category("Action")]
	[Description("Occurs when the component is clicked.")]
	public event EventHandler Click;

	[Category("ButtonSpec")]
	[Description("Occurs when a button specification property has changed.")]
	public event PropertyChangedEventHandler ButtonSpecPropertyChanged;

	public ButtonSpec()
	{
		_image = null;
		_toolTipImage = null;
		_colorMap = Color.Empty;
		_imageTransparentColor = Color.Empty;
		_toolTipImageTransparentColor = Color.Empty;
		_text = string.Empty;
		_extraText = string.Empty;
		_uniqueName = CommonHelper.UniqueString;
		_toolTipTitle = string.Empty;
		_toolTipBody = string.Empty;
		_allowInheritImage = true;
		_allowInheritText = true;
		_allowInheritExtraText = true;
		_allowInheritToolTipTitle = true;
		_toolTipStyle = LabelStyle.ToolTip;
		_style = PaletteButtonStyle.Inherit;
		_orientation = PaletteButtonOrientation.Inherit;
		_type = PaletteButtonSpecStyle.Generic;
		_edge = PaletteRelativeEdgeAlign.Inherit;
		_imageStates = new CheckButtonImageStates();
		_imageStates.NeedPaint = OnImageStateChanged;
		_contextMenuStrip = null;
		_kryptonContextMenu = null;
		_buttonSpecView = null;
	}

	public override string ToString()
	{
		if (!IsDefault)
		{
			return "Modified";
		}
		return string.Empty;
	}

	public virtual object Clone()
	{
		ButtonSpec buttonSpec = (ButtonSpec)Activator.CreateInstance(GetType());
		buttonSpec.Image = Image;
		buttonSpec.ImageTransparentColor = ImageTransparentColor;
		buttonSpec.Text = Text;
		buttonSpec.ExtraText = ExtraText;
		buttonSpec.ToolTipImage = ToolTipImage;
		buttonSpec.ToolTipImageTransparentColor = ToolTipImageTransparentColor;
		buttonSpec.ToolTipTitle = ToolTipTitle;
		buttonSpec.ToolTipBody = ToolTipBody;
		buttonSpec.ToolTipStyle = ToolTipStyle;
		buttonSpec.UniqueName = UniqueName;
		buttonSpec.AllowInheritImage = AllowInheritImage;
		buttonSpec.AllowInheritText = AllowInheritText;
		buttonSpec.AllowInheritExtraText = AllowInheritExtraText;
		buttonSpec.AllowInheritToolTipTitle = AllowInheritToolTipTitle;
		buttonSpec.ColorMap = ColorMap;
		buttonSpec.Style = Style;
		buttonSpec.Orientation = Orientation;
		buttonSpec.Edge = Edge;
		buttonSpec.ContextMenuStrip = ContextMenuStrip;
		buttonSpec.KryptonContextMenu = KryptonContextMenu;
		buttonSpec.KryptonCommand = KryptonCommand;
		buttonSpec.Owner = Owner;
		buttonSpec.Tag = Tag;
		return buttonSpec;
	}

	private bool ShouldSerializeImage()
	{
		return Image != null;
	}

	public void ResetImage()
	{
		Image = null;
	}

	private bool ShouldSerializeImageTransparentColor()
	{
		return ImageTransparentColor != Color.Empty;
	}

	public void ResetImageTransparentColor()
	{
		ImageTransparentColor = Color.Empty;
	}

	private bool ShouldSerializeImageStates()
	{
		return !_imageStates.IsDefault;
	}

	private bool ShouldSerializeText()
	{
		return Text != string.Empty;
	}

	public void ResetText()
	{
		Text = string.Empty;
	}

	private bool ShouldSerializeExtraText()
	{
		return ExtraText != string.Empty;
	}

	public void ResetExtraText()
	{
		ExtraText = string.Empty;
	}

	private bool ShouldSerializeToolTipImage()
	{
		return ToolTipImage != null;
	}

	public void ResetToolTipImage()
	{
		ToolTipImage = null;
	}

	private bool ShouldSerializeToolTipImageTransparentColor()
	{
		return ToolTipImageTransparentColor != Color.Empty;
	}

	public void ResetToolTipImageTransparentColor()
	{
		ToolTipImageTransparentColor = Color.Empty;
	}

	private bool ShouldSerializeToolTipTitle()
	{
		return ToolTipTitle != string.Empty;
	}

	public void ResetToolTipTitle()
	{
		ToolTipTitle = string.Empty;
	}

	private bool ShouldSerializeToolTipBody()
	{
		return ToolTipBody != string.Empty;
	}

	public void ResetToolTipBody()
	{
		ToolTipBody = string.Empty;
	}

	private bool ShouldSerializeToolTipStyle()
	{
		return ToolTipStyle != LabelStyle.ToolTip;
	}

	public void ResetToolTipStyle()
	{
		ToolTipStyle = LabelStyle.ToolTip;
	}

	public void ResetUniqueName()
	{
		_uniqueName = CommonHelper.UniqueString;
	}

	public void ResetAllowInheritImage()
	{
		AllowInheritImage = true;
	}

	public void ResetAllowInheritText()
	{
		AllowInheritText = true;
	}

	public void ResetAllowInheritExtraText()
	{
		AllowInheritExtraText = true;
	}

	public void ResetAllowInheritToolTipTitle()
	{
		AllowInheritToolTipTitle = true;
	}

	private bool ShouldSerializeColorMap()
	{
		return ColorMap != Color.Empty;
	}

	public void ResetColorMap()
	{
		ColorMap = Color.Empty;
	}

	private bool ShouldSerializeStyle()
	{
		return Style != PaletteButtonStyle.Inherit;
	}

	public void ResetStyle()
	{
		Style = PaletteButtonStyle.Inherit;
	}

	private bool ShouldSerializeOrientation()
	{
		return Orientation != PaletteButtonOrientation.Inherit;
	}

	public void ResetOrientation()
	{
		Orientation = PaletteButtonOrientation.Inherit;
	}

	private bool ShouldSerializeEdge()
	{
		return Edge != PaletteRelativeEdgeAlign.Inherit;
	}

	private void ResetEdge()
	{
		Edge = PaletteRelativeEdgeAlign.Inherit;
	}

	public virtual void CopyFrom(ButtonSpec source)
	{
		Image = source.Image;
		ImageTransparentColor = source.ImageTransparentColor;
		ImageStates.CopyFrom(source.ImageStates);
		Text = source.Text;
		ExtraText = source.ExtraText;
		AllowInheritImage = source.AllowInheritImage;
		AllowInheritText = source.AllowInheritText;
		AllowInheritExtraText = source.AllowInheritExtraText;
		ColorMap = source.ColorMap;
		Style = source.Style;
		Orientation = source.Orientation;
		Edge = source.Edge;
		ProtectedType = source.ProtectedType;
	}

	public void PerformClick()
	{
		PerformClick(EventArgs.Empty);
	}

	public void PerformClick(EventArgs e)
	{
		OnClick(e);
	}

	public virtual Image GetImage(IPalette palette, PaletteState state)
	{
		Image image = null;
		if (KryptonCommand != null)
		{
			return KryptonCommand.ImageSmall;
		}
		switch (state)
		{
		case PaletteState.Disabled:
			image = ImageStates.ImageDisabled;
			break;
		case PaletteState.Normal:
			image = ImageStates.ImageNormal;
			break;
		case PaletteState.Pressed:
			image = ImageStates.ImagePressed;
			break;
		case PaletteState.Tracking:
			image = ImageStates.ImageTracking;
			break;
		case PaletteState.CheckedNormal:
			image = ImageStates.ImageCheckedNormal;
			break;
		case PaletteState.CheckedPressed:
			image = ImageStates.ImageCheckedPressed;
			break;
		case PaletteState.CheckedTracking:
			image = ImageStates.ImageCheckedTracking;
			break;
		}
		if (image == null)
		{
			image = Image;
		}
		if (image != null || !AllowInheritImage)
		{
			return image;
		}
		return palette.GetButtonSpecImage(_type, state);
	}

	public virtual Color GetImageTransparentColor(IPalette palette)
	{
		if (KryptonCommand != null)
		{
			return KryptonCommand.ImageTransparentColor;
		}
		if (ImageTransparentColor != Color.Empty)
		{
			return ImageTransparentColor;
		}
		return palette.GetButtonSpecImageTransparentColor(_type);
	}

	public virtual string GetShortText(IPalette palette)
	{
		if (KryptonCommand != null)
		{
			return KryptonCommand.Text;
		}
		if (Text.Length > 0 || !AllowInheritText)
		{
			return Text;
		}
		return palette.GetButtonSpecShortText(_type);
	}

	public virtual string GetLongText(IPalette palette)
	{
		if (KryptonCommand != null)
		{
			return KryptonCommand.ExtraText;
		}
		if (ExtraText.Length > 0 || !AllowInheritExtraText)
		{
			return ExtraText;
		}
		return palette.GetButtonSpecLongText(_type);
	}

	public virtual string GetToolTipTitle(IPalette palette)
	{
		if (!string.IsNullOrEmpty(ToolTipTitle) || !AllowInheritToolTipTitle)
		{
			return ToolTipTitle;
		}
		return palette.GetButtonSpecToolTipTitle(_type);
	}

	public virtual Color GetColorMap(IPalette palette)
	{
		if (ColorMap != Color.Empty)
		{
			return ColorMap;
		}
		return palette.GetButtonSpecColorMap(_type);
	}

	public virtual ButtonStyle GetStyle(IPalette palette)
	{
		if (Style != PaletteButtonStyle.Inherit)
		{
			return ConvertToButtonStyle(Style);
		}
		return ConvertToButtonStyle(palette.GetButtonSpecStyle(_type));
	}

	public virtual ButtonOrientation GetOrientation(IPalette palette)
	{
		if (Orientation != PaletteButtonOrientation.Inherit)
		{
			return ConvertToButtonOrientation(Orientation);
		}
		return ConvertToButtonOrientation(palette.GetButtonSpecOrientation(_type));
	}

	public virtual RelativeEdgeAlign GetEdge(IPalette palette)
	{
		if (Edge != PaletteRelativeEdgeAlign.Inherit)
		{
			return ConvertToRelativeEdgeAlign(Edge);
		}
		return ConvertToRelativeEdgeAlign(palette.GetButtonSpecEdge(_type));
	}

	public virtual HeaderLocation GetLocation(IPalette palette)
	{
		return HeaderLocation.PrimaryHeader;
	}

	public abstract ButtonEnabled GetEnabled(IPalette palette);

	public virtual void SetView(ViewBase view)
	{
		_buttonSpecView = view;
	}

	public virtual ViewBase GetView()
	{
		return _buttonSpecView;
	}

	public bool GetViewEnabled()
	{
		if (_buttonSpecView == null)
		{
			return false;
		}
		return _buttonSpecView.State != PaletteState.Disabled;
	}

	public abstract bool GetVisible(IPalette palette);

	public abstract ButtonCheckState GetChecked(IPalette palette);

	protected void GenerateClick(EventArgs e)
	{
		if (this.Click != null)
		{
			this.Click(this, e);
		}
		if (KryptonCommand != null)
		{
			KryptonCommand.PerformExecute();
		}
	}

	protected virtual void OnClick(EventArgs e)
	{
		if (GetViewEnabled())
		{
			if (this.Click != null)
			{
				this.Click(this, e);
			}
			if (KryptonCommand != null)
			{
				KryptonCommand.PerformExecute();
			}
		}
	}

	protected virtual void OnButtonSpecPropertyChanged(string propertyName)
	{
		if (this.ButtonSpecPropertyChanged != null)
		{
			this.ButtonSpecPropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	protected virtual void OnCommandPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "Text":
			OnButtonSpecPropertyChanged("Text");
			break;
		case "ExtraText":
			OnButtonSpecPropertyChanged("ExtraText");
			break;
		case "ImageSmall":
			OnButtonSpecPropertyChanged("Image");
			break;
		case "ImageTransparentColor":
			OnButtonSpecPropertyChanged("ImageTransparentColor");
			break;
		}
	}

	protected RelativeEdgeAlign ConvertToRelativeEdgeAlign(PaletteRelativeEdgeAlign paletteRelativeEdgeAlign)
	{
		switch (paletteRelativeEdgeAlign)
		{
		case PaletteRelativeEdgeAlign.Near:
			return RelativeEdgeAlign.Near;
		case PaletteRelativeEdgeAlign.Far:
			return RelativeEdgeAlign.Far;
		default:
			Debug.Assert(condition: false);
			return RelativeEdgeAlign.Far;
		}
	}

	protected ButtonOrientation ConvertToButtonOrientation(PaletteButtonOrientation paletteButtonOrientation)
	{
		switch (paletteButtonOrientation)
		{
		case PaletteButtonOrientation.Auto:
			return ButtonOrientation.Auto;
		case PaletteButtonOrientation.FixedBottom:
			return ButtonOrientation.FixedBottom;
		case PaletteButtonOrientation.FixedLeft:
			return ButtonOrientation.FixedLeft;
		case PaletteButtonOrientation.FixedRight:
			return ButtonOrientation.FixedRight;
		case PaletteButtonOrientation.FixedTop:
			return ButtonOrientation.FixedTop;
		default:
			Debug.Assert(condition: false);
			return ButtonOrientation.Auto;
		}
	}

	protected ButtonStyle ConvertToButtonStyle(PaletteButtonStyle paletteButtonStyle)
	{
		switch (paletteButtonStyle)
		{
		case PaletteButtonStyle.Standalone:
			return ButtonStyle.Standalone;
		case PaletteButtonStyle.Alternate:
			return ButtonStyle.Alternate;
		case PaletteButtonStyle.LowProfile:
			return ButtonStyle.LowProfile;
		case PaletteButtonStyle.ButtonSpec:
			return ButtonStyle.ButtonSpec;
		case PaletteButtonStyle.BreadCrumb:
			return ButtonStyle.BreadCrumb;
		case PaletteButtonStyle.Cluster:
			return ButtonStyle.Cluster;
		case PaletteButtonStyle.NavigatorStack:
			return ButtonStyle.NavigatorStack;
		case PaletteButtonStyle.NavigatorOverflow:
			return ButtonStyle.NavigatorOverflow;
		case PaletteButtonStyle.NavigatorMini:
			return ButtonStyle.NavigatorMini;
		case PaletteButtonStyle.InputControl:
			return ButtonStyle.InputControl;
		case PaletteButtonStyle.ListItem:
			return ButtonStyle.ListItem;
		case PaletteButtonStyle.Form:
			return ButtonStyle.Form;
		case PaletteButtonStyle.FormClose:
			return ButtonStyle.FormClose;
		case PaletteButtonStyle.Command:
			return ButtonStyle.Command;
		case PaletteButtonStyle.Custom1:
			return ButtonStyle.Custom1;
		case PaletteButtonStyle.Custom2:
			return ButtonStyle.Custom2;
		case PaletteButtonStyle.Custom3:
			return ButtonStyle.Custom3;
		default:
			Debug.Assert(condition: false);
			return ButtonStyle.Standalone;
		}
	}

	private void OnImageStateChanged(object sender, NeedLayoutEventArgs e)
	{
		OnButtonSpecPropertyChanged("Image");
	}
}
