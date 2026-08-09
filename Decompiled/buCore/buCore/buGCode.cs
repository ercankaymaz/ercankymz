using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;

namespace buCore;

public class buGCode
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

	public List<eEntities> GCodeEntities = new List<eEntities>();

	public List<Pnt9D> PointListVersusGCodeLines = new List<Pnt9D>();

	public Vec3D MoveDistance = new Vec3D();

	public bool UsePointListForGCodeLines = false;

	private string string_0 = "";

	private double double_0 = 0.0;

	private bool bool_0 = false;

	private PostProcessor postProcessor_0 = new PostProcessor();

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

	public buGCode()
	{
		if (buVector.smethod_0("buGCode"))
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
		throw new RegisterException("buGCode");
	}

	public void CreatGCode(camBase Cam, PostProcessor Post, ref string Lines)
	{
		List<camBase> list = new List<camBase>();
		list.Add(Cam);
		CreatGCode(list, Post, ref Lines);
	}

	public void CreatGCode(List<camBase> Cams, PostProcessor Post, ref string Lines)
	{
		try
		{
			PointListVersusGCodeLines.Clear();
			string text = "";
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = "";
			string text6 = "";
			string text7 = "";
			string text8 = "";
			string text9 = "";
			string text10 = "";
			string text11 = "";
			string text12 = "";
			string text13 = "";
			string text14 = "";
			string text15 = "";
			string text16 = "";
			string text17 = "";
			double num = 0.0;
			Pnt9D position = new Pnt9D();
			string Codes = "";
			string_0 = "";
			ArrayList arrayList = new ArrayList();
			postProcessor_0 = new PostProcessor(Post);
			bool flag = postProcessor_0.AxesUsing.U | postProcessor_0.AxesUsing.V | postProcessor_0.AxesUsing.W;
			double_0 = postProcessor_0.NumberDef.Start;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			if (!Cams[0].UseCreatedGCode)
			{
				for (int i = 0; i <= Cams.Count - 1; i++)
				{
					for (int j = 0; j <= Cams[i].CamPoints.Count - 1; j++)
					{
						num2 += Cams[i].CamPoints[j].Points.Count;
					}
				}
				int num6 = Convert.ToInt32((double)num2 / 100.0);
				if (Cams.Count > 0 && Cams[0].CamPoints.Count > 0 && Cams[0].CamPoints[0].Points.Count > 0)
				{
					position = new Pnt9D(Cams[0].CamPoints[0].Points[0].P9);
				}
				if (postProcessor_0.PostVariables.Count > 0)
				{
					ArrayList arrayList2 = new ArrayList();
					for (int k = 0; k <= postProcessor_0.StartLines.Count - 1; k++)
					{
						string text18 = postProcessor_0.StartLines[k].ToString();
						bool flag6 = false;
						ArrayList Lines2 = new ArrayList();
						for (int l = 0; l <= postProcessor_0.PostVariables.Count - 1; l++)
						{
							string variableName = postProcessor_0.PostVariables[l].VariableName;
							if (!(variableName.Trim().ToLower() == text18.Trim().ToLower()))
							{
								continue;
							}
							buString.StringToArrayListByNewLine(postProcessor_0.PostVariables[l].Value, ref Lines2);
							flag6 = true;
							if (postProcessor_0.PostVariables[l].ValueList.Count > 0)
							{
								for (int m = 0; m <= postProcessor_0.PostVariables[l].ValueList.Count - 1; m++)
								{
									Lines2.Add(postProcessor_0.PostVariables[l].ValueList[m]);
								}
							}
						}
						if (Lines2.Count != 0)
						{
							for (int n = 0; n <= Lines2.Count - 1; n++)
							{
								if (Lines2[n].ToString().Trim().Length > 0)
								{
									arrayList2.Add(Lines2[n]);
								}
							}
						}
						else if (!flag6)
						{
							arrayList2.Add(text18);
						}
					}
					postProcessor_0.StartLines.Clear();
					postProcessor_0.StartLines.AddRange(arrayList2);
				}
				for (int num7 = 0; num7 <= postProcessor_0.StartLines.Count - 1; num7++)
				{
					string newCommand = postProcessor_0.StartLines[num7].ToString();
					AddCode(ref Codes, newCommand, postProcessor_0, position);
				}
				arrayList.Add(Codes);
				Codes = "";
				for (int num8 = 0; num8 <= Cams.Count - 1; num8++)
				{
					if (!Cams[num8].Enable)
					{
						continue;
					}
					if (!Cams[num8].UsedCamPost)
					{
						postProcessor_0 = new PostProcessor(Post);
						if (Cams[num8].RegionIndex > 0)
						{
							if (Cams[num8].RegionIndex == 1)
							{
								postProcessor_0.ToolDef = new ToolPost(Post.Region1.RegionToolDef);
								postProcessor_0.SpindleDef = new SpindlePost(Post.Region1.RegionSpindleDef);
								postProcessor_0.TDef = new CharDefinitions(Post.Region1.RegionTDef);
								postProcessor_0.SDef = new CharDefinitions(Post.Region1.RegionSDef);
								postProcessor_0.XDef = new CharDefinitions(Post.Region1.RegionXDef);
								postProcessor_0.YDef = new CharDefinitions(Post.Region1.RegionYDef);
								postProcessor_0.ZDef = new CharDefinitions(Post.Region1.RegionZDef);
								postProcessor_0.ADef = new CharDefinitions(Post.Region1.RegionADef);
								postProcessor_0.BDef = new CharDefinitions(Post.Region1.RegionBDef);
								postProcessor_0.CDef = new CharDefinitions(Post.Region1.RegionCDef);
							}
							if (Cams[num8].RegionIndex == 2)
							{
								postProcessor_0.ToolDef = new ToolPost(Post.Region2.RegionToolDef);
								postProcessor_0.SpindleDef = new SpindlePost(Post.Region2.RegionSpindleDef);
								postProcessor_0.TDef = new CharDefinitions(Post.Region2.RegionTDef);
								postProcessor_0.SDef = new CharDefinitions(Post.Region2.RegionSDef);
								postProcessor_0.XDef = new CharDefinitions(Post.Region2.RegionXDef);
								postProcessor_0.YDef = new CharDefinitions(Post.Region2.RegionYDef);
								postProcessor_0.ZDef = new CharDefinitions(Post.Region2.RegionZDef);
								postProcessor_0.ADef = new CharDefinitions(Post.Region2.RegionADef);
								postProcessor_0.BDef = new CharDefinitions(Post.Region2.RegionBDef);
								postProcessor_0.CDef = new CharDefinitions(Post.Region2.RegionCDef);
							}
							if (Cams[num8].RegionIndex == 3)
							{
								postProcessor_0.ToolDef = new ToolPost(Post.Region3.RegionToolDef);
								postProcessor_0.SpindleDef = new SpindlePost(Post.Region3.RegionSpindleDef);
								postProcessor_0.TDef = new CharDefinitions(Post.Region3.RegionTDef);
								postProcessor_0.SDef = new CharDefinitions(Post.Region3.RegionSDef);
								postProcessor_0.XDef = new CharDefinitions(Post.Region3.RegionXDef);
								postProcessor_0.YDef = new CharDefinitions(Post.Region3.RegionYDef);
								postProcessor_0.ZDef = new CharDefinitions(Post.Region3.RegionZDef);
								postProcessor_0.ADef = new CharDefinitions(Post.Region3.RegionADef);
								postProcessor_0.BDef = new CharDefinitions(Post.Region3.RegionBDef);
								postProcessor_0.CDef = new CharDefinitions(Post.Region3.RegionCDef);
							}
							if (Cams[num8].RegionIndex == 4)
							{
								postProcessor_0.ToolDef = new ToolPost(Post.Region4.RegionToolDef);
								postProcessor_0.SpindleDef = new SpindlePost(Post.Region4.RegionSpindleDef);
								postProcessor_0.TDef = new CharDefinitions(Post.Region4.RegionTDef);
								postProcessor_0.SDef = new CharDefinitions(Post.Region4.RegionSDef);
								postProcessor_0.XDef = new CharDefinitions(Post.Region4.RegionXDef);
								postProcessor_0.YDef = new CharDefinitions(Post.Region4.RegionYDef);
								postProcessor_0.ZDef = new CharDefinitions(Post.Region4.RegionZDef);
								postProcessor_0.ADef = new CharDefinitions(Post.Region4.RegionADef);
								postProcessor_0.BDef = new CharDefinitions(Post.Region4.RegionBDef);
								postProcessor_0.CDef = new CharDefinitions(Post.Region4.RegionCDef);
							}
							if (Cams[num8].RegionIndex == 5)
							{
								postProcessor_0.ToolDef = new ToolPost(Post.Region5.RegionToolDef);
								postProcessor_0.SpindleDef = new SpindlePost(Post.Region5.RegionSpindleDef);
								postProcessor_0.TDef = new CharDefinitions(Post.Region5.RegionTDef);
								postProcessor_0.SDef = new CharDefinitions(Post.Region5.RegionSDef);
								postProcessor_0.XDef = new CharDefinitions(Post.Region5.RegionXDef);
								postProcessor_0.YDef = new CharDefinitions(Post.Region5.RegionYDef);
								postProcessor_0.ZDef = new CharDefinitions(Post.Region5.RegionZDef);
								postProcessor_0.ADef = new CharDefinitions(Post.Region5.RegionADef);
								postProcessor_0.BDef = new CharDefinitions(Post.Region5.RegionBDef);
								postProcessor_0.CDef = new CharDefinitions(Post.Region5.RegionCDef);
							}
							if (Cams[num8].RegionIndex == 6)
							{
								postProcessor_0.ToolDef = new ToolPost(Post.Region6.RegionToolDef);
								postProcessor_0.SpindleDef = new SpindlePost(Post.Region6.RegionSpindleDef);
								postProcessor_0.TDef = new CharDefinitions(Post.Region6.RegionTDef);
								postProcessor_0.SDef = new CharDefinitions(Post.Region6.RegionSDef);
								postProcessor_0.XDef = new CharDefinitions(Post.Region6.RegionXDef);
								postProcessor_0.YDef = new CharDefinitions(Post.Region6.RegionYDef);
								postProcessor_0.ZDef = new CharDefinitions(Post.Region6.RegionZDef);
								postProcessor_0.ADef = new CharDefinitions(Post.Region6.RegionADef);
								postProcessor_0.BDef = new CharDefinitions(Post.Region6.RegionBDef);
								postProcessor_0.CDef = new CharDefinitions(Post.Region6.RegionCDef);
							}
						}
					}
					else
					{
						postProcessor_0 = new PostProcessor(Cams[num8].Post);
						postProcessor_0.AxesUsing.X = Cams[num8].Post.AxesUsing.X & Post.AxesUsing.X;
						postProcessor_0.AxesUsing.Y = Cams[num8].Post.AxesUsing.Y & Post.AxesUsing.Y;
						postProcessor_0.AxesUsing.Z = Cams[num8].Post.AxesUsing.Z & Post.AxesUsing.Z;
						postProcessor_0.AxesUsing.A = Cams[num8].Post.AxesUsing.A & Post.AxesUsing.A;
						postProcessor_0.AxesUsing.B = Cams[num8].Post.AxesUsing.B & Post.AxesUsing.B;
						postProcessor_0.AxesUsing.C = Cams[num8].Post.AxesUsing.C & Post.AxesUsing.C;
						if (Cams[num8].RegionIndex > 0)
						{
							if (Cams[num8].RegionIndex == 1)
							{
								postProcessor_0.ToolDef = new ToolPost(Cams[num8].Post.Region1.RegionToolDef);
								postProcessor_0.SpindleDef = new SpindlePost(Cams[num8].Post.Region1.RegionSpindleDef);
								postProcessor_0.TDef = new CharDefinitions(Cams[num8].Post.Region1.RegionTDef);
								postProcessor_0.SDef = new CharDefinitions(Cams[num8].Post.Region1.RegionSDef);
								postProcessor_0.XDef = new CharDefinitions(Cams[num8].Post.Region1.RegionXDef);
								postProcessor_0.YDef = new CharDefinitions(Cams[num8].Post.Region1.RegionYDef);
								postProcessor_0.ZDef = new CharDefinitions(Cams[num8].Post.Region1.RegionZDef);
								postProcessor_0.ADef = new CharDefinitions(Cams[num8].Post.Region1.RegionADef);
								postProcessor_0.BDef = new CharDefinitions(Cams[num8].Post.Region1.RegionBDef);
								postProcessor_0.CDef = new CharDefinitions(Cams[num8].Post.Region1.RegionCDef);
							}
							if (Cams[num8].RegionIndex == 2)
							{
								postProcessor_0.ToolDef = new ToolPost(Cams[num8].Post.Region2.RegionToolDef);
								postProcessor_0.SpindleDef = new SpindlePost(Cams[num8].Post.Region2.RegionSpindleDef);
								postProcessor_0.TDef = new CharDefinitions(Cams[num8].Post.Region2.RegionTDef);
								postProcessor_0.SDef = new CharDefinitions(Cams[num8].Post.Region2.RegionSDef);
								postProcessor_0.XDef = new CharDefinitions(Cams[num8].Post.Region2.RegionXDef);
								postProcessor_0.YDef = new CharDefinitions(Cams[num8].Post.Region2.RegionYDef);
								postProcessor_0.ZDef = new CharDefinitions(Cams[num8].Post.Region2.RegionZDef);
								postProcessor_0.ADef = new CharDefinitions(Cams[num8].Post.Region2.RegionADef);
								postProcessor_0.BDef = new CharDefinitions(Cams[num8].Post.Region2.RegionBDef);
								postProcessor_0.CDef = new CharDefinitions(Cams[num8].Post.Region2.RegionCDef);
							}
							if (Cams[num8].RegionIndex == 3)
							{
								postProcessor_0.ToolDef = new ToolPost(Cams[num8].Post.Region3.RegionToolDef);
								postProcessor_0.SpindleDef = new SpindlePost(Cams[num8].Post.Region3.RegionSpindleDef);
								postProcessor_0.TDef = new CharDefinitions(Cams[num8].Post.Region3.RegionTDef);
								postProcessor_0.SDef = new CharDefinitions(Cams[num8].Post.Region3.RegionSDef);
								postProcessor_0.XDef = new CharDefinitions(Cams[num8].Post.Region3.RegionXDef);
								postProcessor_0.YDef = new CharDefinitions(Cams[num8].Post.Region3.RegionYDef);
								postProcessor_0.ZDef = new CharDefinitions(Cams[num8].Post.Region3.RegionZDef);
								postProcessor_0.ADef = new CharDefinitions(Cams[num8].Post.Region3.RegionADef);
								postProcessor_0.BDef = new CharDefinitions(Cams[num8].Post.Region3.RegionBDef);
								postProcessor_0.CDef = new CharDefinitions(Cams[num8].Post.Region3.RegionCDef);
							}
							if (Cams[num8].RegionIndex == 4)
							{
								postProcessor_0.ToolDef = new ToolPost(Cams[num8].Post.Region4.RegionToolDef);
								postProcessor_0.SpindleDef = new SpindlePost(Cams[num8].Post.Region4.RegionSpindleDef);
								postProcessor_0.TDef = new CharDefinitions(Cams[num8].Post.Region4.RegionTDef);
								postProcessor_0.SDef = new CharDefinitions(Cams[num8].Post.Region4.RegionSDef);
								postProcessor_0.XDef = new CharDefinitions(Cams[num8].Post.Region4.RegionXDef);
								postProcessor_0.YDef = new CharDefinitions(Cams[num8].Post.Region4.RegionYDef);
								postProcessor_0.ZDef = new CharDefinitions(Cams[num8].Post.Region4.RegionZDef);
								postProcessor_0.ADef = new CharDefinitions(Cams[num8].Post.Region4.RegionADef);
								postProcessor_0.BDef = new CharDefinitions(Cams[num8].Post.Region4.RegionBDef);
								postProcessor_0.CDef = new CharDefinitions(Cams[num8].Post.Region4.RegionCDef);
							}
							if (Cams[num8].RegionIndex == 5)
							{
								postProcessor_0.ToolDef = new ToolPost(Cams[num8].Post.Region5.RegionToolDef);
								postProcessor_0.SpindleDef = new SpindlePost(Cams[num8].Post.Region5.RegionSpindleDef);
								postProcessor_0.TDef = new CharDefinitions(Cams[num8].Post.Region5.RegionTDef);
								postProcessor_0.SDef = new CharDefinitions(Cams[num8].Post.Region5.RegionSDef);
								postProcessor_0.XDef = new CharDefinitions(Cams[num8].Post.Region5.RegionXDef);
								postProcessor_0.YDef = new CharDefinitions(Cams[num8].Post.Region5.RegionYDef);
								postProcessor_0.ZDef = new CharDefinitions(Cams[num8].Post.Region5.RegionZDef);
								postProcessor_0.ADef = new CharDefinitions(Cams[num8].Post.Region5.RegionADef);
								postProcessor_0.BDef = new CharDefinitions(Cams[num8].Post.Region5.RegionBDef);
								postProcessor_0.CDef = new CharDefinitions(Cams[num8].Post.Region5.RegionCDef);
							}
							if (Cams[num8].RegionIndex == 6)
							{
								postProcessor_0.ToolDef = new ToolPost(Cams[num8].Post.Region6.RegionToolDef);
								postProcessor_0.SpindleDef = new SpindlePost(Cams[num8].Post.Region6.RegionSpindleDef);
								postProcessor_0.TDef = new CharDefinitions(Cams[num8].Post.Region6.RegionTDef);
								postProcessor_0.SDef = new CharDefinitions(Cams[num8].Post.Region6.RegionSDef);
								postProcessor_0.XDef = new CharDefinitions(Cams[num8].Post.Region6.RegionXDef);
								postProcessor_0.YDef = new CharDefinitions(Cams[num8].Post.Region6.RegionYDef);
								postProcessor_0.ZDef = new CharDefinitions(Cams[num8].Post.Region6.RegionZDef);
								postProcessor_0.ADef = new CharDefinitions(Cams[num8].Post.Region6.RegionADef);
								postProcessor_0.BDef = new CharDefinitions(Cams[num8].Post.Region6.RegionBDef);
								postProcessor_0.CDef = new CharDefinitions(Cams[num8].Post.Region6.RegionCDef);
							}
						}
					}
					for (int num9 = 0; num9 <= postProcessor_0.StartLinesEachBlock.Count - 1; num9++)
					{
						string text19 = postProcessor_0.StartLinesEachBlock[num9].ToString().Trim();
						if (text19.Length > 0)
						{
							AddCode(ref Codes, text19, postProcessor_0, position);
						}
					}
					if (Cams[num8].PreCodes.Count > 0)
					{
						for (int num10 = 0; num10 <= Cams[num8].PreCodes.Count - 1; num10++)
						{
							string text20 = Cams[num8].PreCodes[num10].ToString().Trim();
							if (text20.Length > 0)
							{
								AddCode(ref Codes, text20, postProcessor_0, position);
							}
						}
					}
					if (!postProcessor_0.SpindleDef.UseSpindle)
					{
						text11 = "";
					}
					else
					{
						text11 = ValueFormat(postProcessor_0, postProcessor_0.SDef.Char, Cams[num8].Tool.CamData.SpindleSpeed, 0.0, 0, Cams[num8]);
						text11 = ((!postProcessor_0.SpindleDef.SpindleMCommandFirst) ? ((Cams[num8].Tool.CamData.SpindleDirection == ClockDirectionType.CW) ? (text11 + postProcessor_0.SpindleDef.SpindleCWCode) : (text11 + postProcessor_0.SpindleDef.SpindleCCWCode)) : ((Cams[num8].Tool.CamData.SpindleDirection == ClockDirectionType.CW) ? (postProcessor_0.SpindleDef.SpindleCWCode + " " + text11) : (postProcessor_0.SpindleDef.SpindleCCWCode + " " + text11)));
					}
					if ((num8 == 0) | ((num8 > 0) & !postProcessor_0.ToolNextDef.ToolData.Enable))
					{
						if (!postProcessor_0.ToolDef.ToolData.Enable)
						{
							text10 = "";
							if (postProcessor_0.SpindleDef.UseSpindle & !postProcessor_0.Tool1.ToolData.Enable & !postProcessor_0.Tool2.ToolData.Enable & !postProcessor_0.Tool3.ToolData.Enable & !postProcessor_0.Tool4.ToolData.Enable & !postProcessor_0.Tool5.ToolData.Enable)
							{
								if (postProcessor_0.SpindleDef.PreCode.Count > 0)
								{
									for (int num11 = 0; num11 <= postProcessor_0.SpindleDef.PreCode.Count - 1; num11++)
									{
										string text21 = postProcessor_0.SpindleDef.PreCode[num11].ToString().Trim();
										if (text21.Length > 0)
										{
											AddCode(ref Codes, text21, postProcessor_0, position);
										}
									}
								}
								AddCode(ref Codes, text11, postProcessor_0, position);
								if (postProcessor_0.SpindleDef.AfterCode.Count > 0)
								{
									for (int num12 = 0; num12 <= postProcessor_0.SpindleDef.AfterCode.Count - 1; num12++)
									{
										string text22 = postProcessor_0.SpindleDef.AfterCode[num12].ToString().Trim();
										if (text22.Length > 0)
										{
											AddCode(ref Codes, text22, postProcessor_0, position);
										}
									}
								}
							}
						}
						else
						{
							bool flag7 = true;
							string text23 = "";
							if (postProcessor_0.ToolDef.UseToolWithComment)
							{
								text23 = postProcessor_0.CommentChar;
							}
							if (((num8 > 0) & !postProcessor_0.RepetitionDef.Tool) && Cams[num8 - 1].Tool.Data.No == Cams[num8].Tool.Data.No)
							{
								flag7 = false;
							}
							if (flag7)
							{
								if (postProcessor_0.ToolDef.UseToolInfo)
								{
									string newCommand2 = postProcessor_0.CommentChar + " Name : " + Cams[num8].Tool.Data.Name + " , Diameter : " + Cams[num8].Tool.Geometry.Diameter + " , Length: " + Cams[num8].Tool.Geometry.Length;
									AddCode(ref Codes, newCommand2, postProcessor_0, position);
								}
								if ((num8 > 0) & postProcessor_0.ToolDef.MoveSafeBeforeToolChange)
								{
									text3 = (postProcessor_0.AxesUsing.Z ? ValueFormat(postProcessor_0, "Z", Cams[num8 - 1].ZSafeDistance, MoveDistance.Z + Cams[num8 - 1].MoveOffset.Z, Cams[num8 - 1].ZAxisIndex, Cams[num8 - 1]) : "");
									if (Cams[num8 - 1].Tool.Data.No != Cams[num8].Tool.Data.No)
									{
										string newCommand3 = "G0 " + text3;
										AddCode(ref Codes, newCommand3, postProcessor_0, position);
									}
								}
								for (int num13 = 0; num13 <= postProcessor_0.ToolDef.ToolData.PreCode.Count - 1; num13++)
								{
									string text24 = postProcessor_0.ToolDef.ToolData.PreCode[num13].ToString().Trim();
									if (text24.Length > 0)
									{
										AddCode(ref Codes, text24, postProcessor_0, position);
									}
								}
							}
							text10 = ValueFormat(postProcessor_0, "T", Cams[num8].Tool.Data.No);
							if (postProcessor_0.ToolDef.UseToolSector)
							{
								text10 = text10.TrimEnd();
								text10 = ((!postProcessor_0.ToolDef.ToolSectorDataNextLine) ? (text10 + postProcessor_0.ToolDef.ToolSectorSeperateChar + Cams[num8].Tool.Data.Sector + " ") : (text10 + Environment.NewLine + postProcessor_0.ToolDef.ToolSectorSeperateChar + Cams[num8].Tool.Data.Sector + " "));
							}
							if (postProcessor_0.ToolDef.ToolChangeCode.Trim().Length > 0)
							{
								text10 = ((!postProcessor_0.ToolDef.ToolChangeMCommandFirst) ? (text10 + postProcessor_0.ToolDef.ToolChangeCode + " ") : (postProcessor_0.ToolDef.ToolChangeCode + " " + text10));
							}
							if (postProcessor_0.ToolDef.UseToolDChar)
							{
								text10 = text10 + "D" + Cams[num8].Tool.Data.No + " ";
							}
							text10 += postProcessor_0.ToolDef.ToolAdditionalString;
							if (flag7)
							{
								if (!postProcessor_0.SpindleDef.SpindleAtToolLine)
								{
									if (text10.Trim().Length > 0)
									{
										AddCode(ref Codes, text23 + text10, postProcessor_0, position);
									}
									if (postProcessor_0.ToolDef.UseToolLengthCompensation)
									{
										string text25 = postProcessor_0.ToolDef.ToolLengthCompensationChar;
										if (postProcessor_0.ToolDef.UseToolLengthCompensationHeight)
										{
											text25 = text25 + " " + postProcessor_0.ToolDef.ToolLengthCompensationHeightChar + Cams[num8].Tool.Data.HeightOffsetIndex + " " + postProcessor_0.ToolDef.ToolLengthCompensationZChar;
										}
										AddCode(ref Codes, text25, postProcessor_0, position);
									}
									if (!postProcessor_0.ToolDef.UseToolLengthCompensation & postProcessor_0.ToolDef.UseToolLengthCompensationHeight)
									{
										string text26 = "";
										text26 = postProcessor_0.ToolDef.ToolLengthCompensationHeightChar + Cams[num8].Tool.Data.HeightOffsetIndex + " " + postProcessor_0.ToolDef.ToolLengthCompensationZChar;
										AddCode(ref Codes, text26, postProcessor_0, position);
									}
									if (flag7)
									{
										for (int num14 = 0; num14 <= postProcessor_0.ToolDef.ToolData.AfterCode.Count - 1; num14++)
										{
											string text27 = postProcessor_0.ToolDef.ToolData.AfterCode[num14].ToString().Trim();
											if (text27.Length > 0)
											{
												AddCode(ref Codes, text27, postProcessor_0, position);
											}
										}
									}
									if (postProcessor_0.SpindleDef.PreCode.Count > 0)
									{
										for (int num15 = 0; num15 <= postProcessor_0.SpindleDef.PreCode.Count - 1; num15++)
										{
											string text28 = postProcessor_0.SpindleDef.PreCode[num15].ToString().Trim();
											if (text28.Length > 0)
											{
												AddCode(ref Codes, text28, postProcessor_0, position);
											}
										}
									}
									if (text11.Length > 0)
									{
										AddCode(ref Codes, text11, postProcessor_0, position);
									}
									if (postProcessor_0.SpindleDef.AfterCode.Count > 0)
									{
										for (int num16 = 0; num16 <= postProcessor_0.SpindleDef.AfterCode.Count - 1; num16++)
										{
											string text29 = postProcessor_0.SpindleDef.AfterCode[num16].ToString().Trim();
											if (text29.Length > 0)
											{
												AddCode(ref Codes, text29, postProcessor_0, position);
											}
										}
									}
								}
								else
								{
									if (text10.Trim().Length > 0)
									{
										AddCode(ref Codes, text23 + text10 + text11, postProcessor_0, position);
									}
									if (postProcessor_0.ToolDef.UseToolLengthCompensation)
									{
										string text30 = postProcessor_0.ToolDef.ToolLengthCompensationChar;
										if (postProcessor_0.ToolDef.UseToolLengthCompensationHeight)
										{
											text30 = text30 + " " + postProcessor_0.ToolDef.ToolLengthCompensationHeightChar + Cams[num8].Tool.Data.HeightOffsetIndex + " " + postProcessor_0.ToolDef.ToolLengthCompensationZChar;
										}
										AddCode(ref Codes, text30, postProcessor_0, position);
									}
									if (!postProcessor_0.ToolDef.UseToolLengthCompensation & postProcessor_0.ToolDef.UseToolLengthCompensationHeight)
									{
										string text31 = "";
										text31 = postProcessor_0.ToolDef.ToolLengthCompensationHeightChar + Cams[num8].Tool.Data.HeightOffsetIndex + " " + postProcessor_0.ToolDef.ToolLengthCompensationZChar;
										AddCode(ref Codes, text31, postProcessor_0, position);
									}
									if (flag7)
									{
										for (int num17 = 0; num17 <= postProcessor_0.ToolDef.ToolData.AfterCode.Count - 1; num17++)
										{
											string text32 = postProcessor_0.ToolDef.ToolData.AfterCode[num17].ToString().Trim();
											if (text32.Length > 0)
											{
												AddCode(ref Codes, text32, postProcessor_0, position);
											}
										}
									}
								}
								if (postProcessor_0.ToolDef.UseToolAuxCodes && Cams[num8].Tool.Aux.Count > 0)
								{
									for (int num18 = 0; num18 <= Cams[num8].Tool.Aux.Count - 1; num18++)
									{
										if (Cams[num8].Tool.Aux[num18].ToString().Length > 0)
										{
											AddCode(ref Codes, Cams[num8].Tool.Aux[num18].ToString(), postProcessor_0, position);
										}
									}
								}
							}
						}
					}
					Pnt9DCam pnt9DCam = new Pnt9DCam(double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue);
					pnt9DCam.Type = -1;
					int num19 = 0;
					int num20 = 0;
					double resolution = buSystem.resolutionCompare;
					double resolution2 = buSystem.resolutionCompare;
					double resolution3 = buSystem.resolutionCompare;
					double resolution4 = buSystem.resolutionCompare;
					double resolution5 = buSystem.resolutionCompare;
					double resolution6 = buSystem.resolutionCompare;
					double resolution7 = buSystem.resolutionCompare;
					double resolution8 = buSystem.resolutionCompare;
					double resolution9 = buSystem.resolutionCompare;
					if (postProcessor_0.XDef.Decimal > 0)
					{
						resolution = 1.0 / Math.Pow(10.0, postProcessor_0.XDef.Decimal);
					}
					if (postProcessor_0.YDef.Decimal > 0)
					{
						resolution2 = 1.0 / Math.Pow(10.0, postProcessor_0.YDef.Decimal);
					}
					if (postProcessor_0.ZDef.Decimal > 0)
					{
						resolution3 = 1.0 / Math.Pow(10.0, postProcessor_0.ZDef.Decimal);
					}
					if (postProcessor_0.ADef.Decimal > 0)
					{
						resolution4 = 1.0 / Math.Pow(10.0, postProcessor_0.ADef.Decimal);
					}
					if (postProcessor_0.BDef.Decimal > 0)
					{
						resolution5 = 1.0 / Math.Pow(10.0, postProcessor_0.BDef.Decimal);
					}
					if (postProcessor_0.CDef.Decimal > 0)
					{
						resolution6 = 1.0 / Math.Pow(10.0, postProcessor_0.CDef.Decimal);
					}
					if (postProcessor_0.UDef.Decimal > 0)
					{
						resolution7 = 1.0 / Math.Pow(10.0, postProcessor_0.UDef.Decimal);
					}
					if (postProcessor_0.VDef.Decimal > 0)
					{
						resolution8 = 1.0 / Math.Pow(10.0, postProcessor_0.VDef.Decimal);
					}
					if (postProcessor_0.WDef.Decimal > 0)
					{
						resolution9 = 1.0 / Math.Pow(10.0, postProcessor_0.WDef.Decimal);
					}
					for (int num21 = 0; num21 <= Cams[num8].CamPoints.Count - 1; num21++)
					{
						num4 = 0;
						num5 = 0;
						num = Cams[num8].CamPoints[num21].Feed;
						for (int num22 = 0; num22 <= Cams[num8].CamPoints[num21].PreCodes.Count - 1; num22++)
						{
							string text33 = Cams[num8].CamPoints[num21].PreCodes[num22].ToString().Trim();
							if (text33.Length > 0)
							{
								AddCode(ref Codes, text33, postProcessor_0, position);
							}
						}
						text14 = "";
						text15 = "";
						text16 = "";
						text17 = "";
						text13 = ValueFormat(postProcessor_0, "F", num, 0.0, 0, Cams[num8]);
						if (Cams[num8].CamPoints[num21].IsRapid && !postProcessor_0.G0Propery.UseFeedSpeed)
						{
							text13 = "";
						}
						string text34 = "";
						string text35 = "";
						eEntities gCodeEntity = new eEntities();
						for (int num23 = 0; num23 <= Cams[num8].CamPoints[num21].Points.Count - 1; num23++)
						{
							position = new Pnt9D(Cams[num8].CamPoints[num21].Points[num23].P9);
							num20 = Cams[num8].CamPoints[num21].Points[num23].PreCodes.Count;
							num3++;
							if (Cams[num8].CamPoints[num21].Points[num23].Type == 0)
							{
								text12 = ValueFormat(postProcessor_0, "G", Cams[num8].CamPoints[num21].Points[num23].Type);
							}
							if (Cams[num8].CamPoints[num21].Points[num23].Type == 1)
							{
								text12 = ValueFormat(postProcessor_0, "G", Cams[num8].CamPoints[num21].Points[num23].Type);
							}
							if (((Cams[num8].CamPoints[num21].Points[num23].Type == 2) | (Cams[num8].CamPoints[num21].Points[num23].Type == 3)) & (postProcessor_0.CircularDef.Type == CircularPostType.DevidedLine))
							{
								text12 = ValueFormat(postProcessor_0, "G", 1);
							}
							if (((Cams[num8].CamPoints[num21].Points[num23].Type == 2) | (Cams[num8].CamPoints[num21].Points[num23].Type == 3)) & (postProcessor_0.CircularDef.Type == CircularPostType.Arc))
							{
								text12 = ValueFormat(postProcessor_0, "G", Cams[num8].CamPoints[num21].Points[num23].Type);
								if (postProcessor_0.CircularDef.Mode == CircularMode.R)
								{
									text14 = ValueFormat(postProcessor_0, "R", Cams[num8].CamPoints[num21].Points[num23].ArcData.Radius, 0.0, 0, Cams[num8]);
									if ((postProcessor_0.RDef.AdditionalData.Length > 0) & !Cams[num8].CamPoints[num21].Points[num23].DontUseAdditionalCommand)
									{
										string text36 = new string(' ', postProcessor_0.RDef.SpaceWithAdditionalData);
										string AddtionalString = postProcessor_0.RDef.AdditionalData;
										GetPostParameter(ref AddtionalString, Cams[num8].CamPoints[num21].Points[num23]);
										text14 = text14 + AddtionalString + text36;
									}
								}
								if (postProcessor_0.CircularDef.Mode == CircularMode.IJK)
								{
									double value = 0.0;
									double value2 = 0.0;
									double value3 = 0.0;
									if (postProcessor_0.CircularDef.IJKMode == CircularIJKMode.OffsetFromStartToCenter)
									{
										value = Cams[num8].CamPoints[num21].Points[num23].ArcData.CenterPoint.X - Cams[num8].CamPoints[num21].Points[0].P9.X;
										value2 = Cams[num8].CamPoints[num21].Points[num23].ArcData.CenterPoint.Y - Cams[num8].CamPoints[num21].Points[0].P9.Y;
										value3 = Cams[num8].CamPoints[num21].Points[num23].ArcData.CenterPoint.Z - Cams[num8].CamPoints[num21].Points[0].P9.Z;
									}
									if (postProcessor_0.CircularDef.IJKMode == CircularIJKMode.Center)
									{
										value = Cams[num8].CamPoints[num21].Points[num23].ArcData.CenterPoint.X;
										value2 = Cams[num8].CamPoints[num21].Points[num23].ArcData.CenterPoint.Y;
										value3 = Cams[num8].CamPoints[num21].Points[num23].ArcData.CenterPoint.Z;
									}
									text15 = ValueFormat(postProcessor_0, "I", value, 0.0, 0, Cams[num8]);
									text16 = ValueFormat(postProcessor_0, "J", value2, 0.0, 0, Cams[num8]);
									text17 = ValueFormat(postProcessor_0, "K", value3, 0.0, 0, Cams[num8]);
									if (Cams[num8].Plane.PlaneType == planeType.XY)
									{
										text17 = "";
									}
									if (Cams[num8].Plane.PlaneType == planeType.XZ)
									{
										text16 = "";
									}
									if (Cams[num8].Plane.PlaneType == planeType.YZ)
									{
										text15 = "";
									}
								}
							}
							for (int num24 = 0; num24 <= Cams[num8].CamPoints[num21].Points[num23].PreCodes.Count - 1; num24++)
							{
								string text37 = Cams[num8].CamPoints[num21].Points[num23].PreCodes[num24].ToString().Trim();
								if (text37.Length > 0)
								{
									AddCode(ref Codes, text37, postProcessor_0, position);
								}
							}
							if (Cams[num8].CamPoints[num21].Points[num23].Feed > 0.0)
							{
								num = Cams[num8].CamPoints[num21].Points[num23].Feed;
								text13 = ValueFormat(postProcessor_0, "F", num, 0.0, 0, Cams[num8]);
							}
							if (!postProcessor_0.AxesUsing.X)
							{
								text = "";
								pnt9DCam.P9.X = 0.0;
							}
							else
							{
								text = ValueFormat(postProcessor_0, "X", Cams[num8].CamPoints[num21].Points[num23].P9.X + Cams[num8].CamPoints[num21].GCodeOffset.X, MoveDistance.X + Cams[num8].MoveOffset.X, 0, Cams[num8]);
								if ((postProcessor_0.XDef.AdditionalData.Length > 0) & !Cams[num8].CamPoints[num21].Points[num23].DontUseAdditionalCommand)
								{
									string text38 = new string(' ', postProcessor_0.XDef.SpaceWithAdditionalData);
									string AddtionalString2 = postProcessor_0.XDef.AdditionalData;
									GetPostParameter(ref AddtionalString2, Cams[num8].CamPoints[num21].Points[num23]);
									text = text + AddtionalString2 + text38;
								}
							}
							if (!postProcessor_0.AxesUsing.Y)
							{
								text2 = "";
								pnt9DCam.P9.Y = 0.0;
							}
							else
							{
								text2 = ValueFormat(postProcessor_0, "Y", Cams[num8].CamPoints[num21].Points[num23].P9.Y + Cams[num8].CamPoints[num21].GCodeOffset.Y, MoveDistance.Y + Cams[num8].MoveOffset.Y, 0, Cams[num8]);
								if ((postProcessor_0.YDef.AdditionalData.Length > 0) & !Cams[num8].CamPoints[num21].Points[num23].DontUseAdditionalCommand)
								{
									string text39 = new string(' ', postProcessor_0.YDef.SpaceWithAdditionalData);
									string AddtionalString3 = postProcessor_0.YDef.AdditionalData;
									GetPostParameter(ref AddtionalString3, Cams[num8].CamPoints[num21].Points[num23]);
									text2 = text2 + AddtionalString3 + text39;
								}
							}
							if (!postProcessor_0.AxesUsing.Z)
							{
								text3 = "";
								pnt9DCam.P9.Z = 0.0;
							}
							else
							{
								text3 = ValueFormat(postProcessor_0, "Z", Cams[num8].CamPoints[num21].Points[num23].P9.Z + Cams[num8].CamPoints[num21].GCodeOffset.Z, MoveDistance.Z + Cams[num8].MoveOffset.Z, Cams[num8].ZAxisIndex, Cams[num8]);
								if ((postProcessor_0.ZDef.AdditionalData.Length > 0) & !Cams[num8].CamPoints[num21].Points[num23].DontUseAdditionalCommand)
								{
									string text40 = new string(' ', postProcessor_0.ZDef.SpaceWithAdditionalData);
									string AddtionalString4 = postProcessor_0.ZDef.AdditionalData;
									GetPostParameter(ref AddtionalString4, Cams[num8].CamPoints[num21].Points[num23]);
									text3 = text3 + AddtionalString4 + text40;
								}
							}
							if (!postProcessor_0.AxesUsing.A)
							{
								text4 = "";
								pnt9DCam.P9.A = 0.0;
							}
							else
							{
								text4 = ValueFormat(postProcessor_0, "A", Cams[num8].CamPoints[num21].Points[num23].P9.A + Cams[num8].CamPoints[num21].GCodeOffset.A, 0.0, 0, Cams[num8]);
								if ((postProcessor_0.ADef.AdditionalData.Length > 0) & !Cams[num8].CamPoints[num21].Points[num23].DontUseAdditionalCommand)
								{
									string text41 = new string(' ', postProcessor_0.ADef.SpaceWithAdditionalData);
									string AddtionalString5 = postProcessor_0.ADef.AdditionalData;
									GetPostParameter(ref AddtionalString5, Cams[num8].CamPoints[num21].Points[num23]);
									text4 = text4 + AddtionalString5 + text41;
								}
							}
							if (!postProcessor_0.AxesUsing.B)
							{
								text5 = "";
								pnt9DCam.P9.B = 0.0;
							}
							else
							{
								text5 = ValueFormat(postProcessor_0, "B", Cams[num8].CamPoints[num21].Points[num23].P9.B + Cams[num8].CamPoints[num21].GCodeOffset.B, 0.0, 0, Cams[num8]);
								if ((postProcessor_0.BDef.AdditionalData.Length > 0) & !Cams[num8].CamPoints[num21].Points[num23].DontUseAdditionalCommand)
								{
									string text42 = new string(' ', postProcessor_0.BDef.SpaceWithAdditionalData);
									string AddtionalString6 = postProcessor_0.BDef.AdditionalData;
									GetPostParameter(ref AddtionalString6, Cams[num8].CamPoints[num21].Points[num23]);
									text5 = text5 + AddtionalString6 + text42;
								}
							}
							if (!postProcessor_0.AxesUsing.C)
							{
								text6 = "";
								pnt9DCam.P9.C = 0.0;
							}
							else
							{
								text6 = ValueFormat(postProcessor_0, "C", Cams[num8].CamPoints[num21].Points[num23].P9.C + Cams[num8].CamPoints[num21].GCodeOffset.C, 0.0, 0, Cams[num8]);
								if ((postProcessor_0.CDef.AdditionalData.Length > 0) & !Cams[num8].CamPoints[num21].Points[num23].DontUseAdditionalCommand)
								{
									string text43 = new string(' ', postProcessor_0.CDef.SpaceWithAdditionalData);
									string AddtionalString7 = postProcessor_0.CDef.AdditionalData;
									GetPostParameter(ref AddtionalString7, Cams[num8].CamPoints[num21].Points[num23]);
									text6 = text6 + AddtionalString7 + text43;
								}
							}
							if (flag)
							{
								if (!postProcessor_0.AxesUsing.U)
								{
									text7 = "";
									pnt9DCam.P9.U = 0.0;
								}
								else
								{
									text7 = ValueFormat(postProcessor_0, "U", Cams[num8].CamPoints[num21].Points[num23].P9.U + Cams[num8].CamPoints[num21].GCodeOffset.U, 0.0, 0, Cams[num8]);
									if ((postProcessor_0.UDef.AdditionalData.Length > 0) & !Cams[num8].CamPoints[num21].Points[num23].DontUseAdditionalCommand)
									{
										string text44 = new string(' ', postProcessor_0.UDef.SpaceWithAdditionalData);
										string AddtionalString8 = postProcessor_0.UDef.AdditionalData;
										GetPostParameter(ref AddtionalString8, Cams[num8].CamPoints[num21].Points[num23]);
										text7 = text7 + AddtionalString8 + text44;
									}
								}
								if (!postProcessor_0.AxesUsing.V)
								{
									text8 = "";
									pnt9DCam.P9.V = 0.0;
								}
								else
								{
									text8 = ValueFormat(postProcessor_0, "V", Cams[num8].CamPoints[num21].Points[num23].P9.V + Cams[num8].CamPoints[num21].GCodeOffset.V, 0.0, 0, Cams[num8]);
									if ((postProcessor_0.VDef.AdditionalData.Length > 0) & !Cams[num8].CamPoints[num21].Points[num23].DontUseAdditionalCommand)
									{
										string text45 = new string(' ', postProcessor_0.VDef.SpaceWithAdditionalData);
										string AddtionalString9 = postProcessor_0.VDef.AdditionalData;
										GetPostParameter(ref AddtionalString9, Cams[num8].CamPoints[num21].Points[num23]);
										text8 = text8 + AddtionalString9 + text45;
									}
								}
								if (!postProcessor_0.AxesUsing.W)
								{
									text9 = "";
									pnt9DCam.P9.W = 0.0;
								}
								else
								{
									text9 = ValueFormat(postProcessor_0, "W", Cams[num8].CamPoints[num21].Points[num23].P9.W + Cams[num8].CamPoints[num21].GCodeOffset.W, 0.0, 0, Cams[num8]);
									if ((postProcessor_0.WDef.AdditionalData.Length > 0) & !Cams[num8].CamPoints[num21].Points[num23].DontUseAdditionalCommand)
									{
										string text46 = new string(' ', postProcessor_0.WDef.SpaceWithAdditionalData);
										string AddtionalString10 = postProcessor_0.WDef.AdditionalData;
										GetPostParameter(ref AddtionalString10, Cams[num8].CamPoints[num21].Points[num23]);
										text9 = text9 + AddtionalString10 + text46;
									}
								}
							}
							if (!Cams[num8].CamPoints[num21].Points[num23].EnableAxes.X)
							{
								text = "";
								pnt9DCam.P9.X = 0.0;
							}
							if (!Cams[num8].CamPoints[num21].Points[num23].EnableAxes.Y)
							{
								text2 = "";
								pnt9DCam.P9.Y = 0.0;
							}
							if (!Cams[num8].CamPoints[num21].Points[num23].EnableAxes.Z)
							{
								text3 = "";
								pnt9DCam.P9.Z = 0.0;
							}
							if (!Cams[num8].CamPoints[num21].Points[num23].EnableAxes.A)
							{
								text4 = "";
								pnt9DCam.P9.A = 0.0;
							}
							if (!Cams[num8].CamPoints[num21].Points[num23].EnableAxes.B)
							{
								text5 = "";
								pnt9DCam.P9.B = 0.0;
							}
							if (!Cams[num8].CamPoints[num21].Points[num23].EnableAxes.C)
							{
								text6 = "";
								pnt9DCam.P9.C = 0.0;
							}
							if (!Cams[num8].CamPoints[num21].Points[num23].EnableAxes.U)
							{
								text7 = "";
								pnt9DCam.P9.U = 0.0;
							}
							if (!Cams[num8].CamPoints[num21].Points[num23].EnableAxes.V)
							{
								text8 = "";
								pnt9DCam.P9.V = 0.0;
							}
							if (!Cams[num8].CamPoints[num21].Points[num23].EnableAxes.W)
							{
								text9 = "";
								pnt9DCam.P9.W = 0.0;
							}
							if (pnt9DCam != null)
							{
								if (!postProcessor_0.RepetitionDef.Command && Cams[num8].CamPoints[num21].Points[num23].Type == pnt9DCam.Type)
								{
									if (Cams[num8].CamPoints[num21].Points[num23].Type == 2)
									{
										if (Cams[num8].CamPoints[num21].Points[num23].ArcType == pnt9DCam.ArcType && num19 == 0 && num20 == 0)
										{
											text12 = "";
										}
									}
									else if (num19 == 0 && num20 == 0)
									{
										text12 = "";
									}
								}
								if (!postProcessor_0.RepetitionDef.Feed && ((num == pnt9DCam.Feed) & (Cams[num8].CamPoints[num21].Points[num23].Type == pnt9DCam.Type)))
								{
									text13 = "";
								}
								if (!postProcessor_0.G0Propery.UseFeedSpeed && Cams[num8].CamPoints[num21].Points[num23].Type == 0)
								{
									text13 = "";
								}
								if (!postProcessor_0.RepetitionDef.Coordinate & !Cams[num8].CamPoints[num21].ForceWriteAllCoordinate)
								{
									if (buCompare.EQ(Cams[num8].CamPoints[num21].Points[num23].P9.X, pnt9DCam.P9.X, resolution) & !postProcessor_0.RepetitionDef.AxesRepetation.X)
									{
										text = "";
									}
									if (buCompare.EQ(Cams[num8].CamPoints[num21].Points[num23].P9.Y, pnt9DCam.P9.Y, resolution2) & !postProcessor_0.RepetitionDef.AxesRepetation.Y)
									{
										text2 = "";
									}
									if (buCompare.EQ(Cams[num8].CamPoints[num21].Points[num23].P9.Z, pnt9DCam.P9.Z, resolution3) & !postProcessor_0.RepetitionDef.AxesRepetation.Z)
									{
										text3 = "";
									}
									if (buCompare.EQ(Cams[num8].CamPoints[num21].Points[num23].P9.A, pnt9DCam.P9.A, resolution4) & !postProcessor_0.RepetitionDef.AxesRepetation.A)
									{
										text4 = "";
									}
									if (buCompare.EQ(Cams[num8].CamPoints[num21].Points[num23].P9.B, pnt9DCam.P9.B, resolution5) & !postProcessor_0.RepetitionDef.AxesRepetation.B)
									{
										text5 = "";
									}
									if (buCompare.EQ(Cams[num8].CamPoints[num21].Points[num23].P9.C, pnt9DCam.P9.C, resolution6) & !postProcessor_0.RepetitionDef.AxesRepetation.C)
									{
										text6 = "";
									}
									if (flag)
									{
										if (buCompare.EQ(Cams[num8].CamPoints[num21].Points[num23].P9.U, pnt9DCam.P9.U, resolution7) & !postProcessor_0.RepetitionDef.AxesRepetation.U)
										{
											text7 = "";
										}
										if (buCompare.EQ(Cams[num8].CamPoints[num21].Points[num23].P9.V, pnt9DCam.P9.V, resolution8) & !postProcessor_0.RepetitionDef.AxesRepetation.V)
										{
											text8 = "";
										}
										if (buCompare.EQ(Cams[num8].CamPoints[num21].Points[num23].P9.W, pnt9DCam.P9.W, resolution9) & !postProcessor_0.RepetitionDef.AxesRepetation.W)
										{
											text9 = "";
										}
									}
								}
							}
							if (!flag)
							{
								if (buCompare.EQ(new Pnt6D(Cams[num8].CamPoints[num21].Points[num23].P9), new Pnt6D(pnt9DCam.P9)))
								{
									text = "";
									text2 = "";
									text3 = "";
									text4 = "";
									text5 = "";
									text6 = "";
									text7 = "";
									text8 = "";
									text9 = "";
								}
							}
							else if (buCompare.EQ(Cams[num8].CamPoints[num21].Points[num23].P9, pnt9DCam.P9))
							{
								text = "";
								text2 = "";
								text3 = "";
								text4 = "";
								text5 = "";
								text6 = "";
								text7 = "";
								text8 = "";
								text9 = "";
							}
							if (!postProcessor_0.UseFCode)
							{
								text13 = "";
							}
							if ((Cams[num8].CamPoints[num21].Points[num23].Type != 2) & (Cams[num8].CamPoints[num21].Points[num23].Type != 3))
							{
								text14 = "";
								text15 = "";
								text16 = "";
								text17 = "";
							}
							if (Cams[num8].CamPoints[num21].Points[num23].PlungeAxisMovement)
							{
								if (Cams[num8].CamPoints[num21].Points[num23].PlungeAxis == "Z")
								{
									text = "";
									text2 = "";
									text4 = "";
									text5 = "";
									text6 = "";
									text7 = "";
									text8 = "";
									text9 = "";
								}
								if (Cams[num8].CamPoints[num21].Points[num23].PlungeAxis == "X")
								{
									text3 = "";
									text2 = "";
									text4 = "";
									text5 = "";
									text6 = "";
									text7 = "";
									text8 = "";
									text9 = "";
								}
								if (Cams[num8].CamPoints[num21].Points[num23].PlungeAxis == "Y")
								{
									text = "";
									text3 = "";
									text4 = "";
									text5 = "";
									text6 = "";
									text7 = "";
									text8 = "";
									text9 = "";
								}
								num4++;
							}
							if (Cams[num8].CamPoints[num21].Points[num23].LeaveAxisMovement)
							{
								if (Cams[num8].CamPoints[num21].Points[num23].PlungeAxis == "Z")
								{
									text = "";
									text2 = "";
									text4 = "";
									text5 = "";
									text6 = "";
									text7 = "";
									text8 = "";
									text9 = "";
								}
								if (Cams[num8].CamPoints[num21].Points[num23].PlungeAxis == "X")
								{
									text3 = "";
									text2 = "";
									text4 = "";
									text5 = "";
									text6 = "";
									text7 = "";
									text8 = "";
									text9 = "";
								}
								if (Cams[num8].CamPoints[num21].Points[num23].PlungeAxis == "Y")
								{
									text = "";
									text3 = "";
									text4 = "";
									text5 = "";
									text6 = "";
									text7 = "";
									text8 = "";
									text9 = "";
								}
								num5++;
							}
							text34 = text + text2 + text3 + text4 + text5 + text6 + text7 + text8 + text9;
							text35 = text12 + text34 + text14 + text15 + text16 + text17 + text13;
							if (num4 == 1 && !flag2)
							{
								for (int num25 = 0; num25 <= postProcessor_0.FirstPlungePreCodes.Count - 1; num25++)
								{
									string text47 = postProcessor_0.FirstPlungePreCodes[num25].ToString().Trim();
									if (text47.Length > 0)
									{
										AddCode(ref Codes, text47, postProcessor_0, position);
										flag2 = true;
									}
								}
							}
							if (num5 == Cams[num8].CamPoints[num21].NumberOfLeaveMovement && !flag4)
							{
								for (int num26 = 0; num26 <= postProcessor_0.LastLeavePreCodes.Count - 1; num26++)
								{
									string text48 = postProcessor_0.LastLeavePreCodes[num26].ToString().Trim();
									if (text48.Length > 0)
									{
										AddCode(ref Codes, text48, postProcessor_0, position);
										flag4 = true;
									}
								}
							}
							if (text.Length > 0)
							{
								pnt9DCam.P9.X = Cams[num8].CamPoints[num21].Points[num23].P9.X;
							}
							if (text2.Length > 0)
							{
								pnt9DCam.P9.Y = Cams[num8].CamPoints[num21].Points[num23].P9.Y;
							}
							if (text3.Length > 0)
							{
								pnt9DCam.P9.Z = Cams[num8].CamPoints[num21].Points[num23].P9.Z;
							}
							if (text4.Length > 0)
							{
								pnt9DCam.P9.A = Cams[num8].CamPoints[num21].Points[num23].P9.A;
							}
							if (text5.Length > 0)
							{
								pnt9DCam.P9.B = Cams[num8].CamPoints[num21].Points[num23].P9.B;
							}
							if (text6.Length > 0)
							{
								pnt9DCam.P9.C = Cams[num8].CamPoints[num21].Points[num23].P9.C;
							}
							if (flag)
							{
								if (text7.Length > 0)
								{
									pnt9DCam.P9.U = Cams[num8].CamPoints[num21].Points[num23].P9.U;
								}
								if (text8.Length > 0)
								{
									pnt9DCam.P9.V = Cams[num8].CamPoints[num21].Points[num23].P9.V;
								}
								if (text9.Length > 0)
								{
									pnt9DCam.P9.W = Cams[num8].CamPoints[num21].Points[num23].P9.W;
								}
							}
							if (text34.Length > 0)
							{
								if (pnt9DCam != null)
								{
									if (num23 > 0 && ((Cams[num8].CamPoints[num21].Points[num23].Type != 0) & (pnt9DCam.Type == 0) & postProcessor_0.G0Propery.AuxCodeForLastFallingG0.Enable & (postProcessor_0.G0Propery.AuxCodeForLastFallingG0.PreCode.Count > 0)))
									{
										for (int num27 = 0; num27 <= postProcessor_0.G0Propery.AuxCodeForLastFallingG0.PreCode.Count - 1; num27++)
										{
											string text49 = postProcessor_0.G0Propery.AuxCodeForLastFallingG0.PreCode[num27].ToString().Trim();
											if (text49.Length > 0)
											{
												AddCode(ref Codes, text49, postProcessor_0, position);
											}
										}
									}
									if ((Cams[num8].CamPoints[num21].Points[num23].Type == 0) & (pnt9DCam.Type != 0) & postProcessor_0.G0Propery.AuxCodeForFirstRisingG0.Enable & (postProcessor_0.G0Propery.AuxCodeForFirstRisingG0.PreCode.Count > 0))
									{
										for (int num28 = 0; num28 <= postProcessor_0.G0Propery.AuxCodeForFirstRisingG0.PreCode.Count - 1; num28++)
										{
											string text50 = postProcessor_0.G0Propery.AuxCodeForFirstRisingG0.PreCode[num28].ToString().Trim();
											if (text50.Length > 0)
											{
												AddCode(ref Codes, text50, postProcessor_0, position);
											}
										}
									}
									if ((Cams[num8].CamPoints[num21].Points[num23].Type == 0) & postProcessor_0.G0Propery.AuxCodeForAllG0.Enable & (postProcessor_0.G0Propery.AuxCodeForAllG0.PreCode.Count > 0))
									{
										for (int num29 = 0; num29 <= postProcessor_0.G0Propery.AuxCodeForAllG0.PreCode.Count - 1; num29++)
										{
											string text51 = postProcessor_0.G0Propery.AuxCodeForAllG0.PreCode[num29].ToString().Trim();
											if (text51.Length > 0)
											{
												AddCode(ref Codes, text51, postProcessor_0, position);
											}
										}
									}
									if (((Cams[num8].CamPoints[num21].Points[num23].Type == 1) | (Cams[num8].CamPoints[num21].Points[num23].Type == 2) | (Cams[num8].CamPoints[num21].Points[num23].Type == 3)) & ((pnt9DCam.Type != 1) & (pnt9DCam.Type != 2) & (pnt9DCam.Type != 3)) & postProcessor_0.G1G2G3Propery.AuxCodeForFirstRisingG1G2G3.Enable & (postProcessor_0.G1G2G3Propery.AuxCodeForFirstRisingG1G2G3.PreCode.Count > 0))
									{
										for (int num30 = 0; num30 <= postProcessor_0.G1G2G3Propery.AuxCodeForFirstRisingG1G2G3.PreCode.Count - 1; num30++)
										{
											string text52 = postProcessor_0.G1G2G3Propery.AuxCodeForFirstRisingG1G2G3.PreCode[num30].ToString().Trim();
											if (text52.Length > 0)
											{
												AddCode(ref Codes, text52, postProcessor_0, position);
											}
										}
									}
									if (((Cams[num8].CamPoints[num21].Points[num23].Type == 1) | (Cams[num8].CamPoints[num21].Points[num23].Type == 2) | (Cams[num8].CamPoints[num21].Points[num23].Type == 3)) & postProcessor_0.G1G2G3Propery.AuxCodeForAllG1G2G3.Enable & (postProcessor_0.G1G2G3Propery.AuxCodeForAllG1G2G3.PreCode.Count > 0))
									{
										for (int num31 = 0; num31 <= postProcessor_0.G1G2G3Propery.AuxCodeForAllG1G2G3.PreCode.Count - 1; num31++)
										{
											string text53 = postProcessor_0.G1G2G3Propery.AuxCodeForAllG1G2G3.PreCode[num31].ToString().Trim();
											if (text53.Length > 0)
											{
												AddCode(ref Codes, text53, postProcessor_0, position);
											}
										}
									}
									if ((Cams[num8].CamPoints[num21].Points[num23].Type == 1) & (pnt9DCam.Type != 1) & postProcessor_0.G1Propery.AuxCodeForFirstRisingG1.Enable & (postProcessor_0.G1Propery.AuxCodeForFirstRisingG1.PreCode.Count > 0))
									{
										for (int num32 = 0; num32 <= postProcessor_0.G1Propery.AuxCodeForFirstRisingG1.PreCode.Count - 1; num32++)
										{
											string text54 = postProcessor_0.G1Propery.AuxCodeForFirstRisingG1.PreCode[num32].ToString().Trim();
											if (text54.Length > 0)
											{
												AddCode(ref Codes, text54, postProcessor_0, position);
											}
										}
									}
									if ((Cams[num8].CamPoints[num21].Points[num23].Type == 1) & postProcessor_0.G1Propery.AuxCodeForAllG1.Enable & (postProcessor_0.G1Propery.AuxCodeForAllG1.PreCode.Count > 0))
									{
										for (int num33 = 0; num33 <= postProcessor_0.G1Propery.AuxCodeForAllG1.PreCode.Count - 1; num33++)
										{
											string text55 = postProcessor_0.G1Propery.AuxCodeForAllG1.PreCode[num33].ToString().Trim();
											if (text55.Length > 0)
											{
												AddCode(ref Codes, text55, postProcessor_0, position);
											}
										}
									}
									if ((Cams[num8].CamPoints[num21].Points[num23].Type == 2) & (pnt9DCam.Type != 2) & postProcessor_0.G2Propery.AuxCodeForFirstRisingG2.Enable & (postProcessor_0.G2Propery.AuxCodeForFirstRisingG2.PreCode.Count > 0))
									{
										for (int num34 = 0; num34 <= postProcessor_0.G2Propery.AuxCodeForFirstRisingG2.PreCode.Count - 1; num34++)
										{
											string text56 = postProcessor_0.G2Propery.AuxCodeForFirstRisingG2.PreCode[num34].ToString().Trim();
											if (text56.Length > 0)
											{
												AddCode(ref Codes, text56, postProcessor_0, position);
											}
										}
									}
									if ((Cams[num8].CamPoints[num21].Points[num23].Type == 2) & postProcessor_0.G2Propery.AuxCodeForAllG2.Enable & (postProcessor_0.G2Propery.AuxCodeForAllG2.PreCode.Count > 0))
									{
										for (int num35 = 0; num35 <= postProcessor_0.G2Propery.AuxCodeForAllG2.PreCode.Count - 1; num35++)
										{
											string text57 = postProcessor_0.G2Propery.AuxCodeForAllG2.PreCode[num35].ToString().Trim();
											if (text57.Length > 0)
											{
												AddCode(ref Codes, text57, postProcessor_0, position);
											}
										}
									}
									if ((Cams[num8].CamPoints[num21].Points[num23].Type == 3) & (pnt9DCam.Type != 3) & postProcessor_0.G3Propery.AuxCodeForFirstRisingG3.Enable & (postProcessor_0.G3Propery.AuxCodeForFirstRisingG3.PreCode.Count > 0))
									{
										for (int num36 = 0; num36 <= postProcessor_0.G3Propery.AuxCodeForFirstRisingG3.PreCode.Count - 1; num36++)
										{
											string text58 = postProcessor_0.G3Propery.AuxCodeForFirstRisingG3.PreCode[num36].ToString().Trim();
											if (text58.Length > 0)
											{
												AddCode(ref Codes, text58, postProcessor_0, position);
											}
										}
									}
									if ((Cams[num8].CamPoints[num21].Points[num23].Type == 3) & postProcessor_0.G3Propery.AuxCodeForAllG3.Enable & (postProcessor_0.G3Propery.AuxCodeForAllG3.PreCode.Count > 0))
									{
										for (int num37 = 0; num37 <= postProcessor_0.G3Propery.AuxCodeForAllG3.PreCode.Count - 1; num37++)
										{
											string text59 = postProcessor_0.G3Propery.AuxCodeForAllG3.PreCode[num37].ToString().Trim();
											if (text59.Length > 0)
											{
												AddCode(ref Codes, text59, postProcessor_0, position);
											}
										}
									}
								}
								AddCode(ref Codes, text35, postProcessor_0, gCodeEntity, position);
								if (text3.Length > 0 && postProcessor_0.UseToolHeightOffsetAfterZMove)
								{
									if (num21 < Cams[num8].CamPoints.Count - 1)
									{
										AddCode(ref Codes, "M75", postProcessor_0, position);
									}
									AddCode(ref Codes, "G43 H" + Cams[num8].Tool.Data.HeightOffsetIndex + " " + text3, postProcessor_0, position);
								}
								if (pnt9DCam == null)
								{
									pnt9DCam = new Pnt9DCam();
								}
								if (pnt9DCam != null)
								{
									if ((Cams[num8].CamPoints[num21].Points[num23].Type == 0) & (pnt9DCam.Type != 0) & postProcessor_0.G0Propery.AuxCodeForFirstRisingG0.Enable & (postProcessor_0.G0Propery.AuxCodeForFirstRisingG0.AfterCode.Count > 0))
									{
										for (int num38 = 0; num38 <= postProcessor_0.G0Propery.AuxCodeForFirstRisingG0.AfterCode.Count - 1; num38++)
										{
											string text60 = postProcessor_0.G0Propery.AuxCodeForFirstRisingG0.AfterCode[num38].ToString().Trim();
											if (text60.Length > 0)
											{
												AddCode(ref Codes, text60, postProcessor_0, position);
											}
										}
									}
									if ((Cams[num8].CamPoints[num21].Points[num23].Type != 0) & (pnt9DCam.Type == 0) & postProcessor_0.G0Propery.AuxCodeForLastFallingG0.Enable & (postProcessor_0.G0Propery.AuxCodeForLastFallingG0.AfterCode.Count > 0))
									{
										for (int num39 = 0; num39 <= postProcessor_0.G0Propery.AuxCodeForLastFallingG0.AfterCode.Count - 1; num39++)
										{
											string text61 = postProcessor_0.G0Propery.AuxCodeForLastFallingG0.AfterCode[num39].ToString().Trim();
											if (text61.Length > 0)
											{
												AddCode(ref Codes, text61, postProcessor_0, position);
											}
										}
									}
									if ((Cams[num8].CamPoints[num21].Points[num23].Type == 0) & postProcessor_0.G0Propery.AuxCodeForAllG0.Enable & (postProcessor_0.G0Propery.AuxCodeForAllG0.AfterCode.Count > 0))
									{
										for (int num40 = 0; num40 <= postProcessor_0.G0Propery.AuxCodeForAllG0.AfterCode.Count - 1; num40++)
										{
											string text62 = postProcessor_0.G0Propery.AuxCodeForAllG0.AfterCode[num40].ToString().Trim();
											if (text62.Length > 0)
											{
												AddCode(ref Codes, text62, postProcessor_0, position);
											}
										}
									}
									if (((Cams[num8].CamPoints[num21].Points[num23].Type == 1) | (Cams[num8].CamPoints[num21].Points[num23].Type == 2) | (Cams[num8].CamPoints[num21].Points[num23].Type == 3)) & ((pnt9DCam.Type != 1) & (pnt9DCam.Type != 2) & (pnt9DCam.Type != 3)) & postProcessor_0.G1G2G3Propery.AuxCodeForFirstRisingG1G2G3.Enable & (postProcessor_0.G1G2G3Propery.AuxCodeForFirstRisingG1G2G3.AfterCode.Count > 0))
									{
										for (int num41 = 0; num41 <= postProcessor_0.G1G2G3Propery.AuxCodeForFirstRisingG1G2G3.AfterCode.Count - 1; num41++)
										{
											string text63 = postProcessor_0.G1G2G3Propery.AuxCodeForFirstRisingG1G2G3.AfterCode[num41].ToString().Trim();
											if (text63.Length > 0)
											{
												AddCode(ref Codes, text63, postProcessor_0, position);
											}
										}
									}
									if (((Cams[num8].CamPoints[num21].Points[num23].Type == 1) | (Cams[num8].CamPoints[num21].Points[num23].Type == 2) | (Cams[num8].CamPoints[num21].Points[num23].Type == 3)) & postProcessor_0.G1G2G3Propery.AuxCodeForAllG1G2G3.Enable & (postProcessor_0.G1G2G3Propery.AuxCodeForAllG1G2G3.AfterCode.Count > 0))
									{
										for (int num42 = 0; num42 <= postProcessor_0.G1G2G3Propery.AuxCodeForAllG1G2G3.AfterCode.Count - 1; num42++)
										{
											string text64 = postProcessor_0.G1G2G3Propery.AuxCodeForAllG1G2G3.AfterCode[num42].ToString().Trim();
											if (text64.Length > 0)
											{
												AddCode(ref Codes, text64, postProcessor_0, position);
											}
										}
									}
									if ((Cams[num8].CamPoints[num21].Points[num23].Type == 1) & (pnt9DCam.Type != 1) & postProcessor_0.G1Propery.AuxCodeForFirstRisingG1.Enable & (postProcessor_0.G1Propery.AuxCodeForFirstRisingG1.AfterCode.Count > 0))
									{
										for (int num43 = 0; num43 <= postProcessor_0.G1Propery.AuxCodeForFirstRisingG1.AfterCode.Count - 1; num43++)
										{
											string text65 = postProcessor_0.G1Propery.AuxCodeForFirstRisingG1.AfterCode[num43].ToString().Trim();
											if (text65.Length > 0)
											{
												AddCode(ref Codes, text65, postProcessor_0, position);
											}
										}
									}
									if ((Cams[num8].CamPoints[num21].Points[num23].Type == 1) & postProcessor_0.G1Propery.AuxCodeForAllG1.Enable & (postProcessor_0.G1Propery.AuxCodeForAllG1.AfterCode.Count > 0))
									{
										for (int num44 = 0; num44 <= postProcessor_0.G1Propery.AuxCodeForAllG1.AfterCode.Count - 1; num44++)
										{
											string text66 = postProcessor_0.G1Propery.AuxCodeForAllG1.AfterCode[num44].ToString().Trim();
											if (text66.Length > 0)
											{
												AddCode(ref Codes, text66, postProcessor_0, position);
											}
										}
									}
									if ((Cams[num8].CamPoints[num21].Points[num23].Type == 2) & (pnt9DCam.Type != 2) & postProcessor_0.G2Propery.AuxCodeForFirstRisingG2.Enable & (postProcessor_0.G2Propery.AuxCodeForFirstRisingG2.AfterCode.Count > 0))
									{
										for (int num45 = 0; num45 <= postProcessor_0.G2Propery.AuxCodeForFirstRisingG2.AfterCode.Count - 1; num45++)
										{
											string text67 = postProcessor_0.G2Propery.AuxCodeForFirstRisingG2.AfterCode[num45].ToString().Trim();
											if (text67.Length > 0)
											{
												AddCode(ref Codes, text67, postProcessor_0, position);
											}
										}
									}
									if ((Cams[num8].CamPoints[num21].Points[num23].Type == 2) & postProcessor_0.G2Propery.AuxCodeForAllG2.Enable & (postProcessor_0.G2Propery.AuxCodeForAllG2.AfterCode.Count > 0))
									{
										for (int num46 = 0; num46 <= postProcessor_0.G2Propery.AuxCodeForAllG2.AfterCode.Count - 1; num46++)
										{
											string text68 = postProcessor_0.G2Propery.AuxCodeForAllG2.AfterCode[num46].ToString().Trim();
											if (text68.Length > 0)
											{
												AddCode(ref Codes, text68, postProcessor_0, position);
											}
										}
									}
									if ((Cams[num8].CamPoints[num21].Points[num23].Type == 3) & (pnt9DCam.Type != 3) & postProcessor_0.G3Propery.AuxCodeForFirstRisingG3.Enable & (postProcessor_0.G3Propery.AuxCodeForFirstRisingG3.AfterCode.Count > 0))
									{
										for (int num47 = 0; num47 <= postProcessor_0.G3Propery.AuxCodeForFirstRisingG3.AfterCode.Count - 1; num47++)
										{
											string text69 = postProcessor_0.G3Propery.AuxCodeForFirstRisingG3.AfterCode[num47].ToString().Trim();
											if (text69.Length > 0)
											{
												AddCode(ref Codes, text69, postProcessor_0, position);
											}
										}
									}
									if ((Cams[num8].CamPoints[num21].Points[num23].Type == 3) & postProcessor_0.G3Propery.AuxCodeForAllG3.Enable & (postProcessor_0.G3Propery.AuxCodeForAllG3.AfterCode.Count > 0))
									{
										for (int num48 = 0; num48 <= postProcessor_0.G3Propery.AuxCodeForAllG3.AfterCode.Count - 1; num48++)
										{
											string text70 = postProcessor_0.G3Propery.AuxCodeForAllG3.AfterCode[num48].ToString().Trim();
											if (text70.Length > 0)
											{
												AddCode(ref Codes, text70, postProcessor_0, position);
											}
										}
									}
								}
								pnt9DCam.Type = Cams[num8].CamPoints[num21].Points[num23].Type;
								pnt9DCam.ArcType = Cams[num8].CamPoints[num21].Points[num23].ArcType;
								pnt9DCam.Feed = num;
							}
							for (int num49 = 0; num49 <= Cams[num8].CamPoints[num21].Points[num23].AfterCodes.Count - 1; num49++)
							{
								string text71 = Cams[num8].CamPoints[num21].Points[num23].AfterCodes[num49].ToString().Trim();
								if (text71.Length > 0)
								{
									AddCode(ref Codes, text71, postProcessor_0, position);
								}
							}
							if (num4 == 1 && !flag3)
							{
								for (int num50 = 0; num50 <= postProcessor_0.FirstPlungeAfterCodes.Count - 1; num50++)
								{
									string text72 = postProcessor_0.FirstPlungeAfterCodes[num50].ToString().Trim();
									if (text72.Length > 0)
									{
										AddCode(ref Codes, text72, postProcessor_0, position);
										flag3 = true;
									}
								}
							}
							if (num5 == Cams[num8].CamPoints[num21].NumberOfLeaveMovement && !flag5)
							{
								for (int num51 = 0; num51 <= postProcessor_0.LastLeaveAfterCodes.Count - 1; num51++)
								{
									string text73 = postProcessor_0.LastLeaveAfterCodes[num51].ToString().Trim();
									if (text73.Length > 0)
									{
										AddCode(ref Codes, text73, postProcessor_0, position);
										flag5 = true;
									}
								}
							}
							if (Codes.Length > 1000)
							{
								arrayList.Add(Codes);
								Codes = "";
							}
							if (buSystem.DoEventEnable && num6 > 0 && num3 > 0 && num3 % num6 == 0)
							{
								Application.DoEvents();
								if (buSystem.ProgressControlEnable && calculationEventHandler_0 != null)
								{
									calculationEventHandler_0(new CalculationEventArg(100.0, Convert.ToDouble((double)num3 / (double)num2) * 100.0, 0, "", ""));
								}
							}
							if (!buSystem.Cancel)
							{
								num19 = Cams[num8].CamPoints[num21].Points[num23].AfterCodes.Count;
								continue;
							}
							buSystem.Cancel = false;
							buSystem.Canceled = true;
							if (calculationEventHandler_0 != null)
							{
								calculationEventHandler_0(new CalculationEventArg(100.0, 100.0, 0, "", "", done: true));
							}
							buLog.addLog("G Code Creat", "Canceled", MethodBase.GetCurrentMethod().Name);
							return;
						}
						for (int num52 = 0; num52 <= Cams[num8].CamPoints[num21].AfterCodes.Count - 1; num52++)
						{
							string text74 = Cams[num8].CamPoints[num21].AfterCodes[num52].ToString().Trim();
							if (text74.Length > 0)
							{
								AddCode(ref Codes, text74, postProcessor_0, position);
							}
						}
						arrayList.Add(Codes);
						Codes = "";
					}
					if (Cams[num8].AfterCodes.Count > 0)
					{
						for (int num53 = 0; num53 <= Cams[num8].AfterCodes.Count - 1; num53++)
						{
							string text75 = Cams[num8].AfterCodes[num53].ToString().Trim();
							if (text75.Length > 0)
							{
								AddCode(ref Codes, text75, postProcessor_0, position);
							}
						}
					}
					for (int num54 = 0; num54 <= postProcessor_0.EndLinesEachBlock.Count - 1; num54++)
					{
						string text76 = postProcessor_0.EndLinesEachBlock[num54].ToString().Trim();
						if (text76.Length > 0)
						{
							AddCode(ref Codes, text76, postProcessor_0, position);
						}
					}
				}
				for (int num55 = 0; num55 <= postProcessor_0.EndLines.Count - 1; num55++)
				{
					AddCode(ref Codes, postProcessor_0.EndLines[num55].ToString(), postProcessor_0, position);
				}
				arrayList.Add(Codes);
				Codes = "";
				Lines = buString.ArrayListToString(arrayList);
				if (bool_0 && AppLanguage.SystemMessages.Count > 9)
				{
					buString.MessageBoxWarning(AppLanguage.SystemMessages[9]);
				}
			}
			else
			{
				for (int num56 = 0; num56 <= Cams[0].CreatedGCodes.Count - 1; num56++)
				{
					string newCommand4 = Cams[0].CreatedGCodes[num56].ToString();
					AddCode(ref Codes, newCommand4, Post, position);
				}
				Lines = Codes;
			}
		}
		catch (Exception mSException)
		{
			string text77 = "";
			buLog.addLog(text77, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text77);
		}
	}

	public string ValueFormat(PostProcessor P, string Code, double Value, double MoveDistance, int AxisDefIndex, camBase Cam)
	{
		try
		{
			string result = "";
			if (!((Code == "X") | (Code == "x")))
			{
				if (!((Code == "Y") | (Code == "y")))
				{
					if (!((Code == "Z") | (Code == "z")))
					{
						if (!((Code == "A") | (Code == "a")))
						{
							if (!((Code == "B") | (Code == "b")))
							{
								if (!((Code == "C") | (Code == "c")))
								{
									if (!((Code == "U") | (Code == "u")))
									{
										if (!((Code == "V") | (Code == "v")))
										{
											if (!((Code == "W") | (Code == "w")))
											{
												if (!((Code == "F") | (Code == "f") | (Code.ToLower() == P.FDef.Char.ToLower())))
												{
													if (!((Code == "R") | (Code == "r") | (Code.ToLower() == P.RDef.Char.ToLower())))
													{
														if (!((Code == "I") | (Code == "ı") | (Code.ToLower() == P.IDef.Char.ToLower())))
														{
															if (!((Code == "J") | (Code == "j") | (Code.ToLower() == P.JDef.Char.ToLower())))
															{
																if (!((Code == "K") | (Code == "k") | (Code.ToLower() == P.KDef.Char.ToLower())))
																{
																	if (!((Code == "S") | (Code == "s") | (Code.ToLower() == P.SDef.Char.ToLower())))
																	{
																		if (!((Code == "N") | (Code == "n") | (Code.ToLower() == P.NDef.Char.ToLower())))
																		{
																			return result;
																		}
																		double num = Value;
																		string text = new string(' ', P.NDef.SpaceWithCharAndValue);
																		string text2 = new string(' ', P.NDef.SpaceWithNextCommandAndValue);
																		return P.NDef.Char + text + num + text2;
																	}
																	double num2 = Math.Round(Value * P.SDef.Multiply, P.SDef.RoundCount);
																	string text3 = new string(' ', P.SDef.SpaceWithCharAndValue);
																	string text4 = new string(' ', P.SDef.SpaceWithNextCommandAndValue);
																	return P.SDef.Char + text3 + num2.ToString("f" + P.SDef.Decimal, buSystem.CI) + text4;
																}
																double num3 = Math.Round(Value, P.KDef.RoundCount);
																string text5 = new string(' ', P.KDef.SpaceWithCharAndValue);
																string text6 = new string(' ', P.KDef.SpaceWithNextCommandAndValue);
																return P.KDef.Char + text5 + num3.ToString("f" + P.KDef.Decimal, buSystem.CI) + text6;
															}
															double num4 = Math.Round(Value, P.JDef.RoundCount);
															string text7 = new string(' ', P.JDef.SpaceWithCharAndValue);
															string text8 = new string(' ', P.JDef.SpaceWithNextCommandAndValue);
															return P.JDef.Char + text7 + num4.ToString("f" + P.JDef.Decimal, buSystem.CI) + text8;
														}
														double num5 = Math.Round(Value, P.IDef.RoundCount);
														string text9 = new string(' ', P.IDef.SpaceWithCharAndValue);
														string text10 = new string(' ', P.IDef.SpaceWithNextCommandAndValue);
														return P.IDef.Char + text9 + num5.ToString("f" + P.IDef.Decimal, buSystem.CI) + text10;
													}
													double num6 = Math.Round(Value, P.RDef.RoundCount);
													string text11 = new string(' ', P.RDef.SpaceWithCharAndValue);
													string text12 = new string(' ', P.RDef.SpaceWithNextCommandAndValue);
													return P.RDef.Char + text11 + num6.ToString("f" + P.RDef.Decimal, buSystem.CI) + text12;
												}
												double num7 = Value * P.FDef.Multiply;
												string text13 = new string(' ', P.FDef.SpaceWithCharAndValue);
												string text14 = new string(' ', P.FDef.SpaceWithNextCommandAndValue);
												return P.FDef.Char + text13 + num7.ToString("f" + P.FDef.Decimal, buSystem.CI) + text14;
											}
											double num8 = Math.Round(Value * P.WDef.Multiply + MoveDistance, P.WDef.RoundCount);
											string text15 = new string(' ', P.WDef.SpaceWithCharAndValue);
											string text16 = new string(' ', P.WDef.SpaceWithNextCommandAndValue);
											return P.WDef.Char + text15 + num8.ToString("f" + P.WDef.Decimal, buSystem.CI) + text16;
										}
										double num9 = Math.Round(Value * P.VDef.Multiply + MoveDistance, P.VDef.RoundCount);
										string text17 = new string(' ', P.VDef.SpaceWithCharAndValue);
										string text18 = new string(' ', P.VDef.SpaceWithNextCommandAndValue);
										return P.VDef.Char + text17 + num9.ToString("f" + P.VDef.Decimal, buSystem.CI) + text18;
									}
									double num10 = Math.Round(Value * P.UDef.Multiply + MoveDistance, P.UDef.RoundCount);
									string text19 = new string(' ', P.UDef.SpaceWithCharAndValue);
									string text20 = new string(' ', P.UDef.SpaceWithNextCommandAndValue);
									return P.UDef.Char + text19 + num10.ToString("f" + P.UDef.Decimal, buSystem.CI) + text20;
								}
								double num11 = Math.Round(Value * P.CDef.Multiply + MoveDistance, P.CDef.RoundCount);
								string text21 = new string(' ', P.CDef.SpaceWithCharAndValue);
								string text22 = new string(' ', P.CDef.SpaceWithNextCommandAndValue);
								return P.CDef.Char + text21 + num11.ToString("f" + P.CDef.Decimal, buSystem.CI) + text22;
							}
							double num12 = Math.Round(Value * P.BDef.Multiply + MoveDistance, P.BDef.RoundCount);
							string text23 = new string(' ', P.BDef.SpaceWithCharAndValue);
							string text24 = new string(' ', P.BDef.SpaceWithNextCommandAndValue);
							return P.BDef.Char + text23 + num12.ToString("f" + P.BDef.Decimal, buSystem.CI) + text24;
						}
						double num13 = Math.Round(Value * P.ADef.Multiply + MoveDistance, P.ADef.RoundCount);
						string text25 = new string(' ', P.ADef.SpaceWithCharAndValue);
						string text26 = new string(' ', P.ADef.SpaceWithNextCommandAndValue);
						return P.ADef.Char + text25 + num13.ToString("f" + P.ADef.Decimal, buSystem.CI) + text26;
					}
					string text27 = P.ZDef.Char;
					if (Cam != null && Cam.ForceAxisString.Z.Length > 0)
					{
						text27 = Cam.ForceAxisString.Z;
					}
					if (AxisDefIndex == 0)
					{
						double num14 = Math.Round(Value * P.ZDef.Multiply + MoveDistance, P.ZDef.RoundCount);
						string text28 = new string(' ', P.ZDef.SpaceWithCharAndValue);
						string text29 = new string(' ', P.ZDef.SpaceWithNextCommandAndValue);
						result = text27 + text28 + num14.ToString("f" + P.ZDef.Decimal, buSystem.CI) + text29;
					}
					if (AxisDefIndex == 1)
					{
						double num15 = Math.Round(Value * P.Z2Def.Multiply + MoveDistance, P.ZDef.RoundCount);
						string text30 = new string(' ', P.Z2Def.SpaceWithCharAndValue);
						string text31 = new string(' ', P.Z2Def.SpaceWithNextCommandAndValue);
						result = P.Z2Def.Char + text30 + num15.ToString("f" + P.Z2Def.Decimal, buSystem.CI) + text31;
					}
					if (AxisDefIndex == 2)
					{
						double num16 = Math.Round(Value * P.Z3Def.Multiply + MoveDistance, P.ZDef.RoundCount);
						string text32 = new string(' ', P.Z3Def.SpaceWithCharAndValue);
						string text33 = new string(' ', P.Z3Def.SpaceWithNextCommandAndValue);
						result = P.Z3Def.Char + text32 + num16.ToString("f" + P.Z3Def.Decimal, buSystem.CI) + text33;
					}
					if (AxisDefIndex == 3)
					{
						double num17 = Math.Round(Value * P.Z4Def.Multiply + MoveDistance, P.ZDef.RoundCount);
						string text34 = new string(' ', P.Z4Def.SpaceWithCharAndValue);
						string text35 = new string(' ', P.Z4Def.SpaceWithNextCommandAndValue);
						result = P.Z4Def.Char + text34 + num17.ToString("f" + P.Z4Def.Decimal, buSystem.CI) + text35;
					}
					return result;
				}
				if (AxisDefIndex == 0)
				{
					double num18 = Math.Round(Value * P.YDef.Multiply + MoveDistance, P.YDef.RoundCount);
					string text36 = new string(' ', P.YDef.SpaceWithCharAndValue);
					string text37 = new string(' ', P.YDef.SpaceWithNextCommandAndValue);
					result = P.YDef.Char + text36 + num18.ToString("f" + P.YDef.Decimal, buSystem.CI) + text37;
				}
				if (AxisDefIndex == 1)
				{
					double num19 = Math.Round(Value * P.Y2Def.Multiply + MoveDistance, P.YDef.RoundCount);
					string text38 = new string(' ', P.Y2Def.SpaceWithCharAndValue);
					string text39 = new string(' ', P.Y2Def.SpaceWithNextCommandAndValue);
					result = P.Y2Def.Char + text38 + num19.ToString("f" + P.Y2Def.Decimal, buSystem.CI) + text39;
				}
				if (AxisDefIndex == 2)
				{
					double num20 = Math.Round(Value * P.Y3Def.Multiply + MoveDistance, P.YDef.RoundCount);
					string text40 = new string(' ', P.Y3Def.SpaceWithCharAndValue);
					string text41 = new string(' ', P.Y3Def.SpaceWithNextCommandAndValue);
					result = P.Y3Def.Char + text40 + num20.ToString("f" + P.Y3Def.Decimal, buSystem.CI) + text41;
				}
				if (AxisDefIndex == 3)
				{
					double num21 = Math.Round(Value * P.Y4Def.Multiply + MoveDistance, P.YDef.RoundCount);
					string text42 = new string(' ', P.Y4Def.SpaceWithCharAndValue);
					string text43 = new string(' ', P.Y4Def.SpaceWithNextCommandAndValue);
					result = P.Y4Def.Char + text42 + num21.ToString("f" + P.Y4Def.Decimal, buSystem.CI) + text43;
				}
				return result;
			}
			if (AxisDefIndex == 0)
			{
				double num22 = Math.Round(Value * P.XDef.Multiply + MoveDistance, P.XDef.RoundCount);
				string text44 = new string(' ', P.XDef.SpaceWithCharAndValue);
				string text45 = new string(' ', P.XDef.SpaceWithNextCommandAndValue);
				result = P.XDef.Char + text44 + num22.ToString("f" + P.XDef.Decimal, buSystem.CI) + text45;
			}
			if (AxisDefIndex == 1)
			{
				double num23 = Math.Round(Value * P.X2Def.Multiply + MoveDistance, P.XDef.RoundCount);
				string text46 = new string(' ', P.X2Def.SpaceWithCharAndValue);
				string text47 = new string(' ', P.X2Def.SpaceWithNextCommandAndValue);
				result = P.X2Def.Char + text46 + num23.ToString("f" + P.X2Def.Decimal, buSystem.CI) + text47;
			}
			if (AxisDefIndex == 2)
			{
				double num24 = Math.Round(Value * P.X3Def.Multiply + MoveDistance, P.XDef.RoundCount);
				string text48 = new string(' ', P.X3Def.SpaceWithCharAndValue);
				string text49 = new string(' ', P.X3Def.SpaceWithNextCommandAndValue);
				result = P.X3Def.Char + text48 + num24.ToString("f" + P.X3Def.Decimal, buSystem.CI) + text49;
			}
			if (AxisDefIndex == 3)
			{
				double num25 = Math.Round(Value * P.X4Def.Multiply + MoveDistance, P.XDef.RoundCount);
				string text50 = new string(' ', P.X4Def.SpaceWithCharAndValue);
				string text51 = new string(' ', P.X4Def.SpaceWithNextCommandAndValue);
				result = P.X4Def.Char + text50 + num25.ToString("f" + P.X4Def.Decimal, buSystem.CI) + text51;
			}
			return result;
		}
		catch (Exception mSException)
		{
			string text52 = "Post: " + P.ToString() + " - Code: " + Code.ToString() + " - Value: " + Value + " - MoveDistance: " + MoveDistance + " - AxisDefIndex: " + AxisDefIndex;
			buLog.addLog(text52, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text52);
			return "";
		}
	}

	public string ValueFormat(PostProcessor P, string Code, int Value)
	{
		try
		{
			string result = "";
			if ((Code == "G") | (Code == "g"))
			{
				int num = Value;
				string text = new string(' ', P.GDef.SpaceWithCharAndValue);
				string text2 = new string(' ', P.GDef.SpaceWithNextCommandAndValue);
				result = P.GDef.Char + text + num + text2;
			}
			if ((Code == "M") | (Code == "m"))
			{
				int num2 = Value;
				string text3 = new string(' ', P.MDef.SpaceWithCharAndValue);
				string text4 = new string(' ', P.MDef.SpaceWithNextCommandAndValue);
				result = P.MDef.Char + text3 + num2 + text4;
			}
			if ((Code == "N") | (Code == "n"))
			{
				int num3 = Value;
				string text5 = new string(' ', P.NDef.SpaceWithCharAndValue);
				string text6 = new string(' ', P.NDef.SpaceWithNextCommandAndValue);
				result = P.NDef.Char + text5 + num3 + text6;
			}
			if ((Code == "T") | (Code == "t"))
			{
				double num4 = Value;
				string text7 = new string(' ', P.TDef.SpaceWithCharAndValue);
				string text8 = new string(' ', P.TDef.SpaceWithNextCommandAndValue);
				result = P.TDef.Char + text7 + num4 + text8;
			}
			return result;
		}
		catch (Exception mSException)
		{
			string text9 = "Post: " + P.ToString() + " - Code: " + Code.ToString() + " - Value: " + Value;
			buLog.addLog(text9, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text9);
			return "";
		}
	}

	public void AddCode(ref string Codes, string NewCommand, PostProcessor Post, Pnt9D Position)
	{
		try
		{
			string text = "";
			if (UsePointListForGCodeLines)
			{
				PointListVersusGCodeLines.Add(new Pnt9D(Position));
			}
			if (string_0.Length > 0 && string_0.Trim().ToLower() == NewCommand.Trim().ToLower())
			{
				return;
			}
			if (!((Post.NumberDef.Max > 0.0) & Post.NumberDef.Enable & (double_0 >= Post.NumberDef.Max)))
			{
				GCodeEntities.Add(new ePoint(new Pnt3D()));
				if (Post.NumberDef.Enable)
				{
					text = ValueFormat(Post, "N", double_0, 0.0, 0, null);
				}
				Codes = Codes + text + NewCommand + Environment.NewLine;
				double_0 += Post.NumberDef.Step;
				string_0 = NewCommand;
			}
			else
			{
				bool_0 = true;
			}
		}
		catch (Exception mSException)
		{
			if (UsePointListForGCodeLines)
			{
				PointListVersusGCodeLines.Add(new Pnt9D(Position));
			}
			string text2 = "Post: " + Post.ToString() + " - NewCommand: " + NewCommand.ToString();
			buLog.addLog(text2, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text2);
		}
	}

	public void AddCode(ref string Codes, string NewCommand, PostProcessor Post, eEntities GCodeEntity, Pnt9D Position)
	{
		try
		{
			string text = "";
			if (UsePointListForGCodeLines)
			{
				PointListVersusGCodeLines.Add(new Pnt9D(Position));
			}
			if (string_0.Length > 0 && string_0.Trim().ToLower() == NewCommand.Trim().ToLower())
			{
				return;
			}
			if (!((Post.NumberDef.Max > 0.0) & Post.NumberDef.Enable & (double_0 >= Post.NumberDef.Max)))
			{
				GCodeEntities.Add(eEntities.CopyEntity(GCodeEntity));
				if (Post.NumberDef.Enable)
				{
					text = ValueFormat(Post, "N", double_0, 0.0, 0, null);
				}
				Codes = Codes + text + NewCommand + Environment.NewLine;
				double_0 += Post.NumberDef.Step;
				string_0 = NewCommand;
			}
			else
			{
				bool_0 = true;
			}
		}
		catch (Exception mSException)
		{
			if (UsePointListForGCodeLines)
			{
				PointListVersusGCodeLines.Add(new Pnt9D(Position));
			}
			string text2 = "Post: " + Post.ToString() + " - NewCommand: " + NewCommand.ToString() + " - GCodeEntity: " + GCodeEntity.ToString();
			buLog.addLog(text2, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text2);
		}
	}

	public void GCodeConverter(GCodeConverterArgs Options, string RefCode, ref string ConvertedCode)
	{
		try
		{
			string[] Lines = null;
			ConvertedCode = "";
			buString.StringToArrayByNewLine(RefCode, ref Lines);
			double num = 0.0;
			double Value = 0.0;
			int num2 = 10;
			if (Lines == null)
			{
				return;
			}
			for (int i = 0; i <= Lines.Length - 1; i++)
			{
				string text = Lines[i];
				bool flag = false;
				buString.ReadCharValue(text, "N", ref Value);
				if (Value > 0.0)
				{
					text = text.Replace("N" + Convert.ToInt32(Value), "").Trim();
				}
				if (Options.ConvertG54)
				{
					if (text.IndexOf("G54") >= 0)
					{
						if (!(num > 0.0))
						{
						}
						if (text.IndexOf("$") == -1)
						{
							text = "N" + num2 + " G53" + Environment.NewLine + "N" + (num2 + 10) + " G75" + Environment.NewLine + "N" + (num2 + 20) + " " + text.Replace("G54", "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$") + Environment.NewLine + "N" + (num2 + 30) + " G75" + Environment.NewLine + "N" + (num2 + 40) + " M154 K0";
							num2 += 50;
							flag = true;
						}
					}
					if (text.IndexOf("G55") >= 0)
					{
						text = "N" + num2 + " G53" + Environment.NewLine + "N" + (num2 + 10) + " G75" + Environment.NewLine + "N" + (num2 + 20) + " " + text.Replace("G55", "G54 X$G55.X$ Y$G55.Y$ Z$G55.Z$") + Environment.NewLine + "N" + (num2 + 30) + " G75" + Environment.NewLine + "N" + (num2 + 40) + " M154 K1";
						num2 += 50;
						flag = true;
					}
					if (text.IndexOf("G56") >= 0)
					{
						text = "N" + num2 + " G53" + Environment.NewLine + "N" + (num2 + 10) + " G75" + Environment.NewLine + "N" + (num2 + 20) + " " + text.Replace("G56", "G54 X$G56.X$ Y$G56.Y$ Z$G56.Z$") + Environment.NewLine + "N" + (num2 + 30) + " G75" + Environment.NewLine + "N" + (num2 + 40) + " M154 K2";
						num2 += 50;
						flag = true;
					}
					if (text.IndexOf("G57") >= 0)
					{
						text = "N" + num2 + " G53" + Environment.NewLine + "N" + (num2 + 10) + " G75" + Environment.NewLine + "N" + (num2 + 20) + " " + text.Replace("G57", "G54 X$G57.X$ Y$G57.Y$ Z$G57.Z$") + Environment.NewLine + "N" + (num2 + 30) + " G75" + Environment.NewLine + "N" + (num2 + 40) + " M154 K3";
						num2 += 50;
						flag = true;
					}
					if (text.IndexOf("G58") >= 0)
					{
						text = "N" + num2 + " G53" + Environment.NewLine + "N" + (num2 + 10) + " G75" + Environment.NewLine + "N" + (num2 + 20) + " " + text.Replace("G58", "G54 X$G58.X$ Y$G58.Y$ Z$G58.Z$") + Environment.NewLine + "N" + (num2 + 30) + " G75" + Environment.NewLine + "N" + (num2 + 40) + " M154 K4";
						num2 += 50;
						flag = true;
					}
				}
				if (Options.ConvertM6TCode && text.IndexOf("M6") >= 0 && text.IndexOf("T") >= 0)
				{
					text = "N" + num2 + " " + text.Replace("T", "K");
					flag = true;
					num2 += 10;
				}
				if (Options.ConvertM6TCode)
				{
					if (text.IndexOf("M3") >= 0 && text.IndexOf("S") >= 0)
					{
						text = "N" + num2 + " " + text.Replace("S", "K");
						flag = true;
						num2 += 10;
					}
					if (text.IndexOf("M4") >= 0 && text.IndexOf("S") >= 0)
					{
						text = "N" + num2 + " " + text.Replace("S", "K");
						flag = true;
						num2 += 10;
					}
				}
				if (!flag)
				{
					text = "N" + num2 + " " + text;
				}
				ConvertedCode = ConvertedCode + text + Environment.NewLine;
				num = Value;
				num2 += 10;
			}
		}
		catch (Exception mSException)
		{
			string text2 = "Options : " + Options.ToString() + "- RefCode : " + RefCode.ToString();
			buLog.addLog(text2, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text2);
		}
	}

	public void GetPostParameter(ref string AddtionalString, Pnt9DCam CamPoint)
	{
		string text = "";
		if (AddtionalString.IndexOf("{") < 0)
		{
			return;
		}
		text = buString.FindStringBetweenTwoChar(AddtionalString, "{", "}");
		if (text.IndexOf("$") >= 0)
		{
			AddtionalString = AddtionalString.Replace("{", "");
			AddtionalString = AddtionalString.Replace("}", "");
			switch (text.Trim())
			{
			case "$CPos":
				AddtionalString = AddtionalString.Replace("$CPos", CamPoint.P9.C.ToString("f3"));
				break;
			case "$XPos":
				AddtionalString = AddtionalString.Replace("$XPos", CamPoint.P9.X.ToString("f3"));
				break;
			case "$YPos":
				AddtionalString = AddtionalString.Replace("$YPos", CamPoint.P9.Y.ToString("f3"));
				break;
			case "$ZPos":
				AddtionalString = AddtionalString.Replace("$ZPos", CamPoint.P9.Z.ToString("f3"));
				break;
			case "$APos":
				AddtionalString = AddtionalString.Replace("$APos", CamPoint.P9.A.ToString("f3"));
				break;
			case "$BPos":
				AddtionalString = AddtionalString.Replace("$BPos", CamPoint.P9.B.ToString("f3"));
				break;
			}
		}
	}
}
