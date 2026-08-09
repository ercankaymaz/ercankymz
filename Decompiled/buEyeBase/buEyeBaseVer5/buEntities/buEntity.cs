using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using buClass;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;

namespace buEyeBaseVer5.buEntities;

[Serializable]
public class buEntity : buSerilization5
{
	public Point3D BoxMax = new Point3D();

	public Point3D BoxMin = new Point3D();

	public Point3D StartPoint = new Point3D();

	public Point3D MiddlePoint = new Point3D();

	public Point3D EndPoint = new Point3D();

	public EntityShapeInfo Shape = null;

	public EntityInfo Info = new EntityInfo();

	public CutterInfo Cutter = null;

	public SewingInfo Sewing = null;

	public MarbleInfo Marble = null;

	public DimensionInfo Dimension = null;

	public entitySortDirection sortDirection = entitySortDirection.Normal;

	public entityTypeDefination typeDefination = entityTypeDefination.None;

	public OrientationAngle Orientation = new OrientationAngle();

	public string ToolName = "";

	public string LayerName = "";

	public int LayerIndex = 0;

	public Color Color = Color.Black;

	public double Thickness = 1.0;

	public List<Point3D> Vertices = new List<Point3D>();

	public void Regen(double Deviation = 0.01)
	{
		bool flag = false;
		if (this == null)
		{
			return;
		}
		Entity copiedEntity = null;
		Copy(this, ref copiedEntity);
		if (copiedEntity is Text || copiedEntity is Dimension)
		{
			flag = true;
		}
		if (!flag)
		{
			copiedEntity.Regen(Deviation);
			BoxMin = new Point3D(copiedEntity.BoxMin.X, copiedEntity.BoxMin.Y, copiedEntity.BoxMin.Z);
			BoxMax = new Point3D(copiedEntity.BoxMax.X, copiedEntity.BoxMax.Y, copiedEntity.BoxMax.Z);
			Vertices.Clear();
			for (int i = 0; i <= copiedEntity.Vertices.Length - 1; i++)
			{
				Vertices.Add(new Point3D(copiedEntity.Vertices[i].X, copiedEntity.Vertices[i].Y, copiedEntity.Vertices[i].Z));
			}
		}
	}

	public void Regen(Entity refEntity, double Deviation = 0.01)
	{
		bool flag = false;
		if (refEntity is Text || refEntity is Dimension)
		{
			flag = true;
		}
		if (flag)
		{
			if (buVector5.baseModel != null && refEntity is Text)
			{
				Text text = refEntity as Text;
				if (buVector5.baseModel.TextStyles.Count > 0 && buVector5.baseModel.TextStyles[0].Name == text.StyleName)
				{
					((Text)refEntity).Regen(new RegenParams(Deviation, buVector5.baseModel));
				}
			}
			return;
		}
		refEntity.Regen(Deviation);
		BoxMin = new Point3D(refEntity.BoxMin.X, refEntity.BoxMin.Y, refEntity.BoxMin.Z);
		BoxMax = new Point3D(refEntity.BoxMax.X, refEntity.BoxMax.Y, refEntity.BoxMax.Z);
		Vertices.Clear();
		for (int i = 0; i <= refEntity.Vertices.Length - 1; i++)
		{
			Vertices.Add(new Point3D(refEntity.Vertices[i].X, refEntity.Vertices[i].Y, refEntity.Vertices[i].Z));
		}
	}

	public void Update(double Deviation = 0.01, Plane plane = null)
	{
		if (!(this is buLine))
		{
			if (!(this is buLinearPath))
			{
				if (!(this is buArc))
				{
					if (!(this is buCircle))
					{
						if (!(this is buEllipse))
						{
							if (!(this is buCurve))
							{
								if (!(this is buCompositeCurve))
								{
									if (!(this is buRegion))
									{
										if (!(this is buMesh))
										{
											if (!(this is buLinearDim))
											{
												if (!(this is buAngularDim))
												{
													if (!(this is buDiametricDim))
													{
														if (!(this is buRadialDim))
														{
															if (!(this is buOrdinateDim))
															{
																if (!(this is buText))
																{
																	if (this is buMultilineText)
																	{
																		Update(buEntityUpdateType.MultilineText, Deviation, plane);
																	}
																}
																else
																{
																	Update(buEntityUpdateType.Text, Deviation, plane);
																}
															}
															else
															{
																Update(buEntityUpdateType.OrdinateDim, Deviation, plane);
															}
														}
														else
														{
															Update(buEntityUpdateType.RadialDim, Deviation, plane);
														}
													}
													else
													{
														Update(buEntityUpdateType.DiametricDim, Deviation, plane);
													}
												}
												else
												{
													Update(buEntityUpdateType.AngularDim, Deviation, plane);
												}
											}
											else
											{
												Update(buEntityUpdateType.LinearDim, Deviation, plane);
											}
										}
										else
										{
											Update(buEntityUpdateType.MeshVerticeTriangleIndices, Deviation, plane);
										}
									}
									else
									{
										Update(buEntityUpdateType.RegionCurveList, Deviation, plane);
									}
								}
								else
								{
									Update(buEntityUpdateType.CompositeCurveCurveList, Deviation, plane);
								}
							}
							else if (((buCurve)this).isRational)
							{
								Update(buEntityUpdateType.CurveControlPoint4D, Deviation, plane);
							}
							else
							{
								Update(buEntityUpdateType.CurveControlPoint, Deviation, plane);
							}
						}
						else if (!(plane == null))
						{
							Update(buEntityUpdateType.EllipseCenterRadiusPlane, Deviation, plane);
						}
						else
						{
							Update(buEntityUpdateType.EllipseCenterRadius, Deviation, plane);
						}
					}
					else if (!(plane == null))
					{
						Update(buEntityUpdateType.CircleCenterRadiusPlane, Deviation, plane);
					}
					else
					{
						Update(buEntityUpdateType.CircleCenterRadius, Deviation, plane);
					}
				}
				else if (!(plane == null))
				{
					Update(buEntityUpdateType.ArcCenterRadiusSAEAPlane, Deviation, plane);
				}
				else
				{
					Update(buEntityUpdateType.ArcCenterRadiusSAEA, Deviation, plane);
				}
			}
			else
			{
				Update(buEntityUpdateType.LinearPath, Deviation, plane);
			}
		}
		else
		{
			Update(buEntityUpdateType.Line, Deviation, plane);
		}
	}

	public void Update(buEntityUpdateType UpdateType, double Deviation = 0.01, Plane plane = null)
	{
		double deviation = Deviation;
		if ((Deviation == 0.01) & (buEntityUtilities.EntityRegenDeviation > 0.0))
		{
			deviation = buEntityUtilities.EntityRegenDeviation;
		}
		if (!(GetType() == typeof(buPoint)))
		{
			if (!(GetType() == typeof(buLine)))
			{
				if (!(GetType() == typeof(buArc)))
				{
					if (!(GetType() == typeof(buCircle)))
					{
						if (!(GetType() == typeof(buEllipse)))
						{
							if (!(GetType() == typeof(buLinearPath)))
							{
								if (!(GetType() == typeof(buCurve)))
								{
									if (!(GetType() == typeof(buCompositeCurve)))
									{
										if (!(GetType() == typeof(buRegion)))
										{
											if (!(GetType() == typeof(buMesh)))
											{
												if (!(GetType() == typeof(buLinearDim)))
												{
													if (!(GetType() == typeof(buAngularDim)))
													{
														if (!(GetType() == typeof(buDiametricDim)))
														{
															if (!(GetType() == typeof(buRadialDim)))
															{
																if (!(GetType() == typeof(buOrdinateDim)))
																{
																	if (!(GetType() == typeof(buText)))
																	{
																		if (GetType() == typeof(buMultilineText))
																		{
																			MultilineText multilineText = null;
																			if (UpdateType != buEntityUpdateType.MultilineText)
																			{
																				if (UpdateType == buEntityUpdateType.MultilineTextStyle)
																				{
																					multilineText = ((((buMultilineText)this).StyleName.Length > 0) ? new MultilineText(((buMultilineText)this).Plane, ((buMultilineText)this).InsertionPoint, ((buMultilineText)this).TextString, ((buMultilineText)this).RectWidth, ((buMultilineText)this).Height, ((buMultilineText)this).LineSpaceDistance, ((buMultilineText)this).Alignment, ((buMultilineText)this).StyleName, ((buMultilineText)this).Simplify, ((buMultilineText)this).Wrap) : new MultilineText(((buMultilineText)this).Plane, ((buMultilineText)this).InsertionPoint, ((buMultilineText)this).TextString, ((buMultilineText)this).RectWidth, ((buMultilineText)this).Height, ((buMultilineText)this).LineSpaceDistance, ((buMultilineText)this).Alignment));
																				}
																			}
																			else
																			{
																				multilineText = new MultilineText(((buMultilineText)this).Plane, ((buMultilineText)this).InsertionPoint, ((buMultilineText)this).TextString, ((buMultilineText)this).RectWidth, ((buMultilineText)this).Height, ((buMultilineText)this).LineSpaceDistance, ((buMultilineText)this).Alignment);
																			}
																			if (multilineText != null && buVector5.baseModel != null)
																			{
																				bool flag = false;
																				for (int i = 0; i <= buVector5.baseModel.TextStyles.Count - 1; i++)
																				{
																					if (multilineText.StyleName == buVector5.baseModel.TextStyles[i].Name)
																					{
																						flag = true;
																						i = buVector5.baseModel.TextStyles.Count;
																					}
																				}
																				if (!flag)
																				{
																					multilineText.StyleName = "Default";
																				}
																				multilineText.Regen(new RegenParams(Deviation, buVector5.baseModel));
																			}
																			Vertices.Clear();
																			if (multilineText.Vertices != null)
																			{
																				for (int j = 0; j <= multilineText.Vertices.Length - 1; j++)
																				{
																					Vertices.Add(new Point3D(multilineText.Vertices[j].X, multilineText.Vertices[j].Y, multilineText.Vertices[j].Z));
																				}
																			}
																		}
																	}
																	else
																	{
																		Text text = null;
																		if (UpdateType != buEntityUpdateType.Text)
																		{
																			if (UpdateType == buEntityUpdateType.TextStyle)
																			{
																				text = ((((buText)this).StyleName.Length > 0) ? (buEyeShotFunctions.isTextStyleAvailable(buVector5.baseModel, ((buText)this).StyleName) ? new Text(((buText)this).Plane, ((buText)this).InsertionPoint, ((buText)this).TextString, ((buText)this).Height, ((buText)this).Alignment, ((buText)this).StyleName, ((buText)this).Simplify) : new Text(((buText)this).Plane, ((buText)this).InsertionPoint, ((buText)this).TextString, ((buText)this).Height, ((buText)this).Alignment)) : new Text(((buText)this).Plane, ((buText)this).InsertionPoint, ((buText)this).TextString, ((buText)this).Height, ((buText)this).Alignment));
																			}
																		}
																		else
																		{
																			text = new Text(((buText)this).Plane, ((buText)this).InsertionPoint, ((buText)this).TextString, ((buText)this).Height, ((buText)this).Alignment);
																		}
																		if (text != null && buVector5.baseModel != null)
																		{
																			bool flag2 = false;
																			for (int k = 0; k <= buVector5.baseModel.TextStyles.Count - 1; k++)
																			{
																				if (text.StyleName == buVector5.baseModel.TextStyles[k].Name)
																				{
																					flag2 = true;
																					k = buVector5.baseModel.TextStyles.Count;
																				}
																			}
																			if (!flag2)
																			{
																				text.StyleName = "Default";
																			}
																			text.Regen(new RegenParams(Deviation, buVector5.baseModel));
																		}
																		Vertices.Clear();
																		if (text.Vertices != null)
																		{
																			for (int l = 0; l <= text.Vertices.Length - 1; l++)
																			{
																				Vertices.Add(new Point3D(text.Vertices[l].X, text.Vertices[l].Y, text.Vertices[l].Z));
																			}
																		}
																	}
																}
																else if (UpdateType == buEntityUpdateType.OrdinateDim)
																{
																	if (plane == null)
																	{
																		plane = Plane.XY;
																	}
																	new OrdinateDim(plane, ((buOrdinateDim)this).DefiningPoint, ((buOrdinateDim)this).DimLinePosition, ((buOrdinateDim)this).isVertical, ((buOrdinateDim)this).Height);
																	Vertices.Clear();
																}
															}
															else if (UpdateType == buEntityUpdateType.DiametricDim)
															{
																if (plane == null)
																{
																	plane = Plane.XY;
																}
																new RadialDim(new Circle(plane, ((buRadialDim)this).Origin, ((buRadialDim)this).Radius), ((buRadialDim)this).DimLinePosition, ((buRadialDim)this).Height);
																Vertices.Clear();
															}
														}
														else if (UpdateType == buEntityUpdateType.DiametricDim)
														{
															if (plane == null)
															{
																plane = Plane.XY;
															}
															new DiametricDim(new Circle(plane, ((buDiametricDim)this).Origin, ((buDiametricDim)this).Radius), ((buDiametricDim)this).DimLinePosition, ((buDiametricDim)this).Height);
															Vertices.Clear();
														}
													}
													else if (UpdateType == buEntityUpdateType.AngularDim)
													{
														if (plane == null)
														{
															plane = Plane.XY;
														}
														new AngularDim(plane, ((buAngularDim)this).ExtLine1, ((buAngularDim)this).ExtLine2, ((buAngularDim)this).DimLinePosition, ((buAngularDim)this).Height);
														Vertices.Clear();
													}
												}
												else if (UpdateType == buEntityUpdateType.LinearDim)
												{
													if (plane == null)
													{
														plane = Plane.XY;
													}
													new LinearDim(plane, ((buLinearDim)this).ExtLine1, ((buLinearDim)this).ExtLine2, ((buLinearDim)this).DimLinePosition, ((buLinearDim)this).Height);
													Vertices.Clear();
												}
											}
											else
											{
												Mesh mesh = null;
												if (UpdateType == buEntityUpdateType.MeshVerticeTriangleIndices)
												{
													mesh = new Mesh(Vertices, ((buMesh)this).Triangles);
												}
												mesh.Regen(deviation);
											}
										}
										else if (((buRegion)this).CurveList.Count > 0)
										{
											Point3D point3D = new Point3D(((buRegion)this).CurveList[0].StartPoint.X, ((buRegion)this).CurveList[0].StartPoint.Y, ((buRegion)this).CurveList[0].StartPoint.Z);
											Point3D point3D2 = new Point3D(((buRegion)this).CurveList[((buRegion)this).CurveList.Count - 1].EndPoint.X, ((buRegion)this).CurveList[((buRegion)this).CurveList.Count - 1].EndPoint.Y, ((buRegion)this).CurveList[((buRegion)this).CurveList.Count - 1].EndPoint.Z);
											((buRegion)this).StartPoint = new Point3D(point3D.X, point3D.Y, point3D.Z);
											((buRegion)this).EndPoint = new Point3D(point3D2.X, point3D2.Y, point3D2.Z);
											Vertices.Clear();
											for (int m = 0; m <= ((buRegion)this).CurveList.Count - 1; m++)
											{
												buEntity buEntity2 = ((buRegion)this).CurveList[m];
												if (buEntity2.Vertices.Count <= 0)
												{
													continue;
												}
												if (Vertices.Count != 0)
												{
													for (int n = 0; n <= buEntity2.Vertices.Count - 1; n++)
													{
														if (!buCompare5.EQ(Vertices[Vertices.Count - 1], buEntity2.Vertices[n]))
														{
															Vertices.Add(new Point3D(buEntity2.Vertices[n].X, buEntity2.Vertices[n].Y, buEntity2.Vertices[n].Z));
														}
													}
												}
												else
												{
													for (int num = 0; num <= buEntity2.Vertices.Count - 1; num++)
													{
														Vertices.Add(new Point3D(buEntity2.Vertices[num].X, buEntity2.Vertices[num].Y, buEntity2.Vertices[num].Z));
													}
												}
											}
										}
									}
									else if (((buCompositeCurve)this).CurveList.Count > 0)
									{
										Point3D point3D3 = new Point3D(((buCompositeCurve)this).CurveList[0].StartPoint.X, ((buCompositeCurve)this).CurveList[0].StartPoint.Y, ((buCompositeCurve)this).CurveList[0].StartPoint.Z);
										Point3D point3D4 = new Point3D(((buCompositeCurve)this).CurveList[((buCompositeCurve)this).CurveList.Count - 1].EndPoint.X, ((buCompositeCurve)this).CurveList[((buCompositeCurve)this).CurveList.Count - 1].EndPoint.Y, ((buCompositeCurve)this).CurveList[((buCompositeCurve)this).CurveList.Count - 1].EndPoint.Z);
										((buCompositeCurve)this).StartPoint = new Point3D(point3D3.X, point3D3.Y, point3D3.Z);
										((buCompositeCurve)this).EndPoint = new Point3D(point3D4.X, point3D4.Y, point3D4.Z);
										Vertices.Clear();
										for (int num2 = 0; num2 <= ((buCompositeCurve)this).CurveList.Count - 1; num2++)
										{
											buEntity buEntity3 = ((buCompositeCurve)this).CurveList[num2];
											if (buEntity3.Vertices.Count <= 0)
											{
												continue;
											}
											if (Vertices.Count != 0)
											{
												for (int num3 = 0; num3 <= buEntity3.Vertices.Count - 1; num3++)
												{
													if (!buCompare5.EQ(Vertices[Vertices.Count - 1], buEntity3.Vertices[num3]))
													{
														Vertices.Add(new Point3D(buEntity3.Vertices[num3].X, buEntity3.Vertices[num3].Y, buEntity3.Vertices[num3].Z));
													}
												}
											}
											else
											{
												for (int num4 = 0; num4 <= buEntity3.Vertices.Count - 1; num4++)
												{
													Vertices.Add(new Point3D(buEntity3.Vertices[num4].X, buEntity3.Vertices[num4].Y, buEntity3.Vertices[num4].Z));
												}
											}
										}
									}
								}
								else
								{
									Curve curve = null;
									if (UpdateType != buEntityUpdateType.CurveControlPoint)
									{
										if (UpdateType != buEntityUpdateType.CurveControlPoint4D)
										{
											if (UpdateType == buEntityUpdateType.CurveDerivate)
											{
												if (!((buCurve)this).isRational)
												{
													List<Point3D> list = new List<Point3D>();
													for (int num5 = 0; num5 <= ((buCurve)this).ControlPoints.Count - 1; num5++)
													{
														list.Add(new Point3D(((buCurve)this).ControlPoints[num5].X, ((buCurve)this).ControlPoints[num5].Y, ((buCurve)this).ControlPoints[num5].Z));
													}
													curve = new Curve(((buCurve)this).Degree, list);
												}
												else
												{
													curve = new Curve(((buCurve)this).Degree, ((buCurve)this).KnotVector.ToArray(), ((buCurve)this).ControlPoints.ToArray());
												}
											}
										}
										else
										{
											curve = new Curve(((buCurve)this).Degree, ((buCurve)this).KnotVector.ToArray(), ((buCurve)this).ControlPoints.ToArray());
										}
									}
									else
									{
										List<Point3D> list2 = new List<Point3D>();
										for (int num6 = 0; num6 <= ((buCurve)this).ControlPoints.Count - 1; num6++)
										{
											list2.Add(new Point3D(((buCurve)this).ControlPoints[num6].X, ((buCurve)this).ControlPoints[num6].Y, ((buCurve)this).ControlPoints[num6].Z));
										}
										curve = new Curve(((buCurve)this).Degree, list2);
									}
									if (curve != null)
									{
										((buCurve)this).StartPoint = new Point3D(curve.StartPoint.X, curve.StartPoint.Y, curve.StartPoint.Z);
										((buCurve)this).EndPoint = new Point3D(curve.EndPoint.X, curve.EndPoint.Y, curve.EndPoint.Z);
										curve.Regen(deviation);
										Vertices.Clear();
										for (int num7 = 0; num7 <= curve.Vertices.Length - 1; num7++)
										{
											Vertices.Add(new Point3D(curve.Vertices[num7].X, curve.Vertices[num7].Y, curve.Vertices[num7].Z));
										}
									}
								}
							}
							else
							{
								LinearPath linearPath = null;
								if (UpdateType != buEntityUpdateType.LinearPathPlane)
								{
									if (Vertices.Count > 0)
									{
										((buLinearPath)this).StartPoint = new Point3D(Vertices[0].X, Vertices[0].Y, Vertices[0].Z);
										((buLinearPath)this).EndPoint = new Point3D(Vertices[Vertices.Count - 1].X, Vertices[Vertices.Count - 1].Y, Vertices[Vertices.Count - 1].Z);
									}
								}
								else
								{
									if (plane == null)
									{
										plane = Plane.XY;
									}
									Plane sketchPlane = plane;
									Point2D[] points = Vertices.ToArray();
									linearPath = new LinearPath(sketchPlane, points);
									linearPath.Regen(deviation);
									Vertices.Clear();
									for (int num8 = 0; num8 <= linearPath.Vertices.Length - 1; num8++)
									{
										Vertices.Add(new Point3D(linearPath.Vertices[num8].X, linearPath.Vertices[num8].Y, linearPath.Vertices[num8].Z));
									}
									((buLinearPath)this).StartPoint = new Point3D(linearPath.StartPoint.X, linearPath.StartPoint.Y, linearPath.StartPoint.Z);
									((buLinearPath)this).EndPoint = new Point3D(linearPath.EndPoint.X, linearPath.EndPoint.Y, linearPath.EndPoint.Z);
								}
							}
						}
						else
						{
							Ellipse ellipse = null;
							if (UpdateType != buEntityUpdateType.EllipseCenterRadius)
							{
								if (UpdateType != buEntityUpdateType.EllipseCenterRadiusPlane)
								{
									if (UpdateType != buEntityUpdateType.EllipseCenter2DRadiusPlane)
									{
										if (UpdateType == buEntityUpdateType.EllipseDerivate)
										{
											ellipse = new Ellipse(((buEllipse)this).Plane, ((buEllipse)this).Center, ((buEllipse)this).RadiusX, ((buEllipse)this).RadiusY);
										}
									}
									else
									{
										ellipse = new Ellipse(((buEllipse)this).Plane, ((buEllipse)this).Center, ((buEllipse)this).RadiusX, ((buEllipse)this).RadiusY);
									}
								}
								else
								{
									ellipse = new Ellipse(((buEllipse)this).Plane, ((buEllipse)this).Center, ((buEllipse)this).RadiusX, ((buEllipse)this).RadiusY);
								}
							}
							else
							{
								ellipse = new Ellipse(((buEllipse)this).Center, ((buEllipse)this).RadiusX, ((buEllipse)this).RadiusY);
							}
							if (ellipse != null)
							{
								((buEllipse)this).StartPoint = new Point3D(ellipse.StartPoint.X, ellipse.StartPoint.Y, ellipse.StartPoint.Z);
								((buEllipse)this).EndPoint = new Point3D(ellipse.EndPoint.X, ellipse.EndPoint.Y, ellipse.EndPoint.Z);
								ellipse.Regen(deviation);
								Vertices.Clear();
								for (int num9 = 0; num9 <= ellipse.Vertices.Length - 1; num9++)
								{
									Vertices.Add(new Point3D(ellipse.Vertices[num9].X, ellipse.Vertices[num9].Y, ellipse.Vertices[num9].Z));
								}
							}
						}
					}
					else
					{
						Circle circle = null;
						if (UpdateType != buEntityUpdateType.CircleCenterRadius)
						{
							if (UpdateType != buEntityUpdateType.CircleCenterRadiusPlane)
							{
								if (UpdateType != buEntityUpdateType.CircleCenter2DRadiusPlane)
								{
									if (UpdateType != buEntityUpdateType.Circle3Point)
									{
										if (UpdateType != buEntityUpdateType.Circle3Point2D)
										{
											if (UpdateType == buEntityUpdateType.CircleDerivate)
											{
												circle = new Circle(((buCircle)this).Plane, ((buCircle)this).Center, ((buCircle)this).Radius);
											}
										}
										else
										{
											circle = new Circle(((buCircle)this).StartPoint, ((buArc)this).MiddlePoint, ((buArc)this).EndPoint);
										}
									}
									else
									{
										circle = new Circle(((buCircle)this).StartPoint, ((buArc)this).MiddlePoint, ((buArc)this).EndPoint);
									}
								}
								else
								{
									circle = new Circle(((buCircle)this).Plane, ((buCircle)this).Center, ((buCircle)this).Radius);
								}
							}
							else
							{
								circle = new Circle(((buCircle)this).Plane, ((buCircle)this).Center, ((buCircle)this).Radius);
							}
						}
						else
						{
							circle = new Circle(((buCircle)this).Center, ((buCircle)this).Radius);
						}
						if (circle != null)
						{
							((buCircle)this).StartPoint = new Point3D(circle.StartPoint.X, circle.StartPoint.Y, circle.StartPoint.Z);
							((buCircle)this).EndPoint = new Point3D(circle.EndPoint.X, circle.EndPoint.Y, circle.EndPoint.Z);
							circle.Regen(deviation);
							Vertices.Clear();
							for (int num10 = 0; num10 <= circle.Vertices.Length - 1; num10++)
							{
								Vertices.Add(new Point3D(circle.Vertices[num10].X, circle.Vertices[num10].Y, circle.Vertices[num10].Z));
							}
						}
					}
				}
				else
				{
					Arc arc = null;
					if (UpdateType != buEntityUpdateType.ArcCenterStartEnd)
					{
						if (UpdateType != buEntityUpdateType.ArcCenterStartEndPlane)
						{
							if (UpdateType != buEntityUpdateType.Arc3Point2DPlane)
							{
								if (UpdateType != buEntityUpdateType.Arc3Point3D)
								{
									if (UpdateType != buEntityUpdateType.ArcCenterRadiusSAEA)
									{
										if (UpdateType != buEntityUpdateType.ArcCenterRadiusSAEAPlane)
										{
											if (UpdateType != buEntityUpdateType.ArcCenterStartEndRadiusPlaneFlip)
											{
												if (UpdateType == buEntityUpdateType.ArcDerivate)
												{
													arc = new Arc(((buArc)this).Plane, ((buArc)this).Center, ((buArc)this).StartPoint, ((buArc)this).EndPoint);
												}
											}
											else
											{
												arc = new Arc(((buArc)this).Plane, ((buArc)this).Center, ((buArc)this).Radius, ((buArc)this).StartPoint, ((buArc)this).EndPoint, ((buArc)this).Flip);
											}
										}
										else
										{
											Point3D EndPnt = new Point3D();
											Point3D EndPnt2 = new Point3D();
											buVector5.LineWithLengthAndAngleByPlane(((buArc)this).Center, ((buArc)this).Radius, ((buArc)this).StartAngle, ((buArc)this).Plane, ref EndPnt);
											buVector5.LineWithLengthAndAngleByPlane(((buArc)this).Center, ((buArc)this).Radius, ((buArc)this).EndAngle, ((buArc)this).Plane, ref EndPnt2);
											arc = new Arc(((buArc)this).Plane, ((buArc)this).Center, EndPnt, EndPnt2);
										}
									}
									else if (buNumeric5.IsNumeric(((buArc)this).Radius.ToString()) & buNumeric5.IsNumeric(((buArc)this).StartAngle.ToString()) & buNumeric5.IsNumeric(((buArc)this).EndAngle.ToString()))
									{
										Point3D EndPnt3 = new Point3D();
										Point3D EndPnt4 = new Point3D();
										buVector5.LineWithLengthAndAngleByPlane(((buArc)this).Center, ((buArc)this).Radius, ((buArc)this).StartAngle, ((buArc)this).Plane, ref EndPnt3);
										buVector5.LineWithLengthAndAngleByPlane(((buArc)this).Center, ((buArc)this).Radius, ((buArc)this).EndAngle, ((buArc)this).Plane, ref EndPnt4);
										arc = new Arc(((buArc)this).Plane, ((buArc)this).Center, EndPnt3, EndPnt4);
									}
								}
								else
								{
									arc = new Arc(((buArc)this).Plane, ((buArc)this).StartPoint, ((buArc)this).MiddlePoint, ((buArc)this).EndPoint, ((buArc)this).Flip);
									((buArc)this).Radius = arc.Radius;
									((buArc)this).Plane = (Plane)arc.Plane.Clone();
								}
							}
							else
							{
								arc = new Arc(((buArc)this).Plane, ((buArc)this).StartPoint, ((buArc)this).MiddlePoint, ((buArc)this).EndPoint, ((buArc)this).Flip);
							}
						}
						else
						{
							arc = new Arc(((buArc)this).Plane, ((buArc)this).Center, ((buArc)this).StartPoint, ((buArc)this).EndPoint);
						}
					}
					else
					{
						arc = new Arc(((buArc)this).Center, ((buArc)this).StartPoint, ((buArc)this).EndPoint);
					}
					if (arc != null)
					{
						arc.Regen(deviation);
						((buArc)this).Center = new Point3D(arc.Center.X, arc.Center.Y, arc.Center.Z);
						((buArc)this).StartPoint = new Point3D(arc.StartPoint.X, arc.StartPoint.Y, arc.StartPoint.Z);
						((buArc)this).MiddlePoint = new Point3D(arc.MidPoint.X, arc.MidPoint.Y, arc.MidPoint.Z);
						((buArc)this).EndPoint = new Point3D(arc.EndPoint.X, arc.EndPoint.Y, arc.EndPoint.Z);
						((buArc)this).StartAngle = buConversion5.RadianToDegree(arc.Domain.t0);
						((buArc)this).EndAngle = buConversion5.RadianToDegree(arc.Domain.t1);
						((buArc)this).Radius = arc.Radius;
						Vertices.Clear();
						for (int num11 = 0; num11 <= arc.Vertices.Length - 1; num11++)
						{
							Vertices.Add(new Point3D(arc.Vertices[num11].X, arc.Vertices[num11].Y, arc.Vertices[num11].Z));
						}
					}
				}
			}
			else
			{
				Line line = null;
				if (UpdateType != buEntityUpdateType.LinePlane)
				{
					Vertices.Clear();
					Vertices.Add(new Point3D(((buLine)this).StartPoint.X, ((buLine)this).StartPoint.Y, ((buLine)this).StartPoint.Z));
					Vertices.Add(new Point3D(((buLine)this).EndPoint.X, ((buLine)this).EndPoint.Y, ((buLine)this).EndPoint.Z));
				}
				else
				{
					if (plane == null)
					{
						plane = Plane.XY;
					}
					line = new Line(plane, ((buLine)this).StartPoint, ((buLine)this).EndPoint);
					line.Regen(deviation);
					StartPoint = new Point3D(line.StartPoint.X, line.StartPoint.Y, line.StartPoint.Z);
					EndPoint = new Point3D(line.EndPoint.X, line.EndPoint.Y, line.EndPoint.Z);
					Vertices.Clear();
					for (int num12 = 0; num12 <= line.Vertices.Length - 1; num12++)
					{
						Vertices.Add(new Point3D(line.Vertices[num12].X, line.Vertices[num12].Y, line.Vertices[num12].Z));
					}
				}
			}
		}
		else
		{
			Vertices.Clear();
			Vertices.Add(new Point3D(((buPoint)this).StartPoint.X, ((buPoint)this).StartPoint.Y, ((buPoint)this).StartPoint.Z));
		}
		if (Vertices != null && Vertices.Count > 0)
		{
			buEntityUtilities.BoxSizeCalculate(Vertices, ref BoxMin, ref BoxMax);
		}
	}

