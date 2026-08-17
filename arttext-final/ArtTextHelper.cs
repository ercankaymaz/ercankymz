using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;
using buClass;
using buControls.Forms.WinControlForms.Drawings;

namespace CMDStoneCAM.ArtText
{
    // Drop-in subclass for the application's existing vector-text editor.  The
    // caller can continue treating this object as F_VectorText, while this form
    // provides the replacement Text Studio UI and writes the result back to the
    // inherited TextData/Result members used by the existing Marble CAM pipeline.
    public sealed class F_ArtTextStudio : F_VectorText
    {
        private TextBox txtText;
        private ComboBox cmbFont;
        private ComboBox cmbAlignment;
        private NumericUpDown numHeight;
        private CheckBox chkBold;
        private CheckBox chkItalic;
        private CheckBox chkVectorCurve;
        private Panel previewPanel;
        private Label lblPreviewInfo;
        private Button btnApply;
        private Button btnCancelStudio;
        private Button btnReset;
        private Font previewFont;

        public F_ArtTextStudio() : base()
        {
            BuildStudio();
        }

        public new void Init()
        {
            if (TextData == null)
                TextData = new TextVectorData();

            txtText.Text = string.IsNullOrEmpty(TextData.Text) ? "YAZI" : TextData.Text;

            string fontName = "Arial";
            try
            {
                if (TextData.Font != null && !string.IsNullOrEmpty(TextData.Font.Name))
                    fontName = TextData.Font.Name;
            }
            catch { }

            if (cmbFont.Items.Contains(fontName))
                cmbFont.SelectedItem = fontName;
            else
                cmbFont.Text = fontName;

            decimal h = 30M;
            try
            {
                if (TextData.Height > 0.01)
                    h = ClampDecimal((decimal)TextData.Height, numHeight.Minimum, numHeight.Maximum);
            }
            catch { }
            numHeight.Value = h;

            try
            {
                if (TextData.Font != null)
                {
                    chkBold.Checked = TextData.Font.Bold;
                    chkItalic.Checked = TextData.Font.Italic;
                }
            }
            catch { }

            try { chkVectorCurve.Checked = TextData.DrawAsCurve; }
            catch { chkVectorCurve.Checked = true; }

            try
            {
                ContentAlignment a = TextData.Alignment;
                if (a == ContentAlignment.TopCenter || a == ContentAlignment.MiddleCenter || a == ContentAlignment.BottomCenter)
                    cmbAlignment.SelectedIndex = 1;
                else if (a == ContentAlignment.TopRight || a == ContentAlignment.MiddleRight || a == ContentAlignment.BottomRight)
                    cmbAlignment.SelectedIndex = 2;
                else
                    cmbAlignment.SelectedIndex = 0;
            }
            catch { cmbAlignment.SelectedIndex = 0; }

            Result = DialogResult.None;
            UpdatePreview();
        }

        private static decimal ClampDecimal(decimal value, decimal min, decimal max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        private void BuildStudio()
        {
            SuspendLayout();
            Controls.Clear();
            Text = "CMDStoneCAM - Text Studio";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.Sizable;
            MinimumSize = new Size(920, 620);
            ClientSize = new Size(1050, 680);
            BackColor = Color.FromArgb(242, 244, 247);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);

            Panel header = new Panel();
            header.Dock = DockStyle.Top;
            header.Height = 68;
            header.BackColor = Color.FromArgb(36, 43, 54);
            Controls.Add(header);

            Label title = new Label();
            title.AutoSize = true;
            title.Text = "TEXT STUDIO";
            title.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            title.ForeColor = Color.White;
            title.Location = new Point(22, 11);
            header.Controls.Add(title);

            Label subtitle = new Label();
            subtitle.AutoSize = true;
            subtitle.Text = "Vektör yazı oluşturma ve CAM hazırlığı";
            subtitle.ForeColor = Color.FromArgb(194, 204, 220);
            subtitle.Location = new Point(25, 43);
            header.Controls.Add(subtitle);

            TableLayoutPanel body = new TableLayoutPanel();
            body.Dock = DockStyle.Fill;
            body.Padding = new Padding(18);
            body.ColumnCount = 2;
            body.RowCount = 1;
            body.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 390F));
            body.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            body.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            Controls.Add(body);
            body.BringToFront();

