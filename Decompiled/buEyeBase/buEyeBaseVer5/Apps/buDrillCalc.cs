using System;
using System.Collections.Generic;
using System.Drawing;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

public class buDrillCalc
{
	public static List<string> LangDrillStatus = new List<string>();

	public static List<string> LangDrillMessage = new List<string>();

	public static List<string> LangDrillCaptions = new List<string>();

	public static List<string> LangDrillCommands = new List<string>();

	public buDrillCalc()
	{
		if (!buVector5.smethod_0("buDrillCalc"))
		{
			throw new RegisterException("buDrillCalc");
		}
	}

	public void ToolToStringList(List<ToolBase5> ToolList, ref List<string> SL)
	{
		SL = new List<string>();
		for (int i = 0; i <= ToolList.Count - 1; i++)
		{
			if (ToolList[i] != null)
			{
				string text = "Tool = No: " + ToolList[i].Data.No.ToString("000") + " ; ";
				string text2 = string.Format("{0,10}", ToolList[i].Geometry.DiameterBody.ToString("f3"));
				text = text + "BodyDia: " + text2 + " ; ";
				string text3 = string.Format("{0,10}", ToolList[i].Geometry.Length.ToString("f3"));
				text = text + "BodyLen: " + text3 + " ; ";
				string text4 = string.Format("{0,10}", ToolList[i].Geometry.Diameter.ToString("f3"));
				text = text + "CutDia: " + text4 + " ; ";
				string text5 = string.Format("{0,10}", ToolList[i].Geometry.CutLength.ToString("f3"));
				text = text + "CutLen: " + text5 + " ; ";
				text = text + "Dir: " + buConversion5.ToolDirectionToString(ToolList[i].Geometry.ToolDirection) + " ; ";
				string text6 = $"{Convert.ToInt32(ToolList[i].Purpose).ToString(),3}";
				text = text + "Purpose: " + text6 + " ; ";
				string text7 = $"{Convert.ToInt32(ToolList[i].Geometry.GeometryType).ToString(),3}";
				text = text + "Type: " + text7 + " ; ";
				string text8 = $"{ToolList[i].Data.GroupIndex.ToString(),3}";
				text = text + "GrpIndex: " + text8 + " ; ";
				string text9 = $"{ToolList[i].Data.GroupItemIndex.ToString(),3}";
				text = text + "GrpItemIndex: " + text9 + " ; ";
				string text10 = string.Format("{0,12}", ToolList[i].Positions.Offset.X.ToString("f3"));
				text = text + "XOffset: " + text10 + " ; ";
				string text11 = string.Format("{0,12}", ToolList[i].Positions.Offset.Y.ToString("f3"));
				text = text + "YOffset: " + text11 + " ; ";
				string text12 = string.Format("{0,12}", ToolList[i].Positions.Offset.Z.ToString("f3"));
				text = text + "ZOffset: " + text12 + " ; ";
				string text13 = string.Format("{0,12}", ToolList[i].Positions.Position.X.ToString("f3"));
				text = text + "XPosition: " + text13 + " ; ";
				string text14 = string.Format("{0,12}", ToolList[i].Positions.Position.Y.ToString("f3"));
				text = text + "YPosition: " + text14 + " ; ";
				string text15 = string.Format("{0,12}", ToolList[i].Positions.Position.Z.ToString("f3"));
				text = text + "ZPosition: " + text15 + " ; ";
				string text16 = $"{Convert.ToInt32(ToolList[i].Positions.Location).ToString(),4}";
				text = text + "Location: " + text16 + " ; ";
				string text17 = string.Format("{0,12}", ToolList[i].Positions.CommonOffset.X.ToString("f3"));
				text = text + "XOffsetCommon: " + text17 + " ; ";
				string text18 = string.Format("{0,12}", ToolList[i].Positions.CommonOffset.Y.ToString("f3"));
				text = text + "YOffsetCommon: " + text18 + " ; ";
				string text19 = string.Format("{0,12}", ToolList[i].Positions.CommonOffset.Z.ToString("f3"));
				text = text + "ZOffsetCommon: " + text19 + " ; ";
				string text20 = string.Format("{0,12}", ToolList[i].Limits.AxesMinLimits.Y.ToString("f3"));
				text = text + "MinLimitY: " + text20 + " ; ";
				string text21 = string.Format("{0,12}", ToolList[i].Limits.AxesMaxLimits.Y.ToString("f3"));
				text = text + "MaxLimitY: " + text21 + " ; ";
				string text22 = string.Format("{0,12}", ToolList[i].CamData.PlungeSpeed.ToString("f3"));
				text = text + "SPlunge: " + text22 + " ; ";
				string text23 = string.Format("{0,12}", ToolList[i].CamData.WaitTime.ToString("f3"));
				text = text + "SWait: " + text23;
				SL.Add(text);
			}
		}
	}

	public void StringListToTool(List<string> SL, ref List<ToolBase5> ToolList)
	{
		if (SL.Count <= 0)
		{
			return;
		}
		for (int i = 0; i <= SL.Count - 1; i++)
		{
			int num = -1;
			if (SL[i].Length <= 2 || !(SL[i].Substring(0, 1) != "|"))
			{
				continue;
			}
			string[] array = SL[i].Split('=');
			if (array == null || array.Length < 2)
			{
				continue;
			}
			string[] array2 = array[1].Split(';');
			if (!((array2 != null) & (array2.Length >= 10)))
			{
				continue;
			}
			ToolBase5 toolBase = new ToolBase5();
			for (int j = 0; j <= array2.Length - 1; j++)
			{
				string[] array3 = array2[j].Split(':');
				if (j == 0)
				{
					if (array3.Length != 1)
					{
						if (array3.Length == 2 && buNumeric5.IsNumeric(array3[1]))
						{
							num = int.Parse(array3[1]);
						}
					}
					else if (buNumeric5.IsNumeric(array3[0]))
					{
						num = int.Parse(array3[0]);
					}
					if (num >= 0)
					{
						toolBase.Data.No = num;
					}
				}
				if (j == 1 && num >= 0)
				{
					if (array3.Length != 1)
					{
						if (array3.Length == 2 && buNumeric5.IsNumeric(array3[1]))
						{
							toolBase.Geometry.DiameterBody = double.Parse(array3[1]);
						}
					}
					else if (buNumeric5.IsNumeric(array3[0]))
					{
						toolBase.Geometry.DiameterBody = double.Parse(array3[0]);
					}
				}
				if (j == 2 && num >= 0)
				{
					if (array3.Length != 1)
					{
						if (array3.Length == 2 && buNumeric5.IsNumeric(array3[1]))
						{
							toolBase.Geometry.Length = double.Parse(array3[1]);
						}
					}
					else if (buNumeric5.IsNumeric(array3[0]))
					{
						toolBase.Geometry.Length = double.Parse(array3[0]);
					}
				}
				if (j == 3 && num >= 0)
				{
					if (array3.Length != 1)
					{
						if (array3.Length == 2 && buNumeric5.IsNumeric(array3[1]))
						{
							toolBase.Geometry.Diameter = double.Parse(array3[1]);
						}
					}
					else if (buNumeric5.IsNumeric(array3[0]))
					{
						toolBase.Geometry.Diameter = double.Parse(array3[0]);
					}
				}
				if (j == 4 && num >= 0)
				{
					if (array3.Length != 1)
					{
						if (array3.Length == 2 && buNumeric5.IsNumeric(array3[1]))
						{
							toolBase.Geometry.CutLength = double.Parse(array3[1]);
							toolBase.Geometry.Thickness = toolBase.Geometry.CutLength;
						}
					}
					else if (buNumeric5.IsNumeric(array3[0]))
					{
						toolBase.Geometry.CutLength = double.Parse(array3[0]);
						toolBase.Geometry.Thickness = toolBase.Geometry.CutLength;
					}
				}
				if (j == 5 && num >= 0)
				{
					if (array3.Length != 1)
					{
						if (array3.Length == 2)
						{
							if (array3[1].ToLower().Trim() == "+x")
							{
								toolBase.Geometry.ToolDirection = new Vec3D(1.0, 0.0, 0.0);
							}
							if (array3[1].ToLower().Trim() == "+y")
							{
								toolBase.Geometry.ToolDirection = new Vec3D(0.0, 1.0, 0.0);
							}
							if (array3[1].ToLower().Trim() == "+z")
							{
								toolBase.Geometry.ToolDirection = new Vec3D(0.0, 0.0, 1.0);
							}
							if (array3[1].ToLower().Trim() == "-x")
							{
								toolBase.Geometry.ToolDirection = new Vec3D(-1.0, 0.0, 0.0);
							}
							if (array3[1].ToLower().Trim() == "-y")
							{
								toolBase.Geometry.ToolDirection = new Vec3D(0.0, -1.0, 0.0);
							}
							if (array3[1].ToLower().Trim() == "-z")
							{
								toolBase.Geometry.ToolDirection = new Vec3D(0.0, 0.0, -1.0);
							}
						}
					}
					else
					{
						if (array3[0].ToLower().Trim() == "+x")
						{
							toolBase.Geometry.ToolDirection = new Vec3D(1.0, 0.0, 0.0);
						}
						if (array3[0].ToLower().Trim() == "+y")
						{
							toolBase.Geometry.ToolDirection = new Vec3D(0.0, 1.0, 0.0);
						}
						if (array3[0].ToLower().Trim() == "+z")
						{
							toolBase.Geometry.ToolDirection = new Vec3D(0.0, 0.0, 1.0);
						}
						if (array3[0].ToLower().Trim() == "-x")
						{
							toolBase.Geometry.ToolDirection = new Vec3D(-1.0, 0.0, 0.0);
						}
						if (array3[0].ToLower().Trim() == "-y")
						{
							toolBase.Geometry.ToolDirection = new Vec3D(0.0, -1.0, 0.0);
						}
						if (array3[0].ToLower().Trim() == "-z")
						{
							toolBase.Geometry.ToolDirection = new Vec3D(0.0, 0.0, -1.0);
						}
					}
				}
				if (j == 6 && num >= 0)
				{
					if (array3.Length != 1)
					{
						if (array3.Length == 2 && buNumeric5.IsNumeric(array3[1]))
						{
							toolBase.Purpose = (ToolPurpose)int.Parse(array3[1]);
						}
					}
					else if (buNumeric5.IsNumeric(array3[0]))
					{
						toolBase.Purpose = (ToolPurpose)int.Parse(array3[0]);
					}
				}
				if (j == 7 && num >= 0)
				{
					if (array3.Length != 1)
					{
						if (array3.Length == 2 && buNumeric5.IsNumeric(array3[1]))
						{
							toolBase.Geometry.GeometryType = (ToolType)int.Parse(array3[1]);
						}
					}
					else if (buNumeric5.IsNumeric(array3[0]))
					{
						toolBase.Geometry.GeometryType = (ToolType)int.Parse(array3[0]);
					}
					if (toolBase.Geometry.GeometryType == ToolType.Slot)
					{
						toolBase.Geometry.ShoulderLength = toolBase.Geometry.Length - toolBase.Geometry.CutLength;
						toolBase.Geometry.ShoulderDiameter = toolBase.Geometry.DiameterBody;
					}
				}
				if (j == 8 && num >= 0)
				{
					if (array3.Length != 1)
					{
						if (array3.Length == 2 && buNumeric5.IsNumeric(array3[1]))
						{
							toolBase.Data.GroupIndex = int.Parse(array3[1]);
						}
					}
					else if (buNumeric5.IsNumeric(array3[0]))
					{
						toolBase.Data.GroupIndex = int.Parse(array3[0]);
					}
				}
				if (j == 9 && num >= 0)
				{
					if (array3.Length != 1)
					{
						if (array3.Length == 2 && buNumeric5.IsNumeric(array3[1]))
						{
							toolBase.Data.GroupItemIndex = int.Parse(array3[1]);
						}
					}
					else if (buNumeric5.IsNumeric(array3[0]))
					{
						toolBase.Data.GroupItemIndex = int.Parse(array3[0]);
					}
				}
				if (j == 10 && num >= 0)
				{
					if (array3.Length != 1)
					{
						if (array3.Length == 2 && buNumeric5.IsNumeric(array3[1]))
						{
							toolBase.Positions.Offset.X = double.Parse(array3[1]);
						}
					}
					else if (buNumeric5.IsNumeric(array3[0]))
					{
						toolBase.Positions.Offset.X = double.Parse(array3[0]);
					}
				}
				if (j == 11 && num >= 0)
				{
					if (array3.Length != 1)
					{
						if (array3.Length == 2 && buNumeric5.IsNumeric(array3[1]))
						{
							toolBase.Positions.Offset.Y = double.Parse(array3[1]);
						}
					}
					else if (buNumeric5.IsNumeric(array3[0]))
					{
						toolBase.Positions.Offset.Y = double.Parse(array3[0]);
					}
				}
				if (j == 12 && num >= 0)
				{
					if (array3.Length != 1)
					{
						if (array3.Length == 2 && buNumeric5.IsNumeric(array3[1]))
						{
							toolBase.Positions.Offset.Z = double.Parse(array3[1]);
						}
					}
					else if (buNumeric5.IsNumeric(array3[0]))
					{
						toolBase.Positions.Offset.Z = double.Parse(array3[0]);
					}
				}
				if (j == 13 && num >= 0)
				{
					if (array3.Length != 1)
					{
						if (array3.Length == 2 && buNumeric5.IsNumeric(array3[1]))
						{
							toolBase.Positions.Position.X = double.Parse(array3[1]);
						}
					}
					else if (buNumeric5.IsNumeric(array3[0]))
					{
						toolBase.Positions.Position.X = double.Parse(array3[0]);
					}
				}
				if (j == 14 && num >= 0)
				{
					if (array3.Length != 1)
					{
						if (array3.Length == 2 && buNumeric5.IsNumeric(array3[1]))
						{
							toolBase.Positions.Position.Y = double.Parse(array3[1]);
						}
					}
					else if (buNumeric5.IsNumeric(array3[0]))
					{
						toolBase.Positions.Position.Y = double.Parse(array3[0]);
					}
				}
				if (j == 15 && num >= 0)
				{
					if (array3.Length != 1)
					{
						if (array3.Length == 2 && buNumeric5.IsNumeric(array3[1]))
						{
							toolBase.Positions.Position.Z = double.Parse(array3[1]);
						}
					}
					else if (buNumeric5.IsNumeric(array3[0]))
					{
						toolBase.Positions.Position.Z = double.Parse(array3[0]);
					}
				}
				if (j == 16 && num >= 0)
				{
					if (array3.Length != 1)
					{
						if (array3.Length == 2 && buNumeric5.IsNumeric(array3[1]))
						{
							toolBase.Positions.Location = (ToolLocationType)int.Parse(array3[1]);
						}
					}
					else if (buNumeric5.IsNumeric(array3[0]))
					{
						toolBase.Positions.Location = (ToolLocationType)int.Parse(array3[0]);
					}
				}
				if (j == 17 && num >= 0)
				{
					if (array3.Length != 1)
					{
						if (array3.Length == 2 && buNumeric5.IsNumeric(array3[1]))
						{
							toolBase.Positions.CommonOffset.X = double.Parse(array3[1]);
						}
					}
					else if (buNumeric5.IsNumeric(array3[0]))
					{
						toolBase.Positions.CommonOffset.X = double.Parse(array3[0]);
					}
				}
				if (j == 18 && num >= 0)
				{
					if (array3.Length != 1)
					{
						if (array3.Length == 2 && buNumeric5.IsNumeric(array3[1]))
						{
							toolBase.Positions.CommonOffset.Y = double.Parse(array3[1]);
						}
					}
					else if (buNumeric5.IsNumeric(array3[0]))
					{
						toolBase.Positions.CommonOffset.Y = double.Parse(array3[0]);
					}
				}
				if (j == 19 && num >= 0)
				{
					if (array3.Length != 1)
					{
						if (array3.Length == 2 && buNumeric5.IsNumeric(array3[1]))
						{
							toolBase.Positions.CommonOffset.Z = double.Parse(array3[1]);
						}
					}
					else if (buNumeric5.IsNumeric(array3[0]))
					{
						toolBase.Positions.CommonOffset.Z = double.Parse(array3[0]);
					}
				}
				if (j == 20 && num >= 0)
				{
					if (array3.Length != 1)
					{
						if (array3.Length == 2 && buNumeric5.IsNumeric(array3[1]))
						{
							toolBase.Limits.AxesMinLimits.Y = double.Parse(array3[1]);
						}
					}
					else if (buNumeric5.IsNumeric(array3[0]))
					{
						toolBase.Limits.AxesMinLimits.Y = double.Parse(array3[0]);
					}
				}
				if (j == 21 && num >= 0)
				{
					if (array3.Length != 1)
					{
						if (array3.Length == 2 && buNumeric5.IsNumeric(array3[1]))
						{
							toolBase.Limits.AxesMaxLimits.Y = double.Parse(array3[1]);
						}
					}
					else if (buNumeric5.IsNumeric(array3[0]))
					{
						toolBase.Limits.AxesMaxLimits.Y = double.Parse(array3[0]);
					}
				}
				if (j == 22 && num >= 0)
				{
					if (array3.Length != 1)
					{
						if (array3.Length == 2 && buNumeric5.IsNumeric(array3[1]))
						{
							toolBase.CamData.PlungeSpeed = double.Parse(array3[1]);
						}
					}
					else if (buNumeric5.IsNumeric(array3[0]))
					{
						toolBase.CamData.PlungeSpeed = double.Parse(array3[0]);
					}
				}
				if (j != 23 || num < 0)
				{
					continue;
				}
				if (array3.Length != 1)
				{
					if (array3.Length == 2 && buNumeric5.IsNumeric(array3[1]))
					{
						toolBase.CamData.WaitTime = double.Parse(array3[1]);
					}
				}
				else if (buNumeric5.IsNumeric(array3[0]))
				{
					toolBase.CamData.WaitTime = double.Parse(array3[0]);
				}
			}
			ToolList.Add(toolBase);
		}
	}

