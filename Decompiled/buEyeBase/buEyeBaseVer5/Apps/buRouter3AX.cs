using System.Collections.Generic;
using System.Drawing;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;

namespace buEyeBaseVer5.Apps;

public class buRouter3AX
{
	public static List<string> LangRouterStatus = new List<string>();

	public static List<string> LangRouterMessage = new List<string>();

	public static List<string> LangRouterCaptions = new List<string>();

	public static List<string> LangRouterCommands = new List<string>();

	public buRouter3AX()
	{
		if (!buVector5.smethod_0("buRouter3AX"))
		{
			throw new RegisterException("buRouter3AX");
		}
	}

	public void CreatePlaneEntities(buEntity refPlaneEntity, buEntity refTextEntity, CamPlaneHeightType HeightType, int Index, Router3AXDisplaySettings Settings, ref Entity entPlane, ref Entity entText)
	{
		entPlane = null;
		entText = null;
		Color color = Settings.colorPlaneBottom.Color;
		int transperancy = Settings.colorPlaneBottom.Transperancy;
		if (HeightType == CamPlaneHeightType.Top)
		{
			color = Settings.colorPlaneTop.Color;
			transperancy = Settings.colorPlaneTop.Transperancy;
		}
		if (HeightType == CamPlaneHeightType.Retract)
		{
			color = Settings.colorPlaneRetract.Color;
			transperancy = Settings.colorPlaneRetract.Transperancy;
		}
		if (HeightType == CamPlaneHeightType.Clearance)
		{
			color = Settings.colorPlaneClearance.Color;
			transperancy = Settings.colorPlaneClearance.Transperancy;
		}
		if (refPlaneEntity != null)
		{
			buEntity.Copy(refPlaneEntity, ref entPlane);
			if (entPlane != null)
			{
				if (entPlane.EntityData != null)
				{
					if (entPlane.EntityData.GetType() != typeof(CustomData))
					{
						entPlane.EntityData = new CustomData();
					}
				}
				else
				{
					entPlane.EntityData = new CustomData();
				}
				CustomData customData = entPlane.EntityData as CustomData;
				entPlane.Color = Color.FromArgb(transperancy, color);
				entPlane.ColorMethod = colorMethodType.byEntity;
				entPlane.LineTypeMethod = colorMethodType.byEntity;
				entPlane.Selectable = false;
				customData.typeDefination = entityTypeDefination.Plane;
				customData.RefIndex = Index;
				customData.ActionName = HeightType.ToString();
			}
		}
		if (refTextEntity == null)
		{
			return;
		}
		buEntity.Copy(refTextEntity, ref entText);
		if (entText == null)
		{
			return;
		}
		if (entText.EntityData != null)
		{
			if (entText.EntityData.GetType() != typeof(CustomData))
			{
				entText.EntityData = new CustomData();
			}
		}
		else
		{
			entText.EntityData = new CustomData();
		}
		CustomData customData2 = entText.EntityData as CustomData;
		entText.Color = Color.FromArgb(Settings.colorPlaneText.Transperancy, Settings.colorPlaneText.Color);
		entText.ColorMethod = colorMethodType.byEntity;
		entText.LineTypeMethod = colorMethodType.byEntity;
		entText.Selectable = false;
		customData2.typeDefination = entityTypeDefination.Plane;
		customData2.RefIndex = Index;
		customData2.ActionName = HeightType.ToString();
	}

	public actionTypeBU CamDrillTypeToAction(CamDrillType DrillType)
	{
		if (DrillType != CamDrillType.Point)
		{
			return actionTypeBU.None;
		}
		return actionTypeBU.routerCamDrillPoint;
	}

	public actionTypeBU CamWireframeTypeToAction(CamWireFrameType WireType)
	{
		return WireType switch
		{
			CamWireFrameType.Contour => actionTypeBU.routerCamContours, 
			CamWireFrameType.Pocket => actionTypeBU.routerCamPocketing, 
			CamWireFrameType.CenterPath => actionTypeBU.routerCamCenterPath, 
			CamWireFrameType.Chamfer2D => actionTypeBU.routerCamChamfer, 
			CamWireFrameType.Engrave => actionTypeBU.routerCamEngrave, 
			CamWireFrameType.Face => actionTypeBU.routerCamFace, 
			CamWireFrameType.FloorFinish => actionTypeBU.routerCamFloorFinish, 
			CamWireFrameType.TextEngrave => actionTypeBU.routerCamTextEngrave, 
			CamWireFrameType.Trochoidal => actionTypeBU.routerCamTrochoidial, 
			_ => actionTypeBU.None, 
		};
	}