            Panel settingsHost = new Panel();
            settingsHost.Dock = DockStyle.Fill;
            settingsHost.BackColor = Color.White;
            settingsHost.Padding = new Padding(18);
            body.Controls.Add(settingsHost, 0, 0);

            Label settingsTitle = SectionTitle("Yazı Ayarları", 0);
            settingsHost.Controls.Add(settingsTitle);

            Label lText = Caption("Metin", 44);
            settingsHost.Controls.Add(lText);
            txtText = new TextBox();
            txtText.Multiline = true;
            txtText.ScrollBars = ScrollBars.Vertical;
            txtText.Location = new Point(18, 67);
            txtText.Size = new Size(354, 86);
            txtText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtText.TextChanged += ValueChanged;
            settingsHost.Controls.Add(txtText);

            Label lFont = Caption("Yazı tipi", 166);
            settingsHost.Controls.Add(lFont);
            cmbFont = new ComboBox();
            cmbFont.DropDownStyle = ComboBoxStyle.DropDown;
            cmbFont.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbFont.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbFont.Location = new Point(18, 189);
            cmbFont.Size = new Size(354, 29);
            cmbFont.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            foreach (FontFamily ff in FontFamily.Families.OrderBy(f => f.Name))
                cmbFont.Items.Add(ff.Name);
            cmbFont.TextChanged += ValueChanged;
            cmbFont.SelectedIndexChanged += ValueChanged;
            settingsHost.Controls.Add(cmbFont);

            chkBold = new CheckBox();
            chkBold.Text = "Kalın";
            chkBold.Location = new Point(18, 230);
            chkBold.AutoSize = true;
            chkBold.CheckedChanged += ValueChanged;
            settingsHost.Controls.Add(chkBold);

            chkItalic = new CheckBox();
            chkItalic.Text = "İtalik";
            chkItalic.Location = new Point(112, 230);
            chkItalic.AutoSize = true;
            chkItalic.CheckedChanged += ValueChanged;
            settingsHost.Controls.Add(chkItalic);

            chkVectorCurve = new CheckBox();
            chkVectorCurve.Text = "Vektör eğrisi olarak oluştur";
            chkVectorCurve.Location = new Point(202, 230);
            chkVectorCurve.AutoSize = true;
            chkVectorCurve.Checked = true;
            settingsHost.Controls.Add(chkVectorCurve);

            Label lHeight = Caption("Yazı yüksekliği (mm)", 269);
            settingsHost.Controls.Add(lHeight);
            numHeight = new NumericUpDown();
            numHeight.DecimalPlaces = 2;
            numHeight.Minimum = 0.10M;
            numHeight.Maximum = 5000M;
            numHeight.Increment = 1M;
            numHeight.Value = 30M;
            numHeight.Location = new Point(18, 292);
            numHeight.Size = new Size(168, 27);
            numHeight.ValueChanged += ValueChanged;
            settingsHost.Controls.Add(numHeight);

            Label lAlign = Caption("Hizalama", 269);
            lAlign.Left = 204;
            settingsHost.Controls.Add(lAlign);
            cmbAlignment = new ComboBox();
            cmbAlignment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAlignment.Items.AddRange(new object[] { "Sol", "Orta", "Sağ" });
            cmbAlignment.SelectedIndex = 0;
            cmbAlignment.Location = new Point(204, 292);
            cmbAlignment.Size = new Size(168, 29);
            cmbAlignment.SelectedIndexChanged += ValueChanged;
            settingsHost.Controls.Add(cmbAlignment);

            Panel hint = new Panel();
            hint.Location = new Point(18, 346);
            hint.Size = new Size(354, 116);
            hint.BackColor = Color.FromArgb(247, 249, 252);
            settingsHost.Controls.Add(hint);

