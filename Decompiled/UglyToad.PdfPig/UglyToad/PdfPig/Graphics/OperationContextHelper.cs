using System;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Geometry;
using UglyToad.PdfPig.Logging;

namespace UglyToad.PdfPig.Graphics;

internal static class OperationContextHelper
{
	internal static TransformationMatrix GetInitialMatrix(UserSpaceUnit userSpaceUnit, MediaBox mediaBox, CropBox cropBox, PageRotationDegrees rotation, ILog log)
	{
		PdfRectangle pdfRectangle = mediaBox.Bounds.Intersect(cropBox.Bounds) ?? cropBox.Bounds;
		if (rotation.Value == 0 && pdfRectangle.Left == 0.0 && pdfRectangle.Bottom == 0.0 && userSpaceUnit.PointMultiples == 1)
		{
			return TransformationMatrix.Identity;
		}
		TransformationMatrix translationMatrix = TransformationMatrix.GetTranslationMatrix(0.0 - pdfRectangle.Left, 0.0 - pdfRectangle.Bottom);
		if (userSpaceUnit.PointMultiples != 1)
		{
			log.Warn("User space unit other than 1 is not implemented");
		}
		double x;
		double y;
		switch (rotation.Value)
		{
		case 0:
			return translationMatrix;
		case 90:
			x = 0.0;
			y = pdfRectangle.Width;
			break;
		case 180:
			x = pdfRectangle.Width;
			y = pdfRectangle.Height;
			break;
		case 270:
			x = pdfRectangle.Height;
			y = 0.0;
			break;
		default:
			throw new InvalidOperationException($"Invalid value for page rotation: {rotation.Value}.");
		}
		return translationMatrix.Multiply(TransformationMatrix.GetRotationMatrix(-rotation.Value).Multiply(TransformationMatrix.GetTranslationMatrix(x, y)));
	}
}
