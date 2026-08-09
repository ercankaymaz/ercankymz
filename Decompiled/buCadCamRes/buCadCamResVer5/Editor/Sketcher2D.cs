using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using buCadCamResVer5.Sewing;
using buClass;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Control.Labels;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;
using ns8;

namespace buCadCamResVer5.Editor;

public class Sketcher2D : Design
{
	public static bool isDrawing;

	public static bool isSelectionDone;

	public static bool isAreaSelection;

	public static bool selectionProcess;

	public static bool buttonPressedForSelection;

	public static bool OrthoPossible;

	public static bool FirstMove;

	public static bool ForbiddenAreaClicked;

	public static int indexLabel;

	public static int rightClickCnt;

	protected DimensionPreviewDrawParams PreviewDrawParams = new DimensionPreviewDrawParams(Color.Blue)
	{
		LineSize = 1f,
		WidthFactor = 0.9
	};

	public Point3D mouseWorldLoc = Point3D.Origin;

	public Point3D mouseLastClick = Point3D.Origin;

	public Point2D mouseScreenLoc = new Point2D();

	public static Point3D mouseWorldCoord;

	public static Point2D mousePlnLoc;

	public static System.Drawing.Point mouseDownLocation;

	protected System.Drawing.Point mouseloc;

	public static List<List<Point3D>> DrawingPoints;

	public static List<UClick> Clicks;

	public static List<Point3D> selectedPoint;

	public static List<Circle> selectedCircle;

	public static pickStateType currPickState;

	public static ISelectableItem entityMouseUnder;

	private ISelectableItem iselectableItem_0;

	public static double PixelVsMilimeter;

	public static Entity entitySelected;

	public static List<Entity> entitiesSelected;

	public static List<List<int>> selectedIndex;

	private devDept.Eyeshot.Entities.Point point_0;

	private devDept.Eyeshot.Entities.Point point_1;

	private bool bool_0;

	internal OsnapPoint[] osnapPoint_0;

	private OsnapPoint osnapPoint_1 = null;

	private int[] int_0 = null;

	private Plane plane_0;

	private System.Drawing.Point point_2;

	private int int_1 = -1;

	private int int_2 = -1;

	private Point2D point2D_0;

	private bool bool_1;

	private Entity entity_0;

	private List<Entity> list_0 = new List<Entity>();

	public static Entity secondSelectedEntity;

	public static Entity firstSelectedEntity;

	internal double double_0 = 500.0;

	private string string_0 = "";

	internal Point3D point3D_0;

	internal Point3D point3D_1;

	private readonly List<Entity> rotateHiddenEntities;

	public List<Point4D> ControlPoints(Curve curve)
	{
		return curve.Decompose().SelectMany((Curve curve_0) => curve_0.ControlPoints).ToList();
	}

	public Sketcher2D()
	{
		if (!IsDesignMode())
		{
			LoadDocument(new SketcherDesignDocument());
			base.WaitCursorMode = waitCursorType.Never;
			string_0 = base.Layers[0].Name;
			Clear();
		}
	}

