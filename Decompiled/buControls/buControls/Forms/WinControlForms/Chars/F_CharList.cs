using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Viewer;
using ns27;

namespace buControls.Forms.WinControlForms.Chars;

public class F_CharList : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public List<CharLibrary> Chars = new List<CharLibrary>();

	internal IContainer icontainer_0 = null;

	internal CheckedListBox checkedListBox_0;

	public buViewer buViewer1;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	public Button btn_remove;

	public Button btn_add;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal NumericUpDown numericUpDown_1;

	internal Label label_1;

	public F_CharList()
	{
		Class76.smethod_703(this);
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
		List<char> list = new List<char>();
		for (int i = 0; i <= 65535; i++)
		{
			char c = Convert.ToChar(i);
			if (char.IsControl(c))
			{
				continue;
			}
			string text = c.ToString().Trim();
			if (text.Length == 1 && i >= 33 && i <= 1260)
			{
				bool flag = false;
				for (int j = 0; j <= Chars.Count - 1; j++)
				{
					if (Chars[j].Char == text)
					{
						flag = true;
					}
				}
				if (flag)
				{
					checkedListBox_0.Items.Add(text, flag);
				}
			}
			list.Add(c);
		}
		Refresh();
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		ControlUpdate();
		Class76.smethod_838(this);
	}

	public void ControlUpdate()
	{
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
			Class76.smethod_371(this);
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
		if (!(control.Name == btn_add.Name))
		{
		}
		if (!(control.Name == btn_remove.Name))
		{
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		if (!Properties.Inited)
		{
			return;
		}
		bool flag = false;
		if (checkedListBox_0.SelectedIndex < 0)
		{
			return;
		}
		if (checkedListBox_0.GetItemChecked(checkedListBox_0.SelectedIndex))
		{
			for (int i = 0; i <= Chars.Count - 1; i++)
			{
				string text = checkedListBox_0.Items[checkedListBox_0.SelectedIndex].ToString();
				if (Chars[i].Char == text)
				{
					Pnt3D MinPnt = new Pnt3D();
					Pnt3D MaxPnt = new Pnt3D();
					buControlCoreClass.cVector.BoxSizeCalculate(Chars[i].CharEntities, ref MinPnt, ref MaxPnt);
					buViewer1.Entities.Clear();
					List<eEntities> EEntities = new List<eEntities>();
					geoEntity.GeoEntitiyToEEntity(Chars[i].CharEntities, ref EEntities);
					buViewer1.AddEntities(EEntities);
					buViewer1.DrawEntities();
					buViewer1.ZoomFit();
					buViewer1.ZoomOut();
					flag = true;
					numericUpDown_0.Value = Convert.ToDecimal(MaxPnt.X - MinPnt.X);
					numericUpDown_1.Value = Convert.ToDecimal(MaxPnt.Y - MinPnt.Y);
				}
			}
		}
		if (!flag)
		{
			buViewer1.Entities.Clear();
			buViewer1.DrawEntities();
			numericUpDown_0.Value = Convert.ToDecimal(0);
			numericUpDown_1.Value = Convert.ToDecimal(0);
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
