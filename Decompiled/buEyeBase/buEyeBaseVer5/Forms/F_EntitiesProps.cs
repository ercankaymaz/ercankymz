using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_EntitiesProps : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public List<Entity> Entities = new List<Entity>();

	public LayerKeyedCollection Layers = new LayerKeyedCollection();

	public static List<string> Captions = new List<string>();

	public Design viewportPort = null;

	private int int_0 = -1;

	internal IContainer icontainer_0 = null;

	public DataGridView DGV_entitiesprops;

	internal Panel panel_0;

	internal ImageList imageList_0;

	internal Button button_0;

	internal ListBox listBox_0;

	public F_EntitiesProps()
	{
		Class186.smethod_408(this);
	}

	public void InitViewport()
	{
		if (viewportPort == null)
		{
			EyeCreateProps eyeCreateProps = new EyeCreateProps();
			eyeCreateProps.ShowToolBar = false;
			eyeCreateProps.ShowViewCube = false;
			eyeCreateProps.ShowCoordinateArrow = false;
			buEyeShotFunctions.CreateControlsTool(FirstCreate: true, eyeCreateProps, ref viewportPort);
			viewportPort.Dock = DockStyle.Fill;
			panel_0.Controls.Add(viewportPort);
		}
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (viewportPort == null)
		{
			EyeCreateProps eyeCreateProps = new EyeCreateProps();
			eyeCreateProps.ShowToolBar = false;
			eyeCreateProps.ShowViewCube = false;
			eyeCreateProps.ShowCoordinateArrow = false;
			buEyeShotFunctions.CreateControlsTool(FirstCreate: true, eyeCreateProps, ref viewportPort);
			viewportPort.Dock = DockStyle.Fill;
			viewportPort.Layers.Clear();
			viewportPort.Layers = Layers;
			panel_0.Controls.Add(viewportPort);
		}
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
		DGV_entitiesprops.RowHeadersVisible = false;
		DGV_entitiesprops.ColumnHeadersVisible = false;
		DGV_entitiesprops.AllowUserToAddRows = false;
		DGV_entitiesprops.AllowUserToResizeColumns = false;
		DGV_entitiesprops.AllowUserToResizeRows = false;
		viewportPort.Entities.Clear();
		for (int i = 0; i <= Entities.Count - 1; i++)
		{
			CustomData customData = null;
			if (Entities[i].EntityData != null && Entities[i].EntityData is CustomData)
			{
				customData = new CustomData((CustomData)Entities[i].EntityData);
			}
			string text = i + 1 + " - ";
			if (customData != null && customData.EntityName.Length > 0)
			{
				text = text + customData.EntityName + " - ";
			}
			Entities[i].GetType();
			text += Entities[i].GetType().Name;
			listBox_0.Items.Add(text);
			viewportPort.Entities.Add(buVector5.CopyEntities(Entities[i]));
		}
		viewportPort.SetView(viewType.Top);
		viewportPort.ZoomFit();
		viewportPort.ZoomOut(10);
		viewportPort.Invalidate();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
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

	public void Apply()
	{
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		if ((sender.GetType() == typeof(Control)) | (sender.GetType() == typeof(Button)))
		{
			control = (Control)sender;
			_ = control.Name;
		}
		if (sender.GetType() == typeof(ToolStripMenuItem))
		{
			_ = ((ToolStripMenuItem)sender).Name;
		}
		if (control.Name == button_0.Name)
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
	}

	internal void method_2(object sender, EventArgs e)
	{
		if (listBox_0.SelectedItems.Count <= 0)
		{
			return;
		}
		int_0 = listBox_0.SelectedIndex;
		if (int_0 < 0)
		{
			return;
		}
		List<string> Properties = new List<string>();
		buCall.buVector5_0.EntityToProperties(Entities[int_0], ref Properties);
		DGV_entitiesprops.Rows.Clear();
		DGV_entitiesprops.Columns.Clear();
		DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
		dataGridViewColumn.Width = Convert.ToInt32((double)DGV_entitiesprops.Width * 0.35);
		dataGridViewColumn.HeaderText = "Name";
		dataGridViewColumn.Name = "Name";
		dataGridViewColumn.ReadOnly = true;
		dataGridViewColumn.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
		dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
		DGV_entitiesprops.Columns.Add(dataGridViewColumn);
		DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
		dataGridViewColumn2.Width = Convert.ToInt32((double)DGV_entitiesprops.Width - (double)dataGridViewColumn.Width) - 25;
		dataGridViewColumn2.HeaderText = "Enable";
		dataGridViewColumn2.Name = "Enable";
		dataGridViewColumn2.ReadOnly = true;
		dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
		dataGridViewColumn2.CellTemplate = new DataGridViewTextBoxCell();
		DGV_entitiesprops.Columns.Add(dataGridViewColumn2);
		for (int i = 0; i <= Properties.Count - 1; i++)
		{
			string[] array = Properties[i].Split('=');
			if (array != null && array.Length == 2)
			{
				DGV_entitiesprops.Rows.Add(array[0], array[1]);
			}
		}
		for (int j = 0; j <= viewportPort.Entities.Count - 1; j++)
		{
			viewportPort.Entities[j].Selected = false;
		}
		viewportPort.Entities[int_0].Selected = true;
		viewportPort.ZoomFitSelectedLeaves();
		viewportPort.Invalidate();
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
