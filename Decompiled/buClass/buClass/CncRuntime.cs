namespace buClass;

public class CncRuntime : buSerilization
{
	public bool SingleStep = false;

	public bool UpdateToolData = false;

	public double FeedVelocity = 0.0;

	public double SpindleSpeed = 0.0;

	public int ActiveLine = 0;

	public int ActiveMCode = 0;

	public int ActiveTool = 0;

	public override string ToString()
	{
		return "FeedVelocity: " + FeedVelocity + " ; SpindleSpeed: " + SpindleSpeed + " ; ActiveLine: " + ActiveLine + " ; ActiveTool: " + ActiveTool + " ; ActiveMCode: " + ActiveMCode;
	}
}
