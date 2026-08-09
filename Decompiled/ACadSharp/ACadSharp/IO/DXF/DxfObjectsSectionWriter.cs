using System;
using System.Linq;
using ACadSharp.Entities;
using ACadSharp.Objects;
using ACadSharp.Objects.Evaluations;
using CSMath;

namespace ACadSharp.IO.DXF;

internal class DxfObjectsSectionWriter : DxfSectionWriterBase
{
	public override string SectionName => "OBJECTS";

	public DxfObjectsSectionWriter(IDxfStreamWriter writer, CadDocument document, CadObjectHolder holder, DxfWriterConfiguration configuration)
		: base(writer, document, holder, configuration)
	{
	}

	protected void writeBookColor(BookColor color)
	{
		_writer.Write(DxfCode.Subclass, "AcDbColor");
		_writer.Write(62, color.Color.GetApproxIndex());
		_writer.WriteTrueColor(420, color.Color);
		_writer.Write(430, color.Name + "$" + color.BookName);
	}

	protected void writeDictionary(CadDictionary dict)
	{
		_writer.Write(DxfCode.Subclass, "AcDbDictionary");
		_writer.Write(280, dict.HardOwnerFlag);
		_writer.Write(281, (int)dict.ClonningFlags);
		foreach (NonGraphicalObject item in dict)
		{
			if (!(item is XRecord) || base.Configuration.WriteXRecords)
			{
				_writer.Write(3, item.Name);
				_writer.Write(350, item.Handle);
				base.Holder.Objects.Enqueue(item);
			}
		}
		if (dict is CadDictionaryWithDefault cadDictionaryWithDefault)
		{
			_writer.Write(100, "AcDbDictionaryWithDefault");
			_writer.WriteHandle(340, cadDictionaryWithDefault.DefaultEntry);
		}
	}

	protected void writeDictionaryVariable(DictionaryVariable dictvar)
	{
		DxfClassMap map = DxfClassMap.Create<DictionaryVariable>();
		_writer.Write(100, "DictionaryVariables");
		_writer.Write(1, dictvar.Value, map);
		_writer.Write(280, dictvar.ObjectSchemaNumber, map);
	}

