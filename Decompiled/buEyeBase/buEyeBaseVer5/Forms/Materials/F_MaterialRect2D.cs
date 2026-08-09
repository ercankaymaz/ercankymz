using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using ns71;

namespace buEyeBaseVer5.Forms.Materials;

public class F_MaterialRect2D : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public MaterialBase5 Material = new MaterialBase5();

	public Design viewportLayout;

	public List<Entity> OptionEntity = null;

	public Entity EntClamper = null;

	public static List<string> Captions;

	private Timer timer_0 = new Timer();

	private IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal NumericUpDown numericUpDown_0;

	internal Label label_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_1;

	public Panel pnl_model;

	public F_MaterialRect2D()
	{
		Class186.smethod_353(this);
		timer_0.Tick += timer_0_Tick;
	}

	public void Init(MaterialBase5 material)
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
		btn_ok.Enabled = false;
		if (material != null)
		{
			Material = new MaterialBase5(material);
		}
		numericUpDown_0.Value = (decimal)Material.Size.Width;
		numericUpDown_1.Value = (decimal)Material.Size.Height;
		ControlUpdate();
		LoadLanguage();
		PropertiesForm.Inited = false;
		label_0.Text = buLangTranslate.preDef.Width + " (X) ";
		label_1.Text = buLangTranslate.preDef.Height + " (Y) ";
		timer_0.Interval = 100;
		timer_0.Enabled = true;
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
		if (control.Name == btn_ok.Name)
		{
			Material.Entities.Clear();
			for (int i = 0; i <= viewportLayout.Entities.Count - 1; i++)
			{
				Entity copiedEnt = null;
				buVector5.CopyEntities(viewportLayout.Entities[i], ref copiedEnt);
				CustomData entityData = new CustomData();
				copiedEnt.EntityData = entityData;
				Material.Entities.Add(copiedEnt);
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

	private void timer_0_Tick(object sender, EventArgs e)
	{
		Class186.smethod_455(this);
		btn_ok.Enabled = true;
		timer_0.Enabled = false;
	}

	public void ControlUpdate()
	{
	}

	public void Apply()
	{
		Material.Size.Width = (double)numericUpDown_0.Value;
		Material.Size.Height = (double)numericUpDown_1.Value;
	}

	internal void method_2(object sender, EventArgs e)
	{
		new Control();
		if (PropertiesForm.Inited)
		{
			Material.Size.Width = (double)numericUpDown_0.Value;
			Material.Size.Height = (double)numericUpDown_1.Value;
			Class186.smethod_455(this);
			PropertiesForm.Inited = true;
		}
	}

	public void FindFirstClamperPositions(double Width, double ClamperLength, ref double X1, ref double X2)
	{
		X2 = ClamperLength / 2.0;
		X1 = Width - ClamperLength / 2.0;
		if (X1 - X2 < ClamperLength + 10.0)
		{
			double num = ClamperLength + 10.0 - (X1 - X2);
			if (num > 0.0)
			{
				X2 += num / 2.0;
				X1 -= num / 2.0;
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

	static F_MaterialRect2D()
	{
		Captions = new List<string>();
	}
}
