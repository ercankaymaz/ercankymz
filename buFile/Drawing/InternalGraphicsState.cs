// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.InternalGraphicsState
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Drawing;

internal class InternalGraphicsState
{
  private XMatrix _transform;
  public bool Invalid;
  private readonly XGraphics _gfx;
  internal XGraphicsState State;

  public InternalGraphicsState(XGraphics gfx) => this._gfx = gfx;

  public InternalGraphicsState(XGraphics gfx, XGraphicsState state)
  {
    this._gfx = gfx;
    this.State = state;
    this.State.InternalState = this;
  }

  public InternalGraphicsState(XGraphics gfx, XGraphicsContainer container)
  {
    this._gfx = gfx;
    container.InternalState = this;
  }

  public XMatrix Transform
  {
    get => this._transform;
    set => this._transform = value;
  }

  public void Pushed()
  {
  }

  public void Popped() => this.Invalid = true;
}
