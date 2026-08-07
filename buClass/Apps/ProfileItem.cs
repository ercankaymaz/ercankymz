// Decompiled with JetBrains decompiler
// Type: buClass.Apps.ProfileItem
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class ProfileItem : buSerilization
{
  public string ItemName = "";
  public bool IsSorted = false;
  public bool IsClamperDone = false;
  public double Length = 1000.0;
  public double Width = 0.0;
  public double Height = 0.0;
  public double SupportBlockZWidth = 0.0;
  public double SupportBlockZHeight = 0.0;
  public double SupportBlockZLength = 0.0;
  public double SupportBlockY1Width = 0.0;
  public double SupportBlockY1Height = 0.0;
  public double SupportBlockY1Length = 0.0;
  public double SupportBlockY2Width = 0.0;
  public double SupportBlockY2Height = 0.0;
  public double SupportBlockY2Length = 0.0;
  public double Thickness = 1.0;
  public int MaxClamperNumber = 4;
  public MaterialSkin Skin = new MaterialSkin();
  public Vec3D Direction = new Vec3D(1.0, 0.0, 0.0);
  public Color Color = Color.DarkGray;
  public int Transparency = 120;
  public List<ProfileOperation> Operations = new List<ProfileOperation>();
  public List<eEntities> SolidEntities = new List<eEntities>();
  public List<eEntities> AuxEntities = new List<eEntities>();
  public List<eEntities> SupportBlockEntities = new List<eEntities>();
  public List<Triangle3D> Triangles = new List<Triangle3D>();
  public List<Pnt3D> OutterPoints = new List<Pnt3D>();
  public List<List<Pnt3D>> InnerPoints = new List<List<Pnt3D>>();
  public List<eEntities> OutterEntitites = new List<eEntities>();
  public List<List<eEntities>> InnerEntities = new List<List<eEntities>>();
  public List<ProfileClamper> Clampers = new List<ProfileClamper>();
  public ProfileClamperSettings ClamperSettings = new ProfileClamperSettings();

  public ProfileItem()
  {
  }

  public ProfileItem(ProfileItem data)
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
    this.Clampers.Clear();
    this.Clampers = new List<ProfileClamper>();
    for (int index = 0; index <= data.Clampers.Count - 1; ++index)
      this.Clampers.Add(new ProfileClamper(data.Clampers[index]));
    this.ClamperSettings = new ProfileClamperSettings(data.ClamperSettings);
    this.SolidEntities.Clear();
    eEntities.CopyEntities(data.SolidEntities, ref this.SolidEntities);
    this.AuxEntities.Clear();
    eEntities.CopyEntities(data.AuxEntities, ref this.AuxEntities);
    this.SupportBlockEntities.Clear();
    this.SupportBlockEntities = new List<eEntities>();
    eEntities.CopyEntities(data.SupportBlockEntities, ref this.SupportBlockEntities);
    this.Triangles.Clear();
    this.Triangles = new List<Triangle3D>();
    Triangle3D.Copy(data.Triangles, ref this.Triangles);
    this.OutterPoints.Clear();
    this.OutterPoints = new List<Pnt3D>();
    Pnt3D.Copy(data.OutterPoints, ref this.OutterPoints);
    this.InnerPoints.Clear();
    this.InnerPoints = new List<List<Pnt3D>>();
    Pnt3D.Copy(data.InnerPoints, ref this.InnerPoints);
    this.OutterEntitites.Clear();
    this.OutterEntitites = new List<eEntities>();
    eEntities.CopyEntities(data.OutterEntitites, ref this.OutterEntitites);
    this.InnerEntities.Clear();
    this.InnerEntities = new List<List<eEntities>>();
    eEntities.CopyEntities(data.InnerEntities, ref this.InnerEntities);
    this.Operations = new List<ProfileOperation>();
    ProfileOperation.Copy(data.Operations, ref this.Operations);
  }

  public static ArrayList ToDef(List<ProfileItem> Items, int Space)
  {
    string str = new string(' ', Space);
    ArrayList def = new ArrayList();
    for (int index = 0; index <= Items.Count - 1; ++index)
    {
      ArrayList arrayList = new ArrayList();
      arrayList.AddRange((ICollection) ProfileItem.ToDef(Items[index], Space).ToArray());
      def.AddRange((ICollection) arrayList.ToArray());
    }
    return def;
  }

  public static ArrayList ToDef(ProfileItem Item, int Space)
  {
    string str = new string(' ', Space);
    ArrayList def = new ArrayList();
    def.AddRange((ICollection) Item.ToDefAll("", Space + 2, SerilizationMode.MultiLine));
    def.RemoveAt(def.Count - 1);
    def.AddRange((ICollection) ProfileOperation.ToDef(Item.Operations, "", Space + 2));
    def.Add((object) (str + "</ProfileItem>"));
    return def;
  }

  public static void Decode(ArrayList AL, ref List<ProfileItem> Items)
  {
    Items.Clear();
    Items = new List<ProfileItem>();
    List<List<string>> stringListList = new List<List<string>>();
    List<List<string>> CalcList = new List<List<string>>();
    buStatics.ListToSpecificList("<ProfileItem>", "</ProfileItem>", true, AL, ref CalcList);
    for (int index = 0; index <= CalcList.Count - 1; ++index)
    {
      ArrayList AL1 = new ArrayList();
      AL1.AddRange((ICollection) CalcList[index].ToArray());
      ProfileItem profileItem = new ProfileItem();
      ProfileItem.Decode(AL1, ref profileItem);
      Items.Add(profileItem);
    }
  }

  public static void Decode(ArrayList AL, ref ProfileItem Item)
  {
    Item = new ProfileItem();
    buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) Item);
    List<List<string>> CalcList = new List<List<string>>();
    buStatics.ListToSpecificList("<ProfileOperation>", "</ProfileOperation>", false, AL, ref CalcList);
    for (int index = 0; index <= CalcList.Count - 1; ++index)
    {
      ArrayList AL1 = new ArrayList();
      AL1.AddRange((ICollection) CalcList[index].ToArray());
      ProfileOperation OP = new ProfileOperation();
      ProfileOperation.Decode(AL1, ref OP);
      Item.Operations.Add(OP);
    }
  }

  public override string ToString()
  {
    return $"{this.ItemName.ToString()}- Len: {this.Length.ToString("f3")}";
  }
}
