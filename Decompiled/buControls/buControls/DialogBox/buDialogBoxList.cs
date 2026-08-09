using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buControls.Controls;
using ns27;

namespace buControls.DialogBox;

public class buDialogBoxList : Form
{
	public string Caption = "List";

	public DialogResult Result = DialogResult.None;

	public List<string> Items = new List<string>();

	public int SelectedIndex = -1;

	public string SelectedItemText = "";

	internal IContainer icontainer_0 = null;

	internal buGround buGround_0;

	public buButton btn_close;

	internal buButton buButton_0;

	internal buButton buButton_1;

	internal ImageList imageList_0;

	internal buListBox buListBox_0;

	internal PictureBox pictureBox_0;

	public buDialogBoxList()
	{
		Class76.smethod_521(this);
	}

	public void Init()
	{
		buListBox_0.Items.Clear();
		buListBox_0.Font = Font;
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			buListBox_0.Items.Add(Items[i]);
		}
		if ((SelectedIndex >= 0) & (SelectedIndex <= buListBox_0.Items.Count - 1))
		{
			buListBox_0.SelectedIndex = SelectedIndex;
		}
		buGround_0.Text = Caption;
	}

	public void Init(string Info, int imageindex)
	{
		buGround_0.Text = Info;
		if (!((imageindex >= 0) & (imageindex <= imageList_0.Images.Count - 1)))
		{
			pictureBox_0.Visible = false;
		}
		else
		{
			pictureBox_0.Image = imageList_0.Images[imageindex];
			pictureBox_0.Visible = true;
		}
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			buListBox_0.Items.Add(Items[i]);
		}
		if ((SelectedIndex >= 0) & (SelectedIndex <= buListBox_0.Items.Count - 1))
		{
			buListBox_0.SelectedIndex = SelectedIndex;
		}
	}

	public void Init(List<string> items, string Info, int imageindex)
	{
		buGround_0.Text = Info;
		if (!((imageindex >= 0) & (imageindex <= imageList_0.Images.Count - 1)))
		{
			pictureBox_0.Visible = false;
		}
		else
		{
			pictureBox_0.Image = imageList_0.Images[imageindex];
			pictureBox_0.Visible = true;
		}
		for (int i = 0; i <= items.Count - 1; i++)
		{
			buListBox_0.Items.Add(items[i]);
		}
		if ((SelectedIndex >= 0) & (SelectedIndex <= buListBox_0.Items.Count - 1))
		{
			buListBox_0.SelectedIndex = SelectedIndex;
		}
	}

	internal void method_0(object sender, EventArgs e)
	{
		SelectedIndex = buListBox_0.SelectedIndex;
		SelectedItemText = buListBox_0.Text;
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
		method_0(buButton_0, e);
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
