// Decompiled with JetBrains decompiler
// Type: buClass.SpindlePost
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class SpindlePost : buSerilization
{
  public bool UseSpindle;
  public string SpindleCWCode = "";
  public string SpindleCCWCode = "";
  public string SpindleStopCode = "";
  public bool SpindleAtToolLine = false;
  public bool SpindleMCommandFirst = false;
  public ArrayList PreCode = new ArrayList();
  public ArrayList AfterCode = new ArrayList();

  public SpindlePost()
  {
  }

  public SpindlePost(SpindlePost data)
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

  public SpindlePost(
    bool usespindle,
    bool spindleattoolline,
    string spindleCWcode,
    string spindleCCWcode,
    string spindlestopcode)
  {
    this.UseSpindle = usespindle;
    this.SpindleCWCode = spindleCWcode;
    this.SpindleCCWCode = spindleCCWcode;
    this.SpindleStopCode = spindlestopcode;
    this.SpindleAtToolLine = spindleattoolline;
  }

  public override string ToString() => "Use: " + this.UseSpindle.ToString();
}
