using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using buClass;
using buClass.Apps;

namespace buCore;

public class buConversion
{
	public buConversion()
	{
		if (!buVector.smethod_0("buConversion"))
		{
			throw new RegisterException("buConversion");
		}
	}

	public static double RadianToDegree(double Radian)
	{
		try
		{
			double num = 0.0;
			return Radian * 180.0 / Math.PI;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
			return 0.0;
		}
	}

	public static double DegreeToRadian(double Degree)
	{
		try
		{
			double result = 0.0;
			if (Degree > 360.0)
			{
				Degree -= 360.0;
				result = Degree * Math.PI / 180.0;
				Degree += 360.0;
			}
			if (Degree <= 360.0)
			{
				result = Degree * Math.PI / 180.0;
			}
			return result;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
			return 0.0;
		}
	}

	public static double DegreeToRadianGreat360(double Degree)
	{
		try
		{
			double result = 0.0;
			if (Degree > 360.0)
			{
				Degree -= 360.0;
				result = Degree * Math.PI / 180.0 + Math.PI * 2.0;
				Degree += 360.0;
			}
			if (Degree <= 360.0)
			{
				result = Degree * Math.PI / 180.0;
			}
			return result;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
			return 0.0;
		}
	}

	public static bool[] IntegerToBits(int Value)
	{
		string text = Convert.ToString(Value, 2);
		int[] array = (from char_0 in text.PadLeft(32, '0')
			select int.Parse(char_0.ToString())).ToArray();
		bool[] array2 = new bool[array.Length];
		int num = 0;
		for (int num2 = array.Length - 1; num2 >= 0; num2--)
		{
			if (array[num2] == 0)
			{
				array2[num] = false;
			}
			else
			{
				array2[num] = true;
			}
			num++;
		}
		return array2;
	}

	public static Pnt3D PointToPnt3D(Point P)
	{
		try
		{
			return new Pnt3D(P.X, P.Y);
		}
		catch (Exception)
		{
			return new Pnt3D();
		}
	}

	public static Point Pnt3DToPoint(Pnt3D P)
	{
		try
		{
			return new Point((int)P.X, (int)P.Y);
		}
		catch (Exception)
		{
			return default(Point);
		}
	}

	public static Pnt3D PointFToPnt3D(PointF P)
	{
		try
		{
			return new Pnt3D(P.X, P.Y);
		}
		catch (Exception)
		{
			return new Pnt3D();
		}
	}

	public static PointF Pnt3DToPointF(Pnt3D P)
	{
		try
		{
			return new PointF((float)P.X, (float)P.Y);
		}
		catch (Exception)
		{
			return default(PointF);
		}
	}

	public static Pnt3D Pnt2DToPnt3D(Pnt2D P)
	{
		try
		{
			return new Pnt3D(P.X, P.Y);
		}
		catch (Exception)
		{
			return new Pnt3D();
		}
	}

	public static Pnt2D Pnt3DToPnt2D(Pnt3D P)
	{
		try
		{
			return new Pnt2D(P.X, P.Y);
		}
		catch (Exception)
		{
			return new Pnt2D();
		}
	}

	public static Pnt3D Vec3DToPnt3D(Vec3D P)
	{
		try
		{
			return new Pnt3D(P.X, P.Y, P.Z);
		}
		catch (Exception)
		{
			return new Pnt3D();
		}
	}

	public static Vec3D Pnt3DToVec3D(Pnt3D P)
	{
		try
		{
			return new Vec3D(P.X, P.Y, P.Z);
		}
		catch (Exception)
		{
			return new Vec3D();
		}
	}

	public static Pnt3D Pnt6DToPnt3D(Pnt6D P)
	{
		try
		{
			return new Pnt3D(P.X, P.Y, P.Z);
		}
		catch (Exception)
		{
			return new Pnt3D();
		}
	}

	public static Size SizeFToSize(SizeF P)
	{
		try
		{
			return new Size((int)P.Width, (int)P.Height);
		}
		catch (Exception)
		{
			return default(Size);
		}
	}

	public static SizeF SizeToSizeF(Size P)
	{
		try
		{
			return new SizeF(P.Width, P.Height);
		}
		catch (Exception)
		{
			return default(SizeF);
		}
	}

	public static Size StringToSize(string Code)
	{
		try
		{
			string[] array = null;
			array = Code.Split(';');
			Size result = default(Size);
			if (array != null && array.Length >= 2)
			{
				result.Width = int.Parse(array[0]);
				result.Height = int.Parse(array[1]);
			}
			return result;
		}
		catch (Exception)
		{
			return default(Size);
		}
	}

	public static string SizeToString(Size S)
	{
		try
		{
			return "W = " + S.Width + "; H = " + S.Height;
		}
		catch (Exception)
		{
			return "W = 0 ; H = 0";
		}
	}

	public static SizeF StringToSizeF(string Code)
	{
		try
		{
			string[] array = null;
			array = Code.Split(';');
			SizeF result = default(SizeF);
			if (array != null && array.Length >= 2)
			{
				result.Width = float.Parse(array[0]);
				result.Height = float.Parse(array[1]);
			}
			return result;
		}
		catch (Exception)
		{
			return default(SizeF);
		}
	}

	public static string SizeFToString(SizeF S)
	{
		try
		{
			return "W = " + S.Width + "; H = " + S.Height;
		}
		catch (Exception)
		{
			return "W = 0 ; H = 0";
		}
	}

	public static Point StringToPoint(string Code)
	{
		try
		{
			string[] array = null;
			array = Code.Split(';');
			Point result = default(Point);
			if (array != null && array.Length >= 2)
			{
				result.X = int.Parse(array[0]);
				result.Y = int.Parse(array[1]);
			}
			return result;
		}
		catch (Exception)
		{
			return default(Point);
		}
	}

	public static string PointToString(Point S)
	{
		try
		{
			return "X = " + S.X + "; Y = " + S.Y;
		}
		catch (Exception)
		{
			return "X = 0 ; Y = 0";
		}
	}

