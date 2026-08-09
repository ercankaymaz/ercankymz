using System.Linq;
using ACadSharp.Tables;
using ACadSharp.Tables.Collections;
using CSMath;

namespace ACadSharp.IO.DXF;

internal class DxfTablesSectionWriter : DxfSectionWriterBase
{
	public override string SectionName => "TABLES";

	public DxfTablesSectionWriter(IDxfStreamWriter writer, CadDocument document, CadObjectHolder objectHolder, DxfWriterConfiguration configuration)
		: base(writer, document, objectHolder, configuration)
	{
	}

	protected override void writeSection()
	{
		writeTable(_document.VPorts);
		writeTable(_document.LineTypes);
		writeTable(_document.Layers);
		writeTable(_document.TextStyles);
		writeTable(_document.Views);
		writeTable(_document.UCSs);
		writeTable(_document.AppIds);
		writeTable(_document.DimensionStyles, "AcDbDimStyleTable");
		writeTable(_document.BlockRecords);
	}

	private void writeTable<T>(Table<T> table, string subclass = null) where T : TableEntry
	{
		_writer.Write(DxfCode.Start, "TABLE");
		_writer.Write(DxfCode.ShapeName, table.ObjectName);
		writeCommonObjectData(table);
		_writer.Write(DxfCode.Subclass, "AcDbSymbolTable");
		_writer.Write(70, table.Count);
		if (!string.IsNullOrEmpty(subclass))
		{
			_writer.Write(DxfCode.Subclass, subclass);
		}
		foreach (T item in table)
		{
			writeEntry(item);
		}
		_writer.Write(DxfCode.Start, "ENDTAB");
	}

	private void writeEntry<T>(T entry) where T : TableEntry
	{
		DxfMap dxfMap = DxfMap.Create<T>();
		_writer.Write(DxfCode.Start, entry.ObjectName);
		writeCommonObjectData(entry);
		_writer.Write(DxfCode.Subclass, "AcDbSymbolTableRecord");
		_writer.Write(DxfCode.Subclass, entry.SubclassMarker);
		if (entry is TextStyle { IsShapeFile: not false })
		{
			_writer.Write(DxfCode.ShapeName, string.Empty);
		}
		else
		{
			_writer.Write(DxfCode.ShapeName, entry.Name);
		}
		_writer.Write(70, entry.Flags);
		if (!(entry is AppId))
		{
			if (!(entry is BlockRecord blockRecord))
			{
				if (!(entry is DimensionStyle dimensionStyle))
				{
					if (!(entry is Layer layer))
					{
						if (!(entry is LineType lineType))
						{
							if (!(entry is TextStyle textStyle2))
							{
								if (!(entry is UCS uCS))
								{
									if (!(entry is View view))
									{
										if (entry is VPort vPort)
										{
											writeVPort(vPort, dxfMap.SubClasses[vPort.SubclassMarker]);
										}
									}
									else
									{
										writeView(view, dxfMap.SubClasses[view.SubclassMarker]);
									}
								}
								else
								{
									writeUcs(uCS, dxfMap.SubClasses[uCS.SubclassMarker]);
								}
							}
							else
							{
								writeTextStyle(textStyle2, dxfMap.SubClasses[textStyle2.SubclassMarker]);
							}
						}
						else
						{
							writeLineType(lineType, dxfMap.SubClasses[lineType.SubclassMarker]);
						}
					}
					else
					{
						writeLayer(layer, dxfMap.SubClasses[layer.SubclassMarker]);
					}
				}
				else
				{
					writeDimensionStyle(dimensionStyle, dxfMap.SubClasses[dimensionStyle.SubclassMarker]);
				}
			}
			else
			{
				writeBlockRecord(blockRecord, dxfMap.SubClasses[blockRecord.SubclassMarker]);
			}
		}
		writeExtendedData(entry.ExtendedData);
	}

	private void writeBlockRecord(BlockRecord block, DxfClassMap map)
	{
		_writer.WriteHandle(340, block.Layout, map);
		_writer.Write(70, (short)block.Units, map);
		_writer.Write(280, block.IsExplodable ? ((byte)1) : ((byte)0), map);
		_writer.Write(281, block.CanScale ? ((byte)1) : ((byte)0), map);
	}

