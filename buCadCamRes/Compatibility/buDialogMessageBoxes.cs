using System;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.DialogBox
{
    internal static class CompatibilityDialogLayout
    {
        public static void Configure(Form form, Label messageLabel, string caption, string message,
            int requestedWidth, int requestedHeight, Color headerColor, Color messageColor)
        {
            form.Text = caption ?? string.Empty;
            form.StartPosition = FormStartPosition.CenterParent;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.ShowInTaskbar = false;
            form.BackColor = headerColor;
            form.ClientSize = new Size(requestedWidth > 10 ? requestedWidth : 440,
                                       requestedHeight > 10 ? requestedHeight : 180);

            messageLabel.Text = message ?? string.Empty;
            messageLabel.BackColor = messageColor;
            messageLabel.ForeColor = Color.Black;
            messageLabel.Padding = new Padding(14);
            messageLabel.AutoEllipsis = true;
            messageLabel.TextAlign = ContentAlignment.MiddleCenter;
            messageLabel.Dock = DockStyle.Fill;
        }
    }

    public class buDialogMessageBoxOk : Form
    {
        public string Caption = "MessageBox";
        public string Message = string.Empty;
        public int FormWidth;
        public int FormHeight;
        public Color ColorHeader = Color.LightBlue;
        public Color ColorBaseFirst = Color.Black;
        public Color ColorBaseSecond = Color.DarkGray;
        public Color ColorMessage = Color.Silver;
        public Color ColorBottomYes = Color.LightGray;
        public Color ColorBottomNo = Color.LightGray;
        public DialogResult Result = DialogResult.None;

        private readonly Label messageLabel = new Label();
        private readonly Button okButton = new Button();
        private readonly Panel bottomPanel = new Panel();

        public buDialogMessageBoxOk()
        {
            bottomPanel.Height = 50;
            bottomPanel.Dock = DockStyle.Bottom;
            okButton.Text = "OK";
            okButton.Width = 100;
            okButton.Height = 30;
            okButton.Anchor = AnchorStyles.None;
            okButton.Click += (s, e) => Complete(DialogResult.OK);
            bottomPanel.Controls.Add(okButton);
            bottomPanel.Resize += (s, e) =>
            {
                okButton.Left = Math.Max(0, (bottomPanel.ClientSize.Width - okButton.Width) / 2);
                okButton.Top = Math.Max(0, (bottomPanel.ClientSize.Height - okButton.Height) / 2);
            };
            Controls.Add(messageLabel);
            Controls.Add(bottomPanel);
            AcceptButton = okButton;
        }

        public void Init() => ApplyAppearance(Caption, Message);

        public void Init(string info, string message)
        {
            Caption = info ?? string.Empty;
            Message = message ?? string.Empty;
            ApplyAppearance(Caption, Message);
        }

        public void SetColors() => ApplyAppearance(Caption, Message);

        private void ApplyAppearance(string caption, string message)
        {
            CompatibilityDialogLayout.Configure(this, messageLabel, caption, message,
                FormWidth, FormHeight, ColorHeader, ColorMessage);
            bottomPanel.BackColor = ColorBaseSecond;
            okButton.BackColor = ColorBottomYes;
        }

        private void Complete(DialogResult result)
        {
            Result = result;
            DialogResult = result;
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (Result == DialogResult.None)
                Result = DialogResult.OK;
            base.OnFormClosing(e);
        }
    }

    public class buDialogMessageBoxYesNo : Form
    {
        public string Caption = "MessageBox";
        public string Message = string.Empty;
        public int FormWidth;
        public int FormHeight;
        public Color ColorHeader = Color.LightBlue;
        public Color ColorBaseFirst = Color.Black;
        public Color ColorBaseSecond = Color.DarkGray;
        public Color ColorMessage = Color.Silver;
        public Color ColorBottomYes = Color.LightGray;
        public Color ColorBottomNo = Color.LightGray;
        public DialogResult Result = DialogResult.None;

        private readonly Label messageLabel = new Label();
        private readonly Button yesButton = new Button();
        private readonly Button noButton = new Button();
        private readonly FlowLayoutPanel bottomPanel = new FlowLayoutPanel();

        public buDialogMessageBoxYesNo()
        {
            bottomPanel.Height = 50;
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.FlowDirection = FlowDirection.LeftToRight;
            bottomPanel.WrapContents = false;
            bottomPanel.Padding = new Padding(105, 9, 8, 8);

            yesButton.Text = "Yes";
            noButton.Text = "No";
            yesButton.Width = noButton.Width = 100;
            yesButton.Height = noButton.Height = 30;
            yesButton.Click += (s, e) => Complete(DialogResult.Yes);
            noButton.Click += (s, e) => Complete(DialogResult.No);
            bottomPanel.Controls.Add(yesButton);
            bottomPanel.Controls.Add(noButton);

            Controls.Add(messageLabel);
            Controls.Add(bottomPanel);
            AcceptButton = yesButton;
            CancelButton = noButton;
        }

        public void Init() => ApplyAppearance(Caption, Message);

        public void Init(string info, string message)
        {
            Caption = info ?? string.Empty;
            Message = message ?? string.Empty;
            ApplyAppearance(Caption, Message);
        }

        public void SetColors() => ApplyAppearance(Caption, Message);

        private void ApplyAppearance(string caption, string message)
        {
            CompatibilityDialogLayout.Configure(this, messageLabel, caption, message,
                FormWidth, FormHeight, ColorHeader, ColorMessage);
            bottomPanel.BackColor = ColorBaseSecond;
            yesButton.BackColor = ColorBottomYes;
            noButton.BackColor = ColorBottomNo;
        }

        private void Complete(DialogResult result)
        {
            Result = result;
            DialogResult = result;
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (Result == DialogResult.None)
                Result = DialogResult.No;
            base.OnFormClosing(e);
        }
    }
}