	public double Length()
	{
		double result = 0.0;
		Entity copiedEntity = null;
		Copy(this, ref copiedEntity);
		if (copiedEntity != null && copiedEntity is ICurve)
		{
			result = ((ICurve)copiedEntity).Length();
		}
		return result;
	}

	public static CustomData EntityToCustomData(buEntity refEntity)
	{
		CustomData CD = null;
		EntityToCustomData(refEntity, ref CD);
		return CD;
	}

	public static void EntityToCustomData(buEntity refEntity, ref CustomData CD)
	{
		CD = new CustomData();
		CD.OriginalEntityIndex = refEntity.Info.OriginalEntityIndex;
		CD.RefIndex = refEntity.Info.RefIndex;
		CD.Sequence = refEntity.Info.Sequence;
		CD.DontUseForCalculation = refEntity.Info.DontUseForCalculation;
		CD.CamSelected = refEntity.Info.CamSelected;
		CD.CamSelectable = refEntity.Info.CamSelectable;
		CD.CamID = refEntity.Info.CamID;
		CD.Tags = refEntity.Info.Tags;
		CD.OrientationA = refEntity.Orientation.A;
		CD.OrientationB = refEntity.Orientation.B;
		CD.OrientationC = refEntity.Orientation.C;
		CD.sortDirection = refEntity.sortDirection;
		CD.typeDefination = refEntity.typeDefination;
		CD.sortDirection = refEntity.sortDirection;
		if (refEntity.Shape != null)
		{
			CD.infoAngle = refEntity.Shape.Angle;
			if (refEntity.Shape.BasePoint != null)
			{
				CD.infoBasePoint = new Point3D(refEntity.Shape.BasePoint.X, refEntity.Shape.BasePoint.Y, refEntity.Shape.BasePoint.Z);
			}
			CD.infoData = refEntity.Shape.Data;
			CD.infoDegree = refEntity.Shape.Degree;
			CD.infoDepth = refEntity.Shape.Depth;
			CD.infoDirection = refEntity.Shape.Direction;
			CD.infoHeadRadius = refEntity.Shape.HeadRadius;
			CD.infoHeight = refEntity.Shape.Height;
			CD.infoLength = refEntity.Shape.Length;
			CD.infoRadius = refEntity.Shape.Radius;
			CD.infoSide = refEntity.Shape.Side;
			CD.infoString = refEntity.Shape.String;
			CD.infoWidth = refEntity.Shape.Width;
			CD.CurveType = refEntity.Shape.CurveType;
		}
	}

	public static void CustomDataToEntity(CustomData CD, ref buEntity refEntity)
	{
		refEntity.Shape = new EntityShapeInfo();
		refEntity.Info = new EntityInfo();
		refEntity.Info.OriginalEntityIndex = CD.OriginalEntityIndex;
		refEntity.Info.RefIndex = CD.RefIndex;
		refEntity.Info.Sequence = CD.Sequence;
		refEntity.Info.DontUseForCalculation = CD.DontUseForCalculation;
		refEntity.Info.CamSelected = CD.CamSelected;
		refEntity.Info.CamSelectable = CD.CamSelectable;
		refEntity.Info.CamID = CD.CamID;
		refEntity.Info.Tags = CD.Tags;
		refEntity.Orientation.A = CD.OrientationA;
		refEntity.Orientation.B = CD.OrientationB;
		refEntity.Orientation.C = CD.OrientationC;
		refEntity.sortDirection = CD.sortDirection;
		refEntity.Shape.Angle = CD.infoAngle;
		if (CD.infoBasePoint != null)
		{
			refEntity.Shape.BasePoint = new Point3D(CD.infoBasePoint.X, CD.infoBasePoint.Y, CD.infoBasePoint.Z);
		}
		refEntity.Shape.Data = CD.infoData;
		refEntity.Shape.Degree = CD.infoDegree;
		refEntity.Shape.Depth = CD.infoDepth;
		refEntity.Shape.Direction = CD.infoDirection;
		refEntity.Shape.HeadRadius = CD.infoHeadRadius;
		refEntity.Shape.Height = CD.infoHeight;
		refEntity.Shape.Length = CD.infoLength;
		refEntity.Shape.Radius = CD.infoRadius;
		refEntity.Shape.Side = CD.infoSide;
		refEntity.Shape.String = CD.infoString;
		refEntity.Shape.Width = CD.infoWidth;
		refEntity.Shape.CurveType = CD.CurveType;
	}

	public static void ZPointToZero(ref List<buEntity> refEntities)
	{
		for (int i = 0; i <= refEntities.Count - 1; i++)
		{
			buEntity refEntity = refEntities[i];
			ZPointToZero(ref refEntity);
		}
	}

	public static void ZPointToZero(ref buEntity refEntity)
	{
		if (refEntity == null)
		{
			return;
		}
		refEntity.StartPoint.Z = 0.0;
		refEntity.MiddlePoint.Z = 0.0;
		refEntity.EndPoint.Z = 0.0;
		if (!(refEntity.GetType() == typeof(buPoint)) && !(refEntity.GetType() == typeof(buLine)) && !(refEntity.GetType() == typeof(buUpperLine)))
		{
			if (!(refEntity.GetType() == typeof(buArc)))
			{
				if (!(refEntity.GetType() == typeof(buCircle)))
				{
					if (!(refEntity.GetType() == typeof(buEllipse)))
					{
						if (!(refEntity.GetType() == typeof(buLinearPath)))
						{
							if (!(refEntity.GetType() == typeof(buCurve)))
							{
								if (!(refEntity.GetType() == typeof(buCompositeCurve)))
								{
									if (!(refEntity.GetType() == typeof(buRegion)))
									{
										if (!(refEntity.GetType() == typeof(buLinearDim)))
										{
											if (!(refEntity.GetType() == typeof(buAngularDim)))
											{
												if (!(refEntity.GetType() == typeof(buDiametricDim)))
												{
													if (!(refEntity.GetType() == typeof(buRadialDim)))
													{
														if (!(refEntity.GetType() == typeof(buOrdinateDim)))
														{
															if (refEntity.GetType() == typeof(buText))
															{
																((buText)refEntity).InsertionPoint.Z = 0.0;
															}
														}
														else
														{
															((buOrdinateDim)refEntity).InsertionPoint.Z = 0.0;
															((buOrdinateDim)refEntity).DimLinePosition.Z = 0.0;
															((buOrdinateDim)refEntity).DefiningPoint.Z = 0.0;
														}
													}
													else
													{
														((buRadialDim)refEntity).InsertionPoint.Z = 0.0;
														((buRadialDim)refEntity).DimLinePosition.Z = 0.0;
														((buRadialDim)refEntity).Origin.Z = 0.0;
													}
												}
												else
												{
													((buDiametricDim)refEntity).InsertionPoint.Z = 0.0;
													((buDiametricDim)refEntity).DimLinePosition.Z = 0.0;
													((buDiametricDim)refEntity).Origin.Z = 0.0;
												}
											}
											else
											{
												((buAngularDim)refEntity).ExtLine1.Z = 0.0;
												((buAngularDim)refEntity).ExtLine2.Z = 0.0;
												((buAngularDim)refEntity).InsertionPoint.Z = 0.0;
												((buAngularDim)refEntity).DimLinePosition.Z = 0.0;
												((buAngularDim)refEntity).QuadrantPoint.Z = 0.0;
												((buAngularDim)refEntity).Origin.Z = 0.0;
											}
										}
										else
										{
											((buLinearDim)refEntity).ExtLine1.Z = 0.0;
											((buLinearDim)refEntity).ExtLine2.Z = 0.0;
											((buLinearDim)refEntity).InsertionPoint.Z = 0.0;
											((buLinearDim)refEntity).DimLinePosition.Z = 0.0;
										}
									}
									else
									{
										for (int i = 0; i <= ((buRegion)refEntity).CurveList.Count - 1; i++)
										{
											buEntity refEntity2 = ((buRegion)refEntity).CurveList[i];
											ZPointToZero(ref refEntity2);
										}
									}
								}
								else
								{
									for (int j = 0; j <= ((buCompositeCurve)refEntity).CurveList.Count - 1; j++)
									{
										buEntity refEntity3 = ((buCompositeCurve)refEntity).CurveList[j];
										ZPointToZero(ref refEntity3);
									}
								}
							}
							else if (!((buCurve)refEntity).isRational)
							{
								for (int k = 0; k <= ((buCurve)refEntity).ControlPoints.Count - 1; k++)
								{
									((buCurve)refEntity).ControlPoints[k].Z = 0.0;
								}
							}
							else
							{
								for (int l = 0; l <= ((buCurve)refEntity).ControlPoints.Count - 1; l++)
								{
									((buCurve)refEntity).ControlPoints[l].Z = 0.0;
								}
							}
						}
					}
					else
					{
						((buEllipse)refEntity).Center.Z = 0.0;
					}
				}
				else
				{
					((buCircle)refEntity).Center.Z = 0.0;
				}
			}
			else
			{
				((buArc)refEntity).Center.Z = 0.0;
			}
		}
		for (int m = 0; m <= refEntity.Vertices.Count - 1; m++)
		{
			refEntity.Vertices[m].Z = 0.0;
		}
		refEntity.BoxMax.Z = 0.0;
		refEntity.BoxMin.Z = 0.0;
	}

	public static Point3D ToPoint3D(Point3D refPnt)
	{
		return new Point3D(refPnt.X, refPnt.Y, refPnt.Z);
	}

	public static List<Point3D> ToPoint3D(List<Point3D> refPnt)
	{
		List<Point3D> list = new List<Point3D>();
		for (int i = 0; i <= refPnt.Count - 1; i++)
		{
			list.Add(new Point3D(refPnt[i].X, refPnt[i].Y, refPnt[i].Z));
		}
		return list;
	}

