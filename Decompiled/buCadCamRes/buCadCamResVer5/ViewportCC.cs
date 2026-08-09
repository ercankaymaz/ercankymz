using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;
using ns8;

namespace buCadCamResVer5;

public class ViewportCC : Design
{
	public Point3D pntUpperRight = new Point3D();

	public Point3D pntUpperLeft = new Point3D();

	public Point3D pntLowerLeft = new Point3D();

	public Point3D pntLowerRight = new Point3D();

	public double ZoomRatio = 1.0;

	public static System.Drawing.Point mouseLocation;

	private System.Drawing.Point point_0;

	private Segment2D segment2D_0;

	public static System.Drawing.Point mouseDownLocation;

	public static int UnderMouseEntityIndex = -1;

	public static object UnderMouseEdge = null;

	public static object UnderMouseFace = null;

	public static Point3D UnderMouseVertice = null;

	public static pickStateType currPickState;

	public static List<List<Point3D>> FreeDrawStrokeList = new List<List<Point3D>>();

	public static List<Point3D> FreeDrawStrokes = new List<Point3D>();

	public static int entityPickIndex = -1;

	public static Entity PickedLastEntity = null;

	public static List<Entity> entitiesUnderMouse = new List<Entity>();

	public static List<Entity> entitiesSelectedUnderMouse = new List<Entity>();

	public static Brep.Face[] DynamicSelectedFace = null;

	public static Brep.Edge[] DynamicSelectedEdge = null;

	public static Point3D[] DynamicSelectedVertex = null;

	public static Brep.Face[] DynamicSelectedInnerFace = null;

	public static int[] UnderMouseEntities = null;

	public static string textDynamical = null;

	public static bool buttonPressedForSelection = false;

	public static bool buttonPressedFreeDraw = false;

	public static bool ForbiddenAreaClicked = false;

	public static bool ForbiddenAreaClickedView = false;

	public static bool MiddleButtonPressed = false;

	public static bool MousePressed = false;

