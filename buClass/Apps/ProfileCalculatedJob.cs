// Decompiled with JetBrains decompiler
// Type: buClass.Apps.ProfileCalculatedJob
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
public class ProfileCalculatedJob : buSerilization
{
  public string Name = "Job";
  public List<ProfileOperation> Operation = new List<ProfileOperation>();

  public ProfileCalculatedJob()
  {
  }

  public ProfileCalculatedJob(ProfileJob data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
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

  public static ArrayList ToDef(List<ProfileCalculatedJob> Items, int Space)
  {
    string str = new string(' ', Space);
    ArrayList def = new ArrayList();
    for (int index = 0; index <= Items.Count - 1; ++index)
    {
      ArrayList c = new ArrayList();
      c.AddRange((ICollection) ProfileCalculatedJob.ToDef(Items[index], Space).ToArray());
      def.AddRange((ICollection) c);
    }
    return def;
  }

  public static ArrayList ToDef(ProfileCalculatedJob Item, int Space)
  {
    string str = new string(' ', Space);
    return new ArrayList();
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
