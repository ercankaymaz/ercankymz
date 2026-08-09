using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleCuttingSequence : Form
{
	public static List<string> Captions = new List<string>();

	public List<MarbleOperationSequence> Sequences = new List<MarbleOperationSequence>();

	public FormProperties PropertiesForm = new FormProperties();

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	internal buButton buButton_0;

	internal buButton buButton_1;

	public buButton btn_close;

	internal buListBox buListBox_0;

	internal buButton buButton_2;

	internal buButton buButton_3;

	internal buLabel buLabel_0;

	internal buListBox buListBox_1;

	internal buLabel buLabel_1;

	internal buButton buButton_4;

	internal buButton buButton_5;

	public F_MarbleCuttingSequence()
	{
		Class186.smethod_783(this);
	}

	public void Init()
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
		buListBox_0.Items.Clear();
		buListBox_1.Items.Clear();
		buListBox_0.Items.Add(AddItem(MarbleOperationSequence.CornerCleanByDrill));
		buListBox_0.Items.Add(AddItem(MarbleOperationSequence.CornerCleanByMilling));
		buListBox_0.Items.Add(AddItem(MarbleOperationSequence.MillingCuttings));
		buListBox_0.Items.Add(AddItem(MarbleOperationSequence.Drills));
		buListBox_0.Items.Add(AddItem(MarbleOperationSequence.SawAngleCutStraight));
		buListBox_0.Items.Add(AddItem(MarbleOperationSequence.SawCircular));
		buListBox_0.Items.Add(AddItem(MarbleOperationSequence.SawStraight));
		for (int i = 0; i <= Sequences.Count - 1; i++)
		{
			buListBox_1.Items.Add(AddItem(Sequences[i]));
		}
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			buGround_0.Text = buLangTranslate.preDef.Sequence;
			buButton_0.Text = buLangTranslate.preDef.Ok;
			buButton_1.Text = buLangTranslate.preDef.Cancel;
		}
		catch (Exception)
		{
		}
	}

	public string AddItem(MarbleOperationSequence OP)
	{
		string result = "";
		if (OP == MarbleOperationSequence.CornerCleanByDrill)
		{
			result = buLangTranslate.preDef.Corner + " " + buLangTranslate.preDef.Drill + " - " + Convert.ToInt32(MarbleOperationSequence.CornerCleanByDrill);
		}
		if (OP == MarbleOperationSequence.CornerCleanByMilling)
		{
			result = buLangTranslate.preDef.Corner + " " + buLangTranslate.preDef.Milling + " - " + Convert.ToInt32(MarbleOperationSequence.CornerCleanByMilling);
		}
		if (OP == MarbleOperationSequence.MillingCuttings)
		{
			result = buLangTranslate.preDef.Milling + " " + buLangTranslate.preDef.Cutting + " - " + Convert.ToInt32(MarbleOperationSequence.MillingCuttings);
		}
		if (OP == MarbleOperationSequence.Drills)
		{
			result = buLangTranslate.preDef.Drill + " - " + Convert.ToInt32(MarbleOperationSequence.Drills);
		}
		if (OP == MarbleOperationSequence.SawAngleCutStraight)
		{
			result = buLangTranslate.preDef.Angle + " " + buLangTranslate.preDef.Saw + " " + buLangTranslate.preDef.Cutting + " - " + Convert.ToInt32(MarbleOperationSequence.SawAngleCutStraight);
		}
		if (OP == MarbleOperationSequence.SawCircular)
		{
			result = buLangTranslate.preDef.Saw + " " + buLangTranslate.preDef.Circular + " - " + Convert.ToInt32(MarbleOperationSequence.SawCircular);
		}
		if (OP == MarbleOperationSequence.SawStraight)
		{
			result = buLangTranslate.preDef.Saw + " " + buLangTranslate.preDef.Straight + " - " + Convert.ToInt32(MarbleOperationSequence.SawStraight);
		}
		return result;
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (PropertiesForm.Result != DialogResult.OK)
		{
			e.Cancel = true;
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

	internal void method_1(object sender, EventArgs e)
	{
		Sequences.Clear();
		for (int i = 0; i <= buListBox_1.Items.Count - 1; i++)
		{
			string[] array = buListBox_1.Items[i].ToString().Split('-');
			if (array != null && array.Length >= 2)
			{
				int num = int.Parse(array[1]);
				if (num >= 0)
				{
					Sequences.Add((MarbleOperationSequence)num);
				}
			}
		}
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

	internal void method_2(object sender, EventArgs e)
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

	internal void method_3(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == buButton_2.Name && buListBox_0.SelectedIndex >= 0)
		{
			buListBox_0.Items.RemoveAt(buListBox_0.SelectedIndex);
		}
		if (control.Name == buButton_3.Name && buListBox_0.SelectedIndex >= 0)
		{
			buListBox_1.Items.Add(buListBox_0.Items[buListBox_0.SelectedIndex]);
		}
		if (control.Name == buButton_5.Name && buListBox_1.SelectedIndex >= 1)
		{
			int selectedIndex = buListBox_1.SelectedIndex;
			string item = buListBox_1.Items[buListBox_1.SelectedIndex].ToString();
			buListBox_1.Items.RemoveAt(buListBox_1.SelectedIndex);
			buListBox_1.Items.Insert(selectedIndex - 1, item);
		}
		if (control.Name == buButton_4.Name && buListBox_1.SelectedIndex < buListBox_1.Items.Count - 1)
		{
			int selectedIndex2 = buListBox_1.SelectedIndex;
			string item2 = buListBox_1.Items[buListBox_1.SelectedIndex].ToString();
			buListBox_1.Items.RemoveAt(buListBox_1.SelectedIndex);
			buListBox_1.Items.Insert(selectedIndex2 + 1, item2);
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
