using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum TriangleMeshBasedTpCalcParamsGeodesicContainmentType
{
	TmbGdpdAuto,
	TmbGdpdUserDefined,
	TmbGdpdSilhouette,
	TmbGdpdUserDefinedAndSilhouette,
	TmbGdpdUserDefinedMesh
}
