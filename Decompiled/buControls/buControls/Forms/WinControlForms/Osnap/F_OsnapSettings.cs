using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Osnap;

public class F_OsnapSettings : Form
{
	public static List<string> Captions = new List<string>();

	public OsnapProps OsnapSettings = new OsnapProps();

	public DialogResult Result = DialogResult.None;

	private IContainer icontainer_0 = null;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal Panel panel_0;

	internal CheckBox checkBox_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_1;

	internal Label label_2;

	internal NumericUpDown numericUpDown_2;

	internal Label label_3;

	internal Panel panel_1;

	internal CheckBox checkBox_1;

	internal Label label_4;

	internal NumericUpDown numericUpDown_3;

	internal Label label_5;

	internal CheckBox checkBox_2;

	internal CheckBox checkBox_3;

	internal CheckBox checkBox_4;

	internal CheckBox checkBox_5;

	internal CheckBox checkBox_6;

	internal CheckBox checkBox_7;

	internal CheckBox checkBox_8;

	internal CheckBox checkBox_9;

	internal Panel panel_2;

	internal NumericUpDown numericUpDown_4;

	internal Label label_6;

	internal CheckBox checkBox_10;

	internal Label label_7;

	internal Panel panel_3;

	internal NumericUpDown numericUpDown_5;

	internal Label label_8;

	internal CheckBox checkBox_11;

	internal Label label_9;

	internal NumericUpDown numericUpDown_6;

	internal Label label_10;

	internal Panel panel_4;

	internal NumericUpDown numericUpDown_7;

	internal Label label_11;

	internal CheckBox checkBox_12;

	internal Label label_12;

	internal Panel panel_5;

	internal NumericUpDown numericUpDown_8;

	internal Label label_13;

	internal CheckBox checkBox_13;

	internal Label label_14;

	internal CheckBox checkBox_14;

	internal Panel panel_6;

	internal NumericUpDown numericUpDown_9;

	internal Label label_15;

	internal CheckBox checkBox_15;

	internal Label label_16;

	public F_OsnapSettings()
	{
		Class76.smethod_526(this);
	}

	public void Init()
	{
		Result = DialogResult.None;
		checkBox_0.Checked = OsnapSettings.Snap;
		numericUpDown_0.Value = (decimal)OsnapSettings.SnapDistance.X;
		numericUpDown_2.Value = (decimal)OsnapSettings.SnapDistance.Y;
		numericUpDown_1.Value = (decimal)OsnapSettings.SnapDistance.Z;
		checkBox_11.Checked = OsnapSettings.Track;
		numericUpDown_5.Value = (decimal)OsnapSettings.TrackPerpendicularAngleLimit;
		numericUpDown_6.Value = OsnapSettings.TrackCatchTime;
		checkBox_10.Checked = OsnapSettings.Over;
		numericUpDown_4.Value = (decimal)OsnapSettings.OverResolution;
		checkBox_13.Checked = OsnapSettings.LimitedDistance;
		numericUpDown_8.Value = (decimal)OsnapSettings.LimitedValue;
		checkBox_12.Checked = OsnapSettings.ConstantPlaneEnable;
		numericUpDown_7.Value = (decimal)OsnapSettings.ConstantPlaneHeight;
		checkBox_15.Checked = OsnapSettings.OrthoAuto;
		numericUpDown_9.Value = (decimal)OsnapSettings.OrthoAutoAngle;
		checkBox_1.Checked = OsnapSettings.Osnap;
		checkBox_8.Checked = OsnapSettings.OsnapPoint;
		checkBox_7.Checked = OsnapSettings.OsnapMiddle;
		checkBox_6.Checked = OsnapSettings.OsnapCenter;
		checkBox_5.Checked = OsnapSettings.OsnapOutside;
		checkBox_2.Checked = OsnapSettings.OsnapZeroPoint;
		checkBox_4.Checked = OsnapSettings.OsnapIntersection;
		checkBox_3.Checked = OsnapSettings.OsnapBoxSize;
		checkBox_9.Checked = OsnapSettings.OsnapControlPoints;
		checkBox_14.Checked = OsnapSettings.OsnapVertice;
		numericUpDown_3.Value = (decimal)OsnapSettings.CatchResolution;
		LoadLangueage();
	}

	public void LoadLangueage()
	{
		string callMethod = "OsnapSettings LoadLanguage";
		try
		{
			if (Captions.Count >= 24)
			{
				Text = Captions[0];
				label_1.Text = Captions[1];
				label_7.Text = Captions[2];
				label_6.Text = Captions[3];
				label_9.Text = Captions[4];
				label_8.Text = Captions[5];
				label_10.Text = Captions[6];
				label_12.Text = Captions[7];
				label_11.Text = Captions[8];
				label_14.Text = Captions[9];
				label_13.Text = Captions[10];
				label_4.Text = Captions[11];
				label_5.Text = Captions[12];
				checkBox_8.Text = Captions[13];
				checkBox_7.Text = Captions[14];
				checkBox_6.Text = Captions[15];
				checkBox_5.Text = Captions[16];
				checkBox_4.Text = Captions[17];
				checkBox_3.Text = Captions[18];
				checkBox_2.Text = Captions[19];
				checkBox_9.Text = Captions[20];
				checkBox_14.Text = Captions[21];
				btn_ok.Text = Captions[22];
				btn_cancel.Text = Captions[23];
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	internal void method_0(object sender, EventArgs e)
	{
		OsnapSettings.Snap = checkBox_0.Checked;
		OsnapSettings.SnapDistance.X = (double)numericUpDown_0.Value;
		OsnapSettings.SnapDistance.Y = (double)numericUpDown_2.Value;
		OsnapSettings.SnapDistance.Z = (double)numericUpDown_1.Value;
		OsnapSettings.Track = checkBox_11.Checked;
		OsnapSettings.TrackPerpendicularAngleLimit = (double)numericUpDown_5.Value;
		OsnapSettings.TrackCatchTime = (int)numericUpDown_6.Value;
		OsnapSettings.Over = checkBox_10.Checked;
		OsnapSettings.OverResolution = (double)numericUpDown_4.Value;
		OsnapSettings.LimitedDistance = checkBox_13.Checked;
		OsnapSettings.LimitedValue = (double)numericUpDown_8.Value;
		OsnapSettings.ConstantPlaneEnable = checkBox_12.Checked;
		OsnapSettings.ConstantPlaneHeight = (double)numericUpDown_7.Value;
		OsnapSettings.OrthoAuto = checkBox_15.Checked;
		OsnapSettings.OrthoAutoAngle = (double)numericUpDown_9.Value;
		OsnapSettings.Osnap = checkBox_1.Checked;
		OsnapSettings.OsnapPoint = checkBox_8.Checked;
		OsnapSettings.OsnapMiddle = checkBox_7.Checked;
		OsnapSettings.OsnapCenter = checkBox_6.Checked;
		OsnapSettings.OsnapOutside = checkBox_5.Checked;
		OsnapSettings.OsnapZeroPoint = checkBox_2.Checked;
		OsnapSettings.OsnapIntersection = checkBox_4.Checked;
		OsnapSettings.OsnapBoxSize = checkBox_3.Checked;
		OsnapSettings.OsnapControlPoints = checkBox_9.Checked;
		OsnapSettings.OsnapVertice = checkBox_14.Checked;
		OsnapSettings.CatchResolution = (double)numericUpDown_3.Value;
		Result = DialogResult.OK;
		Dispose();
	}

	internal void method_1(object sender, EventArgs e)
	{
		Result = DialogResult.Cancel;
		Dispose();
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