	public void Translate(double dx, double dy, double dz)
	{
		if (GetType() == typeof(buPoint))
		{
			((buPoint)this).StartPoint.X = ((buPoint)this).StartPoint.X + dx;
			((buPoint)this).StartPoint.Y = ((buPoint)this).StartPoint.Y + dy;
			((buPoint)this).StartPoint.Z = ((buPoint)this).StartPoint.Z + dz;
			((buPoint)this).EndPoint.X = ((buPoint)this).EndPoint.X + dx;
			((buPoint)this).EndPoint.Y = ((buPoint)this).EndPoint.Y + dy;
			((buPoint)this).EndPoint.Z = ((buPoint)this).EndPoint.Z + dz;
		}
		if (GetType() == typeof(buLine))
		{
			((buLine)this).StartPoint.X = ((buLine)this).StartPoint.X + dx;
			((buLine)this).StartPoint.Y = ((buLine)this).StartPoint.Y + dy;
			((buLine)this).StartPoint.Z = ((buLine)this).StartPoint.Z + dz;
			((buLine)this).EndPoint.X = ((buLine)this).EndPoint.X + dx;
			((buLine)this).EndPoint.Y = ((buLine)this).EndPoint.Y + dy;
			((buLine)this).EndPoint.Z = ((buLine)this).EndPoint.Z + dz;
		}
		if (GetType() == typeof(buArc))
		{
			((buArc)this).Center.X = ((buArc)this).Center.X + dx;
			((buArc)this).Center.Y = ((buArc)this).Center.Y + dy;
			((buArc)this).Center.Z = ((buArc)this).Center.Z + dz;
			((buArc)this).StartPoint.X = ((buArc)this).StartPoint.X + dx;
			((buArc)this).StartPoint.Y = ((buArc)this).StartPoint.Y + dy;
			((buArc)this).StartPoint.Z = ((buArc)this).StartPoint.Z + dz;
			((buArc)this).MiddlePoint.X = ((buArc)this).MiddlePoint.X + dx;
			((buArc)this).MiddlePoint.Y = ((buArc)this).MiddlePoint.Y + dy;
			((buArc)this).MiddlePoint.Z = ((buArc)this).MiddlePoint.Z + dz;
			((buArc)this).EndPoint.X = ((buArc)this).EndPoint.X + dx;
			((buArc)this).EndPoint.Y = ((buArc)this).EndPoint.Y + dy;
			((buArc)this).EndPoint.Z = ((buArc)this).EndPoint.Z + dz;
		}
		if (GetType() == typeof(buCircle))
		{
			((buCircle)this).Center.X = ((buCircle)this).Center.X + dx;
			((buCircle)this).Center.Y = ((buCircle)this).Center.Y + dy;
			((buCircle)this).Center.Z = ((buCircle)this).Center.Z + dz;
			((buCircle)this).StartPoint.X = ((buCircle)this).StartPoint.X + dx;
			((buCircle)this).StartPoint.Y = ((buCircle)this).StartPoint.Y + dy;
			((buCircle)this).StartPoint.Z = ((buCircle)this).StartPoint.Z + dz;
			((buCircle)this).EndPoint.X = ((buCircle)this).EndPoint.X + dx;
			((buCircle)this).EndPoint.Y = ((buCircle)this).EndPoint.Y + dy;
			((buCircle)this).EndPoint.Z = ((buCircle)this).EndPoint.Z + dz;
		}
		if (GetType() == typeof(buEllipse))
		{
			((buEllipse)this).Center.X = ((buEllipse)this).Center.X + dx;
			((buEllipse)this).Center.Y = ((buEllipse)this).Center.Y + dy;
			((buEllipse)this).Center.Z = ((buEllipse)this).Center.Z + dz;
			((buEllipse)this).StartPoint.X = ((buEllipse)this).StartPoint.X + dx;
			((buEllipse)this).StartPoint.Y = ((buEllipse)this).StartPoint.Y + dy;
			((buEllipse)this).StartPoint.Z = ((buEllipse)this).StartPoint.Z + dz;
			((buEllipse)this).EndPoint.X = ((buEllipse)this).EndPoint.X + dx;
			((buEllipse)this).EndPoint.Y = ((buEllipse)this).EndPoint.Y + dy;
			((buEllipse)this).EndPoint.Z = ((buEllipse)this).EndPoint.Z + dz;
		}
		if (GetType() == typeof(buCurve))
		{
			for (int i = 0; i <= ((buCurve)this).ControlPoints.Count - 1; i++)
			{
				((buCurve)this).ControlPoints[i].X = ((buCurve)this).ControlPoints[i].X + dx;
				((buCurve)this).ControlPoints[i].Y = ((buCurve)this).ControlPoints[i].Y + dy;
				((buCurve)this).ControlPoints[i].Z = ((buCurve)this).ControlPoints[i].Z + dz;
			}
			((buCurve)this).StartPoint.X = ((buCurve)this).StartPoint.X + dx;
			((buCurve)this).StartPoint.Y = ((buCurve)this).StartPoint.Y + dy;
			((buCurve)this).StartPoint.Z = ((buCurve)this).StartPoint.Z + dz;
			((buCurve)this).EndPoint.X = ((buCurve)this).EndPoint.X + dx;
			((buCurve)this).EndPoint.Y = ((buCurve)this).EndPoint.Y + dy;
			((buCurve)this).EndPoint.Z = ((buCurve)this).EndPoint.Z + dz;
		}
		if (GetType() == typeof(buCompositeCurve))
		{
			for (int j = 0; j <= ((buCompositeCurve)this).CurveList.Count - 1; j++)
			{
				buEntity buEntity2 = ((buCompositeCurve)this).CurveList[j];
				buEntity2.Translate(dx, dy, dz);
			}
			((buCompositeCurve)this).StartPoint.X = ((buCompositeCurve)this).StartPoint.X + dx;
			((buCompositeCurve)this).StartPoint.Y = ((buCompositeCurve)this).StartPoint.Y + dy;
			((buCompositeCurve)this).StartPoint.Z = ((buCompositeCurve)this).StartPoint.Z + dz;
			((buCompositeCurve)this).EndPoint.X = ((buCompositeCurve)this).EndPoint.X + dx;
			((buCompositeCurve)this).EndPoint.Y = ((buCompositeCurve)this).EndPoint.Y + dy;
			((buCompositeCurve)this).EndPoint.Z = ((buCompositeCurve)this).EndPoint.Z + dz;
		}
		if (GetType() == typeof(buUpperLine))
		{
			((buUpperLine)this).StartPoint.X = ((buUpperLine)this).StartPoint.X + dx;
			((buUpperLine)this).StartPoint.Y = ((buUpperLine)this).StartPoint.Y + dy;
			((buUpperLine)this).StartPoint.Z = ((buUpperLine)this).StartPoint.Z + dz;
			((buUpperLine)this).EndPoint.X = ((buUpperLine)this).EndPoint.X + dx;
			((buUpperLine)this).EndPoint.Y = ((buUpperLine)this).EndPoint.Y + dy;
			((buUpperLine)this).EndPoint.Z = ((buUpperLine)this).EndPoint.Z + dz;
		}
		if (GetType() == typeof(buLinearPath))
		{
			((buLinearPath)this).StartPoint.X = ((buLinearPath)this).StartPoint.X + dx;
			((buLinearPath)this).StartPoint.Y = ((buLinearPath)this).StartPoint.Y + dy;
			((buLinearPath)this).StartPoint.Z = ((buLinearPath)this).StartPoint.Z + dz;
			((buLinearPath)this).EndPoint.X = ((buLinearPath)this).EndPoint.X + dx;
			((buLinearPath)this).EndPoint.Y = ((buLinearPath)this).EndPoint.Y + dy;
			((buLinearPath)this).EndPoint.Z = ((buLinearPath)this).EndPoint.Z + dz;
		}
		if (GetType() == typeof(buRegion))
		{
			for (int k = 0; k <= ((buRegion)this).CurveList.Count - 1; k++)
			{
				buEntity buEntity3 = ((buRegion)this).CurveList[k];
				buEntity3.Translate(dx, dy, dz);
			}
			((buRegion)this).StartPoint.X = ((buRegion)this).StartPoint.X + dx;
			((buRegion)this).StartPoint.Y = ((buRegion)this).StartPoint.Y + dy;
			((buRegion)this).StartPoint.Z = ((buRegion)this).StartPoint.Z + dz;
			((buRegion)this).EndPoint.X = ((buRegion)this).EndPoint.X + dx;
			((buRegion)this).EndPoint.Y = ((buRegion)this).EndPoint.Y + dy;
			((buRegion)this).EndPoint.Z = ((buRegion)this).EndPoint.Z + dz;
		}
		if (GetType() == typeof(buLinearDim))
		{
			((buLinearDim)this).ExtLine1.X = ((buLinearDim)this).ExtLine1.X + dx;
			((buLinearDim)this).ExtLine1.Y = ((buLinearDim)this).ExtLine1.Y + dy;
			((buLinearDim)this).ExtLine1.Z = ((buLinearDim)this).ExtLine1.Z + dz;
			((buLinearDim)this).ExtLine2.X = ((buLinearDim)this).ExtLine2.X + dx;
			((buLinearDim)this).ExtLine2.Y = ((buLinearDim)this).ExtLine2.Y + dy;
			((buLinearDim)this).ExtLine2.Z = ((buLinearDim)this).ExtLine2.Z + dz;
			((buLinearDim)this).InsertionPoint.X = ((buLinearDim)this).InsertionPoint.X + dx;
			((buLinearDim)this).InsertionPoint.Y = ((buLinearDim)this).InsertionPoint.Y + dy;
			((buLinearDim)this).InsertionPoint.Z = ((buLinearDim)this).InsertionPoint.Z + dz;
			((buLinearDim)this).DimLinePosition.X = ((buLinearDim)this).DimLinePosition.X + dx;
			((buLinearDim)this).DimLinePosition.Y = ((buLinearDim)this).DimLinePosition.Y + dy;
			((buLinearDim)this).DimLinePosition.Z = ((buLinearDim)this).DimLinePosition.Z + dz;
		}
		if (GetType() == typeof(buMesh))
		{
			((buMesh)this).StartPoint.X = ((buMesh)this).StartPoint.X + dx;
			((buMesh)this).StartPoint.Y = ((buMesh)this).StartPoint.Y + dy;
			((buMesh)this).StartPoint.Z = ((buMesh)this).StartPoint.Z + dz;
			((buMesh)this).EndPoint.X = ((buMesh)this).EndPoint.X + dx;
			((buMesh)this).EndPoint.Y = ((buMesh)this).EndPoint.Y + dy;
			((buMesh)this).EndPoint.Z = ((buMesh)this).EndPoint.Z + dz;
		}
		if (GetType() == typeof(buText))
		{
			((buText)this).InsertionPoint.X = ((buText)this).InsertionPoint.X + dx;
			((buText)this).InsertionPoint.Y = ((buText)this).InsertionPoint.Y + dy;
			((buText)this).InsertionPoint.Z = ((buText)this).InsertionPoint.Z + dz;
		}
		if (GetType() == typeof(buMultilineText))
		{
			((buMultilineText)this).InsertionPoint.X = ((buMultilineText)this).InsertionPoint.X + dx;
			((buMultilineText)this).InsertionPoint.Y = ((buMultilineText)this).InsertionPoint.Y + dy;
			((buMultilineText)this).InsertionPoint.Z = ((buMultilineText)this).InsertionPoint.Z + dz;
		}
		for (int l = 0; l <= Vertices.Count - 1; l++)
		{
			Vertices[l].X = Vertices[l].X + dx;
			Vertices[l].Y = Vertices[l].Y + dy;
			Vertices[l].Z = Vertices[l].Z + dz;
		}
		BoxMax.X += dx;
		BoxMax.Y += dy;
		BoxMax.Z += dz;
		BoxMin.X += dx;
		BoxMin.Y += dy;
		BoxMin.Z += dz;
	}

	public void Scale(Point3D fixedPoint, double sx, double sy, double sz = 1.0)
	{
		Entity copiedEntity = null;
		Copy(this, ref copiedEntity);
		copiedEntity.Scale(fixedPoint, sx, sy, sz);
		if (!(GetType() == typeof(buPoint)))
		{
			if (!(GetType() == typeof(buLine)))
			{
				if (!(GetType() == typeof(buArc)))
				{
					if (!(GetType() == typeof(buCircle)))
					{
						if (!(GetType() == typeof(buEllipse)))
						{
							if (!(GetType() == typeof(buLinearPath)))
							{
								if (!(GetType() == typeof(buCurve)))
								{
									if (!(GetType() == typeof(buCompositeCurve)))
									{
										if (!(GetType() == typeof(buRegion)))
										{
											if (!(GetType() == typeof(buMesh)))
											{
												if (!(GetType() == typeof(buText)))
												{
													if (GetType() == typeof(buMultilineText))
													{
														MultilineText multilineText = copiedEntity as MultilineText;
														((buMultilineText)this).InsertionPoint = new Point3D(multilineText.InsertionPoint.X, multilineText.InsertionPoint.Y, multilineText.InsertionPoint.Z);
													}
												}
												else
												{
													Text text = copiedEntity as Text;
													((buText)this).InsertionPoint = new Point3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
												}
											}
											else
											{
												Mesh mesh = copiedEntity as Mesh;
												((buMesh)this).Vertices.Clear();
												for (int i = 0; i <= mesh.Vertices.Length - 1; i++)
												{
													((buMesh)this).Vertices.Add(new Point3D(mesh.Vertices[i].X, mesh.Vertices[i].Y, mesh.Vertices[i].Z));
												}
											}
										}
										else
										{
											devDept.Eyeshot.Entities.Region region = copiedEntity as devDept.Eyeshot.Entities.Region;
											((buRegion)this).CurveList.Clear();
											for (int j = 0; j <= region.ContourList.Count - 1; j++)
											{
												Entity copiedEntity2 = null;
												Copy((Entity)region.ContourList[j], ref copiedEntity2);
												((buRegion)this).CurveList.Add(Copy(copiedEntity2));
											}
										}
									}
									else
									{
										CompositeCurve compositeCurve = copiedEntity as CompositeCurve;
										StartPoint = new Point3D(compositeCurve.StartPoint.X, compositeCurve.StartPoint.Y, compositeCurve.StartPoint.Z);
										EndPoint = new Point3D(compositeCurve.EndPoint.X, compositeCurve.EndPoint.Y, compositeCurve.EndPoint.Z);
										((buCompositeCurve)this).CurveList.Clear();
										for (int k = 0; k <= compositeCurve.CurveList.Count - 1; k++)
										{
											Entity copiedEntity3 = null;
											Copy((Entity)compositeCurve.CurveList[k], ref copiedEntity3);
											((buCompositeCurve)this).CurveList.Add(Copy(copiedEntity3));
										}
									}
								}
								else
								{
									Curve curve = copiedEntity as Curve;
									StartPoint = new Point3D(curve.StartPoint.X, curve.StartPoint.Y, curve.StartPoint.Z);
									EndPoint = new Point3D(curve.EndPoint.X, curve.EndPoint.Y, curve.EndPoint.Z);
									((buCurve)this).ControlPoints.Clear();
									for (int l = 0; l <= curve.ControlPoints.Length - 1; l++)
									{
										((buCurve)this).ControlPoints.Add(new Point4D(curve.ControlPoints[l].X, curve.ControlPoints[l].Y, curve.ControlPoints[l].Z, curve.ControlPoints[l].W));
									}
								}
							}
							else
							{
								LinearPath linearPath = copiedEntity as LinearPath;
								StartPoint = new Point3D(linearPath.StartPoint.X, linearPath.StartPoint.Y, linearPath.StartPoint.Z);
								EndPoint = new Point3D(linearPath.EndPoint.X, linearPath.EndPoint.Y, linearPath.EndPoint.Z);
								((buLinearPath)this).Vertices.Clear();
								for (int m = 0; m <= linearPath.Vertices.Length - 1; m++)
								{
									((buLinearPath)this).Vertices.Add(new Point3D(linearPath.Vertices[m].X, linearPath.Vertices[m].Y, linearPath.Vertices[m].Z));
								}
							}
						}
						else
						{
							Ellipse ellipse = copiedEntity as Ellipse;
							((buEllipse)this).Plane = (Plane)ellipse.Plane.Clone();
							((buEllipse)this).Center = new Point3D(ellipse.Center.X, ellipse.Center.Y, ellipse.Center.Z);
							StartPoint = new Point3D(ellipse.StartPoint.X, ellipse.StartPoint.Y, ellipse.StartPoint.Z);
							EndPoint = new Point3D(ellipse.EndPoint.X, ellipse.EndPoint.Y, ellipse.EndPoint.Z);
						}
					}
					else
					{
						Circle circle = copiedEntity as Circle;
						((buCircle)this).Plane = (Plane)circle.Plane.Clone();
						((buCircle)this).Center = new Point3D(circle.Center.X, circle.Center.Y, circle.Center.Z);
						StartPoint = new Point3D(circle.StartPoint.X, circle.StartPoint.Y, circle.StartPoint.Z);
						EndPoint = new Point3D(circle.EndPoint.X, circle.EndPoint.Y, circle.EndPoint.Z);
					}
				}
				else
				{
					Arc arc = copiedEntity as Arc;
					((buArc)this).Plane = (Plane)arc.Plane.Clone();
					((buArc)this).Center = new Point3D(arc.Center.X, arc.Center.Y, arc.Center.Z);
					StartPoint = new Point3D(arc.StartPoint.X, arc.StartPoint.Y, arc.StartPoint.Z);
					MiddlePoint = new Point3D(arc.MidPoint.X, arc.MidPoint.Y, arc.MidPoint.Z);
					EndPoint = new Point3D(arc.EndPoint.X, arc.EndPoint.Y, arc.EndPoint.Z);
				}
			}
			else
			{
				Line line = copiedEntity as Line;
				StartPoint = new Point3D(line.StartPoint.X, line.StartPoint.Y, line.StartPoint.Z);
				EndPoint = new Point3D(line.EndPoint.X, line.EndPoint.Y, line.EndPoint.Z);
			}
		}
		else
		{
			devDept.Eyeshot.Entities.Point point = copiedEntity as devDept.Eyeshot.Entities.Point;
			StartPoint = new Point3D(point.StartPoint.X, point.StartPoint.Y, point.StartPoint.Z);
		}
		Regen(copiedEntity);
	}

	public void Rotate(double Angle, Vector3D axis)
	{
		Entity copiedEntity = null;
		Copy(this, ref copiedEntity);
		copiedEntity.Rotate(buConversion5.DegreeToRadian(Angle), axis);
		if (!(GetType() == typeof(buPoint)))
		{
			if (!(GetType() == typeof(buLine)))
			{
				if (!(GetType() == typeof(buArc)))
				{
					if (!(GetType() == typeof(buCircle)))
					{
						if (!(GetType() == typeof(buEllipse)))
						{
							if (!(GetType() == typeof(buLinearPath)))
							{
								if (!(GetType() == typeof(buCurve)))
								{
									if (!(GetType() == typeof(buCompositeCurve)))
									{
										if (!(GetType() == typeof(buRegion)))
										{
											if (!(GetType() == typeof(buMesh)))
											{
												if (!(GetType() == typeof(buLinearDim)))
												{
													if (!(GetType() == typeof(buAngularDim)))
													{
														if (!(GetType() == typeof(buRadialDim)))
														{
															if (!(GetType() == typeof(buDiametricDim)))
															{
																if (!(GetType() == typeof(buOrdinateDim)))
																{
																	if (!(GetType() == typeof(buText)))
																	{
																		if (GetType() == typeof(buMultilineText))
																		{
																			MultilineText multilineText = copiedEntity as MultilineText;
																			((buMultilineText)this).InsertionPoint = new Point3D(multilineText.InsertionPoint.X, multilineText.InsertionPoint.Y, multilineText.InsertionPoint.Z);
																			((buMultilineText)this).Vertices.Clear();
																			if (multilineText.Vertices != null)
																			{
																				for (int i = 0; i <= multilineText.Vertices.Length - 1; i++)
																				{
																					((buMultilineText)this).Vertices.Add(new Point3D(multilineText.Vertices[i].X, multilineText.Vertices[i].Y, multilineText.Vertices[i].Z));
																				}
																			}
																		}
																	}
																	else
																	{
																		Text text = copiedEntity as Text;
																		((buText)this).InsertionPoint = new Point3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
																		((buText)this).Vertices.Clear();
																		if (text.Vertices != null)
																		{
																			for (int j = 0; j <= text.Vertices.Length - 1; j++)
																			{
																				((buText)this).Vertices.Add(new Point3D(text.Vertices[j].X, text.Vertices[j].Y, text.Vertices[j].Z));
																			}
																		}
																	}
																}
																else
																{
																	OrdinateDim ordinateDim = copiedEntity as OrdinateDim;
																	((buOrdinateDim)this).Plane = (Plane)ordinateDim.Plane.Clone();
																	((buOrdinateDim)this).DimLinePosition = buVector5.ToPoint3D(ordinateDim.DimLinePosition);
																	((buOrdinateDim)this).InsertionPoint = buVector5.ToPoint3D(ordinateDim.InsertionPoint);
																	((buOrdinateDim)this).DefiningPoint = buVector5.ToPoint3D(ordinateDim.DefiningPoint);
																}
															}
															else
															{
																DiametricDim diametricDim = copiedEntity as DiametricDim;
																((buDiametricDim)this).Plane = (Plane)diametricDim.Plane.Clone();
																((buDiametricDim)this).DimLinePosition = buVector5.ToPoint3D(diametricDim.DimLinePosition);
																((buDiametricDim)this).InsertionPoint = buVector5.ToPoint3D(diametricDim.InsertionPoint);
															}
														}
														else
														{
															RadialDim radialDim = copiedEntity as RadialDim;
															((buRadialDim)this).Plane = (Plane)radialDim.Plane.Clone();
															((buRadialDim)this).DimLinePosition = buVector5.ToPoint3D(radialDim.DimLinePosition);
															((buRadialDim)this).InsertionPoint = buVector5.ToPoint3D(radialDim.InsertionPoint);
														}
													}
													else
													{
														AngularDim angularDim = copiedEntity as AngularDim;
														((buAngularDim)this).Plane = (Plane)angularDim.Plane.Clone();
														((buAngularDim)this).ExtLine1 = buVector5.ToPoint3D(angularDim.ExtLine1);
														((buAngularDim)this).ExtLine2 = buVector5.ToPoint3D(angularDim.ExtLine2);
														((buAngularDim)this).DimLinePosition = buVector5.ToPoint3D(angularDim.DimLinePosition);
														((buAngularDim)this).InsertionPoint = buVector5.ToPoint3D(angularDim.InsertionPoint);
													}
												}
												else
												{
													LinearDim linearDim = copiedEntity as LinearDim;
													((buLinearDim)this).Plane = (Plane)linearDim.Plane.Clone();
													((buLinearDim)this).InsertionPoint = buVector5.ToPoint3D(linearDim.InsertionPoint);
													((buLinearDim)this).ExtLine1 = buVector5.ToPoint3D(linearDim.ExtLine1);
													((buLinearDim)this).ExtLine2 = buVector5.ToPoint3D(linearDim.ExtLine2);
													((buLinearDim)this).DimLinePosition = buVector5.ToPoint3D(linearDim.DimLinePosition);
												}
											}
											else
											{
												Mesh mesh = copiedEntity as Mesh;
												((buMesh)this).Vertices.Clear();
												for (int k = 0; k <= mesh.Vertices.Length - 1; k++)
												{
													((buMesh)this).Vertices.Add(new Point3D(mesh.Vertices[k].X, mesh.Vertices[k].Y, mesh.Vertices[k].Z));
												}
											}
										}
										else
										{
											devDept.Eyeshot.Entities.Region region = copiedEntity as devDept.Eyeshot.Entities.Region;
											((buRegion)this).CurveList.Clear();
											for (int l = 0; l <= region.ContourList.Count - 1; l++)
											{
												Entity copiedEntity2 = null;
												Copy((Entity)region.ContourList[l], ref copiedEntity2);
												((buRegion)this).CurveList.Add(Copy(copiedEntity2));
											}
										}
									}
									else
									{
										CompositeCurve compositeCurve = copiedEntity as CompositeCurve;
										StartPoint = new Point3D(compositeCurve.StartPoint.X, compositeCurve.StartPoint.Y, compositeCurve.StartPoint.Z);
										EndPoint = new Point3D(compositeCurve.EndPoint.X, compositeCurve.EndPoint.Y, compositeCurve.EndPoint.Z);
										((buCompositeCurve)this).CurveList.Clear();
										for (int m = 0; m <= compositeCurve.CurveList.Count - 1; m++)
										{
											Entity copiedEntity3 = null;
											Copy((Entity)compositeCurve.CurveList[m], ref copiedEntity3);
											((buCompositeCurve)this).CurveList.Add(Copy(copiedEntity3));
										}
									}
								}
								else
								{
									Curve curve = copiedEntity as Curve;
									StartPoint = new Point3D(curve.StartPoint.X, curve.StartPoint.Y, curve.StartPoint.Z);
									EndPoint = new Point3D(curve.EndPoint.X, curve.EndPoint.Y, curve.EndPoint.Z);
									((buCurve)this).ControlPoints.Clear();
									for (int n = 0; n <= curve.ControlPoints.Length - 1; n++)
									{
										((buCurve)this).ControlPoints.Add(new Point4D(curve.ControlPoints[n].X, curve.ControlPoints[n].Y, curve.ControlPoints[n].Z, curve.ControlPoints[n].W));
									}
								}
							}
							else
							{
								LinearPath linearPath = copiedEntity as LinearPath;
								StartPoint = new Point3D(linearPath.StartPoint.X, linearPath.StartPoint.Y, linearPath.StartPoint.Z);
								EndPoint = new Point3D(linearPath.EndPoint.X, linearPath.EndPoint.Y, linearPath.EndPoint.Z);
								((buLinearPath)this).Vertices.Clear();
								for (int num = 0; num <= linearPath.Vertices.Length - 1; num++)
								{
									((buLinearPath)this).Vertices.Add(new Point3D(linearPath.Vertices[num].X, linearPath.Vertices[num].Y, linearPath.Vertices[num].Z));
								}
							}
						}
						else
						{
							Ellipse ellipse = copiedEntity as Ellipse;
							((buEllipse)this).Plane = (Plane)ellipse.Plane.Clone();
							((buEllipse)this).Center = new Point3D(ellipse.Center.X, ellipse.Center.Y, ellipse.Center.Z);
							StartPoint = new Point3D(ellipse.StartPoint.X, ellipse.StartPoint.Y, ellipse.StartPoint.Z);
							EndPoint = new Point3D(ellipse.EndPoint.X, ellipse.EndPoint.Y, ellipse.EndPoint.Z);
						}
					}
					else
					{
						Circle circle = copiedEntity as Circle;
						((buCircle)this).Plane = (Plane)circle.Plane.Clone();
						((buCircle)this).Center = new Point3D(circle.Center.X, circle.Center.Y, circle.Center.Z);
						StartPoint = new Point3D(circle.StartPoint.X, circle.StartPoint.Y, circle.StartPoint.Z);
						EndPoint = new Point3D(circle.EndPoint.X, circle.EndPoint.Y, circle.EndPoint.Z);
					}
				}
				else
				{
					Arc arc = copiedEntity as Arc;
					((buArc)this).Plane = (Plane)arc.Plane.Clone();
					((buArc)this).Center = new Point3D(arc.Center.X, arc.Center.Y, arc.Center.Z);
					StartPoint = new Point3D(arc.StartPoint.X, arc.StartPoint.Y, arc.StartPoint.Z);
					MiddlePoint = new Point3D(arc.MidPoint.X, arc.MidPoint.Y, arc.MidPoint.Z);
					EndPoint = new Point3D(arc.EndPoint.X, arc.EndPoint.Y, arc.EndPoint.Z);
				}
			}
			else
			{
				Line line = copiedEntity as Line;
				StartPoint = new Point3D(line.StartPoint.X, line.StartPoint.Y, line.StartPoint.Z);
				EndPoint = new Point3D(line.EndPoint.X, line.EndPoint.Y, line.EndPoint.Z);
			}
		}
		else
		{
			devDept.Eyeshot.Entities.Point point = copiedEntity as devDept.Eyeshot.Entities.Point;
			StartPoint = new Point3D(point.StartPoint.X, point.StartPoint.Y, point.StartPoint.Z);
		}
		Regen(copiedEntity);
	}

