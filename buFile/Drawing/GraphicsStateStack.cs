// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.GraphicsStateStack
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace PdfSharp.Drawing;

internal class GraphicsStateStack
{
  private readonly InternalGraphicsState _current;
  private readonly Stack<InternalGraphicsState> _stack = new Stack<InternalGraphicsState>();

  public GraphicsStateStack(XGraphics gfx) => this._current = new InternalGraphicsState(gfx);

  public int Count => this._stack.Count;

  public void Push(InternalGraphicsState state)
  {
    this._stack.Push(state);
    state.Pushed();
  }

  public int Restore(InternalGraphicsState state)
  {
    if (!this._stack.Contains(state))
      throw new ArgumentException("State not on stack.", nameof (state));
    if (state.Invalid)
      throw new ArgumentException("State already restored.", nameof (state));
    int num = 1;
    InternalGraphicsState internalGraphicsState = this._stack.Pop();
    internalGraphicsState.Popped();
    while (internalGraphicsState != state)
    {
      ++num;
      state.Invalid = true;
      internalGraphicsState = this._stack.Pop();
      internalGraphicsState.Popped();
    }
    state.Invalid = true;
    return num;
  }

  public InternalGraphicsState Current
  {
    get => this._stack.Count != 0 ? this._stack.Peek() : this._current;
  }
}
