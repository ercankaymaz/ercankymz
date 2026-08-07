// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.pageInfo
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;

#nullable disable
namespace buEyeBaseVer5;

public class pageInfo
{
  public static byte f000111;

  internal ArrayList \u0002([In] string obj0, [In] object obj1, [In] int obj2)
  {
    try
    {
      string str1 = new string(' ', obj2);
      ArrayList arrayList = new ArrayList();
      if (obj1 == null)
        return arrayList;
      string str2 = obj1.GetType().ToString();
      if (str2.IndexOf("System.Double[]") >= 0)
      {
        arrayList.Add((object) $"{str1}<{obj0}>");
        string str3 = new string(' ', obj2 + 2);
        for (int index = 0; index <= ((double[]) obj1).Length - 1; ++index)
        {
          double num = ((double[]) obj1)[index];
          arrayList.Add((object) $"{str3}{obj0} = {num.ToString()}");
        }
        arrayList.Add((object) $"{str1}</{obj0}>");
      }
      if (str2.IndexOf("System.Int32[]") >= 0)
      {
        arrayList.Add((object) $"{str1}<{obj0}>");
        string str4 = new string(' ', obj2 + 2);
        for (int index = 0; index <= ((int[]) obj1).Length - 1; ++index)
        {
          int num = ((int[]) obj1)[index];
          arrayList.Add((object) $"{str4}{obj0} = {num.ToString()}");
        }
        arrayList.Add((object) $"{str1}</{obj0}>");
      }
      if (str2.IndexOf("System.Single[]") >= 0)
      {
        arrayList.Add((object) $"{str1}<{obj0}>");
        string str5 = new string(' ', obj2 + 2);
        for (int index = 0; index <= ((float[]) obj1).Length - 1; ++index)
        {
          float num = ((float[]) obj1)[index];
          arrayList.Add((object) $"{str5}{obj0} = {num.ToString()}");
        }
        arrayList.Add((object) $"{str1}</{obj0}>");
      }
      if (str2.IndexOf("System.Boolean[]") >= 0)
      {
        arrayList.Add((object) $"{str1}<{obj0}>");
        string str6 = new string(' ', obj2 + 2);
        for (int index = 0; index <= ((bool[]) obj1).Length - 1; ++index)
        {
          bool flag = ((bool[]) obj1)[index];
          arrayList.Add((object) $"{str6}{obj0} = {flag.ToString()}");
        }
        arrayList.Add((object) $"{str1}</{obj0}>");
      }
      if (str2.IndexOf("System.String[]") >= 0)
      {
        arrayList.Add((object) $"{str1}<{obj0}>");
        string str7 = new string(' ', obj2 + 2);
        for (int index = 0; index <= ((string[]) obj1).Length - 1; ++index)
        {
          string str8 = ((string[]) obj1)[index];
          arrayList.Add((object) $"{str7}{obj0} = {str8.ToString()}");
        }
        arrayList.Add((object) $"{str1}</{obj0}>");
      }
      return arrayList;
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return new ArrayList();
    }
  }
}