	public void Rotate(double Angle, Vector3D axis, Point3D center)
	{
		Entity copiedEntity = null;
		Copy(this, ref copiedEntity);
		copiedEntity.Rotate(buConversion5.DegreeToRadian(Angle), axis, center);
		if (!(GetType() == typeof(buPoint)))
		{
			if (!(GetType() == typeof(buLine)))
			{
				if (!(GetType() == typeof(buArc)))
				{
					if (!(GetType() == typeof(buCircle)))
					{
						if (!(GetType() == typeof(buEllipse)))
						{
							if (!(GetType() == typeof(buLinearPath)))
							{
								if (!(GetType() == typeof(buCurve)))
								{
									if (!(GetType() == typeof(buCompositeCurve)))
									{
										if (!(GetType() == typeof(buRegion)))
										{
											if (!(GetType() == typeof(buMesh)))
											{
												if (!(GetType() == typeof(buText)))
												{
													if (GetType() == typeof(buMultilineText))
													{
														((MultilineText)copiedEntity).StyleName = ((MultilineText)copiedEntity).StyleName.Trim();
														MultilineText multilineText = copiedEntity as MultilineText;
														((buMultilineText)this).InsertionPoint = new Point3D(multilineText.InsertionPoint.X, multilineText.InsertionPoint.Y, multilineText.InsertionPoint.Z);
														((buMultilineText)this).Plane = (Plane)multilineText.Plane.Clone();
														((buMultilineText)this).Vertices.Clear();
														if (multilineText.Vertices != null)
														{
															for (int i = 0; i <= multilineText.Vertices.Length - 1; i++)
															{
																((buMultilineText)this).Vertices.Add(new Point3D(multilineText.Vertices[i].X, multilineText.Vertices[i].Y, multilineText.Vertices[i].Z));
															}
														}
													}
												}
												else
												{
													Text text = copiedEntity as Text;
													((buText)this).InsertionPoint = new Point3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
													((buText)this).Plane = (Plane)text.Plane.Clone();
													((buText)this).Vertices.Clear();
													if (text.Vertices != null)
													{
														for (int j = 0; j <= text.Vertices.Length - 1; j++)
														{
															((buText)this).Vertices.Add(new Point3D(text.Vertices[j].X, text.Vertices[j].Y, text.Vertices[j].Z));
														}
													}
												}
											}
											else
											{
												Mesh mesh = copiedEntity as Mesh;
												((buMesh)this).Vertices.Clear();
												for (int k = 0; k <= mesh.Vertices.Length - 1; k++)
												{
													((buMesh)this).Vertices.Add(new Point3D(mesh.Vertices[k].X, mesh.Vertices[k].Y, mesh.Vertices[k].Z));
												}
											}
										}
										else
										{
											devDept.Eyeshot.Entities.Region region = copiedEntity as devDept.Eyeshot.Entities.Region;
											((buRegion)this).CurveList.Clear();
											for (int l = 0; l <= region.ContourList.Count - 1; l++)
											{
												Entity copiedEntity2 = null;
												Copy((Entity)region.ContourList[l], ref copiedEntity2);
												((buRegion)this).CurveList.Add(Copy(copiedEntity2));
											}
										}
									}
									else
									{
										CompositeCurve compositeCurve = copiedEntity as CompositeCurve;
										StartPoint = new Point3D(compositeCurve.StartPoint.X, compositeCurve.StartPoint.Y, compositeCurve.StartPoint.Z);
										EndPoint = new Point3D(compositeCurve.EndPoint.X, compositeCurve.EndPoint.Y, compositeCurve.EndPoint.Z);
										((buCompositeCurve)this).CurveList.Clear();
										for (int m = 0; m <= compositeCurve.CurveList.Count - 1; m++)
										{
											Entity copiedEntity3 = null;
											Copy((Entity)compositeCurve.CurveList[m], ref copiedEntity3);
											((buCompositeCurve)this).CurveList.Add(Copy(copiedEntity3));
										}
									}
								}
								else
								{
									Curve curve = copiedEntity as Curve;
									StartPoint = new Point3D(curve.StartPoint.X, curve.StartPoint.Y, curve.StartPoint.Z);
									EndPoint = new Point3D(curve.EndPoint.X, curve.EndPoint.Y, curve.EndPoint.Z);
									((buCurve)this).ControlPoints.Clear();
									for (int n = 0; n <= curve.ControlPoints.Length - 1; n++)
									{
										((buCurve)this).ControlPoints.Add(new Point4D(curve.ControlPoints[n].X, curve.ControlPoints[n].Y, curve.ControlPoints[n].Z, curve.ControlPoints[n].W));
									}
								}
							}
							else
							{
								LinearPath linearPath = copiedEntity as LinearPath;
								StartPoint = new Point3D(linearPath.StartPoint.X, linearPath.StartPoint.Y, linearPath.StartPoint.Z);
								EndPoint = new Point3D(linearPath.EndPoint.X, linearPath.EndPoint.Y, linearPath.EndPoint.Z);
								((buLinearPath)this).Vertices.Clear();
								for (int num = 0; num <= linearPath.Vertices.Length - 1; num++)
								{
									((buLinearPath)this).Vertices.Add(new Point3D(linearPath.Vertices[num].X, linearPath.Vertices[num].Y, linearPath.Vertices[num].Z));
								}
							}
						}
						else
						{
							Ellipse ellipse = copiedEntity as Ellipse;
							((buEllipse)this).Plane = (Plane)ellipse.Plane.Clone();
							((buEllipse)this).Center = new Point3D(ellipse.Center.X, ellipse.Center.Y, ellipse.Center.Z);
							StartPoint = new Point3D(ellipse.StartPoint.X, ellipse.StartPoint.Y, ellipse.StartPoint.Z);
							EndPoint = new Point3D(ellipse.EndPoint.X, ellipse.EndPoint.Y, ellipse.EndPoint.Z);
						}
					}
					else
					{
						Circle circle = copiedEntity as Circle;
						((buCircle)this).Plane = (Plane)circle.Plane.Clone();
						((buCircle)this).Center = new Point3D(circle.Center.X, circle.Center.Y, circle.Center.Z);
						StartPoint = new Point3D(circle.StartPoint.X, circle.StartPoint.Y, circle.StartPoint.Z);
						EndPoint = new Point3D(circle.EndPoint.X, circle.EndPoint.Y, circle.EndPoint.Z);
					}
				}
				else
				{
					Arc arc = copiedEntity as Arc;
					((buArc)this).Plane = (Plane)arc.Plane.Clone();
					((buArc)this).Center = new Point3D(arc.Center.X, arc.Center.Y, arc.Center.Z);
					StartPoint = new Point3D(arc.StartPoint.X, arc.StartPoint.Y, arc.StartPoint.Z);
					MiddlePoint = new Point3D(arc.MidPoint.X, arc.MidPoint.Y, arc.MidPoint.Z);
					EndPoint = new Point3D(arc.EndPoint.X, arc.EndPoint.Y, arc.EndPoint.Z);
				}
			}
			else
			{
				Line line = copiedEntity as Line;
				StartPoint = new Point3D(line.StartPoint.X, line.StartPoint.Y, line.StartPoint.Z);
				EndPoint = new Point3D(line.EndPoint.X, line.EndPoint.Y, line.EndPoint.Z);
			}
		}
		else
		{
			devDept.Eyeshot.Entities.Point point = copiedEntity as devDept.Eyeshot.Entities.Point;
			StartPoint = new Point3D(point.StartPoint.X, point.StartPoint.Y, point.StartPoint.Z);
		}
		Regen(copiedEntity);
	}

	public void Mirror(Point3D BasePoint, Point3D MirrorPoint, Plane planeMirror)
	{
		try
		{
			Entity copiedEntity = null;
			Copy(this, ref copiedEntity);
			Vector3D x = new Vector3D(BasePoint, MirrorPoint);
			Plane plane = new Plane(BasePoint, x, planeMirror.AxisZ);
			Mirror xform = new Mirror(plane);
			copiedEntity.TransformBy(xform);
			if (!(GetType() == typeof(buPoint)))
			{
				if (!(GetType() == typeof(buLine)))
				{
					if (!(GetType() == typeof(buArc)))
					{
						if (!(GetType() == typeof(buCircle)))
						{
							if (!(GetType() == typeof(buEllipse)))
							{
								if (!(GetType() == typeof(buLinearPath)))
								{
									if (!(GetType() == typeof(buCurve)))
									{
										if (!(GetType() == typeof(buCompositeCurve)))
										{
											if (!(GetType() == typeof(buRegion)))
											{
												if (!(GetType() == typeof(buMesh)))
												{
													if (!(GetType() == typeof(buText)))
													{
														if (GetType() == typeof(buMultilineText))
														{
															MultilineText multilineText = copiedEntity as MultilineText;
															((buMultilineText)this).InsertionPoint = new Point3D(multilineText.InsertionPoint.X, multilineText.InsertionPoint.Y, multilineText.InsertionPoint.Z);
															((buMultilineText)this).Vertices.Clear();
															if (multilineText.Vertices != null)
															{
																for (int i = 0; i <= multilineText.Vertices.Length - 1; i++)
																{
																	((buMultilineText)this).Vertices.Add(new Point3D(multilineText.Vertices[i].X, multilineText.Vertices[i].Y, multilineText.Vertices[i].Z));
																}
															}
														}
													}
													else
													{
														Text text = copiedEntity as Text;
														((buText)this).InsertionPoint = new Point3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
														((buText)this).Vertices.Clear();
														if (text.Vertices != null)
														{
															for (int j = 0; j <= text.Vertices.Length - 1; j++)
															{
																((buText)this).Vertices.Add(new Point3D(text.Vertices[j].X, text.Vertices[j].Y, text.Vertices[j].Z));
															}
														}
													}
												}
												else
												{
													Mesh mesh = copiedEntity as Mesh;
													((buMesh)this).Vertices.Clear();
													for (int k = 0; k <= mesh.Vertices.Length - 1; k++)
													{
														((buMesh)this).Vertices.Add(new Point3D(mesh.Vertices[k].X, mesh.Vertices[k].Y, mesh.Vertices[k].Z));
													}
												}
											}
											else
											{
												devDept.Eyeshot.Entities.Region region = copiedEntity as devDept.Eyeshot.Entities.Region;
												((buRegion)this).CurveList.Clear();
												for (int l = 0; l <= region.ContourList.Count - 1; l++)
												{
													Entity copiedEntity2 = null;
													Copy((Entity)region.ContourList[l], ref copiedEntity2);
													((buRegion)this).CurveList.Add(Copy(copiedEntity2));
												}
											}
										}
										else
										{
											CompositeCurve compositeCurve = copiedEntity as CompositeCurve;
											StartPoint = new Point3D(compositeCurve.StartPoint.X, compositeCurve.StartPoint.Y, compositeCurve.StartPoint.Z);
											EndPoint = new Point3D(compositeCurve.EndPoint.X, compositeCurve.EndPoint.Y, compositeCurve.EndPoint.Z);
											((buCompositeCurve)this).CurveList.Clear();
											for (int m = 0; m <= compositeCurve.CurveList.Count - 1; m++)
											{
												Entity copiedEntity3 = null;
												Copy((Entity)compositeCurve.CurveList[m], ref copiedEntity3);
												((buCompositeCurve)this).CurveList.Add(Copy(copiedEntity3));
											}
										}
									}
									else
									{
										Curve curve = copiedEntity as Curve;
										StartPoint = new Point3D(curve.StartPoint.X, curve.StartPoint.Y, curve.StartPoint.Z);
										EndPoint = new Point3D(curve.EndPoint.X, curve.EndPoint.Y, curve.EndPoint.Z);
										((buCurve)this).ControlPoints.Clear();
										for (int n = 0; n <= curve.ControlPoints.Length - 1; n++)
										{
											((buCurve)this).ControlPoints.Add(new Point4D(curve.ControlPoints[n].X, curve.ControlPoints[n].Y, curve.ControlPoints[n].Z, curve.ControlPoints[n].W));
										}
									}
								}
								else
								{
									LinearPath linearPath = copiedEntity as LinearPath;
									StartPoint = new Point3D(linearPath.StartPoint.X, linearPath.StartPoint.Y, linearPath.StartPoint.Z);
									EndPoint = new Point3D(linearPath.EndPoint.X, linearPath.EndPoint.Y, linearPath.EndPoint.Z);
									((buLinearPath)this).Vertices.Clear();
									for (int num = 0; num <= linearPath.Vertices.Length - 1; num++)
									{
										((buLinearPath)this).Vertices.Add(new Point3D(linearPath.Vertices[num].X, linearPath.Vertices[num].Y, linearPath.Vertices[num].Z));
									}
								}
							}
							else
							{
								Ellipse ellipse = copiedEntity as Ellipse;
								((buEllipse)this).Plane = (Plane)ellipse.Plane.Clone();
								((buEllipse)this).Center = new Point3D(ellipse.Center.X, ellipse.Center.Y, ellipse.Center.Z);
								StartPoint = new Point3D(ellipse.StartPoint.X, ellipse.StartPoint.Y, ellipse.StartPoint.Z);
								EndPoint = new Point3D(ellipse.EndPoint.X, ellipse.EndPoint.Y, ellipse.EndPoint.Z);
							}
						}
						else
						{
							Circle circle = copiedEntity as Circle;
							((buCircle)this).Plane = (Plane)circle.Plane.Clone();
							((buCircle)this).Center = new Point3D(circle.Center.X, circle.Center.Y, circle.Center.Z);
							StartPoint = new Point3D(circle.StartPoint.X, circle.StartPoint.Y, circle.StartPoint.Z);
							EndPoint = new Point3D(circle.EndPoint.X, circle.EndPoint.Y, circle.EndPoint.Z);
						}
					}
					else
					{
						Arc arc = copiedEntity as Arc;
						((buArc)this).Plane = (Plane)arc.Plane.Clone();
						((buArc)this).Center = new Point3D(arc.Center.X, arc.Center.Y, arc.Center.Z);
						StartPoint = new Point3D(arc.StartPoint.X, arc.StartPoint.Y, arc.StartPoint.Z);
						MiddlePoint = new Point3D(arc.MidPoint.X, arc.MidPoint.Y, arc.MidPoint.Z);
						EndPoint = new Point3D(arc.EndPoint.X, arc.EndPoint.Y, arc.EndPoint.Z);
					}
				}
				else
				{
					Line line = copiedEntity as Line;
					StartPoint = new Point3D(line.StartPoint.X, line.StartPoint.Y, line.StartPoint.Z);
					EndPoint = new Point3D(line.EndPoint.X, line.EndPoint.Y, line.EndPoint.Z);
				}
			}
			else
			{
				devDept.Eyeshot.Entities.Point point = copiedEntity as devDept.Eyeshot.Entities.Point;
				StartPoint = new Point3D(point.StartPoint.X, point.StartPoint.Y, point.StartPoint.Z);
			}
			Regen(copiedEntity);
		}
		catch (Exception mSException)
		{
			string text2 = "";
			buLog.addLog(text2, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text2);
		}
	}

