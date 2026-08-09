using System;
using System.Collections.Generic;
using System.Linq;
using ACadSharp.Entities;
using ACadSharp.Objects;
using ACadSharp.Tables;
using ACadSharp.XData;
using CSMath;

namespace ACadSharp.IO.DXF;

internal abstract class DxfSectionWriterBase
{
	protected IDxfStreamWriter _writer;

	protected CadDocument _document;

	public abstract string SectionName { get; }

	public ACadVersion Version => _document.Header.Version;

	public CadObjectHolder Holder { get; }

	public DxfWriterConfiguration Configuration { get; }

	public event NotificationEventHandler OnNotification;

	public DxfSectionWriterBase(IDxfStreamWriter writer, CadDocument document, CadObjectHolder holder, DxfWriterConfiguration configuration)
	{
		_writer = writer;
		_document = document;
		Holder = holder;
		Configuration = configuration;
	}

	public void Write()
	{
		_writer.Write(DxfCode.Start, "SECTION");
		_writer.Write(DxfCode.ShapeName, SectionName);
		writeSection();
		_writer.Write(DxfCode.Start, "ENDSEC");
	}

	protected void writeCommonObjectData(CadObject cadObject)
	{
		if (cadObject is DimensionStyle)
		{
			_writer.Write(DxfCode.DimVarHandle, cadObject.Handle);
		}
		else
		{
			_writer.Write(DxfCode.Handle, cadObject.Handle);
		}
		if (cadObject.XDictionary != null)
		{
			_writer.Write(DxfCode.ControlString, "{ACAD_XDICTIONARY");
			_writer.Write(DxfCode.HardOwnershipId, cadObject.XDictionary.Handle);
			_writer.Write(DxfCode.ControlString, "}");
			Holder.Objects.Enqueue(cadObject.XDictionary);
		}
		cadObject.CleanReactors();
		if (cadObject.Reactors.Any())
		{
			_writer.Write(DxfCode.ControlString, "{ACAD_REACTORS");
			foreach (CadObject reactor in cadObject.Reactors)
			{
				_writer.Write(DxfCode.SoftPointerId, reactor.Handle);
			}
			_writer.Write(DxfCode.ControlString, "}");
		}
		_writer.Write(DxfCode.SoftPointerId, cadObject.Owner.Handle);
	}

	protected void writeExtendedData(ExtendedDataDictionary xdata)
	{
		if (xdata == null || !Configuration.WriteXData)
		{
			return;
		}
		foreach (KeyValuePair<AppId, ExtendedData> xdatum in xdata)
		{
			_writer.Write(DxfCode.ExtendedDataRegAppName, xdatum.Key.Name);
			foreach (ExtendedDataRecord record in xdatum.Value.Records)
			{
				if (!(record is ExtendedDataBinaryChunk extendedDataBinaryChunk))
				{
					if (!(record is ExtendedDataControlString extendedDataControlString))
					{
						if (!(record is ExtendedDataInteger16 extendedDataInteger))
						{
							if (!(record is ExtendedDataInteger32 extendedDataInteger2))
							{
								if (!(record is ExtendedDataReal extendedDataReal))
								{
									if (!(record is ExtendedDataScale extendedDataScale))
									{
										if (!(record is ExtendedDataDistance extendedDataDistance))
										{
											if (!(record is ExtendedDataDisplacement extendedDataDisplacement))
											{
												if (!(record is ExtendedDataDirection extendedDataDirection))
												{
													if (!(record is ExtendedDataCoordinate extendedDataCoordinate))
													{
														if (!(record is ExtendedDataWorldCoordinate extendedDataWorldCoordinate))
														{
															if (!(record is IExtendedDataHandleReference { Value: var num } extendedDataHandleReference))
															{
																if (!(record is ExtendedDataString extendedDataString))
																{
																	throw new NotSupportedException("ExtendedDataRecord of type " + record.GetType().FullName + " not supported.");
																}
																_writer.Write(extendedDataString.Code, extendedDataString.Value);
															}
															else
															{
																if (extendedDataHandleReference.ResolveReference(_document) == null)
																{
																	num = 0uL;
																}
																_writer.Write(DxfCode.ExtendedDataHandle, num);
															}
														}
														else
														{
															_writer.Write(extendedDataWorldCoordinate.Code, extendedDataWorldCoordinate.Value);
														}
													}
													else
													{
														_writer.Write(extendedDataCoordinate.Code, extendedDataCoordinate.Value);
													}
												}
												else
												{
													_writer.Write(extendedDataDirection.Code, extendedDataDirection.Value);
												}
											}
											else
											{
												_writer.Write(extendedDataDisplacement.Code, extendedDataDisplacement.Value);
											}
										}
										else
										{
											_writer.Write(extendedDataDistance.Code, extendedDataDistance.Value);
										}
									}
									else
									{
										_writer.Write(extendedDataScale.Code, extendedDataScale.Value);
									}
								}
								else
								{
									_writer.Write(extendedDataReal.Code, extendedDataReal.Value);
								}
							}
							else
							{
								_writer.Write(extendedDataInteger2.Code, extendedDataInteger2.Value);
							}
						}
						else
						{
							_writer.Write(extendedDataInteger.Code, extendedDataInteger.Value);
						}
					}
					else
					{
						_writer.Write(extendedDataControlString.Code, extendedDataControlString.Value);
					}
				}
				else
				{
					_writer.Write(extendedDataBinaryChunk.Code, extendedDataBinaryChunk.Value);
				}
			}
		}
	}

	protected void writeCommonEntityData(Entity entity)
	{
		DxfClassMap map = DxfClassMap.Create<Entity>();
		_writer.Write(DxfCode.Subclass, "AcDbEntity");
		_writer.Write(8, entity.Layer.Name);
		_writer.Write(6, entity.LineType.Name);
		if (entity.BookColor != null)
		{
			_writer.Write(62, entity.BookColor.Color.GetApproxIndex());
			_writer.WriteTrueColor(420, entity.BookColor.Color);
			_writer.Write(430, entity.BookColor.Name);
		}
		else if (entity.Color.IsTrueColor)
		{
			_writer.WriteTrueColor(420, entity.Color);
		}
		else
		{
			_writer.Write(62, entity.Color.Index);
		}
		if (entity.Transparency.Value >= 0)
		{
			_writer.Write(440, Transparency.ToAlphaValue(entity.Transparency));
		}
		_writer.Write(48, entity.LineTypeScale, map);
		_writer.Write(60, entity.IsInvisible ? ((short)1) : ((short)0), map);
		_writer.Write(370, entity.LineWeight);
	}

