using buClass;

namespace buMW;

public class MWIterationOption
{
	public bool getContour = false;

	public Pnt6D StartPoint = new Pnt6D();

	public Pnt6D EndPoint = new Pnt6D();

	public MWIterationOption()
	{
	}

	public MWIterationOption(MWIterationOption data)
	{
		getContour = data.getContour;
		StartPoint = new Pnt6D(data.StartPoint);
		EndPoint = new Pnt6D(data.EndPoint);
	}
}
