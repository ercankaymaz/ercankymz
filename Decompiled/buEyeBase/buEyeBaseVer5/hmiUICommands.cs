using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buCore;
using buMutliTextbox;

namespace buEyeBaseVer5;

[Serializable]
public class hmiUICommands : buSerilization5
{
	public static buLabel hmiToBuLabel(hmiUISettings data, buLabel Lbl)
	{
		try
		{
			Lbl.Geometry.ArcDiameter = data.Parameters.GeometryArcDiameer;
			Lbl.Geometry.ShapeMode = data.Parameters.GeometryType;
			Lbl.Display = buControlDisplay.Copy(data.Display, Lbl.Display);
			if (data.Parameters.GeometryType != ShapeType.Rectangle)
			{
				Lbl.BackColor = Color.Transparent;
			}
			return Lbl;
		}
		catch (Exception)
		{
			return Lbl;
		}
	}

	public static buLabel hmiToBuLabel(hmiUIBasicSettings data, buLabel Lbl)
	{
		try
		{
			Lbl.Geometry.ArcDiameter = data.Parameters.GeometryArcDiameer;
			Lbl.Geometry.ShapeMode = data.Parameters.GeometryType;
			Lbl.Display = buControlDisplay.Copy(data.Display, Lbl.Display);
			if (data.Parameters.GeometryType != ShapeType.Rectangle)
			{
				Lbl.BackColor = Color.Transparent;
			}
			return Lbl;
		}
		catch (Exception)
		{
			return Lbl;
		}
	}

	public static buLabel hmiToBuLabel(buControlDisplay display, hmiUIPars parameters, buLabel Lbl)
	{
		try
		{
			Lbl.Geometry.ArcDiameter = parameters.GeometryArcDiameer;
			Lbl.Geometry.ShapeMode = parameters.GeometryType;
			Lbl.Display = buControlDisplay.Copy(display, Lbl.Display);
			if (parameters.GeometryType != ShapeType.Rectangle)
			{
				Lbl.BackColor = Color.Transparent;
			}
			return Lbl;
		}
		catch (Exception)
		{
			return Lbl;
		}
	}

	public static buListBox hmiToBuListBox(hmiUISettings data, buListBox Lst)
	{
		try
		{
			Lst.Geometry.ArcDiameter = data.Parameters.GeometryArcDiameer;
			Lst.Geometry.ShapeMode = data.Parameters.GeometryType;
			Lst.Display = buControlDisplay.Copy(data.Display, Lst.Display);
			if (data.Parameters.GeometryType != ShapeType.Rectangle)
			{
				Lst.BackColor = Color.Transparent;
			}
			return Lst;
		}
		catch (Exception)
		{
			return Lst;
		}
	}

	public static buComboBox hmiToBuCombobox(hmiUISettings data, buComboBox Lst)
	{
		try
		{
			Lst.Geometry.ArcDiameter = data.Parameters.GeometryArcDiameer;
			Lst.Geometry.ShapeMode = data.Parameters.GeometryType;
			Lst.Display = buControlDisplay.Copy(data.Display, Lst.Display);
			Lst.Caption.Display = buControlDisplay.Copy(data.Caption, Lst.Caption.Display);
			Lst.Combo.DropBoxColor = data.Parameters.DropColor;
			Lst.Combo.ArrowColor = data.Parameters.ArrowColor;
			Lst.Combo.ValueColor = data.Display.BackColor;
			Lst.Combo.ArrowLineColor = data.Parameters.LineColor;
			Lst.Combo.ArrowButtonWidth = data.Parameters.ObjectWidth;
			if (data.Parameters.GeometryType != ShapeType.Rectangle)
			{
				Lst.BackColor = Color.Transparent;
			}
			return Lst;
		}
		catch (Exception)
		{
			return Lst;
		}
	}

	public static DataGridView hmiToDataGridView(hmiUIDataGridView data, DataGridView Dvg)
	{
		try
		{
			Dvg.EnableHeadersVisualStyles = false;
			Dvg.ColumnHeadersDefaultCellStyle.BackColor = data.colorHeader;
			Dvg.ColumnHeadersDefaultCellStyle.ForeColor = data.colorHeaderFore;
			Dvg.ColumnHeadersDefaultCellStyle.Font = new Font(data.fontHeader.Name, data.fontHeader.Size, data.fontHeader.Style);
			Dvg.RowHeadersDefaultCellStyle.ForeColor = data.colorHeaderFore;
			Dvg.RowHeadersDefaultCellStyle.BackColor = data.colorHeader;
			Dvg.CellBorderStyle = DataGridViewCellBorderStyle.Single;
			Dvg.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			Dvg.GridColor = data.colorGrid;
			Dvg.BackgroundColor = data.colorBackGround;
			Dvg.DefaultCellStyle.SelectionBackColor = data.colorCellSelected;
			Dvg.DefaultCellStyle.SelectionForeColor = data.colorFore;
			Dvg.DefaultCellStyle.Font = new Font(data.fontCell.Name, data.fontCell.Size, data.fontCell.Style);
			Dvg.DefaultCellStyle.BackColor = data.colorCell;
			Dvg.DefaultCellStyle.ForeColor = data.colorFore;
			return Dvg;
		}
		catch (Exception)
		{
			return Dvg;
		}
	}

	public static RadioButton hmiToRadioButton(hmiUISettings data, RadioButton Radio)
	{
		try
		{
			Radio.BackColor = data.Display.BackColor;
			Radio.ForeColor = data.Display.Fonts.ForeColor;
			Radio.TextAlign = data.Display.Fonts.Alignment;
			if (data.Display.Fonts.Font.Name.Trim().Length > 0)
			{
				Radio.Font = new Font(data.Display.Fonts.Font.Name, data.Display.Fonts.Font.Size, data.Display.Fonts.Font.Style);
			}
			return Radio;
		}
		catch (Exception)
		{
			return Radio;
		}
	}

	public static buSpin hmiToBuSpin(hmiUISettings data, buSpin Spn)
	{
		try
		{
			Spn.Geometry.ArcDiameter = data.Parameters.GeometryArcDiameer;
			Spn.Geometry.ShapeMode = data.Parameters.GeometryType;
			Spn.Display = buControlDisplay.Copy(data.Display, Spn.Display);
			Spn.Caption.Display = buControlDisplay.Copy(data.Caption, Spn.Caption.Display);
			Spn.ButtonDownDisplay = buControlDisplay.Copy(data.ButtonDown, Spn.ButtonDownDisplay);
			Spn.ButtonOverDisplay = buControlDisplay.Copy(data.ButtonOver, Spn.ButtonOverDisplay);
			Spn.ButtonNormalDisplay = buControlDisplay.Copy(data.ButtonNormal, Spn.ButtonNormalDisplay);
			if (data.Parameters.GeometryType != ShapeType.Rectangle)
			{
				Spn.BackColor = Color.Transparent;
			}
			return Spn;
		}
		catch (Exception)
		{
			return Spn;
		}
	}

	public static buTextBox hmiToBuTextBox(hmiUISettings data, buTextBox Txt)
	{
		try
		{
			Txt.Geometry.ArcDiameter = data.Parameters.GeometryArcDiameer;
			Txt.Geometry.ShapeMode = data.Parameters.GeometryType;
			Txt.Display = buControlDisplay.Copy(data.Display, Txt.Display);
			Txt.Caption.Display = buControlDisplay.Copy(data.Caption, Txt.Caption.Display);
			if (data.Parameters.GeometryType != ShapeType.Rectangle)
			{
				Txt.BackColor = Color.Transparent;
			}
			return Txt;
		}
		catch (Exception)
		{
			return Txt;
		}
	}

	public static buMultiTextBox hmiToBuMultiTextBox(hmiUISettings data, buMultiTextBox Txt)
	{
		try
		{
			Txt.BackColor = data.Display.BackColor;
			return Txt;
		}
		catch (Exception)
		{
			return Txt;
		}
	}

	public static buCheckBox hmiToBuCheckbox(hmiUISettings data, buCheckBox Chk)
	{
		try
		{
			Chk.Geometry.ArcDiameter = data.Parameters.GeometryArcDiameer;
			Chk.Geometry.ShapeMode = data.Parameters.GeometryType;
			Chk.Display = buControlDisplay.Copy(data.Display, Chk.Display);
			Chk.CheckTick.TickDisplay = buControlDisplay.Copy(data.Caption, Chk.CheckTick.TickDisplay);
			Chk.CheckTick.ColorModeDisplay = buControlDisplay.Copy(data.ButtonNormal, Chk.CheckTick.ColorModeDisplay);
			if (data.Parameters.GeometryType != ShapeType.Rectangle)
			{
				Chk.BackColor = Color.Transparent;
			}
			Chk.CheckTick.Visible = data.Parameters.CheckBoxVisible;
			Chk.CheckTick.ColorModeEnable = data.Parameters.CheckColorMode;
			if (data.Parameters.CheckBoxSize >= 0)
			{
				Chk.CheckTick.BoxSize = data.Parameters.CheckBoxSize;
			}
			if (!data.Parameters.CheckBoxCheckIsRectangle)
			{
				Chk.CheckTick.Shape = ShapeType.Arc;
			}
			else
			{
				Chk.CheckTick.Shape = ShapeType.Rectangle;
			}
			return Chk;
		}
		catch (Exception)
		{
			return Chk;
		}
	}

	public static buTrack hmiToBuTrack(hmiUISettings data, hmiUISettings dataDone, hmiUISettings dataDrawer, buTrack Track)
	{
		try
		{
			Track.Geometry.ArcDiameter = data.Parameters.GeometryArcDiameer;
			Track.Geometry.ShapeMode = data.Parameters.GeometryType;
			Track.Display = buControlDisplay.Copy(data.Display, Track.Display);
			Track.Track.DoneDisplay = buControlDisplay.Copy(dataDone.Display, Track.Track.DoneDisplay);
			Track.Track.DrawerDisplay = buControlDisplay.Copy(dataDrawer.Display, Track.Track.DrawerDisplay);
			if (data.Parameters.GeometryType == ShapeType.Arc)
			{
				Track.BackColor = Color.Transparent;
			}
			return Track;
		}
		catch (Exception)
		{
			return Track;
		}
	}

	public static buTrack hmiToBuTrack(hmiUISettings data, buTrack Track)
	{
		try
		{
			Track.Geometry.ArcDiameter = data.Parameters.GeometryArcDiameer;
			Track.Geometry.ShapeMode = data.Parameters.GeometryType;
			Track.Caption.Display = buControlDisplay.Copy(data.Caption, Track.Display);
			Track.Display = buControlDisplay.Copy(data.Display, Track.Display);
			Track.Track.DoneDisplay = buControlDisplay.Copy(data.Done, Track.Track.DoneDisplay);
			Track.Track.DrawerDisplay = buControlDisplay.Copy(data.Shape, Track.Track.DrawerDisplay);
			Track.Track.ShowPersentage = data.Parameters.ShowPersentage;
			Track.Track.DrawerWidth = data.Parameters.ObjectWidth;
			if (data.Parameters.GeometryType == ShapeType.Arc)
			{
				Track.BackColor = Color.Transparent;
			}
			return Track;
		}
		catch (Exception)
		{
			return Track;
		}
	}