	protected void writeGeoData(GeoData geodata)
	{
		DxfClassMap map = DxfClassMap.Create<GeoData>();
		_writer.Write(100, "AcDbGeoData", map);
		switch (base.Version)
		{
		case ACadVersion.Unknown:
		case ACadVersion.MC0_0:
		case ACadVersion.AC1_2:
		case ACadVersion.AC1_4:
		case ACadVersion.AC1_50:
		case ACadVersion.AC2_10:
		case ACadVersion.AC1002:
		case ACadVersion.AC1003:
		case ACadVersion.AC1004:
		case ACadVersion.AC1006:
		case ACadVersion.AC1009:
		case ACadVersion.AC1012:
		case ACadVersion.AC1014:
		case ACadVersion.AC1015:
		case ACadVersion.AC1018:
		case ACadVersion.AC1021:
			_writer.Write(90, 1, map);
			break;
		case ACadVersion.AC1024:
			_writer.Write(90, 2, map);
			break;
		case ACadVersion.AC1027:
		case ACadVersion.AC1032:
			_writer.Write(90, 3, map);
			break;
		}
		if (geodata.HostBlock != null)
		{
			_writer.Write(330, geodata.HostBlock.Handle, map);
		}
		_writer.Write(70, (short)geodata.CoordinatesType, map);
		if (base.Version <= ACadVersion.AC1021)
		{
			_writer.Write(40, geodata.ReferencePoint.Y, map);
			_writer.Write(41, geodata.ReferencePoint.X, map);
			_writer.Write(42, geodata.ReferencePoint.Z, map);
			_writer.Write(91, (int)geodata.HorizontalUnits, map);
			_writer.Write(10, geodata.DesignPoint, map);
			_writer.Write(11, XYZ.Zero, map);
			_writer.Write(210, geodata.UpDirection, map);
			_writer.Write(52, MathHelper.RadToDeg(Math.PI / 2.0 - geodata.NorthDirection.GetAngle()), map);
			_writer.Write(43, 1.0, map);
			_writer.Write(44, 1.0, map);
			_writer.Write(45, 1.0, map);
			_writer.Write(301, geodata.CoordinateSystemDefinition, map);
			_writer.Write(302, geodata.GeoRssTag, map);
			_writer.Write(46, geodata.UserSpecifiedScaleFactor, map);
			_writer.Write(303, string.Empty, map);
			_writer.Write(304, string.Empty, map);
			_writer.Write(305, geodata.ObservationFromTag, map);
			_writer.Write(306, geodata.ObservationToTag, map);
			_writer.Write(307, geodata.ObservationCoverageTag, map);
			_writer.Write(93, geodata.Points.Count, map);
			foreach (GeoData.GeoMeshPoint point in geodata.Points)
			{
				_writer.Write(12, point.Source, map);
				_writer.Write(13, point.Destination, map);
			}
			_writer.Write(96, geodata.Faces.Count, map);
			foreach (GeoData.GeoMeshFace face in geodata.Faces)
			{
				_writer.Write(97, face.Index1, map);
				_writer.Write(98, face.Index2, map);
				_writer.Write(99, face.Index3, map);
			}
			_writer.Write(3, "CIVIL3D_DATA_BEGIN", map);
			_writer.Write(292, false, map);
			_writer.Write(14, geodata.ReferencePoint.Convert<XY>(), map);
			_writer.Write(15, geodata.ReferencePoint.Convert<XY>(), map);
			_writer.Write(93, 0, map);
			_writer.Write(94, 0, map);
			_writer.Write(293, false, map);
			_writer.Write(16, XY.Zero, map);
			_writer.Write(17, XY.Zero, map);
			_writer.Write(54, MathHelper.RadToDeg(Math.PI / 2.0 - geodata.NorthDirection.GetAngle()), map);
			_writer.Write(140, Math.PI / 2.0 - geodata.NorthDirection.GetAngle(), map);
			_writer.Write(95, (int)geodata.ScaleEstimationMethod, map);
			_writer.Write(141, geodata.UserSpecifiedScaleFactor, map);
			_writer.Write(294, geodata.EnableSeaLevelCorrection, map);
			_writer.Write(142, geodata.SeaLevelElevation, map);
			_writer.Write(143, geodata.CoordinateProjectionRadius, map);
			_writer.Write(4, "CIVIL3D_DATA_END", map);
			return;
		}
		_writer.Write(10, geodata.DesignPoint, map);
		_writer.Write(11, geodata.ReferencePoint, map);
		_writer.Write(40, geodata.VerticalUnitScale, map);
		_writer.Write(91, (int)geodata.HorizontalUnits, map);
		_writer.Write(41, geodata.VerticalUnitScale, map);
		_writer.Write(92, (int)geodata.VerticalUnits, map);
		_writer.Write(210, geodata.UpDirection, map);
		_writer.Write(12, geodata.NorthDirection, map);
		_writer.Write(95, geodata.ScaleEstimationMethod, map);
		_writer.Write(141, geodata.UserSpecifiedScaleFactor, map);
		_writer.Write(294, geodata.EnableSeaLevelCorrection, map);
		_writer.Write(142, geodata.SeaLevelElevation, map);
		_writer.Write(143, geodata.CoordinateProjectionRadius, map);
		writeLongTextValue(301, 303, geodata.CoordinateSystemDefinition);
		_writer.Write(302, geodata.GeoRssTag, map);
		_writer.Write(305, geodata.ObservationFromTag, map);
		_writer.Write(306, geodata.ObservationToTag, map);
		_writer.Write(307, geodata.ObservationCoverageTag, map);
		_writer.Write(93, geodata.Points.Count, map);
		foreach (GeoData.GeoMeshPoint point2 in geodata.Points)
		{
			_writer.Write(13, point2.Source, map);
			_writer.Write(14, point2.Destination, map);
		}
		_writer.Write(96, geodata.Faces.Count, map);
		foreach (GeoData.GeoMeshFace face2 in geodata.Faces)
		{
			_writer.Write(97, face2.Index1, map);
			_writer.Write(98, face2.Index2, map);
			_writer.Write(99, face2.Index3, map);
		}
	}

