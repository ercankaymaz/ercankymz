using System;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit.Properties;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class VisualTaskDialog : KryptonForm
{
	[ToolboxItem(false)]
	public class MessageButton : KryptonButton
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

	private static readonly int BUTTON_GAP = 10;

	private KryptonTaskDialog _taskDialog;

	private string _windowTitle;

	private string _mainInstruction;

	private string _content;

	private MessageBoxIcon _mainIcon;

	private Image _customMainIcon;

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

	private KryptonPanel _panelMain;

	private KryptonPanel _panelIcon;

	private PictureBox _messageIcon;

	private KryptonPanel _panelMainText;

	private KryptonWrapLabel _messageText;

	private KryptonWrapLabel _messageContent;

	private KryptonTextBox _messageContentMultiline;

	private KryptonPanel _panelButtons;

	private MessageButton _buttonOK;

	private MessageButton _buttonYes;

	private MessageButton _buttonNo;

	private MessageButton _buttonCancel;

	private MessageButton _buttonRetry;

	private KryptonBorderEdge _panelButtonsBorderTop;

	private KryptonPanel _panelFooter;

	private KryptonLinkLabel _linkLabelFooter;

	private PictureBox _iconFooter;

	private KryptonWrapLabel _footerLabel;

	private KryptonBorderEdge _panelFooterBorderTop;

	private KryptonCheckBox _checkBox;

	private KryptonPanel _panelMainRadio;

	private KryptonPanel _panelMainCommands;

	private KryptonPanel _panelMainSpacer;

	private MessageButton _buttonClose;

	public VisualTaskDialog(KryptonTaskDialog taskDialog)
	{
		if (taskDialog == null)
		{
			throw new ArgumentNullException("taskDialog");
		}
		_taskDialog = taskDialog;
		_windowTitle = taskDialog.WindowTitle;
		_mainInstruction = taskDialog.MainInstruction;
		_content = taskDialog.Content;
		_mainIcon = taskDialog.Icon;
		_customMainIcon = taskDialog.CustomIcon;
		_radioButtons = taskDialog.RadioButtons;
		_commandButtons = taskDialog.CommandButtons;
		_commonButtons = taskDialog.CommonButtons;
		_defaultRadioButton = taskDialog.DefaultRadioButton;
		_defaultButton = taskDialog.DefaultButton;
		_footerIcon = taskDialog.FooterIcon;
		_customFooterIcon = taskDialog.CustomFooterIcon;
		_footerText = taskDialog.FooterText;
		_footerHyperlink = taskDialog.FooterHyperlink;
		_checkboxText = taskDialog.CheckboxText;
		_checkboxState = taskDialog.CheckboxState;
		_allowDialogClose = taskDialog.AllowDialogClose;
		InitializeComponent();
		UpdateContents();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _taskDialog != null)
		{
			_taskDialog = null;
		}
		base.Dispose(disposing);
	}

	private void UpdateContents()
	{
		UpdateText();
		UpdateIcon();
		UpdateRadioButtons();
		UpdateCommandButtons();
		UpdateButtons();
		UpdateCheckbox();
		UpdateFooter();
		UpdateChrome();
		UpdateSizing();
	}

	private void UpdateText()
	{
		Text = _windowTitle;
		_messageText.Text = _mainInstruction;
		if (string.IsNullOrEmpty(_content))
		{
			_messageContent.Text = string.Empty;
		}
		else if (_content.Length - _content.Replace("\n", "").Length > 20)
		{
			_messageContentMultiline.Text = _content;
			_messageContentMultiline.Visible = true;
			_messageContent.Visible = false;
		}
		else
		{
			_messageContent.Text = _content;
			_messageContentMultiline.Visible = false;
			_messageContent.Visible = true;
		}
	}

	private void UpdateIcon()
	{
		_panelIcon.Visible = true;
		if (_customMainIcon != null)
		{
			_messageIcon.Image = _customMainIcon;
			return;
		}
		switch (_mainIcon)
		{
		case MessageBoxIcon.None:
			_panelIcon.Visible = false;
			_panelMainText.Left -= _messageIcon.Right;
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

	private void UpdateRadioButtons()
	{
		if (_radioButtons.Count == 0)
		{
			_panelMainRadio.Visible = false;
			return;
		}
		_panelMainRadio.Controls.Clear();
		_panelMainRadio.Visible = true;
		Size empty = Size.Empty;
		foreach (KryptonTaskDialogCommand radioButton in _radioButtons)
		{
			KryptonRadioButton kryptonRadioButton = new KryptonRadioButton();
			kryptonRadioButton.LabelStyle = LabelStyle.NormalPanel;
			kryptonRadioButton.Values.Text = radioButton.Text;
			kryptonRadioButton.Values.ExtraText = radioButton.ExtraText;
			kryptonRadioButton.Values.Image = radioButton.Image;
			kryptonRadioButton.Values.ImageTransparentColor = radioButton.ImageTransparentColor;
			kryptonRadioButton.Enabled = radioButton.Enabled;
			kryptonRadioButton.CheckedChanged += OnRadioButtonCheckedChanged;
			kryptonRadioButton.Tag = radioButton;
			if (_defaultRadioButton == radioButton)
			{
				kryptonRadioButton.Checked = true;
			}
			_panelMainRadio.Controls.Add(kryptonRadioButton);
			Size preferredSize = kryptonRadioButton.GetPreferredSize(Size.Empty);
			empty.Width = Math.Max(empty.Width, preferredSize.Width);
			empty.Height = Math.Max(empty.Height, preferredSize.Height);
		}
		empty.Width = Math.Min(Math.Max(empty.Width, 150), 400);
		Point location = new Point(BUTTON_GAP - 1, 2);
		foreach (KryptonRadioButton control in _panelMainRadio.Controls)
		{
			control.Location = location;
			control.Size = empty;
			location.Y += empty.Height;
		}
		_panelMainRadio.Size = new Size(empty.Width, location.Y);
	}

	private void UpdateCommandButtons()
	{
		if (_commandButtons.Count == 0)
		{
			_panelMainCommands.Visible = false;
			return;
		}
		_panelMainCommands.Controls.Clear();
		_panelMainCommands.Visible = true;
		Size empty = Size.Empty;
		foreach (KryptonTaskDialogCommand commandButton in _commandButtons)
		{
			KryptonButton kryptonButton = new KryptonButton();
			kryptonButton.ButtonStyle = ButtonStyle.Command;
			kryptonButton.StateCommon.Content.Image.ImageH = PaletteRelativeAlign.Near;
			kryptonButton.StateCommon.Content.ShortText.TextH = PaletteRelativeAlign.Near;
			kryptonButton.StateCommon.Content.LongText.TextH = PaletteRelativeAlign.Near;
			kryptonButton.Values.Text = commandButton.Text;
			kryptonButton.Values.ExtraText = commandButton.ExtraText;
			kryptonButton.Values.Image = commandButton.Image;
			kryptonButton.Values.ImageTransparentColor = commandButton.ImageTransparentColor;
			kryptonButton.Enabled = commandButton.Enabled;
			kryptonButton.DialogResult = commandButton.DialogResult;
			kryptonButton.Tag = commandButton;
			kryptonButton.Click += OnCommandClicked;
			_panelMainCommands.Controls.Add(kryptonButton);
			Size preferredSize = kryptonButton.GetPreferredSize(Size.Empty);
			empty.Width = Math.Max(empty.Width, preferredSize.Width);
			empty.Height = Math.Max(empty.Height, preferredSize.Height);
		}
		empty.Width = Math.Min(Math.Max(empty.Width, 150), 400);
		Point location = new Point(BUTTON_GAP - 1, 2);
		foreach (KryptonButton control in _panelMainCommands.Controls)
		{
			control.Location = location;
			control.Size = empty;
			location.Y += empty.Height;
		}
		_panelMainCommands.Size = new Size(empty.Width, location.Y);
	}

	private void UpdateButtons()
	{
		MessageButton messageButton = null;
		MessageButton messageButton2 = null;
		if ((_commonButtons & TaskDialogButtons.OK) == TaskDialogButtons.OK)
		{
			if ((_defaultButton & TaskDialogButtons.OK) == TaskDialogButtons.OK)
			{
				messageButton2 = _buttonOK;
			}
			messageButton = _buttonOK;
			_buttonOK.Text = KryptonManager.Strings.OK;
			_buttonOK.Visible = true;
		}
		else
		{
			_buttonOK.Visible = false;
		}
		if ((_commonButtons & TaskDialogButtons.Yes) == TaskDialogButtons.Yes)
		{
			if ((_defaultButton & TaskDialogButtons.Yes) == TaskDialogButtons.Yes)
			{
				messageButton2 = _buttonYes;
			}
			if (messageButton == null)
			{
				messageButton = _buttonYes;
			}
			_buttonYes.Text = KryptonManager.Strings.Yes;
			_buttonYes.Visible = true;
		}
		else
		{
			_buttonYes.Visible = false;
		}
		if ((_commonButtons & TaskDialogButtons.No) == TaskDialogButtons.No)
		{
			if ((_defaultButton & TaskDialogButtons.No) == TaskDialogButtons.No)
			{
				messageButton2 = _buttonNo;
			}
			if (messageButton == null)
			{
				messageButton = _buttonNo;
			}
			_buttonNo.Text = KryptonManager.Strings.No;
			_buttonNo.Visible = true;
		}
		else
		{
			_buttonNo.Visible = false;
		}
		if ((_commonButtons & TaskDialogButtons.Cancel) == TaskDialogButtons.Cancel)
		{
			if ((_defaultButton & TaskDialogButtons.Cancel) == TaskDialogButtons.Cancel)
			{
				messageButton2 = _buttonCancel;
			}
			if (messageButton == null)
			{
				messageButton = _buttonCancel;
			}
			_buttonCancel.Text = KryptonManager.Strings.Cancel;
			_buttonCancel.Visible = true;
		}
		else
		{
			_buttonCancel.Visible = false;
		}
		if ((_commonButtons & TaskDialogButtons.Retry) == TaskDialogButtons.Retry)
		{
			if ((_defaultButton & TaskDialogButtons.Retry) == TaskDialogButtons.Retry)
			{
				messageButton2 = _buttonRetry;
			}
			if (messageButton == null)
			{
				messageButton = _buttonRetry;
			}
			_buttonRetry.Text = KryptonManager.Strings.Retry;
			_buttonRetry.Visible = true;
		}
		else
		{
			_buttonRetry.Visible = false;
		}
		if ((_commonButtons & TaskDialogButtons.Close) == TaskDialogButtons.Close)
		{
			if ((_defaultButton & TaskDialogButtons.Close) == TaskDialogButtons.Close)
			{
				messageButton2 = _buttonClose;
			}
			if (messageButton == null)
			{
				messageButton = _buttonClose;
			}
			_buttonClose.Text = KryptonManager.Strings.Close;
			_buttonClose.Visible = true;
		}
		else
		{
			_buttonClose.Visible = false;
		}
		if (messageButton2 != null)
		{
			messageButton2.Select();
		}
		else
		{
			messageButton?.Select();
		}
	}

	private void UpdateCheckbox()
	{
		_checkBox.Checked = _checkboxState;
		_checkBox.Text = _checkboxText;
		_checkBox.Visible = !string.IsNullOrEmpty(_checkboxText);
	}

	private void UpdateFooter()
	{
		_iconFooter.Visible = true;
		if (_customFooterIcon != null)
		{
			_iconFooter.Image = _customFooterIcon;
		}
		else
		{
			switch (_footerIcon)
			{
			case MessageBoxIcon.None:
				_iconFooter.Visible = false;
				break;
			case MessageBoxIcon.Question:
				_iconFooter.Image = Resources.help2Small;
				break;
			case MessageBoxIcon.Asterisk:
				_iconFooter.Image = Resources.informationSmall;
				break;
			case MessageBoxIcon.Exclamation:
				_iconFooter.Image = Resources.sign_warningSmall;
				break;
			case MessageBoxIcon.Hand:
				_iconFooter.Image = Resources.errorSmall;
				break;
			}
		}
		_footerLabel.Text = _footerText;
		_linkLabelFooter.Text = _footerHyperlink;
	}

	private void UpdateChrome()
	{
		if ((_commonButtons & TaskDialogButtons.Cancel) == TaskDialogButtons.Cancel || _allowDialogClose)
		{
			base.ControlBox = true;
		}
		else
		{
			base.ControlBox = false;
		}
		_buttonOK.IgnoreAltF4 = !base.ControlBox;
		_buttonYes.IgnoreAltF4 = !base.ControlBox;
		_buttonNo.IgnoreAltF4 = !base.ControlBox;
		_buttonCancel.IgnoreAltF4 = !base.ControlBox;
		_buttonRetry.IgnoreAltF4 = !base.ControlBox;
		_buttonClose.IgnoreAltF4 = !base.ControlBox;
	}

	private void UpdateSizing()
	{
		Size size = UpdateMainTextSizing();
		Size size2 = UpdateRadioSizing();
		Size size3 = UpdateCommandSizing();
		Size size4 = UpdateSpacerSizing();
		Size size5 = UpdateIconSizing();
		Size size6 = UpdateButtonsSizing();
		Size size7 = UpdateFooterSizing();
		base.ClientSize = new Size(size5.Width + Math.Max(size.Width, Math.Max(size3.Width, Math.Max(size2.Width, Math.Max(size6.Width, size7.Width)))), Math.Max(size5.Height, size.Height + size2.Height + size3.Height + size4.Height) + size6.Height + size7.Height);
	}

	private Size UpdateMainTextSizing()
	{
		Size size2;
		using (Graphics graphics = CreateGraphics())
		{
			_messageText.UpdateFont();
			_messageContent.UpdateFont();
			_messageContentMultiline.Font = _messageContent.Font;
			Size size = graphics.MeasureString(_mainInstruction, _messageText.Font, 400).ToSize();
			size2 = graphics.MeasureString(_content, _messageContent.Font, 400).ToSize();
			Rectangle workingArea = Screen.GetWorkingArea(base.Location);
			int num = (int)Math.Min(size2.Height, (double)workingArea.Height * 0.6);
			int num2 = (int)Math.Min(size2.Width, (double)workingArea.Width * 0.6);
			Size size3 = new Size(num2, num);
			if (size2 != size3)
			{
				size2 = size3;
			}
			float num3 = ((graphics.DpiX > 96f) ? (1f * graphics.DpiX / 96f) : 1f);
			float num4 = ((graphics.DpiY > 96f) ? (1f * graphics.DpiY / 96f) : 1f);
			size.Width = (int)((float)size.Width * num3);
			size.Height = (int)((float)size.Height * num4);
			size2.Width = (int)((float)size2.Width * num3);
			size2.Height = (int)((float)size2.Height * num4);
			size.Width += 5;
			size2.Width += 5;
			_messageText.Size = size;
			_messageContent.Size = size2;
			_messageContentMultiline.Size = size2;
		}
		Padding padding = _panelMainText.Padding;
		_panelMainText.Width = Math.Max(_messageText.Size.Width, size2.Width) + padding.Horizontal;
		_panelMainText.Height = _messageText.Size.Height + size2.Height + padding.Vertical + BUTTON_GAP;
		_messageContent.Location = new Point(_messageText.Left + 2, _messageText.Bottom);
		_messageContentMultiline.Location = _messageContent.Location;
		return _panelMainText.Size;
	}

	private Size UpdateIconSizing()
	{
		if (_messageIcon.Image == null)
		{
			return Size.Empty;
		}
		return _panelIcon.Size;
	}

	private Size UpdateRadioSizing()
	{
		_panelMainRadio.Location = new Point(_panelMainText.Left, _panelMainText.Top + _panelMainText.Height);
		if (_radioButtons.Count == 0)
		{
			_panelMainRadio.Size = Size.Empty;
			return Size.Empty;
		}
		return new Size(_panelMainRadio.Size.Width + BUTTON_GAP + 2, _panelMainRadio.Size.Height);
	}

	private Size UpdateCommandSizing()
	{
		_panelMainCommands.Location = new Point(_panelMainRadio.Left, _panelMainRadio.Top + _panelMainRadio.Height);
		if (_commandButtons.Count == 0)
		{
			_panelMainCommands.Size = Size.Empty;
			return Size.Empty;
		}
		return new Size(_panelMainCommands.Size.Width + BUTTON_GAP + 2, _panelMainCommands.Size.Height);
	}

	private Size UpdateSpacerSizing()
	{
		_panelMainSpacer.Location = new Point(_panelMainCommands.Left, _panelMainCommands.Top + _panelMainCommands.Height);
		return _panelMainSpacer.Size;
	}

	private Size UpdateButtonsSizing()
	{
		int num = 0;
		Size empty = Size.Empty;
		if ((_commonButtons & TaskDialogButtons.Close) == TaskDialogButtons.Close)
		{
			num++;
			Size preferredSize = _buttonClose.GetPreferredSize(Size.Empty);
			empty.Width = Math.Max(empty.Width, preferredSize.Width + BUTTON_GAP);
			empty.Height = Math.Max(empty.Height, preferredSize.Height);
		}
		if ((_commonButtons & TaskDialogButtons.Retry) == TaskDialogButtons.Retry)
		{
			num++;
			Size preferredSize2 = _buttonRetry.GetPreferredSize(Size.Empty);
			empty.Width = Math.Max(empty.Width, preferredSize2.Width + BUTTON_GAP);
			empty.Height = Math.Max(empty.Height, preferredSize2.Height);
		}
		if ((_commonButtons & TaskDialogButtons.Cancel) == TaskDialogButtons.Cancel)
		{
			num++;
			Size preferredSize3 = _buttonCancel.GetPreferredSize(Size.Empty);
			empty.Width = Math.Max(empty.Width, preferredSize3.Width + BUTTON_GAP);
			empty.Height = Math.Max(empty.Height, preferredSize3.Height);
		}
		if ((_commonButtons & TaskDialogButtons.No) == TaskDialogButtons.No)
		{
			num++;
			Size preferredSize4 = _buttonNo.GetPreferredSize(Size.Empty);
			empty.Width = Math.Max(empty.Width, preferredSize4.Width + BUTTON_GAP);
			empty.Height = Math.Max(empty.Height, preferredSize4.Height);
		}
		if ((_commonButtons & TaskDialogButtons.Yes) == TaskDialogButtons.Yes)
		{
			num++;
			Size preferredSize5 = _buttonYes.GetPreferredSize(Size.Empty);
			empty.Width = Math.Max(empty.Width, preferredSize5.Width + BUTTON_GAP);
			empty.Height = Math.Max(empty.Height, preferredSize5.Height);
		}
		if ((_commonButtons & TaskDialogButtons.OK) == TaskDialogButtons.OK)
		{
			num++;
			Size preferredSize6 = _buttonOK.GetPreferredSize(Size.Empty);
			empty.Width = Math.Max(empty.Width, preferredSize6.Width + BUTTON_GAP);
			empty.Height = Math.Max(empty.Height, preferredSize6.Height);
		}
		int num2 = _panelButtons.Right - BUTTON_GAP;
		if ((_commonButtons & TaskDialogButtons.Close) == TaskDialogButtons.Close)
		{
			_buttonClose.Location = new Point(num2 - empty.Width, BUTTON_GAP);
			_buttonClose.Size = empty;
			num2 -= empty.Width + BUTTON_GAP;
		}
		if ((_commonButtons & TaskDialogButtons.Retry) == TaskDialogButtons.Retry)
		{
			_buttonRetry.Location = new Point(num2 - empty.Width, BUTTON_GAP);
			_buttonRetry.Size = empty;
			num2 -= empty.Width + BUTTON_GAP;
		}
		if ((_commonButtons & TaskDialogButtons.Cancel) == TaskDialogButtons.Cancel)
		{
			_buttonCancel.Location = new Point(num2 - empty.Width, BUTTON_GAP);
			_buttonCancel.Size = empty;
			num2 -= empty.Width + BUTTON_GAP;
		}
		if ((_commonButtons & TaskDialogButtons.No) == TaskDialogButtons.No)
		{
			_buttonNo.Location = new Point(num2 - empty.Width, BUTTON_GAP);
			_buttonNo.Size = empty;
			num2 -= empty.Width + BUTTON_GAP;
		}
		if ((_commonButtons & TaskDialogButtons.Yes) == TaskDialogButtons.Yes)
		{
			_buttonYes.Location = new Point(num2 - empty.Width, BUTTON_GAP);
			_buttonYes.Size = empty;
			num2 -= empty.Width + BUTTON_GAP;
		}
		if ((_commonButtons & TaskDialogButtons.OK) == TaskDialogButtons.OK)
		{
			_buttonOK.Location = new Point(num2 - empty.Width, BUTTON_GAP);
			_buttonOK.Size = empty;
			num2 -= empty.Width + BUTTON_GAP;
		}
		Size size = Size.Empty;
		if (!string.IsNullOrEmpty(_checkboxText))
		{
			size = _checkBox.GetPreferredSize(Size.Empty);
		}
		if (num == 0)
		{
			if (size.IsEmpty)
			{
				_panelButtons.Visible = false;
				return Size.Empty;
			}
			_panelButtons.Visible = true;
			_checkBox.Location = new Point(BUTTON_GAP, BUTTON_GAP);
			return new Size(size.Width + BUTTON_GAP * 2, size.Height + BUTTON_GAP * 2);
		}
		_panelButtons.Visible = true;
		Size result = new Size(empty.Width * num + BUTTON_GAP * (num + 1), empty.Height + BUTTON_GAP * 2);
		if (!size.IsEmpty)
		{
			result.Width += size.Width;
			result.Height = Math.Max(result.Height, size.Height + BUTTON_GAP * 2);
			_checkBox.Location = new Point(BUTTON_GAP, (result.Height - size.Height) / 2);
		}
		return result;
	}

	private Size UpdateFooterSizing()
	{
		using Graphics graphics = CreateGraphics();
		_footerLabel.UpdateFont();
		Size size = graphics.MeasureString(_footerText, _footerLabel.Font, 200).ToSize();
		Size size2 = graphics.MeasureString(_footerHyperlink, _footerLabel.Font, 200).ToSize();
		size.Width += 5;
		size2.Width += 5;
		_footerLabel.Size = size;
		_linkLabelFooter.Size = size2;
		Size empty = Size.Empty;
		if (!string.IsNullOrEmpty(_footerText))
		{
			empty.Width += size.Width;
			empty.Height = size.Height;
		}
		if (!string.IsNullOrEmpty(_footerHyperlink))
		{
			empty.Width += size2.Width;
			empty.Height = Math.Max(empty.Height, size2.Height);
		}
		if (_footerIcon != MessageBoxIcon.None || _customFooterIcon != null)
		{
			empty.Width += _iconFooter.Width + BUTTON_GAP;
			empty.Height = Math.Max(empty.Height, _iconFooter.Size.Height);
		}
		if (empty.Width > 0)
		{
			empty.Width += BUTTON_GAP * 2;
			empty.Height += BUTTON_GAP * 2;
		}
		_panelFooter.Visible = empty.Width > 0;
		if (empty.Width > 0)
		{
			_panelFooter.Size = empty;
			int num = BUTTON_GAP;
			if (_footerIcon != MessageBoxIcon.None || _customFooterIcon != null)
			{
				_iconFooter.Location = new Point(num, (empty.Height - _iconFooter.Height) / 2);
				num += _iconFooter.Width + BUTTON_GAP / 2;
			}
			if (!string.IsNullOrEmpty(_footerText))
			{
				_footerLabel.Location = new Point(num, (empty.Height - size.Height) / 2);
				num += _footerLabel.Width - 8;
			}
			if (!string.IsNullOrEmpty(_footerHyperlink))
			{
				if (!string.IsNullOrEmpty(_footerText))
				{
					_linkLabelFooter.Location = new Point(num, _footerLabel.Location.Y - 1);
				}
				else
				{
					_linkLabelFooter.Location = new Point(num, (empty.Height - size2.Height) / 2);
				}
				num += _footerLabel.Width;
			}
		}
		return empty;
	}

	private void OnRadioButtonCheckedChanged(object sender, EventArgs e)
	{
		KryptonRadioButton kryptonRadioButton = (KryptonRadioButton)sender;
		_defaultRadioButton = (KryptonTaskDialogCommand)kryptonRadioButton.Tag;
		_taskDialog.DefaultRadioButton = _defaultRadioButton;
	}

	private void OnCommandClicked(object sender, EventArgs e)
	{
		Close();
		KryptonButton kryptonButton = (KryptonButton)sender;
		base.DialogResult = kryptonButton.DialogResult;
		KryptonTaskDialogCommand kryptonTaskDialogCommand = (KryptonTaskDialogCommand)kryptonButton.Tag;
		kryptonTaskDialogCommand.PerformExecute();
	}

	private void OnTaskDialogFormClosing(object sender, FormClosingEventArgs e)
	{
		if (e.CloseReason == CloseReason.UserClosing)
		{
			base.DialogResult = DialogResult.Cancel;
		}
	}

	private void checkBox_CheckedChanged(object sender, EventArgs e)
	{
		_checkboxState = _checkBox.Checked;
		if (_taskDialog != null)
		{
			_taskDialog.CheckboxState = _checkboxState;
		}
	}

	private void _linkLabelFooter_LinkClicked(object sender, EventArgs e)
	{
		if (_taskDialog != null)
		{
			_taskDialog.RaiseFooterHyperlinkClicked();
		}
	}

	private void _buttonClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void button_keyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.ControlBox)
		{
			Close();
		}
		else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("---------------------------");
			stringBuilder.AppendLine(_windowTitle);
			stringBuilder.AppendLine("---------------------------");
			stringBuilder.AppendLine(_mainInstruction);
			stringBuilder.AppendLine("---------------------------");
			stringBuilder.AppendLine(_content);
			stringBuilder.AppendLine("---------------------------");
			if (_buttonOK.Visible)
			{
				stringBuilder.Append(_buttonOK.Text);
				stringBuilder.Append("   ");
			}
			if (_buttonYes.Visible)
			{
				stringBuilder.Append(_buttonYes.Text);
				stringBuilder.Append("   ");
			}
			if (_buttonNo.Visible)
			{
				stringBuilder.Append(_buttonNo.Text);
				stringBuilder.Append("   ");
			}
			if (_buttonCancel.Visible)
			{
				stringBuilder.Append(_buttonCancel.Text);
				stringBuilder.Append("   ");
			}
			if (_buttonRetry.Visible)
			{
				stringBuilder.Append(_buttonRetry.Text);
				stringBuilder.Append("   ");
			}
			if (_buttonClose.Visible)
			{
				stringBuilder.Append(_buttonClose.Text);
				stringBuilder.Append("   ");
			}
			stringBuilder.AppendLine("");
			stringBuilder.AppendLine("---------------------------");
			Clipboard.SetText(stringBuilder.ToString(), TextDataFormat.Text);
		}
	}

	private void InitializeComponent()
	{
		this._panelMain = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
		this._panelMainSpacer = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
		this._panelMainCommands = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
		this._panelMainRadio = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
		this._panelMainText = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
		this._messageContent = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
		this._messageContentMultiline = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
		this._messageText = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
		this._panelIcon = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
		this._messageIcon = new System.Windows.Forms.PictureBox();
		this._panelButtons = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
		this._checkBox = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
		this._panelButtonsBorderTop = new ComponentFactory.Krypton.Toolkit.KryptonBorderEdge();
		this._buttonOK = new ComponentFactory.Krypton.Toolkit.VisualTaskDialog.MessageButton();
		this._buttonYes = new ComponentFactory.Krypton.Toolkit.VisualTaskDialog.MessageButton();
		this._buttonNo = new ComponentFactory.Krypton.Toolkit.VisualTaskDialog.MessageButton();
		this._buttonRetry = new ComponentFactory.Krypton.Toolkit.VisualTaskDialog.MessageButton();
		this._buttonCancel = new ComponentFactory.Krypton.Toolkit.VisualTaskDialog.MessageButton();
		this._buttonClose = new ComponentFactory.Krypton.Toolkit.VisualTaskDialog.MessageButton();
		this._panelFooter = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
		this._linkLabelFooter = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
		this._iconFooter = new System.Windows.Forms.PictureBox();
		this._footerLabel = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
		this._panelFooterBorderTop = new ComponentFactory.Krypton.Toolkit.KryptonBorderEdge();
		((System.ComponentModel.ISupportInitialize)this._panelMain).BeginInit();
		this._panelMain.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this._panelMainSpacer).BeginInit();
		((System.ComponentModel.ISupportInitialize)this._panelMainCommands).BeginInit();
		((System.ComponentModel.ISupportInitialize)this._panelMainRadio).BeginInit();
		((System.ComponentModel.ISupportInitialize)this._panelMainText).BeginInit();
		this._panelMainText.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this._panelIcon).BeginInit();
		this._panelIcon.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this._messageIcon).BeginInit();
		((System.ComponentModel.ISupportInitialize)this._panelButtons).BeginInit();
		this._panelButtons.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this._panelFooter).BeginInit();
		this._panelFooter.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this._iconFooter).BeginInit();
		base.SuspendLayout();
		this._panelMain.AutoSize = true;
		this._panelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		this._panelMain.Controls.Add(this._panelMainSpacer);
		this._panelMain.Controls.Add(this._panelMainCommands);
		this._panelMain.Controls.Add(this._panelMainRadio);
		this._panelMain.Controls.Add(this._panelMainText);
		this._panelMain.Controls.Add(this._panelIcon);
		this._panelMain.Dock = System.Windows.Forms.DockStyle.Top;
		this._panelMain.Location = new System.Drawing.Point(0, 0);
		this._panelMain.Name = "_panelMain";
		this._panelMain.Size = new System.Drawing.Size(544, 72);
		this._panelMain.TabIndex = 0;
		this._panelMainSpacer.Location = new System.Drawing.Point(42, 59);
		this._panelMainSpacer.Name = "_panelMainSpacer";
		this._panelMainSpacer.Size = new System.Drawing.Size(10, 10);
		this._panelMainSpacer.TabIndex = 3;
		this._panelMainCommands.AutoSize = true;
		this._panelMainCommands.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		this._panelMainCommands.Location = new System.Drawing.Point(208, 10);
		this._panelMainCommands.Name = "_panelMainCommands";
		this._panelMainCommands.Size = new System.Drawing.Size(0, 0);
		this._panelMainCommands.TabIndex = 2;
		this._panelMainRadio.AutoSize = true;
		this._panelMainRadio.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		this._panelMainRadio.Location = new System.Drawing.Point(208, 32);
		this._panelMainRadio.Name = "_panelMainRadio";
		this._panelMainRadio.Size = new System.Drawing.Size(0, 0);
		this._panelMainRadio.TabIndex = 1;
		this._panelMainText.AutoSize = true;
		this._panelMainText.Controls.Add(this._messageContent);
		this._panelMainText.Controls.Add(this._messageContentMultiline);
		this._panelMainText.Controls.Add(this._messageText);
		this._panelMainText.Location = new System.Drawing.Point(42, 0);
		this._panelMainText.Margin = new System.Windows.Forms.Padding(0);
		this._panelMainText.Name = "_panelMainText";
		this._panelMainText.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
		this._panelMainText.Size = new System.Drawing.Size(357, 60);
		this._panelMainText.TabIndex = 0;
		this._messageContent.AutoSize = false;
		this._messageContent.Font = new System.Drawing.Font("Segoe UI", 9f);
		this._messageContent.ForeColor = System.Drawing.Color.FromArgb(30, 57, 91);
		this._messageContent.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
		this._messageContent.Location = new System.Drawing.Point(6, 34);
		this._messageContent.Margin = new System.Windows.Forms.Padding(0);
		this._messageContent.Name = "_messageContent";
		this._messageContent.Size = new System.Drawing.Size(78, 15);
		this._messageContent.Text = "Content";
		this._messageContentMultiline.Location = new System.Drawing.Point(48, 45);
		this._messageContentMultiline.Multiline = true;
		this._messageContentMultiline.Name = "_messageContentMultiline";
		this._messageContentMultiline.ReadOnly = true;
		this._messageContentMultiline.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this._messageContentMultiline.Size = new System.Drawing.Size(351, 10);
		this._messageContentMultiline.TabIndex = 4;
		this._messageText.AutoSize = false;
		this._messageText.Font = new System.Drawing.Font("Segoe UI", 13.5f, System.Drawing.FontStyle.Bold);
		this._messageText.ForeColor = System.Drawing.Color.FromArgb(30, 57, 91);
		this._messageText.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitlePanel;
		this._messageText.Location = new System.Drawing.Point(5, 5);
		this._messageText.Margin = new System.Windows.Forms.Padding(0);
		this._messageText.Name = "_messageText";
		this._messageText.Size = new System.Drawing.Size(139, 27);
		this._messageText.Text = "Message Text";
		this._panelIcon.AutoSize = true;
		this._panelIcon.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		this._panelIcon.Controls.Add(this._messageIcon);
		this._panelIcon.Location = new System.Drawing.Point(0, 0);
		this._panelIcon.Margin = new System.Windows.Forms.Padding(0);
		this._panelIcon.Name = "_panelIcon";
		this._panelIcon.Padding = new System.Windows.Forms.Padding(10, 10, 0, 10);
		this._panelIcon.Size = new System.Drawing.Size(42, 52);
		this._panelIcon.TabIndex = 0;
		this._messageIcon.BackColor = System.Drawing.Color.Transparent;
		this._messageIcon.Location = new System.Drawing.Point(10, 10);
		this._messageIcon.Margin = new System.Windows.Forms.Padding(0);
		this._messageIcon.Name = "_messageIcon";
		this._messageIcon.Size = new System.Drawing.Size(32, 32);
		this._messageIcon.TabIndex = 0;
		this._messageIcon.TabStop = false;
		this._panelButtons.Controls.Add(this._checkBox);
		this._panelButtons.Controls.Add(this._panelButtonsBorderTop);
		this._panelButtons.Controls.Add(this._buttonOK);
		this._panelButtons.Controls.Add(this._buttonYes);
		this._panelButtons.Controls.Add(this._buttonNo);
		this._panelButtons.Controls.Add(this._buttonRetry);
		this._panelButtons.Controls.Add(this._buttonCancel);
		this._panelButtons.Controls.Add(this._buttonClose);
		this._panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
		this._panelButtons.Location = new System.Drawing.Point(0, 72);
		this._panelButtons.Margin = new System.Windows.Forms.Padding(0);
		this._panelButtons.Name = "_panelButtons";
		this._panelButtons.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
		this._panelButtons.Size = new System.Drawing.Size(544, 46);
		this._panelButtons.TabIndex = 1;
		this._checkBox.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
		this._checkBox.Location = new System.Drawing.Point(12, 12);
		this._checkBox.Name = "_checkBox";
		this._checkBox.Size = new System.Drawing.Size(75, 20);
		this._checkBox.TabIndex = 0;
		this._checkBox.Values.Text = "checkBox";
		this._checkBox.CheckedChanged += new System.EventHandler(checkBox_CheckedChanged);
		this._panelButtonsBorderTop.BorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
		this._panelButtonsBorderTop.Dock = System.Windows.Forms.DockStyle.Top;
		this._panelButtonsBorderTop.Location = new System.Drawing.Point(0, 0);
		this._panelButtonsBorderTop.Name = "_panelButtonsBorderTop";
		this._panelButtonsBorderTop.Size = new System.Drawing.Size(544, 1);
		this._panelButtonsBorderTop.Text = "kryptonBorderEdge1";
		this._buttonOK.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this._buttonOK.AutoSize = true;
		this._buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
		this._buttonOK.IgnoreAltF4 = false;
		this._buttonOK.Location = new System.Drawing.Point(435, 9);
		this._buttonOK.Margin = new System.Windows.Forms.Padding(0);
		this._buttonOK.MinimumSize = new System.Drawing.Size(50, 26);
		this._buttonOK.Name = "_buttonOK";
		this._buttonOK.Size = new System.Drawing.Size(50, 26);
		this._buttonOK.TabIndex = 1;
		this._buttonOK.Values.Text = "OK";
		this._buttonOK.KeyDown += new System.Windows.Forms.KeyEventHandler(button_keyDown);
		this._buttonYes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this._buttonYes.AutoSize = true;
		this._buttonYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
		this._buttonYes.IgnoreAltF4 = false;
		this._buttonYes.Location = new System.Drawing.Point(335, 9);
		this._buttonYes.Margin = new System.Windows.Forms.Padding(0);
		this._buttonYes.MinimumSize = new System.Drawing.Size(50, 26);
		this._buttonYes.Name = "_buttonYes";
		this._buttonYes.Size = new System.Drawing.Size(50, 26);
		this._buttonYes.TabIndex = 2;
		this._buttonYes.Values.Text = "Yes";
		this._buttonYes.KeyDown += new System.Windows.Forms.KeyEventHandler(button_keyDown);
		this._buttonNo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this._buttonNo.AutoSize = true;
		this._buttonNo.DialogResult = System.Windows.Forms.DialogResult.No;
		this._buttonNo.IgnoreAltF4 = false;
		this._buttonNo.Location = new System.Drawing.Point(285, 9);
		this._buttonNo.Margin = new System.Windows.Forms.Padding(0);
		this._buttonNo.MinimumSize = new System.Drawing.Size(50, 26);
		this._buttonNo.Name = "_buttonNo";
		this._buttonNo.Size = new System.Drawing.Size(50, 26);
		this._buttonNo.TabIndex = 3;
		this._buttonNo.Values.Text = "No";
		this._buttonNo.KeyDown += new System.Windows.Forms.KeyEventHandler(button_keyDown);
		this._buttonRetry.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this._buttonRetry.AutoSize = true;
		this._buttonRetry.DialogResult = System.Windows.Forms.DialogResult.Retry;
		this._buttonRetry.IgnoreAltF4 = false;
		this._buttonRetry.Location = new System.Drawing.Point(385, 9);
		this._buttonRetry.Margin = new System.Windows.Forms.Padding(0);
		this._buttonRetry.MinimumSize = new System.Drawing.Size(50, 26);
		this._buttonRetry.Name = "_buttonRetry";
		this._buttonRetry.Size = new System.Drawing.Size(50, 26);
		this._buttonRetry.TabIndex = 5;
		this._buttonRetry.Values.Text = "Retry";
		this._buttonRetry.KeyDown += new System.Windows.Forms.KeyEventHandler(button_keyDown);
		this._buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this._buttonCancel.AutoSize = true;
		this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this._buttonCancel.IgnoreAltF4 = false;
		this._buttonCancel.Location = new System.Drawing.Point(228, 9);
		this._buttonCancel.Margin = new System.Windows.Forms.Padding(0);
		this._buttonCancel.MinimumSize = new System.Drawing.Size(50, 26);
		this._buttonCancel.Name = "_buttonCancel";
		this._buttonCancel.Size = new System.Drawing.Size(57, 26);
		this._buttonCancel.TabIndex = 4;
		this._buttonCancel.Values.Text = "Cancel";
		this._buttonCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(button_keyDown);
		this._buttonClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this._buttonClose.AutoSize = true;
		this._buttonClose.IgnoreAltF4 = false;
		this._buttonClose.Location = new System.Drawing.Point(485, 9);
		this._buttonClose.Margin = new System.Windows.Forms.Padding(0);
		this._buttonClose.MinimumSize = new System.Drawing.Size(50, 26);
		this._buttonClose.Name = "_buttonClose";
		this._buttonClose.Size = new System.Drawing.Size(50, 26);
		this._buttonClose.TabIndex = 6;
		this._buttonClose.Values.Text = "Close";
		this._buttonClose.Click += new System.EventHandler(_buttonClose_Click);
		this._buttonClose.KeyDown += new System.Windows.Forms.KeyEventHandler(button_keyDown);
		this._panelFooter.Controls.Add(this._linkLabelFooter);
		this._panelFooter.Controls.Add(this._iconFooter);
		this._panelFooter.Controls.Add(this._footerLabel);
		this._panelFooter.Controls.Add(this._panelFooterBorderTop);
		this._panelFooter.Dock = System.Windows.Forms.DockStyle.Top;
		this._panelFooter.Location = new System.Drawing.Point(0, 118);
		this._panelFooter.Name = "_panelFooter";
		this._panelFooter.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
		this._panelFooter.Size = new System.Drawing.Size(544, 49);
		this._panelFooter.TabIndex = 2;
		this._linkLabelFooter.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
		this._linkLabelFooter.Location = new System.Drawing.Point(127, 11);
		this._linkLabelFooter.Name = "_linkLabelFooter";
		this._linkLabelFooter.Size = new System.Drawing.Size(110, 20);
		this._linkLabelFooter.TabIndex = 0;
		this._linkLabelFooter.Values.Text = "kryptonLinkLabel1";
		this._linkLabelFooter.LinkClicked += new System.EventHandler(_linkLabelFooter_LinkClicked);
		this._iconFooter.BackColor = System.Drawing.Color.Transparent;
		this._iconFooter.Location = new System.Drawing.Point(10, 10);
		this._iconFooter.Margin = new System.Windows.Forms.Padding(0);
		this._iconFooter.Name = "_iconFooter";
		this._iconFooter.Size = new System.Drawing.Size(16, 16);
		this._iconFooter.TabIndex = 4;
		this._iconFooter.TabStop = false;
		this._footerLabel.AutoSize = false;
		this._footerLabel.Font = new System.Drawing.Font("Segoe UI", 9f);
		this._footerLabel.ForeColor = System.Drawing.Color.FromArgb(30, 57, 91);
		this._footerLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
		this._footerLabel.Location = new System.Drawing.Point(36, 11);
		this._footerLabel.Margin = new System.Windows.Forms.Padding(0);
		this._footerLabel.Name = "_footerLabel";
		this._footerLabel.Size = new System.Drawing.Size(78, 15);
		this._footerLabel.Text = "Content";
		this._panelFooterBorderTop.BorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
		this._panelFooterBorderTop.Dock = System.Windows.Forms.DockStyle.Top;
		this._panelFooterBorderTop.Location = new System.Drawing.Point(0, 0);
		this._panelFooterBorderTop.Name = "_panelFooterBorderTop";
		this._panelFooterBorderTop.Size = new System.Drawing.Size(544, 1);
		this._panelFooterBorderTop.Text = "kryptonBorderEdge1";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.AutoScroll = true;
		base.ClientSize = new System.Drawing.Size(561, 164);
		base.Controls.Add(this._panelFooter);
		base.Controls.Add(this._panelButtons);
		base.Controls.Add(this._panelMain);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "VisualTaskDialog";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(OnTaskDialogFormClosing);
		((System.ComponentModel.ISupportInitialize)this._panelMain).EndInit();
		this._panelMain.ResumeLayout(false);
		this._panelMain.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this._panelMainSpacer).EndInit();
		((System.ComponentModel.ISupportInitialize)this._panelMainCommands).EndInit();
		((System.ComponentModel.ISupportInitialize)this._panelMainRadio).EndInit();
		((System.ComponentModel.ISupportInitialize)this._panelMainText).EndInit();
		this._panelMainText.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this._panelIcon).EndInit();
		this._panelIcon.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this._messageIcon).EndInit();
		((System.ComponentModel.ISupportInitialize)this._panelButtons).EndInit();
		this._panelButtons.ResumeLayout(false);
		this._panelButtons.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this._panelFooter).EndInit();
		this._panelFooter.ResumeLayout(false);
		this._panelFooter.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this._iconFooter).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
