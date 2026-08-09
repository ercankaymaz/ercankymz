using System;
using System.Runtime.InteropServices;

namespace OpenGL.Delegates;

[UnmanagedFunctionPointer(CallingConvention.StdCall)]
public delegate void glVertexAttribPointerARB(int index, int size, int type, bool normalized, int stride, IntPtr pointer);
