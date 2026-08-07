// Decompiled with JetBrains decompiler
// Type: buCore.buAppCalc
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using buClass;

#nullable disable
namespace buCore;

public class buAppCalc
{
  public static buVector cVector;
  public static buCamCalc cCam;
  public static buKinematic cKinematic;
  public static buSort cSort;

  public buAppCalc()
  {
    if (!buVector.smethod_0(nameof (buAppCalc)))
      throw new RegisterException(nameof (buAppCalc));
    buAppCalc.cVector = new buVector();
    buAppCalc.cCam = new buCamCalc();
    buAppCalc.cKinematic = new buKinematic();
    buAppCalc.cSort = new buSort();
    // ISSUE: reference to a compiler-generated field
    if (this.calculationEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.calculationEventHandler_0(new CalculationEventArg(0.0, 0.0, 0, "", ""));
    }
    // ISSUE: reference to a compiler-generated field
    if (this.calculationEventHandler_1 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.calculationEventHandler_1(new CalculationEventArg(0.0, 0.0, 0, "", ""));
    }
    // ISSUE: reference to a compiler-generated field
    if (this.calculationEventHandler_2 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.calculationEventHandler_2(new CalculationEventArg(0.0, 0.0, 0, "", ""));
    }
    // ISSUE: reference to a compiler-generated field
    if (this.calculationEventHandler_3 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "", ""));
    }
    // ISSUE: reference to a compiler-generated field
    if (this.calculationErrorEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.calculationErrorEventHandler_0(new CalculationErrorEventArg("", "", "", 0));
  }

  public event CalculationEventHandler CalculationInProgress;

  public event CalculationEventHandler CalculationStarted;

  public event CalculationEventHandler CalculationEnded;

  public event CalculationEventHandler CalculationCanceled;

  public event CalculationErrorEventHandler CalculationError;
}