	public static PointF StringToPointF(string Code)
	{
		try
		{
			string[] array = null;
			array = Code.Split(';');
			PointF result = default(PointF);
			if (array != null && array.Length >= 2)
			{
				result.X = float.Parse(array[0]);
				result.Y = float.Parse(array[1]);
			}
			return result;
		}
		catch (Exception)
		{
			return default(PointF);
		}
	}

	public static string PointFToString(PointF S)
	{
		try
		{
			return "X = " + S.X + "; Y = " + S.Y;
		}
		catch (Exception)
		{
			return "X = 0 ; Y = 0";
		}
	}

	public static bool StringToBool(string Value)
	{
		try
		{
			if (!((Value.Trim() == "1") | (Value.Trim().ToLower() == "true")))
			{
				return false;
			}
			return true;
		}
		catch (Exception)
		{
			return true;
		}
	}

	public static bool IntToBool(int Value)
	{
		try
		{
			if (Value != 0)
			{
				return true;
			}
			return false;
		}
		catch (Exception)
		{
			return true;
		}
	}

	public static bool DoubleToBool(double Value)
	{
		try
		{
			if (Value != 0.0)
			{
				return true;
			}
			return false;
		}
		catch (Exception)
		{
			return true;
		}
	}

	public static bool FloatToBool(float Value)
	{
		try
		{
			if (Value != 0f)
			{
				return true;
			}
			return false;
		}
		catch (Exception)
		{
			return true;
		}
	}

	public static string ColorToString(Color clr, ColorConvertType Type)
	{
		try
		{
			if (Type != ColorConvertType.Html)
			{
				return clr.ToString();
			}
			return ColorTranslator.ToHtml(clr);
		}
		catch (Exception)
		{
			return "Black";
		}
	}

	public static string FontToString(Font fnt)
	{
		try
		{
			FontConverter fontConverter = new FontConverter();
			return fontConverter.ConvertToString(fnt);
		}
		catch (Exception)
		{
			Font value = new Font("Arial", 10f);
			FontConverter fontConverter2 = new FontConverter();
			return fontConverter2.ConvertToString(value);
		}
	}

	public static Color StringToColor(string Code, ColorConvertType Type)
	{
		Color color = default(Color);
		color = Color.Black;
		try
		{
			if (Type != ColorConvertType.Html)
			{
				Code = Code.Replace("Color", "");
				Code = Code.Replace("[", "");
				Code = Code.Replace("]", "");
				Code = Code.Trim();
				Color.FromName(Code);
				return Color.FromName(Code);
			}
			return ColorTranslator.FromHtml(Code);
		}
		catch (Exception)
		{
			return Color.Black;
		}
	}

