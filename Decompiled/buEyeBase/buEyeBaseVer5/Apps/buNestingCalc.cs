using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buCore;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

public class buNestingCalc : IDisposable
{
	public static List<buNestedResult> NestedAllResults = new List<buNestedResult>();

	private bool bool_0 = false;

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

	public buNestingCalc()
	{
		if (buVector5.smethod_0("buNestingCalc"))
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
		throw new RegisterException("buNestingCalc");
	}

	~buNestingCalc()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		buCall.buVector5_0 = null;
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!bool_0)
		{
			if (disposing)
			{
				buCall.buVector5_0 = null;
			}
			bool_0 = true;
		}
	}

	public void SetLayerIndexFromLayerName(ref List<buEntity> refEntities, Design Viewport)
	{
		for (int i = 0; i <= refEntities.Count - 1; i++)
		{
			for (int j = 0; j <= Viewport.Layers.Count - 1; j++)
			{
				if (!(refEntities[i].LayerName == Viewport.Layers[j].Name))
				{
				}
			}
		}
	}

	public void SetLayerIndexFromLayerName(ref List<List<buEntity>> refEntities, Design Viewport)
	{
		for (int i = 0; i <= refEntities.Count - 1; i++)
		{
			for (int j = 0; j <= refEntities[i].Count - 1; j++)
			{
				for (int k = 0; k <= Viewport.Layers.Count - 1; k++)
				{
					if (!(refEntities[i][j].LayerName == Viewport.Layers[k].Name))
					{
					}
				}
			}
		}
	}

	public void GetAvailableNestingPartID(List<buNestingPart> Parts, ref int PartID)
	{
		try
		{
			int num = int.MinValue;
			if (Parts.Count != 0)
			{
				for (int i = 0; i <= Parts.Count - 1; i++)
				{
					if (Parts[i].ID > num)
					{
						num = Parts[i].ID;
					}
				}
				PartID = num + 1;
			}
			else
			{
				PartID = 0;
			}
		}
		catch (Exception mSException)
		{
			string text = "ID:00400001";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void GetAvailableNestingSheetID(List<buNestingSheet> Sheets, ref int SheetID)
	{
		try
		{
			int num = int.MinValue;
			for (int i = 0; i <= Sheets.Count - 1; i++)
			{
				if (Sheets[i].ID > num)
				{
					num = Sheets[i].ID;
				}
			}
			SheetID = num + 1;
		}
		catch (Exception mSException)
		{
			string text = "ID:00400002";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void IncreaseSheetUsedCountByID(ref List<buNestingSheet> Sheets, int ID)
	{
		try
		{
			for (int i = 0; i <= Sheets.Count - 1; i++)
			{
				if (Sheets[i].ID == ID)
				{
					Sheets[i].Used++;
					Sheets[i].Remain = Sheets[i].MaterialData.Quantity - Sheets[i].Used;
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "ID:00400003";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void IncreasePartUsedCountByID(ref List<buNestingPart> Parts, int ID)
	{
		try
		{
			for (int i = 0; i <= Parts.Count - 1; i++)
			{
				if (Parts[i].ID == ID)
				{
					Parts[i].Nested++;
					Parts[i].Remain = Parts[i].PartData.Quantity - Parts[i].Nested;
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "ID:00400004";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void ResetNestedCountAtPartLis(ref List<buNestingPart> Parts)
	{
		try
		{
			for (int i = 0; i <= Parts.Count - 1; i++)
			{
				Parts[i].Remain = Parts[i].PartData.Quantity;
				Parts[i].Nested = 0;
			}
		}
		catch (Exception mSException)
		{
			string text = "ID:00400005";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void ResetNestedCountAtSheetLis(ref List<buNestingSheet> Sheets)
	{
		try
		{
			for (int i = 0; i <= Sheets.Count - 1; i++)
			{
				Sheets[i].Remain = Sheets[i].MaterialData.Quantity;
				Sheets[i].Used = 0;
			}
		}
		catch (Exception mSException)
		{
			string text = "ID:00400006";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void SheeatArea(buNestedSheet Sheet, LengthUnit Unit, ref double Area)
	{
		try
		{
			double num = 0.0;
			double num2 = 1.0;
			if (Unit != LengthUnit.mm)
			{
				if (Unit != LengthUnit.cm)
				{
					if (Unit != LengthUnit.dm)
					{
						if (Unit != LengthUnit.m)
						{
							if (Unit != LengthUnit.dam)
							{
								if (Unit != LengthUnit.hm)
								{
									if (Unit == LengthUnit.km)
									{
										num2 = 1000000000000.0;
									}
								}
								else
								{
									num2 = 10000000000.0;
								}
							}
							else
							{
								num2 = 100000000.0;
							}
						}
						else
						{
							num2 = 1000000.0;
						}
					}
					else
					{
						num2 = 10000.0;
					}
				}
				else
				{
					num2 = 100.0;
				}
			}
			else
			{
				num2 = 1.0;
			}
			if (buCall.buVector5_0.IsClosed(Sheet.EntitiesGroup.Outside.Points))
			{
				num = buCall.buVector5_0.PolygonArea(Sheet.EntitiesGroup.Outside.Points, Plane.XY);
			}
			Area = num / num2;
		}
		catch (Exception mSException)
		{
			string text = "ID:00400007";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void PartArea(buNestedPart Part, LengthUnit Unit, bool OnlyOutter, ref double Area)
	{
		try
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 1.0;
			if (Unit != LengthUnit.mm)
			{
				if (Unit != LengthUnit.cm)
				{
					if (Unit != LengthUnit.dm)
					{
						if (Unit != LengthUnit.m)
						{
							if (Unit != LengthUnit.dam)
							{
								if (Unit != LengthUnit.hm)
								{
									if (Unit == LengthUnit.km)
									{
										num3 = 1000000000000.0;
									}
								}
								else
								{
									num3 = 10000000000.0;
								}
							}
							else
							{
								num3 = 100000000.0;
							}
						}
						else
						{
							num3 = 1000000.0;
						}
					}
					else
					{
						num3 = 10000.0;
					}
				}
				else
				{
					num3 = 100.0;
				}
			}
			else
			{
				num3 = 1.0;
			}
			if (!buCall.buVector5_0.IsClosed(Part.EntitiesGroup.Outside.Points))
			{
				if (buCall.buVector5_0.isEntitiesClosed(Part.EntitiesGroup.Outside.Entities))
				{
					List<Point3D> Points = new List<Point3D>();
					buCall.buVector5_0.EntitiesToPointsWithCamDirection(Part.EntitiesGroup.Outside.Entities, ref Points);
					num = buCall.buVector5_0.PolygonArea(Points, Plane.XY);
				}
			}
			else
			{
				num = buCall.buVector5_0.PolygonArea(Part.EntitiesGroup.Outside.Points, Plane.XY);
			}
			if (Part.EntitiesGroup.Inside != null)
			{
				for (int i = 0; i <= Part.EntitiesGroup.Inside.Count - 1; i++)
				{
					if (Part.EntitiesGroup.Inside[i].Points == null)
					{
						continue;
					}
					if (!buCall.buVector5_0.IsClosed(Part.EntitiesGroup.Inside[i].Points))
					{
						if (buCall.buVector5_0.isEntitiesClosed(Part.EntitiesGroup.Inside[i].Entities))
						{
							List<Point3D> Points2 = new List<Point3D>();
							buCall.buVector5_0.EntitiesToPointsWithCamDirection(Part.EntitiesGroup.Inside[i].Entities, ref Points2);
							num2 += buCall.buVector5_0.PolygonArea(Points2, Plane.XY);
						}
					}
					else
					{
						num2 += buCall.buVector5_0.PolygonArea(Part.EntitiesGroup.Inside[i].Points, Plane.XY);
					}
				}
			}
			Area = num / num3 - num2 / num3;
			if (!(Area < 0.0))
			{
			}
		}
		catch (Exception mSException)
		{
			string text = "ID:00400007";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void PartArea(buNestingPart Part, LengthUnit Unit, bool OnlyOutter, ref double Area)
	{
		try
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 1.0;
			if (Unit != LengthUnit.mm)
			{
				if (Unit != LengthUnit.cm)
				{
					if (Unit != LengthUnit.dm)
					{
						if (Unit != LengthUnit.m)
						{
							if (Unit != LengthUnit.dam)
							{
								if (Unit != LengthUnit.hm)
								{
									if (Unit == LengthUnit.km)
									{
										num3 = 1000000000000.0;
									}
								}
								else
								{
									num3 = 10000000000.0;
								}
							}
							else
							{
								num3 = 100000000.0;
							}
						}
						else
						{
							num3 = 1000000.0;
						}
					}
					else
					{
						num3 = 10000.0;
					}
				}
				else
				{
					num3 = 100.0;
				}
			}
			else
			{
				num3 = 1.0;
			}
			if (!buCall.buVector5_0.IsClosed(Part.EntitiesGroup.Outside.Points))
			{
				if (buCall.buVector5_0.isEntitiesClosed(Part.EntitiesGroup.Outside.Entities))
				{
					List<Point3D> Points = new List<Point3D>();
					buCall.buVector5_0.EntitiesToPointsWithCamDirection(Part.EntitiesGroup.Outside.Entities, ref Points);
					num = buCall.buVector5_0.PolygonArea(Points, Plane.XY);
				}
			}
			else
			{
				num = buCall.buVector5_0.PolygonArea(Part.EntitiesGroup.Outside.Points, Plane.XY);
			}
			if (Part.EntitiesGroup.Inside != null)
			{
				for (int i = 0; i <= Part.EntitiesGroup.Inside.Count - 1; i++)
				{
					if (Part.EntitiesGroup.Inside[i].Points == null)
					{
						continue;
					}
					if (!buCall.buVector5_0.IsClosed(Part.EntitiesGroup.Inside[i].Points))
					{
						if (buCall.buVector5_0.isEntitiesClosed(Part.EntitiesGroup.Inside[i].Entities))
						{
							List<Point3D> Points2 = new List<Point3D>();
							buCall.buVector5_0.EntitiesToPointsWithCamDirection(Part.EntitiesGroup.Inside[i].Entities, ref Points2);
							num2 += buCall.buVector5_0.PolygonArea(Points2, Plane.XY);
						}
					}
					else
					{
						num2 += buCall.buVector5_0.PolygonArea(Part.EntitiesGroup.Inside[i].Points, Plane.XY);
					}
				}
			}
			Area = num / num3 - num2 / num3;
			if (!(Area < 0.0))
			{
			}
		}
		catch (Exception mSException)
		{
			string text = "ID:00400007";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void NestedPartsBoxAreaFromNestedSheet(buNestedSheet Sheet, ref Point3D pntMin, ref Point3D pntMax)
	{
		try
		{
			List<buEntity> list = new List<buEntity>();
			for (int i = 0; i <= Sheet.Parts.Count - 1; i++)
			{
				for (int j = 0; j <= Sheet.Parts[i].EntitiesGroup.Outside.Entities.Count - 1; j++)
				{
					list.Add(Sheet.Parts[i].EntitiesGroup.Outside.Entities[j]);
				}
			}
			pntMin = new Point3D();
			pntMax = new Point3D();
			buCall.buVector5_0.BoxSizeCalculate(list, ref pntMin, ref pntMax);
		}
		catch (Exception mSException)
		{
			string text = "ID:00400008";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void NestedPartToEntity(buNestedPart Part, ref List<Entity> partEntities, ref List<List<Entity>> innerEntities, ref List<List<Entity>> auxEntities)
	{
		List<Entity> list = new List<Entity>();
		partEntities.Clear();
		partEntities = new List<Entity>();
		for (int i = 0; i <= Part.EntitiesGroup.Outside.Entities.Count - 1; i++)
		{
			Entity copiedEntity = null;
			buEntity.Copy(Part.EntitiesGroup.Outside.Entities[i], ref copiedEntity);
			partEntities.Add(copiedEntity);
		}
		innerEntities.Clear();
		innerEntities = new List<List<Entity>>();
		if (Part.EntitiesGroup.Inside != null && Part.EntitiesGroup.Inside.Count > 0)
		{
			for (int j = 0; j <= Part.EntitiesGroup.Inside[j].Entities.Count - 1; j++)
			{
				list = new List<Entity>();
				buEntity.Copy(Part.EntitiesGroup.Inside[j].Entities, ref list);
				innerEntities.Add(list);
			}
		}
		auxEntities.Clear();
		auxEntities = new List<List<Entity>>();
		if (Part.EntitiesGroup.OpenEntities != null && Part.EntitiesGroup.OpenEntities.Count > 0)
		{
			for (int k = 0; k <= Part.EntitiesGroup.OpenEntities.Count - 1; k++)
			{
				list = new List<Entity>();
				buEntity.Copy(Part.EntitiesGroup.OpenEntities[k].Entities, ref list);
				auxEntities.Add(list);
			}
		}
	}

	public void NestedPartToEntity(buNestedPart Part, bool isSolid, bool OnlyOutterSolid, ref List<Entity> calcEntities)
	{
		calcEntities = new List<Entity>();
		buEntity.Copy(Part.EntitiesGroup, ref calcEntities, Inside: true, OpenEntities: true, Solid: true, Text: true);
	}

	public void NestedPartToCutterEntity(buNestedPart Part, double DrillMainDiameter, double DrillAuxDiameter, ref CutterIsoEntities Entities, ref CutterIsoError Error)
	{
		new List<Entity>();
		MessageBox.Show("NotReady");
	}

	public void NestedSheetToEntity(buNestedSheet Sheet, bool isSolid, bool OnlyOutterSolid, ref List<Entity> calcEntities, ref List<Entity> UselessEntities)
	{
		calcEntities = new List<Entity>();
		buEntity.Copy(Sheet.EntitiesGroup, ref calcEntities, Inside: true, OpenEntities: true, Solid: true);
	}

	public void GetAllNestedPartFromSheet(buNestedSheet Sheet, bool isSorted, ref List<List<Entity>> partEntities, ref List<List<Entity>> innerEntities, ref List<List<Entity>> auxEntities)
	{
		partEntities.Clear();
		partEntities = new List<List<Entity>>();
		innerEntities.Clear();
		innerEntities = new List<List<Entity>>();
		auxEntities.Clear();
		auxEntities = new List<List<Entity>>();
		if (isSorted)
		{
			List<Entity> copiedEnt = new List<Entity>();
			List<Entity> copiedEnt2 = new List<Entity>();
			List<Entity> copiedEnt3 = new List<Entity>();
			for (int i = 0; i <= Sheet.Parts.Count - 1; i++)
			{
				List<Entity> partEntities2 = new List<Entity>();
				List<List<Entity>> innerEntities2 = new List<List<Entity>>();
				List<List<Entity>> auxEntities2 = new List<List<Entity>>();
				NestedPartToEntity(Sheet.Parts[i], ref partEntities2, ref innerEntities2, ref auxEntities2);
				buVector5.AddEntities(partEntities2, ref copiedEnt);
				buVector5.AddEntities(innerEntities2, ref copiedEnt2);
				buVector5.AddEntities(auxEntities2, ref copiedEnt3);
			}
			SortSettings sortSettings = new SortSettings();
			SortResult Result = new SortResult();
			sortSettings.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
			if (copiedEnt.Count > 0)
			{
				List<Entity> SortedEntities = new List<Entity>();
				buCall.buVector5_0.SortEntitiesByRefPoint(((ICurve)copiedEnt[0]).StartPoint, ref copiedEnt, sortSettings, ref SortedEntities, ref Result);
				buCall.buVector5_0.EntitiesSplitByUpperLine(SortedEntities, ref partEntities);
			}
			if (copiedEnt2.Count > 0)
			{
				List<Entity> SortedEntities2 = new List<Entity>();
				buCall.buVector5_0.SortEntitiesByRefPoint(((ICurve)copiedEnt2[0]).StartPoint, ref copiedEnt2, sortSettings, ref SortedEntities2, ref Result);
				buCall.buVector5_0.EntitiesSplitByUpperLine(SortedEntities2, ref innerEntities);
			}
			if (copiedEnt3.Count > 0)
			{
				List<Entity> SortedEntities3 = new List<Entity>();
				buCall.buVector5_0.SortEntitiesByRefPoint(((ICurve)copiedEnt3[0]).StartPoint, ref copiedEnt3, sortSettings, ref SortedEntities3, ref Result);
				buCall.buVector5_0.EntitiesSplitByUpperLine(SortedEntities3, ref auxEntities);
			}
		}
		else
		{
			for (int j = 0; j <= Sheet.Parts.Count - 1; j++)
			{
				List<Entity> partEntities3 = new List<Entity>();
				List<List<Entity>> innerEntities3 = new List<List<Entity>>();
				List<List<Entity>> auxEntities3 = new List<List<Entity>>();
				NestedPartToEntity(Sheet.Parts[j], ref partEntities3, ref innerEntities3, ref auxEntities3);
				buVector5.AddEntities(partEntities3, ref partEntities);
				buVector5.AddEntities(innerEntities3, ref innerEntities);
				buVector5.AddEntities(auxEntities3, ref auxEntities);
			}
		}
	}

	public void SaveNestedResult(buNestedResult Result, string FileName)
	{
		ArrayList arrayList = new ArrayList();
		arrayList = new ArrayList();
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("   Nesting Results");
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.AddRange(buNestedResult.ToDef(Result, 2));
		buFile5.SaveToFile(arrayList, FileName);
	}

	public void GetPartNameAndQuantity(List<buEntity> entText, buNestingVar Setting, ref int itemQuantity, ref string itemName, bool isSheet = false)
	{
		if (entText.Count <= 0)
		{
			return;
		}
		string value = "";
		string refWord = "";
		string value2 = "";
		string refWord2 = "";
		if (!isSheet)
		{
			value = Setting.PartSettings.AutoPartNameRef;
			refWord = Setting.PartSettings.AutoPartNameEquality;
			value2 = Setting.PartSettings.AutoPartQuantityRef;
			refWord2 = Setting.PartSettings.AutoPartQuantityEquality;
		}
		for (int i = 0; i <= entText.Count - 1; i++)
		{
			string text = "";
			if (entText[i] is buText)
			{
				text = ((buText)entText[i]).TextString.Trim();
			}
			if (entText[i] is buMultilineText)
			{
				text = ((buMultilineText)entText[i]).TextString.Trim();
			}
			if (text.Trim().Length > 0)
			{
				if (text.IndexOf(value) >= 0)
				{
					string[] Lines = null;
					buString5.SplitStringByRefWord(text, refWord, ref Lines);
					if (Lines != null && Lines.Length >= 2)
					{
						itemName = Lines[1];
					}
				}
				if (text.IndexOf(value2) >= 0)
				{
					string[] Lines2 = null;
					buString5.SplitStringByRefWord(text, refWord2, ref Lines2);
					if (Lines2 != null && Lines2.Length >= 2 && buNumeric5.IsNumeric(Lines2[1]))
					{
						itemQuantity = int.Parse(Lines2[1]);
					}
				}
			}
			if (itemName.Trim().Length == 0)
			{
				if (isSheet)
				{
					itemName = buLangTranslate.preDef.Sheet;
				}
				else
				{
					itemName = buLangTranslate.preDef.Part;
				}
			}
		}
	}

	public static string SheetItemFormat(buNestedResult Result, string SheetName, int Index)
	{
		try
		{
			return Index + 1 + "- " + SheetName + " , " + Result.NestedResultSheets[Index].Parts.Count + " " + buLangTranslate.preDef.Part;
		}
		catch (Exception mSException)
		{
			string text = "ID:00400009";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return "";
		}
	}

	public static string ResultItemFormat(buNestedResult Result)
	{
		try
		{
			string text = Result.JobName;
			if (Result.JobColor.Trim().Length > 0)
			{
				text = text + " - " + Result.JobColor;
			}
			if (Result.JobExplanation.Trim().Length > 0)
			{
				text = text + " - " + Result.JobExplanation;
			}
			string text2 = "";
			text = text + " = " + Result.NestedResultSheets.Count + " " + AppLanguage.CadCamDynamic[33] + " ";
			if (Result.NotNestedAll)
			{
				text2 = AppLanguage.CadCamDynamic[94] + " -  [" + Result.NestedTotalPartCount + " / " + Result.OrderedTotalPartCount + "]";
				text += text2;
			}
			if (Result.Licanse < 1)
			{
				text = text + " - " + AppLanguage.CadCamDynamic[96];
			}
			return text;
		}
		catch (Exception mSException)
		{
			string text3 = "ID:00400010";
			buLog.addLog(text3, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text3);
			return "";
		}
	}

	public static string NestedSheetInfo(buNestedResult Result, int Index, buNestingProgramSettings Settings, int LineCount = 0)
	{
		if (!Settings.isCutter)
		{
			return NestedSheetInfoForCommon(Result, Index, Settings, LineCount);
		}
		return NestedSheetInfoForCutter(Result, Index, Settings);
	}

	public static string NestedResultInfo(buNestedResult Result, buNestingProgramSettings Settings)
	{
		if (!Settings.isCutter)
		{
			return NestedResultInfoForCommon(Result, Settings);
		}
		return NestedResultInfoForCutter(Result, Settings);
	}

	public static string NestedSheetInfoForCommon(buNestedResult Result, int Index, buNestingProgramSettings Settings, int LineCount)
	{
		try
		{
			string text = "";
			if (LineCount > 0)
			{
				switch (LineCount)
				{
				case 1:
					text = text + buLangTranslate.preDef.Width + " = " + Result.NestedResultSheets[Index].MaterialWidth.ToString("f2") + " " + Settings.UnitLength.ToString() + " - ";
					text = text + buLangTranslate.preDef.Height + " = " + Result.NestedResultSheets[Index].MaterialHeight.ToString("f2") + " " + Settings.UnitLength.ToString() + " - ";
					text = text + buLangTranslate.preDef.Efficiency + " = %" + Result.NestedResultSheets[Index].UsingPersentage.ToString("f2") + " - ";
					text = text + buLangTranslate.preDef.Sheet + " " + buLangTranslate.preDef.Area + " = " + Result.NestedResultSheets[Index].MaterialArea.ToString("f2") + " " + Settings.UnitArea.ToString() + "² - ";
					text = text + buLangTranslate.preDef.Part + " " + buLangTranslate.preDef.Area + " = " + Result.NestedResultSheets[Index].NestedArea.ToString("f2") + " " + Settings.UnitArea.ToString() + "² - ";
					text = text + buLangTranslate.preDef.Count + " = " + Result.NestedResultSheets[Index].Parts.Count;
					if (Result.NestedResultSheets[Index].GCodeResult != null)
					{
						text += Environment.NewLine;
						text = text + buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Time + " =  " + buConversion5.SecondToTimeFormat(Result.NestedResultSheets[Index].GCodeResult.TotalTimeAsSec) + " - ";
						text = text + buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Operation + " " + buLangTranslate.preDef.Time + " =  " + buConversion5.SecondToTimeFormat(Result.NestedResultSheets[Index].GCodeResult.OperationTimeAsSec) + Environment.NewLine;
						text = text + buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Length + " =  " + Result.NestedResultSheets[Index].GCodeResult.TotalLengthAsMeter.ToString("f2") + " m - ";
						text = text + buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Operation + " " + buLangTranslate.preDef.Length + " =  " + Result.NestedResultSheets[Index].GCodeResult.OperationLengthAsMeter.ToString("f2") + " m ";
					}
					break;
				case 2:
					text = text + buLangTranslate.preDef.Width + " = " + Result.NestedResultSheets[Index].MaterialWidth.ToString("f2") + " " + Settings.UnitLength.ToString() + " - ";
					text = text + buLangTranslate.preDef.Height + " = " + Result.NestedResultSheets[Index].MaterialHeight.ToString("f2") + " " + Settings.UnitLength.ToString() + " - ";
					text = text + buLangTranslate.preDef.Efficiency + " = %" + Result.NestedResultSheets[Index].UsingPersentage.ToString("f2") + Environment.NewLine;
					text = text + buLangTranslate.preDef.Sheet + " " + buLangTranslate.preDef.Area + " = " + Result.NestedResultSheets[Index].MaterialArea.ToString("f2") + " " + Settings.UnitArea.ToString() + "² - ";
					text = text + buLangTranslate.preDef.Part + " " + buLangTranslate.preDef.Area + " = " + Result.NestedResultSheets[Index].NestedArea.ToString("f2") + " " + Settings.UnitArea.ToString() + "² - ";
					text = text + buLangTranslate.preDef.Count + " = " + Result.NestedResultSheets[Index].Parts.Count;
					if (Result.NestedResultSheets[Index].GCodeResult != null)
					{
						text += Environment.NewLine;
						text = text + buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Time + " =  " + buConversion5.SecondToTimeFormat(Result.NestedResultSheets[Index].GCodeResult.TotalTimeAsSec) + " - ";
						text = text + buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Operation + " " + buLangTranslate.preDef.Time + " =  " + buConversion5.SecondToTimeFormat(Result.NestedResultSheets[Index].GCodeResult.OperationTimeAsSec) + Environment.NewLine;
						text = text + buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Length + " =  " + Result.NestedResultSheets[Index].GCodeResult.TotalLengthAsMeter.ToString("f2") + " m - ";
						text = text + buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Operation + " " + buLangTranslate.preDef.Length + " =  " + Result.NestedResultSheets[Index].GCodeResult.OperationLengthAsMeter.ToString("f2") + " m ";
					}
					break;
				}
			}
			else
			{
				text = text + buLangTranslate.preDef.Width + " = " + Result.NestedResultSheets[Index].MaterialWidth.ToString("f2") + " " + Settings.UnitLength.ToString() + Environment.NewLine;
				text = text + buLangTranslate.preDef.Height + " = " + Result.NestedResultSheets[Index].MaterialHeight.ToString("f2") + " " + Settings.UnitLength.ToString() + Environment.NewLine;
				text = text + buLangTranslate.preDef.Efficiency + " = %" + Result.NestedResultSheets[Index].UsingPersentage.ToString("f2") + Environment.NewLine;
				text = text + buLangTranslate.preDef.Sheet + " " + buLangTranslate.preDef.Area + " = " + Result.NestedResultSheets[Index].MaterialArea.ToString("f2") + " " + Settings.UnitArea.ToString() + "²" + Environment.NewLine;
				text = text + buLangTranslate.preDef.Part + " " + buLangTranslate.preDef.Area + " = " + Result.NestedResultSheets[Index].NestedArea.ToString("f2") + " " + Settings.UnitArea.ToString() + "²" + Environment.NewLine;
				text = text + buLangTranslate.preDef.Count + " = " + Result.NestedResultSheets[Index].Parts.Count + Environment.NewLine;
				if (Result.NestedResultSheets[Index].GCodeResult != null)
				{
					text += Environment.NewLine;
					text = text + buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Time + " =  " + buConversion5.SecondToTimeFormat(Result.NestedResultSheets[Index].GCodeResult.TotalTimeAsSec) + " - ";
					text = text + buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Operation + " " + buLangTranslate.preDef.Time + " =  " + buConversion5.SecondToTimeFormat(Result.NestedResultSheets[Index].GCodeResult.OperationTimeAsSec) + Environment.NewLine;
					text = text + buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Length + " =  " + Result.NestedResultSheets[Index].GCodeResult.TotalLengthAsMeter.ToString("f2") + " m - ";
					text = text + buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Operation + " " + buLangTranslate.preDef.Length + " =  " + Result.NestedResultSheets[Index].GCodeResult.OperationLengthAsMeter.ToString("f2") + " m ";
				}
				if (Result.NestedResultSheets[Index].SheetMaxXPosition > 0.0)
				{
					text = text + "Max " + buLangTranslate.preDef.Length + " = " + Result.NestedResultSheets[Index].SheetMaxXPosition.ToString("f2") + " " + Settings.UnitLength.ToString() + Environment.NewLine;
				}
			}
			return text;
		}
		catch (Exception mSException)
		{
			string text2 = "ID:00400011";
			buLog.addLog(text2, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text2);
			return "";
		}
	}

	public static string NestedResultInfoForCommon(buNestedResult Result, buNestingProgramSettings Settings)
	{
		try
		{
			string text = "";
			List<buNestedSheet> list = new List<buNestedSheet>();
			for (int i = 0; i <= Result.NestedResultSheets.Count - 1; i++)
			{
				if (list.Count != 0)
				{
					bool flag = false;
					for (int j = 0; j <= list.Count - 1; j++)
					{
						if ((Result.NestedResultSheets[i].MaterialWidth == list[j].MaterialWidth) & (Result.NestedResultSheets[i].MaterialHeight == list[j].MaterialHeight))
						{
							list[j].Count++;
							flag = true;
							j = list.Count;
						}
					}
					if (!flag)
					{
						buNestedSheet buNestedSheet2 = new buNestedSheet(Result.NestedResultSheets[i]);
						buNestedSheet2.Count = 1;
						list.Add(buNestedSheet2);
					}
				}
				else
				{
					buNestedSheet buNestedSheet3 = new buNestedSheet(Result.NestedResultSheets[i]);
					buNestedSheet3.Count = 1;
					list.Add(buNestedSheet3);
				}
			}
			text = text + buLangTranslate.preDef.Job + " = " + Result.JobName + Environment.NewLine;
			if (Result.JobExplanation.Trim().Length > 0)
			{
				text = text + AppLanguage.CadCamDynamic[3] + " = " + Result.JobExplanation + Environment.NewLine;
			}
			text = text + AppLanguage.CadCamDynamic[85] + " = " + Result.ExecutionTime.ToString("f1") + " " + AppLanguage.CadCamDynamic[102] + Environment.NewLine;
			if (Result.PastalWidth > 0.0)
			{
				text = text + buLangTranslate.preDef.Pastal + " " + AppLanguage.CadCamDynamic[15] + " = " + Result.PastalWidth.ToString("f2") + " " + Settings.UnitLength.ToString() + Environment.NewLine;
			}
			if (Result.PartGap > 0.0)
			{
				text = text + buLangTranslate.preDef.Part + " " + AppLanguage.CadCamDynamic[100] + " = " + Result.PartGap.ToString("f2") + " " + Settings.UnitLength.ToString() + Environment.NewLine;
			}
			if (Result.OrderedTotalPartCount > 0)
			{
				text = text + buLangTranslate.preDef.Part + " " + AppLanguage.CadCamDynamic[53] + " = " + Result.NestedTotalPartCount + " \\ " + Result.OrderedTotalPartCount + Environment.NewLine;
			}
			if (Result.NestedSheetCount > 0)
			{
				text = text + buLangTranslate.preDef.Sheet + " " + buLangTranslate.preDef.Count + " = " + Result.NestedSheetCount + Environment.NewLine;
			}
			if (list.Count > 0)
			{
				for (int k = 0; k <= list.Count - 1; k++)
				{
					string text2 = list[k].Name.Trim();
					if (text2.Length == 0)
					{
						text2 = buLangTranslate.preDef.Sheet;
					}
					text = text + " - " + list[k].Count + " \\ " + Result.NestedSheetCount + " " + text2 + " " + buLangTranslate.preDef.Count + " = " + list[k].MaterialWidth.ToString("f1") + " x " + list[k].MaterialHeight.ToString("f1") + Environment.NewLine;
				}
			}
			if ((Result.MaxXPosition > 0.0) & (Result.NestedResultSheets.Count == 1))
			{
				text = text + "Max " + AppLanguage.CadCamDynamic[0] + " = " + Result.MaxXPosition.ToString("f2") + " " + Settings.UnitLength.ToString() + Environment.NewLine;
			}
			double num = 0.0;
			for (int l = 0; l <= Result.NestedResultSheets.Count - 1; l++)
			{
				if (Settings.CalculationShowFormat != nestCalculationShowFormat.MultiSheet)
				{
					if (Settings.CalculationShowFormat == nestCalculationShowFormat.PastalAsSingleSheet)
					{
						num += Result.NestedResultSheets[l].UsingPersentageFromMaxX;
					}
				}
				else
				{
					num += Result.NestedResultSheets[l].UsingPersentage;
				}
			}
			num /= (double)Result.NestedResultSheets.Count;
			text = text + buLangTranslate.preDef.Efficiency + " = %" + num.ToString("f2") + Environment.NewLine;
			if (Result.ExecutionDate.Year > 2000)
			{
				text = text + AppLanguage.CadCamDynamic[101] + " = " + Result.ExecutionDate.ToString("MM/dd/yyyy-HH:mm:ss") + Environment.NewLine;
			}
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			for (int m = 0; m <= Result.NestedResultSheets.Count - 1; m++)
			{
				if (Result.NestedResultSheets[m].GCodeResult != null)
				{
					num2 += Result.NestedResultSheets[m].GCodeResult.TotalTimeAsSec;
					num3 += Result.NestedResultSheets[m].GCodeResult.OperationTimeAsSec;
					num4 += Result.NestedResultSheets[m].GCodeResult.TotalLengthAsMeter;
					num5 += Result.NestedResultSheets[m].GCodeResult.OperationLengthAsMeter;
				}
			}
			if (num2 > 0.0)
			{
				text += Environment.NewLine;
				text = text + buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Time + " =  " + buConversion5.SecondToTimeFormat(num2) + " - ";
				text = text + buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Operation + " " + buLangTranslate.preDef.Time + " =  " + buConversion5.SecondToTimeFormat(num3) + Environment.NewLine;
				text = text + buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Length + " =  " + num4.ToString("f2") + " m - ";
				text = text + buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Operation + " " + buLangTranslate.preDef.Length + " =  " + num5.ToString("f2") + " m - ";
			}
			list.Clear();
			return text;
		}
		catch (Exception mSException)
		{
			string text3 = "ID:00400012";
			buLog.addLog(text3, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text3);
			return "";
		}
	}

	public static string NestedSheetInfoForCutter(buNestedResult Result, int Index, buNestingProgramSettings Settings)
	{
		try
		{
			string text = "";
			if (Result.ExecutionDate.Year > 2000)
			{
				text = text + AppLanguage.CadCamDynamic[101] + " = " + Result.ExecutionDate.ToString("MM/dd/yyyy-HH:mm:ss") + Environment.NewLine;
			}
			text = text + buLangTranslate.preDef.Pastal + " " + AppLanguage.CadCamDynamic[40] + " = " + Result.JobName + Environment.NewLine;
			if (Result.JobExplanation.Trim().Length > 0)
			{
				text = text + buLangTranslate.preDef.Pastal + " " + AppLanguage.CadCamDynamic[3] + " = " + Result.JobExplanation + Environment.NewLine;
			}
			text = text + buLangTranslate.preDef.Pastal + " " + AppLanguage.CadCamDynamic[15] + " = " + Result.NestedResultSheets[0].MaterialHeight.ToString("f2") + " " + Settings.UnitLength.ToString() + Environment.NewLine;
			double num = 0.0;
			if (Settings.CalculationShowFormat != nestCalculationShowFormat.MultiSheet)
			{
				if (Settings.CalculationShowFormat == nestCalculationShowFormat.PastalAsSingleSheet)
				{
					num += Result.NestedResultSheets[Index].UsingPersentageFromMaxX;
				}
			}
			else
			{
				num += Result.NestedResultSheets[Index].UsingPersentage;
			}
			text = text + buLangTranslate.preDef.Pastal + " " + buLangTranslate.preDef.Efficiency + " = %" + num.ToString("f2") + Environment.NewLine;
			text = text + buLangTranslate.preDef.Pastal + " " + buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Length + " = " + (Result.NestedResultSheets[Index].TotalLength / 1000.0).ToString("f2") + " m" + Environment.NewLine;
			if (Result.OrderedTotalPartCount > 0)
			{
				text = text + buLangTranslate.preDef.Part + " " + AppLanguage.CadCamDynamic[53] + " = " + Result.NestedTotalPartCount + " \\ " + Result.OrderedTotalPartCount + Environment.NewLine;
			}
			text = text + buLangTranslate.preDef.Nesting + " " + AppLanguage.CadCamDynamic[85] + " = " + Result.ExecutionTime.ToString("f1") + " " + AppLanguage.CadCamDynamic[102] + Environment.NewLine;
			if (Result.PartGap > 0.0)
			{
				text = text + buLangTranslate.preDef.Part + " " + AppLanguage.CadCamDynamic[100] + " = " + Result.PartGap.ToString("f2") + " " + Settings.UnitLength.ToString() + Environment.NewLine;
			}
			if (Result.NestedResultSheets[Index].Parts.Count > 0)
			{
				text = text + buLangTranslate.preDef.Part + " " + buLangTranslate.preDef.Rotation + " = " + Result.NestedResultSheets[Index].Parts[0].Rotation.ToString() + Environment.NewLine;
			}
			if ((Result.MaxXPosition > 0.0) & (Result.NestedResultSheets.Count == 1))
			{
				text = text + buLangTranslate.preDef.Pastal + " " + AppLanguage.CadCamDynamic[0] + " = " + Result.MaxXPosition.ToString("f2") + " " + Settings.UnitLength.ToString() + Environment.NewLine;
			}
			if (Result.NestedResultSheets[Index].ApproxExecutionTimeSec > 0.0)
			{
				TimeSpan timeSpan = TimeSpan.FromSeconds(Result.NestedResultSheets[Index].ApproxExecutionTimeSec);
				string text2 = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}s";
				text = text + buLangTranslate.preDef.Approx + " " + buLangTranslate.preDef.Time + " = " + text2 + Environment.NewLine;
				if (Result.NestedResultSheets[Index].ApproxExecution0TimeSec > 0.0)
				{
					timeSpan = TimeSpan.FromSeconds(Result.NestedResultSheets[Index].ApproxExecution0TimeSec);
					text2 = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}s";
					text = text + buLangTranslate.preDef.Approx + " " + buLangTranslate.preDef.Layer + " 0 " + buLangTranslate.preDef.Time + " = " + text2 + Environment.NewLine;
				}
				if (Result.NestedResultSheets[Index].ApproxExecution1TimeSec > 0.0)
				{
					timeSpan = TimeSpan.FromSeconds(Result.NestedResultSheets[Index].ApproxExecution1TimeSec);
					text2 = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}s";
					text = text + buLangTranslate.preDef.Approx + " " + buLangTranslate.preDef.Layer + " 1 " + buLangTranslate.preDef.Time + " = " + text2 + Environment.NewLine;
				}
				if (Result.NestedResultSheets[Index].ApproxExecution2TimeSec > 0.0)
				{
					timeSpan = TimeSpan.FromSeconds(Result.NestedResultSheets[Index].ApproxExecution2TimeSec);
					text2 = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}s";
					text = text + buLangTranslate.preDef.Approx + " " + buLangTranslate.preDef.Layer + " 2 " + buLangTranslate.preDef.Time + " = " + text2 + Environment.NewLine;
				}
				if (Result.NestedResultSheets[Index].ApproxExecution3TimeSec > 0.0)
				{
					timeSpan = TimeSpan.FromSeconds(Result.NestedResultSheets[Index].ApproxExecution3TimeSec);
					text2 = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}s";
					text = text + buLangTranslate.preDef.Approx + " " + buLangTranslate.preDef.Layer + " 3 " + buLangTranslate.preDef.Time + " = " + text2 + Environment.NewLine;
				}
				if (Result.NestedResultSheets[Index].ApproxExecution4TimeSec > 0.0)
				{
					timeSpan = TimeSpan.FromSeconds(Result.NestedResultSheets[Index].ApproxExecution4TimeSec);
					text2 = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}s";
					text = text + buLangTranslate.preDef.Approx + " " + buLangTranslate.preDef.Layer + " 4 " + buLangTranslate.preDef.Time + " = " + text2 + Environment.NewLine;
				}
				if (Result.NestedResultSheets[Index].ApproxExecution5TimeSec > 0.0)
				{
					timeSpan = TimeSpan.FromSeconds(Result.NestedResultSheets[Index].ApproxExecution5TimeSec);
					text2 = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}s";
					text = text + buLangTranslate.preDef.Approx + " " + buLangTranslate.preDef.Layer + " 5 " + buLangTranslate.preDef.Time + " = " + text2 + Environment.NewLine;
				}
				if (Result.NestedResultSheets[Index].ApproxExecution6TimeSec > 0.0)
				{
					timeSpan = TimeSpan.FromSeconds(Result.NestedResultSheets[Index].ApproxExecution6TimeSec);
					text2 = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}s";
					text = text + buLangTranslate.preDef.Approx + " " + buLangTranslate.preDef.Layer + " 6 " + buLangTranslate.preDef.Time + " = " + text2 + Environment.NewLine;
				}
				if (Result.NestedResultSheets[Index].ApproxExecution7TimeSec > 0.0)
				{
					timeSpan = TimeSpan.FromSeconds(Result.NestedResultSheets[Index].ApproxExecution7TimeSec);
					text2 = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}s";
					text = text + buLangTranslate.preDef.Approx + " " + buLangTranslate.preDef.Layer + " 7 " + buLangTranslate.preDef.Time + " = " + text2 + Environment.NewLine;
				}
				if (Result.NestedResultSheets[Index].ApproxExecution8TimeSec > 0.0)
				{
					timeSpan = TimeSpan.FromSeconds(Result.NestedResultSheets[Index].ApproxExecution8TimeSec);
					text2 = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}s";
					text = text + buLangTranslate.preDef.Approx + " " + buLangTranslate.preDef.Layer + " 8 " + buLangTranslate.preDef.Time + " = " + text2 + Environment.NewLine;
				}
				if (Result.NestedResultSheets[Index].ApproxExecution9TimeSec > 0.0)
				{
					timeSpan = TimeSpan.FromSeconds(Result.NestedResultSheets[Index].ApproxExecution9TimeSec);
					text2 = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}s";
					text = text + buLangTranslate.preDef.Approx + " " + buLangTranslate.preDef.Layer + " 9 " + buLangTranslate.preDef.Time + " = " + text2 + Environment.NewLine;
				}
			}
			return text;
		}
		catch (Exception mSException)
		{
			string text3 = "ID:00400011";
			buLog.addLog(text3, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text3);
			return "";
		}
	}

	public static string NestedResultInfoForCutter(buNestedResult Result, buNestingProgramSettings Settings)
	{
		try
		{
			string text = "";
			if (Result.ExecutionDate.Year > 2000)
			{
				text = text + AppLanguage.CadCamDynamic[101] + " = " + Result.ExecutionDate.ToString("MM/dd/yyyy-HH:mm:ss") + Environment.NewLine;
			}
			text = text + buLangTranslate.preDef.Pastal + " " + AppLanguage.CadCamDynamic[40] + " = " + Result.JobName + Environment.NewLine;
			if (Result.JobExplanation.Trim().Length > 0)
			{
				text = text + buLangTranslate.preDef.Pastal + " " + AppLanguage.CadCamDynamic[3] + " = " + Result.JobExplanation + Environment.NewLine;
			}
			text = text + buLangTranslate.preDef.Pastal + " " + AppLanguage.CadCamDynamic[15] + " = " + Result.NestedResultSheets[0].MaterialHeight.ToString("f2") + " " + Settings.UnitLength.ToString() + Environment.NewLine;
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			for (int i = 0; i <= Result.NestedResultSheets.Count - 1; i++)
			{
				if (Settings.CalculationShowFormat != nestCalculationShowFormat.MultiSheet)
				{
					if (Settings.CalculationShowFormat == nestCalculationShowFormat.PastalAsSingleSheet)
					{
						num += Result.NestedResultSheets[i].UsingPersentageFromMaxX;
					}
				}
				else
				{
					num += Result.NestedResultSheets[i].UsingPersentage;
				}
				num2 += Result.NestedResultSheets[i].ApproxExecutionTimeSec;
				num3 += Result.NestedResultSheets[i].TotalLength;
			}
			num /= (double)Result.NestedResultSheets.Count;
			text = text + buLangTranslate.preDef.Pastal + " " + buLangTranslate.preDef.Efficiency + " = %" + num.ToString("f2") + Environment.NewLine;
			text = text + buLangTranslate.preDef.Cutting + " " + buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Length + " = " + (num3 / 1000.0).ToString("f2") + " m" + Environment.NewLine;
			if (Result.OrderedTotalPartCount > 0)
			{
				text = text + buLangTranslate.preDef.Part + " " + AppLanguage.CadCamDynamic[53] + " = " + Result.NestedTotalPartCount + " \\ " + Result.OrderedTotalPartCount + Environment.NewLine;
			}
			text = text + AppLanguage.CadCamDynamic[85] + " = " + Result.ExecutionTime.ToString("f1") + " " + AppLanguage.CadCamDynamic[102] + Environment.NewLine;
			if (Result.PartGap > 0.0)
			{
				text = text + buLangTranslate.preDef.Part + " " + AppLanguage.CadCamDynamic[100] + " = " + Result.PartGap.ToString("f2") + " " + Settings.UnitLength.ToString() + Environment.NewLine;
			}
			if (Result.NestedResultSheets.Count > 0 && Result.NestedResultSheets[0].Parts.Count > 0)
			{
				text = text + buLangTranslate.preDef.Part + " " + buLangTranslate.preDef.Rotation + " = " + Result.NestedResultSheets[0].Parts[0].Rotation.ToString() + Environment.NewLine;
			}
			if ((Result.MaxXPosition > 0.0) & (Result.NestedResultSheets.Count == 1))
			{
				text = text + buLangTranslate.preDef.Pastal + " " + AppLanguage.CadCamDynamic[0] + " = " + Result.MaxXPosition.ToString("f2") + " " + Settings.UnitLength.ToString() + Environment.NewLine;
			}
			if (num2 > 0.0)
			{
				TimeSpan timeSpan = TimeSpan.FromSeconds(num2);
				string text2 = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}s";
				text = text + buLangTranslate.preDef.Approx + " " + buLangTranslate.preDef.Time + " = " + text2 + Environment.NewLine;
			}
			return text;
		}
		catch (Exception mSException)
		{
			string text3 = "ID:00400012";
			buLog.addLog(text3, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text3);
			return "";
		}
	}

	public void SortNestingMaterialFromSmallToBig(bool FromLowerToBigger, ref List<buNestingSheet> Mateials)
	{
		try
		{
			for (int i = 0; i <= Mateials.Count - 1; i++)
			{
				for (int j = i; j <= Mateials.Count - 1; j++)
				{
					if (!FromLowerToBigger)
					{
						if (Mateials[i].Area < Mateials[j].Area)
						{
							buNestingSheet data = new buNestingSheet(Mateials[j]);
							Mateials[j] = new buNestingSheet(Mateials[i]);
							Mateials[i] = new buNestingSheet(data);
						}
					}
					else if (Mateials[i].Area > Mateials[j].Area)
					{
						buNestingSheet data2 = new buNestingSheet(Mateials[j]);
						Mateials[j] = new buNestingSheet(Mateials[i]);
						Mateials[i] = new buNestingSheet(data2);
					}
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "FromLowerToBigger : " + FromLowerToBigger;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void CreatePointAndSolidFromEntityGroup(ref buEntitiesGroup entGroup, bool View3D = true)
	{
		if (entGroup.Outside.Entities.Count <= 0)
		{
			return;
		}
		entGroup.Outside.Points = new List<Point3D>();
		buCall.buVector5_0.EntitiesToPointsWithCamDirection(entGroup.Outside.Entities, ref entGroup.Outside.Points);
		buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref entGroup.Outside.Points);
		if (entGroup.Inside != null && entGroup.Inside.Count > 0)
		{
			for (int i = 0; i <= entGroup.Inside.Count - 1; i++)
			{
				entGroup.Inside[i].Points = new List<Point3D>();
				buCall.buVector5_0.EntitiesToPointsWithCamDirection(entGroup.Inside[i].Entities, ref entGroup.Inside[i].Points);
				buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref entGroup.Inside[i].Points);
			}
		}
		if (entGroup.OpenEntities != null && entGroup.OpenEntities.Count > 0)
		{
			for (int j = 0; j <= entGroup.OpenEntities.Count - 1; j++)
			{
				entGroup.OpenEntities[j].Points = new List<Point3D>();
				buCall.buVector5_0.EntitiesToPointsWithCamDirection(entGroup.OpenEntities[j].Entities, ref entGroup.OpenEntities[j].Points);
				buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref entGroup.OpenEntities[j].Points);
			}
		}
		if (!View3D)
		{
			return;
		}
		Entity entSurface = null;
		buCall.buVector5_0.surfaceFromOutterInner(entGroup, 0.2, ref entSurface);
		if (entSurface != null)
		{
			entGroup.Solid = new buEntityList();
			buEntity copiedEntity = null;
			buEntity.Copy(entSurface, ref copiedEntity);
			if (copiedEntity != null)
			{
				entGroup.Solid.Entities.Add(copiedEntity);
			}
		}
	}

	public void SheetRectangle(double Width, double Height, ref buNestingSheet Sheet)
	{
		buEntity rectangleEntity = null;
		buCall.buVector5_0.DrawRectangle(new Point3D(), Width, Height, Plane.XY, ref rectangleEntity);
		Sheet.EntitiesGroup = new buEntitiesGroup();
		Sheet.EntitiesGroup.Outside.Entities.Add(rectangleEntity);
		Sheet.EntitiesGroup.Outside.Points = new List<Point3D>();
		buCall.buVector5_0.EntitiesToPointsWithCamDirection(Sheet.EntitiesGroup.Outside.Entities, ref Sheet.EntitiesGroup.Outside.Points);
		Entity entSurface = null;
		buCall.buVector5_0.surfaceFromOutterInner(Sheet.EntitiesGroup, 0.2, ref entSurface);
		if (entSurface != null)
		{
			Sheet.EntitiesGroup.Solid = new buEntityList();
			buEntity copiedEntity = null;
			buEntity.Copy(entSurface, ref copiedEntity);
			if (copiedEntity != null)
			{
				Sheet.EntitiesGroup.Solid.Entities.Add(copiedEntity);
			}
		}
	}

	public void PartRectangle(double Width, double Height, ref buNestingPart Part)
	{
		buEntity rectangleEntity = null;
		buCall.buVector5_0.DrawRectangle(new Point3D(), Width, Height, Plane.XY, ref rectangleEntity);
		Part.EntitiesGroup = new buEntitiesGroup();
		Part.EntitiesGroup.Outside.Entities.Add(rectangleEntity);
		Part.EntitiesGroup.Outside.Points = new List<Point3D>();
		buCall.buVector5_0.EntitiesToPointsWithCamDirection(Part.EntitiesGroup.Outside.Entities, ref Part.EntitiesGroup.Outside.Points);
		Entity entSurface = null;
		buCall.buVector5_0.surfaceFromOutterInner(Part.EntitiesGroup, 0.2, ref entSurface);
		if (entSurface != null)
		{
			Part.EntitiesGroup.Solid = new buEntityList();
			buEntity copiedEntity = null;
			buEntity.Copy(entSurface, ref copiedEntity);
			if (copiedEntity != null)
			{
				Part.EntitiesGroup.Solid.Entities.Add(copiedEntity);
			}
		}
	}

	public void SaveNesting(string FileName, List<buNestingPart> Parts, List<buNestingSheet> Sheets)
	{
		SaveNesting(FileName, Parts, Sheets, null, null);
	}

	public void SaveNesting(string FileName, List<buNestingPart> Parts, List<buNestingSheet> Sheets, buNestingVar Parameters)
	{
		SaveNesting(FileName, Parts, Sheets, null, Parameters);
	}

	public void SaveNesting(string FileName, List<buNestingPart> Parts, List<buNestingSheet> Sheets, buNestedResult Result, buNestingVar Parameters)
	{
		ArrayList arrayList = new ArrayList();
		if (Sheets != null)
		{
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Nestings Sheets");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(buNestingSheet.ToDef(Sheets, 2).ToArray());
		}
		if (Parts != null)
		{
			arrayList.Add(" ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Nestings Parts");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(buNestingPart.ToDef(Parts, 2).ToArray());
		}
		if (Parameters != null)
		{
			arrayList.Add(" ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Nesting Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(Parameters.AddMaterial.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.AddRange(Parameters.AddPart.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.AddRange(Parameters.MaterailSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.AddRange(Parameters.PartSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.AddRange(Parameters.ResultSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.AddRange(Parameters.Settings.ToDefAll("", 2, SerilizationMode5.MultiLine));
		}
		if (Result != null)
		{
			arrayList.Add(" ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Nesting Results");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(buNestedResult.ToDef(Result, 2));
		}
		if (arrayList.Count > 0)
		{
			buFile.SaveToFile(arrayList, FileName);
		}
	}

	public void OpenNesting(string FileName, ref List<buNestingPart> Parts, ref List<buNestingSheet> Sheets)
	{
		buNestedResult Result = new buNestedResult();
		buNestingVar Parameters = new buNestingVar();
		OpenNesting(FileName, ref Parts, ref Sheets, ref Result, ref Parameters);
	}

	public void OpenNesting(string FileName, ref List<buNestingPart> Parts, ref List<buNestingSheet> Sheets, ref buNestingVar Parameters)
	{
		buNestedResult Result = new buNestedResult();
		OpenNesting(FileName, ref Parts, ref Sheets, ref Result, ref Parameters);
	}

	public void OpenNesting(string FileName, ref List<buNestingPart> Parts, ref List<buNestingSheet> Sheets, ref buNestedResult Result, ref buNestingVar Parameters)
	{
		ArrayList StringList = new ArrayList();
		buFile.OpenFromFile(FileName, ref StringList);
		Parts.Clear();
		Parts = new List<buNestingPart>();
		Sheets.Clear();
		Sheets = new List<buNestingSheet>();
		buNestingSheet.Decode(StringList, ref Sheets);
		buNestingPart.Decode(StringList, ref Parts);
		buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, Parameters.AddMaterial);
		buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, Parameters.AddPart);
		buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, Parameters.MaterailSettings);
		buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, Parameters.PartSettings);
		buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, Parameters.ResultSettings);
		buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, Parameters.Settings);
		Result = new buNestedResult();
		buNestedResult.Decode(StringList, ref Result);
	}

	public void SetNestingCustomDataOfEntity(ref Entity refEntity)
	{
		if (refEntity.EntityData == null)
		{
			CustomData customData = new CustomData();
			customData.typeDefination = entityTypeDefination.Nesting;
			refEntity.EntityData = customData;
		}
		else if (!(refEntity.EntityData is CustomData))
		{
			CustomData customData2 = new CustomData();
			customData2.typeDefination = entityTypeDefination.Nesting;
			refEntity.EntityData = customData2;
		}
		else
		{
			((CustomData)refEntity.EntityData).typeDefination = entityTypeDefination.Nesting;
		}
	}
}
