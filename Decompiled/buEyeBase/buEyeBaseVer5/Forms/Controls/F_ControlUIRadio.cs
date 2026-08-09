using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.DialogBox;
using buCore;
using ns71;

namespace buEyeBaseVer5.Forms.Controls;

public class F_ControlUIRadio : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public RadioButton refRadio = null;

	internal IContainer icontainer_0 = null;

	public buButton btn_close;

	public buGround buGround1;

	public ImageList IC32;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal RadioButton radioButton_0;

	internal buLabel buLabel_0;

	internal buLabel buLabel_1;

	internal buLabel buLabel_2;

	public buButton btn_font;

	internal buComboBox buComboBox_0;

	public F_ControlUIRadio()
	{
		Class186.smethod_733(this);
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
		if (refRadio != null)
		{
			radioButton_0.ForeColor = refRadio.ForeColor;
			radioButton_0.BackColor = refRadio.BackColor;
			radioButton_0.TextAlign = refRadio.TextAlign;
			buLabel_1.Display.BackColor = refRadio.BackColor;
			buLabel_1.Text = buImage.GetColorKnownName(refRadio.BackColor);
			if (!(refRadio.BackColor == Color.Black))
			{
				buLabel_1.Display.Fonts.ForeColor = Color.Black;
			}
			else
			{
				buLabel_1.Display.Fonts.ForeColor = Color.WhiteSmoke;
			}
			buLabel_2.Display.BackColor = refRadio.ForeColor;
			buLabel_2.Text = buImage.GetColorKnownName(refRadio.ForeColor);
			if (!(refRadio.BackColor == Color.Black))
			{
				buLabel_2.Display.Fonts.ForeColor = Color.Black;
			}
			else
			{
				buLabel_2.Display.Fonts.ForeColor = Color.WhiteSmoke;
			}
			btn_font.Text = radioButton_0.Font.Name + " - " + radioButton_0.Font.Size;
			btn_font.Display.BackColor = radioButton_0.ForeColor;
			btn_font.ButtonDownDisplay.BackColor = radioButton_0.ForeColor;
			btn_font.ButtonOverDisplay.BackColor = radioButton_0.ForeColor;
			if (!(radioButton_0.ForeColor == Color.Black))
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
			buLabel_2.Display.BackColor = radioButton_0.ForeColor;
			buLabel_2.Text = buImage.GetColorKnownName(buLabel_2.Display.BackColor);
			if (!(radioButton_0.ForeColor == Color.Black))
			{
				buLabel_2.Display.Fonts.ForeColor = Color.Black;
			}
			else
			{
				buLabel_2.Display.Fonts.ForeColor = Color.WhiteSmoke;
			}
			buComboBox_0.Items.Clear();
			buComboBox_0.Items.AddRange(Enum.GetValues(typeof(ContentAlignment)).Cast<object>().ToArray());
			buComboBox_0.SelectedItem = radioButton_0.TextAlign;
		}
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		Class186.smethod_302(this);
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
					if (control.Name == btn_font.Name)
					{
						FontDialog fontDialog = new FontDialog();
						fontDialog.Font = radioButton_0.Font;
						fontDialog.ShowDialog();
						radioButton_0.Font = fontDialog.Font;
						refRadio.Font = new Font(fontDialog.Font.Name, fontDialog.Font.Size, fontDialog.Font.Style);
						btn_font.Text = radioButton_0.Font.Name + " - " + radioButton_0.Font.Size;
						btn_font.Display.BackColor = radioButton_0.ForeColor;
						btn_font.ButtonDownDisplay.BackColor = radioButton_0.ForeColor;
						btn_font.ButtonOverDisplay.BackColor = radioButton_0.ForeColor;
						if (!(radioButton_0.ForeColor == Color.Black))
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
						buLabel_2.Display.BackColor = radioButton_0.ForeColor;
						buLabel_2.Text = buImage.GetColorKnownName(buLabel_2.Display.BackColor);
						if (!(radioButton_0.ForeColor == Color.Black))
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
				refRadio.BackColor = cColor;
				radioButton_0.BackColor = cColor;
			}
		}
		if (buLabel2.Name == buLabel_2.Name)
		{
			Color cColor2 = buLabel2.Display.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor2) == DialogResult.OK)
			{
				buLabel2.Display.BackColor = cColor2;
				buLabel2.Text = buImage.GetColorKnownName(cColor2);
				refRadio.ForeColor = cColor2;
				radioButton_0.ForeColor = cColor2;
			}
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == buComboBox_0.Name)
		{
			Enum.TryParse<ContentAlignment>(buComboBox_0.SelectedItem.ToString(), out var result);
			refRadio.TextAlign = result;
			radioButton_0.TextAlign = result;
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
