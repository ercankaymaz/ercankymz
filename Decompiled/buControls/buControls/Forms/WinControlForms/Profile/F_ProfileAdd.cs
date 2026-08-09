using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using buControls.ColorPicker;
using buControls.Controls;
using buControls.Viewer;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.Profile;

public class F_ProfileAdd : Form
{
	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public DialogResult Result = DialogResult.None;

	public List<eEntities> EntitiesOriginal = new List<eEntities>();

	public List<eEntities> EntitiesTransformed = new List<eEntities>();

	public List<LayerBase> Layers = new List<LayerBase>();

	public List<MaterialSkin> Materials = new List<MaterialSkin>();

	public int MaterialIndex = 0;

	public ProfileItem Profile = new ProfileItem();

	public ProfileSettings ProfileSet = new ProfileSettings();

	public ProfileRuntimeSettings ProfileRunTimeSet = new ProfileRuntimeSettings();

	public double SupportBlockY1Thickness = 0.0;

	public double SupportBlockY2Thickness = 0.0;

	public double SupportBlockZThickness = 0.0;

	public string strDelete = "Do You Want to Delete This File";

	public string pathProfile = Application.StartupPath;

	private int int_0 = -1;

	private int int_1 = -1;

	private bool bool_0 = false;

	internal Pnt3D pnt3D_0 = new Pnt3D();

	internal Pnt3D pnt3D_1 = new Pnt3D();

	internal List<string> list_0 = new List<string>();

	private IContainer icontainer_0 = null;

	internal TextBox textBox_0;

	internal Label label_0;

	internal buGrid buGrid_0;

	internal Panel panel_0;

	internal Label label_1;

	internal buViewer buViewer_0;

	internal Panel panel_1;

	internal Button button_0;

	internal ImageList imageList_0;

	internal Button button_1;

	internal Button button_2;

	internal Panel panel_2;

	internal Label label_2;

	internal buViewer buViewer_1;

	internal Button button_3;

	internal Button button_4;

	internal Button button_5;

	internal Button button_6;

	internal NumericUpDown numericUpDown_0;

	internal Button button_7;

	internal Label label_3;

	internal buColorComboBox buColorComboBox_0;

	internal ComboBox comboBox_0;

	internal Label label_4;

	internal ComboBox comboBox_1;

	internal Label label_5;

	internal TextBox textBox_1;

	internal Label label_6;

	internal TextBox textBox_2;

	internal Label label_7;

	internal Label label_8;

	internal Label label_9;

	internal TextBox textBox_3;

	internal NumericUpDown numericUpDown_1;

	internal Label label_10;

	internal NumericUpDown numericUpDown_2;

	internal Label label_11;

	internal Label label_12;

	internal NumericUpDown numericUpDown_3;

	internal Label label_13;

	internal Button button_8;

	internal Label label_14;

	internal NumericUpDown numericUpDown_4;

	internal Label label_15;

	internal buColorComboBox buColorComboBox_1;

	internal NumericUpDown numericUpDown_5;

	internal NumericUpDown numericUpDown_6;

	internal Label label_16;

	internal NumericUpDown numericUpDown_7;

	public F_ProfileAdd()
	{
		Class76.smethod_75(this);
	}

