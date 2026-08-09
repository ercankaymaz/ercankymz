using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.buEntities;
using ns71;

namespace buEyeBaseVer5.Forms.Holes;

public class F_MirrorOP : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public buShape Shape = null;

	public MirrorBoxType MirrorType = MirrorBoxType.Plane;

	public planeBoxNames newPlane = planeBoxNames.Top;

	public CornerLocation newCorner = CornerLocation.BottomCenter;

	private CornerLocation cornerLocation_0 = CornerLocation.BottomCenter;

	private CornerLocation cornerLocation_1 = CornerLocation.BottomCenter;

	public bool CopyAsNew = false;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal ImageList imageList_1;

	internal Panel panel_0;

	public Button btn_oldplane;

	internal PictureBox pictureBox_0;

	internal PictureBox pictureBox_1;

	public Button btn_oldver;

	public Button btn_newver;

	public Button btn_oldhor;

	public Button btn_newhor;

	public Button btn_newplane;

	public RadioButton radio_vertical;

	public RadioButton radio_horizontal;

	public RadioButton radio_plane;

	public CheckBox chk_copynew;

	internal Button button_0;

	internal Button button_1;

	internal Button button_2;

	public F_MirrorOP()
	{
		Class186.smethod_267(this);
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
		ControlUpdate();
		LoadLanguage();
		btn_oldver.Enabled = true;
		btn_newver.Enabled = true;
		radio_vertical.Enabled = true;
		radio_horizontal.Enabled = true;
		if (MirrorType == MirrorBoxType.Plane)
		{
			radio_plane.Checked = true;
		}
		if (MirrorType == MirrorBoxType.Horizotal)
		{
			radio_horizontal.Checked = true;
		}
		if (MirrorType == MirrorBoxType.Vertical)
		{
			radio_vertical.Checked = true;
		}
		chk_copynew.Checked = CopyAsNew;
		if (Shape != null)
		{
			if (Shape.planeName == planeBoxNames.Top)
			{
				btn_oldplane.ImageIndex = 0;
				btn_newplane.ImageIndex = 1;
				newPlane = planeBoxNames.Bottom;
			}
			if (Shape.planeName == planeBoxNames.Bottom)
			{
				btn_oldplane.ImageIndex = 1;
				btn_newplane.ImageIndex = 0;
				newPlane = planeBoxNames.Top;
			}
			if (Shape.planeName == planeBoxNames.Front)
			{
				btn_oldplane.ImageIndex = 2;
				btn_newplane.ImageIndex = 3;
				newPlane = planeBoxNames.Back;
			}
			if (Shape.planeName == planeBoxNames.Back)
			{
				btn_oldplane.ImageIndex = 3;
				btn_newplane.ImageIndex = 2;
				newPlane = planeBoxNames.Front;
			}
			if (Shape.planeName == planeBoxNames.Left)
			{
				btn_oldplane.ImageIndex = 4;
				btn_newplane.ImageIndex = 5;
				newPlane = planeBoxNames.Right;
			}
			if (Shape.planeName == planeBoxNames.Right)
			{
				btn_oldplane.ImageIndex = 5;
				btn_newplane.ImageIndex = 4;
				newPlane = planeBoxNames.Left;
			}
			if (Shape.Corner == CornerLocation.TopCenter)
			{
				btn_oldhor.ImageIndex = -1;
				btn_newhor.ImageIndex = -1;
				btn_oldver.ImageIndex = 6;
				btn_newver.ImageIndex = 7;
				btn_oldhor.Enabled = false;
				btn_newhor.Enabled = false;
				radio_horizontal.Enabled = false;
				radio_vertical.Checked = true;
				cornerLocation_1 = CornerLocation.BottomCenter;
			}
			if (Shape.Corner == CornerLocation.BottomCenter)
			{
				btn_oldhor.ImageIndex = -1;
				btn_newhor.ImageIndex = -1;
				btn_oldver.ImageIndex = 7;
				btn_newver.ImageIndex = 6;
				btn_oldhor.Enabled = false;
				btn_newhor.Enabled = false;
				radio_horizontal.Enabled = false;
				radio_vertical.Checked = true;
				cornerLocation_1 = CornerLocation.TopCenter;
			}
			if (Shape.Corner == CornerLocation.LeftCenter)
			{
				btn_oldhor.ImageIndex = 8;
				btn_newhor.ImageIndex = 9;
				btn_oldver.ImageIndex = -1;
				btn_newver.ImageIndex = -1;
				btn_oldver.Enabled = false;
				btn_newver.Enabled = false;
				radio_vertical.Enabled = false;
				radio_horizontal.Checked = true;
				cornerLocation_0 = CornerLocation.RightCenter;
			}
			if (Shape.Corner == CornerLocation.RightCenter)
			{
				btn_oldhor.ImageIndex = 9;
				btn_newhor.ImageIndex = 8;
				btn_oldver.ImageIndex = -1;
				btn_newver.ImageIndex = -1;
				btn_oldver.Enabled = false;
				btn_newver.Enabled = false;
				radio_vertical.Enabled = false;
				radio_horizontal.Checked = true;
				cornerLocation_0 = CornerLocation.LeftCenter;
			}
			if (Shape.Corner == CornerLocation.RightTop)
			{
				btn_oldhor.ImageIndex = 13;
				btn_newhor.ImageIndex = 12;
				btn_oldver.ImageIndex = 13;
				btn_newver.ImageIndex = 11;
				cornerLocation_1 = CornerLocation.RightBottom;
				cornerLocation_0 = CornerLocation.LeftTop;
			}
			if (Shape.Corner == CornerLocation.RightBottom)
			{
				btn_oldhor.ImageIndex = 11;
				btn_newhor.ImageIndex = 12;
				btn_oldver.ImageIndex = 11;
				btn_newver.ImageIndex = 10;
				cornerLocation_1 = CornerLocation.RightTop;
				cornerLocation_0 = CornerLocation.LeftBottom;
			}
			if (Shape.Corner == CornerLocation.LeftTop)
			{
				btn_oldhor.ImageIndex = 12;
				btn_newhor.ImageIndex = 13;
				btn_oldver.ImageIndex = 12;
				btn_newver.ImageIndex = 10;
				cornerLocation_1 = CornerLocation.LeftBottom;
				cornerLocation_0 = CornerLocation.RightTop;
			}
			if (Shape.Corner == CornerLocation.LeftBottom)
			{
				btn_oldhor.ImageIndex = 10;
				btn_newhor.ImageIndex = 11;
				btn_oldver.ImageIndex = 10;
				btn_newver.ImageIndex = 12;
				cornerLocation_1 = CornerLocation.LeftTop;
				cornerLocation_0 = CornerLocation.RightBottom;
			}
		}
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		string callMethod = "LoadLanguage";
		try
		{
			Text = buLangTranslate.preDef.Mirror;
			radio_horizontal.Text = buLangTranslate.preDef.Horizontal;
			radio_plane.Text = buLangTranslate.preDef.Plane;
			radio_vertical.Text = buLangTranslate.preDef.Vertical;
			btn_cancel.Text = buLangTranslate.preDef.Cancel;
			btn_ok.Text = buLangTranslate.preDef.Ok;
			chk_copynew.Text = buLangTranslate.preDef.Copy + " " + buLangTranslate.preDef.New;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	public void ControlUpdate()
	{
	}

	public void Apply()
	{
		if (!radio_plane.Checked)
		{
			if (!radio_horizontal.Checked)
			{
				if (radio_vertical.Checked)
				{
					MirrorType = MirrorBoxType.Vertical;
					newCorner = cornerLocation_1;
				}
			}
			else
			{
				MirrorType = MirrorBoxType.Horizotal;
				newCorner = cornerLocation_0;
			}
		}
		else
		{
			MirrorType = MirrorBoxType.Plane;
		}
		CopyAsNew = chk_copynew.Checked;
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
		Control control = new Control();
		control = (Control)sender;
		if (!(control.Name == btn_ok.Name))
		{
			if (control.Name == btn_cancel.Name)
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
			Apply();
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
