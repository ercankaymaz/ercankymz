// Decompiled with JetBrains decompiler
// Type: buCore.AppCalc.buJewelCalc
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using buClass;
using System;

#nullable disable
namespace buCore.AppCalc;

[Serializable]
public class buJewelCalc : IDisposable
{
  private bool disposed = false;

  public event CalculationEventHandler CalculationInProgress;

  public event CalculationEventHandler CalculationStarted;

  public event CalculationEventHandler CalculationEnded;

  public event CalculationEventHandler CalculationCanceled;

  public event CalculationErrorEventHandler CalculationError;

  public buJewelCalc()
  {
    if (!buVector.smethod_0(nameof (buJewelCalc)))
      throw new RegisterException(nameof (buJewelCalc));
    if (this.CalculationInProgress != null)
      this.CalculationInProgress(new CalculationEventArg(0.0, 0.0, 0, "", ""));
    if (this.CalculationStarted != null)
      this.CalculationStarted(new CalculationEventArg(0.0, 0.0, 0, "", ""));
    if (this.CalculationEnded != null)
      this.CalculationEnded(new CalculationEventArg(0.0, 0.0, 0, "", ""));
    if (this.CalculationCanceled != null)
      this.CalculationCanceled(new CalculationEventArg(0.0, 0.0, 0, "", ""));
    if (this.CalculationError == null)
      return;
    this.CalculationError(new CalculationErrorEventArg("", "", "", 0));
  }

  ~buJewelCalc() => this.Dispose(false);

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (this.disposed)
      return;
    if (!disposing)
      ;
    this.disposed = true;
  }
}
