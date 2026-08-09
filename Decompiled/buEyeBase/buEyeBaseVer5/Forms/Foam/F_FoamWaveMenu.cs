using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using ns71;

namespace buEyeBaseVer5.Forms.Foam;

public class F_FoamWaveMenu : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public FoamType foamType = FoamType.SlicesVertical;

	private IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal Button button_0;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	internal Button button_4;

	internal Button button_5;

	internal Button button_6;

	public F_FoamWaveMenu()
	{
		Class186.smethod_690(this);
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
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (PropertiesForm.Result != DialogResult.OK)
		{
			foamType = FoamType.SlicesVertical;
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
		if (!(control.Name == button_6.Name))
		{
			if (!(control.Name == button_2.Name))
			{
				if (!(control.Name == button_0.Name))
				{
					if (!(control.Name == button_1.Name))
					{
						if (!(control.Name == button_5.Name))
						{
							if (!(control.Name == button_3.Name))
							{
								if (control.Name == button_4.Name)
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
									foamType = FoamType.ZForm;
								}
							}
							else
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
								foamType = FoamType.VForm;
							}
						}
						else
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
							foamType = FoamType.SlicesHorizontal;
						}
					}
					else
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
						foamType = FoamType.Rectangle;
					}
				}
				else
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
					foamType = FoamType.Pyramid;
				}
			}
			else
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
				foamType = FoamType.SForm;
			}
		}
		else
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
			foamType = FoamType.CForm;
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
