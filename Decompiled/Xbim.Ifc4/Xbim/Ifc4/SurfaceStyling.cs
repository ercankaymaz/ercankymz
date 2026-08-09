using System;
using System.Collections.Generic;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4;

public class SurfaceStyling
{
	public SurfaceStyle FrontFaceStyle;

	public SurfaceStyle BackFaceStyle;

	public static SurfaceStyling Empty { get; private set; }

	public bool IsEmpty
	{
		get
		{
			if (FrontFaceStyle == null)
			{
				return BackFaceStyle == null;
			}
			return false;
		}
	}

	static SurfaceStyling()
	{
		Empty = new SurfaceStyling();
	}

	public SurfaceStyling(SurfaceStyle frontFaceStyle, SurfaceStyle backFaceStyle)
	{
		FrontFaceStyle = frontFaceStyle;
		BackFaceStyle = backFaceStyle;
	}

	public SurfaceStyling(IEnumerable<SurfaceStyle> styles)
	{
		foreach (SurfaceStyle style in styles)
		{
			switch (style.Side)
			{
			case IfcSurfaceSide.POSITIVE:
				FrontFaceStyle = style;
				break;
			case IfcSurfaceSide.NEGATIVE:
				BackFaceStyle = style;
				break;
			case IfcSurfaceSide.BOTH:
				FrontFaceStyle = style;
				BackFaceStyle = style;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	private SurfaceStyling()
	{
	}

	public SurfaceStyling(SurfaceStyle frontFaceStyle)
	{
		FrontFaceStyle = frontFaceStyle;
		BackFaceStyle = frontFaceStyle;
	}

	public SurfaceStyle FrontOrDefault(SurfaceStyle defaultStyle = null)
	{
		return FrontFaceStyle ?? defaultStyle;
	}

	public SurfaceStyle FrontBackOrDefault(SurfaceStyle defaultStyle = null)
	{
		return FrontFaceStyle ?? BackFaceStyle ?? defaultStyle;
	}

	public SurfaceStyle BackOrDefault(SurfaceStyle defaultStyle = null)
	{
		return BackFaceStyle ?? defaultStyle;
	}
}