	public void TransformBy(Transformation T)
	{
		try
		{
			Entity copiedEntity = null;
			Copy(this, ref copiedEntity);
			copiedEntity.TransformBy(T);
			if (!(GetType() == typeof(buPoint)))
			{
				if (!(GetType() == typeof(buLine)))
				{
					if (!(GetType() == typeof(buArc)))
					{
						if (!(GetType() == typeof(buCircle)))
						{
							if (!(GetType() == typeof(buEllipse)))
							{
								if (!(GetType() == typeof(buLinearPath)))
								{
									if (!(GetType() == typeof(buCurve)))
									{
										if (!(GetType() == typeof(buCompositeCurve)))
										{
											if (!(GetType() == typeof(buRegion)))
											{
												if (!(GetType() == typeof(buMesh)))
												{
													if (!(GetType() == typeof(buText)))
													{
														if (GetType() == typeof(buMultilineText))
														{
															MultilineText multilineText = copiedEntity as MultilineText;
															((buMultilineText)this).InsertionPoint = new Point3D(multilineText.InsertionPoint.X, multilineText.InsertionPoint.Y, multilineText.InsertionPoint.Z);
															((buMultilineText)this).Vertices.Clear();
															if (multilineText.Vertices != null)
															{
																for (int i = 0; i <= multilineText.Vertices.Length - 1; i++)
																{
																	((buMultilineText)this).Vertices.Add(new Point3D(multilineText.Vertices[i].X, multilineText.Vertices[i].Y, multilineText.Vertices[i].Z));
																}
															}
														}
													}
													else
													{
														Text text = copiedEntity as Text;
														((buText)this).InsertionPoint = new Point3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
														((buText)this).Vertices.Clear();
														if (text.Vertices != null)
														{
															for (int j = 0; j <= text.Vertices.Length - 1; j++)
															{
																((buText)this).Vertices.Add(new Point3D(text.Vertices[j].X, text.Vertices[j].Y, text.Vertices[j].Z));
															}
														}
													}
												}
												else
												{
													Mesh mesh = copiedEntity as Mesh;
													((buMesh)this).Vertices.Clear();
													for (int k = 0; k <= mesh.Vertices.Length - 1; k++)
													{
														((buMesh)this).Vertices.Add(new Point3D(mesh.Vertices[k].X, mesh.Vertices[k].Y, mesh.Vertices[k].Z));
													}
												}
											}
											else
											{
												devDept.Eyeshot.Entities.Region region = copiedEntity as devDept.Eyeshot.Entities.Region;
												((buRegion)this).CurveList.Clear();
												for (int l = 0; l <= region.ContourList.Count - 1; l++)
												{
													Entity copiedEntity2 = null;
													Copy((Entity)region.ContourList[l], ref copiedEntity2);
													((buRegion)this).CurveList.Add(Copy(copiedEntity2));
												}
											}
										}
										else
										{
											CompositeCurve compositeCurve = copiedEntity as CompositeCurve;
											StartPoint = new Point3D(compositeCurve.StartPoint.X, compositeCurve.StartPoint.Y, compositeCurve.StartPoint.Z);
											EndPoint = new Point3D(compositeCurve.EndPoint.X, compositeCurve.EndPoint.Y, compositeCurve.EndPoint.Z);
											((buCompositeCurve)this).CurveList.Clear();
											for (int m = 0; m <= compositeCurve.CurveList.Count - 1; m++)
											{
												Entity copiedEntity3 = null;
												Copy((Entity)compositeCurve.CurveList[m], ref copiedEntity3);
												((buCompositeCurve)this).CurveList.Add(Copy(copiedEntity3));
											}
										}
									}
									else
									{
										Curve curve = copiedEntity as Curve;
										StartPoint = new Point3D(curve.StartPoint.X, curve.StartPoint.Y, curve.StartPoint.Z);
										EndPoint = new Point3D(curve.EndPoint.X, curve.EndPoint.Y, curve.EndPoint.Z);
										((buCurve)this).ControlPoints.Clear();
										for (int n = 0; n <= curve.ControlPoints.Length - 1; n++)
										{
											((buCurve)this).ControlPoints.Add(new Point4D(curve.ControlPoints[n].X, curve.ControlPoints[n].Y, curve.ControlPoints[n].Z, curve.ControlPoints[n].W));
										}
									}
								}
								else
								{
									LinearPath linearPath = copiedEntity as LinearPath;
									StartPoint = new Point3D(linearPath.StartPoint.X, linearPath.StartPoint.Y, linearPath.StartPoint.Z);
									EndPoint = new Point3D(linearPath.EndPoint.X, linearPath.EndPoint.Y, linearPath.EndPoint.Z);
								}
							}
							else
							{
								Ellipse ellipse = copiedEntity as Ellipse;
								((buEllipse)this).Plane = (Plane)ellipse.Plane.Clone();
								((buEllipse)this).Center = new Point3D(ellipse.Center.X, ellipse.Center.Y, ellipse.Center.Z);
								StartPoint = new Point3D(ellipse.StartPoint.X, ellipse.StartPoint.Y, ellipse.StartPoint.Z);
								EndPoint = new Point3D(ellipse.EndPoint.X, ellipse.EndPoint.Y, ellipse.EndPoint.Z);
							}
						}
						else
						{
							Circle circle = copiedEntity as Circle;
							((buCircle)this).Plane = (Plane)circle.Plane.Clone();
							((buCircle)this).Center = new Point3D(circle.Center.X, circle.Center.Y, circle.Center.Z);
							StartPoint = new Point3D(circle.StartPoint.X, circle.StartPoint.Y, circle.StartPoint.Z);
							EndPoint = new Point3D(circle.EndPoint.X, circle.EndPoint.Y, circle.EndPoint.Z);
						}
					}
					else
					{
						Arc arc = copiedEntity as Arc;
						((buArc)this).Plane = (Plane)arc.Plane.Clone();
						((buArc)this).Center = new Point3D(arc.Center.X, arc.Center.Y, arc.Center.Z);
						StartPoint = new Point3D(arc.StartPoint.X, arc.StartPoint.Y, arc.StartPoint.Z);
						MiddlePoint = new Point3D(arc.MidPoint.X, arc.MidPoint.Y, arc.MidPoint.Z);
						EndPoint = new Point3D(arc.EndPoint.X, arc.EndPoint.Y, arc.EndPoint.Z);
					}
				}
				else
				{
					Line line = copiedEntity as Line;
					StartPoint = new Point3D(line.StartPoint.X, line.StartPoint.Y, line.StartPoint.Z);
					EndPoint = new Point3D(line.EndPoint.X, line.EndPoint.Y, line.EndPoint.Z);
				}
			}
			else
			{
				devDept.Eyeshot.Entities.Point point = copiedEntity as devDept.Eyeshot.Entities.Point;
				StartPoint = new Point3D(point.StartPoint.X, point.StartPoint.Y, point.StartPoint.Z);
			}
			Regen(copiedEntity);
		}
		catch (Exception mSException)
		{
			string text2 = "";
			buLog.addLog(text2, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text2);
		}
	}

	public static buEntity Copy(buEntity refEntity)
	{
		if (refEntity != null)
		{
			buEntity buEntity2 = null;
			if (!(refEntity.GetType() == typeof(buPoint)))
			{
				if (!(refEntity.GetType() == typeof(buLine)))
				{
					if (!(refEntity.GetType() == typeof(buArc)))
					{
						if (!(refEntity.GetType() == typeof(buCircle)))
						{
							if (!(refEntity.GetType() == typeof(buEllipse)))
							{
								if (!(refEntity.GetType() == typeof(buLinearPath)))
								{
									if (!(refEntity.GetType() == typeof(buCurve)))
									{
										if (!(refEntity.GetType() == typeof(buCompositeCurve)))
										{
											if (!(refEntity.GetType() == typeof(buUpperLine)))
											{
												if (!(refEntity.GetType() == typeof(buRegion)))
												{
													if (!(refEntity.GetType() == typeof(buMesh)))
													{
														if (!(refEntity.GetType() == typeof(buLinearDim)))
														{
															if (!(refEntity.GetType() == typeof(buAngularDim)))
															{
																if (!(refEntity.GetType() == typeof(buDiametricDim)))
																{
																	if (!(refEntity.GetType() == typeof(buRadialDim)))
																	{
																		if (!(refEntity.GetType() == typeof(buOrdinateDim)))
																		{
																			if (!(refEntity.GetType() == typeof(buText)))
																			{
																				if (refEntity.GetType() == typeof(buMultilineText))
																				{
																					buEntity2 = new buMultilineText((buMultilineText)refEntity);
																				}
																			}
																			else
																			{
																				buEntity2 = new buText((buText)refEntity);
																			}
																		}
																		else
																		{
																			buEntity2 = new buOrdinateDim((buOrdinateDim)refEntity);
																		}
																	}
																	else
																	{
																		buEntity2 = new buRadialDim((buRadialDim)refEntity);
																	}
																}
																else
																{
																	buEntity2 = new buDiametricDim((buDiametricDim)refEntity);
																}
															}
															else
															{
																buEntity2 = new buAngularDim((buAngularDim)refEntity);
															}
														}
														else
														{
															buEntity2 = new buLinearDim((buLinearDim)refEntity);
														}
													}
													else
													{
														buEntity2 = new buMesh((buMesh)refEntity);
													}
												}
												else
												{
													buEntity2 = new buRegion((buRegion)refEntity);
												}
											}
											else
											{
												buEntity2 = new buUpperLine((buUpperLine)refEntity);
											}
										}
										else
										{
											buEntity2 = new buCompositeCurve((buCompositeCurve)refEntity);
										}
									}
									else
									{
										buEntity2 = new buCurve((buCurve)refEntity);
									}
								}
								else
								{
									buEntity2 = new buLinearPath((buLinearPath)refEntity);
								}
							}
							else
							{
								buEntity2 = new buEllipse((buEllipse)refEntity);
							}
						}
						else
						{
							buEntity2 = new buCircle((buCircle)refEntity);
						}
					}
					else
					{
						buEntity2 = new buArc((buArc)refEntity);
					}
				}
				else
				{
					buEntity2 = new buLine((buLine)refEntity);
				}
			}
			else
			{
				buEntity2 = new buPoint((buPoint)refEntity);
			}
			if (refEntity.Marble != null)
			{
				buEntity2.Marble = new MarbleInfo(refEntity.Marble);
			}
			if (refEntity.Sewing != null)
			{
				buEntity2.Sewing = new SewingInfo(refEntity.Sewing);
			}
			if (refEntity.Shape != null)
			{
				buEntity2.Shape = new EntityShapeInfo(refEntity.Shape);
			}
			if (refEntity.Info != null)
			{
				buEntity2.Info = new EntityInfo(refEntity.Info);
			}
			if (refEntity.Cutter != null)
			{
				buEntity2.Cutter = new CutterInfo(refEntity.Cutter);
			}
			if (refEntity.Dimension != null)
			{
				buEntity2.Dimension = new DimensionInfo(refEntity.Dimension);
			}
			return buEntity2;
		}
		return null;
	}

	public static void Copy(buEntity refEntity, ref Entity copiedEntity, bool CheckDuplicated = false, double Resolution = 0.001)
	{
		if (refEntity == null)
		{
			return;
		}
		if (!(refEntity.GetType() == typeof(buPoint)))
		{
			if (!(refEntity.GetType() == typeof(buLine)))
			{
				if (!(refEntity.GetType() == typeof(buUpperLine)))
				{
					if (!(refEntity.GetType() == typeof(buArc)))
					{
						if (!(refEntity.GetType() == typeof(buCircle)))
						{
							if (!(refEntity.GetType() == typeof(buEllipse)))
							{
								if (!(refEntity.GetType() == typeof(buLinearPath)))
								{
									if (!(refEntity.GetType() == typeof(buCurve)))
									{
										if (!(refEntity.GetType() == typeof(buCompositeCurve)))
										{
											if (!(refEntity.GetType() == typeof(buRegion)))
											{
												if (!(refEntity.GetType() == typeof(buMesh)))
												{
													if (!(refEntity.GetType() == typeof(buLinearDim)))
													{
														if (!(refEntity.GetType() == typeof(buAngularDim)))
														{
															if (!(refEntity.GetType() == typeof(buDiametricDim)))
															{
																if (!(refEntity.GetType() == typeof(buRadialDim)))
																{
																	if (!(refEntity.GetType() == typeof(buOrdinateDim)))
																	{
																		if (!(refEntity.GetType() == typeof(buText)))
																		{
																			if (refEntity.GetType() == typeof(buMultilineText))
																			{
																				if (((buMultilineText)refEntity).StyleName.Length != 0)
																				{
																					copiedEntity = new MultilineText(((buMultilineText)refEntity).Plane, ((buMultilineText)refEntity).InsertionPoint, ((buMultilineText)refEntity).TextString, ((buMultilineText)refEntity).RectWidth, ((buMultilineText)refEntity).Height, ((buMultilineText)refEntity).LineSpaceDistance, ((buMultilineText)refEntity).Alignment, ((buMultilineText)refEntity).StyleName, ((buMultilineText)refEntity).Simplify, ((buMultilineText)refEntity).Wrap);
																				}
																				else
																				{
																					copiedEntity = new MultilineText(((buMultilineText)refEntity).Plane, ((buMultilineText)refEntity).InsertionPoint, ((buMultilineText)refEntity).TextString, ((buMultilineText)refEntity).RectWidth, ((buMultilineText)refEntity).Height, ((buMultilineText)refEntity).LineSpaceDistance, ((buMultilineText)refEntity).Alignment);
																				}
																			}
																		}
																		else if (((buText)refEntity).StyleName.Length != 0)
																		{
																			copiedEntity = new Text(((buText)refEntity).Plane, ((buText)refEntity).InsertionPoint, ((buText)refEntity).TextString, ((buText)refEntity).Height, ((buText)refEntity).Alignment, ((buText)refEntity).StyleName, ((buText)refEntity).Simplify);
																		}
																		else
																		{
																			copiedEntity = new Text(((buText)refEntity).Plane, ((buText)refEntity).InsertionPoint, ((buText)refEntity).TextString, ((buText)refEntity).Height, ((buText)refEntity).Alignment);
																		}
																	}
																	else
																	{
																		copiedEntity = new OrdinateDim(((buOrdinateDim)refEntity).Plane, ((buOrdinateDim)refEntity).DefiningPoint, ((buOrdinateDim)refEntity).DimLinePosition, ((buOrdinateDim)refEntity).isVertical, ((buOrdinateDim)refEntity).Height);
																		if (((buOrdinateDim)refEntity).TextOverride.Trim().Length > 0)
																		{
																			((OrdinateDim)copiedEntity).TextOverride = ((buOrdinateDim)refEntity).TextOverride;
																		}
																	}
																}
																else
																{
																	Circle circle = new Circle(((buRadialDim)refEntity).Plane, ((buRadialDim)refEntity).Origin, ((buRadialDim)refEntity).Radius);
																	copiedEntity = new RadialDim(circle, ((buRadialDim)refEntity).DimLinePosition, ((buRadialDim)refEntity).Height);
																	if (((buRadialDim)refEntity).TextOverride.Trim().Length > 0)
																	{
																		((RadialDim)copiedEntity).TextOverride = ((buRadialDim)refEntity).TextOverride;
																	}
																}
															}
															else
															{
																Circle circle2 = new Circle(((buDiametricDim)refEntity).Plane, ((buDiametricDim)refEntity).Origin, ((buDiametricDim)refEntity).Radius);
																copiedEntity = new DiametricDim(circle2, ((buDiametricDim)refEntity).DimLinePosition, ((buDiametricDim)refEntity).Height);
																if (((buDiametricDim)refEntity).TextOverride.Trim().Length > 0)
																{
																	((DiametricDim)copiedEntity).TextOverride = ((buDiametricDim)refEntity).TextOverride;
																}
															}
														}
														else
														{
															copiedEntity = new AngularDim(((buAngularDim)refEntity).Plane, ((buAngularDim)refEntity).ExtLine1, ((buAngularDim)refEntity).ExtLine2, ((buAngularDim)refEntity).DimLinePosition, ((buAngularDim)refEntity).Height);
															if (((buAngularDim)refEntity).TextOverride.Trim().Length > 0)
															{
																((AngularDim)copiedEntity).TextOverride = ((buAngularDim)refEntity).TextOverride;
															}
														}
													}
													else
													{
														copiedEntity = new LinearDim(((buLinearDim)refEntity).Plane, ((buLinearDim)refEntity).ExtLine1, ((buLinearDim)refEntity).ExtLine2, ((buLinearDim)refEntity).DimLinePosition, ((buLinearDim)refEntity).Height);
														if (((buLinearDim)refEntity).TextOverride.Trim().Length > 0)
														{
															((LinearDim)copiedEntity).TextOverride = ((buLinearDim)refEntity).TextOverride;
														}
													}
												}
												else
												{
													List<Point3D> copiedPoint = new List<Point3D>();
													List<IndexTriangle> list = new List<IndexTriangle>();
													buVector5.Copy(refEntity.Vertices, ref copiedPoint);
													for (int i = 0; i <= ((buMesh)refEntity).Triangles.Count - 1; i++)
													{
														list.Add(new IndexTriangle(((buMesh)refEntity).Triangles[i].V1, ((buMesh)refEntity).Triangles[i].V2, ((buMesh)refEntity).Triangles[i].V3));
													}
													copiedEntity = new Mesh(copiedPoint, list);
												}
											}
											else
											{
												List<ICurve> list2 = new List<ICurve>();
												for (int j = 0; j <= ((buRegion)refEntity).CurveList.Count - 1; j++)
												{
													Entity copiedEntity2 = null;
													Copy(((buRegion)refEntity).CurveList[j], ref copiedEntity2);
													list2.Add((ICurve)copiedEntity2);
												}
												copiedEntity = new CompositeCurve(list2);
											}
										}
										else
										{
											List<ICurve> list3 = new List<ICurve>();
											for (int k = 0; k <= ((buCompositeCurve)refEntity).CurveList.Count - 1; k++)
											{
												Entity copiedEntity3 = null;
												Copy(((buCompositeCurve)refEntity).CurveList[k], ref copiedEntity3);
												list3.Add((ICurve)copiedEntity3);
											}
											copiedEntity = new CompositeCurve(list3, sortAndOrient: true);
										}
									}
									else if (!((buCurve)refEntity).isRational)
									{
										List<Point3D> list4 = new List<Point3D>();
										for (int l = 0; l <= ((buCurve)refEntity).ControlPoints.Count - 1; l++)
										{
											list4.Add(new Point3D(((buCurve)refEntity).ControlPoints[l].X, ((buCurve)refEntity).ControlPoints[l].Y, ((buCurve)refEntity).ControlPoints[l].Z));
										}
										copiedEntity = new Curve(((buCurve)refEntity).Degree, list4);
									}
									else
									{
										List<Point4D> list5 = new List<Point4D>();
										for (int m = 0; m <= ((buCurve)refEntity).ControlPoints.Count - 1; m++)
										{
											list5.Add(new Point4D(((buCurve)refEntity).ControlPoints[m].X, ((buCurve)refEntity).ControlPoints[m].Y, ((buCurve)refEntity).ControlPoints[m].Z, ((buCurve)refEntity).ControlPoints[m].W));
										}
										copiedEntity = new Curve(((buCurve)refEntity).Degree, ((buCurve)refEntity).KnotVector.ToArray(), ((buCurve)refEntity).ControlPoints.ToArray());
									}
								}
								else
								{
									copiedEntity = new LinearPath(ToPoint3D(((buLinearPath)refEntity).Vertices));
									if (CheckDuplicated)
									{
										FixVerticeDublicated(ref copiedEntity);
									}
								}
							}
							else
							{
								copiedEntity = new Ellipse(((buEllipse)refEntity).Plane, ToPoint3D(((buEllipse)refEntity).Center), ((buEllipse)refEntity).RadiusX, ((buEllipse)refEntity).RadiusY);
							}
						}
						else
						{
							copiedEntity = new Circle(((buCircle)refEntity).Plane, ToPoint3D(((buCircle)refEntity).Center), ((buCircle)refEntity).Radius);
						}
					}
					else if (buCompare5.EQ(((buArc)refEntity).Center, new Point3D()))
					{
						copiedEntity = new Arc(((buArc)refEntity).Plane, ToPoint3D(((buArc)refEntity).Center), ((buArc)refEntity).Radius, ToPoint3D(((buArc)refEntity).StartPoint), ToPoint3D(((buArc)refEntity).EndPoint), flip: false);
					}
					else
					{
						((buArc)refEntity).Plane.Origin = new Point3D();
						copiedEntity = new Arc(((buArc)refEntity).Plane, ToPoint3D(((buArc)refEntity).Center), ((buArc)refEntity).Radius, ToPoint3D(((buArc)refEntity).StartPoint), ToPoint3D(((buArc)refEntity).EndPoint), flip: false);
					}
				}
				else
				{
					copiedEntity = new Line(ToPoint3D(((buUpperLine)refEntity).StartPoint), ToPoint3D(((buUpperLine)refEntity).EndPoint));
				}
			}
			else
			{
				copiedEntity = new Line(ToPoint3D(((buLine)refEntity).StartPoint), ToPoint3D(((buLine)refEntity).EndPoint));
			}
		}
		else
		{
			copiedEntity = new devDept.Eyeshot.Entities.Point(ToPoint3D(((buPoint)refEntity).StartPoint));
		}
		if (copiedEntity != null)
		{
			CustomData CD = new CustomData();
			if (refEntity.LayerName.Length > 0)
			{
				copiedEntity.LayerName = refEntity.LayerName;
			}
			copiedEntity.Color = refEntity.Color;
			EntityToCustomData(refEntity, ref CD);
			copiedEntity.EntityData = CD;
		}
	}

