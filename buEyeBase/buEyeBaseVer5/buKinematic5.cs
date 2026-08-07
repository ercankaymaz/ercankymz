// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buKinematic5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using System;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5;

public class buKinematic5
{
  public buKinematic5()
  {
    ((buFile5.PLYToSchematic.\u0001) this).ImageAlignment = ContentAlignment.MiddleLeft;
    ((buFile5.PLYToSchematic.\u0001) this).GeometryType = ShapeType.Arc;
    ((buFile5.PLYToSchematic.\u0001) this).GeometryArcDiameer = 10;
    ((buFile5.PLYToSchematic.\u0001) this).SpinButtonShow = true;
    ((buFile5.PLYToSchematic.\u0001) this).CheckBoxSize = 20;
    ((buFile5.PLYToSchematic.\u0001) this).CheckBoxVisible = true;
    ((buFile5.PLYToSchematic.\u0001) this).CheckBoxCheckIsRectangle = true;
    ((buFile5.PLYToSchematic.\u0001) this).CheckColorMode = false;
    ((buFile5.PLYToSchematic.\u0001) this).ObjectWidth = 20;
    ((buFile5.PLYToSchematic.\u0001) this).DrawerRectangle = true;
    ((buFile5.PLYToSchematic.\u0002) this).ShowPersentage = true;
    ((buFile5.PLYToSchematic.\u0002) this).TopHeight = 20;
    ((buFile5.PLYToSchematic.\u0002) this).BottomHeight = 0;
    ((buFile5.PLYToSchematic.\u0002) this).LineColor = Color.Black;
    ((buFile5.PLYToSchematic.\u0003) this).ArrowColor = Color.Silver;
    ((buFile5.PLYToSchematic.\u0003) this).DropColor = Color.LightGray;
    ((buFile5.PLYToSchematic.\u0003) this).ValueColor = Color.WhiteSmoke;
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
  }

