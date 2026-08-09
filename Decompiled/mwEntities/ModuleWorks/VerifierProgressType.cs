using System;

namespace ModuleWorks;

[Serializable]
[Obsolete("Deprecated since Release 2017.04.")]
public enum VerifierProgressType
{
	Unknown,
	InitializeTarget,
	InitializeMesh,
	CalcGouges,
	CalcExcess,
	CalcDeviation,
	DrawStockMesh,
	FreeWorkpiece,
	FreeTarget,
	SimulateMoveList,
	OffsettingMesh,
	SaveSimulation,
	JobLoadSimulation
}
