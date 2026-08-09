using System;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5;
using devDept.Eyeshot.Control;
using ns8;

namespace buCadCamResVer5.Profile;

public class F_ProfileERPList : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public string pathString = Application.StartupPath;

	public Design viewportPort = null;

	public int SelectedJob = -1;

	public bool isLeftHolder = true;

	private Timer timer_0 = new Timer();

	private IContainer icontainer_0 = null;

	internal Button button_0;

	internal Button button_1;

	internal ImageList imageList_0;

	internal ImageList imageList_1;

	internal Button button_2;

	internal Button button_3;

	internal Button button_4;

	public ListBox lst_items;

	public Panel pnl_viewport;

	internal Button button_5;

	internal Button button_6;

	internal Button button_7;

	internal Button button_8;

	internal Button button_9;

	internal Button button_10;

	internal Button button_11;

	internal Button button_12;

	internal Button button_13;

	internal Button button_14;

	internal Button button_15;

	internal Button button_16;

	internal Button button_17;

	public CheckBox chk_deleteloaded;

	public RadioButton radio_leftholder;

	public RadioButton radio_rightholder;

	internal Button button_18;

	public F_ProfileERPList()
	{
		Class5.smethod_156(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			base.Height = PropertiesForm.Height;
		}
		if (PropertiesForm.Width > 10)
		{
			base.Width = PropertiesForm.Width;
		}
		base.TopMost = PropertiesForm.TopMost;
		base.StartPosition = PropertiesForm.FormPosition;
		if (!isLeftHolder)
		{
			radio_leftholder.Checked = false;
			radio_rightholder.Checked = true;
		}
		else
		{
			radio_leftholder.Checked = true;
			radio_rightholder.Checked = false;
		}
		timer_0.Tick += timer_0_Tick;
		timer_0.Interval = 100;
		timer_0.Enabled = true;
		Class5.smethod_142(this);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	internal void method_0(object sender, EventArgs e)
	{
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		timer_0.Enabled = false;
	}

	internal void method_1(object sender, EventArgs e)
	{
		PropertiesForm.Inited = false;
		clsInit.appProfile.doJobListChanged(lst_items.SelectedIndex);
		SelectedJob = lst_items.SelectedIndex;
		PropertiesForm.Inited = true;
	}

	internal void method_2(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_0.Name)
		{
			if (radio_leftholder.Checked)
			{
				isLeftHolder = true;
			}
			if (radio_rightholder.Checked)
			{
				isLeftHolder = false;
			}
			PropertiesForm.Result = DialogResult.OK;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == button_1.Name)
		{
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == button_2.Name)
		{
			clsInit.appProfile.doJobListDelete(lst_items.SelectedIndex);
		}
		if (control.Name == button_18.Name)
		{
			clsInit.appProfile.doJobListDeleteAll();
		}
		if (control.Name == button_3.Name)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = pathString;
			openFileDialog.Filter = "Profile List (*.profilelist)|*.profilelist";
			openFileDialog.FilterIndex = 1;
			openFileDialog.Multiselect = false;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				pathString = buFile5.GetPath(openFileDialog.FileName);
				clsInit.appProfile.doJobListOpen(openFileDialog.FileName);
			}
		}
		if (control.Name == button_4.Name)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = pathString;
			saveFileDialog.Filter = "Profile List (*.profilelist)|*.profilelist";
			saveFileDialog.FilterIndex = 1;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				pathString = buFile5.GetPath(saveFileDialog.FileName);
				clsInit.appProfile.doJobListSave(saveFileDialog.FileName);
			}
		}
		if (control.Name == button_12.Name)
		{
			buEyeShotFunctions.ViewZoomIn(ref viewportPort);
		}
		if (control.Name == button_14.Name)
		{
			buEyeShotFunctions.ViewZoomNormal(ref viewportPort);
		}
		if (control.Name == button_11.Name)
		{
			buEyeShotFunctions.ViewZoomOut(ref viewportPort);
		}
		if (control.Name == button_15.Name)
		{
			buEyeShotFunctions.ViewZoomWindow(ref viewportPort);
		}
		if (control.Name == button_5.Name)
		{
			buEyeShotFunctions.ViewTop(ref viewportPort, isZoomFit: true);
		}
		if (control.Name == button_6.Name)
		{
			buEyeShotFunctions.ViewBottom(ref viewportPort, isZoomFit: true);
		}
		if (control.Name == button_7.Name)
		{
			buEyeShotFunctions.Viewfront(ref viewportPort, isZoomFit: true);
		}
		if (control.Name == button_10.Name)
		{
			buEyeShotFunctions.ViewBack(ref viewportPort, isZoomFit: true);
		}
		if (control.Name == button_8.Name)
		{
			buEyeShotFunctions.ViewRight(ref viewportPort, isZoomFit: true);
		}
		if (control.Name == button_9.Name)
		{
			buEyeShotFunctions.ViewLeft(ref viewportPort, isZoomFit: true);
		}
		if (control.Name == button_13.Name)
		{
			buEyeShotFunctions.ViewProfile(ref viewportPort, isZoomFit: true);
		}
		if (control.Name == button_16.Name)
		{
			buEyeShotFunctions.ViewRotate(ref viewportPort);
		}
		if (control.Name == button_17.Name)
		{
			buEyeShotFunctions.ViewPan(ref viewportPort);
		}
	}

	internal void method_3(object sender, FormClosingEventArgs e)
	{
		if (PropertiesForm.Result != DialogResult.OK)
		{
			e.Cancel = true;
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
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