	public actionTypeBU CamMeshTypeToAction(CamTriangularMeshType MeshType)
	{
		return MeshType switch
		{
			CamTriangularMeshType.Rough => actionTypeBU.routerCamMesh3DRough, 
			CamTriangularMeshType.ParallelCuts => actionTypeBU.routerCamMesh3DParalelCut, 
			CamTriangularMeshType.ConstantZ => actionTypeBU.routerCamMesh3DConstantZ, 
			CamTriangularMeshType.Flatlands => actionTypeBU.routerCamMesh3DFlatLand, 
			CamTriangularMeshType.Pencil => actionTypeBU.routerCamMesh3DPencil, 
			_ => actionTypeBU.None, 
		};
	}

	public actionTypeBU CamMeshTypeToAction(CamTriangularMesh5AxType MeshType)
	{
		return MeshType switch
		{
			CamTriangularMesh5AxType.Rough => actionTypeBU.routerCamMesh5AXRough, 
			CamTriangularMesh5AxType.ParallelCuts => actionTypeBU.routerCamMesh5AXParalelCut, 
			CamTriangularMesh5AxType.ConstantZ => actionTypeBU.routerCamMesh5AXConstantZ, 
			_ => actionTypeBU.None, 
		};
	}

	public actionTypeBU CamSurfaceTypeToAction(CamSurfaceType MeshType)
	{
		if (MeshType != CamSurfaceType.SurfaceParalel)
		{
			return actionTypeBU.None;
		}
		return actionTypeBU.routerCamSurface5AXParalelCut;
	}

	public string JobToString(Router3AXItem Item)
	{
		string text = Item.ItemName;
		if (Item.Stock != null)
		{
			text = text + " - " + buLangTranslate.preDef.Stock + " : " + Item.Stock.SizeStock.Width.ToString("f1") + " X " + Item.Stock.SizeStock.Height.ToString("f1") + " X " + Item.Stock.SizeStock.Depth.ToString("f1");
		}
		return text;
	}

	public string JobStockToString(Router3AXItem Item)
	{
		string text = buLangTranslate.preDef.Stock;
		if (Item.Stock != null)
		{
			text = text + " : " + Item.Stock.SizeStock.Width.ToString("f1") + " X " + Item.Stock.SizeStock.Height.ToString("f1") + " X " + Item.Stock.SizeStock.Depth.ToString("f1");
		}
		return text;
	}

