using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buClass.UserFiles.buCad;
using buControls.Controls;
using buControls.DialogBox;
using buControls.Forms.buControlForms.KeyPad;
using buCore;
using buEyeBaseVer5.buEntities;
using devDept;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Control.Labels;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using ns71;

namespace buEyeBaseVer5.Forms.Library;

public class F_SketchLibrary : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public List<EditorCustomData> OpenCustomData = new List<EditorCustomData>();

	public Design viewport = null;

	internal int int_0 = -1;

	private int int_1 = -1;

	internal List<string> list_0 = new List<string>();

	public List<buEntity> LibraryEntities = new List<buEntity>();

	private Timer timer_0 = new Timer();

	private Timer timer_1 = new Timer();

	public Entity selectedEntity = null;

	private bool bool_0 = false;

	public setLibrary varLib = new setLibrary();

	private string string_0 = "Angle";

	public bool ShowAux = false;

	internal IContainer icontainer_0 = null;

	internal Panel panel_0;

	internal System.Windows.Forms.Label label_0;

	internal ImageList imageList_0;

	public buGround ground_base;

	public buButton btn_topview;

	public buButton btn_zoomfit;

	public buButton btn_zoomout;

	public buButton lbl_name;

	public buButton btn_zoomin;

	public buButton btn_close;

	public buButton btn_cancel;

	public buButton btn_ok;

	internal Panel panel_1;

	internal DataGridView dataGridView_0;

	internal buTextBox buTextBox_0;

	internal buListBox buListBox_0;

	public buButton btn_settings;

	public buButton btn_folder;

	internal buLabel buLabel_0;

	public F_SketchLibrary()
	{
		Class186.smethod_570(this);
		timer_1.Interval = 100;
		timer_1.Tick += timer_1_Tick;
	}

	internal void method_0(object sender, EventArgs e)
	{
		timer_0.Interval = 50;
		timer_0.Tick += timer_0_Tick;
	}

	internal void method_1(object sender, FormClosingEventArgs e)
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
		LoadLanguage();
		DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Base + "\\L");
		if (directoryInfo.Exists)
		{
			setAttributesNormal(directoryInfo);
			directoryInfo.Delete(recursive: true);
		}
		if (viewport == null)
		{
			CreateModelProperties createModelProperties = new CreateModelProperties();
			createModelProperties.BottomColor = Color.WhiteSmoke;
			createModelProperties.TopColor = Color.Gainsboro;
			createModelProperties.CoordinateSystemIconVisible = false;
			createModelProperties.ViewCubeIconVisible = false;
			createModelProperties.OrigineCaptionVisible = false;
			createModelProperties.ToolBorVisible = false;
			createModelProperties.OriginSymbolVisible = false;
			buCall.buVector5_0.CreateModelControl(ref viewport, "", createModelProperties);
			viewport.MouseMove += viewport_MouseMove;
			viewport.MouseDown += viewport_MouseDown;
			viewport.MouseDoubleClick += viewport_MouseDoubleClick;
			viewport.WorkCompleted += Desing_WorkCompleted;
			viewport.Layers.Add(new devDept.Eyeshot.Layer("Gen", Color.Blue));
			viewport.Layers.RemoveAt(0);
			viewport.Selection.Color = Color.DarkOrange;
			panel_0.Controls.Add(viewport);
		}
		bool_0 = false;
		Class186.smethod_674(this);
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.ColumnHeadersVisible = false;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToResizeColumns = false;
		dataGridView_0.AllowUserToResizeRows = false;
		dataGridView_0.Columns.Clear();
		dataGridView_0.Rows.Clear();
		DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
		dataGridViewColumn.Width = 180;
		dataGridViewColumn.HeaderText = buLangTranslate.preDef.Name;
		dataGridViewColumn.Name = "Name";
		dataGridViewColumn.ReadOnly = true;
		dataGridViewColumn.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
		dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
		dataGridView_0.Columns.Add(dataGridViewColumn);
		if (ShowAux)
		{
			dataGridViewColumn.Width = 140;
			DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
			dataGridViewColumn2.Width = 80;
			dataGridViewColumn2.HeaderText = buLangTranslate.preDef.Value;
			dataGridViewColumn2.Name = "Value";
			dataGridViewColumn2.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn2.ReadOnly = false;
			dataGridView_0.Columns.Add(dataGridViewColumn2);
			DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
			dataGridViewColumn3.Width = dataGridView_0.Width - dataGridViewColumn.Width - dataGridViewColumn2.Width - 10;
			dataGridViewColumn3.HeaderText = string_0;
			dataGridViewColumn3.Name = "Aux";
			dataGridViewColumn3.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn3.ReadOnly = false;
			dataGridView_0.Columns.Add(dataGridViewColumn3);
		}
		else
		{
			DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
			dataGridViewColumn4.Width = dataGridView_0.Width - dataGridViewColumn.Width - 10;
			dataGridViewColumn4.HeaderText = buLangTranslate.preDef.Value;
			dataGridViewColumn4.Name = "Value";
			dataGridViewColumn4.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn4.ReadOnly = false;
			dataGridView_0.Columns.Add(dataGridViewColumn4);
			DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
			dataGridViewColumn5.Width = 1;
			dataGridViewColumn5.HeaderText = buLangTranslate.preDef.Value;
			dataGridViewColumn5.Name = "Aux";
			dataGridViewColumn5.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn5.ReadOnly = false;
			dataGridViewColumn5.Visible = false;
			dataGridView_0.Columns.Add(dataGridViewColumn5);
		}
		selectedEntity = null;
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		timer_0.Enabled = true;
	}

	public void setAttributesNormal(DirectoryInfo dir)
	{
		DirectoryInfo[] directories = dir.GetDirectories();
		foreach (DirectoryInfo attributesNormal in directories)
		{
			setAttributesNormal(attributesNormal);
		}
		FileInfo[] files = dir.GetFiles();
		foreach (FileInfo fileInfo in files)
		{
			fileInfo.Attributes = FileAttributes.Normal;
		}
	}

	public void LoadLanguage()
	{
		try
		{
			btn_cancel.Text = buLangTranslate.preDef.Cancel;
			btn_ok.Text = buLangTranslate.preDef.Ok;
			buTextBox_0.Caption.Caption = buLangTranslate.preDef.Search;
			ground_base.Text = buLangTranslate.preDef.Library;
		}
		catch (Exception)
		{
		}
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		try
		{
			if (buListBox_0.Items.Count > 0)
			{
				method_4(null, null);
			}
			timer_0.Enabled = false;
		}
		catch (Exception)
		{
		}
	}

	private void timer_1_Tick(object sender, EventArgs e)
	{
		try
		{
			if (viewport.IsHandleCreated)
			{
				timer_1.Enabled = false;
				viewport.SetView(viewType.Top);
				if (viewport.Entities != null && viewport.Entities.Count > 0)
				{
					viewport.Entities.Regen();
					viewport.Entities.RegenAllCurved();
					viewport.ZoomFit(10);
					viewport.UpdateBoundingBox();
				}
				viewport.Invalidate();
			}
		}
		catch (Exception)
		{
		}
	}

	public void Desing_WorkCompleted(object sender, WorkCompletedEventArgs e)
	{
		try
		{
			if (e.WorkUnit is ReadFileAsync)
			{
				ReadFileAsync readFileAsync = (ReadFileAsync)e.WorkUnit;
				RegenOptions ro = new RegenOptions();
				_ = e.WorkUnit is ReadFile;
				readFileAsync.OpenTo(viewport, ro);
				FileOpened();
			}
		}
		catch (Exception)
		{
		}
	}

	public void FileOpened()
	{
		selectedEntity = null;
		if (viewport.Entities.Count > 0)
		{
			if (viewport.Entities[0] is SketchEntity)
			{
				SketchEntity sketchEntity = viewport.Entities[0] as SketchEntity;
				if (OpenCustomData.Count > 0)
				{
					for (int i = 0; i <= OpenCustomData.Count - 1; i++)
					{
						if ((OpenCustomData[i].EntityIndex >= 0) & (OpenCustomData[i].EntityIndex <= sketchEntity.CurveList.Count - 1))
						{
							((Entity)sketchEntity.CurveList[OpenCustomData[i].EntityIndex]).EntityData = OpenCustomData[i];
						}
					}
				}
				sketchEntity.Edit(viewport);
				viewport.CurrentSketch.UpdateAndInvalidate();
			}
			foreach (devDept.Eyeshot.Control.Labels.Label label in viewport.ActiveViewport.Labels)
			{
				if (label is StackedLabel)
				{
					StackedLabel stackedLabel = label as StackedLabel;
					stackedLabel.Visible = false;
				}
			}
			int num = 0;
			dataGridView_0.Rows.Clear();
			foreach (Entity entity in viewport.Entities)
			{
				if (entity is Dimension)
				{
					double result = 0.0;
					double.TryParse(((Dimension)entity).TextString, out result);
					dataGridView_0.Rows.Add(Class186.smethod_14(result, buString5.GetAlfabetLetter(num), 0.0, this));
					num++;
				}
			}
		}
		DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Base + "\\L");
		if (directoryInfo.Exists)
		{
			directoryInfo.Delete(recursive: true);
		}
		timer_1.Enabled = true;
	}

	public void cmdSaveLib(Design Viewport, string FileName)
	{
		for (int i = 0; i <= Viewport.Entities.Count - 1; i++)
		{
			if (Viewport.Entities[i] is SketchEntity)
			{
				SketchEntity sketchEntity = Viewport.Entities[i] as SketchEntity;
				sketchEntity.Exit();
				Viewport.Entities.Regen();
				Viewport.Invalidate();
				FileInfo fileInfo = new FileInfo(FileName);
				string fileNameWithoutExtension = buFile5.getFileNameWithoutExtension(FileName);
				DirectoryInfo directoryInfo = new DirectoryInfo(fileInfo.DirectoryName + "\\" + fileNameWithoutExtension);
				if (directoryInfo.Exists)
				{
					directoryInfo.Delete(recursive: true);
				}
				Directory.CreateDirectory(directoryInfo.FullName);
				FileInfo fileInfo2 = new FileInfo(directoryInfo.FullName + "\\" + fileNameWithoutExtension + ".buLibEye");
				FileInfo fileInfo3 = new FileInfo(directoryInfo.FullName + "\\" + fileNameWithoutExtension + ".buLibSet");
				new FileInfo(FileName);
				SaveEditorCustomDataToFile(Viewport, fileInfo3.FullName);
				WriteFile writeFile = null;
				WriteFileParams writeFileParams = new WriteFileParams(Viewport.Document);
				writeFile = new WriteFile(writeFileParams, fileInfo2.FullName);
				Viewport.StartWork(writeFile);
			}
		}
	}

	public void SaveEditorCustomDataToFile(Design Viewport, string filename)
	{
		List<string> list = new List<string>();
		for (int i = 0; i <= Viewport.Entities.Count - 1; i++)
		{
			if (!(Viewport.Entities[i] is SketchEntity))
			{
				continue;
			}
			SketchEntity sketchEntity = Viewport.Entities[i] as SketchEntity;
			for (int j = 0; j <= sketchEntity.CurveList.Count - 1; j++)
			{
				if (!(((Entity)sketchEntity.CurveList[j]).EntityData is EditorCustomData))
				{
					continue;
				}
				EditorCustomData editorCustomData = ((Entity)sketchEntity.CurveList[j]).EntityData as EditorCustomData;
				editorCustomData.EntityIndex = j;
				if (editorCustomData.EntityIndex < 0 || editorCustomData.Commands.Count <= 0)
				{
					continue;
				}
				string text = editorCustomData.EntityIndex + " | ";
				string text2 = "";
				for (int k = 0; k <= editorCustomData.Commands.Count - 1; k++)
				{
					if (k > 0)
					{
						text2 = ";";
					}
					text = text + text2 + editorCustomData.Commands[k];
				}
				list.Add(text);
			}
		}
		buFile5.SaveToFile(list, filename);
	}

	internal void method_2(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == btn_folder.Name)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.SelectedPath = varLib.pathLibrary;
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				varLib.pathLibrary = folderBrowserDialog.SelectedPath;
				Init();
			}
		}
		if (control.Name == btn_zoomfit.Name)
		{
			viewport.Focus();
			viewport.ZoomFit();
			viewport.Invalidate();
		}
		if (control.Name == btn_zoomin.Name)
		{
			viewport.ZoomIn(10);
			viewport.Invalidate();
		}
		if (control.Name == btn_zoomout.Name)
		{
			viewport.ZoomOut(10);
			viewport.Invalidate();
		}
		if (control.Name == btn_topview.Name)
		{
			viewport.SetView(viewType.Top);
			viewport.Invalidate();
		}
		if ((control.Name == btn_cancel.Name) | (control.Name == btn_close.Name))
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
		if (!(control.Name == btn_ok.Name) || !PropertiesForm.Inited)
		{
			return;
		}
		PropertiesForm.Result = DialogResult.OK;
		if (viewport.Entities.Count > 0 && viewport.Entities[0] is SketchEntity)
		{
			SketchEntity sketchEntity = viewport.Entities[0] as SketchEntity;
			sketchEntity.Exit();
			LibraryEntities = new List<buEntity>();
			for (int i = 0; i <= sketchEntity.CurveList.Count - 1; i++)
			{
				buEntity buEntity2 = null;
				buEntity2 = buEntity.Copy((Entity)sketchEntity.CurveList[i]);
				if (((Entity)sketchEntity.CurveList[i]).EntityData != null && ((Entity)sketchEntity.CurveList[i]).EntityData is EditorCustomData)
				{
					EditorCustomData editorCustomData = ((Entity)sketchEntity.CurveList[i]).EntityData as EditorCustomData;
					buEntity2.Info.Commands = new List<string>();
					buEntity2.Info.Commands.AddRange(editorCustomData.Commands);
				}
				if (buEntity2 != null)
				{
					LibraryEntities.Add(buEntity2);
				}
			}
		}
		if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		buTextBox buTextBox2 = sender as buTextBox;
		if (AppBool.TouchPad)
		{
			F_KeyPadCharV1 f_KeyPadCharV = new F_KeyPadCharV1();
			f_KeyPadCharV.StartPosition = FormStartPosition.CenterParent;
			f_KeyPadCharV.Caption = buTextBox2.Caption.Caption;
			f_KeyPadCharV.ShowDialog(buTextBox2.Text.ToString());
			buTextBox2.Text = f_KeyPadCharV.Value;
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited && ((buListBox_0.Items.Count > 0) & (buListBox_0.SelectedIndex >= 0)) && buListBox_0.Items[buListBox_0.SelectedIndex].GetType() == typeof(FileItem))
		{
			FileItem fileItem = new FileItem(((FileItem)buListBox_0.Items[buListBox_0.SelectedIndex]).FileFullName);
			viewport.Clear();
			Class186.smethod_504(fileItem.FileFullName, this);
			lbl_name.Text = AppLanguage.CadCamDynamic[32] + " " + AppLanguage.CadCamDynamic[40] + " : " + buFile.getFileNameWithoutExtension(fileItem.FileFullName);
			buLabel_0.Text = buFile.getFileNameWithoutExtension(fileItem.FileFullName);
		}
	}

	internal void method_5(object sender, DataGridViewCellEventArgs e)
	{
		int_0 = e.RowIndex;
		int_1 = e.ColumnIndex;
		Class186.smethod_531(this);
		if (!AppBool.TouchPad)
		{
			return;
		}
		F_KeyPadNumV1 f_KeyPadNumV = new F_KeyPadNumV1();
		f_KeyPadNumV.StartPosition = FormStartPosition.CenterParent;
		f_KeyPadNumV.Caption = dataGridView_0.Rows[int_0].Cells[0].Value.ToString();
		if (int_1 == 1)
		{
			f_KeyPadNumV.ShowDialog(dataGridView_0.Rows[int_0].Cells[1].Value.ToString());
			if (buNumeric.IsNumeric(f_KeyPadNumV.Value))
			{
				dataGridView_0.Rows[int_0].Cells[1].Value = double.Parse(f_KeyPadNumV.Value);
			}
		}
		if (int_1 == 2)
		{
			f_KeyPadNumV.ShowDialog(dataGridView_0.Rows[int_0].Cells[2].Value.ToString());
			if (buNumeric.IsNumeric(f_KeyPadNumV.Value))
			{
				dataGridView_0.Rows[int_0].Cells[2].Value = double.Parse(f_KeyPadNumV.Value);
			}
		}
	}

	internal void method_6(object sender, DataGridViewCellEventArgs e)
	{
		if (PropertiesForm.Inited)
		{
			Class186.smethod_531(this);
			string s = dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
			double result = 0.0;
			double.TryParse(s, out result);
			if (selectedEntity != null)
			{
				VisualConstraint constraint = viewport.CurrentSketch.GetConstraint(selectedEntity);
				((ValueVisualConstraint)constraint).Value = result;
				viewport.CurrentSketch.UpdateAndInvalidate();
			}
		}
	}

	internal void method_7(object sender, DataGridViewCellEventArgs e)
	{
		int_0 = e.RowIndex;
		int_1 = e.ColumnIndex;
		Class186.smethod_531(this);
	}

	internal void method_8(object sender, EventArgs e)
	{
		try
		{
			int num = 1;
			if (buTextBox_0.Text.Length != 0)
			{
				buListBox_0.Items.Clear();
				for (int i = 0; i <= list_0.Count - 1; i++)
				{
					string fileNameWithoutExtension = buFile.getFileNameWithoutExtension(list_0[i]);
					if (fileNameWithoutExtension.ToLower().IndexOf(buTextBox_0.Text.ToLower()) >= 0)
					{
						buListBox_0.Items.Add(fileNameWithoutExtension);
						num++;
					}
				}
			}
			else
			{
				Class186.smethod_674(this);
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	private void viewport_MouseMove(object sender, MouseEventArgs e)
	{
		Point3D intPoint = new Point3D();
		viewport.ScreenToPlane(e.Location, Plane.XY, out intPoint);
		label_0.Text = "X: " + intPoint.X.ToString("f2") + " - Y: " + intPoint.Y.ToString("f2");
	}

	private void viewport_MouseDown(object sender, MouseEventArgs e)
	{
		int[] allEntitiesUnderMouseCursor = viewport.GetAllEntitiesUnderMouseCursor(e.Location);
		if (allEntitiesUnderMouseCursor != null && allEntitiesUnderMouseCursor.Length != 0 && viewport.Entities[allEntitiesUnderMouseCursor[0]].GetType().BaseType == typeof(Dimension) && viewport.Entities[allEntitiesUnderMouseCursor[0]].EntityData != null)
		{
		}
	}

	private void viewport_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		SelectedItem itemUnderMouseCursor = viewport.GetItemUnderMouseCursor(e.Location);
		if (itemUnderMouseCursor == null)
		{
			return;
		}
		Entity entity = itemUnderMouseCursor.Item as Entity;
		VisualConstraint constraint = viewport.CurrentSketch.GetConstraint(entity);
		if (!(constraint is ValueVisualConstraint))
		{
			return;
		}
		DialogBoxInput dialogBoxInput = new DialogBoxInput();
		dialogBoxInput.Value = ((ValueVisualConstraint)constraint).Value;
		dialogBoxInput.StartPosition = FormStartPosition.CenterParent;
		dialogBoxInput.Init();
		dialogBoxInput.SelectAll();
		dialogBoxInput.ShowDialog();
		if (dialogBoxInput.Result == DialogResult.OK)
		{
			((ValueVisualConstraint)constraint).Value = dialogBoxInput.Value;
			int num = 0;
			for (int i = 0; i <= viewport.Entities.Count - 1; i++)
			{
				if (viewport.Entities[i] is Dimension)
				{
					if (buCall.buVector5_0.isEntitySame(entity, viewport.Entities[i]) && num <= dataGridView_0.Rows.Count - 1)
					{
						PropertiesForm.Inited = false;
						dataGridView_0.Rows[num].Cells[1].Value = dialogBoxInput.Value;
					}
					num++;
				}
			}
		}
		viewport.CurrentSketch.UpdateAndInvalidate();
		PropertiesForm.Inited = true;
	}

	internal void method_9(object sender, KeyEventArgs e)
	{
		bool_0 = e.Control;
	}

	internal void method_10(object sender, KeyEventArgs e)
	{
		bool_0 = false;
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
