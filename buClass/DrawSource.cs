// Decompiled with JetBrains decompiler
// Type: buClass.DrawSource
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public class DrawSource : buSerilization
{
  public ViewportDrawingType Type = ViewportDrawingType.Cad;
  public int Index = 0;
  public int ID = 0;

  public DrawSource()
  {
  }

  public DrawSource(ViewportDrawingType type) => this.Type = type;

  public DrawSource(DrawSource source)
  {
    this.Type = source.Type;
    this.Index = source.Index;
    this.ID = source.ID;
  }

  public DrawSource(ViewportDrawingType type, int index)
  {
    this.Type = type;
    this.Index = index;
  }

  public DrawSource(ViewportDrawingType type, int index, int id)
  {
    this.Type = type;
    this.Index = index;
    this.ID = id;
  }

  public override string ToString()
  {
    return $"{this.Type.ToString()} , Index : {this.Index.ToString()} , ID : {this.ID.ToString()}";
  }
}
