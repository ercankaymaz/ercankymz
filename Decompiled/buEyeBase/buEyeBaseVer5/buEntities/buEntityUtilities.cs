using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.buEntities;

public class buEntityUtilities
{
	public static double EntityRegenDeviation;

	public static void BoxSizeCalculate(List<Point3D> Points, ref Point3D MinPoint, ref Point3D MaxPoint)
	{
		try
		{
			MinPoint = new Point3D(double.MaxValue, double.MaxValue, double.MaxValue);
			MaxPoint = new Point3D(double.MinValue, double.MinValue, double.MinValue);
			for (int i = 0; i <= Points.Count - 1; i++)
			{
				if (Points[i].X > MaxPoint.X)
				{
					MaxPoint.X = Points[i].X;
				}
				if (Points[i].Y > MaxPoint.Y)
				{
					MaxPoint.Y = Points[i].Y;
				}
				if (Points[i].Z > MaxPoint.Z)
				{
					MaxPoint.Z = Points[i].Z;
				}
				if (Points[i].X < MinPoint.X)
				{
					MinPoint.X = Points[i].X;
				}
				if (Points[i].Y < MinPoint.Y)
				{
					MinPoint.Y = Points[i].Y;
				}
				if (Points[i].Z < MinPoint.Z)
				{
					MinPoint.Z = Points[i].Z;
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "Count: " + Points.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static buEntity convEntity(ICurve refEntity)
	{
		buEntity result = null;
		if (!(refEntity.GetType() == typeof(Point)))
		{
			if (!(refEntity.GetType() == typeof(Line)))
			{
				if (!(refEntity.GetType() == typeof(Arc)))
				{
					if (!(refEntity.GetType() == typeof(Circle)))
					{
						if (!(refEntity.GetType() == typeof(Ellipse)))
						{
							if (!(refEntity.GetType() == typeof(Curve)))
							{
								if (!(refEntity.GetType() == typeof(LinearPath)))
								{
									if (!(refEntity.GetType() == typeof(CompositeCurve)))
									{
										if (!(refEntity.GetType() == typeof(Region)))
										{
											if (refEntity.GetType() == typeof(Mesh))
											{
												result = new buMesh((Mesh)refEntity);
											}
										}
										else
										{
											result = new buRegion((Region)refEntity);
										}
									}
									else
									{
										result = new buCompositeCurve((CompositeCurve)refEntity);
									}
								}
								else
								{
									result = new buLinearPath((LinearPath)refEntity);
								}
							}
							else
							{
								result = new buCurve((Curve)refEntity);
							}
						}
						else
						{
							result = new buEllipse((Ellipse)refEntity);
						}
					}
					else
					{
						result = new buCircle((Circle)refEntity);
					}
				}
				else
				{
					result = new buArc((Arc)refEntity);
				}
			}
			else
			{
				result = new buLine((Line)refEntity);
			}
		}
		else
		{
			result = new buPoint((Point)refEntity);
		}
		return result;
	}
}
