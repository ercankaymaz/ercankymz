// Decompiled with JetBrains decompiler
// Type: buClass.Apps.ProfileJob
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class ProfileJob : buSerilization
{
  public string Name = "Job";
  public List<ProfileItem> Items = new List<ProfileItem>();
  public int Station = 0;

  public ProfileJob()
  {
  }

  public ProfileJob(ProfileJob data)
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
    for (int index = 0; index <= data.Items.Count - 1; ++index)
      this.Items.Add(new ProfileItem(data.Items[index]));
  }

  public static ArrayList ToDef(List<ProfileJob> Items, int Space)
  {
    string str = new string(' ', Space);
    ArrayList def = new ArrayList();
    for (int index = 0; index <= Items.Count - 1; ++index)
    {
      ArrayList c = new ArrayList();
      c.AddRange((ICollection) ProfileJob.ToDef(Items[index], Space).ToArray());
      def.AddRange((ICollection) c);
    }
    return def;
  }

  public static ArrayList ToDef(ProfileJob Item, int Space)
  {
    string str = new string(' ', Space);
    ArrayList def = new ArrayList();
    def.AddRange((ICollection) Item.ToDefAll("", 2, SerilizationMode.MultiLine).ToArray());
    def.RemoveAt(def.Count - 1);
    def.AddRange((ICollection) ProfileItem.ToDef(Item.Items, Space + 2));
    def.Add((object) (str + "</ProfileJob>"));
    return def;
  }

  public static void Decode(List<string> AL, ref ProfileJob Job)
  {
    Job = new ProfileJob();
    List<List<string>> CalcList1 = new List<List<string>>();
    buStatics.ListToSpecificList("<ProfileJob>", "</ProfileJob>", true, AL, ref CalcList1);
    if (CalcList1.Count <= 0)
      return;
    ArrayList arrayList = new ArrayList();
    arrayList.AddRange((ICollection) CalcList1[0].ToArray());
    buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, (object) Job);
    List<List<string>> CalcList2 = new List<List<string>>();
    buStatics.ListToSpecificList("<ProfileItem>", "</ProfileItem>", true, arrayList, ref CalcList2);
    ProfileItem.Decode(arrayList, ref Job.Items);
  }

  public override string ToString() => this.Name.ToString();
}
