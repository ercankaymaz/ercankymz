using System;

namespace OpenGL.Delegates;

[CLSCompliant(false)]
public delegate void glShaderSource(uint shader, int count, string[] source, int[] length);