	public void FindOperationToolFromString(List<ToolGroup5> Tools, ToolBase5 toolActive, string sTool, ref buShape S)
	{
		if (sTool.Trim().Length <= 0)
		{
			if (Tools.Count > 0 && Tools[0].Tools.Count > 0)
			{
				S.Tool = new ToolBase5(Tools[0].Tools[0]);
			}
			S.InfoMessages = new List<string>();
			S.InfoMessages.Add(buLangTranslate.preSentences.OperationToolIsNotInToolList);
		}
		else
		{
			buCall.buVector5_0.FindToolWithToolName(Tools, sTool.Trim(), ref S.Tool);
		}
		if (S.Tool == null)
		{
			S.Tool = new ToolBase5(toolActive);
			S.InfoMessages = new List<string>();
			S.InfoMessages.Add(buLangTranslate.preSentences.OperationToolIsNotInToolList);
		}
	}

	public bool isSingleClamperAvailable(DrillJob Job, DrillCNCSettings Settings, ref double X1Pos, ref double X2Pos)
	{
		List<double> list = new List<double>();
		List<double> list2 = new List<double>();
		for (int i = 0; i <= Job.ItemCalc.Count - 1; i++)
		{
			if (!((Job.ItemCalc[i].planeName == planeBoxNames.Front) | (Job.ItemCalc[i].planeName == planeBoxNames.Back)))
			{
				if (!(Math.Abs(Job.ItemCalc[i].Center.Y) < Settings.ClamperCatchWidth))
				{
					list2.Add(Job.ItemCalc[i].Center.X);
				}
				else
				{
					list.Add(Job.ItemCalc[i].Center.X);
				}
			}
			else if (!(Math.Abs(Job.ItemCalc[i].Center.Y) < Settings.ClamperCatchWidth + Settings.HorizontalToolHolderWidth / 2.0))
			{
				list2.Add(Job.ItemCalc[i].Center.X);
			}
			else
			{
				list.Add(Job.ItemCalc[i].Center.X);
			}
		}
		if (list.Count >= 2)
		{
			double num = 0.0;
			for (int j = 1; j <= list.Count - 1; j++)
			{
				num = list[j] - list[j - 1];
				if (num > Settings.ClamperLength + Settings.ClamperBetweenMinDistance)
				{
					X2Pos = 0.0 - Math.Abs(list[j - 1] + (list[j] - list[j - 1]) / 2.0);
					X1Pos = 0.0 - (Job.Material.Size.Width + Settings.ClamperLength + 3.0 * Settings.ClamperLength);
					return true;
				}
			}
			num = Math.Abs(list[0]);
			if (num > Settings.ClamperLength + Settings.ClamperBetweenMinDistance)
			{
				X2Pos = (0.0 - num) / 2.0;
				X1Pos = 0.0 - (Job.Material.Size.Width + Settings.ClamperLength + 3.0 * Settings.ClamperLength);
				return true;
			}
			double num2 = Job.Material.Size.Width + Settings.ClamperLength * 0.3;
			num = num2 - Math.Abs(list[list.Count - 1]);
			if (num > Settings.ClamperLength + Settings.ClamperBetweenMinDistance)
			{
				X2Pos = 0.0 - Math.Abs(list[list.Count - 1] + (num2 - list[list.Count - 1]) / 2.0);
				X1Pos = 0.0 - (Job.Material.Size.Width + Settings.ClamperLength + 3.0 * Settings.ClamperLength);
				return true;
			}
		}
		if (list.Count != 1 || !(Job.Material.Size.Width < Settings.ClamperLength) || list[0] != 0.0)
		{
			if (!((list.Count == 0) & (list2.Count > 0)))
			{
				return false;
			}
			X2Pos = (0.0 - Job.Material.Size.Width) / 2.0;
			X1Pos = 0.0 - (Job.Material.Size.Width + Settings.ClamperLength + 3.0 * Settings.ClamperLength);
			return true;
		}
		X2Pos = (0.0 - Settings.ClamperLength) / 2.0;
		X1Pos = 0.0 - (Job.Material.Size.Width + Settings.ClamperLength + 3.0 * Settings.ClamperLength);
		return true;
	}

	public bool SingleMustClamper(DrillJob Job, DrillCNCSettings Settings, ref double X1Pos, ref double X2Pos)
	{
		double num = (0.0 - Job.Material.Size.Width) / 2.0;
		bool flag = false;
		bool flag2 = false;
		for (int i = 0; i <= Job.Items.Count - 1; i++)
		{
			if (Job.Items[i].planeName == planeBoxNames.Right)
			{
				flag = true;
			}
			if (Job.Items[i].planeName == planeBoxNames.Left)
			{
				flag2 = true;
			}
		}
		if (flag2)
		{
			if (!flag)
			{
				num = 0.0 - Job.Material.Size.Width + Settings.ClamperLength / 2.0;
			}
		}
		else
		{
			num = (0.0 - Settings.ClamperLength) / 2.0;
		}
		X2Pos = num;
		X1Pos = 0.0 - (Job.Material.Size.Width + Settings.ClamperLength + 3.0 * Settings.ClamperLength);
		return true;
	}

	public void ChangeCornerOpposite(ref CornerLocation Corner)
	{
		if (Corner != CornerLocation.RightBottom)
		{
			if (Corner != CornerLocation.RightTop)
			{
				if (Corner != CornerLocation.RightCenter)
				{
					if (Corner != CornerLocation.LeftBottom)
					{
						if (Corner != CornerLocation.LeftTop)
						{
							if (Corner == CornerLocation.LeftCenter)
							{
								Corner = CornerLocation.RightCenter;
							}
						}
						else
						{
							Corner = CornerLocation.RightTop;
						}
					}
					else
					{
						Corner = CornerLocation.RightBottom;
					}
				}
				else
				{
					Corner = CornerLocation.LeftCenter;
				}
			}
			else
			{
				Corner = CornerLocation.LeftTop;
			}
		}
		else
		{
			Corner = CornerLocation.LeftBottom;
		}
	}

