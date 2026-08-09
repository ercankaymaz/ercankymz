using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleColorSettings : buSerilization5
{
	public int SolidTranperancy = 120;

	public ColorType colorItemBase = new ColorType(Color.Gray, 255);

	public ColorType colorItem = new ColorType(Color.WhiteSmoke, 255);

	public ColorType colorItemContour = new ColorType(Color.WhiteSmoke, 255);

	public ColorType colorItemEngrave = new ColorType(Color.WhiteSmoke, 255);

	public ColorType colorItemInside = new ColorType(Color.Cyan, 255);

	public ColorType colorItemProfile = new ColorType(Color.WhiteSmoke, 255);

	public ColorType colorItemProfileCurve = new ColorType(Color.WhiteSmoke, 255);

	public ColorType colorItemLatheHorizontal = new ColorType(Color.WhiteSmoke, 255);

	public ColorType colorItemLatheVertical = new ColorType(Color.WhiteSmoke, 255);

	public ColorType colorItemColumn = new ColorType(Color.WhiteSmoke, 255);

	public ColorType colorItemSweep = new ColorType(Color.WhiteSmoke, 255);

	public ColorType colorItemHole = new ColorType(Color.WhiteSmoke, 255);

	public ColorType colorItemText = new ColorType(Color.WhiteSmoke, 255);

	public ColorType colorItemSlicesHorizontal = new ColorType(Color.WhiteSmoke, 255);

	public ColorType colorItemSlicesVertical = new ColorType(Color.WhiteSmoke, 255);

	public ColorType colorItemSingleCut = new ColorType(Color.WhiteSmoke, 255);

	public ColorType colorItemMaterialClean = new ColorType(Color.WhiteSmoke, 255);

	public ColorType colorItemAirDry = new ColorType(Color.WhiteSmoke, 100);

	public ColorType colorAngleText = new ColorType(Color.Red, 255);

	public ColorType colorSequenceText = new ColorType(Color.Black, 255);

	public ColorType colorMaterial = new ColorType(Color.Pink, 100);

	public ColorType colorMaterialDimension = new ColorType(Color.Black, 255);

	public ColorType colorPartDimension = new ColorType(Color.Black, 255);

	public ColorType colorDirArrow = new ColorType(Color.Red, 255);

	public ColorType colorItemEdge = new ColorType(Color.Black, 255);

	public ColorType colorItemCollopse = new ColorType(Color.DeepPink, 160);

	public ColorType colorItemVacuumCutMaterial = new ColorType(Color.GreenYellow, 255);

	public ColorType colorItemVacuumCutEdge = new ColorType(Color.Red, 255);

	public ColorDrawType colorText = new ColorDrawType(Color.Black, 255, 1.0);

	public ColorDrawType colorItemWire = new ColorDrawType(Color.Green, 255, 1.0);

	public ColorDrawType colorItemExtension = new ColorDrawType(Color.Black, 255, 1.0);

	public ColorDrawType colorDirArrowSequence = new ColorDrawType(Color.Black, 255, 3.0);

	public ColorDrawType colorCamG0 = new ColorDrawType(Color.Blue, 255, 1.0);

	public ColorDrawType colorCamG1 = new ColorDrawType(Color.Red, 255, 1.0);

	public ColorDrawType colorCamPlunge = new ColorDrawType(Color.Orange, 255, 1.0);

	public ColorDrawType colorCamLeave = new ColorDrawType(Color.DarkRed, 255, 1.0);

	public ColorDrawType colorCamConnection = new ColorDrawType(Color.Purple, 255, 1.0);

	public ColorDrawType colorCamLeadInOut = new ColorDrawType(Color.Orange, 255, 1.0);

	public ColorDrawType colorCamDraw = new ColorDrawType(Color.DarkOliveGreen, 255, 2.0);

	public ColorDrawType colorVacuum = new ColorDrawType(Color.Orange, 255, 2.0);

	public ColorDrawType colorCutSaw = new ColorDrawType(Color.Red, 255, 1.0);

	public ColorDrawType colorCutMilling = new ColorDrawType(Color.Blue, 255, 1.0);

	public ColorDrawType colorCutMillingHead = new ColorDrawType(Color.Green, 255, 1.0);

	public ColorDrawType colorCutWaterjet = new ColorDrawType(Color.Cyan, 255, 1.0);

	public ColorDrawType colorCutSaw45 = new ColorDrawType(Color.DarkRed, 255, 1.0);

	public ColorType colorViewportGrid = new ColorType(Color.Black, 255);

	public ColorType colorControlEnable = new ColorType(Color.Lime, 255);

	public ColorType colorControlDisable = new ColorType(Color.Red, 255);

	public ColorType colorControlselected = new ColorType(Color.Gold, 255);

	public static List<string> Captions = new List<string>();

	public MarbleColorSettings()
	{
	}

	public MarbleColorSettings(MarbleColorSettings data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}

	public static void Copy(MarbleColorSettings Source, ref MarbleColorSettings Target)
	{
		Target = new MarbleColorSettings(Source);
	}

	public override string ToString()
	{
		return "colorItem: " + colorItem.ToString();
	}
}
