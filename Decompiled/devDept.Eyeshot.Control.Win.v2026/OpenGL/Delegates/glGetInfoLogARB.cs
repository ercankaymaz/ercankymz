using System;
using System.Text;

namespace OpenGL.Delegates;

[CLSCompliant(false)]
public delegate void glGetInfoLogARB(uint shader, int maxLength, ref int length, StringBuilder infoLog);
