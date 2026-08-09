namespace buClass;

public class FtpFileSendEventArg
{
	public int TotalLineCount = 0;

	public int ActualLineIndex = 0;

	public double SendPersentage = 0.0;

	public override string ToString()
	{
		return "TotalLineCount: " + TotalLineCount;
	}
}
