// Decompiled with JetBrains decompiler
// Type: buMotion.DefaultParameter
// Assembly: buMotion, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: F5000E34-965A-4264-B97F-117192F983D9
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMotion.dll

#nullable disable
namespace buMotion;

public class DefaultParameter
{
  private string \u0002;
  public static byte f000070;

  public DefaultParameter()
  {
    ((ReadAxisDataBits) this).Parameter = (object) null;
    ((ReadAxisDataBits) this).Defination = "";
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public DefaultParameter(object Par, string defination)
  {
    ((ReadAxisDataBits) this).Parameter = (object) null;
    ((ReadAxisDataBits) this).Defination = "";
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((ReadAxisDataBits) this).Parameter = Par;
    ((ReadAxisDataBits) this).Defination = defination;
  }
}
