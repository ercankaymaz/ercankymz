using System.ComponentModel;
using System.Windows.Forms;
using buControls.ClassViewer;
using ns8;

namespace buCadCamResVer5.Forms;

public class F_DataClass : Form
{
	private IContainer icontainer_0 = null;

	public buClassViewer buClassViewer1;

	public F_DataClass()
	{
		Class5.smethod_77(this);
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		e.Cancel = true;
		base.Visible = false;
	}

	internal void method_1(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			clsInit.appCommand.Reset();
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
