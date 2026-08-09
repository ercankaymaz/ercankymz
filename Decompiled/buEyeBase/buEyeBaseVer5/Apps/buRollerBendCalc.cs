using System.Collections.Generic;

namespace buEyeBaseVer5.Apps;

public class buRollerBendCalc
{
	public static RollerBendRuntimeSettings varRollerBendRuntime = new RollerBendRuntimeSettings();

	public static RollerBendSettings varRollerBendSetting = new RollerBendSettings();

	public void CreateSimulationPoints(List<RollerBendMove> Moves, ref List<RollerBendMove> SimulationMoves)
	{
		SimulationMoves.Clear();
		if (Moves.Count < 2)
		{
			return;
		}
		RollerBendMove rollerBendMove = new RollerBendMove(Moves[0]);
		rollerBendMove.Index = 0;
		SimulationMoves.Add(rollerBendMove);
		for (int i = 1; i <= Moves.Count - 1; i++)
		{
			List<double> Values = new List<double>();
			List<double> Values2 = new List<double>();
			List<double> Values3 = new List<double>();
			List<double> Values4 = new List<double>();
			List<double> Values5 = new List<double>();
			List<double> Values6 = new List<double>();
			if (!((Moves[i].Command == RollerBendMoveCommand.MoveFree) | (Moves[i].Command == RollerBendMoveCommand.MoveBend) | (Moves[i].Command == RollerBendMoveCommand.MoveMaterial)))
			{
				rollerBendMove = new RollerBendMove(Moves[i]);
				rollerBendMove.Index = i;
				SimulationMoves.Add(rollerBendMove);
				continue;
			}
			buNumeric5.DevideMinMaxValueByNumber(Moves[i - 1].XPosition, Moves[i].XPosition, 10, ref Values);
			buNumeric5.DevideMinMaxValueByNumber(Moves[i - 1].LeftDistance, Moves[i].LeftDistance, 10, ref Values2);
			buNumeric5.DevideMinMaxValueByNumber(Moves[i - 1].LeftAngle, Moves[i].LeftAngle, 10, ref Values5);
			buNumeric5.DevideMinMaxValueByNumber(Moves[i - 1].RightDistance, Moves[i].RightDistance, 10, ref Values3);
			buNumeric5.DevideMinMaxValueByNumber(Moves[i - 1].RightAngle, Moves[i].RightAngle, 10, ref Values6);
			buNumeric5.DevideMinMaxValueByNumber(Moves[i - 1].UpDistance, Moves[i].UpDistance, 10, ref Values4);
			for (int j = 1; j <= Values.Count - 1; j++)
			{
				SimulationMoves.Add(new RollerBendMove(Values[j], Values2[j], Values5[j], Values3[j], Values6[j], Values4[j], Moves[i].Command, i));
			}
		}
	}
}
