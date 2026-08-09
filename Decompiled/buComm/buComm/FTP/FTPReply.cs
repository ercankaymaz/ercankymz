namespace buComm.FTP;

public class FTPReply
{
	private string _0001;

	private string _0002;

	public string ReplyCode => _0001;

	public string ReplyText => _0002;

	internal FTPReply(string P_0, string P_1)
	{
		_0001 = P_0;
		_0002 = P_1;
	}
}
