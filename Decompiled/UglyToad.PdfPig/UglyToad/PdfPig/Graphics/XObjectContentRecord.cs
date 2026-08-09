using System;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Graphics.Colors;
using UglyToad.PdfPig.Graphics.Core;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.XObjects;

namespace UglyToad.PdfPig.Graphics;

public class XObjectContentRecord
{
	public XObjectType Type { get; }

	public StreamToken Stream { get; }

	public TransformationMatrix AppliedTransformation { get; }

	public RenderingIntent DefaultRenderingIntent { get; }

	public ColorSpaceDetails DefaultColorSpace { get; }

	internal XObjectContentRecord(XObjectType type, StreamToken stream, TransformationMatrix appliedTransformation, RenderingIntent defaultRenderingIntent, ColorSpaceDetails defaultColorSpace)
	{
		Type = type;
		Stream = stream ?? throw new ArgumentNullException("stream");
		AppliedTransformation = appliedTransformation;
		DefaultRenderingIntent = defaultRenderingIntent;
		DefaultColorSpace = defaultColorSpace;
	}
}
