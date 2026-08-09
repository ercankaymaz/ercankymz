using System;
using System.Collections;
using System.Collections.Generic;

namespace buClass;

[Serializable]
public class CamPoint : buSerilization
{
	public ArrayList PreCodes = new ArrayList();

	public ArrayList AfterCodes = new ArrayList();

	public List<Pnt9DCam> Points = new List<Pnt9DCam>();

	public List<Pnt3D> PointsNoRTCP = new List<Pnt3D>();

	public Simulation SimilationPoint = new Simulation();

	public List<geoEntity> EntitiesMark = new List<geoEntity>();

	public List<geoEntity> EntitiesG1 = new List<geoEntity>();

	public List<geoEntity> EntitiesG0 = new List<geoEntity>();

	public List<geoEntity> EntitiesPlunge = new List<geoEntity>();

	public List<geoEntity> EntitiesLeave = new List<geoEntity>();

	public List<geoEntity> EntitiesOther = new List<geoEntity>();

	public List<geoEntity> EntitiesLeadIn = new List<geoEntity>();

	public List<geoEntity> EntitiesLeadOut = new List<geoEntity>();

	public List<int> EntityIndex = new List<int>();

	public List<DirectionArrow> DirectionArrows = new List<DirectionArrow>();

	public Pnt9D GCodeOffset = new Pnt9D();

	public int Type = 0;

	public int NumberOfPlungeMovement = 0;

	public int NumberOfLeaveMovement = 0;

	public double Feed = 100.0;

	public bool ForceWriteAllCoordinate = false;

	public bool IsRapid = false;

	public bool FastMoveByG1 = false;

	public string GoSafeAxis = "";

	public string Command = "";

	public int Mode = 0;

	public CamPoint()
	{
	}

	public CamPoint(CamPoint campoint)
	{
		Mode = campoint.Mode;
		Feed = campoint.Feed;
		Type = campoint.Type;
		IsRapid = campoint.IsRapid;
		ForceWriteAllCoordinate = campoint.ForceWriteAllCoordinate;
		Command = campoint.Command;
		GoSafeAxis = campoint.GoSafeAxis;
		FastMoveByG1 = campoint.FastMoveByG1;
		GCodeOffset = new Pnt9D(campoint.GCodeOffset);
		Points = new List<Pnt9DCam>();
		for (int i = 0; i <= campoint.Points.Count - 1; i++)
		{
			Points.Add(new Pnt9DCam(campoint.Points[i]));
		}
		PointsNoRTCP = new List<Pnt3D>();
		for (int j = 0; j <= campoint.PointsNoRTCP.Count - 1; j++)
		{
			PointsNoRTCP.Add(new Pnt3D(campoint.PointsNoRTCP[j]));
		}
		SimilationPoint = new Simulation(new Simulation(campoint.SimilationPoint));
		PreCodes = new ArrayList();
		for (int k = 0; k <= campoint.PreCodes.Count - 1; k++)
		{
			PreCodes.Add(campoint.PreCodes[k]);
		}
		AfterCodes = new ArrayList();
		for (int l = 0; l <= campoint.AfterCodes.Count - 1; l++)
		{
			AfterCodes.Add(campoint.AfterCodes[l]);
		}
		DirectionArrows = new List<DirectionArrow>();
		for (int m = 0; m <= campoint.DirectionArrows.Count - 1; m++)
		{
			DirectionArrow item = new DirectionArrow(campoint.DirectionArrows[m]);
			DirectionArrows.Add(item);
		}
		EntityIndex = new List<int>();
		for (int n = 0; n <= campoint.EntityIndex.Count - 1; n++)
		{
			EntityIndex.Add(campoint.EntityIndex[n]);
		}
		EntitiesG1 = new List<geoEntity>();
		for (int num = 0; num <= campoint.EntitiesG1.Count - 1; num++)
		{
			geoEntity CopiedTo = new geoEntity();
			geoEntity.Copy(campoint.EntitiesG1[num], ref CopiedTo);
			EntitiesG1.Add(CopiedTo);
		}
		EntitiesOther = new List<geoEntity>();
		for (int num2 = 0; num2 <= campoint.EntitiesOther.Count - 1; num2++)
		{
			geoEntity CopiedTo2 = new geoEntity();
			geoEntity.Copy(campoint.EntitiesOther[num2], ref CopiedTo2);
			EntitiesOther.Add(CopiedTo2);
		}
		EntitiesMark = new List<geoEntity>();
		for (int num3 = 0; num3 <= campoint.EntitiesMark.Count - 1; num3++)
		{
			geoEntity CopiedTo3 = new geoEntity();
			geoEntity.Copy(campoint.EntitiesMark[num3], ref CopiedTo3);
			EntitiesMark.Add(CopiedTo3);
		}
		EntitiesG0 = new List<geoEntity>();
		for (int num4 = 0; num4 <= campoint.EntitiesG0.Count - 1; num4++)
		{
			geoEntity CopiedTo4 = new geoEntity();
			geoEntity.Copy(campoint.EntitiesG0[num4], ref CopiedTo4);
			EntitiesG0.Add(CopiedTo4);
		}
		EntitiesLeadIn = new List<geoEntity>();
		for (int num5 = 0; num5 <= campoint.EntitiesLeadIn.Count - 1; num5++)
		{
			geoEntity CopiedTo5 = new geoEntity();
			geoEntity.Copy(campoint.EntitiesLeadIn[num5], ref CopiedTo5);
			EntitiesLeadIn.Add(CopiedTo5);
		}
		EntitiesLeadOut = new List<geoEntity>();
		for (int num6 = 0; num6 <= campoint.EntitiesLeadOut.Count - 1; num6++)
		{
			geoEntity CopiedTo6 = new geoEntity();
			geoEntity.Copy(campoint.EntitiesLeadOut[num6], ref CopiedTo6);
			EntitiesLeadOut.Add(CopiedTo6);
		}
		EntitiesPlunge = new List<geoEntity>();
		for (int num7 = 0; num7 <= campoint.EntitiesPlunge.Count - 1; num7++)
		{
			geoEntity CopiedTo7 = new geoEntity();
			geoEntity.Copy(campoint.EntitiesPlunge[num7], ref CopiedTo7);
			EntitiesPlunge.Add(CopiedTo7);
		}
		EntitiesLeave = new List<geoEntity>();
		for (int num8 = 0; num8 <= campoint.EntitiesLeave.Count - 1; num8++)
		{
			geoEntity CopiedTo8 = new geoEntity();
			geoEntity.Copy(campoint.EntitiesLeave[num8], ref CopiedTo8);
			EntitiesLeave.Add(CopiedTo8);
		}
	}

	public override string ToString()
	{
		string text = "";
		if (Points.Count > 0)
		{
			text = " - X: " + Points[0].P9.X.ToString("f3") + " , Y: " + Points[0].P9.Y.ToString("f3") + " , Z: " + Points[0].P9.Z.ToString("f3");
			if (Points[0].P9.A != 0.0)
			{
				text = text + " - A: " + Points[0].P9.A.ToString("f3");
			}
			if (Points[0].P9.B != 0.0)
			{
				text = text + " - B: " + Points[0].P9.B.ToString("f3");
			}
			if (Points[0].P9.C != 0.0)
			{
				text = text + " - C: " + Points[0].P9.C.ToString("f3");
			}
		}
		return "Cnt: " + Points.Count + " , Type: " + Type + " , Feed: " + Feed + text;
	}
}