	public static buProgressBar hmiToBuProgress(hmiUISettings data, buProgressBar Progress)
	{
		try
		{
			Progress.Geometry.ArcDiameter = data.Parameters.GeometryArcDiameer;
			Progress.Geometry.ShapeMode = data.Parameters.GeometryType;
			Progress.Caption.Display = buControlDisplay.Copy(data.Caption, Progress.Display);
			Progress.Display = buControlDisplay.Copy(data.Display, Progress.Display);
			Progress.ProgressLineer.DoneDisplay = buControlDisplay.Copy(data.Done, Progress.ProgressLineer.DoneDisplay);
			Progress.ProgressLineer.ShowPercentage = data.Parameters.ShowPersentage;
			if (data.Parameters.GeometryType == ShapeType.Arc)
			{
				Progress.BackColor = Color.Transparent;
			}
			return Progress;
		}
		catch (Exception)
		{
			return Progress;
		}
	}

	public static buPanel hmiToBuPanel(hmiUISettings data, buPanel Pnl)
	{
		try
		{
			Pnl.Geometry.ArcDiameter = data.Parameters.GeometryArcDiameer;
			Pnl.Geometry.ShapeMode = data.Parameters.GeometryType;
			Pnl.Display = buControlDisplay.Copy(data.Display, Pnl.Display);
			return Pnl;
		}
		catch (Exception)
		{
			return Pnl;
		}
	}

	public static buGroup hmiToBuGroup(hmiUISettings data, buGroup Group)
	{
		try
		{
			Group.Geometry.ArcDiameter = data.Parameters.GeometryArcDiameer;
			Group.Geometry.ShapeMode = data.Parameters.GeometryType;
			Group.TitleDisplay = buControlDisplay.Copy(data.Caption, Group.TitleDisplay);
			Group.Display = buControlDisplay.Copy(data.Display, Group.Display);
			Group.TitleHeight = data.Parameters.TopHeight;
			if (data.Parameters.GeometryType == ShapeType.Arc)
			{
				Group.BackColor = Color.Transparent;
			}
			return Group;
		}
		catch (Exception)
		{
			return Group;
		}
	}

	public static buGround hmiToBuGround(hmiUISettings data, hmiUISettings dataTop, hmiUISettings dataBottom, buGround Ground)
	{
		try
		{
			Ground.Geometry.ArcDiameter = data.Parameters.GeometryArcDiameer;
			Ground.Geometry.ShapeMode = data.Parameters.GeometryType;
			Ground.Display = buControlDisplay.Copy(data.Display, Ground.Display);
			Ground.DisplayTop = buControlDisplay.Copy(dataTop.Display, Ground.DisplayTop);
			Ground.DisplayBottom = buControlDisplay.Copy(dataBottom.Display, Ground.DisplayBottom);
			return Ground;
		}
		catch (Exception)
		{
			return Ground;
		}
	}

	public static buGround hmiToBuGround(hmiUISettings data, buGround Group)
	{
		try
		{
			Group.Geometry.ArcDiameter = data.Parameters.GeometryArcDiameer;
			Group.Geometry.ShapeMode = data.Parameters.GeometryType;
			Group.DisplayTop = buControlDisplay.Copy(data.Caption, Group.DisplayTop);
			Group.DisplayBottom = buControlDisplay.Copy(data.Shape, Group.DisplayBottom);
			Group.Display = buControlDisplay.Copy(data.Display, Group.Display);
			Group.Ground.TopHeight = data.Parameters.TopHeight;
			Group.Ground.BottomHeight = data.Parameters.BottomHeight;
			if (data.Parameters.GeometryType == ShapeType.Arc)
			{
				Group.BackColor = Color.Transparent;
			}
			return Group;
		}
		catch (Exception)
		{
			return Group;
		}
	}

	public static buButton hmiToBuButton(hmiUISettings dataNormal, double ToneChange, buButton Btn)
	{
		try
		{
			Btn.Geometry.ArcDiameter = dataNormal.Parameters.GeometryArcDiameer;
			Btn.Geometry.ShapeMode = dataNormal.Parameters.GeometryType;
			Btn.Display = buControlDisplay.Copy(dataNormal.ButtonNormal, Btn.Display);
			Btn.ButtonDownDisplay = buControlDisplay.Copy(dataNormal.ButtonDown, Btn.ButtonDownDisplay);
			Btn.ButtonOverDisplay = buControlDisplay.Copy(dataNormal.ButtonOver, Btn.ButtonOverDisplay);
			Btn.Display.SelectionColor = dataNormal.Display.SelectionColor;
			Btn.ButtonOverDisplay.BackColor = buImage5.ColorToneChange(dataNormal.Display.BackColor, 1.0 + ToneChange);
			Btn.ButtonDownDisplay.BackColor = buImage5.ColorToneChange(dataNormal.Display.BackColor, 1.0 + 2.0 * ToneChange);
			Btn.ButtonOverDisplay.LineerGradient.FirstColor = buImage5.ColorToneChange(dataNormal.ButtonNormal.LineerGradient.FirstColor, 1.0 + ToneChange);
			Btn.ButtonOverDisplay.LineerGradient.SecondColor = buImage5.ColorToneChange(dataNormal.ButtonNormal.LineerGradient.SecondColor, 1.0 + ToneChange);
			Btn.ButtonDownDisplay.LineerGradient.FirstColor = buImage5.ColorToneChange(dataNormal.ButtonNormal.LineerGradient.FirstColor, 1.0 + 2.0 * ToneChange);
			Btn.ButtonDownDisplay.LineerGradient.SecondColor = buImage5.ColorToneChange(dataNormal.ButtonNormal.LineerGradient.SecondColor, 1.0 + 2.0 * ToneChange);
			if ((dataNormal.Parameters.GeometryType == ShapeType.Arc) | (dataNormal.Parameters.GeometryType == ShapeType.Ellipse))
			{
				Btn.BackColor = Color.Transparent;
			}
			return Btn;
		}
		catch (Exception)
		{
			return Btn;
		}
	}

	public static buButton hmiToBuButton(hmiUISettings dataNormal, buButton Btn)
	{
		try
		{
			Btn.Display = buControlDisplay.Copy(dataNormal.ButtonNormal, Btn.Display, FontsAlignment: false);
			Btn.ButtonDownDisplay = buControlDisplay.Copy(dataNormal.ButtonDown, Btn.ButtonDownDisplay, FontsAlignment: false);
			Btn.ButtonOverDisplay = buControlDisplay.Copy(dataNormal.ButtonOver, Btn.ButtonOverDisplay, FontsAlignment: false);
			Btn.Geometry.ArcDiameter = dataNormal.Parameters.GeometryArcDiameer;
			Btn.Geometry.ShapeMode = dataNormal.Parameters.GeometryType;
			if ((dataNormal.Parameters.GeometryType == ShapeType.Arc) | (dataNormal.Parameters.GeometryType == ShapeType.Ellipse))
			{
				Btn.BackColor = Color.Transparent;
			}
			return Btn;
		}
		catch (Exception)
		{
			return Btn;
		}
	}

	public static buButton hmiToBuButton(hmiUIBasicSettings dataNormal, buButton Btn)
	{
		try
		{
			Btn.Display = buControlDisplay.Copy(dataNormal.Display, Btn.Display);
			Btn.ButtonDownDisplay = buControlDisplay.Copy(dataNormal.Display, Btn.ButtonDownDisplay);
			Btn.ButtonOverDisplay = buControlDisplay.Copy(dataNormal.Display, Btn.ButtonOverDisplay);
			Btn.Geometry.ArcDiameter = dataNormal.Parameters.GeometryArcDiameer;
			Btn.Geometry.ShapeMode = dataNormal.Parameters.GeometryType;
			Btn.ImageAlign = dataNormal.Parameters.ImageAlignment;
			if ((dataNormal.Parameters.GeometryType == ShapeType.Arc) | (dataNormal.Parameters.GeometryType == ShapeType.Ellipse))
			{
				Btn.BackColor = Color.Transparent;
			}
			return Btn;
		}
		catch (Exception)
		{
			return Btn;
		}
	}

	public static buButton hmiToBuButton(buControlDisplay display, buControlDisplay over, buControlDisplay down, hmiUIPars parameters, buButton Btn)
	{
		try
		{
			Btn.Geometry.ArcDiameter = parameters.GeometryArcDiameer;
			Btn.Geometry.ShapeMode = parameters.GeometryType;
			Btn.Display = buControlDisplay.Copy(display, Btn.Display);
			Btn.ButtonOverDisplay = buControlDisplay.Copy(over, Btn.ButtonOverDisplay);
			Btn.ButtonDownDisplay = buControlDisplay.Copy(down, Btn.ButtonDownDisplay);
			if (parameters.GeometryType != ShapeType.Rectangle)
			{
				Btn.BackColor = Color.Transparent;
			}
			return Btn;
		}
		catch (Exception)
		{
			return Btn;
		}
	}

	public static void buButtonToHmi(ref hmiUISettings data, buButton Btn)
	{
		try
		{
			data.ButtonNormal = buControlDisplay.Copy(Btn.Display, data.ButtonNormal);
			data.ButtonOver = buControlDisplay.Copy(Btn.Display, data.ButtonOver);
			data.ButtonDown = buControlDisplay.Copy(Btn.Display, data.ButtonDown);
			data.Parameters.GeometryArcDiameer = Btn.Geometry.ArcDiameter;
			data.Parameters.GeometryType = Btn.Geometry.ShapeMode;
		}
		catch (Exception)
		{
		}
	}

