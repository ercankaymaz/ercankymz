using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleCam3D : Form
{
	[CompilerGenerated]
	private OkCommandWithFiveDataEventHandler okCommandWithFiveDataEventHandler_0;

	public Color SpinBaseColor = Color.LightGreen;

	public Color SpinFocusColor = Color.MistyRose;

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public MarbleCamType CommandType = MarbleCamType.None;

	public Color clrLabel = Color.DarkSeaGreen;

	public Color clrFormCaption = Color.LightBlue;

	public Color clrFormBackUpper = Color.Black;

	public Color clrFormBackDown = Color.DarkGray;

	public Color clrButtonDisplay = Color.DarkGray;

	public Color clrButtonOver = Color.Gold;

	public Color clrButtonDown = Color.Goldenrod;

	internal IContainer icontainer_0 = null;

	public buButton btn_close;

	internal ImageList imageList_0;

	internal ImageList imageList_1;

	public buGround buGround1;

	public buButton btn_pencil3AX;

	public buButton btn_flatland3AX;

	public buButton btn_constantZ3AX;

	public buButton btn_paralllelcut3AX;

	public buButton btn_sawveralrough;

	public buButton btn_sawhorizontalrough;

	public buButton btn_pocketbydrill;

	public buButton btn_5axisrotartmilling;

	public buButton btn_5axisflatmilling;

	public buButton btn_Rough3AX;

	public buButton btn_roughoutside;

	public buButton btn_surfaceclear;

	public buButton btn_sawveralfinis;

	public buButton btn_sawhorizontalfinish;

	public buButton btn_cornercleaning;

	public buButton btn_rough3plus2back;

	public buButton btn_rough3plus2front;

	public buButton btn_roughrotary;

	public buButton btn_finishprojection;

	public buButton btn_roughprojection;

	public buButton btn_5axisgeodesicmilling;

	internal buLabel buLabel_0;

	internal buLabel buLabel_1;

	public buButton btn_constantcusp3AX;

	public event OkCommandWithFiveDataEventHandler CommandExecute
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithFiveDataEventHandler okCommandWithFiveDataEventHandler = okCommandWithFiveDataEventHandler_0;
			OkCommandWithFiveDataEventHandler okCommandWithFiveDataEventHandler2;
			do
			{
				okCommandWithFiveDataEventHandler2 = okCommandWithFiveDataEventHandler;
				OkCommandWithFiveDataEventHandler value2 = (OkCommandWithFiveDataEventHandler)Delegate.Combine(okCommandWithFiveDataEventHandler2, value);
				okCommandWithFiveDataEventHandler = Interlocked.CompareExchange(ref okCommandWithFiveDataEventHandler_0, value2, okCommandWithFiveDataEventHandler2);
			}
			while ((object)okCommandWithFiveDataEventHandler != okCommandWithFiveDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithFiveDataEventHandler okCommandWithFiveDataEventHandler = okCommandWithFiveDataEventHandler_0;
			OkCommandWithFiveDataEventHandler okCommandWithFiveDataEventHandler2;
			do
			{
				okCommandWithFiveDataEventHandler2 = okCommandWithFiveDataEventHandler;
				OkCommandWithFiveDataEventHandler value2 = (OkCommandWithFiveDataEventHandler)Delegate.Remove(okCommandWithFiveDataEventHandler2, value);
				okCommandWithFiveDataEventHandler = Interlocked.CompareExchange(ref okCommandWithFiveDataEventHandler_0, value2, okCommandWithFiveDataEventHandler2);
			}
			while ((object)okCommandWithFiveDataEventHandler != okCommandWithFiveDataEventHandler2);
		}
	}

	public F_MarbleCam3D()
	{
		Class186.smethod_310(this);
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
		LoadLanguage();
		buGround1.DisplayTop.BackColor = clrFormCaption;
		buGround1.Display.GradientType = GradientMode.Lineer;
		buGround1.Display.LineerGradient.FirstColor = clrFormBackUpper;
		buGround1.Display.LineerGradient.SecondColor = clrFormBackDown;
		btn_close.Display.BackColor = clrFormCaption;
		btn_close.ButtonDownDisplay.BackColor = buImage5.ColorToneChange(clrFormCaption, 0.9);
		btn_close.ButtonOverDisplay.BackColor = buImage5.ColorToneChange(clrFormCaption, 0.95);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			btn_constantZ3AX.Text = "3 " + buLangTranslate.preDef.Axis + " " + buLangTranslate.preDef.ConstantZ;
			btn_paralllelcut3AX.Text = "3 " + buLangTranslate.preDef.Axis + " " + buLangTranslate.preDef.ParalelCuts;
			btn_Rough3AX.Text = "3 " + buLangTranslate.preDef.Axis + " " + buLangTranslate.preDef.Rough;
			btn_pencil3AX.Text = "3 " + buLangTranslate.preDef.Axis + " " + buLangTranslate.preDef.Pencil;
			btn_flatland3AX.Text = "3 " + buLangTranslate.preDef.Axis + " " + buLangTranslate.preDef.Flatlands;
			btn_sawveralrough.Text = "4 " + buLangTranslate.preDef.Axis + " " + buLangTranslate.preDef.Saw + " " + buLangTranslate.preDef.Vertical + " " + buLangTranslate.preDef.Rough;
			btn_sawhorizontalrough.Text = "3 " + buLangTranslate.preDef.Axis + " " + buLangTranslate.preDef.Slice + " " + buLangTranslate.preDef.Horizontal + " " + buLangTranslate.preDef.Rough;
			btn_sawveralfinis.Text = "4 " + buLangTranslate.preDef.Axis + " " + buLangTranslate.preDef.Saw + " " + buLangTranslate.preDef.Vertical + " " + buLangTranslate.preDef.Finish;
			btn_sawhorizontalfinish.Text = "3 " + buLangTranslate.preDef.Axis + " " + buLangTranslate.preDef.Slice + " " + buLangTranslate.preDef.Horizontal + " " + buLangTranslate.preDef.Finish;
			btn_5axisflatmilling.Text = "5 " + buLangTranslate.preDef.Axis + " " + buLangTranslate.preDef.FlatMilling;
			btn_5axisrotartmilling.Text = "5 " + buLangTranslate.preDef.Axis + " " + buLangTranslate.preDef.Rotary + " " + buLangTranslate.preDef.Milling;
			btn_pocketbydrill.Text = buLangTranslate.preDef.Drill + " " + buLangTranslate.preDef.Pocket;
			btn_surfaceclear.Text = "2.5 " + buLangTranslate.preDef.Axis + " " + buLangTranslate.preDef.Surface + " " + buLangTranslate.preDef.Cleaning;
			btn_roughoutside.Text = "3 " + buLangTranslate.preDef.Axis + " " + buLangTranslate.preDef.Rough + " " + buLangTranslate.preDef.Offset;
			buGround1.Text = buLangTranslate.preDef.Cam + " " + buLangTranslate.preDef.Strategy;
		}
		catch (Exception)
		{
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

	public void Apply()
	{
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (!(control.Name == btn_Rough3AX.Name))
		{
			if (!(control.Name == btn_constantZ3AX.Name))
			{
				if (!(control.Name == btn_paralllelcut3AX.Name))
				{
					if (!(control.Name == btn_pencil3AX.Name))
					{
						if (!(control.Name == btn_flatland3AX.Name))
						{
							if (!(control.Name == btn_sawveralrough.Name))
							{
								if (!(control.Name == btn_sawhorizontalrough.Name))
								{
									if (!(control.Name == btn_sawveralfinis.Name))
									{
										if (!(control.Name == btn_sawhorizontalfinish.Name))
										{
											if (!(control.Name == btn_5axisflatmilling.Name))
											{
												if (!(control.Name == btn_5axisrotartmilling.Name))
												{
													if (!(control.Name == btn_roughoutside.Name))
													{
														if (!(control.Name == btn_surfaceclear.Name))
														{
															if (!(control.Name == btn_pocketbydrill.Name))
															{
																if (!(control.Name == btn_cornercleaning.Name))
																{
																	if (!(control.Name == btn_rough3plus2front.Name))
																	{
																		if (!(control.Name == btn_rough3plus2back.Name))
																		{
																			if (!(control.Name == btn_roughrotary.Name))
																			{
																				if (!(control.Name == btn_roughprojection.Name))
																				{
																					if (!(control.Name == btn_finishprojection.Name))
																					{
																						if (!(control.Name == btn_5axisgeodesicmilling.Name))
																						{
																							if (control.Name == btn_constantcusp3AX.Name)
																							{
																								CommandType = MarbleCamType.MillingContantCusp3D;
																							}
																						}
																						else
																						{
																							CommandType = MarbleCamType.MillingGeodesic5D;
																						}
																					}
																					else
																					{
																						CommandType = MarbleCamType.ProjectionRoundFinish;
																					}
																				}
																				else
																				{
																					CommandType = MarbleCamType.ProjectionRoundRough;
																				}
																			}
																			else
																			{
																				CommandType = MarbleCamType.RoughRotary;
																			}
																		}
																		else
																		{
																			CommandType = MarbleCamType.Rough3Plus2Back;
																		}
																	}
																	else
																	{
																		CommandType = MarbleCamType.Rough3Plus2Front;
																	}
																}
																else
																{
																	CommandType = MarbleCamType.CornerCleaning;
																}
															}
															else
															{
																CommandType = MarbleCamType.PocketByDrilling;
															}
														}
														else
														{
															CommandType = MarbleCamType.Surface2D;
														}
													}
													else
													{
														CommandType = MarbleCamType.RoughOutside;
													}
												}
												else
												{
													CommandType = MarbleCamType.MillingContantZ5D;
												}
											}
											else
											{
												CommandType = MarbleCamType.MillingParallelCut5D;
											}
										}
										else
										{
											CommandType = MarbleCamType.SawMillingHorizontalFinish;
										}
									}
									else
									{
										CommandType = MarbleCamType.SawMillingVerticalFinish;
									}
								}
								else
								{
									CommandType = MarbleCamType.SawMillingHorizontalRough;
								}
							}
							else
							{
								CommandType = MarbleCamType.SawMillingVerticalRough;
							}
						}
						else
						{
							CommandType = MarbleCamType.MillingFlatland3D;
						}
					}
					else
					{
						CommandType = MarbleCamType.MillingPencil3D;
					}
				}
				else
				{
					CommandType = MarbleCamType.MillingParallelCut3D;
				}
			}
			else
			{
				CommandType = MarbleCamType.MillingContantZ3D;
			}
		}
		else
		{
			CommandType = MarbleCamType.MillingRough3D;
		}
		if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		PropertiesForm.Result = DialogResult.Cancel;
		CommandType = MarbleCamType.None;
		if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
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
