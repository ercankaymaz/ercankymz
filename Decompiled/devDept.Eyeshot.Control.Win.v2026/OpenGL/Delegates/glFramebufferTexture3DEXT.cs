using System;

namespace OpenGL.Delegates;

[CLSCompliant(false)]
public delegate void glFramebufferTexture3DEXT(int target, int attachment, int textarget, uint texture, int level, int zoffset);
