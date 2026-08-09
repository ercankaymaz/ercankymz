using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Control.Labels;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;
using ns8;

namespace buCadCamResVer5.Editor;

public class Drafting2D : Design
{
	public class SnapPoint : Point3D
	{
		public objectSnapType Type;

		public SnapPoint()
		{
			Type = objectSnapType.None;
		}

		public SnapPoint(Point3D point3D, objectSnapType objectSnapType)
			: base(point3D.X, point3D.Y, point3D.Z)
		{
			Type = objectSnapType;
		}

		public override string ToString()
		{
			return base.ToString() + " | " + Type;
		}
	}

	private Timer timer_0 = null;

	private System.Drawing.Point point_0;

	public static Point3D boxMin = new Point3D();

	public static Point3D boxMid = new Point3D();

	public static Point3D boxMax = new Point3D();

	public Point3D current;

	public Point3D lastPoint;

	protected Point2D mousePlnLoc = new Point2D();

	public Plane plane = Plane.XY;

	public Plane drawingPlane;

	public static List<UClick> points = new List<UClick>();

	public double radius;

	public double radiusY;

	public double arcSpanAngle = 0.0;

	public bool editingMode;

	internal Point3D point3D_0 = null;

	public Point3D midPoint = null;

	public bool ObjectSnapEnabled;

	public static bool firstClick = true;

	public static bool selectionProcess = false;

	public static bool buttonPressedForSelection = false;

	public static bool _dragging = false;

	public string ActiveLayerName = "Default";

	public objectSnapType ActiveObjectSnap = objectSnapType.End;

	public bool currentlySnapping = false;

	public List<SnapPoint> snapPoints = new List<SnapPoint>();

	public static pickStateType currPickState;

	public static System.Drawing.Point mouseDownLocation;

	public int entityPickIndex = -1;

	public int selEntityIndex = -1;

	public static List<List<int>> selectedIndex = new List<List<int>>();

	public static Entity entitySelected = null;

	public static List<Entity> entitiesSelected = new List<Entity>();

	public List<Entity> selEntities = new List<Entity>();

	public static SelectedItem entityMouseUnder = null;

	internal int[] int_0 = null;

	public static Entity entToTrim;

	public static List<Entity> leftOvers = new List<Entity>();

	public Entity secondSelectedEntity = null;

	public Entity firstSelectedEntity = null;

	internal Point3D point3D_1;

	internal Point3D point3D_2;

	public static bool NoRectangleSelection = false;

	private ISelectableItem iselectableItem_0;

