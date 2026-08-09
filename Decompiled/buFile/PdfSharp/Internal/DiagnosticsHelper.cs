using System;

namespace PdfSharp.Internal;

internal static class DiagnosticsHelper
{
	public static void HandleNotImplemented(string message)
	{
		string text = "Not implemented: " + message;
		switch (Diagnostics.NotImplementedBehaviour)
		{
		case NotImplementedBehaviour.DoNothing:
			break;
		case NotImplementedBehaviour.Log:
			Logger.Log(text);
			break;
		case NotImplementedBehaviour.Throw:
			ThrowNotImplementedException(text);
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	public static void ThrowNotImplementedException(string message)
	{
		throw new NotImplementedException(message);
	}
}
