using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleMillingCamSetting : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public camParameters5 varRoughSettings = null;

	public camParameters5 varContourCutSettings = null;

	public camParameters5 varCenterSettings = null;

	public camParameters5 varFaceSettings = null;

	public camParameters5 varFloorFinishSettings = null;

	public camParameters5 varChamferSettings = null;

	public camParameters5 varEngraveSettings = null;

	public camParameters5 varTextEngraveSettings = null;

	public camParameters5 varTrochoidalSettings = null;

	public CamWireFrameType CamType = CamWireFrameType.Pocket;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal buGround buGround_0;

	public buSpin spn_roughcuttingvel;

	public buSpin spn_roughplungevel;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal buButton buButton_0;

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

	public buSpin spn_contoursafedistance;

	public buSpin spn_contourrapiddis;

	public buSpin spn_contourplungevel;

	public buSpin spn_contourcuttingvel;

	internal buLabel buLabel_2;

	public buSpin spn_centersafedis;

	public buSpin spn_centerrapiddis;

	public buSpin spn_centerplungevel;

	public buSpin spn_centercuttingvel;

	internal buLabel buLabel_3;

	public buSpin spn_facesafedis;

	public buSpin spn_facerapiddis;

	public buSpin spn_faceplungevel;

	public buSpin spn_facecuttingvel;

	internal buLabel buLabel_4;

	public buSpin spn_floorfinishsafedis;

	public buSpin spn_floorfinishrapiddis;

	public buSpin spn_floorfinishplungevel;

	public buSpin spn_floorfinishcuttingvel;

	internal TabPage tabPage_5;

	internal TabPage tabPage_6;

	internal TabPage tabPage_7;

	internal TabPage tabPage_8;

	internal buLabel buLabel_5;

	public buSpin spn_chamfersafedis;

	public buSpin spn_chamferrapiddis;

	public buSpin spn_chamferplungevel;

	public buSpin spn_chamfercuttingvel;

	internal buLabel buLabel_6;

	public buSpin spn_engravesafedis;

	public buSpin spn_engraverapiddis;

	public buSpin spn_engraveplungevel;

	public buSpin spn_engravecuttingvel;

	internal buLabel buLabel_7;

	public buSpin spn_textengravesafedis;

	public buSpin spn_textengraverapiddis;

	public buSpin spn_textengraveplungevel;

	public buSpin spn_textengravecuttingvel;

	internal buLabel buLabel_8;

	public buSpin spn_trochoidalsafedis;

	public buSpin spn_trochoidalrapiddis;

	public buSpin spn_trochoidalplungevel;

	public buSpin spn_trochoidalcuttingvel;

	public buSpin spn_contoursteplen;

	public buSpin spn_centersteplen;

	public buCheckBox chk_contouroffsetcenter;

	public buCheckBox chk_contouroffsetoutside;

	public buCheckBox chk_contouroffsetinside;

	internal buLabel buLabel_9;

	public buSpin spn_roughtoolpersentage;

	internal buLabel buLabel_10;

	internal buLabel buLabel_11;

	public buCheckBox chk_spiral;

	public buCheckBox chk_zigzag;

	public buCheckBox chk_oneway;

	public buCheckBox chk_level;

	public buCheckBox chk_region;

	public F_MarbleMillingCamSetting()
	{
		Class186.smethod_625(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		if (Properties.Height > 10)
		{
			base.Height = Properties.Height;
		}
		if (Properties.Width > 10)
		{
			base.Width = Properties.Width;
		}
		base.TopMost = Properties.TopMost;
		base.StartPosition = Properties.FormPosition;
		Properties.Result = DialogResult.None;
		if (varRoughSettings != null)
		{
			spn_roughcuttingvel.Value = varRoughSettings.Speeds.Feed;
			spn_roughplungevel.Value = varRoughSettings.Speeds.Plunge;
			spn_roughrapiddistance.Value = varRoughSettings.Distances.Rapid;
			spn_roughsafedistance.Value = varRoughSettings.Distances.Safe;
			spn_roughsteplen.Value = varRoughSettings.Steps.DepthStep;
			spn_roughtoolpersentage.Value = varRoughSettings.Pockets.StepOverPersentage;
		}
		if (varContourCutSettings != null)
		{
			spn_contourcuttingvel.Value = varContourCutSettings.Speeds.Feed;
			spn_contourplungevel.Value = varContourCutSettings.Speeds.Plunge;
			spn_contourrapiddis.Value = varContourCutSettings.Distances.Rapid;
			spn_contoursafedistance.Value = varContourCutSettings.Distances.Safe;
			spn_contoursteplen.Value = varContourCutSettings.Steps.DepthStep;
			chk_contouroffsetcenter.Check = false;
			chk_contouroffsetinside.Check = false;
			chk_contouroffsetoutside.Check = false;
			if (varContourCutSettings.Offsets.ClosedContour != CamClosedContourType.Center)
			{
				if (varContourCutSettings.Offsets.ClosedContour != CamClosedContourType.Inner)
				{
					chk_contouroffsetoutside.Check = true;
				}
				else
				{
					chk_contouroffsetinside.Check = true;
				}
			}
			else
			{
				chk_contouroffsetcenter.Check = true;
			}
		}
		if (varCenterSettings != null)
		{
			spn_centercuttingvel.Value = varCenterSettings.Speeds.Feed;
			spn_centerplungevel.Value = varCenterSettings.Speeds.Plunge;
			spn_centerrapiddis.Value = varCenterSettings.Distances.Rapid;
			spn_centersafedis.Value = varCenterSettings.Distances.Safe;
			spn_centersteplen.Value = varCenterSettings.Steps.DepthStep;
		}
		if (varFaceSettings != null)
		{
			spn_facecuttingvel.Value = varFaceSettings.Speeds.Feed;
			spn_faceplungevel.Value = varFaceSettings.Speeds.Plunge;
			spn_facerapiddis.Value = varFaceSettings.Distances.Rapid;
			spn_facesafedis.Value = varFaceSettings.Distances.Safe;
		}
		if (varFloorFinishSettings != null)
		{
			spn_floorfinishcuttingvel.Value = varFloorFinishSettings.Speeds.Feed;
			spn_floorfinishplungevel.Value = varFloorFinishSettings.Speeds.Plunge;
			spn_floorfinishrapiddis.Value = varFloorFinishSettings.Distances.Rapid;
			spn_floorfinishsafedis.Value = varFloorFinishSettings.Distances.Safe;
		}
		if (varChamferSettings != null)
		{
			spn_chamfercuttingvel.Value = varChamferSettings.Speeds.Feed;
			spn_chamferplungevel.Value = varChamferSettings.Speeds.Plunge;
			spn_chamferrapiddis.Value = varChamferSettings.Distances.Rapid;
			spn_chamfersafedis.Value = varChamferSettings.Distances.Safe;
		}
		if (varEngraveSettings != null)
		{
			spn_engravecuttingvel.Value = varEngraveSettings.Speeds.Feed;
			spn_engraveplungevel.Value = varEngraveSettings.Speeds.Plunge;
			spn_engraverapiddis.Value = varEngraveSettings.Distances.Rapid;
			spn_engravesafedis.Value = varEngraveSettings.Distances.Safe;
		}
		if (varTextEngraveSettings != null)
		{
			spn_textengravecuttingvel.Value = varTextEngraveSettings.Speeds.Feed;
			spn_textengraveplungevel.Value = varTextEngraveSettings.Speeds.Plunge;
			spn_textengraverapiddis.Value = varTextEngraveSettings.Distances.Rapid;
			spn_textengravesafedis.Value = varTextEngraveSettings.Distances.Safe;
		}
		if (varTrochoidalSettings != null)
		{
			spn_trochoidalcuttingvel.Value = varTrochoidalSettings.Speeds.Feed;
			spn_trochoidalplungevel.Value = varTrochoidalSettings.Speeds.Plunge;
			spn_trochoidalrapiddis.Value = varTrochoidalSettings.Distances.Rapid;
			spn_trochoidalsafedis.Value = varTrochoidalSettings.Distances.Safe;
		}
		if (varTrochoidalSettings == null)
		{
			for (int i = 0; i <= buTab_0.TabPages.Count - 1; i++)
			{
				if (buTab_0.TabPages[i].Name == tabPage_8.Name)
				{
					buTab_0.TabPages.RemoveAt(i);
				}
			}
		}
		if (varTextEngraveSettings == null)
		{
			for (int j = 0; j <= buTab_0.TabPages.Count - 1; j++)
			{
				if (buTab_0.TabPages[j].Name == tabPage_7.Name)
				{
					buTab_0.TabPages.RemoveAt(j);
					break;
				}
			}
		}
		if (varEngraveSettings == null)
		{
			for (int k = 0; k <= buTab_0.TabPages.Count - 1; k++)
			{
				if (buTab_0.TabPages[k].Name == tabPage_6.Name)
				{
					buTab_0.TabPages.RemoveAt(k);
					break;
				}
			}
		}
		if (varChamferSettings == null)
		{
			for (int l = 0; l <= buTab_0.TabPages.Count - 1; l++)
			{
				if (buTab_0.TabPages[l].Name == tabPage_5.Name)
				{
					buTab_0.TabPages.RemoveAt(l);
					break;
				}
			}
		}
		if (varFloorFinishSettings == null)
		{
			for (int m = 0; m <= buTab_0.TabPages.Count - 1; m++)
			{
				if (buTab_0.TabPages[m].Name == tabPage_4.Name)
				{
					buTab_0.TabPages.RemoveAt(m);
					break;
				}
			}
		}
		if (varFaceSettings == null)
		{
			for (int n = 0; n <= buTab_0.TabPages.Count - 1; n++)
			{
				if (buTab_0.TabPages[n].Name == tabPage_3.Name)
				{
					buTab_0.TabPages.RemoveAt(n);
					break;
				}
			}
		}
		if (varCenterSettings == null)
		{
			for (int num = 0; num <= buTab_0.TabPages.Count - 1; num++)
			{
				if (buTab_0.TabPages[num].Name == tabPage_2.Name)
				{
					buTab_0.TabPages.RemoveAt(num);
					break;
				}
			}
		}
		if (varContourCutSettings == null)
		{
			for (int num2 = 0; num2 <= buTab_0.TabPages.Count - 1; num2++)
			{
				if (buTab_0.TabPages[num2].Name == tabPage_1.Name)
				{
					buTab_0.TabPages.RemoveAt(num2);
					break;
				}
			}
		}
		if (varRoughSettings == null)
		{
			for (int num3 = 0; num3 <= buTab_0.TabPages.Count - 1; num3++)
			{
				if (buTab_0.TabPages[num3].Name == tabPage_0.Name)
				{
					buTab_0.TabPages.RemoveAt(num3);
					break;
				}
			}
		}
		if (CamType == CamWireFrameType.Pocket)
		{
			for (int num4 = 0; num4 <= buTab_0.TabPages.Count - 1; num4++)
			{
				if (buTab_0.TabPages[num4].Name == tabPage_0.Name)
				{
					buTab_0.SelectedIndex = num4;
					break;
				}
			}
			Class186.smethod_557(this, varRoughSettings);
		}
		if (CamType == CamWireFrameType.Contour)
		{
			for (int num5 = 0; num5 <= buTab_0.TabPages.Count - 1; num5++)
			{
				if (buTab_0.TabPages[num5].Name == tabPage_1.Name)
				{
					buTab_0.SelectedIndex = num5;
					break;
				}
			}
			Class186.smethod_557(this, varContourCutSettings);
		}
		if (CamType == CamWireFrameType.CenterPath)
		{
			for (int num6 = 0; num6 <= buTab_0.TabPages.Count - 1; num6++)
			{
				if (buTab_0.TabPages[num6].Name == tabPage_2.Name)
				{
					buTab_0.SelectedIndex = num6;
					break;
				}
			}
			Class186.smethod_557(this, varCenterSettings);
		}
		if (CamType == CamWireFrameType.Face)
		{
			for (int num7 = 0; num7 <= buTab_0.TabPages.Count - 1; num7++)
			{
				if (buTab_0.TabPages[num7].Name == tabPage_3.Name)
				{
					buTab_0.SelectedIndex = num7;
					break;
				}
			}
			Class186.smethod_557(this, varFaceSettings);
		}
		if (CamType == CamWireFrameType.FloorFinish)
		{
			for (int num8 = 0; num8 <= buTab_0.TabPages.Count - 1; num8++)
			{
				if (buTab_0.TabPages[num8].Name == tabPage_4.Name)
				{
					buTab_0.SelectedIndex = num8;
					break;
				}
			}
			Class186.smethod_557(this, varFloorFinishSettings);
		}
		if (CamType == CamWireFrameType.Chamfer2D)
		{
			for (int num9 = 0; num9 <= buTab_0.TabPages.Count - 1; num9++)
			{
				if (buTab_0.TabPages[num9].Name == tabPage_5.Name)
				{
					buTab_0.SelectedIndex = num9;
					break;
				}
			}
			Class186.smethod_557(this, varChamferSettings);
		}
		if (CamType == CamWireFrameType.Engrave)
		{
			for (int num10 = 0; num10 <= buTab_0.TabPages.Count - 1; num10++)
			{
				if (buTab_0.TabPages[num10].Name == tabPage_6.Name)
				{
					buTab_0.SelectedIndex = num10;
					break;
				}
			}
			Class186.smethod_557(this, varEngraveSettings);
		}
		if (CamType == CamWireFrameType.TextEngrave)
		{
			for (int num11 = 0; num11 <= buTab_0.TabPages.Count - 1; num11++)
			{
				if (buTab_0.TabPages[num11].Name == tabPage_7.Name)
				{
					buTab_0.SelectedIndex = num11;
					break;
				}
			}
			Class186.smethod_557(this, varTextEngraveSettings);
		}
		if (CamType == CamWireFrameType.Trochoidal)
		{
			for (int num12 = 0; num12 <= buTab_0.TabPages.Count - 1; num12++)
			{
				if (buTab_0.TabPages[num12].Name == tabPage_8.Name)
				{
					buTab_0.SelectedIndex = num12;
					break;
				}
			}
			Class186.smethod_557(this, varTrochoidalSettings);
		}
		Class186.smethod_614(this);
		Properties.Inited = true;
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (Properties.Result != DialogResult.OK)
		{
			e.Cancel = true;
			Properties.Result = DialogResult.Cancel;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
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
			if (!(control.Name == chk_contouroffsetcenter.Name))
			{
				if (!(control.Name == chk_contouroffsetinside.Name))
				{
					if (!(control.Name == chk_contouroffsetoutside.Name))
					{
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
											if (control.Name == btn_ok.Name)
											{
												Class186.smethod_444(this);
												Properties.Result = DialogResult.OK;
												if (Properties.FormCloseMode == FormCloseModeType.Dispose)
												{
													Dispose();
												}
												if (Properties.FormCloseMode == FormCloseModeType.Invisible)
												{
													base.Visible = false;
												}
											}
											if ((control.Name == btn_cancel.Name) | (control.Name == buButton_0.Name))
											{
												Properties.Result = DialogResult.Cancel;
												if (Properties.FormCloseMode == FormCloseModeType.Dispose)
												{
													Dispose();
												}
												if (Properties.FormCloseMode == FormCloseModeType.Invisible)
												{
													base.Visible = false;
												}
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
									chk_zigzag.Check = false;
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
					else
					{
						chk_contouroffsetinside.Check = false;
						chk_contouroffsetoutside.Check = true;
						chk_contouroffsetcenter.Check = false;
					}
				}
				else
				{
					chk_contouroffsetinside.Check = true;
					chk_contouroffsetoutside.Check = false;
					chk_contouroffsetcenter.Check = false;
				}
			}
			else
			{
				chk_contouroffsetinside.Check = false;
				chk_contouroffsetoutside.Check = false;
				chk_contouroffsetcenter.Check = true;
			}
		}
		catch (Exception)
		{
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
	}

	internal void method_3(object sender, EventArgs e)
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
