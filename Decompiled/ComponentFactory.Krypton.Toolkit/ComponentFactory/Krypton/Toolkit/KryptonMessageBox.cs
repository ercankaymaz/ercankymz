using System;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit.Properties;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonMessageBox), "ToolboxBitmaps.KryptonMessageBox.bmp")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
public class KryptonMessageBox : KryptonForm
{
	internal class HelpInfo
	{
		private string _helpFilePath;

		private string _keyword;

		private HelpNavigator _navigator;

		private object _param;

		public string HelpFilePath => _helpFilePath;

		public string Keyword => _keyword;

		public HelpNavigator Navigator => _navigator;

		public object Param => _param;

		public HelpInfo()
		{
		}

		public HelpInfo(string helpFilePath)
		{
			_helpFilePath = helpFilePath;
		}

		public HelpInfo(string helpFilePath, string keyword)
		{
			_helpFilePath = helpFilePath;
			_keyword = keyword;
		}

		public HelpInfo(string helpFilePath, HelpNavigator navigator)
		{
			_helpFilePath = helpFilePath;
			_navigator = navigator;
		}

		public HelpInfo(string helpFilePath, HelpNavigator navigator, object param)
		{
			_helpFilePath = helpFilePath;
			_navigator = navigator;
			_param = param;
		}
	}

	[ToolboxItem(false)]
	internal class MessageButton : KryptonButton
	{
		private bool _ignoreAltF4;

		public bool IgnoreAltF4
		{
			get
			{
				return _ignoreAltF4;
			}
			set
			{
				_ignoreAltF4 = value;
			}
		}

		protected override void WndProc(ref Message m)
		{
			int msg = m.Msg;
			int num = msg;
			if ((num == 256 || num == 260) && IgnoreAltF4)
			{
				Keys keys = (Keys)m.WParam.ToInt64();
				if (keys == Keys.F4 && (Control.ModifierKeys & Keys.Alt) == Keys.Alt)
				{
					return;
				}
			}
			base.WndProc(ref m);
		}
	}

	private static readonly int GAP;

	private static int _osMajorVersion;

	private string _text;

	private string _caption;

	private MessageBoxButtons _buttons;

	private MessageBoxIcon _icon;

	private MessageBoxDefaultButton _defaultButton;

	private MessageBoxOptions _options;

	private KryptonPanel _panelMessage;

	private KryptonPanel _panelMessageText;

	private KryptonWrapLabel _messageText;

	private KryptonPanel _panelMessageIcon;

	private PictureBox _messageIcon;

	private KryptonPanel _panelButtons;

	private MessageButton _button1;

	private MessageButton _button2;

	private MessageButton _button3;

	private KryptonBorderEdge borderEdge;

	private HelpInfo _helpInfo;

	static KryptonMessageBox()
	{
		GAP = 10;
		_osMajorVersion = Environment.OSVersion.Version.Major;
	}

