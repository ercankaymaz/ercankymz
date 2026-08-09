using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_TuftingSort : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	[CompilerGenerated]
	private ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler_0;

	[CompilerGenerated]
	private ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler_1;

	public TuftingSettings Settings = new TuftingSettings();

	public int SelectedLayerIndex = -1;

	public string SelectedLayerName = "";

	public List<LayerBase5> Layers = new List<LayerBase5>();

	internal IContainer icontainer_0 = null;

	internal Button button_0;

	internal ImageList imageList_0;

	internal Button button_1;

	internal Panel panel_0;

	internal PictureBox pictureBox_0;

	internal Panel panel_1;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal RadioButton radioButton_2;

	internal RadioButton radioButton_3;

	internal RadioButton radioButton_4;

	internal RadioButton radioButton_5;

	internal RadioButton radioButton_6;

	internal RadioButton radioButton_7;

	internal CheckBox checkBox_0;

	internal ListView listView_0;

	internal CheckBox checkBox_1;

	public event ApplyCommandWithDataEventHandler DataValueChanged
	{
		[CompilerGenerated]
		add
		{
			ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler = applyCommandWithDataEventHandler_0;
			ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler2;
			do
			{
				applyCommandWithDataEventHandler2 = applyCommandWithDataEventHandler;
				ApplyCommandWithDataEventHandler value2 = (ApplyCommandWithDataEventHandler)Delegate.Combine(applyCommandWithDataEventHandler2, value);
				applyCommandWithDataEventHandler = Interlocked.CompareExchange(ref applyCommandWithDataEventHandler_0, value2, applyCommandWithDataEventHandler2);
			}
			while ((object)applyCommandWithDataEventHandler != applyCommandWithDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler = applyCommandWithDataEventHandler_0;
			ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler2;
			do
			{
				applyCommandWithDataEventHandler2 = applyCommandWithDataEventHandler;
				ApplyCommandWithDataEventHandler value2 = (ApplyCommandWithDataEventHandler)Delegate.Remove(applyCommandWithDataEventHandler2, value);
				applyCommandWithDataEventHandler = Interlocked.CompareExchange(ref applyCommandWithDataEventHandler_0, value2, applyCommandWithDataEventHandler2);
			}
			while ((object)applyCommandWithDataEventHandler != applyCommandWithDataEventHandler2);
		}
	}

	public event ApplyCommandWithDataEventHandler SelectedIndexChanged
	{
		[CompilerGenerated]
		add
		{
			ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler = applyCommandWithDataEventHandler_1;
			ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler2;
			do
			{
				applyCommandWithDataEventHandler2 = applyCommandWithDataEventHandler;
				ApplyCommandWithDataEventHandler value2 = (ApplyCommandWithDataEventHandler)Delegate.Combine(applyCommandWithDataEventHandler2, value);
				applyCommandWithDataEventHandler = Interlocked.CompareExchange(ref applyCommandWithDataEventHandler_1, value2, applyCommandWithDataEventHandler2);
			}
			while ((object)applyCommandWithDataEventHandler != applyCommandWithDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler = applyCommandWithDataEventHandler_1;
			ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler2;
			do
			{
				applyCommandWithDataEventHandler2 = applyCommandWithDataEventHandler;
				ApplyCommandWithDataEventHandler value2 = (ApplyCommandWithDataEventHandler)Delegate.Remove(applyCommandWithDataEventHandler2, value);
				applyCommandWithDataEventHandler = Interlocked.CompareExchange(ref applyCommandWithDataEventHandler_1, value2, applyCommandWithDataEventHandler2);
			}
			while ((object)applyCommandWithDataEventHandler != applyCommandWithDataEventHandler2);
		}
	}

	public F_TuftingSort()
	{
		Class186.smethod_624(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (Settings.SortType != tuftingSelectionModeType.Auto)
		{
			radioButton_7.Checked = false;
			radioButton_6.Checked = true;
		}
		else
		{
			radioButton_7.Checked = true;
			radioButton_6.Checked = false;
		}
		radioButton_5.Checked = false;
		radioButton_4.Checked = false;
		radioButton_2.Checked = false;
		radioButton_3.Checked = false;
		radioButton_0.Checked = false;
		radioButton_1.Checked = false;
		if (Settings.SortAutoNextGroupRules != SortingNextGroupFindRulesType.ClosestLength)
		{
			if (Settings.SortAutoNextGroupRules != SortingNextGroupFindRulesType.DrawingSequence)
			{
				if (Settings.SortAutoNextGroupRules != SortingNextGroupFindRulesType.MinXMinY)
				{
					if (Settings.SortAutoNextGroupRules != SortingNextGroupFindRulesType.MaxXMinY)
					{
						if (Settings.SortAutoNextGroupRules != SortingNextGroupFindRulesType.MinYMinX)
						{
							if (Settings.SortAutoNextGroupRules == SortingNextGroupFindRulesType.MaxYMinX)
							{
								radioButton_0.Checked = true;
							}
						}
						else
						{
							radioButton_1.Checked = true;
						}
					}
					else
					{
						radioButton_2.Checked = true;
					}
				}
				else
				{
					radioButton_3.Checked = true;
				}
			}
			else
			{
				radioButton_4.Checked = true;
			}
		}
		else
		{
			radioButton_5.Checked = true;
		}
		checkBox_0.Checked = Settings.SortOutlineFirst;
		checkBox_1.Checked = Settings.SortBoxBounding;
		listView_0.HeaderStyle = ColumnHeaderStyle.None;
		listView_0.View = View.Details;
		listView_0.FullRowSelect = true;
		listView_0.Columns.Add("", -2);
		listView_0.Columns[0].Width = listView_0.Width - 5;
		for (int i = 0; i <= Layers.Count - 1; i++)
		{
			if (Layers[i].Name.IndexOf("T_") >= 0)
			{
				string name = Layers[i].Name;
				ListViewItem listViewItem = new ListViewItem(name);
				listViewItem.BackColor = Color.White;
				listViewItem.ForeColor = Layers[i].LayerColor;
				if (buImage5.isColorSimilar(listViewItem.ForeColor, Color.White, 5.0))
				{
					listViewItem.ForeColor = Color.Black;
				}
				listView_0.Items.Add(listViewItem);
			}
		}
		if (listView_0.Items.Count <= 0)
		{
		}
		for (int j = 0; j <= listView_0.Items.Count - 1; j++)
		{
			if (listView_0.Items[j].Text == SelectedLayerName)
			{
				listView_0.Items[j].Selected = true;
			}
		}
		listView_0.Select();
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = false;
	}

	public void LoadLanguage()
	{
		string callMethod = "NestSheetPart LoadLanguage";
		try
		{
			if (Captions.Count >= 33)
			{
				Text = Captions[0];
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	public void Apply()
	{
		if (!radioButton_7.Checked)
		{
			Settings.SortType = tuftingSelectionModeType.Manuel;
		}
		else
		{
			Settings.SortType = tuftingSelectionModeType.Auto;
		}
		if (!radioButton_5.Checked)
		{
			if (!radioButton_4.Checked)
			{
				if (!radioButton_3.Checked)
				{
					if (!radioButton_2.Checked)
					{
						if (!radioButton_1.Checked)
						{
							if (radioButton_0.Checked)
							{
								Settings.SortAutoNextGroupRules = SortingNextGroupFindRulesType.MaxYMinX;
							}
						}
						else
						{
							Settings.SortAutoNextGroupRules = SortingNextGroupFindRulesType.MinYMinX;
						}
					}
					else
					{
						Settings.SortAutoNextGroupRules = SortingNextGroupFindRulesType.MaxXMinY;
					}
				}
				else
				{
					Settings.SortAutoNextGroupRules = SortingNextGroupFindRulesType.MinXMinY;
				}
			}
			else
			{
				Settings.SortAutoNextGroupRules = SortingNextGroupFindRulesType.DrawingSequence;
			}
		}
		else
		{
			Settings.SortAutoNextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
		}
		Settings.SortBoxBounding = checkBox_1.Checked;
		Settings.SortOutlineFirst = checkBox_0.Checked;
		SelectedLayerName = listView_0.SelectedItems[0].Text;
	}

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		if ((sender.GetType() == typeof(Control)) | (sender.GetType() == typeof(Button)))
		{
			control = (Control)sender;
			_ = control.Name;
		}
		if (sender.GetType() == typeof(ToolStripMenuItem))
		{
			_ = ((ToolStripMenuItem)sender).Name;
		}
		if (control.Name == button_0.Name)
		{
			Apply();
			PropertiesForm.Result = DialogResult.OK;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == button_1.Name)
		{
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
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
