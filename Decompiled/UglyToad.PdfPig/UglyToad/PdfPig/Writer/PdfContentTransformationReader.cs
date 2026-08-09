using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Graphics.Operations;
using UglyToad.PdfPig.Graphics.Operations.SpecialGraphicsState;

namespace UglyToad.PdfPig.Writer;

internal static class PdfContentTransformationReader
{
	public static TransformationMatrix? GetGlobalTransform(IEnumerable<IGraphicsStateOperation> operations)
	{
		TransformationMatrix? result = null;
		int num = 0;
		foreach (IGraphicsStateOperation operation in operations)
		{
			if (operation is ModifyCurrentTransformationMatrix modifyCurrentTransformationMatrix)
			{
				if (num == 0 && modifyCurrentTransformationMatrix.Value.Length == 6)
				{
					result = TransformationMatrix.FromArray(modifyCurrentTransformationMatrix.Value);
				}
			}
			else if (operation is Push)
			{
				num++;
			}
			else if (operation is Pop)
			{
				num--;
			}
		}
		return result;
	}
}
