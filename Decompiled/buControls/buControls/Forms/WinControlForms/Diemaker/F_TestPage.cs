using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns27;

namespace buControls.Forms.WinControlForms.Diemaker;

public class F_TestPage : Form
{
	public static List<string> Captions = new List<string>();

	public int DigitalInputCount = 32;

	public int DigitalInputColumbs = 4;

	public int DigitalOutputCount = 32;

	public int DigitalOutputColumbs = 4;

	public int AxisCount = 4;

	public int SelectedTab = 0;

	public bool InvisibleIO = false;

	public List<string> AxisCaptions = new List<string>();

	public List<string> InputCaptions = new List<string>();

	public List<string> OutputCaptions = new List<string>();

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	[CompilerGenerated]
	private JogAxisChangedEventHandler jogAxisChangedEventHandler_0;

	[CompilerGenerated]
	private SetOutputEventHandler setOutputEventHandler_0;

	[CompilerGenerated]
	private JogCommandEventHandler jogCommandEventHandler_0;

	private IContainer icontainer_0 = null;

	internal TabControl tabControl_0;

	internal TabPage tabPage_0;

	internal Label label_0;

	internal Label label_1;

	internal Label label_2;

	internal Label label_3;

	internal Label label_4;

	internal Label label_5;

	internal Label label_6;

	internal Label label_7;

	internal Label label_8;

	internal Label label_9;

	internal Label label_10;

	internal Label label_11;

	internal Label label_12;

	internal Label label_13;

	internal Label label_14;

	internal Label label_15;

	internal Label label_16;

	internal Label label_17;

	internal Label label_18;

	internal Label label_19;

	internal Label label_20;

	internal Label label_21;

	internal Label label_22;

	internal Label label_23;

	internal Label label_24;

	internal Label label_25;

	internal Label label_26;

	internal Label label_27;

	internal Label label_28;

	internal Label label_29;

	internal Label label_30;

	internal Label label_31;

	internal TabPage tabPage_1;

	internal TabPage tabPage_2;

	internal Label label_32;

	internal Label label_33;

	internal Label label_34;

	internal Label label_35;

	internal Label label_36;

	internal Label label_37;

	internal Label label_38;

	internal Label label_39;

	internal Label label_40;

	internal Label label_41;

	internal Label label_42;

	internal Label label_43;

	internal Label label_44;

	internal Label label_45;

	internal Label label_46;

	internal Label label_47;

	internal Label label_48;

	internal Label label_49;

	internal Label label_50;

	internal Label label_51;

	internal Label label_52;

	internal Label label_53;

	internal Label label_54;

	internal Label label_55;

	internal Label label_56;

	internal Label label_57;

	internal Label label_58;

	internal Label label_59;

	internal Label label_60;

	internal Label label_61;

	internal Label label_62;

	internal Label label_63;

	internal Label label_64;

	internal Label label_65;

	internal Label label_66;

	internal Label label_67;

	internal Label label_68;

	internal Label label_69;

	internal Label label_70;

	internal Label label_71;

	internal Label label_72;

	internal Label label_73;

	internal Label label_74;

	internal Label label_75;

	internal Label label_76;

	internal Label label_77;

	internal Label label_78;

	internal Label label_79;

	internal Label label_80;

	internal Label label_81;

	internal Label label_82;

	internal Label label_83;

	internal Label label_84;

	internal Label label_85;

	internal Label label_86;

	internal Label label_87;

	internal Label label_88;

	internal Label label_89;

	internal Label label_90;

	internal Label label_91;

	internal Label label_92;

	internal Label label_93;

	internal Label label_94;

	internal Label label_95;

	internal Label label_96;

	internal Label label_97;

	internal Label label_98;

	internal Label label_99;

	internal Label label_100;

	internal Label label_101;

	internal Label label_102;

	internal Label label_103;

	internal Label label_104;

	internal Label label_105;

	internal Label label_106;

	internal Label label_107;

	internal Label label_108;

	internal Label label_109;

	internal Label label_110;

	internal Label label_111;

	internal Label label_112;

	internal Label label_113;

	internal Label label_114;

	internal Label label_115;

	internal Label label_116;

	internal Label label_117;

	internal Label label_118;

	internal Label label_119;

	internal Label label_120;

	internal Label label_121;

	internal Label label_122;

	internal Label label_123;

	internal Label label_124;

	internal Label label_125;

	internal Label label_126;

