using System;

namespace UglyToad.PdfPig.Logging;

public interface ILog
{
	void Debug(string message);

	void Debug(string message, Exception ex);

	void Warn(string message);

	void Error(string message);

	void Error(string message, Exception ex);
}
