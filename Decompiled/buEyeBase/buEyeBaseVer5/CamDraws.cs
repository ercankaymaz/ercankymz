using System.Drawing;
using buClass;

namespace buEyeBaseVer5;

public class CamDraws
{
	public drawPropertiesType CamMarkDraw = new drawPropertiesType(Color.DarkGreen, 2f, new drawingPattern());

	public drawPropertiesType CamG0Draw = new drawPropertiesType(Color.Brown, 2f, new drawingPattern());

	public drawPropertiesType CamG1Draw = new drawPropertiesType(Color.Blue, 2f, new drawingPattern());

	public drawPropertiesType CamPlungeDraw = new drawPropertiesType(Color.Lime, 2f, new drawingPattern());

	public drawPropertiesType CamLeaveDraw = new drawPropertiesType(Color.Red, 2f, new drawingPattern());

	public drawPropertiesType CamLeadinDraw = new drawPropertiesType(Color.Cyan, 2f, new drawingPattern());

	public drawPropertiesType CamLeadOutDraw = new drawPropertiesType(Color.Orange, 2f, new drawingPattern());

	public drawPropertiesType CamOtherDraw = new drawPropertiesType(Color.DarkGray, 2f, new drawingPattern());
}
