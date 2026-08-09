using System;

namespace ModuleWorks;

public class ProgressEventArgs : EventArgs
{
	public ToolPathObjectType ObjectType { get; private set; }

	public ToolPathOperationType OperationType { get; private set; }

	[CLSCompliant(false)]
	public uint OverallProgressPercentage { get; private set; }

	[CLSCompliant(false)]
	public uint CurrentObjectNumber { get; private set; }

	[CLSCompliant(false)]
	public uint TotalObjectCount { get; private set; }

	[CLSCompliant(false)]
	public uint ProgressPercentage { get; private set; }

	public bool Cancelled { get; set; }

	[CLSCompliant(false)]
	public ProgressEventArgs(ToolPathObjectType objectType, ToolPathOperationType operationType, uint overallProgressPercentage, uint currentObjectNumber, uint totalObjectCount, uint progressPercentage)
	{
		Cancelled = false;
		ObjectType = objectType;
		OverallProgressPercentage = overallProgressPercentage;
		OperationType = operationType;
		CurrentObjectNumber = currentObjectNumber;
		TotalObjectCount = totalObjectCount;
		ProgressPercentage = progressPercentage;
	}

	public override string ToString()
	{
		return "Object: " + ObjectType.ToString() + "\r\nOperation: " + OperationType.ToString() + "\r\nOverall %: " + OverallProgressPercentage + "\r\nProgress %: " + ProgressPercentage + "\r\nObject #: " + CurrentObjectNumber + "\r\nTotal Objects: " + TotalObjectCount;
	}
}
