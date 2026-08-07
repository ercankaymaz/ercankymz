// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOperationDataRectangle
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOperationDataRectangle : buSerilization5
{
  public int ApproxExecution4UpDownCnt;
  public int ApproxExecution5UpDownCnt;
  public int ApproxExecution6UpDownCnt;
  public int ApproxExecution7UpDownCnt;
  public int ApproxExecution8UpDownCnt;
  public int ApproxExecution9UpDownCnt;
  public double ApproxExecution0Len;

  public abstract void m001D0F();

  public ProfileOperationDataRectangle()
  {
    ((ProfileOperationCamData) this).ShowSheetSizeOnDisplay = true;
    ((ProfileOperationCamData) this).ShowSheetNameOnDisplay = true;
    ((ProfileOperationCamData) this).ShowSheetPersentageOnDisplay = true;
    ((ProfileOperationCamData) this).ShowSheetCountOnDisplay = true;
    ((ProfileOperationCamData) this).DrawPartAsSolid = true;
    ((ProfileOperationCamData) this).DrawPartOnlyOutterSolid = false;
    ((ProfileOperationCamData) this).PartAreaOnlyFromOutter = true;
    ((ProfileOperationCamData) this).DrawSheets = false;
    ((ProfileOperationCamData) this).DrawSheetOnlyPreview = true;
    ((ProfileOperationCamData) this).DrawNestingResultAligment = HorizontalVertical.Horizontal;
    ((ProfileOperationCamData) this).DrawNestingResultSpace = 0.0;
    ((ProfileOperationCamData) this).DrawAddClearAll = true;
    ((ProfileOperationCamData) this).DrawAddToEnd = true;
    ((ProfileOperationCamData) this).DrawAddToEndOffset = 10.0;
    ((ProfileOperationCamData) this).RemnantMinLength = 300.0;
    ((ProfileOperationCamData) this).RemnantSizeOffset = 10.0;
    ((ProfileOperationCamData) this).RemnantCalculate = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public ProfileOperationDataRectangle(buNestingResultSettings data)
  {
    ((ProfileOperationCamData) this).ShowSheetSizeOnDisplay = true;
    ((ProfileOperationCamData) this).ShowSheetNameOnDisplay = true;
    ((ProfileOperationCamData) this).ShowSheetPersentageOnDisplay = true;
    ((ProfileOperationCamData) this).ShowSheetCountOnDisplay = true;
    ((ProfileOperationCamData) this).DrawPartAsSolid = true;
    ((ProfileOperationCamData) this).DrawPartOnlyOutterSolid = false;
    ((ProfileOperationCamData) this).PartAreaOnlyFromOutter = true;
    ((ProfileOperationCamData) this).DrawSheets = false;
    ((ProfileOperationCamData) this).DrawSheetOnlyPreview = true;
    ((ProfileOperationCamData) this).DrawNestingResultAligment = HorizontalVertical.Horizontal;
    ((ProfileOperationCamData) this).DrawNestingResultSpace = 0.0;
    ((ProfileOperationCamData) this).DrawAddClearAll = true;
    ((ProfileOperationCamData) this).DrawAddToEnd = true;
    ((ProfileOperationCamData) this).DrawAddToEndOffset = 10.0;
    ((ProfileOperationCamData) this).RemnantMinLength = 300.0;
    ((ProfileOperationCamData) this).RemnantSizeOffset = 10.0;
    ((ProfileOperationCamData) this).RemnantCalculate = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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

  static ProfileOperationDataRectangle() => ProfileOperationCamData.Captions = new List<string>();

  public ProfileOperationDataRectangle()
  {
    ((ProfileOperationCamData) this).PartInnerShow = true;
    ((ProfileOperationCamData) this).SheetUselessShow = true;
    ((ProfileOperationCamData) this).DrawAsSolid = true;
    ((ProfileOperationCamData) this).PartSolidColor = Color.WhiteSmoke;
    ((ProfileOperationCamData) this).SheetSolidColor = Color.MintCream;
    ((ProfileOperationCamData) this).PartEntityColor = Color.Blue;
    ((ProfileOperationSortItem) this).SheetEntityColor = Color.Black;
    ((ProfileOperationSortItem) this).PartInnerEntityColor = Color.Red;
    ((ProfileOperationSortItem) this).SheetInnerColor = Color.DarkGray;
    ((ProfileOperationSortItem) this).PartEntityThickness = 2.0;
    ((ProfileOperationSortItem) this).PartInnerEntityThickness = 3.0;
    ((ProfileClamper) this).SheetEntityThickness = 2.0;
    ((ProfileClamper) this).SheetInnerThickness = 3.0;
    ((ProfileClamper) this).GridPartSheetHeight = 40;
    ((ProfileClamper) this).GridPartSheetPreviewWidth = 100;
    ((ProfileClamper) this).ShowSheetFileNameColumb = false;
    ((ProfileClamper) this).ShowSheetItemNoColumb = false;
    ((ProfileClamper) this).ShowSheetThicknessColumb = false;
    ((ProfileClamper) this).ShowSheetOtherColumb = false;
    ((ProfileClamper) this).ShowSheetAuxColumb = false;
    ((ProfileClamper) this).ShowPartFileNameColumb = false;
    ((ProfileClamper) this).ShowPartItemNoColumb = false;
    ((ProfileClamperSettings) this).ShowPartOtherColumb = false;
    ((ProfileClamperSettings) this).ShowPartAuxColumb = false;
    ((ProfileClamperSettings) this).ShowPartThicknessColumb = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public ProfileOperationDataRectangle(buNestingDraw data)
  {
    ((ProfileOperationCamData) this).PartInnerShow = true;
    ((ProfileOperationCamData) this).SheetUselessShow = true;
    ((ProfileOperationCamData) this).DrawAsSolid = true;
    ((ProfileOperationCamData) this).PartSolidColor = Color.WhiteSmoke;
    ((ProfileOperationCamData) this).SheetSolidColor = Color.MintCream;
    ((ProfileOperationCamData) this).PartEntityColor = Color.Blue;
    ((ProfileOperationSortItem) this).SheetEntityColor = Color.Black;
    ((ProfileOperationSortItem) this).PartInnerEntityColor = Color.Red;
    ((ProfileOperationSortItem) this).SheetInnerColor = Color.DarkGray;
    ((ProfileOperationSortItem) this).PartEntityThickness = 2.0;
    ((ProfileOperationSortItem) this).PartInnerEntityThickness = 3.0;
    ((ProfileClamper) this).SheetEntityThickness = 2.0;
    ((ProfileClamper) this).SheetInnerThickness = 3.0;
    ((ProfileClamper) this).GridPartSheetHeight = 40;
    ((ProfileClamper) this).GridPartSheetPreviewWidth = 100;
    ((ProfileClamper) this).ShowSheetFileNameColumb = false;
    ((ProfileClamper) this).ShowSheetItemNoColumb = false;
    ((ProfileClamper) this).ShowSheetThicknessColumb = false;
    ((ProfileClamper) this).ShowSheetOtherColumb = false;
    ((ProfileClamper) this).ShowSheetAuxColumb = false;
    ((ProfileClamper) this).ShowPartFileNameColumb = false;
    ((ProfileClamper) this).ShowPartItemNoColumb = false;
    ((ProfileClamperSettings) this).ShowPartOtherColumb = false;
    ((ProfileClamperSettings) this).ShowPartAuxColumb = false;
    ((ProfileClamperSettings) this).ShowPartThicknessColumb = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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
}
