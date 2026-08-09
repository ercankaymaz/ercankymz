using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonInputBox), "ToolboxBitmaps.KryptonInputBox.bmp")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
public class KryptonInputBox : KryptonForm
{
	private static readonly int GAP = 10;

	private string _prompt;

	private string _caption;

	private string _defaultResponse;

	private KryptonPanel _panelMessage;

	private KryptonWrapLabel _labelPrompt;

	private KryptonTextBox _textBoxResponse;

	private KryptonButton _buttonOK;

	private KryptonButton _buttonCancel;

	internal string InputResponse => _textBoxResponse.Text;

	private KryptonInputBox(string prompt, string caption, string defaultResposne)
	{
		_prompt = prompt;
		_caption = caption;
		_defaultResponse = defaultResposne;
		InitializeComponent();
		UpdateText();
		UpdateButtons();
		UpdateSizing();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
		}
		base.Dispose(disposing);
	}

	public static string Show(string prompt)
	{
		return InternalShow(null, prompt, string.Empty, string.Empty);
	}

	public static string Show(IWin32Window owner, string prompt)
	{
		return InternalShow(owner, prompt, string.Empty, string.Empty);
	}

	public static string Show(string prompt, string caption)
	{
		return InternalShow(null, prompt, caption, string.Empty);
	}

	public static string Show(IWin32Window owner, string prompt, string caption)
	{
		return InternalShow(owner, prompt, caption, string.Empty);
	}

	public static string Show(string prompt, string caption, string defaultResponse)
	{
		return InternalShow(null, prompt, caption, defaultResponse);
	}

	public static string Show(IWin32Window owner, string prompt, string caption, string defaultResponse)
	{
		return InternalShow(owner, prompt, caption, defaultResponse);
	}

	private static string InternalShow(IWin32Window owner, string prompt, string caption, string defaultResponse)
	{
		IWin32Window win32Window = null;
		win32Window = ((owner != null) ? owner : Control.FromHandle(PI.GetActiveWindow()));
		using KryptonInputBox kryptonInputBox = new KryptonInputBox(prompt, caption, defaultResponse);
		if (win32Window == null)
		{
			kryptonInputBox.StartPosition = FormStartPosition.CenterScreen;
		}
		else
		{
			kryptonInputBox.StartPosition = FormStartPosition.CenterParent;
		}
		if (kryptonInputBox.ShowDialog(win32Window) == DialogResult.OK)
		{
			return kryptonInputBox.InputResponse;
		}
		return string.Empty;
	}

	private void UpdateText()
	{
		Text = _caption;
		_labelPrompt.Text = _prompt;
		_textBoxResponse.Text = _defaultResponse;
	}

	private void UpdateButtons()
	{
		_buttonOK.Text = KryptonManager.Strings.OK;
		_buttonCancel.Text = KryptonManager.Strings.Cancel;
	}

	private void UpdateSizing()
	{
		Size size = UpdateButtonSizing();
		Size size2 = UpdatePromptSizing();
		Size size3 = UpdateResponseSizing();
		base.ClientSize = new Size(_buttonCancel.Right + GAP, _textBoxResponse.Bottom + GAP);
	}

	private Size UpdatePromptSizing()
	{
		using Graphics graphics = CreateGraphics();
		_labelPrompt.UpdateFont();
		Size size = graphics.MeasureString(_prompt, _labelPrompt.Font, 250).ToSize();
		float num = ((graphics.DpiX > 96f) ? (1f * graphics.DpiX / 96f) : 1f);
		float num2 = ((graphics.DpiY > 96f) ? (1f * graphics.DpiY / 96f) : 1f);
		size.Width = (int)((float)size.Width * num);
		size.Height = (int)((float)size.Height * num2);
		_labelPrompt.Location = new Point(GAP, GAP);
		_labelPrompt.Size = new Size(255, Math.Max(size.Height, _buttonCancel.Bottom - _buttonOK.Top));
		return new Size(_labelPrompt.Right, _labelPrompt.Bottom);
	}

	private Size UpdateButtonSizing()
	{
		Size preferredSize = _buttonOK.GetPreferredSize(Size.Empty);
		Size preferredSize2 = _buttonCancel.GetPreferredSize(Size.Empty);
		Size size = new Size(Math.Max(preferredSize.Width, preferredSize2.Width), Math.Max(preferredSize.Height, preferredSize2.Height));
		_buttonOK.Size = size;
		_buttonCancel.Size = size;
		_buttonOK.Location = new Point(_panelMessage.Right - _buttonOK.Width - GAP, GAP);
		_buttonCancel.Location = new Point(_panelMessage.Right - _buttonCancel.Width - GAP, _buttonOK.Bottom + GAP / 2);
		return new Size(_buttonOK.Left + GAP, _buttonCancel.Bottom + GAP);
	}

	private Size UpdateResponseSizing()
	{
		_textBoxResponse.Location = new Point(GAP, _labelPrompt.Bottom + GAP);
		_textBoxResponse.Width = _buttonOK.Right - _textBoxResponse.Left;
		return _textBoxResponse.Size;
	}

	private void button_keyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.ControlBox)
		{
			Close();
		}
	}

	private void InitializeComponent()
	{
		this._panelMessage = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
		this._textBoxResponse = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
		this._labelPrompt = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
		this._buttonCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
		this._buttonOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
		((System.ComponentModel.ISupportInitialize)this._panelMessage).BeginInit();
		this._panelMessage.SuspendLayout();
		base.SuspendLayout();
		this._panelMessage.Controls.Add(this._textBoxResponse);
		this._panelMessage.Controls.Add(this._labelPrompt);
		this._panelMessage.Controls.Add(this._buttonCancel);
		this._panelMessage.Controls.Add(this._buttonOK);
		this._panelMessage.Dock = System.Windows.Forms.DockStyle.Fill;
		this._panelMessage.Location = new System.Drawing.Point(0, 0);
		this._panelMessage.Name = "_panelMessage";
		this._panelMessage.Size = new System.Drawing.Size(357, 118);
		this._panelMessage.TabIndex = 0;
		this._textBoxResponse.Location = new System.Drawing.Point(12, 86);
		this._textBoxResponse.Name = "_textBoxResponse";
		this._textBoxResponse.Size = new System.Drawing.Size(333, 20);
		this._textBoxResponse.TabIndex = 0;
		this._labelPrompt.AutoSize = false;
		this._labelPrompt.Font = new System.Drawing.Font("Segoe UI", 9f);
		this._labelPrompt.ForeColor = System.Drawing.Color.FromArgb(30, 57, 91);
		this._labelPrompt.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
		this._labelPrompt.Location = new System.Drawing.Point(12, 12);
		this._labelPrompt.Margin = new System.Windows.Forms.Padding(0);
		this._labelPrompt.Name = "_labelPrompt";
		this._labelPrompt.Size = new System.Drawing.Size(78, 15);
		this._labelPrompt.Text = "Prompt";
		this._buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this._buttonCancel.AutoSize = true;
		this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this._buttonCancel.Location = new System.Drawing.Point(295, 43);
		this._buttonCancel.Margin = new System.Windows.Forms.Padding(0);
		this._buttonCancel.MinimumSize = new System.Drawing.Size(50, 26);
		this._buttonCancel.Name = "_buttonCancel";
		this._buttonCancel.Size = new System.Drawing.Size(50, 26);
		this._buttonCancel.TabIndex = 2;
		this._buttonCancel.Values.Text = "Cancel";
		this._buttonCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(button_keyDown);
		this._buttonOK.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this._buttonOK.AutoSize = true;
		this._buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
		this._buttonOK.Location = new System.Drawing.Point(295, 12);
		this._buttonOK.Margin = new System.Windows.Forms.Padding(0);
		this._buttonOK.MinimumSize = new System.Drawing.Size(50, 26);
		this._buttonOK.Name = "_buttonOK";
		this._buttonOK.Size = new System.Drawing.Size(50, 26);
		this._buttonOK.TabIndex = 1;
		this._buttonOK.Values.Text = "OK";
		this._buttonOK.KeyDown += new System.Windows.Forms.KeyEventHandler(button_keyDown);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(357, 118);
		base.Controls.Add(this._panelMessage);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "KryptonInputBox";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		((System.ComponentModel.ISupportInitialize)this._panelMessage).EndInit();
		this._panelMessage.ResumeLayout(false);
		this._panelMessage.PerformLayout();
		base.ResumeLayout(false);
	}
}
