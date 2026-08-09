using System;
using System.ComponentModel;
using System.Windows.Forms;
using ns27;

namespace buControls.DialogBox;

public class DialogBoxInput : Form
{
	public double Value = 0.0;

	public string ValueCaption = "Value";

	public string FormCaption = "Data Input";

	public int FormWidth = 0;

	public int FormHeight = 0;

	public DialogResult Result = DialogResult.None;

	internal IContainer icontainer_0 = null;

	public Button btn_cancel;

	internal ImageList imageList_0;

	public Button btn_ok;

	internal NumericUpDown numericUpDown_0;

	internal Label label_0;

	public DialogBoxInput()
	{
		Class76.smethod_62(this);
	}

	public void Init()
	{
		if (FormWidth > 1)
		{
			base.Width = FormWidth;
		}
		if (FormHeight > 1)
		{
			base.Height = FormHeight;
		}
		Text = FormCaption;
		label_0.Text = ValueCaption;
		numericUpDown_0.Value = (decimal)Value;
		Result = DialogResult.None;
	}

	public void SelectAll()
	{
		numericUpDown_0.Select(0, 100);
	}

	public void Decimal(int Decimal)
	{
		numericUpDown_0.DecimalPlaces = Decimal;
	}

	internal void method_0(object sender, EventArgs e)
	{
		Value = (double)numericUpDown_0.Value;
		Result = DialogResult.OK;
		Dispose();
	}

	internal void method_1(object sender, EventArgs e)
	{
		Result = DialogResult.Cancel;
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
