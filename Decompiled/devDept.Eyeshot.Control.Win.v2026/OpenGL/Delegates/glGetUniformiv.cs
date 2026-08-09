using System;

namespace OpenGL.Delegates;

[CLSCompliant(false)]
public delegate void glGetUniformiv(uint programObj, int location, int[] iparams);
