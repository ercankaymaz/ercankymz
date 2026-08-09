using System.ComponentModel;
using System.Diagnostics;
using System.Security.Permissions;
using System.Windows.Forms.RibbonHelpers;

namespace System.Windows.Forms;

public class RibbonForm : Form, IRibbonForm
{
	private bool? _isopeninvisualstudiodesigner;

	protected override CreateParams CreateParams
	{
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		get
		{
			CreateParams createParams = base.CreateParams;
			if (!IsOpenInVisualStudioDesigner() && WinApi.IsWindows && !WinApi.IsGlassEnabled)
			{
				createParams.Style |= 917504;
			}
			return createParams;
		}
	}

	public RibbonFormHelper Helper { get; }

	public RibbonForm()
	{
		if (!IsOpenInVisualStudioDesigner())
		{
			if (WinApi.IsWindows && !WinApi.IsGlassEnabled)
			{
				base.FormBorderStyle = FormBorderStyle.None;
				SetStyle(ControlStyles.ResizeRedraw, value: true);
				SetStyle(ControlStyles.Opaque, WinApi.IsGlassEnabled);
				SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
				DoubleBuffered = true;
			}
			Helper = new RibbonFormHelper(this);
		}
	}

	protected bool IsOpenInVisualStudioDesigner()
	{
		if (!_isopeninvisualstudiodesigner.HasValue)
		{
			_isopeninvisualstudiodesigner = LicenseManager.UsageMode == LicenseUsageMode.Designtime || base.DesignMode;
			if (!_isopeninvisualstudiodesigner.Value)
			{
				try
				{
					using Process process = Process.GetCurrentProcess();
					_isopeninvisualstudiodesigner = process.ProcessName.ToLowerInvariant().Contains("devenv");
				}
				catch
				{
				}
			}
		}
		return _isopeninvisualstudiodesigner.Value;
	}

	protected override void OnNotifyMessage(Message m)
	{
		base.OnNotifyMessage(m);
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
	protected override void WndProc(ref Message m)
	{
		if (IsOpenInVisualStudioDesigner())
		{
			base.WndProc(ref m);
		}
		else if (!Helper.WndProc(ref m))
		{
			base.WndProc(ref m);
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		if (IsOpenInVisualStudioDesigner())
		{
			base.OnPaint(e);
		}
		else
		{
			Helper.Form_Paint(this, e);
		}
	}
}