	public static Control.ControlCollection SetVisualItem(Control.ControlCollection Controls)
	{
		for (int i = 0; i <= Controls.Count - 1; i++)
		{
			if (Controls[i] is buButton)
			{
				buButton buButton2 = Controls[i] as buButton;
				if (buButton2.ControlStyle != ControlStyle.System1)
				{
					if (buButton2.ControlStyle != ControlStyle.System2)
					{
						if (buButton2.ControlStyle != ControlStyle.System3)
						{
							if (buButton2.ControlStyle != ControlStyle.System4)
							{
								if (buButton2.ControlStyle != ControlStyle.Menu1)
								{
									if (buButton2.ControlStyle != ControlStyle.Menu2)
									{
										if (buButton2.ControlStyle != ControlStyle.Menu3)
										{
											if (buButton2.ControlStyle != ControlStyle.Menu4)
											{
												if (buButton2.ControlStyle != ControlStyle.Command1)
												{
													if (buButton2.ControlStyle != ControlStyle.Command2)
													{
														if (buButton2.ControlStyle != ControlStyle.Command3)
														{
															if (buButton2.ControlStyle != ControlStyle.Command4)
															{
																if (buButton2.ControlStyle != ControlStyle.Ok)
																{
																	if (buButton2.ControlStyle != ControlStyle.Cancel)
																	{
																		if (buButton2.ControlStyle == ControlStyle.FormButton && buButton2.Parent != null && buButton2.Parent is buGround)
																		{
																			buGround buGround2 = buButton2.Parent as buGround;
																			buButton2.Display = buControlDisplay.Copy(buGround2.DisplayTop, buButton2.Display);
																			buButton2.ButtonOverDisplay = buControlDisplay.Copy(buGround2.DisplayTop, buButton2.ButtonOverDisplay, 1.1);
																			buButton2.ButtonDownDisplay = buControlDisplay.Copy(buGround2.DisplayTop, buButton2.ButtonDownDisplay, 0.9);
																		}
																	}
																	else if (buEyeVars.parVisual.hmiButtonCancel != null)
																	{
																		buButton2 = hmiToBuButton(buEyeVars.parVisual.hmiButtonCancel, buButton2);
																	}
																}
																else if (buEyeVars.parVisual.hmiButtonOk != null)
																{
																	buButton2 = hmiToBuButton(buEyeVars.parVisual.hmiButtonOk, buButton2);
																}
															}
															else if (buEyeVars.parVisual.hmiButtonCommand4 != null)
															{
																buButton2 = hmiToBuButton(buEyeVars.parVisual.hmiButtonCommand4, buButton2);
															}
														}
														else if (buEyeVars.parVisual.hmiButtonCommand3 != null)
														{
															buButton2 = hmiToBuButton(buEyeVars.parVisual.hmiButtonCommand3, buButton2);
														}
													}
													else if (buEyeVars.parVisual.hmiButtonCommand2 != null)
													{
														buButton2 = hmiToBuButton(buEyeVars.parVisual.hmiButtonCommand2, buButton2);
													}
												}
												else if (buEyeVars.parVisual.hmiButtonCommand1 != null)
												{
													buButton2 = hmiToBuButton(buEyeVars.parVisual.hmiButtonCommand1, buButton2);
												}
											}
											else if (buEyeVars.parVisual.hmiButtonMenu4 != null)
											{
												buButton2 = hmiToBuButton(buEyeVars.parVisual.hmiButtonMenu4, buButton2);
											}
										}
										else if (buEyeVars.parVisual.hmiButtonMenu3 != null)
										{
											buButton2 = hmiToBuButton(buEyeVars.parVisual.hmiButtonMenu3, buButton2);
										}
									}
									else if (buEyeVars.parVisual.hmiButtonMenu2 != null)
									{
										buButton2 = hmiToBuButton(buEyeVars.parVisual.hmiButtonMenu2, buButton2);
									}
								}
								else if (buEyeVars.parVisual.hmiButtonMenu1 != null)
								{
									buButton2 = hmiToBuButton(buEyeVars.parVisual.hmiButtonMenu1, buButton2);
								}
							}
							else if (buEyeVars.parVisual.hmiButtonSystem4 != null)
							{
								buButton2 = hmiToBuButton(buEyeVars.parVisual.hmiButtonSystem4, buButton2);
							}
						}
						else if (buEyeVars.parVisual.hmiButtonSystem3 != null)
						{
							buButton2 = hmiToBuButton(buEyeVars.parVisual.hmiButtonSystem3, buButton2);
						}
					}
					else if (buEyeVars.parVisual.hmiButtonSystem2 != null)
					{
						buButton2 = hmiToBuButton(buEyeVars.parVisual.hmiButtonSystem2, buButton2);
					}
				}
				else if (buEyeVars.parVisual.hmiButtonSystem1 != null)
				{
					buButton2 = hmiToBuButton(buEyeVars.parVisual.hmiButtonSystem1, buButton2);
				}
			}
			if (Controls[i] is buSpin)
			{
				buSpin buSpin2 = Controls[i] as buSpin;
				if (buSpin2.ControlStyle != ControlStyle.Base1)
				{
					if (buSpin2.ControlStyle != ControlStyle.Base2)
					{
						if (buSpin2.ControlStyle != ControlStyle.Base3)
						{
							if (buSpin2.ControlStyle == ControlStyle.Base4 && buEyeVars.parVisual.hmiSpin4 != null)
							{
								buSpin2 = hmiToBuSpin(buEyeVars.parVisual.hmiSpin4, buSpin2);
							}
						}
						else if (buEyeVars.parVisual.hmiSpin3 != null)
						{
							buSpin2 = hmiToBuSpin(buEyeVars.parVisual.hmiSpin3, buSpin2);
						}
					}
					else if (buEyeVars.parVisual.hmiSpin2 != null)
					{
						buSpin2 = hmiToBuSpin(buEyeVars.parVisual.hmiSpin2, buSpin2);
					}
				}
				else if (buEyeVars.parVisual.hmiSpin1 != null)
				{
					buSpin2 = hmiToBuSpin(buEyeVars.parVisual.hmiSpin1, buSpin2);
				}
			}
			if (Controls[i] is buTextBox)
			{
				buTextBox buTextBox2 = Controls[i] as buTextBox;
				if (buTextBox2.ControlStyle != ControlStyle.Base1)
				{
					if (buTextBox2.ControlStyle != ControlStyle.Base2)
					{
						if (buTextBox2.ControlStyle != ControlStyle.Base3)
						{
							if (buTextBox2.ControlStyle == ControlStyle.Base4 && buEyeVars.parVisual.hmiText4 != null)
							{
								buTextBox2 = hmiToBuTextBox(buEyeVars.parVisual.hmiText4, buTextBox2);
							}
						}
						else if (buEyeVars.parVisual.hmiText3 != null)
						{
							buTextBox2 = hmiToBuTextBox(buEyeVars.parVisual.hmiText3, buTextBox2);
						}
					}
					else if (buEyeVars.parVisual.hmiText2 != null)
					{
						buTextBox2 = hmiToBuTextBox(buEyeVars.parVisual.hmiText2, buTextBox2);
					}
				}
				else if (buEyeVars.parVisual.hmiText1 != null)
				{
					buTextBox2 = hmiToBuTextBox(buEyeVars.parVisual.hmiText1, buTextBox2);
				}
			}
			if (Controls[i] is buMultiTextBox)
			{
				buMultiTextBox buMultiTextBox2 = Controls[i] as buMultiTextBox;
				if (buMultiTextBox2.Tag == null || !(buMultiTextBox2.Tag.ToString().ToLower() == "text1"))
				{
					if (buMultiTextBox2.Tag == null || !(buMultiTextBox2.Tag.ToString().ToLower() == "text1"))
					{
						if (buMultiTextBox2.Tag == null || !(buMultiTextBox2.Tag.ToString().ToLower() == "text1"))
						{
							if (buMultiTextBox2.Tag != null && buMultiTextBox2.Tag.ToString().ToLower() == "text1" && buEyeVars.parVisual.hmiText4 != null)
							{
								buMultiTextBox2 = hmiToBuMultiTextBox(buEyeVars.parVisual.hmiText4, buMultiTextBox2);
							}
						}
						else if (buEyeVars.parVisual.hmiText3 != null)
						{
							buMultiTextBox2 = hmiToBuMultiTextBox(buEyeVars.parVisual.hmiText3, buMultiTextBox2);
						}
					}
					else if (buEyeVars.parVisual.hmiText2 != null)
					{
						buMultiTextBox2 = hmiToBuMultiTextBox(buEyeVars.parVisual.hmiText2, buMultiTextBox2);
					}
				}
				else if (buEyeVars.parVisual.hmiText1 != null)
				{
					buMultiTextBox2 = hmiToBuMultiTextBox(buEyeVars.parVisual.hmiText1, buMultiTextBox2);
				}
			}
			if (Controls[i] is buCheckBox)
			{
				buCheckBox buCheckBox2 = Controls[i] as buCheckBox;
				if (buCheckBox2.ControlStyle != ControlStyle.Base1)
				{
					if (buCheckBox2.ControlStyle != ControlStyle.Base2)
					{
						if (buCheckBox2.ControlStyle != ControlStyle.Base3)
						{
							if (buCheckBox2.ControlStyle == ControlStyle.Base4 && buEyeVars.parVisual.hmiCheck4 != null)
							{
								buCheckBox2 = hmiToBuCheckbox(buEyeVars.parVisual.hmiCheck4, buCheckBox2);
							}
						}
						else if (buEyeVars.parVisual.hmiCheck3 != null)
						{
							buCheckBox2 = hmiToBuCheckbox(buEyeVars.parVisual.hmiCheck3, buCheckBox2);
						}
					}
					else if (buEyeVars.parVisual.hmiCheck2 != null)
					{
						buCheckBox2 = hmiToBuCheckbox(buEyeVars.parVisual.hmiCheck2, buCheckBox2);
					}
				}
				else if (buEyeVars.parVisual.hmiCheck1 != null)
				{
					buCheckBox2 = hmiToBuCheckbox(buEyeVars.parVisual.hmiCheck1, buCheckBox2);
				}
			}
			if (Controls[i] is buLabel)
			{
				buLabel buLabel2 = Controls[i] as buLabel;
				if (buLabel2.ControlStyle != ControlStyle.Base1)
				{
					if (buLabel2.ControlStyle != ControlStyle.Base2)
					{
						if (buLabel2.ControlStyle != ControlStyle.Base3)
						{
							if (buLabel2.ControlStyle == ControlStyle.Base4 && buEyeVars.parVisual.hmiLabel4 != null)
							{
								buLabel2 = hmiToBuLabel(buEyeVars.parVisual.hmiLabel4, buLabel2);
							}
						}
						else if (buEyeVars.parVisual.hmiLabel3 != null)
						{
							buLabel2 = hmiToBuLabel(buEyeVars.parVisual.hmiLabel3, buLabel2);
						}
					}
					else if (buEyeVars.parVisual.hmiLabel2 != null)
					{
						buLabel2 = hmiToBuLabel(buEyeVars.parVisual.hmiLabel2, buLabel2);
					}
				}
				else if (buEyeVars.parVisual.hmiLabel1 != null)
				{
					buLabel2 = hmiToBuLabel(buEyeVars.parVisual.hmiLabel1, buLabel2);
				}
			}
			if (Controls[i] is buListBox)
			{
				buListBox buListBox2 = Controls[i] as buListBox;
				if (buListBox2.ControlStyle != ControlStyle.Base1)
				{
					if (buListBox2.ControlStyle != ControlStyle.Base2)
					{
						if (buListBox2.ControlStyle != ControlStyle.Base3)
						{
							if (buListBox2.ControlStyle == ControlStyle.Base4 && buEyeVars.parVisual.hmiListbox1 != null)
							{
								buListBox2 = hmiToBuListBox(buEyeVars.parVisual.hmiListbox4, buListBox2);
							}
						}
						else if (buEyeVars.parVisual.hmiListbox1 != null)
						{
							buListBox2 = hmiToBuListBox(buEyeVars.parVisual.hmiListbox3, buListBox2);
						}
					}
					else if (buEyeVars.parVisual.hmiListbox1 != null)
					{
						buListBox2 = hmiToBuListBox(buEyeVars.parVisual.hmiListbox2, buListBox2);
					}
				}
				else if (buEyeVars.parVisual.hmiListbox1 != null)
				{
					buListBox2 = hmiToBuListBox(buEyeVars.parVisual.hmiListbox1, buListBox2);
				}
			}
			if (Controls[i] is buComboBox)
			{
				buComboBox buComboBox2 = Controls[i] as buComboBox;
				if (buComboBox2.ControlStyle != ControlStyle.Base1)
				{
					if (buComboBox2.ControlStyle != ControlStyle.Base2)
					{
						if (buComboBox2.ControlStyle != ControlStyle.Base3)
						{
							if (buComboBox2.ControlStyle == ControlStyle.Base4 && buEyeVars.parVisual.hmiCombo1 != null)
							{
								buComboBox2 = hmiToBuCombobox(buEyeVars.parVisual.hmiCombo4, buComboBox2);
							}
						}
						else if (buEyeVars.parVisual.hmiCombo1 != null)
						{
							buComboBox2 = hmiToBuCombobox(buEyeVars.parVisual.hmiCombo3, buComboBox2);
						}
					}
					else if (buEyeVars.parVisual.hmiCombo1 != null)
					{
						buComboBox2 = hmiToBuCombobox(buEyeVars.parVisual.hmiCombo2, buComboBox2);
					}
				}
				else if (buEyeVars.parVisual.hmiCombo1 != null)
				{
					buComboBox2 = hmiToBuCombobox(buEyeVars.parVisual.hmiCombo1, buComboBox2);
				}
			}
			if (Controls[i] is DataGridView)
			{
				DataGridView dataGridView = Controls[i] as DataGridView;
				if (dataGridView.Tag == null || !(dataGridView.Tag.ToString().ToLower() == "base1"))
				{
					if (dataGridView.Tag != null && dataGridView.Tag.ToString().ToLower() == "base2" && buEyeVars.parVisual.hmiDGV2 != null)
					{
						dataGridView = hmiToDataGridView(buEyeVars.parVisual.hmiDGV2, dataGridView);
					}
				}
				else if (buEyeVars.parVisual.hmiDGV1 != null)
				{
					dataGridView = hmiToDataGridView(buEyeVars.parVisual.hmiDGV1, dataGridView);
				}
			}
			if (Controls[i] is RadioButton)
			{
				RadioButton radioButton = Controls[i] as RadioButton;
				if (radioButton.Tag == null || !(radioButton.Tag.ToString().ToLower() == "base1"))
				{
					if (radioButton.Tag == null || !(radioButton.Tag.ToString().ToLower() == "base2"))
					{
						if (radioButton.Tag == null || !(radioButton.Tag.ToString().ToLower() == "base3"))
						{
							if (radioButton.Tag != null && radioButton.Tag.ToString().ToLower() == "base4" && buEyeVars.parVisual.hmiRadioButton4 != null)
							{
								radioButton = hmiToRadioButton(buEyeVars.parVisual.hmiRadioButton4, radioButton);
							}
						}
						else if (buEyeVars.parVisual.hmiRadioButton3 != null)
						{
							radioButton = hmiToRadioButton(buEyeVars.parVisual.hmiRadioButton3, radioButton);
						}
					}
					else if (buEyeVars.parVisual.hmiRadioButton2 != null)
					{
						radioButton = hmiToRadioButton(buEyeVars.parVisual.hmiRadioButton2, radioButton);
					}
				}
				else if (buEyeVars.parVisual.hmiRadioButton1 != null)
				{
					radioButton = hmiToRadioButton(buEyeVars.parVisual.hmiRadioButton1, radioButton);
				}
			}
			if (Controls[i] is buTrack)
			{
				buTrack buTrack2 = Controls[i] as buTrack;
				if (buTrack2.ControlStyle != ControlStyle.Base1)
				{
					if (buTrack2.ControlStyle == ControlStyle.Base2 && buEyeVars.parVisual.hmiTrack2 != null)
					{
						buTrack2 = hmiToBuTrack(buEyeVars.parVisual.hmiTrack2, buTrack2);
					}
				}
				else if (buEyeVars.parVisual.hmiTrack1 != null)
				{
					buTrack2 = hmiToBuTrack(buEyeVars.parVisual.hmiTrack1, buTrack2);
				}
			}
			if (Controls[i] is buProgressBar)
			{
				buProgressBar buProgressBar2 = Controls[i] as buProgressBar;
				if (buProgressBar2.ControlStyle != ControlStyle.Base1)
				{
					if (buProgressBar2.ControlStyle == ControlStyle.Base1 && buEyeVars.parVisual.hmiProgress2 != null)
					{
						buProgressBar2 = hmiToBuProgress(buEyeVars.parVisual.hmiProgress2, buProgressBar2);
					}
				}
				else if (buEyeVars.parVisual.hmiProgress1 != null)
				{
					buProgressBar2 = hmiToBuProgress(buEyeVars.parVisual.hmiProgress1, buProgressBar2);
				}
			}
			if (Controls[i] is buPanel)
			{
				buPanel buPanel2 = Controls[i] as buPanel;
				if (buPanel2.ControlStyle != ControlStyle.Base1)
				{
					if (buPanel2.ControlStyle == ControlStyle.Base2 && buEyeVars.parVisual.hmiPanel2 != null)
					{
						buPanel2 = hmiToBuPanel(buEyeVars.parVisual.hmiPanel2, buPanel2);
					}
				}
				else if (buEyeVars.parVisual.hmiPanel1 != null)
				{
					buPanel2 = hmiToBuPanel(buEyeVars.parVisual.hmiPanel1, buPanel2);
				}
			}
			if (Controls[i] is buGroup)
			{
				buGroup buGroup2 = Controls[i] as buGroup;
				if (buGroup2.ControlStyle != ControlStyle.Base1)
				{
					if (buGroup2.ControlStyle == ControlStyle.Base2 && buEyeVars.parVisual.hmiGroup1 != null)
					{
						buGroup2 = hmiToBuGroup(buEyeVars.parVisual.hmiGroup2, buGroup2);
					}
				}
				else if (buEyeVars.parVisual.hmiGroup1 != null)
				{
					buGroup2 = hmiToBuGroup(buEyeVars.parVisual.hmiGroup1, buGroup2);
				}
			}
			if (Controls[i] is buGround)
			{
				buGround buGround3 = Controls[i] as buGround;
				if (buGround3.ControlStyle != ControlStyle.Base1)
				{
					if (buGround3.ControlStyle == ControlStyle.Base2 && buEyeVars.parVisual.hmiGround2 != null)
					{
						buGround3 = hmiToBuGround(buEyeVars.parVisual.hmiGround2, buGround3);
					}
				}
				else if (buEyeVars.parVisual.hmiGround1 != null)
				{
					buGround3 = hmiToBuGround(buEyeVars.parVisual.hmiGround1, buGround3);
				}
			}
			if (Controls[i] is buButton)
			{
				buButton buButton3 = Controls[i] as buButton;
				if (buButton3.ControlStyle != ControlStyle.On1)
				{
					if (buButton3.ControlStyle != ControlStyle.On2)
					{
						if (buButton3.ControlStyle != ControlStyle.Off1)
						{
							if (buButton3.ControlStyle == ControlStyle.Off2 && buEyeVars.parVisual.hmiOff2 != null)
							{
								buButton3 = hmiToBuButton(buEyeVars.parVisual.hmiOff2, buButton3);
							}
						}
						else if (buEyeVars.parVisual.hmiOff1 != null)
						{
							buButton3 = hmiToBuButton(buEyeVars.parVisual.hmiOff1, buButton3);
						}
					}
					else if (buEyeVars.parVisual.hmiOn2 != null)
					{
						buButton3 = hmiToBuButton(buEyeVars.parVisual.hmiOn2, buButton3);
					}
				}
				else if (buEyeVars.parVisual.hmiOn1 != null)
				{
					buButton3 = hmiToBuButton(buEyeVars.parVisual.hmiOn1, buButton3);
				}
			}
			if (Controls[i] is buLabel)
			{
				buLabel buLabel3 = Controls[i] as buLabel;
				if (buLabel3.ControlStyle != ControlStyle.Warning)
				{
					if (buLabel3.ControlStyle != ControlStyle.Error)
					{
						if (buLabel3.ControlStyle != ControlStyle.Info)
						{
							if (buLabel3.ControlStyle == ControlStyle.Status && buEyeVars.parVisual.hmiStatus != null)
							{
								buLabel3 = hmiToBuLabel(buEyeVars.parVisual.hmiStatus, buLabel3);
							}
						}
						else if (buEyeVars.parVisual.hmiInfo != null)
						{
							buLabel3 = hmiToBuLabel(buEyeVars.parVisual.hmiInfo, buLabel3);
						}
					}
					else if (buEyeVars.parVisual.hmiError != null)
					{
						buLabel3 = hmiToBuLabel(buEyeVars.parVisual.hmiError, buLabel3);
					}
				}
				else if (buEyeVars.parVisual.hmiWarning != null)
				{
					buLabel3 = hmiToBuLabel(buEyeVars.parVisual.hmiWarning, buLabel3);
				}
			}
			if (Controls[i] is buLabel)
			{
				buLabel buLabel4 = Controls[i] as buLabel;
				if (buLabel4.ControlStyle != ControlStyle.Coordinate1)
				{
					if (buLabel4.ControlStyle != ControlStyle.Coordinate2)
					{
						if (buLabel4.ControlStyle != ControlStyle.CoordinateCaption1)
						{
							if (buLabel4.ControlStyle != ControlStyle.CoordinateCaption2)
							{
								if (buLabel4.ControlStyle != ControlStyle.CoordinateTitle1)
								{
									if (buLabel4.ControlStyle == ControlStyle.CoordinateTitle2 && buEyeVars.parVisual.hmiCoords2 != null)
									{
										buLabel4.Display.Fonts.ForeColor = buEyeVars.parVisual.hmiCoords2.Display.TitleForeColor;
									}
								}
								else if (buEyeVars.parVisual.hmiCoords1 != null)
								{
									buLabel4.Display.Fonts.ForeColor = buEyeVars.parVisual.hmiCoords1.Display.TitleForeColor;
								}
							}
							else if (buEyeVars.parVisual.hmiCoords2 != null)
							{
								buLabel4 = hmiToBuLabel(buEyeVars.parVisual.hmiCoords2.Caption, buEyeVars.parVisual.hmiCoords2.Parameters, buLabel4);
							}
						}
						else if (buEyeVars.parVisual.hmiCoords1 != null)
						{
							buLabel4 = hmiToBuLabel(buEyeVars.parVisual.hmiCoords1.Caption, buEyeVars.parVisual.hmiCoords1.Parameters, buLabel4);
						}
					}
					else if (buEyeVars.parVisual.hmiCoords2 != null)
					{
						buLabel4 = hmiToBuLabel(buEyeVars.parVisual.hmiCoords2.Display, buEyeVars.parVisual.hmiCoords2.Parameters, buLabel4);
					}
				}
				else if (buEyeVars.parVisual.hmiCoords1 != null)
				{
					buLabel4 = hmiToBuLabel(buEyeVars.parVisual.hmiCoords1.Display, buEyeVars.parVisual.hmiCoords1.Parameters, buLabel4);
				}
			}
			if (Controls[i] is buLabel)
			{
				buLabel buLabel5 = Controls[i] as buLabel;
				if (buLabel5.ControlStyle == ControlStyle.Speed1 && buEyeVars.parVisual.hmiSpeed1 != null)
				{
					buLabel5 = hmiToBuLabel(buEyeVars.parVisual.hmiSpeed1.Caption, buEyeVars.parVisual.hmiSpeed1.Parameters, buLabel5);
				}
			}
			if (Controls[i] is buTrack)
			{
				buTrack buTrack3 = Controls[i] as buTrack;
				if (buTrack3.ControlStyle == ControlStyle.Speed1 && buEyeVars.parVisual.hmiSpeed1 != null)
				{
					buTrack3 = hmiToBuTrack(buEyeVars.parVisual.hmiSpeed1, buTrack3);
				}
			}
			if (Controls[i] is buSpin)
			{
				buSpin buSpin3 = Controls[i] as buSpin;
				if (buSpin3.ControlStyle == ControlStyle.Speed1 && buEyeVars.parVisual.hmiSpeed1 != null)
				{
					buSpin3.Display.BackColor = buEyeVars.parVisual.hmiSpeed1.Parameters.ValueColor;
					buSpin3.Display.GradientType = GradientMode.Solid;
				}
			}
			if (Controls[i] is buButton)
			{
				buButton buButton4 = Controls[i] as buButton;
				if (buButton4.ControlStyle == ControlStyle.Speed1 && buEyeVars.parVisual.hmiSpeed1 != null)
				{
					buButton4 = hmiToBuButton(buEyeVars.parVisual.hmiSpeed1.ButtonNormal, buEyeVars.parVisual.hmiSpeed1.ButtonOver, buEyeVars.parVisual.hmiSpeed1.ButtonDown, buEyeVars.parVisual.hmiSpeed1.Parameters, buButton4);
				}
			}
		}
		return Controls;
	}

