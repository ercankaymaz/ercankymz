using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Views;

public class F_GifView : Form
{
	public FormProperties Properties = new FormProperties();

	public Image refImage = null;

	private PictureBoxSizeMode pictureBoxSizeMode_0 = PictureBoxSizeMode.Zoom;

	private IContainer icontainer_0 = null;

	public PictureBox pic_view;

	public F_GifView()
	{
		Class76.smethod_740(this);
	}

	public void Init()
	{
		pic_view.Image = refImage;
		pic_view.SizeMode = pictureBoxSizeMode_0;
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (Properties.Result != DialogResult.OK)
		{
			e.Cancel = true;
			Properties.Result = DialogResult.Cancel;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
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
