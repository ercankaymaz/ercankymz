using System;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Content;

public class MediaBox
{
	private const double PointsPerInch = 72.0;

	private const double PointsPerMm = 2.8346456692913384;

	public static readonly MediaBox Letter = new MediaBox(new PdfRectangle(0.0, 0.0, 612.0, 792.0));

	public static readonly MediaBox Legal = new MediaBox(new PdfRectangle(0.0, 0.0, 612.0, 1008.0));

	public static readonly MediaBox A0 = new MediaBox(new PdfRectangle(0.0, 0.0, 2383.9370078740158, 3370.3937007874015));

	public static readonly MediaBox A1 = new MediaBox(new PdfRectangle(0.0, 0.0, 1683.779527559055, 2383.9370078740158));

	public static readonly MediaBox A2 = new MediaBox(new PdfRectangle(0.0, 0.0, 1190.551181102362, 1683.779527559055));

	public static readonly MediaBox A3 = new MediaBox(new PdfRectangle(0.0, 0.0, 841.8897637795275, 1190.551181102362));

	public static readonly MediaBox A4 = new MediaBox(new PdfRectangle(0.0, 0.0, 595.275590551181, 841.8897637795275));

	public static readonly MediaBox A5 = new MediaBox(new PdfRectangle(0.0, 0.0, 419.5275590551181, 595.275590551181));

	public static readonly MediaBox A6 = new MediaBox(new PdfRectangle(0.0, 0.0, 297.6377952755905, 419.5275590551181));

	public PdfRectangle Bounds { get; }

	public MediaBox(PdfRectangle? bounds)
	{
		Bounds = bounds ?? throw new ArgumentNullException("bounds");
	}
}
