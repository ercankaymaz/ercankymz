namespace buMW;

public class MWCalculationResultEventArg
{
	public bool CalculationSuccess = false;

	public MWCalculationResultEventArg()
	{
	}

	public MWCalculationResultEventArg(bool success)
	{
		CalculationSuccess = success;
	}
}
