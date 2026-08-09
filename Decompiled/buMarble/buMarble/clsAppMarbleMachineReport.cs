using System;
using System.Reflection;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;
using buEyeBaseVer5;

namespace buMarble;

[Serializable]
public class clsAppMarbleMachineReport : buSerilization5
{
	public clsAppMarbleMachineReportItem ItemSpindleUp = null;

	public clsAppMarbleMachineReportItem ItemSpindleDown = null;

	public clsAppMarbleMachineReportItem ItemVacuumUp = null;

	public clsAppMarbleMachineReportItem ItemVacuumDown = null;

	public clsAppMarbleMachineReportItem ItemLeftSuctionCup = null;

	public clsAppMarbleMachineReportItem ItemRightSuctionCup = null;

	public clsAppMarbleMachineReportItem ItemToolMeasureUp = null;

	public clsAppMarbleMachineReportItem ItemToolMeasureDown = null;

	public clsAppMarbleMachineReportItem ItemMaterialMeasureUp = null;

	public clsAppMarbleMachineReportItem ItemMaterialMeasureDown = null;

	public clsAppMarbleMachineReportItem ItemLaserOnOff = null;

	public clsAppMarbleMachineReportItem ItemLeftVacuumOutOk = null;

	public clsAppMarbleMachineReportItem IteLeftVacuumInOk = null;

	public clsAppMarbleMachineReportItem ItemRightVacuumOutOk = null;

	public clsAppMarbleMachineReportItem ItemRightVacuumInOk = null;

	public clsAppMarbleMachineReportItem ItemToolBlowOnOff = null;

	public clsAppMarbleMachineReportItem ItemSuctionCupAirOnOff = null;

	public clsAppMarbleMachineReportItem ItemMagazineOpen = null;

	public clsAppMarbleMachineReportItem ItemMagazineClose = null;

	public clsAppMarbleMachineReportItem ItemMagazineUp = null;

	public clsAppMarbleMachineReportItem ItemMagazineDown = null;

	public clsAppMarbleMachineReportItem ItemToolPens = null;

	public clsAppMarbleMachineReportItem ItemWaterOnOff = null;

	public clsAppMarbleMachineReportItem ItemCameraCover = null;

	public clsAppMarbleMachineReportItem ItemLubrication = null;

	public string ReportName = _007F(107397374);

	public int ReportID = 0;

	public DateTime ReportDate = DateTime.Now;

	public bool Status = false;

	[NonSerialized]
	internal static GetString _007F;

