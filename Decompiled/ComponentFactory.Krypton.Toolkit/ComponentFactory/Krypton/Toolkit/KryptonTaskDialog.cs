using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonTaskDialog), "ToolboxBitmaps.KryptonTaskDialog.bmp")]
[DefaultEvent("PropertyChanged")]
[DesignerCategory("code")]
[Description("Displays a task dialog for presenting different options to the user.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonTaskDialog : Component, INotifyPropertyChanged
{
	private VisualTaskDialog _taskDialog;

	private string _windowTitle;

	private string _mainInstruction;

	private string _content;

	private Image _customIcon;

	private MessageBoxIcon _icon;

	private KryptonTaskDialogCommandCollection _radioButtons;

	private KryptonTaskDialogCommandCollection _commandButtons;

	private KryptonTaskDialogCommand _defaultRadioButton;

	private TaskDialogButtons _commonButtons;

	private TaskDialogButtons _defaultButton;

	private MessageBoxIcon _footerIcon;

	private Image _customFooterIcon;

	private string _footerText;

	private string _footerHyperlink;

	private string _checkboxText;

	private bool _checkboxState;

	private bool _allowDialogClose;

	private object _tag;

	[Category("Appearance")]
	[Description("Caption of the window.")]
	[DefaultValue("")]
	[Localizable(true)]
	[Bindable(true)]
	public string WindowTitle
	{
		get
		{
			return _windowTitle;
		}
		set
		{
			if (_windowTitle != value)
			{
				_windowTitle = value;
				OnPropertyChanged(new PropertyChangedEventArgs("WindowTitle"));
			}
		}
	}

	[Category("Appearance")]
	[Description("Principal text.")]
	[DefaultValue("")]
	[Localizable(true)]
	[Bindable(true)]
	public string MainInstruction
	{
		get
		{
			return _mainInstruction;
		}
		set
		{
			if (_mainInstruction != value)
			{
				_mainInstruction = value;
				OnPropertyChanged(new PropertyChangedEventArgs("MainInstruction"));
			}
		}
	}

	[Category("Appearance")]
	[Description("Extra text.")]
	[DefaultValue("")]
	[Localizable(true)]
	[Bindable(true)]
	public string Content
	{
		get
		{
			return _content;
		}
		set
		{
			if (_content != value)
			{
				_content = value;
				OnPropertyChanged(new PropertyChangedEventArgs("Content"));
			}
		}
	}

	[Category("Appearance")]
	[Description("Predefined icon.")]
	[DefaultValue(typeof(MessageBoxIcon), "None")]
	public MessageBoxIcon Icon
	{
		get
		{
			return _icon;
		}
		set
		{
			if (_icon != value)
			{
				_icon = value;
				OnPropertyChanged(new PropertyChangedEventArgs("Icon"));
			}
		}
	}

	[Category("Appearance")]
	[Description("Custom icon.")]
	[DefaultValue(null)]
	public Image CustomIcon
	{
		get
		{
			return _customIcon;
		}
		set
		{
			if (_customIcon != value)
			{
				_customIcon = value;
				OnPropertyChanged(new PropertyChangedEventArgs("CustomIcon"));
			}
		}
	}

	[Category("Appearance")]
	[Description("Collection of radio button definitions.")]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[RefreshProperties(RefreshProperties.All)]
	[Browsable(true)]
	public KryptonTaskDialogCommandCollection RadioButtons => _radioButtons;

	[Category("Appearance")]
	[Description("Collection of command button definitions.")]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[RefreshProperties(RefreshProperties.All)]
	[Browsable(true)]
	public KryptonTaskDialogCommandCollection CommandButtons => _commandButtons;

	[Category("Appearance")]
	[Description("Common dialog buttons.")]
	[DefaultValue(typeof(TaskDialogButtons), "OK")]
	public TaskDialogButtons CommonButtons
	{
		get
		{
			return _commonButtons;
		}
		set
		{
			if (_commonButtons != value)
			{
				_commonButtons = value;
				OnPropertyChanged(new PropertyChangedEventArgs("CommonButtons"));
			}
		}
	}

	[Category("Appearance")]
	[Description("Default radio button.")]
	[DefaultValue(typeof(TaskDialogButtons), "None")]
	public KryptonTaskDialogCommand DefaultRadioButton
	{
		get
		{
			return _defaultRadioButton;
		}
		set
		{
			if (_defaultRadioButton != value)
			{
				_defaultRadioButton = value;
				OnPropertyChanged(new PropertyChangedEventArgs("DefaultRadioButton"));
			}
		}
	}

	[Category("Appearance")]
	[Description("Default Common button.")]
	[DefaultValue(typeof(TaskDialogButtons), "None")]
	public TaskDialogButtons DefaultButton
	{
		get
		{
			return _defaultButton;
		}
		set
		{
			if (_defaultButton != value)
			{
				_defaultButton = value;
				OnPropertyChanged(new PropertyChangedEventArgs("DefaultButton"));
			}
		}
	}

	[Category("Appearance")]
	[Description("Predefined footer icon.")]
	[DefaultValue(typeof(MessageBoxIcon), "None")]
	public MessageBoxIcon FooterIcon
	{
		get
		{
			return _footerIcon;
		}
		set
		{
			if (_footerIcon != value)
			{
				_footerIcon = value;
				OnPropertyChanged(new PropertyChangedEventArgs("FooterIcon"));
			}
		}
	}

	[Category("Appearance")]
	[Description("Custom footer icon.")]
	[DefaultValue(null)]
	public Image CustomFooterIcon
	{
		get
		{
			return _customFooterIcon;
		}
		set
		{
			if (_customFooterIcon != value)
			{
				_customFooterIcon = value;
				OnPropertyChanged(new PropertyChangedEventArgs("CustomFooterIcon"));
			}
		}
	}

	[Category("Appearance")]
	[Description("Footer text.")]
	[DefaultValue("")]
	[Localizable(true)]
	[Bindable(true)]
	public string FooterText
	{
		get
		{
			return _footerText;
		}
		set
		{
			if (_footerText != value)
			{
				_footerText = value;
				OnPropertyChanged(new PropertyChangedEventArgs("FooterText"));
			}
		}
	}

	[Category("Appearance")]
	[Description("Footer hyperlink.")]
	[DefaultValue("")]
	[Localizable(true)]
	[Bindable(true)]
	public string FooterHyperlink
	{
		get
		{
			return _footerHyperlink;
		}
		set
		{
			if (_footerHyperlink != value)
			{
				_footerHyperlink = value;
				OnPropertyChanged(new PropertyChangedEventArgs("FooterHyperlink"));
			}
		}
	}

	[Category("Appearance")]
	[Description("Checkbox text.")]
	[DefaultValue("")]
	[Localizable(true)]
	[Bindable(true)]
	public string CheckboxText
	{
		get
		{
			return _checkboxText;
		}
		set
		{
			if (_checkboxText != value)
			{
				_checkboxText = value;
				OnPropertyChanged(new PropertyChangedEventArgs("CheckboxText"));
			}
		}
	}

	[Category("Appearance")]
	[Description("Checkbox state.")]
	[DefaultValue(false)]
	[Localizable(true)]
	[Bindable(true)]
	public bool CheckboxState
	{
		get
		{
			return _checkboxState;
		}
		set
		{
			if (_checkboxState != value)
			{
				_checkboxState = value;
				OnPropertyChanged(new PropertyChangedEventArgs("CheckboxState"));
			}
		}
	}

	[Category("Appearance")]
	[Description("Can the user close the window.")]
	[DefaultValue(false)]
	public bool AllowDialogClose
	{
		get
		{
			return _allowDialogClose;
		}
		set
		{
			if (_allowDialogClose != value)
			{
				_allowDialogClose = value;
				OnPropertyChanged(new PropertyChangedEventArgs("AllowDialogClose"));
			}
		}
	}

	[Category("Data")]
	[Description("User-defined data associated with the object.")]
	[TypeConverter(typeof(StringConverter))]
	[Bindable(true)]
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
	[Description("Occurs when the users clicks the footer hyperlink.")]
	public event EventHandler FooterHyperlinkClicked;

	[Category("Property Changed")]
	[Description("Occurs when the value of property has changed.")]
	public event PropertyChangedEventHandler PropertyChanged;

	public KryptonTaskDialog()
	{
		_radioButtons = new KryptonTaskDialogCommandCollection();
		_commandButtons = new KryptonTaskDialogCommandCollection();
		_commonButtons = TaskDialogButtons.OK;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _taskDialog != null)
		{
			_taskDialog.Dispose();
			_taskDialog = null;
		}
		base.Dispose(disposing);
	}

	private void ResetTag()
	{
		Tag = null;
	}

	private bool ShouldSerializeTag()
	{
		return Tag != null;
	}

	public DialogResult ShowDialog()
	{
		return ShowDialog(Control.FromHandle(PI.GetActiveWindow()));
	}

	public DialogResult ShowDialog(IWin32Window owner)
	{
		if (_taskDialog != null)
		{
			_taskDialog.Dispose();
		}
		_taskDialog = new VisualTaskDialog(this);
		if (owner == null)
		{
			_taskDialog.StartPosition = FormStartPosition.CenterScreen;
		}
		else
		{
			_taskDialog.StartPosition = FormStartPosition.CenterParent;
		}
		return _taskDialog.ShowDialog(owner);
	}

	public static DialogResult Show(string windowTitle, string mainInstruction, string content, MessageBoxIcon icon, TaskDialogButtons commonButtons)
	{
		using KryptonTaskDialog kryptonTaskDialog = new KryptonTaskDialog();
		kryptonTaskDialog.WindowTitle = windowTitle;
		kryptonTaskDialog.MainInstruction = mainInstruction;
		kryptonTaskDialog.Content = content;
		kryptonTaskDialog.Icon = icon;
		kryptonTaskDialog.CommonButtons = commonButtons;
		return kryptonTaskDialog.ShowDialog();
	}

	protected virtual void OnFooterHyperlinkClicked(EventArgs e)
	{
		if (this.FooterHyperlinkClicked != null)
		{
			this.FooterHyperlinkClicked(this, e);
		}
	}

	protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, e);
		}
	}

	internal void RaiseFooterHyperlinkClicked()
	{
		OnFooterHyperlinkClicked(EventArgs.Empty);
	}
}
