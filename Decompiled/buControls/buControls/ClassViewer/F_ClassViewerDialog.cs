using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.ClassViewer;

public class F_ClassViewerDialog : Form
{
	public string OkCaption = "Ok";

	public string CancelCaption = "Cancel";

	public string FormCaption = "";

	public List<string> ParCaptions = new List<string>();

	public DialogResult Result = DialogResult.None;

	public double ValuePersentage = 50.0;

	public int DecimalPlace = 3;

	public int CaptionWidthOffset = 0;

	public bool ColorComboBoxMode = false;

	public object Value = null;

	private object object_0 = null;

	private IContainer icontainer_0 = null;

	internal buClassViewer buClassViewer_0;

	public Button btn_cancel;

	public Button btn_ok;

	public F_ClassViewerDialog()
	{
		Class76.smethod_715(this);
	}

	public void Init()
	{
		if (FormCaption.Length > 0)
		{
			Text = FormCaption;
		}
		if (OkCaption.Length > 0)
		{
			btn_ok.Text = OkCaption;
		}
		if (CancelCaption.Length > 0)
		{
			btn_cancel.Text = CancelCaption;
		}
		buSerilization.CopyClass(Value, ref object_0);
		buClassViewer_0.ClassObject = object_0;
		buClassViewer_0.RowSpace = 1;
		buClassViewer_0.Width = base.Width - 15;
		buClassViewer_0.CaptionWidthOffset = CaptionWidthOffset;
		buClassViewer_0.ColorComboBoxMode = ColorComboBoxMode;
		buClassViewer_0.Visible = true;
		buClassViewer_0.DecimalPlace = DecimalPlace;
		buClassViewer_0.ValueWidth = Convert.ToInt32((double)base.Width * (ValuePersentage / 100.0)) - 8;
		buClassViewer_0.ParCaptions.Clear();
		for (int i = 0; i <= ParCaptions.Count - 1; i++)
		{
			buClassViewer_0.ParCaptions.Add(ParCaptions[i]);
		}
		buClassViewer_0.Init();
	}

	internal void method_0(object sender, EventArgs e)
	{
		buSerilization.CopyClass(object_0, ref Value);
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
