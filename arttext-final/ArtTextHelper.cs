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
    public sealed class F_ArtTextStudio : F_VectorText
    {
        TextBox txt;
        ComboBox fonts, align;
        NumericUpDown height;
        CheckBox bold, italic, curves;
        Panel preview;
        Label info;

        public F_ArtTextStudio() : base() { BuildUi(); }

        public new void Init()
        {
            if (TextData == null) TextData = new TextVectorData();
            txt.Text = string.IsNullOrWhiteSpace(TextData.Text) ? "YAZI" : TextData.Text;
            string fn = "Arial";
            try { if (TextData.Font != null && !string.IsNullOrWhiteSpace(TextData.Font.Name)) fn = TextData.Font.Name; } catch { }
            fonts.Text = fn;
            try
            {
                decimal v = (decimal)TextData.Height;
                if (v < height.Minimum) v = height.Minimum;
                if (v > height.Maximum) v = height.Maximum;
                if (v > 0) height.Value = v;
            } catch { }
            try { bold.Checked = TextData.Font != null && TextData.Font.Bold; italic.Checked = TextData.Font != null && TextData.Font.Italic; } catch { }
            try { curves.Checked = TextData.DrawAsCurve; } catch { curves.Checked = true; }
            try
            {
                var a = TextData.Alignment;
                if (a == ContentAlignment.TopCenter || a == ContentAlignment.MiddleCenter || a == ContentAlignment.BottomCenter) align.SelectedIndex = 1;
                else if (a == ContentAlignment.TopRight || a == ContentAlignment.MiddleRight || a == ContentAlignment.BottomRight) align.SelectedIndex = 2;
                else align.SelectedIndex = 0;
            } catch { align.SelectedIndex = 0; }
            Result = DialogResult.None;
            RefreshPreview();
        }

        void BuildUi()
        {
            SuspendLayout();
            Controls.Clear();
            Text = "CMDStoneCAM - Text Studio";
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(980, 640);
            ClientSize = new Size(1080, 700);
            BackColor = Color.FromArgb(238, 241, 246);
            Font = new Font("Segoe UI", 9F);

            var top = new Panel { Dock = DockStyle.Top, Height = 72, BackColor = Color.FromArgb(34, 41, 52) };
            var title = new Label { Text = "TEXT STUDIO", ForeColor = Color.White, AutoSize = true, Font = new Font("Segoe UI Semibold", 19F, FontStyle.Bold), Location = new Point(22, 9) };
            var sub = new Label { Text = "Profesyonel vektör yazı hazırlama", ForeColor = Color.FromArgb(190, 200, 216), AutoSize = true, Location = new Point(25, 45) };
            top.Controls.Add(title); top.Controls.Add(sub); Controls.Add(top);

            var body = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(18), ColumnCount = 2, RowCount = 1 };
            body.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 400)); body.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            Controls.Add(body); body.BringToFront();

            var left = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(18) };
            body.Controls.Add(left, 0, 0);
            AddLabel(left, "Metin", 18, 18);
            txt = new TextBox { Multiline = true, ScrollBars = ScrollBars.Vertical, Location = new Point(18, 43), Size = new Size(364, 100), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            left.Controls.Add(txt);

            AddLabel(left, "Yazı tipi", 18, 158);
            fonts = new ComboBox { Location = new Point(18, 183), Size = new Size(364, 28), DropDownStyle = ComboBoxStyle.DropDown, AutoCompleteMode = AutoCompleteMode.SuggestAppend, AutoCompleteSource = AutoCompleteSource.ListItems };
            foreach (var f in FontFamily.Families.OrderBy(x => x.Name)) fonts.Items.Add(f.Name);
            left.Controls.Add(fonts);

            bold = new CheckBox { Text = "Kalın", Location = new Point(18, 225), AutoSize = true };
            italic = new CheckBox { Text = "İtalik", Location = new Point(100, 225), AutoSize = true };
            curves = new CheckBox { Text = "Vektör eğrisi", Location = new Point(180, 225), AutoSize = true, Checked = true };
            left.Controls.Add(bold); left.Controls.Add(italic); left.Controls.Add(curves);

            AddLabel(left, "Yükseklik (mm)", 18, 266);
            height = new NumericUpDown { Location = new Point(18, 291), Size = new Size(170, 28), DecimalPlaces = 2, Minimum = 0.1M, Maximum = 5000M, Value = 30M };
            left.Controls.Add(height);
            AddLabel(left, "Hizalama", 210, 266);
            align = new ComboBox { Location = new Point(210, 291), Size = new Size(172, 28), DropDownStyle = ComboBoxStyle.DropDownList };
            align.Items.AddRange(new object[] { "Sol", "Orta", "Sağ" }); align.SelectedIndex = 0; left.Controls.Add(align);

            var note = new Label { Text = "Metni hazırladıktan sonra Yazıyı Oluştur'a basın. Geometri mevcut CMDStoneCAM mermer/CAM yerleştirme hattına aktarılır.", Location = new Point(18, 345), Size = new Size(364, 70), ForeColor = Color.FromArgb(80, 88, 102) };
            left.Controls.Add(note);

            var reset = new Button { Text = "Varsayılanlar", Location = new Point(18, 455), Size = new Size(112, 38) };
            var cancel = new Button { Text = "İptal", Location = new Point(154, 455), Size = new Size(92, 38) };
            var ok = new Button { Text = "Yazıyı Oluştur", Location = new Point(254, 455), Size = new Size(128, 38), BackColor = Color.FromArgb(45, 108, 223), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            ok.FlatAppearance.BorderSize = 0;
            left.Controls.Add(reset); left.Controls.Add(cancel); left.Controls.Add(ok);

            var right = new Panel { Dock = DockStyle.Fill, Margin = new Padding(16, 0, 0, 0), BackColor = Color.White, Padding = new Padding(18) };
            body.Controls.Add(right, 1, 0);
            var ph = new Label { Text = "Canlı Önizleme", AutoSize = true, Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold), Location = new Point(18, 14) };
            right.Controls.Add(ph);
            preview = new Panel { Location = new Point(18, 48), Size = new Size(590, 500), Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right, BackColor = Color.WhiteSmoke, BorderStyle = BorderStyle.FixedSingle };
            info = new Label { Location = new Point(18, 560), Size = new Size(590, 35), Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right, ForeColor = Color.FromArgb(80, 88, 102) };
            right.Controls.Add(preview); right.Controls.Add(info);

            txt.TextChanged += delegate { RefreshPreview(); };
            fonts.TextChanged += delegate { RefreshPreview(); };
            bold.CheckedChanged += delegate { RefreshPreview(); };
            italic.CheckedChanged += delegate { RefreshPreview(); };
            height.ValueChanged += delegate { RefreshPreview(); };
            align.SelectedIndexChanged += delegate { RefreshPreview(); };
            preview.Paint += PaintPreview;
            reset.Click += delegate { txt.Text = "YAZI"; fonts.Text = "Arial"; height.Value = 30M; align.SelectedIndex = 0; bold.Checked = italic.Checked = false; curves.Checked = true; };
            cancel.Click += delegate { Result = DialogResult.Cancel; DialogResult = DialogResult.Cancel; Close(); };
            ok.Click += Apply;
            FormClosing += delegate { if (DialogResult == DialogResult.OK) Result = DialogResult.OK; else if (Result != DialogResult.OK) Result = DialogResult.Cancel; };
            AcceptButton = ok; CancelButton = cancel;
            ResumeLayout(true);
        }

        static void AddLabel(Control c, string text, int x, int y) { c.Controls.Add(new Label { Text = text, AutoSize = true, Location = new Point(x, y), ForeColor = Color.FromArgb(70, 78, 92) }); }

        void Apply(object sender, EventArgs e)
        {
            string s = (txt.Text ?? "").Trim();
            if (s.Length == 0) { MessageBox.Show(this, "Yazı boş bırakılamaz.", "Text Studio", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (TextData == null) TextData = new TextVectorData();
            FontStyle fs = FontStyle.Regular; if (bold.Checked) fs |= FontStyle.Bold; if (italic.Checked) fs |= FontStyle.Italic;
            try { TextData.Font = new Font(string.IsNullOrWhiteSpace(fonts.Text) ? "Arial" : fonts.Text, 12F, fs); } catch { TextData.Font = new Font("Arial", 12F, fs); }
            TextData.Text = s; TextData.Height = (double)height.Value; TextData.DrawAsCurve = curves.Checked;
            TextData.Alignment = align.SelectedIndex == 1 ? ContentAlignment.MiddleCenter : (align.SelectedIndex == 2 ? ContentAlignment.MiddleRight : ContentAlignment.MiddleLeft);
            Result = DialogResult.OK; DialogResult = DialogResult.OK; Close();
        }

        void RefreshPreview() { if (preview != null) preview.Invalidate(); if (info != null) info.Text = string.Format("Font: {0}  |  {1:0.##} mm  |  {2}", fonts == null ? "Arial" : fonts.Text, height == null ? 30M : height.Value, align == null ? "Sol" : align.Text); }

        void PaintPreview(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit; e.Graphics.Clear(Color.FromArgb(250, 251, 253));
            using (var pen = new Pen(Color.FromArgb(232, 236, 242))) { for (int x = 20; x < preview.Width; x += 20) e.Graphics.DrawLine(pen, x, 0, x, preview.Height); for (int y = 20; y < preview.Height; y += 20) e.Graphics.DrawLine(pen, 0, y, preview.Width, y); }
            FontStyle fs = FontStyle.Regular; if (bold != null && bold.Checked) fs |= FontStyle.Bold; if (italic != null && italic.Checked) fs |= FontStyle.Italic;
            Font f; try { f = new Font(string.IsNullOrWhiteSpace(fonts.Text) ? "Arial" : fonts.Text, 52F, fs, GraphicsUnit.Pixel); } catch { f = new Font("Arial", 52F, fs, GraphicsUnit.Pixel); }
            using (f) using (var b = new SolidBrush(Color.FromArgb(32, 45, 66))) using (var sf = new StringFormat()) { sf.LineAlignment = StringAlignment.Center; sf.Alignment = align.SelectedIndex == 1 ? StringAlignment.Center : (align.SelectedIndex == 2 ? StringAlignment.Far : StringAlignment.Near); e.Graphics.DrawString(string.IsNullOrEmpty(txt.Text) ? "YAZI" : txt.Text, f, b, new RectangleF(28, 28, preview.Width - 56, preview.Height - 56), sf); }
        }
    }
}
