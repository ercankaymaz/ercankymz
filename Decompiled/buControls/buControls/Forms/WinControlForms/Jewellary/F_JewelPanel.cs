using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Jewellary;

public class F_JewelPanel : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public int SelectedAxis = 0;

	public Color colorSelected = Color.Blue;

	public Color colorUnSelected = Color.WhiteSmoke;

	[CompilerGenerated]
	private JogAxisChangedEventHandler jogAxisChangedEventHandler_0;

	[CompilerGenerated]
	private JogCommandEventHandler jogCommandEventHandler_0;

	[CompilerGenerated]
	private OkCommandEventHandler okCommandEventHandler_0;

	[CompilerGenerated]
	private CancelCommandEventHandler cancelCommandEventHandler_0;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal Button button_0;

	internal Button button_1;

	public Button btn_handwheelenable;

	public Button btn_spindlepsitondown;

	public Button btn_spindlepistonup;

	public Button btn_diameterpistonup;

	public Button btn_diameterpistondown;

	public Button btn_magazineclose;

	public Button btn_magazineopen;

	public Button btn_stop;

	public Button btn_pensclose;

	public Button btn_pensopen;

	public Button btn_spindlestop;

	public Button btn_spindlestart;

	public Button btn_diacut1stop;

	public Button btn_diacut1start;

	public Button btn_diacut2stop;

	public Button btn_diacut2start;

	public Button btn_engravestop;

	public Button btn_engravestart;

	public Button btn_lathestop;

	public Button btn_lathestart;

	public Button btn_laserstop;

	public Button btn_laserstart;

	public Label label1;

	public NumericUpDown spn_spindlespeed;

	public NumericUpDown spn_diacut1speed;

	public Label label2;

	public NumericUpDown spn_diacut2speed;

	public Label label3;

	public NumericUpDown spn_engravespeed;

	public Label label4;

	public NumericUpDown spn_lathespeed;

	public Label label5;

	public Button btn_spindlewarmup;

	public Button btn_aircleanstop;

	public Button btn_aircleanstart;

	public Button btn_oilstop;

	public Button btn_oilstart;

	public Button btn_spindlepark;

	public Button btn_dia1park;

	public Button btn_engravepark;

	public Button btn_dia2park;

	public Button btn_lathepark;

	public Button btn_laserpark;

	public Button btn_x;

	public Button btn_y;

	public Button btn_z;

	public Button btn_c;

	public Button btn_b;

	public Button btn_a;

	public Button btn_w;

	public Button btn_v;

	public Button btn_u;

	public Button btn_homing;

	public Button btn_j;

	public Button btn_i;

	public Button btn_pistondown;

	public Button btn_pistonup;

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

	public event OkCommandEventHandler OkPressed
	{
		[CompilerGenerated]
		add
		{
			OkCommandEventHandler okCommandEventHandler = okCommandEventHandler_0;
			OkCommandEventHandler okCommandEventHandler2;
			do
			{
				okCommandEventHandler2 = okCommandEventHandler;
				OkCommandEventHandler value2 = (OkCommandEventHandler)Delegate.Combine(okCommandEventHandler2, value);
				okCommandEventHandler = Interlocked.CompareExchange(ref okCommandEventHandler_0, value2, okCommandEventHandler2);
			}
			while ((object)okCommandEventHandler != okCommandEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandEventHandler okCommandEventHandler = okCommandEventHandler_0;
			OkCommandEventHandler okCommandEventHandler2;
			do
			{
				okCommandEventHandler2 = okCommandEventHandler;
				OkCommandEventHandler value2 = (OkCommandEventHandler)Delegate.Remove(okCommandEventHandler2, value);
				okCommandEventHandler = Interlocked.CompareExchange(ref okCommandEventHandler_0, value2, okCommandEventHandler2);
			}
			while ((object)okCommandEventHandler != okCommandEventHandler2);
		}
	}

	public event CancelCommandEventHandler CancelPressed
	{
		[CompilerGenerated]
		add
		{
			CancelCommandEventHandler cancelCommandEventHandler = cancelCommandEventHandler_0;
			CancelCommandEventHandler cancelCommandEventHandler2;
			do
			{
				cancelCommandEventHandler2 = cancelCommandEventHandler;
				CancelCommandEventHandler value2 = (CancelCommandEventHandler)Delegate.Combine(cancelCommandEventHandler2, value);
				cancelCommandEventHandler = Interlocked.CompareExchange(ref cancelCommandEventHandler_0, value2, cancelCommandEventHandler2);
			}
			while ((object)cancelCommandEventHandler != cancelCommandEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CancelCommandEventHandler cancelCommandEventHandler = cancelCommandEventHandler_0;
			CancelCommandEventHandler cancelCommandEventHandler2;
			do
			{
				cancelCommandEventHandler2 = cancelCommandEventHandler;
				CancelCommandEventHandler value2 = (CancelCommandEventHandler)Delegate.Remove(cancelCommandEventHandler2, value);
				cancelCommandEventHandler = Interlocked.CompareExchange(ref cancelCommandEventHandler_0, value2, cancelCommandEventHandler2);
			}
			while ((object)cancelCommandEventHandler != cancelCommandEventHandler2);
		}
	}

	public F_JewelPanel()
	{
		Class76.smethod_560(this);
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
		btn_x.BackColor = colorUnSelected;
		btn_y.BackColor = colorUnSelected;
		btn_z.BackColor = colorUnSelected;
		btn_a.BackColor = colorUnSelected;
		btn_b.BackColor = colorUnSelected;
		btn_c.BackColor = colorUnSelected;
		btn_u.BackColor = colorUnSelected;
		btn_v.BackColor = colorUnSelected;
		btn_w.BackColor = colorUnSelected;
		if (SelectedAxis == 0)
		{
			btn_x.BackColor = colorSelected;
		}
		if (SelectedAxis == 1)
		{
			btn_y.BackColor = colorSelected;
		}
		if (SelectedAxis == 2)
		{
			btn_z.BackColor = colorSelected;
		}
		if (SelectedAxis == 3)
		{
			btn_a.BackColor = colorSelected;
		}
		if (SelectedAxis == 4)
		{
			btn_b.BackColor = colorSelected;
		}
		if (SelectedAxis == 5)
		{
			btn_c.BackColor = colorSelected;
		}
		if (SelectedAxis == 6)
		{
			btn_u.BackColor = colorSelected;
		}
		if (SelectedAxis == 7)
		{
			btn_v.BackColor = colorSelected;
		}
		if (SelectedAxis == 8)
		{
			btn_w.BackColor = colorSelected;
		}
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (Properties.Result != DialogResult.OK)
		{
			e.Cancel = true;
			if (cancelCommandEventHandler_0 != null)
			{
				cancelCommandEventHandler_0();
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

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		btn_x.BackColor = colorUnSelected;
		btn_y.BackColor = colorUnSelected;
		btn_z.BackColor = colorUnSelected;
		btn_a.BackColor = colorUnSelected;
		btn_b.BackColor = colorUnSelected;
		btn_c.BackColor = colorUnSelected;
		btn_u.BackColor = colorUnSelected;
		btn_v.BackColor = colorUnSelected;
		btn_w.BackColor = colorUnSelected;
		btn_i.BackColor = colorUnSelected;
		btn_j.BackColor = colorUnSelected;
		if (control.Name == btn_x.Name)
		{
			if (jogAxisChangedEventHandler_0 != null)
			{
				jogAxisChangedEventHandler_0(btn_x, 0);
			}
			btn_x.BackColor = colorSelected;
		}
		if (control.Name == btn_y.Name)
		{
			if (jogAxisChangedEventHandler_0 != null)
			{
				jogAxisChangedEventHandler_0(sender, 1);
			}
			btn_y.BackColor = colorSelected;
		}
		if (control.Name == btn_z.Name)
		{
			if (jogAxisChangedEventHandler_0 != null)
			{
				jogAxisChangedEventHandler_0(sender, 2);
			}
			btn_z.BackColor = colorSelected;
		}
		if (control.Name == btn_a.Name)
		{
			if (jogAxisChangedEventHandler_0 != null)
			{
				jogAxisChangedEventHandler_0(sender, 3);
			}
			btn_a.BackColor = colorSelected;
		}
		if (control.Name == btn_b.Name)
		{
			if (jogAxisChangedEventHandler_0 != null)
			{
				jogAxisChangedEventHandler_0(sender, 4);
			}
			btn_b.BackColor = colorSelected;
		}
		if (control.Name == btn_c.Name)
		{
			if (jogAxisChangedEventHandler_0 != null)
			{
				jogAxisChangedEventHandler_0(sender, 5);
			}
			btn_c.BackColor = colorSelected;
		}
		if (control.Name == btn_u.Name)
		{
			if (jogAxisChangedEventHandler_0 != null)
			{
				jogAxisChangedEventHandler_0(sender, 6);
			}
			btn_u.BackColor = colorSelected;
		}
		if (control.Name == btn_v.Name)
		{
			if (jogAxisChangedEventHandler_0 != null)
			{
				jogAxisChangedEventHandler_0(sender, 7);
			}
			btn_v.BackColor = colorSelected;
		}
		if (control.Name == btn_w.Name)
		{
			if (jogAxisChangedEventHandler_0 != null)
			{
				jogAxisChangedEventHandler_0(sender, 8);
			}
			btn_w.BackColor = colorSelected;
		}
		if (control.Name == btn_i.Name)
		{
			if (jogAxisChangedEventHandler_0 != null)
			{
				jogAxisChangedEventHandler_0(sender, 9);
			}
			btn_i.BackColor = colorSelected;
		}
		if (control.Name == btn_j.Name)
		{
			if (jogAxisChangedEventHandler_0 != null)
			{
				jogAxisChangedEventHandler_0(sender, 10);
			}
			btn_j.BackColor = colorSelected;
		}
		if (control.Name == btn_stop.Name && jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg = new JogCommandEventArg();
			jogCommandEventArg.SelectedAxis = SelectedAxis;
			jogCommandEventArg.Command = JogCommandType.Stop;
			jogCommandEventHandler_0(sender, jogCommandEventArg);
		}
	}

	internal void method_2(object sender, MouseEventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_0.Name && jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg = new JogCommandEventArg();
			jogCommandEventArg.SelectedAxis = SelectedAxis;
			jogCommandEventArg.Command = JogCommandType.VelocityPlus;
			jogCommandEventHandler_0(sender, jogCommandEventArg);
		}
		if (control.Name == button_1.Name && jogCommandEventHandler_0 != null)
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
		if (control.Name == button_0.Name && jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg = new JogCommandEventArg();
			jogCommandEventArg.Command = JogCommandType.StopAll;
			jogCommandEventHandler_0(sender, jogCommandEventArg);
		}
		if (control.Name == button_1.Name && jogCommandEventHandler_0 != null)
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