	protected abstract void writeSection();

	protected void writeLongTextValue(int code, int subcode, string text)
	{
		for (int i = 0; i < text.Length - 250; i += 250)
		{
			_writer.Write(subcode, text.Substring(i, 250));
		}
		_writer.Write(code, text);
	}

	protected void notify(string message, NotificationType notificationType = NotificationType.None, Exception ex = null)
	{
		this.OnNotification?.Invoke(this, new NotificationEventArgs(message, notificationType, ex));
	}

	protected void writeEntity<T>(T entity) where T : Entity
	{
		if (!isEntitySupported(entity))
		{
			return;
		}
		_writer.Write(DxfCode.Start, entity.ObjectName);
		writeCommonObjectData(entity);
		writeCommonEntityData(entity);
		if (!(entity is Arc arc))
		{
			if (!(entity is Circle circle))
			{
				if (!(entity is Dimension dim))
				{
					if (!(entity is Ellipse ellipse))
					{
						if (!(entity is Face3D face))
						{
							if (!(entity is Hatch hatch))
							{
								if (!(entity is Insert insert))
								{
									if (!(entity is Leader leader))
									{
										if (!(entity is Line line))
										{
											if (!(entity is LwPolyline polyline))
											{
												if (!(entity is Mesh mesh))
												{
													if (!(entity is MLine mLine))
													{
														if (!(entity is MText mtext))
														{
															if (!(entity is MultiLeader multiLeader))
															{
																if (!(entity is Ole2Frame ole))
																{
																	if (!(entity is PdfUnderlay underlay))
																	{
																		if (!(entity is Point point))
																		{
																			if (!(entity is IPolyline polyline2))
																			{
																				if (!(entity is RasterImage image))
																				{
																					if (!(entity is Ray ray))
																					{
																						if (!(entity is Shape shape))
																						{
																							if (!(entity is Solid solid))
																							{
																								if (!(entity is Spline spline))
																								{
																									if (!(entity is TextEntity text))
																									{
																										if (!(entity is Tolerance tolerance))
																										{
																											if (!(entity is Vertex v))
																											{
																												if (!(entity is Viewport vp))
																												{
																													if (!(entity is Wipeout image2))
																													{
																														if (!(entity is XLine xline))
																														{
																															throw new NotImplementedException("Entity not implemented " + entity.GetType().FullName);
																														}
																														writeXLine(xline);
																													}
																													else
																													{
																														writeCadImage(image2);
																													}
																												}
																												else
																												{
																													writeViewport(vp);
																												}
																											}
																											else
																											{
																												writeVertex(v);
																											}
																										}
																										else
																										{
																											writeTolerance(tolerance);
																										}
																									}
																									else
																									{
																										writeTextEntity(text);
																									}
																								}
																								else
																								{
																									writeSpline(spline);
																								}
																							}
																							else
																							{
																								writeSolid(solid);
																							}
																						}
																						else
																						{
																							writeShape(shape);
																						}
																					}
																					else
																					{
																						writeRay(ray);
																					}
																				}
																				else
																				{
																					writeCadImage(image);
																				}
																			}
																			else if (!(polyline2 is Polyline2D polyline3))
																			{
																				if (!(polyline2 is Polyline3D polyline4))
																				{
																					if (!(polyline2 is PolyfaceMesh polyline5))
																					{
																						throw new NotImplementedException("Polyline not implemented " + polyline2.GetType().FullName);
																					}
																					writePolyline(polyline5);
																				}
																				else
																				{
																					writePolyline(polyline4);
																				}
																			}
																			else
																			{
																				writePolyline(polyline3);
																			}
																		}
																		else
																		{
																			writePoint(point);
																		}
																	}
																	else
																	{
																		writePdfUnderlay<PdfUnderlay, PdfUnderlayDefinition>(underlay);
																	}
																}
																else
																{
																	writeOle2Frame(ole);
																}
															}
															else
															{
																writeMultiLeader(multiLeader);
															}
														}
														else
														{
															writeMText(mtext);
														}
													}
													else
													{
														writeMLine(mLine);
													}
												}
												else
												{
													writeMesh(mesh);
												}
											}
											else
											{
												writeLwPolyline(polyline);
											}
										}
										else
										{
											writeLine(line);
										}
									}
									else
									{
										writeLeader(leader);
									}
								}
								else
								{
									writeInsert(insert);
								}
							}
							else
							{
								writeHatch(hatch);
							}
						}
						else
						{
							writeFace3D(face);
						}
					}
					else
					{
						writeEllipse(ellipse);
					}
				}
				else
				{
					writeDimension(dim);
				}
			}
			else
			{
				writeCircle(circle);
			}
		}
		else
		{
			writeArc(arc);
		}
		writeExtendedData(entity.ExtendedData);
	}

	private bool isEntitySupported(Entity entity)
	{
		if (!(entity is UnknownEntity))
		{
			if (!(entity is Shape))
			{
				if (entity is ProxyEntity || entity is TableEntity || entity is Solid3D || entity is CadBody || entity is Region)
				{
					notify("Entity type not implemented " + entity.GetType().FullName, NotificationType.NotImplemented);
					return false;
				}
				return true;
			}
			return Configuration.WriteShapes;
		}
		return false;
	}

	private void writeArc(Arc arc)
	{
		DxfClassMap map = DxfClassMap.Create<Arc>();
		writeCircle(arc);
		_writer.Write(DxfCode.Subclass, "AcDbArc");
		_writer.Write(50, arc.StartAngle, map);
		_writer.Write(51, arc.EndAngle, map);
	}

	private void writeAttributeBase(AttributeBase att)
	{
		_writer.Write(2, att.Tag);
		_writer.Write(70, (short)att.Flags);
		_writer.Write(73, (short)0);
		if (att.VerticalAlignment != TextVerticalAlignmentType.Baseline)
		{
			_writer.Write(74, (short)att.VerticalAlignment);
		}
		if (Version > ACadVersion.AC1027 && att.AttributeType != AttributeType.SingleLine)
		{
			_writer.Write(71, (short)att.AttributeType);
			_writer.Write(72, (short)0);
			_writer.Write(11, att.AlignmentPoint);
			if (att.MText != null)
			{
				_writer.Write(101, "Embedded Object");
				writeMText(att.MText, writeSubclass: false);
			}
		}
	}

