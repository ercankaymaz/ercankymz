using System.ComponentModel;
using System.Windows.Forms;
using ns8;

namespace buCadCamResVer5.Forms;

public class F_MiscPanel : Form
{
	internal IContainer icontainer_0 = null;

	public TextBox txt_notes;

	public Panel pnl_controls;

	internal ImageList imageList_0;

	public ToolTip toolTip1;

	internal ImageList imageList_1;

	internal Label label_0;

	public Panel pnl_viewport;

	public F_MiscPanel()
	{
		Class5.smethod_170(this);
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
