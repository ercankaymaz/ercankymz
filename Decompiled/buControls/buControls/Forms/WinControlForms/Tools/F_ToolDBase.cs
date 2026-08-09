using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.Tools;

public class F_ToolDBase : Form
{
	public static List<string> Captions = new List<string>();

	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public DialogResult Result = DialogResult.None;

	public List<ToolBase> Tools = new List<ToolBase>();

	public int ToolSelectedIndex = 0;

	public bool DemoMode = false;

	public bool ShowPurpose = true;

	public bool ShowSpindleDir = true;

	public bool ShowGeometry = true;

	[CompilerGenerated]
	private OkCommandWithDataEventHandler okCommandWithDataEventHandler_0;

	[CompilerGenerated]
	private CancelCommandEventHandler cancelCommandEventHandler_0;

	public string LangMessageDMode = "You Can't Do This Operation in Demo Mode";

	public string LangMessageRemove = "Do You Want to Remove Tool";

	public string LangMessageThisToolAvailable = "This Tool is Available";

	private bool bool_0 = false;

	private ToolBase toolBase_0 = new ToolBase();

	internal IContainer icontainer_0 = null;

	internal ListBox listBox_0;

	internal TextBox textBox_0;

	internal Label label_0;

	internal ComboBox comboBox_0;

	internal Label label_1;

	internal ComboBox comboBox_1;

	internal Label label_2;

	internal Label label_3;

	internal NumericUpDown numericUpDown_0;

	internal Label label_4;

	internal NumericUpDown numericUpDown_1;

	internal Label label_5;

	internal NumericUpDown numericUpDown_2;

	internal Label label_6;

	internal NumericUpDown numericUpDown_3;

	internal Label label_7;

	internal NumericUpDown numericUpDown_4;

	internal Label label_8;

	internal NumericUpDown numericUpDown_5;

	internal Label label_9;

	internal TextBox textBox_1;

	internal ComboBox comboBox_2;

	internal Label label_10;

	internal Panel panel_0;

	internal Label label_11;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	public Button btn_add;

	public Button btn_edit;

	public Button btn_remove;

