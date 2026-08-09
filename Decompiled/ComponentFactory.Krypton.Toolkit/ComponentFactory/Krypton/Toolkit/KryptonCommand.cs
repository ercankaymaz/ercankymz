using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonCommand), "ToolboxBitmaps.KryptonCommand.bmp")]
[DefaultEvent("Click")]
[DefaultProperty("Text")]
[DesignerCategory("code")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonCommandDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[Description("Defines state and events for a single command.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonCommand : Component, IKryptonCommand, INotifyPropertyChanged
{
	private bool _enabled;

	private bool _checked;

	private CheckState _checkState;

	private string _text;

	private string _extraText;

	private string _textLine1;

	private string _textLine2;

	private Image _imageSmall;

	private Image _imageLarge;

	private Color _imageTransparentColor;

	private object _tag;

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Indicates whether the command is enabled.")]
	[DefaultValue(true)]
	public bool Enabled
	{
		get
		{
			return _enabled;
		}
		set
		{
			if (_enabled != value)
			{
				_enabled = value;
				OnPropertyChanged(new PropertyChangedEventArgs("Enabled"));
			}
		}
	}

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Indicates whether the command is in the checked state.")]
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
				_checkState = (_checked ? CheckState.Checked : CheckState.Unchecked);
				OnPropertyChanged(new PropertyChangedEventArgs("Checked"));
				OnPropertyChanged(new PropertyChangedEventArgs("CheckState"));
			}
		}
	}

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Indicates the checked state of the command.")]
	[DefaultValue(typeof(CheckState), "Unchecked")]
	public CheckState CheckState
	{
		get
		{
			return _checkState;
		}
		set
		{
			if (_checkState != value)
			{
				_checkState = value;
				bool flag = _checkState != CheckState.Unchecked;
				bool flag2 = _checked != flag;
				_checked = flag;
				if (flag2)
				{
					OnPropertyChanged(new PropertyChangedEventArgs("Checked"));
				}
				OnPropertyChanged(new PropertyChangedEventArgs("CheckState"));
			}
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Command text.")]
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
				OnPropertyChanged(new PropertyChangedEventArgs("Text"));
			}
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Command extra text.")]
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
				OnPropertyChanged(new PropertyChangedEventArgs("ExtraText"));
			}
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Command text line 1 for use in KryptonRibbon.")]
	public string TextLine1
	{
		get
		{
			return _textLine1;
		}
		set
		{
			if (_textLine1 != value)
			{
				_textLine1 = value;
				OnPropertyChanged(new PropertyChangedEventArgs("TextLine1"));
			}
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Command text line 2 for use in KryptonRibbon.")]
	public string TextLine2
	{
		get
		{
			return _textLine2;
		}
		set
		{
			if (_textLine2 != value)
			{
				_textLine2 = value;
				OnPropertyChanged(new PropertyChangedEventArgs("TextLine2"));
			}
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Command small image.")]
	public Image ImageSmall
	{
		get
		{
			return _imageSmall;
		}
		set
		{
			if (_imageSmall != value)
			{
				_imageSmall = value;
				OnPropertyChanged(new PropertyChangedEventArgs("ImageSmall"));
			}
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Command large image.")]
	public Image ImageLarge
	{
		get
		{
			return _imageLarge;
		}
		set
		{
			if (_imageLarge != value)
			{
				_imageLarge = value;
				OnPropertyChanged(new PropertyChangedEventArgs("ImageLarge"));
			}
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Command image transparent color.")]
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
				OnPropertyChanged(new PropertyChangedEventArgs("ImageTransparentColor"));
			}
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

	[Category("Action")]
	[Description("Occurs when the command needs executing.")]
	public event EventHandler Execute;

	[Category("Property Changed")]
	[Description("Occurs when the value of property has changed.")]
	public event PropertyChangedEventHandler PropertyChanged;

	public KryptonCommand()
	{
		_enabled = true;
		_checked = false;
		_checkState = CheckState.Unchecked;
		_text = string.Empty;
		_extraText = string.Empty;
		_textLine1 = string.Empty;
		_textLine2 = string.Empty;
		_imageSmall = null;
		_imageLarge = null;
		_imageTransparentColor = Color.Empty;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
		}
		base.Dispose(disposing);
	}

	private void ResetText()
	{
		Text = string.Empty;
	}

	private bool ShouldSerializeText()
	{
		return !string.IsNullOrEmpty(Text);
	}

	private void ResetExtraText()
	{
		ExtraText = string.Empty;
	}

	private bool ShouldSerializeExtraText()
	{
		return !string.IsNullOrEmpty(ExtraText);
	}

	private void ResetTextLine1()
	{
		TextLine1 = string.Empty;
	}

	private bool ShouldSerializeTextLine1()
	{
		return !string.IsNullOrEmpty(TextLine1);
	}

	private void ResetTextLine2()
	{
		TextLine2 = string.Empty;
	}

	private bool ShouldSerializeTextLine2()
	{
		return !string.IsNullOrEmpty(TextLine2);
	}

	private void ResetImageSmall()
	{
		ImageSmall = null;
	}

	private bool ShouldSerializeImageSmall()
	{
		return ImageSmall != null;
	}

	private void ResetImageLarge()
	{
		ImageLarge = null;
	}

	private bool ShouldSerializeImageLarge()
	{
		return ImageLarge != null;
	}

	public void PerformExecute()
	{
		OnExecute(EventArgs.Empty);
	}

	protected virtual void OnExecute(EventArgs e)
	{
		if (this.Execute != null)
		{
			this.Execute(this, e);
		}
	}

	protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, e);
		}
	}
}
