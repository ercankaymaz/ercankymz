using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleItemOperations : buSerilization5
{
	public string OperationName = "";

	public bool Enable = true;

	public bool IsExecuted = false;

	public bool isError = false;

	public bool Visible = true;

	public int ID = -1;

	public int CamIndex = -1;

	public ToolBase5 ToolOP = null;

	public MarbleToolType ToolType = MarbleToolType.Saw;

	public MarbleItemType ItemType = MarbleItemType.HorizontalCut;

	public MarbleShapeTypes ShapeType = MarbleShapeTypes.Rectangle;

	public MarbleItemOperations()
	{
	}

	public MarbleItemOperations(MarbleItemCam Cam, MarbleItem Item, int camIndex)
	{
		if (Cam != null)
		{
			OperationName = Cam.CamName;
			ID = Cam.ID;
			ToolOP = new ToolBase5(Cam.ToolSelected);
			ToolType = Cam.ToolType;
		}
		CamIndex = camIndex;
		if (Item != null)
		{
			ItemType = Item.ItemType;
			ShapeType = Item.ShapeType;
		}
		string text = ToolType.ToString();
		if (ToolType != MarbleToolType.Saw)
		{
			if (ToolType != MarbleToolType.Milling)
			{
				if (ToolType != MarbleToolType.MillingHead)
				{
					if (ToolType == MarbleToolType.WaterJet)
					{
						text = buLangTranslate.preDef.WaterJet;
					}
				}
				else
				{
					text = buLangTranslate.preDef.MillingHead;
				}
			}
			else
			{
				text = buLangTranslate.preDef.Milling;
			}
		}
		else
		{
			text = buLangTranslate.preDef.Saw;
		}
		OperationName = (camIndex + 1).ToString("D2") + "- " + Item.ItemName + " - " + Cam.CamName + "  [ " + text + " ]";
	}

	public MarbleItemOperations(MarbleItemOperations data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
		{
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
		if (data.ToolOP != null)
		{
			ToolOP = new ToolBase5(data.ToolOP);
		}
	}

	public override string ToString()
	{
		return "Type:" + ItemType.ToString() + " , ID:" + ID + " , ToolType:" + ToolType;
	}
}
