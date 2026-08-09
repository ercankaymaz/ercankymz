using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Forms.WinControlForms.CAM.CamItems;
using ns27;

namespace buControls.Forms.WinControlForms.CAM;

public class F_CamAll : Form
{
	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public camParameters Parameters = new camParameters();

	public PostProcessor Post = new PostProcessor();

	public bool ShowHelps = true;

	public bool ShowNextButton = true;

	public bool ShowPreButton = true;

	public bool ReadOnly = false;

	public int FormHeight = 0;

	public int FormWidth = 0;

	public DialogResult Result = DialogResult.None;

	private bool bool_0 = false;

	internal NumericUpDown numericUpDown_0 = new NumericUpDown();

	internal NumericUpDown numericUpDown_1 = new NumericUpDown();

	internal NumericUpDown numericUpDown_2 = new NumericUpDown();

	internal NumericUpDown numericUpDown_3 = new NumericUpDown();

	internal NumericUpDown numericUpDown_4 = new NumericUpDown();

	internal NumericUpDown numericUpDown_5 = new NumericUpDown();

	internal NumericUpDown numericUpDown_6 = new NumericUpDown();

	internal NumericUpDown numericUpDown_7 = new NumericUpDown();

	internal NumericUpDown numericUpDown_8 = new NumericUpDown();

	internal NumericUpDown numericUpDown_9 = new NumericUpDown();

	internal CheckBox checkBox_0 = new CheckBox();

	internal NumericUpDown numericUpDown_10 = new NumericUpDown();

	internal NumericUpDown numericUpDown_11 = new NumericUpDown();

	internal NumericUpDown numericUpDown_12 = new NumericUpDown();

	internal NumericUpDown numericUpDown_13 = new NumericUpDown();

	internal NumericUpDown numericUpDown_14 = new NumericUpDown();

	internal NumericUpDown numericUpDown_15 = new NumericUpDown();

	internal CheckBox checkBox_1 = new CheckBox();

	internal CheckBox checkBox_2 = new CheckBox();

	internal RadioButton radioButton_0 = new RadioButton();

	internal RadioButton radioButton_1 = new RadioButton();

	internal RadioButton radioButton_2 = new RadioButton();

	internal RadioButton radioButton_3 = new RadioButton();

	internal NumericUpDown numericUpDown_16 = new NumericUpDown();

	internal RadioButton radioButton_4 = new RadioButton();

	internal RadioButton radioButton_5 = new RadioButton();

	internal RadioButton radioButton_6 = new RadioButton();

	internal RadioButton radioButton_7 = new RadioButton();

	internal RadioButton radioButton_8 = new RadioButton();

	internal IContainer icontainer_0 = null;

	internal TabPage tabPage_0;

	public Button btn_pre;

	internal ImageList imageList_0;

	internal TabPage tabPage_1;

	public Button btn_cancel;

	public Button btn_ok;

	internal TabPage tabPage_2;

	public Button btn_next;

	internal TabPage tabPage_3;

	internal TabPage tabPage_4;

	internal TabPage tabPage_5;

	internal TabControl tabControl_0;

	internal TabPage tabPage_6;

	internal TabPage tabPage_7;

	internal TabPage tabPage_8;

	public F_CamAll()
	{
		Class76.smethod_95(this);
	}