  public buKinematic5(hmiUIPars data)
  {
    ((buFile5.PLYToSchematic.\u0001) this).ImageAlignment = ContentAlignment.MiddleLeft;
    ((buFile5.PLYToSchematic.\u0001) this).GeometryType = ShapeType.Arc;
    ((buFile5.PLYToSchematic.\u0001) this).GeometryArcDiameer = 10;
    ((buFile5.PLYToSchematic.\u0001) this).SpinButtonShow = true;
    ((buFile5.PLYToSchematic.\u0001) this).CheckBoxSize = 20;
    ((buFile5.PLYToSchematic.\u0001) this).CheckBoxVisible = true;
    ((buFile5.PLYToSchematic.\u0001) this).CheckBoxCheckIsRectangle = true;
    ((buFile5.PLYToSchematic.\u0001) this).CheckColorMode = false;
    ((buFile5.PLYToSchematic.\u0001) this).ObjectWidth = 20;
    ((buFile5.PLYToSchematic.\u0001) this).DrawerRectangle = true;
    ((buFile5.PLYToSchematic.\u0002) this).ShowPersentage = true;
    ((buFile5.PLYToSchematic.\u0002) this).TopHeight = 20;
    ((buFile5.PLYToSchematic.\u0002) this).BottomHeight = 0;
    ((buFile5.PLYToSchematic.\u0002) this).LineColor = Color.Black;
    ((buFile5.PLYToSchematic.\u0003) this).ArrowColor = Color.Silver;
    ((buFile5.PLYToSchematic.\u0003) this).DropColor = Color.LightGray;
    ((buFile5.PLYToSchematic.\u0003) this).ValueColor = Color.WhiteSmoke;
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
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

  public buKinematic5()
  {
    ((buFile5.Cf2) this).ImageAlignment = ContentAlignment.MiddleLeft;
    ((buFile5.Cf2) this).GeometryType = ShapeType.Arc;
    ((buFile5.Cf2) this).GeometryArcDiameer = 10;
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
  }

  public buKinematic5(hmiUIBasicPars data)
  {
    ((buFile5.Cf2) this).ImageAlignment = ContentAlignment.MiddleLeft;
    ((buFile5.Cf2) this).GeometryType = ShapeType.Arc;
    ((buFile5.Cf2) this).GeometryArcDiameer = 10;
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
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

  public override string ToString()
  {
    return $"{((buFile5.Cf2) this).GeometryType.ToString()} - {((buFile5.Cf2) this).GeometryArcDiameer.ToString()}";
  }

  public abstract void m0003A2();

  public buKinematic5()
  {
    ((buFile5.Cf2) this).VisibleStatus = true;
    ((buFile5.Cf2) this).ControlLeft = -100;
    ((buFile5.Cf2) this).ControlTop = -100;
    ((buFile5.Cf2) this).ControlWidth = 0;
    ((buFile5.Cf2) this).ControlHeight = 0;
    ((buFile5.Cf2) this).ImageIndex = -1;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buKinematic5(hmiUIOptions data)
  {
    ((buFile5.Cf2) this).VisibleStatus = true;
    ((buFile5.Cf2) this).ControlLeft = -100;
    ((buFile5.Cf2) this).ControlTop = -100;
    ((buFile5.Cf2) this).ControlWidth = 0;
    ((buFile5.Cf2) this).ControlHeight = 0;
    ((buFile5.Cf2) this).ImageIndex = -1;
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

  public static buControl hmiToControl(hmiUIOptions data, buControl Ctrl)
  {
    try
    {
      Ctrl.Visible = ((buFile5.Cf2) data).VisibleStatus;
      if (((buFile5.Cf2) data).ControlTop >= 0)
        Ctrl.Top = ((buFile5.Cf2) data).ControlTop;
      if (((buFile5.Cf2) data).ControlLeft >= 0)
        Ctrl.Left = ((buFile5.Cf2) data).ControlLeft;
      if (((buFile5.Cf2) data).ControlWidth > 0)
        Ctrl.Width = ((buFile5.Cf2) data).ControlWidth;
      if (((buFile5.Cf2) data).ControlHeight > 0)
        Ctrl.Height = ((buFile5.Cf2) data).ControlHeight;
      if (((buFile5.Cf2) data).ImageIndex >= 0)
        Ctrl.ImageIndex = ((buFile5.Cf2) data).ImageIndex;
      return Ctrl;
    }
    catch (Exception ex)
    {
      return Ctrl;
    }
  }

  public static void controlToHmi(ref hmiUIOptions data, buControl Ctrl)
  {
    try
    {
      if (data == null)
        data = (hmiUIOptions) new buKinematic5();
      ((buFile5.Cf2) data).VisibleStatus = Ctrl.Visible;
      ((buFile5.Cf2) data).ControlTop = Ctrl.Top;
      ((buFile5.Cf2) data).ControlLeft = Ctrl.Left;
      ((buFile5.Cf2) data).ControlWidth = Ctrl.Width;
      ((buFile5.Cf2) data).ControlHeight = Ctrl.Height;
      ((buFile5.Cf2) data).ImageIndex = Ctrl.ImageIndex;
    }
    catch (Exception ex)
    {
    }
  }

  public static void CreateSerilizationOptionFromControl(
    Control.ControlCollection Controls,
    int Space,
    ref ArrayList AL)
  {
    string str = new string(' ', Space);
    for (int index = 0; index <= Controls.Count - 1; ++index)
    {
      if (Controls[index] is buButton)
      {
        hmiUIOptions data = (hmiUIOptions) new buKinematic5();
        buKinematic5.controlToHmi(ref data, (buControl) Controls[index]);
        AL.Add((object) $"{str}{Controls[index].Name} = {buSerilization5.ClassToString((object) data)}");
      }
      if (Controls[index] is buSpin)
      {
        hmiUIOptions data = (hmiUIOptions) new buKinematic5();
        buKinematic5.controlToHmi(ref data, (buControl) Controls[index]);
        AL.Add((object) $"{str}{Controls[index].Name} = {buSerilization5.ClassToString((object) data)}");
      }
      if (Controls[index] is buTextBox)
      {
        hmiUIOptions data = (hmiUIOptions) new buKinematic5();
        buKinematic5.controlToHmi(ref data, (buControl) Controls[index]);
        AL.Add((object) $"{str}{Controls[index].Name} = {buSerilization5.ClassToString((object) data)}");
      }
      if (Controls[index] is buLabel)
      {
        hmiUIOptions data = (hmiUIOptions) new buKinematic5();
        buKinematic5.controlToHmi(ref data, (buControl) Controls[index]);
        AL.Add((object) $"{str}{Controls[index].Name} = {buSerilization5.ClassToString((object) data)}");
      }
      if (Controls[index] is buCheckBox)
      {
        hmiUIOptions data = (hmiUIOptions) new buKinematic5();
        buKinematic5.controlToHmi(ref data, (buControl) Controls[index]);
        AL.Add((object) $"{str}{Controls[index].Name} = {buSerilization5.ClassToString((object) data)}");
      }
    }
  }
}