	protected void writeGroup(Group group)
	{
		_writer.Write(100, "AcDbGroup");
		_writer.Write(300, group.Description);
		_writer.Write(70, group.IsUnnamed ? ((short)1) : ((short)0));
		_writer.Write(71, group.Selectable ? ((short)1) : ((short)0));
		foreach (Entity entity in group.Entities)
		{
			_writer.WriteHandle(340, entity);
		}
	}

	protected void writeImageDefinition(ImageDefinition definition)
	{
		DxfClassMap map = DxfClassMap.Create<ImageDefinition>();
		_writer.Write(100, "AcDbRasterImageDef");
		_writer.Write(90, definition.ClassVersion, map);
		_writer.Write(1, definition.FileName, map);
		_writer.Write(10, definition.Size, map);
		_writer.Write(280, definition.IsLoaded ? 1 : 0, map);
		_writer.Write(281, (byte)definition.Units, map);
	}

	protected void writeLayout(Layout layout)
	{
		DxfClassMap map = DxfClassMap.Create<Layout>();
		writePlotSettings(layout);
		_writer.Write(100, "AcDbLayout");
		_writer.Write(1, layout.Name, map);
		_writer.Write(71, layout.TabOrder, map);
		_writer.Write(10, layout.MinLimits, map);
		_writer.Write(11, layout.MaxLimits, map);
		_writer.Write(12, layout.InsertionBasePoint, map);
		_writer.Write(13, layout.Origin, map);
		_writer.Write(14, layout.MinExtents, map);
		_writer.Write(15, layout.MaxExtents, map);
		_writer.Write(16, layout.XAxis, map);
		_writer.Write(17, layout.YAxis, map);
		_writer.Write(146, layout.Elevation, map);
		_writer.Write(76, (short)0, map);
		_writer.WriteHandle(330, layout.AssociatedBlock, map);
	}

	protected void writeMLineStyle(MLineStyle style)
	{
		DxfClassMap map = DxfClassMap.Create<MLineStyle>();
		_writer.Write(100, "AcDbMlineStyle");
		_writer.Write(2, style.Name, map);
		_writer.Write(70, (short)style.Flags, map);
		_writer.Write(3, style.Description, map);
		_writer.Write(62, style.FillColor.GetApproxIndex(), map);
		_writer.Write(51, style.StartAngle, map);
		_writer.Write(52, style.EndAngle, map);
		_writer.Write(71, (short)style.Elements.Count(), map);
		foreach (MLineStyle.Element element in style.Elements)
		{
			_writer.Write(49, element.Offset, map);
			_writer.Write(62, element.Color.Index, map);
			_writer.Write(6, element.LineType.Name, map);
		}
	}

