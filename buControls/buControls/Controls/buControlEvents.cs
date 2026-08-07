// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buControlEvents
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

public class buControlEvents
{
  public delegate void buCheckedChangedEventHandler(object sender, bool CheckStatus);

  public delegate void buClickAfterEventHandler(object sender, bool CheckStatus);

  public delegate void buValueChangedEvent(object sender, double Val);

  public delegate void buValueClickedEvent(object sender, EventArgs e);

  public delegate void buTextChangedEvent(object sender, string ChangedText);

  public delegate void buButtonPlusMinusClickEventHandler(object sender, int Sing);

  public delegate void buButtonPlusMinusMouseEventHandler(
    object sender,
    MouseEventArgs e,
    int Sing);

  public delegate void buLayerVisibleChangedEventHandler(object sender, bool Visible, int Index);

  public delegate void buLayerLockChangedEventHandler(object sender, bool Visible, int Index);

  public delegate void buLayerColorChangedEventHandler(object sender, Color color, int Index);

  public delegate void buLayerChangedEventHandler(
    object sender,
    Color color,
    bool Visible,
    bool Lock,
    string Name,
    int Index);

  public delegate void buLayerDoubleClickEventHandler(
    object sender,
    Color color,
    bool Visible,
    bool Lock,
    string Name,
    int Index);

  public delegate void buColorChangedEventHandler(
    object sender,
    Color color,
    double Thickness,
    int Transparency);

  public delegate void buListValueChangedEventHandler(object sender, buListValueChangedEventArg e);

  public delegate void buListEnableTwoValueChangedEventHandler(
    object sender,
    List<ValuesItem> Items,
    int IndexItem,
    ValuesItem Value);
}
