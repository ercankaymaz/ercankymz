using System;

namespace OpenGL.Delegates;

public delegate void glCompressedTexImage2DARB(int target, int level, int internalformat, int width, int height, int border, int imagesize, IntPtr data);