	protected void writeMultiLeaderStyle(MultiLeaderStyle style)
	{
		DxfClassMap map = DxfClassMap.Create<MultiLeaderStyle>();
		_writer.Write(100, "AcDbMLeaderStyle");
		_writer.Write(179, 2);
		_writer.Write(170, (short)style.ContentType, map);
		_writer.Write(171, (short)style.MultiLeaderDrawOrder, map);
		_writer.Write(172, (short)style.LeaderDrawOrder, map);
		_writer.Write(90, style.MaxLeaderSegmentsPoints, map);
		_writer.Write(40, style.FirstSegmentAngleConstraint, map);
		_writer.Write(41, style.SecondSegmentAngleConstraint, map);
		_writer.Write(173, (short)style.PathType, map);
		_writer.WriteCmColor(91, style.LineColor, map);
		_writer.WriteHandle(340, style.LeaderLineType);
		_writer.Write(92, (short)style.LeaderLineWeight, map);
		_writer.Write(290, style.EnableLanding, map);
		_writer.Write(42, style.LandingGap, map);
		_writer.Write(291, style.EnableDogleg, map);
		_writer.Write(43, style.LandingDistance, map);
		_writer.Write(3, style.Description, map);
		_writer.WriteHandle(341, style.Arrowhead);
		_writer.Write(44, style.ArrowheadSize, map);
		_writer.Write(300, style.DefaultTextContents, map);
		_writer.WriteHandle(342, style.TextStyle);
		_writer.Write(174, (short)style.TextLeftAttachment, map);
		_writer.Write(178, (short)style.TextRightAttachment, map);
		_writer.Write(175, style.TextAngle, map);
		_writer.Write(176, (short)style.TextAlignment, map);
		_writer.WriteCmColor(93, style.TextColor, map);
		_writer.Write(45, style.TextHeight, map);
		_writer.Write(292, style.TextFrame, map);
		_writer.Write(297, style.TextAlignAlwaysLeft, map);
		_writer.Write(46, style.AlignSpace, map);
		_writer.WriteHandle(343, style.BlockContent);
		_writer.WriteCmColor(94, style.BlockContentColor, map);
		_writer.Write(47, style.BlockContentScale.X, map);
		_writer.Write(49, style.BlockContentScale.Y, map);
		_writer.Write(140, style.BlockContentScale.Z, map);
		_writer.Write(293, style.EnableBlockContentScale, map);
		_writer.Write(141, style.BlockContentRotation, map);
		_writer.Write(294, style.EnableBlockContentRotation, map);
		_writer.Write(177, (short)style.BlockContentConnection, map);
		_writer.Write(142, style.ScaleFactor, map);
		_writer.Write(295, style.OverwritePropertyValue, map);
		_writer.Write(296, style.IsAnnotative, map);
		_writer.Write(143, style.BreakGapSize, map);
		_writer.Write(271, (short)style.TextAttachmentDirection, map);
		_writer.Write(272, (short)style.TextBottomAttachment, map);
		_writer.Write(273, (short)style.TextTopAttachment, map);
		_writer.Write(298, false);
	}

	protected void writeObject<T>(T co) where T : CadObject
	{
		if (!isObjectSupported(co) || (co is XRecord && !base.Configuration.WriteXRecords))
		{
			return;
		}
		_writer.Write(DxfCode.Start, co.ObjectName);
		writeCommonObjectData(co);
		if (!(co is BookColor color))
		{
			if (!(co is CadDictionary dict))
			{
				if (!(co is DictionaryVariable dictvar))
				{
					if (!(co is GeoData geodata))
					{
						if (!(co is Group obj))
						{
							if (co is ImageDefinition definition)
							{
								writeImageDefinition(definition);
								return;
							}
							if (co is ImageDefinitionReactor reactor)
							{
								writeImageDefinitionReactor(reactor);
								return;
							}
							if (!(co is Layout layout))
							{
								if (!(co is MLineStyle style))
								{
									if (!(co is MultiLeaderStyle style2))
									{
										if (!(co is PlotSettings plot))
										{
											if (!(co is PdfUnderlayDefinition definition2))
											{
												if (!(co is RasterVariables variables))
												{
													if (!(co is Scale scale))
													{
														if (!(co is SpatialFilter filter))
														{
															if (!(co is SortEntitiesTable e))
															{
																if (!(co is XRecord record))
																{
																	throw new NotImplementedException("Object not implemented : " + co.GetType().FullName);
																}
																writeXRecord(record);
															}
															else
															{
																writeSortentsTable(e);
															}
														}
														else
														{
															writeSpatialFilter(filter);
														}
													}
													else
													{
														writeScale(scale);
													}
												}
												else
												{
													writeRasterVariables(variables);
												}
											}
											else
											{
												writePdfUnderlayDefinition(definition2);
											}
										}
										else
										{
											writePlotSettings(plot);
										}
									}
									else
									{
										writeMultiLeaderStyle(style2);
									}
								}
								else
								{
									writeMLineStyle(style);
								}
							}
							else
							{
								writeLayout(layout);
							}
						}
						else
						{
							writeGroup(obj);
						}
					}
					else
					{
						writeGeoData(geodata);
					}
				}
				else
				{
					writeDictionaryVariable(dictvar);
				}
				writeExtendedData(co.ExtendedData);
			}
			else
			{
				writeDictionary(dict);
			}
		}
		else
		{
			writeBookColor(color);
		}
	}

