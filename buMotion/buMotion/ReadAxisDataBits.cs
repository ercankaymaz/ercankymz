// Decompiled with JetBrains decompiler
// Type: buMotion.ReadAxisDataBits
// Assembly: buMotion, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: F5000E34-965A-4264-B97F-117192F983D9
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMotion.dll

#nullable disable
namespace buMotion;

public class ReadAxisDataBits
{
  public object Parameter;
  public string Defination;
  public static byte f000073;
  public bool Position;
  public bool OffsetedPosition;
  public bool FollowingError;
  public bool Velocity;
  public bool Current;
  public bool Enabled;
  public bool HomingDone;
  public bool StandStill;
  public bool AxisError;
  public bool CommOk;
  public bool InputHoming;
  public bool InputNegLimit;

  public abstract void m000069();

  public ReadAxisDataBits()
  {
    ((typeMinMaxXYZ) this).InputPosLimit = false;
    ((typeMinMaxXYZ) this).InputCapture = false;
    ((typeMinMaxXYZ) this).DistanceToGo = false;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public ReadAxisDataBits(bool position, bool offsetedPosition)
  {
    ((typeMinMaxXYZ) this).InputPosLimit = false;
    ((typeMinMaxXYZ) this).InputCapture = false;
    ((typeMinMaxXYZ) this).DistanceToGo = false;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    this.Position = position;
    this.OffsetedPosition = offsetedPosition;
  }

  public ReadAxisDataBits(bool position, bool offsetedPosition, bool enabled, bool homingdone)
  {
    ((typeMinMaxXYZ) this).InputPosLimit = false;
    ((typeMinMaxXYZ) this).InputCapture = false;
    ((typeMinMaxXYZ) this).DistanceToGo = false;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    this.Position = position;
    this.OffsetedPosition = offsetedPosition;
    this.Enabled = enabled;
    this.HomingDone = homingdone;
  }

  public ReadAxisDataBits(bool position, bool vel, bool enabled, bool homingdone, bool axiserror)
  {
    ((typeMinMaxXYZ) this).InputPosLimit = false;
    ((typeMinMaxXYZ) this).InputCapture = false;
    ((typeMinMaxXYZ) this).DistanceToGo = false;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    this.Position = position;
    this.Velocity = vel;
    this.Enabled = enabled;
    this.HomingDone = homingdone;
    this.AxisError = axiserror;
  }
}
