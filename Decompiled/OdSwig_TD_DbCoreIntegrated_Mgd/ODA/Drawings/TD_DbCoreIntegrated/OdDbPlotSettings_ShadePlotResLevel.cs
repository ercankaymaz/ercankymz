using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbPlotSettings_ShadePlotResLevel
{
	kDraft = 0,
	kPreview = 1,
	kNormal = 2,
	kPresentation = 3,
	kMaximum = 4,
	kCustom = 5
}
