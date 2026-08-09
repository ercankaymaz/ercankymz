using System;
using System.Collections.Generic;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

public class buCutterCalc
{
	public void SetNotchOnContour(List<Entity> NotchEntities, List<Entity> OutterEntities, bool VNotch, bool INotch, ref List<List<Entity>> calcEntities)
	{
		List<Entity> BaseRefEntities = new List<Entity>();
		List<Entity> list = new List<Entity>();
		for (int i = 0; i <= OutterEntities.Count - 1; i++)
		{
			ICurve curve = OutterEntities[i] as ICurve;
			List<Point3D> list2 = new List<Point3D>();
			List<Point3D> list3 = new List<Point3D>();
			for (int j = 0; j <= NotchEntities.Count - 1; j++)
			{
				bool flag = true;
				if (((CustomData)NotchEntities[j].EntityData).infoString == "INotch" && !INotch)
				{
					flag = false;
				}
				if (((CustomData)NotchEntities[j].EntityData).infoString == "VNotch" && !VNotch)
				{
					flag = false;
				}
				if (!flag)
				{
					continue;
				}
				Point3D point3D = buVector5.ToPoint3D(((ICurve)NotchEntities[j]).StartPoint);
				Point3D point3D2 = buVector5.ToPoint3D(((ICurve)NotchEntities[j]).EndPoint);
				if (!(buCall.buVector5_0.isPointInsideEntity(curve, point3D, buSystem.resolutionCompare) & buCall.buVector5_0.isPointInsideEntity(curve, point3D2, buSystem.resolutionCompare)))
				{
					if (!buCall.buVector5_0.isPointInsideEntity(curve, point3D, buSystem.resolutionCompare))
					{
						if (buCall.buVector5_0.isPointInsideEntity(curve, point3D2, buSystem.resolutionCompare))
						{
							new List<Point3D>();
							list3.Add(buVector5.ToPoint3D(point3D2));
						}
					}
					else
					{
						new List<Point3D>();
						list3.Add(buVector5.ToPoint3D(point3D));
					}
				}
				else
				{
					new List<Point3D>();
					list3.Add(buVector5.ToPoint3D(point3D));
					list3.Add(buVector5.ToPoint3D(point3D2));
					list2.Add(buVector5.ToPoint3D(point3D));
					list2.Add(buVector5.ToPoint3D(point3D));
				}
			}
			if (list3.Count <= 0)
			{
				list.Add(buVector5.CopyEntities(OutterEntities[i]));
				continue;
			}
			ICurve[] segments = null;
			curve.SplitBy(list3, out segments);
			if (segments == null)
			{
				list.Add(buVector5.CopyEntities(OutterEntities[i]));
				continue;
			}
			for (int k = 0; k <= segments.Length - 1; k++)
			{
				for (int num = NotchEntities.Count - 1; num >= 0; num--)
				{
					ICurve curve2 = NotchEntities[num] as ICurve;
					if (!(buCompare5.EQ(segments[k].StartPoint, curve2.StartPoint, 0.01) & buCompare5.EQ(segments[k].EndPoint, curve2.EndPoint, 0.01)))
					{
						if (buCompare5.EQ(segments[k].EndPoint, curve2.StartPoint, 0.01) & buCompare5.EQ(segments[k].StartPoint, curve2.EndPoint, 0.01))
						{
							segments[k] = (ICurve)buVector5.CopyEntities(NotchEntities[num]);
							NotchEntities.RemoveAt(num);
						}
					}
					else
					{
						segments[k] = (ICurve)buVector5.CopyEntities(NotchEntities[num]);
						NotchEntities.RemoveAt(num);
					}
				}
			}
			if (NotchEntities.Count <= 0)
			{
				for (int l = 0; l <= segments.Length - 1; l++)
				{
					BaseRefEntities.Add(buVector5.CopyEntities((Entity)segments[l]));
				}
				continue;
			}
			for (int num2 = NotchEntities.Count - 1; num2 >= 0; num2--)
			{
				BaseRefEntities.Add(buVector5.CopyEntities(NotchEntities[num2]));
			}
			for (int m = 0; m <= segments.Length - 1; m++)
			{
				BaseRefEntities.Add(buVector5.CopyEntities((Entity)segments[m]));
			}
		}
		if (list.Count <= 0)
		{
			if (BaseRefEntities.Count > 0)
			{
				SortSettings sortSettings = new SortSettings();
				SortResult Result = new SortResult();
				List<Entity> SortedEntities = new List<Entity>();
				sortSettings.Option.IntersectionRules = SortingIntersectionRulesType.LowerIndex;
				sortSettings.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
				calcEntities.Clear();
				calcEntities = new List<List<Entity>>();
				buCall.buVector5_0.SortEntitiesByRefPoint(((ICurve)OutterEntities[0]).StartPoint, ref BaseRefEntities, sortSettings, ref SortedEntities, ref Result);
				buCall.buVector5_0.EntitiesSplitByUpperLine(SortedEntities, ref calcEntities);
			}
		}
		else
		{
			calcEntities.Clear();
			calcEntities = new List<List<Entity>>();
			calcEntities.Add(list);
		}
	}

