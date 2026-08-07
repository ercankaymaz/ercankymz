// Decompiled with JetBrains decompiler
// Type: buClass.UserFiles.buCad.setProgram
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buClass.UserFiles.buCad;

public class setProgram : buSerilization
{
  public bool OsnapCalculation = true;
  public bool TouchPad = false;
  public int MaxPageCount = 5;
  public bool DontShowMenuWhenNoPage = true;
  public bool ShowFastDraw = true;
  public bool ContinousDrawingMode = true;
  public bool AutoSaveFiles = false;
  public int AutoSaveMinute = 2;
  public bool Mode2D = false;
  public bool UndoEnable = true;
  public int DecimalVisiblePoint = 2;
  public bool ShowToolTipWindow = true;
  public int ToolTipTime = 1000;
  public int UndoBufferCount = 50;
  public bool MotionEnable = false;
  public bool ShowPasswordPageIfNoAccessLevel = true;
  public bool EventCommandRepitation = false;
  public bool DrawCommandRepitation = false;
  public int RecordTickTime = 50;
  public double RecordQuatity = 50.0;
  public int RecordMaxFrame = 1000;
  public LeftRightAlignment ToolLocation = LeftRightAlignment.Left;
  public LeftRightAlignment LayerLocation = LeftRightAlignment.Left;
  public LeftRightAlignment PageLocation = LeftRightAlignment.Left;
  public LeftRightAlignment CamLocation = LeftRightAlignment.Left;
  public LeftRightAlignment MiscLocation = LeftRightAlignment.Left;
  public LeftRightAlignment MaterialLocation = LeftRightAlignment.Left;
  public bool ToolPageVisible = true;
  public bool LayerPageVisible = true;
  public bool PagePageVisible = true;
  public bool CamPageVisible = true;
  public bool MiscPageVisible = true;
  public bool MaterialPageVisible = true;
  public bool MiscPagePreviewEnable = false;
  public Color ButtonSelectedColor = Color.DimGray;
  public Color ButtonUnselectedColor = Color.Gainsboro;
  public int LayerNameColoumColorWidth = 35;
  public int LayerNameColoumEnableWidth = 35;
  public bool LayerColorNameShow = true;
  public bool LayerDefinationShow = true;
  public float LayerFontSize = 9f;
  public int LeftRightMenuTabHeight = 20;
  public bool ShowPostProcessorAtMenu = true;
  public bool ShowFileLargeMenu = true;
  public bool ShowFileSmallMenu = true;
  public bool ShowViewLargeMenu = true;
  public bool ShowViewSmallMenu = true;
  public bool ShowEditSmallMenu = true;
  public bool ShowBarViewMenu = true;
  public bool WindowsMaximize = false;
  public ToolPanelSetting ToolPanelSettings = new ToolPanelSetting();
  public LayerPanelSetting LayerPanelSettings = new LayerPanelSetting();
  public CamPanelSetting CamPanelSettings = new CamPanelSetting();
  public PagePanelSetting PagePanelSettings = new PagePanelSetting();

  public setProgram()
  {
  }

  public setProgram(setProgram data)
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
}
