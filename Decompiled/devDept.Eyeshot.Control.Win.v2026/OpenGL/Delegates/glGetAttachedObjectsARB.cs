using System;

namespace OpenGL.Delegates;

[CLSCompliant(false)]
public delegate void glGetAttachedObjectsARB(uint programObj, int maxCount, ref int count, int[] objects);
