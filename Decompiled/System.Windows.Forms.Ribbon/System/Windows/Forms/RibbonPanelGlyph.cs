using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms.Design.Behavior;

namespace System.Windows.Forms;

public class RibbonPanelGlyph : Glyph
{
	private readonly BehaviorService _behaviorService;

	private readonly RibbonTab _tab;

	private RibbonTabDesigner _componentDesigner;

	private readonly Size size;

	public override Rectangle Bounds
	{
		get
		{
			if (!_tab.Active || !_tab.Owner.Tabs.Contains(_tab))
			{
				return Rectangle.Empty;
			}
			Point point = _behaviorService.ControlToAdornerWindow(_tab.Owner);
			Point point2 = new Point(5, _tab.TabBounds.Bottom + 5);
			if (_tab.Panels.Count > 0)
			{
				RibbonPanel ribbonPanel = _tab.Panels[_tab.Panels.Count - 1];
				if (_tab.Owner.RightToLeft == RightToLeft.No)
				{
					point2.X = ribbonPanel.Bounds.Right + 5;
				}
				else
				{
					point2.X = ribbonPanel.Bounds.Left - 5 - size.Width;
				}
			}
			return new Rectangle(point.X + point2.X, point.Y + point2.Y, size.Width, size.Height);
		}
	}

	public RibbonPanelGlyph(BehaviorService behaviorService, RibbonTabDesigner designer, RibbonTab tab)
		: base(new RibbonPanelGlyphBehavior(designer, tab))
	{
		_behaviorService = behaviorService;
		_componentDesigner = designer;
		_tab = tab;
		size = new Size(60, 16);
	}

	public override Cursor GetHitTest(Point p)
	{
		if (Bounds.Contains(p))
		{
			return Cursors.Hand;
		}
		return null;
	}

	public override void Paint(PaintEventArgs pe)
	{
		SmoothingMode smoothingMode = pe.Graphics.SmoothingMode;
		pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
		using (GraphicsPath path = RibbonProfessionalRenderer.RoundRectangle(Bounds, 9))
		{
			using SolidBrush brush = new SolidBrush(Color.FromArgb(50, Color.Blue));
			pe.Graphics.FillPath(brush, path);
		}
		StringFormat format = StringFormatFactory.Center();
		pe.Graphics.DrawString("Add Panel", SystemFonts.DefaultFont, Brushes.White, Bounds, format);
		pe.Graphics.SmoothingMode = smoothingMode;
	}
}
