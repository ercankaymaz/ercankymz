using System;

namespace ACadSharp.Exceptions;

[Serializable]
public class DxfException : Exception
{
	public DxfException(int code, long line)
		: base($"Invalid dxf code with value {code}, at line {line}.")
	{
	}

	public DxfException(string message, long line)
		: base($"{message}, at line {line}.")
	{
	}

	public DxfException(string message)
		: base(message)
	{
	}
}
