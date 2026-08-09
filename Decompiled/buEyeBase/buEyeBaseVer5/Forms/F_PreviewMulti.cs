using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Graphics;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_PreviewMulti : Form
{
	private IContainer icontainer_0 = null;

	public Design viewport_preview;

	public F_PreviewMulti()
	{
		Class186.smethod_411(this);
		viewport_preview.CreateControl();
		viewport_preview.CreateGraphics();
	}

	public void Init()
	{
		viewport_preview.Viewports[0].SetView(viewType.Trimetric);
		viewport_preview.Viewports[0].DisplayMode = displayType.Flat;
		viewport_preview.Viewports[0].Camera.ProjectionMode = projectionType.Orthographic;
		viewport_preview.Viewports[0].Background = new BackgroundSettings(backgroundStyleType.LinearGradient, Color.FromArgb(250, 248, 239), Color.DodgerBlue, Color.FromArgb(240, 235, 211), 0.75, null, colorThemeType.Auto, 0.33);
		viewport_preview.Viewports[0].Grid.Visible = false;
		viewport_preview.Viewports[0].ZoomFit(5);
		viewport_preview.Viewports[1].SetView(viewType.Top);
		viewport_preview.Viewports[1].DisplayMode = displayType.Flat;
		viewport_preview.Viewports[1].Camera.ProjectionMode = projectionType.Orthographic;
		viewport_preview.Viewports[1].Background = new BackgroundSettings(backgroundStyleType.LinearGradient, Color.FromArgb(250, 248, 239), Color.DodgerBlue, Color.FromArgb(240, 235, 211), 0.75, null, colorThemeType.Auto, 0.33);
		viewport_preview.Viewports[1].Grid.Visible = false;
		viewport_preview.Viewports[1].ZoomFit(5);
		viewport_preview.Viewports[2].SetView(viewType.Right);
		viewport_preview.Viewports[2].DisplayMode = displayType.Flat;
		viewport_preview.Viewports[2].Camera.ProjectionMode = projectionType.Orthographic;
		viewport_preview.Viewports[2].Background = new BackgroundSettings(backgroundStyleType.LinearGradient, Color.FromArgb(250, 248, 239), Color.DodgerBlue, Color.FromArgb(240, 235, 211), 0.75, null, colorThemeType.Auto, 0.33);
		viewport_preview.Viewports[2].Grid.Visible = false;
		viewport_preview.Viewports[2].ZoomFit(5);
		viewport_preview.Viewports[3].SetView(viewType.Front);
		viewport_preview.Viewports[3].DisplayMode = displayType.Flat;
		viewport_preview.Viewports[3].Camera.ProjectionMode = projectionType.Orthographic;
		viewport_preview.Viewports[3].Background = new BackgroundSettings(backgroundStyleType.LinearGradient, Color.FromArgb(250, 248, 239), Color.DodgerBlue, Color.FromArgb(240, 235, 211), 0.75, null, colorThemeType.Auto, 0.33);
		viewport_preview.Viewports[3].Grid.Visible = false;
		viewport_preview.Viewports[3].ZoomFit(5);
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
