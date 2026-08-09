using buEyeBaseVer5.buEntities;

namespace buEyeBaseVer5.Variables;

public class clsVar5
{
	public static buShape lastShape = null;

	public static buShape lastCut = null;

	public static buShape lastDrill = null;

	public static buShape lastProfiling = null;

	public static buShape lastEngrave = null;

	public static buShape lastJunction = null;

	public static ShapeSettingData ShapeSettingsParameters = new ShapeSettingData();

	public static ShapeRuntimeData ShapeDataParameters = new ShapeRuntimeData();

	public static ShapeTempData ShapeTempPar = new ShapeTempData();

	public static ShapeCreateParameters shapeCreatePar = new ShapeCreateParameters();

	public static buShapeVisualition VarbuShapeVisilation = new buShapeVisualition();

	public static MachineSimulation SimVars = new MachineSimulation();
}
