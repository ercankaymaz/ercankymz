// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.MarbleItemExtend
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleItemExtend : buSerilization5
{
  public bool JobOpenClearAllProfiles;
  public bool UseAlwaysPocketForCam;
  public bool UseAlwaysInsideContourForCam;
  public bool ShowSupportBlockInfoAtGCode;
  public bool ShowOperationInfoAtGCode;
  public bool ShowProfileInfoAtGCode;
  public bool ChangeG2G3DirForRightRefProfile;
  public bool ChangeG2G3DirForLeftRefProfile;

  public abstract void m001E86();

  public MarbleItemExtend()
  {
    // ISSUE: unable to decompile the method.
  }

  public MarbleItemExtend(ProfileClamperSettings data)
  {
    // ISSUE: unable to decompile the method.
  }

  public MarbleItemExtend()
  {
    ((buMarbleCalc) this).ProfileLength = 500.0;
    // ISSUE: reference to a compiler-generated field
    ((buMarbleCalc.\u003C\u003Ec) this).ClamperCount = 2;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public MarbleItemExtend(double profilelen, int clampcount)
  {
    ((buMarbleCalc) this).ProfileLength = 500.0;
    // ISSUE: reference to a compiler-generated field
    ((buMarbleCalc.\u003C\u003Ec) this).ClamperCount = 2;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((buMarbleCalc) this).ProfileLength = profilelen;
    // ISSUE: reference to a compiler-generated field
    ((buMarbleCalc.\u003C\u003Ec) this).ClamperCount = clampcount;
  }

  public MarbleItemExtend(ProfileLengthClamperCount data)
  {
    ((buMarbleCalc) this).ProfileLength = 500.0;
    // ISSUE: reference to a compiler-generated field
    ((buMarbleCalc.\u003C\u003Ec) this).ClamperCount = 2;
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

  public override string ToString()
  {
    // ISSUE: reference to a compiler-generated field
    return $"ProfileLength: {((buMarbleCalc) this).ProfileLength.ToString("f2")} , ClamperCount: {((buMarbleCalc.\u003C\u003Ec) this).ClamperCount.ToString()}";
  }

  public static void Copy(
    List<ProfileLengthClamperCount> RefClamper,
    ref List<ProfileLengthClamperCount> CopiedClamper)
  {
    CopiedClamper.Clear();
    CopiedClamper = new List<ProfileLengthClamperCount>();
    for (int index = 0; index <= RefClamper.Count - 1; ++index)
    {
      ProfileLengthClamperCount CopiedClamper1 = (ProfileLengthClamperCount) new MarbleItemExtend();
      MarbleItemOperations.Copy(RefClamper[index], ref CopiedClamper1);
      CopiedClamper.Add(CopiedClamper1);
    }
  }
}