	public Drafting2D()
	{
		if (!IsDesignMode())
		{
			LoadDocument(new SketcherDesignDocument());
			base.WaitCursorMode = waitCursorType.Never;
			Clear();
			timer_0 = new Timer();
			timer_0.Interval = 100;
			timer_0.Tick += Tick_Add;
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		try
		{
			point_0 = e.Location;
			if (!(current == null) && base.ActionMode == actionType.None && !base.ToolBar.Contains(point_0))
			{
				if (base.CurrentSketch != null)
				{
					mousePlnLoc = base.CurrentSketch.DrawingPlane.Project(current);
				}
				if (clsItem.frmEditorV2 != null)
				{
					clsItem.frmEditorV2.lbl_x.Text = "X: " + current.X.ToString("f2");
					clsItem.frmEditorV2.lbl_y.Text = "Y: " + current.Y.ToString("f2");
				}
				int_0 = null;
				entityMouseUnder = GetItemUnderMouseCursor(point_0);
				int_0 = GetAllEntitiesUnderMouseCursor(point_0);
				int labelUnderMouseCursor = GetLabelUnderMouseCursor(e.Location);
				if (entityMouseUnder == null)
				{
				}
				if (entityMouseUnder == null && labelUnderMouseCursor >= 0 && base.ActiveViewport.Labels[labelUnderMouseCursor] is StackedLabel)
				{
					base.CurrentSketch.DisplayConstraintEntities((base.ActiveViewport.Labels[labelUnderMouseCursor] as StackedLabel).Constraint);
				}
				if (buttonPressedForSelection & selectionProcess)
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
					if (ccVars.selectionOnlyPick | NoRectangleSelection)
					{
						currPickState = pickStateType.Pick;
					}
				}
				if (clsInit.appEditor2.action == actionTypeBU.eventTrim)
				{
					method_14();
				}
				PaintBackBuffer();
				SwapBuffers();
				base.OnMouseMove(e);
			}
			else
			{
				base.OnMouseMove(e);
			}
		}
		catch (Exception)
		{
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		try
		{
			System.Drawing.Point location = e.Location;
			mouseDownLocation = e.Location;
			if (!base.ToolBar.Contains(location))
			{
				Entity entity = null;
				iselectableItem_0 = GetEntityByPosition(e.Location);
				if (iselectableItem_0 is Entity)
				{
					entity = (Entity)iselectableItem_0;
					if (clsVar.varEditorRuntimeSet.isSketchMode)
					{
						_dragging = true;
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
				ScreenToPlane(location, plane, out current);
				PointToOsnap();
				if ((e.Button == MouseButtons.Left) & selectionProcess & selectionProcess & !_dragging)
				{
					buttonPressedForSelection = true;
					mouseDownLocation = e.Location;
					currPickState = pickStateType.Pick;
				}
				selEntityIndex = GetEntityUnderMouseCursor(location);
				if (((base.ActionMode == actionType.None) & (clsInit.appEditor2.action != actionTypeBU.None)) && e.Button == MouseButtons.Left && !selectionProcess)
				{
					points.Add(new UClick(new Point2D(current.X, current.Y), current, entity));
					if (clsInit.appEditor2.action != actionTypeBU.drawLine)
					{
						if (clsInit.appEditor2.action != actionTypeBU.drawPolyline)
						{
							if (clsInit.appEditor2.action != actionTypeBU.drawPoint || points.Count != 1)
							{
								if (clsInit.appEditor2.action != actionTypeBU.drawCircle)
								{
									if (clsInit.appEditor2.action != actionTypeBU.drawCircle3Point)
									{
										if (clsInit.appEditor2.action != actionTypeBU.drawArc)
										{
											if (clsInit.appEditor2.action != actionTypeBU.drawArc3Point)
											{
												if (clsInit.appEditor2.action != actionTypeBU.drawEllipse)
												{
													if (clsInit.appEditor2.action != actionTypeBU.drawRectangle)
													{
														if (clsInit.appEditor2.action != actionTypeBU.drawPolygon)
														{
															if (clsInit.appEditor2.action != actionTypeBU.drawSlot)
															{
																if (clsInit.appEditor2.action == actionTypeBU.drawCurve && points.Count >= 3)
																{
																	clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineNextPoint, buLangTranslate.preDef.Curve);
																	if (buCompare5.EQ(points[0].Pnt3D, points.Last().Pnt3D))
																	{
																		clsInit.appEditor2.AddCurve(points);
																	}
																}
															}
															else
															{
																if (points.Count == 1)
																{
																	clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineSecondPoint, buLangTranslate.preDef.Slot);
																}
																if (points.Count == 2)
																{
																	clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineOutsidePoint, buLangTranslate.preDef.Slot);
																}
																if (points.Count == 3)
																{
																	clsInit.appEditor2.AddSlot(points[0], points[1], points[2]);
																}
															}
														}
														else
														{
															if (points.Count == 1)
															{
																clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineOutsidePoint, buLangTranslate.preDef.Polygon);
															}
															if (points.Count == 2)
															{
																clsInit.appEditor2.AddPolygon(points[0], points[1]);
															}
														}
													}
													else
													{
														if (points.Count == 1)
														{
															clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineSecondPoint, buLangTranslate.preDef.Ellipse);
														}
														if (points.Count == 2)
														{
															clsInit.appEditor2.AddRectangle(points[0], points[1]);
														}
													}
												}
												else if (!clsVar.varEditorRuntimeSet.isSketchMode)
												{
													if (points.Count == 1)
													{
														clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineSecondPoint, buLangTranslate.preDef.Ellipse);
													}
													if (points.Count == 2)
													{
														clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineOutsidePoint, buLangTranslate.preDef.Ellipse);
													}
													if (points.Count == 3)
													{
														Ellipse ent = new Ellipse(drawingPlane, drawingPlane.Origin, radius, radiusY);
														clsInit.appEditor2.AddEllipse(ent);
													}
												}
												else
												{
													if (points.Count == 1)
													{
														clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineOutsidePoint, buLangTranslate.preDef.Ellipse);
													}
													if (points.Count == 2)
													{
														clsInit.appEditor2.AddEllipse(points[0], points[1]);
													}
												}
											}
											else
											{
												if (points.Count == 1)
												{
													clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineThirdPoint, buLangTranslate.preDef.Arc);
												}
												if (points.Count == 2)
												{
													clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineSecondPoint, buLangTranslate.preDef.Arc);
												}
												if (points.Count == 3 && ((Point2D.Distance(points[0].Pnt3D, points[1].Position) > 0.0) & (Point2D.Distance(points[0].Pnt3D, points[2].Position) > 0.0) & (Point2D.Distance(points[1].Position, points[2].Position) > 0.0)) && clsInit.appEditor.EvaluateArc(points[0].Pnt3D, points[2].Position, points[1].Position, out var _))
												{
													clsInit.appEditor2.AddArc(points[0], points[2], points[1]);
												}
											}
										}
										else
										{
											if (points.Count == 1)
											{
												clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineNextPoint, buLangTranslate.preDef.Arc);
											}
											if (points.Count == 2)
											{
												clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineLastPoint, buLangTranslate.preDef.Arc);
											}
											if (points.Count == 3)
											{
												drawingPlane = Class5.smethod_209(this, points[1].Pnt3D);
												Vector2D vector2D = new Vector2D(points[0].Pnt3D, points[1].Pnt3D);
												vector2D.Normalize();
												Vector2D vector2D2 = new Vector2D(points[0].Pnt3D, current);
												vector2D2.Normalize();
												arcSpanAngle = Vector2D.SignedAngleBetween(vector2D, vector2D2);
												clsInit.appEditor2.AddArc(drawingPlane, drawingPlane.Origin, radius, 0.0, arcSpanAngle);
											}
										}
									}
									else
									{
										if (points.Count == 1)
										{
											clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineSecondPoint, buLangTranslate.preDef.Cirlce);
										}
										if (points.Count == 2)
										{
											clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineThirdPoint, buLangTranslate.preDef.Cirlce);
										}
										if (points.Count == 3 && ((Point2D.Distance(points[0].Pnt3D, points[1].Position) > 0.0) & (Point2D.Distance(points[0].Pnt3D, points[2].Position) > 0.0) & (Point2D.Distance(points[1].Position, points[2].Position) > 0.0)))
										{
											clsInit.appEditor2.AddCircle(points[0], points[1], points[2]);
										}
									}
								}
								else
								{
									if (points.Count == 1)
									{
										clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineOutsidePoint, buLangTranslate.preDef.Cirlce);
									}
									if (points.Count == 2)
									{
										clsInit.appEditor2.AddCircle(points[0], points[1]);
									}
								}
							}
							else
							{
								clsInit.appEditor2.AddPoint(points[0]);
							}
						}
						else
						{
							clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineNextPoint, buLangTranslate.preDef.Polyline);
							if (points.Count >= 2 && buCompare5.EQ(points[0].Pnt3D, points[points.Count - 1].Position))
							{
								clsInit.appEditor2.AddPolyLine(points);
							}
						}
					}
					else
					{
						clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineNextPoint, buLangTranslate.preDef.Line);
						if (clsVar.varEditorRuntimeSet.isSketchMode)
						{
							if (points.Count != 2)
							{
								if (points.Count > 2)
								{
									points[points.Count - 1].Entity = clsInit.appEditor2.ExtendLine((Line)points[points.Count - 2].Entity, points[points.Count - 1]);
									if (buCompare5.EQ(points[0].Position, points[points.Count - 1].Position))
									{
										ClearAllPreviousCommandData();
										clsItem.frmEditorV2.viewport.CurrentSketch.UpdateAndInvalidate();
									}
								}
							}
							else
							{
								points[points.Count - 1].Entity = clsInit.appEditor2.AddLine(points[points.Count - 2], points[points.Count - 1]);
							}
						}
						else if (points.Count >= 2)
						{
							clsInit.appEditor2.AddLine(points[points.Count - 2], points[points.Count - 1]);
						}
					}
					if (lastPoint == null)
					{
						lastPoint = new Point3D();
					}
					lastPoint.X = current.X;
					lastPoint.Y = current.Y;
					if (clsInit.appEditor2.action == actionTypeBU.eventMove)
					{
						if (points.Count == 1)
						{
							clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineMovePoint, buLangTranslate.preDef.Move);
						}
						if (points.Count == 2)
						{
							EventMove();
						}
					}
					if (clsInit.appEditor2.action == actionTypeBU.eventCopy)
					{
						if (points.Count == 1)
						{
							clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineCopyPoint, buLangTranslate.preDef.Copy);
						}
						if (points.Count == 2)
						{
							EventCopy();
						}
					}
					if (clsInit.appEditor2.action == actionTypeBU.eventRotate)
					{
						if (points.Count == 1)
						{
							clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineReferancePoint, buLangTranslate.preDef.Rotate);
						}
						if (points.Count == 2)
						{
							clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineRotatePoint, buLangTranslate.preDef.Rotate);
						}
						if (points.Count == 3)
						{
							EventRotate();
						}
					}
					if (clsInit.appEditor2.action == actionTypeBU.eventMirror)
					{
						if (points.Count == 1)
						{
							clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineMirrorPoint, buLangTranslate.preDef.Mirror);
						}
						if (points.Count == 2)
						{
							EventMirror();
						}
					}
					if (clsInit.appEditor2.action == actionTypeBU.eventScale)
					{
						if (points.Count == 1)
						{
							clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineReferancePoint, buLangTranslate.preDef.Scale);
						}
						if (points.Count == 2)
						{
							clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineScalePoint, buLangTranslate.preDef.Scale);
						}
						if (points.Count == 3)
						{
							EventScale();
						}
					}
					if (clsInit.appEditor2.action == actionTypeBU.eventOffset && points.Count == 1)
					{
						EventOffset();
					}
					if (clsInit.appEditor2.action == actionTypeBU.libraryVertical && entity != null && entity is Line)
					{
						clsInit.appEditor2.CreateConstraintVertical((Line)entity);
					}
					if (clsInit.appEditor2.action == actionTypeBU.libraryHorizontal && entity != null && entity is Line)
					{
						clsInit.appEditor2.CreateConstraintHorizontal((Line)entity);
					}
					if (clsInit.appEditor2.action == actionTypeBU.libraryLength && entity != null && entity is Line)
					{
						clsInit.appEditor2.CreateConstraintVertical((Line)entity);
					}
				}
				if (base.ActionMode == actionType.None && e.Button == MouseButtons.Right)
				{
					if (clsInit.appEditor2.action != actionTypeBU.drawPolyline)
					{
						if (clsInit.appEditor2.action != actionTypeBU.drawCurve)
						{
							if (clsInit.appEditor2.action == actionTypeBU.drawLine)
							{
								ClearAllPreviousCommandData();
							}
						}
						else if (points.Count >= 2)
						{
							clsInit.appEditor2.AddCurve(points);
						}
					}
					else if (points.Count >= 2)
					{
						clsInit.appEditor2.AddPolyLine(points);
					}
					if (clsInit.appEditor2.action == actionTypeBU.eventDelete)
					{
						EventDelete();
					}
					if ((clsInit.appEditor2.action == actionTypeBU.eventMove) | (clsInit.appEditor2.action == actionTypeBU.eventCopy) | (clsInit.appEditor2.action == actionTypeBU.eventMirror) | (clsInit.appEditor2.action == actionTypeBU.eventRotate) | (clsInit.appEditor2.action == actionTypeBU.eventOffset) | (clsInit.appEditor2.action == actionTypeBU.eventScale) | (clsInit.appEditor2.action == actionTypeBU.eventLineerArray))
					{
						if (clsInit.appEditor2.action == actionTypeBU.eventMove)
						{
							clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineReferancePoint, buLangTranslate.preDef.Move);
						}
						if (clsInit.appEditor2.action == actionTypeBU.eventCopy)
						{
							clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineReferancePoint, buLangTranslate.preDef.Copy);
						}
						if (clsInit.appEditor2.action == actionTypeBU.eventMirror)
						{
							clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineReferancePoint, buLangTranslate.preDef.Mirror);
						}
						if ((clsInit.appEditor2.action == actionTypeBU.eventMove) | (clsInit.appEditor2.action == actionTypeBU.eventCopy) | (clsInit.appEditor2.action == actionTypeBU.eventMirror))
						{
							clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineReferancePoint, buLangTranslate.preDef.Move);
						}
						if (clsInit.appEditor2.action == actionTypeBU.eventRotate)
						{
							clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineCenterPoint, buLangTranslate.preDef.Move);
						}
						if (clsInit.appEditor2.action == actionTypeBU.eventOffset)
						{
							clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineOffsetPoint, buLangTranslate.preDef.Offset);
						}
						if (clsInit.appEditor2.action == actionTypeBU.eventScale)
						{
							clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineFirstPoint, buLangTranslate.preDef.Scale);
						}
						EventCopyToSelected();
					}
				}
				base.OnMouseDown(e);
			}
			else
			{
				base.OnMouseDown(e);
			}
		}
		catch (Exception)
		{
		}
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		int[] selectedIndices = null;
		entityPickIndex = -1;
		if (selectionProcess & (e.Button == MouseButtons.Left) & buttonPressedForSelection)
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
				int num = e.Location.X - mouseDownLocation.X;
				int num2 = e.Location.Y - mouseDownLocation.Y;
				System.Drawing.Point point_ = mouseDownLocation;
				System.Drawing.Point location = e.Location;
				Class5.smethod_158(ref location, ref point_);
				switch (currPickState)
				{
				case pickStateType.Crossing:
				{
					if (num == 0 || num2 == 0)
					{
						break;
					}
					GetCrossingEntities(new Rectangle(point_, new Size(Math.Abs(num), Math.Abs(num2))), firstOnly: false, out selectedIndices);
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
				case pickStateType.Pick:
					entityPickIndex = GetEntityUnderMouseCursor(e.Location);
					GetAllEntitiesUnderMouseCursor(e.Location);
					if (entityPickIndex >= 0 && base.Entities[entityPickIndex].Selectable)
					{
						if (base.Entities[entityPickIndex].Selected)
						{
							base.Entities[entityPickIndex].Selected = false;
						}
						else
						{
							base.Entities[entityPickIndex].Selected = true;
						}
					}
					break;
				case pickStateType.Enclosed:
				{
					if (num == 0 || num2 == 0)
					{
						break;
					}
					GetEnclosedEntities(new Rectangle(point_, new Size(Math.Abs(num), Math.Abs(num2))), firstOnly: false, out selectedIndices);
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
				if (e.Button != MouseButtons.Left || selectedIndices == null || selectedIndices.Length == 0)
				{
				}
				Invalidate();
			}
		}
		if (((base.ActionMode == actionType.None) & (clsInit.appEditor2.action != actionTypeBU.None)) && e.Button == MouseButtons.Left)
		{
			if (selectionProcess)
			{
				if (clsInit.appEditor2.action == actionTypeBU.eventFillet)
				{
					if (firstSelectedEntity == null)
					{
						if (selEntityIndex != -1)
						{
							firstSelectedEntity = base.Entities[selEntityIndex];
							selEntityIndex = -1;
							ScreenToPlane(point_0, Plane.XY, out point3D_1);
							clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.SelectSecondEntity, buLangTranslate.preDef.Fillet);
						}
						return;
					}
					if (secondSelectedEntity == null && selEntityIndex != -1)
					{
						secondSelectedEntity = base.Entities[selEntityIndex];
						selEntityIndex = -1;
						ScreenToPlane(point_0, Plane.XY, out point3D_2);
						EventFillet();
					}
				}
				if (clsInit.appEditor2.action == actionTypeBU.eventChamfer)
				{
					if (firstSelectedEntity == null)
					{
						if (selEntityIndex != -1)
						{
							firstSelectedEntity = base.Entities[selEntityIndex];
							selEntityIndex = -1;
							ScreenToPlane(point_0, Plane.XY, out point3D_1);
							clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.SelectSecondEntity, buLangTranslate.preDef.Chamfer);
						}
						return;
					}
					if (secondSelectedEntity == null && selEntityIndex != -1)
					{
						secondSelectedEntity = base.Entities[selEntityIndex];
						selEntityIndex = -1;
						ScreenToPlane(point_0, Plane.XY, out point3D_2);
						EventChamfer();
					}
				}
			}
			else
			{
				if (clsInit.appEditor2.action == actionTypeBU.eventBreak && points.Count == 1)
				{
					EventBreak();
				}
				if (clsInit.appEditor2.action == actionTypeBU.eventTrim && points.Count == 1)
				{
					EventTrim();
				}
				if (clsInit.appEditor2.action == actionTypeBU.eventExtend)
				{
					EventExtend();
				}
			}
		}
		if (_dragging)
		{
			base.CurrentSketch.DragEnd();
			_dragging = false;
		}
		base.OnMouseUp(e);
	}

	protected override void DrawOverlay(DrawSceneParams data)
	{
		ScreenToPlane(point_0, plane, out current);
		PointToOsnap();
		if (buttonPressedForSelection)
		{
			if (currPickState != pickStateType.Crossing)
			{
				if (currPickState == pickStateType.Enclosed)
				{
					method_0(mouseDownLocation, point_0, clsVar.varSelection.colorSelectionRightToLeft, clsVar.varSelection.SelectionTransparancy, bool_0: true, bool_1: false);
				}
			}
			else
			{
				method_0(mouseDownLocation, point_0, clsVar.varSelection.colorSelectionLeftToRight, clsVar.varSelection.SelectionTransparancy, bool_0: true, bool_1: true);
			}
		}
		if (clsInit.appEditor2.action != actionTypeBU.drawLine)
		{
			if (clsInit.appEditor2.action != actionTypeBU.drawPolyline)
			{
				if (clsInit.appEditor2.action != actionTypeBU.drawCircle || points.Count <= 0)
				{
					if (clsInit.appEditor2.action != actionTypeBU.drawCircle3Point || points.Count <= 0)
					{
						if (clsInit.appEditor2.action != actionTypeBU.drawArc || points.Count <= 0)
						{
							if (clsInit.appEditor2.action != actionTypeBU.drawArc3Point || points.Count <= 0)
							{
								if (clsInit.appEditor2.action != actionTypeBU.drawEllipse || points.Count <= 0)
								{
									if (clsInit.appEditor2.action != actionTypeBU.drawCurve)
									{
										if (clsInit.appEditor2.action != actionTypeBU.drawRectangle)
										{
											if (clsInit.appEditor2.action != actionTypeBU.drawPolygon)
											{
												if (clsInit.appEditor2.action == actionTypeBU.drawSlot)
												{
													if (points.Count == 1)
													{
														method_1();
													}
													if (points.Count == 2)
													{
														method_6();
													}
												}
											}
											else
											{
												method_5();
											}
										}
										else if (points.Count > 0)
										{
											ICurve icurve_ = new Line(Plane.XY, points[0].Pnt3D.X, points[0].Pnt3D.Y, current.X, points[0].Pnt3D.Y);
											Color colorDynamic = clsVar.varEditorSet.colorDynamic;
											Class5.smethod_183(colorDynamic, this, icurve_);
											icurve_ = new Line(Plane.XY, current.X, points[0].Pnt3D.Y, current.X, current.Y);
											colorDynamic = clsVar.varEditorSet.colorDynamic;
											Class5.smethod_183(colorDynamic, this, icurve_);
											icurve_ = new Line(Plane.XY, current.X, current.Y, points[0].Pnt3D.X, current.Y);
											colorDynamic = clsVar.varEditorSet.colorDynamic;
											Class5.smethod_183(colorDynamic, this, icurve_);
											icurve_ = new Line(Plane.XY, points[0].Pnt3D.X, current.Y, points[0].Pnt3D.X, points[0].Pnt3D.Y);
											colorDynamic = clsVar.varEditorSet.colorDynamic;
											Class5.smethod_183(colorDynamic, this, icurve_);
										}
									}
									else
									{
										method_9();
									}
								}
								else
								{
									method_4();
								}
							}
							else if (base.ActionMode == actionType.None && !base.ToolBar.Contains(point_0))
							{
								if (points.Count == 1)
								{
									method_1();
								}
								if (points.Count == 2)
								{
									Class5.smethod_45(this);
								}
							}
						}
						else if (base.ActionMode == actionType.None && !base.ToolBar.Contains(point_0))
						{
							method_3();
						}
					}
					else if (base.ActionMode == actionType.None && !base.ToolBar.Contains(point_0))
					{
						if (points.Count == 1)
						{
							method_1();
						}
						if (points.Count == 2)
						{
							Class5.smethod_190(this);
						}
					}
				}
				else if (base.ActionMode == actionType.None && !base.ToolBar.Contains(point_0))
				{
					Class5.smethod_66(this);
				}
			}
			else
			{
				method_1();
			}
		}
		else
		{
			method_1();
		}
		if (clsInit.appEditor2.action == actionTypeBU.eventMove && selEntities.Count > 0)
		{
			method_11();
		}
		if (clsInit.appEditor2.action == actionTypeBU.eventCopy && selEntities.Count > 0)
		{
			method_11();
		}
		if (clsInit.appEditor2.action == actionTypeBU.eventRotate && selEntities.Count > 0)
		{
			EventRotateEntity();
		}
		if (clsInit.appEditor2.action == actionTypeBU.eventMirror && selEntities.Count > 0)
		{
			method_12();
		}
		if (clsInit.appEditor2.action == actionTypeBU.eventScale && selEntities.Count > 0)
		{
			method_13();
		}
		if (clsInit.appEditor2.action == actionTypeBU.eventOffset && selEntities.Count > 0)
		{
			EventOffsetEntity();
		}
		if (clsInit.appEditor2.action == actionTypeBU.eventBreak && entityMouseUnder != null && entityMouseUnder.Item != null)
		{
			Class5.smethod_196(this);
		}
		if (clsInit.appEditor2.action == actionTypeBU.eventTrim)
		{
			method_7();
		}
		if (clsInit.appEditor2.action == actionTypeBU.eventExtend && entityMouseUnder != null && entityMouseUnder.Item != null)
		{
			Class5.smethod_63(this);
		}
		if (entityMouseUnder != null && entityMouseUnder.Item is ICurve)
		{
			method_8((ICurve)entityMouseUnder.Item, Color.Red);
		}
		base.DrawOverlay(data);
	}

	public void MouseDownDrawings(Entity ent, MouseEventArgs mea)
	{
	}

	public void MouseDownEvents(int[] indx, MouseEventArgs mea)
	{
	}

	private void method_0(System.Drawing.Point point_1, System.Drawing.Point point_2, Color color_0, int int_1, bool bool_0, bool bool_1)
	{
		point_1.Y = base.Height - point_1.Y;
		point_2.Y = base.Height - point_2.Y;
		Class5.smethod_158(ref point_2, ref point_1);
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
		base.RenderContext.SetColorWireframe(Color.FromArgb(int_1, color_0.R, color_0.G, color_0.B));
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

	private void method_1()
	{
		if (points.Count != 0)
		{
			Point2D[] array = method_16(clsInit.appEditor2.ClicksToPoints(points));
			base.RenderContext.SetLineSize((float)clsVar.varEditorSet.DrawThickness + 1f);
			base.RenderContext.DrawLineStrip(array);
			if (base.ActionMode == actionType.None && !base.ToolBar.Contains(point_0) && points.Count > 0)
			{
				base.RenderContext.DrawLine(array[array.Length - 1], WorldToScreen(current));
			}
		}
	}

	private void method_2(List<Point3D> list_0)
	{
		if (points.Count != 0)
		{
			Point2D[] vertices = method_16(list_0);
			base.RenderContext.SetLineSize((float)clsVar.varEditorSet.DrawThickness + 1f);
			base.RenderContext.DrawLineStrip(vertices);
		}
	}

	private void method_3()
	{
		Point2D[] vertices = method_16(clsInit.appEditor2.ClicksToPoints(points));
		base.RenderContext.SetLineSize((float)clsVar.varEditorSet.DrawThickness + 1f);
		base.RenderContext.DrawLineStrip(vertices);
		if (base.ActionMode != actionType.None || base.ToolBar.Contains(point_0) || points.Count <= 0)
		{
			return;
		}
		base.RenderContext.DrawLine(WorldToScreen(points[0].Pnt3D), WorldToScreen(current));
		if (points.Count != 2)
		{
			return;
		}
		radius = points[0].Pnt3D.DistanceTo(points[1].Pnt3D);
		if (radius > 0.001)
		{
			drawingPlane = Class5.smethod_209(this, points[1].Pnt3D);
			Vector2D vector2D = new Vector2D(points[0].Pnt3D, points[1].Pnt3D);
			vector2D.Normalize();
			Vector2D vector2D2 = new Vector2D(points[0].Pnt3D, current);
			vector2D2.Normalize();
			arcSpanAngle = Vector2D.SignedAngleBetween(vector2D, vector2D2);
			if (Math.Abs(arcSpanAngle) > 0.001)
			{
				Arc icurve_ = new Arc(drawingPlane, drawingPlane.Origin, radius, 0.0, arcSpanAngle);
				Class5.smethod_183(clsVar.varEditorSet.colorDynamic, this, (ICurve)icurve_);
			}
		}
	}

	private void method_4()
	{
		if (clsInit.appEditor2.action == actionTypeBU.drawEllipseArc && points.Count > 2)
		{
			return;
		}
		base.RenderContext.SetLineSize((float)clsVar.varEditorSet.DrawThickness + 1f);
		if (points.Count == 1)
		{
			base.RenderContext.DrawLine(WorldToScreen(points[0].Pnt3D), WorldToScreen(current));
		}
		if (points.Count >= 2)
		{
			midPoint = Point3D.MidPoint(points[0].Pnt3D, points[1].Pnt3D);
			radius = midPoint.DistanceTo(points[1].Pnt3D);
			radiusY = current.DistanceTo(new Segment2D(points[0].Pnt3D, points[1].Pnt3D));
			if (!(radius <= 0.001) && radiusY > 0.001)
			{
				Point3D point3D = midPoint;
				Point3D pnt3D = points[1].Pnt3D;
				drawingPlane = Class5.smethod_11(pnt3D, point3D, this);
				method_10(midPoint);
				Ellipse icurve_ = new Ellipse(drawingPlane, drawingPlane.Origin, radius, radiusY);
				Class5.smethod_183(clsVar.varEditorSet.colorDynamic, this, (ICurve)icurve_);
			}
		}
	}

	private void method_5()
	{
		if (points.Count != 0)
		{
			base.RenderContext.SetLineSize((float)clsVar.varEditorSet.DrawThickness + 1f);
			if (points.Count == 1)
			{
				base.RenderContext.DrawLine(WorldToScreen(points[0].Pnt3D), WorldToScreen(current));
			}
			List<Pnt3D> Vertices = new List<Pnt3D>();
			clsInit.cVector.PolygonCenter(new Pnt3D(points[0].Pnt3D.X, points[0].Pnt3D.Y), new Pnt3D(current.X, current.Y), clsVar.varEditorRuntimeSet.PolygonSide, new WorkPlane(planeType.XY, 1), ref Vertices);
			List<Point3D> CopiedPnt = new List<Point3D>();
			buConversion5.Pnt3DToPoint3D(Vertices, ref CopiedPnt);
			if (CopiedPnt.Count >= 2)
			{
				drawingPlane = Plane.XY;
				method_10(points[0].Pnt3D);
				method_2(CopiedPnt);
			}
		}
	}

	private void method_6()
	{
		if (points.Count > 1)
		{
			base.RenderContext.SetLineSize((float)clsVar.varEditorSet.DrawThickness + 1f);
			base.RenderContext.DrawLine(WorldToScreen(points[0].Pnt3D), WorldToScreen(points[1].Pnt3D));
			new List<Point3D>();
			Entity entity = clsInit.cVector5.Slot3Point(points[0].Pnt3D, points[1].Pnt3D, current, Plane.XY);
			Class5.smethod_183(clsVar.varEditorSet.colorDynamic, this, (ICurve)entity);
		}
	}

	private void method_7()
	{
		base.RenderContext.EnableXOR(enable: false);
		if (leftOvers.Count <= 0)
		{
			if (entToTrim != null)
			{
				ICurve icurve_ = entToTrim as ICurve;
				Color colorSecondPart = clsVar.varEditorSet.colorSecondPart;
				Class5.smethod_183(colorSecondPart, this, icurve_);
			}
		}
		else
		{
			ICurve icurve_ = entToTrim as ICurve;
			Color colorSecondPart = clsVar.varEditorSet.colorFirstPart;
			Class5.smethod_183(colorSecondPart, this, icurve_);
			foreach (Entity leftOver in leftOvers)
			{
				Class5.smethod_183(clsVar.varEditorSet.colorSecondPart, this, leftOver as ICurve);
			}
		}
		base.RenderContext.EnableXOR(enable: true);
	}

	internal void method_8(ICurve icurve_0, Color color_0)
	{
		Point3D[] array = new Point3D[101];
		for (int i = 0; i <= 100; i++)
		{
			array[i] = WorldToScreen(icurve_0.PointAt(icurve_0.Domain.ParameterAt((double)i / 100.0)));
		}
		base.RenderContext.SetLineSize((float)clsVar.varEditorSet.DrawThickness + 1f);
		base.RenderContext.SetColorWireframe(color_0);
		base.RenderContext.DrawLineStrip(array);
	}

	private void method_9()
	{
		List<Point3D> list = new List<Point3D>(clsInit.appEditor2.ClicksToPoints(points));
		list.Add(method_17(point_0, plane, clsInit.appEditor2.ClicksToPoints(points), 0));
		base.RenderContext.SetLineSize((float)clsVar.varEditorSet.DrawThickness + 1f);
		if (points.Count <= 1)
		{
			base.RenderContext.DrawLineStrip(method_16(list));
			return;
		}
		Curve icurve_ = Curve.CubicSplineInterpolation(list);
		Class5.smethod_183(clsVar.varEditorSet.colorDynamic, this, (ICurve)icurve_);
	}

	internal void method_10(Point3D point3D_3, double double_0 = 20.0)
	{
		if (clsInit.appEditor2.action != actionTypeBU.drawDimAlinged && clsInit.appEditor2.action != actionTypeBU.drawDimAngular && clsInit.appEditor2.action != actionTypeBU.drawDimLeader && clsInit.appEditor2.action != actionTypeBU.drawDimDiameter && clsInit.appEditor2.action != actionTypeBU.drawDimLinear && clsInit.appEditor2.action != actionTypeBU.drawDimHorizontalOrdinate && clsInit.appEditor2.action != actionTypeBU.drawDimVerticalOrdinate && clsInit.appEditor2.action != actionTypeBU.drawDimRadial)
		{
			if (IsPolygonClosed())
			{
				point3D_3 = points[0].Pnt3D;
			}
			base.RenderContext.SetLineSize((float)clsVar.varEditorSet.DrawThickness + 1f);
			Point3D point3D = WorldToScreen(point3D_3);
			Point2D a = WorldToScreen(point3D_3.X - 1.0, point3D_3.Y, 0.0);
			Vector2D vector2D = Vector2D.Subtract(a, point3D);
			vector2D.Normalize();
			a = point3D + vector2D * double_0;
			Point2D p = point3D - vector2D * double_0;
			base.RenderContext.DrawLine(a, p);
			Point2D a2 = WorldToScreen(point3D_3.X, point3D_3.Y - 1.0, 0.0);
			Vector2D vector2D2 = Vector2D.Subtract(a2, point3D);
			vector2D2.Normalize();
			a2 = point3D + vector2D2 * double_0;
			Point2D p2 = point3D - vector2D2 * double_0;
			base.RenderContext.DrawLine(a2, p2);
			base.RenderContext.SetLineSize(1f);
		}
	}

	public void EventCopyToSelected()
	{
		selectionProcess = false;
		clsItem.frmEditorV2.viewport.selEntities.Clear();
		for (int num = clsItem.frmEditorV2.viewport.Entities.Count - 1; num > -1; num--)
		{
			Entity entity = clsItem.frmEditorV2.viewport.Entities[num];
			if (entity.Selected && (entity is ICurve || entity is BlockReference || entity is Text || entity is Leader))
			{
				clsItem.frmEditorV2.viewport.selEntities.Add(entity);
			}
		}
		foreach (Entity selEntity in clsItem.frmEditorV2.viewport.selEntities)
		{
			selEntity.Selected = true;
		}
	}

	public void EventMove()
	{
		try
		{
			if (points.Count != 2 || selEntities.Count <= 0)
			{
				return;
			}
			clsInit.appEditor2.UndoBuffer();
			foreach (Entity selEntity in selEntities)
			{
				Vector3D v = new Vector3D(points[0].Pnt3D, points[1].Pnt3D);
				selEntity.Translate(v);
			}
			base.Entities.Regen();
			ClearAllPreviousCommandData();
		}
		catch (Exception)
		{
		}
	}

	public void EventCopy()
	{
		try
		{
			if (points.Count != 2 || selEntities.Count <= 0)
			{
				return;
			}
			clsInit.appEditor2.UndoBuffer();
			foreach (Entity selEntity in selEntities)
			{
				Vector3D v = new Vector3D(points[0].Pnt3D, points[1].Pnt3D);
				Entity entity2 = (Entity)selEntity.Clone();
				entity2.Translate(v);
				method_18(entity2, ActiveLayerName, bool_0: false, bool_1: false);
			}
			base.Entities.Regen();
			ClearAllPreviousCommandData();
		}
		catch (Exception)
		{
		}
	}

	public void EventRotate()
	{
		if (points.Count != 3 || selEntities.Count <= 0)
		{
			return;
		}
		clsInit.appEditor2.UndoBuffer();
		foreach (Entity selEntity in selEntities)
		{
			selEntity.Rotate(arcSpanAngle, Vector3D.AxisZ, points[0].Pnt3D);
			if (selEntity is Text)
			{
				selEntity.Regen(new RegenParams(0.0, this));
			}
		}
		base.Entities.Regen();
		ClearAllPreviousCommandData();
	}

	public void EventMirror()
	{
		if (points.Count != 2 || selEntities.Count <= 0)
		{
			return;
		}
		if (!(points[1].Pnt3D.X >= points[0].Pnt3D.X) || points[1].Pnt3D.Y < points[0].Pnt3D.Y)
		{
			Point3D first = points[0].Pnt3D;
			Point3D second = points[1].Pnt3D;
			Utility.Swap(ref first, ref second);
			points[0].Pnt3D = first;
			points[1].Pnt3D = second;
		}
		Vector3D vector3D = new Vector3D(points[0].Pnt3D, points[1].Pnt3D);
		Plane pln = new Plane(points[0].Pnt3D, vector3D, Vector3D.AxisZ);
		foreach (Entity selEntity in selEntities)
		{
			Entity entity2 = (Entity)selEntity.Clone();
			Transformation xform = Transformation.CreateReflection(pln);
			entity2.TransformBy(xform);
			method_18(entity2, ActiveLayerName, bool_0: false, bool_1: false);
		}
		base.Entities.Regen();
		ClearAllPreviousCommandData();
	}

	public void EventScale(bool Override = false, double ScaleRatio = 1.0)
	{
		try
		{
			if (!Override)
			{
				if (points.Count != 3 || selEntities.Count <= 0)
				{
					return;
				}
				double num = points[0].Pnt3D.DistanceTo(points[2].Pnt3D) / points[0].Pnt3D.DistanceTo(points[1].Pnt3D);
				if (num > 0.0)
				{
					clsInit.appEditor2.UndoBuffer();
					foreach (Entity selEntity in selEntities)
					{
						selEntity.Scale(points[0].Pnt3D, num);
					}
					base.Entities.Regen();
				}
				ClearAllPreviousCommandData();
				return;
			}
			if (ScaleRatio > 0.0)
			{
				clsInit.appEditor2.UndoBuffer();
				foreach (Entity selEntity2 in selEntities)
				{
					if (points.Count <= 0)
					{
						selEntity2.Scale(boxMid, ScaleRatio);
					}
					else
					{
						selEntity2.Scale(points[0].Pnt3D, ScaleRatio);
					}
				}
				base.Entities.Regen();
			}
			ClearAllPreviousCommandData();
		}
		catch (Exception)
		{
		}
	}

	public void EventOffset()
	{
		if (points.Count != 1 || selEntities.Count <= 0)
		{
			return;
		}
		clsVar.varEditorSet.OffsetByMouse = clsItem.frmEditorV2.chk_offsetbymouse.Check;
		clsVar.varEditorRuntimeSet.OffsetValue = clsItem.frmEditorV2.spn_offset.Value;
		clsInit.appEditor2.UndoBuffer();
		foreach (Entity selEntity in selEntities)
		{
			if (!clsVar.varEditorSet.OffsetByMouse)
			{
				ICurve curve = selEntity as ICurve;
				curve.Project(current, out var t);
				Point3D point3D = curve.PointAt(t);
				double offsetValue = clsVar.varEditorRuntimeSet.OffsetValue;
				ICurve[] array = curve.Offset(offsetValue, Vector3D.AxisZ, sharp: true);
				ICurve curve2 = ((array == null) ? null : array[0]);
				ICurve[] array2 = curve.Offset(0.0 - offsetValue, Vector3D.AxisZ, sharp: true);
				ICurve curve3 = ((array2 == null) ? null : array2[0]);
				curve2.Project(current, out t);
				point3D = curve2.PointAt(t);
				curve3.Project(current, out t);
				Point3D point3D2 = curve3.PointAt(t);
				double num = point3D.DistanceTo(current);
				double num2 = point3D2.DistanceTo(current);
				if (!(num < num2))
				{
					method_18((Entity)curve3, ActiveLayerName, bool_0: false, bool_1: false);
				}
				else
				{
					method_18((Entity)curve2, ActiveLayerName, bool_0: false, bool_1: false);
				}
			}
			else
			{
				ICurve curve4 = selEntity as ICurve;
				curve4.Project(points[0].Pnt3D, out var t2);
				Point3D point3D3 = curve4.PointAt(t2);
				double num3 = point3D3.DistanceTo(points[0].Pnt3D);
				ICurve[] array3 = curve4.Offset(num3, Vector3D.AxisZ, sharp: true);
				ICurve curve5 = ((array3 == null) ? null : array3[0]);
				curve5.Project(points[0].Pnt3D, out t2);
				point3D3 = curve5.PointAt(t2);
				if (point3D3.DistanceTo(points[0].Pnt3D) > 0.001)
				{
					ICurve[] array4 = curve4.Offset(0.0 - num3, Vector3D.AxisZ, sharp: true);
					curve5 = ((array4 == null) ? null : array4[0]);
				}
				method_18((Entity)curve5, ActiveLayerName, bool_0: false, bool_1: false);
			}
		}
		base.Entities.Regen();
		ClearAllPreviousCommandData();
	}

	public void EventDelete()
	{
		try
		{
			clsInit.appEditor2.UndoBuffer();
			base.Entities.DeleteSelected();
			Invalidate();
			clsInit.appEditor2.Reset();
			ClearAllPreviousCommandData();
		}
		catch (Exception)
		{
		}
	}

	public void EventBreak()
	{
		try
		{
			if (!((points.Count == 1) & (int_0 != null)) || int_0.Length == 0 || entityMouseUnder == null || entityMouseUnder.Item == null)
			{
				return;
			}
			clsInit.appEditor2.UndoBuffer();
			Entity entityFirst = null;
			Entity entitySecond = null;
			Break((Entity)entityMouseUnder.Item, current, ref entityFirst, ref entitySecond);
			if (entityFirst != null && entitySecond != null)
			{
				if ((int_0[0] >= 0) & (int_0[0] <= base.Entities.Count - 1))
				{
					base.Entities.RemoveAt(int_0[0]);
				}
				method_18(entityFirst, ActiveLayerName, bool_0: true, bool_1: true);
				method_18(entitySecond, ActiveLayerName, bool_0: true, bool_1: true);
			}
		}
		catch (Exception)
		{
		}
	}

	public void EventTrim()
	{
		try
		{
			if (!((points.Count == 1) & (int_0 != null)) || int_0.Length == 0)
			{
				return;
			}
			int num = int_0[0];
			if (num == -1)
			{
				return;
			}
			Entity entity = base.Entities[num];
			if (entity != null)
			{
				clsInit.appEditor2.UndoBuffer();
				if (!Utility.Trim(this, mouseDownLocation, out var leftOverEntities))
				{
					base.Entities.Remove(entity);
				}
				else
				{
					base.Entities.AddRange(leftOverEntities);
				}
				base.Entities.RegenAllCurved();
				points.Clear();
				timer_0.Interval = 100;
				timer_0.Enabled = true;
			}
		}
		catch (Exception)
		{
		}
	}

	public void Break(Entity selEntity, Point3D refPoint, ref Entity entityFirst, ref Entity entitySecond)
	{
		ICurve curve = selEntity as ICurve;
		ICurve lower = null;
		ICurve upper = null;
		if (curve.Project(refPoint, out var t))
		{
			curve.SplitAt(t, out lower, out upper);
		}
		if (lower != null && upper != null)
		{
			entityFirst = (Entity)lower;
			entitySecond = (Entity)upper;
		}
	}

	public void EventExtend()
	{
		try
		{
			if (!((points.Count == 1) & (int_0 != null)) || int_0.Length == 0)
			{
				return;
			}
			if (entityMouseUnder != null && entityMouseUnder.Item != null)
			{
				Entity entityExtended = null;
				clsVar.varEditorRuntimeSet.ExtendLength = clsItem.frmEditorV2.spn_extndlen.Value;
				clsInit.appCommand.Extend(clsItem.frmEditorV2.viewport.Entities, int_0[0], current, clsVar.varEditorRuntimeSet.ExtendLength, ref entityExtended);
				if (entityExtended != null)
				{
					clsInit.appEditor2.UndoBuffer();
					if ((int_0[0] >= 0) & (int_0[0] <= base.Entities.Count - 1))
					{
						base.Entities.RemoveAt(int_0[0]);
					}
					method_18(entityExtended, ActiveLayerName, bool_0: true, bool_1: true);
				}
			}
			ClearAllPreviousCommandData();
		}
		catch (Exception)
		{
		}
	}

	public void EventFillet()
	{
		if (firstSelectedEntity != null)
		{
			if (secondSelectedEntity == null)
			{
			}
		}
		else if (selEntityIndex != -1)
		{
			firstSelectedEntity = base.Entities[selEntityIndex];
			selEntityIndex = -1;
			ScreenToPlane(point_0, Plane.XY, out point3D_1);
			return;
		}
		if (secondSelectedEntity == null && selEntityIndex != -1)
		{
			secondSelectedEntity = base.Entities[selEntityIndex];
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
				ClearAllPreviousCommandData();
				return;
			}
		}
		try
		{
			if (firstSelectedEntity.Equals(secondSelectedEntity))
			{
				ClearAllPreviousCommandData();
				return;
			}
			ScreenToPlane(point_0, Plane.XY, out point3D_2);
			clsVar.varEditorRuntimeSet.FilletRadius = clsItem.frmEditorV2.spn_filletrad.Value;
			firstSelectedEntity = method_19(firstSelectedEntity);
			secondSelectedEntity = method_19(secondSelectedEntity);
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
					curve3 = Class5.smethod_56((ICurve)(Line)firstSelectedEntity, this);
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
					curve4 = Class5.smethod_56((ICurve)(Line)secondSelectedEntity, this);
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
				Class5.smethod_153(ref icurve_3, curve, out icurve_4, out icurve_, curve2, out icurve_2, this);
			}
			ICurve[] array = new ICurve[8]
			{
				Class5.smethod_0(icurve_3, this),
				Class5.smethod_0(icurve_3, this),
				Class5.smethod_0(icurve_3, this),
				Class5.smethod_0(icurve_3, this),
				null,
				null,
				null,
				null
			};
			ICurve[] array2 = new ICurve[8]
			{
				Class5.smethod_0(icurve_4, this),
				Class5.smethod_0(icurve_4, this),
				Class5.smethod_0(icurve_4, this),
				Class5.smethod_0(icurve_4, this),
				null,
				null,
				null,
				null
			};
			Arc[] array3 = new Arc[8];
			ICurve curve5 = firstSelectedEntity as ICurve;
			ICurve curve6 = secondSelectedEntity as ICurve;
			double num = Point3D.Distance(point3D_1, curve5.StartPoint);
			double num2 = Point3D.Distance(point3D_2, curve5.EndPoint);
			if (!(num2 >= num) && (curve6 is Arc || curve6 is EllipticalArc))
			{
				curve5.Reverse();
			}
			double num3 = Point3D.Distance(point3D_1, curve6.StartPoint);
			double num4 = Point3D.Distance(point3D_2, curve6.EndPoint);
			if (!(num4 >= num3) && (curve6 is Arc || curve6 is EllipticalArc))
			{
				curve6.Reverse();
			}
			for (int i = 4; i < array.Length; i++)
			{
				array[i] = Class5.smethod_0(icurve_3, this);
			}
			for (int j = 4; j < array2.Length; j++)
			{
				array2[j] = Class5.smethod_0(icurve_4, this);
			}
			Curve.Fillet(array[0], array2[0], clsVar.varEditorRuntimeSet.FilletRadius, flip1: false, flip2: false, trim1: true, trim2: true, out array3[0]);
			Curve.Fillet(array[1], array2[1], clsVar.varEditorRuntimeSet.FilletRadius, flip1: false, flip2: true, trim1: true, trim2: true, out array3[1]);
			Curve.Fillet(array[2], array2[2], clsVar.varEditorRuntimeSet.FilletRadius, flip1: true, flip2: false, trim1: true, trim2: true, out array3[2]);
			Curve.Fillet(array[3], array2[3], clsVar.varEditorRuntimeSet.FilletRadius, flip1: true, flip2: true, trim1: true, trim2: true, out array3[3]);
			Curve.Fillet(array[4], array2[4], clsVar.varEditorRuntimeSet.FilletRadius, flip1: false, flip2: false, trim1: true, trim2: true, out array3[4]);
			Curve.Fillet(array[5], array2[5], clsVar.varEditorRuntimeSet.FilletRadius, flip1: false, flip2: true, trim1: true, trim2: true, out array3[5]);
			Curve.Fillet(array[6], array2[6], clsVar.varEditorRuntimeSet.FilletRadius, flip1: true, flip2: false, trim1: true, trim2: true, out array3[6]);
			Curve.Fillet(array[7], array2[7], clsVar.varEditorRuntimeSet.FilletRadius, flip1: true, flip2: true, trim1: true, trim2: true, out array3[7]);
			int num5 = method_20(array3);
			if (num5 < 0)
			{
				if (!curve5.StartPoint.Equals(curve6.StartPoint) && !curve5.StartPoint.Equals(curve6.EndPoint) && !curve6.StartPoint.Equals(curve5.EndPoint) && !curve6.EndPoint.Equals(curve5.EndPoint))
				{
					if ((!(secondSelectedEntity is Arc) && !(secondSelectedEntity is EllipticalArc)) || !(firstSelectedEntity is Line))
					{
						Utility.Swap(ref firstSelectedEntity, ref secondSelectedEntity);
						method_21();
						Utility.Swap(ref firstSelectedEntity, ref secondSelectedEntity);
						method_21();
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
						if (!Class5.smethod_162(secondSelectedEntity))
						{
							method_21();
						}
						Utility.Swap(ref firstSelectedEntity, ref secondSelectedEntity);
						method_21();
						Utility.Swap(ref firstSelectedEntity, ref secondSelectedEntity);
					}
					if (clsVar.varEditorRuntimeSet.FilletRadius > 0.0)
					{
						clsInit.appEditor2.UndoBuffer();
						curve = (ICurve)firstSelectedEntity.Clone();
						curve2 = (ICurve)secondSelectedEntity.Clone();
						icurve_3 = curve;
						icurve_4 = curve2;
						if (Utility.Intersection((ICurve)firstSelectedEntity, (ICurve)secondSelectedEntity).Length > 1 || (curve3 != null && curve4 != null && Utility.Intersection(curve3, curve4).Length > 1))
						{
							Class5.smethod_153(ref icurve_3, curve, out icurve_4, out icurve_, curve2, out icurve_2, this);
						}
						for (int k = 0; k < array.Length; k++)
						{
							array[k] = Class5.smethod_0(icurve_3, this);
						}
						for (int l = 0; l < array2.Length; l++)
						{
							array2[l] = Class5.smethod_0(icurve_4, this);
						}
						Curve.Fillet(array[0], array2[0], clsVar.varEditorRuntimeSet.FilletRadius, flip1: false, flip2: false, trim1: true, trim2: true, out array3[0]);
						Curve.Fillet(array[1], array2[1], clsVar.varEditorRuntimeSet.FilletRadius, flip1: false, flip2: true, trim1: true, trim2: true, out array3[1]);
						Curve.Fillet(array[2], array2[2], clsVar.varEditorRuntimeSet.FilletRadius, flip1: true, flip2: false, trim1: true, trim2: true, out array3[2]);
						Curve.Fillet(array[3], array2[3], clsVar.varEditorRuntimeSet.FilletRadius, flip1: true, flip2: true, trim1: true, trim2: true, out array3[3]);
						Curve.Fillet(array[4], array2[4], clsVar.varEditorRuntimeSet.FilletRadius, flip1: false, flip2: false, trim1: true, trim2: true, out array3[4]);
						Curve.Fillet(array[5], array2[5], clsVar.varEditorRuntimeSet.FilletRadius, flip1: false, flip2: true, trim1: true, trim2: true, out array3[5]);
						Curve.Fillet(array[6], array2[6], clsVar.varEditorRuntimeSet.FilletRadius, flip1: true, flip2: false, trim1: true, trim2: true, out array3[6]);
						Curve.Fillet(array[7], array2[7], clsVar.varEditorRuntimeSet.FilletRadius, flip1: true, flip2: true, trim1: true, trim2: true, out array3[7]);
						num5 = method_20(array3);
						if (num5 < 0)
						{
							method_18(firstSelectedEntity, ActiveLayerName, bool_0: true, bool_1: true);
							method_18(secondSelectedEntity, ActiveLayerName, bool_0: true, bool_1: true);
						}
						else
						{
							base.Entities.Remove(secondSelectedEntity);
							base.Entities.Remove(firstSelectedEntity);
							ICurve curve7 = Class5.smethod_148(this, array[num5], icurve_, true);
							if (curve7 != null)
							{
								array[num5] = curve7;
							}
							curve7 = Class5.smethod_148(this, array2[num5], icurve_2, true);
							if (curve7 != null)
							{
								array2[num5] = curve7;
							}
							method_18(Class5.smethod_162(firstSelectedEntity) ? firstSelectedEntity : ((Entity)array[num5]), ActiveLayerName, bool_0: true, bool_1: true);
							method_18(Class5.smethod_162(secondSelectedEntity) ? secondSelectedEntity : ((Entity)array2[num5]), ActiveLayerName, bool_0: true, bool_1: true);
							method_18(array3[num5], ActiveLayerName, bool_0: true, bool_1: true);
						}
					}
				}
			}
			else
			{
				clsInit.appEditor2.UndoBuffer();
				base.Entities.Remove(firstSelectedEntity);
				base.Entities.Remove(secondSelectedEntity);
				ICurve curve8 = array[num5];
				ICurve curve9 = array2[num5];
				bool bool_ = curve8 is EllipticalArc && (curve8 as EllipticalArc).Center.X > point3D_1.X;
				ICurve curve10 = Class5.smethod_148(this, curve8, icurve_, bool_);
				if (curve10 != null)
				{
					array[num5] = curve10;
				}
				bool_ = curve9 is EllipticalArc && (curve9 as EllipticalArc).Center.X > point3D_2.X;
				curve10 = Class5.smethod_148(this, curve9, icurve_2, bool_);
				if (curve10 != null)
				{
					array2[num5] = curve10;
				}
				method_18(Class5.smethod_162(firstSelectedEntity) ? firstSelectedEntity : ((Entity)array[num5]), ActiveLayerName, bool_0: true, bool_1: true);
				method_18(Class5.smethod_162(secondSelectedEntity) ? secondSelectedEntity : ((Entity)array2[num5]), ActiveLayerName, bool_0: true, bool_1: true);
				method_18(array3[num5], ActiveLayerName, bool_0: true, bool_1: true);
			}
		}
		catch
		{
		}
		ClearAllPreviousCommandData();
	}

	public void EventChamfer()
	{
		if (firstSelectedEntity != null)
		{
			if (secondSelectedEntity == null)
			{
			}
		}
		else if (selEntityIndex != -1)
		{
			firstSelectedEntity = base.Entities[selEntityIndex];
			selEntityIndex = -1;
			ScreenToPlane(point_0, Plane.XY, out point3D_1);
			return;
		}
		if (secondSelectedEntity == null && selEntityIndex != -1)
		{
			secondSelectedEntity = base.Entities[selEntityIndex];
		}
		if (!(firstSelectedEntity is ICurve) || !(secondSelectedEntity is ICurve))
		{
			return;
		}
		if (!firstSelectedEntity.Equals(secondSelectedEntity))
		{
			clsVar.varEditorRuntimeSet.ChamferLength = clsItem.frmEditorV2.spn_chamgerlen.Value;
			firstSelectedEntity = method_19(firstSelectedEntity);
			secondSelectedEntity = method_19(secondSelectedEntity);
			ScreenToPlane(point_0, Plane.XY, out point3D_2);
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
					curve3 = Class5.smethod_56((ICurve)(Line)firstSelectedEntity, this);
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
					curve4 = Class5.smethod_56((ICurve)(Line)secondSelectedEntity, this);
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
				Class5.smethod_153(ref icurve_3, curve, out icurve_4, out icurve_, curve2, out icurve_2, this);
			}
			ICurve[] array = new ICurve[8]
			{
				Class5.smethod_0(icurve_3, this),
				Class5.smethod_0(icurve_3, this),
				Class5.smethod_0(icurve_3, this),
				Class5.smethod_0(icurve_3, this),
				null,
				null,
				null,
				null
			};
			ICurve[] array2 = new ICurve[8]
			{
				Class5.smethod_0(icurve_4, this),
				Class5.smethod_0(icurve_4, this),
				Class5.smethod_0(icurve_4, this),
				Class5.smethod_0(icurve_4, this),
				null,
				null,
				null,
				null
			};
			Line[] array3 = new Line[8];
			ICurve curve5 = firstSelectedEntity as ICurve;
			ICurve curve6 = secondSelectedEntity as ICurve;
			double num = Point3D.Distance(point3D_1, curve5.StartPoint);
			double num2 = Point3D.Distance(point3D_2, curve5.EndPoint);
			if (!(num2 >= num) && (curve6 is Arc || curve6 is EllipticalArc))
			{
				curve5.Reverse();
			}
			double num3 = Point3D.Distance(point3D_1, curve6.StartPoint);
			double num4 = Point3D.Distance(point3D_2, curve6.EndPoint);
			if (!(num4 >= num3) && (curve6 is Arc || curve6 is EllipticalArc))
			{
				curve6.Reverse();
			}
			for (int i = 4; i < array.Length; i++)
			{
				array[i] = Class5.smethod_0(icurve_3, this);
			}
			for (int j = 4; j < array2.Length; j++)
			{
				array2[j] = Class5.smethod_0(icurve_4, this);
			}
			Curve.Chamfer(array[0], array2[0], chamferLength, flip1: false, flip2: false, trim1: true, trim2: true, out array3[0]);
			Curve.Chamfer(array[1], array2[1], chamferLength, flip1: false, flip2: true, trim1: true, trim2: true, out array3[1]);
			Curve.Chamfer(array[2], array2[2], chamferLength, flip1: true, flip2: false, trim1: true, trim2: true, out array3[2]);
			Curve.Chamfer(array[3], array2[3], chamferLength, flip1: true, flip2: true, trim1: true, trim2: true, out array3[3]);
			Curve.Chamfer(array[4], array2[4], chamferLength, flip1: false, flip2: false, trim1: true, trim2: true, out array3[4]);
			Curve.Chamfer(array[5], array2[5], chamferLength, flip1: false, flip2: true, trim1: true, trim2: true, out array3[5]);
			Curve.Chamfer(array[6], array2[6], chamferLength, flip1: true, flip2: false, trim1: true, trim2: true, out array3[6]);
			Curve.Chamfer(array[7], array2[7], chamferLength, flip1: true, flip2: true, trim1: true, trim2: true, out array3[7]);
			int num5 = method_20(array3);
			if (num5 < 0)
			{
				if (!curve5.StartPoint.Equals(curve6.StartPoint) && !curve5.StartPoint.Equals(curve6.EndPoint) && !curve6.StartPoint.Equals(curve5.EndPoint) && !curve6.EndPoint.Equals(curve5.EndPoint))
				{
					if ((!(secondSelectedEntity is Arc) && !(secondSelectedEntity is EllipticalArc)) || !(firstSelectedEntity is Line))
					{
						Utility.Swap(ref firstSelectedEntity, ref secondSelectedEntity);
						method_21();
						Utility.Swap(ref firstSelectedEntity, ref secondSelectedEntity);
						method_21();
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
						if (!Class5.smethod_162(secondSelectedEntity))
						{
							method_21();
						}
						Utility.Swap(ref firstSelectedEntity, ref secondSelectedEntity);
						method_21();
						Utility.Swap(ref firstSelectedEntity, ref secondSelectedEntity);
					}
					if (chamferLength > 0.0)
					{
						clsInit.appEditor2.UndoBuffer();
						curve = (ICurve)firstSelectedEntity.Clone();
						curve2 = (ICurve)secondSelectedEntity.Clone();
						icurve_3 = curve;
						icurve_4 = curve2;
						if (Utility.Intersection((ICurve)firstSelectedEntity, (ICurve)secondSelectedEntity).Length > 1 || (curve3 != null && curve4 != null && Utility.Intersection(curve3, curve4).Length > 1))
						{
							Class5.smethod_153(ref icurve_3, curve, out icurve_4, out icurve_, curve2, out icurve_2, this);
						}
						for (int k = 0; k < array.Length; k++)
						{
							array[k] = Class5.smethod_0(icurve_3, this);
						}
						for (int l = 0; l < array2.Length; l++)
						{
							array2[l] = Class5.smethod_0(icurve_4, this);
						}
						Curve.Chamfer(array[0], array2[0], chamferLength, flip1: false, flip2: false, trim1: true, trim2: true, out array3[0]);
						Curve.Chamfer(array[1], array2[1], chamferLength, flip1: false, flip2: true, trim1: true, trim2: true, out array3[1]);
						Curve.Chamfer(array[2], array2[2], chamferLength, flip1: true, flip2: false, trim1: true, trim2: true, out array3[2]);
						Curve.Chamfer(array[3], array2[3], chamferLength, flip1: true, flip2: true, trim1: true, trim2: true, out array3[3]);
						Curve.Chamfer(array[4], array2[4], chamferLength, flip1: false, flip2: false, trim1: true, trim2: true, out array3[4]);
						Curve.Chamfer(array[5], array2[5], chamferLength, flip1: false, flip2: true, trim1: true, trim2: true, out array3[5]);
						Curve.Chamfer(array[6], array2[6], chamferLength, flip1: true, flip2: false, trim1: true, trim2: true, out array3[6]);
						Curve.Chamfer(array[7], array2[7], chamferLength, flip1: true, flip2: true, trim1: true, trim2: true, out array3[7]);
						num5 = method_20(array3);
						if (num5 < 0)
						{
							method_18(firstSelectedEntity, ActiveLayerName, bool_0: true, bool_1: true);
							method_18(secondSelectedEntity, ActiveLayerName, bool_0: true, bool_1: true);
						}
						else
						{
							base.Entities.Remove(secondSelectedEntity);
							base.Entities.Remove(firstSelectedEntity);
							ICurve curve7 = Class5.smethod_148(this, array[num5], icurve_, true);
							if (curve7 != null)
							{
								array[num5] = curve7;
							}
							curve7 = Class5.smethod_148(this, array2[num5], icurve_2, true);
							if (curve7 != null)
							{
								array2[num5] = curve7;
							}
							method_18(Class5.smethod_162(firstSelectedEntity) ? firstSelectedEntity : ((Entity)array[num5]), ActiveLayerName, bool_0: true, bool_1: true);
							method_18(Class5.smethod_162(secondSelectedEntity) ? secondSelectedEntity : ((Entity)array2[num5]), ActiveLayerName, bool_0: true, bool_1: true);
							method_18(array3[num5], ActiveLayerName, bool_0: true, bool_1: true);
						}
					}
				}
			}
			else
			{
				clsInit.appEditor2.UndoBuffer();
				base.Entities.Remove(firstSelectedEntity);
				base.Entities.Remove(secondSelectedEntity);
				bool bool_ = array[num5] is EllipticalArc && ((EllipticalArc)array[num5]).Center.X > point3D_1.X;
				ICurve curve8 = Class5.smethod_148(this, array[num5], icurve_, bool_);
				if (curve8 != null)
				{
					array[num5] = curve8;
				}
				bool_ = array2[num5] is EllipticalArc && ((EllipticalArc)array2[num5]).Center.X > point3D_2.X;
				curve8 = Class5.smethod_148(this, array2[num5], icurve_2, bool_);
				if (curve8 != null)
				{
					array2[num5] = curve8;
				}
				method_18(Class5.smethod_162(firstSelectedEntity) ? firstSelectedEntity : ((Entity)array[num5]), ActiveLayerName, bool_0: true, bool_1: true);
				method_18(Class5.smethod_162(secondSelectedEntity) ? secondSelectedEntity : ((Entity)array2[num5]), ActiveLayerName, bool_0: true, bool_1: true);
				method_18(array3[num5], ActiveLayerName, bool_0: true, bool_1: true);
			}
			ClearAllPreviousCommandData();
		}
		else
		{
			ClearAllPreviousCommandData();
		}
	}

	public void EventRotateEntity()
	{
		method_3();
		if (points.Count == 0 || points.Count == 1 || points.Count != 2)
		{
			return;
		}
		foreach (Entity selEntity in selEntities)
		{
			Entity entity2 = (Entity)selEntity.Clone();
			entity2.Rotate(arcSpanAngle, Vector3D.AxisZ, points[0].Pnt3D);
			if (entity2 is Text)
			{
				entity2.Regen(new RegenParams(0.0, this));
			}
			method_15(entity2, clsVar.varEditorSet.colorEvent);
		}
	}

	private void method_11()
	{
		if (points.Count == 0 || points.Count != 1)
		{
			return;
		}
		foreach (Entity selEntity in selEntities)
		{
			Entity entity2 = (Entity)selEntity.Clone();
			Vector3D v = new Vector3D(points[0].Pnt3D, current);
			entity2.Translate(v);
			if (entity2 is Text)
			{
				entity2.Regen(new RegenParams(0.0, this));
			}
			method_15(entity2, clsVar.varEditorSet.colorEvent);
		}
	}

	private void method_12()
	{
		if (points.Count >= 1)
		{
			method_1();
			Point3D point3D = new Point3D(points[0].Pnt3D.X, points[0].Pnt3D.Y, points[0].Pnt3D.Z);
			Point3D point3D2 = new Point3D(current.X, current.Y, current.Z);
			if (!(point3D2.X >= point3D.X) || point3D2.Y < point3D.Y)
			{
				Point3D first = point3D;
				Point3D second = point3D2;
				Utility.Swap(ref first, ref second);
				point3D = first;
				point3D2 = second;
			}
			if (!(Point3D.Distance(point3D, point3D2) > 0.0))
			{
				return;
			}
			Vector3D vector3D = new Vector3D(point3D, point3D2);
			Plane pln = new Plane(point3D, vector3D, Vector3D.AxisZ);
			{
				foreach (Entity selEntity in selEntities)
				{
					Entity entity2 = (Entity)selEntity.Clone();
					Transformation xform = Transformation.CreateReflection(pln);
					entity2.TransformBy(xform);
					method_15(entity2, clsVar.varEditorSet.colorEvent);
				}
				return;
			}
		}
		method_1();
	}

	private void method_13()
	{
		List<Point3D> list = new List<Point3D>();
		foreach (Point3D item in clsInit.appEditor2.ClicksToPoints(points))
		{
			list.Add(WorldToScreen(item));
		}
		base.RenderContext.DrawLineStrip(list.ToArray());
		if (base.ActionMode == actionType.None && list.Count() > 0)
		{
			base.RenderContext.DrawLineStrip(new Point3D[2]
			{
				WorldToScreen(clsInit.appEditor2.ClicksToPoints(points).First()),
				WorldToScreen(current)
			});
		}
		if (points.Count != 2)
		{
			return;
		}
		double num = points[0].Pnt3D.DistanceTo(current) / points[0].Pnt3D.DistanceTo(points[1].Pnt3D);
		if (!(num > 0.0))
		{
			return;
		}
		foreach (Entity selEntity in selEntities)
		{
			Entity entity2 = (Entity)selEntity.Clone();
			entity2.Scale(points[0].Pnt3D, (num != 0.0) ? num : 1.0);
			if (entity2 is Text)
			{
				entity2.Regen(new RegenParams(0.0, this));
			}
			method_15(entity2, clsVar.varEditorSet.colorEvent);
		}
	}

	public void EventOffsetEntity()
	{
		if (points.Count != 0)
		{
			return;
		}
		clsVar.varEditorSet.OffsetByMouse = clsItem.frmEditorV2.chk_offsetbymouse.Check;
		clsVar.varEditorRuntimeSet.OffsetValue = clsItem.frmEditorV2.spn_offset.Value;
		foreach (Entity selEntity in selEntities)
		{
			Entity entity2 = (Entity)selEntity.Clone();
			if (!clsVar.varEditorSet.OffsetByMouse)
			{
				ICurve curve = entity2 as ICurve;
				curve.Project(current, out var t);
				Point3D point3D = curve.PointAt(t);
				double offsetValue = clsVar.varEditorRuntimeSet.OffsetValue;
				ICurve[] array = curve.Offset(offsetValue, Vector3D.AxisZ, sharp: true);
				ICurve curve2 = ((array == null) ? null : array[0]);
				ICurve[] array2 = curve.Offset(0.0 - offsetValue, Vector3D.AxisZ, sharp: true);
				ICurve curve3 = ((array2 == null) ? null : array2[0]);
				curve2.Project(current, out t);
				point3D = curve2.PointAt(t);
				curve3.Project(current, out t);
				Point3D point3D2 = curve3.PointAt(t);
				double num = point3D.DistanceTo(current);
				double num2 = point3D2.DistanceTo(current);
				if (!(num < num2))
				{
					method_15((Entity)curve3, clsVar.varEditorSet.colorEvent);
				}
				else
				{
					method_15((Entity)curve2, clsVar.varEditorSet.colorEvent);
				}
			}
			else
			{
				ICurve curve4 = entity2 as ICurve;
				curve4.Project(current, out var t2);
				Point3D point3D3 = curve4.PointAt(t2);
				double num3 = point3D3.DistanceTo(current);
				ICurve[] array3 = curve4.Offset(num3, Vector3D.AxisZ, sharp: true);
				ICurve curve5 = ((array3 == null) ? null : array3[0]);
				curve5.Project(current, out t2);
				point3D3 = curve5.PointAt(t2);
				if (point3D3.DistanceTo(current) > 0.001)
				{
					ICurve[] array4 = curve4.Offset(0.0 - num3, Vector3D.AxisZ, sharp: true);
					curve5 = ((array4 == null) ? null : array4[0]);
				}
				method_15((Entity)curve5, clsVar.varEditorSet.colorEvent);
			}
		}
	}

	private void method_14()
	{
		entToTrim = null;
		leftOvers.Clear();
		if (points.Count != 0 || entityMouseUnder == null || entityMouseUnder.Item == null)
		{
			return;
		}
		if (entityMouseUnder == null || entityMouseUnder.Item == null)
		{
			entToTrim = null;
		}
		else
		{
			Entity entity = entityMouseUnder.Item as Entity;
			entToTrim = entity.Clone() as Entity;
		}
		List<Entity> previewEntities = new List<Entity>();
		Utility.TrimPreview(this, point_0, out previewEntities);
		leftOvers = previewEntities.Select((Entity entity_0) => entity_0.Clone() as Entity).ToList();
		foreach (Entity leftOver in leftOvers)
		{
			if (base.CurrentTransformation != null)
			{
				leftOver.TransformBy(base.CurrentTransformation);
			}
		}
		if (entToTrim != null && base.CurrentTransformation != null)
		{
			entToTrim.TransformBy(base.CurrentTransformation);
		}
	}

	internal void method_15(Entity entity_0, Color color_0)
	{
		if (!(entity_0 is ICurve))
		{
			if (!(entity_0 is LinearDim))
			{
				if (!(entity_0 is RadialDim))
				{
					if (!(entity_0 is AngularDim))
					{
						if (!(entity_0 is OrdinateDim))
						{
							if (!(entity_0 is Text))
							{
								if (!(entity_0 is BlockReference))
								{
									if (entity_0 is Leader)
									{
										Leader leader = (Leader)entity_0;
										Class5.smethod_183(color_0, this, (ICurve)new Line(leader.Vertices[0], leader.Vertices[1]));
										Class5.smethod_183(color_0, this, (ICurve)new Line(leader.Vertices[1], leader.Vertices[2]));
									}
									return;
								}
								BlockReference blockReference = (BlockReference)entity_0;
								Entity[] array = blockReference.Explode(base.Blocks);
								Entity[] array2 = array;
								foreach (Entity entity in array2)
								{
									if (entity is ICurve icurve_)
									{
										Class5.smethod_183(color_0, this, icurve_);
									}
								}
							}
							else
							{
								Text text = (Text)entity_0;
								Class5.smethod_183(color_0, this, (ICurve)new Line(text.Vertices[0], text.Vertices[1]));
								Class5.smethod_183(color_0, this, (ICurve)new Line(text.Vertices[1], text.Vertices[2]));
								Class5.smethod_183(color_0, this, (ICurve)new Line(text.Vertices[2], text.Vertices[3]));
								Class5.smethod_183(color_0, this, (ICurve)new Line(text.Vertices[3], text.Vertices[0]));
							}
						}
						else
						{
							OrdinateDim ordinateDim = (OrdinateDim)entity_0;
							Class5.smethod_183(color_0, this, (ICurve)new Line(ordinateDim.Vertices[4], ordinateDim.Vertices[5]));
							Class5.smethod_183(color_0, this, (ICurve)new Line(ordinateDim.Vertices[5], ordinateDim.Vertices[6]));
							Class5.smethod_183(color_0, this, (ICurve)new Line(ordinateDim.Vertices[6], ordinateDim.Vertices[7]));
							Class5.smethod_183(color_0, this, (ICurve)new Line(ordinateDim.Vertices[7], ordinateDim.Vertices[4]));
							Class5.smethod_183(color_0, this, (ICurve)new Line(ordinateDim.Vertices[0], ordinateDim.Vertices[1]));
							Class5.smethod_183(color_0, this, (ICurve)new Line(ordinateDim.Vertices[1], ordinateDim.Vertices[2]));
							Class5.smethod_183(color_0, this, (ICurve)new Line(ordinateDim.Vertices[2], ordinateDim.Vertices[3]));
						}
					}
					else
					{
						AngularDim angularDim = (AngularDim)entity_0;
						Class5.smethod_183(color_0, this, (ICurve)new Line(angularDim.Vertices[4], angularDim.Vertices[5]));
						Class5.smethod_183(color_0, this, (ICurve)new Line(angularDim.Vertices[5], angularDim.Vertices[6]));
						Class5.smethod_183(color_0, this, (ICurve)new Line(angularDim.Vertices[6], angularDim.Vertices[7]));
						Class5.smethod_183(color_0, this, (ICurve)new Line(angularDim.Vertices[7], angularDim.Vertices[4]));
						Class5.smethod_183(color_0, this, (ICurve)new Line(angularDim.Vertices[0], angularDim.Vertices[1]));
						Class5.smethod_183(color_0, this, (ICurve)new Line(angularDim.Vertices[2], angularDim.Vertices[3]));
						Class5.smethod_183(color_0, this, (ICurve)angularDim.UnderlyingArc);
					}
				}
				else
				{
					RadialDim radialDim = (RadialDim)entity_0;
					Class5.smethod_183(color_0, this, (ICurve)new Line(radialDim.Vertices[6], radialDim.Vertices[7]));
					Class5.smethod_183(color_0, this, (ICurve)new Line(radialDim.Vertices[7], radialDim.Vertices[8]));
					Class5.smethod_183(color_0, this, (ICurve)new Line(radialDim.Vertices[8], radialDim.Vertices[9]));
					Class5.smethod_183(color_0, this, (ICurve)new Line(radialDim.Vertices[9], radialDim.Vertices[6]));
					Class5.smethod_183(color_0, this, (ICurve)new Line(radialDim.Vertices[0], radialDim.Vertices[5]));
				}
			}
			else
			{
				LinearDim linearDim = (LinearDim)entity_0;
				Class5.smethod_183(color_0, this, (ICurve)new Line(linearDim.Vertices[6], linearDim.Vertices[7]));
				Class5.smethod_183(color_0, this, (ICurve)new Line(linearDim.Vertices[7], linearDim.Vertices[8]));
				Class5.smethod_183(color_0, this, (ICurve)new Line(linearDim.Vertices[8], linearDim.Vertices[9]));
				Class5.smethod_183(color_0, this, (ICurve)new Line(linearDim.Vertices[9], linearDim.Vertices[6]));
				Class5.smethod_183(color_0, this, (ICurve)new Line(linearDim.Vertices[0], linearDim.Vertices[1]));
				Class5.smethod_183(color_0, this, (ICurve)new Line(linearDim.Vertices[2], linearDim.Vertices[3]));
				Class5.smethod_183(color_0, this, (ICurve)new Line(linearDim.Vertices[4], linearDim.Vertices[5]));
			}
		}
		else
		{
			Class5.smethod_183(color_0, this, entity_0 as ICurve);
		}
	}

	public Entity GetEntityByPosition(System.Drawing.Point location)
	{
		SelectedItem itemUnderMouseCursor = GetItemUnderMouseCursor(location);
		if (itemUnderMouseCursor == null)
		{
			return null;
		}
		return itemUnderMouseCursor.Item as Entity;
	}

	private Point2D[] method_16(IList<Point3D> ilist_0)
	{
		Point2D[] array = new Point2D[ilist_0.Count];
		for (int i = 0; i < ilist_0.Count; i++)
		{
			array[i] = WorldToScreen(ilist_0[i]);
		}
		return array;
	}

	public bool IsPolygonClosed()
	{
		if (points.Count <= 0 || (clsInit.appEditor2.action != actionTypeBU.drawLine && clsInit.appEditor2.action != actionTypeBU.drawPolyline && clsInit.appEditor2.action != actionTypeBU.drawCurve) || !(points[0].Pnt3D.DistanceTo(current) < (double)clsVar.varEditorSet.EntityMagnetRange))
		{
			return false;
		}
		return true;
	}

	private Point3D method_17(System.Drawing.Point point_1, Plane plane_0, IList<Point3D> ilist_0, int int_1)
	{
		if (ilist_0.Count > 0)
		{
			Point3D point3D = ilist_0[int_1];
			Point3D b = WorldToScreen(point3D);
			Point2D a = new Point2D(point_1.X, base.Size.Height - point_1.Y);
			if (Point2D.Distance(a, b) < 10.0)
			{
				return (Point3D)point3D.Clone();
			}
		}
		ScreenToPlane(point_1, plane_0, out var intPoint);
		return intPoint;
	}

	internal void method_18(Entity entity_0, string string_0, bool bool_0, bool bool_1)
	{
		if (!(entity_0 is devDept.Eyeshot.Entities.Point))
		{
			if (!(entity_0 is Dimension))
			{
				if (!(entity_0 is Leader))
				{
					if (!(entity_0 is Text))
					{
						entity_0.ColorMethod = colorMethodType.byEntity;
						entity_0.Color = clsVar.varEditorSet.colorDraw;
						entity_0.LineWeightMethod = colorMethodType.byEntity;
						entity_0.LineWeight = (float)clsVar.varEditorSet.DrawThickness;
						base.Entities.Add(entity_0, string_0);
					}
					else
					{
						Text text = (Text)entity_0;
						text.LayerName = string_0;
						text.WidthFactor = 0.9;
						text.LineWeightMethod = colorMethodType.byEntity;
						base.Entities.Add(text);
					}
				}
				else
				{
					entity_0.LayerName = string_0;
					entity_0.LineWeightMethod = colorMethodType.byEntity;
					base.Entities.Add(entity_0);
				}
			}
			else
			{
				Dimension dimension = (Dimension)entity_0;
				dimension.ColorMethod = colorMethodType.byEntity;
				dimension.Color = clsVar.varEditorSet.colorDraw;
				dimension.LayerName = string_0;
				dimension.WidthFactor = 0.9;
				dimension.LineWeightMethod = colorMethodType.byEntity;
				base.Entities.Add(dimension);
			}
		}
		else
		{
			entity_0.ColorMethod = colorMethodType.byEntity;
			entity_0.Color = clsVar.varEditorSet.colorDraw;
			entity_0.LineWeightMethod = colorMethodType.byEntity;
			entity_0.LineWeight = 3f;
			base.Entities.Add(entity_0);
		}
		if (bool_1)
		{
			base.Entities.Regen();
			Invalidate();
		}
		if (bool_0)
		{
			ClearAllPreviousCommandData();
		}
	}

	private Entity method_19(Entity entity_0)
	{
		if (!(entity_0 is Circle) || entity_0 is Arc)
		{
			if (entity_0 is Ellipse && !(entity_0 is EllipticalArc))
			{
				Ellipse ellipse = entity_0 as Ellipse;
				base.Entities.Remove(entity_0);
				entity_0 = new EllipticalArc(ellipse.Center, ellipse.RadiusX, ellipse.RadiusY, Math.PI * 2.0);
			}
		}
		else
		{
			Circle circle = entity_0 as Circle;
			base.Entities.Remove(entity_0);
			entity_0 = new Arc(circle.Center, circle.Radius, Math.PI * 2.0);
		}
		return entity_0;
	}

	private int method_20<T>(T[] gparam_0) where T : ICurve
	{
		double num = double.MaxValue;
		int result = -1;
		for (int i = 0; i < gparam_0.Length; i++)
		{
			ICurve curve = gparam_0[i];
			if (curve != null)
			{
				Point3D b = curve.PointAt(curve.Domain.Mid);
				double num2 = Point3D.Distance(point3D_1, b) + Point3D.Distance(point3D_2, b);
				if (num2 < num)
				{
					num = num2;
					result = i;
				}
			}
		}
		return result;
	}

	private void method_21()
	{
		if (!(firstSelectedEntity is ICurve) || !(secondSelectedEntity is ICurve))
		{
			return;
		}
		ICurve curve = firstSelectedEntity as ICurve;
		ICurve curve2 = secondSelectedEntity as ICurve;
		ScreenToPlane(point_0, Plane.XY, out point3D_2);
		curve.ClosestPointTo(curve2.StartPoint, out var t);
		curve.ClosestPointTo(curve2.EndPoint, out var t2);
		Point3D b = curve.PointAt(t);
		Point3D b2 = curve.PointAt(t2);
		ICurve curve3 = null;
		ICurve curve4 = null;
		if (!(curve2 is Arc))
		{
			if (!(curve2 is Ellipse))
			{
				if (curve2 is Line)
				{
					curve3 = Class5.smethod_56((ICurve)(Line)curve2, this);
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
					curve4 = Class5.smethod_56((ICurve)(Line)curve, this);
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
		double num;
		double num2;
		if (curve3 == null || curve4 == null || curve3.IntersectWith(curve4).Length <= 1)
		{
			num = curve2.StartPoint.DistanceTo(b);
			num2 = curve2.EndPoint.DistanceTo(b2);
		}
		else
		{
			num = curve2.StartPoint.DistanceTo(point3D_2);
			num2 = curve2.EndPoint.DistanceTo(point3D_2);
		}
		bool flag = false;
		bool bool_ = num < num2;
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
							flag = Class5.smethod_214(curve2, curve, bool_, this);
						}
					}
					else
					{
						flag = Class5.smethod_171(curve, curve2, bool_, this);
					}
				}
				else
				{
					flag = Class5.smethod_115(bool_, curve2, curve, this);
				}
			}
			else
			{
				flag = Class5.smethod_75(bool_, this, curve, curve2);
			}
		}
		else
		{
			flag = Class5.smethod_194(curve2, bool_, curve, this);
		}
		if (flag)
		{
			base.Entities.Regen();
		}
	}

	internal bool method_22(ICurve icurve_0, ICurve icurve_1, bool bool_0)
	{
		ICurve curve = icurve_0.Clone() as ICurve;
		List<Point3D> list = new List<Point3D>();
		for (int i = 0; i < 100; i++)
		{
			if (list.Count != 0)
			{
				break;
			}
			double num = curve.Domain.Length / 10.0;
			double t = ((!bool_0) ? (curve.Domain.t1 + num) : (curve.Domain.t0 - num));
			curve.ExtendAt(t);
			list = curve.IntersectWith(icurve_1).ToList();
		}
		if (list.Count != 0)
		{
			ICurve curve2 = icurve_0.Clone() as ICurve;
			curve2.ExtendBy(list[0], !bool_0);
			base.Entities.Remove((Entity)icurve_0);
			base.Entities.Add((Entity)curve2);
			return true;
		}
		return false;
	}

	public void ClearAllPreviousCommandData()
	{
		clsItem.frmEditorV2.grp_eventmovecmd.Visible = false;
		clsItem.frmEditorV2.grp_events.Visible = false;
		clsInit.appEditor2.StatusUpdate("", "");
		selectionProcess = true;
		clsInit.appEditor2.action = actionTypeBU.None;
		NoRectangleSelection = false;
		lastPoint = null;
		points.Clear();
		selEntities.Clear();
		selEntityIndex = -1;
		point3D_0 = null;
		firstClick = true;
		firstSelectedEntity = null;
		secondSelectedEntity = null;
		entToTrim = null;
		leftOvers = new List<Entity>();
		base.ActionMode = actionType.None;
		base.Entities.ClearSelection();
		base.ObjectManipulator.Cancel();
	}

	public void Tick_Add(object sender, EventArgs e)
	{
		actionTypeBU action = clsInit.appEditor2.action;
		ClearAllPreviousCommandData();
		timer_0.Enabled = false;
		Invalidate();
		if (action == actionTypeBU.eventTrim)
		{
			clsInit.appEditor2.cmdEventsTrim();
		}
	}

	public void PointToOsnap()
	{
		currentlySnapping = false;
		if (clsVar.varEditorSet.OsnapEntity)
		{
			point3D_0 = null;
			snapPoints = GetSnapPoints(point_0);
			if (snapPoints != null && snapPoints.Count > 0)
			{
				SnapPoint snapPoint = method_23(snapPoints);
				if (snapPoint != null)
				{
					current = snapPoint;
					currentlySnapping = true;
				}
			}
			if (points != null && points.Count >= 2 && buCompare5.EQ(points[0].Pnt3D, current, 2.0))
			{
				SnapPoint snapPoint_ = (SnapPoint)(current = new SnapPoint(points[0].Pnt3D, objectSnapType.End));
				currentlySnapping = true;
				method_24(snapPoint_);
			}
		}
		if (currentlySnapping)
		{
			return;
		}
		if (!(clsVar.varEditorSet.Ortho & (lastPoint != null) & (clsInit.appEditor2.action != actionTypeBU.None)))
		{
			if (!currentlySnapping & clsVar.varEditorSet.OsnapGrid)
			{
				clsEditorV2 appEditor = clsInit.appEditor2;
				Point3D point3D = current;
				Class5.smethod_5(point3D, ref current, appEditor);
			}
		}
		else
		{
			int OrthoDir = 0;
			if (lastPoint != null)
			{
				clsInit.cVector5.OrthoFunction(current, lastPoint, Plane.XY, ref current, ref OrthoDir);
			}
		}
	}

	private SnapPoint method_23(List<SnapPoint> list_0)
	{
		double num = double.MaxValue;
		int num2 = 0;
		int num3 = -1;
		foreach (SnapPoint item in list_0)
		{
			Point3D a = WorldToScreen(item);
			Point2D b = new Point2D(point_0.X, base.Size.Height - point_0.Y);
			double num4 = Point2D.Distance(a, b);
			if ((num4 < num) & (num4 <= (double)clsVar.varEditorSet.snapSymbolSize))
			{
				num3 = num2;
				num = num4;
			}
			num2++;
		}
		SnapPoint snapPoint = null;
		if (num3 >= 0)
		{
			snapPoint = list_0[num3];
			method_24(snapPoint);
		}
		return snapPoint;
	}

	private void method_24(SnapPoint snapPoint_0)
	{
		base.RenderContext.SetLineSize(2f);
		base.RenderContext.SetColorWireframe(Color.FromArgb(0, 0, 255));
		base.RenderContext.SetState(depthStencilStateType.DepthTestOff);
		Point2D point2D = WorldToScreen(snapPoint_0);
		point3D_0 = snapPoint_0;
		switch (snapPoint_0.Type)
		{
		case objectSnapType.Quad:
			base.RenderContext.SetLineSize(3f);
			method_27(new System.Drawing.Point((int)point2D.X, (int)point2D.Y));
			break;
		case objectSnapType.Point:
			DrawCircle(new System.Drawing.Point((int)point2D.X, (int)point2D.Y));
			DrawCross(new System.Drawing.Point((int)point2D.X, (int)point2D.Y));
			break;
		case objectSnapType.Center:
			DrawCircle(new System.Drawing.Point((int)point2D.X, (int)point2D.Y));
			break;
		case objectSnapType.End:
			DrawQuad(new System.Drawing.Point((int)point2D.X, (int)point2D.Y));
			break;
		case objectSnapType.Mid:
			method_26(new System.Drawing.Point((int)point2D.X, (int)point2D.Y));
			break;
		}
		base.RenderContext.SetLineSize(1f);
	}

	private Entity method_25(System.Drawing.Point point_1, IList<Entity> ilist_0, ref Transformation transformation_0)
	{
		GetCrossingEntities(new Rectangle(point_1.X - 5, point_1.Y - 5, 10, 10), ilist_0, firstOnly: true, out var selectedIndices, selectableOnly: true, transformation_0);
		if (selectedIndices == null || selectedIndices.Length == 0)
		{
			return null;
		}
		if (!(ilist_0[selectedIndices[0]] is BlockReference))
		{
			return ilist_0[selectedIndices[0]];
		}
		BlockReference blockReference = (BlockReference)ilist_0[selectedIndices[0]];
		transformation_0 *= blockReference.GetFullTransformation(base.Blocks);
		return method_25(point_1, base.Blocks[blockReference.BlockName].Entities, ref transformation_0);
	}

	public List<SnapPoint> GetSnapPoints(System.Drawing.Point mouseLocation)
	{
		int pickBoxSize = base.PickBoxSize;
		base.PickBoxSize = 10;
		Transformation transformation_ = Transformation.CreateIdentity();
		Entity entity = method_25(mouseLocation, base.Entities, ref transformation_);
		base.PickBoxSize = pickBoxSize;
		List<SnapPoint> list = new List<SnapPoint>();
		if (entity != null)
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
													objectSnapType activeObjectSnap = ActiveObjectSnap;
													objectSnapType objectSnapType2 = activeObjectSnap;
													if (objectSnapType2 == objectSnapType.End)
													{
														for (int i = 0; i < mesh.Vertices.Length; i++)
														{
															Point3D point3D = mesh.Vertices[i];
															list.Add(new SnapPoint(point3D, objectSnapType.End));
														}
													}
												}
											}
											else
											{
												Ellipse ellipse = (Ellipse)entity;
												list.Add(new SnapPoint(ellipse.EndPoint, objectSnapType.Point));
												list.Add(new SnapPoint(ellipse.Center, objectSnapType.Center));
												list.Add(new SnapPoint(ellipse.PointAt(ellipse.Domain.Mid), objectSnapType.Mid));
											}
										}
										else
										{
											EllipticalArc ellipticalArc = (EllipticalArc)entity;
											list.Add(new SnapPoint(ellipticalArc.StartPoint, objectSnapType.Point));
											list.Add(new SnapPoint(ellipticalArc.EndPoint, objectSnapType.Point));
											list.Add(new SnapPoint(ellipticalArc.Center, objectSnapType.Center));
										}
									}
									else
									{
										Curve curve = (Curve)entity;
										list.Add(new SnapPoint(curve.StartPoint, objectSnapType.End));
										list.Add(new SnapPoint(curve.EndPoint, objectSnapType.End));
										list.Add(new SnapPoint(curve.PointAt(0.5), objectSnapType.Mid));
									}
								}
								else
								{
									Circle circle = (Circle)entity;
									Point3D point3D2 = new Point3D(circle.Center.X, circle.Center.Y + circle.Radius);
									Point3D point3D3 = new Point3D(circle.Center.X + circle.Radius, circle.Center.Y);
									Point3D point3D4 = new Point3D(circle.Center.X, circle.Center.Y - circle.Radius);
									Point3D point3D5 = new Point3D(circle.Center.X - circle.Radius, circle.Center.Y);
									list.Add(new SnapPoint(circle.EndPoint, objectSnapType.End));
									list.Add(new SnapPoint(circle.Center, objectSnapType.Center));
									list.Add(new SnapPoint(point3D2, objectSnapType.Quad));
									list.Add(new SnapPoint(point3D3, objectSnapType.Quad));
									list.Add(new SnapPoint(point3D4, objectSnapType.Quad));
									list.Add(new SnapPoint(point3D5, objectSnapType.Quad));
								}
							}
							else
							{
								Arc arc = (Arc)entity;
								list.Add(new SnapPoint(arc.StartPoint, objectSnapType.End));
								list.Add(new SnapPoint(arc.EndPoint, objectSnapType.End));
								list.Add(new SnapPoint(arc.MidPoint, objectSnapType.Mid));
								list.Add(new SnapPoint(arc.Center, objectSnapType.Center));
							}
						}
						else
						{
							CompositeCurve compositeCurve = (CompositeCurve)entity;
							List<SnapPoint> list2 = new List<SnapPoint>();
							objectSnapType activeObjectSnap2 = ActiveObjectSnap;
							objectSnapType objectSnapType3 = activeObjectSnap2;
							if (objectSnapType3 == objectSnapType.End)
							{
								foreach (ICurve curve2 in compositeCurve.CurveList)
								{
									list2.Add(new SnapPoint(curve2.EndPoint, objectSnapType.End));
								}
								list2.Add(new SnapPoint(compositeCurve.CurveList[0].StartPoint, objectSnapType.End));
								list.AddRange(list2.ToArray());
							}
						}
					}
					else
					{
						LinearPath linearPath = (LinearPath)entity;
						List<SnapPoint> list3 = new List<SnapPoint>();
						objectSnapType activeObjectSnap3 = ActiveObjectSnap;
						objectSnapType objectSnapType4 = activeObjectSnap3;
						if (objectSnapType4 == objectSnapType.End)
						{
							Point3D[] vertices = linearPath.Vertices;
							foreach (Point3D point3D6 in vertices)
							{
								list3.Add(new SnapPoint(point3D6, objectSnapType.End));
							}
							list.AddRange(list3.ToArray());
						}
					}
				}
				else
				{
					Line line = (Line)entity;
					list.Add(new SnapPoint(line.StartPoint, objectSnapType.End));
					list.Add(new SnapPoint(line.EndPoint, objectSnapType.End));
					list.Add(new SnapPoint(line.MidPoint, objectSnapType.Mid));
				}
			}
			else
			{
				devDept.Eyeshot.Entities.Point point = (devDept.Eyeshot.Entities.Point)entity;
				objectSnapType activeObjectSnap4 = ActiveObjectSnap;
				objectSnapType objectSnapType5 = activeObjectSnap4;
				if (objectSnapType5 == objectSnapType.Point)
				{
					Point3D point3D7 = point.Vertices[0];
					list.Add(new SnapPoint(point3D7, objectSnapType.Point));
				}
			}
		}
		foreach (Entity entity2 in base.Entities)
		{
			if (entity2 is Circle)
			{
				Circle circle2 = entity2 as Circle;
				list.Add(new SnapPoint(circle2.Center, objectSnapType.Center));
			}
			if (entity2 is Ellipse)
			{
				Ellipse ellipse2 = entity2 as Ellipse;
				list.Add(new SnapPoint(ellipse2.Center, objectSnapType.Center));
			}
		}
		list.Add(new SnapPoint(new Point3D(), objectSnapType.End));
		if (transformation_ != Transformation.CreateIdentity())
		{
			foreach (SnapPoint item in list)
			{
				Point3D point3D8 = transformation_ * item;
				item.X = point3D8.X;
				item.Y = point3D8.Y;
				item.Z = point3D8.Z;
			}
		}
		return list;
	}

	public void DrawCross(System.Drawing.Point onScreen)
	{
		double num = onScreen.X + 6;
		double num2 = onScreen.Y + 6;
		double num3 = onScreen.X - 6;
		double num4 = onScreen.Y - 6;
		Point3D point3D = new Point3D(num3, num2);
		Point3D point3D2 = new Point3D(num, num2);
		Point3D point3D3 = new Point3D(num, num4);
		Point3D point3D4 = new Point3D(num3, num4);
		base.RenderContext.DrawLines(new Point3D[4] { point3D4, point3D2, point3D, point3D3 });
	}

	public void DrawCircle(System.Drawing.Point onScreen)
	{
		double num = 6.0;
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
		double num = onScreen.X + 6;
		double num2 = onScreen.Y + 6;
		double num3 = onScreen.X - 6;
		double num4 = onScreen.Y - 6;
		Point3D point3D = new Point3D(num3, num2);
		Point3D point3D2 = new Point3D(num, num2);
		Point3D point3D3 = new Point3D(num, num4);
		Point3D point3D4 = new Point3D(num3, num4);
		base.RenderContext.DrawLineLoop(new Point3D[4] { point3D4, point3D3, point3D2, point3D });
	}

	private void method_26(System.Drawing.Point point_1)
	{
		double num = point_1.X + 6;
		double num2 = point_1.Y + 6;
		double num3 = point_1.X - 6;
		double num4 = point_1.Y - 6;
		double num5 = point_1.X;
		Point3D point3D = new Point3D(num5, num2);
		Point3D point3D2 = new Point3D(num, num4);
		Point3D point3D3 = new Point3D(num3, num4);
		base.RenderContext.DrawLineLoop(new Point3D[3] { point3D3, point3D2, point3D });
	}

	private void method_27(System.Drawing.Point point_1)
	{
		double num = (double)point_1.X + 8.0;
		double num2 = (double)point_1.Y + 8.0;
		double num3 = (double)point_1.X - 8.0;
		double num4 = (double)point_1.Y - 8.0;
		Point3D point3D = new Point3D(point_1.X, num2);
		Point3D point3D2 = new Point3D(point_1.X, num4);
		Point3D point3D3 = new Point3D(num, point_1.Y);
		Point3D point3D4 = new Point3D(num3, point_1.Y);
		base.RenderContext.DrawLineLoop(new Point3D[4] { point3D2, point3D3, point3D, point3D4 });
	}
}