	public static buButton ColorButtonLinearFromOnOff(buButton refButton, bool State, hmiUISettings OnState, hmiUISettings OffState)
	{
		if (!State)
		{
			refButton.Display = buControlDisplay.Copy(OffState.ButtonNormal, refButton.Display, 1.0, FontsAlignment: false);
			refButton.ButtonDownDisplay = buControlDisplay.Copy(OffState.ButtonDown, refButton.ButtonDownDisplay, 1.0, FontsAlignment: false);
			refButton.ButtonOverDisplay = buControlDisplay.Copy(OffState.ButtonOver, refButton.ButtonOverDisplay, 1.0, FontsAlignment: false);
		}
		else
		{
			refButton.Display = buControlDisplay.Copy(OnState.ButtonNormal, refButton.Display, 1.0, FontsAlignment: false);
			refButton.ButtonDownDisplay = buControlDisplay.Copy(OnState.ButtonDown, refButton.ButtonDownDisplay, 1.0, FontsAlignment: false);
			refButton.ButtonOverDisplay = buControlDisplay.Copy(OnState.ButtonOver, refButton.ButtonOverDisplay, 1.0, FontsAlignment: false);
		}
		return refButton;
	}

	public static buButton ColorButtonLinearFromOnOff(buButton refButton, bool State, hmiUIBasicSettings OnState, hmiUIBasicSettings OffState)
	{
		if (!State)
		{
			refButton.Display = buControlDisplay.Copy(OffState.Display, refButton.Display, 1.0, FontsAlignment: false);
			refButton.ButtonDownDisplay = buControlDisplay.Copy(OffState.Display, refButton.ButtonDownDisplay, 0.9, FontsAlignment: false);
			refButton.ButtonOverDisplay = buControlDisplay.Copy(OffState.Display, refButton.ButtonOverDisplay, 0.8, FontsAlignment: false);
		}
		else
		{
			refButton.Display = buControlDisplay.Copy(OnState.Display, refButton.Display, 1.0, FontsAlignment: false);
			refButton.ButtonDownDisplay = buControlDisplay.Copy(OnState.Display, refButton.ButtonDownDisplay, 0.9, FontsAlignment: false);
			refButton.ButtonOverDisplay = buControlDisplay.Copy(OnState.Display, refButton.ButtonOverDisplay, 0.8, FontsAlignment: false);
		}
		return refButton;
	}

