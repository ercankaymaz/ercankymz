using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ns27;

namespace buControls.Controls;

[DefaultProperty("Status")]
[DefaultEvent("Click")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class buStatus : buControl
{
	private Timer timer_0 = new Timer();

	private Timer timer_1 = new Timer();

	private ThemeType themeType_0 = ThemeType.Standart;

	private buControlStatus buControlStatus_0 = new buControlStatus();

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlStatus Status
	{
		get
		{
			return buControlStatus_0;
		}
		set
		{
			buControlStatus_0 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
			Invalidate();
		}
	}

	public buStatus()
	{
		try
		{
			Class76.smethod_747();
			base.Display.Parent = this;
			base.Geometry.Parent = this;
			Status.Parent = this;
			Status.Alarm.Parent = this;
			Status.Warning.Parent = this;
			Status.Information.Parent = this;
			Status.Status.Parent = this;
			base.Theme.Parent = this;
			Status.Alarm.BackColor = Color.Red;
			Status.Alarm.Fonts.Alignment = ContentAlignment.MiddleCenter;
			Status.Warning.BackColor = Color.Gold;
			Status.Warning.Fonts.Alignment = ContentAlignment.MiddleCenter;
			Status.Information.BackColor = Color.Blue;
			Status.Information.Fonts.Alignment = ContentAlignment.MiddleCenter;
			Status.Status.BackColor = Color.LightGray;
			Status.Status.Fonts.Alignment = ContentAlignment.MiddleCenter;
			SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			timer_1.Tick += timer_1_Tick;
			timer_0.Tick += timer_0_Tick;
			timer_0.Interval = 2000;
			DoubleBuffered = true;
			base.Size = new Size(166, 40);
		}
		catch (Exception)
		{
		}
	}

	public void ShowWarning(string WarningText)
	{
		Status.WarningText = WarningText;
		Status.ShowWarning = true;
		Invalidate();
	}

	public void ShowInfo(string InfoText)
	{
		Status.InformationText = InfoText;
		Status.ShowInformation = true;
		Invalidate();
	}

	public void ShowInfo(string InfoText, bool TimeEnable)
	{
		Status.InformationText = InfoText;
		Status.ShowInformation = true;
		timer_1.Interval = Status.InformationTime;
		timer_1.Enabled = TimeEnable;
		Invalidate();
	}

	public void HideInfo()
	{
		Status.ShowInformation = false;
		timer_1.Enabled = false;
		Invalidate();
	}

	public void HideWarning()
	{
		Status.ShowWarning = false;
		Invalidate();
	}

	public void HideAlarm()
	{
		Status.ShowAlarm = false;
		Invalidate();
	}

	public void ShowAlarm(string AlarmText)
	{
		Status.AlarmText = AlarmText;
		Status.ShowAlarm = true;
		Status.ShowInformation = false;
		Invalidate();
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		Status.ShowWarning = false;
		timer_0.Enabled = false;
		Invalidate();
	}

	private void timer_1_Tick(object sender, EventArgs e)
	{
		Status.ShowInformation = false;
		timer_1.Enabled = false;
		Invalidate();
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		Invalidate();
		base.OnMouseUp(e);
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		Invalidate();
		base.OnMouseDown(e);
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		Cursor = Cursors.Default;
		Invalidate();
		base.OnMouseMove(e);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		Invalidate();
		base.OnMouseLeave(e);
	}

	protected override void OnTextChanged(EventArgs e)
	{
		Invalidate();
		base.OnTextChanged(e);
	}

	protected override void OnResize(EventArgs e)
	{
		Invalidate();
		base.OnResize(e);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		try
		{
			Graphics Grph = e.Graphics;
			if (base.Theme.Type != themeType_0)
			{
				buControlThemeVars Vars = new buControlThemeVars();
				buControlTheme.UpdateTheme(base.Theme.Type, ref Vars);
				base.Geometry = new buControlGeometry(Vars.Geometry);
				base.Display = new buControlDisplay(Vars.Display);
				Status.Alarm = new buControlDisplay(Vars.Status.Alarm);
				Status.Warning = new buControlDisplay(Vars.Status.Warning);
				Status.Information = new buControlDisplay(Vars.Status.Information);
				Status.Status = new buControlDisplay(Vars.Status.Status);
				base.Display.Parent = this;
				Status.Alarm.Parent = this;
				Status.Warning.Parent = this;
				Status.Information.Parent = this;
				Status.Status.Parent = this;
				Status.Parent = this;
			}
			if (base.Width > 0 && base.Height > 0)
			{
				RectangleF rect = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, base.ClientRectangle.Height);
				if (!Status.ShowWarning & !Status.ShowInformation & !Status.ShowAlarm)
				{
					ControlGeometry.drawGeometry(rect, base.Geometry, Status.Status, RoundRectangleType.RoundRectAll, ref Grph);
					ControlGeometry.drawString(rect, Status.StatusText, Status.Status, ref Grph);
				}
				if (Status.ShowInformation)
				{
					ControlGeometry.drawGeometry(rect, base.Geometry, Status.Information, RoundRectangleType.RoundRectAll, ref Grph);
					ControlGeometry.drawString(rect, Status.InformationText, Status.Information, ref Grph);
				}
				if (Status.ShowAlarm)
				{
					ControlGeometry.drawGeometry(rect, base.Geometry, Status.Alarm, RoundRectangleType.RoundRectAll, ref Grph);
					ControlGeometry.drawString(rect, Status.AlarmText, Status.Alarm, ref Grph);
				}
				if (Status.ShowWarning)
				{
					ControlGeometry.drawGeometry(rect, base.Geometry, Status.Warning, RoundRectangleType.RoundRectAll, ref Grph);
					ControlGeometry.drawString(rect, Status.WarningText, Status.Warning, ref Grph);
				}
			}
			themeType_0 = base.Theme.Type;
			base.OnPaint(e);
		}
		catch (Exception)
		{
		}
	}
}
