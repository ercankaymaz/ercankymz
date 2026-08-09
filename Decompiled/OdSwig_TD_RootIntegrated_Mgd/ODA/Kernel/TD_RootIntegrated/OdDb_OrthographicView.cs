using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdDb_OrthographicView
{
	kNonOrthoView = 0,
	kTopView = 1,
	kBottomView = 2,
	kFrontView = 3,
	kBackView = 4,
	kLeftView = 5,
	kRightView = 6
}
