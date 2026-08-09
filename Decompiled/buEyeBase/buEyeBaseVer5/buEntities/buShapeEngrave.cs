using System.Reflection;
using buClass;
using devDept.Eyeshot.Entities;

namespace buEyeBaseVer5.buEntities;

public class buShapeEngrave : buShape
{
	public double Width = 0.0;

	public double Height = 0.0;

	public bool isFinish = false;

	public Entity entityMesh = null;

	public buShapeEngrave()
	{
		ShapeGroup = ShapeGroup.Engraving;
	}

	public buShapeEngrave(double depth, double width, double height, Entity mesh)
	{
		Width = width;
		Height = height;
		Depth = depth;
		if (mesh != null)
		{
			buEntity.Copy(mesh, ref entityMesh);
		}
		ShapeGroup = ShapeGroup.Engraving;
	}

	public buShapeEngrave(buShape data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
		{
			FieldInfo[] fields = GetType().GetFields();
			if (fields != null)
			{
				for (int i = 0; i <= fields.Length - 1; i++)
				{
					_ = fields[i].Name;
					object value = fields[i].GetValue(CopiedClass);
					fields[i].SetValue(this, value);
				}
			}
		}
		if (data is buShapeEngrave && ((buShapeEngrave)data).entityMesh != null)
		{
			buEntity.Copy(((buShapeEngrave)data).entityMesh, ref entityMesh);
		}
	}

	public override string ToString()
	{
		string text = "Engrave | " + planeName.ToString() + " -";
		return text + " Width: " + Width.ToString("f2") + " , Height: " + Height.ToString("f2");
	}
}
