using System;

namespace buClass.Apps;

[Serializable]
public class TuftingLoadedFileInfo : buSerilization
{
	public string LoadedFileName = "";

	public string LoadedColor = "";

	public double FrameSizeX = 0.0;

	public double FrameSizeY = 0.0;

	public double TuftingSizeX = 0.0;

	public double TuftingSizeY = 0.0;

	public int TotalVectorCount = 0;

	public int TotalStitchCount = 0;

	public double TotalYarnLengthAsMeter = 0.0;

	public double TotalYarnWeight = 0.0;

	public double TotalUsedYarnWeight = 0.0;

	public string YarnType = "";
}
