using System;
using System.Collections.Generic;
using System.Reflection;
using devDept.Eyeshot.Entities;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCounterTopPars : buSerilization5
{
	public MarbleCountertopTypes CountertopType = MarbleCountertopTypes.RectangleType1;

	public MarbleCountertopCommands Commands = MarbleCountertopCommands.None;

	public MarbleCountertopActiveModes ActiveMode = MarbleCountertopActiveModes.None;

	public MarbleCountertopActiveModes ActiveModePre = MarbleCountertopActiveModes.None;

	public List<marbleEdgeItem> EdgeItems = new List<marbleEdgeItem>();

	public marbleCountertopMainPars Main = new marbleCountertopMainPars();

	public marbleCountertopInsidePars SinkFirst = new marbleCountertopInsidePars();

	public marbleCountertopInsidePars SinkSecond = new marbleCountertopInsidePars();

	public marbleCountertopInsidePars BuiltInFirst = new marbleCountertopInsidePars();

	public marbleCountertopInsidePars BuiltInSecond = new marbleCountertopInsidePars();

	public marbleCountertopTapPars TapFirst = new marbleCountertopTapPars();

	public marbleCountertopTapPars TapSecond = new marbleCountertopTapPars();

	public marbleCountertopTapPars TapThird = new marbleCountertopTapPars();

	public marbleCountertopTapPars TapFourth = new marbleCountertopTapPars();

	public marbleCountertopCavityPars CavityFirst = new marbleCountertopCavityPars();

	public marbleCountertopCavityPars CavitySecond = new marbleCountertopCavityPars();

	public buEntitiesGroup EntitiesGroup = new buEntitiesGroup();

	public Entity SolidEntity = null;

	public static List<string> Captions = new List<string>();

	public marbleCounterTopPars()
	{
	}

	public marbleCounterTopPars(marbleCounterTopPars data)
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
		SinkFirst = new marbleCountertopInsidePars(data.SinkFirst);
		SinkSecond = new marbleCountertopInsidePars(data.SinkSecond);
		BuiltInFirst = new marbleCountertopInsidePars(data.BuiltInFirst);
		BuiltInSecond = new marbleCountertopInsidePars(data.BuiltInSecond);
		TapFirst = new marbleCountertopTapPars(data.TapFirst);
		TapSecond = new marbleCountertopTapPars(data.TapSecond);
		TapThird = new marbleCountertopTapPars(data.TapThird);
		TapFourth = new marbleCountertopTapPars(data.TapFourth);
		CavityFirst = new marbleCountertopCavityPars(data.CavityFirst);
		CavitySecond = new marbleCountertopCavityPars(data.CavitySecond);
		Main = new marbleCountertopMainPars(data.Main);
		EntitiesGroup = new buEntitiesGroup(data.EntitiesGroup);
		marbleEdgeItem.Copy(data.EdgeItems, ref EdgeItems);
	}

	public override string ToString()
	{
		return CountertopType.ToString();
	}
}
