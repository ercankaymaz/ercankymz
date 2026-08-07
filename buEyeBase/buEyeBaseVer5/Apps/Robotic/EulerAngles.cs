// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Robotic.EulerAngles
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.Apps.Marble;
using System;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Robotic;

[Serializable]
public class EulerAngles : buSerilization5
{
  public const MarbleOperationSelectionCommand WireItem = ; // Unable to render the field
  public const MarbleOperationSelectionCommand Tool = ; // Unable to render the field
  public const MarbleOperationSelectionCommand Parameter = ; // Unable to render the field

  public EulerAngles()
  {
    ((marbleSurfaceCleanPars) this).PixelToMmX = 3.0;
    ((marbleSurfaceCleanPars) this).PixelToMmY = 3.0;
    ((marbleSurfaceCleanPars) this).SheetInnerMakeItHoleas3D = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public EulerAngles(MarbleImageSettings data)
  {
    ((marbleSurfaceCleanPars) this).PixelToMmX = 3.0;
    ((marbleSurfaceCleanPars) this).PixelToMmY = 3.0;
    ((marbleSurfaceCleanPars) this).SheetInnerMakeItHoleas3D = false;
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

  public static void Copy(MarbleImageSettings Source, ref MarbleImageSettings Target)
  {
    Target = (MarbleImageSettings) new EulerAngles(Source);
  }
}
