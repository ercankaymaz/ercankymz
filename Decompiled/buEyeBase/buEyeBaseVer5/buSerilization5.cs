using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using ns71;

namespace buEyeBaseVer5;

[Serializable]
public class buSerilization5
{
	public static List<string> ExceptionalVariables = new List<string>();

	public static string ToDef(IndexTriangle P)
	{
		return P.V1 + " ; " + P.V2 + " ; " + P.V3;
	}

	public static string ToDef(Point3D P)
	{
		return P.X + " ; " + P.Y + " ; " + P.Z;
	}

	public static string ToDef(Point4D P)
	{
		return P.X + " ; " + P.Y + " ; " + P.Z + " ; " + P.W;
	}

	public static string ToDef(Vector3D P)
	{
		return P.X + " ; " + P.Y + " ; " + P.Z;
	}

	public static string ToDef(OrientationAngle P)
	{
		return P.A + " ; " + P.B + " ; " + P.C;
	}

	public static ArrayList ToDef(Plane P, string Char, int Space)
	{
		ArrayList arrayList = new ArrayList();
		string text = Char;
		if (text.Length <= 0)
		{
			text = "WorkPlane";
		}
		arrayList.Add(buString5.SpaceChar(Space) + "<" + text + ">");
		arrayList.Add(buString5.SpaceChar(Space) + ToDef(P));
		arrayList.Add(buString5.SpaceChar(Space) + "</" + text + ">");
		return arrayList;
	}

	public static string ToDef(Plane P)
	{
		return P.Origin.X + " ; " + P.Origin.Y + " ; " + P.Origin.Z + " # " + P.AxisX.X + " ; " + P.AxisX.Y + " ; " + P.AxisX.Z + " # " + P.AxisY.X + " ; " + P.AxisY.Y + " ; " + P.AxisY.Z + " # " + P.Equation.X + " ; " + P.Equation.Y + " ; " + P.Equation.Z;
	}

	public static double DecoderFromDouble(string Line)
	{
		try
		{
			string[] array = Line.Split(':');
			if (array != null)
			{
				if (array.Length == 1)
				{
					double result = 0.0;
					double.TryParse(array[0], out result);
					return result;
				}
				if (array.Length == 2)
				{
					double result2 = 0.0;
					double.TryParse(array[1], out result2);
					return result2;
				}
			}
			return 0.0;
		}
		catch (Exception)
		{
			return 0.0;
		}
	}

	public static int DecoderFromInt(string Line)
	{
		try
		{
			string[] array = Line.Split(':');
			if (array != null)
			{
				if (array.Length == 1)
				{
					int result = 0;
					int.TryParse(array[0], out result);
					return result;
				}
				if (array.Length == 2)
				{
					int result2 = 0;
					int.TryParse(array[1], out result2);
					return result2;
				}
			}
			return 0;
		}
		catch (Exception)
		{
			return 0;
		}
	}

	public static float DecoderFromFloat(string Line)
	{
		try
		{
			string[] array = Line.Split(':');
			if (array != null)
			{
				if (array.Length == 1)
				{
					float result = 0f;
					float.TryParse(array[0], out result);
					return result;
				}
				if (array.Length == 2)
				{
					float result2 = 0f;
					float.TryParse(array[1], out result2);
					return result2;
				}
			}
			return 0f;
		}
		catch (Exception)
		{
			return 0f;
		}
	}

