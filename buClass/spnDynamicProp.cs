// Decompiled with JetBrains decompiler
// Type: buClass.spnDynamicProp
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Drawing;

#nullable disable
namespace buClass;

[Serializable]
public class spnDynamicProp : buSerilization
{
  public Pnt3D pntMin = new Pnt3D();
  public Pnt3D pntMid = new Pnt3D();
  public Pnt3D pntMax = new Pnt3D();
  public string Caption = "";
  public ContentAlignment Alignment = ContentAlignment.MiddleCenter;
  public bool Focus = true;
  public bool SelectAll = true;
  public bool Visible = false;
  public bool PreVisible = false;
}
