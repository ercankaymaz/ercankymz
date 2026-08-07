// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.GeometryTableItem
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Eyeshot.Translators;
using System;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class GeometryTableItem : buSerilization5
{
  public string A;
  public string B;
  public string C;
  public string U;

  public GeometryTableItem()
  {
    ((hmiUIPars) this).Version = autodeskVersionType.Acad2000;
    ((hmiUIPars) this).Deviation = 0.0;
    ((hmiUIPars) this).ExplodeViews = false;
    ((hmiUIPars) this).Password = "";
    ((hmiUIBasicPars) this).CurveAsFitSpline = false;
    ((hmiUIBasicPars) this).AciColors = true;
    ((hmiUIBasicPars) this).Purge = false;
    ((hmiUIOptions) this).SelectedOnly = false;
    ((hmiUIOptions) this).Convert2PointLinearPathToLine = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public GeometryTableItem(WriteDxfDwgPropeties data)
  {
    ((hmiUIPars) this).Version = autodeskVersionType.Acad2000;
    ((hmiUIPars) this).Deviation = 0.0;
    ((hmiUIPars) this).ExplodeViews = false;
    ((hmiUIPars) this).Password = "";
    ((hmiUIBasicPars) this).CurveAsFitSpline = false;
    ((hmiUIBasicPars) this).AciColors = true;
    ((hmiUIBasicPars) this).Purge = false;
    ((hmiUIOptions) this).SelectedOnly = false;
    ((hmiUIOptions) this).Convert2PointLinearPathToLine = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public abstract void m000356();

  public GeometryTableItem()
  {
    ((hmiUIOptions) this).Color = Color.DarkGray;
    ((hmiUIOptions) this).Transperancy = (int) byte.MaxValue;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
