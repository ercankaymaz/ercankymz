using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buControls.ColorPicker;
using ns27;

namespace buControls.DialogBox;

public class ColorDialogBox : Form
{
	public static Color Color = Color.Black;

	public static DialogResult Result = DialogResult.None;

	private IContainer icontainer_0 = null;

	internal Button button_0;

	internal Button button_1;

	public buColorPicker buColorPicker1;

	public ColorDialogBox()
	{
		Class76.smethod_392(this);
	}

	public static Color ShowDialog(Color cColor)
	{
		Color = cColor;
		ColorDialogBox colorDialogBox = new ColorDialogBox();
		colorDialogBox.buColorPicker1.Color = Color;
		colorDialogBox.buColorPicker1.ColorChanged += Class76.smethod_820;
		colorDialogBox.ShowDialog();
		colorDialogBox.Dispose();
		return Color;
	}

	public static DialogResult ShowDialog(ref Color cColor)
	{
		Color = cColor;
		ColorDialogBox colorDialogBox = new ColorDialogBox();
		colorDialogBox.buColorPicker1.Color = Color;
		colorDialogBox.buColorPicker1.ColorChanged += Class76.smethod_820;
		colorDialogBox.ShowDialog();
		colorDialogBox.Dispose();
		cColor = Color;
		return Result;
	}

	internal void method_0(object sender, EventArgs e)
	{
		base.Visible = false;
		Result = DialogResult.Cancel;
	}

	internal void method_1(object sender, EventArgs e)
	{
		base.Visible = false;
		Result = DialogResult.OK;
	}

	internal void method_2(object sender, EventArgs e)
	{
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
