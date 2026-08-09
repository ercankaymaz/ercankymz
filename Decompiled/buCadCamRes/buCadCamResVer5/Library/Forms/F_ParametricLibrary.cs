using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buClass.UserFiles.buCad;
using buControls.DialogBox;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.buEntities;
using devDept;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Control.Labels;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using ns8;

namespace buCadCamResVer5.Library.Forms;

public class F_ParametricLibrary : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public List<EditorCustomData> OpenCustomData = new List<EditorCustomData>();

	public Design viewport = null;

	internal int int_0 = -1;

	private int int_1 = -1;

	internal List<string> list_0 = new List<string>();

	public List<buEntity> LibraryEntities = new List<buEntity>();

	private Color color_0 = Color.DarkOrange;

	private Color color_1 = Color.Blue;

	private Color color_2 = Color.Black;

	private Timer timer_0 = new Timer();

	private Timer timer_1 = new Timer();

	public Entity selectedEntity = null;

	private bool bool_0 = false;

	public setLibrary varLib = new setLibrary();

	private string string_0 = "Name";

	private string string_1 = "Char";

	private string string_2 = "Value";

	internal IContainer icontainer_0 = null;

	internal Panel panel_0;

	internal Panel panel_1;

	internal Panel panel_2;

	internal System.Windows.Forms.Label label_0;

	internal TextBox textBox_0;

	internal DataGridView dataGridView_0;

	internal System.Windows.Forms.Label label_1;

	internal System.Windows.Forms.Label label_2;

	internal ListBox listBox_0;

	internal Button button_0;

	internal Button button_1;

	internal Button button_2;

	internal ImageList imageList_0;

	internal Button button_3;

	internal Button button_4;

	internal Button button_5;

	internal Button button_6;

	internal Button button_7;

	internal Button button_8;

	public F_ParametricLibrary()
	{
		Class5.smethod_103(this);
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
		if (viewport == null)
		{
			CreateModelProperties Properties = new CreateModelProperties();
			clsInit.appCommand.EyeParameterToCreateModelProperties(clsVar.varPreviewViewport, clsVar.varMouse, ref Properties);
			Properties.BottomColor = Color.WhiteSmoke;
			Properties.TopColor = Color.Gainsboro;
			Properties.CoordinateSystemIconVisible = false;
			Properties.ViewCubeIconVisible = false;
			Properties.OrigineCaptionVisible = false;
			Properties.ToolBorVisible = false;
			Properties.OriginSymbolVisible = false;
			clsInit.cVector5.CreateModelControl(ref viewport, clsVar.UnlockKey, Properties);
			viewport.MouseMove += viewport_MouseMove;
			viewport.MouseDown += viewport_MouseDown;
			viewport.MouseDoubleClick += viewport_MouseDoubleClick;
			viewport.WorkCompleted += Desing_WorkCompleted;
			viewport.Layers.Add(new Layer("Gen", Color.Blue));
			viewport.Layers.RemoveAt(0);
			viewport.Selection.Color = Color.DarkOrange;
			panel_0.Controls.Add(viewport);
		}
		bool_0 = false;
		Class5.smethod_141(this);
		LoadLanguage();
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.ColumnHeadersVisible = false;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToResizeColumns = false;
		dataGridView_0.AllowUserToResizeRows = false;
		dataGridView_0.Columns.Clear();
		dataGridView_0.Rows.Clear();
		DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
		dataGridViewColumn.Width = 180;
		dataGridViewColumn.HeaderText = string_0;
		dataGridViewColumn.Name = string_0;
		dataGridViewColumn.ReadOnly = true;
		dataGridViewColumn.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
		dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
		dataGridView_0.Columns.Add(dataGridViewColumn);
		DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
		dataGridViewColumn2.Width = dataGridView_0.Width - dataGridViewColumn.Width - 10;
		dataGridViewColumn2.HeaderText = string_2;
		dataGridViewColumn2.Name = string_2;
		dataGridViewColumn2.CellTemplate = new DataGridViewTextBoxCell();
		dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
		dataGridViewColumn2.ReadOnly = false;
		dataGridView_0.Columns.Add(dataGridViewColumn2);
		selectedEntity = null;
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		timer_0.Enabled = true;
	}

	public void LoadLanguage()
	{
		try
		{
			if (Captions.Count > 10)
			{
				Text = Captions[0];
				label_0.Text = Captions[1];
				string_0 = Captions[8];
				string_1 = Captions[9];
				string_2 = Captions[10];
			}
		}
		catch (Exception)
		{
		}
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (listBox_0.Items.Count > 0)
		{
			method_3(null, null);
		}
		timer_0.Enabled = false;
	}

	private void timer_1_Tick(object sender, EventArgs e)
	{
		try
		{
			timer_1.Enabled = false;
			viewport.SetView(viewType.Top);
			viewport.Entities.Regen();
			viewport.ZoomFit(10);
			viewport.UpdateBoundingBox();
			viewport.Invalidate();
		}
		catch (Exception)
		{
		}
	}

	public void Desing_WorkCompleted(object sender, WorkCompletedEventArgs e)
	{
		if (e.WorkUnit is ReadFileAsync)
		{
			ReadFileAsync readFileAsync = (ReadFileAsync)e.WorkUnit;
			RegenOptions ro = new RegenOptions();
			_ = e.WorkUnit is ReadFile;
			readFileAsync.OpenTo(viewport, ro);
			FileOpened();
		}
		if (e.WorkUnit is WriteFileAsyncWithTextStyles)
		{
			clsInit.appEditor.SaveLibraryToZip();
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
					dataGridView_0.Rows.Add(Class5.smethod_25(result, this, buString5.GetAlfabetLetter(num)));
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

	internal void method_2(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_2.Name)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.SelectedPath = varLib.pathLibrary;
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				varLib.pathLibrary = folderBrowserDialog.SelectedPath;
				Init();
			}
		}
		if (control.Name == button_8.Name)
		{
			_ = viewport.CurrentSketch;
			viewport.CurrentSketch.Exit();
			viewport.Entities.Regen();
			viewport.Invalidate();
			clsInit.appEditor.cmdSaveLib(viewport);
			if (viewport.Entities.Count <= 0)
			{
			}
			foreach (devDept.Eyeshot.Control.Labels.Label label in viewport.ActiveViewport.Labels)
			{
				if (label is StackedLabel)
				{
					StackedLabel stackedLabel = label as StackedLabel;
					stackedLabel.Visible = false;
				}
			}
		}
		if (control.Name == button_4.Name)
		{
			viewport.ZoomFit();
			viewport.Invalidate();
		}
		if (control.Name == button_5.Name)
		{
			viewport.ZoomIn(10);
			viewport.Invalidate();
		}
		if (control.Name == button_6.Name)
		{
			viewport.ZoomOut(10);
			viewport.Invalidate();
		}
		if (control.Name == button_7.Name)
		{
			viewport.SetView(viewType.Top);
			viewport.Invalidate();
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
		if (!(control.Name == button_0.Name) || (!viewport.IsHandleCreated | viewport.IsBusy) || !PropertiesForm.Inited)
		{
			return;
		}
		PropertiesForm.Result = DialogResult.OK;
		if (viewport.Entities.Count > 0 && viewport.Entities[0] is SketchEntity)
		{
			clsLibrary.LibraryEntities = new List<buEntity>();
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
					clsLibrary.LibraryEntities.Add(buEntity2);
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
		if (PropertiesForm.Inited && ((listBox_0.Items.Count > 0) & (listBox_0.SelectedIndex >= 0)) && listBox_0.Items[listBox_0.SelectedIndex].GetType() == typeof(FileItem))
		{
			FileItem fileItem = new FileItem(((FileItem)listBox_0.Items[listBox_0.SelectedIndex]).FileFullName);
			viewport.Clear();
			Class5.smethod_70(fileItem.FileFullName, this);
			label_2.Text = AppLanguage.CadCamDynamic[32] + " " + AppLanguage.CadCamDynamic[40] + " : " + buFile.getFileNameWithoutExtension(fileItem.FileFullName);
		}
	}

	internal void method_4(object sender, DataGridViewCellEventArgs e)
	{
		int_0 = e.RowIndex;
		int_1 = e.ColumnIndex;
		Class5.smethod_122(this);
	}

	internal void method_5(object sender, DataGridViewCellEventArgs e)
	{
		if (PropertiesForm.Inited)
		{
			Class5.smethod_122(this);
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

	internal void method_6(object sender, DataGridViewCellEventArgs e)
	{
		int_0 = e.RowIndex;
		int_1 = e.ColumnIndex;
		Class5.smethod_122(this);
	}

	internal void method_7(object sender, EventArgs e)
	{
		try
		{
			int num = 1;
			if (textBox_0.Text.Length != 0)
			{
				listBox_0.Items.Clear();
				for (int i = 0; i <= list_0.Count - 1; i++)
				{
					string fileNameWithoutExtension = buFile.getFileNameWithoutExtension(list_0[i]);
					if (fileNameWithoutExtension.ToLower().IndexOf(textBox_0.Text.ToLower()) >= 0)
					{
						listBox_0.Items.Add(fileNameWithoutExtension);
						num++;
					}
				}
			}
			else
			{
				Class5.smethod_141(this);
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
		label_1.Text = "X: " + intPoint.X.ToString("f2") + " - Y: " + intPoint.Y.ToString("f2");
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
					if (clsInit.cVector5.isEntitySame(entity, viewport.Entities[i]) && num <= dataGridView_0.Rows.Count - 1)
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

	internal void method_8(object sender, MouseEventArgs e)
	{
		if (bool_0)
		{
		}
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