	public static bool DecoderFromBool(string Line)
	{
		try
		{
			string[] array = Line.Split(':');
			if (array != null)
			{
				if (array.Length == 1)
				{
					bool result = false;
					bool.TryParse(array[0], out result);
					return result;
				}
				if (array.Length == 2)
				{
					bool result2 = false;
					bool.TryParse(array[1], out result2);
					return result2;
				}
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public static string DecoderFromString(string Line)
	{
		try
		{
			string[] array = Line.Split(':');
			if (array != null)
			{
				if (array.Length == 1)
				{
					return array[0];
				}
				if (array.Length == 2)
				{
					return array[1];
				}
				if (array.Length == 3)
				{
					return array[1] + ":" + array[2];
				}
			}
			return "";
		}
		catch (Exception)
		{
			return "";
		}
	}

	public static IndexTriangle DecoderFromTriangleIndex(string Line)
	{
		try
		{
			string[] array = Line.Split(':');
			if (array != null)
			{
				string text = "";
				if (array.Length == 1)
				{
					text = array[0];
				}
				if (array.Length == 2)
				{
					text = array[1];
				}
				if (text.Length > 0)
				{
					string[] array2 = text.Split(';');
					if (array2.Length == 3)
					{
						int result = 0;
						int result2 = 0;
						int result3 = 0;
						int.TryParse(array2[0], out result);
						int.TryParse(array2[1], out result2);
						int.TryParse(array2[2], out result3);
						return new IndexTriangle(result, result2, result3);
					}
				}
			}
			return new IndexTriangle();
		}
		catch (Exception)
		{
			return new IndexTriangle();
		}
	}

	public static Point3D DecoderFromPoint3D(string Line)
	{
		try
		{
			string[] array = Line.Split(':');
			if (array != null)
			{
				string text = "";
				if (array.Length == 1)
				{
					text = array[0];
				}
				if (array.Length == 2)
				{
					text = array[1];
				}
				if (text.Length > 0)
				{
					string[] array2 = text.Split(';');
					if (array2.Length == 3)
					{
						double result = 0.0;
						double result2 = 0.0;
						double result3 = 0.0;
						double.TryParse(array2[0], out result);
						double.TryParse(array2[1], out result2);
						double.TryParse(array2[2], out result3);
						return new Point3D(result, result2, result3);
					}
				}
			}
			return new Point3D();
		}
		catch (Exception)
		{
			return new Point3D();
		}
	}

	public static Point4D DecoderFromPoint4D(string Line)
	{
		try
		{
			string[] array = Line.Split(':');
			if (array != null)
			{
				string text = "";
				if (array.Length == 1)
				{
					text = array[0];
				}
				if (array.Length == 2)
				{
					text = array[1];
				}
				if (text.Length > 0)
				{
					string[] array2 = text.Split(';');
					if (array2.Length == 3)
					{
						double result = 0.0;
						double result2 = 0.0;
						double result3 = 0.0;
						double.TryParse(array2[0], out result);
						double.TryParse(array2[1], out result2);
						double.TryParse(array2[2], out result3);
						return new Point4D(result, result2, result3, 0.0);
					}
					if (array2.Length == 4)
					{
						double result4 = 0.0;
						double result5 = 0.0;
						double result6 = 0.0;
						double result7 = 0.0;
						double.TryParse(array2[0], out result4);
						double.TryParse(array2[1], out result5);
						double.TryParse(array2[2], out result6);
						double.TryParse(array2[3], out result7);
						return new Point4D(result4, result5, result6, result7);
					}
				}
			}
			return new Point4D();
		}
		catch (Exception)
		{
			return new Point4D();
		}
	}

	public static Vector3D DecoderFromVector3D(string Line)
	{
		try
		{
			string[] array = Line.Split(':');
			if (array != null)
			{
				string text = "";
				if (array.Length == 1)
				{
					text = array[0];
				}
				if (array.Length == 2)
				{
					text = array[1];
				}
				if (text.Length > 0)
				{
					string[] array2 = text.Split(';');
					if (array2.Length == 3)
					{
						double result = 0.0;
						double result2 = 0.0;
						double result3 = 0.0;
						double.TryParse(array2[0], out result);
						double.TryParse(array2[1], out result2);
						double.TryParse(array2[2], out result3);
						return new Vector3D(result, result2, result3);
					}
				}
			}
			return new Vector3D();
		}
		catch (Exception)
		{
			return new Vector3D();
		}
	}

	public static Plane DecoderFromPlane(string Line)
	{
		try
		{
			Plane result = null;
			Point3D point3D = null;
			Vector3D vector3D = null;
			Vector3D vector3D2 = null;
			Vector3D vector3D3 = null;
			string[] array = Line.Split(':');
			if (array != null)
			{
				string text = "";
				if (array.Length == 1)
				{
					text = array[0];
				}
				if (array.Length == 2)
				{
					text = array[1];
				}
				if (text.Length > 0)
				{
					string[] array2 = text.Split('#');
					if ((array2 != null) & (array2.Length >= 1))
					{
						string[] array3 = array2[0].Split(';');
						if (array3.Length == 3)
						{
							double result2 = 0.0;
							double result3 = 0.0;
							double result4 = 0.0;
							double.TryParse(array3[0], out result2);
							double.TryParse(array3[1], out result3);
							double.TryParse(array3[2], out result4);
							point3D = new Point3D(result2, result3, result4);
						}
					}
					if ((array2 != null) & (array2.Length >= 2))
					{
						string[] array4 = array2[1].Split(';');
						if (array4.Length == 3)
						{
							double result5 = 0.0;
							double result6 = 0.0;
							double result7 = 0.0;
							double.TryParse(array4[0], out result5);
							double.TryParse(array4[1], out result6);
							double.TryParse(array4[2], out result7);
							vector3D = new Vector3D(result5, result6, result7);
						}
					}
					if ((array2 != null) & (array2.Length >= 3))
					{
						string[] array5 = array2[2].Split(';');
						if (array5.Length == 3)
						{
							double result8 = 0.0;
							double result9 = 0.0;
							double result10 = 0.0;
							double.TryParse(array5[0], out result8);
							double.TryParse(array5[1], out result9);
							double.TryParse(array5[2], out result10);
							vector3D2 = new Vector3D(result8, result9, result10);
						}
					}
					if ((array2 != null) & (array2.Length >= 4))
					{
						string[] array6 = array2[3].Split(';');
						if (array6.Length == 3)
						{
							double result11 = 0.0;
							double result12 = 0.0;
							double result13 = 0.0;
							double.TryParse(array6[0], out result11);
							double.TryParse(array6[1], out result12);
							double.TryParse(array6[2], out result13);
							vector3D3 = new Vector3D(result11, result12, result13);
						}
					}
					if (!((point3D != null) & (vector3D != null) & (vector3D2 != null)))
					{
						if (vector3D3 != null)
						{
							result = new Plane(vector3D3);
						}
					}
					else
					{
						result = new Plane(point3D, vector3D, vector3D2);
					}
				}
			}
			return result;
		}
		catch (Exception)
		{
			return Plane.XY;
		}
	}

	public static OrientationAngle DecoderFromOrientationAngle(string Line)
	{
		try
		{
			string[] array = Line.Split(':');
			if (array != null)
			{
				string text = "";
				if (array.Length == 1)
				{
					text = array[0];
				}
				if (array.Length == 2)
				{
					text = array[1];
				}
				if (text.Length > 0)
				{
					string[] array2 = text.Split(';');
					if (array2.Length == 3)
					{
						double result = 0.0;
						double result2 = 0.0;
						double result3 = 0.0;
						double.TryParse(array2[0], out result);
						double.TryParse(array2[1], out result2);
						double.TryParse(array2[2], out result3);
						return new OrientationAngle(result, result2, result3);
					}
				}
			}
			return new OrientationAngle();
		}
		catch (Exception)
		{
			return new OrientationAngle();
		}
	}

	public static Pnt3D DecoderFromPnt3D(string Line)
	{
		try
		{
			string[] array = Line.Split(':');
			if (array != null)
			{
				string text = "";
				if (array.Length == 1)
				{
					text = array[0];
				}
				if (array.Length == 2)
				{
					text = array[1];
				}
				if (text.Length > 0)
				{
					string[] array2 = text.Split(';');
					if (array2.Length == 3)
					{
						double result = 0.0;
						double result2 = 0.0;
						double result3 = 0.0;
						double.TryParse(array2[0], out result);
						double.TryParse(array2[1], out result2);
						double.TryParse(array2[2], out result3);
						return new Pnt3D(result, result2, result3);
					}
				}
			}
			return new Pnt3D();
		}
		catch (Exception)
		{
			return new Pnt3D();
		}
	}

	public static Pnt6D DecoderFromPnt6D(string Line)
	{
		try
		{
			string[] array = Line.Split(':');
			if (array != null)
			{
				string text = "";
				if (array.Length == 1)
				{
					text = array[0];
				}
				if (array.Length == 2)
				{
					text = array[1];
				}
				if (text.Length > 0)
				{
					string[] array2 = text.Split(';');
					if (array2.Length == 6)
					{
						double result = 0.0;
						double result2 = 0.0;
						double result3 = 0.0;
						double result4 = 0.0;
						double result5 = 0.0;
						double result6 = 0.0;
						double.TryParse(array2[0], out result);
						double.TryParse(array2[1], out result2);
						double.TryParse(array2[2], out result3);
						double.TryParse(array2[3], out result4);
						double.TryParse(array2[4], out result5);
						double.TryParse(array2[5], out result6);
						return new Pnt6D(result, result2, result3, result4, result5, result6);
					}
				}
			}
			return new Pnt6D();
		}
		catch (Exception)
		{
			return new Pnt6D();
		}
	}

	public static entitySortDirection DecoderFromSortDirection(string Line)
	{
		try
		{
			string[] array = Line.Split(':');
			if (array != null)
			{
				if (array.Length == 1)
				{
					string text = array[0];
					EnumConverter enumConverter = new EnumConverter(typeof(entitySortDirection));
					return (entitySortDirection)enumConverter.ConvertFromString(text.ToString());
				}
				if (array.Length == 2)
				{
					string text2 = array[1];
					EnumConverter enumConverter2 = new EnumConverter(typeof(entitySortDirection));
					return (entitySortDirection)enumConverter2.ConvertFromString(text2.ToString());
				}
			}
			return entitySortDirection.Normal;
		}
		catch (Exception)
		{
			return entitySortDirection.Normal;
		}
	}

	public static entityTypeDefination DecoderFromDefinationType(string Line)
	{
		try
		{
			string[] array = Line.Split(':');
			if (array != null)
			{
				if (array.Length == 1)
				{
					string text = array[0];
					EnumConverter enumConverter = new EnumConverter(typeof(entityTypeDefination));
					return (entityTypeDefination)enumConverter.ConvertFromString(text.ToString());
				}
				if (array.Length == 2)
				{
					string text2 = array[1];
					EnumConverter enumConverter2 = new EnumConverter(typeof(entityTypeDefination));
					return (entityTypeDefination)enumConverter2.ConvertFromString(text2.ToString());
				}
			}
			return entityTypeDefination.None;
		}
		catch (Exception)
		{
			return entityTypeDefination.None;
		}
	}

	public static EntityInfo DecoderFromEntityInfo(List<string> Lines)
	{
		try
		{
			EntityInfo entityInfo = new EntityInfo();
			List<string> CalcList = new List<string>();
			buString5.ListToSpecificList("<EntInfo>", "</EntInfo>", AddStartEndKey: false, Lines, ref CalcList);
			if (CalcList.Count > 0)
			{
				for (int i = 0; i <= CalcList.Count - 1; i++)
				{
					if (CalcList[i].ToLower().IndexOf("sequence") >= 0)
					{
						entityInfo.Sequence = DecoderFromInt(CalcList[i]);
						entityInfo.OriginalEntityIndex = DecoderFromInt(CalcList[i + 1]);
						entityInfo.CamID = DecoderFromInt(CalcList[i + 2]);
						entityInfo.CamSelectable = DecoderFromBool(CalcList[i + 3]);
						entityInfo.CamSelected = DecoderFromBool(CalcList[i + 4]);
						entityInfo.DontUseForCalculation = DecoderFromBool(CalcList[i + 5]);
						entityInfo.RefIndex = DecoderFromInt(CalcList[i + 6]);
						entityInfo.Tags = DecoderFromString(CalcList[i + 7]);
					}
				}
			}
			return new EntityInfo();
		}
		catch (Exception)
		{
			return new EntityInfo();
		}
	}

	public static drillTypes DecoderFromDrillType(string Line)
	{
		try
		{
			string[] array = Line.Split(':');
			if (array != null)
			{
				if (array.Length == 1)
				{
					string text = array[0];
					EnumConverter enumConverter = new EnumConverter(typeof(drillTypes));
					return (drillTypes)enumConverter.ConvertFromString(text.ToString());
				}
				if (array.Length == 2)
				{
					string text2 = array[1];
					EnumConverter enumConverter2 = new EnumConverter(typeof(drillTypes));
					return (drillTypes)enumConverter2.ConvertFromString(text2.ToString());
				}
			}
			return drillTypes.SingleHole;
		}
		catch (Exception)
		{
			return drillTypes.SingleHole;
		}
	}

	public static CutTypes DecoderFromCutType(string Line)
	{
		try
		{
			string[] array = Line.Split(':');
			if (array != null)
			{
				if (array.Length == 1)
				{
					string text = array[0];
					EnumConverter enumConverter = new EnumConverter(typeof(CutTypes));
					return (CutTypes)enumConverter.ConvertFromString(text.ToString());
				}
				if (array.Length == 2)
				{
					string text2 = array[1];
					EnumConverter enumConverter2 = new EnumConverter(typeof(CutTypes));
					return (CutTypes)enumConverter2.ConvertFromString(text2.ToString());
				}
			}
			return CutTypes.CutFree;
		}
		catch (Exception)
		{
			return CutTypes.CutFree;
		}
	}

	public static ProfilingTypes DecoderFromProfilingType(string Line)
	{
		try
		{
			string[] array = Line.Split(':');
			if (array != null)
			{
				if (array.Length == 1)
				{
					string text = array[0];
					EnumConverter enumConverter = new EnumConverter(typeof(ProfilingTypes));
					return (ProfilingTypes)enumConverter.ConvertFromString(text.ToString());
				}
				if (array.Length == 2)
				{
					string text2 = array[1];
					EnumConverter enumConverter2 = new EnumConverter(typeof(ProfilingTypes));
					return (ProfilingTypes)enumConverter2.ConvertFromString(text2.ToString());
				}
			}
			return ProfilingTypes.ProfilingRectangle;
		}
		catch (Exception)
		{
			return ProfilingTypes.ProfilingRectangle;
		}
	}

	public static JunctionTypes DecoderFromJunctionType(string Line)
	{
		try
		{
			string[] array = Line.Split(':');
			if (array != null)
			{
				if (array.Length == 1)
				{
					string text = array[0];
					EnumConverter enumConverter = new EnumConverter(typeof(JunctionTypes));
					return (JunctionTypes)enumConverter.ConvertFromString(text.ToString());
				}
				if (array.Length == 2)
				{
					string text2 = array[1];
					EnumConverter enumConverter2 = new EnumConverter(typeof(JunctionTypes));
					return (JunctionTypes)enumConverter2.ConvertFromString(text2.ToString());
				}
			}
			return JunctionTypes.Junction2HoleNearByHorizontal;
		}
		catch (Exception)
		{
			return JunctionTypes.Junction2HoleNearByHorizontal;
		}
	}

	public static UpDownLocationType DecoderFromUpDownLocationType(string Line)
	{
		try
		{
			string[] array = Line.Split(':');
			if (array != null)
			{
				if (array.Length == 1)
				{
					string text = array[0];
					EnumConverter enumConverter = new EnumConverter(typeof(UpDownLocationType));
					return (UpDownLocationType)enumConverter.ConvertFromString(text.ToString());
				}
				if (array.Length == 2)
				{
					string text2 = array[1];
					EnumConverter enumConverter2 = new EnumConverter(typeof(UpDownLocationType));
					return (UpDownLocationType)enumConverter2.ConvertFromString(text2.ToString());
				}
			}
			return UpDownLocationType.Down;
		}
		catch (Exception)
		{
			return UpDownLocationType.Down;
		}
	}

	public static FrontBackType DecoderFromFrontBackType(string Line)
	{
		try
		{
			string[] array = Line.Split(':');
			if (array != null)
			{
				if (array.Length == 1)
				{
					string text = array[0];
					EnumConverter enumConverter = new EnumConverter(typeof(FrontBackType));
					return (FrontBackType)enumConverter.ConvertFromString(text.ToString());
				}
				if (array.Length == 2)
				{
					string text2 = array[1];
					EnumConverter enumConverter2 = new EnumConverter(typeof(FrontBackType));
					return (FrontBackType)enumConverter2.ConvertFromString(text2.ToString());
				}
			}
			return FrontBackType.Back;
		}
		catch (Exception)
		{
			return FrontBackType.Back;
		}
	}

	public static ProfileNotchLocationType DecoderFromProfileNotchLocationType(string Line)
	{
		try
		{
			string[] array = Line.Split(':');
			if (array != null)
			{
				if (array.Length == 1)
				{
					string text = array[0];
					EnumConverter enumConverter = new EnumConverter(typeof(ProfileNotchLocationType));
					return (ProfileNotchLocationType)enumConverter.ConvertFromString(text.ToString());
				}
				if (array.Length == 2)
				{
					string text2 = array[1];
					EnumConverter enumConverter2 = new EnumConverter(typeof(ProfileNotchLocationType));
					return (ProfileNotchLocationType)enumConverter2.ConvertFromString(text2.ToString());
				}
			}
			return ProfileNotchLocationType.Back;
		}
		catch (Exception)
		{
			return ProfileNotchLocationType.Back;
		}
	}

	public static ProfileNotchOperationType DecoderFromProfileNotchOperationType(string Line)
	{
		try
		{
			string[] array = Line.Split(':');
			if (array != null)
			{
				if (array.Length == 1)
				{
					string text = array[0];
					EnumConverter enumConverter = new EnumConverter(typeof(ProfileNotchOperationType));
					return (ProfileNotchOperationType)enumConverter.ConvertFromString(text.ToString());
				}
				if (array.Length == 2)
				{
					string text2 = array[1];
					EnumConverter enumConverter2 = new EnumConverter(typeof(ProfileNotchOperationType));
					return (ProfileNotchOperationType)enumConverter2.ConvertFromString(text2.ToString());
				}
			}
			return ProfileNotchOperationType.Side;
		}
		catch (Exception)
		{
			return ProfileNotchOperationType.Side;
		}
	}

	public static planeNames DecoderFromPlaneNames(string Line)
	{
		try
		{
			string[] array = Line.Split(':');
			if (array != null)
			{
				if (array.Length == 1)
				{
					string text = array[0];
					EnumConverter enumConverter = new EnumConverter(typeof(planeNames));
					return (planeNames)enumConverter.ConvertFromString(text.ToString());
				}
				if (array.Length == 2)
				{
					string text2 = array[1];
					EnumConverter enumConverter2 = new EnumConverter(typeof(planeNames));
					return (planeNames)enumConverter2.ConvertFromString(text2.ToString());
				}
			}
			return planeNames.Top;
		}
		catch (Exception)
		{
			return planeNames.Top;
		}
	}

	public static planeBoxNames DecoderFromPlaneBoxNames(string Line)
	{
		try
		{
			string[] array = Line.Split(':');
			if (array != null)
			{
				if (array.Length == 1)
				{
					string text = array[0];
					EnumConverter enumConverter = new EnumConverter(typeof(planeBoxNames));
					return (planeBoxNames)enumConverter.ConvertFromString(text.ToString());
				}
				if (array.Length == 2)
				{
					string text2 = array[1];
					EnumConverter enumConverter2 = new EnumConverter(typeof(planeBoxNames));
					return (planeBoxNames)enumConverter2.ConvertFromString(text2.ToString());
				}
			}
			return planeBoxNames.Top;
		}
		catch (Exception)
		{
			return planeBoxNames.Top;
		}
	}

	public static ShapeGroup DecoderFromShapeGroup(string Line)
	{
		try
		{
			string[] array = Line.Split(':');
			if (array != null)
			{
				if (array.Length == 1)
				{
					string text = array[0];
					EnumConverter enumConverter = new EnumConverter(typeof(ShapeGroup));
					return (ShapeGroup)enumConverter.ConvertFromString(text.ToString());
				}
				if (array.Length == 2)
				{
					string text2 = array[1];
					EnumConverter enumConverter2 = new EnumConverter(typeof(ShapeGroup));
					return (ShapeGroup)enumConverter2.ConvertFromString(text2.ToString());
				}
			}
			return ShapeGroup.Shape;
		}
		catch (Exception)
		{
			return ShapeGroup.Shape;
		}
	}

	public static CornerLocation DecoderFromCornerLocation(string Line)
	{
		try
		{
			string[] array = Line.Split(':');
			if (array != null)
			{
				if (array.Length == 1)
				{
					string text = array[0];
					EnumConverter enumConverter = new EnumConverter(typeof(CornerLocation));
					return (CornerLocation)enumConverter.ConvertFromString(text.ToString());
				}
				if (array.Length == 2)
				{
					string text2 = array[1];
					EnumConverter enumConverter2 = new EnumConverter(typeof(CornerLocation));
					return (CornerLocation)enumConverter2.ConvertFromString(text2.ToString());
				}
			}
			return CornerLocation.LeftBottom;
		}
		catch (Exception)
		{
			return CornerLocation.LeftBottom;
		}
	}

	public static ObjectAlignment DecoderFromObjectAlignment(string Line)
	{
		try
		{
			string[] array = Line.Split(':');
			if (array != null)
			{
				if (array.Length == 1)
				{
					string text = array[0];
					EnumConverter enumConverter = new EnumConverter(typeof(ObjectAlignment));
					return (ObjectAlignment)enumConverter.ConvertFromString(text.ToString());
				}
				if (array.Length == 2)
				{
					string text2 = array[1];
					EnumConverter enumConverter2 = new EnumConverter(typeof(ObjectAlignment));
					return (ObjectAlignment)enumConverter2.ConvertFromString(text2.ToString());
				}
			}
			return ObjectAlignment.MiddleCenter;
		}
		catch (Exception)
		{
			return ObjectAlignment.MiddleCenter;
		}
	}

	public static ShapeTypes DecoderFromShapeTypes(string Line)
	{
		try
		{
			string[] array = Line.Split(':');
			if (array != null)
			{
				if (array.Length == 1)
				{
					string text = array[0];
					EnumConverter enumConverter = new EnumConverter(typeof(ShapeTypes));
					return (ShapeTypes)enumConverter.ConvertFromString(text.ToString());
				}
				if (array.Length == 2)
				{
					string text2 = array[1];
					EnumConverter enumConverter2 = new EnumConverter(typeof(ShapeTypes));
					return (ShapeTypes)enumConverter2.ConvertFromString(text2.ToString());
				}
			}
			return ShapeTypes.None;
		}
		catch (Exception)
		{
			return ShapeTypes.None;
		}
	}

	public string ToDefLine(int Space)
	{
		try
		{
			string text = new string(' ', Space);
			List<cParameter5> Vars = new List<cParameter5>();
			GetClassVariables(this, ref Vars);
			string text2 = "";
			text2 = text;
			for (int i = 0; i <= Vars.Count - 1; i++)
			{
				string text3 = "";
				if (i < Vars.Count - 1)
				{
					text3 = " ; ";
				}
				text2 = text2 + Vars[i].Name + " = " + Vars[i].ValueAsString + text3;
			}
			return text2;
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			return "";
		}
	}

	public ArrayList ToDefNewLine(int Space)
	{
		try
		{
			string text = new string(' ', Space);
			List<cParameter5> Vars = new List<cParameter5>();
			GetClassVariables(this, ref Vars);
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i <= Vars.Count - 1; i++)
			{
				if (i != 28)
				{
				}
				if (Vars[i] == null)
				{
					continue;
				}
				string text2 = Vars[i].Value.GetType().ToString();
				bool flag = false;
				Type type = Vars[i].Value.GetType();
				if (!((Vars[i].Value.GetType() != typeof(ArrayList)) & (text2.IndexOf("Generic.List") < 0) & !type.IsArray))
				{
					if (!type.IsArray)
					{
						if (!(Vars[i].Value.GetType() == typeof(ArrayList)))
						{
							if (text2.IndexOf("Generic.List") < 0)
							{
								continue;
							}
							string[] array = text2.Split(new string[1] { "Generic.List" }, StringSplitOptions.None);
							bool flag2 = true;
							for (int j = 0; j <= ExceptionalVariables.Count - 1; j++)
							{
								if (ExceptionalVariables[j].Trim().ToLower() == Vars[i].Name.Trim().ToLower())
								{
									flag2 = false;
									j = ExceptionalVariables.Count;
								}
							}
							if (flag2)
							{
								if (array.Length == 2)
								{
									arrayList.AddRange(method_0(Vars[i].Name.ToString(), Vars[i].Value, Space).ToArray());
								}
								if (array.Length == 3)
								{
									string string_ = Vars[i].Name.ToString();
									object value = Vars[i].Value;
									arrayList.AddRange(Class186.smethod_753(value, Space, this, string_).ToArray());
								}
							}
						}
						else
						{
							string string_2 = Vars[i].Name.ToString();
							ArrayList arrayList_ = (ArrayList)Vars[i].Value;
							arrayList.AddRange(Class186.smethod_528(arrayList_, string_2, this, Space).ToArray());
						}
					}
					else
					{
						arrayList.AddRange(method_1(Vars[i].Name.ToString(), Vars[i].Value, Space).ToArray());
					}
					continue;
				}
				bool flag3 = true;
				for (int k = 0; k <= ExceptionalVariables.Count - 1; k++)
				{
					if (ExceptionalVariables[k].Trim().ToLower() == Vars[i].Name.Trim().ToLower())
					{
						flag3 = false;
						k = ExceptionalVariables.Count;
					}
				}
				if (flag3)
				{
					if (type.BaseType != null && (((type.Namespace == "buClass") | (type.BaseType.Namespace == "buClass") | (type.Namespace == "buEyeBaseVer5") | (type.BaseType.Namespace == "buEyeBaseVer5") | (type.Namespace == "buMW") | (type.BaseType.Namespace == "buMW") | (type.BaseType.Name == "buSerilization5")) & !type.IsEnum) && Vars[i].Value.GetType().BaseType != typeof(eEntities))
					{
						string text3 = new string(' ', Space);
						arrayList.Add(text3 + "<" + Vars[i].Name + ">");
						arrayList.AddRange(Class186.smethod_622(Vars[i].Value, this, Space + 2).ToArray());
						arrayList.Add(text3 + "</" + Vars[i].Name + ">");
						flag = true;
					}
					if (Vars[i].Value.GetType().BaseType == typeof(eEntities))
					{
						flag = true;
					}
					if (Vars[i].Value.GetType().BaseType == typeof(buEntity))
					{
						flag = true;
					}
					if (!flag)
					{
						string text4 = GetType().Name + ".";
						arrayList.Add(text + text4 + Vars[i].Name + " = " + Vars[i].ValueAsString.ToString());
					}
				}
			}
			return arrayList;
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			return new ArrayList();
		}
	}

	public ArrayList ToDefAll(string Char, int Space)
	{
		return ToDefAll(Char, Space, SerilizationMode5.MultiLine);
	}

	public ArrayList ToDefAll(string Char, int Space, SerilizationMode5 DefMode)
	{
		ArrayList arrayList = new ArrayList();
		string text = new string(' ', Space);
		new string(' ', Space + 2);
		if (DefMode == SerilizationMode5.SingleLine)
		{
			arrayList.Add(text + "<" + GetType().Name + Char + ">");
			arrayList.Add(ToDefLine(Space + 2));
			arrayList.Add(text + "</" + GetType().Name + Char + ">");
		}
		if (DefMode == SerilizationMode5.MultiLine)
		{
			arrayList.Add(text + "<" + GetType().Name + Char + ">");
			arrayList.AddRange(ToDefNewLine(Space + 2));
			arrayList.Add(text + "</" + GetType().Name + Char + ">");
		}
		if (DefMode == SerilizationMode5.SingleLineWithParenthesis)
		{
			arrayList.Add(text + GetType().Name + Char + "(" + ToDefLine(0) + ")");
		}
		return arrayList;
	}

	public ArrayList ToDefAll(string Char, int Space, SerilizationMode5 DefMode, string DefClassName)
	{
		ArrayList arrayList = new ArrayList();
		string text = new string(' ', Space);
		new string(' ', Space + 2);
		if (DefMode == SerilizationMode5.SingleLine)
		{
			arrayList.Add(text + "<" + DefClassName + Char + ">");
			arrayList.Add(ToDefLine(Space + 2));
			arrayList.Add(text + "</" + DefClassName + Char + ">");
		}
		if (DefMode == SerilizationMode5.MultiLine)
		{
			arrayList.Add(text + "<" + DefClassName + Char + ">");
			arrayList.AddRange(ToDefNewLine(Space + 2));
			arrayList.Add(text + "</" + DefClassName + Char + ">");
		}
		if (DefMode == SerilizationMode5.SingleLineWithParenthesis)
		{
			arrayList.Add(text + DefClassName + Char + "(" + ToDefLine(0) + ")");
		}
		return arrayList;
	}

	public static object Decode(ArrayList AL, string Char, SerilizationMode5 Mode, object Obj)
	{
		object result = null;
		List<string> CalcList = new List<string>();
		new List<string>();
		buStatics.ListToSpecificList("<" + Obj.GetType().Name + Char + ">", "</" + Obj.GetType().Name + Char + ">", AL, ref CalcList);
		if (CalcList.Count > 0)
		{
			List<cParameter5> Vars = new List<cParameter5>();
			GetClassVariableValuesFromStringCodes(CalcList, Obj, ref Vars);
			if (Vars.Count > 0)
			{
				SetClassVariables(ref Obj, Vars);
			}
		}
		return result;
	}

	public static object Decode(List<string> SL, string Char, SerilizationMode5 Mode, object Obj)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.AddRange(SL.ToArray());
		return Decode(arrayList, Char, Mode, Obj);
	}

	public static void ClassToString(object ObjPar, ref string Line)
	{
		List<cParameter5> Vars = new List<cParameter5>();
		GetClassVariables(ObjPar, UseSubClass: false, UseArrayList: false, UseList: false, UseArray: false, ref Vars);
		if (Vars.Count <= 0)
		{
			return;
		}
		for (int i = 0; i <= Vars.Count - 1; i++)
		{
			if (Vars[i] == null || Vars[i].Value == null)
			{
				continue;
			}
			string text = Vars[i].Value.ToString();
			if (!(Vars[i].Field.FieldType == typeof(Point3D)))
			{
				if (!(Vars[i].Field.FieldType == typeof(Vector3D)))
				{
					if (!(Vars[i].Field.FieldType == typeof(OrientationAngle)))
					{
						if (!(Vars[i].Field.FieldType == typeof(Pnt3D)))
						{
							if (!(Vars[i].Field.FieldType == typeof(Pnt6D)))
							{
								if (!(Vars[i].Field.FieldType == typeof(Vec3D)))
								{
									if (Vars[i].Field.FieldType == typeof(Plane))
									{
										text = ToDef((Plane)Vars[i].Value);
									}
								}
								else
								{
									text = ((Vec3D)Vars[i].Value).ToDefNumber();
								}
							}
							else
							{
								text = ((Pnt6D)Vars[i].Value).ToDefNumber();
							}
						}
						else
						{
							text = ((Pnt3D)Vars[i].Value).ToDefNumber();
						}
					}
					else
					{
						text = ToDef((OrientationAngle)Vars[i].Value);
					}
				}
				else
				{
					text = ToDef((Vector3D)Vars[i].Value);
				}
			}
			else
			{
				text = ToDef((Point3D)Vars[i].Value);
			}
			if (Line.Length != 0)
			{
				Line = Line + " | " + Vars[i].Name + ": " + text;
			}
			else
			{
				Line = Vars[i].Name + ": " + text;
			}
		}
	}

	public static string ClassToString(object ObjPar)
	{
		string Line = "";
		ClassToString(ObjPar, ref Line);
		return Line;
	}

	public static void StringToClass(ref object ObjPar, string Line)
	{
		if (Line.Trim().Length <= 0)
		{
			return;
		}
		string[] array = Line.Split('|');
		if (array == null || array.Length == 0)
		{
			return;
		}
		string[] array2 = array[0].Split('=');
		if (array2 != null && array2.Length >= 2)
		{
			array[0] = array2[1];
		}
		List<cParameter5> Vars = new List<cParameter5>();
		GetClassVariables(ObjPar, UseSubClass: false, UseArrayList: false, UseList: false, UseArray: false, ref Vars);
		for (int i = 0; i <= Vars.Count - 1; i++)
		{
			if (Vars[i] != null)
			{
				string valueFromStringArrayByName = GetValueFromStringArrayByName(array, Vars[i].Name);
				FieldInfo FI = Vars[i].Field;
				if (valueFromStringArrayByName.Length > 0)
				{
					SetObjectValueByType(ref FI, ref ObjPar, valueFromStringArrayByName);
					Vars[i].ValueAsString = valueFromStringArrayByName;
				}
			}
		}
	}

	public static string GetValueFromLineByName(string Line, string ParName)
	{
		string[] strArr = Line.Split('|');
		return GetValueFromStringArrayByName(strArr, ParName);
	}

	public static string GetValueFromStringArrayByName(string[] strArr, string ParName)
	{
		string result = "";
		if (strArr != null && strArr.Length != 0)
		{
			for (int i = 0; i <= strArr.Length - 1; i++)
			{
				string[] array = strArr[i].Split(':');
				if (array != null && array.Length == 2)
				{
					string text = array[0].Trim();
					string result2 = array[1].Trim();
					if (text.Trim().ToLower() == ParName.Trim().ToLower())
					{
						return result2;
					}
				}
			}
		}
		return result;
	}

	public static void GetClassVariables(object ObjPar, ref List<cParameter5> Vars)
	{
		GetClassVariables(ObjPar, UseSubClass: true, UseArrayList: true, UseList: true, UseArray: true, ref Vars);
	}

	public static void GetClassVariables(object ObjPar, bool UseSubClass, bool UseArrayList, bool UseList, bool UseArray, ref List<cParameter5> Vars)
	{
		try
		{
			Vars.Clear();
			FieldInfo[] array = null;
			if (ObjPar == null)
			{
				return;
			}
			array = ObjPar.GetType().GetFields();
			if (array == null)
			{
				return;
			}
			for (int i = 0; i <= array.Length - 1; i++)
			{
				if (i != 8)
				{
				}
				cParameter5 cParameter6 = null;
				object obj = null;
				FieldInfo fieldInfo = array[i];
				_ = fieldInfo.Name;
				_ = fieldInfo.Name;
				if (ObjPar != null)
				{
				}
				obj = fieldInfo.GetValue(ObjPar);
				if (obj == null)
				{
					NullToValue(ref obj, fieldInfo);
				}
				if (obj != null)
				{
					Type type = obj.GetType();
					if (!((fieldInfo.FieldType.ToString().IndexOf("Generic.List") < 0) & (fieldInfo.FieldType.ToString().IndexOf("ArrayList") < 0) & !type.IsArray))
					{
						if (type.IsArray && UseArray)
						{
							cParameter6 = new cParameter5();
							cParameter6.Name = fieldInfo.Name;
							cParameter6.Value = obj;
							cParameter6.ValueAsString = obj.ToString();
							cParameter6.Field = fieldInfo;
							cParameter6.Types = obj.GetType();
						}
						if (!(((fieldInfo.FieldType.ToString().IndexOf("ArrayList") >= 0) & !type.IsArray) && UseArrayList))
						{
							if (((fieldInfo.FieldType.ToString().IndexOf("Generic.List") >= 0) & !type.IsArray) && UseList && !fieldInfo.IsStatic)
							{
								cParameter6 = new cParameter5();
								cParameter6.Name = fieldInfo.Name;
								cParameter6.Value = obj;
								cParameter6.ValueAsString = obj.ToString();
								cParameter6.Field = fieldInfo;
								cParameter6.Types = obj.GetType();
							}
						}
						else
						{
							cParameter6 = new cParameter5();
							cParameter6.Name = fieldInfo.Name;
							cParameter6.Value = obj;
							cParameter6.ValueAsString = obj.ToString();
							cParameter6.Field = fieldInfo;
							cParameter6.Types = obj.GetType();
						}
					}
					else if (!(obj.GetType() == typeof(double)))
					{
						if (!(obj.GetType() == typeof(int)))
						{
							if (!(obj.GetType() == typeof(float)))
							{
								if (!(obj.GetType() == typeof(long)))
								{
									if (!(obj.GetType() == typeof(uint)))
									{
										if (!(obj.GetType() == typeof(bool)))
										{
											if (!(obj.GetType() == typeof(byte)))
											{
												if (!(obj.GetType() == typeof(string)))
												{
													if (!(obj.GetType() == typeof(Color)))
													{
														if (!(obj.GetType() == typeof(Font)))
														{
															if (!(obj.GetType() == typeof(DateTime)))
															{
																if (!(obj.GetType() == typeof(Size)))
																{
																	if (!(obj.GetType() == typeof(SizeF)))
																	{
																		if (!(obj.GetType() == typeof(Point)))
																		{
																			if (!(obj.GetType() == typeof(PointF)))
																			{
																				if (!(obj.GetType() == typeof(Pnt2D)))
																				{
																					if (!(obj.GetType() == typeof(Pnt3D)))
																					{
																						if (!(obj.GetType() == typeof(Point3D)))
																						{
																							if (!(obj.GetType() == typeof(Vector3D)))
																							{
																								if (!(obj.GetType() == typeof(Pnt6D)))
																								{
																									if (!(obj.GetType() == typeof(Pnt9D)))
																									{
																										if (!(obj.GetType() == typeof(Vec3D)))
																										{
																											if (!(obj.GetType() == typeof(Length3D)))
																											{
																												if (!(obj.GetType() == typeof(OrientationAngle)))
																												{
																													if (!(obj.GetType() == typeof(Line3D)))
																													{
																														if (!(obj.GetType() == typeof(Triangle3D)))
																														{
																															if (!(obj.GetType() == typeof(Quad3D)))
																															{
																																if (!(obj.GetType() == typeof(Plane)))
																																{
																																	if (!(obj.GetType() == typeof(object)))
																																	{
																																		if (type.IsEnum)
																																		{
																																			cParameter6 = new cParameter5();
																																			cParameter6.Name = fieldInfo.Name;
																																			cParameter6.Value = obj;
																																			cParameter6.ValueAsString = obj.ToString();
																																			cParameter6.Field = fieldInfo;
																																			cParameter6.Types = obj.GetType();
																																		}
																																		if (fieldInfo.FieldType.BaseType != null && (type.IsClass & ((fieldInfo.FieldType.BaseType.Namespace.IndexOf("buClass") >= 0) | (fieldInfo.FieldType.BaseType.Namespace.IndexOf("buMW") >= 0) | (fieldInfo.FieldType.BaseType.Namespace.IndexOf("buEyeBaseVer5") >= 0) | (fieldInfo.FieldType.Namespace.IndexOf("buClass") >= 0) | (fieldInfo.FieldType.Namespace.IndexOf("buEyeBaseVer5") >= 0))) && UseSubClass)
																																		{
																																			cParameter6 = new cParameter5();
																																			List<cParameter5> Vars2 = new List<cParameter5>();
																																			GetClassVariables(obj, ref Vars2);
																																			cParameter6.Name = fieldInfo.Name;
																																			cParameter6.Value = obj;
																																			cParameter6.ValueAsString = obj.ToString();
																																			cParameter6.Field = fieldInfo;
																																			cParameter6.Types = obj.GetType();
																																			cParameter6.SubParameter = Vars2;
																																		}
																																	}
																																	else
																																	{
																																		cParameter6 = new cParameter5();
																																		cParameter6.Name = fieldInfo.Name;
																																		cParameter6.Value = obj;
																																		cParameter6.ValueAsString = "";
																																		cParameter6.Field = fieldInfo;
																																		cParameter6.Types = obj.GetType();
																																	}
																																}
																																else
																																{
																																	cParameter6 = new cParameter5();
																																	cParameter6.Name = fieldInfo.Name;
																																	cParameter6.Value = obj;
																																	cParameter6.ValueAsString = ToDef((Plane)obj);
																																	cParameter6.Field = fieldInfo;
																																	cParameter6.Types = obj.GetType();
																																}
																															}
																															else
																															{
																																cParameter6 = new cParameter5();
																																cParameter6.Name = fieldInfo.Name;
																																cParameter6.Value = obj;
																																cParameter6.ValueAsString = ((Quad3D)obj).ToDef();
																																cParameter6.Field = fieldInfo;
																																cParameter6.Types = obj.GetType();
																															}
																														}
																														else
																														{
																															cParameter6 = new cParameter5();
																															cParameter6.Name = fieldInfo.Name;
																															cParameter6.Value = obj;
																															cParameter6.ValueAsString = ((Triangle3D)obj).ToDef();
																															cParameter6.Field = fieldInfo;
																															cParameter6.Types = obj.GetType();
																														}
																													}
																													else
																													{
																														cParameter6 = new cParameter5();
																														cParameter6.Name = fieldInfo.Name;
																														cParameter6.Value = obj;
																														cParameter6.ValueAsString = ((Line3D)obj).ToDef();
																														cParameter6.Field = fieldInfo;
																														cParameter6.Types = obj.GetType();
																													}
																												}
																												else
																												{
																													cParameter6 = new cParameter5();
																													cParameter6.Name = fieldInfo.Name;
																													cParameter6.Value = obj;
																													cParameter6.ValueAsString = ((OrientationAngle)obj).ToDef();
																													cParameter6.Field = fieldInfo;
																													cParameter6.Types = obj.GetType();
																												}
																											}
																											else
																											{
																												cParameter6 = new cParameter5();
																												cParameter6.Name = fieldInfo.Name;
																												cParameter6.Value = obj;
																												cParameter6.ValueAsString = ((Length3D)obj).ToDef();
																												cParameter6.Field = fieldInfo;
																												cParameter6.Types = obj.GetType();
																											}
																										}
																										else
																										{
																											cParameter6 = new cParameter5();
																											cParameter6.Name = fieldInfo.Name;
																											cParameter6.Value = obj;
																											cParameter6.ValueAsString = ((Vec3D)obj).ToDef();
																											cParameter6.Field = fieldInfo;
																											cParameter6.Types = obj.GetType();
																										}
																									}
																									else
																									{
																										cParameter6 = new cParameter5();
																										cParameter6.Name = fieldInfo.Name;
																										cParameter6.Value = obj;
																										cParameter6.ValueAsString = ((Pnt9D)obj).ToDef();
																										cParameter6.Field = fieldInfo;
																										cParameter6.Types = obj.GetType();
																									}
																								}
																								else
																								{
																									cParameter6 = new cParameter5();
																									cParameter6.Name = fieldInfo.Name;
																									cParameter6.Value = obj;
																									cParameter6.ValueAsString = ((Pnt6D)obj).ToDef();
																									cParameter6.Field = fieldInfo;
																									cParameter6.Types = obj.GetType();
																								}
																							}
																							else
																							{
																								cParameter6 = new cParameter5();
																								cParameter6.Name = fieldInfo.Name;
																								cParameter6.Value = obj;
																								cParameter6.ValueAsString = buVector5.Vector3DToDef((Vector3D)obj);
																								cParameter6.Field = fieldInfo;
																								cParameter6.Types = obj.GetType();
																							}
																						}
																						else
																						{
																							cParameter6 = new cParameter5();
																							cParameter6.Name = fieldInfo.Name;
																							cParameter6.Value = obj;
																							cParameter6.ValueAsString = buVector5.Point3DToDef((Point3D)obj);
																							cParameter6.Field = fieldInfo;
																							cParameter6.Types = obj.GetType();
																						}
																					}
																					else
																					{
																						cParameter6 = new cParameter5();
																						cParameter6.Name = fieldInfo.Name;
																						cParameter6.Value = obj;
																						cParameter6.ValueAsString = ((Pnt3D)obj).ToDef();
																						cParameter6.Field = fieldInfo;
																						cParameter6.Types = obj.GetType();
																					}
																				}
																				else
																				{
																					cParameter6 = new cParameter5();
																					cParameter6.Name = fieldInfo.Name;
																					cParameter6.Value = obj;
																					cParameter6.ValueAsString = ((Pnt2D)obj).ToDef();
																					cParameter6.Field = fieldInfo;
																					cParameter6.Types = obj.GetType();
																				}
																			}
																			else
																			{
																				cParameter6 = new cParameter5();
																				cParameter6.Name = fieldInfo.Name;
																				cParameter6.Value = obj;
																				cParameter6.ValueAsString = ((PointF)obj).X + ";" + ((PointF)obj).Y;
																				cParameter6.Field = fieldInfo;
																				cParameter6.Types = obj.GetType();
																			}
																		}
																		else
																		{
																			cParameter6 = new cParameter5();
																			cParameter6.Name = fieldInfo.Name;
																			cParameter6.Value = obj;
																			cParameter6.ValueAsString = ((Point)obj).X + ";" + ((Point)obj).Y;
																			cParameter6.Field = fieldInfo;
																			cParameter6.Types = obj.GetType();
																		}
																	}
																	else
																	{
																		cParameter6 = new cParameter5();
																		cParameter6.Name = fieldInfo.Name;
																		cParameter6.Value = obj;
																		cParameter6.ValueAsString = ((SizeF)obj).Width + ";" + ((SizeF)obj).Height;
																		cParameter6.Field = fieldInfo;
																		cParameter6.Types = obj.GetType();
																	}
																}
																else
																{
																	cParameter6 = new cParameter5();
																	cParameter6.Name = fieldInfo.Name;
																	cParameter6.Value = obj;
																	cParameter6.ValueAsString = ((Size)obj).Width + ";" + ((Size)obj).Height;
																	cParameter6.Field = fieldInfo;
																	cParameter6.Types = obj.GetType();
																}
															}
															else
															{
																cParameter6 = new cParameter5();
																cParameter6.Name = fieldInfo.Name;
																cParameter6.Value = obj;
																cParameter6.ValueAsString = ((DateTime)obj).ToString();
																cParameter6.Field = fieldInfo;
																cParameter6.Types = obj.GetType();
															}
														}
														else
														{
															cParameter6 = new cParameter5();
															cParameter6.Name = fieldInfo.Name;
															cParameter6.Value = obj;
															cParameter6.ValueAsString = buStatics.FontToString((Font)obj);
															cParameter6.Field = fieldInfo;
															cParameter6.Types = obj.GetType();
														}
													}
													else
													{
														cParameter6 = new cParameter5();
														cParameter6.Name = fieldInfo.Name;
														cParameter6.Value = obj;
														cParameter6.ValueAsString = buStatics.ColorToString((Color)obj, ColorConvertType.String);
														cParameter6.Field = fieldInfo;
														cParameter6.Types = obj.GetType();
													}
												}
												else
												{
													cParameter6 = new cParameter5();
													cParameter6.Name = fieldInfo.Name;
													cParameter6.Value = obj;
													cParameter6.ValueAsString = obj.ToString();
													cParameter6.Field = fieldInfo;
													cParameter6.Types = obj.GetType();
												}
											}
											else
											{
												cParameter6 = new cParameter5();
												cParameter6.Name = fieldInfo.Name;
												cParameter6.Value = obj;
												cParameter6.ValueAsString = obj.ToString();
												cParameter6.Field = fieldInfo;
												cParameter6.Types = obj.GetType();
											}
										}
										else
										{
											cParameter6 = new cParameter5();
											cParameter6.Name = fieldInfo.Name;
											cParameter6.Value = obj;
											cParameter6.ValueAsString = obj.ToString();
											cParameter6.Field = fieldInfo;
											cParameter6.Types = obj.GetType();
										}
									}
									else
									{
										cParameter6 = new cParameter5();
										cParameter6.Name = fieldInfo.Name;
										cParameter6.Value = obj;
										cParameter6.ValueAsString = obj.ToString();
										cParameter6.Field = fieldInfo;
										cParameter6.Types = obj.GetType();
									}
								}
								else
								{
									cParameter6 = new cParameter5();
									cParameter6.Name = fieldInfo.Name;
									cParameter6.Value = obj;
									cParameter6.ValueAsString = obj.ToString();
									cParameter6.Field = fieldInfo;
									cParameter6.Types = obj.GetType();
								}
							}
							else
							{
								cParameter6 = new cParameter5();
								cParameter6.Name = fieldInfo.Name;
								cParameter6.Value = obj;
								cParameter6.ValueAsString = obj.ToString();
								cParameter6.Field = fieldInfo;
								cParameter6.Types = obj.GetType();
							}
						}
						else
						{
							cParameter6 = new cParameter5();
							cParameter6.Name = fieldInfo.Name;
							cParameter6.Value = obj;
							cParameter6.ValueAsString = obj.ToString();
							cParameter6.Field = fieldInfo;
							cParameter6.Types = obj.GetType();
						}
					}
					else
					{
						cParameter6 = new cParameter5();
						cParameter6.Name = fieldInfo.Name;
						cParameter6.Value = obj;
						cParameter6.ValueAsString = obj.ToString();
						cParameter6.Field = fieldInfo;
						cParameter6.Types = obj.GetType();
					}
				}
				if (cParameter6 == null)
				{
					Vars.Add(cParameter6);
				}
				else
				{
					Vars.Add(cParameter6);
				}
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public static void GetCaptionsOfClass(object ObjPar, ref List<string> Captions)
	{
		FieldInfo[] fields = ObjPar.GetType().GetFields();
		if (fields == null)
		{
			return;
		}
		for (int i = 0; i <= fields.Length - 1; i++)
		{
			if (fields[i].IsStatic && ((fields[i].Name == "Caption") | (fields[i].Name == "Captions")))
			{
				Captions.AddRange(((List<string>)fields[i].GetValue(ObjPar)).ToArray());
			}
		}
	}

	public static void NullToValue(ref object Obj, FieldInfo field)
	{
		if (field.FieldType == typeof(double))
		{
			double num = 0.0;
			Obj = num;
		}
		if (field.FieldType == typeof(int))
		{
			Obj = 0;
		}
		if (field.FieldType == typeof(float))
		{
			float num2 = 0f;
			Obj = num2;
		}
		if (field.FieldType == typeof(long))
		{
			Obj = 0L;
		}
		if (field.FieldType == typeof(uint))
		{
			Obj = 0u;
		}
		if (field.FieldType == typeof(bool))
		{
			Obj = false;
		}
		if (field.FieldType == typeof(byte))
		{
			Obj = (byte)0;
		}
		if (field.FieldType == typeof(string))
		{
			string text = "";
			Obj = text;
		}
		if (field.FieldType == typeof(Color))
		{
			Color white = Color.White;
			Obj = white;
		}
		if (field.FieldType == typeof(Font))
		{
			Font font = new Font("Arial", 10f);
			Obj = font;
		}
		if (field.FieldType == typeof(DateTime))
		{
			Obj = default(DateTime);
		}
		if (field.FieldType == typeof(Size))
		{
			Obj = default(Size);
		}
		if (field.FieldType == typeof(SizeF))
		{
			Obj = default(SizeF);
		}
		if (field.FieldType == typeof(Point))
		{
			Obj = default(Point);
		}
		if (field.FieldType == typeof(PointF))
		{
			Obj = default(PointF);
		}
		if (field.FieldType == typeof(Pnt2D))
		{
			Pnt2D pnt2D = new Pnt2D();
			Obj = pnt2D;
		}
		if (field.FieldType == typeof(Pnt3D))
		{
			Pnt3D pnt3D = new Pnt3D();
			Obj = pnt3D;
		}
		if (field.FieldType == typeof(Point3D))
		{
			Point3D point3D = new Point3D();
			Obj = point3D;
		}
		if (field.FieldType == typeof(Vector3D))
		{
			Vector3D vector3D = new Vector3D();
			Obj = vector3D;
		}
		if (field.FieldType == typeof(Pnt6D))
		{
			Pnt6D pnt6D = new Pnt6D();
			Obj = pnt6D;
		}
		if (field.FieldType == typeof(Pnt9D))
		{
			Pnt9D pnt9D = new Pnt9D();
			Obj = pnt9D;
		}
		if (field.FieldType == typeof(Vec3D))
		{
			Vec3D vec3D = new Vec3D();
			Obj = vec3D;
		}
		if (field.FieldType == typeof(Length3D))
		{
			Length3D length3D = new Length3D();
			Obj = length3D;
		}
		if (field.FieldType == typeof(OrientationAngle))
		{
			OrientationAngle orientationAngle = new OrientationAngle();
			Obj = orientationAngle;
		}
		if (field.FieldType == typeof(Line3D))
		{
			Line3D line3D = new Line3D();
			Obj = line3D;
		}
		if (field.FieldType == typeof(Triangle3D))
		{
			Triangle3D triangle3D = new Triangle3D();
			Obj = triangle3D;
		}
		if (field.FieldType == typeof(Quad3D))
		{
			Quad3D quad3D = new Quad3D();
			Obj = quad3D;
		}
	}

	public static void SetClassVariable(ref object ObjPar, cParameter5 Var)
	{
		try
		{
			FieldInfo[] array = null;
			if (ObjPar == null)
			{
				return;
			}
			array = ObjPar.GetType().GetFields();
			if (array == null)
			{
				return;
			}
			for (int i = 0; i <= array.Length - 1; i++)
			{
				object object_ = null;
				FieldInfo FI = array[i];
				_ = FI.Name;
				_ = FI.Name;
				Type fieldType = FI.FieldType;
				if (!((FI.FieldType.ToString().IndexOf("List") < 0) & !fieldType.IsArray))
				{
					if (!((FI.FieldType.ToString().IndexOf("ArrayList") >= 0) & !fieldType.IsArray))
					{
						if (!((FI.FieldType.ToString().IndexOf("Generic.List") >= 0) & !fieldType.IsArray))
						{
							if (fieldType.IsArray && FI.Name == Var.Name)
							{
								Class186.smethod_766(Var.Value, ref object_);
								object_ = Var.Value;
								if (object_ != null)
								{
									SetObjectValueByType(ref FI, ref ObjPar, object_);
								}
							}
						}
						else if (FI.Name == Var.Name)
						{
							Class186.smethod_547(Var.Value, ref object_);
							object_ = Var.Value;
							if (object_ != null)
							{
								SetObjectValueByType(ref FI, ref ObjPar, object_);
							}
						}
					}
					else if (FI.Name == Var.Name)
					{
						Class186.smethod_258(ref object_, Var.Value);
						object_ = Var.Value;
						if (object_ != null)
						{
							SetObjectValueByType(ref FI, ref ObjPar, object_);
						}
					}
				}
				else if (FI.Name == Var.Name)
				{
					object_ = Var.Value;
					if ((((fieldType.Namespace == "buClass") | (fieldType.BaseType.Namespace == "buClass") | (fieldType.Namespace == "buEyeBaseVer5") | (fieldType.BaseType.Namespace == "buEyeBaseVer5") | (fieldType.Namespace == "buMW") | (fieldType.BaseType.Namespace == "buSerilization5")) & !fieldType.IsEnum & fieldType.IsClass) && (List<cParameter5>)Var.SubParameter != null)
					{
						SetClassVariables(ref object_, (List<cParameter5>)Var.SubParameter);
						FI.SetValue(ObjPar, object_);
					}
					if (object_ != null)
					{
						SetObjectValueByType(ref FI, ref ObjPar, object_);
					}
				}
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public static void SetClassVariables(ref object ObjPar, List<cParameter5> Vars)
	{
		try
		{
			FieldInfo[] array = null;
			if (ObjPar == null)
			{
				return;
			}
			array = ObjPar.GetType().GetFields();
			if (array == null)
			{
				return;
			}
			for (int i = 0; i <= array.Length - 1; i++)
			{
				if (i != 14)
				{
				}
				object ObjPar2 = null;
				FieldInfo FI = array[i];
				_ = FI.Name;
				_ = FI.Name;
				Type fieldType = FI.FieldType;
				if (!((FI.FieldType.ToString().IndexOf("List") < 0) & !fieldType.IsArray))
				{
					if (!((FI.FieldType.ToString().IndexOf("ArrayList") >= 0) & !fieldType.IsArray))
					{
						if (!((FI.FieldType.ToString().IndexOf("Generic.List") >= 0) & !fieldType.IsArray))
						{
							if (!fieldType.IsArray)
							{
								continue;
							}
							for (int j = 0; j <= Vars.Count - 1; j++)
							{
								if (FI.Name == Vars[j].Name)
								{
									Class186.smethod_766(Vars[j].Value, ref ObjPar2);
									ObjPar2 = Vars[j].Value;
									j = Vars.Count + 1;
								}
							}
							if (ObjPar2 != null)
							{
								SetObjectValueByType(ref FI, ref ObjPar, ObjPar2);
							}
							continue;
						}
						string[] array2 = FI.FieldType.ToString().Split(new string[1] { "Generic.List" }, StringSplitOptions.None);
						new ArrayList();
						new List<cParameter5>();
						if (!((array2.Length == 2) | (array2.Length == 3)))
						{
							continue;
						}
						for (int k = 0; k <= Vars.Count - 1; k++)
						{
							if (Vars[k] != null && FI.Name == Vars[k].Name)
							{
								Class186.smethod_547(Vars[k].Value, ref ObjPar2);
								ObjPar2 = Vars[k].Value;
								k = Vars.Count + 1;
							}
						}
						if (ObjPar2 != null)
						{
							SetObjectValueByType(ref FI, ref ObjPar, ObjPar2);
						}
						continue;
					}
					for (int l = 0; l <= Vars.Count - 1; l++)
					{
						if (Vars[l] != null && FI.Name == Vars[l].Name)
						{
							Class186.smethod_258(ref ObjPar2, Vars[l].Value);
							ObjPar2 = Vars[l].Value;
							l = Vars.Count + 1;
						}
					}
					if (ObjPar2 != null)
					{
						SetObjectValueByType(ref FI, ref ObjPar, ObjPar2);
					}
					continue;
				}
				for (int m = 0; m <= Vars.Count - 1; m++)
				{
					if (Vars[m] != null && FI.Name == Vars[m].Name.ToString())
					{
						ObjPar2 = Vars[m].Value;
						m = Vars.Count + 1;
					}
				}
				if (!(fieldType.BaseType != null))
				{
					if ((((fieldType.Namespace == "buClass") | (fieldType.Namespace == "buEyeBaseVer5") | (fieldType.Namespace == "buMW")) & !fieldType.IsEnum & fieldType.IsClass) && i <= Vars.Count - 1 && Vars[i] != null && (List<cParameter5>)Vars[i].SubParameter != null)
					{
						SetClassVariables(ref ObjPar2, (List<cParameter5>)Vars[i].SubParameter);
						FI.SetValue(ObjPar, ObjPar2);
					}
				}
				else if ((((fieldType.Namespace == "buClass") | (fieldType.BaseType.Namespace == "buClass") | (fieldType.Namespace == "buEyeBaseVer5") | (fieldType.BaseType.Namespace == "buEyeBaseVer5") | (fieldType.Namespace == "buMW") | (fieldType.BaseType.Namespace == "buSerilization5")) & !fieldType.IsEnum & fieldType.IsClass) && i <= Vars.Count - 1 && Vars[i] != null && (List<cParameter5>)Vars[i].SubParameter != null)
				{
					SetClassVariables(ref ObjPar2, (List<cParameter5>)Vars[i].SubParameter);
					FI.SetValue(ObjPar, ObjPar2);
				}
				if (ObjPar2 != null)
				{
					SetObjectValueByType(ref FI, ref ObjPar, ObjPar2);
				}
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public static void CopyClass(object RefClass, ref object CopiedClass)
	{
		if (RefClass != null)
		{
			List<cParameter5> Vars = new List<cParameter5>();
			GetClassVariables(RefClass, ref Vars);
			CopiedClass = new object();
			CopiedClass = Activator.CreateInstance(RefClass.GetType());
			SetClassVariables(ref CopiedClass, Vars);
		}
	}

	public static void SetObjectValueByType(ref FieldInfo FI, ref object Obj, object Value)
	{
		try
		{
			if (!(FI != null))
			{
				return;
			}
			if (FI.FieldType == typeof(double))
			{
				double result = 0.0;
				if (double.TryParse(Value.ToString(), out result))
				{
					FI.SetValue(Obj, result);
				}
			}
			if (FI.FieldType == typeof(float))
			{
				float result2 = 0f;
				if (float.TryParse(Value.ToString(), out result2))
				{
					FI.SetValue(Obj, result2);
				}
			}
			if (FI.FieldType == typeof(int))
			{
				int result3 = 0;
				if (int.TryParse(Value.ToString(), out result3))
				{
					FI.SetValue(Obj, result3);
				}
			}
			if (FI.FieldType == typeof(long))
			{
				long result4 = 0L;
				if (long.TryParse(Value.ToString(), out result4))
				{
					FI.SetValue(Obj, result4);
				}
			}
			if (FI.FieldType == typeof(uint))
			{
				uint result5 = 0u;
				if (uint.TryParse(Value.ToString(), out result5))
				{
					FI.SetValue(Obj, result5);
				}
			}
			if (FI.FieldType == typeof(bool))
			{
				bool result6 = false;
				if (bool.TryParse(Value.ToString(), out result6))
				{
					FI.SetValue(Obj, result6);
				}
			}
			if (FI.FieldType == typeof(short))
			{
				short result7 = 0;
				if (short.TryParse(Value.ToString(), out result7))
				{
					FI.SetValue(Obj, result7);
				}
			}
			if (FI.FieldType == typeof(string))
			{
				FI.SetValue(Obj, Value.ToString());
			}
			if (FI.FieldType == typeof(long))
			{
				long result8 = 0L;
				if (long.TryParse(Value.ToString(), out result8))
				{
					FI.SetValue(Obj, result8);
				}
			}
			if (FI.FieldType == typeof(uint))
			{
				uint result9 = 0u;
				if (uint.TryParse(Value.ToString(), out result9))
				{
					FI.SetValue(Obj, result9);
				}
			}
			if (FI.FieldType == typeof(byte))
			{
				byte result10 = 0;
				if (byte.TryParse(Value.ToString(), out result10))
				{
					FI.SetValue(Obj, result10);
				}
			}
			if (FI.FieldType == typeof(Size))
			{
				if (Value.GetType() == typeof(string))
				{
					FI.SetValue(Obj, buStatics.StringToSize(Value.ToString()));
				}
				if (Value.GetType() == typeof(Size))
				{
					FI.SetValue(Obj, Value);
				}
			}
			if (FI.FieldType == typeof(SizeF))
			{
				if (Value.GetType() == typeof(string))
				{
					FI.SetValue(Obj, buStatics.StringToSizeF(Value.ToString()));
				}
				if (Value.GetType() == typeof(SizeF))
				{
					FI.SetValue(Obj, Value);
				}
			}
			if (FI.FieldType == typeof(Point))
			{
				if (Value.GetType() == typeof(string))
				{
					FI.SetValue(Obj, buStatics.StringToPoint(Value.ToString()));
				}
				if (Value.GetType() == typeof(Point))
				{
					FI.SetValue(Obj, Value);
				}
			}
			if (FI.FieldType == typeof(PointF))
			{
				if (Value.GetType() == typeof(string))
				{
					FI.SetValue(Obj, buStatics.StringToPointF(Value.ToString()));
				}
				if (Value.GetType() == typeof(PointF))
				{
					FI.SetValue(Obj, Value);
				}
			}
			if (FI.FieldType.BaseType == typeof(Enum))
			{
				EnumConverter enumConverter = new EnumConverter(FI.FieldType);
				FI.SetValue(Obj, enumConverter.ConvertFromString(Value.ToString()));
			}
			if (FI.FieldType == typeof(Color))
			{
				FI.SetValue(Obj, buStatics.StringToColor(Value.ToString(), ColorConvertType.String));
			}
			if (FI.FieldType == typeof(Font))
			{
				new FontConverter();
				if (Value.GetType() == typeof(string))
				{
					FI.SetValue(Obj, buStatics.StringToFont(Value.ToString()));
				}
				if (Value.GetType() == typeof(Font))
				{
					FI.SetValue(Obj, Value);
				}
			}
			if (FI.FieldType == typeof(DateTime))
			{
				FI.SetValue(Obj, buStatics.StringToDateTime(Value.ToString()));
			}
			if (FI.FieldType == typeof(Pnt2D))
			{
				Pnt2D pnt2D = new Pnt2D();
				pnt2D = Pnt2D.DecodeFromString(((Pnt2D)Value).ToDef());
				FI.SetValue(Obj, pnt2D);
			}
			if (FI.FieldType == typeof(Pnt3D))
			{
				Pnt3D pnt3D = new Pnt3D();
				pnt3D = Pnt3D.DecodeFromString(Value.ToString());
				FI.SetValue(Obj, pnt3D);
			}
			if (FI.FieldType == typeof(Plane))
			{
				if (!(Value.GetType() == typeof(Plane)))
				{
					Plane plane = new Plane();
					plane = DecoderFromPlane(Convert.ToString(Value));
					FI.SetValue(Obj, plane);
				}
				else
				{
					Plane plane2 = new Plane();
					plane2 = (Plane)((Plane)Value).Clone();
					FI.SetValue(Obj, plane2);
				}
			}
			if (FI.FieldType == typeof(Point3D))
			{
				Point3D point3D = new Point3D();
				point3D = buVector5.Point3DDecodeFromString(Convert.ToString(Value));
				FI.SetValue(Obj, point3D);
			}
			if (FI.FieldType == typeof(Vector3D))
			{
				Vector3D vector3D = new Vector3D();
				vector3D = buVector5.Vector3DDecodeFromString(Convert.ToString(Value));
				FI.SetValue(Obj, vector3D);
			}
			if (FI.FieldType == typeof(Pnt6D))
			{
				Pnt6D pnt6D = new Pnt6D();
				pnt6D = Pnt6D.DecodeFromString(Value.ToString());
				FI.SetValue(Obj, pnt6D);
			}
			if (FI.FieldType == typeof(Pnt9D))
			{
				Pnt9D pnt9D = new Pnt9D();
				pnt9D = Pnt9D.DecodeFromString(((Pnt9D)Value).ToDef());
				FI.SetValue(Obj, pnt9D);
			}
			if (FI.FieldType == typeof(Vec3D))
			{
				Vec3D vec3D = new Vec3D();
				vec3D = Vec3D.DecodeFromString(Value.ToString());
				FI.SetValue(Obj, vec3D);
			}
			if (FI.FieldType == typeof(Length3D))
			{
				Length3D length3D = new Length3D();
				length3D = Length3D.DecodeFromString(((Length3D)Value).ToDef());
				FI.SetValue(Obj, length3D);
			}
			if (FI.FieldType == typeof(OrientationAngle))
			{
				OrientationAngle value = new OrientationAngle();
				if (!(Value.GetType() == typeof(string)))
				{
					string value2 = ((OrientationAngle)Value).ToDef();
					value = OrientationAngle.DecodeFromString(value2);
					FI.SetValue(Obj, value);
				}
				else
				{
					FI.SetValue(Obj, value);
				}
			}
			if (FI.FieldType == typeof(Line3D))
			{
				Line3D line3D = new Line3D();
				line3D = Line3D.DecodeFromString(((Line3D)Value).ToDef());
				FI.SetValue(Obj, line3D);
			}
			if (FI.FieldType == typeof(Triangle3D))
			{
				Triangle3D triangle3D = new Triangle3D();
				triangle3D = Triangle3D.DecodeFromString(((Triangle3D)Value).ToDef());
				FI.SetValue(Obj, triangle3D);
			}
			if (FI.FieldType == typeof(Quad3D))
			{
				Quad3D quad3D = new Quad3D();
				quad3D = Quad3D.DecodeFromString(((Quad3D)Value).ToDef());
				FI.SetValue(Obj, quad3D);
			}
			if (FI.FieldType == typeof(object))
			{
				object obj = new object();
				obj = Value;
				FI.SetValue(Obj, obj);
			}
			if (FI.FieldType == typeof(ArrayList))
			{
				ArrayList arrayList = new ArrayList();
				if (Value.GetType() == typeof(ArrayList))
				{
					arrayList.AddRange(((ArrayList)Value).ToArray());
				}
				FI.SetValue(Obj, arrayList);
			}
			if (FI.FieldType == typeof(List<double>))
			{
				List<double> list = new List<double>();
				if (Value.GetType() == typeof(List<double>))
				{
					list.AddRange(((List<double>)Value).ToArray());
				}
				FI.SetValue(Obj, list);
			}
			if (FI.FieldType == typeof(List<int>))
			{
				List<int> list2 = new List<int>();
				if (Value.GetType() == typeof(List<int>))
				{
					list2.AddRange(((List<int>)Value).ToArray());
				}
				FI.SetValue(Obj, list2);
			}
			if (FI.FieldType == typeof(List<float>))
			{
				List<float> list3 = new List<float>();
				if (Value.GetType() == typeof(List<float>))
				{
					list3.AddRange(((List<float>)Value).ToArray());
				}
				FI.SetValue(Obj, list3);
			}
			if (FI.FieldType == typeof(List<bool>))
			{
				List<bool> list4 = new List<bool>();
				if (Value.GetType() == typeof(List<bool>))
				{
					list4.AddRange(((List<bool>)Value).ToArray());
				}
				FI.SetValue(Obj, list4);
			}
			if (FI.FieldType == typeof(List<string>))
			{
				List<string> list5 = new List<string>();
				if (Value.GetType() == typeof(List<string>))
				{
					list5.AddRange(((List<string>)Value).ToArray());
				}
				FI.SetValue(Obj, list5);
			}
			if (FI.FieldType == typeof(List<Pnt2D>))
			{
				List<Pnt2D> list6 = new List<Pnt2D>();
				if (Value.GetType() == typeof(List<Pnt2D>))
				{
					list6.AddRange(((List<Pnt2D>)Value).ToArray());
				}
				FI.SetValue(Obj, list6);
			}
			if (FI.FieldType == typeof(List<Pnt3D>))
			{
				List<Pnt3D> list7 = new List<Pnt3D>();
				if (Value.GetType() == typeof(List<Pnt3D>))
				{
					list7.AddRange(((List<Pnt3D>)Value).ToArray());
				}
				FI.SetValue(Obj, list7);
			}
			if (FI.FieldType == typeof(List<Point3D>))
			{
				List<Point3D> list8 = new List<Point3D>();
				if (Value.GetType() == typeof(List<Point3D>))
				{
					list8.AddRange(((List<Point3D>)Value).ToArray());
				}
				FI.SetValue(Obj, list8);
			}
			if (FI.FieldType == typeof(List<Pnt6D>))
			{
				List<Pnt6D> list9 = new List<Pnt6D>();
				if (Value.GetType() == typeof(List<Pnt6D>))
				{
					list9.AddRange(((List<Pnt6D>)Value).ToArray());
				}
				FI.SetValue(Obj, list9);
			}
			if (FI.FieldType == typeof(List<Pnt9D>))
			{
				List<Pnt9D> list10 = new List<Pnt9D>();
				if (Value.GetType() == typeof(List<Pnt9D>))
				{
					list10.AddRange(((List<Pnt9D>)Value).ToArray());
				}
				FI.SetValue(Obj, list10);
			}
			if (FI.FieldType == typeof(List<Vec3D>))
			{
				List<Vec3D> list11 = new List<Vec3D>();
				if (Value.GetType() == typeof(List<Vec3D>))
				{
					list11.AddRange(((List<Vec3D>)Value).ToArray());
				}
				FI.SetValue(Obj, list11);
			}
			if (FI.FieldType == typeof(List<OrientationAngle>))
			{
				List<OrientationAngle> list12 = new List<OrientationAngle>();
				if (Value.GetType() == typeof(List<OrientationAngle>))
				{
					list12.AddRange(((List<OrientationAngle>)Value).ToArray());
				}
				FI.SetValue(Obj, list12);
			}
			if (FI.FieldType == typeof(List<Line3D>))
			{
				List<Line3D> list13 = new List<Line3D>();
				if (Value.GetType() == typeof(List<Line3D>))
				{
					list13.AddRange(((List<Line3D>)Value).ToArray());
				}
				FI.SetValue(Obj, list13);
			}
			if (FI.FieldType == typeof(List<Triangle3D>))
			{
				List<Triangle3D> list14 = new List<Triangle3D>();
				if (Value.GetType() == typeof(List<Triangle3D>))
				{
					list14.AddRange(((List<Triangle3D>)Value).ToArray());
				}
				FI.SetValue(Obj, list14);
			}
			if (FI.FieldType == typeof(List<Quad3D>))
			{
				List<Quad3D> list15 = new List<Quad3D>();
				if (Value.GetType() == typeof(List<Quad3D>))
				{
					list15.AddRange(((List<Quad3D>)Value).ToArray());
				}
				FI.SetValue(Obj, list15);
			}
			if (FI.FieldType == typeof(List<List<Pnt3D>>))
			{
				List<List<Pnt3D>> list16 = new List<List<Pnt3D>>();
				if (Value.GetType() == typeof(List<List<Pnt3D>>))
				{
					for (int i = 0; i <= ((List<List<Pnt3D>>)Value).Count - 1; i++)
					{
						List<Pnt3D> list17 = new List<Pnt3D>();
						list17.AddRange(((List<List<Pnt3D>>)Value)[i].ToArray());
						list16.Add(list17);
					}
					FI.SetValue(Obj, list16);
				}
			}
			if (FI.FieldType == typeof(List<List<Point3D>>))
			{
				List<List<Point3D>> list18 = new List<List<Point3D>>();
				if (Value.GetType() == typeof(List<List<Point3D>>))
				{
					for (int j = 0; j <= ((List<List<Point3D>>)Value).Count - 1; j++)
					{
						List<Point3D> list19 = new List<Point3D>();
						list19.AddRange(((List<List<Point3D>>)Value)[j].ToArray());
						list18.Add(list19);
					}
					FI.SetValue(Obj, list18);
				}
			}
			if (FI.FieldType == typeof(double[]))
			{
				try
				{
					double[] array = new double[((double[])Value).Length];
					if (Value.GetType() == typeof(double[]))
					{
						for (int k = 0; k <= ((double[])Value).Length - 1; k++)
						{
							array[k] = ((double[])Value)[k];
						}
					}
					FI.SetValue(Obj, array);
				}
				catch (Exception)
				{
				}
			}
			if (FI.FieldType == typeof(float[]) && Value != null)
			{
				try
				{
					float[] array2 = new float[((float[])Value).Length];
					if (Value.GetType() == typeof(float[]))
					{
						for (int l = 0; l <= ((float[])Value).Length - 1; l++)
						{
							array2[l] = ((float[])Value)[l];
						}
					}
					FI.SetValue(Obj, array2);
				}
				catch (Exception)
				{
				}
			}
			if (FI.FieldType == typeof(int[]))
			{
				try
				{
					int[] array3 = new int[((int[])Value).Length];
					if (Value.GetType() == typeof(int[]))
					{
						for (int m = 0; m <= ((int[])Value).Length - 1; m++)
						{
							array3[m] = ((int[])Value)[m];
						}
					}
					FI.SetValue(Obj, array3);
				}
				catch (Exception)
				{
				}
			}
			if (FI.FieldType == typeof(bool[]))
			{
				try
				{
					bool[] array4 = new bool[((bool[])Value).Length];
					if (Value.GetType() == typeof(bool[]))
					{
						for (int n = 0; n <= ((bool[])Value).Length - 1; n++)
						{
							array4[n] = ((bool[])Value)[n];
						}
					}
					FI.SetValue(Obj, array4);
				}
				catch (Exception)
				{
				}
			}
			if (FI.FieldType == typeof(string[]))
			{
				try
				{
					string[] array5 = new string[((string[])Value).Length];
					if (Value.GetType() == typeof(string[]))
					{
						for (int num = 0; num <= ((string[])Value).Length - 1; num++)
						{
							array5[num] = ((string[])Value)[num];
						}
					}
					FI.SetValue(Obj, array5);
				}
				catch (Exception)
				{
				}
			}
			if (FI.FieldType == typeof(Pnt2D[]))
			{
				try
				{
					Pnt2D[] array6 = new Pnt2D[((Pnt2D[])Value).Length];
					if (Value.GetType() == typeof(Pnt2D[]))
					{
						for (int num2 = 0; num2 <= ((Pnt2D[])Value).Length - 1; num2++)
						{
							array6[num2] = ((Pnt2D[])Value)[num2];
						}
					}
					FI.SetValue(Obj, array6);
				}
				catch (Exception)
				{
				}
			}
			if (FI.FieldType == typeof(Point3D[]))
			{
				try
				{
					Point3D[] array7 = new Point3D[((Point3D[])Value).Length];
					if (Value.GetType() == typeof(Point3D[]))
					{
						for (int num3 = 0; num3 <= ((Point3D[])Value).Length - 1; num3++)
						{
							array7[num3] = ((Point3D[])Value)[num3];
						}
					}
					FI.SetValue(Obj, array7);
				}
				catch (Exception)
				{
				}
			}
			if (FI.FieldType == typeof(Pnt6D[]))
			{
				try
				{
					Pnt6D[] array8 = new Pnt6D[((Pnt6D[])Value).Length];
					if (Value.GetType() == typeof(Pnt6D[]))
					{
						for (int num4 = 0; num4 <= ((Pnt6D[])Value).Length - 1; num4++)
						{
							array8[num4] = ((Pnt6D[])Value)[num4];
						}
					}
					FI.SetValue(Obj, array8);
				}
				catch (Exception)
				{
				}
			}
			if (FI.FieldType == typeof(Pnt9D[]))
			{
				try
				{
					Pnt9D[] array9 = new Pnt9D[((Pnt9D[])Value).Length];
					if (Value.GetType() == typeof(Pnt9D[]))
					{
						for (int num5 = 0; num5 <= ((Pnt9D[])Value).Length - 1; num5++)
						{
							array9[num5] = ((Pnt9D[])Value)[num5];
						}
					}
					FI.SetValue(Obj, array9);
				}
				catch (Exception)
				{
				}
			}
			if (FI.FieldType == typeof(Vec3D[]))
			{
				try
				{
					Vec3D[] array10 = new Vec3D[((Vec3D[])Value).Length];
					if (Value.GetType() == typeof(Vec3D[]))
					{
						for (int num6 = 0; num6 <= ((Vec3D[])Value).Length - 1; num6++)
						{
							array10[num6] = ((Vec3D[])Value)[num6];
						}
					}
					FI.SetValue(Obj, array10);
				}
				catch (Exception)
				{
				}
			}
			if (FI.FieldType == typeof(OrientationAngle[]))
			{
				try
				{
					OrientationAngle[] array11 = new OrientationAngle[((OrientationAngle[])Value).Length];
					if (Value.GetType() == typeof(OrientationAngle[]))
					{
						for (int num7 = 0; num7 <= ((OrientationAngle[])Value).Length - 1; num7++)
						{
							array11[num7] = ((OrientationAngle[])Value)[num7];
						}
					}
					FI.SetValue(Obj, array11);
				}
				catch (Exception)
				{
				}
			}
			if (FI.FieldType == typeof(Line3D[]))
			{
				try
				{
					Line3D[] array12 = new Line3D[((Line3D[])Value).Length];
					if (Value.GetType() == typeof(Line3D[]))
					{
						for (int num8 = 0; num8 <= ((Line3D[])Value).Length - 1; num8++)
						{
							array12[num8] = ((Line3D[])Value)[num8];
						}
					}
					FI.SetValue(Obj, array12);
				}
				catch (Exception)
				{
				}
			}
			if (FI.FieldType == typeof(Triangle3D[]))
			{
				try
				{
					Triangle3D[] array13 = new Triangle3D[((Triangle3D[])Value).Length];
					if (Value.GetType() == typeof(Triangle3D[]))
					{
						for (int num9 = 0; num9 <= ((Triangle3D[])Value).Length - 1; num9++)
						{
							array13[num9] = ((Triangle3D[])Value)[num9];
						}
					}
					FI.SetValue(Obj, array13);
				}
				catch (Exception)
				{
				}
			}
			if (!(FI.FieldType == typeof(Quad3D[])))
			{
				return;
			}
			try
			{
				Quad3D[] array14 = new Quad3D[((Quad3D[])Value).Length];
				if (Value.GetType() == typeof(Quad3D[]))
				{
					for (int num10 = 0; num10 <= ((Quad3D[])Value).Length - 1; num10++)
					{
						array14[num10] = ((Quad3D[])Value)[num10];
					}
				}
				FI.SetValue(Obj, array14);
			}
			catch (Exception)
			{
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public static void GetClassVariableValuesFromStringCodes(string Code, object RefObject, ref List<cParameter5> Vars)
	{
		try
		{
			string[] array = null;
			array = Code.Split(';');
			if (array == null)
			{
				return;
			}
			Vars = new List<cParameter5>();
			GetClassVariables(RefObject, ref Vars);
			for (int i = 0; i <= Vars.Count - 1; i++)
			{
				bool flag = false;
				string value = "";
				for (int j = 0; j <= array.Length - 1; j++)
				{
					string[] array2 = null;
					array2 = array[j].Split('=');
					if (array2 == null)
					{
						continue;
					}
					if (array2.Length == 2 && array2[0].ToString().Trim() == Vars[i].Name.ToString().Trim())
					{
						value = array2[1].Trim();
						flag = true;
						j = array.Length + 1;
					}
					if (array2.Length <= 2 || !(array2[0].ToString().Trim() == Vars[i].Name.ToString().Trim()))
					{
						continue;
					}
					string text = "";
					for (int k = 1; k <= array2.Length - 1; k++)
					{
						string text2 = array2[k].Trim();
						if (k > 1)
						{
							text2 = "=" + text2;
						}
						if (text2.Length == 0)
						{
							text2 = "=";
						}
						text += text2;
					}
					value = text;
					flag = true;
					j = array.Length + 1;
				}
				if (!flag)
				{
					Vars[i].Value = "0";
				}
				else
				{
					Vars[i].Value = value;
				}
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public static void GetClassVariableValuesFromStringCodes(ArrayList Codes, object RefObject, ref List<cParameter5> Vars)
	{
		try
		{
			List<string> list = new List<string>();
			for (int i = 0; i <= Codes.Count - 1; i++)
			{
				list.Add(Codes[i].ToString());
			}
			GetClassVariableValuesFromStringCodes(list, RefObject, ref Vars);
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public static void GetSubClassVariableValuesFromStringCodes(List<string> Codes, ref object RefObject, ref List<cParameter5> Vars)
	{
		try
		{
			List<string> list = new List<string>();
			for (int i = 0; i <= Codes.Count - 1; i++)
			{
				string[] array = null;
				array = Codes[i].Split(new string[2] { "\r\n", "\n" }, StringSplitOptions.None);
				if (array != null)
				{
					for (int j = 0; j <= array.Length - 1; j++)
					{
						list.Add(array[j]);
					}
				}
			}
			if (list.Count <= 0)
			{
				return;
			}
			Vars = new List<cParameter5>();
			GetClassVariables(RefObject, ref Vars);
			for (int k = 0; k <= Vars.Count - 1; k++)
			{
				if (Vars[k] == null)
				{
					continue;
				}
				Type type = Vars[k].Value.GetType();
				string text = Vars[k].Name.ToString().Trim();
				bool flag = false;
				bool flag2 = false;
				string value = "";
				new ArrayList();
				if (k != 25)
				{
				}
				if ((type.IsClass | (type.IsValueType & !type.IsEnum)) & !type.IsArray)
				{
					string text2 = "";
					if (type.BaseType != null && type.BaseType.BaseType != null)
					{
						text2 = type.BaseType.BaseType.Namespace;
					}
					if (type.BaseType != null && ((type.Namespace == "buClass") | (type.BaseType.Namespace == "buClass") | (text2 == "buClass") | (type.Namespace == "buEyeBaseVer5") | (type.BaseType.Namespace == "buEyeBaseVer5") | (text2 == "buEyeBaseVer5") | (type.Namespace == "buMW") | (type.BaseType.Namespace == "buMW") | (text2 == "buMW")))
					{
						List<string> CalcList = new List<string>();
						List<cParameter5> Vars2 = new List<cParameter5>();
						buStatics.ListToSpecificList("<" + text + ">", "</" + text + ">", list, ref CalcList);
						GetSubClassVariableValuesFromStringCodes(CalcList, ref Vars[k].Value, ref Vars2);
						Vars[k].SubParameter = Vars2;
						object ObjPar = Vars[k].Field.GetValue(RefObject);
						SetClassVariables(ref ObjPar, Vars2);
						Vars[k].Value = ObjPar;
						flag2 = true;
						flag = true;
					}
				}
				if (type.IsArray)
				{
					ArrayList CalcList2 = new ArrayList();
					new List<cParameter5>();
					buStatics.ListToSpecificList("<" + text + ">", "</" + text + ">", list, ref CalcList2);
					Class186.smethod_569(ref Vars[k].Value, CalcList2);
					flag2 = true;
					flag = true;
				}
				if (!type.IsArray && Vars[k].Types.Name.IndexOf("List`1") >= 0)
				{
					ArrayList CalcList3 = new ArrayList();
					new List<cParameter5>();
					buStatics.ListToSpecificList("<" + text + ">", "</" + text + ">", list, ref CalcList3);
					Class186.smethod_236(CalcList3, ref Vars[k].Value);
					flag2 = true;
					flag = true;
				}
				if (!type.IsArray && Vars[k].Types.Name.IndexOf("ArrayList") >= 0)
				{
					ArrayList CalcList4 = new ArrayList();
					new List<cParameter5>();
					buStatics.ListToSpecificList("<" + text + ">", "</" + text + ">", list, ref CalcList4);
					Class186.smethod_708(CalcList4, ref Vars[k].Value);
					flag2 = true;
					flag = true;
				}
				if (!flag2)
				{
					for (int l = 0; l <= list.Count - 1; l++)
					{
						string string_ = "";
						string string_2 = "";
						if (Class186.smethod_755(ref string_, ref string_2, list[l]))
						{
							string text3 = RefObject.GetType().Name + ".";
							if ((string_2.Trim() == text) | (string_2.Trim() == text3 + text))
							{
								value = string_.Trim();
								flag = true;
								l = list.Count + 1;
							}
						}
					}
				}
				if (flag && !flag2)
				{
					Vars[k].Value = value;
				}
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public static void GetClassVariableValuesFromStringCodes(List<string> Codes, object RefObject, ref List<cParameter5> Vars)
	{
		try
		{
			List<string> list = new List<string>();
			for (int i = 0; i <= Codes.Count - 1; i++)
			{
				string[] array = null;
				array = Codes[i].Split(new string[2] { "\r\n", "\n" }, StringSplitOptions.None);
				if (array != null)
				{
					for (int j = 0; j <= array.Length - 1; j++)
					{
						list.Add(array[j]);
					}
				}
			}
			if (list.Count <= 0)
			{
				return;
			}
			Vars = new List<cParameter5>();
			GetClassVariables(RefObject, ref Vars);
			for (int k = 0; k <= Vars.Count - 1; k++)
			{
				if (Vars[k] == null)
				{
					continue;
				}
				Type type = Vars[k].Value.GetType();
				string text = Vars[k].Name.ToString().Trim();
				bool flag = false;
				bool flag2 = false;
				string value = "";
				new ArrayList();
				if (k != 55)
				{
				}
				if (((type.IsClass | (type.IsValueType & !type.IsEnum)) & !type.IsArray) && ((type.Namespace == "buClass") | (type.BaseType.Namespace == "buClass") | (type.Namespace == "buEyeBaseVer5") | (type.BaseType.Namespace == "buEyeBaseVer5") | (type.Namespace == "buMW") | (type.BaseType.Namespace == "buMW")))
				{
					List<string> CalcList = new List<string>();
					List<cParameter5> Vars2 = new List<cParameter5>();
					buStatics.ListToSpecificList("<" + text + ">", "</" + text + ">", list, ref CalcList);
					GetSubClassVariableValuesFromStringCodes(CalcList, ref Vars[k].Value, ref Vars2);
					if (Vars2.Count == 0 && (List<cParameter5>)Vars[k].SubParameter != null)
					{
						for (int l = 0; l <= ((List<cParameter5>)Vars[k].SubParameter).Count - 1; l++)
						{
							Vars2.Add(((List<cParameter5>)Vars[k].SubParameter)[l]);
						}
					}
					Vars[k].SubParameter = Vars2;
					if (Vars2.Count > 0)
					{
						object ObjPar = Vars[k].Field.GetValue(RefObject);
						SetClassVariables(ref ObjPar, Vars2);
						Vars[k].Value = ObjPar;
						flag = true;
					}
					flag2 = true;
				}
				if (type.IsArray)
				{
					ArrayList CalcList2 = new ArrayList();
					new List<cParameter5>();
					buStatics.ListToSpecificList("<" + text + ">", "</" + text + ">", list, ref CalcList2);
					Class186.smethod_569(ref Vars[k].Value, CalcList2);
					flag2 = true;
					flag = true;
				}
				if (!type.IsArray && Vars[k].Types.FullName.IndexOf("Generic.List") >= 0)
				{
					string[] array2 = Vars[k].Types.FullName.Split(new string[1] { "Generic.List" }, StringSplitOptions.None);
					ArrayList CalcList3 = new ArrayList();
					new List<cParameter5>();
					if (array2.Length == 2)
					{
						buStatics.ListToSpecificList("<" + text + ">", "</" + text + ">", list, ref CalcList3);
						Class186.smethod_236(CalcList3, ref Vars[k].Value);
						flag2 = true;
						flag = true;
					}
					if (array2.Length == 3)
					{
						buStatics.ListToSpecificList("<" + text + ">", "</" + text + ">", list, ref CalcList3);
						Class186.smethod_399(CalcList3, ref Vars[k].Value, text);
						flag2 = true;
						flag = true;
					}
				}
				if (!type.IsArray && Vars[k].Types.Name.IndexOf("ArrayList") >= 0)
				{
					ArrayList CalcList4 = new ArrayList();
					new List<cParameter5>();
					buStatics.ListToSpecificList("<" + text + ">", "</" + text + ">", list, ref CalcList4);
					Class186.smethod_708(CalcList4, ref Vars[k].Value);
					flag2 = true;
					flag = true;
				}
				if (!flag2)
				{
					for (int m = 0; m <= list.Count - 1; m++)
					{
						string string_ = "";
						string string_2 = "";
						if (Class186.smethod_755(ref string_, ref string_2, list[m]))
						{
							string text2 = RefObject.GetType().Name + ".";
							if ((string_2.Trim() == text) | (string_2.Trim() == text2 + text))
							{
								value = string_.Trim();
								flag = true;
								m = list.Count + 1;
							}
						}
					}
				}
				if (flag && !flag2)
				{
					Vars[k].Value = value;
				}
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	internal ArrayList method_0(string string_0, object object_0, int int_0)
	{
		try
		{
			string text = new string(' ', int_0);
			ArrayList arrayList = new ArrayList();
			if (object_0 != null)
			{
				object_0.GetType().ToString();
				Type type = object_0.GetType();
				if (type == typeof(List<double>))
				{
					arrayList.Add(text + "<" + string_0 + ">");
					string text2 = new string(' ', int_0 + 2);
					for (int i = 0; i <= ((List<double>)object_0).Count - 1; i++)
					{
						double num = 0.0;
						arrayList.Add(text2 + string_0 + " = " + ((List<double>)object_0)[i]);
					}
					arrayList.Add(text + "</" + string_0 + ">");
				}
				if (type == typeof(List<int>))
				{
					arrayList.Add(text + "<" + string_0 + ">");
					string text3 = new string(' ', int_0 + 2);
					for (int j = 0; j <= ((List<int>)object_0).Count - 1; j++)
					{
						int num2 = 0;
						arrayList.Add(text3 + string_0 + " = " + ((List<int>)object_0)[j]);
					}
					arrayList.Add(text + "</" + string_0 + ">");
				}
				if (type == typeof(List<float>))
				{
					arrayList.Add(text + "<" + string_0 + ">");
					string text4 = new string(' ', int_0 + 2);
					for (int k = 0; k <= ((List<float>)object_0).Count - 1; k++)
					{
						float num3 = 0f;
						arrayList.Add(text4 + string_0 + " = " + ((List<float>)object_0)[k]);
					}
					arrayList.Add(text + "</" + string_0 + ">");
				}
				if (type == typeof(List<bool>))
				{
					arrayList.Add(text + "<" + string_0 + ">");
					string text5 = new string(' ', int_0 + 2);
					for (int l = 0; l <= ((List<bool>)object_0).Count - 1; l++)
					{
						bool flag = false;
						arrayList.Add(text5 + string_0 + " = " + ((List<bool>)object_0)[l]);
					}
					arrayList.Add(text + "</" + string_0 + ">");
				}
				if (type == typeof(List<string>))
				{
					arrayList.Add(text + "<" + string_0 + ">");
					string text6 = new string(' ', int_0 + 2);
					for (int m = 0; m <= ((List<string>)object_0).Count - 1; m++)
					{
						string text7 = "";
						text7 = ((List<string>)object_0)[m];
						arrayList.Add(text6 + string_0 + " = " + text7.ToString());
					}
					arrayList.Add(text + "</" + string_0 + ">");
				}
				if (type == typeof(List<Pnt2D>))
				{
					arrayList.Add(text + "<" + string_0 + ">");
					string text8 = new string(' ', int_0 + 2);
					for (int n = 0; n <= ((List<Pnt2D>)object_0).Count - 1; n++)
					{
						Pnt2D pnt2D = new Pnt2D();
						pnt2D = ((List<Pnt2D>)object_0)[n];
						arrayList.Add(text8 + string_0 + " = " + pnt2D.ToDef());
					}
					arrayList.Add(text + "</" + string_0 + ">");
				}
				if (type == typeof(List<Pnt3D>))
				{
					arrayList.Add(text + "<" + string_0 + ">");
					string text9 = new string(' ', int_0 + 2);
					for (int num4 = 0; num4 <= ((List<Pnt3D>)object_0).Count - 1; num4++)
					{
						Pnt3D pnt3D = new Pnt3D();
						pnt3D = ((List<Pnt3D>)object_0)[num4];
						arrayList.Add(text9 + string_0 + " = " + pnt3D.ToDef());
					}
					arrayList.Add(text + "</" + string_0 + ">");
				}
				if (type == typeof(List<Point3D>))
				{
					arrayList.Add(text + "<" + string_0 + ">");
					string text10 = new string(' ', int_0 + 2);
					for (int num5 = 0; num5 <= ((List<Point3D>)object_0).Count - 1; num5++)
					{
						Point3D point3D = new Point3D();
						point3D = ((List<Point3D>)object_0)[num5];
						arrayList.Add(text10 + string_0 + " = " + buVector5.Point3DToDef(point3D));
					}
					arrayList.Add(text + "</" + string_0 + ">");
				}
				if (type == typeof(List<Pnt6D>))
				{
					arrayList.Add(text + "<" + string_0 + ">");
					string text11 = new string(' ', int_0 + 2);
					for (int num6 = 0; num6 <= ((List<Pnt6D>)object_0).Count - 1; num6++)
					{
						Pnt6D pnt6D = new Pnt6D();
						pnt6D = ((List<Pnt6D>)object_0)[num6];
						arrayList.Add(text11 + string_0 + " = " + pnt6D.ToDef());
					}
					arrayList.Add(text + "</" + string_0 + ">");
				}
				if (type == typeof(List<Pnt9D>))
				{
					arrayList.Add(text + "<" + string_0 + ">");
					string text12 = new string(' ', int_0 + 2);
					for (int num7 = 0; num7 <= ((List<Pnt9D>)object_0).Count - 1; num7++)
					{
						Pnt9D pnt9D = new Pnt9D();
						pnt9D = ((List<Pnt9D>)object_0)[num7];
						arrayList.Add(text12 + string_0 + " = " + pnt9D.ToDef());
					}
					arrayList.Add(text + "</" + string_0 + ">");
				}
				if (type == typeof(List<Vec3D>))
				{
					arrayList.Add(text + "<" + string_0 + ">");
					string text13 = new string(' ', int_0 + 2);
					for (int num8 = 0; num8 <= ((List<Vec3D>)object_0).Count - 1; num8++)
					{
						Vec3D vec3D = new Vec3D();
						vec3D = ((List<Vec3D>)object_0)[num8];
						arrayList.Add(text13 + string_0 + " = " + vec3D.ToDef());
					}
					arrayList.Add(text + "</" + string_0 + ">");
				}
				if (type == typeof(List<OrientationAngle>))
				{
					arrayList.Add(text + "<" + string_0 + ">");
					string text14 = new string(' ', int_0 + 2);
					for (int num9 = 0; num9 <= ((List<OrientationAngle>)object_0).Count - 1; num9++)
					{
						OrientationAngle orientationAngle = new OrientationAngle();
						orientationAngle = ((List<OrientationAngle>)object_0)[num9];
						arrayList.Add(text14 + string_0 + " = " + orientationAngle.ToDef());
					}
					arrayList.Add(text + "</" + string_0 + ">");
				}
				if (type == typeof(List<Line3D>))
				{
					arrayList.Add(text + "<" + string_0 + ">");
					string text15 = new string(' ', int_0 + 2);
					for (int num10 = 0; num10 <= ((List<Line3D>)object_0).Count - 1; num10++)
					{
						Line3D line3D = new Line3D();
						line3D = ((List<Line3D>)object_0)[num10];
						arrayList.Add(text15 + string_0 + " = " + line3D.ToDef(2));
					}
					arrayList.Add(text + "</" + string_0 + ">");
				}
				if (type == typeof(List<Triangle3D>))
				{
					arrayList.Add(text + "<" + string_0 + ">");
					string text16 = new string(' ', int_0 + 2);
					for (int num11 = 0; num11 <= ((List<Triangle3D>)object_0).Count - 1; num11++)
					{
						Triangle3D triangle3D = new Triangle3D();
						triangle3D = ((List<Triangle3D>)object_0)[num11];
						arrayList.Add(text16 + string_0 + " = " + triangle3D.ToDef(2));
					}
					arrayList.Add(text + "</" + string_0 + ">");
				}
				if (type == typeof(List<Quad3D>))
				{
					arrayList.Add(text + "<" + string_0 + ">");
					string text17 = new string(' ', int_0 + 2);
					for (int num12 = 0; num12 <= ((List<Quad3D>)object_0).Count - 1; num12++)
					{
						Quad3D quad3D = new Quad3D();
						quad3D = ((List<Quad3D>)object_0)[num12];
						arrayList.Add(text17 + string_0 + " = " + quad3D.ToDef(2));
					}
					arrayList.Add(text + "</" + string_0 + ">");
				}
				return arrayList;
			}
			return arrayList;
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			return new ArrayList();
		}
	}

	internal ArrayList method_1(string string_0, object object_0, int int_0)
	{
		try
		{
			string text = new string(' ', int_0);
			ArrayList arrayList = new ArrayList();
			if (object_0 != null)
			{
				string text2 = object_0.GetType().ToString();
				if (text2.IndexOf("System.Double[]") >= 0)
				{
					arrayList.Add(text + "<" + string_0 + ">");
					string text3 = new string(' ', int_0 + 2);
					for (int i = 0; i <= ((double[])object_0).Length - 1; i++)
					{
						double num = 0.0;
						num = ((double[])object_0)[i];
						arrayList.Add(text3 + string_0 + " = " + num);
					}
					arrayList.Add(text + "</" + string_0 + ">");
				}
				if (text2.IndexOf("System.Int32[]") >= 0)
				{
					arrayList.Add(text + "<" + string_0 + ">");
					string text4 = new string(' ', int_0 + 2);
					for (int j = 0; j <= ((int[])object_0).Length - 1; j++)
					{
						int num2 = 0;
						num2 = ((int[])object_0)[j];
						arrayList.Add(text4 + string_0 + " = " + num2);
					}
					arrayList.Add(text + "</" + string_0 + ">");
				}
				if (text2.IndexOf("System.Single[]") >= 0)
				{
					arrayList.Add(text + "<" + string_0 + ">");
					string text5 = new string(' ', int_0 + 2);
					for (int k = 0; k <= ((float[])object_0).Length - 1; k++)
					{
						float num3 = 0f;
						num3 = ((float[])object_0)[k];
						arrayList.Add(text5 + string_0 + " = " + num3);
					}
					arrayList.Add(text + "</" + string_0 + ">");
				}
				if (text2.IndexOf("System.Boolean[]") >= 0)
				{
					arrayList.Add(text + "<" + string_0 + ">");
					string text6 = new string(' ', int_0 + 2);
					for (int l = 0; l <= ((bool[])object_0).Length - 1; l++)
					{
						bool flag = false;
						flag = ((bool[])object_0)[l];
						arrayList.Add(text6 + string_0 + " = " + flag);
					}
					arrayList.Add(text + "</" + string_0 + ">");
				}
				if (text2.IndexOf("System.String[]") >= 0)
				{
					arrayList.Add(text + "<" + string_0 + ">");
					string text7 = new string(' ', int_0 + 2);
					for (int m = 0; m <= ((string[])object_0).Length - 1; m++)
					{
						string text8 = "";
						text8 = ((string[])object_0)[m];
						arrayList.Add(text7 + string_0 + " = " + text8.ToString());
					}
					arrayList.Add(text + "</" + string_0 + ">");
				}
				return arrayList;
			}
			return arrayList;
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			return new ArrayList();
		}
	}
}
