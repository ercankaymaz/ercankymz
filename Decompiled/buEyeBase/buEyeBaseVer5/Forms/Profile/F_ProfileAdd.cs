using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using buControls.ClassViewer;
using buControls.DialogBox;
using buCore;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using ns71;

namespace buEyeBaseVer5.Forms.Profile;

public class F_ProfileAdd : Form
{
	public F_NewProfile FrmNewProfile = null;

	public FormProperties PropertiesForm = new FormProperties();

	public List<buEntity> EntitiesTransformed = new List<buEntity>();

	public List<LayerBase5> Layers = new List<LayerBase5>();

	public List<MaterialSkin> Materials = new List<MaterialSkin>();

	public int MaterialIndex = 0;

	public bool RigthProfile = false;

	public bool BoxProfile = false;

	public buEyeBaseVer5.Apps.ProfileItem Profile = new buEyeBaseVer5.Apps.ProfileItem();

	public buEyeBaseVer5.Apps.ProfileSettings ProfileSet = new buEyeBaseVer5.Apps.ProfileSettings();

	public buEyeBaseVer5.Apps.ProfileRuntimeSettings ProfileRunTimeSet = new buEyeBaseVer5.Apps.ProfileRuntimeSettings();

	public string strDelete = "Do You Want to Delete This File";

	internal Design design_0 = null;

	private List<string> list_0 = new List<string>();

	[CompilerGenerated]
	private OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler_0;

	private int int_0 = -1;

	private int int_1 = -1;

	private string string_0 = "";

	internal Point3D point3D_0 = new Point3D();

	internal Point3D point3D_1 = new Point3D();

	internal Point3D point3D_2 = new Point3D();

	internal List<string> list_1 = new List<string>();

	private System.Windows.Forms.Timer timer_0 = null;

	private buEyeBaseVer5.Apps.ProfileItem profileItem_0 = null;

	internal IContainer icontainer_0 = null;

	internal TextBox textBox_0;

	internal Label label_0;

	internal Panel panel_0;

	internal Label label_1;

	internal Panel panel_1;

	internal Button button_0;

	internal ImageList imageList_0;

	internal Button button_1;

	internal Button button_2;

	internal Panel panel_2;

	internal Label label_2;

	internal Button button_3;

	internal Button button_4;

	internal Button button_5;

	internal Button button_6;

	internal NumericUpDown numericUpDown_0;

	internal Button button_7;

	internal Label label_3;

	internal ComboBox comboBox_0;

	internal Label label_4;

	internal ComboBox comboBox_1;

	internal Label label_5;

	internal TextBox textBox_1;

	internal Label label_6;

	internal Label label_7;

	internal Label label_8;

	internal TextBox textBox_2;

	internal NumericUpDown numericUpDown_1;

	internal Label label_9;

	internal NumericUpDown numericUpDown_2;

	internal Label label_10;

	internal Label label_11;

	internal NumericUpDown numericUpDown_3;

	internal Label label_12;

	internal Button button_8;

	internal Label label_13;

	internal NumericUpDown numericUpDown_4;

	internal Label label_14;

	internal NumericUpDown numericUpDown_5;

	internal NumericUpDown numericUpDown_6;

	internal Label label_15;

	internal NumericUpDown numericUpDown_7;

	internal Label label_16;

	internal Label label_17;

	public DataGridView grid_files;

	internal Panel panel_3;

	internal CheckBox checkBox_0;

	internal Label label_18;

	internal NumericUpDown numericUpDown_8;

	internal NumericUpDown numericUpDown_9;

	internal NumericUpDown numericUpDown_10;

	internal Label label_19;

	internal CheckBox checkBox_1;

	internal NumericUpDown numericUpDown_11;

	internal Label label_20;

	internal NumericUpDown numericUpDown_12;

	internal Label label_21;

	internal Panel panel_4;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal Button button_9;

	internal Button button_10;

	internal Button button_11;

	internal Button button_12;

	internal PictureBox pictureBox_0;

	internal PictureBox pictureBox_1;

	internal CheckBox checkBox_2;

	internal NumericUpDown numericUpDown_13;

	internal Label label_22;

	internal NumericUpDown numericUpDown_14;

	internal Label label_23;

	internal CheckBox checkBox_3;

	internal PictureBox pictureBox_2;

	internal TextBox textBox_3;

	internal PictureBox pictureBox_3;

