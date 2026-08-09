using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using ns71;

namespace buEyeBaseVer5.Forms.Foam;

public class F_FoamSpeedList : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public List<camRadiusFeed> RadiusFeedList = new List<camRadiusFeed>();

	public List<camLengthFeed> LengthFeedList = new List<camLengthFeed>();

	public int SelectedRadiusRowSheet = -1;

	public int SelectedLengthRowSheet = -1;

	private IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal ImageList imageList_1;

	internal ImageList imageList_2;

	internal DataGridView dataGridView_0;

	internal DataGridView dataGridView_1;

	public Button btn_addradius;

	public Button btn_addlength;

	public Button btn_removerad;

	public Button btn_removelen;

	public F_FoamSpeedList()
	{
		Class186.smethod_618(this);
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
		ControlUpdate();
		LoadLanguage();
		if (dataGridView_1.Columns.Count == 0)
		{
			DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
			dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn.Width = 40;
			dataGridViewColumn.HeaderText = buLangTranslate.preDef.No;
			dataGridViewColumn.Name = buLangTranslate.preDef.No;
			dataGridViewColumn.ReadOnly = true;
			dataGridViewColumn.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_1.Columns.Add(dataGridViewColumn);
			DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
			dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn2.Width = 120;
			dataGridViewColumn2.HeaderText = buLangTranslate.preDef.Min + " " + buLangTranslate.preDef.Length;
			dataGridViewColumn2.Name = buLangTranslate.preDef.Min + " " + buLangTranslate.preDef.Length;
			dataGridViewColumn2.ReadOnly = false;
			dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn2.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_1.Columns.Add(dataGridViewColumn2);
			DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
			dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn3.Width = 120;
			dataGridViewColumn2.HeaderText = buLangTranslate.preDef.Max + " " + buLangTranslate.preDef.Length;
			dataGridViewColumn3.Name = buLangTranslate.preDef.Max + " " + buLangTranslate.preDef.Length;
			dataGridViewColumn3.ReadOnly = false;
			dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn3.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_1.Columns.Add(dataGridViewColumn3);
			DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
			dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn4.Width = 120;
			dataGridViewColumn2.HeaderText = buLangTranslate.preDef.Speed;
			dataGridViewColumn4.Name = buLangTranslate.preDef.Speed;
			dataGridViewColumn4.ReadOnly = false;
			dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn4.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_1.Columns.Add(dataGridViewColumn4);
		}
		if (dataGridView_0.Columns.Count == 0)
		{
			DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
			dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn5.Width = 40;
			dataGridViewColumn5.HeaderText = buLangTranslate.preDef.No;
			dataGridViewColumn5.Name = buLangTranslate.preDef.No;
			dataGridViewColumn5.ReadOnly = true;
			dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn5.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn5);
			DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
			dataGridViewColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn6.Width = 120;
			dataGridViewColumn6.HeaderText = buLangTranslate.preDef.Min + " " + buLangTranslate.preDef.Radius;
			dataGridViewColumn6.Name = buLangTranslate.preDef.Min + " " + buLangTranslate.preDef.Radius;
			dataGridViewColumn6.ReadOnly = false;
			dataGridViewColumn6.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn6.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn6);
			DataGridViewColumn dataGridViewColumn7 = new DataGridViewColumn();
			dataGridViewColumn7.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn7.Width = 120;
			dataGridViewColumn6.HeaderText = buLangTranslate.preDef.Max + " " + buLangTranslate.preDef.Radius;
			dataGridViewColumn7.Name = buLangTranslate.preDef.Max + " " + buLangTranslate.preDef.Radius;
			dataGridViewColumn7.ReadOnly = false;
			dataGridViewColumn7.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn7.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn7);
			DataGridViewColumn dataGridViewColumn8 = new DataGridViewColumn();
			dataGridViewColumn8.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn8.Width = 120;
			dataGridViewColumn6.HeaderText = buLangTranslate.preDef.Speed;
			dataGridViewColumn8.Name = buLangTranslate.preDef.Speed;
			dataGridViewColumn8.ReadOnly = false;
			dataGridViewColumn8.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn8.CellTemplate = new DataGridViewTextBoxCell();
			dataGridView_0.Columns.Add(dataGridViewColumn8);
		}
		for (int i = 0; i <= RadiusFeedList.Count - 1; i++)
		{
			DataGridViewRowCollection rows = dataGridView_0.Rows;
			double minRadius = RadiusFeedList[i].MinRadius;
			double maxRadius = RadiusFeedList[i].MaxRadius;
			double feed = RadiusFeedList[i].Feed;
			rows.Add(Class186.smethod_652(i + 1, minRadius, this, maxRadius, feed));
		}
		for (int j = 0; j <= LengthFeedList.Count - 1; j++)
		{
			DataGridViewRowCollection rows2 = dataGridView_1.Rows;
			double minLength = LengthFeedList[j].MinLength;
			double maxLength = LengthFeedList[j].MaxLength;
			double feed2 = LengthFeedList[j].Feed;
			rows2.Add(Class186.smethod_98(minLength, feed2, maxLength, j + 1, this));
		}
		dataGridView_1.RowHeadersVisible = false;
		dataGridView_1.AllowUserToAddRows = false;
		dataGridView_1.AllowUserToResizeColumns = false;
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToResizeColumns = false;
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

	public void ControlUpdate()
	{
	}

	public void Apply()
	{
		RadiusFeedList.Clear();
		LengthFeedList.Clear();
		for (int i = 0; i <= dataGridView_0.Rows.Count - 1; i++)
		{
			camRadiusFeed camRadiusFeed2 = new camRadiusFeed();
			camRadiusFeed2.MinRadius = Convert.ToDouble(dataGridView_0.Rows[i].Cells[0].Value);
			camRadiusFeed2.MaxRadius = Convert.ToDouble(dataGridView_0.Rows[i].Cells[1].Value);
			camRadiusFeed2.Feed = Convert.ToDouble(dataGridView_0.Rows[i].Cells[2].Value);
			RadiusFeedList.Add(camRadiusFeed2);
		}
		for (int j = 0; j <= dataGridView_1.Rows.Count - 1; j++)
		{
			camLengthFeed camLengthFeed2 = new camLengthFeed();
			camLengthFeed2.MinLength = Convert.ToDouble(dataGridView_1.Rows[j].Cells[0].Value);
			camLengthFeed2.MaxLength = Convert.ToDouble(dataGridView_1.Rows[j].Cells[1].Value);
			camLengthFeed2.Feed = Convert.ToDouble(dataGridView_1.Rows[j].Cells[2].Value);
			LengthFeedList.Add(camLengthFeed2);
		}
	}

	internal void method_0(object sender, DataGridViewCellEventArgs e)
	{
		if ((e.RowIndex >= 0) & (e.RowIndex <= dataGridView_0.Rows.Count - 1))
		{
			SelectedRadiusRowSheet = e.RowIndex;
		}
	}

	internal void method_1(object sender, DataGridViewCellEventArgs e)
	{
		if ((e.RowIndex >= 0) & (e.RowIndex <= dataGridView_1.Rows.Count - 1))
		{
			SelectedLengthRowSheet = e.RowIndex;
		}
	}

	internal void method_2(object sender, FormClosingEventArgs e)
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

	internal void method_3(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (!(control.Name == btn_addradius.Name))
		{
			if (!(control.Name == btn_addlength.Name))
			{
				if (!(control.Name == btn_removerad.Name))
				{
					if (!(control.Name == btn_removelen.Name))
					{
						if (!(control.Name == btn_ok.Name))
						{
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
						}
						else
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
					}
					else if ((SelectedLengthRowSheet >= 0) & (SelectedLengthRowSheet <= dataGridView_1.Rows.Count - 1))
					{
						dataGridView_1.Rows.RemoveAt(SelectedLengthRowSheet);
					}
				}
				else if ((SelectedRadiusRowSheet >= 0) & (SelectedRadiusRowSheet <= dataGridView_0.Rows.Count - 1))
				{
					dataGridView_0.Rows.RemoveAt(SelectedRadiusRowSheet);
				}
			}
			else
			{
				dataGridView_1.Rows.Add(Class186.smethod_98(0.0, 0.0, 0.0, dataGridView_1.Rows.Count + 1, this));
			}
		}
		else
		{
			dataGridView_0.Rows.Add(Class186.smethod_652(dataGridView_0.Rows.Count + 1, 0.0, this, 0.0, 0.0));
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
