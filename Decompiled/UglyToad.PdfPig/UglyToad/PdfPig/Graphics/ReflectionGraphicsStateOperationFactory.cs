using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Graphics.Operations;
using UglyToad.PdfPig.Graphics.Operations.ClippingPaths;
using UglyToad.PdfPig.Graphics.Operations.Compatibility;
using UglyToad.PdfPig.Graphics.Operations.General;
using UglyToad.PdfPig.Graphics.Operations.InlineImages;
using UglyToad.PdfPig.Graphics.Operations.MarkedContent;
using UglyToad.PdfPig.Graphics.Operations.PathConstruction;
using UglyToad.PdfPig.Graphics.Operations.PathPainting;
using UglyToad.PdfPig.Graphics.Operations.SpecialGraphicsState;
using UglyToad.PdfPig.Graphics.Operations.TextObjects;
using UglyToad.PdfPig.Graphics.Operations.TextPositioning;
using UglyToad.PdfPig.Graphics.Operations.TextShowing;
using UglyToad.PdfPig.Graphics.Operations.TextState;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Graphics;

public sealed class ReflectionGraphicsStateOperationFactory : IGraphicsStateOperationFactory
{
	public static readonly ReflectionGraphicsStateOperationFactory Instance = new ReflectionGraphicsStateOperationFactory();

	private static readonly IReadOnlyDictionary<string, Type> Operations = new Dictionary<string, Type>
	{
		{
			"SCN",
			typeof(SetStrokeColorAdvanced)
		},
		{
			"CS",
			typeof(SetStrokeColorSpace)
		},
		{
			"Tc",
			typeof(SetCharacterSpacing)
		},
		{
			"cm",
			typeof(ModifyCurrentTransformationMatrix)
		},
		{
			"K",
			typeof(SetStrokeColorDeviceCmyk)
		},
		{
			"EX",
			typeof(EndCompatibilitySection)
		},
		{
			"b*",
			typeof(CloseFillPathEvenOddRuleAndStroke)
		},
		{
			"SC",
			typeof(SetStrokeColor)
		},
		{
			"d",
			typeof(SetLineDashPattern)
		},
		{
			"DP",
			typeof(DesignateMarkedContentPointWithProperties)
		},
		{
			"RG",
			typeof(SetStrokeColorDeviceRgb)
		},
		{
			"BMC",
			typeof(BeginMarkedContent)
		},
		{
			"m",
			typeof(BeginNewSubpath)
		},
		{
			"EMC",
			typeof(EndMarkedContent)
		},
		{
			"k",
			typeof(SetNonStrokeColorDeviceCmyk)
		},
		{
			"Do",
			typeof(InvokeNamedXObject)
		},
		{
			"n",
			typeof(EndPath)
		},
		{
			"gs",
			typeof(SetGraphicsStateParametersFromDictionary)
		},
		{
			"f*",
			typeof(FillPathEvenOddRule)
		},
		{
			"d0",
			typeof(Type3SetGlyphWidth)
		},
		{
			"q",
			typeof(Push)
		},
		{
			"Q",
			typeof(Pop)
		},
		{
			"MP",
			typeof(DesignateMarkedContentPoint)
		},
		{
			"scn",
			typeof(SetNonStrokeColorAdvanced)
		},
		{
			"\"",
			typeof(MoveToNextLineShowTextWithSpacing)
		},
		{
			"Tz",
			typeof(SetHorizontalScaling)
		},
		{
			"BX",
			typeof(BeginCompatibilitySection)
		},
		{
			"i",
			typeof(SetFlatnessTolerance)
		},
		{
			"EI",
			typeof(EndInlineImage)
		},
		{
			"Td",
			typeof(MoveToNextLineWithOffset)
		},
		{
			"TL",
			typeof(SetTextLeading)
		},
		{
			"BT",
			typeof(BeginText)
		},
		{
			"BDC",
			typeof(BeginMarkedContentWithProperties)
		},
		{
			"c",
			typeof(AppendDualControlPointBezierCurve)
		},
		{
			"b",
			typeof(CloseFillPathNonZeroWindingAndStroke)
		},
		{
			"S",
			typeof(StrokePath)
		},
		{
			"T*",
			typeof(MoveToNextLine)
		},
		{
			"Tj",
			typeof(ShowText)
		},
		{
			"B",
			typeof(FillPathNonZeroWindingAndStroke)
		},
		{
			"y",
			typeof(AppendEndControlPointBezierCurve)
		},
		{
			"v",
			typeof(AppendStartControlPointBezierCurve)
		},
		{
			"sc",
			typeof(SetNonStrokeColor)
		},
		{
			"s",
			typeof(CloseAndStrokePath)
		},
		{
			"ID",
			typeof(BeginInlineImageData)
		},
		{
			"W",
			typeof(ModifyClippingByNonZeroWindingIntersect)
		},
		{
			"'",
			typeof(MoveToNextLineShowText)
		},
		{
			"J",
			typeof(SetLineCap)
		},
		{
			"f",
			typeof(FillPathNonZeroWinding)
		},
		{
			"B*",
			typeof(FillPathEvenOddRuleAndStroke)
		},
		{
			"Tf",
			typeof(SetFontAndSize)
		},
		{
			"ri",
			typeof(SetColorRenderingIntent)
		},
		{
			"sh",
			typeof(PaintShading)
		},
		{
			"M",
			typeof(SetMiterLimit)
		},
		{
			"re",
			typeof(AppendRectangle)
		},
		{
			"cs",
			typeof(SetNonStrokeColorSpace)
		},
		{
			"TD",
			typeof(MoveToNextLineWithOffsetSetLeading)
		},
		{
			"h",
			typeof(CloseSubpath)
		},
		{
			"G",
			typeof(SetStrokeColorDeviceGray)
		},
		{
			"Tw",
			typeof(SetWordSpacing)
		},
		{
			"BI",
			typeof(BeginInlineImage)
		},
		{
			"rg",
			typeof(SetNonStrokeColorDeviceRgb)
		},
		{
			"Tm",
			typeof(SetTextMatrix)
		},
		{
			"Ts",
			typeof(SetTextRise)
		},
		{
			"d1",
			typeof(Type3SetGlyphWidthAndBoundingBox)
		},
		{
			"W*",
			typeof(ModifyClippingByEvenOddIntersect)
		},
		{
			"l",
			typeof(AppendStraightLineSegment)
		},
		{
			"ET",
			typeof(EndText)
		},
		{
			"F",
			typeof(FillPathNonZeroWindingCompatibility)
		},
		{
			"TJ",
			typeof(ShowTextsWithPositioning)
		},
		{
			"j",
			typeof(SetLineJoin)
		},
		{
			"w",
			typeof(SetLineWidth)
		},
		{
			"g",
			typeof(SetNonStrokeColorDeviceGray)
		},
		{
			"Tr",
			typeof(SetTextRenderingMode)
		}
	};

