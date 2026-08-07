// Decompiled with JetBrains decompiler
// Type: buApplication3D.UserInterfaces.buUserControls
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Eyeshot.Control;
using System.Windows.Forms;

#nullable disable
namespace buApplication3D.UserInterfaces;

public class buUserControls
{
  public static Timer timSim;
  public static Timer timCollision;
  public static Timer timGeneral;
  public static Timer timWarning;
  public static Design desingSketch;

  static buUserControls()
  {
    buUserSimSetVariables.SimLinearStep = 5.0;
    buUserSimSetVariables.SimRotaryDegree = 2.0;
    buUserSimSetVariables.GCodeLineOffset = 0;
    buUserSimSetVariables.CollisionControl = true;
  }
}
