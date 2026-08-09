using System.Drawing;
using buClass;

namespace buEyeBaseVer5.Apps.Marble;

public class MarbleDisplayViewportSettings : buSerilization5
{
	public bool ZoomMouseWheelReverse = false;

	public Color CNCViewportBottomColor = Color.LightGray;

	public Color CNCViewportMiddleColor = Color.WhiteSmoke;

	public Color CNCViewportTopColor = Color.LightGray;

	public DisplayModeType CNCViewportDisplayType = DisplayModeType.Rendered;

	public ProjectionModeType CNCViewportProjection = ProjectionModeType.Orthographic;

	public bool CNCViewportShowCubeBox = true;

	public bool CNCViewportShowUcsArrow = true;

	public bool CNCViewportShowOrigineSembol = true;

	public bool CNCViewportShowMouseCoordinates = true;

	public Color CadCamViewportBottomColor = Color.LightGray;

	public Color CadCamViewportMiddleColor = Color.WhiteSmoke;

	public Color CadCamViewportTopColor = Color.LightGray;

	public DisplayModeType CadCamViewportDisplayType = DisplayModeType.Rendered;

	public ProjectionModeType CadCamViewportProjection = ProjectionModeType.Orthographic;

	public bool CadCamViewportShowCubeBox = true;

	public bool CadCamViewportShowUcsArrow = true;

	public bool CadCamViewportShowOrigineSembol = true;

	public bool CadCamViewportShowMouseCoordinates = true;

	public Color DialogViewportBottomColor = Color.DarkGray;

	public Color DialogViewportMiddleColor = Color.Silver;

	public Color DialogViewportTopColor = Color.Gray;

	public DisplayModeType DialogViewportDisplayType = DisplayModeType.Rendered;

	public ProjectionModeType DialogViewportProjection = ProjectionModeType.Orthographic;

	public bool DialogViewportShowCubeBox = true;

	public bool DialogViewportShowUcsArrow = true;

	public bool DialogViewportShowOrigineSembol = true;

	public bool DialogViewportShowMouseCoordinates = true;
}