	private void writeBoundaryPath(Hatch.BoundaryPath path)
	{
		_writer.Write(92, (int)path.Flags);
		if (!path.Flags.HasFlag(BoundaryPathFlags.Polyline))
		{
			_writer.Write(93, path.Edges.Count);
		}
		foreach (Hatch.BoundaryPath.Edge edge in path.Edges)
		{
			writeHatchBoundaryPathEdge(edge);
		}
		_writer.Write(97, path.Entities.Count);
		foreach (Entity entity in path.Entities)
		{
			_writer.WriteHandle(330, entity);
		}
	}

	private void writeCadImage<T>(T image) where T : CadWipeoutBase
	{
		DxfClassMap map = DxfClassMap.Create<T>();
		_writer.Write(DxfCode.Subclass, image.SubclassMarker);
		_writer.Write(90, image.ClassVersion, map);
		_writer.Write(10, image.InsertPoint, map);
		_writer.Write(11, image.UVector, map);
		_writer.Write(12, image.VVector, map);
		_writer.Write(13, image.Size, map);
		_writer.WriteHandle(340, image.Definition, map);
		_writer.Write(70, (short)image.Flags, map);
		_writer.Write(280, image.ClippingState, map);
		_writer.Write(281, image.Brightness, map);
		_writer.Write(282, image.Contrast, map);
		_writer.Write(283, image.Fade, map);
		if (image.DefinitionReactor != null)
		{
			_writer.WriteHandle(360, image.DefinitionReactor, map);
			Holder.Objects.Enqueue(image.DefinitionReactor);
		}
		_writer.Write(71, (short)image.ClipType, map);
		if (image.ClipType == ClipType.Polygonal)
		{
			_writer.Write(91, image.ClipBoundaryVertices.Count + 1, map);
			foreach (XY clipBoundaryVertex in image.ClipBoundaryVertices)
			{
				_writer.Write(14, clipBoundaryVertex, map);
			}
			_writer.Write(14, image.ClipBoundaryVertices.First(), map);
			return;
		}
		_writer.Write(91, image.ClipBoundaryVertices.Count, map);
		foreach (XY clipBoundaryVertex2 in image.ClipBoundaryVertices)
		{
			_writer.Write(14, clipBoundaryVertex2, map);
		}
	}

	private void writeCircle(Circle circle)
	{
		DxfClassMap map = DxfClassMap.Create<Circle>();
		_writer.Write(DxfCode.Subclass, "AcDbCircle");
		_writer.Write(10, circle.Center, map);
		_writer.Write(39, circle.Thickness, map);
		_writer.Write(40, circle.Radius, map);
		_writer.Write(210, circle.Normal, map);
	}

	private void writeDimension(Dimension dim)
	{
		DxfClassMap map = DxfClassMap.Create<Dimension>();
		_writer.Write(DxfCode.Subclass, "AcDbDimension");
		_writer.WriteName(2, dim.Block, map);
		_writer.Write(10, dim.DefinitionPoint, map);
		_writer.Write(11, dim.TextMiddlePoint, map);
		_writer.Write(53, dim.TextRotation, map);
		_writer.Write(70, (short)dim.Flags, map);
		_writer.Write(71, (short)dim.AttachmentPoint, map);
		_writer.Write(72, (short)dim.LineSpacingStyle, map);
		_writer.Write(41, dim.LineSpacingFactor, map);
		if (string.IsNullOrEmpty(dim.Text))
		{
			_writer.Write(1, dim.Text, map);
		}
		_writer.Write(210, dim.Normal, map);
		_writer.WriteName(3, dim.Style, map);
		if (!(dim is DimensionAligned aligned))
		{
			if (!(dim is DimensionRadius radius))
			{
				if (!(dim is DimensionDiameter diameter))
				{
					if (!(dim is DimensionAngular2Line angular2Line))
					{
						if (!(dim is DimensionAngular3Pt angular3Pt))
						{
							if (!(dim is DimensionOrdinate ordinate))
							{
								throw new NotImplementedException("Dimension type not implemented " + dim.GetType().FullName);
							}
							writeDimensionOrdinate(ordinate);
						}
						else
						{
							writeDimensionAngular3Pt(angular3Pt);
						}
					}
					else
					{
						writeDimensionAngular2Line(angular2Line);
					}
				}
				else
				{
					writeDimensionDiameter(diameter);
				}
			}
			else
			{
				writeDimensionRadius(radius);
			}
		}
		else
		{
			writeDimensionAligned(aligned);
		}
	}

	private void writeDimensionAligned(DimensionAligned aligned)
	{
		DxfClassMap map = DxfClassMap.Create<DimensionAligned>();
		_writer.Write(DxfCode.Subclass, "AcDbAlignedDimension");
		_writer.Write(13, aligned.FirstPoint, map);
		_writer.Write(14, aligned.SecondPoint, map);
		if (aligned is DimensionLinear linear)
		{
			writeDimensionLinear(linear);
		}
	}

	private void writeDimensionAngular2Line(DimensionAngular2Line angular2Line)
	{
		DxfClassMap map = DxfClassMap.Create<DimensionAngular2Line>();
		_writer.Write(DxfCode.Subclass, "AcDb2LineAngularDimension");
		_writer.Write(13, angular2Line.FirstPoint, map);
		_writer.Write(14, angular2Line.SecondPoint, map);
		_writer.Write(15, angular2Line.AngleVertex, map);
		_writer.Write(16, angular2Line.DimensionArc, map);
	}

	private void writeDimensionAngular3Pt(DimensionAngular3Pt angular3Pt)
	{
		DxfClassMap map = DxfClassMap.Create<DimensionAngular3Pt>();
		_writer.Write(DxfCode.Subclass, "AcDb3PointAngularDimension");
		_writer.Write(13, angular3Pt.FirstPoint, map);
		_writer.Write(14, angular3Pt.SecondPoint, map);
		_writer.Write(15, angular3Pt.AngleVertex, map);
	}

	private void writeDimensionDiameter(DimensionDiameter diameter)
	{
		DxfClassMap map = DxfClassMap.Create<DimensionDiameter>();
		_writer.Write(DxfCode.Subclass, "AcDbDiametricDimension");
		_writer.Write(15, diameter.AngleVertex, map);
		_writer.Write(40, diameter.LeaderLength, map);
	}

	private void writeDimensionLinear(DimensionLinear linear)
	{
		DxfClassMap map = DxfClassMap.Create<DimensionLinear>();
		_writer.Write(50, linear.Rotation, map);
		_writer.Write(DxfCode.Subclass, "AcDbRotatedDimension");
	}

