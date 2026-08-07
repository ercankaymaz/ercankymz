// Decompiled with JetBrains decompiler
// Type: buClass.camSpeedsEnable
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class camSpeedsEnable : buSerilization
{
  public bool Feed = true;
  public bool BackwardFeed = false;
  public bool Plunge = true;
  public bool Rapid = false;
  public bool Leave = true;
  public bool Finish = true;
  public static List<string> Captions = new List<string>();

  public camSpeedsEnable()
  {
  }

  public camSpeedsEnable(
    bool feed,
    bool plunge,
    bool rapid,
    bool leave,
    bool backwardfeed,
    bool finish)
  {
    this.Feed = feed;
    this.Plunge = plunge;
    this.Rapid = rapid;
    this.Leave = leave;
    this.BackwardFeed = backwardfeed;
    this.Finish = finish;
  }

  public camSpeedsEnable(camSpeedsEnable speeds)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) speeds, ref CopiedClass);
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

  public override string ToString()
  {
    return $"Feed: {this.Feed.ToString()} , Plunge: {this.Plunge.ToString()} , Rapid: {this.Rapid.ToString()} , Leave: {this.Leave.ToString()}";
  }
}
