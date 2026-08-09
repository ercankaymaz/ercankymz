using System;

namespace OpenGL.Delegates;

[CLSCompliant(false)]
public delegate void glGetShaderSourceARB(uint shader, int maxLength, ref int length, ref string source);
