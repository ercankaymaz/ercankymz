using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class KeyTipControl : Form
{
	private KryptonRibbon _ribbon;

	private List<ViewDrawRibbonKeyTip> _viewList;

	private string _prefix;

	private bool _showDisabled;

	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams createParams = base.CreateParams;
			createParams.Parent = IntPtr.Zero;
			createParams.Style |= int.MinValue;
			createParams.ExStyle |= 136;
			return createParams;
		}
	}

	public KeyTipControl(KryptonRibbon ribbon, KeyTipInfoList keyTips, bool showDisabled)
	{
		_ribbon = ribbon;
		_showDisabled = showDisabled;
		base.StartPosition = FormStartPosition.Manual;
		base.FormBorderStyle = FormBorderStyle.None;
		base.ShowInTaskbar = false;
		base.TransparencyKey = Color.Magenta;
		if (_showDisabled)
		{
			base.Opacity = 0.5;
		}
		SetKeyTips(keyTips);
	}

	public void SetKeyTips(KeyTipInfoList keyTips)
	{
		_viewList = new List<ViewDrawRibbonKeyTip>();
		Rectangle rectangle = Rectangle.Empty;
		foreach (KeyTipInfo keyTip in keyTips)
		{
			if (rectangle.IsEmpty)
			{
				rectangle = new Rectangle(keyTip.ScreenPt, new Size(1, 1));
			}
			else
			{
				if (keyTip.ScreenPt.X < rectangle.Left)
				{
					int num = rectangle.Left - keyTip.ScreenPt.X;
					rectangle.Width += num;
					rectangle.X -= num;
				}
				if (keyTip.ScreenPt.X > rectangle.Right)
				{
					rectangle.Width += keyTip.ScreenPt.X - rectangle.Right;
				}
				if (keyTip.ScreenPt.Y < rectangle.Top)
				{
					int num2 = rectangle.Top - keyTip.ScreenPt.Y;
					rectangle.Height += num2;
					rectangle.Y -= num2;
				}
				if (keyTip.ScreenPt.Y > rectangle.Bottom)
				{
					rectangle.Height += keyTip.ScreenPt.Y - rectangle.Bottom;
				}
			}
			_viewList.Add(new ViewDrawRibbonKeyTip(keyTip, _ribbon.StateCommon.RibbonKeyTip.Back, _ribbon.StateCommon.RibbonKeyTip.Border, _ribbon.StateCommon.RibbonKeyTip.Content));
		}
		rectangle.Inflate(50, 50);
		_prefix = string.Empty;
		SetBounds(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
		StartTimer();
	}

	public void AppendKeyPress(char key)
	{
		key = char.ToUpper(key);
		string value = _prefix + key;
		foreach (ViewDrawRibbonKeyTip view in _viewList)
		{
			if (view.KeyTipInfo.KeyString.Equals(value))
			{
				view.KeyTipInfo.KeyTipSelect(_ribbon);
				return;
			}
		}
		bool flag = false;
		foreach (ViewDrawRibbonKeyTip view2 in _viewList)
		{
			if (view2.KeyTipInfo.KeyString.StartsWith(value))
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			_prefix += key;
			PI.ShowWindow(base.Handle, 0);
			StartTimer();
		}
		else if (key != '\u001b')
		{
			PI.MessageBeep(16);
		}
	}

	protected override void OnPaintBackground(PaintEventArgs pevent)
	{
		pevent.Graphics.FillRectangle(Brushes.Magenta, pevent.ClipRectangle);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		using (ViewLayoutContext viewLayoutContext = new ViewLayoutContext(this, _ribbon.Renderer))
		{
			foreach (ViewDrawRibbonKeyTip view in _viewList)
			{
				if ((_showDisabled && !view.KeyTipInfo.Enabled) || (!_showDisabled && view.KeyTipInfo.Enabled))
				{
					bool flag = view.KeyTipInfo.Visible;
					if (flag && !string.IsNullOrEmpty(_prefix))
					{
						flag = view.KeyTipInfo.KeyString.StartsWith(_prefix);
					}
					view.Visible = flag;
					view.Enabled = view.KeyTipInfo.Enabled;
					Size preferredSize = view.GetPreferredSize(viewLayoutContext);
					Point location = PointToClient(view.KeyTipInfo.ScreenPt);
					location.X -= preferredSize.Width / 2;
					location.Y -= preferredSize.Height / 2;
					viewLayoutContext.DisplayRectangle = new Rectangle(location, preferredSize);
					view.Layout(viewLayoutContext);
				}
			}
		}
		using RenderContext context = new RenderContext(this, e.Graphics, e.ClipRectangle, _ribbon.Renderer);
		foreach (ViewDrawRibbonKeyTip view2 in _viewList)
		{
			if (view2.Visible)
			{
				view2.Render(context);
			}
		}
	}

	private void StartTimer()
	{
		Timer timer = new Timer();
		timer.Interval = 1;
		timer.Tick += OnRedrawTick;
		timer.Start();
	}

	private void OnRedrawTick(object sender, EventArgs e)
	{
		Timer timer = (Timer)sender;
		timer.Stop();
		timer.Dispose();
		if (!base.IsDisposed && base.Handle != IntPtr.Zero)
		{
			PI.ShowWindow(base.Handle, 4);
		}
	}
}
