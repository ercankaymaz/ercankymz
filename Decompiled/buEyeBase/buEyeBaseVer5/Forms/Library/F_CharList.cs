using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buControls.Viewer;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ns71;

namespace buEyeBaseVer5.Forms.Library;

public class F_CharList : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public List<CharLibrary5> Chars = new List<CharLibrary5>();

	internal IContainer icontainer_0 = null;

	internal CheckedListBox checkedListBox_0;

	public buViewer buViewer1;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	public Button btn_remove;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal NumericUpDown numericUpDown_1;

	internal Label label_1;

	public Button btn_removeall;

	public Button btn_selectall;

	public Button btn_unlsectall;

	public F_CharList()
	{
		Class186.smethod_7(this);
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if ((Properties.Result != DialogResult.OK) & (Properties.Result != DialogResult.Ignore))
		{
			e.Cancel = true;
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
		new ArrayList();
		if (Properties.Height > 10)
		{
			base.Height = Properties.Height;
		}
		if (Properties.Width > 10)
		{
			base.Width = Properties.Width;
		}
		Chars = SortByCharVal(Chars, new CharLibrary5("0"), SortDirection.BiggerToLower);
		for (int i = 0; i <= Chars.Count - 1; i++)
		{
			if (Chars[i].Char.Length > 0)
			{
				string text = "";
				if (Chars[i].Index > 0)
				{
					text = "_" + Chars[i].Index;
				}
				checkedListBox_0.Items.Add(Chars[i].Char + text, isChecked: true);
			}
		}
		Refresh();
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		ControlUpdate();
		Class186.smethod_643(this);
	}

	public void ControlUpdate()
	{
	}

	public List<CharLibrary5> SortByCharVal(List<CharLibrary5> lst, CharLibrary5 refPoint, SortDirection Direction)
	{
		List<CharLibrary5> list = new List<CharLibrary5>();
		if (lst.Count > 0)
		{
			list.Add(lst[NearestIndexPoint(new CharLibrary5(refPoint), lst)]);
			lst.Remove(list[0]);
			int num = 0;
			for (int i = 0; i < lst.Count + num; i++)
			{
				list.Add(lst[NearestIndexPoint(list[list.Count - 1], lst)]);
				lst.Remove(list[list.Count - 1]);
				num++;
			}
			if (Direction == SortDirection.LowerToBigger)
			{
				list.Reverse();
			}
		}
		return list;
	}

	public int NearestIndexPoint(CharLibrary5 srcPt, List<CharLibrary5> lookIn)
	{
		KeyValuePair<int, int> keyValuePair = default(KeyValuePair<int, int>);
		for (int i = 0; i < lookIn.Count; i++)
		{
			string value = lookIn[i].Char;
			if (lookIn[i].Char.Length > 1)
			{
				value = lookIn[i].Char.Substring(0, 1);
			}
			int num = Convert.ToInt32(Convert.ToChar(value));
			if (i != 0)
			{
				if (num < keyValuePair.Key)
				{
					keyValuePair = new KeyValuePair<int, int>(num, i);
				}
			}
			else
			{
				keyValuePair = new KeyValuePair<int, int>(num, i);
			}
		}
		return keyValuePair.Value;
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_ok.Name)
		{
			if (!Properties.Inited)
			{
				return;
			}
			if (Properties.ReadOnly)
			{
				Dispose();
				return;
			}
			Class186.smethod_595(this);
			Properties.Result = DialogResult.OK;
			Dispose();
		}
		if (control.Name == btn_cancel.Name)
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
		if (!(control.Name == btn_remove.Name))
		{
			if (!(control.Name == btn_selectall.Name))
			{
				if (!(control.Name == btn_unlsectall.Name))
				{
					if (!(control.Name == btn_removeall.Name) || buString5.MessageBoxQuestion(AppLanguage.CadCamMessages[130]) != DialogResult.Yes)
					{
						return;
					}
					for (int i = 0; i <= checkedListBox_0.Items.Count - 1; i++)
					{
						if (!checkedListBox_0.GetItemChecked(i))
						{
							continue;
						}
						for (int j = 0; j <= Chars.Count - 1; j++)
						{
							if (checkedListBox_0.Items[i].ToString() == Chars[j].Char)
							{
								Chars.RemoveAt(j);
								j = Chars.Count;
							}
						}
					}
					for (int num = checkedListBox_0.Items.Count - 1; num >= 0; num--)
					{
						if (checkedListBox_0.GetItemChecked(num))
						{
							checkedListBox_0.Items.RemoveAt(num);
						}
					}
				}
				else
				{
					for (int k = 0; k <= checkedListBox_0.Items.Count - 1; k++)
					{
						checkedListBox_0.SetItemChecked(k, value: false);
					}
				}
			}
			else
			{
				for (int l = 0; l <= checkedListBox_0.Items.Count - 1; l++)
				{
					checkedListBox_0.SetItemChecked(l, value: true);
				}
			}
		}
		else if (checkedListBox_0.SelectedIndex >= 0)
		{
			Chars.RemoveAt(checkedListBox_0.SelectedIndex);
			checkedListBox_0.Items.RemoveAt(checkedListBox_0.SelectedIndex);
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		if (Properties.Inited && checkedListBox_0.SelectedIndex >= 0)
		{
			Point3D MinPoint = new Point3D();
			Point3D MaxPoint = new Point3D();
			buCall.buVector5_0.BoxSizeCalculate(Chars[checkedListBox_0.SelectedIndex].CharEntities, ref MinPoint, ref MaxPoint);
			buViewer1.Entities.Clear();
			List<eEntities> list = new List<eEntities>();
			for (int i = 0; i <= Chars[checkedListBox_0.SelectedIndex].CharEntities.Count - 1; i++)
			{
				eEntities item = null;
				Entity copiedEntity = null;
				buEntity.Copy(Chars[checkedListBox_0.SelectedIndex].CharEntities[i], ref copiedEntity);
				buConversion5.eyeEntityToEEntities(copiedEntity, Color.Black, ref item);
				list.Add(item);
			}
			buViewer1.AddEntities(list);
			buViewer1.DrawEntities();
			buViewer1.ZoomFit();
			buViewer1.ZoomOut();
			numericUpDown_0.Value = Convert.ToDecimal(MaxPoint.X - MinPoint.X);
			numericUpDown_1.Value = Convert.ToDecimal(MaxPoint.Y - MinPoint.Y);
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
