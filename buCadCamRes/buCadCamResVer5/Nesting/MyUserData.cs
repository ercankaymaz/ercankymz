// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Nesting.MyUserData
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using PowerNest2Cs;

#nullable disable
namespace buCadCamResVer5.Nesting;

public class MyUserData : IUserData
{
  public MyUserData() => this.NbCall = 0;

  public int NbCall { get; set; }
}
