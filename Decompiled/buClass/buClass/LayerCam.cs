using System;
using System.Collections.Generic;

namespace buClass;

[Serializable]
public class LayerCam : buSerilization
{
	public double OperationHeight = 0.0;

	public ToolBase CamTool = new ToolBase();

	public List<camBase> Cams = new List<camBase>();

	public static List<string> Captions = new List<string>();

	public LayerCam()
	{
	}

	public LayerCam(LayerCam cam)
	{
		OperationHeight = cam.OperationHeight;
		CamTool = new ToolBase(cam.CamTool);
		Cams.Clear();
		for (int i = 0; i <= cam.Cams.Count - 1; i++)
		{
			camBase copiedCam = new camBase();
			camBase.CopyCam(cam.Cams[i], ref copiedCam);
			Cams.Add(copiedCam);
		}
	}

	public override string ToString()
	{
		return "Height : " + OperationHeight + " -  Tool : " + CamTool.Data.No;
	}
}
