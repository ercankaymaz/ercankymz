using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ns71;

namespace buEyeBaseVer5.Forms.Profile;

public class F_ProfileCopy : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public ProfileOperationData OperationData = new ProfileOperationData();

	public List<SelectedPlaneInfo> selectedPlanes = new List<SelectedPlaneInfo>();

	public ProfileItem Profile = new ProfileItem();

	public bool ShowCount = true;

	public bool UseOriginalPlane = false;

	public int Count = 1;

	public double DistanceHor = 0.0;

	public double DistanceVer = 0.0;

	public bool UseDistance = false;

	internal IContainer icontainer_0 = null;

	public Panel panel4;

	public Label label4;

	public NumericUpDown spn_x;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	public Label label1;

	public NumericUpDown spn_y;

	public Button btn_planebottom;

	public Button btn_planeselect;

	public Button btn_planefree;

	public Button btn_planeback;

	public Button btn_planefront;

	public Button btn_planetop;

	public Label label7;

	public Label label6;

	public Label label5;

	public Label label3;

	public Label label2;

	internal CheckBox checkBox_0;

	public Label lbl_count;

	public NumericUpDown spn_count;

	public Label lbl_Distancehor;

	public NumericUpDown spn_distancehor;

	public Label lbl_Distancever;

	public NumericUpDown spn_distancever;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	public F_ProfileCopy()
	{
		Class186.smethod_378(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		if (Properties.Height > 10)
		{
			base.Height = Properties.Height;
		}
		if (Properties.Width > 10)
		{
			base.Width = Properties.Width;
		}
		base.TopMost = Properties.TopMost;
		base.StartPosition = Properties.FormPosition;
		if (!((OperationData.selectedPlaneName == planeNames.Top) | (OperationData.selectedPlaneName == planeNames.Bottom) | (OperationData.selectedPlaneName == planeNames.Free)))
		{
			spn_x.Value = (decimal)OperationData.basePosition.X;
			spn_y.Value = Math.Abs((decimal)OperationData.basePosition.Z);
		}
		else
		{
			spn_x.Value = (decimal)OperationData.basePosition.X;
			spn_y.Value = Math.Abs((decimal)OperationData.basePosition.Y);
		}
		spn_count.Value = Count;
		spn_distancehor.Value = (decimal)DistanceHor;
		spn_distancever.Value = (decimal)DistanceVer;
		if (!UseDistance)
		{
			radioButton_0.Checked = false;
			radioButton_1.Checked = true;
		}
		else
		{
			radioButton_0.Checked = true;
			radioButton_1.Checked = false;
		}
		btn_planetop.BackColor = Color.Gainsboro;
		btn_planebottom.BackColor = Color.Gainsboro;
		btn_planeback.BackColor = Color.Gainsboro;
		btn_planefront.BackColor = Color.Gainsboro;
		btn_planefree.BackColor = Color.Gainsboro;
		lbl_count.Visible = ShowCount;
		spn_count.Visible = ShowCount;
		if (OperationData.selectedPlaneName == planeNames.Top)
		{
			btn_planetop.BackColor = Color.Gold;
		}
		if (OperationData.selectedPlaneName == planeNames.Bottom)
		{
			btn_planebottom.BackColor = Color.Gold;
		}
		if (OperationData.selectedPlaneName == planeNames.Front)
		{
			btn_planefront.BackColor = Color.Gold;
		}
		if (OperationData.selectedPlaneName == planeNames.Back)
		{
			btn_planeback.BackColor = Color.Gold;
		}
		if (OperationData.selectedPlaneName == planeNames.Free)
		{
			btn_planefree.BackColor = Color.Gold;
		}
		checkBox_0.Checked = UseOriginalPlane;
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		LoadLangueage();
	}

	public void LoadLangueage()
	{
		string callMethod = "ToolDetailed LoadLanguage";
		try
		{
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

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_ok.Name)
		{
			if (!Properties.Inited)
			{
				return;
			}
			if (Properties.ReadOnly)
			{
				Dispose();
				return;
			}
			Class186.smethod_86(this);
			if ((OperationData.selectedPlaneName == planeNames.Top) | (OperationData.selectedPlaneName == planeNames.Bottom))
			{
				OperationData.Position.Y = 0.0 - Math.Abs(OperationData.Position.Y);
			}
			Properties.Result = DialogResult.OK;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == btn_cancel.Name)
		{
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
		if ((control.Name == btn_planetop.Name) | (control.Name == btn_planebottom.Name) | (control.Name == btn_planeback.Name) | (control.Name == btn_planefront.Name) | (control.Name == btn_planefree.Name))
		{
			btn_planetop.BackColor = Color.Gainsboro;
			btn_planebottom.BackColor = Color.Gainsboro;
			btn_planeback.BackColor = Color.Gainsboro;
			btn_planefront.BackColor = Color.Gainsboro;
			btn_planefree.BackColor = Color.Gainsboro;
		}
		if (control.Name == btn_planetop.Name)
		{
			OperationData.selectedPlaneName = planeNames.Top;
			btn_planetop.BackColor = Color.Gold;
		}
		if (control.Name == btn_planebottom.Name)
		{
			OperationData.selectedPlaneName = planeNames.Bottom;
			btn_planebottom.BackColor = Color.Gold;
		}
		if (control.Name == btn_planeback.Name)
		{
			OperationData.selectedPlaneName = planeNames.Back;
			btn_planeback.BackColor = Color.Gold;
		}
		if (control.Name == btn_planefront.Name)
		{
			OperationData.selectedPlaneName = planeNames.Front;
			btn_planefront.BackColor = Color.Gold;
		}
		if (control.Name == btn_planefree.Name)
		{
			OperationData.selectedPlaneName = planeNames.Free;
			btn_planefree.BackColor = Color.Gold;
		}
		if (!(control.Name == btn_planeselect.Name))
		{
			return;
		}
		F_SelectedPlanes f_SelectedPlanes = new F_SelectedPlanes();
		for (int i = 0; i <= selectedPlanes.Count - 1; i++)
		{
			f_SelectedPlanes.Planes.Add(new SelectedPlaneInfo(selectedPlanes[i]));
		}
		for (int j = 0; j <= Profile.Drawings.Count - 1; j++)
		{
			if (Profile.Drawings[j].SolidEntity != null)
			{
				Entity entity = buVector5.CopyEntities(Profile.Drawings[j].SolidEntity);
				entity.ColorMethod = colorMethodType.byEntity;
				entity.Color = Color.FromArgb(180, Profile.colorProfile);
				entity.LayerName = "Default";
				f_SelectedPlanes.PreviewEnts.Add(entity);
			}
		}
		if (Profile.Operations.Count > 0)
		{
			for (int k = 0; k <= Profile.Operations.Count - 1; k++)
			{
				for (int l = 0; l <= Profile.Operations[k].EntityMultiSolidDepth.Count - 1; l++)
				{
					Entity copiedEnt = null;
					buVector5.CopyEntities(Profile.Operations[k].EntityMultiSolidDepth[l], ref copiedEnt);
					copiedEnt.ColorMethod = colorMethodType.byEntity;
					copiedEnt.Color = Color.Cyan;
					copiedEnt.LayerName = "Default";
					f_SelectedPlanes.PreviewEnts.Add(copiedEnt);
				}
			}
		}
		f_SelectedPlanes.Init();
		f_SelectedPlanes.TopMost = true;
		f_SelectedPlanes.ShowDialog();
		if (f_SelectedPlanes.PropertiesForm.Result == DialogResult.OK)
		{
			selectedPlanes.Clear();
			selectedPlanes = new List<SelectedPlaneInfo>();
			for (int m = 0; m <= f_SelectedPlanes.Planes.Count - 1; m++)
			{
				selectedPlanes.Add(new SelectedPlaneInfo(f_SelectedPlanes.Planes[m]));
			}
			if (f_SelectedPlanes.Planes.Count > 0 && f_SelectedPlanes.SelectedPlane >= 0)
			{
				SelectedPlaneInfo item = new SelectedPlaneInfo(f_SelectedPlanes.Planes[f_SelectedPlanes.SelectedPlane]);
				Profile.selectedFreePlanes.Clear();
				Profile.selectedFreePlanes.Add(item);
				OperationData.selectedPlane = (Plane)Profile.selectedFreePlanes[0].refPlane.Clone();
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
