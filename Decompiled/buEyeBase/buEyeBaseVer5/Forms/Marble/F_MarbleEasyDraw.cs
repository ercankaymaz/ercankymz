using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buControls;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleEasyDraw : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public List<Point3D> pntList = new List<Point3D>();

	public List<Entity> EntityList = new List<Entity>();

	private Timer timer_0 = null;

	private DrawingTypes drawingTypes_0 = DrawingTypes.Line;

	private List<buEntity> list_0 = new List<buEntity>();

	private Point3D point3D_0 = new Point3D();

	private Point3D point3D_1 = new Point3D();

	internal IContainer icontainer_0 = null;

	public buButton buButton1;

	public buButton btn_maximize;

	public buButton btn_close;

	public buGround buGround1;

	public buButton btn_open;

	public buButton btn_ok;

	public buLabel lbl_countertop;

	public Panel pnl_base;

	public buButton btn_save;

	public Panel pnl_data;

	public buButton btn_addtolist;

	internal buCheckBox buCheckBox_0;

	public buButton btn_cancel;

	public buButton btn_settings;

	public Panel pnl_viewport;

	public buLabel lbl_commands;

	public buButton btn_viewtop;

	public buButton btn_viewback;

	public buButton btn_viewfront;

	public buButton btn_viewleft;

	public buButton btn_viewright;

	public buButton btn_viewiso;

	public buButton btn_viewzoomfit;

	public buButton btn_rotate;

	public buButton btn_pan;

	internal ImageList imageList_0;

	public TreeView tree_entities;

	public buLabel lbl_items;

	public buButton btn_start;

	internal buLabel buLabel_0;

	public buSpin spn_starty;

	internal buLabel buLabel_1;

	public buSpin spn_startx;

	public buButton btn_rectangle;

	public buButton btn_circle;

	public buButton btn_arc;

	public buButton btn_polyline;

	public buTab buTab1;

	internal TabPage tabPage_0;

	public buSpin spn_length;

	public buSpin spn_angle;

	public TabPage tabPage_builtin;

	internal TabPage tabPage_1;

	internal buPanel buPanel_0;

	internal TabPage tabPage_2;

	internal buPanel buPanel_1;

	public buButton btn_leftup;

	public buButton btn_right;

	public buButton btn_rightdown;

	public buButton btn_left;

	public buButton btn_rightup;

	public buButton btn_up;

	public buButton btn_down;

	public buButton btn_leftdown;

	internal buPanel buPanel_2;

	public buSpin spn_diameter;

	public buSpin spn_width;

	public buSpin spn_height;

	public buButton btn_undo;

	public buButton btn_clear;

	public buButton btn_angle;

	public buTab buTab2;

	internal TabPage tabPage_3;

	public TabPage tabPage2;

	public buButton btn_length;

	public buButton btn_closedrawing;

	public buButton btn_add;

	public buSpin spn_dy;

	public buSpin spn_dx;

	public F_MarbleEasyDraw()
	{
		Class186.smethod_810(this);
		timer_0 = new Timer();
		timer_0.Interval = 50;
		timer_0.Tick += timer_0_Tick;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			base.Height = PropertiesForm.Height;
		}
		if (PropertiesForm.Width > 10)
		{
			base.Width = PropertiesForm.Width;
		}
		base.TopMost = PropertiesForm.TopMost;
		base.StartPosition = PropertiesForm.FormPosition;
		Class186.smethod_772(this);
		list_0.Clear();
		EntityList.Clear();
		tree_entities.Nodes.Clear();
		buTab1.ItemSize = new Size(1, 1);
		buTab2.ItemSize = new Size(1, 1);
		Class186.smethod_438(this);
		MenuButtonColors(buMarbleCalc.varMarbleRunSettings.BasicDrawLineMethod);
		MenuButtonDrawColors(drawingTypes_0);
		MenuButtonAngleColors(buMarbleCalc.varMarbleRunSettings.BasicDrawAngle);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		Class186.smethod_481(this);
	}

	public void DrawLineCoord(ref Point3D pNext)
	{
		pNext = new Point3D();
		if (buTab2.SelectedIndex != 0)
		{
			if (buTab2.SelectedIndex == 1)
			{
				pNext.X = point3D_1.X + spn_dx.Value;
				pNext.Y = point3D_1.Y + spn_dy.Value;
			}
		}
		else
		{
			buCall.buVector5_0.LineWithLengthAndAngle(point3D_1, spn_length.Value, spn_angle.Value, ref pNext);
		}
	}

	public void AddToList(DrawingTypes T)
	{
		int num = 0;
		string nodeText = "";
		switch (T)
		{
		case DrawingTypes.Line:
			num = 0;
			nodeText = buLangTranslate.preDef.Line;
			break;
		case DrawingTypes.Arc:
			num = 1;
			nodeText = buLangTranslate.preDef.Arc;
			break;
		case DrawingTypes.Circle:
			num = 2;
			nodeText = buLangTranslate.preDef.Cirlce;
			break;
		case DrawingTypes.Rectangle:
			num = 3;
			nodeText = buLangTranslate.preDef.Rectangle;
			break;
		}
		buTreeNode node = new buTreeNode(nodeText)
		{
			ImageIndex = num,
			SelectedImageIndex = num,
			Tag = "0",
			ClassIndex = 0,
			ClassSubIndex = -1,
			Command = T.ToString(),
			Checked = true
		};
		tree_entities.Nodes.Add(node);
	}

	public void AddJoint(Point3D Pnt)
	{
		Joint joint = new Joint(new Point3D(Pnt.X, Pnt.Y, 0.0), 10.0, 2);
		joint.ColorMethod = colorMethodType.byEntity;
		joint.Color = Color.WhiteSmoke;
		CustomData customData = new CustomData();
		customData.typeDefination = entityTypeDefination.Mark;
		joint.EntityData = customData;
		buEyeItems.viewportDialogs.Entities.Add(joint);
		buEyeItems.viewportDialogs.Invalidate();
	}

	public void RemoveJoint()
	{
		if (buEyeItems.viewportDialogs.Entities.Count > 0)
		{
			if (buEyeItems.viewportDialogs.Entities[buEyeItems.viewportDialogs.Entities.Count - 1] is Joint)
			{
				buEyeItems.viewportDialogs.Entities.RemoveAt(buEyeItems.viewportDialogs.Entities.Count - 1);
			}
			if (buEyeItems.viewportDialogs.Entities.Count > 0 && buEyeItems.viewportDialogs.Entities[buEyeItems.viewportDialogs.Entities.Count - 1] is Joint)
			{
				buEyeItems.viewportDialogs.Entities.RemoveAt(buEyeItems.viewportDialogs.Entities.Count - 1);
			}
		}
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (PropertiesForm.Result != DialogResult.OK)
		{
			e.Cancel = true;
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		try
		{
			Control control = sender as Control;
			if (control.Name == btn_angle.Name)
			{
				MenuButtonColors(0);
			}
			if (control.Name == btn_length.Name)
			{
				MenuButtonColors(1);
			}
			if (!(control.Name == btn_rotate.Name))
			{
				if (!(control.Name == btn_pan.Name))
				{
					if (!(control.Name == btn_viewtop.Name))
					{
						if (!(control.Name == btn_viewfront.Name))
						{
							if (!(control.Name == btn_viewback.Name))
							{
								if (!(control.Name == btn_viewleft.Name))
								{
									if (!(control.Name == btn_viewright.Name))
									{
										if (!(control.Name == btn_viewiso.Name))
										{
											if (!(control.Name == btn_viewzoomfit.Name))
											{
												if (control.Name == btn_add.Name)
												{
													DrawLineCoord(ref point3D_0);
													double num = buCall.buVector5_0.Length3D(point3D_1, point3D_0, Plane.XY);
													CustomData customData = null;
													if (num > 0.0)
													{
														RemoveJoint();
														if (drawingTypes_0 == DrawingTypes.Line)
														{
															Line line = new Line(buVector5.ToPoint3D(point3D_1), buVector5.ToPoint3D(point3D_0));
															line.LayerName = "Default";
															line.Color = Color.Black;
															line.LineWeight = 2f;
															line.ColorMethod = colorMethodType.byEntity;
															line.LineWeightMethod = colorMethodType.byEntity;
															customData = new CustomData();
															customData.typeDefination = entityTypeDefination.Drawing;
															customData.infoBasePoint = new Point3D(point3D_0.X, point3D_0.Y);
															line.EntityData = customData;
															buEyeItems.viewportDialogs.Entities.Add(line);
															EntityList.Add(line);
															AddToList(drawingTypes_0);
														}
														if (drawingTypes_0 == DrawingTypes.Arc)
														{
															if (pntList.Count != 0)
															{
																if (buEyeItems.viewportDialogs.Entities.Count > 0 && buEyeItems.viewportDialogs.Entities[buEyeItems.viewportDialogs.Entities.Count - 1] is LinearPath)
																{
																	buEyeItems.viewportDialogs.Entities.RemoveAt(buEyeItems.viewportDialogs.Entities.Count - 1);
																}
																Arc arc = new Arc(buVector5.ToPoint3D(pntList[0]), buVector5.ToPoint3D(pntList[1]), buVector5.ToPoint3D(point3D_0), flip: false);
																arc.LayerName = "Default";
																arc.Color = Color.Black;
																arc.LineWeight = 2f;
																arc.ColorMethod = colorMethodType.byEntity;
																arc.LineWeightMethod = colorMethodType.byEntity;
																customData = new CustomData();
																customData.typeDefination = entityTypeDefination.Drawing;
																customData.infoBasePoint = new Point3D(point3D_0.X, point3D_0.Y);
																arc.EntityData = customData;
																buEyeItems.viewportDialogs.Entities.Add(arc);
																EntityList.Add(arc);
																pntList.Clear();
																AddToList(drawingTypes_0);
															}
															else
															{
																pntList.Add(new Point3D(point3D_1.X, point3D_1.Y));
																pntList.Add(new Point3D(point3D_0.X, point3D_0.Y));
																List<Point3D> list = new List<Point3D>();
																list.Add(point3D_1);
																list.Add(point3D_0);
																LinearPath linearPath = new LinearPath(list);
																linearPath.LayerName = "Default";
																linearPath.Color = Color.Red;
																linearPath.LineWeight = 1f;
																linearPath.ColorMethod = colorMethodType.byEntity;
																linearPath.LineWeightMethod = colorMethodType.byEntity;
																customData = new CustomData();
																customData.typeDefination = entityTypeDefination.Drawing;
																linearPath.EntityData = customData;
																buEyeItems.viewportDialogs.Entities.Add(linearPath);
															}
														}
														AddJoint(point3D_0);
														point3D_1.X = point3D_0.X;
														point3D_1.Y = point3D_0.Y;
													}
												}
												if (control.Name == btn_clear.Name && buString5.MessageBoxQuestion(buLangTranslate.preSentences.DoYouWantToDelete) == DialogResult.Yes)
												{
													tree_entities.Nodes.Clear();
													pntList.Clear();
													EntityList.Clear();
													buEyeItems.viewportDialogs.Entities.Clear();
													buEyeItems.viewportDialogs.Invalidate();
												}
												if (control.Name == btn_arc.Name)
												{
													drawingTypes_0 = DrawingTypes.Arc;
													MenuButtonDrawColors(drawingTypes_0);
												}
												if (control.Name == btn_polyline.Name)
												{
													drawingTypes_0 = DrawingTypes.Line;
													MenuButtonDrawColors(drawingTypes_0);
												}
												if (control.Name == btn_circle.Name)
												{
													drawingTypes_0 = DrawingTypes.Circle;
													MenuButtonDrawColors(drawingTypes_0);
												}
												if (control.Name == btn_rectangle.Name)
												{
													drawingTypes_0 = DrawingTypes.Rectangle;
													MenuButtonDrawColors(drawingTypes_0);
												}
												if (control.Name == btn_undo.Name)
												{
													if (EntityList.Count <= 0)
													{
														method_1(btn_start, e);
													}
													else
													{
														RemoveJoint();
														if (buEyeItems.viewportDialogs.Entities.Count > 0)
														{
															buEyeItems.viewportDialogs.Entities.RemoveAt(buEyeItems.viewportDialogs.Entities.Count - 1);
														}
														if (pntList.Count <= 1)
														{
															EntityList.RemoveAt(EntityList.Count - 1);
															pntList.Clear();
															if (tree_entities.Nodes.Count > 0)
															{
																tree_entities.Nodes.RemoveAt(tree_entities.Nodes.Count - 1);
															}
															if (EntityList.Count != 0)
															{
																Entity entity = EntityList[EntityList.Count - 1];
																point3D_1 = new Point3D(((CustomData)entity.EntityData).infoBasePoint.X, ((CustomData)entity.EntityData).infoBasePoint.Y);
																AddJoint(point3D_1);
															}
															else
															{
																method_1(btn_start, e);
															}
														}
														else
														{
															point3D_1 = new Point3D(pntList[0].X, pntList[0].Y);
															EntityList.RemoveAt(EntityList.Count - 1);
															pntList.Clear();
															AddJoint(point3D_1);
														}
														buEyeItems.viewportDialogs.Invalidate();
													}
												}
												if (control.Name == btn_start.Name)
												{
													buEyeItems.viewportDialogs.SetView(viewType.Top);
													buEyeItems.viewportDialogs.Invalidate();
													pntList.Clear();
													buEyeItems.viewportDialogs.Entities.Clear();
													point3D_1 = new Point3D(spn_startx.Value, spn_starty.Value, 0.0);
													Joint joint = new Joint(new Point3D(spn_startx.Value, spn_starty.Value, 0.0), 20.0, 2);
													joint.ColorMethod = colorMethodType.byEntity;
													joint.Color = Color.WhiteSmoke;
													CustomData customData2 = new CustomData();
													customData2.typeDefination = entityTypeDefination.Mark;
													joint.EntityData = customData2;
													buEyeItems.viewportDialogs.Entities.Add(joint);
													tree_entities.Nodes.Clear();
													EntityList.Clear();
												}
												if (control.Name == btn_closedrawing.Name && EntityList.Count > 0)
												{
													RemoveJoint();
													Line line2 = new Line(new Point3D(point3D_1.X, point3D_1.Y), new Point3D());
													line2.LayerName = "Default";
													line2.Color = Color.Black;
													line2.LineWeight = 2f;
													line2.ColorMethod = colorMethodType.byEntity;
													line2.LineWeightMethod = colorMethodType.byEntity;
													CustomData customData3 = new CustomData();
													customData3.typeDefination = entityTypeDefination.Drawing;
													customData3.infoBasePoint = new Point3D(point3D_0.X, point3D_0.Y);
													line2.EntityData = customData3;
													buEyeItems.viewportDialogs.Entities.Add(line2);
													EntityList.Add(line2);
													AddToList(drawingTypes_0);
													point3D_1.X = 0.0;
													point3D_1.Y = 0.0;
													AddJoint(point3D_1);
												}
												if (!(control.Name == btn_left.Name))
												{
													if (!(control.Name == btn_leftdown.Name))
													{
														if (!(control.Name == btn_leftup.Name))
														{
															if (!(control.Name == btn_up.Name))
															{
																if (!(control.Name == btn_down.Name))
																{
																	if (!(control.Name == btn_right.Name))
																	{
																		if (!(control.Name == btn_rightdown.Name))
																		{
																			if (control.Name == btn_rightup.Name)
																			{
																				spn_angle.Value = 45.0;
																				MenuButtonAngleColors(spn_angle.Value);
																			}
																		}
																		else
																		{
																			spn_angle.Value = 315.0;
																			MenuButtonAngleColors(spn_angle.Value);
																		}
																	}
																	else
																	{
																		spn_angle.Value = 0.0;
																		MenuButtonAngleColors(spn_angle.Value);
																	}
																}
																else
																{
																	spn_angle.Value = 270.0;
																	MenuButtonAngleColors(spn_angle.Value);
																}
															}
															else
															{
																spn_angle.Value = 90.0;
																MenuButtonAngleColors(spn_angle.Value);
															}
														}
														else
														{
															spn_angle.Value = 135.0;
															MenuButtonAngleColors(spn_angle.Value);
														}
													}
													else
													{
														spn_angle.Value = 225.0;
														MenuButtonAngleColors(spn_angle.Value);
													}
												}
												else
												{
													spn_angle.Value = 180.0;
													MenuButtonAngleColors(spn_angle.Value);
												}
												if (!(control.Name == btn_settings.Name))
												{
												}
												if (control.Name == btn_save.Name)
												{
													SaveFileDialog saveFileDialog = new SaveFileDialog();
													saveFileDialog.Filter = "Dxf Files (*.dxf)|*.dxf";
													saveFileDialog.InitialDirectory = buMarbleCalc.varMarbleRunSettings.pathEasyDraw;
													if (saveFileDialog.ShowDialog() == DialogResult.OK)
													{
														RemoveJoint();
														buFile5.SaveDxfDwg(buEyeItems.viewportDialogs, saveFileDialog.FileName);
														buMarbleCalc.varMarbleRunSettings.pathEasyDraw = buFile5.GetPath(saveFileDialog.FileName);
														AddJoint(point3D_0);
													}
												}
												if (control.Name == btn_ok.Name)
												{
													Class186.smethod_154(this);
													PropertiesForm.Result = DialogResult.OK;
													if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
													{
														Dispose();
													}
													if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
													{
														base.Visible = false;
													}
												}
												if ((control.Name == btn_cancel.Name) | (control.Name == btn_close.Name))
												{
													PropertiesForm.Result = DialogResult.Cancel;
													if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
													{
														Dispose();
													}
													if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
													{
														base.Visible = false;
													}
												}
											}
											else
											{
												buEyeItems.viewportDialogs.ZoomFit(10);
												buEyeItems.viewportDialogs.Invalidate();
											}
										}
										else
										{
											buEyeItems.viewportDialogs.SetView(viewType.Trimetric);
											buEyeItems.viewportDialogs.Invalidate();
										}
									}
									else
									{
										buEyeItems.viewportDialogs.SetView(viewType.Right);
										buEyeItems.viewportDialogs.Invalidate();
									}
								}
								else
								{
									buEyeItems.viewportDialogs.SetView(viewType.Left);
									buEyeItems.viewportDialogs.Invalidate();
								}
							}
							else
							{
								buEyeItems.viewportDialogs.SetView(viewType.Rear);
								buEyeItems.viewportDialogs.Invalidate();
							}
						}
						else
						{
							buEyeItems.viewportDialogs.SetView(viewType.Front);
							buEyeItems.viewportDialogs.Invalidate();
						}
					}
					else
					{
						buEyeItems.viewportDialogs.SetView(viewType.Top);
						buEyeItems.viewportDialogs.Invalidate();
					}
				}
				else if (buEyeItems.viewportDialogs.ActionMode != actionType.Pan)
				{
					buEyeItems.viewportDialogs.ActionMode = actionType.Pan;
				}
				else
				{
					buEyeItems.viewportDialogs.ActionMode = actionType.None;
				}
			}
			else if (buEyeItems.viewportDialogs.ActionMode != actionType.Rotate)
			{
				buEyeItems.viewportDialogs.ActionMode = actionType.Rotate;
			}
			else
			{
				buEyeItems.viewportDialogs.ActionMode = actionType.None;
			}
		}
		catch (Exception)
		{
		}
	}

	public void spn_Leave(object sender, EventArgs e)
	{
	}

	internal void method_2(object sender, EventArgs e)
	{
		buSpin buSpin2 = sender as buSpin;
		if (AppBool.TouchPad)
		{
			F_KeyPadNumV1 f_KeyPadNumV = new F_KeyPadNumV1();
			f_KeyPadNumV.StartPosition = FormStartPosition.CenterParent;
			f_KeyPadNumV.Caption = buSpin2.Caption.Caption;
			f_KeyPadNumV.ShowDialog(buSpin2.Value.ToString());
			if (buNumeric5.IsNumeric(f_KeyPadNumV.Value))
			{
				buSpin2.Value = double.Parse(f_KeyPadNumV.Value);
			}
		}
	}

	public void MenuButtonColors(int PageIndex)
	{
		Control.ControlCollection controls = tabPage_0.Controls;
		controls = hmiUICommands.SetVisualItem(controls);
		if (PageIndex == 0)
		{
			btn_angle.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_angle.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_angle.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
		}
		if (PageIndex == 1)
		{
			btn_length.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_length.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_length.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
		}
		buTab2.SelectedIndex = PageIndex;
	}

	public void MenuButtonDrawColors(DrawingTypes T)
	{
		Control.ControlCollection controls = pnl_data.Controls;
		controls = hmiUICommands.SetVisualItem(controls);
		if (T == DrawingTypes.Line)
		{
			btn_polyline.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_polyline.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_polyline.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			buTab1.SelectedIndex = 0;
		}
		if (T == DrawingTypes.Arc)
		{
			btn_arc.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_arc.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_arc.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			buTab1.SelectedIndex = 0;
		}
		if (T == DrawingTypes.Circle)
		{
			btn_circle.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_circle.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_circle.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			buTab1.SelectedIndex = 1;
		}
		if (T == DrawingTypes.Rectangle)
		{
			btn_rectangle.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_rectangle.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_rectangle.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			buTab1.SelectedIndex = 2;
		}
	}

	public void MenuButtonAngleColors(double Angle)
	{
		Control.ControlCollection controls = tabPage_3.Controls;
		controls = hmiUICommands.SetVisualItem(controls);
		if (Angle == 0.0)
		{
			btn_right.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_right.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_right.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
		}
		if (Angle == 45.0)
		{
			btn_rightup.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_rightup.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_rightup.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
		}
		if (Angle == 90.0)
		{
			btn_up.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_up.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_up.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
		}
		if (Angle == 135.0)
		{
			btn_leftup.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_leftup.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_leftup.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
		}
		if (Angle == 180.0)
		{
			btn_left.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_left.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_left.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
		}
		if (Angle == 225.0)
		{
			btn_leftdown.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_leftdown.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_leftdown.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
		}
		if (Angle == 270.0)
		{
			btn_down.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_down.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_down.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
		}
		if (Angle == 315.0)
		{
			btn_rightdown.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_rightdown.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_rightdown.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
		}
	}

	internal void method_3(object sender, TreeViewEventArgs e)
	{
	}

	internal void method_4(object sender, EventArgs e)
	{
	}

	internal void method_5(object sender, TreeNodeMouseClickEventArgs e)
	{
		if (!(AppBool.ListFilling | AppBool.TreeCollapsing | AppBool.TreeExpanding))
		{
			AppBool.TreeNodeClicked = true;
			buTreeNode buTreeNode2 = (buTreeNode)e.Node;
			string command = buTreeNode2.Command;
			string text = command;
			if (text == "main")
			{
				buTab1.SelectedIndex = 0;
			}
			AppBool.TreeNodeClicked = false;
		}
		else
		{
			AppBool.TreeCollapsing = false;
			AppBool.TreeExpanding = false;
		}
	}

	internal void method_6(object sender, TreeViewCancelEventArgs e)
	{
		AppBool.TreeExpanding = true;
	}

	internal void method_7(object sender, TreeViewCancelEventArgs e)
	{
		AppBool.TreeCollapsing = true;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
