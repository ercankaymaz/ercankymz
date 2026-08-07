// Decompiled with JetBrains decompiler
// Type: buMarble.clsAppMarbleIODef
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buEyeBaseVer5;
using System;

#nullable disable
namespace buMarble;

[Serializable]
public class clsAppMarbleIODef : buSerilization5
{
  public bool OptionWarmMotors;
  public bool Value;
  public int SourceIndex;
  public string Address;
  public string Caption;

  public clsAppMarbleIODef(clsAppMarbleOPVar data)
  {
    // ISSUE: unable to decompile the method.
  }

  public clsAppMarbleIODef()
  {
    ((clsAppMarbleIOVar) this).Invert = false;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public clsAppMarbleIODef(string address)
  {
    ((clsAppMarbleIOVar) this).Invert = false;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    this.Address = address;
    this.Caption = address;
  }
}
