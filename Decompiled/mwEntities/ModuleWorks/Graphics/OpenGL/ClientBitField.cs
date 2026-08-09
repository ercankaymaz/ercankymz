using System;

namespace ModuleWorks.Graphics.OpenGL;

[Serializable]
[CLSCompliant(false)]
[Flags]
public enum ClientBitField : uint
{
	PixelStore = 1u,
	VertexArray = 2u,
	AllAttrib = uint.MaxValue
}
