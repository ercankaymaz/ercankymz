// Decompiled with JetBrains decompiler
// Type: buClass.buCadFileOpenOptions
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public class buCadFileOpenOptions : buSerilization
{
  public bool OpenCamList = true;
  public bool OpenProfileList = false;

  public buCadFileOpenOptions()
  {
  }

  public buCadFileOpenOptions(bool cam, bool profile)
  {
    this.OpenCamList = cam;
    this.OpenProfileList = profile;
  }
}
