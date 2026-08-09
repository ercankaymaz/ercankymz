using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleLanguageMenu : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public int Language = 0;

	private IContainer icontainer_0 = null;

	public buButton btn_close;

	public buCheckBox btn_tr;

	public buGround buGround1;

	public buCheckBox btn_bae;

	public buCheckBox btn_cn;

	public buCheckBox btn_it;

	public buCheckBox btn_en;

	public buCheckBox btn_de;

	public buCheckBox btn_es;

	public buCheckBox btn_fr;

	public F_MarbleLanguageMenu()
	{
		Class186.smethod_217(this);
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
		btn_cn.Check = false;
		btn_de.Check = false;
		btn_en.Check = false;
		btn_es.Check = false;
		btn_fr.Check = false;
		btn_it.Check = false;
		btn_tr.Check = false;
		btn_bae.Check = false;
		if (Language != 0)
		{
			if (Language != 1)
			{
				if (Language != 2)
				{
					if (Language != 3)
					{
						if (Language != 4)
						{
							if (Language != 5)
							{
								if (Language != 7)
								{
									if (Language == 8)
									{
										btn_fr.Check = true;
									}
								}
								else
								{
									btn_bae.Check = true;
								}
							}
							else
							{
								btn_es.Check = true;
							}
						}
						else
						{
							btn_it.Check = true;
						}
					}
					else
					{
						btn_de.Check = true;
					}
				}
				else
				{
					btn_cn.Check = true;
				}
			}
			else
			{
				btn_tr.Check = true;
			}
		}
		else
		{
			btn_en.Check = true;
		}
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			buGround1.Text = buLangTranslate.preDef.Language;
		}
		catch (Exception)
		{
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

	public void Apply()
	{
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == btn_tr.Name)
		{
			Language = 1;
		}
		if (control.Name == btn_en.Name)
		{
			Language = 0;
		}
		if (control.Name == btn_cn.Name)
		{
			Language = 2;
		}
		if (control.Name == btn_de.Name)
		{
			Language = 3;
		}
		if (control.Name == btn_it.Name)
		{
			Language = 4;
		}
		if (control.Name == btn_es.Name)
		{
			Language = 5;
		}
		if (control.Name == btn_bae.Name)
		{
			Language = 7;
		}
		if (control.Name == btn_fr.Name)
		{
			Language = 8;
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

	internal void method_2(object sender, EventArgs e)
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

	internal void method_3(object object_0, bool bool_0)
	{
		if (PropertiesForm.Inited)
		{
			btn_tr.Check = true;
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

	internal void method_4(object object_0, bool bool_0)
	{
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
