using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms.RibbonHelpers;

namespace System.Windows.Forms;

public class RibbonFormHelper
{
	public enum NonClientHitTestResult
	{
		Nowhere = 0,
		Client = 1,
		Caption = 2,
		GrowBox = 4,
		MinimizeButton = 8,
		MaximizeButton = 9,
		Left = 10,
		Right = 11,
		Top = 12,
		TopLeft = 13,
		TopRight = 14,
		Bottom = 15,
		BottomLeft = 16,
		BottomRight = 17
	}

	private FormWindowState _lastState;

	private bool _frameExtended;

	private Ribbon _ribbon;

	private Size _storeSize;

	public Ribbon Ribbon
	{
		get
		{
			return _ribbon;
		}
		set
		{
			if (_ribbon != null)
			{
				_ribbon.OrbStyleChanged -= RibbonOrbStyleChanged;
			}
			_ribbon = value;
			if (_ribbon != null)
			{
				_ribbon.OrbStyleChanged += RibbonOrbStyleChanged;
			}
			UpdateRibbonConditions();
		}
	}

	public int CaptionHeight { get; set; }

	public Form Form { get; }

	public Padding Margins { get; private set; }

	private bool MarginsChecked { get; set; }

	private bool DesignMode
	{
		get
		{
			if (Form != null && Form.Site != null)
			{
				return Form.Site.DesignMode;
			}
			return false;
		}
	}

	public RibbonFormHelper(Form f)
	{
		Form = f;
		Form.Load += Form_Load;
		Form.ResizeEnd += _form_ResizeEnd;
		Form.MinimumSizeChanged += _form_ResizeEnd;
		Form.MaximumSizeChanged += _form_ResizeEnd;
		Form.Layout += _form_Layout;
		Form.TextChanged += _form_TextChanged;
	}

	private void _form_TextChanged(object sender, EventArgs e)
	{
		UpdateRibbonConditions();
		Form.Refresh();
		Form.Update();
	}

	private void _form_Layout(object sender, LayoutEventArgs e)
	{
		if (_lastState != Form.WindowState)
		{
			if (_storeSize.IsEmpty)
			{
				_storeSize = Form.Size;
			}
			if (WinApi.IsGlassEnabled)
			{
				Form.Invalidate();
			}
			else
			{
				Form.Refresh();
			}
			_lastState = Form.WindowState;
		}
	}

	private void _form_ResizeEnd(object sender, EventArgs e)
	{
		UpdateRibbonConditions();
		Form.Refresh();
	}

	private void UpdateRibbonConditions()
	{
		if (Ribbon != null && Ribbon.Dock != DockStyle.Top)
		{
			Ribbon.Dock = DockStyle.Top;
		}
	}

	public void Form_Paint(object sender, PaintEventArgs e)
	{
		if (DesignMode)
		{
			return;
		}
		if (WinApi.IsGlassEnabled)
		{
			WinApi.FillForGlass(e.Graphics, new Rectangle(0, 0, Form.Width, Form.Height));
			using Brush brush = new SolidBrush(Form.BackColor);
			int left;
			int right;
			if (WinApi.IsWin10)
			{
				left = 0;
				right = Form.Width;
			}
			else
			{
				left = Margins.Left;
				right = Form.Width - Margins.Right;
			}
			e.Graphics.FillRectangle(brush, Rectangle.FromLTRB(left, Margins.Top, right, Form.Height - Margins.Bottom));
			return;
		}
		PaintTitleBar(e);
	}

