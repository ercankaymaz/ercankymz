using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buCore;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

public class buProfileCalc
{
	public static string sClass = "buProfileCalc";

	public static ProfileSettings varProfileSettings = new ProfileSettings();

	public static ProfileVisualSettings varProfileVisualSettings = new ProfileVisualSettings();

	public static ProfileRuntimeSettings varProfileRunSettings = new ProfileRuntimeSettings();

	public static UCSObjectData varUCSData = new UCSObjectData();

	public static ProfileTempVars varTemps = new ProfileTempVars();

	public static ProfileClamperSettings varProfileClamperSettings = new ProfileClamperSettings();

	public static string UnlockString = "";

	public buProfileCalc()
	{
		if (!buVector5.smethod_0("buProfile"))
		{
			throw new RegisterException("buProfile");
		}
	}

	public static string ProfileToString(ProfileItem Profile)
	{
		string text = "";
		if (Profile.ItemName.Trim().Length > 0)
		{
			text = Profile.ItemName.Trim();
		}
		text = ((text.Length > 0) ? (text + "- " + buLangTranslate.preChar.Length + ": " + Profile.Length) : (buLangTranslate.preChar.Length + ": " + Profile.Length));
		text = text + " - " + buLangTranslate.preChar.Width + ": " + (Profile.ProfileMaxPoint.Y - Profile.ProfileMinPoint.Y).ToString("f1") + " - " + buLangTranslate.preChar.Height + ": " + Profile.ProfileMaxPoint.Z.ToString("f1");
		if (Profile.XReferanceLocation != LeftRightType.Left)
		{
			return text + " - " + buLangTranslate.preDef.Right;
		}
		return text + " - " + buLangTranslate.preDef.Left;
	}

	public static string OperationItemString(ProfileOperation Op, string charPriority = "P")
	{
		string text = "";
		string result = "";
		string text2 = "";
		if (Op.Priority != 0)
		{
			text2 = " - " + charPriority + ": " + Op.Priority;
		}
		string text3 = " | " + Op.OperationData.selectedPlaneName.ToString() + " , X: " + Op.OperationData.Position.X.ToString("f1") + " - " + Op.OperationData.selectedPlaneName;
		if (Op.OperationData.OperationType == ProfileOperationTypes.Circle)
		{
			result = AppLanguage.CadCamDynamic[51] + text2 + text3 + " - Dia: " + AppLanguage.CadCamDynamic[57] + Op.OperationData.CircleData.CircleDiameter.ToString("f1");
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.Rectangle)
		{
			result = AppLanguage.CadCamDynamic[62] + text2 + text3 + " - W: " + Op.OperationData.RectangleData.RectangleWidth.ToString("f1") + " , H: " + Op.OperationData.RectangleData.RectangleHeight.ToString("f1");
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.RoundRectangle)
		{
			result = AppLanguage.CadCamDynamic[63] + text2 + text3 + " - W: " + Op.OperationData.RectangleRoundData.RoundRectangleWidth.ToString("f1") + " , H: " + Op.OperationData.RectangleRoundData.RoundRectangleHeight.ToString("f1");
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.Slot)
		{
			result = AppLanguage.CadCamDynamic[59] + text2 + text3 + " - Dia: " + Op.OperationData.SlotData.SlotDiameter.ToString("f1") + " , W: " + Op.OperationData.SlotData.SlotWidth.ToString("f1");
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.Cut)
		{
			result = AppLanguage.CadCamDynamic[123] + text2 + text3 + " - W: " + Op.OperationData.CutData.CutWidth.ToString("f1") + " , H: " + Op.OperationData.CutData.CutHeigth.ToString("f1");
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.Barrel)
		{
			result = AppLanguage.CadCamDynamic[60] + text2 + text3 + " - Dia:" + Op.OperationData.BarelData.BarrelDiameter.ToString("f1") + " , L: " + Op.OperationData.BarelData.BarrelLength.ToString("f1") + " , W: " + Op.OperationData.BarelData.BarrelWidth.ToString("f1");
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.Ellipse)
		{
			result = AppLanguage.CadCamDynamic[54] + text2 + text3 + " - Dx:" + Op.OperationData.EllipseData.EllipseWidth.ToString("f1") + " , Dy: " + Op.OperationData.EllipseData.EllipseHeight.ToString("f1");
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.Hole)
		{
			result = AppLanguage.CadCamDynamic[124] + text2 + text3 + " - Dia:" + Op.OperationData.HoleData.HoleDiameter.ToString("f1");
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.Tapping)
		{
			result = buLangTranslate.preDef.Tapping + text2 + text3 + " - Dia:" + Op.OperationData.HoleData.HoleDiameter.ToString("f1");
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.Notch)
		{
			result = AppLanguage.CadCamDynamic[125] + text2 + text3 + " - D:" + Op.OperationData.NotchData.NotchDepth.ToString("f1") + " , H:" + Op.OperationData.NotchData.NotchHeight.ToString("f1");
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.FreeDraw)
		{
			result = AppLanguage.CadCamDynamic[77] + text2 + text3 + " - W:" + Op.OperationData.FreeDrawData.FreeDrawWidth.ToString("f1") + " , H:" + Op.OperationData.FreeDrawData.FreeDrawHeight.ToString("f1");
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.Text)
		{
			result = buLangTranslate.preDef.Text + text2 + text3 + " - T:" + Op.OperationData.TextData.TextString.ToString();
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.WireText)
		{
			result = buLangTranslate.preDef.Text + "  " + buLangTranslate.preDef.Wireframe + text2 + text3 + " - T:" + Op.OperationData.TextData.TextString.ToString();
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.Polygon)
		{
			result = buLangTranslate.preDef.Polygon + text2 + text3 + " - Side:" + Op.OperationData.PolygonData.PolygonSide + " , Dia:" + Op.OperationData.PolygonData.PolygonDiameter.ToString("f1");
		}
		return result;
	}

	public static string OperationItemDetailedString(ProfileOperation Op)
	{
		string text = "";
		string text2 = "";
		string text3 = " | X: " + Op.OperationData.Position.X.ToString("f1") + " , Y: " + Op.OperationData.Position.Y.ToString("f1");
		if (Op.OperationData.OperationType == ProfileOperationTypes.Circle)
		{
			text2 = AppLanguage.CadCamDynamic[51] + text3 + " - " + AppLanguage.CadCamDynamic[57] + "= " + Op.OperationData.CircleData.CircleDiameter.ToString("f1") + " - " + AppLanguage.CadCamDynamic[113] + "= " + Op.OperationData.CircleData.CircleThickness.ToString("f1");
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.Rectangle)
		{
			text2 = AppLanguage.CadCamDynamic[62] + text3 + " - " + AppLanguage.CadCamDynamic[15] + "= " + Op.OperationData.RectangleData.RectangleWidth.ToString("f1") + " - " + AppLanguage.CadCamDynamic[16] + "= " + Op.OperationData.RectangleData.RectangleHeight.ToString("f1") + " - " + AppLanguage.CadCamDynamic[113] + "= " + Op.OperationData.RectangleData.RectangleThickness.ToString("f1");
			if (Op.OperationData.RectangleData.RectangleAngle != 0.0)
			{
				text2 = text2 + " - " + AppLanguage.CadCamDynamic[2] + "= " + Op.OperationData.RectangleData.RectangleAngle.ToString("f1");
			}
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.RoundRectangle)
		{
			text2 = AppLanguage.CadCamDynamic[63] + text3 + " - " + AppLanguage.CadCamDynamic[15] + "= " + Op.OperationData.RectangleRoundData.RoundRectangleWidth.ToString("f1") + " - " + AppLanguage.CadCamDynamic[16] + "= " + Op.OperationData.RectangleRoundData.RoundRectangleHeight.ToString("f1") + " - " + AppLanguage.CadCamDynamic[19] + "= " + Op.OperationData.RectangleRoundData.RoundRectangleRadius.ToString("f1") + " - " + AppLanguage.CadCamDynamic[113] + "= " + Op.OperationData.RectangleRoundData.RoundRectangleThickness.ToString("f1");
			if (Op.OperationData.RectangleData.RectangleAngle != 0.0)
			{
				text2 = text2 + " - " + AppLanguage.CadCamDynamic[2] + "= " + Op.OperationData.RectangleRoundData.RoundRectangleAngle.ToString("f1");
			}
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.Slot)
		{
			text2 = AppLanguage.CadCamDynamic[59] + text3 + " - " + AppLanguage.CadCamDynamic[15] + "= " + Op.OperationData.SlotData.SlotWidth.ToString("f1") + " - " + AppLanguage.CadCamDynamic[57] + "= " + Op.OperationData.SlotData.SlotDiameter.ToString("f1") + " - " + AppLanguage.CadCamDynamic[113] + "= " + Op.OperationData.SlotData.SlotThickness.ToString("f1");
			if (Op.OperationData.SlotData.SlotAngle != 0.0)
			{
				text2 = text2 + " - " + AppLanguage.CadCamDynamic[2] + "= " + Op.OperationData.SlotData.SlotAngle.ToString("f1");
			}
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.Cut)
		{
			text2 = AppLanguage.CadCamDynamic[123] + text3 + " - " + AppLanguage.CadCamDynamic[15] + "= " + Op.OperationData.CutData.CutWidth.ToString("f1") + " - " + AppLanguage.CadCamDynamic[16] + "= " + Op.OperationData.CutData.CutHeigth.ToString("f1") + " - " + AppLanguage.CadCamDynamic[113] + "= " + Op.OperationData.CutData.CutThickness.ToString("f1");
			if (Op.OperationData.CutData.CutAngle != 0.0)
			{
				text2 = text2 + " - " + AppLanguage.CadCamDynamic[2] + "= " + Op.OperationData.CutData.CutAngle.ToString("f1");
			}
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.Barrel)
		{
			text2 = AppLanguage.CadCamDynamic[60] + text3 + " - " + AppLanguage.CadCamDynamic[57] + "= " + Op.OperationData.BarelData.BarrelDiameter.ToString("f1") + " - " + AppLanguage.CadCamDynamic[0] + "= " + Op.OperationData.BarelData.BarrelLength.ToString("f1") + " - " + AppLanguage.CadCamDynamic[15] + "= " + Op.OperationData.BarelData.BarrelWidth.ToString("f1") + " - " + AppLanguage.CadCamDynamic[113] + "= " + Op.OperationData.BarelData.BarrelThickness.ToString("f1");
			if (Op.OperationData.BarelData.BarrelAngle != 0.0)
			{
				text2 = text2 + " - " + AppLanguage.CadCamDynamic[2] + "= " + Op.OperationData.BarelData.BarrelAngle.ToString("f1");
			}
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.Ellipse)
		{
			text2 = AppLanguage.CadCamDynamic[54] + text3 + " - " + AppLanguage.CadCamDynamic[15] + "= " + Op.OperationData.EllipseData.EllipseWidth.ToString("f1") + " - " + AppLanguage.CadCamDynamic[16] + "= " + Op.OperationData.EllipseData.EllipseHeight.ToString("f1") + " - " + AppLanguage.CadCamDynamic[113] + "= " + Op.OperationData.EllipseData.EllipseThickness.ToString("f1");
			if (Op.OperationData.EllipseData.EllipseAngle != 0.0)
			{
				text2 = text2 + " - " + AppLanguage.CadCamDynamic[2] + "= " + Op.OperationData.EllipseData.EllipseAngle.ToString("f1");
			}
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.Hole)
		{
			text2 = AppLanguage.CadCamDynamic[124] + text3 + " - " + AppLanguage.CadCamDynamic[57] + "= " + Op.OperationData.HoleData.HoleDiameter.ToString("f1") + " - " + AppLanguage.CadCamDynamic[113] + "= " + Op.OperationData.HoleData.HoleThickness.ToString("f1");
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.Tapping)
		{
			text2 = buLangTranslate.preDef.Tapping + text3 + " - " + AppLanguage.CadCamDynamic[57] + "= " + Op.OperationData.HoleData.HoleDiameter.ToString("f1") + " - " + AppLanguage.CadCamDynamic[113] + "= " + Op.OperationData.HoleData.HoleThickness.ToString("f1");
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.Notch)
		{
			text2 = AppLanguage.CadCamDynamic[125] + " - " + AppLanguage.CadCamDynamic[84] + "= " + Op.OperationData.NotchData.NotchLocation.ToString() + " - " + AppLanguage.CadCamDynamic[127] + "= " + Op.OperationData.CamParNotch.Notch.CutDirection.ToString() + " - " + Op.OperationData.CamParNotch.Notch.NotchCutDirection.ToString() + " - " + Op.OperationData.CamParNotch.Notch.NotchCutType;
			text2 = text2 + " - " + AppLanguage.CadCamDynamic[15] + "= " + Op.OperationData.NotchData.NotchWidth.ToString("f1") + " - " + AppLanguage.CadCamDynamic[16] + "= " + Op.OperationData.NotchData.NotchHeight.ToString("f1") + " - " + AppLanguage.CadCamDynamic[113] + "= " + Op.OperationData.NotchData.NotchDepth.ToString("f1");
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.FreeDraw)
		{
			text2 = AppLanguage.CadCamDynamic[77] + text3 + " - " + AppLanguage.CadCamDynamic[15] + "= " + Op.OperationData.FreeDrawData.FreeDrawWidth.ToString("f1") + " - " + AppLanguage.CadCamDynamic[16] + "= " + Op.OperationData.FreeDrawData.FreeDrawHeight.ToString("f1") + " - " + AppLanguage.CadCamDynamic[50] + "= " + Op.OperationData.FreeDrawData.FreeDrawScaleCenter.ToString() + " - " + AppLanguage.CadCamDynamic[113] + "= " + Op.OperationData.FreeDrawData.FreeDrawThickness.ToString("f1");
			if (Op.OperationData.FreeDrawData.FreeDrawAngle != 0.0)
			{
				text2 = text2 + " - " + AppLanguage.CadCamDynamic[2] + "= " + Op.OperationData.FreeDrawData.FreeDrawAngle.ToString("f1");
			}
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.Text)
		{
			text2 = buLangTranslate.preDef.Text + text3 + " - " + Op.OperationData.TextData.TextString.ToString() + " - " + AppLanguage.CadCamDynamic[15] + "= " + Op.OperationData.TextData.TextWidth.ToString("f1") + " - " + AppLanguage.CadCamDynamic[16] + "= " + Op.OperationData.TextData.TextHeight.ToString("f1") + " - " + AppLanguage.CadCamDynamic[50] + "= " + Op.OperationData.TextData.TextScaleCenter.ToString() + " - " + AppLanguage.CadCamDynamic[126] + "= " + Op.OperationData.TextData.TextAlignment.ToString() + " - " + AppLanguage.CadCamDynamic[113] + "= " + Op.OperationData.TextData.TextThickness.ToString("f1");
			if (Op.OperationData.TextData.TextAngle != 0.0)
			{
				text2 = text2 + " - " + AppLanguage.CadCamDynamic[2] + "= " + Op.OperationData.TextData.TextAngle.ToString("f1");
			}
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.WireText)
		{
			text2 = buLangTranslate.preDef.Text + " " + buLangTranslate.preDef.Wireframe + text3 + " - " + Op.OperationData.TextData.TextString.ToString() + " - " + AppLanguage.CadCamDynamic[15] + "= " + Op.OperationData.TextData.TextWidth.ToString("f1") + " - " + AppLanguage.CadCamDynamic[16] + "= " + Op.OperationData.TextData.TextHeight.ToString("f1") + " - " + AppLanguage.CadCamDynamic[50] + "= " + Op.OperationData.TextData.TextScaleCenter.ToString() + " - " + AppLanguage.CadCamDynamic[126] + "= " + Op.OperationData.TextData.TextAlignment.ToString() + " - " + AppLanguage.CadCamDynamic[113] + "= " + Op.OperationData.TextData.TextThickness.ToString("f1");
			if (Op.OperationData.TextData.TextAngle != 0.0)
			{
				text2 = text2 + " - " + AppLanguage.CadCamDynamic[2] + "= " + Op.OperationData.TextData.TextAngle.ToString("f1");
			}
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.Polygon)
		{
			text2 = AppLanguage.CadCamDynamic[70] + text3 + " - " + AppLanguage.CadCamDynamic[71] + "= " + Op.OperationData.PolygonData.PolygonSide + " - " + AppLanguage.CadCamDynamic[57] + "= " + Op.OperationData.PolygonData.PolygonDiameter.ToString("f1") + " - " + AppLanguage.CadCamDynamic[113] + "= " + Op.OperationData.PolygonData.PolygonThickness.ToString("f1");
			if (Op.OperationData.PolygonData.PolygonThickness != 0.0)
			{
				text2 = text2 + " - " + AppLanguage.CadCamDynamic[2] + "= " + Op.OperationData.PolygonData.PolygonThickness.ToString("f1");
			}
		}
		return text2;
	}

	public static string OperationItemString(GProfileOperation Op, string strOperation, int Index)
	{
		string result = strOperation;
		if (Op.OperationData.OperationType == ProfileOperationTypes.Circle)
		{
			result = ProfileTempVars.strCircle + " " + (Index + 1) + ": [" + Op.OperationData.Position.X + "]";
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.Rectangle)
		{
			result = ProfileTempVars.strRectangle + " " + (Index + 1) + ": [" + Op.OperationData.Position.X + "]";
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.RoundRectangle)
		{
			result = ProfileTempVars.strRoundRect + " " + (Index + 1) + ": [" + Op.OperationData.Position.X + "]";
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.Slot)
		{
			result = ProfileTempVars.strSlot + " " + (Index + 1) + ": [" + Op.OperationData.Position.X + "]";
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.Cut)
		{
			result = ProfileTempVars.strCut + " " + (Index + 1) + ": [" + Op.OperationData.Position.X + "]";
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.Barrel)
		{
			result = ProfileTempVars.strKeyHole + " " + (Index + 1) + ": [" + Op.OperationData.Position.X + "]";
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.Ellipse)
		{
			result = ProfileTempVars.strEllipse + " " + (Index + 1) + ": [" + Op.OperationData.Position.X + "]";
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.Hole)
		{
			result = ProfileTempVars.strHole + " " + (Index + 1) + ": [" + Op.OperationData.Position.X + "]";
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.Notch)
		{
			result = ProfileTempVars.strNotch + " " + (Index + 1) + ": [" + Op.OperationData.Position.X + "]";
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.FreeDraw)
		{
			result = ProfileTempVars.strFreeDraw + " " + (Index + 1) + ": [" + Op.OperationData.Position.X + "]";
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.Text)
		{
			result = ProfileTempVars.strText + " " + (Index + 1) + ": [" + Op.OperationData.Position.X + "]";
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.WireText)
		{
			result = ProfileTempVars.strText + " " + buLangTranslate.preDef.Wireframe + " " + (Index + 1) + ": [" + Op.OperationData.Position.X + "]";
		}
		if (Op.OperationData.OperationType == ProfileOperationTypes.Polygon)
		{
			result = ProfileTempVars.strPoylgon + " " + (Index + 1) + ": [" + Op.OperationData.Position.X + "]";
		}
		return result;
	}

	public static string OperationItemStringV2(GProfileOperation Op)
	{
		string text = "";
		text = ((Op.OperationData.OperationType == ProfileOperationTypes.Circle) ? (buLangTranslate.preDef.Cirlce + " - " + Op.OperationData.selectedPlaneName.ToString() + " - [ X: " + Op.OperationData.Position.X + "]") : ((Op.OperationData.OperationType == ProfileOperationTypes.Rectangle) ? (buLangTranslate.preDef.Rectangle + " - " + Op.OperationData.selectedPlaneName.ToString() + " - [ X: " + Op.OperationData.Position.X + "]") : ((Op.OperationData.OperationType == ProfileOperationTypes.RoundRectangle) ? (buLangTranslate.preDef.RectangleRound + " - " + Op.OperationData.selectedPlaneName.ToString() + " - [ X: " + Op.OperationData.Position.X + "]") : ((Op.OperationData.OperationType == ProfileOperationTypes.Slot) ? (buLangTranslate.preDef.Slot + " - " + Op.OperationData.selectedPlaneName.ToString() + " - [ X: " + Op.OperationData.Position.X + "]") : ((Op.OperationData.OperationType == ProfileOperationTypes.Cut) ? (buLangTranslate.preDef.Cut + " - " + Op.OperationData.selectedPlaneName.ToString() + " - [ X: " + Op.OperationData.Position.X + "]") : ((Op.OperationData.OperationType == ProfileOperationTypes.Barrel) ? (buLangTranslate.preDef.KeyHole + " - " + Op.OperationData.selectedPlaneName.ToString() + " - [ X: " + Op.OperationData.Position.X + "]") : ((Op.OperationData.OperationType == ProfileOperationTypes.Ellipse) ? (buLangTranslate.preDef.Ellipse + " - " + Op.OperationData.selectedPlaneName.ToString() + " - [ X: " + Op.OperationData.Position.X + "]") : ((Op.OperationData.OperationType == ProfileOperationTypes.Hole) ? (buLangTranslate.preDef.Hole + " - " + Op.OperationData.selectedPlaneName.ToString() + " - [ X: " + Op.OperationData.Position.X + "]") : ((Op.OperationData.OperationType == ProfileOperationTypes.Notch) ? (buLangTranslate.preDef.Notch + " - " + Op.OperationData.selectedPlaneName.ToString() + " - [ X: " + Op.OperationData.Position.X + "]") : ((Op.OperationData.OperationType == ProfileOperationTypes.FreeDraw) ? (buLangTranslate.preDef.FreeDraw + " - " + Op.OperationData.selectedPlaneName.ToString() + " - [ X: " + Op.OperationData.Position.X + "]") : ((Op.OperationData.OperationType == ProfileOperationTypes.Text) ? (buLangTranslate.preDef.Text + " - " + Op.OperationData.selectedPlaneName.ToString() + " - [ X: " + Op.OperationData.Position.X + "]") : ((Op.OperationData.OperationType == ProfileOperationTypes.WireText) ? (buLangTranslate.preDef.Text + " - " + buLangTranslate.preDef.Wireframe + " " + Op.OperationData.selectedPlaneName.ToString() + " - [ X: " + Op.OperationData.Position.X + "]") : ((Op.OperationData.OperationType == ProfileOperationTypes.Polygon) ? (buLangTranslate.preDef.Polygon + " - " + Op.OperationData.selectedPlaneName.ToString() + " - [ X: " + Op.OperationData.Position.X + "]") : (buLangTranslate.preDef.Other + " - " + Op.OperationData.selectedPlaneName.ToString() + " - [ X: " + Op.OperationData.Position.X + "]"))))))))))))));
		return text + " - " + Op.OperationData.selectedPlaneName;
	}

	public static string PlaneToString(planeNames refPlane)
	{
		string text = "";
		return refPlane switch
		{
			planeNames.Top => buLangTranslate.preDef.Top, 
			planeNames.Bottom => buLangTranslate.preDef.Bottom, 
			planeNames.Front => buLangTranslate.preDef.Front, 
			planeNames.Back => buLangTranslate.preDef.Back, 
			planeNames.Left => buLangTranslate.preDef.Left, 
			planeNames.Right => buLangTranslate.preDef.Right, 
			_ => buLangTranslate.preDef.Free, 
		};
	}

	public int GetOperationImageIndex(ProfileOperation OP)
	{
		int num = -1;
		num = Convert.ToInt32(OP.OperationData.OperationType);
		if (OP.OperationData.OperationType == ProfileOperationTypes.WireText)
		{
			num = 32;
		}
		if (OP.OperationData.OperationType == ProfileOperationTypes.Tapping)
		{
			num = 42;
		}
		if (!OP.Enable)
		{
			num = 26;
		}
		if (OP.Error)
		{
		}
		return num;
	}

	public void SetWaterOnAdnOffToCam(ref List<camTp> Cams, string WaterOn, string WaterOff)
	{
		bool flag = false;
		for (int i = 0; i <= Cams.Count - 1; i++)
		{
			for (int j = 0; j <= Cams[i].CamPoints.Count - 1; j++)
			{
				for (int k = 0; k <= Cams[i].CamPoints[j].Points.Count - 1; k++)
				{
					TpPnt9D tpPnt9D = Cams[i].CamPoints[j].Points[k];
					TpPnt9D tpPnt9D2 = null;
					TpPnt9D tpPnt9D3 = null;
					if (k < Cams[i].CamPoints[j].Points.Count - 1)
					{
						tpPnt9D2 = Cams[i].CamPoints[j].Points[k + 1];
					}
					if (k > 0)
					{
						tpPnt9D3 = Cams[i].CamPoints[j].Points[k - 1];
					}
					if (flag && tpPnt9D3 != null && ((tpPnt9D.Type == 0) & (tpPnt9D3.Type > 0)))
					{
						tpPnt9D.AfterCodes.Add(WaterOff);
						flag = false;
					}
					if (!flag && tpPnt9D2 != null && ((tpPnt9D.Type == 0) & (tpPnt9D2.Type > 0)))
					{
						tpPnt9D.AfterCodes.Add(WaterOn);
						flag = true;
					}
				}
			}
		}
	}

	public void SetWaterOnAdnOffToCam(ref List<camTp> Cams, List<string> WaterOn, List<string> WaterOff)
	{
		bool flag = false;
		for (int i = 0; i <= Cams.Count - 1; i++)
		{
			for (int j = 0; j <= Cams[i].CamPoints.Count - 1; j++)
			{
				for (int k = 0; k <= Cams[i].CamPoints[j].Points.Count - 1; k++)
				{
					TpPnt9D tpPnt9D = Cams[i].CamPoints[j].Points[k];
					TpPnt9D tpPnt9D2 = null;
					TpPnt9D tpPnt9D3 = null;
					if (k < Cams[i].CamPoints[j].Points.Count - 1)
					{
						tpPnt9D2 = Cams[i].CamPoints[j].Points[k + 1];
					}
					if (k > 0)
					{
						tpPnt9D3 = Cams[i].CamPoints[j].Points[k - 1];
					}
					if (flag && tpPnt9D3 != null && ((tpPnt9D.Type == 0) & (tpPnt9D3.Type > 0)))
					{
						tpPnt9D.AfterCodes.AddRange(WaterOff);
						flag = false;
					}
					if (!flag && tpPnt9D2 != null && ((tpPnt9D.Type == 0) & (tpPnt9D2.Type > 0)))
					{
						tpPnt9D.AfterCodes.AddRange(WaterOn);
						flag = true;
					}
				}
			}
		}
	}

	public void InsertProfileInfoToGCode(ProfileItem Item, int IndestIndex, ref PostProcessor tempPost, string CommentStartChar, string CommentEndChar, string EqualChar = " = ")
	{
		string callMethod = "InsertProfileInfoToGCode";
		try
		{
			string text = buLangTranslate.preDef.Left;
			if (Item.XReferanceLocation == LeftRightType.Right)
			{
				text = buLangTranslate.preDef.Right;
			}
			tempPost.StartLines.Insert(IndestIndex, CommentStartChar + text + " " + buLangTranslate.preDef.Profile + " " + CommentEndChar);
			tempPost.StartLines.Insert(IndestIndex + 1, CommentStartChar + buLangTranslate.preDef.Length + EqualChar + Item.Length.ToString("f2") + " " + CommentEndChar);
			tempPost.StartLines.Insert(IndestIndex + 2, CommentStartChar + buLangTranslate.preDef.Width + EqualChar + Item.Width.ToString("f2") + " " + CommentEndChar);
			tempPost.StartLines.Insert(IndestIndex + 3, CommentStartChar + buLangTranslate.preDef.Height + EqualChar + Item.Height.ToString("f2") + " " + CommentEndChar);
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, sClass, callMethod, ShowMessageBox: false, "");
		}
	}

	public void InsertSupportBlockInfoToGCode(ProfileItem Item, int InsertIndex, ref PostProcessor tempPost, string CommentStartChar, string CommentEndChar, string EqualChar = " = ")
	{
		string callMethod = "InsertSupportBlockInfoToGCode";
		try
		{
			if ((Item.SupportBlock.SupportBlockZHeight > 0.0) | (Item.SupportBlock.SupportBlockY1FrontWidth > 0.0) | (Item.SupportBlock.SupportBlockY2BackWidth > 0.0))
			{
				string text = CommentStartChar;
				if (Item.SupportBlock.SupportBlockZHeight > 0.0)
				{
					text = text + "Z " + buLangTranslate.preDef.Bottom + " " + buLangTranslate.preDef.Leaning + "= " + Item.SupportBlock.SupportBlockZHeight.ToString("f1") + "  ";
				}
				if (Item.SupportBlock.SupportBlockY1FrontWidth > 0.0)
				{
					text = text + "Y " + buLangTranslate.preDef.Front + " " + buLangTranslate.preDef.Leaning + "= " + Item.SupportBlock.SupportBlockY1FrontWidth.ToString("f1") + "  ";
				}
				if (Item.SupportBlock.SupportBlockY2BackWidth > 0.0)
				{
					text = text + "Y " + buLangTranslate.preDef.Back + " " + buLangTranslate.preDef.Leaning + "= " + Item.SupportBlock.SupportBlockY2BackWidth.ToString("f1");
				}
				text += CommentEndChar;
				tempPost.StartLines.Insert(InsertIndex, text);
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, sClass, callMethod, ShowMessageBox: false, "");
		}
	}

	public void InsertOperationInfoToGCode(GProfileOperation OP, ref ArrayList Infos, string CommentStartChar, string CommentEndChar, string EqualChar = "= ")
	{
		string callMethod = "InsertOperationInfoToGCode";
		try
		{
			string text = "";
			if (OP.OperationData.OperationType == ProfileOperationTypes.Rectangle)
			{
				text = CommentStartChar + buLangTranslate.preDef.Rectangle + " - " + buLangTranslate.preDef.Width + EqualChar + OP.OperationData.RectangleData.RectangleWidth.ToString("f2") + " - " + buLangTranslate.preDef.Height + EqualChar + OP.OperationData.RectangleData.RectangleHeight.ToString("f2");
				if (OP.OperationData.RectangleData.RectangleRadius > 0.0)
				{
					text = text + " - " + buLangTranslate.preDef.Radius + EqualChar + OP.OperationData.RectangleData.RectangleRadius.ToString("f2");
				}
				text += CommentEndChar;
				Infos.Add(text);
			}
			if (OP.OperationData.OperationType == ProfileOperationTypes.Circle)
			{
				text = CommentStartChar + buLangTranslate.preDef.Cirlce + " - " + buLangTranslate.preDef.Diameter + EqualChar + OP.OperationData.CircleData.CircleDiameter.ToString("f2");
				text += CommentEndChar;
				Infos.Add(text);
			}
			if (OP.OperationData.OperationType == ProfileOperationTypes.Slot)
			{
				text = CommentStartChar + buLangTranslate.preDef.Slot + " - " + buLangTranslate.preDef.Width + EqualChar + OP.OperationData.SlotData.SlotWidth.ToString("f2") + " - " + buLangTranslate.preDef.Diameter + EqualChar + OP.OperationData.SlotData.SlotDiameter.ToString("f2");
				text += CommentEndChar;
				Infos.Add(text);
			}
			if (OP.OperationData.OperationType == ProfileOperationTypes.Ellipse)
			{
				text = CommentStartChar + buLangTranslate.preDef.Ellipse + " - " + buLangTranslate.preDef.Width + EqualChar + OP.OperationData.EllipseData.EllipseWidth.ToString("f2") + " - " + buLangTranslate.preDef.Height + EqualChar + OP.OperationData.EllipseData.EllipseHeight.ToString("f2");
				text += CommentEndChar;
				Infos.Add(text);
			}
			if (OP.OperationData.OperationType == ProfileOperationTypes.Polygon)
			{
				text = CommentStartChar + buLangTranslate.preDef.Polygon + " - " + buLangTranslate.preDef.Diameter + EqualChar + OP.OperationData.PolygonData.PolygonDiameter.ToString("f2") + " - " + buLangTranslate.preDef.Side + EqualChar + OP.OperationData.PolygonData.PolygonSide;
				text += CommentEndChar;
				Infos.Add(text);
			}
			if (OP.OperationData.OperationType == ProfileOperationTypes.Hole)
			{
				text = CommentStartChar + buLangTranslate.preDef.Hole + " - " + buLangTranslate.preDef.Diameter + EqualChar + OP.OperationData.HoleData.HoleDiameter.ToString("f2");
				text += CommentEndChar;
				Infos.Add(text);
			}
			if (OP.OperationData.OperationType == ProfileOperationTypes.Barrel)
			{
				text = CommentStartChar + buLangTranslate.preDef.KeyHole + " - " + buLangTranslate.preDef.Diameter + EqualChar + OP.OperationData.BarelData.BarrelDiameter.ToString("f2") + " - " + buLangTranslate.preDef.Length + EqualChar + OP.OperationData.BarelData.BarrelLength.ToString("f2") + " - " + buLangTranslate.preDef.Width + EqualChar + OP.OperationData.BarelData.BarrelWidth.ToString("f2");
				text += CommentEndChar;
				Infos.Add(text);
			}
			if (OP.OperationData.OperationType == ProfileOperationTypes.FreeDraw)
			{
				text = CommentStartChar + buLangTranslate.preDef.FreeDraw + " - " + buLangTranslate.preDef.Width + EqualChar + OP.OperationData.FreeDrawData.FreeDrawWidth.ToString("f2") + " - " + buLangTranslate.preDef.Height + EqualChar + OP.OperationData.FreeDrawData.FreeDrawHeight.ToString("f2");
				text += CommentEndChar;
				Infos.Add(text);
			}
			if ((OP.OperationData.OperationType == ProfileOperationTypes.Text) | (OP.OperationData.OperationType == ProfileOperationTypes.CustomText) | (OP.OperationData.OperationType == ProfileOperationTypes.WireText))
			{
				text = CommentStartChar + buLangTranslate.preDef.Text + EqualChar + OP.OperationData.TextData.TextString + " - " + buLangTranslate.preDef.Width + EqualChar + OP.OperationData.TextData.TextWidth.ToString("f2") + " - " + buLangTranslate.preDef.Height + EqualChar + OP.OperationData.TextData.TextHeight.ToString("f2");
				text += CommentEndChar;
				Infos.Add(text);
			}
			if (OP.OperationData.OperationType == ProfileOperationTypes.Cut)
			{
				text = CommentStartChar + buLangTranslate.preDef.Cut + " - " + buLangTranslate.preDef.Width + EqualChar + OP.OperationData.CutData.CutWidth.ToString("f2") + " - " + buLangTranslate.preDef.Height + EqualChar + OP.OperationData.CutData.CutHeigth.ToString("f2");
				text += CommentEndChar;
				Infos.Add(text);
			}
			if (OP.OperationData.OperationType == ProfileOperationTypes.Notch)
			{
				text = CommentStartChar + buLangTranslate.preDef.Notch + EqualChar + OP.OperationData.NotchData.NotchOPType;
				text += CommentEndChar;
				Infos.Add(text);
			}
			text = CommentStartChar + PlaneToString(OP.OperationData.selectedPlaneName) + " - " + buLangTranslate.preDef.Depth + EqualChar + (OP.OperationData.ExternalDepth + OP.OperationData.ExtraDepth).ToString("f2") + CommentEndChar;
			Infos.Add(text);
			if (OP.Tool != null)
			{
				text = CommentStartChar + buLangTranslate.preDef.Tool + " " + OP.Tool.Data.Name + " - " + buLangTranslate.preDef.Diameter + EqualChar + OP.Tool.Geometry.Diameter + " - " + buLangTranslate.preDef.Length + EqualChar + OP.Tool.Geometry.Length + CommentEndChar;
				Infos.Add(text);
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, sClass, callMethod, ShowMessageBox: false, "");
		}
	}

	public void CreatePlane(ProfilePlaneDef Type, int Index, bool Create, Point3D pntMinProfile, Point3D pntMaxProfile, double PlaneThinkness, UCSObjectData UcsData, ref SelectedPlaneInfo P)
	{
		string explanation = P.Explanation;
		if (Create)
		{
			P = new SelectedPlaneInfo();
		}
		P.PlaneType = Type;
		if (Create)
		{
			if (Type == ProfilePlaneDef.Top0)
			{
				P.pntPlane = new Point3D(0.0, pntMinProfile.Y, pntMaxProfile.Z);
				P.Angle = 0.0;
				explanation = buLangTranslate.preDef.Top + " " + buLangTranslate.preDef.Plane + ": " + (P.Angle + P.AngleOffset).ToString("f1") + " °";
			}
			if (Type == ProfilePlaneDef.Back45 || Type == ProfilePlaneDef.Back90)
			{
				P.pntPlane = new Point3D(0.0, 0.0, pntMaxProfile.Z);
				if (Type == ProfilePlaneDef.Back45)
				{
					P.Angle = -45.0;
				}
				if (Type == ProfilePlaneDef.Back90)
				{
					P.Angle = -90.0;
				}
				explanation = buLangTranslate.preDef.Back + " " + buLangTranslate.preDef.Plane + ": " + (P.Angle + P.AngleOffset).ToString("f1") + " °";
			}
			if (Type == ProfilePlaneDef.Front45 || Type == ProfilePlaneDef.Front90)
			{
				P.pntPlane = new Point3D(0.0, pntMinProfile.Y, pntMaxProfile.Z);
				if (Type == ProfilePlaneDef.Front45)
				{
					P.Angle = 45.0;
				}
				if (Type == ProfilePlaneDef.Front90)
				{
					P.Angle = 90.0;
					P.pntPlane.Z = 0.0;
				}
				explanation = buLangTranslate.preDef.Front + " " + buLangTranslate.preDef.Plane + ": " + (P.Angle + P.AngleOffset).ToString("f1") + " °";
			}
		}
		P.AngleOffset = 0.0;
		P.refPlane = new Plane(new Point3D(0.0, P.pntPlane.Y, P.pntPlane.Z), Vector3D.AxisX, Vector3D.AxisY);
		P.refPlane.Rotate(buConversion5.DegreeToRadian(P.Angle), P.refPlane.AxisX, P.pntPlane);
		P.refPlane.UpdateEquation();
		P.Length = pntMaxProfile.X - pntMinProfile.X;
		P.Height = pntMaxProfile.Y - pntMinProfile.Y;
		if (P.Length <= 0.0)
		{
			P.Length = 100.0;
		}
		if (P.Height <= 0.0)
		{
			P.Height = 20.0;
		}
		buCall.buVector5_0.PlaneToEntity(P.refPlane, P.Length, P.Height, PlaneThinkness, UcsData, ref P.entityPlane, ref P.entityXVector, ref P.entityYVector, ref P.entityZVector, ref P.entityBall);
		P.Explanation = explanation;
		P.Index = Index;
	}

	public int ClamperPreperation(ref ProfileItemCalc ItemCalc, List<ProfileClamper> Clampers, List<ProfileLengthClamperCount> ClampCountFromLength, ref List<ProfileClamper> opClampers, ref int RemainClamper)
	{
		try
		{
			ItemCalc.IsClamperDone = false;
			if (Clampers.Count != 0)
			{
				if (ClampCountFromLength.Count > 0)
				{
					for (int i = 0; i <= ClampCountFromLength.Count - 1; i++)
					{
						if (i != 0)
						{
							if (((ClampCountFromLength[i - 1].ProfileLength < ItemCalc.Length) & (ItemCalc.Length <= ClampCountFromLength[i].ProfileLength)) && ItemCalc.MaxClamperNumber >= ClampCountFromLength[i].ClamperCount)
							{
								RemainClamper = ItemCalc.MaxClamperNumber - ClampCountFromLength[i].ClamperCount;
								ItemCalc.MaxClamperNumber = ClampCountFromLength[i].ClamperCount;
							}
						}
						else if (ItemCalc.Length <= ClampCountFromLength[i].ProfileLength && ItemCalc.MaxClamperNumber >= ClampCountFromLength[i].ClamperCount)
						{
							RemainClamper = ItemCalc.MaxClamperNumber - ClampCountFromLength[i].ClamperCount;
							ItemCalc.MaxClamperNumber = ClampCountFromLength[i].ClamperCount;
						}
					}
				}
				if ((ItemCalc.CalcType == ProfileExcType.LongSecondPart) | (ItemCalc.CalcType == ProfileExcType.LongSecondBottom))
				{
					ItemCalc.MaxClamperNumber = Clampers.Count;
					RemainClamper = 0;
				}
				for (int j = 0; j <= ItemCalc.MaxClamperNumber - 1; j++)
				{
					if (j > Clampers.Count - 1)
					{
						opClampers.Add(new ProfileClamper());
					}
					else
					{
						opClampers.Add(Clampers[j]);
					}
				}
				for (int k = 0; k <= opClampers.Count - 1; k++)
				{
					opClampers[k].Used = false;
				}
				return 1;
			}
			MessageBox.Show(buLangTranslate.preSentencesProfile.NoClamperAvailable);
			return -1;
		}
		catch (Exception)
		{
			return -1;
		}
	}

	public void ReArrangeClampers(double MinX, double MaxX, double ForbiddenMixX, double ForbiddenMaxX, int ClamperCount, double MinDisBetweenClamper, double MaxDisBetweenClamper, ref List<ProfileClamper> Clampers)
	{
		try
		{
			double num = MaxX - ForbiddenMaxX;
			for (int i = 0; i <= Clampers.Count - 1; i++)
			{
				if (i != 0)
				{
					if (i != ClamperCount - 1)
					{
						if (!(i > 0 && i < ClamperCount - 1))
						{
							if (Clampers[i].XPosition < Clampers[i - 1].XPosition + MinDisBetweenClamper)
							{
								Clampers[i].XPosition = Clampers[i - 1].XPosition + MinDisBetweenClamper;
								Clampers[i].GeometrixMaxX = Clampers[i].XPosition + Clampers[i].Width / 2.0;
								Clampers[i].GeometrixMinX = Clampers[i].XPosition - Clampers[i].Width / 2.0;
							}
							continue;
						}
						double num2 = ForbiddenMixX - Clampers[i].Width / 2.0 - Clampers[i - 1].XPosition;
						if (MinDisBetweenClamper < num2 && num2 < MaxDisBetweenClamper)
						{
							Clampers[i].XPosition = ForbiddenMixX - Clampers[i].Width / 2.0;
							Clampers[i].GeometrixMaxX = Clampers[i].XPosition + Clampers[i].Width / 2.0;
							Clampers[i].GeometrixMinX = Clampers[i].XPosition - Clampers[i].Width / 2.0;
						}
					}
					else if (!(num > Clampers[0].Width / 2.0))
					{
						double num3 = ForbiddenMixX - Clampers[i].Width / 2.0 - Clampers[i - 1].XPosition;
						if (!(MinDisBetweenClamper < num3 && num3 < MaxDisBetweenClamper))
						{
							if (Clampers[i].XPosition < MaxX)
							{
								Clampers[i].XPosition = MaxX + MinDisBetweenClamper;
								Clampers[i].GeometrixMaxX = Clampers[i].XPosition + Clampers[i].Width / 2.0;
								Clampers[i].GeometrixMinX = Clampers[i].XPosition - Clampers[i].Width / 2.0;
							}
						}
						else
						{
							Clampers[i].XPosition = ForbiddenMixX - Clampers[i].Width / 2.0;
							Clampers[i].GeometrixMaxX = Clampers[i].XPosition + Clampers[i].Width / 2.0;
							Clampers[i].GeometrixMinX = Clampers[i].XPosition - Clampers[i].Width / 2.0;
						}
					}
					else
					{
						Clampers[i].XPosition = ForbiddenMaxX + Clampers[i].Width / 2.0;
						Clampers[i].GeometrixMaxX = Clampers[i].XPosition + Clampers[i].Width / 2.0;
						Clampers[i].GeometrixMinX = Clampers[i].XPosition - Clampers[i].Width / 2.0;
					}
				}
				else
				{
					Clampers[i].XPosition = MinX;
					Clampers[i].GeometrixMaxX = Clampers[i].XPosition + Clampers[i].Width / 2.0;
					Clampers[i].GeometrixMinX = Clampers[i].XPosition - Clampers[i].Width / 2.0;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public int HowManyClamperInsideProfile(ProfileItemCalc Item, double StartOffset, double EndOffset, List<ProfileClamper> Clampers, double ProfileOffset = 0.0)
	{
		try
		{
			double num = StartOffset + ProfileOffset;
			double num2 = Item.Length - EndOffset + ProfileOffset;
			int num3 = 0;
			for (int i = 0; i <= Clampers.Count - 1; i++)
			{
				if ((num <= Clampers[i].XPosition) & (Clampers[i].XPosition <= num2))
				{
					num3++;
				}
			}
			return num3;
		}
		catch (Exception)
		{
			return 0;
		}
	}

	public int HowManyClamperInsideProfile(ProfileItem Item, double MachineLength)
	{
		try
		{
			int num = 0;
			if (Item.XReferanceLocation != LeftRightType.Left)
			{
				double num2 = MachineLength - Item.Length;
				for (int i = 0; i <= Item.CalculationData.Count - 1; i++)
				{
					for (int j = 0; j <= Item.CalculationData[i].calcOperations.Count - 1; j++)
					{
						for (int k = 0; k <= Item.CalculationData[i].calcOperations[j].Clampers.Count - 1; k++)
						{
							ProfileClamper profileClamper = Item.CalculationData[i].calcOperations[j].Clampers[k];
							if ((profileClamper.XPosition > num2) & (profileClamper.XPosition <= MachineLength))
							{
								num++;
							}
						}
					}
				}
			}
			else
			{
				for (int l = 0; l <= Item.CalculationData.Count - 1; l++)
				{
					for (int m = 0; m <= Item.CalculationData[l].calcOperations.Count - 1; m++)
					{
						for (int n = 0; n <= Item.CalculationData[l].calcOperations[m].Clampers.Count - 1; n++)
						{
							ProfileClamper profileClamper2 = Item.CalculationData[l].calcOperations[m].Clampers[n];
							if ((profileClamper2.XPosition > 0.0) & (profileClamper2.XPosition <= Item.Length + 2.0))
							{
								num++;
							}
						}
					}
				}
			}
			return num;
		}
		catch (Exception)
		{
			return 0;
		}
	}

	public void RemoveUnNeccesaryClamperMove(List<ProfileClamper> LastClampers, GProfileOperation OP, ref List<ProfileClamper> CurrentClampers)
	{
		if (!((LastClampers.Count > 0) & (CurrentClampers.Count > 0)))
		{
			return;
		}
		int num = CurrentClampers.Count - 1;
		if (num >= 0)
		{
			double num2 = CurrentClampers[num].XPosition - LastClampers[num].XPosition;
			if (num2 < 0.0 && ((OP.SizePoint.MinPoint.X < LastClampers[num].XPosition) & (OP.SizePoint.MaxPoint.X < LastClampers[num].XPosition)) && ((OP.SizePoint.MinPoint.X < CurrentClampers[num].XPosition) & (OP.SizePoint.MaxPoint.X < CurrentClampers[num].XPosition)))
			{
				CurrentClampers[num] = new ProfileClamper(LastClampers[num]);
			}
			if (num2 > 0.0 && ((LastClampers[num].XPosition < OP.SizePoint.MinPoint.X) & (LastClampers[num].XPosition < OP.SizePoint.MaxPoint.X)) && ((CurrentClampers[num].XPosition < OP.SizePoint.MinPoint.X) & (CurrentClampers[num].XPosition < OP.SizePoint.MaxPoint.X)))
			{
				CurrentClampers[num] = new ProfileClamper(LastClampers[num]);
			}
		}
	}

	public bool isClamperSuitable(double MinPosition, double MaxPosition, double OperationMinDistance, double ClamperWidth)
	{
		try
		{
			double num = MaxPosition - MinPosition;
			double num2 = OperationMinDistance;
			if (MinPosition > 0.0)
			{
				num2 = OperationMinDistance * 2.0;
			}
			if (!(num < ClamperWidth + num2))
			{
				return true;
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public bool isClamperInsideOperationRange(double MinPointX, double MaxPointX, double LeftDistance, double RightDistance, double ClamperPosition, double ClamperWidth)
	{
		double num = MinPointX - LeftDistance;
		double num2 = MaxPointX + RightDistance;
		if (!(num < ClamperPosition && ClamperPosition < num2))
		{
			if (!(num < ClamperPosition && ClamperPosition < num2))
			{
				if (!(num < ClamperPosition && ClamperPosition < num2))
				{
					return false;
				}
				return true;
			}
			return true;
		}
		return true;
	}

	public bool isClamperInsideOperationRange(GProfileOperation OP, double LeftDistance, double RightDistance, double ClamperPosition, double ClamperWidth)
	{
		double num = OP.SizePoint.MinPoint.X - LeftDistance;
		double num2 = OP.SizePoint.MaxPoint.X + RightDistance;
		double num3 = ClamperPosition - ClamperWidth / 2.0;
		double num4 = ClamperPosition + ClamperWidth / 2.0;
		if (!(num < num3 && num3 < num2))
		{
			if (!(num < num4 && num4 < num2))
			{
				if (!(num < ClamperPosition && ClamperPosition < num2))
				{
					return false;
				}
				return true;
			}
			return true;
		}
		return true;
	}

	public bool isClamperInsideOperationRange(GProfileOperationGroup OP, double LeftDistance, double RightDistance, double ClamperPosition, double ClamperWidth)
	{
		double num = OP.Size.MinPoint.X - LeftDistance;
		double num2 = OP.Size.MaxPoint.X - RightDistance;
		double num3 = ClamperPosition - ClamperWidth / 2.0;
		double num4 = ClamperPosition + ClamperWidth / 2.0;
		if (!(num3 > num && num3 < num2))
		{
			if (!(num4 > num && num4 < num2))
			{
				return false;
			}
			return true;
		}
		return true;
	}

	public bool isOperationInsideClamperLimits(GProfileOperation OP, List<ProfileClamper> Clampers, OperationInsideClampers Options)
	{
		for (int i = 0; i <= Clampers.Count - 1; i++)
		{
			bool flag = isOperationInsideClamper(OP, Clampers[i], Options);
			if ((Options.IndexOpertion > 0) & (OP.OperationData.selectedPlaneName == planeNames.Top) & !Options.UseTopPlane)
			{
				flag = false;
			}
			if (flag)
			{
				return true;
			}
		}
		return false;
	}

	public bool isClmpersAreSame(List<ProfileClamper> FirstClampers, List<ProfileClamper> SecondClampers)
	{
		try
		{
			if (FirstClampers.Count == SecondClampers.Count)
			{
				for (int i = 0; i <= FirstClampers.Count - 1; i++)
				{
					if (!buCompare.EQ(FirstClampers[i].XPosition, SecondClampers[i].XPosition))
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public bool isClmpersAreSameWhichAreMoved(List<ProfileClamper> FirstClampers, List<ProfileClamper> SecondClampers, ref List<int> MovedIndex)
	{
		try
		{
			bool result = true;
			MovedIndex.Clear();
			if (FirstClampers.Count == SecondClampers.Count)
			{
				for (int i = 0; i <= FirstClampers.Count - 1; i++)
				{
					if (!buCompare.EQ(FirstClampers[i].XPosition, SecondClampers[i].XPosition))
					{
						result = false;
						MovedIndex.Add(i);
					}
				}
				return result;
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public bool isOperationInsideClamper(GProfileOperation OP, ProfileClamper Clampers, OperationInsideClampers Options)
	{
		if (!((Clampers.GeometrixMinX < OP.SizePoint.MinPoint.X) & (OP.SizePoint.MinPoint.X < Clampers.GeometrixMaxX)))
		{
			if (!((Clampers.GeometrixMinX < OP.SizePoint.MaxPoint.X) & (OP.SizePoint.MaxPoint.X < Clampers.GeometrixMaxX)))
			{
				double num = OP.SizePoint.MinPoint.X - Options.LeftDistance + Options.ClamperWidth / 2.0;
				if (!((Clampers.GeometrixMinX < num) & (num < Clampers.GeometrixMaxX)))
				{
					num = OP.SizePoint.MaxPoint.X + Options.RightDistance - Options.ClamperWidth / 2.0;
					if (!((Clampers.GeometrixMinX < num) & (num < Clampers.GeometrixMaxX)))
					{
						if (!((OP.SizePoint.MinPoint.X < Clampers.GeometrixMinX) & (Clampers.GeometrixMinX < OP.SizePoint.MaxPoint.X)))
						{
							if (!((OP.SizePoint.MinPoint.X < Clampers.GeometrixMaxX) & (Clampers.GeometrixMaxX < OP.SizePoint.MaxPoint.X)))
							{
								double num2 = OP.SizePoint.MinPoint.X - Options.LeftDistance + Options.ClamperWidth / 2.0;
								double num3 = OP.SizePoint.MaxPoint.X + Options.RightDistance - Options.ClamperWidth / 2.0;
								if (!((num2 < Clampers.GeometrixMinX) & (Clampers.GeometrixMinX < num3)))
								{
									if (!((num2 < Clampers.GeometrixMaxX) & (Clampers.GeometrixMaxX < num3)))
									{
										return false;
									}
									return true;
								}
								return true;
							}
							return true;
						}
						return true;
					}
					return true;
				}
				return true;
			}
			return true;
		}
		return true;
	}

	public bool isExistingClamperSuitableForNew(List<ProfileClamper> ExistingClampers, int indexExistingClamper, List<ProfileClamper> NewClampersList, ProfileClamper newClamper, GProfileOperation OP, ProfileExistingClamperCompare Options, ProfileClamperSettings ClamperSettings)
	{
		if ((indexExistingClamper >= 0) & (indexExistingClamper <= ExistingClampers.Count - 1))
		{
			double value = ExistingClampers[indexExistingClamper].XPosition - newClamper.XPosition;
			if (!Options.UseBig)
			{
				if (Math.Abs(value) < Options.SmallChangeGap)
				{
					if (NewClampersList.Count > 0)
					{
						double num = ExistingClampers[indexExistingClamper].XPosition - NewClampersList[NewClampersList.Count - 1].XPosition;
						if (num < ClamperSettings.MinDistanceFor2Clamper)
						{
							return false;
						}
						if (num > ClamperSettings.MaxDistanceFor2Clamper)
						{
							return false;
						}
					}
					if (!isOperationInsideClamper(OP, ExistingClampers[indexExistingClamper], new OperationInsideClampers(Options.LeftDistance, Options.RightDistance, ClamperSettings.ClamperWidth)))
					{
						return true;
					}
					return false;
				}
			}
			else if (Math.Abs(value) < Options.BigChangeGap)
			{
				if (NewClampersList.Count > 0)
				{
					double num2 = ExistingClampers[indexExistingClamper].XPosition - NewClampersList[NewClampersList.Count - 1].XPosition;
					if (num2 < ClamperSettings.MinDistanceFor2Clamper)
					{
						return false;
					}
					if (num2 > ClamperSettings.MaxDistanceFor2Clamper)
					{
						return false;
					}
				}
				if (!isOperationInsideClamper(OP, ExistingClampers[indexExistingClamper], new OperationInsideClampers(Options.LeftDistance, Options.RightDistance, ClamperSettings.ClamperWidth)))
				{
					return true;
				}
				return false;
			}
		}
		return false;
	}

	public void Clamper3D(double XPosition, int Type, double ProfileWidth, double ProfileHeight, ClamperData3D Data, ref List<Entity> ClamperEntities)
	{
		ClamperEntities = new List<Entity>();
		if (Type == 1)
		{
			new List<TriangleIndex>();
			new List<Pnt3D>();
			Point3D point3D = new Point3D(XPosition, (0.0 - (ProfileWidth + Data.TipPointThickness - Data.ConstantPointThickness)) / 2.0, (0.0 - Data.BottomThickness) / 2.0);
			Brep brep = Brep.CreateBox(Data.Width, ProfileWidth + Data.TipPointThickness + Data.ConstantPointThickness, Data.BottomThickness);
			brep.Regen(new RegenParams(buSystem.RegenDeviation));
			brep.Translate((0.0 - (brep.BoxMax.X - brep.BoxMin.X)) / 2.0, (0.0 - (brep.BoxMax.Y - brep.BoxMin.Y)) / 2.0, (0.0 - (brep.BoxMax.Z - brep.BoxMin.Z)) / 2.0);
			brep.Translate(point3D.X, point3D.Y, point3D.Z);
			point3D = new Point3D(XPosition, 0.0 - (ProfileWidth + Data.TipPointThickness / 2.0), Data.ConstantPointHeight / 2.0);
			Brep brep2 = Brep.CreateBox(Data.Width, Data.TipPointThickness, Data.ConstantPointHeight);
			brep2.Regen(new RegenParams(buSystem.RegenDeviation));
			brep2.Translate((0.0 - (brep2.BoxMax.X - brep2.BoxMin.X)) / 2.0, (0.0 - (brep2.BoxMax.Y - brep2.BoxMin.Y)) / 2.0, (0.0 - (brep2.BoxMax.Z - brep2.BoxMin.Z)) / 2.0);
			brep2.Translate(point3D.X, point3D.Y, point3D.Z);
			point3D = new Point3D(XPosition, Data.ConstantPointThickness / 2.0, Data.TipPointHeight / 2.0);
			Brep brep3 = Brep.CreateBox(Data.Width, Data.ConstantPointThickness, Data.TipPointHeight);
			brep3.Regen(new RegenParams(buSystem.RegenDeviation));
			brep3.Translate((0.0 - (brep3.BoxMax.X - brep3.BoxMin.X)) / 2.0, (0.0 - (brep3.BoxMax.Y - brep3.BoxMin.Y)) / 2.0, (0.0 - (brep3.BoxMax.Z - brep3.BoxMin.Z)) / 2.0);
			brep3.Translate(point3D.X, point3D.Y, point3D.Z);
			ClamperEntities.Add(brep);
			ClamperEntities.Add(brep2);
			ClamperEntities.Add(brep3);
		}
	}

	public bool isPositionInsideMinMax(double X, List<MinMax> MinMaxList, ref double distanceToMin, ref double distanceToMax)
	{
		try
		{
			for (int i = 0; i <= MinMaxList.Count - 1; i++)
			{
				if ((MinMaxList[i].Min <= X) & (X <= MinMaxList[i].Max))
				{
					distanceToMin = X - MinMaxList[i].Min;
					distanceToMax = MinMaxList[i].Max - X;
					return true;
				}
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public bool isPreOPCalmperSequenceCloseToCurrentClamper(GProfileOperation PreOP, GProfileOperation CurrentOP, int ClamperIndex, double ClamperCloseToDistance, double LeftDistance, double RightDistance, double ClamperWidth, ref ProfileClamper CurrentClamper)
	{
		if (ClamperIndex > PreOP.Clampers.Count - 1)
		{
			return false;
		}
		double value = PreOP.Clampers[ClamperIndex].XPosition - CurrentClamper.XPosition;
		if (Math.Abs(value) < ClamperCloseToDistance)
		{
			OperationInsideClampers options = new OperationInsideClampers(LeftDistance, RightDistance, ClamperWidth);
			if (!isOperationInsideClamper(CurrentOP, PreOP.Clampers[ClamperIndex], options))
			{
				CurrentClamper = new ProfileClamper(PreOP.Clampers[ClamperIndex]);
			}
		}
		return true;
	}

	public bool FindSuitableArea(List<GProfileOperationGroup> Groups, int startIndex, ProfileClamperSettings Settings, ref List<double> FoundX)
	{
		FoundX = new List<double>();
		if (startIndex >= 0)
		{
			for (int i = startIndex; i <= Groups.Count - 2; i++)
			{
				bool flag = false;
				for (int j = 0; j <= Groups[i + 1].OpList.Count - 1; j++)
				{
					if ((Groups[i + 1].OpList[j].OperationData.selectedPlaneName == planeNames.Front) | (Groups[i + 1].OpList[j].OperationData.selectedPlaneName == planeNames.Back) | (Groups[i + 1].OpList[j].OperationData.selectedPlaneName == planeNames.Free))
					{
						flag = true;
					}
				}
				if (!flag)
				{
					double num = Groups[i + 1].Size.MidPoint.X - Groups[i].Size.MaxPoint.X;
					if (num > Settings.OperationFrontLeftMinDistance + Settings.OperationFrontRightMinDistance)
					{
						double item = Groups[i].Size.MaxPoint.X + Settings.OperationFrontRightMinDistance;
						FoundX.Add(item);
					}
				}
				else
				{
					double num2 = Groups[i + 1].Size.MinPoint.X - Groups[i].Size.MaxPoint.X;
					if (num2 > Settings.OperationFrontLeftMinDistance + Settings.OperationFrontRightMinDistance)
					{
						double item2 = Groups[i].Size.MaxPoint.X + Settings.OperationFrontRightMinDistance;
						FoundX.Add(item2);
					}
				}
			}
			if (FoundX.Count != 0)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public void AddForbiddenAreaToList(MinMax ForbiddernPoint, ref List<MinMax> ForbiddenAreas)
	{
		if (ForbiddenAreas.Count != 0)
		{
			for (int i = 0; i <= ForbiddenAreas.Count - 1; i++)
			{
				bool flag = buNumeric5.IsValueInsideMinMaxValues(ForbiddernPoint.Min, ForbiddenAreas[i].Min, ForbiddenAreas[i].Max);
				bool flag2 = buNumeric5.IsValueInsideMinMaxValues(ForbiddernPoint.Max, ForbiddenAreas[i].Min, ForbiddenAreas[i].Max);
				if (!(!flag && !flag2))
				{
					if (!(flag && !flag2))
					{
						if (!flag && flag2)
						{
							ForbiddenAreas[i].Min = ForbiddernPoint.Min;
						}
					}
					else
					{
						ForbiddenAreas[i].Max = ForbiddernPoint.Max;
					}
				}
				else
				{
					ForbiddenAreas.Add(ForbiddernPoint);
				}
			}
		}
		else
		{
			ForbiddenAreas.Add(ForbiddernPoint);
		}
	}

	public void MoveFwdClampersFromIndex(int refIndex, double MinClamperDistance, ref List<ProfileClamper> Clampers)
	{
		if (!((refIndex >= 0) & (refIndex <= Clampers.Count - 1)))
		{
			return;
		}
		for (int i = refIndex + 1; i <= Clampers.Count - 1; i++)
		{
			double num = Clampers[i].XPosition - Clampers[i - 1].XPosition;
			if (num < MinClamperDistance)
			{
				Clampers[i].XPosition = Clampers[i - 1].XPosition + MinClamperDistance;
			}
		}
	}

	public void MoveBwdClampersFromIndex(int refIndex, double MinClamperDistance, ref List<ProfileClamper> Clampers)
	{
		if (!((refIndex >= 0) & (refIndex <= Clampers.Count - 1)))
		{
			return;
		}
		for (int num = refIndex - 1; num >= 0; num--)
		{
			double num2 = Clampers[num + 1].XPosition - Clampers[num].XPosition;
			if (num2 < MinClamperDistance)
			{
				Clampers[num].XPosition = Clampers[num + 1].XPosition - MinClamperDistance;
			}
		}
	}

	public bool isOperationSafeForClamps(ProfileItem Item, ProfileItemCalc ItemCalc, GProfileOperation sortOP, ProfileSettings varProfileSet, ProfileClamperSettings varProfileClampSet)
	{
		double num = 0.0;
		double num2 = 0.0;
		bool result = false;
		if (sortOP.OperationData.selectedPlaneName == planeNames.Free)
		{
			num = buCall.buVector5_0.PointAngle(new Point3D(sortOP.OperationData.selectedPlane.AxisZ.X, sortOP.OperationData.selectedPlane.AxisZ.Y, sortOP.OperationData.selectedPlane.AxisZ.Z), new Point3D(), Plane.YZ);
			num2 = ((num > 90.0) ? (num - 90.0) : (90.0 - num));
		}
		if ((sortOP.OperationData.selectedPlaneName == planeNames.Top) | (sortOP.OperationData.selectedPlaneName == planeNames.Bottom) | ((sortOP.OperationData.selectedPlaneName == planeNames.Free) & (num2 <= varProfileClampSet.FreePlaneToBackFrontAngleLimit)))
		{
			if (ItemCalc.Height + Item.SupportBlock.SupportBlockZHeight > varProfileClampSet.ClamperMaxHeight)
			{
				result = true;
			}
			if (sortOP.SizePoint.MinPoint.Z + Item.SupportBlock.SupportBlockZHeight > varProfileClampSet.ClamperMaxHeight)
			{
				result = true;
			}
			if ((sortOP.SizePoint.MinPoint.Y - varProfileSet.ToolPensDiameter / 2.0 - 5.0 > 0.0 - ItemCalc.Width) & (sortOP.SizePoint.MaxPoint.Y + varProfileSet.ToolPensDiameter / 2.0 + 5.0 < 0.0))
			{
				result = true;
			}
			double num3 = sortOP.SizePoint.MinPoint.Z + Item.SupportBlock.SupportBlockZHeight + (sortOP.Tool.Geometry.TotalLength - varProfileSet.ToolHolderLength);
			if (num3 > varProfileClampSet.ClamperMaxHeight && ((sortOP.SizePoint.MinPoint.Y - sortOP.Tool.Geometry.Diameter / 2.0 - 5.0 > 0.0 - ItemCalc.Width) & (sortOP.SizePoint.MaxPoint.Y + sortOP.Tool.Geometry.Diameter / 2.0 + 5.0 < 0.0)))
			{
				result = true;
			}
		}
		if (((sortOP.OperationData.selectedPlaneName == planeNames.Back) | (((sortOP.OperationData.selectedPlaneName == planeNames.Free) & (num2 > varProfileClampSet.FreePlaneToBackFrontAngleLimit)) && num < 90.0)) && sortOP.OperationData.selectedPlaneName == planeNames.Free && sortOP.SizePoint.MinPoint.Z + Item.SupportBlock.SupportBlockZHeight > varProfileClampSet.ClamperMaxHeight)
		{
			result = true;
		}
		if (((sortOP.OperationData.selectedPlaneName == planeNames.Front) | (((sortOP.OperationData.selectedPlaneName == planeNames.Free) & (num2 > varProfileClampSet.FreePlaneToBackFrontAngleLimit)) && num > 90.0)) && sortOP.OperationData.selectedPlaneName == planeNames.Free && sortOP.SizePoint.MinPoint.Z + Item.SupportBlock.SupportBlockZHeight > varProfileClampSet.ClamperMaxHeight)
		{
			result = true;
		}
		return result;
	}

	public bool isNotchOperationSimilar(GProfileOperation FirstOP, GProfileOperation SecondOP)
	{
		if (FirstOP == null || FirstOP.OperationData.OperationType != ProfileOperationTypes.Notch || FirstOP.OperationData.NotchData.NotchOPType != ProfileNotchOperationType.Side || SecondOP == null || SecondOP.OperationData.OperationType != ProfileOperationTypes.Notch || FirstOP.OperationData.NotchData.NotchOPType != SecondOP.OperationData.NotchData.NotchOPType || !((FirstOP.OperationData.NotchData.NotchLocation == SecondOP.OperationData.NotchData.NotchLocation) & (FirstOP.OperationData.NotchData.NotchFrontBack == SecondOP.OperationData.NotchData.NotchFrontBack)) || FirstOP.OperationData.CamParNotch.Notch.NotchCutType != SecondOP.OperationData.CamParNotch.Notch.NotchCutType)
		{
			return false;
		}
		return true;
	}

	public void PositionConversionFromPlane(ProfileItem curItem, planeNames selectedPlaneName, Plane selectedPlane, ref ProfileOperationData OPData, ref double Ang)
	{
		Ang = buCall.buVector5_0.PlaneAngleYZ(selectedPlane);
	}

	public ShapeTypes ActionToShapeType(actionTypeBU action)
	{
		ShapeTypes result = ShapeTypes.Rectangle;
		if (action == actionTypeBU.profileRectangle)
		{
			result = ShapeTypes.Rectangle;
		}
		if (action == actionTypeBU.profileCircle)
		{
			result = ShapeTypes.Circle;
		}
		if (action == actionTypeBU.profileEllipse)
		{
			result = ShapeTypes.Ellipse;
		}
		if (action == actionTypeBU.profileBarrel)
		{
			result = ShapeTypes.KeyHole;
		}
		if (action == actionTypeBU.profilePolygon)
		{
			result = ShapeTypes.Polygon;
		}
		if (action == actionTypeBU.profileSlot)
		{
			result = ShapeTypes.Slot;
		}
		if (action == actionTypeBU.profileHole)
		{
			result = ShapeTypes.Hole;
		}
		if (action == actionTypeBU.profileTapping)
		{
			result = ShapeTypes.Hole;
		}
		if (action == actionTypeBU.profileCut)
		{
			result = ShapeTypes.Cut;
		}
		if (action == actionTypeBU.profileFreeDraw)
		{
			result = ShapeTypes.FreeDraw;
		}
		if (action == actionTypeBU.profileText)
		{
			result = ShapeTypes.Text;
		}
		if (action == actionTypeBU.profileWireText)
		{
			result = ShapeTypes.Text;
		}
		return result;
	}

	public void ManuelZValueFromPlaneChange(ProfileItem curItem, ProfileOperation OP, planeNames newPlane, double refManuelZVal, ref double calcManuelZVal)
	{
		if (OP.OperationData.selectedPlaneName != planeNames.Front)
		{
			if (OP.OperationData.selectedPlaneName != planeNames.Back)
			{
				if (OP.OperationData.selectedPlaneName != planeNames.Top)
				{
				}
				return;
			}
			if (newPlane == planeNames.Front)
			{
				calcManuelZVal = 0.0 - curItem.Width - refManuelZVal;
				if (calcManuelZVal < 0.0 - curItem.Width)
				{
					calcManuelZVal = 0.0 - curItem.Width;
				}
			}
			if (newPlane == planeNames.Top)
			{
				calcManuelZVal = curItem.Height + refManuelZVal;
			}
			return;
		}
		if (newPlane == planeNames.Back)
		{
			calcManuelZVal = curItem.Width + refManuelZVal;
			if (calcManuelZVal > 0.0)
			{
				calcManuelZVal = 0.0;
			}
		}
		if (newPlane == planeNames.Top)
		{
			calcManuelZVal = curItem.Height + (0.0 - curItem.Width - refManuelZVal);
		}
	}

	public int GetSelectedOperationCount(ProfileItem curItem)
	{
		int num = 0;
		for (int i = 0; i <= curItem.Operations.Count - 1; i++)
		{
			if (curItem.Operations[i].Selected)
			{
				num++;
			}
		}
		return num;
	}

	public void ShapeFromProfileOperation(ProfileOperation OP, ref buShape Shape)
	{
		ProfileOperationData operationData = OP.OperationData;
		if (operationData.OperationType != ProfileOperationTypes.Rectangle)
		{
			if (operationData.OperationType != ProfileOperationTypes.Circle)
			{
				if (operationData.OperationType != ProfileOperationTypes.Ellipse)
				{
					if (operationData.OperationType != ProfileOperationTypes.Barrel)
					{
						if (operationData.OperationType != ProfileOperationTypes.Polygon)
						{
							if (operationData.OperationType != ProfileOperationTypes.Slot)
							{
								if (operationData.OperationType != ProfileOperationTypes.Cut)
								{
									if (operationData.OperationType != ProfileOperationTypes.FreeDraw)
									{
										if (operationData.OperationType == ProfileOperationTypes.Text)
										{
											Shape = new buShapeText(operationData.TextData.TextWidth, operationData.TextData.TextHeight, OP.Depth, operationData.TextData.TextString, operationData.TextData.TextFont, operationData.TextData.TextAngle);
											((buShapeText)Shape).isWire = operationData.TextData.isWire;
										}
									}
									else
									{
										Shape = new buShapeFreeDraw(operationData.FreeDrawData.FreeDrawWidth, operationData.FreeDrawData.FreeDrawHeight, OP.Depth, operationData.FreeDrawData.FreeDrawAngle);
									}
								}
								else
								{
									Shape = new buShapeCut(CutTypes.CutVertical, operationData.CutData.CutHeigth, OP.Depth, operationData.CutData.CutWidth);
								}
							}
							else
							{
								Shape = new buShapeSlot(operationData.SlotData.SlotDiameter, operationData.SlotData.SlotWidth, OP.Depth, operationData.SlotData.SlotAngle);
							}
						}
						else
						{
							Shape = new buShapePolygon(operationData.PolygonData.PolygonDiameter / 2.0, operationData.PolygonData.PolygonSide, OP.Depth, operationData.PolygonData.PolygonAngle);
						}
					}
					else
					{
						Shape = new buShapeKeyHole(operationData.BarelData.BarrelDiameter, operationData.BarelData.BarrelWidth, operationData.BarelData.BarrelLength, OP.Depth, operationData.BarelData.BarrelAngle);
					}
				}
				else
				{
					Shape = new buShapeEllipse(operationData.EllipseData.EllipseWidth / 2.0, operationData.EllipseData.EllipseHeight / 2.0, OP.Depth, operationData.EllipseData.EllipseAngle);
				}
			}
			else
			{
				Shape = new buShapeCircle(operationData.CircleData.CircleDiameter / 2.0, OP.Depth);
			}
		}
		else
		{
			Shape = new buShapeRectangle(operationData.RectangleData.RectangleWidth, operationData.RectangleData.RectangleHeight, operationData.RectangleData.RectangleRadius, 0.0, OP.Depth, operationData.RectangleData.RectangleAngle);
		}
		Shape.Priority = OP.Priority;
		Shape.BasePoint = new Point3D(operationData.basePosition.X, operationData.basePosition.Y, operationData.basePosition.Z);
		Shape.planeName = buConversion5.PlaneNamesToPlaneBoxNames(operationData.selectedPlaneName);
		Shape.planeOperation = buCall.buVector5_0.PlaneNameToPlane(Shape.planeName);
		Shape.Corner = operationData.Corner;
		Shape.Alignment = operationData.Alignment;
		Shape.DepthExtra = operationData.ExtraDepth;
		Shape.CamPar = new camParameters5(operationData.CamParMilling);
		Shape.isPocket = operationData.CamParMilling.Operations.AreaClearanceEnable;
	}

	public void CheckOperationSpeeds(ref ProfileOperation OP)
	{
		if (OP.OperationData.OperationType == ProfileOperationTypes.Notch)
		{
			return;
		}
		if (OP.OperationData.CamParMilling.Speeds.SpindleSpeed == 0.0)
		{
			OP.OperationData.CamParMilling.Speeds.SpindleSpeed = OP.Tool.CamData.SpindleSpeed;
		}
		if (OP.OperationData.CamParMilling.Speeds.Feed == 0.0)
		{
			if (!(OP.CamOPData.velFeed > 0.0))
			{
				OP.OperationData.CamParMilling.Speeds.Feed = OP.Tool.CamData.FeedSpeed;
			}
			else
			{
				OP.OperationData.CamParMilling.Speeds.Feed = OP.CamOPData.velFeed;
			}
		}
		if (OP.OperationData.CamParMilling.Speeds.Plunge == 0.0)
		{
			if (!(OP.CamOPData.velPlunge > 0.0))
			{
				OP.OperationData.CamParMilling.Speeds.Plunge = OP.Tool.CamData.PlungeSpeed;
			}
			else
			{
				OP.OperationData.CamParMilling.Speeds.Plunge = OP.CamOPData.velPlunge;
			}
		}
		if (OP.OperationData.CamParMilling.Speeds.Finish == 0.0)
		{
			if (!(OP.CamOPData.velFinish > 0.0))
			{
				OP.OperationData.CamParMilling.Speeds.Finish = OP.Tool.CamData.FinishSpeed;
			}
			else
			{
				OP.OperationData.CamParMilling.Speeds.Finish = OP.CamOPData.velFinish;
			}
		}
		if (OP.OperationData.CamParMilling.Speeds.Leave == 0.0)
		{
			if (!(OP.CamOPData.velLeave > 0.0))
			{
				OP.OperationData.CamParMilling.Speeds.Leave = OP.Tool.CamData.LeaveSpeed;
			}
			else
			{
				OP.OperationData.CamParMilling.Speeds.Leave = OP.CamOPData.velLeave;
			}
		}
	}

	public void AddOperationToProfileOperationList(ref ProfileItem Item, ProfileOperation OP, bool AddSmallSizeBeforeIfSamePos)
	{
		if (Item == null)
		{
			return;
		}
		if (Item.Operations.Count != 0)
		{
			bool flag = false;
			if (AddSmallSizeBeforeIfSamePos)
			{
				for (int i = 0; i <= Item.Operations.Count - 1; i++)
				{
					if (OP.OperationData.OperationType == Item.Operations[i].OperationData.OperationType && !flag && OP.OperationData.selectedPlaneName == Item.Operations[i].OperationData.selectedPlaneName && buCompare5.EQ(OP.OperationData.Position, Item.Operations[i].OperationData.Position, 0.01))
					{
						double num = OP.MaxPoint.X - OP.MinPoint.X;
						double num2 = Item.Operations[i].MaxPoint.X - Item.Operations[i].MinPoint.X;
						if (num < num2)
						{
							Item.Operations.Insert(i, OP);
							flag = true;
						}
					}
				}
			}
			if (!flag)
			{
				Item.Operations.Add(OP);
			}
		}
		else
		{
			Item.Operations.Add(OP);
		}
	}

	public void FindOperationFromCalculatedOperationsByID(ProfileItem Item, string ID, ref ProfileOperation foundOP)
	{
		if (Item == null)
		{
			return;
		}
		int num = 0;
		while (true)
		{
			if (num <= Item.Operations.Count - 1)
			{
				if (Item.Operations[num].ID == ID)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		foundOP = Item.Operations[num];
	}

	public void ShapeRunTimeToOperationData(ShapeRuntimeData shapeRuntimeData, ref ProfileOperationData OPData)
	{
		if (shapeRuntimeData.ShapeType == ShapeTypes.Rectangle)
		{
			OPData.RectangleData.RectangleHeight = shapeRuntimeData.RectangleHeight;
			OPData.RectangleData.RectangleWidth = shapeRuntimeData.RectangleWidth;
			OPData.RectangleData.RectangleRadius = shapeRuntimeData.RectangleRadius;
			OPData.RectangleData.RectangleChamfer = shapeRuntimeData.RectangleChamfer;
		}
		OPData.ExtraDepth = shapeRuntimeData.ExtraDepth;
	}

	public void OperationDataToShapeRunTime(ProfileOperationData OPData, ref ShapeRuntimeData shapeRuntimeData)
	{
		shapeRuntimeData.RectangleHeight = OPData.RectangleData.RectangleHeight;
		shapeRuntimeData.RectangleAngle = OPData.RectangleData.RectangleAngle;
		shapeRuntimeData.Edit.RotateDegree = shapeRuntimeData.RectangleAngle;
		shapeRuntimeData.RectangleWidth = OPData.RectangleData.RectangleWidth;
		shapeRuntimeData.RectangleRadius = OPData.RectangleData.RectangleRadius;
		shapeRuntimeData.RectangleChamfer = OPData.RectangleData.RectangleChamfer;
		if (OPData.OperationType == ProfileOperationTypes.Rectangle)
		{
			shapeRuntimeData.RectangleDepth = OPData.ExternalDepth;
			shapeRuntimeData.Edit.RotateDegree = shapeRuntimeData.RectangleAngle;
		}
		shapeRuntimeData.SlotAngle = OPData.SlotData.SlotAngle;
		shapeRuntimeData.SlotDiameter = OPData.SlotData.SlotDiameter;
		shapeRuntimeData.SlotLength = OPData.SlotData.SlotWidth;
		if (OPData.OperationType == ProfileOperationTypes.Slot)
		{
			shapeRuntimeData.SlotDepth = OPData.ExternalDepth;
			shapeRuntimeData.Edit.RotateDegree = shapeRuntimeData.SlotAngle;
		}
		shapeRuntimeData.PolygonAngle = OPData.PolygonData.PolygonAngle;
		shapeRuntimeData.PolygonRadius = OPData.PolygonData.PolygonDiameter / 2.0;
		shapeRuntimeData.PolygonSide = OPData.PolygonData.PolygonSide;
		if (OPData.OperationType == ProfileOperationTypes.Polygon)
		{
			shapeRuntimeData.PolygonDepth = OPData.ExternalDepth;
			shapeRuntimeData.Edit.RotateDegree = shapeRuntimeData.PolygonAngle;
		}
		shapeRuntimeData.KeyHoleAngle = OPData.BarelData.BarrelAngle;
		shapeRuntimeData.KeyHoleDiameter = OPData.BarelData.BarrelWidth;
		shapeRuntimeData.KeyHoleHeadDiameter = OPData.BarelData.BarrelDiameter;
		shapeRuntimeData.KeyHoleLength = OPData.BarelData.BarrelLength;
		if (OPData.OperationType == ProfileOperationTypes.Barrel)
		{
			shapeRuntimeData.KeyHoleDepth = OPData.ExternalDepth;
			shapeRuntimeData.Edit.RotateDegree = shapeRuntimeData.KeyHoleAngle;
		}
		shapeRuntimeData.HoleDiameter = OPData.HoleData.HoleDiameter;
		if (OPData.OperationType == ProfileOperationTypes.Hole)
		{
			shapeRuntimeData.HoleDepth = OPData.ExternalDepth;
		}
		shapeRuntimeData.EllipseAngle = OPData.EllipseData.EllipseAngle;
		shapeRuntimeData.EllipseRadiusX = OPData.EllipseData.EllipseWidth / 2.0;
		shapeRuntimeData.EllipseRadiusY = OPData.EllipseData.EllipseHeight / 2.0;
		if (OPData.OperationType == ProfileOperationTypes.Ellipse)
		{
			shapeRuntimeData.EllipseDepth = OPData.ExternalDepth;
			shapeRuntimeData.Edit.RotateDegree = shapeRuntimeData.EllipseAngle;
		}
		shapeRuntimeData.CircleRadius = OPData.CircleData.CircleDiameter / 2.0;
		if (OPData.OperationType == ProfileOperationTypes.Circle)
		{
			shapeRuntimeData.CircleDepth = OPData.ExternalDepth;
		}
		shapeRuntimeData.Edit.ArrayData = new ShapeArray(OPData.Array);
		shapeRuntimeData.Edit.MirrorData = new ShapeMirror(OPData.Mirror);
		shapeRuntimeData.FreeDrawAngle = OPData.FreeDrawData.FreeDrawAngle;
		shapeRuntimeData.FreeDrawWidth = OPData.FreeDrawData.FreeDrawWidth;
		shapeRuntimeData.FreeDrawHeight = OPData.FreeDrawData.FreeDrawHeight;
		if (OPData.OperationType == ProfileOperationTypes.FreeDraw)
		{
			shapeRuntimeData.FreeDrawDepth = OPData.ExternalDepth;
			shapeRuntimeData.Edit.RotateDegree = shapeRuntimeData.FreeDrawAngle;
		}
		shapeRuntimeData.TextAngle = OPData.TextData.TextAngle;
		shapeRuntimeData.TextHeight = OPData.TextData.TextHeight;
		shapeRuntimeData.TextWidth = OPData.TextData.TextWidth;
		shapeRuntimeData.TextString = OPData.TextData.TextString;
		shapeRuntimeData.TextFont = OPData.TextData.TextFont;
		if (OPData.OperationType == ProfileOperationTypes.Text)
		{
			shapeRuntimeData.TextDepth = OPData.ExternalDepth;
			shapeRuntimeData.Edit.RotateDegree = shapeRuntimeData.TextAngle;
		}
		shapeRuntimeData.NotchSideLocation = OPData.NotchData.NotchLocation;
		shapeRuntimeData.NotchOPType = OPData.NotchData.NotchOPType;
		shapeRuntimeData.NotchDepth = OPData.NotchData.NotchDepth;
		shapeRuntimeData.NotchHeight = OPData.NotchData.NotchHeight;
		shapeRuntimeData.NotchFrontBack = OPData.NotchData.NotchFrontBack;
		shapeRuntimeData.NotchStartHeight = OPData.NotchData.NotchStart;
		shapeRuntimeData.NotchUpDown = OPData.NotchData.NotchUpDown;
		shapeRuntimeData.NotchWidth = OPData.NotchData.NotchWidth;
		shapeRuntimeData.selectedPlane = buConversion5.PlaneNamesToPlaneBoxNames(OPData.selectedPlaneName);
		shapeRuntimeData.pntBase = buVector5.ToPoint3D(OPData.basePosition);
		shapeRuntimeData.pntBase.X = OPData.basePosition.X;
		shapeRuntimeData.selectedCorner = OPData.Corner;
		shapeRuntimeData.objectAlignment = OPData.Alignment;
		shapeRuntimeData.isShapePocket = OPData.CamParMilling.Operations.AreaClearanceEnable;
		shapeRuntimeData.EachLayer = OPData.EachLayer;
		shapeRuntimeData.ExtraDepth = OPData.ExtraDepth;
		shapeRuntimeData.ManuelDepthStart = OPData.ManuelZVal;
		shapeRuntimeData.ManuelDepthEnable = OPData.ManuelZEnable;
		shapeRuntimeData.CamPars = new camParameters5(OPData.CamParMilling);
	}

	public void SplitOperationByToolNo(List<GProfileOperation> refOperations, ref List<List<GProfileOperation>> splitedOP)
	{
		if (refOperations.Count <= 0)
		{
			return;
		}
		splitedOP = new List<List<GProfileOperation>>();
		List<GProfileOperation> list = new List<GProfileOperation>();
		list.Add(new GProfileOperation(refOperations[0]));
		splitedOP.Add(list);
		list = new List<GProfileOperation>();
		for (int i = 1; i <= refOperations.Count - 1; i++)
		{
			bool flag = false;
			GProfileOperation gProfileOperation = new GProfileOperation(refOperations[i]);
			for (int j = 0; j <= splitedOP.Count - 1; j++)
			{
				for (int k = 0; k <= splitedOP[j].Count - 1; k++)
				{
					if (splitedOP[j][k].Tool.Data.No == gProfileOperation.Tool.Data.No && !flag)
					{
						splitedOP[j].Add(gProfileOperation);
						flag = true;
					}
				}
			}
			if (!flag)
			{
				list = new List<GProfileOperation>();
				list.Add(gProfileOperation);
				splitedOP.Add(list);
			}
		}
	}

	public void SplitOperationByPlane(List<GProfileOperation> refOperations, ref List<List<GProfileOperation>> splitedOP)
	{
		if (refOperations.Count <= 0)
		{
			return;
		}
		splitedOP = new List<List<GProfileOperation>>();
		List<GProfileOperation> list = new List<GProfileOperation>();
		List<GProfileOperation> list2 = new List<GProfileOperation>();
		List<GProfileOperation> list3 = new List<GProfileOperation>();
		List<GProfileOperation> list4 = new List<GProfileOperation>();
		List<GProfileOperation> list5 = new List<GProfileOperation>();
		for (int i = 0; i <= refOperations.Count - 1; i++)
		{
			if (refOperations[i].OperationData.selectedPlaneName == planeNames.Top)
			{
				list.Add(new GProfileOperation(refOperations[i]));
			}
			if (refOperations[i].OperationData.selectedPlaneName == planeNames.Front)
			{
				list2.Add(new GProfileOperation(refOperations[i]));
			}
			if (refOperations[i].OperationData.selectedPlaneName == planeNames.Back)
			{
				list3.Add(new GProfileOperation(refOperations[i]));
			}
			if (refOperations[i].OperationData.selectedPlaneName == planeNames.Free)
			{
				list4.Add(new GProfileOperation(refOperations[i]));
			}
			if (refOperations[i].OperationData.selectedPlaneName == planeNames.Bottom)
			{
				list5.Add(new GProfileOperation(refOperations[i]));
			}
		}
		if (list.Count > 0)
		{
			splitedOP.Add(list);
		}
		if (list3.Count > 0)
		{
			splitedOP.Add(list3);
		}
		if (list2.Count > 0)
		{
			splitedOP.Add(list2);
		}
		if (list4.Count > 0)
		{
			splitedOP.Add(list4);
		}
		if (list5.Count > 0)
		{
			splitedOP.Add(list5);
		}
	}

	public void OperationDimensionEntities(ref ProfileOperation OP, ProfileItem curItem, double selectedFreePlaneLength)
	{
		Point3D point3D = null;
		Point3D point3D2 = null;
		Point3D point3D3 = null;
		Point3D point3D4 = null;
		Point3D point3D5 = null;
		Point3D point3D6 = null;
		Plane drawingPlane = null;
		DimensionGroup dimensionGroup = null;
		buLinearDim buLinearDim2 = null;
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		OP.EntityDimension.Clear();
		if (OP.OperationData.Action == actionTypeBU.profileRectangle)
		{
			num = OP.OperationData.RectangleData.RectangleWidth;
			num2 = OP.OperationData.RectangleData.RectangleHeight;
			num3 = OP.OperationData.RectangleData.RectangleAngle;
		}
		if (OP.OperationData.Action == actionTypeBU.profileCircle)
		{
			num = OP.OperationData.CircleData.CircleDiameter;
		}
		if (OP.OperationData.Action == actionTypeBU.profileHole)
		{
			num = OP.OperationData.HoleData.HoleDiameter;
		}
		if (OP.OperationData.Action == actionTypeBU.profileTapping)
		{
			num = OP.OperationData.HoleData.HoleDiameter;
		}
		if (OP.OperationData.Action == actionTypeBU.profileEllipse)
		{
			num = OP.OperationData.EllipseData.EllipseWidth;
			num2 = OP.OperationData.EllipseData.EllipseHeight;
			num3 = OP.OperationData.EllipseData.EllipseAngle;
		}
		if (OP.OperationData.Action == actionTypeBU.profileSlot)
		{
			num = OP.OperationData.SlotData.SlotWidth;
			num2 = OP.OperationData.SlotData.SlotDiameter;
			num3 = OP.OperationData.SlotData.SlotAngle;
		}
		if (OP.OperationData.Action == actionTypeBU.profileBarrel)
		{
			num = OP.OperationData.BarelData.BarrelLength;
			num2 = OP.OperationData.BarelData.BarrelWidth;
			num3 = OP.OperationData.BarelData.BarrelAngle;
		}
		if (OP.OperationData.Action == actionTypeBU.profilePolygon)
		{
			num = OP.OperationData.PolygonData.PolygonDiameter;
		}
		if (OP.OperationData.Action == actionTypeBU.profileCut)
		{
			num = OP.OperationData.CutData.CutWidth;
			num2 = OP.OperationData.CutData.CutHeigth;
		}
		if (OP.OperationData.Action == actionTypeBU.profileText)
		{
			num = OP.OperationData.TextData.TextWidth;
			num2 = OP.OperationData.TextData.TextHeight;
			num3 = OP.OperationData.TextData.TextAngle;
		}
		if (OP.OperationData.Action == actionTypeBU.profileWireText)
		{
			num = OP.OperationData.TextData.TextWidth;
			num2 = OP.OperationData.TextData.TextHeight;
			num3 = OP.OperationData.TextData.TextAngle;
		}
		if (OP.OperationData.Action == actionTypeBU.profileFreeDraw)
		{
			num = OP.OperationData.FreeDrawData.FreeDrawWidth;
			num2 = OP.OperationData.FreeDrawData.FreeDrawHeight;
			num3 = OP.OperationData.FreeDrawData.FreeDrawAngle;
		}
		if (OP.OperationData.Action == actionTypeBU.profileNotch)
		{
			num = OP.OperationData.NotchData.NotchWidth;
			num2 = OP.OperationData.NotchData.NotchHeight;
		}
		double num4 = OP.OperationData.Position.X;
		if (curItem.XReferanceLocation == LeftRightType.Right)
		{
			num4 = curItem.Length - OP.OperationData.Position.X;
		}
		if (OP.OperationData.Action != actionTypeBU.profileNotch)
		{
			if (OP.OperationData.selectedPlaneName != planeNames.Free)
			{
				if (num > 0.0)
				{
					point3D = new Point3D(num4 - num / 2.0, 0.0, 0.0);
					point3D2 = new Point3D(num4 + num / 2.0, 0.0, 0.0);
					if ((OP.OperationData.selectedPlaneName == planeNames.Top) | (OP.OperationData.selectedPlaneName == planeNames.Bottom))
					{
						point3D.Y = OP.OperationData.Position.Y;
						point3D2.Y = OP.OperationData.Position.Y;
						point3D.Z = OP.ProfileHeight + 1.0;
						point3D2.Z = OP.ProfileHeight + 1.0;
						point3D3 = new Point3D((point3D.X + point3D2.X) / 2.0, OP.MaxPoint.Y + 10.0, point3D2.Z);
					}
					if ((OP.OperationData.selectedPlaneName == planeNames.Front) | (OP.OperationData.selectedPlaneName == planeNames.Back))
					{
						point3D.Y = 0.0 - OP.ProfileWidth - 1.0;
						point3D2.Y = 0.0 - OP.ProfileWidth - 1.0;
						point3D.Z = OP.OperationData.Position.Z;
						point3D2.Z = OP.OperationData.Position.Z;
						point3D3 = new Point3D((point3D.X + point3D2.X) / 2.0, 0.0, OP.MaxPoint.Z + 10.0);
					}
					if (OP.OperationData.Action == actionTypeBU.profileBarrel)
					{
						point3D.X += OP.OperationData.BarelData.BarrelDiameter;
						point3D2.X += OP.OperationData.BarelData.BarrelDiameter;
						point3D3.X += OP.OperationData.BarelData.BarrelDiameter;
					}
				}
				if (num2 > 0.0)
				{
					point3D4 = new Point3D(OP.MinPoint.X, 0.0, 0.0);
					point3D5 = new Point3D(OP.MinPoint.X, 0.0, 0.0);
					if ((OP.OperationData.selectedPlaneName == planeNames.Top) | (OP.OperationData.selectedPlaneName == planeNames.Bottom))
					{
						point3D4.Y = OP.OperationData.Position.Y - num2 / 2.0;
						point3D5.Y = OP.OperationData.Position.Y + num2 / 2.0;
						point3D4.Z = OP.ProfileHeight + 1.0;
						point3D5.Z = OP.ProfileHeight + 1.0;
						point3D6 = new Point3D(point3D4.X - 20.0, (point3D4.Y + point3D5.Y) / 2.0, point3D4.Z);
					}
					if ((OP.OperationData.selectedPlaneName == planeNames.Front) | (OP.OperationData.selectedPlaneName == planeNames.Back))
					{
						point3D4.Y = 0.0 - OP.ProfileWidth - 1.0;
						point3D5.Y = 0.0 - OP.ProfileWidth - 1.0;
						point3D4.Z = OP.OperationData.Position.Z - num2 / 2.0;
						point3D5.Z = OP.OperationData.Position.Z + num2 / 2.0;
						point3D6 = new Point3D(point3D4.X - 20.0, 0.0 - OP.ProfileWidth - 1.0, (point3D4.Z + point3D5.Z) / 2.0);
					}
				}
				if (num > 0.0)
				{
					buCall.buVector5_0.AlignedDimCalculate(point3D, point3D2, point3D3, 10.0, OP.OperationData.selectedPlane, ref drawingPlane);
					buLinearDim2 = new buLinearDim(drawingPlane, point3D, point3D2, point3D3, 10.0);
					if (num3 != 0.0)
					{
						buLinearDim2.Rotate(num3, OP.OperationData.selectedPlane.Equation);
					}
					dimensionGroup = new DimensionGroup(buLinearDim2, ShapeDataValueType.Width);
					if (OP.OperationData.Action == actionTypeBU.profileNotch && OP.OperationData.NotchData.NotchOPType == ProfileNotchOperationType.Side)
					{
						dimensionGroup.PlaneType = planeNames.Front;
						dimensionGroup.UsePlaneType = true;
					}
					OP.EntityDimension.Add(dimensionGroup);
				}
				if (num2 > 0.0)
				{
					buCall.buVector5_0.AlignedDimCalculate(point3D4, point3D5, point3D6, 10.0, OP.OperationData.selectedPlane, ref drawingPlane);
					buLinearDim2 = new buLinearDim(drawingPlane, point3D4, point3D5, point3D6, 10.0);
					if (num3 != 0.0)
					{
						buLinearDim2.Rotate(num3, OP.OperationData.selectedPlane.Equation);
					}
					dimensionGroup = new DimensionGroup(buLinearDim2, ShapeDataValueType.Height);
					if (OP.OperationData.Action == actionTypeBU.profileNotch && OP.OperationData.NotchData.NotchOPType == ProfileNotchOperationType.Side)
					{
						dimensionGroup.PlaneType = planeNames.Front;
						dimensionGroup.UsePlaneType = true;
					}
					OP.EntityDimension.Add(dimensionGroup);
				}
				if (OP.OperationData.Action == actionTypeBU.profileBarrel && OP.OperationData.BarelData.BarrelDiameter > 0.0)
				{
					point3D4 = new Point3D(OP.MinPoint.X, 0.0, 0.0);
					point3D5 = new Point3D(OP.MinPoint.X, 0.0, 0.0);
					if ((OP.OperationData.selectedPlaneName == planeNames.Top) | (OP.OperationData.selectedPlaneName == planeNames.Bottom))
					{
						point3D4.Y = OP.OperationData.Position.Y - OP.OperationData.BarelData.BarrelDiameter / 2.0;
						point3D5.Y = OP.OperationData.Position.Y + OP.OperationData.BarelData.BarrelDiameter / 2.0;
						point3D4.Z = OP.ProfileHeight + 1.0;
						point3D5.Z = OP.ProfileHeight + 1.0;
						point3D6 = new Point3D(point3D4.X - 20.0, (point3D4.Y + point3D5.Y) / 2.0, point3D4.Z);
					}
					if ((OP.OperationData.selectedPlaneName == planeNames.Front) | (OP.OperationData.selectedPlaneName == planeNames.Back))
					{
						point3D4.Y = 0.0 - OP.ProfileWidth - 1.0;
						point3D5.Y = 0.0 - OP.ProfileWidth - 1.0;
						point3D4.Z = OP.OperationData.Position.Z - OP.OperationData.BarelData.BarrelDiameter / 2.0;
						point3D5.Z = OP.OperationData.Position.Z + OP.OperationData.BarelData.BarrelDiameter / 2.0;
						point3D6 = new Point3D(point3D4.X - 20.0, 0.0 - OP.ProfileWidth - 1.0, (point3D4.Z + point3D5.Z) / 2.0);
					}
					buCall.buVector5_0.AlignedDimCalculate(point3D4, point3D5, point3D6, 10.0, OP.OperationData.selectedPlane, ref drawingPlane);
					buLinearDim2 = new buLinearDim(drawingPlane, point3D4, point3D5, point3D6, 10.0);
					buLinearDim2.Rotate(OP.OperationData.RectangleData.RectangleAngle, OP.OperationData.selectedPlane.Equation);
					dimensionGroup = new DimensionGroup(buLinearDim2, ShapeDataValueType.HeadDiameter);
					OP.EntityDimension.Add(dimensionGroup);
				}
				return;
			}
			if (num > 0.0)
			{
				point3D = new Point3D((0.0 - num) / 2.0, 0.0, 0.0);
				point3D2 = new Point3D(num / 2.0, 0.0, 0.0);
				if (OP.OperationData.Action == actionTypeBU.profileBarrel)
				{
					point3D = new Point3D((0.0 - num) / 2.0 + OP.OperationData.BarelData.BarrelDiameter / 1.0, 0.0, 0.0);
					point3D2 = new Point3D(num / 2.0 + OP.OperationData.BarelData.BarrelDiameter / 1.0, 0.0, 0.0);
				}
				point3D3 = new Point3D((point3D.X + point3D2.X) / 2.0, 0.0, 0.0);
				point3D = OP.OperationData.selectedPlane.PointAt(new Point2D(point3D.X, point3D.Y));
				point3D2 = OP.OperationData.selectedPlane.PointAt(new Point2D(point3D2.X, point3D2.Y));
				point3D3 = OP.OperationData.selectedPlane.PointAt(new Point2D(point3D3.X, point3D3.Y - num2 / 2.0 - 10.0));
				buCall.buVector5_0.AlignedDimCalculate(point3D, point3D2, point3D3, 10.0, OP.OperationData.selectedPlane, ref drawingPlane);
				buLinearDim2 = new buLinearDim(drawingPlane, point3D, point3D2, point3D3, 10.0);
				if (num3 != 0.0)
				{
					buLinearDim2.Rotate(num3, OP.OperationData.selectedPlane.Equation);
				}
				dimensionGroup = new DimensionGroup(buLinearDim2, ShapeDataValueType.Width);
				OP.EntityDimension.Add(dimensionGroup);
			}
			if (num2 > 0.0)
			{
				point3D4 = new Point3D(0.0, (0.0 - num2) / 2.0, 0.0);
				point3D5 = new Point3D(0.0, num2 / 2.0, 0.0);
				point3D6 = new Point3D(0.0, 0.0, 0.0);
				point3D4 = OP.OperationData.selectedPlane.PointAt(new Point2D(point3D4.X, point3D4.Y));
				point3D5 = OP.OperationData.selectedPlane.PointAt(new Point2D(point3D5.X, point3D5.Y));
				point3D6 = OP.OperationData.selectedPlane.PointAt(new Point2D(point3D6.X - 20.0, point3D6.Y));
				point3D4 -= OP.OperationData.selectedPlane.AxisY * (OP.OperationData.Position.Y - selectedFreePlaneLength / 2.0);
				point3D5 -= OP.OperationData.selectedPlane.AxisY * (OP.OperationData.Position.Y - selectedFreePlaneLength / 2.0);
				point3D6 = point3D3 - OP.OperationData.selectedPlane.AxisY * (OP.OperationData.Position.Y - selectedFreePlaneLength / 2.0);
				point3D6.X = (0.0 - num) / 2.0 - 10.0;
				buCall.buVector5_0.AlignedDimCalculate(point3D4, point3D5, point3D6, 10.0, OP.OperationData.selectedPlane, ref drawingPlane);
				buLinearDim2 = new buLinearDim(drawingPlane, point3D4, point3D5, point3D6, 10.0);
				if (num3 != 0.0)
				{
					buLinearDim2.Rotate(num3, OP.OperationData.selectedPlane.Equation);
				}
				dimensionGroup = new DimensionGroup(buLinearDim2, ShapeDataValueType.Height);
				OP.EntityDimension.Add(dimensionGroup);
			}
			if (OP.OperationData.Action == actionTypeBU.profileBarrel && OP.OperationData.BarelData.BarrelDiameter > 0.0)
			{
				point3D4 = new Point3D(0.0, (0.0 - OP.OperationData.BarelData.BarrelDiameter) / 2.0, 0.0);
				point3D5 = new Point3D(0.0, OP.OperationData.BarelData.BarrelDiameter / 2.0, 0.0);
				point3D6 = new Point3D(0.0, 0.0, 0.0);
				point3D4 = OP.OperationData.selectedPlane.PointAt(new Point2D(point3D4.X, point3D4.Y));
				point3D5 = OP.OperationData.selectedPlane.PointAt(new Point2D(point3D5.X, point3D5.Y));
				point3D6 = OP.OperationData.selectedPlane.PointAt(new Point2D(point3D6.X, point3D6.Y));
				point3D4 -= OP.OperationData.selectedPlane.AxisY * (OP.OperationData.Position.Y - selectedFreePlaneLength / 2.0);
				point3D5 -= OP.OperationData.selectedPlane.AxisY * (OP.OperationData.Position.Y - selectedFreePlaneLength / 2.0);
				point3D6 = point3D3 - OP.OperationData.selectedPlane.AxisY * (OP.OperationData.Position.Y - selectedFreePlaneLength / 2.0);
				point3D6.X = (0.0 - num) / 2.0 - 10.0;
				buCall.buVector5_0.AlignedDimCalculate(point3D4, point3D5, point3D6, 10.0, OP.OperationData.selectedPlane, ref drawingPlane);
				buLinearDim2 = new buLinearDim(drawingPlane, point3D4, point3D5, point3D6, 10.0);
				if (num3 != 0.0)
				{
					buLinearDim2.Rotate(num3, OP.OperationData.selectedPlane.Equation);
				}
				dimensionGroup = new DimensionGroup(buLinearDim2, ShapeDataValueType.HeadDiameter);
				OP.EntityDimension.Add(dimensionGroup);
			}
		}
		else
		{
			OperationNotchDimensionEntities(ref OP, curItem, selectedFreePlaneLength);
		}
	}

	public void OperationNotchDimensionEntities(ref ProfileOperation OP, ProfileItem curItem, double selectedFreePlaneLength)
	{
		Point3D point3D = null;
		Point3D point3D2 = null;
		Point3D point3D3 = null;
		Plane drawingPlane = null;
		DimensionGroup dimensionGroup = null;
		buLinearDim buLinearDim2 = null;
		double num = 0.0;
		double num2 = 0.0;
		double x = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double notchWidth = OP.OperationData.NotchData.NotchWidth;
		double notchHeight = OP.OperationData.NotchData.NotchHeight;
		double notchDepth = OP.OperationData.NotchData.NotchDepth;
		double num7 = OP.OperationData.NotchData.NotchStart;
		if (OP.OperationData.NotchData.NotchOPType == ProfileNotchOperationType.Side)
		{
			num3 = 0.0 - OP.ProfileWidth - 1.0;
			if (OP.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Left)
			{
				num = 0.0;
				x = -20.0;
			}
			if (OP.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Right)
			{
				num = OP.ProfileLength;
				x = OP.ProfileLength + 20.0;
			}
			if (notchHeight > 0.0)
			{
				if (OP.OperationData.NotchData.NotchUpDown == UpDownLocationType.Up)
				{
					num5 = OP.ProfileHeight - OP.OperationData.NotchData.NotchStart;
					num6 = OP.ProfileHeight - OP.OperationData.NotchData.NotchStart - OP.OperationData.NotchData.NotchHeight;
				}
				if (OP.OperationData.NotchData.NotchUpDown == UpDownLocationType.Down)
				{
					num5 = OP.OperationData.NotchData.NotchStart;
					num6 = OP.OperationData.NotchData.NotchStart + OP.OperationData.NotchData.NotchHeight;
				}
				point3D = new Point3D(num, num3, num5);
				point3D2 = new Point3D(num, num3, num6);
				point3D3 = new Point3D(x, num3, (num5 + num6) / 2.0);
				buCall.buVector5_0.AlignedDimCalculate(point3D, point3D2, point3D3, 10.0, Plane.XZ, ref drawingPlane);
				buLinearDim2 = new buLinearDim(drawingPlane, point3D, point3D2, point3D3, 10.0);
				dimensionGroup = new DimensionGroup(buLinearDim2, ShapeDataValueType.Distance);
				dimensionGroup.PlaneType = planeNames.Front;
				dimensionGroup.UsePlaneType = true;
				OP.EntityDimension.Add(dimensionGroup);
			}
			if (num7 >= 0.0)
			{
				string textOverride = "";
				if (num7 == 0.0)
				{
					num7 = 0.1;
					textOverride = "0";
				}
				if (OP.OperationData.NotchData.NotchUpDown == UpDownLocationType.Up)
				{
					num5 = OP.ProfileHeight;
					num6 = OP.ProfileHeight - num7;
				}
				if (OP.OperationData.NotchData.NotchUpDown == UpDownLocationType.Down)
				{
					num5 = 0.0;
					num6 = num7;
				}
				point3D = new Point3D(num, num3, num5);
				point3D2 = new Point3D(num, num3, num6);
				point3D3 = new Point3D(x, num3, (num5 + num6) / 2.0);
				buCall.buVector5_0.AlignedDimCalculate(point3D, point3D2, point3D3, 10.0, Plane.XZ, ref drawingPlane);
				buLinearDim2 = new buLinearDim(drawingPlane, point3D, point3D2, point3D3, 10.0);
				buLinearDim2.TextOverride = textOverride;
				dimensionGroup = new DimensionGroup(buLinearDim2, ShapeDataValueType.Height);
				dimensionGroup.PlaneType = planeNames.Front;
				dimensionGroup.UsePlaneType = true;
				OP.EntityDimension.Add(dimensionGroup);
			}
			if (notchDepth > 0.0)
			{
				if (OP.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Left)
				{
					num = 0.0;
					num2 = notchDepth;
				}
				if (OP.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Right)
				{
					num = OP.ProfileLength;
					num2 = OP.ProfileLength - notchDepth;
				}
				x = (num + num2) / 2.0;
				if (OP.OperationData.NotchData.NotchUpDown == UpDownLocationType.Up)
				{
					num5 = OP.ProfileHeight - OP.OperationData.NotchData.NotchStart - OP.OperationData.NotchData.NotchHeight;
					num6 = num5 - 10.0;
				}
				if (OP.OperationData.NotchData.NotchUpDown == UpDownLocationType.Down)
				{
					num5 = OP.OperationData.NotchData.NotchStart + OP.OperationData.NotchData.NotchHeight;
					num6 = num5 + 10.0;
				}
				point3D = new Point3D(num, num3, num5);
				point3D2 = new Point3D(num2, num3, num5);
				point3D3 = new Point3D(x, num3, num6);
				buCall.buVector5_0.AlignedDimCalculate(point3D, point3D2, point3D3, 10.0, Plane.XZ, ref drawingPlane);
				buLinearDim2 = new buLinearDim(drawingPlane, point3D, point3D2, point3D3, 10.0);
				dimensionGroup = new DimensionGroup(buLinearDim2, ShapeDataValueType.Width);
				dimensionGroup.PlaneType = planeNames.Front;
				dimensionGroup.UsePlaneType = true;
				OP.EntityDimension.Add(dimensionGroup);
			}
		}
		if (OP.OperationData.NotchData.NotchOPType == ProfileNotchOperationType.Vertical)
		{
			num3 = 0.0 - OP.ProfileWidth - 1.0;
			if (OP.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Left)
			{
				num = 0.0;
				x = -20.0;
			}
			if (OP.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Right)
			{
				num = OP.ProfileLength;
				x = OP.ProfileLength + 20.0;
			}
			if (notchHeight > 0.0)
			{
				if (OP.OperationData.NotchData.NotchFrontBack == FrontBackType.Front)
				{
					num3 = 0.0 - OP.ProfileHeight + num7;
					num4 = 0.0 - OP.ProfileHeight + num7 + notchHeight;
				}
				if (OP.OperationData.NotchData.NotchFrontBack == FrontBackType.Back)
				{
					num3 = 0.0 - num7;
					num4 = 0.0 - num7 - notchHeight;
				}
				num5 = OP.ProfileHeight;
				point3D = new Point3D(num, num4, num5);
				point3D2 = new Point3D(num, num3, num5);
				point3D3 = new Point3D(num, (num3 + num4) / 2.0, num5 + 10.0);
				buCall.buVector5_0.AlignedDimCalculate(point3D, point3D2, point3D3, 10.0, Plane.YZ, ref drawingPlane);
				drawingPlane.Rotate(buConversion5.DegreeToRadian(180.0), Vector3D.AxisZ);
				buLinearDim2 = new buLinearDim(drawingPlane, point3D, point3D2, point3D3, 10.0);
				dimensionGroup = new DimensionGroup(buLinearDim2, ShapeDataValueType.Distance);
				dimensionGroup.PlaneType = planeNames.Left;
				dimensionGroup.UsePlaneType = true;
				OP.EntityDimension.Add(dimensionGroup);
			}
			if (num7 >= 0.0)
			{
				string textOverride2 = "";
				if (num7 == 0.0)
				{
					num7 = 0.1;
					textOverride2 = "0";
				}
				if (OP.OperationData.NotchData.NotchFrontBack == FrontBackType.Front)
				{
					num3 = 0.0 - OP.ProfileHeight;
					num4 = 0.0 - OP.ProfileHeight + num7;
				}
				if (OP.OperationData.NotchData.NotchFrontBack == FrontBackType.Back)
				{
					num3 = 0.0;
					num4 = 0.0 - num7;
				}
				num5 = OP.ProfileHeight;
				point3D = new Point3D(num, num4, num5);
				point3D2 = new Point3D(num, num3, num5);
				point3D3 = new Point3D(num, (num3 + num4) / 2.0, num5 + 10.0);
				buCall.buVector5_0.AlignedDimCalculate(point3D, point3D2, point3D3, 10.0, Plane.YZ, ref drawingPlane);
				drawingPlane.Rotate(buConversion5.DegreeToRadian(180.0), Vector3D.AxisZ);
				buLinearDim2 = new buLinearDim(drawingPlane, point3D, point3D2, point3D3, 10.0);
				buLinearDim2.TextOverride = textOverride2;
				dimensionGroup = new DimensionGroup(buLinearDim2, ShapeDataValueType.Height);
				dimensionGroup.PlaneType = planeNames.Left;
				dimensionGroup.UsePlaneType = true;
				OP.EntityDimension.Add(dimensionGroup);
			}
			if (notchDepth > 0.0)
			{
				num3 = 0.0 - OP.ProfileWidth - 1.0;
				if (OP.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Left)
				{
					num = 0.0;
					num2 = notchDepth;
				}
				if (OP.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Right)
				{
					num = OP.ProfileLength;
					num2 = OP.ProfileLength - notchDepth;
				}
				x = (num + num2) / 2.0;
				if (OP.OperationData.NotchData.NotchUpDown == UpDownLocationType.Up)
				{
					num5 = OP.ProfileHeight - OP.OperationData.NotchData.NotchStart - OP.OperationData.NotchData.NotchHeight;
					num6 = num5 - 10.0;
				}
				if (OP.OperationData.NotchData.NotchUpDown == UpDownLocationType.Down)
				{
					num5 = OP.OperationData.NotchData.NotchStart + OP.OperationData.NotchData.NotchHeight;
					num6 = num5 + 10.0;
				}
				point3D = new Point3D(num, num3, num5);
				point3D2 = new Point3D(num2, num3, num5);
				point3D3 = new Point3D(x, num3, num6);
				buCall.buVector5_0.AlignedDimCalculate(point3D, point3D2, point3D3, 10.0, Plane.XZ, ref drawingPlane);
				buLinearDim2 = new buLinearDim(drawingPlane, point3D, point3D2, point3D3, 10.0);
				dimensionGroup = new DimensionGroup(buLinearDim2, ShapeDataValueType.Width);
				dimensionGroup.PlaneType = planeNames.Front;
				dimensionGroup.UsePlaneType = true;
				OP.EntityDimension.Add(dimensionGroup);
			}
		}
		if (OP.OperationData.NotchData.NotchOPType == ProfileNotchOperationType.Length)
		{
			num3 = 0.0 - OP.ProfileWidth - 1.0;
			if (curItem.XReferanceLocation == LeftRightType.Left)
			{
				num = OP.OperationData.Position.X;
				num2 = num + notchWidth;
			}
			if (curItem.XReferanceLocation == LeftRightType.Right)
			{
				num = curItem.Length - OP.OperationData.Position.X - notchWidth;
				num2 = num + notchWidth;
			}
			if (notchHeight > 0.0)
			{
				if (OP.OperationData.NotchData.NotchUpDown == UpDownLocationType.Up)
				{
					num5 = OP.ProfileHeight - OP.OperationData.NotchData.NotchStart;
					num6 = OP.ProfileHeight - OP.OperationData.NotchData.NotchStart - OP.OperationData.NotchData.NotchHeight;
				}
				if (OP.OperationData.NotchData.NotchUpDown == UpDownLocationType.Down)
				{
					num5 = OP.OperationData.NotchData.NotchStart;
					num6 = OP.OperationData.NotchData.NotchStart + OP.OperationData.NotchData.NotchHeight;
				}
				point3D = new Point3D(num, num3, num5);
				point3D2 = new Point3D(num, num3, num6);
				point3D3 = new Point3D(num - 10.0, num3, (num5 + num6) / 2.0);
				buCall.buVector5_0.AlignedDimCalculate(point3D, point3D2, point3D3, 10.0, Plane.XZ, ref drawingPlane);
				buLinearDim2 = new buLinearDim(drawingPlane, point3D, point3D2, point3D3, 10.0);
				dimensionGroup = new DimensionGroup(buLinearDim2, ShapeDataValueType.Height);
				dimensionGroup.PlaneType = planeNames.Front;
				dimensionGroup.UsePlaneType = true;
				OP.EntityDimension.Add(dimensionGroup);
			}
			if (notchWidth > 0.0)
			{
				x = (num + num2) / 2.0;
				if (OP.OperationData.NotchData.NotchUpDown == UpDownLocationType.Up)
				{
					num5 = OP.ProfileHeight - OP.OperationData.NotchData.NotchStart - OP.OperationData.NotchData.NotchHeight;
					num6 = num5 - 10.0;
				}
				if (OP.OperationData.NotchData.NotchUpDown == UpDownLocationType.Down)
				{
					num5 = OP.OperationData.NotchData.NotchStart + OP.OperationData.NotchData.NotchHeight;
					num6 = num5 + 10.0;
				}
				point3D = new Point3D(num, num3, num5);
				point3D2 = new Point3D(num2, num3, num5);
				point3D3 = new Point3D(x, num3, num6);
				buCall.buVector5_0.AlignedDimCalculate(point3D, point3D2, point3D3, 10.0, Plane.XZ, ref drawingPlane);
				buLinearDim2 = new buLinearDim(drawingPlane, point3D, point3D2, point3D3, 10.0);
				dimensionGroup = new DimensionGroup(buLinearDim2, ShapeDataValueType.Width);
				dimensionGroup.PlaneType = planeNames.Front;
				dimensionGroup.UsePlaneType = true;
				OP.EntityDimension.Add(dimensionGroup);
			}
			if (notchDepth > 0.0)
			{
				if (OP.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Front)
				{
					num3 = 0.0 - OP.ProfileWidth;
					num4 = 0.0 - OP.ProfileWidth + notchDepth;
				}
				if (OP.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Back)
				{
					num3 = 0.0;
					num4 = 0.0 - notchDepth;
				}
				if (OP.OperationData.NotchData.NotchUpDown == UpDownLocationType.Up)
				{
					num5 = OP.ProfileHeight - OP.OperationData.NotchData.NotchStart - OP.OperationData.NotchData.NotchHeight;
					num6 = num5 - 10.0;
				}
				if (OP.OperationData.NotchData.NotchUpDown == UpDownLocationType.Down)
				{
					num5 = OP.OperationData.NotchData.NotchStart + OP.OperationData.NotchData.NotchHeight;
					num6 = num5 + 10.0;
				}
				point3D = new Point3D(0.0, num3, num5);
				point3D2 = new Point3D(0.0, num4, num5);
				point3D3 = new Point3D(x, num3, num6);
				buCall.buVector5_0.AlignedDimCalculate(point3D, point3D2, point3D3, 10.0, Plane.YZ, ref drawingPlane);
				drawingPlane.Rotate(buConversion5.DegreeToRadian(180.0), Vector3D.AxisZ);
				buLinearDim2 = new buLinearDim(drawingPlane, point3D, point3D2, point3D3, 10.0);
				dimensionGroup = new DimensionGroup(buLinearDim2, ShapeDataValueType.Distance);
				dimensionGroup.PlaneType = planeNames.Left;
				dimensionGroup.UsePlaneType = true;
				OP.EntityDimension.Add(dimensionGroup);
			}
		}
		if (OP.OperationData.NotchData.NotchOPType != ProfileNotchOperationType.Horizontal)
		{
			return;
		}
		num3 = 0.0 - OP.ProfileWidth - 1.0;
		if (curItem.XReferanceLocation == LeftRightType.Left)
		{
			num = OP.OperationData.Position.X;
			num2 = num + notchWidth;
		}
		if (curItem.XReferanceLocation == LeftRightType.Right)
		{
			num = curItem.Length - OP.OperationData.Position.X - notchWidth;
			num2 = num + notchWidth;
		}
		if (notchHeight > 0.0)
		{
			if (OP.OperationData.NotchData.NotchUpDown == UpDownLocationType.Up)
			{
				num5 = OP.ProfileHeight - OP.OperationData.NotchData.NotchStart;
				num6 = OP.ProfileHeight - OP.OperationData.NotchData.NotchStart - OP.OperationData.NotchData.NotchHeight;
			}
			if (OP.OperationData.NotchData.NotchUpDown == UpDownLocationType.Down)
			{
				num5 = OP.OperationData.NotchData.NotchStart;
				num6 = OP.OperationData.NotchData.NotchStart + OP.OperationData.NotchData.NotchHeight;
			}
			point3D = new Point3D(num, num3, num5);
			point3D2 = new Point3D(num, num3, num6);
			point3D3 = new Point3D(num - 10.0, num3, (num5 + num6) / 2.0);
			buCall.buVector5_0.AlignedDimCalculate(point3D, point3D2, point3D3, 10.0, Plane.XZ, ref drawingPlane);
			buLinearDim2 = new buLinearDim(drawingPlane, point3D, point3D2, point3D3, 10.0);
			dimensionGroup = new DimensionGroup(buLinearDim2, ShapeDataValueType.Height);
			dimensionGroup.PlaneType = planeNames.Front;
			dimensionGroup.UsePlaneType = true;
			OP.EntityDimension.Add(dimensionGroup);
		}
		if (notchWidth > 0.0)
		{
			x = (num + num2) / 2.0;
			if (OP.OperationData.NotchData.NotchUpDown == UpDownLocationType.Up)
			{
				num5 = OP.ProfileHeight - OP.OperationData.NotchData.NotchStart - OP.OperationData.NotchData.NotchHeight;
				num6 = num5 - 10.0;
			}
			if (OP.OperationData.NotchData.NotchUpDown == UpDownLocationType.Down)
			{
				num5 = OP.OperationData.NotchData.NotchStart + OP.OperationData.NotchData.NotchHeight;
				num6 = num5 + 10.0;
			}
			point3D = new Point3D(num, num3, num5);
			point3D2 = new Point3D(num2, num3, num5);
			point3D3 = new Point3D(x, num3, num6);
			buCall.buVector5_0.AlignedDimCalculate(point3D, point3D2, point3D3, 10.0, Plane.XZ, ref drawingPlane);
			buLinearDim2 = new buLinearDim(drawingPlane, point3D, point3D2, point3D3, 10.0);
			dimensionGroup = new DimensionGroup(buLinearDim2, ShapeDataValueType.Width);
			dimensionGroup.PlaneType = planeNames.Front;
			dimensionGroup.UsePlaneType = true;
			OP.EntityDimension.Add(dimensionGroup);
		}
		if (notchDepth > 0.0)
		{
			if (OP.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Front)
			{
				num3 = 0.0 - OP.ProfileWidth;
				num4 = 0.0 - OP.ProfileWidth + notchDepth;
			}
			if (OP.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Back)
			{
				num3 = 0.0;
				num4 = 0.0 - notchDepth;
			}
			if (OP.OperationData.NotchData.NotchUpDown == UpDownLocationType.Up)
			{
				num5 = OP.ProfileHeight - OP.OperationData.NotchData.NotchStart - OP.OperationData.NotchData.NotchHeight;
				num6 = num5 - 10.0;
			}
			if (OP.OperationData.NotchData.NotchUpDown == UpDownLocationType.Down)
			{
				num5 = OP.OperationData.NotchData.NotchStart + OP.OperationData.NotchData.NotchHeight;
				num6 = num5 + 10.0;
			}
			point3D = new Point3D(0.0, num3, num5);
			point3D2 = new Point3D(0.0, num4, num5);
			point3D3 = new Point3D(x, num3, num6);
			buCall.buVector5_0.AlignedDimCalculate(point3D, point3D2, point3D3, 10.0, Plane.YZ, ref drawingPlane);
			drawingPlane.Rotate(buConversion5.DegreeToRadian(180.0), Vector3D.AxisZ);
			buLinearDim2 = new buLinearDim(drawingPlane, point3D, point3D2, point3D3, 10.0);
			dimensionGroup = new DimensionGroup(buLinearDim2, ShapeDataValueType.Distance);
			dimensionGroup.PlaneType = planeNames.Left;
			dimensionGroup.UsePlaneType = true;
			OP.EntityDimension.Add(dimensionGroup);
		}
	}

	public void CreateDimensionEntity(ProfileOperation OP, ProfileItem curItem, ShapeDataValueType ValueType, MaterialBase5 Material, Point3D CornerPoint, ref Entity dimEntity, ref viewType ViewType, ref Plane viewPlane, double TextHeight = 20.0)
	{
		try
		{
			Point3D point3D = null;
			Point3D point3D2 = null;
			Point3D point3D3 = null;
			Point3D point3D4 = null;
			string text = "";
			Plane drawingPlane = null;
			if (!((OP.OperationData.selectedPlaneName == planeNames.Top) | (OP.OperationData.selectedPlaneName == planeNames.Bottom)))
			{
				if (!((OP.OperationData.selectedPlaneName == planeNames.Front) | (OP.OperationData.selectedPlaneName == planeNames.Back)))
				{
					if (OP.OperationData.selectedPlaneName == planeNames.Free)
					{
						point3D = OP.OperationData.selectedPlane.PointAt(new Point2D(OP.OperationData.Position.X, OP.OperationData.SelectedPlaneLength / 2.0 + OP.OperationData.Position.Y));
						point3D.X = OP.OperationData.Position.X;
					}
				}
				else
				{
					point3D = new Point3D(OP.OperationData.Position.X, OP.OperationData.Position.Y, OP.OperationData.Position.Z);
				}
			}
			else
			{
				point3D = new Point3D(OP.OperationData.Position.X, OP.OperationData.Position.Y, OP.OperationData.Position.Z);
			}
			if (OP.OperationData.Action != actionTypeBU.profileRectangle)
			{
			}
			if (OP.OperationData.Action != actionTypeBU.profileCircle)
			{
			}
			if (OP.OperationData.Action != actionTypeBU.profileHole)
			{
			}
			if (OP.OperationData.Action != actionTypeBU.profileTapping)
			{
			}
			if (OP.OperationData.Action != actionTypeBU.profileEllipse)
			{
			}
			if (OP.OperationData.Action != actionTypeBU.profileSlot)
			{
			}
			if (OP.OperationData.Action != actionTypeBU.profileBarrel)
			{
			}
			double x = OP.OperationData.Position.X;
			if (curItem.XReferanceLocation == LeftRightType.Right)
			{
				x = curItem.Length - OP.OperationData.Position.X;
			}
			if (ValueType == ShapeDataValueType.XPosition)
			{
				if (OP.OperationData.Action == actionTypeBU.profileNotch)
				{
					x = OP.OperationData.Position.X;
					CornerPoint.X = 0.0;
					if (curItem.XReferanceLocation == LeftRightType.Right)
					{
						x = curItem.Length - OP.OperationData.Position.X;
						CornerPoint.X = curItem.Length;
					}
				}
				if ((OP.OperationData.selectedPlaneName == planeNames.Top) | (OP.OperationData.selectedPlaneName == planeNames.Bottom))
				{
					point3D2 = new Point3D(x, 0.0 - Material.Size.Height, OP.OperationData.Position.Z);
					point3D3 = new Point3D(CornerPoint.X, 0.0 - Material.Size.Height, OP.OperationData.Position.Z);
					point3D4 = new Point3D((point3D2.X + point3D3.X) / 2.0, 10.0, point3D2.Z);
					buCall.buVector5_0.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, Plane.XY, ref drawingPlane);
					viewPlane = Plane.XY;
					ViewType = viewType.Top;
				}
				if ((OP.OperationData.selectedPlaneName == planeNames.Front) | (OP.OperationData.selectedPlaneName == planeNames.Back))
				{
					point3D2 = new Point3D(x, 0.0 - Material.Size.Height, OP.OperationData.Position.Z);
					point3D3 = new Point3D(CornerPoint.X, 0.0 - Material.Size.Height, OP.OperationData.Position.Z);
					point3D4 = new Point3D((point3D2.X + point3D3.X) / 2.0, point3D2.Y, Material.Size.Depth + 10.0);
					buCall.buVector5_0.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, Plane.XZ, ref drawingPlane);
					viewPlane = Plane.XY;
					ViewType = viewType.Front;
				}
				if (OP.OperationData.selectedPlaneName == planeNames.Free)
				{
					point3D2 = new Point3D(x, 0.0 - Material.Size.Height, OP.OperationData.Position.Z);
					point3D3 = new Point3D(CornerPoint.X, 0.0 - Material.Size.Height, OP.OperationData.Position.Z);
					point3D4 = new Point3D((point3D2.X + point3D3.X) / 2.0, 10.0, point3D2.Z);
					buCall.buVector5_0.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, OP.OperationData.selectedPlane, ref drawingPlane);
					viewPlane = (Plane)OP.OperationData.selectedPlane.Clone();
					ViewType = viewType.Top;
				}
				if (drawingPlane != null)
				{
					dimEntity = new LinearDim(drawingPlane, point3D2, point3D3, point3D4, TextHeight);
					dimEntity.Selected = true;
				}
			}
			if (ValueType == ShapeDataValueType.YPosition)
			{
				if ((OP.OperationData.selectedPlaneName == planeNames.Top) | (OP.OperationData.selectedPlaneName == planeNames.Bottom))
				{
					point3D2 = new Point3D(x, OP.OperationData.Position.Y, Material.Size.Depth);
					point3D3 = new Point3D(x, CornerPoint.Y, Material.Size.Depth);
					point3D4 = new Point3D(point3D2.X - 20.0, (point3D2.Y + point3D3.Y) / 2.0, point3D2.Z);
					buCall.buVector5_0.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, Plane.XY, ref drawingPlane);
					viewPlane = Plane.XY;
					ViewType = viewType.Top;
					if (drawingPlane != null)
					{
						dimEntity = new LinearDim(drawingPlane, point3D2, point3D3, point3D4, TextHeight);
					}
				}
				if (OP.OperationData.selectedPlaneName == planeNames.Free)
				{
					double num = OP.OperationData.Position.Y;
					if (num == 0.0)
					{
						num = 1.0;
					}
					point3D2 = OP.OperationData.selectedPlane.PointAt(new Point2D(OP.OperationData.Position.X, OP.OperationData.SelectedPlaneLength / 2.0));
					point3D2.X = x;
					point3D3 = OP.OperationData.selectedPlane.PointAt(new Point2D(OP.OperationData.Position.X, OP.OperationData.SelectedPlaneLength / 2.0 - num));
					point3D3.X = x;
					point3D4 = new Point3D(point3D2.X - 20.0, (point3D2.Y + point3D3.Y) / 2.0, (point3D2.Z + point3D3.Z) / 2.0);
					buCall.buVector5_0.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, OP.OperationData.selectedPlane, ref drawingPlane);
					viewPlane = (Plane)OP.OperationData.selectedPlane.Clone();
					ViewType = viewType.Top;
					if (drawingPlane != null)
					{
						dimEntity = new LinearDim(drawingPlane, point3D2, point3D3, point3D4, TextHeight);
						if (OP.OperationData.Position.Y == 0.0)
						{
							((LinearDim)dimEntity).TextOverride = "0";
						}
					}
				}
				if (dimEntity != null)
				{
					dimEntity.Selected = true;
				}
			}
			if (ValueType == ShapeDataValueType.ZPosition)
			{
				if ((OP.OperationData.selectedPlaneName == planeNames.Front) | (OP.OperationData.selectedPlaneName == planeNames.Back))
				{
					point3D2 = new Point3D(x, 0.0 - Material.Size.Height, OP.OperationData.Position.Z);
					point3D3 = new Point3D(x, 0.0 - Material.Size.Height, CornerPoint.Z);
					point3D4 = new Point3D(point3D2.X - 20.0, point3D2.Y, (point3D2.Z + point3D3.Z) / 2.0);
					buCall.buVector5_0.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, Plane.XZ, ref drawingPlane);
					viewPlane = Plane.XY;
					ViewType = viewType.Front;
				}
				if (OP.OperationData.selectedPlaneName == planeNames.Top && OP.OperationData.Action == actionTypeBU.profileNotch)
				{
					double x2 = OP.OperationData.Position.X;
					double num2 = OP.OperationData.NotchData.NotchStart;
					if (OP.OperationData.NotchData.NotchOPType == ProfileNotchOperationType.Length && curItem.XReferanceLocation == LeftRightType.Right)
					{
						x2 = curItem.Length - OP.OperationData.Position.X;
					}
					if (num2 == 0.0)
					{
						num2 = 0.1;
						text = "0";
					}
					if (OP.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Right)
					{
						x2 = Material.Size.Width;
					}
					if (OP.OperationData.NotchData.NotchUpDown == UpDownLocationType.Up)
					{
						point3D2 = new Point3D(x2, 0.0 - Material.Size.Height, Material.Size.Depth);
						point3D3 = new Point3D(x2, 0.0 - Material.Size.Height, Material.Size.Depth - num2);
					}
					if (OP.OperationData.NotchData.NotchUpDown == UpDownLocationType.Down)
					{
						point3D2 = new Point3D(x2, 0.0 - Material.Size.Height, 0.0);
						point3D3 = new Point3D(x2, 0.0 - Material.Size.Height, num2);
					}
					point3D4 = new Point3D(point3D2.X - 20.0, point3D2.Y, (point3D2.Z + point3D3.Z) / 2.0);
					buCall.buVector5_0.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, Plane.XZ, ref drawingPlane);
					viewPlane = Plane.XZ;
					ViewType = viewType.Front;
				}
				if (drawingPlane != null)
				{
					dimEntity = new LinearDim(drawingPlane, point3D2, point3D3, point3D4, TextHeight);
					dimEntity.Selected = true;
				}
			}
			if (ValueType == ShapeDataValueType.Width || ValueType == ShapeDataValueType.Height || ValueType == ShapeDataValueType.HeadDiameter || ValueType == ShapeDataValueType.Diameter || ValueType == ShapeDataValueType.Distance)
			{
				DimensionGroup dimensionGroup = null;
				for (int i = 0; i <= OP.EntityDimension.Count - 1; i++)
				{
					if (OP.EntityDimension[i].ShapeValueType == ValueType)
					{
						dimensionGroup = OP.EntityDimension[i];
						buEntity.Copy(OP.EntityDimension[i].dimEntity, ref dimEntity);
						dimEntity.Selected = true;
					}
				}
				if ((OP.OperationData.selectedPlaneName == planeNames.Top) | (OP.OperationData.selectedPlaneName == planeNames.Bottom))
				{
					viewPlane = Plane.XY;
					ViewType = viewType.Top;
				}
				if ((OP.OperationData.selectedPlaneName == planeNames.Front) | (OP.OperationData.selectedPlaneName == planeNames.Back))
				{
					viewPlane = Plane.XY;
					ViewType = viewType.Front;
				}
				if (OP.OperationData.selectedPlaneName == planeNames.Free)
				{
					viewPlane = (Plane)OP.OperationData.selectedPlane.Clone();
					ViewType = viewType.Top;
				}
				if (dimensionGroup != null && dimensionGroup.UsePlaneType)
				{
					if ((dimensionGroup.PlaneType == planeNames.Top) | (dimensionGroup.PlaneType == planeNames.Bottom))
					{
						viewPlane = Plane.XY;
						ViewType = viewType.Top;
					}
					if ((dimensionGroup.PlaneType == planeNames.Front) | (dimensionGroup.PlaneType == planeNames.Back))
					{
						viewPlane = Plane.XY;
						ViewType = viewType.Front;
					}
					if (dimensionGroup.PlaneType == planeNames.Left)
					{
						viewPlane = Plane.YZ;
						ViewType = viewType.Left;
					}
					if (dimensionGroup.PlaneType == planeNames.Right)
					{
						viewPlane = Plane.YZ;
						ViewType = viewType.Right;
					}
					if (dimensionGroup.PlaneType == planeNames.Free)
					{
						viewPlane = (Plane)OP.OperationData.selectedPlane.Clone();
						ViewType = viewType.Top;
					}
				}
			}
			if (ValueType == ShapeDataValueType.Depth)
			{
				double x3 = OP.MinPoint.X;
				if (curItem.XReferanceLocation == LeftRightType.Right)
				{
					x3 = curItem.Length - OP.MinPoint.X;
				}
				if ((OP.OperationData.selectedPlaneName == planeNames.Top) | (OP.OperationData.selectedPlaneName == planeNames.Bottom))
				{
					point3D2 = new Point3D(x3, 0.0 - Material.Size.Height, OP.MinPoint.Z + OP.OperationData.ExtraDepth);
					point3D3 = new Point3D(x3, 0.0 - Material.Size.Height, OP.MaxPoint.Z);
					point3D4 = new Point3D(point3D2.X - 20.0, point3D3.Y, (point3D2.Z + point3D3.Z) / 2.0);
					buCall.buVector5_0.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, Plane.XZ, ref drawingPlane);
					viewPlane = Plane.XY;
					ViewType = viewType.Front;
				}
				if (OP.OperationData.selectedPlaneName == planeNames.Front)
				{
					point3D2 = new Point3D(x3, OP.MinPoint.Y, Material.Size.Depth + 1.0);
					point3D3 = new Point3D(x3, OP.MaxPoint.Y - OP.OperationData.ExtraDepth, Material.Size.Depth + 1.0);
					point3D4 = new Point3D(point3D2.X - 20.0, (point3D2.Y + point3D3.Y) / 2.0, point3D3.Z);
					buCall.buVector5_0.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, Plane.XY, ref drawingPlane);
					viewPlane = Plane.XY;
					ViewType = viewType.Top;
				}
				if (OP.OperationData.selectedPlaneName == planeNames.Back)
				{
					point3D2 = new Point3D(x3, OP.MinPoint.Y + OP.OperationData.ExtraDepth, Material.Size.Depth + 1.0);
					point3D3 = new Point3D(x3, OP.MaxPoint.Y, Material.Size.Depth + 1.0);
					point3D4 = new Point3D(point3D2.X - 20.0, (point3D2.Y + point3D3.Y) / 2.0, point3D3.Z);
					buCall.buVector5_0.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, Plane.XY, ref drawingPlane);
					viewPlane = Plane.XY;
					ViewType = viewType.Top;
				}
				if (OP.OperationData.selectedPlaneName == planeNames.Free)
				{
					point3D2 = OP.OperationData.selectedPlane.PointAt(new Point2D(OP.OperationData.Position.X, OP.OperationData.SelectedPlaneLength / 2.0 + OP.OperationData.Position.Y));
					point3D2.X = OP.OperationData.Position.X;
					point3D3 = new Point3D();
					point3D3.Y = point3D2.Y + (0.0 - OP.OperationData.selectedPlane.AxisZ.Y) * OP.OperationData.ExternalDepth;
					point3D3.Z = point3D2.Z + (0.0 - OP.OperationData.selectedPlane.AxisZ.Z) * OP.OperationData.ExternalDepth;
					point3D3.X = OP.OperationData.Position.X;
					point3D4 = new Point3D(point3D2.X - 20.0, (point3D2.Y + point3D3.Y) / 2.0, (point3D2.Z + point3D3.Z) / 2.0);
					buCall.buVector5_0.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, Plane.XY, ref drawingPlane);
					if (drawingPlane != null)
					{
						viewPlane = (Plane)drawingPlane.Clone();
					}
					ViewType = viewType.Top;
				}
				if (drawingPlane != null)
				{
					dimEntity = new LinearDim(drawingPlane, point3D2, point3D3, point3D4, TextHeight);
					dimEntity.Selected = true;
				}
			}
			if (ValueType == ShapeDataValueType.ExtraDepth)
			{
				double num3 = OP.OperationData.ExtraDepth;
				if (num3 == 0.0)
				{
					num3 = 0.1;
				}
				double x4 = OP.MinPoint.X;
				if (curItem.XReferanceLocation == LeftRightType.Right)
				{
					x4 = curItem.Length - OP.MinPoint.X;
				}
				if ((OP.OperationData.selectedPlaneName == planeNames.Top) | (OP.OperationData.selectedPlaneName == planeNames.Bottom))
				{
					point3D2 = new Point3D(x4, 0.0 - Material.Size.Height, OP.MinPoint.Z + num3);
					point3D3 = new Point3D(x4, 0.0 - Material.Size.Height, OP.MinPoint.Z);
					point3D4 = new Point3D(point3D2.X - 20.0, point3D3.Y, (point3D2.Z + point3D3.Z) / 2.0);
					buCall.buVector5_0.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, Plane.XZ, ref drawingPlane);
					viewPlane = Plane.XY;
					ViewType = viewType.Front;
				}
				if (OP.OperationData.selectedPlaneName == planeNames.Front)
				{
					point3D2 = new Point3D(x4, OP.MaxPoint.Y - num3, Material.Size.Depth + 1.0);
					point3D3 = new Point3D(x4, OP.MaxPoint.Y, Material.Size.Depth + 1.0);
					point3D4 = new Point3D(point3D2.X - 20.0, (point3D2.Y + point3D3.Y) / 2.0, point3D3.Z);
					buCall.buVector5_0.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, Plane.XY, ref drawingPlane);
					viewPlane = Plane.XY;
					ViewType = viewType.Top;
				}
				if (OP.OperationData.selectedPlaneName == planeNames.Back)
				{
					point3D2 = new Point3D(x4, OP.MinPoint.Y + num3, Material.Size.Depth + 1.0);
					point3D3 = new Point3D(x4, OP.MinPoint.Y, Material.Size.Depth + 1.0);
					point3D4 = new Point3D(point3D2.X - 20.0, (point3D2.Y + point3D3.Y) / 2.0, point3D3.Z);
					buCall.buVector5_0.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, Plane.XY, ref drawingPlane);
					viewPlane = Plane.XY;
					ViewType = viewType.Top;
				}
				if (OP.OperationData.selectedPlaneName == planeNames.Free)
				{
					point3D2 = new Point3D();
					point3D2.Y = point3D.Y + (0.0 - OP.OperationData.selectedPlane.AxisZ.Y) * OP.OperationData.ExternalDepth;
					point3D2.Z = point3D.Z + (0.0 - OP.OperationData.selectedPlane.AxisZ.Z) * OP.OperationData.ExternalDepth;
					point3D2.X = OP.OperationData.Position.X;
					point3D3 = new Point3D();
					point3D3.Y = point3D.Y + (0.0 - OP.OperationData.selectedPlane.AxisZ.Y) * (OP.OperationData.ExternalDepth + OP.OperationData.ExtraDepth);
					point3D3.Z = point3D.Z + (0.0 - OP.OperationData.selectedPlane.AxisZ.Z) * (OP.OperationData.ExternalDepth + OP.OperationData.ExtraDepth);
					point3D3.X = OP.OperationData.Position.X;
					point3D4 = new Point3D(point3D2.X - 20.0, (point3D2.Y + point3D3.Y) / 2.0, (point3D2.Z + point3D3.Z) / 2.0);
					buCall.buVector5_0.AlignedDimCalculate(point3D2, point3D3, point3D4, TextHeight, Plane.XY, ref drawingPlane);
					if (drawingPlane != null)
					{
						viewPlane = (Plane)drawingPlane.Clone();
					}
					ViewType = viewType.Top;
				}
				if (drawingPlane != null)
				{
					dimEntity = new LinearDim(drawingPlane, point3D2, point3D3, point3D4, TextHeight);
					((LinearDim)dimEntity).TextOverride = OP.OperationData.ExtraDepth.ToString("f1");
					dimEntity.Selected = true;
				}
			}
			if (dimEntity != null)
			{
				dimEntity.Color = Color.Red;
				dimEntity.ColorMethod = colorMethodType.byEntity;
			}
			if (text.Length > 0 && dimEntity != null)
			{
				((Dimension)dimEntity).TextOverride = text;
			}
		}
		catch (Exception)
		{
		}
	}

	public bool isSameOperationAvailableInList(ProfileItem Item, ProfileOperation Operation)
	{
		for (int i = 0; i <= Item.Operations.Count - 1; i++)
		{
			ProfileOperationData operationData = Item.Operations[i].OperationData;
			ProfileOperationData operationData2 = Operation.OperationData;
			if ((operationData.OperationType == operationData2.OperationType) & (operationData.selectedPlaneName == operationData2.selectedPlaneName))
			{
				if (operationData2.OperationType == ProfileOperationTypes.Rectangle && (buCompare5.EQ(operationData2.RectangleData.RectangleWidth, operationData.RectangleData.RectangleWidth) & buCompare5.EQ(operationData2.RectangleData.RectangleHeight, operationData.RectangleData.RectangleHeight)) && (buCompare5.EQ(operationData2.RectangleData.RectangleAngle, operationData.RectangleData.RectangleAngle) & (operationData2.selectedPlaneName == operationData.selectedPlaneName)) && buCompare5.EQ(operationData2.Position, operationData.Position))
				{
					return true;
				}
				if (operationData2.OperationType == ProfileOperationTypes.RoundRectangle && (buCompare5.EQ(operationData2.RectangleRoundData.RoundRectangleWidth, operationData.RectangleRoundData.RoundRectangleWidth) & buCompare5.EQ(operationData2.RectangleRoundData.RoundRectangleHeight, operationData.RectangleRoundData.RoundRectangleHeight)) && (buCompare5.EQ(operationData2.RectangleRoundData.RoundRectangleAngle, operationData.RectangleRoundData.RoundRectangleAngle) & (operationData2.selectedPlaneName == operationData.selectedPlaneName)) && (buCompare5.EQ(operationData2.RectangleRoundData.RoundRectangleRadius, operationData.RectangleRoundData.RoundRectangleRadius) & buCompare5.EQ(operationData2.Position, operationData.Position)))
				{
					return true;
				}
				if (operationData2.OperationType == ProfileOperationTypes.Circle && (buCompare5.EQ(operationData2.CircleData.CircleDiameter, operationData.CircleData.CircleDiameter) & buCompare5.EQ(operationData2.Position, operationData.Position)))
				{
					return true;
				}
				if (operationData2.OperationType == ProfileOperationTypes.Barrel && (buCompare5.EQ(operationData2.BarelData.BarrelAngle, operationData.BarelData.BarrelAngle) & buCompare5.EQ(operationData2.BarelData.BarrelLength, operationData.BarelData.BarrelLength)) && (buCompare5.EQ(operationData2.BarelData.BarrelDiameter, operationData.BarelData.BarrelDiameter) & (operationData2.selectedPlaneName == operationData.selectedPlaneName)) && (buCompare5.EQ(operationData2.BarelData.BarrelWidth, operationData.BarelData.BarrelWidth) & buCompare5.EQ(operationData2.Position, operationData.Position)))
				{
					return true;
				}
				if (operationData2.OperationType == ProfileOperationTypes.Cut && (buCompare5.EQ(operationData2.CutData.CutAngle, operationData.CutData.CutAngle) & buCompare5.EQ(operationData2.CutData.CutDepth, operationData.CutData.CutDepth)) && (buCompare5.EQ(operationData2.CutData.CutHeigth, operationData.CutData.CutHeigth) & (operationData2.selectedPlaneName == operationData.selectedPlaneName)) && (buCompare5.EQ(operationData2.CutData.CutWidth, operationData.CutData.CutWidth) & buCompare5.EQ(operationData2.Position, operationData.Position)))
				{
					return true;
				}
				if (operationData2.OperationType == ProfileOperationTypes.Ellipse && (buCompare5.EQ(operationData2.EllipseData.EllipseAngle, operationData.EllipseData.EllipseAngle) & buCompare5.EQ(operationData2.EllipseData.EllipseHeight, operationData.EllipseData.EllipseHeight)) && (buCompare5.EQ(operationData2.EllipseData.EllipseWidth, operationData.EllipseData.EllipseWidth) & (operationData2.selectedPlaneName == operationData.selectedPlaneName)) && buCompare5.EQ(operationData2.Position, operationData.Position))
				{
					return true;
				}
				if (operationData2.OperationType == ProfileOperationTypes.Hole && (buCompare5.EQ(operationData2.HoleData.HoleDepth, operationData.HoleData.HoleDepth) & buCompare5.EQ(operationData2.HoleData.HoleDiameter, operationData.HoleData.HoleDiameter)) && (buCompare5.EQ(operationData2.Position, operationData.Position) & (operationData2.selectedPlaneName == operationData.selectedPlaneName)))
				{
					return true;
				}
				if (operationData2.OperationType == ProfileOperationTypes.Notch && (buCompare5.EQ(operationData2.NotchData.NotchDepth, operationData.NotchData.NotchDepth) & buCompare5.EQ(operationData2.NotchData.NotchHeight, operationData.NotchData.NotchHeight)) && (buCompare5.EQ(operationData2.NotchData.NotchStart, operationData.NotchData.NotchStart) & (operationData2.selectedPlaneName == operationData.selectedPlaneName)) && buCompare5.EQ(operationData2.NotchData.NotchWidth, operationData.NotchData.NotchWidth) && (buCompare5.EQ(operationData2.Position, operationData.Position) & (operationData2.NotchData.NotchLocation == operationData.NotchData.NotchLocation)) && operationData2.NotchData.NotchOPType == operationData.NotchData.NotchOPType)
				{
					return true;
				}
				if (operationData2.OperationType == ProfileOperationTypes.Polygon && (buCompare5.EQ(operationData2.PolygonData.PolygonAngle, operationData.PolygonData.PolygonAngle) & buCompare5.EQ(operationData2.PolygonData.PolygonDiameter, operationData.PolygonData.PolygonDiameter)) && (buCompare5.EQ(operationData2.PolygonData.PolygonSide, operationData.PolygonData.PolygonSide) & (operationData2.selectedPlaneName == operationData.selectedPlaneName)) && buCompare5.EQ(operationData2.Position, operationData.Position))
				{
					return true;
				}
				if (operationData2.OperationType == ProfileOperationTypes.Slot && (buCompare5.EQ(operationData2.SlotData.SlotAngle, operationData.SlotData.SlotAngle) & buCompare5.EQ(operationData2.SlotData.SlotWidth, operationData.SlotData.SlotWidth)) && (buCompare5.EQ(operationData2.SlotData.SlotDiameter, operationData.SlotData.SlotDiameter) & (operationData2.selectedPlaneName == operationData.selectedPlaneName)) && buCompare5.EQ(operationData2.Position, operationData.Position))
				{
					return true;
				}
				if (operationData2.OperationType == ProfileOperationTypes.Text && (buCompare5.EQ(operationData2.TextData.TextAngle, operationData.TextData.TextAngle) & (operationData2.TextData.TextString == operationData.TextData.TextString)) && (buCompare5.EQ(operationData2.TextData.TextWidth, operationData.TextData.TextWidth) & (operationData2.selectedPlaneName == operationData.selectedPlaneName)) && (buCompare5.EQ(operationData2.TextData.TextHeight, operationData.TextData.TextHeight) & buCompare5.EQ(operationData2.Position, operationData.Position)))
				{
					return true;
				}
				if (operationData2.OperationType == ProfileOperationTypes.FreeDraw && (buCompare5.EQ(operationData2.FreeDrawData.FreeDrawAngle, operationData.FreeDrawData.FreeDrawAngle) & (operationData2.FreeDrawData.FreeDrawHeight == operationData.FreeDrawData.FreeDrawHeight)) && (buCompare5.EQ(operationData2.FreeDrawData.FreeDrawWidth, operationData.FreeDrawData.FreeDrawWidth) & (operationData2.selectedPlaneName == operationData.selectedPlaneName)) && ((operationData2.FreeDrawData.FreeDrawScaleCenter == operationData.FreeDrawData.FreeDrawScaleCenter) & buCompare5.EQ(operationData2.Position, operationData.Position)))
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool isAllOperationInsideXLimit(ProfileItem Item, double XLimit)
	{
		bool result = false;
		for (int i = 0; i <= Item.Operations.Count - 1; i++)
		{
			if (Item.Operations[i].MaxPoint.X > XLimit)
			{
				return true;
			}
		}
		return result;
	}

	public bool isBottomOperationAvailable(ProfileItem Item)
	{
		bool result = false;
		for (int i = 0; i <= Item.Operations.Count - 1; i++)
		{
			if (Item.Operations[i].OperationData.selectedPlaneName == planeNames.Bottom)
			{
				return true;
			}
		}
		return result;
	}

	public bool isNextOperationsInsideRange(List<GProfileOperation> Operations, GProfileOperation refOP, bool UseMaxPoint, int startIndex, double MaxDistance, ref double calcDistance, ref List<GProfileOperation> foundOP)
	{
		bool result = false;
		foundOP.Clear();
		for (int i = startIndex; i <= Operations.Count - 1; i++)
		{
			if (!UseMaxPoint)
			{
				double num = Operations[i].SizePoint.MinPoint.X - refOP.SizePoint.MinPoint.X;
				if (!(num < MaxDistance && num > 0.0))
				{
					return result;
				}
				if (num > calcDistance)
				{
					calcDistance = num;
				}
				foundOP.Add(new GProfileOperation(Operations[i]));
				result = true;
			}
			else
			{
				double num2 = Operations[i].SizePoint.MaxPoint.X - refOP.SizePoint.MaxPoint.X;
				if (!(num2 < MaxDistance && num2 >= 0.0))
				{
					return result;
				}
				if (num2 > calcDistance)
				{
					calcDistance = num2;
				}
				foundOP.Add(new GProfileOperation(Operations[i]));
				result = true;
			}
		}
		return result;
	}

	public bool GetOperationDepthValueFromProfile(ProfileItem Profile, DepthPositionOptions Options, double ExternalDepth, double ExtraDepth, double DepthUp, bool EachLayer, ToolBase5 Tool, ref ProfileOperation Operation)
	{
		if (Profile != null)
		{
			Point3D MinPoint = new Point3D();
			Point3D MaxPoint = new Point3D();
			Operation.ProfileWidth = Profile.Width;
			Operation.ProfileHeight = Profile.Height;
			Operation.ProfileLength = Profile.Length;
			Operation.ProfileName = Profile.ItemName;
			List<DepthPositions> list = new List<DepthPositions>();
			DepthPositions depth = new DepthPositions();
			List<double> Values = new List<double>();
			List<Point3D> list2 = new List<Point3D>();
			List<Point3D> SortingPoints = new List<Point3D>();
			double num = 0.0;
			double num2 = 0.0;
			double y = 0.0;
			double y2 = 0.0;
			double z = 0.0;
			double z2 = 0.0;
			Point3D point3D = new Point3D(0.0, 0.0, 0.0);
			Point3D point3D2 = new Point3D(0.0, 0.0, 0.0);
			List<Line> list3 = new List<Line>();
			List<double> Values2 = new List<double>();
			if (Options.AreaCalculation)
			{
				if (Operation.OperationData.Action == actionTypeBU.profileRectangle)
				{
					num = (0.0 - Operation.OperationData.RectangleData.RectangleHeight) / 2.0;
					num2 = Operation.OperationData.RectangleData.RectangleHeight / 2.0;
					if ((Operation.OperationData.Alignment == ObjectAlignment.TopLeft) | (Operation.OperationData.Alignment == ObjectAlignment.TopCenter) | (Operation.OperationData.Alignment == ObjectAlignment.TopRight))
					{
						num = 0.0;
						num2 = 0.0 - Operation.OperationData.RectangleData.RectangleHeight;
					}
					if ((Operation.OperationData.Alignment == ObjectAlignment.BottomLeft) | (Operation.OperationData.Alignment == ObjectAlignment.BottomCenter) | (Operation.OperationData.Alignment == ObjectAlignment.BottomRight))
					{
						num = 0.0;
						num2 = Operation.OperationData.RectangleData.RectangleHeight;
					}
					buNumeric5.DevideMinMaxValueByNumber(num, num2, Options.AreaStep, ref Values2);
				}
				if (Operation.OperationData.Action == actionTypeBU.profileCircle)
				{
					num = (0.0 - Operation.OperationData.CircleData.CircleDiameter) / 2.0;
					num2 = Operation.OperationData.CircleData.CircleDiameter / 2.0;
					if ((Operation.OperationData.Alignment == ObjectAlignment.TopLeft) | (Operation.OperationData.Alignment == ObjectAlignment.TopCenter) | (Operation.OperationData.Alignment == ObjectAlignment.TopRight))
					{
						num = 0.0;
						num2 = 0.0 - Operation.OperationData.CircleData.CircleDiameter;
					}
					if ((Operation.OperationData.Alignment == ObjectAlignment.BottomLeft) | (Operation.OperationData.Alignment == ObjectAlignment.BottomCenter) | (Operation.OperationData.Alignment == ObjectAlignment.BottomRight))
					{
						num = 0.0;
						num2 = Operation.OperationData.CircleData.CircleDiameter;
					}
					buNumeric5.DevideMinMaxValueByNumber(num, num2, Options.AreaStep, ref Values2);
				}
				if (Operation.OperationData.Action == actionTypeBU.profileSlot)
				{
					num = (0.0 - Operation.OperationData.SlotData.SlotDiameter) / 2.0;
					num2 = Operation.OperationData.SlotData.SlotDiameter / 2.0;
					if ((Operation.OperationData.Alignment == ObjectAlignment.TopLeft) | (Operation.OperationData.Alignment == ObjectAlignment.TopCenter) | (Operation.OperationData.Alignment == ObjectAlignment.TopRight))
					{
						num = 0.0;
						num2 = 0.0 - Operation.OperationData.SlotData.SlotDiameter;
					}
					if ((Operation.OperationData.Alignment == ObjectAlignment.BottomLeft) | (Operation.OperationData.Alignment == ObjectAlignment.BottomCenter) | (Operation.OperationData.Alignment == ObjectAlignment.BottomRight))
					{
						num = 0.0;
						num2 = Operation.OperationData.SlotData.SlotDiameter;
					}
					buNumeric5.DevideMinMaxValueByNumber(num, num2, Options.AreaStep, ref Values2);
				}
				if (Operation.OperationData.Action == actionTypeBU.profileHole)
				{
					num = (0.0 - Operation.OperationData.HoleData.HoleDiameter) / 2.0;
					num2 = Operation.OperationData.HoleData.HoleDiameter / 2.0;
					if ((Operation.OperationData.Alignment == ObjectAlignment.TopLeft) | (Operation.OperationData.Alignment == ObjectAlignment.TopCenter) | (Operation.OperationData.Alignment == ObjectAlignment.TopRight))
					{
						num = 0.0;
						num2 = 0.0 - Operation.OperationData.HoleData.HoleDiameter;
					}
					if ((Operation.OperationData.Alignment == ObjectAlignment.BottomLeft) | (Operation.OperationData.Alignment == ObjectAlignment.BottomCenter) | (Operation.OperationData.Alignment == ObjectAlignment.BottomRight))
					{
						num = 0.0;
						num2 = Operation.OperationData.HoleData.HoleDiameter;
					}
					buNumeric5.DevideMinMaxValueByNumber(num, num2, Options.AreaStep, ref Values2);
				}
				if (Operation.OperationData.Action == actionTypeBU.profilePolygon)
				{
					num = (0.0 - Operation.OperationData.PolygonData.PolygonDiameter) / 2.0;
					num2 = Operation.OperationData.PolygonData.PolygonDiameter / 2.0;
					if ((Operation.OperationData.Alignment == ObjectAlignment.TopLeft) | (Operation.OperationData.Alignment == ObjectAlignment.TopCenter) | (Operation.OperationData.Alignment == ObjectAlignment.TopRight))
					{
						num = 0.0;
						num2 = 0.0 - Operation.OperationData.PolygonData.PolygonDiameter;
					}
					if ((Operation.OperationData.Alignment == ObjectAlignment.BottomLeft) | (Operation.OperationData.Alignment == ObjectAlignment.BottomCenter) | (Operation.OperationData.Alignment == ObjectAlignment.BottomRight))
					{
						num = 0.0;
						num2 = Operation.OperationData.PolygonData.PolygonDiameter;
					}
					buNumeric5.DevideMinMaxValueByNumber(num, num2, Options.AreaStep, ref Values2);
				}
				if (Operation.OperationData.Action == actionTypeBU.profileTapping)
				{
					num = (0.0 - Operation.OperationData.HoleData.HoleDiameter) / 2.0;
					num2 = Operation.OperationData.HoleData.HoleDiameter / 2.0;
					if ((Operation.OperationData.Alignment == ObjectAlignment.TopLeft) | (Operation.OperationData.Alignment == ObjectAlignment.TopCenter) | (Operation.OperationData.Alignment == ObjectAlignment.TopRight))
					{
						num = 0.0;
						num2 = 0.0 - Operation.OperationData.HoleData.HoleDiameter;
					}
					if ((Operation.OperationData.Alignment == ObjectAlignment.BottomLeft) | (Operation.OperationData.Alignment == ObjectAlignment.BottomCenter) | (Operation.OperationData.Alignment == ObjectAlignment.BottomRight))
					{
						num = 0.0;
						num2 = Operation.OperationData.HoleData.HoleDiameter;
					}
					buNumeric5.DevideMinMaxValueByNumber(num, num2, Options.AreaStep, ref Values2);
				}
				if (Operation.OperationData.Action == actionTypeBU.profileText)
				{
					num = (0.0 - Operation.OperationData.TextData.TextHeight) / 2.0;
					num2 = Operation.OperationData.TextData.TextHeight / 2.0;
					if ((Operation.OperationData.Alignment == ObjectAlignment.TopLeft) | (Operation.OperationData.Alignment == ObjectAlignment.TopCenter) | (Operation.OperationData.Alignment == ObjectAlignment.TopRight))
					{
						num = 0.0;
						num2 = 0.0 - Operation.OperationData.TextData.TextHeight;
					}
					if ((Operation.OperationData.Alignment == ObjectAlignment.BottomLeft) | (Operation.OperationData.Alignment == ObjectAlignment.BottomCenter) | (Operation.OperationData.Alignment == ObjectAlignment.BottomRight))
					{
						num = 0.0;
						num2 = Operation.OperationData.TextData.TextHeight;
					}
					buNumeric5.DevideMinMaxValueByNumber(num, num2, Options.AreaStep, ref Values2);
				}
				if (Operation.OperationData.Action == actionTypeBU.profileFreeDraw)
				{
					num = (0.0 - Operation.OperationData.FreeDrawData.FreeDrawHeight) / 2.0;
					num2 = Operation.OperationData.FreeDrawData.FreeDrawHeight / 2.0;
					if ((Operation.OperationData.Alignment == ObjectAlignment.TopLeft) | (Operation.OperationData.Alignment == ObjectAlignment.TopCenter) | (Operation.OperationData.Alignment == ObjectAlignment.TopRight))
					{
						num = 0.0;
						num2 = 0.0 - Operation.OperationData.FreeDrawData.FreeDrawHeight;
					}
					if ((Operation.OperationData.Alignment == ObjectAlignment.BottomLeft) | (Operation.OperationData.Alignment == ObjectAlignment.BottomCenter) | (Operation.OperationData.Alignment == ObjectAlignment.BottomRight))
					{
						num = 0.0;
						num2 = Operation.OperationData.FreeDrawData.FreeDrawHeight;
					}
					buNumeric5.DevideMinMaxValueByNumber(num, num2, Options.AreaStep, ref Values2);
				}
				if (Operation.OperationData.Action == actionTypeBU.profileCut)
				{
					num = (0.0 - Operation.OperationData.CutData.CutHeigth) / 2.0;
					num2 = Operation.OperationData.CutData.CutHeigth / 2.0;
					if ((Operation.OperationData.Alignment == ObjectAlignment.TopLeft) | (Operation.OperationData.Alignment == ObjectAlignment.TopCenter) | (Operation.OperationData.Alignment == ObjectAlignment.TopRight))
					{
						num = 0.0;
						num2 = 0.0 - Operation.OperationData.CutData.CutHeigth;
					}
					if ((Operation.OperationData.Alignment == ObjectAlignment.BottomLeft) | (Operation.OperationData.Alignment == ObjectAlignment.BottomCenter) | (Operation.OperationData.Alignment == ObjectAlignment.BottomRight))
					{
						num = 0.0;
						num2 = Operation.OperationData.CutData.CutHeigth;
					}
					buNumeric5.DevideMinMaxValueByNumber(num, num2, Options.AreaStep, ref Values2);
				}
				if (Operation.OperationData.Action == actionTypeBU.profileEllipse)
				{
					num = (0.0 - Operation.OperationData.EllipseData.EllipseHeight) / 2.0;
					num2 = Operation.OperationData.EllipseData.EllipseHeight / 2.0;
					if ((Operation.OperationData.Alignment == ObjectAlignment.TopLeft) | (Operation.OperationData.Alignment == ObjectAlignment.TopCenter) | (Operation.OperationData.Alignment == ObjectAlignment.TopRight))
					{
						num = 0.0;
						num2 = 0.0 - Operation.OperationData.EllipseData.EllipseHeight;
					}
					if ((Operation.OperationData.Alignment == ObjectAlignment.BottomLeft) | (Operation.OperationData.Alignment == ObjectAlignment.BottomCenter) | (Operation.OperationData.Alignment == ObjectAlignment.BottomRight))
					{
						num = 0.0;
						num2 = Operation.OperationData.EllipseData.EllipseHeight;
					}
					buNumeric5.DevideMinMaxValueByNumber(num, num2, Options.AreaStep, ref Values2);
				}
				if (Operation.OperationData.Action == actionTypeBU.profileBarrel)
				{
					num = (0.0 - Operation.OperationData.BarelData.BarrelDiameter) / 2.0;
					num2 = Operation.OperationData.BarelData.BarrelDiameter / 2.0;
					if ((Operation.OperationData.Alignment == ObjectAlignment.TopLeft) | (Operation.OperationData.Alignment == ObjectAlignment.TopCenter) | (Operation.OperationData.Alignment == ObjectAlignment.TopRight))
					{
						num = 0.0;
						num2 = 0.0 - Operation.OperationData.BarelData.BarrelDiameter;
					}
					if ((Operation.OperationData.Alignment == ObjectAlignment.BottomLeft) | (Operation.OperationData.Alignment == ObjectAlignment.BottomCenter) | (Operation.OperationData.Alignment == ObjectAlignment.BottomRight))
					{
						num = 0.0;
						num2 = Operation.OperationData.BarelData.BarrelDiameter;
					}
					buNumeric5.DevideMinMaxValueByNumber(num, num2, Options.AreaStep, ref Values2);
				}
				for (int i = 0; i <= Values2.Count - 1; i++)
				{
					Values2[i] += Operation.OperationData.Position.Y;
				}
				new List<double>();
				if (Operation.OperationData.selectedPlaneName == planeNames.Top)
				{
					y = Operation.OperationData.Position.Y + num;
					y2 = Operation.OperationData.Position.Y + num2;
					z = Profile.ProfileMaxPoint.Z - ExternalDepth;
					z2 = Profile.ProfileMaxPoint.Z;
				}
				if (Operation.OperationData.selectedPlaneName == planeNames.Bottom)
				{
					y = Operation.OperationData.Position.Y + num;
					y2 = Operation.OperationData.Position.Y + num2;
					z = Profile.ProfileMinPoint.Z;
					z2 = Profile.ProfileMinPoint.Z + ExternalDepth;
				}
				if (Operation.OperationData.selectedPlaneName == planeNames.Front)
				{
					z = Operation.OperationData.Position.Z + num;
					z2 = Operation.OperationData.Position.Z + num2;
					y = Profile.ProfileMinPoint.Y;
					y2 = Profile.ProfileMinPoint.Y + ExternalDepth;
				}
				if (Operation.OperationData.selectedPlaneName == planeNames.Back)
				{
					z = Operation.OperationData.Position.Z + num;
					z2 = Operation.OperationData.Position.Z + num2;
					y = Profile.ProfileMaxPoint.Y - ExternalDepth;
					y2 = Profile.ProfileMaxPoint.Y;
				}
				point3D = new Point3D(0.0, y, z);
				point3D2 = new Point3D(0.0, y2, z2);
				for (int j = 0; j <= Profile.Drawings.Count - 1; j++)
				{
					for (int k = 0; k <= Profile.Drawings[j].OutterEntitites.Count - 1; k++)
					{
						if (!(Profile.Drawings[j].OutterEntitites[k] is buCompositeCurve))
						{
							buEntity buEntity2 = Profile.Drawings[j].OutterEntitites[k];
							Point3D point3D3 = new Point3D(0.0, buEntity2.StartPoint.X + Profile.ProfileOffset.Y, buEntity2.StartPoint.Y + Profile.ProfileOffset.Z);
							if (buCall.buVector5_0.IsPointInsideBoxsize(point3D3, point3D, point3D2, Plane.YZ))
							{
								if ((Operation.OperationData.selectedPlaneName == planeNames.Top) | (Operation.OperationData.selectedPlaneName == planeNames.Bottom))
								{
									Values2.Add(point3D3.Y);
								}
								if ((Operation.OperationData.selectedPlaneName == planeNames.Front) | (Operation.OperationData.selectedPlaneName == planeNames.Back))
								{
									Values2.Add(point3D3.Z);
								}
							}
							point3D3 = new Point3D(0.0, buEntity2.EndPoint.X + Profile.ProfileOffset.Y, buEntity2.EndPoint.Y + Profile.ProfileOffset.Z);
							if (buCall.buVector5_0.IsPointInsideBoxsize(point3D3, point3D, point3D2, Plane.YZ))
							{
								if ((Operation.OperationData.selectedPlaneName == planeNames.Top) | (Operation.OperationData.selectedPlaneName == planeNames.Bottom))
								{
									Values2.Add(point3D3.Y);
								}
								if ((Operation.OperationData.selectedPlaneName == planeNames.Front) | (Operation.OperationData.selectedPlaneName == planeNames.Back))
								{
									Values2.Add(point3D3.Z);
								}
							}
							continue;
						}
						buCompositeCurve buCompositeCurve2 = Profile.Drawings[j].OutterEntitites[k] as buCompositeCurve;
						for (int l = 0; l <= buCompositeCurve2.CurveList.Count - 1; l++)
						{
							Point3D point3D4 = new Point3D(0.0, buCompositeCurve2.CurveList[l].StartPoint.X + Profile.ProfileOffset.Y, buCompositeCurve2.CurveList[l].StartPoint.Y + Profile.ProfileOffset.Z);
							if (buCall.buVector5_0.IsPointInsideBoxsize(point3D4, point3D, point3D2, Plane.YZ))
							{
								if ((Operation.OperationData.selectedPlaneName == planeNames.Top) | (Operation.OperationData.selectedPlaneName == planeNames.Bottom))
								{
									Values2.Add(point3D4.Y);
								}
								if ((Operation.OperationData.selectedPlaneName == planeNames.Front) | (Operation.OperationData.selectedPlaneName == planeNames.Back))
								{
									Values2.Add(point3D4.Z);
								}
							}
							point3D4 = new Point3D(0.0, buCompositeCurve2.CurveList[l].EndPoint.X + Profile.ProfileOffset.Y, buCompositeCurve2.CurveList[l].EndPoint.Y + Profile.ProfileOffset.Z);
							if (buCall.buVector5_0.IsPointInsideBoxsize(point3D4, point3D, point3D2, Plane.YZ))
							{
								if ((Operation.OperationData.selectedPlaneName == planeNames.Top) | (Operation.OperationData.selectedPlaneName == planeNames.Bottom))
								{
									Values2.Add(point3D4.Y);
								}
								if ((Operation.OperationData.selectedPlaneName == planeNames.Front) | (Operation.OperationData.selectedPlaneName == planeNames.Back))
								{
									Values2.Add(point3D4.Z);
								}
							}
						}
					}
				}
				Values2.Sort();
				buNumeric5.CheckDuplicatedWithPrevious(ref Values2, 0.2);
			}
			if (Values2.Count == 0)
			{
				Values2.Add(Operation.OperationData.Position.Y);
			}
			if (!EachLayer)
			{
				if (!((Operation.OperationData.selectedPlaneName == planeNames.Top) | (Operation.OperationData.selectedPlaneName == planeNames.Bottom)))
				{
					if (!((Operation.OperationData.selectedPlaneName == planeNames.Back) | (Operation.OperationData.selectedPlaneName == planeNames.Front)))
					{
						Point3D start = new Point3D(0.0, Operation.OperationData.selectedPlane.AxisZ.Y * 10000.0, Operation.OperationData.selectedPlane.AxisZ.Z * 10000.0);
						Point3D end = new Point3D(0.0, Operation.OperationData.selectedPlane.AxisZ.Y * -10000.0, Operation.OperationData.selectedPlane.AxisZ.Z * -10000.0);
						Line item = new Line(start, end);
						list3.Add(item);
					}
					else
					{
						list3.Add(new Line(new Point3D(0.0, -10000.0, Operation.OperationData.Position.Y + Operation.OperationData.movePlanePoint.Z), new Point3D(0.0, 10000.0, Operation.OperationData.Position.Y + Operation.OperationData.movePlanePoint.Z)));
					}
				}
				else
				{
					list3.Add(new Line(new Point3D(0.0, Operation.OperationData.Position.Y, -10000.0), new Point3D(0.0, Operation.OperationData.Position.Y, 10000.0)));
				}
			}
			else if (!((Operation.OperationData.selectedPlaneName == planeNames.Top) | (Operation.OperationData.selectedPlaneName == planeNames.Bottom)))
			{
				if (!((Operation.OperationData.selectedPlaneName == planeNames.Back) | (Operation.OperationData.selectedPlaneName == planeNames.Front)))
				{
					Point3D start2 = new Point3D(0.0, Operation.OperationData.selectedPlane.AxisZ.Y * 10000.0, Operation.OperationData.selectedPlane.AxisZ.Z * 10000.0);
					Point3D end2 = new Point3D(0.0, Operation.OperationData.selectedPlane.AxisZ.Y * -10000.0, Operation.OperationData.selectedPlane.AxisZ.Z * -10000.0);
					Line item2 = new Line(start2, end2);
					list3.Add(item2);
				}
				else
				{
					for (int m = 0; m <= Values2.Count - 1; m++)
					{
						list3.Add(new Line(new Point3D(0.0, -10000.0, Operation.OperationData.movePlanePoint.Z + Values2[m]), new Point3D(0.0, 10000.0, Operation.OperationData.movePlanePoint.Z + Values2[m])));
					}
				}
			}
			else
			{
				for (int n = 0; n <= Values2.Count - 1; n++)
				{
					list3.Add(new Line(new Point3D(0.0, Values2[n], -10000.0), new Point3D(0.0, Values2[n], 10000.0)));
				}
			}
			for (int num3 = 0; num3 <= list3.Count - 1; num3++)
			{
				for (int num4 = 0; num4 <= Profile.Drawings.Count - 1; num4++)
				{
					LinearPath linearPath = new LinearPath(Profile.Drawings[num4].OutterPoints);
					Point3D[] collection = linearPath.IntersectWith(list3[num3]);
					list2.AddRange(collection);
					for (int num5 = 0; num5 <= Profile.Drawings[num4].InnerPoints.Count - 1; num5++)
					{
						linearPath = new LinearPath(Profile.Drawings[num4].InnerPoints[num5]);
						Point3D[] collection2 = linearPath.IntersectWith(list3[num3]);
						list2.AddRange(collection2);
					}
				}
			}
			if (EachLayer)
			{
				if ((Operation.OperationData.selectedPlaneName == planeNames.Top) | (Operation.OperationData.selectedPlaneName == planeNames.Bottom))
				{
					Line c = null;
					if (Operation.OperationData.selectedPlaneName == planeNames.Top)
					{
						c = new Line(new Point3D(0.0, y, z), new Point3D(0.0, y2, z));
					}
					if (Operation.OperationData.selectedPlaneName == planeNames.Bottom)
					{
						c = new Line(new Point3D(0.0, y, z2), new Point3D(0.0, y2, z2));
					}
					for (int num6 = 0; num6 <= Profile.Drawings.Count - 1; num6++)
					{
						LinearPath linearPath2 = new LinearPath(Profile.Drawings[num6].OutterPoints);
						Point3D[] collection3 = linearPath2.IntersectWith(c);
						SortingPoints.AddRange(collection3);
						for (int num7 = 0; num7 <= Profile.Drawings[num6].InnerPoints.Count - 1; num7++)
						{
							linearPath2 = new LinearPath(Profile.Drawings[num6].InnerPoints[num7]);
							Point3D[] collection4 = linearPath2.IntersectWith(c);
							SortingPoints.AddRange(collection4);
						}
					}
					buCall.buVector5_0.SortDeltaZ(new Point3D(0.0, 0.0, 10000.0), SortDirectionType.Bigger, ref SortingPoints);
					buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref SortingPoints);
				}
				if ((Operation.OperationData.selectedPlaneName == planeNames.Front) | (Operation.OperationData.selectedPlaneName == planeNames.Back))
				{
					Line c2 = null;
					if (Operation.OperationData.selectedPlaneName == planeNames.Back)
					{
						c2 = new Line(new Point3D(0.0, y, z), new Point3D(0.0, y, z2));
					}
					if (Operation.OperationData.selectedPlaneName == planeNames.Front)
					{
						c2 = new Line(new Point3D(0.0, y2, z), new Point3D(0.0, y2, z2));
					}
					for (int num8 = 0; num8 <= Profile.Drawings.Count - 1; num8++)
					{
						LinearPath linearPath3 = new LinearPath(Profile.Drawings[num8].OutterPoints);
						Point3D[] collection5 = linearPath3.IntersectWith(c2);
						SortingPoints.AddRange(collection5);
						for (int num9 = 0; num9 <= Profile.Drawings[num8].InnerPoints.Count - 1; num9++)
						{
							linearPath3 = new LinearPath(Profile.Drawings[num8].InnerPoints[num9]);
							Point3D[] collection6 = linearPath3.IntersectWith(c2);
							SortingPoints.AddRange(collection6);
						}
					}
					buCall.buVector5_0.SortDeltaY(new Point3D(0.0, 10000.0, 0.0), SortDirectionType.Bigger, ref SortingPoints);
					buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref SortingPoints);
				}
			}
			buCall.buVector5_0.BoxSizeCalculate(list2, ref MinPoint, ref MaxPoint);
			list2.Clear();
			for (int num10 = 0; num10 <= list3.Count - 1; num10++)
			{
				Values.Clear();
				list2.Clear();
				list2.AddRange(SortingPoints);
				int num11 = 0;
				for (int num12 = 0; num12 <= Profile.Drawings.Count - 1; num12++)
				{
					num11 = 0;
					for (int num13 = 1; num13 <= Profile.Drawings[num12].OutterPoints.Count - 1; num13++)
					{
						bool flag = false;
						if (!((Operation.OperationData.selectedPlaneName == planeNames.Front) | (Operation.OperationData.selectedPlaneName == planeNames.Back)) || buCompare5.EQ(Profile.Drawings[num12].OutterPoints[num13 - 1].Z, Profile.Drawings[num12].OutterPoints[num13].Z, 0.01))
						{
						}
						if (!((Operation.OperationData.selectedPlaneName == planeNames.Top) | (Operation.OperationData.selectedPlaneName == planeNames.Bottom)) || buCompare5.EQ(Profile.Drawings[num12].OutterPoints[num13 - 1].Y, Profile.Drawings[num12].OutterPoints[num13].Y, 0.01))
						{
						}
						if (flag)
						{
							continue;
						}
						Line line = new Line(Profile.Drawings[num12].OutterPoints[num13 - 1], Profile.Drawings[num12].OutterPoints[num13]);
						Point3D[] array = line.IntersectWith(list3[num10]);
						if (array.Length == 0)
						{
							continue;
						}
						if (list2.Count != 0)
						{
							if ((Operation.OperationData.selectedPlaneName == planeNames.Front) | (Operation.OperationData.selectedPlaneName == planeNames.Back))
							{
								double num14 = Math.Abs(list2[list2.Count - 1].Y - array[0].Y);
								if (num14 > 0.1)
								{
									if (num13 - num11 <= 0)
									{
										if (Operation.OperationData.selectedPlaneName == planeNames.Front && array[0].Y < list2[list2.Count - 1].Y)
										{
											list2[list2.Count - 1] = new Point3D(array[0].X, array[0].Y, array[0].Z);
											num11 = num13;
										}
										if (Operation.OperationData.selectedPlaneName == planeNames.Back && array[0].Y > list2[list2.Count - 1].Y)
										{
											list2[list2.Count - 1] = new Point3D(array[0].X, array[0].Y, array[0].Z);
											num11 = num13;
										}
									}
									else
									{
										list2.AddRange(array);
										num11 = num13;
									}
								}
							}
							if (!((Operation.OperationData.selectedPlaneName == planeNames.Top) | (Operation.OperationData.selectedPlaneName == planeNames.Bottom)))
							{
								continue;
							}
							double num15 = Math.Abs(list2[list2.Count - 1].Z - array[0].Z);
							if (!(num15 > 0.1))
							{
								continue;
							}
							if (num13 - num11 <= 0)
							{
								if (Operation.OperationData.selectedPlaneName == planeNames.Top && array[0].Z > list2[list2.Count - 1].Z)
								{
									list2[list2.Count - 1] = new Point3D(array[0].X, array[0].Y, array[0].Z);
									num11 = num13;
								}
								if (Operation.OperationData.selectedPlaneName == planeNames.Bottom && array[0].Z < list2[list2.Count - 1].Z)
								{
									list2[list2.Count - 1] = new Point3D(array[0].X, array[0].Y, array[0].Z);
									num11 = num13;
								}
							}
							else
							{
								list2.AddRange(array);
								num11 = num13;
							}
						}
						else
						{
							list2.AddRange(array);
							num11 = num13;
						}
					}
					for (int num16 = 0; num16 <= Profile.Drawings[num12].InnerPoints.Count - 1; num16++)
					{
						for (int num17 = 1; num17 <= Profile.Drawings[num12].InnerPoints[num16].Count - 1; num17++)
						{
							bool flag2 = false;
							if (!((Operation.OperationData.selectedPlaneName == planeNames.Front) | (Operation.OperationData.selectedPlaneName == planeNames.Back)) || buCompare5.EQ(Profile.Drawings[num12].InnerPoints[num16][num17 - 1].Z, Profile.Drawings[num12].InnerPoints[num16][num17].Z, 0.1))
							{
							}
							if (!((Operation.OperationData.selectedPlaneName == planeNames.Top) | (Operation.OperationData.selectedPlaneName == planeNames.Bottom)) || buCompare5.EQ(Profile.Drawings[num12].InnerPoints[num16][num17 - 1].Y, Profile.Drawings[num12].InnerPoints[num16][num17].Y, 0.1))
							{
							}
							if (!flag2)
							{
								Line line2 = new Line(Profile.Drawings[num12].InnerPoints[num16][num17 - 1], Profile.Drawings[num12].InnerPoints[num16][num17]);
								Point3D[] collection7 = line2.IntersectWith(list3[num10]);
								list2.AddRange(collection7);
							}
						}
					}
				}
				for (int num18 = 0; num18 <= list2.Count - 1; num18++)
				{
					if (Operation.OperationData.selectedPlaneName != planeNames.Top)
					{
						if (Operation.OperationData.selectedPlaneName != planeNames.Bottom)
						{
							if (Operation.OperationData.selectedPlaneName != planeNames.Front)
							{
								if (Operation.OperationData.selectedPlaneName == planeNames.Back && buCompare5.GE(list2[num18].Y, MaxPoint.Y - ExternalDepth, 0.1))
								{
									Values.Add(Math.Round(list2[num18].Y, 3));
								}
							}
							else if (buCompare5.LE(list2[num18].Y, MinPoint.Y + ExternalDepth, 0.1))
							{
								Values.Add(Math.Round(list2[num18].Y, 3));
							}
						}
						else if (buCompare5.LE(list2[num18].Z, MinPoint.Z + ExternalDepth, 0.1))
						{
							Values.Add(Math.Round(list2[num18].Z, 3));
						}
					}
					else if (buCompare5.GE(list2[num18].Z, MaxPoint.Z - ExternalDepth, 0.1))
					{
						Values.Add(Math.Round(list2[num18].Z, 3));
					}
				}
				if (Values.Count >= 2)
				{
					Values.Sort();
					if ((Operation.OperationData.selectedPlaneName == planeNames.Top) | (Operation.OperationData.selectedPlaneName == planeNames.Back))
					{
						Values.Reverse();
					}
				}
				if (Values.Count == 1)
				{
					if ((Operation.OperationData.selectedPlaneName == planeNames.Top) | (Operation.OperationData.selectedPlaneName == planeNames.Back))
					{
						Values.Add(Values[0] - Operation.OperationData.ExternalDepth);
					}
					if ((Operation.OperationData.selectedPlaneName == planeNames.Front) | (Operation.OperationData.selectedPlaneName == planeNames.Bottom))
					{
						Values.Add(Values[0] + Operation.OperationData.ExternalDepth);
					}
				}
				buNumeric5.CheckDuplicatedWithPrevious(ref Values);
				if (Values.Count % 2 != 1)
				{
				}
				bool flag3 = false;
				if ((Operation.OperationData.selectedPlaneName == planeNames.Top) | (Operation.OperationData.selectedPlaneName == planeNames.Back))
				{
					for (int num19 = 0; num19 <= Values.Count - 1; num19 += 2)
					{
						if (num19 >= Values.Count - 1)
						{
							continue;
						}
						double num20 = Values[num19] - Values[num19 + 1];
						if (!((num20 >= Options.MinThickness) & (num20 <= Options.MaxThickness)))
						{
							continue;
						}
						DepthPositions depthPositions = new DepthPositions();
						depthPositions.TopPosition = Values[num19];
						depthPositions.BottomPosition = Values[num19 + 1] - ExtraDepth;
						depthPositions.Depth = depthPositions.BottomPosition - depthPositions.TopPosition;
						if (!EachLayer)
						{
							if (!flag3)
							{
								depth = new DepthPositions(depthPositions);
								flag3 = true;
							}
						}
						else if (list.Count != 0)
						{
							bool flag4 = false;
							for (int num21 = 0; num21 <= list.Count - 1; num21++)
							{
								bool flag5 = buNumeric5.IsValueInsideMinMaxValues(depthPositions.TopPosition, list[num21].BottomPosition, list[num21].TopPosition);
								bool flag6 = buNumeric5.IsValueInsideMinMaxValues(depthPositions.BottomPosition, list[num21].BottomPosition, list[num21].TopPosition);
								if (!(flag5 || flag6))
								{
									continue;
								}
								flag4 = true;
								if (!(flag5 && !flag6))
								{
									if (!flag5 && flag6)
									{
										list[num21].TopPosition = depthPositions.TopPosition;
										list[num21].Depth = list[num21].BottomPosition - list[num21].TopPosition;
									}
								}
								else
								{
									list[num21].BottomPosition = depthPositions.BottomPosition;
									list[num21].Depth = list[num21].BottomPosition - list[num21].TopPosition;
								}
							}
							if (!flag4)
							{
								list.Add(depthPositions);
							}
						}
						else
						{
							list.Add(depthPositions);
						}
					}
					if (Operation.OperationData.ManuelZEnable)
					{
						list.Clear();
						DepthPositions depthPositions2 = new DepthPositions();
						depthPositions2.TopPosition = Operation.OperationData.ManuelZVal;
						depthPositions2.BottomPosition = Operation.OperationData.ManuelZVal - Operation.OperationData.ExternalDepth - Operation.OperationData.ExtraDepth;
						depthPositions2.Depth = depthPositions2.BottomPosition - depthPositions2.TopPosition;
						Operation.OperationData.Depth = new DepthPositions(depthPositions2);
					}
				}
				if ((Operation.OperationData.selectedPlaneName == planeNames.Bottom) | (Operation.OperationData.selectedPlaneName == planeNames.Front))
				{
					for (int num22 = 0; num22 <= Values.Count - 1; num22 += 2)
					{
						if (num22 >= Values.Count - 1)
						{
							continue;
						}
						double num23 = Values[num22 + 1] - Values[num22];
						if (!((num23 >= Options.MinThickness) & (num23 <= Options.MaxThickness)))
						{
							continue;
						}
						DepthPositions depthPositions3 = new DepthPositions();
						depthPositions3.TopPosition = Values[num22];
						depthPositions3.BottomPosition = Values[num22 + 1] + ExtraDepth;
						depthPositions3.Depth = depthPositions3.BottomPosition - depthPositions3.TopPosition;
						if (!EachLayer)
						{
							if (!flag3)
							{
								depth = new DepthPositions(depthPositions3);
								flag3 = true;
							}
						}
						else if (list.Count != 0)
						{
							bool flag7 = false;
							for (int num24 = 0; num24 <= list.Count - 1; num24++)
							{
								bool flag8 = buNumeric5.IsValueInsideMinMaxValues(depthPositions3.TopPosition, list[num24].BottomPosition, list[num24].TopPosition);
								bool flag9 = buNumeric5.IsValueInsideMinMaxValues(depthPositions3.BottomPosition, list[num24].BottomPosition, list[num24].TopPosition);
								if (!(flag8 || flag9))
								{
									continue;
								}
								flag7 = true;
								if (!(flag8 && !flag9))
								{
									if (!flag8 && flag9)
									{
										list[num24].TopPosition = depthPositions3.TopPosition;
										list[num24].Depth = list[num24].BottomPosition - list[num24].TopPosition;
									}
								}
								else
								{
									list[num24].BottomPosition = depthPositions3.BottomPosition;
									list[num24].Depth = list[num24].BottomPosition - list[num24].TopPosition;
								}
							}
							if (!flag7)
							{
								list.Add(depthPositions3);
							}
						}
						else
						{
							list.Add(depthPositions3);
						}
					}
					if (Operation.OperationData.ManuelZEnable)
					{
						list.Clear();
						DepthPositions depthPositions4 = new DepthPositions();
						depthPositions4.TopPosition = Operation.OperationData.ManuelZVal;
						depthPositions4.BottomPosition = Operation.OperationData.ManuelZVal + Operation.OperationData.ExternalDepth + Operation.OperationData.ExtraDepth;
						depthPositions4.Depth = depthPositions4.BottomPosition - depthPositions4.TopPosition;
						depth = new DepthPositions(depthPositions4);
					}
				}
				if (Operation.OperationData.selectedPlaneName == planeNames.Free)
				{
					DepthPositions depthPositions5 = new DepthPositions();
					depthPositions5.TopPosition = 0.0;
					depthPositions5.BottomPosition = 0.0;
					depthPositions5.Depth = ExternalDepth;
					if (depthPositions5.Depth == 0.0)
					{
						depthPositions5.Depth = 2.0;
					}
					depthPositions5.Depth += ExtraDepth;
					depth = new DepthPositions(depthPositions5);
				}
			}
			Operation.OperationData.Depth = depth;
			if (list.Count <= 1)
			{
				Operation.OperationData.DepthValues = list;
			}
			else
			{
				List<DepthPositions> list4 = new List<DepthPositions>();
				list4.Add(new DepthPositions(list[0]));
				for (int num25 = 1; num25 <= list.Count - 1; num25++)
				{
					bool flag10 = false;
					for (int num26 = 0; num26 <= list4.Count - 1; num26++)
					{
						bool flag11 = buNumeric5.IsValueInsideMinMaxValues(list[num25].TopPosition, list4[num26].BottomPosition, list4[num26].TopPosition, 0.5);
						bool flag12 = buNumeric5.IsValueInsideMinMaxValues(list[num25].BottomPosition, list4[num26].BottomPosition, list4[num26].TopPosition, 0.5);
						if (!(flag11 || flag12))
						{
							continue;
						}
						flag10 = true;
						if (!(flag11 && !flag12))
						{
							if (!flag11 && flag12)
							{
								list4[num26].TopPosition = list[num25].TopPosition;
								list4[num26].Depth = list4[num26].BottomPosition - list4[num26].TopPosition;
							}
						}
						else
						{
							list4[num26].BottomPosition = list[num25].BottomPosition;
							list4[num26].Depth = list4[num26].BottomPosition - list4[num26].TopPosition;
						}
					}
					if (!flag10)
					{
						list4.Add(new DepthPositions(list[num25]));
					}
				}
				Operation.OperationData.DepthValues = list4;
			}
			if (DepthUp != 0.0)
			{
				for (int num27 = 0; num27 <= Operation.OperationData.DepthValues.Count - 1; num27++)
				{
					if (!((Operation.OperationData.selectedPlaneName == planeNames.Front) | (Operation.OperationData.selectedPlaneName == planeNames.Bottom)))
					{
						Operation.OperationData.DepthValues[num27].TopPosition = Operation.OperationData.DepthValues[num27].TopPosition + DepthUp;
					}
					else
					{
						Operation.OperationData.DepthValues[num27].TopPosition = Operation.OperationData.DepthValues[num27].TopPosition - DepthUp;
					}
					Operation.OperationData.DepthValues[num27].Depth = Operation.OperationData.DepthValues[num27].BottomPosition - Operation.OperationData.DepthValues[num27].TopPosition;
				}
			}
			return true;
		}
		return false;
	}

	public bool GetOperationDepthValueFromProfile1(ProfileItem Profile, DepthPositionOptions Options, double ExternalDepth, double ExtraDepth, bool EachLayer, ToolBase5 Tool, ref ProfileOperation Operation)
	{
		if (Profile != null)
		{
			Point3D MinPoint = new Point3D();
			Point3D MaxPoint = new Point3D();
			Operation.OperationData.DepthValues.Clear();
			Operation.ProfileWidth = Profile.Width;
			Operation.ProfileHeight = Profile.Height;
			Operation.ProfileLength = Profile.Length;
			Operation.ProfileName = Profile.ItemName;
			List<double> List = new List<double>();
			List<Point3D> list = new List<Point3D>();
			double num = 0.0;
			double num2 = 0.0;
			new List<Line>();
			List<double> Values = new List<double>();
			if (Operation.OperationData.Action == actionTypeBU.profileRectangle)
			{
				num = (0.0 - Operation.OperationData.RectangleData.RectangleHeight) / 2.0;
				num2 = Operation.OperationData.RectangleData.RectangleHeight / 2.0;
				buNumeric5.DevideMinMaxValueByNumber(num, num2, 10, ref Values);
			}
			for (int i = 0; i <= Profile.Drawings.Count - 1; i++)
			{
				LinearPath linearPath = new LinearPath(Profile.Drawings[i].OutterPoints);
				Line line = null;
				if (!((Operation.OperationData.selectedPlaneName == planeNames.Top) | (Operation.OperationData.selectedPlaneName == planeNames.Bottom)))
				{
					if (!((Operation.OperationData.selectedPlaneName == planeNames.Back) | (Operation.OperationData.selectedPlaneName == planeNames.Front)))
					{
						Point3D start = new Point3D(0.0, Operation.OperationData.selectedPlane.AxisZ.Y * 10000.0, Operation.OperationData.selectedPlane.AxisZ.Z * 10000.0);
						Point3D end = new Point3D(0.0, Operation.OperationData.selectedPlane.AxisZ.Y * -10000.0, Operation.OperationData.selectedPlane.AxisZ.Z * -10000.0);
						line = new Line(start, end);
					}
					else
					{
						line = new Line(new Point3D(0.0, -10000.0, Operation.OperationData.Position.Y + Operation.OperationData.movePlanePoint.Z), new Point3D(0.0, 10000.0, Operation.OperationData.Position.Y + Operation.OperationData.movePlanePoint.Z));
					}
				}
				else
				{
					line = new Line(new Point3D(0.0, Operation.OperationData.Position.Y, -10000.0), new Point3D(0.0, Operation.OperationData.Position.Y, 10000.0));
				}
				Point3D[] collection = linearPath.IntersectWith(line);
				list.AddRange(collection);
				for (int j = 0; j <= Profile.Drawings[i].InnerPoints.Count - 1; j++)
				{
					linearPath = new LinearPath(Profile.Drawings[i].InnerPoints[j]);
					Point3D[] collection2 = linearPath.IntersectWith(line);
					list.AddRange(collection2);
				}
			}
			buCall.buVector5_0.BoxSizeCalculate(list, ref MinPoint, ref MaxPoint);
			for (int k = 0; k <= list.Count - 1; k++)
			{
				if (Operation.OperationData.selectedPlaneName != planeNames.Top)
				{
					if (Operation.OperationData.selectedPlaneName != planeNames.Bottom)
					{
						if (Operation.OperationData.selectedPlaneName != planeNames.Front)
						{
							if (Operation.OperationData.selectedPlaneName == planeNames.Back && list[k].Y >= MaxPoint.Y - ExternalDepth)
							{
								List.Add(Math.Round(list[k].Y, 3));
							}
						}
						else if (list[k].Y <= MinPoint.Y + ExternalDepth)
						{
							List.Add(Math.Round(list[k].Y, 3));
						}
					}
					else if (list[k].Z <= MinPoint.Z + ExternalDepth)
					{
						List.Add(Math.Round(list[k].Z, 3));
					}
				}
				else if (list[k].Z >= MaxPoint.Z - ExternalDepth)
				{
					List.Add(Math.Round(list[k].Z, 3));
				}
			}
			if (Operation.OperationData.selectedPlaneName != planeNames.Top)
			{
				if (Operation.OperationData.selectedPlaneName != planeNames.Bottom)
				{
					if (Operation.OperationData.selectedPlaneName != planeNames.Front)
					{
						if (Operation.OperationData.selectedPlaneName == planeNames.Back)
						{
							buNumeric5.AddValueToList(Math.Round(MaxPoint.Y - ExternalDepth, 3), ref List);
						}
					}
					else
					{
						buNumeric5.AddValueToList(Math.Round(MinPoint.Y + ExternalDepth, 3), ref List);
					}
				}
				else
				{
					buNumeric5.AddValueToList(Math.Round(MinPoint.Z + ExternalDepth, 3), ref List);
				}
			}
			else
			{
				buNumeric5.AddValueToList(Math.Round(MaxPoint.Z - ExternalDepth, 3), ref List);
			}
			if (List.Count >= 2)
			{
				List.Sort();
				if ((Operation.OperationData.selectedPlaneName == planeNames.Top) | (Operation.OperationData.selectedPlaneName == planeNames.Back))
				{
					List.Reverse();
				}
			}
			bool flag = false;
			if ((Operation.OperationData.selectedPlaneName == planeNames.Top) | (Operation.OperationData.selectedPlaneName == planeNames.Back))
			{
				for (int l = 0; l <= List.Count - 1; l += 2)
				{
					if (l >= List.Count - 1)
					{
						continue;
					}
					double num3 = List[l] - List[l + 1];
					if (!((num3 >= Options.MinThickness) & (num3 <= Options.MaxThickness)))
					{
						continue;
					}
					DepthPositions depthPositions = new DepthPositions();
					depthPositions.TopPosition = List[l];
					depthPositions.BottomPosition = List[l + 1] - ExtraDepth;
					depthPositions.Depth = depthPositions.BottomPosition - depthPositions.TopPosition;
					if (!EachLayer)
					{
						if (!flag)
						{
							Operation.OperationData.Depth = new DepthPositions(depthPositions);
							flag = true;
						}
					}
					else
					{
						Operation.OperationData.DepthValues.Add(depthPositions);
					}
				}
				if (Operation.OperationData.ManuelZEnable)
				{
					Operation.OperationData.DepthValues.Clear();
					DepthPositions depthPositions2 = new DepthPositions();
					depthPositions2.TopPosition = Operation.OperationData.ManuelZVal;
					depthPositions2.BottomPosition = Operation.OperationData.ManuelZVal - Operation.OperationData.ExternalDepth - Operation.OperationData.ExtraDepth;
					depthPositions2.Depth = depthPositions2.BottomPosition - depthPositions2.TopPosition;
					Operation.OperationData.Depth = new DepthPositions(depthPositions2);
				}
			}
			if ((Operation.OperationData.selectedPlaneName == planeNames.Bottom) | (Operation.OperationData.selectedPlaneName == planeNames.Front))
			{
				for (int m = 0; m <= List.Count - 1; m += 2)
				{
					if (m >= List.Count - 1)
					{
						continue;
					}
					double num4 = List[m + 1] - List[m];
					if (!((num4 >= Options.MinThickness) & (num4 <= Options.MaxThickness)))
					{
						continue;
					}
					DepthPositions depthPositions3 = new DepthPositions();
					depthPositions3.TopPosition = List[m];
					depthPositions3.BottomPosition = List[m + 1] + ExtraDepth;
					depthPositions3.Depth = depthPositions3.BottomPosition - depthPositions3.TopPosition;
					if (!EachLayer)
					{
						if (!flag)
						{
							Operation.OperationData.Depth = new DepthPositions(depthPositions3);
							flag = true;
						}
					}
					else
					{
						Operation.OperationData.DepthValues.Add(depthPositions3);
					}
				}
				if (Operation.OperationData.ManuelZEnable)
				{
					Operation.OperationData.DepthValues.Clear();
					DepthPositions depthPositions4 = new DepthPositions();
					depthPositions4.TopPosition = Operation.OperationData.ManuelZVal;
					depthPositions4.BottomPosition = Operation.OperationData.ManuelZVal + Operation.OperationData.ExternalDepth + Operation.OperationData.ExtraDepth;
					depthPositions4.Depth = depthPositions4.BottomPosition - depthPositions4.TopPosition;
					Operation.OperationData.Depth = new DepthPositions(depthPositions4);
				}
			}
			if (Operation.OperationData.selectedPlaneName == planeNames.Free)
			{
				DepthPositions depthPositions5 = new DepthPositions();
				depthPositions5.TopPosition = 0.0;
				depthPositions5.BottomPosition = 0.0;
				depthPositions5.Depth = ExternalDepth;
				if (depthPositions5.Depth == 0.0)
				{
					depthPositions5.Depth = 2.0;
				}
				depthPositions5.Depth += ExtraDepth;
				Operation.OperationData.Depth = new DepthPositions(depthPositions5);
			}
			return true;
		}
		return false;
	}

	public void OperationStepCalculation(ProfileOperationData OperationData, DepthPositions DepthVal, camStep5 Steps, ref List<DepthPositions> calcDepth)
	{
		Steps.StartValue = DepthVal.TopPosition;
		if ((OperationData.selectedPlaneName == planeNames.Front) | (OperationData.selectedPlaneName == planeNames.Bottom))
		{
			Steps.EndValue = DepthVal.TopPosition + DepthVal.Depth;
		}
		if ((OperationData.selectedPlaneName == planeNames.Top) | (OperationData.selectedPlaneName == planeNames.Back))
		{
			Steps.EndValue = DepthVal.TopPosition + DepthVal.Depth;
		}
		if (OperationData.selectedPlaneName == planeNames.Free)
		{
			Steps.EndValue = DepthVal.Depth;
		}
		Steps.Distance = Steps.EndValue - Steps.StartValue;
		List<double> CalcValues = new List<double>();
		buCall.buCam5_0.CamStepCalculation(Steps, ref CalcValues);
		if (CalcValues.Count <= 0)
		{
			return;
		}
		for (int i = 0; i <= CalcValues.Count - 1; i++)
		{
			if (i != 0)
			{
				DepthPositions depthPositions = new DepthPositions();
				depthPositions.TopPosition = CalcValues[i - 1];
				depthPositions.BottomPosition = CalcValues[i];
				depthPositions.Depth = depthPositions.BottomPosition - depthPositions.TopPosition;
				if (depthPositions.Depth == 0.0)
				{
					depthPositions.Depth = 2.0;
				}
				calcDepth.Add(depthPositions);
			}
			else
			{
				DepthPositions depthPositions2 = new DepthPositions();
				depthPositions2.TopPosition = DepthVal.TopPosition;
				depthPositions2.BottomPosition = CalcValues[i];
				depthPositions2.Depth = depthPositions2.BottomPosition - depthPositions2.TopPosition;
				if (depthPositions2.Depth == 0.0)
				{
					depthPositions2.Depth = 2.0;
				}
				calcDepth.Add(depthPositions2);
			}
		}
	}

	public void GetOperationWithName(ProfileItem Profile, string OperationName, ref ProfileOperation foundOP)
	{
		int num = 0;
		while (true)
		{
			if (num <= Profile.Operations.Count - 1)
			{
				if (Profile.Operations[num].Name == OperationName)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		foundOP = new ProfileOperation();
		ProfileOperation.Copy(Profile.Operations[num], ref foundOP);
	}

	public bool isOperationEnableFromName(ProfileItem Profile, string OperationName)
	{
		for (int i = 0; i <= Profile.Operations.Count - 1; i++)
		{
			if (Profile.Operations[i].Name == OperationName)
			{
				return Profile.Operations[i].Enable;
			}
		}
		return false;
	}

	public double GetOperationRotationAngle(ProfileOperation OP)
	{
		if (OP.OperationData.OperationType != ProfileOperationTypes.Barrel)
		{
			if (OP.OperationData.OperationType != ProfileOperationTypes.Cut)
			{
				if (OP.OperationData.OperationType != ProfileOperationTypes.Ellipse)
				{
					if (OP.OperationData.OperationType != ProfileOperationTypes.FreeDraw)
					{
						if (OP.OperationData.OperationType != ProfileOperationTypes.Polygon)
						{
							if (OP.OperationData.OperationType != ProfileOperationTypes.Rectangle)
							{
								if (OP.OperationData.OperationType != ProfileOperationTypes.RoundRectangle)
								{
									if (OP.OperationData.OperationType != ProfileOperationTypes.Slot)
									{
										if (OP.OperationData.OperationType != ProfileOperationTypes.Text)
										{
											return 0.0;
										}
										return OP.OperationData.TextData.TextAngle;
									}
									return OP.OperationData.SlotData.SlotAngle;
								}
								return OP.OperationData.RectangleRoundData.RoundRectangleAngle;
							}
							return OP.OperationData.RectangleData.RectangleAngle;
						}
						return OP.OperationData.PolygonData.PolygonAngle;
					}
					return OP.OperationData.FreeDrawData.FreeDrawAngle;
				}
				return OP.OperationData.EllipseData.EllipseAngle;
			}
			return OP.OperationData.CutData.CutAngle;
		}
		return OP.OperationData.BarelData.BarrelAngle;
	}

	public void SetOperationRotationAngle(ref ProfileOperation OP, double Angle)
	{
		if (OP.OperationData.OperationType == ProfileOperationTypes.Barrel)
		{
			OP.OperationData.BarelData.BarrelAngle = Angle;
		}
		if (OP.OperationData.OperationType == ProfileOperationTypes.Cut)
		{
			OP.OperationData.CutData.CutAngle = Angle;
		}
		if (OP.OperationData.OperationType == ProfileOperationTypes.Ellipse)
		{
			OP.OperationData.EllipseData.EllipseAngle = Angle;
		}
		if (OP.OperationData.OperationType == ProfileOperationTypes.FreeDraw)
		{
			OP.OperationData.FreeDrawData.FreeDrawAngle = Angle;
		}
		if (OP.OperationData.OperationType == ProfileOperationTypes.Polygon)
		{
			OP.OperationData.PolygonData.PolygonAngle = Angle;
		}
		if (OP.OperationData.OperationType == ProfileOperationTypes.Rectangle)
		{
			OP.OperationData.RectangleData.RectangleAngle = Angle;
		}
		if (OP.OperationData.OperationType == ProfileOperationTypes.RoundRectangle)
		{
			OP.OperationData.RectangleRoundData.RoundRectangleAngle = Angle;
		}
		if (OP.OperationData.OperationType == ProfileOperationTypes.Slot)
		{
			OP.OperationData.SlotData.SlotAngle = Angle;
		}
		if (OP.OperationData.OperationType == ProfileOperationTypes.Text)
		{
			OP.OperationData.TextData.TextAngle = Angle;
		}
	}

	public void BoxSizeOfGOperationGroup(ref GProfileOperationGroup Grp)
	{
		List<Point3D> list = new List<Point3D>();
		for (int i = 0; i <= Grp.OpList.Count - 1; i++)
		{
			list.Add(buVector5.ToPoint3D(Grp.OpList[i].SizePoint.MaxPoint));
			list.Add(buVector5.ToPoint3D(Grp.OpList[i].SizePoint.MinPoint));
		}
		Point3D MinPoint = new Point3D();
		Point3D MaxPoint = new Point3D();
		buCall.buVector5_0.BoxSizeCalculate(list, ref MinPoint, ref MaxPoint);
		Grp.Size = new BoxSize5(MinPoint, MaxPoint);
	}

	public ProfileOperationTypes ProfileActionToOperationType(actionTypeBU Action)
	{
		ProfileOperationTypes result = ProfileOperationTypes.UnKnown;
		switch (Action)
		{
		default:
			return result;
		case actionTypeBU.profileRectangle:
			result = ProfileOperationTypes.Rectangle;
			return ProfileOperationTypes.Rectangle;
		case actionTypeBU.profileBarrel:
			result = ProfileOperationTypes.Barrel;
			return ProfileOperationTypes.Barrel;
		case actionTypeBU.profileCircle:
			result = ProfileOperationTypes.Circle;
			return ProfileOperationTypes.Circle;
		case actionTypeBU.profileCustomText:
			result = ProfileOperationTypes.CustomText;
			return ProfileOperationTypes.CustomText;
		case actionTypeBU.profileCut:
			result = ProfileOperationTypes.Cut;
			return ProfileOperationTypes.Cut;
		case actionTypeBU.profileEllipse:
			result = ProfileOperationTypes.Ellipse;
			return ProfileOperationTypes.Ellipse;
		case actionTypeBU.profileFreeDraw:
			result = ProfileOperationTypes.FreeDraw;
			return ProfileOperationTypes.FreeDraw;
		case actionTypeBU.profileFromFile:
			result = ProfileOperationTypes.FromFile;
			return ProfileOperationTypes.FromFile;
		case actionTypeBU.profileHole:
			result = ProfileOperationTypes.Hole;
			return ProfileOperationTypes.Hole;
		case actionTypeBU.profileTapping:
			result = ProfileOperationTypes.Tapping;
			return ProfileOperationTypes.Tapping;
		case actionTypeBU.profileNotch:
			result = ProfileOperationTypes.Notch;
			return ProfileOperationTypes.Notch;
		case actionTypeBU.profilePolygon:
			result = ProfileOperationTypes.Polygon;
			return ProfileOperationTypes.Polygon;
		case actionTypeBU.profileRoundRectangle:
			result = ProfileOperationTypes.RoundRectangle;
			return ProfileOperationTypes.RoundRectangle;
		case actionTypeBU.profileSlot:
			result = ProfileOperationTypes.Slot;
			return ProfileOperationTypes.Slot;
		case actionTypeBU.profileText:
			result = ProfileOperationTypes.Text;
			return ProfileOperationTypes.Text;
		case actionTypeBU.profileWireText:
			result = ProfileOperationTypes.WireText;
			return ProfileOperationTypes.WireText;
		}
	}

	public void MirrorOperation(ShapeMirror Mirror, ProfileItem Profile, ref ProfileOperation mirroredOP)
	{
		Point3D point3D = new Point3D();
		Plane planeMirror = Plane.XY;
		double num = Mirror.MirrorDistance;
		point3D = Point3D.MidPoint(mirroredOP.MinPoint, mirroredOP.MaxPoint);
		Point3D point3D2 = new Point3D(mirroredOP.MinPoint.X, mirroredOP.MinPoint.Y, mirroredOP.MinPoint.Z);
		Point3D point3D3 = new Point3D(mirroredOP.MinPoint.X, mirroredOP.MinPoint.Y, mirroredOP.MinPoint.Z);
		if (Mirror.MirrorLocation == MinCenterMaxType.Max)
		{
			point3D2 = new Point3D(mirroredOP.MaxPoint.X, mirroredOP.MaxPoint.Y, mirroredOP.MaxPoint.Z);
			point3D3 = new Point3D(mirroredOP.MaxPoint.X, mirroredOP.MaxPoint.Y, mirroredOP.MaxPoint.Z);
		}
		if (Mirror.MirrorLocation == MinCenterMaxType.Center)
		{
			point3D2 = new Point3D(point3D.X, point3D.Y, point3D.Z);
			point3D3 = new Point3D(point3D.X, point3D.Y, point3D.Z);
		}
		if (mirroredOP.OperationData.selectedPlaneName == planeNames.Front)
		{
			planeMirror = Plane.XZ;
		}
		if (mirroredOP.OperationData.selectedPlaneName == planeNames.Back)
		{
			planeMirror = Plane.XZ;
		}
		if (Mirror.MirrorMode == MirrorModeType.FromCenter)
		{
			num = 0.0;
			if (mirroredOP.OperationData.selectedPlaneName == planeNames.Top)
			{
				point3D2 = new Point3D(Profile.Length / 2.0, (0.0 - Profile.Width) / 2.0, Profile.Height);
				point3D3 = new Point3D(Profile.Length / 2.0, (0.0 - Profile.Width) / 2.0, Profile.Height);
			}
			if (mirroredOP.OperationData.selectedPlaneName == planeNames.Front)
			{
				point3D2 = new Point3D(Profile.Length / 2.0, 0.0 - Profile.Width, Profile.Height / 2.0);
				point3D3 = new Point3D(Profile.Length / 2.0, 0.0 - Profile.Width, Profile.Height / 2.0);
			}
			if (mirroredOP.OperationData.selectedPlaneName == planeNames.Back)
			{
				point3D2 = new Point3D(Profile.Length / 2.0, 0.0, Profile.Height / 2.0);
				point3D3 = new Point3D(Profile.Length / 2.0, 0.0, Profile.Height / 2.0);
			}
		}
		if (Mirror.MirrorAxis == MirrorAxisXYType.X)
		{
			if (mirroredOP.OperationData.selectedPlaneName == planeNames.Top)
			{
				point3D3.Y += 10.0;
				point3D3.X += num;
				point3D2.X += num;
			}
			if ((mirroredOP.OperationData.selectedPlaneName == planeNames.Front) | (mirroredOP.OperationData.selectedPlaneName == planeNames.Back))
			{
				point3D3.Z += 10.0;
				point3D3.X += num;
				point3D2.X += num;
			}
		}
		if (Mirror.MirrorAxis == MirrorAxisXYType.Y)
		{
			if (mirroredOP.OperationData.selectedPlaneName == planeNames.Top)
			{
				point3D3.X += 10.0;
				point3D3.Y += num;
				point3D2.Y += num;
			}
			if ((mirroredOP.OperationData.selectedPlaneName == planeNames.Front) | (mirroredOP.OperationData.selectedPlaneName == planeNames.Back))
			{
				point3D3.X += 10.0;
				point3D3.Z += num;
				point3D2.Z += num;
			}
		}
		if (mirroredOP.EntityMultiCam != null)
		{
			for (int i = 0; i <= mirroredOP.EntityMultiCam.Count - 1; i++)
			{
				mirroredOP.EntityMultiCam[i].Mirror(point3D2, point3D3, planeMirror);
			}
		}
		if (mirroredOP.EntityMultiContour != null)
		{
			for (int j = 0; j <= mirroredOP.EntityMultiContour.Count - 1; j++)
			{
				mirroredOP.EntityMultiContour[j].Mirror(point3D2, point3D3, planeMirror);
			}
		}
		if (mirroredOP.EntityMultiXYPlane != null)
		{
			for (int k = 0; k <= mirroredOP.EntityMultiXYPlane.Count - 1; k++)
			{
				mirroredOP.EntityMultiXYPlane[k].Mirror(point3D2, point3D3, planeMirror);
			}
		}
		buCall.buVector5_0.Mirror(point3D2, point3D3, planeMirror, ref mirroredOP.EntityMultiSolidDepth);
		Point3D mirrorPoint = new Point3D();
		buCall.buVector5_0.Mirror(point3D2, point3D3, planeMirror, mirroredOP.OperationData.Position, ref mirrorPoint);
		mirrorPoint = new Point3D();
		buCall.buVector5_0.Mirror(point3D2, point3D3, planeMirror, mirroredOP.MaxPoint, ref mirrorPoint);
		mirroredOP.MaxPoint = mirrorPoint;
		mirrorPoint = new Point3D();
		buCall.buVector5_0.Mirror(point3D2, point3D3, planeMirror, mirroredOP.MinPoint, ref mirrorPoint);
		mirroredOP.MinPoint = mirrorPoint;
		mirroredOP.OperationData.Mirror = new ShapeMirror(Mirror);
		if (mirroredOP.OperationData.Corner == CornerLocation.LeftBottom)
		{
			mirroredOP.OperationData.Corner = CornerLocation.RightBottom;
		}
	}

	public void FindShapeDataValueType(buShape Shape, int indexRow, ref ShapeDataValueType DataValue)
	{
		DataValue = ShapeDataValueType.None;
		if (Shape.ShapeGroup != ShapeGroup.Shape)
		{
			return;
		}
		if (indexRow == 0)
		{
			if ((Shape.planeName == planeBoxNames.Top) | (Shape.planeName == planeBoxNames.Bottom) | (Shape.planeName == planeBoxNames.Front) | (Shape.planeName == planeBoxNames.Back) | (Shape.planeName == planeBoxNames.Free))
			{
				DataValue = ShapeDataValueType.XPosition;
			}
			if ((Shape.planeName == planeBoxNames.Left) | (Shape.planeName == planeBoxNames.Right))
			{
				DataValue = ShapeDataValueType.YPosition;
			}
		}
		if (indexRow == 1)
		{
			if ((Shape.planeName == planeBoxNames.Top) | (Shape.planeName == planeBoxNames.Bottom) | (Shape.planeName == planeBoxNames.Free))
			{
				DataValue = ShapeDataValueType.YPosition;
			}
			if ((Shape.planeName == planeBoxNames.Front) | (Shape.planeName == planeBoxNames.Back) | (Shape.planeName == planeBoxNames.Left) | (Shape.planeName == planeBoxNames.Right))
			{
				DataValue = ShapeDataValueType.ZPosition;
			}
		}
		if (Shape.ShapeType == ShapeTypes.Rectangle)
		{
			if (indexRow == 2)
			{
				DataValue = ShapeDataValueType.Width;
			}
			if (indexRow == 3)
			{
				DataValue = ShapeDataValueType.Height;
			}
			if (indexRow == 4)
			{
				DataValue = ShapeDataValueType.Radius;
			}
			if (indexRow == 5)
			{
				DataValue = ShapeDataValueType.Depth;
			}
			if (indexRow == 6)
			{
				DataValue = ShapeDataValueType.ExtraDepth;
			}
		}
		if (Shape.ShapeType == ShapeTypes.Circle)
		{
			if (indexRow == 2)
			{
				DataValue = ShapeDataValueType.Width;
			}
			if (indexRow == 3)
			{
				DataValue = ShapeDataValueType.Depth;
			}
			if (indexRow == 4)
			{
				DataValue = ShapeDataValueType.ExtraDepth;
			}
		}
		if (Shape.ShapeType == ShapeTypes.Ellipse)
		{
			if (indexRow == 2)
			{
				DataValue = ShapeDataValueType.Width;
			}
			if (indexRow == 3)
			{
				DataValue = ShapeDataValueType.Height;
			}
			if (indexRow == 4)
			{
				DataValue = ShapeDataValueType.Depth;
			}
			if (indexRow == 5)
			{
				DataValue = ShapeDataValueType.ExtraDepth;
			}
		}
		if (Shape.ShapeType == ShapeTypes.KeyHole)
		{
			if (indexRow == 2)
			{
				DataValue = ShapeDataValueType.HeadDiameter;
			}
			if (indexRow == 3)
			{
				DataValue = ShapeDataValueType.Height;
			}
			if (indexRow == 4)
			{
				DataValue = ShapeDataValueType.Width;
			}
			if (indexRow == 5)
			{
				DataValue = ShapeDataValueType.Depth;
			}
			if (indexRow == 6)
			{
				DataValue = ShapeDataValueType.ExtraDepth;
			}
		}
		if (Shape.ShapeType == ShapeTypes.Slot)
		{
			if (indexRow == 2)
			{
				DataValue = ShapeDataValueType.Height;
			}
			if (indexRow == 3)
			{
				DataValue = ShapeDataValueType.Width;
			}
			if (indexRow == 4)
			{
				DataValue = ShapeDataValueType.Depth;
			}
			if (indexRow == 5)
			{
				DataValue = ShapeDataValueType.ExtraDepth;
			}
		}
		if (Shape.ShapeType == ShapeTypes.Polygon)
		{
			if (indexRow == 2)
			{
				DataValue = ShapeDataValueType.Width;
			}
			if (indexRow == 4)
			{
				DataValue = ShapeDataValueType.Depth;
			}
			if (indexRow == 5)
			{
				DataValue = ShapeDataValueType.ExtraDepth;
			}
		}
		if (Shape.ShapeType == ShapeTypes.Hole)
		{
			if (indexRow == 2)
			{
				DataValue = ShapeDataValueType.Width;
			}
			if (indexRow == 3)
			{
				DataValue = ShapeDataValueType.Depth;
			}
			if (indexRow == 4)
			{
				DataValue = ShapeDataValueType.ExtraDepth;
			}
		}
		if (Shape.ShapeType == ShapeTypes.Cut)
		{
			if (indexRow == 2)
			{
				DataValue = ShapeDataValueType.Width;
			}
			if (indexRow == 3)
			{
				DataValue = ShapeDataValueType.Height;
			}
			if (indexRow == 4)
			{
				DataValue = ShapeDataValueType.Depth;
			}
			if (indexRow == 5)
			{
				DataValue = ShapeDataValueType.ExtraDepth;
			}
		}
		if (Shape.ShapeType == ShapeTypes.FreeDraw)
		{
			if (indexRow == 2)
			{
				DataValue = ShapeDataValueType.Width;
			}
			if (indexRow == 3)
			{
				DataValue = ShapeDataValueType.Height;
			}
			if (indexRow == 4)
			{
				DataValue = ShapeDataValueType.Depth;
			}
			if (indexRow == 5)
			{
				DataValue = ShapeDataValueType.ExtraDepth;
			}
		}
		if (Shape.ShapeType == ShapeTypes.Text)
		{
			if (indexRow == 2)
			{
				DataValue = ShapeDataValueType.Width;
			}
			if (indexRow == 3)
			{
				DataValue = ShapeDataValueType.Height;
			}
			if (indexRow == 6)
			{
				DataValue = ShapeDataValueType.Depth;
			}
			if (indexRow == 7)
			{
				DataValue = ShapeDataValueType.ExtraDepth;
			}
		}
	}

	public void FindShapeDataValueType(ShapeRuntimeData Shape, int indexRow, ref ShapeDataValueType DataValue)
	{
		DataValue = ShapeDataValueType.None;
		if (Shape.ShapeGroup != ShapeGroup.Shape)
		{
			return;
		}
		if (indexRow == 0)
		{
			if ((Shape.selectedPlane == planeBoxNames.Top) | (Shape.selectedPlane == planeBoxNames.Bottom) | (Shape.selectedPlane == planeBoxNames.Front) | (Shape.selectedPlane == planeBoxNames.Back) | (Shape.selectedPlane == planeBoxNames.Free))
			{
				DataValue = ShapeDataValueType.XPosition;
			}
			if ((Shape.selectedPlane == planeBoxNames.Left) | (Shape.selectedPlane == planeBoxNames.Right))
			{
				DataValue = ShapeDataValueType.YPosition;
			}
		}
		if (indexRow == 1)
		{
			if ((Shape.selectedPlane == planeBoxNames.Top) | (Shape.selectedPlane == planeBoxNames.Bottom) | (Shape.selectedPlane == planeBoxNames.Free))
			{
				DataValue = ShapeDataValueType.YPosition;
			}
			if ((Shape.selectedPlane == planeBoxNames.Front) | (Shape.selectedPlane == planeBoxNames.Back) | (Shape.selectedPlane == planeBoxNames.Left) | (Shape.selectedPlane == planeBoxNames.Right))
			{
				DataValue = ShapeDataValueType.ZPosition;
			}
		}
		if (Shape.ShapeType == ShapeTypes.Rectangle)
		{
			if (indexRow == 2)
			{
				DataValue = ShapeDataValueType.Width;
			}
			if (indexRow == 3)
			{
				DataValue = ShapeDataValueType.Height;
			}
			if (indexRow == 4)
			{
				DataValue = ShapeDataValueType.Radius;
			}
			if (indexRow == 5)
			{
				DataValue = ShapeDataValueType.Depth;
			}
			if (indexRow == 6)
			{
				DataValue = ShapeDataValueType.ExtraDepth;
			}
		}
		if (Shape.ShapeType == ShapeTypes.Circle)
		{
			if (indexRow == 2)
			{
				DataValue = ShapeDataValueType.Width;
			}
			if (indexRow == 3)
			{
				DataValue = ShapeDataValueType.Depth;
			}
			if (indexRow == 4)
			{
				DataValue = ShapeDataValueType.ExtraDepth;
			}
		}
		if (Shape.ShapeType == ShapeTypes.Ellipse)
		{
			if (indexRow == 2)
			{
				DataValue = ShapeDataValueType.Width;
			}
			if (indexRow == 3)
			{
				DataValue = ShapeDataValueType.Height;
			}
			if (indexRow == 4)
			{
				DataValue = ShapeDataValueType.Depth;
			}
			if (indexRow == 5)
			{
				DataValue = ShapeDataValueType.ExtraDepth;
			}
		}
		if (Shape.ShapeType == ShapeTypes.KeyHole)
		{
			if (indexRow == 2)
			{
				DataValue = ShapeDataValueType.HeadDiameter;
			}
			if (indexRow == 3)
			{
				DataValue = ShapeDataValueType.Height;
			}
			if (indexRow == 4)
			{
				DataValue = ShapeDataValueType.Width;
			}
			if (indexRow == 5)
			{
				DataValue = ShapeDataValueType.Depth;
			}
			if (indexRow == 6)
			{
				DataValue = ShapeDataValueType.ExtraDepth;
			}
		}
		if (Shape.ShapeType == ShapeTypes.Slot)
		{
			if (indexRow == 2)
			{
				DataValue = ShapeDataValueType.Height;
			}
			if (indexRow == 3)
			{
				DataValue = ShapeDataValueType.Width;
			}
			if (indexRow == 4)
			{
				DataValue = ShapeDataValueType.Depth;
			}
			if (indexRow == 5)
			{
				DataValue = ShapeDataValueType.ExtraDepth;
			}
		}
		if (Shape.ShapeType == ShapeTypes.Polygon)
		{
			if (indexRow == 2)
			{
				DataValue = ShapeDataValueType.Width;
			}
			if (indexRow == 4)
			{
				DataValue = ShapeDataValueType.Depth;
			}
			if (indexRow == 5)
			{
				DataValue = ShapeDataValueType.ExtraDepth;
			}
		}
		if (Shape.ShapeType == ShapeTypes.Hole)
		{
			if (indexRow == 2)
			{
				DataValue = ShapeDataValueType.Width;
			}
			if (indexRow == 3)
			{
				DataValue = ShapeDataValueType.Depth;
			}
			if (indexRow == 4)
			{
				DataValue = ShapeDataValueType.ExtraDepth;
			}
		}
		if (Shape.ShapeType == ShapeTypes.Cut)
		{
			if (indexRow == 2)
			{
				DataValue = ShapeDataValueType.Width;
			}
			if (indexRow == 3)
			{
				DataValue = ShapeDataValueType.Height;
			}
			if (indexRow == 4)
			{
				DataValue = ShapeDataValueType.Depth;
			}
			if (indexRow == 5)
			{
				DataValue = ShapeDataValueType.ExtraDepth;
			}
		}
		if (Shape.ShapeType == ShapeTypes.FreeDraw)
		{
			if (indexRow == 2)
			{
				DataValue = ShapeDataValueType.Width;
			}
			if (indexRow == 3)
			{
				DataValue = ShapeDataValueType.Height;
			}
			if (indexRow == 4)
			{
				DataValue = ShapeDataValueType.Depth;
			}
			if (indexRow == 5)
			{
				DataValue = ShapeDataValueType.ExtraDepth;
			}
		}
		if (Shape.ShapeType == ShapeTypes.Text)
		{
			if (indexRow == 2)
			{
				DataValue = ShapeDataValueType.Width;
			}
			if (indexRow == 3)
			{
				DataValue = ShapeDataValueType.Height;
			}
			if (indexRow == 6)
			{
				DataValue = ShapeDataValueType.Depth;
			}
			if (indexRow == 7)
			{
				DataValue = ShapeDataValueType.ExtraDepth;
			}
		}
	}

	public void buShapeToProfileData(buShape Shape, ShapeRuntimeData shapeRuntimeData, ref ProfileOperationData OPData, ref actionTypeBU Action)
	{
		Action = actionTypeBU.None;
		if (Shape.GetType() == typeof(buShapeRectangle))
		{
			buShapeRectangle buShapeRectangle2 = Shape as buShapeRectangle;
			Action = actionTypeBU.profileRectangle;
			OPData.RectangleData.RectangleWidth = buShapeRectangle2.Width;
			OPData.RectangleData.RectangleHeight = buShapeRectangle2.Height;
			OPData.RectangleData.RectangleAngle = buShapeRectangle2.Angle;
			OPData.RectangleData.RectangleRadius = buShapeRectangle2.Radius;
			OPData.RectangleData.RectangleChamfer = buShapeRectangle2.Chamfer;
			if (buShapeRectangle2.Edit != null)
			{
				OPData.RectangleData.RectangleAngle = buShapeRectangle2.Edit.RotateDegree;
			}
		}
		if (Shape.GetType() == typeof(buShapeCircle))
		{
			buShapeCircle buShapeCircle2 = Shape as buShapeCircle;
			Action = actionTypeBU.profileCircle;
			OPData.CircleData.CircleDiameter = buShapeCircle2.Radius * 2.0;
		}
		if (Shape.GetType() == typeof(buShapeHole))
		{
			buShapeHole buShapeHole4 = Shape as buShapeHole;
			Action = actionTypeBU.profileHole;
			OPData.HoleData.HoleDiameter = buShapeHole4.Diameter;
			if (buShapeHole4.isTapping)
			{
				Action = actionTypeBU.profileTapping;
			}
		}
		if (Shape.GetType() == typeof(buShapeEllipse))
		{
			buShapeEllipse buShapeEllipse2 = Shape as buShapeEllipse;
			Action = actionTypeBU.profileEllipse;
			OPData.EllipseData.EllipseWidth = buShapeEllipse2.RadiusX * 2.0;
			OPData.EllipseData.EllipseHeight = buShapeEllipse2.RadiusY * 2.0;
			OPData.EllipseData.EllipseAngle = buShapeEllipse2.Angle;
			if (buShapeEllipse2.Edit != null)
			{
				OPData.EllipseData.EllipseAngle = buShapeEllipse2.Edit.RotateDegree;
			}
		}
		if (Shape.GetType() == typeof(buShapeKeyHole))
		{
			buShapeKeyHole buShapeKeyHole2 = Shape as buShapeKeyHole;
			Action = actionTypeBU.profileBarrel;
			OPData.BarelData.BarrelDiameter = buShapeKeyHole2.HeadDiameter;
			OPData.BarelData.BarrelLength = buShapeKeyHole2.Length;
			OPData.BarelData.BarrelWidth = buShapeKeyHole2.Diameter;
			OPData.BarelData.BarrelAngle = buShapeKeyHole2.Angle * 2.0;
			if (buShapeKeyHole2.Edit != null)
			{
				OPData.BarelData.BarrelAngle = buShapeKeyHole2.Edit.RotateDegree;
			}
		}
		if (Shape.GetType() == typeof(buShapePolygon))
		{
			buShapePolygon buShapePolygon2 = Shape as buShapePolygon;
			Action = actionTypeBU.profilePolygon;
			OPData.PolygonData.PolygonDiameter = buShapePolygon2.Radius * 2.0;
			OPData.PolygonData.PolygonSide = buShapePolygon2.Side;
			OPData.PolygonData.PolygonAngle = buShapePolygon2.Angle;
			if (buShapePolygon2.Edit != null)
			{
				OPData.PolygonData.PolygonAngle = buShapePolygon2.Edit.RotateDegree;
			}
		}
		if (Shape.GetType() == typeof(buShapeCut))
		{
			buShapeCut buShapeCut2 = Shape as buShapeCut;
			Action = actionTypeBU.profileCut;
			OPData.CutData.CutWidth = buShapeCut2.Diameter;
			OPData.CutData.CutHeigth = buShapeCut2.Length;
			if (buShapeCut2.Edit != null)
			{
				OPData.CutData.CutAngle = buShapeCut2.Edit.RotateDegree;
			}
		}
		if (Shape.GetType() == typeof(buShapeSlot))
		{
			buShapeSlot buShapeSlot2 = Shape as buShapeSlot;
			Action = actionTypeBU.profileSlot;
			OPData.SlotData.SlotDiameter = buShapeSlot2.Diameter;
			OPData.SlotData.SlotWidth = buShapeSlot2.Length;
			OPData.SlotData.SlotAngle = buShapeSlot2.Angle;
			if (buShapeSlot2.Edit != null)
			{
				OPData.SlotData.SlotAngle = buShapeSlot2.Edit.RotateDegree;
			}
		}
		if (Shape.GetType() == typeof(buShapeFreeDraw))
		{
			buShapeFreeDraw buShapeFreeDraw2 = Shape as buShapeFreeDraw;
			Action = actionTypeBU.profileFreeDraw;
			OPData.FreeDrawData.FreeDrawWidth = buShapeFreeDraw2.Width;
			OPData.FreeDrawData.FreeDrawHeight = buShapeFreeDraw2.Height;
			OPData.FreeDrawData.FreeDrawAngle = buShapeFreeDraw2.Angle;
			if (buShapeFreeDraw2.Edit != null)
			{
				OPData.FreeDrawData.FreeDrawAngle = buShapeFreeDraw2.Edit.RotateDegree;
			}
		}
		if (Shape.GetType() == typeof(buShapeText))
		{
			buShapeText buShapeText2 = Shape as buShapeText;
			Action = actionTypeBU.profileText;
			OPData.TextData.TextWidth = buShapeText2.Width;
			OPData.TextData.TextHeight = buShapeText2.Height;
			OPData.TextData.TextString = buShapeText2.TextString;
			OPData.TextData.TextFont = new Font(buShapeText2.TextFont.Name, buShapeText2.TextFont.Size, buShapeText2.TextFont.Style);
			OPData.TextData.isWire = buShapeText2.isWire;
			if (buShapeText2.isWire)
			{
				Action = actionTypeBU.profileWireText;
			}
			if (buShapeText2.Edit != null)
			{
				OPData.TextData.TextAngle = buShapeText2.Edit.RotateDegree;
			}
		}
		if (Shape.GetType() == typeof(buShapeNotch))
		{
			buShapeNotch buShapeNotch2 = Shape as buShapeNotch;
			Action = actionTypeBU.profileNotch;
			OPData.NotchData.NotchWidth = buShapeNotch2.NotchWidth;
			OPData.NotchData.NotchHeight = buShapeNotch2.NotchHeight;
			OPData.NotchData.NotchStart = buShapeNotch2.NotchStartHeight;
			OPData.NotchData.NotchDepth = buShapeNotch2.Depth;
			OPData.NotchData.NotchUpDown = buShapeNotch2.NotchUpDown;
			OPData.NotchData.NotchFrontBack = buShapeNotch2.NotchFrontBack;
			OPData.NotchData.NotchLocation = buShapeNotch2.NotchLocation;
			OPData.NotchData.NotchOPType = buShapeNotch2.NotchOPType;
		}
		OPData.ExternalDepth = Shape.Depth;
		OPData.basePosition.X = Shape.BasePoint.X;
		OPData.basePosition.Y = Shape.BasePoint.Y;
		OPData.basePosition.Z = Shape.BasePoint.Z;
		OPData.selectedPlaneName = (planeNames)Convert.ToInt32(Shape.planeName);
		if (Shape.planeOperation != null && Shape.planeOperation != OPData.selectedPlane)
		{
			OPData.selectedPlane = (Plane)Shape.planeOperation.Clone();
		}
		if (Shape.Edit != null)
		{
			OPData.Array.LineerEnable = Shape.Edit.ArrayData.LineerEnable;
			OPData.Array.CircularEnable = Shape.Edit.ArrayData.CircularEnable;
			OPData.Mirror.MirrorEnable = Shape.Edit.MirrorData.MirrorEnable;
			if (Shape.Edit.ArrayData.LineerEnable)
			{
				OPData.Array.LineerEnable = true;
				OPData.Array.LineerXCount = Shape.Edit.ArrayData.LineerXCount;
				OPData.Array.LineerXDistance = Shape.Edit.ArrayData.LineerXDistance;
				OPData.Array.LineerYCount = Shape.Edit.ArrayData.LineerYCount;
				OPData.Array.LineerYDistance = Shape.Edit.ArrayData.LineerYDistance;
			}
			if (Shape.Edit.ArrayData.CircularEnable)
			{
				OPData.Array.CircularEnable = true;
				OPData.Array.CircularCount = Shape.Edit.ArrayData.CircularCount;
				OPData.Array.CircularAngle = Shape.Edit.ArrayData.CircularAngle;
			}
			if (Shape.Edit.MirrorData.MirrorEnable)
			{
				OPData.Mirror.MirrorEnable = true;
				OPData.Mirror.MirrorDistance = Shape.Edit.MirrorData.MirrorDistance;
				OPData.Mirror.MirrorLocation = Shape.Edit.MirrorData.MirrorLocation;
				OPData.Mirror.MirrorMode = Shape.Edit.MirrorData.MirrorMode;
				OPData.Mirror.MirrorAxis = Shape.Edit.MirrorData.MirrorAxis;
			}
		}
		OPData.EachLayer = shapeRuntimeData.EachLayer;
		OPData.ManuelZEnable = shapeRuntimeData.ManuelDepthEnable;
		OPData.ManuelZVal = shapeRuntimeData.ManuelDepthStart;
		OPData.IncrementalDistance = shapeRuntimeData.IncrementalDistance;
		OPData.ExtraDepth = shapeRuntimeData.ExtraDepth;
		OPData.Alignment = Shape.Alignment;
		OPData.Corner = Shape.Corner;
		if (!(Shape.GetType() == typeof(buShapeNotch)))
		{
			OPData.CamParMilling = new camParameters5(Shape.CamPar);
			OPData.CamParMilling.Operations.AreaClearanceEnable = Shape.isPocket;
		}
		else
		{
			OPData.CamParNotch = new camParameters5(Shape.CamPar);
		}
		OPData.Action = Action;
	}

	public void buShapeToProfileData(ShapeRuntimeData shapeRuntimeData, ref ProfileOperationData OPData, ref actionTypeBU Action)
	{
		Action = actionTypeBU.None;
		if (shapeRuntimeData.ShapeType == ShapeTypes.Rectangle)
		{
			Action = actionTypeBU.profileRectangle;
			OPData.RectangleData.RectangleWidth = shapeRuntimeData.RectangleWidth;
			OPData.RectangleData.RectangleHeight = shapeRuntimeData.RectangleHeight;
			OPData.RectangleData.RectangleAngle = shapeRuntimeData.RectangleAngle;
			OPData.ExternalDepth = shapeRuntimeData.RectangleDepth;
			OPData.RectangleData.RectangleRadius = shapeRuntimeData.RectangleRadius;
			OPData.RectangleData.RectangleChamfer = shapeRuntimeData.RectangleChamfer;
			OPData.RectangleData.RectangleAngle = shapeRuntimeData.Edit.RotateDegree;
		}
		if (shapeRuntimeData.ShapeType == ShapeTypes.Circle)
		{
			Action = actionTypeBU.profileCircle;
			OPData.CircleData.CircleDiameter = shapeRuntimeData.CircleRadius * 2.0;
			OPData.ExternalDepth = shapeRuntimeData.CircleDepth;
		}
		if (shapeRuntimeData.ShapeType == ShapeTypes.Hole)
		{
			Action = actionTypeBU.profileHole;
			OPData.HoleData.HoleDiameter = shapeRuntimeData.HoleDiameter;
			OPData.ExternalDepth = shapeRuntimeData.HoleDepth;
			OPData.HoleData.TappingDepth = shapeRuntimeData.TappingDepth;
			OPData.HoleData.TappingDiameter = shapeRuntimeData.TappingDiameter;
			OPData.HoleData.TappingPitch = shapeRuntimeData.TappingPitch;
			if (shapeRuntimeData.isTapping)
			{
				Action = actionTypeBU.profileTapping;
			}
		}
		if (shapeRuntimeData.ShapeType == ShapeTypes.Ellipse)
		{
			Action = actionTypeBU.profileEllipse;
			OPData.EllipseData.EllipseWidth = shapeRuntimeData.EllipseRadiusX * 2.0;
			OPData.EllipseData.EllipseHeight = shapeRuntimeData.EllipseRadiusY * 2.0;
			OPData.EllipseData.EllipseAngle = shapeRuntimeData.Edit.RotateDegree;
			OPData.ExternalDepth = shapeRuntimeData.EllipseDepth;
		}
		if (shapeRuntimeData.ShapeType == ShapeTypes.KeyHole)
		{
			Action = actionTypeBU.profileBarrel;
			OPData.BarelData.BarrelDiameter = shapeRuntimeData.KeyHoleHeadDiameter;
			OPData.BarelData.BarrelLength = shapeRuntimeData.KeyHoleLength;
			OPData.BarelData.BarrelWidth = shapeRuntimeData.KeyHoleDiameter;
			OPData.BarelData.BarrelAngle = shapeRuntimeData.Edit.RotateDegree;
			OPData.ExternalDepth = shapeRuntimeData.KeyHoleDepth;
		}
		if (shapeRuntimeData.ShapeType == ShapeTypes.Polygon)
		{
			Action = actionTypeBU.profilePolygon;
			OPData.PolygonData.PolygonDiameter = shapeRuntimeData.PolygonRadius * 2.0;
			OPData.PolygonData.PolygonSide = shapeRuntimeData.PolygonSide;
			OPData.PolygonData.PolygonAngle = shapeRuntimeData.Edit.RotateDegree;
			OPData.ExternalDepth = shapeRuntimeData.PolygonDepth;
		}
		if (shapeRuntimeData.ShapeType == ShapeTypes.Cut)
		{
			Action = actionTypeBU.profileCut;
			OPData.CutData.CutWidth = shapeRuntimeData.CutDiameter;
			OPData.CutData.CutHeigth = shapeRuntimeData.CutLength;
			OPData.CutData.CutAngle = shapeRuntimeData.Edit.RotateDegree;
			OPData.ExternalDepth = shapeRuntimeData.CutDepth;
		}
		if (shapeRuntimeData.ShapeType == ShapeTypes.Slot)
		{
			Action = actionTypeBU.profileSlot;
			OPData.SlotData.SlotDiameter = shapeRuntimeData.SlotDiameter;
			OPData.SlotData.SlotWidth = shapeRuntimeData.SlotLength;
			OPData.SlotData.SlotAngle = shapeRuntimeData.Edit.RotateDegree;
			OPData.ExternalDepth = shapeRuntimeData.SlotDepth;
		}
		if (shapeRuntimeData.ShapeType == ShapeTypes.FreeDraw)
		{
			Action = actionTypeBU.profileFreeDraw;
			OPData.FreeDrawData.FreeDrawWidth = shapeRuntimeData.FreeDrawWidth;
			OPData.FreeDrawData.FreeDrawHeight = shapeRuntimeData.FreeDrawHeight;
			OPData.ExternalDepth = shapeRuntimeData.FreeDrawDepth;
			OPData.FreeDrawData.FreeDrawAngle = shapeRuntimeData.Edit.RotateDegree;
		}
		if (shapeRuntimeData.ShapeType == ShapeTypes.Text)
		{
			Action = actionTypeBU.profileText;
			OPData.TextData.TextWidth = shapeRuntimeData.TextWidth;
			OPData.TextData.TextHeight = shapeRuntimeData.TextHeight;
			OPData.TextData.TextString = shapeRuntimeData.TextString;
			OPData.ExternalDepth = shapeRuntimeData.TextDepth;
			OPData.TextData.TextFont = new Font(shapeRuntimeData.TextFont.Name, shapeRuntimeData.TextFont.Size, shapeRuntimeData.TextFont.Style);
			OPData.TextData.isWire = shapeRuntimeData.TextIsWire;
			if (shapeRuntimeData.TextIsWire)
			{
				Action = actionTypeBU.profileWireText;
			}
			OPData.TextData.TextAngle = shapeRuntimeData.Edit.RotateDegree;
		}
		if (shapeRuntimeData.ShapeType == ShapeTypes.Notch)
		{
			Action = actionTypeBU.profileNotch;
			OPData.NotchData.NotchWidth = shapeRuntimeData.NotchWidth;
			OPData.NotchData.NotchHeight = shapeRuntimeData.NotchHeight;
			OPData.NotchData.NotchStart = shapeRuntimeData.NotchStartHeight;
			OPData.NotchData.NotchDepth = shapeRuntimeData.NotchDepth;
			OPData.NotchData.NotchUpDown = shapeRuntimeData.NotchUpDown;
			OPData.NotchData.NotchFrontBack = shapeRuntimeData.NotchFrontBack;
			OPData.NotchData.NotchOPType = shapeRuntimeData.NotchOPType;
			if (!((OPData.NotchData.NotchOPType == ProfileNotchOperationType.Side) | (OPData.NotchData.NotchOPType == ProfileNotchOperationType.Vertical) | (OPData.NotchData.NotchOPType == ProfileNotchOperationType.Horizontal)))
			{
				OPData.NotchData.NotchLocation = shapeRuntimeData.NotchLengthLocation;
			}
			else
			{
				OPData.NotchData.NotchLocation = shapeRuntimeData.NotchSideLocation;
			}
		}
		OPData.basePosition.X = shapeRuntimeData.pntBase.X;
		OPData.basePosition.Y = shapeRuntimeData.pntBase.Y;
		OPData.basePosition.Z = shapeRuntimeData.pntBase.Z;
		OPData.selectedPlaneName = (planeNames)Convert.ToInt32(shapeRuntimeData.selectedPlane);
		OPData.selectedPlane = buCall.buVector5_0.PlaneNameToPlane(shapeRuntimeData.selectedPlane);
		if (shapeRuntimeData.Edit != null)
		{
			OPData.Array.LineerEnable = shapeRuntimeData.Edit.ArrayData.LineerEnable;
			OPData.Array.CircularEnable = shapeRuntimeData.Edit.ArrayData.CircularEnable;
			OPData.Mirror.MirrorEnable = shapeRuntimeData.Edit.MirrorData.MirrorEnable;
			if (shapeRuntimeData.Edit.ArrayData.LineerEnable)
			{
				OPData.Array.LineerEnable = true;
				OPData.Array.LineerXCount = shapeRuntimeData.Edit.ArrayData.LineerXCount;
				OPData.Array.LineerXDistance = shapeRuntimeData.Edit.ArrayData.LineerXDistance;
				OPData.Array.LineerYCount = shapeRuntimeData.Edit.ArrayData.LineerYCount;
				OPData.Array.LineerYDistance = shapeRuntimeData.Edit.ArrayData.LineerYDistance;
			}
			if (shapeRuntimeData.Edit.ArrayData.CircularEnable)
			{
				OPData.Array.CircularEnable = true;
				OPData.Array.CircularCount = shapeRuntimeData.Edit.ArrayData.CircularCount;
				OPData.Array.CircularAngle = shapeRuntimeData.Edit.ArrayData.CircularAngle;
			}
			if (shapeRuntimeData.Edit.MirrorData.MirrorEnable)
			{
				OPData.Mirror.MirrorEnable = true;
				OPData.Mirror.MirrorDistance = shapeRuntimeData.Edit.MirrorData.MirrorDistance;
				OPData.Mirror.MirrorLocation = shapeRuntimeData.Edit.MirrorData.MirrorLocation;
				OPData.Mirror.MirrorMode = shapeRuntimeData.Edit.MirrorData.MirrorMode;
				OPData.Mirror.MirrorAxis = shapeRuntimeData.Edit.MirrorData.MirrorAxis;
			}
		}
		OPData.EachLayer = shapeRuntimeData.EachLayer;
		OPData.ManuelZEnable = shapeRuntimeData.ManuelDepthEnable;
		OPData.ManuelZVal = shapeRuntimeData.ManuelDepthStart;
		OPData.IncrementalDistance = shapeRuntimeData.IncrementalDistance;
		OPData.ExtraDepth = shapeRuntimeData.ExtraDepth;
		OPData.Alignment = shapeRuntimeData.objectAlignment;
		OPData.Corner = shapeRuntimeData.selectedCorner;
		if (shapeRuntimeData.ShapeType != ShapeTypes.Notch)
		{
			OPData.CamParMilling = new camParameters5(shapeRuntimeData.CamPars);
			OPData.CamParMilling.Operations.AreaClearanceEnable = shapeRuntimeData.isShapePocket;
		}
		else
		{
			OPData.CamParNotch = new camParameters5(shapeRuntimeData.CamPars);
		}
		OPData.Action = Action;
	}

	public void CamParameterToProfileCamData(camParameters5 CamData, ref ProfileOperationCamData CamProfileData)
	{
		CamProfileData.distanceSafe = CamData.Distances.Safe;
		CamProfileData.distanceRapid = CamData.Distances.Rapid;
		CamProfileData.distanceFirstApproach = CamData.Distances.FirstApproach;
		CamProfileData.velPlunge = CamData.Speeds.Plunge;
		CamProfileData.velFeed = CamData.Speeds.Feed;
		CamProfileData.velFinish = CamData.Speeds.Finish;
		CamProfileData.velAreaClearance = CamData.Speeds.AreaClearance;
		CamProfileData.velLeave = CamData.Speeds.Leave;
		CamProfileData.stepCount = CamData.Steps.Count;
		CamProfileData.stepDistance = CamData.Steps.Step;
		CamProfileData.enableStepOperation = CamData.Steps.Enable;
		CamProfileData.LeadIn = CamData.LeadIn.Enable;
		CamProfileData.LeadOut = CamData.LeadOut.Enable;
		CamProfileData.NotchCutPersentage = CamData.Notch.NotchCutPersentage;
		CamProfileData.offsetFinish = CamData.Offsets.FinishOffset;
		CamProfileData.typeClosedContour = CamData.Offsets.ClosedContour;
		CamProfileData.typeOpenContour = CamData.Offsets.OpenContour;
		CamProfileData.AreaClearanceDirection = CamData.Operations.AreaClearanceDirection;
		CamProfileData.directionContour = CamData.Operations.Direction;
		CamProfileData.enableAreaClearanceOperation = CamData.Operations.AreaClearanceEnable;
		CamProfileData.enableFinishOperation = CamData.Operations.FinishEnable;
		CamProfileData.enableOpenContourTwoDirectionCutOperation = CamData.Strategy.OpenContourTwoDirectionCut;
	}

	public void ProfileCamDataToCamParameter(ProfileOperationCamData CamProfileData, ref camParameters5 CamData)
	{
		CamData.Distances.Safe = CamProfileData.distanceSafe;
		CamData.Distances.Rapid = CamProfileData.distanceRapid;
		CamData.Distances.FirstApproach = CamProfileData.distanceFirstApproach;
		CamData.Speeds.Plunge = CamProfileData.velPlunge;
		CamData.Speeds.Feed = CamProfileData.velFeed;
		CamData.Speeds.Finish = CamProfileData.velFinish;
		CamData.Speeds.Leave = CamProfileData.velLeave;
		CamData.Speeds.AreaClearance = CamProfileData.velAreaClearance;
		CamData.Steps.Count = CamProfileData.stepCount;
		CamData.Steps.Step = CamProfileData.stepDistance;
		CamData.Steps.Enable = CamProfileData.enableStepOperation;
		CamData.LeadIn.Enable = CamProfileData.LeadIn;
		CamData.LeadOut.Enable = CamProfileData.LeadOut;
		CamData.Notch.NotchCutPersentage = CamProfileData.NotchCutPersentage;
		CamData.Notch.NotchCutType = CamProfileData.NotchCutType;
		CamData.Offsets.FinishOffset = CamProfileData.offsetFinish;
		CamData.Offsets.ClosedContour = CamProfileData.typeClosedContour;
		CamData.Offsets.OpenContour = CamProfileData.typeOpenContour;
		CamData.Operations.AreaClearanceDirection = CamProfileData.AreaClearanceDirection;
		CamData.Operations.Direction = CamProfileData.directionContour;
		CamData.Operations.AreaClearanceEnable = CamProfileData.enableAreaClearanceOperation;
		CamData.Operations.FinishEnable = CamProfileData.enableFinishOperation;
		CamData.Strategy.OpenContourTwoDirectionCut = CamProfileData.enableOpenContourTwoDirectionCutOperation;
	}

	public void AddOperationListsToProfileLists(ref ProfileItem Profile)
	{
		for (int i = 0; i <= Profile.Operations.Count - 1; i++)
		{
			for (int j = 0; j <= Profile.Operations[i].warningList.Count - 1; j++)
			{
				AddWarningToProfile(Profile.Operations[i].warningList[j], ref Profile);
			}
			for (int k = 0; k <= Profile.Operations[i].errorList.Count - 1; k++)
			{
				AddErrorToProfile(Profile.Operations[i].errorList[k], ref Profile);
			}
			for (int l = 0; l <= Profile.Operations[i].infoList.Count - 1; l++)
			{
				AddInfoToProfile(Profile.Operations[i].infoList[l], ref Profile);
			}
		}
	}

	public void AddWarningToProfile(string strWarning, ref ProfileItem Profile)
	{
		if (Profile.warningAllList.Count != 0)
		{
			int num = 0;
			while (true)
			{
				if (num <= Profile.warningAllList.Count - 1)
				{
					if (!(Profile.warningAllList[num] == strWarning))
					{
						num++;
						continue;
					}
					break;
				}
				Profile.warningAllList.Add(strWarning);
				break;
			}
		}
		else
		{
			Profile.warningAllList.Add(strWarning);
		}
	}

	public void AddErrorToProfile(string strError, ref ProfileItem Profile)
	{
		if (Profile.errorAllList.Count != 0)
		{
			for (int i = 0; i <= Profile.errorAllList.Count - 1; i++)
			{
				if (Profile.errorAllList[i] == strError)
				{
					if (Profile.errorAllList.Count > 0)
					{
						Profile.isError = true;
					}
					return;
				}
			}
			Profile.errorAllList.Add(strError);
		}
		else
		{
			Profile.errorAllList.Add(strError);
		}
		if (Profile.errorAllList.Count > 0)
		{
			Profile.isError = true;
		}
	}

	public void AddInfoToProfile(string strInfo, ref ProfileItem Profile)
	{
		if (Profile.infoAllList.Count != 0)
		{
			int num = 0;
			while (true)
			{
				if (num <= Profile.infoAllList.Count - 1)
				{
					if (!(Profile.infoAllList[num] == strInfo))
					{
						num++;
						continue;
					}
					break;
				}
				Profile.infoAllList.Add(strInfo);
				break;
			}
		}
		else
		{
			Profile.infoAllList.Add(strInfo);
		}
	}

	public void AddWarningToOperation(string strWarning, ref ProfileOperation OP)
	{
		if (OP.warningList.Count != 0)
		{
			int num = 0;
			while (true)
			{
				if (num <= OP.warningList.Count - 1)
				{
					if (!(OP.warningList[num] == strWarning))
					{
						num++;
						continue;
					}
					break;
				}
				OP.warningList.Add(strWarning);
				break;
			}
		}
		else
		{
			OP.warningList.Add(strWarning);
		}
	}

	public void AddErrorToOperation(string strError, ref ProfileOperation OP)
	{
		if (OP.errorList.Count != 0)
		{
			for (int i = 0; i <= OP.errorList.Count - 1; i++)
			{
				if (OP.errorList[i] == strError)
				{
					if (OP.errorList.Count > 0)
					{
						OP.Error = true;
					}
					return;
				}
			}
			OP.errorList.Add(strError);
		}
		else
		{
			OP.errorList.Add(strError);
		}
		if (OP.errorList.Count > 0)
		{
			OP.Error = true;
		}
	}

	public void AddInfoToOperation(string strInfo, ref ProfileOperation OP)
	{
		if (OP.infoList.Count != 0)
		{
			int num = 0;
			while (true)
			{
				if (num <= OP.infoList.Count - 1)
				{
					if (!(OP.infoList[num] == strInfo))
					{
						num++;
						continue;
					}
					break;
				}
				OP.infoList.Add(strInfo);
				break;
			}
		}
		else
		{
			OP.infoList.Add(strInfo);
		}
	}

	public static string ToolToString(ToolBase5 Tool)
	{
		if (Tool != null)
		{
			return Tool.Data.Name + " - T: " + Tool.Data.No;
		}
		return "";
	}

	public bool isToolForHole(ToolBase5 Tool)
	{
		if (Tool != null)
		{
			if (!((Tool.Purpose == ToolPurpose.General) | (Tool.Purpose == ToolPurpose.Milling) | (Tool.Purpose == ToolPurpose.Hole) | (Tool.Purpose == ToolPurpose.Drilling)))
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public bool isToolForMilling(ToolBase5 Tool)
	{
		if (Tool != null)
		{
			if (!((Tool.Purpose == ToolPurpose.General) | (Tool.Purpose == ToolPurpose.Milling) | (Tool.Purpose == ToolPurpose.Cutting) | (Tool.Purpose == ToolPurpose.CutCenter) | (Tool.Purpose == ToolPurpose.CutIn) | (Tool.Purpose == ToolPurpose.CutOut)))
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public bool isToolForNotch(ToolBase5 Tool)
	{
		if (Tool != null)
		{
			if (Tool.Geometry.GeometryType != ToolType.Saw)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public bool isToolSuitableForOperation(ProfileOperation OP, ref List<string> Messages)
	{
		bool result = true;
		Messages.Clear();
		if (OP.OperationData.Action != actionTypeBU.profileNotch)
		{
			if (OP.OperationData.Action != actionTypeBU.profileTapping)
			{
				if (OP.OperationData.Action != actionTypeBU.profileHole)
				{
					if (OP.Tool == null)
					{
						Messages.Add(buLangTranslate.preSentencesProfile.NoMillingToolSelected);
					}
					if (OP.Tool != null && !isToolForMilling(OP.Tool))
					{
						Messages.Add(buLangTranslate.preSentencesProfile.NoMillingToolSelected);
					}
				}
				else
				{
					if (OP.Tool == null)
					{
						Messages.Add(buLangTranslate.preSentencesProfile.NoTappingToolSelected);
					}
					if (OP.Tool != null && ((OP.Tool.Purpose != ToolPurpose.Drilling) & (OP.Tool.Purpose != ToolPurpose.Milling) & (OP.Tool.Purpose != ToolPurpose.General)))
					{
						Messages.Add(buLangTranslate.preSentencesProfile.NoHoleToolSelected);
					}
				}
			}
			else
			{
				if (OP.Tool == null)
				{
					Messages.Add(buLangTranslate.preSentencesProfile.NoTappingToolSelected);
				}
				if (OP.ToolAux == null)
				{
					Messages.Add(buLangTranslate.preSentencesProfile.NoHoleToolSelected);
				}
				if (OP.Tool != null && OP.Tool.Purpose != ToolPurpose.Tapping)
				{
					Messages.Add(buLangTranslate.preSentencesProfile.NoTappingToolSelected);
				}
				if (OP.ToolAux != null && !isToolForHole(OP.ToolAux))
				{
					Messages.Add(buLangTranslate.preSentencesProfile.NoHoleToolSelected);
				}
			}
		}
		else
		{
			if (OP.ToolNotch == null)
			{
				Messages.Add(buLangTranslate.preSentencesProfile.NotchToolisnotAvailavle);
			}
			if (OP.ToolNotch != null && OP.ToolNotch.Geometry.GeometryType != ToolType.Saw)
			{
				Messages.Add(buLangTranslate.preSentencesProfile.NotchToolisnotAvailavle);
			}
		}
		if (OP.Tool != null)
		{
			if (OP.OperationData.selectedPlaneName == planeNames.Top && (!OP.Tool.Limits.PlaneAll & !OP.Tool.Limits.PlaneTop))
			{
				Messages.Add(buLangTranslate.preSentencesProfile.ThisPlaneIsNotSuitable + " " + buLangTranslate.preDef.Top);
			}
			if (OP.OperationData.selectedPlaneName == planeNames.Bottom && (!OP.Tool.Limits.PlaneAll & !OP.Tool.Limits.PlaneBottom))
			{
				Messages.Add(buLangTranslate.preSentencesProfile.ThisPlaneIsNotSuitable + " " + buLangTranslate.preDef.Bottom);
			}
			if (OP.OperationData.selectedPlaneName == planeNames.Front && (!OP.Tool.Limits.PlaneAll & !OP.Tool.Limits.PlaneFront))
			{
				Messages.Add(buLangTranslate.preSentencesProfile.ThisPlaneIsNotSuitable + " " + buLangTranslate.preDef.Front);
			}
			if (OP.OperationData.selectedPlaneName == planeNames.Back && (!OP.Tool.Limits.PlaneAll & !OP.Tool.Limits.PlaneBack))
			{
				Messages.Add(buLangTranslate.preSentencesProfile.ThisPlaneIsNotSuitable + " " + buLangTranslate.preDef.Back);
			}
			if (OP.OperationData.selectedPlaneName == planeNames.Free && (!OP.Tool.Limits.PlaneAll & !OP.Tool.Limits.PlaneSlope))
			{
				Messages.Add(buLangTranslate.preSentencesProfile.ThisPlaneIsNotSuitable + " " + buLangTranslate.preDef.Free);
			}
		}
		if (Messages.Count <= 0)
		{
			return result;
		}
		return false;
	}

	public void ToolDataToOPCamData(ref ProfileOperationData Data, ToolBase5 Tool, bool SpeedData = true, bool DistanceData = true)
	{
		if (SpeedData)
		{
			Data.CamParMilling.Speeds.Feed = Tool.CamData.FeedSpeed;
			Data.CamParMilling.Speeds.Plunge = Tool.CamData.PlungeSpeed;
			Data.CamParMilling.Speeds.Finish = Tool.CamData.FinishSpeed;
			Data.CamParMilling.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
		}
		if (DistanceData)
		{
			Data.CamParMilling.Distances.Safe = Tool.CamData.SafeDistance;
			Data.CamParMilling.Distances.Rapid = Tool.CamData.RapidDistance;
		}
	}

	public bool FindNotchTool(List<ToolGroup5> ToolGroup, ref ToolBase5 foundTool)
	{
		foundTool = null;
		for (int i = 0; i <= ToolGroup.Count - 1; i++)
		{
			for (int j = 0; j <= ToolGroup[i].Tools.Count - 1; j++)
			{
				if (ToolGroup[i].Tools[j].Geometry.GeometryType == ToolType.Saw)
				{
					foundTool = new ToolBase5(ToolGroup[i].Tools[j]);
					return true;
				}
			}
		}
		return false;
	}

	public void CheckToolLength(ProfileOperation Operation, ToolBase5 Tool, double ToolHolderLength, ref bool isToolLenShort, ref bool isToolCutLenShort)
	{
		isToolLenShort = false;
		isToolCutLenShort = false;
		if (Tool == null)
		{
			return;
		}
		if (Operation.OperationData.OperationType != ProfileOperationTypes.Notch)
		{
			if (Operation.OperationData.DepthValues.Count <= 0)
			{
				double num = Math.Abs(Operation.OperationData.Depth.TopPosition - Operation.OperationData.Depth.BottomPosition);
				if (Operation.OperationData.CamParMilling.Steps.Enable)
				{
					num = Operation.OperationData.CamParMilling.Steps.Step;
				}
				if (num > Tool.Geometry.TotalLength - ToolHolderLength)
				{
					isToolLenShort = true;
				}
				if (num > Tool.Geometry.CutLength)
				{
					isToolCutLenShort = true;
				}
				return;
			}
			double num2 = Math.Abs(Operation.OperationData.DepthValues[0].TopPosition - Operation.OperationData.DepthValues[Operation.OperationData.DepthValues.Count - 1].BottomPosition);
			if (num2 > Tool.Geometry.TotalLength - ToolHolderLength)
			{
				isToolLenShort = true;
			}
			for (int i = 0; i <= Operation.OperationData.DepthValues.Count - 1; i++)
			{
				num2 = Math.Abs(Operation.OperationData.DepthValues[i].TopPosition - Operation.OperationData.DepthValues[i].BottomPosition);
				if (num2 > Tool.Geometry.CutLength)
				{
					isToolCutLenShort = true;
				}
			}
		}
		else if (Operation.OperationData.NotchData.NotchDepth > Tool.Geometry.Diameter / 2.0)
		{
			isToolCutLenShort = true;
		}
	}

	public void SortList(SortDirectionType Direction, ref List<MinMax> RefList)
	{
		try
		{
			bool flag = false;
			if (RefList.Count <= 1)
			{
				return;
			}
			RefList.Sort((MinMax minMax_0, MinMax minMax_1) => minMax_0.Min.CompareTo(minMax_1.Min));
			if (Direction == SortDirectionType.Lower)
			{
				for (int num = 1; num <= RefList.Count - 1; num++)
				{
					if (RefList[num - 1].Min > RefList[num].Min)
					{
						num = RefList.Count;
						flag = true;
					}
				}
				if (flag)
				{
					RefList.Reverse();
				}
			}
			if (Direction != SortDirectionType.Bigger)
			{
				return;
			}
			for (int num2 = 1; num2 <= RefList.Count - 1; num2++)
			{
				if (RefList[num2 - 1].Min < RefList[num2].Min)
				{
					num2 = RefList.Count;
					flag = true;
				}
			}
			if (flag)
			{
				RefList.Reverse();
			}
		}
		catch (Exception mSException)
		{
			string text = "Direction: " + Direction;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void SortList(SortDirectionType Direction, ref List<ProfileOperation> RefList)
	{
		try
		{
			bool flag = false;
			if (RefList.Count <= 1)
			{
				return;
			}
			RefList.Sort((ProfileOperation profileOperation_0, ProfileOperation profileOperation_1) => profileOperation_0.MinPoint.X.CompareTo(profileOperation_1.MinPoint.X));
			if (Direction == SortDirectionType.Lower)
			{
				for (int num = 1; num <= RefList.Count - 1; num++)
				{
					if (RefList[num - 1].MinPoint.X > RefList[num].MinPoint.X)
					{
						num = RefList.Count;
						flag = true;
					}
				}
				if (flag)
				{
					RefList.Reverse();
				}
			}
			if (Direction != SortDirectionType.Bigger)
			{
				return;
			}
			for (int num2 = 1; num2 <= RefList.Count - 1; num2++)
			{
				if (RefList[num2 - 1].MinPoint.X < RefList[num2].MinPoint.X)
				{
					num2 = RefList.Count;
					flag = true;
				}
			}
			if (flag)
			{
				RefList.Reverse();
			}
		}
		catch (Exception mSException)
		{
			string text = "Direction: " + Direction;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void SortList(SortDirectionType Direction, ref List<GProfileOperation> RefList)
	{
		try
		{
			bool flag = false;
			if (RefList.Count <= 1)
			{
				return;
			}
			RefList.Sort((GProfileOperation gprofileOperation_0, GProfileOperation gprofileOperation_1) => gprofileOperation_0.SizePoint.MinPoint.X.CompareTo(gprofileOperation_1.SizePoint.MinPoint.X));
			if (Direction == SortDirectionType.Lower)
			{
				for (int num = 1; num <= RefList.Count - 1; num++)
				{
					if (RefList[num - 1].SizePoint.MinPoint.X > RefList[num].SizePoint.MinPoint.X)
					{
						num = RefList.Count;
						flag = true;
					}
				}
				if (flag)
				{
					RefList.Reverse();
				}
			}
			if (Direction != SortDirectionType.Bigger)
			{
				return;
			}
			for (int num2 = 1; num2 <= RefList.Count - 1; num2++)
			{
				if (RefList[num2 - 1].SizePoint.MinPoint.X < RefList[num2].SizePoint.MinPoint.X)
				{
					num2 = RefList.Count;
					flag = true;
				}
			}
			if (flag)
			{
				RefList.Reverse();
			}
		}
		catch (Exception mSException)
		{
			string text = "Direction: " + Direction;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void SortList(SortDirectionType Direction, ref List<GProfileOperation> RefList, profileSortSequenceAtSamePosition Sequence)
	{
		try
		{
			bool flag = false;
			if (RefList.Count <= 1)
			{
				return;
			}
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			if (Direction != SortDirectionType.Lower)
			{
				if (Sequence == profileSortSequenceAtSamePosition.FrontTopBack)
				{
					num = -0.1;
					num2 = -0.2;
					num3 = 0.0;
				}
				if (Sequence == profileSortSequenceAtSamePosition.BackTopFront)
				{
					num = -0.1;
					num2 = 0.0;
					num3 = -0.2;
				}
			}
			else
			{
				if (Sequence == profileSortSequenceAtSamePosition.FrontTopBack)
				{
					num = 0.1;
					num2 = 0.2;
					num3 = 0.0;
				}
				if (Sequence == profileSortSequenceAtSamePosition.BackTopFront)
				{
					num = 0.1;
					num2 = 0.0;
					num3 = 0.2;
				}
			}
			for (int i = 0; i <= RefList.Count - 1; i++)
			{
				if ((RefList[i].OperationData.selectedPlaneName == planeNames.Top) | (RefList[i].OperationData.selectedPlaneName == planeNames.Free))
				{
					RefList[i].SizePoint.MinPoint.X = RefList[i].SizePoint.MinPoint.X + num;
				}
				if (RefList[i].OperationData.selectedPlaneName == planeNames.Back)
				{
					RefList[i].SizePoint.MinPoint.X = RefList[i].SizePoint.MinPoint.X + num2;
				}
				if (RefList[i].OperationData.selectedPlaneName == planeNames.Front)
				{
					RefList[i].SizePoint.MinPoint.X = RefList[i].SizePoint.MinPoint.X + num3;
				}
			}
			RefList.Sort((GProfileOperation gprofileOperation_0, GProfileOperation gprofileOperation_1) => gprofileOperation_0.SizePoint.MinPoint.X.CompareTo(gprofileOperation_1.SizePoint.MinPoint.X));
			if (Direction == SortDirectionType.Lower)
			{
				for (int num4 = 1; num4 <= RefList.Count - 1; num4++)
				{
					if (RefList[num4 - 1].SizePoint.MinPoint.X > RefList[num4].SizePoint.MinPoint.X)
					{
						num4 = RefList.Count;
						flag = true;
					}
				}
				if (flag)
				{
					RefList.Reverse();
				}
			}
			if (Direction == SortDirectionType.Bigger)
			{
				for (int num5 = 1; num5 <= RefList.Count - 1; num5++)
				{
					if (RefList[num5 - 1].SizePoint.MinPoint.X < RefList[num5].SizePoint.MinPoint.X)
					{
						num5 = RefList.Count;
						flag = true;
					}
				}
				if (flag)
				{
					RefList.Reverse();
				}
			}
			for (int num6 = 0; num6 <= RefList.Count - 1; num6++)
			{
				if ((RefList[num6].OperationData.selectedPlaneName == planeNames.Top) | (RefList[num6].OperationData.selectedPlaneName == planeNames.Free))
				{
					RefList[num6].SizePoint.MinPoint.X = RefList[num6].SizePoint.MinPoint.X - num;
				}
				if (RefList[num6].OperationData.selectedPlaneName == planeNames.Back)
				{
					RefList[num6].SizePoint.MinPoint.X = RefList[num6].SizePoint.MinPoint.X - num2;
				}
				if (RefList[num6].OperationData.selectedPlaneName == planeNames.Front)
				{
					RefList[num6].SizePoint.MinPoint.X = RefList[num6].SizePoint.MinPoint.X - num3;
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "Direction: " + Direction;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void SortListByPriority(SortDirectionType Direction, ref List<GProfileOperation> RefList)
	{
		try
		{
			bool flag = false;
			if (RefList.Count <= 1)
			{
				return;
			}
			RefList.Sort((GProfileOperation gprofileOperation_0, GProfileOperation gprofileOperation_1) => gprofileOperation_0.Priority.CompareTo(gprofileOperation_1.Priority));
			if (Direction == SortDirectionType.Lower)
			{
				for (int num = 1; num <= RefList.Count - 1; num++)
				{
					if (RefList[num - 1].Priority > RefList[num].Priority)
					{
						num = RefList.Count;
						flag = true;
					}
				}
				if (flag)
				{
					RefList.Reverse();
				}
			}
			if (Direction != SortDirectionType.Bigger)
			{
				return;
			}
			for (int num2 = 1; num2 <= RefList.Count - 1; num2++)
			{
				if (RefList[num2 - 1].Priority < RefList[num2].Priority)
				{
					num2 = RefList.Count;
					flag = true;
				}
			}
			if (flag)
			{
				RefList.Reverse();
			}
		}
		catch (Exception mSException)
		{
			string text = "Direction: " + Direction;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void SortList(SortDirectionType Direction, ref List<ProfileOperationSortItem> RefList)
	{
		try
		{
			bool flag = false;
			if (RefList.Count <= 1)
			{
				return;
			}
			RefList.Sort((ProfileOperationSortItem profileOperationSortItem_0, ProfileOperationSortItem profileOperationSortItem_1) => profileOperationSortItem_0.SizePoint.MinPoint.X.CompareTo(profileOperationSortItem_1.SizePoint.MinPoint.X));
			if (Direction == SortDirectionType.Lower)
			{
				for (int num = 1; num <= RefList.Count - 1; num++)
				{
					if (RefList[num - 1].SizePoint.MinPoint.X > RefList[num].SizePoint.MinPoint.X)
					{
						num = RefList.Count;
						flag = true;
					}
				}
				if (flag)
				{
					RefList.Reverse();
				}
			}
			if (Direction != SortDirectionType.Bigger)
			{
				return;
			}
			for (int num2 = 1; num2 <= RefList.Count - 1; num2++)
			{
				if (RefList[num2 - 1].SizePoint.MinPoint.X < RefList[num2].SizePoint.MinPoint.X)
				{
					num2 = RefList.Count;
					flag = true;
				}
			}
			if (flag)
			{
				RefList.Reverse();
			}
		}
		catch (Exception mSException)
		{
			string text = "Direction: " + Direction;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void CheckDepthAndChangeSequenceIfIntersect(ref List<GProfileOperation> RefList)
	{
		for (int i = 0; i <= RefList.Count - 1; i++)
		{
			if (i >= RefList.Count - 1 || RefList[i].OperationData.selectedPlaneName != RefList[i + 1].OperationData.selectedPlaneName)
			{
				continue;
			}
			bool flag = false;
			if (!buCall.buVector5_0.isBoxSizeInsideBoxSize(RefList[i].SizePoint.MinPoint, RefList[i].SizePoint.MaxPoint, RefList[i + 1].SizePoint.MinPoint, RefList[i + 1].SizePoint.MaxPoint, RefList[i].OperationData.selectedPlane))
			{
				if (!buCall.buVector5_0.isBoxSizeInsideBoxSize(RefList[i + 1].SizePoint.MinPoint, RefList[i + 1].SizePoint.MaxPoint, RefList[i].SizePoint.MinPoint, RefList[i].SizePoint.MaxPoint, RefList[i].OperationData.selectedPlane))
				{
					if (buCall.buVector5_0.isBoxSizesIntersection(RefList[i].SizePoint.MinPoint, RefList[i].SizePoint.MaxPoint, RefList[i + 1].SizePoint.MinPoint, RefList[i + 1].SizePoint.MaxPoint, RefList[i].OperationData.selectedPlane))
					{
						flag = true;
					}
				}
				else
				{
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
			if (flag)
			{
				DepthPositions depthPositions = null;
				DepthPositions depthPositions2 = null;
				depthPositions = ((RefList[i].OperationData.DepthValues.Count > 0) ? RefList[i].OperationData.DepthValues[0] : RefList[i].OperationData.Depth);
				depthPositions2 = ((RefList[i + 1].OperationData.DepthValues.Count > 0) ? RefList[i + 1].OperationData.DepthValues[0] : RefList[i + 1].OperationData.Depth);
				if (((RefList[i].OperationData.selectedPlaneName == planeNames.Top) | (RefList[i].OperationData.selectedPlaneName == planeNames.Back)) && depthPositions.TopPosition < depthPositions2.TopPosition)
				{
					GProfileOperation item = RefList[i + 1];
					RefList.RemoveAt(i + 1);
					RefList.Insert(i, item);
				}
				if (((RefList[i].OperationData.selectedPlaneName == planeNames.Bottom) | (RefList[i].OperationData.selectedPlaneName == planeNames.Front)) && depthPositions.TopPosition > depthPositions2.TopPosition)
				{
					GProfileOperation item2 = RefList[i + 1];
					RefList.RemoveAt(i + 1);
					RefList.Insert(i, item2);
				}
			}
		}
	}

	public ProfileItem SelectActiveProfile(ProfileItem FirstItem, ProfileItem SecondItem, ref int activeProfileIndex)
	{
		string callMethod = "SelectActiveProfile";
		try
		{
			ProfileItem result = null;
			if (activeProfileIndex != 0)
			{
				if (activeProfileIndex == 1)
				{
					result = SecondItem;
				}
			}
			else
			{
				result = FirstItem;
			}
			return result;
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, sClass, callMethod, ShowMessageBox: false, "");
			return null;
		}
	}

	public void TotalWidthOfProfile(ref ProfileItem Item, ref int cntProfile)
	{
		cntProfile = 0;
		if (Item.MultiplyProfile.ProfileMultiplyEnable)
		{
			cntProfile = Item.MultiplyProfile.ProfileMultiplyCount - 1;
		}
		if (cntProfile < 0)
		{
			cntProfile = 0;
		}
		Item.TotalWidth = Item.Width;
		if (cntProfile > 0)
		{
			Item.TotalWidth = Item.Width + (Item.Width + Item.MultiplyProfile.ProfileMultiplySpace) * (double)(Item.MultiplyProfile.ProfileMultiplyCount - 1);
		}
	}

	public void CreateProfileFromData(List<Entity> Entities, CreateProfileFromDataOptions Options, ref ProfileItem Profile)
	{
		List<buEntity> refEntities = new List<buEntity>();
		double leftAngle = Profile.LeftAngle;
		double rightAngle = Profile.RightAngle;
		Profile = new ProfileItem();
		Profile.LeftAngle = leftAngle;
		Profile.RightAngle = rightAngle;
		Point3D MinPoint = new Point3D();
		Point3D MaxPoint = new Point3D();
		Point3D MidPoint = new Point3D();
		buCall.buVector5_0.BoxSizeCalculate(Entities, ref MinPoint, ref MidPoint, ref MaxPoint);
		buCall.buVector5_0.Move(0.0 - MinPoint.X, 0.0 - MinPoint.Y, 0.0 - MinPoint.Z, ref Entities);
		for (int i = 0; i <= Entities.Count - 1; i++)
		{
			if (i != 312)
			{
			}
			if (!(Entities[i] is CompositeCurve))
			{
				buEntity copiedEntity = null;
				buEntity.Copy(Entities[i], ref copiedEntity);
				if (Entities[i] is ICurve)
				{
					copiedEntity.Info.RefIndex = i;
					if (((ICurve)Entities[i]).Length() > 0.01)
					{
						refEntities.Add(copiedEntity);
					}
				}
				continue;
			}
			buEntity copiedEntity2 = null;
			buEntity.Copy(Entities[i], ref copiedEntity2);
			if (Entities[i] is ICurve)
			{
				copiedEntity2.Info.RefIndex = i;
				if (((ICurve)Entities[i]).Length() > 0.01)
				{
					refEntities.Add(copiedEntity2);
				}
			}
		}
		buEntity.ZPointToZero(ref refEntities);
		Profile.ItemName = Options.Name;
		Profile.FileName = Options.FileName;
		Profile.FileNameFull = Options.FullName;
		Profile.Length = Options.Length;
		Profile.colorProfile = Options.color;
		Profile.Transparency = Options.Transparency;
		new List<Point3D>();
		Point3D MinPoint2 = new Point3D();
		Point3D MidPoint2 = new Point3D();
		Point3D MaxPoint2 = new Point3D();
		buCall.buVector5_0.BoxSizeCalculate(refEntities, ref MinPoint2, ref MidPoint2, ref MaxPoint2);
		Profile.Width = Math.Round(MaxPoint2.X - MinPoint2.X, 3);
		Profile.Height = Math.Round(MaxPoint2.Y - MinPoint2.Y, 3);
		double num = 1.0;
		double num2 = 1.0;
		num = Options.NeededWidth / Profile.Width;
		num2 = Options.NeededHeight / Profile.Height;
		if ((!buCompare.EQ(num, 1.0, 0.001) | !buCompare.EQ(num2, 1.0, 0.001)) && num > 0.0 && num2 > 0.0)
		{
			buCall.buVector5_0.Scale(MinPoint2, num, num2, 1.0, ref refEntities);
		}
		if (Options.ConnectSmallGap)
		{
			buCall.buVector5_0.ConnnectEntitiesGap(ref refEntities, Options.GapConnection);
		}
		double num3 = double.MaxValue;
		int num4 = -1;
		Point3D refPoint = new Point3D();
		for (int j = 0; j <= refEntities.Count - 1; j++)
		{
			for (int k = 0; k <= refEntities[j].Vertices.Count - 1; k++)
			{
				double num5 = Point3D.Distance(refEntities[j].Vertices[k], new Point3D());
				if (num5 < num3)
				{
					num3 = num5;
					num4 = j;
				}
			}
		}
		if (num4 >= 0)
		{
			refPoint = buVector5.ToPoint3D(refEntities[num4].StartPoint);
		}
		List<buEntitiesGroup> Groups = new List<buEntitiesGroup>();
		buCall.buVector5_0.FindEntitiesGroupFromEntities(refPoint, refEntities, Plane.XY, ref Groups, Options.SortResolituon, Options.IntersectionRules);
		if (Groups.Count == 0)
		{
			return;
		}
		for (int l = 0; l <= Groups.Count - 1; l++)
		{
			ProfileDrawings profileDrawings = new ProfileDrawings();
			if (Groups[l].Outside.Entities.Count > 0)
			{
				buEntity.Copy(Groups[l].Outside.Entities, ref profileDrawings.OutterEntitites);
				buCall.buVector5_0.EntitiesToPointsWithCamDirection(profileDrawings.OutterEntitites, ref profileDrawings.OutterPoints);
				buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref profileDrawings.OutterPoints);
			}
			if (Groups[l].Inside.Count > 0)
			{
				for (int m = 0; m <= Groups[l].Inside.Count - 1; m++)
				{
					List<buEntity> copiedEntities = new List<buEntity>();
					List<Point3D> Points = new List<Point3D>();
					buEntity.Copy(Groups[l].Inside[m].Entities, ref copiedEntities);
					buCall.buVector5_0.EntitiesToPointsWithCamDirection(copiedEntities, ref Points);
					buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref Points);
					profileDrawings.InnerEntities.Add(copiedEntities);
					profileDrawings.InnerPoints.Add(Points);
				}
			}
			Profile.Drawings.Add(profileDrawings);
		}
		Profile.SupportBlock.SupportBlockZLength = Options.Length;
		Profile.SupportBlock.SupportBlockZWidth = Options.SupportBlockZWidth;
		Profile.SupportBlock.SupportBlockZHeight = Options.SupportBlockZHeight;
		Profile.SupportBlock.SupportBlockY1FrontLength = Options.Length;
		Profile.SupportBlock.SupportBlockY1FrontWidth = Options.SupportBlockY1Width;
		Profile.SupportBlock.SupportBlockY1FrontHeight = Options.SupportBlockY1Height;
		Profile.SupportBlock.SupportBlockY2BackLength = Options.Length;
		Profile.SupportBlock.SupportBlockY2BackWidth = Options.SupportBlockY2Width;
		Profile.SupportBlock.SupportBlockY2BackHeight = Options.SupportBlockY2Height;
	}

	public void CreateProfile(ProfileItem Profile, Plane ProfilePlane, Point3D ProfileOffset, ref Entity entProfile)
	{
		CompositeCurve compositeCurve = CompositeCurve.CreateRectangle(ProfilePlane, Profile.Width, Profile.Height, centered: true);
		CompositeCurve compositeCurve2 = CompositeCurve.CreateRectangle(ProfilePlane, Profile.Width - Profile.Thickness, Profile.Height - Profile.Thickness, centered: true);
		devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(new ICurve[2] { compositeCurve, compositeCurve2 }, ProfilePlane, sortAndOrient: false);
		Brep brep = region.ExtrudeAsBrep(Profile.Length);
		brep.Color = Profile.Color;
		brep.ColorMethod = colorMethodType.byEntity;
		brep.Translate(ProfileOffset.X, ProfileOffset.Y, ProfileOffset.Z);
		brep.Regen(0.01);
		entProfile = brep;
	}

	public void CreateProfileFromDrawing(ref ProfileItem Profile, Plane ProfilePlane, Point3D ProfileOffset, bool isNewProfile, ProfileSettings Settings, ProfileVisualSettings VisualSettings, double ProfileRefEntityThickness = 10.0, double MinPointFilterLength = 0.0)
	{
		try
		{
			for (int i = 0; i <= Profile.Drawings.Count - 1; i++)
			{
				List<ICurve> list = new List<ICurve>();
				List<ICurve> list2 = new List<ICurve>();
				List<Point3D> Points = new List<Point3D>();
				if (!isNewProfile)
				{
					buVector5.Copy(Profile.Drawings[i].OutterPoints, ref Points);
				}
				else
				{
					List<Point3D> copiedPoint = new List<Point3D>();
					buVector5.Copy(Profile.Drawings[i].OutterPoints, ref copiedPoint);
					Profile.Drawings[i].OutterPoints.Clear();
					for (int j = 0; j <= copiedPoint.Count - 1; j++)
					{
						double x = copiedPoint[j].X;
						double y = copiedPoint[j].Y;
						Profile.Drawings[i].OutterPoints.Add(new Point3D(ProfileOffset.X, x + ProfileOffset.Y, y + ProfileOffset.Z));
						Points.Add(new Point3D(ProfileOffset.X, x + ProfileOffset.Y, y + ProfileOffset.Z));
					}
					buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref Points);
					if (MinPointFilterLength > 0.0)
					{
						buCall.buVector5_0.RemoveSmallLengthFromPoints(MinPointFilterLength, ref Points);
					}
				}
				list.Add(new LinearPath(Points));
				if (!isNewProfile)
				{
					for (int k = 0; k <= Profile.Drawings[i].InnerPoints.Count - 1; k++)
					{
						Points = new List<Point3D>();
						buVector5.Copy(Profile.Drawings[i].InnerPoints[k], ref Points);
						list2.Add(new LinearPath(Points));
					}
				}
				else
				{
					List<List<Point3D>> copiedPoint2 = new List<List<Point3D>>();
					buVector5.Copy(Profile.Drawings[i].InnerPoints, ref copiedPoint2);
					Profile.Drawings[i].InnerPoints = new List<List<Point3D>>();
					for (int l = 0; l <= copiedPoint2.Count - 1; l++)
					{
						Points = new List<Point3D>();
						List<Point3D> list3 = new List<Point3D>();
						for (int m = 0; m <= copiedPoint2[l].Count - 1; m++)
						{
							double x2 = copiedPoint2[l][m].X;
							double y2 = copiedPoint2[l][m].Y;
							Points.Add(new Point3D(ProfileOffset.X, x2 + ProfileOffset.Y, y2 + ProfileOffset.Z));
							list3.Add(new Point3D(ProfileOffset.X, x2 + ProfileOffset.Y, y2 + ProfileOffset.Z));
						}
						buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref Points);
						if (MinPointFilterLength > 0.0)
						{
							buCall.buVector5_0.RemoveSmallLengthFromPoints(MinPointFilterLength, ref Points);
						}
						bool flag = Utility.IsOrientedClockwise(Points);
						Points.Reverse();
						if (flag)
						{
						}
						Profile.Drawings[i].InnerPoints.Add(Points);
						list2.Add(new LinearPath(list3));
					}
				}
				if (list.Count <= 0)
				{
					continue;
				}
				CompositeCurve compositeCurve = new CompositeCurve(list);
				devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(new ICurve[1] { compositeCurve }, ProfilePlane, sortAndOrient: false);
				for (int n = 0; n <= list2.Count - 1; n++)
				{
					region.ContourList.Add(list2[n]);
				}
				Brep brep = null;
				double num = 0.0;
				if (!(Profile.RightAngle > 0.0))
				{
				}
				brep = region.ExtrudeAsBrep(Profile.Length + num);
				brep.Color = Profile.Color;
				brep.ColorMethod = colorMethodType.byEntity;
				if (Profile.XReferanceLocation == LeftRightType.Left)
				{
					Mesh mesh = Mesh.CreateBox(ProfileRefEntityThickness, Profile.Width, Profile.Height, Mesh.natureType.RichSmooth);
					mesh.Translate(0.0 - ProfileRefEntityThickness, ProfileOffset.Y);
					mesh.Color = Color.FromArgb(VisualSettings.ProfileRefeanceTranparentLeft, VisualSettings.ProfileRefeanceColor);
					mesh.ColorMethod = colorMethodType.byEntity;
					CustomData entityData = new CustomData(entityTypeDefination.Lean);
					mesh.EntityData = entityData;
					mesh.Selectable = false;
					Profile.ProfileReferanceEntity = mesh;
					if (Settings.ShowBottomReferanceEntity)
					{
						Mesh mesh2 = Mesh.CreateBox(Profile.Length + ProfileRefEntityThickness, Profile.Width, ProfileRefEntityThickness / 2.0, Mesh.natureType.RichSmooth);
						mesh2.Translate(0.0 - ProfileRefEntityThickness, ProfileOffset.Y, (0.0 - ProfileRefEntityThickness) / 2.0);
						mesh2.Color = Color.FromArgb(VisualSettings.ProfileRefeanceTranparentBottom, VisualSettings.ProfileRefeanceColor);
						mesh2.ColorMethod = colorMethodType.byEntity;
						entityData = new CustomData(entityTypeDefination.Lean);
						mesh2.EntityData = entityData;
						mesh2.Selectable = false;
						Profile.ProfileReferanceBottomEntity = mesh2;
					}
					if (Settings.ShowBackReferanceEntity)
					{
						Mesh mesh3 = Mesh.CreateBox(Profile.Length + ProfileRefEntityThickness, ProfileRefEntityThickness / 2.0, Profile.Height, Mesh.natureType.RichSmooth);
						mesh3.Translate(0.0 - ProfileRefEntityThickness, 0.0);
						mesh3.Color = Color.FromArgb(VisualSettings.ProfileRefeanceTranparentBack, VisualSettings.ProfileRefeanceColor);
						mesh3.ColorMethod = colorMethodType.byEntity;
						entityData = new CustomData(entityTypeDefination.Lean);
						mesh3.EntityData = entityData;
						mesh3.Selectable = false;
						Profile.ProfileReferanceBackEntity = mesh3;
					}
					if (Settings.RemoveProfileAngle)
					{
						if (Profile.LeftAngle > 0.0)
						{
							double height = Profile.Height / Math.Cos(buConversion5.DegreeToRadian(Profile.LeftAngle));
							devDept.Eyeshot.Entities.Region region2 = devDept.Eyeshot.Entities.Region.CreateRectangle(Plane.YZ, Profile.Width, height);
							region2.Translate(0.0, ProfileOffset.Y);
						}
						if (Profile.LeftAngle < 0.0)
						{
							double num2 = Profile.Height / Math.Cos(buConversion5.DegreeToRadian(Profile.LeftAngle));
							devDept.Eyeshot.Entities.Region region3 = devDept.Eyeshot.Entities.Region.CreateRectangle(Plane.YZ, Profile.Width, num2);
							region3.Translate(0.0, ProfileOffset.Y, Profile.Height - num2);
						}
						if (Profile.RightAngle < 0.0)
						{
							double height2 = Profile.Height / Math.Cos(buConversion5.DegreeToRadian(Profile.RightAngle));
							devDept.Eyeshot.Entities.Region region4 = devDept.Eyeshot.Entities.Region.CreateRectangle(Plane.YZ, Profile.Width, height2);
							region4.Translate(Profile.Length, ProfileOffset.Y);
						}
						if (Profile.RightAngle > 0.0)
						{
							double num3 = Profile.Height / Math.Cos(buConversion5.DegreeToRadian(Profile.RightAngle));
							devDept.Eyeshot.Entities.Region region5 = devDept.Eyeshot.Entities.Region.CreateRectangle(Plane.YZ, Profile.Width, num3);
							region5.Translate(Profile.Length, ProfileOffset.Y, Profile.Height - num3);
						}
					}
				}
				if (Profile.XReferanceLocation == LeftRightType.Right)
				{
					Mesh mesh4 = Mesh.CreateBox(ProfileRefEntityThickness, Profile.Width, Profile.Height, Mesh.natureType.RichSmooth);
					mesh4.Translate(Profile.Length, ProfileOffset.Y);
					mesh4.Color = Color.FromArgb(VisualSettings.ProfileRefeanceTranparentLeft, VisualSettings.ProfileRefeanceColor);
					mesh4.ColorMethod = colorMethodType.byEntity;
					CustomData entityData2 = new CustomData(entityTypeDefination.Lean);
					mesh4.EntityData = entityData2;
					mesh4.Selectable = false;
					Profile.ProfileReferanceEntity = mesh4;
					if (Settings.ShowBottomReferanceEntity)
					{
						Mesh mesh5 = Mesh.CreateBox(Profile.Length + ProfileRefEntityThickness, Profile.Width, ProfileRefEntityThickness / 2.0, Mesh.natureType.RichSmooth);
						mesh5.Translate(0.0, ProfileOffset.Y, (0.0 - ProfileRefEntityThickness) / 2.0);
						mesh5.Color = Color.FromArgb(VisualSettings.ProfileRefeanceTranparentBottom, VisualSettings.ProfileRefeanceColor);
						mesh5.ColorMethod = colorMethodType.byEntity;
						entityData2 = new CustomData(entityTypeDefination.Lean);
						mesh5.EntityData = entityData2;
						mesh5.Selectable = false;
						Profile.ProfileReferanceBottomEntity = mesh5;
					}
					if (Settings.ShowBackReferanceEntity)
					{
						Mesh mesh6 = Mesh.CreateBox(Profile.Length + ProfileRefEntityThickness, ProfileRefEntityThickness / 2.0, Profile.Height, Mesh.natureType.RichSmooth);
						mesh6.Translate(0.0, 0.0);
						mesh6.Color = Color.FromArgb(VisualSettings.ProfileRefeanceTranparentBack, VisualSettings.ProfileRefeanceColor);
						mesh6.ColorMethod = colorMethodType.byEntity;
						entityData2 = new CustomData(entityTypeDefination.Lean);
						mesh6.EntityData = entityData2;
						mesh6.Selectable = false;
						Profile.ProfileReferanceBackEntity = mesh6;
					}
				}
				brep.Regen(0.01);
				brep.Color = Color.FromArgb(Profile.Transparency, Profile.colorProfile);
				CustomData entityData3 = new CustomData(entityTypeDefination.Profile);
				brep.EntityData = entityData3;
				Profile.Drawings[i].SolidEntity = brep;
			}
			double height3 = Profile.Height / Math.Cos(buConversion5.DegreeToRadian(Profile.LeftAngle));
			if (!(Profile.LeftAngle > 0.0))
			{
				if (Profile.LeftAngle < 0.0)
				{
					devDept.Eyeshot.Entities.Region region6 = devDept.Eyeshot.Entities.Region.CreateRectangle(Plane.YZ, Profile.Width + 1.0, height3);
					Mesh mesh7 = region6.ExtrudeAsMesh(ProfileRefEntityThickness * 0.1, 0.1, Mesh.natureType.RichSmooth);
					mesh7.Rotate(buConversion5.DegreeToRadian(Profile.LeftAngle), Vector3D.AxisY);
					mesh7.Regen(0.01);
					mesh7.Translate(0.0 - mesh7.BoxMin.X, ProfileOffset.Y);
					CustomData entityData4 = new CustomData(entityTypeDefination.Angle);
					mesh7.EntityData = entityData4;
				}
			}
			else
			{
				devDept.Eyeshot.Entities.Region region7 = devDept.Eyeshot.Entities.Region.CreateRectangle(Plane.YZ, Profile.Width, height3);
				Mesh mesh8 = region7.ExtrudeAsMesh(ProfileRefEntityThickness * 0.1, 0.1, Mesh.natureType.RichSmooth);
				mesh8.Rotate(buConversion5.DegreeToRadian(Profile.LeftAngle), Vector3D.AxisY);
				mesh8.Regen(0.01);
				mesh8.Translate(0.0 - mesh8.BoxMin.X, ProfileOffset.Y);
				CustomData entityData5 = new CustomData(entityTypeDefination.Angle);
				mesh8.EntityData = entityData5;
			}
			if (Profile.RightAngle < 0.0)
			{
				height3 = Profile.Height / Math.Cos(buConversion5.DegreeToRadian(Profile.RightAngle));
				devDept.Eyeshot.Entities.Region region8 = devDept.Eyeshot.Entities.Region.CreateRectangle(Plane.YZ, Profile.Width, height3);
				Mesh mesh9 = region8.ExtrudeAsMesh(ProfileRefEntityThickness * 0.1, 0.1, Mesh.natureType.RichSmooth);
				mesh9.Rotate(buConversion5.DegreeToRadian(Profile.RightAngle), Vector3D.AxisY);
				mesh9.Regen(0.01);
				mesh9.Translate(Profile.Length - mesh9.BoxMax.X, ProfileOffset.Y);
				CustomData entityData6 = new CustomData(entityTypeDefination.Angle);
				mesh9.EntityData = entityData6;
				Profile.RightAngleEntity = mesh9;
			}
			if (Profile.RightAngle > 0.0)
			{
				height3 = Profile.Height / Math.Cos(buConversion5.DegreeToRadian(Profile.RightAngle));
				devDept.Eyeshot.Entities.Region region9 = devDept.Eyeshot.Entities.Region.CreateRectangle(Plane.YZ, Profile.Width, height3);
				Mesh mesh10 = region9.ExtrudeAsMesh(ProfileRefEntityThickness * 0.1, 0.1, Mesh.natureType.RichSmooth);
				mesh10.Rotate(buConversion5.DegreeToRadian(Profile.RightAngle), Vector3D.AxisY);
				mesh10.Regen(0.01);
				mesh10.Translate(Profile.Length - mesh10.BoxMax.X, ProfileOffset.Y);
				CustomData entityData7 = new CustomData(entityTypeDefination.Angle);
				mesh10.EntityData = entityData7;
				Profile.RightAngleEntity = mesh10;
			}
		}
		catch (Exception)
		{
		}
	}

	public void BoxSizeProfile(ProfileItem Profile, ref Point3D MinPoint, ref Point3D MidPoint, ref Point3D MaxPoint)
	{
		List<Point3D> list = new List<Point3D>();
		for (int i = 0; i <= Profile.Drawings.Count - 1; i++)
		{
			for (int j = 0; j <= Profile.Drawings[i].OutterPoints.Count - 1; j++)
			{
				list.Add(Profile.Drawings[i].OutterPoints[j]);
			}
		}
		buCall.buVector5_0.BoxSizeCalculate(list, ref MinPoint, ref MidPoint, ref MaxPoint);
	}

	public void FindIntersectBetweenCenterLineAndSurface(ProfileItem Profile, planeNames PlaneNames, Point3D refPoint, ref List<Point3D> pntIntersect)
	{
		try
		{
			pntIntersect = new List<Point3D>();
			for (int i = 0; i <= Profile.Drawings.Count - 1; i++)
			{
				LinearPath linearPath = new LinearPath(Profile.Drawings[i].OutterPoints);
				Line c = null;
				if (!(PlaneNames == planeNames.Top || PlaneNames == planeNames.Bottom))
				{
					if (PlaneNames == planeNames.Back || PlaneNames == planeNames.Front)
					{
						c = new Line(new Point3D(0.0, -10000.0, refPoint.Z), new Point3D(0.0, 10000.0, refPoint.Z));
					}
				}
				else
				{
					c = new Line(new Point3D(0.0, refPoint.Y, -10000.0), new Point3D(0.0, refPoint.Y, 10000.0));
				}
				Point3D[] collection = linearPath.IntersectWith(c);
				pntIntersect.AddRange(collection);
				for (int j = 0; j <= Profile.Drawings[i].InnerPoints.Count - 1; j++)
				{
					linearPath = new LinearPath(Profile.Drawings[i].InnerPoints[j]);
					Point3D[] collection2 = linearPath.IntersectWith(c);
					pntIntersect.AddRange(collection2);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void CopyJustProfileProperties(ProfileItem refProfile, ref ProfileItem copyProfile)
	{
		copyProfile.Color = refProfile.Color;
		copyProfile.colorProfile = refProfile.colorProfile;
		copyProfile.colorSupportBlock = refProfile.colorSupportBlock;
		copyProfile.CreatedFromDrawing = refProfile.CreatedFromDrawing;
		copyProfile.Direction = new Vector3D(refProfile.Direction.X, refProfile.Direction.Y, refProfile.Direction.Z);
		copyProfile.Enable = refProfile.Enable;
		copyProfile.FileName = refProfile.FileName;
		copyProfile.FileNameFull = refProfile.FileNameFull;
		copyProfile.Height = refProfile.Height;
		for (int i = 0; i <= refProfile.Drawings.Count - 1; i++)
		{
			if (refProfile.Drawings[i].InnerEntities != null)
			{
				copyProfile.Drawings[i].InnerEntities.Clear();
				buEntity.Copy(refProfile.Drawings[i].InnerEntities, ref copyProfile.Drawings[i].InnerEntities);
			}
			if (refProfile.Drawings[i].OutterEntitites != null)
			{
				copyProfile.Drawings[i].OutterEntitites.Clear();
				buEntity.Copy(refProfile.Drawings[i].OutterEntitites, ref copyProfile.Drawings[i].OutterEntitites);
			}
			copyProfile.Drawings[i].InnerPoints.Clear();
			copyProfile.Drawings[i].OutterPoints.Clear();
			buVector5.Copy(refProfile.Drawings[i].InnerPoints, ref copyProfile.Drawings[i].InnerPoints);
			buVector5.Copy(refProfile.Drawings[i].OutterPoints, ref copyProfile.Drawings[i].OutterPoints);
			if (refProfile.Drawings[i].SolidEntity != null)
			{
				buEntity.Copy(refProfile.Drawings[i].SolidEntity, ref copyProfile.Drawings[i].SolidEntity);
			}
		}
		copyProfile.ItemName = refProfile.ItemName;
		copyProfile.LeftAngle = refProfile.LeftAngle;
		if (refProfile.LeftAngleEntity != null)
		{
			buEntity.Copy(refProfile.LeftAngleEntity, ref copyProfile.LeftAngleEntity);
		}
		if (refProfile.RightAngleEntity != null)
		{
			buEntity.Copy(refProfile.RightAngleEntity, ref copyProfile.RightAngleEntity);
		}
		copyProfile.Length = refProfile.Length;
		copyProfile.MaxClamperNumber = refProfile.MaxClamperNumber;
		copyProfile.MaxOperationXPosition = refProfile.MaxOperationXPosition;
		copyProfile.ProfileCenterPoint = buVector5.ToPoint3D(refProfile.ProfileCenterPoint);
		copyProfile.ProfileMaxPoint = buVector5.ToPoint3D(refProfile.ProfileMaxPoint);
		copyProfile.ProfileMinPoint = buVector5.ToPoint3D(refProfile.ProfileMinPoint);
		if (refProfile.ProfileReferanceEntity != null)
		{
			buEntity.Copy(refProfile.ProfileReferanceEntity, ref copyProfile.ProfileReferanceEntity);
		}
		if (refProfile.SupportBlockEntities != null)
		{
			buEntity.Copy(refProfile.SupportBlockEntities, ref copyProfile.SupportBlockEntities);
		}
		copyProfile.ProfileTraformations.Clear();
		for (int j = 0; j <= refProfile.ProfileTraformations.Count - 1; j++)
		{
			copyProfile.ProfileTraformations.Add(refProfile.ProfileTraformations[j]);
		}
		copyProfile.RightAngle = refProfile.RightAngle;
		copyProfile.selectedFreePlanes.Clear();
		for (int k = 0; k <= refProfile.selectedFreePlanes.Count - 1; k++)
		{
			copyProfile.selectedFreePlanes.Add(new SelectedPlaneInfo(refProfile.selectedFreePlanes[k]));
		}
		copyProfile.Skin = new MaterialSkin(refProfile.Skin);
		copyProfile.StandartProfileIndex = refProfile.StandartProfileIndex;
		copyProfile.SupportBlock = new ProfileSupportBlock(refProfile.SupportBlock);
		copyProfile.TextureName = refProfile.TextureName;
		copyProfile.Thickness = refProfile.Thickness;
		copyProfile.TotalOffset = refProfile.TotalOffset;
		copyProfile.Transparency = refProfile.Transparency;
		copyProfile.Width = refProfile.Width;
		copyProfile.XReferanceLocation = refProfile.XReferanceLocation;
		copyProfile.YDirection = refProfile.YDirection;
	}

	public void NotchCadCreate(ref ProfileOperation OP, ProfileItem curItem, double SupportBlockZHeight)
	{
		OP.OperationData.Array.LineerEnable = false;
		Brep brep = null;
		OP.ProfileWidth = curItem.Width;
		OP.ProfileHeight = curItem.Height;
		OP.ProfileLength = curItem.Length;
		OP.ProfileName = curItem.ItemName;
		if (OP.OperationData.NotchData.NotchOPType != ProfileNotchOperationType.Side)
		{
			if (OP.OperationData.NotchData.NotchOPType != ProfileNotchOperationType.Length)
			{
				if (OP.OperationData.NotchData.NotchOPType != ProfileNotchOperationType.Vertical)
				{
					if (OP.OperationData.NotchData.NotchOPType == ProfileNotchOperationType.Horizontal)
					{
						if (OP.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Left)
						{
							brep = Brep.CreateBox(OP.OperationData.NotchData.NotchWidth, OP.OperationData.NotchData.NotchHeight, OP.OperationData.NotchData.NotchDepth);
							brep.Regen(new RegenParams(buSystem.RegenDeviation));
							double dy = 0.0 - OP.OperationData.basePosition.Y - (brep.BoxMax.Y + brep.BoxMin.Y) / 2.0;
							double x = OP.OperationData.basePosition.X;
							brep.Translate(x, dy);
						}
						if (OP.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Right)
						{
							brep = Brep.CreateBox(OP.OperationData.NotchData.NotchWidth, OP.OperationData.NotchData.NotchHeight, OP.OperationData.NotchData.NotchDepth);
							brep.Regen(new RegenParams(buSystem.RegenDeviation));
							double dy2 = 0.0 - OP.OperationData.basePosition.Y - (brep.BoxMax.Y + brep.BoxMin.Y) / 2.0;
							double dx = curItem.Length - brep.BoxMax.X - OP.OperationData.basePosition.X;
							brep.Translate(dx, dy2);
						}
					}
				}
				else
				{
					if (OP.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Left)
					{
						brep = Brep.CreateBox(OP.OperationData.NotchData.NotchDepth, OP.OperationData.NotchData.NotchHeight, curItem.Height);
						brep.Regen(new RegenParams(buSystem.RegenDeviation));
						double num = 0.0;
						num = ((OP.OperationData.NotchData.NotchFrontBack == FrontBackType.Back) ? (0.0 - OP.OperationData.NotchData.NotchStart - brep.BoxMax.Y) : (OP.OperationData.NotchData.NotchStart + curItem.ProfileMinPoint.Y));
						brep.Translate(0.0, num);
					}
					if (OP.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Right)
					{
						brep = Brep.CreateBox(OP.OperationData.NotchData.NotchDepth, OP.OperationData.NotchData.NotchHeight, curItem.Height);
						brep.Regen(new RegenParams(buSystem.RegenDeviation));
						double dx2 = curItem.Length - brep.BoxMax.X;
						double num2 = 0.0;
						num2 = ((OP.OperationData.NotchData.NotchFrontBack == FrontBackType.Back) ? (0.0 - OP.OperationData.NotchData.NotchStart - brep.BoxMax.Y) : (OP.OperationData.NotchData.NotchStart + curItem.ProfileMinPoint.Y));
						brep.Translate(dx2, num2);
					}
				}
			}
			else
			{
				if (OP.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Back)
				{
					brep = Brep.CreateBox(OP.OperationData.NotchData.NotchWidth, OP.OperationData.NotchData.NotchDepth, OP.OperationData.NotchData.NotchHeight);
					brep.Regen(new RegenParams(buSystem.RegenDeviation));
					double dy3 = curItem.ProfileMaxPoint.Y - brep.BoxMax.Y;
					if (curItem.XReferanceLocation == LeftRightType.Left)
					{
						brep.Translate(OP.OperationData.basePosition.X, dy3);
					}
					if (curItem.XReferanceLocation == LeftRightType.Right)
					{
						brep.Translate(curItem.Length - OP.OperationData.basePosition.X - OP.OperationData.NotchData.NotchWidth, dy3);
					}
				}
				if (OP.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Front)
				{
					brep = Brep.CreateBox(OP.OperationData.NotchData.NotchWidth, OP.OperationData.NotchData.NotchDepth, OP.OperationData.NotchData.NotchHeight);
					brep.Regen(new RegenParams(buSystem.RegenDeviation));
					_ = curItem.ProfileMaxPoint.X - brep.BoxMax.X;
					double dy4 = curItem.ProfileMinPoint.Y + brep.BoxMax.Y - OP.OperationData.NotchData.NotchDepth;
					if (curItem.XReferanceLocation == LeftRightType.Left)
					{
						brep.Translate(OP.OperationData.basePosition.X, dy4);
					}
					if (curItem.XReferanceLocation == LeftRightType.Right)
					{
						brep.Translate(curItem.Length - OP.OperationData.basePosition.X - OP.OperationData.NotchData.NotchWidth, dy4);
					}
				}
			}
		}
		else
		{
			if (OP.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Left)
			{
				brep = Brep.CreateBox(OP.OperationData.NotchData.NotchDepth, curItem.Width, OP.OperationData.NotchData.NotchHeight);
				brep.Regen(new RegenParams(buSystem.RegenDeviation));
				double dy5 = curItem.ProfileMaxPoint.Y - brep.BoxMax.Y;
				brep.Translate(0.0, dy5);
			}
			if (OP.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Right)
			{
				brep = Brep.CreateBox(OP.OperationData.NotchData.NotchDepth, curItem.Width, OP.OperationData.NotchData.NotchHeight);
				brep.Regen(new RegenParams(buSystem.RegenDeviation));
				double dx3 = curItem.Length - brep.BoxMax.X;
				double dy6 = curItem.ProfileMaxPoint.Y - brep.BoxMax.Y;
				brep.Translate(dx3, dy6);
			}
		}
		if (OP.OperationData.NotchData.NotchOPType != ProfileNotchOperationType.Side)
		{
			if (OP.OperationData.NotchData.NotchOPType != ProfileNotchOperationType.Length)
			{
				if (OP.OperationData.NotchData.NotchOPType == ProfileNotchOperationType.Horizontal && brep != null)
				{
					double dz = curItem.ProfileMaxPoint.Z - brep.BoxMax.Z;
					brep.Translate(0.0, 0.0, dz);
				}
			}
			else
			{
				if (OP.OperationData.NotchData.NotchUpDown == UpDownLocationType.Up && brep != null)
				{
					double dz2 = curItem.ProfileMaxPoint.Z - brep.BoxMax.Z - OP.OperationData.NotchData.NotchStart;
					brep.Translate(0.0, 0.0, dz2);
				}
				if (OP.OperationData.NotchData.NotchUpDown == UpDownLocationType.Down && brep != null)
				{
					double dz3 = brep.BoxMin.Z + OP.OperationData.NotchData.NotchStart;
					brep.Translate(0.0, 0.0, dz3);
				}
			}
		}
		else
		{
			if (OP.OperationData.NotchData.NotchUpDown == UpDownLocationType.Up && brep != null)
			{
				double dz4 = curItem.ProfileMaxPoint.Z - OP.OperationData.NotchData.NotchStart - brep.BoxMax.Z;
				brep.Translate(0.0, 0.0, dz4);
			}
			if (OP.OperationData.NotchData.NotchUpDown == UpDownLocationType.Down && brep != null)
			{
				double dz5 = brep.BoxMin.Z + OP.OperationData.NotchData.NotchStart;
				brep.Translate(0.0, 0.0, dz5);
			}
		}
		if (brep != null)
		{
			brep.Regen(new RegenParams(buSystem.RegenDeviation));
			CustomData customData = new CustomData();
			customData.typeDefination = entityTypeDefination.Operation;
			brep.EntityData = customData;
			OP.EntityMultiSolidDepth.Add(brep);
		}
	}

	public int NotchCalc(ref ProfileOperation P, ref camTp CamCalc, ProfileItem Profile, List<ToolBase5> ToolList, ProfileSettings Settings)
	{
		try
		{
			string Name = "";
			CamCalc = new camTp();
			camTpPoint CP = new camTpPoint();
			CamCalc.Name = "Profile -" + Name;
			TpPnt9D tpPnt9D = new TpPnt9D();
			ToolBase5 toolBase = null;
			ToolBase5 toolBase2 = null;
			double num = 0.0;
			double num2 = -1.0;
			double XOffset = 0.0;
			double YOffset = 0.0;
			double XStart = 0.0;
			double XEnd = 0.0;
			double YSafe = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			for (int i = 0; i <= ToolList.Count - 1; i++)
			{
				if (ToolList[i].Purpose == ToolPurpose.Saw)
				{
					toolBase = new ToolBase5(ToolList[i]);
				}
				if (ToolList[i].Purpose != ToolPurpose.Milling)
				{
					continue;
				}
				if (toolBase2 != null)
				{
					if (ToolList[i].Geometry.Length > P.OperationData.NotchData.NotchHeight && ToolList[i].Geometry.Diameter / 2.0 <= P.OperationData.NotchData.NotchDepth && ToolList[i].Geometry.Diameter < toolBase2.Geometry.Diameter)
					{
						toolBase2 = new ToolBase5(ToolList[i]);
					}
				}
				else if (ToolList[i].Geometry.Length > P.OperationData.NotchData.NotchHeight && ToolList[i].Geometry.Diameter / 2.0 <= P.OperationData.NotchData.NotchDepth)
				{
					toolBase2 = new ToolBase5(ToolList[i]);
				}
			}
			toolBase2 = new ToolBase5(P.Tool);
			toolBase = new ToolBase5(P.ToolNotch);
			if (toolBase != null)
			{
				if (!((toolBase2 == null) & (P.OperationData.CamParNotch.Notch.NotchCutType == ProfileNotchCutType.BySawAndMilling)))
				{
					List<double> list = new List<double>();
					List<double> list2 = new List<double>();
					double num5 = 0.0;
					double num6 = 0.0;
					double XVal = 0.0;
					double XSafe = 0.0;
					double num7 = 0.0;
					double num8 = 0.0;
					double num9 = 0.0;
					double DistanceX = 0.0;
					double num10 = 0.0;
					int num11 = 0;
					NotchCalcParameter(Profile, toolBase, toolBase2, ref P, ref XOffset, ref XSafe, ref XStart, ref XEnd, ref XVal, ref DistanceX, ref YSafe, ref YOffset, ref Name);
					P.ToolNotch = new ToolBase5(toolBase);
					P.Tool = new ToolBase5(toolBase2);
					P.OperationData.ToolName = toolBase2.Data.Name;
					P.OperationData.ToolNotchName = toolBase.Data.Name;
					if (P.OperationData.NotchData.NotchOPType == ProfileNotchOperationType.Horizontal)
					{
						list.Add(Profile.Height - P.OperationData.NotchData.NotchDepth);
					}
					if ((P.OperationData.NotchData.NotchOPType == ProfileNotchOperationType.Side) | (P.OperationData.NotchData.NotchOPType == ProfileNotchOperationType.Length))
					{
						((ProfileOperationNotch)P).Width = P.OperationData.NotchData.NotchWidth;
						((ProfileOperationNotch)P).Height = P.OperationData.NotchData.NotchHeight;
						((ProfileOperationNotch)P).Start = P.OperationData.NotchData.NotchStart;
						((ProfileOperationNotch)P).Depth = P.OperationData.NotchData.NotchDepth;
						((ProfileOperationNotch)P).NotchLocation = P.OperationData.NotchData.NotchLocation;
						double num12 = Math.Round(toolBase.Geometry.Thickness, 3) * P.OperationData.CamParNotch.Notch.NotchCutPersentage / 100.0;
						double num13 = 0.0;
						double num14 = 0.0;
						if (P.OperationData.NotchData.NotchUpDown != UpDownLocationType.Down)
						{
							if (!(P.OperationData.NotchData.NotchHeight >= toolBase.Geometry.Thickness))
							{
								num14 = Profile.ProfileMaxPoint.Z - P.OperationData.NotchData.NotchStart - P.OperationData.NotchData.NotchHeight;
								num13 = Profile.ProfileMaxPoint.Z - P.OperationData.NotchData.NotchStart - P.OperationData.NotchData.NotchHeight;
								num5 = Profile.ProfileMaxPoint.Z - P.OperationData.NotchData.NotchStart - P.OperationData.NotchData.NotchHeight;
							}
							else
							{
								num14 = Profile.ProfileMaxPoint.Z - P.OperationData.NotchData.NotchStart - toolBase.Geometry.Thickness;
								num13 = Profile.ProfileMaxPoint.Z - P.OperationData.NotchData.NotchStart - P.OperationData.NotchData.NotchHeight;
								num5 = Profile.ProfileMaxPoint.Z - P.OperationData.NotchData.NotchStart - P.OperationData.NotchData.NotchHeight;
							}
						}
						else
						{
							num14 = P.OperationData.NotchData.NotchStart + P.OperationData.NotchData.NotchHeight - Math.Round(toolBase.Geometry.Thickness, 3);
							num13 = P.OperationData.NotchData.NotchStart;
							num5 = P.OperationData.NotchData.NotchStart;
						}
						double num15 = num14 - num13;
						num11 = Convert.ToInt32(buNumeric.RoundToUpper(buNumeric.RoundToUpper(num15 / num12)));
						num9 = Math.Round(num15 / (double)num11, 5);
						list.Add(num5);
						for (int j = 1; j <= num11; j++)
						{
							num6 = Math.Round(num5 + num9, 5);
							if (!buNumeric5.isValueAvailableInList(list, num6))
							{
								list.Add(num6);
								num5 = num6;
							}
						}
						if (!buNumeric5.isValueAvailableInList(list, num14))
						{
							list.Add(num14);
						}
						if (P.OperationData.CamParNotch.Notch.CutDirection == UpDownDirectionType.UpToDown)
						{
							list.Reverse();
						}
					}
					if (P.OperationData.NotchData.NotchOPType == ProfileNotchOperationType.Vertical)
					{
						((ProfileOperationNotch)P).Width = P.OperationData.NotchData.NotchWidth;
						((ProfileOperationNotch)P).Height = P.OperationData.NotchData.NotchHeight;
						((ProfileOperationNotch)P).Start = P.OperationData.NotchData.NotchStart;
						((ProfileOperationNotch)P).Depth = P.OperationData.NotchData.NotchDepth;
						((ProfileOperationNotch)P).NotchLocation = P.OperationData.NotchData.NotchLocation;
						double num12 = toolBase.Geometry.Thickness * P.OperationData.CamParNotch.Notch.NotchCutPersentage / 100.0;
						if (P.OperationData.NotchData.NotchFrontBack != FrontBackType.Front)
						{
							num4 = 0.0 - P.OperationData.NotchData.NotchStart - num12 - toolBase.Geometry.Thickness;
							num3 = 0.0 - P.OperationData.NotchData.NotchStart - P.OperationData.NotchData.NotchHeight;
							num7 = 0.0 - P.OperationData.NotchData.NotchStart - toolBase.Geometry.Thickness;
						}
						else
						{
							num4 = 0.0 - Profile.Width + P.OperationData.NotchData.NotchStart + P.OperationData.NotchData.NotchHeight - num12;
							num3 = 0.0 - Profile.Width + P.OperationData.NotchData.NotchStart + toolBase.Geometry.Thickness;
							num7 = 0.0 - Profile.Width + P.OperationData.NotchData.NotchStart + P.OperationData.NotchData.NotchHeight;
						}
						double num16 = num4 - num3;
						num11 = Convert.ToInt32(buNumeric.RoundToUpper(buNumeric.RoundToUpper(num16 / num12)));
						num9 = Math.Round(num16 / (double)num11, 5);
						list2.Clear();
						list2.Add(num7);
						for (int k = 1; k <= num11; k++)
						{
							num8 = ((P.OperationData.NotchData.NotchFrontBack == FrontBackType.Front) ? Math.Round(num7 - num9, 5) : Math.Round(num7 - num9, 5));
							list2.Add(num8);
							num7 = num8;
						}
						list2.Add(num3);
						if (P.OperationData.CamParNotch.Notch.CutDirection == UpDownDirectionType.UpToDown)
						{
							list2.Reverse();
						}
					}
					bool flag = false;
					if ((P.OperationData.NotchData.NotchUpDown == UpDownLocationType.Up) & (P.OperationData.CamParNotch.Notch.NotchCutType == ProfileNotchCutType.BySawAndMilling))
					{
						flag = true;
					}
					if (P.OperationData.NotchData.NotchStart != 0.0)
					{
						flag = false;
					}
					if (flag)
					{
						if (toolBase2 == null)
						{
							return -1;
						}
						if (P.OperationData.NotchData.NotchOPType == ProfileNotchOperationType.Side)
						{
							P.Tool = new ToolBase5(toolBase2);
							CamCalc.Tool = new ToolBase5(toolBase);
							num10 = Profile.Height - P.OperationData.NotchData.NotchHeight + toolBase.Geometry.Thickness / 2.0 + num;
							List<Point3D> list3 = new List<Point3D>();
							tpPnt9D = new TpPnt9D(new Pnt6D(XSafe + XOffset, 0.0, Profile.Height + P.OperationData.CamParNotch.Distances.Safe), P.OperationData.CamParNotch.Speeds.Rapid, 0);
							tpPnt9D.PlungeAxis = "X";
							tpPnt9D.PlungeAxisMovement = true;
							tpPnt9D.MoveType = CamMoveType.Plunge;
							CP.Points.Add(tpPnt9D);
							list3.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
							tpPnt9D = new TpPnt9D(new Pnt6D(XSafe + XOffset, 0.0, num10), P.OperationData.CamParNotch.Speeds.Rapid, 0);
							tpPnt9D.Type = 0;
							tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Rapid;
							tpPnt9D.MoveType = CamMoveType.G0;
							CP.Points.Add(tpPnt9D);
							list3.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
							tpPnt9D = new TpPnt9D(new Pnt6D(XVal + XOffset, 0.0, num10), P.OperationData.CamParNotch.Speeds.Plunge, 1);
							tpPnt9D.Type = 1;
							tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Plunge;
							tpPnt9D.MoveType = CamMoveType.G1;
							CP.Points.Add(tpPnt9D);
							list3.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
							tpPnt9D = new TpPnt9D(new Pnt6D(XVal + XOffset, Profile.Width * num2, num10), P.OperationData.CamParNotch.Speeds.Plunge, 1);
							tpPnt9D.Type = 1;
							tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Feed;
							tpPnt9D.MoveType = CamMoveType.G1;
							CP.Points.Add(tpPnt9D);
							list3.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
							tpPnt9D = new TpPnt9D(new Pnt6D(XSafe + XOffset, Profile.Width * num2, num10), P.OperationData.CamParNotch.Speeds.Plunge, 1);
							tpPnt9D.Type = 1;
							tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Leave;
							tpPnt9D.MoveType = CamMoveType.G1;
							CP.Points.Add(tpPnt9D);
							list3.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
							tpPnt9D = new TpPnt9D(new Pnt6D(XSafe + XOffset, Profile.Width * num2, Profile.Height + P.OperationData.CamParNotch.Distances.Safe), P.OperationData.CamParNotch.Speeds.Rapid, 0);
							tpPnt9D.Type = 0;
							tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Leave;
							tpPnt9D.MoveType = CamMoveType.G0;
							CP.Points.Add(tpPnt9D);
							list3.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
							new LinearPath(list3);
							CamCalc.CamPoints.Add(CP);
							CamCalc.Tool = new ToolBase5(toolBase);
							if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Left)
							{
								CamCalc.Tool.CamData.SimMoveOffset.X = (0.0 - toolBase.Geometry.Diameter) / 2.0;
							}
							if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Right)
							{
								CamCalc.Tool.CamData.SimMoveOffset.X = toolBase.Geometry.Diameter / 2.0;
							}
							if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Left)
							{
								CamCalc.MoveOffset.X = (0.0 - CamCalc.Tool.Geometry.Diameter) / 2.0;
							}
							if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Right)
							{
								CamCalc.MoveOffset.X = CamCalc.Tool.Geometry.Diameter / 2.0;
							}
							P.CamCalculation.Add(CamCalc);
							CamCalc = new camTp();
							CP = new camTpPoint();
							CamCalc.Name = "Profile -" + Name;
							tpPnt9D = new TpPnt9D();
							list3 = new List<Point3D>();
							tpPnt9D = new TpPnt9D(new Pnt6D(DistanceX, 0.0, Profile.Height + P.OperationData.CamParNotch.Distances.Safe + num), P.OperationData.CamParNotch.Speeds.Rapid, 0);
							tpPnt9D.PlungeAxis = "Z";
							tpPnt9D.PlungeAxisMovement = true;
							tpPnt9D.MoveType = CamMoveType.Plunge;
							CP.Points.Add(tpPnt9D);
							list3.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
							tpPnt9D = new TpPnt9D(new Pnt6D(DistanceX, 0.0, Profile.Height + P.OperationData.CamParNotch.Distances.Safe + num), P.OperationData.CamParNotch.Speeds.Rapid, 0);
							tpPnt9D.Type = 0;
							tpPnt9D.MoveType = CamMoveType.G0;
							tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Rapid;
							CP.Points.Add(tpPnt9D);
							list3.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
							tpPnt9D = new TpPnt9D(new Pnt6D(DistanceX, 0.0, num10 - toolBase.Geometry.Thickness / 2.0), P.OperationData.CamParNotch.Speeds.Plunge, 1);
							tpPnt9D.Type = 1;
							tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Plunge;
							tpPnt9D.MoveType = CamMoveType.G1;
							CP.Points.Add(tpPnt9D);
							list3.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
							tpPnt9D = new TpPnt9D(new Pnt6D(DistanceX, Profile.Width * num2, num10 - toolBase.Geometry.Thickness / 2.0), P.OperationData.CamParNotch.Speeds.Plunge, 1);
							tpPnt9D.Type = 1;
							tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Feed;
							tpPnt9D.MoveType = CamMoveType.G1;
							CP.Points.Add(tpPnt9D);
							list3.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
							tpPnt9D = new TpPnt9D(new Pnt6D(DistanceX, Profile.Width * num2, Profile.Height + P.OperationData.CamParNotch.Distances.Safe + num), P.OperationData.CamParNotch.Speeds.Plunge, 1);
							tpPnt9D.Type = 1;
							tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Leave;
							tpPnt9D.MoveType = CamMoveType.G1;
							CP.Points.Add(tpPnt9D);
							list3.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
							new LinearPath(list3);
							CamCalc.CamPoints.Add(CP);
							CamCalc.Tool = new ToolBase5(toolBase2);
							P.CamCalculation.Add(CamCalc);
							list.Clear();
							return 1;
						}
						if (P.OperationData.NotchData.NotchOPType == ProfileNotchOperationType.Length)
						{
							P.Tool = new ToolBase5(toolBase2);
							P.ToolNotch = new ToolBase5(toolBase);
							CamCalc.Tool = new ToolBase5(toolBase);
							num10 = Profile.Height - P.OperationData.NotchData.NotchHeight + toolBase.Geometry.Thickness / 2.0 + num;
							if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Front)
							{
								num8 = (Profile.Width - P.OperationData.NotchData.NotchDepth) * num2 + YOffset;
								YSafe = (Profile.Width + P.OperationData.CamParNotch.Distances.Safe) * num2 + YOffset;
							}
							if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Back)
							{
								num8 = 0.0 - P.OperationData.NotchData.NotchDepth + YOffset;
								YSafe = P.OperationData.CamParNotch.Distances.Safe + YOffset;
							}
							List<Point3D> PL = new List<Point3D>();
							tpPnt9D = new TpPnt9D(new Pnt6D(XStart, YSafe, Profile.Height + P.OperationData.CamParNotch.Distances.Safe), P.OperationData.CamParNotch.Speeds.Rapid, 0);
							tpPnt9D.PlungeAxis = "Y";
							tpPnt9D.PlungeAxisMovement = true;
							tpPnt9D.MoveType = CamMoveType.Plunge;
							CP.Points.Add(tpPnt9D);
							PL.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
							NotchWidthTypeCamMoveCalc(ref P, ref CP, ref PL, XStart, XEnd, YSafe, num8, num10);
							new LinearPath(PL);
							CamCalc.CamPoints.Add(CP);
							CamCalc.Tool = new ToolBase5(toolBase);
							if (P.OperationData.NotchData.NotchLocation != ProfileNotchLocationType.Front)
							{
							}
							if (P.OperationData.NotchData.NotchLocation != ProfileNotchLocationType.Back)
							{
							}
							if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Front)
							{
								CamCalc.MoveOffset.Y = (0.0 - CamCalc.Tool.Geometry.Diameter) / 2.0;
							}
							if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Back)
							{
								CamCalc.MoveOffset.Y = CamCalc.Tool.Geometry.Diameter / 2.0;
							}
							P.CamCalculation.Add(CamCalc);
							if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Front)
							{
								num8 = 0.0 - Profile.Width + toolBase2.Geometry.Diameter / 2.0 + P.OperationData.NotchData.NotchDepth;
							}
							if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Back)
							{
								num8 = 0.0 - P.OperationData.NotchData.NotchDepth + toolBase2.Geometry.Diameter / 2.0;
							}
							CamCalc = new camTp();
							CamCalc.Tool = new ToolBase5(toolBase2);
							XStart = P.OperationData.basePosition.X + toolBase2.Geometry.Diameter / 2.0;
							XEnd = P.OperationData.basePosition.X + P.OperationData.NotchData.NotchWidth - toolBase2.Geometry.Diameter / 2.0;
							CP = new camTpPoint();
							CamCalc.Name = "Profile -" + Name;
							tpPnt9D = new TpPnt9D();
							PL = new List<Point3D>();
							tpPnt9D = new TpPnt9D(new Pnt6D(XStart, num8, Profile.Height + P.OperationData.CamParNotch.Distances.Safe + num), P.OperationData.CamParNotch.Speeds.Rapid, 0);
							tpPnt9D.PlungeAxis = "Z";
							tpPnt9D.PlungeAxisMovement = true;
							tpPnt9D.MoveType = CamMoveType.Plunge;
							CP.Points.Add(tpPnt9D);
							PL.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
							tpPnt9D = new TpPnt9D(new Pnt6D(XStart, num8, Profile.Height + P.OperationData.CamParNotch.Distances.Safe + num), P.OperationData.CamParNotch.Speeds.Rapid, 0);
							tpPnt9D.Type = 0;
							tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Rapid;
							tpPnt9D.MoveType = CamMoveType.G0;
							CP.Points.Add(tpPnt9D);
							PL.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
							tpPnt9D = new TpPnt9D(new Pnt6D(XStart, num8, num10 - toolBase.Geometry.Thickness / 2.0), P.OperationData.CamParNotch.Speeds.Plunge, 1);
							tpPnt9D.Type = 1;
							tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Plunge;
							tpPnt9D.MoveType = CamMoveType.G1;
							CP.Points.Add(tpPnt9D);
							PL.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
							tpPnt9D = new TpPnt9D(new Pnt6D(XEnd, num8, num10 - toolBase.Geometry.Thickness / 2.0), P.OperationData.CamParNotch.Speeds.Plunge, 1);
							tpPnt9D.Type = 1;
							tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Feed;
							tpPnt9D.MoveType = CamMoveType.G1;
							CP.Points.Add(tpPnt9D);
							PL.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
							tpPnt9D = new TpPnt9D(new Pnt6D(XEnd, num8, Profile.Height + P.OperationData.CamParNotch.Distances.Safe + num), P.OperationData.CamParNotch.Speeds.Plunge, 1);
							tpPnt9D.Type = 1;
							tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Leave;
							tpPnt9D.MoveType = CamMoveType.G1;
							CP.Points.Add(tpPnt9D);
							PL.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
							new LinearPath(PL);
							CamCalc.CamPoints.Add(CP);
							CamCalc.Tool = new ToolBase5(toolBase2);
							P.CamCalculation.Add(CamCalc);
							list.Clear();
							return 1;
						}
						if (P.OperationData.NotchData.NotchOPType == ProfileNotchOperationType.Vertical)
						{
							double a = 90.0;
							P.Tool = new ToolBase5(toolBase2);
							CamCalc.Tool = new ToolBase5(toolBase);
							num10 = Profile.Height;
							if (P.OperationData.selectedPlaneName != planeNames.Front)
							{
								num8 = num3;
								a = -90.0;
							}
							else
							{
								num8 = num4;
							}
							List<Point3D> list4 = new List<Point3D>();
							tpPnt9D = new TpPnt9D(new Pnt6D(XSafe + XOffset, num8, Profile.Height + P.OperationData.CamParNotch.Distances.Safe, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Rapid, 0);
							tpPnt9D.PlungeAxis = "X";
							tpPnt9D.PlungeAxisMovement = true;
							tpPnt9D.MoveType = CamMoveType.Plunge;
							CP.Points.Add(tpPnt9D);
							tpPnt9D = new TpPnt9D(new Pnt6D(XSafe + XOffset, num8, num10, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Rapid, 0);
							tpPnt9D.Type = 0;
							tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Rapid;
							tpPnt9D.MoveType = CamMoveType.G0;
							CP.Points.Add(tpPnt9D);
							tpPnt9D = new TpPnt9D(new Pnt6D(XVal + XOffset, num8, num10, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Plunge, 1);
							tpPnt9D.Type = 1;
							tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Plunge;
							tpPnt9D.MoveType = CamMoveType.G1;
							CP.Points.Add(tpPnt9D);
							list4.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
							tpPnt9D = new TpPnt9D(new Pnt6D(XVal + XOffset, num8, 0.0, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Plunge, 1);
							tpPnt9D.Type = 1;
							tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Feed;
							tpPnt9D.MoveType = CamMoveType.G1;
							CP.Points.Add(tpPnt9D);
							list4.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
							tpPnt9D = new TpPnt9D(new Pnt6D(XSafe + XOffset, num8, 0.0, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Plunge, 1);
							tpPnt9D.Type = 1;
							tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Leave;
							tpPnt9D.MoveType = CamMoveType.G1;
							CP.Points.Add(tpPnt9D);
							list4.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
							tpPnt9D = new TpPnt9D(new Pnt6D(XSafe + XOffset, num8, 0.0, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Rapid, 0);
							tpPnt9D.Type = 0;
							tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Leave;
							tpPnt9D.MoveType = CamMoveType.G0;
							CP.Points.Add(tpPnt9D);
							list4.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
							tpPnt9D = new TpPnt9D(new Pnt6D(XSafe + XOffset, num8, 0.0, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Rapid, 0);
							tpPnt9D.Type = 0;
							tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Leave;
							tpPnt9D.MoveType = CamMoveType.G0;
							CP.Points.Add(tpPnt9D);
							list4.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
							tpPnt9D = new TpPnt9D(new Pnt6D(XSafe + XOffset, num8, Profile.Height + P.OperationData.CamParNotch.Distances.Safe, 90.0, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Rapid, 0);
							tpPnt9D.Type = 0;
							tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Leave;
							tpPnt9D.MoveType = CamMoveType.G0;
							CP.Points.Add(tpPnt9D);
							new LinearPath(list4);
							CamCalc.CamPoints.Add(CP);
							CamCalc.Tool = new ToolBase5(toolBase);
							if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Left)
							{
								CamCalc.Tool.CamData.SimMoveOffset.X = (0.0 - toolBase.Geometry.Diameter) / 2.0;
							}
							if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Right)
							{
								CamCalc.Tool.CamData.SimMoveOffset.X = toolBase.Geometry.Diameter / 2.0;
							}
							if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Left)
							{
								CamCalc.MoveOffset.X = (0.0 - CamCalc.Tool.Geometry.Diameter) / 2.0;
							}
							if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Right)
							{
								CamCalc.MoveOffset.X = CamCalc.Tool.Geometry.Diameter / 2.0;
							}
							P.CamCalculation.Add(CamCalc);
							CamCalc = new camTp();
							CamCalc.Tool = new ToolBase5(toolBase2);
							if (P.OperationData.selectedPlaneName != planeNames.Front)
							{
								YSafe = P.OperationData.CamParNotch.Distances.Safe;
								num8 = 0.0 - P.OperationData.NotchData.NotchHeight;
							}
							else
							{
								YSafe = 0.0 - Profile.Width - P.OperationData.CamParNotch.Distances.Safe;
								num8 = 0.0 - Profile.Width + P.OperationData.NotchData.NotchHeight;
							}
							num10 = Profile.Height + P.OperationData.CamParNotch.Distances.Safe + num;
							CP = new camTpPoint();
							CamCalc.Name = "Profile -" + Name;
							tpPnt9D = new TpPnt9D();
							list4 = new List<Point3D>();
							tpPnt9D = new TpPnt9D(new Pnt6D(DistanceX, YSafe, num10, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Rapid, 0);
							tpPnt9D.PlungeAxis = "Z";
							tpPnt9D.PlungeAxisMovement = true;
							tpPnt9D.MoveType = CamMoveType.Plunge;
							CP.Points.Add(tpPnt9D);
							tpPnt9D = new TpPnt9D(new Pnt6D(DistanceX, YSafe, num10, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Rapid, 0);
							tpPnt9D.Type = 0;
							tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Rapid;
							tpPnt9D.MoveType = CamMoveType.G0;
							CP.Points.Add(tpPnt9D);
							tpPnt9D = new TpPnt9D(new Pnt6D(DistanceX, num8, num10, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Plunge, 1);
							tpPnt9D.Type = 1;
							tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Plunge;
							CP.Points.Add(tpPnt9D);
							tpPnt9D.MoveType = CamMoveType.G1;
							list4.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
							tpPnt9D = new TpPnt9D(new Pnt6D(DistanceX, num8, 0.0, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Plunge, 1);
							tpPnt9D.Type = 1;
							tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Feed;
							tpPnt9D.MoveType = CamMoveType.G1;
							CP.Points.Add(tpPnt9D);
							list4.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
							tpPnt9D = new TpPnt9D(new Pnt6D(DistanceX, YSafe, 0.0, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Plunge, 1);
							tpPnt9D.Type = 0;
							tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Leave;
							tpPnt9D.MoveType = CamMoveType.G0;
							CP.Points.Add(tpPnt9D);
							list4.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
							tpPnt9D = new TpPnt9D(new Pnt6D(DistanceX, YSafe, num10, 0.0, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Plunge, 1);
							tpPnt9D.Type = 0;
							tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Leave;
							tpPnt9D.MoveType = CamMoveType.G0;
							CP.Points.Add(tpPnt9D);
							new LinearPath(list4);
							CamCalc.CamPoints.Add(CP);
							CamCalc.Tool = new ToolBase5(toolBase2);
							P.CamCalculation.Add(CamCalc);
							list.Clear();
							return 1;
						}
					}
					for (int l = 0; l <= list.Count - 1; l++)
					{
						CamCalc.Tool = new ToolBase5(toolBase);
						List<Point3D> PL2 = new List<Point3D>();
						CP = new camTpPoint();
						double num17 = list[l];
						if (P.OperationData.NotchData.NotchOPType == ProfileNotchOperationType.Side)
						{
							NotchSideCalc(ref CP, ref P, ref CamCalc, l, toolBase, Profile, XVal, XSafe, XOffset, num2, num17, Settings);
						}
						if (P.OperationData.NotchData.NotchOPType == ProfileNotchOperationType.Length)
						{
							if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Front)
							{
								num8 = (Profile.Width - P.OperationData.NotchData.NotchDepth) * num2 + YOffset;
								YSafe = (Profile.Width + P.OperationData.CamParNotch.Distances.Safe) * num2 + YOffset;
							}
							if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Back)
							{
								num8 = 0.0 - P.OperationData.NotchData.NotchDepth + YOffset;
								YSafe = P.OperationData.CamParNotch.Distances.Safe + YOffset;
							}
							if (P.OperationData.CamParNotch.Notch.NotchCutDirection == CamCuttingWayDirectionType.OneWayDirection)
							{
								NotchWidthTypeCamMoveCalc(ref P, ref CP, ref PL2, XStart, XEnd, YSafe, num8, num17);
							}
							if (P.OperationData.CamParNotch.Notch.NotchCutDirection == CamCuttingWayDirectionType.TwoWayDirection)
							{
								if (l % 2 != 1)
								{
									NotchWidthTypeCamMoveCalc(ref P, ref CP, ref PL2, XStart, XEnd, YSafe, num8, num17);
								}
								else
								{
									NotchWidthTypeCamMoveCalc(ref P, ref CP, ref PL2, XEnd, XStart, YSafe, num8, num17);
								}
							}
							LinearPath linearPath = new LinearPath(PL2);
							CustomData customData = new CustomData();
							customData.typeDefination = entityTypeDefination.CamPlunge;
							linearPath.EntityData = customData;
							CamCalc.EntitiesG1.Add(linearPath);
							if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Left)
							{
								CamCalc.Tool.CamData.SimMoveOffset.X = (0.0 - toolBase.Geometry.Diameter) / 2.0;
							}
							if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Right)
							{
								CamCalc.Tool.CamData.SimMoveOffset.X = toolBase.Geometry.Diameter / 2.0;
							}
							CamCalc.CamPoints.Add(CP);
							if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Left)
							{
								CamCalc.MoveOffset.X = (0.0 - CamCalc.Tool.Geometry.Diameter) / 2.0;
							}
							if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Right)
							{
								CamCalc.MoveOffset.X = CamCalc.Tool.Geometry.Diameter / 2.0;
							}
						}
						if (P.OperationData.NotchData.NotchOPType != ProfileNotchOperationType.Horizontal)
						{
							continue;
						}
						double start = Math.Round(0.0 - P.OperationData.basePosition.Y + P.OperationData.NotchData.NotchHeight / 2.0, 5);
						double end = Math.Round(0.0 - P.OperationData.basePosition.Y - P.OperationData.NotchData.NotchHeight / 2.0);
						List<double> calcSteps = new List<double>();
						buCall.buVector5_0.StepCalculation(start, end, Math.Round(P.ToolNotch.Geometry.Thickness), ref calcSteps);
						for (int m = 0; m <= calcSteps.Count - 1; m++)
						{
							CP = new camTpPoint();
							PL2 = new List<Point3D>();
							NotchHorizontalTypeCamMoveCalc(toolBase, ref P, ref CP, ref PL2, XStart, XEnd, calcSteps[m] + P.ToolNotch.Geometry.Thickness / 2.0, Profile.Height + P.CamOPData.distanceSafe, num17);
							LinearPath linearPath2 = new LinearPath(PL2);
							CustomData customData2 = new CustomData();
							customData2.typeDefination = entityTypeDefination.CamPlunge;
							linearPath2.EntityData = customData2;
							CamCalc.EntitiesG1.Add(linearPath2);
							if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Left)
							{
								CamCalc.Tool.CamData.SimMoveOffset.X = (0.0 - toolBase.Geometry.Diameter) / 2.0;
							}
							if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Right)
							{
								CamCalc.Tool.CamData.SimMoveOffset.X = toolBase.Geometry.Diameter / 2.0;
							}
							CamCalc.CamPoints.Add(CP);
						}
						P.CamCalculation.Add(CamCalc);
						if (P.OperationData.NotchData.UseMilling)
						{
							CamCalc = new camTp();
							CP = new camTpPoint();
							PL2 = new List<Point3D>();
							NotchHorizontalTypeMillingCamMoveCalc(toolBase2, ref P, ref CP, ref PL2, XStart + P.Tool.Geometry.Diameter / 2.0, XEnd - P.Tool.Geometry.Diameter / 2.0, calcSteps[0] - P.Tool.Geometry.Diameter / 2.0, calcSteps[calcSteps.Count - 1] + P.Tool.Geometry.Diameter / 2.0, Profile.Height + P.CamOPData.distanceSafe, num17);
							LinearPath linearPath3 = new LinearPath(PL2);
							CustomData customData3 = new CustomData();
							customData3.typeDefination = entityTypeDefination.CamG1;
							linearPath3.EntityData = customData3;
							CamCalc.EntitiesG1.Add(linearPath3);
							if (P.OperationData.NotchData.NotchLocation != ProfileNotchLocationType.Left)
							{
							}
							if (P.OperationData.NotchData.NotchLocation != ProfileNotchLocationType.Right)
							{
							}
							CamCalc.CamPoints.Add(CP);
							P.CamCalculation.Add(CamCalc);
						}
						return 1;
					}
					for (int n = 0; n <= list2.Count - 1; n++)
					{
						bool isLast = false;
						if (n == list2.Count - 1)
						{
							isLast = true;
						}
						if (P.OperationData.NotchData.NotchOPType == ProfileNotchOperationType.Vertical)
						{
							NotchVerticalCalc(ref CP, ref P, ref CamCalc, n, toolBase, Profile, XVal, XSafe, XOffset, num2, list2[n], Settings, isLast);
						}
					}
					TpPnt9D tpPnt9D2 = new TpPnt9D(CamCalc.CamPoints[0].Points[0]);
					tpPnt9D2.PlungeAxis = "Z";
					tpPnt9D2.P9.Z = Profile.Height + P.CamOPData.distanceSafe;
					if (tpPnt9D2.P9.Z < Profile.ClamperSettings.ClamperMaxHeight + 50.0)
					{
						tpPnt9D2.P9.Z = Profile.ClamperSettings.ClamperMaxHeight + 50.0;
						if (CamCalc.CamPoints[0].Points.Count > 0 && tpPnt9D2.P9.Z < CamCalc.CamPoints[0].Points[0].P9.Z)
						{
							tpPnt9D2.P9.Z = CamCalc.CamPoints[0].Points[0].P9.Z;
						}
					}
					TpPnt9D tpPnt9D3 = new TpPnt9D(tpPnt9D2);
					tpPnt9D3.EnableAxes.Z = false;
					tpPnt9D3.PlungeAxis = "";
					tpPnt9D3.PlungeAxisMovement = false;
					TpPnt9D item = new TpPnt9D(tpPnt9D2);
					CamCalc.CamPoints[0].Points.Insert(0, item);
					CamCalc.CamPoints[0].Points.Insert(0, tpPnt9D3);
					Point3D start2 = new Point3D(CamCalc.CamPoints[0].Points[0].P9.X, CamCalc.CamPoints[0].Points[0].P9.Y, CamCalc.CamPoints[0].Points[0].P9.Z);
					Point3D end2 = new Point3D(CamCalc.CamPoints[0].Points[1].P9.X, CamCalc.CamPoints[0].Points[1].P9.Y, CamCalc.CamPoints[0].Points[1].P9.Z);
					Line line = new Line(start2, end2);
					CustomData customData4 = new CustomData();
					customData4.typeDefination = entityTypeDefination.CamG0;
					line.EntityData = customData4;
					CamCalc.EntitiesG0.Insert(0, line);
					TpPnt9D tpPnt9D4 = new TpPnt9D(CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points[CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points.Count - 1]);
					tpPnt9D4.PlungeAxis = "Z";
					tpPnt9D4.P9.Z = Profile.Height + P.CamOPData.distanceSafe;
					if (tpPnt9D4.P9.Z < Profile.ClamperSettings.ClamperMaxHeight + 50.0)
					{
						tpPnt9D4.P9.Z = Profile.ClamperSettings.ClamperMaxHeight + 50.0;
						if (CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points.Count > 0 && tpPnt9D4.P9.Z < CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points[CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points.Count - 1].P9.Z)
						{
							tpPnt9D4.P9.Z = CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points[CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points.Count - 1].P9.Z;
						}
					}
					tpPnt9D4.Type = 0;
					tpPnt9D4.MoveType = CamMoveType.G0;
					CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points.Add(tpPnt9D4);
					start2 = new Point3D(CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points[CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points.Count - 2].P9.X, CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points[CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points.Count - 2].P9.Y, CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points[CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points.Count - 2].P9.Z);
					end2 = new Point3D(CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points[CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points.Count - 1].P9.X, CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points[CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points.Count - 1].P9.Y, CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points[CamCalc.CamPoints[CamCalc.CamPoints.Count - 1].Points.Count - 1].P9.Z);
					Line item2 = new Line(start2, end2);
					customData4 = new CustomData();
					customData4.typeDefination = entityTypeDefination.CamG0;
					line.EntityData = customData4;
					CamCalc.EntitiesG0.Add(item2);
					P.CamCalculation.Add(new camTp(CamCalc));
					return 1;
				}
				return -1;
			}
			return -1;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return -1;
		}
	}

	public void NotchVerticalCalc(ref camTpPoint CP, ref ProfileOperation P, ref camTp CamCalc, int i, ToolBase5 toolSaw, ProfileItem Profile, double XVal, double XSafe, double XOffset, double YSing, double calcY, ProfileSettings Settings, bool isLast)
	{
		TpPnt9D tpPnt9D = null;
		CamCalc.Tool = new ToolBase5(toolSaw);
		List<Point3D> list = new List<Point3D>();
		CP = new camTpPoint();
		double a = 90.0;
		if (P.OperationData.selectedPlaneName == planeNames.Back)
		{
			a = -90.0;
		}
		if (i == 0 && Settings.NotchVerticalSafeAtXAxis)
		{
			tpPnt9D = new TpPnt9D(new Pnt6D(XSafe + XOffset, calcY, Profile.Height + P.OperationData.CamParNotch.Distances.Safe, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Rapid, 0);
			tpPnt9D.MoveType = CamMoveType.G0;
			CP.Points.Add(tpPnt9D);
		}
		if (P.OperationData.CamParNotch.Notch.NotchCutDirection == CamCuttingWayDirectionType.OneWayDirection)
		{
			tpPnt9D = new TpPnt9D(new Pnt6D(XSafe + XOffset, calcY, Profile.Height, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Rapid, 0);
			tpPnt9D.PlungeAxis = "X";
			tpPnt9D.PlungeAxisMovement = true;
			tpPnt9D.MoveType = CamMoveType.G0;
			CP.Points.Add(tpPnt9D);
			tpPnt9D = new TpPnt9D(new Pnt6D(XSafe + XOffset, calcY, Profile.Height, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Rapid, 0);
			tpPnt9D.Type = 0;
			tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Rapid;
			tpPnt9D.MoveType = CamMoveType.G0;
			CP.Points.Add(tpPnt9D);
			list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
			tpPnt9D = new TpPnt9D(new Pnt6D(XVal + XOffset, calcY, Profile.Height, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Plunge, 1);
			tpPnt9D.Type = 1;
			tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Plunge;
			tpPnt9D.MoveType = CamMoveType.Plunge;
			CP.Points.Add(tpPnt9D);
			list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
			tpPnt9D = new TpPnt9D(new Pnt6D(XVal + XOffset, calcY, 0.0, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Plunge, 1);
			tpPnt9D.Type = 1;
			tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Feed;
			tpPnt9D.MoveType = CamMoveType.G1;
			CP.Points.Add(tpPnt9D);
			list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
			tpPnt9D = new TpPnt9D(new Pnt6D(XSafe + XOffset, calcY, 0.0, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Plunge, 1);
			tpPnt9D.Type = 1;
			tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Leave;
			tpPnt9D.MoveType = CamMoveType.Leave;
			CP.Points.Add(tpPnt9D);
			list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
		}
		if (!Settings.NotchVerticalSafeAtXAxis)
		{
			if (P.OperationData.CamParNotch.Notch.NotchCutDirection == CamCuttingWayDirectionType.TwoWayDirection)
			{
				if (i % 2 != 1)
				{
					tpPnt9D = new TpPnt9D(new Pnt6D(XVal + XOffset, calcY, Profile.Height + toolSaw.Geometry.Diameter / 2.0, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Rapid, 0);
					tpPnt9D.PlungeAxis = "Z";
					tpPnt9D.PlungeAxisMovement = true;
					tpPnt9D.MoveType = CamMoveType.G0;
					CP.Points.Add(tpPnt9D);
					list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
					tpPnt9D = new TpPnt9D(new Pnt6D(XVal + XOffset, calcY, 0.0 - toolSaw.Geometry.Diameter / 2.0, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Plunge, 1);
					tpPnt9D.Type = 1;
					tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Feed;
					tpPnt9D.MoveType = CamMoveType.G1;
					CP.Points.Add(tpPnt9D);
					list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
				}
				else
				{
					tpPnt9D = new TpPnt9D(new Pnt6D(XVal + XOffset, calcY, 0.0 - toolSaw.Geometry.Diameter / 2.0, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Rapid, 0);
					tpPnt9D.PlungeAxis = "Z";
					tpPnt9D.PlungeAxisMovement = true;
					tpPnt9D.MoveType = CamMoveType.G0;
					CP.Points.Add(tpPnt9D);
					list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
					tpPnt9D = new TpPnt9D(new Pnt6D(XVal + XOffset, calcY, Profile.Height + toolSaw.Geometry.Diameter / 2.0, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Plunge, 1);
					tpPnt9D.Type = 1;
					tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Feed;
					tpPnt9D.MoveType = CamMoveType.G1;
					CP.Points.Add(tpPnt9D);
					list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
				}
				if (isLast)
				{
					tpPnt9D = new TpPnt9D(CP.Points[CP.Points.Count - 1]);
					tpPnt9D.P9.X = XSafe + XOffset;
					tpPnt9D.Type = 1;
					tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Feed;
					tpPnt9D.MoveType = CamMoveType.G1;
					CP.Points.Add(tpPnt9D);
					list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
				}
			}
		}
		else if (P.OperationData.CamParNotch.Notch.NotchCutDirection == CamCuttingWayDirectionType.TwoWayDirection)
		{
			if (i % 2 != 1)
			{
				tpPnt9D = new TpPnt9D(new Pnt6D(XSafe + XOffset, calcY, Profile.Height, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Rapid, 0);
				tpPnt9D.PlungeAxis = "X";
				tpPnt9D.PlungeAxisMovement = true;
				tpPnt9D.MoveType = CamMoveType.G0;
				CP.Points.Add(tpPnt9D);
				tpPnt9D = new TpPnt9D(new Pnt6D(XSafe + XOffset, calcY, Profile.Height, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Rapid, 0);
				tpPnt9D.Type = 0;
				tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Rapid;
				tpPnt9D.MoveType = CamMoveType.G0;
				CP.Points.Add(tpPnt9D);
				list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
				tpPnt9D = new TpPnt9D(new Pnt6D(XVal + XOffset, calcY, Profile.Height, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Plunge, 1);
				tpPnt9D.Type = 1;
				tpPnt9D.MoveType = CamMoveType.Plunge;
				tpPnt9D.PlungeAxis = "X";
				tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Plunge;
				CP.Points.Add(tpPnt9D);
				list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
				tpPnt9D = new TpPnt9D(new Pnt6D(XVal + XOffset, calcY, 0.0, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Plunge, 1);
				tpPnt9D.Type = 1;
				tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Feed;
				tpPnt9D.MoveType = CamMoveType.G1;
				CP.Points.Add(tpPnt9D);
				list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
				tpPnt9D = new TpPnt9D(new Pnt6D(XSafe + XOffset, calcY, 0.0, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Plunge, 1);
				tpPnt9D.Type = 1;
				tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Leave;
				tpPnt9D.MoveType = CamMoveType.Leave;
				CP.Points.Add(tpPnt9D);
				list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
			}
			else
			{
				tpPnt9D = new TpPnt9D(new Pnt6D(XSafe + XOffset, calcY, 0.0, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Rapid, 0);
				tpPnt9D.PlungeAxis = "X";
				tpPnt9D.PlungeAxisMovement = true;
				tpPnt9D.MoveType = CamMoveType.G0;
				CP.Points.Add(tpPnt9D);
				list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
				tpPnt9D = new TpPnt9D(new Pnt6D(XSafe + XOffset, calcY, 0.0, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Rapid, 0);
				tpPnt9D.Type = 0;
				tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Rapid;
				tpPnt9D.MoveType = CamMoveType.G0;
				CP.Points.Add(tpPnt9D);
				list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
				tpPnt9D = new TpPnt9D(new Pnt6D(XVal + XOffset, calcY, 0.0, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Plunge, 1);
				tpPnt9D.Type = 1;
				tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Plunge;
				tpPnt9D.PlungeAxis = "X";
				tpPnt9D.MoveType = CamMoveType.Plunge;
				CP.Points.Add(tpPnt9D);
				list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
				tpPnt9D = new TpPnt9D(new Pnt6D(XVal + XOffset, calcY, Profile.Height, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Plunge, 1);
				tpPnt9D.Type = 1;
				tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Feed;
				tpPnt9D.MoveType = CamMoveType.G1;
				CP.Points.Add(tpPnt9D);
				list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
				tpPnt9D = new TpPnt9D(new Pnt6D(XSafe + XOffset, calcY, Profile.Height, a, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Plunge, 1);
				tpPnt9D.Type = 1;
				tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Leave;
				tpPnt9D.MoveType = CamMoveType.Leave;
				CP.Points.Add(tpPnt9D);
				list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
			}
		}
		LinearPath linearPath = new LinearPath(list);
		CustomData customData = new CustomData();
		customData.typeDefination = entityTypeDefination.CamPlunge;
		linearPath.EntityData = customData;
		CamCalc.EntitiesG1.Add(linearPath);
		if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Left)
		{
			CamCalc.Tool.CamData.SimMoveOffset.X = (0.0 - toolSaw.Geometry.Diameter) / 2.0;
		}
		if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Right)
		{
			CamCalc.Tool.CamData.SimMoveOffset.X = toolSaw.Geometry.Diameter / 2.0;
		}
		CamCalc.CamPoints.Add(CP);
		if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Left)
		{
			CamCalc.MoveOffset.X = (0.0 - CamCalc.Tool.Geometry.Diameter) / 2.0;
		}
		if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Right)
		{
			CamCalc.MoveOffset.X = CamCalc.Tool.Geometry.Diameter / 2.0;
		}
	}

	public void NotchSideCalc(ref camTpPoint CP, ref ProfileOperation P, ref camTp CamCalc, int i, ToolBase5 toolSaw, ProfileItem Profile, double XVal, double XSafe, double XOffset, double YSing, double calcZ, ProfileSettings Settings)
	{
		TpPnt9D tpPnt9D = null;
		List<Point3D> list = new List<Point3D>();
		if (P.OperationData.NotchData.NotchOPType != ProfileNotchOperationType.Side)
		{
			return;
		}
		if (P.OperationData.CamParNotch.Notch.NotchCutDirection == CamCuttingWayDirectionType.OneWayDirection)
		{
			tpPnt9D = new TpPnt9D(new Pnt6D(XSafe + XOffset, Profile.Width * YSing, calcZ), P.OperationData.CamParNotch.Speeds.Rapid, 0);
			tpPnt9D.PlungeAxis = "X";
			tpPnt9D.PlungeAxisMovement = true;
			tpPnt9D.MoveType = CamMoveType.G0;
			CP.Points.Add(tpPnt9D);
			tpPnt9D = new TpPnt9D(new Pnt6D(XSafe + XOffset, Profile.Width * YSing, calcZ), P.OperationData.CamParNotch.Speeds.Rapid, 0);
			tpPnt9D.Type = 0;
			tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Rapid;
			tpPnt9D.MoveType = CamMoveType.G0;
			CP.Points.Add(tpPnt9D);
			list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
			tpPnt9D = new TpPnt9D(new Pnt6D(XVal + XOffset, Profile.Width * YSing, calcZ), P.OperationData.CamParNotch.Speeds.Plunge, 1);
			tpPnt9D.Type = 1;
			tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Plunge;
			tpPnt9D.MoveType = CamMoveType.Plunge;
			CP.Points.Add(tpPnt9D);
			list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
			tpPnt9D = new TpPnt9D(new Pnt6D(XVal + XOffset, 0.0, calcZ), P.OperationData.CamParNotch.Speeds.Plunge, 1);
			tpPnt9D.Type = 1;
			tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Feed;
			tpPnt9D.MoveType = CamMoveType.G1;
			CP.Points.Add(tpPnt9D);
			list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
			tpPnt9D = new TpPnt9D(new Pnt6D(XSafe + XOffset, 0.0, calcZ), P.OperationData.CamParNotch.Speeds.Plunge, 1);
			tpPnt9D.Type = 1;
			tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Leave;
			tpPnt9D.MoveType = CamMoveType.Leave;
			CP.Points.Add(tpPnt9D);
			list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
		}
		if (P.OperationData.CamParNotch.Notch.NotchCutDirection == CamCuttingWayDirectionType.TwoWayDirection)
		{
			if (!Settings.NotchSideSafeAtXAxis)
			{
				if (i % 2 != 1)
				{
					tpPnt9D = new TpPnt9D(new Pnt6D(XVal + XOffset, (Profile.Width + toolSaw.Geometry.Diameter / 2.0) * YSing, calcZ), P.OperationData.CamParNotch.Speeds.Rapid, 0);
					tpPnt9D.PlungeAxis = "Y";
					tpPnt9D.PlungeAxisMovement = true;
					tpPnt9D.MoveType = CamMoveType.G0;
					CP.Points.Add(tpPnt9D);
					tpPnt9D = new TpPnt9D(new Pnt6D(XVal + XOffset, 0.0 - YSing * toolSaw.Geometry.Diameter / 2.0, calcZ), P.OperationData.CamParNotch.Speeds.Plunge, 1);
					tpPnt9D.Type = 1;
					tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Feed;
					tpPnt9D.MoveType = CamMoveType.G1;
					CP.Points.Add(tpPnt9D);
					list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
				}
				else
				{
					tpPnt9D = new TpPnt9D(new Pnt6D(XVal + XOffset, 0.0 - YSing * toolSaw.Geometry.Diameter / 2.0, calcZ), P.OperationData.CamParNotch.Speeds.Rapid, 0);
					tpPnt9D.PlungeAxis = "Y";
					tpPnt9D.PlungeAxisMovement = true;
					tpPnt9D.MoveType = CamMoveType.G0;
					CP.Points.Add(tpPnt9D);
					list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
					tpPnt9D = new TpPnt9D(new Pnt6D(XVal + XOffset, (Profile.Width + toolSaw.Geometry.Diameter / 2.0) * YSing, calcZ), P.OperationData.CamParNotch.Speeds.Plunge, 1);
					tpPnt9D.Type = 1;
					tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Feed;
					tpPnt9D.MoveType = CamMoveType.G1;
					CP.Points.Add(tpPnt9D);
					list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
				}
			}
			else if (i % 2 != 1)
			{
				tpPnt9D = new TpPnt9D(new Pnt6D(XSafe + XOffset, Profile.Width * YSing, calcZ), P.OperationData.CamParNotch.Speeds.Rapid, 0);
				tpPnt9D.PlungeAxis = "X";
				tpPnt9D.PlungeAxisMovement = true;
				tpPnt9D.MoveType = CamMoveType.G0;
				CP.Points.Add(tpPnt9D);
				tpPnt9D = new TpPnt9D(new Pnt6D(XSafe + XOffset, Profile.Width * YSing, calcZ), P.OperationData.CamParNotch.Speeds.Rapid, 0);
				tpPnt9D.Type = 0;
				tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Rapid;
				tpPnt9D.MoveType = CamMoveType.G0;
				CP.Points.Add(tpPnt9D);
				list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
				tpPnt9D = new TpPnt9D(new Pnt6D(XVal + XOffset, Profile.Width * YSing, calcZ), P.OperationData.CamParNotch.Speeds.Plunge, 1);
				tpPnt9D.Type = 1;
				tpPnt9D.MoveType = CamMoveType.Plunge;
				tpPnt9D.PlungeAxis = "X";
				tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Plunge;
				CP.Points.Add(tpPnt9D);
				list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
				tpPnt9D = new TpPnt9D(new Pnt6D(XVal + XOffset, 0.0, calcZ), P.OperationData.CamParNotch.Speeds.Plunge, 1);
				tpPnt9D.Type = 1;
				tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Feed;
				tpPnt9D.MoveType = CamMoveType.G1;
				CP.Points.Add(tpPnt9D);
				list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
				tpPnt9D = new TpPnt9D(new Pnt6D(XSafe + XOffset, 0.0, calcZ), P.OperationData.CamParNotch.Speeds.Plunge, 1);
				tpPnt9D.Type = 1;
				tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Leave;
				tpPnt9D.MoveType = CamMoveType.Leave;
				CP.Points.Add(tpPnt9D);
				list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
			}
			else
			{
				tpPnt9D = new TpPnt9D(new Pnt6D(XSafe + XOffset, 0.0, calcZ), P.OperationData.CamParNotch.Speeds.Rapid, 0);
				tpPnt9D.PlungeAxis = "X";
				tpPnt9D.PlungeAxisMovement = true;
				tpPnt9D.MoveType = CamMoveType.G0;
				CP.Points.Add(tpPnt9D);
				list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
				tpPnt9D = new TpPnt9D(new Pnt6D(XSafe + XOffset, 0.0, calcZ), P.OperationData.CamParNotch.Speeds.Rapid, 0);
				tpPnt9D.Type = 0;
				tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Rapid;
				tpPnt9D.MoveType = CamMoveType.G0;
				CP.Points.Add(tpPnt9D);
				list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
				tpPnt9D = new TpPnt9D(new Pnt6D(XVal + XOffset, 0.0, calcZ), P.OperationData.CamParNotch.Speeds.Plunge, 1);
				tpPnt9D.Type = 1;
				tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Plunge;
				tpPnt9D.PlungeAxis = "X";
				tpPnt9D.MoveType = CamMoveType.Plunge;
				CP.Points.Add(tpPnt9D);
				list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
				tpPnt9D = new TpPnt9D(new Pnt6D(XVal + XOffset, Profile.Width * YSing, calcZ), P.OperationData.CamParNotch.Speeds.Plunge, 1);
				tpPnt9D.Type = 1;
				tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Feed;
				tpPnt9D.MoveType = CamMoveType.G1;
				CP.Points.Add(tpPnt9D);
				list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
				tpPnt9D = new TpPnt9D(new Pnt6D(XSafe + XOffset, Profile.Width * YSing, calcZ), P.OperationData.CamParNotch.Speeds.Plunge, 1);
				tpPnt9D.Type = 1;
				tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Leave;
				tpPnt9D.MoveType = CamMoveType.Leave;
				CP.Points.Add(tpPnt9D);
				list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
			}
		}
		LinearPath linearPath = new LinearPath(list);
		CustomData customData = new CustomData();
		customData.typeDefination = entityTypeDefination.CamPlunge;
		linearPath.EntityData = customData;
		CamCalc.EntitiesG1.Add(linearPath);
		if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Left)
		{
			CamCalc.Tool.CamData.SimMoveOffset.X = (0.0 - toolSaw.Geometry.Diameter) / 2.0;
		}
		if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Right)
		{
			CamCalc.Tool.CamData.SimMoveOffset.X = toolSaw.Geometry.Diameter / 2.0;
		}
		CamCalc.CamPoints.Add(CP);
		if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Left)
		{
			CamCalc.MoveOffset.X = (0.0 - CamCalc.Tool.Geometry.Diameter) / 2.0;
		}
		if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Right)
		{
			CamCalc.MoveOffset.X = CamCalc.Tool.Geometry.Diameter / 2.0;
		}
	}

	public void NotchCalcParameter(ProfileItem Profile, ToolBase5 toolSaw, ToolBase5 toolMilling, ref ProfileOperation P, ref double XOffset, ref double XSafe, ref double XStart, ref double XEnd, ref double XVal, ref double DistanceX, ref double YSafe, ref double YOffset, ref string Name)
	{
		if (P.OperationData.NotchData.NotchOPType == ProfileNotchOperationType.Side)
		{
			if ((P.OperationData.NotchData.NotchLocation != ProfileNotchLocationType.Left) & (P.OperationData.NotchData.NotchLocation != ProfileNotchLocationType.Right))
			{
				P.OperationData.NotchData.NotchLocation = ProfileNotchLocationType.Left;
			}
			Name = buLangTranslate.preDef.Notch + " " + buLangTranslate.preDef.Side;
			if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Left)
			{
				XOffset = (0.0 - toolSaw.Geometry.Diameter) / 2.0;
				XSafe = 0.0 - P.OperationData.CamParNotch.Distances.Safe;
				DistanceX = P.OperationData.NotchData.NotchDepth - toolMilling.Geometry.Diameter / 2.0;
			}
			if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Right)
			{
				XOffset = toolSaw.Geometry.Diameter / 2.0;
				XSafe = Profile.Length + P.OperationData.CamParNotch.Distances.Safe;
				DistanceX = Profile.Length - P.OperationData.NotchData.NotchDepth + toolMilling.Geometry.Diameter / 2.0;
			}
			if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Left)
			{
				XVal = P.OperationData.NotchData.NotchDepth;
			}
			if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Right)
			{
				XVal = Profile.Length - P.OperationData.NotchData.NotchDepth;
			}
			P.OperationData.selectedPlaneName = planeNames.Top;
			P.OperationData.selectedPlane = Plane.XY;
		}
		if (P.OperationData.NotchData.NotchOPType == ProfileNotchOperationType.Length)
		{
			Name = buLangTranslate.preDef.Notch + " " + buLangTranslate.preDef.Length;
			if (!(P.OperationData.NotchData.NotchWidth < toolSaw.Geometry.Diameter))
			{
				if (!buCompare5.EQ(P.OperationData.basePosition.X, 0.0))
				{
					if (Profile.XReferanceLocation == LeftRightType.Left)
					{
						XStart = P.OperationData.basePosition.X + toolSaw.Geometry.Diameter / 2.0;
						XEnd = P.OperationData.basePosition.X + P.OperationData.NotchData.NotchWidth - toolSaw.Geometry.Diameter / 2.0;
					}
					if (Profile.XReferanceLocation == LeftRightType.Right)
					{
						XStart = Profile.Length - P.OperationData.basePosition.X - P.OperationData.NotchData.NotchWidth + toolSaw.Geometry.Diameter / 2.0;
						XEnd = Profile.Length - P.OperationData.basePosition.X - P.OperationData.NotchData.NotchWidth + P.OperationData.NotchData.NotchWidth - toolSaw.Geometry.Diameter / 2.0;
					}
				}
				else
				{
					if (Profile.XReferanceLocation == LeftRightType.Left)
					{
						XStart = P.OperationData.basePosition.X + toolSaw.Geometry.Diameter / 2.0;
						XEnd = P.OperationData.basePosition.X + P.OperationData.NotchData.NotchWidth - toolSaw.Geometry.Diameter / 2.0;
					}
					if (Profile.XReferanceLocation == LeftRightType.Right)
					{
						XStart = Profile.Length - P.OperationData.basePosition.X - P.OperationData.NotchData.NotchWidth + toolSaw.Geometry.Diameter / 2.0;
						XEnd = Profile.Length - P.OperationData.basePosition.X - P.OperationData.NotchData.NotchWidth + P.OperationData.NotchData.NotchWidth - toolSaw.Geometry.Diameter / 2.0;
					}
					if (XStart > XEnd)
					{
						XStart = XEnd - 50.0;
					}
				}
			}
			else
			{
				if (Profile.XReferanceLocation == LeftRightType.Left)
				{
					XStart = P.OperationData.basePosition.X;
					XEnd = P.OperationData.basePosition.X + P.OperationData.NotchData.NotchWidth;
				}
				if (Profile.XReferanceLocation == LeftRightType.Right)
				{
					XStart = Profile.Length - P.OperationData.basePosition.X - P.OperationData.NotchData.NotchWidth;
					XEnd = Profile.Length - P.OperationData.basePosition.X - P.OperationData.NotchData.NotchWidth + P.OperationData.NotchData.NotchWidth;
				}
			}
			if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Back)
			{
				YSafe = 0.0 - P.OperationData.CamParNotch.Distances.Safe;
				DistanceX = P.OperationData.NotchData.NotchDepth - toolMilling.Geometry.Diameter / 2.0;
				YOffset = toolSaw.Geometry.Diameter / 2.0;
			}
			if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Front)
			{
				YSafe = Profile.Height + P.OperationData.CamParNotch.Distances.Safe;
				DistanceX = Profile.Length - P.OperationData.NotchData.NotchDepth + toolMilling.Geometry.Diameter / 2.0;
				YOffset = (0.0 - toolSaw.Geometry.Diameter) / 2.0;
			}
			if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Left)
			{
				XVal = P.OperationData.basePosition.X;
			}
			P.OperationData.selectedPlaneName = planeNames.Top;
			P.OperationData.selectedPlane = Plane.XY;
		}
		if (P.OperationData.NotchData.NotchOPType == ProfileNotchOperationType.Vertical)
		{
			Name = buLangTranslate.preDef.Notch + " " + buLangTranslate.preDef.Vertical;
			if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Left)
			{
				XOffset = (0.0 - toolSaw.Geometry.Diameter) / 2.0;
				XSafe = 0.0 - P.OperationData.CamParNotch.Distances.Safe;
				DistanceX = P.OperationData.NotchData.NotchDepth - toolMilling.Geometry.Diameter / 2.0;
			}
			if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Right)
			{
				XOffset = toolSaw.Geometry.Diameter / 2.0;
				XSafe = Profile.Length + P.OperationData.CamParNotch.Distances.Safe;
				DistanceX = Profile.Length - P.OperationData.NotchData.NotchDepth + toolMilling.Geometry.Diameter / 2.0;
			}
			if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Left)
			{
				XVal = P.OperationData.NotchData.NotchDepth;
			}
			if (P.OperationData.NotchData.NotchLocation == ProfileNotchLocationType.Right)
			{
				XVal = Profile.Length - P.OperationData.NotchData.NotchDepth;
			}
			if (P.OperationData.NotchData.NotchFrontBack == FrontBackType.Front)
			{
				P.OperationData.selectedPlaneName = planeNames.Front;
				P.OperationData.selectedPlane = Plane.XZ;
			}
			if (P.OperationData.NotchData.NotchFrontBack == FrontBackType.Back)
			{
				P.OperationData.selectedPlaneName = planeNames.Back;
				P.OperationData.selectedPlane = Plane.XZ;
			}
		}
		if (P.OperationData.NotchData.NotchOPType != ProfileNotchOperationType.Horizontal)
		{
			return;
		}
		Name = buLangTranslate.preDef.Notch + " " + buLangTranslate.preDef.Horizontal;
		if (Profile.XReferanceLocation == LeftRightType.Left)
		{
			if (P.OperationData.NotchData.NotchLocation != ProfileNotchLocationType.Left)
			{
				XEnd = Profile.Length - P.OperationData.basePosition.X;
				XStart = Profile.Length - P.OperationData.basePosition.X - P.OperationData.NotchData.NotchWidth;
			}
			else
			{
				XStart = P.OperationData.basePosition.X;
				XEnd = P.OperationData.basePosition.X + P.OperationData.NotchData.NotchWidth;
			}
		}
		if (Profile.XReferanceLocation == LeftRightType.Right)
		{
			if (P.OperationData.NotchData.NotchLocation != ProfileNotchLocationType.Left)
			{
				XStart = Profile.Length - P.OperationData.basePosition.X - P.OperationData.NotchData.NotchWidth;
				XEnd = Profile.Length - P.OperationData.basePosition.X;
			}
			else
			{
				XEnd = P.OperationData.basePosition.X + P.OperationData.NotchData.NotchWidth;
				XStart = P.OperationData.basePosition.X;
			}
		}
		P.OperationData.selectedPlaneName = planeNames.Top;
		P.OperationData.selectedPlane = Plane.XY;
	}

	public void NotchWidthTypeCamMoveCalc(ref ProfileOperation P, ref camTpPoint CP, ref List<Point3D> PL, double XStart, double XEnd, double YSafe, double YVal, double DistanceZ)
	{
		TpPnt9D tpPnt9D = new TpPnt9D(new Pnt6D(XStart, YSafe, DistanceZ), P.OperationData.CamParNotch.Speeds.Rapid, 0);
		tpPnt9D.Type = 0;
		tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Rapid;
		tpPnt9D.MoveType = CamMoveType.G0;
		CP.Points.Add(tpPnt9D);
		PL.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
		tpPnt9D = new TpPnt9D(new Pnt6D(XStart, YVal, DistanceZ), P.OperationData.CamParNotch.Speeds.Plunge, 1);
		tpPnt9D.Type = 1;
		tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Plunge;
		tpPnt9D.MoveType = CamMoveType.G1;
		tpPnt9D.PlungeAxis = "Y";
		tpPnt9D.LeaveAxis = "Y";
		CP.Points.Add(tpPnt9D);
		PL.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
		tpPnt9D = new TpPnt9D(new Pnt6D(XEnd, YVal, DistanceZ), P.OperationData.CamParNotch.Speeds.Plunge, 1);
		tpPnt9D.Type = 1;
		tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Feed;
		CP.Points.Add(tpPnt9D);
		PL.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
		tpPnt9D = new TpPnt9D(new Pnt6D(XEnd, YSafe, DistanceZ), P.OperationData.CamParNotch.Speeds.Plunge, 1);
		tpPnt9D.Type = 1;
		tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Leave;
		tpPnt9D.MoveType = CamMoveType.G1;
		tpPnt9D.PlungeAxis = "Y";
		tpPnt9D.LeaveAxis = "Y";
		CP.Points.Add(tpPnt9D);
		PL.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
	}

	public void NotchHorizontalTypeCamMoveCalc(ToolBase5 Tool, ref ProfileOperation P, ref camTpPoint CP, ref List<Point3D> PL, double XStart, double XEnd, double YPos, double ZSafe, double ZVal)
	{
		TpPnt9D tpPnt9D = new TpPnt9D(new Pnt6D(XStart, YPos, ZSafe + Tool.Geometry.Diameter / 2.0, 90.0, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Rapid, 0);
		tpPnt9D.P9.A = 90.0;
		tpPnt9D.Type = 0;
		tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Rapid;
		tpPnt9D.MoveType = CamMoveType.G0;
		CP.Points.Add(tpPnt9D);
		PL.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z - Tool.Geometry.Diameter / 2.0));
		tpPnt9D = new TpPnt9D(new Pnt6D(XStart, YPos, ZVal + Tool.Geometry.Diameter / 2.0, 90.0, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Plunge, 1);
		tpPnt9D.Type = 1;
		tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Plunge;
		tpPnt9D.MoveType = CamMoveType.Plunge;
		tpPnt9D.PlungeAxis = "Z";
		tpPnt9D.LeaveAxis = "Z";
		tpPnt9D.PlungeAxisMovement = true;
		CP.Points.Add(tpPnt9D);
		PL.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z - Tool.Geometry.Diameter / 2.0));
		tpPnt9D = new TpPnt9D(new Pnt6D(XEnd, YPos, ZVal + Tool.Geometry.Diameter / 2.0, 90.0, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Feed, 1);
		tpPnt9D.Type = 1;
		tpPnt9D.Feed = P.OperationData.CamParNotch.Speeds.Feed;
		tpPnt9D.MoveType = CamMoveType.G1;
		CP.Points.Add(tpPnt9D);
		PL.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z - Tool.Geometry.Diameter / 2.0));
		tpPnt9D = new TpPnt9D(new Pnt6D(XEnd, YPos, ZSafe + Tool.Geometry.Diameter / 2.0, 90.0, 0.0, 0.0), P.OperationData.CamParNotch.Speeds.Leave, 0);
		tpPnt9D.Type = 0;
		tpPnt9D.MoveType = CamMoveType.G0;
		tpPnt9D.PlungeAxis = "Z";
		tpPnt9D.LeaveAxis = "Z";
		CP.Points.Add(tpPnt9D);
		PL.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z - Tool.Geometry.Diameter / 2.0));
	}

	public void NotchHorizontalTypeMillingCamMoveCalc(ToolBase5 Tool, ref ProfileOperation P, ref camTpPoint CP, ref List<Point3D> PL, double XStart, double XEnd, double YStart, double YEnd, double ZSafe, double ZVal)
	{
		TpPnt9D tpPnt9D = new TpPnt9D(new Pnt6D(XStart, YStart, ZSafe, 0.0, 0.0, 0.0), P.OperationData.CamParMilling.Speeds.Rapid, 0);
		tpPnt9D.P9.A = 0.0;
		tpPnt9D.Type = 0;
		tpPnt9D.Feed = P.OperationData.CamParMilling.Speeds.Rapid;
		tpPnt9D.MoveType = CamMoveType.G0;
		CP.Points.Add(tpPnt9D);
		PL.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
		tpPnt9D = new TpPnt9D(new Pnt6D(XStart, YStart, ZVal, 0.0, 0.0, 0.0), P.OperationData.CamParMilling.Speeds.Plunge, 1);
		tpPnt9D.Type = 1;
		tpPnt9D.Feed = P.OperationData.CamParMilling.Speeds.Plunge;
		tpPnt9D.MoveType = CamMoveType.Plunge;
		tpPnt9D.PlungeAxis = "Z";
		tpPnt9D.LeaveAxis = "Z";
		tpPnt9D.PlungeAxisMovement = true;
		CP.Points.Add(tpPnt9D);
		PL.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
		tpPnt9D = new TpPnt9D(new Pnt6D(XStart, YEnd, ZVal, 0.0, 0.0, 0.0), P.OperationData.CamParMilling.Speeds.Feed, 1);
		tpPnt9D.Type = 1;
		tpPnt9D.Feed = P.OperationData.CamParMilling.Speeds.Feed;
		tpPnt9D.MoveType = CamMoveType.G1;
		CP.Points.Add(tpPnt9D);
		PL.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
		tpPnt9D = new TpPnt9D(new Pnt6D(XStart, YEnd, ZSafe, 0.0, 0.0, 0.0), P.OperationData.CamParMilling.Speeds.Leave, 0);
		tpPnt9D.Type = 0;
		tpPnt9D.MoveType = CamMoveType.G0;
		tpPnt9D.PlungeAxis = "Z";
		tpPnt9D.LeaveAxis = "Z";
		CP.Points.Add(tpPnt9D);
		PL.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
		tpPnt9D = new TpPnt9D(new Pnt6D(XEnd, YStart, ZSafe, 0.0, 0.0, 0.0), P.OperationData.CamParMilling.Speeds.Rapid, 0);
		tpPnt9D.P9.A = 0.0;
		tpPnt9D.Type = 0;
		tpPnt9D.Feed = P.OperationData.CamParMilling.Speeds.Rapid;
		tpPnt9D.MoveType = CamMoveType.G0;
		CP.Points.Add(tpPnt9D);
		PL.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
		tpPnt9D = new TpPnt9D(new Pnt6D(XEnd, YStart, ZVal, 0.0, 0.0, 0.0), P.OperationData.CamParMilling.Speeds.Plunge, 1);
		tpPnt9D.Type = 1;
		tpPnt9D.Feed = P.OperationData.CamParMilling.Speeds.Plunge;
		tpPnt9D.MoveType = CamMoveType.Plunge;
		tpPnt9D.PlungeAxis = "Z";
		tpPnt9D.LeaveAxis = "Z";
		tpPnt9D.PlungeAxisMovement = true;
		CP.Points.Add(tpPnt9D);
		PL.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
		tpPnt9D = new TpPnt9D(new Pnt6D(XEnd, YEnd, ZVal, 0.0, 0.0, 0.0), P.OperationData.CamParMilling.Speeds.Feed, 1);
		tpPnt9D.Type = 1;
		tpPnt9D.Feed = P.OperationData.CamParMilling.Speeds.Feed;
		tpPnt9D.MoveType = CamMoveType.G1;
		CP.Points.Add(tpPnt9D);
		PL.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z - Tool.Geometry.Diameter / 2.0));
		tpPnt9D = new TpPnt9D(new Pnt6D(XEnd, YEnd, ZSafe, 0.0, 0.0, 0.0), P.OperationData.CamParMilling.Speeds.Leave, 0);
		tpPnt9D.Type = 0;
		tpPnt9D.MoveType = CamMoveType.G0;
		tpPnt9D.PlungeAxis = "Z";
		tpPnt9D.LeaveAxis = "Z";
		CP.Points.Add(tpPnt9D);
		PL.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z - Tool.Geometry.Diameter / 2.0));
	}

	public ProfileNotchLocationType GetNotchLocationType(ShapeRuntimeData Par)
	{
		if (Par.NotchOPType != ProfileNotchOperationType.Side)
		{
			return Par.NotchLengthLocation;
		}
		return Par.NotchSideLocation;
	}

	public void FindNotchDataValueType(buShape Shape, int indexRow, ref ShapeDataValueType DataValue)
	{
		DataValue = ShapeDataValueType.None;
		if (Shape.ShapeGroup != ShapeGroup.Shape)
		{
			return;
		}
		if (!(Shape is buShapeNotch))
		{
			return;
		}
		buShapeNotch buShapeNotch2 = Shape as buShapeNotch;
		if (buShapeNotch2.NotchOPType == ProfileNotchOperationType.Side)
		{
			if (indexRow == 0)
			{
				DataValue = ShapeDataValueType.Height;
			}
			if (indexRow == 1)
			{
				DataValue = ShapeDataValueType.Distance;
			}
			if (indexRow == 2)
			{
				DataValue = ShapeDataValueType.Width;
			}
		}
		if (buShapeNotch2.NotchOPType == ProfileNotchOperationType.Length)
		{
			if (indexRow == 0)
			{
				DataValue = ShapeDataValueType.XPosition;
			}
			if (indexRow == 1)
			{
				DataValue = ShapeDataValueType.ZPosition;
			}
			if (indexRow == 2)
			{
				DataValue = ShapeDataValueType.Width;
			}
			if (indexRow == 3)
			{
				DataValue = ShapeDataValueType.Height;
			}
			if (indexRow == 4)
			{
				DataValue = ShapeDataValueType.Distance;
			}
		}
		if (buShapeNotch2.NotchOPType == ProfileNotchOperationType.Vertical)
		{
			if (indexRow == 0)
			{
				DataValue = ShapeDataValueType.Height;
			}
			if (indexRow == 1)
			{
				DataValue = ShapeDataValueType.Distance;
			}
			if (indexRow == 2)
			{
				DataValue = ShapeDataValueType.Width;
			}
		}
		if (buShapeNotch2.NotchOPType == ProfileNotchOperationType.Horizontal)
		{
			if (indexRow == 0)
			{
				DataValue = ShapeDataValueType.XPosition;
			}
			if (indexRow == 1)
			{
				DataValue = ShapeDataValueType.YPosition;
			}
			if (indexRow == 2)
			{
				DataValue = ShapeDataValueType.Width;
			}
			if (indexRow == 3)
			{
				DataValue = ShapeDataValueType.Height;
			}
			if (indexRow == 4)
			{
				DataValue = ShapeDataValueType.Depth;
			}
		}
	}

	public void FindNotchDataValueType(ShapeRuntimeData Shape, int indexRow, ref ShapeDataValueType DataValue)
	{
		DataValue = ShapeDataValueType.None;
		if (Shape.ShapeGroup != ShapeGroup.Notch)
		{
			return;
		}
		if (Shape.NotchOPType == ProfileNotchOperationType.Side)
		{
			if (indexRow == 0)
			{
				DataValue = ShapeDataValueType.Height;
			}
			if (indexRow == 1)
			{
				DataValue = ShapeDataValueType.Distance;
			}
			if (indexRow == 2)
			{
				DataValue = ShapeDataValueType.Width;
			}
		}
		if (Shape.NotchOPType == ProfileNotchOperationType.Length)
		{
			if (indexRow == 0)
			{
				DataValue = ShapeDataValueType.XPosition;
			}
			if (indexRow == 1)
			{
				DataValue = ShapeDataValueType.ZPosition;
			}
			if (indexRow == 2)
			{
				DataValue = ShapeDataValueType.Width;
			}
			if (indexRow == 3)
			{
				DataValue = ShapeDataValueType.Height;
			}
			if (indexRow == 4)
			{
				DataValue = ShapeDataValueType.Distance;
			}
		}
		if (Shape.NotchOPType == ProfileNotchOperationType.Vertical)
		{
			if (indexRow == 0)
			{
				DataValue = ShapeDataValueType.Height;
			}
			if (indexRow == 1)
			{
				DataValue = ShapeDataValueType.Distance;
			}
			if (indexRow == 2)
			{
				DataValue = ShapeDataValueType.Width;
			}
		}
		if (Shape.NotchOPType == ProfileNotchOperationType.Horizontal)
		{
			if (indexRow == 0)
			{
				DataValue = ShapeDataValueType.XPosition;
			}
			if (indexRow == 1)
			{
				DataValue = ShapeDataValueType.YPosition;
			}
			if (indexRow == 2)
			{
				DataValue = ShapeDataValueType.Width;
			}
			if (indexRow == 3)
			{
				DataValue = ShapeDataValueType.Height;
			}
			if (indexRow == 4)
			{
				DataValue = ShapeDataValueType.Depth;
			}
		}
	}
}