	public static void Copy(Entity refEntity, ref buEntity copiedEntity, double Deviation = 0.01)
	{
		if (refEntity != null)
		{
			if (!(refEntity.GetType() == typeof(devDept.Eyeshot.Entities.Point)))
			{
				if (!(refEntity.GetType() == typeof(Line)))
				{
					if (!(refEntity.GetType() == typeof(buLineCam)))
					{
						if (!(refEntity.GetType() == typeof(Arc)))
						{
							if (!(refEntity.GetType() == typeof(buArcCam)))
							{
								if (!(refEntity.GetType() == typeof(Circle)))
								{
									if (!(refEntity.GetType() == typeof(Ellipse)))
									{
										if (!(refEntity.GetType() == typeof(LinearPath)))
										{
											if (!(refEntity.GetType() == typeof(LinearPathEx)))
											{
												if (!(refEntity.GetType() == typeof(EllipticalArc)))
												{
													if (!(refEntity.GetType() == typeof(buLinearPathCam)))
													{
														if (!(refEntity.GetType() == typeof(Curve)))
														{
															if (!(refEntity.GetType() == typeof(CompositeCurve)))
															{
																if (!(refEntity.GetType() == typeof(buCompositeCurveCam)))
																{
																	if (!(refEntity.GetType() == typeof(devDept.Eyeshot.Entities.Region)))
																	{
																		if (!(refEntity.GetType() == typeof(Mesh)))
																		{
																			if (!(refEntity.GetType() == typeof(LinearDim)))
																			{
																				if (!(refEntity.GetType() == typeof(AngularDim)))
																				{
																					if (!(refEntity.GetType() == typeof(DiametricDim)))
																					{
																						if (!(refEntity.GetType() == typeof(RadialDim)))
																						{
																							if (!(refEntity.GetType() == typeof(OrdinateDim)))
																							{
																								if (!(refEntity.GetType() == typeof(Text)))
																								{
																									if (refEntity.GetType() == typeof(MultilineText))
																									{
																										MultilineText another = refEntity as MultilineText;
																										copiedEntity = new buMultilineText(another);
																									}
																								}
																								else
																								{
																									Text another2 = refEntity as Text;
																									copiedEntity = new buText(another2);
																								}
																							}
																							else
																							{
																								OrdinateDim another3 = refEntity as OrdinateDim;
																								copiedEntity = new buOrdinateDim(another3);
																							}
																						}
																						else
																						{
																							RadialDim another4 = refEntity as RadialDim;
																							copiedEntity = new buRadialDim(another4);
																						}
																					}
																					else
																					{
																						DiametricDim another5 = refEntity as DiametricDim;
																						copiedEntity = new buDiametricDim(another5);
																					}
																				}
																				else
																				{
																					AngularDim another6 = refEntity as AngularDim;
																					copiedEntity = new buAngularDim(another6);
																				}
																			}
																			else
																			{
																				LinearDim another7 = refEntity as LinearDim;
																				copiedEntity = new buLinearDim(another7);
																			}
																		}
																		else
																		{
																			Mesh mesh = refEntity as Mesh;
																			copiedEntity = new buMesh(mesh.Vertices, mesh.Triangles);
																		}
																	}
																	else
																	{
																		devDept.Eyeshot.Entities.Region region = refEntity as devDept.Eyeshot.Entities.Region;
																		List<buEntity> list = new List<buEntity>();
																		for (int i = 0; i <= region.ContourList.Count - 1; i++)
																		{
																			buEntity copiedEntity2 = null;
																			Entity copiedEntity3 = null;
																			Copy((Entity)region.ContourList[i], ref copiedEntity3);
																			Copy(copiedEntity3, ref copiedEntity2);
																			list.Add(copiedEntity2);
																		}
																		copiedEntity = new buRegion(list);
																	}
																}
																else
																{
																	buCompositeCurveCam buCompositeCurveCam2 = refEntity as buCompositeCurveCam;
																	List<buEntity> list2 = new List<buEntity>();
																	for (int j = 0; j <= buCompositeCurveCam2.CurveList.Count - 1; j++)
																	{
																		buEntity copiedEntity4 = null;
																		Entity copiedEntity5 = null;
																		Copy((Entity)buCompositeCurveCam2.CurveList[j], ref copiedEntity5);
																		Copy(copiedEntity5, ref copiedEntity4);
																		list2.Add(copiedEntity4);
																	}
																	copiedEntity = new buCompositeCurve(list2);
																}
															}
															else
															{
																CompositeCurve compositeCurve = refEntity as CompositeCurve;
																List<buEntity> list3 = new List<buEntity>();
																for (int k = 0; k <= compositeCurve.CurveList.Count - 1; k++)
																{
																	buEntity copiedEntity6 = null;
																	Entity copiedEntity7 = null;
																	Copy((Entity)compositeCurve.CurveList[k], ref copiedEntity7);
																	Copy(copiedEntity7, ref copiedEntity6);
																	list3.Add(copiedEntity6);
																}
																copiedEntity = new buCompositeCurve(list3);
															}
														}
														else
														{
															Curve curve = refEntity as Curve;
															if (!curve.IsRational)
															{
																List<Point3D> list4 = new List<Point3D>();
																for (int l = 0; l <= curve.ControlPoints.Length - 1; l++)
																{
																	list4.Add(new Point3D(curve.ControlPoints[l].X, curve.ControlPoints[l].Y, curve.ControlPoints[l].Z));
																}
																copiedEntity = new buCurve(curve.Degree, list4);
															}
															else
															{
																copiedEntity = new buCurve(curve.Degree, curve.KnotVector, curve.ControlPoints);
															}
														}
													}
													else
													{
														buLinearPathCam buLinearPathCam2 = refEntity as buLinearPathCam;
														copiedEntity = new buLinearPath(buLinearPathCam2.Vertices.ToList());
													}
												}
												else
												{
													EllipticalArc ellipticalArc = refEntity as EllipticalArc;
													if (ellipticalArc.Vertices == null)
													{
														ellipticalArc.Regen(0.01);
													}
													copiedEntity = new buLinearPath(ellipticalArc.Vertices.ToList());
												}
											}
											else
											{
												LinearPathEx linearPathEx = refEntity as LinearPathEx;
												copiedEntity = new buLinearPath(linearPathEx.Vertices.ToList());
											}
										}
										else
										{
											LinearPath linearPath = refEntity as LinearPath;
											copiedEntity = new buLinearPath(linearPath.Vertices.ToList());
										}
									}
									else
									{
										Ellipse ellipse = refEntity as Ellipse;
										copiedEntity = new buEllipse(ellipse.Plane, ellipse.Center, ellipse.RadiusX, ellipse.RadiusY);
									}
								}
								else
								{
									Circle circle = refEntity as Circle;
									copiedEntity = new buCircle(circle.Plane, circle.Center, circle.Radius);
								}
							}
							else
							{
								buArcCam buArcCam2 = refEntity as buArcCam;
								copiedEntity = new buArc(buArcCam2.Plane, buArcCam2.Center, buArcCam2.Radius, buArcCam2.StartPoint, buArcCam2.EndPoint, flip: false);
								if (!buArcCam2.isReverse)
								{
									copiedEntity.sortDirection = entitySortDirection.Normal;
								}
								else
								{
									copiedEntity.sortDirection = entitySortDirection.Reverse;
								}
							}
						}
						else
						{
							Arc arc = refEntity as Arc;
							copiedEntity = new buArc(arc.Plane, arc.Center, arc.Radius, arc.StartPoint, arc.EndPoint, flip: false);
							if (!(buVector5.isPlaneXYorYX(arc.Plane) | buVector5.isPlaneXZorZX(arc.Plane) | buVector5.isPlaneYZorZY(arc.Plane)))
							{
								((buArc)copiedEntity).StartAngle = Math.Round(buConversion5.RadianToDegree(arc.Angle.t0), 8);
								((buArc)copiedEntity).EndAngle = Math.Round(buConversion5.RadianToDegree(arc.Angle.t1), 8);
							}
							else
							{
								((buArc)copiedEntity).StartAngle = buVector5.PointAngleByPlane(arc.StartPoint, arc.Center, arc.Plane);
								((buArc)copiedEntity).EndAngle = buVector5.PointAngleByPlane(arc.EndPoint, arc.Center, arc.Plane);
								((buArc)copiedEntity).StartAngle = Math.Round(buConversion5.RadianToDegree(arc.Angle.t0), 8);
								((buArc)copiedEntity).EndAngle = Math.Round(buConversion5.RadianToDegree(arc.Angle.t1), 8);
							}
						}
					}
					else
					{
						buLineCam buLineCam2 = refEntity as buLineCam;
						copiedEntity = new buLine(buLineCam2.StartPoint, buLineCam2.EndPoint);
					}
				}
				else
				{
					Line line = refEntity as Line;
					copiedEntity = new buLine(line.StartPoint, line.EndPoint);
				}
			}
			else
			{
				devDept.Eyeshot.Entities.Point point = refEntity as devDept.Eyeshot.Entities.Point;
				copiedEntity = new buPoint(point.StartPoint);
			}
			if (buVector5.baseModel == null)
			{
				refEntity.Regen(buSystem.RegenDeviation);
			}
			else
			{
				try
				{
					refEntity.Regen(new RegenParams(buSystem.RegenDeviation, buVector5.baseModel));
				}
				catch (Exception)
				{
				}
			}
			if (copiedEntity == null)
			{
				return;
			}
			copiedEntity.LayerName = refEntity.LayerName;
			copiedEntity.Color = refEntity.Color;
			if (buCall.list_0 != null && buCall.list_0.Count > 0)
			{
				Color colorLayer = refEntity.Color;
				if (buEyeShotFunctions.GetLayerColorFromName(refEntity.LayerName, ref colorLayer))
				{
					copiedEntity.Color = colorLayer;
				}
			}
			if (refEntity.BoxMax != null)
			{
				copiedEntity.BoxMax = new Point3D(refEntity.BoxMax.X, refEntity.BoxMax.Y, refEntity.BoxMax.Z);
				copiedEntity.BoxMin = new Point3D(refEntity.BoxMin.X, refEntity.BoxMin.Y, refEntity.BoxMin.Z);
			}
			if (refEntity.EntityData != null && refEntity.EntityData is CustomData)
			{
				CustomDataToEntity((CustomData)refEntity.EntityData, ref copiedEntity);
			}
		}
		else
		{
			copiedEntity = null;
		}
	}

	public static void Copy(buEntitiesGroup EntGroup, ref List<buEntity> copiedEntity, bool Inside = true, bool OpenEntities = true, bool Solid = false, bool Text = false)
	{
		copiedEntity.Clear();
		if (EntGroup.Outside.Entities.Count > 0)
		{
			Add(EntGroup.Outside.Entities, ref copiedEntity);
		}
		if (EntGroup.Inside != null && EntGroup.Inside.Count > 0 && Inside)
		{
			for (int i = 0; i <= EntGroup.Inside.Count - 1; i++)
			{
				Add(EntGroup.Inside[i].Entities, ref copiedEntity);
			}
		}
		if (EntGroup.OpenEntities != null && EntGroup.OpenEntities.Count > 0 && OpenEntities)
		{
			for (int j = 0; j <= EntGroup.OpenEntities.Count - 1; j++)
			{
				Add(EntGroup.OpenEntities[j].Entities, ref copiedEntity);
			}
		}
		if (EntGroup.Text != null && EntGroup.Text.Entities.Count > 0 && Text)
		{
			Add(EntGroup.Text.Entities, ref copiedEntity);
		}
		if (EntGroup.Solid != null && EntGroup.Solid.Entities.Count > 0 && Solid)
		{
			Add(EntGroup.Text.Entities, ref copiedEntity);
		}
	}

	public static void Copy(buEntitiesGroup EntGroup, ref List<Entity> copiedEntity, bool Inside = true, bool OpenEntities = true, bool Solid = false, bool Text = false)
	{
		copiedEntity.Clear();
		if (EntGroup.Outside.Entities.Count > 0)
		{
			Add(EntGroup.Outside.Entities, ref copiedEntity);
		}
		if (EntGroup.Inside != null && EntGroup.Inside.Count > 0 && Inside)
		{
			for (int i = 0; i <= EntGroup.Inside.Count - 1; i++)
			{
				Add(EntGroup.Inside[i].Entities, ref copiedEntity);
			}
		}
		if (EntGroup.OpenEntities != null && EntGroup.OpenEntities.Count > 0 && OpenEntities)
		{
			for (int j = 0; j <= EntGroup.OpenEntities.Count - 1; j++)
			{
				Add(EntGroup.OpenEntities[j].Entities, ref copiedEntity);
			}
		}
		if (EntGroup.Text != null && EntGroup.Text.Entities.Count > 0 && Text)
		{
			Add(EntGroup.Text.Entities, ref copiedEntity);
		}
		if (EntGroup.Solid != null && EntGroup.Solid.Entities.Count > 0 && Solid)
		{
			Add(EntGroup.Solid.Entities, ref copiedEntity);
		}
	}

	public static void Copy(ICurve refEntity, ref buEntity copiedEntity, double Deviation = 0.01)
	{
		Entity refEntity2 = (Entity)refEntity;
		Copy(refEntity2, ref copiedEntity, Deviation);
	}

	public static buEntity Copy(Entity refEntity)
	{
		buEntity copiedEntity = null;
		Copy(refEntity, ref copiedEntity);
		return copiedEntity;
	}

	public static void Copy(buEntity refEntity, ref buEntity copiedEntity)
	{
		copiedEntity = Copy(refEntity);
	}

	public static List<buEntity> Copy(List<buEntity> refEntities)
	{
		List<buEntity> list = new List<buEntity>();
		if (refEntities != null)
		{
			for (int i = 0; i <= refEntities.Count - 1; i++)
			{
				buEntity item = Copy(refEntities[i]);
				list.Add(item);
			}
		}
		return list;
	}

	public static void Copy(List<buEntity> refEntities, ref List<Entity> copiedEntities)
	{
		for (int i = 0; i <= refEntities.Count - 1; i++)
		{
			Entity copiedEntity = null;
			Copy(refEntities[i], ref copiedEntity);
			if (copiedEntity != null)
			{
				copiedEntities.Add(copiedEntity);
			}
		}
	}

	public static void Copy(List<List<buEntity>> refEntities, ref List<List<Entity>> copiedEntities)
	{
		for (int i = 0; i <= refEntities.Count - 1; i++)
		{
			List<Entity> copiedEntities2 = new List<Entity>();
			Copy(refEntities[i], ref copiedEntities2);
			if (copiedEntities2.Count > 0)
			{
				copiedEntities.Add(copiedEntities2);
			}
		}
	}

	public static void Copy(List<buEntity> refEntities, ref List<ICurve> copiedEntities)
	{
		for (int i = 0; i <= refEntities.Count - 1; i++)
		{
			Entity copiedEntity = null;
			Copy(refEntities[i], ref copiedEntity);
			if (copiedEntity != null && copiedEntity is ICurve)
			{
				copiedEntities.Add((ICurve)copiedEntity);
			}
		}
	}

	public static void Copy(List<Entity> refEntities, ref List<buEntity> copiedEntities)
	{
		for (int i = 0; i <= refEntities.Count - 1; i++)
		{
			buEntity copiedEntity = null;
			Copy(refEntities[i], ref copiedEntity);
			if (copiedEntity != null)
			{
				copiedEntities.Add(copiedEntity);
			}
		}
	}

	public static void Copy(List<List<Entity>> refEntities, ref List<List<buEntity>> copiedEntities)
	{
		for (int i = 0; i <= refEntities.Count - 1; i++)
		{
			List<buEntity> copiedEntities2 = new List<buEntity>();
			Copy(refEntities[i], ref copiedEntities2);
			if (copiedEntities2 != null && copiedEntities2.Count > 0)
			{
				copiedEntities.Add(copiedEntities2);
			}
		}
	}

	public static void Copy(List<ICurve> refEntities, ref List<buEntity> copiedEntities)
	{
		List<Entity> list = new List<Entity>();
		for (int i = 0; i <= refEntities.Count - 1; i++)
		{
			list.Add((Entity)refEntities[i]);
		}
		Copy(list, ref copiedEntities);
	}

	public static void Copy(List<buEntity> refEntities, ref List<buEntity> copiedEntities)
	{
		if (copiedEntities == null)
		{
			copiedEntities = new List<buEntity>();
		}
		copiedEntities.AddRange(Copy(refEntities));
	}

	public static void Copy(List<List<buEntity>> refEntities, ref List<List<buEntity>> copiedEntities)
	{
		copiedEntities = new List<List<buEntity>>();
		if (refEntities != null)
		{
			for (int i = 0; i <= refEntities.Count - 1; i++)
			{
				List<buEntity> copiedEntities2 = new List<buEntity>();
				Copy(refEntities[i], ref copiedEntities2);
				copiedEntities.Add(copiedEntities2);
			}
		}
	}

	public static void Copy(Entity refEntity, ref Entity copiedEntity)
	{
		buVector5.CopyEntities(refEntity, ref copiedEntity);
	}

	public static void Copy(List<Entity> refEntity, ref List<Entity> copiedEntity)
	{
		buVector5.CopyEntities(refEntity, ref copiedEntity);
	}

	public static void Copy(EntityList refEntity, ref List<Entity> copiedEntity)
	{
		buVector5.CopyEntities(refEntity, ref copiedEntity);
	}

	public static void Copy(List<List<Entity>> refEntity, ref List<List<Entity>> copiedEntity)
	{
		buVector5.CopyEntities(refEntity, ref copiedEntity);
	}

	public static void Add(buEntity refEntity, ref List<buEntity> copiedEntities)
	{
		copiedEntities.Add(Copy(refEntity));
	}

	public static void Add(List<buEntity> refEntities, ref List<buEntity> copiedEntities)
	{
		copiedEntities.AddRange(Copy(refEntities));
	}

	public static void Add(List<buEntity> refEntities, ref List<Entity> copiedEntities)
	{
		for (int i = 0; i <= refEntities.Count - 1; i++)
		{
			Entity copiedEntity = null;
			Copy(refEntities[i], ref copiedEntity);
			if (copiedEntity != null)
			{
				copiedEntities.Add(copiedEntity);
			}
		}
	}

