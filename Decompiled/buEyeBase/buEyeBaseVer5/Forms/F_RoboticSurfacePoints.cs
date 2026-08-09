using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_RoboticSurfacePoints : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	[CompilerGenerated]
	private ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler_0;

	[CompilerGenerated]
	private ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler_1;

	public List<RoboticSurfacePoint> SurfPoints = new List<RoboticSurfacePoint>();

	public bool isTangent = false;

	private int int_0 = -1;

	private int int_1 = -1;

	internal IContainer icontainer_0 = null;

	internal DataGridView dataGridView_0;

	internal Button button_0;

	internal ImageList imageList_0;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	internal Button button_4;

	internal Button button_5;

	internal Button button_6;

	internal NumericUpDown numericUpDown_0;

	internal Label label_0;

	public event ApplyCommandWithDataEventHandler DataValueChanged
	{
		[CompilerGenerated]
		add
		{
			ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler = applyCommandWithDataEventHandler_0;
			ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler2;
			do
			{
				applyCommandWithDataEventHandler2 = applyCommandWithDataEventHandler;
				ApplyCommandWithDataEventHandler value2 = (ApplyCommandWithDataEventHandler)Delegate.Combine(applyCommandWithDataEventHandler2, value);
				applyCommandWithDataEventHandler = Interlocked.CompareExchange(ref applyCommandWithDataEventHandler_0, value2, applyCommandWithDataEventHandler2);
			}
			while ((object)applyCommandWithDataEventHandler != applyCommandWithDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler = applyCommandWithDataEventHandler_0;
			ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler2;
			do
			{
				applyCommandWithDataEventHandler2 = applyCommandWithDataEventHandler;
				ApplyCommandWithDataEventHandler value2 = (ApplyCommandWithDataEventHandler)Delegate.Remove(applyCommandWithDataEventHandler2, value);
				applyCommandWithDataEventHandler = Interlocked.CompareExchange(ref applyCommandWithDataEventHandler_0, value2, applyCommandWithDataEventHandler2);
			}
			while ((object)applyCommandWithDataEventHandler != applyCommandWithDataEventHandler2);
		}
	}

	public event ApplyCommandWithDataEventHandler SelectedIndexChanged
	{
		[CompilerGenerated]
		add
		{
			ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler = applyCommandWithDataEventHandler_1;
			ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler2;
			do
			{
				applyCommandWithDataEventHandler2 = applyCommandWithDataEventHandler;
				ApplyCommandWithDataEventHandler value2 = (ApplyCommandWithDataEventHandler)Delegate.Combine(applyCommandWithDataEventHandler2, value);
				applyCommandWithDataEventHandler = Interlocked.CompareExchange(ref applyCommandWithDataEventHandler_1, value2, applyCommandWithDataEventHandler2);
			}
			while ((object)applyCommandWithDataEventHandler != applyCommandWithDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler = applyCommandWithDataEventHandler_1;
			ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler2;
			do
			{
				applyCommandWithDataEventHandler2 = applyCommandWithDataEventHandler;
				ApplyCommandWithDataEventHandler value2 = (ApplyCommandWithDataEventHandler)Delegate.Remove(applyCommandWithDataEventHandler2, value);
				applyCommandWithDataEventHandler = Interlocked.CompareExchange(ref applyCommandWithDataEventHandler_1, value2, applyCommandWithDataEventHandler2);
			}
			while ((object)applyCommandWithDataEventHandler != applyCommandWithDataEventHandler2);
		}
	}

	public F_RoboticSurfacePoints()
	{
		Class186.smethod_76(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		string headerText = "No";
		string headerText2 = "Sel";
		string headerText3 = "X Pos";
		string headerText4 = "Y Pos";
		string headerText5 = "Z Pos";
		string headerText6 = "A Angle";
		string headerText7 = "B Angle";
		string headerText8 = "C Angle";
		if (dataGridView_0.Columns.Count == 0)
		{
			DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
			dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn.Width = 40;
			dataGridViewColumn.HeaderText = headerText;
			dataGridViewColumn.Name = "No";
			dataGridViewColumn.ReadOnly = true;
			dataGridViewColumn.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn);
			DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
			dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn2.Width = 50;
			dataGridViewColumn2.HeaderText = headerText2;
			dataGridViewColumn2.Name = "Sel";
			dataGridViewColumn2.ReadOnly = false;
			dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn2.CellTemplate = new DataGridViewCheckBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn2);
			DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
			dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn3.Width = 100;
			dataGridViewColumn3.HeaderText = headerText3;
			dataGridViewColumn3.Name = "XPos";
			dataGridViewColumn3.ReadOnly = false;
			dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn3.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn3);
			DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
			dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn4.Width = 100;
			dataGridViewColumn4.HeaderText = headerText4;
			dataGridViewColumn4.Name = "YPos";
			dataGridViewColumn4.ReadOnly = false;
			dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn4.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn4);
			DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
			dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn5.Width = 100;
			dataGridViewColumn5.HeaderText = headerText5;
			dataGridViewColumn5.Name = "ZPos";
			dataGridViewColumn5.ReadOnly = false;
			dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn5.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn5);
			DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
			dataGridViewColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn6.Width = 100;
			dataGridViewColumn6.HeaderText = headerText6;
			dataGridViewColumn6.Name = "APos";
			dataGridViewColumn6.ReadOnly = false;
			dataGridViewColumn6.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn6.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn6);
			DataGridViewColumn dataGridViewColumn7 = new DataGridViewColumn();
			dataGridViewColumn7.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn7.Width = 100;
			dataGridViewColumn7.HeaderText = headerText7;
			dataGridViewColumn7.Name = "BPos";
			dataGridViewColumn7.ReadOnly = false;
			dataGridViewColumn7.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn7.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn7);
			DataGridViewColumn dataGridViewColumn8 = new DataGridViewColumn();
			dataGridViewColumn8.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn8.Width = 100;
			dataGridViewColumn8.HeaderText = headerText8;
			dataGridViewColumn8.Name = "CPos";
			dataGridViewColumn8.ReadOnly = false;
			dataGridViewColumn8.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn8.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn8);
		}
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToResizeColumns = false;
		Class186.smethod_303(this);
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = false;
	}

	public void LoadLanguage()
	{
		string callMethod = "NestSheetPart LoadLanguage";
		try
		{
			if (Captions.Count >= 33)
			{
				Text = Captions[0];
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		string text = "";
		if ((sender.GetType() == typeof(Control)) | (sender.GetType() == typeof(Button)))
		{
			control = (Control)sender;
			text = control.Name;
		}
		if (sender.GetType() == typeof(ToolStripMenuItem))
		{
			text = ((ToolStripMenuItem)sender).Name;
		}
		if (!(text == button_3.Name))
		{
		}
		if (!(text == button_2.Name))
		{
		}
		if (text == button_6.Name && ((int_0 >= 0) & (int_1 >= 2)))
		{
			double num = Convert.ToDouble(dataGridView_0.Rows[int_0].Cells[int_1].Value.ToString());
			num -= (double)numericUpDown_0.Value;
			dataGridView_0.Rows[int_0].Cells[int_1].Value = num.ToString();
			method_0(button_4, null);
		}
		if (text == button_5.Name && ((int_0 >= 0) & (int_1 >= 2)))
		{
			double num2 = Convert.ToDouble(dataGridView_0.Rows[int_0].Cells[int_1].Value.ToString());
			num2 += (double)numericUpDown_0.Value;
			dataGridView_0.Rows[int_0].Cells[int_1].Value = num2.ToString();
			method_0(button_4, null);
		}
		if (control.Name == button_0.Name)
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
		if (!(text == button_4.Name) || applyCommandWithDataEventHandler_0 == null)
		{
			return;
		}
		double num3 = 30.0;
		for (int i = 0; i <= dataGridView_0.Rows.Count - 1; i++)
		{
			bool enable = Convert.ToBoolean(dataGridView_0.Rows[i].Cells[1].Value.ToString());
			double num4 = Convert.ToDouble(dataGridView_0.Rows[i].Cells[2].Value.ToString());
			double num5 = Convert.ToDouble(dataGridView_0.Rows[i].Cells[3].Value.ToString());
			double z = Convert.ToDouble(dataGridView_0.Rows[i].Cells[4].Value.ToString());
			double a = Convert.ToDouble(dataGridView_0.Rows[i].Cells[5].Value.ToString());
			double b = Convert.ToDouble(dataGridView_0.Rows[i].Cells[6].Value.ToString());
			double c = Convert.ToDouble(dataGridView_0.Rows[i].Cells[7].Value.ToString());
			Point3D point3D = new Point3D(num4, num5, z);
			buCall.buVector5_0.PointAngle(new Point3D(SurfPoints[i].vecNormal.X, SurfPoints[i].vecNormal.Y, SurfPoints[i].vecNormal.Z), new Point3D(), Plane.XY);
			buCall.buVector5_0.PointAngle(new Point3D(SurfPoints[i].vecNormal.X, SurfPoints[i].vecNormal.Y, SurfPoints[i].vecNormal.Z), new Point3D(), Plane.XZ);
			buCall.buVector5_0.PointAngle(new Point3D(SurfPoints[i].vecNormal.X, SurfPoints[i].vecNormal.Y, SurfPoints[i].vecNormal.Z), new Point3D(), Plane.YZ);
			Line line = new Line(new Point3D(point3D.X, point3D.Y, point3D.Z), new Point3D(point3D.X + num3 * SurfPoints[i].vecNormal.X, point3D.Y + num3 * SurfPoints[i].vecNormal.Y, point3D.Z + num3 * SurfPoints[i].vecNormal.Z));
			SurfPoints[i].entNormal = line;
			SurfPoints[i].entTangent = buVector5.CopyEntities(line);
			if (SurfPoints[i].isLast)
			{
				SurfPoints[i].entTangent.Rotate(buConversion5.DegreeToRadian(-90.0), new Vector3D(SurfPoints[i].pntPre, SurfPoints[i].pntBase), new Point3D(point3D.X, point3D.Y, point3D.Z));
			}
			else
			{
				SurfPoints[i].entTangent.Rotate(buConversion5.DegreeToRadian(-90.0), new Vector3D(SurfPoints[i].pntBase, SurfPoints[i].pntNext), new Point3D(point3D.X, point3D.Y, point3D.Z));
			}
			buCall.buVector5_0.PointAngle(((Line)SurfPoints[i].entTangent).EndPoint, ((Line)SurfPoints[i].entTangent).StartPoint, Plane.XY);
			buCall.buVector5_0.PointAngle(((Line)SurfPoints[i].entTangent).EndPoint, ((Line)SurfPoints[i].entTangent).StartPoint, Plane.XZ);
			buCall.buVector5_0.PointAngle(((Line)SurfPoints[i].entTangent).EndPoint, ((Line)SurfPoints[i].entTangent).StartPoint, Plane.YZ);
			if (isTangent)
			{
				SurfPoints[i].pntTangent = new Pnt6D(point3D.X, point3D.Y, point3D.Z, a, b, c);
			}
			else
			{
				SurfPoints[i].pntNormal = new Pnt6D(point3D.X, point3D.Y, point3D.Z, a, b, c);
			}
			SurfPoints[i].Enable = enable;
		}
		applyCommandWithDataEventHandler_0(SurfPoints);
	}

	internal void method_1(object sender, DataGridViewCellEventArgs e)
	{
		if ((e.RowIndex >= 0) & (e.RowIndex <= SurfPoints.Count - 1))
		{
			int_0 = e.RowIndex;
			int_1 = e.ColumnIndex;
			if (applyCommandWithDataEventHandler_1 != null)
			{
				applyCommandWithDataEventHandler_1(int_0);
			}
		}
	}

	internal void method_2(object sender, DataGridViewCellEventArgs e)
	{
		if ((e.RowIndex >= 0) & (e.RowIndex <= SurfPoints.Count - 1))
		{
		}
	}

	internal void method_3(object sender, DataGridViewCellEventArgs e)
	{
		if ((e.ColumnIndex >= 0) & (e.RowIndex >= 0))
		{
			if ((e.ColumnIndex == 1) & (e.RowIndex <= SurfPoints.Count - 1))
			{
				SurfPoints[e.RowIndex].Enable = Convert.ToBoolean(dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			}
			if (!((e.ColumnIndex == 2) & (e.RowIndex <= SurfPoints.Count - 1)))
			{
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
