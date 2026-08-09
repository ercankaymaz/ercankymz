using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace buControls.Controls;

public class buTab : TabControl
{
	private ThemeType themeType_0 = ThemeType.Standart;

	public List<bool> TabPageVisible = new List<bool>();

	private buControlDisplay buControlDisplay_0 = new buControlDisplay();

	private buControlGeometry buControlGeometry_0 = new buControlGeometry();

	private buControlLanguage buControlLanguage_0 = new buControlLanguage();

	private buControlTab buControlTab_0 = new buControlTab();

	private buControlTheme buControlTheme_0 = new buControlTheme();

	private Color color_0 = Color.LightGray;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlTheme Theme
	{
		get
		{
			return buControlTheme_0;
		}
		set
		{
			buControlTheme_0 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
			Invalidate();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay Display
	{
		get
		{
			return buControlDisplay_0;
		}
		set
		{
			buControlDisplay_0 = value;
			if (base.Parent == null)
			{
				MessageBox.Show("2122");
			}
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
			Invalidate();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlGeometry Geometry
	{
		get
		{
			return buControlGeometry_0;
		}
		set
		{
			buControlGeometry_0 = value;
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
			Invalidate();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlTab Tabs
	{
		get
		{
			return buControlTab_0;
		}
		set
		{
			buControlTab_0 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
			Invalidate();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(typeof(Color), "LightGray")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public override Color BackColor
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
			Invalidate();
		}
	}

	public buTab()
	{
		Tabs.Parent = this;
		Display.Parent = this;
		Tabs.Header.Parent = this;
		Tabs.HeaderSelected.Parent = this;
		Geometry.Parent = this;
		Theme.Parent = this;
		Language.Parent = this;
		if (base.Parent != null)
		{
			BackColor = base.Parent.BackColor;
		}
		SetStyle(ControlStyles.Selectable, value: false);
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		Tabs.HeaderSelected.BackColor = Color.DarkGray;
	}

	protected override void CreateHandle()
	{
		try
		{
			base.CreateHandle();
		}
		catch (Exception)
		{
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics Grph = e.Graphics;
		Rectangle rectangle = default(Rectangle);
		Grph.Clear(Display.BackColor);
		if (base.Alignment != TabAlignment.Top)
		{
			if (base.Alignment != TabAlignment.Right)
			{
				if (base.Alignment != TabAlignment.Left)
				{
					if (base.Alignment == TabAlignment.Bottom)
					{
						RectangleF rect = new RectangleF(0f, 0f, base.Width - 1, base.Height - base.ItemSize.Height - 2);
						ControlGeometry.drawGeometry(rect, Geometry, Display, RoundRectangleType.RoundRectAll, ref Grph);
						for (int i = 0; i <= base.TabCount - 1; i++)
						{
							bool flag = true;
							if (i <= TabPageVisible.Count - 1)
							{
								flag = TabPageVisible[i];
							}
							if (!flag)
							{
								continue;
							}
							rectangle = GetTabRect(i);
							if (i != base.SelectedIndex)
							{
								RoundRectangleType roundRectangleType = RoundRectangleType.RoundRectNone;
								if (i == 0)
								{
									roundRectangleType = RoundRectangleType.RoundRectLeftDown;
								}
								if (i == base.TabCount - 1)
								{
									roundRectangleType = RoundRectangleType.RoundRectRightDown;
								}
								RectangleF rect2 = new RectangleF(rectangle.X + Tabs.HeaderXOffset, rectangle.Y - 2, rectangle.Width, rectangle.Height);
								ControlGeometry.drawGeometry(rect2, Geometry.ArcDiameter, Geometry.ShapeMode, Tabs.Header, roundRectangleType, ref Grph);
								try
								{
									Grph.TranslateTransform(rect2.X + rect2.Width / 2f, rect2.Y + rect2.Height / 2f);
									Grph.RotateTransform(0f);
									Grph.DrawString(base.TabPages[i].Text, Tabs.Header.Fonts.Font, new SolidBrush(Tabs.Header.Fonts.ForeColor), 0f, 0f, ControlGeometry.AlignmentToStringFormat(Tabs.Header.Fonts.Alignment));
									Grph.ResetTransform();
									base.TabPages[i].BackColor = Tabs.TabPageColor;
								}
								catch
								{
								}
							}
							else
							{
								RoundRectangleType roundRectangleType2 = RoundRectangleType.RoundRectNone;
								if (i == 0)
								{
									roundRectangleType2 = RoundRectangleType.RoundRectLeftDown;
								}
								if (i == base.TabCount - 1)
								{
									roundRectangleType2 = RoundRectangleType.RoundRectRightDown;
								}
								RectangleF rect3 = new RectangleF(rectangle.X, rectangle.Y - 2, rectangle.Width, rectangle.Height);
								ControlGeometry.drawGeometry(rect3, Geometry, Tabs.HeaderSelected, roundRectangleType2, ref Grph);
								try
								{
									Grph.TranslateTransform(rect3.X + rect3.Width / 2f, rect3.Y + rect3.Height / 2f);
									Grph.RotateTransform(0f);
									Grph.DrawString(base.TabPages[i].Text, Tabs.HeaderSelected.Fonts.Font, new SolidBrush(Tabs.HeaderSelected.Fonts.ForeColor), 0f, 0f, ControlGeometry.AlignmentToStringFormat(Tabs.HeaderSelected.Fonts.Alignment));
									Grph.ResetTransform();
									base.TabPages[i].BackColor = Tabs.TabPageColor;
								}
								catch
								{
								}
							}
						}
					}
				}
				else
				{
					RectangleF rect4 = new RectangleF(base.ItemSize.Height, 0f, base.Width - base.ItemSize.Height - 1, base.Height - 1);
					ControlGeometry.drawGeometry(rect4, Geometry, Display, RoundRectangleType.RoundRectAll, ref Grph);
					for (int j = 0; j <= base.TabCount - 1; j++)
					{
						bool flag2 = true;
						if (j <= TabPageVisible.Count - 1)
						{
							flag2 = TabPageVisible[j];
						}
						if (!flag2)
						{
							continue;
						}
						rectangle = GetTabRect(j);
						if (j != base.SelectedIndex)
						{
							RoundRectangleType roundRectangleType3 = RoundRectangleType.RoundRectNone;
							if (j == 0)
							{
								roundRectangleType3 = RoundRectangleType.RoundRectLeftUp;
							}
							if (j == base.TabCount - 1)
							{
								roundRectangleType3 = RoundRectangleType.RoundRectLeftDown;
							}
							RectangleF rect5 = new RectangleF(rectangle.X + Tabs.HeaderXOffset, rectangle.Y - 2, rectangle.Width, rectangle.Height);
							ControlGeometry.drawGeometry(rect5, Geometry.ArcDiameter, Geometry.ShapeMode, Tabs.Header, roundRectangleType3, ref Grph);
							try
							{
								Grph.TranslateTransform(rect5.X + rect5.Width / 2f, rect5.Y + rect5.Height / 2f);
								Grph.RotateTransform(-90f);
								Grph.DrawString(base.TabPages[j].Text, Tabs.Header.Fonts.Font, new SolidBrush(Tabs.Header.Fonts.ForeColor), 0f, 0f, ControlGeometry.AlignmentToStringFormat(Tabs.Header.Fonts.Alignment));
								Grph.ResetTransform();
								base.TabPages[j].BackColor = Tabs.TabPageColor;
							}
							catch
							{
							}
						}
						else
						{
							RoundRectangleType roundRectangleType4 = RoundRectangleType.RoundRectNone;
							if (j == 0)
							{
								roundRectangleType4 = RoundRectangleType.RoundRectLeftUp;
							}
							if (j == base.TabCount - 1)
							{
								roundRectangleType4 = RoundRectangleType.RoundRectLeftDown;
							}
							RectangleF rect6 = new RectangleF(rectangle.X, rectangle.Y - 2, rectangle.Width, rectangle.Height);
							ControlGeometry.drawGeometry(rect6, Geometry, Tabs.HeaderSelected, roundRectangleType4, ref Grph);
							try
							{
								Grph.TranslateTransform(rect6.X + rect6.Width / 2f, rect6.Y + rect6.Height / 2f);
								Grph.RotateTransform(-90f);
								Grph.DrawString(base.TabPages[j].Text, Tabs.HeaderSelected.Fonts.Font, new SolidBrush(Tabs.HeaderSelected.Fonts.ForeColor), 0f, 0f, ControlGeometry.AlignmentToStringFormat(Tabs.HeaderSelected.Fonts.Alignment));
								Grph.ResetTransform();
								base.TabPages[j].BackColor = Tabs.TabPageColor;
							}
							catch
							{
							}
						}
					}
				}
			}
			else
			{
				RectangleF rect7 = new RectangleF(0f, 0f, base.Width - base.ItemSize.Height - 1, base.Height - 1);
				ControlGeometry.drawGeometry(rect7, Geometry, Display, RoundRectangleType.RoundRectAll, ref Grph);
				for (int k = 0; k <= base.TabCount - 1; k++)
				{
					bool flag3 = true;
					if (k <= TabPageVisible.Count - 1)
					{
						flag3 = TabPageVisible[k];
					}
					if (!flag3)
					{
						continue;
					}
					rectangle = GetTabRect(k);
					if (k != base.SelectedIndex)
					{
						RoundRectangleType roundRectangleType5 = RoundRectangleType.RoundRectNone;
						if (k == 0)
						{
							roundRectangleType5 = RoundRectangleType.RoundRectRightUp;
						}
						if (k == base.TabCount - 1)
						{
							roundRectangleType5 = RoundRectangleType.RoundRectRightDown;
						}
						RectangleF rect8 = new RectangleF(rectangle.X + Tabs.HeaderXOffset, rectangle.Y - 2, rectangle.Width, rectangle.Height);
						ControlGeometry.drawGeometry(rect8, Geometry.ArcDiameter, Geometry.ShapeMode, Tabs.Header, roundRectangleType5, ref Grph);
						try
						{
							Grph.TranslateTransform(rect8.X + rect8.Width / 2f, rect8.Y + rect8.Height / 2f);
							Grph.RotateTransform(90f);
							Grph.DrawString(base.TabPages[k].Text, Tabs.Header.Fonts.Font, new SolidBrush(Tabs.Header.Fonts.ForeColor), 0f, 0f, ControlGeometry.AlignmentToStringFormat(Tabs.Header.Fonts.Alignment));
							Grph.ResetTransform();
							base.TabPages[k].BackColor = Tabs.TabPageColor;
						}
						catch
						{
						}
					}
					else
					{
						RoundRectangleType roundRectangleType6 = RoundRectangleType.RoundRectNone;
						if (k == 0)
						{
							roundRectangleType6 = RoundRectangleType.RoundRectRightUp;
						}
						if (k == base.TabCount - 1)
						{
							roundRectangleType6 = RoundRectangleType.RoundRectRightDown;
						}
						RectangleF rect9 = new RectangleF(rectangle.X, rectangle.Y - 2, rectangle.Width, rectangle.Height);
						ControlGeometry.drawGeometry(rect9, Geometry, Tabs.HeaderSelected, roundRectangleType6, ref Grph);
						try
						{
							Grph.TranslateTransform(rect9.X + rect9.Width / 2f, rect9.Y + rect9.Height / 2f);
							Grph.RotateTransform(90f);
							Grph.DrawString(base.TabPages[k].Text, Tabs.HeaderSelected.Fonts.Font, new SolidBrush(Tabs.HeaderSelected.Fonts.ForeColor), 0f, 0f, ControlGeometry.AlignmentToStringFormat(Tabs.HeaderSelected.Fonts.Alignment));
							Grph.ResetTransform();
							base.TabPages[k].BackColor = Tabs.TabPageColor;
						}
						catch
						{
						}
					}
				}
			}
		}
		else
		{
			_ = base.Width;
			RectangleF rect10 = new RectangleF(0f, base.ItemSize.Height - 1, base.Width - 1, base.Height - base.ItemSize.Height);
			ControlGeometry.drawGeometry(rect10, Geometry, Display, RoundRectangleType.RoundRectAll, ref Grph);
			for (int l = 0; l <= base.TabCount - 1; l++)
			{
				bool flag4 = true;
				if (l <= TabPageVisible.Count - 1)
				{
					flag4 = TabPageVisible[l];
				}
				if (!flag4)
				{
					continue;
				}
				rectangle = GetTabRect(l);
				if (l != base.SelectedIndex)
				{
					RoundRectangleType roundRectangleType7 = RoundRectangleType.RoundRectNone;
					if (l == 0)
					{
						roundRectangleType7 = RoundRectangleType.RoundRectLeftUp;
					}
					if (l == base.TabCount - 1)
					{
						roundRectangleType7 = RoundRectangleType.RoundRectRightUp;
					}
					RectangleF rect11 = new RectangleF(rectangle.X + Tabs.HeaderXOffset, rectangle.Y - 2, rectangle.Width, rectangle.Height);
					ControlGeometry.drawGeometry(rect11, Geometry.ArcDiameter, Geometry.ShapeMode, Tabs.Header, roundRectangleType7, ref Grph);
					try
					{
						Point location = new Point(GetTabRect(l).Location.X + Tabs.HeaderXOffset, GetTabRect(l).Location.Y);
						Grph.DrawString(base.TabPages[l].Text, Tabs.Header.Fonts.Font, new SolidBrush(Tabs.Header.Fonts.ForeColor), new Rectangle(location, GetTabRect(l).Size), ControlGeometry.AlignmentToStringFormat(Tabs.Header.Fonts.Alignment));
						base.TabPages[l].BackColor = Tabs.TabPageColor;
					}
					catch
					{
					}
				}
				else
				{
					RoundRectangleType roundRectangleType8 = RoundRectangleType.RoundRectNone;
					if (l == 0)
					{
						roundRectangleType8 = RoundRectangleType.RoundRectLeftUp;
					}
					if (l == base.TabCount - 1)
					{
						roundRectangleType8 = RoundRectangleType.RoundRectRightUp;
					}
					RectangleF rect12 = new RectangleF(rectangle.X + Tabs.HeaderXOffset, rectangle.Y - 2, rectangle.Width, rectangle.Height);
					ControlGeometry.drawGeometry(rect12, Geometry, Tabs.HeaderSelected, roundRectangleType8, ref Grph);
					try
					{
						Point location2 = new Point(GetTabRect(l).Location.X + Tabs.HeaderXOffset, GetTabRect(l).Location.Y);
						Grph.DrawString(base.TabPages[l].Text, Tabs.HeaderSelected.Fonts.Font, new SolidBrush(Tabs.HeaderSelected.Fonts.ForeColor), new Rectangle(location2, GetTabRect(l).Size), ControlGeometry.AlignmentToStringFormat(Tabs.HeaderSelected.Fonts.Alignment));
						base.TabPages[l].BackColor = Tabs.TabPageColor;
					}
					catch
					{
					}
				}
			}
		}
		themeType_0 = Theme.Type;
		base.OnPaint(e);
	}

	public void PropertiesValueChanged()
	{
		Invalidate();
	}
}