	private void writeDimensionOrdinate(DimensionOrdinate ordinate)
	{
		DxfClassMap map = DxfClassMap.Create<DimensionOrdinate>();
		_writer.Write(DxfCode.Subclass, "AcDbOrdinateDimension");
		_writer.Write(13, ordinate.FeatureLocation, map);
		_writer.Write(14, ordinate.LeaderEndpoint, map);
	}

	private void writeDimensionRadius(DimensionRadius radius)
	{
		DxfClassMap map = DxfClassMap.Create<DimensionRadius>();
		_writer.Write(DxfCode.Subclass, "AcDbRadialDimension");
		_writer.Write(15, radius.AngleVertex, map);
		_writer.Write(40, radius.LeaderLength, map);
	}

	private void writeEllipse(Ellipse ellipse)
	{
		DxfClassMap map = DxfClassMap.Create<Ellipse>();
		_writer.Write(DxfCode.Subclass, "AcDbEllipse");
		_writer.Write(10, ellipse.Center, map);
		_writer.Write(11, ellipse.MajorAxisEndPoint, map);
		_writer.Write(210, ellipse.Normal, map);
		_writer.Write(39, ellipse.Thickness, map);
		_writer.Write(40, ellipse.RadiusRatio, map);
		_writer.Write(41, ellipse.StartParameter, map);
		_writer.Write(42, ellipse.EndParameter, map);
	}

	private void writeFace3D(Face3D face)
	{
		DxfClassMap map = DxfClassMap.Create<Face3D>();
		_writer.Write(DxfCode.Subclass, "AcDbFace");
		_writer.Write(10, face.FirstCorner, map);
		_writer.Write(11, face.SecondCorner, map);
		_writer.Write(12, face.ThirdCorner, map);
		_writer.Write(13, face.FourthCorner, map);
		_writer.Write(70, (short)face.Flags, map);
	}

	private void writeHatch(Hatch hatch)
	{
		DxfClassMap map = DxfClassMap.Create<Hatch>();
		_writer.Write(DxfCode.Subclass, "AcDbHatch");
		_writer.Write(10, 0, map);
		_writer.Write(20, 0, map);
		_writer.Write(30, hatch.Elevation, map);
		_writer.Write(210, hatch.Normal, map);
		_writer.Write(2, hatch.Pattern.Name, map);
		_writer.Write(70, hatch.IsSolid ? ((short)1) : ((short)0), map);
		_writer.Write(71, hatch.IsAssociative ? ((short)1) : ((short)0), map);
		_writer.Write(91, hatch.Paths.Count, map);
		foreach (Hatch.BoundaryPath path in hatch.Paths)
		{
			writeBoundaryPath(path);
		}
		writeHatchPattern(hatch, hatch.Pattern);
		if (hatch.PixelSize != 0.0)
		{
			_writer.Write(47, hatch.PixelSize, map);
		}
		_writer.Write(98, hatch.SeedPoints.Count);
		foreach (XY seedPoint in hatch.SeedPoints)
		{
			_writer.Write(10, seedPoint);
		}
	}

	private void writeHatchBoundaryPathEdge(Hatch.BoundaryPath.Edge edge)
	{
		if (!(edge is Hatch.BoundaryPath.Polyline))
		{
			_writer.Write(72, edge.Type);
		}
		if (!(edge is Hatch.BoundaryPath.Arc arc))
		{
			if (!(edge is Hatch.BoundaryPath.Ellipse ellipse))
			{
				if (!(edge is Hatch.BoundaryPath.Line line))
				{
					if (!(edge is Hatch.BoundaryPath.Polyline polyline))
					{
						if (edge is Hatch.BoundaryPath.Spline spline)
						{
							_writer.Write(73, spline.Rational ? ((short)1) : ((short)0));
							_writer.Write(74, spline.Periodic ? ((short)1) : ((short)0));
							_writer.Write(94, spline.Degree);
							_writer.Write(95, spline.Knots.Count);
							_writer.Write(96, spline.ControlPoints.Count);
							foreach (double knot in spline.Knots)
							{
								_writer.Write(40, knot);
							}
							{
								foreach (XYZ controlPoint in spline.ControlPoints)
								{
									_writer.Write(10, controlPoint.X);
									_writer.Write(20, controlPoint.Y);
									if (spline.Rational)
									{
										_writer.Write(42, controlPoint.Z);
									}
								}
								return;
							}
						}
						throw new ArgumentException("Unknown Hatch.BoundaryPath.Edge type " + edge.GetType().FullName);
					}
					_writer.Write(72, polyline.HasBulge ? ((short)1) : ((short)0));
					_writer.Write(73, polyline.IsClosed ? ((short)1) : ((short)0));
					_writer.Write(93, polyline.Vertices.Count);
					for (int i = 0; i < polyline.Vertices.Count; i++)
					{
						_writer.Write(10, (XY)polyline.Vertices[i]);
						if (polyline.HasBulge)
						{
							_writer.Write(42, polyline.Bulges.ElementAtOrDefault(i));
						}
					}
				}
				else
				{
					_writer.Write(10, line.Start);
					_writer.Write(11, line.End);
				}
			}
			else
			{
				_writer.Write(10, ellipse.Center);
				_writer.Write(11, ellipse.MajorAxisEndPoint);
				_writer.Write(40, ellipse.MinorToMajorRatio);
				_writer.Write(50, ellipse.StartAngle);
				_writer.Write(51, ellipse.EndAngle);
				_writer.Write(73, ellipse.CounterClockWise ? ((short)1) : ((short)0));
			}
		}
		else
		{
			_writer.Write(10, arc.Center);
			_writer.Write(40, arc.Radius);
			_writer.Write(50, arc.StartAngle);
			_writer.Write(51, arc.EndAngle);
			_writer.Write(73, arc.CounterClockWise ? ((short)1) : ((short)0));
		}
	}