	public string JobCamToString(Router3AXCAM Cam)
	{
		string text = "";
		if (Cam.camMode != CamMode.WireFrame)
		{
			if (Cam.camMode != CamMode.TriangularMesh)
			{
				if (Cam.camMode != CamMode.TriangularMesh5AX)
				{
					if (Cam.camMode == CamMode.Drill)
					{
						text += buLangTranslate.preDef.Drill;
						if (Cam.camDrillType == CamDrillType.Line)
						{
							text = text + " - " + buLangTranslate.preDef.Line;
						}
						if (Cam.camDrillType == CamDrillType.Point)
						{
							text = text + " - " + buLangTranslate.preDef.Point;
						}
						if (Cam.camDrillType == CamDrillType.Surface)
						{
							text = text + " - " + buLangTranslate.preDef.Surface;
						}
					}
				}
				else
				{
					text += buLangTranslate.preDef.Mesh;
					if (Cam.camMesh5AXType == CamTriangularMesh5AxType.ParallelCuts)
					{
						text = text + " - " + buLangTranslate.preDef.ParalelCuts + " 5 " + buLangTranslate.preDef.Axes;
					}
					if (Cam.camMesh5AXType == CamTriangularMesh5AxType.ConstantZ)
					{
						text = text + " - " + buLangTranslate.preDef.ConstantZ + " 5 " + buLangTranslate.preDef.Axes;
					}
					if (Cam.camMesh5AXType == CamTriangularMesh5AxType.Rough)
					{
						text = text + " - " + buLangTranslate.preDef.Rough + " 5 " + buLangTranslate.preDef.Axes;
					}
				}
			}
			else
			{
				text += buLangTranslate.preDef.Mesh;
				if (Cam.camMeshType == CamTriangularMeshType.ConstantCusp)
				{
					text = text + " - " + buLangTranslate.preDef.ConstantCusp;
				}
				if (Cam.camMeshType == CamTriangularMeshType.ConstantZ)
				{
					text = text + " - " + buLangTranslate.preDef.ConstantZ;
				}
				if (Cam.camMeshType == CamTriangularMeshType.Flatlands)
				{
					text = text + " - " + buLangTranslate.preDef.Flatlands;
				}
				if (Cam.camMeshType == CamTriangularMeshType.Geodesic)
				{
					text = text + " - " + buLangTranslate.preDef.Geodesic;
				}
				if (Cam.camMeshType == CamTriangularMeshType.ParallelCuts)
				{
					text = text + " - " + buLangTranslate.preDef.ParalelCuts;
				}
				if (Cam.camMeshType == CamTriangularMeshType.Pencil)
				{
					text = text + " - " + buLangTranslate.preDef.Pencil;
				}
				if (Cam.camMeshType == CamTriangularMeshType.ProjectCurves)
				{
					text = text + " - " + buLangTranslate.preDef.ProjectCurves;
				}
				if (Cam.camMeshType == CamTriangularMeshType.Projection)
				{
					text = text + " - " + buLangTranslate.preDef.Projection;
				}
				if (Cam.camMeshType == CamTriangularMeshType.Rotary)
				{
					text = text + " - " + buLangTranslate.preDef.Rotary;
				}
				if (Cam.camMeshType == CamTriangularMeshType.RotaryFinish)
				{
					text = text + " - " + buLangTranslate.preDef.RotaryFinish;
				}
				if (Cam.camMeshType == CamTriangularMeshType.RotaryRough)
				{
					text = text + " - " + buLangTranslate.preDef.ConstantCusp;
				}
				if (Cam.camMeshType == CamTriangularMeshType.Rough)
				{
					text = text + " - " + buLangTranslate.preDef.Rough;
				}
			}
		}
		else
		{
			text += buLangTranslate.preDef.Wireframe;
			if (Cam.camWireframeType == CamWireFrameType.CenterPath)
			{
				text = text + " - " + buLangTranslate.preDef.CenterPath;
			}
			if (Cam.camWireframeType == CamWireFrameType.Chamfer2D)
			{
				text = text + " - " + buLangTranslate.preDef.ChamferPath;
			}
			if (Cam.camWireframeType == CamWireFrameType.Contour)
			{
				text = text + " - " + buLangTranslate.preDef.Contour;
			}
			if (Cam.camWireframeType == CamWireFrameType.Engrave)
			{
				text = text + " - " + buLangTranslate.preDef.Engrave;
			}
			if (Cam.camWireframeType == CamWireFrameType.Face)
			{
				text = text + " - " + buLangTranslate.preDef.Face;
			}
			if (Cam.camWireframeType == CamWireFrameType.FloorFinish)
			{
				text = text + " - " + buLangTranslate.preDef.FloorFinish;
			}
			if (Cam.camWireframeType == CamWireFrameType.Pocket)
			{
				text = text + " - " + buLangTranslate.preDef.Pocket;
			}
			if (Cam.camWireframeType == CamWireFrameType.TextEngrave)
			{
				text = text + " - " + buLangTranslate.preDef.TextEngrave;
			}
			if (Cam.camWireframeType == CamWireFrameType.Trochoidal)
			{
				text = text + " - " + buLangTranslate.preDef.Trochoidal;
			}
			if (Cam.CamName.Length > 0)
			{
				text = Cam.CamName;
			}
		}
		return text;
	}

	public string JobCamToolToString(ToolBase5 Tool)
	{
		string text = buLangTranslate.preDef.Tool;
		if (Tool.Data.Name.Length > 0)
		{
			text = Tool.Data.Name;
		}
		return text + " - " + buLangTranslate.preDef.Diameter + " : " + Tool.Geometry.Diameter.ToString("f1") + " - " + buLangTranslate.preDef.Length + " : " + Tool.Geometry.Length.ToString("f1");
	}

	public string JobCamInfoToString(camParameters5 CamPar)
	{
		string text = buLangTranslate.preDef.Feed + " : " + CamPar.Speeds.Feed;
		if (CamPar.Steps.Enable)
		{
			text = (text = text + " - " + buLangTranslate.preDef.Step + " : " + buLangTranslate.preDef.Enable);
		}
		return text;
	}

	public int JobCamInfoToIndex()
	{
		return 38;
	}