	public static buLabel ColorLabelLinearFromOnOff(buLabel refLabel, bool State, hmiUIBasicSettings OnState, hmiUIBasicSettings OffState)
	{
		if (!State)
		{
			refLabel.Display = buControlDisplay.Copy(OffState.Display, refLabel.Display, 1.0, FontsAlignment: false);
		}
		else
		{
			refLabel.Display = buControlDisplay.Copy(OnState.Display, refLabel.Display, 1.0, FontsAlignment: false);
		}
		return refLabel;
	}

	public static void OpenApplicationVisualFile(string FileName)
	{
		FileInfo fileInfo = new FileInfo(FileName);
		if (fileInfo.Exists)
		{
			ArrayList StringList = new ArrayList();
			buFile5.OpenFromFile(fileInfo.FullName, ref StringList);
			List<string> CalcList = new List<string>();
			List<string> list = new List<string>();
			List<string> CalcList2 = new List<string>();
			buString.ListToSpecificList("<ApplicationCommonColors>", "</ApplicationCommonColors>", AddStartEndKey: false, StringList, ref CalcList);
			buString.ListToSpecificList("<ButtonControl>", "</ButtonControl>", AddStartEndKey: false, CalcList, ref CalcList2);
			if (CalcList2.Count > 0)
			{
				hmiUISettings.DecodeHMI(CalcList2, "ButtonMenu1", buEyeVars.parVisual.hmiButtonMenu1);
				hmiUISettings.DecodeHMI(CalcList2, "ButtonMenu2", buEyeVars.parVisual.hmiButtonMenu2);
				hmiUISettings.DecodeHMI(CalcList2, "ButtonMenu3", buEyeVars.parVisual.hmiButtonMenu3);
				hmiUISettings.DecodeHMI(CalcList2, "ButtonMenu4", buEyeVars.parVisual.hmiButtonMenu4);
				hmiUISettings.DecodeHMI(CalcList2, "ButtonSystem1", buEyeVars.parVisual.hmiButtonSystem1);
				hmiUISettings.DecodeHMI(CalcList2, "ButtonSystem2", buEyeVars.parVisual.hmiButtonSystem2);
				hmiUISettings.DecodeHMI(CalcList2, "ButtonSystem3", buEyeVars.parVisual.hmiButtonSystem3);
				hmiUISettings.DecodeHMI(CalcList2, "ButtonSystem4", buEyeVars.parVisual.hmiButtonSystem4);
				hmiUISettings.DecodeHMI(CalcList2, "ButtonCommand1", buEyeVars.parVisual.hmiButtonCommand1);
				hmiUISettings.DecodeHMI(CalcList2, "ButtonCommand2", buEyeVars.parVisual.hmiButtonCommand2);
				hmiUISettings.DecodeHMI(CalcList2, "ButtonCommand3", buEyeVars.parVisual.hmiButtonCommand3);
				hmiUISettings.DecodeHMI(CalcList2, "ButtonCommand4", buEyeVars.parVisual.hmiButtonCommand4);
				hmiUISettings.DecodeHMI(CalcList2, "ButtonOk", buEyeVars.parVisual.hmiButtonOk);
				hmiUISettings.DecodeHMI(CalcList2, "ButtonCancel", buEyeVars.parVisual.hmiButtonCancel);
			}
			CalcList2.Clear();
			buString.ListToSpecificList("<SpinControl>", "</SpinControl>", AddStartEndKey: false, CalcList, ref CalcList2);
			if (CalcList2.Count > 0)
			{
				hmiUISettings.DecodeHMI(CalcList2, "SpinData1", buEyeVars.parVisual.hmiSpin1);
				hmiUISettings.DecodeHMI(CalcList2, "SpinData2", buEyeVars.parVisual.hmiSpin2);
				hmiUISettings.DecodeHMI(CalcList2, "SpinData3", buEyeVars.parVisual.hmiSpin3);
				hmiUISettings.DecodeHMI(CalcList2, "SpinData4", buEyeVars.parVisual.hmiSpin4);
			}
			CalcList2.Clear();
			buString.ListToSpecificList("<TextControl>", "</TextControl>", AddStartEndKey: false, CalcList, ref CalcList2);
			if (CalcList2.Count > 0)
			{
				hmiUISettings.DecodeHMI(CalcList2, "TextData1", buEyeVars.parVisual.hmiText1);
				hmiUISettings.DecodeHMI(CalcList2, "TextData2", buEyeVars.parVisual.hmiText2);
				hmiUISettings.DecodeHMI(CalcList2, "TextData3", buEyeVars.parVisual.hmiText3);
				hmiUISettings.DecodeHMI(CalcList2, "TextData4", buEyeVars.parVisual.hmiText4);
			}
			CalcList2.Clear();
			buString.ListToSpecificList("<CheckControl>", "</CheckControl>", AddStartEndKey: false, CalcList, ref CalcList2);
			if (CalcList2.Count > 0)
			{
				hmiUISettings.DecodeHMI(CalcList2, "Checkbox1", buEyeVars.parVisual.hmiCheck1);
				hmiUISettings.DecodeHMI(CalcList2, "Checkbox2", buEyeVars.parVisual.hmiCheck2);
				hmiUISettings.DecodeHMI(CalcList2, "Checkbox3", buEyeVars.parVisual.hmiCheck3);
				hmiUISettings.DecodeHMI(CalcList2, "Checkbox4", buEyeVars.parVisual.hmiCheck4);
			}
			CalcList2.Clear();
			buString.ListToSpecificList("<LabelControl>", "</LabelControl>", AddStartEndKey: false, CalcList, ref CalcList2);
			if (CalcList2.Count > 0)
			{
				hmiUISettings.DecodeHMI(CalcList2, "Labelbox1", buEyeVars.parVisual.hmiLabel1);
				hmiUISettings.DecodeHMI(CalcList2, "Labelbox2", buEyeVars.parVisual.hmiLabel2);
				hmiUISettings.DecodeHMI(CalcList2, "Labelbox3", buEyeVars.parVisual.hmiLabel3);
				hmiUISettings.DecodeHMI(CalcList2, "Labelbox4", buEyeVars.parVisual.hmiLabel4);
			}
			CalcList2.Clear();
			buString.ListToSpecificList("<ListboxControl>", "</ListboxControl>", AddStartEndKey: false, CalcList, ref CalcList2);
			if (CalcList2.Count > 0)
			{
				hmiUISettings.DecodeHMI(CalcList2, "Listbox1", buEyeVars.parVisual.hmiListbox1);
				hmiUISettings.DecodeHMI(CalcList2, "Listbox2", buEyeVars.parVisual.hmiListbox2);
				hmiUISettings.DecodeHMI(CalcList2, "Listbox3", buEyeVars.parVisual.hmiListbox3);
				hmiUISettings.DecodeHMI(CalcList2, "Listbox4", buEyeVars.parVisual.hmiListbox4);
			}
			CalcList2.Clear();
			buString.ListToSpecificList("<DataGridViewControl>", "</DataGridViewControl>", AddStartEndKey: false, CalcList, ref CalcList2);
			if (CalcList2.Count > 0)
			{
				buSerilization.Decode(CalcList2, "DGV1", SerilizationMode.MultiLine, buEyeVars.parVisual.hmiDGV1);
				buSerilization.Decode(CalcList2, "DGV2", SerilizationMode.MultiLine, buEyeVars.parVisual.hmiDGV2);
			}
			CalcList2.Clear();
			buString.ListToSpecificList("<RadioButtonControl>", "</RadioButtonControl>", AddStartEndKey: false, CalcList, ref CalcList2);
			if (CalcList2.Count > 0)
			{
				hmiUISettings.DecodeHMI(CalcList2, "RadioButton1", buEyeVars.parVisual.hmiRadioButton1);
				hmiUISettings.DecodeHMI(CalcList2, "RadioButton2", buEyeVars.parVisual.hmiRadioButton2);
				hmiUISettings.DecodeHMI(CalcList2, "RadioButton3", buEyeVars.parVisual.hmiRadioButton3);
				hmiUISettings.DecodeHMI(CalcList2, "RadioButton4", buEyeVars.parVisual.hmiRadioButton4);
			}
			CalcList2.Clear();
			buString.ListToSpecificList("<TrackControl>", "</TrackControl>", AddStartEndKey: false, CalcList, ref CalcList2);
			if (CalcList2.Count > 0)
			{
				hmiUISettings.DecodeHMI(CalcList2, "Track1", buEyeVars.parVisual.hmiTrack1);
				hmiUISettings.DecodeHMI(CalcList2, "Track2", buEyeVars.parVisual.hmiTrack2);
			}
			CalcList2.Clear();
			buString.ListToSpecificList("<ProgressControl>", "</ProgressControl>", AddStartEndKey: false, CalcList, ref CalcList2);
			if (CalcList2.Count > 0)
			{
				hmiUISettings.DecodeHMI(CalcList2, "Progress1", buEyeVars.parVisual.hmiProgress1);
				hmiUISettings.DecodeHMI(CalcList2, "Progress2", buEyeVars.parVisual.hmiProgress2);
			}
			CalcList2.Clear();
			buString.ListToSpecificList("<ComboControl>", "</ComboControl>", AddStartEndKey: false, CalcList, ref CalcList2);
			if (CalcList2.Count > 0)
			{
				hmiUISettings.DecodeHMI(CalcList2, "Combo1", buEyeVars.parVisual.hmiCombo1);
				hmiUISettings.DecodeHMI(CalcList2, "Combo2", buEyeVars.parVisual.hmiCombo2);
				hmiUISettings.DecodeHMI(CalcList2, "Combo3", buEyeVars.parVisual.hmiCombo3);
				hmiUISettings.DecodeHMI(CalcList2, "Combo4", buEyeVars.parVisual.hmiCombo4);
			}
			CalcList2.Clear();
			buString.ListToSpecificList("<GroupControl>", "</GroupControl>", AddStartEndKey: false, CalcList, ref CalcList2);
			if (CalcList2.Count > 0)
			{
				hmiUISettings.DecodeHMI(CalcList2, "Group1", buEyeVars.parVisual.hmiGroup1);
				hmiUISettings.DecodeHMI(CalcList2, "Group2", buEyeVars.parVisual.hmiGroup2);
			}
			CalcList2.Clear();
			buString.ListToSpecificList("<GroundControl>", "</GroundControl>", AddStartEndKey: false, CalcList, ref CalcList2);
			if (CalcList2.Count > 0)
			{
				hmiUISettings.DecodeHMI(CalcList2, "Ground1", buEyeVars.parVisual.hmiGround1);
				hmiUISettings.DecodeHMI(CalcList2, "Ground2", buEyeVars.parVisual.hmiGround2);
			}
			CalcList2.Clear();
			buString.ListToSpecificList("<PanelControl>", "</PanelControl>", AddStartEndKey: false, CalcList, ref CalcList2);
			if (CalcList2.Count > 0)
			{
				hmiUISettings.DecodeHMI(CalcList2, "Panel1", buEyeVars.parVisual.hmiPanel1);
				hmiUISettings.DecodeHMI(CalcList2, "Panel2", buEyeVars.parVisual.hmiPanel2);
			}
			CalcList2.Clear();
			buString.ListToSpecificList("<SpeedControl>", "</SpeedControl>", AddStartEndKey: false, CalcList, ref CalcList2);
			if (CalcList2.Count > 0)
			{
				hmiUISettings.DecodeHMI(CalcList2, "Speed1", buEyeVars.parVisual.hmiSpeed1);
			}
			CalcList2.Clear();
			buString.ListToSpecificList("<SingleControl>", "</SingleControl>", AddStartEndKey: false, CalcList, ref CalcList2);
			if (CalcList2.Count > 0)
			{
				hmiUIBasicSettings.DecodeHMI(CalcList2, "On1", buEyeVars.parVisual.hmiOn1);
				hmiUIBasicSettings.DecodeHMI(CalcList2, "Off1", buEyeVars.parVisual.hmiOff1);
				hmiUIBasicSettings.DecodeHMI(CalcList2, "On2", buEyeVars.parVisual.hmiOn2);
				hmiUIBasicSettings.DecodeHMI(CalcList2, "Off2", buEyeVars.parVisual.hmiOff2);
				hmiUIBasicSettings.DecodeHMI(CalcList2, "Warning", buEyeVars.parVisual.hmiWarning);
				hmiUIBasicSettings.DecodeHMI(CalcList2, "Error", buEyeVars.parVisual.hmiError);
				hmiUIBasicSettings.DecodeHMI(CalcList2, "Info", buEyeVars.parVisual.hmiInfo);
				hmiUIBasicSettings.DecodeHMI(CalcList2, "Status", buEyeVars.parVisual.hmiStatus);
			}
			CalcList2.Clear();
			buString.ListToSpecificList("<Coordinate>", "</Coordinate>", AddStartEndKey: false, CalcList, ref CalcList2);
			if (CalcList2.Count > 0)
			{
				hmiUISettings.DecodeHMI(CalcList2, "Coords1", buEyeVars.parVisual.hmiCoords1);
				hmiUISettings.DecodeHMI(CalcList2, "Coords2", buEyeVars.parVisual.hmiCoords2);
			}
			StringList.Clear();
			CalcList.Clear();
			list.Clear();
			CalcList2.Clear();
		}
	}