	public void CreateNotch(CutterNotchType notchType, Point3D Position, double Length, double DirectionAngle, double Angle, ICurve baseEntity, ref List<Entity> notchEntities)
	{
		Point3D EndPnt = new Point3D();
		buCall.buVector5_0.LineWithLengthAndAngle(Position, Length, DirectionAngle, Plane.XY, ref EndPnt);
		if (notchType != CutterNotchType.INotch)
		{
			List<Point3D> TriangleVertice = new List<Point3D>();
			double triangleLength = Length * Math.Cos(buConversion5.DegreeToRadian(Angle / 2.0));
			buCall.buVector5_0.TriangleAtPointByLineRef(Position, EndPnt, Angle / 2.0, triangleLength, Plane.XY, Reverse: false, FromBaseLine: true, ref TriangleVertice);
			List<Point3D> list = new List<Point3D>();
			Point3D point3D = new Point3D(TriangleVertice[1].X, TriangleVertice[1].Y, TriangleVertice[1].Z);
			Point3D point3D2 = new Point3D(TriangleVertice[2].X, TriangleVertice[2].Y, TriangleVertice[2].Z);
			Point3D point3D3 = new Point3D(TriangleVertice[0].X, TriangleVertice[0].Y, TriangleVertice[0].Z);
			Vector3D vector3D = new Vector3D(point3D3, point3D);
			vector3D.Normalize();
			Line c = new Line(point3D3 + vector3D * 10.0, point3D + vector3D * -10.0);
			Point3D[] array = baseEntity.IntersectWith(c);
			if (array != null && array.Length != 0)
			{
				double num = 1000000000.0;
				int num2 = -1;
				for (int i = 0; i <= array.Length - 1; i++)
				{
					double num3 = Point3D.Distance(array[i], point3D);
					if (num3 < num)
					{
						num = num3;
						num2 = i;
					}
				}
				if (num2 >= 0)
				{
					point3D = buVector5.ToPoint3D(array[num2]);
				}
			}
			vector3D = new Vector3D(point3D3, point3D2);
			vector3D.Normalize();
			Line c2 = new Line(point3D3 + vector3D * 10.0, point3D2 + vector3D * -10.0);
			Point3D[] array2 = baseEntity.IntersectWith(c2);
			if (array2 != null && array2.Length != 0)
			{
				double num4 = 1000000000.0;
				int num5 = -1;
				for (int j = 0; j <= array2.Length - 1; j++)
				{
					double num6 = Point3D.Distance(array2[j], point3D2);
					if (num6 < num4)
					{
						num4 = num6;
						num5 = j;
					}
				}
				if (num5 >= 0)
				{
					point3D2 = buVector5.ToPoint3D(array2[num5]);
				}
			}
			list.Add(point3D);
			list.Add(point3D3);
			list.Add(point3D2);
			LinearPath linearPath = new LinearPath(list);
			linearPath.EntityData = new CustomData();
			notchEntities.Add(linearPath);
		}
		else
		{
			Line line = new Line(Position, EndPnt);
			line.EntityData = new CustomData();
			notchEntities.Add(line);
		}
	}

	public void RotateNotch(ref Entity refEntities)
	{
		refEntities.Rotate(buConversion5.DegreeToRadian(180.0), new Vector3D(0.0, 0.0, 1.0), ((CustomData)refEntities.EntityData).infoBasePoint);
		refEntities.Regen(0.01);
	}

