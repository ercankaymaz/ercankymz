using buClass;

namespace buEyeBaseVer5.Apps;

public class buNestedResultSentEventArg
{
	public nestResultSendType SendToDraw = nestResultSendType.Job;

	public int IndexResult = -1;

	public int IndexSheet = -1;

	public int IndexPart = -1;

	public buNestedResult NestResult = null;

	public override string ToString()
	{
		return "IndexResult : " + IndexResult;
	}
}