	public event OkCommandWithDataEventHandler OkPressed
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithDataEventHandler okCommandWithDataEventHandler = okCommandWithDataEventHandler_0;
			OkCommandWithDataEventHandler okCommandWithDataEventHandler2;
			do
			{
				okCommandWithDataEventHandler2 = okCommandWithDataEventHandler;
				OkCommandWithDataEventHandler value2 = (OkCommandWithDataEventHandler)Delegate.Combine(okCommandWithDataEventHandler2, value);
				okCommandWithDataEventHandler = Interlocked.CompareExchange(ref okCommandWithDataEventHandler_0, value2, okCommandWithDataEventHandler2);
			}
			while ((object)okCommandWithDataEventHandler != okCommandWithDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithDataEventHandler okCommandWithDataEventHandler = okCommandWithDataEventHandler_0;
			OkCommandWithDataEventHandler okCommandWithDataEventHandler2;
			do
			{
				okCommandWithDataEventHandler2 = okCommandWithDataEventHandler;
				OkCommandWithDataEventHandler value2 = (OkCommandWithDataEventHandler)Delegate.Remove(okCommandWithDataEventHandler2, value);
				okCommandWithDataEventHandler = Interlocked.CompareExchange(ref okCommandWithDataEventHandler_0, value2, okCommandWithDataEventHandler2);
			}
			while ((object)okCommandWithDataEventHandler != okCommandWithDataEventHandler2);
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

	public F_ToolDBase()
	{
		Class76.smethod_783(this);
	}

	public void Init()
	{
		bool_0 = false;
		label_2.Visible = ShowPurpose;
		comboBox_1.Visible = ShowPurpose;
		label_1.Visible = ShowGeometry;
		comboBox_0.Visible = ShowGeometry;
		label_10.Visible = ShowSpindleDir;
		comboBox_2.Visible = ShowSpindleDir;
		listBox_0.Items.Clear();
		if (Tools.Count > 0)
		{
			toolBase_0 = new ToolBase(Tools[0]);
			for (int i = 0; i <= Tools.Count - 1; i++)
			{
				listBox_0.Items.Add("T" + Tools[i].Data.No + " - " + Tools[i].Data.Name);
			}
			if (!((ToolSelectedIndex >= 0) & (ToolSelectedIndex <= Tools.Count - 1)))
			{
				bool_0 = true;
				ToolSelectedIndex = 0;
				listBox_0.SelectedIndex = ToolSelectedIndex;
				toolBase_0 = new ToolBase(Tools[ToolSelectedIndex]);
			}
			else
			{
				bool_0 = true;
				listBox_0.SelectedIndex = ToolSelectedIndex;
				toolBase_0 = new ToolBase(Tools[ToolSelectedIndex]);
			}
		}
		LoadLangueage();
	}

	public void LoadLangueage()
	{
		string callMethod = "TooDataBase LoadLanguage";
		try
		{
			if (Captions.Count >= 18)
			{
				Text = Captions[0];
				label_0.Text = Captions[1];
				btn_add.Text = Captions[2];
				btn_remove.Text = Captions[3];
				btn_edit.Text = Captions[4];
				label_11.Text = Captions[5];
				label_9.Text = Captions[6];
				label_8.Text = Captions[7];
				label_7.Text = Captions[8];
				label_6.Text = Captions[9];
				label_5.Text = Captions[10];
				label_4.Text = Captions[11];
				label_3.Text = Captions[12];
				label_2.Text = Captions[13];
				label_1.Text = Captions[14];
				label_10.Text = Captions[15];
				btn_ok.Text = Captions[16];
				btn_cancel.Text = Captions[17];
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	internal void method_0(object sender, EventArgs e)
	{
		if (!DemoMode)
		{
			Result = DialogResult.OK;
			if (FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
			if (okCommandWithDataEventHandler_0 != null)
			{
				okCommandWithDataEventHandler_0(Tools);
			}
		}
		else
		{
			buString.MessageBoxError(LangMessageDMode);
		}
	}

	internal void method_1(object sender, EventArgs e)
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
		if (base.Owner != null)
		{
			base.Owner.Focus();
		}
		if (cancelCommandEventHandler_0 != null)
		{
			cancelCommandEventHandler_0();
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		for (int i = 0; i <= Tools.Count - 1; i++)
		{
			if (Tools[i].Data.Name.Trim().ToLower() == textBox_1.Text.Trim().ToLower())
			{
				buString.MessageBoxWarning(LangMessageThisToolAvailable);
				return;
			}
		}
		ToolBase toolBase = new ToolBase();
		toolBase.Data.Name = textBox_1.Text;
		toolBase.Data.No = (int)numericUpDown_5.Value;
		toolBase.CamData.FeedSpeed = (double)numericUpDown_1.Value;
		toolBase.CamData.PlungeSpeed = (double)numericUpDown_0.Value;
		toolBase.CamData.SpindleSpeed = (double)numericUpDown_2.Value;
		toolBase.Geometry.Diameter = (double)numericUpDown_4.Value;
		toolBase.Geometry.Length = (double)numericUpDown_3.Value;
		if (ShowGeometry)
		{
			toolBase.Geometry.GeometryType = (ToolType)buGeneral.EnumValueFromInt(toolBase.Geometry.GeometryType, comboBox_0.SelectedIndex);
		}
		if (ShowSpindleDir)
		{
			toolBase.CamData.SpindleDirection = (ClockDirectionType)buGeneral.EnumValueFromInt(toolBase.CamData.SpindleDirection, comboBox_2.SelectedIndex);
		}
		if (ShowPurpose)
		{
			toolBase.Purpose = (ToolPurpose)buGeneral.EnumValueFromInt(toolBase.Purpose, comboBox_1.SelectedIndex);
		}
		Tools.Add(toolBase);
		Init();
	}

	internal void method_3(object sender, EventArgs e)
	{
		if (((listBox_0.SelectedIndex >= 0) & (listBox_0.SelectedIndex <= Tools.Count - 1)) && buString.MessageBoxQuestion(LangMessageRemove) == DialogResult.Yes)
		{
			Tools.RemoveAt(listBox_0.SelectedIndex);
			Init();
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		if ((ToolSelectedIndex >= 0) & (ToolSelectedIndex <= Tools.Count - 1))
		{
			Tools[ToolSelectedIndex].Data.Name = textBox_1.Text;
			Tools[ToolSelectedIndex].Data.No = (int)numericUpDown_5.Value;
			Tools[ToolSelectedIndex].CamData.FeedSpeed = (double)numericUpDown_1.Value;
			Tools[ToolSelectedIndex].CamData.PlungeSpeed = (double)numericUpDown_0.Value;
			Tools[ToolSelectedIndex].CamData.SpindleSpeed = (double)numericUpDown_2.Value;
			Tools[ToolSelectedIndex].Geometry.Diameter = (double)numericUpDown_4.Value;
			Tools[ToolSelectedIndex].Geometry.Length = (double)numericUpDown_3.Value;
			if (ShowGeometry)
			{
				Tools[ToolSelectedIndex].Geometry.GeometryType = (ToolType)buGeneral.EnumValueFromInt(Tools[ToolSelectedIndex].Geometry.GeometryType, comboBox_0.SelectedIndex);
			}
			if (ShowSpindleDir)
			{
				Tools[ToolSelectedIndex].CamData.SpindleDirection = (ClockDirectionType)buGeneral.EnumValueFromInt(Tools[ToolSelectedIndex].CamData.SpindleDirection, comboBox_2.SelectedIndex);
			}
			if (ShowPurpose)
			{
				Tools[ToolSelectedIndex].Purpose = (ToolPurpose)buGeneral.EnumValueFromInt(Tools[ToolSelectedIndex].Purpose, comboBox_1.SelectedIndex);
			}
			Init();
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
	}

	internal void method_6(object sender, EventArgs e)
	{
		if (bool_0)
		{
			toolBase_0 = new ToolBase();
			ToolBase.Copy(Tools[listBox_0.SelectedIndex], ref toolBase_0);
			ToolSelectedIndex = listBox_0.SelectedIndex;
			textBox_1.Text = toolBase_0.Data.Name;
			numericUpDown_5.Value = toolBase_0.Data.No;
			numericUpDown_4.Value = (decimal)toolBase_0.Geometry.Diameter;
			numericUpDown_3.Value = (decimal)toolBase_0.Geometry.Length;
			numericUpDown_2.Value = (decimal)toolBase_0.CamData.SpindleSpeed;
			numericUpDown_1.Value = (decimal)toolBase_0.CamData.FeedSpeed;
			numericUpDown_0.Value = (decimal)toolBase_0.CamData.PlungeSpeed;
			ArrayList EnumItems = new ArrayList();
			buGeneral.GetEnumTypeValues(toolBase_0.CamData.SpindleDirection, ref EnumItems);
			buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(toolBase_0.CamData.SpindleDirection), ref comboBox_2);
			EnumItems = new ArrayList();
			buGeneral.GetEnumTypeValues(toolBase_0.Purpose, ref EnumItems);
			buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(toolBase_0.Purpose), ref comboBox_1);
			EnumItems = new ArrayList();
			buGeneral.GetEnumTypeValues(toolBase_0.Geometry.GeometryType, ref EnumItems);
			buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(toolBase_0.Geometry.GeometryType), ref comboBox_0);
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