	protected void writePdfUnderlayDefinition(PdfUnderlayDefinition definition)
	{
		DxfClassMap map = DxfClassMap.Create<PlotSettings>();
		_writer.Write(100, "AcDbUnderlayDefinition");
		_writer.Write(1, definition.File, map);
		_writer.Write(2, definition.Page, map);
	}

	protected void writePlotSettings(PlotSettings plot)
	{
		DxfClassMap map = DxfClassMap.Create<PlotSettings>();
		_writer.Write(100, "AcDbPlotSettings");
		_writer.Write(1, plot.PageName, map);
		_writer.Write(2, plot.SystemPrinterName, map);
		_writer.Write(4, plot.PaperSize, map);
		_writer.Write(6, plot.PlotViewName, map);
		_writer.Write(7, plot.StyleSheet, map);
		_writer.Write(40, plot.UnprintableMargin.Left, map);
		_writer.Write(41, plot.UnprintableMargin.Bottom, map);
		_writer.Write(42, plot.UnprintableMargin.Right, map);
		_writer.Write(43, plot.UnprintableMargin.Top, map);
		_writer.Write(44, plot.PaperWidth, map);
		_writer.Write(45, plot.PaperHeight, map);
		_writer.Write(46, plot.PlotOriginX, map);
		_writer.Write(47, plot.PlotOriginY, map);
		_writer.Write(48, plot.WindowLowerLeftX, map);
		_writer.Write(49, plot.WindowLowerLeftY, map);
		_writer.Write(140, plot.WindowUpperLeftX, map);
		_writer.Write(141, plot.WindowUpperLeftY, map);
		_writer.Write(142, plot.NumeratorScale, map);
		_writer.Write(143, plot.DenominatorScale, map);
		_writer.Write(70, (short)plot.Flags, map);
		_writer.Write(72, (short)plot.PaperUnits, map);
		_writer.Write(73, (short)plot.PaperRotation, map);
		_writer.Write(74, (short)plot.PlotType, map);
		_writer.Write(75, plot.ScaledFit, map);
		_writer.Write(76, (short)plot.ShadePlotMode, map);
		_writer.Write(77, (short)plot.ShadePlotResolutionMode, map);
		_writer.Write(78, plot.ShadePlotDPI, map);
		_writer.Write(147, plot.PrintScale, map);
		_writer.Write(148, plot.PaperImageOrigin.X, map);
		_writer.Write(149, plot.PaperImageOrigin.Y, map);
	}

	protected void writeRasterVariables(RasterVariables variables)
	{
		DxfClassMap map = DxfClassMap.Create<RasterVariables>();
		_writer.Write(100, "AcDbRasterVariables");
		_writer.Write(90, variables.ClassVersion, map);
		_writer.Write(70, variables.IsDisplayFrameShown ? 1 : 0, map);
		_writer.Write(71, (short)variables.DisplayQuality, map);
		_writer.Write(72, (short)variables.DisplayQuality, map);
	}

	protected void writeScale(Scale scale)
	{
		_writer.Write(100, "AcDbScale");
		_writer.Write(70, 0);
		_writer.Write(300, scale.Name);
		_writer.Write(140, scale.PaperUnits);
		_writer.Write(141, scale.DrawingUnits);
		_writer.Write(290, scale.IsUnitScale ? ((short)1) : ((short)0));
	}

	protected override void writeSection()
	{
		while (base.Holder.Objects.Any())
		{
			CadObject co = base.Holder.Objects.Dequeue();
			writeObject(co);
		}
	}

