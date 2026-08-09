using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_Preview : Form
{
	public Design viewportLayout;

	public viewType View = viewType.Top;

	public bool ZoomFit = true;

	public bool ZoomAnimation = false;

	public string fileNameTexture = Application.StartupPath;

	public List<Entity> previewEntities = new List<Entity>();

	private Timer timer_0 = new Timer();

	private IContainer icontainer_0 = null;

	public F_Preview()
	{
		Class186.smethod_699(this);
		if (viewportLayout == null)
		{
			viewportLayout = new Design();
		}
		timer_0.Interval = 20;
		timer_0.Tick += timer_0_Tick;
	}

	public void Init()
	{
	}

	public void Init(viewType view, bool zoomFit, bool zoomAnimation)
	{
		ZoomFit = zoomFit;
		View = view;
		ZoomAnimation = zoomAnimation;
		timer_0.Enabled = true;
	}

	public void Init(viewType view, bool zoomFit, bool zoomAnimation, bool ViewToolbar, bool ViewCubeIcon, bool ViewOrigine, bool ViewCoordinate)
	{
		ZoomFit = zoomFit;
		View = view;
		ZoomAnimation = zoomAnimation;
		viewportLayout.ActiveViewport.ToolBar.Visible = ViewToolbar;
		viewportLayout.ActiveViewport.ViewCubeIcon.Visible = ViewToolbar;
		viewportLayout.ActiveViewport.OriginSymbol.Visible = ViewToolbar;
		viewportLayout.ActiveViewport.CoordinateSystemIcon.Visible = ViewToolbar;
		timer_0.Enabled = true;
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		e.Cancel = true;
		base.Visible = false;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		timer_0.Enabled = false;
		if (viewportLayout != null)
		{
			viewportLayout.SetView(View, ZoomFit, ZoomAnimation);
			viewportLayout.Invalidate();
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
