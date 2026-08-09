using System;

namespace buClass;

[Serializable]
public enum CamGeodesicContainmentType
{
	TmbGdpdAuto,
	TmbGdpdUserDefined,
	TmbGdpdSilhouette,
	TmbGdpdUserDefinedAndSilhouette,
	TmbGdpdUserDefinedMesh
}
