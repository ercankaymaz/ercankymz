// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buDoor
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buClipperLib;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class buDoor
{
  public string infoString;
  public string infoData;
  public double infoLength;
  public double infoAngle;
  public double infoHeight;
  public double infoRadius;
  public double infoWidth;

  public virtual bool \u0001([In] object obj0)
  {
    bool flag;
    if ((obj0 == null ? 1 : (!(obj0 is \u000E.\u0001) ? 1 : 0)) != 0)
    {
      flag = false;
    }
    else
    {
      \u000E.\u0001 obj = (\u000E.\u0001) obj0;
      flag = obj.\u0001 == ((DoorRuntimeSettings) this).\u0001 && (long) obj.\u0001 == (long) ((DoorRuntimeSettings) this).\u0001;
    }
    return flag;
  }

  public virtual int \u0001()
  {
    return ((DoorRuntimeSettings) this).\u0001.GetHashCode() ^ ((DoorRuntimeSettings) this).\u0001.GetHashCode();
  }

  [SpecialName]
  public static \u000E.\u0001 \u0001([In] \u000E.\u0001 obj0)
  {
    return obj0.\u0001 != 0UL ? (\u000E.\u0001) new CamCreateSettings(~obj0.\u0001, (ulong) (~(long) obj0.\u0001 + 1L)) : (\u000E.\u0001) new CamCreateSettings(-obj0.\u0001, 0UL);
  }

  public static \u000E.\u0001 \u0001([In] long obj0, [In] long obj1)
  {
    bool flag = obj0 < 0L != obj1 < 0L;
    if (obj0 < 0L)
      obj0 = -obj0;
    if (obj1 < 0L)
      obj1 = -obj1;
    ulong num1 = (ulong) (obj0 >>> 32 /*0x20*/);
    ulong num2 = (ulong) (obj0 & (long) uint.MaxValue);
    ulong num3 = (ulong) (obj1 >>> 32 /*0x20*/);
    ulong num4 = (ulong) (obj1 & (long) uint.MaxValue);
    ulong num5 = num1 * num3;
    ulong num6 = num2 * num4;
    ulong num7 = (ulong) ((long) num1 * (long) num4 + (long) num2 * (long) num3);
    long num8 = (long) num5 + (long) (num7 >> 32 /*0x20*/);
    ulong num9 = (num7 << 32 /*0x20*/) + num6;
    if (num9 < num6)
      ++num8;
    \u000E.\u0001 obj;
    // ISSUE: explicit constructor call
    ((CamCreateSettings) ref obj).\u002Ector(num8, num9);
    return flag ? buDoor.\u0001(obj) : obj;
  }

  public buDoor(long x, long y, long z = 0)
  {
    ((DoorRuntimeSettings) this).X = x;
    ((DoorRuntimeSettings) this).Y = y;
    ((DoorRuntimeSettings) this).Z = z;
  }

  public buDoor(double x, double y, double z = 0.0)
  {
    ((DoorRuntimeSettings) this).X = (long) x;
    ((DoorRuntimeSettings) this).Y = (long) y;
    ((DoorRuntimeSettings) this).Z = (long) z;
  }

  public buDoor(DoublePoint dp)
  {
    ((DoorRuntimeSettings) this).X = (long) dp.X;
    ((DoorRuntimeSettings) this).Y = (long) dp.Y;
    ((DoorRuntimeSettings) this).Z = 0L;
  }
}
