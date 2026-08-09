using System;

namespace ODA.Prc.OdPrcModule;

[Flags]
public enum PrcPreviewGenerator_ViewType
{
	kDefault = 0,
	kFront = 1,
	kBack = 2,
	kTop = 3,
	kBottom = 4,
	kRight = 5,
	kLeft = 6
}
