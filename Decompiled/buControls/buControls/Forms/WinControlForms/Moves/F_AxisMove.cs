using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Moves;

public class F_AxisMove : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	[CompilerGenerated]
	private JogCommandEventHandler jogCommandEventHandler_0;

	public int SelectedAxis = 0;

	private IContainer icontainer_0 = null;

	internal Button button_0;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	internal Button button_4;

	internal Button button_5;

	internal Button button_6;

	internal Button button_7;

	internal Label label_0;

	internal Label label_1;

	internal Label label_2;

	internal Label label_3;

	internal Label label_4;

	internal Panel panel_0;

	internal Label label_5;

	internal Panel panel_1;

	internal Label label_6;

	internal Button button_8;

	internal Button button_9;

	internal PictureBox pictureBox_0;

	public Label lbl_axisvalue;

	public Label lbl_selaxistext;

	public NumericUpDown spn_pos1;

	public NumericUpDown spn_pos2;

	public NumericUpDown spn_inc;

	public NumericUpDown spn_velmove;

	public NumericUpDown spn_veljog;

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

	public F_AxisMove()
	{
		Class76.smethod_652(this);
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
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
	}

	internal void method_1(object sender, MouseEventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_2.Name && jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg = new JogCommandEventArg();
			jogCommandEventArg.SelectedAxis = SelectedAxis;
			jogCommandEventArg.Position1 = (double)spn_pos1.Value;
			jogCommandEventArg.Position2 = (double)spn_pos2.Value;
			jogCommandEventArg.IncrementalPosition = (double)spn_inc.Value;
			jogCommandEventArg.VelocityMove = (double)spn_velmove.Value;
			jogCommandEventArg.VelocityJog = (double)spn_veljog.Value;
			jogCommandEventArg.Command = JogCommandType.VelocityPlus;
			jogCommandEventHandler_0(sender, jogCommandEventArg);
		}
		if (control.Name == button_3.Name && jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg2 = new JogCommandEventArg();
			jogCommandEventArg2.SelectedAxis = SelectedAxis;
			jogCommandEventArg2.Position1 = (double)spn_pos1.Value;
			jogCommandEventArg2.Position2 = (double)spn_pos2.Value;
			jogCommandEventArg2.IncrementalPosition = (double)spn_inc.Value;
			jogCommandEventArg2.VelocityMove = (double)spn_velmove.Value;
			jogCommandEventArg2.VelocityJog = (double)spn_veljog.Value;
			jogCommandEventArg2.Command = JogCommandType.VelocityMinus;
			jogCommandEventHandler_0(sender, jogCommandEventArg2);
		}
	}

	internal void method_2(object sender, MouseEventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_2.Name && jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg = new JogCommandEventArg();
			jogCommandEventArg.Position1 = (double)spn_pos1.Value;
			jogCommandEventArg.Position2 = (double)spn_pos2.Value;
			jogCommandEventArg.IncrementalPosition = (double)spn_inc.Value;
			jogCommandEventArg.VelocityMove = (double)spn_velmove.Value;
			jogCommandEventArg.VelocityJog = (double)spn_veljog.Value;
			jogCommandEventArg.Command = JogCommandType.StopAll;
			jogCommandEventHandler_0(sender, jogCommandEventArg);
		}
		if (control.Name == button_3.Name && jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg2 = new JogCommandEventArg();
			jogCommandEventArg2.Position1 = (double)spn_pos1.Value;
			jogCommandEventArg2.Position2 = (double)spn_pos2.Value;
			jogCommandEventArg2.IncrementalPosition = (double)spn_inc.Value;
			jogCommandEventArg2.VelocityMove = (double)spn_velmove.Value;
			jogCommandEventArg2.VelocityJog = (double)spn_veljog.Value;
			jogCommandEventArg2.Command = JogCommandType.StopAll;
			jogCommandEventHandler_0(sender, jogCommandEventArg2);
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		new Control();
	}

	internal void method_4(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_0.Name && jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg = new JogCommandEventArg();
			jogCommandEventArg.SelectedAxis = SelectedAxis;
			jogCommandEventArg.Command = JogCommandType.Position1;
			jogCommandEventArg.Position1 = (double)spn_pos1.Value;
			jogCommandEventArg.Position2 = (double)spn_pos2.Value;
			jogCommandEventArg.IncrementalPosition = (double)spn_inc.Value;
			jogCommandEventArg.VelocityMove = (double)spn_velmove.Value;
			jogCommandEventArg.VelocityJog = (double)spn_veljog.Value;
			jogCommandEventHandler_0(sender, jogCommandEventArg);
		}
		if (control.Name == button_1.Name && jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg2 = new JogCommandEventArg();
			jogCommandEventArg2.SelectedAxis = SelectedAxis;
			jogCommandEventArg2.Command = JogCommandType.Position2;
			jogCommandEventArg2.Position1 = (double)spn_pos1.Value;
			jogCommandEventArg2.Position2 = (double)spn_pos2.Value;
			jogCommandEventArg2.IncrementalPosition = (double)spn_inc.Value;
			jogCommandEventArg2.VelocityMove = (double)spn_velmove.Value;
			jogCommandEventArg2.VelocityJog = (double)spn_veljog.Value;
			jogCommandEventHandler_0(sender, jogCommandEventArg2);
		}
		if (control.Name == button_4.Name && jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg3 = new JogCommandEventArg();
			jogCommandEventArg3.SelectedAxis = SelectedAxis;
			jogCommandEventArg3.Command = JogCommandType.Incremental;
			jogCommandEventArg3.Position1 = (double)spn_pos1.Value;
			jogCommandEventArg3.Position2 = (double)spn_pos2.Value;
			jogCommandEventArg3.IncrementalPosition = (double)spn_inc.Value;
			jogCommandEventArg3.VelocityMove = (double)spn_velmove.Value;
			jogCommandEventArg3.VelocityJog = (double)spn_veljog.Value;
			jogCommandEventHandler_0(sender, jogCommandEventArg3);
		}
		if (control.Name == button_5.Name && jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg4 = new JogCommandEventArg();
			jogCommandEventArg4.SelectedAxis = SelectedAxis;
			jogCommandEventArg4.Command = JogCommandType.Home;
			jogCommandEventHandler_0(sender, jogCommandEventArg4);
		}
		if (control.Name == button_7.Name && jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg5 = new JogCommandEventArg();
			jogCommandEventArg5.SelectedAxis = SelectedAxis;
			jogCommandEventArg5.Command = JogCommandType.Stop;
			jogCommandEventArg5.Position1 = (double)spn_pos1.Value;
			jogCommandEventArg5.Position2 = (double)spn_pos2.Value;
			jogCommandEventArg5.IncrementalPosition = (double)spn_inc.Value;
			jogCommandEventArg5.VelocityMove = (double)spn_velmove.Value;
			jogCommandEventArg5.VelocityJog = (double)spn_veljog.Value;
			jogCommandEventHandler_0(sender, jogCommandEventArg5);
		}
		if (control.Name == button_6.Name && jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg6 = new JogCommandEventArg();
			jogCommandEventArg6.SelectedAxis = SelectedAxis;
			jogCommandEventArg6.Command = JogCommandType.AutoTest;
			jogCommandEventArg6.Position1 = (double)spn_pos1.Value;
			jogCommandEventArg6.Position2 = (double)spn_pos2.Value;
			jogCommandEventArg6.IncrementalPosition = (double)spn_inc.Value;
			jogCommandEventArg6.VelocityMove = (double)spn_velmove.Value;
			jogCommandEventArg6.VelocityJog = (double)spn_veljog.Value;
			jogCommandEventHandler_0(sender, jogCommandEventArg6);
		}
		if (control.Name == button_9.Name)
		{
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
		if (control.Name == button_8.Name && jogCommandEventHandler_0 != null)
		{
			JogCommandEventArg jogCommandEventArg7 = new JogCommandEventArg();
			jogCommandEventArg7.SelectedAxis = SelectedAxis;
			jogCommandEventArg7.Command = JogCommandType.Settings;
			jogCommandEventHandler_0(sender, jogCommandEventArg7);
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