	private KryptonMessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, HelpInfo helpInfo)
	{
		_text = text;
		_caption = caption;
		_buttons = buttons;
		_icon = icon;
		_defaultButton = defaultButton;
		_options = options;
		_helpInfo = helpInfo;
		InitializeComponent();
		UpdateText();
		UpdateIcon();
		UpdateButtons();
		UpdateDefault();
		UpdateHelp();
		UpdateSizing();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
		}
		base.Dispose(disposing);
	}

	public static DialogResult Show(string text)
	{
		return InternalShow(null, text, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, null);
	}

	public static DialogResult Show(IWin32Window owner, string text)
	{
		return InternalShow(owner, text, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, null);
	}

	public static DialogResult Show(string text, string caption)
	{
		return InternalShow(null, text, caption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, null);
	}

	public static DialogResult Show(IWin32Window owner, string text, string caption)
	{
		return InternalShow(owner, text, caption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, null);
	}

	public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
	{
		return InternalShow(null, text, caption, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, null);
	}

	public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons)
	{
		return InternalShow(owner, text, caption, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, null);
	}

	public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
	{
		return InternalShow(null, text, caption, buttons, icon, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, null);
	}

	public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
	{
		return InternalShow(owner, text, caption, buttons, icon, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0, null);
	}

	public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
	{
		return InternalShow(null, text, caption, buttons, icon, defaultButton, (MessageBoxOptions)0, null);
	}

	public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
	{
		return InternalShow(owner, text, caption, buttons, icon, defaultButton, (MessageBoxOptions)0, null);
	}

	public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options)
	{
		return InternalShow(null, text, caption, buttons, icon, defaultButton, options, null);
	}

	public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options)
	{
		return InternalShow(owner, text, caption, buttons, icon, defaultButton, options, null);
	}

	public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, bool displayHelpButton)
	{
		return InternalShow(null, text, caption, buttons, icon, defaultButton, options, displayHelpButton ? new HelpInfo() : null);
	}

	public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath)
	{
		return InternalShow(null, text, caption, buttons, icon, defaultButton, options, new HelpInfo(helpFilePath));
	}

	public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath)
	{
		return InternalShow(owner, text, caption, buttons, icon, defaultButton, options, new HelpInfo(helpFilePath));
	}

	public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, HelpNavigator navigator)
	{
		return InternalShow(null, text, caption, buttons, icon, defaultButton, options, new HelpInfo(helpFilePath, navigator));
	}

	public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, string keyword)
	{
		return InternalShow(null, text, caption, buttons, icon, defaultButton, options, new HelpInfo(helpFilePath, keyword));
	}

	public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, HelpNavigator navigator)
	{
		return InternalShow(owner, text, caption, buttons, icon, defaultButton, options, new HelpInfo(helpFilePath, navigator));
	}

	public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, string keyword)
	{
		return InternalShow(owner, text, caption, buttons, icon, defaultButton, options, new HelpInfo(helpFilePath, keyword));
	}

	public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, HelpNavigator navigator, object param)
	{
		return InternalShow(null, text, caption, buttons, icon, defaultButton, options, new HelpInfo(helpFilePath, navigator, param));
	}

	public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, HelpNavigator navigator, object param)
	{
		return InternalShow(owner, text, caption, buttons, icon, defaultButton, options, new HelpInfo(helpFilePath, navigator, param));
	}

	private static DialogResult InternalShow(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, HelpInfo helpInfo)
	{
		if (!SystemInformation.UserInteractive && (options & (MessageBoxOptions.ServiceNotification | MessageBoxOptions.DefaultDesktopOnly)) == 0)
		{
			throw new InvalidOperationException("Cannot show modal dialog when non-interactive");
		}
		if (owner != null && (options & (MessageBoxOptions.ServiceNotification | MessageBoxOptions.DefaultDesktopOnly)) != 0)
		{
			throw new ArgumentException("Cannot show message box from a service with an owner specified", "options");
		}
		if (helpInfo != null && (options & (MessageBoxOptions.ServiceNotification | MessageBoxOptions.DefaultDesktopOnly)) != 0)
		{
			throw new ArgumentException("Cannot show message box from a service with help specified", "options");
		}
		IWin32Window win32Window = null;
		if (helpInfo != null || (options & (MessageBoxOptions.ServiceNotification | MessageBoxOptions.DefaultDesktopOnly)) == 0)
		{
			win32Window = ((owner != null) ? owner : Control.FromHandle(PI.GetActiveWindow()));
		}
		using KryptonMessageBox kryptonMessageBox = new KryptonMessageBox(text, caption, buttons, icon, defaultButton, options, helpInfo);
		if (win32Window == null)
		{
			kryptonMessageBox.StartPosition = FormStartPosition.CenterScreen;
		}
		else
		{
			kryptonMessageBox.StartPosition = FormStartPosition.CenterParent;
		}
		return kryptonMessageBox.ShowDialog(win32Window);
	}

	private void UpdateText()
	{
		Text = _caption;
		_messageText.Text = _text;
	}

	private void UpdateIcon()
	{
		switch (_icon)
		{
		case MessageBoxIcon.None:
			_panelMessageIcon.Visible = false;
			_panelMessageText.Left -= _messageIcon.Right;
			if (_osMajorVersion < 6)
			{
				SystemSounds.Beep.Play();
			}
			break;
		case MessageBoxIcon.Question:
			_messageIcon.Image = Resources.help2;
			SystemSounds.Question.Play();
			break;
		case MessageBoxIcon.Asterisk:
			_messageIcon.Image = Resources.information;
			SystemSounds.Asterisk.Play();
			break;
		case MessageBoxIcon.Exclamation:
			_messageIcon.Image = Resources.sign_warning;
			SystemSounds.Exclamation.Play();
			break;
		case MessageBoxIcon.Hand:
			_messageIcon.Image = Resources.error;
			SystemSounds.Hand.Play();
			break;
		}
	}

	private void UpdateButtons()
	{
		switch (_buttons)
		{
		case MessageBoxButtons.OK:
		{
			_button1.Text = KryptonManager.Strings.OK;
			_button1.DialogResult = DialogResult.OK;
			MessageButton button = _button2;
			bool visible = (_button3.Visible = false);
			button.Visible = visible;
			break;
		}
		case MessageBoxButtons.OKCancel:
			_button1.Text = KryptonManager.Strings.OK;
			_button2.Text = KryptonManager.Strings.Cancel;
			_button1.DialogResult = DialogResult.OK;
			_button2.DialogResult = DialogResult.Cancel;
			_button3.Visible = false;
			break;
		case MessageBoxButtons.YesNo:
			_button1.Text = KryptonManager.Strings.Yes;
			_button2.Text = KryptonManager.Strings.No;
			_button1.DialogResult = DialogResult.Yes;
			_button2.DialogResult = DialogResult.No;
			_button3.Visible = false;
			base.ControlBox = false;
			break;
		case MessageBoxButtons.YesNoCancel:
			_button1.Text = KryptonManager.Strings.Yes;
			_button2.Text = KryptonManager.Strings.No;
			_button3.Text = KryptonManager.Strings.Cancel;
			_button1.DialogResult = DialogResult.Yes;
			_button2.DialogResult = DialogResult.No;
			_button3.DialogResult = DialogResult.Cancel;
			break;
		case MessageBoxButtons.RetryCancel:
			_button1.Text = KryptonManager.Strings.Retry;
			_button2.Text = KryptonManager.Strings.Cancel;
			_button1.DialogResult = DialogResult.Retry;
			_button2.DialogResult = DialogResult.Cancel;
			_button3.Visible = false;
			break;
		case MessageBoxButtons.AbortRetryIgnore:
			_button1.Text = KryptonManager.Strings.Abort;
			_button2.Text = KryptonManager.Strings.Retry;
			_button3.Text = KryptonManager.Strings.Ignore;
			_button1.DialogResult = DialogResult.Abort;
			_button2.DialogResult = DialogResult.Retry;
			_button3.DialogResult = DialogResult.Ignore;
			base.ControlBox = false;
			break;
		}
		if (!base.ControlBox)
		{
			_button1.IgnoreAltF4 = true;
			_button2.IgnoreAltF4 = true;
			_button3.IgnoreAltF4 = true;
		}
	}

	private void UpdateDefault()
	{
		switch (_defaultButton)
		{
		case MessageBoxDefaultButton.Button2:
			_button2.Select();
			break;
		case MessageBoxDefaultButton.Button3:
			_button3.Select();
			break;
		}
	}

	private void UpdateHelp()
	{
	}

	private void UpdateSizing()
	{
		Size size = UpdateMessageSizing();
		Size size2 = UpdateButtonsSizing();
		base.ClientSize = new Size(Math.Max(size.Width, size2.Width), size.Height + size2.Height);
	}

	private Size UpdateMessageSizing()
	{
		using (Graphics graphics = CreateGraphics())
		{
			_messageText.UpdateFont();
			Size size = graphics.MeasureString(_text, _messageText.Font, 400).ToSize();
			float num = ((graphics.DpiX > 96f) ? (1f * graphics.DpiX / 96f) : 1f);
			float num2 = ((graphics.DpiY > 96f) ? (1f * graphics.DpiY / 96f) : 1f);
			size.Width = (int)((float)size.Width * num);
			size.Height = (int)((float)size.Height * num2);
			size.Width += 5;
			_messageText.Size = size;
		}
		Padding padding = _panelMessageText.Padding;
		_panelMessageText.Width = _messageText.Size.Width + padding.Horizontal;
		_panelMessageText.Height = _messageText.Size.Height + padding.Vertical;
		Size size2 = _panelMessageText.Size;
		if (_messageIcon.Image != null)
		{
			size2.Width += _panelMessageIcon.Width;
			size2.Height = Math.Max(size2.Height, _panelMessageIcon.Height);
		}
		size2 = new Size(Math.Max(_panelMessage.Size.Width, size2.Width), Math.Max(_panelMessage.Size.Height, size2.Height));
		_panelMessage.Size = size2;
		return size2;
	}

	private Size UpdateButtonsSizing()
	{
		int num = 1;
		Size preferredSize = _button1.GetPreferredSize(Size.Empty);
		Size size = new Size(preferredSize.Width + GAP, preferredSize.Height);
		MessageBoxButtons buttons = _buttons;
		MessageBoxButtons messageBoxButtons = buttons;
		if ((uint)(messageBoxButtons - 1) <= 4u)
		{
			num++;
			Size preferredSize2 = _button2.GetPreferredSize(Size.Empty);
			size.Width = Math.Max(size.Width, preferredSize2.Width + GAP);
			size.Height = Math.Max(size.Height, preferredSize2.Height);
		}
		MessageBoxButtons buttons2 = _buttons;
		MessageBoxButtons messageBoxButtons2 = buttons2;
		if ((uint)(messageBoxButtons2 - 2) <= 1u)
		{
			num++;
			Size preferredSize3 = _button2.GetPreferredSize(Size.Empty);
			size.Width = Math.Max(size.Width, preferredSize3.Width + GAP);
			size.Height = Math.Max(size.Height, preferredSize3.Height);
		}
		int num2 = _panelButtons.Right - GAP;
		MessageBoxButtons buttons3 = _buttons;
		MessageBoxButtons messageBoxButtons3 = buttons3;
		if ((uint)(messageBoxButtons3 - 2) <= 1u)
		{
			_button3.Location = new Point(num2 - size.Width, GAP);
			_button3.Size = size;
			num2 -= size.Width + GAP;
		}
		MessageBoxButtons buttons4 = _buttons;
		MessageBoxButtons messageBoxButtons4 = buttons4;
		if ((uint)(messageBoxButtons4 - 1) <= 4u)
		{
			_button2.Location = new Point(num2 - size.Width, GAP);
			_button2.Size = size;
			num2 -= size.Width + GAP;
		}
		_button1.Location = new Point(num2 - size.Width, GAP);
		_button1.Size = size;
		_panelButtons.Size = new Size(size.Width * num + GAP * (num + 1), size.Height + GAP * 2);
		return new Size(size.Width * num + GAP * (num + 1), size.Height + GAP * 2);
	}

	private void button_keyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.ControlBox)
		{
			Close();
		}
		else
		{
			if (e.Modifiers != Keys.Control || e.KeyCode != Keys.C)
			{
				return;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("---------------------------");
			stringBuilder.AppendLine(_caption);
			stringBuilder.AppendLine("---------------------------");
			stringBuilder.AppendLine(_text);
			stringBuilder.AppendLine("---------------------------");
			stringBuilder.Append(_button1.Text);
			stringBuilder.Append("   ");
			if (_button2.Visible)
			{
				stringBuilder.Append(_button2.Text);
				stringBuilder.Append("   ");
				if (_button3.Visible)
				{
					stringBuilder.Append(_button3.Text);
					stringBuilder.Append("   ");
				}
			}
			stringBuilder.AppendLine("");
			stringBuilder.AppendLine("---------------------------");
			Clipboard.SetText(stringBuilder.ToString(), TextDataFormat.Text);
		}
	}

	private void InitializeComponent()
	{
		this._panelMessage = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
		this._panelMessageText = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
		this._messageText = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
		this._panelMessageIcon = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
		this._messageIcon = new System.Windows.Forms.PictureBox();
		this._panelButtons = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
		this.borderEdge = new ComponentFactory.Krypton.Toolkit.KryptonBorderEdge();
		this._button3 = new ComponentFactory.Krypton.Toolkit.KryptonMessageBox.MessageButton();
		this._button1 = new ComponentFactory.Krypton.Toolkit.KryptonMessageBox.MessageButton();
		this._button2 = new ComponentFactory.Krypton.Toolkit.KryptonMessageBox.MessageButton();
		((System.ComponentModel.ISupportInitialize)this._panelMessage).BeginInit();
		this._panelMessage.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this._panelMessageText).BeginInit();
		this._panelMessageText.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this._panelMessageIcon).BeginInit();
		this._panelMessageIcon.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this._messageIcon).BeginInit();
		((System.ComponentModel.ISupportInitialize)this._panelButtons).BeginInit();
		this._panelButtons.SuspendLayout();
		base.SuspendLayout();
		this._panelMessage.AutoSize = true;
		this._panelMessage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		this._panelMessage.Controls.Add(this._panelMessageText);
		this._panelMessage.Controls.Add(this._panelMessageIcon);
		this._panelMessage.Dock = System.Windows.Forms.DockStyle.Top;
		this._panelMessage.Location = new System.Drawing.Point(0, 0);
		this._panelMessage.Name = "_panelMessage";
		this._panelMessage.Size = new System.Drawing.Size(156, 52);
		this._panelMessage.TabIndex = 0;
		this._panelMessageText.AutoSize = true;
		this._panelMessageText.Controls.Add(this._messageText);
		this._panelMessageText.Location = new System.Drawing.Point(42, 0);
		this._panelMessageText.Margin = new System.Windows.Forms.Padding(0);
		this._panelMessageText.Name = "_panelMessageText";
		this._panelMessageText.Padding = new System.Windows.Forms.Padding(5, 17, 5, 17);
		this._panelMessageText.Size = new System.Drawing.Size(88, 52);
		this._panelMessageText.TabIndex = 1;
		this._messageText.AutoSize = false;
		this._messageText.Font = new System.Drawing.Font("Segoe UI", 9f);
		this._messageText.ForeColor = System.Drawing.Color.FromArgb(30, 57, 91);
		this._messageText.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
		this._messageText.Location = new System.Drawing.Point(5, 18);
		this._messageText.Margin = new System.Windows.Forms.Padding(0);
		this._messageText.Name = "_messageText";
		this._messageText.Size = new System.Drawing.Size(78, 15);
		this._messageText.Text = "Message Text";
		this._panelMessageIcon.AutoSize = true;
		this._panelMessageIcon.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		this._panelMessageIcon.Controls.Add(this._messageIcon);
		this._panelMessageIcon.Location = new System.Drawing.Point(0, 0);
		this._panelMessageIcon.Margin = new System.Windows.Forms.Padding(0);
		this._panelMessageIcon.Name = "_panelMessageIcon";
		this._panelMessageIcon.Padding = new System.Windows.Forms.Padding(10, 10, 0, 10);
		this._panelMessageIcon.Size = new System.Drawing.Size(42, 52);
		this._panelMessageIcon.TabIndex = 0;
		this._messageIcon.BackColor = System.Drawing.Color.Transparent;
		this._messageIcon.Location = new System.Drawing.Point(10, 10);
		this._messageIcon.Margin = new System.Windows.Forms.Padding(0);
		this._messageIcon.Name = "_messageIcon";
		this._messageIcon.Size = new System.Drawing.Size(32, 32);
		this._messageIcon.TabIndex = 0;
		this._messageIcon.TabStop = false;
		this._panelButtons.Controls.Add(this.borderEdge);
		this._panelButtons.Controls.Add(this._button3);
		this._panelButtons.Controls.Add(this._button1);
		this._panelButtons.Controls.Add(this._button2);
		this._panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
		this._panelButtons.Location = new System.Drawing.Point(0, 52);
		this._panelButtons.Margin = new System.Windows.Forms.Padding(0);
		this._panelButtons.Name = "_panelButtons";
		this._panelButtons.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
		this._panelButtons.Size = new System.Drawing.Size(156, 26);
		this._panelButtons.TabIndex = 0;
		this.borderEdge.BorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
		this.borderEdge.Dock = System.Windows.Forms.DockStyle.Top;
		this.borderEdge.Location = new System.Drawing.Point(0, 0);
		this.borderEdge.Name = "borderEdge";
		this.borderEdge.Size = new System.Drawing.Size(156, 1);
		this.borderEdge.Text = "kryptonBorderEdge1";
		this._button3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this._button3.AutoSize = true;
		this._button3.IgnoreAltF4 = false;
		this._button3.Location = new System.Drawing.Point(106, 0);
		this._button3.Margin = new System.Windows.Forms.Padding(0);
		this._button3.MinimumSize = new System.Drawing.Size(50, 26);
		this._button3.Name = "_button3";
		this._button3.Size = new System.Drawing.Size(50, 26);
		this._button3.TabIndex = 2;
		this._button3.Values.Text = "B3";
		this._button3.KeyDown += new System.Windows.Forms.KeyEventHandler(button_keyDown);
		this._button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this._button1.AutoSize = true;
		this._button1.IgnoreAltF4 = false;
		this._button1.Location = new System.Drawing.Point(6, 0);
		this._button1.Margin = new System.Windows.Forms.Padding(0);
		this._button1.MinimumSize = new System.Drawing.Size(50, 26);
		this._button1.Name = "_button1";
		this._button1.Size = new System.Drawing.Size(50, 26);
		this._button1.TabIndex = 0;
		this._button1.Values.Text = "B1";
		this._button1.KeyDown += new System.Windows.Forms.KeyEventHandler(button_keyDown);
		this._button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this._button2.AutoSize = true;
		this._button2.IgnoreAltF4 = false;
		this._button2.Location = new System.Drawing.Point(56, 0);
		this._button2.Margin = new System.Windows.Forms.Padding(0);
		this._button2.MinimumSize = new System.Drawing.Size(50, 26);
		this._button2.Name = "_button2";
		this._button2.Size = new System.Drawing.Size(50, 26);
		this._button2.TabIndex = 1;
		this._button2.Values.Text = "B2";
		this._button2.KeyDown += new System.Windows.Forms.KeyEventHandler(button_keyDown);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(156, 78);
		base.Controls.Add(this._panelButtons);
		base.Controls.Add(this._panelMessage);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "KryptonMessageBox";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		base.TopMost = true;
		((System.ComponentModel.ISupportInitialize)this._panelMessage).EndInit();
		this._panelMessage.ResumeLayout(false);
		this._panelMessage.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this._panelMessageText).EndInit();
		this._panelMessageText.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this._panelMessageIcon).EndInit();
		this._panelMessageIcon.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this._messageIcon).EndInit();
		((System.ComponentModel.ISupportInitialize)this._panelButtons).EndInit();
		this._panelButtons.ResumeLayout(false);
		this._panelButtons.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
