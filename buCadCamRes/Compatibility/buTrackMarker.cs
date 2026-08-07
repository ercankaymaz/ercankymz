using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls
{
    /// <summary>
    /// Source-compatible replacement for the profile-simulation track marker that is
    /// referenced by the recovered buCadCamRes sources but is absent from the validated
    /// legacy buControls runtime DLL. It intentionally implements only the public surface
    /// used by F_ProfileSim/Class5 and keeps the normal WinForms mouse/value semantics.
    /// </summary>
    [DefaultProperty("Value")]
    [DefaultEvent("ValueChanged")]
    public class buTrackMarker : Control
    {
        public delegate void ValueChangedEventHandler(object sender, double value);
        public event ValueChangedEventHandler ValueChanged;

        public sealed class BorderOptions
        {
            public bool Visible { get; set; } = true;
        }

        public sealed class DisplayOptions
        {
            public Color BackColor { get; set; } = Color.Transparent;
            public BorderOptions Border { get; } = new BorderOptions();
        }

        public sealed class CaptionOptions
        {
            public double HeightPersentage { get; set; } = 50.0;
        }

        public sealed class CheckTickOptions
        {
            public bool Visible { get; set; }
            public DisplayOptions TickDisplay { get; } = new DisplayOptions();
        }

        public sealed class TrackOptions
        {
            public DisplayOptions DoneDisplay { get; } = new DisplayOptions();
            public DisplayOptions DrawerDisplay { get; } = new DisplayOptions();
            public bool ShowPersentage { get; set; }
            public bool ValueShow { get; set; }
        }

        private double minimumValue;
        private double maximumValue = 100.0;
        private double currentValue;
        private double centerHeight = 10.0;
        private bool dragging;

        public buTrackMarker()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.SupportsTransparentBackColor, true);
            Height = 25;
            TabStop = false;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CaptionOptions Caption { get; } = new CaptionOptions();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DisplayOptions CenterDisplay { get; } = new DisplayOptions();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DisplayOptions Display { get; } = new DisplayOptions();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CheckTickOptions CheckTick { get; } = new CheckTickOptions();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TrackOptions Track { get; } = new TrackOptions();

        [DefaultValue(null)]
        public Image Image { get; set; }

        [DefaultValue(typeof(ContentAlignment), "MiddleLeft")]
        public ContentAlignment ImageAlign { get; set; } = ContentAlignment.MiddleLeft;

        [DefaultValue(0d)]
        public double MinimumValue
        {
            get => minimumValue;
            set
            {
                minimumValue = value;
                if (maximumValue < minimumValue)
                    maximumValue = minimumValue;
                SetValue(currentValue, false);
                Invalidate();
            }
        }

        [DefaultValue(100d)]
        public double MaximumValue
        {
            get => maximumValue;
            set
            {
                maximumValue = value;
                if (maximumValue < minimumValue)
                    minimumValue = maximumValue;
                SetValue(currentValue, false);
                Invalidate();
            }
        }

        [DefaultValue(0d)]
        public double Value
        {
            get => currentValue;
            set => SetValue(value, true);
        }

        [DefaultValue(10d)]
        public double CenterHeight
        {
            get => centerHeight;
            set
            {
                centerHeight = Math.Max(2.0, value);
                Invalidate();
            }
        }

        [DefaultValue(true)]
        public bool MouseControlEnable { get; set; } = true;

        [DefaultValue(40)]
        public int CaptionSeperatorValue { get; set; } = 40;

        [DefaultValue("")]
        public string UnitCaption { get; set; } = string.Empty;

        private void SetValue(double value, bool raiseEvent)
        {
            double clamped = Math.Max(minimumValue, Math.Min(maximumValue, value));
            if (Math.Abs(currentValue - clamped) <= 1e-12)
                return;

            currentValue = clamped;
            Invalidate();
            if (raiseEvent)
                ValueChanged?.Invoke(this, currentValue);
        }

        private void SetValueFromMouse(int mouseX)
        {
            if (!MouseControlEnable || Width <= 1 || maximumValue <= minimumValue)
                return;

            double ratio = Math.Max(0.0, Math.Min(1.0, (double)mouseX / (Width - 1)));
            Value = minimumValue + (maximumValue - minimumValue) * ratio;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != MouseButtons.Left || !MouseControlEnable)
                return;
            dragging = true;
            Capture = true;
            SetValueFromMouse(e.X);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (dragging)
                SetValueFromMouse(e.X);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button != MouseButtons.Left)
                return;
            dragging = false;
            Capture = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Rectangle bounds = ClientRectangle;
            if (bounds.Width <= 1 || bounds.Height <= 1)
                return;

            Color baseColor = Display.BackColor == Color.Transparent ? BackColor : Display.BackColor;
            using (Brush background = new SolidBrush(baseColor))
                e.Graphics.FillRectangle(background, bounds);

            int y = Math.Max(0, (int)Math.Round((bounds.Height - centerHeight) / 2.0));
            int h = Math.Max(2, Math.Min(bounds.Height, (int)Math.Round(centerHeight)));
            Rectangle trackRect = new Rectangle(0, y, bounds.Width - 1, h);
            using (Brush track = new SolidBrush(Track.DrawerDisplay.BackColor.IsEmpty ? Color.DimGray : Track.DrawerDisplay.BackColor))
                e.Graphics.FillRectangle(track, trackRect);

            double ratio = maximumValue <= minimumValue ? 0.0 : (currentValue - minimumValue) / (maximumValue - minimumValue);
            int doneWidth = Math.Max(0, Math.Min(trackRect.Width, (int)Math.Round(trackRect.Width * ratio)));
            if (doneWidth > 0)
            {
                Rectangle done = new Rectangle(trackRect.X, trackRect.Y, doneWidth, trackRect.Height);
                using (Brush brush = new SolidBrush(Track.DoneDisplay.BackColor.IsEmpty ? Color.Green : Track.DoneDisplay.BackColor))
                    e.Graphics.FillRectangle(brush, done);
            }

            int markerX = Math.Max(0, Math.Min(bounds.Width - 1, doneWidth));
            Color markerColor = CenterDisplay.BackColor.IsEmpty ? Color.Orange : CenterDisplay.BackColor;
            using (Pen marker = new Pen(markerColor, 2f))
                e.Graphics.DrawLine(marker, markerX, 0, markerX, bounds.Height - 1);

            if (!string.IsNullOrEmpty(Text))
            {
                TextRenderer.DrawText(e.Graphics, Text, Font, bounds, ForeColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
            }

            if (Display.Border.Visible)
                ControlPaint.DrawBorder(e.Graphics, bounds, ForeColor, ButtonBorderStyle.Solid);
        }
    }
}
