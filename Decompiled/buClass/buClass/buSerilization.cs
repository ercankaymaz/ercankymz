using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;

namespace buClass;

[Serializable]
public class buSerilization
{
	public static List<string> ExceptionalVariables = new List<string>();

	public string ToDefLine(int Space)
	{
		try
		{
			string text = new string(' ', Space);
			List<cParameter> Vars = new List<cParameter>();
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
			List<cParameter> Vars = new List<cParameter>();
			GetClassVariables(this, ref Vars);
			ArrayList arrayList = new ArrayList();
			string text2 = text;
			for (int i = 0; i <= Vars.Count - 1; i++)
			{
				if (i == 75)
				{
				}
				string text3 = Vars[i].Value.GetType().ToString();
				bool flag = false;
				Type type = Vars[i].Value.GetType();
				if ((Vars[i].Value.GetType() != typeof(ArrayList)) & (text3.IndexOf("Generic.List") < 0) & !type.IsArray)
				{
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
						if (type.BaseType != null && (((type.Namespace == "buClass") | (type.BaseType.Namespace == "buClass") | (type.Namespace == "buEyeBaseVer5") | (type.BaseType.Namespace == "buEyeBaseVer5") | (type.Namespace == "buMW") | (type.BaseType.Namespace == "buMW") | (type.Namespace.IndexOf("buControls") >= 0)) & !type.IsEnum) && Vars[i].Value.GetType().BaseType != typeof(eEntities))
						{
							string text4 = new string(' ', Space);
							arrayList.Add(text4 + "<" + Vars[i].Name + ">");
							arrayList.AddRange(ToDefSubClass(Vars[i].Value, Space + 2).ToArray());
							arrayList.Add(text4 + "</" + Vars[i].Name + ">");
							flag = true;
						}
						if (Vars[i].Value.GetType().BaseType == typeof(eEntities))
						{
							flag = true;
						}
						if (!flag)
						{
							string text5 = GetType().Name + ".";
							arrayList.Add(text + text5 + Vars[i].Name + " = " + Vars[i].ValueAsString.ToString());
						}
					}
				}
				else if (type.IsArray)
				{
					arrayList.AddRange(ArrayToStrings(Vars[i].Name.ToString(), Vars[i].Value, Space).ToArray());
				}
				else if (Vars[i].Value.GetType() == typeof(ArrayList))
				{
					arrayList.AddRange(ArrayListToStrings(Vars[i].Name.ToString(), (ArrayList)Vars[i].Value, Space).ToArray());
				}
				else
				{
					if (text3.IndexOf("Generic.List") < 0)
					{
						continue;
					}
					string[] array = text3.Split(new string[1] { "Generic.List" }, StringSplitOptions.None);
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
						if (array.Length == 2)
						{
							arrayList.AddRange(ListToStrings(Vars[i].Name.ToString(), Vars[i].Value, Space).ToArray());
						}
						if (array.Length == 3)
						{
							arrayList.AddRange(ListListToStrings(Vars[i].Name.ToString(), Vars[i].Value, Space).ToArray());
						}
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
		return ToDefAll(Char, Space, SerilizationMode.MultiLine);
	}

	public ArrayList ToDefAll(string Char, int Space, SerilizationMode DefMode)
	{
		ArrayList arrayList = new ArrayList();
		string text = new string(' ', Space);
		string text2 = new string(' ', Space + 2);
		if (DefMode == SerilizationMode.SingleLine)
		{
			arrayList.Add(text + "<" + GetType().Name + Char + ">");
			arrayList.Add(ToDefLine(Space + 2));
			arrayList.Add(text + "</" + GetType().Name + Char + ">");
		}
		if (DefMode == SerilizationMode.MultiLine)
		{
			arrayList.Add(text + "<" + GetType().Name + Char + ">");
			arrayList.AddRange(ToDefNewLine(Space + 2));
			arrayList.Add(text + "</" + GetType().Name + Char + ">");
		}
		if (DefMode == SerilizationMode.SingleLineWithParenthesis)
		{
			arrayList.Add(text + GetType().Name + Char + "(" + ToDefLine(0) + ")");
		}
		return arrayList;
	}

	public ArrayList ToDefAll(string Char, int Space, SerilizationMode DefMode, string DefClassName)
	{
		ArrayList arrayList = new ArrayList();
		string text = new string(' ', Space);
		string text2 = new string(' ', Space + 2);
		if (DefMode == SerilizationMode.SingleLine)
		{
			arrayList.Add(text + "<" + DefClassName + Char + ">");
			arrayList.Add(ToDefLine(Space + 2));
			arrayList.Add(text + "</" + DefClassName + Char + ">");
		}
		if (DefMode == SerilizationMode.MultiLine)
		{
			arrayList.Add(text + "<" + DefClassName + Char + ">");
			arrayList.AddRange(ToDefNewLine(Space + 2));
			arrayList.Add(text + "</" + DefClassName + Char + ">");
		}
		if (DefMode == SerilizationMode.SingleLineWithParenthesis)
		{
			arrayList.Add(text + DefClassName + Char + "(" + ToDefLine(0) + ")");
		}
		return arrayList;
	}

	public static object Decode(ArrayList AL, string Char, SerilizationMode Mode, object Obj)
	{
		object result = null;
		List<string> CalcList = new List<string>();
		List<string> list = new List<string>();
		buStatics.ListToSpecificList("<" + Obj.GetType().Name + Char + ">", "</" + Obj.GetType().Name + Char + ">", AL, ref CalcList);
		if (CalcList.Count > 0)
		{
			List<cParameter> Vars = new List<cParameter>();
			GetClassVariableValuesFromStringCodes(CalcList, Obj, ref Vars);
			if (Vars.Count > 0)
			{
				SetClassVariables(ref Obj, Vars);
			}
		}
		return result;
	}

	public static object Decode(List<string> SL, string Char, SerilizationMode Mode, object Obj)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.AddRange(SL.ToArray());
		return Decode(arrayList, Char, Mode, Obj);
	}

	public static object DecodeProperty(ArrayList AL, string Char, SerilizationMode Mode, object Obj)
	{
		object result = null;
		List<string> CalcList = new List<string>();
		List<string> list = new List<string>();
		buStatics.ListToSpecificList("<" + Obj.GetType().Name + Char + ">", "</" + Obj.GetType().Name + Char + ">", AL, ref CalcList);
		if (CalcList.Count > 0)
		{
			List<cParameter> Vars = new List<cParameter>();
			GetClassPropertyVariableValuesFromStringCodes(CalcList, Obj, ref Vars);
			if (Vars.Count > 0)
			{
				SetClassPropertyVariables(ref Obj, Vars);
			}
		}
		return result;
	}

	public static object DecodeProperty(List<string> SL, string Char, SerilizationMode Mode, object Obj)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.AddRange(SL.ToArray());
		return DecodeProperty(arrayList, Char, Mode, Obj);
	}

	public static void GetClassVariables(object ObjPar, ref List<cParameter> Vars)
	{
		GetClassVariables(ObjPar, UseSubClass: true, UseArrayList: true, UseList: true, UseArray: true, ref Vars);
	}

