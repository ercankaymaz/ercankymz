using System;
using System.Collections;

namespace buClass;

[Serializable]
public class camParametersEnable : buSerilization
{
	public camOptionsEnable OptionsEnable = new camOptionsEnable();

	public camOperationEnable OperationsEnable = new camOperationEnable();

	public camDistanceEnable DistancesEnable = new camDistanceEnable();

	public camStepEnable StepsEnable = new camStepEnable();

	public camSpeedsEnable SpeedsEnable = new camSpeedsEnable();

	public camOffsetEnable OffsetsEnable = new camOffsetEnable();

	public camPocketEnable PocketsEnable = new camPocketEnable();

	public LeadInOutEnable LeadInOutEnable = new LeadInOutEnable();

	public camParametersEnable()
	{
	}

	public camParametersEnable(camOptionsEnable optionenable, camOperationEnable operationenable, camDistanceEnable distanceenable, camStepEnable stepenable, camSpeedsEnable speedenable, camOffsetEnable offsetenable, camPocketEnable pocketenable, LeadInOutEnable leadinoutenable)
	{
		OptionsEnable = new camOptionsEnable(optionenable);
		OperationsEnable = new camOperationEnable(operationenable);
		DistancesEnable = new camDistanceEnable(distanceenable);
		StepsEnable = new camStepEnable(stepenable);
		SpeedsEnable = new camSpeedsEnable(speedenable);
		OffsetsEnable = new camOffsetEnable(offsetenable);
		PocketsEnable = new camPocketEnable(pocketenable);
		LeadInOutEnable = new LeadInOutEnable(leadinoutenable);
	}

	public camParametersEnable(camParametersEnable parameters)
	{
		DistancesEnable = new camDistanceEnable(parameters.DistancesEnable);
		LeadInOutEnable = new LeadInOutEnable(parameters.LeadInOutEnable);
		OffsetsEnable = new camOffsetEnable(parameters.OffsetsEnable);
		OperationsEnable = new camOperationEnable(parameters.OperationsEnable);
		OptionsEnable = new camOptionsEnable(parameters.OptionsEnable);
		PocketsEnable = new camPocketEnable(parameters.PocketsEnable);
		SpeedsEnable = new camSpeedsEnable(parameters.SpeedsEnable);
		StepsEnable = new camStepEnable(parameters.StepsEnable);
	}

	public static void Decode(ArrayList AL, string Char, ref camParametersEnable Par)
	{
		buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, Par.DistancesEnable);
		buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, Par.LeadInOutEnable);
		buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, Par.OffsetsEnable);
		buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, Par.OperationsEnable);
		buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, Par.OptionsEnable);
		buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, Par.PocketsEnable);
		buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, Par.SpeedsEnable);
		buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, Par.StepsEnable);
	}

	public static void ToDef(camParametersEnable Par, ref ArrayList AL, string Char, int Space, SerilizationMode DefMode)
	{
		AL.AddRange(Par.DistancesEnable.ToDefAll(Char, Space, SerilizationMode.MultiLine));
		AL.AddRange(Par.LeadInOutEnable.ToDefAll(Char, Space, SerilizationMode.MultiLine));
		AL.AddRange(Par.OffsetsEnable.ToDefAll(Char, Space, SerilizationMode.MultiLine));
		AL.AddRange(Par.OperationsEnable.ToDefAll(Char, Space, SerilizationMode.MultiLine));
		AL.AddRange(Par.OptionsEnable.ToDefAll(Char, Space, SerilizationMode.MultiLine));
		AL.AddRange(Par.PocketsEnable.ToDefAll(Char, Space, SerilizationMode.MultiLine));
		AL.AddRange(Par.SpeedsEnable.ToDefAll(Char, Space, SerilizationMode.MultiLine));
		AL.AddRange(Par.StepsEnable.ToDefAll(Char, Space, SerilizationMode.MultiLine));
	}
}
