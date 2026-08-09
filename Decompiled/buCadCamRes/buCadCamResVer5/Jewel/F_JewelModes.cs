using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;
using buEyeBaseVer5;
using buMW;
using buMW.CamForms;
using ns8;

namespace buCadCamResVer5.Jewel;

public class F_JewelModes : Form
{
	public JewelMode CurrentModePars = new JewelMode();

	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	private IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	public Button btn_3axwireframe;

	public Button btn_4axwireframe;

	public Button btn_3axwireframerough;

	public Button btn_3axtrimeshrough;

	public Button btn_3axtrimeshparalel;

	public Button btn_3axtrimeshconstantz;

	public Button btn_3axdrill;

	internal Label label_0;

	internal TextBox textBox_0;

	internal TextBox textBox_1;

	internal Label label_1;

	public F_JewelModes()
	{
		Class5.smethod_201(this);
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
		textBox_0.Text = CurrentModePars.Name;
		textBox_1.Text = CurrentModePars.Prepared;
		ControlUpdate();
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		string callMethod = "LoadLanguage";
		try
		{
			if (Captions.Count >= 9)
			{
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	internal void method_0(object sender, FormClosingEventArgs e)
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

	internal void method_1(object sender, EventArgs e)
	{
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Expected O, but got Unknown
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected O, but got Unknown
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Expected O, but got Unknown
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Expected O, but got Unknown
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Expected O, but got Unknown
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Expected O, but got Unknown
		//IL_0367: Unknown result type (might be due to invalid IL or missing references)
		//IL_0371: Expected O, but got Unknown
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_0391: Expected O, but got Unknown
		//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Expected O, but got Unknown
		//IL_0448: Unknown result type (might be due to invalid IL or missing references)
		//IL_0452: Expected O, but got Unknown
		//IL_0469: Unknown result type (might be due to invalid IL or missing references)
		//IL_0473: Expected O, but got Unknown
		//IL_04db: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e5: Expected O, but got Unknown
		//IL_0532: Unknown result type (might be due to invalid IL or missing references)
		//IL_053c: Expected O, but got Unknown
		//IL_0553: Unknown result type (might be due to invalid IL or missing references)
		//IL_055d: Expected O, but got Unknown
		//IL_05c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cf: Expected O, but got Unknown
		//IL_061c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0626: Expected O, but got Unknown
		//IL_063d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0647: Expected O, but got Unknown
		//IL_06af: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b9: Expected O, but got Unknown
		//IL_0706: Unknown result type (might be due to invalid IL or missing references)
		//IL_0710: Expected O, but got Unknown
		//IL_0727: Unknown result type (might be due to invalid IL or missing references)
		//IL_0731: Expected O, but got Unknown
		//IL_0796: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a0: Expected O, but got Unknown
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_ok.Name)
		{
			PropertiesForm.Result = DialogResult.OK;
			Apply();
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == btn_cancel.Name)
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
		if (control.Name == btn_3axwireframe.Name)
		{
			F_WFContour f_WFContour = new F_WFContour();
			f_WFContour.mwCamParameter = new GeoLib(CurrentModePars.varMWCamWFContourPars.Units, 0);
			f_WFContour.mwCamParameter.MachParam = new MachiningParams(CurrentModePars.varMWCamWFContourPars.MachParam);
			buMWCalcs.CopyGeoLibProperties(CurrentModePars.varMWCamWFContourPars, f_WFContour.mwCamParameter);
			f_WFContour.buCamParameter = new camParameters5(CurrentModePars.varbuCamWFContourPars);
			f_WFContour.Init();
			f_WFContour.ShowDialog();
			if (f_WFContour.PropertiesForm.Result == DialogResult.OK)
			{
				CurrentModePars.varMWCamWFContourPars.MachParam = new MachiningParams(f_WFContour.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_WFContour.mwCamParameter, CurrentModePars.varMWCamWFContourPars);
				CurrentModePars.varbuCamWFContourPars = new camParameters5(f_WFContour.buCamParameter);
			}
		}
		if (control.Name == btn_3axwireframerough.Name)
		{
			F_WFRough f_WFRough = new F_WFRough();
			f_WFRough.mwCamParameter = new GeoLib(CurrentModePars.varMWCamWFContourPars.Units, 0);
			f_WFRough.mwCamParameter.MachParam = new MachiningParams(CurrentModePars.varMWCamWFContourPars.MachParam);
			buMWCalcs.CopyGeoLibProperties(CurrentModePars.varMWCamWFContourPars, f_WFRough.mwCamParameter);
			f_WFRough.buCamParameter = new camParameters5(CurrentModePars.varbuCamWFContourPars);
			f_WFRough.Init();
			f_WFRough.ShowDialog();
			if (f_WFRough.PropertiesForm.Result == DialogResult.OK)
			{
				CurrentModePars.varMWCamWFContourPars.MachParam = new MachiningParams(f_WFRough.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_WFRough.mwCamParameter, CurrentModePars.varMWCamWFContourPars);
				CurrentModePars.varbuCamWFContourPars = new camParameters5(f_WFRough.buCamParameter);
			}
		}
		if (control.Name == btn_4axwireframe.Name)
		{
			F_WFContour4AX f_WFContour4AX = new F_WFContour4AX();
			f_WFContour4AX.mwCamParameter = new GeoLib(CurrentModePars.varMWCamWFContour4XPars.Units, 0);
			f_WFContour4AX.mwCamParameter.MachParam = new MachiningParams(CurrentModePars.varMWCamWFContour4XPars.MachParam);
			buMWCalcs.CopyGeoLibProperties(CurrentModePars.varMWCamWFContour4XPars, f_WFContour4AX.mwCamParameter);
			f_WFContour4AX.buCamParameter = new camParameters5(CurrentModePars.varbuCamWFContour4XPars);
			f_WFContour4AX.Init();
			f_WFContour4AX.ShowDialog();
			if (f_WFContour4AX.PropertiesForm.Result == DialogResult.OK)
			{
				CurrentModePars.varMWCamWFContour4XPars.MachParam = new MachiningParams(f_WFContour4AX.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_WFContour4AX.mwCamParameter, CurrentModePars.varMWCamWFContour4XPars);
				CurrentModePars.varbuCamWFContour4XPars = new camParameters5(f_WFContour4AX.buCamParameter);
			}
		}
		if (control.Name == btn_3axtrimeshrough.Name)
		{
			F_TriMeshRough f_TriMeshRough = new F_TriMeshRough();
			f_TriMeshRough.mwCamParameter = new GeoLib(CurrentModePars.varMWCamMeshRoughPars.Units, 0);
			f_TriMeshRough.mwCamParameter.MachParam = new MachiningParams(CurrentModePars.varMWCamMeshRoughPars.MachParam);
			buMWCalcs.CopyGeoLibProperties(CurrentModePars.varMWCamMeshRoughPars, f_TriMeshRough.mwCamParameter);
			f_TriMeshRough.buCamParameter = new camParameters5(CurrentModePars.varbuCamMeshRoughPars);
			f_TriMeshRough.Init();
			f_TriMeshRough.ShowDialog();
			if (f_TriMeshRough.PropertiesForm.Result == DialogResult.OK)
			{
				CurrentModePars.varMWCamMeshRoughPars.MachParam = new MachiningParams(f_TriMeshRough.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_TriMeshRough.mwCamParameter, CurrentModePars.varMWCamMeshRoughPars);
				CurrentModePars.varbuCamMeshRoughPars = new camParameters5(f_TriMeshRough.buCamParameter);
			}
		}
		if (control.Name == btn_3axtrimeshparalel.Name)
		{
			F_TriMeshParallelCut f_TriMeshParallelCut = new F_TriMeshParallelCut();
			f_TriMeshParallelCut.mwCamParameter = new GeoLib(CurrentModePars.varMWCamMeshParalelPars.Units, 0);
			f_TriMeshParallelCut.mwCamParameter.MachParam = new MachiningParams(CurrentModePars.varMWCamMeshParalelPars.MachParam);
			buMWCalcs.CopyGeoLibProperties(CurrentModePars.varMWCamMeshParalelPars, f_TriMeshParallelCut.mwCamParameter);
			f_TriMeshParallelCut.buCamParameter = new camParameters5(CurrentModePars.varbuCamMeshParallelPars);
			f_TriMeshParallelCut.Init();
			f_TriMeshParallelCut.ShowDialog();
			if (f_TriMeshParallelCut.PropertiesForm.Result == DialogResult.OK)
			{
				CurrentModePars.varMWCamMeshParalelPars.MachParam = new MachiningParams(f_TriMeshParallelCut.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_TriMeshParallelCut.mwCamParameter, CurrentModePars.varMWCamMeshParalelPars);
				CurrentModePars.varbuCamMeshParallelPars = new camParameters5(f_TriMeshParallelCut.buCamParameter);
			}
		}
		if (control.Name == btn_3axtrimeshconstantz.Name)
		{
			F_TriMeshParallelCut f_TriMeshParallelCut2 = new F_TriMeshParallelCut();
			f_TriMeshParallelCut2.mwCamParameter = new GeoLib(CurrentModePars.varMWCamMeshContantZPars.Units, 0);
			f_TriMeshParallelCut2.mwCamParameter.MachParam = new MachiningParams(CurrentModePars.varMWCamMeshContantZPars.MachParam);
			buMWCalcs.CopyGeoLibProperties(CurrentModePars.varMWCamMeshContantZPars, f_TriMeshParallelCut2.mwCamParameter);
			f_TriMeshParallelCut2.buCamParameter = new camParameters5(CurrentModePars.varbuCamMeshConstantZPars);
			f_TriMeshParallelCut2.Init();
			f_TriMeshParallelCut2.ShowDialog();
			if (f_TriMeshParallelCut2.PropertiesForm.Result == DialogResult.OK)
			{
				CurrentModePars.varMWCamMeshContantZPars.MachParam = new MachiningParams(f_TriMeshParallelCut2.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_TriMeshParallelCut2.mwCamParameter, CurrentModePars.varMWCamMeshContantZPars);
				CurrentModePars.varbuCamMeshConstantZPars = new camParameters5(f_TriMeshParallelCut2.buCamParameter);
			}
		}
		if (control.Name == btn_3axdrill.Name)
		{
			F_DrillLine f_DrillLine = new F_DrillLine();
			f_DrillLine.mwCamParameter = new GeoLib(CurrentModePars.varMWCamDrillPars.Units, 0);
			f_DrillLine.mwCamParameter.MachParam = new MachiningParams(CurrentModePars.varMWCamDrillPars.MachParam);
			buMWCalcs.CopyGeoLibProperties(CurrentModePars.varMWCamDrillPars, f_DrillLine.mwCamParameter);
			f_DrillLine.buCamParameter = new camParameters5(CurrentModePars.varbuCamDrillPars);
			f_DrillLine.Init();
			f_DrillLine.ShowDialog();
			if (f_DrillLine.PropertiesForm.Result == DialogResult.OK)
			{
				CurrentModePars.varMWCamDrillPars.MachParam = new MachiningParams(f_DrillLine.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_DrillLine.mwCamParameter, CurrentModePars.varMWCamDrillPars);
				CurrentModePars.varbuCamDrillPars = new camParameters5(f_DrillLine.buCamParameter);
			}
		}
	}

	public void ControlUpdate()
	{
	}

	public void Apply()
	{
		CurrentModePars.Name = textBox_0.Text;
		CurrentModePars.Prepared = textBox_1.Text;
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
