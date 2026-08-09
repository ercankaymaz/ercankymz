using System;
using buClass;

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
		if (buVector.smethod_0("buJewelCalc"))
		{
			if (this.CalculationInProgress != null)
			{
				this.CalculationInProgress(new CalculationEventArg(0.0, 0.0, 0, "", ""));
			}
			if (this.CalculationStarted != null)
			{
				this.CalculationStarted(new CalculationEventArg(0.0, 0.0, 0, "", ""));
			}
			if (this.CalculationEnded != null)
			{
				this.CalculationEnded(new CalculationEventArg(0.0, 0.0, 0, "", ""));
			}
			if (this.CalculationCanceled != null)
			{
				this.CalculationCanceled(new CalculationEventArg(0.0, 0.0, 0, "", ""));
			}
			if (this.CalculationError != null)
			{
				this.CalculationError(new CalculationErrorEventArg("", "", "", 0));
			}
			return;
		}
		throw new RegisterException("buJewelCalc");
	}

	~buJewelCalc()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposed)
		{
			if (!disposing)
			{
			}
			disposed = true;
		}
	}
}
