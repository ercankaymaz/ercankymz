using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns27;

namespace buControls.Forms.WinControlForms.Helps;

public class F_About : Form
{
	public static List<string> Captions = new List<string>();

	private IContainer icontainer_0 = null;

	internal TextBox textBox_0;

	internal Button button_0;

	internal PictureBox pictureBox_0;

	internal Label label_0;

	internal Label label_1;

	internal Label label_2;

	internal Label label_3;

	public F_About()
	{
		Class76.smethod_657(this);
	}

	public void Init(string ProductName, string Version, string CopyRight, string Company, string Description, string Title, Image img)
	{
		Text = Title;
		label_0.Text = ProductName;
		label_1.Text = Version;
		label_2.Text = CopyRight;
		label_3.Text = Company;
		textBox_0.Text = Description;
		if (img != null)
		{
			pictureBox_0.Image = img;
		}
		Class76.smethod_119(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
		Dispose();
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
