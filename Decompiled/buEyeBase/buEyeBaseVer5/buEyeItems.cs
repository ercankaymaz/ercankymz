using System.Windows.Forms;
using devDept.Eyeshot.Control;
using devDept.Geometry;

namespace buEyeBaseVer5;

public class buEyeItems
{
	public static Form frmMain = null;

	public static Design viewportCNC = null;

	public static Design viewportCadCam = null;

	public static Design viewportDialogs = null;

	public static Plane planeViewportDialogs = Plane.XY;

	public static Point3D pntMouseMove = new Point3D();

	public static void mouseMoveViewportDialogs(object sender, MouseEventArgs e)
	{
		if (viewportDialogs != null)
		{
			viewportDialogs.ScreenToPlane(e.Location, planeViewportDialogs, out pntMouseMove);
		}
	}
}
