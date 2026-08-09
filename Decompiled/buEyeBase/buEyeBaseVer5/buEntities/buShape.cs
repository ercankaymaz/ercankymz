using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.buEntities;

public class buShape : buSerilization5
{
	public string ShapeName = "";

	public string Defination = null;

	public string Aux = null;

	public string SecondToolName = null;

	public int ID = -1;

	public int Index = -1;

	public int Zone = 0;

	public int Priority = 0;

	public double Depth = 0.0;

	public double OffsetDistance = 0.0;

	public double DepthExtra = 0.0;

	public double feedPlunge = 0.0;

	public double feedCutting = 0.0;

	public double SpindleSpeed = 0.0;

	public List<double> DepthLevel = new List<double>();

	public bool Enable = true;

	public bool isEngraving = false;

	public bool isPocket = false;

	public planeBoxNames planeName = planeBoxNames.Top;

	public ShapeGroup ShapeGroup = ShapeGroup.Shape;

	public CornerLocation Corner = CornerLocation.RightTop;

	public ObjectAlignment Alignment = ObjectAlignment.MiddleCenter;

	public ShapeTypes ShapeType = ShapeTypes.Rectangle;

	public ShapeEdit Edit = new ShapeEdit();

	public ShapeSizeInfo ItemSize = new ShapeSizeInfo();

	public ShapeLeadInOut LeadInOut = new ShapeLeadInOut();

	public Plane planeOperation = new Plane();

	public Point3D CornerPoint = new Point3D(0.0, 0.0, 0.0);

	public Point3D BasePoint = new Point3D(0.0, 0.0, 0.0);

	public Point3D Offset = new Point3D(0.0, 0.0, 0.0);

	public Point3D CalculatedPoint = new Point3D(0.0, 0.0, 0.0);

	public buLinearDim dimHorizontal = null;

	public buLinearDim dimVertical = null;

	public Vector3D CornerDirection = new Vector3D(0.0, 0.0, 1.0);

	public List<buEntity> entitiesShape = new List<buEntity>();

	public List<buEntity> entitiesCam = new List<buEntity>();

	public List<buEntity> entitiesDim = null;

	public List<buEntity> entitiesRef = null;

	public List<Entity> entitySolid = new List<Entity>();

	public List<Entity> entityWireframe = new List<Entity>();

	public List<Clamper> Clampers = null;

	public List<ShapeMultiCenterData> multiCenter = null;

	public camTp Cam = null;

	public camParameters5 CamPar = null;

	public ToolBase5 Tool = null;

	public ShapeProfileData ProfileData = null;

	public List<string> InfoMessages = null;

	public List<string> Codes = null;

	public Color OperationColor = Color.Cyan;

	public static List<ToolBase5> ToolList = new List<ToolBase5>();

	public static buShape Copy(buShape refItem)
	{
		buShape copyItem = new buShape();
		Copy(refItem, ref copyItem);
		return copyItem;
	}

	public static void Copy(buShape refItem, ref buShape copyItem)
	{
		if (refItem.GetType() == typeof(buShapeRectangle))
		{
			copyItem = new buShapeRectangle(refItem);
		}
		if (refItem.GetType() == typeof(buShapeCircle))
		{
			copyItem = new buShapeCircle(refItem);
		}
		if (refItem.GetType() == typeof(buShapeEllipse))
		{
			copyItem = new buShapeEllipse(refItem);
		}
		if (refItem.GetType() == typeof(buShapeKeyHole))
		{
			copyItem = new buShapeKeyHole(refItem);
		}
		if (refItem.GetType() == typeof(buShapePolygon))
		{
			copyItem = new buShapePolygon(refItem);
		}
		if (refItem.GetType() == typeof(buShapeSlot))
		{
			copyItem = new buShapeSlot(refItem);
		}
		if (refItem.GetType() == typeof(buShapeFreeDraw))
		{
			copyItem = new buShapeFreeDraw(refItem);
		}
		if (refItem.GetType() == typeof(buShapeFreeLines))
		{
			copyItem = new buShapeFreeLines(refItem);
		}
		if (refItem.GetType() == typeof(buShapeHole))
		{
			copyItem = new buShapeHole(refItem);
		}
		if (refItem.GetType() == typeof(buShapeHoleMulti))
		{
			copyItem = new buShapeHoleMulti(refItem);
		}
		if (refItem.GetType() == typeof(buShapeHole3))
		{
			copyItem = new buShapeHole3(refItem);
		}
		if (refItem.GetType() == typeof(buShapeCut))
		{
			copyItem = new buShapeCut(refItem);
		}
		if (refItem.GetType() == typeof(buShapeProfiling))
		{
			copyItem = new buShapeProfiling(refItem);
		}
		if (refItem.GetType() == typeof(buShapeEngrave))
		{
			copyItem = new buShapeEngrave(refItem);
		}
		if (refItem.GetType() == typeof(buShapeJunction))
		{
			copyItem = new buShapeJunction(refItem);
		}
		if (refItem.GetType() == typeof(buShapeText))
		{
			copyItem = new buShapeText(refItem);
		}
		if (refItem.GetType() == typeof(buShapeNotch))
		{
			copyItem = new buShapeNotch(refItem);
		}
		if (refItem.InfoMessages != null)
		{
			copyItem.InfoMessages = new List<string>();
			for (int i = 0; i <= refItem.InfoMessages.Count - 1; i++)
			{
				copyItem.InfoMessages.Add(refItem.InfoMessages[i]);
			}
		}
		if (refItem.Codes != null)
		{
			copyItem.Codes = new List<string>();
			for (int j = 0; j <= refItem.Codes.Count - 1; j++)
			{
				copyItem.Codes.Add(refItem.Codes[j]);
			}
		}
		copyItem.entitiesShape.Clear();
		copyItem.entitiesShape = new List<buEntity>();
		copyItem.entitiesShape.AddRange(buEntity.Copy(refItem.entitiesShape));
		copyItem.entitiesCam.Clear();
		copyItem.entitiesCam = new List<buEntity>();
		copyItem.entitiesCam.AddRange(buEntity.Copy(refItem.entitiesCam));
		if (refItem.entitiesRef != null)
		{
			copyItem.entitiesRef = new List<buEntity>();
			copyItem.entitiesRef.AddRange(buEntity.Copy(refItem.entitiesRef));
		}
		if (refItem.entitiesDim != null)
		{
			copyItem.entitiesDim = new List<buEntity>();
			copyItem.entitiesDim.AddRange(buEntity.Copy(refItem.entitiesDim));
		}
		if (refItem.Clampers != null)
		{
			copyItem.Clampers = new List<Clamper>();
			Clamper.Copy(refItem.Clampers, ref copyItem.Clampers);
		}
		if (refItem.ProfileData != null)
		{
			copyItem.ProfileData = new ShapeProfileData(refItem.ProfileData);
		}
		copyItem.BasePoint = new Point3D(refItem.BasePoint.X, refItem.BasePoint.Y, refItem.BasePoint.Z);
		copyItem.Offset = new Point3D(refItem.Offset.X, refItem.Offset.Y, refItem.Offset.Z);
		copyItem.CornerPoint = new Point3D(refItem.CornerPoint.X, refItem.CornerPoint.Y, refItem.CornerPoint.Z);
		copyItem.CalculatedPoint = new Point3D(refItem.CalculatedPoint.X, refItem.CalculatedPoint.Y, refItem.CalculatedPoint.Z);
		copyItem.CornerDirection = new Vector3D(refItem.CornerDirection.X, refItem.CornerDirection.Y, refItem.CornerDirection.Z);
		copyItem.Edit = new ShapeEdit(refItem.Edit);
		copyItem.ItemSize = new ShapeSizeInfo(refItem.ItemSize);
		copyItem.LeadInOut = new ShapeLeadInOut(refItem.LeadInOut);
		copyItem.planeOperation = (Plane)refItem.planeOperation.Clone();
		if (refItem.multiCenter != null)
		{
			copyItem.multiCenter = new List<ShapeMultiCenterData>();
			for (int k = 0; k <= refItem.multiCenter.Count - 1; k++)
			{
				copyItem.multiCenter.Add(refItem.multiCenter[k]);
			}
		}
		if (refItem.entitySolid != null)
		{
			buEntity.Copy(refItem.entitySolid, ref copyItem.entitySolid);
		}
		if (refItem.entityWireframe != null)
		{
			copyItem.entityWireframe = new List<Entity>();
			buEntity.Copy(refItem.entityWireframe, ref copyItem.entityWireframe);
		}
		if (refItem.DepthLevel != null)
		{
			copyItem.DepthLevel = new List<double>();
			for (int l = 0; l <= refItem.DepthLevel.Count - 1; l++)
			{
				copyItem.DepthLevel.Add(refItem.DepthLevel[l]);
			}
		}
		if (refItem.Cam != null)
		{
			copyItem.Cam = new camTp(refItem.Cam);
		}
		if (refItem.Tool != null)
		{
			copyItem.Tool = new ToolBase5(refItem.Tool);
		}
		if (refItem.Cam != null)
		{
			copyItem.Cam = new camTp(refItem.Cam);
		}
		if (refItem.CamPar != null)
		{
			copyItem.CamPar = new camParameters5(refItem.CamPar);
		}
	}