	private ReflectionGraphicsStateOperationFactory()
	{
	}

	private static double[] TokensToDoubleArray(IReadOnlyList<IToken> tokens, bool exceptLast = false)
	{
		using ArrayPoolBufferWriter<double> arrayPoolBufferWriter = new ArrayPoolBufferWriter<double>(16);
		for (int i = 0; i < tokens.Count - (exceptLast ? 1 : 0); i++)
		{
			IToken token = tokens[i];
			if (token is ArrayToken arrayToken)
			{
				for (int j = 0; j < arrayToken.Length; j++)
				{
					if (!(arrayToken[j] is NumericToken numericToken))
					{
						return arrayPoolBufferWriter.WrittenSpan.ToArray();
					}
					arrayPoolBufferWriter.Write(numericToken.Data);
				}
			}
			if (!(token is NumericToken numericToken2))
			{
				return arrayPoolBufferWriter.WrittenSpan.ToArray();
			}
			arrayPoolBufferWriter.Write(numericToken2.Data);
		}
		return arrayPoolBufferWriter.WrittenSpan.ToArray();
	}

	private static int OperandToInt(IToken token)
	{
		return ((token as NumericToken) ?? throw new InvalidOperationException($"Invalid operand token encountered when expecting numeric: {token}.")).Int;
	}

	private static double OperandToDouble(IToken token)
	{
		return ((token as NumericToken) ?? throw new InvalidOperationException($"Invalid operand token encountered when expecting numeric: {token}.")).Data;
	}