	public static bool isVerticeDublicated(buEntity Entity, double Resolution = 0.001)
	{
		string text = "isVerticeDublicated";
		try
		{
			new List<Point3D>();
			new Point3D(double.MinValue, double.MinValue, double.MinValue);
			if (Entity.Vertices.Count > 1)
			{
				for (int i = 1; i <= Entity.Vertices.Count - 1; i++)
				{
					if (buCompare5.EQ(Entity.Vertices[i - 1], Entity.Vertices[i]))
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}
		catch (Exception mSException)
		{
			buLogVer5.addToLogException("buEntity", text, "");
			buException.throwException(mSException, text, ShowMessageBox: false);
			return false;
		}
	}

	public static void FixVerticeDublicated(ref buEntity Entity, double Resolution = 0.001)
	{
		string text = "FixVerticeDublicated";
		try
		{
			if (Entity.Vertices.Count < 2)
			{
				return;
			}
			for (int i = 1; i <= Entity.Vertices.Count - 1; i++)
			{
				if (buCompare5.EQ(Entity.Vertices[i - 1], Entity.Vertices[i]))
				{
					Entity.Vertices.RemoveAt(i);
				}
			}
		}
		catch (Exception mSException)
		{
			buLogVer5.addToLogException("buEntity", text, "");
			buException.throwException(mSException, text, ShowMessageBox: false);
		}
	}

	public static void FixVerticeDublicated(ref Entity Entity, double Resolution = 0.001)
	{
		string text = "FixVerticeDublicated";
		try
		{
			if (Entity.Vertices.Length < 2 || !(Entity is LinearPath))
			{
				return;
			}
			LinearPath linearPath = Entity as LinearPath;
			List<Point3D> list = new List<Point3D>();
			list.Add(new Point3D(Entity.Vertices[0].X, Entity.Vertices[0].Y, Entity.Vertices[0].Z));
			for (int i = 1; i <= Entity.Vertices.Length - 1; i++)
			{
				if (!buCompare5.EQ(list[list.Count - 1], Entity.Vertices[i], Resolution))
				{
					list.Add(new Point3D(Entity.Vertices[i].X, Entity.Vertices[i].Y, Entity.Vertices[i].Z));
				}
			}
			linearPath.Vertices = new Point3D[list.Count];
			linearPath.Vertices = list.ToArray();
			linearPath.Regen(0.01);
		}
		catch (Exception mSException)
		{
			buLogVer5.addToLogException("buEntity", text, "");
			buException.throwException(mSException, text, ShowMessageBox: false);
		}
	}

	public static void CopyProperties(buEntity baseEntity, ref buEntity copiedEntity)
	{
		CopyProperties(baseEntity, typeDef: true, orientation: true, shape: true, info: true, modeproperties: true, dimension: true, ref copiedEntity);
	}

	public static void CopyProperties(buEntity baseEntity, bool typeDef, bool orientation, bool shape, bool info, bool modeproperties, bool dimension, ref buEntity copiedEntity)
	{
		if (orientation)
		{
			copiedEntity.Orientation = new OrientationAngle(baseEntity.Orientation);
		}
		if (typeDef)
		{
			copiedEntity.typeDefination = baseEntity.typeDefination;
		}
		copiedEntity.Color = baseEntity.Color;
		copiedEntity.LayerIndex = baseEntity.LayerIndex;
		copiedEntity.LayerName = baseEntity.LayerName;
		if (info && baseEntity.Info != null)
		{
			copiedEntity.Info = new EntityInfo(baseEntity.Info);
		}
		if (shape && baseEntity.Shape != null)
		{
			copiedEntity.Shape = new EntityShapeInfo(baseEntity.Shape);
		}
		if (dimension && baseEntity.Dimension != null)
		{
			copiedEntity.Dimension = new DimensionInfo(baseEntity.Dimension);
		}
		if (modeproperties)
		{
			if (baseEntity.Marble != null)
			{
				copiedEntity.Marble = new MarbleInfo(baseEntity.Marble);
			}
			if (baseEntity.Sewing != null)
			{
				copiedEntity.Sewing = new SewingInfo(baseEntity.Sewing);
			}
			if (baseEntity.Cutter != null)
			{
				copiedEntity.Cutter = new CutterInfo(baseEntity.Cutter);
			}
		}
	}

	public static void GeoEntitiyToBuEntity(geoEntity GeoEntity, ref buEntity EEntity)
	{
		if (GeoEntity.GetType() == typeof(geoPoint))
		{
			Point3D p = new Point3D(((geoPoint)GeoEntity).StartPoint.X, ((geoPoint)GeoEntity).StartPoint.Y, ((geoPoint)GeoEntity).StartPoint.Z);
			EEntity = new buPoint(p);
		}
		if (GeoEntity.GetType() == typeof(geoLine))
		{
			Point3D start = new Point3D(((geoLine)GeoEntity).StartPoint.X, ((geoLine)GeoEntity).StartPoint.Y, ((geoLine)GeoEntity).StartPoint.Z);
			Point3D end = new Point3D(((geoLine)GeoEntity).EndPoint.X, ((geoLine)GeoEntity).EndPoint.Y, ((geoLine)GeoEntity).EndPoint.Z);
			EEntity = new buLine(start, end);
		}
		if (GeoEntity.GetType() == typeof(geoArc))
		{
			Point3D center = new Point3D(((geoArc)GeoEntity).CenterPoint.X, ((geoArc)GeoEntity).CenterPoint.Y, ((geoArc)GeoEntity).CenterPoint.Z);
			EEntity = new buArc(buVector5.WorkPlaneToPlane(GeoEntity.Plane), center, ((geoArc)GeoEntity).Radius, ((geoArc)GeoEntity).StartAngle, ((geoArc)GeoEntity).EndAngle);
		}
		if (GeoEntity.GetType() == typeof(geoCircle))
		{
			Point3D center2 = new Point3D(((geoCircle)GeoEntity).CenterPoint.X, ((geoCircle)GeoEntity).CenterPoint.Y, ((geoCircle)GeoEntity).CenterPoint.Z);
			EEntity = new buCircle(buVector5.WorkPlaneToPlane(GeoEntity.Plane), center2, ((geoCircle)GeoEntity).Radius);
		}
		if (GeoEntity.GetType() == typeof(geoEllipse))
		{
			Point3D center3 = new Point3D(((geoEllipse)GeoEntity).CenterPoint.X, ((geoEllipse)GeoEntity).CenterPoint.Y, ((geoEllipse)GeoEntity).CenterPoint.Z);
			EEntity = new buEllipse(buVector5.WorkPlaneToPlane(GeoEntity.Plane), center3, ((geoEllipse)GeoEntity).MajorRadius, ((geoEllipse)GeoEntity).MinorRadius);
		}
		if (GeoEntity.GetType() == typeof(geoPolyline))
		{
			List<Point3D> list = new List<Point3D>();
			for (int i = 0; i <= ((geoPolyline)GeoEntity).Vertice.Count - 1; i++)
			{
				list.Add(new Point3D(((geoPolyline)GeoEntity).Vertice[i].X, ((geoPolyline)GeoEntity).Vertice[i].Y, ((geoPolyline)GeoEntity).Vertice[i].Z));
			}
			EEntity = new buLinearPath(list);
		}
		if (!(GeoEntity.GetType() == typeof(geoBSpline)))
		{
		}
		if (GeoEntity.GetType() == typeof(geoText))
		{
		}
		EEntity.Info.Tags = GeoEntity.Tag;
		EEntity.sortDirection = GeoEntity.Direction;
		EEntity.typeDefination = GeoEntity.TypeDefination;
	}

	public static void GeoEntitiyToBuEntity(List<geoEntity> GeoEntities, ref List<buEntity> EEntities)
	{
		EEntities.Clear();
		EEntities = new List<buEntity>();
		for (int i = 0; i <= GeoEntities.Count - 1; i++)
		{
			buEntity EEntity = new buEntity();
			GeoEntitiyToBuEntity(GeoEntities[i], ref EEntity);
			EEntities.Add(EEntity);
		}
	}

	public static void GeoEntitiyToBuEntity(List<List<geoEntity>> GeoEntities, ref List<List<buEntity>> EEntities)
	{
		EEntities.Clear();
		EEntities = new List<List<buEntity>>();
		for (int i = 0; i <= GeoEntities.Count - 1; i++)
		{
			List<buEntity> EEntities2 = new List<buEntity>();
			GeoEntitiyToBuEntity(GeoEntities[i], ref EEntities2);
			EEntities.Add(EEntities2);
		}
	}

	public static void GeoEntitiyToEyeEntity(geoEntity GeoEntity, ref Entity EEntity)
	{
		if (GeoEntity.GetType() == typeof(geoPoint))
		{
			Point3D p = new Point3D(((geoPoint)GeoEntity).StartPoint.X, ((geoPoint)GeoEntity).StartPoint.Y, ((geoPoint)GeoEntity).StartPoint.Z);
			EEntity = new devDept.Eyeshot.Entities.Point(p);
		}
		if (GeoEntity.GetType() == typeof(geoLine))
		{
			Point3D start = new Point3D(((geoLine)GeoEntity).StartPoint.X, ((geoLine)GeoEntity).StartPoint.Y, ((geoLine)GeoEntity).StartPoint.Z);
			Point3D end = new Point3D(((geoLine)GeoEntity).EndPoint.X, ((geoLine)GeoEntity).EndPoint.Y, ((geoLine)GeoEntity).EndPoint.Z);
			EEntity = new Line(start, end);
		}
		if (GeoEntity.GetType() == typeof(geoArc))
		{
			Point3D center = new Point3D(((geoArc)GeoEntity).CenterPoint.X, ((geoArc)GeoEntity).CenterPoint.Y, ((geoArc)GeoEntity).CenterPoint.Z);
			EEntity = new Arc(buVector5.WorkPlaneToPlane(GeoEntity.Plane), center, ((geoArc)GeoEntity).Radius, ((geoArc)GeoEntity).StartAngle, ((geoArc)GeoEntity).EndAngle);
		}
		if (GeoEntity.GetType() == typeof(geoCircle))
		{
			Point3D center2 = new Point3D(((geoCircle)GeoEntity).CenterPoint.X, ((geoCircle)GeoEntity).CenterPoint.Y, ((geoCircle)GeoEntity).CenterPoint.Z);
			EEntity = new Circle(buVector5.WorkPlaneToPlane(GeoEntity.Plane), center2, ((geoCircle)GeoEntity).Radius);
		}
		if (GeoEntity.GetType() == typeof(geoEllipse))
		{
			Point3D center3 = new Point3D(((geoEllipse)GeoEntity).CenterPoint.X, ((geoEllipse)GeoEntity).CenterPoint.Y, ((geoEllipse)GeoEntity).CenterPoint.Z);
			EEntity = new Ellipse(buVector5.WorkPlaneToPlane(GeoEntity.Plane), center3, ((geoEllipse)GeoEntity).MajorRadius, ((geoEllipse)GeoEntity).MinorRadius);
		}
		if (GeoEntity.GetType() == typeof(geoPolyline))
		{
			List<Point3D> list = new List<Point3D>();
			for (int i = 0; i <= ((geoPolyline)GeoEntity).Vertice.Count - 1; i++)
			{
				list.Add(new Point3D(((geoPolyline)GeoEntity).Vertice[i].X, ((geoPolyline)GeoEntity).Vertice[i].Y, ((geoPolyline)GeoEntity).Vertice[i].Z));
			}
			EEntity = new LinearPath(list);
		}
		if (!(GeoEntity.GetType() == typeof(geoBSpline)))
		{
		}
		if (GeoEntity.GetType() == typeof(geoText))
		{
		}
		EEntity.LayerName = GeoEntity.LayerName;
		CustomData customData = new CustomData();
		customData.sortDirection = GeoEntity.Direction;
		EEntity.EntityData = customData;
	}

	public static void GeoEntitiyToEyeEntity(List<geoEntity> GeoEntities, ref List<Entity> EEntities)
	{
		EEntities.Clear();
		EEntities = new List<Entity>();
		for (int i = 0; i <= GeoEntities.Count - 1; i++)
		{
			Entity EEntity = null;
			GeoEntitiyToEyeEntity(GeoEntities[i], ref EEntity);
			EEntities.Add(EEntity);
		}
	}

	public static void eEntityToEyeEntity(List<eEntities> eEntity, ref List<Entity> eyeEntity)
	{
		eyeEntity.Clear();
		for (int i = 0; i <= eEntity.Count - 1; i++)
		{
			Entity eyeEntity2 = null;
			eEntityToEyeEntity(eEntity[i], ref eyeEntity2);
			if (eyeEntity2 != null)
			{
				eyeEntity.Add(eyeEntity2);
			}
		}
	}

	public static void eEntityToEyeEntity(eEntities eEntity, ref Entity eyeEntity)
	{
		try
		{
			if (eEntity.GetType() == typeof(eLine))
			{
				eyeEntity = new Line(buConversion5.Pnt3DToPoint3D(((eLine)eEntity).StartPoint), buConversion5.Pnt3DToPoint3D(((eLine)eEntity).EndPoint));
				eyeEntity.EntityData = new CustomData();
			}
			if (eEntity.GetType() == typeof(eArc))
			{
				if (!buCompare5.EQ(Math.Abs(((eArc)eEntity).EndAngle - ((eArc)eEntity).StartAngle), 360.0))
				{
					eyeEntity = new Arc(buConversion5.Pnt3DToPoint3D(((eArc)eEntity).StartPoint), buConversion5.Pnt3DToPoint3D(((eArc)eEntity).MiddlePoint), buConversion5.Pnt3DToPoint3D(((eArc)eEntity).EndPoint), flip: false);
					eyeEntity.EntityData = new CustomData();
				}
				else
				{
					eyeEntity = new Circle(buVector5.WorkPlaneToPlane(((eArc)eEntity).Plane), buConversion5.Pnt3DToPoint3D(((eArc)eEntity).CenterPoint), ((eArc)eEntity).Radius);
					eyeEntity.EntityData = new CustomData();
				}
			}
			if (eEntity.GetType() == typeof(eCircle))
			{
				eyeEntity = new Circle(buVector5.WorkPlaneToPlane(((eCircle)eEntity).Plane), buConversion5.Pnt3DToPoint3D(((eCircle)eEntity).CenterPoint), ((eCircle)eEntity).Radius);
				eyeEntity.EntityData = new CustomData();
			}
			if ((eEntity.GetType() == typeof(eEllipse)) | (eEntity.GetType() == typeof(eBSpline)) | (eEntity.GetType() == typeof(eBezeir)) | (eEntity.GetType() == typeof(ePolyline)))
			{
				eyeEntity = new LinearPath(buConversion5.Pnt3dToPoint3D(eEntity.Vertice));
				eyeEntity.EntityData = new CustomData();
			}
			if (eEntity.GetType() == typeof(ePoint))
			{
				eyeEntity = new devDept.Eyeshot.Entities.Point(buConversion5.Pnt3DToPoint3D(((ePoint)eEntity).StartPoint));
				eyeEntity.EntityData = new CustomData();
			}
			((CustomData)eyeEntity.EntityData).typeDefination = eEntity.TypeDefination;
		}
		catch (Exception)
		{
		}
	}

	public static void eEntityTobuEntity(List<eEntities> eEntity, ref List<buEntity> bEntity)
	{
		bEntity.Clear();
		for (int i = 0; i <= eEntity.Count - 1; i++)
		{
			buEntity bEntity2 = null;
			eEntityTobuEntity(eEntity[i], ref bEntity2);
			if (bEntity2 != null)
			{
				bEntity.Add(bEntity2);
			}
		}
	}

	public static void eEntityTobuEntity(eEntities eEntity, ref buEntity bEntity)
	{
		try
		{
			if (eEntity.GetType() == typeof(eLine))
			{
				bEntity = new buLine(buConversion5.Pnt3DToPoint3D(((eLine)eEntity).StartPoint), buConversion5.Pnt3DToPoint3D(((eLine)eEntity).EndPoint));
			}
			if (eEntity.GetType() == typeof(eArc))
			{
				if (!buCompare5.EQ(Math.Abs(((eArc)eEntity).EndAngle - ((eArc)eEntity).StartAngle), 360.0))
				{
					bEntity = new buArc(buConversion5.Pnt3DToPoint3D(((eArc)eEntity).StartPoint), buConversion5.Pnt3DToPoint3D(((eArc)eEntity).MiddlePoint), buConversion5.Pnt3DToPoint3D(((eArc)eEntity).EndPoint), flip: false);
				}
				else
				{
					bEntity = new buCircle(buVector5.WorkPlaneToPlane(((eArc)eEntity).Plane), buConversion5.Pnt3DToPoint3D(((eArc)eEntity).CenterPoint), ((eArc)eEntity).Radius);
				}
			}
			if (eEntity.GetType() == typeof(eCircle))
			{
				bEntity = new buCircle(buVector5.WorkPlaneToPlane(((eCircle)eEntity).Plane), buConversion5.Pnt3DToPoint3D(((eCircle)eEntity).CenterPoint), ((eCircle)eEntity).Radius);
			}
			if ((eEntity.GetType() == typeof(eEllipse)) | (eEntity.GetType() == typeof(eBSpline)) | (eEntity.GetType() == typeof(eBezeir)) | (eEntity.GetType() == typeof(ePolyline)))
			{
				bEntity = new buLinearPath(buConversion5.Pnt3dToPoint3D(eEntity.Vertice));
			}
			if (eEntity.GetType() == typeof(ePoint))
			{
				bEntity = new buPoint(buConversion5.Pnt3DToPoint3D(((ePoint)eEntity).StartPoint));
			}
		}
		catch (Exception)
		{
		}
	}

	public static void Decode(List<string> SL, ref buEntity refEntity, string Char = "")
	{
		try
		{
			if (SL.Count < 2)
			{
				return;
			}
			if (SL[0].ToLower().Trim() == "bupoint")
			{
				Point3D point3D = buSerilization5.DecoderFromPoint3D(SL[1]);
				if (point3D != null)
				{
					refEntity = new buPoint(point3D);
				}
			}
			if (SL[0].ToLower().Trim() == "buline")
			{
				Point3D point3D2 = buSerilization5.DecoderFromPoint3D(SL[1]);
				Point3D point3D3 = buSerilization5.DecoderFromPoint3D(SL[2]);
				if ((point3D2 != null) & (point3D3 != null))
				{
					refEntity = new buLine(point3D2, point3D3);
				}
			}
			if (SL[0].ToLower().Trim() == "bucircle")
			{
				Point3D point3D4 = buSerilization5.DecoderFromPoint3D(SL[1]);
				double num = buSerilization5.DecoderFromDouble(SL[2]);
				Plane plane = buSerilization5.DecoderFromPlane(SL[3]);
				if ((point3D4 != null && num > 0.0) & (plane != null))
				{
					refEntity = new buCircle(plane, point3D4, num);
				}
			}
			if (SL[0].ToLower().Trim() == "buarc")
			{
				Point3D point3D5 = buSerilization5.DecoderFromPoint3D(SL[1]);
				double num2 = buSerilization5.DecoderFromDouble(SL[2]);
				Point3D point3D6 = buSerilization5.DecoderFromPoint3D(SL[3]);
				Point3D point3D7 = buSerilization5.DecoderFromPoint3D(SL[4]);
				Plane plane2 = buSerilization5.DecoderFromPlane(SL[5]);
				if ((((point3D5 != null) & (point3D6 != null) & (point3D7 != null)) && num2 > 0.0) & (plane2 != null))
				{
					refEntity = new buArc(plane2, point3D5, num2, point3D6, point3D7, flip: false);
				}
			}
			if (SL[0].ToLower().Trim() == "bulinearpath")
			{
				List<string> CalcList = new List<string>();
				List<Point3D> list = new List<Point3D>();
				buString5.ListToSpecificList("<Vertices>", "</Vertices>", AddStartEndKey: false, SL, ref CalcList);
				for (int i = 0; i <= CalcList.Count - 1; i++)
				{
					list.Add(buSerilization5.DecoderFromPoint3D(CalcList[i]));
				}
				if (list.Count > 1)
				{
					refEntity = new buLinearPath(list);
				}
			}
			if (SL[0].ToLower().Trim() == "buellipse")
			{
				Point3D point3D8 = buSerilization5.DecoderFromPoint3D(SL[1]);
				double num3 = buSerilization5.DecoderFromDouble(SL[2]);
				double num4 = buSerilization5.DecoderFromDouble(SL[3]);
				Plane plane3 = buSerilization5.DecoderFromPlane(SL[4]);
				if ((point3D8 != null && num4 > 0.0 && num3 > 0.0) & (plane3 != null))
				{
					refEntity = new buEllipse(plane3, point3D8, num3, num4);
				}
			}
			if (SL[0].ToLower().Trim() == "bucurve")
			{
				int degree = buSerilization5.DecoderFromInt(SL[1]);
				List<string> CalcList2 = new List<string>();
				List<string> CalcList3 = new List<string>();
				List<Point3D> list2 = new List<Point3D>();
				Point4D[] array = null;
				double[] array2 = null;
				buString5.ListToSpecificList("<ControlPoints>", "</ControlPoints>", AddStartEndKey: false, SL, ref CalcList2);
				buString5.ListToSpecificList("<KnotVector>", "</KnotVector>", AddStartEndKey: false, SL, ref CalcList3);
				if (CalcList3.Count > 0)
				{
					array2 = new double[CalcList3.Count];
				}
				if (array2 == null)
				{
					for (int j = 0; j <= CalcList2.Count - 1; j++)
					{
						Point4D point4D = buSerilization5.DecoderFromPoint4D(CalcList2[j]);
						list2.Add(new Point3D(point4D.X, point4D.Y, point4D.Z));
					}
					if (list2.Count > 0)
					{
						refEntity = new buCurve(degree, list2);
					}
				}
				else
				{
					array = new Point4D[CalcList2.Count];
					for (int k = 0; k <= CalcList2.Count - 1; k++)
					{
						array[k] = buSerilization5.DecoderFromPoint4D(CalcList2[k]);
					}
					for (int l = 0; l <= CalcList3.Count - 1; l++)
					{
						array2[l] = buSerilization5.DecoderFromDouble(CalcList3[l]);
					}
					if ((array.Length != 0) & (array2.Length != 0))
					{
						refEntity = new buCurve(degree, array2, array);
					}
				}
			}
			if (SL[0].ToLower().Trim() == "bucompositecurve")
			{
				List<string> CalcList4 = new List<string>();
				List<List<string>> CalcList5 = new List<List<string>>();
				List<buEntity> list3 = new List<buEntity>();
				buString5.ListToSpecificList("<SubCurves>", "</SubCurves>", AddStartEndKey: false, SL, ref CalcList4);
				buString5.ListToSpecificList("<buEntitySub>", "</buEntitySub>", AddStartEndKey: false, CalcList4, ref CalcList5);
				int num5 = -1;
				int num6 = -1;
				for (int m = 0; m <= SL.Count - 1; m++)
				{
					if (SL[m].IndexOf("<SubCurves>") >= 0)
					{
						num5 = m;
					}
					if (SL[m].IndexOf("</SubCurves>") >= 0)
					{
						num6 = m;
					}
				}
				if (num5 >= 0 && num6 >= 0 && num6 - num5 > 0)
				{
					SL.RemoveRange(num5, num6 - num5 + 1);
				}
				for (int n = 0; n <= CalcList5.Count - 1; n++)
				{
					buEntity refEntity2 = null;
					Decode(CalcList5[n], ref refEntity2, "Sub");
					if (refEntity2 != null)
					{
						list3.Add(refEntity2);
					}
				}
				if (list3.Count > 0)
				{
					refEntity = new buCompositeCurve(list3);
				}
			}
			if (SL[0].ToLower().Trim() == "buregion")
			{
				List<string> CalcList6 = new List<string>();
				List<List<string>> CalcList7 = new List<List<string>>();
				List<buEntity> list4 = new List<buEntity>();
				buString5.ListToSpecificList("<SubCurves>", "</SubCurves>", AddStartEndKey: false, SL, ref CalcList6);
				buString5.ListToSpecificList("<buEntitySub>", "</buEntitySub>", AddStartEndKey: false, CalcList6, ref CalcList7);
				for (int num7 = 0; num7 <= CalcList7.Count - 1; num7++)
				{
					buEntity refEntity3 = null;
					Decode(CalcList7[num7], ref refEntity3, "Sub");
					if (refEntity3 != null)
					{
						list4.Add(refEntity3);
					}
				}
				if (list4.Count > 0)
				{
					refEntity = new buRegion(list4);
				}
			}
			if (SL[0].ToLower().Trim() == "bumesh")
			{
				List<string> CalcList8 = new List<string>();
				List<string> CalcList9 = new List<string>();
				List<Point3D> list5 = new List<Point3D>();
				List<IndexTriangle> list6 = new List<IndexTriangle>();
				buString5.ListToSpecificList("<Vertices>", "</Vertices>", AddStartEndKey: false, SL, ref CalcList8);
				for (int num8 = 0; num8 <= CalcList8.Count - 1; num8++)
				{
					list5.Add(buSerilization5.DecoderFromPoint3D(CalcList8[num8]));
				}
				buString5.ListToSpecificList("<Triangles>", "</Triangles>", AddStartEndKey: false, SL, ref CalcList9);
				for (int num9 = 0; num9 <= CalcList9.Count - 1; num9++)
				{
					list6.Add(buSerilization5.DecoderFromTriangleIndex(CalcList9[num9]));
				}
				if (list5.Count > 1)
				{
					refEntity = new buMesh(list5, list6);
				}
			}
			if (SL[0].ToLower().Trim() == "bulineardim")
			{
				Point3D point3D9 = buSerilization5.DecoderFromPoint3D(SL[1]);
				Point3D point3D10 = buSerilization5.DecoderFromPoint3D(SL[2]);
				Point3D point3D11 = buSerilization5.DecoderFromPoint3D(SL[3]);
				double textHeight = buSerilization5.DecoderFromDouble(SL[4]);
				Plane dimPlane = buSerilization5.DecoderFromPlane(SL[5]);
				if ((point3D9 != null) & (point3D10 != null) & (point3D11 != null))
				{
					refEntity = new buLinearDim(dimPlane, point3D9, point3D10, point3D11, textHeight);
				}
			}
			if (SL[0].ToLower().Trim() == "buangulardim")
			{
				Point3D point3D12 = buSerilization5.DecoderFromPoint3D(SL[1]);
				Point3D point3D13 = buSerilization5.DecoderFromPoint3D(SL[2]);
				Point3D point3D14 = buSerilization5.DecoderFromPoint3D(SL[3]);
				double textHeight2 = buSerilization5.DecoderFromDouble(SL[4]);
				Plane dimPlane2 = buSerilization5.DecoderFromPlane(SL[5]);
				if ((point3D12 != null) & (point3D13 != null) & (point3D14 != null))
				{
					refEntity = new buAngularDim(dimPlane2, point3D12, point3D13, point3D14, textHeight2);
				}
			}
			if (SL[0].ToLower().Trim() == "buradialdim")
			{
				Point3D point3D15 = buSerilization5.DecoderFromPoint3D(SL[1]);
				Point3D point3D16 = buSerilization5.DecoderFromPoint3D(SL[2]);
				double num10 = buSerilization5.DecoderFromDouble(SL[3]);
				double textHeight3 = buSerilization5.DecoderFromDouble(SL[4]);
				Plane dimPlane3 = buSerilization5.DecoderFromPlane(SL[5]);
				if (((point3D15 != null) & (point3D16 != null)) && num10 > 0.0)
				{
					refEntity = new buRadialDim(dimPlane3, point3D15, num10, point3D16, textHeight3);
				}
			}
			if (SL[0].ToLower().Trim() == "budiametricdim")
			{
				Point3D point3D17 = buSerilization5.DecoderFromPoint3D(SL[1]);
				Point3D point3D18 = buSerilization5.DecoderFromPoint3D(SL[2]);
				double num11 = buSerilization5.DecoderFromDouble(SL[3]);
				double textHeight4 = buSerilization5.DecoderFromDouble(SL[4]);
				Plane dimPlane4 = buSerilization5.DecoderFromPlane(SL[5]);
				if (((point3D17 != null) & (point3D18 != null)) && num11 > 0.0)
				{
					refEntity = new buDiametricDim(dimPlane4, point3D17, num11, point3D18, textHeight4);
				}
			}
			if (SL[0].ToLower().Trim() == "buordinatedim")
			{
				Point3D point3D19 = buSerilization5.DecoderFromPoint3D(SL[1]);
				Point3D point3D20 = buSerilization5.DecoderFromPoint3D(SL[2]);
				bool isVertical = buSerilization5.DecoderFromBool(SL[3]);
				double textHeight5 = buSerilization5.DecoderFromDouble(SL[4]);
				Plane dimPlane5 = buSerilization5.DecoderFromPlane(SL[5]);
				if ((point3D19 != null) & (point3D20 != null))
				{
					refEntity = new buOrdinateDim(dimPlane5, point3D19, point3D20, isVertical, textHeight5);
				}
			}
			if (SL[0].ToLower().Trim() == "butext")
			{
				Point3D point3D21 = buSerilization5.DecoderFromPoint3D(SL[1]);
				string textString = buSerilization5.DecoderFromString(SL[2]);
				double height = buSerilization5.DecoderFromDouble(SL[3]);
				string styleName = buSerilization5.DecoderFromString(SL[4]);
				bool simplify = buSerilization5.DecoderFromBool(SL[5]);
				Enum.TryParse<Text.alignmentType>(buSerilization5.DecoderFromString(SL[6]), out var result);
				Plane textPlane = buSerilization5.DecoderFromPlane(SL[7]);
				if (point3D21 != null)
				{
					refEntity = new buText(textPlane, point3D21, textString, height, result, styleName, simplify);
				}
			}
			if (SL[0].ToLower().Trim() == "bumultilinetext")
			{
				Point3D point3D22 = buSerilization5.DecoderFromPoint3D(SL[1]);
				string textString2 = buSerilization5.DecoderFromString(SL[2]);
				double height2 = buSerilization5.DecoderFromDouble(SL[3]);
				string styleName2 = buSerilization5.DecoderFromString(SL[4]);
				bool simplify2 = buSerilization5.DecoderFromBool(SL[5]);
				Enum.TryParse<Text.alignmentType>(buSerilization5.DecoderFromString(SL[6]), out var result2);
				double width = buSerilization5.DecoderFromDouble(SL[7]);
				double lineSpaceDistance = buSerilization5.DecoderFromDouble(SL[8]);
				bool wrap = buSerilization5.DecoderFromBool(SL[9]);
				Plane textPlane2 = buSerilization5.DecoderFromPlane(SL[10]);
				if (point3D22 != null)
				{
					refEntity = new buMultilineText(textPlane2, point3D22, textString2, width, height2, lineSpaceDistance, result2, styleName2, simplify2, wrap);
				}
			}
			if (refEntity != null)
			{
				List<string> CalcList10 = new List<string>();
				buString5.ListToSpecificList("<Common>", "</Common>", AddStartEndKey: false, SL, ref CalcList10);
				DecodeCommon(CalcList10, ref refEntity);
				CalcList10 = new List<string>();
				buString5.ListToSpecificList("<Sewing>", "</Sewing>", AddStartEndKey: false, SL, ref CalcList10);
				if (CalcList10.Count > 0)
				{
					SewingInfo.Decode(CalcList10, ref refEntity.Sewing);
				}
				CalcList10 = new List<string>();
				buString5.ListToSpecificList("<Dimension>", "</Dimension>", AddStartEndKey: false, SL, ref CalcList10);
				if (CalcList10.Count > 0)
				{
					DimensionInfo.Decode(CalcList10, ref refEntity.Dimension);
				}
				CalcList10 = new List<string>();
				buString5.ListToSpecificList("<Marble>", "</Marble>", AddStartEndKey: false, SL, ref CalcList10);
				if (CalcList10.Count > 0)
				{
					MarbleInfo.Decode(CalcList10, ref refEntity.Marble);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public static buEntity Decode(List<string> SL)
	{
		try
		{
			buEntity refEntity = null;
			Decode(SL, ref refEntity);
			return refEntity;
		}
		catch (Exception)
		{
			return null;
		}
	}

	public static void Decode(List<string> SL, ref List<buEntity> refEntity, string Char = "")
	{
		try
		{
			refEntity = new List<buEntity>();
			List<List<string>> CalcList = new List<List<string>>();
			buStatics.ListToSpecificList("<buEntity>", "</buEntity>", AddStartEndKey: false, SL, ref CalcList);
			if (CalcList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i <= CalcList.Count - 1; i++)
			{
				buEntity refEntity2 = null;
				Decode(CalcList[i], ref refEntity2, Char);
				if (refEntity2 != null)
				{
					refEntity.Add(refEntity2);
				}
				CalcList[i].Clear();
			}
			CalcList.Clear();
		}
		catch (Exception)
		{
		}
	}

	public static void Decode(List<string> SL, ref List<List<buEntity>> refEntity, string Char = "")
	{
		try
		{
			refEntity = new List<List<buEntity>>();
			List<List<string>> CalcList = new List<List<string>>();
			buStatics.ListToSpecificList("<buEntityList>", "</buEntityList>", AddStartEndKey: false, SL, ref CalcList);
			if (CalcList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i <= CalcList.Count - 1; i++)
			{
				List<buEntity> refEntity2 = new List<buEntity>();
				Decode(CalcList[i], ref refEntity2, Char);
				if (refEntity2.Count > 0)
				{
					refEntity.Add(refEntity2);
				}
				CalcList[i].Clear();
			}
			CalcList.Clear();
		}
		catch (Exception)
		{
		}
	}

	public static void DecodeCommon(List<string> SL, ref buEntity refEntity)
	{
		try
		{
			string[] array = null;
			object obj = null;
			object obj2 = null;
			object obj3 = null;
			if (!((refEntity != null) & (SL.Count >= 4)))
			{
				return;
			}
			array = SL[0].Split(':');
			refEntity.sortDirection = (entitySortDirection)Enum.Parse(typeof(entitySortDirection), array[1], ignoreCase: true);
			array = SL[1].Split(':');
			refEntity.typeDefination = (entityTypeDefination)Enum.Parse(typeof(entityTypeDefination), array[1], ignoreCase: true);
			array = SL[2].Split(':');
			refEntity.Orientation = buSerilization5.DecoderFromOrientationAngle(array[1]);
			obj = refEntity.Info;
			buSerilization5.StringToClass(ref obj, SL[3]);
			if (SL.Count >= 5)
			{
				array = SL[4].Split(':');
				refEntity.ToolName = array[1];
			}
			if (SL.Count >= 6)
			{
				array = SL[5].Split(':');
				refEntity.LayerName = array[1];
			}
			if (SL.Count >= 7)
			{
				array = SL[6].Split(':');
				refEntity.Color = buImage5.StringToColor(array[1], ColorConvertType.String);
			}
			for (int i = 4; i <= SL.Count - 1; i++)
			{
				if (SL[i].ToLower().Trim().IndexOf("shape") >= 0)
				{
					obj2 = refEntity.Shape;
					buSerilization5.StringToClass(ref obj2, SL[i]);
				}
				if (SL[i].ToLower().Trim().IndexOf("cutter") >= 0)
				{
					obj3 = refEntity.Cutter;
					buSerilization5.StringToClass(ref obj3, SL[i]);
				}
				if (SL[i].ToLower().Trim().IndexOf("marble") >= 0)
				{
					obj3 = refEntity.Marble;
					buSerilization5.StringToClass(ref obj3, SL[i]);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public static ArrayList ToDefEntity(buEntity refEntity, int Space)
	{
		ArrayList AL = new ArrayList();
		ToDefEntity(refEntity, Space, ref AL);
		return AL;
	}

	public static void ToDefEntity(buEntity refEntity, int Space, ref ArrayList AL)
	{
		AL.Clear();
		AL = new ArrayList();
		AL.AddRange(refEntity.ToDef(Space));
	}

	public static void ToDefEntity(List<buEntity> refEntities, int Space, ref ArrayList AL)
	{
		AL.Clear();
		AL = new ArrayList();
		for (int i = 0; i <= refEntities.Count - 1; i++)
		{
			AL.AddRange(refEntities[i].ToDef(Space));
		}
	}

	public static ArrayList ToDefEntity(List<buEntity> refEntities, int Space)
	{
		ArrayList AL = new ArrayList();
		ToDefEntity(refEntities, Space, ref AL);
		return AL;
	}

	public static void ToDefEntity(List<List<buEntity>> refEntities, int Space, ref ArrayList AL)
	{
		AL.Clear();
		AL = new ArrayList();
		for (int i = 0; i <= refEntities.Count - 1; i++)
		{
			AL.Add(buString5.SpaceChar(Space) + "<buEntityList>");
			AL.AddRange(ToDefEntity(refEntities[i], Space + 2));
			AL.Add(buString5.SpaceChar(Space) + "</buEntityList>");
		}
	}

	public static ArrayList ToDefEntity(List<List<buEntity>> refEntities, int Space)
	{
		ArrayList AL = new ArrayList();
		ToDefEntity(refEntities, Space, ref AL);
		return AL;
	}

	public ArrayList ToDef(int Space, string Char = "")
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buString5.SpaceChar(Space) + "<buEntity" + Char + ">");
		if (this is buPoint)
		{
			buPoint buPoint2 = this as buPoint;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buPoint");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "StartPoint: " + buSerilization5.ToDef(buPoint2.StartPoint));
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (this is buLine)
		{
			buLine buLine2 = this as buLine;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buLine");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "StartPoint: " + buSerilization5.ToDef(buLine2.StartPoint));
			arrayList.Add(buString5.SpaceChar(Space + 2) + "EndPoint: " + buSerilization5.ToDef(buLine2.EndPoint));
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (this is buCircle)
		{
			buCircle buCircle2 = this as buCircle;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buCircle");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "CenterPoint: " + buSerilization5.ToDef(buCircle2.Center));
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Radius: " + buCircle2.Radius);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Plane: " + buSerilization5.ToDef(buCircle2.Plane));
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (this is buArc)
		{
			buArc buArc2 = this as buArc;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buArc");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "CenterPoint: " + buSerilization5.ToDef(buArc2.Center));
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Radius: " + buArc2.Radius);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "StartPoint: " + buSerilization5.ToDef(buArc2.StartPoint));
			arrayList.Add(buString5.SpaceChar(Space + 2) + "EndPoint: " + buSerilization5.ToDef(buArc2.EndPoint));
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Plane: " + buSerilization5.ToDef(buArc2.Plane));
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (this is buLinearPath)
		{
			buLinearPath buLinearPath2 = this as buLinearPath;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buLinearPath");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "<Vertices>");
			for (int i = 0; i <= buLinearPath2.Vertices.Count - 1; i++)
			{
				arrayList.Add(buString5.SpaceChar(Space + 4) + "P: " + buSerilization5.ToDef(buLinearPath2.Vertices[i]));
			}
			arrayList.Add(buString5.SpaceChar(Space + 2) + "</Vertices>");
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (this is buEllipse)
		{
			buEllipse buEllipse2 = this as buEllipse;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buEllipse");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "CenterPoint: " + buSerilization5.ToDef(buEllipse2.Center));
			arrayList.Add(buString5.SpaceChar(Space + 2) + "RadiusX: " + buEllipse2.RadiusX);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "RadiusY: " + buEllipse2.RadiusY);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Angle: " + buEllipse2.Angle);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Plane: " + buSerilization5.ToDef(buEllipse2.Plane));
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (this is buCurve)
		{
			buCurve buCurve2 = this as buCurve;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buCurve");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Degree: " + buCurve2.Degree);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "<ControlPoints>");
			for (int j = 0; j <= buCurve2.ControlPoints.Count - 1; j++)
			{
				arrayList.Add(buString5.SpaceChar(Space + 4) + "CP: " + buSerilization5.ToDef(buCurve2.ControlPoints[j]));
			}
			arrayList.Add(buString5.SpaceChar(Space + 2) + "</ControlPoints>");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "<KnotVector>");
			for (int k = 0; k <= buCurve2.KnotVector.Count - 1; k++)
			{
				arrayList.Add(buString5.SpaceChar(Space + 4) + "KV: " + buCurve2.KnotVector[k]);
			}
			arrayList.Add(buString5.SpaceChar(Space + 2) + "</KnotVector>");
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (this is buCompositeCurve)
		{
			buCompositeCurve buCompositeCurve2 = this as buCompositeCurve;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buCompositeCurve");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "<SubCurves>");
			for (int l = 0; l <= buCompositeCurve2.CurveList.Count - 1; l++)
			{
				arrayList.AddRange(buCompositeCurve2.CurveList[l].ToDef(Space + 2, "Sub"));
			}
			arrayList.Add(buString5.SpaceChar(Space + 2) + "</SubCurves>");
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (this is buRegion)
		{
			buRegion buRegion2 = this as buRegion;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buRegion");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "<SubCurves>");
			for (int m = 0; m <= buRegion2.CurveList.Count - 1; m++)
			{
				arrayList.AddRange(buRegion2.CurveList[m].ToDef(Space + 2, "Sub"));
			}
			arrayList.Add(buString5.SpaceChar(Space + 2) + "</SubCurves>");
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (this is buMesh)
		{
			buMesh buMesh2 = this as buMesh;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buMesh");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "<Vertices>");
			for (int n = 0; n <= buMesh2.Vertices.Count - 1; n++)
			{
				arrayList.Add(buString5.SpaceChar(Space + 4) + "P: " + buSerilization5.ToDef(buMesh2.Vertices[n]));
			}
			arrayList.Add(buString5.SpaceChar(Space + 2) + "</Vertices>");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "<Triangles>");
			for (int num = 0; num <= buMesh2.Triangles.Count - 1; num++)
			{
				arrayList.Add(buString5.SpaceChar(Space + 4) + "P: " + buSerilization5.ToDef(buMesh2.Triangles[num]));
			}
			arrayList.Add(buString5.SpaceChar(Space + 2) + "</Triangles>");
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (this is buLinearDim)
		{
			buLinearDim buLinearDim2 = this as buLinearDim;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buLinearDim");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "ExtLine1: " + buSerilization5.ToDef(buLinearDim2.ExtLine1));
			arrayList.Add(buString5.SpaceChar(Space + 2) + "ExtLine2: " + buSerilization5.ToDef(buLinearDim2.ExtLine2));
			arrayList.Add(buString5.SpaceChar(Space + 2) + "DimLinePosition: " + buSerilization5.ToDef(buLinearDim2.DimLinePosition));
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Height: " + buLinearDim2.Height);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Plane: " + buSerilization5.ToDef(buLinearDim2.Plane));
			arrayList.Add(buString5.SpaceChar(Space + 2) + "TextOverride: " + buLinearDim2.TextOverride.ToString());
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (this is buAngularDim)
		{
			buAngularDim buAngularDim2 = this as buAngularDim;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buAngularDim");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "ExtLine1: " + buSerilization5.ToDef(buAngularDim2.ExtLine1));
			arrayList.Add(buString5.SpaceChar(Space + 2) + "ExtLine2: " + buSerilization5.ToDef(buAngularDim2.ExtLine2));
			arrayList.Add(buString5.SpaceChar(Space + 2) + "DimLinePosition: " + buSerilization5.ToDef(buAngularDim2.DimLinePosition));
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Height: " + buAngularDim2.Height);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Plane: " + buSerilization5.ToDef(buAngularDim2.Plane));
			arrayList.Add(buString5.SpaceChar(Space + 2) + "TextOverride: " + buAngularDim2.TextOverride.ToString());
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (this is buRadialDim)
		{
			buRadialDim buRadialDim2 = this as buRadialDim;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buRadialDim");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Origin: " + buSerilization5.ToDef(buRadialDim2.Origin));
			arrayList.Add(buString5.SpaceChar(Space + 2) + "DimLinePosition: " + buSerilization5.ToDef(buRadialDim2.DimLinePosition));
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Radius: " + buRadialDim2.Radius);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Height: " + buRadialDim2.Height);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Plane: " + buSerilization5.ToDef(buRadialDim2.Plane));
			arrayList.Add(buString5.SpaceChar(Space + 2) + "TextOverride: " + buRadialDim2.TextOverride.ToString());
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (this is buDiametricDim)
		{
			buDiametricDim buDiametricDim2 = this as buDiametricDim;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buDiametricDim");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Origin: " + buSerilization5.ToDef(buDiametricDim2.Origin));
			arrayList.Add(buString5.SpaceChar(Space + 2) + "DimLinePosition: " + buSerilization5.ToDef(buDiametricDim2.DimLinePosition));
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Radius: " + buDiametricDim2.Radius);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Height: " + buDiametricDim2.Height);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Plane: " + buSerilization5.ToDef(buDiametricDim2.Plane));
			arrayList.Add(buString5.SpaceChar(Space + 2) + "TextOverride: " + buDiametricDim2.TextOverride.ToString());
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (this is buOrdinateDim)
		{
			buOrdinateDim buOrdinateDim2 = this as buOrdinateDim;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buOrdinateDim");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "DefiningPoint: " + buSerilization5.ToDef(buOrdinateDim2.DefiningPoint));
			arrayList.Add(buString5.SpaceChar(Space + 2) + "DimLinePosition: " + buSerilization5.ToDef(buOrdinateDim2.DimLinePosition));
			arrayList.Add(buString5.SpaceChar(Space + 2) + "isVertical: " + buOrdinateDim2.isVertical);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Height: " + buOrdinateDim2.Height);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Plane: " + buSerilization5.ToDef(buOrdinateDim2.Plane));
			arrayList.Add(buString5.SpaceChar(Space + 2) + "TextOverride: " + buOrdinateDim2.TextOverride.ToString());
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (this is buText)
		{
			buText buText2 = this as buText;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buText");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "InsertionPoint: " + buSerilization5.ToDef(buText2.InsertionPoint));
			arrayList.Add(buString5.SpaceChar(Space + 2) + "TextString: " + buText2.TextString.ToString());
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Height: " + buText2.Height);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "StyleName: " + buText2.StyleName.ToString());
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Simplify: " + buText2.Simplify);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Alignment: " + buText2.Alignment);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Plane: " + buSerilization5.ToDef(buText2.Plane));
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (this is buMultilineText)
		{
			buMultilineText buMultilineText2 = this as buMultilineText;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buMultilineText");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "InsertionPoint: " + buSerilization5.ToDef(buMultilineText2.InsertionPoint));
			arrayList.Add(buString5.SpaceChar(Space + 2) + "TextString: " + buMultilineText2.TextString.ToString());
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Height: " + buMultilineText2.Height);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "StyleName: " + buMultilineText2.StyleName.ToString());
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Simplify: " + buMultilineText2.Simplify);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Alignment: " + buMultilineText2.Alignment);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "RectWidth: " + buMultilineText2.RectWidth);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "LineSpaceDistance: " + buMultilineText2.LineSpaceDistance);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Wrap: " + buMultilineText2.Wrap);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Plane: " + buSerilization5.ToDef(buMultilineText2.Plane));
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		arrayList.Add(buString5.SpaceChar(Space) + "</buEntity" + Char + ">");
		return arrayList;
	}

	public ArrayList ToDefCommon(int Space)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buString5.SpaceChar(Space) + "<Common>");
		arrayList.Add(buString5.SpaceChar(Space + 2) + "sortDirection: " + sortDirection);
		arrayList.Add(buString5.SpaceChar(Space + 2) + "typeDefination: " + typeDefination);
		arrayList.Add(buString5.SpaceChar(Space + 2) + "Orientation: " + buSerilization5.ToDef(Orientation));
		arrayList.Add(buString5.SpaceChar(Space + 2) + "Info = " + buSerilization5.ClassToString(Info));
		if (ToolName == null)
		{
			arrayList.Add(buString5.SpaceChar(Space + 2) + "ToolName: ");
		}
		else
		{
			arrayList.Add(buString5.SpaceChar(Space + 2) + "ToolName: " + ToolName.ToString());
		}
		if (LayerName == null)
		{
			arrayList.Add(buString5.SpaceChar(Space + 2) + "LayerName: ");
		}
		else
		{
			arrayList.Add(buString5.SpaceChar(Space + 2) + "LayerName: " + LayerName.ToString());
		}
		arrayList.Add(buString5.SpaceChar(Space + 2) + "Color: " + buImage5.ColorToString(Color, ColorConvertType.String));
		if (Shape != null)
		{
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Shape = " + buSerilization5.ClassToString(Shape));
		}
		if (Cutter != null)
		{
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Cutter = " + buSerilization5.ClassToString(Cutter));
		}
		arrayList.Add(buString5.SpaceChar(Space) + "</Common>");
		if (Sewing != null)
		{
			arrayList.Add(buString5.SpaceChar(Space) + "<Sewing>");
			arrayList.AddRange(Sewing.ToDef(Space + 2));
			arrayList.Add(buString5.SpaceChar(Space) + "</Sewing>");
		}
		if (Dimension != null)
		{
			arrayList.Add(buString5.SpaceChar(Space) + "<Dimension>");
			arrayList.AddRange(Dimension.ToDef(Space + 2));
			arrayList.Add(buString5.SpaceChar(Space) + "</Dimension>");
		}
		if (Marble != null)
		{
			arrayList.Add(buString5.SpaceChar(Space) + "<Marble>");
			arrayList.AddRange(Marble.ToDef(Space + 2));
			arrayList.Add(buString5.SpaceChar(Space) + "</Marble>");
		}
		return arrayList;
	}
}
