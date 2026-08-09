using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonRibbonGroupRadioButton), "ToolboxBitmaps.KryptonRibbonGroupRadioButton.bmp")]
[Designer("ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupRadioButtonDesigner, ComponentFactory.Krypton.Ribbon, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
[DefaultEvent("CheckedChanged")]
[DefaultProperty("Checked")]
public class KryptonRibbonGroupRadioButton : KryptonRibbonGroupItem
{
	private bool _enabled;

	private bool _visible;

	private bool _checked;

	private bool _autoCheck;

	private Image _toolTipImage;

	private Color _toolTipImageTransparentColor;

	private LabelStyle _toolTipStyle;

	private string _textLine1;

	private string _textLine2;

	private string _keyTip;

	private string _toolTipTitle;

	private string _toolTipBody;

	private Keys _shortcutKeys;

	private ViewBase _radioButtonView;

	private GroupItemSize _itemSizeMax;

	private GroupItemSize _itemSizeMin;

	private GroupItemSize _itemSizeCurrent;

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Radio button display text line 1.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue("RadioButton")]
	public string TextLine1
	{
		get
		{
			return _textLine1;
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				value = "RadioButton";
			}
			if (value != _textLine1)
			{
				_textLine1 = value;
				OnPropertyChanged("TextLine1");
			}
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Radio button display text line 2.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue("")]
	public string TextLine2
	{
		get
		{
			return _textLine2;
		}
		set
		{
			if (value != _textLine2)
			{
				_textLine2 = value;
				OnPropertyChanged("TextLine2");
			}
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Ribbon group radio button key tip.")]
	[DefaultValue("R")]
	public string KeyTip
	{
		get
		{
			return _keyTip;
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				value = "R";
			}
			_keyTip = value.ToUpper();
		}
	}

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Determines whether the radio button is visible or hidden.")]
	[DefaultValue(true)]
	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public override bool Visible
	{
		get
		{
			return _visible;
		}
		set
		{
			if (value != _visible)
			{
				_visible = value;
				OnPropertyChanged("Visible");
			}
		}
	}

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Determines whether the group radio button is enabled.")]
	[DefaultValue(true)]
	public bool Enabled
	{
		get
		{
			return _enabled;
		}
		set
		{
			if (value != _enabled)
			{
				_enabled = value;
				OnPropertyChanged("Enabled");
			}
		}
	}

	[Category("Behavior")]
	[Description("Indicates if the radio button is in the checked state.")]
	[DefaultValue(false)]
	public bool Checked
	{
		get
		{
			return _checked;
		}
		set
		{
			if (_checked != value)
			{
				_checked = value;
				OnPropertyChanged("Checked");
				if (_checked)
				{
					AutoUpdateOthers();
				}
				OnCheckedChanged(EventArgs.Empty);
			}
		}
	}

	[Category("Behavior")]
	[Description("Indicates if checking this radio button should uncheck others in the same group.")]
	[DefaultValue(true)]
	public bool AutoCheck
	{
		get
		{
			return _autoCheck;
		}
		set
		{
			if (_autoCheck != value)
			{
				_autoCheck = value;
				if (_checked)
				{
					AutoUpdateOthers();
				}
			}
		}
	}

	[Localizable(true)]
	[Category("Behavior")]
	[Description("Shortcut key combination to fire click event of the radio button.")]
	public Keys ShortcutKeys
	{
		get
		{
			return _shortcutKeys;
		}
		set
		{
			_shortcutKeys = value;
		}
	}

	[Category("Appearance")]
	[Description("Tooltip style for the group radio button.")]
	[DefaultValue(typeof(LabelStyle), "SuperTip")]
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

	[Bindable(true)]
	[Category("Appearance")]
	[Description("Display image associated ToolTip.")]
	[DefaultValue(null)]
	[Localizable(true)]
	public Image ToolTipImage
	{
		get
		{
			return _toolTipImage;
		}
		set
		{
			_toolTipImage = value;
		}
	}

	[Bindable(true)]
	[Category("Appearance")]
	[Description("Color to draw as transparent in the ToolTipImage.")]
	[KryptonDefaultColor]
	[Localizable(true)]
	public Color ToolTipImageTransparentColor
	{
		get
		{
			return _toolTipImageTransparentColor;
		}
		set
		{
			_toolTipImageTransparentColor = value;
		}
	}

	[Bindable(true)]
	[Category("Appearance")]
	[Description("Title text for use in associated ToolTip.")]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DefaultValue("")]
	[Localizable(true)]
	public string ToolTipTitle
	{
		get
		{
			return _toolTipTitle;
		}
		set
		{
			_toolTipTitle = value;
		}
	}

	[Bindable(true)]
	[Category("Appearance")]
	[Description("Body text for use in associated ToolTip.")]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DefaultValue("")]
	[Localizable(true)]
	public string ToolTipBody
	{
		get
		{
			return _toolTipBody;
		}
		set
		{
			_toolTipBody = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override GroupItemSize ItemSizeMaximum
	{
		get
		{
			return _itemSizeMax;
		}
		set
		{
			if (_itemSizeMax != value)
			{
				_itemSizeMax = value;
				OnPropertyChanged("ItemSizeMaximum");
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override GroupItemSize ItemSizeMinimum
	{
		get
		{
			return _itemSizeMin;
		}
		set
		{
			if (_itemSizeMin != value)
			{
				_itemSizeMin = value;
				OnPropertyChanged("ItemSizeMinimum");
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override GroupItemSize ItemSizeCurrent
	{
		get
		{
			return _itemSizeCurrent;
		}
		set
		{
			if (_itemSizeCurrent != value)
			{
				_itemSizeCurrent = value;
				OnPropertyChanged("ItemSizeCurrent");
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public ViewBase RadioButtonView
	{
		get
		{
			return _radioButtonView;
		}
		set
		{
			_radioButtonView = value;
		}
	}

	internal override LabelStyle InternalToolTipStyle => ToolTipStyle;

	internal override Image InternalToolTipImage => ToolTipImage;

	internal override Color InternalToolTipImageTransparentColor => ToolTipImageTransparentColor;

	internal override string InternalToolTipTitle => ToolTipTitle;

	internal override string InternalToolTipBody => ToolTipBody;

	[Category("Ribbon")]
	[Description("Occurs when the radio button is clicked.")]
	public event EventHandler Click;

	[Category("Ribbon")]
	[Description("Occurs whenever the Checked property has changed.")]
	public event EventHandler CheckedChanged;

	[Category("Ribbon")]
	[Description("Occurs after the value of a property has changed.")]
	public event PropertyChangedEventHandler PropertyChanged;

	[Category("Design Time")]
	[Description("Occurs when the design time context menu is requested.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event MouseEventHandler DesignTimeContextMenu;

	public KryptonRibbonGroupRadioButton()
	{
		_enabled = true;
		_visible = true;
		_checked = false;
		_autoCheck = true;
		_shortcutKeys = Keys.None;
		_textLine1 = "RadioButton";
		_textLine2 = string.Empty;
		_keyTip = "R";
		_itemSizeMax = GroupItemSize.Large;
		_itemSizeMin = GroupItemSize.Small;
		_itemSizeCurrent = GroupItemSize.Large;
		_toolTipImageTransparentColor = Color.Empty;
		_toolTipTitle = string.Empty;
		_toolTipBody = string.Empty;
		_toolTipStyle = LabelStyle.SuperTip;
	}

	public void Show()
	{
		Visible = true;
	}

	public void Hide()
	{
		Visible = false;
	}

	private bool ShouldSerializeShortcutKeys()
	{
		return ShortcutKeys != Keys.None;
	}

	public void ResetShortcutKeys()
	{
		ShortcutKeys = Keys.None;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override ViewBase CreateView(KryptonRibbon ribbon, NeedPaintHandler needPaint)
	{
		return new ViewDrawRibbonGroupRadioButton(ribbon, this, needPaint);
	}

	public void PerformClick()
	{
		PerformClick(null);
	}

	public void PerformClick(EventHandler finishDelegate)
	{
		OnClick(finishDelegate);
	}

	protected virtual void OnClick(EventHandler finishDelegate)
	{
		bool flag = true;
		if (!Ribbon.InDesignMode && Enabled)
		{
			if (!Checked)
			{
				Checked = true;
			}
			if (VisualPopupManager.Singleton.CurrentPopup != null)
			{
				if (flag)
				{
					finishDelegate?.Invoke(this, EventArgs.Empty);
				}
				flag = false;
			}
			if (this.Click != null)
			{
				this.Click(this, EventArgs.Empty);
			}
		}
		if (flag)
		{
			finishDelegate?.Invoke(this, EventArgs.Empty);
		}
	}

	protected virtual void OnCheckedChanged(EventArgs e)
	{
		if (this.CheckedChanged != null)
		{
			this.CheckedChanged(this, e);
		}
	}

	protected virtual void OnPropertyChanged(string propertyName)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	internal void OnDesignTimeContextMenu(MouseEventArgs e)
	{
		if (this.DesignTimeContextMenu != null)
		{
			this.DesignTimeContextMenu(this, e);
		}
	}

	internal override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		if (Enabled && base.ChainVisible && ShortcutKeys != Keys.None && ShortcutKeys == keyData)
		{
			PerformClick();
			return true;
		}
		return false;
	}

	private void AutoUpdateOthers()
	{
		if (!AutoCheck || !Checked || RibbonContainer == null || RibbonContainer.RibbonGroup == null)
		{
			return;
		}
		foreach (KryptonRibbonGroupContainer item in RibbonContainer.RibbonGroup.Items)
		{
			AutoUpdateContainer(item);
		}
	}

	private void AutoUpdateContainer(IRibbonGroupContainer Container)
	{
		Component[] childComponents = Container.GetChildComponents();
		foreach (Component component in childComponents)
		{
			if (component is IRibbonGroupContainer)
			{
				AutoUpdateContainer(component as IRibbonGroupContainer);
			}
			else if (component is KryptonRibbonGroupRadioButton)
			{
				KryptonRibbonGroupRadioButton kryptonRibbonGroupRadioButton = (KryptonRibbonGroupRadioButton)component;
				if (kryptonRibbonGroupRadioButton != this && kryptonRibbonGroupRadioButton.AutoCheck && kryptonRibbonGroupRadioButton.Checked)
				{
					kryptonRibbonGroupRadioButton.Checked = false;
				}
			}
		}
	}
}
