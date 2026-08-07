// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.PageScene
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

public class PageScene : buSerilization5, IDisposable
{
  public LinearGradientBoolType colorLinearGradientEnableDisable;
  private bool \u0001;
  public Plane ScenePlane;
  public string SceneName;
  public string SceneFileName;
  public int EntitiesCount;

  public PageScene()
  {
  }

  public PageScene()
  {
    ((clsVisualVars) this).hmiButtonMenu1 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiButtonMenu2 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiButtonMenu3 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiButtonMenu4 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiButtonCommand1 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiButtonCommand2 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiButtonCommand3 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiButtonCommand4 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiButtonSystem1 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiButtonSystem2 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiButtonSystem3 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiButtonSystem4 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiButtonOk = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiButtonCancel = (hmiUISettings) new buEyeShotFunctions();
    buEyeShotFunctions eyeShotFunctions1 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions1).Display = new buControlDisplay()
    {
      BackColor = Color.WhiteSmoke
    };
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions1).Caption = new buControlDisplay()
    {
      BackColor = Color.Orange
    };
    ((buFile5) eyeShotFunctions1).ButtonNormal = new buControlDisplay()
    {
      BackColor = Color.Silver
    };
    ((buFile5) eyeShotFunctions1).ButtonOver = new buControlDisplay()
    {
      BackColor = Color.Gray
    };
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions1).ButtonDown = new buControlDisplay()
    {
      BackColor = Color.Silver
    };
    ((clsVisualVars) this).hmiSpin1 = (hmiUISettings) eyeShotFunctions1;
    buEyeShotFunctions eyeShotFunctions2 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions2).Display = new buControlDisplay()
    {
      BackColor = Color.WhiteSmoke
    };
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions2).Caption = new buControlDisplay()
    {
      BackColor = Color.Orange
    };
    ((buFile5) eyeShotFunctions2).ButtonNormal = new buControlDisplay()
    {
      BackColor = Color.Silver
    };
    ((buFile5) eyeShotFunctions2).ButtonOver = new buControlDisplay()
    {
      BackColor = Color.Gray
    };
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions2).ButtonDown = new buControlDisplay()
    {
      BackColor = Color.Silver
    };
    ((clsVisualVars) this).hmiSpin2 = (hmiUISettings) eyeShotFunctions2;
    buEyeShotFunctions eyeShotFunctions3 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions3).Display = new buControlDisplay()
    {
      BackColor = Color.WhiteSmoke
    };
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions3).Caption = new buControlDisplay()
    {
      BackColor = Color.Orange
    };
    ((buFile5) eyeShotFunctions3).ButtonNormal = new buControlDisplay()
    {
      BackColor = Color.Silver
    };
    ((buFile5) eyeShotFunctions3).ButtonOver = new buControlDisplay()
    {
      BackColor = Color.Gray
    };
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions3).ButtonDown = new buControlDisplay()
    {
      BackColor = Color.Silver
    };
    ((clsVisualVars) this).hmiSpin3 = (hmiUISettings) eyeShotFunctions3;
    buEyeShotFunctions eyeShotFunctions4 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions4).Display = new buControlDisplay()
    {
      BackColor = Color.WhiteSmoke
    };
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions4).Caption = new buControlDisplay()
    {
      BackColor = Color.Orange
    };
    ((buFile5) eyeShotFunctions4).ButtonNormal = new buControlDisplay()
    {
      BackColor = Color.Silver
    };
    ((buFile5) eyeShotFunctions4).ButtonOver = new buControlDisplay()
    {
      BackColor = Color.Gray
    };
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions4).ButtonDown = new buControlDisplay()
    {
      BackColor = Color.Silver
    };
    ((clsVisualVars) this).hmiSpin4 = (hmiUISettings) eyeShotFunctions4;
    buEyeShotFunctions eyeShotFunctions5 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions5).Display = new buControlDisplay()
    {
      BackColor = Color.WhiteSmoke
    };
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions5).Caption = new buControlDisplay()
    {
      BackColor = Color.Orange
    };
    ((clsVisualVars) this).hmiText1 = (hmiUISettings) eyeShotFunctions5;
    buEyeShotFunctions eyeShotFunctions6 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions6).Display = new buControlDisplay()
    {
      BackColor = Color.WhiteSmoke
    };
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions6).Caption = new buControlDisplay()
    {
      BackColor = Color.Orange
    };
    ((clsVisualVars) this).hmiText2 = (hmiUISettings) eyeShotFunctions6;
    buEyeShotFunctions eyeShotFunctions7 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions7).Display = new buControlDisplay()
    {
      BackColor = Color.WhiteSmoke
    };
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions7).Caption = new buControlDisplay()
    {
      BackColor = Color.Orange
    };
    ((clsVisualVars) this).hmiText3 = (hmiUISettings) eyeShotFunctions7;
    buEyeShotFunctions eyeShotFunctions8 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions8).Display = new buControlDisplay()
    {
      BackColor = Color.WhiteSmoke
    };
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions8).Caption = new buControlDisplay()
    {
      BackColor = Color.Orange
    };
    ((clsVisualVars) this).hmiText4 = (hmiUISettings) eyeShotFunctions8;
    buEyeShotFunctions eyeShotFunctions9 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions9).Display = new buControlDisplay()
    {
      BackColor = Color.DarkOrange
    };
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions9).Caption = new buControlDisplay()
    {
      BackColor = Color.PaleGreen
    };
    ((buFile5) eyeShotFunctions9).ButtonNormal = new buControlDisplay()
    {
      BackColor = Color.WhiteSmoke
    };
    ((clsVisualVars) this).hmiCheck1 = (hmiUISettings) eyeShotFunctions9;
    buEyeShotFunctions eyeShotFunctions10 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions10).Display = new buControlDisplay()
    {
      BackColor = Color.DarkOrange
    };
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions10).Caption = new buControlDisplay()
    {
      BackColor = Color.PaleGreen
    };
    ((buFile5) eyeShotFunctions10).ButtonNormal = new buControlDisplay()
    {
      BackColor = Color.WhiteSmoke
    };
    ((clsVisualVars) this).hmiCheck2 = (hmiUISettings) eyeShotFunctions10;
    buEyeShotFunctions eyeShotFunctions11 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions11).Display = new buControlDisplay()
    {
      BackColor = Color.DarkOrange
    };
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions11).Caption = new buControlDisplay()
    {
      BackColor = Color.PaleGreen
    };
    ((buFile5) eyeShotFunctions11).ButtonNormal = new buControlDisplay()
    {
      BackColor = Color.WhiteSmoke
    };
    ((clsVisualVars) this).hmiCheck3 = (hmiUISettings) eyeShotFunctions11;
    buEyeShotFunctions eyeShotFunctions12 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions12).Display = new buControlDisplay()
    {
      BackColor = Color.DarkOrange
    };
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions12).Caption = new buControlDisplay()
    {
      BackColor = Color.PaleGreen
    };
    ((buFile5) eyeShotFunctions12).ButtonNormal = new buControlDisplay()
    {
      BackColor = Color.WhiteSmoke
    };
    ((clsVisualVars) this).hmiCheck4 = (hmiUISettings) eyeShotFunctions12;
    buEyeShotFunctions eyeShotFunctions13 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions13).Display = new buControlDisplay()
    {
      BackColor = Color.LightGray
    };
    ((clsVisualVars) this).hmiLabel1 = (hmiUISettings) eyeShotFunctions13;
    buEyeShotFunctions eyeShotFunctions14 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions14).Display = new buControlDisplay()
    {
      BackColor = Color.LightGray
    };
    ((clsVisualVars) this).hmiLabel2 = (hmiUISettings) eyeShotFunctions14;
    buEyeShotFunctions eyeShotFunctions15 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions15).Display = new buControlDisplay()
    {
      BackColor = Color.LightGray
    };
    ((clsVisualVars) this).hmiLabel3 = (hmiUISettings) eyeShotFunctions15;
    buEyeShotFunctions eyeShotFunctions16 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions16).Display = new buControlDisplay()
    {
      BackColor = Color.LightGray
    };
    ((clsVisualVars) this).hmiLabel4 = (hmiUISettings) eyeShotFunctions16;
    buEyeShotFunctions eyeShotFunctions17 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions17).Display = new buControlDisplay()
    {
      BackColor = Color.LightGray,
      SelectionColor = Color.LightBlue
    };
    ((clsVisualVars) this).hmiListbox1 = (hmiUISettings) eyeShotFunctions17;
    buEyeShotFunctions eyeShotFunctions18 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions18).Display = new buControlDisplay()
    {
      BackColor = Color.LightGray,
      SelectionColor = Color.LightBlue
    };
    ((clsVisualVars) this).hmiListbox2 = (hmiUISettings) eyeShotFunctions18;
    buEyeShotFunctions eyeShotFunctions19 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions19).Display = new buControlDisplay()
    {
      BackColor = Color.LightGray,
      SelectionColor = Color.LightBlue
    };
    ((clsVisualVars) this).hmiListbox3 = (hmiUISettings) eyeShotFunctions19;
    buEyeShotFunctions eyeShotFunctions20 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions20).Display = new buControlDisplay()
    {
      BackColor = Color.LightGray,
      SelectionColor = Color.LightBlue
    };
    ((clsVisualVars) this).hmiListbox4 = (hmiUISettings) eyeShotFunctions20;
    ((clsVisualVars) this).hmiDGV1 = (hmiUIDataGridView) new buMatrix5();
    ((clsVisualVars) this).hmiDGV2 = (hmiUIDataGridView) new buMatrix5();
    buEyeShotFunctions eyeShotFunctions21 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions21).Display = new buControlDisplay()
    {
      BackColor = Color.Transparent,
      Fonts = new buControlFont()
      {
        ForeColor = Color.WhiteSmoke
      }
    };
    ((clsVisualVars) this).hmiRadioButton1 = (hmiUISettings) eyeShotFunctions21;
    buEyeShotFunctions eyeShotFunctions22 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions22).Display = new buControlDisplay()
    {
      BackColor = Color.Transparent,
      Fonts = new buControlFont()
      {
        ForeColor = Color.WhiteSmoke
      }
    };
    ((clsVisualVars) this).hmiRadioButton2 = (hmiUISettings) eyeShotFunctions22;
    buEyeShotFunctions eyeShotFunctions23 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions23).Display = new buControlDisplay()
    {
      BackColor = Color.Transparent,
      Fonts = new buControlFont()
      {
        ForeColor = Color.WhiteSmoke
      }
    };
    ((clsVisualVars) this).hmiRadioButton3 = (hmiUISettings) eyeShotFunctions23;
    buEyeShotFunctions eyeShotFunctions24 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions24).Display = new buControlDisplay()
    {
      BackColor = Color.Transparent,
      Fonts = new buControlFont()
      {
        ForeColor = Color.WhiteSmoke
      }
    };
    ((clsVisualVars) this).hmiRadioButton4 = (hmiUISettings) eyeShotFunctions24;
    ((clsVisualVars) this).hmiTrack1 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiTrack2 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiProgress1 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiProgress2 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiGroup1 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiGroup2 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiPanel1 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiPanel2 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiGround1 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiGround2 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiCombo1 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiCombo2 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiCombo3 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiCombo4 = (hmiUISettings) new buEyeShotFunctions();
    buEyeShotFunctions eyeShotFunctions25 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions25).Display = new buControlDisplay()
    {
      BackColor = Color.GreenYellow,
      SelectionColor = Color.LightBlue
    };
    ((clsVisualVars) this).hmiOn1 = (hmiUIBasicSettings) eyeShotFunctions25;
    buEyeShotFunctions eyeShotFunctions26 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions26).Display = new buControlDisplay()
    {
      BackColor = Color.Tomato,
      SelectionColor = Color.LightBlue
    };
    ((clsVisualVars) this).hmiOff1 = (hmiUIBasicSettings) eyeShotFunctions26;
    buEyeShotFunctions eyeShotFunctions27 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions27).Display = new buControlDisplay()
    {
      BackColor = Color.GreenYellow,
      SelectionColor = Color.LightBlue
    };
    ((clsVisualVars) this).hmiOn2 = (hmiUIBasicSettings) eyeShotFunctions27;
    buEyeShotFunctions eyeShotFunctions28 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions28).Display = new buControlDisplay()
    {
      BackColor = Color.Tomato,
      SelectionColor = Color.LightBlue
    };
    ((clsVisualVars) this).hmiOff2 = (hmiUIBasicSettings) eyeShotFunctions28;
    buEyeShotFunctions eyeShotFunctions29 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions29).Display = new buControlDisplay()
    {
      BackColor = Color.Gold,
      SelectionColor = Color.LightBlue
    };
    ((clsVisualVars) this).hmiWarning = (hmiUIBasicSettings) eyeShotFunctions29;
    buEyeShotFunctions eyeShotFunctions30 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions30).Display = new buControlDisplay()
    {
      BackColor = Color.Red,
      SelectionColor = Color.LightBlue
    };
    ((clsVisualVars) this).hmiError = (hmiUIBasicSettings) eyeShotFunctions30;
    buEyeShotFunctions eyeShotFunctions31 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions31).Display = new buControlDisplay()
    {
      BackColor = Color.LightBlue,
      SelectionColor = Color.LightBlue
    };
    ((clsVisualVars) this).hmiInfo = (hmiUIBasicSettings) eyeShotFunctions31;
    buEyeShotFunctions eyeShotFunctions32 = new buEyeShotFunctions();
    ((buFile5.PLYToSchematic.\u0001) eyeShotFunctions32).Display = new buControlDisplay()
    {
      BackColor = Color.LightSteelBlue,
      SelectionColor = Color.LightBlue
    };
    ((clsVisualVars) this).hmiStatus = (hmiUIBasicSettings) eyeShotFunctions32;
    ((clsVisualVars) this).hmiPopup1GroundProps = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiPopup1GroundTopProps = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiPopup1GroundBottomProps = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiPopup1LabelsProps = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiPopup1TextProps = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiPopup1ButtonOk = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiPopup1ButtonCancel = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiCoords1 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiCoords2 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiSpeed1 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiSpeedTrackSpindle1 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiSpeedTrackSpindleDone1 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiSpeedTrackSpindleDrawer1 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiSpeedLabelSpindle1 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiSpeedSpinSpindle1 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiSpeedTrackSpindle2 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiSpeedTrackSpindleDone2 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiSpeedTrackSpindleDrawer2 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiSpeedTrackFeed1 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiSpeedTrackFeedDone1 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiSpeedTrackFeedDrawer1 = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiSpeedFeedLabelProps = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).hmiSpeedSpinsProps = (hmiUISettings) new buEyeShotFunctions();
    ((clsVisualVars) this).colorDataFocus = Color.LightGreen;
    this.colorLinearGradientEnableDisable = new LinearGradientBoolType();
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public PageScene()
  {
    this.Visible = true;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public PageScene(PageScene data)
  {
    this.Visible = true;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
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
    this.ScenePlane = (Plane) data.ScenePlane.Clone();
  }

  public static void DecodeLocal(List<string> SL, string Char, ref PageScene scene)
  {
    scene = new PageScene();
    buSerilization5.Decode(SL, Char, (SerilizationMode5) 1, (object) scene);
    ArrayList arrayList = new ArrayList();
    List<string> CalcList1 = new List<string>();
    buImage5.ListToSpecificList("<Origine>", "</Origine>", false, SL, ref CalcList1);
    Point3D P = new Point3D();
    Vector3D N = Vector3D.AxisZ;
    if (CalcList1.Count >= 1)
    {
      string[] strArray = CalcList1[0].Split(';');
      if (strArray != null && strArray.Length >= 3)
        P = new Point3D(double.Parse(strArray[0]), double.Parse(strArray[1]), double.Parse(strArray[2]));
    }
    List<string> CalcList2 = new List<string>();
    buImage5.ListToSpecificList("<Equation>", "</Equation>", false, SL, ref CalcList2);
    if (CalcList2.Count >= 1)
    {
      string[] strArray = CalcList2[0].Split(';');
      if (strArray != null && strArray.Length >= 3)
        N = new Vector3D(double.Parse(strArray[0]), double.Parse(strArray[1]), double.Parse(strArray[2]));
    }
    scene.ScenePlane = new Plane(P, N);
  }

  public ArrayList ToDef(string Char, int Space)
  {
    ArrayList def = new ArrayList();
    def.AddRange((ICollection) this.ToDefAll(Char, Space, (SerilizationMode5) 1).ToArray());
    string str = "";
    if (def.Count > 1)
    {
      def[0].ToString();
      str = def[def.Count - 1].ToString();
      def.RemoveAt(def.Count - 1);
    }
    def.Add((object) "<Origine>");
    def.Add((object) $"{this.ScenePlane.Origin.X.ToString()};{this.ScenePlane.Origin.Y.ToString()};{this.ScenePlane.Origin.Z.ToString()}");
    def.Add((object) "</Origine>");
    def.Add((object) "<Equation>");
    def.Add((object) $"{this.ScenePlane.Equation.X.ToString()};{this.ScenePlane.Equation.Y.ToString()};{this.ScenePlane.Equation.Z.ToString()}");
    def.Add((object) "</Equation>");
    def.Add((object) str);
    return def;
  }

  ~PageScene() => this.Dispose(false);
}