	internal Label label_127;

	internal Label label_128;

	internal Label label_129;

	internal Label label_130;

	internal PictureBox pictureBox_0;

	public ListBox lst_axis;

	public Label lbl_pos;

	public Button btn_bwd;

	public Button btn_fwd;

	public Button btn_increment;

	public Button btn_stop;

	public Button btn_home;

	public NumericUpDown spn_pos1;

	public Button btn_pos1;

	public Button btn_pos2;

	public NumericUpDown spn_relative;

	public NumericUpDown spn_pos2;

	public Button btn_write;

	public event EventHandler PageClosing
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event JogAxisChangedEventHandler AxisChanged
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

	public event SetOutputEventHandler SetOutput
	{
		[CompilerGenerated]
		add
		{
			SetOutputEventHandler setOutputEventHandler = setOutputEventHandler_0;
			SetOutputEventHandler setOutputEventHandler2;
			do
			{
				setOutputEventHandler2 = setOutputEventHandler;
				SetOutputEventHandler value2 = (SetOutputEventHandler)Delegate.Combine(setOutputEventHandler2, value);
				setOutputEventHandler = Interlocked.CompareExchange(ref setOutputEventHandler_0, value2, setOutputEventHandler2);
			}
			while ((object)setOutputEventHandler != setOutputEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			SetOutputEventHandler setOutputEventHandler = setOutputEventHandler_0;
			SetOutputEventHandler setOutputEventHandler2;
			do
			{
				setOutputEventHandler2 = setOutputEventHandler;
				SetOutputEventHandler value2 = (SetOutputEventHandler)Delegate.Remove(setOutputEventHandler2, value);
				setOutputEventHandler = Interlocked.CompareExchange(ref setOutputEventHandler_0, value2, setOutputEventHandler2);
			}
			while ((object)setOutputEventHandler != setOutputEventHandler2);
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

	public F_TestPage()
	{
		Class76.smethod_376(this);
	}

	public void Init()
	{
		Class76.smethod_487(this);
		try
		{
			if (InvisibleIO && tabControl_0.TabPages.Count > 1)
			{
				for (int i = 0; i <= tabControl_0.TabPages.Count - 1; i++)
				{
					if (tabControl_0.TabPages.Count > 1)
					{
						tabControl_0.TabPages.RemoveAt(0);
					}
				}
			}
			lst_axis.Items.Clear();
			for (int j = 0; j <= AxisCount - 1; j++)
			{
				if (j > AxisCaptions.Count - 1)
				{
					lst_axis.Items.Add("Axis " + (j + 1));
				}
				else
				{
					lst_axis.Items.Add(AxisCaptions[j]);
				}
			}
			for (int k = 0; k <= 48; k++)
			{
				for (int l = 0; l <= tabPage_0.Controls.Count - 1; l++)
				{
					Control control = new Control();
					control = tabPage_0.Controls[l];
					if (control.Name == "chk_i" + k && ((InputCaptions.Count > 0) & (k <= InputCaptions.Count - 1)))
					{
						((buCheckBox)tabPage_0.Controls[l]).Text = InputCaptions[k];
					}
				}
			}
			for (int m = 0; m <= 48; m++)
			{
				for (int n = 0; n <= tabPage_1.Controls.Count - 1; n++)
				{
					Control control2 = new Control();
					control2 = tabPage_1.Controls[n];
					if (control2.Name == "chk_o" + m && ((OutputCaptions.Count > 0) & (m <= OutputCaptions.Count - 1)))
					{
						((buCheckBox)tabPage_1.Controls[n]).Text = OutputCaptions[m];
					}
				}
			}
			if ((AppProcess.SelectedAxis >= 0) & (AppProcess.SelectedAxis <= lst_axis.Items.Count - 1))
			{
				lst_axis.SelectedIndex = AppProcess.SelectedAxis;
			}
			if (!((tabControl_0.SelectedIndex == 0) | (tabControl_0.SelectedIndex == 1)))
			{
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		e.Cancel = true;
		base.Visible = false;
		if (eventHandler_0 != null)
		{
			eventHandler_0(e, new EventArgs());
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		try
		{
			if (jogCommandEventHandler_0 != null)
			{
				JogCommandEventArg jogCommandEventArg = new JogCommandEventArg();
				jogCommandEventArg.Command = JogCommandType.AxisSelected;
				jogCommandEventArg.SelectedAxis = lst_axis.SelectedIndex;
				jogCommandEventHandler_0(sender, jogCommandEventArg);
			}
			if (jogAxisChangedEventHandler_0 != null && lst_axis.SelectedIndex >= 0)
			{
				jogAxisChangedEventHandler_0(this, lst_axis.SelectedIndex);
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void GetInput(int Index, bool State)
	{
		try
		{
			for (int i = 1; i <= tabPage_0.Controls.Count - 1; i++)
			{
				if (tabPage_0.Controls[i].Tag != null)
				{
					int num = int.Parse(tabPage_0.Controls[i].Tag.ToString());
					if (num == Index)
					{
						((buCheckBox)tabPage_0.Controls[i]).Check = State;
					}
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "Index: " + Index + " - State: " + State;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void GetOutput(int Index, bool State)
	{
		try
		{
			for (int i = 1; i <= tabPage_1.Controls.Count - 1; i++)
			{
				if (tabPage_1.Controls[i].Tag != null)
				{
					int num = int.Parse(tabPage_1.Controls[i].Tag.ToString());
					if (num == Index)
					{
						((buCheckBox)tabPage_1.Controls[i]).Check = State;
					}
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "Index: " + Index + " - State: " + State;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void SetAxisInput(bool Homing, bool PosLim, bool NegLim, bool Capture)
	{
	}

	internal void method_2(object sender, EventArgs e)
	{
		if (jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg = new JogCommandEventArg();
			jogCommandEventArg.Command = JogCommandType.Absolute;
			jogCommandEventArg.Position = (double)spn_pos1.Value;
			jogCommandEventArg.SelectedAxis = lst_axis.SelectedIndex;
			jogCommandEventHandler_0(sender, jogCommandEventArg);
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		if (jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg = new JogCommandEventArg();
			jogCommandEventArg.Command = JogCommandType.Absolute;
			jogCommandEventArg.Position = (double)spn_pos2.Value;
			jogCommandEventArg.SelectedAxis = lst_axis.SelectedIndex;
			jogCommandEventHandler_0(sender, jogCommandEventArg);
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		if (jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg = new JogCommandEventArg();
			jogCommandEventArg.Command = JogCommandType.Incremental;
			jogCommandEventArg.Position = (double)spn_relative.Value;
			jogCommandEventArg.SelectedAxis = lst_axis.SelectedIndex;
			jogCommandEventHandler_0(sender, jogCommandEventArg);
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		if (jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg = new JogCommandEventArg();
			jogCommandEventArg.Command = JogCommandType.Home;
			jogCommandEventArg.SelectedAxis = lst_axis.SelectedIndex;
			jogCommandEventHandler_0(sender, jogCommandEventArg);
		}
	}

	internal void method_6(object sender, EventArgs e)
	{
		if (jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg = new JogCommandEventArg();
			jogCommandEventArg.Command = JogCommandType.Stop;
			jogCommandEventArg.SelectedAxis = lst_axis.SelectedIndex;
			jogCommandEventHandler_0(sender, jogCommandEventArg);
		}
	}

	internal void method_7(object sender, MouseEventArgs e)
	{
		if (jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg = new JogCommandEventArg();
			jogCommandEventArg.Command = JogCommandType.VelocityPlus;
			jogCommandEventArg.SelectedAxis = lst_axis.SelectedIndex;
			jogCommandEventHandler_0(sender, jogCommandEventArg);
		}
	}

	internal void method_8(object sender, MouseEventArgs e)
	{
		if (jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg = new JogCommandEventArg();
			jogCommandEventArg.Command = JogCommandType.VelocityMinus;
			jogCommandEventArg.SelectedAxis = lst_axis.SelectedIndex;
			jogCommandEventHandler_0(sender, jogCommandEventArg);
		}
	}

	internal void method_9(object sender, MouseEventArgs e)
	{
		if (jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg = new JogCommandEventArg();
			jogCommandEventArg.Command = JogCommandType.Stop;
			jogCommandEventArg.SelectedAxis = lst_axis.SelectedIndex;
			jogCommandEventHandler_0(sender, jogCommandEventArg);
		}
	}

	internal void method_10(object sender, MouseEventArgs e)
	{
		if (jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg = new JogCommandEventArg();
			jogCommandEventArg.Command = JogCommandType.Stop;
			jogCommandEventArg.SelectedAxis = lst_axis.SelectedIndex;
			jogCommandEventHandler_0(sender, jogCommandEventArg);
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
