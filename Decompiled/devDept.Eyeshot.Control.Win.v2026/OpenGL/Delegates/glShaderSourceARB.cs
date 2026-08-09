using System;

namespace OpenGL.Delegates;

[CLSCompliant(false)]
public delegate void glShaderSourceARB(uint shaderobj, int nstrings, string[] source, int[] lengths);
