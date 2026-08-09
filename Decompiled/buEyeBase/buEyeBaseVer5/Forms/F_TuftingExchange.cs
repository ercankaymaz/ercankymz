using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_TuftingExchange : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public TuftingSequenceItem TuftSequence = new TuftingSequenceItem();

	public List<Entity> AllEntities = new List<Entity>();

	public LayerBase5 layerSelected = new LayerBase5();

	private Design design_0 = null;

	private Color color_0 = Color.Black;

	private int int_0 = -1;

	private int int_1 = -1;

	private int int_2 = -1;

	private int int_3 = -1;

	private Timer timer_0 = new Timer();

	private IContainer icontainer_0 = null;

	internal Button button_0;

	internal ImageList imageList_0;

	internal Button button_1;

	internal Panel panel_0;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal RadioButton radioButton_2;

	internal RadioButton radioButton_3;

	internal ListView listView_0;

	internal Label label_0;

	internal TextBox textBox_0;

	internal Panel panel_1;

	internal Button button_2;

	internal Button button_3;

	internal Button button_4;

	internal Label label_1;

	internal NumericUpDown numericUpDown_0;

	internal Button button_5;

	internal Button button_6;

	internal RadioButton radioButton_4;

	internal RadioButton radioButton_5;

	public F_TuftingExchange()
	{
		Class186.smethod_89(this);
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
		if (design_0 == null)
		{
			EyeCreateProps eyeCreateProps = new EyeCreateProps();
			eyeCreateProps.ShowToolBar = false;
			eyeCreateProps.ShowViewCube = false;
			eyeCreateProps.ShowCoordinateArrow = false;
			buEyeShotFunctions.CreateControlsTool(FirstCreate: true, eyeCreateProps, ref design_0);
			design_0.Dock = DockStyle.Fill;
			panel_1.Controls.Add(design_0);
		}
		listView_0.HeaderStyle = ColumnHeaderStyle.None;
		listView_0.View = System.Windows.Forms.View.Details;
		listView_0.FullRowSelect = true;
		listView_0.Columns.Add("", -2);
		listView_0.Columns[0].Width = listView_0.Width - 5;
		textBox_0.Text = layerSelected.Name;
		for (int i = 0; i <= TuftSequence.SortedEntities.Count - 1; i++)
		{
			string text = i + 1 + " - Path";
			ListViewItem listViewItem = new ListViewItem(text);
			listViewItem.Checked = true;
			listView_0.Items.Add(listViewItem);
			Entity copiedEnt = null;
			buVector5.CopyEntities(TuftSequence.SortedEntities[i], ref copiedEnt);
			copiedEnt.ColorMethod = colorMethodType.byEntity;
			copiedEnt.LayerName = design_0.Layers[0].Name;
			copiedEnt.Color = layerSelected.LayerColor;
			copiedEnt.LineWeightMethod = colorMethodType.byEntity;
			copiedEnt.LineWeight = 2f;
			design_0.Entities.Add(copiedEnt);
			color_0 = layerSelected.LayerColor;
		}
		for (int j = 0; j <= AllEntities.Count - 1; j++)
		{
			Entity copiedEnt2 = null;
			buVector5.CopyEntities(AllEntities[j], ref copiedEnt2);
			copiedEnt2.ColorMethod = colorMethodType.byEntity;
			copiedEnt2.LayerName = design_0.Layers[0].Name;
			copiedEnt2.Color = Color.Gray;
			design_0.Entities.Add(copiedEnt2);
		}
		design_0.SetView(viewType.Top, fit: true, animate: false);
		design_0.Invalidate();
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	internal void method_0(object sender, EventArgs e)
	{
		timer_0.Interval = 50;
		timer_0.Tick += timer_0_Tick;
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
		if (control.Name == button_2.Name && int_0 >= 0)
		{
			if (!radioButton_3.Checked)
			{
				if (!radioButton_1.Checked)
				{
					if (!radioButton_2.Checked)
					{
						if (!radioButton_0.Checked)
						{
							if (!radioButton_5.Checked)
							{
								if (radioButton_5.Checked && ((int_2 >= 0) & (int_3 >= 0) & (int_2 != int_3)))
								{
									Entity copiedEnt = null;
									buVector5.CopyEntities(TuftSequence.SortedEntities[int_3], ref copiedEnt);
									TuftSequence.SortedEntities.RemoveAt(int_3);
									if (int_2 >= TuftSequence.SortedEntities.Count - 1)
									{
										TuftSequence.SortedEntities.Add(copiedEnt);
									}
									else
									{
										TuftSequence.SortedEntities.Insert(int_2 + 1, copiedEnt);
									}
									Entity copiedEnt2 = null;
									buVector5.CopyEntities(design_0.Entities[int_3], ref copiedEnt2);
									design_0.Entities.RemoveAt(int_3);
									if (int_2 >= design_0.Entities.Count - 1)
									{
										design_0.Entities.Add(copiedEnt2);
									}
									else
									{
										design_0.Entities.Insert(int_2 + 1, copiedEnt2);
									}
									design_0.Entities.Regen();
									design_0.Invalidate();
									listView_0.SelectedItems.Clear();
									listView_0.Items[int_2 + 1].Selected = true;
									listView_0.Invalidate();
								}
							}
							else if ((int_2 >= 0) & (int_3 >= 0) & (int_2 != int_3))
							{
								Entity copiedEnt3 = null;
								buVector5.CopyEntities(TuftSequence.SortedEntities[int_3], ref copiedEnt3);
								TuftSequence.SortedEntities.RemoveAt(int_3);
								TuftSequence.SortedEntities.Insert(int_2, copiedEnt3);
								Entity copiedEnt4 = null;
								buVector5.CopyEntities(design_0.Entities[int_3], ref copiedEnt4);
								design_0.Entities.RemoveAt(int_3);
								design_0.Entities.Insert(int_2, copiedEnt4);
								design_0.Entities.Regen();
								design_0.Invalidate();
								listView_0.SelectedItems.Clear();
								listView_0.Items[int_2].Selected = true;
								listView_0.Invalidate();
							}
						}
						else if (int_0 < TuftSequence.SortedEntities.Count - 1)
						{
							Entity copiedEnt5 = null;
							buVector5.CopyEntities(TuftSequence.SortedEntities[int_0], ref copiedEnt5);
							TuftSequence.SortedEntities.RemoveAt(int_0);
							TuftSequence.SortedEntities.Insert(int_0 + 1, copiedEnt5);
							Entity copiedEnt6 = null;
							buVector5.CopyEntities(design_0.Entities[int_0], ref copiedEnt6);
							design_0.Entities.RemoveAt(int_0);
							design_0.Entities.Insert(int_0 + 1, copiedEnt6);
							design_0.Entities.Regen();
							design_0.Invalidate();
							listView_0.SelectedItems.Clear();
							listView_0.Items[int_0 + 1].Selected = true;
							listView_0.Invalidate();
						}
					}
					else if (int_0 >= 1)
					{
						Entity copiedEnt7 = null;
						buVector5.CopyEntities(TuftSequence.SortedEntities[int_0], ref copiedEnt7);
						TuftSequence.SortedEntities.RemoveAt(int_0);
						TuftSequence.SortedEntities.Insert(int_0 - 1, copiedEnt7);
						Entity copiedEnt8 = null;
						buVector5.CopyEntities(design_0.Entities[int_0], ref copiedEnt8);
						design_0.Entities.RemoveAt(int_0);
						design_0.Entities.Insert(int_0 - 1, copiedEnt8);
						design_0.Entities.Regen();
						design_0.Invalidate();
						listView_0.SelectedItems.Clear();
						listView_0.Items[int_0 - 1].Selected = true;
						listView_0.Invalidate();
					}
				}
				else
				{
					Entity copiedEnt9 = null;
					buVector5.CopyEntities(TuftSequence.SortedEntities[int_0], ref copiedEnt9);
					TuftSequence.SortedEntities.RemoveAt(int_0);
					TuftSequence.SortedEntities.Add(copiedEnt9);
					Entity copiedEnt10 = null;
					buVector5.CopyEntities(design_0.Entities[int_0], ref copiedEnt10);
					design_0.Entities.RemoveAt(int_0);
					design_0.Entities.Insert(TuftSequence.SortedEntities.Count - 1, copiedEnt10);
					design_0.Entities.Regen();
					design_0.Invalidate();
					listView_0.SelectedItems.Clear();
					listView_0.Items[TuftSequence.SortedEntities.Count - 1].Selected = true;
					listView_0.Invalidate();
				}
			}
			else
			{
				Entity copiedEnt11 = null;
				buVector5.CopyEntities(TuftSequence.SortedEntities[int_0], ref copiedEnt11);
				TuftSequence.SortedEntities.RemoveAt(int_0);
				TuftSequence.SortedEntities.Insert(0, copiedEnt11);
				Entity copiedEnt12 = null;
				buVector5.CopyEntities(design_0.Entities[int_0], ref copiedEnt12);
				design_0.Entities.RemoveAt(int_0);
				design_0.Entities.Insert(0, copiedEnt12);
				design_0.Entities.Regen();
				design_0.Invalidate();
				listView_0.SelectedItems.Clear();
				listView_0.Items[0].Selected = true;
				listView_0.Invalidate();
			}
		}
		if (control.Name == button_0.Name)
		{
			Apply();
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
		if (control.Name == button_5.Name && int_0 >= 0)
		{
			int_2 = int_0;
			for (int i = 0; i <= design_0.Entities.Count - 1; i++)
			{
				if (int_2 != i)
				{
					if (int_3 != i)
					{
						design_0.Entities[i].Color = color_0;
					}
					else
					{
						design_0.Entities[i].Color = Color.Cyan;
					}
				}
				else
				{
					design_0.Entities[i].Color = Color.Lime;
				}
			}
			design_0.Invalidate();
		}
		if (control.Name == button_6.Name && int_0 >= 0)
		{
			int_3 = int_0;
			for (int j = 0; j <= design_0.Entities.Count - 1; j++)
			{
				if (int_2 != j)
				{
					if (int_3 != j)
					{
						design_0.Entities[j].Color = color_0;
					}
					else
					{
						design_0.Entities[j].Color = Color.Cyan;
					}
				}
				else
				{
					design_0.Entities[j].Color = Color.Lime;
				}
			}
			design_0.Invalidate();
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
		if (control.Name == button_3.Name)
		{
			timer_0.Interval = (int)numericUpDown_0.Value;
			timer_0.Enabled = true;
		}
		if (!(control.Name == button_4.Name))
		{
			return;
		}
		if (!timer_0.Enabled)
		{
			if (!timer_0.Enabled)
			{
				int_1 = 0;
			}
		}
		else
		{
			timer_0.Enabled = false;
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		if (listView_0.SelectedItems.Count <= 0)
		{
			return;
		}
		int_0 = listView_0.SelectedItems[0].Index;
		if (int_0 >= 0)
		{
			for (int i = 0; i <= design_0.Entities.Count - 1; i++)
			{
				design_0.Entities[i].Selected = false;
			}
			design_0.Entities[int_0].Selected = true;
			if (design_0.Entities.Count >= 2)
			{
				if (design_0.Entities[design_0.Entities.Count - 1] is Brep)
				{
					design_0.Entities.RemoveAt(design_0.Entities.Count - 1);
				}
				if (design_0.Entities[design_0.Entities.Count - 1] is Brep)
				{
					design_0.Entities.RemoveAt(design_0.Entities.Count - 1);
				}
			}
			Brep brep = Brep.CreateBox(10.0, 10.0, 1.0);
			brep.Translate(((ICurve)design_0.Entities[int_0]).StartPoint.X - 5.0, ((ICurve)design_0.Entities[int_0]).StartPoint.Y - 5.0, -1.5);
			brep.ColorMethod = colorMethodType.byEntity;
			brep.Color = Color.Lime;
			design_0.Entities.Add(brep);
			Brep brep2 = Brep.CreateCylinder(5.0, 1.0);
			brep2.Translate(((ICurve)design_0.Entities[int_0]).EndPoint.X, ((ICurve)design_0.Entities[int_0]).EndPoint.Y, -1.5);
			brep2.ColorMethod = colorMethodType.byEntity;
			brep2.Color = Color.Cyan;
			design_0.Entities.Add(brep2);
		}
		design_0.Invalidate();
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (!((int_1 >= 0) & (int_1 <= TuftSequence.SortedEntities.Count - 1)))
		{
			int_1 = 0;
			timer_0.Enabled = false;
		}
		else
		{
			listView_0.SelectedItems.Clear();
			listView_0.Items[int_1].Selected = true;
			int_1++;
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
