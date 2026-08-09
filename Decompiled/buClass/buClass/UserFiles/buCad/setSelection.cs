using System.Drawing;
using System.Reflection;

namespace buClass.UserFiles.buCad;

public class setSelection : buSerilization
{
	public DynamicalSelectionType DynamicSelection = DynamicalSelectionType.Entity;

	public MinMaxType DynamicSelectionDistanceType = MinMaxType.Min;

	public int SelectionTransparancy = 100;

	public Color colorSelectionLeftToRight = Color.DarkBlue;

	public drawPropertiesType displaySelectionLeftToRightBorder = new drawPropertiesType(Color.DarkBlue, 1f, new drawingPattern());

	public Color colorSelectionRightToLeft = Color.DarkRed;

	public drawPropertiesType displaySelectionRightToLeftBorder = new drawPropertiesType(Color.DarkRed, 1f, new drawingPattern());

	public bool ShowHighLight = true;

	public drawPropertiesType displayHighLight = new drawPropertiesType(Color.Yellow, 2f, new drawingPattern());

	public drawPropertiesType displaySelectedEntity = new drawPropertiesType(Color.DeepSkyBlue, 1f, new drawingPattern());

	public double SelectionBoxSize = 12.0;

	public drawPropertiesType displaySelectionBox = new drawPropertiesType(Color.Blue, 2f, new drawingPattern());

	public drawPropertiesType displaySelectionBoxControlSelected = new drawPropertiesType(Color.Red, 2f, new drawingPattern());

	public drawPropertiesType displaySelectionBoxMove = new drawPropertiesType(Color.BlueViolet, 2f, new drawingPattern());

	public drawPropertiesType displaySelectionBoxBoxSize = new drawPropertiesType(Color.AliceBlue, 2f, new drawingPattern());

	public bool ShowBoxSizeBoxes = false;

	public bool Enable3DPointsWithMouseClick = true;

	public bool ShowAllBoxes = true;

	public bool SmartSelection = false;

	public double SelectionResolution = 0.01;

	public double CompareResolution = 0.01;

	public bool UseSelectedEntityLayerForChainEntities = true;

	public bool DontUseRectangleSelection = false;

	public bool DontSelectGroupItem = false;

	public int MinVeeticeCount = 0;

	public bool OnlyClosedShapes = false;

	public double MinSingleEntityLength = 0.0;

	public bool ClearSelectionWhenPressEmptySpace = false;

	public bool MoveEntityWhenClickAlreadySelected = false;

	public bool SelectInternalEntitiesWhenClick = false;

	public setSelection()
	{
	}

	public setSelection(setSelection data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				string name = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