	protected override void OnMouseMove(MouseEventArgs mea)
	{
		try
		{
			mouseloc = mea.Location;
			mouseScreenLoc = new Point2D(mea.Location.X, base.Height - mea.Location.Y);
			System.Drawing.Point location = mea.Location;
			if (mouseloc == point_2)
			{
				return;
			}
			ScreenToPlane(location, Plane.XY, out mouseWorldLoc);
			if (mouseWorldLoc == null)
			{
				return;
			}
			mouseWorldCoord.X = mouseWorldLoc.X;
			mouseWorldCoord.Y = mouseWorldLoc.Y;
			if (clsVar.varEditorSet.Ortho & OrthoPossible)
			{
				int OrthoDir = 0;
				new Point3D();
				clsInit.cVector5.OrthoFunction(mouseWorldLoc, mouseLastClick, Plane.XY, ref mouseWorldLoc, ref OrthoDir);
			}
			osnapPoint_1 = null;
			osnapPoint_0 = GetSnapPoints(mouseloc);
			if (osnapPoint_0 != null && osnapPoint_0.Length != 0)
			{
				osnapPoint_1 = method_17(osnapPoint_0);
				if (osnapPoint_1 != null)
				{
					mouseWorldLoc = osnapPoint_1;
				}
			}
			if ((osnapPoint_1 == null) & !selectionProcess)
			{
				osnapPoint_1 = Snaping();
				if (osnapPoint_1 != null)
				{
					mouseWorldLoc = osnapPoint_1;
					mouseScreenLoc = WorldToScreen(mouseWorldLoc);
				}
			}
			if (osnapPoint_1 == null)
			{
				osnapPoint_0 = new OsnapPoint[1];
				osnapPoint_0[0] = new OsnapPoint(new Point3D(), osnapType.Point);
				osnapPoint_1 = method_17(osnapPoint_0);
				if (osnapPoint_1 != null)
				{
					mouseWorldLoc = osnapPoint_1;
				}
			}
			int_0 = null;
			entityMouseUnder = GetEntityByPosition(mea.Location);
			int_0 = GetAllEntitiesUnderMouseCursor(mea.Location);
			indexLabel = GetLabelUnderMouseCursor(mea.Location);
			base.TempEntities.Clear();
			if (entityMouseUnder == null || base.Entities.Count > 0)
			{
			}
			if (((entityMouseUnder == null) & (indexLabel >= 0)) && base.ActiveViewport.Labels[indexLabel] is StackedLabel)
			{
				base.CurrentSketch.DisplayConstraintEntities((base.ActiveViewport.Labels[indexLabel] as StackedLabel).Constraint);
			}
			if (bool_1)
			{
				ScreenToPlane(mea.Location, base.CurrentSketch.DrawingPlane, out var intPoint);
				Point2D point2D = base.CurrentSketch.DrawingPlane.Project(intPoint);
				if (iselectableItem_0 is Entity)
				{
					base.CurrentSketch.DragTo(mousePlnLoc);
				}
				point2D_0 = point2D;
				if (base.CurrentSketch.DOF > 0)
				{
					base.CurrentSketch.UpdateAndInvalidate();
				}
			}
			if (buttonPressedForSelection & selectionProcess)
			{
				int num = mea.Location.X - mouseDownLocation.X;
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
			if (clsInit.appEditor.action == actionTypeBU.eventTrim)
			{
				method_4();
			}
			mouseWorldLoc = mouseWorldLoc ?? Point3D.Origin;
			mousePlnLoc = Plane.XY.Project(mouseWorldLoc);
			point_2 = mouseloc;
			if (clsItem.frmEditor != null)
			{
				clsItem.frmEditor.lbl_x.Text = "X: " + mouseWorldLoc.X.ToString("f2");
				clsItem.frmEditor.lbl_y.Text = "Y: " + mouseWorldLoc.Y.ToString("f2");
			}
			if (clsItem.frmEditor != null)
			{
				clsItem.frmEditor.Viewport_MouseMove(null, mea);
			}
			Invalidate();
			base.OnMouseMove(mea);
		}
		catch (Exception)
		{
		}
	}

	protected override void OnMouseDown(MouseEventArgs mea)
	{
		try
		{
			Entity entity = null;
			iselectableItem_0 = GetEntityByPosition(mea.Location);
			if (iselectableItem_0 is Entity)
			{
				entity = (Entity)iselectableItem_0;
				if (clsInit.appEditor.action == actionTypeBU.None && clsVar.varEditorRuntimeSet.isSketchMode)
				{
					bool_1 = true;
					if (entity.Selected)
					{
						base.ActionMode = actionType.None;
						base.CurrentSketch.DragStart(mousePlnLoc, base.Entities.Where((Entity entity_0) => entity_0.Selected).ToArray());
					}
					else
					{
						base.CurrentSketch.DragStart(mousePlnLoc, entity);
						entity.Selected = true;
					}
				}
			}
			if (mouseWorldLoc == null)
			{
				return;
			}
			int_2 = -1;
			int[] allEntitiesUnderMouseCursor = GetAllEntitiesUnderMouseCursor(mea.Location);
			int_2 = GetEntityUnderMouseCursor(mea.Location);
			entitySelected = null;
			if ((mea.Button == MouseButtons.Left) & selectionProcess & selectionProcess & !ForbiddenAreaClicked & !bool_1)
			{
				buttonPressedForSelection = true;
				mouseDownLocation = mea.Location;
				currPickState = pickStateType.Pick;
			}
			if (mea.Button == MouseButtons.Left)
			{
				if ((clsInit.appEditor.action != actionTypeBU.None) & !selectionProcess)
				{
					Clicks.Add(new UClick(mousePlnLoc, new Point3D(mousePlnLoc.X, mousePlnLoc.Y), entity, bool_0));
				}
				mouseLastClick.X = mouseWorldLoc.X;
				mouseLastClick.Y = mouseWorldLoc.Y;
				MouseDownDrawings(entity, mea);
				if (!selectionProcess)
				{
					MouseDownEvents(allEntitiesUnderMouseCursor, mea);
				}
				if (clsInit.appEditor.action == actionTypeBU.sewingSorting)
				{
					clsInit.appSewing.doSortMainEntitiesByRefPoint(mouseWorldLoc, clsSewing.varSewingRunSettings.NextRules);
					clsInit.appSewing.DrawSewingData(clsInit.appSewing.SewingBase, base.Entities);
				}
				if (clsInit.appEditor.action == actionTypeBU.sewingPunteriz)
				{
					clsInit.appSewing.doDefinePunteriz(mouseWorldLoc, clsSewing.varSewingRunSettings.ShowDialog);
					clsInit.appSewing.DrawSewingData(clsInit.appSewing.SewingBase, base.Entities);
				}
				if (clsInit.appEditor.action == actionTypeBU.sewingLockStitch)
				{
					clsInit.appSewing.doDefineLockStitch(mouseWorldLoc, clsSewing.varSewingRunSettings.ShowDialog);
					clsInit.appSewing.DrawSewingData(clsInit.appSewing.SewingBase, base.Entities);
				}
				if (clsInit.appEditor.action == actionTypeBU.sewingScale)
				{
					clsInit.appSewing.Selected.Clear();
					clsInit.appSewing.doDefineScale(mouseWorldLoc, clsSewing.varSewingRunSettings.ShowDialog);
				}
				if (clsInit.appEditor.action == actionTypeBU.sewingRotate)
				{
					clsInit.appSewing.Selected.Clear();
					clsInit.appSewing.doDefineRotate(mouseWorldLoc, clsSewing.varSewingRunSettings.ShowDialog);
				}
				if (clsInit.appEditor.action == actionTypeBU.sewingDeleteVertex)
				{
					clsInit.appSewing.Selected.Clear();
					clsInit.appSewing.doDeleteVertex(mouseWorldLoc);
				}
				if ((clsInit.appEditor.action == actionTypeBU.sewingMoveVertex) | (clsInit.appEditor.action == actionTypeBU.sewingFootHeight) | (clsInit.appEditor.action == actionTypeBU.sewingChangeDirection) | (clsInit.appEditor.action == actionTypeBU.sewingSpeed))
				{
					clsInit.appSewing.Selected.Clear();
					clsInit.appSewing.doDefineSelectVertex(mouseWorldLoc, clsInit.appEditor.action);
				}
				if (clsInit.appEditor.action == actionTypeBU.sewingAddCode)
				{
					clsInit.appSewing.doDefineAddCodes(mouseWorldLoc);
					clsInit.appSewing.DrawSewingData(clsInit.appSewing.SewingBase, base.Entities);
					clsInit.appSewing.JobUpdate();
				}
				if (clsInit.appEditor.action == actionTypeBU.miscAutoSort)
				{
					clsInit.appEditor.ManuelSort(mouseWorldLoc);
				}
				if (clsInit.appEditor.action == actionTypeBU.libraryVertical && entity != null && entity is Line)
				{
					clsInit.appEditor.CreateConstraintVertical((Line)entity);
				}
				if (clsInit.appEditor.action == actionTypeBU.libraryHorizontal && entity != null && entity is Line)
				{
					clsInit.appEditor.CreateConstraintHorizontal((Line)entity);
				}
				if (clsInit.appEditor.action == actionTypeBU.libraryLength)
				{
					if (isSelectionDone & (entitiesSelected.Count > 0))
					{
						clsInit.appEditor.CreateConstraintLength((Line)entitiesSelected[0], mouseWorldLoc);
						isSelectionDone = false;
						entitiesSelected.Clear();
					}
					if (entity != null && entity is Line)
					{
						entitySelected = entity;
						entitiesSelected.Add(entity);
					}
				}
				if (clsInit.appEditor.action == actionTypeBU.libraryRadius)
				{
					if (isSelectionDone & (entitiesSelected.Count > 0))
					{
						clsInit.appEditor.CreateConstraintDiameter((Circle)entitiesSelected[0]);
						isSelectionDone = false;
						entitiesSelected.Clear();
					}
					if (entity != null && entity is Circle)
					{
						entitySelected = entity;
						entitiesSelected.Add(entity);
					}
				}
				if (clsInit.appEditor.action == actionTypeBU.libraryFixPoint)
				{
					clsInit.appEditor.CreateConstraintFixPoint(entity, mouseWorldLoc);
				}
				if (clsInit.appEditor.action == actionTypeBU.libraryAngle)
				{
					if (entity != null && ((entity is Arc) & !isSelectionDone))
					{
						entity.Selected = true;
						entitiesSelected.Add(entity);
						return;
					}
					if ((entitiesSelected.Count == 1) & isSelectionDone)
					{
						clsInit.appEditor.CreateConstraintAngle((Arc)entitiesSelected[0], mouseWorldLoc);
					}
					if (entity != null && ((entity is Line) & !isSelectionDone))
					{
						entity.Selected = true;
						entitiesSelected.Add(entity);
						if (entitiesSelected.Count == 2)
						{
							Line L = entitiesSelected[0] as Line;
							Line L2 = entitiesSelected[1] as Line;
							clsInit.appEditor.AngleCalculation(ref L, ref L2);
						}
					}
					if ((entitiesSelected.Count == 2) & isSelectionDone)
					{
						clsInit.appEditor.CreateConstraintAngle((Line)entitiesSelected[0], (Line)entitiesSelected[1], mouseWorldLoc);
					}
				}
				if (clsInit.appEditor.action == actionTypeBU.libraryFillet)
				{
					if (entity != null && (entity is Line || entity is Arc || entity is Curve))
					{
						entity.Selected = true;
						entitiesSelected.Add(entity);
					}
					if (entitiesSelected.Count == 2)
					{
						clsInit.appEditor.FilletChamferCalculation(isFillet: true);
						entitiesSelected.Clear();
					}
				}
				if (clsInit.appEditor.action == actionTypeBU.libraryChamfer)
				{
					if (entity != null && (entity is Line || entity is Arc || entity is Curve))
					{
						entity.Selected = true;
						entitiesSelected.Add(entity);
					}
					if (entitiesSelected.Count == 2)
					{
						clsInit.appEditor.FilletChamferCalculation(isFillet: false);
						entitiesSelected.Clear();
					}
				}
				if (clsInit.appEditor.action == actionTypeBU.libraryEqualLength)
				{
					if (entity != null && entity is ICurve)
					{
						entity.Selected = true;
						entitiesSelected.Add(entity);
					}
					if (entitiesSelected.Count == 2)
					{
						clsInit.appEditor.CreateConstraintEqualLength(entitiesSelected[0], entitiesSelected[1], Radius: false);
						entitiesSelected.Clear();
					}
				}
				if (clsInit.appEditor.action == actionTypeBU.libraryEqualRadius)
				{
					if (entity != null && (entity is Circle || entity is Arc))
					{
						entity.Selected = true;
						entitiesSelected.Add(entity);
					}
					if (entitiesSelected.Count == 2)
					{
						clsInit.appEditor.CreateConstraintEqualLength(entitiesSelected[0], entitiesSelected[1], Radius: true);
						entitiesSelected.Clear();
					}
				}
				if (clsInit.appEditor.action == actionTypeBU.libraryLineLine)
				{
					if (entity != null && ((entity is Line) & !isSelectionDone))
					{
						entity.Selected = true;
						entitiesSelected.Add(entity);
					}
					if ((entitiesSelected.Count == 2) & isSelectionDone)
					{
						clsInit.appEditor.CreateConstraintLineLineDistance((Line)entitiesSelected[0], (Line)entitiesSelected[1], mouseWorldLoc);
						entitiesSelected.Clear();
					}
				}
				if (clsInit.appEditor.action == actionTypeBU.libraryLinePoint)
				{
					if (entity != null && entitiesSelected.Count == 0 && ((entity is Line || entity is devDept.Eyeshot.Entities.Point) & !isSelectionDone))
					{
						entity.Selected = true;
						entitiesSelected.Add(entity);
						return;
					}
					bool flag = false;
					if (entity != null && entitiesSelected.Count == 1 && ((entity is Line || entity is devDept.Eyeshot.Entities.Point) & !isSelectionDone))
					{
						if (!(entitiesSelected[0] is Line && entity is devDept.Eyeshot.Entities.Point))
						{
							if (entitiesSelected[0] is devDept.Eyeshot.Entities.Point && entity is Line)
							{
								entity.Selected = true;
								entitiesSelected.Add(entity);
								flag = true;
							}
						}
						else
						{
							entity.Selected = true;
							entitiesSelected.Add(entity);
							flag = true;
						}
					}
					if (!flag && entitiesSelected.Count == 1 && entitiesSelected[0] is Line)
					{
						for (int num = 0; num <= base.Entities.Count - 1; num++)
						{
							if (base.Entities[num] is devDept.Eyeshot.Entities.Point)
							{
								double num2 = Point3D.Distance(((devDept.Eyeshot.Entities.Point)base.Entities[num]).Position, mouseWorldLoc);
								if (num2 < 0.1)
								{
									entity = base.Entities[num];
									entity.Selected = true;
									entitiesSelected.Add(entity);
									num = base.Entities.Count;
								}
							}
						}
					}
					if ((entitiesSelected.Count == 2) & isSelectionDone)
					{
						if (!((entitiesSelected[0] is Line) & (entitiesSelected[1] is devDept.Eyeshot.Entities.Point)))
						{
							if ((entitiesSelected[0] is devDept.Eyeshot.Entities.Point) & (entitiesSelected[1] is Line))
							{
								clsInit.appEditor.CreateConstraintLinePointDistance((devDept.Eyeshot.Entities.Point)entitiesSelected[0], (Line)entitiesSelected[1], mouseWorldLoc);
							}
						}
						else
						{
							clsInit.appEditor.CreateConstraintLinePointDistance((devDept.Eyeshot.Entities.Point)entitiesSelected[1], (Line)entitiesSelected[0], mouseWorldLoc);
						}
						entitiesSelected.Clear();
					}
				}
				if (clsInit.appEditor.action == actionTypeBU.libraryPointPoint)
				{
					bool flag2 = false;
					if (((entity != null) & !isSelectionDone) && entity is devDept.Eyeshot.Entities.Point)
					{
						entity.Selected = true;
						entitiesSelected.Add(entity);
						flag2 = true;
					}
					if (!flag2 & !isSelectionDone)
					{
						for (int num3 = 0; num3 <= base.Entities.Count - 1; num3++)
						{
							if (base.Entities[num3] is devDept.Eyeshot.Entities.Point)
							{
								double num4 = Point3D.Distance(((devDept.Eyeshot.Entities.Point)base.Entities[num3]).Position, mouseWorldLoc);
								if (num4 < 0.1)
								{
									entity = base.Entities[num3];
									entity.Selected = true;
									entitiesSelected.Add(entity);
								}
							}
						}
					}
					if ((entitiesSelected.Count == 2) & isSelectionDone)
					{
						if (!Vector3D.AreParallel(plane_0.AxisX, clsItem.frmEditor.viewport.CurrentSketch.Plane.AxisX))
						{
							if (!Vector3D.AreParallel(plane_0.AxisX, clsItem.frmEditor.viewport.CurrentSketch.Plane.AxisY))
							{
								clsInit.appEditor.CreateConstraintPointPointAlignedDistance((devDept.Eyeshot.Entities.Point)entitiesSelected[0], (devDept.Eyeshot.Entities.Point)entitiesSelected[1], mouseWorldLoc);
							}
							else
							{
								clsInit.appEditor.CreateConstraintPointPointVerticalDistance((devDept.Eyeshot.Entities.Point)entitiesSelected[0], (devDept.Eyeshot.Entities.Point)entitiesSelected[1], mouseWorldLoc);
							}
						}
						else
						{
							clsInit.appEditor.CreateConstraintPointPointHorizontalDistance((devDept.Eyeshot.Entities.Point)entitiesSelected[0], (devDept.Eyeshot.Entities.Point)entitiesSelected[1], mouseWorldLoc);
						}
						entitiesSelected.Clear();
					}
				}
				if (clsInit.appEditor.action == actionTypeBU.libraryCollinear && entity != null && entity is Line)
				{
					entity.Selected = true;
					entitiesSelected.Add(entity);
					if (entitiesSelected.Count == 2)
					{
						Line l = entitiesSelected[0] as Line;
						Line l2 = entitiesSelected[1] as Line;
						clsInit.appEditor.CreateConstraintCollinear(l, l2);
					}
				}
				if (clsInit.appEditor.action == actionTypeBU.libraryParalel && entity != null && entity is Line)
				{
					entity.Selected = true;
					entitiesSelected.Add(entity);
					if (entitiesSelected.Count == 2)
					{
						Line l3 = entitiesSelected[0] as Line;
						Line l4 = entitiesSelected[1] as Line;
						clsInit.appEditor.CreateConstraintParallel(l3, l4);
					}
				}
				if (clsInit.appEditor.action == actionTypeBU.libraryPerpendiculat && entity != null && entity is Line)
				{
					entity.Selected = true;
					entitiesSelected.Add(entity);
					if (entitiesSelected.Count == 2)
					{
						Line l5 = entitiesSelected[0] as Line;
						Line l6 = entitiesSelected[1] as Line;
						clsInit.appEditor.CreateConstraintPerpendicular(l5, l6);
					}
				}
				if (clsInit.appEditor.action == actionTypeBU.libraryTangent && entity != null && entity is ICurve)
				{
					entity.Selected = true;
					entitiesSelected.Add(entity);
					if (entitiesSelected.Count == 2)
					{
						clsInit.appEditor.CreateConstraintTangent(entitiesSelected[0], entitiesSelected[1]);
					}
				}
				if (clsInit.appEditor.action == actionTypeBU.libraryDeleteEntity && entity != null && entity is ICurve)
				{
					clsInit.appEditor.cmdDeleteEntity(entity);
				}
			}
			if (mea.Button == MouseButtons.Right)
			{
				if (clsInit.appEditor.action == actionTypeBU.drawSpline)
				{
					if (Clicks.Count == 1)
					{
						if (clsVar.varEditorRuntimeSet.isSketchMode)
						{
							point_0 = ((!(Clicks[0].Entity is devDept.Eyeshot.Entities.Point)) ? clsItem.frmEditor.viewport.CurrentSketch.AddPoint(Clicks[0].Position) : ((devDept.Eyeshot.Entities.Point)Clicks[0].Entity));
							return;
						}
						point_0 = new devDept.Eyeshot.Entities.Point(Clicks[0].Position.X, Clicks[0].Position.Y);
					}
					if (!buCompare5.EQ(Clicks[0].Position, Clicks[Clicks.Count - 1].Position, 0.5))
					{
						clsInit.appEditor.AddSpline(point_0, Clicks);
					}
					else
					{
						Clicks[Clicks.Count - 1].Position = new Point2D(Clicks[0].Position.X, Clicks[0].Position.Y);
						if (Clicks.Last().Position == point_0.Position)
						{
							clsInit.appEditor.AddSpline(point_0, Clicks);
						}
					}
				}
				if ((clsInit.appEditor.action == actionTypeBU.eventAlingLeft) | (clsInit.appEditor.action == actionTypeBU.eventAlingRight) | (clsInit.appEditor.action == actionTypeBU.eventAlingTop) | (clsInit.appEditor.action == actionTypeBU.eventAlingBottom) | (clsInit.appEditor.action == actionTypeBU.eventAlingHorizontal) | (clsInit.appEditor.action == actionTypeBU.eventAlingVertical))
				{
					clsInit.appEditor.Align();
				}
				if ((clsInit.appEditor.action == actionTypeBU.eventEqualHorizontal) | (clsInit.appEditor.action == actionTypeBU.eventEqualVertical))
				{
					clsInit.appEditor.EqualDistanceEvent((double)clsItem.frmEditor.spn_value.Value);
				}
				if (clsInit.appEditor.action == actionTypeBU.eventRotateValue)
				{
					clsInit.appEditor.Rotate(clsVar.varEditorRuntimeSet.LastRotateAngle);
				}
				if (clsInit.appEditor.action == actionTypeBU.eventMirrorValue)
				{
					clsInit.appEditor.Mirror(clsVar.varEditorRuntimeSet.LastMirrorType);
				}
				if (clsInit.appEditor.action == actionTypeBU.eventTurnOver)
				{
					clsInit.appEditor.TurnOver();
				}
				rightClickCnt++;
				int num5 = 1;
				if ((clsInit.appEditor.action != actionTypeBU.None) & selectionProcess)
				{
					num5 = 2;
				}
				if (rightClickCnt >= num5)
				{
					clsInit.appEditor.Reset();
					Clicks.Clear();
					entitiesSelected.Clear();
					selectedIndex.Clear();
					entitySelected = null;
					clsInit.appEditor.action = actionTypeBU.None;
					base.ActionMode = actionType.None;
					isDrawing = false;
				}
			}
			base.OnMouseDown(mea);
		}
		catch (Exception)
		{
		}
	}

	public void MouseDownDrawings(Entity ent, MouseEventArgs mea)
	{
		if (clsInit.appEditor.action == actionTypeBU.drawPoint)
		{
			if (ent == null)
			{
				if (!clsVar.varEditorRuntimeSet.isSketchMode)
				{
					clsInit.appEditor.AddPoint(Clicks[Clicks.Count - 1]);
				}
			}
			else if (Clicks.Count == 1)
			{
				clsInit.appEditor.AddPoint(Clicks[Clicks.Count - 1]);
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.drawLine)
		{
			if (Clicks.Count >= 1)
			{
				OrthoPossible = true;
			}
			if (Clicks.Count != 2)
			{
				if (Clicks.Count > 2)
				{
					if (!clsVar.varEditorRuntimeSet.isSketchMode)
					{
						clsInit.appEditor.AddLine(Clicks[Clicks.Count - 2], Clicks[Clicks.Count - 1]);
					}
					else
					{
						Clicks[Clicks.Count - 1].Entity = clsInit.appEditor.ExtendLine((Line)Clicks[Clicks.Count - 2].Entity, Clicks[Clicks.Count - 1]);
					}
				}
			}
			else
			{
				Clicks[Clicks.Count - 1].Entity = clsInit.appEditor.AddLine(Clicks[Clicks.Count - 2], Clicks[Clicks.Count - 1]);
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.drawCircle)
		{
			if (Clicks.Count >= 1)
			{
				OrthoPossible = true;
			}
			if (Clicks.Count >= 2)
			{
				Clicks[Clicks.Count - 1].Entity = clsInit.appEditor.AddCircle(Clicks[Clicks.Count - 2], Clicks[Clicks.Count - 1]);
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.drawCircle3Point)
		{
			if (Clicks.Count >= 1)
			{
				OrthoPossible = true;
			}
			if (Clicks.Count >= 2)
			{
				OrthoPossible = false;
			}
			if (Clicks.Count >= 3)
			{
				clsInit.appEditor.AddCircle(Clicks[Clicks.Count - 3], Clicks[Clicks.Count - 2], Clicks[Clicks.Count - 1]);
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.drawArc3PointSEM)
		{
			if (Clicks.Count >= 1)
			{
				OrthoPossible = true;
			}
			if (Clicks.Count >= 2)
			{
				OrthoPossible = false;
			}
			if (Clicks.Count >= 3)
			{
				Clicks[Clicks.Count - 1].Entity = clsInit.appEditor.AddArc(Clicks[Clicks.Count - 3], Clicks[Clicks.Count - 1], Clicks[Clicks.Count - 2]);
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.drawRectangle && Clicks.Count == 2)
		{
			clsInit.appEditor.AddRectangle(Clicks[Clicks.Count - 2], Clicks[Clicks.Count - 1]);
		}
		if (clsInit.appEditor.action == actionTypeBU.drawEllipse && Clicks.Count == 2)
		{
			clsInit.appEditor.AddEllipse(Clicks[Clicks.Count - 2], Clicks[Clicks.Count - 1]);
		}
		if (clsInit.appEditor.action == actionTypeBU.drawPolygon)
		{
			if (Clicks.Count >= 1)
			{
				OrthoPossible = true;
			}
			if (Clicks.Count == 2)
			{
				clsInit.appEditor.AddPolygon(Clicks[Clicks.Count - 2], Clicks[Clicks.Count - 1]);
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.drawKeyHole && Clicks.Count >= 1)
		{
			clsInit.appEditor.AddKeyHole(Clicks[Clicks.Count - 1]);
		}
		if (clsInit.appEditor.action == actionTypeBU.drawSlot)
		{
			if (Clicks.Count >= 1)
			{
				OrthoPossible = true;
			}
			if (Clicks.Count >= 2)
			{
				OrthoPossible = false;
			}
			if (Clicks.Count == 3)
			{
				clsInit.appEditor.AddSLot(Clicks[Clicks.Count - 3], Clicks[Clicks.Count - 2], Clicks[Clicks.Count - 1]);
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.drawSpline)
		{
			if (Clicks.Count == 1)
			{
				if (clsVar.varEditorRuntimeSet.isSketchMode)
				{
					point_0 = ((!(Clicks[0].Entity is devDept.Eyeshot.Entities.Point)) ? clsItem.frmEditor.viewport.CurrentSketch.AddPoint(Clicks[0].Position) : ((devDept.Eyeshot.Entities.Point)Clicks[0].Entity));
					return;
				}
				point_0 = new devDept.Eyeshot.Entities.Point(Clicks[0].Position.X, Clicks[0].Position.Y);
			}
			if (buCompare5.EQ(Clicks[0].Position, Clicks[Clicks.Count - 1].Position, 0.5))
			{
				Clicks[Clicks.Count - 1].Position = new Point2D(Clicks[0].Position.X, Clicks[0].Position.Y);
				if (Clicks.Last().Position == point_0.Position)
				{
					clsInit.appEditor.AddSpline(point_0, Clicks);
				}
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.drawMeasure)
		{
			if (Clicks.Count >= 1)
			{
				OrthoPossible = true;
			}
			if (Clicks.Count >= 2)
			{
				Clicks.RemoveAt(0);
			}
		}
	}

	public void MouseDownEvents(int[] indx, MouseEventArgs mea)
	{
		if (clsInit.appEditor.action == actionTypeBU.eventMove)
		{
			if (Clicks.Count != 1)
			{
				if (Clicks.Count == 2)
				{
					clsInit.appEditor.UndoBuffer();
					foreach (Entity item in entitiesSelected)
					{
						Vector3D v = new Vector3D(Clicks[0].Pnt3D, Clicks[1].Pnt3D);
						item.Translate(v);
					}
					clsItem.frmEditor.viewport.Entities.Regen();
					clsInit.appEditor.Reset();
					return;
				}
			}
			else
			{
				clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[1], buLangTranslate.preDef.Move);
				OrthoPossible = true;
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.eventCopy)
		{
			if (Clicks.Count != 1)
			{
				if (Clicks.Count == 2)
				{
					clsInit.appEditor.UndoBuffer();
					List<Entity> list = null;
					if (clsVar.varEditorRuntimeSet.isSewingMode)
					{
						list = new List<Entity>();
					}
					foreach (Entity item2 in entitiesSelected)
					{
						Entity copiedEntity = null;
						buEntity.Copy(item2, ref copiedEntity);
						if (copiedEntity != null)
						{
							Vector3D v2 = new Vector3D(Clicks[0].Pnt3D, Clicks[1].Pnt3D);
							copiedEntity.Translate(v2);
							copiedEntity.ColorMethod = colorMethodType.byEntity;
							copiedEntity.Color = clsVar.varEditorSet.colorEntity;
							copiedEntity.LineWeight = (float)clsVar.varEditorSet.thicknessEntity;
							copiedEntity.LineWeightMethod = colorMethodType.byEntity;
							if (clsVar.varEditorRuntimeSet.isSewingMode)
							{
								Entity copiedEntity2 = null;
								buEntity.Copy(copiedEntity, ref copiedEntity2);
								list.Add(copiedEntity2);
							}
							clsItem.frmEditor.viewport.Entities.Add(copiedEntity);
						}
					}
					clsItem.frmEditor.viewport.Entities.Regen();
					clsInit.appEditor.Reset();
					if (clsVar.varEditorRuntimeSet.isSewingMode && clsInit.appSewing != null && list != null)
					{
						clsInit.appSewing.doAddEntities(list);
					}
					return;
				}
			}
			else
			{
				clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[1], buLangTranslate.preDef.Copy);
				OrthoPossible = true;
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.eventMirror)
		{
			if (Clicks.Count != 1)
			{
				if (Clicks.Count == 2)
				{
					List<Entity> list2 = new List<Entity>();
					clsInit.appEditor.UndoBuffer();
					foreach (Entity item3 in entitiesSelected)
					{
						if (!(Clicks[1].Pnt3D.X >= Clicks[0].Pnt3D.X) || Clicks[1].Pnt3D.Y < Clicks[0].Pnt3D.Y)
						{
							Point3D first = Clicks[0].Pnt3D;
							Point3D second = Clicks[1].Pnt3D;
							Utility.Swap(ref first, ref second);
							Clicks[0].Pnt3D = first;
							Clicks[1].Pnt3D = second;
						}
						Vector3D vector3D = new Vector3D(Clicks[0].Pnt3D, Clicks[1].Pnt3D);
						Plane plane = new Plane(Clicks[0].Pnt3D, vector3D, Vector3D.AxisZ);
						Entity entity = (Entity)item3.Clone();
						Mirror xform = new Mirror(plane);
						entity.TransformBy(xform);
						entity.ColorMethod = colorMethodType.byEntity;
						entity.Color = clsVar.varEditorSet.colorEntity;
						entity.LineWeight = (float)clsVar.varEditorSet.thicknessEntity;
						entity.LineWeightMethod = colorMethodType.byEntity;
						list2.Add(entity);
					}
					clsItem.frmEditor.viewport.Entities.DeleteSelected();
					for (int i = 0; i <= list2.Count - 1; i++)
					{
						clsItem.frmEditor.viewport.Entities.Add(list2[i]);
					}
					clsItem.frmEditor.viewport.Entities.Regen();
					clsInit.appEditor.Reset();
					return;
				}
			}
			else
			{
				clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[122], buLangTranslate.preDef.Mirror);
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.eventOffset)
		{
			clsInit.appEditor.UndoBuffer();
			foreach (Entity item4 in entitiesSelected)
			{
				Entity selEntity = (Entity)item4.Clone();
				Entity entityOffseted = null;
				if (!clsInit.appEditor.Offset(selEntity, mouseWorldLoc, ref entityOffseted))
				{
					return;
				}
				if (entityOffseted != null)
				{
					entityOffseted.ColorMethod = colorMethodType.byEntity;
					entityOffseted.Color = clsVar.varEditorSet.colorEntity;
					entityOffseted.LineWeight = (float)clsVar.varEditorSet.thicknessEntity;
					entityOffseted.LineWeightMethod = colorMethodType.byEntity;
					if (clsInit.appSewing == null)
					{
						clsItem.frmEditor.viewport.Entities.Add(entityOffseted);
						clsItem.frmEditor.viewport.Entities.Regen();
						clsInit.appEditor.Reset();
						clsInit.appEditor.cmdEventsOffset();
					}
					else
					{
						clsInit.appSewing.doOffset(entityOffseted);
					}
					return;
				}
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.eventRotate)
		{
			if (Clicks.Count != 1)
			{
				if (Clicks.Count != 2)
				{
					if (Clicks.Count == 3)
					{
						double double_ = 0.0;
						clsInit.appEditor.UndoBuffer();
						method_3(ref double_);
						foreach (Entity item5 in entitiesSelected)
						{
							Entity entity2 = item5;
							entity2.Rotate(double_, Vector3D.AxisZ, Clicks[0].Pnt3D);
							if (entity2 is Text)
							{
								entity2.Regen(new RegenParams(0.0, this));
							}
						}
						clsItem.frmEditor.viewport.Entities.Regen();
						clsInit.appEditor.Reset();
						return;
					}
				}
				else
				{
					clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[21], buLangTranslate.preDef.Rotate);
					OrthoPossible = false;
				}
			}
			else
			{
				clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[21], buLangTranslate.preDef.Rotate);
				OrthoPossible = true;
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.eventBreak && ((entityMouseUnder != null) & (indx.Length != 0)))
		{
			clsInit.appEditor.UndoBuffer();
			if ((entityMouseUnder is Entity) & (indx[0] >= 0) & (indx[0] <= base.Entities.Count - 1))
			{
				Entity entityFirst = null;
				Entity entitySecond = null;
				clsInit.appEditor.Break((Entity)entityMouseUnder, mouseWorldLoc, ref entityFirst, ref entitySecond);
				if (entityFirst != null && entitySecond != null)
				{
					base.Entities.RemoveAt(indx[0]);
					entityFirst.ColorMethod = colorMethodType.byEntity;
					entityFirst.Color = clsVar.varEditorSet.colorEntity;
					entityFirst.LineWeight = (float)clsVar.varEditorSet.thicknessEntity;
					entityFirst.LineWeightMethod = colorMethodType.byEntity;
					entitySecond.ColorMethod = colorMethodType.byEntity;
					entitySecond.Color = clsVar.varEditorSet.colorEntity;
					entitySecond.LineWeight = (float)clsVar.varEditorSet.thicknessEntity;
					entitySecond.LineWeightMethod = colorMethodType.byEntity;
					base.Entities.Add(entityFirst);
					base.Entities.Add(entitySecond);
					clsItem.frmEditor.viewport.Entities.Regen();
					clsInit.appEditor.Reset();
					clsInit.appEditor.cmdEventsBreak();
					return;
				}
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.eventScale)
		{
			if (Clicks.Count != 1)
			{
				if (Clicks.Count != 2)
				{
					if (Clicks.Count == 3)
					{
						double num = Clicks[0].Pnt3D.DistanceTo(Clicks[1].Pnt3D);
						if (num > 0.0)
						{
							clsInit.appEditor.UndoBuffer();
							double num2 = Clicks[0].Pnt3D.DistanceTo(mouseWorldLoc) / Clicks[0].Pnt3D.DistanceTo(Clicks[1].Pnt3D);
							foreach (Entity item6 in entitiesSelected)
							{
								Entity entity3 = item6;
								if (num2 >= 0.01)
								{
									entity3.Scale(Clicks[0].Pnt3D, num2);
								}
							}
							clsItem.frmEditor.viewport.Entities.Regen();
							clsInit.appEditor.Reset();
							return;
						}
					}
				}
				else
				{
					clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[32], buLangTranslate.preDef.Scale);
				}
			}
			else
			{
				clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[32], buLangTranslate.preDef.Scale);
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.eventExtend && ((entityMouseUnder != null) & (int_0.Length >= 0)) && ((entityMouseUnder is Entity) & (int_0[0] >= 0) & (int_0[0] <= base.Entities.Count - 1)))
		{
			Entity entityExtended = null;
			clsInit.appCommand.Extend(clsItem.frmEditor.viewport.Entities, int_0[0], mouseWorldLoc, clsVar.varEditorRuntimeSet.ExtendLength, ref entityExtended);
			if (entityExtended != null)
			{
				clsInit.appEditor.UndoBuffer();
				base.Entities.RemoveAt(int_0[0]);
				entityExtended.ColorMethod = colorMethodType.byEntity;
				entityExtended.Color = clsVar.varEditorSet.colorEntity;
				entityExtended.LineWeight = (float)clsVar.varEditorSet.thicknessEntity;
				entityExtended.LineWeightMethod = colorMethodType.byEntity;
				base.Entities.Add(entityExtended);
				clsItem.frmEditor.viewport.Entities.Regen();
				clsInit.appEditor.Reset();
				clsInit.appEditor.cmdEventsExtend();
				return;
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.eventTrim)
		{
			int entityUnderMouseCursor = GetEntityUnderMouseCursor(mea.Location);
			if (entityUnderMouseCursor == -1)
			{
				return;
			}
			Entity entity4 = base.Entities[entityUnderMouseCursor];
			if (entity4 == null)
			{
				return;
			}
			clsInit.appEditor.UndoBuffer();
			if (!Utility.Trim(this, mea.Location, out var leftOverEntities))
			{
				base.Entities.Remove(entity4);
			}
			else
			{
				base.Entities.AddRange(leftOverEntities);
			}
			base.Entities.Regen();
		}
		if (clsInit.appEditor.action == actionTypeBU.eventFillet)
		{
			method_1();
		}
		if (clsInit.appEditor.action == actionTypeBU.eventChamfer)
		{
			method_2();
		}
	}

	protected override void OnMouseUp(MouseEventArgs mea)
	{
		int[] selectedIndices = null;
		int_1 = -1;
		if (selectionProcess & (mea.Button == MouseButtons.Left) & buttonPressedForSelection)
		{
			new List<int>();
			new List<int>();
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
				int num = mea.Location.X - mouseDownLocation.X;
				int num2 = mea.Location.Y - mouseDownLocation.Y;
				System.Drawing.Point location = mouseDownLocation;
				System.Drawing.Point location2 = mea.Location;
				if (location.X > location2.X)
				{
					int num3 = location.X;
					location.X = location2.X;
					location2.X = num3;
				}
				if (location.Y > location2.Y)
				{
					int num4 = location.Y;
					location.Y = location2.Y;
					location2.Y = num4;
				}
				switch (currPickState)
				{
				case pickStateType.Pick:
				{
					int_1 = GetEntityUnderMouseCursor(mea.Location);
					int[] allEntitiesUnderMouseCursor = GetAllEntitiesUnderMouseCursor(mea.Location);
					bool flag = (Control.ModifierKeys & Keys.Control) == Keys.Control;
					if (int_1 >= 0 && int_1 < base.Entities.Count && base.Entities[int_1].Selectable)
					{
						Entity entity = base.Entities[int_1];
						if (flag)
						{
							entity.Selected = !entity.Selected;
						}
						else
						{
							for (int k = 0; k < base.Entities.Count; k++)
							{
								base.Entities[k].Selected = false;
							}
							entity.Selected = true;
						}
					}
					if (clsInit.appEditor.action == actionTypeBU.sewingMove && clsInit.appSewing != null)
					{
						clsInit.appSewing.doDefineMove();
					}
					if (clsInit.appEditor.action == actionTypeBU.sewingChangeStitchLen && clsInit.appSewing != null)
					{
						entitiesSelected.Clear();
						clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, Clone: false, ref entitiesSelected);
						clsInit.appSewing.cmdChangeStitchLength(entitiesSelected, clsSewing.varSewingRunSettings.ShowDialog);
					}
					if (clsInit.appEditor.action == actionTypeBU.sewingStitchToJump && clsInit.appSewing != null)
					{
						clsInit.appSewing.cmdStitchToJump();
					}
					if (clsInit.appEditor.action == actionTypeBU.sewingJumpToStitch && clsInit.appSewing != null)
					{
						clsInit.appSewing.cmdJumpToStitch();
					}
					if (clsInit.appEditor.action == actionTypeBU.sewingDelete && clsInit.appSewing != null)
					{
						clsInit.appSewing.doDeleteByQuestion(mouseWorldLoc);
					}
					if ((clsInit.appEditor.action == actionTypeBU.sewingMoveVertex) | (clsInit.appEditor.action == actionTypeBU.sewingFootHeight) | (clsInit.appEditor.action == actionTypeBU.sewingSpeed))
					{
						for (int l = 0; l <= allEntitiesUnderMouseCursor.Length - 1; l++)
						{
							if (!(base.Entities[allEntitiesUnderMouseCursor[l]].GetType() == typeof(devDept.Eyeshot.Entities.Point)))
							{
								base.Entities[allEntitiesUnderMouseCursor[l]].Selected = false;
							}
							else
							{
								base.Entities[allEntitiesUnderMouseCursor[l]].Selected = true;
							}
						}
						if (clsInit.appSewing != null)
						{
							clsInit.appSewing.doDefineSelectVertex(new Point3D(), clsInit.appEditor.action);
						}
					}
					Invalidate();
					break;
				}
				case pickStateType.Enclosed:
				{
					if (num == 0 || num2 == 0)
					{
						break;
					}
					GetEnclosedEntities(new Rectangle(location, new Size(Math.Abs(num), Math.Abs(num2))), firstOnly: false, out selectedIndices);
					if (selectedIndices == null)
					{
						break;
					}
					for (int j = 0; j < selectedIndices.Length; j++)
					{
						if (base.Entities[selectedIndices[j]].Selectable)
						{
							if (base.Entities[selectedIndices[j]].Selected)
							{
								base.Entities[selectedIndices[j]].Selected = false;
							}
							else
							{
								base.Entities[selectedIndices[j]].Selected = true;
							}
						}
					}
					break;
				}
				case pickStateType.Crossing:
				{
					if (num == 0 || num2 == 0)
					{
						break;
					}
					GetCrossingEntities(new Rectangle(location, new Size(Math.Abs(num), Math.Abs(num2))), firstOnly: false, out selectedIndices);
					if (selectedIndices == null)
					{
						break;
					}
					for (int i = 0; i < selectedIndices.Length; i++)
					{
						if (base.Entities[selectedIndices[i]].Selectable)
						{
							if (base.Entities[selectedIndices[i]].Selected)
							{
								base.Entities[selectedIndices[i]].Selected = false;
							}
							else
							{
								base.Entities[selectedIndices[i]].Selected = true;
							}
						}
					}
					break;
				}
				}
				if (mea.Button == MouseButtons.Left)
				{
					bool flag2 = false;
					if (selectedIndices != null)
					{
						if (selectedIndices.Length == 0)
						{
							flag2 = true;
						}
					}
					else
					{
						flag2 = true;
					}
					if ((isAreaSelection && flag2) & (int_1 == -1))
					{
						List<Entity> SortedEntities = new List<Entity>();
						GetChainEntitiesSettings settings = new GetChainEntitiesSettings();
						SelectionOperation SelectionOP = new SelectionOperation();
						List<int> SortedEntitesIndex = new List<int>();
						Entity foundEntity = null;
						double limitDistance = 0.0;
						clsInit.cVector5.GetClosestEntityToRefPoint(base.Entities.ToList(), mouseWorldLoc, ref foundEntity, limitDistance);
						if (foundEntity != null)
						{
							clsInit.cVector5.GetChainEntities(((ICurve)foundEntity).StartPoint, base.Entities.ToList(), new BlockKeyedCollection(), settings, ref SortedEntities, ref SortedEntitesIndex, ref SelectionOP);
							bool flag3 = clsInit.cVector5.isEntitiesClosed(SortedEntities);
							List<Point3D> Points = new List<Point3D>();
							clsInit.cVector5.EntitiesToPointsWithCamDirection(SortedEntities, 0.01, ref Points);
							bool flag4;
							if (!(flag4 = clsInit.cVector5.IsPointInsidePolygon(Points, mouseWorldLoc)))
							{
								for (int num5 = SortedEntitesIndex.Count - 1; num5 >= 0; num5--)
								{
									bool flag5 = false;
									for (int m = 0; m <= selectedIndex.Count - 1; m++)
									{
										for (int n = 0; n <= selectedIndex[m].Count - 1; n++)
										{
											if (selectedIndex[m][n] == SortedEntitesIndex[num5])
											{
												flag5 = true;
											}
										}
									}
									if (!flag5 && ((SortedEntitesIndex[num5] >= 0) & (SortedEntitesIndex[num5] <= base.Entities.Count - 1)))
									{
										base.Entities[SortedEntitesIndex[num5]].Selected = false;
									}
								}
								Invalidate();
								return;
							}
							if (!clsInit.cVector5.isSelectedIndexAvailableInSelectionList(selectedIndex, SortedEntitesIndex) && flag3 && flag4)
							{
								selectedIndex.Add(SortedEntitesIndex);
							}
						}
					}
				}
				Invalidate();
				return;
			}
		}
		if (clsInit.appEditor.action != actionTypeBU.sewingDelete)
		{
			if (clsInit.appEditor.action != actionTypeBU.sewingMove)
			{
				if (clsInit.appEditor.action == actionTypeBU.sewingChangeDirection)
				{
					clsInit.appSewing.doChangeDirection(mouseWorldLoc, clsInit.appEditor.action);
				}
				if (clsInit.appEditor.action == actionTypeBU.eventDelete)
				{
					clsItem.frmEditor.viewport.Entities.DeleteSelected();
					clsItem.frmEditor.viewport.Invalidate();
					clsInit.appEditor.Reset();
				}
				if (((clsInit.appEditor.action == actionTypeBU.eventMove) | (clsInit.appEditor.action == actionTypeBU.eventCopy) | (clsInit.appEditor.action == actionTypeBU.eventOffset) | (clsInit.appEditor.action == actionTypeBU.eventRotate) | (clsInit.appEditor.action == actionTypeBU.eventScale) | (clsInit.appEditor.action == actionTypeBU.eventMirror)) && selectionProcess)
				{
					entitiesSelected.Clear();
					clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, Clone: false, ref entitiesSelected);
					if (entitiesSelected.Count > 0)
					{
						if (clsInit.appEditor.action == actionTypeBU.eventCopy)
						{
							clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[0], buLangTranslate.preDef.Copy);
						}
						if (clsInit.appEditor.action == actionTypeBU.eventMove)
						{
							clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[0], buLangTranslate.preDef.Move);
						}
						if (clsInit.appEditor.action == actionTypeBU.eventOffset)
						{
							clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[33], buLangTranslate.preDef.Move);
						}
						if (clsInit.appEditor.action == actionTypeBU.eventRotate)
						{
							clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[20], buLangTranslate.preDef.Rotate);
						}
						if (clsInit.appEditor.action == actionTypeBU.eventScale)
						{
							clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[31], buLangTranslate.preDef.Scale);
						}
						if (clsInit.appEditor.action == actionTypeBU.eventMirror)
						{
							clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[122], buLangTranslate.preDef.Mirror);
						}
						selectionProcess = false;
					}
				}
				if (bool_1)
				{
					base.CurrentSketch.DragEnd();
					bool_1 = false;
				}
				base.OnMouseUp(mea);
			}
			else if (clsInit.appSewing != null)
			{
				clsInit.appSewing.doDefineMove();
			}
		}
		else if (clsInit.appSewing != null)
		{
			clsInit.appSewing.doDelete();
		}
	}

	protected override void DrawOverlay(DrawSceneParams data)
	{
		if (!FirstMove)
		{
			if (base.Entities.Count > 0 && base.Entities[0] is CompositeCurve)
			{
				base.Entities.RemoveAt(0);
			}
			FirstMove = true;
		}
		if (IsDesignMode())
		{
			return;
		}
		Point3D intPoint = null;
		Point3D intPoint2 = null;
		ScreenToPlane(new System.Drawing.Point(1, 1), Plane.XY, out intPoint);
		ScreenToPlane(new System.Drawing.Point(2, 2), Plane.XY, out intPoint2);
		if ((intPoint != null) & (intPoint2 != null))
		{
			PixelVsMilimeter = Point3D.Distance(intPoint, intPoint2);
		}
		if ((entityMouseUnder != null) & (entityMouseUnder is ICurve))
		{
			method_6((ICurve)entityMouseUnder, bool_2: false, Color.Red, 2f);
		}
		if (buttonPressedForSelection)
		{
			if (currPickState != pickStateType.Crossing)
			{
				if (currPickState == pickStateType.Enclosed)
				{
					method_0(mouseDownLocation, mouseloc, clsVar.varSelection.colorSelectionRightToLeft, clsVar.varSelection.SelectionTransparancy, bool_2: true, bool_3: false);
				}
			}
			else
			{
				method_0(mouseDownLocation, mouseloc, clsVar.varSelection.colorSelectionLeftToRight, clsVar.varSelection.SelectionTransparancy, bool_2: true, bool_3: true);
			}
		}
		base.RenderContext.SetColorWireframe(Color.Black);
		base.RenderContext.SetLineSize(2f);
		if (clsInit.appEditor.action == actionTypeBU.drawLine && Clicks.Count > 0)
		{
			Draw(new Line(Plane.XY, Clicks.Last().Position, mousePlnLoc));
		}
		if (clsInit.appEditor.action == actionTypeBU.drawCircle && Clicks.Count > 0)
		{
			double num = Point2D.Distance(Clicks.Last().Position, mousePlnLoc);
			if (num > 0.0)
			{
				if (base.CurrentSketch == null)
				{
					Draw(new Circle(Plane.XY, Clicks.Last().Position, num));
				}
				else
				{
					Draw(new Circle(base.CurrentSketch.DrawingPlane, Clicks.Last().Position, num));
				}
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.drawCircle3Point)
		{
			int num2 = ((Clicks.Count >= 3) ? ((Clicks.Count - 3) % 2 + 1) : Clicks.Count);
			if (Clicks.Count == 1 || Clicks.Count == 2)
			{
				if (base.CurrentSketch == null)
				{
					Draw(new devDept.Eyeshot.Entities.Point(Plane.XY, Clicks[0].Position), 8f);
				}
				else
				{
					Draw(new devDept.Eyeshot.Entities.Point(base.CurrentSketch.DrawingPlane, Clicks[0].Position), 8f);
				}
			}
			if (num2 != 1)
			{
				try
				{
					if (Clicks.Count >= 2)
					{
						Point2D position = Clicks[Clicks.Count - 2].Position;
						Point2D position2 = Clicks[Clicks.Count - 1].Position;
						if (base.CurrentSketch == null)
						{
							Draw(new devDept.Eyeshot.Entities.Point(Plane.XY, position2), 8f);
						}
						else
						{
							Draw(new devDept.Eyeshot.Entities.Point(base.CurrentSketch.DrawingPlane, position2), 8f);
						}
						if (!clsInit.appEditor.EvaluateArc(position, mousePlnLoc, position2, out var _))
						{
							if (base.CurrentSketch == null)
							{
								Draw(new Line(Plane.XY, position, mousePlnLoc));
							}
							else
							{
								Draw(new Line(base.CurrentSketch.DrawingPlane, position, mousePlnLoc));
							}
						}
						else
						{
							Draw(new Circle(Plane.XY, position, mousePlnLoc, position2));
						}
					}
				}
				catch
				{
				}
			}
			else if (base.CurrentSketch == null)
			{
				Draw(new Line(Plane.XY, Clicks.Last().Position, mousePlnLoc));
			}
			else
			{
				Draw(new Line(base.CurrentSketch.DrawingPlane, Clicks.Last().Position, mousePlnLoc));
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.drawArc3PointSEM)
		{
			int num3 = ((Clicks.Count >= 3) ? ((Clicks.Count - 3) % 2 + 1) : Clicks.Count);
			if (Clicks.Count == 1 || Clicks.Count == 2)
			{
				Draw(new devDept.Eyeshot.Entities.Point(Plane.XY, Clicks[0].Position), 8f);
			}
			if (num3 != 1)
			{
				try
				{
					if (Clicks.Count >= 2)
					{
						Point2D position3 = Clicks[Clicks.Count - 2].Position;
						Point2D position4 = Clicks[Clicks.Count - 1].Position;
						Draw(new devDept.Eyeshot.Entities.Point(Plane.XY, position4), 8f);
						if (!clsInit.appEditor.EvaluateArc(position3, mousePlnLoc, position4, out var flip2))
						{
							Draw(new Line(Plane.XY, position3, mousePlnLoc));
						}
						else
						{
							Draw(new Arc(Plane.XY, position3, mousePlnLoc, position4, flip2));
						}
					}
				}
				catch
				{
				}
			}
			else
			{
				Draw(new Line(Plane.XY, Clicks.Last().Position, mousePlnLoc));
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.drawRectangle && Clicks.Count > 0)
		{
			Point2D position5 = Clicks.First().Position;
			Draw(new Line(Plane.XY, position5.X, position5.Y, mousePlnLoc.X, position5.Y));
			Draw(new Line(Plane.XY, mousePlnLoc.X, position5.Y, mousePlnLoc.X, mousePlnLoc.Y));
			Draw(new Line(Plane.XY, mousePlnLoc.X, mousePlnLoc.Y, position5.X, mousePlnLoc.Y));
			Draw(new Line(Plane.XY, position5.X, mousePlnLoc.Y, position5.X, position5.Y));
		}
		if (clsInit.appEditor.action == actionTypeBU.drawEllipse && Clicks.Count > 0)
		{
			Point2D position6 = Clicks.First().Position;
			double num4 = position6.DistanceTo(new Point3D(mousePlnLoc.X, position6.Y));
			double num5 = position6.DistanceTo(new Point3D(position6.X, mousePlnLoc.Y));
			if (!(num4 <= 0.001) && num5 > 0.001)
			{
				Draw(new Ellipse(Plane.XY, position6, num4, num5));
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.drawPolygon && Clicks.Count > 0)
		{
			LinearPath lp = null;
			clsInit.appEditor.DrawPolygon(Clicks[0].Position, mousePlnLoc, ref lp);
			if (lp != null)
			{
				Draw(lp);
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.drawKeyHole)
		{
			buArc HeadArc = new buArc();
			buArc TaleArc = new buArc();
			buLine FirstLine = new buLine();
			buLine SecondLine = new buLine();
			clsInit.cVector5.KeyHole(new Point3D(mousePlnLoc.X, mousePlnLoc.Y), clsVar.varEditorRuntimeSet.KeyHoleHeadDiameter / 2.0, clsVar.varEditorRuntimeSet.KeyHoleWidth / 2.0, clsVar.varEditorRuntimeSet.KeyHoleLength, clsVar.varEditorRuntimeSet.KeyHoleAngle, Reverse: false, Plane.XY, ref HeadArc, ref TaleArc, ref FirstLine, ref SecondLine);
			List<buEntity> RefEntities = new List<buEntity>();
			if (HeadArc.Vertices.Count > 0)
			{
				RefEntities.Add(HeadArc);
			}
			if (FirstLine.Vertices.Count > 0)
			{
				RefEntities.Add(FirstLine);
			}
			if (TaleArc.Vertices.Count > 0)
			{
				RefEntities.Add(TaleArc);
			}
			if (SecondLine.Vertices.Count > 0)
			{
				RefEntities.Add(SecondLine);
			}
			clsInit.cVector5.SplitArcEntitiesIfGreaterThen180Degree(ref RefEntities, 150.0);
			buCompositeCurve calcCompositeCurve = null;
			clsInit.cVector5.CreateCompositeCurveFromEntities(RefEntities, ref calcCompositeCurve);
			Entity copiedEntity = null;
			buEntity.Copy(calcCompositeCurve, ref copiedEntity);
			if (copiedEntity != null)
			{
				Draw((ICurve)copiedEntity);
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.drawSlot)
		{
			if (Clicks.Count == 1)
			{
				Draw(new Line(Plane.XY, Clicks.First().Position, mousePlnLoc));
			}
			if (Clicks.Count == 2 && Clicks[1].Position.DistanceTo(mousePlnLoc) > 0.0)
			{
				CompositeCurve curve = clsInit.appEditor.ThreePointsSlot(Clicks[0].Position, Clicks[1].Position, mousePlnLoc);
				Draw(curve);
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.drawSpline)
		{
			if (!clsVar.varEditorRuntimeSet.isSketchMode)
			{
				if (Clicks.Count <= 1)
				{
					if (Clicks.Count == 1)
					{
						Draw(new Line(Plane.XY, Clicks[0].Position, mousePlnLoc));
					}
				}
				else
				{
					List<Point3D> list = new List<Point3D>();
					for (int i = 0; i <= Clicks.Count - 1; i++)
					{
						list.Add(new Point3D(Clicks[i].Position.X, Clicks[i].Position.Y, 0.0));
					}
					list.Add(mouseWorldLoc);
					Curve curve2 = null;
					if (list.Count != 2)
					{
						if (buCompare5.EQ(list[0], list[list.Count - 1], 0.5))
						{
							list[list.Count - 1] = list[0];
						}
						curve2 = Curve.CubicSplineInterpolation(list);
					}
					else
					{
						Line curve3 = new Line(Plane.XY, list[0], list[1]);
						Draw(curve3);
					}
					if (curve2 != null)
					{
						Draw(curve2);
						List<Point4D> list2 = ControlPoints(curve2);
						foreach (Point4D item in list2)
						{
							Draw(new devDept.Eyeshot.Entities.Point(item), 3f);
						}
						for (int j = 0; j < list2.Count - 1; j += 2)
						{
							Draw(new Line(list2[j], list2[j + 1]), 1f, Color.Gray);
						}
					}
				}
				foreach (UClick click in Clicks)
				{
					Draw(new devDept.Eyeshot.Entities.Point(Plane.XY, click.Position), 8f);
				}
			}
			else
			{
				if (Clicks.Count <= 1)
				{
					if (Clicks.Count == 1)
					{
						Draw(new Line(Plane.XY, Clicks[0].Position, mousePlnLoc));
					}
				}
				else
				{
					List<Point3D> list3 = Class5.smethod_172(this);
					list3.Add(mouseWorldLoc);
					Curve curve4 = ((Clicks.Count == 2 && mouseWorldLoc == point_0.Position) ? clsInit.appEditor.InterpolateTwoPoints(Clicks[0], Clicks[1]) : Curve.CubicSplineInterpolation(list3));
					Draw(curve4);
					List<Point4D> list4 = ControlPoints(curve4);
					foreach (Point4D item2 in list4)
					{
						Draw(new devDept.Eyeshot.Entities.Point(item2), 3f);
					}
					for (int k = 0; k < list4.Count - 1; k += 2)
					{
						Draw(new Line(list4[k], list4[k + 1]), 1f, Color.Gray);
					}
				}
				foreach (UClick click2 in Clicks)
				{
					Draw(new devDept.Eyeshot.Entities.Point(Plane.XY, click2.Position), 8f);
				}
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.drawMeasure && Clicks.Count > 0)
		{
			Draw(new Line(Plane.XY, Clicks.Last().Position, mousePlnLoc));
			if (Clicks.Count >= 1)
			{
				int num6 = (int)WorldToScreen(mousePlnLoc.X, mousePlnLoc.Y, 0.0).X;
				int num7 = (int)WorldToScreen(mousePlnLoc.X, mousePlnLoc.Y, 0.0).Y;
				double num8 = clsInit.cVector5.PointAngle(mouseWorldLoc, new Point3D(Clicks[Clicks.Count - 1].Position.X, Clicks[Clicks.Count - 1].Position.Y));
				string text = buLangTranslate.preDef.Length + ": " + Point2D.Distance(Clicks[Clicks.Count - 1].Position, new Point2D(mousePlnLoc.X, mousePlnLoc.Y)).ToString("f2");
				text = text + " - " + buLangTranslate.preDef.Angle + ": " + num8.ToString("f2");
				double num9 = mousePlnLoc.Y - Clicks[Clicks.Count - 1].Position.Y;
				int num10 = 10;
				if (num9 < 0.0)
				{
					num10 = -10;
				}
				DrawText(num6, num7 + num10, text, new Font("Arial", (float)clsVar.varView.DynamicTextSize), Color.Black, ContentAlignment.MiddleLeft);
			}
		}
		if (((clsInit.appEditor.action == actionTypeBU.eventMove) | (clsInit.appEditor.action == actionTypeBU.eventCopy)) && Clicks.Count == 1)
		{
			foreach (Entity item3 in entitiesSelected)
			{
				Entity entity = (Entity)item3.Clone();
				Vector3D v = new Vector3D(Clicks[0].Pnt3D, mouseWorldLoc);
				entity.Translate(v);
				if (entity is Text)
				{
					entity.Regen(new RegenParams(0.0, this));
				}
				Draw((ICurve)entity);
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.eventMirror && Clicks.Count == 1)
		{
			foreach (Entity item4 in entitiesSelected)
			{
				Point3D point3D = buVector5.ToPoint3D(Clicks[0].Pnt3D);
				Point3D point3D2 = buVector5.ToPoint3D(mouseWorldLoc);
				if (!(point3D2.X >= point3D.X) || point3D2.Y < point3D.Y)
				{
					Point3D first = point3D;
					Point3D second = point3D2;
					Utility.Swap(ref first, ref second);
					point3D = first;
					point3D2 = second;
				}
				if (Point3D.Distance(point3D, point3D2) > 0.01)
				{
					Vector3D vector3D = new Vector3D(point3D, point3D2);
					Plane plane = new Plane(point3D, vector3D, Vector3D.AxisZ);
					Entity entity2 = (Entity)item4.Clone();
					Mirror xform = new Mirror(plane);
					entity2.TransformBy(xform);
					Draw((ICurve)entity2);
				}
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.eventOffset)
		{
			foreach (Entity item5 in entitiesSelected)
			{
				Entity selEntity = (Entity)item5.Clone();
				Entity entityOffseted = null;
				if (clsInit.appEditor.Offset(selEntity, mouseWorldLoc, ref entityOffseted))
				{
					Draw((ICurve)entityOffseted);
					continue;
				}
				return;
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.eventRotate)
		{
			if (Clicks.Count != 1)
			{
				if (Clicks.Count == 2)
				{
					double double_ = 0.0;
					method_3(ref double_);
					foreach (Entity item6 in entitiesSelected)
					{
						Entity entity3 = (Entity)item6.Clone();
						entity3.Rotate(double_, Vector3D.AxisZ, Clicks[0].Pnt3D);
						if (entity3 is Text)
						{
							entity3.Regen(new RegenParams(0.0, this));
						}
						Draw((ICurve)entity3);
					}
				}
			}
			else
			{
				Entity entity4 = new Line(Clicks[0].Pnt3D, mouseWorldLoc);
				Draw((ICurve)entity4);
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.eventBreak && entityMouseUnder != null && entityMouseUnder is Entity)
		{
			Entity entityFirst = null;
			Entity entitySecond = null;
			clsInit.appEditor.Break((Entity)entityMouseUnder, mouseWorldLoc, ref entityFirst, ref entitySecond);
			if (entityFirst != null && entitySecond != null)
			{
				Draw((ICurve)entityFirst, 3f, Color.Blue);
				Draw((ICurve)entitySecond, 3f, Color.Cyan);
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.eventScale)
		{
			if (Clicks.Count != 1)
			{
				if (Clicks.Count == 2)
				{
					Entity entity5 = new Line(Clicks[0].Pnt3D, Clicks[1].Pnt3D);
					Draw((ICurve)entity5);
					entity5 = new Line(Clicks[0].Pnt3D, mouseWorldLoc);
					Draw((ICurve)entity5);
					double num11 = Clicks[0].Pnt3D.DistanceTo(Clicks[1].Pnt3D);
					if (num11 > 0.0)
					{
						double num12 = Clicks[0].Pnt3D.DistanceTo(mouseWorldLoc) / num11;
						foreach (Entity item7 in entitiesSelected)
						{
							Entity entity6 = (Entity)item7.Clone();
							if (num12 >= 0.01)
							{
								entity6.Scale(Clicks[0].Pnt3D, num12);
								Draw((ICurve)entity6);
							}
						}
					}
				}
			}
			else
			{
				Entity entity7 = new Line(Clicks[0].Pnt3D, mouseWorldLoc);
				Draw((ICurve)entity7);
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.eventExtend && ((entityMouseUnder != null) & (int_0.Length >= 0)) && ((entityMouseUnder is Entity) & (int_0[0] >= 0) & (int_0[0] <= base.Entities.Count - 1)))
		{
			Entity entityExtended = null;
			clsInit.appCommand.Extend(clsItem.frmEditor.viewport.Entities, int_0[0], mouseWorldLoc, clsVar.varEditorRuntimeSet.ExtendLength, ref entityExtended);
			if (entityExtended != null)
			{
				Draw((ICurve)entityExtended, 3f, Color.Blue);
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.eventTrim)
		{
			method_5();
		}
		if (clsInit.appEditor.action == actionTypeBU.libraryLength && entitySelected != null)
		{
			UtilityEx.DrawLinearDimPreview(clsItem.frmEditor.viewport, clsItem.frmEditor.viewport.CurrentSketch.Plane, (Line)entitySelected, mouseloc, PreviewDrawParams);
			isSelectionDone = true;
		}
		if (clsInit.appEditor.action == actionTypeBU.libraryRadius && entitySelected != null)
		{
			if (!(entitySelected.GetType() == typeof(Arc)))
			{
				if (entitySelected.GetType() == typeof(Circle))
				{
					UtilityEx.DrawDiametricDimPreview(clsItem.frmEditor.viewport, clsItem.frmEditor.viewport.CurrentSketch.Plane, (Circle)entitySelected, mouseloc, PreviewDrawParams);
					isSelectionDone = true;
				}
			}
			else
			{
				UtilityEx.DrawRadialDimPreview(clsItem.frmEditor.viewport, clsItem.frmEditor.viewport.CurrentSketch.Plane, (Circle)entitySelected, mouseloc, PreviewDrawParams);
				isSelectionDone = true;
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.libraryAngle)
		{
			if (entitiesSelected != null && entitiesSelected.Count == 1 && entitiesSelected[0] is Arc)
			{
				UtilityEx.DrawAngularDimPreview(clsItem.frmEditor.viewport, (Arc)entitiesSelected[0], mouseloc, PreviewDrawParams);
				isSelectionDone = true;
			}
			if (entitiesSelected != null && entitiesSelected.Count == 2)
			{
				UtilityEx.DrawAngularDimPreview(clsItem.frmEditor.viewport, clsItem.frmEditor.viewport.CurrentSketch.Plane, (Line)entitiesSelected[0], (Line)entitiesSelected[1], mouseloc, PreviewDrawParams);
				isSelectionDone = true;
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.libraryLineLine && entitiesSelected != null && entitiesSelected.Count >= 2 && ((entitiesSelected[0] is Line) & (entitiesSelected[1] is Line)))
		{
			Point3D startPoint = ((Line)entitiesSelected[0]).StartPoint;
			((Line)entitiesSelected[1]).Project(startPoint, out var t);
			Point3D end = ((Line)entitiesSelected[1]).PointAt(t);
			UtilityEx.DrawLinearDimPreview(clsItem.frmEditor.viewport, clsItem.frmEditor.viewport.CurrentSketch.Plane, new Line(startPoint, end), mouseloc, PreviewDrawParams);
			isSelectionDone = true;
		}
		if (clsInit.appEditor.action == actionTypeBU.libraryLinePoint && entitiesSelected != null && entitiesSelected.Count >= 2)
		{
			if ((entitiesSelected[0] is Line) & (entitiesSelected[1] is devDept.Eyeshot.Entities.Point))
			{
				Line line = entitiesSelected[0] as Line;
				devDept.Eyeshot.Entities.Point point = entitiesSelected[1] as devDept.Eyeshot.Entities.Point;
				line.Project(point.Position, out var t2);
				Point3D end2 = line.PointAt(t2);
				UtilityEx.DrawLinearDimPreview(clsItem.frmEditor.viewport, clsItem.frmEditor.viewport.CurrentSketch.Plane, new Line(point.Position, end2), mouseloc, PreviewDrawParams);
				isSelectionDone = true;
			}
			if ((entitiesSelected[0] is devDept.Eyeshot.Entities.Point) & (entitiesSelected[1] is Line))
			{
				Line line2 = entitiesSelected[1] as Line;
				devDept.Eyeshot.Entities.Point point2 = entitiesSelected[0] as devDept.Eyeshot.Entities.Point;
				line2.Project(point2.Position, out var t3);
				Point3D end3 = line2.PointAt(t3);
				UtilityEx.DrawLinearDimPreview(clsItem.frmEditor.viewport, clsItem.frmEditor.viewport.CurrentSketch.Plane, new Line(point2.Position, end3), mouseloc, PreviewDrawParams);
				isSelectionDone = true;
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.libraryPointPoint && entitiesSelected != null && entitiesSelected.Count >= 2 && ((entitiesSelected[0] is devDept.Eyeshot.Entities.Point) & (entitiesSelected[1] is devDept.Eyeshot.Entities.Point)))
		{
			Point3D position7 = ((devDept.Eyeshot.Entities.Point)entitiesSelected[0]).Position;
			Point3D position8 = ((devDept.Eyeshot.Entities.Point)entitiesSelected[1]).Position;
			if (Point3D.Distance(position7, position8) > 0.0)
			{
				plane_0 = UtilityEx.DrawLinearDimPreview(clsItem.frmEditor.viewport, clsItem.frmEditor.viewport.CurrentSketch.Plane, position7, position8, mouseloc, PreviewDrawParams).Plane;
				isSelectionDone = true;
			}
		}
		if (clsInit.appEditor.action == actionTypeBU.miscAutoSort && clsInit.appEditor.ManuelSortClickResult.ResultType != SortingResultType.None)
		{
			Draw(new Line(Plane.XY, clsInit.appEditor.ManuelSortClickResult.LastPoint, mouseWorldLoc));
		}
		if (DrawingPoints.Count > 0)
		{
			for (int l = 0; l <= DrawingPoints.Count - 1; l++)
			{
				if (DrawingPoints[l].Count > 0)
				{
					LinearPath curve5 = new LinearPath(DrawingPoints[l]);
					Draw(curve5, (float)clsVar.varEditorSet.thicknessDrawingPoints, clsVar.varEditorSet.colorDrawingPoints);
				}
			}
		}
		if (selectedPoint.Count > 0)
		{
			for (int m = 0; m <= selectedPoint.Count - 1; m++)
			{
				DrawPoint(selectedPoint[m], 6f, Color.Green);
			}
		}
		if (selectedCircle.Count > 0)
		{
			for (int n = 0; n <= selectedCircle.Count - 1; n++)
			{
				DrawCircle(selectedCircle[n]);
			}
		}
		if (clsVar.varEditorSet.ShowPoints)
		{
			for (int num13 = 0; num13 <= base.Entities.Count - 1; num13++)
			{
				if (base.Entities[num13] is ICurve)
				{
					DrawPoint(((ICurve)base.Entities[num13]).StartPoint, 6f, Color.Green);
					DrawPoint(((ICurve)base.Entities[num13]).EndPoint, 6f, Color.Green);
				}
			}
		}
		if (clsVar.varEditorSet.ShowBoxSize & (base.Entities.Count > 0))
		{
			if (base.Entities.BoxMin == null)
			{
				base.Entities.UpdateBoundingBox();
			}
			double boxSizeOffset = clsVar.varEditorSet.BoxSizeOffset;
			double boxSizeOffset2 = clsVar.varEditorSet.BoxSizeOffset;
			Draw(new Line(Plane.XY, new Point3D(base.Entities.BoxMin.X - boxSizeOffset, base.Entities.BoxMin.Y - boxSizeOffset2), new Point3D(base.Entities.BoxMax.X + boxSizeOffset, base.Entities.BoxMin.Y - boxSizeOffset2)), 3f, Color.Blue);
			Draw(new Line(Plane.XY, new Point3D(base.Entities.BoxMax.X + boxSizeOffset, base.Entities.BoxMin.Y - boxSizeOffset2), new Point3D(base.Entities.BoxMax.X + boxSizeOffset, base.Entities.BoxMax.Y + boxSizeOffset2)), 3f, Color.Blue);
			Draw(new Line(Plane.XY, new Point3D(base.Entities.BoxMax.X + boxSizeOffset, base.Entities.BoxMax.Y + boxSizeOffset2), new Point3D(base.Entities.BoxMin.X - boxSizeOffset, base.Entities.BoxMax.Y + boxSizeOffset2)), 3f, Color.Blue);
			Draw(new Line(Plane.XY, new Point3D(base.Entities.BoxMin.X - boxSizeOffset, base.Entities.BoxMax.Y + boxSizeOffset2), new Point3D(base.Entities.BoxMin.X - boxSizeOffset, base.Entities.BoxMin.Y - boxSizeOffset2)), 3f, Color.Blue);
		}
		if (clsVar.varEditorSet.DrawDirrectionArrow)
		{
			for (int num14 = 0; num14 <= base.Entities.Count - 1; num14++)
			{
				if (base.Entities[num14] is ICurve && base.Entities[num14].GetType() != typeof(devDept.Eyeshot.Entities.Point))
				{
					DrawArrow((ICurve)base.Entities[num14], ((ICurve)base.Entities[num14]).Domain.Mid, flip: false, 8, 20);
				}
			}
		}
		if (clsInit.appEditor.sortedEntities.Count > 0)
		{
			for (int num15 = 0; num15 <= clsInit.appEditor.sortedEntities.Count - 1; num15++)
			{
				Entity copiedEntity2 = null;
				buEntity.Copy(clsInit.appEditor.sortedEntities[num15], ref copiedEntity2);
				List<Point3D> copiedPoint = new List<Point3D>();
				buVector5.Copy(clsInit.appEditor.sortedEntities[num15].Vertices, ref copiedPoint);
				if (clsInit.appEditor.sortedEntities[num15].sortDirection == entitySortDirection.Reverse)
				{
					copiedPoint.Reverse();
				}
				LinearPath linearPath = new LinearPath(copiedPoint);
				DrawArrow(linearPath, ((ICurve)linearPath).Domain.Mid, flip: false, 4, 15);
				if (linearPath != null)
				{
					float num16 = 2f;
					Color value = Color.Black;
					if (clsInit.appEditor.sortedEntities[num15].Info.CamSelectedCount >= 2)
					{
						num16 += (float)clsInit.appEditor.sortedEntities[num15].Info.CamSelectedCount;
						value = Color.Red;
					}
					Draw(linearPath, num16, value);
				}
			}
			Point3D pntEnd = new Point3D();
			clsInit.cVector5.GetEntityEndPointByCamDirection(clsInit.appEditor.sortedEntities[clsInit.appEditor.sortedEntities.Count - 1], ref pntEnd);
			Point2D point2D = WorldToScreen(pntEnd);
			DrawCircle(new System.Drawing.Point((int)point2D.X, (int)point2D.Y));
		}
		if (osnapPoint_1 != null)
		{
			method_18(osnapPoint_1);
		}
		base.RenderContext.SetLineSize(1.5f);
		if (isDrawing)
		{
			DrawCursor();
		}
		base.DrawOverlay(data);
	}

	private void method_0(System.Drawing.Point point_3, System.Drawing.Point point_4, Color color_0, int int_3, bool bool_2, bool bool_3)
	{
		point_3.Y = base.Height - point_3.Y;
		point_4.Y = base.Height - point_4.Y;
		Class5.smethod_87(ref point_3, ref point_4);
		int[] viewFrame = base.Viewports[0].GetViewFrame();
		int num = viewFrame[0];
		int num2 = viewFrame[1] + viewFrame[3];
		int num3 = num + viewFrame[2];
		int num4 = viewFrame[1];
		if (point_4.X > num3 - 1)
		{
			point_4.X = num3 - 1;
		}
		if (point_4.Y > num2 - 1)
		{
			point_4.Y = num2 - 1;
		}
		if (point_3.X < num + 1)
		{
			point_3.X = num + 1;
		}
		if (point_3.Y < num4 + 1)
		{
			point_3.Y = num4 + 1;
		}
		base.RenderContext.SetState(blendStateType.Blend);
		base.RenderContext.SetColorWireframe(Color.FromArgb(int_3, color_0.R, color_0.G, color_0.B));
		base.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_NoPolygonOffset);
		int num5 = point_4.X - point_3.X;
		int num6 = point_4.Y - point_3.Y;
		base.RenderContext.DrawQuad(new RectangleF(point_3.X + 1, point_3.Y + 1, num5 - 1, num6 - 1));
		base.RenderContext.SetState(blendStateType.NoBlend);
		if (bool_2)
		{
			base.RenderContext.SetColorWireframe(Color.FromArgb(255, color_0.R, color_0.G, color_0.B));
			List<Point3D> list = null;
			if (bool_3)
			{
				base.RenderContext.SetLineStipple(1, 3855, base.Viewports[0].Camera);
				base.RenderContext.EnableLineStipple(enable: true);
			}
			int num7 = point_3.X;
			int num8 = point_4.X;
			if (base.RenderContext.IsDirect3D)
			{
				num7++;
				num8++;
			}
			list = new List<Point3D>(new Point3D[8]
			{
				new Point3D(num7, point_3.Y),
				new Point3D(point_4.X, point_3.Y),
				new Point3D(num8, point_3.Y),
				new Point3D(num8, point_4.Y),
				new Point3D(num8, point_4.Y),
				new Point3D(num7, point_4.Y),
				new Point3D(num7, point_4.Y),
				new Point3D(num7, point_3.Y)
			});
			base.RenderContext.DrawLines(list.ToArray());
			if (bool_3)
			{
				base.RenderContext.EnableLineStipple(enable: false);
			}
		}
	}

	internal void method_1()
	{
		if (firstSelectedEntity != null)
		{
			if (secondSelectedEntity == null)
			{
				base.RenderContext.EnableXOR(enable: false);
			}
		}
		else if (int_2 != -1)
		{
			firstSelectedEntity = base.Entities[int_2];
			firstSelectedEntity.Selected = true;
			int_2 = -1;
			ScreenToPlane(mouseloc, Plane.XY, out point3D_0);
			clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[125], buLangTranslate.preDef.Fillet);
			return;
		}
		if (secondSelectedEntity == null && int_2 != -1)
		{
			secondSelectedEntity = base.Entities[int_2];
			secondSelectedEntity.Selected = true;
		}
		if (!(firstSelectedEntity is ICurve) || !(secondSelectedEntity is ICurve))
		{
			return;
		}
		if (firstSelectedEntity is Line && secondSelectedEntity is Line)
		{
			Line line = firstSelectedEntity as Line;
			Line line2 = secondSelectedEntity as Line;
			if (Vector3D.AreParallel(line.StartTangent, line2.StartTangent))
			{
				clsInit.appEditor.Reset();
				return;
			}
		}
		try
		{
			if (firstSelectedEntity.Equals(secondSelectedEntity))
			{
				clsInit.appEditor.Reset();
				return;
			}
			ScreenToPlane(mouseloc, Plane.XY, out point3D_1);
			firstSelectedEntity = method_13(firstSelectedEntity);
			secondSelectedEntity = method_13(secondSelectedEntity);
			ICurve curve = (ICurve)firstSelectedEntity.Clone();
			ICurve curve2 = (ICurve)secondSelectedEntity.Clone();
			ICurve icurve_ = null;
			ICurve icurve_2 = null;
			ICurve curve3 = null;
			ICurve curve4 = null;
			if (!(firstSelectedEntity is Arc))
			{
				if (!(firstSelectedEntity is Line))
				{
					if (firstSelectedEntity is EllipticalArc)
					{
						EllipticalArc ellipticalArc = firstSelectedEntity as EllipticalArc;
						curve3 = new Ellipse(ellipticalArc.Center, ellipticalArc.RadiusX, ellipticalArc.RadiusY);
					}
				}
				else
				{
					curve3 = Class5.smethod_175(this, (ICurve)(Line)firstSelectedEntity);
				}
			}
			else
			{
				Arc arc = firstSelectedEntity as Arc;
				curve3 = new Circle(arc.Center, arc.Radius);
			}
			if (!(secondSelectedEntity is Arc))
			{
				if (!(secondSelectedEntity is Line))
				{
					if (secondSelectedEntity is EllipticalArc)
					{
						EllipticalArc ellipticalArc2 = secondSelectedEntity as EllipticalArc;
						curve4 = new Ellipse(ellipticalArc2.Center, ellipticalArc2.RadiusX, ellipticalArc2.RadiusY);
					}
				}
				else
				{
					curve4 = Class5.smethod_175(this, (ICurve)(Line)secondSelectedEntity);
				}
			}
			else
			{
				Arc arc2 = secondSelectedEntity as Arc;
				curve4 = new Circle(arc2.Center, arc2.Radius);
			}
			ICurve icurve_3 = curve;
			ICurve icurve_4 = curve2;
			if (Utility.Intersection((ICurve)firstSelectedEntity, (ICurve)secondSelectedEntity).Length > 1 || (curve3 != null && curve4 != null && Utility.Intersection(curve3, curve4).Length > 1))
			{
				Class5.smethod_193(curve2, ref icurve_4, out icurve_3, out icurve_, curve, out icurve_2, this);
			}
			ICurve[] array = new ICurve[8]
			{
				Class5.smethod_33(icurve_3, this),
				Class5.smethod_33(icurve_3, this),
				Class5.smethod_33(icurve_3, this),
				Class5.smethod_33(icurve_3, this),
				null,
				null,
				null,
				null
			};
			ICurve[] array2 = new ICurve[8]
			{
				Class5.smethod_33(icurve_4, this),
				Class5.smethod_33(icurve_4, this),
				Class5.smethod_33(icurve_4, this),
				Class5.smethod_33(icurve_4, this),
				null,
				null,
				null,
				null
			};
			Arc[] array3 = new Arc[8];
			ICurve curve5 = firstSelectedEntity as ICurve;
			ICurve curve6 = secondSelectedEntity as ICurve;
			double num = Point3D.Distance(point3D_0, curve5.StartPoint);
			double num2 = Point3D.Distance(point3D_1, curve5.EndPoint);
			if (!(num2 >= num) && (curve6 is Arc || curve6 is EllipticalArc))
			{
				curve5.Reverse();
			}
			double num3 = Point3D.Distance(point3D_0, curve6.StartPoint);
			double num4 = Point3D.Distance(point3D_1, curve6.EndPoint);
			if (!(num4 >= num3) && (curve6 is Arc || curve6 is EllipticalArc))
			{
				curve6.Reverse();
			}
			for (int i = 4; i < array.Length; i++)
			{
				array[i] = Class5.smethod_33(icurve_3, this);
			}
			for (int j = 4; j < array2.Length; j++)
			{
				array2[j] = Class5.smethod_33(icurve_4, this);
			}
			clsInit.appEditor.UndoBuffer();
			Curve.Fillet(array[0], array2[0], clsVar.varEditorRuntimeSet.FilletRadius, flip1: false, flip2: false, trim1: true, trim2: true, out array3[0]);
			Curve.Fillet(array[1], array2[1], clsVar.varEditorRuntimeSet.FilletRadius, flip1: false, flip2: true, trim1: true, trim2: true, out array3[1]);
			Curve.Fillet(array[2], array2[2], clsVar.varEditorRuntimeSet.FilletRadius, flip1: true, flip2: false, trim1: true, trim2: true, out array3[2]);
			Curve.Fillet(array[3], array2[3], clsVar.varEditorRuntimeSet.FilletRadius, flip1: true, flip2: true, trim1: true, trim2: true, out array3[3]);
			Curve.Fillet(array[4], array2[4], clsVar.varEditorRuntimeSet.FilletRadius, flip1: false, flip2: false, trim1: true, trim2: true, out array3[4]);
			Curve.Fillet(array[5], array2[5], clsVar.varEditorRuntimeSet.FilletRadius, flip1: false, flip2: true, trim1: true, trim2: true, out array3[5]);
			Curve.Fillet(array[6], array2[6], clsVar.varEditorRuntimeSet.FilletRadius, flip1: true, flip2: false, trim1: true, trim2: true, out array3[6]);
			Curve.Fillet(array[7], array2[7], clsVar.varEditorRuntimeSet.FilletRadius, flip1: true, flip2: true, trim1: true, trim2: true, out array3[7]);
			int num5 = method_12(array3);
			if (num5 < 0)
			{
				if (!curve5.StartPoint.Equals(curve6.StartPoint) && !curve5.StartPoint.Equals(curve6.EndPoint) && !curve6.StartPoint.Equals(curve5.EndPoint) && !curve6.EndPoint.Equals(curve5.EndPoint))
				{
					if ((!(secondSelectedEntity is Arc) && !(secondSelectedEntity is EllipticalArc)) || !(firstSelectedEntity is Line))
					{
						Utility.Swap(ref firstSelectedEntity, ref secondSelectedEntity);
						method_8();
						Utility.Swap(ref firstSelectedEntity, ref secondSelectedEntity);
						method_8();
						if (!(num2 >= num) && (curve5 is Arc || curve6 is Arc))
						{
							curve5.Reverse();
						}
						if (!(num4 >= num3) && (curve5 is Arc || curve6 is Arc))
						{
							curve6.Reverse();
						}
					}
					else
					{
						if (!Class5.smethod_137(secondSelectedEntity))
						{
							method_8();
						}
						Utility.Swap(ref firstSelectedEntity, ref secondSelectedEntity);
						method_8();
						Utility.Swap(ref firstSelectedEntity, ref secondSelectedEntity);
					}
					if (clsVar.varEditorRuntimeSet.FilletRadius > 0.0)
					{
						curve = (ICurve)firstSelectedEntity.Clone();
						curve2 = (ICurve)secondSelectedEntity.Clone();
						icurve_3 = curve;
						icurve_4 = curve2;
						if (Utility.Intersection((ICurve)firstSelectedEntity, (ICurve)secondSelectedEntity).Length > 1 || (curve3 != null && curve4 != null && Utility.Intersection(curve3, curve4).Length > 1))
						{
							Class5.smethod_193(curve2, ref icurve_4, out icurve_3, out icurve_, curve, out icurve_2, this);
						}
						for (int k = 0; k < array.Length; k++)
						{
							array[k] = Class5.smethod_33(icurve_3, this);
						}
						for (int l = 0; l < array2.Length; l++)
						{
							array2[l] = Class5.smethod_33(icurve_4, this);
						}
						Curve.Fillet(array[0], array2[0], clsVar.varEditorRuntimeSet.FilletRadius, flip1: false, flip2: false, trim1: true, trim2: true, out array3[0]);
						Curve.Fillet(array[1], array2[1], clsVar.varEditorRuntimeSet.FilletRadius, flip1: false, flip2: true, trim1: true, trim2: true, out array3[1]);
						Curve.Fillet(array[2], array2[2], clsVar.varEditorRuntimeSet.FilletRadius, flip1: true, flip2: false, trim1: true, trim2: true, out array3[2]);
						Curve.Fillet(array[3], array2[3], clsVar.varEditorRuntimeSet.FilletRadius, flip1: true, flip2: true, trim1: true, trim2: true, out array3[3]);
						Curve.Fillet(array[4], array2[4], clsVar.varEditorRuntimeSet.FilletRadius, flip1: false, flip2: false, trim1: true, trim2: true, out array3[4]);
						Curve.Fillet(array[5], array2[5], clsVar.varEditorRuntimeSet.FilletRadius, flip1: false, flip2: true, trim1: true, trim2: true, out array3[5]);
						Curve.Fillet(array[6], array2[6], clsVar.varEditorRuntimeSet.FilletRadius, flip1: true, flip2: false, trim1: true, trim2: true, out array3[6]);
						Curve.Fillet(array[7], array2[7], clsVar.varEditorRuntimeSet.FilletRadius, flip1: true, flip2: true, trim1: true, trim2: true, out array3[7]);
						num5 = method_12(array3);
						if (num5 < 0)
						{
							method_7(firstSelectedEntity, string_0);
							method_7(secondSelectedEntity, string_0);
						}
						else
						{
							base.Entities.Remove(secondSelectedEntity);
							base.Entities.Remove(firstSelectedEntity);
							ICurve curve7 = Class5.smethod_169(this, array[num5], icurve_, true);
							if (curve7 != null)
							{
								array[num5] = curve7;
							}
							curve7 = Class5.smethod_169(this, array2[num5], icurve_2, true);
							if (curve7 != null)
							{
								array2[num5] = curve7;
							}
							method_7(Class5.smethod_137(firstSelectedEntity) ? firstSelectedEntity : ((Entity)array[num5]), string_0);
							method_7(Class5.smethod_137(secondSelectedEntity) ? secondSelectedEntity : ((Entity)array2[num5]), string_0);
							method_7(array3[num5], string_0);
						}
					}
				}
			}
			else
			{
				base.Entities.Remove(firstSelectedEntity);
				base.Entities.Remove(secondSelectedEntity);
				ICurve curve8 = array[num5];
				ICurve curve9 = array2[num5];
				bool flag = curve8 is EllipticalArc && (curve8 as EllipticalArc).Center.X > point3D_0.X;
				ICurve curve10 = Class5.smethod_169(this, curve8, icurve_, flag);
				if (curve10 != null)
				{
					array[num5] = curve10;
				}
				flag = curve9 is EllipticalArc && (curve9 as EllipticalArc).Center.X > point3D_1.X;
				curve10 = Class5.smethod_169(this, curve9, icurve_2, flag);
				if (curve10 != null)
				{
					array2[num5] = curve10;
				}
				method_7(Class5.smethod_137(firstSelectedEntity) ? firstSelectedEntity : ((Entity)array[num5]), string_0);
				method_7(Class5.smethod_137(secondSelectedEntity) ? secondSelectedEntity : ((Entity)array2[num5]), string_0);
				method_7(array3[num5], string_0);
			}
			clsInit.appEditor.Reset();
		}
		catch
		{
		}
		clsInit.appEditor.Reset();
	}

	internal void method_2()
	{
		if (firstSelectedEntity != null)
		{
			if (secondSelectedEntity == null)
			{
				base.RenderContext.EnableXOR(enable: false);
			}
		}
		else if (int_2 != -1)
		{
			firstSelectedEntity = base.Entities[int_2];
			firstSelectedEntity.Selected = true;
			int_2 = -1;
			ScreenToPlane(mouseloc, Plane.XY, out point3D_0);
			clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[125], buLangTranslate.preDef.Chamfer);
			return;
		}
		if (secondSelectedEntity == null && int_2 != -1)
		{
			secondSelectedEntity = base.Entities[int_2];
			secondSelectedEntity.Selected = true;
		}
		if (!(firstSelectedEntity is ICurve) || !(secondSelectedEntity is ICurve))
		{
			return;
		}
		if (!firstSelectedEntity.Equals(secondSelectedEntity))
		{
			firstSelectedEntity = method_13(firstSelectedEntity);
			secondSelectedEntity = method_13(secondSelectedEntity);
			ScreenToPlane(mouseloc, Plane.XY, out point3D_1);
			double chamferLength = clsVar.varEditorRuntimeSet.ChamferLength;
			ICurve curve = (ICurve)firstSelectedEntity.Clone();
			ICurve curve2 = (ICurve)secondSelectedEntity.Clone();
			ICurve icurve_ = null;
			ICurve icurve_2 = null;
			ICurve curve3 = null;
			ICurve curve4 = null;
			if (!(firstSelectedEntity is Arc))
			{
				if (!(firstSelectedEntity is Line))
				{
					if (firstSelectedEntity is EllipticalArc)
					{
						EllipticalArc ellipticalArc = (EllipticalArc)firstSelectedEntity;
						curve3 = new Ellipse(ellipticalArc.Center, ellipticalArc.RadiusX, ellipticalArc.RadiusY);
					}
				}
				else
				{
					curve3 = Class5.smethod_175(this, (ICurve)(Line)firstSelectedEntity);
				}
			}
			else
			{
				Arc arc = firstSelectedEntity as Arc;
				curve3 = new Circle(arc.Center, arc.Radius);
			}
			if (!(secondSelectedEntity is Arc))
			{
				if (!(secondSelectedEntity is Line))
				{
					if (secondSelectedEntity is EllipticalArc)
					{
						EllipticalArc ellipticalArc2 = secondSelectedEntity as EllipticalArc;
						curve4 = new Ellipse(ellipticalArc2.Center, ellipticalArc2.RadiusX, ellipticalArc2.RadiusY);
					}
				}
				else
				{
					curve4 = Class5.smethod_175(this, (ICurve)(Line)secondSelectedEntity);
				}
			}
			else
			{
				Arc arc2 = secondSelectedEntity as Arc;
				curve4 = new Circle(arc2.Center, arc2.Radius);
			}
			ICurve icurve_3 = curve;
			ICurve icurve_4 = curve2;
			if (Utility.Intersection((ICurve)firstSelectedEntity, (ICurve)secondSelectedEntity).Length > 1 || (curve3 != null && curve4 != null && Utility.Intersection(curve3, curve4).Length > 1))
			{
				Class5.smethod_193(curve2, ref icurve_4, out icurve_3, out icurve_, curve, out icurve_2, this);
			}
			ICurve[] array = new ICurve[8]
			{
				Class5.smethod_33(icurve_3, this),
				Class5.smethod_33(icurve_3, this),
				Class5.smethod_33(icurve_3, this),
				Class5.smethod_33(icurve_3, this),
				null,
				null,
				null,
				null
			};
			ICurve[] array2 = new ICurve[8]
			{
				Class5.smethod_33(icurve_4, this),
				Class5.smethod_33(icurve_4, this),
				Class5.smethod_33(icurve_4, this),
				Class5.smethod_33(icurve_4, this),
				null,
				null,
				null,
				null
			};
			Line[] array3 = new Line[8];
			ICurve curve5 = firstSelectedEntity as ICurve;
			ICurve curve6 = secondSelectedEntity as ICurve;
			double num = Point3D.Distance(point3D_0, curve5.StartPoint);
			double num2 = Point3D.Distance(point3D_1, curve5.EndPoint);
			if (!(num2 >= num) && (curve6 is Arc || curve6 is EllipticalArc))
			{
				curve5.Reverse();
			}
			double num3 = Point3D.Distance(point3D_0, curve6.StartPoint);
			double num4 = Point3D.Distance(point3D_1, curve6.EndPoint);
			if (!(num4 >= num3) && (curve6 is Arc || curve6 is EllipticalArc))
			{
				curve6.Reverse();
			}
			for (int i = 4; i < array.Length; i++)
			{
				array[i] = Class5.smethod_33(icurve_3, this);
			}
			for (int j = 4; j < array2.Length; j++)
			{
				array2[j] = Class5.smethod_33(icurve_4, this);
			}
			clsInit.appEditor.UndoBuffer();
			Curve.Chamfer(array[0], array2[0], chamferLength, flip1: false, flip2: false, trim1: true, trim2: true, out array3[0]);
			Curve.Chamfer(array[1], array2[1], chamferLength, flip1: false, flip2: true, trim1: true, trim2: true, out array3[1]);
			Curve.Chamfer(array[2], array2[2], chamferLength, flip1: true, flip2: false, trim1: true, trim2: true, out array3[2]);
			Curve.Chamfer(array[3], array2[3], chamferLength, flip1: true, flip2: true, trim1: true, trim2: true, out array3[3]);
			Curve.Chamfer(array[4], array2[4], chamferLength, flip1: false, flip2: false, trim1: true, trim2: true, out array3[4]);
			Curve.Chamfer(array[5], array2[5], chamferLength, flip1: false, flip2: true, trim1: true, trim2: true, out array3[5]);
			Curve.Chamfer(array[6], array2[6], chamferLength, flip1: true, flip2: false, trim1: true, trim2: true, out array3[6]);
			Curve.Chamfer(array[7], array2[7], chamferLength, flip1: true, flip2: true, trim1: true, trim2: true, out array3[7]);
			int num5 = method_12(array3);
			if (num5 < 0)
			{
				if (!curve5.StartPoint.Equals(curve6.StartPoint) && !curve5.StartPoint.Equals(curve6.EndPoint) && !curve6.StartPoint.Equals(curve5.EndPoint) && !curve6.EndPoint.Equals(curve5.EndPoint))
				{
					if ((!(secondSelectedEntity is Arc) && !(secondSelectedEntity is EllipticalArc)) || !(firstSelectedEntity is Line))
					{
						Utility.Swap(ref firstSelectedEntity, ref secondSelectedEntity);
						method_8();
						Utility.Swap(ref firstSelectedEntity, ref secondSelectedEntity);
						method_8();
						if (!(num2 >= num) && (curve5 is Arc || curve6 is Arc))
						{
							curve5.Reverse();
						}
						if (!(num4 >= num3) && (curve5 is Arc || curve6 is Arc))
						{
							curve6.Reverse();
						}
					}
					else
					{
						if (!Class5.smethod_137(secondSelectedEntity))
						{
							method_8();
						}
						Utility.Swap(ref firstSelectedEntity, ref secondSelectedEntity);
						method_8();
						Utility.Swap(ref firstSelectedEntity, ref secondSelectedEntity);
					}
					if (chamferLength > 0.0)
					{
						curve = (ICurve)firstSelectedEntity.Clone();
						curve2 = (ICurve)secondSelectedEntity.Clone();
						icurve_3 = curve;
						icurve_4 = curve2;
						if (Utility.Intersection((ICurve)firstSelectedEntity, (ICurve)secondSelectedEntity).Length > 1 || (curve3 != null && curve4 != null && Utility.Intersection(curve3, curve4).Length > 1))
						{
							Class5.smethod_193(curve2, ref icurve_4, out icurve_3, out icurve_, curve, out icurve_2, this);
						}
						for (int k = 0; k < array.Length; k++)
						{
							array[k] = Class5.smethod_33(icurve_3, this);
						}
						for (int l = 0; l < array2.Length; l++)
						{
							array2[l] = Class5.smethod_33(icurve_4, this);
						}
						Curve.Chamfer(array[0], array2[0], chamferLength, flip1: false, flip2: false, trim1: true, trim2: true, out array3[0]);
						Curve.Chamfer(array[1], array2[1], chamferLength, flip1: false, flip2: true, trim1: true, trim2: true, out array3[1]);
						Curve.Chamfer(array[2], array2[2], chamferLength, flip1: true, flip2: false, trim1: true, trim2: true, out array3[2]);
						Curve.Chamfer(array[3], array2[3], chamferLength, flip1: true, flip2: true, trim1: true, trim2: true, out array3[3]);
						Curve.Chamfer(array[4], array2[4], chamferLength, flip1: false, flip2: false, trim1: true, trim2: true, out array3[4]);
						Curve.Chamfer(array[5], array2[5], chamferLength, flip1: false, flip2: true, trim1: true, trim2: true, out array3[5]);
						Curve.Chamfer(array[6], array2[6], chamferLength, flip1: true, flip2: false, trim1: true, trim2: true, out array3[6]);
						Curve.Chamfer(array[7], array2[7], chamferLength, flip1: true, flip2: true, trim1: true, trim2: true, out array3[7]);
						num5 = method_12(array3);
						if (num5 < 0)
						{
							method_7(firstSelectedEntity, string_0);
							method_7(secondSelectedEntity, string_0);
						}
						else
						{
							base.Entities.Remove(secondSelectedEntity);
							base.Entities.Remove(firstSelectedEntity);
							ICurve curve7 = Class5.smethod_169(this, array[num5], icurve_, true);
							if (curve7 != null)
							{
								array[num5] = curve7;
							}
							curve7 = Class5.smethod_169(this, array2[num5], icurve_2, true);
							if (curve7 != null)
							{
								array2[num5] = curve7;
							}
							method_7(Class5.smethod_137(firstSelectedEntity) ? firstSelectedEntity : ((Entity)array[num5]), string_0);
							method_7(Class5.smethod_137(secondSelectedEntity) ? secondSelectedEntity : ((Entity)array2[num5]), string_0);
							method_7(array3[num5], string_0);
						}
					}
				}
			}
			else
			{
				base.Entities.Remove(firstSelectedEntity);
				base.Entities.Remove(secondSelectedEntity);
				bool flag = array[num5] is EllipticalArc && ((EllipticalArc)array[num5]).Center.X > point3D_0.X;
				ICurve curve8 = Class5.smethod_169(this, array[num5], icurve_, flag);
				if (curve8 != null)
				{
					array[num5] = curve8;
				}
				flag = array2[num5] is EllipticalArc && ((EllipticalArc)array2[num5]).Center.X > point3D_1.X;
				curve8 = Class5.smethod_169(this, array2[num5], icurve_2, flag);
				if (curve8 != null)
				{
					array2[num5] = curve8;
				}
				method_7(Class5.smethod_137(firstSelectedEntity) ? firstSelectedEntity : ((Entity)array[num5]), string_0);
				method_7(Class5.smethod_137(secondSelectedEntity) ? secondSelectedEntity : ((Entity)array2[num5]), string_0);
				method_7(array3[num5], string_0);
			}
			clsInit.appEditor.Reset();
			Invalidate();
		}
		else
		{
			clsInit.appEditor.Reset();
		}
	}

	private void method_3(ref double double_1)
	{
		double num = 0.0;
		if (base.ActionMode != actionType.None || Clicks.Count <= 0)
		{
			return;
		}
		Line curve = new Line(Clicks[0].Pnt3D, mouseWorldLoc);
		Draw(curve, 2f, Color.Blue);
		if (Clicks.Count == 2)
		{
			num = Clicks[0].Pnt3D.DistanceTo(Clicks[1].Pnt3D);
			if (num > 0.001)
			{
				Plane plane = Class5.smethod_13(Clicks[1].Pnt3D, this);
				Vector2D vector2D = new Vector2D(Clicks[0].Pnt3D, Clicks[1].Pnt3D);
				vector2D.Normalize();
				Vector2D vector2D2 = new Vector2D(Clicks[0].Pnt3D, mouseWorldLoc);
				vector2D2.Normalize();
				double_1 = Vector2D.SignedAngleBetween(vector2D, vector2D2);
				if (Math.Abs(double_1) > 0.001)
				{
					Arc curve2 = new Arc(plane, plane.Origin, num, 0.0, double_1);
					Draw(curve2, 2f, Color.Blue);
				}
			}
		}
		if (Clicks.Count != 3)
		{
			return;
		}
		num = Clicks[0].Pnt3D.DistanceTo(Clicks[1].Pnt3D);
		if (num > 0.001)
		{
			Plane plane2 = Class5.smethod_13(Clicks[1].Pnt3D, this);
			Vector2D vector2D3 = new Vector2D(Clicks[0].Pnt3D, Clicks[1].Pnt3D);
			vector2D3.Normalize();
			Vector2D vector2D4 = new Vector2D(Clicks[0].Pnt3D, Clicks[2].Pnt3D);
			vector2D4.Normalize();
			double_1 = Vector2D.SignedAngleBetween(vector2D3, vector2D4);
			if (Math.Abs(double_1) > 0.001)
			{
				Arc curve3 = new Arc(plane2, plane2.Origin, num, 0.0, double_1);
				Draw(curve3, 2f, Color.Blue);
			}
		}
	}

	private void method_4()
	{
		SelectedItem itemUnderMouseCursor = GetItemUnderMouseCursor(mouseloc);
		if (itemUnderMouseCursor == null || itemUnderMouseCursor.Item == null)
		{
			entity_0 = null;
		}
		else
		{
			Entity entity = itemUnderMouseCursor.Item as Entity;
			entity_0 = entity.Clone() as Entity;
		}
		List<Entity> previewEntities = new List<Entity>();
		Utility.TrimPreview(this, mouseloc, out previewEntities);
		list_0 = previewEntities.Select((Entity entity_0) => entity_0.Clone() as Entity).ToList();
		foreach (Entity item in list_0)
		{
			if (base.CurrentTransformation != null)
			{
				item.TransformBy(base.CurrentTransformation);
			}
		}
		if (entity_0 != null && base.CurrentTransformation != null)
		{
			entity_0.TransformBy(base.CurrentTransformation);
		}
	}

	private void method_5()
	{
		base.RenderContext.EnableXOR(enable: false);
		if (list_0.Count <= 0)
		{
			if (entity_0 != null)
			{
				Draw(entity_0 as ICurve, 5f, Color.DodgerBlue);
			}
		}
		else
		{
			Draw(entity_0 as ICurve, 5f, Color.BlueViolet);
			foreach (Entity item in list_0)
			{
				Draw(item as ICurve, 5f, Color.DodgerBlue);
			}
		}
		base.RenderContext.EnableXOR(enable: true);
	}

	public void DrawCursor()
	{
		double num = 10.0;
		Draw(new Line(mouseScreenLoc.X, mouseScreenLoc.Y - num, mouseScreenLoc.X, mouseScreenLoc.Y + num), 1.5f, null, screenCoords: true);
		Draw(new Line(mouseScreenLoc.X - num, mouseScreenLoc.Y, mouseScreenLoc.X + num, mouseScreenLoc.Y), 1.5f, null, screenCoords: true);
	}

	public void Draw(ICurve curve, float? lineSize = null, Color? color = null, bool screenCoords = false)
	{
		float? num = null;
		float? num2 = null;
		Color? color2 = null;
		Color color_ = Color.Blue;
		float float_ = 1f;
		shaderType currentShader = base.RenderContext.CurrentShader;
		if (lineSize.HasValue)
		{
			float_ = lineSize.Value;
			if (!(curve is devDept.Eyeshot.Entities.Point))
			{
				num = base.RenderContext.SetLineSize(lineSize.Value);
			}
			else
			{
				num2 = base.RenderContext.SetPointSize(lineSize.Value);
			}
		}
		if (color.HasValue)
		{
			color2 = base.RenderContext.CurrentWireColor;
			color_ = color.Value;
			base.RenderContext.SetColorWireframe(color.Value);
		}
		if (!(curve is Line))
		{
			if (!(curve is LinearPath))
			{
				if (!(curve is devDept.Eyeshot.Entities.Point))
				{
					if (!(curve is CompositeCurve))
					{
						method_6(curve, screenCoords, color_, float_);
					}
					else
					{
						Entity[] array = ((CompositeCurve)curve).Explode();
						foreach (Entity entity in array)
						{
							method_6((ICurve)entity, screenCoords, color_, float_);
						}
					}
				}
				else
				{
					base.RenderContext.DrawPoints(new Point3D[1] { method_14(((devDept.Eyeshot.Entities.Point)curve).Position, screenCoords) });
				}
			}
			else
			{
				base.RenderContext.DrawLineStrip(method_15(((LinearPath)curve).Vertices, screenCoords));
			}
		}
		else
		{
			base.RenderContext.DrawLine(method_14(curve.StartPoint, screenCoords), method_14(curve.EndPoint, screenCoords));
		}
		if (num2.HasValue)
		{
			base.RenderContext.SetPointSize(num2.Value);
		}
		if (num.HasValue)
		{
			base.RenderContext.SetLineSize(num.Value);
		}
		if (color2.HasValue)
		{
			base.RenderContext.SetColorWireframe(color2.Value);
		}
		base.RenderContext.SetShader(currentShader);
	}

	public void DrawArrow(Point3D position, Vector2D tangent, bool flip = false, int height = 4, int width = 10, int mWidth = 2)
	{
		base.RenderContext.SetColorWireframe(Color.Black);
		Mesh mesh = Class5.smethod_164((double)mWidth, (double)width, (double)height);
		mesh.Rotate(tangent.Angle + ((!flip) ? 0.0 : Math.PI), Vector3D.AxisZ);
		mesh.Translate(WorldToScreen(position).AsVector);
		base.RenderContext.DrawPlainTriangles(mesh.Triangles, mesh.Vertices);
	}

	public void DrawArrow(ICurve curve, double t, bool flip = false, int height = 4, int width = 10, int mWidth = 2)
	{
		bool flag = false;
		bool flag2 = false;
		if (curve is Entity && ((Entity)curve).EntityData != null && ((Entity)curve).EntityData is SewingEntityCustomData)
		{
			if (((SewingEntityCustomData)((Entity)curve).EntityData).SortDir == entitySortDirection.Reverse)
			{
				flag = true;
			}
			if ((((SewingEntityCustomData)((Entity)curve).EntityData).DrawType != SewingDrawType.Jump) & (((SewingEntityCustomData)((Entity)curve).EntityData).DrawType != SewingDrawType.Stitched))
			{
				flag2 = true;
			}
			if (((SewingEntityCustomData)((Entity)curve).EntityData).DrawType == SewingDrawType.Punteriz)
			{
				t = 1.0;
				flag2 = true;
			}
			if (((SewingEntityCustomData)((Entity)curve).EntityData).DrawType == SewingDrawType.Extension)
			{
				t = 1.0;
				flag2 = true;
			}
		}
		Point3D point3D = curve.PointAt(t);
		Vector3D vector3D = curve.TangentAt(t);
		if ((point3D != null) & (vector3D != null))
		{
			Point2D point2D = WorldToScreen(point3D) - WorldToScreen(point3D - vector3D);
			Vector2D asVector = point2D.AsVector;
			if (!flag)
			{
			}
			asVector.Normalize();
			if (!flag2)
			{
				DrawArrow(curve.PointAt(t).AsVector.AsPoint, asVector, flip, height, width, mWidth);
			}
		}
	}

	public void DrawCircle(Circle C)
	{
		base.RenderContext.SetColorWireframe(C.Color);
		devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(C);
		Mesh mesh = region.ExtrudeAsMesh(0.1, 0.01, Mesh.natureType.RichSmooth);
		mesh.Regen(0.02);
		List<Point3D> list = new List<Point3D>();
		list.AddRange(method_15(mesh.Vertices, bool_2: false));
		base.RenderContext.DrawPlainTriangles(mesh.Triangles, list);
	}

	public void DrawPoint(Point3D P, float size, Color color)
	{
		base.RenderContext.SetPointSize(size);
		base.RenderContext.SetColorWireframe(color);
		Point3D[] points = new Point3D[1] { method_14(P, bool_2: false) };
		base.RenderContext.DrawPoints(points);
	}

	private void method_6(ICurve icurve_0, bool bool_2, Color color_0, float float_0 = 1f)
	{
		if (icurve_0 is Entity)
		{
			Entity entity = (Entity)icurve_0;
			if (entity.Vertices == null)
			{
				entity.Regen(0.01);
			}
			base.RenderContext.SetLineSize(float_0);
			base.RenderContext.SetColorWireframe(color_0);
			base.RenderContext.SetState(depthStencilStateType.DepthTestOff);
			base.RenderContext.DrawLineStrip(method_15(entity.Vertices, bool_2));
		}
	}

	internal void method_7(Entity entity_1, string string_1)
	{
		entity_1.ColorMethod = colorMethodType.byEntity;
		entity_1.Color = clsVar.varEditorSet.colorEntity;
		entity_1.LineWeight = (float)clsVar.varEditorSet.thicknessEntity;
		entity_1.LineWeightMethod = colorMethodType.byEntity;
		if (!(entity_1 is devDept.Eyeshot.Entities.Point))
		{
			if (!(entity_1 is Dimension))
			{
				if (!(entity_1 is Leader))
				{
					if (!(entity_1 is Text))
					{
						base.Entities.Add(entity_1, string_1);
					}
					else
					{
						Text text = (Text)entity_1;
						text.LayerName = string_1;
						text.WidthFactor = 0.9;
						text.LineWeightMethod = colorMethodType.byEntity;
						base.Entities.Add(text);
					}
				}
				else
				{
					entity_1.LayerName = string_1;
					entity_1.LineWeightMethod = colorMethodType.byEntity;
					base.Entities.Add(entity_1);
				}
			}
			else
			{
				Dimension dimension = (Dimension)entity_1;
				dimension.LayerName = string_1;
				dimension.WidthFactor = 0.9;
				dimension.LineWeightMethod = colorMethodType.byEntity;
				base.Entities.Add(dimension);
			}
		}
		else
		{
			entity_1.LineWeightMethod = colorMethodType.byEntity;
			entity_1.LineWeight += 3f;
			base.Entities.Add(entity_1);
		}
		base.Entities.Regen();
		Invalidate();
	}

	private void method_8()
	{
		if (!(firstSelectedEntity is ICurve) || !(secondSelectedEntity is ICurve))
		{
			return;
		}
		ICurve curve = firstSelectedEntity as ICurve;
		ICurve curve2 = secondSelectedEntity as ICurve;
		ScreenToPlane(mouseloc, Plane.XY, out point3D_1);
		double num = 0.5;
		curve.ClosestPointTo(curve2.StartPoint, out var t);
		curve.ClosestPointTo(curve2.EndPoint, out var t2);
		Point3D point3D = curve.PointAt(t);
		Point3D point3D2 = curve.PointAt(t2);
		ICurve curve3 = null;
		ICurve curve4 = null;
		if (!(curve2 is Arc))
		{
			if (!(curve2 is Ellipse))
			{
				if (curve2 is Line)
				{
					curve3 = Class5.smethod_175(this, (ICurve)(Line)curve2);
				}
			}
			else
			{
				Ellipse ellipse = curve2 as Ellipse;
				curve3 = new Ellipse(ellipse.Center, ellipse.RadiusX, ellipse.RadiusY);
			}
		}
		else
		{
			Arc arc = curve2 as Arc;
			curve3 = new Circle(arc.Center, arc.Radius);
		}
		if (!(curve is Arc))
		{
			if (!(curve is Ellipse))
			{
				if (curve is Line)
				{
					curve4 = Class5.smethod_175(this, (ICurve)(Line)curve);
				}
			}
			else
			{
				Ellipse ellipse2 = curve as Ellipse;
				curve4 = new Ellipse(ellipse2.Center, ellipse2.RadiusX, ellipse2.RadiusY);
			}
		}
		else
		{
			Arc arc2 = curve as Arc;
			curve4 = new Circle(arc2.Center, arc2.Radius);
		}
		double num2;
		double num3;
		if (curve3 == null || curve4 == null || curve3.IntersectWith(curve4).Length <= 1)
		{
			num2 = curve2.StartPoint.DistanceTo(point3D);
			num3 = curve2.EndPoint.DistanceTo(point3D2);
		}
		else
		{
			num2 = curve2.StartPoint.DistanceTo(point3D_1);
			num3 = curve2.EndPoint.DistanceTo(point3D_1);
		}
		double num4 = Math.Abs(curve2.StartPoint.X - point3D.X);
		double num5 = Math.Abs(curve2.StartPoint.Y - point3D.Y);
		double num6 = Math.Abs(curve2.EndPoint.X - point3D2.X);
		double num7 = Math.Abs(curve2.EndPoint.Y - point3D2.Y);
		bool flag = false;
		bool? flag2 = null;
		if (num2 >= num3 || !(num4 > num) || !(num5 > num))
		{
			if (num6 <= num || !(num7 > num))
			{
				if (!(num4 <= num) && num5 > num)
				{
					flag2 = true;
				}
			}
			else
			{
				flag2 = false;
			}
		}
		else
		{
			flag2 = true;
		}
		if (flag2.HasValue)
		{
			if (!(curve2 is Line))
			{
				if (!(curve2 is LinearPath))
				{
					if (!(curve2 is Arc))
					{
						if (!(curve2 is EllipticalArc))
						{
							if (curve2 is Curve)
							{
								flag = Class5.smethod_139(curve2, curve, this, flag2.Value);
							}
						}
						else
						{
							flag = method_10(curve2, curve, flag2.Value);
						}
					}
					else
					{
						flag = method_9(curve2, curve, flag2.Value);
					}
				}
				else
				{
					flag = Class5.smethod_54(curve2, this, curve, flag2.Value);
				}
			}
			else
			{
				flag = Class5.smethod_88(curve2, curve, this, flag2.Value);
			}
		}
		if (flag)
		{
			base.Entities.Regen();
		}
	}

	private bool method_9(ICurve icurve_0, ICurve icurve_1, bool bool_2)
	{
		Arc arc = icurve_0 as Arc;
		Circle c = new Circle(arc.Plane, arc.Center, arc.Radius);
		Point3D[] array = Utility.Intersection(icurve_1, c);
		if (array.Length == 0)
		{
			array = Utility.Intersection(Class5.smethod_175(this, icurve_1), c);
		}
		if (array.Length == 0)
		{
			return false;
		}
		if (!bool_2)
		{
			Point3D p = Class5.smethod_118(this, arc.EndPoint, array);
			Vector3D vector3D = new Vector3D(arc.Center, arc.StartPoint);
			vector3D.Normalize();
			Vector3D vector3D2 = Vector3D.Cross(Vector3D.AxisZ, vector3D);
			vector3D2.Normalize();
			Plane plane = new Plane(arc.Center, vector3D, vector3D2);
			Vector2D vector2D = new Vector2D(arc.Center, arc.StartPoint);
			vector2D.Normalize();
			Vector2D vector2D2 = new Vector2D(arc.Center, p);
			vector2D2.Normalize();
			double endAngleInRadians = Vector2D.SignedAngleBetween(vector2D, vector2D2);
			base.Entities.Remove(secondSelectedEntity);
			secondSelectedEntity = new Arc(plane, plane.Origin, arc.Radius, 0.0, endAngleInRadians);
		}
		else
		{
			Point3D p2 = Class5.smethod_118(this, arc.StartPoint, array);
			Vector3D vector3D3 = new Vector3D(arc.Center, arc.EndPoint);
			vector3D3.Normalize();
			Vector3D vector3D4 = Vector3D.Cross(Vector3D.AxisZ, vector3D3);
			vector3D4.Normalize();
			Plane plane2 = new Plane(arc.Center, vector3D3, vector3D4);
			Vector2D vector2D3 = new Vector2D(arc.Center, arc.EndPoint);
			vector2D3.Normalize();
			Vector2D vector2D4 = new Vector2D(arc.Center, p2);
			vector2D4.Normalize();
			double endAngleInRadians2 = Vector2D.SignedAngleBetween(vector2D3, vector2D4);
			base.Entities.Remove(secondSelectedEntity);
			secondSelectedEntity = new Arc(plane2, plane2.Origin, arc.Radius, 0.0, endAngleInRadians2);
		}
		return true;
	}

	private bool method_10(ICurve icurve_0, ICurve icurve_1, bool bool_2)
	{
		EllipticalArc ellipticalArc = icurve_0 as EllipticalArc;
		Ellipse c = new Ellipse(ellipticalArc.Plane, ellipticalArc.Center, ellipticalArc.RadiusX, ellipticalArc.RadiusY);
		Point3D[] array = Utility.Intersection(icurve_1, c);
		if (array.Length == 0)
		{
			array = Utility.Intersection(Class5.smethod_175(this, icurve_1), c);
		}
		EllipticalArc ellipticalArc2 = null;
		if (array.Length != 0)
		{
			Plane plane = ellipticalArc.Plane;
			if (!bool_2)
			{
				Point3D end = Class5.smethod_118(this, ellipticalArc.EndPoint, array);
				ellipticalArc2 = new EllipticalArc(plane, ellipticalArc.Center, ellipticalArc.RadiusX, ellipticalArc.RadiusY, ellipticalArc.StartPoint, end, flip: false);
				ellipticalArc2.ClosestPointTo(ellipticalArc.EndPoint, out var t);
				Point3D point3D = ellipticalArc2.PointAt(t);
				if (point3D.DistanceTo(ellipticalArc.EndPoint) > 0.1)
				{
					ellipticalArc2 = new EllipticalArc(plane, ellipticalArc.Center, ellipticalArc.RadiusX, ellipticalArc.RadiusY, ellipticalArc.StartPoint, end, flip: true);
				}
			}
			else
			{
				Point3D end2 = Class5.smethod_118(this, ellipticalArc.StartPoint, array);
				ellipticalArc2 = new EllipticalArc(plane, ellipticalArc.Center, ellipticalArc.RadiusX, ellipticalArc.RadiusY, ellipticalArc.EndPoint, end2, flip: false);
				ellipticalArc2.ClosestPointTo(ellipticalArc.StartPoint, out var t2);
				Point3D point3D2 = ellipticalArc2.PointAt(t2);
				if (point3D2.DistanceTo(ellipticalArc.StartPoint) > 0.1)
				{
					ellipticalArc2 = new EllipticalArc(plane, ellipticalArc.Center, ellipticalArc.RadiusX, ellipticalArc.RadiusY, ellipticalArc.EndPoint, end2, flip: true);
				}
				method_7(ellipticalArc2, ((Entity)icurve_0).LayerName);
			}
			if (ellipticalArc2 != null)
			{
				base.Entities.Remove(secondSelectedEntity);
				secondSelectedEntity = ellipticalArc2;
				return true;
			}
		}
		return false;
	}

	internal bool method_11(ICurve icurve_0, ICurve icurve_1, bool bool_2)
	{
		ICurve curve = icurve_0.Clone() as ICurve;
		List<Point3D> list = new List<Point3D>();
		for (int i = 0; i < 10; i++)
		{
			if (list != null && list.Count != 0)
			{
				break;
			}
			double t = ((!bool_2) ? (curve.Domain.t1 + curve.Domain.Length) : (curve.Domain.t0 - curve.Domain.Length));
			curve.ExtendAt(t);
			list = curve.IntersectWith(icurve_1).ToList();
		}
		if (list.Count != 0)
		{
			ICurve curve2 = icurve_0.Clone() as ICurve;
			curve2.ExtendBy(list[0], !bool_2);
			for (int j = 1; j < list.Count; j++)
			{
				Point3D pt = list[j];
				ICurve curve3 = icurve_0.Clone() as ICurve;
				curve3.ExtendBy(pt, !bool_2);
				if (curve3.Length() < curve2.Length())
				{
					curve2 = curve3;
				}
			}
			base.Entities.Remove((Entity)icurve_0);
			base.Entities.Add((Entity)curve2);
			return true;
		}
		return false;
	}

	private int method_12<T>(T[] gparam_0) where T : ICurve
	{
		double num = double.MaxValue;
		int result = -1;
		for (int i = 0; i < gparam_0.Length; i++)
		{
			ICurve curve = gparam_0[i];
			if (curve != null)
			{
				Point3D b = curve.PointAt(curve.Domain.Mid);
				double num2 = Point3D.Distance(point3D_0, b) + Point3D.Distance(point3D_1, b);
				if (num2 < num)
				{
					num = num2;
					result = i;
				}
			}
		}
		return result;
	}

	private Entity method_13(Entity entity_1)
	{
		if (!(entity_1 is Circle) || entity_1 is Arc)
		{
			if (entity_1 is Ellipse && !(entity_1 is EllipticalArc))
			{
				Ellipse ellipse = entity_1 as Ellipse;
				base.Entities.Remove(entity_1);
				entity_1 = new EllipticalArc(ellipse.Center, ellipse.RadiusX, ellipse.RadiusY, Math.PI * 2.0);
			}
		}
		else
		{
			Circle circle = entity_1 as Circle;
			base.Entities.Remove(entity_1);
			entity_1 = new Arc(circle.Center, circle.Radius, Math.PI * 2.0);
		}
		return entity_1;
	}

	public Entity GetEntityByPosition(System.Drawing.Point location)
	{
		try
		{
			SelectedItem itemUnderMouseCursor = GetItemUnderMouseCursor(location);
			if (itemUnderMouseCursor == null)
			{
				return null;
			}
			return itemUnderMouseCursor.Item as Entity;
		}
		catch (Exception)
		{
			return null;
		}
	}

	private Point3D method_14(Point3D point3D_2, bool bool_2)
	{
		return (!bool_2) ? WorldToScreen(point3D_2) : point3D_2;
	}

	private Point3D[] method_15(Point3D[] point3D_2, bool bool_2)
	{
		return (!bool_2) ? WorldToScreen(point3D_2) : point3D_2;
	}

	private double method_16(Point3D point3D_2, Point3D point3D_3, bool bool_2)
	{
		Point3D point3D = point3D_2.Clone() as Point3D;
		if (bool_2 && base.CurrentTransformation != null)
		{
			point3D.TransformBy(base.CurrentTransformation);
		}
		return WorldToScreen(point3D).DistanceTo(WorldToScreen(point3D_3));
	}

	public OsnapPoint Snaping()
	{
		try
		{
			if (!((base.CurrentSketch == null) & clsVar.varEditorRuntimeSet.isSketchMode))
			{
				devDept.Eyeshot.Entities.Point point = (from point_3 in base.Entities.OfType<devDept.Eyeshot.Entities.Point>()
					where method_16(point_3.Position, mouseWorldLoc, bool_2: true) <= (double)clsVar.varEditorSet.snapGridPixel
					orderby method_16(point_3.Position, mouseWorldLoc, bool_2: true)
					select point_3).FirstOrDefault();
				bool_0 = false;
				point_1 = null;
				if (point == null)
				{
					if (bool_1)
					{
					}
					if (base.ActiveViewport.Grid.Visible)
					{
						double step = base.ActiveViewport.Grid.Step;
						Point3D point3D = new Point3D((double)(int)Math.Round(mousePlnLoc.X / step) * step, (double)(int)Math.Round(mousePlnLoc.Y / step) * step);
						if (base.CurrentSketch != null)
						{
							bool_0 = method_16(base.CurrentSketch.DrawingPlane.PointAt(point3D), mouseWorldLoc, bool_2: false) <= (double)clsVar.varEditorSet.snapGridPixel;
						}
						if (!(bool_0 & (clsInit.appEditor.action != actionTypeBU.None)))
						{
							return null;
						}
						if (!(clsVar.varEditorSet.OsnapGrid & !clsVar.varEditorRuntimeSet.OsnapGridDisable))
						{
							return null;
						}
						return new OsnapPoint(point3D, osnapType.Grid);
					}
					return null;
				}
				point_1 = point;
				bool_0 = point_1 != null;
				if (!(clsVar.varEditorSet.OsnapOver & !clsVar.varEditorRuntimeSet.OsnapOverDisable))
				{
					return null;
				}
				Point3D point3D2 = point_1.Position.Clone() as Point3D;
				if (base.CurrentTransformation != null)
				{
					point3D2.TransformBy(base.CurrentTransformation);
				}
				return new OsnapPoint(point3D2, osnapType.Over);
			}
			return null;
		}
		catch (Exception)
		{
			return null;
		}
	}

	private OsnapPoint method_17(OsnapPoint[] osnapPoint_2)
	{
		double num = double.MaxValue;
		int num2 = 0;
		int num3 = -1;
		foreach (OsnapPoint point in osnapPoint_2)
		{
			Point3D a = WorldToScreen(point);
			Point2D b = new Point2D(mouseloc.X, base.Size.Height - mouseloc.Y);
			double num4 = Point2D.Distance(a, b);
			if ((num4 < num) & (num4 <= (double)clsVar.varEditorSet.snapSymbolSize))
			{
				num3 = num2;
				num = num4;
			}
			num2++;
		}
		OsnapPoint result = null;
		if (num3 >= 0)
		{
			result = (OsnapPoint)osnapPoint_2.GetValue(num3);
		}
		return result;
	}

	private void method_18(OsnapPoint osnapPoint_2)
	{
		base.RenderContext.SetLineSize(2f);
		base.RenderContext.SetColorWireframe(Color.FromArgb(0, 0, 255));
		base.RenderContext.SetState(depthStencilStateType.DepthTestOff);
		Point2D point2D = WorldToScreen(osnapPoint_2);
		switch (osnapPoint_2.Type)
		{
		case osnapType.Over:
			DrawCircle(new System.Drawing.Point((int)point2D.X, (int)point2D.Y));
			DrawCross(new System.Drawing.Point((int)point2D.X, (int)point2D.Y));
			break;
		case osnapType.Grid:
			DrawCross(new System.Drawing.Point((int)point2D.X, (int)point2D.Y));
			DrawQuad(new System.Drawing.Point((int)point2D.X, (int)point2D.Y));
			break;
		case osnapType.Point:
			DrawQuad(new System.Drawing.Point((int)point2D.X, (int)point2D.Y));
			break;
		case osnapType.Center:
			DrawCircle(new System.Drawing.Point((int)point2D.X, (int)point2D.Y));
			break;
		case osnapType.Middle:
			DrawTriangle(new System.Drawing.Point((int)point2D.X, (int)point2D.Y));
			break;
		case osnapType.Outer:
			DrawRhombus(new System.Drawing.Point((int)point2D.X, (int)point2D.Y));
			break;
		}
		base.RenderContext.SetLineSize(1f);
	}

	private Entity method_19(System.Drawing.Point point_3, IList<Entity> ilist_0, ref Transformation transformation_0)
	{
		GetCrossingEntities(new Rectangle(point_3.X - 5, point_3.Y - 5, 10, 10), ilist_0, firstOnly: false, out var selectedIndices, selectableOnly: true, transformation_0);
		if (selectedIndices != null && selectedIndices.Length != 0)
		{
			if (ilist_0[selectedIndices[0]] is BlockReference)
			{
				BlockReference blockReference = (BlockReference)ilist_0[selectedIndices[0]];
				transformation_0 *= blockReference.GetFullTransformation(base.Blocks);
				return method_19(point_3, base.Blocks[blockReference.BlockName].Entities, ref transformation_0);
			}
			if (selectedIndices.Length == 1)
			{
				return ilist_0[selectedIndices[0]];
			}
			if (selectedIndices.Length > 1)
			{
				for (int i = 0; i <= selectedIndices.Length - 1; i++)
				{
					if (ilist_0[selectedIndices[i]] is ICurve)
					{
						return ilist_0[selectedIndices[i]];
					}
				}
			}
		}
		return null;
	}

	public OsnapPoint[] GetSnapPoints(System.Drawing.Point mouseLocation)
	{
		int pickBoxSize = base.PickBoxSize;
		base.PickBoxSize = 10;
		Transformation transformation_ = new Identity();
		Entity entity = method_19(mouseLocation, base.Entities, ref transformation_);
		base.PickBoxSize = pickBoxSize;
		OsnapPoint[] array = new OsnapPoint[0];
		if (entity != null && (clsVar.varEditorSet.OsnapEntity & !clsVar.varEditorRuntimeSet.OsnapEntityDisable))
		{
			if (!(entity is devDept.Eyeshot.Entities.Point))
			{
				if (!(entity is Line))
				{
					if (!(entity is LinearPath))
					{
						if (!(entity is CompositeCurve))
						{
							if (!(entity is Arc))
							{
								if (!(entity is Circle))
								{
									if (!(entity is Curve))
									{
										if (!(entity is EllipticalArc))
										{
											if (!(entity is Ellipse))
											{
												if (entity is Mesh)
												{
													Mesh mesh = (Mesh)entity;
													array = new OsnapPoint[mesh.Vertices.Length];
													for (int i = 0; i < mesh.Vertices.Length; i++)
													{
														Point3D point3D = mesh.Vertices[i];
														array[i] = new OsnapPoint(point3D, osnapType.Point);
													}
												}
											}
											else
											{
												Ellipse ellipse = (Ellipse)entity;
												array = new OsnapPoint[2]
												{
													new OsnapPoint(ellipse.EndPoint, osnapType.Point),
													new OsnapPoint(ellipse.Center, osnapType.Center)
												};
											}
										}
										else
										{
											EllipticalArc ellipticalArc = (EllipticalArc)entity;
											array = new OsnapPoint[3]
											{
												new OsnapPoint(ellipticalArc.StartPoint, osnapType.Point),
												new OsnapPoint(ellipticalArc.EndPoint, osnapType.Point),
												new OsnapPoint(ellipticalArc.Center, osnapType.Center)
											};
										}
									}
									else
									{
										Curve curve = (Curve)entity;
										array = new OsnapPoint[3]
										{
											new OsnapPoint(curve.StartPoint, osnapType.Point),
											new OsnapPoint(curve.EndPoint, osnapType.Point),
											new OsnapPoint(curve.PointAt(0.5), osnapType.Middle)
										};
									}
								}
								else
								{
									Circle circle = (Circle)entity;
									Point3D point3D2 = new Point3D(circle.Center.X, circle.Center.Y + circle.Radius);
									Point3D point3D3 = new Point3D(circle.Center.X + circle.Radius, circle.Center.Y);
									Point3D point3D4 = new Point3D(circle.Center.X, circle.Center.Y - circle.Radius);
									Point3D point3D5 = new Point3D(circle.Center.X - circle.Radius, circle.Center.Y);
									array = new OsnapPoint[6]
									{
										new OsnapPoint(circle.EndPoint, osnapType.Point),
										new OsnapPoint(circle.Center, osnapType.Center),
										new OsnapPoint(point3D2, osnapType.Outer),
										new OsnapPoint(point3D3, osnapType.Outer),
										new OsnapPoint(point3D4, osnapType.Outer),
										new OsnapPoint(point3D5, osnapType.Outer)
									};
								}
							}
							else
							{
								Arc arc = (Arc)entity;
								array = new OsnapPoint[4]
								{
									new OsnapPoint(arc.StartPoint, osnapType.Point),
									new OsnapPoint(arc.EndPoint, osnapType.Point),
									new OsnapPoint(arc.MidPoint, osnapType.Middle),
									new OsnapPoint(arc.Center, osnapType.Center)
								};
							}
						}
						else
						{
							CompositeCurve compositeCurve = (CompositeCurve)entity;
							List<OsnapPoint> list = new List<OsnapPoint>();
							foreach (ICurve curve2 in compositeCurve.CurveList)
							{
								list.Add(new OsnapPoint(curve2.EndPoint, osnapType.Point));
							}
							list.Add(new OsnapPoint(compositeCurve.CurveList[0].StartPoint, osnapType.Point));
							array = list.ToArray();
						}
					}
					else
					{
						LinearPath linearPath = (LinearPath)entity;
						List<OsnapPoint> list2 = new List<OsnapPoint>();
						Point3D[] vertices = linearPath.Vertices;
						foreach (Point3D point3D6 in vertices)
						{
							list2.Add(new OsnapPoint(point3D6, osnapType.Point));
						}
						array = list2.ToArray();
					}
				}
				else
				{
					Line line = (Line)entity;
					array = new OsnapPoint[3]
					{
						new OsnapPoint(line.StartPoint, osnapType.Point),
						new OsnapPoint(line.EndPoint, osnapType.Point),
						new OsnapPoint(line.MidPoint, osnapType.Middle)
					};
				}
			}
			else if (!clsVar.varEditorRuntimeSet.OsnapPointDisable)
			{
				devDept.Eyeshot.Entities.Point point = (devDept.Eyeshot.Entities.Point)entity;
				Point3D point3D7 = point.Vertices[0];
				array = new OsnapPoint[1]
				{
					new OsnapPoint(point3D7, osnapType.Point)
				};
			}
		}
		if (transformation_ != new Identity())
		{
			OsnapPoint[] array2 = array;
			foreach (OsnapPoint osnapPoint in array2)
			{
				Point3D point3D8 = transformation_ * osnapPoint;
				osnapPoint.X = point3D8.X;
				osnapPoint.Y = point3D8.Y;
				osnapPoint.Z = point3D8.Z;
			}
		}
		return array;
	}

	public void DrawCross(System.Drawing.Point onScreen)
	{
		double num = onScreen.X + clsVar.varEditorSet.snapSymbolSize / 2;
		double num2 = onScreen.Y + clsVar.varEditorSet.snapSymbolSize / 2;
		double num3 = onScreen.X - clsVar.varEditorSet.snapSymbolSize / 2;
		double num4 = onScreen.Y - clsVar.varEditorSet.snapSymbolSize / 2;
		Point3D point3D = new Point3D(num3, num2);
		Point3D point3D2 = new Point3D(num, num2);
		Point3D point3D3 = new Point3D(num, num4);
		Point3D point3D4 = new Point3D(num3, num4);
		base.RenderContext.DrawLines(new Point3D[4] { point3D4, point3D2, point3D, point3D3 });
	}

	public void DrawCircle(System.Drawing.Point onScreen)
	{
		double num = clsVar.varEditorSet.snapSymbolSize / 2;
		double num2 = 0.0;
		double num3 = 0.0;
		List<Point3D> list = new List<Point3D>();
		for (int i = 0; i < 360; i += 10)
		{
			double num4 = Utility.DegToRad(i);
			num2 = (double)onScreen.X + num * Math.Cos(num4);
			num3 = (double)onScreen.Y + num * Math.Sin(num4);
			Point3D item = new Point3D(num2, num3);
			list.Add(item);
		}
		base.RenderContext.DrawLineLoop(list.ToArray());
	}

	public void DrawQuad(System.Drawing.Point onScreen)
	{
		double num = onScreen.X + clsVar.varEditorSet.snapSymbolSize / 2;
		double num2 = onScreen.Y + clsVar.varEditorSet.snapSymbolSize / 2;
		double num3 = onScreen.X - clsVar.varEditorSet.snapSymbolSize / 2;
		double num4 = onScreen.Y - clsVar.varEditorSet.snapSymbolSize / 2;
		Point3D point3D = new Point3D(num3, num2);
		Point3D point3D2 = new Point3D(num, num2);
		Point3D point3D3 = new Point3D(num, num4);
		Point3D point3D4 = new Point3D(num3, num4);
		base.RenderContext.DrawLineLoop(new Point3D[4] { point3D4, point3D3, point3D2, point3D });
	}

	public void DrawTriangle(System.Drawing.Point onScreen)
	{
		double num = onScreen.X + clsVar.varEditorSet.snapSymbolSize / 2;
		double num2 = onScreen.Y + clsVar.varEditorSet.snapSymbolSize / 2;
		double num3 = onScreen.X - clsVar.varEditorSet.snapSymbolSize / 2;
		double num4 = onScreen.Y - clsVar.varEditorSet.snapSymbolSize / 2;
		double num5 = onScreen.X;
		Point3D point3D = new Point3D(num5, num2);
		Point3D point3D2 = new Point3D(num, num4);
		Point3D point3D3 = new Point3D(num3, num4);
		base.RenderContext.DrawLineLoop(new Point3D[3] { point3D3, point3D2, point3D });
	}

	public void DrawRhombus(System.Drawing.Point onScreen)
	{
		double num = (double)onScreen.X + (double)clsVar.varEditorSet.snapSymbolSize / 1.5;
		double num2 = (double)onScreen.Y + (double)clsVar.varEditorSet.snapSymbolSize / 1.5;
		double num3 = (double)onScreen.X - (double)clsVar.varEditorSet.snapSymbolSize / 1.5;
		double num4 = (double)onScreen.Y - (double)clsVar.varEditorSet.snapSymbolSize / 1.5;
		Point3D point3D = new Point3D(onScreen.X, num2);
		Point3D point3D2 = new Point3D(onScreen.X, num4);
		Point3D point3D3 = new Point3D(num, onScreen.Y);
		Point3D point3D4 = new Point3D(num3, onScreen.Y);
		base.RenderContext.DrawLineLoop(new Point3D[4] { point3D2, point3D3, point3D, point3D4 });
	}

	static Sketcher2D()
	{
		isDrawing = false;
		isSelectionDone = false;
		isAreaSelection = false;
		selectionProcess = false;
		buttonPressedForSelection = false;
		OrthoPossible = false;
		FirstMove = false;
		ForbiddenAreaClicked = false;
		indexLabel = -1;
		rightClickCnt = 0;
		mouseWorldCoord = new Point3D();
		mousePlnLoc = new Point2D();
		DrawingPoints = new List<List<Point3D>>();
		Clicks = new List<UClick>();
		selectedPoint = new List<Point3D>();
		selectedCircle = new List<Circle>();
		entityMouseUnder = null;
		PixelVsMilimeter = 1.0;
		entitySelected = null;
		entitiesSelected = new List<Entity>();
		selectedIndex = new List<List<int>>();
		secondSelectedEntity = null;
		firstSelectedEntity = null;
	}

	[CompilerGenerated]
	private bool method_20(devDept.Eyeshot.Entities.Point point_3)
	{
		return method_16(point_3.Position, mouseWorldLoc, bool_2: true) <= (double)clsVar.varEditorSet.snapGridPixel;
	}

	[CompilerGenerated]
	private double method_21(devDept.Eyeshot.Entities.Point point_3)
	{
		return method_16(point_3.Position, mouseWorldLoc, bool_2: true);
	}

	private void HideRotateOriginals()
	{
		if (rotateHiddenEntities.Count > 0 || entitiesSelected == null)
		{
			return;
		}
		foreach (Entity item in entitiesSelected)
		{
			if (item != null && item.Visible)
			{
				rotateHiddenEntities.Add(item);
				item.Visible = false;
			}
		}
		Invalidate();
	}

	private void RestoreRotateOriginals()
	{
		for (int i = 0; i < rotateHiddenEntities.Count; i++)
		{
			Entity entity = rotateHiddenEntities[i];
			if (entity != null)
			{
				entity.Visible = true;
			}
		}
		rotateHiddenEntities.Clear();
		Invalidate();
	}
}
