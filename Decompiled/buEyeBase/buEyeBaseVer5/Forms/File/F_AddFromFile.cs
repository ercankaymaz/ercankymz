using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buCore;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using devDept.Serialization;
using ns71;

namespace buEyeBaseVer5.Forms.File;

public class F_AddFromFile : Form
{
	[CompilerGenerated]
	internal OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler_0;

	public FormProperties PropertiesForm = new FormProperties();

	public List<buEntity> EntitiesTransformed = new List<buEntity>();

	public List<LayerBase5> Layers = new List<LayerBase5>();

	public string Path = Application.StartupPath;

	public string FileName = Application.StartupPath;

	public bool KeepRatio = true;

	public bool MoveEntities = true;

	public bool MoveReverse = false;

	public MinMaxType MoveRef = MinMaxType.Min;

	public Design viewport = null;

	public List<string> ExtensionList = new List<string>();

	private List<string> list_0 = new List<string>();

	private int int_0 = -1;

	private int int_1 = -1;

	private string string_0 = "";

	private bool bool_0 = false;

	private Point3D point3D_0 = new Point3D();

	private Point3D point3D_1 = new Point3D();

	private Point3D point3D_2 = new Point3D();

	internal List<string> list_1 = new List<string>();

	private System.Windows.Forms.Timer timer_0 = null;

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

	internal Button button_3;

	internal Button button_4;

	internal Button button_5;

	internal Button button_6;

	internal NumericUpDown numericUpDown_0;

	internal Button button_7;

	internal Label label_2;

	internal Label label_3;

	internal TextBox textBox_1;

	internal Button button_8;

	internal NumericUpDown numericUpDown_1;

	internal NumericUpDown numericUpDown_2;

	public DataGridView grid_files;

	internal Panel panel_2;

	internal CheckBox checkBox_0;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal RadioButton radioButton_2;

	internal Button button_9;

	public event OkCommandWithTwoDataEventHandler ReadFile
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

	public F_AddFromFile()
	{
		Class186.smethod_322(this);
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
		checkBox_0.Checked = KeepRatio;
		if (viewport == null)
		{
			EyeCreateProps eyeCreateProps = new EyeCreateProps();
			eyeCreateProps.ShowToolBar = false;
			eyeCreateProps.ShowViewCube = true;
			eyeCreateProps.ShowCoordinateArrow = true;
			buEyeShotFunctions.CreateControlsTool(FirstCreate: true, eyeCreateProps, ref viewport);
			viewport.Dock = DockStyle.Fill;
			panel_2.Controls.Add(viewport);
		}
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
		bool_0 = false;
		if (ExtensionList.Count == 0)
		{
			ExtensionList.Add(".dxf");
			ExtensionList.Add(".bucadv5");
		}
		list_1 = new List<string>();
		for (int i = 0; i <= ExtensionList.Count - 1; i++)
		{
			List<string> Files = new List<string>();
			buFile.GetFilesInDirectory(Path, ExtensionList[i], ref Files);
			for (int j = 0; j <= Files.Count - 1; j++)
			{
				list_1.Add(Files[j]);
			}
		}
		LoadLanguage();
		Class186.smethod_78(this);
		if (timer_0 == null)
		{
			timer_0 = new System.Windows.Forms.Timer();
			timer_0.Tick += Init_Tick;
			timer_0.Interval = 100;
		}
		timer_0.Enabled = true;
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		Text = buLangTranslate.preDef.File + " " + buLangTranslate.preDef.Add;
		label_1.Text = buLangTranslate.preDef.Files;
		label_3.Text = buLangTranslate.preDef.Height;
		label_0.Text = buLangTranslate.preDef.Search;
		label_2.Text = buLangTranslate.preDef.Width;
		button_9.Text = buLangTranslate.preDef.Save;
		button_2.Text = buLangTranslate.preDef.Cancel;
		button_0.Text = buLangTranslate.preDef.Folder;
		button_1.Text = buLangTranslate.preDef.Ok;
		button_8.Text = buLangTranslate.preDef.Other + " " + buLangTranslate.preDef.Files;
		button_7.Text = buLangTranslate.preDef.Delete;
		checkBox_0.Text = buLangTranslate.preDef.KeepRatio;
	}

