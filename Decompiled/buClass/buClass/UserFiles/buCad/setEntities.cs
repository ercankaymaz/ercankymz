using System.Drawing;
using System.Reflection;

namespace buClass.UserFiles.buCad;

public class setEntities : buSerilization
{
	public EntityResolution DynamicEntityResolution = new EntityResolution();

	public double EntityCatchRatio = 2.0;

	public double DimensionTextHeight = 5.0;

	public double PointVisibleThicknessOffset = 4.0;

	public double RegenDeviation = 0.01;

	public double RegenMaxLen = 0.0;

	public double RegenAngle = 0.0;

	public double SmallSizeRatio = 0.01;

	public bool DimensionDrawingPropertiesFromLayer = false;

	public bool ExplodeEntitiesAsNewEntity = false;

	public bool FinishPolylineIfClosed = true;

	public drawPropertiesType DimensionDrawing = new drawPropertiesType(Color.DimGray, 1f, new drawingPattern());

	public bool ContinuesTrim = true;

	public bool ContinuesExtend = true;

	public ScaleType ScaleMode = ScaleType.Size;

	public InsertEntitiesTYpe InsertEntititesMode = InsertEntitiesTYpe.ByMouse;

	public double MinVerticesDistance = 0.0;

	public setEntities()
	{
	}

	public setEntities(setEntities data)
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
