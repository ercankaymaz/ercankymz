using System;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;

namespace buMotion;

[Serializable]
public class buMotionMessageLang : buSerilization
{
	public string DoYoutoTurnDefault = _0019(107385540);

	public string DoYouWanttoDeleteFile = _0019(107385507);

	public string FileisLoading = _0019(107385470);

	public string FileisLoaded = _0019(107385481);

	public string YourLevelNotEnoughtThisOperation = _0019(107385460);

	public string DoYouWanttoClearAll = _0019(107385375);

	public string PasswordError = _0019(107385338);

	public string DoYouWanttoRemove = _0019(107385829);

	public string DoYouWanttoRemoveAll = _0019(107385832);

	public string GCodeLineNumberHigherthenMaxLimit = _0019(107385763);

	public string ExitFromPRogram = _0019(107385738);

	public string ValueIncorrectFormat = _0019(107385713);

	public string DoYouWanttoDelete = _0019(107385680);

	public string DoYouWanttoUpdate = _0019(107385651);

	public string ThisToolExist = _0019(107385590);

	public string YouCantChangeParameterBeforeLoad = _0019(107385057);

	public string NoSelectedEntities = _0019(107385036);

	public string DoYouWanttoRemoveTool = _0019(107385007);

	public string DoYouWanttoUpdateTool = _0019(107384970);

	public string NoSelectedPoint = _0019(107384901);

	public string DoyouWanttoSavetoFile = _0019(107384908);

	public string DoYouWanttoClearList = _0019(107384871);

	public string DoYouWanttoSaveList = _0019(107385314);

	public string DoYouWanttoRemoveAllEx = _0019(107385281);

	public string DoYouWanttoRemoveEx = _0019(107385829);

	public string XAxisValueGreatThanLimitDoYouWanttoContinue = _0019(107385244);

	public string XAxisValueLowerThanLimitDoYouWanttoContinue = _0019(107385203);

	public string YAxisValueGreatThanLimitDoYouWanttoContinue = _0019(107385130);

	public string YAxisValueLowerThanLimitDoYouWanttoContinue = _0019(107384513);

	public string DoYouWanttoStartFromMiddlePoint = _0019(107384440);

	public string ThereisAnotherOperationforThisIDDoYouWanttoRemoveThem = _0019(107384387);

	public string NoDefinedIPAddressforController = _0019(107384330);

	public string AxisValueisHigherThanLimit = _0019(107384761);

	public string AxisValueisLowerThanLimit = _0019(107384748);

	public string DoYouWanttoClearTable = _0019(107384675);

	public string DoYouWanttoDeleteItem = _0019(107384638);

	public string DoYouWanttoAddItem = _0019(107384601);

	public string FileZMinValueLowerThanMachineMinValue = _0019(107384568);

	public string FileAMinValueLowerThanMachineMinValue = _0019(107383995);

	public string FileZMaxValueGreaterThanMachineMinValue = _0019(107383934);

	public string FileAMaxValueGreaterThanMachineMinValue = _0019(107383869);

	public string FileBMinValueLowerThanMachineMinValue = _0019(107383804);

	public string FileCMinValueLowerThanMachineMinValue = _0019(107384255);

	public string FileBMaxValueGreaterThanMachineMinValue = _0019(107384194);

	public string FileCMaxValueGreaterThanMachineMinValue = _0019(107384129);

	public string DoYouWanttoMakeThisOperation = _0019(107384064);

	public string YouMustSelectPattern = _0019(107383535);

	public string YouMustSelectSingleBlock = _0019(107383502);

	public string ReportHasBeenSentSuccesful = _0019(107383429);

	public string ReportSendError = _0019(107383388);

	public string ReportHasBeenCreated = _0019(107383363);

	public string DoyouwanttoGoParkposition = _0019(107383330);

	public string DoyouwanttoGoServiceposition = _0019(107383317);

	public string DoyouwanttoGoDefinedposition = _0019(107383748);

	public string DoyouwanttoShowLimits = _0019(107383731);

	public string DoyouwanttoMakeHoming = _0019(107383694);

	public string FileisNotAvailable = _0019(107383657);

	public string ParameterValueIncorrectFormat = _0019(107383628);

	public string ToolValueIncorrectFormat = _0019(107383551);

	public string WrongToolNumber = _0019(107383002);

	public string ItisAlreadyInchSystemDoYouWanttoContinue = _0019(107382977);

	public string ItisAlreadymmSystemDoYouWanttoContinue = _0019(107382908);

	public string NoFileLoaded = _0019(107382843);

	[NonSerialized]
	internal static GetString _0019;

	static buMotionMessageLang()
	{
		Strings.CreateGetStringDelegate(typeof(buMotionMessageLang));
	}
}
