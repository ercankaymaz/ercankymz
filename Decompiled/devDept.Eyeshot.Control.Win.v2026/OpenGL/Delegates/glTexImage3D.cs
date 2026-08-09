using System;

namespace OpenGL.Delegates;

public delegate void glTexImage3D(int target, int level, int internalformat, int width, int height, int depth, int border, int format, int type, IntPtr pixels);