	private void writeDimensionStyle(DimensionStyle style, DxfClassMap map)
	{
		_writer.Write(3, style.PostFix, map);
		_writer.Write(4, style.AlternateDimensioningSuffix, map);
		_writer.Write(40, style.ScaleFactor, map);
		_writer.Write(41, style.ArrowSize, map);
		_writer.Write(42, style.ExtensionLineOffset, map);
		_writer.Write(43, style.DimensionLineIncrement, map);
		_writer.Write(44, style.ExtensionLineExtension, map);
		_writer.Write(45, style.Rounding, map);
		_writer.Write(46, style.DimensionLineExtension, map);
		_writer.Write(47, style.PlusTolerance, map);
		_writer.Write(48, style.MinusTolerance, map);
		_writer.Write(49, style.FixedExtensionLineLength, map);
		_writer.Write(50, style.JoggedRadiusDimensionTransverseSegmentAngle, map);
		if (style.TextBackgroundFillMode != DimensionTextBackgroundFillMode.NoBackground)
		{
			_writer.Write(69, (short)style.TextBackgroundFillMode, map);
			_writer.Write(70, style.TextBackgroundColor.GetApproxIndex(), map);
		}
		else
		{
			_writer.Write(70, 0, map);
		}
		if (style.ArcLengthSymbolPosition != ArcLengthSymbolPosition.AboveDimensionText)
		{
			_writer.Write(90, (int)style.ArcLengthSymbolPosition);
		}
		_writer.Write(140, style.TextHeight);
		_writer.Write(141, style.CenterMarkSize);
		_writer.Write(142, style.TickSize);
		_writer.Write(143, style.AlternateUnitScaleFactor);
		_writer.Write(144, style.LinearScaleFactor);
		_writer.Write(145, style.TextVerticalPosition);
		_writer.Write(146, style.ToleranceScaleFactor);
		_writer.Write(147, style.DimensionLineGap);
		_writer.Write(148, style.AlternateUnitRounding);
		_writer.Write(71, style.GenerateTolerances ? ((short)1) : ((short)0));
		_writer.Write(72, style.LimitsGeneration ? ((short)1) : ((short)0));
		_writer.Write(73, style.TextInsideHorizontal ? ((short)1) : ((short)0));
		_writer.Write(74, style.TextOutsideHorizontal ? ((short)1) : ((short)0));
		_writer.Write(75, style.SuppressFirstExtensionLine ? ((short)1) : ((short)0));
		_writer.Write(76, style.SuppressSecondExtensionLine ? ((short)1) : ((short)0));
		_writer.Write(77, (short)style.TextVerticalAlignment);
		_writer.Write(78, (short)style.ZeroHandling);
		_writer.Write(79, (short)style.AngularZeroHandling);
		_writer.Write(170, style.AlternateUnitDimensioning ? ((short)1) : ((short)0));
		_writer.Write(171, style.AlternateUnitDecimalPlaces);
		_writer.Write(172, style.TextOutsideExtensions ? ((short)1) : ((short)0));
		_writer.Write(173, style.SeparateArrowBlocks ? ((short)1) : ((short)0));
		_writer.Write(174, style.TextInsideExtensions ? ((short)1) : ((short)0));
		_writer.Write(175, style.SuppressOutsideExtensions ? ((short)1) : ((short)0));
		_writer.Write(176, style.DimensionLineColor.GetApproxIndex(), map);
		_writer.Write(177, style.ExtensionLineColor.GetApproxIndex(), map);
		_writer.Write(178, style.TextColor.GetApproxIndex(), map);
		_writer.Write(179, style.AngularDecimalPlaces);
		_writer.Write(271, style.DecimalPlaces);
		_writer.Write(272, style.ToleranceDecimalPlaces);
		_writer.Write(273, (short)style.AlternateUnitFormat);
		_writer.Write(274, style.AlternateUnitToleranceDecimalPlaces);
		_writer.Write(275, (short)style.AngularUnit);
		_writer.Write(276, (short)style.FractionFormat);
		_writer.Write(277, (short)style.LinearUnitFormat);
		_writer.Write(278, (short)style.DecimalSeparator);
		_writer.Write(279, (short)style.TextMovement);
		_writer.Write(280, (byte)style.TextHorizontalAlignment);
		_writer.Write(281, style.SuppressFirstDimensionLine);
		_writer.Write(282, style.SuppressSecondDimensionLine);
		_writer.Write(283, (byte)style.ToleranceAlignment);
		_writer.Write(284, (byte)style.ToleranceZeroHandling);
		_writer.Write(285, (byte)style.AlternateUnitZeroHandling);
		_writer.Write(286, (byte)style.AlternateUnitToleranceZeroHandling);
		_writer.Write(287, (byte)style.DimensionFit);
		_writer.Write(288, style.CursorUpdate);
		_writer.Write(289, (byte)style.DimensionTextArrowFit);
		_writer.Write(290, style.IsExtensionLineLengthFixed);
		_writer.WriteHandle(340, style.Style, map);
		_writer.WriteHandle(341, style.LeaderArrow, map);
		_writer.WriteHandle(342, style.ArrowBlock, map);
		_writer.WriteHandle(343, style.DimArrow1, map);
		_writer.WriteHandle(344, style.DimArrow2, map);
		_writer.Write(371, style.DimensionLineWeight);
		_writer.Write(372, style.ExtensionLineWeight);
	}

