using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Opaline2Cs;
using PowerNest2Cs;
using buClass;
using buControls.DialogBox;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using ns8;

namespace buCadCamResVer5.Nesting;

public class clsPowerNest
{
	public static List<string> ErrorList = new List<string>();

	public PowerNest2 tempPowerNest = null;

	public Opaline OPL = new Opaline();

	public string Login = "fatih@115";

	public static bool bExecute = false;

	public static bool bExecuteDone = false;

	public static bool bStop = false;

	public static Thread threadExecute = null;

	public static int ExecutionCounter = 0;

	public List<buNestedResult> tempBetterNestedResult = new List<buNestedResult>();

	public static List<MultiResult> storedNestedResult = new List<MultiResult>();

	private MultiResult multiResult_0 = null;

	private IList<Sheet> ilist_0 = new List<Sheet>();

	private IList<buNestingSheet> ilist_1 = new List<buNestingSheet>();

	private IList<PowerNest2Cs.Part> ilist_2 = new List<PowerNest2Cs.Part>();

	private IList<buNestingPart> ilist_3 = new List<buNestingPart>();

	private IList<int> ilist_4 = new List<int>();

	private IUserData iuserData_0 = null;

	private IUserData iuserData_1 = null;

	private System.Windows.Forms.Timer timer_0 = new System.Windows.Forms.Timer();

	private double double_0 = 30.0;

	private int int_0 = 1;

	private bool bool_0 = false;

	private DateTime dateTime_0 = default(DateTime);

	public string PowerNestLogin => Login.Trim();

	public bool isDongleAvailable()
	{
		try
		{
			if (tempPowerNest == null)
			{
				tempPowerNest = new PowerNest2();
			}
			bool result = tempPowerNest.CheckDetectedExe();
			DisposeNesting();
			return result;
		}
		catch (Exception)
		{
			buString5.MessageBoxError("NO Nesting Dongle");
			Environment.Exit(0);
			return false;
		}
	}

	public void DisposeNesting()
	{
		try
		{
			if (tempPowerNest != null)
			{
				tempPowerNest.Dispose();
			}
		}
		catch (Exception)
		{
		}
	}

