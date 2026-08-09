using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buControls.UserControls;
using ns27;

namespace buControls.Forms.WinControlForms.Drawings;

public class F_VectorText : Form
{
	public static List<string> Captions = new List<string>();

	public TextVectorData TextData = new TextVectorData();

	public DialogResult Result = DialogResult.None;

	public bool ShowXYPoint = false;

	private IContainer icontainer_0 = null;

	public Button btn_cancel;

	public Button btn_ok;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_1;

	internal TextBox textBox_0;

	internal buContentAlignment buContentAlignment_0;

	internal Label label_2;

	internal Label label_3;

	public Button btn_font;

	internal Label label_4;

	internal NumericUpDown numericUpDown_1;

	internal NumericUpDown numericUpDown_2;

	internal Label label_5;

	public F_VectorText()
	{
		Class76.smethod_408(this);
	}

	public void Init()
	{
		TextData.Font = new Font(TextData.Font.FontFamily, (float)TextData.Height, TextData.Font.Style);
		textBox_0.Text = TextData.Text;
		numericUpDown_0.Value = (decimal)TextData.Height;
		btn_font.Text = TextData.Font.Name + " - " + TextData.Font.Size;
		buContentAlignment_0.Alignment = TextData.Alignment;
		numericUpDown_2.Value = (decimal)TextData.CenterPoint.X;
		numericUpDown_1.Value = (decimal)TextData.CenterPoint.Y;
		label_5.Visible = ShowXYPoint;
		label_4.Visible = ShowXYPoint;
		numericUpDown_2.Visible = ShowXYPoint;
		numericUpDown_1.Visible = ShowXYPoint;
		Class76.smethod_720(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_ok.Name)
		{
			TextData.CenterPoint.X = (double)numericUpDown_2.Value;
			TextData.CenterPoint.Y = (double)numericUpDown_1.Value;
			TextData.Text = textBox_0.Text;
			TextData.Height = (double)numericUpDown_0.Value;
			TextData.Alignment = buContentAlignment_0.Alignment;
			Result = DialogResult.OK;
			Dispose();
		}
		if (control.Name == btn_cancel.Name)
		{
			Result = DialogResult.Cancel;
			Dispose();
		}
		if (control.Name == btn_font.Name)
		{
			FontDialog fontDialog = new FontDialog();
			fontDialog.Font = new Font(TextData.Font.FontFamily, (float)numericUpDown_0.Value, TextData.Font.Style);
			if (fontDialog.ShowDialog() == DialogResult.OK)
			{
				numericUpDown_0.Value = Math.Round((decimal)fontDialog.Font.Size, 0);
				TextData.Height = (double)numericUpDown_0.Value;
				TextData.Font = new Font(fontDialog.Font.FontFamily, (float)TextData.Height, fontDialog.Font.Style);
				btn_font.Font = new Font(fontDialog.Font.FontFamily, 8f);
				btn_font.Text = TextData.Font.Name + " - " + TextData.Font.Size;
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
