// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Library.LibraryManager
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buEyeBaseVer5;
using buEyeBaseVer5.buEntities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buCadCamResVer5.Library;

[Serializable]
public class LibraryManager : buSerilization5
{
  public List<LibraryConstraints> ConstraintList = new List<LibraryConstraints>();
  public List<buEntity> Entities = new List<buEntity>();

  public LibraryManager()
  {
  }

  public LibraryManager(LibraryManager data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
    {
      FieldInfo[] fields = this.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          string name = fields[index].Name;
          object obj = fields[index].GetValue(CopiedClass);
          fields[index].SetValue((object) this, obj);
        }
      }
    }
    for (int index = 0; index <= data.ConstraintList.Count - 1; ++index)
      this.ConstraintList.Add(new LibraryConstraints(data.ConstraintList[index]));
  }

  public static ArrayList ToDef(LibraryManager LibManager)
  {
    ArrayList def = new ArrayList();
    for (int index = 0; index <= LibManager.ConstraintList.Count - 1; ++index)
      def.AddRange((ICollection) LibManager.ConstraintList[index].ToDefAll("", 4, SerilizationMode5.MultiLine));
    return def;
  }

  public static void Decode(List<string> SL, ref LibraryManager LibManager)
  {
    List<List<string>> CalcList = new List<List<string>>();
    buString5.ListToSpecificList("<LibraryConstraints>", "</LibraryConstraints>", true, SL, ref CalcList);
    for (int index = 0; index <= CalcList.Count - 1; ++index)
    {
      LibraryConstraints libraryConstraints = new LibraryConstraints();
      buSerilization5.Decode(CalcList[index], "", SerilizationMode5.MultiLine, (object) libraryConstraints);
      LibManager.ConstraintList.Add(libraryConstraints);
    }
  }

  public override string ToString()
  {
    int count = this.ConstraintList.Count;
    string str1 = count.ToString();
    count = this.Entities.Count;
    string str2 = count.ToString();
    return $"Constraint : {str1} - Entities : {str2}";
  }
}
