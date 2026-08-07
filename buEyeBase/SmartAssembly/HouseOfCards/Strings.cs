// Decompiled with JetBrains decompiler
// Type: SmartAssembly.HouseOfCards.Strings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.ClassViewer;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace SmartAssembly.HouseOfCards;

public static class Strings
{
  static void \u0001([In] string obj0, [In] ref setCheckBoxControl obj1, [In] bool obj2, [In] buClassViewer5 obj3)
  {
    obj1.Font = ((buMachinePart) obj3).FontValues;
    obj1.Checked = obj2;
    obj1.Height = ((buMachinePart) obj3).RowHeight;
    obj1.Width = ((buMachinePart) obj3).ValueWidth;
    obj1.CheckedChanged += new EventHandler(((buLinearPath) obj3).\u0002);
    obj1.Tag = (object) obj0;
  }
}
