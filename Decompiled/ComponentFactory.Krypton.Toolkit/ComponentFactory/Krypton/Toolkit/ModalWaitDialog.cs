using System;
using System.ComponentModel;
using System.Drawing;
using System.Security.Permissions;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit.Properties;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
public class ModalWaitDialog : Form, IMessageFilter
{
	private const int DELAY_SHOWING = 500;

	private const int DELAY_SPIN = 75;

	private const int SPIN_ANGLE = 20;

	private static readonly Bitmap _hourGlass = Resources.HourGlass;

	private bool _startTimestamped;

	private DateTime _startTimestamp;

	private DateTime _spinTimestamp;

	private float _spinAngle;

	private IContainer components = null;

	private Label labelMessage;

	public ModalWaitDialog()
	{
		InitializeComponent();
		SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, value: true);
		Application.AddMessageFilter(this);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		e.Graphics.TranslateTransform(32f, 32f);
		e.Graphics.RotateTransform(_spinAngle);
		e.Graphics.DrawImage(_hourGlass, -16, -16, _hourGlass.Width, _hourGlass.Height);
		e.Graphics.ResetTransform();
	}

	public void UpdateDialog()
	{
		if (!_startTimestamped)
		{
			_startTimestamped = true;
			_startTimestamp = DateTime.Now;
		}
		else if (!base.Visible)
		{
			if (DateTime.Now.Subtract(_startTimestamp).TotalMilliseconds > 500.0)
			{
				Show();
				_spinTimestamp = DateTime.Now;
			}
		}
		else if (DateTime.Now.Subtract(_spinTimestamp).TotalMilliseconds > 75.0)
		{
			_spinAngle = (_spinAngle + 20f) % 360f;
			Invalidate();
			_spinTimestamp = DateTime.Now;
		}
		Application.DoEvents();
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
	public bool PreFilterMessage(ref Message m)
	{
		if ((m.Msg >= 512 && m.Msg <= 521) || (m.Msg >= 160 && m.Msg <= 169))
		{
			if (Control.FromHandle(m.HWnd) != null)
			{
				Form form = Control.FromHandle(m.HWnd).FindForm();
				if (form != null && form == this)
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	protected override void Dispose(bool disposing)
	{
		Application.RemoveMessageFilter(this);
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.labelMessage = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.labelMessage.Location = new System.Drawing.Point(68, 17);
		this.labelMessage.Name = "labelMessage";
		this.labelMessage.Size = new System.Drawing.Size(201, 28);
		this.labelMessage.TabIndex = 0;
		this.labelMessage.Text = "Please wait for operation to complete.";
		this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(269, 66);
		base.ControlBox = false;
		base.Controls.Add(this.labelMessage);
		this.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "ModalWaitDialog";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Processing";
		base.ResumeLayout(false);
	}
}
