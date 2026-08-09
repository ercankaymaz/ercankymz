using System;

namespace OpenGL.Delegates;

[CLSCompliant(false)]
public delegate void glStencilFuncSeparateATI(int frontfunc, int backfunc, int refval, uint mask);
