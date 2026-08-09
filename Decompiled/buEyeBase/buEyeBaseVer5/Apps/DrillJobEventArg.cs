namespace buEyeBaseVer5.Apps;

public class DrillJobEventArg
{
	public DrillJob Job = null;

	public DrillJobEventArg()
	{
	}

	public DrillJobEventArg(DrillJob data)
	{
		Job = new DrillJob(data);
	}

	public override string ToString()
	{
		return Job.baseItems.Count.ToString();
	}
}
