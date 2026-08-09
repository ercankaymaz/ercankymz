using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns27;

namespace buControls.Forms.buControlForms.G54;

public class F_G54 : Form
{
	[CompilerGenerated]
	private G54GetPosEventHandler g54GetPosEventHandler_0;

	[CompilerGenerated]
	private G54ChangedEventHandler g54ChangedEventHandler_0;

	[CompilerGenerated]
	private G54GetAllPosEventHandler g54GetAllPosEventHandler_0;

	[CompilerGenerated]
	private PageClosedEventHandler pageClosedEventHandler_0;

	public List<string> Captions = new List<string>();

	public List<Pnt9D> parG54List = new List<Pnt9D>();

	public List<Pnt9D> parG54SetValue = new List<Pnt9D>();

	public int parG54Index = 0;

	public int DecimalPoint = 2;

	public double IncrementStep = 0.1;

	public bool DisableSetAllButton = false;

	public AxesEnableWithUVW parG54OffsetAxisEnable = new AxesEnableWithUVW();

	public string[] parAxisString = new string[9] { "X", "Y", "Z", "A", "B", "C", "U", "V", "W" };

	public bool FormTopMost = false;

	public bool ReadOnly = false;

	public bool ScreenCenter = true;

	private buSpin Offset = new buSpin();

	private buSpin buSpin_0 = new buSpin();

	private buButton buButton_0 = new buButton();

	private buButton buButton_1 = new buButton();

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	internal buButton buButton_2;

	internal buButton buButton_3;

	internal buPanel buPanel_0;

	internal buButton buButton_4;

	internal buSpin buSpin_1;