	public void Init_Tick(object sender, EventArgs e)
	{
		timer_0.Enabled = false;
		if (list_1.Count > 0)
		{
			grid_files.CurrentCell = grid_files.Rows[0].Cells[0];
			method_6(null, new DataGridViewCellEventArgs(0, 0));
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
		if (control.Name == button_0.Name)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.SelectedPath = Path;
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				Path = folderBrowserDialog.SelectedPath;
			}
			Init();
		}
		if (control.Name == button_8.Name)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "All Files |";
			for (int i = 0; i <= ExtensionList.Count - 1; i++)
			{
				if (i < ExtensionList.Count - 1)
				{
					openFileDialog.Filter = openFileDialog.Filter + "*" + ExtensionList[i] + ";";
				}
			}
			openFileDialog.InitialDirectory = Path;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				method_2(openFileDialog.FileName);
				string_0 = buFile5.getFileNameWithoutExtension(openFileDialog.FileName);
				Path = buFile5.GetPath(openFileDialog.FileName);
				list_0.Clear();
				list_0 = new List<string>();
				viewport.Invalidate();
			}
		}
		if (control.Name == button_7.Name && int_1 >= 0)
		{
			FileInfo fileInfo = new FileInfo(Path + "\\" + grid_files.Rows[int_1].Cells[1].Value.ToString());
			if (fileInfo.Exists)
			{
				string fileName = buFile.getFileName(fileInfo.FullName);
				if (buString.MessageBoxQuestion(AppLanguage.CadCamMessages[107] + " : " + fileName) == DialogResult.Yes)
				{
					fileInfo.Delete();
					Class186.smethod_78(this);
				}
			}
		}
		if (control.Name == button_3.Name)
		{
			Point3D MinPoint = new Point3D();
			Point3D MaxPoint = new Point3D();
			Point3D MidPoint = new Point3D();
			if (!radioButton_0.Checked)
			{
				if (!radioButton_1.Checked)
				{
					viewport.Entities.Rotate(buConversion5.DegreeToRadian((double)numericUpDown_0.Value), new Vector3D(0.0, 0.0, 1.0));
				}
				else
				{
					viewport.Entities.Rotate(buConversion5.DegreeToRadian((double)numericUpDown_0.Value), new Vector3D(0.0, 1.0, 0.0));
				}
			}
			else
			{
				viewport.Entities.Rotate(buConversion5.DegreeToRadian((double)numericUpDown_0.Value), new Vector3D(1.0, 0.0, 0.0));
			}
			viewport.Entities.RegenAllCurved();
			buCall.buVector5_0.BoxSizeCalculate(viewport.Entities, ref MinPoint, ref MidPoint, ref MaxPoint);
			viewport.Entities.Translate(0.0 - MaxPoint.X, 0.0 - MinPoint.Y, 0.0 - MinPoint.Z);
			viewport.Entities.RegenAllCurved();
			viewport.ZoomFit();
			viewport.Invalidate();
			PropertiesForm.Inited = false;
			numericUpDown_1.Value = (decimal)(MaxPoint.X - MinPoint.X);
			numericUpDown_2.Value = (decimal)(MaxPoint.Y - MinPoint.Y);
			list_0.Add("RotateLeft");
			PropertiesForm.Inited = true;
		}
		if (control.Name == button_4.Name)
		{
			Point3D MinPoint2 = new Point3D();
			Point3D MaxPoint2 = new Point3D();
			Point3D MidPoint2 = new Point3D();
			if (!radioButton_0.Checked)
			{
				if (!radioButton_1.Checked)
				{
					viewport.Entities.Rotate(buConversion5.DegreeToRadian(0.0 - (double)numericUpDown_0.Value), new Vector3D(0.0, 0.0, 1.0));
				}
				else
				{
					viewport.Entities.Rotate(buConversion5.DegreeToRadian((double)numericUpDown_0.Value), new Vector3D(0.0, 1.0, 0.0));
				}
			}
			else
			{
				viewport.Entities.Rotate(buConversion5.DegreeToRadian((double)numericUpDown_0.Value), new Vector3D(1.0, 0.0, 0.0));
			}
			viewport.Entities.RegenAllCurved();
			buCall.buVector5_0.BoxSizeCalculate(viewport.Entities, ref MinPoint2, ref MidPoint2, ref MaxPoint2);
			viewport.Entities.Translate(0.0 - MaxPoint2.X, 0.0 - MinPoint2.Y, 0.0 - MinPoint2.Z);
			viewport.Entities.RegenAllCurved();
			viewport.ZoomFit();
			viewport.Invalidate();
			PropertiesForm.Inited = false;
			numericUpDown_1.Value = (decimal)(MaxPoint2.X - MinPoint2.X);
			numericUpDown_2.Value = (decimal)(MaxPoint2.Y - MinPoint2.Y);
			list_0.Add("RotateRight");
			PropertiesForm.Inited = true;
		}
		if (control.Name == button_5.Name)
		{
			Point3D MinPoint3 = new Point3D();
			Point3D MaxPoint3 = new Point3D();
			Point3D MidPoint3 = new Point3D();
			for (int j = 0; j <= viewport.Entities.Count - 1; j++)
			{
				Vector3D vector3D = new Vector3D(new Point3D(), new Point3D(0.0, 10.0, 0.0));
				Plane plane = new Plane(new Point3D(), vector3D, Plane.XY.AxisZ);
				Mirror xform = new Mirror(plane);
				viewport.Entities[j].TransformBy(xform);
			}
			viewport.Entities.RegenAllCurved();
			buCall.buVector5_0.BoxSizeCalculate(viewport.Entities, ref MinPoint3, ref MidPoint3, ref MaxPoint3);
			viewport.Entities.Translate(0.0 - MaxPoint3.X, 0.0 - MinPoint3.Y, 0.0 - MinPoint3.Z);
			viewport.Entities.RegenAllCurved();
			viewport.ZoomFit();
			viewport.Invalidate();
			PropertiesForm.Inited = false;
			numericUpDown_1.Value = (decimal)(MaxPoint3.X - MinPoint3.X);
			numericUpDown_2.Value = (decimal)(MaxPoint3.Y - MinPoint3.Y);
			list_0.Add("MirrorHorizontal");
			PropertiesForm.Inited = true;
		}
		if (control.Name == button_6.Name)
		{
			Point3D MinPoint4 = new Point3D();
			Point3D MaxPoint4 = new Point3D();
			Point3D MidPoint4 = new Point3D();
			for (int k = 0; k <= viewport.Entities.Count - 1; k++)
			{
				Vector3D vector3D2 = new Vector3D(new Point3D(), new Point3D(10.0, 0.0, 0.0));
				Plane plane2 = new Plane(new Point3D(), vector3D2, Plane.XY.AxisZ);
				Mirror xform2 = new Mirror(plane2);
				viewport.Entities[k].TransformBy(xform2);
			}
			viewport.Entities.RegenAllCurved();
			buCall.buVector5_0.BoxSizeCalculate(viewport.Entities, ref MinPoint4, ref MidPoint4, ref MaxPoint4);
			viewport.Entities.Translate(0.0 - MaxPoint4.X, 0.0 - MinPoint4.Y, 0.0 - MinPoint4.Z);
			viewport.Entities.RegenAllCurved();
			viewport.ZoomFit();
			viewport.Invalidate();
			PropertiesForm.Inited = false;
			numericUpDown_1.Value = (decimal)(MaxPoint4.X - MinPoint4.X);
			numericUpDown_2.Value = (decimal)(MaxPoint4.Y - MinPoint4.Y);
			list_0.Add("MirrorVertical");
			PropertiesForm.Inited = true;
		}
		if (control.Name == button_9.Name)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "All Files |";
			for (int l = 0; l <= ExtensionList.Count - 1; l++)
			{
				if (l < ExtensionList.Count - 1)
				{
					saveFileDialog.Filter = saveFileDialog.Filter + "*" + ExtensionList[l] + ";";
				}
			}
			saveFileDialog.InitialDirectory = Path;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				Class186.smethod_451(this, saveFileDialog.FileName);
				string_0 = buFile5.getFileNameWithoutExtension(saveFileDialog.FileName);
				Path = buFile5.GetPath(saveFileDialog.FileName);
				Init();
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
		if (control.Name == button_1.Name)
		{
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
	}

	private void method_2(string string_1)
	{
		try
		{
			FileName = string_1;
			if (okCommandWithTwoDataEventHandler_0 != null)
			{
				okCommandWithTwoDataEventHandler_0(string_1, null);
			}
			FileInfo fileInfo = new FileInfo(string_1);
			if (fileInfo.Extension.ToLower() == ".dxf")
			{
				buFile5.OpenDxfDwg(ref viewport, string_1);
			}
			if (!(fileInfo.Extension.ToLower() == ".dwg"))
			{
				if (!(fileInfo.Extension.ToLower() == ".stl"))
				{
					if (!((fileInfo.Extension.ToLower() == ".step") | (fileInfo.Extension.ToLower() == ".stp")))
					{
						if (!((fileInfo.Extension.ToLower() == ".iges") | (fileInfo.Extension.ToLower() == ".igs")))
						{
							if (!(fileInfo.Extension.ToLower() == ".obj"))
							{
								if (fileInfo.Extension == ".bucadv5")
								{
									DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Base + "\\T");
									if (directoryInfo.Exists)
									{
										directoryInfo.Delete(recursive: true);
									}
									buFile.ExtractToFolder(AppPath.Base + "\\T", FileName);
									List<string> Files = new List<string>();
									buFile.getFiles(AppPath.Base + "\\T", ref Files);
									Files.Reverse();
									foreach (string item in Files)
									{
										FileInfo fileInfo2 = new FileInfo(item);
										if (!((fileInfo2.Extension == ".bupage") & fileInfo.Exists))
										{
											continue;
										}
										ReadFile readFile = new ReadFile(fileInfo2.FullName, new MyFileSerializer(contentType.GeometryAndTessellation));
										readFile.DoWork();
										RegenOptions ro = new RegenOptions();
										if (viewport != null)
										{
											if (viewport.Entities != null)
											{
												viewport.Entities.Clear();
											}
											readFile.OpenTo(viewport, ro);
										}
									}
								}
							}
							else
							{
								buFile5.OpenObj(ref viewport, string_1);
							}
						}
						else
						{
							buFile5.OpenIges(ref viewport, string_1);
						}
					}
					else
					{
						buFile5.OpenStep(ref viewport, string_1);
					}
				}
				else
				{
					buFile5.OpenStl(ref viewport, string_1);
				}
			}
			else
			{
				buFile5.OpenDxfDwg(ref viewport, string_1);
			}
			viewport.Layers[0].Color = Color.Gold;
			if (viewport.Entities.Count > 0)
			{
				for (int i = 0; i <= viewport.Entities.Count - 1; i++)
				{
					viewport.Entities[i].LineWeight = 2f;
					viewport.Entities[i].LineWeightMethod = colorMethodType.byEntity;
					viewport.Entities[i].Color = Color.Orange;
					if (viewport.Entities[i] is ICurve)
					{
						viewport.Entities[i].Color = Color.Black;
					}
					viewport.Entities[i].ColorMethod = colorMethodType.byEntity;
					if (!(viewport.Entities[i] is ICurve))
					{
					}
				}
				Point3D MinPoint = new Point3D();
				Point3D MidPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				buCall.buVector5_0.BoxSizeCalculate(viewport.Entities, ref MinPoint, ref MidPoint, ref MaxPoint);
				if (MoveEntities)
				{
					if (MoveRef != MinMaxType.Max)
					{
						if (!MoveReverse)
						{
							viewport.Entities.Translate(0.0 - MinPoint.X, 0.0 - MinPoint.Y, 0.0 - MinPoint.Z);
						}
						else
						{
							viewport.Entities.Translate(MinPoint.X, MinPoint.Y, MinPoint.Z);
						}
					}
					else if (!MoveReverse)
					{
						viewport.Entities.Translate(MaxPoint.X, MinPoint.Y, MinPoint.Z);
					}
					else
					{
						viewport.Entities.Translate(0.0 - MaxPoint.X, 0.0 - MinPoint.Y, 0.0 - MinPoint.Z);
					}
					viewport.Entities.RegenAllCurved();
					viewport.Entities.Regen();
				}
			}
			viewport.SetView(viewType.Top);
			viewport.ZoomFit(10);
			viewport.Invalidate();
			buCall.buVector5_0.BoxSizeCalculate(viewport.Entities, ref point3D_0, ref point3D_1, ref point3D_2);
			textBox_1.Text = buFile.getFileName(string_1);
			PropertiesForm.Inited = false;
			numericUpDown_1.Value = (decimal)(point3D_2.X - point3D_0.X);
			numericUpDown_2.Value = (decimal)(point3D_2.Y - point3D_0.Y);
			PropertiesForm.Inited = true;
		}
		catch (Exception)
		{
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		if (!PropertiesForm.Inited)
		{
			return;
		}
		Control control = new Control();
		control = (Control)sender;
		double num = (double)numericUpDown_1.Value / (viewport.Entities.BoxMax.X - viewport.Entities.BoxMin.X);
		double num2 = (double)numericUpDown_2.Value / (viewport.Entities.BoxMax.Y - viewport.Entities.BoxMin.Y);
		double sz = 1.0;
		new List<Entity>();
		if (control.Name == numericUpDown_1.Name && num != 0.0 && num2 != 0.0)
		{
			if (KeepRatio)
			{
				num2 = num;
				sz = num;
				PropertiesForm.Inited = false;
				numericUpDown_2.Value = Math.Round(numericUpDown_2.Value * (decimal)num2);
				PropertiesForm.Inited = true;
			}
			if (!KeepRatio && num != num2)
			{
				List<Entity> copiedEnt = new List<Entity>();
				List<Entity> devideEntities = new List<Entity>();
				List<Entity> list = new List<Entity>();
				for (int i = 0; i <= viewport.Entities.Count - 1; i++)
				{
					if (viewport.Entities[i].GetType() != typeof(ICurve))
					{
						Entity copiedEnt2 = null;
						buVector5.CopyEntities(viewport.Entities[i], ref copiedEnt2);
						list.Add(copiedEnt2);
					}
				}
				buVector5.CopyEntities(viewport.Entities, ref copiedEnt);
				EntityDevideData entityDevideData = new EntityDevideData();
				entityDevideData.Arc = true;
				entityDevideData.Circle = true;
				entityDevideData.Ellipse = true;
				entityDevideData.ArcLength = 0.1;
				entityDevideData.CircleLength = 0.1;
				entityDevideData.EllipseLength = 0.1;
				Color color = viewport.Entities[0].Color;
				buCall.buVector5_0.EntitiesDevideByLengthAsPolyline(copiedEnt, entityDevideData, ref devideEntities);
				viewport.Entities.Clear();
				for (int j = 0; j <= devideEntities.Count - 1; j++)
				{
					devideEntities[j].Color = color;
					devideEntities[j].ColorMethod = colorMethodType.byEntity;
					viewport.Entities.Add(devideEntities[j]);
				}
				for (int k = 0; k <= list.Count - 1; k++)
				{
					if (color == Color.Black)
					{
						color = Color.Gold;
					}
					list[k].Color = color;
					list[k].ColorMethod = colorMethodType.byEntity;
					viewport.Entities.Add(list[k]);
				}
			}
			viewport.Entities.Scale(num, num2, sz);
			viewport.Entities.RegenAllCurved(0.01);
			viewport.ZoomFit();
			viewport.Invalidate();
		}
		if (!(control.Name == numericUpDown_2.Name) || !(num != 0.0 && num2 != 0.0))
		{
			return;
		}
		if (KeepRatio)
		{
			num = num2;
			PropertiesForm.Inited = false;
			numericUpDown_1.Value = Math.Round(numericUpDown_1.Value * (decimal)num);
			PropertiesForm.Inited = true;
		}
		if (!KeepRatio && num != num2)
		{
			List<Entity> copiedEnt3 = new List<Entity>();
			List<Entity> devideEntities2 = new List<Entity>();
			List<Entity> list2 = new List<Entity>();
			for (int l = 0; l <= viewport.Entities.Count - 1; l++)
			{
				if (viewport.Entities[l].GetType() != typeof(ICurve))
				{
					Entity copiedEnt4 = null;
					buVector5.CopyEntities(viewport.Entities[l], ref copiedEnt4);
					list2.Add(copiedEnt4);
				}
			}
			buVector5.CopyEntities(viewport.Entities, ref copiedEnt3);
			EntityDevideData entityDevideData2 = new EntityDevideData();
			entityDevideData2.Arc = true;
			entityDevideData2.Circle = true;
			entityDevideData2.Ellipse = true;
			entityDevideData2.ArcLength = 0.1;
			entityDevideData2.CircleLength = 0.1;
			entityDevideData2.EllipseLength = 0.1;
			Color color2 = viewport.Entities[0].Color;
			buCall.buVector5_0.EntitiesDevideByLengthAsPolyline(copiedEnt3, entityDevideData2, ref devideEntities2);
			viewport.Entities.Clear();
			for (int m = 0; m <= devideEntities2.Count - 1; m++)
			{
				devideEntities2[m].Color = color2;
				devideEntities2[m].ColorMethod = colorMethodType.byEntity;
				viewport.Entities.Add(devideEntities2[m]);
			}
			for (int n = 0; n <= list2.Count - 1; n++)
			{
				if (color2 == Color.Black)
				{
					color2 = Color.Gold;
				}
				list2[n].Color = color2;
				list2[n].ColorMethod = colorMethodType.byEntity;
				viewport.Entities.Add(list2[n]);
			}
		}
		viewport.Entities.Scale(num, num2);
		viewport.Entities.RegenAllCurved(0.01);
		viewport.ZoomFit();
		viewport.Invalidate();
	}

	internal void method_4(object sender, EventArgs e)
	{
		try
		{
			int num = 1;
			bool_0 = true;
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
				Class186.smethod_78(this);
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

	internal void method_5(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited)
		{
			KeepRatio = checkBox_0.Checked;
		}
	}

	internal void method_6(object sender, DataGridViewCellEventArgs e)
	{
		int_0 = e.ColumnIndex;
		int_1 = e.RowIndex;
		if (int_1 >= 0)
		{
			string text = grid_files.Rows[int_1].Cells[1].Value.ToString();
			string[] array = text.Split('|');
			if (array.Length < 1)
			{
				string_0 = grid_files.Rows[int_1].Cells[1].Value.ToString();
			}
			else
			{
				method_2(Path + "\\" + array[0].Trim());
			}
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
