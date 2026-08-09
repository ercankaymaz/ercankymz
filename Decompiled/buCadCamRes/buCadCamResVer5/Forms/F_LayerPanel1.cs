using System.ComponentModel;
using System.Windows.Forms;
using ns8;

namespace buCadCamResVer5.Forms;

public class F_LayerPanel1 : Form
{
	private IContainer icontainer_0 = null;

	public DataGridView DGV_layer;

	public Panel pnl_controls;

	public TextBox txt_layerexplanatiom;

	public Panel pnl_cmd;

	internal ImageList imageList_0;

	public Button btn_down;

	public Button btn_add;

	public Button btn_up;

	public Button btn_remove;

	public Button btn_copy;

	public Button btn_properties;

	public Label lbl_layers;

	public F_LayerPanel1()
	{
		Class5.smethod_143(this);
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
