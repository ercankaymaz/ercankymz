// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Clamper
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class Clamper : buSerilization5
{
  public bool PolylineToLine;
  public bool CompositeCurveToEntities;
  public bool CurveToPolyLine;
  public bool CircleTo4Arc;
  public bool ArcToPoyline;
  public bool EllipseToPoyline;
  public bool CircleToPoyline;
  public double MinLength;
  public double RegenDev;
  public double PolylineToLineMinLength;

  public Clamper(CharLibrary5 data)
  {
    ((EntitiesCopySettings) this).Char = "";
    ((EntitiesCopySettings) this).Index = 0;
    ((EntitiesCopySettings) this).CharEntities = new List<buEntity>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
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
    buRadialDim.Copy(((EntitiesCopySettings) data).CharEntities, ref ((EntitiesCopySettings) this).CharEntities);
  }

  public static void Copy(CharLibrary5 Base, ref CharLibrary5 Copied)
  {
    Copied = (CharLibrary5) new Clamper(Base);
  }

  public static void Copy(List<CharLibrary5> Base, ref List<CharLibrary5> Copied)
  {
    Copied.Clear();
    Copied = new List<CharLibrary5>();
    for (int index = 0; index <= Base.Count - 1; ++index)
    {
      CharLibrary5 charLibrary5 = (CharLibrary5) new Clamper(Base[index]);
      Copied.Add(charLibrary5);
    }
  }

  public static ArrayList ToDef(List<CharLibrary5> Chars, int Space)
  {
    ArrayList def = new ArrayList();
    for (int index1 = 0; index1 <= Chars.Count - 1; ++index1)
    {
      def.Add((object) (buImage5.SpaceChar(Space) + "<CharacterLibrary>"));
      def.AddRange((ICollection) Chars[index1].ToDefAll("", Space + 2, (SerilizationMode5) 1));
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "<CharEntities>"));
      for (int index2 = 0; index2 <= ((EntitiesCopySettings) Chars[index1]).CharEntities.Count - 1; ++index2)
      {
        if (((EntitiesCopySettings) Chars[index1]).CharEntities != null)
          def.AddRange((ICollection) buText.ToDefEntity(((EntitiesCopySettings) Chars[index1]).CharEntities[index2], Space + 4));
      }
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "</CharEntities>"));
      def.Add((object) (buImage5.SpaceChar(Space) + "</CharacterLibrary>"));
    }
    return def;
  }

  public static void Decode(ArrayList AL, ref List<CharLibrary5> Chars)
  {
    Chars.Clear();
    Chars = new List<CharLibrary5>();
    List<List<string>> CalcList1 = new List<List<string>>();
    buStatics.ListToSpecificList("<CharacterLibrary>", "</CharacterLibrary>", false, AL, ref CalcList1);
    for (int index1 = 0; index1 <= CalcList1.Count - 1; ++index1)
    {
      CharLibrary5 charLibrary5 = (CharLibrary5) new KinematicBase5();
      buSerilization5.Decode(CalcList1[index1], "", (SerilizationMode5) 1, (object) charLibrary5);
      List<List<string>> CalcList2 = new List<List<string>>();
      buStatics.ListToSpecificList("<buEntity>", "</buEntity>", false, CalcList1[index1], ref CalcList2);
      for (int index2 = 0; index2 <= CalcList2.Count - 1; ++index2)
      {
        buEntity buEntity = buText.Decode(CalcList2[index2]);
        if (buEntity != null)
          ((EntitiesCopySettings) charLibrary5).CharEntities.Add(buEntity);
      }
      Chars.Add(charLibrary5);
    }
  }

  public override string ToString()
  {
    return $"{((EntitiesCopySettings) this).Char} , Ent Count : {((EntitiesCopySettings) this).CharEntities.Count.ToString()}";
  }
}
