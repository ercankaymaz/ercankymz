using System;
using System.Diagnostics;

namespace SharpGLTF.Scenes;

[DebuggerDisplay("EmptyContent")]
internal class EmptyContent : ICloneable
{
	public EmptyContent()
	{
	}

	public object Clone()
	{
		return new EmptyContent(this);
	}

	private EmptyContent(EmptyContent other)
	{
	}
}
