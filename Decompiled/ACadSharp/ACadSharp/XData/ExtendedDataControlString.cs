namespace ACadSharp.XData;

public class ExtendedDataControlString : ExtendedDataRecord
{
	public static ExtendedDataControlString Open => new ExtendedDataControlString(isClosing: false);

	public static ExtendedDataControlString Close => new ExtendedDataControlString(isClosing: true);

	public bool IsClosing { get; set; }

	public char Value
	{
		get
		{
			if (!IsClosing)
			{
				return '{';
			}
			return '}';
		}
	}

	public ExtendedDataControlString(bool isClosing)
		: base(DxfCode.ExtendedDataControlString, isClosing ? '}' : '{')
	{
		IsClosing = isClosing;
	}
}