	public clsAppMarbleMachineReport()
	{
		ItemSpindleUp = new clsAppMarbleMachineReportItem(buLangTranslate.preDef.Spindle + _007F(107395991) + buLangTranslate.preDef.Up);
		ItemSpindleDown = new clsAppMarbleMachineReportItem(buLangTranslate.preDef.Spindle + _007F(107395991) + buLangTranslate.preDef.Down);
		ItemVacuumUp = new clsAppMarbleMachineReportItem(buLangTranslate.preDef.Vacuum + _007F(107395991) + buLangTranslate.preDef.Up);
		ItemVacuumDown = new clsAppMarbleMachineReportItem(buLangTranslate.preDef.Vacuum + _007F(107395991) + buLangTranslate.preDef.Down);
		ItemLeftSuctionCup = new clsAppMarbleMachineReportItem(buLangTranslate.preDef.Left + _007F(107395991) + buLangTranslate.preDef.SuctionCub);
		ItemRightSuctionCup = new clsAppMarbleMachineReportItem(buLangTranslate.preDef.Right + _007F(107395991) + buLangTranslate.preDef.SuctionCub);
		ItemToolMeasureUp = new clsAppMarbleMachineReportItem(buLangTranslate.preDef.Tool + _007F(107395991) + buLangTranslate.preDef.Measure + _007F(107395991) + buLangTranslate.preDef.Up);
		ItemToolMeasureDown = new clsAppMarbleMachineReportItem(buLangTranslate.preDef.Tool + _007F(107395991) + buLangTranslate.preDef.Measure + _007F(107395991) + buLangTranslate.preDef.Down);
		ItemMaterialMeasureUp = new clsAppMarbleMachineReportItem(buLangTranslate.preDef.Slab + _007F(107395991) + buLangTranslate.preDef.Measure + _007F(107395991) + buLangTranslate.preDef.Up);
		ItemMaterialMeasureDown = new clsAppMarbleMachineReportItem(buLangTranslate.preDef.Slab + _007F(107395991) + buLangTranslate.preDef.Measure + _007F(107395991) + buLangTranslate.preDef.Down);
		ItemLaserOnOff = new clsAppMarbleMachineReportItem(buLangTranslate.preDef.Laser + _007F(107395991) + buLangTranslate.preDef.On + _007F(107380378) + buLangTranslate.preDef.Off);
		ItemLeftVacuumOutOk = new clsAppMarbleMachineReportItem(buLangTranslate.preDef.Left + _007F(107395991) + buLangTranslate.preDef.Out + _007F(107395991) + buLangTranslate.preDef.Vacuum);
		IteLeftVacuumInOk = new clsAppMarbleMachineReportItem(buLangTranslate.preDef.Left + _007F(107395991) + buLangTranslate.preDef.In + _007F(107395991) + buLangTranslate.preDef.Vacuum);
		ItemRightVacuumOutOk = new clsAppMarbleMachineReportItem(buLangTranslate.preDef.Right + _007F(107395991) + buLangTranslate.preDef.Out + _007F(107395991) + buLangTranslate.preDef.Vacuum);
		ItemRightVacuumInOk = new clsAppMarbleMachineReportItem(buLangTranslate.preDef.Right + _007F(107395991) + buLangTranslate.preDef.In + _007F(107395991) + buLangTranslate.preDef.Vacuum);
		ItemToolBlowOnOff = new clsAppMarbleMachineReportItem(buLangTranslate.preDef.Blow + _007F(107395991) + buLangTranslate.preDef.On + _007F(107380378) + buLangTranslate.preDef.Off);
		ItemSuctionCupAirOnOff = new clsAppMarbleMachineReportItem(buLangTranslate.preDef.Air + _007F(107395991) + buLangTranslate.preDef.On + _007F(107380378) + buLangTranslate.preDef.Off);
		ItemMagazineOpen = new clsAppMarbleMachineReportItem(buLangTranslate.preDef.Magazine + _007F(107395991) + buLangTranslate.preDef.Open);
		ItemMagazineClose = new clsAppMarbleMachineReportItem(buLangTranslate.preDef.Magazine + _007F(107395991) + buLangTranslate.preDef.Close);
		ItemMagazineUp = new clsAppMarbleMachineReportItem(buLangTranslate.preDef.Magazine + _007F(107395991) + buLangTranslate.preDef.Up);
		ItemMagazineDown = new clsAppMarbleMachineReportItem(buLangTranslate.preDef.Magazine + _007F(107395991) + buLangTranslate.preDef.Down);
		ItemToolPens = new clsAppMarbleMachineReportItem(buLangTranslate.preDef.Pens + _007F(107395991) + buLangTranslate.preDef.On + _007F(107380378) + buLangTranslate.preDef.Off);
		ItemWaterOnOff = new clsAppMarbleMachineReportItem(buLangTranslate.preDef.Water + _007F(107395991) + buLangTranslate.preDef.On + _007F(107380378) + buLangTranslate.preDef.Off);
		ItemCameraCover = new clsAppMarbleMachineReportItem(buLangTranslate.preDef.Camera + _007F(107395991) + buLangTranslate.preDef.Cover + _007F(107395991) + buLangTranslate.preDef.On + _007F(107380378) + buLangTranslate.preDef.Off);
		ItemLubrication = new clsAppMarbleMachineReportItem(buLangTranslate.preDef.Lubricate + _007F(107395991) + buLangTranslate.preDef.On + _007F(107380378) + buLangTranslate.preDef.Off);
	}

	public clsAppMarbleMachineReport(clsAppMarbleMachineReport data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				string name = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}

	static clsAppMarbleMachineReport()
	{
		Strings.CreateGetStringDelegate(typeof(clsAppMarbleMachineReport));
	}
}
