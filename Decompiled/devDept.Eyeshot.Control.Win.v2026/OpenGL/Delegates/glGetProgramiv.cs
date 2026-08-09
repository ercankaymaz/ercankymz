using System;

namespace OpenGL.Delegates;

[CLSCompliant(false)]
public delegate void glGetProgramiv(uint program, int pname, ref int parameters);
