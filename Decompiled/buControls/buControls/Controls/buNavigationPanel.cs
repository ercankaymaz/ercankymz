using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns27;

namespace buControls.Controls;

public class buNavigationPanel : buContainerControl
{
	public delegate void NavigasyonChangedEventHandler(bool Minimized);

	private MouseState mouseState_0;

	private bool bool_0 = false;

	private int int_2 = 100;

	private int int_3 = 100;

	private int int_4 = 0;

	private int int_5 = 0;

	private ThemeType themeType_0 = ThemeType.Standart;

	internal HotkeyPrefix hotkeyPrefix_0 = HotkeyPrefix.None;

	private buControlDisplay buControlDisplay_1 = new buControlDisplay();

	private buControlNavigationPanel buControlNavigationPanel_0 = new buControlNavigationPanel();

	private NavigationDockPositionType navigationDockPositionType_0 = NavigationDockPositionType.Left;

	private buControlLanguage buControlLanguage_0 = new buControlLanguage();

	private int int_6 = 25;

	private int int_7 = 50;

	private bool bool_1;

	private string string_1 = "";

	[CompilerGenerated]
	private NavigasyonChangedEventHandler navigasyonChangedEventHandler_0;

	[DefaultValue(true)]
	public bool UseMnemonic
	{
		get
		{
			return bool_1;
		}
		set
		{
			if (bool_1 != value)
			{
				bool_1 = value;
				Class76.smethod_700(this, bool_1);
				Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay TitleDisplay
	{
		get
		{
			return buControlDisplay_1;
		}
		set
		{
			buControlDisplay_1 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
			Invalidate();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlLanguage Language
	{
		get
		{
			return buControlLanguage_0;
		}
		set
		{
			buControlLanguage_0 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlNavigationPanel Navigation
	{
		get
		{
			return buControlNavigationPanel_0;
		}
		set
		{
			buControlNavigationPanel_0 = value;
			Invalidate();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(25)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int TitleHeight
	{
		get
		{
			return int_6;
		}
		set
		{
			int_6 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
			Invalidate();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(NavigationDockPositionType.Left)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public NavigationDockPositionType Position
	{
		get
		{
			return navigationDockPositionType_0;
		}
		set
		{
			navigationDockPositionType_0 = value;
			Invalidate();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(50)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int MinimizedLength
	{
		get
		{
			return int_7;
		}
		set
		{
			int_7 = value;
			Invalidate();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue("")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public override string Text
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
			Invalidate();
		}
	}

	public event NavigasyonChangedEventHandler StateChanged
	{
		[CompilerGenerated]
		add
		{
			NavigasyonChangedEventHandler navigasyonChangedEventHandler = navigasyonChangedEventHandler_0;
			NavigasyonChangedEventHandler navigasyonChangedEventHandler2;
			do
			{
				navigasyonChangedEventHandler2 = navigasyonChangedEventHandler;
				NavigasyonChangedEventHandler value2 = (NavigasyonChangedEventHandler)Delegate.Combine(navigasyonChangedEventHandler2, value);
				navigasyonChangedEventHandler = Interlocked.CompareExchange(ref navigasyonChangedEventHandler_0, value2, navigasyonChangedEventHandler2);
			}
			while ((object)navigasyonChangedEventHandler != navigasyonChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			NavigasyonChangedEventHandler navigasyonChangedEventHandler = navigasyonChangedEventHandler_0;
			NavigasyonChangedEventHandler navigasyonChangedEventHandler2;
			do
			{
				navigasyonChangedEventHandler2 = navigasyonChangedEventHandler;
				NavigasyonChangedEventHandler value2 = (NavigasyonChangedEventHandler)Delegate.Remove(navigasyonChangedEventHandler2, value);
				navigasyonChangedEventHandler = Interlocked.CompareExchange(ref navigasyonChangedEventHandler_0, value2, navigasyonChangedEventHandler2);
			}
			while ((object)navigasyonChangedEventHandler != navigasyonChangedEventHandler2);
		}
	}

	public buNavigationPanel()
	{
		try
		{
			Class76.smethod_602();
			base.Display.Parent = this;
			base.Geometry.Parent = this;
			base.Theme.Parent = this;
			Navigation.Parent = this;
			TitleDisplay.Parent = this;
			Navigation.ButtonDisplay.Parent = this;
			base.Image = null;
			bool_1 = true;
			Class76.smethod_700(this, bool_1);
			base.ImageList = null;
			TextAlign = ContentAlignment.MiddleCenter;
			base.ImageAlign = ContentAlignment.MiddleLeft;
			Navigation.ButtonDisplay.BackColor = Color.Gray;
			SetStyle(ControlStyles.Selectable, value: false);
			SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			int_2 = base.Width;
			int_3 = base.Height;
			int_4 = base.Left;
			int_5 = base.Top;
		}
		catch (Exception)
		{
		}
	}

	public void SetMinimized(bool bMinimized)
	{
		bool_0 = !bMinimized;
		if (Position == NavigationDockPositionType.Left)
		{
			if (bool_0)
			{
				bool_0 = false;
				base.Width = int_2;
				for (int i = 0; i <= base.Controls.Count - 1; i++)
				{
					base.Controls[i].Visible = true;
				}
			}
			else
			{
				bool_0 = true;
				int_2 = base.Width;
				if (MinimizedLength >= Navigation.ButtonSize)
				{
					base.Width = Navigation.ButtonSize + 5;
				}
				else
				{
					base.Width = MinimizedLength;
				}
				for (int j = 0; j <= base.Controls.Count - 1; j++)
				{
					base.Controls[j].Visible = false;
				}
			}
			if (navigasyonChangedEventHandler_0 != null)
			{
				navigasyonChangedEventHandler_0(bool_0);
			}
		}
		if (Position == NavigationDockPositionType.Right)
		{
			if (bool_0)
			{
				bool_0 = false;
				base.Left = int_4;
				base.Width = int_2;
				for (int k = 0; k <= base.Controls.Count - 1; k++)
				{
					base.Controls[k].Visible = true;
				}
			}
			else
			{
				bool_0 = true;
				int_2 = base.Width;
				int_4 = base.Left;
				if (MinimizedLength >= Navigation.ButtonSize)
				{
					base.Left = base.Left + base.Width - Navigation.ButtonSize - 5;
					base.Width = Navigation.ButtonSize + 5;
				}
				else
				{
					base.Left = base.Left + base.Width - MinimizedLength - 2;
					base.Width = MinimizedLength - 2;
				}
				for (int l = 0; l <= base.Controls.Count - 1; l++)
				{
					base.Controls[l].Visible = false;
				}
			}
			if (navigasyonChangedEventHandler_0 != null)
			{
				navigasyonChangedEventHandler_0(bool_0);
			}
		}
		if (Position == NavigationDockPositionType.Down)
		{
			if (bool_0)
			{
				bool_0 = false;
				base.Top = int_5;
				base.Height = int_3;
				for (int m = 0; m <= base.Controls.Count - 1; m++)
				{
					base.Controls[m].Visible = true;
				}
			}
			else
			{
				bool_0 = true;
				int_3 = base.Height;
				int_5 = base.Top;
				base.Top += base.Height - MinimizedLength;
				base.Height = MinimizedLength;
				for (int n = 0; n <= base.Controls.Count - 1; n++)
				{
					base.Controls[n].Visible = false;
				}
			}
			if (navigasyonChangedEventHandler_0 != null)
			{
				navigasyonChangedEventHandler_0(bool_0);
			}
		}
		if (Position != NavigationDockPositionType.Up)
		{
			return;
		}
		if (bool_0)
		{
			bool_0 = false;
			base.Height = int_3;
			for (int num = 0; num <= base.Controls.Count - 1; num++)
			{
				base.Controls[num].Visible = true;
			}
		}
		else
		{
			bool_0 = true;
			int_3 = base.Height;
			base.Height = MinimizedLength;
			for (int num2 = 0; num2 <= base.Controls.Count - 1; num2++)
			{
				base.Controls[num2].Visible = false;
			}
		}
		if (navigasyonChangedEventHandler_0 != null)
		{
			navigasyonChangedEventHandler_0(bool_0);
		}
	}

	protected override void OnResize(EventArgs e)
	{
		try
		{
			base.OnResize(e);
			if (base.DesignMode)
			{
				int_2 = base.Width;
				int_3 = base.Height;
				int_4 = base.Left;
				int_5 = base.Top;
			}
			Invalidate();
		}
		catch (Exception)
		{
		}
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		try
		{
			mouseState_0 = MouseState.None;
			Invalidate();
			base.OnMouseUp(e);
		}
		catch (Exception)
		{
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		try
		{
			if (Position == NavigationDockPositionType.Left)
			{
				if (e.Y >= Convert.ToInt32(Navigation.ButtonSize))
				{
					mouseState_0 = MouseState.None;
				}
				else if (!((e.X > 0) & (e.X < Navigation.ButtonSize)))
				{
					mouseState_0 = MouseState.None;
				}
				else
				{
					mouseState_0 = MouseState.Down;
					if (bool_0)
					{
						bool_0 = false;
						base.Width = int_2;
						for (int i = 0; i <= base.Controls.Count - 1; i++)
						{
							base.Controls[i].Visible = true;
						}
					}
					else
					{
						bool_0 = true;
						int_2 = base.Width;
						if (MinimizedLength >= Navigation.ButtonSize)
						{
							base.Width = Navigation.ButtonSize + 5;
						}
						else
						{
							base.Width = MinimizedLength;
						}
						for (int j = 0; j <= base.Controls.Count - 1; j++)
						{
							base.Controls[j].Visible = false;
						}
					}
					if (navigasyonChangedEventHandler_0 != null)
					{
						navigasyonChangedEventHandler_0(bool_0);
					}
				}
			}
			if (Position == NavigationDockPositionType.Right)
			{
				if (e.Y >= Convert.ToInt32(Navigation.ButtonSize))
				{
					mouseState_0 = MouseState.None;
				}
				else if (!((e.X > base.Width - Navigation.ButtonSize) & (e.X < base.Width)))
				{
					mouseState_0 = MouseState.None;
				}
				else
				{
					mouseState_0 = MouseState.Down;
					if (bool_0)
					{
						bool_0 = false;
						base.Left = int_4;
						base.Width = int_2;
						for (int k = 0; k <= base.Controls.Count - 1; k++)
						{
							base.Controls[k].Visible = true;
						}
					}
					else
					{
						bool_0 = true;
						int_2 = base.Width;
						int_4 = base.Left;
						if (MinimizedLength >= Navigation.ButtonSize)
						{
							base.Left = base.Left + base.Width - Navigation.ButtonSize - 5;
							base.Width = Navigation.ButtonSize + 5;
						}
						else
						{
							base.Left = base.Left + base.Width - MinimizedLength - 2;
							base.Width = MinimizedLength - 2;
						}
						for (int l = 0; l <= base.Controls.Count - 1; l++)
						{
							base.Controls[l].Visible = false;
						}
					}
					if (navigasyonChangedEventHandler_0 != null)
					{
						navigasyonChangedEventHandler_0(bool_0);
					}
				}
			}
			if (Position == NavigationDockPositionType.Down)
			{
				if (!((base.Height - Navigation.ButtonSize < e.Y) & (e.Y < base.Height)))
				{
					mouseState_0 = MouseState.None;
				}
				else if (!((e.X > 0) & (e.X < Navigation.ButtonSize)))
				{
					mouseState_0 = MouseState.None;
				}
				else
				{
					mouseState_0 = MouseState.Down;
					if (bool_0)
					{
						bool_0 = false;
						base.Top = int_5;
						base.Height = int_3;
						for (int m = 0; m <= base.Controls.Count - 1; m++)
						{
							base.Controls[m].Visible = true;
						}
					}
					else
					{
						bool_0 = true;
						int_3 = base.Height;
						int_5 = base.Top;
						base.Top += base.Height - MinimizedLength;
						base.Height = MinimizedLength;
						for (int n = 0; n <= base.Controls.Count - 1; n++)
						{
							base.Controls[n].Visible = false;
						}
					}
					if (navigasyonChangedEventHandler_0 != null)
					{
						navigasyonChangedEventHandler_0(bool_0);
					}
				}
			}
			if (Position == NavigationDockPositionType.Up)
			{
				if (!((e.Y > 0) & (e.Y < Convert.ToInt32(Navigation.ButtonSize))))
				{
					mouseState_0 = MouseState.None;
				}
				else if (!((e.X > 0) & (e.X < Navigation.ButtonSize)))
				{
					mouseState_0 = MouseState.None;
				}
				else
				{
					mouseState_0 = MouseState.Down;
					if (bool_0)
					{
						bool_0 = false;
						base.Height = int_3;
						for (int num = 0; num <= base.Controls.Count - 1; num++)
						{
							base.Controls[num].Visible = true;
						}
					}
					else
					{
						bool_0 = true;
						int_3 = base.Height;
						base.Height = MinimizedLength;
						for (int num2 = 0; num2 <= base.Controls.Count - 1; num2++)
						{
							base.Controls[num2].Visible = false;
						}
					}
					if (navigasyonChangedEventHandler_0 != null)
					{
						navigasyonChangedEventHandler_0(bool_0);
					}
				}
			}
			Invalidate();
			base.OnMouseDown(e);
		}
		catch (Exception)
		{
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		try
		{
			if (Position == NavigationDockPositionType.Left)
			{
				if (e.Y >= Convert.ToInt32(Navigation.ButtonSize))
				{
					mouseState_0 = MouseState.None;
				}
				else if (!((e.X > base.Width - Navigation.ButtonSize) & (e.X < base.Width)))
				{
					mouseState_0 = MouseState.None;
				}
				else
				{
					mouseState_0 = MouseState.Move;
				}
			}
			if ((Position == NavigationDockPositionType.Right) | (Position == NavigationDockPositionType.Down))
			{
				if (e.Y >= Convert.ToInt32(Navigation.ButtonSize))
				{
					mouseState_0 = MouseState.None;
				}
				else if (!((e.X > 0) & (e.X < Navigation.ButtonSize)))
				{
					mouseState_0 = MouseState.None;
				}
				else
				{
					mouseState_0 = MouseState.Move;
				}
			}
			if (Position == NavigationDockPositionType.Up)
			{
				if (!((e.Y > Convert.ToInt32(base.Height - Navigation.ButtonSize)) & (e.Y < Convert.ToInt32(base.Height))))
				{
					mouseState_0 = MouseState.None;
				}
				else if (!((e.X > 0) & (e.X < Navigation.ButtonSize)))
				{
					mouseState_0 = MouseState.None;
				}
				else
				{
					mouseState_0 = MouseState.Move;
				}
			}
			Cursor = Cursors.Default;
			Invalidate();
			base.OnMouseMove(e);
		}
		catch (Exception)
		{
		}
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		try
		{
			mouseState_0 = MouseState.None;
			Invalidate();
			if (mouseState_0 != MouseState.None)
			{
			}
			base.OnMouseLeave(e);
		}
		catch (Exception)
		{
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		try
		{
			string orjText = Text;
			RectangleF rectangleF = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, base.ClientRectangle.Height);
			rectDraw rectDraw2 = new rectDraw(new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, TitleHeight), RoundRectangleType.RoundRectAll);
			RectangleF rect = default(RectangleF);
			Graphics Grph = e.Graphics;
			if (base.Theme.Type != themeType_0)
			{
				buControlThemeVars Vars = new buControlThemeVars();
				buControlTheme.UpdateTheme(base.Theme.Type, ref Vars);
				base.Geometry = new buControlGeometry(Vars.Geometry);
				base.Display = new buControlDisplay(Vars.Display);
				TitleDisplay = new buControlDisplay(Vars.DisplayGroupTitle);
				Navigation.ButtonDisplay = new buControlDisplay(Vars.DisplayButtonNormal);
				Navigation.Parent = this;
				Navigation.ButtonDisplay.Parent = this;
				base.Display.Parent = this;
				base.Geometry.Parent = this;
				base.Theme.Parent = this;
				TitleDisplay.Parent = this;
			}
			orjText = ControlGeometry.LanguageSelect(Language, orjText);
			if ((base.Width > 0) & (base.Height > 0))
			{
				ControlGeometry.drawGeometry(base.ClientRectangle, base.Geometry, base.Display, RoundRectangleType.RoundRectAll, ref Grph);
				if (Position == NavigationDockPositionType.Left)
				{
					rectDraw2 = new rectDraw(new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, TitleHeight, base.Height), RoundRectangleType.RoundRectAll);
					rect = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, TitleHeight, Navigation.ButtonSize);
					ControlGeometry.drawGeometry(rectDraw2.rect, base.Geometry, TitleDisplay, RoundRectangleType.RoundRectDown, ref Grph);
					ControlGeometry.drawGeometry(rect, base.Geometry, Navigation.ButtonDisplay, RoundRectangleType.RoundRectDown, ref Grph);
					if (base.Image != null)
					{
						rectDraw2.rectText = ControlGeometry.GetTextRectangleFromImage(base.Image, base.ImageAlign, rectDraw2.rectText, base.Geometry, base.ImageBorderOffset);
					}
					ControlGeometry.drawString(rect, "↔", 0f, Navigation.ButtonDisplay, hotkeyPrefix_0, ref Grph);
					if (bool_0)
					{
						ControlGeometry.drawString(rectDraw2.rectText, orjText, -90f, TitleDisplay, hotkeyPrefix_0, ref Grph);
					}
					else
					{
						ControlGeometry.drawString(rectDraw2.rectText, orjText, -90f, TitleDisplay, hotkeyPrefix_0, ref Grph);
					}
					DrawImage(e.Graphics, base.Image, new Rectangle(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, TitleHeight), base.ImageAlign);
				}
				if (Position == NavigationDockPositionType.Right)
				{
					rectDraw2 = new rectDraw(new RectangleF(base.ClientRectangle.Width - TitleHeight, base.ClientRectangle.Top, TitleHeight, base.Height), RoundRectangleType.RoundRectAll);
					rect = new RectangleF(base.ClientRectangle.Width - TitleHeight, base.ClientRectangle.Top, TitleHeight, Navigation.ButtonSize);
					ControlGeometry.drawGeometry(rectDraw2.rect, base.Geometry, TitleDisplay, RoundRectangleType.RoundRectDown, ref Grph);
					ControlGeometry.drawGeometry(rect, base.Geometry, Navigation.ButtonDisplay, RoundRectangleType.RoundRectDown, ref Grph);
					if (base.Image != null)
					{
						rectDraw2.rectText = ControlGeometry.GetTextRectangleFromImage(base.Image, base.ImageAlign, rectDraw2.rectText, base.Geometry, base.ImageBorderOffset);
					}
					ControlGeometry.drawString(rect, "↔", 0f, Navigation.ButtonDisplay, hotkeyPrefix_0, ref Grph);
					if (bool_0)
					{
						ControlGeometry.drawString(rectDraw2.rectText, orjText, -90f, TitleDisplay, hotkeyPrefix_0, ref Grph);
					}
					else
					{
						ControlGeometry.drawString(rectDraw2.rectText, orjText, -90f, TitleDisplay, hotkeyPrefix_0, ref Grph);
					}
					DrawImage(e.Graphics, base.Image, new Rectangle(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, TitleHeight), base.ImageAlign);
				}
				if (Position == NavigationDockPositionType.Up)
				{
					rectDraw2 = new rectDraw(new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, TitleHeight), RoundRectangleType.RoundRectAll);
					rect = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, Navigation.ButtonSize, TitleHeight);
					ControlGeometry.drawGeometry(rectDraw2.rect, base.Geometry, TitleDisplay, RoundRectangleType.RoundRectDown, ref Grph);
					ControlGeometry.drawGeometry(rect, base.Geometry, Navigation.ButtonDisplay, RoundRectangleType.RoundRectDown, ref Grph);
					if (base.Image != null)
					{
						rectDraw2.rectText = ControlGeometry.GetTextRectangleFromImage(base.Image, base.ImageAlign, rectDraw2.rectText, base.Geometry, base.ImageBorderOffset);
					}
					ControlGeometry.drawString(rect, "↨", 0f, Navigation.ButtonDisplay, hotkeyPrefix_0, ref Grph);
					if (bool_0)
					{
						ControlGeometry.drawString(rectDraw2.rectText, orjText, TitleDisplay, hotkeyPrefix_0, ref Grph);
					}
					else
					{
						ControlGeometry.drawString(rectDraw2.rectText, orjText, TitleDisplay, hotkeyPrefix_0, ref Grph);
					}
					DrawImage(e.Graphics, base.Image, new Rectangle(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, TitleHeight), base.ImageAlign);
				}
				if (Position == NavigationDockPositionType.Down)
				{
					rectDraw2 = new rectDraw(new RectangleF(base.ClientRectangle.Left, base.Height - TitleHeight, base.ClientRectangle.Width, TitleHeight), RoundRectangleType.RoundRectAll);
					rect = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Height - TitleHeight, Navigation.ButtonSize, TitleHeight);
					ControlGeometry.drawGeometry(rectDraw2.rect, base.Geometry, TitleDisplay, RoundRectangleType.RoundRectDown, ref Grph);
					ControlGeometry.drawGeometry(rect, base.Geometry, Navigation.ButtonDisplay, RoundRectangleType.RoundRectDown, ref Grph);
					if (base.Image != null)
					{
						rectDraw2.rectText = ControlGeometry.GetTextRectangleFromImage(base.Image, base.ImageAlign, rectDraw2.rectText, base.Geometry, base.ImageBorderOffset);
					}
					ControlGeometry.drawString(rect, "↨", 0f, Navigation.ButtonDisplay, hotkeyPrefix_0, ref Grph);
					if (bool_0)
					{
						ControlGeometry.drawString(rectDraw2.rectText, orjText, TitleDisplay, hotkeyPrefix_0, ref Grph);
					}
					else
					{
						ControlGeometry.drawString(rectDraw2.rectText, orjText, TitleDisplay, hotkeyPrefix_0, ref Grph);
					}
					DrawImage(e.Graphics, base.Image, new Rectangle(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, TitleHeight), base.ImageAlign);
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