	protected override void OnMouseDown(MouseEventArgs e)
	{
		try
		{
			MousePressed = true;
			if (clsVar.threadCalculations == null || clsVar.threadCalculations.IsAlive)
			{
			}
			if (e.Button != MouseButtons.Middle)
			{
				MiddleButtonPressed = false;
			}
			else
			{
				MiddleButtonPressed = true;
			}
			ForbiddenAreaClicked = false;
			if (base.Viewports[0].ViewCubeIcon.Contains(e.Location) | base.Viewports[0].ToolBars[0].Contains(e.Location))
			{
				ForbiddenAreaClicked = true;
				ForbiddenAreaClickedView = true;
			}
			if (!ForbiddenAreaClicked & !AppBool.MousePositionFromMotion)
			{
				ScreenToPlane(mouseLocation, ccVars.planeActive, out ccVars.pntActive);
			}
			if (ccVars.pntActive == null)
			{
				return;
			}
			clsInit.appCommand.CoordinateCalculation(ccVars.pntActive);
			if (ccVars.ConstantCoordinateEnable.Z)
			{
				ccVars.pntActive.Z = ccVars.ConstantCoordinate.Z;
			}
			if (clsVar.varInterface.MinDistanceForEntity > 0.0 && ccVars.Action == actionTypeBU.drawPolyline)
			{
				for (int i = 0; i <= base.Entities.Count - 1; i++)
				{
					if (base.Entities[i] is ICurve)
					{
						ICurve curve = base.Entities[i] as ICurve;
						double t = 0.0;
						curve.ClosestPointTo(ccVars.pntActive, out t);
						Point3D overPoint = new Point3D();
						bool pointOnEntity = clsInit.cVector5.GetPointOnEntity(ccVars.pntActive, base.Entities[i], ref overPoint);
						t = Point3D.Distance(overPoint, ccVars.pntActive);
						if (pointOnEntity & (t < clsVar.varInterface.MinDistanceForEntity))
						{
							double angle = clsInit.cVector5.PointAngle(ccVars.pntActive, overPoint, ccVars.planeActive);
							clsInit.cVector5.LineWithLengthAndAngle(overPoint, clsVar.varInterface.MinDistanceForEntity, angle, ref ccVars.pntActive);
						}
					}
				}
			}
			if (clsVar.UserMode.ProfileMode.Enable)
			{
				UnderMouseEntities = GetAllEntitiesUnderMouseCursor(e.Location, selectableOnly: false);
				if ((UnderMouseEntities != null) & (UnderMouseEntities.Length != 0))
				{
					for (int j = 0; j <= UnderMouseEntities.Length - 1; j++)
					{
						_ = base.Entities[UnderMouseEntities[j]];
					}
					clsInit.appProfile.doSelectedEntities(UnderMouseEntities);
				}
			}
			if ((e.Button == MouseButtons.Left) & ((base.ActionMode == actionType.None) | (base.ActionMode == actionType.SelectVisibleByPickDynamic)) & ccVars.selectionProcess & !ForbiddenAreaClicked)
			{
				buttonPressedForSelection = true;
				mouseDownLocation = (mouseLocation = e.Location);
				currPickState = pickStateType.Pick;
			}
			if ((e.Button == MouseButtons.Left) & (ccVars.Action == actionTypeBU.drawFreeDraw))
			{
				buttonPressedFreeDraw = true;
				if ((clsVar.varInterface.FreeDrawVar.MouseMode == FreeDrawMouseModeType.DownDown) & (FreeDrawStrokes.Count >= 2))
				{
					FreeDrawStrokeList.Add(FreeDrawStrokes);
					new List<Point3D>();
					ccVars.pntDrawDynamicLinesArr.Add(FreeDrawStrokes);
					clsInit.appCommand.cmdMainFormStatusUpdate(AppLanguage.CadCamStatus[93]);
					FreeDrawStrokes = new List<Point3D>();
					buttonPressedFreeDraw = false;
				}
				if (clsVar.varInterface.FreeDrawVar.MouseMode == FreeDrawMouseModeType.DownUp)
				{
					FreeDrawStrokes.Clear();
					clsInit.appCommand.cmdMainFormStatusUpdate(AppLanguage.CadCamStatus[94]);
				}
			}
			if (!ForbiddenAreaClicked)
			{
				clsInit.appCommand.viewportMouseDown(ccVars.pntActive, this, e);
				if (clsVar.UserMode.NestingMode.Enable)
				{
					UnderMouseEntities = GetAllEntitiesUnderMouseCursor(e.Location, selectableOnly: false);
					if ((UnderMouseEntities != null) & (UnderMouseEntities.Length == 0) & (ccVars.SelectionOP.Selections.Count > 0) & (currPickState == pickStateType.Pick) & clsVar.varSelection.ClearSelectionWhenPressEmptySpace)
					{
						if (ccVars.Action != actionTypeBU.eventMove)
						{
							if ((ccVars.Action == actionTypeBU.None) & (ccVars.stpDrawing == 0))
							{
								clsInit.appCommand.Reset();
							}
						}
						else
						{
							if (ccVars.stpDrawing == 2)
							{
								if (ccVars.Moved)
								{
									ccVars.Moved = false;
								}
								else
								{
									clsInit.appCommand.Reset();
								}
							}
							if ((ccVars.stpDrawing == 3) & !ccVars.MoveEntityPointPressed)
							{
								bool flag = false;
								if (clsVar.varDisplay.ShowSelectedEntitiesMovePoint)
								{
									for (int k = 0; k <= ccVars.SelectionOP.Selections.Count - 1; k++)
									{
										for (int l = 0; l <= ccVars.SelectionOP.Selections[k].AlingPoints.MovePoints.Count - 1; l++)
										{
											if (clsInit.cVector5.IsPointInsideWindow(ccVars.pntActive, ccVars.SelectionOP.Selections[k].AlingPoints.MovePoints[l], clsVar.varMouse.Osnap.CatchResolution * ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ZoomRatio, ccVars.planeActive))
											{
												flag = true;
											}
										}
									}
								}
								if (!flag)
								{
									clsInit.appCommand.Reset();
								}
							}
						}
					}
				}
			}
			PaintBackBuffer();
			SwapBuffers();
			base.OnMouseDown(e);
		}
		catch (Exception)
		{
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		try
		{
			if (clsVar.threadCalculations == null || clsVar.threadCalculations.IsAlive)
			{
			}
			mouseLocation = e.Location;
			if (mouseLocation == point_0)
			{
				return;
			}
			if (buttonPressedForSelection & ccVars.selectionProcess)
			{
				int num = e.Location.X - mouseDownLocation.X;
				if (num <= 10)
				{
					if (num >= -10)
					{
						currPickState = pickStateType.Pick;
					}
					else if (!clsVar.varSelection.DontUseRectangleSelection)
					{
						currPickState = pickStateType.Crossing;
					}
				}
				else if (!clsVar.varSelection.DontUseRectangleSelection)
				{
					currPickState = pickStateType.Enclosed;
				}
				if (ccVars.selectionOnlyPick)
				{
					currPickState = pickStateType.Pick;
				}
			}
			if (!AppBool.MousePositionFromMotion)
			{
				ScreenToPlane(mouseLocation, ccVars.planeActive, out ccVars.pntActive);
			}
			if (clsVar.varInterface.MinDistanceForEntity > 0.0 && ccVars.Action == actionTypeBU.drawPolyline)
			{
				for (int i = 0; i <= base.Entities.Count - 1; i++)
				{
					if (base.Entities[i] is ICurve)
					{
						ICurve curve = base.Entities[i] as ICurve;
						double t = 0.0;
						curve.ClosestPointTo(ccVars.pntActive, out t);
						Point3D overPoint = new Point3D();
						bool pointOnEntity = clsInit.cVector5.GetPointOnEntity(ccVars.pntActive, base.Entities[i], ref overPoint);
						t = Point3D.Distance(overPoint, ccVars.pntActive);
						if (pointOnEntity & (t < clsVar.varInterface.MinDistanceForEntity))
						{
							double angle = clsInit.cVector5.PointAngle(ccVars.pntActive, overPoint, ccVars.planeActive);
							clsInit.cVector5.LineWithLengthAndAngle(overPoint, clsVar.varInterface.MinDistanceForEntity, angle, ref ccVars.pntActive);
						}
					}
				}
			}
			if ((ccVars.pntActive != null) & !MousePressed)
			{
				ccVars.HighLightPoints.Clear();
				entitiesSelectedUnderMouse.Clear();
				entitiesUnderMouse.Clear();
				int[] allEntitiesUnderMouseCursor = GetAllEntitiesUnderMouseCursor(e.Location);
				if (allEntitiesUnderMouseCursor == null)
				{
					ccVars.OsnapCatchPoint.UnderEntityIndex = -1;
					UnderMouseEntityIndex = -1;
					clsItem.timToolTip.Enabled = false;
					ccVars.Pages[ccVars.PageIndex].Form.lbl_tooltip.Visible = false;
				}
				else
				{
					if (allEntitiesUnderMouseCursor.Length != 0)
					{
						if ((ccVars.Action == actionTypeBU.None) & (base.ActionMode == actionType.None))
						{
							UnderMouseEntityIndex = allEntitiesUnderMouseCursor[0];
							ccVars.OsnapCatchPoint.UnderEntityIndex = UnderMouseEntityIndex;
							clsItem.timToolTip.Enabled = true;
						}
					}
					else
					{
						UnderMouseEntityIndex = -1;
						ccVars.OsnapCatchPoint.UnderEntityIndex = -1;
						clsItem.timToolTip.Enabled = false;
						ccVars.Pages[ccVars.PageIndex].Form.lbl_tooltip.Visible = false;
					}
					new List<Point3D>();
					ccVars.numberOfUnderEntity = allEntitiesUnderMouseCursor.Length;
					ccVars.numberOfUnderSelectedEntity = 0;
					for (int j = 0; j <= allEntitiesUnderMouseCursor.Length - 1; j++)
					{
						UnderMouseEntityIndex = allEntitiesUnderMouseCursor[j];
						ccVars.OsnapCatchPoint.UnderEntityIndex = UnderMouseEntityIndex;
						if (!((UnderMouseEntityIndex >= 0) & (UnderMouseEntityIndex <= base.Entities.Count - 1)))
						{
							continue;
						}
						entitiesUnderMouse.Add(base.Entities[UnderMouseEntityIndex]);
						if (base.Entities[UnderMouseEntityIndex].Selected)
						{
							entitiesSelectedUnderMouse.Add(base.Entities[UnderMouseEntityIndex]);
							ccVars.numberOfUnderSelectedEntity++;
						}
						if (!clsInit.cVector5.isEntityDrawing(base.Entities[UnderMouseEntityIndex]))
						{
							if (!(base.Entities[UnderMouseEntityIndex].GetType() == typeof(Mesh)) && !(base.Entities[UnderMouseEntityIndex] is Surface) && base.Entities[UnderMouseEntityIndex] is Brep && ccVars.Action == actionTypeBU.camContours)
							{
								ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.SelectVisibleByPickDynamic;
								ccVars.Pages[ccVars.PageIndex].Form.viewportcad.SelectionFilterMode = selectionFilterType.Edge;
							}
							continue;
						}
						((ICurve)base.Entities[UnderMouseEntityIndex]).ClosestPointTo(ccVars.pntActive, out ccVars.OsnapCatchPoint.DistanceToPoint);
						ccVars.OsnapCatchPoint.EntityPoint = ((ICurve)base.Entities[UnderMouseEntityIndex]).PointAt(ccVars.OsnapCatchPoint.DistanceToPoint);
						if (base.Entities[UnderMouseEntityIndex].Vertices != null)
						{
							HighLights highLights = new HighLights();
							highLights.PointsList.AddRange(base.Entities[UnderMouseEntityIndex].Vertices.ToArray());
							ccVars.HighLightPoints.Add(highLights);
						}
						if (ccVars.Action == actionTypeBU.camContours && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode == actionType.SelectVisibleByPickDynamic)
						{
							ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
							ccVars.Pages[ccVars.PageIndex].Form.viewportcad.SelectionFilterMode = selectionFilterType.Edge;
						}
					}
					if (entitiesSelectedUnderMouse.Count > 0)
					{
						clsInit.cVector5.BoxSizeCalculate(entitiesSelectedUnderMouse, ref ccVars.pntSelectedMin, ref ccVars.pntSelectedMid, ref ccVars.pntSelectedMax);
					}
				}
				clsInit.appCommand.CoordinateCalculation(ccVars.pntActive);
				if (ccVars.ConstantCoordinateEnable.Z)
				{
					ccVars.pntActive.Z = ccVars.ConstantCoordinate.Z;
				}
			}
			if (ccVars.pntActive != null)
			{
				clsInit.appCommand.viewportMouseMove(ccVars.pntActive, this, e);
			}
			point_0 = mouseLocation;
			bool flag = false;
			if ((((ccVars.Action == actionTypeBU.drawMeasure) | (ccVars.Action == actionTypeBU.profileSelectPlaneThenOperation) | (ccVars.Action == actionTypeBU.profileSelectPlaneThenAdd)) & !MiddleButtonPressed) && clsVar.varSelection.DynamicSelection != DynamicalSelectionType.Points)
			{
				flag = true;
			}
			if (!flag)
			{
				PaintBackBuffer();
				SwapBuffers();
			}
			base.OnMouseMove(e);
		}
		catch (Exception)
		{
		}
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		try
		{
			MousePressed = false;
			if (clsVar.threadCalculations == null || clsVar.threadCalculations.IsAlive)
			{
			}
			MiddleButtonPressed = false;
			ForbiddenAreaClicked = false;
			if (base.Viewports[0].ViewCubeIcon.Contains(e.Location) | base.Viewports[0].ToolBars[0].Contains(e.Location))
			{
				ForbiddenAreaClicked = true;
			}
			PickedLastEntity = null;
			if (!ForbiddenAreaClicked)
			{
				if ((buttonPressedFreeDraw & (ccVars.Action == actionTypeBU.drawFreeDraw)) && clsVar.varInterface.FreeDrawVar.MouseMode == FreeDrawMouseModeType.DownUp)
				{
					if (FreeDrawStrokes.Count > 0)
					{
						clsInit.appCommand.cmdMainFormStatusUpdate(AppLanguage.CadCamStatus[93]);
						FreeDrawStrokeList.Add(FreeDrawStrokes);
						ccVars.pntDrawDynamicLinesArr.Add(FreeDrawStrokes);
						FreeDrawStrokes = new List<Point3D>();
					}
					buttonPressedFreeDraw = false;
				}
				if (ccVars.selectionProcess & (e.Button == MouseButtons.Left) & buttonPressedForSelection)
				{
					List<int> list = new List<int>();
					List<int> list2 = new List<int>();
					if (buttonPressedForSelection)
					{
						if (base.CurrentBlockReference == null)
						{
							new List<Entity>(base.Entities);
						}
						else
						{
							_ = base.Blocks[base.CurrentBlockReference.BlockName].Entities;
						}
						buttonPressedForSelection = false;
						entityPickIndex = -1;
						int num = mouseLocation.X - mouseDownLocation.X;
						int num2 = mouseLocation.Y - mouseDownLocation.Y;
						System.Drawing.Point point_ = mouseDownLocation;
						System.Drawing.Point point = mouseLocation;
						Class5.smethod_9(ref point, ref point_);
						int[] selectedIndices;
						switch (currPickState)
						{
						case pickStateType.Crossing:
						{
							if (num == 0 || num2 == 0)
							{
								break;
							}
							SelectedItem[] crossingEntities = GetCrossingEntities(new Rectangle(point_, new Size(Math.Abs(num), Math.Abs(num2))), base.Entities, firstOnly: false, out selectedIndices);
							if (crossingEntities != null && selectedIndices != null)
							{
								for (int j = 0; j < selectedIndices.Length; j++)
								{
									clsInit.appCommand.ManageSelection(selectedIndices[j], Control.ModifierKeys, list, list2);
								}
								clsInit.appCommand.SelectionAnalyzeAfterSelected(Control.ModifierKeys);
							}
							break;
						}
						case pickStateType.Pick:
						{
							entityPickIndex = GetEntityUnderMouseCursor(mouseLocation);
							if (entityPickIndex < 0)
							{
								break;
							}
							PickedLastEntity = base.Entities[entityPickIndex];
							bool flag = false;
							if (ccVars.Action == actionTypeBU.eventRotateVerHor)
							{
								flag = true;
							}
							if (flag)
							{
								break;
							}
							if (!(clsVar.varSelection.SmartSelection & !ccVars.disableSmartSelection & (base.Entities[entityPickIndex] is ICurve)))
							{
								clsInit.appCommand.ManageSelection(entityPickIndex, Control.ModifierKeys, list, list2);
							}
							else
							{
								GetChainEntitiesSettings settings = new GetChainEntitiesSettings(addToselection: true, entityPickIndex, clsVar.varSelection.UseSelectedEntityLayerForChainEntities);
								clsInit.cVector5.GetChainEntities(ccVars.pntActive, ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.ToList(), ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Blocks, settings, ref ccVars.SelectionOP);
								if (Control.ModifierKeys == Keys.Control)
								{
									clsInit.appCommand.ManageSelection(entityPickIndex, Control.ModifierKeys, list, list2);
								}
							}
							clsInit.appCommand.SelectionAnalyzeAfterSelected(Control.ModifierKeys);
							if (clsInit.appDrill != null)
							{
								clsInit.appDrill.GetPickEntity(entityPickIndex);
							}
							if (clsInit.appMarble == null)
							{
								break;
							}
							if (((entityPickIndex >= 0) & (entityPickIndex <= base.Entities.Count - 1)) && base.Entities[entityPickIndex].EntityData != null && base.Entities[entityPickIndex].EntityData is CustomData)
							{
								if (((CustomData)base.Entities[entityPickIndex].EntityData).infoBasePoint == null)
								{
									((CustomData)base.Entities[entityPickIndex].EntityData).infoBasePoint = new Point3D();
								}
								((CustomData)base.Entities[entityPickIndex].EntityData).infoBasePoint.X = ccVars.pntActive.X;
								((CustomData)base.Entities[entityPickIndex].EntityData).infoBasePoint.Y = ccVars.pntActive.Y;
								((CustomData)base.Entities[entityPickIndex].EntityData).infoBasePoint.Z = ccVars.pntActive.Z;
							}
							clsInit.appMarble.doGetSelectedItemFromPick(entityPickIndex, ccVars.pntActive);
							break;
						}
						case pickStateType.Enclosed:
						{
							if (num == 0 || num2 == 0)
							{
								break;
							}
							SelectedItem[] enclosedEntities = GetEnclosedEntities(new Rectangle(point_, new Size(Math.Abs(num), Math.Abs(num2))), firstOnly: false, out selectedIndices);
							if (enclosedEntities != null && selectedIndices != null)
							{
								for (int i = 0; i < selectedIndices.Length; i++)
								{
									clsInit.appCommand.ManageSelection(selectedIndices[i], Control.ModifierKeys, list, list2);
								}
								clsInit.appCommand.SelectionAnalyzeAfterSelected(Control.ModifierKeys);
							}
							break;
						}
						}
						Invalidate();
					}
					if (list.Count > 0)
					{
						clsInit.appCommand.SelectedToSelectionAdd(list);
					}
					if (list2.Count > 0)
					{
						clsInit.appCommand.SelectedToSelectionRemove(list2);
					}
				}
				clsInit.appCommand.viewportMouseUp(ccVars.pntActive, this, e);
			}
			PaintBackBuffer();
			SwapBuffers();
			base.OnMouseUp(e);
		}
		catch (Exception)
		{
			MessageBox.Show("Error");
		}
	}

	protected override void OnDoubleClick(EventArgs e)
	{
		int[] allEntitiesUnderMouseCursor = GetAllEntitiesUnderMouseCursor(mouseLocation);
		if (allEntitiesUnderMouseCursor == null || allEntitiesUnderMouseCursor.Length == 0)
		{
		}
		base.OnDoubleClick(e);
	}

	protected override void DrawOverlay(DrawSceneParams data)
	{
		try
		{
			if (clsVar.threadCalculations == null || clsVar.threadCalculations.IsAlive)
			{
			}
			if (ccVars.pntActive == null)
			{
				return;
			}
			ZoomRatio = Class5.smethod_52(this);
			ccVars.Pages[ccVars.PageIndex].Form.lbl_tooltip.Visible = false;
			for (int i = 0; i <= base.Entities.Count - 1; i++)
			{
				_ = base.Entities[i];
			}
			ScreenToPlane(new System.Drawing.Point(base.Width, 0), ccVars.planeActive, out pntUpperRight);
			ScreenToPlane(new System.Drawing.Point(0, 0), ccVars.planeActive, out pntUpperLeft);
			ScreenToPlane(new System.Drawing.Point(0, base.Height), ccVars.planeActive, out pntLowerLeft);
			ScreenToPlane(new System.Drawing.Point(base.Width, base.Height), ccVars.planeActive, out pntLowerRight);
			if (pntLowerLeft != null)
			{
				buVector5.ScreenInfo.pntMin.X = pntLowerLeft.X;
				buVector5.ScreenInfo.pntMin.Y = pntLowerLeft.Y;
				buVector5.ScreenInfo.pntMin.Z = pntLowerLeft.Z;
				buVector5.ScreenInfo.pntMax.X = pntUpperRight.X;
				buVector5.ScreenInfo.pntMax.Y = pntUpperRight.Y;
				buVector5.ScreenInfo.pntMax.Z = pntUpperRight.Z;
				buVector5.ScreenInfo.ScreenSize.dX = buVector5.ScreenInfo.pntMax.X - buVector5.ScreenInfo.pntMin.X;
				buVector5.ScreenInfo.ScreenSize.dY = buVector5.ScreenInfo.pntMax.Y - buVector5.ScreenInfo.pntMin.Y;
				buVector5.ScreenInfo.ScreenSize.dZ = buVector5.ScreenInfo.pntMax.Z - buVector5.ScreenInfo.pntMin.Z;
			}
			buVector5.ScreenInfo.pntCurrent.X = ccVars.pntActive.X;
			buVector5.ScreenInfo.pntCurrent.Y = ccVars.pntActive.Y;
			buVector5.ScreenInfo.pntCurrent.Z = ccVars.pntActive.Z;
			if ((buVector5.isPlaneXYorYX(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive) | buVector5.isPlaneYZorZY(ccVars.planeActive)) && ((pntUpperRight != null) & (pntUpperLeft != null) & (pntLowerLeft != null) & (pntLowerRight != null)))
			{
				method_0();
			}
			base.RenderContext.EnableXOR(enable: false);
			base.RenderContext.SetState(depthStencilStateType.DepthTestOff);
			if (clsVar.varView.ShowOsnapPoints)
			{
				method_2();
			}
			if (clsVar.varView.ShowEntityPoints)
			{
				method_3();
			}
			if (segment2D_0 != null)
			{
				base.RenderContext.SetLineSize(4f);
				base.RenderContext.SetColorWireframe(Color.Red);
				base.RenderContext.DrawLine(segment2D_0.P0, segment2D_0.P1);
			}
			if (ccVars.pntDrawDynamicMarkers.Count > 0)
			{
				for (int j = 0; j <= ccVars.pntDrawDynamicMarkers.Count - 1; j++)
				{
					method_27(ccVars.pntDrawDynamicMarkers[j], clsVar.varView.displayMarker.Thickness, clsVar.varView.displayMarker.Color, 15.0);
				}
			}
			method_21();
			method_28();
			if (ccVars.enableViewportDrawCurrentLine)
			{
				DrawCurrentLine(ccVars.pntBase, ccVars.pntActive);
				if (ccVars.RealDrawMode)
				{
					method_16(ccVars.pntBase, ccVars.pntActive, clsVar.varInterface.FatWireframeDistance, clsVar.varDisplay.displayDynamicArrowLineDrawing.Color, clsVar.varDisplay.displayDynamicArrowLineDrawing.Thickness);
				}
			}
			if (ccVars.Action == actionTypeBU.drawFreeDraw)
			{
				method_20();
			}
			if ((ccVars.Action == actionTypeBU.marbleDrawCompositeCurve) & (ccVars.pntDynamicCompositeCurve.Count > 0))
			{
				DrawDynamicPointCompositeCurve(ccVars.pntActive);
			}
			method_17();
			DrawDynamicPointArr();
			DrawDynamicPointList();
			DrawDynamicPointLineArr();
			DrawDynamicPointLineArrColor();
			DrawDynamicMeasure();
			method_18();
			method_19();
			if (clsVar.varSelection.ShowAllBoxes)
			{
				method_22();
			}
			if (clsVar.varView.ShowDynamicText & ccVars.enableViewportTextForCommand)
			{
				method_23(ccVars.pntActive, dynamicInfo.Command, dynamicInfo.Info);
			}
			if (clsVar.varView.ShowDynamicBigCross & ccVars.enableViewportCross)
			{
				method_26(ccVars.pntActive);
			}
			if (clsVar.varView.ShowDynamicCross & ccVars.enableViewportCross)
			{
				method_27(ccVars.pntActive, clsVar.varView.displayDynamicCrossDisplay.Thickness, clsVar.varView.displayDynamicCrossDisplay.Color);
				if (ccVars.selectionProcess)
				{
					Point2D point2D = WorldToScreen(ccVars.pntActive);
					method_5(new System.Drawing.Point((int)point2D.X, (int)point2D.Y), 8.0, clsVar.varView.displayDynamicCrossDisplay.Color, clsVar.varView.displayDynamicCrossDisplay.Thickness);
				}
			}
			method_1();
			if (ccVars.dynamicTextOnMouse.Length > 0)
			{
				method_24(mouseLocation.X, mouseLocation.Y, ccVars.dynamicTextOnMouse);
			}
			if (ccVars.DrawCircle.Count > 0)
			{
				for (int k = 0; k <= ccVars.DrawCircle.Count - 1; k++)
				{
					Point2D point2D2 = WorldToScreen(ccVars.DrawCircle[k].Center);
					method_10(new System.Drawing.Point((int)point2D2.X, (int)point2D2.Y), clsVar.varDisplay.DrawCircleSize, clsVar.varDisplay.displayCircle.Color, clsVar.varDisplay.displayCircle.Thickness);
				}
			}
			if (ccVars.DrawPointer)
			{
				DrawPointer();
			}
			if (buttonPressedForSelection)
			{
				if (currPickState != pickStateType.Crossing)
				{
					if (currPickState == pickStateType.Enclosed)
					{
						method_4(mouseDownLocation, mouseLocation, clsVar.varSelection.colorSelectionRightToLeft, clsVar.varSelection.SelectionTransparancy, bool_0: true, bool_1: false);
					}
				}
				else
				{
					method_4(mouseDownLocation, mouseLocation, clsVar.varSelection.colorSelectionLeftToRight, clsVar.varSelection.SelectionTransparancy, bool_0: true, bool_1: true);
				}
			}
			if (textDynamical != null)
			{
				method_25(ccVars.pntActive, textDynamical);
			}
			base.RenderContext.EnableXOR(enable: false);
			base.DrawOverlay(data);
		}
		catch (Exception)
		{
		}
	}

	public void GetDynamicSelectionEntityInfo(Entity refEntity, int Index, out Brep.Face[] SelectedFace, out Brep.Edge[] SelectedEdge, out Point3D[] SelectedVertice, out Brep.Face[] SelectedInnerFace)
	{
		SelectedFace = null;
		SelectedEdge = null;
		SelectedVertice = null;
		SelectedInnerFace = null;
		for (int i = 0; i <= base.Blocks.Count - 1; i++)
		{
			for (int j = 0; j <= base.Blocks[i].Entities.Count - 1; j++)
			{
				if (base.Blocks[i].Entities[j].GetType() == typeof(Brep))
				{
					Brep.Face[] selectedFaces = ((Brep)base.Blocks[i].Entities[j]).GetSelectedFaces();
					if (selectedFaces == null)
					{
					}
				}
			}
		}
		if (refEntity.GetType() == typeof(BlockReference))
		{
			for (int k = 0; k <= base.Blocks.Count - 1; k++)
			{
				if (((BlockReference)refEntity).BlockName == base.Blocks[k].Name)
				{
					for (int l = 0; l <= base.Blocks[k].Entities.Count - 1; l++)
					{
						GetDynamicSelectionEntityInfo(base.Blocks[k].Entities[l], Index, out SelectedFace, out SelectedEdge, out SelectedVertice, out SelectedInnerFace);
					}
				}
			}
		}
		if (!(refEntity.GetType() == typeof(Brep)))
		{
			return;
		}
		SelectedFace = ((Brep)refEntity).GetSelectedFaces();
		SelectedEdge = ((Brep)refEntity).GetSelectedEdges();
		SelectedVertice = ((Brep)refEntity).GetSelectedVertices();
		SelectedInnerFace = ((Brep)refEntity).GetSelectedInnerFaces();
		if (SelectedFace == null)
		{
			if (SelectedEdge == null)
			{
				if (SelectedVertice == null)
				{
					if (SelectedInnerFace == null)
					{
						UnderMouseFace = null;
						UnderMouseEdge = null;
						UnderMouseVertice = null;
						return;
					}
					if (SelectedInnerFace[0].Parametric == null)
					{
						((Brep)refEntity).Rebuild(0.01);
					}
					UnderMouseFace = SelectedInnerFace[0];
					UnderMouseEntityIndex = Index;
					clsItem.timToolTip.Enabled = true;
				}
				else if (SelectedVertice.Length != 0)
				{
					UnderMouseVertice = SelectedVertice[0];
					UnderMouseEntityIndex = Index;
					clsItem.timToolTip.Enabled = true;
				}
			}
			else if (SelectedEdge.Length != 0)
			{
				UnderMouseEdge = SelectedEdge[0];
				UnderMouseEntityIndex = Index;
				clsItem.timToolTip.Enabled = true;
			}
		}
		else if (SelectedFace.Length != 0)
		{
			if (SelectedFace[0].Parametric == null)
			{
				((Brep)refEntity).Rebuild(0.01);
			}
			UnderMouseFace = SelectedFace[0];
			UnderMouseEntityIndex = Index;
			clsItem.timToolTip.Enabled = true;
		}
	}

	private void method_0()
	{
		try
		{
			base.RenderContext.SetState(blendStateType.Blend);
			bool flag = false;
			if ((buCompare.EQ(base.ActiveViewport.Camera.Rotation.X, 0.5, 0.01) & buCompare.EQ(base.ActiveViewport.Camera.Rotation.Y, 0.5, 0.01) & buCompare.EQ(base.ActiveViewport.Camera.Rotation.Z, 0.5, 0.01) & buCompare.EQ(base.ActiveViewport.Camera.Rotation.W, 0.5, 0.01)) | (buCompare.EQ(base.ActiveViewport.Camera.Rotation.X, 0.0, 0.01) & buCompare.EQ(base.ActiveViewport.Camera.Rotation.Y, 0.0, 0.01) & buCompare.EQ(base.ActiveViewport.Camera.Rotation.Z, 0.707, 0.01) & buCompare.EQ(base.ActiveViewport.Camera.Rotation.W, 0.707, 0.01)) | (buCompare.EQ(base.ActiveViewport.Camera.Rotation.X, 0.0, 0.01) & buCompare.EQ(base.ActiveViewport.Camera.Rotation.Y, 0.0, 0.01) & buCompare.EQ(base.ActiveViewport.Camera.Rotation.Z, 0.0, 0.01) & buCompare.EQ(base.ActiveViewport.Camera.Rotation.W, 1.0, 0.01)) | (buCompare.EQ(base.ActiveViewport.Camera.Rotation.X, 0.0, 0.01) & buCompare.EQ(base.ActiveViewport.Camera.Rotation.Y, 0.0, 0.01) & buCompare.EQ(base.ActiveViewport.Camera.Rotation.Z, -0.707, 0.01) & buCompare.EQ(base.ActiveViewport.Camera.Rotation.W, 0.707, 0.01)) | (buCompare.EQ(base.ActiveViewport.Camera.Rotation.X, -0.5, 0.01) & buCompare.EQ(base.ActiveViewport.Camera.Rotation.Y, -0.5, 0.01) & buCompare.EQ(base.ActiveViewport.Camera.Rotation.Z, 0.5, 0.01) & buCompare.EQ(base.ActiveViewport.Camera.Rotation.W, 0.5, 0.01)) | (buCompare.EQ(base.ActiveViewport.Camera.Rotation.X, 0.0, 0.01) & buCompare.EQ(base.ActiveViewport.Camera.Rotation.Y, 0.0, 0.01) & buCompare.EQ(base.ActiveViewport.Camera.Rotation.Z, 1.0, 0.01) & buCompare.EQ(base.ActiveViewport.Camera.Rotation.W, 0.0, 0.01)))
			{
				flag = true;
			}
			if (clsVar.varDisplay.LeftRuler.Enable && flag)
			{
				base.RenderContext.SetColorWireframe(Color.FromArgb(clsVar.varDisplay.LeftRuler.Transparancy, clsVar.varDisplay.LeftRuler.RulerColor.R, clsVar.varDisplay.LeftRuler.RulerColor.G, clsVar.varDisplay.LeftRuler.RulerColor.B));
				base.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
				base.RenderContext.DrawQuad(new RectangleF(0f, 0f, (float)clsVar.varDisplay.LeftRuler.Width, base.Height));
			}
			if (clsVar.varDisplay.RightRuler.Enable && flag)
			{
				base.RenderContext.SetColorWireframe(Color.FromArgb(clsVar.varDisplay.RightRuler.Transparancy, clsVar.varDisplay.RightRuler.RulerColor.R, clsVar.varDisplay.RightRuler.RulerColor.G, clsVar.varDisplay.RightRuler.RulerColor.B));
				base.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
				base.RenderContext.DrawQuad(new RectangleF((float)((double)base.Width - clsVar.varDisplay.RightRuler.Width), 0f, (float)clsVar.varDisplay.RightRuler.Width, base.Height));
			}
			if (clsVar.varDisplay.BottomRuler.Enable && flag)
			{
				base.RenderContext.SetColorWireframe(Color.FromArgb(clsVar.varDisplay.BottomRuler.Transparancy, clsVar.varDisplay.BottomRuler.RulerColor.R, clsVar.varDisplay.BottomRuler.RulerColor.G, clsVar.varDisplay.BottomRuler.RulerColor.B));
				base.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
				base.RenderContext.DrawQuad(new RectangleF(0f, 0f, base.Width, (float)clsVar.varDisplay.BottomRuler.Height));
			}
			if (clsVar.varDisplay.TopRuler.Enable && flag)
			{
				base.RenderContext.SetColorWireframe(Color.FromArgb(clsVar.varDisplay.TopRuler.Transparancy, clsVar.varDisplay.TopRuler.RulerColor.R, clsVar.varDisplay.TopRuler.RulerColor.G, clsVar.varDisplay.TopRuler.RulerColor.B));
				base.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
				base.RenderContext.DrawQuad(new RectangleF(0f, (float)((double)base.Height - clsVar.varDisplay.TopRuler.Height), base.Width, (float)clsVar.varDisplay.TopRuler.Height));
			}
			base.RenderContext.SetState(blendStateType.NoBlend);
			double Step = 0.0;
			double num = 0.0;
			double num2 = 0.0;
			int num3 = 0;
			string format = "{0:0.#}";
			new Point3D();
			double num4 = 0.0;
			double num5 = 0.0;
			if (clsVar.varDisplay.TopRuler.Enable && flag)
			{
				if (buVector5.isPlaneXYorYX(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
				{
					num4 = Math.Abs(pntUpperRight.X - pntUpperLeft.X);
					num4 /= (double)clsVar.varDisplay.TopRuler.TotalTickCount;
					buGeneral.RulerSteps(num4, ref Step);
					num = pntUpperLeft.X - pntUpperLeft.X % Step;
					num2 = pntUpperRight.X - pntUpperRight.X % Step;
				}
				if (buVector5.isPlaneYZorZY(ccVars.planeActive))
				{
					num4 = Math.Abs(pntUpperRight.Y - pntUpperLeft.Y);
					num4 /= (double)clsVar.varDisplay.TopRuler.TotalTickCount;
					buGeneral.RulerSteps(num4, ref Step);
					num = pntUpperLeft.Y - pntUpperLeft.Y % Step;
					num2 = pntUpperRight.Y - pntUpperRight.Y % Step;
				}
				if (num > num2)
				{
					double num6 = num;
					num = num2;
					num2 = num6;
				}
				for (double num7 = num; num7 <= num2; num7 += Step)
				{
					base.RenderContext.SetLineSize((float)clsVar.varDisplay.TopRuler.SmallTickThickness);
					base.RenderContext.SetColorWireframe(clsVar.varDisplay.TopRuler.SmallTickColor);
					double num8 = clsVar.varDisplay.TopRuler.SmallTickLength;
					if (num3 % clsVar.varDisplay.TopRuler.BigTickCount == 0)
					{
						num8 = clsVar.varDisplay.TopRuler.BigTickLength;
						base.RenderContext.SetLineSize((float)clsVar.varDisplay.TopRuler.BigTickThickness);
						base.RenderContext.SetColorWireframe(clsVar.varDisplay.TopRuler.BigTickColor);
					}
					if (buVector5.isPlaneXYorYX(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
					{
						base.RenderContext.DrawLine(new Point2D(WorldToScreen(num7, 0.0, 0.0).X, (double)base.Height - num8), new Point2D(WorldToScreen(num7, 0.0, 0.0).X, base.Height));
					}
					if (buVector5.isPlaneYZorZY(ccVars.planeActive))
					{
						base.RenderContext.DrawLine(new Point2D(WorldToScreen(0.0, num7, 0.0).X, (double)base.Height - num8), new Point2D(WorldToScreen(0.0, num7, 0.0).X, base.Height));
					}
					int num9 = 0;
					if (num7.ToString().Length > 3)
					{
						num9 = (num7.ToString().Length - 3) * 10;
					}
					Font textFont = new Font("Arial", 8f);
					if (buVector5.isPlaneXYorYX(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
					{
						DrawText((int)WorldToScreen(num7, 0.0, 0.0).X, base.Height - (int)clsVar.varDisplay.TopRuler.Height - num9, string.Format(format, num7), textFont, clsVar.varDisplay.TopRuler.TextColor, Color.Transparent, ContentAlignment.BottomLeft, RotateFlipType.Rotate270FlipX);
					}
					if (buVector5.isPlaneYZorZY(ccVars.planeActive))
					{
						DrawText((int)WorldToScreen(0.0, num7, 0.0).X, base.Height - (int)clsVar.varDisplay.TopRuler.Height - num9, string.Format(format, num7), textFont, clsVar.varDisplay.TopRuler.TextColor, Color.Transparent, ContentAlignment.BottomLeft, RotateFlipType.Rotate270FlipX);
					}
					num3++;
				}
				base.RenderContext.SetLineSize((float)clsVar.varDisplay.TopRuler.MoveCursorThickness);
				base.RenderContext.SetColorWireframe(clsVar.varDisplay.TopRuler.MoveCursorColor);
				if (buVector5.isPlaneXYorYX(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
				{
					base.RenderContext.DrawLine(new Point2D(WorldToScreen(ccVars.pntActive.X, 0.0, 0.0).X, (double)base.Height - clsVar.varDisplay.TopRuler.Height), new Point2D(WorldToScreen(ccVars.pntActive.X, 0.0, 0.0).X, base.Height));
				}
				if (buVector5.isPlaneYZorZY(ccVars.planeActive))
				{
					base.RenderContext.DrawLine(new Point2D(WorldToScreen(0.0, ccVars.pntActive.Y, 0.0).X, (double)base.Height - clsVar.varDisplay.TopRuler.Height), new Point2D(WorldToScreen(0.0, ccVars.pntActive.Y, 0.0).X, base.Height));
				}
			}
			if (clsVar.varDisplay.BottomRuler.Enable && flag)
			{
				if (buVector5.isPlaneXYorYX(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
				{
					num4 = Math.Abs(pntUpperRight.X - pntUpperLeft.X);
					num4 /= (double)clsVar.varDisplay.BottomRuler.TotalTickCount;
					buGeneral.RulerSteps(num4, ref Step);
					num = pntUpperLeft.X - pntUpperLeft.X % Step;
					num2 = pntUpperRight.X - pntUpperRight.X % Step;
				}
				if (buVector5.isPlaneYZorZY(ccVars.planeActive))
				{
					num4 = Math.Abs(pntUpperRight.Y - pntUpperLeft.Y);
					num4 /= (double)clsVar.varDisplay.BottomRuler.TotalTickCount;
					buGeneral.RulerSteps(num4, ref Step);
					num = pntUpperLeft.Y - pntUpperLeft.Y % Step;
					num2 = pntUpperRight.Y - pntUpperRight.Y % Step;
				}
				if (num > num2)
				{
					double num10 = num;
					num = num2;
					num2 = num10;
				}
				for (double num11 = num; num11 <= num2; num11 += Step)
				{
					base.RenderContext.SetLineSize((float)clsVar.varDisplay.BottomRuler.SmallTickThickness);
					base.RenderContext.SetColorWireframe(clsVar.varDisplay.BottomRuler.SmallTickColor);
					double num12 = clsVar.varDisplay.BottomRuler.SmallTickLength;
					if (num3 % clsVar.varDisplay.BottomRuler.BigTickCount == 0)
					{
						num12 = clsVar.varDisplay.BottomRuler.BigTickLength;
						base.RenderContext.SetLineSize((float)clsVar.varDisplay.BottomRuler.BigTickThickness);
						base.RenderContext.SetColorWireframe(clsVar.varDisplay.BottomRuler.BigTickColor);
					}
					if (buVector5.isPlaneXYorYX(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
					{
						base.RenderContext.DrawLine(new Point2D(WorldToScreen(num11, 0.0, 0.0).X, num12), new Point2D(WorldToScreen(num11, 0.0, 0.0).X, 0.0));
					}
					if (buVector5.isPlaneYZorZY(ccVars.planeActive))
					{
						base.RenderContext.DrawLine(new Point2D(WorldToScreen(0.0, num11, 0.0).X, num12), new Point2D(WorldToScreen(0.0, num11, 0.0).X, 0.0));
					}
					Font textFont2 = new Font("Arial", 8f);
					if (buVector5.isPlaneXYorYX(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
					{
						DrawText((int)WorldToScreen(num11, 0.0, 0.0).X, 0, string.Format(format, num11), textFont2, clsVar.varDisplay.BottomRuler.TextColor, Color.Transparent, ContentAlignment.BottomLeft, RotateFlipType.Rotate270FlipX);
					}
					if (buVector5.isPlaneYZorZY(ccVars.planeActive))
					{
						DrawText((int)WorldToScreen(0.0, num11, 0.0).X, 0, string.Format(format, num11), textFont2, clsVar.varDisplay.BottomRuler.TextColor, Color.Transparent, ContentAlignment.BottomLeft, RotateFlipType.Rotate270FlipX);
					}
					num3++;
				}
				base.RenderContext.SetLineSize((float)clsVar.varDisplay.BottomRuler.MoveCursorThickness);
				base.RenderContext.SetColorWireframe(clsVar.varDisplay.BottomRuler.MoveCursorColor);
				if (buVector5.isPlaneXYorYX(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
				{
					base.RenderContext.DrawLine(new Point2D(WorldToScreen(ccVars.pntActive.X, 0.0, 0.0).X, clsVar.varDisplay.BottomRuler.Height), new Point2D(WorldToScreen(ccVars.pntActive.X, 0.0, 0.0).X, 0.0));
				}
				if (buVector5.isPlaneYZorZY(ccVars.planeActive))
				{
					base.RenderContext.DrawLine(new Point2D(WorldToScreen(0.0, ccVars.pntActive.Y, 0.0).X, clsVar.varDisplay.BottomRuler.Height), new Point2D(WorldToScreen(0.0, ccVars.pntActive.Y, 0.0).X, 0.0));
				}
			}
			if (clsVar.varDisplay.LeftRuler.Enable && flag)
			{
				if (buVector5.isPlaneXYorYX(ccVars.planeActive))
				{
					num5 = Math.Abs(pntUpperRight.Y - pntLowerLeft.Y);
					num5 /= (double)clsVar.varDisplay.LeftRuler.TotalTickCount;
					buGeneral.RulerSteps(num5, ref Step);
					num = pntLowerLeft.Y - pntLowerLeft.Y % Step;
					num2 = pntUpperRight.Y - pntUpperRight.Y % Step;
				}
				if (buVector5.isPlaneYZorZY(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
				{
					num5 = Math.Abs(pntUpperRight.Z - pntLowerLeft.Z);
					num5 /= (double)clsVar.varDisplay.LeftRuler.TotalTickCount;
					buGeneral.RulerSteps(num5, ref Step);
					num = pntLowerLeft.Z - pntLowerLeft.Z % Step;
					num2 = pntUpperRight.Z - pntUpperRight.Z % Step;
				}
				if (num > num2)
				{
					double num13 = num;
					num = num2;
					num2 = num13;
				}
				for (double num14 = num; num14 <= num2; num14 += Step)
				{
					base.RenderContext.SetLineSize((float)clsVar.varDisplay.LeftRuler.SmallTickThickness);
					base.RenderContext.SetColorWireframe(clsVar.varDisplay.LeftRuler.SmallTickColor);
					double num15 = clsVar.varDisplay.LeftRuler.SmallTickLength;
					if (num3 % clsVar.varDisplay.LeftRuler.BigTickCount == 0)
					{
						num15 = clsVar.varDisplay.LeftRuler.BigTickLength;
						base.RenderContext.SetLineSize((float)clsVar.varDisplay.LeftRuler.BigTickThickness);
						base.RenderContext.SetColorWireframe(clsVar.varDisplay.LeftRuler.BigTickColor);
					}
					if (buVector5.isPlaneXYorYX(ccVars.planeActive))
					{
						base.RenderContext.DrawLine(new Point2D(num15, WorldToScreen(0.0, num14, 0.0).Y), new Point2D(0.0, WorldToScreen(0.0, num14, 0.0).Y));
					}
					if (buVector5.isPlaneYZorZY(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
					{
						base.RenderContext.DrawLine(new Point2D(num15, WorldToScreen(0.0, 0.0, num14).Y), new Point2D(0.0, WorldToScreen(0.0, 0.0, num14).Y));
					}
					Font textFont3 = new Font("Arial", 8f);
					if (buVector5.isPlaneXYorYX(ccVars.planeActive))
					{
						DrawText(0, (int)WorldToScreen(0.0, num14, 0.0).Y, string.Format(format, num14), textFont3, clsVar.varDisplay.LeftRuler.TextColor, Color.Transparent, ContentAlignment.BottomLeft);
					}
					if (buVector5.isPlaneYZorZY(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
					{
						DrawText(0, (int)WorldToScreen(0.0, 0.0, num14).Y, string.Format(format, num14), textFont3, clsVar.varDisplay.LeftRuler.TextColor, Color.Transparent, ContentAlignment.BottomLeft);
					}
					num3++;
				}
				base.RenderContext.SetLineSize((float)clsVar.varDisplay.LeftRuler.MoveCursorThickness);
				base.RenderContext.SetColorWireframe(clsVar.varDisplay.LeftRuler.MoveCursorColor);
				if (buVector5.isPlaneXYorYX(ccVars.planeActive))
				{
					base.RenderContext.DrawLine(new Point2D(0.0, WorldToScreen(0.0, ccVars.pntActive.Y, 0.0).Y), new Point2D(clsVar.varDisplay.LeftRuler.Width, WorldToScreen(0.0, ccVars.pntActive.Y, 0.0).Y));
				}
				if (buVector5.isPlaneYZorZY(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
				{
					base.RenderContext.DrawLine(new Point2D(0.0, WorldToScreen(0.0, 0.0, ccVars.pntActive.Z).Y), new Point2D(clsVar.varDisplay.LeftRuler.Width, WorldToScreen(0.0, 0.0, ccVars.pntActive.Z).Y));
				}
			}
			if (!(clsVar.varDisplay.RightRuler.Enable && flag))
			{
				return;
			}
			if (buVector5.isPlaneXYorYX(ccVars.planeActive))
			{
				num5 = Math.Abs(pntUpperRight.Y - pntLowerLeft.Y);
				num5 /= (double)clsVar.varDisplay.RightRuler.TotalTickCount;
				buGeneral.RulerSteps(num5, ref Step);
				num = pntLowerLeft.Y - pntLowerLeft.Y % Step;
				num2 = pntUpperRight.Y - pntUpperRight.Y % Step;
			}
			if (buVector5.isPlaneYZorZY(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
			{
				num5 = Math.Abs(pntUpperRight.Z - pntLowerLeft.Z);
				num5 /= (double)clsVar.varDisplay.RightRuler.TotalTickCount;
				buGeneral.RulerSteps(num5, ref Step);
				num = pntLowerLeft.Z - pntLowerLeft.Z % Step;
				num2 = pntUpperRight.Z - pntUpperRight.Z % Step;
			}
			if (num > num2)
			{
				double num16 = num;
				num = num2;
				num2 = num16;
			}
			for (double num17 = num; num17 <= num2; num17 += Step)
			{
				base.RenderContext.SetLineSize((float)clsVar.varDisplay.RightRuler.SmallTickThickness);
				base.RenderContext.SetColorWireframe(clsVar.varDisplay.RightRuler.SmallTickColor);
				double num18 = clsVar.varDisplay.RightRuler.SmallTickLength;
				if (num3 % clsVar.varDisplay.RightRuler.BigTickCount == 0)
				{
					num18 = clsVar.varDisplay.RightRuler.BigTickLength;
					base.RenderContext.SetLineSize((float)clsVar.varDisplay.RightRuler.BigTickThickness);
					base.RenderContext.SetColorWireframe(clsVar.varDisplay.RightRuler.BigTickColor);
				}
				if (buVector5.isPlaneXYorYX(ccVars.planeActive))
				{
					base.RenderContext.DrawLine(new Point2D((double)base.Width - num18, WorldToScreen(0.0, num17, 0.0).Y), new Point2D(base.Width, WorldToScreen(0.0, num17, 0.0).Y));
				}
				if (buVector5.isPlaneYZorZY(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
				{
					base.RenderContext.DrawLine(new Point2D((double)base.Width - num18, WorldToScreen(0.0, 0.0, num17).Y), new Point2D(base.Width, WorldToScreen(0.0, 0.0, num17).Y));
				}
				int num19 = 0;
				if (num17.ToString().Length > 3)
				{
					num19 = (num17.ToString().Length - 3) * 10;
				}
				Font textFont4 = new Font("Arial", 8f);
				if (buVector5.isPlaneXYorYX(ccVars.planeActive))
				{
					DrawText(base.Width - (int)clsVar.varDisplay.RightRuler.Width - num19, (int)WorldToScreen(0.0, num17, 0.0).Y, string.Format(format, num17), textFont4, clsVar.varDisplay.RightRuler.TextColor, Color.Transparent, ContentAlignment.BottomLeft);
				}
				if (buVector5.isPlaneYZorZY(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
				{
					DrawText(base.Width - (int)clsVar.varDisplay.RightRuler.Width - num19, (int)WorldToScreen(0.0, 0.0, num17).Y, string.Format(format, num17), textFont4, clsVar.varDisplay.RightRuler.TextColor, Color.Transparent, ContentAlignment.BottomLeft);
				}
				num3++;
			}
			base.RenderContext.SetLineSize((float)clsVar.varDisplay.RightRuler.MoveCursorThickness);
			base.RenderContext.SetColorWireframe(clsVar.varDisplay.RightRuler.MoveCursorColor);
			if (buVector5.isPlaneXYorYX(ccVars.planeActive))
			{
				base.RenderContext.DrawLine(new Point2D(base.Width, WorldToScreen(0.0, ccVars.pntActive.Y, 0.0).Y), new Point2D((double)base.Width - clsVar.varDisplay.RightRuler.Width, WorldToScreen(0.0, ccVars.pntActive.Y, 0.0).Y));
			}
			if (buVector5.isPlaneYZorZY(ccVars.planeActive) | buVector5.isPlaneXZorZX(ccVars.planeActive))
			{
				base.RenderContext.DrawLine(new Point2D(base.Width, WorldToScreen(0.0, 0.0, ccVars.pntActive.Z).Y), new Point2D((double)base.Width - clsVar.varDisplay.RightRuler.Width, WorldToScreen(0.0, 0.0, ccVars.pntActive.Z).Y));
			}
		}
		catch (Exception)
		{
		}
	}

	private void method_1()
	{
		try
		{
			if (!ccVars.OsnapCatchPoint.Found)
			{
				if (ccVars.OsnapCatchPoint.OrthoFound)
				{
					Point2D point2D = WorldToScreen(ccVars.OsnapCatchPoint.Point);
					method_12(new System.Drawing.Point((int)point2D.X, (int)point2D.Y), clsVar.varDisplay.OsnapSize, clsVar.varDisplay.displayOsnap.Color, clsVar.varDisplay.displayOsnap.Thickness);
				}
				if (ccVars.OsnapCatchPoint.OverFound)
				{
					Point2D point2D2 = WorldToScreen(ccVars.OsnapCatchPoint.EntityPoint);
					method_9(new System.Drawing.Point((int)point2D2.X, (int)point2D2.Y), clsVar.varDisplay.OsnapSize, clsVar.varDisplay.displayOsnap.Color, clsVar.varDisplay.displayOsnap.Thickness);
				}
			}
			if (!ccVars.OsnapCatchPoint.Found)
			{
				return;
			}
			Point2D point2D3 = WorldToScreen(ccVars.OsnapCatchPoint.Point);
			if (ccVars.OsnapCatchPoint.Type == osnapType.ControlPoint)
			{
				method_5(new System.Drawing.Point((int)point2D3.X, (int)point2D3.Y), clsVar.varDisplay.OsnapSize, clsVar.varDisplay.displayOsnap.Color, clsVar.varDisplay.displayOsnap.Thickness);
			}
			if (ccVars.OsnapCatchPoint.Type == osnapType.Point)
			{
				method_5(new System.Drawing.Point((int)point2D3.X, (int)point2D3.Y), clsVar.varDisplay.OsnapSize, clsVar.varDisplay.displayOsnap.Color, clsVar.varDisplay.displayOsnap.Thickness);
				if (ccVars.OsnapCatchPoint.Point == new Point3D())
				{
					double double_ = 24.0;
					method_5(new System.Drawing.Point((int)point2D3.X, (int)point2D3.Y), double_, clsVar.varDisplay.displayOsnap.Color, clsVar.varDisplay.displayOsnap.Thickness);
				}
			}
			if (ccVars.OsnapCatchPoint.Type == osnapType.Middle)
			{
				method_6(new System.Drawing.Point((int)point2D3.X, (int)point2D3.Y), clsVar.varDisplay.OsnapSize, clsVar.varDisplay.displayOsnap.Color, clsVar.varDisplay.displayOsnap.Thickness);
			}
			if (ccVars.OsnapCatchPoint.Type == osnapType.Center)
			{
				method_10(new System.Drawing.Point((int)point2D3.X, (int)point2D3.Y), clsVar.varDisplay.OsnapSize, clsVar.varDisplay.displayOsnap.Color, clsVar.varDisplay.displayOsnap.Thickness);
			}
			if (ccVars.OsnapCatchPoint.Type == osnapType.Outer)
			{
				method_14(new System.Drawing.Point((int)point2D3.X, (int)point2D3.Y), clsVar.varDisplay.OsnapSize, clsVar.varDisplay.displayOsnap.Color, clsVar.varDisplay.displayOsnap.Thickness);
			}
			if (ccVars.OsnapCatchPoint.Type == osnapType.Intersection)
			{
				method_8(new System.Drawing.Point((int)point2D3.X, (int)point2D3.Y), clsVar.varDisplay.OsnapSize, clsVar.varDisplay.displayOsnap.Color, clsVar.varDisplay.displayOsnap.Thickness);
			}
			if (ccVars.OsnapCatchPoint.Type == osnapType.Over)
			{
				method_8(new System.Drawing.Point((int)point2D3.X, (int)point2D3.Y), clsVar.varDisplay.OsnapSize, clsVar.varDisplay.displayOsnap.Color, clsVar.varDisplay.displayOsnap.Thickness);
			}
			if (ccVars.OsnapCatchPoint.Type == osnapType.Alingment)
			{
				method_11(new System.Drawing.Point((int)point2D3.X, (int)point2D3.Y), clsVar.varDisplay.OsnapSize, clsVar.varDisplay.displayOsnap.Color, clsVar.varDisplay.displayOsnap.Thickness);
				method_13(ccVars.OsnapCatchPoint.CatchBasePoints);
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	private void method_2()
	{
		try
		{
			List<Point3D> list = new List<Point3D>();
			base.RenderContext.SetPointSize(clsVar.varView.displayOsnapPoints.Thickness);
			base.RenderContext.SetColorWireframe(clsVar.varView.displayOsnapPoints.Color);
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].OsnapPoints.Count - 1; i++)
			{
				if (!ccVars.Pages[ccVars.PageIndex].OsnapPoints[i].Enable)
				{
					continue;
				}
				if (!((ccVars.Pages[ccVars.PageIndex].OsnapPoints[i].Type == osnapType.Point) & clsVar.varMouse.Osnap.OsnapPoint))
				{
					if (!((ccVars.Pages[ccVars.PageIndex].OsnapPoints[i].Type == osnapType.Middle) & clsVar.varMouse.Osnap.OsnapMiddle))
					{
						if (!((ccVars.Pages[ccVars.PageIndex].OsnapPoints[i].Type == osnapType.Center) & clsVar.varMouse.Osnap.OsnapCenter))
						{
							if (!((ccVars.Pages[ccVars.PageIndex].OsnapPoints[i].Type == osnapType.Outer) & clsVar.varMouse.Osnap.OsnapOutside))
							{
								if (!((ccVars.Pages[ccVars.PageIndex].OsnapPoints[i].Type == osnapType.Intersection) & clsVar.varMouse.Osnap.OsnapIntersection))
								{
									if ((ccVars.Pages[ccVars.PageIndex].OsnapPoints[i].Type == osnapType.ControlPoint) & clsVar.varMouse.Osnap.OsnapControlPoints)
									{
										Point3D point3D = new Point3D();
										point3D = buVector5.ToPoint3D(ccVars.Pages[ccVars.PageIndex].OsnapPoints[i]);
										list.Add(point3D);
									}
								}
								else
								{
									Point3D point3D2 = new Point3D();
									point3D2 = buVector5.ToPoint3D(ccVars.Pages[ccVars.PageIndex].OsnapPoints[i]);
									list.Add(point3D2);
								}
							}
							else
							{
								Point3D point3D3 = new Point3D();
								point3D3 = buVector5.ToPoint3D(ccVars.Pages[ccVars.PageIndex].OsnapPoints[i]);
								list.Add(point3D3);
							}
						}
						else
						{
							Point3D point3D4 = new Point3D();
							point3D4 = buVector5.ToPoint3D(ccVars.Pages[ccVars.PageIndex].OsnapPoints[i]);
							list.Add(point3D4);
						}
					}
					else
					{
						Point3D point3D5 = new Point3D();
						point3D5 = buVector5.ToPoint3D(ccVars.Pages[ccVars.PageIndex].OsnapPoints[i]);
						list.Add(point3D5);
					}
				}
				else
				{
					Point3D point3D6 = new Point3D();
					point3D6 = buVector5.ToPoint3D(ccVars.Pages[ccVars.PageIndex].OsnapPoints[i]);
					list.Add(point3D6);
				}
			}
			if (list != null)
			{
				base.RenderContext.DrawPoints(WorldToScreen(list));
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	private void method_3()
	{
		try
		{
			List<Point3D> list = new List<Point3D>();
			base.RenderContext.SetPointSize(clsVar.varView.displayEntityPoints.Thickness);
			base.RenderContext.SetColorWireframe(clsVar.varView.displayEntityPoints.Color);
			for (int i = 0; i <= base.Entities.Count - 1; i++)
			{
				if (!((base.Entities[i] is ICurve) & base.Entities[i].Visible))
				{
					continue;
				}
				for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; j++)
				{
					if (!(ccVars.Pages[ccVars.PageIndex].Layers[j].Name == base.Entities[i].LayerName) || !ccVars.Pages[ccVars.PageIndex].Layers[j].Enable)
					{
						continue;
					}
					if (!(base.Entities[i].GetType() == typeof(LinearPath)))
					{
						Point3D point3D = new Point3D();
						point3D = buVector5.ToPoint3D(((ICurve)base.Entities[i]).StartPoint);
						list.Add(point3D);
						point3D = new Point3D();
						point3D = buVector5.ToPoint3D(((ICurve)base.Entities[i]).EndPoint);
						list.Add(point3D);
						if (base.Entities[i] is CompositeCurve)
						{
							for (int k = 0; k <= ((CompositeCurve)base.Entities[i]).CurveList.Count - 1; k++)
							{
								point3D = buVector5.ToPoint3D(((CompositeCurve)base.Entities[i]).CurveList[k].StartPoint);
								list.Add(point3D);
								point3D = new Point3D();
								point3D = buVector5.ToPoint3D(((CompositeCurve)base.Entities[i]).CurveList[k].EndPoint);
								list.Add(point3D);
							}
						}
					}
					else
					{
						for (int l = 0; l <= base.Entities[i].Vertices.Length - 1; l++)
						{
							Point3D point3D2 = new Point3D();
							point3D2 = buVector5.ToPoint3D(base.Entities[i].Vertices[l]);
							list.Add(point3D2);
						}
					}
					j = ccVars.Pages[ccVars.PageIndex].Layers.Count;
				}
			}
			if (list != null)
			{
				base.RenderContext.DrawPoints(WorldToScreen(list));
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	public bool FindClosestPointForOsnap(List<OsnapPoint> snapPoints, ref OsnapPoint foundPoint)
	{
		try
		{
			double num = double.MaxValue;
			int num2 = 0;
			int num3 = -1;
			foundPoint.Type = osnapType.None;
			if (clsVar.varMouse.Osnap.OsnapEntities)
			{
				foreach (Entity entity in base.Entities)
				{
					if (!(entity is ICurve))
					{
						if (!(entity is Brep) || !clsVar.varMouse.Osnap.OsnapBrep)
						{
							continue;
						}
						Brep brep = entity as Brep;
						int num4 = 0;
						while (num4 <= brep.Edges.Length - 1)
						{
							Entity copiedEntity = null;
							buEntity.Copy((Entity)brep.Edges[num4].Curve, ref copiedEntity);
							clsInit.cVector5.EntityICurveOsnapPoints(copiedEntity, this, clsVar.varDisplay.OsnapSize, clsVar.varMouse.Osnap.OsnapOnlyStartEndPoint, mouseLocation, ref foundPoint);
							if (foundPoint.Type == osnapType.None)
							{
								num4++;
								continue;
							}
							goto IL_022a;
						}
					}
					else if (base.Layers[entity.LayerName].Visible)
					{
						clsInit.cVector5.EntityICurveOsnapPoints(entity, this, clsVar.varDisplay.OsnapSize, clsVar.varMouse.Osnap.OsnapOnlyStartEndPoint, mouseLocation, ref foundPoint);
						if (foundPoint.Type != osnapType.None)
						{
							return true;
						}
					}
				}
			}
			foreach (OsnapPoint snapPoint in snapPoints)
			{
				if (snapPoint != null)
				{
					Point3D a = WorldToScreen(snapPoint);
					Point2D b = new Point2D(mouseLocation.X, base.Height - mouseLocation.Y);
					double num5 = Point2D.Distance(a, b);
					if ((num5 < num) & (num5 <= clsVar.varDisplay.OsnapSize))
					{
						num3 = num2;
						num = num5;
					}
					num2++;
				}
			}
			if (!((num3 >= 0) & (num3 <= snapPoints.Count - 1)))
			{
				return false;
			}
			foundPoint = snapPoints[num3];
			return true;
			IL_022a:
			if (foundPoint.Type == osnapType.None)
			{
				return false;
			}
			return true;
		}
		catch (Exception)
		{
			throw;
		}
	}

	private void method_4(System.Drawing.Point point_1, System.Drawing.Point point_2, Color color_0, int int_0, bool bool_0, bool bool_1)
	{
		point_1.Y = base.Height - point_1.Y;
		point_2.Y = base.Height - point_2.Y;
		Class5.smethod_9(ref point_2, ref point_1);
		int[] viewFrame = base.Viewports[0].GetViewFrame();
		int num = viewFrame[0];
		int num2 = viewFrame[1] + viewFrame[3];
		int num3 = num + viewFrame[2];
		int num4 = viewFrame[1];
		if (point_2.X > num3 - 1)
		{
			point_2.X = num3 - 1;
		}
		if (point_2.Y > num2 - 1)
		{
			point_2.Y = num2 - 1;
		}
		if (point_1.X < num + 1)
		{
			point_1.X = num + 1;
		}
		if (point_1.Y < num4 + 1)
		{
			point_1.Y = num4 + 1;
		}
		base.RenderContext.SetState(blendStateType.Blend);
		base.RenderContext.SetColorWireframe(Color.FromArgb(int_0, color_0.R, color_0.G, color_0.B));
		base.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_NoPolygonOffset);
		int num5 = point_2.X - point_1.X;
		int num6 = point_2.Y - point_1.Y;
		base.RenderContext.DrawQuad(new RectangleF(point_1.X + 1, point_1.Y + 1, num5 - 1, num6 - 1));
		base.RenderContext.SetState(blendStateType.NoBlend);
		if (bool_0)
		{
			base.RenderContext.SetColorWireframe(Color.FromArgb(255, color_0.R, color_0.G, color_0.B));
			List<Point3D> list = null;
			if (bool_1)
			{
				base.RenderContext.SetLineStipple(1, 3855, base.Viewports[0].Camera);
				base.RenderContext.EnableLineStipple(enable: true);
			}
			int num7 = point_1.X;
			int num8 = point_2.X;
			if (base.RenderContext.IsDirect3D)
			{
				num7++;
				num8++;
			}
			list = new List<Point3D>(new Point3D[8]
			{
				new Point3D(num7, point_1.Y),
				new Point3D(point_2.X, point_1.Y),
				new Point3D(num8, point_1.Y),
				new Point3D(num8, point_2.Y),
				new Point3D(num8, point_2.Y),
				new Point3D(num7, point_2.Y),
				new Point3D(num7, point_2.Y),
				new Point3D(num7, point_1.Y)
			});
			base.RenderContext.DrawLines(list.ToArray());
			if (bool_1)
			{
				base.RenderContext.EnableLineStipple(enable: false);
			}
		}
	}

	private void method_5(System.Drawing.Point point_1, double double_0, Color color_0, float float_0)
	{
		try
		{
			double num = (double)point_1.X + double_0 / 2.0;
			double num2 = (double)point_1.Y + double_0 / 2.0;
			double num3 = (double)point_1.X - double_0 / 2.0;
			double num4 = (double)point_1.Y - double_0 / 2.0;
			Point3D point3D = new Point3D(num3, num2);
			Point3D point3D2 = new Point3D(num, num2);
			Point3D point3D3 = new Point3D(num, num4);
			Point3D point3D4 = new Point3D(num3, num4);
			base.RenderContext.SetLineSize(float_0);
			base.RenderContext.SetColorWireframe(color_0);
			base.RenderContext.DrawLineLoop(new Point3D[4] { point3D4, point3D3, point3D2, point3D });
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	private void method_6(System.Drawing.Point point_1, double double_0, Color color_0, float float_0)
	{
		try
		{
			double num = (double)point_1.X + double_0 / 2.0;
			double num2 = (double)point_1.Y + double_0 / 2.0;
			double num3 = (double)point_1.X - double_0 / 2.0;
			double num4 = (double)point_1.Y - double_0 / 2.0;
			double num5 = point_1.X;
			Point3D point3D = new Point3D(num5, num2);
			Point3D point3D2 = new Point3D(num, num4);
			Point3D point3D3 = new Point3D(num3, num4);
			base.RenderContext.SetLineSize(float_0);
			base.RenderContext.SetColorWireframe(color_0);
			base.RenderContext.DrawLineLoop(new Point3D[3] { point3D3, point3D2, point3D });
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	private void method_7(Point3D point3D_0, double double_0, Color color_0, float float_0)
	{
		try
		{
			double num = WorldToScreen(point3D_0.X, point3D_0.Y, point3D_0.Z).X + double_0 / 2.0;
			double num2 = WorldToScreen(point3D_0.X, point3D_0.Y, point3D_0.Z).Y + double_0 / 2.0;
			double num3 = WorldToScreen(point3D_0.X, point3D_0.Y, point3D_0.Z).X - double_0 / 2.0;
			double num4 = WorldToScreen(point3D_0.X, point3D_0.Y, point3D_0.Z).Y - double_0 / 2.0;
			Point3D point3D = new Point3D(num3, num2);
			Point3D point3D2 = new Point3D(num, num2);
			Point3D point3D3 = new Point3D(num, num4);
			Point3D point3D4 = new Point3D(num3, num4);
			base.RenderContext.SetLineSize(float_0);
			base.RenderContext.SetColorWireframe(color_0);
			base.RenderContext.DrawLines(new Point3D[4] { point3D4, point3D2, point3D, point3D3 });
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	private void method_8(System.Drawing.Point point_1, double double_0, Color color_0, float float_0)
	{
		try
		{
			double num = (double)point_1.X + double_0 / 2.0;
			double num2 = (double)point_1.Y + double_0 / 2.0;
			double num3 = (double)point_1.X - double_0 / 2.0;
			double num4 = (double)point_1.Y - double_0 / 2.0;
			Point3D point3D = new Point3D(num3, num2);
			Point3D point3D2 = new Point3D(num, num2);
			Point3D point3D3 = new Point3D(num, num4);
			Point3D point3D4 = new Point3D(num3, num4);
			base.RenderContext.SetLineSize(float_0);
			base.RenderContext.SetColorWireframe(color_0);
			base.RenderContext.DrawLines(new Point3D[4] { point3D4, point3D2, point3D, point3D3 });
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	private void method_9(System.Drawing.Point point_1, double double_0, Color color_0, float float_0)
	{
		try
		{
			double num = (double)point_1.X + double_0 / 2.0;
			double num2 = (double)point_1.Y + double_0 / 2.0;
			double num3 = (double)point_1.X - double_0 / 2.0;
			double num4 = (double)point_1.Y - double_0 / 2.0;
			Point3D point3D = new Point3D(num3, point_1.Y);
			Point3D point3D2 = new Point3D(num, point_1.Y);
			Point3D point3D3 = new Point3D(point_1.X, num2);
			Point3D point3D4 = new Point3D(point_1.X, num4);
			base.RenderContext.SetLineSize(float_0);
			base.RenderContext.SetColorWireframe(color_0);
			base.RenderContext.DrawLines(new Point3D[4] { point3D, point3D2, point3D3, point3D4 });
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	private void method_10(System.Drawing.Point point_1, double double_0, Color color_0, float float_0)
	{
		try
		{
			double num = double_0 / 2.0;
			double num2 = 0.0;
			double num3 = 0.0;
			List<Point3D> list = new List<Point3D>();
			for (int i = 0; i < 360; i += 10)
			{
				double num4 = Utility.DegToRad(i);
				num2 = (double)point_1.X + num * Math.Cos(num4);
				num3 = (double)point_1.Y + num * Math.Sin(num4);
				Point3D item = new Point3D(num2, num3);
				list.Add(item);
			}
			base.RenderContext.SetState(blendStateType.Blend);
			base.RenderContext.SetLineSize(float_0);
			base.RenderContext.SetColorWireframe(color_0);
			base.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_NoPolygonOffset);
			base.RenderContext.DrawLineLoop(list.ToArray());
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	private void method_11(System.Drawing.Point point_1, double double_0, Color color_0, float float_0)
	{
		try
		{
			double num = (double)point_1.X + double_0 * 1.0;
			double num2 = (double)point_1.Y + double_0 * 1.0;
			Point3D point3D = new Point3D(point_1.X, num2);
			Point3D point3D2 = new Point3D(num, point_1.Y);
			Point3D point3D3 = new Point3D(point_1.X, point_1.Y);
			base.RenderContext.SetLineSize(float_0);
			base.RenderContext.SetColorWireframe(color_0);
			base.RenderContext.DrawLines(new Point3D[4] { point3D, point3D3, point3D3, point3D2 });
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	private void method_12(System.Drawing.Point point_1, double double_0, Color color_0, float float_0)
	{
		try
		{
			double num = (double)point_1.X - double_0 * 0.5;
			double num2 = (double)point_1.Y + double_0 * 1.0;
			double num3 = (double)point_1.X + double_0 * 0.5;
			Point3D point3D = new Point3D(num3, point_1.Y);
			Point3D point3D2 = new Point3D(num, point_1.Y);
			Point3D point3D3 = new Point3D(point_1.X, point_1.Y);
			Point3D point3D4 = new Point3D(point_1.X, num2);
			base.RenderContext.SetLineSize(float_0);
			base.RenderContext.SetColorWireframe(color_0);
			base.RenderContext.DrawLines(new Point3D[4] { point3D, point3D2, point3D3, point3D4 });
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	private void method_13(List<Point3D> list_0)
	{
		try
		{
			if (list_0.Count > 0)
			{
				base.RenderContext.SetLineSize(clsVar.varDisplay.displayHighLight.Thickness + 2f);
				base.RenderContext.SetColorWireframe(clsVar.varDisplay.displayHighLight.Color);
				base.RenderContext.DrawLines(WorldToScreen(list_0));
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	private void method_14(System.Drawing.Point point_1, double double_0, Color color_0, float float_0)
	{
		try
		{
			double num = (double)point_1.X + double_0 / 1.5;
			double num2 = (double)point_1.Y + double_0 / 1.5;
			double num3 = (double)point_1.X - double_0 / 1.5;
			double num4 = (double)point_1.Y - double_0 / 1.5;
			Point3D point3D = new Point3D(point_1.X, num2);
			Point3D point3D2 = new Point3D(point_1.X, num4);
			Point3D point3D3 = new Point3D(num, point_1.Y);
			Point3D point3D4 = new Point3D(num3, point_1.Y);
			base.RenderContext.SetLineSize(float_0);
			base.RenderContext.SetColorWireframe(color_0);
			base.RenderContext.DrawLineLoop(new Point3D[4] { point3D2, point3D3, point3D, point3D4 });
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	private void method_15(Point3D point3D_0, Point3D point3D_1, double double_0, double double_1, double double_2)
	{
		new geoTriangle();
		new geoTriangle();
		new List<Pnt3D>();
		new List<Pnt3D>();
		List<Point3D> calcPoints = new List<Point3D>();
		clsInit.cVector5.DrawWireArrowHead(point3D_1, point3D_0, double_0, double_2, Reverse: true, ccVars.planeActive, ref calcPoints);
		base.RenderContext.SetState(blendStateType.Blend);
		base.RenderContext.SetLineSize(2f);
		base.RenderContext.SetColorWireframe(Color.Red);
		base.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_NoPolygonOffset);
		Point3D[] array = new Point3D[calcPoints.Count];
		for (int i = 0; i <= calcPoints.Count - 1; i++)
		{
			array[i] = new Point3D();
			array[i] = WorldToScreen(calcPoints[i].X, calcPoints[i].Y, calcPoints[i].Z);
		}
		base.RenderContext.DrawLineStrip(array);
		base.RenderContext.SetState(blendStateType.NoBlend);
	}

	private void method_16(Point3D point3D_0, Point3D point3D_1, double double_0, Color color_0, float float_0)
	{
		base.RenderContext.SetState(blendStateType.Blend);
		base.RenderContext.SetLineSize(float_0);
		base.RenderContext.SetColorWireframe(color_0);
		base.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_NoPolygonOffset);
		if (ccVars.pntDrawDynamicArr != null && ccVars.pntDrawDynamicArr.Length != 0)
		{
			for (int i = 1; i <= ccVars.pntDrawDynamicArr.Length - 1; i++)
			{
				Point3D firstPoint = buVector5.ToPoint3D(ccVars.pntDrawDynamicArr[i - 1]);
				Point3D secondPoints = buVector5.ToPoint3D(ccVars.pntDrawDynamicArr[i]);
				List<Point3D> calcPoints = new List<Point3D>();
				clsInit.cVector5.DrawLineAsRectangle(firstPoint, secondPoints, double_0, ccVars.planeActive, ref calcPoints);
				Point3D[] vertices = new Point3D[5]
				{
					WorldToScreen(calcPoints[0].X, calcPoints[0].Y, calcPoints[0].Z),
					WorldToScreen(calcPoints[1].X, calcPoints[1].Y, calcPoints[1].Z),
					WorldToScreen(calcPoints[2].X, calcPoints[2].Y, calcPoints[2].Z),
					WorldToScreen(calcPoints[3].X, calcPoints[3].Y, calcPoints[3].Z),
					WorldToScreen(calcPoints[4].X, calcPoints[4].Y, calcPoints[4].Z)
				};
				Point3D[] array = new Point3D[3];
				Point3D[] array2 = new Point3D[3];
				array[0] = WorldToScreen(calcPoints[0].X, calcPoints[0].Y, calcPoints[0].Z);
				array[1] = WorldToScreen(calcPoints[1].X, calcPoints[1].Y, calcPoints[1].Z);
				array[2] = WorldToScreen(calcPoints[2].X, calcPoints[2].Y, calcPoints[2].Z);
				array2[0] = WorldToScreen(calcPoints[2].X, calcPoints[2].Y, calcPoints[2].Z);
				array2[1] = WorldToScreen(calcPoints[3].X, calcPoints[3].Y, calcPoints[3].Z);
				array2[2] = WorldToScreen(calcPoints[0].X, calcPoints[0].Y, calcPoints[0].Z);
				base.RenderContext.DrawTriangles(array, new Vector3D(0.0, 0.0, 1.0));
				base.RenderContext.DrawTriangles(array2, new Vector3D(0.0, 0.0, 1.0));
				base.RenderContext.DrawLineStrip(vertices);
			}
		}
		base.RenderContext.SetState(blendStateType.NoBlend);
	}

	public void DrawPointer()
	{
		Point2D point2D = WorldToScreen(ccVars.pntActive);
		method_9(new System.Drawing.Point((int)point2D.X, (int)point2D.Y), clsVar.varDisplay.PointerSize, clsVar.varDisplay.displayPointer.Color, clsVar.varDisplay.displayPointer.Thickness);
	}

	private void method_17()
	{
		if (ccVars.pntMark.Count > 0)
		{
			for (int i = 0; i <= ccVars.pntMark.Count - 1; i++)
			{
				Point2D point2D = WorldToScreen(ccVars.pntMark[i]);
				Color color_ = Color.FromArgb(ccVars.pntMark[i].R, ccVars.pntMark[i].G, ccVars.pntMark[i].B);
				method_5(new System.Drawing.Point((int)point2D.X, (int)point2D.Y), 8.0, color_, (float)clsVar.varView.DrawMarkThickness);
			}
		}
	}

	private void method_18()
	{
		if (buVector5.AskMe.FoundEntities.Count > 0)
		{
			base.RenderContext.SetLineSize(clsVar.varDisplay.displayAskMeEntities.Thickness);
			base.RenderContext.SetColorWireframe(clsVar.varDisplay.displayAskMeEntities.Color);
			for (int i = 0; i <= buVector5.AskMe.FoundEntities.Count - 1; i++)
			{
				if (buVector5.AskMe.FoundEntities[i].Vertices != null)
				{
					base.RenderContext.DrawLines(WorldToScreen(buVector5.AskMe.FoundEntities[i].Vertices));
				}
			}
			if ((buVector5.AskMe.SelectedIndex >= 0) & (buVector5.AskMe.SelectedIndex <= buVector5.AskMe.FoundEntities.Count - 1))
			{
				base.RenderContext.SetLineSize(clsVar.varDisplay.displayAskMeEntitiesSelected.Thickness);
				base.RenderContext.SetColorWireframe(clsVar.varDisplay.displayAskMeEntitiesSelected.Color);
				if (buVector5.AskMe.FoundEntities[buVector5.AskMe.SelectedIndex].Vertices != null)
				{
					base.RenderContext.DrawLines(WorldToScreen(buVector5.AskMe.FoundEntities[buVector5.AskMe.SelectedIndex].Vertices));
					if (buVector5.AskMe.FoundEntities[buVector5.AskMe.SelectedIndex] is ICurve)
					{
						Point3D OtherPoint = new Point3D();
						clsInit.cVector5.GetOtherPointOfEntity(buVector5.AskMe.CatchPoint, buVector5.AskMe.FoundEntities[buVector5.AskMe.SelectedIndex], ref OtherPoint);
						_ = buVector5.AskMe.FoundEntities[buVector5.AskMe.SelectedIndex] is ICurve;
						method_15(buVector5.AskMe.CatchPoint, OtherPoint, 20.0, 10.0, 15.0);
					}
				}
			}
		}
		if (ccVars.SortedEntities.Count > 0)
		{
			base.RenderContext.SetLineSize(clsVar.varDisplay.displaySortedEntities.Thickness);
			base.RenderContext.SetColorWireframe(clsVar.varDisplay.displaySortedEntities.Color);
			for (int j = 0; j <= ccVars.SortedEntities.Count - 1; j++)
			{
				if (!(ccVars.SortedEntities[j].GetType() == typeof(buUpperLineEnt)))
				{
					base.RenderContext.SetLineSize(clsVar.varDisplay.displaySortedEntities.Thickness);
					base.RenderContext.SetColorWireframe(clsVar.varDisplay.displaySortedEntities.Color);
				}
				else
				{
					base.RenderContext.SetLineSize(clsVar.varDisplay.displaySortedUpperEntities.Thickness);
					base.RenderContext.SetColorWireframe(clsVar.varDisplay.displaySortedUpperEntities.Color);
				}
				if (ccVars.SortedEntities[j].Vertices != null)
				{
					base.RenderContext.DrawLines(WorldToScreen(ccVars.SortedEntities[j].Vertices));
				}
			}
		}
		if (buVector5.AskMe.SortedEntities.Count > 0)
		{
			base.RenderContext.SetLineSize(clsVar.varDisplay.displaySortedEntities.Thickness);
			base.RenderContext.SetColorWireframe(clsVar.varDisplay.displaySortedEntities.Color);
			for (int k = 0; k <= buVector5.AskMe.SortedEntities.Count - 1; k++)
			{
				if (buVector5.AskMe.SortedEntities[k].Vertices != null)
				{
					base.RenderContext.DrawLines(WorldToScreen(buVector5.AskMe.SortedEntities[k].Vertices));
				}
			}
		}
		if (buVector5.AskMe.LastMarkPosition.Count > 0)
		{
			for (int l = buVector5.AskMe.LastMarkPosition.Count - 1; l <= buVector5.AskMe.LastMarkPosition.Count - 1; l++)
			{
				method_7(buVector5.AskMe.LastMarkPosition[l], clsVar.varDisplay.OsnapSize, clsVar.varDisplay.displaySortedUpperEntities.Color, clsVar.varDisplay.displaySortedUpperEntities.Thickness);
			}
		}
	}

	private void method_19()
	{
		if (buVector5.AskMeBu.FoundEntities.Count > 0)
		{
			base.RenderContext.SetLineSize(clsVar.varDisplay.displayAskMeEntities.Thickness);
			base.RenderContext.SetColorWireframe(clsVar.varDisplay.displayAskMeEntities.Color);
			for (int i = 0; i <= buVector5.AskMeBu.FoundEntities.Count - 1; i++)
			{
				if (buVector5.AskMeBu.FoundEntities[i].Vertices != null)
				{
					base.RenderContext.DrawLines(WorldToScreen(buVector5.AskMeBu.FoundEntities[i].Vertices));
				}
			}
			if ((buVector5.AskMeBu.SelectedIndex >= 0) & (buVector5.AskMeBu.SelectedIndex <= buVector5.AskMeBu.FoundEntities.Count - 1))
			{
				base.RenderContext.SetLineSize(clsVar.varDisplay.displayAskMeEntitiesSelected.Thickness);
				base.RenderContext.SetColorWireframe(clsVar.varDisplay.displayAskMeEntitiesSelected.Color);
				if (buVector5.AskMeBu.FoundEntities[buVector5.AskMeBu.SelectedIndex].Vertices != null)
				{
					base.RenderContext.DrawLines(WorldToScreen(buVector5.AskMeBu.FoundEntities[buVector5.AskMeBu.SelectedIndex].Vertices));
					Point3D OtherPoint = new Point3D();
					clsInit.cVector5.GetOtherPointOfEntity(buVector5.AskMeBu.CatchPoint, buVector5.AskMeBu.FoundEntities[buVector5.AskMeBu.SelectedIndex], ref OtherPoint);
					_ = buVector5.AskMeBu.FoundEntities[buVector5.AskMeBu.SelectedIndex] is ICurve;
					method_15(buVector5.AskMeBu.CatchPoint, OtherPoint, 20.0, 10.0, 15.0);
				}
			}
		}
		if (ccVars.SortedEntities.Count > 0)
		{
			base.RenderContext.SetLineSize(clsVar.varDisplay.displaySortedEntities.Thickness);
			base.RenderContext.SetColorWireframe(clsVar.varDisplay.displaySortedEntities.Color);
			for (int j = 0; j <= ccVars.SortedEntities.Count - 1; j++)
			{
				if (!(ccVars.SortedEntities[j].GetType() == typeof(buUpperLineEnt)))
				{
					base.RenderContext.SetLineSize(clsVar.varDisplay.displaySortedEntities.Thickness);
					base.RenderContext.SetColorWireframe(clsVar.varDisplay.displaySortedEntities.Color);
				}
				else
				{
					base.RenderContext.SetLineSize(clsVar.varDisplay.displaySortedUpperEntities.Thickness);
					base.RenderContext.SetColorWireframe(clsVar.varDisplay.displaySortedUpperEntities.Color);
				}
				if (ccVars.SortedEntities[j].Vertices != null)
				{
					base.RenderContext.DrawLines(WorldToScreen(ccVars.SortedEntities[j].Vertices));
				}
			}
		}
		if (buVector5.AskMeBu.SortedEntities.Count > 0)
		{
			base.RenderContext.SetLineSize(clsVar.varDisplay.displaySortedEntities.Thickness);
			base.RenderContext.SetColorWireframe(clsVar.varDisplay.displaySortedEntities.Color);
			for (int k = 0; k <= buVector5.AskMeBu.SortedEntities.Count - 1; k++)
			{
				if (buVector5.AskMeBu.SortedEntities[k].Vertices != null)
				{
					base.RenderContext.DrawLines(WorldToScreen(buVector5.AskMeBu.SortedEntities[k].Vertices));
				}
			}
		}
		if (buVector5.AskMeBu.LastMarkPosition.Count > 0)
		{
			for (int l = buVector5.AskMeBu.LastMarkPosition.Count - 1; l <= buVector5.AskMeBu.LastMarkPosition.Count - 1; l++)
			{
				method_7(buVector5.AskMeBu.LastMarkPosition[l], clsVar.varDisplay.OsnapSize, clsVar.varDisplay.displaySortedUpperEntities.Color, clsVar.varDisplay.displaySortedUpperEntities.Thickness);
			}
		}
	}

	private void method_20()
	{
		base.RenderContext.SetLineSize(clsVar.varDisplay.displayDynamicArrowLineDrawing.Thickness);
		base.RenderContext.SetColorWireframe(clsVar.varDisplay.displayDynamicArrowLineDrawing.Color);
		for (int i = 0; i < FreeDrawStrokes.Count - 1; i++)
		{
			base.RenderContext.DrawLine(WorldToScreen(FreeDrawStrokes[i]), WorldToScreen(FreeDrawStrokes[i + 1]));
		}
		for (int j = 0; j <= FreeDrawStrokeList.Count - 1; j++)
		{
			for (int k = 0; k < FreeDrawStrokeList[j].Count - 1; k++)
			{
				base.RenderContext.DrawLine(WorldToScreen(FreeDrawStrokeList[j][k]), WorldToScreen(FreeDrawStrokeList[j][k + 1]));
			}
		}
	}

	private void method_21()
	{
		try
		{
			if (ccVars.HighLightPoints.Count <= 0)
			{
				return;
			}
			for (int i = 0; i <= ccVars.HighLightPoints.Count - 1; i++)
			{
				base.RenderContext.SetLineSize(clsVar.varDisplay.displayHighLight.Thickness + 2f);
				base.RenderContext.SetColorWireframe(clsVar.varDisplay.displayHighLight.Color);
				Point3D[] array = ccVars.HighLightPoints[i].PointsList.ToArray();
				if (ccVars.HighLightPoints[i].TriangleIndexList.Count != 0)
				{
					base.RenderContext.SetState(blendStateType.Blend);
					base.RenderContext.SetColorWireframe(clsVar.varDisplay.displayHighLight.Color);
					Vector3D[] array2 = new Vector3D[ccVars.HighLightPoints[i].Normals.Count];
					Point3D[] array3 = new Point3D[ccVars.HighLightPoints[i].TriangleIndexList.Count * 3];
					for (int j = 0; j <= ccVars.HighLightPoints[i].TriangleIndexList.Count - 1; j++)
					{
						Point3D point3D = array[ccVars.HighLightPoints[i].TriangleIndexList[j].V1];
						Point3D point3D2 = array[ccVars.HighLightPoints[i].TriangleIndexList[j].V2];
						Point3D point3D3 = array[ccVars.HighLightPoints[i].TriangleIndexList[j].V3];
						array3[j * 3] = new Point3D(point3D.X, point3D.Y, point3D.Z);
						array3[j * 3 + 1] = new Point3D(point3D2.X, point3D2.Y, point3D2.Z);
						array3[j * 3 + 2] = new Point3D(point3D3.X, point3D3.Y, point3D3.Z);
					}
					for (int k = 0; k <= ccVars.HighLightPoints[i].Normals.Count - 1; k++)
					{
						array2[k] = new Vector3D(ccVars.HighLightPoints[i].Normals[k].X, ccVars.HighLightPoints[i].Normals[k].Y, ccVars.HighLightPoints[i].Normals[k].Z);
					}
					if (array3.Length != 0)
					{
						base.RenderContext.DrawTriangles(WorldToScreen(array3), Vector3D.AxisZ);
					}
					base.RenderContext.SetState(blendStateType.NoBlend);
				}
				else
				{
					base.RenderContext.DrawLineStrip(WorldToScreen(array));
				}
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	public void DrawCurrentLine(Point3D pntPrevious, Point3D pntCurrent)
	{
		base.RenderContext.SetLineSize(clsVar.varDisplay.displayDynamicArrowLineDrawing.Thickness);
		base.RenderContext.SetColorWireframe(clsVar.varDisplay.displayDynamicArrowLineDrawing.Color);
		base.RenderContext.DrawLine(WorldToScreen(pntPrevious), WorldToScreen(pntCurrent));
		if (ccVars.enableViewPortCurrentLineArrow)
		{
		}
	}

	public void DrawDynamicPointCompositeCurve(Point3D pointLast)
	{
		Point4D point4D = null;
		if (ccVars.pntDynamicCompositeCurve.Count > 0)
		{
			point4D = ccVars.pntDynamicCompositeCurve[ccVars.pntDynamicCompositeCurve.Count - 1];
		}
		List<Point3D> list = new List<Point3D>();
		for (int i = 0; i <= ccVars.pntDynamicCompositeCurve.Count - 1; i++)
		{
			Point4D point4D2 = ccVars.pntDynamicCompositeCurve[i];
			if (point4D2.W == 0.0)
			{
				list.Add(new Point3D(point4D2.X, point4D2.Y, point4D2.Z));
			}
			if (point4D2.W != 2.0)
			{
				continue;
			}
			Point4D point4D3 = ccVars.pntDynamicCompositeCurve[i - 2];
			Point4D point4D4 = ccVars.pntDynamicCompositeCurve[i - 1];
			List<Point3D> Vertices = new List<Point3D>();
			double num = clsInit.cVector5.Length3D(point4D4, point4D3);
			double num2 = clsInit.cVector5.Length3D(point4D4, point4D2);
			if (num > 0.5 && num2 > 0.5)
			{
				clsInit.cVector5.Arc3Point(new Point3D(point4D3.X, point4D3.Y, point4D3.Z), new Point3D(point4D4.X, point4D4.Y, point4D4.Z), new Point3D(point4D2.X, point4D2.Y, point4D2.Z), ccVars.planeActive, new EntityResolution(0.5, 10, 20.0, EntityResolutionType.ByLnRadius, 25), ref Vertices);
				if (Vertices.Count >= 3)
				{
					Vertices.RemoveAt(0);
					list.AddRange(Vertices);
				}
			}
		}
		if (point4D != null)
		{
			if ((point4D.W == 0.0) | (point4D.W == 2.0))
			{
				list.Add(new Point3D(pointLast.X, pointLast.Y, pointLast.Z));
			}
			if (point4D.W == 1.0)
			{
				Point4D point4D5 = ccVars.pntDynamicCompositeCurve[ccVars.pntDynamicCompositeCurve.Count - 2];
				List<Point3D> Vertices2 = new List<Point3D>();
				double num3 = clsInit.cVector5.Length3D(point4D5, point4D);
				double num4 = clsInit.cVector5.Length3D(point4D, pointLast);
				if (num3 > 0.5 && num4 > 0.5)
				{
					clsInit.cVector5.Arc3Point(new Point3D(point4D5.X, point4D5.Y, point4D5.Z), new Point3D(point4D.X, point4D.Y, point4D.Z), pointLast, ccVars.planeActive, new EntityResolution(0.5, 10, 20.0, EntityResolutionType.ByLnRadius, 25), ref Vertices2);
					if (Vertices2.Count >= 3)
					{
						if (!buCompare5.EQ(Vertices2[0], point4D5))
						{
							Vertices2.Reverse();
						}
						Vertices2.RemoveAt(0);
						list.AddRange(Vertices2);
					}
				}
			}
		}
		base.RenderContext.SetLineSize(clsVar.varDisplay.displayDynamicArrowLineDrawing.Thickness);
		base.RenderContext.SetColorWireframe(clsVar.varDisplay.displayDynamicArrowLineDrawing.Color);
		base.RenderContext.DrawLineStrip(WorldToScreen(list));
		if (ccVars.pntDynamicCompositeCurve.Count > 0 && ccVars.pntDynamicCompositeCurve[ccVars.pntDynamicCompositeCurve.Count - 1].W == 1.0)
		{
			Point4D point4D6 = ccVars.pntDynamicCompositeCurve[ccVars.pntDynamicCompositeCurve.Count - 1];
			method_7(new Point3D(point4D6.X, point4D6.Y, point4D6.Z), clsVar.varDisplay.OsnapSize, Color.Lime, 4f);
		}
	}

	public void DrawDynamicPointArr()
	{
		if (ccVars.pntDrawDynamicArr != null && ccVars.pntDrawDynamicArr.Length != 0)
		{
			base.RenderContext.SetLineSize(clsVar.varDisplay.displayDynamicArrowLineDrawing.Thickness);
			base.RenderContext.SetColorWireframe(clsVar.varDisplay.displayDynamicArrowLineDrawing.Color);
			base.RenderContext.DrawLineStrip(WorldToScreen(ccVars.pntDrawDynamicArr));
		}
	}

	public void DrawDynamicPointLineArr()
	{
		if (ccVars.pntDrawDynamicLinesArr == null)
		{
			return;
		}
		for (int i = 0; i <= ccVars.pntDrawDynamicLinesArr.Count - 1; i++)
		{
			if (ccVars.pntDrawDynamicLinesArr[i].Count <= 1)
			{
				if (ccVars.pntDrawDynamicLinesArr[i].Count == 1)
				{
					base.RenderContext.SetLineSize(clsVar.varDisplay.displayDynamicArrowLineDrawing.Thickness + 2f);
					base.RenderContext.SetColorWireframe(clsVar.varDisplay.displayDynamicArrowLineDrawing.Color);
					base.RenderContext.DrawPoints(WorldToScreen(ccVars.pntDrawDynamicLinesArr[i]));
				}
			}
			else
			{
				base.RenderContext.SetLineSize(clsVar.varDisplay.displayDynamicArrowLineDrawing.Thickness);
				base.RenderContext.SetColorWireframe(clsVar.varDisplay.displayDynamicArrowLineDrawing.Color);
				base.RenderContext.DrawLineStrip(WorldToScreen(ccVars.pntDrawDynamicLinesArr[i]));
			}
		}
	}

	public void DrawDynamicPointLineArrColor()
	{
		if (ccVars.pntDrawDynamicLinesArrColored == null)
		{
			return;
		}
		for (int i = 0; i <= ccVars.pntDrawDynamicLinesArrColored.Count - 1; i++)
		{
			for (int j = 1; j <= ccVars.pntDrawDynamicLinesArrColored[i].Count - 1; j++)
			{
				base.RenderContext.SetLineSize(clsVar.varDisplay.displayDynamicArrowLineDrawing.Thickness);
				base.RenderContext.SetColorWireframe(Color.FromArgb(ccVars.pntDrawDynamicLinesArrColored[i][j - 1].R, ccVars.pntDrawDynamicLinesArrColored[i][j - 1].G, ccVars.pntDrawDynamicLinesArrColored[i][j - 1].B));
				base.RenderContext.DrawLine(WorldToScreen(ccVars.pntDrawDynamicLinesArrColored[i][j - 1]), WorldToScreen(ccVars.pntDrawDynamicLinesArrColored[i][j]));
			}
		}
	}

	public void DrawDynamicMeasure()
	{
		if (ccVars.pntDrawDynamicMeasure == null)
		{
			return;
		}
		for (int i = 0; i <= ccVars.pntDrawDynamicMeasure.Count - 1; i++)
		{
			if (ccVars.pntDrawDynamicMeasure[i].Points.Count > 0)
			{
				base.RenderContext.SetLineSize(ccVars.pntDrawDynamicMeasure[i].Size);
				base.RenderContext.SetColorWireframe(ccVars.pntDrawDynamicMeasure[i].Color);
				base.RenderContext.DrawLineStrip(WorldToScreen(ccVars.pntDrawDynamicMeasure[i].Points));
				string text = ccVars.pntDrawDynamicMeasure[i].Text;
				if (!buCompare.EQ(ccVars.pntDrawDynamicMeasure[i].Length, 0.0, 0.001))
				{
					text += ccVars.pntDrawDynamicMeasure[i].Length.ToString("f3");
				}
				method_25(ccVars.pntDrawDynamicMeasure[i].PntText, text);
			}
		}
	}

	public void DrawDynamicPointList()
	{
		if (ccVars.pntDrawDynamicLines != null && ccVars.pntDrawDynamicLines.Count > 0 && ccVars.pntDrawDynamicLines[0] != null)
		{
			base.RenderContext.SetLineSize(clsVar.varDisplay.displayDynamicArrowLineDrawing.Thickness);
			base.RenderContext.SetColorWireframe(clsVar.varDisplay.displayDynamicArrowLineDrawing.Color);
			base.RenderContext.DrawLineStrip(WorldToScreen(ccVars.pntDrawDynamicLines));
		}
	}

	private void method_22()
	{
		try
		{
			if (!((ccVars.SelectionOP.Selections.Count > 0) & clsVar.varDisplay.ShowSelectedEntitiesPoint))
			{
				return;
			}
			if (clsVar.varDisplay.ShowSelectedEntitiesMovePoint)
			{
				for (int i = 0; i <= ccVars.SelectionOP.Selections.Count - 1; i++)
				{
					for (int j = 0; j <= ccVars.SelectionOP.Selections[i].AlingPoints.MovePoints.Count - 1; j++)
					{
						Point2D point2D = WorldToScreen(ccVars.SelectionOP.Selections[i].AlingPoints.MovePoints[j]);
						method_5(new System.Drawing.Point((int)point2D.X, (int)point2D.Y), clsVar.varSelection.SelectionBoxSize, clsVar.varSelection.displaySelectionBoxMove.Color, clsVar.varSelection.displaySelectionBoxMove.Thickness);
					}
				}
			}
			if (!clsVar.varDisplay.ShowSelectedEntitiesTipPoint)
			{
				return;
			}
			for (int k = 0; k <= ccVars.SelectionOP.Selections.Count - 1; k++)
			{
				for (int l = 0; l <= ccVars.SelectionOP.Selections[k].AlingPoints.TipPoints.Count - 1; l++)
				{
					Point2D point2D2 = WorldToScreen(ccVars.SelectionOP.Selections[k].AlingPoints.TipPoints[l]);
					method_5(new System.Drawing.Point((int)point2D2.X, (int)point2D2.Y), clsVar.varSelection.SelectionBoxSize, clsVar.varSelection.displaySelectionBox.Color, clsVar.varSelection.displaySelectionBox.Thickness);
				}
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	private void method_23(Point3D point3D_0, string string_0, string string_1)
	{
		try
		{
			string text = string_1;
			if (text.Length > 0)
			{
				text = Environment.NewLine + string_1;
			}
			string text2 = "";
			if (clsVar.varView.ShowDynamicTextCommand)
			{
				text2 = string_0 + " - ";
			}
			if (!clsVar.varView.ShowDynamicTextInfo)
			{
				text = "";
			}
			DrawText(mouseLocation.X, base.Height - mouseLocation.Y + 10, text2 + text, new Font("Arial", (float)clsVar.varView.DynamicTextSize), clsVar.varView.colorDynamicText, ContentAlignment.BottomLeft);
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	private void method_24(int int_0, int int_1, string string_0)
	{
		try
		{
			if (string_0.Length > 0)
			{
				DrawText(int_0, base.Height - int_1 + 10, string_0, new Font("Arial", (float)clsVar.varView.DynamicTextSize), clsVar.varView.colorDynamicText, ContentAlignment.MiddleCenter);
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	private void method_25(Point3D point3D_0, string string_0)
	{
		try
		{
			if (string_0.Length > 0)
			{
				DrawText((int)WorldToScreen(point3D_0).X, (int)WorldToScreen(point3D_0).Y + 10, string_0, new Font("Arial", (float)clsVar.varView.DynamicTextSize), clsVar.varView.colorDynamicText, clsVar.varView.DynamicTextAlignment);
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	private void method_26(Point3D point3D_0)
	{
		try
		{
			base.RenderContext.SetLineSize(clsVar.varView.displayDynamicBigCrossDisplay.Thickness);
			base.RenderContext.SetColorWireframe(clsVar.varView.displayDynamicBigCrossDisplay.Color);
			base.RenderContext.DrawLine(WorldToScreen(pntLowerLeft.X, point3D_0.Y, point3D_0.Z), WorldToScreen(pntLowerRight.X, point3D_0.Y, point3D_0.Z));
			base.RenderContext.DrawLine(WorldToScreen(point3D_0.X, pntLowerLeft.Y, point3D_0.Z), WorldToScreen(point3D_0.X, pntUpperLeft.Y, point3D_0.Z));
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	private void method_27(Point3D point3D_0, float float_0, Color color_0, double double_0 = 20.0)
	{
		try
		{
			base.RenderContext.SetLineSize(float_0);
			base.RenderContext.SetColorWireframe(color_0);
			Point3D point3D = WorldToScreen(point3D_0);
			Point3D point3D2 = WorldToScreen(point3D_0.X - 1.0, point3D_0.Y, point3D_0.Z);
			Vector3D vector3D = new Vector3D(1.0, 0.0, 0.0);
			point3D2 = point3D + vector3D * double_0;
			Point2D p = point3D - vector3D * double_0;
			base.RenderContext.DrawLine(point3D2, p);
			Point3D point3D3 = WorldToScreen(point3D_0.X, point3D_0.Y, point3D_0.Z);
			Vector3D vector3D2 = new Vector3D(0.0, 1.0, 0.0);
			point3D3 = point3D + vector3D2 * double_0;
			Point3D p2 = point3D - vector3D2 * double_0;
			base.RenderContext.DrawLine(point3D3, p2);
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	private void method_28()
	{
		base.RenderContext.SetLineSize(clsVar.varDisplay.displaySortArrow.Thickness);
		base.RenderContext.SetColorWireframe(clsVar.varDisplay.displaySortArrow.Color);
		if (ccVars.SortArrow.Count > 0)
		{
			for (int i = 0; i <= ccVars.SortArrow.Count - 1; i++)
			{
				method_15(buConversion5.Pnt3DToPoint3D(ccVars.SortArrow[i].PrePoint), buConversion5.Pnt3DToPoint3D(ccVars.SortArrow[i].Point), ccVars.SortArrow[i].Length, 10.0, ccVars.SortArrow[i].PointAngle);
			}
		}
	}
}
