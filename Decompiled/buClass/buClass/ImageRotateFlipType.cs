using System;

namespace buClass;

[Serializable]
public enum ImageRotateFlipType
{
	RotateNoneFlipNone,
	Rotate90FlipNone,
	Rotate180FlipNone,
	Rotate270FlipNone,
	RotateNoneFlipX,
	Rotate90FlipX,
	RotateNoneFlipY,
	Rotate270FlipX
}
