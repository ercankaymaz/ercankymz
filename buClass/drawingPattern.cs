// Decompiled with JetBrains decompiler
// Type: buClass.drawingPattern
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public class drawingPattern : buSerilization
{
  public float[] Type = new float[2]{ 5f, -1f / 1000f };
  public string Name = "Solid";

  public drawingPattern()
  {
  }

  public drawingPattern(drawingPattern pattern)
  {
    this.Name = pattern.Name;
    this.Type = new float[pattern.Type.Length];
    for (int index = 0; index <= pattern.Type.Length - 1; ++index)
      this.Type[index] = pattern.Type[index];
  }

  public override string ToString() => this.Name;
}