	public static void SaveApplicationVisualFile(string FileName)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add("<ApplicationCommonColors>");
		arrayList.Add(new string(' ', 2) + "<ButtonControl>");
		buEyeVars.parVisual.hmiButtonCommand1.Caption = null;
		buEyeVars.parVisual.hmiButtonCommand1.Display = null;
		buEyeVars.parVisual.hmiButtonCommand1.Done = null;
		buEyeVars.parVisual.hmiButtonCommand1.Shape = null;
		buEyeVars.parVisual.hmiButtonCommand2.Caption = null;
		buEyeVars.parVisual.hmiButtonCommand2.Display = null;
		buEyeVars.parVisual.hmiButtonCommand2.Done = null;
		buEyeVars.parVisual.hmiButtonCommand2.Shape = null;
		buEyeVars.parVisual.hmiButtonCommand3.Caption = null;
		buEyeVars.parVisual.hmiButtonCommand3.Display = null;
		buEyeVars.parVisual.hmiButtonCommand3.Done = null;
		buEyeVars.parVisual.hmiButtonCommand3.Shape = null;
		buEyeVars.parVisual.hmiButtonCommand4.Caption = null;
		buEyeVars.parVisual.hmiButtonCommand4.Display = null;
		buEyeVars.parVisual.hmiButtonCommand4.Done = null;
		buEyeVars.parVisual.hmiButtonCommand4.Shape = null;
		buEyeVars.parVisual.hmiButtonMenu1.Caption = null;
		buEyeVars.parVisual.hmiButtonMenu1.Display = null;
		buEyeVars.parVisual.hmiButtonMenu1.Done = null;
		buEyeVars.parVisual.hmiButtonMenu1.Shape = null;
		buEyeVars.parVisual.hmiButtonMenu2.Caption = null;
		buEyeVars.parVisual.hmiButtonMenu2.Display = null;
		buEyeVars.parVisual.hmiButtonMenu2.Done = null;
		buEyeVars.parVisual.hmiButtonMenu2.Shape = null;
		buEyeVars.parVisual.hmiButtonMenu3.Caption = null;
		buEyeVars.parVisual.hmiButtonMenu3.Display = null;
		buEyeVars.parVisual.hmiButtonMenu3.Done = null;
		buEyeVars.parVisual.hmiButtonMenu3.Shape = null;
		buEyeVars.parVisual.hmiButtonMenu4.Caption = null;
		buEyeVars.parVisual.hmiButtonMenu4.Display = null;
		buEyeVars.parVisual.hmiButtonMenu4.Done = null;
		buEyeVars.parVisual.hmiButtonMenu4.Shape = null;
		buEyeVars.parVisual.hmiButtonSystem1.Caption = null;
		buEyeVars.parVisual.hmiButtonSystem1.Display = null;
		buEyeVars.parVisual.hmiButtonSystem1.Done = null;
		buEyeVars.parVisual.hmiButtonSystem1.Shape = null;
		buEyeVars.parVisual.hmiButtonSystem2.Caption = null;
		buEyeVars.parVisual.hmiButtonSystem2.Display = null;
		buEyeVars.parVisual.hmiButtonSystem2.Done = null;
		buEyeVars.parVisual.hmiButtonSystem2.Shape = null;
		buEyeVars.parVisual.hmiButtonSystem3.Caption = null;
		buEyeVars.parVisual.hmiButtonSystem3.Display = null;
		buEyeVars.parVisual.hmiButtonSystem3.Done = null;
		buEyeVars.parVisual.hmiButtonSystem3.Shape = null;
		buEyeVars.parVisual.hmiButtonSystem4.Caption = null;
		buEyeVars.parVisual.hmiButtonSystem4.Display = null;
		buEyeVars.parVisual.hmiButtonSystem4.Done = null;
		buEyeVars.parVisual.hmiButtonSystem4.Shape = null;
		buEyeVars.parVisual.hmiButtonOk.Caption = null;
		buEyeVars.parVisual.hmiButtonOk.Display = null;
		buEyeVars.parVisual.hmiButtonOk.Done = null;
		buEyeVars.parVisual.hmiButtonOk.Shape = null;
		buEyeVars.parVisual.hmiButtonCancel.Display = null;
		buEyeVars.parVisual.hmiButtonCancel.Display = null;
		buEyeVars.parVisual.hmiButtonCancel.Done = null;
		buEyeVars.parVisual.hmiButtonCancel.Shape = null;
		arrayList.AddRange(buEyeVars.parVisual.hmiButtonMenu1.ToDefHMI("ButtonMenu1", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiButtonMenu2.ToDefHMI("ButtonMenu2", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiButtonMenu3.ToDefHMI("ButtonMenu3", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiButtonMenu4.ToDefHMI("ButtonMenu4", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiButtonSystem1.ToDefHMI("ButtonSystem1", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiButtonSystem2.ToDefHMI("ButtonSystem2", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiButtonSystem3.ToDefHMI("ButtonSystem3", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiButtonSystem4.ToDefHMI("ButtonSystem4", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiButtonCommand1.ToDefHMI("ButtonCommand1", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiButtonCommand2.ToDefHMI("ButtonCommand2", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiButtonCommand3.ToDefHMI("ButtonCommand3", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiButtonCommand4.ToDefHMI("ButtonCommand4", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiButtonOk.ToDefHMI("ButtonOk", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiButtonCancel.ToDefHMI("ButtonCancel", 4));
		arrayList.Add(new string(' ', 2) + "</ButtonControl>");
		arrayList.Add("  <SpinControl>");
		buEyeVars.parVisual.hmiSpin1.Done = null;
		buEyeVars.parVisual.hmiSpin1.Shape = null;
		buEyeVars.parVisual.hmiSpin2.Done = null;
		buEyeVars.parVisual.hmiSpin2.Shape = null;
		buEyeVars.parVisual.hmiSpin3.Done = null;
		buEyeVars.parVisual.hmiSpin3.Shape = null;
		buEyeVars.parVisual.hmiSpin4.Done = null;
		buEyeVars.parVisual.hmiSpin4.Shape = null;
		arrayList.AddRange(buEyeVars.parVisual.hmiSpin1.ToDefHMI("SpinData1", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiSpin2.ToDefHMI("SpinData2", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiSpin3.ToDefHMI("SpinData3", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiSpin4.ToDefHMI("SpinData4", 4));
		arrayList.Add("  </SpinControl>");
		arrayList.Add("  <TextControl>");
		buEyeVars.parVisual.hmiText1.ButtonNormal = null;
		buEyeVars.parVisual.hmiText1.ButtonDown = null;
		buEyeVars.parVisual.hmiText1.ButtonOver = null;
		buEyeVars.parVisual.hmiText1.Done = null;
		buEyeVars.parVisual.hmiText1.Shape = null;
		buEyeVars.parVisual.hmiText2.ButtonNormal = null;
		buEyeVars.parVisual.hmiText2.ButtonDown = null;
		buEyeVars.parVisual.hmiText2.ButtonOver = null;
		buEyeVars.parVisual.hmiText2.Done = null;
		buEyeVars.parVisual.hmiText2.Shape = null;
		buEyeVars.parVisual.hmiText3.ButtonNormal = null;
		buEyeVars.parVisual.hmiText3.ButtonDown = null;
		buEyeVars.parVisual.hmiText3.ButtonOver = null;
		buEyeVars.parVisual.hmiText3.Done = null;
		buEyeVars.parVisual.hmiText3.Shape = null;
		buEyeVars.parVisual.hmiText4.ButtonNormal = null;
		buEyeVars.parVisual.hmiText4.ButtonDown = null;
		buEyeVars.parVisual.hmiText4.ButtonOver = null;
		buEyeVars.parVisual.hmiText4.Done = null;
		buEyeVars.parVisual.hmiText4.Shape = null;
		arrayList.AddRange(buEyeVars.parVisual.hmiText1.ToDefHMI("TextData1", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiText2.ToDefHMI("TextData2", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiText3.ToDefHMI("TextData3", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiText4.ToDefHMI("TextData4", 4));
		arrayList.Add("  </TextControl>");
		arrayList.Add("  <CheckControl>");
		buEyeVars.parVisual.hmiCheck1.ButtonDown = null;
		buEyeVars.parVisual.hmiCheck1.ButtonOver = null;
		buEyeVars.parVisual.hmiCheck1.Done = null;
		buEyeVars.parVisual.hmiCheck1.Shape = null;
		buEyeVars.parVisual.hmiCheck2.ButtonDown = null;
		buEyeVars.parVisual.hmiCheck2.ButtonOver = null;
		buEyeVars.parVisual.hmiCheck2.Done = null;
		buEyeVars.parVisual.hmiCheck2.Shape = null;
		buEyeVars.parVisual.hmiCheck3.ButtonDown = null;
		buEyeVars.parVisual.hmiCheck3.ButtonOver = null;
		buEyeVars.parVisual.hmiCheck3.Done = null;
		buEyeVars.parVisual.hmiCheck3.Shape = null;
		buEyeVars.parVisual.hmiCheck4.ButtonDown = null;
		buEyeVars.parVisual.hmiCheck4.ButtonOver = null;
		buEyeVars.parVisual.hmiCheck4.Done = null;
		buEyeVars.parVisual.hmiCheck4.Shape = null;
		arrayList.AddRange(buEyeVars.parVisual.hmiCheck1.ToDefHMI("Checkbox1", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiCheck2.ToDefHMI("Checkbox2", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiCheck3.ToDefHMI("Checkbox3", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiCheck4.ToDefHMI("Checkbox4", 4));
		arrayList.Add("  </CheckControl>");
		arrayList.Add("  <LabelControl>");
		buEyeVars.parVisual.hmiLabel1.ButtonNormal = null;
		buEyeVars.parVisual.hmiLabel1.ButtonDown = null;
		buEyeVars.parVisual.hmiLabel1.ButtonOver = null;
		buEyeVars.parVisual.hmiLabel1.Caption = null;
		buEyeVars.parVisual.hmiLabel1.Done = null;
		buEyeVars.parVisual.hmiLabel1.Shape = null;
		buEyeVars.parVisual.hmiLabel2.ButtonNormal = null;
		buEyeVars.parVisual.hmiLabel2.ButtonDown = null;
		buEyeVars.parVisual.hmiLabel2.ButtonOver = null;
		buEyeVars.parVisual.hmiLabel2.Caption = null;
		buEyeVars.parVisual.hmiLabel2.Done = null;
		buEyeVars.parVisual.hmiLabel2.Shape = null;
		buEyeVars.parVisual.hmiLabel3.ButtonNormal = null;
		buEyeVars.parVisual.hmiLabel3.ButtonDown = null;
		buEyeVars.parVisual.hmiLabel3.ButtonOver = null;
		buEyeVars.parVisual.hmiLabel3.Caption = null;
		buEyeVars.parVisual.hmiLabel3.Done = null;
		buEyeVars.parVisual.hmiLabel3.Shape = null;
		buEyeVars.parVisual.hmiLabel4.ButtonNormal = null;
		buEyeVars.parVisual.hmiLabel4.ButtonDown = null;
		buEyeVars.parVisual.hmiLabel4.ButtonOver = null;
		buEyeVars.parVisual.hmiLabel4.Caption = null;
		buEyeVars.parVisual.hmiLabel4.Done = null;
		buEyeVars.parVisual.hmiLabel4.Shape = null;
		arrayList.AddRange(buEyeVars.parVisual.hmiLabel1.ToDefHMI("Labelbox1", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiLabel2.ToDefHMI("Labelbox2", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiLabel3.ToDefHMI("Labelbox3", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiLabel4.ToDefHMI("Labelbox4", 4));
		arrayList.Add("  </LabelControl>");
		arrayList.Add("  <ListboxControl>");
		buEyeVars.parVisual.hmiListbox1.ButtonNormal = null;
		buEyeVars.parVisual.hmiListbox1.ButtonDown = null;
		buEyeVars.parVisual.hmiListbox1.ButtonOver = null;
		buEyeVars.parVisual.hmiListbox1.Caption = null;
		buEyeVars.parVisual.hmiListbox1.Done = null;
		buEyeVars.parVisual.hmiListbox1.Shape = null;
		buEyeVars.parVisual.hmiListbox2.ButtonNormal = null;
		buEyeVars.parVisual.hmiListbox2.ButtonDown = null;
		buEyeVars.parVisual.hmiListbox2.ButtonOver = null;
		buEyeVars.parVisual.hmiListbox2.Caption = null;
		buEyeVars.parVisual.hmiListbox2.Done = null;
		buEyeVars.parVisual.hmiListbox2.Shape = null;
		buEyeVars.parVisual.hmiListbox3.ButtonNormal = null;
		buEyeVars.parVisual.hmiListbox3.ButtonDown = null;
		buEyeVars.parVisual.hmiListbox3.ButtonOver = null;
		buEyeVars.parVisual.hmiListbox3.Caption = null;
		buEyeVars.parVisual.hmiListbox3.Done = null;
		buEyeVars.parVisual.hmiListbox3.Shape = null;
		buEyeVars.parVisual.hmiListbox4.ButtonNormal = null;
		buEyeVars.parVisual.hmiListbox4.ButtonDown = null;
		buEyeVars.parVisual.hmiListbox4.ButtonOver = null;
		buEyeVars.parVisual.hmiListbox4.Caption = null;
		buEyeVars.parVisual.hmiListbox4.Done = null;
		buEyeVars.parVisual.hmiListbox4.Shape = null;
		arrayList.AddRange(buEyeVars.parVisual.hmiListbox1.ToDefHMI("Listbox1", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiListbox2.ToDefHMI("Listbox2", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiListbox3.ToDefHMI("Listbox3", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiListbox4.ToDefHMI("Listbox4", 4));
		arrayList.Add("  </ListboxControl>");
		arrayList.Add("  <DataGridViewControl>");
		arrayList.AddRange(buEyeVars.parVisual.hmiDGV1.ToDefAll("DGV1", 4, SerilizationMode.MultiLine));
		arrayList.AddRange(buEyeVars.parVisual.hmiDGV2.ToDefAll("DGV2", 4, SerilizationMode.MultiLine));
		arrayList.Add("  </DataGridViewControl>");
		arrayList.Add("  <RadioButtonControl>");
		buEyeVars.parVisual.hmiRadioButton1.ButtonNormal = null;
		buEyeVars.parVisual.hmiRadioButton1.ButtonDown = null;
		buEyeVars.parVisual.hmiRadioButton1.ButtonOver = null;
		buEyeVars.parVisual.hmiRadioButton1.Caption = null;
		buEyeVars.parVisual.hmiRadioButton1.Done = null;
		buEyeVars.parVisual.hmiRadioButton1.Shape = null;
		buEyeVars.parVisual.hmiRadioButton2.ButtonNormal = null;
		buEyeVars.parVisual.hmiRadioButton2.ButtonDown = null;
		buEyeVars.parVisual.hmiRadioButton2.ButtonOver = null;
		buEyeVars.parVisual.hmiRadioButton2.Caption = null;
		buEyeVars.parVisual.hmiRadioButton2.Done = null;
		buEyeVars.parVisual.hmiRadioButton2.Shape = null;
		buEyeVars.parVisual.hmiRadioButton3.ButtonNormal = null;
		buEyeVars.parVisual.hmiRadioButton3.ButtonDown = null;
		buEyeVars.parVisual.hmiRadioButton3.ButtonOver = null;
		buEyeVars.parVisual.hmiRadioButton3.Caption = null;
		buEyeVars.parVisual.hmiRadioButton3.Done = null;
		buEyeVars.parVisual.hmiRadioButton3.Shape = null;
		buEyeVars.parVisual.hmiRadioButton4.ButtonNormal = null;
		buEyeVars.parVisual.hmiRadioButton4.ButtonDown = null;
		buEyeVars.parVisual.hmiRadioButton4.ButtonOver = null;
		buEyeVars.parVisual.hmiRadioButton4.Caption = null;
		buEyeVars.parVisual.hmiRadioButton4.Done = null;
		buEyeVars.parVisual.hmiRadioButton4.Shape = null;
		arrayList.AddRange(buEyeVars.parVisual.hmiRadioButton1.ToDefHMI("RadioButton1", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiRadioButton2.ToDefHMI("RadioButton2", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiRadioButton3.ToDefHMI("RadioButton3", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiRadioButton4.ToDefHMI("RadioButton4", 4));
		arrayList.Add("  </RadioButtonControl>");
		arrayList.Add("  <TrackControl>");
		buEyeVars.parVisual.hmiTrack1.ButtonDown = null;
		buEyeVars.parVisual.hmiTrack1.ButtonNormal = null;
		buEyeVars.parVisual.hmiTrack1.ButtonOver = null;
		buEyeVars.parVisual.hmiTrack2.ButtonDown = null;
		buEyeVars.parVisual.hmiTrack2.ButtonNormal = null;
		buEyeVars.parVisual.hmiTrack2.ButtonOver = null;
		arrayList.AddRange(buEyeVars.parVisual.hmiTrack1.ToDefHMI("Track1", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiTrack2.ToDefHMI("Track2", 4));
		arrayList.Add("  </TrackControl>");
		arrayList.Add("  <ProgressControl>");
		buEyeVars.parVisual.hmiProgress1.ButtonDown = null;
		buEyeVars.parVisual.hmiProgress1.ButtonNormal = null;
		buEyeVars.parVisual.hmiProgress1.ButtonOver = null;
		buEyeVars.parVisual.hmiProgress2.ButtonDown = null;
		buEyeVars.parVisual.hmiProgress2.ButtonNormal = null;
		buEyeVars.parVisual.hmiProgress2.ButtonOver = null;
		arrayList.AddRange(buEyeVars.parVisual.hmiProgress1.ToDefHMI("Progress1", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiProgress2.ToDefHMI("Progress2", 4));
		arrayList.Add("  </ProgressControl>");
		arrayList.Add("  <ComboControl>");
		buEyeVars.parVisual.hmiCombo1.ButtonDown = null;
		buEyeVars.parVisual.hmiCombo1.ButtonNormal = null;
		buEyeVars.parVisual.hmiCombo1.ButtonOver = null;
		buEyeVars.parVisual.hmiCombo1.Shape = null;
		buEyeVars.parVisual.hmiCombo1.Done = null;
		buEyeVars.parVisual.hmiCombo2.ButtonDown = null;
		buEyeVars.parVisual.hmiCombo2.ButtonNormal = null;
		buEyeVars.parVisual.hmiCombo2.ButtonOver = null;
		buEyeVars.parVisual.hmiCombo2.Shape = null;
		buEyeVars.parVisual.hmiCombo2.Done = null;
		buEyeVars.parVisual.hmiCombo3.ButtonDown = null;
		buEyeVars.parVisual.hmiCombo3.ButtonNormal = null;
		buEyeVars.parVisual.hmiCombo3.ButtonOver = null;
		buEyeVars.parVisual.hmiCombo3.Shape = null;
		buEyeVars.parVisual.hmiCombo3.Done = null;
		buEyeVars.parVisual.hmiCombo4.ButtonDown = null;
		buEyeVars.parVisual.hmiCombo4.ButtonNormal = null;
		buEyeVars.parVisual.hmiCombo4.ButtonOver = null;
		buEyeVars.parVisual.hmiCombo4.Shape = null;
		buEyeVars.parVisual.hmiCombo4.Done = null;
		arrayList.AddRange(buEyeVars.parVisual.hmiCombo1.ToDefHMI("Combo1", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiCombo2.ToDefHMI("Combo", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiCombo3.ToDefHMI("Combo1", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiCombo4.ToDefHMI("Combo", 4));
		arrayList.Add("  </ComboControl>");
		arrayList.Add("  <GroupControl>");
		buEyeVars.parVisual.hmiGroup1.ButtonDown = null;
		buEyeVars.parVisual.hmiGroup1.ButtonNormal = null;
		buEyeVars.parVisual.hmiGroup1.ButtonOver = null;
		buEyeVars.parVisual.hmiGroup1.Shape = null;
		buEyeVars.parVisual.hmiGroup1.Done = null;
		buEyeVars.parVisual.hmiGroup2.ButtonDown = null;
		buEyeVars.parVisual.hmiGroup2.ButtonNormal = null;
		buEyeVars.parVisual.hmiGroup2.ButtonOver = null;
		buEyeVars.parVisual.hmiGroup2.Shape = null;
		buEyeVars.parVisual.hmiGroup2.Done = null;
		arrayList.AddRange(buEyeVars.parVisual.hmiGroup1.ToDefHMI("Group1", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiGroup2.ToDefHMI("Group2", 4));
		arrayList.Add("  </GroupControl>");
		arrayList.Add("  <PanelControl>");
		buEyeVars.parVisual.hmiPanel1.ButtonDown = null;
		buEyeVars.parVisual.hmiPanel1.ButtonNormal = null;
		buEyeVars.parVisual.hmiPanel1.ButtonOver = null;
		buEyeVars.parVisual.hmiPanel1.Shape = null;
		buEyeVars.parVisual.hmiPanel1.Done = null;
		buEyeVars.parVisual.hmiPanel2.ButtonDown = null;
		buEyeVars.parVisual.hmiPanel2.ButtonNormal = null;
		buEyeVars.parVisual.hmiPanel2.ButtonOver = null;
		buEyeVars.parVisual.hmiPanel2.Shape = null;
		buEyeVars.parVisual.hmiPanel2.Done = null;
		arrayList.AddRange(buEyeVars.parVisual.hmiGroup1.ToDefHMI("Panel1", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiGroup2.ToDefHMI("Panel2", 4));
		arrayList.Add("  </PanelControl>");
		arrayList.Add("  <SpeedControl>");
		arrayList.AddRange(buEyeVars.parVisual.hmiSpeed1.ToDefHMI("Speed1", 4));
		arrayList.Add("  </SpeedControl>");
		arrayList.Add("  <GroundControl>");
		buEyeVars.parVisual.hmiGround1.ButtonDown = null;
		buEyeVars.parVisual.hmiGround1.ButtonNormal = null;
		buEyeVars.parVisual.hmiGround1.ButtonOver = null;
		buEyeVars.parVisual.hmiGround1.Done = null;
		buEyeVars.parVisual.hmiGround2.ButtonDown = null;
		buEyeVars.parVisual.hmiGround2.ButtonNormal = null;
		buEyeVars.parVisual.hmiGround2.ButtonOver = null;
		buEyeVars.parVisual.hmiGround2.Done = null;
		arrayList.AddRange(buEyeVars.parVisual.hmiGround1.ToDefHMI("Ground1", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiGround2.ToDefHMI("Ground2", 4));
		arrayList.Add("  </GroundControl>");
		arrayList.Add("  <SingleControl>");
		arrayList.AddRange(buEyeVars.parVisual.hmiOn1.ToDefHMI("On1", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiOff1.ToDefHMI("Off1", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiOn2.ToDefHMI("On2", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiOff2.ToDefHMI("Off2", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiWarning.ToDefHMI("Warning", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiError.ToDefHMI("Error", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiInfo.ToDefHMI("Info", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiStatus.ToDefHMI("Status", 4));
		arrayList.Add("  </SingleControl>");
		arrayList.Add("  <Coordinate>");
		buEyeVars.parVisual.hmiCoords1.ButtonDown = null;
		buEyeVars.parVisual.hmiCoords1.ButtonNormal = null;
		buEyeVars.parVisual.hmiCoords1.ButtonOver = null;
		buEyeVars.parVisual.hmiCoords1.Done = null;
		buEyeVars.parVisual.hmiCoords1.Shape = null;
		buEyeVars.parVisual.hmiCoords2.ButtonDown = null;
		buEyeVars.parVisual.hmiCoords2.ButtonNormal = null;
		buEyeVars.parVisual.hmiCoords2.ButtonOver = null;
		buEyeVars.parVisual.hmiCoords2.Done = null;
		buEyeVars.parVisual.hmiCoords2.Shape = null;
		arrayList.AddRange(buEyeVars.parVisual.hmiCoords1.ToDefHMI("Coords1", 4));
		arrayList.AddRange(buEyeVars.parVisual.hmiCoords2.ToDefHMI("Coords2", 4));
		arrayList.Add("  </Coordinate>");
		arrayList.Add("</ApplicationCommonColors>");
		arrayList.Add("");
		buFile5.SaveToFile(arrayList, FileName);
	}
}