            Label hintTitle = new Label();
            hintTitle.Text = "Vektör yazı iş akışı";
            hintTitle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            hintTitle.AutoSize = true;
            hintTitle.Location = new Point(12, 11);
            hint.Controls.Add(hintTitle);

            Label hintText = new Label();
            hintText.Text = "Metni ve fontu burada hazırlayın. Oluştur komutundan sonra CMDStoneCAM mevcut mermer yerleştirme ve CAM hattına devam eder.";
            hintText.AutoSize = false;
            hintText.Size = new Size(326, 70);
            hintText.Location = new Point(12, 36);
            hintText.ForeColor = Color.FromArgb(75, 83, 96);
            hint.Controls.Add(hintText);

            btnReset = new Button();
            btnReset.Text = "Varsayılanlar";
            btnReset.Size = new Size(112, 36);
            btnReset.Location = new Point(18, 487);
            btnReset.Click += ResetClicked;
            settingsHost.Controls.Add(btnReset);

            btnCancelStudio = new Button();
            btnCancelStudio.Text = "İptal";
            btnCancelStudio.Size = new Size(92, 36);
            btnCancelStudio.Location = new Point(180, 487);
            btnCancelStudio.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelStudio.Click += CancelClicked;
            settingsHost.Controls.Add(btnCancelStudio);

            btnApply = new Button();
            btnApply.Text = "Yazıyı Oluştur";
            btnApply.Size = new Size(136, 36);
            btnApply.Location = new Point(236, 533);
            btnApply.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnApply.BackColor = Color.FromArgb(45, 108, 223);
            btnApply.ForeColor = Color.White;
            btnApply.FlatStyle = FlatStyle.Flat;
            btnApply.FlatAppearance.BorderSize = 0;
            btnApply.Click += ApplyClicked;
            settingsHost.Controls.Add(btnApply);

            Panel previewHost = new Panel();
            previewHost.Dock = DockStyle.Fill;
            previewHost.Margin = new Padding(16, 0, 0, 0);
            previewHost.BackColor = Color.White;
            previewHost.Padding = new Padding(18);
            body.Controls.Add(previewHost, 1, 0);

            Label previewTitle = SectionTitle("Canlı Önizleme", 0);
            previewHost.Controls.Add(previewTitle);

            previewPanel = new Panel();
            previewPanel.Location = new Point(18, 46);
            previewPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            previewPanel.Size = new Size(590, 502);
            previewPanel.BackColor = Color.WhiteSmoke;
            previewPanel.BorderStyle = BorderStyle.FixedSingle;
            previewPanel.Paint += PreviewPaint;
            previewHost.Controls.Add(previewPanel);

            lblPreviewInfo = new Label();
            lblPreviewInfo.AutoSize = false;
            lblPreviewInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblPreviewInfo.Location = new Point(18, 558);
            lblPreviewInfo.Size = new Size(590, 38);
            lblPreviewInfo.ForeColor = Color.FromArgb(85, 93, 108);
            previewHost.Controls.Add(lblPreviewInfo);

