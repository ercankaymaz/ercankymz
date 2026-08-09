namespace buClass;

public class CodesysAxesData
{
	public CodesysAxis AxisPar = new CodesysAxis();

	public CodesysAxesData()
	{
	}

	public CodesysAxesData(CodesysAxesData axis)
	{
		AxisPar = new CodesysAxis(axis.AxisPar);
	}

	public CodesysAxesData(CodesysAxis axis)
	{
		AxisPar = new CodesysAxis(axis);
	}
}
