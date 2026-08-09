using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbRasterImage_ImageDisplayOpt
{
	kShow = 1,
	kShowUnAligned = 2,
	kClip = 4,
	kTransparent = 8
}
