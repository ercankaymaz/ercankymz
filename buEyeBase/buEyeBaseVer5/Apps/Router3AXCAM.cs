// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Router3AXCAM
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Serialization;
using System;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class Router3AXCAM : buSerilization5
{
  public static byte f0039C3;
  public static byte f0039CD;

  public Router3AXCAM(contentType contentType)
    : this(contentType)
  {
  }

  protected virtual void FillModel() => __nonvirtual (((FileSerializer) this).FillModel());

  protected virtual Type GetTypeForObject(string typeName)
  {
    Type type = Type.GetType(typeName, false, true);
    // ISSUE: explicit non-virtual call
    return !(type != (Type) null) ? __nonvirtual (((FileSerializer) this).GetTypeForObject(typeName)) : type;
  }

  static Router3AXCAM()
  {
    DoorRuntimeSettings.CustomTag = "1.2";
    DoorRuntimeSettings.Version = 0;
  }

  public Router3AXCAM(double x = 0.0, double y = 0.0)
  {
    ((DoorRuntimeSettings) this).X = x;
    ((DoorRuntimeSettings) this).Y = y;
  }
}
