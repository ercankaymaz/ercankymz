namespace buClass;

public class CalculationEventArg
{
	public int Sequence = 0;

	public double ActiveProgressPercentage = 0.0;

	public double OverallProgressPercentage = 0.0;

	public string Job = "";

	public string SubJob = "";

	public bool Canceled = false;

	public bool Done = false;

	public bool ShowForm = true;

	public bool ShowOnMainForm = false;

	public CalculationEventArg()
	{
	}

	public CalculationEventArg(double activePersentage, double overallPercentage, int seq, string job, string subjob)
	{
		ActiveProgressPercentage = activePersentage;
		OverallProgressPercentage = overallPercentage;
		Sequence = seq;
		Job = job;
		SubJob = subjob;
		Done = false;
	}

	public CalculationEventArg(double activePersentage, double overallPercentage, int seq, string job, string subjob, bool done)
	{
		ActiveProgressPercentage = activePersentage;
		OverallProgressPercentage = overallPercentage;
		Sequence = seq;
		Job = job;
		SubJob = subjob;
		Done = done;
	}
}
