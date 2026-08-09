using System.ComponentModel;
using System.Windows.Forms;
using ns71;

namespace buEyeBaseVer5.Forms.Marble.OperationData;

public class Form1 : Form
{
	private IContainer icontainer_0 = null;

	public Form1()
	{
		Class186.smethod_707(this);
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
