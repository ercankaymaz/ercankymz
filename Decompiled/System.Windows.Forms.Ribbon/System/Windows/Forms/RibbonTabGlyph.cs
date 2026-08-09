using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms.Design.Behavior;

namespace System.Windows.Forms;

public class RibbonTabGlyph : Glyph
{
	private readonly BehaviorService _behaviorService;

	private readonly Ribbon _ribbon;

	private RibbonDesigner _componentDesigner;

	private Rectangle _bounds;

	public override Rectangle Bounds
	{
		get
		{
			Point pos = _behaviorService.ControlToAdornerWindow(_ribbon);
			_bounds = new Rectangle(5, _ribbon.OrbBounds.Bottom + 5, 60, 16);
			if (_ribbon.Tabs.Count > 0)
			{
				RibbonTab ribbonTab = _ribbon.Tabs[_ribbon.Tabs.Count - 1];
				_bounds = _ribbon.LayoutHelper.CalcNewPosition(ribbonTab.Bounds, _bounds, LayoutHelper.RTLLayoutPosition.Far, 5);
				_bounds.Y = ribbonTab.Bounds.Top + 2;
			}
			foreach (RibbonContext context in _ribbon.Contexts)
			{
				if (context.ContextualTabsCount == 0)
				{
					_bounds = _ribbon.LayoutHelper.CalcNewPosition(context.Bounds, _bounds, LayoutHelper.RTLLayoutPosition.Far, 5);
				}
			}
			_bounds.Offset(pos);
			return _bounds;
		}
	}

	public RibbonTabGlyph(BehaviorService behaviorService, RibbonDesigner designer, Ribbon ribbon)
		: base(new RibbonTabGlyphBehavior(designer, ribbon))
	{
		_behaviorService = behaviorService;
		_componentDesigner = designer;
		_ribbon = ribbon;
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
		using (GraphicsPath path = RibbonProfessionalRenderer.RoundRectangle(Bounds, 2))
		{
			using SolidBrush brush = new SolidBrush(Color.FromArgb(50, Color.Blue));
			pe.Graphics.FillPath(brush, path);
		}
		StringFormat format = StringFormatFactory.Center();
		pe.Graphics.DrawString("Add Tab", SystemFonts.DefaultFont, Brushes.White, Bounds, format);
		pe.Graphics.SmoothingMode = smoothingMode;
	}
}
