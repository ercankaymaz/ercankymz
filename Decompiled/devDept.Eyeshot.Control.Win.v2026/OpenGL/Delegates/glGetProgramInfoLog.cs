using System;

namespace OpenGL.Delegates;

[CLSCompliant(false)]
public delegate void glGetProgramInfoLog(uint program, int maxLength, ref int length, IntPtr infoLog);
