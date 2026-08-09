using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum DrillingBasedTpCalcParamsPattern
{
	TcDbPointsOnSurfs,
	TcDbPoints,
	TcDbLines,
	TcDbLinesOnSurfs,
	TcDbLinesOnMesh
}