	public string MoveCommandToString(DrillMoveCommand Cmd)
	{
		string result = "";
		if (Cmd == DrillMoveCommand.AllClamperDown)
		{
			result = LangDrillCommands[0];
		}
		if (Cmd == DrillMoveCommand.AllClamperUp)
		{
			result = LangDrillCommands[1];
		}
		if (Cmd == DrillMoveCommand.AxisMove)
		{
			result = LangDrillCommands[2];
		}
		if (Cmd == DrillMoveCommand.Clamper1Down)
		{
			result = LangDrillCommands[3];
		}
		if (Cmd == DrillMoveCommand.Clamper1Up)
		{
			result = LangDrillCommands[4];
		}
		if (Cmd == DrillMoveCommand.Clamper2Down)
		{
			result = LangDrillCommands[5];
		}
		if (Cmd == DrillMoveCommand.Clamper2Up)
		{
			result = LangDrillCommands[6];
		}
		if (Cmd == DrillMoveCommand.Finished)
		{
			result = LangDrillCommands[7];
		}
		if (Cmd == DrillMoveCommand.GCode)
		{
			result = LangDrillCommands[8];
		}
		if (Cmd == DrillMoveCommand.None)
		{
			result = LangDrillCommands[9];
		}
		if (Cmd == DrillMoveCommand.ResetAll)
		{
			result = LangDrillCommands[10];
		}
		if (Cmd == DrillMoveCommand.ResetAllPress)
		{
			result = LangDrillCommands[11];
		}
		if (Cmd == DrillMoveCommand.ResetPiston)
		{
			result = LangDrillCommands[12];
		}
		if (Cmd == DrillMoveCommand.ResetPress)
		{
			result = LangDrillCommands[13];
		}
		if (Cmd == DrillMoveCommand.SetPiston)
		{
			result = LangDrillCommands[14];
		}
		if (Cmd == DrillMoveCommand.SetPress)
		{
			result = LangDrillCommands[15];
		}
		if (Cmd == DrillMoveCommand.Wait)
		{
			result = LangDrillCommands[16];
		}
		if (Cmd == DrillMoveCommand.XAxesGantyOff)
		{
			result = LangDrillCommands[17];
		}
		if (Cmd == DrillMoveCommand.XAxesGantyOn)
		{
			result = LangDrillCommands[18];
		}
		return result;
	}

	public string DrillMoveToolsToString(DrillMove Move)
	{
		string text = "";
		if (Move.Tool1 != 0)
		{
			text = text + "T: " + Move.Tool1 + " - ";
		}
		if (Move.Tool2 != 0)
		{
			text = text + "T: " + Move.Tool2 + " - ";
		}
		if (Move.Tool3 != 0)
		{
			text = text + "T: " + Move.Tool3 + " - ";
		}
		if (Move.Tool4 != 0)
		{
			text = text + "T: " + Move.Tool4 + " - ";
		}
		if (Move.Tool5 != 0)
		{
			text = text + "T: " + Move.Tool5 + " - ";
		}
		if (Move.Tool6 != 0)
		{
			text = text + "T: " + Move.Tool6;
		}
		if (Move.Tool7 != 0)
		{
			text = text + "T: " + Move.Tool7 + " - ";
		}
		if (Move.Tool8 != 0)
		{
			text = text + "T: " + Move.Tool8 + " - ";
		}
		if (Move.Tool9 != 0)
		{
			text = text + "T: " + Move.Tool9 + " - ";
		}
		if (Move.Tool10 != 0)
		{
			text = text + "T: " + Move.Tool10 + " - ";
		}
		if (Move.Tool11 != 0)
		{
			text = text + "T: " + Move.Tool11 + " - ";
		}
		if (Move.Tool12 != 0)
		{
			text = text + "T: " + Move.Tool12;
		}
		return text;
	}

	public string JobItemCommandToString(buShape Item)
	{
		string result = "";
		if (Item.ShapeGroup == ShapeGroup.Drill)
		{
			if (!(Item.GetType() == typeof(buShapeHole)))
			{
				if (!(Item.GetType() == typeof(buShapeHoleMulti)))
				{
					if (Item.GetType() == typeof(buShapeHole3))
					{
						buShapeHole3 buShapeHole4 = Item as buShapeHole3;
						string text = "";
						if (buShapeHole4.isMilling)
						{
							text = " (M)";
						}
						string text2 = "3 " + buLangTranslate.preDef.Hole;
						result = text2 + text;
					}
				}
				else
				{
					buShapeHoleMulti buShapeHoleMulti2 = Item as buShapeHoleMulti;
					string text3 = "";
					if (buShapeHoleMulti2.isMilling)
					{
						text3 = " (M)";
					}
					string text4 = "";
					if (buShapeHoleMulti2.DrillType == drillTypes.HorizontalHoles)
					{
						text4 = buLangTranslate.preDef.Horizontal + " " + buLangTranslate.preDef.Multi + " " + buLangTranslate.preDef.Hole + " ";
					}
					if (buShapeHoleMulti2.DrillType == drillTypes.HorizontalLineHoles)
					{
						text4 = buLangTranslate.preDef.Horizontal + " " + buLangTranslate.preDef.Multi + " " + buLangTranslate.preDef.Line + " " + buLangTranslate.preDef.Hole + " ";
					}
					if (buShapeHoleMulti2.DrillType == drillTypes.VerticalHoles)
					{
						text4 = buLangTranslate.preDef.Vertical + " " + buLangTranslate.preDef.Multi + " " + buLangTranslate.preDef.Hole + " ";
					}
					if (buShapeHoleMulti2.DrillType == drillTypes.VerticalLineHoles)
					{
						text4 = buLangTranslate.preDef.Vertical + " " + buLangTranslate.preDef.Multi + " " + buLangTranslate.preDef.Line + " " + buLangTranslate.preDef.Hole + " ";
					}
					if (buShapeHoleMulti2.DrillType == drillTypes.InclineHoles)
					{
						text4 = buLangTranslate.preDef.Inclined + " " + buLangTranslate.preDef.Multi + " " + buLangTranslate.preDef.Hole + " ";
					}
					result = text4 + text3;
				}
			}
			else
			{
				buShapeHole buShapeHole5 = Item as buShapeHole;
				string text5 = "";
				if (buShapeHole5.isMilling)
				{
					text5 = " (M)";
				}
				string text6 = buLangTranslate.preDef.Single + " " + buLangTranslate.preDef.Hole + " ";
				result = text6 + text5;
			}
		}
		if (Item.ShapeGroup == ShapeGroup.Cut && Item.GetType() == typeof(buShapeCut))
		{
			buShapeCut buShapeCut2 = Item as buShapeCut;
			string text7 = "";
			if (buShapeCut2.isMilling)
			{
				text7 = " (M)";
			}
			string text8 = "";
			if (buShapeCut2.CutType == CutTypes.CutHorizontal)
			{
				text8 = buLangTranslate.preDef.Horizontal + " " + buLangTranslate.preDef.Slot + " ";
			}
			if (buShapeCut2.CutType == CutTypes.CutHorizontalLine)
			{
				text8 = buLangTranslate.preDef.Horizontal + " " + buLangTranslate.preDef.Line + " " + buLangTranslate.preDef.Slot + " ";
			}
			if (buShapeCut2.CutType == CutTypes.CutVertical)
			{
				text8 = buLangTranslate.preDef.Vertical + " " + buLangTranslate.preDef.Slot + " ";
			}
			if (buShapeCut2.CutType == CutTypes.CutVerticalLine)
			{
				text8 = buLangTranslate.preDef.Vertical + " " + buLangTranslate.preDef.Line + " " + buLangTranslate.preDef.Slot + " ";
			}
			if (buShapeCut2.CutType == CutTypes.CutFree)
			{
				text8 = buLangTranslate.preDef.Free + " " + buLangTranslate.preDef.Slot + " ";
			}
			result = text8 + text7;
		}
		if (Item.ShapeGroup == ShapeGroup.Shape)
		{
			string text9 = "";
			if (Item.ShapeType == ShapeTypes.Rectangle)
			{
				text9 = ((((buShapeRectangle)Item).Radius == 0.0) ? (buLangTranslate.preDef.Rect + " ") : (buLangTranslate.preDef.Rect + " " + buLangTranslate.preDef.Round + " "));
			}
			if (Item.ShapeType == ShapeTypes.Circle)
			{
				text9 = buLangTranslate.preDef.Cirlce + " ";
			}
			if (Item.ShapeType == ShapeTypes.Ellipse)
			{
				text9 = buLangTranslate.preDef.Ellipse + " ";
			}
			if (Item.ShapeType == ShapeTypes.KeyHole)
			{
				text9 = buLangTranslate.preDef.KeyHole + " ";
			}
			if (Item.ShapeType == ShapeTypes.Polygon)
			{
				text9 = buLangTranslate.preDef.Polygon + " ";
			}
			if (Item.ShapeType == ShapeTypes.Slot)
			{
				text9 = buLangTranslate.preDef.Slot + " ";
			}
			if (Item.ShapeType == ShapeTypes.Text)
			{
				text9 = buLangTranslate.preDef.Text + " ";
			}
			if (Item.ShapeType == ShapeTypes.Trepezoid)
			{
				text9 = buLangTranslate.preDef.Trapezoid + " ";
			}
			if (Item.ShapeType == ShapeTypes.Triangle)
			{
				text9 = buLangTranslate.preDef.Triangle + " ";
			}
			if (Item.ShapeType == ShapeTypes.FreeDraw)
			{
				text9 = buLangTranslate.preDef.FreeDraw + " ";
			}
			if (Item.ShapeType == ShapeTypes.Rhombus)
			{
				text9 = buLangTranslate.preDef.Rhombus + " ";
			}
			if (Item.ShapeType == ShapeTypes.Star)
			{
				text9 = buLangTranslate.preDef.Star + " ";
			}
			if (Item.ShapeType == ShapeTypes.Moon)
			{
				text9 = buLangTranslate.preDef.Moon + " ";
			}
			result = text9;
		}
		if (Item.ShapeGroup == ShapeGroup.Profiling)
		{
			buShapeProfiling buShapeProfiling2 = Item as buShapeProfiling;
			string text10 = "";
			if (buShapeProfiling2.ProfilingType == ProfilingTypes.ProfilingRectangle)
			{
				text10 = buLangTranslate.preDef.Rect + " " + buLangTranslate.preDef.Corner + " ";
			}
			if (buShapeProfiling2.ProfilingType == ProfilingTypes.ProfilingRound)
			{
				text10 = buLangTranslate.preDef.Round + " " + buLangTranslate.preDef.Corner + " ";
			}
			if (buShapeProfiling2.ProfilingType == ProfilingTypes.ProfilingChamfer)
			{
				text10 = buLangTranslate.preDef.Chamfer + " " + buLangTranslate.preDef.Corner + " ";
			}
			if (buShapeProfiling2.ProfilingType == ProfilingTypes.ProfilingRoundConcave)
			{
				text10 = buLangTranslate.preDef.Round + " " + buLangTranslate.preDef.Concave + " " + buLangTranslate.preDef.Corner + " ";
			}
			result = text10;
		}
		if (Item.ShapeGroup == ShapeGroup.Junction)
		{
			buShapeJunction buShapeJunction2 = Item as buShapeJunction;
			string text11 = "";
			if (buShapeJunction2.JunctionType == JunctionTypes.Junction2HoleNearByHorizontal)
			{
				text11 = "2 " + buLangTranslate.preDef.Hole + " " + buLangTranslate.preDef.Junction + " " + buLangTranslate.preDef.Horizontal + " ";
			}
			if (buShapeJunction2.JunctionType == JunctionTypes.Junction2HoleNearByVertical)
			{
				text11 = "2 " + buLangTranslate.preDef.Hole + " " + buLangTranslate.preDef.Junction + " " + buLangTranslate.preDef.Vertical + " ";
			}
			if (buShapeJunction2.JunctionType == JunctionTypes.Junction3HoleIntersectHorizontal)
			{
				text11 = "3 " + buLangTranslate.preDef.Hole + " " + buLangTranslate.preDef.Junction + " " + buLangTranslate.preDef.Horizontal + " ";
			}
			if (buShapeJunction2.JunctionType == JunctionTypes.Junction3HoleIntersectVertical)
			{
				text11 = "3 " + buLangTranslate.preDef.Hole + " " + buLangTranslate.preDef.Junction + " " + buLangTranslate.preDef.Vertical + " ";
			}
			result = text11;
		}
		if (Item.ShapeGroup == ShapeGroup.Engraving)
		{
			string text12 = buLangTranslate.preDef.Engraving + " ";
			result = text12;
		}
		if (Item.ShapeGroup == ShapeGroup.Text)
		{
			string text13 = buLangTranslate.preDef.Text + " ";
			result = text13;
		}
		if (Item.ShapeGroup == ShapeGroup.Contour)
		{
			string text14 = buLangTranslate.preDef.Contour + " ";
			result = text14;
		}
		return result;
	}

	public string PlaneBoxNamesToString(planeBoxNames plane)
	{
		return plane switch
		{
			planeBoxNames.Top => buLangTranslate.preDef.Top, 
			planeBoxNames.Bottom => buLangTranslate.preDef.Bottom, 
			planeBoxNames.Left => buLangTranslate.preDef.Left, 
			planeBoxNames.Right => buLangTranslate.preDef.Right, 
			planeBoxNames.Front => buLangTranslate.preDef.Front, 
			planeBoxNames.Back => buLangTranslate.preDef.Back, 
			planeBoxNames.Free => buLangTranslate.preDef.Free, 
			_ => "", 
		};
	}

