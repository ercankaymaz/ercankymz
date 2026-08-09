using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ns27;

namespace buControls.DialogBox;

public class DialogBoxList : Form
{
	public string FormCaption = "List";

	public string Caption = "List";

	public DialogResult Result = DialogResult.None;

	public List<string> Items = new List<string>();

	public int SelectedIndex = -1;

	public string SelectedItemText = "";

	internal IContainer icontainer_0 = null;

	public Button btn_cancel;

	public Button btn_ok;

	internal ImageList imageList_0;

	internal PictureBox pictureBox_0;

	internal ImageList imageList_1;

	internal Label label_0;

	public ListBox lst_items;

	public DialogBoxList()
	{
		Class76.smethod_318(this);
	}

	public void Init()
	{
		lst_items.Items.Clear();
		lst_items.Font = Font;
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			lst_items.Items.Add(Items[i]);
		}
		if ((SelectedIndex >= 0) & (SelectedIndex <= lst_items.Items.Count - 1))
		{
			lst_items.SelectedIndex = SelectedIndex;
		}
		Text = Caption;
	}

	public void Init(string Info, int imageindex)
	{
		if (Info.Trim().Length <= 0)
		{
			label_0.Visible = false;
		}
		else
		{
			label_0.Visible = true;
		}
		label_0.Text = Info;
		if (!((imageindex >= 0) & (imageindex <= imageList_1.Images.Count - 1)))
		{
			pictureBox_0.Visible = false;
		}
		else
		{
			pictureBox_0.Image = imageList_1.Images[imageindex];
			pictureBox_0.Visible = true;
		}
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			lst_items.Items.Add(Items[i]);
		}
		if ((SelectedIndex >= 0) & (SelectedIndex <= lst_items.Items.Count - 1))
		{
			lst_items.SelectedIndex = SelectedIndex;
		}
		Text = Caption;
	}

	internal void method_0(object sender, EventArgs e)
	{
		SelectedIndex = lst_items.SelectedIndex;
		SelectedItemText = lst_items.Text;
		Result = DialogResult.OK;
		Dispose();
	}

	internal void method_1(object sender, EventArgs e)
	{
		Result = DialogResult.Cancel;
		Dispose();
	}

	internal void method_2(object sender, EventArgs e)
	{
		method_0(btn_ok, e);
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
