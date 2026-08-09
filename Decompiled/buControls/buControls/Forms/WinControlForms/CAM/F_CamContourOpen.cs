using System.ComponentModel;
using System.Windows.Forms;
using ns27;

namespace buControls.Forms.WinControlForms.CAM;

public class F_CamContourOpen : Form
{
	private IContainer icontainer_0 = null;

	public F_CamContourOpen()
	{
		Class76.smethod_390(this);
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
