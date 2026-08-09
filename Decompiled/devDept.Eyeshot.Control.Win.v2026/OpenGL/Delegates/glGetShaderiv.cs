using System;

namespace OpenGL.Delegates;

[CLSCompliant(false)]
public delegate void glGetShaderiv(uint shader, int pname, ref int parameters);
