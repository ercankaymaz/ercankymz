using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleEngraveCamSetting : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public camParameters5 varRoughSettings = null;

	public camParameters5 varParalelCutSettings = null;

	public camParameters5 varContantZSettings = null;

	public camParameters5 varFlatlandSettings = null;

	public camParameters5 varPencilSettings = null;

	public camParameters5 varProjectionRoughSettings = null;

	public camParameters5 varProjectionFinishSettings = null;

	public camParameters5 varGeoDesicSettings = null;

	public MarbleCamType CamType = MarbleCamType.MillingRough3D;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal buGround buGround_0;

	public buSpin spn_roughcuttingvel;

	public buSpin spn_roughplungevel;

	public buButton btn_ok;

	public buButton btn_cancel;

	public buSpin spn_roughsafedistance;

	public buSpin spn_roughrapiddistance;

	internal buTab buTab_0;

	internal TabPage tabPage_0;

	internal TabPage tabPage_1;

	internal buLabel buLabel_0;

	public buSpin spn_roughsteplen;

	internal TabPage tabPage_2;

	internal TabPage tabPage_3;

	internal TabPage tabPage_4;

	internal buLabel buLabel_1;

	public buSpin spn_finishsafedistance;

	public buSpin spn_finishrapiddis;

	public buSpin spn_finishplungevel;

	public buSpin spn_finishcuttingvel;

	public buSpin spn_constantZsteplen;

	internal buLabel buLabel_2;

	public buSpin spn_constantZsafedis;

	public buSpin spn_constantZrapiddis;

	public buSpin spn_constantZplungevel;

	public buSpin spn_constantZcuttingvel;

	internal buLabel buLabel_3;

	public buSpin spn_flatlandsafedis;

	public buSpin spn_flatlandrapiddis;

	public buSpin spn_flatlandplungevel;

	public buSpin spn_flatlandcuttingvel;

	internal buLabel buLabel_4;

	public buSpin spn_pencilsafedis;

	public buSpin spn_pencilrapiddis;

	public buSpin spn_pencilplungevel;

	public buSpin spn_pencilcuttingvel;

	public buSpin spn_roughtoolpersentage;

	public buSpin spn_finishtoolpersentage;

	public buSpin spn_flatlandtoolpersentage;

	internal buLabel buLabel_5;

	internal buLabel buLabel_6;

	public buCheckBox chk_spiral;

	public buCheckBox chk_zigzag;

	public buCheckBox chk_oneway;

	public buCheckBox chk_level;

	public buCheckBox chk_region;

	internal buLabel buLabel_7;

	public buCheckBox chk_silhouettepartend;

	public buCheckBox chk_silhouettepart;

	public buCheckBox chk_silhouettenone;

	public buCheckBox chk_silhouettetoolcontact;

	public buSpin spn_cuttolerance;

	public buCheckBox chk_roughadaptive;

	public buCheckBox chk_roughparalel;

	public buCheckBox chk_roughoffset;

	public buCheckBox chk_roughuseramp;

	internal Panel panel_0;

	internal buLabel buLabel_8;

	public buCheckBox chk_roughremovecornerpeg;

	public buCheckBox chk_roughleadout;

	public buCheckBox chk_roughsharpcorner;

	public buSpin spn_roughrampdia;

	public buSpin spn_roughrampangle;

	public buCheckBox chk_roughminimizelink;

	public buButton btn_roughok;

	public buButton btn_roughsettings;

	public buButton btn_closecross;

	public buSpin spn_roughendheight;

	public buSpin spn_roughstartheight;

	internal buLabel buLabel_9;

	public buCheckBox chk_roughstocksurface;

	public buCheckBox chk_roughstockbox;

	public F_MarbleEngraveCamSetting()
	{
		Class186.smethod_765(this);
	}

	public void Init(MarbleCamType camType)
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
		CamType = camType;
		PropertiesForm.Result = DialogResult.None;
		if (!((CamType == MarbleCamType.MillingRough3D) | (CamType == MarbleCamType.Rough3Plus2Back) | (CamType == MarbleCamType.Rough3Plus2Front)))
		{
			if (!((CamType == MarbleCamType.MillingParallelCut3D) | (CamType == MarbleCamType.MillingParallelCut5D)))
			{
				if (!((CamType == MarbleCamType.MillingContantZ3D) | (CamType == MarbleCamType.MillingContantZ5D)))
				{
					if (CamType != MarbleCamType.MillingFlatland3D)
					{
						if (CamType != MarbleCamType.MillingPencil3D)
						{
							buTab_0.SelectedIndex = 0;
							buTab_0.ItemSize = new Size(105, 30);
						}
						else
						{
							buTab_0.SelectedIndex = 4;
							buTab_0.ItemSize = new Size(1, 1);
							Class186.smethod_633(this, varPencilSettings);
						}
					}
					else
					{
						buTab_0.SelectedIndex = 3;
						buTab_0.ItemSize = new Size(1, 1);
						Class186.smethod_633(this, varFlatlandSettings);
					}
				}
				else
				{
					buTab_0.SelectedIndex = 2;
					buTab_0.ItemSize = new Size(1, 1);
					Class186.smethod_633(this, varContantZSettings);
				}
			}
			else
			{
				buTab_0.SelectedIndex = 1;
				buTab_0.ItemSize = new Size(1, 1);
				Class186.smethod_633(this, varParalelCutSettings);
			}
		}
		else
		{
			buTab_0.SelectedIndex = 0;
			buTab_0.ItemSize = new Size(1, 1);
			Class186.smethod_633(this, varRoughSettings);
		}
		if (varRoughSettings != null)
		{
			spn_roughcuttingvel.Value = varRoughSettings.Speeds.Feed;
			spn_roughplungevel.Value = varRoughSettings.Speeds.Plunge;
			spn_roughrapiddistance.Value = varRoughSettings.Distances.Rapid;
			spn_roughsafedistance.Value = varRoughSettings.Distances.Safe;
			spn_roughsteplen.Value = varRoughSettings.Steps.DepthStep;
			spn_roughtoolpersentage.Value = varRoughSettings.Pockets.StepOverPersentage;
			chk_roughadaptive.Check = false;
			chk_roughparalel.Check = false;
			chk_roughoffset.Check = false;
			if (varRoughSettings.Pockets.PocketType != CamPocketType.WfbRghtOffset)
			{
				if (varRoughSettings.Pockets.PocketType != CamPocketType.WfbRghtAdaptive)
				{
					if (varRoughSettings.Pockets.PocketType == CamPocketType.WfbRghtParallel)
					{
						chk_roughparalel.Check = true;
					}
				}
				else
				{
					chk_roughadaptive.Check = true;
				}
			}
			else
			{
				chk_roughoffset.Check = true;
			}
			chk_roughsharpcorner.Check = varRoughSettings.Pockets.SharpCorner;
			chk_roughleadout.Check = varRoughSettings.Strategy.RoughLeadOut;
			chk_roughminimizelink.Check = varRoughSettings.Strategy.MinimizeLink;
			chk_roughremovecornerpeg.Check = varRoughSettings.Strategy.RemoveCornerPeg;
			chk_roughuseramp.Check = varRoughSettings.Strategy.MinimizeLink;
			spn_roughrampangle.Value = varRoughSettings.Strategy.RampAngle;
			spn_roughrampdia.Value = varRoughSettings.Strategy.RampMaxDiameterFromToolPerc;
			spn_roughstartheight.Value = varRoughSettings.Steps.StartValue;
			spn_roughendheight.Value = varRoughSettings.Steps.EndValue;
			if (varRoughSettings.Options.StockType != CamStockType.StSurfaces)
			{
				chk_roughstockbox.Check = false;
				chk_roughstocksurface.Check = true;
			}
			else
			{
				chk_roughstockbox.Check = true;
				chk_roughstocksurface.Check = false;
			}
		}
		if (varParalelCutSettings != null)
		{
			spn_finishcuttingvel.Value = varParalelCutSettings.Speeds.Feed;
			spn_finishplungevel.Value = varParalelCutSettings.Speeds.Plunge;
			spn_finishrapiddis.Value = varParalelCutSettings.Distances.Rapid;
			spn_finishsafedistance.Value = varParalelCutSettings.Distances.Safe;
			spn_finishtoolpersentage.Value = varParalelCutSettings.Pockets.StepOverPersentage;
		}
		if (varContantZSettings != null)
		{
			spn_constantZcuttingvel.Value = varContantZSettings.Speeds.Feed;
			spn_constantZplungevel.Value = varContantZSettings.Speeds.Plunge;
			spn_constantZrapiddis.Value = varContantZSettings.Distances.Rapid;
			spn_constantZsafedis.Value = varContantZSettings.Distances.Safe;
			spn_constantZsteplen.Value = varContantZSettings.Steps.DepthStep;
		}
		if (varFlatlandSettings != null)
		{
			spn_flatlandcuttingvel.Value = varFlatlandSettings.Speeds.Feed;
			spn_flatlandplungevel.Value = varFlatlandSettings.Speeds.Plunge;
			spn_flatlandrapiddis.Value = varFlatlandSettings.Distances.Rapid;
			spn_flatlandsafedis.Value = varFlatlandSettings.Distances.Safe;
			spn_flatlandtoolpersentage.Value = varFlatlandSettings.Pockets.StepOverPersentage;
		}
		if (varPencilSettings != null)
		{
			spn_pencilcuttingvel.Value = varPencilSettings.Speeds.Feed;
			spn_pencilplungevel.Value = varPencilSettings.Speeds.Plunge;
			spn_pencilrapiddis.Value = varPencilSettings.Distances.Rapid;
			spn_pencilsafedis.Value = varPencilSettings.Distances.Safe;
		}
		Class186.smethod_426(this);
		PropertiesForm.Inited = true;
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
		PropertiesForm.Result = DialogResult.None;
		if (varRoughSettings != null)
		{
			spn_roughcuttingvel.Value = varRoughSettings.Speeds.Feed;
			spn_roughplungevel.Value = varRoughSettings.Speeds.Plunge;
			spn_roughrapiddistance.Value = varRoughSettings.Distances.Rapid;
			spn_roughsafedistance.Value = varRoughSettings.Distances.Safe;
			spn_roughsteplen.Value = varRoughSettings.Steps.DepthStep;
			spn_roughtoolpersentage.Value = varRoughSettings.Pockets.StepOverPersentage;
			chk_roughadaptive.Check = false;
			chk_roughparalel.Check = false;
			chk_roughoffset.Check = false;
			if (varRoughSettings.Pockets.PocketType != CamPocketType.WfbRghtOffset)
			{
				if (varRoughSettings.Pockets.PocketType != CamPocketType.WfbRghtAdaptive)
				{
					if (varRoughSettings.Pockets.PocketType == CamPocketType.WfbRghtParallel)
					{
						chk_roughparalel.Check = true;
					}
				}
				else
				{
					chk_roughadaptive.Check = true;
				}
			}
			else
			{
				chk_roughoffset.Check = true;
			}
			chk_roughsharpcorner.Check = varRoughSettings.Pockets.SharpCorner;
			chk_roughleadout.Check = varRoughSettings.Strategy.RoughLeadOut;
			chk_roughminimizelink.Check = varRoughSettings.Strategy.MinimizeLink;
			chk_roughremovecornerpeg.Check = varRoughSettings.Strategy.RemoveCornerPeg;
			chk_roughuseramp.Check = varRoughSettings.Strategy.MinimizeLink;
			spn_roughrampangle.Value = varRoughSettings.Strategy.RampAngle;
			spn_roughrampdia.Value = varRoughSettings.Strategy.RampMaxDiameterFromToolPerc;
			spn_roughstartheight.Value = varRoughSettings.Steps.StartValue;
			spn_roughendheight.Value = varRoughSettings.Steps.EndValue;
			if (varRoughSettings.Options.StockType != CamStockType.StSurfaces)
			{
				chk_roughstockbox.Check = false;
				chk_roughstocksurface.Check = true;
			}
			else
			{
				chk_roughstockbox.Check = true;
				chk_roughstocksurface.Check = false;
			}
		}
		if (varParalelCutSettings != null)
		{
			spn_finishcuttingvel.Value = varParalelCutSettings.Speeds.Feed;
			spn_finishplungevel.Value = varParalelCutSettings.Speeds.Plunge;
			spn_finishrapiddis.Value = varParalelCutSettings.Distances.Rapid;
			spn_finishsafedistance.Value = varParalelCutSettings.Distances.Safe;
			spn_finishtoolpersentage.Value = varParalelCutSettings.Pockets.StepOverPersentage;
		}
		if (varContantZSettings != null)
		{
			spn_constantZcuttingvel.Value = varContantZSettings.Speeds.Feed;
			spn_constantZplungevel.Value = varContantZSettings.Speeds.Plunge;
			spn_constantZrapiddis.Value = varContantZSettings.Distances.Rapid;
			spn_constantZsafedis.Value = varContantZSettings.Distances.Safe;
			spn_constantZsteplen.Value = varContantZSettings.Steps.DepthStep;
		}
		if (varFlatlandSettings != null)
		{
			spn_flatlandcuttingvel.Value = varFlatlandSettings.Speeds.Feed;
			spn_flatlandplungevel.Value = varFlatlandSettings.Speeds.Plunge;
			spn_flatlandrapiddis.Value = varFlatlandSettings.Distances.Rapid;
			spn_flatlandsafedis.Value = varFlatlandSettings.Distances.Safe;
			spn_flatlandtoolpersentage.Value = varFlatlandSettings.Pockets.StepOverPersentage;
		}
		if (varPencilSettings != null)
		{
			spn_pencilcuttingvel.Value = varPencilSettings.Speeds.Feed;
			spn_pencilplungevel.Value = varPencilSettings.Speeds.Plunge;
			spn_pencilrapiddis.Value = varPencilSettings.Distances.Rapid;
			spn_pencilsafedis.Value = varPencilSettings.Distances.Safe;
		}
		if (varPencilSettings == null)
		{
			for (int i = 0; i <= buTab_0.TabPages.Count - 1; i++)
			{
				if (buTab_0.TabPages[i].Name == tabPage_4.Name)
				{
					buTab_0.TabPages.RemoveAt(i);
				}
			}
		}
		if (varFlatlandSettings == null)
		{
			for (int j = 0; j <= buTab_0.TabPages.Count - 1; j++)
			{
				if (buTab_0.TabPages[j].Name == tabPage_3.Name)
				{
					buTab_0.TabPages.RemoveAt(j);
					break;
				}
			}
		}
		if (varContantZSettings == null)
		{
			for (int k = 0; k <= buTab_0.TabPages.Count - 1; k++)
			{
				if (buTab_0.TabPages[k].Name == tabPage_2.Name)
				{
					buTab_0.TabPages.RemoveAt(k);
					break;
				}
			}
		}
		if (varParalelCutSettings == null)
		{
			for (int l = 0; l <= buTab_0.TabPages.Count - 1; l++)
			{
				if (buTab_0.TabPages[l].Name == tabPage_1.Name)
				{
					buTab_0.TabPages.RemoveAt(l);
					break;
				}
			}
		}
		if (varRoughSettings == null)
		{
			for (int m = 0; m <= buTab_0.TabPages.Count - 1; m++)
			{
				if (buTab_0.TabPages[m].Name == tabPage_0.Name)
				{
					buTab_0.TabPages.RemoveAt(m);
					break;
				}
			}
		}
		if ((CamType == MarbleCamType.MillingRough3D) | (CamType == MarbleCamType.Rough3Plus2Front) | (CamType == MarbleCamType.Rough3Plus2Back))
		{
			for (int n = 0; n <= buTab_0.TabPages.Count - 1; n++)
			{
				if (buTab_0.TabPages[n].Name == tabPage_0.Name)
				{
					buTab_0.SelectedIndex = n;
					break;
				}
			}
			Class186.smethod_633(this, varRoughSettings);
		}
		if (CamType == MarbleCamType.MillingParallelCut3D)
		{
			for (int num = 0; num <= buTab_0.TabPages.Count - 1; num++)
			{
				if (buTab_0.TabPages[num].Name == tabPage_1.Name)
				{
					buTab_0.SelectedIndex = num;
					break;
				}
			}
			Class186.smethod_633(this, varParalelCutSettings);
		}
		if (CamType == MarbleCamType.MillingContantZ3D)
		{
			for (int num2 = 0; num2 <= buTab_0.TabPages.Count - 1; num2++)
			{
				if (buTab_0.TabPages[num2].Name == tabPage_2.Name)
				{
					buTab_0.SelectedIndex = num2;
					break;
				}
			}
			Class186.smethod_633(this, varContantZSettings);
		}
		if (CamType == MarbleCamType.MillingFlatland3D)
		{
			for (int num3 = 0; num3 <= buTab_0.TabPages.Count - 1; num3++)
			{
				if (buTab_0.TabPages[num3].Name == tabPage_3.Name)
				{
					buTab_0.SelectedIndex = num3;
					break;
				}
			}
			Class186.smethod_633(this, varFlatlandSettings);
		}
		if (CamType == MarbleCamType.MillingPencil3D)
		{
			for (int num4 = 0; num4 <= buTab_0.TabPages.Count - 1; num4++)
			{
				if (buTab_0.TabPages[num4].Name == tabPage_4.Name)
				{
					buTab_0.SelectedIndex = num4;
					break;
				}
			}
			Class186.smethod_633(this, varPencilSettings);
		}
		Class186.smethod_426(this);
		PropertiesForm.Inited = true;
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
			Control control = new Control();
			control = (Control)sender;
			if (!(control.Name == chk_zigzag.Name))
			{
				if (!(control.Name == chk_oneway.Name))
				{
					if (!(control.Name == chk_spiral.Name))
					{
						if (!(control.Name == chk_region.Name))
						{
							if (!(control.Name == chk_level.Name))
							{
								if (!(control.Name == chk_silhouettenone.Name))
								{
									if (!(control.Name == chk_silhouettepart.Name))
									{
										if (!(control.Name == chk_silhouettepartend.Name))
										{
											if (!(control.Name == chk_silhouettetoolcontact.Name))
											{
												if (!(control.Name == chk_roughadaptive.Name))
												{
													if (!(control.Name == chk_roughoffset.Name))
													{
														if (!(control.Name == chk_roughparalel.Name))
														{
															if (!(control.Name == chk_roughstockbox.Name))
															{
																if (!(control.Name == chk_roughstocksurface.Name))
																{
																	if (control.Name == btn_roughok.Name)
																	{
																		panel_0.Visible = false;
																	}
																	if (control.Name == btn_roughsettings.Name)
																	{
																		if (panel_0.Visible)
																		{
																			panel_0.Visible = false;
																		}
																		else
																		{
																			panel_0.Visible = true;
																		}
																	}
																	if (control.Name == btn_ok.Name)
																	{
																		Class186.smethod_390(this);
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
																	if ((control.Name == btn_cancel.Name) | (control.Name == btn_closecross.Name))
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
																	chk_roughstocksurface.Check = true;
																	chk_roughstockbox.Check = false;
																}
															}
															else
															{
																chk_roughstocksurface.Check = false;
																chk_roughstockbox.Check = true;
															}
														}
														else
														{
															chk_roughoffset.Check = false;
															chk_roughadaptive.Check = false;
															chk_roughparalel.Check = true;
														}
													}
													else
													{
														chk_roughoffset.Check = true;
														chk_roughadaptive.Check = false;
														chk_roughparalel.Check = false;
													}
												}
												else
												{
													chk_roughoffset.Check = false;
													chk_roughadaptive.Check = true;
													chk_roughparalel.Check = false;
												}
											}
											else
											{
												chk_silhouettenone.Check = false;
												chk_silhouettepart.Check = false;
												chk_silhouettepartend.Check = false;
												chk_silhouettetoolcontact.Check = true;
											}
										}
										else
										{
											chk_silhouettenone.Check = false;
											chk_silhouettepart.Check = false;
											chk_silhouettepartend.Check = true;
											chk_silhouettetoolcontact.Check = false;
										}
									}
									else
									{
										chk_silhouettenone.Check = false;
										chk_silhouettepart.Check = true;
										chk_silhouettepartend.Check = false;
										chk_silhouettetoolcontact.Check = false;
									}
								}
								else
								{
									chk_silhouettenone.Check = true;
									chk_silhouettepart.Check = false;
									chk_silhouettepartend.Check = false;
									chk_silhouettetoolcontact.Check = false;
								}
							}
							else
							{
								chk_region.Check = false;
								chk_level.Check = true;
							}
						}
						else
						{
							chk_region.Check = true;
							chk_level.Check = false;
						}
					}
					else
					{
						chk_oneway.Check = false;
						chk_roughadaptive.Check = false;
						chk_spiral.Check = true;
					}
				}
				else
				{
					chk_oneway.Check = true;
					chk_zigzag.Check = false;
					chk_spiral.Check = false;
				}
			}
			else
			{
				chk_oneway.Check = false;
				chk_zigzag.Check = true;
				chk_spiral.Check = false;
			}
		}
		catch (Exception)
		{
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		new Control();
		if (!PropertiesForm.Inited)
		{
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
	}

	internal void method_4(object sender, EventArgs e)
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
