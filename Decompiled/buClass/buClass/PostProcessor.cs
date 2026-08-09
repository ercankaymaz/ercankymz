using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class PostProcessor : buSerilization
{
	public CharDefinitions XDef = new CharDefinitions("X", 3, 1.0, 0, 1);

	public CharDefinitions X2Def = new CharDefinitions("X", 3, 1.0, 0, 1);

	public CharDefinitions X3Def = new CharDefinitions("X", 3, 1.0, 0, 1);

	public CharDefinitions X4Def = new CharDefinitions("X", 3, 1.0, 0, 1);

	public CharDefinitions YDef = new CharDefinitions("Y", 3, 1.0, 0, 1);

	public CharDefinitions Y2Def = new CharDefinitions("Y", 3, 1.0, 0, 1);

	public CharDefinitions Y3Def = new CharDefinitions("Y", 3, 1.0, 0, 1);

	public CharDefinitions Y4Def = new CharDefinitions("Y", 3, 1.0, 0, 1);

	public CharDefinitions ZDef = new CharDefinitions("Z", 3, 1.0, 0, 1);

	public CharDefinitions Z2Def = new CharDefinitions("W", 3, 1.0, 0, 1);

	public CharDefinitions Z3Def = new CharDefinitions("Z", 3, 1.0, 0, 1);

	public CharDefinitions Z4Def = new CharDefinitions("Z", 3, 1.0, 0, 1);

	public CharDefinitions ADef = new CharDefinitions("A", 3, 1.0, 0, 1);

	public CharDefinitions BDef = new CharDefinitions("B", 3, 1.0, 0, 1);

	public CharDefinitions CDef = new CharDefinitions("C", 3, 1.0, 0, 1);

	public CharDefinitions UDef = new CharDefinitions("U", 3, 1.0, 0, 1);

	public CharDefinitions VDef = new CharDefinitions("V", 3, 1.0, 0, 1);

	public CharDefinitions WDef = new CharDefinitions("W", 3, 1.0, 0, 1);

	public CharDefinitions NDef = new CharDefinitions("N", 0, 1.0, 0, 1);

	public CharDefinitions SDef = new CharDefinitions("S", 0, 1.0, 0, 1);

	public CharDefinitions FDef = new CharDefinitions("F", 0, 1.0, 0, 1);

	public CharDefinitions RDef = new CharDefinitions("R", 3, 1.0, 0, 1);

	public CharDefinitions IDef = new CharDefinitions("I", 3, 1.0, 0, 1);

	public CharDefinitions JDef = new CharDefinitions("J", 3, 1.0, 0, 1);

	public CharDefinitions KDef = new CharDefinitions("K", 3, 1.0, 0, 1);

	public CharDefinitions MDef = new CharDefinitions("M", 0, 1.0, 0, 1);

	public CharDefinitions GDef = new CharDefinitions("G", 0, 1.0, 0, 1);

	public CharDefinitions TDef = new CharDefinitions("T", 0, 1.0, 0, 1);

	public CharDefinitions G0Def = new CharDefinitions("G0", 0, 1.0, 0, 1);

	public CharDefinitions G1Def = new CharDefinitions("G1", 0, 1.0, 0, 1);

	public CharDefinitions G2Def = new CharDefinitions("G2", 0, 1.0, 0, 1);

	public CharDefinitions G3Def = new CharDefinitions("G3", 0, 1.0, 0, 1);

	public CharDefinitions G40Def = new CharDefinitions("G40", 0, 1.0, 0, 1);

	public CharDefinitions G41Def = new CharDefinitions("G41", 0, 1.0, 0, 1);

	public CharDefinitions G42Def = new CharDefinitions("G42", 0, 1.0, 0, 1);

	public CharDefinitions G53Def = new CharDefinitions("G53", 0, 1.0, 0, 1);

	public CharDefinitions G54Def = new CharDefinitions("G54", 0, 1.0, 0, 1);

	public CharDefinitions G55Def = new CharDefinitions("G55", 0, 1.0, 0, 1);

	public CharDefinitions G56Def = new CharDefinitions("G56", 0, 1.0, 0, 1);

	public Numbering NumberDef = new Numbering(1.0, 1.0, -1.0, enable: true);

	public ToolPost ToolDef = new ToolPost();

	public ToolPost ToolNextDef = new ToolPost();

	public ToolPost Tool1 = new ToolPost();

	public ToolPost Tool2 = new ToolPost();

	public ToolPost Tool3 = new ToolPost();

	public ToolPost Tool4 = new ToolPost();

	public ToolPost Tool5 = new ToolPost();

	public SpindlePost SpindleDef = new SpindlePost(usespindle: false, spindleattoolline: false, "M3", "M4", "M5");

	public postRegionMode Region1 = new postRegionMode();

	public postRegionMode Region2 = new postRegionMode();

	public postRegionMode Region3 = new postRegionMode();

	public postRegionMode Region4 = new postRegionMode();

	public postRegionMode Region5 = new postRegionMode();

	public postRegionMode Region6 = new postRegionMode();

	public postRegionMode Region7 = new postRegionMode();

	public postRegionMode Region8 = new postRegionMode();

	public PositionPost PositionDef = new PositionPost(PositionPostType.G90);

	public CircularPost CircularDef = new CircularPost(CircularPostType.Arc, 0.1);

	public CodeRepetition RepetitionDef = new CodeRepetition(coordinate: false, feed: false, tool: false, command: false);

	public AxesEnableWithUVW AxesUsing = new AxesEnableWithUVW(x: true, y: true, z: true);

	public EntitySortMode EntitySort = new EntitySortMode();

	public PostCamProperties PostCamProps = new PostCamProperties();

	public ToolPageVisible ToolPageVisiblity = new ToolPageVisible();

	public CamPageTabs CamPageTab = new CamPageTabs();

	public ArrayList CamPageDistance = new ArrayList();

	public ArrayList CamPageVelocity = new ArrayList();

	public ArrayList CamPageStep = new ArrayList();

	public ArrayList CamPageOperation = new ArrayList();

	public ArrayList CamPageOffset = new ArrayList();

	public ArrayList CamPageLeadIn = new ArrayList();

	public ArrayList CamPageLeadOut = new ArrayList();

	public ArrayList CamPageTools = new ArrayList();

	public ArrayList CamPageMisc = new ArrayList();

	public PatternActions EnterToPattern = new PatternActions(air: false, safe: true, moveg53: false, moveupincremental: false, moveonestepup: false, movefirstpoint: false);

	public PatternActions LeaveFromPattern = new PatternActions(air: false, safe: true, moveg53: false, moveupincremental: false, moveonestepup: false, movefirstpoint: false);

	public PatternActions PatternStepToStep = new PatternActions(air: false, safe: true, moveg53: false, moveupincremental: false, moveonestepup: false, movefirstpoint: false);

	public PatternActions PatternBlockToBlock = new PatternActions(air: false, safe: true, moveg53: false, moveupincremental: false, moveonestepup: false, movefirstpoint: false);

	public G0Properties G0Propery = new G0Properties(usefeed: false, useallchar: false);

	public G1Properties G1Propery = new G1Properties();

	public G2Properties G2Propery = new G2Properties();

	public G3Properties G3Propery = new G3Properties();

	public G1G2G3Properties G1G2G3Propery = new G1G2G3Properties();

	public AxesEnableWithUVW MotionAxesEnable = new AxesEnableWithUVW(x: true, y: true, z: true);

	public bool RemoveSafeDistanceIfNoIntersection = false;

	public bool UseToolHeightOffsetAfterZMove = false;

	public bool UseFCode = true;

	public bool UseG41G42 = false;

	public bool IsArcAsLine = false;

	public string FileExtension = "*.cnc";

	public string FileExplanation = "buCad/Cam Common Generic Post";

	public string Name = "Basic BuCad/Cam Post Processor";

	public string FileName = "";

	public string CommentChar = "( ";

	public string LineEndChar = "";

	public string SeparatorCharForAxis = "";

	public string Mode = "";

	public bool Inited = false;

	public bool WaterJet5Axis = false;

	public bool PreCoordinateClearAfterCodes = true;

	public ArrayList InhibitedMCodes = new ArrayList();

	public ArrayList StartLines = new ArrayList();

	public ArrayList EndLines = new ArrayList();

	public ArrayList StartLinesFirstTable = new ArrayList();

	public ArrayList EndLinesFirstTable = new ArrayList();

	public ArrayList StartLinesSecondTable = new ArrayList();

	public ArrayList EndLinesSecondTable = new ArrayList();

	public ArrayList StartLinesFirstThenSecondTable = new ArrayList();

	public ArrayList EndLinesFirstThenSecondTable = new ArrayList();

	public ArrayList StartLinesBothTable = new ArrayList();

	public ArrayList EndLinesBothTable = new ArrayList();

	public ArrayList StartLinesWithoutProcess = new ArrayList();

	public ArrayList EndLinesWithoutProcess = new ArrayList();

	public ArrayList FirstPlungePreCodes = new ArrayList();

	public ArrayList FirstPlungeAfterCodes = new ArrayList();

	public ArrayList LastLeavePreCodes = new ArrayList();

	public ArrayList LastLeaveAfterCodes = new ArrayList();

	public ArrayList StartLinesEachBlock = new ArrayList();

	public ArrayList EndLinesEachBlock = new ArrayList();

	public ArrayList JewellaryPocket3AXPreCodes = new ArrayList();

	public ArrayList JewellaryPocket3AXAfterCodes = new ArrayList();

	public ArrayList JewellaryContour3AXPreCodes = new ArrayList();

	public ArrayList JewellaryContour3AXAfterCodes = new ArrayList();

	public ArrayList JewellaryContour4AXPreCodes = new ArrayList();

	public ArrayList JewellaryContour4AXAfterCodes = new ArrayList();

	public ArrayList JewellarySpinConstant3AXPreCodes = new ArrayList();

	public ArrayList JewellarySpinConstant3AXAfterCodes = new ArrayList();

	public ArrayList JewellaryTriangleMesh3AXPreCodes = new ArrayList();

	public ArrayList JewellaryTriangleMesh3AXAfterCodes = new ArrayList();

	public ArrayList JewellaryDrill3AXPreCodes = new ArrayList();

	public ArrayList JewellaryDrill3AXAfterCodes = new ArrayList();

	public ArrayList JewellaryDrill4AXPreCodes = new ArrayList();

	public ArrayList JewellaryDrill4AXAfterCodes = new ArrayList();

	public ArrayList Pocket3AXPreCodes = new ArrayList();

	public ArrayList Pocket3AXAfterCodes = new ArrayList();

	public ArrayList Contour3AXPreCodes = new ArrayList();

	public ArrayList Contour3AXAfterCodes = new ArrayList();

	public ArrayList Contour4AXPreCodes = new ArrayList();

	public ArrayList Contour4AXAfterCodes = new ArrayList();

	public ArrayList SpinConstant3AXPreCodes = new ArrayList();

	public ArrayList SpinConstant3AXAfterCodes = new ArrayList();

	public ArrayList TriangleMesh3AXPreCodes = new ArrayList();

	public ArrayList TriangleMesh3AXAfterCodes = new ArrayList();

	public ArrayList Drill3AXPreCodes = new ArrayList();

	public ArrayList Drill3AXAfterCodes = new ArrayList();

	public ArrayList Drill4AXPreCodes = new ArrayList();

	public ArrayList Drill4AXAfterCodes = new ArrayList();

	public List<PostVariable> PostVariables = new List<PostVariable>();

	public PostProcessor()
	{
	}

	public PostProcessor(PostProcessor data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
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
		PostVariables = new List<PostVariable>();
		for (int j = 0; j <= data.PostVariables.Count - 1; j++)
		{
			PostVariable item = new PostVariable(data.PostVariables[j]);
			PostVariables.Add(item);
		}
		AxesUsing = new AxesEnableWithUVW(data.AxesUsing);
		ToolDef = new ToolPost(data.ToolDef);
		SpindleDef = new SpindlePost(data.SpindleDef);
		EntitySort = new EntitySortMode(data.EntitySort);
		PostCamProps = new PostCamProperties(data.PostCamProps);
		CamPageTab = new CamPageTabs(data.CamPageTab);
		Region1 = new postRegionMode(data.Region1);
		Region2 = new postRegionMode(data.Region2);
		Region3 = new postRegionMode(data.Region3);
		Region4 = new postRegionMode(data.Region4);
		Region5 = new postRegionMode(data.Region5);
		Region6 = new postRegionMode(data.Region6);
		Region7 = new postRegionMode(data.Region7);
		Region8 = new postRegionMode(data.Region8);
		MotionAxesEnable = new AxesEnableWithUVW(data.MotionAxesEnable);
		PostVariables = new List<PostVariable>();
		for (int k = 0; k <= data.PostVariables.Count - 1; k++)
		{
			PostVariables.Add(data.PostVariables[k]);
		}
	}

	public override string ToString()
	{
		return Name;
	}
}
