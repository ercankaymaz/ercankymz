// Decompiled with JetBrains decompiler
// Type: buClass.LayerCam
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buClass;

[Serializable]
public class LayerCam : buSerilization
{
  public double OperationHeight = 0.0;
  public ToolBase CamTool = new ToolBase();
  public List<camBase> Cams = new List<camBase>();
  public static List<string> Captions = new List<string>();

  public LayerCam()
  {
  }

  public LayerCam(LayerCam cam)
  {
    this.OperationHeight = cam.OperationHeight;
    this.CamTool = new ToolBase(cam.CamTool);
    this.Cams.Clear();
    for (int index = 0; index <= cam.Cams.Count - 1; ++index)
    {
      camBase copiedCam = new camBase();
      camBase.CopyCam(cam.Cams[index], ref copiedCam);
      this.Cams.Add(copiedCam);
    }
  }

  public override string ToString()
  {
    return $"Height : {this.OperationHeight.ToString()} -  Tool : {this.CamTool.Data.No.ToString()}";
  }
}