	private void writeLayer(Layer layer, DxfClassMap map)
	{
		int num = (layer.Color.IsTrueColor ? layer.Color.GetApproxIndex() : layer.Color.Index);
		if (layer.IsOn)
		{
			_writer.Write(62, num, map);
		}
		else
		{
			_writer.Write(62, -num, map);
		}
		if (layer.Color.IsTrueColor)
		{
			_writer.Write(420, (uint)layer.Color.TrueColor, map);
		}
		_writer.Write(6, layer.LineType.Name, map);
		_writer.Write(290, layer.PlotFlag, map);
		_writer.Write(370, (short)layer.LineWeight, map);
		_writer.Write(390, 0uL, map);
	}

	private void writeLineType(LineType linetype, DxfClassMap map)
	{
		_writer.Write(3, linetype.Description, map);
		_writer.Write(72, (short)linetype.Alignment, map);
		_writer.Write(73, (short)linetype.Segments.Count(), map);
		_writer.Write(40, linetype.PatternLength);
		foreach (LineType.Segment segment in linetype.Segments)
		{
			_writer.Write(49, segment.Length);
			_writer.Write(74, (short)segment.Flags);
			if (segment.Flags != LineTypeShapeFlags.None)
			{
				if (segment.Flags.HasFlag(LineTypeShapeFlags.Shape))
				{
					_writer.Write(75, segment.ShapeNumber);
				}
				if (segment.Flags.HasFlag(LineTypeShapeFlags.Text))
				{
					_writer.Write(75, (short)0);
				}
				if (segment.Style == null)
				{
					_writer.Write(340, 0uL);
				}
				else
				{
					_writer.Write(340, segment.Style.Handle);
				}
				_writer.Write(46, segment.Scale);
				_writer.Write(50, MathHelper.RadToDeg(segment.Rotation));
				_writer.Write(44, segment.Offset.X);
				_writer.Write(45, segment.Offset.Y);
				_writer.Write(9, segment.Text);
			}
		}
	}

	private void writeTextStyle(TextStyle textStyle, DxfClassMap map)
	{
		if (!string.IsNullOrEmpty(textStyle.Filename))
		{
			_writer.Write(3, textStyle.Filename, map);
		}
		if (!string.IsNullOrEmpty(textStyle.BigFontFilename))
		{
			_writer.Write(4, textStyle.BigFontFilename);
		}
		_writer.Write(40, textStyle.Height, map);
		_writer.Write(41, textStyle.Width, map);
		_writer.Write(42, textStyle.LastHeight, map);
		_writer.Write(50, textStyle.ObliqueAngle, map);
		_writer.Write(71, textStyle.MirrorFlag, map);
	}

	private void writeUcs(UCS ucs, DxfClassMap map)
	{
		_writer.Write(10, ucs.Origin.X, map);
		_writer.Write(20, ucs.Origin.Y, map);
		_writer.Write(30, ucs.Origin.Z, map);
		_writer.Write(11, ucs.XAxis.X, map);
		_writer.Write(21, ucs.XAxis.Y, map);
		_writer.Write(31, ucs.XAxis.Z, map);
		_writer.Write(12, ucs.YAxis.X, map);
		_writer.Write(22, ucs.YAxis.Y, map);
		_writer.Write(32, ucs.YAxis.Z, map);
		_writer.Write(71, ucs.OrthographicType, map);
		_writer.Write(79, ucs.OrthographicViewType, map);
		_writer.Write(146, ucs.Elevation, map);
	}

	private void writeView(View view, DxfClassMap map)
	{
		_writer.Write(40, view.Height, map);
		_writer.Write(41, view.Width, map);
		_writer.Write(42, view.LensLength, map);
		_writer.Write(43, view.FrontClipping, map);
		_writer.Write(44, view.BackClipping, map);
		_writer.Write(10, view.Center, map);
		_writer.Write(11, view.Direction, map);
		_writer.Write(12, view.Target, map);
		_writer.Write(50, view.Angle, map);
		_writer.Write(71, (short)view.ViewMode);
		_writer.Write(72, view.IsUcsAssociated, map);
		_writer.Write(79, (short)view.UcsOrthographicType);
		_writer.Write(281, (byte)view.RenderMode);
		_writer.Write(110, view.UcsOrigin);
		_writer.Write(111, view.UcsXAxis);
		_writer.Write(112, view.UcsYAxis);
		_writer.Write(146, view.UcsElevation);
	}

	private void writeVPort(VPort vport, DxfClassMap map)
	{
		_writer.Write(10, vport.BottomLeft, map);
		_writer.Write(11, vport.TopRight, map);
		_writer.Write(12, vport.Center, map);
		_writer.Write(13, vport.SnapBasePoint, map);
		_writer.Write(14, vport.SnapSpacing, map);
		_writer.Write(15, vport.GridSpacing, map);
		_writer.Write(16, vport.Direction, map);
		_writer.Write(17, vport.Target, map);
		_writer.Write(40, vport.ViewHeight);
		_writer.Write(41, vport.AspectRatio);
		_writer.Write(75, vport.SnapOn ? ((short)1) : ((short)0));
		_writer.Write(76, vport.ShowGrid ? ((short)1) : ((short)0));
	}
}
