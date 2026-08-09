using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleMenuType : buSerilization5
{
	public MarbleToolType selectedTool = MarbleToolType.Saw;

	public CamWireFrameType selectedWireframeType = CamWireFrameType.Contour;

	public CamWireFrameType selectedWireframeType2 = CamWireFrameType.None;

	public CamTriangularMeshType selectedMeshType = CamTriangularMeshType.Rough;

	public CamTriangularMeshType selectedMeshType2 = CamTriangularMeshType.ParallelCuts;

	public CamTriangularMeshType selectedMesh5AxisType = CamTriangularMeshType.Rough;

	public CamTriangularMeshType selectedMesh5AxisType2 = CamTriangularMeshType.ParallelCuts;

	public MarbleSawCamType selectedSawCamType = MarbleSawCamType.Contour;

	public MarbleWaterJetCamType selectedWaterJetCamType = MarbleWaterJetCamType.Contour;

	public MarbleCamType selectedCamType = MarbleCamType.None;

	public ObjectAlignment objectAlignment = ObjectAlignment.BottomLeft;

	public bool InsideMilling = false;

	public int AxesNumber = 3;

	public bool MirrorX = false;

	public bool MirrorY = false;

	public bool Rotate90Plus = false;

	public bool Rotate180Plus = false;

	public bool Rotate90Minus = false;

	public bool Rotate180Minus = false;

	public marbleMenuType()
	{
	}

	public marbleMenuType(marbleMenuType data)
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

	public override string ToString()
	{
		return "Tool: " + selectedTool.ToString() + " - Wireframe Type: " + selectedWireframeType.ToString() + " - Mesh Cam: " + selectedMeshType.ToString() + " - Saw Cam: " + selectedSawCamType.ToString() + " - WaterJet Cam: " + selectedWaterJetCamType;
	}
}
