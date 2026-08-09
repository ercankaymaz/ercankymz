using System;
using System.Drawing;
using buClass;
using buControls.Controls;

namespace buEyeBaseVer5;

[Serializable]
public class clsVisualVars
{
	public hmiUISettings hmiButtonMenu1 = new hmiUISettings();

	public hmiUISettings hmiButtonMenu2 = new hmiUISettings();

	public hmiUISettings hmiButtonMenu3 = new hmiUISettings();

	public hmiUISettings hmiButtonMenu4 = new hmiUISettings();

	public hmiUISettings hmiButtonCommand1 = new hmiUISettings();

	public hmiUISettings hmiButtonCommand2 = new hmiUISettings();

	public hmiUISettings hmiButtonCommand3 = new hmiUISettings();

	public hmiUISettings hmiButtonCommand4 = new hmiUISettings();

	public hmiUISettings hmiButtonSystem1 = new hmiUISettings();

	public hmiUISettings hmiButtonSystem2 = new hmiUISettings();

	public hmiUISettings hmiButtonSystem3 = new hmiUISettings();

	public hmiUISettings hmiButtonSystem4 = new hmiUISettings();

	public hmiUISettings hmiButtonOk = new hmiUISettings();

	public hmiUISettings hmiButtonCancel = new hmiUISettings();

