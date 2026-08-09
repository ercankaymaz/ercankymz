using System;
using System.Text;

namespace Xbim.Common.Exceptions;

public static class ExceptionExtensions
{
	public static string ErrorStack(this Exception e, string baseError)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(baseError);
		string text = "\t";
		Exception ex = e;
		while (ex != null)
		{
			stringBuilder.AppendLine(text + ex.Message);
			ex = ex.InnerException;
			text += "\t";
		}
		return stringBuilder.ToString();
	}
}
