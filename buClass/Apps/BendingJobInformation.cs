// Decompiled with JetBrains decompiler
// Type: buClass.Apps.BendingJobInformation
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class BendingJobInformation : buSerilization
{
  public int MaxBlockCount;
  public double BladeHeight;
  public int NumberOf;
  public int MirrorOf;
  public double TotalLength;
  public double CalculatedLength = 0.0;
  public string Customer = "";
  public string JobCode = "";
  public string Author = "";
  public string Explanation = "";
  public double BladeThickness;
  public double Pt = 0.0;
  public string FullFileName = "";
  public string FileNameWithoutExtension = "";
  public DateTime Date = new DateTime();
  public Color Color = Color.Black;

  public BendingJobInformation()
  {
  }

  public BendingJobInformation(BendingJobInformation data)
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

  public override string ToString()
  {
    return $"Tot Len: {this.TotalLength.ToString()} ; Calc Len : {this.CalculatedLength.ToString()} ; Number of : {this.NumberOf.ToString()} ; Mirror of : {this.MirrorOf.ToString()} ; Thickness : {this.BladeThickness.ToString()} ; Height : {this.BladeHeight.ToString()}";
  }
}