	public event OkCommandWithTwoDataEventHandler EditDxf
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler = okCommandWithTwoDataEventHandler_0;
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler2;
			do
			{
				okCommandWithTwoDataEventHandler2 = okCommandWithTwoDataEventHandler;
				OkCommandWithTwoDataEventHandler value2 = (OkCommandWithTwoDataEventHandler)Delegate.Combine(okCommandWithTwoDataEventHandler2, value);
				okCommandWithTwoDataEventHandler = Interlocked.CompareExchange(ref okCommandWithTwoDataEventHandler_0, value2, okCommandWithTwoDataEventHandler2);
			}
			while ((object)okCommandWithTwoDataEventHandler != okCommandWithTwoDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler = okCommandWithTwoDataEventHandler_0;
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler2;
			do
			{
				okCommandWithTwoDataEventHandler2 = okCommandWithTwoDataEventHandler;
				OkCommandWithTwoDataEventHandler value2 = (OkCommandWithTwoDataEventHandler)Delegate.Remove(okCommandWithTwoDataEventHandler2, value);
				okCommandWithTwoDataEventHandler = Interlocked.CompareExchange(ref okCommandWithTwoDataEventHandler_0, value2, okCommandWithTwoDataEventHandler2);
			}
			while ((object)okCommandWithTwoDataEventHandler != okCommandWithTwoDataEventHandler2);
		}
	}

	public F_ProfileAdd()
	{
		Class186.smethod_345(this);
	}

	public void Init(buEyeBaseVer5.Apps.ProfileItem Item, bool boxprofile = false)
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
		profileItem_0 = Item;
		BoxProfile = boxprofile;
		if (design_0 == null)
		{
			EyeCreateProps eyeCreateProps = new EyeCreateProps();
			eyeCreateProps.ShowToolBar = false;
			eyeCreateProps.ShowViewCube = true;
			eyeCreateProps.ShowCoordinateArrow = false;
			buEyeShotFunctions.CreateControlsTool(FirstCreate: true, eyeCreateProps, ref design_0);
			design_0.Dock = DockStyle.Fill;
			panel_3.Controls.Add(design_0);
		}
		design_0.ActiveViewport.ViewCubeIcon.Visible = false;
		if (!RigthProfile)
		{
			ProfileSet.XDirRefType = LeftRightType.Left;
		}
		radioButton_0.Enabled = RigthProfile;
		grid_files.AllowUserToAddRows = false;
		grid_files.AllowUserToDeleteRows = false;
		grid_files.AllowUserToResizeRows = false;
		grid_files.RowHeadersVisible = false;
		grid_files.Columns.Clear();
		grid_files.Rows.Clear();
		grid_files.Columns.Clear();
		DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
		dataGridViewColumn.Width = 60;
		dataGridViewColumn.HeaderText = "No";
		dataGridViewColumn.Name = "No";
		dataGridViewColumn.ReadOnly = true;
		dataGridViewColumn.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
		dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
		grid_files.Columns.Add(dataGridViewColumn);
		DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
		dataGridViewColumn2.Width = 250;
		dataGridViewColumn2.HeaderText = "FileName";
		dataGridViewColumn2.Name = "FileName";
		dataGridViewColumn2.ReadOnly = true;
		dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
		dataGridViewColumn2.CellTemplate = new DataGridViewTextBoxCell();
		grid_files.Columns.Add(dataGridViewColumn2);
		numericUpDown_6.ReadOnly = ProfileSet.ProfileAddWidthHeightReadOnly;
		numericUpDown_5.ReadOnly = ProfileSet.ProfileAddWidthHeightReadOnly;
		numericUpDown_1.Value = ProfileSet.MaterialTranspancy;
		label_17.BackColor = ProfileSet.ProfileColor;
		label_16.BackColor = ProfileSet.SupportBlockZColor;
		textBox_1.Text = "Item";
		checkBox_1.Checked = ProfileRunTimeSet.ProfileKeepRatio;
		if (Item != null)
		{
			numericUpDown_14.Value = Item.MultiplyProfile.ProfileMultiplyCount;
			numericUpDown_13.Value = (decimal)Item.MultiplyProfile.ProfileMultiplySpace;
			checkBox_2.Checked = Item.MultiplyProfile.ProfileMultiplyMirror;
			checkBox_3.Checked = Item.MultiplyProfile.ProfileMultiplyEnable;
		}
		comboBox_1.Items.Clear();
		comboBox_1.Items.Add(100);
		comboBox_1.Items.Add(500);
		comboBox_1.Items.Add(800);
		comboBox_1.Items.Add(1000);
		comboBox_1.Items.Add(1200);
		comboBox_1.Items.Add(1500);
		comboBox_1.Items.Add(2000);
		comboBox_1.Items.Add(3000);
		comboBox_1.Items.Add(4000);
		comboBox_1.Items.Add(5000);
		comboBox_1.Items.Add(6000);
		comboBox_1.Text = ProfileRunTimeSet.ProfileLength.ToString();
		comboBox_0.Items.Clear();
		checkBox_0.Checked = ProfileRunTimeSet.TextureEnable;
		for (int i = 0; i <= Materials.Count - 1; i++)
		{
			comboBox_0.Items.Add(Materials[i].Name);
		}
		if ((MaterialIndex >= 0) & (MaterialIndex <= comboBox_0.Items.Count - 1))
		{
			comboBox_0.SelectedIndex = MaterialIndex;
		}
		numericUpDown_2.Value = (decimal)ProfileRunTimeSet.SupportBlockY1Height;
		numericUpDown_4.Value = (decimal)ProfileRunTimeSet.SupportBlockY2Height;
		numericUpDown_3.Value = (decimal)ProfileRunTimeSet.SupportBlockZHeight;
		numericUpDown_10.Value = (decimal)ProfileRunTimeSet.SupportBlockY1Width;
		numericUpDown_8.Value = (decimal)ProfileRunTimeSet.SupportBlockY2Width;
		numericUpDown_9.Value = (decimal)ProfileRunTimeSet.SupportBlockZWidth;
		numericUpDown_7.Value = ProfileSet.ProfileMaxClamper;
		numericUpDown_12.Value = (decimal)ProfileRunTimeSet.LeftAngle;
		numericUpDown_11.Value = (decimal)ProfileRunTimeSet.RigthAngle;
		ProfileRunTimeSet.AnalyseSettings.SmallGapMaxDistance = ProfileSet.GapConnectionForProfile;
		ProfileRunTimeSet.AnalyseSettings.SmallGapMinDistance = ProfileSet.ProfileSortResolution;
		if (ProfileSet.XDirRefType != LeftRightType.Left)
		{
			radioButton_1.Checked = false;
			radioButton_0.Checked = true;
		}
		else
		{
			radioButton_1.Checked = true;
			radioButton_0.Checked = false;
		}
		list_1 = new List<string>();
		List<string> Files = new List<string>();
		buFile.GetFilesInDirectory(ProfileRunTimeSet.pathProfiles, ".dxf", ref Files);
		for (int j = 0; j <= Files.Count - 1; j++)
		{
			list_1.Add(Files[j]);
		}
		Files = new List<string>();
		buFile.GetFilesInDirectory(ProfileRunTimeSet.pathProfiles, ".bucad", ref Files);
		for (int k = 0; k <= Files.Count - 1; k++)
		{
			list_1.Add(Files[k]);
		}
		numericUpDown_12.Value = 0m;
		numericUpDown_11.Value = 0m;
		Class186.smethod_540(this);
		if (Item != null)
		{
			numericUpDown_2.Value = (decimal)Item.SupportBlock.SupportBlockY1FrontHeight;
			numericUpDown_4.Value = (decimal)Item.SupportBlock.SupportBlockY2BackHeight;
			numericUpDown_3.Value = (decimal)Item.SupportBlock.SupportBlockZHeight;
			numericUpDown_10.Value = (decimal)Item.SupportBlock.SupportBlockY2BackHeight;
			numericUpDown_8.Value = (decimal)Item.SupportBlock.SupportBlockY2BackWidth;
			numericUpDown_9.Value = (decimal)Item.SupportBlock.SupportBlockZWidth;
			numericUpDown_7.Value = Item.MaxClamperNumber;
			textBox_1.Text = Item.ItemName;
			comboBox_1.Text = Item.Length.ToString();
			label_17.BackColor = Item.colorProfile;
			label_16.BackColor = Item.colorSupportBlock;
			numericUpDown_12.Value = (decimal)Item.LeftAngle;
			numericUpDown_11.Value = (decimal)Item.RightAngle;
			ProfileRunTimeSet.SupportBlockY1Height = Item.SupportBlock.SupportBlockY1FrontHeight;
			ProfileRunTimeSet.SupportBlockY2Height = Item.SupportBlock.SupportBlockY2BackHeight;
			ProfileRunTimeSet.SupportBlockZHeight = Item.SupportBlock.SupportBlockZHeight;
			ProfileRunTimeSet.SupportBlockY1Width = Item.SupportBlock.SupportBlockY1FrontWidth;
			ProfileRunTimeSet.SupportBlockY2Width = Item.SupportBlock.SupportBlockY2BackWidth;
			ProfileRunTimeSet.SupportBlockZWidth = Item.SupportBlock.SupportBlockZWidth;
			ProfileRunTimeSet.LeftAngle = Item.LeftAngle;
			ProfileRunTimeSet.RigthAngle = Item.RightAngle;
			ProfileSet.XDirRefType = Item.XReferanceLocation;
			if (Item.XReferanceLocation != LeftRightType.Left)
			{
				radioButton_1.Checked = false;
				radioButton_0.Checked = true;
			}
			else
			{
				radioButton_1.Checked = true;
				radioButton_0.Checked = false;
			}
		}
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		if (Item == null)
		{
			if (boxprofile)
			{
				if (timer_0 == null)
				{
					timer_0 = new System.Windows.Forms.Timer();
					timer_0.Interval = 20;
					timer_0.Tick += Init_Tick;
				}
				timer_0.Enabled = true;
			}
		}
		else
		{
			if (timer_0 == null)
			{
				timer_0 = new System.Windows.Forms.Timer();
				timer_0.Interval = 20;
				timer_0.Tick += Init_Tick;
			}
			timer_0.Enabled = true;
		}
	}

	public void Init_Tick(object sender, EventArgs e)
	{
		if (BoxProfile)
		{
			timer_0.Enabled = false;
			method_1(button_8, null);
		}
		else
		{
			if (!design_0.IsHandleCreated)
			{
				return;
			}
			timer_0.Enabled = false;
			for (int i = 0; i <= grid_files.Rows.Count - 1; i++)
			{
				if (grid_files.Rows[i].Cells[1].Value.ToString() == profileItem_0.FileName)
				{
					grid_files.Rows[i].Selected = true;
					DataGridViewCellEventArgs e2 = new DataGridViewCellEventArgs(1, i);
					method_6(null, e2);
				}
			}
			if (profileItem_0.ProfileTraformations.Count <= 0)
			{
				return;
			}
			List<string> list = new List<string>();
			for (int j = 0; j <= profileItem_0.ProfileTraformations.Count - 1; j++)
			{
				list.Add(profileItem_0.ProfileTraformations[j].ToLower());
			}
			profileItem_0.ProfileTraformations.Clear();
			list_0.Clear();
			for (int k = 0; k <= list.Count - 1; k++)
			{
				if (list[k].ToLower() == "rotateleft")
				{
					method_1(button_3, null);
				}
				if (list[k].ToLower() == "rotateright")
				{
					method_1(button_4, null);
				}
				if (list[k].ToLower() == "mirrorhorizontal")
				{
					method_1(button_5, null);
				}
				if (list[k].ToLower() == "mirrorvertical")
				{
					method_1(button_6, null);
				}
			}
			for (int l = 0; l <= list_0.Count - 1; l++)
			{
				profileItem_0.ProfileTraformations.Add(list_0[l].ToLower());
			}
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
		Control control = new Control();
		control = (Control)sender;
		method_4(sender, e);
		if (control.Name == button_0.Name)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.SelectedPath = ProfileRunTimeSet.pathProfiles;
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				ProfileRunTimeSet.pathProfiles = folderBrowserDialog.SelectedPath;
			}
			Init(null);
		}
		if (control.Name == button_9.Name && okCommandWithTwoDataEventHandler_0 != null)
		{
			okCommandWithTwoDataEventHandler_0(ProfileRunTimeSet.pathProfiles + "\\" + string_0, null);
		}
		if (control.Name == button_11.Name)
		{
			F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
			f_ClassViewerDialog.FormCaption = "Anaylse";
			f_ClassViewerDialog.Value = ProfileRunTimeSet.AnalyseSettings;
			f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
			f_ClassViewerDialog.Width = 500;
			f_ClassViewerDialog.Height = 750;
			f_ClassViewerDialog.ValuePersentage = 35.0;
			f_ClassViewerDialog.Init();
			f_ClassViewerDialog.ShowDialog();
			if (f_ClassViewerDialog.Result == DialogResult.OK)
			{
				ProfileRunTimeSet.AnalyseSettings = new AnalyseEntitiesSetting((AnalyseEntitiesSetting)f_ClassViewerDialog.Value);
			}
		}
		if (control.Name == button_12.Name)
		{
			SortResolutionSet sortResolutionSet = new SortResolutionSet();
			sortResolutionSet.GapDistance = ProfileSet.GapConnectionForProfile;
			sortResolutionSet.SortResolution = ProfileSet.ProfileSortResolution;
			sortResolutionSet.IntersectionRules = ProfileSet.IntersectionRules;
			sortResolutionSet.ConnectSmallGap = ProfileSet.ConnectSmallGap;
			sortResolutionSet.MinProfileFilterLength = ProfileSet.MinProfileFilterLength;
			F_ClassViewerDialog f_ClassViewerDialog2 = new F_ClassViewerDialog();
			f_ClassViewerDialog2.FormCaption = "Sort";
			f_ClassViewerDialog2.Value = sortResolutionSet;
			f_ClassViewerDialog2.StartPosition = FormStartPosition.CenterParent;
			f_ClassViewerDialog2.Width = 500;
			f_ClassViewerDialog2.Height = 750;
			f_ClassViewerDialog2.ValuePersentage = 35.0;
			f_ClassViewerDialog2.Init();
			f_ClassViewerDialog2.ShowDialog();
			if (f_ClassViewerDialog2.Result == DialogResult.OK)
			{
				ProfileSet.GapConnectionForProfile = ((SortResolutionSet)f_ClassViewerDialog2.Value).GapDistance;
				ProfileSet.ProfileSortResolution = ((SortResolutionSet)f_ClassViewerDialog2.Value).SortResolution;
				ProfileSet.IntersectionRules = ((SortResolutionSet)f_ClassViewerDialog2.Value).IntersectionRules;
				ProfileSet.ConnectSmallGap = ((SortResolutionSet)f_ClassViewerDialog2.Value).ConnectSmallGap;
				ProfileSet.MinProfileFilterLength = ((SortResolutionSet)f_ClassViewerDialog2.Value).MinProfileFilterLength;
				ProfileRunTimeSet.AnalyseSettings.SmallGapMaxDistance = ProfileSet.GapConnectionForProfile;
				ProfileRunTimeSet.AnalyseSettings.SmallGapMinDistance = ProfileSet.ProfileSortResolution;
			}
		}
		if (control.Name == button_10.Name)
		{
			AnalyseEntitiesResult Result = new AnalyseEntitiesResult();
			buCall.buVector5_0.AnalyseEntities(design_0.Entities.ToList(), ProfileRunTimeSet.AnalyseSettings, ref Result);
			if (Result.ErrorList.Count <= 0)
			{
				buString5.MessageBoxInfo(AppLanguage.CadCamMessages[89]);
			}
			else
			{
				F_Preview f_Preview = new F_Preview();
				CreateModelProperties createModelProperties = new CreateModelProperties();
				createModelProperties.CoordinateSystemIconVisible = false;
				createModelProperties.ViewCubeIconVisible = false;
				createModelProperties.OrigineCaptionVisible = false;
				createModelProperties.ToolBorVisible = false;
				createModelProperties.BottomColor = Color.Gray;
				createModelProperties.MiddleColor = Color.Gray;
				createModelProperties.TopColor = Color.Gray;
				f_Preview.viewportLayout = buCall.buVector5_0.CreateModelControl("", createModelProperties);
				for (int i = 0; i <= design_0.Entities.Count - 1; i++)
				{
					Entity copiedEntity = null;
					buEntity.Copy(design_0.Entities[i], ref copiedEntity);
					copiedEntity.LayerName = "Default";
					f_Preview.viewportLayout.Entities.Add(copiedEntity);
				}
				DialogBoxList dialogBoxList = new DialogBoxList();
				for (int j = 0; j <= Result.ErrorList.Count - 1; j++)
				{
					if ((Result.ErrorList[j].IndexEntity >= 0) & (Result.ErrorList[j].IndexEntity <= f_Preview.viewportLayout.Entities.Count - 1))
					{
						f_Preview.viewportLayout.Entities[Result.ErrorList[j].IndexEntity].Selected = true;
						buEntity copiedEntity2 = null;
						buEntity.Copy(f_Preview.viewportLayout.Entities[Result.ErrorList[j].IndexEntity], ref copiedEntity2);
						string text = Result.ErrorList[j].ErrorType.ToString();
						if (Result.ErrorList[j].ErrorType == AnalyseEntitiesResultErrorType.SmallLength)
						{
							text = text + " = " + ((ICurve)f_Preview.viewportLayout.Entities[Result.ErrorList[j].IndexEntity]).Length().ToString("f5");
						}
						text = text + " - [ " + Result.ErrorList[j].IndexEntity + " ] " + copiedEntity2.ToString();
						dialogBoxList.Items.Add(text);
					}
					devDept.Eyeshot.Entities.Text text2 = new devDept.Eyeshot.Entities.Text(Plane.XY, Result.ErrorList[j].ErrorType.ToString(), 0.1);
					text2.Translate(Result.ErrorList[j].pntError.X, Result.ErrorList[j].pntError.Y, Result.ErrorList[j].pntError.Z);
					devDept.Eyeshot.Entities.Point point = new devDept.Eyeshot.Entities.Point(Result.ErrorList[j].pntError.X, Result.ErrorList[j].pntError.Y, Result.ErrorList[j].pntError.Z);
					point.LineWeight = 5f;
					point.Color = Color.Red;
					if (Result.ErrorList[j].ErrorType == AnalyseEntitiesResultErrorType.SameAvailable)
					{
						point.Color = Color.Blue;
					}
					if (Result.ErrorList[j].ErrorType == AnalyseEntitiesResultErrorType.SmallGap)
					{
						point.Color = Color.Lime;
					}
					point.ColorMethod = colorMethodType.byEntity;
					point.LineWeightMethod = colorMethodType.byEntity;
					f_Preview.viewportLayout.Entities.Add(point);
				}
				dialogBoxList.Init(buLangTranslate.preDef.Error, 0);
				dialogBoxList.ShowDialog();
				f_Preview.Controls.Add(f_Preview.viewportLayout);
				f_Preview.Init(viewType.Top, zoomFit: true, zoomAnimation: false);
				f_Preview.Show();
			}
		}
		if (control.Name == button_8.Name)
		{
			if (FrmNewProfile == null)
			{
				FrmNewProfile = new F_NewProfile();
			}
			FrmNewProfile.txt_name.Text = AppLanguage.CadCamDynamic[112];
			FrmNewProfile.cmb_length.Text = comboBox_1.Text;
			if (profileItem_0 != null)
			{
				FrmNewProfile.spn_multiplycount.Value = profileItem_0.MultiplyProfile.ProfileMultiplyCount;
				FrmNewProfile.spn_multiplyspace.Value = (decimal)profileItem_0.MultiplyProfile.ProfileMultiplySpace;
				FrmNewProfile.chk_multilymirror.Checked = profileItem_0.MultiplyProfile.ProfileMultiplyMirror;
				FrmNewProfile.chk_multiplyprofile.Checked = profileItem_0.MultiplyProfile.ProfileMultiplyEnable;
			}
			FrmNewProfile.spn_supportblocky1H.Value = (decimal)ProfileRunTimeSet.SupportBlockY1Height;
			FrmNewProfile.spn_supportblocky2H.Value = (decimal)ProfileRunTimeSet.SupportBlockY2Height;
			FrmNewProfile.spn_supportblockzH.Value = (decimal)ProfileRunTimeSet.SupportBlockZHeight;
			FrmNewProfile.spn_supportblocky1W.Value = (decimal)ProfileRunTimeSet.SupportBlockY1Width;
			FrmNewProfile.spn_supportblocky2W.Value = (decimal)ProfileRunTimeSet.SupportBlockY2Width;
			FrmNewProfile.spn_supportblockzW.Value = (decimal)ProfileRunTimeSet.SupportBlockZWidth;
			FrmNewProfile.spn_leftangle.Value = (decimal)ProfileRunTimeSet.LeftAngle;
			FrmNewProfile.spn_rightangle.Value = (decimal)ProfileRunTimeSet.RigthAngle;
			if (!radioButton_1.Checked)
			{
				ProfileSet.XDirRefType = LeftRightType.Right;
			}
			else
			{
				ProfileSet.XDirRefType = LeftRightType.Left;
			}
			if (ProfileSet.XDirRefType != LeftRightType.Left)
			{
				FrmNewProfile.radio_leftholder.Checked = false;
				FrmNewProfile.radio_rightholder.Checked = true;
			}
			else
			{
				FrmNewProfile.radio_leftholder.Checked = true;
				FrmNewProfile.radio_rightholder.Checked = false;
			}
			FrmNewProfile.ItemHeight = ProfileRunTimeSet.NewProfileHeight;
			FrmNewProfile.ItemWidth = ProfileRunTimeSet.NewProfileWidth;
			FrmNewProfile.ItemThickness = ProfileRunTimeSet.NewProfileThickness;
			FrmNewProfile.RightProfile = RigthProfile;
			FrmNewProfile.MaxClamper = (int)numericUpDown_7.Value;
			FrmNewProfile.FormCloseMode = FormCloseModeType.Invisible;
			FrmNewProfile.Init();
			FrmNewProfile.StartPosition = FormStartPosition.CenterParent;
			FrmNewProfile.ShowDialog();
			if (FrmNewProfile.Result == DialogResult.OK)
			{
				ProfileRunTimeSet.ProfileType = FrmNewProfile.SelectedType;
				ProfileRunTimeSet.NewProfileHeight = FrmNewProfile.ItemHeight;
				ProfileRunTimeSet.NewProfileWidth = FrmNewProfile.ItemWidth;
				ProfileRunTimeSet.NewProfileThickness = FrmNewProfile.ItemThickness;
				textBox_1.Text = FrmNewProfile.ItemName;
				if (FrmNewProfile.ItemLength.Length > 0)
				{
					comboBox_1.Text = FrmNewProfile.ItemLength;
				}
				ProfileRunTimeSet.SupportBlockY1Height = (double)FrmNewProfile.spn_supportblocky1H.Value;
				ProfileRunTimeSet.SupportBlockY2Height = (double)FrmNewProfile.spn_supportblocky2H.Value;
				ProfileRunTimeSet.SupportBlockZHeight = (double)FrmNewProfile.spn_supportblockzH.Value;
				ProfileRunTimeSet.SupportBlockY1Width = (double)FrmNewProfile.spn_supportblocky1W.Value;
				ProfileRunTimeSet.SupportBlockY2Width = (double)FrmNewProfile.spn_supportblocky2W.Value;
				ProfileRunTimeSet.SupportBlockZWidth = (double)FrmNewProfile.spn_supportblockzW.Value;
				ProfileRunTimeSet.LeftAngle = (double)FrmNewProfile.spn_leftangle.Value;
				ProfileRunTimeSet.RigthAngle = (double)FrmNewProfile.spn_rightangle.Value;
				if (!FrmNewProfile.radio_leftholder.Checked)
				{
					ProfileSet.XDirRefType = LeftRightType.Right;
					radioButton_1.Checked = false;
					radioButton_0.Checked = true;
				}
				else
				{
					ProfileSet.XDirRefType = LeftRightType.Left;
					radioButton_1.Checked = true;
					radioButton_0.Checked = false;
				}
				EntitiesTransformed.Clear();
				buEntity.Copy(FrmNewProfile.PreviewEnts, ref EntitiesTransformed);
				for (int k = 0; k <= EntitiesTransformed.Count - 1; k++)
				{
					buEntity LinearPathEntity = null;
					buCall.buVector5_0.EntitiesToLinearPath(EntitiesTransformed[k], buSystem.RegenDeviation, ref LinearPathEntity);
					EntitiesTransformed[k] = LinearPathEntity;
				}
				design_0.Entities.Clear();
				for (int l = 0; l <= EntitiesTransformed.Count - 1; l++)
				{
					Entity copiedEntity3 = null;
					buEntity.Copy(EntitiesTransformed[l], ref copiedEntity3);
					design_0.Entities.Add(copiedEntity3);
				}
				design_0.Invalidate();
				Point3D MinPoint = new Point3D();
				Point3D MidPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				buCall.buVector5_0.BoxSizeCalculate(EntitiesTransformed, ref MinPoint, ref MidPoint, ref MaxPoint);
				PropertiesForm.Inited = false;
				numericUpDown_5.Value = (decimal)Math.Round(MaxPoint.X - MinPoint.X, 3);
				numericUpDown_6.Value = (decimal)Math.Round(MaxPoint.Y - MinPoint.Y, 3);
				numericUpDown_2.Value = (decimal)ProfileRunTimeSet.SupportBlockY1Height;
				numericUpDown_4.Value = (decimal)ProfileRunTimeSet.SupportBlockY2Height;
				numericUpDown_3.Value = (decimal)ProfileRunTimeSet.SupportBlockZHeight;
				numericUpDown_10.Value = (decimal)ProfileRunTimeSet.SupportBlockY1Width;
				numericUpDown_8.Value = (decimal)ProfileRunTimeSet.SupportBlockY2Width;
				numericUpDown_9.Value = (decimal)ProfileRunTimeSet.SupportBlockZWidth;
				numericUpDown_7.Value = FrmNewProfile.MaxClamper;
				numericUpDown_12.Value = (decimal)ProfileRunTimeSet.LeftAngle;
				numericUpDown_11.Value = (decimal)ProfileRunTimeSet.RigthAngle;
				numericUpDown_14.Value = FrmNewProfile.spn_multiplycount.Value;
				numericUpDown_13.Value = FrmNewProfile.spn_multiplyspace.Value;
				checkBox_3.Checked = FrmNewProfile.chk_multiplyprofile.Checked;
				checkBox_2.Checked = FrmNewProfile.chk_multilymirror.Checked;
				Profile.MultiplyProfile.ProfileMultiplyCount = (int)FrmNewProfile.spn_multiplycount.Value;
				Profile.MultiplyProfile.ProfileMultiplySpace = (double)FrmNewProfile.spn_multiplyspace.Value;
				Profile.MultiplyProfile.ProfileMultiplyEnable = FrmNewProfile.chk_multiplyprofile.Checked;
				Profile.MultiplyProfile.ProfileMultiplyMirror = FrmNewProfile.chk_multilymirror.Checked;
				PropertiesForm.Inited = true;
				method_1(button_1, e);
				return;
			}
		}
		if (control.Name == button_7.Name && int_1 >= 0)
		{
			FileInfo fileInfo = new FileInfo(ProfileRunTimeSet.pathProfiles + "\\" + grid_files.Rows[int_1].Cells[1].Value.ToString());
			if (fileInfo.Exists)
			{
				string fileName = buFile.getFileName(fileInfo.FullName);
				if (buString.MessageBoxQuestion(strDelete + " : " + fileName) == DialogResult.Yes)
				{
					fileInfo.Delete();
					Class186.smethod_540(this);
				}
			}
		}
		if (control.Name == button_4.Name)
		{
			Point3D MinPoint2 = new Point3D();
			Point3D MaxPoint2 = new Point3D();
			Point3D MidPoint2 = new Point3D();
			design_0.Entities.Rotate(buConversion5.DegreeToRadian((double)numericUpDown_0.Value), new Vector3D(0.0, 0.0, 1.0));
			design_0.Entities.RegenAllCurved();
			buCall.buVector5_0.BoxSizeCalculate(design_0.Entities, ref MinPoint2, ref MidPoint2, ref MaxPoint2);
			design_0.Entities.Translate(0.0 - MaxPoint2.X, 0.0 - MinPoint2.Y, 0.0 - MinPoint2.Z);
			design_0.Entities.RegenAllCurved();
			design_0.ZoomFit();
			design_0.Invalidate();
			PropertiesForm.Inited = false;
			numericUpDown_5.Value = (decimal)(MaxPoint2.X - MinPoint2.X);
			numericUpDown_6.Value = (decimal)(MaxPoint2.Y - MinPoint2.Y);
			list_0.Add("RotateLeft");
			PropertiesForm.Inited = true;
		}
		if (control.Name == button_3.Name)
		{
			Point3D MinPoint3 = new Point3D();
			Point3D MaxPoint3 = new Point3D();
			Point3D MidPoint3 = new Point3D();
			design_0.Entities.Rotate(buConversion5.DegreeToRadian(0.0 - (double)numericUpDown_0.Value), new Vector3D(0.0, 0.0, 1.0));
			design_0.Entities.RegenAllCurved();
			buCall.buVector5_0.BoxSizeCalculate(design_0.Entities, ref MinPoint3, ref MidPoint3, ref MaxPoint3);
			design_0.Entities.Translate(0.0 - MaxPoint3.X, 0.0 - MinPoint3.Y, 0.0 - MinPoint3.Z);
			design_0.Entities.RegenAllCurved();
			design_0.ZoomFit();
			design_0.Invalidate();
			PropertiesForm.Inited = false;
			numericUpDown_5.Value = (decimal)(MaxPoint3.X - MinPoint3.X);
			numericUpDown_6.Value = (decimal)(MaxPoint3.Y - MinPoint3.Y);
			list_0.Add("RotateRight");
			PropertiesForm.Inited = true;
		}
		if (control.Name == button_5.Name)
		{
			Point3D MinPoint4 = new Point3D();
			Point3D MaxPoint4 = new Point3D();
			Point3D MidPoint4 = new Point3D();
			for (int m = 0; m <= design_0.Entities.Count - 1; m++)
			{
				Vector3D vector3D = new Vector3D(new Point3D(), new Point3D(0.0, 10.0, 0.0));
				Plane plane = new Plane(new Point3D(), vector3D, Plane.XY.AxisZ);
				Mirror xform = new Mirror(plane);
				design_0.Entities[m].TransformBy(xform);
			}
			design_0.Entities.RegenAllCurved();
			buCall.buVector5_0.BoxSizeCalculate(design_0.Entities, ref MinPoint4, ref MidPoint4, ref MaxPoint4);
			design_0.Entities.Translate(0.0 - MaxPoint4.X, 0.0 - MinPoint4.Y, 0.0 - MinPoint4.Z);
			design_0.Entities.RegenAllCurved();
			design_0.ZoomFit();
			design_0.Invalidate();
			PropertiesForm.Inited = false;
			numericUpDown_5.Value = (decimal)(MaxPoint4.X - MinPoint4.X);
			numericUpDown_6.Value = (decimal)(MaxPoint4.Y - MinPoint4.Y);
			list_0.Add("MirrorHorizontal");
			PropertiesForm.Inited = true;
		}
		if (control.Name == button_6.Name)
		{
			Point3D MinPoint5 = new Point3D();
			Point3D MaxPoint5 = new Point3D();
			Point3D MidPoint5 = new Point3D();
			for (int n = 0; n <= design_0.Entities.Count - 1; n++)
			{
				Vector3D vector3D2 = new Vector3D(new Point3D(), new Point3D(10.0, 0.0, 0.0));
				Plane plane2 = new Plane(new Point3D(), vector3D2, Plane.XY.AxisZ);
				Mirror xform2 = new Mirror(plane2);
				design_0.Entities[n].TransformBy(xform2);
			}
			design_0.Entities.RegenAllCurved();
			buCall.buVector5_0.BoxSizeCalculate(design_0.Entities, ref MinPoint5, ref MidPoint5, ref MaxPoint5);
			design_0.Entities.Translate(0.0 - MaxPoint5.X, 0.0 - MinPoint5.Y, 0.0 - MinPoint5.Z);
			design_0.Entities.RegenAllCurved();
			design_0.ZoomFit();
			design_0.Invalidate();
			PropertiesForm.Inited = false;
			numericUpDown_5.Value = (decimal)(MaxPoint5.X - MinPoint5.X);
			numericUpDown_6.Value = (decimal)(MaxPoint5.Y - MinPoint5.Y);
			list_0.Add("MirrorVertical");
			PropertiesForm.Inited = true;
		}
		if (control.Name == label_16.Name)
		{
			Color supportBlockZColor = ProfileSet.SupportBlockZColor;
			ColorDialogBox.ShowDialog(supportBlockZColor);
			if (ColorDialogBox.Result == DialogResult.OK)
			{
				ProfileSet.SupportBlockZColor = ColorDialogBox.Color;
				Profile.colorSupportBlock = ColorDialogBox.Color;
				label_16.BackColor = ColorDialogBox.Color;
			}
		}
		if (control.Name == label_17.Name)
		{
			Color color = Profile.Color;
			ColorDialogBox.ShowDialog(color);
			if (ColorDialogBox.Result == DialogResult.OK)
			{
				ProfileSet.ProfileColor = ColorDialogBox.Color;
				Profile.colorProfile = ColorDialogBox.Color;
				label_17.BackColor = ColorDialogBox.Color;
				Class186.smethod_502(ProfileRunTimeSet.pathProfiles + "\\" + grid_files.Rows[int_1].Cells[1].Value.ToString(), this);
			}
		}
		if (control.Name == button_2.Name)
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
		if (!(control.Name == button_1.Name))
		{
			return;
		}
		Profile = new buEyeBaseVer5.Apps.ProfileItem();
		double result = 0.0;
		double.TryParse(comboBox_1.Text, out result);
		if (((ProfileSet.ProfileMaxLength > 0.0) & (result > ProfileSet.ProfileMaxLength)) && buString5.MessageBoxQuestion(buProfile.LangProfileMessage[24]) == DialogResult.No)
		{
			return;
		}
		if (!((ProfileSet.ProfileMaxWidth > 0.0) & ((double)numericUpDown_5.Value > ProfileSet.ProfileMaxWidth)))
		{
			if (!((ProfileSet.ProfileMaxHeight > 0.0) & ((double)numericUpDown_6.Value > ProfileSet.ProfileMaxHeight)))
			{
				if (!(checkBox_3.Checked & checkBox_2.Checked & (numericUpDown_14.Value > 2m)))
				{
					CreateProfileFromDataOptions createProfileFromDataOptions = new CreateProfileFromDataOptions();
					createProfileFromDataOptions.color = ProfileSet.ProfileColor;
					createProfileFromDataOptions.Transparency = (int)numericUpDown_1.Value;
					createProfileFromDataOptions.FileName = string_0;
					createProfileFromDataOptions.FullName = ProfileRunTimeSet.pathProfiles + "\\" + Profile.FileName;
					createProfileFromDataOptions.Name = textBox_1.Text;
					createProfileFromDataOptions.Length = result;
					createProfileFromDataOptions.NeededHeight = (double)numericUpDown_6.Value;
					createProfileFromDataOptions.NeededWidth = (double)numericUpDown_5.Value;
					createProfileFromDataOptions.SupportBlockY1Height = (double)numericUpDown_2.Value;
					createProfileFromDataOptions.SupportBlockY2Height = (double)numericUpDown_4.Value;
					createProfileFromDataOptions.SupportBlockZHeight = (double)numericUpDown_3.Value;
					createProfileFromDataOptions.SupportBlockY1Width = (double)numericUpDown_10.Value;
					createProfileFromDataOptions.SupportBlockY2Width = (double)numericUpDown_8.Value;
					createProfileFromDataOptions.SupportBlockZWidth = (double)numericUpDown_9.Value;
					createProfileFromDataOptions.GapConnection = ProfileSet.GapConnectionForProfile;
					createProfileFromDataOptions.SortResolituon = ProfileSet.ProfileSortResolution;
					createProfileFromDataOptions.IntersectionRules = ProfileSet.IntersectionRules;
					createProfileFromDataOptions.ConnectSmallGap = ProfileSet.ConnectSmallGap;
					createProfileFromDataOptions.MinPointFilterLength = ProfileSet.MinProfileFilterLength;
					createProfileFromDataOptions.NextFroupRules = SortingNextGroupFindRulesType.ClosestLength;
					createProfileFromDataOptions.MaxClamper = (int)numericUpDown_7.Value;
					List<Entity> Entities = new List<Entity>();
					for (int num = 0; num <= design_0.Entities.Count - 1; num++)
					{
						if (!(design_0.Entities[num] is ICurve))
						{
							if (!(design_0.Entities[num].GetType() == typeof(BlockReference)))
							{
								if (!(design_0.Entities[num].GetType() == typeof(BlockReferenceEx)))
								{
									continue;
								}
								BlockReferenceEx blockReferenceEx = design_0.Entities[num] as BlockReferenceEx;
								for (int num2 = 0; num2 <= design_0.Blocks.Count - 1; num2++)
								{
									if (!(blockReferenceEx.BlockName == design_0.Blocks[num2].Name))
									{
										continue;
									}
									for (int num3 = 0; num3 <= design_0.Blocks[num2].Entities.Count - 1; num3++)
									{
										if (design_0.Blocks[num2].Entities[num3] is ICurve)
										{
											Entity entity = buVector5.CopyEntities(design_0.Blocks[num2].Entities[num3]);
											entity.TransformBy(blockReferenceEx.Transformation);
											entity.Regen(0.01);
											Entities.Add(entity);
										}
									}
								}
								continue;
							}
							BlockReference blockReference = design_0.Entities[num] as BlockReference;
							for (int num4 = 0; num4 <= design_0.Blocks.Count - 1; num4++)
							{
								if (!(blockReference.BlockName == design_0.Blocks[num4].Name))
								{
									continue;
								}
								for (int num5 = 0; num5 <= design_0.Blocks[num4].Entities.Count - 1; num5++)
								{
									if (design_0.Blocks[num4].Entities[num5] is ICurve)
									{
										Entity entity2 = buVector5.CopyEntities(design_0.Blocks[num4].Entities[num5]);
										entity2.TransformBy(blockReference.Transformation);
										entity2.Regen(0.01);
										Entities.Add(entity2);
									}
								}
							}
						}
						else
						{
							if ((design_0.Entities[num].GetType() != typeof(devDept.Eyeshot.Entities.Point)) & (design_0.Entities[num].GetType() != typeof(Curve)))
							{
								Entities.Add(buVector5.CopyEntities(design_0.Entities[num]));
							}
							if (design_0.Entities[num].GetType() == typeof(Curve))
							{
								((Curve)design_0.Entities[num]).Regen(0.1);
								Entities.Add(new LinearPath(design_0.Entities[num].Vertices));
							}
						}
					}
					if (checkBox_3.Checked)
					{
						Point3D MinPoint6 = new Point3D();
						Point3D MaxPoint6 = new Point3D();
						buCall.buVector5_0.BoxSizeCalculate(Entities, ref MinPoint6, ref MaxPoint6);
						double num6 = MaxPoint6.X - MinPoint6.X;
						double num7 = (num6 + (double)numericUpDown_13.Value) * ((double)numericUpDown_14.Value - 1.0) + num6;
						if ((ProfileSet.ProfileMaxHeight > 0.0) & (num7 > ProfileSet.ProfileMaxHeight))
						{
							buString5.MessageBoxWarning(buLangTranslate.preSentencesProfile.ProfileMultiplyWidthIsBiggerThenLimit);
							return;
						}
					}
					Profile.LeftAngle = (double)numericUpDown_12.Value;
					Profile.RightAngle = (double)numericUpDown_11.Value;
					CheckEntitesOption checkEntitesOption = new CheckEntitesOption();
					checkEntitesOption.CompositeCurveToEntities = false;
					buCall.buVector5_0.CheckEntities(checkEntitesOption, ref Entities);
					buCall.buProfileCalc_0.CreateProfileFromData(Entities, createProfileFromDataOptions, ref Profile);
					Profile.colorSupportBlock = ProfileSet.SupportBlockZColor;
					Profile.MaxClamperNumber = (int)numericUpDown_7.Value;
					Profile.Thickness = ProfileRunTimeSet.NewProfileThickness;
					Profile.ProfileType = ProfileRunTimeSet.ProfileType;
					Profile.MultiplyProfile.ProfileMultiplyCount = (int)numericUpDown_14.Value;
					Profile.MultiplyProfile.ProfileMultiplySpace = (double)numericUpDown_13.Value;
					Profile.MultiplyProfile.ProfileMultiplyEnable = checkBox_3.Checked;
					Profile.MultiplyProfile.ProfileMultiplyMirror = checkBox_2.Checked;
					ProfileRunTimeSet.TextureEnable = checkBox_0.Checked;
					ProfileRunTimeSet.LeftAngle = (double)numericUpDown_12.Value;
					ProfileRunTimeSet.RigthAngle = (double)numericUpDown_11.Value;
					if (!radioButton_1.Checked)
					{
						Profile.XReferanceLocation = LeftRightType.Right;
						ProfileSet.XDirRefType = LeftRightType.Right;
					}
					else
					{
						Profile.XReferanceLocation = LeftRightType.Left;
						ProfileSet.XDirRefType = LeftRightType.Left;
					}
					ProfileRunTimeSet.MultiplyProfileCount = (int)numericUpDown_14.Value;
					ProfileRunTimeSet.MultiplyProfileSpace = (double)numericUpDown_13.Value;
					ProfileRunTimeSet.MultiplyProfileMirror = checkBox_2.Checked;
					ProfileRunTimeSet.MultiplyProfileEnable = checkBox_3.Checked;
					ProfileSet.MaterialTranspancy = (int)numericUpDown_1.Value;
					ProfileSet.SupportBlockZColor = label_16.BackColor;
					Profile.ItemName = textBox_1.Text;
					Profile.FileName = string_0;
					Profile.FileNameFull = ProfileRunTimeSet.pathProfiles + "\\" + Profile.FileName;
					for (int num8 = 0; num8 <= list_0.Count - 1; num8++)
					{
						Profile.ProfileTraformations.Add(list_0[num8]);
					}
					ProfileRunTimeSet.ProfileLength = result;
					ProfileRunTimeSet.SupportBlockY1Height = (double)numericUpDown_2.Value;
					ProfileRunTimeSet.SupportBlockY2Height = (double)numericUpDown_4.Value;
					ProfileRunTimeSet.SupportBlockZHeight = (double)numericUpDown_3.Value;
					ProfileRunTimeSet.SupportBlockY1Width = (double)numericUpDown_10.Value;
					ProfileRunTimeSet.SupportBlockY2Width = (double)numericUpDown_8.Value;
					ProfileRunTimeSet.SupportBlockZWidth = (double)numericUpDown_9.Value;
					if (ProfileRunTimeSet.SupportBlockY1Height < 0.0)
					{
						ProfileRunTimeSet.SupportBlockY1Height = 0.0;
					}
					if (ProfileRunTimeSet.SupportBlockY2Height < 0.0)
					{
						ProfileRunTimeSet.SupportBlockY2Height = 0.0;
					}
					if (ProfileRunTimeSet.SupportBlockZHeight < 0.0)
					{
						ProfileRunTimeSet.SupportBlockZHeight = 0.0;
					}
					if (ProfileRunTimeSet.SupportBlockY2Width < 0.0)
					{
						ProfileRunTimeSet.SupportBlockY2Width = 0.0;
					}
					if (ProfileRunTimeSet.SupportBlockY2Width < 0.0)
					{
						ProfileRunTimeSet.SupportBlockY2Width = 0.0;
					}
					if (ProfileRunTimeSet.SupportBlockZWidth < 0.0)
					{
						ProfileRunTimeSet.SupportBlockZWidth = 0.0;
					}
					Profile.Length = result;
					if (Materials.Count > 0)
					{
						Profile.Skin = new MaterialSkin(Materials[comboBox_0.SelectedIndex]);
					}
					if (!ProfileRunTimeSet.TextureEnable)
					{
						Profile.TextureName = "";
					}
					else
					{
						Profile.TextureName = comboBox_0.Text;
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
				else
				{
					buString5.MessageBoxWarning(buLangTranslate.preSentencesProfile.YouCanDefineMax2ProfileforMultiplyMirrorMode);
				}
			}
			else
			{
				buString5.MessageBoxWarning(buProfile.LangProfileMessage[26]);
			}
		}
		else
		{
			buString5.MessageBoxWarning(buProfile.LangProfileMessage[25]);
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		if (!PropertiesForm.Inited)
		{
			return;
		}
		Control control = new Control();
		control = (Control)sender;
		double num = (double)numericUpDown_5.Value / (design_0.Entities.BoxMax.X - design_0.Entities.BoxMin.X);
		double num2 = (double)numericUpDown_6.Value / (design_0.Entities.BoxMax.Y - design_0.Entities.BoxMin.Y);
		new List<Entity>();
		if (control.Name == numericUpDown_5.Name && num != 0.0 && num2 != 0.0)
		{
			if (ProfileRunTimeSet.ProfileKeepRatio)
			{
				num2 = num;
				PropertiesForm.Inited = false;
				numericUpDown_6.Value = Math.Round(numericUpDown_6.Value * (decimal)num2);
				PropertiesForm.Inited = true;
			}
			if (!ProfileRunTimeSet.ProfileKeepRatio && num != num2)
			{
				List<Entity> copiedEnt = new List<Entity>();
				List<Entity> devideEntities = new List<Entity>();
				buVector5.CopyEntities(design_0.Entities, ref copiedEnt);
				EntityDevideData entityDevideData = new EntityDevideData();
				entityDevideData.Arc = true;
				entityDevideData.Circle = true;
				entityDevideData.Ellipse = true;
				entityDevideData.ArcLength = 0.1;
				entityDevideData.CircleLength = 0.1;
				entityDevideData.EllipseLength = 0.1;
				Color color = design_0.Entities[0].Color;
				buCall.buVector5_0.EntitiesDevideByLengthAsPolyline(copiedEnt, entityDevideData, ref devideEntities);
				design_0.Entities.Clear();
				for (int i = 0; i <= devideEntities.Count - 1; i++)
				{
					devideEntities[i].Color = color;
					devideEntities[i].ColorMethod = colorMethodType.byEntity;
					design_0.Entities.Add(devideEntities[i]);
				}
			}
			design_0.Entities.Scale(num, num2);
			design_0.Entities.RegenAllCurved(0.01);
			design_0.ZoomFit();
			design_0.Invalidate();
		}
		if (!(control.Name == numericUpDown_6.Name) || !(num != 0.0 && num2 != 0.0))
		{
			return;
		}
		if (ProfileRunTimeSet.ProfileKeepRatio)
		{
			num = num2;
			PropertiesForm.Inited = false;
			numericUpDown_5.Value = Math.Round(numericUpDown_5.Value * (decimal)num);
			PropertiesForm.Inited = true;
		}
		if (!ProfileRunTimeSet.ProfileKeepRatio && num != num2)
		{
			List<Entity> copiedEnt2 = new List<Entity>();
			List<Entity> devideEntities2 = new List<Entity>();
			buVector5.CopyEntities(design_0.Entities, ref copiedEnt2);
			EntityDevideData entityDevideData2 = new EntityDevideData();
			entityDevideData2.Arc = true;
			entityDevideData2.Circle = true;
			entityDevideData2.Ellipse = true;
			entityDevideData2.ArcLength = 0.1;
			entityDevideData2.CircleLength = 0.1;
			entityDevideData2.EllipseLength = 0.1;
			Color color2 = design_0.Entities[0].Color;
			buCall.buVector5_0.EntitiesDevideByLengthAsPolyline(copiedEnt2, entityDevideData2, ref devideEntities2);
			design_0.Entities.Clear();
			for (int j = 0; j <= devideEntities2.Count - 1; j++)
			{
				devideEntities2[j].Color = color2;
				devideEntities2[j].ColorMethod = colorMethodType.byEntity;
				design_0.Entities.Add(devideEntities2[j]);
			}
		}
		design_0.Entities.Scale(num, num2);
		design_0.Entities.RegenAllCurved(0.01);
		design_0.ZoomFit();
		design_0.Invalidate();
	}

	internal void method_3(object sender, EventArgs e)
	{
		try
		{
			int num = 1;
			if (textBox_0.Text.Length != 0)
			{
				grid_files.Rows.Clear();
				for (int i = 0; i <= list_1.Count - 1; i++)
				{
					string fileName = buFile.getFileName(list_1[i]);
					if (fileName.ToLower().IndexOf(textBox_0.Text.ToLower()) >= 0)
					{
						grid_files.Rows.Add(num, fileName);
						num++;
					}
				}
			}
			else
			{
				Class186.smethod_540(this);
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Tag == null)
		{
			pictureBox_2.Image = null;
			textBox_3.Text = "";
			return;
		}
		FileInfo fileInfo = null;
		if (control.Tag.ToString() == "2")
		{
			fileInfo = new FileInfo(AppPath.HelpImages + "\\LeftSupportHeight.png");
			textBox_3.Text = buLangTranslate.preHelpProfile.DefineBackPlaneProfileLeanHeight;
		}
		if (control.Tag.ToString() == "3")
		{
			fileInfo = new FileInfo(AppPath.HelpImages + "\\LeftSupportWidth.png");
			textBox_3.Text = buLangTranslate.preHelpProfile.DefineBackPlaneProfileLeanWidth;
		}
		if (control.Tag.ToString() == "4")
		{
			fileInfo = new FileInfo(AppPath.HelpImages + "\\RigthSupportHeight.png");
			textBox_3.Text = buLangTranslate.preHelpProfile.DefineFrontPlaneProfileLeanHeight;
		}
		if (control.Tag.ToString() == "5")
		{
			fileInfo = new FileInfo(AppPath.HelpImages + "\\RigthSupportWidth.png");
			textBox_3.Text = buLangTranslate.preHelpProfile.DefineFrontPlaneProfileLeanWidth;
		}
		if (control.Tag.ToString() == "6")
		{
			fileInfo = new FileInfo(AppPath.HelpImages + "\\BottomSupportZ.png");
			textBox_3.Text = buLangTranslate.preHelpProfile.DefineBottomPlaneProfileLeanHeight;
		}
		if (control.Tag.ToString() == "7")
		{
			fileInfo = new FileInfo(AppPath.HelpImages + "\\BottomSupportWidth.png");
			textBox_3.Text = buLangTranslate.preHelpProfile.DefineBottomPlaneProfileLeanWidth;
		}
		if (fileInfo == null)
		{
			pictureBox_2.Image = null;
			textBox_3.Text = "";
		}
		else if (!fileInfo.Exists)
		{
			pictureBox_2.Image = null;
			textBox_3.Text = "";
		}
		else
		{
			pictureBox_2.Image = Image.FromFile(fileInfo.FullName);
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited)
		{
			ProfileRunTimeSet.ProfileKeepRatio = checkBox_1.Checked;
		}
	}

	internal void method_6(object sender, DataGridViewCellEventArgs e)
	{
		int_0 = e.ColumnIndex;
		int_1 = e.RowIndex;
		if (int_1 >= 0)
		{
			Class186.smethod_502(ProfileRunTimeSet.pathProfiles + "\\" + grid_files.Rows[int_1].Cells[1].Value.ToString(), this);
			string_0 = grid_files.Rows[int_1].Cells[1].Value.ToString();
			textBox_1.Text = buFile5.getFileNameWithoutExtension(string_0);
			list_0.Clear();
			list_0 = new List<string>();
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