	public int JobCamToolToIndex(ToolBase5 Tool)
	{
		if (Tool.Geometry.GeometryType != ToolType.Barrel)
		{
			if (Tool.Geometry.GeometryType != ToolType.Bullnose)
			{
				if (Tool.Geometry.GeometryType != ToolType.Chamfer)
				{
					if (Tool.Geometry.GeometryType != ToolType.ConvexTip)
					{
						if (Tool.Geometry.GeometryType != ToolType.Dove)
						{
							if (Tool.Geometry.GeometryType != ToolType.Flat)
							{
								if (Tool.Geometry.GeometryType != ToolType.FromFile)
								{
									if (Tool.Geometry.GeometryType != ToolType.Laser)
									{
										if (Tool.Geometry.GeometryType != ToolType.Lollipop)
										{
											if (Tool.Geometry.GeometryType != ToolType.Saw)
											{
												if (Tool.Geometry.GeometryType != ToolType.Slot)
												{
													if (Tool.Geometry.GeometryType != ToolType.Sphere)
													{
														if (Tool.Geometry.GeometryType != ToolType.Taper)
														{
															if (Tool.Geometry.GeometryType != ToolType.WateJet)
															{
																return -1;
															}
															return 37;
														}
														return 36;
													}
													return 35;
												}
												return 34;
											}
											return 33;
										}
										return 32;
									}
									return 31;
								}
								return 30;
							}
							return 29;
						}
						return 28;
					}
					return 27;
				}
				return 26;
			}
			return 25;
		}
		return 24;
	}

	public int JobCamToIndex(Router3AXCAM Cam)
	{
		if (Cam.camMode != CamMode.WireFrame)
		{
			if (Cam.camMode != CamMode.TriangularMesh)
			{
				if (Cam.camMode != CamMode.TriangularMesh5AX)
				{
					if (Cam.camMode == CamMode.Drill)
					{
						if (Cam.camDrillType == CamDrillType.Line)
						{
							return 13;
						}
						if (Cam.camDrillType == CamDrillType.Point)
						{
							return 12;
						}
						if (Cam.camDrillType == CamDrillType.Surface)
						{
							return 14;
						}
					}
				}
				else
				{
					if (Cam.camMesh5AXType == CamTriangularMesh5AxType.ParallelCuts)
					{
						return 39;
					}
					if (Cam.camMesh5AXType == CamTriangularMesh5AxType.ConstantZ)
					{
						return 40;
					}
				}
			}
			else
			{
				if (Cam.camMeshType == CamTriangularMeshType.ConstantCusp)
				{
					return 21;
				}
				if (Cam.camMeshType == CamTriangularMeshType.ConstantZ)
				{
					return 17;
				}
				if (Cam.camMeshType == CamTriangularMeshType.Flatlands)
				{
					return 19;
				}
				if (Cam.camMeshType == CamTriangularMeshType.ParallelCuts)
				{
					return 16;
				}
				if (Cam.camMeshType == CamTriangularMeshType.Pencil)
				{
					return 18;
				}
				if (Cam.camMeshType == CamTriangularMeshType.ProjectCurves)
				{
					return 20;
				}
				if (Cam.camMeshType == CamTriangularMeshType.Projection)
				{
					return 22;
				}
				if (Cam.camMeshType == CamTriangularMeshType.Rotary)
				{
					return 23;
				}
				if (Cam.camMeshType == CamTriangularMeshType.Rough)
				{
					return 15;
				}
			}
		}
		else
		{
			if (Cam.camWireframeType == CamWireFrameType.CenterPath)
			{
				return 2;
			}
			if (Cam.camWireframeType == CamWireFrameType.Chamfer2D)
			{
				return 3;
			}
			if (Cam.camWireframeType == CamWireFrameType.Contour)
			{
				return 7;
			}
			if (Cam.camWireframeType == CamWireFrameType.Engrave)
			{
				return 4;
			}
			if (Cam.camWireframeType == CamWireFrameType.Face)
			{
				return 5;
			}
			if (Cam.camWireframeType == CamWireFrameType.FloorFinish)
			{
				return 6;
			}
			if (Cam.camWireframeType == CamWireFrameType.Pocket)
			{
				return 8;
			}
			if (Cam.camWireframeType == CamWireFrameType.TextEngrave)
			{
				return 9;
			}
			if (Cam.camWireframeType == CamWireFrameType.Trochoidal)
			{
				return 10;
			}
		}
		return -1;
	}
}
