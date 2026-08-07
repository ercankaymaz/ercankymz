// Decompiled with JetBrains decompiler
// Type: buClass.CharLibrary
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class CharLibrary : buSerilization
{
  public string Char = "";
  public List<geoEntity> CharEntities = new List<geoEntity>();

  public CharLibrary()
  {
  }

  public CharLibrary(CharLibrary data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
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
    this.CharEntities = new List<geoEntity>();
    geoEntity.Copy(data.CharEntities, ref this.CharEntities);
  }

  public static void Copy(CharLibrary Base, ref CharLibrary Copied)
  {
    Copied = new CharLibrary(Base);
  }

  public static void Copy(List<CharLibrary> Base, ref List<CharLibrary> Copied)
  {
    Copied.Clear();
    Copied = new List<CharLibrary>();
    for (int index = 0; index <= Base.Count - 1; ++index)
    {
      CharLibrary charLibrary = new CharLibrary(Base[index]);
      Copied.Add(charLibrary);
    }
  }

  public static ArrayList ToDef(List<CharLibrary> Chars, int Space)
  {
    string str1 = new string(' ', Space);
    string str2 = new string(' ', Space + 2);
    string str3 = new string(' ', Space + 6);
    string str4 = new string(' ', Space + 8);
    ArrayList def = new ArrayList();
    def.Add((object) (str1 + "<CharacterLibrary>"));
    for (int index1 = 0; index1 <= Chars.Count - 1; ++index1)
    {
      def.AddRange((ICollection) Chars[index1].ToDefAll("", 4 + Space, SerilizationMode.MultiLine));
      string str5 = def[def.Count - 1].ToString();
      def.RemoveAt(def.Count - 1);
      def.Add((object) (str3 + "<CharEntities>"));
      for (int index2 = 0; index2 <= Chars[index1].CharEntities.Count - 1; ++index2)
      {
        if (Chars[index1].CharEntities != null)
          def.AddRange((ICollection) Chars[index1].CharEntities[index2].ToDefAll(8 + Space));
      }
      def.Add((object) (str3 + "</CharEntities>"));
      def.Add((object) str5);
    }
    def.Add((object) (str1 + "</CharacterLibrary>"));
    return def;
  }

  public static void Decode(ArrayList AL, ref List<CharLibrary> Chars)
  {
    List<List<string>> stringListList = new List<List<string>>();
    Chars.Clear();
    Chars = new List<CharLibrary>();
    List<List<string>> CalcList1 = new List<List<string>>();
    buStatics.ListToSpecificList("<CharLibrary>", "</CharLibrary>", true, AL, ref CalcList1);
    for (int index1 = 0; index1 <= CalcList1.Count - 1; ++index1)
    {
      ArrayList arrayList = new ArrayList();
      arrayList.AddRange((ICollection) CalcList1[index1].ToArray());
      CharLibrary charLibrary = new CharLibrary();
      buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, (object) charLibrary);
      List<string> CalcList2 = new List<string>();
      buStatics.ListToSpecificList("<CharEntities>", "</CharEntities>", true, arrayList, ref CalcList2);
      List<List<string>> CalcList3 = new List<List<string>>();
      buStatics.ListToSpecificList("<geoEntity>", "</geoEntity>", false, CalcList2, ref CalcList3);
      for (int index2 = 0; index2 <= CalcList3.Count - 1; ++index2)
      {
        geoEntity geoEntity1 = new geoEntity();
        geoEntity geoEntity2 = geoEntity.Decode(CalcList3[index2], "", SerilizationMode.MultiLine);
        charLibrary.CharEntities.Add(geoEntity2);
      }
      Chars.Add(charLibrary);
    }
  }

  public override string ToString()
  {
    return $"{this.Char} , Ent Count : {this.CharEntities.Count.ToString()}";
  }
}