	private void PaintTitleBar(PaintEventArgs e)
	{
		int num = 4;
		int radius = num;
		Rectangle r = new Rectangle(Point.Empty, Form.Size);
		Rectangle r2 = new Rectangle(Point.Empty, new Size(r.Width - 1, r.Height - 1));
		using GraphicsPath path = RibbonProfessionalRenderer.RoundRectangle(r, num);
		using GraphicsPath path2 = RibbonProfessionalRenderer.RoundRectangle(r2, radius);
		if (Ribbon == null || Ribbon.ActualBorderMode != RibbonWindowMode.NonClientAreaCustomDrawn || !(Ribbon.Renderer is RibbonProfessionalRenderer ribbonProfessionalRenderer))
		{
			return;
		}
		e.Graphics.Clear(ribbonProfessionalRenderer.ColorTable.RibbonBackground);
		using (SolidBrush brush = new SolidBrush(ribbonProfessionalRenderer.ColorTable.Caption1))
		{
			e.Graphics.FillRectangle(brush, new Rectangle(0, 0, Form.Width, Ribbon.CaptionBarSize));
		}
		ribbonProfessionalRenderer.DrawCaptionBarBackground(new Rectangle(0, Margins.Bottom - 1, Form.Width, Ribbon.CaptionBarSize), e.Graphics);
		using Region region = new Region(path);
		Form.Region = region;
		SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
		e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
		using (Pen pen = new Pen(ribbonProfessionalRenderer.ColorTable.FormBorder, 1f))
		{
			e.Graphics.DrawPath(pen, path2);
		}
		e.Graphics.SmoothingMode = smoothingMode;
	}

	private void RibbonOrbStyleChanged(object sender, EventArgs e)
	{
		if (_frameExtended)
		{
			_frameExtended = false;
			Form_Load(sender, e);
		}
	}

	protected virtual void Form_Load(object sender, EventArgs e)
	{
		if (!DesignMode)
		{
			if (Ribbon == null)
			{
				throw new ArgumentNullException("Ribbon", "Ribbon Control was not placed to RibbonForm");
			}
			WinApi.MARGINS marInset = ((!Ribbon.CaptionBarVisible) ? new WinApi.MARGINS(Margins.Left, Margins.Right, Margins.Bottom + Ribbon.ContextSpace + ((Ribbon.OrbStyle != RibbonOrbStyle.Office_2007) ? Ribbon.TabsMargin.Top : 0), Margins.Bottom) : new WinApi.MARGINS(Margins.Left, Margins.Right, Margins.Bottom + Ribbon.ContextSpace + ((Ribbon.OrbStyle == RibbonOrbStyle.Office_2007) ? Ribbon.CaptionBarHeight : (Ribbon.CaptionBarHeight + Ribbon.TabsMargin.Top)), Margins.Bottom));
			if (WinApi.IsWin10)
			{
				marInset.cxLeftWidth = 0;
				marInset.cxRightWidth = 0;
				marInset.cyBottomHeight = 0;
			}
			if (WinApi.IsVista && !_frameExtended)
			{
				WinApi.DwmExtendFrameIntoClientArea(Form.Handle, ref marInset);
				_frameExtended = true;
			}
		}
	}