	private void writeHatchPattern(Hatch hatch, HatchPattern pattern)
	{
		_writer.Write(75, (short)hatch.Style);
		_writer.Write(76, (short)hatch.PatternType);
		if (hatch.IsSolid)
		{
			return;
		}
		_writer.Write(52, MathHelper.RadToDeg(hatch.PatternAngle));
		_writer.Write(41, hatch.PatternScale);
		_writer.Write(77, hatch.IsDouble ? ((short)1) : ((short)0));
		_writer.Write(78, (short)pattern.Lines.Count);
		foreach (HatchPattern.Line line in pattern.Lines)
		{
			_writer.Write(53, MathHelper.RadToDeg(line.Angle));
			_writer.Write(43, line.BasePoint.X);
			_writer.Write(44, line.BasePoint.Y);
			_writer.Write(45, line.Offset.X);
			_writer.Write(46, line.Offset.Y);
			_writer.Write(79, (short)line.DashLengths.Count);
			foreach (double dashLength in line.DashLengths)
			{
				_writer.Write(49, dashLength);
			}
		}
	}

	private void writeInsert(Insert insert)
	{
		DxfClassMap map = DxfClassMap.Create<Insert>();
		_writer.Write(DxfCode.Subclass, insert.SubclassMarker);
		_writer.WriteName(2, insert.Block, map);
		_writer.Write(10, insert.InsertPoint, map);
		_writer.Write(41, insert.XScale, map);
		_writer.Write(42, insert.YScale, map);
		_writer.Write(43, insert.ZScale, map);
		_writer.Write(50, insert.Rotation, map);
		_writer.Write(70, (short)insert.ColumnCount);
		_writer.Write(71, (short)insert.RowCount);
		_writer.Write(44, insert.ColumnSpacing);
		_writer.Write(45, insert.RowSpacing);
		_writer.Write(210, insert.Normal, map);
		if (!insert.HasAttributes)
		{
			return;
		}
		_writer.Write(66, 1);
		foreach (AttributeEntity attribute in insert.Attributes)
		{
			writeEntity(attribute);
		}
		writeSeqend(insert.Attributes.Seqend);
	}

	private void writeLeader(Leader leader)
	{
		DxfClassMap map = DxfClassMap.Create<Leader>();
		_writer.Write(DxfCode.Subclass, "AcDbLeader");
		_writer.WriteName(3, leader.Style, map);
		_writer.Write(71, leader.ArrowHeadEnabled ? ((short)1) : ((short)0), map);
		_writer.Write(72, (short)leader.PathType, map);
		_writer.Write(73, (short)leader.CreationType, map);
		_writer.Write(74, (leader.HookLineDirection == HookLineDirection.Same) ? ((short)1) : ((short)0), map);
		_writer.Write(75, leader.HasHookline ? ((short)1) : ((short)0), map);
		_writer.Write(40, leader.TextHeight, map);
		_writer.Write(41, leader.TextWidth, map);
		_writer.Write(76, leader.Vertices.Count, map);
		foreach (XYZ vertex in leader.Vertices)
		{
			_writer.Write(10, vertex, map);
		}
		_writer.Write(210, leader.Normal, map);
		_writer.Write(211, leader.HorizontalDirection, map);
		_writer.Write(212, leader.BlockOffset, map);
		_writer.Write(213, leader.AnnotationOffset, map);
	}

	private void writeLeaderLine(MultiLeaderObjectContextData.LeaderLine leaderLine)
	{
		_writer.Write(304, "LEADER_LINE{");
		foreach (XYZ point in leaderLine.Points)
		{
			_writer.Write(10, point);
		}
		_writer.Write(91, leaderLine.Index);
		_writer.Write(305, "}");
	}

	private void writeLeaderRoot(MultiLeaderObjectContextData.LeaderRoot leaderRoot)
	{
		_writer.Write(302, "LEADER{");
		_writer.Write(290, (short)1);
		_writer.Write(291, (short)1);
		_writer.Write(10, leaderRoot.ConnectionPoint);
		_writer.Write(11, leaderRoot.Direction);
		_writer.Write(90, leaderRoot.LeaderIndex);
		_writer.Write(40, leaderRoot.LandingDistance);
		foreach (MultiLeaderObjectContextData.LeaderLine line in leaderRoot.Lines)
		{
			writeLeaderLine(line);
		}
		_writer.Write(271, 0);
		_writer.Write(303, "}");
	}

	private void writeLine(Line line)
	{
		DxfClassMap map = DxfClassMap.Create<Line>();
		_writer.Write(DxfCode.Subclass, "AcDbLine");
		_writer.Write(10, line.StartPoint, map);
		_writer.Write(11, line.EndPoint, map);
		_writer.Write(39, line.Thickness, map);
		_writer.Write(210, line.Normal, map);
	}

	private void writeLwPolyline(LwPolyline polyline)
	{
		DxfClassMap map = DxfClassMap.Create<LwPolyline>();
		_writer.Write(DxfCode.Subclass, "AcDbPolyline");
		_writer.Write(90, polyline.Vertices.Count);
		_writer.Write(70, (short)polyline.Flags);
		_writer.Write(38, polyline.Elevation);
		_writer.Write(39, polyline.Thickness);
		foreach (LwPolyline.Vertex vertex in polyline.Vertices)
		{
			_writer.Write(10, vertex.Location);
			_writer.Write(40, vertex.StartWidth);
			_writer.Write(41, vertex.EndWidth);
			_writer.Write(42, vertex.Bulge);
		}
		_writer.Write(210, polyline.Normal, map);
	}

	private void writeMesh(Mesh mesh)
	{
		DxfClassMap map = DxfClassMap.Create<Mesh>();
		_writer.Write(DxfCode.Subclass, "AcDbSubDMesh");
		_writer.Write(71, mesh.Version, map);
		_writer.Write(72, mesh.BlendCrease ? ((short)1) : ((short)0), map);
		_writer.Write(91, mesh.SubdivisionLevel, map);
		_writer.Write(92, mesh.Vertices.Count, map);
		foreach (XYZ vertex in mesh.Vertices)
		{
			_writer.Write(10, vertex, map);
		}
		int count = mesh.Faces.Count;
		count += mesh.Faces.Sum((int[] f) => f.Length);
		_writer.Write(93, count);
		foreach (int[] face in mesh.Faces)
		{
			_writer.Write(90, face.Length);
			int[] array = face;
			foreach (int num2 in array)
			{
				_writer.Write(90, num2);
			}
		}
		_writer.Write(94, mesh.Edges.Count, map);
		foreach (Mesh.Edge edge in mesh.Edges)
		{
			_writer.Write(90, edge.Start);
			_writer.Write(90, edge.End);
		}
		_writer.Write(95, mesh.Edges.Count, map);
		foreach (Mesh.Edge edge2 in mesh.Edges)
		{
			_writer.Write(140, edge2.Crease);
		}
		_writer.Write(90, 0);
	}