	public event G54GetPosEventHandler G54GetPos
	{
		[CompilerGenerated]
		add
		{
			G54GetPosEventHandler g54GetPosEventHandler = g54GetPosEventHandler_0;
			G54GetPosEventHandler g54GetPosEventHandler2;
			do
			{
				g54GetPosEventHandler2 = g54GetPosEventHandler;
				G54GetPosEventHandler value2 = (G54GetPosEventHandler)Delegate.Combine(g54GetPosEventHandler2, value);
				g54GetPosEventHandler = Interlocked.CompareExchange(ref g54GetPosEventHandler_0, value2, g54GetPosEventHandler2);
			}
			while ((object)g54GetPosEventHandler != g54GetPosEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			G54GetPosEventHandler g54GetPosEventHandler = g54GetPosEventHandler_0;
			G54GetPosEventHandler g54GetPosEventHandler2;
			do
			{
				g54GetPosEventHandler2 = g54GetPosEventHandler;
				G54GetPosEventHandler value2 = (G54GetPosEventHandler)Delegate.Remove(g54GetPosEventHandler2, value);
				g54GetPosEventHandler = Interlocked.CompareExchange(ref g54GetPosEventHandler_0, value2, g54GetPosEventHandler2);
			}
			while ((object)g54GetPosEventHandler != g54GetPosEventHandler2);
		}
	}

	public event G54ChangedEventHandler G54Changed
	{
		[CompilerGenerated]
		add
		{
			G54ChangedEventHandler g54ChangedEventHandler = g54ChangedEventHandler_0;
			G54ChangedEventHandler g54ChangedEventHandler2;
			do
			{
				g54ChangedEventHandler2 = g54ChangedEventHandler;
				G54ChangedEventHandler value2 = (G54ChangedEventHandler)Delegate.Combine(g54ChangedEventHandler2, value);
				g54ChangedEventHandler = Interlocked.CompareExchange(ref g54ChangedEventHandler_0, value2, g54ChangedEventHandler2);
			}
			while ((object)g54ChangedEventHandler != g54ChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			G54ChangedEventHandler g54ChangedEventHandler = g54ChangedEventHandler_0;
			G54ChangedEventHandler g54ChangedEventHandler2;
			do
			{
				g54ChangedEventHandler2 = g54ChangedEventHandler;
				G54ChangedEventHandler value2 = (G54ChangedEventHandler)Delegate.Remove(g54ChangedEventHandler2, value);
				g54ChangedEventHandler = Interlocked.CompareExchange(ref g54ChangedEventHandler_0, value2, g54ChangedEventHandler2);
			}
			while ((object)g54ChangedEventHandler != g54ChangedEventHandler2);
		}
	}

	public event G54GetAllPosEventHandler G54GetPosAll
	{
		[CompilerGenerated]
		add
		{
			G54GetAllPosEventHandler g54GetAllPosEventHandler = g54GetAllPosEventHandler_0;
			G54GetAllPosEventHandler g54GetAllPosEventHandler2;
			do
			{
				g54GetAllPosEventHandler2 = g54GetAllPosEventHandler;
				G54GetAllPosEventHandler value2 = (G54GetAllPosEventHandler)Delegate.Combine(g54GetAllPosEventHandler2, value);
				g54GetAllPosEventHandler = Interlocked.CompareExchange(ref g54GetAllPosEventHandler_0, value2, g54GetAllPosEventHandler2);
			}
			while ((object)g54GetAllPosEventHandler != g54GetAllPosEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			G54GetAllPosEventHandler g54GetAllPosEventHandler = g54GetAllPosEventHandler_0;
			G54GetAllPosEventHandler g54GetAllPosEventHandler2;
			do
			{
				g54GetAllPosEventHandler2 = g54GetAllPosEventHandler;
				G54GetAllPosEventHandler value2 = (G54GetAllPosEventHandler)Delegate.Remove(g54GetAllPosEventHandler2, value);
				g54GetAllPosEventHandler = Interlocked.CompareExchange(ref g54GetAllPosEventHandler_0, value2, g54GetAllPosEventHandler2);
			}
			while ((object)g54GetAllPosEventHandler != g54GetAllPosEventHandler2);
		}
	}

	public event PageClosedEventHandler G54PageClosed
	{
		[CompilerGenerated]
		add
		{
			PageClosedEventHandler pageClosedEventHandler = pageClosedEventHandler_0;
			PageClosedEventHandler pageClosedEventHandler2;
			do
			{
				pageClosedEventHandler2 = pageClosedEventHandler;
				PageClosedEventHandler value2 = (PageClosedEventHandler)Delegate.Combine(pageClosedEventHandler2, value);
				pageClosedEventHandler = Interlocked.CompareExchange(ref pageClosedEventHandler_0, value2, pageClosedEventHandler2);
			}
			while ((object)pageClosedEventHandler != pageClosedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PageClosedEventHandler pageClosedEventHandler = pageClosedEventHandler_0;
			PageClosedEventHandler pageClosedEventHandler2;
			do
			{
				pageClosedEventHandler2 = pageClosedEventHandler;
				PageClosedEventHandler value2 = (PageClosedEventHandler)Delegate.Remove(pageClosedEventHandler2, value);
				pageClosedEventHandler = Interlocked.CompareExchange(ref pageClosedEventHandler_0, value2, pageClosedEventHandler2);
			}
			while ((object)pageClosedEventHandler != pageClosedEventHandler2);
		}
	}

	public F_G54()
	{
		Class76.smethod_338(this);
	}

	public void Init()
	{
		try
		{
			base.TopMost = FormTopMost;
			int num = 0;
			if (parG54List.Count == 0)
			{
				parG54SetValue.Clear();
				parG54List.Add(new Pnt9D());
				parG54List.Add(new Pnt9D());
				parG54List.Add(new Pnt9D());
				parG54SetValue.Add(new Pnt9D());
				parG54SetValue.Add(new Pnt9D());
				parG54SetValue.Add(new Pnt9D());
			}
			buButton_3.Enabled = !DisableSetAllButton;
			if (parG54OffsetAxisEnable.X)
			{
				num++;
			}
			if (parG54OffsetAxisEnable.Y)
			{
				num++;
			}
			if (parG54OffsetAxisEnable.Z)
			{
				num++;
			}
			if (parG54OffsetAxisEnable.A)
			{
				num++;
			}
			if (parG54OffsetAxisEnable.B)
			{
				num++;
			}
			if (parG54OffsetAxisEnable.C)
			{
				num++;
			}
			if (parG54OffsetAxisEnable.U)
			{
				num++;
			}
			if (parG54OffsetAxisEnable.V)
			{
				num++;
			}
			if (parG54OffsetAxisEnable.W)
			{
				num++;
			}
			if (num > 0)
			{
				int num2 = Convert.ToInt32(Convert.ToDouble(buPanel_0.Height) / Convert.ToDouble(num)) - 5;
				int num3 = 0;
				int num4 = 3;
				buPanel_0.Controls.Clear();
				for (int i = 0; i <= num - 1; i++)
				{
					bool flag = false;
					if (i <= parAxisString.Length - 1)
					{
						Offset = new buSpin();
						Offset.Name = "Offset";
						Offset.Font = new Font("Times New Roman", (float)num2 / 2f, FontStyle.Bold);
						Offset.Size = new Size(Convert.ToInt32((double)buPanel_0.Width * 0.6), num2);
						Offset.Tag = i;
						Offset.MinValue = -999999999999.0;
						Offset.MaxValue = 999999999999.0;
						Offset.DecimalPoint = DecimalPoint;
						Offset.IncrementStep = IncrementStep;
						Offset.Caption.Visible = true;
						Offset.Caption.Width = 50;
						Offset.Caption.Caption = parAxisString[i];
						Offset.Location = new Point(2, num4 + num3 * (num2 + 2));
						Offset.CaptionClicked += Offset_CaptionClicked;
						Offset.Enter += Offset_Enter;
						buButton_0 = new buButton();
						buButton_0.Font = new Font("Times New Roman", (float)num2 / 3f, FontStyle.Bold);
						buButton_0.Size = new Size(buPanel_0.Width - Offset.Width - 8, num2);
						buButton_0.Text = "Set " + parAxisString[i];
						buButton_0.Click += buButton_0_Click;
						buButton_0.Tag = i;
						buButton_0.Location = new Point(Offset.Left + Offset.Width + 4, num4 + num3 * (num2 + 2));
						if ((i == 0) & parG54OffsetAxisEnable.X)
						{
							flag = true;
						}
						if ((i == 1) & parG54OffsetAxisEnable.Y)
						{
							flag = true;
						}
						if ((i == 2) & parG54OffsetAxisEnable.Z)
						{
							flag = true;
						}
						if ((i == 3) & parG54OffsetAxisEnable.A)
						{
							flag = true;
						}
						if ((i == 4) & parG54OffsetAxisEnable.B)
						{
							flag = true;
						}
						if ((i == 5) & parG54OffsetAxisEnable.C)
						{
							flag = true;
						}
						if ((i == 6) & parG54OffsetAxisEnable.U)
						{
							flag = true;
						}
						if ((i == 7) & parG54OffsetAxisEnable.V)
						{
							flag = true;
						}
						if ((i == 8) & parG54OffsetAxisEnable.W)
						{
							flag = true;
						}
						if (flag)
						{
							buPanel_0.Controls.Add(Offset);
							buPanel_0.Controls.Add(buButton_0);
							num3++;
						}
					}
				}
				buSpin_1.MinValue = 0.0;
				buSpin_1.MaxValue = parG54List.Count - 1;
				method_0(parG54Index);
				LoadLanguage();
				if (ScreenCenter)
				{
					base.StartPosition = FormStartPosition.CenterScreen;
				}
			}
			else
			{
				MessageBox.Show("No Offset Value");
			}
		}
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: false);
		}
	}

	public void LoadLanguage()
	{
		try
		{
			if (Captions.Count >= 7)
			{
				Text = Captions[0];
				buButton_2.Text = Captions[6];
			}
		}
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: false);
		}
	}

