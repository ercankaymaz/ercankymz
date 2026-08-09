using System;

namespace OpenGL.Delegates;

[CLSCompliant(false)]
public delegate void glGetShaderInfoLog(uint shader, int maxLength, ref int length, IntPtr infoLog);