	public static void GetClassVariables(object ObjPar, bool UseSubClass, bool UseArrayList, bool UseList, bool UseArray, ref List<cParameter> Vars)
	{
		try
		{
			Vars.Clear();
			FieldInfo[] array = null;
			PropertyInfo[] array2 = null;
			if (ObjPar == null)
			{
				return;
			}
			array = ObjPar.GetType().GetFields();
			array2 = ObjPar.GetType().GetProperties();
			if (array != null)
			{
				for (int i = 0; i <= array.Length - 1; i++)
				{
					if (i == 26)
					{
					}
					cParameter cParameter2 = null;
					object obj = null;
					FieldInfo fieldInfo = array[i];
					string name = fieldInfo.Name;
					string name2 = fieldInfo.Name;
					if (ObjPar == null)
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
						if ((fieldInfo.FieldType.ToString().IndexOf("Generic.List") < 0) & (fieldInfo.FieldType.ToString().IndexOf("ArrayList") < 0) & !type.IsArray)
						{
							if (obj.GetType() == typeof(double))
							{
								cParameter2 = new cParameter();
								cParameter2.Name = fieldInfo.Name;
								cParameter2.Value = obj;
								cParameter2.ValueAsString = obj.ToString();
								cParameter2.Field = fieldInfo;
								cParameter2.Types = obj.GetType();
							}
							else if (obj.GetType() == typeof(int))
							{
								cParameter2 = new cParameter();
								cParameter2.Name = fieldInfo.Name;
								cParameter2.Value = obj;
								cParameter2.ValueAsString = obj.ToString();
								cParameter2.Field = fieldInfo;
								cParameter2.Types = obj.GetType();
							}
							else if (obj.GetType() == typeof(float))
							{
								cParameter2 = new cParameter();
								cParameter2.Name = fieldInfo.Name;
								cParameter2.Value = obj;
								cParameter2.ValueAsString = obj.ToString();
								cParameter2.Field = fieldInfo;
								cParameter2.Types = obj.GetType();
							}
							else if (obj.GetType() == typeof(long))
							{
								cParameter2 = new cParameter();
								cParameter2.Name = fieldInfo.Name;
								cParameter2.Value = obj;
								cParameter2.ValueAsString = obj.ToString();
								cParameter2.Field = fieldInfo;
								cParameter2.Types = obj.GetType();
							}
							else if (obj.GetType() == typeof(uint))
							{
								cParameter2 = new cParameter();
								cParameter2.Name = fieldInfo.Name;
								cParameter2.Value = obj;
								cParameter2.ValueAsString = obj.ToString();
								cParameter2.Field = fieldInfo;
								cParameter2.Types = obj.GetType();
							}
							else if (obj.GetType() == typeof(bool))
							{
								cParameter2 = new cParameter();
								cParameter2.Name = fieldInfo.Name;
								cParameter2.Value = obj;
								cParameter2.ValueAsString = obj.ToString();
								cParameter2.Field = fieldInfo;
								cParameter2.Types = obj.GetType();
							}
							else if (obj.GetType() == typeof(byte))
							{
								cParameter2 = new cParameter();
								cParameter2.Name = fieldInfo.Name;
								cParameter2.Value = obj;
								cParameter2.ValueAsString = obj.ToString();
								cParameter2.Field = fieldInfo;
								cParameter2.Types = obj.GetType();
							}
							else if (obj.GetType() == typeof(string))
							{
								cParameter2 = new cParameter();
								cParameter2.Name = fieldInfo.Name;
								cParameter2.Value = obj;
								cParameter2.ValueAsString = obj.ToString();
								cParameter2.Field = fieldInfo;
								cParameter2.Types = obj.GetType();
							}
							else if (obj.GetType() == typeof(Color))
							{
								cParameter2 = new cParameter();
								cParameter2.Name = fieldInfo.Name;
								cParameter2.Value = obj;
								cParameter2.ValueAsString = buStatics.ColorToString((Color)obj, ColorConvertType.String);
								cParameter2.Field = fieldInfo;
								cParameter2.Types = obj.GetType();
							}
							else if (obj.GetType() == typeof(Font))
							{
								cParameter2 = new cParameter();
								cParameter2.Name = fieldInfo.Name;
								cParameter2.Value = obj;
								cParameter2.ValueAsString = buStatics.FontToString((Font)obj);
								cParameter2.Field = fieldInfo;
								cParameter2.Types = obj.GetType();
							}
							else if (obj.GetType() == typeof(DateTime))
							{
								cParameter2 = new cParameter();
								cParameter2.Name = fieldInfo.Name;
								cParameter2.Value = obj;
								cParameter2.ValueAsString = ((DateTime)obj).ToString();
								cParameter2.Field = fieldInfo;
								cParameter2.Types = obj.GetType();
							}
							else if (obj.GetType() == typeof(Size))
							{
								cParameter2 = new cParameter();
								cParameter2.Name = fieldInfo.Name;
								cParameter2.Value = obj;
								cParameter2.ValueAsString = ((Size)obj).Width + ";" + ((Size)obj).Height;
								cParameter2.Field = fieldInfo;
								cParameter2.Types = obj.GetType();
							}
							else if (obj.GetType() == typeof(SizeF))
							{
								cParameter2 = new cParameter();
								cParameter2.Name = fieldInfo.Name;
								cParameter2.Value = obj;
								cParameter2.ValueAsString = ((SizeF)obj).Width + ";" + ((SizeF)obj).Height;
								cParameter2.Field = fieldInfo;
								cParameter2.Types = obj.GetType();
							}
							else if (obj.GetType() == typeof(Point))
							{
								cParameter2 = new cParameter();
								cParameter2.Name = fieldInfo.Name;
								cParameter2.Value = obj;
								cParameter2.ValueAsString = ((Point)obj).X + ";" + ((Point)obj).Y;
								cParameter2.Field = fieldInfo;
								cParameter2.Types = obj.GetType();
							}
							else if (obj.GetType() == typeof(PointF))
							{
								cParameter2 = new cParameter();
								cParameter2.Name = fieldInfo.Name;
								cParameter2.Value = obj;
								cParameter2.ValueAsString = ((PointF)obj).X + ";" + ((PointF)obj).Y;
								cParameter2.Field = fieldInfo;
								cParameter2.Types = obj.GetType();
							}
							else if (obj.GetType() == typeof(Pnt2D))
							{
								cParameter2 = new cParameter();
								cParameter2.Name = fieldInfo.Name;
								cParameter2.Value = obj;
								cParameter2.ValueAsString = ((Pnt2D)obj).ToDef();
								cParameter2.Field = fieldInfo;
								cParameter2.Types = obj.GetType();
							}
							else if (obj.GetType() == typeof(Pnt3D))
							{
								cParameter2 = new cParameter();
								cParameter2.Name = fieldInfo.Name;
								cParameter2.Value = obj;
								cParameter2.ValueAsString = ((Pnt3D)obj).ToDef();
								cParameter2.Field = fieldInfo;
								cParameter2.Types = obj.GetType();
							}
							else if (obj.GetType() == typeof(Pnt6D))
							{
								cParameter2 = new cParameter();
								cParameter2.Name = fieldInfo.Name;
								cParameter2.Value = obj;
								cParameter2.ValueAsString = ((Pnt6D)obj).ToDef();
								cParameter2.Field = fieldInfo;
								cParameter2.Types = obj.GetType();
							}
							else if (obj.GetType() == typeof(Pnt9D))
							{
								cParameter2 = new cParameter();
								cParameter2.Name = fieldInfo.Name;
								cParameter2.Value = obj;
								cParameter2.ValueAsString = ((Pnt9D)obj).ToDef();
								cParameter2.Field = fieldInfo;
								cParameter2.Types = obj.GetType();
							}
							else if (obj.GetType() == typeof(Vec3D))
							{
								cParameter2 = new cParameter();
								cParameter2.Name = fieldInfo.Name;
								cParameter2.Value = obj;
								cParameter2.ValueAsString = ((Vec3D)obj).ToDef();
								cParameter2.Field = fieldInfo;
								cParameter2.Types = obj.GetType();
							}
							else if (obj.GetType() == typeof(Length3D))
							{
								cParameter2 = new cParameter();
								cParameter2.Name = fieldInfo.Name;
								cParameter2.Value = obj;
								cParameter2.ValueAsString = ((Length3D)obj).ToDef();
								cParameter2.Field = fieldInfo;
								cParameter2.Types = obj.GetType();
							}
							else if (obj.GetType() == typeof(OrientationAngle))
							{
								cParameter2 = new cParameter();
								cParameter2.Name = fieldInfo.Name;
								cParameter2.Value = obj;
								cParameter2.ValueAsString = ((OrientationAngle)obj).ToDef();
								cParameter2.Field = fieldInfo;
								cParameter2.Types = obj.GetType();
							}
							else if (obj.GetType() == typeof(Line3D))
							{
								cParameter2 = new cParameter();
								cParameter2.Name = fieldInfo.Name;
								cParameter2.Value = obj;
								cParameter2.ValueAsString = ((Line3D)obj).ToDef();
								cParameter2.Field = fieldInfo;
								cParameter2.Types = obj.GetType();
							}
							else if (obj.GetType() == typeof(Triangle3D))
							{
								cParameter2 = new cParameter();
								cParameter2.Name = fieldInfo.Name;
								cParameter2.Value = obj;
								cParameter2.ValueAsString = ((Triangle3D)obj).ToDef();
								cParameter2.Field = fieldInfo;
								cParameter2.Types = obj.GetType();
							}
							else if (obj.GetType() == typeof(Quad3D))
							{
								cParameter2 = new cParameter();
								cParameter2.Name = fieldInfo.Name;
								cParameter2.Value = obj;
								cParameter2.ValueAsString = ((Quad3D)obj).ToDef();
								cParameter2.Field = fieldInfo;
								cParameter2.Types = obj.GetType();
							}
							else if (obj.GetType() == typeof(object))
							{
								cParameter2 = new cParameter();
								cParameter2.Name = fieldInfo.Name;
								cParameter2.Value = obj;
								cParameter2.ValueAsString = "";
								cParameter2.Field = fieldInfo;
								cParameter2.Types = obj.GetType();
							}
							else
							{
								if (type.IsEnum)
								{
									cParameter2 = new cParameter();
									cParameter2.Name = fieldInfo.Name;
									cParameter2.Value = obj;
									cParameter2.ValueAsString = obj.ToString();
									cParameter2.Field = fieldInfo;
									cParameter2.Types = obj.GetType();
								}
								if (fieldInfo.FieldType.BaseType != null && (type.IsClass & ((fieldInfo.FieldType.BaseType.Namespace.IndexOf("buClass") >= 0) | (fieldInfo.FieldType.BaseType.Namespace.IndexOf("buMW") >= 0) | (fieldInfo.FieldType.BaseType.Namespace.IndexOf("buEyeBaseVer5") >= 0) | (fieldInfo.FieldType.Namespace.IndexOf("buClass") >= 0) | (fieldInfo.FieldType.Namespace.IndexOf("buEyeBaseVer5") >= 0))) && UseSubClass)
								{
									cParameter2 = new cParameter();
									List<cParameter> Vars2 = new List<cParameter>();
									GetClassVariables(obj, ref Vars2);
									cParameter2.Name = fieldInfo.Name;
									cParameter2.Value = obj;
									cParameter2.ValueAsString = obj.ToString();
									cParameter2.Field = fieldInfo;
									cParameter2.Types = obj.GetType();
									cParameter2.SubParameter = Vars2;
								}
							}
						}
						else
						{
							if (type.IsArray && UseArray)
							{
								cParameter2 = new cParameter();
								cParameter2.Name = fieldInfo.Name;
								cParameter2.Value = obj;
								cParameter2.ValueAsString = obj.ToString();
								cParameter2.Field = fieldInfo;
								cParameter2.Types = obj.GetType();
							}
							if (((fieldInfo.FieldType.ToString().IndexOf("ArrayList") >= 0) & !type.IsArray) && UseArrayList)
							{
								cParameter2 = new cParameter();
								cParameter2.Name = fieldInfo.Name;
								cParameter2.Value = obj;
								cParameter2.ValueAsString = obj.ToString();
								cParameter2.Field = fieldInfo;
								cParameter2.Types = obj.GetType();
							}
							else if (((fieldInfo.FieldType.ToString().IndexOf("Generic.List") >= 0) & !type.IsArray) && UseList && !fieldInfo.IsStatic)
							{
								cParameter2 = new cParameter();
								cParameter2.Name = fieldInfo.Name;
								cParameter2.Value = obj;
								cParameter2.ValueAsString = obj.ToString();
								cParameter2.Field = fieldInfo;
								cParameter2.Types = obj.GetType();
							}
						}
					}
					if (cParameter2 != null)
					{
						Vars.Add(cParameter2);
					}
				}
			}
			if (array2 == null)
			{
				return;
			}
			for (int j = 0; j <= array2.Length - 1; j++)
			{
				if (j == 26)
				{
				}
				cParameter cParameter3 = null;
				object obj2 = null;
				PropertyInfo propertyInfo = array2[j];
				string name3 = propertyInfo.Name;
				string name4 = propertyInfo.Name;
				if (ObjPar == null)
				{
				}
				obj2 = propertyInfo.GetValue(ObjPar);
				if (obj2 == null)
				{
					NullToValue(ref obj2, propertyInfo);
				}
				if (obj2 != null)
				{
					Type type2 = obj2.GetType();
					if ((propertyInfo.PropertyType.ToString().IndexOf("Generic.List") < 0) & (propertyInfo.PropertyType.ToString().IndexOf("ArrayList") < 0) & !type2.IsArray)
					{
						if (obj2.GetType() == typeof(double))
						{
							cParameter3 = new cParameter();
							cParameter3.Name = propertyInfo.Name;
							cParameter3.Value = obj2;
							cParameter3.ValueAsString = obj2.ToString();
							cParameter3.Property = propertyInfo;
							cParameter3.Types = obj2.GetType();
						}
						else if (obj2.GetType() == typeof(int))
						{
							cParameter3 = new cParameter();
							cParameter3.Name = propertyInfo.Name;
							cParameter3.Value = obj2;
							cParameter3.ValueAsString = obj2.ToString();
							cParameter3.Property = propertyInfo;
							cParameter3.Types = obj2.GetType();
						}
						else if (obj2.GetType() == typeof(float))
						{
							cParameter3 = new cParameter();
							cParameter3.Name = propertyInfo.Name;
							cParameter3.Value = obj2;
							cParameter3.ValueAsString = obj2.ToString();
							cParameter3.Property = propertyInfo;
							cParameter3.Types = obj2.GetType();
						}
						else if (obj2.GetType() == typeof(long))
						{
							cParameter3 = new cParameter();
							cParameter3.Name = propertyInfo.Name;
							cParameter3.Value = obj2;
							cParameter3.ValueAsString = obj2.ToString();
							cParameter3.Property = propertyInfo;
							cParameter3.Types = obj2.GetType();
						}
						else if (obj2.GetType() == typeof(uint))
						{
							cParameter3 = new cParameter();
							cParameter3.Name = propertyInfo.Name;
							cParameter3.Value = obj2;
							cParameter3.ValueAsString = obj2.ToString();
							cParameter3.Property = propertyInfo;
							cParameter3.Types = obj2.GetType();
						}
						else if (obj2.GetType() == typeof(bool))
						{
							cParameter3 = new cParameter();
							cParameter3.Name = propertyInfo.Name;
							cParameter3.Value = obj2;
							cParameter3.ValueAsString = obj2.ToString();
							cParameter3.Property = propertyInfo;
							cParameter3.Types = obj2.GetType();
						}
						else if (obj2.GetType() == typeof(byte))
						{
							cParameter3 = new cParameter();
							cParameter3.Name = propertyInfo.Name;
							cParameter3.Value = obj2;
							cParameter3.ValueAsString = obj2.ToString();
							cParameter3.Property = propertyInfo;
							cParameter3.Types = obj2.GetType();
						}
						else if (obj2.GetType() == typeof(string))
						{
							cParameter3 = new cParameter();
							cParameter3.Name = propertyInfo.Name;
							cParameter3.Value = obj2;
							cParameter3.ValueAsString = obj2.ToString();
							cParameter3.Property = propertyInfo;
							cParameter3.Types = obj2.GetType();
						}
						else if (obj2.GetType() == typeof(Color))
						{
							cParameter3 = new cParameter();
							cParameter3.Name = propertyInfo.Name;
							cParameter3.Value = obj2;
							cParameter3.ValueAsString = buStatics.ColorToString((Color)obj2, ColorConvertType.String);
							cParameter3.Property = propertyInfo;
							cParameter3.Types = obj2.GetType();
						}
						else if (obj2.GetType() == typeof(Font))
						{
							cParameter3 = new cParameter();
							cParameter3.Name = propertyInfo.Name;
							cParameter3.Value = obj2;
							cParameter3.ValueAsString = buStatics.FontToString((Font)obj2);
							cParameter3.Property = propertyInfo;
							cParameter3.Types = obj2.GetType();
						}
						else if (obj2.GetType() == typeof(DateTime))
						{
							cParameter3 = new cParameter();
							cParameter3.Name = propertyInfo.Name;
							cParameter3.Value = obj2;
							cParameter3.ValueAsString = ((DateTime)obj2).ToString();
							cParameter3.Property = propertyInfo;
							cParameter3.Types = obj2.GetType();
						}
						else if (obj2.GetType() == typeof(Size))
						{
							cParameter3 = new cParameter();
							cParameter3.Name = propertyInfo.Name;
							cParameter3.Value = obj2;
							cParameter3.ValueAsString = ((Size)obj2).Width + ";" + ((Size)obj2).Height;
							cParameter3.Property = propertyInfo;
							cParameter3.Types = obj2.GetType();
						}
						else if (obj2.GetType() == typeof(SizeF))
						{
							cParameter3 = new cParameter();
							cParameter3.Name = propertyInfo.Name;
							cParameter3.Value = obj2;
							cParameter3.ValueAsString = ((SizeF)obj2).Width + ";" + ((SizeF)obj2).Height;
							cParameter3.Property = propertyInfo;
							cParameter3.Types = obj2.GetType();
						}
						else if (obj2.GetType() == typeof(Point))
						{
							cParameter3 = new cParameter();
							cParameter3.Name = propertyInfo.Name;
							cParameter3.Value = obj2;
							cParameter3.ValueAsString = ((Point)obj2).X + ";" + ((Point)obj2).Y;
							cParameter3.Property = propertyInfo;
							cParameter3.Types = obj2.GetType();
						}
						else if (obj2.GetType() == typeof(PointF))
						{
							cParameter3 = new cParameter();
							cParameter3.Name = propertyInfo.Name;
							cParameter3.Value = obj2;
							cParameter3.ValueAsString = ((PointF)obj2).X + ";" + ((PointF)obj2).Y;
							cParameter3.Property = propertyInfo;
							cParameter3.Types = obj2.GetType();
						}
						else if (obj2.GetType() == typeof(Pnt2D))
						{
							cParameter3 = new cParameter();
							cParameter3.Name = propertyInfo.Name;
							cParameter3.Value = obj2;
							cParameter3.ValueAsString = ((Pnt2D)obj2).ToDef();
							cParameter3.Property = propertyInfo;
							cParameter3.Types = obj2.GetType();
						}
						else if (obj2.GetType() == typeof(Pnt3D))
						{
							cParameter3 = new cParameter();
							cParameter3.Name = propertyInfo.Name;
							cParameter3.Value = obj2;
							cParameter3.ValueAsString = ((Pnt3D)obj2).ToDef();
							cParameter3.Property = propertyInfo;
							cParameter3.Types = obj2.GetType();
						}
						else if (obj2.GetType() == typeof(Pnt6D))
						{
							cParameter3 = new cParameter();
							cParameter3.Name = propertyInfo.Name;
							cParameter3.Value = obj2;
							cParameter3.ValueAsString = ((Pnt6D)obj2).ToDef();
							cParameter3.Property = propertyInfo;
							cParameter3.Types = obj2.GetType();
						}
						else if (obj2.GetType() == typeof(Pnt9D))
						{
							cParameter3 = new cParameter();
							cParameter3.Name = propertyInfo.Name;
							cParameter3.Value = obj2;
							cParameter3.ValueAsString = ((Pnt9D)obj2).ToDef();
							cParameter3.Property = propertyInfo;
							cParameter3.Types = obj2.GetType();
						}
						else if (obj2.GetType() == typeof(Vec3D))
						{
							cParameter3 = new cParameter();
							cParameter3.Name = propertyInfo.Name;
							cParameter3.Value = obj2;
							cParameter3.ValueAsString = ((Vec3D)obj2).ToDef();
							cParameter3.Property = propertyInfo;
							cParameter3.Types = obj2.GetType();
						}
						else if (obj2.GetType() == typeof(Length3D))
						{
							cParameter3 = new cParameter();
							cParameter3.Name = propertyInfo.Name;
							cParameter3.Value = obj2;
							cParameter3.ValueAsString = ((Length3D)obj2).ToDef();
							cParameter3.Property = propertyInfo;
							cParameter3.Types = obj2.GetType();
						}
						else if (obj2.GetType() == typeof(OrientationAngle))
						{
							cParameter3 = new cParameter();
							cParameter3.Name = propertyInfo.Name;
							cParameter3.Value = obj2;
							cParameter3.ValueAsString = ((OrientationAngle)obj2).ToDef();
							cParameter3.Property = propertyInfo;
							cParameter3.Types = obj2.GetType();
						}
						else if (obj2.GetType() == typeof(Line3D))
						{
							cParameter3 = new cParameter();
							cParameter3.Name = propertyInfo.Name;
							cParameter3.Value = obj2;
							cParameter3.ValueAsString = ((Line3D)obj2).ToDef();
							cParameter3.Property = propertyInfo;
							cParameter3.Types = obj2.GetType();
						}
						else if (obj2.GetType() == typeof(Triangle3D))
						{
							cParameter3 = new cParameter();
							cParameter3.Name = propertyInfo.Name;
							cParameter3.Value = obj2;
							cParameter3.ValueAsString = ((Triangle3D)obj2).ToDef();
							cParameter3.Property = propertyInfo;
							cParameter3.Types = obj2.GetType();
						}
						else if (obj2.GetType() == typeof(Quad3D))
						{
							cParameter3 = new cParameter();
							cParameter3.Name = propertyInfo.Name;
							cParameter3.Value = obj2;
							cParameter3.ValueAsString = ((Quad3D)obj2).ToDef();
							cParameter3.Property = propertyInfo;
							cParameter3.Types = obj2.GetType();
						}
						else if (obj2.GetType() == typeof(object))
						{
							cParameter3 = new cParameter();
							cParameter3.Name = propertyInfo.Name;
							cParameter3.Value = obj2;
							cParameter3.ValueAsString = "";
							cParameter3.Property = propertyInfo;
							cParameter3.Types = obj2.GetType();
						}
						else
						{
							if (type2.IsEnum)
							{
								cParameter3 = new cParameter();
								cParameter3.Name = propertyInfo.Name;
								cParameter3.Value = obj2;
								cParameter3.ValueAsString = obj2.ToString();
								cParameter3.Property = propertyInfo;
								cParameter3.Types = obj2.GetType();
							}
							if (propertyInfo.PropertyType.BaseType != null && (type2.IsClass & ((propertyInfo.PropertyType.BaseType.Namespace.IndexOf("buClass") >= 0) | (propertyInfo.PropertyType.BaseType.Namespace.IndexOf("buMW") >= 0) | (propertyInfo.PropertyType.BaseType.Namespace.IndexOf("buEyeBaseVer5") >= 0) | (propertyInfo.PropertyType.Namespace.IndexOf("buClass") >= 0) | (propertyInfo.PropertyType.Namespace.IndexOf("buControls") >= 0) | (propertyInfo.PropertyType.Namespace.IndexOf("buEyeBaseVer5") >= 0))) && UseSubClass)
							{
								cParameter3 = new cParameter();
								List<cParameter> Vars3 = new List<cParameter>();
								GetClassVariables(obj2, ref Vars3);
								cParameter3.Name = propertyInfo.Name;
								cParameter3.Value = obj2;
								cParameter3.ValueAsString = obj2.ToString();
								cParameter3.Property = propertyInfo;
								cParameter3.Types = obj2.GetType();
								cParameter3.SubParameter = Vars3;
							}
						}
					}
					else
					{
						if (type2.IsArray && UseArray)
						{
							cParameter3 = new cParameter();
							cParameter3.Name = propertyInfo.Name;
							cParameter3.Value = obj2;
							cParameter3.ValueAsString = obj2.ToString();
							cParameter3.Property = propertyInfo;
							cParameter3.Types = obj2.GetType();
						}
						if (((propertyInfo.PropertyType.ToString().IndexOf("ArrayList") >= 0) & !type2.IsArray) && UseArrayList)
						{
							cParameter3 = new cParameter();
							cParameter3.Name = propertyInfo.Name;
							cParameter3.Value = obj2;
							cParameter3.ValueAsString = obj2.ToString();
							cParameter3.Property = propertyInfo;
							cParameter3.Types = obj2.GetType();
						}
						else if (((propertyInfo.PropertyType.ToString().IndexOf("Generic.List") >= 0) & !type2.IsArray) && UseList)
						{
							cParameter3 = new cParameter();
							cParameter3.Name = propertyInfo.Name;
							cParameter3.Value = obj2;
							cParameter3.ValueAsString = obj2.ToString();
							cParameter3.Property = propertyInfo;
							cParameter3.Types = obj2.GetType();
						}
					}
				}
				if (cParameter3 != null)
				{
					Vars.Add(cParameter3);
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
			int num2 = 0;
			Obj = num2;
		}
		if (field.FieldType == typeof(float))
		{
			float num3 = 0f;
			Obj = num3;
		}
		if (field.FieldType == typeof(long))
		{
			long num4 = 0L;
			Obj = num4;
		}
		if (field.FieldType == typeof(uint))
		{
			uint num5 = 0u;
			Obj = num5;
		}
		if (field.FieldType == typeof(bool))
		{
			bool flag = false;
			Obj = flag;
		}
		if (field.FieldType == typeof(byte))
		{
			byte b = 0;
			Obj = b;
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

	public static void NullToValue(ref object Obj, PropertyInfo field)
	{
		if (field.PropertyType == typeof(double))
		{
			double num = 0.0;
			Obj = num;
		}
		if (field.PropertyType == typeof(int))
		{
			int num2 = 0;
			Obj = num2;
		}
		if (field.PropertyType == typeof(float))
		{
			float num3 = 0f;
			Obj = num3;
		}
		if (field.PropertyType == typeof(long))
		{
			long num4 = 0L;
			Obj = num4;
		}
		if (field.PropertyType == typeof(uint))
		{
			uint num5 = 0u;
			Obj = num5;
		}
		if (field.PropertyType == typeof(bool))
		{
			bool flag = false;
			Obj = flag;
		}
		if (field.PropertyType == typeof(byte))
		{
			byte b = 0;
			Obj = b;
		}
		if (field.PropertyType == typeof(string))
		{
			string text = "";
			Obj = text;
		}
		if (field.PropertyType == typeof(Color))
		{
			Color white = Color.White;
			Obj = white;
		}
		if (field.PropertyType == typeof(Font))
		{
			Font font = new Font("Arial", 10f);
			Obj = font;
		}
		if (field.PropertyType == typeof(DateTime))
		{
			Obj = default(DateTime);
		}
		if (field.PropertyType == typeof(Size))
		{
			Obj = default(Size);
		}
		if (field.PropertyType == typeof(SizeF))
		{
			Obj = default(SizeF);
		}
		if (field.PropertyType == typeof(Point))
		{
			Obj = default(Point);
		}
		if (field.PropertyType == typeof(PointF))
		{
			Obj = default(PointF);
		}
		if (field.PropertyType == typeof(Pnt2D))
		{
			Pnt2D pnt2D = new Pnt2D();
			Obj = pnt2D;
		}
		if (field.PropertyType == typeof(Pnt3D))
		{
			Pnt3D pnt3D = new Pnt3D();
			Obj = pnt3D;
		}
		if (field.PropertyType == typeof(Pnt6D))
		{
			Pnt6D pnt6D = new Pnt6D();
			Obj = pnt6D;
		}
		if (field.PropertyType == typeof(Pnt9D))
		{
			Pnt9D pnt9D = new Pnt9D();
			Obj = pnt9D;
		}
		if (field.PropertyType == typeof(Vec3D))
		{
			Vec3D vec3D = new Vec3D();
			Obj = vec3D;
		}
		if (field.PropertyType == typeof(Length3D))
		{
			Length3D length3D = new Length3D();
			Obj = length3D;
		}
		if (field.PropertyType == typeof(OrientationAngle))
		{
			OrientationAngle orientationAngle = new OrientationAngle();
			Obj = orientationAngle;
		}
		if (field.PropertyType == typeof(Line3D))
		{
			Line3D line3D = new Line3D();
			Obj = line3D;
		}
		if (field.PropertyType == typeof(Triangle3D))
		{
			Triangle3D triangle3D = new Triangle3D();
			Obj = triangle3D;
		}
		if (field.PropertyType == typeof(Quad3D))
		{
			Quad3D quad3D = new Quad3D();
			Obj = quad3D;
		}
	}

	public static void SetClassVariable(ref object ObjPar, cParameter Var)
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
				object Obj = null;
				FieldInfo FI = array[i];
				string name = FI.Name;
				string name2 = FI.Name;
				Type fieldType = FI.FieldType;
				if ((FI.FieldType.ToString().IndexOf("List") < 0) & !fieldType.IsArray)
				{
					if (FI.Name == Var.Name)
					{
						Obj = Var.Value;
						if ((((fieldType.Namespace == "buClass") | (fieldType.BaseType.Namespace == "buClass") | (fieldType.Namespace == "buEyeBaseVer5") | (fieldType.BaseType.Namespace == "buEyeBaseVer5") | (fieldType.Namespace == "buMW") | (fieldType.BaseType.Namespace == "buMW")) & !fieldType.IsEnum & fieldType.IsClass) && (List<cParameter>)Var.SubParameter != null)
						{
							SetClassVariables(ref Obj, (List<cParameter>)Var.SubParameter);
							FI.SetValue(ObjPar, Obj);
						}
						if (Obj != null)
						{
							SetObjectValueByType(ref FI, ref ObjPar, Obj);
						}
					}
				}
				else if ((FI.FieldType.ToString().IndexOf("ArrayList") >= 0) & !fieldType.IsArray)
				{
					if (FI.Name == Var.Name)
					{
						ValueToSetClassArrayList(ref Obj, Var.Value);
						Obj = Var.Value;
						if (Obj != null)
						{
							SetObjectValueByType(ref FI, ref ObjPar, Obj);
						}
					}
				}
				else if ((FI.FieldType.ToString().IndexOf("Generic.List") >= 0) & !fieldType.IsArray)
				{
					if (FI.Name == Var.Name)
					{
						ValueToSetClassList(ref Obj, Var.Value);
						Obj = Var.Value;
						if (Obj != null)
						{
							SetObjectValueByType(ref FI, ref ObjPar, Obj);
						}
					}
				}
				else if (fieldType.IsArray && FI.Name == Var.Name)
				{
					ValueToSetClassArray(ref Obj, Var.Value);
					Obj = Var.Value;
					if (Obj != null)
					{
						SetObjectValueByType(ref FI, ref ObjPar, Obj);
					}
				}
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public static void SetClassVariables(ref object ObjPar, List<cParameter> Vars)
	{
		try
		{
			FieldInfo[] array = null;
			PropertyInfo[] array2 = null;
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
				if (i == 121)
				{
				}
				object Obj = null;
				FieldInfo FI = array[i];
				string name = FI.Name;
				string name2 = FI.Name;
				Type fieldType = FI.FieldType;
				if ((FI.FieldType.ToString().IndexOf("List") < 0) & !fieldType.IsArray)
				{
					for (int j = 0; j <= Vars.Count - 1; j++)
					{
						if (FI.Name == Vars[j].Name.ToString())
						{
							Obj = Vars[j].Value;
							j = Vars.Count + 1;
						}
					}
					if (fieldType.BaseType != null)
					{
						if ((((fieldType.Namespace == "buClass") | (fieldType.BaseType.Namespace == "buClass") | (fieldType.Namespace == "buEyeBaseVer5") | (fieldType.BaseType.Namespace == "buEyeBaseVer5") | (fieldType.Namespace == "buMW") | (fieldType.BaseType.Namespace == "buMW")) & !fieldType.IsEnum & fieldType.IsClass) && i <= Vars.Count - 1 && (List<cParameter>)Vars[i].SubParameter != null)
						{
							SetClassVariables(ref Obj, (List<cParameter>)Vars[i].SubParameter);
							FI.SetValue(ObjPar, Obj);
						}
					}
					else if ((((fieldType.Namespace == "buClass") | (fieldType.Namespace == "buEyeBaseVer5") | (fieldType.Namespace == "buMW")) & !fieldType.IsEnum & fieldType.IsClass) && i <= Vars.Count - 1 && (List<cParameter>)Vars[i].SubParameter != null)
					{
						SetClassVariables(ref Obj, (List<cParameter>)Vars[i].SubParameter);
						FI.SetValue(ObjPar, Obj);
					}
					if (Obj != null)
					{
						SetObjectValueByType(ref FI, ref ObjPar, Obj);
					}
				}
				else if ((FI.FieldType.ToString().IndexOf("ArrayList") >= 0) & !fieldType.IsArray)
				{
					for (int k = 0; k <= Vars.Count - 1; k++)
					{
						if (FI.Name == Vars[k].Name)
						{
							ValueToSetClassArrayList(ref Obj, Vars[k].Value);
							Obj = Vars[k].Value;
							k = Vars.Count + 1;
						}
					}
					if (Obj != null)
					{
						SetObjectValueByType(ref FI, ref ObjPar, Obj);
					}
				}
				else if ((FI.FieldType.ToString().IndexOf("Generic.List") >= 0) & !fieldType.IsArray)
				{
					string[] array3 = FI.FieldType.ToString().Split(new string[1] { "Generic.List" }, StringSplitOptions.None);
					ArrayList arrayList = new ArrayList();
					List<cParameter> list = new List<cParameter>();
					if (!((array3.Length == 2) | (array3.Length == 3)))
					{
						continue;
					}
					for (int l = 0; l <= Vars.Count - 1; l++)
					{
						if (FI.Name == Vars[l].Name)
						{
							ValueToSetClassList(ref Obj, Vars[l].Value);
							Obj = Vars[l].Value;
							l = Vars.Count + 1;
						}
					}
					if (Obj != null)
					{
						SetObjectValueByType(ref FI, ref ObjPar, Obj);
					}
				}
				else
				{
					if (!fieldType.IsArray)
					{
						continue;
					}
					for (int m = 0; m <= Vars.Count - 1; m++)
					{
						if (FI.Name == Vars[m].Name)
						{
							ValueToSetClassArray(ref Obj, Vars[m].Value);
							Obj = Vars[m].Value;
							m = Vars.Count + 1;
						}
					}
					if (Obj != null)
					{
						SetObjectValueByType(ref FI, ref ObjPar, Obj);
					}
				}
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public static void SetClassPropertyVariables(ref object ObjPar, List<cParameter> Vars)
	{
		try
		{
			PropertyInfo[] array = null;
			if (ObjPar == null)
			{
				return;
			}
			array = ObjPar.GetType().GetProperties();
			if (array == null)
			{
				return;
			}
			for (int i = 0; i <= array.Length - 1; i++)
			{
				if (i == 121)
				{
				}
				object Obj = null;
				PropertyInfo PI = array[i];
				string name = PI.Name;
				string name2 = PI.Name;
				Type propertyType = PI.PropertyType;
				if ((PI.PropertyType.ToString().IndexOf("List") < 0) & !propertyType.IsArray)
				{
					for (int j = 0; j <= Vars.Count - 1; j++)
					{
						if (PI.Name == Vars[j].Name.ToString())
						{
							Obj = Vars[j].Value;
							j = Vars.Count + 1;
						}
					}
					if (propertyType.BaseType != null)
					{
						if ((((propertyType.Namespace == "buClass") | (propertyType.BaseType.Namespace == "buClass") | (propertyType.Namespace == "buEyeBaseVer5") | (propertyType.BaseType.Namespace == "buEyeBaseVer5") | (propertyType.Namespace == "buMW") | (propertyType.BaseType.Namespace == "buMW")) & !propertyType.IsEnum & propertyType.IsClass) && i <= Vars.Count - 1 && (List<cParameter>)Vars[i].SubParameter != null)
						{
							SetClassPropertyVariables(ref Obj, (List<cParameter>)Vars[i].SubParameter);
							PI.SetValue(ObjPar, Obj);
						}
					}
					else if ((((propertyType.Namespace == "buClass") | (propertyType.Namespace == "buEyeBaseVer5") | (propertyType.Namespace == "buMW")) & !propertyType.IsEnum & propertyType.IsClass) && i <= Vars.Count - 1 && (List<cParameter>)Vars[i].SubParameter != null)
					{
						SetClassPropertyVariables(ref Obj, (List<cParameter>)Vars[i].SubParameter);
						PI.SetValue(ObjPar, Obj);
					}
					if (Obj != null)
					{
						SetObjectValueByType(ref PI, ref ObjPar, Obj);
					}
				}
				else if ((PI.PropertyType.ToString().IndexOf("ArrayList") >= 0) & !propertyType.IsArray)
				{
					for (int k = 0; k <= Vars.Count - 1; k++)
					{
						if (PI.Name == Vars[k].Name)
						{
							ValueToSetClassArrayList(ref Obj, Vars[k].Value);
							Obj = Vars[k].Value;
							k = Vars.Count + 1;
						}
					}
					if (Obj != null)
					{
						SetObjectValueByType(ref PI, ref ObjPar, Obj);
					}
				}
				else if ((PI.PropertyType.ToString().IndexOf("Generic.List") >= 0) & !propertyType.IsArray)
				{
					string[] array2 = PI.PropertyType.ToString().Split(new string[1] { "Generic.List" }, StringSplitOptions.None);
					ArrayList arrayList = new ArrayList();
					List<cParameter> list = new List<cParameter>();
					if (!((array2.Length == 2) | (array2.Length == 3)))
					{
						continue;
					}
					for (int l = 0; l <= Vars.Count - 1; l++)
					{
						if (PI.Name == Vars[l].Name)
						{
							ValueToSetClassList(ref Obj, Vars[l].Value);
							Obj = Vars[l].Value;
							l = Vars.Count + 1;
						}
					}
					if (Obj != null)
					{
						SetObjectValueByType(ref PI, ref ObjPar, Obj);
					}
				}
				else
				{
					if (!propertyType.IsArray)
					{
						continue;
					}
					for (int m = 0; m <= Vars.Count - 1; m++)
					{
						if (PI.Name == Vars[m].Name)
						{
							ValueToSetClassArray(ref Obj, Vars[m].Value);
							Obj = Vars[m].Value;
							m = Vars.Count + 1;
						}
					}
					if (Obj != null)
					{
						SetObjectValueByType(ref PI, ref ObjPar, Obj);
					}
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
			List<cParameter> Vars = new List<cParameter>();
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
				if ((Value.ToString().ToLower() == "false") | (Value.ToString().ToLower() == "true"))
				{
					string value = Value.ToString();
					if (bool.TryParse(value, out result6))
					{
						FI.SetValue(Obj, result6);
					}
				}
				else
				{
					string value2 = "true";
					if (Value.ToString() == "0")
					{
						value2 = "false";
					}
					if (bool.TryParse(value2, out result6))
					{
						FI.SetValue(Obj, result6);
					}
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
				FontConverter fontConverter = new FontConverter();
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
				pnt3D = Pnt3D.DecodeFromString(((Pnt3D)Value).ToDef());
				FI.SetValue(Obj, pnt3D);
			}
			if (FI.FieldType == typeof(Pnt6D))
			{
				Pnt6D pnt6D = new Pnt6D();
				pnt6D = Pnt6D.DecodeFromString(((Pnt6D)Value).ToDef());
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
				vec3D = Vec3D.DecodeFromString(((Vec3D)Value).ToDef());
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
				OrientationAngle orientationAngle = new OrientationAngle();
				orientationAngle = OrientationAngle.DecodeFromString(((OrientationAngle)Value).ToDef());
				FI.SetValue(Obj, orientationAngle);
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
			if (FI.FieldType == typeof(List<Pnt6D>))
			{
				List<Pnt6D> list8 = new List<Pnt6D>();
				if (Value.GetType() == typeof(List<Pnt6D>))
				{
					list8.AddRange(((List<Pnt6D>)Value).ToArray());
				}
				FI.SetValue(Obj, list8);
			}
			if (FI.FieldType == typeof(List<Pnt9D>))
			{
				List<Pnt9D> list9 = new List<Pnt9D>();
				if (Value.GetType() == typeof(List<Pnt9D>))
				{
					list9.AddRange(((List<Pnt9D>)Value).ToArray());
				}
				FI.SetValue(Obj, list9);
			}
			if (FI.FieldType == typeof(List<Vec3D>))
			{
				List<Vec3D> list10 = new List<Vec3D>();
				if (Value.GetType() == typeof(List<Vec3D>))
				{
					list10.AddRange(((List<Vec3D>)Value).ToArray());
				}
				FI.SetValue(Obj, list10);
			}
			if (FI.FieldType == typeof(List<OrientationAngle>))
			{
				List<OrientationAngle> list11 = new List<OrientationAngle>();
				if (Value.GetType() == typeof(List<OrientationAngle>))
				{
					list11.AddRange(((List<OrientationAngle>)Value).ToArray());
				}
				FI.SetValue(Obj, list11);
			}
			if (FI.FieldType == typeof(List<Line3D>))
			{
				List<Line3D> list12 = new List<Line3D>();
				if (Value.GetType() == typeof(List<Line3D>))
				{
					list12.AddRange(((List<Line3D>)Value).ToArray());
				}
				FI.SetValue(Obj, list12);
			}
			if (FI.FieldType == typeof(List<Triangle3D>))
			{
				List<Triangle3D> list13 = new List<Triangle3D>();
				if (Value.GetType() == typeof(List<Triangle3D>))
				{
					list13.AddRange(((List<Triangle3D>)Value).ToArray());
				}
				FI.SetValue(Obj, list13);
			}
			if (FI.FieldType == typeof(List<Quad3D>))
			{
				List<Quad3D> list14 = new List<Quad3D>();
				if (Value.GetType() == typeof(List<Quad3D>))
				{
					list14.AddRange(((List<Quad3D>)Value).ToArray());
				}
				FI.SetValue(Obj, list14);
			}
			if (FI.FieldType == typeof(List<List<Pnt3D>>))
			{
				List<List<Pnt3D>> list15 = new List<List<Pnt3D>>();
				if (Value.GetType() == typeof(List<List<Pnt3D>>))
				{
					for (int i = 0; i <= ((List<List<Pnt3D>>)Value).Count - 1; i++)
					{
						List<Pnt3D> list16 = new List<Pnt3D>();
						list16.AddRange(((List<List<Pnt3D>>)Value)[i].ToArray());
						list15.Add(list16);
					}
					FI.SetValue(Obj, list15);
				}
			}
			if (FI.FieldType == typeof(double[]))
			{
				try
				{
					double[] array = new double[((double[])Value).Length];
					if (Value.GetType() == typeof(double[]))
					{
						for (int j = 0; j <= ((double[])Value).Length - 1; j++)
						{
							array[j] = ((double[])Value)[j];
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
						for (int k = 0; k <= ((float[])Value).Length - 1; k++)
						{
							array2[k] = ((float[])Value)[k];
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
						for (int l = 0; l <= ((int[])Value).Length - 1; l++)
						{
							array3[l] = ((int[])Value)[l];
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
						for (int m = 0; m <= ((bool[])Value).Length - 1; m++)
						{
							array4[m] = ((bool[])Value)[m];
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
						for (int n = 0; n <= ((string[])Value).Length - 1; n++)
						{
							array5[n] = ((string[])Value)[n];
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
						for (int num = 0; num <= ((Pnt2D[])Value).Length - 1; num++)
						{
							array6[num] = ((Pnt2D[])Value)[num];
						}
					}
					FI.SetValue(Obj, array6);
				}
				catch (Exception)
				{
				}
			}
			if (FI.FieldType == typeof(Pnt3D[]))
			{
				try
				{
					Pnt3D[] array7 = new Pnt3D[((Pnt3D[])Value).Length];
					if (Value.GetType() == typeof(Pnt3D[]))
					{
						for (int num2 = 0; num2 <= ((Pnt3D[])Value).Length - 1; num2++)
						{
							array7[num2] = ((Pnt3D[])Value)[num2];
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
						for (int num3 = 0; num3 <= ((Pnt6D[])Value).Length - 1; num3++)
						{
							array8[num3] = ((Pnt6D[])Value)[num3];
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
						for (int num4 = 0; num4 <= ((Pnt9D[])Value).Length - 1; num4++)
						{
							array9[num4] = ((Pnt9D[])Value)[num4];
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
						for (int num5 = 0; num5 <= ((Vec3D[])Value).Length - 1; num5++)
						{
							array10[num5] = ((Vec3D[])Value)[num5];
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
						for (int num6 = 0; num6 <= ((OrientationAngle[])Value).Length - 1; num6++)
						{
							array11[num6] = ((OrientationAngle[])Value)[num6];
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
						for (int num7 = 0; num7 <= ((Line3D[])Value).Length - 1; num7++)
						{
							array12[num7] = ((Line3D[])Value)[num7];
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
						for (int num8 = 0; num8 <= ((Triangle3D[])Value).Length - 1; num8++)
						{
							array13[num8] = ((Triangle3D[])Value)[num8];
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
					for (int num9 = 0; num9 <= ((Quad3D[])Value).Length - 1; num9++)
					{
						array14[num9] = ((Quad3D[])Value)[num9];
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

	public static void SetObjectValueByType(ref PropertyInfo PI, ref object Obj, object Value)
	{
		try
		{
			if (!(PI != null))
			{
				return;
			}
			if (PI.PropertyType == typeof(double))
			{
				double result = 0.0;
				if (double.TryParse(Value.ToString(), out result))
				{
					PI.SetValue(Obj, result);
				}
			}
			if (PI.PropertyType == typeof(float))
			{
				float result2 = 0f;
				if (float.TryParse(Value.ToString(), out result2))
				{
					PI.SetValue(Obj, result2);
				}
			}
			if (PI.PropertyType == typeof(int))
			{
				int result3 = 0;
				if (int.TryParse(Value.ToString(), out result3))
				{
					PI.SetValue(Obj, result3);
				}
			}
			if (PI.PropertyType == typeof(long))
			{
				long result4 = 0L;
				if (long.TryParse(Value.ToString(), out result4))
				{
					PI.SetValue(Obj, result4);
				}
			}
			if (PI.PropertyType == typeof(uint))
			{
				uint result5 = 0u;
				if (uint.TryParse(Value.ToString(), out result5))
				{
					PI.SetValue(Obj, result5);
				}
			}
			if (PI.PropertyType == typeof(bool))
			{
				bool result6 = false;
				if ((Value.ToString().ToLower() == "false") | (Value.ToString().ToLower() == "true"))
				{
					string value = Value.ToString();
					if (bool.TryParse(value, out result6))
					{
						PI.SetValue(Obj, result6);
					}
				}
				else
				{
					string value2 = "true";
					if (Value.ToString() == "0")
					{
						value2 = "false";
					}
					if (bool.TryParse(value2, out result6))
					{
						PI.SetValue(Obj, result6);
					}
				}
			}
			if (PI.PropertyType == typeof(short))
			{
				short result7 = 0;
				if (short.TryParse(Value.ToString(), out result7))
				{
					PI.SetValue(Obj, result7);
				}
			}
			if (PI.PropertyType == typeof(string))
			{
				PI.SetValue(Obj, Value.ToString());
			}
			if (PI.PropertyType == typeof(long))
			{
				long result8 = 0L;
				if (long.TryParse(Value.ToString(), out result8))
				{
					PI.SetValue(Obj, result8);
				}
			}
			if (PI.PropertyType == typeof(uint))
			{
				uint result9 = 0u;
				if (uint.TryParse(Value.ToString(), out result9))
				{
					PI.SetValue(Obj, result9);
				}
			}
			if (PI.PropertyType == typeof(byte))
			{
				byte result10 = 0;
				if (byte.TryParse(Value.ToString(), out result10))
				{
					PI.SetValue(Obj, result10);
				}
			}
			if (PI.PropertyType == typeof(Size))
			{
				if (Value.GetType() == typeof(string))
				{
					PI.SetValue(Obj, buStatics.StringToSize(Value.ToString()));
				}
				if (Value.GetType() == typeof(Size))
				{
					PI.SetValue(Obj, Value);
				}
			}
			if (PI.PropertyType == typeof(SizeF))
			{
				if (Value.GetType() == typeof(string))
				{
					PI.SetValue(Obj, buStatics.StringToSizeF(Value.ToString()));
				}
				if (Value.GetType() == typeof(SizeF))
				{
					PI.SetValue(Obj, Value);
				}
			}
			if (PI.PropertyType == typeof(Point))
			{
				if (Value.GetType() == typeof(string))
				{
					PI.SetValue(Obj, buStatics.StringToPoint(Value.ToString()));
				}
				if (Value.GetType() == typeof(Point))
				{
					PI.SetValue(Obj, Value);
				}
			}
			if (PI.PropertyType == typeof(PointF))
			{
				if (Value.GetType() == typeof(string))
				{
					PI.SetValue(Obj, buStatics.StringToPointF(Value.ToString()));
				}
				if (Value.GetType() == typeof(PointF))
				{
					PI.SetValue(Obj, Value);
				}
			}
			if (PI.PropertyType.BaseType == typeof(Enum))
			{
				EnumConverter enumConverter = new EnumConverter(PI.PropertyType);
				PI.SetValue(Obj, enumConverter.ConvertFromString(Value.ToString()));
			}
			if (PI.PropertyType == typeof(Color))
			{
				PI.SetValue(Obj, buStatics.StringToColor(Value.ToString(), ColorConvertType.String));
			}
			if (PI.PropertyType == typeof(Font))
			{
				FontConverter fontConverter = new FontConverter();
				if (Value.GetType() == typeof(string))
				{
					PI.SetValue(Obj, buStatics.StringToFont(Value.ToString()));
				}
				if (Value.GetType() == typeof(Font))
				{
					PI.SetValue(Obj, Value);
				}
			}
			if (PI.PropertyType == typeof(DateTime))
			{
				PI.SetValue(Obj, buStatics.StringToDateTime(Value.ToString()));
			}
			if (PI.PropertyType == typeof(Pnt2D))
			{
				Pnt2D pnt2D = new Pnt2D();
				pnt2D = Pnt2D.DecodeFromString(((Pnt2D)Value).ToDef());
				PI.SetValue(Obj, pnt2D);
			}
			if (PI.PropertyType == typeof(Pnt3D))
			{
				Pnt3D pnt3D = new Pnt3D();
				pnt3D = Pnt3D.DecodeFromString(((Pnt3D)Value).ToDef());
				PI.SetValue(Obj, pnt3D);
			}
			if (PI.PropertyType == typeof(Pnt6D))
			{
				Pnt6D pnt6D = new Pnt6D();
				pnt6D = Pnt6D.DecodeFromString(((Pnt6D)Value).ToDef());
				PI.SetValue(Obj, pnt6D);
			}
			if (PI.PropertyType == typeof(Pnt9D))
			{
				Pnt9D pnt9D = new Pnt9D();
				pnt9D = Pnt9D.DecodeFromString(((Pnt9D)Value).ToDef());
				PI.SetValue(Obj, pnt9D);
			}
			if (PI.PropertyType == typeof(Vec3D))
			{
				Vec3D vec3D = new Vec3D();
				vec3D = Vec3D.DecodeFromString(((Vec3D)Value).ToDef());
				PI.SetValue(Obj, vec3D);
			}
			if (PI.PropertyType == typeof(Length3D))
			{
				Length3D length3D = new Length3D();
				length3D = Length3D.DecodeFromString(((Length3D)Value).ToDef());
				PI.SetValue(Obj, length3D);
			}
			if (PI.PropertyType == typeof(OrientationAngle))
			{
				OrientationAngle orientationAngle = new OrientationAngle();
				orientationAngle = OrientationAngle.DecodeFromString(((OrientationAngle)Value).ToDef());
				PI.SetValue(Obj, orientationAngle);
			}
			if (PI.PropertyType == typeof(Line3D))
			{
				Line3D line3D = new Line3D();
				line3D = Line3D.DecodeFromString(((Line3D)Value).ToDef());
				PI.SetValue(Obj, line3D);
			}
			if (PI.PropertyType == typeof(Triangle3D))
			{
				Triangle3D triangle3D = new Triangle3D();
				triangle3D = Triangle3D.DecodeFromString(((Triangle3D)Value).ToDef());
				PI.SetValue(Obj, triangle3D);
			}
			if (PI.PropertyType == typeof(Quad3D))
			{
				Quad3D quad3D = new Quad3D();
				quad3D = Quad3D.DecodeFromString(((Quad3D)Value).ToDef());
				PI.SetValue(Obj, quad3D);
			}
			if (PI.PropertyType == typeof(object))
			{
				object obj = new object();
				obj = Value;
				PI.SetValue(Obj, obj);
			}
			if (PI.PropertyType == typeof(ArrayList))
			{
				ArrayList arrayList = new ArrayList();
				if (Value.GetType() == typeof(ArrayList))
				{
					arrayList.AddRange(((ArrayList)Value).ToArray());
				}
				PI.SetValue(Obj, arrayList);
			}
			if (PI.PropertyType == typeof(List<double>))
			{
				List<double> list = new List<double>();
				if (Value.GetType() == typeof(List<double>))
				{
					list.AddRange(((List<double>)Value).ToArray());
				}
				PI.SetValue(Obj, list);
			}
			if (PI.PropertyType == typeof(List<int>))
			{
				List<int> list2 = new List<int>();
				if (Value.GetType() == typeof(List<int>))
				{
					list2.AddRange(((List<int>)Value).ToArray());
				}
				PI.SetValue(Obj, list2);
			}
			if (PI.PropertyType == typeof(List<float>))
			{
				List<float> list3 = new List<float>();
				if (Value.GetType() == typeof(List<float>))
				{
					list3.AddRange(((List<float>)Value).ToArray());
				}
				PI.SetValue(Obj, list3);
			}
			if (PI.PropertyType == typeof(List<bool>))
			{
				List<bool> list4 = new List<bool>();
				if (Value.GetType() == typeof(List<bool>))
				{
					list4.AddRange(((List<bool>)Value).ToArray());
				}
				PI.SetValue(Obj, list4);
			}
			if (PI.PropertyType == typeof(List<string>))
			{
				List<string> list5 = new List<string>();
				if (Value.GetType() == typeof(List<string>))
				{
					list5.AddRange(((List<string>)Value).ToArray());
				}
				PI.SetValue(Obj, list5);
			}
			if (PI.PropertyType == typeof(List<Pnt2D>))
			{
				List<Pnt2D> list6 = new List<Pnt2D>();
				if (Value.GetType() == typeof(List<Pnt2D>))
				{
					list6.AddRange(((List<Pnt2D>)Value).ToArray());
				}
				PI.SetValue(Obj, list6);
			}
			if (PI.PropertyType == typeof(List<Pnt3D>))
			{
				List<Pnt3D> list7 = new List<Pnt3D>();
				if (Value.GetType() == typeof(List<Pnt3D>))
				{
					list7.AddRange(((List<Pnt3D>)Value).ToArray());
				}
				PI.SetValue(Obj, list7);
			}
			if (PI.PropertyType == typeof(List<Pnt6D>))
			{
				List<Pnt6D> list8 = new List<Pnt6D>();
				if (Value.GetType() == typeof(List<Pnt6D>))
				{
					list8.AddRange(((List<Pnt6D>)Value).ToArray());
				}
				PI.SetValue(Obj, list8);
			}
			if (PI.PropertyType == typeof(List<Pnt9D>))
			{
				List<Pnt9D> list9 = new List<Pnt9D>();
				if (Value.GetType() == typeof(List<Pnt9D>))
				{
					list9.AddRange(((List<Pnt9D>)Value).ToArray());
				}
				PI.SetValue(Obj, list9);
			}
			if (PI.PropertyType == typeof(List<Vec3D>))
			{
				List<Vec3D> list10 = new List<Vec3D>();
				if (Value.GetType() == typeof(List<Vec3D>))
				{
					list10.AddRange(((List<Vec3D>)Value).ToArray());
				}
				PI.SetValue(Obj, list10);
			}
			if (PI.PropertyType == typeof(List<OrientationAngle>))
			{
				List<OrientationAngle> list11 = new List<OrientationAngle>();
				if (Value.GetType() == typeof(List<OrientationAngle>))
				{
					list11.AddRange(((List<OrientationAngle>)Value).ToArray());
				}
				PI.SetValue(Obj, list11);
			}
			if (PI.PropertyType == typeof(List<Line3D>))
			{
				List<Line3D> list12 = new List<Line3D>();
				if (Value.GetType() == typeof(List<Line3D>))
				{
					list12.AddRange(((List<Line3D>)Value).ToArray());
				}
				PI.SetValue(Obj, list12);
			}
			if (PI.PropertyType == typeof(List<Triangle3D>))
			{
				List<Triangle3D> list13 = new List<Triangle3D>();
				if (Value.GetType() == typeof(List<Triangle3D>))
				{
					list13.AddRange(((List<Triangle3D>)Value).ToArray());
				}
				PI.SetValue(Obj, list13);
			}
			if (PI.PropertyType == typeof(List<Quad3D>))
			{
				List<Quad3D> list14 = new List<Quad3D>();
				if (Value.GetType() == typeof(List<Quad3D>))
				{
					list14.AddRange(((List<Quad3D>)Value).ToArray());
				}
				PI.SetValue(Obj, list14);
			}
			if (PI.PropertyType == typeof(List<List<Pnt3D>>))
			{
				List<List<Pnt3D>> list15 = new List<List<Pnt3D>>();
				if (Value.GetType() == typeof(List<List<Pnt3D>>))
				{
					for (int i = 0; i <= ((List<List<Pnt3D>>)Value).Count - 1; i++)
					{
						List<Pnt3D> list16 = new List<Pnt3D>();
						list16.AddRange(((List<List<Pnt3D>>)Value)[i].ToArray());
						list15.Add(list16);
					}
					PI.SetValue(Obj, list15);
				}
			}
			if (PI.PropertyType == typeof(double[]))
			{
				try
				{
					double[] array = new double[((double[])Value).Length];
					if (Value.GetType() == typeof(double[]))
					{
						for (int j = 0; j <= ((double[])Value).Length - 1; j++)
						{
							array[j] = ((double[])Value)[j];
						}
					}
					PI.SetValue(Obj, array);
				}
				catch (Exception)
				{
				}
			}
			if (PI.PropertyType == typeof(float[]) && Value != null)
			{
				try
				{
					float[] array2 = new float[((float[])Value).Length];
					if (Value.GetType() == typeof(float[]))
					{
						for (int k = 0; k <= ((float[])Value).Length - 1; k++)
						{
							array2[k] = ((float[])Value)[k];
						}
					}
					PI.SetValue(Obj, array2);
				}
				catch (Exception)
				{
				}
			}
			if (PI.PropertyType == typeof(int[]))
			{
				try
				{
					int[] array3 = new int[((int[])Value).Length];
					if (Value.GetType() == typeof(int[]))
					{
						for (int l = 0; l <= ((int[])Value).Length - 1; l++)
						{
							array3[l] = ((int[])Value)[l];
						}
					}
					PI.SetValue(Obj, array3);
				}
				catch (Exception)
				{
				}
			}
			if (PI.PropertyType == typeof(bool[]))
			{
				try
				{
					bool[] array4 = new bool[((bool[])Value).Length];
					if (Value.GetType() == typeof(bool[]))
					{
						for (int m = 0; m <= ((bool[])Value).Length - 1; m++)
						{
							array4[m] = ((bool[])Value)[m];
						}
					}
					PI.SetValue(Obj, array4);
				}
				catch (Exception)
				{
				}
			}
			if (PI.PropertyType == typeof(string[]))
			{
				try
				{
					string[] array5 = new string[((string[])Value).Length];
					if (Value.GetType() == typeof(string[]))
					{
						for (int n = 0; n <= ((string[])Value).Length - 1; n++)
						{
							array5[n] = ((string[])Value)[n];
						}
					}
					PI.SetValue(Obj, array5);
				}
				catch (Exception)
				{
				}
			}
			if (PI.PropertyType == typeof(Pnt2D[]))
			{
				try
				{
					Pnt2D[] array6 = new Pnt2D[((Pnt2D[])Value).Length];
					if (Value.GetType() == typeof(Pnt2D[]))
					{
						for (int num = 0; num <= ((Pnt2D[])Value).Length - 1; num++)
						{
							array6[num] = ((Pnt2D[])Value)[num];
						}
					}
					PI.SetValue(Obj, array6);
				}
				catch (Exception)
				{
				}
			}
			if (PI.PropertyType == typeof(Pnt3D[]))
			{
				try
				{
					Pnt3D[] array7 = new Pnt3D[((Pnt3D[])Value).Length];
					if (Value.GetType() == typeof(Pnt3D[]))
					{
						for (int num2 = 0; num2 <= ((Pnt3D[])Value).Length - 1; num2++)
						{
							array7[num2] = ((Pnt3D[])Value)[num2];
						}
					}
					PI.SetValue(Obj, array7);
				}
				catch (Exception)
				{
				}
			}
			if (PI.PropertyType == typeof(Pnt6D[]))
			{
				try
				{
					Pnt6D[] array8 = new Pnt6D[((Pnt6D[])Value).Length];
					if (Value.GetType() == typeof(Pnt6D[]))
					{
						for (int num3 = 0; num3 <= ((Pnt6D[])Value).Length - 1; num3++)
						{
							array8[num3] = ((Pnt6D[])Value)[num3];
						}
					}
					PI.SetValue(Obj, array8);
				}
				catch (Exception)
				{
				}
			}
			if (PI.PropertyType == typeof(Pnt9D[]))
			{
				try
				{
					Pnt9D[] array9 = new Pnt9D[((Pnt9D[])Value).Length];
					if (Value.GetType() == typeof(Pnt9D[]))
					{
						for (int num4 = 0; num4 <= ((Pnt9D[])Value).Length - 1; num4++)
						{
							array9[num4] = ((Pnt9D[])Value)[num4];
						}
					}
					PI.SetValue(Obj, array9);
				}
				catch (Exception)
				{
				}
			}
			if (PI.PropertyType == typeof(Vec3D[]))
			{
				try
				{
					Vec3D[] array10 = new Vec3D[((Vec3D[])Value).Length];
					if (Value.GetType() == typeof(Vec3D[]))
					{
						for (int num5 = 0; num5 <= ((Vec3D[])Value).Length - 1; num5++)
						{
							array10[num5] = ((Vec3D[])Value)[num5];
						}
					}
					PI.SetValue(Obj, array10);
				}
				catch (Exception)
				{
				}
			}
			if (PI.PropertyType == typeof(OrientationAngle[]))
			{
				try
				{
					OrientationAngle[] array11 = new OrientationAngle[((OrientationAngle[])Value).Length];
					if (Value.GetType() == typeof(OrientationAngle[]))
					{
						for (int num6 = 0; num6 <= ((OrientationAngle[])Value).Length - 1; num6++)
						{
							array11[num6] = ((OrientationAngle[])Value)[num6];
						}
					}
					PI.SetValue(Obj, array11);
				}
				catch (Exception)
				{
				}
			}
			if (PI.PropertyType == typeof(Line3D[]))
			{
				try
				{
					Line3D[] array12 = new Line3D[((Line3D[])Value).Length];
					if (Value.GetType() == typeof(Line3D[]))
					{
						for (int num7 = 0; num7 <= ((Line3D[])Value).Length - 1; num7++)
						{
							array12[num7] = ((Line3D[])Value)[num7];
						}
					}
					PI.SetValue(Obj, array12);
				}
				catch (Exception)
				{
				}
			}
			if (PI.PropertyType == typeof(Triangle3D[]))
			{
				try
				{
					Triangle3D[] array13 = new Triangle3D[((Triangle3D[])Value).Length];
					if (Value.GetType() == typeof(Triangle3D[]))
					{
						for (int num8 = 0; num8 <= ((Triangle3D[])Value).Length - 1; num8++)
						{
							array13[num8] = ((Triangle3D[])Value)[num8];
						}
					}
					PI.SetValue(Obj, array13);
				}
				catch (Exception)
				{
				}
			}
			if (!(PI.PropertyType == typeof(Quad3D[])))
			{
				return;
			}
			try
			{
				Quad3D[] array14 = new Quad3D[((Quad3D[])Value).Length];
				if (Value.GetType() == typeof(Quad3D[]))
				{
					for (int num9 = 0; num9 <= ((Quad3D[])Value).Length - 1; num9++)
					{
						array14[num9] = ((Quad3D[])Value)[num9];
					}
				}
				PI.SetValue(Obj, array14);
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

	public static void GetClassVariableValuesFromStringCodes(string Code, object RefObject, ref List<cParameter> Vars)
	{
		try
		{
			string[] array = null;
			array = Code.Split(';');
			if (array == null)
			{
				return;
			}
			Vars = new List<cParameter>();
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
				if (flag)
				{
					Vars[i].Value = value;
				}
				else
				{
					Vars[i].Value = "0";
				}
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public static void GetClassVariableValuesFromStringCodes(ArrayList Codes, object RefObject, ref List<cParameter> Vars)
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

	public static void GetSubClassVariableValuesFromStringCodes(List<string> Codes, ref object RefObject, ref List<cParameter> Vars)
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
			Vars = new List<cParameter>();
			GetClassVariables(RefObject, ref Vars);
			for (int k = 0; k <= Vars.Count - 1; k++)
			{
				Type type = Vars[k].Value.GetType();
				string text = Vars[k].Name.ToString().Trim();
				bool flag = false;
				bool flag2 = false;
				string value = "";
				ArrayList arrayList = new ArrayList();
				if (k == 25)
				{
				}
				if ((type.IsClass | (type.IsValueType & !type.IsEnum)) & !type.IsArray)
				{
					string text2 = "";
					if (type.BaseType.BaseType != null)
					{
						text2 = type.BaseType.BaseType.Namespace;
					}
					if ((type.Namespace == "buClass") | (type.BaseType.Namespace == "buClass") | (text2 == "buClass") | (type.Namespace == "buEyeBaseVer5") | (type.BaseType.Namespace == "buEyeBaseVer5") | (text2 == "buEyeBaseVer5") | (type.Namespace == "buMW") | (type.BaseType.Namespace == "buMW") | (text2 == "buMW"))
					{
						List<string> CalcList = new List<string>();
						List<cParameter> Vars2 = new List<cParameter>();
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
					List<cParameter> list2 = new List<cParameter>();
					buStatics.ListToSpecificList("<" + text + ">", "</" + text + ">", list, ref CalcList2);
					StringsToArray(ref Vars[k].Value, CalcList2);
					flag2 = true;
					flag = true;
				}
				if (!type.IsArray && Vars[k].Types.Name.IndexOf("List`1") >= 0)
				{
					ArrayList CalcList3 = new ArrayList();
					List<cParameter> list3 = new List<cParameter>();
					buStatics.ListToSpecificList("<" + text + ">", "</" + text + ">", list, ref CalcList3);
					StringsToList(ref Vars[k].Value, CalcList3);
					flag2 = true;
					flag = true;
				}
				if (!type.IsArray && Vars[k].Types.Name.IndexOf("ArrayList") >= 0)
				{
					ArrayList CalcList4 = new ArrayList();
					List<cParameter> list4 = new List<cParameter>();
					buStatics.ListToSpecificList("<" + text + ">", "</" + text + ">", list, ref CalcList4);
					StringsToArrayList(ref Vars[k].Value, CalcList4);
					flag2 = true;
					flag = true;
				}
				if (!flag2)
				{
					for (int l = 0; l <= list.Count - 1; l++)
					{
						string Value = "";
						string ParName = "";
						if (GetParameterValue(list[l], ref ParName, ref Value))
						{
							string text3 = RefObject.GetType().Name + ".";
							if ((ParName.Trim() == text) | (ParName.Trim() == text3 + text))
							{
								value = Value.Trim();
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

	public static void GetClassVariableValuesFromStringCodes(List<string> Codes, object RefObject, ref List<cParameter> Vars)
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
			Vars = new List<cParameter>();
			GetClassVariables(RefObject, ref Vars);
			for (int k = 0; k <= Vars.Count - 1; k++)
			{
				Type type = Vars[k].Value.GetType();
				string text = Vars[k].Name.ToString().Trim();
				bool flag = false;
				bool flag2 = false;
				string value = "";
				ArrayList arrayList = new ArrayList();
				if (k == 55)
				{
				}
				if (((type.IsClass | (type.IsValueType & !type.IsEnum)) & !type.IsArray) && ((type.Namespace == "buClass") | (type.BaseType.Namespace == "buClass") | (type.Namespace == "buEyeBaseVer5") | (type.BaseType.Namespace == "buEyeBaseVer5") | (type.Namespace == "buMW") | (type.BaseType.Namespace == "buMW") | (type.Namespace.IndexOf("buControls") >= 0)))
				{
					List<string> CalcList = new List<string>();
					List<cParameter> Vars2 = new List<cParameter>();
					buStatics.ListToSpecificList("<" + text + ">", "</" + text + ">", list, ref CalcList);
					GetSubClassVariableValuesFromStringCodes(CalcList, ref Vars[k].Value, ref Vars2);
					if (Vars2.Count == 0 && (List<cParameter>)Vars[k].SubParameter != null)
					{
						for (int l = 0; l <= ((List<cParameter>)Vars[k].SubParameter).Count - 1; l++)
						{
							Vars2.Add(((List<cParameter>)Vars[k].SubParameter)[l]);
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
					List<cParameter> list2 = new List<cParameter>();
					buStatics.ListToSpecificList("<" + text + ">", "</" + text + ">", list, ref CalcList2);
					StringsToArray(ref Vars[k].Value, CalcList2);
					flag2 = true;
					flag = true;
				}
				if (!type.IsArray && Vars[k].Types.FullName.IndexOf("Generic.List") >= 0)
				{
					string[] array2 = Vars[k].Types.FullName.Split(new string[1] { "Generic.List" }, StringSplitOptions.None);
					ArrayList CalcList3 = new ArrayList();
					List<cParameter> list3 = new List<cParameter>();
					if (array2.Length == 2)
					{
						buStatics.ListToSpecificList("<" + text + ">", "</" + text + ">", list, ref CalcList3);
						StringsToList(ref Vars[k].Value, CalcList3);
						flag2 = true;
						flag = true;
					}
					if (array2.Length == 3)
					{
						buStatics.ListToSpecificList("<" + text + ">", "</" + text + ">", list, ref CalcList3);
						StringsToListList(ref Vars[k].Value, text, CalcList3);
						flag2 = true;
						flag = true;
					}
				}
				if (!type.IsArray && Vars[k].Types.Name.IndexOf("ArrayList") >= 0)
				{
					ArrayList CalcList4 = new ArrayList();
					List<cParameter> list4 = new List<cParameter>();
					buStatics.ListToSpecificList("<" + text + ">", "</" + text + ">", list, ref CalcList4);
					StringsToArrayList(ref Vars[k].Value, CalcList4);
					flag2 = true;
					flag = true;
				}
				if (!flag2)
				{
					for (int m = 0; m <= list.Count - 1; m++)
					{
						string Value = "";
						string ParName = "";
						if (GetParameterValue(list[m], ref ParName, ref Value))
						{
							string text2 = RefObject.GetType().Name + ".";
							if ((ParName.Trim() == text) | (ParName.Trim() == text2 + text))
							{
								value = Value.Trim();
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

	public static void GetSubClassPropertyVariableValuesFromStringCodes(List<string> Codes, ref object RefObject, ref List<cParameter> Vars)
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
			Vars = new List<cParameter>();
			GetClassVariables(RefObject, ref Vars);
			for (int k = 0; k <= Vars.Count - 1; k++)
			{
				Type type = Vars[k].Value.GetType();
				string text = Vars[k].Name.ToString().Trim();
				bool flag = false;
				bool flag2 = false;
				string value = "";
				ArrayList arrayList = new ArrayList();
				if (k == 25)
				{
				}
				if ((type.IsClass | (type.IsValueType & !type.IsEnum)) & !type.IsArray)
				{
					string text2 = "";
					if (type.BaseType.BaseType != null)
					{
						text2 = type.BaseType.BaseType.Namespace;
					}
					if ((type.Namespace == "buClass") | (type.BaseType.Namespace == "buClass") | (text2 == "buClass") | (type.Namespace == "buEyeBaseVer5") | (type.BaseType.Namespace == "buEyeBaseVer5") | (text2 == "buEyeBaseVer5") | (type.Namespace == "buMW") | (type.BaseType.Namespace == "buMW") | (text2 == "buMW") | (type.Namespace.IndexOf("buControls") >= 0))
					{
						List<string> CalcList = new List<string>();
						List<cParameter> Vars2 = new List<cParameter>();
						buStatics.ListToSpecificList("<" + text + ">", "</" + text + ">", list, ref CalcList);
						GetSubClassPropertyVariableValuesFromStringCodes(CalcList, ref Vars[k].Value, ref Vars2);
						Vars[k].SubParameter = Vars2;
						object ObjPar = Vars[k].Property.GetValue(RefObject);
						SetClassPropertyVariables(ref ObjPar, Vars2);
						Vars[k].Value = ObjPar;
						flag2 = true;
						flag = true;
					}
				}
				if (type.IsArray)
				{
					ArrayList CalcList2 = new ArrayList();
					List<cParameter> list2 = new List<cParameter>();
					buStatics.ListToSpecificList("<" + text + ">", "</" + text + ">", list, ref CalcList2);
					StringsToArray(ref Vars[k].Value, CalcList2);
					flag2 = true;
					flag = true;
				}
				if (!type.IsArray && Vars[k].Types.Name.IndexOf("List`1") >= 0)
				{
					ArrayList CalcList3 = new ArrayList();
					List<cParameter> list3 = new List<cParameter>();
					buStatics.ListToSpecificList("<" + text + ">", "</" + text + ">", list, ref CalcList3);
					StringsToList(ref Vars[k].Value, CalcList3);
					flag2 = true;
					flag = true;
				}
				if (!type.IsArray && Vars[k].Types.Name.IndexOf("ArrayList") >= 0)
				{
					ArrayList CalcList4 = new ArrayList();
					List<cParameter> list4 = new List<cParameter>();
					buStatics.ListToSpecificList("<" + text + ">", "</" + text + ">", list, ref CalcList4);
					StringsToArrayList(ref Vars[k].Value, CalcList4);
					flag2 = true;
					flag = true;
				}
				if (!flag2)
				{
					for (int l = 0; l <= list.Count - 1; l++)
					{
						string Value = "";
						string ParName = "";
						if (GetParameterValue(list[l], ref ParName, ref Value))
						{
							string text3 = RefObject.GetType().Name + ".";
							if ((ParName.Trim() == text) | (ParName.Trim() == text3 + text))
							{
								value = Value.Trim();
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

	public static void GetClassPropertyVariableValuesFromStringCodes(List<string> Codes, object RefObject, ref List<cParameter> Vars)
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
			Vars = new List<cParameter>();
			GetClassVariables(RefObject, ref Vars);
			for (int k = 0; k <= Vars.Count - 1; k++)
			{
				Type type = Vars[k].Value.GetType();
				string text = Vars[k].Name.ToString().Trim();
				bool flag = false;
				bool flag2 = false;
				string value = "";
				ArrayList arrayList = new ArrayList();
				if (k == 55)
				{
				}
				if (((type.IsClass | (type.IsValueType & !type.IsEnum)) & !type.IsArray) && ((type.Namespace == "buClass") | (type.BaseType.Namespace == "buClass") | (type.Namespace == "buEyeBaseVer5") | (type.BaseType.Namespace == "buEyeBaseVer5") | (type.Namespace == "buMW") | (type.BaseType.Namespace == "buMW") | (type.Namespace.IndexOf("buControls") >= 0)))
				{
					List<string> CalcList = new List<string>();
					List<cParameter> Vars2 = new List<cParameter>();
					buStatics.ListToSpecificList("<" + text + ">", "</" + text + ">", list, ref CalcList);
					GetSubClassPropertyVariableValuesFromStringCodes(CalcList, ref Vars[k].Value, ref Vars2);
					if (Vars2.Count == 0 && (List<cParameter>)Vars[k].SubParameter != null)
					{
						for (int l = 0; l <= ((List<cParameter>)Vars[k].SubParameter).Count - 1; l++)
						{
							Vars2.Add(((List<cParameter>)Vars[k].SubParameter)[l]);
						}
					}
					Vars[k].SubParameter = Vars2;
					if (Vars2.Count > 0)
					{
						object ObjPar = Vars[k].Property.GetValue(RefObject);
						SetClassPropertyVariables(ref ObjPar, Vars2);
						Vars[k].Value = ObjPar;
						flag = true;
					}
					flag2 = true;
				}
				if (type.IsArray)
				{
					ArrayList CalcList2 = new ArrayList();
					List<cParameter> list2 = new List<cParameter>();
					buStatics.ListToSpecificList("<" + text + ">", "</" + text + ">", list, ref CalcList2);
					StringsToArray(ref Vars[k].Value, CalcList2);
					flag2 = true;
					flag = true;
				}
				if (!type.IsArray && Vars[k].Types.FullName.IndexOf("Generic.List") >= 0)
				{
					string[] array2 = Vars[k].Types.FullName.Split(new string[1] { "Generic.List" }, StringSplitOptions.None);
					ArrayList CalcList3 = new ArrayList();
					List<cParameter> list3 = new List<cParameter>();
					if (array2.Length == 2)
					{
						buStatics.ListToSpecificList("<" + text + ">", "</" + text + ">", list, ref CalcList3);
						StringsToList(ref Vars[k].Value, CalcList3);
						flag2 = true;
						flag = true;
					}
					if (array2.Length == 3)
					{
						buStatics.ListToSpecificList("<" + text + ">", "</" + text + ">", list, ref CalcList3);
						StringsToListList(ref Vars[k].Value, text, CalcList3);
						flag2 = true;
						flag = true;
					}
				}
				if (!type.IsArray && Vars[k].Types.Name.IndexOf("ArrayList") >= 0)
				{
					ArrayList CalcList4 = new ArrayList();
					List<cParameter> list4 = new List<cParameter>();
					buStatics.ListToSpecificList("<" + text + ">", "</" + text + ">", list, ref CalcList4);
					StringsToArrayList(ref Vars[k].Value, CalcList4);
					flag2 = true;
					flag = true;
				}
				if (!flag2)
				{
					for (int m = 0; m <= list.Count - 1; m++)
					{
						string Value = "";
						string ParName = "";
						if (GetParameterValue(list[m], ref ParName, ref Value))
						{
							string text2 = RefObject.GetType().Name + ".";
							if ((ParName.Trim() == text) | (ParName.Trim() == text2 + text))
							{
								value = Value.Trim();
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

	private ArrayList ToDefSubClass(object Obj, int Space)
	{
		try
		{
			ArrayList arrayList = new ArrayList();
			string text = new string(' ', Space);
			string text2 = text;
			List<cParameter> Vars = new List<cParameter>();
			GetClassVariables(Obj, ref Vars);
			for (int i = 0; i <= Vars.Count - 1; i++)
			{
				string text3 = Vars[i].Value.GetType().ToString();
				bool flag = false;
				Type type = Vars[i].Value.GetType();
				if ((Vars[i].Value.GetType() != typeof(ArrayList)) & (text3.IndexOf("Generic.List") < 0) & !type.IsArray)
				{
					if (((type.Namespace == "buClass") | (type.Namespace == "buMW") | (type.Namespace == "buEyeBaseVer5")) & !type.IsEnum)
					{
						string text4 = new string(' ', Space);
						arrayList.Add(text4 + "<" + Vars[i].Name.ToString() + ">");
						arrayList.AddRange(ToDefSubClass(Vars[i].Value, Space + 2).ToArray());
						arrayList.Add(text4 + "</" + Vars[i].Name.ToString() + ">");
						flag = true;
					}
					if (!flag)
					{
						string text5 = Obj.GetType().Name + ".";
						arrayList.Add(text + text5 + Vars[i].Name + " = " + Vars[i].ValueAsString.ToString());
					}
				}
				else if (type.IsArray)
				{
					arrayList.AddRange(ArrayToStrings(Vars[i].Name.ToString(), Vars[i].Value, Space).ToArray());
				}
				else if (Vars[i].Value.GetType() == typeof(ArrayList))
				{
					arrayList.AddRange(ArrayListToStrings(Vars[i].Name.ToString(), (ArrayList)Vars[i].Value, Space).ToArray());
				}
				else if (text3.IndexOf("Generic.List") >= 0)
				{
					arrayList.AddRange(ListToStrings(Vars[i].Name.ToString(), Vars[i].Value, Space).ToArray());
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

	private ArrayList ArrayListToStrings(string varName, ArrayList varVal, int Space)
	{
		try
		{
			string text = new string(' ', Space);
			ArrayList arrayList = new ArrayList();
			arrayList.Add(text + "<" + varName + ">");
			string text2 = new string(' ', Space + 2);
			for (int i = 0; i <= varVal.Count - 1; i++)
			{
				arrayList.Add(text2 + varName + " = " + varVal[i].ToString());
			}
			arrayList.Add(text + "</" + varName + ">");
			return arrayList;
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			return new ArrayList();
		}
	}

	private ArrayList ListToStrings(string varName, object varVal, int Space)
	{
		try
		{
			string text = new string(' ', Space);
			ArrayList arrayList = new ArrayList();
			if (varVal == null)
			{
				return arrayList;
			}
			string text2 = varVal.GetType().ToString();
			Type type = varVal.GetType();
			if (type == typeof(List<double>))
			{
				arrayList.Add(text + "<" + varName + ">");
				string text3 = new string(' ', Space + 2);
				for (int i = 0; i <= ((List<double>)varVal).Count - 1; i++)
				{
					double num = 0.0;
					arrayList.Add(text3 + varName + " = " + ((List<double>)varVal)[i]);
				}
				arrayList.Add(text + "</" + varName + ">");
			}
			if (type == typeof(List<int>))
			{
				arrayList.Add(text + "<" + varName + ">");
				string text4 = new string(' ', Space + 2);
				for (int j = 0; j <= ((List<int>)varVal).Count - 1; j++)
				{
					int num2 = 0;
					arrayList.Add(text4 + varName + " = " + ((List<int>)varVal)[j]);
				}
				arrayList.Add(text + "</" + varName + ">");
			}
			if (type == typeof(List<float>))
			{
				arrayList.Add(text + "<" + varName + ">");
				string text5 = new string(' ', Space + 2);
				for (int k = 0; k <= ((List<float>)varVal).Count - 1; k++)
				{
					float num3 = 0f;
					arrayList.Add(text5 + varName + " = " + ((List<float>)varVal)[k]);
				}
				arrayList.Add(text + "</" + varName + ">");
			}
			if (type == typeof(List<bool>))
			{
				arrayList.Add(text + "<" + varName + ">");
				string text6 = new string(' ', Space + 2);
				for (int l = 0; l <= ((List<bool>)varVal).Count - 1; l++)
				{
					bool flag = false;
					arrayList.Add(text6 + varName + " = " + ((List<bool>)varVal)[l]);
				}
				arrayList.Add(text + "</" + varName + ">");
			}
			if (type == typeof(List<string>))
			{
				arrayList.Add(text + "<" + varName + ">");
				string text7 = new string(' ', Space + 2);
				for (int m = 0; m <= ((List<string>)varVal).Count - 1; m++)
				{
					string text8 = "";
					text8 = ((List<string>)varVal)[m];
					arrayList.Add(text7 + varName + " = " + text8.ToString());
				}
				arrayList.Add(text + "</" + varName + ">");
			}
			if (type == typeof(List<Pnt2D>))
			{
				arrayList.Add(text + "<" + varName + ">");
				string text9 = new string(' ', Space + 2);
				for (int n = 0; n <= ((List<Pnt2D>)varVal).Count - 1; n++)
				{
					Pnt2D pnt2D = new Pnt2D();
					pnt2D = ((List<Pnt2D>)varVal)[n];
					arrayList.Add(text9 + varName + " = " + pnt2D.ToDef());
				}
				arrayList.Add(text + "</" + varName + ">");
			}
			if (type == typeof(List<Pnt3D>))
			{
				arrayList.Add(text + "<" + varName + ">");
				string text10 = new string(' ', Space + 2);
				for (int num4 = 0; num4 <= ((List<Pnt3D>)varVal).Count - 1; num4++)
				{
					Pnt3D pnt3D = new Pnt3D();
					pnt3D = ((List<Pnt3D>)varVal)[num4];
					arrayList.Add(text10 + varName + " = " + pnt3D.ToDef());
				}
				arrayList.Add(text + "</" + varName + ">");
			}
			if (type == typeof(List<Pnt6D>))
			{
				arrayList.Add(text + "<" + varName + ">");
				string text11 = new string(' ', Space + 2);
				for (int num5 = 0; num5 <= ((List<Pnt6D>)varVal).Count - 1; num5++)
				{
					Pnt6D pnt6D = new Pnt6D();
					pnt6D = ((List<Pnt6D>)varVal)[num5];
					arrayList.Add(text11 + varName + " = " + pnt6D.ToDef());
				}
				arrayList.Add(text + "</" + varName + ">");
			}
			if (type == typeof(List<Pnt9D>))
			{
				arrayList.Add(text + "<" + varName + ">");
				string text12 = new string(' ', Space + 2);
				for (int num6 = 0; num6 <= ((List<Pnt9D>)varVal).Count - 1; num6++)
				{
					Pnt9D pnt9D = new Pnt9D();
					pnt9D = ((List<Pnt9D>)varVal)[num6];
					arrayList.Add(text12 + varName + " = " + pnt9D.ToDef());
				}
				arrayList.Add(text + "</" + varName + ">");
			}
			if (type == typeof(List<Vec3D>))
			{
				arrayList.Add(text + "<" + varName + ">");
				string text13 = new string(' ', Space + 2);
				for (int num7 = 0; num7 <= ((List<Vec3D>)varVal).Count - 1; num7++)
				{
					Vec3D vec3D = new Vec3D();
					vec3D = ((List<Vec3D>)varVal)[num7];
					arrayList.Add(text13 + varName + " = " + vec3D.ToDef());
				}
				arrayList.Add(text + "</" + varName + ">");
			}
			if (type == typeof(List<OrientationAngle>))
			{
				arrayList.Add(text + "<" + varName + ">");
				string text14 = new string(' ', Space + 2);
				for (int num8 = 0; num8 <= ((List<OrientationAngle>)varVal).Count - 1; num8++)
				{
					OrientationAngle orientationAngle = new OrientationAngle();
					orientationAngle = ((List<OrientationAngle>)varVal)[num8];
					arrayList.Add(text14 + varName + " = " + orientationAngle.ToDef());
				}
				arrayList.Add(text + "</" + varName + ">");
			}
			if (type == typeof(List<Line3D>))
			{
				arrayList.Add(text + "<" + varName + ">");
				string text15 = new string(' ', Space + 2);
				for (int num9 = 0; num9 <= ((List<Line3D>)varVal).Count - 1; num9++)
				{
					Line3D line3D = new Line3D();
					line3D = ((List<Line3D>)varVal)[num9];
					arrayList.Add(text15 + varName + " = " + line3D.ToDef(2));
				}
				arrayList.Add(text + "</" + varName + ">");
			}
			if (type == typeof(List<Triangle3D>))
			{
				arrayList.Add(text + "<" + varName + ">");
				string text16 = new string(' ', Space + 2);
				for (int num10 = 0; num10 <= ((List<Triangle3D>)varVal).Count - 1; num10++)
				{
					Triangle3D triangle3D = new Triangle3D();
					triangle3D = ((List<Triangle3D>)varVal)[num10];
					arrayList.Add(text16 + varName + " = " + triangle3D.ToDef(2));
				}
				arrayList.Add(text + "</" + varName + ">");
			}
			if (type == typeof(List<Quad3D>))
			{
				arrayList.Add(text + "<" + varName + ">");
				string text17 = new string(' ', Space + 2);
				for (int num11 = 0; num11 <= ((List<Quad3D>)varVal).Count - 1; num11++)
				{
					Quad3D quad3D = new Quad3D();
					quad3D = ((List<Quad3D>)varVal)[num11];
					arrayList.Add(text17 + varName + " = " + quad3D.ToDef(2));
				}
				arrayList.Add(text + "</" + varName + ">");
			}
			return arrayList;
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			return new ArrayList();
		}
	}

	private ArrayList ListListToStrings(string varName, object varVal, int Space)
	{
		try
		{
			string text = new string(' ', Space);
			ArrayList arrayList = new ArrayList();
			if (varVal == null)
			{
				return arrayList;
			}
			Type type = varVal.GetType();
			string text2 = varVal.GetType().ToString();
			if (type == typeof(List<List<Pnt3D>>))
			{
				arrayList.Add(text + "<" + varName + ">");
				string text3 = new string(' ', Space + 2);
				for (int i = 0; i <= ((List<List<Pnt3D>>)varVal).Count - 1; i++)
				{
					arrayList.AddRange(ListToStrings(varName + "_Sub", ((List<List<Pnt3D>>)varVal)[i], Space + 2).ToArray());
				}
				arrayList.Add(text + "</" + varName + ">");
			}
			return arrayList;
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			return new ArrayList();
		}
	}

	private ArrayList ArrayToStrings(string varName, object varVal, int Space)
	{
		try
		{
			string text = new string(' ', Space);
			ArrayList arrayList = new ArrayList();
			if (varVal == null)
			{
				return arrayList;
			}
			string text2 = varVal.GetType().ToString();
			if (text2.IndexOf("System.Double[]") >= 0)
			{
				arrayList.Add(text + "<" + varName + ">");
				string text3 = new string(' ', Space + 2);
				for (int i = 0; i <= ((double[])varVal).Length - 1; i++)
				{
					double num = 0.0;
					num = ((double[])varVal)[i];
					arrayList.Add(text3 + varName + " = " + num);
				}
				arrayList.Add(text + "</" + varName + ">");
			}
			if (text2.IndexOf("System.Int32[]") >= 0)
			{
				arrayList.Add(text + "<" + varName + ">");
				string text4 = new string(' ', Space + 2);
				for (int j = 0; j <= ((int[])varVal).Length - 1; j++)
				{
					int num2 = 0;
					num2 = ((int[])varVal)[j];
					arrayList.Add(text4 + varName + " = " + num2);
				}
				arrayList.Add(text + "</" + varName + ">");
			}
			if (text2.IndexOf("System.Single[]") >= 0)
			{
				arrayList.Add(text + "<" + varName + ">");
				string text5 = new string(' ', Space + 2);
				for (int k = 0; k <= ((float[])varVal).Length - 1; k++)
				{
					float num3 = 0f;
					num3 = ((float[])varVal)[k];
					arrayList.Add(text5 + varName + " = " + num3);
				}
				arrayList.Add(text + "</" + varName + ">");
			}
			if (text2.IndexOf("System.Boolean[]") >= 0)
			{
				arrayList.Add(text + "<" + varName + ">");
				string text6 = new string(' ', Space + 2);
				for (int l = 0; l <= ((bool[])varVal).Length - 1; l++)
				{
					bool flag = false;
					flag = ((bool[])varVal)[l];
					arrayList.Add(text6 + varName + " = " + flag);
				}
				arrayList.Add(text + "</" + varName + ">");
			}
			if (text2.IndexOf("System.String[]") >= 0)
			{
				arrayList.Add(text + "<" + varName + ">");
				string text7 = new string(' ', Space + 2);
				for (int m = 0; m <= ((string[])varVal).Length - 1; m++)
				{
					string text8 = "";
					text8 = ((string[])varVal)[m];
					arrayList.Add(text7 + varName + " = " + text8.ToString());
				}
				arrayList.Add(text + "</" + varName + ">");
			}
			return arrayList;
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			return new ArrayList();
		}
	}

	public static string BoolToString(bool Val)
	{
		if (Val)
		{
			return "1";
		}
		return "0";
	}

	private static void StringsToArrayList(ref object varVal, ArrayList valueList)
	{
		try
		{
			if (varVal.GetType() == typeof(ArrayList))
			{
				varVal = new ArrayList();
				for (int i = 0; i <= valueList.Count - 1; i++)
				{
					string parameterValue = GetParameterValue(valueList[i].ToString());
					((ArrayList)varVal).Add(parameterValue);
				}
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	private static void StringsToList(ref object varVal, ArrayList valueList)
	{
		try
		{
			if (varVal.GetType() == typeof(List<double>))
			{
				varVal = new List<double>();
				for (int i = 0; i <= valueList.Count - 1; i++)
				{
					double result = 0.0;
					double.TryParse(GetParameterValue(valueList[i].ToString()), out result);
					((List<double>)varVal).Add(result);
				}
			}
			if (varVal.GetType() == typeof(List<int>))
			{
				varVal = new List<int>();
				for (int j = 0; j <= valueList.Count - 1; j++)
				{
					int result2 = 0;
					int.TryParse(GetParameterValue(valueList[j].ToString()), out result2);
					((List<int>)varVal).Add(result2);
				}
			}
			if (varVal.GetType() == typeof(List<float>))
			{
				varVal = new List<float>();
				for (int k = 0; k <= valueList.Count - 1; k++)
				{
					float result3 = 0f;
					float.TryParse(GetParameterValue(valueList[k].ToString()), out result3);
					((List<float>)varVal).Add(result3);
				}
			}
			if (varVal.GetType() == typeof(List<bool>))
			{
				varVal = new List<bool>();
				for (int l = 0; l <= valueList.Count - 1; l++)
				{
					bool result4 = false;
					bool.TryParse(GetParameterValue(valueList[l].ToString()), out result4);
					((List<bool>)varVal).Add(result4);
				}
			}
			if (varVal.GetType() == typeof(List<string>))
			{
				varVal = new List<string>();
				for (int m = 0; m <= valueList.Count - 1; m++)
				{
					string parameterValue = GetParameterValue(valueList[m].ToString());
					((List<string>)varVal).Add(parameterValue);
				}
			}
			if (varVal.GetType() == typeof(List<Pnt2D>))
			{
				varVal = new List<Pnt2D>();
				for (int n = 0; n <= valueList.Count - 1; n++)
				{
					Pnt2D pnt2D = new Pnt2D();
					pnt2D = Pnt2D.DecodeFromString(GetParameterValue(valueList[n].ToString()));
					((List<Pnt2D>)varVal).Add(pnt2D);
				}
			}
			if (varVal.GetType() == typeof(List<Pnt3D>))
			{
				varVal = new List<Pnt3D>();
				for (int num = 0; num <= valueList.Count - 1; num++)
				{
					Pnt3D pnt3D = new Pnt3D();
					pnt3D = Pnt3D.DecodeFromString(GetParameterValue(valueList[num].ToString()));
					((List<Pnt3D>)varVal).Add(pnt3D);
				}
			}
			if (varVal.GetType() == typeof(List<Pnt6D>))
			{
				varVal = new List<Pnt6D>();
				for (int num2 = 0; num2 <= valueList.Count - 1; num2++)
				{
					Pnt6D pnt6D = new Pnt6D();
					pnt6D = Pnt6D.DecodeFromString(GetParameterValue(valueList[num2].ToString()));
					((List<Pnt6D>)varVal).Add(pnt6D);
				}
			}
			if (varVal.GetType() == typeof(List<Pnt9D>))
			{
				varVal = new List<Pnt9D>();
				for (int num3 = 0; num3 <= valueList.Count - 1; num3++)
				{
					Pnt9D pnt9D = new Pnt9D();
					pnt9D = Pnt9D.DecodeFromString(GetParameterValue(valueList[num3].ToString()));
					((List<Pnt9D>)varVal).Add(pnt9D);
				}
			}
			if (varVal.GetType() == typeof(List<Vec3D>))
			{
				varVal = new List<Vec3D>();
				for (int num4 = 0; num4 <= valueList.Count - 1; num4++)
				{
					Vec3D vec3D = new Vec3D();
					vec3D = Vec3D.DecodeFromString(GetParameterValue(valueList[num4].ToString()));
					((List<Vec3D>)varVal).Add(vec3D);
				}
			}
			if (varVal.GetType() == typeof(List<OrientationAngle>))
			{
				varVal = new List<OrientationAngle>();
				for (int num5 = 0; num5 <= valueList.Count - 1; num5++)
				{
					OrientationAngle orientationAngle = new OrientationAngle();
					orientationAngle = OrientationAngle.DecodeFromString(GetParameterValue(valueList[num5].ToString()));
					((List<OrientationAngle>)varVal).Add(orientationAngle);
				}
			}
			if (varVal.GetType() == typeof(List<Line3D>))
			{
				varVal = new List<Line3D>();
				for (int num6 = 0; num6 <= valueList.Count - 1; num6++)
				{
					Line3D line3D = new Line3D();
					line3D = Line3D.DecodeFromString(GetParameterValue(valueList[num6].ToString()));
					((List<Line3D>)varVal).Add(line3D);
				}
			}
			if (varVal.GetType() == typeof(List<Triangle3D>))
			{
				varVal = new List<Triangle3D>();
				for (int num7 = 0; num7 <= valueList.Count - 1; num7++)
				{
					Triangle3D triangle3D = new Triangle3D();
					triangle3D = Triangle3D.DecodeFromString(GetParameterValue(valueList[num7].ToString()));
					((List<Triangle3D>)varVal).Add(triangle3D);
				}
			}
			if (varVal.GetType() == typeof(List<Quad3D>))
			{
				varVal = new List<Quad3D>();
				for (int num8 = 0; num8 <= valueList.Count - 1; num8++)
				{
					Quad3D quad3D = new Quad3D();
					quad3D = Quad3D.DecodeFromString(GetParameterValue(valueList[num8].ToString()));
					((List<Quad3D>)varVal).Add(quad3D);
				}
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	private static void StringsToListList(ref object varVal, string nameVar, ArrayList valueList)
	{
		try
		{
			if (varVal.GetType() == typeof(List<List<Pnt3D>>))
			{
				varVal = new List<List<Pnt3D>>();
				List<List<string>> CalcList = new List<List<string>>();
				buStatics.ListToSpecificList("<" + nameVar + "_Sub>", "</" + nameVar + "_Sub>", valueList, ref CalcList);
				for (int i = 0; i <= CalcList.Count - 1; i++)
				{
					ArrayList arrayList = new ArrayList();
					arrayList.AddRange(CalcList[i].ToArray());
					object varVal2 = new List<Pnt3D>();
					StringsToList(ref varVal2, arrayList);
					((List<List<Pnt3D>>)varVal).Add((List<Pnt3D>)varVal2);
				}
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	private static void StringsToArray(ref object varVal, ArrayList valueList)
	{
		try
		{
			if (varVal.GetType() == typeof(double[]))
			{
				varVal = new double[valueList.Count];
				for (int i = 0; i <= valueList.Count - 1; i++)
				{
					double result = 0.0;
					double.TryParse(GetParameterValue(valueList[i].ToString()), out result);
					((double[])varVal)[i] = result;
				}
			}
			if (varVal.GetType() == typeof(int[]))
			{
				varVal = new int[valueList.Count];
				for (int j = 0; j <= valueList.Count - 1; j++)
				{
					int result2 = 0;
					int.TryParse(GetParameterValue(valueList[j].ToString()), out result2);
					((int[])varVal)[j] = result2;
				}
			}
			if (varVal.GetType() == typeof(bool[]))
			{
				varVal = new bool[valueList.Count];
				for (int k = 0; k <= valueList.Count - 1; k++)
				{
					bool result3 = false;
					bool.TryParse(GetParameterValue(valueList[k].ToString()), out result3);
					((bool[])varVal)[k] = result3;
				}
			}
			if (varVal.GetType() == typeof(string[]))
			{
				varVal = new string[valueList.Count];
				for (int l = 0; l <= valueList.Count - 1; l++)
				{
					string parameterValue = GetParameterValue(valueList[l].ToString());
					((string[])varVal)[l] = parameterValue;
				}
			}
			if (varVal.GetType() == typeof(double[]))
			{
				varVal = new double[valueList.Count];
				for (int m = 0; m <= valueList.Count - 1; m++)
				{
					double result4 = 0.0;
					double.TryParse(GetParameterValue(valueList[m].ToString()), out result4);
					((double[])varVal)[m] = result4;
				}
			}
			if (varVal.GetType() == typeof(float[]))
			{
				varVal = new float[valueList.Count];
				for (int n = 0; n <= valueList.Count - 1; n++)
				{
					float result5 = 0f;
					float.TryParse(GetParameterValue(valueList[n].ToString()), out result5);
					((float[])varVal)[n] = result5;
				}
			}
			if (varVal.GetType() == typeof(Pnt2D[]))
			{
				varVal = new Pnt2D[valueList.Count];
				for (int num = 0; num <= valueList.Count - 1; num++)
				{
					Pnt2D pnt2D = new Pnt2D();
					pnt2D = Pnt2D.DecodeFromString(GetParameterValue(valueList[num].ToString()));
					((Pnt2D[])varVal)[num] = pnt2D;
				}
			}
			if (varVal.GetType() == typeof(Pnt3D[]))
			{
				varVal = new Pnt3D[valueList.Count];
				for (int num2 = 0; num2 <= valueList.Count - 1; num2++)
				{
					Pnt3D pnt3D = new Pnt3D();
					pnt3D = Pnt3D.DecodeFromString(GetParameterValue(valueList[num2].ToString()));
					((Pnt3D[])varVal)[num2] = pnt3D;
				}
			}
			if (varVal.GetType() == typeof(Pnt6D[]))
			{
				varVal = new Pnt6D[valueList.Count];
				for (int num3 = 0; num3 <= valueList.Count - 1; num3++)
				{
					Pnt6D pnt6D = new Pnt6D();
					pnt6D = Pnt6D.DecodeFromString(GetParameterValue(valueList[num3].ToString()));
					((Pnt6D[])varVal)[num3] = pnt6D;
				}
			}
			if (varVal.GetType() == typeof(Pnt9D[]))
			{
				varVal = new Pnt9D[valueList.Count];
				for (int num4 = 0; num4 <= valueList.Count - 1; num4++)
				{
					Pnt9D pnt9D = new Pnt9D();
					pnt9D = Pnt9D.DecodeFromString(GetParameterValue(valueList[num4].ToString()));
					((Pnt9D[])varVal)[num4] = pnt9D;
				}
			}
			if (varVal.GetType() == typeof(Vec3D[]))
			{
				varVal = new Vec3D[valueList.Count];
				for (int num5 = 0; num5 <= valueList.Count - 1; num5++)
				{
					Vec3D vec3D = new Vec3D();
					vec3D = Vec3D.DecodeFromString(GetParameterValue(valueList[num5].ToString()));
					((Vec3D[])varVal)[num5] = vec3D;
				}
			}
			if (varVal.GetType() == typeof(OrientationAngle[]))
			{
				varVal = new OrientationAngle[valueList.Count];
				for (int num6 = 0; num6 <= valueList.Count - 1; num6++)
				{
					OrientationAngle orientationAngle = new OrientationAngle();
					orientationAngle = OrientationAngle.DecodeFromString(GetParameterValue(valueList[num6].ToString()));
					((OrientationAngle[])varVal)[num6] = orientationAngle;
				}
			}
			if (varVal.GetType() == typeof(Line3D[]))
			{
				varVal = new Line3D[valueList.Count];
				for (int num7 = 0; num7 <= valueList.Count - 1; num7++)
				{
					Line3D line3D = new Line3D();
					line3D = Line3D.DecodeFromString(GetParameterValue(valueList[num7].ToString()));
					((Line3D[])varVal)[num7] = line3D;
				}
			}
			if (varVal.GetType() == typeof(Triangle3D[]))
			{
				varVal = new Triangle3D[valueList.Count];
				for (int num8 = 0; num8 <= valueList.Count - 1; num8++)
				{
					Triangle3D triangle3D = new Triangle3D();
					triangle3D = Triangle3D.DecodeFromString(GetParameterValue(valueList[num8].ToString()));
					((Triangle3D[])varVal)[num8] = triangle3D;
				}
			}
			if (varVal.GetType() == typeof(Quad3D[]))
			{
				varVal = new Quad3D[valueList.Count];
				for (int num9 = 0; num9 <= valueList.Count - 1; num9++)
				{
					Quad3D quad3D = new Quad3D();
					quad3D = Quad3D.DecodeFromString(GetParameterValue(valueList[num9].ToString()));
					((Quad3D[])varVal)[num9] = quad3D;
				}
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	private static void ValueToSetClassArrayList(ref object Obj, object Value)
	{
		try
		{
			if (Value.GetType() == typeof(ArrayList))
			{
				Obj = new ArrayList();
				ArrayList arrayList = new ArrayList();
				arrayList = (ArrayList)Value;
				((ArrayList)Obj).AddRange(arrayList.ToArray());
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	private static void ValueToSetClassArray(ref object Obj, object Value)
	{
		try
		{
			if (Value.GetType() == typeof(double[]))
			{
				Obj = new double[((double[])Value).Length];
				for (int i = 0; i <= ((double[])Value).Length - 1; i++)
				{
					((double[])Obj)[i] = ((double[])Value)[i];
				}
			}
			if (Value.GetType() == typeof(float[]))
			{
				Obj = new float[((float[])Value).Length];
				for (int j = 0; j <= ((float[])Value).Length - 1; j++)
				{
					((float[])Obj)[j] = ((float[])Value)[j];
				}
			}
			if (Value.GetType() == typeof(int[]))
			{
				Obj = new int[((int[])Value).Length];
				for (int k = 0; k <= ((int[])Value).Length - 1; k++)
				{
					((int[])Obj)[k] = ((int[])Value)[k];
				}
			}
			if (Value.GetType() == typeof(bool[]))
			{
				Obj = new bool[((bool[])Value).Length];
				for (int l = 0; l <= ((bool[])Value).Length - 1; l++)
				{
					((bool[])Obj)[l] = ((bool[])Value)[l];
				}
			}
			if (Value.GetType() == typeof(string[]))
			{
				Obj = new string[((string[])Value).Length];
				for (int m = 0; m <= ((string[])Value).Length - 1; m++)
				{
					((string[])Obj)[m] = ((string[])Value)[m];
				}
			}
			if (Value.GetType() == typeof(Pnt2D[]))
			{
				Obj = new Pnt2D[((Pnt2D[])Value).Length];
				for (int n = 0; n <= ((Pnt2D[])Value).Length - 1; n++)
				{
					((Pnt2D[])Obj)[n] = ((Pnt2D[])Value)[n];
				}
			}
			if (Value.GetType() == typeof(Pnt3D[]))
			{
				Obj = new Pnt3D[((Pnt3D[])Value).Length];
				for (int num = 0; num <= ((Pnt3D[])Value).Length - 1; num++)
				{
					((Pnt3D[])Obj)[num] = ((Pnt3D[])Value)[num];
				}
			}
			if (Value.GetType() == typeof(Pnt6D[]))
			{
				Obj = new Pnt6D[((Pnt6D[])Value).Length];
				for (int num2 = 0; num2 <= ((Pnt6D[])Value).Length - 1; num2++)
				{
					((Pnt6D[])Obj)[num2] = ((Pnt6D[])Value)[num2];
				}
			}
			if (Value.GetType() == typeof(Pnt9D[]))
			{
				Obj = new Pnt9D[((Pnt9D[])Value).Length];
				for (int num3 = 0; num3 <= ((Pnt9D[])Value).Length - 1; num3++)
				{
					((Pnt9D[])Obj)[num3] = ((Pnt9D[])Value)[num3];
				}
			}
			if (Value.GetType() == typeof(Vec3D[]))
			{
				Obj = new Vec3D[((Vec3D[])Value).Length];
				for (int num4 = 0; num4 <= ((Vec3D[])Value).Length - 1; num4++)
				{
					((Vec3D[])Obj)[num4] = ((Vec3D[])Value)[num4];
				}
			}
			if (Value.GetType() == typeof(OrientationAngle[]))
			{
				Obj = new OrientationAngle[((OrientationAngle[])Value).Length];
				for (int num5 = 0; num5 <= ((OrientationAngle[])Value).Length - 1; num5++)
				{
					((OrientationAngle[])Obj)[num5] = ((OrientationAngle[])Value)[num5];
				}
			}
			if (Value.GetType() == typeof(Line3D[]))
			{
				Obj = new Line3D[((Line3D[])Value).Length];
				for (int num6 = 0; num6 <= ((Line3D[])Value).Length - 1; num6++)
				{
					((Line3D[])Obj)[num6] = ((Line3D[])Value)[num6];
				}
			}
			if (Value.GetType() == typeof(Triangle3D[]))
			{
				Obj = new Triangle3D[((Triangle3D[])Value).Length];
				for (int num7 = 0; num7 <= ((Triangle3D[])Value).Length - 1; num7++)
				{
					((Triangle3D[])Obj)[num7] = ((Triangle3D[])Value)[num7];
				}
			}
			if (Value.GetType() == typeof(Quad3D[]))
			{
				Obj = new Quad3D[((Quad3D[])Value).Length];
				for (int num8 = 0; num8 <= ((Quad3D[])Value).Length - 1; num8++)
				{
					((Quad3D[])Obj)[num8] = ((Quad3D[])Value)[num8];
				}
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	private static void ValueToSetClassList(ref object Obj, object Value)
	{
		try
		{
			if (Value.GetType() == typeof(List<double>))
			{
				Obj = new List<double>();
				List<double> list = new List<double>();
				list = (List<double>)Value;
				((List<double>)Obj).AddRange(list.ToArray());
			}
			if (Value.GetType() == typeof(List<float>))
			{
				Obj = new List<float>();
				List<float> list2 = new List<float>();
				list2 = (List<float>)Value;
				((List<float>)Obj).AddRange(list2.ToArray());
			}
			if (Value.GetType() == typeof(List<int>))
			{
				Obj = new List<int>();
				List<int> list3 = new List<int>();
				list3 = (List<int>)Value;
				((List<int>)Obj).AddRange(list3.ToArray());
			}
			if (Value.GetType() == typeof(List<bool>))
			{
				Obj = new List<bool>();
				List<bool> list4 = new List<bool>();
				list4 = (List<bool>)Value;
				((List<bool>)Obj).AddRange(list4.ToArray());
			}
			if (Value.GetType() == typeof(List<string>))
			{
				Obj = new List<string>();
				List<string> list5 = new List<string>();
				list5 = (List<string>)Value;
				((List<string>)Obj).AddRange(list5.ToArray());
			}
			if (Value.GetType() == typeof(List<Pnt2D>))
			{
				Obj = new List<Pnt2D>();
				List<Pnt2D> list6 = new List<Pnt2D>();
				list6 = (List<Pnt2D>)Value;
				((List<Pnt2D>)Obj).AddRange(list6.ToArray());
			}
			if (Value.GetType() == typeof(List<Pnt3D>))
			{
				Obj = new List<Pnt3D>();
				List<Pnt3D> list7 = new List<Pnt3D>();
				list7 = (List<Pnt3D>)Value;
				((List<Pnt3D>)Obj).AddRange(list7.ToArray());
			}
			if (Value.GetType() == typeof(List<Pnt6D>))
			{
				Obj = new List<Pnt6D>();
				List<Pnt6D> list8 = new List<Pnt6D>();
				list8 = (List<Pnt6D>)Value;
				((List<Pnt6D>)Obj).AddRange(list8.ToArray());
			}
			if (Value.GetType() == typeof(List<Pnt9D>))
			{
				Obj = new List<Pnt9D>();
				List<Pnt9D> list9 = new List<Pnt9D>();
				list9 = (List<Pnt9D>)Value;
				((List<Pnt9D>)Obj).AddRange(list9.ToArray());
			}
			if (Value.GetType() == typeof(List<Vec3D>))
			{
				Obj = new List<Vec3D>();
				List<Vec3D> list10 = new List<Vec3D>();
				list10 = (List<Vec3D>)Value;
				((List<Vec3D>)Obj).AddRange(list10.ToArray());
			}
			if (Value.GetType() == typeof(List<OrientationAngle>))
			{
				Obj = new List<OrientationAngle>();
				List<OrientationAngle> list11 = new List<OrientationAngle>();
				list11 = (List<OrientationAngle>)Value;
				((List<OrientationAngle>)Obj).AddRange(list11.ToArray());
			}
			if (Value.GetType() == typeof(List<Line3D>))
			{
				Obj = new List<Line3D>();
				List<Line3D> list12 = new List<Line3D>();
				list12 = (List<Line3D>)Value;
				((List<Line3D>)Obj).AddRange(list12.ToArray());
			}
			if (Value.GetType() == typeof(List<Triangle3D>))
			{
				Obj = new List<Triangle3D>();
				List<Triangle3D> list13 = new List<Triangle3D>();
				list13 = (List<Triangle3D>)Value;
				((List<Triangle3D>)Obj).AddRange(list13.ToArray());
			}
			if (Value.GetType() == typeof(List<Quad3D>))
			{
				Obj = new List<Quad3D>();
				List<Quad3D> list14 = new List<Quad3D>();
				list14 = (List<Quad3D>)Value;
				((List<Quad3D>)Obj).AddRange(list14.ToArray());
			}
			if (Value.GetType() == typeof(List<List<Pnt3D>>))
			{
				Obj = new List<List<Pnt3D>>();
				for (int i = 0; i <= ((List<List<Pnt3D>>)Value).Count - 1; i++)
				{
					List<Pnt3D> list15 = new List<Pnt3D>();
					list15 = ((List<List<Pnt3D>>)Value)[i];
					((List<List<Pnt3D>>)Obj).Add(list15);
				}
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	private static string GetParameterValue(string ParameterValue)
	{
		try
		{
			string[] array = null;
			array = ParameterValue.Split('=');
			if (array != null)
			{
				if (array.Length == 2)
				{
					return array[1].Trim();
				}
				if (array.Length > 2)
				{
					string text = "";
					for (int i = 1; i <= array.Length - 1; i++)
					{
						string text2 = array[i].Trim();
						if (i > 1)
						{
							text2 = "=" + text2;
						}
						if (text2.Length == 0)
						{
							text2 = "=";
						}
						text += text2;
					}
					return text;
				}
			}
			return "";
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			return "";
		}
	}

	private static string GetParameterValue(string ParameterValue, bool UseEqualChar)
	{
		try
		{
			if (UseEqualChar)
			{
				string[] array = null;
				array = ParameterValue.Split('=');
				if (array != null)
				{
					if (array.Length == 2)
					{
						return array[1].Trim();
					}
					if (array.Length > 2)
					{
						string text = "";
						for (int i = 1; i <= array.Length - 1; i++)
						{
							string text2 = array[i].Trim();
							if (i > 1)
							{
								text2 = "=" + text2;
							}
							if (text2.Length == 0)
							{
								text2 = "=";
							}
							text += text2;
						}
						return text;
					}
				}
			}
			else if (ParameterValue.Trim().Length > 0)
			{
				return ParameterValue;
			}
			return "";
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			return "";
		}
	}

	private static bool GetParameterValue(string ParameterValue, ref string Value)
	{
		try
		{
			string[] array = null;
			array = ParameterValue.Split('=');
			if (array != null)
			{
				if (array.Length >= 2)
				{
					Value = array[1].Trim();
					return true;
				}
				if (array.Length == 2)
				{
					Value = array[1].Trim();
					return true;
				}
				if (array.Length > 2)
				{
					for (int i = 1; i <= array.Length - 1; i++)
					{
						string text = array[i].Trim();
						if (i > 1)
						{
							text = "=" + text;
						}
						if (text.Length == 0)
						{
							text = "=";
						}
						Value += text;
					}
					return true;
				}
			}
			return false;
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			return false;
		}
	}

	private static bool GetParameterValue(string ParameterValue, ref string ParName, ref string Value)
	{
		try
		{
			string[] array = null;
			array = ParameterValue.Split('=');
			if (array != null)
			{
				if (array.Length == 2)
				{
					ParName = array[0].Trim();
					Value = array[1].Trim();
					return true;
				}
				if (array.Length > 2)
				{
					ParName = array[0].Trim();
					for (int i = 1; i <= array.Length - 1; i++)
					{
						string text = array[i].Trim();
						if (i > 1)
						{
							text = "=" + text;
						}
						if (text.Length == 0)
						{
							text = "=";
						}
						Value += text;
					}
					return true;
				}
			}
			return false;
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			return false;
		}
	}

	public static string ToDef(Pnt3D P)
	{
		return P.X + " ; " + P.Y + " ; " + P.Z;
	}

	public static string ToDef(Pnt4D P)
	{
		return P.X + " ; " + P.Y + " ; " + P.Z + " ; " + P.W;
	}

	public static string ToDef(Vec3D P)
	{
		return P.X + " ; " + P.Y + " ; " + P.Z;
	}

	public static string ToDef(OrientationAngle P)
	{
		return P.A + " ; " + P.B + " ; " + P.C;
	}

	public static ArrayList ToDef(WorkPlane P, string Char, int Space)
	{
		ArrayList arrayList = new ArrayList();
		string text = Char;
		if (text.Length <= 0)
		{
			text = "WorkPlane";
		}
		arrayList.Add("  <" + text + ">");
		arrayList.Add("  " + ToDef(P));
		arrayList.Add("  </" + text + ">");
		return arrayList;
	}

	public static string ToDef(WorkPlane P)
	{
		return P.Normalies.X + " ; " + P.Normalies.Y + " ; " + P.Normalies.Z;
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
			}
			return "";
		}
		catch (Exception)
		{
			return "";
		}
	}

	public static Pnt4D DecoderFromPoint4D(string Line)
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
						return new Pnt4D(result, result2, result3, 0.0);
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
						return new Pnt4D(result4, result5, result6, result7);
					}
				}
			}
			return new Pnt4D();
		}
		catch (Exception)
		{
			return new Pnt4D();
		}
	}

	public static Vec3D DecoderFromVector3D(string Line)
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
						return new Vec3D(result, result2, result3);
					}
				}
			}
			return new Vec3D();
		}
		catch (Exception)
		{
			return new Vec3D();
		}
	}

	public static WorkPlane DecoderFromPlane(string Line)
	{
		try
		{
			return null;
		}
		catch (Exception)
		{
			return new WorkPlane();
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
						double.TryParse(array[0], out result);
						double.TryParse(array[1], out result2);
						double.TryParse(array[2], out result3);
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

	public static void ClassToString(object ObjPar, ref string Line)
	{
		List<cParameter> Vars = new List<cParameter>();
		GetClassVariables(ObjPar, UseSubClass: false, UseArrayList: false, UseList: false, UseArray: false, ref Vars);
		if (Vars.Count <= 0)
		{
			return;
		}
		for (int i = 0; i <= Vars.Count - 1; i++)
		{
			if (Vars[i].Value != null)
			{
				string text = Vars[i].Value.ToString();
				if (Vars[i].Field.FieldType == typeof(Pnt3D))
				{
					text = ToDef((Pnt3D)Vars[i].Value);
				}
				else if (Vars[i].Field.FieldType == typeof(Vec3D))
				{
					text = ToDef((Vec3D)Vars[i].Value);
				}
				else if (Vars[i].Field.FieldType == typeof(OrientationAngle))
				{
					text = ToDef((OrientationAngle)Vars[i].Value);
				}
				else if (Vars[i].Field.FieldType == typeof(Pnt3D))
				{
					text = ((Pnt3D)Vars[i].Value).ToDef();
				}
				else if (Vars[i].Field.FieldType == typeof(Pnt6D))
				{
					text = ((Pnt6D)Vars[i].Value).ToDef();
				}
				else if (Vars[i].Field.FieldType == typeof(WorkPlane))
				{
					text = ToDef((WorkPlane)Vars[i].Value);
				}
				if (Line.Length == 0)
				{
					Line = Vars[i].Name + ": " + text;
					continue;
				}
				Line = Line + " | " + Vars[i].Name + ": " + text;
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
		List<cParameter> Vars = new List<cParameter>();
		GetClassVariables(ObjPar, UseSubClass: false, UseArrayList: false, UseList: false, UseArray: false, ref Vars);
		for (int i = 0; i <= Vars.Count - 1; i++)
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
}
