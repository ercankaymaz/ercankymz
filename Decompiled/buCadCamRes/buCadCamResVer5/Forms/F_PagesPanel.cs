using System.ComponentModel;
using System.Windows.Forms;
using ns8;

namespace buCadCamResVer5.Forms;

public class F_PagesPanel : Form
{
	internal IContainer icontainer_0 = null;

	public TreeView tree_pages;

	internal ImageList imageList_0;

	public Panel pnl_controls;

	public Panel pnl_cmd;

	public TextBox txt_pageexplanatiom;

	internal ImageList imageList_1;

	public Button btn_setplane;

	public Button btn_addpage;

	public Button btn_addscene;

	public Button btn_preview;

	public Label lbl_pages;

	public F_PagesPanel()
	{
		Class5.smethod_181(this);
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
