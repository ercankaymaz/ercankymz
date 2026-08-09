using System;

namespace OpenGL.Delegates;

[CLSCompliant(false)]
public delegate void glGetActiveAttribARB(uint programObj, int index, int maxLength, ref int length, ref int size, ref int type, string name);