	public virtual void ReapplyGlass()
	{
		_frameExtended = false;
		Form_Load(this, EventArgs.Empty);
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
	public virtual bool WndProc(ref Message m)
	{
		if (DesignMode)
		{
			return false;
		}
		if (Ribbon == null)
		{
			return false;
		}
		bool flag = false;
		if (WinApi.IsVista && WinApi.DwmDefWindowProc(m.HWnd, m.Msg, m.WParam, m.LParam, out var result) == 1)
		{
			m.Result = result;
			flag = true;
		}
		if (!flag)
		{
			if (m.Msg == 131 && (int)m.WParam == 1)
			{
				WinApi.NCCALCSIZE_PARAMS structure = (WinApi.NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(WinApi.NCCALCSIZE_PARAMS));
				if (!MarginsChecked)
				{
					SetMargins(new Padding(structure.rect2.Left - structure.rect1.Left, structure.rect2.Top - structure.rect1.Top, structure.rect1.Right - structure.rect2.Right, structure.rect1.Bottom - structure.rect2.Bottom));
					MarginsChecked = true;
				}
				if (WinApi.IsWin10)
				{
					structure.rect0.Left += Margins.Left;
					structure.rect0.Right -= Margins.Right;
					structure.rect0.Bottom -= Margins.Bottom;
				}
				if (Screen.AllScreens.Length > 1 && WinApi.IsGlassEnabled)
				{
					structure.rect0.Bottom--;
				}
				Marshal.StructureToPtr(structure, m.LParam, fDeleteOld: false);
				m.Result = IntPtr.Zero;
				flag = true;
			}
			else if (m.Msg == 134 && Ribbon != null && Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaCustomDrawn)
			{
				Ribbon.Invalidate();
				flag = true;
				if (m.WParam == IntPtr.Zero)
				{
					m.Result = (IntPtr)1;
				}
			}
			else if ((m.Msg == 6 || m.Msg == 15) && WinApi.IsVista)
			{
				m.Result = (IntPtr)1;
				flag = false;
			}
			else if (m.Msg == 132 && (int)m.Result == 0)
			{
				m.Result = new IntPtr(Convert.ToInt32(NonClientHitTest(new Point(WinApi.LoWord((int)m.LParam), WinApi.HiWord((int)m.LParam)))));
				flag = true;
			}
			else if (m.Msg == 165)
			{
				int xMouse = WinApi.Get_X_LParam((int)m.LParam);
				int yMouse = WinApi.Get_Y_LParam((int)m.LParam);
				int num = WinApi.LoWord((int)m.WParam);
				if (num == 2 || num == 3)
				{
					WinApi.ShowSystemMenu(Form, xMouse, yMouse);
					flag = true;
				}
			}
			else if (m.Msg == 274)
			{
				if (((int)((IntPtr.Size == 4) ? m.WParam.ToInt32() : m.WParam.ToInt64()) & 0xFFF0) == 61728)
				{
					Form.Size = _storeSize;
				}
				else if (Form.WindowState == FormWindowState.Normal)
				{
					_storeSize = Form.Size;
				}
			}
			else if ((m.Msg == 70 || m.Msg == 71) && Ribbon != null)
			{
				Ribbon.Invalidate();
			}
		}
		return flag;
	}

	public virtual NonClientHitTestResult NonClientHitTest(Point hitPoint)
	{
		int x = 0;
		int num = 0;
		if (WinApi.IsWin10)
		{
			x = -Margins.Left;
			num = -Margins.Right;
		}
		if (Form.RectangleToScreen(new Rectangle(x, 0, Margins.Left, Margins.Left)).Contains(hitPoint))
		{
			return NonClientHitTestResult.TopLeft;
		}
		if (Form.RectangleToScreen(new Rectangle(num + Form.Width - Margins.Right, 0, Margins.Right, Margins.Right)).Contains(hitPoint))
		{
			return NonClientHitTestResult.TopRight;
		}
		if (Form.RectangleToScreen(new Rectangle(x, Form.Height - Margins.Bottom, Margins.Left, Margins.Bottom)).Contains(hitPoint))
		{
			return NonClientHitTestResult.BottomLeft;
		}
		if (Form.RectangleToScreen(new Rectangle(num + Form.Width - Margins.Right, Form.Height - Margins.Bottom, Margins.Right, Margins.Bottom)).Contains(hitPoint))
		{
			return NonClientHitTestResult.BottomRight;
		}
		if (Form.RectangleToScreen(new Rectangle(0, 0, Form.Width, Margins.Left)).Contains(hitPoint))
		{
			return NonClientHitTestResult.Top;
		}
		if (Form.RectangleToScreen(new Rectangle(0, Margins.Left, Form.Width, Margins.Top - Margins.Left)).Contains(hitPoint))
		{
			return NonClientHitTestResult.Caption;
		}
		if (Form.RectangleToScreen(new Rectangle(x, 0, Margins.Left, Form.Height)).Contains(hitPoint))
		{
			return NonClientHitTestResult.Left;
		}
		if (Form.RectangleToScreen(new Rectangle(num + Form.Width - Margins.Right, 0, Margins.Right, Form.Height)).Contains(hitPoint))
		{
			return NonClientHitTestResult.Right;
		}
		if (Form.RectangleToScreen(new Rectangle(0, Form.Height - Margins.Bottom, Form.Width, Margins.Bottom)).Contains(hitPoint))
		{
			return NonClientHitTestResult.Bottom;
		}
		return NonClientHitTestResult.Client;
	}

	private void SetMargins(Padding p)
	{
		Margins = p;
		Padding padding = p;
		padding.Top = p.Bottom - 1;
		if (!DesignMode)
		{
			if (WinApi.IsWin10)
			{
				padding.Left = 0;
				padding.Right = 0;
				padding.Bottom = 0;
			}
			Form.Padding = padding;
		}
	}
}
