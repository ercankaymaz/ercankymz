using System;
using System.Reflection;

namespace buEyeBaseVer5.Variables;

[Serializable]
public class varRuntimePar5 : buSerilization5
{
	public AnalyseEntitiesSetting AnalyseEntitySetting = new AnalyseEntitiesSetting();

	public DirectionArrowSetting DirectionArrowSettings = new DirectionArrowSetting();

	public CopyEventFormVars copyEventFormVar = new CopyEventFormVars();

	public MoveEventFormVars moveEventFormVar = new MoveEventFormVars();

	public ScaleEventFormVars scaleEventFormVar = new ScaleEventFormVars();

	public MirrorEventFormVars mirrorEventFormVar = new MirrorEventFormVars();

	public DevideEventFormVars devideEventFormVar = new DevideEventFormVars();

	public DeleteTypeEventFormVars deleteTypeEventFormVar = new DeleteTypeEventFormVars();

	public FlatViewSettings FlatViewSettings = new FlatViewSettings();

	public varRuntimePar5()
	{
	}

	public varRuntimePar5(varRuntimePar5 data)
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
		AnalyseEntitySetting = new AnalyseEntitiesSetting(data.AnalyseEntitySetting);
		DirectionArrowSettings = new DirectionArrowSetting(data.DirectionArrowSettings);
		copyEventFormVar = new CopyEventFormVars(data.copyEventFormVar);
		moveEventFormVar = new MoveEventFormVars(data.moveEventFormVar);
		scaleEventFormVar = new ScaleEventFormVars(data.scaleEventFormVar);
		mirrorEventFormVar = new MirrorEventFormVars(data.mirrorEventFormVar);
		devideEventFormVar = new DevideEventFormVars(data.devideEventFormVar);
		deleteTypeEventFormVar = new DeleteTypeEventFormVars(data.deleteTypeEventFormVar);
	}
}
