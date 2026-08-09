using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType
{
	ScctTop,
	ScctBottom,
	ScctPartSilhouette,
	ScctPartEnd,
	ScctToolContact
}