	private void writeMLine(MLine mLine)
	{
		DxfClassMap map = DxfClassMap.Create<MLine>();
		_writer.Write(DxfCode.Subclass, "AcDbMline");
		_writer.WriteName(2, mLine.Style, map);
		_writer.WriteHandle(340, mLine.Style, map);
		_writer.Write(40, mLine.ScaleFactor);
		_writer.Write(70, (short)mLine.Justification);
		_writer.Write(71, (short)mLine.Flags);
		_writer.Write(72, (short)mLine.Vertices.Count);
		if (mLine.Style != null)
		{
			_writer.Write(73, (short)mLine.Style.Elements.Count());
		}
		_writer.Write(10, mLine.StartPoint, map);
		_writer.Write(210, mLine.Normal);
		foreach (MLine.Vertex vertex in mLine.Vertices)
		{
			_writer.Write(11, vertex.Position, map);
			_writer.Write(12, vertex.Direction, map);
			_writer.Write(13, vertex.Miter, map);
			foreach (MLine.Vertex.Segment segment in vertex.Segments)
			{
				_writer.Write(74, (short)segment.Parameters.Count);
				foreach (double parameter in segment.Parameters)
				{
					_writer.Write(41, parameter);
				}
				_writer.Write(75, (short)segment.AreaFillParameters.Count);
				foreach (double areaFillParameter in segment.AreaFillParameters)
				{
					_writer.Write(42, areaFillParameter);
				}
			}
		}
	}

	private void writeMText(MText mtext, bool writeSubclass = true)
	{
		DxfClassMap map = DxfClassMap.Create<MText>();
		if (writeSubclass)
		{
			_writer.Write(DxfCode.Subclass, "AcDbMText");
		}
		_writer.Write(10, mtext.InsertPoint, map);
		_writer.Write(40, mtext.Height, map);
		_writer.Write(41, mtext.RectangleWidth, map);
		_writer.Write(44, mtext.LineSpacing, map);
		if (Version >= ACadVersion.AC1021)
		{
			_writer.Write(46, mtext.RectangleHeight, map);
		}
		_writer.Write(71, (short)mtext.AttachmentPoint, map);
		_writer.Write(72, (short)mtext.DrawingDirection, map);
		writeLongTextValue(1, 3, mtext.Value);
		_writer.WriteName(7, mtext.Style);
		_writer.Write(73, (short)mtext.LineSpacingStyle, map);
		_writer.Write(11, mtext.AlignmentPoint, map);
		_writer.Write(210, mtext.Normal, map);
	}

	private void writeMultiLeader(MultiLeader multiLeader)
	{
		MultiLeaderObjectContextData contextData = multiLeader.ContextData;
		_writer.Write(100, "AcDbMLeader");
		_writer.Write(270, 2);
		writeMultiLeaderAnnotContext(contextData);
		_writer.WriteHandle(340, multiLeader.Style);
		_writer.Write(90, multiLeader.PropertyOverrideFlags);
		_writer.Write(170, (short)multiLeader.PathType);
		_writer.WriteCmColor(91, multiLeader.LineColor);
		_writer.WriteHandle(341, multiLeader.LineType);
		_writer.Write(171, (short)multiLeader.LeaderLineWeight);
		_writer.Write(290, multiLeader.EnableLanding);
		_writer.Write(291, multiLeader.EnableDogleg);
		_writer.Write(41, multiLeader.LandingDistance);
		_writer.Write(42, multiLeader.ArrowheadSize);
		_writer.Write(172, (short)multiLeader.ContentType);
		_writer.WriteHandle(343, multiLeader.TextStyle);
		_writer.Write(173, (short)multiLeader.TextLeftAttachment);
		_writer.Write(95, (short)multiLeader.TextRightAttachment);
		_writer.Write(174, (short)multiLeader.TextAngle);
		_writer.Write(175, (short)multiLeader.TextAlignment);
		_writer.WriteCmColor(92, multiLeader.TextColor);
		_writer.Write(292, multiLeader.TextFrame);
		_writer.WriteCmColor(93, multiLeader.BlockContentColor);
		_writer.Write(10, multiLeader.BlockContentScale);
		_writer.Write(43, multiLeader.BlockContentRotation);
		_writer.Write(176, (short)multiLeader.BlockContentConnection);
		_writer.Write(293, multiLeader.EnableAnnotationScale);
		_writer.Write(294, multiLeader.TextDirectionNegative);
		_writer.Write(178, multiLeader.TextAligninIPE);
		_writer.Write(179, multiLeader.TextAttachmentPoint);
		_writer.Write(45, multiLeader.ScaleFactor);
		_writer.Write(271, multiLeader.TextAttachmentDirection);
		_writer.Write(272, multiLeader.TextBottomAttachment);
		_writer.Write(273, multiLeader.TextTopAttachment);
		_writer.Write(295, 0);
	}

	private void writeMultiLeaderAnnotContext(MultiLeaderObjectContextData contextData)
	{
		_writer.Write(300, "CONTEXT_DATA{");
		_writer.Write(40, contextData.ScaleFactor);
		_writer.Write(10, contextData.ContentBasePoint);
		_writer.Write(41, contextData.TextHeight);
		_writer.Write(140, contextData.ArrowheadSize);
		_writer.Write(145, contextData.LandingGap);
		_writer.Write(174, (short)contextData.TextLeftAttachment);
		_writer.Write(175, (short)contextData.TextRightAttachment);
		_writer.Write(176, (short)contextData.TextAlignment);
		_writer.Write(177, (short)contextData.BlockContentConnection);
		_writer.Write(290, contextData.HasTextContents);
		_writer.Write(304, contextData.TextLabel);
		_writer.Write(11, contextData.TextNormal);
		_writer.WriteHandle(340, contextData.TextStyle);
		_writer.Write(12, contextData.TextLocation);
		_writer.Write(13, contextData.Direction);
		_writer.Write(42, contextData.TextRotation);
		_writer.Write(43, contextData.BoundaryWidth);
		_writer.Write(44, contextData.BoundaryHeight);
		_writer.Write(45, contextData.LineSpacingFactor);
		_writer.Write(170, (short)contextData.LineSpacing);
		_writer.WriteCmColor(90, contextData.TextColor);
		_writer.Write(171, (short)contextData.TextAttachmentPoint);
		_writer.Write(172, (short)contextData.FlowDirection);
		_writer.WriteCmColor(91, contextData.BackgroundFillColor);
		_writer.Write(141, contextData.BackgroundScaleFactor);
		_writer.Write(92, contextData.BackgroundTransparency);
		_writer.Write(291, contextData.BackgroundFillEnabled);
		_writer.Write(292, contextData.BackgroundMaskFillOn);
		_writer.Write(173, contextData.ColumnType);
		_writer.Write(293, contextData.TextHeightAutomatic);
		_writer.Write(142, contextData.ColumnWidth);
		_writer.Write(143, contextData.ColumnGutter);
		_writer.Write(294, contextData.ColumnFlowReversed);
		_writer.Write(295, contextData.WordBreak);
		_writer.Write(296, contextData.HasContentsBlock);
		_writer.Write(110, contextData.BasePoint);
		_writer.Write(111, contextData.BaseDirection);
		_writer.Write(112, contextData.BaseVertical);
		_writer.Write(297, contextData.NormalReversed);
		foreach (MultiLeaderObjectContextData.LeaderRoot leaderRoot in contextData.LeaderRoots)
		{
			writeLeaderRoot(leaderRoot);
		}
		_writer.Write(272, (short)contextData.TextBottomAttachment);
		_writer.Write(273, (short)contextData.TextTopAttachment);
		_writer.Write(301, "}");
	}

