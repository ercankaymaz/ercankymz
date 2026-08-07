// Decompiled with JetBrains decompiler
// Type: buClass.buSerilization
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class buSerilization
{
  public static List<string> ExceptionalVariables = new List<string>();

  public string ToDefLine(int Space)
  {
    try
    {
      string str1 = new string(' ', Space);
      List<cParameter> Vars = new List<cParameter>();
      buSerilization.GetClassVariables((object) this, ref Vars);
      string defLine = str1;
      for (int index = 0; index <= Vars.Count - 1; ++index)
      {
        string str2 = "";
        if (index < Vars.Count - 1)
          str2 = " ; ";
        defLine = $"{defLine}{Vars[index].Name} = {Vars[index].ValueAsString}{str2}";
      }
      return defLine;
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return "";
    }
  }

  public ArrayList ToDefNewLine(int Space)
  {
    try
    {
      string str1 = new string(' ', Space);
      List<cParameter> Vars = new List<cParameter>();
      buSerilization.GetClassVariables((object) this, ref Vars);
      ArrayList defNewLine = new ArrayList();
      for (int index1 = 0; index1 <= Vars.Count - 1; ++index1)
      {
        if (index1 != 75)
          ;
        string str2 = Vars[index1].Value.GetType().ToString();
        bool flag1 = false;
        Type type = Vars[index1].Value.GetType();
        if (Vars[index1].Value.GetType() != typeof (ArrayList) & str2.IndexOf("Generic.List") < 0 & !type.IsArray)
        {
          bool flag2 = true;
          for (int index2 = 0; index2 <= buSerilization.ExceptionalVariables.Count - 1; ++index2)
          {
            if (buSerilization.ExceptionalVariables[index2].Trim().ToLower() == Vars[index1].Name.Trim().ToLower())
            {
              flag2 = false;
              index2 = buSerilization.ExceptionalVariables.Count;
            }
          }
          if (flag2)
          {
            if (type.BaseType != (Type) null && (type.Namespace == "buClass" | type.BaseType.Namespace == "buClass" | type.Namespace == "buEyeBaseVer5" | type.BaseType.Namespace == "buEyeBaseVer5" | type.Namespace == "buMW" | type.BaseType.Namespace == "buMW" | type.Namespace.IndexOf("buControls") >= 0) & !type.IsEnum && Vars[index1].Value.GetType().BaseType != typeof (eEntities))
            {
              string str3 = new string(' ', Space);
              defNewLine.Add((object) $"{str3}<{Vars[index1].Name}>");
              defNewLine.AddRange((ICollection) this.ToDefSubClass(Vars[index1].Value, Space + 2).ToArray());
              defNewLine.Add((object) $"{str3}</{Vars[index1].Name}>");
              flag1 = true;
            }
            if (Vars[index1].Value.GetType().BaseType == typeof (eEntities))
              flag1 = true;
            if (!flag1)
            {
              string str4 = this.GetType().Name + ".";
              defNewLine.Add((object) $"{str1}{str4}{Vars[index1].Name} = {Vars[index1].ValueAsString.ToString()}");
            }
          }
        }
        else if (type.IsArray)
          defNewLine.AddRange((ICollection) this.ArrayToStrings(Vars[index1].Name.ToString(), Vars[index1].Value, Space).ToArray());
        else if (Vars[index1].Value.GetType() == typeof (ArrayList))
          defNewLine.AddRange((ICollection) this.ArrayListToStrings(Vars[index1].Name.ToString(), (ArrayList) Vars[index1].Value, Space).ToArray());
        else if (str2.IndexOf("Generic.List") >= 0)
        {
          string[] strArray = str2.Split(new string[1]
          {
            "Generic.List"
          }, StringSplitOptions.None);
          bool flag3 = true;
          for (int index3 = 0; index3 <= buSerilization.ExceptionalVariables.Count - 1; ++index3)
          {
            if (buSerilization.ExceptionalVariables[index3].Trim().ToLower() == Vars[index1].Name.Trim().ToLower())
            {
              flag3 = false;
              index3 = buSerilization.ExceptionalVariables.Count;
            }
          }
          if (flag3)
          {
            if (strArray.Length == 2)
              defNewLine.AddRange((ICollection) this.ListToStrings(Vars[index1].Name.ToString(), Vars[index1].Value, Space).ToArray());
            if (strArray.Length == 3)
              defNewLine.AddRange((ICollection) this.ListListToStrings(Vars[index1].Name.ToString(), Vars[index1].Value, Space).ToArray());
          }
        }
      }
      return defNewLine;
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return new ArrayList();
    }
  }

  public ArrayList ToDefAll(string Char, int Space)
  {
    return this.ToDefAll(Char, Space, SerilizationMode.MultiLine);
  }

  public ArrayList ToDefAll(string Char, int Space, SerilizationMode DefMode)
  {
    ArrayList defAll = new ArrayList();
    string str1 = new string(' ', Space);
    string str2 = new string(' ', Space + 2);
    if (DefMode == SerilizationMode.SingleLine)
    {
      defAll.Add((object) $"{str1}<{this.GetType().Name}{Char}>");
      defAll.Add((object) this.ToDefLine(Space + 2));
      defAll.Add((object) $"{str1}</{this.GetType().Name}{Char}>");
    }
    if (DefMode == SerilizationMode.MultiLine)
    {
      defAll.Add((object) $"{str1}<{this.GetType().Name}{Char}>");
      defAll.AddRange((ICollection) this.ToDefNewLine(Space + 2));
      defAll.Add((object) $"{str1}</{this.GetType().Name}{Char}>");
    }
    if (DefMode == SerilizationMode.SingleLineWithParenthesis)
      defAll.Add((object) $"{str1}{this.GetType().Name}{Char}({this.ToDefLine(0)})");
    return defAll;
  }

  public ArrayList ToDefAll(string Char, int Space, SerilizationMode DefMode, string DefClassName)
  {
    ArrayList defAll = new ArrayList();
    string str1 = new string(' ', Space);
    string str2 = new string(' ', Space + 2);
    if (DefMode == SerilizationMode.SingleLine)
    {
      defAll.Add((object) $"{str1}<{DefClassName}{Char}>");
      defAll.Add((object) this.ToDefLine(Space + 2));
      defAll.Add((object) $"{str1}</{DefClassName}{Char}>");
    }
    if (DefMode == SerilizationMode.MultiLine)
    {
      defAll.Add((object) $"{str1}<{DefClassName}{Char}>");
      defAll.AddRange((ICollection) this.ToDefNewLine(Space + 2));
      defAll.Add((object) $"{str1}</{DefClassName}{Char}>");
    }
    if (DefMode == SerilizationMode.SingleLineWithParenthesis)
      defAll.Add((object) $"{str1}{DefClassName}{Char}({this.ToDefLine(0)})");
    return defAll;
  }

  public static object Decode(ArrayList AL, string Char, SerilizationMode Mode, object Obj)
  {
    object obj = (object) null;
    List<string> CalcList = new List<string>();
    List<string> stringList = new List<string>();
    buStatics.ListToSpecificList($"<{Obj.GetType().Name}{Char}>", $"</{Obj.GetType().Name}{Char}>", AL, ref CalcList);
    if (CalcList.Count > 0)
    {
      List<cParameter> Vars = new List<cParameter>();
      buSerilization.GetClassVariableValuesFromStringCodes(CalcList, Obj, ref Vars);
      if (Vars.Count > 0)
        buSerilization.SetClassVariables(ref Obj, Vars);
    }
    return obj;
  }

  public static object Decode(List<string> SL, string Char, SerilizationMode Mode, object Obj)
  {
    ArrayList AL = new ArrayList();
    AL.AddRange((ICollection) SL.ToArray());
    return buSerilization.Decode(AL, Char, Mode, Obj);
  }

  public static object DecodeProperty(
    ArrayList AL,
    string Char,
    SerilizationMode Mode,
    object Obj)
  {
    object obj = (object) null;
    List<string> CalcList = new List<string>();
    List<string> stringList = new List<string>();
    buStatics.ListToSpecificList($"<{Obj.GetType().Name}{Char}>", $"</{Obj.GetType().Name}{Char}>", AL, ref CalcList);
    if (CalcList.Count > 0)
    {
      List<cParameter> Vars = new List<cParameter>();
      buSerilization.GetClassPropertyVariableValuesFromStringCodes(CalcList, Obj, ref Vars);
      if (Vars.Count > 0)
        buSerilization.SetClassPropertyVariables(ref Obj, Vars);
    }
    return obj;
  }

  public static object DecodeProperty(
    List<string> SL,
    string Char,
    SerilizationMode Mode,
    object Obj)
  {
    ArrayList AL = new ArrayList();
    AL.AddRange((ICollection) SL.ToArray());
    return buSerilization.DecodeProperty(AL, Char, Mode, Obj);
  }

  public static void GetClassVariables(object ObjPar, ref List<cParameter> Vars)
  {
    buSerilization.GetClassVariables(ObjPar, true, true, true, true, ref Vars);
  }

  public static void GetClassVariables(
    object ObjPar,
    bool UseSubClass,
    bool UseArrayList,
    bool UseList,
    bool UseArray,
    ref List<cParameter> Vars)
  {
    try
    {
      Vars.Clear();
      if (ObjPar == null)
        return;
      FieldInfo[] fields = ObjPar.GetType().GetFields();
      PropertyInfo[] properties = ObjPar.GetType().GetProperties();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          if (index != 26)
            ;
          cParameter cParameter = (cParameter) null;
          object obj = (object) null;
          FieldInfo field = fields[index];
          string name1 = field.Name;
          string name2 = field.Name;
          if (ObjPar != null)
            ;
          obj = field.GetValue(ObjPar);
          if (obj == null)
            buSerilization.NullToValue(ref obj, field);
          if (obj != null)
          {
            Type type = obj.GetType();
            if (field.FieldType.ToString().IndexOf("Generic.List") < 0 & field.FieldType.ToString().IndexOf("ArrayList") < 0 & !type.IsArray)
            {
              if (obj.GetType() == typeof (double))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = obj.ToString();
                cParameter.Field = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (int))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = obj.ToString();
                cParameter.Field = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (float))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = obj.ToString();
                cParameter.Field = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (long))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = obj.ToString();
                cParameter.Field = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (uint))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = obj.ToString();
                cParameter.Field = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (bool))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = obj.ToString();
                cParameter.Field = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (byte))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = obj.ToString();
                cParameter.Field = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (string))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = obj.ToString();
                cParameter.Field = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (Color))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = buStatics.ColorToString((Color) obj, ColorConvertType.String);
                cParameter.Field = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (Font))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = buStatics.FontToString((Font) obj);
                cParameter.Field = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (DateTime))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = ((DateTime) obj).ToString();
                cParameter.Field = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (Size))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = $"{((Size) obj).Width.ToString()};{((Size) obj).Height.ToString()}";
                cParameter.Field = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (SizeF))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = $"{((SizeF) obj).Width.ToString()};{((SizeF) obj).Height.ToString()}";
                cParameter.Field = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (Point))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = $"{((Point) obj).X.ToString()};{((Point) obj).Y.ToString()}";
                cParameter.Field = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (PointF))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = $"{((PointF) obj).X.ToString()};{((PointF) obj).Y.ToString()}";
                cParameter.Field = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (Pnt2D))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = ((Pnt2D) obj).ToDef();
                cParameter.Field = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (Pnt3D))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = ((Pnt3D) obj).ToDef();
                cParameter.Field = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (Pnt6D))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = ((Pnt6D) obj).ToDef();
                cParameter.Field = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (Pnt9D))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = ((Pnt9D) obj).ToDef();
                cParameter.Field = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (Vec3D))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = ((Vec3D) obj).ToDef();
                cParameter.Field = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (Length3D))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = ((Length3D) obj).ToDef();
                cParameter.Field = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (OrientationAngle))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = ((OrientationAngle) obj).ToDef();
                cParameter.Field = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (Line3D))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = ((Line3D) obj).ToDef();
                cParameter.Field = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (Triangle3D))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = ((Triangle3D) obj).ToDef();
                cParameter.Field = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (Quad3D))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = ((Quad3D) obj).ToDef();
                cParameter.Field = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (object))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = "";
                cParameter.Field = field;
                cParameter.Types = obj.GetType();
              }
              else
              {
                if (type.IsEnum)
                {
                  cParameter = new cParameter();
                  cParameter.Name = field.Name;
                  cParameter.Value = obj;
                  cParameter.ValueAsString = obj.ToString();
                  cParameter.Field = field;
                  cParameter.Types = obj.GetType();
                }
                if (field.FieldType.BaseType != (Type) null && type.IsClass & (field.FieldType.BaseType.Namespace.IndexOf("buClass") >= 0 | field.FieldType.BaseType.Namespace.IndexOf("buMW") >= 0 | field.FieldType.BaseType.Namespace.IndexOf("buEyeBaseVer5") >= 0 | field.FieldType.Namespace.IndexOf("buClass") >= 0 | field.FieldType.Namespace.IndexOf("buEyeBaseVer5") >= 0) & UseSubClass)
                {
                  cParameter = new cParameter();
                  List<cParameter> Vars1 = new List<cParameter>();
                  buSerilization.GetClassVariables(obj, ref Vars1);
                  cParameter.Name = field.Name;
                  cParameter.Value = obj;
                  cParameter.ValueAsString = obj.ToString();
                  cParameter.Field = field;
                  cParameter.Types = obj.GetType();
                  cParameter.SubParameter = (object) Vars1;
                }
              }
            }
            else
            {
              if (type.IsArray & UseArray)
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = obj.ToString();
                cParameter.Field = field;
                cParameter.Types = obj.GetType();
              }
              if (field.FieldType.ToString().IndexOf("ArrayList") >= 0 & !type.IsArray & UseArrayList)
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = obj.ToString();
                cParameter.Field = field;
                cParameter.Types = obj.GetType();
              }
              else if (field.FieldType.ToString().IndexOf("Generic.List") >= 0 & !type.IsArray & UseList && !field.IsStatic)
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = obj.ToString();
                cParameter.Field = field;
                cParameter.Types = obj.GetType();
              }
            }
          }
          if (cParameter != null)
            Vars.Add(cParameter);
        }
      }
      if (properties != null)
      {
        for (int index = 0; index <= properties.Length - 1; ++index)
        {
          if (index != 26)
            ;
          cParameter cParameter = (cParameter) null;
          object obj = (object) null;
          PropertyInfo field = properties[index];
          string name3 = field.Name;
          string name4 = field.Name;
          if (ObjPar != null)
            ;
          obj = field.GetValue(ObjPar);
          if (obj == null)
            buSerilization.NullToValue(ref obj, field);
          if (obj != null)
          {
            Type type = obj.GetType();
            if (field.PropertyType.ToString().IndexOf("Generic.List") < 0 & field.PropertyType.ToString().IndexOf("ArrayList") < 0 & !type.IsArray)
            {
              if (obj.GetType() == typeof (double))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = obj.ToString();
                cParameter.Property = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (int))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = obj.ToString();
                cParameter.Property = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (float))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = obj.ToString();
                cParameter.Property = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (long))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = obj.ToString();
                cParameter.Property = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (uint))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = obj.ToString();
                cParameter.Property = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (bool))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = obj.ToString();
                cParameter.Property = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (byte))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = obj.ToString();
                cParameter.Property = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (string))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = obj.ToString();
                cParameter.Property = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (Color))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = buStatics.ColorToString((Color) obj, ColorConvertType.String);
                cParameter.Property = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (Font))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = buStatics.FontToString((Font) obj);
                cParameter.Property = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (DateTime))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = ((DateTime) obj).ToString();
                cParameter.Property = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (Size))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = $"{((Size) obj).Width.ToString()};{((Size) obj).Height.ToString()}";
                cParameter.Property = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (SizeF))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = $"{((SizeF) obj).Width.ToString()};{((SizeF) obj).Height.ToString()}";
                cParameter.Property = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (Point))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = $"{((Point) obj).X.ToString()};{((Point) obj).Y.ToString()}";
                cParameter.Property = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (PointF))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = $"{((PointF) obj).X.ToString()};{((PointF) obj).Y.ToString()}";
                cParameter.Property = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (Pnt2D))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = ((Pnt2D) obj).ToDef();
                cParameter.Property = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (Pnt3D))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = ((Pnt3D) obj).ToDef();
                cParameter.Property = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (Pnt6D))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = ((Pnt6D) obj).ToDef();
                cParameter.Property = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (Pnt9D))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = ((Pnt9D) obj).ToDef();
                cParameter.Property = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (Vec3D))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = ((Vec3D) obj).ToDef();
                cParameter.Property = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (Length3D))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = ((Length3D) obj).ToDef();
                cParameter.Property = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (OrientationAngle))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = ((OrientationAngle) obj).ToDef();
                cParameter.Property = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (Line3D))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = ((Line3D) obj).ToDef();
                cParameter.Property = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (Triangle3D))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = ((Triangle3D) obj).ToDef();
                cParameter.Property = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (Quad3D))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = ((Quad3D) obj).ToDef();
                cParameter.Property = field;
                cParameter.Types = obj.GetType();
              }
              else if (obj.GetType() == typeof (object))
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = "";
                cParameter.Property = field;
                cParameter.Types = obj.GetType();
              }
              else
              {
                if (type.IsEnum)
                {
                  cParameter = new cParameter();
                  cParameter.Name = field.Name;
                  cParameter.Value = obj;
                  cParameter.ValueAsString = obj.ToString();
                  cParameter.Property = field;
                  cParameter.Types = obj.GetType();
                }
                if (field.PropertyType.BaseType != (Type) null && type.IsClass & (field.PropertyType.BaseType.Namespace.IndexOf("buClass") >= 0 | field.PropertyType.BaseType.Namespace.IndexOf("buMW") >= 0 | field.PropertyType.BaseType.Namespace.IndexOf("buEyeBaseVer5") >= 0 | field.PropertyType.Namespace.IndexOf("buClass") >= 0 | field.PropertyType.Namespace.IndexOf("buControls") >= 0 | field.PropertyType.Namespace.IndexOf("buEyeBaseVer5") >= 0) & UseSubClass)
                {
                  cParameter = new cParameter();
                  List<cParameter> Vars2 = new List<cParameter>();
                  buSerilization.GetClassVariables(obj, ref Vars2);
                  cParameter.Name = field.Name;
                  cParameter.Value = obj;
                  cParameter.ValueAsString = obj.ToString();
                  cParameter.Property = field;
                  cParameter.Types = obj.GetType();
                  cParameter.SubParameter = (object) Vars2;
                }
              }
            }
            else
            {
              if (type.IsArray & UseArray)
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = obj.ToString();
                cParameter.Property = field;
                cParameter.Types = obj.GetType();
              }
              if (field.PropertyType.ToString().IndexOf("ArrayList") >= 0 & !type.IsArray & UseArrayList)
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = obj.ToString();
                cParameter.Property = field;
                cParameter.Types = obj.GetType();
              }
              else if (field.PropertyType.ToString().IndexOf("Generic.List") >= 0 & !type.IsArray & UseList)
              {
                cParameter = new cParameter();
                cParameter.Name = field.Name;
                cParameter.Value = obj;
                cParameter.ValueAsString = obj.ToString();
                cParameter.Property = field;
                cParameter.Types = obj.GetType();
              }
            }
          }
          if (cParameter != null)
            Vars.Add(cParameter);
        }
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static void GetCaptionsOfClass(object ObjPar, ref List<string> Captions)
  {
    FieldInfo[] fields = ObjPar.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      if (fields[index].IsStatic && fields[index].Name == "Caption" | fields[index].Name == nameof (Captions))
        Captions.AddRange((IEnumerable<string>) ((List<string>) fields[index].GetValue(ObjPar)).ToArray());
    }
  }

  public static void NullToValue(ref object Obj, FieldInfo field)
  {
    if (field.FieldType == typeof (double))
    {
      double num = 0.0;
      Obj = (object) num;
    }
    if (field.FieldType == typeof (int))
    {
      int num = 0;
      Obj = (object) num;
    }
    if (field.FieldType == typeof (float))
    {
      float num = 0.0f;
      Obj = (object) num;
    }
    if (field.FieldType == typeof (long))
    {
      long num = 0;
      Obj = (object) num;
    }
    if (field.FieldType == typeof (uint))
    {
      uint num = 0;
      Obj = (object) num;
    }
    if (field.FieldType == typeof (bool))
    {
      bool flag = false;
      Obj = (object) flag;
    }
    if (field.FieldType == typeof (byte))
    {
      byte num = 0;
      Obj = (object) num;
    }
    if (field.FieldType == typeof (string))
    {
      string str = "";
      Obj = (object) str;
    }
    if (field.FieldType == typeof (Color))
    {
      Color white = Color.White;
      Obj = (object) white;
    }
    if (field.FieldType == typeof (Font))
    {
      Font font = new Font("Arial", 10f);
      Obj = (object) font;
    }
    if (field.FieldType == typeof (DateTime))
    {
      DateTime dateTime = new DateTime();
      Obj = (object) dateTime;
    }
    if (field.FieldType == typeof (Size))
    {
      Size size = new Size();
      Obj = (object) size;
    }
    if (field.FieldType == typeof (SizeF))
    {
      SizeF sizeF = new SizeF();
      Obj = (object) sizeF;
    }
    if (field.FieldType == typeof (Point))
    {
      Point point = new Point();
      Obj = (object) point;
    }
    if (field.FieldType == typeof (PointF))
    {
      PointF pointF = new PointF();
      Obj = (object) pointF;
    }
    if (field.FieldType == typeof (Pnt2D))
    {
      Pnt2D pnt2D = new Pnt2D();
      Obj = (object) pnt2D;
    }
    if (field.FieldType == typeof (Pnt3D))
    {
      Pnt3D pnt3D = new Pnt3D();
      Obj = (object) pnt3D;
    }
    if (field.FieldType == typeof (Pnt6D))
    {
      Pnt6D pnt6D = new Pnt6D();
      Obj = (object) pnt6D;
    }
    if (field.FieldType == typeof (Pnt9D))
    {
      Pnt9D pnt9D = new Pnt9D();
      Obj = (object) pnt9D;
    }
    if (field.FieldType == typeof (Vec3D))
    {
      Vec3D vec3D = new Vec3D();
      Obj = (object) vec3D;
    }
    if (field.FieldType == typeof (Length3D))
    {
      Length3D length3D = new Length3D();
      Obj = (object) length3D;
    }
    if (field.FieldType == typeof (OrientationAngle))
    {
      OrientationAngle orientationAngle = new OrientationAngle();
      Obj = (object) orientationAngle;
    }
    if (field.FieldType == typeof (Line3D))
    {
      Line3D line3D = new Line3D();
      Obj = (object) line3D;
    }
    if (field.FieldType == typeof (Triangle3D))
    {
      Triangle3D triangle3D = new Triangle3D();
      Obj = (object) triangle3D;
    }
    if (!(field.FieldType == typeof (Quad3D)))
      return;
    Quad3D quad3D = new Quad3D();
    Obj = (object) quad3D;
  }

  public static void NullToValue(ref object Obj, PropertyInfo field)
  {
    if (field.PropertyType == typeof (double))
    {
      double num = 0.0;
      Obj = (object) num;
    }
    if (field.PropertyType == typeof (int))
    {
      int num = 0;
      Obj = (object) num;
    }
    if (field.PropertyType == typeof (float))
    {
      float num = 0.0f;
      Obj = (object) num;
    }
    if (field.PropertyType == typeof (long))
    {
      long num = 0;
      Obj = (object) num;
    }
    if (field.PropertyType == typeof (uint))
    {
      uint num = 0;
      Obj = (object) num;
    }
    if (field.PropertyType == typeof (bool))
    {
      bool flag = false;
      Obj = (object) flag;
    }
    if (field.PropertyType == typeof (byte))
    {
      byte num = 0;
      Obj = (object) num;
    }
    if (field.PropertyType == typeof (string))
    {
      string str = "";
      Obj = (object) str;
    }
    if (field.PropertyType == typeof (Color))
    {
      Color white = Color.White;
      Obj = (object) white;
    }
    if (field.PropertyType == typeof (Font))
    {
      Font font = new Font("Arial", 10f);
      Obj = (object) font;
    }
    if (field.PropertyType == typeof (DateTime))
    {
      DateTime dateTime = new DateTime();
      Obj = (object) dateTime;
    }
    if (field.PropertyType == typeof (Size))
    {
      Size size = new Size();
      Obj = (object) size;
    }
    if (field.PropertyType == typeof (SizeF))
    {
      SizeF sizeF = new SizeF();
      Obj = (object) sizeF;
    }
    if (field.PropertyType == typeof (Point))
    {
      Point point = new Point();
      Obj = (object) point;
    }
    if (field.PropertyType == typeof (PointF))
    {
      PointF pointF = new PointF();
      Obj = (object) pointF;
    }
    if (field.PropertyType == typeof (Pnt2D))
    {
      Pnt2D pnt2D = new Pnt2D();
      Obj = (object) pnt2D;
    }
    if (field.PropertyType == typeof (Pnt3D))
    {
      Pnt3D pnt3D = new Pnt3D();
      Obj = (object) pnt3D;
    }
    if (field.PropertyType == typeof (Pnt6D))
    {
      Pnt6D pnt6D = new Pnt6D();
      Obj = (object) pnt6D;
    }
    if (field.PropertyType == typeof (Pnt9D))
    {
      Pnt9D pnt9D = new Pnt9D();
      Obj = (object) pnt9D;
    }
    if (field.PropertyType == typeof (Vec3D))
    {
      Vec3D vec3D = new Vec3D();
      Obj = (object) vec3D;
    }
    if (field.PropertyType == typeof (Length3D))
    {
      Length3D length3D = new Length3D();
      Obj = (object) length3D;
    }
    if (field.PropertyType == typeof (OrientationAngle))
    {
      OrientationAngle orientationAngle = new OrientationAngle();
      Obj = (object) orientationAngle;
    }
    if (field.PropertyType == typeof (Line3D))
    {
      Line3D line3D = new Line3D();
      Obj = (object) line3D;
    }
    if (field.PropertyType == typeof (Triangle3D))
    {
      Triangle3D triangle3D = new Triangle3D();
      Obj = (object) triangle3D;
    }
    if (!(field.PropertyType == typeof (Quad3D)))
      return;
    Quad3D quad3D = new Quad3D();
    Obj = (object) quad3D;
  }

  public static void SetClassVariable(ref object ObjPar, cParameter Var)
  {
    try
    {
      if (ObjPar == null)
        return;
      FieldInfo[] fields = ObjPar.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          object ObjPar1 = (object) null;
          FieldInfo FI = fields[index];
          string name1 = FI.Name;
          string name2 = FI.Name;
          Type fieldType = FI.FieldType;
          if (FI.FieldType.ToString().IndexOf("List") < 0 & !fieldType.IsArray)
          {
            if (FI.Name == Var.Name)
            {
              ObjPar1 = Var.Value;
              if ((fieldType.Namespace == "buClass" | fieldType.BaseType.Namespace == "buClass" | fieldType.Namespace == "buEyeBaseVer5" | fieldType.BaseType.Namespace == "buEyeBaseVer5" | fieldType.Namespace == "buMW" | fieldType.BaseType.Namespace == "buMW") & !fieldType.IsEnum & fieldType.IsClass && (List<cParameter>) Var.SubParameter != null)
              {
                buSerilization.SetClassVariables(ref ObjPar1, (List<cParameter>) Var.SubParameter);
                FI.SetValue(ObjPar, ObjPar1);
              }
              if (ObjPar1 != null)
                buSerilization.SetObjectValueByType(ref FI, ref ObjPar, ObjPar1);
            }
          }
          else if (FI.FieldType.ToString().IndexOf("ArrayList") >= 0 & !fieldType.IsArray)
          {
            if (FI.Name == Var.Name)
            {
              buSerilization.ValueToSetClassArrayList(ref ObjPar1, Var.Value);
              ObjPar1 = Var.Value;
              if (ObjPar1 != null)
                buSerilization.SetObjectValueByType(ref FI, ref ObjPar, ObjPar1);
            }
          }
          else if (FI.FieldType.ToString().IndexOf("Generic.List") >= 0 & !fieldType.IsArray)
          {
            if (FI.Name == Var.Name)
            {
              buSerilization.ValueToSetClassList(ref ObjPar1, Var.Value);
              ObjPar1 = Var.Value;
              if (ObjPar1 != null)
                buSerilization.SetObjectValueByType(ref FI, ref ObjPar, ObjPar1);
            }
          }
          else if (fieldType.IsArray && FI.Name == Var.Name)
          {
            buSerilization.ValueToSetClassArray(ref ObjPar1, Var.Value);
            ObjPar1 = Var.Value;
            if (ObjPar1 != null)
              buSerilization.SetObjectValueByType(ref FI, ref ObjPar, ObjPar1);
          }
        }
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static void SetClassVariables(ref object ObjPar, List<cParameter> Vars)
  {
    try
    {
      if (ObjPar == null)
        return;
      FieldInfo[] fields = ObjPar.GetType().GetFields();
      if (fields != null)
      {
        for (int index1 = 0; index1 <= fields.Length - 1; ++index1)
        {
          if (index1 != 121)
            ;
          object ObjPar1 = (object) null;
          FieldInfo FI = fields[index1];
          string name1 = FI.Name;
          string name2 = FI.Name;
          Type fieldType = FI.FieldType;
          if (FI.FieldType.ToString().IndexOf("List") < 0 & !fieldType.IsArray)
          {
            for (int index2 = 0; index2 <= Vars.Count - 1; ++index2)
            {
              if (FI.Name == Vars[index2].Name.ToString())
              {
                ObjPar1 = Vars[index2].Value;
                index2 = Vars.Count + 1;
              }
            }
            if (fieldType.BaseType != (Type) null)
            {
              if ((fieldType.Namespace == "buClass" | fieldType.BaseType.Namespace == "buClass" | fieldType.Namespace == "buEyeBaseVer5" | fieldType.BaseType.Namespace == "buEyeBaseVer5" | fieldType.Namespace == "buMW" | fieldType.BaseType.Namespace == "buMW") & !fieldType.IsEnum & fieldType.IsClass && index1 <= Vars.Count - 1 && (List<cParameter>) Vars[index1].SubParameter != null)
              {
                buSerilization.SetClassVariables(ref ObjPar1, (List<cParameter>) Vars[index1].SubParameter);
                FI.SetValue(ObjPar, ObjPar1);
              }
            }
            else if ((fieldType.Namespace == "buClass" | fieldType.Namespace == "buEyeBaseVer5" | fieldType.Namespace == "buMW") & !fieldType.IsEnum & fieldType.IsClass && index1 <= Vars.Count - 1 && (List<cParameter>) Vars[index1].SubParameter != null)
            {
              buSerilization.SetClassVariables(ref ObjPar1, (List<cParameter>) Vars[index1].SubParameter);
              FI.SetValue(ObjPar, ObjPar1);
            }
            if (ObjPar1 != null)
              buSerilization.SetObjectValueByType(ref FI, ref ObjPar, ObjPar1);
          }
          else if (FI.FieldType.ToString().IndexOf("ArrayList") >= 0 & !fieldType.IsArray)
          {
            for (int index3 = 0; index3 <= Vars.Count - 1; ++index3)
            {
              if (FI.Name == Vars[index3].Name)
              {
                buSerilization.ValueToSetClassArrayList(ref ObjPar1, Vars[index3].Value);
                ObjPar1 = Vars[index3].Value;
                index3 = Vars.Count + 1;
              }
            }
            if (ObjPar1 != null)
              buSerilization.SetObjectValueByType(ref FI, ref ObjPar, ObjPar1);
          }
          else if (FI.FieldType.ToString().IndexOf("Generic.List") >= 0 & !fieldType.IsArray)
          {
            string[] strArray = FI.FieldType.ToString().Split(new string[1]
            {
              "Generic.List"
            }, StringSplitOptions.None);
            ArrayList arrayList = new ArrayList();
            List<cParameter> cParameterList = new List<cParameter>();
            if (strArray.Length == 2 | strArray.Length == 3)
            {
              for (int index4 = 0; index4 <= Vars.Count - 1; ++index4)
              {
                if (FI.Name == Vars[index4].Name)
                {
                  buSerilization.ValueToSetClassList(ref ObjPar1, Vars[index4].Value);
                  ObjPar1 = Vars[index4].Value;
                  index4 = Vars.Count + 1;
                }
              }
              if (ObjPar1 != null)
                buSerilization.SetObjectValueByType(ref FI, ref ObjPar, ObjPar1);
            }
          }
          else if (fieldType.IsArray)
          {
            for (int index5 = 0; index5 <= Vars.Count - 1; ++index5)
            {
              if (FI.Name == Vars[index5].Name)
              {
                buSerilization.ValueToSetClassArray(ref ObjPar1, Vars[index5].Value);
                ObjPar1 = Vars[index5].Value;
                index5 = Vars.Count + 1;
              }
            }
            if (ObjPar1 != null)
              buSerilization.SetObjectValueByType(ref FI, ref ObjPar, ObjPar1);
          }
        }
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static void SetClassPropertyVariables(ref object ObjPar, List<cParameter> Vars)
  {
    try
    {
      if (ObjPar == null)
        return;
      PropertyInfo[] properties = ObjPar.GetType().GetProperties();
      if (properties != null)
      {
        for (int index1 = 0; index1 <= properties.Length - 1; ++index1)
        {
          if (index1 != 121)
            ;
          object ObjPar1 = (object) null;
          PropertyInfo PI = properties[index1];
          string name1 = PI.Name;
          string name2 = PI.Name;
          Type propertyType = PI.PropertyType;
          if (PI.PropertyType.ToString().IndexOf("List") < 0 & !propertyType.IsArray)
          {
            for (int index2 = 0; index2 <= Vars.Count - 1; ++index2)
            {
              if (PI.Name == Vars[index2].Name.ToString())
              {
                ObjPar1 = Vars[index2].Value;
                index2 = Vars.Count + 1;
              }
            }
            if (propertyType.BaseType != (Type) null)
            {
              if ((propertyType.Namespace == "buClass" | propertyType.BaseType.Namespace == "buClass" | propertyType.Namespace == "buEyeBaseVer5" | propertyType.BaseType.Namespace == "buEyeBaseVer5" | propertyType.Namespace == "buMW" | propertyType.BaseType.Namespace == "buMW") & !propertyType.IsEnum & propertyType.IsClass && index1 <= Vars.Count - 1 && (List<cParameter>) Vars[index1].SubParameter != null)
              {
                buSerilization.SetClassPropertyVariables(ref ObjPar1, (List<cParameter>) Vars[index1].SubParameter);
                PI.SetValue(ObjPar, ObjPar1);
              }
            }
            else if ((propertyType.Namespace == "buClass" | propertyType.Namespace == "buEyeBaseVer5" | propertyType.Namespace == "buMW") & !propertyType.IsEnum & propertyType.IsClass && index1 <= Vars.Count - 1 && (List<cParameter>) Vars[index1].SubParameter != null)
            {
              buSerilization.SetClassPropertyVariables(ref ObjPar1, (List<cParameter>) Vars[index1].SubParameter);
              PI.SetValue(ObjPar, ObjPar1);
            }
            if (ObjPar1 != null)
              buSerilization.SetObjectValueByType(ref PI, ref ObjPar, ObjPar1);
          }
          else if (PI.PropertyType.ToString().IndexOf("ArrayList") >= 0 & !propertyType.IsArray)
          {
            for (int index3 = 0; index3 <= Vars.Count - 1; ++index3)
            {
              if (PI.Name == Vars[index3].Name)
              {
                buSerilization.ValueToSetClassArrayList(ref ObjPar1, Vars[index3].Value);
                ObjPar1 = Vars[index3].Value;
                index3 = Vars.Count + 1;
              }
            }
            if (ObjPar1 != null)
              buSerilization.SetObjectValueByType(ref PI, ref ObjPar, ObjPar1);
          }
          else if (PI.PropertyType.ToString().IndexOf("Generic.List") >= 0 & !propertyType.IsArray)
          {
            string[] strArray = PI.PropertyType.ToString().Split(new string[1]
            {
              "Generic.List"
            }, StringSplitOptions.None);
            ArrayList arrayList = new ArrayList();
            List<cParameter> cParameterList = new List<cParameter>();
            if (strArray.Length == 2 | strArray.Length == 3)
            {
              for (int index4 = 0; index4 <= Vars.Count - 1; ++index4)
              {
                if (PI.Name == Vars[index4].Name)
                {
                  buSerilization.ValueToSetClassList(ref ObjPar1, Vars[index4].Value);
                  ObjPar1 = Vars[index4].Value;
                  index4 = Vars.Count + 1;
                }
              }
              if (ObjPar1 != null)
                buSerilization.SetObjectValueByType(ref PI, ref ObjPar, ObjPar1);
            }
          }
          else if (propertyType.IsArray)
          {
            for (int index5 = 0; index5 <= Vars.Count - 1; ++index5)
            {
              if (PI.Name == Vars[index5].Name)
              {
                buSerilization.ValueToSetClassArray(ref ObjPar1, Vars[index5].Value);
                ObjPar1 = Vars[index5].Value;
                index5 = Vars.Count + 1;
              }
            }
            if (ObjPar1 != null)
              buSerilization.SetObjectValueByType(ref PI, ref ObjPar, ObjPar1);
          }
        }
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static void CopyClass(object RefClass, ref object CopiedClass)
  {
    if (RefClass == null)
      return;
    List<cParameter> Vars = new List<cParameter>();
    buSerilization.GetClassVariables(RefClass, ref Vars);
    CopiedClass = new object();
    CopiedClass = Activator.CreateInstance(RefClass.GetType());
    buSerilization.SetClassVariables(ref CopiedClass, Vars);
  }

  public static void SetObjectValueByType(ref FieldInfo FI, ref object Obj, object Value)
  {
    try
    {
      if (!(FI != (FieldInfo) null))
        return;
      if (FI.FieldType == typeof (double))
      {
        double result = 0.0;
        if (double.TryParse(Value.ToString(), out result))
          FI.SetValue(Obj, (object) result);
      }
      if (FI.FieldType == typeof (float))
      {
        float result = 0.0f;
        if (float.TryParse(Value.ToString(), out result))
          FI.SetValue(Obj, (object) result);
      }
      if (FI.FieldType == typeof (int))
      {
        int result = 0;
        if (int.TryParse(Value.ToString(), out result))
          FI.SetValue(Obj, (object) result);
      }
      if (FI.FieldType == typeof (long))
      {
        long result = 0;
        if (long.TryParse(Value.ToString(), out result))
          FI.SetValue(Obj, (object) result);
      }
      if (FI.FieldType == typeof (uint))
      {
        uint result = 0;
        if (uint.TryParse(Value.ToString(), out result))
          FI.SetValue(Obj, (object) result);
      }
      if (FI.FieldType == typeof (bool))
      {
        bool result = false;
        if (Value.ToString().ToLower() == "false" | Value.ToString().ToLower() == "true")
        {
          if (bool.TryParse(Value.ToString(), out result))
            FI.SetValue(Obj, (object) result);
        }
        else
        {
          string str = "true";
          if (Value.ToString() == "0")
            str = "false";
          if (bool.TryParse(str, out result))
            FI.SetValue(Obj, (object) result);
        }
      }
      if (FI.FieldType == typeof (short))
      {
        short result = 0;
        if (short.TryParse(Value.ToString(), out result))
          FI.SetValue(Obj, (object) result);
      }
      if (FI.FieldType == typeof (string))
        FI.SetValue(Obj, (object) Value.ToString());
      if (FI.FieldType == typeof (long))
      {
        long result = 0;
        if (long.TryParse(Value.ToString(), out result))
          FI.SetValue(Obj, (object) result);
      }
      if (FI.FieldType == typeof (uint))
      {
        uint result = 0;
        if (uint.TryParse(Value.ToString(), out result))
          FI.SetValue(Obj, (object) result);
      }
      if (FI.FieldType == typeof (byte))
      {
        byte result = 0;
        if (byte.TryParse(Value.ToString(), out result))
          FI.SetValue(Obj, (object) result);
      }
      if (FI.FieldType == typeof (Size))
      {
        if (Value.GetType() == typeof (string))
          FI.SetValue(Obj, (object) buStatics.StringToSize(Value.ToString()));
        if (Value.GetType() == typeof (Size))
          FI.SetValue(Obj, Value);
      }
      if (FI.FieldType == typeof (SizeF))
      {
        if (Value.GetType() == typeof (string))
          FI.SetValue(Obj, (object) buStatics.StringToSizeF(Value.ToString()));
        if (Value.GetType() == typeof (SizeF))
          FI.SetValue(Obj, Value);
      }
      if (FI.FieldType == typeof (Point))
      {
        if (Value.GetType() == typeof (string))
          FI.SetValue(Obj, (object) buStatics.StringToPoint(Value.ToString()));
        if (Value.GetType() == typeof (Point))
          FI.SetValue(Obj, Value);
      }
      if (FI.FieldType == typeof (PointF))
      {
        if (Value.GetType() == typeof (string))
          FI.SetValue(Obj, (object) buStatics.StringToPointF(Value.ToString()));
        if (Value.GetType() == typeof (PointF))
          FI.SetValue(Obj, Value);
      }
      if (FI.FieldType.BaseType == typeof (Enum))
      {
        EnumConverter enumConverter = new EnumConverter(FI.FieldType);
        FI.SetValue(Obj, enumConverter.ConvertFromString(Value.ToString()));
      }
      if (FI.FieldType == typeof (Color))
        FI.SetValue(Obj, (object) buStatics.StringToColor(Value.ToString(), ColorConvertType.String));
      if (FI.FieldType == typeof (Font))
      {
        FontConverter fontConverter = new FontConverter();
        if (Value.GetType() == typeof (string))
          FI.SetValue(Obj, (object) buStatics.StringToFont(Value.ToString()));
        if (Value.GetType() == typeof (Font))
          FI.SetValue(Obj, Value);
      }
      if (FI.FieldType == typeof (DateTime))
        FI.SetValue(Obj, (object) buStatics.StringToDateTime(Value.ToString()));
      if (FI.FieldType == typeof (Pnt2D))
      {
        Pnt2D pnt2D1 = new Pnt2D();
        Pnt2D pnt2D2 = Pnt2D.DecodeFromString(((Pnt2D) Value).ToDef());
        FI.SetValue(Obj, (object) pnt2D2);
      }
      if (FI.FieldType == typeof (Pnt3D))
      {
        Pnt3D pnt3D1 = new Pnt3D();
        Pnt3D pnt3D2 = Pnt3D.DecodeFromString(((Pnt3D) Value).ToDef());
        FI.SetValue(Obj, (object) pnt3D2);
      }
      if (FI.FieldType == typeof (Pnt6D))
      {
        Pnt6D pnt6D1 = new Pnt6D();
        Pnt6D pnt6D2 = Pnt6D.DecodeFromString(((Pnt6D) Value).ToDef());
        FI.SetValue(Obj, (object) pnt6D2);
      }
      if (FI.FieldType == typeof (Pnt9D))
      {
        Pnt9D pnt9D1 = new Pnt9D();
        Pnt9D pnt9D2 = Pnt9D.DecodeFromString(((Pnt9D) Value).ToDef());
        FI.SetValue(Obj, (object) pnt9D2);
      }
      if (FI.FieldType == typeof (Vec3D))
      {
        Vec3D vec3D1 = new Vec3D();
        Vec3D vec3D2 = Vec3D.DecodeFromString(((Vec3D) Value).ToDef());
        FI.SetValue(Obj, (object) vec3D2);
      }
      if (FI.FieldType == typeof (Length3D))
      {
        Length3D length3D1 = new Length3D();
        Length3D length3D2 = Length3D.DecodeFromString(((Length3D) Value).ToDef());
        FI.SetValue(Obj, (object) length3D2);
      }
      if (FI.FieldType == typeof (OrientationAngle))
      {
        OrientationAngle orientationAngle1 = new OrientationAngle();
        OrientationAngle orientationAngle2 = OrientationAngle.DecodeFromString(((OrientationAngle) Value).ToDef());
        FI.SetValue(Obj, (object) orientationAngle2);
      }
      if (FI.FieldType == typeof (Line3D))
      {
        Line3D line3D1 = new Line3D();
        Line3D line3D2 = Line3D.DecodeFromString(((Line3D) Value).ToDef());
        FI.SetValue(Obj, (object) line3D2);
      }
      if (FI.FieldType == typeof (Triangle3D))
      {
        Triangle3D triangle3D1 = new Triangle3D();
        Triangle3D triangle3D2 = Triangle3D.DecodeFromString(((Triangle3D) Value).ToDef());
        FI.SetValue(Obj, (object) triangle3D2);
      }
      if (FI.FieldType == typeof (Quad3D))
      {
        Quad3D quad3D1 = new Quad3D();
        Quad3D quad3D2 = Quad3D.DecodeFromString(((Quad3D) Value).ToDef());
        FI.SetValue(Obj, (object) quad3D2);
      }
      if (FI.FieldType == typeof (object))
      {
        object obj1 = new object();
        object obj2 = Value;
        FI.SetValue(Obj, obj2);
      }
      if (FI.FieldType == typeof (ArrayList))
      {
        ArrayList arrayList = new ArrayList();
        if (Value.GetType() == typeof (ArrayList))
          arrayList.AddRange((ICollection) ((ArrayList) Value).ToArray());
        FI.SetValue(Obj, (object) arrayList);
      }
      if (FI.FieldType == typeof (List<double>))
      {
        List<double> doubleList = new List<double>();
        if (Value.GetType() == typeof (List<double>))
          doubleList.AddRange((IEnumerable<double>) ((List<double>) Value).ToArray());
        FI.SetValue(Obj, (object) doubleList);
      }
      if (FI.FieldType == typeof (List<int>))
      {
        List<int> intList = new List<int>();
        if (Value.GetType() == typeof (List<int>))
          intList.AddRange((IEnumerable<int>) ((List<int>) Value).ToArray());
        FI.SetValue(Obj, (object) intList);
      }
      if (FI.FieldType == typeof (List<float>))
      {
        List<float> floatList = new List<float>();
        if (Value.GetType() == typeof (List<float>))
          floatList.AddRange((IEnumerable<float>) ((List<float>) Value).ToArray());
        FI.SetValue(Obj, (object) floatList);
      }
      if (FI.FieldType == typeof (List<bool>))
      {
        List<bool> boolList = new List<bool>();
        if (Value.GetType() == typeof (List<bool>))
          boolList.AddRange((IEnumerable<bool>) ((List<bool>) Value).ToArray());
        FI.SetValue(Obj, (object) boolList);
      }
      if (FI.FieldType == typeof (List<string>))
      {
        List<string> stringList = new List<string>();
        if (Value.GetType() == typeof (List<string>))
          stringList.AddRange((IEnumerable<string>) ((List<string>) Value).ToArray());
        FI.SetValue(Obj, (object) stringList);
      }
      if (FI.FieldType == typeof (List<Pnt2D>))
      {
        List<Pnt2D> pnt2DList = new List<Pnt2D>();
        if (Value.GetType() == typeof (List<Pnt2D>))
          pnt2DList.AddRange((IEnumerable<Pnt2D>) ((List<Pnt2D>) Value).ToArray());
        FI.SetValue(Obj, (object) pnt2DList);
      }
      if (FI.FieldType == typeof (List<Pnt3D>))
      {
        List<Pnt3D> pnt3DList = new List<Pnt3D>();
        if (Value.GetType() == typeof (List<Pnt3D>))
          pnt3DList.AddRange((IEnumerable<Pnt3D>) ((List<Pnt3D>) Value).ToArray());
        FI.SetValue(Obj, (object) pnt3DList);
      }
      if (FI.FieldType == typeof (List<Pnt6D>))
      {
        List<Pnt6D> pnt6DList = new List<Pnt6D>();
        if (Value.GetType() == typeof (List<Pnt6D>))
          pnt6DList.AddRange((IEnumerable<Pnt6D>) ((List<Pnt6D>) Value).ToArray());
        FI.SetValue(Obj, (object) pnt6DList);
      }
      if (FI.FieldType == typeof (List<Pnt9D>))
      {
        List<Pnt9D> pnt9DList = new List<Pnt9D>();
        if (Value.GetType() == typeof (List<Pnt9D>))
          pnt9DList.AddRange((IEnumerable<Pnt9D>) ((List<Pnt9D>) Value).ToArray());
        FI.SetValue(Obj, (object) pnt9DList);
      }
      if (FI.FieldType == typeof (List<Vec3D>))
      {
        List<Vec3D> vec3DList = new List<Vec3D>();
        if (Value.GetType() == typeof (List<Vec3D>))
          vec3DList.AddRange((IEnumerable<Vec3D>) ((List<Vec3D>) Value).ToArray());
        FI.SetValue(Obj, (object) vec3DList);
      }
      if (FI.FieldType == typeof (List<OrientationAngle>))
      {
        List<OrientationAngle> orientationAngleList = new List<OrientationAngle>();
        if (Value.GetType() == typeof (List<OrientationAngle>))
          orientationAngleList.AddRange((IEnumerable<OrientationAngle>) ((List<OrientationAngle>) Value).ToArray());
        FI.SetValue(Obj, (object) orientationAngleList);
      }
      if (FI.FieldType == typeof (List<Line3D>))
      {
        List<Line3D> line3DList = new List<Line3D>();
        if (Value.GetType() == typeof (List<Line3D>))
          line3DList.AddRange((IEnumerable<Line3D>) ((List<Line3D>) Value).ToArray());
        FI.SetValue(Obj, (object) line3DList);
      }
      if (FI.FieldType == typeof (List<Triangle3D>))
      {
        List<Triangle3D> triangle3DList = new List<Triangle3D>();
        if (Value.GetType() == typeof (List<Triangle3D>))
          triangle3DList.AddRange((IEnumerable<Triangle3D>) ((List<Triangle3D>) Value).ToArray());
        FI.SetValue(Obj, (object) triangle3DList);
      }
      if (FI.FieldType == typeof (List<Quad3D>))
      {
        List<Quad3D> quad3DList = new List<Quad3D>();
        if (Value.GetType() == typeof (List<Quad3D>))
          quad3DList.AddRange((IEnumerable<Quad3D>) ((List<Quad3D>) Value).ToArray());
        FI.SetValue(Obj, (object) quad3DList);
      }
      if (FI.FieldType == typeof (List<List<Pnt3D>>))
      {
        List<List<Pnt3D>> pnt3DListList = new List<List<Pnt3D>>();
        if (Value.GetType() == typeof (List<List<Pnt3D>>))
        {
          for (int index = 0; index <= ((List<List<Pnt3D>>) Value).Count - 1; ++index)
          {
            List<Pnt3D> pnt3DList = new List<Pnt3D>();
            pnt3DList.AddRange((IEnumerable<Pnt3D>) ((List<List<Pnt3D>>) Value)[index].ToArray());
            pnt3DListList.Add(pnt3DList);
          }
          FI.SetValue(Obj, (object) pnt3DListList);
        }
      }
      if (FI.FieldType == typeof (double[]))
      {
        try
        {
          double[] numArray = new double[((double[]) Value).Length];
          if (Value.GetType() == typeof (double[]))
          {
            for (int index = 0; index <= ((double[]) Value).Length - 1; ++index)
              numArray[index] = ((double[]) Value)[index];
          }
          FI.SetValue(Obj, (object) numArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (FI.FieldType == typeof (float[]))
      {
        if (Value != null)
        {
          try
          {
            float[] numArray = new float[((float[]) Value).Length];
            if (Value.GetType() == typeof (float[]))
            {
              for (int index = 0; index <= ((float[]) Value).Length - 1; ++index)
                numArray[index] = ((float[]) Value)[index];
            }
            FI.SetValue(Obj, (object) numArray);
          }
          catch (Exception ex)
          {
          }
        }
      }
      if (FI.FieldType == typeof (int[]))
      {
        try
        {
          int[] numArray = new int[((int[]) Value).Length];
          if (Value.GetType() == typeof (int[]))
          {
            for (int index = 0; index <= ((int[]) Value).Length - 1; ++index)
              numArray[index] = ((int[]) Value)[index];
          }
          FI.SetValue(Obj, (object) numArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (FI.FieldType == typeof (bool[]))
      {
        try
        {
          bool[] flagArray = new bool[((bool[]) Value).Length];
          if (Value.GetType() == typeof (bool[]))
          {
            for (int index = 0; index <= ((bool[]) Value).Length - 1; ++index)
              flagArray[index] = ((bool[]) Value)[index];
          }
          FI.SetValue(Obj, (object) flagArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (FI.FieldType == typeof (string[]))
      {
        try
        {
          string[] strArray = new string[((string[]) Value).Length];
          if (Value.GetType() == typeof (string[]))
          {
            for (int index = 0; index <= ((string[]) Value).Length - 1; ++index)
              strArray[index] = ((string[]) Value)[index];
          }
          FI.SetValue(Obj, (object) strArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (FI.FieldType == typeof (Pnt2D[]))
      {
        try
        {
          Pnt2D[] pnt2DArray = new Pnt2D[((Pnt2D[]) Value).Length];
          if (Value.GetType() == typeof (Pnt2D[]))
          {
            for (int index = 0; index <= ((Pnt2D[]) Value).Length - 1; ++index)
              pnt2DArray[index] = ((Pnt2D[]) Value)[index];
          }
          FI.SetValue(Obj, (object) pnt2DArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (FI.FieldType == typeof (Pnt3D[]))
      {
        try
        {
          Pnt3D[] pnt3DArray = new Pnt3D[((Pnt3D[]) Value).Length];
          if (Value.GetType() == typeof (Pnt3D[]))
          {
            for (int index = 0; index <= ((Pnt3D[]) Value).Length - 1; ++index)
              pnt3DArray[index] = ((Pnt3D[]) Value)[index];
          }
          FI.SetValue(Obj, (object) pnt3DArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (FI.FieldType == typeof (Pnt6D[]))
      {
        try
        {
          Pnt6D[] pnt6DArray = new Pnt6D[((Pnt6D[]) Value).Length];
          if (Value.GetType() == typeof (Pnt6D[]))
          {
            for (int index = 0; index <= ((Pnt6D[]) Value).Length - 1; ++index)
              pnt6DArray[index] = ((Pnt6D[]) Value)[index];
          }
          FI.SetValue(Obj, (object) pnt6DArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (FI.FieldType == typeof (Pnt9D[]))
      {
        try
        {
          Pnt9D[] pnt9DArray = new Pnt9D[((Pnt9D[]) Value).Length];
          if (Value.GetType() == typeof (Pnt9D[]))
          {
            for (int index = 0; index <= ((Pnt9D[]) Value).Length - 1; ++index)
              pnt9DArray[index] = ((Pnt9D[]) Value)[index];
          }
          FI.SetValue(Obj, (object) pnt9DArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (FI.FieldType == typeof (Vec3D[]))
      {
        try
        {
          Vec3D[] vec3DArray = new Vec3D[((Vec3D[]) Value).Length];
          if (Value.GetType() == typeof (Vec3D[]))
          {
            for (int index = 0; index <= ((Vec3D[]) Value).Length - 1; ++index)
              vec3DArray[index] = ((Vec3D[]) Value)[index];
          }
          FI.SetValue(Obj, (object) vec3DArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (FI.FieldType == typeof (OrientationAngle[]))
      {
        try
        {
          OrientationAngle[] orientationAngleArray = new OrientationAngle[((OrientationAngle[]) Value).Length];
          if (Value.GetType() == typeof (OrientationAngle[]))
          {
            for (int index = 0; index <= ((OrientationAngle[]) Value).Length - 1; ++index)
              orientationAngleArray[index] = ((OrientationAngle[]) Value)[index];
          }
          FI.SetValue(Obj, (object) orientationAngleArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (FI.FieldType == typeof (Line3D[]))
      {
        try
        {
          Line3D[] line3DArray = new Line3D[((Line3D[]) Value).Length];
          if (Value.GetType() == typeof (Line3D[]))
          {
            for (int index = 0; index <= ((Line3D[]) Value).Length - 1; ++index)
              line3DArray[index] = ((Line3D[]) Value)[index];
          }
          FI.SetValue(Obj, (object) line3DArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (FI.FieldType == typeof (Triangle3D[]))
      {
        try
        {
          Triangle3D[] triangle3DArray = new Triangle3D[((Triangle3D[]) Value).Length];
          if (Value.GetType() == typeof (Triangle3D[]))
          {
            for (int index = 0; index <= ((Triangle3D[]) Value).Length - 1; ++index)
              triangle3DArray[index] = ((Triangle3D[]) Value)[index];
          }
          FI.SetValue(Obj, (object) triangle3DArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (FI.FieldType == typeof (Quad3D[]))
      {
        try
        {
          Quad3D[] quad3DArray = new Quad3D[((Quad3D[]) Value).Length];
          if (Value.GetType() == typeof (Quad3D[]))
          {
            for (int index = 0; index <= ((Quad3D[]) Value).Length - 1; ++index)
              quad3DArray[index] = ((Quad3D[]) Value)[index];
          }
          FI.SetValue(Obj, (object) quad3DArray);
        }
        catch (Exception ex)
        {
        }
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static void SetObjectValueByType(ref PropertyInfo PI, ref object Obj, object Value)
  {
    try
    {
      if (!(PI != (PropertyInfo) null))
        return;
      if (PI.PropertyType == typeof (double))
      {
        double result = 0.0;
        if (double.TryParse(Value.ToString(), out result))
          PI.SetValue(Obj, (object) result);
      }
      if (PI.PropertyType == typeof (float))
      {
        float result = 0.0f;
        if (float.TryParse(Value.ToString(), out result))
          PI.SetValue(Obj, (object) result);
      }
      if (PI.PropertyType == typeof (int))
      {
        int result = 0;
        if (int.TryParse(Value.ToString(), out result))
          PI.SetValue(Obj, (object) result);
      }
      if (PI.PropertyType == typeof (long))
      {
        long result = 0;
        if (long.TryParse(Value.ToString(), out result))
          PI.SetValue(Obj, (object) result);
      }
      if (PI.PropertyType == typeof (uint))
      {
        uint result = 0;
        if (uint.TryParse(Value.ToString(), out result))
          PI.SetValue(Obj, (object) result);
      }
      if (PI.PropertyType == typeof (bool))
      {
        bool result = false;
        if (Value.ToString().ToLower() == "false" | Value.ToString().ToLower() == "true")
        {
          if (bool.TryParse(Value.ToString(), out result))
            PI.SetValue(Obj, (object) result);
        }
        else
        {
          string str = "true";
          if (Value.ToString() == "0")
            str = "false";
          if (bool.TryParse(str, out result))
            PI.SetValue(Obj, (object) result);
        }
      }
      if (PI.PropertyType == typeof (short))
      {
        short result = 0;
        if (short.TryParse(Value.ToString(), out result))
          PI.SetValue(Obj, (object) result);
      }
      if (PI.PropertyType == typeof (string))
        PI.SetValue(Obj, (object) Value.ToString());
      if (PI.PropertyType == typeof (long))
      {
        long result = 0;
        if (long.TryParse(Value.ToString(), out result))
          PI.SetValue(Obj, (object) result);
      }
      if (PI.PropertyType == typeof (uint))
      {
        uint result = 0;
        if (uint.TryParse(Value.ToString(), out result))
          PI.SetValue(Obj, (object) result);
      }
      if (PI.PropertyType == typeof (byte))
      {
        byte result = 0;
        if (byte.TryParse(Value.ToString(), out result))
          PI.SetValue(Obj, (object) result);
      }
      if (PI.PropertyType == typeof (Size))
      {
        if (Value.GetType() == typeof (string))
          PI.SetValue(Obj, (object) buStatics.StringToSize(Value.ToString()));
        if (Value.GetType() == typeof (Size))
          PI.SetValue(Obj, Value);
      }
      if (PI.PropertyType == typeof (SizeF))
      {
        if (Value.GetType() == typeof (string))
          PI.SetValue(Obj, (object) buStatics.StringToSizeF(Value.ToString()));
        if (Value.GetType() == typeof (SizeF))
          PI.SetValue(Obj, Value);
      }
      if (PI.PropertyType == typeof (Point))
      {
        if (Value.GetType() == typeof (string))
          PI.SetValue(Obj, (object) buStatics.StringToPoint(Value.ToString()));
        if (Value.GetType() == typeof (Point))
          PI.SetValue(Obj, Value);
      }
      if (PI.PropertyType == typeof (PointF))
      {
        if (Value.GetType() == typeof (string))
          PI.SetValue(Obj, (object) buStatics.StringToPointF(Value.ToString()));
        if (Value.GetType() == typeof (PointF))
          PI.SetValue(Obj, Value);
      }
      if (PI.PropertyType.BaseType == typeof (Enum))
      {
        EnumConverter enumConverter = new EnumConverter(PI.PropertyType);
        PI.SetValue(Obj, enumConverter.ConvertFromString(Value.ToString()));
      }
      if (PI.PropertyType == typeof (Color))
        PI.SetValue(Obj, (object) buStatics.StringToColor(Value.ToString(), ColorConvertType.String));
      if (PI.PropertyType == typeof (Font))
      {
        FontConverter fontConverter = new FontConverter();
        if (Value.GetType() == typeof (string))
          PI.SetValue(Obj, (object) buStatics.StringToFont(Value.ToString()));
        if (Value.GetType() == typeof (Font))
          PI.SetValue(Obj, Value);
      }
      if (PI.PropertyType == typeof (DateTime))
        PI.SetValue(Obj, (object) buStatics.StringToDateTime(Value.ToString()));
      if (PI.PropertyType == typeof (Pnt2D))
      {
        Pnt2D pnt2D1 = new Pnt2D();
        Pnt2D pnt2D2 = Pnt2D.DecodeFromString(((Pnt2D) Value).ToDef());
        PI.SetValue(Obj, (object) pnt2D2);
      }
      if (PI.PropertyType == typeof (Pnt3D))
      {
        Pnt3D pnt3D1 = new Pnt3D();
        Pnt3D pnt3D2 = Pnt3D.DecodeFromString(((Pnt3D) Value).ToDef());
        PI.SetValue(Obj, (object) pnt3D2);
      }
      if (PI.PropertyType == typeof (Pnt6D))
      {
        Pnt6D pnt6D1 = new Pnt6D();
        Pnt6D pnt6D2 = Pnt6D.DecodeFromString(((Pnt6D) Value).ToDef());
        PI.SetValue(Obj, (object) pnt6D2);
      }
      if (PI.PropertyType == typeof (Pnt9D))
      {
        Pnt9D pnt9D1 = new Pnt9D();
        Pnt9D pnt9D2 = Pnt9D.DecodeFromString(((Pnt9D) Value).ToDef());
        PI.SetValue(Obj, (object) pnt9D2);
      }
      if (PI.PropertyType == typeof (Vec3D))
      {
        Vec3D vec3D1 = new Vec3D();
        Vec3D vec3D2 = Vec3D.DecodeFromString(((Vec3D) Value).ToDef());
        PI.SetValue(Obj, (object) vec3D2);
      }
      if (PI.PropertyType == typeof (Length3D))
      {
        Length3D length3D1 = new Length3D();
        Length3D length3D2 = Length3D.DecodeFromString(((Length3D) Value).ToDef());
        PI.SetValue(Obj, (object) length3D2);
      }
      if (PI.PropertyType == typeof (OrientationAngle))
      {
        OrientationAngle orientationAngle1 = new OrientationAngle();
        OrientationAngle orientationAngle2 = OrientationAngle.DecodeFromString(((OrientationAngle) Value).ToDef());
        PI.SetValue(Obj, (object) orientationAngle2);
      }
      if (PI.PropertyType == typeof (Line3D))
      {
        Line3D line3D1 = new Line3D();
        Line3D line3D2 = Line3D.DecodeFromString(((Line3D) Value).ToDef());
        PI.SetValue(Obj, (object) line3D2);
      }
      if (PI.PropertyType == typeof (Triangle3D))
      {
        Triangle3D triangle3D1 = new Triangle3D();
        Triangle3D triangle3D2 = Triangle3D.DecodeFromString(((Triangle3D) Value).ToDef());
        PI.SetValue(Obj, (object) triangle3D2);
      }
      if (PI.PropertyType == typeof (Quad3D))
      {
        Quad3D quad3D1 = new Quad3D();
        Quad3D quad3D2 = Quad3D.DecodeFromString(((Quad3D) Value).ToDef());
        PI.SetValue(Obj, (object) quad3D2);
      }
      if (PI.PropertyType == typeof (object))
      {
        object obj1 = new object();
        object obj2 = Value;
        PI.SetValue(Obj, obj2);
      }
      if (PI.PropertyType == typeof (ArrayList))
      {
        ArrayList arrayList = new ArrayList();
        if (Value.GetType() == typeof (ArrayList))
          arrayList.AddRange((ICollection) ((ArrayList) Value).ToArray());
        PI.SetValue(Obj, (object) arrayList);
      }
      if (PI.PropertyType == typeof (List<double>))
      {
        List<double> doubleList = new List<double>();
        if (Value.GetType() == typeof (List<double>))
          doubleList.AddRange((IEnumerable<double>) ((List<double>) Value).ToArray());
        PI.SetValue(Obj, (object) doubleList);
      }
      if (PI.PropertyType == typeof (List<int>))
      {
        List<int> intList = new List<int>();
        if (Value.GetType() == typeof (List<int>))
          intList.AddRange((IEnumerable<int>) ((List<int>) Value).ToArray());
        PI.SetValue(Obj, (object) intList);
      }
      if (PI.PropertyType == typeof (List<float>))
      {
        List<float> floatList = new List<float>();
        if (Value.GetType() == typeof (List<float>))
          floatList.AddRange((IEnumerable<float>) ((List<float>) Value).ToArray());
        PI.SetValue(Obj, (object) floatList);
      }
      if (PI.PropertyType == typeof (List<bool>))
      {
        List<bool> boolList = new List<bool>();
        if (Value.GetType() == typeof (List<bool>))
          boolList.AddRange((IEnumerable<bool>) ((List<bool>) Value).ToArray());
        PI.SetValue(Obj, (object) boolList);
      }
      if (PI.PropertyType == typeof (List<string>))
      {
        List<string> stringList = new List<string>();
        if (Value.GetType() == typeof (List<string>))
          stringList.AddRange((IEnumerable<string>) ((List<string>) Value).ToArray());
        PI.SetValue(Obj, (object) stringList);
      }
      if (PI.PropertyType == typeof (List<Pnt2D>))
      {
        List<Pnt2D> pnt2DList = new List<Pnt2D>();
        if (Value.GetType() == typeof (List<Pnt2D>))
          pnt2DList.AddRange((IEnumerable<Pnt2D>) ((List<Pnt2D>) Value).ToArray());
        PI.SetValue(Obj, (object) pnt2DList);
      }
      if (PI.PropertyType == typeof (List<Pnt3D>))
      {
        List<Pnt3D> pnt3DList = new List<Pnt3D>();
        if (Value.GetType() == typeof (List<Pnt3D>))
          pnt3DList.AddRange((IEnumerable<Pnt3D>) ((List<Pnt3D>) Value).ToArray());
        PI.SetValue(Obj, (object) pnt3DList);
      }
      if (PI.PropertyType == typeof (List<Pnt6D>))
      {
        List<Pnt6D> pnt6DList = new List<Pnt6D>();
        if (Value.GetType() == typeof (List<Pnt6D>))
          pnt6DList.AddRange((IEnumerable<Pnt6D>) ((List<Pnt6D>) Value).ToArray());
        PI.SetValue(Obj, (object) pnt6DList);
      }
      if (PI.PropertyType == typeof (List<Pnt9D>))
      {
        List<Pnt9D> pnt9DList = new List<Pnt9D>();
        if (Value.GetType() == typeof (List<Pnt9D>))
          pnt9DList.AddRange((IEnumerable<Pnt9D>) ((List<Pnt9D>) Value).ToArray());
        PI.SetValue(Obj, (object) pnt9DList);
      }
      if (PI.PropertyType == typeof (List<Vec3D>))
      {
        List<Vec3D> vec3DList = new List<Vec3D>();
        if (Value.GetType() == typeof (List<Vec3D>))
          vec3DList.AddRange((IEnumerable<Vec3D>) ((List<Vec3D>) Value).ToArray());
        PI.SetValue(Obj, (object) vec3DList);
      }
      if (PI.PropertyType == typeof (List<OrientationAngle>))
      {
        List<OrientationAngle> orientationAngleList = new List<OrientationAngle>();
        if (Value.GetType() == typeof (List<OrientationAngle>))
          orientationAngleList.AddRange((IEnumerable<OrientationAngle>) ((List<OrientationAngle>) Value).ToArray());
        PI.SetValue(Obj, (object) orientationAngleList);
      }
      if (PI.PropertyType == typeof (List<Line3D>))
      {
        List<Line3D> line3DList = new List<Line3D>();
        if (Value.GetType() == typeof (List<Line3D>))
          line3DList.AddRange((IEnumerable<Line3D>) ((List<Line3D>) Value).ToArray());
        PI.SetValue(Obj, (object) line3DList);
      }
      if (PI.PropertyType == typeof (List<Triangle3D>))
      {
        List<Triangle3D> triangle3DList = new List<Triangle3D>();
        if (Value.GetType() == typeof (List<Triangle3D>))
          triangle3DList.AddRange((IEnumerable<Triangle3D>) ((List<Triangle3D>) Value).ToArray());
        PI.SetValue(Obj, (object) triangle3DList);
      }
      if (PI.PropertyType == typeof (List<Quad3D>))
      {
        List<Quad3D> quad3DList = new List<Quad3D>();
        if (Value.GetType() == typeof (List<Quad3D>))
          quad3DList.AddRange((IEnumerable<Quad3D>) ((List<Quad3D>) Value).ToArray());
        PI.SetValue(Obj, (object) quad3DList);
      }
      if (PI.PropertyType == typeof (List<List<Pnt3D>>))
      {
        List<List<Pnt3D>> pnt3DListList = new List<List<Pnt3D>>();
        if (Value.GetType() == typeof (List<List<Pnt3D>>))
        {
          for (int index = 0; index <= ((List<List<Pnt3D>>) Value).Count - 1; ++index)
          {
            List<Pnt3D> pnt3DList = new List<Pnt3D>();
            pnt3DList.AddRange((IEnumerable<Pnt3D>) ((List<List<Pnt3D>>) Value)[index].ToArray());
            pnt3DListList.Add(pnt3DList);
          }
          PI.SetValue(Obj, (object) pnt3DListList);
        }
      }
      if (PI.PropertyType == typeof (double[]))
      {
        try
        {
          double[] numArray = new double[((double[]) Value).Length];
          if (Value.GetType() == typeof (double[]))
          {
            for (int index = 0; index <= ((double[]) Value).Length - 1; ++index)
              numArray[index] = ((double[]) Value)[index];
          }
          PI.SetValue(Obj, (object) numArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (PI.PropertyType == typeof (float[]))
      {
        if (Value != null)
        {
          try
          {
            float[] numArray = new float[((float[]) Value).Length];
            if (Value.GetType() == typeof (float[]))
            {
              for (int index = 0; index <= ((float[]) Value).Length - 1; ++index)
                numArray[index] = ((float[]) Value)[index];
            }
            PI.SetValue(Obj, (object) numArray);
          }
          catch (Exception ex)
          {
          }
        }
      }
      if (PI.PropertyType == typeof (int[]))
      {
        try
        {
          int[] numArray = new int[((int[]) Value).Length];
          if (Value.GetType() == typeof (int[]))
          {
            for (int index = 0; index <= ((int[]) Value).Length - 1; ++index)
              numArray[index] = ((int[]) Value)[index];
          }
          PI.SetValue(Obj, (object) numArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (PI.PropertyType == typeof (bool[]))
      {
        try
        {
          bool[] flagArray = new bool[((bool[]) Value).Length];
          if (Value.GetType() == typeof (bool[]))
          {
            for (int index = 0; index <= ((bool[]) Value).Length - 1; ++index)
              flagArray[index] = ((bool[]) Value)[index];
          }
          PI.SetValue(Obj, (object) flagArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (PI.PropertyType == typeof (string[]))
      {
        try
        {
          string[] strArray = new string[((string[]) Value).Length];
          if (Value.GetType() == typeof (string[]))
          {
            for (int index = 0; index <= ((string[]) Value).Length - 1; ++index)
              strArray[index] = ((string[]) Value)[index];
          }
          PI.SetValue(Obj, (object) strArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (PI.PropertyType == typeof (Pnt2D[]))
      {
        try
        {
          Pnt2D[] pnt2DArray = new Pnt2D[((Pnt2D[]) Value).Length];
          if (Value.GetType() == typeof (Pnt2D[]))
          {
            for (int index = 0; index <= ((Pnt2D[]) Value).Length - 1; ++index)
              pnt2DArray[index] = ((Pnt2D[]) Value)[index];
          }
          PI.SetValue(Obj, (object) pnt2DArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (PI.PropertyType == typeof (Pnt3D[]))
      {
        try
        {
          Pnt3D[] pnt3DArray = new Pnt3D[((Pnt3D[]) Value).Length];
          if (Value.GetType() == typeof (Pnt3D[]))
          {
            for (int index = 0; index <= ((Pnt3D[]) Value).Length - 1; ++index)
              pnt3DArray[index] = ((Pnt3D[]) Value)[index];
          }
          PI.SetValue(Obj, (object) pnt3DArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (PI.PropertyType == typeof (Pnt6D[]))
      {
        try
        {
          Pnt6D[] pnt6DArray = new Pnt6D[((Pnt6D[]) Value).Length];
          if (Value.GetType() == typeof (Pnt6D[]))
          {
            for (int index = 0; index <= ((Pnt6D[]) Value).Length - 1; ++index)
              pnt6DArray[index] = ((Pnt6D[]) Value)[index];
          }
          PI.SetValue(Obj, (object) pnt6DArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (PI.PropertyType == typeof (Pnt9D[]))
      {
        try
        {
          Pnt9D[] pnt9DArray = new Pnt9D[((Pnt9D[]) Value).Length];
          if (Value.GetType() == typeof (Pnt9D[]))
          {
            for (int index = 0; index <= ((Pnt9D[]) Value).Length - 1; ++index)
              pnt9DArray[index] = ((Pnt9D[]) Value)[index];
          }
          PI.SetValue(Obj, (object) pnt9DArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (PI.PropertyType == typeof (Vec3D[]))
      {
        try
        {
          Vec3D[] vec3DArray = new Vec3D[((Vec3D[]) Value).Length];
          if (Value.GetType() == typeof (Vec3D[]))
          {
            for (int index = 0; index <= ((Vec3D[]) Value).Length - 1; ++index)
              vec3DArray[index] = ((Vec3D[]) Value)[index];
          }
          PI.SetValue(Obj, (object) vec3DArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (PI.PropertyType == typeof (OrientationAngle[]))
      {
        try
        {
          OrientationAngle[] orientationAngleArray = new OrientationAngle[((OrientationAngle[]) Value).Length];
          if (Value.GetType() == typeof (OrientationAngle[]))
          {
            for (int index = 0; index <= ((OrientationAngle[]) Value).Length - 1; ++index)
              orientationAngleArray[index] = ((OrientationAngle[]) Value)[index];
          }
          PI.SetValue(Obj, (object) orientationAngleArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (PI.PropertyType == typeof (Line3D[]))
      {
        try
        {
          Line3D[] line3DArray = new Line3D[((Line3D[]) Value).Length];
          if (Value.GetType() == typeof (Line3D[]))
          {
            for (int index = 0; index <= ((Line3D[]) Value).Length - 1; ++index)
              line3DArray[index] = ((Line3D[]) Value)[index];
          }
          PI.SetValue(Obj, (object) line3DArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (PI.PropertyType == typeof (Triangle3D[]))
      {
        try
        {
          Triangle3D[] triangle3DArray = new Triangle3D[((Triangle3D[]) Value).Length];
          if (Value.GetType() == typeof (Triangle3D[]))
          {
            for (int index = 0; index <= ((Triangle3D[]) Value).Length - 1; ++index)
              triangle3DArray[index] = ((Triangle3D[]) Value)[index];
          }
          PI.SetValue(Obj, (object) triangle3DArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (PI.PropertyType == typeof (Quad3D[]))
      {
        try
        {
          Quad3D[] quad3DArray = new Quad3D[((Quad3D[]) Value).Length];
          if (Value.GetType() == typeof (Quad3D[]))
          {
            for (int index = 0; index <= ((Quad3D[]) Value).Length - 1; ++index)
              quad3DArray[index] = ((Quad3D[]) Value)[index];
          }
          PI.SetValue(Obj, (object) quad3DArray);
        }
        catch (Exception ex)
        {
        }
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static void GetClassVariableValuesFromStringCodes(
    string Code,
    object RefObject,
    ref List<cParameter> Vars)
  {
    try
    {
      string[] strArray1 = Code.Split(';');
      if (strArray1 == null)
        return;
      Vars = new List<cParameter>();
      buSerilization.GetClassVariables(RefObject, ref Vars);
      for (int index1 = 0; index1 <= Vars.Count - 1; ++index1)
      {
        bool flag = false;
        string str1 = "";
        for (int index2 = 0; index2 <= strArray1.Length - 1; ++index2)
        {
          string[] strArray2 = strArray1[index2].Split('=');
          if (strArray2 != null)
          {
            if (strArray2.Length == 2 && strArray2[0].ToString().Trim() == Vars[index1].Name.ToString().Trim())
            {
              str1 = strArray2[1].Trim();
              flag = true;
              index2 = strArray1.Length + 1;
            }
            if (strArray2.Length > 2 && strArray2[0].ToString().Trim() == Vars[index1].Name.ToString().Trim())
            {
              string str2 = "";
              for (int index3 = 1; index3 <= strArray2.Length - 1; ++index3)
              {
                string str3 = strArray2[index3].Trim();
                if (index3 > 1)
                  str3 = "=" + str3;
                if (str3.Length == 0)
                  str3 = "=";
                str2 += str3;
              }
              str1 = str2;
              flag = true;
              index2 = strArray1.Length + 1;
            }
          }
        }
        Vars[index1].Value = !flag ? (object) "0" : (object) str1;
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static void GetClassVariableValuesFromStringCodes(
    ArrayList Codes,
    object RefObject,
    ref List<cParameter> Vars)
  {
    try
    {
      List<string> Codes1 = new List<string>();
      for (int index = 0; index <= Codes.Count - 1; ++index)
        Codes1.Add(Codes[index].ToString());
      buSerilization.GetClassVariableValuesFromStringCodes(Codes1, RefObject, ref Vars);
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static void GetSubClassVariableValuesFromStringCodes(
    List<string> Codes,
    ref object RefObject,
    ref List<cParameter> Vars)
  {
    try
    {
      List<string> RefList = new List<string>();
      for (int index1 = 0; index1 <= Codes.Count - 1; ++index1)
      {
        string[] strArray = Codes[index1].Split(new string[2]
        {
          "\r\n",
          "\n"
        }, StringSplitOptions.None);
        if (strArray != null)
        {
          for (int index2 = 0; index2 <= strArray.Length - 1; ++index2)
            RefList.Add(strArray[index2]);
        }
      }
      if (RefList.Count <= 0)
        return;
      Vars = new List<cParameter>();
      buSerilization.GetClassVariables(RefObject, ref Vars);
      for (int index3 = 0; index3 <= Vars.Count - 1; ++index3)
      {
        Type type = Vars[index3].Value.GetType();
        string str1 = Vars[index3].Name.ToString().Trim();
        bool flag1 = false;
        bool flag2 = false;
        string str2 = "";
        ArrayList arrayList = new ArrayList();
        if (index3 != 25)
          ;
        if ((type.IsClass | type.IsValueType & !type.IsEnum) & !type.IsArray)
        {
          string str3 = "";
          if (type.BaseType.BaseType != (Type) null)
            str3 = type.BaseType.BaseType.Namespace;
          if (type.Namespace == "buClass" | type.BaseType.Namespace == "buClass" | str3 == "buClass" | type.Namespace == "buEyeBaseVer5" | type.BaseType.Namespace == "buEyeBaseVer5" | str3 == "buEyeBaseVer5" | type.Namespace == "buMW" | type.BaseType.Namespace == "buMW" | str3 == "buMW")
          {
            List<string> CalcList = new List<string>();
            List<cParameter> Vars1 = new List<cParameter>();
            buStatics.ListToSpecificList($"<{str1}>", $"</{str1}>", RefList, ref CalcList);
            buSerilization.GetSubClassVariableValuesFromStringCodes(CalcList, ref Vars[index3].Value, ref Vars1);
            Vars[index3].SubParameter = (object) Vars1;
            object ObjPar = Vars[index3].Field.GetValue(RefObject);
            buSerilization.SetClassVariables(ref ObjPar, Vars1);
            Vars[index3].Value = ObjPar;
            flag2 = true;
            flag1 = true;
          }
        }
        if (type.IsArray)
        {
          ArrayList CalcList = new ArrayList();
          List<cParameter> cParameterList = new List<cParameter>();
          buStatics.ListToSpecificList($"<{str1}>", $"</{str1}>", RefList, ref CalcList);
          buSerilization.StringsToArray(ref Vars[index3].Value, CalcList);
          flag2 = true;
          flag1 = true;
        }
        if (!type.IsArray && Vars[index3].Types.Name.IndexOf("List`1") >= 0)
        {
          ArrayList CalcList = new ArrayList();
          List<cParameter> cParameterList = new List<cParameter>();
          buStatics.ListToSpecificList($"<{str1}>", $"</{str1}>", RefList, ref CalcList);
          buSerilization.StringsToList(ref Vars[index3].Value, CalcList);
          flag2 = true;
          flag1 = true;
        }
        if (!type.IsArray && Vars[index3].Types.Name.IndexOf("ArrayList") >= 0)
        {
          ArrayList CalcList = new ArrayList();
          List<cParameter> cParameterList = new List<cParameter>();
          buStatics.ListToSpecificList($"<{str1}>", $"</{str1}>", RefList, ref CalcList);
          buSerilization.StringsToArrayList(ref Vars[index3].Value, CalcList);
          flag2 = true;
          flag1 = true;
        }
        if (!flag2)
        {
          for (int index4 = 0; index4 <= RefList.Count - 1; ++index4)
          {
            string str4 = "";
            string ParName = "";
            if (buSerilization.GetParameterValue(RefList[index4], ref ParName, ref str4))
            {
              string str5 = RefObject.GetType().Name + ".";
              if (ParName.Trim() == str1 | ParName.Trim() == str5 + str1)
              {
                str2 = str4.Trim();
                flag1 = true;
                index4 = RefList.Count + 1;
              }
            }
          }
        }
        if (flag1 && !flag2)
          Vars[index3].Value = (object) str2;
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static void GetClassVariableValuesFromStringCodes(
    List<string> Codes,
    object RefObject,
    ref List<cParameter> Vars)
  {
    try
    {
      List<string> RefList = new List<string>();
      for (int index1 = 0; index1 <= Codes.Count - 1; ++index1)
      {
        string[] strArray = Codes[index1].Split(new string[2]
        {
          "\r\n",
          "\n"
        }, StringSplitOptions.None);
        if (strArray != null)
        {
          for (int index2 = 0; index2 <= strArray.Length - 1; ++index2)
            RefList.Add(strArray[index2]);
        }
      }
      if (RefList.Count <= 0)
        return;
      Vars = new List<cParameter>();
      buSerilization.GetClassVariables(RefObject, ref Vars);
      for (int index3 = 0; index3 <= Vars.Count - 1; ++index3)
      {
        Type type = Vars[index3].Value.GetType();
        string nameVar = Vars[index3].Name.ToString().Trim();
        bool flag1 = false;
        bool flag2 = false;
        string str1 = "";
        ArrayList arrayList = new ArrayList();
        if (index3 != 55)
          ;
        if ((type.IsClass | type.IsValueType & !type.IsEnum) & !type.IsArray && type.Namespace == "buClass" | type.BaseType.Namespace == "buClass" | type.Namespace == "buEyeBaseVer5" | type.BaseType.Namespace == "buEyeBaseVer5" | type.Namespace == "buMW" | type.BaseType.Namespace == "buMW" | type.Namespace.IndexOf("buControls") >= 0)
        {
          List<string> CalcList = new List<string>();
          List<cParameter> Vars1 = new List<cParameter>();
          buStatics.ListToSpecificList($"<{nameVar}>", $"</{nameVar}>", RefList, ref CalcList);
          buSerilization.GetSubClassVariableValuesFromStringCodes(CalcList, ref Vars[index3].Value, ref Vars1);
          if (Vars1.Count == 0 && (List<cParameter>) Vars[index3].SubParameter != null)
          {
            for (int index4 = 0; index4 <= ((List<cParameter>) Vars[index3].SubParameter).Count - 1; ++index4)
              Vars1.Add(((List<cParameter>) Vars[index3].SubParameter)[index4]);
          }
          Vars[index3].SubParameter = (object) Vars1;
          if (Vars1.Count > 0)
          {
            object ObjPar = Vars[index3].Field.GetValue(RefObject);
            buSerilization.SetClassVariables(ref ObjPar, Vars1);
            Vars[index3].Value = ObjPar;
            flag1 = true;
          }
          flag2 = true;
        }
        if (type.IsArray)
        {
          ArrayList CalcList = new ArrayList();
          List<cParameter> cParameterList = new List<cParameter>();
          buStatics.ListToSpecificList($"<{nameVar}>", $"</{nameVar}>", RefList, ref CalcList);
          buSerilization.StringsToArray(ref Vars[index3].Value, CalcList);
          flag2 = true;
          flag1 = true;
        }
        if (!type.IsArray && Vars[index3].Types.FullName.IndexOf("Generic.List") >= 0)
        {
          string[] strArray = Vars[index3].Types.FullName.Split(new string[1]
          {
            "Generic.List"
          }, StringSplitOptions.None);
          ArrayList CalcList = new ArrayList();
          List<cParameter> cParameterList = new List<cParameter>();
          if (strArray.Length == 2)
          {
            buStatics.ListToSpecificList($"<{nameVar}>", $"</{nameVar}>", RefList, ref CalcList);
            buSerilization.StringsToList(ref Vars[index3].Value, CalcList);
            flag2 = true;
            flag1 = true;
          }
          if (strArray.Length == 3)
          {
            buStatics.ListToSpecificList($"<{nameVar}>", $"</{nameVar}>", RefList, ref CalcList);
            buSerilization.StringsToListList(ref Vars[index3].Value, nameVar, CalcList);
            flag2 = true;
            flag1 = true;
          }
        }
        if (!type.IsArray && Vars[index3].Types.Name.IndexOf("ArrayList") >= 0)
        {
          ArrayList CalcList = new ArrayList();
          List<cParameter> cParameterList = new List<cParameter>();
          buStatics.ListToSpecificList($"<{nameVar}>", $"</{nameVar}>", RefList, ref CalcList);
          buSerilization.StringsToArrayList(ref Vars[index3].Value, CalcList);
          flag2 = true;
          flag1 = true;
        }
        if (!flag2)
        {
          for (int index5 = 0; index5 <= RefList.Count - 1; ++index5)
          {
            string str2 = "";
            string ParName = "";
            if (buSerilization.GetParameterValue(RefList[index5], ref ParName, ref str2))
            {
              string str3 = RefObject.GetType().Name + ".";
              if (ParName.Trim() == nameVar | ParName.Trim() == str3 + nameVar)
              {
                str1 = str2.Trim();
                flag1 = true;
                index5 = RefList.Count + 1;
              }
            }
          }
        }
        if (flag1 && !flag2)
          Vars[index3].Value = (object) str1;
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static void GetSubClassPropertyVariableValuesFromStringCodes(
    List<string> Codes,
    ref object RefObject,
    ref List<cParameter> Vars)
  {
    try
    {
      List<string> RefList = new List<string>();
      for (int index1 = 0; index1 <= Codes.Count - 1; ++index1)
      {
        string[] strArray = Codes[index1].Split(new string[2]
        {
          "\r\n",
          "\n"
        }, StringSplitOptions.None);
        if (strArray != null)
        {
          for (int index2 = 0; index2 <= strArray.Length - 1; ++index2)
            RefList.Add(strArray[index2]);
        }
      }
      if (RefList.Count <= 0)
        return;
      Vars = new List<cParameter>();
      buSerilization.GetClassVariables(RefObject, ref Vars);
      for (int index3 = 0; index3 <= Vars.Count - 1; ++index3)
      {
        Type type = Vars[index3].Value.GetType();
        string str1 = Vars[index3].Name.ToString().Trim();
        bool flag1 = false;
        bool flag2 = false;
        string str2 = "";
        ArrayList arrayList = new ArrayList();
        if (index3 != 25)
          ;
        if ((type.IsClass | type.IsValueType & !type.IsEnum) & !type.IsArray)
        {
          string str3 = "";
          if (type.BaseType.BaseType != (Type) null)
            str3 = type.BaseType.BaseType.Namespace;
          if (type.Namespace == "buClass" | type.BaseType.Namespace == "buClass" | str3 == "buClass" | type.Namespace == "buEyeBaseVer5" | type.BaseType.Namespace == "buEyeBaseVer5" | str3 == "buEyeBaseVer5" | type.Namespace == "buMW" | type.BaseType.Namespace == "buMW" | str3 == "buMW" | type.Namespace.IndexOf("buControls") >= 0)
          {
            List<string> CalcList = new List<string>();
            List<cParameter> Vars1 = new List<cParameter>();
            buStatics.ListToSpecificList($"<{str1}>", $"</{str1}>", RefList, ref CalcList);
            buSerilization.GetSubClassPropertyVariableValuesFromStringCodes(CalcList, ref Vars[index3].Value, ref Vars1);
            Vars[index3].SubParameter = (object) Vars1;
            object ObjPar = Vars[index3].Property.GetValue(RefObject);
            buSerilization.SetClassPropertyVariables(ref ObjPar, Vars1);
            Vars[index3].Value = ObjPar;
            flag2 = true;
            flag1 = true;
          }
        }
        if (type.IsArray)
        {
          ArrayList CalcList = new ArrayList();
          List<cParameter> cParameterList = new List<cParameter>();
          buStatics.ListToSpecificList($"<{str1}>", $"</{str1}>", RefList, ref CalcList);
          buSerilization.StringsToArray(ref Vars[index3].Value, CalcList);
          flag2 = true;
          flag1 = true;
        }
        if (!type.IsArray && Vars[index3].Types.Name.IndexOf("List`1") >= 0)
        {
          ArrayList CalcList = new ArrayList();
          List<cParameter> cParameterList = new List<cParameter>();
          buStatics.ListToSpecificList($"<{str1}>", $"</{str1}>", RefList, ref CalcList);
          buSerilization.StringsToList(ref Vars[index3].Value, CalcList);
          flag2 = true;
          flag1 = true;
        }
        if (!type.IsArray && Vars[index3].Types.Name.IndexOf("ArrayList") >= 0)
        {
          ArrayList CalcList = new ArrayList();
          List<cParameter> cParameterList = new List<cParameter>();
          buStatics.ListToSpecificList($"<{str1}>", $"</{str1}>", RefList, ref CalcList);
          buSerilization.StringsToArrayList(ref Vars[index3].Value, CalcList);
          flag2 = true;
          flag1 = true;
        }
        if (!flag2)
        {
          for (int index4 = 0; index4 <= RefList.Count - 1; ++index4)
          {
            string str4 = "";
            string ParName = "";
            if (buSerilization.GetParameterValue(RefList[index4], ref ParName, ref str4))
            {
              string str5 = RefObject.GetType().Name + ".";
              if (ParName.Trim() == str1 | ParName.Trim() == str5 + str1)
              {
                str2 = str4.Trim();
                flag1 = true;
                index4 = RefList.Count + 1;
              }
            }
          }
        }
        if (flag1 && !flag2)
          Vars[index3].Value = (object) str2;
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static void GetClassPropertyVariableValuesFromStringCodes(
    List<string> Codes,
    object RefObject,
    ref List<cParameter> Vars)
  {
    try
    {
      List<string> RefList = new List<string>();
      for (int index1 = 0; index1 <= Codes.Count - 1; ++index1)
      {
        string[] strArray = Codes[index1].Split(new string[2]
        {
          "\r\n",
          "\n"
        }, StringSplitOptions.None);
        if (strArray != null)
        {
          for (int index2 = 0; index2 <= strArray.Length - 1; ++index2)
            RefList.Add(strArray[index2]);
        }
      }
      if (RefList.Count <= 0)
        return;
      Vars = new List<cParameter>();
      buSerilization.GetClassVariables(RefObject, ref Vars);
      for (int index3 = 0; index3 <= Vars.Count - 1; ++index3)
      {
        Type type = Vars[index3].Value.GetType();
        string nameVar = Vars[index3].Name.ToString().Trim();
        bool flag1 = false;
        bool flag2 = false;
        string str1 = "";
        ArrayList arrayList = new ArrayList();
        if (index3 != 55)
          ;
        if ((type.IsClass | type.IsValueType & !type.IsEnum) & !type.IsArray && type.Namespace == "buClass" | type.BaseType.Namespace == "buClass" | type.Namespace == "buEyeBaseVer5" | type.BaseType.Namespace == "buEyeBaseVer5" | type.Namespace == "buMW" | type.BaseType.Namespace == "buMW" | type.Namespace.IndexOf("buControls") >= 0)
        {
          List<string> CalcList = new List<string>();
          List<cParameter> Vars1 = new List<cParameter>();
          buStatics.ListToSpecificList($"<{nameVar}>", $"</{nameVar}>", RefList, ref CalcList);
          buSerilization.GetSubClassPropertyVariableValuesFromStringCodes(CalcList, ref Vars[index3].Value, ref Vars1);
          if (Vars1.Count == 0 && (List<cParameter>) Vars[index3].SubParameter != null)
          {
            for (int index4 = 0; index4 <= ((List<cParameter>) Vars[index3].SubParameter).Count - 1; ++index4)
              Vars1.Add(((List<cParameter>) Vars[index3].SubParameter)[index4]);
          }
          Vars[index3].SubParameter = (object) Vars1;
          if (Vars1.Count > 0)
          {
            object ObjPar = Vars[index3].Property.GetValue(RefObject);
            buSerilization.SetClassPropertyVariables(ref ObjPar, Vars1);
            Vars[index3].Value = ObjPar;
            flag1 = true;
          }
          flag2 = true;
        }
        if (type.IsArray)
        {
          ArrayList CalcList = new ArrayList();
          List<cParameter> cParameterList = new List<cParameter>();
          buStatics.ListToSpecificList($"<{nameVar}>", $"</{nameVar}>", RefList, ref CalcList);
          buSerilization.StringsToArray(ref Vars[index3].Value, CalcList);
          flag2 = true;
          flag1 = true;
        }
        if (!type.IsArray && Vars[index3].Types.FullName.IndexOf("Generic.List") >= 0)
        {
          string[] strArray = Vars[index3].Types.FullName.Split(new string[1]
          {
            "Generic.List"
          }, StringSplitOptions.None);
          ArrayList CalcList = new ArrayList();
          List<cParameter> cParameterList = new List<cParameter>();
          if (strArray.Length == 2)
          {
            buStatics.ListToSpecificList($"<{nameVar}>", $"</{nameVar}>", RefList, ref CalcList);
            buSerilization.StringsToList(ref Vars[index3].Value, CalcList);
            flag2 = true;
            flag1 = true;
          }
          if (strArray.Length == 3)
          {
            buStatics.ListToSpecificList($"<{nameVar}>", $"</{nameVar}>", RefList, ref CalcList);
            buSerilization.StringsToListList(ref Vars[index3].Value, nameVar, CalcList);
            flag2 = true;
            flag1 = true;
          }
        }
        if (!type.IsArray && Vars[index3].Types.Name.IndexOf("ArrayList") >= 0)
        {
          ArrayList CalcList = new ArrayList();
          List<cParameter> cParameterList = new List<cParameter>();
          buStatics.ListToSpecificList($"<{nameVar}>", $"</{nameVar}>", RefList, ref CalcList);
          buSerilization.StringsToArrayList(ref Vars[index3].Value, CalcList);
          flag2 = true;
          flag1 = true;
        }
        if (!flag2)
        {
          for (int index5 = 0; index5 <= RefList.Count - 1; ++index5)
          {
            string str2 = "";
            string ParName = "";
            if (buSerilization.GetParameterValue(RefList[index5], ref ParName, ref str2))
            {
              string str3 = RefObject.GetType().Name + ".";
              if (ParName.Trim() == nameVar | ParName.Trim() == str3 + nameVar)
              {
                str1 = str2.Trim();
                flag1 = true;
                index5 = RefList.Count + 1;
              }
            }
          }
        }
        if (flag1 && !flag2)
          Vars[index3].Value = (object) str1;
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  private ArrayList ToDefSubClass(object Obj, int Space)
  {
    try
    {
      ArrayList defSubClass = new ArrayList();
      string str1 = new string(' ', Space);
      List<cParameter> Vars = new List<cParameter>();
      buSerilization.GetClassVariables(Obj, ref Vars);
      for (int index = 0; index <= Vars.Count - 1; ++index)
      {
        string str2 = Vars[index].Value.GetType().ToString();
        bool flag = false;
        Type type = Vars[index].Value.GetType();
        if (Vars[index].Value.GetType() != typeof (ArrayList) & str2.IndexOf("Generic.List") < 0 & !type.IsArray)
        {
          if ((type.Namespace == "buClass" | type.Namespace == "buMW" | type.Namespace == "buEyeBaseVer5") & !type.IsEnum)
          {
            string str3 = new string(' ', Space);
            defSubClass.Add((object) $"{str3}<{Vars[index].Name.ToString()}>");
            defSubClass.AddRange((ICollection) this.ToDefSubClass(Vars[index].Value, Space + 2).ToArray());
            defSubClass.Add((object) $"{str3}</{Vars[index].Name.ToString()}>");
            flag = true;
          }
          if (!flag)
          {
            string str4 = Obj.GetType().Name + ".";
            defSubClass.Add((object) $"{str1}{str4}{Vars[index].Name} = {Vars[index].ValueAsString.ToString()}");
          }
        }
        else if (type.IsArray)
          defSubClass.AddRange((ICollection) this.ArrayToStrings(Vars[index].Name.ToString(), Vars[index].Value, Space).ToArray());
        else if (Vars[index].Value.GetType() == typeof (ArrayList))
          defSubClass.AddRange((ICollection) this.ArrayListToStrings(Vars[index].Name.ToString(), (ArrayList) Vars[index].Value, Space).ToArray());
        else if (str2.IndexOf("Generic.List") >= 0)
          defSubClass.AddRange((ICollection) this.ListToStrings(Vars[index].Name.ToString(), Vars[index].Value, Space).ToArray());
      }
      return defSubClass;
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return new ArrayList();
    }
  }

  private ArrayList ArrayListToStrings(string varName, ArrayList varVal, int Space)
  {
    try
    {
      string str1 = new string(' ', Space);
      ArrayList strings = new ArrayList();
      strings.Add((object) $"{str1}<{varName}>");
      string str2 = new string(' ', Space + 2);
      for (int index = 0; index <= varVal.Count - 1; ++index)
        strings.Add((object) $"{str2}{varName} = {varVal[index].ToString()}");
      strings.Add((object) $"{str1}</{varName}>");
      return strings;
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return new ArrayList();
    }
  }

  private ArrayList ListToStrings(string varName, object varVal, int Space)
  {
    try
    {
      string str1 = new string(' ', Space);
      ArrayList strings = new ArrayList();
      if (varVal == null)
        return strings;
      varVal.GetType().ToString();
      Type type = varVal.GetType();
      if (type == typeof (List<double>))
      {
        strings.Add((object) $"{str1}<{varName}>");
        string str2 = new string(' ', Space + 2);
        for (int index = 0; index <= ((List<double>) varVal).Count - 1; ++index)
        {
          double num = ((List<double>) varVal)[index];
          strings.Add((object) $"{str2}{varName} = {num.ToString()}");
        }
        strings.Add((object) $"{str1}</{varName}>");
      }
      if (type == typeof (List<int>))
      {
        strings.Add((object) $"{str1}<{varName}>");
        string str3 = new string(' ', Space + 2);
        for (int index = 0; index <= ((List<int>) varVal).Count - 1; ++index)
        {
          int num = ((List<int>) varVal)[index];
          strings.Add((object) $"{str3}{varName} = {num.ToString()}");
        }
        strings.Add((object) $"{str1}</{varName}>");
      }
      if (type == typeof (List<float>))
      {
        strings.Add((object) $"{str1}<{varName}>");
        string str4 = new string(' ', Space + 2);
        for (int index = 0; index <= ((List<float>) varVal).Count - 1; ++index)
        {
          float num = ((List<float>) varVal)[index];
          strings.Add((object) $"{str4}{varName} = {num.ToString()}");
        }
        strings.Add((object) $"{str1}</{varName}>");
      }
      if (type == typeof (List<bool>))
      {
        strings.Add((object) $"{str1}<{varName}>");
        string str5 = new string(' ', Space + 2);
        for (int index = 0; index <= ((List<bool>) varVal).Count - 1; ++index)
        {
          bool flag = ((List<bool>) varVal)[index];
          strings.Add((object) $"{str5}{varName} = {flag.ToString()}");
        }
        strings.Add((object) $"{str1}</{varName}>");
      }
      if (type == typeof (List<string>))
      {
        strings.Add((object) $"{str1}<{varName}>");
        string str6 = new string(' ', Space + 2);
        for (int index = 0; index <= ((List<string>) varVal).Count - 1; ++index)
        {
          string str7 = ((List<string>) varVal)[index];
          strings.Add((object) $"{str6}{varName} = {str7.ToString()}");
        }
        strings.Add((object) $"{str1}</{varName}>");
      }
      if (type == typeof (List<Pnt2D>))
      {
        strings.Add((object) $"{str1}<{varName}>");
        string str8 = new string(' ', Space + 2);
        for (int index = 0; index <= ((List<Pnt2D>) varVal).Count - 1; ++index)
        {
          Pnt2D pnt2D1 = new Pnt2D();
          Pnt2D pnt2D2 = ((List<Pnt2D>) varVal)[index];
          strings.Add((object) $"{str8}{varName} = {pnt2D2.ToDef()}");
        }
        strings.Add((object) $"{str1}</{varName}>");
      }
      if (type == typeof (List<Pnt3D>))
      {
        strings.Add((object) $"{str1}<{varName}>");
        string str9 = new string(' ', Space + 2);
        for (int index = 0; index <= ((List<Pnt3D>) varVal).Count - 1; ++index)
        {
          Pnt3D pnt3D1 = new Pnt3D();
          Pnt3D pnt3D2 = ((List<Pnt3D>) varVal)[index];
          strings.Add((object) $"{str9}{varName} = {pnt3D2.ToDef()}");
        }
        strings.Add((object) $"{str1}</{varName}>");
      }
      if (type == typeof (List<Pnt6D>))
      {
        strings.Add((object) $"{str1}<{varName}>");
        string str10 = new string(' ', Space + 2);
        for (int index = 0; index <= ((List<Pnt6D>) varVal).Count - 1; ++index)
        {
          Pnt6D pnt6D1 = new Pnt6D();
          Pnt6D pnt6D2 = ((List<Pnt6D>) varVal)[index];
          strings.Add((object) $"{str10}{varName} = {pnt6D2.ToDef()}");
        }
        strings.Add((object) $"{str1}</{varName}>");
      }
      if (type == typeof (List<Pnt9D>))
      {
        strings.Add((object) $"{str1}<{varName}>");
        string str11 = new string(' ', Space + 2);
        for (int index = 0; index <= ((List<Pnt9D>) varVal).Count - 1; ++index)
        {
          Pnt9D pnt9D1 = new Pnt9D();
          Pnt9D pnt9D2 = ((List<Pnt9D>) varVal)[index];
          strings.Add((object) $"{str11}{varName} = {pnt9D2.ToDef()}");
        }
        strings.Add((object) $"{str1}</{varName}>");
      }
      if (type == typeof (List<Vec3D>))
      {
        strings.Add((object) $"{str1}<{varName}>");
        string str12 = new string(' ', Space + 2);
        for (int index = 0; index <= ((List<Vec3D>) varVal).Count - 1; ++index)
        {
          Vec3D vec3D1 = new Vec3D();
          Vec3D vec3D2 = ((List<Vec3D>) varVal)[index];
          strings.Add((object) $"{str12}{varName} = {vec3D2.ToDef()}");
        }
        strings.Add((object) $"{str1}</{varName}>");
      }
      if (type == typeof (List<OrientationAngle>))
      {
        strings.Add((object) $"{str1}<{varName}>");
        string str13 = new string(' ', Space + 2);
        for (int index = 0; index <= ((List<OrientationAngle>) varVal).Count - 1; ++index)
        {
          OrientationAngle orientationAngle1 = new OrientationAngle();
          OrientationAngle orientationAngle2 = ((List<OrientationAngle>) varVal)[index];
          strings.Add((object) $"{str13}{varName} = {orientationAngle2.ToDef()}");
        }
        strings.Add((object) $"{str1}</{varName}>");
      }
      if (type == typeof (List<Line3D>))
      {
        strings.Add((object) $"{str1}<{varName}>");
        string str14 = new string(' ', Space + 2);
        for (int index = 0; index <= ((List<Line3D>) varVal).Count - 1; ++index)
        {
          Line3D line3D1 = new Line3D();
          Line3D line3D2 = ((List<Line3D>) varVal)[index];
          strings.Add((object) $"{str14}{varName} = {line3D2.ToDef(2)}");
        }
        strings.Add((object) $"{str1}</{varName}>");
      }
      if (type == typeof (List<Triangle3D>))
      {
        strings.Add((object) $"{str1}<{varName}>");
        string str15 = new string(' ', Space + 2);
        for (int index = 0; index <= ((List<Triangle3D>) varVal).Count - 1; ++index)
        {
          Triangle3D triangle3D1 = new Triangle3D();
          Triangle3D triangle3D2 = ((List<Triangle3D>) varVal)[index];
          strings.Add((object) $"{str15}{varName} = {triangle3D2.ToDef(2)}");
        }
        strings.Add((object) $"{str1}</{varName}>");
      }
      if (type == typeof (List<Quad3D>))
      {
        strings.Add((object) $"{str1}<{varName}>");
        string str16 = new string(' ', Space + 2);
        for (int index = 0; index <= ((List<Quad3D>) varVal).Count - 1; ++index)
        {
          Quad3D quad3D1 = new Quad3D();
          Quad3D quad3D2 = ((List<Quad3D>) varVal)[index];
          strings.Add((object) $"{str16}{varName} = {quad3D2.ToDef(2)}");
        }
        strings.Add((object) $"{str1}</{varName}>");
      }
      return strings;
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return new ArrayList();
    }
  }

  private ArrayList ListListToStrings(string varName, object varVal, int Space)
  {
    try
    {
      string str1 = new string(' ', Space);
      ArrayList strings = new ArrayList();
      if (varVal == null)
        return strings;
      Type type = varVal.GetType();
      varVal.GetType().ToString();
      if (type == typeof (List<List<Pnt3D>>))
      {
        strings.Add((object) $"{str1}<{varName}>");
        string str2 = new string(' ', Space + 2);
        for (int index = 0; index <= ((List<List<Pnt3D>>) varVal).Count - 1; ++index)
          strings.AddRange((ICollection) this.ListToStrings(varName + "_Sub", (object) ((List<List<Pnt3D>>) varVal)[index], Space + 2).ToArray());
        strings.Add((object) $"{str1}</{varName}>");
      }
      return strings;
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return new ArrayList();
    }
  }

  private ArrayList ArrayToStrings(string varName, object varVal, int Space)
  {
    try
    {
      string str1 = new string(' ', Space);
      ArrayList strings = new ArrayList();
      if (varVal == null)
        return strings;
      string str2 = varVal.GetType().ToString();
      if (str2.IndexOf("System.Double[]") >= 0)
      {
        strings.Add((object) $"{str1}<{varName}>");
        string str3 = new string(' ', Space + 2);
        for (int index = 0; index <= ((double[]) varVal).Length - 1; ++index)
        {
          double num = ((double[]) varVal)[index];
          strings.Add((object) $"{str3}{varName} = {num.ToString()}");
        }
        strings.Add((object) $"{str1}</{varName}>");
      }
      if (str2.IndexOf("System.Int32[]") >= 0)
      {
        strings.Add((object) $"{str1}<{varName}>");
        string str4 = new string(' ', Space + 2);
        for (int index = 0; index <= ((int[]) varVal).Length - 1; ++index)
        {
          int num = ((int[]) varVal)[index];
          strings.Add((object) $"{str4}{varName} = {num.ToString()}");
        }
        strings.Add((object) $"{str1}</{varName}>");
      }
      if (str2.IndexOf("System.Single[]") >= 0)
      {
        strings.Add((object) $"{str1}<{varName}>");
        string str5 = new string(' ', Space + 2);
        for (int index = 0; index <= ((float[]) varVal).Length - 1; ++index)
        {
          float num = ((float[]) varVal)[index];
          strings.Add((object) $"{str5}{varName} = {num.ToString()}");
        }
        strings.Add((object) $"{str1}</{varName}>");
      }
      if (str2.IndexOf("System.Boolean[]") >= 0)
      {
        strings.Add((object) $"{str1}<{varName}>");
        string str6 = new string(' ', Space + 2);
        for (int index = 0; index <= ((bool[]) varVal).Length - 1; ++index)
        {
          bool flag = ((bool[]) varVal)[index];
          strings.Add((object) $"{str6}{varName} = {flag.ToString()}");
        }
        strings.Add((object) $"{str1}</{varName}>");
      }
      if (str2.IndexOf("System.String[]") >= 0)
      {
        strings.Add((object) $"{str1}<{varName}>");
        string str7 = new string(' ', Space + 2);
        for (int index = 0; index <= ((string[]) varVal).Length - 1; ++index)
        {
          string str8 = ((string[]) varVal)[index];
          strings.Add((object) $"{str7}{varName} = {str8.ToString()}");
        }
        strings.Add((object) $"{str1}</{varName}>");
      }
      return strings;
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return new ArrayList();
    }
  }

  public static string BoolToString(bool Val) => Val ? "1" : "0";

  private static void StringsToArrayList(ref object varVal, ArrayList valueList)
  {
    try
    {
      if (!(varVal.GetType() == typeof (ArrayList)))
        return;
      varVal = (object) new ArrayList();
      for (int index = 0; index <= valueList.Count - 1; ++index)
      {
        string parameterValue = buSerilization.GetParameterValue(valueList[index].ToString());
        ((ArrayList) varVal).Add((object) parameterValue);
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  private static void StringsToList(ref object varVal, ArrayList valueList)
  {
    try
    {
      if (varVal.GetType() == typeof (List<double>))
      {
        varVal = (object) new List<double>();
        for (int index = 0; index <= valueList.Count - 1; ++index)
        {
          double result = 0.0;
          double.TryParse(buSerilization.GetParameterValue(valueList[index].ToString()), out result);
          ((List<double>) varVal).Add(result);
        }
      }
      if (varVal.GetType() == typeof (List<int>))
      {
        varVal = (object) new List<int>();
        for (int index = 0; index <= valueList.Count - 1; ++index)
        {
          int result = 0;
          int.TryParse(buSerilization.GetParameterValue(valueList[index].ToString()), out result);
          ((List<int>) varVal).Add(result);
        }
      }
      if (varVal.GetType() == typeof (List<float>))
      {
        varVal = (object) new List<float>();
        for (int index = 0; index <= valueList.Count - 1; ++index)
        {
          float result = 0.0f;
          float.TryParse(buSerilization.GetParameterValue(valueList[index].ToString()), out result);
          ((List<float>) varVal).Add(result);
        }
      }
      if (varVal.GetType() == typeof (List<bool>))
      {
        varVal = (object) new List<bool>();
        for (int index = 0; index <= valueList.Count - 1; ++index)
        {
          bool result = false;
          bool.TryParse(buSerilization.GetParameterValue(valueList[index].ToString()), out result);
          ((List<bool>) varVal).Add(result);
        }
      }
      if (varVal.GetType() == typeof (List<string>))
      {
        varVal = (object) new List<string>();
        for (int index = 0; index <= valueList.Count - 1; ++index)
        {
          string parameterValue = buSerilization.GetParameterValue(valueList[index].ToString());
          ((List<string>) varVal).Add(parameterValue);
        }
      }
      if (varVal.GetType() == typeof (List<Pnt2D>))
      {
        varVal = (object) new List<Pnt2D>();
        for (int index = 0; index <= valueList.Count - 1; ++index)
        {
          Pnt2D pnt2D1 = new Pnt2D();
          Pnt2D pnt2D2 = Pnt2D.DecodeFromString(buSerilization.GetParameterValue(valueList[index].ToString()));
          ((List<Pnt2D>) varVal).Add(pnt2D2);
        }
      }
      if (varVal.GetType() == typeof (List<Pnt3D>))
      {
        varVal = (object) new List<Pnt3D>();
        for (int index = 0; index <= valueList.Count - 1; ++index)
        {
          Pnt3D pnt3D1 = new Pnt3D();
          Pnt3D pnt3D2 = Pnt3D.DecodeFromString(buSerilization.GetParameterValue(valueList[index].ToString()));
          ((List<Pnt3D>) varVal).Add(pnt3D2);
        }
      }
      if (varVal.GetType() == typeof (List<Pnt6D>))
      {
        varVal = (object) new List<Pnt6D>();
        for (int index = 0; index <= valueList.Count - 1; ++index)
        {
          Pnt6D pnt6D1 = new Pnt6D();
          Pnt6D pnt6D2 = Pnt6D.DecodeFromString(buSerilization.GetParameterValue(valueList[index].ToString()));
          ((List<Pnt6D>) varVal).Add(pnt6D2);
        }
      }
      if (varVal.GetType() == typeof (List<Pnt9D>))
      {
        varVal = (object) new List<Pnt9D>();
        for (int index = 0; index <= valueList.Count - 1; ++index)
        {
          Pnt9D pnt9D1 = new Pnt9D();
          Pnt9D pnt9D2 = Pnt9D.DecodeFromString(buSerilization.GetParameterValue(valueList[index].ToString()));
          ((List<Pnt9D>) varVal).Add(pnt9D2);
        }
      }
      if (varVal.GetType() == typeof (List<Vec3D>))
      {
        varVal = (object) new List<Vec3D>();
        for (int index = 0; index <= valueList.Count - 1; ++index)
        {
          Vec3D vec3D1 = new Vec3D();
          Vec3D vec3D2 = Vec3D.DecodeFromString(buSerilization.GetParameterValue(valueList[index].ToString()));
          ((List<Vec3D>) varVal).Add(vec3D2);
        }
      }
      if (varVal.GetType() == typeof (List<OrientationAngle>))
      {
        varVal = (object) new List<OrientationAngle>();
        for (int index = 0; index <= valueList.Count - 1; ++index)
        {
          OrientationAngle orientationAngle1 = new OrientationAngle();
          OrientationAngle orientationAngle2 = OrientationAngle.DecodeFromString(buSerilization.GetParameterValue(valueList[index].ToString()));
          ((List<OrientationAngle>) varVal).Add(orientationAngle2);
        }
      }
      if (varVal.GetType() == typeof (List<Line3D>))
      {
        varVal = (object) new List<Line3D>();
        for (int index = 0; index <= valueList.Count - 1; ++index)
        {
          Line3D line3D1 = new Line3D();
          Line3D line3D2 = Line3D.DecodeFromString(buSerilization.GetParameterValue(valueList[index].ToString()));
          ((List<Line3D>) varVal).Add(line3D2);
        }
      }
      if (varVal.GetType() == typeof (List<Triangle3D>))
      {
        varVal = (object) new List<Triangle3D>();
        for (int index = 0; index <= valueList.Count - 1; ++index)
        {
          Triangle3D triangle3D1 = new Triangle3D();
          Triangle3D triangle3D2 = Triangle3D.DecodeFromString(buSerilization.GetParameterValue(valueList[index].ToString()));
          ((List<Triangle3D>) varVal).Add(triangle3D2);
        }
      }
      if (!(varVal.GetType() == typeof (List<Quad3D>)))
        return;
      varVal = (object) new List<Quad3D>();
      for (int index = 0; index <= valueList.Count - 1; ++index)
      {
        Quad3D quad3D1 = new Quad3D();
        Quad3D quad3D2 = Quad3D.DecodeFromString(buSerilization.GetParameterValue(valueList[index].ToString()));
        ((List<Quad3D>) varVal).Add(quad3D2);
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  private static void StringsToListList(ref object varVal, string nameVar, ArrayList valueList)
  {
    try
    {
      if (!(varVal.GetType() == typeof (List<List<Pnt3D>>)))
        return;
      varVal = (object) new List<List<Pnt3D>>();
      List<List<string>> CalcList = new List<List<string>>();
      buStatics.ListToSpecificList($"<{nameVar}_Sub>", $"</{nameVar}_Sub>", valueList, ref CalcList);
      for (int index = 0; index <= CalcList.Count - 1; ++index)
      {
        ArrayList valueList1 = new ArrayList();
        valueList1.AddRange((ICollection) CalcList[index].ToArray());
        object varVal1 = (object) new List<Pnt3D>();
        buSerilization.StringsToList(ref varVal1, valueList1);
        ((List<List<Pnt3D>>) varVal).Add((List<Pnt3D>) varVal1);
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  private static void StringsToArray(ref object varVal, ArrayList valueList)
  {
    try
    {
      if (varVal.GetType() == typeof (double[]))
      {
        varVal = (object) new double[valueList.Count];
        for (int index = 0; index <= valueList.Count - 1; ++index)
        {
          double result = 0.0;
          double.TryParse(buSerilization.GetParameterValue(valueList[index].ToString()), out result);
          ((double[]) varVal)[index] = result;
        }
      }
      if (varVal.GetType() == typeof (int[]))
      {
        varVal = (object) new int[valueList.Count];
        for (int index = 0; index <= valueList.Count - 1; ++index)
        {
          int result = 0;
          int.TryParse(buSerilization.GetParameterValue(valueList[index].ToString()), out result);
          ((int[]) varVal)[index] = result;
        }
      }
      if (varVal.GetType() == typeof (bool[]))
      {
        varVal = (object) new bool[valueList.Count];
        for (int index = 0; index <= valueList.Count - 1; ++index)
        {
          bool result = false;
          bool.TryParse(buSerilization.GetParameterValue(valueList[index].ToString()), out result);
          ((bool[]) varVal)[index] = result;
        }
      }
      if (varVal.GetType() == typeof (string[]))
      {
        varVal = (object) new string[valueList.Count];
        for (int index = 0; index <= valueList.Count - 1; ++index)
        {
          string parameterValue = buSerilization.GetParameterValue(valueList[index].ToString());
          ((string[]) varVal)[index] = parameterValue;
        }
      }
      if (varVal.GetType() == typeof (double[]))
      {
        varVal = (object) new double[valueList.Count];
        for (int index = 0; index <= valueList.Count - 1; ++index)
        {
          double result = 0.0;
          double.TryParse(buSerilization.GetParameterValue(valueList[index].ToString()), out result);
          ((double[]) varVal)[index] = result;
        }
      }
      if (varVal.GetType() == typeof (float[]))
      {
        varVal = (object) new float[valueList.Count];
        for (int index = 0; index <= valueList.Count - 1; ++index)
        {
          float result = 0.0f;
          float.TryParse(buSerilization.GetParameterValue(valueList[index].ToString()), out result);
          ((float[]) varVal)[index] = result;
        }
      }
      if (varVal.GetType() == typeof (Pnt2D[]))
      {
        varVal = (object) new Pnt2D[valueList.Count];
        for (int index = 0; index <= valueList.Count - 1; ++index)
        {
          Pnt2D pnt2D1 = new Pnt2D();
          Pnt2D pnt2D2 = Pnt2D.DecodeFromString(buSerilization.GetParameterValue(valueList[index].ToString()));
          ((Pnt2D[]) varVal)[index] = pnt2D2;
        }
      }
      if (varVal.GetType() == typeof (Pnt3D[]))
      {
        varVal = (object) new Pnt3D[valueList.Count];
        for (int index = 0; index <= valueList.Count - 1; ++index)
        {
          Pnt3D pnt3D1 = new Pnt3D();
          Pnt3D pnt3D2 = Pnt3D.DecodeFromString(buSerilization.GetParameterValue(valueList[index].ToString()));
          ((Pnt3D[]) varVal)[index] = pnt3D2;
        }
      }
      if (varVal.GetType() == typeof (Pnt6D[]))
      {
        varVal = (object) new Pnt6D[valueList.Count];
        for (int index = 0; index <= valueList.Count - 1; ++index)
        {
          Pnt6D pnt6D1 = new Pnt6D();
          Pnt6D pnt6D2 = Pnt6D.DecodeFromString(buSerilization.GetParameterValue(valueList[index].ToString()));
          ((Pnt6D[]) varVal)[index] = pnt6D2;
        }
      }
      if (varVal.GetType() == typeof (Pnt9D[]))
      {
        varVal = (object) new Pnt9D[valueList.Count];
        for (int index = 0; index <= valueList.Count - 1; ++index)
        {
          Pnt9D pnt9D1 = new Pnt9D();
          Pnt9D pnt9D2 = Pnt9D.DecodeFromString(buSerilization.GetParameterValue(valueList[index].ToString()));
          ((Pnt9D[]) varVal)[index] = pnt9D2;
        }
      }
      if (varVal.GetType() == typeof (Vec3D[]))
      {
        varVal = (object) new Vec3D[valueList.Count];
        for (int index = 0; index <= valueList.Count - 1; ++index)
        {
          Vec3D vec3D1 = new Vec3D();
          Vec3D vec3D2 = Vec3D.DecodeFromString(buSerilization.GetParameterValue(valueList[index].ToString()));
          ((Vec3D[]) varVal)[index] = vec3D2;
        }
      }
      if (varVal.GetType() == typeof (OrientationAngle[]))
      {
        varVal = (object) new OrientationAngle[valueList.Count];
        for (int index = 0; index <= valueList.Count - 1; ++index)
        {
          OrientationAngle orientationAngle1 = new OrientationAngle();
          OrientationAngle orientationAngle2 = OrientationAngle.DecodeFromString(buSerilization.GetParameterValue(valueList[index].ToString()));
          ((OrientationAngle[]) varVal)[index] = orientationAngle2;
        }
      }
      if (varVal.GetType() == typeof (Line3D[]))
      {
        varVal = (object) new Line3D[valueList.Count];
        for (int index = 0; index <= valueList.Count - 1; ++index)
        {
          Line3D line3D1 = new Line3D();
          Line3D line3D2 = Line3D.DecodeFromString(buSerilization.GetParameterValue(valueList[index].ToString()));
          ((Line3D[]) varVal)[index] = line3D2;
        }
      }
      if (varVal.GetType() == typeof (Triangle3D[]))
      {
        varVal = (object) new Triangle3D[valueList.Count];
        for (int index = 0; index <= valueList.Count - 1; ++index)
        {
          Triangle3D triangle3D1 = new Triangle3D();
          Triangle3D triangle3D2 = Triangle3D.DecodeFromString(buSerilization.GetParameterValue(valueList[index].ToString()));
          ((Triangle3D[]) varVal)[index] = triangle3D2;
        }
      }
      if (!(varVal.GetType() == typeof (Quad3D[])))
        return;
      varVal = (object) new Quad3D[valueList.Count];
      for (int index = 0; index <= valueList.Count - 1; ++index)
      {
        Quad3D quad3D1 = new Quad3D();
        Quad3D quad3D2 = Quad3D.DecodeFromString(buSerilization.GetParameterValue(valueList[index].ToString()));
        ((Quad3D[]) varVal)[index] = quad3D2;
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  private static void ValueToSetClassArrayList(ref object Obj, object Value)
  {
    try
    {
      if (!(Value.GetType() == typeof (ArrayList)))
        return;
      Obj = (object) new ArrayList();
      ArrayList arrayList1 = new ArrayList();
      ArrayList arrayList2 = (ArrayList) Value;
      ((ArrayList) Obj).AddRange((ICollection) arrayList2.ToArray());
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  private static void ValueToSetClassArray(ref object Obj, object Value)
  {
    try
    {
      if (Value.GetType() == typeof (double[]))
      {
        Obj = (object) new double[((double[]) Value).Length];
        for (int index = 0; index <= ((double[]) Value).Length - 1; ++index)
          ((double[]) Obj)[index] = ((double[]) Value)[index];
      }
      if (Value.GetType() == typeof (float[]))
      {
        Obj = (object) new float[((float[]) Value).Length];
        for (int index = 0; index <= ((float[]) Value).Length - 1; ++index)
          ((float[]) Obj)[index] = ((float[]) Value)[index];
      }
      if (Value.GetType() == typeof (int[]))
      {
        Obj = (object) new int[((int[]) Value).Length];
        for (int index = 0; index <= ((int[]) Value).Length - 1; ++index)
          ((int[]) Obj)[index] = ((int[]) Value)[index];
      }
      if (Value.GetType() == typeof (bool[]))
      {
        Obj = (object) new bool[((bool[]) Value).Length];
        for (int index = 0; index <= ((bool[]) Value).Length - 1; ++index)
          ((bool[]) Obj)[index] = ((bool[]) Value)[index];
      }
      if (Value.GetType() == typeof (string[]))
      {
        Obj = (object) new string[((string[]) Value).Length];
        for (int index = 0; index <= ((string[]) Value).Length - 1; ++index)
          ((string[]) Obj)[index] = ((string[]) Value)[index];
      }
      if (Value.GetType() == typeof (Pnt2D[]))
      {
        Obj = (object) new Pnt2D[((Pnt2D[]) Value).Length];
        for (int index = 0; index <= ((Pnt2D[]) Value).Length - 1; ++index)
          ((Pnt2D[]) Obj)[index] = ((Pnt2D[]) Value)[index];
      }
      if (Value.GetType() == typeof (Pnt3D[]))
      {
        Obj = (object) new Pnt3D[((Pnt3D[]) Value).Length];
        for (int index = 0; index <= ((Pnt3D[]) Value).Length - 1; ++index)
          ((Pnt3D[]) Obj)[index] = ((Pnt3D[]) Value)[index];
      }
      if (Value.GetType() == typeof (Pnt6D[]))
      {
        Obj = (object) new Pnt6D[((Pnt6D[]) Value).Length];
        for (int index = 0; index <= ((Pnt6D[]) Value).Length - 1; ++index)
          ((Pnt6D[]) Obj)[index] = ((Pnt6D[]) Value)[index];
      }
      if (Value.GetType() == typeof (Pnt9D[]))
      {
        Obj = (object) new Pnt9D[((Pnt9D[]) Value).Length];
        for (int index = 0; index <= ((Pnt9D[]) Value).Length - 1; ++index)
          ((Pnt9D[]) Obj)[index] = ((Pnt9D[]) Value)[index];
      }
      if (Value.GetType() == typeof (Vec3D[]))
      {
        Obj = (object) new Vec3D[((Vec3D[]) Value).Length];
        for (int index = 0; index <= ((Vec3D[]) Value).Length - 1; ++index)
          ((Vec3D[]) Obj)[index] = ((Vec3D[]) Value)[index];
      }
      if (Value.GetType() == typeof (OrientationAngle[]))
      {
        Obj = (object) new OrientationAngle[((OrientationAngle[]) Value).Length];
        for (int index = 0; index <= ((OrientationAngle[]) Value).Length - 1; ++index)
          ((OrientationAngle[]) Obj)[index] = ((OrientationAngle[]) Value)[index];
      }
      if (Value.GetType() == typeof (Line3D[]))
      {
        Obj = (object) new Line3D[((Line3D[]) Value).Length];
        for (int index = 0; index <= ((Line3D[]) Value).Length - 1; ++index)
          ((Line3D[]) Obj)[index] = ((Line3D[]) Value)[index];
      }
      if (Value.GetType() == typeof (Triangle3D[]))
      {
        Obj = (object) new Triangle3D[((Triangle3D[]) Value).Length];
        for (int index = 0; index <= ((Triangle3D[]) Value).Length - 1; ++index)
          ((Triangle3D[]) Obj)[index] = ((Triangle3D[]) Value)[index];
      }
      if (!(Value.GetType() == typeof (Quad3D[])))
        return;
      Obj = (object) new Quad3D[((Quad3D[]) Value).Length];
      for (int index = 0; index <= ((Quad3D[]) Value).Length - 1; ++index)
        ((Quad3D[]) Obj)[index] = ((Quad3D[]) Value)[index];
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  private static void ValueToSetClassList(ref object Obj, object Value)
  {
    try
    {
      if (Value.GetType() == typeof (List<double>))
      {
        Obj = (object) new List<double>();
        List<double> doubleList1 = new List<double>();
        List<double> doubleList2 = (List<double>) Value;
        ((List<double>) Obj).AddRange((IEnumerable<double>) doubleList2.ToArray());
      }
      if (Value.GetType() == typeof (List<float>))
      {
        Obj = (object) new List<float>();
        List<float> floatList1 = new List<float>();
        List<float> floatList2 = (List<float>) Value;
        ((List<float>) Obj).AddRange((IEnumerable<float>) floatList2.ToArray());
      }
      if (Value.GetType() == typeof (List<int>))
      {
        Obj = (object) new List<int>();
        List<int> intList1 = new List<int>();
        List<int> intList2 = (List<int>) Value;
        ((List<int>) Obj).AddRange((IEnumerable<int>) intList2.ToArray());
      }
      if (Value.GetType() == typeof (List<bool>))
      {
        Obj = (object) new List<bool>();
        List<bool> boolList1 = new List<bool>();
        List<bool> boolList2 = (List<bool>) Value;
        ((List<bool>) Obj).AddRange((IEnumerable<bool>) boolList2.ToArray());
      }
      if (Value.GetType() == typeof (List<string>))
      {
        Obj = (object) new List<string>();
        List<string> stringList1 = new List<string>();
        List<string> stringList2 = (List<string>) Value;
        ((List<string>) Obj).AddRange((IEnumerable<string>) stringList2.ToArray());
      }
      if (Value.GetType() == typeof (List<Pnt2D>))
      {
        Obj = (object) new List<Pnt2D>();
        List<Pnt2D> pnt2DList1 = new List<Pnt2D>();
        List<Pnt2D> pnt2DList2 = (List<Pnt2D>) Value;
        ((List<Pnt2D>) Obj).AddRange((IEnumerable<Pnt2D>) pnt2DList2.ToArray());
      }
      if (Value.GetType() == typeof (List<Pnt3D>))
      {
        Obj = (object) new List<Pnt3D>();
        List<Pnt3D> pnt3DList1 = new List<Pnt3D>();
        List<Pnt3D> pnt3DList2 = (List<Pnt3D>) Value;
        ((List<Pnt3D>) Obj).AddRange((IEnumerable<Pnt3D>) pnt3DList2.ToArray());
      }
      if (Value.GetType() == typeof (List<Pnt6D>))
      {
        Obj = (object) new List<Pnt6D>();
        List<Pnt6D> pnt6DList1 = new List<Pnt6D>();
        List<Pnt6D> pnt6DList2 = (List<Pnt6D>) Value;
        ((List<Pnt6D>) Obj).AddRange((IEnumerable<Pnt6D>) pnt6DList2.ToArray());
      }
      if (Value.GetType() == typeof (List<Pnt9D>))
      {
        Obj = (object) new List<Pnt9D>();
        List<Pnt9D> pnt9DList1 = new List<Pnt9D>();
        List<Pnt9D> pnt9DList2 = (List<Pnt9D>) Value;
        ((List<Pnt9D>) Obj).AddRange((IEnumerable<Pnt9D>) pnt9DList2.ToArray());
      }
      if (Value.GetType() == typeof (List<Vec3D>))
      {
        Obj = (object) new List<Vec3D>();
        List<Vec3D> vec3DList1 = new List<Vec3D>();
        List<Vec3D> vec3DList2 = (List<Vec3D>) Value;
        ((List<Vec3D>) Obj).AddRange((IEnumerable<Vec3D>) vec3DList2.ToArray());
      }
      if (Value.GetType() == typeof (List<OrientationAngle>))
      {
        Obj = (object) new List<OrientationAngle>();
        List<OrientationAngle> orientationAngleList1 = new List<OrientationAngle>();
        List<OrientationAngle> orientationAngleList2 = (List<OrientationAngle>) Value;
        ((List<OrientationAngle>) Obj).AddRange((IEnumerable<OrientationAngle>) orientationAngleList2.ToArray());
      }
      if (Value.GetType() == typeof (List<Line3D>))
      {
        Obj = (object) new List<Line3D>();
        List<Line3D> line3DList1 = new List<Line3D>();
        List<Line3D> line3DList2 = (List<Line3D>) Value;
        ((List<Line3D>) Obj).AddRange((IEnumerable<Line3D>) line3DList2.ToArray());
      }
      if (Value.GetType() == typeof (List<Triangle3D>))
      {
        Obj = (object) new List<Triangle3D>();
        List<Triangle3D> triangle3DList1 = new List<Triangle3D>();
        List<Triangle3D> triangle3DList2 = (List<Triangle3D>) Value;
        ((List<Triangle3D>) Obj).AddRange((IEnumerable<Triangle3D>) triangle3DList2.ToArray());
      }
      if (Value.GetType() == typeof (List<Quad3D>))
      {
        Obj = (object) new List<Quad3D>();
        List<Quad3D> quad3DList1 = new List<Quad3D>();
        List<Quad3D> quad3DList2 = (List<Quad3D>) Value;
        ((List<Quad3D>) Obj).AddRange((IEnumerable<Quad3D>) quad3DList2.ToArray());
      }
      if (!(Value.GetType() == typeof (List<List<Pnt3D>>)))
        return;
      Obj = (object) new List<List<Pnt3D>>();
      for (int index = 0; index <= ((List<List<Pnt3D>>) Value).Count - 1; ++index)
      {
        List<Pnt3D> pnt3DList3 = new List<Pnt3D>();
        List<Pnt3D> pnt3DList4 = ((List<List<Pnt3D>>) Value)[index];
        ((List<List<Pnt3D>>) Obj).Add(pnt3DList4);
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  private static string GetParameterValue(string ParameterValue)
  {
    try
    {
      string[] strArray = ParameterValue.Split('=');
      if (strArray != null)
      {
        if (strArray.Length == 2)
          return strArray[1].Trim();
        if (strArray.Length > 2)
        {
          string parameterValue = "";
          for (int index = 1; index <= strArray.Length - 1; ++index)
          {
            string str = strArray[index].Trim();
            if (index > 1)
              str = "=" + str;
            if (str.Length == 0)
              str = "=";
            parameterValue += str;
          }
          return parameterValue;
        }
      }
      return "";
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return "";
    }
  }

  private static string GetParameterValue(string ParameterValue, bool UseEqualChar)
  {
    try
    {
      if (UseEqualChar)
      {
        string[] strArray = ParameterValue.Split('=');
        if (strArray != null)
        {
          if (strArray.Length == 2)
            return strArray[1].Trim();
          if (strArray.Length > 2)
          {
            string parameterValue = "";
            for (int index = 1; index <= strArray.Length - 1; ++index)
            {
              string str = strArray[index].Trim();
              if (index > 1)
                str = "=" + str;
              if (str.Length == 0)
                str = "=";
              parameterValue += str;
            }
            return parameterValue;
          }
        }
      }
      else if (ParameterValue.Trim().Length > 0)
        return ParameterValue;
      return "";
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return "";
    }
  }

  private static bool GetParameterValue(string ParameterValue, ref string Value)
  {
    try
    {
      string[] strArray = ParameterValue.Split('=');
      if (strArray != null)
      {
        if (strArray.Length >= 2)
        {
          Value = strArray[1].Trim();
          return true;
        }
        if (strArray.Length == 2)
        {
          Value = strArray[1].Trim();
          return true;
        }
        if (strArray.Length > 2)
        {
          for (int index = 1; index <= strArray.Length - 1; ++index)
          {
            string str = strArray[index].Trim();
            if (index > 1)
              str = "=" + str;
            if (str.Length == 0)
              str = "=";
            Value += str;
          }
          return true;
        }
      }
      return false;
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return false;
    }
  }

  private static bool GetParameterValue(
    string ParameterValue,
    ref string ParName,
    ref string Value)
  {
    try
    {
      string[] strArray = ParameterValue.Split('=');
      if (strArray != null)
      {
        if (strArray.Length == 2)
        {
          ParName = strArray[0].Trim();
          Value = strArray[1].Trim();
          return true;
        }
        if (strArray.Length > 2)
        {
          ParName = strArray[0].Trim();
          for (int index = 1; index <= strArray.Length - 1; ++index)
          {
            string str = strArray[index].Trim();
            if (index > 1)
              str = "=" + str;
            if (str.Length == 0)
              str = "=";
            Value += str;
          }
          return true;
        }
      }
      return false;
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return false;
    }
  }

  public static string ToDef(Pnt3D P) => $"{P.X.ToString()} ; {P.Y.ToString()} ; {P.Z.ToString()}";

  public static string ToDef(Pnt4D P)
  {
    return $"{P.X.ToString()} ; {P.Y.ToString()} ; {P.Z.ToString()} ; {P.W.ToString()}";
  }

  public static string ToDef(Vec3D P) => $"{P.X.ToString()} ; {P.Y.ToString()} ; {P.Z.ToString()}";

  public static string ToDef(OrientationAngle P)
  {
    return $"{P.A.ToString()} ; {P.B.ToString()} ; {P.C.ToString()}";
  }

  public static ArrayList ToDef(WorkPlane P, string Char, int Space)
  {
    ArrayList def = new ArrayList();
    string str = Char;
    if (str.Length <= 0)
      str = "WorkPlane";
    def.Add((object) $"  <{str}>");
    def.Add((object) ("  " + buSerilization.ToDef(P)));
    def.Add((object) $"  </{str}>");
    return def;
  }

  public static string ToDef(WorkPlane P)
  {
    return $"{P.Normalies.X.ToString()} ; {P.Normalies.Y.ToString()} ; {P.Normalies.Z.ToString()}";
  }

  public static double DecoderFromDouble(string Line)
  {
    try
    {
      string[] strArray = Line.Split(':');
      if (strArray != null)
      {
        if (strArray.Length == 1)
        {
          double result = 0.0;
          double.TryParse(strArray[0], out result);
          return result;
        }
        if (strArray.Length == 2)
        {
          double result = 0.0;
          double.TryParse(strArray[1], out result);
          return result;
        }
      }
      return 0.0;
    }
    catch (Exception ex)
    {
      return 0.0;
    }
  }

  public static int DecoderFromInt(string Line)
  {
    try
    {
      string[] strArray = Line.Split(':');
      if (strArray != null)
      {
        if (strArray.Length == 1)
        {
          int result = 0;
          int.TryParse(strArray[0], out result);
          return result;
        }
        if (strArray.Length == 2)
        {
          int result = 0;
          int.TryParse(strArray[1], out result);
          return result;
        }
      }
      return 0;
    }
    catch (Exception ex)
    {
      return 0;
    }
  }

  public static float DecoderFromFloat(string Line)
  {
    try
    {
      string[] strArray = Line.Split(':');
      if (strArray != null)
      {
        if (strArray.Length == 1)
        {
          float result = 0.0f;
          float.TryParse(strArray[0], out result);
          return result;
        }
        if (strArray.Length == 2)
        {
          float result = 0.0f;
          float.TryParse(strArray[1], out result);
          return result;
        }
      }
      return 0.0f;
    }
    catch (Exception ex)
    {
      return 0.0f;
    }
  }

  public static bool DecoderFromBool(string Line)
  {
    try
    {
      string[] strArray = Line.Split(':');
      if (strArray != null)
      {
        if (strArray.Length == 1)
        {
          bool result = false;
          bool.TryParse(strArray[0], out result);
          return result;
        }
        if (strArray.Length == 2)
        {
          bool result = false;
          bool.TryParse(strArray[1], out result);
          return result;
        }
      }
      return false;
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public static string DecoderFromString(string Line)
  {
    try
    {
      string[] strArray = Line.Split(':');
      if (strArray != null)
      {
        if (strArray.Length == 1)
          return strArray[0];
        if (strArray.Length == 2)
          return strArray[1];
      }
      return "";
    }
    catch (Exception ex)
    {
      return "";
    }
  }

  public static Pnt4D DecoderFromPoint4D(string Line)
  {
    try
    {
      string[] strArray1 = Line.Split(':');
      if (strArray1 != null)
      {
        string str = "";
        if (strArray1.Length == 1)
          str = strArray1[0];
        if (strArray1.Length == 2)
          str = strArray1[1];
        if (str.Length > 0)
        {
          string[] strArray2 = str.Split(';');
          if (strArray2.Length == 3)
          {
            double result1 = 0.0;
            double result2 = 0.0;
            double result3 = 0.0;
            double.TryParse(strArray2[0], out result1);
            double.TryParse(strArray2[1], out result2);
            double.TryParse(strArray2[2], out result3);
            return new Pnt4D(result1, result2, result3, 0.0);
          }
          if (strArray2.Length == 4)
          {
            double result4 = 0.0;
            double result5 = 0.0;
            double result6 = 0.0;
            double result7 = 0.0;
            double.TryParse(strArray2[0], out result4);
            double.TryParse(strArray2[1], out result5);
            double.TryParse(strArray2[2], out result6);
            double.TryParse(strArray2[3], out result7);
            return new Pnt4D(result4, result5, result6, result7);
          }
        }
      }
      return new Pnt4D();
    }
    catch (Exception ex)
    {
      return new Pnt4D();
    }
  }

  public static Vec3D DecoderFromVector3D(string Line)
  {
    try
    {
      string[] strArray1 = Line.Split(':');
      if (strArray1 != null)
      {
        string str = "";
        if (strArray1.Length == 1)
          str = strArray1[0];
        if (strArray1.Length == 2)
          str = strArray1[1];
        if (str.Length > 0)
        {
          string[] strArray2 = str.Split(';');
          if (strArray2.Length == 3)
          {
            double result1 = 0.0;
            double result2 = 0.0;
            double result3 = 0.0;
            double.TryParse(strArray2[0], out result1);
            double.TryParse(strArray2[1], out result2);
            double.TryParse(strArray2[2], out result3);
            return new Vec3D(result1, result2, result3);
          }
        }
      }
      return new Vec3D();
    }
    catch (Exception ex)
    {
      return new Vec3D();
    }
  }

  public static WorkPlane DecoderFromPlane(string Line)
  {
    try
    {
      return (WorkPlane) null;
    }
    catch (Exception ex)
    {
      return new WorkPlane();
    }
  }

  public static OrientationAngle DecoderFromOrientationAngle(string Line)
  {
    try
    {
      string[] strArray = Line.Split(':');
      if (strArray != null)
      {
        string str = "";
        if (strArray.Length == 1)
          str = strArray[0];
        if (strArray.Length == 2)
          str = strArray[1];
        if (str.Length > 0)
        {
          if (str.Split(';').Length == 3)
          {
            double result1 = 0.0;
            double result2 = 0.0;
            double result3 = 0.0;
            double.TryParse(strArray[0], out result1);
            double.TryParse(strArray[1], out result2);
            double.TryParse(strArray[2], out result3);
            return new OrientationAngle(result1, result2, result3);
          }
        }
      }
      return new OrientationAngle();
    }
    catch (Exception ex)
    {
      return new OrientationAngle();
    }
  }

  public static Pnt3D DecoderFromPnt3D(string Line)
  {
    try
    {
      string[] strArray1 = Line.Split(':');
      if (strArray1 != null)
      {
        string str = "";
        if (strArray1.Length == 1)
          str = strArray1[0];
        if (strArray1.Length == 2)
          str = strArray1[1];
        if (str.Length > 0)
        {
          string[] strArray2 = str.Split(';');
          if (strArray2.Length == 3)
          {
            double result1 = 0.0;
            double result2 = 0.0;
            double result3 = 0.0;
            double.TryParse(strArray2[0], out result1);
            double.TryParse(strArray2[1], out result2);
            double.TryParse(strArray2[2], out result3);
            return new Pnt3D(result1, result2, result3);
          }
        }
      }
      return new Pnt3D();
    }
    catch (Exception ex)
    {
      return new Pnt3D();
    }
  }

  public static Pnt6D DecoderFromPnt6D(string Line)
  {
    try
    {
      string[] strArray1 = Line.Split(':');
      if (strArray1 != null)
      {
        string str = "";
        if (strArray1.Length == 1)
          str = strArray1[0];
        if (strArray1.Length == 2)
          str = strArray1[1];
        if (str.Length > 0)
        {
          string[] strArray2 = str.Split(';');
          if (strArray2.Length == 6)
          {
            double result1 = 0.0;
            double result2 = 0.0;
            double result3 = 0.0;
            double result4 = 0.0;
            double result5 = 0.0;
            double result6 = 0.0;
            double.TryParse(strArray2[0], out result1);
            double.TryParse(strArray2[1], out result2);
            double.TryParse(strArray2[2], out result3);
            double.TryParse(strArray2[3], out result4);
            double.TryParse(strArray2[4], out result5);
            double.TryParse(strArray2[5], out result6);
            return new Pnt6D(result1, result2, result3, result4, result5, result6);
          }
        }
      }
      return new Pnt6D();
    }
    catch (Exception ex)
    {
      return new Pnt6D();
    }
  }

  public static entitySortDirection DecoderFromSortDirection(string Line)
  {
    try
    {
      string[] strArray = Line.Split(':');
      if (strArray != null)
      {
        if (strArray.Length == 1)
          return (entitySortDirection) new EnumConverter(typeof (entitySortDirection)).ConvertFromString(strArray[0].ToString());
        if (strArray.Length == 2)
          return (entitySortDirection) new EnumConverter(typeof (entitySortDirection)).ConvertFromString(strArray[1].ToString());
      }
      return entitySortDirection.Normal;
    }
    catch (Exception ex)
    {
      return entitySortDirection.Normal;
    }
  }

  public static entityTypeDefination DecoderFromDefinationType(string Line)
  {
    try
    {
      string[] strArray = Line.Split(':');
      if (strArray != null)
      {
        if (strArray.Length == 1)
          return (entityTypeDefination) new EnumConverter(typeof (entityTypeDefination)).ConvertFromString(strArray[0].ToString());
        if (strArray.Length == 2)
          return (entityTypeDefination) new EnumConverter(typeof (entityTypeDefination)).ConvertFromString(strArray[1].ToString());
      }
      return entityTypeDefination.None;
    }
    catch (Exception ex)
    {
      return entityTypeDefination.None;
    }
  }

  public static void ClassToString(object ObjPar, ref string Line)
  {
    List<cParameter> Vars = new List<cParameter>();
    buSerilization.GetClassVariables(ObjPar, false, false, false, false, ref Vars);
    if (Vars.Count <= 0)
      return;
    for (int index = 0; index <= Vars.Count - 1; ++index)
    {
      if (Vars[index].Value != null)
      {
        string def = Vars[index].Value.ToString();
        if (Vars[index].Field.FieldType == typeof (Pnt3D))
          def = buSerilization.ToDef((Pnt3D) Vars[index].Value);
        else if (Vars[index].Field.FieldType == typeof (Vec3D))
          def = buSerilization.ToDef((Vec3D) Vars[index].Value);
        else if (Vars[index].Field.FieldType == typeof (OrientationAngle))
          def = buSerilization.ToDef((OrientationAngle) Vars[index].Value);
        else if (Vars[index].Field.FieldType == typeof (Pnt3D))
          def = ((Pnt3D) Vars[index].Value).ToDef();
        else if (Vars[index].Field.FieldType == typeof (Pnt6D))
          def = ((Pnt6D) Vars[index].Value).ToDef();
        else if (Vars[index].Field.FieldType == typeof (WorkPlane))
          def = buSerilization.ToDef((WorkPlane) Vars[index].Value);
        if (Line.Length == 0)
          Line = $"{Vars[index].Name}: {def}";
        else
          Line = $"{Line} | {Vars[index].Name}: {def}";
      }
    }
  }

  public static string ClassToString(object ObjPar)
  {
    string Line = "";
    buSerilization.ClassToString(ObjPar, ref Line);
    return Line;
  }

  public static void StringToClass(ref object ObjPar, string Line)
  {
    if (Line.Trim().Length <= 0)
      return;
    string[] strArr = Line.Split('|');
    if (strArr != null && strArr.Length != 0)
    {
      List<cParameter> Vars = new List<cParameter>();
      buSerilization.GetClassVariables(ObjPar, false, false, false, false, ref Vars);
      for (int index = 0; index <= Vars.Count - 1; ++index)
      {
        string stringArrayByName = buSerilization.GetValueFromStringArrayByName(strArr, Vars[index].Name);
        FieldInfo field = Vars[index].Field;
        if (stringArrayByName.Length > 0)
        {
          buSerilization.SetObjectValueByType(ref field, ref ObjPar, (object) stringArrayByName);
          Vars[index].ValueAsString = stringArrayByName;
        }
      }
    }
  }

  public static string GetValueFromLineByName(string Line, string ParName)
  {
    return buSerilization.GetValueFromStringArrayByName(Line.Split('|'), ParName);
  }

  public static string GetValueFromStringArrayByName(string[] strArr, string ParName)
  {
    string stringArrayByName1 = "";
    if (strArr != null && strArr.Length != 0)
    {
      for (int index = 0; index <= strArr.Length - 1; ++index)
      {
        string[] strArray = strArr[index].Split(':');
        if (strArray != null && strArray.Length == 2)
        {
          string str = strArray[0].Trim();
          string stringArrayByName2 = strArray[1].Trim();
          if (str.Trim().ToLower() == ParName.Trim().ToLower())
            return stringArrayByName2;
        }
      }
    }
    return stringArrayByName1;
  }
}
