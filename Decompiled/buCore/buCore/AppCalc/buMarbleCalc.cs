using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using buClass;
using buClass.Apps;

namespace buCore.AppCalc;

public class buMarbleCalc
{
	[CompilerGenerated]
	private CalculationEventHandler calculationEventHandler_0;

	[CompilerGenerated]
	private CalculationEventHandler calculationEventHandler_1;

	[CompilerGenerated]
	private CalculationEventHandler calculationEventHandler_2;

	[CompilerGenerated]
	private CalculationEventHandler calculationEventHandler_3;

	[CompilerGenerated]
	private CalculationErrorEventHandler calculationErrorEventHandler_0;

	public static List<marbleCutItems> itemsMultiCut = new List<marbleCutItems>();

	public static List<marbleCutItems> itemsPerpendicularCutHor = new List<marbleCutItems>();

	public static List<marbleCutItems> itemsPerpendicularCutVer = new List<marbleCutItems>();

	public static List<string> LangMarbleStatus = new List<string>();

	public static List<string> LangMarbleMessage = new List<string>();

	public static List<string> LangMarbleCaptions = new List<string>();

	public static List<List<Pnt3D>> pntTeachGrids = new List<List<Pnt3D>>();

	public event CalculationEventHandler CalculationInProgress
	{
		[CompilerGenerated]
		add
		{
			CalculationEventHandler calculationEventHandler = calculationEventHandler_0;
			CalculationEventHandler calculationEventHandler2;
			do
			{
				calculationEventHandler2 = calculationEventHandler;
				CalculationEventHandler value2 = (CalculationEventHandler)Delegate.Combine(calculationEventHandler2, value);
				calculationEventHandler = Interlocked.CompareExchange(ref calculationEventHandler_0, value2, calculationEventHandler2);
			}
			while ((object)calculationEventHandler != calculationEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CalculationEventHandler calculationEventHandler = calculationEventHandler_0;
			CalculationEventHandler calculationEventHandler2;
			do
			{
				calculationEventHandler2 = calculationEventHandler;
				CalculationEventHandler value2 = (CalculationEventHandler)Delegate.Remove(calculationEventHandler2, value);
				calculationEventHandler = Interlocked.CompareExchange(ref calculationEventHandler_0, value2, calculationEventHandler2);
			}
			while ((object)calculationEventHandler != calculationEventHandler2);
		}
	}

	public event CalculationEventHandler CalculationStarted
	{
		[CompilerGenerated]
		add
		{
			CalculationEventHandler calculationEventHandler = calculationEventHandler_1;
			CalculationEventHandler calculationEventHandler2;
			do
			{
				calculationEventHandler2 = calculationEventHandler;
				CalculationEventHandler value2 = (CalculationEventHandler)Delegate.Combine(calculationEventHandler2, value);
				calculationEventHandler = Interlocked.CompareExchange(ref calculationEventHandler_1, value2, calculationEventHandler2);
			}
			while ((object)calculationEventHandler != calculationEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CalculationEventHandler calculationEventHandler = calculationEventHandler_1;
			CalculationEventHandler calculationEventHandler2;
			do
			{
				calculationEventHandler2 = calculationEventHandler;
				CalculationEventHandler value2 = (CalculationEventHandler)Delegate.Remove(calculationEventHandler2, value);
				calculationEventHandler = Interlocked.CompareExchange(ref calculationEventHandler_1, value2, calculationEventHandler2);
			}
			while ((object)calculationEventHandler != calculationEventHandler2);
		}
	}

	public event CalculationEventHandler CalculationEnded
	{
		[CompilerGenerated]
		add
		{
			CalculationEventHandler calculationEventHandler = calculationEventHandler_2;
			CalculationEventHandler calculationEventHandler2;
			do
			{
				calculationEventHandler2 = calculationEventHandler;
				CalculationEventHandler value2 = (CalculationEventHandler)Delegate.Combine(calculationEventHandler2, value);
				calculationEventHandler = Interlocked.CompareExchange(ref calculationEventHandler_2, value2, calculationEventHandler2);
			}
			while ((object)calculationEventHandler != calculationEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CalculationEventHandler calculationEventHandler = calculationEventHandler_2;
			CalculationEventHandler calculationEventHandler2;
			do
			{
				calculationEventHandler2 = calculationEventHandler;
				CalculationEventHandler value2 = (CalculationEventHandler)Delegate.Remove(calculationEventHandler2, value);
				calculationEventHandler = Interlocked.CompareExchange(ref calculationEventHandler_2, value2, calculationEventHandler2);
			}
			while ((object)calculationEventHandler != calculationEventHandler2);
		}
	}

	public event CalculationEventHandler CalculationCanceled
	{
		[CompilerGenerated]
		add
		{
			CalculationEventHandler calculationEventHandler = calculationEventHandler_3;
			CalculationEventHandler calculationEventHandler2;
			do
			{
				calculationEventHandler2 = calculationEventHandler;
				CalculationEventHandler value2 = (CalculationEventHandler)Delegate.Combine(calculationEventHandler2, value);
				calculationEventHandler = Interlocked.CompareExchange(ref calculationEventHandler_3, value2, calculationEventHandler2);
			}
			while ((object)calculationEventHandler != calculationEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CalculationEventHandler calculationEventHandler = calculationEventHandler_3;
			CalculationEventHandler calculationEventHandler2;
			do
			{
				calculationEventHandler2 = calculationEventHandler;
				CalculationEventHandler value2 = (CalculationEventHandler)Delegate.Remove(calculationEventHandler2, value);
				calculationEventHandler = Interlocked.CompareExchange(ref calculationEventHandler_3, value2, calculationEventHandler2);
			}
			while ((object)calculationEventHandler != calculationEventHandler2);
		}
	}

	public event CalculationErrorEventHandler CalculationError
	{
		[CompilerGenerated]
		add
		{
			CalculationErrorEventHandler calculationErrorEventHandler = calculationErrorEventHandler_0;
			CalculationErrorEventHandler calculationErrorEventHandler2;
			do
			{
				calculationErrorEventHandler2 = calculationErrorEventHandler;
				CalculationErrorEventHandler value2 = (CalculationErrorEventHandler)Delegate.Combine(calculationErrorEventHandler2, value);
				calculationErrorEventHandler = Interlocked.CompareExchange(ref calculationErrorEventHandler_0, value2, calculationErrorEventHandler2);
			}
			while ((object)calculationErrorEventHandler != calculationErrorEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CalculationErrorEventHandler calculationErrorEventHandler = calculationErrorEventHandler_0;
			CalculationErrorEventHandler calculationErrorEventHandler2;
			do
			{
				calculationErrorEventHandler2 = calculationErrorEventHandler;
				CalculationErrorEventHandler value2 = (CalculationErrorEventHandler)Delegate.Remove(calculationErrorEventHandler2, value);
				calculationErrorEventHandler = Interlocked.CompareExchange(ref calculationErrorEventHandler_0, value2, calculationErrorEventHandler2);
			}
			while ((object)calculationErrorEventHandler != calculationErrorEventHandler2);
		}
	}

	public buMarbleCalc()
	{
		if (buVector.smethod_0("buMarbleCalc"))
		{
			if (calculationEventHandler_0 != null)
			{
				calculationEventHandler_0(new CalculationEventArg(0.0, 0.0, 0, "", ""));
			}
			if (calculationEventHandler_1 != null)
			{
				calculationEventHandler_1(new CalculationEventArg(0.0, 0.0, 0, "", ""));
			}
			if (calculationEventHandler_2 != null)
			{
				calculationEventHandler_2(new CalculationEventArg(0.0, 0.0, 0, "", ""));
			}
			if (calculationEventHandler_3 != null)
			{
				calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "", ""));
			}
			if (calculationErrorEventHandler_0 != null)
			{
				calculationErrorEventHandler_0(new CalculationErrorEventArg("", "", "", 0));
			}
			return;
		}
		throw new RegisterException("buMarbleCalc");
	}

	public void MarbleItemHeightByDirection(CamCuttingDirectionType CutDir, HeightStepCalculationType StepType, double ForwardStep, double BackwardStep, double StartZ, double EndZ, Pnt3D StartPoint, Pnt3D EndPoint, ref List<Pnt3D> CalcPoints)
	{
		try
		{
			List<double> CalculatedHeight = new List<double>();
			CalcPoints.Clear();
			if (CutDir == CamCuttingDirectionType.Forward)
			{
				buAppCalc.cVector.StepLengthCalculation(StepType, ForwardStep, StartZ, EndZ, ref CalculatedHeight);
				for (int i = 0; i <= CalculatedHeight.Count - 1; i++)
				{
					Pnt3D CalcPoint = new Pnt3D();
					buAppCalc.cVector.XYFromZ(StartPoint, EndPoint, CalculatedHeight[i], ref CalcPoint);
					CalcPoints.Add(CalcPoint);
				}
			}
			if (CutDir == CamCuttingDirectionType.Backward)
			{
				buAppCalc.cVector.StepLengthCalculation(StepType, BackwardStep, StartZ, EndZ, ref CalculatedHeight);
				for (int j = 0; j <= CalculatedHeight.Count - 1; j++)
				{
					Pnt3D CalcPoint2 = new Pnt3D();
					buAppCalc.cVector.XYFromZ(StartPoint, EndPoint, CalculatedHeight[j], ref CalcPoint2);
					CalcPoints.Add(CalcPoint2);
				}
			}
			if (CutDir != CamCuttingDirectionType.ForwardBackward)
			{
				return;
			}
			buAppCalc.cVector.StepLengthCalculation(StepType, ForwardStep + BackwardStep, StartZ, EndZ, ref CalculatedHeight);
			List<double> list = new List<double>();
			double num = StartZ;
			for (int k = 0; k <= CalculatedHeight.Count - 1; k++)
			{
				double num2 = num - CalculatedHeight[k];
				double num3 = BackwardStep / num2;
				if (!(num2 >= ForwardStep + BackwardStep))
				{
					list.Add(CalculatedHeight[k]);
				}
				else
				{
					list.Add(num2 * num3 + CalculatedHeight[k]);
					list.Add(CalculatedHeight[k]);
				}
				num = CalculatedHeight[k];
			}
			buGeneral.CopyLists(list, ref CalculatedHeight);
			for (int l = 0; l <= CalculatedHeight.Count - 1; l++)
			{
				Pnt3D CalcPoint3 = new Pnt3D();
				buAppCalc.cVector.XYFromZ(StartPoint, EndPoint, CalculatedHeight[l], ref CalcPoint3);
				CalcPoints.Add(CalcPoint3);
			}
		}
		catch (Exception mSException)
		{
			string text = "CutDir: " + CutDir.ToString() + " - StepType: " + StepType.ToString() + " - ForwardStep: " + ForwardStep + " - BackwardStep: " + BackwardStep + " - StepStartZ: " + StartZ + " - EndZ: " + EndZ;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public bool MarbleItemEntitiesCalculation(Pnt3D StartPoint, Pnt3D EndPoint, double MaterialThickness, double ToolThickness, double PitchAngle, double TangentAngle, bool Perpendicular, marbleOperation OperationPars, List<marbleCutItems> Items, ref List<List<eEntities>> CalcEntities, ref List<Quad3D> ItemSlices)
	{
		try
		{
			List<eEntities> list = new List<eEntities>();
			Pnt3D EndPnt = new Pnt3D(StartPoint);
			Pnt3D EndPnt2 = new Pnt3D(EndPoint);
			Pnt3D BasePnt = new Pnt3D();
			Pnt3D pnt3D = new Pnt3D();
			new Pnt9D();
			int num = 0;
			int num2 = 0;
			double num3 = MaterialThickness;
			double num4 = MaterialThickness - OperationPars.TargetZ;
			double num5 = OperationPars.CamParameters.ForwardStepDownDistance;
			double num6 = ToolThickness / 2.0;
			double num7 = 0.0;
			CalcEntities = new List<List<eEntities>>();
			if (OperationPars.CamParameters.FirstEnterDistance > 0.0)
			{
				buAppCalc.cVector.LineWithLengthAndAngle(StartPoint, OperationPars.CamParameters.FirstEnterDistance, TangentAngle + 180.0, new WorkPlane(), ref BasePnt, ref EndPnt);
			}
			if (OperationPars.CamParameters.LastOutDistance > 0.0)
			{
				buAppCalc.cVector.LineWithLengthAndAngle(EndPoint, OperationPars.CamParameters.LastOutDistance, TangentAngle, new WorkPlane(), ref BasePnt, ref EndPnt2);
			}
			Pnt3D pnt3D2 = new Pnt3D(EndPnt);
			Pnt3D pnt3D3 = new Pnt3D(EndPnt2);
			Pnt3D pnt3D4 = new Pnt3D();
			Pnt3D pnt3D5 = new Pnt3D();
			Pnt3D pnt3D6 = new Pnt3D();
			Pnt3D pnt3D7 = new Pnt3D();
			for (int i = 0; i <= Items.Count - 1; i++)
			{
				eLine eLine2 = new eLine();
				double num8 = 0.0;
				if (!Perpendicular)
				{
					_ = (Items[i].Length + ToolThickness) / Math.Cos(buConversion.DegreeToRadian(TangentAngle));
					num8 = Items[i].Length / Math.Cos(buConversion.DegreeToRadian(TangentAngle));
					num6 = ToolThickness / Math.Cos(buConversion.DegreeToRadian(TangentAngle));
					num7 = ToolThickness * 0.5 / Math.Cos(buConversion.DegreeToRadian(TangentAngle));
					for (int j = 0; j <= Items[i].Count - 1; j++)
					{
						pnt3D2 = new Pnt3D(EndPnt.X, EndPnt.Y + num6, EndPnt.Z);
						pnt3D3 = new Pnt3D(EndPnt2.X, EndPnt2.Y + num6, EndPnt2.Z);
						pnt3D4 = new Pnt3D(pnt3D2.X, pnt3D2.Y + num8, pnt3D2.Z);
						pnt3D5 = new Pnt3D(pnt3D3.X, pnt3D3.Y + num8, pnt3D3.Z);
						Quad3D item = new Quad3D(pnt3D2, pnt3D3, pnt3D5, pnt3D4);
						ItemSlices.Add(item);
						if (i == 0 && j == 0)
						{
							pnt3D6 = new Pnt3D(pnt3D2.X, pnt3D2.Y - num7, pnt3D2.Z);
							pnt3D7 = new Pnt3D(pnt3D3.X, pnt3D3.Y - num7, pnt3D3.Z);
							eLine2 = new eLine(pnt3D6, pnt3D7);
							eLine2.Orientation = new OrientationAngle(Items[i].StartAngle, 0.0, TangentAngle);
							list.Add(eLine2);
						}
						if ((i > 0) | ((j > 0) & (list[list.Count - 1].Orientation.A != Items[i].StartAngle)))
						{
							pnt3D6 = new Pnt3D(pnt3D2.X, pnt3D2.Y - num7, pnt3D2.Z);
							pnt3D7 = new Pnt3D(pnt3D3.X, pnt3D3.Y - num7, pnt3D3.Z);
							eLine2 = new eLine(pnt3D6, pnt3D7);
							eLine2.Orientation = new OrientationAngle(Items[i].StartAngle, 0.0, TangentAngle);
							list.Add(eLine2);
						}
						pnt3D6 = new Pnt3D(pnt3D4.X, pnt3D4.Y + num7, pnt3D4.Z);
						pnt3D7 = new Pnt3D(pnt3D5.X, pnt3D5.Y + num7, pnt3D5.Z);
						eLine2 = new eLine(pnt3D6, pnt3D7);
						eLine2.Orientation = new OrientationAngle(Items[i].EndAngle * -1.0, 0.0, TangentAngle);
						list.Add(eLine2);
						EndPnt = new Pnt3D(pnt3D4);
						EndPnt2 = new Pnt3D(pnt3D5);
					}
				}
				if (!Perpendicular)
				{
					continue;
				}
				_ = (Items[i].Length + ToolThickness) / Math.Sin(buConversion.DegreeToRadian(TangentAngle));
				num8 = Items[i].Length / Math.Sin(buConversion.DegreeToRadian(TangentAngle));
				num6 = ToolThickness / Math.Sin(buConversion.DegreeToRadian(TangentAngle));
				num7 = ToolThickness * 0.5 / Math.Sin(buConversion.DegreeToRadian(TangentAngle));
				for (int k = 0; k <= Items[i].Count - 1; k++)
				{
					pnt3D2 = new Pnt3D(EndPnt.X + num6, EndPnt.Y, EndPnt.Z);
					pnt3D3 = new Pnt3D(EndPnt2.X + num6, EndPnt2.Y, EndPnt2.Z);
					pnt3D4 = new Pnt3D(pnt3D2.X + num8, pnt3D2.Y, pnt3D2.Z);
					pnt3D5 = new Pnt3D(pnt3D3.X + num8, pnt3D3.Y, pnt3D3.Z);
					Quad3D item2 = new Quad3D(pnt3D2, pnt3D3, pnt3D5, pnt3D4);
					ItemSlices.Add(item2);
					if (i == 0 && k == 0)
					{
						pnt3D6 = new Pnt3D(pnt3D2.X - num7, pnt3D2.Y, pnt3D2.Z);
						pnt3D7 = new Pnt3D(pnt3D3.X - num7, pnt3D3.Y, pnt3D3.Z);
						eLine2 = new eLine(pnt3D6, pnt3D7);
						eLine2.Orientation = new OrientationAngle(Items[i].StartAngle, 0.0, TangentAngle);
						list.Add(eLine2);
					}
					if ((i > 0) | ((k > 0) & (list[list.Count - 1].Orientation.A != Items[i].StartAngle)))
					{
						pnt3D6 = new Pnt3D(pnt3D2.X - num7, pnt3D2.Y, pnt3D2.Z);
						pnt3D7 = new Pnt3D(pnt3D3.X - num7, pnt3D3.Y, pnt3D3.Z);
						eLine2 = new eLine(pnt3D6, pnt3D7);
						eLine2.Orientation = new OrientationAngle(Items[i].StartAngle, 0.0, TangentAngle);
						list.Add(eLine2);
					}
					pnt3D6 = new Pnt3D(pnt3D4.X + num7, pnt3D4.Y, pnt3D4.Z);
					pnt3D7 = new Pnt3D(pnt3D5.X + num7, pnt3D5.Y, pnt3D5.Z);
					eLine2 = new eLine(pnt3D6, pnt3D7);
					eLine2.Orientation = new OrientationAngle(Items[i].EndAngle * -1.0, 0.0, TangentAngle);
					list.Add(eLine2);
					EndPnt = new Pnt3D(pnt3D4);
					EndPnt2 = new Pnt3D(pnt3D5);
				}
			}
			new Pnt9D(EndPnt.X, EndPnt.Y, 0.0);
			if (OperationPars.CamParameters.CuttingDirection == CamCuttingDirectionType.Forward)
			{
				num5 = OperationPars.CamParameters.ForwardStepDownDistance;
			}
			if (OperationPars.CamParameters.CuttingDirection == CamCuttingDirectionType.Backward)
			{
				num5 = OperationPars.CamParameters.BackwardStepDownDistance;
			}
			if (OperationPars.CamParameters.CuttingDirection == CamCuttingDirectionType.ForwardBackward)
			{
				num5 = OperationPars.CamParameters.ForwardStepDownDistance + OperationPars.CamParameters.BackwardStepDownDistance;
			}
			num2 = Convert.ToInt32(Math.Ceiling(num4 / num5));
			if (num2 > 1)
			{
				num5 = num4 / (double)num2;
			}
			if (OperationPars.CamParameters.CuttingOrderDirection == CamCuttingOrderDirectionType.Region)
			{
				for (int l = 0; l <= list.Count - 1; l++)
				{
					List<eEntities> list2 = new List<eEntities>();
					Pnt3D pnt3D8 = new Pnt3D(list[l].Vertice[0]);
					Pnt3D pnt3D9 = new Pnt3D(list[l].Vertice[list[l].Vertice.Count - 1]);
					if (OperationPars.CamParameters.CuttingDirection == CamCuttingDirectionType.Backward)
					{
						pnt3D8 = new Pnt3D(list[l].Vertice[list[l].Vertice.Count - 1]);
						pnt3D9 = new Pnt3D(list[l].Vertice[0]);
					}
					if ((OperationPars.CamParameters.CuttingDirection == CamCuttingDirectionType.ForwardBackward) & (num % 2 == 1))
					{
						pnt3D8 = new Pnt3D(list[l].Vertice[list[l].Vertice.Count - 1]);
						pnt3D9 = new Pnt3D(list[l].Vertice[0]);
					}
					if ((OperationPars.CamParameters.CuttingDirection == CamCuttingDirectionType.Forward) | (OperationPars.CamParameters.CuttingDirection == CamCuttingDirectionType.Backward))
					{
						eLine eLine3 = new eLine();
						for (int m = 1; m <= num2; m++)
						{
							num3 = MaterialThickness - (double)m * num5;
							if (num3 < 0.0)
							{
								num3 = 0.0;
							}
							pnt3D8.Z = num3;
							pnt3D9.Z = num3;
							eLine3 = new eLine(pnt3D8, pnt3D9);
							eLine3.Orientation = new OrientationAngle(list[l].Orientation);
							eLine3.auxText = "Fwd";
							if (OperationPars.CamParameters.CuttingDirection == CamCuttingDirectionType.Backward)
							{
								eLine3.auxText = "Bwd";
							}
							list2.Add(eLine3);
							if (list2.Count > 0)
							{
								CalcEntities.Add(list2);
							}
							list2 = new List<eEntities>();
							num++;
						}
					}
					if (OperationPars.CamParameters.CuttingDirection == CamCuttingDirectionType.ForwardBackward)
					{
						new List<Pnt3D>();
						eLine eLine4 = new eLine();
						for (int n = 1; n <= num2; n++)
						{
							num3 = MaterialThickness - (double)n * num5 + OperationPars.CamParameters.BackwardStepDownDistance;
							if (num3 < 0.0)
							{
								num3 = 0.0;
							}
							if (n > 1)
							{
								eLine4 = new eLine(pnt3D, new Pnt3D(pnt3D.X, pnt3D.Y, num3));
								eLine4.Orientation = new OrientationAngle(list[l].Orientation);
								eLine4.auxText = "Plunge";
								list2.Add(eLine4);
							}
							pnt3D8.Z = num3;
							pnt3D9.Z = num3;
							eLine4 = new eLine(new Pnt3D(pnt3D8), new Pnt3D(pnt3D9));
							eLine4.Orientation = new OrientationAngle(list[l].Orientation);
							eLine4.auxText = "Fwd";
							list2.Add(eLine4);
							num3 = MaterialThickness - (double)n * num5;
							eLine4 = new eLine(pnt3D9, new Pnt3D(pnt3D9.X, pnt3D9.Y, num3));
							eLine4.Orientation = new OrientationAngle(list[l].Orientation);
							eLine4.auxText = "Plunge";
							list2.Add(eLine4);
							pnt3D8.Z = num3;
							pnt3D9.Z = num3;
							eLine4 = new eLine(new Pnt3D(pnt3D9), new Pnt3D(pnt3D8));
							eLine4.Orientation = new OrientationAngle(list[l].Orientation);
							eLine4.auxText = "Bwd";
							list2.Add(eLine4);
							pnt3D = new Pnt3D(eLine4.EndPoint);
							num++;
						}
					}
					if (list2.Count > 0)
					{
						CalcEntities.Add(list2);
					}
				}
			}
			return true;
		}
		catch (Exception mSException)
		{
			string text = "StartPoint: " + StartPoint.ToString() + " - EndPoint: " + EndPoint.ToString() + " - MaterialThickness: " + MaterialThickness + " - ToolThickness: " + ToolThickness + " - TangentAngle: " + TangentAngle + " - PitchAngle: " + PitchAngle;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return false;
		}
	}

	public void MarblecalcItemLines(Pnt3D FirstUpPnt, Pnt3D FirstDownPnt, Pnt3D LastUpPnt, Pnt3D LastDownPnt, ToolBase Tool, double StartAngle, double EndAngle, double LastA, Pnt6D Position, bool StartMode, marbleOperation varOperation, ref List<List<eEntities>> Entities)
	{
		List<eEntities> list = new List<eEntities>();
		List<Pnt3D> CalcPoints = new List<Pnt3D>();
		List<Pnt3D> CalcPoints2 = new List<Pnt3D>();
		MarbleItemHeightByDirection(varOperation.CamParameters.CuttingDirection, HeightStepCalculationType.DontChangeBaseStepMakeExtraStep, varOperation.CamParameters.ForwardStepDownDistance, varOperation.CamParameters.BackwardStepDownDistance, varOperation.MaterialThickness, varOperation.TargetZ, FirstUpPnt, FirstDownPnt, ref CalcPoints);
		MarbleItemHeightByDirection(varOperation.CamParameters.CuttingDirection, HeightStepCalculationType.DontChangeBaseStepMakeExtraStep, varOperation.CamParameters.ForwardStepDownDistance, varOperation.CamParameters.BackwardStepDownDistance, varOperation.MaterialThickness, varOperation.TargetZ, LastUpPnt, LastDownPnt, ref CalcPoints2);
		list = new List<eEntities>();
		for (int i = 0; i <= CalcPoints.Count - 1; i++)
		{
			eLine eLine2 = new eLine(CalcPoints[i], CalcPoints2[i], (float)Tool.Geometry.Thickness, Color.Lime);
			if (varOperation.CamParameters.CuttingDirection == CamCuttingDirectionType.Backward)
			{
				eLine2.camDirections = camPathDirectionType.Reverse;
				eLine2.auxText = "Backward";
			}
			if (varOperation.CamParameters.CuttingDirection == CamCuttingDirectionType.ForwardBackward && i % 2 == 1)
			{
				eLine2.camDirections = camPathDirectionType.Reverse;
				eLine2.auxText = "Backward";
			}
			if (!StartMode)
			{
				if (!(EndAngle >= 0.0))
				{
					eLine2.Orientation = new OrientationAngle(EndAngle * -1.0, 0.0, Position.C + 180.0);
					buAppCalc.cVector.CamDirectionChange(ref eLine2.camDirections);
				}
				else
				{
					eLine2.Orientation = new OrientationAngle(EndAngle, 0.0, Position.C);
				}
			}
			else if (!(StartAngle > 0.0))
			{
				eLine2.Orientation = new OrientationAngle(StartAngle * -1.0, 0.0, Position.C);
			}
			else
			{
				eLine2.Orientation = new OrientationAngle(StartAngle, 0.0, Position.C + 180.0);
				buAppCalc.cVector.CamDirectionChange(ref eLine2.camDirections);
			}
			list.Add(eLine2);
		}
		if (!StartMode)
		{
			if (list.Count > 0)
			{
				Entities.Add(list);
			}
		}
		else
		{
			if (list.Count <= 0)
			{
				return;
			}
			if (Entities.Count != 0)
			{
				if (LastA != StartAngle)
				{
					Entities.Add(list);
				}
			}
			else
			{
				Entities.Add(list);
			}
		}
	}

	public void MarblecalcItemCam(List<List<eEntities>> CamEntities, ToolBase Tool, List<eEntities> ItemEntities, List<marbleCutItems> Items, string CamName, marbleOperation varOperation, KinematicBase Kinematic, EntitiesResolution Resolutions, ref camBase Cam)
	{
		if ((varOperation.CamParameters.CuttingDirection == CamCuttingDirectionType.Forward) | (varOperation.CamParameters.CuttingDirection == CamCuttingDirectionType.Backward))
		{
			List<List<eEntities>> list = new List<List<eEntities>>();
			for (int i = 0; i <= CamEntities.Count - 1; i++)
			{
				for (int j = 0; j <= CamEntities[i].Count - 1; j++)
				{
					List<eEntities> list2 = new List<eEntities>();
					eEntities copiedEnt = new eEntities();
					eEntities.CopyEntity(CamEntities[i][j], ref copiedEnt);
					list2.Add(copiedEnt);
					list.Add(list2);
				}
			}
			buGeneral.CopyLists(list, ref CamEntities);
		}
		Cam = new camBase();
		Cam.Tool = new ToolBase(Tool);
		camSpeeds speeds = new camSpeeds(varOperation.CamParameters.ForwardCuttingVelocity, varOperation.CamParameters.PlungeVelocity, 100.0, varOperation.CamParameters.LeaveVelocity, varOperation.CamParameters.BackwardCuttingVelocity, 100.0);
		camDistances distance = new camDistances(varOperation.CamParameters.SafeDistance, varOperation.CamParameters.StepUpDistance, varOperation.CamParameters.AirDistance, increemntalsafe: false);
		camParameters camParameters2 = new camParameters();
		camParameters2.Speeds = new camSpeeds(speeds);
		camParameters2.Distances = new camDistances(distance);
		buAppCalc.cCam.CalculateMarbleWireFrameWithSaw(CamEntities, new List<List<eEntities>>(), Kinematic, Tool, varOperation, varOperation.CamParameters, camParameters2, Resolutions, ref Cam);
		Cam.ItemEntities.AddRange(ItemEntities);
		Cam.Name = CamName;
		for (int k = 0; k <= Items.Count - 1; k++)
		{
			Cam.PreCodes.Add("// Item ;" + Items[k].Length + ";" + Items[k].Count + ";" + Items[k].StartAngle + ";" + Items[k].EndAngle);
		}
		for (int l = 0; l <= Cam.CamPoints.Count - 1; l++)
		{
			for (int m = 0; m <= Cam.CamPoints[l].Points.Count - 1; m++)
			{
				Pnt9D pnt9D = new Pnt9D(Cam.CamPoints[l].Points[m].P9);
				pnt9D.X += Kinematic.OffsetXYZ.X;
				pnt9D.Y += Kinematic.OffsetXYZ.Y;
				pnt9D.Z = pnt9D.Z + Kinematic.OffsetXYZ.Z - Tool.Geometry.Diameter / 2.0;
				Cam.CamPoints[l].Points[m].P9 = new Pnt9D(pnt9D);
			}
		}
		for (int n = 0; n <= Cam.CamPoints.Count - 1; n++)
		{
			for (int num = 0; num <= Cam.CamPoints[n].SimilationPoint.SimDetailedPoints.Count - 1; num++)
			{
				Pnt6DSim pnt6DSim = new Pnt6DSim(Cam.CamPoints[n].SimilationPoint.SimDetailedPoints[num]);
				pnt6DSim.Z -= Tool.Geometry.Diameter / 2.0;
			}
		}
	}

	public void doSingleCut(Pnt6D Position, ToolBase Tool, marbleOperation varOperation, KinematicBase Kinematic, EntitiesResolution Resolution, ref camBase Cam)
	{
		List<eEntities> list = new List<eEntities>();
		Pnt6D pnt6D = new Pnt6D(Math.Round(Position.X, 3), Math.Round(Position.Y, 3), Math.Round(Position.Z, 3), Math.Round(Position.A, 3), 0.0, Math.Round(Position.C, 3));
		new eEntities();
		List<eEntities> itemEntities = new List<eEntities>();
		List<List<eEntities>> list2 = new List<List<eEntities>>();
		List<Pnt3D> Vertices = new List<Pnt3D>();
		double height = varOperation.MaterialThickness / Math.Sin(buConversion.DegreeToRadian(pnt6D.A + 90.0));
		buAppCalc.cVector.Plane3D(new Pnt3D(pnt6D.X, pnt6D.Y, varOperation.MaterialThickness), new Vec3D(1.0, 0.0, 0.0), new OrientationAngle(pnt6D.A - 90.0, 0.0, pnt6D.C), varOperation.CutLength, height, ref Vertices);
		List<Pnt3D> CalcPoints = new List<Pnt3D>();
		List<Pnt3D> CalcPoints2 = new List<Pnt3D>();
		MarbleItemHeightByDirection(varOperation.CamParameters.CuttingDirection, HeightStepCalculationType.DontChangeBaseStepMakeExtraStep, varOperation.CamParameters.ForwardStepDownDistance, varOperation.CamParameters.BackwardStepDownDistance, varOperation.MaterialThickness, varOperation.TargetZ, Vertices[0], Vertices[3], ref CalcPoints);
		MarbleItemHeightByDirection(varOperation.CamParameters.CuttingDirection, HeightStepCalculationType.DontChangeBaseStepMakeExtraStep, varOperation.CamParameters.ForwardStepDownDistance, varOperation.CamParameters.BackwardStepDownDistance, varOperation.MaterialThickness, varOperation.TargetZ, Vertices[1], Vertices[2], ref CalcPoints2);
		list = new List<eEntities>();
		for (int i = 0; i <= CalcPoints.Count - 1; i++)
		{
			eLine eLine2 = new eLine(CalcPoints[i], CalcPoints2[i], 4f, Color.Lime);
			LeadIn leadIn = new LeadIn(enable: true, 0.0, LeadInOutType.Line, varOperation.CamParameters.FirstEnterDistance);
			LeadOut leadOut = new LeadOut(enable: true, 0.0, LeadInOutType.Line, varOperation.CamParameters.LastOutDistance);
			eEntities LeadInEntitiy = new eEntities();
			eEntities LeadOutEntitiy = new eEntities();
			buAppCalc.cCam.LeadInOutCalculation(eLine2, eLine2, leadIn, leadOut, new WorkPlane(), ClockDirectionType.CW, ref LeadInEntitiy, ref LeadOutEntitiy);
			eLine2.StartPoint = new Pnt3D(LeadInEntitiy.Vertice[0]);
			eLine2.EndPoint = new Pnt3D(LeadOutEntitiy.Vertice[LeadOutEntitiy.Vertice.Count - 1]);
			if (varOperation.CamParameters.CuttingDirection == CamCuttingDirectionType.Backward)
			{
				eLine2.camDirections = camPathDirectionType.Reverse;
				eLine2.auxText = "BackWard";
			}
			if (varOperation.CamParameters.CuttingDirection == CamCuttingDirectionType.ForwardBackward && i % 2 == 1)
			{
				eLine2.camDirections = camPathDirectionType.Reverse;
				eLine2.auxText = "Backward";
			}
			if (!(pnt6D.A >= 0.0))
			{
				eLine2.Orientation = new OrientationAngle(pnt6D.A * -1.0, 0.0, pnt6D.C);
			}
			else
			{
				eLine2.Orientation = new OrientationAngle(pnt6D.A, 0.0, pnt6D.C);
			}
			list.Add(eLine2);
		}
		if (list.Count > 0)
		{
			list2.Add(list);
		}
		MarblecalcItemCam(list2, Tool, itemEntities, new List<marbleCutItems>(), "Multi Cut - [Marble]", varOperation, Kinematic, Resolution, ref Cam);
		Cam.Kinematic = new KinematicBase(Kinematic);
	}

	public void doMultiCut(Pnt6D Position, ToolBase Tool, List<marbleCutItems> Items, bool VerticalCut, marbleOperation varOperation, KinematicBase Kinematic, EntitiesResolution Resolution, ref camBase Cam)
	{
		new eEntities();
		new List<eEntities>();
		List<eEntities> Entities = new List<eEntities>();
		List<List<eEntities>> CalcLines = new List<List<eEntities>>();
		if (VerticalCut)
		{
			VerticalItemsCalc(Position, Tool, Items, varOperation, varOperation.CutLength, Kinematic, ref Cam, ref Entities, ref CalcLines);
		}
		else
		{
			HorizontalItemsCalc(Position, Tool, Items, varOperation, varOperation.CutLength, Kinematic, ref Cam, ref Entities, ref CalcLines);
		}
		MarblecalcItemCam(CalcLines, Tool, Entities, Items, "Multi Cut - [Marble]", varOperation, Kinematic, Resolution, ref Cam);
	}

	public void doPerpendicularCut(Pnt6D HorizontalPosition, Pnt6D VerticalPosition, ToolBase Tool, List<marbleCutItems> HorizontalItems, List<marbleCutItems> VerticalItems, marbleOperation varOperation, KinematicBase Kinematic, EntitiesResolution Resolution, ref camBase Cam)
	{
		List<List<eEntities>> CalcLines = new List<List<eEntities>>();
		List<List<eEntities>> CalcLines2 = new List<List<eEntities>>();
		List<eEntities> Entities = new List<eEntities>();
		List<marbleCutItems> list = new List<marbleCutItems>();
		if (varOperation.VerticalFirst)
		{
			if (VerticalItems.Count > 0)
			{
				VerticalItemsCalc(VerticalPosition, Tool, VerticalItems, varOperation, varOperation.CutLengthVertical, Kinematic, ref Cam, ref Entities, ref CalcLines2);
			}
			if (HorizontalItems.Count > 0)
			{
				if (VerticalPosition.C == HorizontalPosition.C)
				{
					HorizontalPosition.C -= 90.0;
				}
				HorizontalItemsCalc(HorizontalPosition, Tool, HorizontalItems, varOperation, varOperation.CutLengthHorizontal, Kinematic, ref Cam, ref Entities, ref CalcLines);
			}
			for (int i = 0; i <= CalcLines.Count - 1; i++)
			{
				List<eEntities> CopiedEnt = new List<eEntities>();
				eEntities.CopyEntities(CalcLines[i], ref CopiedEnt);
				CalcLines2.Add(CopiedEnt);
			}
			for (int j = 0; j <= VerticalItems.Count - 1; j++)
			{
				list.Add(new marbleCutItems(VerticalItems[j]));
			}
			for (int k = 0; k <= HorizontalItems.Count - 1; k++)
			{
				list.Add(new marbleCutItems(HorizontalItems[k]));
			}
			MarblecalcItemCam(CalcLines2, Tool, Entities, list, "Perpendicular Cut - [Marble]", varOperation, Kinematic, Resolution, ref Cam);
			return;
		}
		if (HorizontalItems.Count > 0)
		{
			HorizontalItemsCalc(HorizontalPosition, Tool, HorizontalItems, varOperation, varOperation.CutLengthHorizontal, Kinematic, ref Cam, ref Entities, ref CalcLines);
		}
		if (VerticalItems.Count > 0)
		{
			if (VerticalPosition.C == HorizontalPosition.C)
			{
				VerticalPosition.C = HorizontalPosition.C + 90.0;
			}
			VerticalItemsCalc(VerticalPosition, Tool, VerticalItems, varOperation, varOperation.CutLengthVertical, Kinematic, ref Cam, ref Entities, ref CalcLines2);
		}
		for (int l = 0; l <= CalcLines2.Count - 1; l++)
		{
			List<eEntities> CopiedEnt2 = new List<eEntities>();
			eEntities.CopyEntities(CalcLines2[l], ref CopiedEnt2);
			CalcLines.Add(CopiedEnt2);
		}
		for (int m = 0; m <= HorizontalItems.Count - 1; m++)
		{
			list.Add(new marbleCutItems(HorizontalItems[m]));
		}
		for (int n = 0; n <= VerticalItems.Count - 1; n++)
		{
			list.Add(new marbleCutItems(VerticalItems[n]));
		}
		MarblecalcItemCam(CalcLines, Tool, Entities, list, "Perpendicular Cut - [Marble]", varOperation, Kinematic, Resolution, ref Cam);
	}

	public void HorizontalItemsCalc(Pnt6D Position, ToolBase Tool, List<marbleCutItems> Items, marbleOperation varOperation, double CutLength, KinematicBase Kinematic, ref camBase Cam, ref List<eEntities> Entities, ref List<List<eEntities>> CalcLines)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 1.0;
		double num5 = 0.0;
		eEntities SurfaceEntity = new eEntities();
		num3 = varOperation.MaterialThickness;
		num5 = Math.Round(Position.C);
		if (Items.Count == 0)
		{
			return;
		}
		if (Items[0].Length < 0.0)
		{
			num4 = -1.0;
		}
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			List<Quad3D> Quads = new List<Quad3D>();
			double num6 = Items[i].StartAngle;
			double num7 = Items[i].EndAngle;
			double num8 = Math.Abs(Items[i].Length);
			double num9 = 360.0;
			if (num6 > 0.0)
			{
				num8 -= num3 * Math.Tan(buConversion.DegreeToRadian(num6));
			}
			if (num7 > 0.0)
			{
				num8 -= num3 * Math.Tan(buConversion.DegreeToRadian(num7));
			}
			if (i <= Items.Count - 2)
			{
				num9 = Items[i + 1].StartAngle;
			}
			buAppCalc.cVector.Trapezoid3D(new Pnt3D(Position.X, Position.Y, varOperation.MaterialThickness), num8, varOperation.MaterialThickness - varOperation.TargetZ, num6 + 90.0, num7 + 90.0, new Vec3D(1.0, 0.0, 0.0), CutLength, num5, ref Quads, ref SurfaceEntity);
			if (num4 < 0.0)
			{
				num6 *= -1.0;
				num7 *= -1.0;
			}
			for (int j = 0; j <= Items[i].Count - 1; j++)
			{
				new List<Pnt3D>();
				new List<Pnt3D>();
				eEntities CalcEnt = new eEntities();
				double num10 = 0.0;
				double num11 = 0.0;
				double num12 = 0.0;
				double num13 = Math.Abs(Items[i].Length) / Math.Cos(buConversion.DegreeToRadian(num5));
				double num14 = 0.0;
				double num15 = 0.0;
				_ = Tool.Geometry.Thickness / Math.Cos(buConversion.DegreeToRadian(Math.Abs(num6)));
				double num16 = Tool.Geometry.Thickness / Math.Cos(buConversion.DegreeToRadian(Math.Abs(num7)));
				num11 = Tool.Geometry.Thickness / 2.0 / Math.Cos(buConversion.DegreeToRadian(Math.Abs(num6)));
				num12 = Tool.Geometry.Thickness / 2.0 / Math.Cos(buConversion.DegreeToRadian(Math.Abs(num7)));
				num14 = num16;
				buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(0.0, num, 0.0), SurfaceEntity, ref CalcEnt);
				CalcEnt.LayerIndex = varOperation.HorizontalLayerIndex;
				Entities.Add(CalcEnt);
				if ((i == 0 && j == 0) || num2 != num6)
				{
					num10 = num11;
				}
				if (j <= Items[i].Count - 2 && num7 != 0.0 - num6)
				{
					num15 = 4.0;
				}
				if (j == Items[i].Count - 1 && num7 != 0.0 - num9)
				{
					num15 = 4.0;
				}
				Quad3D Quad = new Quad3D(Quads[5]);
				buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(0.0, num - num10, 0.0), ref Quad);
				MarblecalcItemLines(Quad.FirstPoint, Quad.SecondPoint, Quad.FourthPoint, Quad.ThirdPoint, Tool, num6, num7, num2, Position, StartMode: true, varOperation, ref CalcLines);
				Quad = new Quad3D(Quads[3]);
				buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(0.0, num + num12, 0.0), ref Quad);
				MarblecalcItemLines(Quad.FirstPoint, Quad.SecondPoint, Quad.FourthPoint, Quad.ThirdPoint, Tool, num6, num7, num2, Position, StartMode: false, varOperation, ref CalcLines);
				num2 = num7 * -1.0;
				num = num + num13 + num14 + num15;
			}
		}
		if (num4 < 0.0)
		{
			buAppCalc.cVector.Mirror(new Pnt3D(0.0, Position.Y, 0.0), new Pnt3D(1.0, Position.Y, 0.0), new WorkPlane(), 0.0, ref Entities);
			buAppCalc.cVector.Mirror(new Pnt3D(0.0, Position.Y, 0.0), new Pnt3D(1.0, Position.Y, 0.0), new WorkPlane(), 0.0, ref CalcLines);
		}
	}