	public void Init()
	{
		bool_0 = false;
		new ArrayList();
		if (FormHeight > 10)
		{
			base.Height = FormHeight;
		}
		if (FormWidth > 10)
		{
			base.Width = FormWidth;
		}
		btn_next.Visible = ShowNextButton;
		btn_pre.Visible = ShowPreButton;
		if (!Post.CamPageTab.ShowMisc && tabControl_0.TabPages.Count >= 9)
		{
			tabControl_0.TabPages.RemoveAt(8);
		}
		if (!Post.CamPageTab.ShowTools && tabControl_0.TabPages.Count >= 8)
		{
			tabControl_0.TabPages.RemoveAt(7);
		}
		if (!Post.CamPageTab.ShowLeadOut && tabControl_0.TabPages.Count >= 7)
		{
			tabControl_0.TabPages.RemoveAt(6);
		}
		if (!Post.CamPageTab.ShowLeadIn && tabControl_0.TabPages.Count >= 6)
		{
			tabControl_0.TabPages.RemoveAt(5);
		}
		if (!Post.CamPageTab.ShowOffset && tabControl_0.TabPages.Count >= 5)
		{
			tabControl_0.TabPages.RemoveAt(4);
		}
		if (!Post.CamPageTab.ShowStep && tabControl_0.TabPages.Count >= 4)
		{
			tabControl_0.TabPages.RemoveAt(3);
		}
		if (!Post.CamPageTab.ShowDistance && tabControl_0.TabPages.Count >= 3)
		{
			tabControl_0.TabPages.RemoveAt(2);
		}
		if (!Post.CamPageTab.ShowVelocity && tabControl_0.TabPages.Count >= 2)
		{
			tabControl_0.TabPages.RemoveAt(1);
		}
		if (!Post.CamPageTab.ShowOperation && tabControl_0.TabPages.Count >= 1)
		{
			tabControl_0.TabPages.RemoveAt(0);
		}
		F_CamOperationAll f_CamOperationAll = new F_CamOperationAll(ShowExplanation: false, 2);
		tabPage_2.Controls.Clear();
		int num = 0;
		for (int i = 0; i <= Post.CamPageOperation.Count - 1; i++)
		{
			for (int j = 0; j <= f_CamOperationAll.Controls.Count - 1; j++)
			{
				Control control = f_CamOperationAll.Controls[j];
				bool flag = false;
				if (!(control.GetType() == typeof(Panel)))
				{
					continue;
				}
				if (control.Tag != null && Post.CamPageOperation[i].ToString().ToLower() == control.Tag.ToString())
				{
					flag = true;
				}
				if (!flag)
				{
					continue;
				}
				for (int k = 0; k <= control.Controls.Count - 1; k++)
				{
					if (control.Controls[k].GetType() == typeof(NumericUpDown))
					{
						((NumericUpDown)control.Controls[k]).KeyDown += method_2;
						((NumericUpDown)control.Controls[k]).Click += method_3;
						((NumericUpDown)control.Controls[k]).ValueChanged += method_1;
						if (control.Tag.ToString() == "height")
						{
							numericUpDown_16 = (NumericUpDown)control.Controls[k];
							((NumericUpDown)control.Controls[k]).Value = (decimal)Parameters.Operations.Height;
						}
					}
					if (control.Controls[k].GetType() == typeof(RadioButton) && control.Tag.ToString() == "direction")
					{
						if (control.Controls[k].Tag.ToString() == "cw")
						{
							radioButton_4 = (RadioButton)control.Controls[k];
						}
						if (control.Controls[k].Tag.ToString() == "ccw")
						{
							radioButton_5 = (RadioButton)control.Controls[k];
						}
						if (Parameters.Operations.Direction == ClockDirectionType.CW)
						{
							radioButton_4.Checked = true;
							radioButton_5.Checked = false;
						}
						if (Parameters.Operations.Direction == ClockDirectionType.CCW)
						{
							radioButton_4.Checked = false;
							radioButton_5.Checked = true;
						}
					}
					if (control.Controls[k].GetType() == typeof(RadioButton) && control.Tag.ToString() == "opencontour")
					{
						if (control.Controls[k].Tag.ToString() == "left")
						{
							radioButton_6 = (RadioButton)control.Controls[k];
						}
						if (control.Controls[k].Tag.ToString() == "right")
						{
							radioButton_7 = (RadioButton)control.Controls[k];
						}
						if (control.Controls[k].Tag.ToString() == "center")
						{
							radioButton_8 = (RadioButton)control.Controls[k];
						}
						if (Parameters.Offsets.OpenContourOld == CamOpenContourType2.Left)
						{
							radioButton_6.Checked = true;
							radioButton_7.Checked = false;
							radioButton_8.Checked = false;
						}
						if (Parameters.Offsets.OpenContourOld == CamOpenContourType2.Right)
						{
							radioButton_6.Checked = false;
							radioButton_7.Checked = true;
							radioButton_8.Checked = false;
						}
						if (Parameters.Offsets.OpenContourOld == CamOpenContourType2.Center)
						{
							radioButton_6.Checked = false;
							radioButton_7.Checked = false;
							radioButton_8.Checked = true;
						}
					}
				}
				control.Top = 6 + num * 32;
				tabPage_2.Controls.Add(control);
				num++;
				j = 2147483637;
			}
		}
		F_CamVelocityAll f_CamVelocityAll = new F_CamVelocityAll(ShowExplanation: false, 2);
		tabPage_1.Controls.Clear();
		int num2 = 0;
		for (int l = 0; l <= Post.CamPageVelocity.Count - 1; l++)
		{
			for (int m = 0; m <= f_CamVelocityAll.Controls.Count - 1; m++)
			{
				Control control2 = f_CamVelocityAll.Controls[m];
				bool flag2 = false;
				if (!(control2.GetType() == typeof(Panel)))
				{
					continue;
				}
				if (control2.Tag != null && Post.CamPageVelocity[l].ToString().ToLower() == control2.Tag.ToString())
				{
					flag2 = true;
				}
				if (!flag2)
				{
					continue;
				}
				for (int n = 0; n <= control2.Controls.Count - 1; n++)
				{
					if (control2.Controls[n].GetType() == typeof(NumericUpDown))
					{
						((NumericUpDown)control2.Controls[n]).KeyDown += method_2;
						((NumericUpDown)control2.Controls[n]).Click += method_3;
						((NumericUpDown)control2.Controls[n]).ValueChanged += method_1;
						if (control2.Tag.ToString() == "feed")
						{
							numericUpDown_0 = (NumericUpDown)control2.Controls[n];
							((NumericUpDown)control2.Controls[n]).Value = (decimal)Parameters.Speeds.Feed;
						}
						if (control2.Tag.ToString() == "plunge")
						{
							numericUpDown_2 = (NumericUpDown)control2.Controls[n];
							((NumericUpDown)control2.Controls[n]).Value = (decimal)Parameters.Speeds.Plunge;
						}
						if (control2.Tag.ToString() == "leave")
						{
							numericUpDown_3 = (NumericUpDown)control2.Controls[n];
							((NumericUpDown)control2.Controls[n]).Value = (decimal)Parameters.Speeds.Leave;
						}
						if (control2.Tag.ToString() == "rapid")
						{
							numericUpDown_4 = (NumericUpDown)control2.Controls[n];
							((NumericUpDown)control2.Controls[n]).Value = (decimal)Parameters.Speeds.Rapid;
						}
						if (control2.Tag.ToString() == "finish")
						{
							numericUpDown_5 = (NumericUpDown)control2.Controls[n];
							((NumericUpDown)control2.Controls[n]).Value = (decimal)Parameters.Speeds.Finish;
						}
						if (control2.Tag.ToString() == "backfeed")
						{
							numericUpDown_1 = (NumericUpDown)control2.Controls[n];
							((NumericUpDown)control2.Controls[n]).Value = (decimal)Parameters.Speeds.BackwardFeed;
						}
					}
				}
				control2.Top = 6 + num2 * 32;
				tabPage_1.Controls.Add(control2);
				num2++;
				m--;
			}
		}
		F_CamDistanceAll f_CamDistanceAll = new F_CamDistanceAll(ShowExplanation: false, 2);
		tabPage_3.Controls.Clear();
		int num3 = 0;
		for (int num4 = 0; num4 <= Post.CamPageDistance.Count - 1; num4++)
		{
			for (int num5 = 0; num5 <= f_CamDistanceAll.Controls.Count - 1; num5++)
			{
				Control control3 = f_CamDistanceAll.Controls[num5];
				bool flag3 = false;
				if (!(control3.GetType() == typeof(Panel)))
				{
					continue;
				}
				if (control3.Tag != null && Post.CamPageDistance[num4].ToString().ToLower() == control3.Tag.ToString())
				{
					flag3 = true;
				}
				if (!flag3)
				{
					continue;
				}
				for (int num6 = 0; num6 <= control3.Controls.Count - 1; num6++)
				{
					if (control3.Controls[num6].GetType() == typeof(NumericUpDown))
					{
						((NumericUpDown)control3.Controls[num6]).KeyDown += method_2;
						((NumericUpDown)control3.Controls[num6]).Click += method_3;
						((NumericUpDown)control3.Controls[num6]).ValueChanged += method_1;
						if (control3.Tag.ToString() == "safe")
						{
							numericUpDown_6 = (NumericUpDown)control3.Controls[num6];
							((NumericUpDown)control3.Controls[num6]).Value = (decimal)Parameters.Distances.Safe;
						}
						if (control3.Tag.ToString() == "air")
						{
							numericUpDown_7 = (NumericUpDown)control3.Controls[num6];
							((NumericUpDown)control3.Controls[num6]).Value = (decimal)Parameters.Distances.Air;
						}
						if (control3.Tag.ToString() == "stepup")
						{
							numericUpDown_8 = (NumericUpDown)control3.Controls[num6];
							((NumericUpDown)control3.Controls[num6]).Value = (decimal)Parameters.Distances.StepUp;
						}
						if (control3.Tag.ToString() == "smallsafe")
						{
							numericUpDown_9 = (NumericUpDown)control3.Controls[num6];
							((NumericUpDown)control3.Controls[num6]).Value = (decimal)Parameters.Distances.SafeSmall;
						}
					}
					if (control3.Controls[num6].GetType() == typeof(CheckBox) && control3.Tag.ToString() == "safeincremental")
					{
						checkBox_0 = (CheckBox)control3.Controls[num6];
						((CheckBox)control3.Controls[num6]).Checked = Parameters.Distances.IncrementalSafe;
					}
				}
				control3.Top = 6 + num3 * 32;
				tabPage_3.Controls.Add(control3);
				num3++;
				num5--;
			}
		}
		F_CamStepAll f_CamStepAll = new F_CamStepAll(ShowExplanation: false, 2);
		tabPage_0.Controls.Clear();
		int num7 = 0;
		for (int num8 = 0; num8 <= Post.CamPageStep.Count - 1; num8++)
		{
			for (int num9 = 0; num9 <= f_CamStepAll.Controls.Count - 1; num9++)
			{
				Control control4 = f_CamStepAll.Controls[num9];
				bool flag4 = false;
				if (!(control4.GetType() == typeof(Panel)))
				{
					continue;
				}
				if (control4.Tag != null && Post.CamPageStep[num8].ToString().ToLower() == control4.Tag.ToString())
				{
					flag4 = true;
				}
				if (!flag4)
				{
					continue;
				}
				for (int num10 = 0; num10 <= control4.Controls.Count - 1; num10++)
				{
					if (control4.Controls[num10].GetType() == typeof(NumericUpDown))
					{
						((NumericUpDown)control4.Controls[num10]).KeyDown += method_2;
						((NumericUpDown)control4.Controls[num10]).Click += method_3;
						((NumericUpDown)control4.Controls[num10]).ValueChanged += method_1;
						if (control4.Tag.ToString() == "start")
						{
							numericUpDown_10 = (NumericUpDown)control4.Controls[num10];
							((NumericUpDown)control4.Controls[num10]).Value = (decimal)Parameters.Steps.StartValue;
						}
						if (control4.Tag.ToString() == "end")
						{
							numericUpDown_11 = (NumericUpDown)control4.Controls[num10];
							((NumericUpDown)control4.Controls[num10]).Value = (decimal)Parameters.Steps.EndValue;
						}
						if (control4.Tag.ToString() == "count")
						{
							numericUpDown_12 = (NumericUpDown)control4.Controls[num10];
							((NumericUpDown)control4.Controls[num10]).Value = Parameters.Steps.Count;
						}
						if (control4.Tag.ToString() == "step")
						{
							numericUpDown_12 = (NumericUpDown)control4.Controls[num10];
							((NumericUpDown)control4.Controls[num10]).Value = (decimal)Parameters.Steps.Step;
						}
						if (control4.Tag.ToString() == "distance")
						{
							numericUpDown_14 = (NumericUpDown)control4.Controls[num10];
							((NumericUpDown)control4.Controls[num10]).Value = (decimal)Parameters.Steps.Distance;
						}
						if (control4.Tag.ToString() == "moveup")
						{
							numericUpDown_15 = (NumericUpDown)control4.Controls[num10];
							((NumericUpDown)control4.Controls[num10]).Value = (decimal)Parameters.Steps.MoveUp;
						}
					}
					if (control4.Controls[num10].GetType() == typeof(CheckBox) && control4.Tag.ToString() == "moveup")
					{
						checkBox_2 = (CheckBox)control4.Controls[num10];
						((CheckBox)control4.Controls[num10]).Checked = Parameters.Steps.MoveUpEnable;
					}
					if (control4.Controls[num10].GetType() == typeof(CheckBox) && control4.Tag.ToString() == "enable")
					{
						checkBox_1 = (CheckBox)control4.Controls[num10];
						((CheckBox)control4.Controls[num10]).Checked = Parameters.Steps.Enable;
					}
					if (!(control4.Controls[num10].GetType() == typeof(RadioButton)))
					{
						continue;
					}
					if (control4.Tag.ToString() == "moveuptype")
					{
						if (control4.Controls[num10].Tag.ToString() == "abs")
						{
							radioButton_0 = (RadioButton)control4.Controls[num10];
						}
						if (control4.Controls[num10].Tag.ToString() == "rel")
						{
							radioButton_1 = (RadioButton)control4.Controls[num10];
						}
						if (Parameters.Steps.MoveUpType == CamMoveUpType.Absolute)
						{
							radioButton_0.Checked = true;
							radioButton_1.Checked = false;
						}
						if (Parameters.Steps.MoveUpType == CamMoveUpType.Incremental)
						{
							radioButton_0.Checked = false;
							radioButton_1.Checked = true;
						}
					}
					if (control4.Tag.ToString() == "sequence")
					{
						if (control4.Controls[num10].Tag.ToString() == "level")
						{
							radioButton_2 = (RadioButton)control4.Controls[num10];
						}
						if (control4.Controls[num10].Tag.ToString() == "region")
						{
							radioButton_3 = (RadioButton)control4.Controls[num10];
						}
						if (Parameters.Steps.Sequence == CamMachiningSequenceType.Level)
						{
							radioButton_2.Checked = true;
							radioButton_3.Checked = false;
						}
						if (Parameters.Steps.Sequence == CamMachiningSequenceType.Region)
						{
							radioButton_2.Checked = false;
							radioButton_3.Checked = true;
						}
					}
				}
				control4.Top = 6 + num7 * 32;
				tabPage_0.Controls.Add(control4);
				num7++;
				num9 = 2147483637;
			}
		}
		Refresh();
		Result = DialogResult.None;
		bool_0 = true;
	}

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_ok.Name)
		{
			if (!bool_0)
			{
				return;
			}
			if (ReadOnly)
			{
				Dispose();
				return;
			}
			Class76.smethod_589(this);
			Result = DialogResult.OK;
			Dispose();
		}
		if (control.Name == btn_cancel.Name)
		{
			Result = DialogResult.Cancel;
			if (FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == btn_pre.Name && tabControl_0.SelectedIndex > 0)
		{
			tabControl_0.SelectedIndex--;
		}
		if (control.Name == btn_next.Name && tabControl_0.SelectedIndex < tabControl_0.TabPages.Count - 1)
		{
			tabControl_0.SelectedIndex++;
		}
	}

	private void method_1(object sender, EventArgs e)
	{
		if (bool_0)
		{
		}
	}

	private void method_2(object sender, KeyEventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if ((e.KeyCode == Keys.Return) | (e.KeyCode == Keys.Tab))
		{
			int result = 0;
			int.TryParse(control.Tag.ToString(), out result);
			buControlCommands.FindNextControlByKey(tabControl_0.SelectedTab.Controls, result, e.Shift);
		}
	}

	private void method_3(object sender, EventArgs e)
	{
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
