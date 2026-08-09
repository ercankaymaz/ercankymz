using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Viewer;
using ns27;

namespace buControls.Forms.WinControlForms.Views;

public class F_Preview : Form
{
	public static List<string> Captions = new List<string>();

	public List<eEntities> Entities = new List<eEntities>();

	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public string FormCaption = "Preview";

	public bool CoordinateByMouse = true;

	private IContainer icontainer_0 = null;

	internal buViewer buViewer_0;

	public F_Preview()
	{
		Class76.smethod_29(this);
	}

	public void Init()
	{
		buViewer_0.Entities = new List<eEntities>();
		for (int i = 0; i <= Entities.Count - 1; i++)
		{
			eEntities copiedEnt = new eEntities();
			eEntities.CopyEntity(Entities[i], ref copiedEnt);
			buViewer_0.Entities.Add(copiedEnt);
		}
		buViewer_0.DrawEntities();
		buViewer_0.ZoomFit();
		buViewer_0.ZoomOut();
		LoadLanguage();
		GC.Collect();
	}

	public void LoadLanguage()
	{
		if (Captions.Count >= 1)
		{
			Text = Captions[0];
		}
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		e.Cancel = true;
		if (FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
		if (FormCloseMode == FormCloseModeType.Close)
		{
			Close();
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
