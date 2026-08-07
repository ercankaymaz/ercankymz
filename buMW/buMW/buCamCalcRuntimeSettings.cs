// Decompiled with JetBrains decompiler
// Type: buMW.buCamCalcRuntimeSettings
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buEyeBaseVer5;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buMW;

public class buCamCalcRuntimeSettings : buSerilization5
{
  public double CamMarkSize;

  public buCamCalcRuntimeSettings(buCamCalcSettings data)
  {
    ((buCamCalcSettings) this).ShowMwDialogBox = false;
    ((buCamCalcSettings) this).XAxisMinLimit = 0.0;
    ((buCamCalcSettings) this).XAxisMaxLimit = 0.0;
    ((buCamCalcSettings) this).YAxisMinLimit = 0.0;
    ((buCamCalcSettings) this).YAxisMaxLimit = 0.0;
    ((buCamCalcSettings) this).ZAxisMinLimit = 0.0;
    ((buCamCalcSettings) this).ZAxisMaxLimit = 0.0;
    ((buCamCalcSettings) this).AAxisMinLimit = 0.0;
    ((buCamCalcSettings) this).AAxisMaxLimit = 0.0;
    ((buCamCalcSettings) this).BAxisMinLimit = 0.0;
    ((buCamCalcSettings) this).BAxisMaxLimit = 0.0;
    ((buCamCalcSettings) this).CAxisMinLimit = 0.0;
    ((buCamCalcSettings) this).CAxisMaxLimit = 0.0;
    ((buCamCalcSettings) this).CopyToolDataToCamData = false;
    ((buCamCalcSettings) this).CopyToolFeedToCamFeed = true;
    ((buCamCalcSettings) this).CopyToolPlungeFeedToCamPlungeFeed = true;
    ((buCamCalcSettings) this).CopyToolRetractFeedToCamRetractFeed = true;
    ((buCamCalcSettings) this).ShowProgressForm = true;
    ((buCamCalcSettings) this).CamMarkDraw = new drawPropertiesType(Color.DarkGreen, 2f, new drawingPattern());
    ((buCamCalcSettings) this).CamG0Draw = new drawPropertiesType(Color.Brown, 2f, new drawingPattern());
    ((buCamCalcSettings) this).CamG1Draw = new drawPropertiesType(Color.Blue, 2f, new drawingPattern());
    ((buCamCalcSettings) this).CamPlungeDraw = new drawPropertiesType(Color.Lime, 2f, new drawingPattern());
    ((buCamCalcSettings) this).CamLeaveDraw = new drawPropertiesType(Color.Red, 2f, new drawingPattern());
    ((buCamCalcSettings) this).CamLeadinDraw = new drawPropertiesType(Color.Cyan, 2f, new drawingPattern());
    ((buCamCalcSettings) this).CamLeadOutDraw = new drawPropertiesType(Color.Orange, 2f, new drawingPattern());
    ((buCamCalcSettings) this).CamConnectionDraw = new drawPropertiesType(Color.Purple, 2f, new drawingPattern());
    ((buCamCalcSettings) this).CamOtherDraw = new drawPropertiesType(Color.DarkGray, 2f, new drawingPattern());
    this.CamMarkSize = 0.5;
    // ISSUE: explicit constructor call
    base.\u002Ector();
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

  public buCamCalcRuntimeSettings()
  {
    ((buMWCaptions) this).CamLinkEntitiesAsG1 = true;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }
}
