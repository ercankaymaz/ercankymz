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

namespace buControls.Forms.buControlForms.Settings;

public class F_AbsoluteHome : Form
{
	[CompilerGenerated]
	private AbsoluteHomeSetEventHandle absoluteHomeSetEventHandle_0;

	public List<string> Captions = new List<string>();

	public int DecimalPoint = 2;

	public double IncrementStep = 0.1;

	public AxesEnableWithUVW parAbsoluteHomeAxisEnable = new AxesEnableWithUVW();

	public string[] parAxisString = new string[9] { "X", "Y", "Z", "A", "B", "C", "U", "V", "W" };

	public int[] parAxisIndex = new int[9] { 0, 1, 2, 3, 4, 4, -1, -1, -1 };

	public bool FormTopMost = false;

	public bool ReadOnly = false;

	public bool ScreenCenter = true;

	private buSpin Offset = new buSpin();

	private buButton buButton_0 = new buButton();

	private IContainer icontainer_0 = null;

	internal buPanel buPanel_0;

	internal buGround buGround_0;

	internal buButton buButton_1;

	public event AbsoluteHomeSetEventHandle AbsoluteHomeSet
	{
		[CompilerGenerated]
		add
		{
			AbsoluteHomeSetEventHandle absoluteHomeSetEventHandle = absoluteHomeSetEventHandle_0;
			AbsoluteHomeSetEventHandle absoluteHomeSetEventHandle2;
			do
			{
				absoluteHomeSetEventHandle2 = absoluteHomeSetEventHandle;
				AbsoluteHomeSetEventHandle value2 = (AbsoluteHomeSetEventHandle)Delegate.Combine(absoluteHomeSetEventHandle2, value);
				absoluteHomeSetEventHandle = Interlocked.CompareExchange(ref absoluteHomeSetEventHandle_0, value2, absoluteHomeSetEventHandle2);
			}
			while ((object)absoluteHomeSetEventHandle != absoluteHomeSetEventHandle2);
		}
		[CompilerGenerated]
		remove
		{
			AbsoluteHomeSetEventHandle absoluteHomeSetEventHandle = absoluteHomeSetEventHandle_0;
			AbsoluteHomeSetEventHandle absoluteHomeSetEventHandle2;
			do
			{
				absoluteHomeSetEventHandle2 = absoluteHomeSetEventHandle;
				AbsoluteHomeSetEventHandle value2 = (AbsoluteHomeSetEventHandle)Delegate.Remove(absoluteHomeSetEventHandle2, value);
				absoluteHomeSetEventHandle = Interlocked.CompareExchange(ref absoluteHomeSetEventHandle_0, value2, absoluteHomeSetEventHandle2);
			}
			while ((object)absoluteHomeSetEventHandle != absoluteHomeSetEventHandle2);
		}
	}

	public F_AbsoluteHome()
	{
		Class76.smethod_641(this);
	}

	public void Init()
	{
		try
		{
			base.TopMost = FormTopMost;
			int num = 0;
			if (parAbsoluteHomeAxisEnable.X)
			{
				num++;
			}
			if (parAbsoluteHomeAxisEnable.Y)
			{
				num++;
			}
			if (parAbsoluteHomeAxisEnable.Z)
			{
				num++;
			}
			if (parAbsoluteHomeAxisEnable.A)
			{
				num++;
			}
			if (parAbsoluteHomeAxisEnable.B)
			{
				num++;
			}
			if (parAbsoluteHomeAxisEnable.C)
			{
				num++;
			}
			if (parAbsoluteHomeAxisEnable.U)
			{
				num++;
			}
			if (parAbsoluteHomeAxisEnable.V)
			{
				num++;
			}
			if (parAbsoluteHomeAxisEnable.W)
			{
				num++;
			}
			if (num > 0)
			{
				int num2 = Convert.ToInt32(Convert.ToDouble(buPanel_0.Height) / Convert.ToDouble(num)) - 5;
				int num3 = 0;
				int num4 = 3;
				buPanel_0.Controls.Clear();
				for (int i = 0; i <= parAxisString.Length - 1; i++)
				{
					bool flag = false;
					if (i <= parAxisString.Length - 1)
					{
						Offset = new buSpin();
						Offset.Name = "Offset";
						Offset.Font = new Font("Times New Roman", (float)num2 / 2f, FontStyle.Bold);
						Offset.Size = new Size(Convert.ToInt32((double)buPanel_0.Width * 0.6), num2);
						Offset.Tag = parAxisIndex[i];
						Offset.MinValue = -999999999999.0;
						Offset.MaxValue = 999999999999.0;
						Offset.DecimalPoint = DecimalPoint;
						Offset.IncrementStep = IncrementStep;
						Offset.Caption.Visible = true;
						Offset.Caption.Width = 50;
						Offset.Caption.Caption = parAxisString[i];
						Offset.Location = new Point(2, num4 + num3 * (num2 + 2));
						Offset.Enter += Offset_Enter;
						buButton_0 = new buButton();
						buButton_0.Font = new Font("Times New Roman", (float)num2 / 3f, FontStyle.Bold);
						buButton_0.Size = new Size(buPanel_0.Width - Offset.Width - 8, num2);
						buButton_0.Text = "Set " + parAxisString[i];
						buButton_0.Click += buButton_0_Click;
						buButton_0.Tag = parAxisIndex[i];
						buButton_0.Location = new Point(Offset.Left + Offset.Width + 4, num4 + num3 * (num2 + 2));
						if ((i == 0) & parAbsoluteHomeAxisEnable.X)
						{
							flag = true;
						}
						if ((i == 1) & parAbsoluteHomeAxisEnable.Y)
						{
							flag = true;
						}
						if ((i == 2) & parAbsoluteHomeAxisEnable.Z)
						{
							flag = true;
						}
						if ((i == 3) & parAbsoluteHomeAxisEnable.A)
						{
							flag = true;
						}
						if ((i == 4) & parAbsoluteHomeAxisEnable.B)
						{
							flag = true;
						}
						if ((i == 5) & parAbsoluteHomeAxisEnable.C)
						{
							flag = true;
						}
						if ((i == 6) & parAbsoluteHomeAxisEnable.U)
						{
							flag = true;
						}
						if ((i == 7) & parAbsoluteHomeAxisEnable.V)
						{
							flag = true;
						}
						if ((i == 8) & parAbsoluteHomeAxisEnable.W)
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
				LoadLanguage();
				if (ScreenCenter)
				{
					base.StartPosition = FormStartPosition.CenterScreen;
				}
			}
			else
			{
				MessageBox.Show("No Home Value");
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
				buButton_1.Text = Captions[6];
			}
		}
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: false);
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
			for (int i = 0; i <= buPanel_0.Controls.Count - 1; i++)
			{
				if (buPanel_0.Controls[i].GetType() == typeof(buSpin))
				{
					buSpin buSpin2 = new buSpin();
					buSpin2 = (buSpin)buPanel_0.Controls[i];
					if (buSpin2.Name == "Offset" && int.Parse(buSpin2.Tag.ToString()) == int.Parse(buButton2.Tag.ToString()) && absoluteHomeSetEventHandle_0 != null)
					{
						absoluteHomeSetEventHandle_0(int.Parse(buSpin2.Tag.ToString()), ((buSpin)buPanel_0.Controls[i]).Value);
					}
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

	internal void method_0(object sender, EventArgs e)
	{
		base.Visible = false;
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