	protected void writeXRecord(XRecord record)
	{
		_writer.Write(DxfCode.Subclass, "AcDbXrecord");
		_writer.Write(280, record.CloningFlags);
		foreach (XRecord.Entry entry in record.Entries)
		{
			switch (entry.GroupCode)
			{
			case GroupCodeValueType.Point3D:
				if (entry.Value is IVector value)
				{
					_writer.Write(entry.Code, value);
				}
				else
				{
					_writer.Write(entry.Code, entry.Value);
				}
				break;
			case GroupCodeValueType.Handle:
			case GroupCodeValueType.ObjectId:
			case GroupCodeValueType.ExtendedDataHandle:
			{
				IHandledCadObject handledCadObject = entry.Value as IHandledCadObject;
				_writer.Write(entry.Code, handledCadObject.Handle);
				break;
			}
			default:
				_writer.Write(entry.Code, entry.Value);
				break;
			case GroupCodeValueType.None:
				break;
			}
		}
	}

	private bool isObjectSupported(CadObject co)
	{
		if (!(co is UnknownNonGraphicalObject))
		{
			if (co is AcdbPlaceHolder || co is EvaluationGraph || co is Material || co is MultiLeaderObjectContextData || co is VisualStyle || co is ProxyObject)
			{
				notify("Object not implemented : " + co.GetType().FullName, NotificationType.NotImplemented);
				return false;
			}
			return true;
		}
		return false;
	}

	private void writeImageDefinitionReactor(ImageDefinitionReactor reactor)
	{
		_writer.Write(DxfCode.Subclass, "AcDbRasterImageDefReactor");
		_writer.Write(90, reactor.ClassVersion);
		_writer.WriteHandle(330, reactor.Image);
	}

	private void writeSortentsTable(SortEntitiesTable e)
	{
		_writer.Write(DxfCode.Subclass, "AcDbSortentsTable");
		_writer.WriteHandle(330, e.BlockOwner);
		foreach (SortEntitiesTable.Sorter item in e)
		{
			_writer.WriteHandle(331, item.Entity);
			_writer.Write(5, item.SortHandle);
		}
	}

	private void writeSpatialFilter(SpatialFilter filter)
	{
		DxfClassMap map = DxfClassMap.Create<SpatialFilter>();
		_writer.Write(100, "AcDbFilter");
		_writer.Write(100, "AcDbSpatialFilter");
		_writer.Write(70, (short)filter.BoundaryPoints.Count, map);
		foreach (XY boundaryPoint in filter.BoundaryPoints)
		{
			_writer.Write(10, boundaryPoint, map);
		}
		_writer.Write(210, filter.Normal, map);
		_writer.Write(11, filter.Origin, map);
		_writer.Write(71, filter.DisplayBoundary ? ((short)1) : ((short)0), map);
		_writer.Write(72, filter.ClipFrontPlane ? 1 : 0, map);
		if (filter.ClipFrontPlane)
		{
			_writer.Write(40, filter.FrontDistance, map);
		}
		_writer.Write(73, filter.ClipBackPlane ? 1 : 0, map);
		if (filter.ClipBackPlane)
		{
			_writer.Write(41, filter.BackDistance, map);
		}
		double[] array = new double[24]
		{
			filter.InverseInsertTransform.M00,
			filter.InverseInsertTransform.M01,
			filter.InverseInsertTransform.M02,
			filter.InverseInsertTransform.M03,
			filter.InverseInsertTransform.M10,
			filter.InverseInsertTransform.M11,
			filter.InverseInsertTransform.M12,
			filter.InverseInsertTransform.M13,
			filter.InverseInsertTransform.M20,
			filter.InverseInsertTransform.M21,
			filter.InverseInsertTransform.M22,
			filter.InverseInsertTransform.M23,
			filter.InsertTransform.M00,
			filter.InsertTransform.M01,
			filter.InsertTransform.M02,
			filter.InsertTransform.M03,
			filter.InsertTransform.M10,
			filter.InsertTransform.M11,
			filter.InsertTransform.M12,
			filter.InsertTransform.M13,
			filter.InsertTransform.M20,
			filter.InsertTransform.M21,
			filter.InsertTransform.M22,
			filter.InsertTransform.M23
		};
		for (int i = 0; i < array.Length; i++)
		{
			_writer.Write(40, array[i]);
		}
	}
}
