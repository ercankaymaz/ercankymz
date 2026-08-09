using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms;

[ToolboxItem(false)]
public class RibbonPanelPopup : RibbonPopup
{
	private bool _ignoreNext;

	public RibbonMouseSensor Sensor { get; }

	public RibbonPanel Panel { get; }

	internal RibbonPanelPopup(RibbonPanel panel)
	{
		SetStyle(ControlStyles.Opaque, value: false);
		DoubleBuffered = true;
		Sensor = new RibbonMouseSensor(this, panel.Owner, panel.Items)
		{
			PanelLimit = panel
		};
		Panel = panel;
		Panel.PopUp = this;
		panel.Owner.SuspendSensor();
		using (Graphics g = CreateGraphics())
		{
			panel.overflowBoundsBuffer = panel.Bounds;
			Size size = panel.SwitchToSize(this, g, GetSizeMode(panel));
			base.Size = size;
		}
		foreach (RibbonItem item in panel.Items)
		{
			item.SetCanvas(this);
		}
	}

	public RibbonElementSizeMode GetSizeMode(RibbonPanel pnl)
	{
		if (pnl.FlowsTo == RibbonPanelFlowDirection.Right)
		{
			return RibbonElementSizeMode.Medium;
		}
		return RibbonElementSizeMode.Large;
	}

	public void IgnoreNextClickDeactivation()
	{
		_ignoreNext = true;
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		base.OnMouseUp(e);
		if (_ignoreNext)
		{
			_ignoreNext = false;
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		Panel.Owner.Renderer.OnRenderPanelPopupBackground(new RibbonCanvasEventArgs(Panel.Owner, e.Graphics, new Rectangle(Point.Empty, base.ClientSize), this, Panel));
		foreach (RibbonItem item in Panel.Items)
		{
			item.OnPaint(this, new RibbonElementPaintEventArgs(e.ClipRectangle, e.Graphics, RibbonElementSizeMode.Large));
		}
		Panel.Owner.Renderer.OnRenderRibbonPanelBackground(new RibbonPanelRenderEventArgs(Panel.Owner, e.Graphics, e.ClipRectangle, Panel, this));
		Panel.Owner.Renderer.OnRenderRibbonPanelText(new RibbonPanelRenderEventArgs(Panel.Owner, e.Graphics, e.ClipRectangle, Panel, this));
	}

	protected override void OnClosed(EventArgs e)
	{
		foreach (RibbonItem item in Panel.Items)
		{
			item.SetCanvas(null);
		}
		Panel.SetPressed(pressed: false);
		Panel.SetSelected(selected: false);
		Panel.Owner.UpdateRegions();
		Panel.Owner.Refresh();
		Panel.PopUp = null;
		Panel.Owner.ResumeSensor();
		Panel.PopupShowed = false;
		Panel.Owner.RedrawArea(Panel.Bounds);
		base.OnClosed(e);
	}
}
