using System;

namespace OpenGL.Delegates;

[CLSCompliant(false)]
public delegate void glGetUniformfv(uint programObj, int location, float[] fparams);