            AcceptButton = btnApply;
            CancelButton = btnCancelStudio;
            FormClosing += StudioClosing;
            ResumeLayout(true);
        }

        private static Label SectionTitle(string text, int top)
        {
            Label l = new Label();
            l.Text = text;
            l.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            l.AutoSize = true;
            l.Location = new Point(18, top + 4);
            l.ForeColor = Color.FromArgb(45, 52, 64);
            return l;
        }

        private static Label Caption(string text, int top)
        {
            Label l = new Label();
            l.Text = text;
            l.AutoSize = true;
            l.Location = new Point(18, top);
            l.ForeColor = Color.FromArgb(75, 83, 96);
            return l;
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void ResetClicked(object sender, EventArgs e)
        {
            txtText.Text = "YAZI";
            cmbFont.Text = "Arial";
            numHeight.Value = 30M;
            cmbAlignment.SelectedIndex = 0;
            chkBold.Checked = false;
            chkItalic.Checked = false;
            chkVectorCurve.Checked = true;
            UpdatePreview();
        }

        private void CancelClicked(object sender, EventArgs e)
        {
            Result = DialogResult.Cancel;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ApplyClicked(object sender, EventArgs e)
        {
            string value = (txtText.Text ?? string.Empty).Trim();
            if (value.Length == 0)
            {
                MessageBox.Show(this, "Yazı boş bırakılamaz.", "Text Studio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtText.Focus();
                return;
            }

            if (TextData == null)
                TextData = new TextVectorData();

            string fontName = string.IsNullOrWhiteSpace(cmbFont.Text) ? "Arial" : cmbFont.Text.Trim();
            FontStyle style = FontStyle.Regular;
            if (chkBold.Checked) style |= FontStyle.Bold;
            if (chkItalic.Checked) style |= FontStyle.Italic;

            try
            {
                Font candidate = new Font(fontName, 12F, style, GraphicsUnit.Point);
                TextData.Font = candidate;
            }
            catch
            {
                TextData.Font = new Font("Arial", 12F, style, GraphicsUnit.Point);
            }

            TextData.Text = value;
            TextData.Height = (double)numHeight.Value;
            TextData.DrawAsCurve = chkVectorCurve.Checked;
            TextData.Alignment = cmbAlignment.SelectedIndex == 1
                ? ContentAlignment.MiddleCenter
                : (cmbAlignment.SelectedIndex == 2 ? ContentAlignment.MiddleRight : ContentAlignment.MiddleLeft);

            Result = DialogResult.OK;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void StudioClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK && Result != DialogResult.OK)
                Result = DialogResult.Cancel;
        }

        private void UpdatePreview()
        {
            if (previewPanel == null) return;
            if (lblPreviewInfo != null)
            {
                string fontName = cmbFont == null || string.IsNullOrWhiteSpace(cmbFont.Text) ? "Arial" : cmbFont.Text;
                decimal h = numHeight == null ? 30M : numHeight.Value;
                lblPreviewInfo.Text = string.Format("Font: {0}   |   Yükseklik: {1:0.##} mm   |   Hizalama: {2}", fontName, h, cmbAlignment == null ? "Sol" : cmbAlignment.Text);
            }
            previewPanel.Invalidate();
        }

        private void PreviewPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            e.Graphics.Clear(Color.FromArgb(250, 251, 253));

            Rectangle r = previewPanel.ClientRectangle;
            using (Pen gridPen = new Pen(Color.FromArgb(232, 236, 242), 1F))
            {
                for (int x = 20; x < r.Width; x += 20) e.Graphics.DrawLine(gridPen, x, 0, x, r.Height);
                for (int y = 20; y < r.Height; y += 20) e.Graphics.DrawLine(gridPen, 0, y, r.Width, y);
            }

            string value = txtText == null ? "YAZI" : txtText.Text;
            if (string.IsNullOrEmpty(value)) value = "YAZI";
            string fontName = cmbFont == null || string.IsNullOrWhiteSpace(cmbFont.Text) ? "Arial" : cmbFont.Text;
            FontStyle style = FontStyle.Regular;
            if (chkBold != null && chkBold.Checked) style |= FontStyle.Bold;
            if (chkItalic != null && chkItalic.Checked) style |= FontStyle.Italic;

            if (previewFont != null) { previewFont.Dispose(); previewFont = null; }
            try { previewFont = new Font(fontName, 52F, style, GraphicsUnit.Pixel); }
            catch { previewFont = new Font("Arial", 52F, style, GraphicsUnit.Pixel); }

            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = cmbAlignment != null && cmbAlignment.SelectedIndex == 1
                ? StringAlignment.Center
                : (cmbAlignment != null && cmbAlignment.SelectedIndex == 2 ? StringAlignment.Far : StringAlignment.Near);

            RectangleF textRect = new RectangleF(28, 28, Math.Max(20, r.Width - 56), Math.Max(20, r.Height - 56));
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(32, 45, 66)))
                e.Graphics.DrawString(value, previewFont, brush, textRect, sf);
            sf.Dispose();
        }
    }
}
