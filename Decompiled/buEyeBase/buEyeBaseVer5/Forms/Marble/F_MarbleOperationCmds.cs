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

public class F_MarbleOperationCmds : Form
{
	[CompilerGenerated]
	private OkCommandWithFiveDataEventHandler okCommandWithFiveDataEventHandler_0;

	public Color SpinBaseColor = Color.LightGreen;

	public Color SpinFocusColor = Color.MistyRose;

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public MarbleItemType CommandType = MarbleItemType.None;

	public Color clrLabel = Color.DarkSeaGreen;

	public Color clrFormCaption = Color.LightBlue;

	public Color clrFormBackUpper = Color.Black;

	public Color clrFormBackDown = Color.DarkGray;

	public Color clrButtonDisplay = Color.DarkGray;

	public Color clrButtonOver = Color.Gold;

	public Color clrButtonDown = Color.Goldenrod;

	internal IContainer icontainer_0 = null;

	public buButton btn_vertical;

	public buButton btn_close;

	internal ImageList imageList_0;

	internal ImageList imageList_1;

	public buGround buGround1;

	public buButton btn_drill;

	public buButton btn_air;

	public buButton btn_verticallathe;

	public buButton btn_horizontallathe;

	public buButton btn_columns;

	public buButton btn_sweep;

	public buButton btn_engrave;

	public buButton btn_cleaning;

	public buButton btn_text;

	public buButton btn_shapes;

	public buButton btn_arcprofile;

	public buButton btn_profile;

	public buButton btn_library;

	public buButton btn_contour;

	public buButton btn_single;

	public buButton btn_horizontal;

	public buButton btn_editor;

	public buButton btn_gcode;

	public buButton btn_countertop;

	public buButton btn_slices;

	public buButton btn_sawveralmilling;

	public buButton btn_sawhorizontalmilling;

	public buButton btn_easydraw;

	public buButton btn_pocketbydrill;

	public buButton btn_5axisrotartmilling;

	public buButton btn_5axisflatmilling;

	public buButton btn_horver;

	public buButton btn_cutremainmaterial;

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

