using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class MaterialBase5 : buSerilization5
{
	public string Name = "Material";

	public List<Point3D> Points = new List<Point3D>();

	public List<List<Point3D>> InnerPoints = null;

	public SolidItemDisplay Display = new SolidItemDisplay(Color.Linen, 100, Color.Brown, 200);

	public Point3D StartPoint = new Point3D();

	public Point3D BoxMinPoint = new Point3D();

	public Point3D BoxMaxPoint = new Point3D();

	public Point3D Sing = new Point3D(1.0, 1.0, 1.0);

	public Image matImage = null;

	public SizeObject Size = new SizeObject(400.0, 200.0, 25.0);

	public double FrontAngle = 0.0;

	public double BackAngle = 0.0;

	public double LeftAngle = 0.0;

	public double RightAngle = 0.0;

	public MaterialShapes Shapes = MaterialShapes.Rectangle;

	public MaterialPurpose Purpose = MaterialPurpose.Door;

	public bool Enable = true;

	public double Angle = 0.0;

	public double Radius = 10.0;

	public double Diameter = 100.0;

	public double MajorRadius = 100.0;

	public double MinorRadius = 50.0;

	public double RoundRadiue = 5.0;

	public double ChamferLength = 5.0;

	public double dX = 0.0;

	public double dY = 0.0;

	public double dZ = 0.0;

	public double OffsetX = 0.0;

	public double OffsetY = 0.0;

	public bool TopIsZeroPosition = false;

	public string FileName = Application.StartupPath;

	public string FileNameImage = Application.StartupPath;

	public List<Entity> Entities = new List<Entity>();

	public MaterialBase5()
	{
	}

	public MaterialBase5(MaterialBase5 mat)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(mat, ref CopiedClass);
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
		if (mat.matImage != null)
		{
			matImage = (Image)mat.matImage.Clone();
		}
		Display = new SolidItemDisplay(mat.Display);
		Size = new SizeObject(mat.Size);
		StartPoint = buVector5.ToPoint3D(mat.StartPoint);
		BoxMinPoint = buVector5.ToPoint3D(mat.BoxMinPoint);
		BoxMaxPoint = buVector5.ToPoint3D(mat.BoxMaxPoint);
		Points.Clear();
		buVector5.Copy(mat.Points, ref Points);
		if (mat.InnerPoints != null)
		{
			buVector5.Copy(mat.InnerPoints, ref InnerPoints);
		}
		if (mat.Entities != null)
		{
			buVector5.CopyEntities(mat.Entities, ref Entities);
		}
	}

	public MaterialBase5(SizeObject size)
	{
		Size = new SizeObject(size);
	}

	public MaterialBase5(double width, double height, double depth)
	{
		Size = new SizeObject(width, height, depth);
	}

	public static void Copy(List<MaterialBase5> RefList, ref List<MaterialBase5> CopiedList)
	{
		try
		{
			if (RefList != null)
			{
				if (CopiedList == null)
				{
					CopiedList = new List<MaterialBase5>();
				}
				for (int i = 0; i <= RefList.Count - 1; i++)
				{
					CopiedList.Add(new MaterialBase5(RefList[i]));
				}
			}
		}
		catch (Exception)
		{
			CopiedList = new List<MaterialBase5>();
		}
	}

	public static void Copy(List<List<MaterialBase5>> RefList, ref List<List<MaterialBase5>> CopiedList)
	{
		try
		{
			if (RefList == null)
			{
				return;
			}
			if (CopiedList == null)
			{
				CopiedList = new List<List<MaterialBase5>>();
			}
			for (int i = 0; i <= RefList.Count - 1; i++)
			{
				List<MaterialBase5> CopiedList2 = new List<MaterialBase5>();
				Copy(RefList[i], ref CopiedList2);
				if (CopiedList2 != null && CopiedList2.Count > 0)
				{
					CopiedList.Add(CopiedList2);
				}
			}
		}
		catch (Exception)
		{
			CopiedList = new List<List<MaterialBase5>>();
		}
	}

	public override string ToString()
	{
		return "X: " + BoxMinPoint.X.ToString("f2") + " Y: " + BoxMinPoint.Y.ToString("f2") + " W: " + Size.Width.ToString("f2") + " H: " + Size.Height.ToString("f2") + " " + Name;
	}
}
