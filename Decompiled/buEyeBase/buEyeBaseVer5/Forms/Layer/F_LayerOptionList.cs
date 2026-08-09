using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.DialogBox;
using ns71;

namespace buEyeBaseVer5.Forms.Layer;

public class F_LayerOptionList : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public List<LayerOverride> LayerOptions = new List<LayerOverride>();

	internal IContainer icontainer_0 = null;

	internal Label label_0;

	internal Label label_1;

	internal Label label_2;

	internal Label label_3;

	internal Label label_4;

	internal Label label_5;

	internal Label label_6;

	internal Label label_7;

	internal Label label_8;

	internal Label label_9;

	internal Label label_10;

	internal Label label_11;

	internal Label label_12;

	internal Label label_13;

	internal Label label_14;

	internal Label label_15;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal Label label_16;

	internal Label label_17;

	internal Label label_18;

	internal Label label_19;

	internal Label label_20;

	internal Label label_21;

	internal Label label_22;

	internal Label label_23;

	internal Label label_24;

	internal Label label_25;

	internal Label label_26;

	internal Label label_27;

	internal Label label_28;

	internal Label label_29;

	internal Label label_30;

	internal Label label_31;

	internal TextBox textBox_0;

	internal TextBox textBox_1;

	internal TextBox textBox_2;

	internal Label label_32;

	internal Label label_33;

	internal Label label_34;

	internal Label label_35;

	internal TextBox textBox_3;

	internal TextBox textBox_4;

	internal TextBox textBox_5;

	internal TextBox textBox_6;

	internal TextBox textBox_7;

	internal TextBox textBox_8;

	internal TextBox textBox_9;

	internal TextBox textBox_10;

	internal TextBox textBox_11;

	internal TextBox textBox_12;

	internal TextBox textBox_13;

	internal TextBox textBox_14;

	internal TextBox textBox_15;

	internal TextBox textBox_16;

	internal TextBox textBox_17;

	internal TextBox textBox_18;

	internal TextBox textBox_19;

	internal TextBox textBox_20;

	internal TextBox textBox_21;

	internal TextBox textBox_22;

	internal TextBox textBox_23;

	internal TextBox textBox_24;

	internal TextBox textBox_25;

	internal TextBox textBox_26;

	internal TextBox textBox_27;

	internal TextBox textBox_28;

	internal TextBox textBox_29;

	internal TextBox textBox_30;

	internal TextBox textBox_31;

	internal TextBox textBox_32;

	internal TextBox textBox_33;

	internal TextBox textBox_34;

	internal TextBox textBox_35;

	internal TextBox textBox_36;

	internal TextBox textBox_37;

	internal TextBox textBox_38;

	internal TextBox textBox_39;

	internal TextBox textBox_40;

	internal TextBox textBox_41;

	internal TextBox textBox_42;

	internal TextBox textBox_43;

	internal TextBox textBox_44;

	internal TextBox textBox_45;

	internal TextBox textBox_46;

	internal TextBox textBox_47;

	internal CheckBox checkBox_0;

	public F_LayerOptionList()
	{
		Class186.smethod_377(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		base.StartPosition = PropertiesForm.FormPosition;
		for (int i = 0; i <= LayerOptions.Count - 1; i++)
		{
			for (int j = 0; j <= base.Controls.Count - 1; j++)
			{
				if (base.Controls[j].Name.IndexOf("txt_orjname") >= 0 && base.Controls[j].Tag != null)
				{
					int result = -1;
					int.TryParse(base.Controls[j].Tag.ToString(), out result);
					if (result == i)
					{
						((TextBox)base.Controls[j]).Text = LayerOptions[i].LayerOriginalName;
					}
				}
				if (base.Controls[j].Name.IndexOf("txt_newname") >= 0 && base.Controls[j].Tag != null)
				{
					int result2 = -1;
					int.TryParse(base.Controls[j].Tag.ToString(), out result2);
					if (result2 == i)
					{
						((TextBox)base.Controls[j]).Text = LayerOptions[i].LayerNewName;
					}
				}
				if (base.Controls[j].Name.IndexOf("txt_extra") >= 0 && base.Controls[j].Tag != null)
				{
					int result3 = -1;
					int.TryParse(base.Controls[j].Tag.ToString(), out result3);
					if (result3 == i)
					{
						((TextBox)base.Controls[j]).Text = LayerOptions[i].LayerExtraName;
					}
				}
				if (base.Controls[j].Name.IndexOf("lbl_Color") >= 0 && base.Controls[j].Tag != null)
				{
					int result4 = -1;
					int.TryParse(base.Controls[j].Tag.ToString(), out result4);
					if (result4 == i)
					{
						base.Controls[j].BackColor = buImage5.ColorList[result4];
						base.Controls[j].ForeColor = buImage5.InvertColorNoGray(buImage5.ColorList[result4]);
						base.Controls[j].Text = buImage5.GetColorKnownName(buImage5.ColorList[result4]);
					}
				}
			}
		}
		PropertiesForm.Inited = false;
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
		string callMethod = "LoadLanguage";
		try
		{
			Text = buLangTranslate.preDef.Layer + " " + buLangTranslate.preDef.Option + " " + buLangTranslate.preDef.List;
			label_32.Text = buLangTranslate.preDef.Originale + " " + buLangTranslate.preDef.Layer + " " + buLangTranslate.preDef.Name;
			label_33.Text = buLangTranslate.preDef.New + " " + buLangTranslate.preDef.Layer + " " + buLangTranslate.preDef.Name;
			label_34.Text = buLangTranslate.preDef.Extra + " " + buLangTranslate.preDef.Layer + " " + buLangTranslate.preDef.Name;
			btn_cancel.Text = buLangTranslate.preDef.Cancel;
			btn_ok.Text = buLangTranslate.preDef.Ok;
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
		if (control.Name == btn_ok.Name)
		{
			LayerOptions.Clear();
			if ((textBox_0.Text.Trim().Length > 0) & (textBox_1.Text.Trim().Length > 0))
			{
				LayerOverride item = new LayerOverride
				{
					LayerOriginalName = textBox_0.Text,
					LayerNewName = textBox_1.Text,
					LayerExtraName = textBox_2.Text,
					LayerNewColor = label_6.BackColor
				};
				LayerOptions.Add(item);
			}
			if ((textBox_5.Text.Trim().Length > 0) & (textBox_4.Text.Trim().Length > 0))
			{
				LayerOverride item2 = new LayerOverride
				{
					LayerOriginalName = textBox_5.Text,
					LayerNewName = textBox_4.Text,
					LayerExtraName = textBox_3.Text,
					LayerNewColor = label_5.BackColor
				};
				LayerOptions.Add(item2);
			}
			if ((textBox_11.Text.Trim().Length > 0) & (textBox_10.Text.Trim().Length > 0))
			{
				LayerOverride item3 = new LayerOverride
				{
					LayerOriginalName = textBox_11.Text,
					LayerNewName = textBox_10.Text,
					LayerExtraName = textBox_9.Text,
					LayerNewColor = label_4.BackColor
				};
				LayerOptions.Add(item3);
			}
			if ((textBox_8.Text.Trim().Length > 0) & (textBox_7.Text.Trim().Length > 0))
			{
				LayerOverride item4 = new LayerOverride
				{
					LayerOriginalName = textBox_8.Text,
					LayerNewName = textBox_7.Text,
					LayerExtraName = textBox_6.Text,
					LayerNewColor = label_3.BackColor
				};
				LayerOptions.Add(item4);
			}
			if ((textBox_8.Text.Trim().Length > 0) & (textBox_22.Text.Trim().Length > 0))
			{
				LayerOverride item5 = new LayerOverride
				{
					LayerOriginalName = textBox_23.Text,
					LayerNewName = textBox_22.Text,
					LayerExtraName = textBox_21.Text,
					LayerNewColor = label_2.BackColor
				};
				LayerOptions.Add(item5);
			}
			if ((textBox_20.Text.Trim().Length > 0) & (textBox_19.Text.Trim().Length > 0))
			{
				LayerOverride item6 = new LayerOverride
				{
					LayerOriginalName = textBox_20.Text,
					LayerNewName = textBox_19.Text,
					LayerExtraName = textBox_18.Text,
					LayerNewColor = label_1.BackColor
				};
				LayerOptions.Add(item6);
			}
			if ((textBox_17.Text.Trim().Length > 0) & (textBox_16.Text.Trim().Length > 0))
			{
				LayerOverride item7 = new LayerOverride
				{
					LayerOriginalName = textBox_17.Text,
					LayerNewName = textBox_16.Text,
					LayerExtraName = textBox_15.Text,
					LayerNewColor = label_0.BackColor
				};
				LayerOptions.Add(item7);
			}
			if ((textBox_14.Text.Trim().Length > 0) & (textBox_13.Text.Trim().Length > 0))
			{
				LayerOverride item8 = new LayerOverride
				{
					LayerOriginalName = textBox_14.Text,
					LayerNewName = textBox_13.Text,
					LayerExtraName = textBox_12.Text,
					LayerNewColor = label_7.BackColor
				};
				LayerOptions.Add(item8);
			}
			if ((textBox_35.Text.Trim().Length > 0) & (textBox_34.Text.Trim().Length > 0))
			{
				LayerOverride item9 = new LayerOverride
				{
					LayerOriginalName = textBox_35.Text,
					LayerNewName = textBox_34.Text,
					LayerExtraName = textBox_33.Text,
					LayerNewColor = label_15.BackColor
				};
				LayerOptions.Add(item9);
			}
			if ((textBox_32.Text.Trim().Length > 0) & (textBox_31.Text.Trim().Length > 0))
			{
				LayerOverride item10 = new LayerOverride
				{
					LayerOriginalName = textBox_32.Text,
					LayerNewName = textBox_31.Text,
					LayerExtraName = textBox_30.Text,
					LayerNewColor = label_14.BackColor
				};
				LayerOptions.Add(item10);
			}
			if ((textBox_29.Text.Trim().Length > 0) & (textBox_28.Text.Trim().Length > 0))
			{
				LayerOverride item11 = new LayerOverride
				{
					LayerOriginalName = textBox_29.Text,
					LayerNewName = textBox_28.Text,
					LayerExtraName = textBox_27.Text,
					LayerNewColor = label_13.BackColor
				};
				LayerOptions.Add(item11);
			}
			if ((textBox_26.Text.Trim().Length > 0) & (textBox_25.Text.Trim().Length > 0))
			{
				LayerOverride item12 = new LayerOverride
				{
					LayerOriginalName = textBox_26.Text,
					LayerNewName = textBox_25.Text,
					LayerExtraName = textBox_24.Text,
					LayerNewColor = label_12.BackColor
				};
				LayerOptions.Add(item12);
			}
			if ((textBox_47.Text.Trim().Length > 0) & (textBox_46.Text.Trim().Length > 0))
			{
				LayerOverride item13 = new LayerOverride
				{
					LayerOriginalName = textBox_47.Text,
					LayerNewName = textBox_46.Text,
					LayerExtraName = textBox_45.Text,
					LayerNewColor = label_11.BackColor
				};
				LayerOptions.Add(item13);
			}
			if ((textBox_44.Text.Trim().Length > 0) & (textBox_43.Text.Trim().Length > 0))
			{
				LayerOverride item14 = new LayerOverride
				{
					LayerOriginalName = textBox_44.Text,
					LayerNewName = textBox_43.Text,
					LayerExtraName = textBox_42.Text,
					LayerNewColor = label_10.BackColor
				};
				LayerOptions.Add(item14);
			}
			if ((textBox_41.Text.Trim().Length > 0) & (textBox_40.Text.Trim().Length > 0))
			{
				LayerOverride item15 = new LayerOverride
				{
					LayerOriginalName = textBox_41.Text,
					LayerNewName = textBox_40.Text,
					LayerExtraName = textBox_39.Text,
					LayerNewColor = label_9.BackColor
				};
				LayerOptions.Add(item15);
			}
			if ((textBox_38.Text.Trim().Length > 0) & (textBox_37.Text.Trim().Length > 0))
			{
				LayerOverride item16 = new LayerOverride
				{
					LayerOriginalName = textBox_38.Text,
					LayerNewName = textBox_37.Text,
					LayerExtraName = textBox_36.Text,
					LayerNewColor = label_8.BackColor
				};
				LayerOptions.Add(item16);
			}
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

	internal void method_2(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Tag == null || !buNumeric5.IsNumeric(control.Tag.ToString()))
		{
			return;
		}
		int num = -1;
		num = int.Parse(control.Tag.ToString());
		ColorDialogBox.ShowDialog(buImage5.ColorList[num]);
		if (ColorDialogBox.Result == DialogResult.OK)
		{
			if ((num >= 0) & (num <= LayerOptions.Count - 1))
			{
				LayerOptions[num].LayerNewColor = ColorDialogBox.Color;
			}
			control.BackColor = ColorDialogBox.Color;
			control.ForeColor = buImage5.InvertColorNoGray(control.BackColor);
			control.Text = buImage5.GetColorKnownName(control.BackColor);
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
