// Decompiled with JetBrains decompiler
// Type: buClass.buCadFileSaveOptions
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public class buCadFileSaveOptions : buSerilization
{
  public bool SaveCamList = true;
  public bool SaveProfileList = false;

  public buCadFileSaveOptions()
  {
  }

  public buCadFileSaveOptions(bool cam, bool profile)
  {
    this.SaveCamList = cam;
    this.SaveProfileList = profile;
  }
}