	public string DrillCalcItemToString(DrillCalcItem Item)
	{
		string text = "";
		text += PlaneBoxNamesToString(Item.planeName);
		text = text + " - " + buLangTranslate.preDef.Diameter + " " + Item.Diameter.ToString("f1");
		text = text + " - " + buLangTranslate.preDef.Depth + " " + Item.Depth.ToString("f1");
		return text + " - " + buLangTranslate.preDef.Center + " X: " + Item.Center.X.ToString("f1") + " , Y: " + Item.Center.Y.ToString("f1") + " , Z: " + Item.Center.Z.ToString("f1");
	}

	public void CreateClamperEntities(Entity ClamperEntity, double FirstClamperX, double SecondClamperX, ref Entity FirstClamper, ref Entity SecondClamper, Color Clr, int Transparency = 100)
	{
		if (ClamperEntity != null)
		{
			FirstClamper = null;
			SecondClamper = null;
			buVector5.CopyEntities(ClamperEntity, ref FirstClamper);
			buVector5.CopyEntities(ClamperEntity, ref SecondClamper);
			if (FirstClamper != null)
			{
				CustomData customData = new CustomData();
				customData.typeDefination = entityTypeDefination.Clamper;
				customData.RefIndex = 1;
				FirstClamper.Translate(FirstClamperX, 0.0);
				FirstClamper.EntityData = customData;
				FirstClamper.ColorMethod = colorMethodType.byEntity;
				FirstClamper.Color = Color.FromArgb(Transparency, Clr);
			}
			if (SecondClamper != null)
			{
				CustomData customData2 = new CustomData();
				customData2.typeDefination = entityTypeDefination.Clamper;
				customData2.RefIndex = 2;
				SecondClamper.Translate(SecondClamperX, 0.0);
				SecondClamper.ColorMethod = colorMethodType.byEntity;
				SecondClamper.Color = Color.FromArgb(Transparency, Clr);
				SecondClamper.EntityData = customData2;
			}
		}
	}

	public void EnableDisableOperations(bool Status, ref DrillJob Job, bool Hole, bool Shape, bool Cut, bool Profiling, bool Junction, bool Engraving, bool Text, bool Contour, bool Profile)
	{
		for (int i = 0; i <= Job.Items.Count - 1; i++)
		{
			if (Job.Items[i].ShapeGroup == ShapeGroup.Drill && Hole)
			{
				Job.Items[i].Enable = Status;
			}
			if (Job.Items[i].ShapeGroup == ShapeGroup.Shape && Shape)
			{
				Job.Items[i].Enable = Status;
			}
			if (Job.Items[i].ShapeGroup == ShapeGroup.Cut && Cut)
			{
				Job.Items[i].Enable = Status;
			}
			if (Job.Items[i].ShapeGroup == ShapeGroup.Profiling && Profiling)
			{
				Job.Items[i].Enable = Status;
			}
			if (Job.Items[i].ShapeGroup == ShapeGroup.Junction && Junction)
			{
				Job.Items[i].Enable = Status;
			}
			if (Job.Items[i].ShapeGroup == ShapeGroup.Engraving && Engraving)
			{
				Job.Items[i].Enable = Status;
			}
			if (Job.Items[i].ShapeGroup == ShapeGroup.Text && Text)
			{
				Job.Items[i].Enable = Status;
			}
			if (Job.Items[i].ShapeGroup == ShapeGroup.Contour && Contour)
			{
				Job.Items[i].Enable = Status;
			}
			if (Job.Items[i].ShapeGroup == ShapeGroup.Profile && Profiling)
			{
				Job.Items[i].Enable = Status;
			}
		}
	}

	public void EnableDisableOperation(bool Status, ref DrillJob Job, int Index)
	{
		if ((Index >= 0) & (Index <= Job.Items.Count - 1))
		{
			Job.Items[Index].Enable = Status;
		}
	}

	public void FindNextVerticalDrill(List<List<DrillCalcItem>> ItemList, DrillCalcItem refItem, int Index, double RepeatDistance, ref List<DrillCalcItem> foundItems, int MaxToolCount = -1)
	{
		int num = 1;
		foundItems.Clear();
		for (int i = Index; i <= ItemList.Count - 1; i++)
		{
			for (int j = 0; j <= ItemList[i].Count - 1; j++)
			{
				double num2 = ItemList[i][j].Center.X - refItem.Center.X;
				double value = num2 % RepeatDistance;
				if ((ItemList[i][j].Enable & !ItemList[i][j].Calculated) && ((num2 > 0.0) & buCompare5.EQ(value, 0.0, 0.05) & buCompare5.EQ(refItem.Center.Y, ItemList[i][j].Center.Y, 0.05)) && (num < MaxToolCount || MaxToolCount == -1))
				{
					foundItems.Add(new DrillCalcItem(ItemList[i][j]));
					num++;
				}
			}
		}
	}

	public void FindVerticalSameDiameterTools(List<ToolBase5> Tools, double Diameter, planeBoxNames Plane, ref int recommentIndex)
	{
		recommentIndex = 0;
		List<int> list = new List<int>();
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		for (int num = Tools.Count - 1; num >= 0; num--)
		{
			if (((Plane == planeBoxNames.Bottom) & (Tools[num].Geometry.Diameter == Diameter)) && Tools[num].Geometry.ToolDirection.Z == 1.0)
			{
				list.Add(Tools[num].Data.No);
				if (Tools[num].Data.No == 261)
				{
					flag = true;
				}
				if (Tools[num].Data.No == 264)
				{
					flag2 = true;
				}
				if (Tools[num].Data.No == 267)
				{
					flag3 = true;
				}
			}
		}
		if (!((Plane == planeBoxNames.Bottom) & (list.Count > 0)))
		{
			return;
		}
		bool flag4 = false;
		bool flag5 = false;
		bool flag6 = false;
		if (flag)
		{
			flag4 = true;
			for (int i = 0; i <= list.Count - 1; i++)
			{
				if (list[i] == 262)
				{
					flag5 = true;
				}
				if (list[i] == 263)
				{
					flag6 = true;
				}
			}
			if (flag4 && flag5 && flag6)
			{
				recommentIndex = 261;
				return;
			}
		}
		if (flag2)
		{
			flag4 = true;
			for (int j = 0; j <= list.Count - 1; j++)
			{
				if (list[j] == 265)
				{
					flag5 = true;
				}
				if (list[j] == 266)
				{
					flag6 = true;
				}
			}
			if (flag4 && flag5 && flag6)
			{
				recommentIndex = 264;
				return;
			}
		}
		if (!flag3)
		{
			return;
		}
		flag4 = true;
		for (int k = 0; k <= list.Count - 1; k++)
		{
			if (list[k] == 268)
			{
				flag5 = true;
			}
			if (list[k] == 269)
			{
				flag6 = true;
			}
		}
		if (flag4 && flag5 && flag6)
		{
			recommentIndex = 267;
		}
	}

	public bool isMultiZAvailable(List<DrillCalcItem> Items)
	{
		bool result = false;
		if (Items.Count >= 2)
		{
			List<double> list = new List<double>();
			list.Add(Items[0].Center.Z);
			for (int i = 1; i <= Items.Count - 1; i++)
			{
				for (int j = 0; j <= list.Count - 1; j++)
				{
					if (!buCompare5.EQ(list[j], Items[i].Center.Z))
					{
						return true;
					}
				}
			}
		}
		return result;
	}

	public void SplitDrillsByYDistanceThenSortZDir(List<DrillCalcItem> Items, SortDirection SortDir, ref List<List<DrillCalcItem>> SplitedItems)
	{
		List<DrillCalcItem> list = new List<DrillCalcItem>();
		SplitedItems = new List<List<DrillCalcItem>>();
		if (Items.Count <= 0)
		{
			return;
		}
		list.Add(new DrillCalcItem(Items[0]));
		for (int i = 1; i <= Items.Count - 1; i++)
		{
			if (!buCompare5.EQ(list[list.Count - 1].Center.Y, Items[i].Center.Y))
			{
				SplitedItems.Add(list);
				list = new List<DrillCalcItem>();
				list.Add(new DrillCalcItem(Items[i]));
			}
			else
			{
				list.Add(new DrillCalcItem(Items[i]));
			}
		}
		if (list.Count > 0)
		{
			SplitedItems.Add(list);
		}
		for (int j = 0; j <= SplitedItems.Count - 1; j++)
		{
			list = new List<DrillCalcItem>();
			list = SplitedItems[j];
			list = SortByZDistance(list, new DrillCalcItem(), SortDir);
			SplitedItems[j] = list;
		}
	}

	public List<DrillCalcItem> SortByZDistance(List<DrillCalcItem> lst, DrillCalcItem refPoint, SortDirection Direction)
	{
		List<DrillCalcItem> list = new List<DrillCalcItem>();
		if (lst.Count > 0)
		{
			list.Add(lst[NearestZPoint(new DrillCalcItem(refPoint), lst)]);
			lst.Remove(list[0]);
			int num = 0;
			for (int i = 0; i < lst.Count + num; i++)
			{
				list.Add(lst[NearestZPoint(list[list.Count - 1], lst)]);
				lst.Remove(list[list.Count - 1]);
				num++;
			}
			if (Direction == SortDirection.LowerToBigger)
			{
				list.Reverse();
			}
		}
		return list;
	}

	public int NearestZPoint(DrillCalcItem srcPt, List<DrillCalcItem> lookIn)
	{
		KeyValuePair<double, int> keyValuePair = default(KeyValuePair<double, int>);
		for (int i = 0; i < lookIn.Count; i++)
		{
			double num = srcPt.Center.Z - lookIn[i].Center.Z;
			if (i != 0)
			{
				if (num < keyValuePair.Key)
				{
					keyValuePair = new KeyValuePair<double, int>(num, i);
				}
			}
			else
			{
				keyValuePair = new KeyValuePair<double, int>(num, i);
			}
		}
		return keyValuePair.Value;
	}

