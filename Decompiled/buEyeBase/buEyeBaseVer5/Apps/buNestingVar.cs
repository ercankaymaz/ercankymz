using System;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingVar : buSerilization5
{
	public buNestingSheetSettings MaterailSettings = new buNestingSheetSettings();

	public buNestingPartSettings PartSettings = new buNestingPartSettings();

	public buNestingSheetAddData AddMaterial = new buNestingSheetAddData();

	public buNestingPartAddData AddPart = new buNestingPartAddData();

	public buNestingSettings Settings = new buNestingSettings();

	public buNestingProgramSettings ProgramSettings = new buNestingProgramSettings();

	public buNestingResultSettings ResultSettings = new buNestingResultSettings();

	public buNestingRuntime Runtime = new buNestingRuntime();

	public buNestingDraw Draw = new buNestingDraw();

	public AnalyseEntitiesSetting AnalyseSettings = new AnalyseEntitiesSetting();

	public buNestingVar()
	{
	}

	public buNestingVar(buNestingVar data)
	{
		MaterailSettings = new buNestingSheetSettings(data.MaterailSettings);
		PartSettings = new buNestingPartSettings(data.PartSettings);
		AddMaterial = new buNestingSheetAddData(data.AddMaterial);
		AddPart = new buNestingPartAddData(data.AddPart);
		Settings = new buNestingSettings(data.Settings);
		ResultSettings = new buNestingResultSettings(data.ResultSettings);
		Runtime = new buNestingRuntime(data.Runtime);
		Draw = new buNestingDraw(data.Draw);
		ProgramSettings = new buNestingProgramSettings(data.ProgramSettings);
	}
}
