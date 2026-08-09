using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonCommand), "ToolboxBitmaps.KryptonTaskDialogCommand.bmp")]
[DefaultEvent("Click")]
[DefaultProperty("Text")]
[DesignerCategory("code")]
[Description("Defines state and events for a single task dialog command.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonTaskDialogCommand : Component, IKryptonCommand, INotifyPropertyChanged
{
	private bool _enabled;

	private string _text;

	private string _extraText;

	private Image _image;

	private Color _imageTransparentColor;

	private DialogResult _dialogResult;

	private object _tag;

	[Bindable(true)]
	[Category("Behavior")]
	[Description("DialogResult to use when the command is pressed.")]
	[DefaultValue(true)]
	public DialogResult DialogResult
	{
		get
		{
			return _dialogResult;
		}
		set
		{
			if (_dialogResult != value)
			{
				_dialogResult = value;
				OnPropertyChanged(new PropertyChangedEventArgs("DialogResult"));
			}
		}
	}

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
	[Description("Command small image.")]
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
				OnPropertyChanged(new PropertyChangedEventArgs("ImageSmall"));
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

	Image IKryptonCommand.ImageSmall
	{
		get
		{
			return Image;
		}
		set
		{
			Image = value;
		}
	}

	Image IKryptonCommand.ImageLarge
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	string IKryptonCommand.TextLine1
	{
		get
		{
			return string.Empty;
		}
		set
		{
		}
	}

	string IKryptonCommand.TextLine2
	{
		get
		{
			return string.Empty;
		}
		set
		{
		}
	}

	bool IKryptonCommand.Checked
	{
		get
		{
			return true;
		}
		set
		{
		}
	}

	CheckState IKryptonCommand.CheckState
	{
		get
		{
			return CheckState.Unchecked;
		}
		set
		{
		}
	}

	[Category("Action")]
	[Description("Occurs when the command needs executing.")]
	public event EventHandler Execute;

	[Category("Property Changed")]
	[Description("Occurs when the value of property has changed.")]
	public event PropertyChangedEventHandler PropertyChanged;

	public KryptonTaskDialogCommand()
	{
		_enabled = true;
		_text = string.Empty;
		_extraText = string.Empty;
		_image = null;
		_imageTransparentColor = Color.Empty;
		_dialogResult = DialogResult.OK;
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

	private void ResetImage()
	{
		Image = null;
	}

	private bool ShouldSerializeImage()
	{
		return Image != null;
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
