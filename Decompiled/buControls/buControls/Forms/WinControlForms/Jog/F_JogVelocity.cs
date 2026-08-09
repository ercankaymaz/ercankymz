using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Jog;

public class F_JogVelocity : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public EnableVisibleText AxisButton1Status = new EnableVisibleText(enable: true, visible: true, "X");

	public EnableVisibleText AxisButton2Status = new EnableVisibleText(enable: true, visible: true, "Y");

	public EnableVisibleText AxisButton3Status = new EnableVisibleText(enable: true, visible: true, "Z");

	public EnableVisibleText AxisButton4Status = new EnableVisibleText(enable: true, visible: false, "A");

	public EnableVisibleText AxisButton5Status = new EnableVisibleText(enable: true, visible: false, "B");

	public EnableVisibleText AxisButton6Status = new EnableVisibleText(enable: true, visible: false, "C");

	public EnableVisibleText AxisButton7Status = new EnableVisibleText(enable: true, visible: false, "U");

	public EnableVisibleText AxisButton8Status = new EnableVisibleText(enable: true, visible: false, "V");

	public EnableVisibleText AxisButton9Status = new EnableVisibleText(enable: true, visible: false, "W");

	public int SelectedAxis = 0;

	public Color colorSelected = Color.Blue;

	public Color colorUnSelected = Color.WhiteSmoke;

	[CompilerGenerated]
	private JogAxisChangedEventHandler jogAxisChangedEventHandler_0;

	[CompilerGenerated]
	private JogCommandEventHandler jogCommandEventHandler_0;

	internal IContainer icontainer_0 = null;

	internal Button button_0;

	internal Button button_1;

	internal ImageList imageList_0;

	internal Button button_2;

	internal Button button_3;

	internal Button button_4;

	internal Button button_5;

	internal Button button_6;

	internal Button button_7;

	internal Button button_8;

	internal Button button_9;

	internal Button button_10;

	public event JogAxisChangedEventHandler SelectedAxisChanged
	{
		[CompilerGenerated]
		add
		{
			JogAxisChangedEventHandler jogAxisChangedEventHandler = jogAxisChangedEventHandler_0;
			JogAxisChangedEventHandler jogAxisChangedEventHandler2;
			do
			{
				jogAxisChangedEventHandler2 = jogAxisChangedEventHandler;
				JogAxisChangedEventHandler value2 = (JogAxisChangedEventHandler)Delegate.Combine(jogAxisChangedEventHandler2, value);
				jogAxisChangedEventHandler = Interlocked.CompareExchange(ref jogAxisChangedEventHandler_0, value2, jogAxisChangedEventHandler2);
			}
			while ((object)jogAxisChangedEventHandler != jogAxisChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			JogAxisChangedEventHandler jogAxisChangedEventHandler = jogAxisChangedEventHandler_0;
			JogAxisChangedEventHandler jogAxisChangedEventHandler2;
			do
			{
				jogAxisChangedEventHandler2 = jogAxisChangedEventHandler;
				JogAxisChangedEventHandler value2 = (JogAxisChangedEventHandler)Delegate.Remove(jogAxisChangedEventHandler2, value);
				jogAxisChangedEventHandler = Interlocked.CompareExchange(ref jogAxisChangedEventHandler_0, value2, jogAxisChangedEventHandler2);
			}
			while ((object)jogAxisChangedEventHandler != jogAxisChangedEventHandler2);
		}
	}

	public event JogCommandEventHandler JogCommand
	{
		[CompilerGenerated]
		add
		{
			JogCommandEventHandler jogCommandEventHandler = jogCommandEventHandler_0;
			JogCommandEventHandler jogCommandEventHandler2;
			do
			{
				jogCommandEventHandler2 = jogCommandEventHandler;
				JogCommandEventHandler value2 = (JogCommandEventHandler)Delegate.Combine(jogCommandEventHandler2, value);
				jogCommandEventHandler = Interlocked.CompareExchange(ref jogCommandEventHandler_0, value2, jogCommandEventHandler2);
			}
			while ((object)jogCommandEventHandler != jogCommandEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			JogCommandEventHandler jogCommandEventHandler = jogCommandEventHandler_0;
			JogCommandEventHandler jogCommandEventHandler2;
			do
			{
				jogCommandEventHandler2 = jogCommandEventHandler;
				JogCommandEventHandler value2 = (JogCommandEventHandler)Delegate.Remove(jogCommandEventHandler2, value);
				jogCommandEventHandler = Interlocked.CompareExchange(ref jogCommandEventHandler_0, value2, jogCommandEventHandler2);
			}
			while ((object)jogCommandEventHandler != jogCommandEventHandler2);
		}
	}

	public F_JogVelocity()
	{
		Class76.smethod_398(this);
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (Properties.Result != DialogResult.OK)
		{
			e.Cancel = true;
			if (jogCommandEventHandler_0 != null)
			{
				JogCommandEventArg jogCommandEventArg = new JogCommandEventArg();
				jogCommandEventArg.Command = JogCommandType.StopAll;
				jogCommandEventHandler_0(sender, jogCommandEventArg);
			}
			Properties.Result = DialogResult.Cancel;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	public void Init()
	{
		Properties.Inited = false;
		if (Properties.Height > 10)
		{
			base.Height = Properties.Height;
		}
		if (Properties.Width > 10)
		{
			base.Width = Properties.Width;
		}
		base.TopMost = Properties.TopMost;
		base.StartPosition = Properties.FormPosition;
		base.AutoScaleMode = Properties.ScaleFromMode;
		button_2.Enabled = AxisButton1Status.Enable;
		button_2.Visible = AxisButton1Status.Visible;
		button_2.Text = AxisButton1Status.Text;
		button_2.BackColor = colorUnSelected;
		button_3.Enabled = AxisButton2Status.Enable;
		button_3.Visible = AxisButton2Status.Visible;
		button_3.Text = AxisButton2Status.Text;
		button_3.BackColor = colorUnSelected;
		button_4.Enabled = AxisButton3Status.Enable;
		button_4.Visible = AxisButton3Status.Visible;
		button_4.Text = AxisButton3Status.Text;
		button_4.BackColor = colorUnSelected;
		button_7.Enabled = AxisButton4Status.Enable;
		button_7.Visible = AxisButton4Status.Visible;
		button_7.Text = AxisButton4Status.Text;
		button_7.BackColor = colorUnSelected;
		button_6.Enabled = AxisButton5Status.Enable;
		button_6.Visible = AxisButton5Status.Visible;
		button_6.Text = AxisButton5Status.Text;
		button_6.BackColor = colorUnSelected;
		button_5.Enabled = AxisButton6Status.Enable;
		button_5.Visible = AxisButton6Status.Visible;
		button_5.Text = AxisButton6Status.Text;
		button_5.BackColor = colorUnSelected;
		button_10.Enabled = AxisButton7Status.Enable;
		button_10.Visible = AxisButton7Status.Visible;
		button_10.Text = AxisButton7Status.Text;
		button_10.BackColor = colorUnSelected;
		button_9.Enabled = AxisButton8Status.Enable;
		button_9.Visible = AxisButton8Status.Visible;
		button_9.Text = AxisButton8Status.Text;
		button_9.BackColor = colorUnSelected;
		button_8.Enabled = AxisButton9Status.Enable;
		button_8.Visible = AxisButton9Status.Visible;
		button_8.Text = AxisButton9Status.Text;
		button_8.BackColor = colorUnSelected;
		if (SelectedAxis == 0)
		{
			button_2.BackColor = colorSelected;
		}
		if (SelectedAxis == 1)
		{
			button_3.BackColor = colorSelected;
		}
		if (SelectedAxis == 2)
		{
			button_4.BackColor = colorSelected;
		}
		if (SelectedAxis == 3)
		{
			button_7.BackColor = colorSelected;
		}
		if (SelectedAxis == 4)
		{
			button_6.BackColor = colorSelected;
		}
		if (SelectedAxis == 5)
		{
			button_5.BackColor = colorSelected;
		}
		if (SelectedAxis == 6)
		{
			button_10.BackColor = colorSelected;
		}
		if (SelectedAxis == 7)
		{
			button_9.BackColor = colorSelected;
		}
		if (SelectedAxis == 8)
		{
			button_8.BackColor = colorSelected;
		}
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		button_2.BackColor = colorUnSelected;
		button_3.BackColor = colorUnSelected;
		button_4.BackColor = colorUnSelected;
		button_7.BackColor = colorUnSelected;
		button_6.BackColor = colorUnSelected;
		button_5.BackColor = colorUnSelected;
		button_10.BackColor = colorUnSelected;
		button_9.BackColor = colorUnSelected;
		button_8.BackColor = colorUnSelected;
		if (control.Name == button_2.Name)
		{
			if (jogAxisChangedEventHandler_0 != null)
			{
				jogAxisChangedEventHandler_0(button_2, 0);
			}
			button_2.BackColor = colorSelected;
		}
		if (control.Name == button_3.Name)
		{
			if (jogAxisChangedEventHandler_0 != null)
			{
				jogAxisChangedEventHandler_0(sender, 1);
			}
			button_3.BackColor = colorSelected;
		}
		if (control.Name == button_4.Name)
		{
			if (jogAxisChangedEventHandler_0 != null)
			{
				jogAxisChangedEventHandler_0(sender, 2);
			}
			button_4.BackColor = colorSelected;
		}
		if (control.Name == button_7.Name)
		{
			if (jogAxisChangedEventHandler_0 != null)
			{
				jogAxisChangedEventHandler_0(sender, 3);
			}
			button_7.BackColor = colorSelected;
		}
		if (control.Name == button_6.Name)
		{
			if (jogAxisChangedEventHandler_0 != null)
			{
				jogAxisChangedEventHandler_0(sender, 4);
			}
			button_6.BackColor = colorSelected;
		}
		if (control.Name == button_5.Name)
		{
			if (jogAxisChangedEventHandler_0 != null)
			{
				jogAxisChangedEventHandler_0(sender, 5);
			}
			button_5.BackColor = colorSelected;
		}
		if (control.Name == button_10.Name)
		{
			if (jogAxisChangedEventHandler_0 != null)
			{
				jogAxisChangedEventHandler_0(sender, 6);
			}
			button_10.BackColor = colorSelected;
		}
		if (control.Name == button_9.Name)
		{
			if (jogAxisChangedEventHandler_0 != null)
			{
				jogAxisChangedEventHandler_0(sender, 7);
			}
			button_9.BackColor = colorSelected;
		}
		if (control.Name == button_8.Name)
		{
			if (jogAxisChangedEventHandler_0 != null)
			{
				jogAxisChangedEventHandler_0(sender, 8);
			}
			button_8.BackColor = colorSelected;
		}
	}

	internal void method_2(object sender, MouseEventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_1.Name && jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg = new JogCommandEventArg();
			jogCommandEventArg.SelectedAxis = SelectedAxis;
			jogCommandEventArg.Command = JogCommandType.VelocityPlus;
			jogCommandEventHandler_0(sender, jogCommandEventArg);
		}
		if (control.Name == button_0.Name && jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg2 = new JogCommandEventArg();
			jogCommandEventArg2.SelectedAxis = SelectedAxis;
			jogCommandEventArg2.Command = JogCommandType.VelocityMinus;
			jogCommandEventHandler_0(sender, jogCommandEventArg2);
		}
	}

	internal void method_3(object sender, MouseEventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_1.Name && jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg = new JogCommandEventArg();
			jogCommandEventArg.Command = JogCommandType.StopAll;
			jogCommandEventHandler_0(sender, jogCommandEventArg);
		}
		if (control.Name == button_0.Name && jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg2 = new JogCommandEventArg();
			jogCommandEventArg2.Command = JogCommandType.StopAll;
			jogCommandEventHandler_0(sender, jogCommandEventArg2);
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_1.Name && jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg = new JogCommandEventArg();
			jogCommandEventArg.Command = JogCommandType.StopAll;
			jogCommandEventHandler_0(sender, jogCommandEventArg);
		}
		if (control.Name == button_0.Name && jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg2 = new JogCommandEventArg();
			jogCommandEventArg2.Command = JogCommandType.StopAll;
			jogCommandEventHandler_0(sender, jogCommandEventArg2);
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