	public bool WriteIsoFile(string FileName, int Index, CutterIsoFileSettings Settings, buNestedResult NestResult, CutterProgramSettings ProgramSettings, ref List<List<Entity>> DrawEntities)
	{
		bool flag = false;
		new List<string>();
		DrawEntities.Clear();
		DrawEntities = new List<List<Entity>>();
		string text = "";
		text = "H1*";
		text += "ZX984251*D2*M15*";
		if ((Index >= 0) & (Index <= NestResult.NestedResultSheets.Count - 1))
		{
			for (int i = 0; i <= NestResult.NestedResultSheets[Index].Parts.Count - 1; i++)
			{
				text = text + "N" + (i + 1) + "*";
				new List<Entity>();
				new List<List<Entity>>();
				new List<List<Entity>>();
				CutterIsoEntities Entities = new CutterIsoEntities();
				List<List<Entity>> calcEntities = new List<List<Entity>>();
				CutterIsoError Error = new CutterIsoError();
				buCall.buNestingCalc_0.NestedPartToCutterEntity(NestResult.NestedResultSheets[Index].Parts[i], ProgramSettings.DrillMainDaimeterValue, ProgramSettings.DrillAuxDaimeterValue, ref Entities, ref Error);
				if (!Error.DrillDiameterError)
				{
					if (!Settings.NotchOnContour)
					{
						calcEntities.Add(Entities.OutsideCenterEntities);
					}
					else
					{
						SetNotchOnContour(Entities.NotchCenterEntities, Entities.OutsideCenterEntities, VNotch: true, INotch: true, ref calcEntities);
					}
					buVector5.AddEntities(calcEntities, ref DrawEntities);
					if (Entities.InnerCenterEntities.Count > 0)
					{
						for (int j = 0; j <= Entities.InnerCenterEntities.Count - 1; j++)
						{
							List<Point3D> Points = new List<Point3D>();
							buCall.buVector5_0.EntitiesToPointsWithCamDirection(Entities.InnerCenterEntities[j], buSystem.RegenDeviation, ref Points);
							if (Points.Count > 1)
							{
								text += "D2*M15*";
								text = text + "X" + Convert.ToInt32(Points[0].X / Settings.XScaleFactor) + "Y" + Convert.ToInt32(Points[0].Y / Settings.YScaleFactor) + "*";
								text += "M14*";
								for (int k = 1; k <= Points.Count - 1; k++)
								{
									text = text + "X" + Convert.ToInt32(Points[k].X / Settings.XScaleFactor) + "Y" + Convert.ToInt32(Points[k].Y / Settings.YScaleFactor) + "*";
								}
								text += "D2*M15*";
								flag = true;
							}
						}
					}
					if (Entities.DrillMainEntities.Count > 0)
					{
						if (!flag)
						{
							text += "D2*M15*";
						}
						for (int l = 0; l <= Entities.DrillMainEntities.Count - 1; l++)
						{
							Circle circle = null;
							if (Entities.DrillMainEntities[l] is Circle)
							{
								circle = Entities.DrillMainEntities[l] as Circle;
								text = text + "X" + Convert.ToInt32(circle.Center.X / Settings.XScaleFactor) + "Y" + Convert.ToInt32(circle.Center.Y / Settings.YScaleFactor) + "M43*";
								text += "D2*M15*";
								flag = true;
							}
						}
					}
					if (Entities.DrillAuxEntities.Count > 0)
					{
						if (!flag)
						{
							text += "D2*M15*";
						}
						for (int m = 0; m <= Entities.DrillAuxEntities.Count - 1; m++)
						{
							Circle circle2 = null;
							if (Entities.DrillMainEntities[m] is Circle)
							{
								circle2 = Entities.DrillAuxEntities[m] as Circle;
								text = text + "X" + Convert.ToInt32(circle2.Center.X / Settings.XScaleFactor) + "Y" + Convert.ToInt32(circle2.Center.Y / Settings.YScaleFactor) + "M44*";
							}
						}
						text += "D2*M15*";
						flag = true;
					}
					if (calcEntities.Count <= 0)
					{
						continue;
					}
					if (!flag)
					{
						text += "D2*M15*";
					}
					for (int n = 0; n <= calcEntities.Count - 1; n++)
					{
						List<Point3D> Points2 = new List<Point3D>();
						buCall.buVector5_0.EntitiesToPointsWithCamDirection(calcEntities[n], buSystem.RegenDeviation, ref Points2);
						if (Points2.Count <= 1)
						{
							continue;
						}
						text = text + "X" + Convert.ToInt32(Points2[0].X / Settings.XScaleFactor) + "Y" + Convert.ToInt32(Points2[0].Y / Settings.YScaleFactor) + "*";
						text += "M14*";
						for (int num = 1; num <= Points2.Count - 1; num++)
						{
							if ((num == Points2.Count - 1) & (n < calcEntities.Count - 1))
							{
								text += "M14*";
							}
							text = text + "X" + Convert.ToInt32(Points2[num].X / Settings.XScaleFactor) + "Y" + Convert.ToInt32(Points2[num].Y / Settings.YScaleFactor) + "*";
						}
						text += "D2*M15*";
						flag = true;
					}
					continue;
				}
				buString5.MessageBoxError(buCutter.LangCutterMessage[0]);
				return false;
			}
			if (!flag)
			{
				text += "D2*M15*";
			}
			text = text + "QX" + Convert.ToInt32(NestResult.NestedResultSheets[Index].SheetMaxXPosition / Settings.XScaleFactor) + "Y0*";
		}
		text += "M0**";
		if (text.Length > 0)
		{
			buFile5.SaveToFile(text, FileName);
		}
		return true;
	}
}