	public IGraphicsStateOperation? Create(OperatorToken op, IReadOnlyList<IToken> operands)
	{
		switch (op.Data)
		{
		case "W*":
			return ModifyClippingByEvenOddIntersect.Value;
		case "W":
			return ModifyClippingByNonZeroWindingIntersect.Value;
		case "BX":
			return BeginCompatibilitySection.Value;
		case "EX":
			return EndCompatibilitySection.Value;
		case "ri":
			return new SetColorRenderingIntent((NameToken)operands[0]);
		case "i":
			if (operands.Count == 0)
			{
				return null;
			}
			return new SetFlatnessTolerance(OperandToDouble(operands[0]));
		case "J":
			return new SetLineCap(OperandToInt(operands[0]));
		case "d":
			return new SetLineDashPattern(TokensToDoubleArray(operands, exceptLast: true), OperandToInt(operands[operands.Count - 1]));
		case "j":
			return new SetLineJoin(OperandToInt(operands[0]));
		case "w":
			return new SetLineWidth(OperandToDouble(operands[0]));
		case "M":
			return new SetMiterLimit(OperandToDouble(operands[0]));
		case "c":
			if (operands.Count == 0)
			{
				return null;
			}
			return new AppendDualControlPointBezierCurve(OperandToDouble(operands[0]), OperandToDouble(operands[1]), OperandToDouble(operands[2]), OperandToDouble(operands[3]), OperandToDouble(operands[4]), OperandToDouble(operands[5]));
		case "y":
			if (operands.Count == 0)
			{
				return null;
			}
			return new AppendEndControlPointBezierCurve(OperandToDouble(operands[0]), OperandToDouble(operands[1]), OperandToDouble(operands[2]), OperandToDouble(operands[3]));
		case "re":
			if (operands.Count == 0)
			{
				return null;
			}
			return new AppendRectangle(OperandToDouble(operands[0]), OperandToDouble(operands[1]), OperandToDouble(operands[2]), OperandToDouble(operands[3]));
		case "v":
			if (operands.Count == 0)
			{
				return null;
			}
			return new AppendStartControlPointBezierCurve(OperandToDouble(operands[0]), OperandToDouble(operands[1]), OperandToDouble(operands[2]), OperandToDouble(operands[3]));
		case "l":
			return new AppendStraightLineSegment(OperandToDouble(operands[0]), OperandToDouble(operands[1]));
		case "m":
			return new BeginNewSubpath(OperandToDouble(operands[0]), OperandToDouble(operands[1]));
		case "h":
			return CloseSubpath.Value;
		case "cm":
			return new ModifyCurrentTransformationMatrix(TokensToDoubleArray(operands));
		case "Q":
			return Pop.Value;
		case "q":
			return Push.Value;
		case "gs":
			return new SetGraphicsStateParametersFromDictionary((NameToken)operands[0]);
		case "BT":
			return BeginText.Value;
		case "ET":
			return EndText.Value;
		case "Tc":
			return new SetCharacterSpacing(OperandToDouble(operands[0]));
		case "Tf":
			return new SetFontAndSize((NameToken)operands[0], OperandToDouble(operands[1]));
		case "Tz":
			return new SetHorizontalScaling(OperandToDouble(operands[0]));
		case "TL":
			return new SetTextLeading(OperandToDouble(operands[0]));
		case "Tr":
			return new SetTextRenderingMode(OperandToInt(operands[0]));
		case "Ts":
			return new SetTextRise(OperandToDouble(operands[0]));
		case "Tw":
			return new SetWordSpacing(OperandToDouble(operands[0]));
		case "s":
			return CloseAndStrokePath.Value;
		case "b*":
			return CloseFillPathEvenOddRuleAndStroke.Value;
		case "b":
			return CloseFillPathNonZeroWindingAndStroke.Value;
		case "BI":
			return BeginInlineImage.Value;
		case "BMC":
			return new BeginMarkedContent((NameToken)operands[0]);
		case "BDC":
		{
			NameToken name2 = (NameToken)operands[0];
			if (operands[1] is DictionaryToken properties2)
			{
				return new BeginMarkedContentWithProperties(name2, properties2);
			}
			if (operands[1] is NameToken propertyDictionaryName2)
			{
				return new BeginMarkedContentWithProperties(name2, propertyDictionaryName2);
			}
			string text4 = string.Join(", ", operands.Select((IToken x) => x.ToString()));
			throw new PdfDocumentFormatException("Attempted to set a marked-content sequence with invalid parameters: [" + text4 + "]");
		}
		case "MP":
			return new DesignateMarkedContentPoint((NameToken)operands[0]);
		case "DP":
		{
			NameToken name = (NameToken)operands[0];
			if (operands[1] is DictionaryToken properties)
			{
				return new DesignateMarkedContentPointWithProperties(name, properties);
			}
			if (operands[1] is NameToken propertyDictionaryName)
			{
				return new DesignateMarkedContentPointWithProperties(name, propertyDictionaryName);
			}
			string text2 = string.Join(", ", operands.Select((IToken x) => x.ToString()));
			throw new PdfDocumentFormatException("Attempted to set a marked-content point with invalid parameters: [" + text2 + "]");
		}
		case "EMC":
			return EndMarkedContent.Value;
		case "n":
			return EndPath.Value;
		case "f*":
			return FillPathEvenOddRule.Value;
		case "B*":
			return FillPathEvenOddRuleAndStroke.Value;
		case "f":
			return FillPathNonZeroWinding.Value;
		case "B":
			return FillPathNonZeroWindingAndStroke.Value;
		case "F":
			return FillPathNonZeroWindingCompatibility.Value;
		case "Do":
			return new InvokeNamedXObject((NameToken)operands[0]);
		case "T*":
			return MoveToNextLine.Value;
		case "'":
			if (operands.Count != 1)
			{
				throw new InvalidOperationException($"Attempted to create a move to next line and show text operation with {operands.Count} operands.");
			}
			if (operands[0] is StringToken stringToken)
			{
				return new MoveToNextLineShowText(stringToken.Data);
			}
			if (operands[0] is HexToken hexToken)
			{
				return new MoveToNextLineShowText(hexToken.Memory);
			}
			throw new InvalidOperationException("Tried to create a move to next line and show text operation with operand type: " + (operands[0]?.GetType().Name ?? "null"));
		case "\"":
		{
			NumericToken numericToken = (NumericToken)operands[0];
			NumericToken numericToken2 = (NumericToken)operands[1];
			IToken token = operands[2];
			if (token is StringToken stringToken3)
			{
				return new MoveToNextLineShowTextWithSpacing(numericToken.Double, numericToken2.Double, stringToken3.Data);
			}
			if (token is HexToken hexToken3)
			{
				return new MoveToNextLineShowTextWithSpacing(numericToken.Double, numericToken2.Double, hexToken3.Memory);
			}
			throw new InvalidOperationException("Tried to create a MoveToNextLineShowTextWithSpacing operation with operand type: " + (operands[2]?.GetType().Name ?? "null"));
		}
		case "Td":
			return new MoveToNextLineWithOffset(OperandToDouble(operands[0]), OperandToDouble(operands[1]));
		case "TD":
			return new MoveToNextLineWithOffsetSetLeading(OperandToDouble(operands[0]), OperandToDouble(operands[1]));
		case "sh":
			return new PaintShading((NameToken)operands[0]);
		case "sc":
			return new SetNonStrokeColor(TokensToDoubleArray(operands));
		case "scn":
		{
			if (operands[operands.Count - 1] is NameToken patternName2)
			{
				return new SetNonStrokeColorAdvanced((from x in operands.Take(operands.Count - 1)
					select ((NumericToken)x).Data).ToArray(), patternName2);
			}
			if (operands.All((IToken x) => x is NumericToken))
			{
				return new SetNonStrokeColorAdvanced(operands.Select((IToken x) => ((NumericToken)x).Data).ToArray());
			}
			string text3 = string.Join(", ", operands.Select((IToken x) => x.ToString()));
			throw new PdfDocumentFormatException("Attempted to set a non-stroke color space (scn) with invalid arguments: [" + text3 + "]");
		}
		case "k":
			return new SetNonStrokeColorDeviceCmyk(OperandToDouble(operands[0]), OperandToDouble(operands[1]), OperandToDouble(operands[2]), OperandToDouble(operands[3]));
		case "g":
			return new SetNonStrokeColorDeviceGray(OperandToDouble(operands[0]));
		case "rg":
			return new SetNonStrokeColorDeviceRgb(OperandToDouble(operands[0]), OperandToDouble(operands[1]), OperandToDouble(operands[2]));
		case "cs":
			return new SetNonStrokeColorSpace((NameToken)operands[0]);
		case "SC":
			return new SetStrokeColor(TokensToDoubleArray(operands));
		case "SCN":
		{
			if (operands[operands.Count - 1] is NameToken patternName)
			{
				return new SetStrokeColorAdvanced((from x in operands.Take(operands.Count - 1)
					select ((NumericToken)x).Data).ToList(), patternName);
			}
			if (operands.All((IToken x) => x is NumericToken))
			{
				return new SetStrokeColorAdvanced(operands.Select((IToken x) => ((NumericToken)x).Data).ToList());
			}
			string text = string.Join(", ", operands.Select((IToken x) => x.ToString()));
			throw new PdfDocumentFormatException("Attempted to set a stroke color space (SCN) with invalid arguments: [" + text + "]");
		}
		case "K":
		{
			double[] expectedDoubles3 = GetExpectedDoubles("k", operands, 4);
			return new SetStrokeColorDeviceCmyk(expectedDoubles3[0], expectedDoubles3[1], expectedDoubles3[2], expectedDoubles3[3]);
		}
		case "G":
			return new SetStrokeColorDeviceGray(OperandToDouble(operands[0]));
		case "RG":
			return new SetStrokeColorDeviceRgb(OperandToDouble(operands[0]), OperandToDouble(operands[1]), OperandToDouble(operands[2]));
		case "CS":
			return new SetStrokeColorSpace((NameToken)operands[0]);
		case "Tm":
			return new SetTextMatrix(TokensToDoubleArray(operands));
		case "S":
			return StrokePath.Value;
		case "Tj":
			if (operands.Count != 1)
			{
				throw new InvalidOperationException($"Attempted to create a show text operation with {operands.Count} operands.");
			}
			if (operands[0] is StringToken stringToken2)
			{
				return new ShowText(stringToken2.Data);
			}
			if (operands[0] is HexToken hexToken2)
			{
				return new ShowText(hexToken2.Memory);
			}
			throw new InvalidOperationException("Tried to create a show text operation with operand type: " + (operands[0]?.GetType().Name ?? "null"));
		case "TJ":
			if (operands.Count == 0)
			{
				throw new InvalidOperationException("Cannot have 0 parameters for a TJ operator.");
			}
			if (operands.Count == 1 && operands[0] is ArrayToken arrayToken)
			{
				return new ShowTextsWithPositioning(arrayToken.Data);
			}
			return new ShowTextsWithPositioning(operands.ToArray());
		case "ID":
			return null;
		case "EI":
			return null;
		case "d0":
		{
			double[] expectedDoubles2 = GetExpectedDoubles("d0", operands, 2);
			return new Type3SetGlyphWidth(expectedDoubles2[0], expectedDoubles2[1]);
		}
		case "d1":
		{
			double[] expectedDoubles = GetExpectedDoubles("d1", operands, 6);
			return new Type3SetGlyphWidthAndBoundingBox(expectedDoubles[0], expectedDoubles[1], expectedDoubles[2], expectedDoubles[3], expectedDoubles[4], expectedDoubles[5]);
		}
		default:
		{
			if (!Operations.TryGetValue(op.Data, out Type _))
			{
				return null;
			}
			throw new NotImplementedException("No support implemented for content operator " + op.Data);
		}
		}
	}

	private static double[] GetExpectedDoubles(string operatorSymbol, IReadOnlyList<IToken> operands, int resultCount)
	{
		double[] array = new double[resultCount];
		if (operands.Count < resultCount)
		{
			throw new InvalidOperationException($"Invalid operands for {operatorSymbol}, needed {resultCount} numbers, got: {PrintOperands(operands)}");
		}
		for (int i = 0; i < resultCount; i++)
		{
			if (!(operands[i] is NumericToken numericToken))
			{
				throw new InvalidOperationException($"Invalid operands for {operatorSymbol}, needed {resultCount} numbers, got: {PrintOperands(operands)}");
			}
			array[i] = numericToken.Data;
		}
		return array;
	}

	private static string PrintOperands(IEnumerable<IToken> operands)
	{
		return "[" + string.Join(", ", operands.Select((IToken x) => x.ToString())) + "]";
	}
}
