using System;
using System.Collections;
using System.Collections.Generic;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class camParameters5 : buSerilization5
{
	public camOptions5 Options = new camOptions5();

	public camOperation5 Operations = new camOperation5();

	public camDistances5 Distances = new camDistances5();

	public camStep5 Steps = new camStep5();

	public camSpeeds5 Speeds = new camSpeeds5();

	public camOffset5 Offsets = new camOffset5();

	public camPocket5 Pockets = new camPocket5();

	public camStrategy5 Strategy = new camStrategy5();

	public camRotary5 Rotary = new camRotary5();

	public camHole5 Hole = new camHole5();

	public camMaterial5 Material = new camMaterial5();

	public LeadIn5 LeadIn = new LeadIn5();

	public LeadOut5 LeadOut = new LeadOut5();

	public camHatch5 Hatch = new camHatch5();

	public camDrill5 Drill = new camDrill5();

	public camNotch5 Notch = new camNotch5();

	public camRuntime5 Runtime = new camRuntime5();

	public SortSettings Sorting = new SortSettings();

	public camParameters5()
	{
	}

	public camParameters5(camDistances5 distance, camSpeeds5 speeds, camStep5 steps, camOffset5 offsets, camOperation5 operations, camOptions5 options, camStrategy5 strategy, camPocket5 pocket, LeadIn5 leadin, LeadOut5 leadout, camHole5 hole, camMaterial5 material, camHatch5 hatch, camRotary5 rotary)
	{
		Distances = new camDistances5(distance);
		Speeds = new camSpeeds5(speeds);
		Steps = new camStep5(steps);
		Offsets = new camOffset5(offsets);
		Operations = new camOperation5(operations);
		Options = new camOptions5(options);
		Strategy = new camStrategy5(strategy);
		Pockets = new camPocket5(pocket);
		LeadOut = new LeadOut5(leadout);
		LeadIn = new LeadIn5(leadin);
		Hole = new camHole5(hole);
		Material = new camMaterial5(material);
		Hatch = new camHatch5(hatch);
		Rotary = new camRotary5(rotary);
	}

	public camParameters5(camParameters5 parameters)
	{
		if (parameters != null)
		{
			Distances = new camDistances5(parameters.Distances);
			Options = new camOptions5(parameters.Options);
			Operations = new camOperation5(parameters.Operations);
			Steps = new camStep5(parameters.Steps);
			Speeds = new camSpeeds5(parameters.Speeds);
			Offsets = new camOffset5(parameters.Offsets);
			Pockets = new camPocket5(parameters.Pockets);
			Strategy = new camStrategy5(parameters.Strategy);
			LeadIn = new LeadIn5(parameters.LeadIn);
			LeadOut = new LeadOut5(parameters.LeadOut);
			Hole = new camHole5(parameters.Hole);
			Material = new camMaterial5(parameters.Material);
			Hatch = new camHatch5(parameters.Hatch);
			Drill = new camDrill5(parameters.Drill);
			Sorting = new SortSettings(parameters.Sorting);
			Runtime = new camRuntime5(parameters.Runtime);
			Notch = new camNotch5(parameters.Notch);
			Rotary = new camRotary5(parameters.Rotary);
		}
	}

	public static void Copy(camParameters5 parameters, ref camDistances5 distance, ref camSpeeds5 speeds, ref camStep5 steps, ref camOffset5 offsets, ref camOperation5 operations, ref camOptions5 options, ref camStrategy5 strategy, ref camPocket5 pocket, ref LeadIn5 leadin, ref LeadOut5 leadout, ref camHole5 hole, ref camHatch5 hatch, ref camRotary5 rotary)
	{
		distance = new camDistances5(parameters.Distances);
		options = new camOptions5(parameters.Options);
		operations = new camOperation5(parameters.Operations);
		steps = new camStep5(parameters.Steps);
		speeds = new camSpeeds5(parameters.Speeds);
		offsets = new camOffset5(parameters.Offsets);
		pocket = new camPocket5(parameters.Pockets);
		strategy = new camStrategy5(parameters.Strategy);
		leadin = new LeadIn5(parameters.LeadIn);
		leadout = new LeadOut5(parameters.LeadOut);
		hole = new camHole5(parameters.Hole);
		hatch = new camHatch5(parameters.Hatch);
		rotary = new camRotary5(parameters.Rotary);
	}

	public static void Decode(ArrayList AL, string Char, ref camParameters5 Par)
	{
		buSerilization5.Decode(AL, Char, SerilizationMode5.MultiLine, Par.Distances);
		buSerilization5.Decode(AL, Char, SerilizationMode5.MultiLine, Par.Operations);
		buSerilization5.Decode(AL, Char, SerilizationMode5.MultiLine, Par.LeadIn);
		buSerilization5.Decode(AL, Char, SerilizationMode5.MultiLine, Par.LeadOut);
		buSerilization5.Decode(AL, Char, SerilizationMode5.MultiLine, Par.Offsets);
		buSerilization5.Decode(AL, Char, SerilizationMode5.MultiLine, Par.Steps);
		buSerilization5.Decode(AL, Char, SerilizationMode5.MultiLine, Par.Speeds);
		buSerilization5.Decode(AL, Char, SerilizationMode5.MultiLine, Par.Options);
		buSerilization5.Decode(AL, Char, SerilizationMode5.MultiLine, Par.Strategy);
		buSerilization5.Decode(AL, Char, SerilizationMode5.MultiLine, Par.Pockets);
		buSerilization5.Decode(AL, Char, SerilizationMode5.MultiLine, Par.Hole);
		buSerilization5.Decode(AL, Char, SerilizationMode5.MultiLine, Par.Hatch);
		buSerilization5.Decode(AL, Char, SerilizationMode5.MultiLine, Par.Drill);
		buSerilization5.Decode(AL, Char, SerilizationMode5.MultiLine, Par.Sorting);
		buSerilization5.Decode(AL, Char, SerilizationMode5.MultiLine, Par.Rotary);
	}

	public static void ToDef(camParameters5 Par, ref ArrayList AL, string Char, int Space, SerilizationMode5 DefMode)
	{
		AL.AddRange(Par.Distances.ToDefAll(Char, Space, SerilizationMode5.MultiLine));
		AL.AddRange(Par.Operations.ToDefAll(Char, Space, SerilizationMode5.MultiLine));
		AL.AddRange(Par.LeadIn.ToDefAll(Char, Space, SerilizationMode5.MultiLine));
		AL.AddRange(Par.LeadOut.ToDefAll(Char, Space, SerilizationMode5.MultiLine));
		AL.AddRange(Par.Offsets.ToDefAll(Char, Space, SerilizationMode5.MultiLine));
		AL.AddRange(Par.Steps.ToDefAll(Char, Space, SerilizationMode5.MultiLine));
		AL.AddRange(Par.Speeds.ToDefAll(Char, Space, SerilizationMode5.MultiLine));
		AL.AddRange(Par.Options.ToDefAll(Char, Space, SerilizationMode5.MultiLine));
		AL.AddRange(Par.Strategy.ToDefAll(Char, Space, SerilizationMode5.MultiLine));
		AL.AddRange(Par.Pockets.ToDefAll(Char, Space, SerilizationMode5.MultiLine));
		AL.AddRange(Par.Hole.ToDefAll(Char, Space, SerilizationMode5.MultiLine));
		AL.AddRange(Par.Hatch.ToDefAll(Char, Space, SerilizationMode5.MultiLine));
		AL.AddRange(Par.Drill.ToDefAll(Char, Space, SerilizationMode5.MultiLine));
		AL.AddRange(Par.Sorting.ToDefAll(Char, Space, SerilizationMode5.MultiLine));
		AL.AddRange(Par.Rotary.ToDefAll(Char, Space, SerilizationMode5.MultiLine));
	}

	public static void DecodeSingleLine(List<string> SL, string Char, ref camParameters5 Par)
	{
		Par = new camParameters5();
		if (SL.Count >= 1)
		{
			object ObjPar = Par.Distances;
			buSerilization5.StringToClass(ref ObjPar, SL[0]);
		}
		if (SL.Count >= 2)
		{
			object ObjPar2 = Par.Drill;
			buSerilization5.StringToClass(ref ObjPar2, SL[1]);
		}
		if (SL.Count >= 3)
		{
			object ObjPar3 = Par.Hatch;
			buSerilization5.StringToClass(ref ObjPar3, SL[2]);
		}
		if (SL.Count >= 4)
		{
			object ObjPar4 = Par.Hole;
			buSerilization5.StringToClass(ref ObjPar4, SL[3]);
		}
		if (SL.Count >= 5)
		{
			object ObjPar5 = Par.LeadIn;
			buSerilization5.StringToClass(ref ObjPar5, SL[4]);
		}
		if (SL.Count >= 6)
		{
			object ObjPar6 = Par.LeadOut;
			buSerilization5.StringToClass(ref ObjPar6, SL[5]);
		}
		if (SL.Count >= 7)
		{
			object ObjPar7 = Par.Material;
			buSerilization5.StringToClass(ref ObjPar7, SL[6]);
		}
		if (SL.Count >= 8)
		{
			object ObjPar8 = Par.Notch;
			buSerilization5.StringToClass(ref ObjPar8, SL[7]);
		}
		if (SL.Count >= 9)
		{
			object ObjPar9 = Par.Offsets;
			buSerilization5.StringToClass(ref ObjPar9, SL[8]);
		}
		if (SL.Count >= 10)
		{
			object ObjPar10 = Par.Operations;
			buSerilization5.StringToClass(ref ObjPar10, SL[9]);
		}
		if (SL.Count >= 11)
		{
			object ObjPar11 = Par.Options;
			buSerilization5.StringToClass(ref ObjPar11, SL[10]);
		}
		if (SL.Count >= 12)
		{
			object ObjPar12 = Par.Pockets;
			buSerilization5.StringToClass(ref ObjPar12, SL[11]);
		}
		if (SL.Count >= 13)
		{
			object ObjPar13 = Par.Sorting;
			buSerilization5.StringToClass(ref ObjPar13, SL[12]);
		}
		if (SL.Count >= 14)
		{
			object ObjPar14 = Par.Speeds;
			buSerilization5.StringToClass(ref ObjPar14, SL[13]);
		}
		if (SL.Count >= 15)
		{
			object ObjPar15 = Par.Steps;
			buSerilization5.StringToClass(ref ObjPar15, SL[14]);
		}
		if (SL.Count >= 16)
		{
			object ObjPar16 = Par.Strategy;
			buSerilization5.StringToClass(ref ObjPar16, SL[15]);
		}
		if (SL.Count >= 17)
		{
			object ObjPar17 = Par.Rotary;
			buSerilization5.StringToClass(ref ObjPar17, SL[16]);
		}
	}

	public static void ToDefSingleLine(camParameters5 Par, ref ArrayList AL, string Char, int Space)
	{
		AL.Add(buString5.SpaceChar(Space) + "<CamParametersAll>");
		AL.Add(buString5.SpaceChar(Space + 2) + "CamParDis = " + buSerilization5.ClassToString(Par.Distances));
		AL.Add(buString5.SpaceChar(Space + 2) + "CamParDrill = " + buSerilization5.ClassToString(Par.Drill));
		AL.Add(buString5.SpaceChar(Space + 2) + "CamParHatch = " + buSerilization5.ClassToString(Par.Hatch));
		AL.Add(buString5.SpaceChar(Space + 2) + "CamParHole = " + buSerilization5.ClassToString(Par.Hole));
		AL.Add(buString5.SpaceChar(Space + 2) + "CamParLeadIn= " + buSerilization5.ClassToString(Par.LeadIn));
		AL.Add(buString5.SpaceChar(Space + 2) + "CamParLeadOut = " + buSerilization5.ClassToString(Par.LeadOut));
		AL.Add(buString5.SpaceChar(Space + 2) + "CamParMaterial = " + buSerilization5.ClassToString(Par.Material));
		AL.Add(buString5.SpaceChar(Space + 2) + "CamParNotch = " + buSerilization5.ClassToString(Par.Notch));
		AL.Add(buString5.SpaceChar(Space + 2) + "CamParOffset = " + buSerilization5.ClassToString(Par.Offsets));
		AL.Add(buString5.SpaceChar(Space + 2) + "CamParOperation = " + buSerilization5.ClassToString(Par.Operations));
		AL.Add(buString5.SpaceChar(Space + 2) + "CamParOption = " + buSerilization5.ClassToString(Par.Options));
		AL.Add(buString5.SpaceChar(Space + 2) + "CamParPocket = " + buSerilization5.ClassToString(Par.Pockets));
		AL.Add(buString5.SpaceChar(Space + 2) + "CamParSorting = " + buSerilization5.ClassToString(Par.Sorting));
		AL.Add(buString5.SpaceChar(Space + 2) + "CamParSpeed = " + buSerilization5.ClassToString(Par.Speeds));
		AL.Add(buString5.SpaceChar(Space + 2) + "CamParStep = " + buSerilization5.ClassToString(Par.Steps));
		AL.Add(buString5.SpaceChar(Space + 2) + "CamParStrategy = " + buSerilization5.ClassToString(Par.Strategy));
		AL.Add(buString5.SpaceChar(Space + 2) + "CamParRotary = " + buSerilization5.ClassToString(Par.Rotary));
		AL.Add(buString5.SpaceChar(Space) + "</CamParametersAll>");
	}

	public void MmToInch()
	{
		Distances.Safe = Math.Round(Distances.Safe * buSystem.MmToInchRatio, 5);
		Distances.SafeSmall = Math.Round(Distances.SafeSmall * buSystem.MmToInchRatio, 5);
		Distances.FirstApproach = Math.Round(Distances.FirstApproach * buSystem.MmToInchRatio, 5);
		Distances.StepUp = Math.Round(Distances.StepUp * buSystem.MmToInchRatio, 5);
		Distances.LeftSafe = Math.Round(Distances.LeftSafe * buSystem.MmToInchRatio, 5);
		Distances.LeftSafeSmall = Math.Round(Distances.LeftSafeSmall * buSystem.MmToInchRatio, 5);
		Distances.LeftFirstApproach = Math.Round(Distances.LeftFirstApproach * buSystem.MmToInchRatio, 5);
		Distances.LeftStepUp = Math.Round(Distances.LeftStepUp * buSystem.MmToInchRatio, 5);
		Distances.RightSafe = Math.Round(Distances.RightSafe * buSystem.MmToInchRatio, 5);
		Distances.RightSafeSmall = Math.Round(Distances.RightSafeSmall * buSystem.MmToInchRatio, 5);
		Distances.RightFirstApproach = Math.Round(Distances.RightFirstApproach * buSystem.MmToInchRatio, 5);
		Distances.RightStepUp = Math.Round(Distances.RightStepUp * buSystem.MmToInchRatio, 5);
		Distances.Air = Math.Round(Distances.Air * buSystem.MmToInchRatio, 5);
		Distances.Rapid = Math.Round(Distances.Rapid * buSystem.MmToInchRatio, 5);
		Distances.EntryAndExit = Math.Round(Distances.EntryAndExit * buSystem.MmToInchRatio, 5);
		Speeds.AreaClearance = Math.Round(Speeds.AreaClearance * buSystem.MmToInchRatio, 5);
		Speeds.Feed = Math.Round(Speeds.Feed * buSystem.MmToInchRatio, 5);
		Speeds.BackwardFeed = Math.Round(Speeds.BackwardFeed * buSystem.MmToInchRatio, 5);
		Speeds.Plunge = Math.Round(Speeds.Plunge * buSystem.MmToInchRatio, 5);
		Speeds.Rapid = Math.Round(Speeds.Rapid * buSystem.MmToInchRatio, 5);
		Speeds.Leave = Math.Round(Speeds.Leave * buSystem.MmToInchRatio, 5);
		Speeds.Finish = Math.Round(Speeds.Finish * buSystem.MmToInchRatio, 5);
		Speeds.SpindleSpeed = Math.Round(Speeds.SpindleSpeed * buSystem.MmToInchRatio, 5);
		Drill.EndHeight = Math.Round(Drill.EndHeight * buSystem.MmToInchRatio, 5);
		Drill.PeckDepth = Math.Round(Drill.PeckDepth * buSystem.MmToInchRatio, 5);
		Drill.PeckMinRetractDistance = Math.Round(Drill.PeckMinRetractDistance * buSystem.MmToInchRatio, 5);
		Drill.StartHeight = Math.Round(Drill.StartHeight * buSystem.MmToInchRatio, 5);
		Hatch.CutStep = Math.Round(Hatch.CutStep * buSystem.MmToInchRatio, 5);
		Hatch.XDirectionLength = Math.Round(Hatch.XDirectionLength * buSystem.MmToInchRatio, 5);
		Hatch.YDirectionWidth = Math.Round(Hatch.YDirectionWidth * buSystem.MmToInchRatio, 5);
		Hole.DownStep = Math.Round(Hole.DownStep * buSystem.MmToInchRatio, 5);
		Hole.EndHeight = Math.Round(Hole.EndHeight * buSystem.MmToInchRatio, 5);
		Hole.StartHeight = Math.Round(Hole.StartHeight * buSystem.MmToInchRatio, 5);
		Hole.UpStep = Math.Round(Hole.UpStep * buSystem.MmToInchRatio, 5);
		LeadIn.ArcRadius = Math.Round(LeadIn.ArcRadius * buSystem.MmToInchRatio, 5);
		LeadIn.ExtendLength = Math.Round(LeadIn.ExtendLength * buSystem.MmToInchRatio, 5);
		LeadIn.Length = Math.Round(LeadIn.Length * buSystem.MmToInchRatio, 5);
		LeadOut.ArcRadius = Math.Round(LeadOut.ArcRadius * buSystem.MmToInchRatio, 5);
		LeadOut.ExtendLength = Math.Round(LeadOut.ExtendLength * buSystem.MmToInchRatio, 5);
		LeadOut.Length = Math.Round(LeadOut.Length * buSystem.MmToInchRatio, 5);
		Material.StartZ = Math.Round(Material.StartZ * buSystem.MmToInchRatio, 5);
		Material.Thickness = Math.Round(Material.Thickness * buSystem.MmToInchRatio, 5);
		Offsets.AdditionalOffset = Math.Round(Offsets.AdditionalOffset * buSystem.MmToInchRatio, 5);
		Offsets.FinishOffset = Math.Round(Offsets.FinishOffset * buSystem.MmToInchRatio, 5);
		Offsets.InCutSafeLength = Math.Round(Offsets.InCutSafeLength * buSystem.MmToInchRatio, 5);
		Offsets.Offset = Math.Round(Offsets.Offset * buSystem.MmToInchRatio, 5);
		Offsets.OverlapDistance = Math.Round(Offsets.OverlapDistance * buSystem.MmToInchRatio, 5);
		Operations.BaseThickness = Math.Round(Operations.BaseThickness * buSystem.MmToInchRatio, 5);
		Operations.Depth = Math.Round(Operations.Depth * buSystem.MmToInchRatio, 5);
		Operations.Height = Math.Round(Operations.Height * buSystem.MmToInchRatio, 5);
		Operations.Overlap = Math.Round(Operations.Overlap * buSystem.MmToInchRatio, 5);
		Operations.TargetZ = Math.Round(Operations.TargetZ * buSystem.MmToInchRatio, 5);
		Operations.Thickness = Math.Round(Operations.Thickness * buSystem.MmToInchRatio, 5);
		Operations.Width = Math.Round(Operations.Width * buSystem.MmToInchRatio, 5);
		Options.PocketNextContourMaxDistance = Math.Round(Options.PocketNextContourMaxDistance * buSystem.MmToInchRatio, 5);
		Options.StockHeight = Math.Round(Options.StockHeight * buSystem.MmToInchRatio, 5);
		Options.WidthXDirection = Math.Round(Options.WidthXDirection * buSystem.MmToInchRatio, 5);
		Options.WidthXYDirection = Math.Round(Options.WidthXYDirection * buSystem.MmToInchRatio, 5);
		Options.WidthYDirection = Math.Round(Options.WidthYDirection * buSystem.MmToInchRatio, 5);
		Steps.DepthStep = Math.Round(Steps.DepthStep * buSystem.MmToInchRatio, 5);
		Steps.Distance = Math.Round(Steps.Distance * buSystem.MmToInchRatio, 5);
		Steps.EndValue = Math.Round(Steps.EndValue * buSystem.MmToInchRatio, 5);
		Steps.MoveUp = Math.Round(Steps.MoveUp * buSystem.MmToInchRatio, 5);
		Steps.StartValue = Math.Round(Steps.StartValue * buSystem.MmToInchRatio, 5);
		Steps.Step = Math.Round(Steps.Step * buSystem.MmToInchRatio, 5);
	}

	public void InchToMm()
	{
		Distances.Safe = Math.Round(Distances.Safe * buSystem.InchToMmRatio, 5);
		Distances.SafeSmall = Math.Round(Distances.SafeSmall * buSystem.InchToMmRatio, 5);
		Distances.FirstApproach = Math.Round(Distances.FirstApproach * buSystem.InchToMmRatio, 5);
		Distances.StepUp = Math.Round(Distances.StepUp * buSystem.InchToMmRatio, 5);
		Distances.LeftSafe = Math.Round(Distances.LeftSafe * buSystem.InchToMmRatio, 5);
		Distances.LeftSafeSmall = Math.Round(Distances.LeftSafeSmall * buSystem.InchToMmRatio, 5);
		Distances.LeftFirstApproach = Math.Round(Distances.LeftFirstApproach * buSystem.InchToMmRatio, 5);
		Distances.LeftStepUp = Math.Round(Distances.LeftStepUp * buSystem.InchToMmRatio, 5);
		Distances.RightSafe = Math.Round(Distances.RightSafe * buSystem.InchToMmRatio, 5);
		Distances.RightSafeSmall = Math.Round(Distances.RightSafeSmall * buSystem.InchToMmRatio, 5);
		Distances.RightFirstApproach = Math.Round(Distances.RightFirstApproach * buSystem.InchToMmRatio, 5);
		Distances.RightStepUp = Math.Round(Distances.RightStepUp * buSystem.InchToMmRatio, 5);
		Distances.Air = Math.Round(Distances.Air * buSystem.InchToMmRatio, 5);
		Distances.Rapid = Math.Round(Distances.Rapid * buSystem.InchToMmRatio, 5);
		Distances.EntryAndExit = Math.Round(Distances.EntryAndExit * buSystem.InchToMmRatio, 5);
		Speeds.AreaClearance = Math.Round(Speeds.AreaClearance * buSystem.InchToMmRatio, 5);
		Speeds.Feed = Math.Round(Speeds.Feed * buSystem.InchToMmRatio, 5);
		Speeds.BackwardFeed = Math.Round(Speeds.BackwardFeed * buSystem.InchToMmRatio, 5);
		Speeds.Plunge = Math.Round(Speeds.Plunge * buSystem.InchToMmRatio, 5);
		Speeds.Rapid = Math.Round(Speeds.Rapid * buSystem.InchToMmRatio, 5);
		Speeds.Leave = Math.Round(Speeds.Leave * buSystem.InchToMmRatio, 5);
		Speeds.Finish = Math.Round(Speeds.Finish * buSystem.InchToMmRatio, 5);
		Speeds.SpindleSpeed = Math.Round(Speeds.SpindleSpeed * buSystem.InchToMmRatio, 5);
		Drill.EndHeight = Math.Round(Drill.EndHeight * buSystem.InchToMmRatio, 5);
		Drill.PeckDepth = Math.Round(Drill.PeckDepth * buSystem.InchToMmRatio, 5);
		Drill.PeckMinRetractDistance = Math.Round(Drill.PeckMinRetractDistance * buSystem.InchToMmRatio, 5);
		Drill.StartHeight = Math.Round(Drill.StartHeight * buSystem.InchToMmRatio, 5);
		Hatch.CutStep = Math.Round(Hatch.CutStep * buSystem.InchToMmRatio, 5);
		Hatch.XDirectionLength = Math.Round(Hatch.XDirectionLength * buSystem.InchToMmRatio, 5);
		Hatch.YDirectionWidth = Math.Round(Hatch.YDirectionWidth * buSystem.InchToMmRatio, 5);
		Hole.DownStep = Math.Round(Hole.DownStep * buSystem.InchToMmRatio, 5);
		Hole.EndHeight = Math.Round(Hole.EndHeight * buSystem.InchToMmRatio, 5);
		Hole.StartHeight = Math.Round(Hole.StartHeight * buSystem.InchToMmRatio, 5);
		Hole.UpStep = Math.Round(Hole.UpStep * buSystem.InchToMmRatio, 5);
		LeadIn.ArcRadius = Math.Round(LeadIn.ArcRadius * buSystem.InchToMmRatio, 5);
		LeadIn.ExtendLength = Math.Round(LeadIn.ExtendLength * buSystem.InchToMmRatio, 5);
		LeadIn.Length = Math.Round(LeadIn.Length * buSystem.InchToMmRatio, 5);
		LeadOut.ArcRadius = Math.Round(LeadOut.ArcRadius * buSystem.InchToMmRatio, 5);
		LeadOut.ExtendLength = Math.Round(LeadOut.ExtendLength * buSystem.InchToMmRatio, 5);
		LeadOut.Length = Math.Round(LeadOut.Length * buSystem.InchToMmRatio, 5);
		Material.StartZ = Math.Round(Material.StartZ * buSystem.InchToMmRatio, 5);
		Material.Thickness = Math.Round(Material.Thickness * buSystem.InchToMmRatio, 5);
		Offsets.AdditionalOffset = Math.Round(Offsets.AdditionalOffset * buSystem.InchToMmRatio, 5);
		Offsets.FinishOffset = Math.Round(Offsets.FinishOffset * buSystem.InchToMmRatio, 5);
		Offsets.InCutSafeLength = Math.Round(Offsets.InCutSafeLength * buSystem.InchToMmRatio, 5);
		Offsets.Offset = Math.Round(Offsets.Offset * buSystem.InchToMmRatio, 5);
		Offsets.OverlapDistance = Math.Round(Offsets.OverlapDistance * buSystem.InchToMmRatio, 5);
		Operations.BaseThickness = Math.Round(Operations.BaseThickness * buSystem.InchToMmRatio, 5);
		Operations.Depth = Math.Round(Operations.Depth * buSystem.InchToMmRatio, 5);
		Operations.Height = Math.Round(Operations.Height * buSystem.InchToMmRatio, 5);
		Operations.Overlap = Math.Round(Operations.Overlap * buSystem.InchToMmRatio, 5);
		Operations.TargetZ = Math.Round(Operations.TargetZ * buSystem.InchToMmRatio, 5);
		Operations.Thickness = Math.Round(Operations.Thickness * buSystem.InchToMmRatio, 5);
		Operations.Width = Math.Round(Operations.Width * buSystem.InchToMmRatio, 5);
		Options.PocketNextContourMaxDistance = Math.Round(Options.PocketNextContourMaxDistance * buSystem.InchToMmRatio, 5);
		Options.StockHeight = Math.Round(Options.StockHeight * buSystem.InchToMmRatio, 5);
		Options.WidthXDirection = Math.Round(Options.WidthXDirection * buSystem.InchToMmRatio, 5);
		Options.WidthXYDirection = Math.Round(Options.WidthXYDirection * buSystem.InchToMmRatio, 5);
		Options.WidthYDirection = Math.Round(Options.WidthYDirection * buSystem.InchToMmRatio, 5);
		Steps.DepthStep = Math.Round(Steps.DepthStep * buSystem.InchToMmRatio, 5);
		Steps.Distance = Math.Round(Steps.Distance * buSystem.InchToMmRatio, 5);
		Steps.EndValue = Math.Round(Steps.EndValue * buSystem.InchToMmRatio, 5);
		Steps.MoveUp = Math.Round(Steps.MoveUp * buSystem.InchToMmRatio, 5);
		Steps.StartValue = Math.Round(Steps.StartValue * buSystem.InchToMmRatio, 5);
		Steps.Step = Math.Round(Steps.Step * buSystem.InchToMmRatio, 5);
	}
}
