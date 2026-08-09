using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Permissions;
using System.Windows.Forms.RibbonHelpers;

namespace System.Windows.Forms;

[ToolboxItem(false)]
public class RibbonPopup : Control
{
	[Browsable(false)]
	public int BorderRoundness { get; set; }

	internal RibbonWrappedDropDown WrappedDropDown { get; set; }

	protected override CreateParams CreateParams
	{
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		get
		{
			CreateParams createParams = base.CreateParams;
			if (WinApi.IsXP)
			{
				createParams.ClassStyle |= 131072;
			}
			return createParams;
		}
	}

	public event EventHandler Showed;

	public event EventHandler Closed;

	public event ToolStripDropDownClosingEventHandler Closing;

	public event CancelEventHandler Opening;

	public RibbonPopup()
	{
		SetStyle(ControlStyles.Opaque, value: true);
		SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
		SetStyle(ControlStyles.UserPaint, value: true);
		SetStyle(ControlStyles.Selectable, value: false);
		BorderRoundness = 3;
	}

	public void Show(Point screenLocation)
	{
		if (WrappedDropDown == null)
		{
			ToolStripControlHost toolStripControlHost = new ToolStripControlHost(this);
			WrappedDropDown = new RibbonWrappedDropDown
			{
				AutoClose = (RibbonDesigner.Current != null)
			};
			WrappedDropDown.Items.Add(toolStripControlHost);
			WrappedDropDown.Padding = Padding.Empty;
			WrappedDropDown.Margin = Padding.Empty;
			toolStripControlHost.Padding = Padding.Empty;
			toolStripControlHost.Margin = Padding.Empty;
			WrappedDropDown.Opening += ToolStripDropDown_Opening;
			WrappedDropDown.Closing += ToolStripDropDown_Closing;
			WrappedDropDown.Closed += ToolStripDropDown_Closed;
			WrappedDropDown.Size = base.Size;
		}
		WrappedDropDown.Show(screenLocation);
		RibbonPopupManager.Register(this);
		OnShowed(EventArgs.Empty);
	}

	private void ToolStripDropDown_Opening(object sender, CancelEventArgs e)
	{
		OnOpening(e);
	}

	protected virtual void OnOpening(CancelEventArgs e)
	{
		if (this.Opening != null)
		{
			this.Opening(this, e);
		}
	}

	private void ToolStripDropDown_Closing(object sender, ToolStripDropDownClosingEventArgs e)
	{
		OnClosing(e);
	}

	private void ToolStripDropDown_Closed(object sender, ToolStripDropDownClosedEventArgs e)
	{
		OnClosed(EventArgs.Empty);
	}

	public void Close()
	{
		if (WrappedDropDown != null)
		{
			WrappedDropDown.Close();
		}
	}

	protected virtual void OnClosing(ToolStripDropDownClosingEventArgs e)
	{
		if (this.Closing != null)
		{
			this.Closing(this, e);
		}
	}

	protected virtual void OnClosed(EventArgs e)
	{
		RibbonPopupManager.Unregister(this);
		if (this.Closed != null)
		{
			this.Closed(this, e);
		}
	}

	protected virtual void OnShowed(EventArgs e)
	{
		if (this.Showed != null)
		{
			this.Showed(this, e);
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		using GraphicsPath path = RibbonProfessionalRenderer.RoundRectangle(new Rectangle(Point.Empty, base.Size), BorderRoundness);
		using Region region = new Region(path);
		WrappedDropDown.Region = region;
	}
}
