using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class PdfPage
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Size2D _0023_003DzmHMtUW2Xjt9chJvxlQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Entity[] _0023_003DzkQFaoC3kEbwVDWS1fA_003D_003D = Array.Empty<Entity>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Tuple<RectangleF, double>[] _0023_003Dz96khXyCrQXyv7_PrdFhLVOIbFJzY;

	public Size2D Size
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzmHMtUW2Xjt9chJvxlQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzmHMtUW2Xjt9chJvxlQ_003D_003D = value;
		}
	}

	public Entity[] Entities
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzkQFaoC3kEbwVDWS1fA_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzkQFaoC3kEbwVDWS1fA_003D_003D = value;
		}
	}

	public Tuple<RectangleF, double>[] Viewports
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz96khXyCrQXyv7_PrdFhLVOIbFJzY;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz96khXyCrQXyv7_PrdFhLVOIbFJzY = value;
		}
	}

	internal PdfPage()
	{
	}
}