	public void VerticalItemsCalc(Pnt6D Position, ToolBase Tool, List<marbleCutItems> Items, marbleOperation varOperation, double CutLength, KinematicBase Kinematic, ref camBase Cam, ref List<eEntities> Entities, ref List<List<eEntities>> CalcLines)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 1.0;
		double num5 = 1.0;
		double num6 = 0.0;
		eEntities SurfaceEntity = new eEntities();
		num3 = varOperation.MaterialThickness;
		num6 = Math.Round(Position.C);
		if (Items.Count == 0)
		{
			return;
		}
		if (Items[0].Length < 0.0)
		{
			num4 = -1.0;
		}
		if (num6 < 0.0)
		{
			num5 *= -1.0;
		}
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			List<Quad3D> Quads = new List<Quad3D>();
			double num7 = Items[i].StartAngle;
			double num8 = Items[i].EndAngle;
			double num9 = Math.Abs(Items[i].Length);
			double num10 = 360.0;
			if (num7 < 0.0)
			{
				num9 -= num3 * Math.Tan(buConversion.DegreeToRadian(num7));
			}
			if (num8 < 0.0)
			{
				num9 -= num3 * Math.Tan(buConversion.DegreeToRadian(num8));
			}
			if (i <= Items.Count - 2)
			{
				num10 = Items[i + 1].StartAngle;
			}
			double num11 = 0.0 - num7;
			double num12 = 0.0 - num8;
			buAppCalc.cVector.Trapezoid3D(new Pnt3D(Position.X, Position.Y, varOperation.MaterialThickness), num9, varOperation.MaterialThickness, num11 + 90.0, num12 + 90.0, new Vec3D(0.0, 1.0, 0.0), CutLength, Math.Abs(Position.C) - 90.0, ref Quads, ref SurfaceEntity);
			if (num6 < 0.0)
			{
				buAppCalc.cVector.Mirror(new Pnt3D(0.0, Position.Y, 0.0), new Pnt3D(1.0, Position.Y, 0.0), new WorkPlane(), 0.0, ref Quads);
				buAppCalc.cVector.Mirror(new Pnt3D(0.0, Position.Y, 0.0), new Pnt3D(1.0, Position.Y, 0.0), new WorkPlane(), 0.0, ref SurfaceEntity);
				num7 *= -1.0;
				num8 *= -1.0;
			}
			if (num4 < 0.0)
			{
				num7 *= -1.0;
				num8 *= -1.0;
			}
			for (int j = 0; j <= Items[i].Count - 1; j++)
			{
				new List<Pnt3D>();
				new List<Pnt3D>();
				eEntities CalcEnt = new eEntities();
				double num13 = 0.0;
				double num14 = 0.0;
				double num15 = 0.0;
				double num16 = Math.Abs(Items[i].Length) / Math.Sin(buConversion.DegreeToRadian(Math.Abs(num6)));
				double num17 = 0.0;
				double num18 = 0.0;
				double num19 = Tool.Geometry.Thickness / Math.Cos(buConversion.DegreeToRadian(Math.Abs(num7)));
				double num20 = Tool.Geometry.Thickness / Math.Cos(buConversion.DegreeToRadian(Math.Abs(num8)));
				num14 = Tool.Geometry.Thickness / 2.0 / Math.Cos(buConversion.DegreeToRadian(Math.Abs(num7)));
				num15 = Tool.Geometry.Thickness / 2.0 / Math.Cos(buConversion.DegreeToRadian(Math.Abs(num8)));
				if (!(Math.Abs(num19) > Math.Abs(num20)))
				{
					num17 = num20;
				}
				else
				{
					num17 = num19;
				}
				num17 = num20;
				buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(num, 0.0, 0.0), SurfaceEntity, ref CalcEnt);
				CalcEnt.LayerIndex = varOperation.VerticalLayerIndex;
				Entities.Add(CalcEnt);
				if ((i == 0 && j == 0) || num2 != num7)
				{
					num13 = num14;
				}
				if (j <= Items[i].Count - 2 && num8 != 0.0 - num7)
				{
					num18 = 4.0;
				}
				if (j == Items[i].Count - 1 && num8 != 0.0 - num10)
				{
					num18 = 4.0;
				}
				Quad3D Quad = new Quad3D(Quads[5]);
				buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(num - num13, 0.0, 0.0), ref Quad);
				MarblecalcItemLines(Quad.FirstPoint, Quad.SecondPoint, Quad.ThirdPoint, Quad.FourthPoint, Tool, num7, num8, num2, Position, StartMode: true, varOperation, ref CalcLines);
				Quad = new Quad3D(Quads[3]);
				buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(num + num15, 0.0, 0.0), ref Quad);
				MarblecalcItemLines(Quad.FirstPoint, Quad.SecondPoint, Quad.ThirdPoint, Quad.FourthPoint, Tool, num7, num8, num2, Position, StartMode: false, varOperation, ref CalcLines);
				num2 = num8 * -1.0;
				num = num + num16 + num17 + num18;
			}
		}
		if (num4 < 0.0)
		{
			buAppCalc.cVector.Mirror(new Pnt3D(Position.X, 0.0, 0.0), new Pnt3D(Position.X, 1.0, 0.0), new WorkPlane(), 0.0, ref Entities);
			buAppCalc.cVector.Mirror(new Pnt3D(Position.X, 0.0, 0.0), new Pnt3D(Position.X, 1.0, 0.0), new WorkPlane(), 0.0, ref CalcLines);
		}
	}
}