	public hmiUISettings hmiSpin1 = new hmiUISettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.WhiteSmoke
		},
		Caption = new buControlDisplay
		{
			BackColor = Color.Orange
		},
		ButtonNormal = new buControlDisplay
		{
			BackColor = Color.Silver
		},
		ButtonOver = new buControlDisplay
		{
			BackColor = Color.Gray
		},
		ButtonDown = new buControlDisplay
		{
			BackColor = Color.Silver
		}
	};

	public hmiUISettings hmiSpin2 = new hmiUISettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.WhiteSmoke
		},
		Caption = new buControlDisplay
		{
			BackColor = Color.Orange
		},
		ButtonNormal = new buControlDisplay
		{
			BackColor = Color.Silver
		},
		ButtonOver = new buControlDisplay
		{
			BackColor = Color.Gray
		},
		ButtonDown = new buControlDisplay
		{
			BackColor = Color.Silver
		}
	};

	public hmiUISettings hmiSpin3 = new hmiUISettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.WhiteSmoke
		},
		Caption = new buControlDisplay
		{
			BackColor = Color.Orange
		},
		ButtonNormal = new buControlDisplay
		{
			BackColor = Color.Silver
		},
		ButtonOver = new buControlDisplay
		{
			BackColor = Color.Gray
		},
		ButtonDown = new buControlDisplay
		{
			BackColor = Color.Silver
		}
	};

	public hmiUISettings hmiSpin4 = new hmiUISettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.WhiteSmoke
		},
		Caption = new buControlDisplay
		{
			BackColor = Color.Orange
		},
		ButtonNormal = new buControlDisplay
		{
			BackColor = Color.Silver
		},
		ButtonOver = new buControlDisplay
		{
			BackColor = Color.Gray
		},
		ButtonDown = new buControlDisplay
		{
			BackColor = Color.Silver
		}
	};

	public hmiUISettings hmiText1 = new hmiUISettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.WhiteSmoke
		},
		Caption = new buControlDisplay
		{
			BackColor = Color.Orange
		}
	};

	public hmiUISettings hmiText2 = new hmiUISettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.WhiteSmoke
		},
		Caption = new buControlDisplay
		{
			BackColor = Color.Orange
		}
	};

	public hmiUISettings hmiText3 = new hmiUISettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.WhiteSmoke
		},
		Caption = new buControlDisplay
		{
			BackColor = Color.Orange
		}
	};

	public hmiUISettings hmiText4 = new hmiUISettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.WhiteSmoke
		},
		Caption = new buControlDisplay
		{
			BackColor = Color.Orange
		}
	};

	public hmiUISettings hmiCheck1 = new hmiUISettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.DarkOrange
		},
		Caption = new buControlDisplay
		{
			BackColor = Color.PaleGreen
		},
		ButtonNormal = new buControlDisplay
		{
			BackColor = Color.WhiteSmoke
		}
	};

	public hmiUISettings hmiCheck2 = new hmiUISettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.DarkOrange
		},
		Caption = new buControlDisplay
		{
			BackColor = Color.PaleGreen
		},
		ButtonNormal = new buControlDisplay
		{
			BackColor = Color.WhiteSmoke
		}
	};

	public hmiUISettings hmiCheck3 = new hmiUISettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.DarkOrange
		},
		Caption = new buControlDisplay
		{
			BackColor = Color.PaleGreen
		},
		ButtonNormal = new buControlDisplay
		{
			BackColor = Color.WhiteSmoke
		}
	};

	public hmiUISettings hmiCheck4 = new hmiUISettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.DarkOrange
		},
		Caption = new buControlDisplay
		{
			BackColor = Color.PaleGreen
		},
		ButtonNormal = new buControlDisplay
		{
			BackColor = Color.WhiteSmoke
		}
	};

	public hmiUISettings hmiLabel1 = new hmiUISettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.LightGray
		}
	};

	public hmiUISettings hmiLabel2 = new hmiUISettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.LightGray
		}
	};

	public hmiUISettings hmiLabel3 = new hmiUISettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.LightGray
		}
	};

	public hmiUISettings hmiLabel4 = new hmiUISettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.LightGray
		}
	};

	public hmiUISettings hmiListbox1 = new hmiUISettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.LightGray,
			SelectionColor = Color.LightBlue
		}
	};

	public hmiUISettings hmiListbox2 = new hmiUISettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.LightGray,
			SelectionColor = Color.LightBlue
		}
	};

	public hmiUISettings hmiListbox3 = new hmiUISettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.LightGray,
			SelectionColor = Color.LightBlue
		}
	};

	public hmiUISettings hmiListbox4 = new hmiUISettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.LightGray,
			SelectionColor = Color.LightBlue
		}
	};

	public hmiUIDataGridView hmiDGV1 = new hmiUIDataGridView();

	public hmiUIDataGridView hmiDGV2 = new hmiUIDataGridView();

	public hmiUISettings hmiRadioButton1 = new hmiUISettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.Transparent,
			Fonts = new buControlFont
			{
				ForeColor = Color.WhiteSmoke
			}
		}
	};

	public hmiUISettings hmiRadioButton2 = new hmiUISettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.Transparent,
			Fonts = new buControlFont
			{
				ForeColor = Color.WhiteSmoke
			}
		}
	};

	public hmiUISettings hmiRadioButton3 = new hmiUISettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.Transparent,
			Fonts = new buControlFont
			{
				ForeColor = Color.WhiteSmoke
			}
		}
	};

	public hmiUISettings hmiRadioButton4 = new hmiUISettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.Transparent,
			Fonts = new buControlFont
			{
				ForeColor = Color.WhiteSmoke
			}
		}
	};

	public hmiUISettings hmiTrack1 = new hmiUISettings();

	public hmiUISettings hmiTrack2 = new hmiUISettings();

	public hmiUISettings hmiProgress1 = new hmiUISettings();

	public hmiUISettings hmiProgress2 = new hmiUISettings();

	public hmiUISettings hmiGroup1 = new hmiUISettings();

	public hmiUISettings hmiGroup2 = new hmiUISettings();

	public hmiUISettings hmiPanel1 = new hmiUISettings();

	public hmiUISettings hmiPanel2 = new hmiUISettings();

	public hmiUISettings hmiGround1 = new hmiUISettings();

	public hmiUISettings hmiGround2 = new hmiUISettings();

	public hmiUISettings hmiCombo1 = new hmiUISettings();

	public hmiUISettings hmiCombo2 = new hmiUISettings();

	public hmiUISettings hmiCombo3 = new hmiUISettings();

	public hmiUISettings hmiCombo4 = new hmiUISettings();

	public hmiUIBasicSettings hmiOn1 = new hmiUIBasicSettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.GreenYellow,
			SelectionColor = Color.LightBlue
		}
	};

	public hmiUIBasicSettings hmiOff1 = new hmiUIBasicSettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.Tomato,
			SelectionColor = Color.LightBlue
		}
	};

	public hmiUIBasicSettings hmiOn2 = new hmiUIBasicSettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.GreenYellow,
			SelectionColor = Color.LightBlue
		}
	};

	public hmiUIBasicSettings hmiOff2 = new hmiUIBasicSettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.Tomato,
			SelectionColor = Color.LightBlue
		}
	};

	public hmiUIBasicSettings hmiWarning = new hmiUIBasicSettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.Gold,
			SelectionColor = Color.LightBlue
		}
	};

	public hmiUIBasicSettings hmiError = new hmiUIBasicSettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.Red,
			SelectionColor = Color.LightBlue
		}
	};

	public hmiUIBasicSettings hmiInfo = new hmiUIBasicSettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.LightBlue,
			SelectionColor = Color.LightBlue
		}
	};

	public hmiUIBasicSettings hmiStatus = new hmiUIBasicSettings
	{
		Display = new buControlDisplay
		{
			BackColor = Color.LightSteelBlue,
			SelectionColor = Color.LightBlue
		}
	};

	public hmiUISettings hmiPopup1GroundProps = new hmiUISettings();

	public hmiUISettings hmiPopup1GroundTopProps = new hmiUISettings();

	public hmiUISettings hmiPopup1GroundBottomProps = new hmiUISettings();

	public hmiUISettings hmiPopup1LabelsProps = new hmiUISettings();

	public hmiUISettings hmiPopup1TextProps = new hmiUISettings();

	public hmiUISettings hmiPopup1ButtonOk = new hmiUISettings();

	public hmiUISettings hmiPopup1ButtonCancel = new hmiUISettings();

	public hmiUISettings hmiCoords1 = new hmiUISettings();

	public hmiUISettings hmiCoords2 = new hmiUISettings();

	public hmiUISettings hmiSpeed1 = new hmiUISettings();

	public hmiUISettings hmiSpeedTrackSpindle1 = new hmiUISettings();

	public hmiUISettings hmiSpeedTrackSpindleDone1 = new hmiUISettings();

	public hmiUISettings hmiSpeedTrackSpindleDrawer1 = new hmiUISettings();

	public hmiUISettings hmiSpeedLabelSpindle1 = new hmiUISettings();

	public hmiUISettings hmiSpeedSpinSpindle1 = new hmiUISettings();

	public hmiUISettings hmiSpeedTrackSpindle2 = new hmiUISettings();

	public hmiUISettings hmiSpeedTrackSpindleDone2 = new hmiUISettings();

	public hmiUISettings hmiSpeedTrackSpindleDrawer2 = new hmiUISettings();

	public hmiUISettings hmiSpeedTrackFeed1 = new hmiUISettings();

	public hmiUISettings hmiSpeedTrackFeedDone1 = new hmiUISettings();

	public hmiUISettings hmiSpeedTrackFeedDrawer1 = new hmiUISettings();

	public hmiUISettings hmiSpeedFeedLabelProps = new hmiUISettings();

	public hmiUISettings hmiSpeedSpinsProps = new hmiUISettings();

	public Color colorDataFocus = Color.LightGreen;

	public LinearGradientBoolType colorLinearGradientEnableDisable = new LinearGradientBoolType();
}
