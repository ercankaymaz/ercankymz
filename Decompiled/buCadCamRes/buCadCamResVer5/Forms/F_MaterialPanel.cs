using System.ComponentModel;
using System.Windows.Forms;
using ns8;

namespace buCadCamResVer5.Forms;

public class F_MaterialPanel : Form
{
	private IContainer icontainer_0 = null;

	public TextBox txt_notes;

	public Panel pnl_controls;

	public Panel pnl_materials;

	public Panel pnl_cmd;

	public TreeView tree_mats;

	internal ImageList imageList_0;

	public TextBox txt_materialexplanatiom;

	public ToolTip toolTip1;

	internal ImageList imageList_1;

	public Button btn_remove;

	public Button btn_add;

	public Button btn_down;

	public Button btn_copy;

	public Button btn_properties;

	public Button btn_up;

	public Label lbl_materials;

	public Label lbl_notes;

	public F_MaterialPanel()
	{
		Class5.smethod_98(this);
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