	public static void Copy(List<buShape> refItem, ref List<buShape> copyItem)
	{
		copyItem = new List<buShape>();
		for (int i = 0; i <= refItem.Count - 1; i++)
		{
			buShape copyItem2 = new buShape();
			Copy(refItem[i], ref copyItem2);
			copyItem.Add(copyItem2);
		}
	}

	public static string ToDefination(buShape shape)
	{
		string text = "None";
		try
		{
			if (AppLanguage.CadCamDynamic.Count <= 0)
			{
				if (!(shape.GetType() == typeof(buShapeCircle)))
				{
					if (!(shape.GetType() == typeof(buShapeEllipse)))
					{
						if (!(shape.GetType() == typeof(buShapeFreeDraw)))
						{
							if (!(shape.GetType() == typeof(buShapeFreeLines)))
							{
								if (!(shape.GetType() == typeof(buShapeKeyHole)))
								{
									if (!(shape.GetType() == typeof(buShapePolygon)))
									{
										if (!(shape.GetType() == typeof(buShapeRectangle)))
										{
											if (shape.GetType() == typeof(buShapeSlot))
											{
												buShapeSlot buShapeSlot2 = shape as buShapeSlot;
												text = "Slot - Diameter: " + buShapeSlot2.Diameter.ToString("f2") + " , Length: " + buShapeSlot2.Length.ToString("f2") + "Depth: " + buShapeSlot2.Depth.ToString("f2") + " , Plane: " + buLangTranslate.EnumToLang(buShapeSlot2.planeName);
												if (buShapeSlot2.Angle != 0.0)
												{
													text = text + " , Angle: " + buShapeSlot2.Angle.ToString("f2");
												}
											}
										}
										else
										{
											buShapeRectangle buShapeRectangle2 = shape as buShapeRectangle;
											text = "Rectangle - Width: " + buShapeRectangle2.Width.ToString("f2") + " , Height: " + buShapeRectangle2.Height.ToString("f2") + "Depth: " + buShapeRectangle2.Depth.ToString("f2") + " , Plane: " + buLangTranslate.EnumToLang(buShapeRectangle2.planeName);
											if (buShapeRectangle2.Radius > 0.0)
											{
												text = text + " , Radius: " + buShapeRectangle2.Radius.ToString("f2");
											}
											if (buShapeRectangle2.Angle != 0.0)
											{
												text = text + " , Angle: " + buShapeRectangle2.Angle.ToString("f2");
											}
										}
									}
									else
									{
										buShapePolygon buShapePolygon2 = shape as buShapePolygon;
										text = "Polygon - Diameter: " + (buShapePolygon2.Radius * 2.0).ToString("f2") + " , Side: " + buShapePolygon2.Side.ToString("f2") + "Depth: " + buShapePolygon2.Depth.ToString("f2") + " , Plane: " + buLangTranslate.EnumToLang(buShapePolygon2.planeName);
										if (buShapePolygon2.Angle != 0.0)
										{
											text = text + " , Angle: " + buShapePolygon2.Angle.ToString("f2");
										}
									}
								}
								else
								{
									buShapeKeyHole buShapeKeyHole2 = shape as buShapeKeyHole;
									text = "KeyHole - Head Diameter: " + buShapeKeyHole2.HeadDiameter.ToString("f2") + " , Diameter: " + buShapeKeyHole2.Diameter.ToString("f2") + " , Length: " + buShapeKeyHole2.Length.ToString("f2") + "Depth: " + buShapeKeyHole2.Depth.ToString("f2") + " , Plane: " + buLangTranslate.EnumToLang(buShapeKeyHole2.planeName);
									if (buShapeKeyHole2.Angle != 0.0)
									{
										text = text + " , Angle: " + buShapeKeyHole2.Angle.ToString("f2");
									}
								}
							}
							else
							{
								buShapeFreeLines buShapeFreeLines2 = shape as buShapeFreeLines;
								double num = 0.0;
								double num2 = 0.0;
								if ((buShapeFreeLines2.planeName == planeBoxNames.Top) | (buShapeFreeLines2.planeName == planeBoxNames.Bottom))
								{
									num = buShapeFreeLines2.ItemSize.MaxBox.X - buShapeFreeLines2.ItemSize.MinBox.X;
									num2 = buShapeFreeLines2.ItemSize.MaxBox.Y - buShapeFreeLines2.ItemSize.MinBox.Y;
								}
								if ((buShapeFreeLines2.planeName == planeBoxNames.Front) | (buShapeFreeLines2.planeName == planeBoxNames.Back))
								{
									num = buShapeFreeLines2.ItemSize.MaxBox.X - buShapeFreeLines2.ItemSize.MinBox.X;
									num2 = buShapeFreeLines2.ItemSize.MaxBox.Z - buShapeFreeLines2.ItemSize.MinBox.Z;
								}
								if ((buShapeFreeLines2.planeName == planeBoxNames.Top) | (buShapeFreeLines2.planeName == planeBoxNames.Bottom))
								{
									num = buShapeFreeLines2.ItemSize.MaxBox.Y - buShapeFreeLines2.ItemSize.MinBox.Y;
									num2 = buShapeFreeLines2.ItemSize.MaxBox.Z - buShapeFreeLines2.ItemSize.MinBox.Z;
								}
								text = "Free Line - Width: " + num.ToString("f2") + " , Height: " + num2.ToString("f2") + "Depth: " + buShapeFreeLines2.Depth.ToString("f2") + " , Plane: " + buLangTranslate.EnumToLang(buShapeFreeLines2.planeName);
							}
						}
						else
						{
							buShapeFreeDraw buShapeFreeDraw2 = shape as buShapeFreeDraw;
							double num3 = 0.0;
							double num4 = 0.0;
							if ((buShapeFreeDraw2.planeName == planeBoxNames.Top) | (buShapeFreeDraw2.planeName == planeBoxNames.Bottom))
							{
								num3 = buShapeFreeDraw2.ItemSize.MaxBox.X - buShapeFreeDraw2.ItemSize.MinBox.X;
								num4 = buShapeFreeDraw2.ItemSize.MaxBox.Y - buShapeFreeDraw2.ItemSize.MinBox.Y;
							}
							if ((buShapeFreeDraw2.planeName == planeBoxNames.Front) | (buShapeFreeDraw2.planeName == planeBoxNames.Back))
							{
								num3 = buShapeFreeDraw2.ItemSize.MaxBox.X - buShapeFreeDraw2.ItemSize.MinBox.X;
								num4 = buShapeFreeDraw2.ItemSize.MaxBox.Z - buShapeFreeDraw2.ItemSize.MinBox.Z;
							}
							if ((buShapeFreeDraw2.planeName == planeBoxNames.Top) | (buShapeFreeDraw2.planeName == planeBoxNames.Bottom))
							{
								num3 = buShapeFreeDraw2.ItemSize.MaxBox.Y - buShapeFreeDraw2.ItemSize.MinBox.Y;
								num4 = buShapeFreeDraw2.ItemSize.MaxBox.Z - buShapeFreeDraw2.ItemSize.MinBox.Z;
							}
							text = "Free Draw - Width: " + num3.ToString("f2") + " , Height: " + num4.ToString("f2") + "Depth: " + buShapeFreeDraw2.Depth.ToString("f2") + " , Plane: " + buLangTranslate.EnumToLang(buShapeFreeDraw2.planeName);
							if (buShapeFreeDraw2.Angle != 0.0)
							{
								text = text + " , Angle: " + buShapeFreeDraw2.Angle.ToString("f2");
							}
						}
					}
					else
					{
						buShapeEllipse buShapeEllipse2 = shape as buShapeEllipse;
						text = "Ellipse - DiameterX: " + (buShapeEllipse2.RadiusX * 2.0).ToString("f2") + " , DiameterY: " + (buShapeEllipse2.RadiusY * 2.0).ToString("f2") + "Depth: " + buShapeEllipse2.Depth.ToString("f2") + " , Plane: " + buLangTranslate.EnumToLang(buShapeEllipse2.planeName);
						if (buShapeEllipse2.Angle != 0.0)
						{
							text = text + " , Angle: " + buShapeEllipse2.Angle.ToString("f2");
						}
					}
				}
				else
				{
					buShapeCircle buShapeCircle2 = shape as buShapeCircle;
					text = "Circle - Diameter: " + (buShapeCircle2.Radius * 2.0).ToString("f2") + "Depth: " + buShapeCircle2.Depth.ToString("f2") + " , Plane: " + buLangTranslate.EnumToLang(buShapeCircle2.planeName);
				}
			}
			else if (!(shape.GetType() == typeof(buShapeCircle)))
			{
				if (!(shape.GetType() == typeof(buShapeEllipse)))
				{
					if (!(shape.GetType() == typeof(buShapeFreeDraw)))
					{
						if (!(shape.GetType() == typeof(buShapeFreeLines)))
						{
							if (!(shape.GetType() == typeof(buShapeKeyHole)))
							{
								if (!(shape.GetType() == typeof(buShapePolygon)))
								{
									if (!(shape.GetType() == typeof(buShapeRectangle)))
									{
										if (shape.GetType() == typeof(buShapeSlot))
										{
											buShapeSlot buShapeSlot3 = shape as buShapeSlot;
											text = buLangTranslate.preDef.Slot + " - " + buString5.DefItem(buLangTranslate.preDef.Diameter, buShapeSlot3.Diameter, "f2", "") + buString5.DefItem(buLangTranslate.preDef.Length, buShapeSlot3.Length) + buString5.DefItem(buLangTranslate.preDef.Depth, buShapeSlot3.Depth) + buString5.DefItem(buLangTranslate.preDef.Plane, buLangTranslate.EnumToLang(buShapeSlot3.planeName));
											if (buShapeSlot3.Angle != 0.0)
											{
												text += buString5.DefItem(buLangTranslate.preDef.Angle, buShapeSlot3.Angle);
											}
										}
									}
									else
									{
										buShapeRectangle buShapeRectangle3 = shape as buShapeRectangle;
										text = buLangTranslate.preDef.Rect + " - " + buString5.DefItem(buLangTranslate.preDef.Width, buShapeRectangle3.Width, "f2", "") + buString5.DefItem(buLangTranslate.preDef.Height, buShapeRectangle3.Height) + buString5.DefItem(buLangTranslate.preDef.Depth, buShapeRectangle3.Depth) + buString5.DefItem(buLangTranslate.preDef.Plane, buLangTranslate.EnumToLang(buShapeRectangle3.planeName));
										if (buShapeRectangle3.Radius != 0.0)
										{
											text += buString5.DefItem(buLangTranslate.preDef.Radius, buShapeRectangle3.Radius);
										}
										if (buShapeRectangle3.Angle != 0.0)
										{
											text += buString5.DefItem(buLangTranslate.preDef.Angle, buShapeRectangle3.Angle);
										}
									}
								}
								else
								{
									buShapePolygon buShapePolygon3 = shape as buShapePolygon;
									text = buLangTranslate.preDef.Polygon + " - " + buString5.DefItem(buLangTranslate.preDef.Diameter, buShapePolygon3.Radius * 2.0, "f2", "") + buString5.DefItem(buLangTranslate.preDef.Side, buShapePolygon3.Side) + buString5.DefItem(buLangTranslate.preDef.Depth, buShapePolygon3.Depth) + buString5.DefItem(buLangTranslate.preDef.Plane, buLangTranslate.EnumToLang(buShapePolygon3.planeName));
									if (buShapePolygon3.Angle != 0.0)
									{
										text += buString5.DefItem(buLangTranslate.preDef.Angle, buShapePolygon3.Angle);
									}
								}
							}
							else
							{
								buShapeKeyHole buShapeKeyHole3 = shape as buShapeKeyHole;
								text = buLangTranslate.preDef.KeyHole + " - " + buString5.DefItem(buLangTranslate.preDef.HeadDiameter, buShapeKeyHole3.HeadDiameter, "f2", "") + buString5.DefItem(buLangTranslate.preDef.Diameter, buShapeKeyHole3.Diameter) + buString5.DefItem(buLangTranslate.preDef.Length, buShapeKeyHole3.Length) + buString5.DefItem(buLangTranslate.preDef.Depth, buShapeKeyHole3.Depth) + buString5.DefItem(buLangTranslate.preDef.Plane, buLangTranslate.EnumToLang(buShapeKeyHole3.planeName));
								if (buShapeKeyHole3.Angle != 0.0)
								{
									text += buString5.DefItem(buLangTranslate.preDef.Angle, buShapeKeyHole3.Angle);
								}
							}
						}
						else
						{
							buShapeFreeLines buShapeFreeLines3 = shape as buShapeFreeLines;
							double num5 = 0.0;
							double num6 = 0.0;
							if ((buShapeFreeLines3.planeName == planeBoxNames.Top) | (buShapeFreeLines3.planeName == planeBoxNames.Bottom))
							{
								num5 = buShapeFreeLines3.ItemSize.MaxBox.X - buShapeFreeLines3.ItemSize.MinBox.X;
								num6 = buShapeFreeLines3.ItemSize.MaxBox.Y - buShapeFreeLines3.ItemSize.MinBox.Y;
							}
							if ((buShapeFreeLines3.planeName == planeBoxNames.Front) | (buShapeFreeLines3.planeName == planeBoxNames.Back))
							{
								num5 = buShapeFreeLines3.ItemSize.MaxBox.X - buShapeFreeLines3.ItemSize.MinBox.X;
								num6 = buShapeFreeLines3.ItemSize.MaxBox.Z - buShapeFreeLines3.ItemSize.MinBox.Z;
							}
							if ((buShapeFreeLines3.planeName == planeBoxNames.Top) | (buShapeFreeLines3.planeName == planeBoxNames.Bottom))
							{
								num5 = buShapeFreeLines3.ItemSize.MaxBox.Y - buShapeFreeLines3.ItemSize.MinBox.Y;
								num6 = buShapeFreeLines3.ItemSize.MaxBox.Z - buShapeFreeLines3.ItemSize.MinBox.Z;
							}
							text = buLangTranslate.preDef.FreeLines + " - " + buString5.DefItem(buLangTranslate.preDef.Width, num5, "f2", "") + buString5.DefItem(buLangTranslate.preDef.Height, num6) + buString5.DefItem(buLangTranslate.preDef.Depth, buShapeFreeLines3.Depth) + buString5.DefItem(buLangTranslate.preDef.Plane, buLangTranslate.EnumToLang(buShapeFreeLines3.planeName));
						}
					}
					else
					{
						buShapeFreeDraw buShapeFreeDraw3 = shape as buShapeFreeDraw;
						double num7 = 0.0;
						double num8 = 0.0;
						if ((buShapeFreeDraw3.planeName == planeBoxNames.Top) | (buShapeFreeDraw3.planeName == planeBoxNames.Bottom))
						{
							num7 = buShapeFreeDraw3.ItemSize.MaxBox.X - buShapeFreeDraw3.ItemSize.MinBox.X;
							num8 = buShapeFreeDraw3.ItemSize.MaxBox.Y - buShapeFreeDraw3.ItemSize.MinBox.Y;
						}
						if ((buShapeFreeDraw3.planeName == planeBoxNames.Front) | (buShapeFreeDraw3.planeName == planeBoxNames.Back))
						{
							num7 = buShapeFreeDraw3.ItemSize.MaxBox.X - buShapeFreeDraw3.ItemSize.MinBox.X;
							num8 = buShapeFreeDraw3.ItemSize.MaxBox.Z - buShapeFreeDraw3.ItemSize.MinBox.Z;
						}
						if ((buShapeFreeDraw3.planeName == planeBoxNames.Top) | (buShapeFreeDraw3.planeName == planeBoxNames.Bottom))
						{
							num7 = buShapeFreeDraw3.ItemSize.MaxBox.Y - buShapeFreeDraw3.ItemSize.MinBox.Y;
							num8 = buShapeFreeDraw3.ItemSize.MaxBox.Z - buShapeFreeDraw3.ItemSize.MinBox.Z;
						}
						text = buLangTranslate.preDef.FreeDraw + " - " + buString5.DefItem(buLangTranslate.preDef.Width, num7, "f2", "") + buString5.DefItem(buLangTranslate.preDef.Height, num8) + buString5.DefItem(buLangTranslate.preDef.Depth, buShapeFreeDraw3.Depth) + buString5.DefItem(buLangTranslate.preDef.Plane, buLangTranslate.EnumToLang(buShapeFreeDraw3.planeName));
						if (buShapeFreeDraw3.Angle != 0.0)
						{
							text += buString5.DefItem(buLangTranslate.preDef.Angle, buShapeFreeDraw3.Angle);
						}
					}
				}
				else
				{
					buShapeEllipse buShapeEllipse3 = shape as buShapeEllipse;
					text = buLangTranslate.preDef.Ellipse + " - " + buString5.DefItem(buLangTranslate.preDef.DiaX, buShapeEllipse3.RadiusX * 2.0, "f2", "") + buString5.DefItem(buLangTranslate.preDef.DiaY, buShapeEllipse3.RadiusY * 2.0) + buString5.DefItem(buLangTranslate.preDef.Depth, buShapeEllipse3.Depth) + buString5.DefItem(buLangTranslate.preDef.Plane, buLangTranslate.EnumToLang(buShapeEllipse3.planeName));
					if (buShapeEllipse3.Angle != 0.0)
					{
						text += buString5.DefItem(buLangTranslate.preDef.Angle, buShapeEllipse3.Angle);
					}
				}
			}
			else
			{
				buShapeCircle buShapeCircle3 = shape as buShapeCircle;
				text = buLangTranslate.preDef.Cirlce + " - " + buString5.DefItem(buLangTranslate.preDef.Diameter, buShapeCircle3.Radius * 2.0, "f2", "") + buString5.DefItem(buLangTranslate.preDef.Depth, buShapeCircle3.Depth) + buString5.DefItem(buLangTranslate.preDef.Plane, buLangTranslate.EnumToLang(buShapeCircle3.planeName));
			}
			return text;
		}
		catch (Exception)
		{
			return text;
		}
	}