	public bool AddPart(List<buNestingPart> Parts)
	{
		try
		{
			ilist_2.Clear();
			ilist_2 = new List<PowerNest2Cs.Part>();
			ilist_3.Clear();
			ilist_3 = new List<buNestingPart>();
			ErrorList.Clear();
			for (int i = 0; i <= Parts.Count - 1; i++)
			{
				Shape shape = null;
				bool flag = false;
				string text = "";
				if (!(Parts[i].Enable & (Parts[i].Remain > 0)))
				{
					continue;
				}
				IList<PowerNest2Cs.Orientation> list = new List<PowerNest2Cs.Orientation>();
				if (Parts[i].PartData.Rotation != nestPartRotateType.FreeRotate)
				{
					if (Parts[i].PartData.Rotation != nestPartRotateType.Increment180)
					{
						if (Parts[i].PartData.Rotation != nestPartRotateType.Fixed0)
						{
							if (Parts[i].PartData.Mirror)
							{
								list.Add(PowerNest2.anpn2key_11(0.0));
								list.Add(PowerNest2.anpn2key_11(90.0));
								list.Add(PowerNest2.anpn2key_11(180.0));
								list.Add(PowerNest2.anpn2key_11(270.0));
							}
							else
							{
								list.Add(PowerNest2.anpn2key_309(0.0));
								list.Add(PowerNest2.anpn2key_309(90.0));
								list.Add(PowerNest2.anpn2key_309(180.0));
								list.Add(PowerNest2.anpn2key_309(270.0));
							}
							if (Parts[i].PartData.AdditionalRotation > 0.0)
							{
								double num = Parts[i].PartData.AdditionalRotation / 2.0;
								if (Parts[i].PartData.Mirror)
								{
									list.Add(PowerNest2.anpn2key_12(0.0 + num, num));
									list.Add(PowerNest2.anpn2key_12(90.0 - num, num));
									list.Add(PowerNest2.anpn2key_12(90.0 + num, num));
									list.Add(PowerNest2.anpn2key_12(180.0 - num, num));
									list.Add(PowerNest2.anpn2key_12(180.0 + num, num));
									list.Add(PowerNest2.anpn2key_12(270.0 - num, num));
									list.Add(PowerNest2.anpn2key_12(270.0 + num, num));
								}
								else
								{
									list.Add(PowerNest2.anpn2key_10(0.0 + num, num));
									list.Add(PowerNest2.anpn2key_10(90.0 - num, num));
									list.Add(PowerNest2.anpn2key_10(90.0 + num, num));
									list.Add(PowerNest2.anpn2key_10(180.0 - num, num));
									list.Add(PowerNest2.anpn2key_10(180.0 + num, num));
									list.Add(PowerNest2.anpn2key_10(270.0 - num, num));
									list.Add(PowerNest2.anpn2key_10(270.0 + num, num));
								}
							}
						}
						else
						{
							list.Add(PowerNest2.anpn2key_309(0.0));
						}
					}
					else
					{
						if (Parts[i].PartData.Mirror)
						{
							list.Add(PowerNest2.anpn2key_11(0.0));
							list.Add(PowerNest2.anpn2key_11(180.0));
						}
						else
						{
							list.Add(PowerNest2.anpn2key_309(0.0));
							list.Add(PowerNest2.anpn2key_309(180.0));
						}
						if (Parts[i].PartData.AdditionalRotation > 0.0)
						{
							double num2 = Parts[i].PartData.AdditionalRotation / 2.0;
							if (Parts[i].PartData.Mirror)
							{
								list.Add(PowerNest2.anpn2key_12(0.0 + num2, num2));
								list.Add(PowerNest2.anpn2key_12(180.0 - num2, num2));
								list.Add(PowerNest2.anpn2key_12(180.0 + num2, num2));
							}
							else
							{
								list.Add(PowerNest2.anpn2key_10(0.0 + num2, num2));
								list.Add(PowerNest2.anpn2key_10(180.0 - num2, num2));
								list.Add(PowerNest2.anpn2key_10(180.0 + num2, num2));
							}
						}
					}
				}
				else
				{
					list.Add(tempPowerNest.CreateFreeOrientation(Parts[i].PartData.Mirror));
				}
				if (Parts[i].Type != nestMaterialType.Rectangle)
				{
					List<PowerNest2Cs.Point> list2 = new List<PowerNest2Cs.Point>();
					new List<double>();
					if (Parts[i].EntitiesGroup.Outside.Points == null)
					{
						Parts[i].EntitiesGroup.Outside.Points = new List<Point3D>();
						clsInit.cVector5.EntitiesToPointsWithCamDirection(Parts[i].EntitiesGroup.Outside.Entities, ref Parts[i].EntitiesGroup.Outside.Points);
					}
					if (Parts[i].EntitiesGroup.Outside.Entities != null && Parts[i].EntitiesGroup.Outside.Entities.Count > 0)
					{
						text = Parts[i].EntitiesGroup.Outside.Entities[0].LayerName;
					}
					clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Parts[i].EntitiesGroup.Outside.Points);
					if (clsInit.cVector5.IsClosed(Parts[i].EntitiesGroup.Outside.Points))
					{
					}
					for (int j = 0; j <= Parts[i].EntitiesGroup.Outside.Points.Count - 1; j++)
					{
						list2.Add(new PowerNest2Cs.Point(Parts[i].EntitiesGroup.Outside.Points[j].X, Parts[i].EntitiesGroup.Outside.Points[j].Y));
					}
					Contour contour = tempPowerNest.CreateContourFromPoints(list2);
					ErrorCode errorCode = tempPowerNest.GetErrorCode(contour);
					bool flag2 = false;
					if (errorCode != ErrorCode.OK)
					{
						ErrorList.Add(i + ". Part Contour Hole Add Part : " + Parts[i].PartData.Name + " -  " + errorCode);
						flag2 = true;
					}
					else
					{
						shape = tempPowerNest.AddShapeFromContour(contour, default(PowerNest2Cs.Point));
					}
					if (!flag2)
					{
						if (Parts[i].UseInnersAsHolePartInPart && Parts[i].EntitiesGroup.Inside != null)
						{
							for (int k = 0; k <= Parts[i].EntitiesGroup.Inside.Count - 1; k++)
							{
								if (Parts[i].EntitiesGroup.Inside[k].Entities == null || Parts[i].EntitiesGroup.Inside[k].Entities.Count <= 0 || !(Parts[i].EntitiesGroup.Inside[k].Entities[0].LayerName == text))
								{
									continue;
								}
								if (Parts[i].EntitiesGroup.Inside[k].Points != null)
								{
									if (Parts[i].EntitiesGroup.Inside[k].Points.Count >= 4 && clsInit.cVector5.IsClosed(Parts[i].EntitiesGroup.Inside[k].Points))
									{
										list2 = new List<PowerNest2Cs.Point>();
										for (int l = 0; l <= Parts[i].EntitiesGroup.Inside[k].Points.Count - 1; l++)
										{
											list2.Add(new PowerNest2Cs.Point(Parts[i].EntitiesGroup.Inside[k].Points[l].X, Parts[i].EntitiesGroup.Inside[k].Points[l].Y));
										}
										Contour contour2 = tempPowerNest.CreateContourFromPoints(list2);
										ErrorCode errorCode2 = tempPowerNest.GetErrorCode(contour2);
										if (errorCode2 != ErrorCode.OK)
										{
											ErrorList.Add(i + ". Part Error Hole Add Part : " + Parts[i].PartData.Name + " -  " + errorCode2);
										}
										else
										{
											tempPowerNest.ShapeAddHoleFromContour(shape, contour2);
										}
									}
								}
								else
								{
									buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NoInternalEntitiesPoints);
								}
							}
						}
						flag = true;
					}
				}
				else
				{
					IList<PowerNest2Cs.Point> list3 = new List<PowerNest2Cs.Point>();
					for (int m = 0; m <= Parts[i].EntitiesGroup.Outside.Points.Count - 1; m++)
					{
						list3.Add(new PowerNest2Cs.Point(Parts[i].EntitiesGroup.Outside.Points[m].X, Parts[i].EntitiesGroup.Outside.Points[m].Y));
					}
					if (list3.Count >= 4)
					{
						shape = tempPowerNest.AddShape(list3);
						flag = true;
					}
				}
				if (!flag)
				{
					continue;
				}
				int num3 = 0;
				if (!(Parts[i].PartDistance > 0.0))
				{
					tempPowerNest.ShapeSetProtectionOffset(shape, clsNesting.ParNest.PartSettings.PartsSpace);
				}
				else
				{
					tempPowerNest.ShapeSetProtectionOffset(shape, Parts[i].PartDistance);
				}
				IEnumerable<PowerNest2Cs.Part> partList = new List<PowerNest2Cs.Part>();
				tempPowerNest.AddSeveralParts(shape, list, Parts[i].Remain * clsNesting.ParNest.PartSettings.Multiply, out partList);
				for (int n = 0; n < partList.Count(); n++)
				{
					PowerNest2Cs.Part part = partList.ElementAt(n);
					ErrorCode errorCode3 = tempPowerNest.GetErrorCode(part);
					if (errorCode3 != ErrorCode.OK)
					{
						ErrorList.Add(i + ". Part Error Add Part : " + Parts[i].PartData.Name + " -  " + errorCode3);
						num3++;
					}
					else
					{
						ilist_2.Add(part);
					}
				}
				if (num3 == 0)
				{
					for (int num4 = 0; num4 <= Parts[i].Remain * clsNesting.ParNest.PartSettings.Multiply - 1; num4++)
					{
						buNestingPart item = new buNestingPart(Parts[i]);
						ilist_3.Add(item);
					}
				}
			}
			if (ErrorList.Count <= 0)
			{
				return true;
			}
			DialogBoxList dialogBoxList = new DialogBoxList();
			dialogBoxList.Caption = buLangTranslate.preDef.Error;
			dialogBoxList.Width = 500;
			for (int num5 = 0; num5 <= ErrorList.Count - 1; num5++)
			{
				dialogBoxList.Items.Add(ErrorList[num5]);
			}
			dialogBoxList.StartPosition = FormStartPosition.CenterScreen;
			dialogBoxList.Init();
			dialogBoxList.ShowDialog();
			if (dialogBoxList.Result != DialogResult.OK)
			{
				return false;
			}
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public void AddSheet(List<buNestingSheet> Sheets)
	{
		ilist_0.Clear();
		ilist_0 = new List<Sheet>();
		ilist_4.Clear();
		ilist_1.Clear();
		ilist_1 = new List<buNestingSheet>();
		for (int i = 0; i <= Sheets.Count - 1; i++)
		{
			if (!(Sheets[i].Enable & (Sheets[i].Remain > 0)))
			{
				continue;
			}
			Sheet sheet = null;
			if (Sheets[i].Type != nestMaterialType.Rectangle)
			{
				List<PowerNest2Cs.Point> list = new List<PowerNest2Cs.Point>();
				for (int j = 0; j <= Sheets[i].EntitiesGroup.Outside.Points.Count - 1; j++)
				{
					list.Add(new PowerNest2Cs.Point(Sheets[i].EntitiesGroup.Outside.Points[j].X, Sheets[i].EntitiesGroup.Outside.Points[j].Y));
				}
				Contour contour = tempPowerNest.CreateContourFromPoints(list);
				sheet = tempPowerNest.AddSheetFromContourWithBorderGap(contour, clsNesting.ParNest.MaterailSettings.IrregularMargin);
			}
			else
			{
				sheet = tempPowerNest.AddSheet(Sheets[i].MaterialData.Height, Sheets[i].MaterialData.Width);
				tempPowerNest.SheetAddBorderGaps(sheet, clsNesting.ParNest.MaterailSettings.RectangleMarginLeft, clsNesting.ParNest.MaterailSettings.RectangleMarginRight, clsNesting.ParNest.MaterailSettings.RectangleMarginBottom, clsNesting.ParNest.MaterailSettings.RectangleMarginTop);
			}
			if (Sheets[i].EntitiesGroup.Inside != null)
			{
				for (int k = 0; k <= Sheets[i].EntitiesGroup.Inside.Count - 1; k++)
				{
					if (clsInit.cVector5.IsClosed(Sheets[i].EntitiesGroup.Inside[k].Points))
					{
						List<PowerNest2Cs.Point> list2 = new List<PowerNest2Cs.Point>();
						for (int l = 0; l <= Sheets[i].EntitiesGroup.Inside[k].Points.Count - 1; l++)
						{
							list2.Add(new PowerNest2Cs.Point(Sheets[i].EntitiesGroup.Inside[k].Points[l].X, Sheets[i].EntitiesGroup.Inside[k].Points[l].Y));
						}
						Contour contour2 = tempPowerNest.CreateContourFromPoints(list2);
						tempPowerNest.SheetAddDefectFromContour(sheet, contour2);
					}
				}
			}
			ErrorCode errorCode = tempPowerNest.GetErrorCode(sheet);
			if (errorCode != ErrorCode.OK)
			{
				ErrorList.Add("Error Add Sheet : " + Sheets[i].MaterialData.Name + " - " + errorCode);
			}
			else
			{
				ilist_0.Add(sheet);
				ilist_4.Add(Sheets[i].Remain);
			}
			buNestingSheet item = new buNestingSheet(Sheets[i]);
			ilist_1.Add(item);
		}
	}