	public void UpdateOffsetValues(int AxisIndex, double Value)
	{
		try
		{
			Pnt9D pnt9D = new Pnt9D(parG54List[parG54Index]);
			for (int i = 0; i <= buPanel_0.Controls.Count - 1; i++)
			{
				if (!(buPanel_0.Controls[i].GetType() == typeof(buSpin)))
				{
					continue;
				}
				buSpin buSpin2 = new buSpin();
				buSpin2 = (buSpin)buPanel_0.Controls[i];
				if (buSpin2.Name == "Offset" && int.Parse(buSpin2.Tag.ToString()) == AxisIndex)
				{
					((buSpin)buPanel_0.Controls[i]).Value = Value;
					if (AxisIndex == 0)
					{
						pnt9D.X = Value;
					}
					if (AxisIndex == 1)
					{
						pnt9D.Y = Value;
					}
					if (AxisIndex == 2)
					{
						pnt9D.Z = Value;
					}
					if (AxisIndex == 3)
					{
						pnt9D.A = Value;
					}
					if (AxisIndex == 4)
					{
						pnt9D.B = Value;
					}
					if (AxisIndex == 5)
					{
						pnt9D.C = Value;
					}
					if (AxisIndex == 6)
					{
						pnt9D.U = Value;
					}
					if (AxisIndex == 7)
					{
						pnt9D.V = Value;
					}
					if (AxisIndex == 8)
					{
						pnt9D.W = Value;
					}
					parG54List[parG54Index] = new Pnt9D(pnt9D);
				}
			}
			if (g54ChangedEventHandler_0 != null)
			{
				g54ChangedEventHandler_0(parG54List, parG54SetValue);
			}
		}
		catch (Exception ee)
		{
			string message = "AxisIndex: " + AxisIndex + " - Value: " + Value;
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: false);
		}
	}

	private void method_0(int int_0)
	{
		try
		{
			for (int i = 0; i <= buPanel_0.Controls.Count - 1; i++)
			{
				if (!(buPanel_0.Controls[i].GetType() == typeof(buSpin)))
				{
					continue;
				}
				buSpin buSpin2 = new buSpin();
				buSpin2 = (buSpin)buPanel_0.Controls[i];
				if (buSpin2.Name == "Offset")
				{
					if (int.Parse(buSpin2.Tag.ToString()) == 0)
					{
						((buSpin)buPanel_0.Controls[i]).Value = parG54List[int_0].X;
					}
					if (int.Parse(buSpin2.Tag.ToString()) == 1)
					{
						((buSpin)buPanel_0.Controls[i]).Value = parG54List[int_0].Y;
					}
					if (int.Parse(buSpin2.Tag.ToString()) == 2)
					{
						((buSpin)buPanel_0.Controls[i]).Value = parG54List[int_0].Z;
					}
					if (int.Parse(buSpin2.Tag.ToString()) == 3)
					{
						((buSpin)buPanel_0.Controls[i]).Value = parG54List[int_0].A;
					}
					if (int.Parse(buSpin2.Tag.ToString()) == 4)
					{
						((buSpin)buPanel_0.Controls[i]).Value = parG54List[int_0].B;
					}
					if (int.Parse(buSpin2.Tag.ToString()) == 5)
					{
						((buSpin)buPanel_0.Controls[i]).Value = parG54List[int_0].C;
					}
					if (int.Parse(buSpin2.Tag.ToString()) == 6)
					{
						((buSpin)buPanel_0.Controls[i]).Value = parG54List[int_0].U;
					}
					if (int.Parse(buSpin2.Tag.ToString()) == 7)
					{
						((buSpin)buPanel_0.Controls[i]).Value = parG54List[int_0].V;
					}
					if (int.Parse(buSpin2.Tag.ToString()) == 8)
					{
						((buSpin)buPanel_0.Controls[i]).Value = parG54List[int_0].W;
					}
				}
			}
		}
		catch (Exception ee)
		{
			string message = "G54Index: " + int_0;
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: true);
		}
	}

	private void buButton_0_Click(object sender, EventArgs e)
	{
		try
		{
			if (!(sender.GetType() == typeof(buButton)))
			{
				return;
			}
			buButton buButton2 = new buButton();
			buButton2 = (buButton)sender;
			if (!((parG54Index >= 0) & (parG54Index <= parG54List.Count - 1)))
			{
				return;
			}
			Pnt9D pnt9D = new Pnt9D(parG54List[parG54Index]);
			for (int i = 0; i <= buPanel_0.Controls.Count - 1; i++)
			{
				if (!(buPanel_0.Controls[i].GetType() == typeof(buSpin)))
				{
					continue;
				}
				buSpin buSpin2 = new buSpin();
				buSpin2 = (buSpin)buPanel_0.Controls[i];
				if (buSpin2.Name == "Offset" && int.Parse(buSpin2.Tag.ToString()) == int.Parse(buButton2.Tag.ToString()))
				{
					if (int.Parse(buSpin2.Tag.ToString()) == 0)
					{
						pnt9D.X = ((buSpin)buPanel_0.Controls[i]).Value;
					}
					if (int.Parse(buSpin2.Tag.ToString()) == 1)
					{
						pnt9D.Y = ((buSpin)buPanel_0.Controls[i]).Value;
					}
					if (int.Parse(buSpin2.Tag.ToString()) == 2)
					{
						pnt9D.Z = ((buSpin)buPanel_0.Controls[i]).Value;
					}
					if (int.Parse(buSpin2.Tag.ToString()) == 3)
					{
						pnt9D.A = ((buSpin)buPanel_0.Controls[i]).Value;
					}
					if (int.Parse(buSpin2.Tag.ToString()) == 4)
					{
						pnt9D.B = ((buSpin)buPanel_0.Controls[i]).Value;
					}
					if (int.Parse(buSpin2.Tag.ToString()) == 5)
					{
						pnt9D.C = ((buSpin)buPanel_0.Controls[i]).Value;
					}
					if (int.Parse(buSpin2.Tag.ToString()) == 6)
					{
						pnt9D.U = ((buSpin)buPanel_0.Controls[i]).Value;
					}
					if (int.Parse(buSpin2.Tag.ToString()) == 7)
					{
						pnt9D.V = ((buSpin)buPanel_0.Controls[i]).Value;
					}
					if (int.Parse(buSpin2.Tag.ToString()) == 8)
					{
						pnt9D.W = ((buSpin)buPanel_0.Controls[i]).Value;
					}
				}
			}
			parG54List[parG54Index] = new Pnt9D(pnt9D);
			if (g54ChangedEventHandler_0 != null)
			{
				g54ChangedEventHandler_0(parG54List, parG54SetValue);
			}
		}
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: true);
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if (!(control.Name == buButton_3.Name))
			{
				return;
			}
			if ((parG54Index >= 0) & (parG54Index <= parG54List.Count - 1))
			{
				Pnt9D pnt9D = new Pnt9D(parG54List[parG54Index]);
				for (int i = 0; i <= buPanel_0.Controls.Count - 1; i++)
				{
					if (!(buPanel_0.Controls[i].GetType() == typeof(buSpin)))
					{
						continue;
					}
					buSpin buSpin2 = new buSpin();
					buSpin2 = (buSpin)buPanel_0.Controls[i];
					if (buSpin2.Name == "Offset")
					{
						if (int.Parse(buSpin2.Tag.ToString()) == 0)
						{
							pnt9D.X = ((buSpin)buPanel_0.Controls[i]).Value;
						}
						if (int.Parse(buSpin2.Tag.ToString()) == 1)
						{
							pnt9D.Y = ((buSpin)buPanel_0.Controls[i]).Value;
						}
						if (int.Parse(buSpin2.Tag.ToString()) == 2)
						{
							pnt9D.Z = ((buSpin)buPanel_0.Controls[i]).Value;
						}
						if (int.Parse(buSpin2.Tag.ToString()) == 3)
						{
							pnt9D.A = ((buSpin)buPanel_0.Controls[i]).Value;
						}
						if (int.Parse(buSpin2.Tag.ToString()) == 4)
						{
							pnt9D.B = ((buSpin)buPanel_0.Controls[i]).Value;
						}
						if (int.Parse(buSpin2.Tag.ToString()) == 5)
						{
							pnt9D.C = ((buSpin)buPanel_0.Controls[i]).Value;
						}
						if (int.Parse(buSpin2.Tag.ToString()) == 6)
						{
							pnt9D.U = ((buSpin)buPanel_0.Controls[i]).Value;
						}
						if (int.Parse(buSpin2.Tag.ToString()) == 7)
						{
							pnt9D.V = ((buSpin)buPanel_0.Controls[i]).Value;
						}
						if (int.Parse(buSpin2.Tag.ToString()) == 8)
						{
							pnt9D.W = ((buSpin)buPanel_0.Controls[i]).Value;
						}
					}
				}
				parG54List[parG54Index] = new Pnt9D(pnt9D);
			}
			if (g54ChangedEventHandler_0 != null)
			{
				g54ChangedEventHandler_0(parG54List, parG54SetValue);
			}
		}
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: true);
		}
	}

	private void Offset_CaptionClicked(object sender, EventArgs e)
	{
		try
		{
			if (!(sender.GetType() == typeof(buSpin)))
			{
				return;
			}
			buSpin buSpin2 = new buSpin();
			buSpin2 = (buSpin)sender;
			if ((parG54Index >= 0) & (parG54Index <= parG54List.Count - 1))
			{
				int axis = int.Parse(buSpin2.Tag.ToString());
				if (g54GetPosEventHandler_0 != null)
				{
					g54GetPosEventHandler_0(axis);
				}
			}
		}
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: true);
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		try
		{
			if (g54GetAllPosEventHandler_0 != null)
			{
				g54GetAllPosEventHandler_0();
			}
		}
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: true);
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		if (pageClosedEventHandler_0 != null)
		{
			pageClosedEventHandler_0(new PageClosedEventArg());
		}
		base.Visible = false;
	}

	internal void method_4(object object_0, double double_0)
	{
		try
		{
			parG54Index = (int)buSpin_1.Value;
			if ((parG54Index >= 0) & (parG54Index <= parG54List.Count - 1))
			{
				method_0(parG54Index);
			}
		}
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: true);
		}
	}

	private void Offset_Enter(object sender, EventArgs e)
	{
		try
		{
			if (AppBool.TouchPad)
			{
				buSpin buSpin2 = new buSpin();
				buSpin2 = (buSpin)sender;
				buControlCommands.ShowKeyPad(this, buSpin2);
			}
		}
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: true);
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