	public void CoordinateFromPlaneAndCorner(SizeObject Size, CornerLocation Corner, planeBoxNames Plane, ref DrillItemBase Item, Point3D refPoint, double Sing)
	{
		Item.Corner = Corner;
		if (Sing == -1.0)
		{
			if (Plane == planeBoxNames.Top)
			{
				if (Corner == CornerLocation.LeftBottom)
				{
					Item.CornerPoint = new Point3D(Sing * Size.Width, Sing * Size.Height, Size.Depth);
					Item.BaseCenter.X = Size.Width - refPoint.X;
					Item.BaseCenter.Y = Size.Height - refPoint.Y;
					Item.BaseCenter.Z = Size.Depth;
				}
				if (Corner == CornerLocation.LeftTop)
				{
					Item.CornerPoint = new Point3D(Sing * Size.Width, 0.0, Size.Depth);
					Item.BaseCenter.X = Size.Width - refPoint.X;
					Item.BaseCenter.Y = refPoint.Y;
					Item.BaseCenter.Z = Size.Depth;
				}
				if (Corner == CornerLocation.RightBottom)
				{
					Item.CornerPoint = new Point3D(0.0, Sing * Size.Height, Size.Depth);
					Item.BaseCenter.X = refPoint.X;
					Item.BaseCenter.Y = Size.Height - refPoint.Y;
					Item.BaseCenter.Z = Size.Depth;
				}
				if (Corner == CornerLocation.RightTop)
				{
					Item.CornerPoint = new Point3D(0.0, 0.0, Size.Depth);
					Item.BaseCenter.X = refPoint.X;
					Item.BaseCenter.Y = refPoint.Y;
					Item.BaseCenter.Z = Size.Depth;
				}
			}
			if (Plane == planeBoxNames.Bottom)
			{
				if (Corner == CornerLocation.LeftBottom)
				{
					Item.CornerPoint = new Point3D(Sing * Size.Width, Sing * Size.Height, 0.0);
					Item.BaseCenter.X = Size.Width - refPoint.X;
					Item.BaseCenter.Y = Size.Height - refPoint.Y;
					Item.BaseCenter.Z = Size.Depth;
				}
				if (Corner == CornerLocation.LeftTop)
				{
					Item.CornerPoint = new Point3D(Sing * Size.Width, 0.0, 0.0);
					Item.BaseCenter.X = Size.Width - refPoint.X;
					Item.BaseCenter.Y = refPoint.Y;
					Item.BaseCenter.Z = Size.Depth;
				}
				if (Corner == CornerLocation.RightBottom)
				{
					Item.CornerPoint = new Point3D(0.0, Sing * Size.Height, 0.0);
					Item.BaseCenter.X = refPoint.X;
					Item.BaseCenter.Y = Size.Height - refPoint.Y;
					Item.BaseCenter.Z = Size.Depth;
				}
				if (Corner == CornerLocation.RightTop)
				{
					Item.CornerPoint = new Point3D(0.0, 0.0, 0.0);
					Item.BaseCenter.X = refPoint.X;
					Item.BaseCenter.Y = refPoint.Y;
					Item.BaseCenter.Z = Size.Depth;
				}
			}
			if (Plane == planeBoxNames.Front)
			{
				if (Corner == CornerLocation.LeftBottom)
				{
					Item.CornerPoint = new Point3D(0.0, Sing * Size.Height, 0.0);
					Item.BaseCenter.X = 0.0;
					Item.BaseCenter.Y = Size.Height - refPoint.Y;
					Item.BaseCenter.Z = refPoint.Z;
				}
				if (Corner == CornerLocation.LeftTop)
				{
					Item.CornerPoint = new Point3D(0.0, Sing * Size.Height, Size.Depth);
					Item.BaseCenter.X = 0.0;
					Item.BaseCenter.Y = Size.Height - refPoint.Y;
					Item.BaseCenter.Z = Size.Depth - refPoint.Z;
				}
				if (Corner == CornerLocation.RightBottom)
				{
					Item.CornerPoint = new Point3D(0.0, 0.0, 0.0);
					Item.BaseCenter.X = 0.0;
					Item.BaseCenter.Y = refPoint.Y;
					Item.BaseCenter.Z = refPoint.Z;
				}
				if (Corner == CornerLocation.RightTop)
				{
					Item.CornerPoint = new Point3D(0.0, 0.0, Size.Depth);
					Item.BaseCenter.X = 0.0;
					Item.BaseCenter.Y = refPoint.Y;
					Item.BaseCenter.Z = Size.Depth - refPoint.Z;
				}
			}
			if (Plane == planeBoxNames.Back)
			{
				if (Corner == CornerLocation.LeftBottom)
				{
					Item.CornerPoint = new Point3D(Sing * Size.Width, Sing * Size.Height, 0.0);
					Item.BaseCenter.X = Size.Width;
					Item.BaseCenter.Y = Size.Height - refPoint.Y;
					Item.BaseCenter.Z = refPoint.Z;
				}
				if (Corner == CornerLocation.LeftTop)
				{
					Item.CornerPoint = new Point3D(Sing * Size.Width, Sing * Size.Height, Size.Depth);
					Item.BaseCenter.X = Size.Width;
					Item.BaseCenter.Y = Size.Height - refPoint.Y;
					Item.BaseCenter.Z = Size.Depth - refPoint.Z;
				}
				if (Corner == CornerLocation.RightBottom)
				{
					Item.CornerPoint = new Point3D(Sing * Size.Width, 0.0, 0.0);
					Item.BaseCenter.X = Size.Width;
					Item.BaseCenter.Y = refPoint.Y;
					Item.BaseCenter.Z = refPoint.Z;
				}
				if (Corner == CornerLocation.RightTop)
				{
					Item.CornerPoint = new Point3D(Sing * Size.Width, 0.0, Size.Depth);
					Item.BaseCenter.X = Size.Width;
					Item.BaseCenter.Y = refPoint.Y;
					Item.BaseCenter.Z = Size.Depth - refPoint.Z;
				}
			}
			if (Plane == planeBoxNames.Right)
			{
				if (Corner == CornerLocation.LeftBottom)
				{
					Item.CornerPoint = new Point3D(Sing * Size.Width, Sing * Size.Height, 0.0);
					Item.BaseCenter.X = Size.Width - refPoint.X;
					Item.BaseCenter.Y = Size.Height;
					Item.BaseCenter.Z = refPoint.Z;
				}
				if (Corner == CornerLocation.LeftTop)
				{
					Item.CornerPoint = new Point3D(Sing * Size.Width, Sing * Size.Height, Size.Depth);
					Item.BaseCenter.X = Size.Width - refPoint.X;
					Item.BaseCenter.Y = Size.Height;
					Item.BaseCenter.Z = Size.Depth - refPoint.Z;
				}
				if (Corner == CornerLocation.RightBottom)
				{
					Item.CornerPoint = new Point3D(0.0, Sing * Size.Height, 0.0);
					Item.BaseCenter.X = refPoint.X;
					Item.BaseCenter.Y = Size.Height;
					Item.BaseCenter.Z = refPoint.Z;
				}
				if (Corner == CornerLocation.RightTop)
				{
					Item.CornerPoint = new Point3D(0.0, Sing * Size.Height, Size.Depth);
					Item.BaseCenter.X = refPoint.X;
					Item.BaseCenter.Y = Size.Height;
					Item.BaseCenter.Z = Size.Depth - refPoint.Z;
				}
			}
			if (Plane == planeBoxNames.Left)
			{
				if (Corner == CornerLocation.LeftBottom)
				{
					Item.CornerPoint = new Point3D(Sing * Size.Width, 0.0, 0.0);
					Item.BaseCenter.X = Size.Width - refPoint.X;
					Item.BaseCenter.Y = 0.0;
					Item.BaseCenter.Z = refPoint.Z;
				}
				if (Corner == CornerLocation.LeftTop)
				{
					Item.CornerPoint = new Point3D(Sing * Size.Width, 0.0, Size.Depth);
					Item.BaseCenter.X = Size.Width - refPoint.X;
					Item.BaseCenter.Y = 0.0;
					Item.BaseCenter.Z = Size.Depth - refPoint.Z;
				}
				if (Corner == CornerLocation.RightBottom)
				{
					Item.CornerPoint = new Point3D(0.0, 0.0, 0.0);
					Item.BaseCenter.X = refPoint.X;
					Item.BaseCenter.Y = 0.0;
					Item.BaseCenter.Z = refPoint.Z;
				}
				if (Corner == CornerLocation.RightTop)
				{
					Item.CornerPoint = new Point3D(0.0, 0.0, Size.Depth);
					Item.BaseCenter.X = refPoint.X;
					Item.BaseCenter.Y = 0.0;
					Item.BaseCenter.Z = Size.Depth - refPoint.Z;
				}
			}
		}
		GetDirectionVectorFromCornerAndPlane(ref Item);
	}

	public void CoordinateFromPlaneAndCorner(SizeObject Size, CornerLocation Corner, planeBoxNames Plane, ref DrillItem Item, Point3D refPoint, double Sing)
	{
		Item.Corner = Corner;
		if (Sing == -1.0)
		{
			if (Plane == planeBoxNames.Top)
			{
				if (Corner == CornerLocation.LeftBottom)
				{
					Item.CornerPoint = new Point3D(Sing * Size.Width, Sing * Size.Height, Size.Depth);
					Item.Center.X = Size.Width - refPoint.X;
					Item.Center.Y = Size.Height - refPoint.Y;
					Item.Center.Z = Size.Depth;
				}
				if (Corner == CornerLocation.LeftTop)
				{
					Item.CornerPoint = new Point3D(Sing * Size.Width, 0.0, Size.Depth);
					Item.Center.X = Size.Width - refPoint.X;
					Item.Center.Y = refPoint.Y;
					Item.Center.Z = Size.Depth;
				}
				if (Corner == CornerLocation.RightBottom)
				{
					Item.CornerPoint = new Point3D(0.0, Sing * Size.Height, Size.Depth);
					Item.Center.X = refPoint.X;
					Item.Center.Y = Size.Height - refPoint.Y;
					Item.Center.Z = Size.Depth;
				}
				if (Corner == CornerLocation.RightTop)
				{
					Item.CornerPoint = new Point3D(0.0, 0.0, Size.Depth);
					Item.Center.X = refPoint.X;
					Item.Center.Y = refPoint.Y;
					Item.Center.Z = Size.Depth;
				}
			}
			if (Plane == planeBoxNames.Bottom)
			{
				if (Corner == CornerLocation.LeftBottom)
				{
					Item.CornerPoint = new Point3D(Sing * Size.Width, Sing * Size.Height, 0.0);
					Item.Center.X = Size.Width - refPoint.X;
					Item.Center.Y = Size.Height - refPoint.Y;
					Item.Center.Z = Size.Depth;
				}
				if (Corner == CornerLocation.LeftTop)
				{
					Item.CornerPoint = new Point3D(Sing * Size.Width, 0.0, 0.0);
					Item.Center.X = Size.Width - refPoint.X;
					Item.Center.Y = refPoint.Y;
					Item.Center.Z = Size.Depth;
				}
				if (Corner == CornerLocation.RightBottom)
				{
					Item.CornerPoint = new Point3D(0.0, Sing * Size.Height, 0.0);
					Item.Center.X = refPoint.X;
					Item.Center.Y = Size.Height - refPoint.Y;
					Item.Center.Z = Size.Depth;
				}
				if (Corner == CornerLocation.RightTop)
				{
					Item.CornerPoint = new Point3D(0.0, 0.0, 0.0);
					Item.Center.X = refPoint.X;
					Item.Center.Y = refPoint.Y;
					Item.Center.Z = Size.Depth;
				}
			}
			if (Plane == planeBoxNames.Front)
			{
				if (Corner == CornerLocation.LeftBottom)
				{
					Item.CornerPoint = new Point3D(0.0, Sing * Size.Height, 0.0);
					Item.Center.X = 0.0;
					Item.Center.Y = Size.Height - refPoint.Y;
					Item.Center.Z = refPoint.Z;
				}
				if (Corner == CornerLocation.LeftTop)
				{
					Item.CornerPoint = new Point3D(0.0, Sing * Size.Height, Size.Depth);
					Item.Center.X = 0.0;
					Item.Center.Y = Size.Height - refPoint.Y;
					Item.Center.Z = Size.Depth - refPoint.Z;
				}
				if (Corner == CornerLocation.RightBottom)
				{
					Item.CornerPoint = new Point3D(0.0, 0.0, 0.0);
					Item.Center.X = 0.0;
					Item.Center.Y = refPoint.Y;
					Item.Center.Z = refPoint.Z;
				}
				if (Corner == CornerLocation.RightTop)
				{
					Item.CornerPoint = new Point3D(0.0, 0.0, Size.Depth);
					Item.Center.X = 0.0;
					Item.Center.Y = refPoint.Y;
					Item.Center.Z = Size.Depth - refPoint.Z;
				}
			}
			if (Plane == planeBoxNames.Back)
			{
				if (Corner == CornerLocation.LeftBottom)
				{
					Item.CornerPoint = new Point3D(Sing * Size.Width, Sing * Size.Height, 0.0);
					Item.Center.X = Size.Width;
					Item.Center.Y = Size.Height - refPoint.Y;
					Item.Center.Z = refPoint.Z;
				}
				if (Corner == CornerLocation.LeftTop)
				{
					Item.CornerPoint = new Point3D(Sing * Size.Width, Sing * Size.Height, Size.Depth);
					Item.Center.X = Size.Width;
					Item.Center.Y = Size.Height - refPoint.Y;
					Item.Center.Z = Size.Depth - refPoint.Z;
				}
				if (Corner == CornerLocation.RightBottom)
				{
					Item.CornerPoint = new Point3D(Sing * Size.Width, 0.0, 0.0);
					Item.Center.X = Size.Width;
					Item.Center.Y = refPoint.Y;
					Item.Center.Z = refPoint.Z;
				}
				if (Corner == CornerLocation.RightTop)
				{
					Item.CornerPoint = new Point3D(Sing * Size.Width, 0.0, Size.Depth);
					Item.Center.X = Size.Width;
					Item.Center.Y = refPoint.Y;
					Item.Center.Z = Size.Depth - refPoint.Z;
				}
			}
			if (Plane == planeBoxNames.Right)
			{
				if (Corner == CornerLocation.LeftBottom)
				{
					Item.CornerPoint = new Point3D(Sing * Size.Width, Sing * Size.Height, 0.0);
					Item.Center.X = Size.Width - refPoint.X;
					Item.Center.Y = Size.Height;
					Item.Center.Z = refPoint.Z;
				}
				if (Corner == CornerLocation.LeftTop)
				{
					Item.CornerPoint = new Point3D(Sing * Size.Width, Sing * Size.Height, Size.Depth);
					Item.Center.X = Size.Width - refPoint.X;
					Item.Center.Y = Size.Height;
					Item.Center.Z = Size.Depth - refPoint.Z;
				}
				if (Corner == CornerLocation.RightBottom)
				{
					Item.CornerPoint = new Point3D(0.0, Sing * Size.Height, 0.0);
					Item.Center.X = refPoint.X;
					Item.Center.Y = Size.Height;
					Item.Center.Z = refPoint.Z;
				}
				if (Corner == CornerLocation.RightTop)
				{
					Item.CornerPoint = new Point3D(0.0, Sing * Size.Height, Size.Depth);
					Item.Center.X = refPoint.X;
					Item.Center.Y = Size.Height;
					Item.Center.Z = Size.Depth - refPoint.Z;
				}
			}
			if (Plane == planeBoxNames.Left)
			{
				if (Corner == CornerLocation.LeftBottom)
				{
					Item.CornerPoint = new Point3D(Sing * Size.Width, 0.0, 0.0);
					Item.Center.X = Size.Width - refPoint.X;
					Item.Center.Y = 0.0;
					Item.Center.Z = refPoint.Z;
				}
				if (Corner == CornerLocation.LeftTop)
				{
					Item.CornerPoint = new Point3D(Sing * Size.Width, 0.0, Size.Depth);
					Item.Center.X = Size.Width - refPoint.X;
					Item.Center.Y = 0.0;
					Item.Center.Z = Size.Depth - refPoint.Z;
				}
				if (Corner == CornerLocation.RightBottom)
				{
					Item.CornerPoint = new Point3D(0.0, 0.0, 0.0);
					Item.Center.X = refPoint.X;
					Item.Center.Y = 0.0;
					Item.Center.Z = refPoint.Z;
				}
				if (Corner == CornerLocation.RightTop)
				{
					Item.CornerPoint = new Point3D(0.0, 0.0, Size.Depth);
					Item.Center.X = refPoint.X;
					Item.Center.Y = 0.0;
					Item.Center.Z = Size.Depth - refPoint.Z;
				}
			}
		}
		GetDirectionVectorFromCornerAndPlane(ref Item);
	}