	public void DrawToMultiSvg(PowerNest2 PowerNest, MultiResult Result, string FileName)
	{
		PowerNest.DrawMultiSvg(Result, FileName);
	}

	public void MultiResultToNestedResult(MultiResult nestMultiResult, ref buNestedResult Result)
	{
		if (tempPowerNest.GetErrorCode(nestMultiResult) == ErrorCode.OK)
		{
			Result = new buNestedResult();
			int nbSheets = 0;
			ErrorCode multiResultInfos = tempPowerNest.GetMultiResultInfos(nestMultiResult, out nbSheets);
			if (multiResultInfos != ErrorCode.OK)
			{
				ErrorList.Add("GetMultiResultInfos  - " + multiResultInfos);
			}
			else
			{
				Result.NestedSheetCount = nbSheets;
				int count = ilist_3.Count;
				int num = 0;
				for (int i = 0; i < nbSheets; i++)
				{
					int num2 = -1;
					Result result = null;
					Sheet sheet_result;
					if (!clsNesting.ParNest.Settings.UseCompactMethod)
					{
						result = tempPowerNest.GetResult(nestMultiResult, i, out sheet_result);
					}
					else
					{
						Result result2 = tempPowerNest.GetResult(nestMultiResult, i, out sheet_result);
						tempPowerNest.SetSessionOffcutSides(Side.Top, Side.Right);
						result = tempPowerNest.Compact(result2, DirectionType.BottomLeft, clsNesting.ParNest.Settings.CompactTime);
					}
					ErrorCode errorCode = tempPowerNest.GetErrorCode(result);
					if (errorCode != ErrorCode.OK)
					{
						ErrorList.Add("Error Sheet Result  - " + errorCode);
						continue;
					}
					for (int j = 0; j <= ilist_0.Count - 1; j++)
					{
						if (sheet_result == ilist_0[j])
						{
							num2 = j;
						}
					}
					if (num2 < 0)
					{
						continue;
					}
					buNestedSheet sheetNested = new buNestedSheet(ilist_1[num2]);
					for (int k = 0; k < ilist_2.Count; k++)
					{
						if (!tempPowerNest.GetNestedPart(result, ilist_2.ElementAt(k), out var position, out var orientation))
						{
							continue;
						}
						buNestingPart buNestingPart2 = ilist_3[k];
						buNestedPart buNestedPart2 = buNestedPart.FromNestingPart(ilist_3[k]);
						clsInit.cVector5.EntitiesLength(buNestingPart2.EntitiesGroup.Outside.Entities, ref buNestedPart2.TotalOutSideLength);
						GetApproxLEngthBLayerName(ref sheetNested, buNestingPart2.EntitiesGroup.Outside.Entities);
						sheetNested.TotalUpMove++;
						sheetNested.TotalDownMove++;
						if (buNestingPart2.EntitiesGroup.Inside != null)
						{
							for (int l = 0; l <= buNestingPart2.EntitiesGroup.Inside.Count - 1; l++)
							{
								double Length = 0.0;
								clsInit.cVector5.EntitiesLength(buNestingPart2.EntitiesGroup.Inside[l].Entities, ref Length);
								buNestedPart2.TotalInsideLength += Length;
								sheetNested.TotalUpMove++;
								sheetNested.TotalDownMove++;
								GetApproxLEngthBLayerName(ref sheetNested, buNestingPart2.EntitiesGroup.Inside[l].Entities);
							}
						}
						if (buNestingPart2.EntitiesGroup.OpenEntities != null)
						{
							for (int m = 0; m <= buNestingPart2.EntitiesGroup.OpenEntities.Count - 1; m++)
							{
								double Length2 = 0.0;
								clsInit.cVector5.EntitiesLength(buNestingPart2.EntitiesGroup.OpenEntities[m].Entities, ref Length2);
								buNestedPart2.TotalInsideLength += Length2;
								sheetNested.TotalUpMove++;
								sheetNested.TotalDownMove++;
								GetApproxLEngthBLayerName(ref sheetNested, buNestingPart2.EntitiesGroup.OpenEntities[m].Entities);
							}
						}
						if (buNestingPart2.EntitiesGroup.Text != null)
						{
							for (int n = 0; n <= buNestingPart2.EntitiesGroup.Text.Entities.Count - 1; n++)
							{
								sheetNested.TotalTextCount++;
							}
						}
						clsInit.cNesting.PartArea(buNestedPart2, clsNesting.ParNest.ProgramSettings.UnitArea, clsNesting.ParNest.ResultSettings.PartAreaOnlyFromOutter, ref buNestedPart2.PartArea);
						sheetNested.NestedArea += buNestedPart2.PartArea;
						buNestedPart2.TotalLength = buNestedPart2.TotalInsideLength + buNestedPart2.TotalOutSideLength;
						buNestedPart2.MovedDistance = new Vec3D(position.x, position.y);
						buNestedPart2.RotateValue = orientation.MinAngle;
						if (orientation.HorizontalFlip == 1)
						{
							clsInit.cVector5.Mirror(new Point3D(), new Point3D(1.0, 0.0, 0.0), Plane.XY, ref buNestedPart2.EntitiesGroup);
							buNestedPart2.RotateValue = 0.0 - orientation.MinAngle;
						}
						clsInit.cVector5.Rotate(new Point3D(), buNestedPart2.RotateValue, Vector3D.AxisZ, ref buNestedPart2.EntitiesGroup);
						clsInit.cVector5.Move(buNestedPart2.MovedDistance.X, buNestedPart2.MovedDistance.Y, 0.0, ref buNestedPart2.EntitiesGroup);
						if (orientation.HorizontalFlip == 1)
						{
							buNestedPart2.isMirror = true;
						}
						int index = buNestingPart2.ID % clsVar.ColorList.Count;
						buNestedPart2.Color = clsVar.ColorList[index];
						buNestedPart2.Thickness = ilist_1[num2].MaterialData.Thickness + 1.0;
						sheetNested.Parts.Add(buNestedPart2);
						sheetNested.TotalLength += buNestedPart2.TotalLength;
						sheetNested.TotalInsideLength = Math.Round(sheetNested.TotalInsideLength + buNestedPart2.TotalInsideLength, 5);
						sheetNested.TotalOutsideLength = Math.Round(sheetNested.TotalOutsideLength + buNestedPart2.TotalOutSideLength, 5);
						if (clsNesting.ParNest.ProgramSettings.UseNoneCutting && ((k > 0) & (sheetNested.Parts.Count > 0)))
						{
							Point3D a = sheetNested.Parts[sheetNested.Parts.Count - 1].EntitiesGroup.Outside.Entities[0].Vertices[0];
							Point3D b = buNestedPart2.EntitiesGroup.Outside.Entities[0].Vertices[0];
							sheetNested.TotalNoneCuttingLength += Point3D.Distance(a, b);
						}
						num++;
					}
					if (clsNesting.ParNest.ProgramSettings.CuttingSpeed > 0.0)
					{
						sheetNested.ApproxExecutionTimeSec = sheetNested.TotalLength / clsNesting.ParNest.ProgramSettings.CuttingSpeed + (double)sheetNested.TotalUpMove * clsNesting.ParNest.ProgramSettings.PenUpTime + (double)sheetNested.TotalDownMove * clsNesting.ParNest.ProgramSettings.PenDownTime + (double)sheetNested.TotalTextCount * clsNesting.ParNest.ProgramSettings.TextTime;
					}
					if ((clsNesting.ParNest.ProgramSettings.NoneCuttingSpeed > 0.0) & clsNesting.ParNest.ProgramSettings.UseNoneCutting & (sheetNested.TotalNoneCuttingLength > 0.0))
					{
						sheetNested.ApproxExecutionTimeSec += sheetNested.TotalNoneCuttingLength / clsNesting.ParNest.ProgramSettings.NoneCuttingSpeed;
					}
					if ((sheetNested.ApproxExecution0Len > 0.0) & (clsNesting.ParNest.ProgramSettings.Layer0Speed > 0.0))
					{
						sheetNested.ApproxExecution0TimeSec = sheetNested.ApproxExecution0Len / clsNesting.ParNest.ProgramSettings.Layer0Speed + (double)sheetNested.ApproxExecution0UpDownCnt * clsNesting.ParNest.ProgramSettings.PenUpTime;
					}
					if ((sheetNested.ApproxExecution1Len > 0.0) & (clsNesting.ParNest.ProgramSettings.Layer1Speed > 0.0))
					{
						sheetNested.ApproxExecution1TimeSec = sheetNested.ApproxExecution1Len / clsNesting.ParNest.ProgramSettings.Layer1Speed + (double)sheetNested.ApproxExecution1UpDownCnt * clsNesting.ParNest.ProgramSettings.PenUpTime;
					}
					if ((sheetNested.ApproxExecution2Len > 0.0) & (clsNesting.ParNest.ProgramSettings.Layer2Speed > 0.0))
					{
						sheetNested.ApproxExecution2TimeSec = sheetNested.ApproxExecution2Len / clsNesting.ParNest.ProgramSettings.Layer2Speed + (double)sheetNested.ApproxExecution2UpDownCnt * clsNesting.ParNest.ProgramSettings.PenUpTime;
					}
					if ((sheetNested.ApproxExecution3Len > 0.0) & (clsNesting.ParNest.ProgramSettings.Layer3Speed > 0.0))
					{
						sheetNested.ApproxExecution3TimeSec = sheetNested.ApproxExecution3Len / clsNesting.ParNest.ProgramSettings.Layer3Speed + (double)sheetNested.ApproxExecution3UpDownCnt * clsNesting.ParNest.ProgramSettings.PenUpTime;
					}
					if ((sheetNested.ApproxExecution4Len > 0.0) & (clsNesting.ParNest.ProgramSettings.Layer4Speed > 0.0))
					{
						sheetNested.ApproxExecution4TimeSec = sheetNested.ApproxExecution4Len / clsNesting.ParNest.ProgramSettings.Layer4Speed + (double)sheetNested.ApproxExecution4UpDownCnt * clsNesting.ParNest.ProgramSettings.PenUpTime;
					}
					if ((sheetNested.ApproxExecution5Len > 0.0) & (clsNesting.ParNest.ProgramSettings.Layer5Speed > 0.0))
					{
						sheetNested.ApproxExecution5TimeSec = sheetNested.ApproxExecution5Len / clsNesting.ParNest.ProgramSettings.Layer5Speed + (double)sheetNested.ApproxExecution5UpDownCnt * clsNesting.ParNest.ProgramSettings.PenUpTime;
					}
					if ((sheetNested.ApproxExecution6Len > 0.0) & (clsNesting.ParNest.ProgramSettings.Layer6Speed > 0.0))
					{
						sheetNested.ApproxExecution6TimeSec = sheetNested.ApproxExecution6Len / clsNesting.ParNest.ProgramSettings.Layer6Speed + (double)sheetNested.ApproxExecution6UpDownCnt * clsNesting.ParNest.ProgramSettings.PenUpTime;
					}
					if ((sheetNested.ApproxExecution7Len > 0.0) & (clsNesting.ParNest.ProgramSettings.Layer7Speed > 0.0))
					{
						sheetNested.ApproxExecution7TimeSec = sheetNested.ApproxExecution7Len / clsNesting.ParNest.ProgramSettings.Layer7Speed + (double)sheetNested.ApproxExecution7UpDownCnt * clsNesting.ParNest.ProgramSettings.PenUpTime;
					}
					if ((sheetNested.ApproxExecution8Len > 0.0) & (clsNesting.ParNest.ProgramSettings.Layer8Speed > 0.0))
					{
						sheetNested.ApproxExecution8TimeSec = sheetNested.ApproxExecution8Len / clsNesting.ParNest.ProgramSettings.Layer8Speed + (double)sheetNested.ApproxExecution8UpDownCnt * clsNesting.ParNest.ProgramSettings.PenUpTime;
					}
					if ((sheetNested.ApproxExecution9Len > 0.0) & (clsNesting.ParNest.ProgramSettings.Layer9Speed > 0.0))
					{
						sheetNested.ApproxExecution9TimeSec = sheetNested.ApproxExecution9Len / clsNesting.ParNest.ProgramSettings.Layer9Speed + (double)sheetNested.ApproxExecution9UpDownCnt * clsNesting.ParNest.ProgramSettings.PenUpTime;
					}
					if ((sheetNested.ApproxExecution0TimeSec > 0.0) | (sheetNested.ApproxExecution1TimeSec > 0.0) | (sheetNested.ApproxExecution2TimeSec > 0.0) | (sheetNested.ApproxExecution3TimeSec > 0.0) | (sheetNested.ApproxExecution4TimeSec > 0.0) | (sheetNested.ApproxExecution5TimeSec > 0.0) | (sheetNested.ApproxExecution6TimeSec > 0.0) | (sheetNested.ApproxExecution7TimeSec > 0.0) | (sheetNested.ApproxExecution8TimeSec > 0.0) | (sheetNested.ApproxExecution9TimeSec > 0.0))
					{
						sheetNested.ApproxExecutionTimeSec = sheetNested.ApproxExecution0TimeSec + sheetNested.ApproxExecution1TimeSec + sheetNested.ApproxExecution2TimeSec + sheetNested.ApproxExecution3TimeSec + sheetNested.ApproxExecution4TimeSec + sheetNested.ApproxExecution5TimeSec + sheetNested.ApproxExecution6TimeSec + sheetNested.ApproxExecution7TimeSec + sheetNested.ApproxExecution8TimeSec + sheetNested.ApproxExecution9TimeSec;
					}
					Point3D pntMin = new Point3D();
					Point3D pntMax = new Point3D();
					clsInit.cNesting.NestedPartsBoxAreaFromNestedSheet(sheetNested, ref pntMin, ref pntMax);
					sheetNested.SheetMaxXPosition = pntMax.X;
					sheetNested.SheetMaxYPosition = pntMax.Y;
					if (clsNesting.ParNest.ResultSettings.RemnantCalculate)
					{
						double num3 = sheetNested.MaterialWidth - pntMax.X - clsNesting.ParNest.ResultSettings.RemnantSizeOffset;
						double num4 = sheetNested.MaterialHeight - pntMax.Y - clsNesting.ParNest.ResultSettings.RemnantSizeOffset;
						if (!(num3 > num4))
						{
							if (num4 > clsNesting.ParNest.ResultSettings.RemnantMinLength)
							{
								Rectangle2D item = new Rectangle2D(new Point3D(0.0, Math.Round(pntMax.Y + clsNesting.ParNest.ResultSettings.RemnantSizeOffset, 5)), Math.Round(pntMax.X, 5), Math.Round(num4, 5));
								sheetNested.RemnantSheets.Add(item);
								if (num3 > clsNesting.ParNest.ResultSettings.RemnantMinLength)
								{
									item = new Rectangle2D(new Point3D(Math.Round(pntMax.X + clsNesting.ParNest.ResultSettings.RemnantSizeOffset, 5), 0.0), Math.Round(num3, 5), pntMax.Y);
									sheetNested.RemnantSheets.Add(item);
								}
							}
						}
						else if (num3 > clsNesting.ParNest.ResultSettings.RemnantMinLength)
						{
							Rectangle2D item2 = new Rectangle2D(new Point3D(Math.Round(pntMax.X + clsNesting.ParNest.ResultSettings.RemnantSizeOffset, 5), 0.0), Math.Round(num3, 5), sheetNested.MaterialHeight);
							sheetNested.RemnantSheets.Add(item2);
							if (num4 > clsNesting.ParNest.ResultSettings.RemnantMinLength)
							{
								item2 = new Rectangle2D(new Point3D(0.0, Math.Round(pntMax.Y + clsNesting.ParNest.ResultSettings.RemnantSizeOffset, 5)), Math.Round(pntMax.X, 5), Math.Round(num4, 5));
								sheetNested.RemnantSheets.Add(item2);
							}
						}
					}
					clsInit.cNesting.SheeatArea(sheetNested, clsNesting.ParNest.ProgramSettings.UnitArea, ref sheetNested.MaterialArea);
					if (sheetNested.Type == nestMaterialType.Rectangle)
					{
						sheetNested.MaterialArea = sheetNested.MaterialHeight * sheetNested.MaterialWidth;
						sheetNested.MaterialAreaFromMaxX = sheetNested.MaterialHeight * sheetNested.SheetMaxXPosition;
						double UnitRatio = 1.0;
						clsInit.cVector5.AreaUnitRatioFromMM(clsNesting.ParNest.ProgramSettings.UnitArea, ref UnitRatio);
						sheetNested.MaterialArea /= UnitRatio;
						sheetNested.MaterialAreaFromMaxX /= UnitRatio;
					}
					sheetNested.UsingPersentage = sheetNested.NestedArea / sheetNested.MaterialArea * 100.0;
					sheetNested.UsingPersentageFromMaxX = sheetNested.NestedArea / sheetNested.MaterialAreaFromMaxX * 100.0;
					Result.NestedResultSheets.Add(sheetNested);
				}
				Result.Parameters = new buNestingVar(clsNesting.ParNest);
				Result.OrderedTotalPartCount = count;
				Result.NestedTotalPartCount = num;
				Result.PartGap = clsNesting.ParNest.PartSettings.PartsSpace;
				Result.ExecutionDate = DateTime.Now;
				Result.ExecutionTime = clsNesting.ParNest.Runtime.MaxNestingTimeSec;
				if (Result.NestedResultSheets.Count == 1)
				{
					Result.MaxXPosition = Result.NestedResultSheets[0].SheetMaxXPosition;
					Result.MaxYPosition = Result.NestedResultSheets[0].SheetMaxYPosition;
				}
				if (num < count)
				{
					Result.NotNestedAll = true;
				}
			}
		}
		Result.JobExplanation = clsNesting.ParNest.Runtime.NestingJobExplanation;
		Result.JobName = clsNesting.ParNest.Runtime.NestingJobName;
	}

