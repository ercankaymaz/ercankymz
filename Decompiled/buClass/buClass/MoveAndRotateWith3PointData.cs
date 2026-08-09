using System.Reflection;

namespace buClass;

public class MoveAndRotateWith3PointData
{
	public Pnt3D PntMoveSelected = new Pnt3D();

	public Pnt3D PntMoveNew = new Pnt3D();

	public Pnt3D PntRotateASelected = new Pnt3D();

	public Pnt3D PntRotateANew = new Pnt3D();

	public Pnt3D PntRotateCSelected = new Pnt3D();

	public Pnt3D PntRotateCNew = new Pnt3D();

	public MoveAndRotateWith3PointData()
	{
	}

	public MoveAndRotateWith3PointData(MoveAndRotateWith3PointData data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
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
		PntMoveSelected = new Pnt3D(data.PntMoveSelected);
		PntMoveNew = new Pnt3D(data.PntMoveNew);
		PntRotateASelected = new Pnt3D(data.PntRotateASelected);
		PntRotateANew = new Pnt3D(data.PntRotateANew);
		PntRotateCSelected = new Pnt3D(data.PntRotateCSelected);
		PntRotateCNew = new Pnt3D(data.PntRotateCNew);
	}
}
