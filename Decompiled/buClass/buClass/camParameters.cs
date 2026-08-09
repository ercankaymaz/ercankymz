using System;
using System.Collections;

namespace buClass;

[Serializable]
public class camParameters : buSerilization
{
	public camOptions Options = new camOptions();

	public camOperation Operations = new camOperation();

	public camDistances Distances = new camDistances();

	public camStep Steps = new camStep();

	public camSpeeds Speeds = new camSpeeds();

	public camOffset Offsets = new camOffset();

	public camPocket Pockets = new camPocket();

	public camStrategy Strategy = new camStrategy();

	public camHole Hole = new camHole();

	public camMaterial Material = new camMaterial();

	public LeadIn LeadIn = new LeadIn();

	public LeadOut LeadOut = new LeadOut();

	public camHatch Hatch = new camHatch();

	public camDrill Drill = new camDrill();

	public camParameters()
	{
	}

	public camParameters(camDistances distance, camSpeeds speeds, camStep steps, camOffset offsets, camOperation operations, camOptions options, camStrategy strategy, camPocket pocket, LeadIn leadin, LeadOut leadout, camHole hole, camMaterial material, camHatch hatch)
	{
		Distances = new camDistances(distance);
		Speeds = new camSpeeds(speeds);
		Steps = new camStep(steps);
		Offsets = new camOffset(offsets);
		Operations = new camOperation(operations);
		Options = new camOptions(options);
		Strategy = new camStrategy(strategy);
		Pockets = new camPocket(pocket);
		LeadOut = new LeadOut(leadout);
		LeadIn = new LeadIn(leadin);
		Hole = new camHole(hole);
		Material = new camMaterial(material);
		Hatch = new camHatch(hatch);
	}

	public camParameters(camParameters parameters)
	{
		Distances = new camDistances(parameters.Distances);
		Options = new camOptions(parameters.Options);
		Operations = new camOperation(parameters.Operations);
		Steps = new camStep(parameters.Steps);
		Speeds = new camSpeeds(parameters.Speeds);
		Offsets = new camOffset(parameters.Offsets);
		Pockets = new camPocket(parameters.Pockets);
		Strategy = new camStrategy(parameters.Strategy);
		LeadIn = new LeadIn(parameters.LeadIn);
		LeadOut = new LeadOut(parameters.LeadOut);
		Hole = new camHole(parameters.Hole);
		Material = new camMaterial(parameters.Material);
		Hatch = new camHatch(parameters.Hatch);
		Drill = new camDrill(parameters.Drill);
	}

	public static void Copy(camParameters parameters, ref camDistances distance, ref camSpeeds speeds, ref camStep steps, ref camOffset offsets, ref camOperation operations, ref camOptions options, ref camStrategy strategy, ref camPocket pocket, ref LeadIn leadin, ref LeadOut leadout, ref camHole hole, ref camHatch hatch)
	{
		distance = new camDistances(parameters.Distances);
		options = new camOptions(parameters.Options);
		operations = new camOperation(parameters.Operations);
		steps = new camStep(parameters.Steps);
		speeds = new camSpeeds(parameters.Speeds);
		offsets = new camOffset(parameters.Offsets);
		pocket = new camPocket(parameters.Pockets);
		strategy = new camStrategy(parameters.Strategy);
		leadin = new LeadIn(parameters.LeadIn);
		leadout = new LeadOut(parameters.LeadOut);
		hole = new camHole(parameters.Hole);
		hatch = new camHatch(parameters.Hatch);
	}

	public static void Decode(ArrayList AL, string Char, ref camParameters Par)
	{
		buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, Par.Distances);
		buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, Par.Operations);
		buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, Par.LeadIn);
		buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, Par.LeadOut);
		buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, Par.Offsets);
		buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, Par.Steps);
		buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, Par.Speeds);
		buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, Par.Options);
		buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, Par.Strategy);
		buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, Par.Pockets);
		buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, Par.Hole);
		buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, Par.Hatch);
	}

	public static void ToDef(camParameters Par, ref ArrayList AL, string Char, int Space, SerilizationMode DefMode)
	{
		AL.AddRange(Par.Distances.ToDefAll(Char, Space, SerilizationMode.MultiLine));
		AL.AddRange(Par.Operations.ToDefAll(Char, Space, SerilizationMode.MultiLine));
		AL.AddRange(Par.LeadIn.ToDefAll(Char, Space, SerilizationMode.MultiLine));
		AL.AddRange(Par.LeadOut.ToDefAll(Char, Space, SerilizationMode.MultiLine));
		AL.AddRange(Par.Offsets.ToDefAll(Char, Space, SerilizationMode.MultiLine));
		AL.AddRange(Par.Steps.ToDefAll(Char, Space, SerilizationMode.MultiLine));
		AL.AddRange(Par.Speeds.ToDefAll(Char, Space, SerilizationMode.MultiLine));
		AL.AddRange(Par.Options.ToDefAll(Char, Space, SerilizationMode.MultiLine));
		AL.AddRange(Par.Strategy.ToDefAll(Char, Space, SerilizationMode.MultiLine));
		AL.AddRange(Par.Pockets.ToDefAll(Char, Space, SerilizationMode.MultiLine));
		AL.AddRange(Par.Hole.ToDefAll(Char, Space, SerilizationMode.MultiLine));
		AL.AddRange(Par.Hatch.ToDefAll(Char, Space, SerilizationMode.MultiLine));
	}
}