	public static int ToImageIndex(buShape shape)
	{
		if (!(shape.GetType() == typeof(buShapeCircle)))
		{
			if (!(shape.GetType() == typeof(buShapeEllipse)))
			{
				if (!(shape.GetType() == typeof(buShapeFreeDraw)))
				{
					if (!(shape.GetType() == typeof(buShapeKeyHole)))
					{
						if (!(shape.GetType() == typeof(buShapePolygon)))
						{
							if (!(shape.GetType() == typeof(buShapeRectangle)))
							{
								if (!(shape.GetType() == typeof(buShapeSlot)))
								{
									return -1;
								}
								return 5;
							}
							return 0;
						}
						return 4;
					}
					return 3;
				}
				return 6;
			}
			return 2;
		}
		return 1;
	}

	public static string buShapeTypeToString(buShape shape)
	{
		string result = "None";
		try
		{
			if (AppLanguage.CadCamDynamic.Count <= 0)
			{
				if (!(shape.GetType() == typeof(buShapeCircle)))
				{
					if (!(shape.GetType() == typeof(buShapeEllipse)))
					{
						if (!(shape.GetType() == typeof(buShapeFreeDraw)))
						{
							if (!(shape.GetType() == typeof(buShapeKeyHole)))
							{
								if (!(shape.GetType() == typeof(buShapePolygon)))
								{
									if (!(shape.GetType() == typeof(buShapeRectangle)))
									{
										if (shape.GetType() == typeof(buShapeSlot))
										{
											result = "Slot";
										}
									}
									else
									{
										result = "Rectangle";
									}
								}
								else
								{
									result = "Poylgon";
								}
							}
							else
							{
								result = "KeyHole";
							}
						}
						else
						{
							result = "Free Draw";
						}
					}
					else
					{
						result = "Ellipse";
					}
				}
				else
				{
					result = "Circle";
				}
			}
			else if (!(shape.GetType() == typeof(buShapeCircle)))
			{
				if (!(shape.GetType() == typeof(buShapeEllipse)))
				{
					if (!(shape.GetType() == typeof(buShapeFreeDraw)))
					{
						if (!(shape.GetType() == typeof(buShapeKeyHole)))
						{
							if (!(shape.GetType() == typeof(buShapePolygon)))
							{
								if (!(shape.GetType() == typeof(buShapeRectangle)))
								{
									if (shape.GetType() == typeof(buShapeSlot))
									{
										result = AppLanguage.CadCamDynamic[59];
									}
								}
								else
								{
									result = AppLanguage.CadCamDynamic[62];
								}
							}
							else
							{
								result = AppLanguage.CadCamDynamic[70];
							}
						}
						else
						{
							result = AppLanguage.CadCamDynamic[60];
						}
					}
					else
					{
						result = AppLanguage.CadCamDynamic[77];
					}
				}
				else
				{
					result = AppLanguage.CadCamDynamic[54];
				}
			}
			else
			{
				result = AppLanguage.CadCamDynamic[51];
			}
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public static bool isSame(buShape firstShape, buShape secondShape)
	{
		if (!((firstShape.ShapeGroup != secondShape.ShapeGroup) | (firstShape.planeName != secondShape.planeName) | (firstShape.Depth != secondShape.Depth)))
		{
			if (firstShape.ShapeGroup != ShapeGroup.Drill)
			{
				if (firstShape.ShapeGroup != ShapeGroup.Shape)
				{
					return false;
				}
				if (!((firstShape.ShapeType == secondShape.ShapeType) & (firstShape.planeName == secondShape.planeName) & buCompare5.EQ(firstShape.Depth, secondShape.Depth)) || !(buCompare5.EQ(firstShape.ItemSize.MinBox, secondShape.ItemSize.MinBox) & buCompare5.EQ(firstShape.ItemSize.MaxBox, secondShape.ItemSize.MaxBox)) || !(!buCompare5.EQ(firstShape.ItemSize.MinBox, new Point3D()) & !buCompare5.EQ(firstShape.ItemSize.MaxBox, new Point3D())))
				{
					return false;
				}
				return true;
			}
			buShapeHole buShapeHole4 = firstShape as buShapeHole;
			buShapeHole buShapeHole5 = secondShape as buShapeHole;
			if (!((buShapeHole4.DrillType == buShapeHole5.DrillType) & buCompare5.EQ(buShapeHole4.Diameter, buShapeHole5.Diameter) & (buShapeHole4.planeName == buShapeHole5.planeName) & buCompare5.EQ(buShapeHole4.Depth, buShapeHole5.Depth)) || !buCompare5.EQ(buShapeHole4.CalculatedPoint, buShapeHole5.CalculatedPoint))
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public override string ToString()
	{
		string text = "";
		if (!(GetType() == typeof(buShapeRectangle)))
		{
			if (!(GetType() == typeof(buShapeCircle)))
			{
				if (!(GetType() == typeof(buShapeEllipse)))
				{
					if (!(GetType() == typeof(buShapeKeyHole)))
					{
						if (!(GetType() == typeof(buShapePolygon)))
						{
							if (!(GetType() == typeof(buShapeSlot)))
							{
								if (!(GetType() == typeof(buShapeFreeDraw)))
								{
									if (!(GetType() == typeof(buShapeHole)))
									{
										if (!(GetType() == typeof(buShapeHoleMulti)))
										{
											if (!(GetType() == typeof(buShapeHole3)))
											{
												if (!(GetType() == typeof(buShapeCut)))
												{
													if (!(GetType() == typeof(buShapeProfiling)))
													{
														if (!(GetType() == typeof(buShapeJunction)))
														{
															if (!(GetType() == typeof(buShapeEngrave)))
															{
																if (GetType() == typeof(buShapeText))
																{
																	text = ((buShapeText)this).ToString();
																}
															}
															else
															{
																text = ((buShapeEngrave)this).ToString();
															}
														}
														else
														{
															text = ((buShapeJunction)this).ToString();
														}
													}
													else
													{
														text = ((buShapeProfiling)this).ToString();
													}
												}
												else
												{
													text = ((buShapeCut)this).ToString();
												}
											}
											else
											{
												text = ((buShapeHole3)this).ToString();
											}
										}
										else
										{
											text = ((buShapeHoleMulti)this).ToString();
										}
									}
									else
									{
										text = ((buShapeHole)this).ToString();
									}
								}
								else
								{
									text = ((buShapeFreeDraw)this).ToString();
								}
							}
							else
							{
								text = ((buShapeSlot)this).ToString();
							}
						}
						else
						{
							text = ((buShapePolygon)this).ToString();
						}
					}
					else
					{
						text = ((buShapeKeyHole)this).ToString();
					}
				}
				else
				{
					text = ((buShapeEllipse)this).ToString();
				}
			}
			else
			{
				text = ((buShapeCircle)this).ToString();
			}
		}
		else
		{
			text = ((buShapeRectangle)this).ToString();
		}
		if (text.Length <= 0)
		{
			return base.ToString();
		}
		return text;
	}

	public static void Decode(List<string> SL, ref buShape refShape, string Char = "")
	{
		try
		{
			if (SL.Count < 2)
			{
				return;
			}
			if (SL[0].Trim() == "buShapeRectangle")
			{
				double num = buSerilization5.DecoderFromDouble(SL[1]);
				double num2 = buSerilization5.DecoderFromDouble(SL[2]);
				double angle = buSerilization5.DecoderFromDouble(SL[3]);
				double radius = buSerilization5.DecoderFromDouble(SL[4]);
				double chamfer = buSerilization5.DecoderFromDouble(SL[5]);
				if (num > 0.0 && num2 > 0.0)
				{
					refShape = new buShapeRectangle(num, num2, radius, chamfer, 0.0, angle);
				}
			}
			if (SL[0].Trim() == "buShapeCircle")
			{
				double num3 = buSerilization5.DecoderFromDouble(SL[1]);
				if (num3 > 0.0)
				{
					refShape = new buShapeCircle(num3, 0.0);
				}
			}
			if (SL[0].Trim() == "buShapeEllipse")
			{
				double num4 = buSerilization5.DecoderFromDouble(SL[1]);
				double num5 = buSerilization5.DecoderFromDouble(SL[2]);
				double angle2 = buSerilization5.DecoderFromDouble(SL[3]);
				if (num4 > 0.0 && num5 > 0.0)
				{
					refShape = new buShapeEllipse(num4, num5, 0.0, angle2);
				}
			}
			if (SL[0].Trim() == "buShapePolygon")
			{
				double num6 = buSerilization5.DecoderFromDouble(SL[1]);
				int num7 = buSerilization5.DecoderFromInt(SL[2]);
				double angle3 = buSerilization5.DecoderFromDouble(SL[3]);
				if (num6 > 0.0 && num7 > 2)
				{
					refShape = new buShapePolygon(num6, num7, 0.0, angle3);
				}
			}
			if (SL[0].Trim() == "buShapeSlot")
			{
				double num8 = buSerilization5.DecoderFromDouble(SL[1]);
				double num9 = buSerilization5.DecoderFromDouble(SL[2]);
				double angle4 = buSerilization5.DecoderFromDouble(SL[3]);
				if (num8 > 0.0 && num9 > 0.0)
				{
					refShape = new buShapeSlot(num8, num9, 0.0, angle4);
				}
			}
			if (SL[0].Trim() == "buShapeKeyHole")
			{
				double num10 = buSerilization5.DecoderFromDouble(SL[1]);
				double num11 = buSerilization5.DecoderFromDouble(SL[2]);
				double num12 = buSerilization5.DecoderFromDouble(SL[3]);
				double angle5 = buSerilization5.DecoderFromDouble(SL[4]);
				if (num11 > 0.0 && num12 > 0.0 && num10 > 0.0)
				{
					refShape = new buShapeKeyHole(num10, num11, num12, 0.0, angle5);
				}
			}
			if (SL[0].Trim() == "buShapeFreeDraw")
			{
				double num13 = buSerilization5.DecoderFromDouble(SL[1]);
				double num14 = buSerilization5.DecoderFromDouble(SL[2]);
				double angle6 = buSerilization5.DecoderFromDouble(SL[3]);
				if (num13 > 0.0 && num14 > 0.0)
				{
					refShape = new buShapeFreeDraw(num13, num14, 0.0, angle6);
				}
			}
			if (SL[0].Trim() == "buShapeFreeLines")
			{
				double num15 = buSerilization5.DecoderFromDouble(SL[1]);
				double num16 = buSerilization5.DecoderFromDouble(SL[2]);
				if (num15 > 0.0 && num16 > 0.0)
				{
					refShape = new buShapeFreeLines(num15, num16, 0.0);
				}
			}
			if (SL[0].Trim() == "buShapeHole")
			{
				double num17 = buSerilization5.DecoderFromDouble(SL[1]);
				drillTypes drillType = buSerilization5.DecoderFromDrillType(SL[2]);
				bool isMilling = buSerilization5.DecoderFromBool(SL[3]);
				if (num17 > 0.0)
				{
					refShape = new buShapeHole(num17, 0.0);
					((buShapeHole)refShape).isMilling = isMilling;
					((buShapeHole)refShape).DrillType = drillType;
				}
			}
			if (SL[0].Trim() == "buShapeHoleMulti")
			{
				double num18 = buSerilization5.DecoderFromDouble(SL[1]);
				drillTypes type = buSerilization5.DecoderFromDrillType(SL[2]);
				bool isMilling2 = buSerilization5.DecoderFromBool(SL[3]);
				int count = buSerilization5.DecoderFromInt(SL[4]);
				double distance = buSerilization5.DecoderFromDouble(SL[5]);
				double startdistance = buSerilization5.DecoderFromDouble(SL[6]);
				double enddistance = buSerilization5.DecoderFromDouble(SL[7]);
				double angle7 = buSerilization5.DecoderFromDouble(SL[8]);
				if (num18 > 0.0)
				{
					refShape = new buShapeHoleMulti(type, num18, count, distance, startdistance, enddistance, 0.0, angle7);
					((buShapeHoleMulti)refShape).isMilling = isMilling2;
				}
			}
			if (SL[0].Trim() == "buShapeHole3")
			{
				double num19 = buSerilization5.DecoderFromDouble(SL[1]);
				buSerilization5.DecoderFromDrillType(SL[2]);
				bool isMilling3 = buSerilization5.DecoderFromBool(SL[3]);
				double diameteroutside = buSerilization5.DecoderFromDouble(SL[4]);
				double angle8 = buSerilization5.DecoderFromDouble(SL[5]);
				double distancex = buSerilization5.DecoderFromDouble(SL[6]);
				double distancey = buSerilization5.DecoderFromDouble(SL[7]);
				if (num19 > 0.0)
				{
					refShape = new buShapeHole3(num19, 0.0, diameteroutside, distancex, distancey, angle8);
					((buShapeHole3)refShape).isMilling = isMilling3;
				}
			}
			if (SL[0].Trim() == "buShapeCut")
			{
				double num20 = buSerilization5.DecoderFromDouble(SL[1]);
				double length = buSerilization5.DecoderFromDouble(SL[2]);
				double angle9 = buSerilization5.DecoderFromDouble(SL[3]);
				double startdistance2 = buSerilization5.DecoderFromDouble(SL[4]);
				double enddistance2 = buSerilization5.DecoderFromDouble(SL[5]);
				CutTypes slotType = buSerilization5.DecoderFromCutType(SL[6]);
				bool isMilling4 = buSerilization5.DecoderFromBool(SL[7]);
				if (num20 > 0.0)
				{
					refShape = new buShapeCut(slotType, num20, 0.0, length, startdistance2, enddistance2, angle9);
					((buShapeCut)refShape).isMilling = isMilling4;
				}
			}
			if (SL[0].Trim() == "buShapeProfiling")
			{
				double num21 = buSerilization5.DecoderFromDouble(SL[1]);
				double num22 = buSerilization5.DecoderFromDouble(SL[2]);
				double num23 = buSerilization5.DecoderFromDouble(SL[3]);
				double num24 = buSerilization5.DecoderFromDouble(SL[4]);
				ProfilingTypes profilingType = buSerilization5.DecoderFromProfilingType(SL[5]);
				if (num21 > 0.0 || num22 > 0.0 || num23 > 0.0 || num24 > 0.0)
				{
					refShape = new buShapeProfiling(profilingType, num21, 0.0, num22, num23, num24);
				}
			}
			if (SL[0].Trim() == "buShapeJunction")
			{
				double num25 = buSerilization5.DecoderFromDouble(SL[1]);
				double num26 = buSerilization5.DecoderFromDouble(SL[2]);
				double distance2 = buSerilization5.DecoderFromDouble(SL[3]);
				JunctionTypes junctionType = buSerilization5.DecoderFromJunctionType(SL[4]);
				bool ismilling = buSerilization5.DecoderFromBool(SL[5]);
				if (num25 > 0.0 || num26 > 0.0)
				{
					refShape = new buShapeJunction(junctionType, num25, 0.0, num26, distance2, ismilling);
				}
			}
			if (SL[0].Trim() == "buShapeText")
			{
				double num27 = buSerilization5.DecoderFromDouble(SL[1]);
				double num28 = buSerilization5.DecoderFromDouble(SL[2]);
				double angle10 = buSerilization5.DecoderFromDouble(SL[3]);
				string textString = SL[4].Trim();
				string familyName = SL[5].Trim();
				float emSize = buSerilization5.DecoderFromFloat(SL[6]);
				string text = SL[7].Trim();
				if (num27 > 0.0 && num28 > 0.0)
				{
					string text2 = text;
					EnumConverter enumConverter = new EnumConverter(typeof(FontStyle));
					Font font = new Font(familyName, emSize, (FontStyle)enumConverter.ConvertFromString(text2.ToString()));
					refShape = new buShapeText(num27, num28, 0.0, textString, font, angle10);
				}
			}
			if (SL[0].Trim() == "buShapeNotch")
			{
				double num29 = buSerilization5.DecoderFromDouble(SL[1]);
				double num30 = buSerilization5.DecoderFromDouble(SL[2]);
				double startheight = buSerilization5.DecoderFromDouble(SL[3]);
				buSerilization5.DecoderFromDouble(SL[4]);
				UpDownLocationType updown = buSerilization5.DecoderFromUpDownLocationType(SL[5]);
				FrontBackType frontback = buSerilization5.DecoderFromFrontBackType(SL[6]);
				ProfileNotchLocationType location = buSerilization5.DecoderFromProfileNotchLocationType(SL[7]);
				ProfileNotchOperationType notchOpType = buSerilization5.DecoderFromProfileNotchOperationType(SL[8]);
				if (num29 > 0.0 || num30 > 0.0)
				{
					refShape = new buShapeNotch(num29, num30, startheight, 0.0, updown, location, notchOpType, frontback);
				}
			}
			List<string> CalcList = new List<string>();
			buString5.ListToSpecificList("<CommonShape>", "</CommonShape>", AddStartEndKey: false, SL, ref CalcList);
			DecodeCommon(CalcList, ref refShape);
		}
		catch (Exception)
		{
		}
	}

	public static buShape Decode(List<string> SL)
	{
		try
		{
			buShape refShape = null;
			Decode(SL, ref refShape);
			return refShape;
		}
		catch (Exception)
		{
			return null;
		}
	}

	public static void DecodeCommon(List<string> SL, ref buShape refEntity)
	{
		try
		{
			object obj = null;
			object obj2 = null;
			object obj3 = null;
			object obj4 = null;
			object obj5 = null;
			if (!((refEntity != null) & (SL.Count >= 4)))
			{
				return;
			}
			refEntity.ShapeName = buSerilization5.DecoderFromString(SL[0]);
			refEntity.Defination = buSerilization5.DecoderFromString(SL[1]);
			refEntity.Aux = buSerilization5.DecoderFromString(SL[2]);
			refEntity.ID = buSerilization5.DecoderFromInt(SL[3]);
			refEntity.Index = buSerilization5.DecoderFromInt(SL[4]);
			refEntity.Zone = buSerilization5.DecoderFromInt(SL[5]);
			refEntity.Depth = buSerilization5.DecoderFromDouble(SL[6]);
			refEntity.DepthExtra = buSerilization5.DecoderFromDouble(SL[7]);
			refEntity.OffsetDistance = buSerilization5.DecoderFromDouble(SL[8]);
			refEntity.feedCutting = buSerilization5.DecoderFromDouble(SL[9]);
			refEntity.feedPlunge = buSerilization5.DecoderFromDouble(SL[10]);
			refEntity.SpindleSpeed = buSerilization5.DecoderFromDouble(SL[11]);
			refEntity.Enable = buSerilization5.DecoderFromBool(SL[12]);
			refEntity.isEngraving = buSerilization5.DecoderFromBool(SL[13]);
			refEntity.isPocket = buSerilization5.DecoderFromBool(SL[14]);
			refEntity.planeName = buSerilization5.DecoderFromPlaneBoxNames(SL[15]);
			refEntity.ShapeGroup = buSerilization5.DecoderFromShapeGroup(SL[16]);
			refEntity.Corner = buSerilization5.DecoderFromCornerLocation(SL[17]);
			refEntity.Alignment = buSerilization5.DecoderFromObjectAlignment(SL[18]);
			refEntity.ShapeType = buSerilization5.DecoderFromShapeTypes(SL[19]);
			refEntity.OperationColor = buImage5.StringToColor(SL[20], ColorConvertType.String);
			refEntity.CornerPoint = buSerilization5.DecoderFromPoint3D(SL[21]);
			refEntity.BasePoint = buSerilization5.DecoderFromPoint3D(SL[22]);
			refEntity.Offset = buSerilization5.DecoderFromPoint3D(SL[23]);
			refEntity.CalculatedPoint = buSerilization5.DecoderFromPoint3D(SL[24]);
			refEntity.CornerDirection = buSerilization5.DecoderFromVector3D(SL[25]);
			refEntity.planeOperation = buSerilization5.DecoderFromPlane(SL[26]);
			string text = buSerilization5.DecoderFromString(SL[27]);
			if (text.Trim().Length > 0)
			{
				if (ToolList.Count != 0)
				{
					for (int i = 0; i <= ToolList.Count - 1; i++)
					{
						if (ToolList[i].Data.Name.Trim() == text.Trim())
						{
							refEntity.Tool = new ToolBase5(ToolList[i]);
						}
					}
				}
				else
				{
					refEntity.Tool = new ToolBase5();
					refEntity.Tool.Data.Name = text;
				}
			}
			obj = refEntity.Edit;
			buSerilization5.StringToClass(ref obj, SL[28]);
			obj3 = refEntity.Edit.ArrayData;
			buSerilization5.StringToClass(ref obj3, SL[29]);
			obj2 = refEntity.Edit.MirrorData;
			buSerilization5.StringToClass(ref obj2, SL[30]);
			obj4 = refEntity.ItemSize;
			buSerilization5.StringToClass(ref obj4, SL[31]);
			obj5 = refEntity.LeadInOut;
			buSerilization5.StringToClass(ref obj5, SL[32]);
			if (SL[33].IndexOf("SecondToolName") >= 0)
			{
				refEntity.SecondToolName = buSerilization5.DecoderFromString(SL[33]);
			}
			List<string> CalcList = new List<string>();
			buStatics.ListToSpecificList("<DepthLevel>", "</DepthLevel>", AddStartEndKey: false, SL, ref CalcList);
			if (CalcList.Count > 0)
			{
				for (int j = 0; j <= CalcList.Count - 1; j++)
				{
					double result = 0.0;
					if (double.TryParse(CalcList[j], out result))
					{
						refEntity.DepthLevel.Add(result);
					}
				}
			}
			List<string> CalcList2 = new List<string>();
			buStatics.ListToSpecificList("<CamParametersAll>", "</CamParametersAll>", AddStartEndKey: false, SL, ref CalcList2);
			if (CalcList2.Count > 0)
			{
				camParameters5.DecodeSingleLine(CalcList2, "", ref refEntity.CamPar);
			}
			List<string> CalcList3 = new List<string>();
			List<List<string>> CalcList4 = new List<List<string>>();
			buStatics.ListToSpecificList("<entitiesShape>", "</entitiesShape>", AddStartEndKey: false, SL, ref CalcList3);
			buStatics.ListToSpecificList("<buEntity>", "</buEntity>", AddStartEndKey: false, CalcList3, ref CalcList4);
			refEntity.entitiesShape = new List<buEntity>();
			for (int k = 0; k <= CalcList4.Count - 1; k++)
			{
				buEntity buEntity2 = buEntity.Decode(CalcList4[k]);
				if (buEntity2 != null)
				{
					refEntity.entitiesShape.Add(buEntity2);
				}
			}
			CalcList3.Clear();
			CalcList4.Clear();
			CalcList3 = new List<string>();
			CalcList4 = new List<List<string>>();
			buStatics.ListToSpecificList("<entitiesCam>", "</entitiesCam>", AddStartEndKey: false, SL, ref CalcList3);
			buStatics.ListToSpecificList("<buEntity>", "</buEntity>", AddStartEndKey: false, CalcList3, ref CalcList4);
			refEntity.entitiesCam = new List<buEntity>();
			for (int l = 0; l <= CalcList4.Count - 1; l++)
			{
				buEntity buEntity3 = buEntity.Decode(CalcList4[l]);
				if (buEntity3 != null)
				{
					refEntity.entitiesCam.Add(buEntity3);
				}
			}
			CalcList3.Clear();
			CalcList4.Clear();
			CalcList3 = new List<string>();
			CalcList4 = new List<List<string>>();
			buStatics.ListToSpecificList("<entitiesRef>", "</entitiesRef>", AddStartEndKey: false, SL, ref CalcList3);
			if (CalcList3.Count <= 0)
			{
				return;
			}
			buStatics.ListToSpecificList("<buEntity>", "</buEntity>", AddStartEndKey: false, CalcList3, ref CalcList4);
			refEntity.entitiesRef = new List<buEntity>();
			for (int m = 0; m <= CalcList4.Count - 1; m++)
			{
				buEntity buEntity4 = buEntity.Decode(CalcList4[m]);
				if (buEntity4 != null)
				{
					refEntity.entitiesRef.Add(buEntity4);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public static ArrayList ToDefShape(buShape refEntity, int Space)
	{
		ArrayList AL = new ArrayList();
		ToDefShape(refEntity, Space, ref AL);
		return AL;
	}

	public static void ToDefShape(buShape refEntity, int Space, ref ArrayList AL)
	{
		AL.Clear();
		AL = new ArrayList();
		AL.AddRange(refEntity.ToDef(Space));
	}

	public static void ToDefShape(List<buShape> refEntities, int Space, ref ArrayList AL)
	{
		AL.Clear();
		AL = new ArrayList();
		for (int i = 0; i <= refEntities.Count - 1; i++)
		{
			AL.AddRange(refEntities[i].ToDef(Space));
		}
	}

	public static ArrayList ToDefShape(List<buShape> refEntities, int Space)
	{
		ArrayList AL = new ArrayList();
		ToDefShape(refEntities, Space, ref AL);
		return AL;
	}

	public ArrayList ToDef(int Space, string Char = "")
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buString5.SpaceChar(Space) + "<buShape" + Char + ">");
		if (this is buShapeRectangle)
		{
			buShapeRectangle buShapeRectangle2 = this as buShapeRectangle;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buShapeRectangle");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Width: " + buShapeRectangle2.Width);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Height: " + buShapeRectangle2.Height);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Angle: " + buShapeRectangle2.Angle);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Radius: " + buShapeRectangle2.Radius);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Chamfer: " + buShapeRectangle2.Chamfer);
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (this is buShapeCircle)
		{
			buShapeCircle buShapeCircle2 = this as buShapeCircle;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buShapeCircle");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Radius: " + buShapeCircle2.Radius);
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (this is buShapeEllipse)
		{
			buShapeEllipse buShapeEllipse2 = this as buShapeEllipse;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buShapeEllipse");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "RadiusX: " + buShapeEllipse2.RadiusX);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "RadiusY: " + buShapeEllipse2.RadiusY);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Angle: " + buShapeEllipse2.Angle);
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (this is buShapePolygon)
		{
			buShapePolygon buShapePolygon2 = this as buShapePolygon;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buShapePolygon");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Radius: " + buShapePolygon2.Radius);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Side: " + buShapePolygon2.Side);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Angle: " + buShapePolygon2.Angle);
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (this is buShapeSlot)
		{
			buShapeSlot buShapeSlot2 = this as buShapeSlot;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buShapeSlot");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Diameter: " + buShapeSlot2.Diameter);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Length: " + buShapeSlot2.Length);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Angle: " + buShapeSlot2.Angle);
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (this is buShapeKeyHole)
		{
			buShapeKeyHole buShapeKeyHole2 = this as buShapeKeyHole;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buShapeKeyHole");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "HeadDiameter: " + buShapeKeyHole2.HeadDiameter);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Diameter: " + buShapeKeyHole2.Diameter);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Length: " + buShapeKeyHole2.Length);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Angle: " + buShapeKeyHole2.Angle);
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (this is buShapeFreeDraw)
		{
			buShapeFreeDraw buShapeFreeDraw2 = this as buShapeFreeDraw;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buShapeFreeDraw");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Width: " + buShapeFreeDraw2.Width);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Height: " + buShapeFreeDraw2.Height);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Angle: " + buShapeFreeDraw2.Angle);
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (this is buShapeFreeLines)
		{
			buShapeFreeLines buShapeFreeLines2 = this as buShapeFreeLines;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buShapeFreeLines");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Width: " + buShapeFreeLines2.Width);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Height: " + buShapeFreeLines2.Height);
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (GetType() == typeof(buShapeHole))
		{
			buShapeHole buShapeHole4 = this as buShapeHole;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buShapeHole");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Diameter: " + buShapeHole4.Diameter);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "DrillType: " + buShapeHole4.DrillType);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "isMilling: " + buShapeHole4.isMilling);
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (GetType() == typeof(buShapeHoleMulti))
		{
			buShapeHoleMulti buShapeHoleMulti2 = this as buShapeHoleMulti;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buShapeHoleMulti");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Diameter: " + buShapeHoleMulti2.Diameter);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "DrillType: " + buShapeHoleMulti2.DrillType);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "isMilling: " + buShapeHoleMulti2.isMilling);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Count: " + buShapeHoleMulti2.Count);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Distance: " + buShapeHoleMulti2.Distance);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "StartDistance: " + buShapeHoleMulti2.StartDistance);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "EndDistance: " + buShapeHoleMulti2.EndDistance);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Angle: " + buShapeHoleMulti2.Angle);
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (GetType() == typeof(buShapeHole3))
		{
			buShapeHole3 buShapeHole5 = this as buShapeHole3;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buShapeHole3");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Diameter: " + buShapeHole5.Diameter);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "DrillType: " + buShapeHole5.DrillType);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "isMilling: " + buShapeHole5.isMilling);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "DiameterOutside: " + buShapeHole5.DiameterOutside);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Hole3Angle: " + buShapeHole5.Hole3Angle);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "DistanceX: " + buShapeHole5.DistanceX);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "DistanceY: " + buShapeHole5.DistanceY);
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (GetType() == typeof(buShapeCut))
		{
			buShapeCut buShapeCut2 = this as buShapeCut;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buShapeCut");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Diameter: " + buShapeCut2.Diameter);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Length: " + buShapeCut2.Length);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Angle: " + buShapeCut2.Angle);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "StartDistance: " + buShapeCut2.StartDistance);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "EndDistance: " + buShapeCut2.EndDistance);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "CutType: " + buShapeCut2.CutType);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "isMilling: " + buShapeCut2.isMilling);
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (GetType() == typeof(buShapeProfiling))
		{
			buShapeProfiling buShapeProfiling2 = this as buShapeProfiling;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buShapeProfiling");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Radius: " + buShapeProfiling2.Radius);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Length: " + buShapeProfiling2.Length);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Width: " + buShapeProfiling2.Width);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Height: " + buShapeProfiling2.Height);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "ProfilingType: " + buShapeProfiling2.ProfilingType);
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (GetType() == typeof(buShapeJunction))
		{
			buShapeJunction buShapeJunction2 = this as buShapeJunction;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buShapeJunction");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Diameter: " + buShapeJunction2.Diameter);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "DiameterOutside: " + buShapeJunction2.DiameterOutside);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Distance: " + buShapeJunction2.Distance);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "JunctionType: " + buShapeJunction2.JunctionType);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "isMilling: " + buShapeJunction2.isMilling);
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (GetType() == typeof(buShapeText))
		{
			buShapeText buShapeText2 = this as buShapeText;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buShapeText");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Width: " + buShapeText2.Width);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Height: " + buShapeText2.Height);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "Angle: " + buShapeText2.Angle);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "TextString: " + buShapeText2.TextString.ToString());
			arrayList.Add(buString5.SpaceChar(Space + 2) + "TextFontName: " + buShapeText2.TextFont.Name.ToString());
			arrayList.Add(buString5.SpaceChar(Space + 2) + "TextFontSize: " + buShapeText2.TextFont.Size);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "TextFontStyle: " + buShapeText2.TextFont.Style);
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		if (GetType() == typeof(buShapeNotch))
		{
			buShapeNotch buShapeNotch2 = this as buShapeNotch;
			arrayList.Add(buString5.SpaceChar(Space + 2) + "buShapeNotch");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "NotchWidth: " + buShapeNotch2.NotchWidth);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "NotchHeight: " + buShapeNotch2.NotchHeight);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "NotchStartHeight: " + buShapeNotch2.NotchStartHeight);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "NotchAngle: " + buShapeNotch2.NotchAngle);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "NotchUpDown: " + buShapeNotch2.NotchUpDown);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "NotchFrontBack: " + buShapeNotch2.NotchFrontBack);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "NotchLocation: " + buShapeNotch2.NotchLocation);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "NotchOPType: " + buShapeNotch2.NotchOPType);
			arrayList.AddRange(ToDefCommon(Space + 2));
		}
		arrayList.Add(buString5.SpaceChar(Space) + "</buShape" + Char + ">");
		return arrayList;
	}

	public ArrayList ToDefCommon(int Space)
	{
		ArrayList AL = new ArrayList();
		AL.Add(buString5.SpaceChar(Space) + "<CommonShape>");
		AL.Add(buString5.SpaceChar(Space + 2) + "ShapeName: " + ShapeName.ToString());
		AL.Add(buString5.SpaceChar(Space + 2) + "Defination: " + Defination.ToString());
		AL.Add(buString5.SpaceChar(Space + 2) + "Aux: " + Aux.ToString());
		AL.Add(buString5.SpaceChar(Space + 2) + "ID: " + ID);
		AL.Add(buString5.SpaceChar(Space + 2) + "Index: " + Index);
		AL.Add(buString5.SpaceChar(Space + 2) + "Zone: " + Zone);
		AL.Add(buString5.SpaceChar(Space + 2) + "Depth: " + Depth);
		AL.Add(buString5.SpaceChar(Space + 2) + "DepthExtra: " + DepthExtra);
		AL.Add(buString5.SpaceChar(Space + 2) + "OffsetDistance: " + OffsetDistance);
		AL.Add(buString5.SpaceChar(Space + 2) + "feedCutting: " + feedCutting);
		AL.Add(buString5.SpaceChar(Space + 2) + "feedPlunge: " + feedPlunge);
		AL.Add(buString5.SpaceChar(Space + 2) + "SpindleSpeed: " + SpindleSpeed);
		AL.Add(buString5.SpaceChar(Space + 2) + "Enable: " + Enable);
		AL.Add(buString5.SpaceChar(Space + 2) + "isEngraving: " + isEngraving);
		AL.Add(buString5.SpaceChar(Space + 2) + "isPocket: " + isPocket);
		AL.Add(buString5.SpaceChar(Space + 2) + "planeName: " + planeName);
		AL.Add(buString5.SpaceChar(Space + 2) + "ShapeGroup: " + ShapeGroup);
		AL.Add(buString5.SpaceChar(Space + 2) + "Corner: " + Corner);
		AL.Add(buString5.SpaceChar(Space + 2) + "Alignment: " + Alignment);
		AL.Add(buString5.SpaceChar(Space + 2) + "ShapeType: " + ShapeType);
		AL.Add(buString5.SpaceChar(Space + 2) + "Color: " + buImage5.ColorToString(OperationColor, ColorConvertType.String));
		AL.Add(buString5.SpaceChar(Space + 2) + "CornerPoint: " + buSerilization5.ToDef(CornerPoint));
		AL.Add(buString5.SpaceChar(Space + 2) + "BasePoint: " + buSerilization5.ToDef(BasePoint));
		AL.Add(buString5.SpaceChar(Space + 2) + "Offset: " + buSerilization5.ToDef(Offset));
		AL.Add(buString5.SpaceChar(Space + 2) + "CalculatedPoint: " + buSerilization5.ToDef(CalculatedPoint));
		AL.Add(buString5.SpaceChar(Space + 2) + "CornerDirection: " + buSerilization5.ToDef(CornerDirection));
		AL.Add(buString5.SpaceChar(Space + 2) + "Plane = " + buSerilization5.ToDef(planeOperation));
		if (Tool == null)
		{
			AL.Add(buString5.SpaceChar(Space + 2) + "ToolName: ");
		}
		else
		{
			AL.Add(buString5.SpaceChar(Space + 2) + "ToolName: " + Tool.Data.Name.ToString());
		}
		AL.Add(buString5.SpaceChar(Space + 2) + "Edit = " + buSerilization5.ClassToString(Edit));
		AL.Add(buString5.SpaceChar(Space + 2) + "EditArray = " + buSerilization5.ClassToString(Edit.ArrayData));
		AL.Add(buString5.SpaceChar(Space + 2) + "EditMirror = " + buSerilization5.ClassToString(Edit.MirrorData));
		AL.Add(buString5.SpaceChar(Space + 2) + "ItemSize = " + buSerilization5.ClassToString(ItemSize));
		AL.Add(buString5.SpaceChar(Space + 2) + "LeadInOut = " + buSerilization5.ClassToString(LeadInOut));
		if (SecondToolName == null)
		{
			AL.Add(buString5.SpaceChar(Space + 2) + "SecondToolName: ");
		}
		else
		{
			AL.Add(buString5.SpaceChar(Space + 2) + "SecondToolName: " + SecondToolName.ToString());
		}
		if (DepthLevel.Count > 0)
		{
			AL.Add(buString5.SpaceChar(Space + 2) + "<DepthLevel>");
			for (int i = 0; i <= DepthLevel.Count - 1; i++)
			{
				AL.Add(DepthLevel[i].ToString());
			}
			AL.Add(buString5.SpaceChar(Space + 2) + "</DepthLevel>");
		}
		if (CamPar != null)
		{
			camParameters5.ToDefSingleLine(CamPar, ref AL, "", Space + 2);
		}
		AL.Add(buString5.SpaceChar(Space + 2) + "<entitiesShape>");
		AL.AddRange(buEntity.ToDefEntity(entitiesShape, Space + 4));
		AL.Add(buString5.SpaceChar(Space + 2) + "</entitiesShape>");
		AL.Add(buString5.SpaceChar(Space + 2) + "<entitiesCam>");
		AL.AddRange(buEntity.ToDefEntity(entitiesCam, Space + 4));
		AL.Add(buString5.SpaceChar(Space + 2) + "</entitiesCam>");
		if (entitiesRef != null)
		{
			AL.Add(buString5.SpaceChar(Space + 2) + "<entitiesRef>");
			AL.AddRange(buEntity.ToDefEntity(entitiesRef, Space + 4));
			AL.Add(buString5.SpaceChar(Space + 2) + "</entitiesRef>");
		}
		if (multiCenter != null)
		{
			AL.Add(buString5.SpaceChar(Space + 2) + "<multiCenter>");
			for (int j = 0; j <= multiCenter.Count - 1; j++)
			{
				AL.Add(buString5.SpaceChar(Space + 2) + "multiCenter = " + buSerilization5.ClassToString(multiCenter[j]));
			}
			AL.Add(buString5.SpaceChar(Space + 2) + "</multiCenter>");
		}
		AL.Add(buString5.SpaceChar(Space) + "</CommonShape>");
		return AL;
	}
}
