using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ns27;

namespace buControls.Forms.WinControlForms.Diemaker;

public class F_BendingItems : Form
{
	public static List<string> Captions = new List<string>();

	private IContainer icontainer_0 = null;

	public F_BendingItems()
	{
		Class76.smethod_791(this);
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