	public void GetDirectionVectorFromCornerAndPlane(ref DrillItem Item)
	{
		if (Item.planeName == planeBoxNames.Top)
		{
			if (Item.Corner == CornerLocation.LeftBottom)
			{
				Item.CornerDirection = new Vector3D(1.0, 1.0, 1.0);
			}
			if (Item.Corner == CornerLocation.LeftTop)
			{
				Item.CornerDirection = new Vector3D(1.0, -1.0, 1.0);
			}
			if (Item.Corner == CornerLocation.RightBottom)
			{
				Item.CornerDirection = new Vector3D(-1.0, 1.0, 1.0);
			}
			if (Item.Corner == CornerLocation.RightTop)
			{
				Item.CornerDirection = new Vector3D(-1.0, -1.0, 1.0);
			}
			if (Item.Corner == CornerLocation.LeftCenter)
			{
				Item.CornerDirection = new Vector3D(1.0, 0.0, 1.0);
			}
			if (Item.Corner == CornerLocation.RightCenter)
			{
				Item.CornerDirection = new Vector3D(-1.0, 0.0, 1.0);
			}
			if (Item.Corner == CornerLocation.TopCenter)
			{
				Item.CornerDirection = new Vector3D(0.0, -1.0, 1.0);
			}
			if (Item.Corner == CornerLocation.BottomCenter)
			{
				Item.CornerDirection = new Vector3D(0.0, 1.0, 1.0);
			}
		}
		if (Item.planeName == planeBoxNames.Bottom)
		{
			if (Item.Corner == CornerLocation.LeftBottom)
			{
				Item.CornerDirection = new Vector3D(1.0, 1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.LeftTop)
			{
				Item.CornerDirection = new Vector3D(1.0, -1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.RightBottom)
			{
				Item.CornerDirection = new Vector3D(-1.0, 1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.RightTop)
			{
				Item.CornerDirection = new Vector3D(-1.0, -1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.LeftCenter)
			{
				Item.CornerDirection = new Vector3D(1.0, 0.0, -1.0);
			}
			if (Item.Corner == CornerLocation.RightCenter)
			{
				Item.CornerDirection = new Vector3D(-1.0, 0.0, -1.0);
			}
			if (Item.Corner == CornerLocation.TopCenter)
			{
				Item.CornerDirection = new Vector3D(0.0, -1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.BottomCenter)
			{
				Item.CornerDirection = new Vector3D(0.0, 1.0, -1.0);
			}
		}
		if (Item.planeName == planeBoxNames.Front)
		{
			if (Item.Corner == CornerLocation.LeftBottom)
			{
				Item.CornerDirection = new Vector3D(1.0, 1.0, 1.0);
			}
			if (Item.Corner == CornerLocation.LeftTop)
			{
				Item.CornerDirection = new Vector3D(1.0, 1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.RightBottom)
			{
				Item.CornerDirection = new Vector3D(1.0, -1.0, 1.0);
			}
			if (Item.Corner == CornerLocation.RightTop)
			{
				Item.CornerDirection = new Vector3D(1.0, -1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.LeftCenter)
			{
				Item.CornerDirection = new Vector3D(1.0, 1.0, 0.0);
			}
			if (Item.Corner == CornerLocation.RightCenter)
			{
				Item.CornerDirection = new Vector3D(1.0, -1.0, 0.0);
			}
			if (Item.Corner == CornerLocation.TopCenter)
			{
				Item.CornerDirection = new Vector3D(1.0, 0.0, -1.0);
			}
			if (Item.Corner == CornerLocation.BottomCenter)
			{
				Item.CornerDirection = new Vector3D(1.0, 0.0, 1.0);
			}
		}
		if (Item.planeName == planeBoxNames.Back)
		{
			if (Item.Corner == CornerLocation.LeftBottom)
			{
				Item.CornerDirection = new Vector3D(-1.0, 1.0, 1.0);
			}
			if (Item.Corner == CornerLocation.LeftTop)
			{
				Item.CornerDirection = new Vector3D(-1.0, 1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.RightBottom)
			{
				Item.CornerDirection = new Vector3D(-1.0, -1.0, 1.0);
			}
			if (Item.Corner == CornerLocation.RightTop)
			{
				Item.CornerDirection = new Vector3D(-1.0, -1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.LeftCenter)
			{
				Item.CornerDirection = new Vector3D(-1.0, 1.0, 0.0);
			}
			if (Item.Corner == CornerLocation.RightCenter)
			{
				Item.CornerDirection = new Vector3D(-1.0, -1.0, 0.0);
			}
			if (Item.Corner == CornerLocation.TopCenter)
			{
				Item.CornerDirection = new Vector3D(-1.0, 0.0, -1.0);
			}
			if (Item.Corner == CornerLocation.BottomCenter)
			{
				Item.CornerDirection = new Vector3D(-1.0, 0.0, 1.0);
			}
		}
		if (Item.planeName == planeBoxNames.Right)
		{
			if (Item.Corner == CornerLocation.LeftBottom)
			{
				Item.CornerDirection = new Vector3D(1.0, -1.0, 1.0);
			}
			if (Item.Corner == CornerLocation.LeftTop)
			{
				Item.CornerDirection = new Vector3D(1.0, -1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.RightBottom)
			{
				Item.CornerDirection = new Vector3D(-1.0, -1.0, 1.0);
			}
			if (Item.Corner == CornerLocation.RightTop)
			{
				Item.CornerDirection = new Vector3D(-1.0, -1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.LeftCenter)
			{
				Item.CornerDirection = new Vector3D(1.0, -1.0, 0.0);
			}
			if (Item.Corner == CornerLocation.RightCenter)
			{
				Item.CornerDirection = new Vector3D(-1.0, -1.0, 0.0);
			}
			if (Item.Corner == CornerLocation.TopCenter)
			{
				Item.CornerDirection = new Vector3D(1.0, -1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.BottomCenter)
			{
				Item.CornerDirection = new Vector3D(-1.0, -1.0, 1.0);
			}
		}
		if (Item.planeName == planeBoxNames.Left)
		{
			if (Item.Corner == CornerLocation.LeftBottom)
			{
				Item.CornerDirection = new Vector3D(1.0, 1.0, 1.0);
			}
			if (Item.Corner == CornerLocation.LeftTop)
			{
				Item.CornerDirection = new Vector3D(1.0, 1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.RightBottom)
			{
				Item.CornerDirection = new Vector3D(-1.0, 1.0, 1.0);
			}
			if (Item.Corner == CornerLocation.RightTop)
			{
				Item.CornerDirection = new Vector3D(-1.0, 1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.LeftCenter)
			{
				Item.CornerDirection = new Vector3D(1.0, 1.0, 0.0);
			}
			if (Item.Corner == CornerLocation.RightCenter)
			{
				Item.CornerDirection = new Vector3D(-1.0, 1.0, 0.0);
			}
			if (Item.Corner == CornerLocation.TopCenter)
			{
				Item.CornerDirection = new Vector3D(1.0, 1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.BottomCenter)
			{
				Item.CornerDirection = new Vector3D(-1.0, 1.0, 1.0);
			}
		}
	}

	public void GetDirectionVectorFromCornerAndPlane(ref DrillItemBase Item)
	{
		if (Item.planeName == planeBoxNames.Top)
		{
			if (Item.Corner == CornerLocation.LeftBottom)
			{
				Item.CornerDirection = new Vector3D(1.0, 1.0, 1.0);
			}
			if (Item.Corner == CornerLocation.LeftTop)
			{
				Item.CornerDirection = new Vector3D(1.0, -1.0, 1.0);
			}
			if (Item.Corner == CornerLocation.RightBottom)
			{
				Item.CornerDirection = new Vector3D(-1.0, 1.0, 1.0);
			}
			if (Item.Corner == CornerLocation.RightTop)
			{
				Item.CornerDirection = new Vector3D(-1.0, -1.0, 1.0);
			}
			if (Item.Corner == CornerLocation.LeftCenter)
			{
				Item.CornerDirection = new Vector3D(1.0, 0.0, 1.0);
			}
			if (Item.Corner == CornerLocation.RightCenter)
			{
				Item.CornerDirection = new Vector3D(-1.0, 0.0, 1.0);
			}
			if (Item.Corner == CornerLocation.TopCenter)
			{
				Item.CornerDirection = new Vector3D(0.0, -1.0, 1.0);
			}
			if (Item.Corner == CornerLocation.BottomCenter)
			{
				Item.CornerDirection = new Vector3D(0.0, 1.0, 1.0);
			}
		}
		if (Item.planeName == planeBoxNames.Bottom)
		{
			if (Item.Corner == CornerLocation.LeftBottom)
			{
				Item.CornerDirection = new Vector3D(1.0, 1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.LeftTop)
			{
				Item.CornerDirection = new Vector3D(1.0, -1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.RightBottom)
			{
				Item.CornerDirection = new Vector3D(-1.0, 1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.RightTop)
			{
				Item.CornerDirection = new Vector3D(-1.0, -1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.LeftCenter)
			{
				Item.CornerDirection = new Vector3D(1.0, 0.0, -1.0);
			}
			if (Item.Corner == CornerLocation.RightCenter)
			{
				Item.CornerDirection = new Vector3D(-1.0, 0.0, -1.0);
			}
			if (Item.Corner == CornerLocation.TopCenter)
			{
				Item.CornerDirection = new Vector3D(0.0, -1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.BottomCenter)
			{
				Item.CornerDirection = new Vector3D(0.0, 1.0, -1.0);
			}
		}
		if (Item.planeName == planeBoxNames.Front)
		{
			if (Item.Corner == CornerLocation.LeftBottom)
			{
				Item.CornerDirection = new Vector3D(1.0, 1.0, 1.0);
			}
			if (Item.Corner == CornerLocation.LeftTop)
			{
				Item.CornerDirection = new Vector3D(1.0, 1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.RightBottom)
			{
				Item.CornerDirection = new Vector3D(1.0, -1.0, 1.0);
			}
			if (Item.Corner == CornerLocation.RightTop)
			{
				Item.CornerDirection = new Vector3D(1.0, -1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.LeftCenter)
			{
				Item.CornerDirection = new Vector3D(1.0, 1.0, 0.0);
			}
			if (Item.Corner == CornerLocation.RightCenter)
			{
				Item.CornerDirection = new Vector3D(1.0, -1.0, 0.0);
			}
			if (Item.Corner == CornerLocation.TopCenter)
			{
				Item.CornerDirection = new Vector3D(1.0, 0.0, -1.0);
			}
			if (Item.Corner == CornerLocation.BottomCenter)
			{
				Item.CornerDirection = new Vector3D(1.0, 0.0, 1.0);
			}
		}
		if (Item.planeName == planeBoxNames.Back)
		{
			if (Item.Corner == CornerLocation.LeftBottom)
			{
				Item.CornerDirection = new Vector3D(-1.0, 1.0, 1.0);
			}
			if (Item.Corner == CornerLocation.LeftTop)
			{
				Item.CornerDirection = new Vector3D(-1.0, 1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.RightBottom)
			{
				Item.CornerDirection = new Vector3D(-1.0, -1.0, 1.0);
			}
			if (Item.Corner == CornerLocation.RightTop)
			{
				Item.CornerDirection = new Vector3D(-1.0, -1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.LeftCenter)
			{
				Item.CornerDirection = new Vector3D(-1.0, 1.0, 0.0);
			}
			if (Item.Corner == CornerLocation.RightCenter)
			{
				Item.CornerDirection = new Vector3D(-1.0, -1.0, 0.0);
			}
			if (Item.Corner == CornerLocation.TopCenter)
			{
				Item.CornerDirection = new Vector3D(-1.0, 0.0, -1.0);
			}
			if (Item.Corner == CornerLocation.BottomCenter)
			{
				Item.CornerDirection = new Vector3D(-1.0, 0.0, 1.0);
			}
		}
		if (Item.planeName == planeBoxNames.Right)
		{
			if (Item.Corner == CornerLocation.LeftBottom)
			{
				Item.CornerDirection = new Vector3D(1.0, -1.0, 1.0);
			}
			if (Item.Corner == CornerLocation.LeftTop)
			{
				Item.CornerDirection = new Vector3D(1.0, -1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.RightBottom)
			{
				Item.CornerDirection = new Vector3D(-1.0, -1.0, 1.0);
			}
			if (Item.Corner == CornerLocation.RightTop)
			{
				Item.CornerDirection = new Vector3D(-1.0, -1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.LeftCenter)
			{
				Item.CornerDirection = new Vector3D(1.0, -1.0, 0.0);
			}
			if (Item.Corner == CornerLocation.RightCenter)
			{
				Item.CornerDirection = new Vector3D(-1.0, -1.0, 0.0);
			}
			if (Item.Corner == CornerLocation.TopCenter)
			{
				Item.CornerDirection = new Vector3D(1.0, -1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.BottomCenter)
			{
				Item.CornerDirection = new Vector3D(-1.0, -1.0, 1.0);
			}
		}
		if (Item.planeName == planeBoxNames.Left)
		{
			if (Item.Corner == CornerLocation.LeftBottom)
			{
				Item.CornerDirection = new Vector3D(1.0, 1.0, 1.0);
			}
			if (Item.Corner == CornerLocation.LeftTop)
			{
				Item.CornerDirection = new Vector3D(1.0, 1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.RightBottom)
			{
				Item.CornerDirection = new Vector3D(-1.0, 1.0, 1.0);
			}
			if (Item.Corner == CornerLocation.RightTop)
			{
				Item.CornerDirection = new Vector3D(-1.0, 1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.LeftCenter)
			{
				Item.CornerDirection = new Vector3D(1.0, 1.0, 0.0);
			}
			if (Item.Corner == CornerLocation.RightCenter)
			{
				Item.CornerDirection = new Vector3D(-1.0, 1.0, 0.0);
			}
			if (Item.Corner == CornerLocation.TopCenter)
			{
				Item.CornerDirection = new Vector3D(1.0, 1.0, -1.0);
			}
			if (Item.Corner == CornerLocation.BottomCenter)
			{
				Item.CornerDirection = new Vector3D(-1.0, 1.0, 1.0);
			}
		}
	}

	public void CreateContourItemOfPanel(ref DrillItem Item, DrillJob Job)
	{
		Item = new DrillItem();
		new Point3D();
		Item.ShapeData.Depth = 0.0;
		Item.ShapeData.Width = Job.Material.Size.Width;
		Item.ShapeData.Height = Job.Material.Size.Height;
		Item.Type = DrillItemType.Contouring;
		Item.ShapeType = ShapeTypes.Rectangle;
		Item.isCenter = false;
		Item.isPocket = false;
		Item.shapeEntitites.Clear();
		if (Item.isCenter)
		{
		}
		if ((Item.ShapeData.Width > 0.0) & (Item.ShapeData.Height > 0.0))
		{
			double num = -1.0;
			CompositeCurve compositeCurve = CompositeCurve.CreateRectangle(Plane.XY, 0.0 - Item.ShapeData.Width, 0.0 - Item.ShapeData.Height);
			compositeCurve.Translate(num * Item.Center.X, num * Item.Center.Y, Item.Center.Z);
			List<buEntity> list = new List<buEntity>();
			list.Add(buEntity.Copy(compositeCurve));
			Item.shapeEntitites.Add(list);
		}
	}

	public void CreateEntitiesOfItem(DrillItemBase ItemBase, ref DrillItem Item, double Sing = -1.0)
	{
		if (!((Item.Type == DrillItemType.Slot) | (Item.Type == DrillItemType.SlotByMilling)))
		{
			return;
		}
		if (ItemBase.Command != drillCommands.CutHorizontal)
		{
			if (ItemBase.Command != drillCommands.CutVertical)
			{
				Point3D EndPnt = new Point3D();
				buCall.buVector5_0.LineWithLengthAndAngle(new Point3D(Sing * Item.Center.X, Sing * Item.Center.Y, Item.Center.Z), Item.ShapeData.Length, Item.ShapeData.Angle, ref EndPnt);
				buLine item = new buLine(new Point3D(Sing * Item.Center.X, Sing * Item.Center.Y, Item.Center.Z), EndPnt);
				List<buEntity> list = new List<buEntity>();
				list.Add(item);
				Item.shapeEntitites.Add(list);
			}
			else
			{
				buLine item2 = new buLine(new Point3D(Sing * Item.Center.X, Sing * Item.Center.Y, Item.Center.Z), new Point3D(Sing * Item.Center.X, Sing * Item.Center.Y + Sing * Item.ShapeData.Length, Item.Center.Z));
				List<buEntity> list2 = new List<buEntity>();
				list2.Add(item2);
				Item.shapeEntitites.Add(list2);
			}
		}
		else
		{
			buLine item3 = new buLine(new Point3D(Sing * Item.Center.X, Sing * Item.Center.Y, Item.Center.Z), new Point3D(Sing * Item.Center.X + Sing * Item.ShapeData.Length, Sing * Item.Center.Y, Item.Center.Z));
			List<buEntity> list3 = new List<buEntity>();
			list3.Add(item3);
			Item.shapeEntitites.Add(list3);
		}
	}

	public void DrillItemToEntity(DrillItemBase Item, SizeObject Size, ref List<List<buEntity>> Entities)
	{
		List<List<Entity>> Entities2 = new List<List<Entity>>();
		DrillItemToEntity(Item, Size, ref Entities2);
		Entities = new List<List<buEntity>>();
		buEntity.Copy(Entities2, ref Entities);
	}

	public void DrillItemToEntity(DrillItemBase Item, SizeObject Size, ref List<List<Entity>> Entities)
	{
		Entities = new List<List<Entity>>();
		List<Entity> Entities2 = new List<Entity>();
		DrillItemToEntity(Item, Size, ref Entities2);
		Entities.Add(Entities2);
	}

	public void DrillItemToEntity(DrillItemBase Item, SizeObject Size, ref List<buEntity> Entities)
	{
		List<Entity> Entities2 = new List<Entity>();
		DrillItemToEntity(Item, Size, ref Entities2);
		Entities = new List<buEntity>();
		buEntity.Copy(Entities2, ref Entities);
	}

	public void DrillItemToEntity(DrillItemBase Item, SizeObject Size, ref List<Entity> Entities)
	{
		for (int i = 0; i <= Item.Items.Count - 1; i++)
		{
			for (int j = 0; j <= Item.Items[i].shapeEntitites.Count - 1; j++)
			{
				for (int k = 0; k <= Item.Items[i].shapeEntitites[j].Count - 1; k++)
				{
					Entity copiedEntity = null;
					buEntity.Copy(Item.Items[i].shapeEntitites[j][k], ref copiedEntity);
					Entities.Add(copiedEntity);
				}
			}
		}
	}

	public void DrillItemToEntity1(DrillItemBase Item, SizeObject Size, ref List<Entity> Entities)
	{
		Entities.Clear();
	}

	public bool DuplicateHolesFromItem(drillCommands Command, DrillRuntimeSettings Settings, DrillItem refDrill, ref DrillItemBase refItem, DrillJob Job, ref double CalcValue)
	{
		bool result = false;
		if (Command == drillCommands.HorizontalHoles || Command == drillCommands.HorizontalLineHoles)
		{
			int num = Settings.HorizontalCount;
			double num2 = Settings.HorizontalDistance;
			if (Command == drillCommands.HorizontalLineHoles && refItem.HorizontalDistance > 0.0)
			{
				double num3 = Job.Material.Size.Width - refItem.StartDistance - refItem.EndDistance;
				if ((Settings.lastDrillPlaneNames == planeBoxNames.Front) | (Settings.lastDrillPlaneNames == planeBoxNames.Back))
				{
					num3 = Job.Material.Size.Height - refItem.StartDistance - refItem.EndDistance;
				}
				if (num3 > 0.0)
				{
					double value = num3 / refItem.HorizontalDistance;
					num = Convert.ToInt32(value);
					num2 = num3 / (double)num;
					num++;
					if (!buCompare5.EQ(num2, refItem.HorizontalDistance, 0.01))
					{
						CalcValue = num2;
						result = true;
					}
				}
			}
			if ((refItem.planeName == planeBoxNames.Top) | (refItem.planeName == planeBoxNames.Bottom) | (refItem.planeName == planeBoxNames.Left) | (refItem.planeName == planeBoxNames.Right))
			{
				double num4 = 1.0;
				if (((refItem.planeName == planeBoxNames.Top) | (refItem.planeName == planeBoxNames.Bottom) | (refItem.planeName == planeBoxNames.Right)) && ((refItem.Corner == CornerLocation.LeftTop) | (refItem.Corner == CornerLocation.LeftBottom)))
				{
					num4 = -1.0;
				}
				if (refItem.planeName == planeBoxNames.Left && ((refItem.Corner == CornerLocation.LeftBottom) | (refItem.Corner == CornerLocation.LeftTop)))
				{
					num4 = -1.0;
				}
				for (int i = 0; i <= num - 1; i++)
				{
					DrillItem drillItem = new DrillItem(refDrill);
					drillItem.Center.X = drillItem.Center.X + num4 * num2 * (double)i;
					refItem.Items.Add(drillItem);
				}
			}
			if ((refItem.planeName == planeBoxNames.Front) | (refItem.planeName == planeBoxNames.Back))
			{
				double num5 = 1.0;
				if (refItem.planeName == planeBoxNames.Front && ((refItem.Corner == CornerLocation.LeftTop) | (refItem.Corner == CornerLocation.LeftBottom)))
				{
					num5 = -1.0;
				}
				if (refItem.planeName == planeBoxNames.Back && ((refItem.Corner == CornerLocation.LeftTop) | (refItem.Corner == CornerLocation.LeftBottom)))
				{
					num5 = -1.0;
				}
				for (int j = 0; j <= num - 1; j++)
				{
					DrillItem drillItem2 = new DrillItem(refDrill);
					drillItem2.Center.Y = drillItem2.Center.Y + num5 * num2 * (double)j;
					refItem.Items.Add(drillItem2);
				}
			}
			refItem.HorizontalCount = num;
			refItem.HorizontalDistance = num2;
		}
		if (Command == drillCommands.VerticalHoles || Command == drillCommands.VerticalLineHoles)
		{
			int num6 = Settings.VerticalCount;
			double num7 = Settings.VerticalDistance;
			if (Command == drillCommands.VerticalLineHoles && refItem.VerticalDistance > 0.0)
			{
				double num8 = Job.Material.Size.Depth - refItem.StartDistance - refItem.EndDistance;
				if ((Settings.lastDrillPlaneNames == planeBoxNames.Top) | (Settings.lastDrillPlaneNames == planeBoxNames.Bottom))
				{
					num8 = Job.Material.Size.Height - refItem.StartDistance - refItem.EndDistance;
				}
				if (num8 > 0.0)
				{
					double value2 = num8 / refItem.VerticalDistance;
					num6 = Convert.ToInt32(value2);
					num7 = num8 / (double)num6;
					num6++;
					if (!buCompare5.EQ(num7, refItem.VerticalDistance, 0.01))
					{
						CalcValue = num7;
						result = true;
					}
				}
			}
			if ((refItem.planeName == planeBoxNames.Top) | (refItem.planeName == planeBoxNames.Bottom))
			{
				double num9 = 1.0;
				if (((refItem.planeName == planeBoxNames.Top) | (refItem.planeName == planeBoxNames.Right)) && ((refItem.Corner == CornerLocation.LeftBottom) | (refItem.Corner == CornerLocation.RightBottom)))
				{
					num9 = -1.0;
				}
				if (refItem.planeName == planeBoxNames.Bottom && ((refItem.Corner == CornerLocation.LeftTop) | (refItem.Corner == CornerLocation.RightTop)))
				{
					num9 = -1.0;
				}
				if (refItem.planeName == planeBoxNames.Left && ((refItem.Corner == CornerLocation.RightBottom) | (refItem.Corner == CornerLocation.RightTop)))
				{
					num9 = -1.0;
				}
				for (int k = 0; k <= num6 - 1; k++)
				{
					DrillItem drillItem3 = new DrillItem(refDrill);
					drillItem3.Center.Y = drillItem3.Center.Y + num9 * num7 * (double)k;
					refItem.Items.Add(drillItem3);
				}
			}
			if ((refItem.planeName == planeBoxNames.Right) | (refItem.planeName == planeBoxNames.Left) | (refItem.planeName == planeBoxNames.Front) | (refItem.planeName == planeBoxNames.Back))
			{
				double num10 = 1.0;
				if (((refItem.planeName == planeBoxNames.Right) | (refItem.planeName == planeBoxNames.Left) | (refItem.planeName == planeBoxNames.Front) | (refItem.planeName == planeBoxNames.Back)) && ((refItem.Corner == CornerLocation.LeftTop) | (refItem.Corner == CornerLocation.RightTop)))
				{
					num10 = -1.0;
				}
				for (int l = 0; l <= num6 - 1; l++)
				{
					DrillItem drillItem4 = new DrillItem(refDrill);
					drillItem4.Center.Z = drillItem4.Center.Z + num10 * num7 * (double)l;
					refItem.Items.Add(drillItem4);
				}
			}
		}
		return result;
	}

	public void SimPointMoveCalculate(DrillMove PreMove, DrillMove CurrentMove, double devideLen, ref List<DrillMove> calcSimMoves)
	{
		double num = Math.Abs(CurrentMove.XPosition - PreMove.XPosition);
		double num2 = Math.Abs(CurrentMove.Y1Position - PreMove.Y1Position);
		double num3 = Math.Abs(CurrentMove.Y2Position - PreMove.Y2Position);
		double num4 = Math.Abs(CurrentMove.Y3Position - PreMove.Y3Position);
		double num5 = Math.Abs(CurrentMove.Z1Position - PreMove.Z1Position);
		double num6 = Math.Abs(CurrentMove.Z2Position - PreMove.Z2Position);
		double num7 = Math.Abs(CurrentMove.Z3Position - PreMove.Z3Position);
		double num8 = double.MinValue;
		if (CurrentMove.Y1Position == 100000.0)
		{
			num2 = 0.0;
		}
		if (CurrentMove.Y2Position == 100000.0)
		{
			num3 = 0.0;
		}
		if (CurrentMove.Y3Position == 100000.0)
		{
			num4 = 0.0;
		}
		if (CurrentMove.Z1Position == 100000.0)
		{
			num5 = 0.0;
		}
		if (CurrentMove.Z2Position == 100000.0)
		{
			num6 = 0.0;
		}
		if (CurrentMove.Z3Position == 100000.0)
		{
			num7 = 0.0;
		}
		if (!(devideLen <= 0.0))
		{
			if (num > num8)
			{
				num8 = num;
			}
			if (num2 > num8)
			{
				num8 = num2;
			}
			if (num3 > num8)
			{
				num8 = num3;
			}
			if (num4 > num8)
			{
				num8 = num4;
			}
			if (num5 > num8)
			{
				num8 = num5;
			}
			if (num6 > num8)
			{
				num8 = num6;
			}
			if (num7 > num8)
			{
				num8 = num7;
			}
			if (!(num8 > devideLen))
			{
				calcSimMoves.Add(new DrillMove(CurrentMove));
				return;
			}
			int num9 = (int)buNumeric5.RoundToUpper(num8 / devideLen);
			if (num9 < 2)
			{
				num9 = 2;
			}
			List<double> Values = new List<double>();
			List<double> Values2 = new List<double>();
			List<double> Values3 = new List<double>();
			List<double> Values4 = new List<double>();
			List<double> Values5 = new List<double>();
			List<double> Values6 = new List<double>();
			List<double> Values7 = new List<double>();
			List<double> Values8 = new List<double>();
			List<double> Values9 = new List<double>();
			buNumeric5.DevideMinMaxValueByNumber(PreMove.XPosition, CurrentMove.XPosition, num9, ref Values);
			buNumeric5.DevideMinMaxValueByNumber(PreMove.X1Clamper, CurrentMove.X1Clamper, num9, ref Values2);
			buNumeric5.DevideMinMaxValueByNumber(PreMove.X2Clamper, CurrentMove.X2Clamper, num9, ref Values3);
			buNumeric5.DevideMinMaxValueByNumber(PreMove.Y1Position, CurrentMove.Y1Position, num9, ref Values4);
			buNumeric5.DevideMinMaxValueByNumber(PreMove.Y2Position, CurrentMove.Y2Position, num9, ref Values5);
			buNumeric5.DevideMinMaxValueByNumber(PreMove.Y3Position, CurrentMove.Y3Position, num9, ref Values6);
			buNumeric5.DevideMinMaxValueByNumber(PreMove.Z1Position, CurrentMove.Z1Position, num9, ref Values7);
			buNumeric5.DevideMinMaxValueByNumber(PreMove.Z2Position, CurrentMove.Z2Position, num9, ref Values8);
			buNumeric5.DevideMinMaxValueByNumber(PreMove.Z3Position, CurrentMove.Z3Position, num9, ref Values9);
			for (int i = 0; i <= Values.Count - 1; i++)
			{
				DrillMove drillMove = new DrillMove(CurrentMove);
				drillMove.XPosition = Values[i];
				drillMove.X1Clamper = Values2[i];
				drillMove.X2Clamper = Values3[i];
				drillMove.Y1Position = Values4[i];
				drillMove.Y2Position = Values5[i];
				drillMove.Y3Position = Values6[i];
				drillMove.Z1Position = Values7[i];
				drillMove.Z2Position = Values8[i];
				drillMove.Z3Position = Values9[i];
				calcSimMoves.Add(drillMove);
			}
		}
		else
		{
			calcSimMoves.Add(new DrillMove(CurrentMove));
		}
	}

	public bool isDrillSameForSameLine(DrillCalcItem refItem, DrillCalcItem drillCalcItem_0)
	{
		if (!buCompare5.EQ(refItem.Diameter, drillCalcItem_0.Diameter) || !buCompare5.EQ(refItem.Depth, drillCalcItem_0.Depth) || refItem.planeName != drillCalcItem_0.planeName)
		{
			return false;
		}
		return true;
	}

	public void isHorizontalDrillAvailabe(List<DrillItem> Drills, DrillItem refDrill, double RepeatDistance, int Index, ref int Count)
	{
		Count = 0;
		for (int i = Index + 1; i <= Drills.Count - 1; i++)
		{
			double num = Drills[i].Center.Y - refDrill.Center.Y;
			double value = num % RepeatDistance;
			if (buCompare5.EQ(value, 0.0, 0.05))
			{
				Count++;
			}
		}
	}

	public void isVerticalDrillAvailable(DrillItem refDrill, List<DrillItem> Drills, ref int Count)
	{
		Count = 0;
		for (int i = 0; i <= Drills.Count - 1; i++)
		{
			if (!Drills[i].Calculated && buCompare5.EQ(Drills[i].Center.Y, refDrill.Center.Y, 0.05))
			{
				Count++;
			}
		}
	}

	public void isHorizontalDrillAvailabe(List<DrillCalcItem> Drills, DrillCalcItem refDrill, double RepeatDistance, int Index, ref int Count)
	{
		double MaxYDistance = 0.0;
		isHorizontalDrillAvailabe(Drills, refDrill, RepeatDistance, Index, ref Count, ref MaxYDistance);
	}

	public void isHorizontalDrillAvailabe(List<DrillCalcItem> Drills, DrillCalcItem refDrill, double RepeatDistance, int Index, ref int Count, ref double MaxYDistance)
	{
		Count = 0;
		double num = double.MinValue;
		for (int i = Index + 1; i <= Drills.Count - 1; i++)
		{
			double num2 = Drills[i].Center.Y - refDrill.Center.Y;
			double value = Drills[i].Center.Z - refDrill.Center.Z;
			double value2 = num2 % RepeatDistance;
			if (buCompare5.EQ(value2, 0.0, 0.05) & buCompare5.EQ(value, 0.0, 0.05) & (refDrill.Diameter == Drills[i].Diameter) & (refDrill.planeName == Drills[i].planeName) & (refDrill.ID != Drills[i].ID) & (refDrill.Depth == Drills[i].Depth))
			{
				if (num2 > num)
				{
					num = num2;
				}
				Count++;
			}
		}
		MaxYDistance = num;
		if (MaxYDistance == double.MinValue)
		{
			MaxYDistance = 0.0;
		}
	}

	public void isVerticalDrillAvailable(DrillCalcItem refDrill, List<List<DrillCalcItem>> Drills, double RepeatDistance, int Index, ref int Count)
	{
		Count = 0;
		for (int i = Index + 1; i <= Drills.Count - 1; i++)
		{
			for (int j = 0; j <= Drills[i].Count - 1; j++)
			{
				if (!Drills[i][j].Calculated)
				{
					double num = Drills[i][j].Center.X - refDrill.Center.X;
					double value = num % RepeatDistance;
					if ((num > 0.0 && num <= RepeatDistance * 5.0) & buCompare5.EQ(value, 0.0, 0.05) & buCompare5.EQ(Drills[i][j].Center.Y, refDrill.Center.Y, 0.05) & (refDrill.Diameter == Drills[i][j].Diameter) & (refDrill.Depth == Drills[i][j].Depth) & (refDrill.planeName == Drills[i][j].planeName) & (refDrill.ID != Drills[i][j].ID))
					{
						Count++;
					}
				}
			}
		}
	}

	public void isVerticalDrillAvailable(DrillCalcItem refDrill, List<DrillCalcItem> Drills, ref int Count)
	{
		Count = 0;
		for (int i = 0; i <= Drills.Count - 1; i++)
		{
			if (!Drills[i].Calculated && (buCompare5.EQ(Drills[i].Center.Y, refDrill.Center.Y, 0.05) & (refDrill.Diameter == Drills[i].Diameter) & (refDrill.planeName == Drills[i].planeName) & (refDrill.ID != Drills[i].ID)))
			{
				Count++;
			}
		}
	}

	public bool isDrillSame(DrillItem refDrill, DrillItem checkDrill)
	{
		if (refDrill.planeName != checkDrill.planeName || !buCompare5.EQ(refDrill.Center, checkDrill.Center))
		{
			return false;
		}
		return true;
	}

	public bool isToolsSameForNextOperation(List<DrillCalcItem> ExistingDrills, List<DrillCalcItem> NextDrills)
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i <= ExistingDrills.Count - 1; i++)
		{
			num += ExistingDrills[i].Tool;
		}
		for (int j = 0; j <= NextDrills.Count - 1; j++)
		{
			num2 += NextDrills[j].Tool;
		}
		if (num == num2)
		{
			for (int k = 0; k <= ExistingDrills.Count - 1; k++)
			{
				int tool = ExistingDrills[k].Tool;
				bool flag = false;
				for (int l = 0; l <= NextDrills.Count - 1; l++)
				{
					int tool2 = NextDrills[l].Tool;
					if (tool == tool2)
					{
						flag = true;
					}
				}
				if (!flag)
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}
}
