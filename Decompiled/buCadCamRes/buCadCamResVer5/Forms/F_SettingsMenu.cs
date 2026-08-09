using System;
using System.ComponentModel;
using System.Windows.Forms;
using buControls.ClassViewer;
using buEyeBaseVer5;
using ns8;

namespace buCadCamResVer5.Forms;

public class F_SettingsMenu : Form
{
	private IContainer icontainer_0 = null;

	internal Button button_0;

	internal Button button_1;

	internal ImageList imageList_0;

	internal Button button_2;

	internal Button button_3;

	public F_SettingsMenu()
	{
		Class5.smethod_136(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_1.Name)
		{
			F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
			f_ClassViewerDialog.Text = "Analyse";
			f_ClassViewerDialog.Value = clsVar.varInterface5.AnalyseEntitySetting;
			f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
			f_ClassViewerDialog.Width = 500;
			f_ClassViewerDialog.Height = 600;
			f_ClassViewerDialog.ValuePersentage = 35.0;
			f_ClassViewerDialog.Init();
			f_ClassViewerDialog.ShowDialog();
			if (f_ClassViewerDialog.Result == DialogResult.OK)
			{
				clsVar.varInterface5.AnalyseEntitySetting = new AnalyseEntitiesSetting((AnalyseEntitiesSetting)f_ClassViewerDialog.Value);
				clsFiles.SaveParameter();
			}
		}
		if (control.Name == button_2.Name)
		{
			F_ClassViewerDialog f_ClassViewerDialog2 = new F_ClassViewerDialog();
			f_ClassViewerDialog2.Text = "Arrow";
			f_ClassViewerDialog2.Value = clsVar.varInterface5.DirectionArrowSettings;
			f_ClassViewerDialog2.StartPosition = FormStartPosition.CenterParent;
			f_ClassViewerDialog2.Width = 500;
			f_ClassViewerDialog2.Height = 600;
			f_ClassViewerDialog2.ValuePersentage = 35.0;
			f_ClassViewerDialog2.Init();
			f_ClassViewerDialog2.ShowDialog();
			if (f_ClassViewerDialog2.Result == DialogResult.OK)
			{
				clsVar.varInterface5.DirectionArrowSettings = new DirectionArrowSetting((DirectionArrowSetting)f_ClassViewerDialog2.Value);
				clsFiles.SaveParameter();
			}
		}
		if (control.Name == button_3.Name)
		{
			F_ClassViewerDialog f_ClassViewerDialog3 = new F_ClassViewerDialog();
			f_ClassViewerDialog3.Text = "Arrow";
			f_ClassViewerDialog3.Value = clsVar.varInterface5.FlatViewSettings;
			f_ClassViewerDialog3.StartPosition = FormStartPosition.CenterParent;
			f_ClassViewerDialog3.Width = 500;
			f_ClassViewerDialog3.Height = 600;
			f_ClassViewerDialog3.ValuePersentage = 35.0;
			f_ClassViewerDialog3.Init();
			f_ClassViewerDialog3.ShowDialog();
			if (f_ClassViewerDialog3.Result == DialogResult.OK)
			{
				clsVar.varInterface5.FlatViewSettings = new FlatViewSettings((FlatViewSettings)f_ClassViewerDialog3.Value);
				clsFiles.SaveParameter();
			}
		}
		if (control.Name == button_0.Name)
		{
			base.Visible = false;
		}
	}

	internal void method_1(object sender, FormClosingEventArgs e)
	{
		e.Cancel = true;
		base.Visible = false;
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
