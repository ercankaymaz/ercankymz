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

namespace buControls.Forms.buControlForms.Jog;

public class F_JogBasic : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public List<CodesysAxesData> Axes = new List<CodesysAxesData>();

	public bool ShowSettingsMenu = true;

	public List<string> AxisChars = new List<string>();

	public List<string> Captions = new List<string>();

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	[CompilerGenerated]
	private JogSelectedSettingsModeEventHandler jogSelectedSettingsModeEventHandler_0;

	[CompilerGenerated]
	private JogCommandEventHandler jogCommandEventHandler_0;

	private IContainer icontainer_0 = null;

	internal buLabel buLabel_0;

	public buButton btn_stop;

	public buButton btn_absgo;

	public buTab tab_jog;

	public TabPage tabpage_speed;

	internal buLabel buLabel_1;

	public buButton btn_speedminus;

	public buButton btn_speedplus;

	public TabPage tabpage_incremental;

	internal buLabel buLabel_2;

	public buButton btn_incminus;

	public buButton btn_incplus;

	public TabPage tabpage_absolute;

	public buSpin spn_abspos;

	internal buGroup buGroup_0;

	internal buGround buGround_0;

	internal buButton buButton_0;

	internal buComboBox buComboBox_0;

	internal ImageList imageList_0;

	internal buButton buButton_1;

	internal buSeparator buSeparator_0;

	public buSpin spn_actspeed;

	public buSpin spn_actpos;

	public buButton btn_axisselectminus;

	public buButton btn_axisselectplus;

	public buSpin spn_incpos;

	internal buComboBox buComboBox_1;

	internal TabPage tabPage_0;

	public buSpin spn_autopos2;

	public buButton btn_auto;

	public buSpin spn_autopos1;

	internal buLabel buLabel_3;

	public buSpin spn_autowaittime;

	internal buLabel buLabel_4;

	internal buLabel buLabel_5;

	internal buLabel buLabel_6;

	internal buLabel buLabel_7;

	internal buLabel buLabel_8;

	internal buLabel buLabel_9;

	internal buLabel buLabel_10;

	public buButton btn_homing;

	public buLabel lbl_enableled;

	public buPanel pnl_error;

	public buLabel lbl_ledpositivelimit;

	public buLabel lbl_lednegativelimit;

	public buLabel lbl_ledcapture;

	public buLabel lbl_ledhoming;

	public buLabel lbl_homeled;

	internal buLabel buLabel_11;

	public event EventHandler PageClose
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

	public event JogSelectedSettingsModeEventHandler SettingsClick
	{
		[CompilerGenerated]
		add
		{
			JogSelectedSettingsModeEventHandler jogSelectedSettingsModeEventHandler = jogSelectedSettingsModeEventHandler_0;
			JogSelectedSettingsModeEventHandler jogSelectedSettingsModeEventHandler2;
			do
			{
				jogSelectedSettingsModeEventHandler2 = jogSelectedSettingsModeEventHandler;
				JogSelectedSettingsModeEventHandler value2 = (JogSelectedSettingsModeEventHandler)Delegate.Combine(jogSelectedSettingsModeEventHandler2, value);
				jogSelectedSettingsModeEventHandler = Interlocked.CompareExchange(ref jogSelectedSettingsModeEventHandler_0, value2, jogSelectedSettingsModeEventHandler2);
			}
			while ((object)jogSelectedSettingsModeEventHandler != jogSelectedSettingsModeEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			JogSelectedSettingsModeEventHandler jogSelectedSettingsModeEventHandler = jogSelectedSettingsModeEventHandler_0;
			JogSelectedSettingsModeEventHandler jogSelectedSettingsModeEventHandler2;
			do
			{
				jogSelectedSettingsModeEventHandler2 = jogSelectedSettingsModeEventHandler;
				JogSelectedSettingsModeEventHandler value2 = (JogSelectedSettingsModeEventHandler)Delegate.Remove(jogSelectedSettingsModeEventHandler2, value);
				jogSelectedSettingsModeEventHandler = Interlocked.CompareExchange(ref jogSelectedSettingsModeEventHandler_0, value2, jogSelectedSettingsModeEventHandler2);
			}
			while ((object)jogSelectedSettingsModeEventHandler != jogSelectedSettingsModeEventHandler2);
		}
	}

	public event JogCommandEventHandler Command
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

	public F_JogBasic()
	{
		Class76.smethod_619(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
	}

	internal void method_1(object sender, FormClosingEventArgs e)
	{
		try
		{
			e.Cancel = true;
			base.Visible = false;
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, new EventArgs());
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void Init()
	{
		try
		{
			PropertiesForm.Inited = false;
			if (PropertiesForm.Height > 10)
			{
				base.Height = PropertiesForm.Height;
			}
			if (PropertiesForm.Width > 10)
			{
				base.Width = PropertiesForm.Width;
			}
			base.TopMost = PropertiesForm.TopMost;
			base.StartPosition = PropertiesForm.FormPosition;
			buButton_0.Visible = ShowSettingsMenu;
			if (AppProcess.SelectedAxis < 0)
			{
				AppProcess.SelectedAxis = 0;
			}
			buComboBox_0.Items.Clear();
			for (int i = 0; i <= Axes.Count - 1; i++)
			{
				string item = i + 1 + "-" + Axes[i].AxisPar.Base.baseName;
				buComboBox_0.Items.Add(item);
			}
			if (AppProcess.SelectedAxis <= Axes.Count - 1)
			{
				buComboBox_0.SelectedIndex = AppProcess.SelectedAxis;
			}
			buComboBox_1.Items.Clear();
			buComboBox_1.Items.Add(10);
			buComboBox_1.Items.Add(1);
			buComboBox_1.Items.Add(0.1);
			buComboBox_1.Items.Add(0.01);
			buComboBox_1.Items.Add(0.001);
			buComboBox_1.SelectedIndex = 1;
			LoadLanguage();
			PropertiesForm.Inited = true;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void LoadLanguage()
	{
		try
		{
			if (Captions.Count >= 12)
			{
				Text = Captions[0];
				buGroup_0.Text = Captions[1];
				tabpage_speed.Text = Captions[2];
				tabpage_incremental.Text = Captions[3];
				tabpage_absolute.Text = Captions[4];
				buLabel_1.Text = Captions[5];
				buLabel_2.Text = Captions[6];
				buLabel_0.Text = Captions[7];
				btn_speedplus.Text = Captions[8];
				btn_speedminus.Text = Captions[9];
				btn_incplus.Text = Captions[8];
				btn_incminus.Text = Captions[9];
				btn_stop.Text = Captions[10];
				btn_absgo.Text = Captions[11];
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		try
		{
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		try
		{
			new Control();
			if (AppBool.TouchPad & PropertiesForm.Inited)
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

	internal void method_4(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if ((AppBool.TouchPad & PropertiesForm.Inited) && control.Name == spn_abspos.Name)
		{
			buControlCommands.ShowKeyPad(this, spn_abspos);
			buGround_0.Focus();
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if (control.Name == buButton_1.Name)
			{
				base.Visible = false;
				if (eventHandler_0 != null)
				{
					eventHandler_0(sender, e);
				}
			}
			if (control.Name == buButton_0.Name && jogSelectedSettingsModeEventHandler_0 != null)
			{
				jogSelectedSettingsModeEventHandler_0(AxisSettingsType.All, AppProcess.SelectedAxis);
			}
			if (control.Name == btn_homing.Name && jogCommandEventHandler_0 != null)
			{
				JogCommandEventArg jogCommandEventArg = new JogCommandEventArg();
				jogCommandEventArg.Command = JogCommandType.Home;
				jogCommandEventArg.SelectedAxis = buComboBox_0.SelectedIndex;
				jogCommandEventHandler_0(sender, jogCommandEventArg);
			}
			if (control.Name == btn_stop.Name && jogCommandEventHandler_0 != null)
			{
				JogCommandEventArg jogCommandEventArg2 = new JogCommandEventArg();
				jogCommandEventArg2.Command = JogCommandType.Stop;
				jogCommandEventArg2.SelectedAxis = buComboBox_0.SelectedIndex;
				jogCommandEventHandler_0(sender, jogCommandEventArg2);
			}
			if (control.Name == btn_absgo.Name && jogCommandEventHandler_0 != null)
			{
				JogCommandEventArg jogCommandEventArg3 = new JogCommandEventArg();
				jogCommandEventArg3.Command = JogCommandType.Absolute;
				jogCommandEventArg3.Position = spn_abspos.Value;
				jogCommandEventArg3.SelectedAxis = buComboBox_0.SelectedIndex;
				jogCommandEventHandler_0(sender, jogCommandEventArg3);
			}
			if (control.Name == btn_incplus.Name && jogCommandEventHandler_0 != null)
			{
				JogCommandEventArg jogCommandEventArg4 = new JogCommandEventArg();
				jogCommandEventArg4.Command = JogCommandType.Incremental;
				jogCommandEventArg4.IncrementalPosition = spn_incpos.Value;
				jogCommandEventArg4.SelectedAxis = buComboBox_0.SelectedIndex;
				jogCommandEventArg4.Direction = 1.0;
				jogCommandEventHandler_0(sender, jogCommandEventArg4);
			}
			if (control.Name == btn_incminus.Name && jogCommandEventHandler_0 != null)
			{
				JogCommandEventArg jogCommandEventArg5 = new JogCommandEventArg();
				jogCommandEventArg5.Command = JogCommandType.Incremental;
				jogCommandEventArg5.IncrementalPosition = spn_incpos.Value;
				jogCommandEventArg5.SelectedAxis = buComboBox_0.SelectedIndex;
				jogCommandEventArg5.Direction = -1.0;
				jogCommandEventHandler_0(sender, jogCommandEventArg5);
			}
			if (control.Name == btn_auto.Name && jogCommandEventHandler_0 != null)
			{
				JogCommandEventArg jogCommandEventArg6 = new JogCommandEventArg();
				jogCommandEventArg6.Command = JogCommandType.AutoTest;
				jogCommandEventArg6.Position1 = spn_autopos1.Value;
				jogCommandEventArg6.Position2 = spn_autopos2.Value;
				jogCommandEventArg6.SelectedAxis = buComboBox_0.SelectedIndex;
				jogCommandEventArg6.Direction = 1.0;
				jogCommandEventHandler_0(sender, jogCommandEventArg6);
			}
			if (control.Name == btn_axisselectminus.Name && buComboBox_0.SelectedIndex > 0)
			{
				buComboBox_0.SelectedIndex--;
				AppProcess.SelectedAxis = buComboBox_0.SelectedIndex;
			}
			if (control.Name == btn_axisselectplus.Name && buComboBox_0.SelectedIndex < buComboBox_0.Items.Count - 1)
			{
				buComboBox_0.SelectedIndex++;
				AppProcess.SelectedAxis = buComboBox_0.SelectedIndex;
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_6(object sender, MouseEventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_speedminus.Name && jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg = new JogCommandEventArg();
			jogCommandEventArg.Command = JogCommandType.VelocityMinus;
			jogCommandEventArg.SelectedAxis = buComboBox_0.SelectedIndex;
			jogCommandEventHandler_0(sender, jogCommandEventArg);
		}
		if (control.Name == btn_speedplus.Name && jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg2 = new JogCommandEventArg();
			jogCommandEventArg2.Command = JogCommandType.VelocityPlus;
			jogCommandEventArg2.SelectedAxis = buComboBox_0.SelectedIndex;
			jogCommandEventHandler_0(sender, jogCommandEventArg2);
		}
	}

	internal void method_7(object sender, MouseEventArgs e)
	{
		if (jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg = new JogCommandEventArg();
			jogCommandEventArg.Command = JogCommandType.JogStop;
			jogCommandEventArg.SelectedAxis = buComboBox_0.SelectedIndex;
			jogCommandEventHandler_0(sender, jogCommandEventArg);
		}
	}

	internal void method_8(object sender, EventArgs e)
	{
		if (jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg = new JogCommandEventArg();
			jogCommandEventArg.Command = JogCommandType.JogStop;
			jogCommandEventArg.SelectedAxis = buComboBox_0.SelectedIndex;
			jogCommandEventHandler_0(sender, jogCommandEventArg);
		}
	}

	internal void method_9(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == buComboBox_0.Name && PropertiesForm.Inited && buComboBox_0.SelectedIndex >= 0 && Axes[buComboBox_0.SelectedIndex].AxisPar.Base.baseNo >= 0)
		{
			AppProcess.SelectedAxis = buComboBox_0.SelectedIndex;
			buComboBox_0.Invalidate();
		}
		if (control.Name == buComboBox_1.Name && PropertiesForm.Inited && buComboBox_1.SelectedIndex >= 0)
		{
			spn_incpos.Value = Convert.ToDouble(buComboBox_1.Text);
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
