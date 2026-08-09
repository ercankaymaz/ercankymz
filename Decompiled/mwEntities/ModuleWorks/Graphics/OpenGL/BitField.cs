using System;

namespace ModuleWorks.Graphics.OpenGL;

[Serializable]
[Flags]
public enum BitField
{
	Current = 1,
	Point = 2,
	Line = 4,
	Polygon = 8,
	PolygonStipple = 0x10,
	PixelMode = 0x20,
	Lighting = 0x40,
	Fog = 0x80,
	DepthBuffer = 0x100,
	AccumBuffer = 0x200,
	StencilBuffer = 0x400,
	Viewport = 0x800,
	Transform = 0x1000,
	Enable = 0x2000,
	ColorBuffer = 0x4000,
	Hint = 0x8000,
	Eval = 0x10000,
	List = 0x20000,
	Texture = 0x40000,
	Scissor = 0x80000,
	AllAttribs = 0xFFFFF
}
