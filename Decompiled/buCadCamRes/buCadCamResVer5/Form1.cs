using System.ComponentModel;
using System.Windows.Forms;
using ns8;

namespace buCadCamResVer5;

public class Form1 : Form
{
	private IContainer icontainer_0 = null;

	public Form1()
	{
		Class5.smethod_24(this);
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
