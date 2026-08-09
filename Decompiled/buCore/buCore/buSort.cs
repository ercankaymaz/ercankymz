using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;

namespace buCore;

public class buSort
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

	public SortingAskMe AskMe = new SortingAskMe();

	private List<eEntities> list_0 = new List<eEntities>();

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

	public buSort()
	{
		if (buVector.smethod_0("buSort"))
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
		throw new RegisterException("buSort");
	}

	public void PrepareEntites(SortingFilter Filters, SortingOptions Options, List<eEntities> RefEntities, ref List<eEntities> CalculatedEntities)
	{
		try
		{
			bool flag = false;
			bool flag2 = false;
			if (RefEntities == null)
			{
				return;
			}
			CalculatedEntities = new List<eEntities>();
			for (int i = 0; i <= RefEntities.Count - 1; i++)
			{
				flag = false;
				flag2 = true;
				if (Filters != null)
				{
					if (Filters.SelectableEntities != null && Filters.SelectableEntities.Count > 0)
					{
						flag2 = false;
						for (int j = 0; j <= Filters.SelectableEntities.Count - 1; j++)
						{
							if (Filters.SelectableEntities[j].GetType() == RefEntities[i].GetType())
							{
								flag2 = true;
								j = Filters.SelectableEntities.Count;
							}
						}
					}
					if (Filters.SelectableIndex != null && Filters.SelectableIndex.Count > 0)
					{
						flag2 = false;
						for (int k = 0; k <= Filters.SelectableIndex.Count - 1; k++)
						{
							int num = Filters.SelectableIndex[k];
							if (num == RefEntities[i].EntityIndex)
							{
								flag2 = true;
								k = Filters.SelectableIndex.Count;
							}
						}
					}
					if (Filters.SelectableColor != null && Filters.SelectableColor.Count > 0)
					{
						flag2 = false;
						for (int l = 0; l <= Filters.SelectableColor.Count - 1; l++)
						{
							if (RefEntities[i].dispColor == Filters.SelectableColor[l])
							{
								flag2 = true;
								l = Filters.SelectableColor.Count;
							}
						}
					}
				}
				if (((RefEntities[i].GetType() == typeof(eCircle)) & RefEntities[i].bSelectable) && flag2)
				{
					List<eEntities> DevidedEntities = new List<eEntities>();
					buAppCalc.cVector.CircleDevide(RefEntities[i], new DevideData(1.0, DevideType.QuadraticArc), ((ePlaneEntities)RefEntities[i]).Plane, ref DevidedEntities);
					for (int m = 0; m <= DevidedEntities.Count - 1; m++)
					{
						CalculatedEntities.Add(DevidedEntities[m]);
					}
					flag = true;
				}
				if (((RefEntities[i].GetType() == typeof(eBSpline)) & RefEntities[i].bSelectable) && flag2)
				{
					eBSpline item = new eBSpline(eEntities.CopyEntity(RefEntities[i]));
					CalculatedEntities.Add(item);
					flag = true;
				}
				if (((RefEntities[i].GetType() == typeof(eBezeir)) & RefEntities[i].bSelectable) && flag2)
				{
					eBezeir item2 = new eBezeir(eEntities.CopyEntity(RefEntities[i]));
					CalculatedEntities.Add(item2);
					flag = true;
				}
				if (((RefEntities[i].GetType() == typeof(eArc)) & RefEntities[i].bSelectable) && flag2)
				{
					eArc item3 = new eArc(eEntities.CopyEntity(RefEntities[i]));
					CalculatedEntities.Add(item3);
					flag = true;
				}
				if (((RefEntities[i].GetType() == typeof(eEllipse)) & RefEntities[i].bSelectable) && flag2)
				{
					eEllipse item4 = new eEllipse(eEntities.CopyEntity(RefEntities[i]));
					CalculatedEntities.Add(item4);
					flag = true;
				}
				if (((RefEntities[i].GetType() == typeof(eEllipseArc)) & RefEntities[i].bSelectable) && flag2)
				{
					eEllipseArc item5 = new eEllipseArc(eEntities.CopyEntity(RefEntities[i]));
					CalculatedEntities.Add(item5);
					flag = true;
				}
				if (((RefEntities[i].GetType() == typeof(eLine)) & RefEntities[i].bSelectable) && flag2)
				{
					eLine item6 = new eLine(eEntities.CopyEntity(RefEntities[i]));
					CalculatedEntities.Add(item6);
					flag = true;
				}
				if (((RefEntities[i].GetType() == typeof(ePolyline)) & RefEntities[i].bSelectable) && flag2)
				{
					ePolyline item7 = new ePolyline(eEntities.CopyEntity(RefEntities[i]));
					CalculatedEntities.Add(item7);
					flag = true;
				}
				if ((!flag && flag2) & RefEntities[i].bSelectable)
				{
					CalculatedEntities.Add(eEntities.CopyEntity(RefEntities[i]));
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "Filters: " + Filters.ToString() + " - Options: " + Options.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void SortEntitiesByRefPoint(Pnt3D RefPoint, ref List<eEntities> BaseRefEntities, SortingOptions Options, ref List<eEntities> SortedEntities)
	{
		SortingResult Result = new SortingResult();
		SortEntitiesByRefPoint(RefPoint, ref BaseRefEntities, new WorkPlane(), new SortingFilter(), Options, new SortingCamData(), ref SortedEntities, ref Result);
	}

	public void SortEntitiesByRefPoint(Pnt3D RefPoint, ref List<eEntities> BaseRefEntities, WorkPlane Plane, SortingFilter Filter, SortingOptions Options, SortingCamData CamData, ref List<eEntities> SortedEntities, ref SortingResult Result)
	{
		List<eEntities> extraRefLines = new List<eEntities>();
		SortEntitiesByRefPoint(RefPoint, ref BaseRefEntities, extraRefLines, Plane, Filter, Options, CamData, ref SortedEntities, ref Result);
	}

	public void SortEntitiesByRefPoint(Pnt3D RefPoint, ref List<eEntities> BaseRefEntities, List<eEntities> ExtraRefLines, WorkPlane Plane, SortingFilter Filter, SortingOptions Options, SortingCamData CamData, ref List<eEntities> SortedEntities, ref SortingResult Result)
	{
		try
		{
			List<SortingFoundItems> Founds = new List<SortingFoundItems>();
			bool flag = false;
			int num = 0;
			Pnt3D pnt = new Pnt3D(RefPoint);
			Result.LastCalculatedEntities.Clear();
			Result.LastSelectedEntitiesIndex.Clear();
			while (true)
			{
				num++;
				Pnt3D pnt2 = new Pnt3D(RefPoint);
				int Sequence = 0;
				RefPoint = ((!Options.UsePlane) ? new Pnt3D(buAppCalc.cVector.MostClosestPoint(RefPoint, MostClosestPointType.OnlyNotCamSelectedEntities, new WorkPlane(), BaseRefEntities, ref Sequence)) : ((Plane != null) ? new Pnt3D(buAppCalc.cVector.MostClosestPoint(RefPoint, MostClosestPointType.OnlyNotCamSelectedEntities, Plane, BaseRefEntities, ref Sequence)) : new Pnt3D(buAppCalc.cVector.MostClosestPoint(RefPoint, MostClosestPointType.OnlyNotCamSelectedEntities, new WorkPlane(), BaseRefEntities, ref Sequence))));
				if (!AskMe.Return)
				{
					list_0.Clear();
					if (Sequence <= 0)
					{
						eEntities.CopyEntities(BaseRefEntities, ref list_0);
					}
					else
					{
						Pnt3D value = new Pnt3D(BaseRefEntities[Sequence].Vertice[0]);
						Pnt3D value2 = new Pnt3D(BaseRefEntities[Sequence].Vertice[BaseRefEntities[Sequence].Vertice.Count - 1]);
						if (!buCompare.EQ(RefPoint, value, Options.Resolution))
						{
							if (!buCompare.EQ(RefPoint, value2, Options.Resolution))
							{
								eEntities.CopyEntities(BaseRefEntities, ref list_0);
							}
							else
							{
								for (int num2 = Sequence; num2 >= 0; num2--)
								{
									list_0.Add(eEntities.CopyEntity(BaseRefEntities[num2]));
								}
								for (int num3 = BaseRefEntities.Count - 1; num3 >= Sequence + 1; num3--)
								{
									list_0.Add(eEntities.CopyEntity(BaseRefEntities[num3]));
								}
							}
						}
						else
						{
							for (int i = Sequence; i <= BaseRefEntities.Count - 1; i++)
							{
								list_0.Add(eEntities.CopyEntity(BaseRefEntities[i]));
							}
							for (int j = 0; j <= Sequence - 1; j++)
							{
								list_0.Add(eEntities.CopyEntity(BaseRefEntities[j]));
							}
						}
					}
				}
				int num4 = Convert.ToInt32((double)BaseRefEntities.Count / 100.0);
				int num5 = 0;
				bool flag2 = false;
				ClockDirectionType clockDirectionType = ClockDirectionType.CW;
				if (AskMe.Return && ((AskMe.SelectedIndex >= 0) & (AskMe.SelectedIndex <= AskMe.Entities.Count - 1)))
				{
					SortingFoundItems sortingFoundItems = new SortingFoundItems();
					sortingFoundItems.RefPoint = new Pnt3D(AskMe.RefPoint);
					sortingFoundItems.Index = AskMe.EntitiesIndex[AskMe.SelectedIndex];
					sortingFoundItems.Direction = camPathDirectionType.Normal;
					sortingFoundItems.Entity = eEntities.CopyEntity(AskMe.Entities[AskMe.SelectedIndex]);
					buAppCalc.cVector.CamDirectionSet(sortingFoundItems.RefPoint, ref sortingFoundItems.Entity);
					buAppCalc.cVector.GetOtherPointOfEntity(AskMe.RefPoint, sortingFoundItems.Entity, ref sortingFoundItems.RefPoint);
					Founds.Add(sortingFoundItems);
				}
				if (AskMe.ReturnNextGroup)
				{
					eUpperLine item = new eUpperLine(AskMe.RefPoint, RefPoint);
					SortedEntities.Add(item);
					SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
					AskMe.ReturnNextGroup = false;
				}
				int num6 = 0;
				while (true)
				{
					if (num6 <= BaseRefEntities.Count - 1)
					{
						if (!AskMe.Return)
						{
							while (true)
							{
								Founds.Clear();
								if (ExtraRefLines.Count <= 0)
								{
									break;
								}
								int ConnectionCount = 0;
								List<int> ConnectionIndex = new List<int>();
								HowManyConnectionAtRefPoint(ExtraRefLines, RefPoint, Options.Resolution, ref ConnectionCount, ref ConnectionIndex);
								int index;
								bool flag3;
								for (int k = 0; k <= ConnectionIndex.Count - 1; k++)
								{
									index = ConnectionIndex[k];
									if (ExtraRefLines[index].Vertice.Count <= 0)
									{
										continue;
									}
									Pnt3D value3 = new Pnt3D(ExtraRefLines[index].Vertice[0]);
									flag3 = false;
									if (!(buCompare.EQ(value3, RefPoint, Options.Resolution) & !ExtraRefLines[index].bCamSelected))
									{
										if (flag3)
										{
											continue;
										}
										value3 = new Pnt3D(ExtraRefLines[index].Vertice[ExtraRefLines[index].Vertice.Count - 1]);
										if (!(buCompare.EQ(value3, RefPoint, Options.Resolution) & !ExtraRefLines[index].bCamSelected))
										{
											continue;
										}
										goto IL_05d7;
									}
									goto IL_0683;
								}
								break;
								IL_05d7:
								if (SortedEntities[0].camDirections == camPathDirectionType.Reverse)
								{
									Options.IntersectionRules = SortingIntersectionRulesType.HigherIndex;
								}
								SortedEntities.Add(eEntities.CopyEntity(ExtraRefLines[index]));
								SortedEntities[SortedEntities.Count - 1].camDirections = camPathDirectionType.Reverse;
								RefPoint = new Pnt3D(ExtraRefLines[index].Vertice[0]);
								ExtraRefLines.RemoveAt(index);
								flag2 = true;
								List<Pnt3D> Points = new List<Pnt3D>();
								buAppCalc.cVector.EntityToPoint(SortedEntities, new EntityResolution(), ref Points);
								if (!buAppCalc.cVector.IsClosed(Points))
								{
									Points.Add(new Pnt3D(Points[0]));
								}
								clockDirectionType = buAppCalc.cVector.PolygonDirection(Points, Plane);
								continue;
								IL_0683:
								if (SortedEntities[0].camDirections == camPathDirectionType.Reverse)
								{
									Options.IntersectionRules = SortingIntersectionRulesType.HigherIndex;
								}
								SortedEntities.Add(eEntities.CopyEntity(ExtraRefLines[index]));
								RefPoint = new Pnt3D(ExtraRefLines[index].Vertice[ExtraRefLines[index].Vertice.Count - 1]);
								flag3 = true;
								ExtraRefLines.RemoveAt(index);
								flag2 = true;
								List<Pnt3D> Points2 = new List<Pnt3D>();
								buAppCalc.cVector.EntityToPoint(SortedEntities, new EntityResolution(), ref Points2);
								if (!buAppCalc.cVector.IsClosed(Points2))
								{
									Points2.Add(new Pnt3D(Points2[0]));
								}
								clockDirectionType = buAppCalc.cVector.PolygonDirection(Points2, Plane);
							}
							if (Founds.Count == 0)
							{
								for (int l = 0; l <= list_0.Count - 1; l++)
								{
									if (list_0[l].Vertice.Count > 0)
									{
										bool flag4 = false;
										if (!Filter.UsePointEntities & (list_0[l].GetType() == typeof(ePoint)))
										{
											flag4 = true;
										}
										if (!flag4)
										{
											Pnt3D pnt3D = new Pnt3D(list_0[l].Vertice[0]);
											Pnt3D pntEnd = new Pnt3D();
											if (list_0[l].Vertice.Count >= 2)
											{
												pntEnd = new Pnt3D(list_0[l].Vertice[1]);
											}
											bool flag5 = false;
											SortingFoundItems sortingFoundItems2 = new SortingFoundItems();
											if (buCompare.EQ(pnt3D, RefPoint, Options.Resolution) & !list_0[l].bCamSelected)
											{
												sortingFoundItems2.RefPoint = new Pnt3D(list_0[l].Vertice[list_0[l].Vertice.Count - 1]);
												sortingFoundItems2.Direction = camPathDirectionType.Normal;
												sortingFoundItems2.Entity = eEntities.CopyEntity(list_0[l]);
												sortingFoundItems2.Entity.camDirections = camPathDirectionType.Normal;
												sortingFoundItems2.Index = l;
												if (Options.AngleLimitation)
												{
													double num7 = buAppCalc.cVector.PointAngle(pntEnd, pnt3D);
													if ((num7 > Options.AngleMaxLimit) | (num7 < Options.AngleMinLimit))
													{
														sortingFoundItems2.RefPoint = new Pnt3D(list_0[l].Vertice[0]);
														sortingFoundItems2.Direction = camPathDirectionType.Reverse;
														sortingFoundItems2.Entity.camDirections = camPathDirectionType.Reverse;
													}
												}
												Founds.Add(sortingFoundItems2);
												flag5 = true;
											}
											pnt3D = new Pnt3D(list_0[l].Vertice[list_0[l].Vertice.Count - 1]);
											if (list_0[l].Vertice.Count >= 2)
											{
												pntEnd = new Pnt3D(list_0[l].Vertice[list_0[l].Vertice.Count - 2]);
											}
											if ((buCompare.EQ(pnt3D, RefPoint, Options.Resolution) & !list_0[l].bCamSelected) && !flag5)
											{
												sortingFoundItems2.RefPoint = new Pnt3D(list_0[l].Vertice[0]);
												sortingFoundItems2.Direction = camPathDirectionType.Reverse;
												sortingFoundItems2.Entity = eEntities.CopyEntity(list_0[l]);
												sortingFoundItems2.Entity.camDirections = camPathDirectionType.Reverse;
												sortingFoundItems2.Index = l;
												if (Options.AngleLimitation)
												{
													double num8 = buAppCalc.cVector.PointAngle(pntEnd, pnt3D);
													if ((num8 > Options.AngleMaxLimit) | (num8 < Options.AngleMinLimit))
													{
														sortingFoundItems2.RefPoint = new Pnt3D(list_0[l].Vertice[list_0[l].Vertice.Count - 1]);
														sortingFoundItems2.Direction = camPathDirectionType.Normal;
														sortingFoundItems2.Entity.camDirections = camPathDirectionType.Normal;
													}
												}
												Founds.Add(sortingFoundItems2);
											}
										}
									}
									if ((Founds.Count >= 1 && !flag2) & ((Options.IntersectionRules == SortingIntersectionRulesType.LowerIndex) | (Options.IntersectionRules == SortingIntersectionRulesType.FromDrawing)))
									{
										l = list_0.Count;
									}
								}
							}
						}
						if (Founds.Count == 0)
						{
							if (num > 2)
							{
								return;
							}
							if (Options.IntersectionRules == SortingIntersectionRulesType.With2Point)
							{
								break;
							}
							if (SortedEntities.Count > 0)
							{
								int num9 = 0;
								for (int m = 0; m <= SortedEntities.Count - 1; m++)
								{
									if (SortedEntities[m].GetType() != typeof(eUpperLine))
									{
										num9++;
									}
								}
								if (num9 >= BaseRefEntities.Count)
								{
									Result.FirstPoint = new Pnt3D(pnt2);
									Result.LastPoint = new Pnt3D(RefPoint);
									Result.ResultType = SortingResultType.Done;
									return;
								}
								if (SortedEntities[SortedEntities.Count - 1].GetType() == typeof(eUpperLine))
								{
									SortedEntities.RemoveAt(SortedEntities.Count - 1);
									Result.SelectedEntitiesIndex.Add(-1);
									return;
								}
								RefPoint = ((SortedEntities[SortedEntities.Count - 1].camDirections == camPathDirectionType.Normal) ? new Pnt3D(SortedEntities[SortedEntities.Count - 1].Vertice[SortedEntities[SortedEntities.Count - 1].Vertice.Count - 1]) : new Pnt3D(SortedEntities[SortedEntities.Count - 1].Vertice[0]));
							}
							if (num6 <= BaseRefEntities.Count - 1)
							{
								if ((Options.NextGroupRules == SortingNextGroupFindRulesType.MinYMinX) | (Options.NextGroupRules == SortingNextGroupFindRulesType.MinYMaxX))
								{
									Pnt3D pnt3D2 = new Pnt3D();
									List<Pnt3D> SortingPoints = new List<Pnt3D>();
									new List<Pnt3D>();
									double num10 = double.MaxValue;
									int num11 = -1;
									for (int n = 0; n <= list_0.Count - 1; n++)
									{
										double y = list_0[n].Vertice[0].Y;
										if ((y < num10) & list_0[n].bSelectable & !list_0[n].bSelected & !list_0[n].bCamSelected)
										{
											num10 = y;
											pnt3D2 = new Pnt3D(list_0[n].Vertice[0]);
											num11 = n;
										}
										y = list_0[n].Vertice[list_0[n].Vertice.Count - 1].Y;
										if ((y < num10) & list_0[n].bSelectable & !list_0[n].bSelected & !list_0[n].bCamSelected)
										{
											num10 = y;
											pnt3D2 = new Pnt3D(list_0[n].Vertice[list_0[n].Vertice.Count - 1]);
											num11 = n;
										}
									}
									SortingPoints.Add(new Pnt3D(pnt3D2));
									for (int num12 = 0; num12 <= list_0.Count - 1; num12++)
									{
										double y2 = list_0[num12].Vertice[0].Y;
										if ((((y2 < num10) | buCompare.EQ(y2, num10, 0.01)) && num12 != num11) & list_0[num12].bSelectable & !list_0[num12].bSelected & !list_0[num12].bCamSelected)
										{
											pnt3D2 = new Pnt3D(list_0[num12].Vertice[0]);
											SortingPoints.Add(pnt3D2);
											num11 = num12;
										}
										y2 = list_0[num12].Vertice[list_0[num12].Vertice.Count - 1].Y;
										if ((((y2 < num10) | buCompare.EQ(y2, num10, 0.01)) && num12 != num11) & list_0[num12].bSelectable & !list_0[num12].bSelected & !list_0[num12].bCamSelected)
										{
											pnt3D2 = new Pnt3D(list_0[num12].Vertice[list_0[num12].Vertice.Count - 1]);
											SortingPoints.Add(pnt3D2);
											num11 = num12;
										}
									}
									if (SortingPoints.Count > 1)
									{
										double MinX = 0.0;
										double MinY = 0.0;
										double MinZ = 0.0;
										buNumeric.GetMinXYZFromPointList(SortingPoints, ref MinX, ref MinY, ref MinZ);
										buAppCalc.cVector.SortDeltaX(new Pnt3D(MinX, 0.0), SortDirectionType.Lower, ref SortingPoints);
										if (Options.NextGroupRules == SortingNextGroupFindRulesType.MinYMaxX)
										{
											SortingPoints.Reverse();
										}
										pnt3D2 = new Pnt3D(SortingPoints[0]);
									}
									eUpperLine item2 = new eUpperLine(RefPoint, pnt3D2);
									SortedEntities.Add(item2);
									SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
									RefPoint = new Pnt3D(pnt3D2);
									num6--;
								}
								if ((Options.NextGroupRules == SortingNextGroupFindRulesType.MaxYMinX) | (Options.NextGroupRules == SortingNextGroupFindRulesType.MaxYMaxX))
								{
									Pnt3D pnt3D3 = new Pnt3D();
									List<Pnt3D> SortingPoints2 = new List<Pnt3D>();
									double num13 = double.MinValue;
									int num14 = -1;
									for (int num15 = 0; num15 <= list_0.Count - 1; num15++)
									{
										double y3 = list_0[num15].Vertice[0].Y;
										if ((y3 > num13) & list_0[num15].bSelectable & !list_0[num15].bSelected & !list_0[num15].bCamSelected)
										{
											num13 = y3;
											pnt3D3 = new Pnt3D(list_0[num15].Vertice[0]);
											num14 = num15;
										}
										y3 = list_0[num15].Vertice[list_0[num15].Vertice.Count - 1].Y;
										if ((y3 > num13) & list_0[num15].bSelectable & !list_0[num15].bSelected & !list_0[num15].bCamSelected)
										{
											num13 = y3;
											pnt3D3 = new Pnt3D(list_0[num15].Vertice[list_0[num15].Vertice.Count - 1]);
											num14 = num15;
										}
									}
									SortingPoints2.Add(new Pnt3D(pnt3D3));
									for (int num16 = 0; num16 <= list_0.Count - 1; num16++)
									{
										double y4 = list_0[num16].Vertice[0].Y;
										if ((((y4 > num13) | buCompare.EQ(y4, num13, 0.01)) && num16 != num14) & list_0[num16].bSelectable & !list_0[num16].bSelected & !list_0[num16].bCamSelected)
										{
											pnt3D3 = new Pnt3D(list_0[num16].Vertice[0]);
											SortingPoints2.Add(pnt3D3);
											num14 = num16;
										}
										y4 = list_0[num16].Vertice[list_0[num16].Vertice.Count - 1].Y;
										if ((((y4 > num13) | buCompare.EQ(y4, num13, 0.01)) && num16 != num14) & list_0[num16].bSelectable & !list_0[num16].bSelected & !list_0[num16].bCamSelected)
										{
											pnt3D3 = new Pnt3D(list_0[num16].Vertice[list_0[num16].Vertice.Count - 1]);
											SortingPoints2.Add(pnt3D3);
											num14 = num16;
										}
									}
									if (SortingPoints2.Count > 1)
									{
										double MinX2 = 0.0;
										double MinY2 = 0.0;
										double MinZ2 = 0.0;
										buNumeric.GetMinXYZFromPointList(SortingPoints2, ref MinX2, ref MinY2, ref MinZ2);
										buAppCalc.cVector.SortDeltaX(new Pnt3D(MinX2, 0.0), SortDirectionType.Lower, ref SortingPoints2);
										if (Options.NextGroupRules == SortingNextGroupFindRulesType.MaxYMaxX)
										{
											SortingPoints2.Reverse();
										}
										pnt3D3 = new Pnt3D(SortingPoints2[0]);
									}
									eUpperLine item3 = new eUpperLine(RefPoint, pnt3D3);
									SortedEntities.Add(item3);
									SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
									RefPoint = new Pnt3D(pnt3D3);
									num6--;
								}
								if ((Options.NextGroupRules == SortingNextGroupFindRulesType.MinXMinY) | (Options.NextGroupRules == SortingNextGroupFindRulesType.MinXMaxY))
								{
									Pnt3D pnt3D4 = new Pnt3D();
									List<Pnt3D> SortingPoints3 = new List<Pnt3D>();
									double num17 = double.MaxValue;
									int num18 = -1;
									for (int num19 = 0; num19 <= list_0.Count - 1; num19++)
									{
										double x = list_0[num19].Vertice[0].X;
										if ((x < num17) & list_0[num19].bSelectable & !list_0[num19].bSelected & !list_0[num19].bCamSelected)
										{
											num17 = x;
											pnt3D4 = new Pnt3D(list_0[num19].Vertice[0]);
											num18 = num19;
										}
										x = list_0[num19].Vertice[list_0[num19].Vertice.Count - 1].X;
										if ((x < num17) & list_0[num19].bSelectable & !list_0[num19].bSelected & !list_0[num19].bCamSelected)
										{
											num17 = x;
											pnt3D4 = new Pnt3D(list_0[num19].Vertice[list_0[num19].Vertice.Count - 1]);
											num18 = num19;
										}
									}
									SortingPoints3.Add(new Pnt3D(pnt3D4));
									for (int num20 = 0; num20 <= list_0.Count - 1; num20++)
									{
										double x2 = list_0[num20].Vertice[0].X;
										if ((((x2 < num17) | buCompare.EQ(x2, num17, 0.01)) && num20 != num18) & list_0[num20].bSelectable & !list_0[num20].bSelected & !list_0[num20].bCamSelected)
										{
											pnt3D4 = new Pnt3D(list_0[num20].Vertice[0]);
											SortingPoints3.Add(pnt3D4);
											num18 = num20;
										}
										x2 = list_0[num20].Vertice[list_0[num20].Vertice.Count - 1].X;
										if ((((x2 < num17) | buCompare.EQ(x2, num17, 0.01)) && num20 != num18) & list_0[num20].bSelectable & !list_0[num20].bSelected & !list_0[num20].bCamSelected)
										{
											pnt3D4 = new Pnt3D(list_0[num20].Vertice[list_0[num20].Vertice.Count - 1]);
											SortingPoints3.Add(pnt3D4);
											num18 = num20;
										}
									}
									if (SortingPoints3.Count > 1)
									{
										double MinX3 = 0.0;
										double MinY3 = 0.0;
										double MinZ3 = 0.0;
										buNumeric.GetMinXYZFromPointList(SortingPoints3, ref MinX3, ref MinY3, ref MinZ3);
										buAppCalc.cVector.SortDeltaY(new Pnt3D(0.0, MinY3), SortDirectionType.Lower, ref SortingPoints3);
										if (Options.NextGroupRules == SortingNextGroupFindRulesType.MinXMaxY)
										{
											SortingPoints3.Reverse();
										}
										pnt3D4 = new Pnt3D(SortingPoints3[0]);
									}
									eUpperLine item4 = new eUpperLine(RefPoint, pnt3D4);
									SortedEntities.Add(item4);
									SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
									RefPoint = new Pnt3D(pnt3D4);
									num6--;
								}
								if ((Options.NextGroupRules == SortingNextGroupFindRulesType.MaxXMinY) | (Options.NextGroupRules == SortingNextGroupFindRulesType.MaxXMaxY))
								{
									Pnt3D pnt3D5 = new Pnt3D();
									List<Pnt3D> SortingPoints4 = new List<Pnt3D>();
									double num21 = double.MinValue;
									int num22 = -1;
									for (int num23 = 0; num23 <= list_0.Count - 1; num23++)
									{
										double x3 = list_0[num23].Vertice[0].X;
										if ((x3 > num21) & list_0[num23].bSelectable & !list_0[num23].bSelected & !list_0[num23].bCamSelected)
										{
											num21 = x3;
											pnt3D5 = new Pnt3D(list_0[num23].Vertice[0]);
											num22 = num23;
										}
										x3 = list_0[num23].Vertice[list_0[num23].Vertice.Count - 1].X;
										if ((x3 > num21) & list_0[num23].bSelectable & !list_0[num23].bSelected & !list_0[num23].bCamSelected)
										{
											num21 = x3;
											pnt3D5 = new Pnt3D(list_0[num23].Vertice[list_0[num23].Vertice.Count - 1]);
											num22 = num23;
										}
									}
									SortingPoints4.Add(new Pnt3D(pnt3D5));
									for (int num24 = 0; num24 <= list_0.Count - 1; num24++)
									{
										double x4 = list_0[num24].Vertice[0].X;
										if ((((x4 > num21) | buCompare.EQ(x4, num21, 0.01)) && num24 != num22) & list_0[num24].bSelectable & !list_0[num24].bSelected & !list_0[num24].bCamSelected)
										{
											pnt3D5 = new Pnt3D(list_0[num24].Vertice[0]);
											SortingPoints4.Add(pnt3D5);
											num22 = num24;
										}
										x4 = list_0[num24].Vertice[list_0[num24].Vertice.Count - 1].X;
										if ((((x4 > num21) | buCompare.EQ(x4, num21, 0.01)) && num24 != num22) & list_0[num24].bSelectable & !list_0[num24].bSelected & !list_0[num24].bCamSelected)
										{
											pnt3D5 = new Pnt3D(list_0[num24].Vertice[list_0[num24].Vertice.Count - 1]);
											SortingPoints4.Add(pnt3D5);
											num22 = num24;
										}
									}
									if (SortingPoints4.Count > 1)
									{
										double MinX4 = 0.0;
										double MinY4 = 0.0;
										double MinZ4 = 0.0;
										buNumeric.GetMinXYZFromPointList(SortingPoints4, ref MinX4, ref MinY4, ref MinZ4);
										buAppCalc.cVector.SortDeltaY(new Pnt3D(0.0, MinY4), SortDirectionType.Lower, ref SortingPoints4);
										if (Options.NextGroupRules == SortingNextGroupFindRulesType.MaxXMaxY)
										{
											SortingPoints4.Reverse();
										}
										pnt3D5 = new Pnt3D(SortingPoints4[0]);
									}
									eUpperLine item5 = new eUpperLine(RefPoint, pnt3D5);
									SortedEntities.Add(item5);
									SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
									RefPoint = new Pnt3D(pnt3D5);
									num6--;
								}
								if (Options.NextGroupRules == SortingNextGroupFindRulesType.ClosestLength)
								{
									Pnt3D pnt3D6 = new Pnt3D();
									Pnt3D startPoint = new Pnt3D(RefPoint);
									if (Options.AlwaysUseZeroPointAfterJump)
									{
										RefPoint = new Pnt3D();
									}
									pnt3D6 = ((!Options.UsePlane) ? buAppCalc.cVector.MostClosestPoint(RefPoint, Filter.MostClosestType, new WorkPlane(), list_0) : ((Plane != null) ? buAppCalc.cVector.MostClosestPoint(RefPoint, Filter.MostClosestType, Plane, list_0) : buAppCalc.cVector.MostClosestPoint(RefPoint, Filter.MostClosestType, new WorkPlane(), list_0)));
									eUpperLine item6 = new eUpperLine(startPoint, pnt3D6);
									SortedEntities.Add(item6);
									SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
									RefPoint = new Pnt3D(pnt3D6);
									num6--;
								}
								if (Options.NextGroupRules == SortingNextGroupFindRulesType.DrawingSequence)
								{
									Pnt3D pnt3D7 = new Pnt3D();
									int FoundIndex = -1;
									buAppCalc.cVector.FindLowerAvailableIndexOfEntities(BaseRefEntities, ref FoundIndex);
									if (FoundIndex >= 0)
									{
										double num25 = 0.0;
										double num26 = 0.0;
										num25 = buAppCalc.cVector.Length3D(RefPoint, BaseRefEntities[FoundIndex].Vertice[0]);
										num26 = buAppCalc.cVector.Length3D(RefPoint, BaseRefEntities[FoundIndex].Vertice[BaseRefEntities[FoundIndex].Vertice.Count - 1]);
										pnt3D7 = ((num25 < num26) ? new Pnt3D(BaseRefEntities[FoundIndex].Vertice[0]) : new Pnt3D(BaseRefEntities[FoundIndex].Vertice[BaseRefEntities[FoundIndex].Vertice.Count - 1]));
									}
									eUpperLine item7 = new eUpperLine(RefPoint, pnt3D7);
									SortedEntities.Add(item7);
									SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
									RefPoint = new Pnt3D(pnt3D7);
									num6--;
								}
								if (Options.NextGroupRules == SortingNextGroupFindRulesType.AskMe)
								{
									for (int num27 = 0; num27 <= SortedEntities.Count - 1; num27++)
									{
										if (!(SortedEntities[num27].GetType() != typeof(eUpperLine)))
										{
											eEntities copiedEnt = new eEntities();
											eEntities.CopyEntity(SortedEntities[num27], ref copiedEnt);
											AskMe.UpperEntities.Add(copiedEnt);
										}
										else
										{
											eEntities copiedEnt2 = new eEntities();
											eEntities.CopyEntity(SortedEntities[num27], ref copiedEnt2);
											AskMe.SortedEntities.Add(copiedEnt2);
										}
									}
									AskMe.RefPoint = new Pnt3D();
									Result.LastPoint = new Pnt3D(RefPoint);
									Result.ResultType = SortingResultType.SelectNextGroup;
									return;
								}
								if (Options.NextGroupRules == SortingNextGroupFindRulesType.NoNextGroup)
								{
									Result.ResultType = SortingResultType.Done;
									return;
								}
							}
							AskMe.Return = false;
						}
						if (Founds.Count > 0)
						{
							if (Founds.Count == 1)
							{
								RefPoint = new Pnt3D(Founds[0].RefPoint);
								int ListIndex = -1;
								buAppCalc.cVector.FindEntityListIndexByEntityIndex(BaseRefEntities, list_0[Founds[0].Index].EntityIndex, ref ListIndex);
								if ((ListIndex >= 0) & (ListIndex <= BaseRefEntities.Count - 1) & Options.UseCamSelectedProps)
								{
									BaseRefEntities[ListIndex].bCamSelected = true;
								}
								SortAddFoundToList(Founds[0], ref SortedEntities, ref list_0, CamData, ref Result);
								AskMe = new SortingAskMe();
								RefPoint = new Pnt3D(Founds[0].RefPoint);
								if (Options.UseStopPoint && buCompare.EQ(RefPoint, Options.StopPoint))
								{
									Result.ResultType = SortingResultType.Done;
									return;
								}
								if (Options.IntersectionRules == SortingIntersectionRulesType.With2Point && RefPoint == Options.EndPoint)
								{
									Result.ResultType = SortingResultType.Done;
									return;
								}
							}
							if (Founds.Count > 1)
							{
								bool FoundUsed = false;
								if (flag2)
								{
									int num28 = -1;
									for (int num29 = 0; num29 <= Founds.Count - 1; num29++)
									{
										ClockDirectionType clockDirectionType2 = ClockDirectionType.CW;
										List<eEntities> CopiedEnt = new List<eEntities>();
										eEntities.CopyEntities(SortedEntities, ref CopiedEnt);
										CopiedEnt.Add(Founds[num29].Entity);
										List<Pnt3D> Points3 = new List<Pnt3D>();
										buAppCalc.cVector.EntityToPoint(CopiedEnt, new EntityResolution(), ref Points3);
										if (!buAppCalc.cVector.IsClosed(Points3))
										{
											Points3.Add(new Pnt3D(Points3[0]));
										}
										double TotalArea = 0.0;
										clockDirectionType2 = buAppCalc.cVector.PolygonDirection(Points3, Plane, ref TotalArea);
										bool flag6 = buAppCalc.cVector.PolygonIsConvex(Points3);
										if (clockDirectionType2 == clockDirectionType && flag6)
										{
											num28 = num29;
										}
									}
									if (num28 >= 0)
									{
										RefPoint = new Pnt3D(Founds[num28].RefPoint);
										SortedEntities.Add(eEntities.CopyEntity(list_0[Founds[num28].Index]));
										Result.LastCalculatedEntities.Add(eEntities.CopyEntity(list_0[Founds[num28].Index]));
										if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.SelectedEntitiesIndex, list_0[Founds[num28].Index].EntityIndex))
										{
											Result.SelectedEntitiesIndex.Add(list_0[Founds[num28].Index].EntityIndex);
										}
										if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.LastSelectedEntitiesIndex, list_0[Founds[num28].Index].EntityIndex))
										{
											Result.LastSelectedEntitiesIndex.Add(list_0[Founds[num28].Index].EntityIndex);
										}
										list_0.RemoveAt(Founds[num28].Index);
										SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
										SortedEntities[SortedEntities.Count - 1].bCamSelected = true;
										SortedEntities[SortedEntities.Count - 1].camDirections = Founds[num28].Direction;
										Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
										Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].bCamSelected = true;
										Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camDirections = Founds[num28].Direction;
										FoundUsed = true;
									}
								}
								if (Options.IntersectionRules == SortingIntersectionRulesType.With2Point && !FoundUsed)
								{
									int index2 = 0;
									if (flag)
									{
										index2 = Founds.Count - 1;
									}
									RefPoint = new Pnt3D(Founds[index2].RefPoint);
									SortedEntities.Add(eEntities.CopyEntity(list_0[Founds[index2].Index]));
									Result.LastCalculatedEntities.Add(eEntities.CopyEntity(list_0[Founds[index2].Index]));
									if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.SelectedEntitiesIndex, list_0[Founds[index2].Index].EntityIndex))
									{
										Result.SelectedEntitiesIndex.Add(list_0[Founds[index2].Index].EntityIndex);
									}
									if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.LastSelectedEntitiesIndex, list_0[Founds[index2].Index].EntityIndex))
									{
										Result.LastSelectedEntitiesIndex.Add(list_0[Founds[index2].Index].EntityIndex);
									}
									list_0.RemoveAt(Founds[index2].Index);
									SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
									SortedEntities[SortedEntities.Count - 1].bCamSelected = true;
									SortedEntities[SortedEntities.Count - 1].camDirections = Founds[index2].Direction;
									Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
									Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].bCamSelected = true;
									Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camDirections = Founds[index2].Direction;
									FoundUsed = true;
								}
								if ((((Options.IntersectionRules == SortingIntersectionRulesType.LowerIndex) | (Options.IntersectionRules == SortingIntersectionRulesType.HigherIndex) | (Options.IntersectionRules == SortingIntersectionRulesType.FromDrawing)) && !FoundUsed) & !AskMe.Return)
								{
									int index3 = 0;
									if ((Options.IntersectionRules == SortingIntersectionRulesType.LowerIndex) | (Options.IntersectionRules == SortingIntersectionRulesType.FromDrawing))
									{
										index3 = 0;
									}
									if (Options.IntersectionRules == SortingIntersectionRulesType.HigherIndex)
									{
										index3 = Founds.Count - 1;
									}
									if ((SortedEntities.Count == 0) & Options.If2PointAtFirstPointUseSecondOne)
									{
										index3 = 1;
									}
									RefPoint = new Pnt3D(Founds[index3].RefPoint);
									SortedEntities.Add(eEntities.CopyEntity(list_0[Founds[index3].Index]));
									Result.LastCalculatedEntities.Add(eEntities.CopyEntity(list_0[Founds[index3].Index]));
									if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.SelectedEntitiesIndex, list_0[Founds[index3].Index].EntityIndex))
									{
										Result.SelectedEntitiesIndex.Add(list_0[Founds[index3].Index].EntityIndex);
									}
									if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.LastSelectedEntitiesIndex, list_0[Founds[index3].Index].EntityIndex))
									{
										Result.LastSelectedEntitiesIndex.Add(list_0[Founds[index3].Index].EntityIndex);
									}
									list_0.RemoveAt(Founds[index3].Index);
									SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
									SortedEntities[SortedEntities.Count - 1].bCamSelected = true;
									SortedEntities[SortedEntities.Count - 1].camDirections = Founds[index3].Direction;
									Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
									Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].bCamSelected = true;
									Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camDirections = Founds[index3].Direction;
									FoundUsed = true;
								}
								if ((((Options.IntersectionRules == SortingIntersectionRulesType.LowerAngle) | (Options.IntersectionRules == SortingIntersectionRulesType.HighAngle)) && !FoundUsed) & !AskMe.Return)
								{
									SortHighOrLowerAngle(ref RefPoint, ref FoundUsed, ref SortedEntities, ref Founds, ref list_0, Options, CamData, ref Result);
								}
								if (Options.IntersectionRules == SortingIntersectionRulesType.AskMe)
								{
									if (!AskMe.Return)
									{
										AskMe.Entities = new List<eEntities>();
										for (int num30 = 0; num30 <= Founds.Count - 1; num30++)
										{
											AskMe.Entities.Add(eEntities.CopyEntity(list_0[Founds[num30].Index]));
											AskMe.EntitiesIndex.Add(Founds[num30].Index);
										}
										AskMe.Return = true;
										AskMe.RefPoint = new Pnt3D(RefPoint);
										AskMe.SelectedIndex = 0;
										Result.ResultType = SortingResultType.MultipleEntities;
										return;
									}
									if (AskMe.Return)
									{
										int num31 = 0;
										if (AskMe.SelectedIndex > Founds.Count - 1)
										{
											AskMe.SelectedIndex = 0;
										}
										num31 = AskMe.SelectedIndex;
										RefPoint = new Pnt3D(Founds[num31].RefPoint);
										SortAddFoundToList(Founds[num31], ref SortedEntities, ref list_0, CamData, ref Result);
										AskMe.Return = false;
									}
								}
							}
						}
						flag2 = false;
						if (buSystem.ProgressControlEnable && calculationEventHandler_0 != null)
						{
							calculationEventHandler_0(new CalculationEventArg(50.0, Convert.ToDouble((double)num6 / (double)(BaseRefEntities.Count - 1)) * 100.0, 0, "Sorting Entities", ""));
						}
						if (buSystem.DoEventEnable && num4 > 0 && num5 > 0 && num5 % num4 == 0)
						{
							Application.DoEvents();
						}
						if (!buSystem.Cancel)
						{
							num5++;
							num6++;
							continue;
						}
						buSystem.Cancel = false;
						buSystem.Canceled = true;
						if (calculationEventHandler_2 != null)
						{
							calculationEventHandler_2(new CalculationEventArg());
						}
						if (calculationEventHandler_3 != null)
						{
							calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "Soring Entities", ""));
						}
						buLog.addLog("Soring Entities", "Canceled", MethodBase.GetCurrentMethod().Name);
						return;
					}
					if (SortedEntities.Count <= 0)
					{
						return;
					}
					int num32 = 0;
					for (int num33 = 0; num33 <= SortedEntities.Count - 1; num33++)
					{
						if (SortedEntities[num33].GetType() != typeof(eUpperLine))
						{
							num32++;
						}
					}
					if (num32 < BaseRefEntities.Count)
					{
						if (!(SortedEntities[SortedEntities.Count - 1].GetType() == typeof(eUpperLine)))
						{
							RefPoint = ((SortedEntities[SortedEntities.Count - 1].camDirections == camPathDirectionType.Normal) ? new Pnt3D(SortedEntities[SortedEntities.Count - 1].Vertice[SortedEntities[SortedEntities.Count - 1].Vertice.Count - 1]) : new Pnt3D(SortedEntities[SortedEntities.Count - 1].Vertice[0]));
							return;
						}
						SortedEntities.RemoveAt(SortedEntities.Count - 1);
						Result.SelectedEntitiesIndex.Add(-1);
					}
					else
					{
						Result.FirstPoint = new Pnt3D(pnt2);
						Result.LastPoint = new Pnt3D(RefPoint);
						Result.ResultType = SortingResultType.Done;
					}
					return;
				}
				if (flag)
				{
					if (!(RefPoint == Options.EndPoint))
					{
						flag = true;
						continue;
					}
					Result.ResultType = SortingResultType.Done;
					break;
				}
				if (!(RefPoint == Options.EndPoint))
				{
					SortedEntities = new List<eEntities>();
					flag = true;
					RefPoint = new Pnt3D(pnt);
					continue;
				}
				Result.ResultType = SortingResultType.Done;
				break;
			}
		}
		catch (Exception mSException)
		{
			string text = "Filters: " + Filter.ToString() + " - Options: " + Options.ToString() + " - RefPoint: " + RefPoint.ToString() + " - Plane: " + Plane.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void SortPointsByRefPoint(Pnt3D RefPoint, ref List<Pnt3D> BaseRefPoints, WorkPlane Plane, SortingFilter Filter, SortingOptions Options, SortingCamData CamData, ref List<List<Pnt3D>> SortedPoints, ref SortingResult Result)
	{
		try
		{
		}
		catch (Exception mSException)
		{
			string text = "Filters: " + Filter.ToString() + " - Options: " + Options.ToString() + " - RefPoint: " + RefPoint.ToString() + " - Plane: " + Plane.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void SortHighOrLowerAngle(ref Pnt3D RefPoint, ref bool FoundUsed, ref List<eEntities> SortedEntities, ref List<SortingFoundItems> Founds, ref List<eEntities> tempCircularEntities, SortingOptions Options, SortingCamData CamData, ref SortingResult Result)
	{
		if (SortedEntities.Count <= 0)
		{
			int index = 0;
			RefPoint = new Pnt3D(Founds[0].RefPoint);
			SortedEntities.Add(eEntities.CopyEntity(tempCircularEntities[Founds[0].Index]));
			Result.LastCalculatedEntities.Add(eEntities.CopyEntity(tempCircularEntities[Founds[0].Index]));
			tempCircularEntities.RemoveAt(Founds[0].Index);
			if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.SelectedEntitiesIndex, tempCircularEntities[Founds[0].Index].EntityIndex))
			{
				Result.SelectedEntitiesIndex.Add(tempCircularEntities[Founds[index].Index].EntityIndex);
			}
			if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.LastSelectedEntitiesIndex, tempCircularEntities[Founds[index].Index].EntityIndex))
			{
				Result.LastSelectedEntitiesIndex.Add(tempCircularEntities[Founds[index].Index].EntityIndex);
			}
			SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
			SortedEntities[SortedEntities.Count - 1].bCamSelected = true;
			SortedEntities[SortedEntities.Count - 1].camDirections = Founds[index].Direction;
			Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
			Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].bCamSelected = true;
			Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camDirections = Founds[index].Direction;
			FoundUsed = true;
			return;
		}
		if (SortedEntities[SortedEntities.Count - 1].Vertice.Count <= 1)
		{
			int index2 = 0;
			RefPoint = new Pnt3D(Founds[0].RefPoint);
			SortedEntities.Add(eEntities.CopyEntity(tempCircularEntities[Founds[0].Index]));
			Result.LastCalculatedEntities.Add(eEntities.CopyEntity(tempCircularEntities[Founds[0].Index]));
			tempCircularEntities.RemoveAt(Founds[0].Index);
			if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.SelectedEntitiesIndex, tempCircularEntities[Founds[0].Index].EntityIndex))
			{
				Result.SelectedEntitiesIndex.Add(tempCircularEntities[Founds[index2].Index].EntityIndex);
			}
			if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.LastSelectedEntitiesIndex, tempCircularEntities[Founds[index2].Index].EntityIndex))
			{
				Result.LastSelectedEntitiesIndex.Add(tempCircularEntities[Founds[index2].Index].EntityIndex);
			}
			SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
			SortedEntities[SortedEntities.Count - 1].bCamSelected = true;
			SortedEntities[SortedEntities.Count - 1].camDirections = Founds[index2].Direction;
			Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
			Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].bCamSelected = true;
			Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camDirections = Founds[index2].Direction;
			FoundUsed = true;
			return;
		}
		Pnt3D pnt3D = new Pnt3D();
		Pnt3D pnt3D2 = new Pnt3D();
		if (SortedEntities[SortedEntities.Count - 1].camDirections != camPathDirectionType.Normal)
		{
			pnt3D = new Pnt3D(SortedEntities[SortedEntities.Count - 1].Vertice[0]);
			pnt3D2 = new Pnt3D(SortedEntities[SortedEntities.Count - 1].Vertice[1]);
		}
		else
		{
			pnt3D = new Pnt3D(SortedEntities[SortedEntities.Count - 1].Vertice[SortedEntities[SortedEntities.Count - 1].Vertice.Count - 1]);
			pnt3D2 = new Pnt3D(SortedEntities[SortedEntities.Count - 1].Vertice[SortedEntities[SortedEntities.Count - 1].Vertice.Count - 2]);
		}
		Pnt3D secondLineStart = new Pnt3D();
		Pnt3D secondLineEnd = new Pnt3D();
		double num = 0.0;
		double num2 = -9999999.0;
		double num3 = 9999999.0;
		int num4 = 0;
		int num5 = 0;
		for (int i = 0; i <= Founds.Count - 1; i++)
		{
			Pnt3D value = new Pnt3D(tempCircularEntities[Founds[i].Index].Vertice[0]);
			Pnt3D value2 = new Pnt3D(tempCircularEntities[Founds[i].Index].Vertice[tempCircularEntities[Founds[i].Index].Vertice.Count - 1]);
			if (buCompare.EQ(pnt3D, value, Options.Resolution))
			{
				secondLineStart = new Pnt3D(tempCircularEntities[Founds[i].Index].Vertice[0]);
				secondLineEnd = new Pnt3D(tempCircularEntities[Founds[i].Index].Vertice[1]);
			}
			if (buCompare.EQ(pnt3D, value2, Options.Resolution))
			{
				secondLineStart = new Pnt3D(tempCircularEntities[Founds[i].Index].Vertice[tempCircularEntities[Founds[i].Index].Vertice.Count - 1]);
				secondLineEnd = new Pnt3D(tempCircularEntities[Founds[i].Index].Vertice[tempCircularEntities[Founds[i].Index].Vertice.Count - 2]);
			}
			num = buAppCalc.cVector.AngleOfTwoLines(pnt3D, pnt3D2, secondLineStart, secondLineEnd, new WorkPlane());
			if (num > num2)
			{
				num2 = num;
				num4 = i;
			}
			if (num < num3)
			{
				num3 = num;
				num5 = i;
			}
		}
		if (Options.IntersectionRules == SortingIntersectionRulesType.HighAngle)
		{
			int index3 = num4;
			RefPoint = new Pnt3D(Founds[index3].RefPoint);
			SortedEntities.Add(eEntities.CopyEntity(tempCircularEntities[Founds[index3].Index]));
			Result.LastCalculatedEntities.Add(eEntities.CopyEntity(tempCircularEntities[Founds[index3].Index]));
			if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.SelectedEntitiesIndex, tempCircularEntities[Founds[index3].Index].EntityIndex))
			{
				Result.SelectedEntitiesIndex.Add(tempCircularEntities[Founds[index3].Index].EntityIndex);
			}
			if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.LastSelectedEntitiesIndex, tempCircularEntities[Founds[index3].Index].EntityIndex))
			{
				Result.LastSelectedEntitiesIndex.Add(tempCircularEntities[Founds[index3].Index].EntityIndex);
			}
			tempCircularEntities.RemoveAt(Founds[index3].Index);
			SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
			SortedEntities[SortedEntities.Count - 1].bCamSelected = true;
			SortedEntities[SortedEntities.Count - 1].camDirections = Founds[index3].Direction;
			Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
			Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].bCamSelected = true;
			Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camDirections = Founds[index3].Direction;
			FoundUsed = true;
		}
		if (Options.IntersectionRules == SortingIntersectionRulesType.LowerAngle)
		{
			int index4 = num5;
			RefPoint = new Pnt3D(Founds[index4].RefPoint);
			SortedEntities.Add(eEntities.CopyEntity(tempCircularEntities[Founds[index4].Index]));
			Result.LastCalculatedEntities.Add(eEntities.CopyEntity(tempCircularEntities[Founds[index4].Index]));
			tempCircularEntities.RemoveAt(Founds[index4].Index);
			if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.SelectedEntitiesIndex, tempCircularEntities[Founds[index4].Index].EntityIndex))
			{
				Result.SelectedEntitiesIndex.Add(tempCircularEntities[Founds[index4].Index].EntityIndex);
			}
			if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.LastSelectedEntitiesIndex, tempCircularEntities[Founds[index4].Index].EntityIndex))
			{
				Result.LastSelectedEntitiesIndex.Add(tempCircularEntities[Founds[index4].Index].EntityIndex);
			}
			SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
			SortedEntities[SortedEntities.Count - 1].bCamSelected = true;
			SortedEntities[SortedEntities.Count - 1].camDirections = Founds[index4].Direction;
			Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
			Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].bCamSelected = true;
			Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camDirections = Founds[index4].Direction;
			FoundUsed = true;
		}
	}

	public void SortAddFoundToList(SortingFoundItems FoundItem, ref List<eEntities> SortedEntities, ref List<eEntities> tempCircularEntities, SortingCamData CamData, ref SortingResult Result)
	{
		SortedEntities.Add(FoundItem.Entity);
		Result.LastCalculatedEntities.Add(eEntities.CopyEntity(FoundItem.Entity));
		if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.SelectedEntitiesIndex, tempCircularEntities[FoundItem.Index].EntityIndex))
		{
			Result.SelectedEntitiesIndex.Add(tempCircularEntities[FoundItem.Index].EntityIndex);
		}
		if (!buAppCalc.cVector.IsIndexNumberAvailableAtList(Result.LastSelectedEntitiesIndex, tempCircularEntities[FoundItem.Index].EntityIndex))
		{
			Result.LastSelectedEntitiesIndex.Add(tempCircularEntities[FoundItem.Index].EntityIndex);
		}
		tempCircularEntities.RemoveAt(FoundItem.Index);
		SortedEntities[SortedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
		SortedEntities[SortedEntities.Count - 1].bCamSelected = true;
		Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camToolNo = CamData.Tool.Data.No;
		Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].bCamSelected = true;
		Result.LastCalculatedEntities[Result.LastCalculatedEntities.Count - 1].camDirections = FoundItem.Direction;
	}

	public void HowManyConnectionAtRefPoint(List<eEntities> RefEntities, Pnt3D RefPoint, double Resolution, ref int ConnectionCount)
	{
		List<int> ConnectionIndex = new List<int>();
		HowManyConnectionAtRefPoint(RefEntities, RefPoint, Resolution, ref ConnectionCount, ref ConnectionIndex);
	}

	public void HowManyConnectionAtRefPoint(List<eEntities> RefEntities, Pnt3D RefPoint, double Resolution, ref int ConnectionCount, ref List<int> ConnectionIndex)
	{
		try
		{
			ConnectionCount = 0;
			ConnectionIndex.Clear();
			for (int i = 0; i <= RefEntities.Count - 1; i++)
			{
				if (RefEntities[i].Vertice.Count <= 0)
				{
					continue;
				}
				Pnt3D value = new Pnt3D(RefEntities[i].Vertice[0]);
				bool flag = false;
				if (buCompare.EQ(value, RefPoint, Resolution) & !RefEntities[i].bCamSelected)
				{
					ConnectionCount++;
					ConnectionIndex.Add(i);
					flag = true;
				}
				if (!flag)
				{
					value = new Pnt3D(RefEntities[i].Vertice[RefEntities[i].Vertice.Count - 1]);
					if (buCompare.EQ(value, RefPoint, Resolution) & !RefEntities[i].bCamSelected)
					{
						ConnectionCount++;
						ConnectionIndex.Add(i);
					}
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "RefEntities: " + RefEntities.Count + " - RefPoint: " + RefPoint.ToString() + " - Resolution: " + Resolution;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void FindInternalEntitiesAtClosedContour(List<Pnt3D> ClosedContour, List<eEntities> Entities, WorkPlane Plane, ref List<List<eEntities>> ClosedEntities, ref List<List<eEntities>> NotClosedEntities)
	{
		try
		{
			List<eEntities> BaseRefEntities = new List<eEntities>();
			List<eEntities> SortedEntities = new List<eEntities>();
			List<List<eEntities>> SplitedEntitites = new List<List<eEntities>>();
			SortingOptions sortingOptions = new SortingOptions();
			Pnt3D MinPoint = new Pnt3D();
			Pnt3D MaxPoint = new Pnt3D();
			buAppCalc.cVector.BoxSizeCalculate(ClosedContour, ref MinPoint, ref MaxPoint);
			sortingOptions.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
			sortingOptions.IntersectionRules = SortingIntersectionRulesType.LowerIndex;
			for (int i = 0; i <= Entities.Count - 1; i++)
			{
				if (!Entities[i].bVisible)
				{
					continue;
				}
				bool flag = buAppCalc.cVector.IsPointInsideWindow(MinPoint, MaxPoint, Entities[i].geoMinPoint, Plane, UseEqualCondition: false);
				bool flag2 = buAppCalc.cVector.IsPointInsideWindow(MinPoint, MaxPoint, Entities[i].geoMaxPoint, Plane, UseEqualCondition: false);
				bool flag3 = flag && flag2;
				if (flag && flag2)
				{
					for (int j = 0; j <= Entities[i].Vertice.Count - 1; j++)
					{
						bool flag4 = buAppCalc.cVector.IsPointInsidePolygon(ClosedContour, Entities[i].Vertice[j]);
						flag3 = flag3 && flag4;
					}
				}
				if (flag3)
				{
					BaseRefEntities.Add(eEntities.CopyEntity(Entities[i]));
				}
			}
			if (BaseRefEntities.Count > 0)
			{
				SortEntitiesByRefPoint(BaseRefEntities[0].Vertice[0], ref BaseRefEntities, sortingOptions, ref SortedEntities);
			}
			buAppCalc.cVector.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
			for (int k = 0; k <= SplitedEntitites.Count - 1; k++)
			{
				if (!buAppCalc.cVector.IsEntitiesClosedPath(SplitedEntitites[k]))
				{
					List<eEntities> CopiedEnt = new List<eEntities>();
					eEntities.CopyEntities(SplitedEntitites[k], ref CopiedEnt);
					NotClosedEntities.Add(CopiedEnt);
				}
				else
				{
					List<eEntities> CopiedEnt2 = new List<eEntities>();
					eEntities.CopyEntities(SplitedEntitites[k], ref CopiedEnt2);
					ClosedEntities.Add(CopiedEnt2);
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "ClosedContour: " + ClosedContour.Count + " - Entities: " + Entities.Count + " - Plane: " + Plane.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void FindOutsideEntitiesFromAllEntities(Pnt3D RefPoint, List<eEntities> AllEntities, WorkPlane Plane, ref List<eEntities> OutsideEntities, ref List<Pnt3D> OutsidePoints)
	{
		try
		{
			SortingFilter filter = new SortingFilter();
			SortingOptions sortingOptions = new SortingOptions();
			SortingResult Result = new SortingResult();
			sortingOptions.UseCamSelectedProps = false;
			sortingOptions.IntersectionRules = SortingIntersectionRulesType.LowerIndex;
			sortingOptions.NextGroupRules = SortingNextGroupFindRulesType.NoNextGroup;
			OutsideEntities = new List<eEntities>();
			SortEntitiesByRefPoint(RefPoint, ref AllEntities, Plane, filter, sortingOptions, new SortingCamData(), ref OutsideEntities, ref Result);
			OutsidePoints.Clear();
			buAppCalc.cVector.EntityToPoint(OutsideEntities, buSystem.EntitiesResolution, ref OutsidePoints);
			buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref OutsidePoints, 0.01);
		}
		catch (Exception mSException)
		{
			string text = "AllEntities: " + AllEntities.Count + " - RefPoint: " + RefPoint.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}
}