	public void Init()
	{
		buGrid_0.AllowUserToAddRows = false;
		buGrid_0.AllowUserToDeleteRows = false;
		buGrid_0.AllowUserToResizeRows = false;
		buGrid_0.RowHeadersVisible = false;
		buGrid_0.customColumbs.Clear();
		ColumbProperties columbProperties = new ColumbProperties();
		columbProperties = new ColumbProperties("No", 50, readOnly: false, Type.GetType("System.Int"));
		buGrid_0.customColumbs.Add(columbProperties);
		columbProperties = new ColumbProperties("File Name", 250, readOnly: false, Type.GetType("System.String"));
		buGrid_0.customColumbs.Add(columbProperties);
		buGrid_0.Creat();
		numericUpDown_1.Value = ProfileSet.MaterialTranspancy;
		buColorComboBox_0.Color = Profile.Color;
		buColorComboBox_1.Color = ProfileSet.SupportBlockZColor;
		bool_0 = false;
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
		for (int i = 0; i <= Materials.Count - 1; i++)
		{
			comboBox_0.Items.Add(Materials[i].Name);
		}
		if ((MaterialIndex >= 0) & (MaterialIndex <= comboBox_0.Items.Count - 1))
		{
			comboBox_0.SelectedIndex = MaterialIndex;
		}
		numericUpDown_2.Value = (decimal)SupportBlockY1Thickness;
		numericUpDown_4.Value = (decimal)SupportBlockY2Thickness;
		numericUpDown_3.Value = (decimal)SupportBlockZThickness;
		numericUpDown_7.Value = ProfileRunTimeSet.ProfileMaxClamper;
		list_0 = new List<string>();
		List<string> Files = new List<string>();
		buFile.GetFilesInDirectory(AppPath.Profiles, ".dxf", ref Files);
		for (int j = 0; j <= Files.Count - 1; j++)
		{
			list_0.Add(Files[j]);
		}
		Files = new List<string>();
		buFile.GetFilesInDirectory(AppPath.Profiles, ".bucad", ref Files);
		for (int k = 0; k <= Files.Count - 1; k++)
		{
			list_0.Add(Files[k]);
		}
		Class76.smethod_235(this);
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (Result != DialogResult.OK)
		{
			e.Cancel = true;
			Result = DialogResult.Cancel;
			if (FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_0.Name)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.SelectedPath = pathProfile;
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				pathProfile = folderBrowserDialog.SelectedPath;
			}
			Init();
		}
		if (control.Name == button_8.Name)
		{
			F_NewProfile f_NewProfile = new F_NewProfile();
			f_NewProfile.txt_name.Text = textBox_2.Text;
			f_NewProfile.cmb_length.Text = comboBox_1.Text;
			f_NewProfile.ItemHeight = ProfileRunTimeSet.NewProfileHeight;
			f_NewProfile.ItemWidth = ProfileRunTimeSet.NewProfileWidth;
			f_NewProfile.ItemThickness = ProfileRunTimeSet.NewProfileThickness;
			f_NewProfile.Init();
			f_NewProfile.StartPosition = FormStartPosition.CenterParent;
			f_NewProfile.ShowDialog();
			if (f_NewProfile.Result == DialogResult.OK)
			{
				ProfileRunTimeSet.NewProfileHeight = f_NewProfile.ItemHeight;
				ProfileRunTimeSet.NewProfileWidth = f_NewProfile.ItemWidth;
				ProfileRunTimeSet.NewProfileThickness = f_NewProfile.ItemThickness;
				textBox_2.Text = f_NewProfile.ItemName;
				if (f_NewProfile.ItemLength.Length > 0)
				{
					comboBox_1.Text = f_NewProfile.ItemLength;
				}
				EntitiesTransformed.Clear();
				eEntities.CopyEntities(f_NewProfile.PreviewEnts, ref EntitiesTransformed);
				method_1(button_1, e);
				return;
			}
		}
		if (control.Name == button_7.Name && int_1 >= 0)
		{
			FileInfo fileInfo = new FileInfo(AppPath.Profiles + "\\" + buGrid_0.Rows[int_1].Cells[1].Value.ToString());
			if (fileInfo.Exists)
			{
				string fileName = buFile.getFileName(fileInfo.FullName);
				if (buString.MessageBoxQuestion(strDelete + " : " + fileName) == DialogResult.Yes)
				{
					fileInfo.Delete();
					Class76.smethod_235(this);
				}
			}
		}
		if (control.Name == button_3.Name)
		{
			Pnt3D MinPoint = new Pnt3D();
			Pnt3D MaxPoint = new Pnt3D();
			Pnt3D MidPoint = new Pnt3D();
			buControlCoreClass.cVector.BoxSizeCalculate(EntitiesTransformed, ref MinPoint, ref MidPoint, ref MaxPoint);
			buControlCoreClass.cVector.Rotate(MidPoint, (double)numericUpDown_0.Value, ClockDirectionType.CCW, new WorkPlane(), ref EntitiesTransformed);
			buControlCoreClass.cVector.BoxSizeCalculate(EntitiesTransformed, ref MinPoint, ref MidPoint, ref MaxPoint);
			numericUpDown_5.Value = (decimal)(MaxPoint.X - MinPoint.X);
			numericUpDown_6.Value = (decimal)(MaxPoint.Y - MinPoint.Y);
			buViewer_1.AddEntities(EntitiesTransformed);
			buViewer_1.DrawEntities();
			buViewer_1.ZoomFit();
			buViewer_1.ZoomOut();
		}
		if (control.Name == button_4.Name)
		{
			Pnt3D MinPoint2 = new Pnt3D();
			Pnt3D MaxPoint2 = new Pnt3D();
			Pnt3D MidPoint2 = new Pnt3D();
			buControlCoreClass.cVector.BoxSizeCalculate(EntitiesTransformed, ref MinPoint2, ref MidPoint2, ref MaxPoint2);
			buControlCoreClass.cVector.Rotate(MidPoint2, (double)numericUpDown_0.Value * -1.0, ClockDirectionType.CCW, new WorkPlane(), ref EntitiesTransformed);
			buControlCoreClass.cVector.BoxSizeCalculate(EntitiesTransformed, ref MinPoint2, ref MidPoint2, ref MaxPoint2);
			numericUpDown_5.Value = (decimal)(MaxPoint2.X - MinPoint2.X);
			numericUpDown_6.Value = (decimal)(MaxPoint2.Y - MinPoint2.Y);
			buViewer_1.AddEntities(EntitiesTransformed);
			buViewer_1.DrawEntities();
			buViewer_1.ZoomFit();
			buViewer_1.ZoomOut();
		}
		if (control.Name == button_5.Name)
		{
			Pnt3D MinPoint3 = new Pnt3D();
			Pnt3D MaxPoint3 = new Pnt3D();
			Pnt3D MidPoint3 = new Pnt3D();
			buControlCoreClass.cVector.BoxSizeCalculate(EntitiesTransformed, ref MinPoint3, ref MidPoint3, ref MaxPoint3);
			buControlCoreClass.cVector.Mirror(MidPoint3, new Pnt3D(MidPoint3.X, MidPoint3.Y + 10.0), new WorkPlane(), 0.0, ref EntitiesTransformed);
			buControlCoreClass.cVector.BoxSizeCalculate(EntitiesTransformed, ref MinPoint3, ref MidPoint3, ref MaxPoint3);
			numericUpDown_5.Value = (decimal)(MaxPoint3.X - MinPoint3.X);
			numericUpDown_6.Value = (decimal)(MaxPoint3.Y - MinPoint3.Y);
			buViewer_1.AddEntities(EntitiesTransformed);
			buViewer_1.DrawEntities();
			buViewer_1.ZoomFit();
			buViewer_1.ZoomOut();
		}
		if (control.Name == button_6.Name)
		{
			Pnt3D MinPoint4 = new Pnt3D();
			Pnt3D MaxPoint4 = new Pnt3D();
			Pnt3D MidPoint4 = new Pnt3D();
			buControlCoreClass.cVector.BoxSizeCalculate(EntitiesTransformed, ref MinPoint4, ref MidPoint4, ref MaxPoint4);
			buControlCoreClass.cVector.Mirror(MidPoint4, new Pnt3D(MidPoint4.X + 10.0, MidPoint4.Y), new WorkPlane(), 0.0, ref EntitiesTransformed);
			buControlCoreClass.cVector.BoxSizeCalculate(EntitiesTransformed, ref MinPoint4, ref MidPoint4, ref MaxPoint4);
			numericUpDown_5.Value = (decimal)(MaxPoint4.X - MinPoint4.X);
			numericUpDown_6.Value = (decimal)(MaxPoint4.Y - MinPoint4.Y);
			buViewer_1.AddEntities(EntitiesTransformed);
			buViewer_1.DrawEntities();
			buViewer_1.ZoomFit();
			buViewer_1.ZoomOut();
		}
		if (control.Name == button_2.Name)
		{
			Result = DialogResult.Cancel;
			if (FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == button_1.Name)
		{
			Profile = new ProfileItem();
			ProfileSet.MaterialTranspancy = (int)numericUpDown_1.Value;
			ProfileSet.SupportBlockZColor = buColorComboBox_1.Color;
			Profile.ItemName = textBox_2.Text;
			double result = 0.0;
			double.TryParse(comboBox_1.Text, out result);
			ProfileRunTimeSet.ProfileLength = result;
			ProfileRunTimeSet.ProfileMaxClamper = (int)numericUpDown_7.Value;
			SupportBlockY1Thickness = (double)numericUpDown_2.Value;
			SupportBlockY2Thickness = (double)numericUpDown_4.Value;
			SupportBlockZThickness = (double)numericUpDown_3.Value;
			if (SupportBlockY1Thickness < 0.0)
			{
				SupportBlockY1Thickness = 0.0;
			}
			if (SupportBlockY2Thickness < 0.0)
			{
				SupportBlockY2Thickness = 0.0;
			}
			if (SupportBlockZThickness < 0.0)
			{
				SupportBlockZThickness = 0.0;
			}
			Profile.Length = result;
			Profile.Skin = new MaterialSkin(Materials[comboBox_0.SelectedIndex]);
			Profile.Color = buColorComboBox_0.Color;
			Profile.Transparency = (int)numericUpDown_1.Value;
			new List<eEntities>();
			new List<Pnt3D>();
			Pnt3D MinPoint5 = new Pnt3D();
			Pnt3D MaxPoint5 = new Pnt3D();
			buControlCoreClass.cVector.BoxSizeCalculate(EntitiesTransformed, ref MinPoint5, ref MaxPoint5);
			Profile.Width = Math.Round(MaxPoint5.X - MinPoint5.X, 3);
			Profile.Height = Math.Round(MaxPoint5.Y - MinPoint5.Y, 3);
			double num = 1.0;
			double num2 = 1.0;
			num = (double)numericUpDown_5.Value / Profile.Width;
			num2 = (double)numericUpDown_6.Value / Profile.Height;
			if (!buCompare.EQ(num, 1.0, 0.001) | !buCompare.EQ(num2, 1.0, 0.001))
			{
				buControlCoreClass.cVector.Scale(MinPoint5, num, num2, 1.0, ScaleX: true, ScaleY: true, ScaleZ: false, new WorkPlane(), ref EntitiesTransformed);
			}
			buControlCoreClass.cSort.FindOutsideEntitiesFromAllEntities(new Pnt3D(), EntitiesTransformed, new WorkPlane(), ref Profile.OutterEntitites, ref Profile.OutterPoints);
			if (SupportBlockZThickness > 0.0)
			{
				Profile.SupportBlockZLength = result;
				Profile.SupportBlockZWidth = Profile.Width;
				Profile.SupportBlockZHeight = SupportBlockZThickness;
			}
			if (SupportBlockY1Thickness > 0.0)
			{
				Profile.SupportBlockY1Length = result;
				Profile.SupportBlockY1Width = SupportBlockY1Thickness;
				Profile.SupportBlockY1Height = Profile.Height;
			}
			if (SupportBlockY2Thickness > 0.0)
			{
				Profile.SupportBlockY2Length = result;
				Profile.SupportBlockY2Width = SupportBlockY2Thickness;
				Profile.SupportBlockY2Height = Profile.Height;
			}
			new List<List<eEntities>>();
			List<List<eEntities>> NotClosedEntities = new List<List<eEntities>>();
			buControlCoreClass.cSort.FindInternalEntitiesAtClosedContour(Profile.OutterPoints, EntitiesTransformed, new WorkPlane(), ref Profile.InnerEntities, ref NotClosedEntities);
			for (int i = 0; i <= Profile.InnerEntities.Count - 1; i++)
			{
				List<Pnt3D> Points = new List<Pnt3D>();
				buControlCoreClass.cVector.EntityToPoint(Profile.InnerEntities[i], buSystem.EntitiesResolution, ref Points);
				Profile.InnerPoints.Add(Points);
			}
			Result = DialogResult.OK;
			if (FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		double num = pnt3D_1.X - pnt3D_0.X;
		double num2 = pnt3D_1.Y - pnt3D_0.Y;
		double ratioX = (double)numericUpDown_5.Value / num;
		double ratioY = (double)numericUpDown_6.Value / num2;
		List<eEntities> CalcEntities = new List<eEntities>();
		if (control.Name == numericUpDown_5.Name)
		{
			buControlCoreClass.cVector.Scale(new Pnt3D(), ratioX, ratioY, 1.0, ScaleX: true, ScaleY: true, ScaleZ: false, new WorkPlane(), EntitiesOriginal, ref CalcEntities);
			buViewer_1.Entities.Clear();
			buViewer_1.AddEntities(CalcEntities);
			buViewer_1.DrawEntities();
			buViewer_1.ZoomFit();
			buViewer_1.ZoomOut();
		}
		if (control.Name == numericUpDown_6.Name)
		{
			buControlCoreClass.cVector.Scale(new Pnt3D(), ratioX, ratioY, 1.0, ScaleX: true, ScaleY: true, ScaleZ: false, new WorkPlane(), EntitiesOriginal, ref CalcEntities);
			buViewer_1.Entities.Clear();
			buViewer_1.AddEntities(CalcEntities);
			buViewer_1.DrawEntities();
			buViewer_1.ZoomFit();
			buViewer_1.ZoomOut();
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		try
		{
			int num = 1;
			bool_0 = true;
			if (textBox_0.Text.Length != 0)
			{
				buGrid_0.Dt.Clear();
				for (int i = 0; i <= list_0.Count - 1; i++)
				{
					string fileName = buFile.getFileName(list_0[i]);
					if (fileName.ToLower().IndexOf(textBox_0.Text.ToLower()) >= 0)
					{
						buGrid_0.AddNewRow(num, fileName);
						num++;
					}
				}
			}
			else
			{
				Class76.smethod_235(this);
			}
			bool_0 = false;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_4(object sender, DataGridViewCellEventArgs e)
	{
		int_0 = e.ColumnIndex;
		int_1 = e.RowIndex;
		if (int_1 >= 0)
		{
			Class76.smethod_418(AppPath.Profiles + "\\" + buGrid_0.Rows[int_1].Cells[1].Value.ToString(), this);
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