	public static Font StringToFont(string Code)
	{
		Font result = new Font("Arial", 10f);
		try
		{
			FontConverter fontConverter = new FontConverter();
			result = fontConverter.ConvertFromString(Code) as Font;
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public static List<string> EnumToString(Type enumVal)
	{
		List<string> list = new List<string>();
		Array values = Enum.GetValues(enumVal);
		if (values != null)
		{
			for (int i = 0; i <= values.Length - 1; i++)
			{
				list.Add(values.GetValue(i).ToString());
			}
		}
		return list;
	}

	public static DateTime StringToDateTime(string Code)
	{
		try
		{
			return DateTime.Parse(Code);
		}
		catch (Exception)
		{
			return DateTime.Now;
		}
	}

	public static string DateToString(DateTime Date)
	{
		try
		{
			return Date.Day + "." + Date.Month + "." + Date.Year;
		}
		catch (Exception)
		{
			return "";
		}
	}

	public static string TimeToString(DateTime Date)
	{
		try
		{
			return Date.Hour + ":" + Date.Minute + ":" + Date.Second;
		}
		catch (Exception)
		{
			return "";
		}
	}

	public static void ConvertFromInchToMm(ref camParameters camPar, int Round)
	{
		double num = 25.4;
		camPar.Distances.Air = Math.Round(camPar.Distances.Air * num, Round);
		camPar.Distances.FirstApproach = Math.Round(camPar.Distances.FirstApproach * num, Round);
		camPar.Distances.Safe = Math.Round(camPar.Distances.Safe * num, Round);
		camPar.Distances.SafeSmall = Math.Round(camPar.Distances.SafeSmall * num, Round);
		camPar.Distances.StepUp = Math.Round(camPar.Distances.StepUp * num, Round);
		camPar.Steps.Distance = Math.Round(camPar.Steps.Distance * num, Round);
		camPar.Steps.EndValue = Math.Round(camPar.Steps.EndValue * num, Round);
		camPar.Steps.MoveUp = Math.Round(camPar.Steps.MoveUp * num, Round);
		camPar.Steps.StartValue = Math.Round(camPar.Steps.StartValue * num, Round);
		camPar.Steps.Step = Math.Round(camPar.Steps.Step * num, Round);
		camPar.Offsets.AdditionalOffset = Math.Round(camPar.Offsets.AdditionalOffset * num, Round);
		camPar.Offsets.InCutSafeLength = Math.Round(camPar.Offsets.InCutSafeLength * num, Round);
		camPar.Offsets.Offset = Math.Round(camPar.Offsets.Offset * num, Round);
		camPar.Offsets.OverlapDistance = Math.Round(camPar.Offsets.OverlapDistance * num, Round);
		camPar.Hole.DownStep = Math.Round(camPar.Hole.DownStep * num, Round);
		camPar.Hole.EndHeight = Math.Round(camPar.Hole.EndHeight * num, Round);
		camPar.Hole.StartHeight = Math.Round(camPar.Hole.StartHeight * num, Round);
		camPar.Hole.UpStep = Math.Round(camPar.Hole.UpStep * num, Round);
		camPar.LeadIn.ArcRadius = Math.Round(camPar.LeadIn.ArcRadius * num, Round);
		camPar.LeadIn.ExtendLength = Math.Round(camPar.LeadIn.ExtendLength * num, Round);
		camPar.LeadIn.Length = Math.Round(camPar.LeadIn.Length * num, Round);
		camPar.LeadOut.ArcRadius = Math.Round(camPar.LeadOut.ArcRadius * num, Round);
		camPar.LeadOut.ExtendLength = Math.Round(camPar.LeadOut.ExtendLength * num, Round);
		camPar.LeadOut.Length = Math.Round(camPar.LeadOut.Length * num, Round);
		camPar.Operations.Depth = Math.Round(camPar.Operations.Depth * num, Round);
		camPar.Operations.Height = Math.Round(camPar.Operations.Height * num, Round);
		camPar.Operations.TargetZ = Math.Round(camPar.Operations.TargetZ * num, Round);
		camPar.Operations.Thickness = Math.Round(camPar.Operations.Thickness * num, Round);
		camPar.Options.PocketNextContourMaxDistance = Math.Round(camPar.Options.PocketNextContourMaxDistance * num, Round);
		camPar.Speeds.AreaClearance = Math.Round(camPar.Speeds.AreaClearance * num, Round);
		camPar.Speeds.BackwardFeed = Math.Round(camPar.Speeds.BackwardFeed * num, Round);
		camPar.Speeds.Feed = Math.Round(camPar.Speeds.Feed * num, Round);
		camPar.Speeds.Finish = Math.Round(camPar.Speeds.Finish * num, Round);
		camPar.Speeds.Leave = Math.Round(camPar.Speeds.Leave * num, Round);
		camPar.Speeds.Plunge = Math.Round(camPar.Speeds.Plunge * num, Round);
		camPar.Speeds.Rapid = Math.Round(camPar.Speeds.Rapid * num, Round);
	}

	public static void ConvertFromInchToMm(ref marbleProfileCut Data, int Round)
	{
		double num = 25.4;
		Data.BaseHeight = Math.Round(Data.BaseHeight * num, Round);
		Data.DownDevideLen = Math.Round(Data.DownDevideLen * num, Round);
		Data.FinishDevideLen = Math.Round(Data.FinishDevideLen * num, Round);
		Data.FinishOffset = Math.Round(Data.FinishOffset * num, Round);
		Data.FinishStep = Math.Round(Data.FinishStep * num, Round);
		Data.Length = Math.Round(Data.Length * num, Round);
		Data.RoughtDevideLen = Math.Round(Data.RoughtDevideLen * num, Round);
		Data.RoughtOffset = Math.Round(Data.RoughtOffset * num, Round);
	}

	public static void ConvertFromInchToMm(ref KinematicBase Data, int Round)
	{
		double num = 25.4;
		Data.MovePartRuntimeOffset.X = Math.Round(Data.MovePartRuntimeOffset.X * num, Round);
		Data.MovePartRuntimeOffset.Y = Math.Round(Data.MovePartRuntimeOffset.Y * num, Round);
		Data.MovePartRuntimeOffset.Z = Math.Round(Data.MovePartRuntimeOffset.Z * num, Round);
		Data.OffsetXYZ.X = Math.Round(Data.OffsetXYZ.X * num, Round);
		Data.OffsetXYZ.Y = Math.Round(Data.OffsetXYZ.Y * num, Round);
		Data.OffsetXYZ.Z = Math.Round(Data.OffsetXYZ.Z * num, Round);
		Data.RotateCenterOffsetOfA.X = Math.Round(Data.RotateCenterOffsetOfA.X * num, Round);
		Data.RotateCenterOffsetOfA.Y = Math.Round(Data.RotateCenterOffsetOfA.Y * num, Round);
		Data.RotateCenterOffsetOfA.Z = Math.Round(Data.RotateCenterOffsetOfA.Z * num, Round);
		Data.RotateCenterOffsetOfB.X = Math.Round(Data.RotateCenterOffsetOfB.X * num, Round);
		Data.RotateCenterOffsetOfB.Y = Math.Round(Data.RotateCenterOffsetOfB.Y * num, Round);
		Data.RotateCenterOffsetOfB.Z = Math.Round(Data.RotateCenterOffsetOfB.Z * num, Round);
		Data.RotateCenterOffsetOfC.X = Math.Round(Data.RotateCenterOffsetOfC.X * num, Round);
		Data.RotateCenterOffsetOfC.Y = Math.Round(Data.RotateCenterOffsetOfC.Y * num, Round);
		Data.RotateCenterOffsetOfC.Z = Math.Round(Data.RotateCenterOffsetOfC.Z * num, Round);
	}

	public static void ConvertFromInchToMm(ref marbleOperation Data, int Round)
	{
		double num = 25.4;
		Data.CutLength = Math.Round(Data.CutLength * num, Round);
		Data.CutLengthHorizontal = Math.Round(Data.CutLengthHorizontal * num, Round);
		Data.CutLengthVertical = Math.Round(Data.CutLengthVertical * num, Round);
		Data.CutSawDistanceOverlap = Math.Round(Data.CutSawDistanceOverlap * num, Round);
		Data.InnerCutSafeDistance = Math.Round(Data.InnerCutSafeDistance * num, Round);
		Data.MaterialThickness = Math.Round(Data.MaterialThickness * num, Round);
		Data.OffsetX = Math.Round(Data.OffsetX * num, Round);
		Data.OffsetY = Math.Round(Data.OffsetY * num, Round);
		Data.SawDevideLength = Math.Round(Data.SawDevideLength * num, Round);
		Data.SawRampHeight = Math.Round(Data.SawRampHeight * num, Round);
		Data.SawRampLenght = Math.Round(Data.SawRampLenght * num, Round);
		Data.TargetZ = Math.Round(Data.TargetZ * num, Round);
		Data.CamParameters.AirDistance = Math.Round(Data.CamParameters.AirDistance * num, Round);
		Data.CamParameters.BackwardCuttingVelocity = Math.Round(Data.CamParameters.BackwardCuttingVelocity * num, Round);
		Data.CamParameters.BackwardStepDownDistance = Math.Round(Data.CamParameters.BackwardStepDownDistance * num, Round);
		Data.CamParameters.FirstEnterDistance = Math.Round(Data.CamParameters.FirstEnterDistance * num, Round);
		Data.CamParameters.ForwardCuttingVelocity = Math.Round(Data.CamParameters.ForwardCuttingVelocity * num, Round);
		Data.CamParameters.ForwardStepDownDistance = Math.Round(Data.CamParameters.ForwardStepDownDistance * num, Round);
		Data.CamParameters.LastOutDistance = Math.Round(Data.CamParameters.LastOutDistance * num, Round);
		Data.CamParameters.LeaveVelocity = Math.Round(Data.CamParameters.LeaveVelocity * num, Round);
		Data.CamParameters.PlungeVelocity = Math.Round(Data.CamParameters.PlungeVelocity * num, Round);
		Data.CamParameters.SafeDistance = Math.Round(Data.CamParameters.SafeDistance * num, Round);
		Data.CamParameters.StepUpDistance = Math.Round(Data.CamParameters.StepUpDistance * num, Round);
	}

	public static void ConvertFromInchToMm(ref CodesysAxis Data, int Round)
	{
		double num = 25.4;
		if (!Data.Base.baseRotaryAxis)
		{
			Data.Homings.homingOffset = Math.Round(Data.Homings.homingOffset * num, Round);
			Data.Homings.homingSetPosition = Math.Round(Data.Homings.homingSetPosition * num, Round);
			Data.Homings.homingAcc = Math.Round(Data.Homings.homingAcc * num, Round);
			Data.Homings.homingDec = Math.Round(Data.Homings.homingDec * num, Round);
			Data.Homings.homingFastVelocity = Math.Round(Data.Homings.homingFastVelocity * num, Round);
			Data.Homings.homingJerk = Math.Round(Data.Homings.homingJerk * num, Round);
			Data.Homings.homingSlowVelocity = Math.Round(Data.Homings.homingSlowVelocity * num, Round);
			Data.Jogs.jogAcc = Math.Round(Data.Jogs.jogAcc * num, Round);
			Data.Jogs.jogDec = Math.Round(Data.Jogs.jogDec * num, Round);
			Data.Jogs.jogJerk = Math.Round(Data.Jogs.jogJerk * num, Round);
			Data.Jogs.jogVelocity = Math.Round(Data.Jogs.jogVelocity * num, Round);
			Data.Moves.moveAcc = Math.Round(Data.Moves.moveAcc * num, Round);
			Data.Moves.moveDec = Math.Round(Data.Moves.moveDec * num, Round);
			Data.Moves.moveJerk = Math.Round(Data.Moves.moveJerk * num, Round);
			Data.Moves.moveVelocity = Math.Round(Data.Moves.moveVelocity * num, Round);
			Data.Test.testPosition1 = Math.Round(Data.Test.testPosition1 * num, Round);
			Data.Test.testPosition2 = Math.Round(Data.Test.testPosition2 * num, Round);
			Data.Test.testJogVelocity = Math.Round(Data.Test.testJogVelocity * num, Round);
			Data.Test.testMoveVelocity = Math.Round(Data.Test.testMoveVelocity * num, Round);
			Data.Sets.setDataLimitNegative = Math.Round(Data.Sets.setDataLimitNegative * num, Round);
			Data.Sets.setDataLimitPositive = Math.Round(Data.Sets.setDataLimitPositive * num, Round);
			Data.Sets.setParkPosition = Math.Round(Data.Sets.setParkPosition * num, Round);
			Data.Sets.setPositionDoneLimit = Math.Round(Data.Sets.setPositionDoneLimit * num, Round);
			Data.Sets.setSoftLimitErrorMaxDistance = Math.Round(Data.Sets.setSoftLimitErrorMaxDistance * num, Round);
			Data.Sets.setSoftLimitNegative = Math.Round(Data.Sets.setSoftLimitNegative * num, Round);
			Data.Sets.setSoftLimitPositive = Math.Round(Data.Sets.setSoftLimitPositive * num, Round);
			Data.Sets.setUnit = Math.Round(Data.Sets.setUnit * num, Round);
			Data.Sets.setEmergencyDec = Math.Round(Data.Sets.setEmergencyDec * num, Round);
			Data.Sets.setMaxAcc = Math.Round(Data.Sets.setMaxAcc * num, Round);
			Data.Sets.setMaxDec = Math.Round(Data.Sets.setMaxDec * num, Round);
			Data.Sets.setMaxJerk = Math.Round(Data.Sets.setMaxJerk * num, Round);
			Data.Sets.setMaxVelocity = Math.Round(Data.Sets.setMaxVelocity * num, Round);
			Data.Sets.setSoftLimitErrorDec = Math.Round(Data.Sets.setSoftLimitErrorDec * num, Round);
			Data.Cnc.cncMaxAccDec = Math.Round(Data.Cnc.cncMaxAccDec * num, Round);
			Data.Cnc.cncMaxDifferance = Math.Round(Data.Cnc.cncMaxDifferance * num, Round);
			Data.Cnc.cncMaxFeed = Math.Round(Data.Cnc.cncMaxFeed * num, Round);
		}
	}

	public static void ConvertFromInchToMm(ref ToolBase Data, int Round)
	{
		double num = 25.4;
		Data.CamData.Cutover = Math.Round(Data.CamData.Cutover * num, Round);
		Data.CamData.ExtraOffset = Math.Round(Data.CamData.ExtraOffset * num, Round);
		Data.CamData.OperationHeight = Math.Round(Data.CamData.OperationHeight * num, Round);
		Data.CamData.OperationHeigthForSecond = Math.Round(Data.CamData.OperationHeigthForSecond * num, Round);
		Data.CamData.SafeDistance = Math.Round(Data.CamData.SafeDistance * num, Round);
		Data.CamData.Stepover = Math.Round(Data.CamData.Stepover * num, Round);
		Data.CamData.AreaClearanceSpeed = Math.Round(Data.CamData.AreaClearanceSpeed * num, Round);
		Data.CamData.FeedSpeed = Math.Round(Data.CamData.FeedSpeed * num, Round);
		Data.CamData.FinishSpeed = Math.Round(Data.CamData.FinishSpeed * num, Round);
		Data.CamData.PlungeSpeed = Math.Round(Data.CamData.PlungeSpeed * num, Round);
		Data.Geometry.ArborBottomDiameter = Math.Round(Data.Geometry.ArborBottomDiameter * num, Round);
		Data.Geometry.ArborLength = Math.Round(Data.Geometry.ArborLength * num, Round);
		Data.Geometry.ArborTopDiameter = Math.Round(Data.Geometry.ArborTopDiameter * num, Round);
		Data.Geometry.BottomDiameter = Math.Round(Data.Geometry.BottomDiameter * num, Round);
		Data.Geometry.ConvexTipRadius = Math.Round(Data.Geometry.ConvexTipRadius * num, Round);
		Data.Geometry.CutLength = Math.Round(Data.Geometry.CutLength * num, Round);
		Data.Geometry.Diameter = Math.Round(Data.Geometry.Diameter * num, Round);
		Data.Geometry.FlatnessDiameter = Math.Round(Data.Geometry.FlatnessDiameter * num, Round);
		Data.Geometry.HolderDiameter = Math.Round(Data.Geometry.HolderDiameter * num, Round);
		Data.Geometry.HolderInDiameter = Math.Round(Data.Geometry.HolderInDiameter * num, Round);
		Data.Geometry.HolderLength = Math.Round(Data.Geometry.HolderLength * num, Round);
		Data.Geometry.Length = Math.Round(Data.Geometry.Length * num, Round);
		Data.Geometry.LengthDiameter = Math.Round(Data.Geometry.LengthDiameter * num, Round);
		Data.Geometry.LowerRadius = Math.Round(Data.Geometry.LowerRadius * num, Round);
		Data.Geometry.MaxDiameter = Math.Round(Data.Geometry.MaxDiameter * num, Round);
		Data.Geometry.MinLength = Math.Round(Data.Geometry.MinLength * num, Round);
		Data.Geometry.OutsideDiameter = Math.Round(Data.Geometry.OutsideDiameter * num, Round);
		Data.Geometry.ProfileDiameter = Math.Round(Data.Geometry.ProfileDiameter * num, Round);
		Data.Geometry.RoundRadius = Math.Round(Data.Geometry.RoundRadius * num, Round);
		Data.Geometry.Thickness = Math.Round(Data.Geometry.Thickness * num, Round);
		Data.Geometry.TopDiameter = Math.Round(Data.Geometry.TopDiameter * num, Round);
		Data.Limits.AxesMaxLimits.X = Math.Round(Data.Limits.AxesMaxLimits.X * num, Round);
		Data.Limits.AxesMaxLimits.Y = Math.Round(Data.Limits.AxesMaxLimits.Y * num, Round);
		Data.Limits.AxesMaxLimits.Z = Math.Round(Data.Limits.AxesMaxLimits.Z * num, Round);
		Data.Limits.AxesMinLimits.X = Math.Round(Data.Limits.AxesMinLimits.X * num, Round);
		Data.Limits.AxesMinLimits.Y = Math.Round(Data.Limits.AxesMinLimits.Y * num, Round);
		Data.Limits.AxesMinLimits.Z = Math.Round(Data.Limits.AxesMinLimits.Z * num, Round);
		Data.Positions.Offset.X = Math.Round(Data.Positions.Offset.X * num, Round);
		Data.Positions.Offset.Y = Math.Round(Data.Positions.Offset.Y * num, Round);
		Data.Positions.Offset.Z = Math.Round(Data.Positions.Offset.Z * num, Round);
		Data.Positions.Position.X = Math.Round(Data.Positions.Position.X * num, Round);
		Data.Positions.Position.Y = Math.Round(Data.Positions.Position.Y * num, Round);
		Data.Positions.Position.Z = Math.Round(Data.Positions.Position.Z * num, Round);
	}

	public static void ConvertFromMmToInch(ref camParameters camPar, int Round)
	{
		double num = 0.03937007874015748;
		camPar.Distances.Air = Math.Round(camPar.Distances.Air * num, Round);
		camPar.Distances.FirstApproach = Math.Round(camPar.Distances.FirstApproach * num, Round);
		camPar.Distances.Safe = Math.Round(camPar.Distances.Safe * num, Round);
		camPar.Distances.SafeSmall = Math.Round(camPar.Distances.SafeSmall * num, Round);
		camPar.Distances.StepUp = Math.Round(camPar.Distances.StepUp * num, Round);
		camPar.Steps.Distance = Math.Round(camPar.Steps.Distance * num, Round);
		camPar.Steps.EndValue = Math.Round(camPar.Steps.EndValue * num, Round);
		camPar.Steps.MoveUp = Math.Round(camPar.Steps.MoveUp * num, Round);
		camPar.Steps.StartValue = Math.Round(camPar.Steps.StartValue * num, Round);
		camPar.Steps.Step = Math.Round(camPar.Steps.Step * num, Round);
		camPar.Offsets.AdditionalOffset = Math.Round(camPar.Offsets.AdditionalOffset * num, Round);
		camPar.Offsets.InCutSafeLength = Math.Round(camPar.Offsets.InCutSafeLength * num, Round);
		camPar.Offsets.Offset = Math.Round(camPar.Offsets.Offset * num, Round);
		camPar.Offsets.OverlapDistance = Math.Round(camPar.Offsets.OverlapDistance * num, Round);
		camPar.Hole.DownStep = Math.Round(camPar.Hole.DownStep * num, Round);
		camPar.Hole.EndHeight = Math.Round(camPar.Hole.EndHeight * num, Round);
		camPar.Hole.StartHeight = Math.Round(camPar.Hole.StartHeight * num, Round);
		camPar.Hole.UpStep = Math.Round(camPar.Hole.UpStep * num, Round);
		camPar.LeadIn.ArcRadius = Math.Round(camPar.LeadIn.ArcRadius * num, Round);
		camPar.LeadIn.ExtendLength = Math.Round(camPar.LeadIn.ExtendLength * num, Round);
		camPar.LeadIn.Length = Math.Round(camPar.LeadIn.Length * num, Round);
		camPar.LeadOut.ArcRadius = Math.Round(camPar.LeadOut.ArcRadius * num, Round);
		camPar.LeadOut.ExtendLength = Math.Round(camPar.LeadOut.ExtendLength * num, Round);
		camPar.LeadOut.Length = Math.Round(camPar.LeadOut.Length * num, Round);
		camPar.Operations.Depth = Math.Round(camPar.Operations.Depth * num, Round);
		camPar.Operations.Height = Math.Round(camPar.Operations.Height * num, Round);
		camPar.Operations.TargetZ = Math.Round(camPar.Operations.TargetZ * num, Round);
		camPar.Operations.Thickness = Math.Round(camPar.Operations.Thickness * num, Round);
		camPar.Options.PocketNextContourMaxDistance = Math.Round(camPar.Options.PocketNextContourMaxDistance * num, Round);
		camPar.Speeds.AreaClearance = Math.Round(camPar.Speeds.AreaClearance * num, Round);
		camPar.Speeds.BackwardFeed = Math.Round(camPar.Speeds.BackwardFeed * num, Round);
		camPar.Speeds.Feed = Math.Round(camPar.Speeds.Feed * num, Round);
		camPar.Speeds.Finish = Math.Round(camPar.Speeds.Finish * num, Round);
		camPar.Speeds.Leave = Math.Round(camPar.Speeds.Leave * num, Round);
		camPar.Speeds.Plunge = Math.Round(camPar.Speeds.Plunge * num, Round);
		camPar.Speeds.Rapid = Math.Round(camPar.Speeds.Rapid * num, Round);
	}

	public static void ConvertFromMmToInch(ref marbleProfileCut Data, int Round)
	{
		double num = 0.03937007874015748;
		Data.BaseHeight = Math.Round(Data.BaseHeight * num, Round);
		Data.DownDevideLen = Math.Round(Data.DownDevideLen * num, Round);
		Data.FinishDevideLen = Math.Round(Data.FinishDevideLen * num, Round);
		Data.FinishOffset = Math.Round(Data.FinishOffset * num, Round);
		Data.FinishStep = Math.Round(Data.FinishStep * num, Round);
		Data.Length = Math.Round(Data.Length * num, Round);
		Data.RoughtDevideLen = Math.Round(Data.RoughtDevideLen * num, Round);
		Data.RoughtOffset = Math.Round(Data.RoughtOffset * num, Round);
	}

	public static void ConvertFromMmToInch(ref marbleOperation Data, int Round)
	{
		double num = 0.03937007874015748;
		Data.CutLength = Math.Round(Data.CutLength * num, Round);
		Data.CutLengthHorizontal = Math.Round(Data.CutLengthHorizontal * num, Round);
		Data.CutLengthVertical = Math.Round(Data.CutLengthVertical * num, Round);
		Data.CutSawDistanceOverlap = Math.Round(Data.CutSawDistanceOverlap * num, Round);
		Data.InnerCutSafeDistance = Math.Round(Data.InnerCutSafeDistance * num, Round);
		Data.MaterialThickness = Math.Round(Data.MaterialThickness * num, Round);
		Data.OffsetX = Math.Round(Data.OffsetX * num, Round);
		Data.OffsetY = Math.Round(Data.OffsetY * num, Round);
		Data.SawDevideLength = Math.Round(Data.SawDevideLength * num, Round);
		Data.SawRampHeight = Math.Round(Data.SawRampHeight * num, Round);
		Data.SawRampLenght = Math.Round(Data.SawRampLenght * num, Round);
		Data.TargetZ = Math.Round(Data.TargetZ * num, Round);
		Data.CamParameters.AirDistance = Math.Round(Data.CamParameters.AirDistance * num, Round);
		Data.CamParameters.BackwardCuttingVelocity = Math.Round(Data.CamParameters.BackwardCuttingVelocity * num, Round);
		Data.CamParameters.BackwardStepDownDistance = Math.Round(Data.CamParameters.BackwardStepDownDistance * num, Round);
		Data.CamParameters.FirstEnterDistance = Math.Round(Data.CamParameters.FirstEnterDistance * num, Round);
		Data.CamParameters.ForwardCuttingVelocity = Math.Round(Data.CamParameters.ForwardCuttingVelocity * num, Round);
		Data.CamParameters.ForwardStepDownDistance = Math.Round(Data.CamParameters.ForwardStepDownDistance * num, Round);
		Data.CamParameters.LastOutDistance = Math.Round(Data.CamParameters.LastOutDistance * num, Round);
		Data.CamParameters.LeaveVelocity = Math.Round(Data.CamParameters.LeaveVelocity * num, Round);
		Data.CamParameters.PlungeVelocity = Math.Round(Data.CamParameters.PlungeVelocity * num, Round);
		Data.CamParameters.SafeDistance = Math.Round(Data.CamParameters.SafeDistance * num, Round);
		Data.CamParameters.StepUpDistance = Math.Round(Data.CamParameters.StepUpDistance * num, Round);
	}

	public static void ConvertFromMmToInch(ref KinematicBase Data, int Round)
	{
		double num = 0.03937007874015748;
		Data.MovePartRuntimeOffset.X = Math.Round(Data.MovePartRuntimeOffset.X * num, Round);
		Data.MovePartRuntimeOffset.Y = Math.Round(Data.MovePartRuntimeOffset.Y * num, Round);
		Data.MovePartRuntimeOffset.Z = Math.Round(Data.MovePartRuntimeOffset.Z * num, Round);
		Data.OffsetXYZ.X = Math.Round(Data.OffsetXYZ.X * num, Round);
		Data.OffsetXYZ.Y = Math.Round(Data.OffsetXYZ.Y * num, Round);
		Data.OffsetXYZ.Z = Math.Round(Data.OffsetXYZ.Z * num, Round);
		Data.RotateCenterOffsetOfA.X = Math.Round(Data.RotateCenterOffsetOfA.X * num, Round);
		Data.RotateCenterOffsetOfA.Y = Math.Round(Data.RotateCenterOffsetOfA.Y * num, Round);
		Data.RotateCenterOffsetOfA.Z = Math.Round(Data.RotateCenterOffsetOfA.Z * num, Round);
		Data.RotateCenterOffsetOfB.X = Math.Round(Data.RotateCenterOffsetOfB.X * num, Round);
		Data.RotateCenterOffsetOfB.Y = Math.Round(Data.RotateCenterOffsetOfB.Y * num, Round);
		Data.RotateCenterOffsetOfB.Z = Math.Round(Data.RotateCenterOffsetOfB.Z * num, Round);
		Data.RotateCenterOffsetOfC.X = Math.Round(Data.RotateCenterOffsetOfC.X * num, Round);
		Data.RotateCenterOffsetOfC.Y = Math.Round(Data.RotateCenterOffsetOfC.Y * num, Round);
		Data.RotateCenterOffsetOfC.Z = Math.Round(Data.RotateCenterOffsetOfC.Z * num, Round);
	}

	public static void ConvertFromMmToInch(ref CodesysAxis Data, int Round)
	{
		double num = 0.03937007874015748;
		if (!Data.Base.baseRotaryAxis)
		{
			Data.Homings.homingOffset = Math.Round(Data.Homings.homingOffset * num, Round);
			Data.Homings.homingSetPosition = Math.Round(Data.Homings.homingSetPosition * num, Round);
			Data.Homings.homingAcc = Math.Round(Data.Homings.homingAcc * num, Round);
			Data.Homings.homingDec = Math.Round(Data.Homings.homingDec * num, Round);
			Data.Homings.homingFastVelocity = Math.Round(Data.Homings.homingFastVelocity * num, Round);
			Data.Homings.homingJerk = Math.Round(Data.Homings.homingJerk * num, Round);
			Data.Homings.homingSlowVelocity = Math.Round(Data.Homings.homingSlowVelocity * num, Round);
			Data.Jogs.jogAcc = Math.Round(Data.Jogs.jogAcc * num, Round);
			Data.Jogs.jogDec = Math.Round(Data.Jogs.jogDec * num, Round);
			Data.Jogs.jogJerk = Math.Round(Data.Jogs.jogJerk * num, Round);
			Data.Jogs.jogVelocity = Math.Round(Data.Jogs.jogVelocity * num, Round);
			Data.Moves.moveAcc = Math.Round(Data.Moves.moveAcc * num, Round);
			Data.Moves.moveDec = Math.Round(Data.Moves.moveDec * num, Round);
			Data.Moves.moveJerk = Math.Round(Data.Moves.moveJerk * num, Round);
			Data.Moves.moveVelocity = Math.Round(Data.Moves.moveVelocity * num, Round);
			Data.Test.testPosition1 = Math.Round(Data.Test.testPosition1 * num, Round);
			Data.Test.testPosition2 = Math.Round(Data.Test.testPosition2 * num, Round);
			Data.Test.testJogVelocity = Math.Round(Data.Test.testJogVelocity * num, Round);
			Data.Test.testMoveVelocity = Math.Round(Data.Test.testMoveVelocity * num, Round);
			Data.Sets.setDataLimitNegative = Math.Round(Data.Sets.setDataLimitNegative * num, Round);
			Data.Sets.setDataLimitPositive = Math.Round(Data.Sets.setDataLimitPositive * num, Round);
			Data.Sets.setParkPosition = Math.Round(Data.Sets.setParkPosition * num, Round);
			Data.Sets.setPositionDoneLimit = Math.Round(Data.Sets.setPositionDoneLimit * num, Round);
			Data.Sets.setSoftLimitErrorMaxDistance = Math.Round(Data.Sets.setSoftLimitErrorMaxDistance * num, Round);
			Data.Sets.setSoftLimitNegative = Math.Round(Data.Sets.setSoftLimitNegative * num, Round);
			Data.Sets.setSoftLimitPositive = Math.Round(Data.Sets.setSoftLimitPositive * num, Round);
			Data.Sets.setUnit = Math.Round(Data.Sets.setUnit * num, Round);
			Data.Sets.setEmergencyDec = Math.Round(Data.Sets.setEmergencyDec * num, Round);
			Data.Sets.setMaxAcc = Math.Round(Data.Sets.setMaxAcc * num, Round);
			Data.Sets.setMaxDec = Math.Round(Data.Sets.setMaxDec * num, Round);
			Data.Sets.setMaxJerk = Math.Round(Data.Sets.setMaxJerk * num, Round);
			Data.Sets.setMaxVelocity = Math.Round(Data.Sets.setMaxVelocity * num, Round);
			Data.Sets.setSoftLimitErrorDec = Math.Round(Data.Sets.setSoftLimitErrorDec * num, Round);
			Data.Cnc.cncMaxAccDec = Math.Round(Data.Cnc.cncMaxAccDec * num, Round);
			Data.Cnc.cncMaxDifferance = Math.Round(Data.Cnc.cncMaxDifferance * num, Round);
			Data.Cnc.cncMaxFeed = Math.Round(Data.Cnc.cncMaxFeed * num, Round);
		}
	}

	public static void ConvertFromMmToInch(ref ToolBase Data, int Round)
	{
		double num = 0.03937007874015748;
		Data.CamData.Cutover = Math.Round(Data.CamData.Cutover * num, Round);
		Data.CamData.ExtraOffset = Math.Round(Data.CamData.ExtraOffset * num, Round);
		Data.CamData.OperationHeight = Math.Round(Data.CamData.OperationHeight * num, Round);
		Data.CamData.OperationHeigthForSecond = Math.Round(Data.CamData.OperationHeigthForSecond * num, Round);
		Data.CamData.SafeDistance = Math.Round(Data.CamData.SafeDistance * num, Round);
		Data.CamData.Stepover = Math.Round(Data.CamData.Stepover * num, Round);
		Data.CamData.AreaClearanceSpeed = Math.Round(Data.CamData.AreaClearanceSpeed * num, Round);
		Data.CamData.FeedSpeed = Math.Round(Data.CamData.FeedSpeed * num, Round);
		Data.CamData.FinishSpeed = Math.Round(Data.CamData.FinishSpeed * num, Round);
		Data.CamData.PlungeSpeed = Math.Round(Data.CamData.PlungeSpeed * num, Round);
		Data.Geometry.ArborBottomDiameter = Math.Round(Data.Geometry.ArborBottomDiameter * num, Round);
		Data.Geometry.ArborLength = Math.Round(Data.Geometry.ArborLength * num, Round);
		Data.Geometry.ArborTopDiameter = Math.Round(Data.Geometry.ArborTopDiameter * num, Round);
		Data.Geometry.BottomDiameter = Math.Round(Data.Geometry.BottomDiameter * num, Round);
		Data.Geometry.ConvexTipRadius = Math.Round(Data.Geometry.ConvexTipRadius * num, Round);
		Data.Geometry.CutLength = Math.Round(Data.Geometry.CutLength * num, Round);
		Data.Geometry.Diameter = Math.Round(Data.Geometry.Diameter * num, Round);
		Data.Geometry.FlatnessDiameter = Math.Round(Data.Geometry.FlatnessDiameter * num, Round);
		Data.Geometry.HolderDiameter = Math.Round(Data.Geometry.HolderDiameter * num, Round);
		Data.Geometry.HolderInDiameter = Math.Round(Data.Geometry.HolderInDiameter * num, Round);
		Data.Geometry.HolderLength = Math.Round(Data.Geometry.HolderLength * num, Round);
		Data.Geometry.Length = Math.Round(Data.Geometry.Length * num, Round);
		Data.Geometry.LengthDiameter = Math.Round(Data.Geometry.LengthDiameter * num, Round);
		Data.Geometry.LowerRadius = Math.Round(Data.Geometry.LowerRadius * num, Round);
		Data.Geometry.MaxDiameter = Math.Round(Data.Geometry.MaxDiameter * num, Round);
		Data.Geometry.MinLength = Math.Round(Data.Geometry.MinLength * num, Round);
		Data.Geometry.OutsideDiameter = Math.Round(Data.Geometry.OutsideDiameter * num, Round);
		Data.Geometry.ProfileDiameter = Math.Round(Data.Geometry.ProfileDiameter * num, Round);
		Data.Geometry.RoundRadius = Math.Round(Data.Geometry.RoundRadius * num, Round);
		Data.Geometry.Thickness = Math.Round(Data.Geometry.Thickness * num, Round);
		Data.Geometry.TopDiameter = Math.Round(Data.Geometry.TopDiameter * num, Round);
		Data.Limits.AxesMaxLimits.X = Math.Round(Data.Limits.AxesMaxLimits.X * num, Round);
		Data.Limits.AxesMaxLimits.Y = Math.Round(Data.Limits.AxesMaxLimits.Y * num, Round);
		Data.Limits.AxesMaxLimits.Z = Math.Round(Data.Limits.AxesMaxLimits.Z * num, Round);
		Data.Limits.AxesMinLimits.X = Math.Round(Data.Limits.AxesMinLimits.X * num, Round);
		Data.Limits.AxesMinLimits.Y = Math.Round(Data.Limits.AxesMinLimits.Y * num, Round);
		Data.Limits.AxesMinLimits.Z = Math.Round(Data.Limits.AxesMinLimits.Z * num, Round);
		Data.Positions.Offset.X = Math.Round(Data.Positions.Offset.X * num, Round);
		Data.Positions.Offset.Y = Math.Round(Data.Positions.Offset.Y * num, Round);
		Data.Positions.Offset.Z = Math.Round(Data.Positions.Offset.Z * num, Round);
		Data.Positions.Position.X = Math.Round(Data.Positions.Position.X * num, Round);
		Data.Positions.Position.Y = Math.Round(Data.Positions.Position.Y * num, Round);
		Data.Positions.Position.Z = Math.Round(Data.Positions.Position.Z * num, Round);
	}

	public static string ToolDirectionToString(Vec3D Direction)
	{
		string result = "-Z";
		if (Direction.Z == 1.0)
		{
			result = "+Z";
		}
		if (Direction.Z == -1.0)
		{
			result = "-Z";
		}
		if (Direction.X == 1.0)
		{
			result = "+X";
		}
		if (Direction.X == -1.0)
		{
			result = "-X";
		}
		if (Direction.Y == 1.0)
		{
			result = "+Y";
		}
		if (Direction.Y == -1.0)
		{
			result = "-Y";
		}
		return result;
	}

	public static InOutCenterType InOutCenterNoneToInOutCenter(InOutCenterNoneType Type)
	{
		return Type switch
		{
			InOutCenterNoneType.Inside => InOutCenterType.Inside, 
			InOutCenterNoneType.Outside => InOutCenterType.Outside, 
			InOutCenterNoneType.Center => InOutCenterType.Center, 
			_ => InOutCenterType.Center, 
		};
	}

	public static InOutCenterNoneType InOutCenterToInOutCenterNone(InOutCenterType Type)
	{
		return Type switch
		{
			InOutCenterType.Inside => InOutCenterNoneType.Inside, 
			InOutCenterType.Outside => InOutCenterNoneType.Outside, 
			_ => InOutCenterNoneType.Center, 
		};
	}
}
