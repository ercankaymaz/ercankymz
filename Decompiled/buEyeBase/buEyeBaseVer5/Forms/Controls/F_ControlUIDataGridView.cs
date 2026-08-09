using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.DialogBox;
using buCore;
using ns71;

namespace buEyeBaseVer5.Forms.Controls;

public class F_ControlUIDataGridView : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	internal IContainer icontainer_0 = null;

	public buButton btn_close;

	public buGround buGround1;

	public ImageList IC32;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal buLabel buLabel_0;

	internal buLabel buLabel_1;

	internal buLabel buLabel_2;

	public buButton btn_font;

	internal buLabel buLabel_3;

	internal buLabel buLabel_4;

	internal buLabel buLabel_5;

	internal buLabel buLabel_6;

	public DataGridView dgv_ref;

	internal buLabel buLabel_7;

	internal buLabel buLabel_8;

	internal buLabel buLabel_9;

	public buButton btn_fontheader;

	internal buLabel buLabel_10;

	internal buLabel buLabel_11;

	public F_ControlUIDataGridView()
	{
		Class186.smethod_641(this);
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
		if (dgv_ref.Columns.Count == 0)
		{
			DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
			dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn.Width = 35;
			dataGridViewColumn.HeaderText = buLangTranslate.preDef.Number;
			dataGridViewColumn.Name = "No";
			dataGridViewColumn.ReadOnly = true;
			dataGridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgv_ref.Columns.Add(dataGridViewColumn);
			DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
			dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn2.Width = dgv_ref.Width - 40;
			dataGridViewColumn2.HeaderText = buLangTranslate.preDef.Text;
			dataGridViewColumn2.Name = "Text";
			dataGridViewColumn2.ReadOnly = true;
			dataGridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewColumn2.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgv_ref.Columns.Add(dataGridViewColumn2);
			dgv_ref.Rows.Add(Class186.smethod_798("DataGridView2", 1, this));
			dgv_ref.Rows.Add(Class186.smethod_798("DataGridView2", 2, this));
		}
		dgv_ref.RowHeadersVisible = false;
		dgv_ref.AllowUserToAddRows = false;
		dgv_ref.AllowUserToResizeColumns = false;
		dgv_ref.ColumnHeadersVisible = true;
		buLabel_1.Display.BackColor = dgv_ref.BackgroundColor;
		buLabel_1.Text = buImage.GetColorKnownName(dgv_ref.BackgroundColor);
		if (!(dgv_ref.BackgroundColor == Color.Black))
		{
			buLabel_1.Display.Fonts.ForeColor = Color.Black;
		}
		else
		{
			buLabel_1.Display.Fonts.ForeColor = Color.WhiteSmoke;
		}
		buLabel_6.Display.BackColor = dgv_ref.DefaultCellStyle.BackColor;
		buLabel_6.Text = buImage.GetColorKnownName(dgv_ref.DefaultCellStyle.BackColor);
		if (!(dgv_ref.DefaultCellStyle.BackColor == Color.Black))
		{
			buLabel_6.Display.Fonts.ForeColor = Color.Black;
		}
		else
		{
			buLabel_6.Display.Fonts.ForeColor = Color.WhiteSmoke;
		}
		buLabel_8.Display.BackColor = dgv_ref.DefaultCellStyle.SelectionBackColor;
		buLabel_8.Text = buImage.GetColorKnownName(dgv_ref.DefaultCellStyle.SelectionBackColor);
		if (!(dgv_ref.DefaultCellStyle.SelectionBackColor == Color.Black))
		{
			buLabel_8.Display.Fonts.ForeColor = Color.Black;
		}
		else
		{
			buLabel_8.Display.Fonts.ForeColor = Color.WhiteSmoke;
		}
		buLabel_4.Display.BackColor = dgv_ref.GridColor;
		buLabel_4.Text = buImage.GetColorKnownName(dgv_ref.GridColor);
		if (!(dgv_ref.GridColor == Color.Black))
		{
			buLabel_4.Display.Fonts.ForeColor = Color.Black;
		}
		else
		{
			buLabel_4.Display.Fonts.ForeColor = Color.WhiteSmoke;
		}
		buLabel_11.Display.BackColor = dgv_ref.ColumnHeadersDefaultCellStyle.BackColor;
		buLabel_11.Text = buImage.GetColorKnownName(dgv_ref.ColumnHeadersDefaultCellStyle.BackColor);
		if (!(dgv_ref.ColumnHeadersDefaultCellStyle.BackColor == Color.Black))
		{
			buLabel_11.Display.Fonts.ForeColor = Color.Black;
		}
		else
		{
			buLabel_11.Display.Fonts.ForeColor = Color.WhiteSmoke;
		}
		btn_font.Text = buLangTranslate.preDef.Cell + " : " + dgv_ref.DefaultCellStyle.Font.Name + " - " + dgv_ref.DefaultCellStyle.Font.Size;
		btn_font.Display.BackColor = dgv_ref.DefaultCellStyle.ForeColor;
		btn_font.ButtonDownDisplay.BackColor = dgv_ref.DefaultCellStyle.ForeColor;
		btn_font.ButtonOverDisplay.BackColor = dgv_ref.DefaultCellStyle.ForeColor;
		if (!(dgv_ref.DefaultCellStyle.ForeColor == Color.Black))
		{
			btn_font.Display.Fonts.ForeColor = Color.Black;
			btn_font.ButtonDownDisplay.Fonts.ForeColor = Color.Black;
			btn_font.ButtonOverDisplay.Fonts.ForeColor = Color.Black;
		}
		else
		{
			btn_font.Display.Fonts.ForeColor = Color.WhiteSmoke;
			btn_font.ButtonDownDisplay.Fonts.ForeColor = Color.WhiteSmoke;
			btn_font.ButtonOverDisplay.Fonts.ForeColor = Color.WhiteSmoke;
		}
		buLabel_2.Display.BackColor = dgv_ref.DefaultCellStyle.ForeColor;
		buLabel_2.Text = buImage.GetColorKnownName(buLabel_2.Display.BackColor);
		if (!(dgv_ref.DefaultCellStyle.ForeColor == Color.Black))
		{
			buLabel_2.Display.Fonts.ForeColor = Color.Black;
		}
		else
		{
			buLabel_2.Display.Fonts.ForeColor = Color.WhiteSmoke;
		}
		btn_fontheader.Text = buLangTranslate.preDef.Header + " : " + dgv_ref.ColumnHeadersDefaultCellStyle.Font.Name + " - " + dgv_ref.ColumnHeadersDefaultCellStyle.Font.Size;
		btn_fontheader.Display.BackColor = dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor;
		btn_fontheader.ButtonDownDisplay.BackColor = dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor;
		btn_fontheader.ButtonOverDisplay.BackColor = dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor;
		if (!(dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor == Color.Black))
		{
			btn_fontheader.Display.Fonts.ForeColor = Color.Black;
			btn_fontheader.ButtonDownDisplay.Fonts.ForeColor = Color.Black;
			btn_fontheader.ButtonOverDisplay.Fonts.ForeColor = Color.Black;
		}
		else
		{
			btn_fontheader.Display.Fonts.ForeColor = Color.WhiteSmoke;
			btn_fontheader.ButtonDownDisplay.Fonts.ForeColor = Color.WhiteSmoke;
			btn_fontheader.ButtonOverDisplay.Fonts.ForeColor = Color.WhiteSmoke;
		}
		buLabel_9.Display.BackColor = dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor;
		buLabel_9.Text = buImage.GetColorKnownName(buLabel_2.Display.BackColor);
		if (!(dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor == Color.Black))
		{
			buLabel_9.Display.Fonts.ForeColor = Color.Black;
		}
		else
		{
			buLabel_9.Display.Fonts.ForeColor = Color.WhiteSmoke;
		}
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		Class186.smethod_280(this);
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

	public void Apply()
	{
	}

	internal void method_1(object sender, EventArgs e)
	{
		try
		{
			Control control = sender as Control;
			if (!(control.Name == btn_ok.Name))
			{
				if (!((control.Name == btn_close.Name) | (control.Name == btn_cancel.Name)))
				{
					if (control.Name == btn_fontheader.Name)
					{
						FontDialog fontDialog = new FontDialog();
						fontDialog.Font = dgv_ref.ColumnHeadersDefaultCellStyle.Font;
						fontDialog.ShowDialog();
						dgv_ref.ColumnHeadersDefaultCellStyle.Font = fontDialog.Font;
						btn_fontheader.Text = buLangTranslate.preDef.Header + " : " + dgv_ref.ColumnHeadersDefaultCellStyle.Font.Name + " - " + dgv_ref.ColumnHeadersDefaultCellStyle.Font.Size;
						btn_fontheader.Display.BackColor = dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor;
						btn_fontheader.ButtonDownDisplay.BackColor = dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor;
						btn_fontheader.ButtonOverDisplay.BackColor = dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor;
						if (!(dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor == Color.Black))
						{
							btn_fontheader.Display.Fonts.ForeColor = Color.Black;
							btn_fontheader.ButtonDownDisplay.Fonts.ForeColor = Color.Black;
							btn_fontheader.ButtonOverDisplay.Fonts.ForeColor = Color.Black;
						}
						else
						{
							btn_fontheader.Display.Fonts.ForeColor = Color.WhiteSmoke;
							btn_fontheader.ButtonDownDisplay.Fonts.ForeColor = Color.WhiteSmoke;
							btn_fontheader.ButtonOverDisplay.Fonts.ForeColor = Color.WhiteSmoke;
						}
						buLabel_9.Display.BackColor = dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor;
						buLabel_9.Text = buImage.GetColorKnownName(buLabel_2.Display.BackColor);
						if (!(dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor == Color.Black))
						{
							buLabel_9.Display.Fonts.ForeColor = Color.Black;
						}
						else
						{
							buLabel_9.Display.Fonts.ForeColor = Color.WhiteSmoke;
						}
					}
					if (control.Name == btn_font.Name)
					{
						FontDialog fontDialog2 = new FontDialog();
						fontDialog2.Font = dgv_ref.DefaultCellStyle.Font;
						fontDialog2.ShowDialog();
						dgv_ref.DefaultCellStyle.Font = fontDialog2.Font;
						btn_font.Text = buLangTranslate.preDef.Cell + " : " + dgv_ref.DefaultCellStyle.Font.Name + " - " + dgv_ref.DefaultCellStyle.Font.Size;
						btn_font.Display.BackColor = dgv_ref.DefaultCellStyle.ForeColor;
						btn_font.ButtonDownDisplay.BackColor = dgv_ref.DefaultCellStyle.ForeColor;
						btn_font.ButtonOverDisplay.BackColor = dgv_ref.DefaultCellStyle.ForeColor;
						if (!(dgv_ref.DefaultCellStyle.ForeColor == Color.Black))
						{
							btn_font.Display.Fonts.ForeColor = Color.Black;
							btn_font.ButtonDownDisplay.Fonts.ForeColor = Color.Black;
							btn_font.ButtonOverDisplay.Fonts.ForeColor = Color.Black;
						}
						else
						{
							btn_font.Display.Fonts.ForeColor = Color.WhiteSmoke;
							btn_font.ButtonDownDisplay.Fonts.ForeColor = Color.WhiteSmoke;
							btn_font.ButtonOverDisplay.Fonts.ForeColor = Color.WhiteSmoke;
						}
						buLabel_2.Display.BackColor = dgv_ref.DefaultCellStyle.ForeColor;
						buLabel_2.Text = buImage.GetColorKnownName(buLabel_2.Display.BackColor);
						if (!(dgv_ref.DefaultCellStyle.ForeColor == Color.Black))
						{
							buLabel_2.Display.Fonts.ForeColor = Color.Black;
						}
						else
						{
							buLabel_2.Display.Fonts.ForeColor = Color.WhiteSmoke;
						}
					}
				}
				else
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
		catch (Exception)
		{
		}
	}

	public void spn_Leave(object sender, EventArgs e)
	{
	}

	internal void method_2(object sender, EventArgs e)
	{
		buLabel buLabel2 = sender as buLabel;
		if (buLabel2.Name == buLabel_1.Name)
		{
			Color cColor = buLabel2.Display.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor) == DialogResult.OK)
			{
				buLabel2.Display.BackColor = cColor;
				buLabel2.Text = buImage.GetColorKnownName(cColor);
				dgv_ref.BackgroundColor = cColor;
			}
		}
		if (buLabel2.Name == buLabel_4.Name)
		{
			Color cColor2 = buLabel2.Display.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor2) == DialogResult.OK)
			{
				buLabel2.Display.BackColor = cColor2;
				buLabel2.Text = buImage.GetColorKnownName(cColor2);
				dgv_ref.GridColor = cColor2;
			}
		}
		if (buLabel2.Name == buLabel_6.Name)
		{
			Color cColor3 = buLabel2.Display.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor3) == DialogResult.OK)
			{
				buLabel2.Display.BackColor = cColor3;
				buLabel2.Text = buImage.GetColorKnownName(cColor3);
				dgv_ref.DefaultCellStyle.BackColor = cColor3;
			}
		}
		if (buLabel2.Name == buLabel_7.Name)
		{
			Color cColor4 = buLabel2.Display.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor4) == DialogResult.OK)
			{
				buLabel2.Display.BackColor = cColor4;
				buLabel2.Text = buImage.GetColorKnownName(cColor4);
				dgv_ref.DefaultCellStyle.SelectionBackColor = cColor4;
			}
		}
		if (buLabel2.Name == buLabel_2.Name)
		{
			Color cColor5 = buLabel2.Display.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor5) == DialogResult.OK)
			{
				buLabel2.Display.BackColor = cColor5;
				buLabel2.Text = buImage.GetColorKnownName(cColor5);
				dgv_ref.DefaultCellStyle.ForeColor = cColor5;
				dgv_ref.DefaultCellStyle.SelectionForeColor = cColor5;
			}
		}
		if (buLabel2.Name == buLabel_11.Name)
		{
			Color cColor6 = buLabel2.Display.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor6) == DialogResult.OK)
			{
				buLabel2.Display.BackColor = cColor6;
				buLabel2.Text = buImage.GetColorKnownName(cColor6);
				dgv_ref.ColumnHeadersDefaultCellStyle.BackColor = cColor6;
				dgv_ref.RowHeadersDefaultCellStyle.BackColor = cColor6;
			}
		}
		if (buLabel2.Name == buLabel_9.Name)
		{
			Color cColor7 = buLabel2.Display.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor7) == DialogResult.OK)
			{
				buLabel2.Display.BackColor = cColor7;
				buLabel2.Text = buImage.GetColorKnownName(cColor7);
				dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor = cColor7;
				dgv_ref.RowHeadersDefaultCellStyle.ForeColor = cColor7;
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
