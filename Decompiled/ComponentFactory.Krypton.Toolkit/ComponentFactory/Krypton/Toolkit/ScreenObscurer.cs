using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
public class ScreenObscurer : IDisposable
{
	private class ObscurerForm : Form
	{
		public ObscurerForm()
		{
			base.StartPosition = FormStartPosition.Manual;
			base.Location = new Point(-2147483647, -2147483647);
			base.Size = Size.Empty;
			base.FormBorderStyle = FormBorderStyle.None;
			base.ShowInTaskbar = false;
		}

		public void ShowForm(Rectangle screenRect)
		{
			SetBounds(screenRect.X, screenRect.Y, screenRect.Width, screenRect.Height);
			PI.ShowWindow(base.Handle, 4);
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
		}

		protected override void OnPaint(PaintEventArgs e)
		{
		}
	}

	private ObscurerForm _obscurer;

	public ScreenObscurer()
	{
		if (_obscurer == null)
		{
			_obscurer = new ObscurerForm();
		}
	}

	public ScreenObscurer(Form f, bool designMode)
	{
		if (f != null && !f.IsDisposed && !designMode)
		{
			if (_obscurer == null)
			{
				_obscurer = new ObscurerForm();
			}
			if (f != null)
			{
				_obscurer.ShowForm(f.Bounds);
			}
		}
	}

	public ScreenObscurer(Control c, bool designMode)
	{
		if (c != null && !c.IsDisposed && !designMode)
		{
			if (_obscurer == null)
			{
				_obscurer = new ObscurerForm();
			}
			if (c != null)
			{
				_obscurer.ShowForm(c.RectangleToScreen(c.ClientRectangle));
			}
		}
	}

	public void Cover(Form f)
	{
		if (f != null && !f.IsDisposed && _obscurer != null)
		{
			_obscurer.ShowForm(f.Bounds);
		}
	}

	public void Cover(Control c)
	{
		if (c != null && !c.IsDisposed && _obscurer != null)
		{
			_obscurer.ShowForm(c.RectangleToScreen(c.ClientRectangle));
		}
	}

	public void Uncover()
	{
		if (_obscurer != null)
		{
			_obscurer.Hide();
		}
	}

	public void Dispose()
	{
		if (_obscurer != null)
		{
			_obscurer.Hide();
			_obscurer.Dispose();
			_obscurer = null;
		}
	}
}
