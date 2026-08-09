using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms;

public class RibbonHost : RibbonItem
{
	public delegate void RibbonHostSizeModeHandledEventHandler(object sender, RibbonHostSizeModeHandledEventArgs e);

	private Control ctl;

	private Font ctlFont;

	private Size ctlSize;

	private RibbonElementSizeMode _lastSizeMode;

	public Control HostedControl
	{
		get
		{
			return ctl;
		}
		set
		{
			ctl = value;
			NotifyOwnerRegionsChanged();
			if (ctl != null && Site == null)
			{
				ctlFont = ctl.Font;
				ctlSize = ctl.Size;
				ctl.MouseMove += ctl_MouseMove;
				CanvasChanged += RibbonHost_CanvasChanged;
				if (base.OwnerTab != null)
				{
					base.Owner.ActiveTabChanged += Owner_ActiveTabChanged;
				}
				if (base.Owner != null)
				{
					base.Owner.Controls.Add(ctl);
				}
				ctl.Font = ctlFont;
				ctl.Visible = false;
			}
		}
	}

	public event MouseEventHandler ClientMouseMove;

	[Description("Occurs when the SizeMode of the Controls container is changing. if you manually set the size of the control you need to set the Handled flag to true.")]
	public event RibbonHostSizeModeHandledEventHandler SizeModeChanging;

	public override void OnPaint(object sender, RibbonElementPaintEventArgs e)
	{
		if (base.Owner == null)
		{
			return;
		}
		StringFormat format = StringFormatFactory.CenterNoWrap(StringTrimming.None);
		if (Site != null && Site.DesignMode)
		{
			base.Owner.Renderer.OnRenderRibbonItemText(new RibbonTextEventArgs(base.Owner, e.Graphics, base.Bounds, this, base.Bounds, Site.Name, format));
			return;
		}
		base.Owner.Renderer.OnRenderRibbonItemText(new RibbonTextEventArgs(base.Owner, e.Graphics, base.Bounds, this, base.Bounds, Text, format));
		if (ctl != null)
		{
			if (ctl.Parent != base.Canvas)
			{
				base.Canvas.Controls.Add(ctl);
			}
			ctl.Location = new Point(base.Bounds.Left, (base.SizeMode == RibbonElementSizeMode.DropDown) ? base.Bounds.Top : base.Bounds.Top);
			ctl.Visible = true;
			ctl.BringToFront();
		}
	}

	public override void SetBounds(Rectangle bounds)
	{
		base.SetBounds(bounds);
	}

	public override Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e)
	{
		if (Site != null && Site.DesignMode && base.Owner != null)
		{
			int width = Convert.ToInt32(e.Graphics.MeasureString(Site.Name, base.Owner.Font).Width);
			int height = 20;
			SetLastMeasuredSize(new Size(width, height));
		}
		else if (ctl == null || !Visible)
		{
			SetLastMeasuredSize(new Size(0, 0));
		}
		else
		{
			ctl.Visible = false;
			if (_lastSizeMode != e.SizeMode)
			{
				_lastSizeMode = e.SizeMode;
				RibbonHostSizeModeHandledEventArgs e2 = new RibbonHostSizeModeHandledEventArgs(e.Graphics, e.SizeMode);
				OnSizeModeChanging(ref e2);
			}
			SetLastMeasuredSize(new Size(ctl.Size.Width, ctl.Size.Height));
		}
		return base.LastMeasuredSize;
	}

	public void HostCompleted()
	{
		OnClick(new MouseEventArgs(MouseButtons.Left, 1, Cursor.Position.X, Cursor.Position.Y, 0));
	}

	public virtual void OnSizeModeChanging(ref RibbonHostSizeModeHandledEventArgs e)
	{
		if (this.SizeModeChanging != null)
		{
			this.SizeModeChanging(this, e);
		}
	}

	private void PlaceControls()
	{
		if (ctl != null && Site == null)
		{
			ctl.Location = new Point(base.Bounds.Left + 1, base.Bounds.Top + 1);
			if (base.Canvas is Ribbon && base.OwnerPanel != null && base.OwnerPanel.SizeMode == RibbonElementSizeMode.Overflow)
			{
				ctl.Visible = false;
			}
		}
	}

	private void ctl_MouseMove(object sender, MouseEventArgs e)
	{
		if (base.OwnerItem == null)
		{
			MouseEventArgs e2 = new MouseEventArgs(e.Button, e.Clicks, base.Owner.PointToClient(ctl.PointToScreen(e.Location)).X, base.Owner.PointToClient(ctl.PointToScreen(e.Location)).Y, e.Delta);
			base.Owner.OnRibbonHostMouseMove(e2);
		}
		else
		{
			MouseEventArgs e3 = new MouseEventArgs(e.Button, e.Clicks, base.Bounds.Left + e.X, base.Bounds.Top + e.Y, e.Delta);
			if (this.ClientMouseMove != null)
			{
				this.ClientMouseMove(this, e3);
			}
		}
		OnMouseMove(e);
	}

	private void Owner_ActiveTabChanged(object sender, EventArgs e)
	{
		if (ctl != null && base.OwnerTab != null && base.Owner.ActiveTab != base.OwnerTab)
		{
			ctl.Visible = false;
		}
	}

	private void RibbonHost_CanvasChanged(object sender, EventArgs e)
	{
		if (ctl != null)
		{
			base.Canvas.Controls.Add(ctl);
			ctl.Font = ctlFont;
		}
	}

	internal override void SetSizeMode(RibbonElementSizeMode sizeMode)
	{
		base.SetSizeMode(sizeMode);
		if (ctl != null && base.OwnerPanel != null && base.OwnerPanel.SizeMode == RibbonElementSizeMode.Overflow)
		{
			ctl.Visible = false;
		}
	}
}