	private void writePdfUnderlay<T, R>(T underlay) where T : UnderlayEntity<R> where R : UnderlayDefinition
	{
		DxfClassMap map = DxfClassMap.Create<T>();
		_writer.Write(DxfCode.Subclass, "AcDbUnderlayReference");
		_writer.WriteHandle(340, underlay.Definition, map);
		_writer.Write(10, underlay.InsertPoint, map);
		_writer.Write(280, underlay.Flags, map);
		_writer.Write(281, underlay.Contrast, map);
		_writer.Write(282, underlay.Fade, map);
		foreach (XY clipBoundaryVertex in underlay.ClipBoundaryVertices)
		{
			_writer.Write(11, clipBoundaryVertex, map);
		}
	}

	private void writeOle2Frame(Ole2Frame ole)
	{
		DxfClassMap map = DxfClassMap.Create<Ole2Frame>();
		_writer.Write(DxfCode.Subclass, "AcDbOle2Frame");
		_writer.Write(70, ole.Version, map);
		_writer.Write(3, ole.SourceApplication, map);
		_writer.Write(10, ole.UpperLeftCorner, map);
		_writer.Write(11, ole.LowerRightCorner, map);
		_writer.Write(71, ole.OleObjectType, map);
		_writer.Write(72, ole.IsPaperSpace, map);
		_writer.Write(73, 3, map);
		_writer.Write(90, ole.BinaryData.Length, map);
		_writer.Write(310, ole.BinaryData, map);
		_writer.Write(1, "OLE");
	}

	private void writePoint(Point point)
	{
		DxfClassMap map = DxfClassMap.Create<Point>();
		_writer.Write(DxfCode.Subclass, "AcDbPoint");
		_writer.Write(10, point.Location, map);
		_writer.Write(39, point.Thickness, map);
		_writer.Write(210, point.Normal, map);
		_writer.Write(50, point.Rotation, map);
	}

	private void writePolyline<T>(Polyline<T> polyline) where T : Entity, IVertex
	{
		DxfClassMap map;
		if (!(polyline is Polyline2D))
		{
			if (!(polyline is Polyline3D))
			{
				if (!(polyline is PolyfaceMesh))
				{
					throw new NotImplementedException("Polyline not implemented " + polyline.GetType().FullName);
				}
				map = DxfClassMap.Create<PolyfaceMesh>();
			}
			else
			{
				map = DxfClassMap.Create<Polyline3D>();
			}
		}
		else
		{
			map = DxfClassMap.Create<Polyline2D>();
		}
		_writer.Write(DxfCode.Subclass, polyline.SubclassMarker);
		_writer.Write(DxfCode.XCoordinate, 0);
		_writer.Write(DxfCode.YCoordinate, 0);
		_writer.Write(DxfCode.ZCoordinate, polyline.Elevation);
		_writer.Write(70, (short)polyline.Flags, map);
		_writer.Write(75, (short)polyline.SmoothSurface, map);
		_writer.Write(210, polyline.Normal, map);
		if (!polyline.Vertices.Any())
		{
			return;
		}
		foreach (T vertex in polyline.Vertices)
		{
			writeEntity(vertex);
		}
		writeSeqend(polyline.Vertices.Seqend);
	}

	private void writeRay(Ray ray)
	{
		DxfClassMap map = DxfClassMap.Create<Ray>();
		_writer.Write(DxfCode.Subclass, "AcDbRay");
		_writer.Write(10, ray.StartPoint, map);
		_writer.Write(11, ray.Direction, map);
	}

	private void writeSeqend(Seqend seqend)
	{
		_writer.Write(0, seqend.ObjectName);
		_writer.Write(5, seqend.Handle);
		_writer.Write(330, seqend.Owner.Handle);
		_writer.Write(DxfCode.Subclass, "AcDbEntity");
		_writer.Write(8, seqend.Layer.Name);
	}

	private void writeShape(Shape shape)
	{
		DxfClassMap map = DxfClassMap.Create<Shape>();
		_writer.Write(DxfCode.Subclass, "AcDbShape");
		_writer.Write(39, shape.Thickness, map);
		_writer.Write(10, shape.InsertionPoint, map);
		_writer.Write(40, shape.Size, map);
		_writer.WriteName(2, shape.ShapeStyle, map);
		_writer.Write(50, shape.Rotation, map);
		_writer.Write(41, shape.RelativeXScale, map);
		_writer.Write(51, shape.ObliqueAngle, map);
		_writer.Write(210, shape.Normal, map);
	}

	private void writeSolid(Solid solid)
	{
		DxfClassMap map = DxfClassMap.Create<Solid>();
		_writer.Write(DxfCode.Subclass, "AcDbTrace");
		_writer.Write(10, solid.FirstCorner, map);
		_writer.Write(11, solid.SecondCorner, map);
		_writer.Write(12, solid.ThirdCorner, map);
		_writer.Write(13, solid.FourthCorner, map);
		_writer.Write(39, solid.Thickness, map);
		_writer.Write(210, solid.Normal, map);
	}