	public F_MarbleOperationCmds()
	{
		Class186.smethod_535(this);
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
		btn_vertical.Display.BackColor = clrButtonDisplay;
		btn_vertical.ButtonDownDisplay.BackColor = clrButtonDown;
		btn_vertical.ButtonOverDisplay.BackColor = clrButtonOver;
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			btn_air.Text = buLangTranslate.preDef.Air + " " + buLangTranslate.preDef.Dry;
			btn_arcprofile.Text = buLangTranslate.preDef.Profile + " " + buLangTranslate.preDef.Curve;
			btn_cleaning.Text = buLangTranslate.preDef.Cleaning;
			btn_columns.Text = buLangTranslate.preDef.Columns;
			btn_contour.Text = buLangTranslate.preDef.Contour;
			btn_drill.Text = buLangTranslate.preDef.Drill;
			btn_editor.Text = buLangTranslate.preDef.Editor;
			btn_engrave.Text = buLangTranslate.preDef.Engraving;
			btn_horizontal.Text = buLangTranslate.preDef.Horizontal;
			btn_horizontallathe.Text = buLangTranslate.preDef.Horizontal + " " + buLangTranslate.preDef.Lathe;
			btn_library.Text = buLangTranslate.preDef.Library;
			btn_profile.Text = buLangTranslate.preDef.Profile;
			btn_shapes.Text = buLangTranslate.preDef.Shape;
			btn_single.Text = buLangTranslate.preDef.Single + " " + buLangTranslate.preDef.Cut;
			btn_sweep.Text = buLangTranslate.preDef.Sweep;
			btn_text.Text = buLangTranslate.preDef.Text;
			btn_vertical.Text = buLangTranslate.preDef.Vertical + " " + buLangTranslate.preDef.Cut;
			btn_verticallathe.Text = buLangTranslate.preDef.Vertical + " " + buLangTranslate.preDef.Lathe;
			btn_gcode.Text = buLangTranslate.preDef.GCode;
			btn_countertop.Text = buLangTranslate.preDef.Countertop;
			btn_slices.Text = buLangTranslate.preDef.Slice;
			btn_sawveralmilling.Text = buLangTranslate.preDef.Saw + " " + buLangTranslate.preDef.Vertical + " " + buLangTranslate.preDef.Milling;
			btn_sawhorizontalmilling.Text = buLangTranslate.preDef.Slice + " " + buLangTranslate.preDef.Horizontal + " " + buLangTranslate.preDef.Milling;
			btn_easydraw.Text = buLangTranslate.preDef.Easy + " " + buLangTranslate.preDef.Drawing;
			btn_horver.Text = buLangTranslate.preDef.Horizontal + " " + buLangTranslate.preDef.Vertical;
			btn_cutremainmaterial.Text = buLangTranslate.preDef.Cut + " " + buLangTranslate.preDef.Remnant + " " + buLangTranslate.preDef.Material;
			btn_5axisrotartmilling.Text = buLangTranslate.preDef.Rotary + " " + buLangTranslate.preDef.Milling;
			btn_5axisflatmilling.Text = buLangTranslate.preDef.Flat + " " + buLangTranslate.preDef.Milling;
			btn_pocketbydrill.Text = buLangTranslate.preDef.Pocket + " " + buLangTranslate.preDef.Drill;
			buGround1.Text = buLangTranslate.preDef.Operation + " " + buLangTranslate.preDef.Menu;
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
		if (!(control.Name == btn_air.Name))
		{
			if (!(control.Name == btn_arcprofile.Name))
			{
				if (!(control.Name == btn_cleaning.Name))
				{
					if (!(control.Name == btn_columns.Name))
					{
						if (!(control.Name == btn_contour.Name))
						{
							if (!(control.Name == btn_drill.Name))
							{
								if (!(control.Name == btn_engrave.Name))
								{
									if (!(control.Name == btn_horizontal.Name))
									{
										if (!(control.Name == btn_horizontallathe.Name))
										{
											if (!(control.Name == btn_library.Name))
											{
												if (!(control.Name == btn_profile.Name))
												{
													if (!(control.Name == btn_shapes.Name))
													{
														if (!(control.Name == btn_single.Name))
														{
															if (!(control.Name == btn_sweep.Name))
															{
																if (!(control.Name == btn_text.Name))
																{
																	if (!(control.Name == btn_vertical.Name))
																	{
																		if (!(control.Name == btn_verticallathe.Name))
																		{
																			if (!(control.Name == btn_editor.Name))
																			{
																				if (!(control.Name == btn_gcode.Name))
																				{
																					if (!(control.Name == btn_slices.Name))
																					{
																						if (!(control.Name == btn_sawveralmilling.Name))
																						{
																							if (!(control.Name == btn_sawhorizontalmilling.Name))
																							{
																								if (!(control.Name == btn_easydraw.Name))
																								{
																									if (!(control.Name == btn_pocketbydrill.Name))
																									{
																										if (!(control.Name == btn_5axisrotartmilling.Name))
																										{
																											if (!(control.Name == btn_5axisflatmilling.Name))
																											{
																												if (!(control.Name == btn_horver.Name))
																												{
																													if (control.Name == btn_cutremainmaterial.Name)
																													{
																														CommandType = MarbleItemType.CutRemainMaterial;
																													}
																												}
																												else
																												{
																													CommandType = MarbleItemType.HorizontalVerticalCut;
																												}
																											}
																											else
																											{
																												CommandType = MarbleItemType.Milling5AxisFlat;
																											}
																										}
																										else
																										{
																											CommandType = MarbleItemType.Milling5AxisRotary;
																										}
																									}
																									else
																									{
																										CommandType = MarbleItemType.PocketByDrill;
																									}
																								}
																								else
																								{
																									CommandType = MarbleItemType.EasyDraw;
																								}
																							}
																							else
																							{
																								CommandType = MarbleItemType.SawHorizontalMillingRough;
																							}
																						}
																						else
																						{
																							CommandType = MarbleItemType.SawVerticalMillingRough;
																						}
																					}
																					else
																					{
																						CommandType = MarbleItemType.Slices;
																					}
																				}
																				else
																				{
																					CommandType = MarbleItemType.GCode;
																				}
																			}
																			else
																			{
																				CommandType = MarbleItemType.Editor;
																			}
																		}
																		else
																		{
																			CommandType = MarbleItemType.LatheVertical;
																		}
																	}
																	else
																	{
																		CommandType = MarbleItemType.VerticalCut;
																	}
																}
																else
																{
																	CommandType = MarbleItemType.Text;
																}
															}
															else
															{
																CommandType = MarbleItemType.Sweep;
															}
														}
														else
														{
															CommandType = MarbleItemType.SingleCut;
														}
													}
													else
													{
														CommandType = MarbleItemType.Shape;
													}
												}
												else
												{
													CommandType = MarbleItemType.Profiling;
												}
											}
											else
											{
												CommandType = MarbleItemType.Library;
											}
										}
										else
										{
											CommandType = MarbleItemType.LatheHorizontal;
										}
									}
									else
									{
										CommandType = MarbleItemType.HorizontalCut;
									}
								}
								else
								{
									CommandType = MarbleItemType.Engraving;
								}
							}
							else
							{
								CommandType = MarbleItemType.Drill;
							}
						}
						else
						{
							CommandType = MarbleItemType.Contour;
						}
					}
					else
					{
						CommandType = MarbleItemType.Columns;
					}
				}
				else
				{
					CommandType = MarbleItemType.MaterialClean;
				}
			}
			else
			{
				CommandType = MarbleItemType.ProfileCurve;
			}
		}
		else
		{
			CommandType = MarbleItemType.AirDry;
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
		CommandType = MarbleItemType.None;
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
