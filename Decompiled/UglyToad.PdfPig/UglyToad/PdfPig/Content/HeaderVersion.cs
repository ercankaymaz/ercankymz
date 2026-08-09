using System;

namespace UglyToad.PdfPig.Content;

internal class HeaderVersion
{
	public double Version { get; }

	public string VersionString { get; }

	public long OffsetInFile { get; }

	public HeaderVersion(double version, string versionString, long offsetInFile)
	{
		Version = version;
		VersionString = versionString;
		if (offsetInFile < 0)
		{
			throw new ArgumentOutOfRangeException($"Invalid offset for header version, must be positive. Got: {offsetInFile}.");
		}
		OffsetInFile = offsetInFile;
	}

	public override string ToString()
	{
		return "Version: " + VersionString;
	}
}