	private void writeSpline(Spline spline)
	{
		DxfClassMap map = DxfClassMap.Create<Spline>();
		_writer.Write(DxfCode.Subclass, "AcDbSpline");
		if (spline.Flags.HasFlag(SplineFlags.Planar))
		{
			_writer.Write(210, spline.Normal, map);
		}
		_writer.Write(70, (short)spline.Flags, map);
		_writer.Write(71, (short)spline.Degree, map);
		_writer.Write(72, (short)spline.Knots.Count, map);
		_writer.Write(73, (short)spline.ControlPoints.Count, map);
		if (spline.FitPoints.Any())
		{
			_writer.Write(74, (short)spline.FitPoints.Count, map);
		}
		_writer.Write(42, spline.KnotTolerance, map);
		_writer.Write(43, spline.ControlPointTolerance, map);
		_writer.Write(44, spline.FitTolerance, map);
		if (!spline.StartTangent.IsZero())
		{
			_writer.Write(12, spline.StartTangent, map);
		}
		if (!spline.EndTangent.IsZero())
		{
			_writer.Write(13, spline.EndTangent, map);
		}
		foreach (double knot in spline.Knots)
		{
			_writer.Write(40, knot, map);
		}
		foreach (double weight in spline.Weights)
		{
			_writer.Write(41, weight, map);
		}
		foreach (XYZ controlPoint in spline.ControlPoints)
		{
			_writer.Write(10, controlPoint, map);
		}
		foreach (XYZ fitPoint in spline.FitPoints)
		{
			_writer.Write(11, fitPoint, map);
		}
	}

	private void writeTextEntity(TextEntity text)
	{
		DxfClassMap map = DxfClassMap.Create<TextEntity>();
		_writer.Write(DxfCode.Subclass, "AcDbText");
		_writer.Write(1, text.Value, map);
		_writer.Write(10, text.InsertPoint, map);
		_writer.Write(40, text.Height, map);
		if (text.WidthFactor != 1.0)
		{
			_writer.Write(41, text.WidthFactor, map);
		}
		if (text.Rotation != 0.0)
		{
			_writer.Write(50, text.Rotation, map);
		}
		if (text.ObliqueAngle != 0.0)
		{
			_writer.Write(51, text.ObliqueAngle, map);
		}
		_writer.Write(7, text.Style.Name);
		_writer.Write(11, text.AlignmentPoint, map);
		_writer.Write(210, text.Normal, map);
		if (text.Mirror != TextMirrorFlag.None)
		{
			_writer.Write(71, text.Mirror, map);
		}
		if (text.HorizontalAlignment != TextHorizontalAlignment.Left)
		{
			_writer.Write(72, text.HorizontalAlignment, map);
		}
		if (text.GetType() == typeof(TextEntity))
		{
			_writer.Write(DxfCode.Subclass, "AcDbText");
			if (text.VerticalAlignment != TextVerticalAlignmentType.Baseline)
			{
				_writer.Write(73, text.VerticalAlignment, map);
			}
		}
		if (!(text is AttributeBase))
		{
			return;
		}
		if (!(text is AttributeEntity att))
		{
			if (!(text is AttributeDefinition attributeDefinition))
			{
				throw new ArgumentException("Unknown AttributeBase type " + text.GetType().FullName);
			}
			_writer.Write(DxfCode.Subclass, "AcDbAttributeDefinition");
			_writer.Write(3, attributeDefinition.Prompt, DxfClassMap.Create<AttributeDefinition>());
			writeAttributeBase(attributeDefinition);
		}
		else
		{
			_writer.Write(DxfCode.Subclass, "AcDbAttribute");
			writeAttributeBase(att);
		}
	}

	private void writeTolerance(Tolerance tolerance)
	{
		DxfClassMap map = DxfClassMap.Create<Tolerance>();
		_writer.Write(DxfCode.Subclass, tolerance.SubclassMarker);
		_writer.WriteName(3, tolerance.Style, map);
		_writer.Write(10, tolerance.InsertionPoint, map);
		_writer.Write(11, tolerance.Direction, map);
		_writer.Write(210, tolerance.Normal, map);
		_writer.Write(1, tolerance.Text, map);
	}

	private void writeVertex(Vertex v)
	{
		DxfClassMap map = DxfClassMap.Create<Vertex>();
		_writer.Write(DxfCode.Subclass, "AcDbVertex");
		_writer.Write(DxfCode.Subclass, v.SubclassMarker);
		_writer.Write(10, v.Location, map);
		_writer.Write(40, v.StartWidth, map);
		_writer.Write(41, v.EndWidth, map);
		_writer.Write(42, v.Bulge, map);
		_writer.Write(70, v.Flags, map);
		_writer.Write(50, v.CurveTangent, map);
	}

	private void writeViewport(Viewport vp)
	{
		DxfClassMap map = DxfClassMap.Create<Viewport>();
		_writer.Write(DxfCode.Subclass, "AcDbViewport");
		_writer.Write(10, vp.Center, map);
		_writer.Write(40, vp.Width, map);
		_writer.Write(41, vp.Height, map);
		_writer.Write(69, vp.Id, map);
		_writer.Write(12, vp.ViewCenter, map);
		_writer.Write(13, vp.SnapBase, map);
		_writer.Write(14, vp.SnapSpacing, map);
		_writer.Write(15, vp.GridSpacing, map);
		_writer.Write(16, vp.ViewDirection, map);
		_writer.Write(17, vp.ViewTarget, map);
		_writer.Write(42, vp.LensLength, map);
		_writer.Write(43, vp.FrontClipPlane, map);
		_writer.Write(44, vp.BackClipPlane, map);
		_writer.Write(45, vp.ViewHeight, map);
		_writer.Write(50, vp.SnapAngle, map);
		_writer.Write(51, vp.TwistAngle, map);
		_writer.Write(72, vp.CircleZoomPercent, map);
		foreach (Layer frozenLayer in vp.FrozenLayers)
		{
			_writer.Write(331, frozenLayer.Handle, map);
		}
		_writer.Write(90, (int)vp.Status, map);
		if (vp.Boundary != null)
		{
			_writer.Write(340, vp.Boundary.Handle, map);
		}
		_writer.Write(110, vp.UcsOrigin, map);
		_writer.Write(111, vp.UcsXAxis, map);
		_writer.Write(112, vp.UcsYAxis, map);
	}

	private void writeXLine(XLine xline)
	{
		DxfClassMap map = DxfClassMap.Create<XLine>();
		_writer.Write(DxfCode.Subclass, "AcDbXline");
		_writer.Write(10, xline.FirstPoint, map);
		_writer.Write(11, xline.Direction, map);
	}
}
