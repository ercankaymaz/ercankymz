using System.ComponentModel;
using System.Windows.Forms;
using ns27;

namespace buControls.Forms.WinControlForms.Settings;

public class F_DisplayPointer : Form
{
	internal IContainer icontainer_0 = null;

	public F_DisplayPointer()
	{
		Class76.smethod_796(this);
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