	public void GetApproxLEngthBLayerName(ref buNestedSheet sheetNested, List<buEntity> refEntities)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		int num9 = 0;
		int num10 = 0;
		for (int i = 0; i <= refEntities.Count - 1; i++)
		{
			if (refEntities[i].LayerName.Trim() == "0")
			{
				sheetNested.ApproxExecution0Len += refEntities[i].Length();
				num++;
			}
			if (refEntities[i].LayerName.Trim() == "1")
			{
				sheetNested.ApproxExecution1Len += refEntities[i].Length();
				num2++;
			}
			if (refEntities[i].LayerName.Trim() == "2")
			{
				sheetNested.ApproxExecution2Len += refEntities[i].Length();
				num3++;
			}
			if (refEntities[i].LayerName.Trim() == "3")
			{
				sheetNested.ApproxExecution3Len += refEntities[i].Length();
				num4++;
			}
			if (refEntities[i].LayerName.Trim() == "4")
			{
				sheetNested.ApproxExecution4Len += refEntities[i].Length();
				num5++;
			}
			if (refEntities[i].LayerName.Trim() == "5")
			{
				sheetNested.ApproxExecution5Len += refEntities[i].Length();
				num6++;
			}
			if (refEntities[i].LayerName.Trim() == "6")
			{
				sheetNested.ApproxExecution6Len += refEntities[i].Length();
				num7++;
			}
			if (refEntities[i].LayerName.Trim() == "7")
			{
				sheetNested.ApproxExecution7Len += refEntities[i].Length();
				num8++;
			}
			if (refEntities[i].LayerName.Trim() == "8")
			{
				sheetNested.ApproxExecution8Len += refEntities[i].Length();
				num9++;
			}
			if (refEntities[i].LayerName.Trim() == "9")
			{
				sheetNested.ApproxExecution9Len += refEntities[i].Length();
				num10++;
			}
		}
		if (num > 0)
		{
			sheetNested.ApproxExecution0UpDownCnt++;
			sheetNested.ApproxExecution0UpDownCnt++;
		}
		if (num2 > 0)
		{
			sheetNested.ApproxExecution1UpDownCnt++;
			sheetNested.ApproxExecution1UpDownCnt++;
		}
		if (num3 > 0)
		{
			sheetNested.ApproxExecution2UpDownCnt++;
			sheetNested.ApproxExecution2UpDownCnt++;
		}
		if (num4 > 0)
		{
			sheetNested.ApproxExecution3UpDownCnt++;
			sheetNested.ApproxExecution3UpDownCnt++;
		}
		if (num5 > 0)
		{
			sheetNested.ApproxExecution4UpDownCnt++;
			sheetNested.ApproxExecution4UpDownCnt++;
		}
		if (num6 > 0)
		{
			sheetNested.ApproxExecution5UpDownCnt++;
			sheetNested.ApproxExecution5UpDownCnt++;
		}
		if (num7 > 0)
		{
			sheetNested.ApproxExecution6UpDownCnt++;
			sheetNested.ApproxExecution6UpDownCnt++;
		}
		if (num8 > 0)
		{
			sheetNested.ApproxExecution7UpDownCnt++;
			sheetNested.ApproxExecution7UpDownCnt++;
		}
		if (num9 > 0)
		{
			sheetNested.ApproxExecution8UpDownCnt++;
			sheetNested.ApproxExecution8UpDownCnt++;
		}
		if (num10 > 0)
		{
			sheetNested.ApproxExecution9UpDownCnt++;
			sheetNested.ApproxExecution9UpDownCnt++;
		}
	}

	public bool Execute(double Time)
	{
		if (ilist_2.Count != 0)
		{
			if (ilist_0.Count != 0)
			{
				if (clsNesting.ParNest.Settings.NestingThreadCalculationCount <= 0)
				{
					clsNesting.ParNest.Settings.NestingThreadCalculationCount = 2;
				}
				if (clsNesting.ParNest.Settings.NestingThreadCalculationCount > 4)
				{
					clsNesting.ParNest.Settings.NestingThreadCalculationCount = 4;
				}
				ExecutionCounter = 0;
				bStop = false;
				iuserData_0 = new MyUserData();
				iuserData_1 = new MyUserData();
				tempPowerNest.SetSessionOffcutSides(Side.Right, Side.Top);
				if (clsNesting.ParNest.Settings.UseCallBacks)
				{
					tempPowerNest.SetSessionMultiCallbacks((StopNesting)Class5.smethod_113, iuserData_0, (MultiUpdateBest)Class5.smethod_84, iuserData_1);
				}
				tempPowerNest.SetSessionNbThreads(clsNesting.ParNest.Settings.NestingThreadCalculationCount);
				bExecuteDone = false;
				clsNesting.BestNestCount = 1;
				tempBetterNestedResult.Clear();
				storedNestedResult.Clear();
				double_0 = Time;
				dateTime_0 = DateTime.Now;
				if (!clsNesting.ParNest.Settings.NestExecutionByThread)
				{
					multiResult_0 = tempPowerNest.MultiNest(ilist_0, ilist_4, ilist_2, Time);
					bStop = false;
					ExecuteEnd(multiResult_0);
				}
				else
				{
					timer_0.Interval = 100;
					timer_0.Tick += Tick_Execute;
					timer_0.Start();
					threadExecute = new Thread(clsInit.appNestingPower.ThreadCalculationLoop);
					threadExecute.Start();
					bExecute = true;
				}
				return true;
			}
			buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NoMaterialWillBeUsedForNesting);
			return false;
		}
		buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NoPartWillWeNested);
		return false;
	}

	public void ExecuteEnd(MultiResult nestMultiResult)
	{
		if (threadExecute != null)
		{
			threadExecute.Abort();
		}
		DrawToMultiSvg(tempPowerNest, nestMultiResult, Path.Combine(AppPath.Base, "buNesting.svg"));
		storedNestedResult.Add(nestMultiResult);
		MultiResultToNestedResult(nestMultiResult, ref clsInit.appNesting.NestedResult);
		clsInit.appNesting.doAddToTempCalculatedNesting(clsInit.appNesting.NestedResult, isLast: true);
		clsItem.FrmNestOnlineCalc.btn_send.Enabled = true;
		clsItem.FrmNestOnlineCalc.btn_preview.Enabled = true;
		if (clsVar.appModes_0.CutterMode.Enable)
		{
			clsInit.appCutter.AddCutterThingsToNestingResult(ref clsInit.appNesting.NestedResult);
		}
	}

	public void AddBetterResult()
	{
		for (int i = 0; i <= storedNestedResult.Count - 1; i++)
		{
			int nbSheets = 0;
			MultiResult multiResult = storedNestedResult[i].DeepClone();
			if (tempPowerNest.GetMultiResultInfos(multiResult, out nbSheets) == ErrorCode.OK)
			{
				clsInit.appNesting.NestedResult.NestedSheetCount = nbSheets;
				int num = 0;
				int num2 = 0;
				num = ilist_3.Count;
				for (int j = 0; j < nbSheets; j++)
				{
					int num3 = -1;
					Sheet sheet_result;
					Result result = tempPowerNest.GetResult(multiResult, j, out sheet_result);
					ErrorCode errorCode = tempPowerNest.GetErrorCode(result);
					if (errorCode != ErrorCode.OK)
					{
						ErrorList.Add("Error Sheet Result  - " + errorCode);
						continue;
					}
					for (int k = 0; k <= ilist_0.Count - 1; k++)
					{
						if (sheet_result == ilist_0[k])
						{
							num3 = k;
						}
					}
					if (num3 < 0)
					{
						continue;
					}
					buNestedSheet buNestedSheet2 = new buNestedSheet(ilist_1[num3]);
					for (int l = 0; l < ilist_2.Count; l++)
					{
						if (tempPowerNest.GetNestedPart(result, ilist_2.ElementAt(l), out var position, out var orientation))
						{
							buNestingPart buNestingPart2 = new buNestingPart(ilist_3[l]);
							buNestedPart buNestedPart2 = new buNestedPart();
							try
							{
								buNestedPart2.EntitiesGroup = new buEntitiesGroup(ilist_3[l].EntitiesGroup);
							}
							catch (Exception)
							{
							}
							buNestedPart2.MovedDistance = new Vec3D(position.x, position.y);
							buNestedPart2.RotateValue = orientation.MinAngle;
							if (orientation.HorizontalFlip == 1)
							{
								clsInit.cVector5.Mirror(new Point3D(), new Point3D(1.0, 0.0, 0.0), Plane.XY, ref buNestedPart2.EntitiesGroup);
								buNestedPart2.RotateValue = 0.0 - orientation.MinAngle;
							}
							clsInit.cVector5.Rotate(new Point3D(), buNestedPart2.RotateValue, Vector3D.AxisZ, ref buNestedPart2.EntitiesGroup);
							clsInit.cVector5.Move(buNestedPart2.MovedDistance.X, buNestedPart2.MovedDistance.Y, 0.0, ref buNestedPart2.EntitiesGroup);
							int index = buNestingPart2.ID % clsVar.ColorList.Count;
							buNestedPart2.Color = clsVar.ColorList[index];
							buNestedPart2.Thickness = ilist_1[num3].MaterialData.Thickness + 1.0;
							clsInit.cNesting.PartArea(buNestedPart2, clsNesting.ParNest.ProgramSettings.UnitArea, clsNesting.ParNest.ResultSettings.PartAreaOnlyFromOutter, ref buNestedPart2.PartArea);
							buNestedSheet2.NestedArea += buNestedPart2.PartArea;
							buNestedSheet2.Parts.Add(buNestedPart2);
							num2++;
						}
					}
					Point3D pntMin = new Point3D();
					Point3D pntMax = new Point3D();
					clsInit.cNesting.NestedPartsBoxAreaFromNestedSheet(buNestedSheet2, ref pntMin, ref pntMax);
					buNestedSheet2.SheetMaxXPosition = pntMax.X;
					buNestedSheet2.SheetMaxYPosition = pntMax.Y;
					clsInit.cNesting.SheeatArea(buNestedSheet2, clsNesting.ParNest.ProgramSettings.UnitArea, ref buNestedSheet2.MaterialArea);
					if (buNestedSheet2.Type == nestMaterialType.Rectangle && j == nbSheets - 1)
					{
						buNestedSheet2.MaterialArea = buNestedSheet2.MaterialHeight * buNestedSheet2.MaterialWidth;
						buNestedSheet2.MaterialAreaFromMaxX = buNestedSheet2.MaterialHeight * buNestedSheet2.SheetMaxXPosition;
						double UnitRatio = 1.0;
						clsInit.cVector5.AreaUnitRatioFromMM(clsNesting.ParNest.ProgramSettings.UnitArea, ref UnitRatio);
						buNestedSheet2.MaterialArea /= UnitRatio;
						buNestedSheet2.MaterialAreaFromMaxX /= UnitRatio;
					}
					buNestedSheet2.UsingPersentage = buNestedSheet2.NestedArea / buNestedSheet2.MaterialArea * 100.0;
					buNestedSheet2.UsingPersentageFromMaxX = buNestedSheet2.NestedArea / buNestedSheet2.MaterialAreaFromMaxX * 100.0;
					clsInit.appNesting.NestedResult.NestedResultSheets.Add(buNestedSheet2);
				}
				clsInit.appNesting.NestedResult.OrderedTotalPartCount = num;
				clsInit.appNesting.NestedResult.NestedTotalPartCount = num2;
				clsInit.appNesting.NestedResult.PartGap = clsNesting.ParNest.PartSettings.PartsSpace;
				clsInit.appNesting.NestedResult.ExecutionDate = DateTime.Now;
				clsInit.appNesting.NestedResult.ExecutionTime = clsNesting.ParNest.Runtime.MaxNestingTimeSec;
				if (clsInit.appNesting.NestedResult.NestedResultSheets.Count == 1)
				{
					clsInit.appNesting.NestedResult.MaxXPosition = clsInit.appNesting.NestedResult.NestedResultSheets[0].SheetMaxXPosition;
					clsInit.appNesting.NestedResult.MaxYPosition = clsInit.appNesting.NestedResult.NestedResultSheets[0].SheetMaxYPosition;
				}
				if (clsVar.appModes_0.CutterMode.Enable)
				{
					clsInit.appCutter.AddCutterThingsToNestingResult(ref clsInit.appNesting.NestedResult);
				}
				if (num2 < num)
				{
					clsInit.appNesting.NestedResult.NotNestedAll = true;
				}
			}
			clsInit.appNesting.NestedResult.JobExplanation = clsNesting.ParNest.Runtime.NestingJobExplanation;
			clsInit.appNesting.NestedResult.JobName = clsNesting.ParNest.Runtime.NestingJobName;
			tempBetterNestedResult.Add(clsInit.appNesting.NestedResult);
		}
	}

	public void Tick_Execute(object sender, EventArgs e)
	{
		TimeSpan timeSpan = DateTime.Now - dateTime_0;
		GC.KeepAlive(tempPowerNest);
		if (clsItem.FrmNestOnlineCalc != null && clsItem.FrmNestOnlineCalc.Visible)
		{
			if (bExecuteDone)
			{
				clsItem.FrmNestOnlineCalc.lbl_status.Text = "Done";
				clsItem.FrmNestOnlineCalc.lbl_status.BackColor = Color.LightCoral;
			}
			else
			{
				clsItem.FrmNestOnlineCalc.lbl_status.Text = "Running";
				clsItem.FrmNestOnlineCalc.lbl_status.BackColor = Color.Lime;
			}
			if (tempBetterNestedResult.Count > 0)
			{
				tempBetterNestedResult.RemoveAt(0);
			}
			clsItem.FrmNestOnlineCalc.txt_bestcount.Text = int_0.ToString();
			clsItem.FrmNestOnlineCalc.txt_time.Text = Convert.ToInt32(timeSpan.TotalSeconds) + " / " + clsNesting.ParNest.Runtime.MaxNestingTimeSec.ToString("f0");
			double totalSeconds = timeSpan.TotalSeconds;
			double num = 0.0;
			if (!(totalSeconds < 0.0))
			{
				if (!((totalSeconds >= 0.0) & (totalSeconds <= (double)clsNesting.ParNest.Runtime.MaxNestingTimeSec)))
				{
					num = 100.0;
					clsItem.FrmNestOnlineCalc.progress_execution.Value = 100;
				}
				else
				{
					num = totalSeconds / (double)clsNesting.ParNest.Runtime.MaxNestingTimeSec * 100.0;
					clsItem.FrmNestOnlineCalc.progress_execution.Value = (int)num;
				}
			}
			else
			{
				clsItem.FrmNestOnlineCalc.progress_execution.Value = 0;
			}
			clsItem.FrmNestOnlineCalc.lbl_persentage.Text = "%" + num.ToString("f1");
		}
		if (bExecuteDone)
		{
			clsItem.FrmNestOnlineCalc.progress_execution.Value = 100;
			clsItem.FrmNestOnlineCalc.lbl_persentage.Text = "%100.0";
			ExecuteEnd(multiResult_0.DeepClone());
			bExecuteDone = false;
			timer_0.Tick -= Tick_Execute;
			timer_0.Stop();
		}
	}

	public void ThreadCalculationLoop()
	{
		try
		{
			while (true)
			{
				if (bExecute)
				{
					GC.TryStartNoGCRegion(clsNesting.ParNest.Settings.GarbageCollectionDisableSize, disallowFullBlockingGC: true);
					multiResult_0 = tempPowerNest.MultiNest(ilist_0, ilist_4, ilist_2, double_0);
					GC.KeepAlive(iuserData_0);
					GC.KeepAlive(iuserData_1);
					bStop = false;
					bExecute = false;
					bExecuteDone = true;
					GC.EndNoGCRegion();
				}
			}
		}
		catch (Exception)
		{
		}
	}
}
