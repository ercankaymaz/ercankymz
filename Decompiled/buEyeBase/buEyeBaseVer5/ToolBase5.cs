using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class ToolBase5 : buSerilization5
{
	public ToolData5 Data = new ToolData5();

	public ToolGeometry5 Geometry = new ToolGeometry5();

	public ToolCamData5 CamData = new ToolCamData5();

	public ToolDisplay5 Display = new ToolDisplay5();

	public ToolPositions5 Positions = new ToolPositions5();

	public ToolLimits5 Limits = new ToolLimits5();

	public ToolPurpose Purpose = ToolPurpose.General;

	public ArrayList Aux = new ArrayList();

	public ArrayList ToolPre = new ArrayList();

	public ArrayList ToolNext = new ArrayList();

	public ArrayList SpindlePre = new ArrayList();

	public ArrayList SpindleNext = new ArrayList();

	public static List<string> Captions = new List<string>();

	public ToolBase5()
	{
	}

	public ToolBase5(ToolBase5 tool)
	{
		if (tool != null)
		{
			Data = new ToolData5(tool.Data);
			Geometry = new ToolGeometry5(tool.Geometry);
			CamData = new ToolCamData5(tool.CamData);
			Positions = new ToolPositions5(tool.Positions);
			Display = new ToolDisplay5(tool.Display);
			Limits = new ToolLimits5(tool.Limits);
			Purpose = tool.Purpose;
			Aux = new ArrayList();
			for (int i = 0; i <= tool.Aux.Count - 1; i++)
			{
				Aux.Add(tool.Aux[i]);
			}
			ToolPre = new ArrayList();
			for (int j = 0; j <= tool.ToolPre.Count - 1; j++)
			{
				ToolPre.Add(tool.ToolPre[j]);
			}
			ToolNext = new ArrayList();
			for (int k = 0; k <= tool.ToolNext.Count - 1; k++)
			{
				ToolNext.Add(tool.ToolNext[k]);
			}
			SpindlePre = new ArrayList();
			for (int l = 0; l <= tool.SpindlePre.Count - 1; l++)
			{
				SpindlePre.Add(tool.SpindlePre[l]);
			}
			SpindleNext = new ArrayList();
			for (int m = 0; m <= tool.SpindleNext.Count - 1; m++)
			{
				SpindleNext.Add(tool.SpindleNext[m]);
			}
		}
	}

	public ToolBase5(ToolBase tool)
	{
		Data = new ToolData5(tool.Data);
		Geometry = new ToolGeometry5(tool.Geometry);
		CamData = new ToolCamData5(tool.CamData);
		Positions = new ToolPositions5(tool.Positions);
		Display = new ToolDisplay5(tool.Display);
		Limits = new ToolLimits5(tool.Limits);
		Purpose = tool.Purpose;
		Aux = new ArrayList();
		for (int i = 0; i <= tool.Aux.Count - 1; i++)
		{
			Aux.Add(tool.Aux[i]);
		}
	}

	public static void MmToInch(ref List<ToolBase5> Tools)
	{
		for (int i = 0; i <= Tools.Count - 1; i++)
		{
			Tools[i].MmToInch();
		}
	}

	public static void InchToMm(ref List<ToolBase5> Tools)
	{
		for (int i = 0; i <= Tools.Count - 1; i++)
		{
			Tools[i].InchToMm();
		}
	}

	public static void SaveToolHolder(ToolBase5 Tool, string FileName)
	{
		List<string> list = new List<string>();
		list.Add("<ToolHolder>");
		if (Tool.Geometry.HolderPoints.Count > 0)
		{
			for (int i = 0; i <= Tool.Geometry.HolderPoints.Count - 1; i++)
			{
				list.Add("  " + Tool.Geometry.HolderPoints[i].ToDef());
			}
		}
		list.Add("</ToolHolder>");
		list.Add("<ToolArbor>");
		if (Tool.Geometry.ArborPoints.Count > 0)
		{
			for (int j = 0; j <= Tool.Geometry.ArborPoints.Count - 1; j++)
			{
				list.Add("  " + Tool.Geometry.ArborPoints[j].ToDef());
			}
		}
		list.Add("</ToolArbor>");
		if (FileName.Length >= 2)
		{
			buFile5.SaveToFile(list, FileName);
		}
		list.Clear();
	}

	public static void OpenToolHolder(ref ToolBase5 Tool, string FileName)
	{
		if (FileName.Length < 2)
		{
			return;
		}
		FileInfo fileInfo = new FileInfo(FileName);
		if (fileInfo.Exists)
		{
			List<string> StringList = new List<string>();
			List<string> CalcList = new List<string>();
			buFile5.OpenFromFile(FileName, ref StringList);
			Tool.Geometry.HolderPoints.Clear();
			Tool.Geometry.ArborPoints.Clear();
			buString5.ListToSpecificList("<ToolHolder>", "</ToolHolder>", AddStartEndKey: false, StringList, ref CalcList);
			for (int i = 0; i <= CalcList.Count - 1; i++)
			{
				Tool.Geometry.HolderPoints.Add(Pnt3D.DecodeFromString(CalcList[i]));
			}
			CalcList.Clear();
			buString5.ListToSpecificList("<ToolArbor>", "</ToolArbor>", AddStartEndKey: false, StringList, ref CalcList);
			for (int j = 0; j <= CalcList.Count - 1; j++)
			{
				Tool.Geometry.ArborPoints.Add(Pnt3D.DecodeFromString(CalcList[j]));
			}
			CalcList.Clear();
			StringList.Clear();
		}
	}

	public void MmToInch()
	{
		Geometry.Diameter = Math.Round(Geometry.Diameter * buSystem.MmToInchRatio, 5);
		Geometry.DiameterLeft = Math.Round(Geometry.DiameterLeft * buSystem.MmToInchRatio, 5);
		Geometry.DiameterRight = Math.Round(Geometry.DiameterRight * buSystem.MmToInchRatio, 5);
		Geometry.DiameterBody = Math.Round(Geometry.DiameterBody * buSystem.MmToInchRatio, 5);
		Geometry.ShoulderDiameter = Math.Round(Geometry.ShoulderDiameter * buSystem.MmToInchRatio, 5);
		Geometry.ShoulderLength = Math.Round(Geometry.ShoulderLength * buSystem.MmToInchRatio, 5);
		Geometry.BottomDiameter = Math.Round(Geometry.BottomDiameter * buSystem.MmToInchRatio, 5);
		Geometry.TopDiameter = Math.Round(Geometry.TopDiameter * buSystem.MmToInchRatio, 5);
		Geometry.RoundRadius = Math.Round(Geometry.RoundRadius * buSystem.MmToInchRatio, 5);
		Geometry.Length = Math.Round(Geometry.Length * buSystem.MmToInchRatio, 5);
		Geometry.LengthLeft = Math.Round(Geometry.LengthLeft * buSystem.MmToInchRatio, 5);
		Geometry.LengthRigth = Math.Round(Geometry.LengthRigth * buSystem.MmToInchRatio, 5);
		Geometry.LengthDiameter = Math.Round(Geometry.LengthDiameter * buSystem.MmToInchRatio, 5);
		Geometry.CutLength = Math.Round(Geometry.CutLength * buSystem.MmToInchRatio, 5);
		Geometry.CutLengthLeft = Math.Round(Geometry.CutLengthLeft * buSystem.MmToInchRatio, 5);
		Geometry.CutLengthRight = Math.Round(Geometry.CutLengthRight * buSystem.MmToInchRatio, 5);
		Geometry.ArborLength = Math.Round(Geometry.ArborLength * buSystem.MmToInchRatio, 5);
		Geometry.ArborTopDiameter = Math.Round(Geometry.ArborTopDiameter * buSystem.MmToInchRatio, 5);
		Geometry.ArborBottomDiameter = Math.Round(Geometry.ArborBottomDiameter * buSystem.MmToInchRatio, 5);
		Geometry.HolderLength = Math.Round(Geometry.HolderLength * buSystem.MmToInchRatio, 5);
		Geometry.HolderDiameter = Math.Round(Geometry.HolderDiameter * buSystem.MmToInchRatio, 5);
		Geometry.HolderInDiameter = Math.Round(Geometry.HolderInDiameter * buSystem.MmToInchRatio, 5);
		Geometry.LowerRadius = Math.Round(Geometry.LowerRadius * buSystem.MmToInchRatio, 5);
		Geometry.UpperRadius = Math.Round(Geometry.UpperRadius * buSystem.MmToInchRatio, 5);
		Geometry.UpperDiameter = Math.Round(Geometry.UpperDiameter * buSystem.MmToInchRatio, 5);
		Geometry.ProfileRadius = Math.Round(Geometry.ProfileRadius * buSystem.MmToInchRatio, 5);
		Geometry.OutsideDiameter = Math.Round(Geometry.OutsideDiameter * buSystem.MmToInchRatio, 5);
		Geometry.ProfileDiameter = Math.Round(Geometry.ProfileDiameter * buSystem.MmToInchRatio, 5);
		Geometry.MaxDiameter = Math.Round(Geometry.MaxDiameter * buSystem.MmToInchRatio, 5);
		Geometry.FlatnessDiameter = Math.Round(Geometry.FlatnessDiameter * buSystem.MmToInchRatio, 5);
		Geometry.ConvexTipRadius = Math.Round(Geometry.ConvexTipRadius * buSystem.MmToInchRatio, 5);
		Geometry.Thickness = Math.Round(Geometry.Thickness * buSystem.MmToInchRatio, 5);
		Geometry.MinLength = Math.Round(Geometry.MinLength * buSystem.MmToInchRatio, 5);
		Geometry.SizeWidth = Math.Round(Geometry.SizeWidth * buSystem.MmToInchRatio, 5);
		Geometry.SizeDepth = Math.Round(Geometry.SizeDepth * buSystem.MmToInchRatio, 5);
		Geometry.SizeHeight = Math.Round(Geometry.SizeHeight * buSystem.MmToInchRatio, 5);
		Geometry.AgregateVerticalLength = Math.Round(Geometry.AgregateVerticalLength * buSystem.MmToInchRatio, 5);
		Geometry.AgregateToolCenterLength = Math.Round(Geometry.AgregateToolCenterLength * buSystem.MmToInchRatio, 5);
		CamData.DepthConstant = Math.Round(CamData.DepthConstant * buSystem.MmToInchRatio, 5);
		CamData.Stepover = Math.Round(CamData.Stepover * buSystem.MmToInchRatio, 5);
		CamData.Cutover = Math.Round(CamData.Cutover * buSystem.MmToInchRatio, 5);
		CamData.OperationHeight = Math.Round(CamData.OperationHeight * buSystem.MmToInchRatio, 5);
		CamData.AreaClearanceSpeed = Math.Round(CamData.AreaClearanceSpeed * buSystem.MmToInchRatio, 5);
		CamData.FinishSpeed = Math.Round(CamData.FinishSpeed * buSystem.MmToInchRatio, 5);
		CamData.RetractSpeed = Math.Round(CamData.RetractSpeed * buSystem.MmToInchRatio, 5);
		CamData.FeedSpeed = Math.Round(CamData.FeedSpeed * buSystem.MmToInchRatio, 5);
		CamData.PlungeSpeed = Math.Round(CamData.PlungeSpeed * buSystem.MmToInchRatio, 5);
		CamData.LeaveSpeed = Math.Round(CamData.LeaveSpeed * buSystem.MmToInchRatio, 5);
		CamData.SpindleSpeed = Math.Round(CamData.SpindleSpeed * buSystem.MmToInchRatio, 5);
		CamData.OperationHeigthForSecond = Math.Round(CamData.OperationHeigthForSecond * buSystem.MmToInchRatio, 5);
		CamData.ExtraOffset = Math.Round(CamData.ExtraOffset * buSystem.MmToInchRatio, 5);
		CamData.SafeDistance = Math.Round(CamData.SafeDistance * buSystem.MmToInchRatio, 5);
		CamData.RapidDistance = Math.Round(CamData.RapidDistance * buSystem.MmToInchRatio, 5);
		Positions.CommonOffset.X = Math.Round(Positions.CommonOffset.X * buSystem.MmToInchRatio, 5);
		Positions.CommonOffset.Y = Math.Round(Positions.CommonOffset.Y * buSystem.MmToInchRatio, 5);
		Positions.CommonOffset.Z = Math.Round(Positions.CommonOffset.Z * buSystem.MmToInchRatio, 5);
		Positions.Offset.X = Math.Round(Positions.Offset.X * buSystem.MmToInchRatio, 5);
		Positions.Offset.Y = Math.Round(Positions.Offset.Y * buSystem.MmToInchRatio, 5);
		Positions.Offset.Z = Math.Round(Positions.Offset.Z * buSystem.MmToInchRatio, 5);
		Positions.Position.X = Math.Round(Positions.Position.X * buSystem.MmToInchRatio, 5);
		Positions.Position.Y = Math.Round(Positions.Position.Y * buSystem.MmToInchRatio, 5);
		Positions.Position.Z = Math.Round(Positions.Position.Z * buSystem.MmToInchRatio, 5);
		Limits.AxesMaxLimits.X = Math.Round(Limits.AxesMaxLimits.X * buSystem.MmToInchRatio, 5);
		Limits.AxesMaxLimits.Y = Math.Round(Limits.AxesMaxLimits.Y * buSystem.MmToInchRatio, 5);
		Limits.AxesMaxLimits.Z = Math.Round(Limits.AxesMaxLimits.Z * buSystem.MmToInchRatio, 5);
		Limits.AxesMinLimits.X = Math.Round(Limits.AxesMinLimits.X * buSystem.MmToInchRatio, 5);
		Limits.AxesMinLimits.Y = Math.Round(Limits.AxesMinLimits.Y * buSystem.MmToInchRatio, 5);
		Limits.AxesMinLimits.Z = Math.Round(Limits.AxesMinLimits.Z * buSystem.MmToInchRatio, 5);
	}

	public void InchToMm()
	{
		Geometry.Diameter = Math.Round(Geometry.Diameter * buSystem.InchToMmRatio, 5);
		Geometry.DiameterLeft = Math.Round(Geometry.DiameterLeft * buSystem.InchToMmRatio, 5);
		Geometry.DiameterRight = Math.Round(Geometry.DiameterRight * buSystem.InchToMmRatio, 5);
		Geometry.DiameterBody = Math.Round(Geometry.DiameterBody * buSystem.InchToMmRatio, 5);
		Geometry.ShoulderDiameter = Math.Round(Geometry.ShoulderDiameter * buSystem.InchToMmRatio, 5);
		Geometry.ShoulderLength = Math.Round(Geometry.ShoulderLength * buSystem.InchToMmRatio, 5);
		Geometry.BottomDiameter = Math.Round(Geometry.BottomDiameter * buSystem.InchToMmRatio, 5);
		Geometry.TopDiameter = Math.Round(Geometry.TopDiameter * buSystem.InchToMmRatio, 5);
		Geometry.RoundRadius = Math.Round(Geometry.RoundRadius * buSystem.InchToMmRatio, 5);
		Geometry.Length = Math.Round(Geometry.Length * buSystem.InchToMmRatio, 5);
		Geometry.LengthLeft = Math.Round(Geometry.LengthLeft * buSystem.InchToMmRatio, 5);
		Geometry.LengthRigth = Math.Round(Geometry.LengthRigth * buSystem.InchToMmRatio, 5);
		Geometry.LengthDiameter = Math.Round(Geometry.LengthDiameter * buSystem.InchToMmRatio, 5);
		Geometry.CutLength = Math.Round(Geometry.CutLength * buSystem.InchToMmRatio, 5);
		Geometry.CutLengthLeft = Math.Round(Geometry.CutLengthLeft * buSystem.InchToMmRatio, 5);
		Geometry.CutLengthRight = Math.Round(Geometry.CutLengthRight * buSystem.InchToMmRatio, 5);
		Geometry.ArborLength = Math.Round(Geometry.ArborLength * buSystem.InchToMmRatio, 5);
		Geometry.ArborTopDiameter = Math.Round(Geometry.ArborTopDiameter * buSystem.InchToMmRatio, 5);
		Geometry.ArborBottomDiameter = Math.Round(Geometry.ArborBottomDiameter * buSystem.InchToMmRatio, 5);
		Geometry.HolderLength = Math.Round(Geometry.HolderLength * buSystem.InchToMmRatio, 5);
		Geometry.HolderDiameter = Math.Round(Geometry.HolderDiameter * buSystem.InchToMmRatio, 5);
		Geometry.HolderInDiameter = Math.Round(Geometry.HolderInDiameter * buSystem.InchToMmRatio, 5);
		Geometry.LowerRadius = Math.Round(Geometry.LowerRadius * buSystem.InchToMmRatio, 5);
		Geometry.UpperRadius = Math.Round(Geometry.UpperRadius * buSystem.InchToMmRatio, 5);
		Geometry.UpperDiameter = Math.Round(Geometry.UpperDiameter * buSystem.InchToMmRatio, 5);
		Geometry.ProfileRadius = Math.Round(Geometry.ProfileRadius * buSystem.InchToMmRatio, 5);
		Geometry.OutsideDiameter = Math.Round(Geometry.OutsideDiameter * buSystem.InchToMmRatio, 5);
		Geometry.ProfileDiameter = Math.Round(Geometry.ProfileDiameter * buSystem.InchToMmRatio, 5);
		Geometry.MaxDiameter = Math.Round(Geometry.MaxDiameter * buSystem.InchToMmRatio, 5);
		Geometry.FlatnessDiameter = Math.Round(Geometry.FlatnessDiameter * buSystem.InchToMmRatio, 5);
		Geometry.ConvexTipRadius = Math.Round(Geometry.ConvexTipRadius * buSystem.InchToMmRatio, 5);
		Geometry.Thickness = Math.Round(Geometry.Thickness * buSystem.InchToMmRatio, 5);
		Geometry.MinLength = Math.Round(Geometry.MinLength * buSystem.InchToMmRatio, 5);
		Geometry.SizeWidth = Math.Round(Geometry.SizeWidth * buSystem.InchToMmRatio, 5);
		Geometry.SizeDepth = Math.Round(Geometry.SizeDepth * buSystem.InchToMmRatio, 5);
		Geometry.SizeHeight = Math.Round(Geometry.SizeHeight * buSystem.InchToMmRatio, 5);
		Geometry.AgregateVerticalLength = Math.Round(Geometry.AgregateVerticalLength * buSystem.InchToMmRatio, 5);
		Geometry.AgregateToolCenterLength = Math.Round(Geometry.AgregateToolCenterLength * buSystem.InchToMmRatio, 5);
		CamData.DepthConstant = Math.Round(CamData.DepthConstant * buSystem.InchToMmRatio, 5);
		CamData.Stepover = Math.Round(CamData.Stepover * buSystem.InchToMmRatio, 5);
		CamData.Cutover = Math.Round(CamData.Cutover * buSystem.InchToMmRatio, 5);
		CamData.OperationHeight = Math.Round(CamData.OperationHeight * buSystem.InchToMmRatio, 5);
		CamData.AreaClearanceSpeed = Math.Round(CamData.AreaClearanceSpeed * buSystem.InchToMmRatio, 5);
		CamData.FinishSpeed = Math.Round(CamData.FinishSpeed * buSystem.InchToMmRatio, 5);
		CamData.RetractSpeed = Math.Round(CamData.RetractSpeed * buSystem.InchToMmRatio, 5);
		CamData.FeedSpeed = Math.Round(CamData.FeedSpeed * buSystem.InchToMmRatio, 5);
		CamData.PlungeSpeed = Math.Round(CamData.PlungeSpeed * buSystem.InchToMmRatio, 5);
		CamData.LeaveSpeed = Math.Round(CamData.LeaveSpeed * buSystem.InchToMmRatio, 5);
		CamData.SpindleSpeed = Math.Round(CamData.SpindleSpeed * buSystem.InchToMmRatio, 5);
		CamData.OperationHeigthForSecond = Math.Round(CamData.OperationHeigthForSecond * buSystem.InchToMmRatio, 5);
		CamData.ExtraOffset = Math.Round(CamData.ExtraOffset * buSystem.InchToMmRatio, 5);
		CamData.SafeDistance = Math.Round(CamData.SafeDistance * buSystem.InchToMmRatio, 5);
		CamData.RapidDistance = Math.Round(CamData.RapidDistance * buSystem.InchToMmRatio, 5);
		Positions.CommonOffset.X = Math.Round(Positions.CommonOffset.X * buSystem.InchToMmRatio, 5);
		Positions.CommonOffset.Y = Math.Round(Positions.CommonOffset.Y * buSystem.InchToMmRatio, 5);
		Positions.CommonOffset.Z = Math.Round(Positions.CommonOffset.Z * buSystem.InchToMmRatio, 5);
		Positions.Offset.X = Math.Round(Positions.Offset.X * buSystem.InchToMmRatio, 5);
		Positions.Offset.Y = Math.Round(Positions.Offset.Y * buSystem.InchToMmRatio, 5);
		Positions.Offset.Z = Math.Round(Positions.Offset.Z * buSystem.InchToMmRatio, 5);
		Positions.Position.X = Math.Round(Positions.Position.X * buSystem.InchToMmRatio, 5);
		Positions.Position.Y = Math.Round(Positions.Position.Y * buSystem.InchToMmRatio, 5);
		Positions.Position.Z = Math.Round(Positions.Position.Z * buSystem.InchToMmRatio, 5);
		Limits.AxesMaxLimits.X = Math.Round(Limits.AxesMaxLimits.X * buSystem.InchToMmRatio, 5);
		Limits.AxesMaxLimits.Y = Math.Round(Limits.AxesMaxLimits.Y * buSystem.InchToMmRatio, 5);
		Limits.AxesMaxLimits.Z = Math.Round(Limits.AxesMaxLimits.Z * buSystem.InchToMmRatio, 5);
		Limits.AxesMinLimits.X = Math.Round(Limits.AxesMinLimits.X * buSystem.InchToMmRatio, 5);
		Limits.AxesMinLimits.Y = Math.Round(Limits.AxesMinLimits.Y * buSystem.InchToMmRatio, 5);
		Limits.AxesMinLimits.Z = Math.Round(Limits.AxesMinLimits.Z * buSystem.InchToMmRatio, 5);
	}

	public static ArrayList ToDef(ToolBase5 Tool)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(Tool.Purpose.ToString());
		arrayList.Add(buSerilization5.ClassToString(Tool.Data));
		arrayList.Add(buSerilization5.ClassToString(Tool.Geometry));
		arrayList.Add(buSerilization5.ClassToString(Tool.CamData));
		return arrayList;
	}

	public static ArrayList ToDefShort(int Space, ToolBase5 Tool)
	{
		ArrayList arrayList = new ArrayList();
		string text = new string(' ', Space);
		arrayList.Add(text + Tool.Purpose);
		arrayList.Add(text + buSerilization5.ClassToString(Tool.Data));
		arrayList.Add(text + buSerilization5.ClassToString(Tool.Geometry));
		arrayList.Add(text + buSerilization5.ClassToString(Tool.CamData));
		arrayList.Add(text + buSerilization5.ClassToString(Tool.Limits));
		arrayList.Add(text + buSerilization5.ClassToString(Tool.Positions));
		return arrayList;
	}

	public static void Decode(ArrayList AL, ref ToolBase5 Tool)
	{
		Tool = new ToolBase5();
		if (AL.Count >= 1)
		{
			EnumConverter enumConverter = new EnumConverter(typeof(ToolPurpose));
			Tool.Purpose = (ToolPurpose)enumConverter.ConvertFromString(AL[0].ToString());
		}
		if (AL.Count >= 2)
		{
			object ObjPar = Tool.Data;
			buSerilization5.StringToClass(ref ObjPar, AL[1].ToString());
		}
		if (AL.Count >= 3)
		{
			object ObjPar2 = Tool.Geometry;
			buSerilization5.StringToClass(ref ObjPar2, AL[2].ToString());
		}
		if (AL.Count >= 4)
		{
			object ObjPar3 = Tool.CamData;
			buSerilization5.StringToClass(ref ObjPar3, AL[3].ToString());
		}
	}

	public static void DecodeShort(ArrayList AL, ref ToolBase5 Tool)
	{
		Tool = new ToolBase5();
		if (AL.Count >= 1)
		{
			EnumConverter enumConverter = new EnumConverter(typeof(ToolPurpose));
			Tool.Purpose = (ToolPurpose)enumConverter.ConvertFromString(AL[0].ToString());
		}
		if (AL.Count >= 2)
		{
			object ObjPar = Tool.Data;
			buSerilization5.StringToClass(ref ObjPar, AL[1].ToString());
		}
		if (AL.Count >= 3)
		{
			object ObjPar2 = Tool.Geometry;
			buSerilization5.StringToClass(ref ObjPar2, AL[2].ToString());
		}
		if (AL.Count >= 4)
		{
			object ObjPar3 = Tool.CamData;
			buSerilization5.StringToClass(ref ObjPar3, AL[3].ToString());
		}
		if (AL.Count >= 5)
		{
			object ObjPar4 = Tool.Limits;
			buSerilization5.StringToClass(ref ObjPar4, AL[4].ToString());
		}
		if (AL.Count >= 6)
		{
			object ObjPar5 = Tool.Positions;
			buSerilization5.StringToClass(ref ObjPar5, AL[5].ToString());
		}
	}

	public static void DecodeShort(List<string> SL, ref ToolBase5 Tool)
	{
		Tool = new ToolBase5();
		if (SL.Count >= 1)
		{
			EnumConverter enumConverter = new EnumConverter(typeof(ToolPurpose));
			Tool.Purpose = (ToolPurpose)enumConverter.ConvertFromString(SL[0].ToString());
		}
		if (SL.Count >= 2)
		{
			object ObjPar = Tool.Data;
			buSerilization5.StringToClass(ref ObjPar, SL[1].ToString());
		}
		if (SL.Count >= 3)
		{
			object ObjPar2 = Tool.Geometry;
			buSerilization5.StringToClass(ref ObjPar2, SL[2].ToString());
		}
		if (SL.Count >= 4)
		{
			object ObjPar3 = Tool.CamData;
			buSerilization5.StringToClass(ref ObjPar3, SL[3].ToString());
		}
		if (SL.Count >= 5)
		{
			object ObjPar4 = Tool.Limits;
			buSerilization5.StringToClass(ref ObjPar4, SL[4].ToString());
		}
		if (SL.Count >= 6)
		{
			object ObjPar5 = Tool.Positions;
			buSerilization5.StringToClass(ref ObjPar5, SL[5].ToString());
		}
	}

	public static void Copy(ToolBase5 RefTools, ref ToolBase5 CopiedTool)
	{
		if (RefTools.GetType() == typeof(ToolBase5))
		{
			CopiedTool = new ToolBase5(RefTools);
		}
	}

	public static void Copy(List<ToolBase5> RefTools, ref List<ToolBase5> CopiedTools)
	{
		CopiedTools.Clear();
		for (int i = 0; i <= RefTools.Count - 1; i++)
		{
			ToolBase5 CopiedTool = new ToolBase5();
			Copy(RefTools[i], ref CopiedTool);
			CopiedTools.Add(CopiedTool);
		}
	}

	public static List<ToolBase5> Copy(List<ToolBase5> RefTools)
	{
		List<ToolBase5> list = new List<ToolBase5>();
		for (int i = 0; i <= RefTools.Count - 1; i++)
		{
			ToolBase5 CopiedTool = new ToolBase5();
			Copy(RefTools[i], ref CopiedTool);
			list.Add(CopiedTool);
		}
		return list;
	}

	public override string ToString()
	{
		return Data.Name + " - No: " + Data.No + " , Type: " + Geometry.GeometryType.ToString() + " , D: " + Geometry.Diameter + " , L: " + Geometry.Length + " , Thickness: " + Geometry.Thickness;
	}
}
