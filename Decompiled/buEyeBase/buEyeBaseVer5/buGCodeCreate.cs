using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using buClass;

namespace buEyeBaseVer5;

public class buGCodeCreate
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

	public buGCodeCreate()
	{
		if (buVector5.smethod_0("buGCodeCreate"))
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
		throw new RegisterException("buGCodeCreate");
	}

	public void CreatGCode(camTp Cam, PostProcessor Post, ref string Lines)
	{
		List<camTp> list = new List<camTp>();
		list.Add(Cam);
		CreatGCode(list, Post, ref Lines);
	}

	public void CreatGCode(List<camTp> Cams, PostProcessor Post, ref string Lines)
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
			double num = 0.0;
			Pnt9D pnt9D = new Pnt9D();
			string Codes = "";
			string_0 = "";
			ArrayList CodeLists = new ArrayList();
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
			bool flag6 = false;
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
				pnt9D = new Pnt9D(Cams[0].CamPoints[0].Points[0].P9);
			}
			StartLines(ref Codes, ref CodeLists, pnt9D);
			for (int k = 0; k <= Cams.Count - 1; k++)
			{
				if (!Cams[k].Enable)
				{
					continue;
				}
				if (Cams[k].PreCodesWithoutNo.Count > 0)
				{
					bool enable = postProcessor_0.NumberDef.Enable;
					postProcessor_0.NumberDef.Enable = false;
					for (int l = 0; l <= Cams[k].PreCodesWithoutNo.Count - 1; l++)
					{
						string text16 = Cams[k].PreCodesWithoutNo[l].ToString().Trim();
						if (text16.Length > 0)
						{
							AddCode(ref Codes, text16, postProcessor_0, pnt9D);
						}
					}
					postProcessor_0.NumberDef.Enable = enable;
				}
				if (!Cams[k].UsedCamPost)
				{
					postProcessor_0 = new PostProcessor(Post);
					if (Cams[k].RegionIndex > 0)
					{
						if (Cams[k].RegionIndex == 1)
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
						if (Cams[k].RegionIndex == 2)
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
						if (Cams[k].RegionIndex == 3)
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
						if (Cams[k].RegionIndex == 4)
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
						if (Cams[k].RegionIndex == 5)
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
						if (Cams[k].RegionIndex == 6)
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
					postProcessor_0 = new PostProcessor(Cams[k].Post);
					postProcessor_0.AxesUsing.X = Cams[k].Post.AxesUsing.X & Post.AxesUsing.X;
					postProcessor_0.AxesUsing.Y = Cams[k].Post.AxesUsing.Y & Post.AxesUsing.Y;
					postProcessor_0.AxesUsing.Z = Cams[k].Post.AxesUsing.Z & Post.AxesUsing.Z;
					postProcessor_0.AxesUsing.A = Cams[k].Post.AxesUsing.A & Post.AxesUsing.A;
					postProcessor_0.AxesUsing.B = Cams[k].Post.AxesUsing.B & Post.AxesUsing.B;
					postProcessor_0.AxesUsing.C = Cams[k].Post.AxesUsing.C & Post.AxesUsing.C;
					if (Cams[k].RegionIndex > 0)
					{
						if (Cams[k].RegionIndex == 1)
						{
							postProcessor_0.ToolDef = new ToolPost(Cams[k].Post.Region1.RegionToolDef);
							postProcessor_0.SpindleDef = new SpindlePost(Cams[k].Post.Region1.RegionSpindleDef);
							postProcessor_0.TDef = new CharDefinitions(Cams[k].Post.Region1.RegionTDef);
							postProcessor_0.SDef = new CharDefinitions(Cams[k].Post.Region1.RegionSDef);
							postProcessor_0.XDef = new CharDefinitions(Cams[k].Post.Region1.RegionXDef);
							postProcessor_0.YDef = new CharDefinitions(Cams[k].Post.Region1.RegionYDef);
							postProcessor_0.ZDef = new CharDefinitions(Cams[k].Post.Region1.RegionZDef);
							postProcessor_0.ADef = new CharDefinitions(Cams[k].Post.Region1.RegionADef);
							postProcessor_0.BDef = new CharDefinitions(Cams[k].Post.Region1.RegionBDef);
							postProcessor_0.CDef = new CharDefinitions(Cams[k].Post.Region1.RegionCDef);
						}
						if (Cams[k].RegionIndex == 2)
						{
							postProcessor_0.ToolDef = new ToolPost(Cams[k].Post.Region2.RegionToolDef);
							postProcessor_0.SpindleDef = new SpindlePost(Cams[k].Post.Region2.RegionSpindleDef);
							postProcessor_0.TDef = new CharDefinitions(Cams[k].Post.Region2.RegionTDef);
							postProcessor_0.SDef = new CharDefinitions(Cams[k].Post.Region2.RegionSDef);
							postProcessor_0.XDef = new CharDefinitions(Cams[k].Post.Region2.RegionXDef);
							postProcessor_0.YDef = new CharDefinitions(Cams[k].Post.Region2.RegionYDef);
							postProcessor_0.ZDef = new CharDefinitions(Cams[k].Post.Region2.RegionZDef);
							postProcessor_0.ADef = new CharDefinitions(Cams[k].Post.Region2.RegionADef);
							postProcessor_0.BDef = new CharDefinitions(Cams[k].Post.Region2.RegionBDef);
							postProcessor_0.CDef = new CharDefinitions(Cams[k].Post.Region2.RegionCDef);
						}
						if (Cams[k].RegionIndex == 3)
						{
							postProcessor_0.ToolDef = new ToolPost(Cams[k].Post.Region3.RegionToolDef);
							postProcessor_0.SpindleDef = new SpindlePost(Cams[k].Post.Region3.RegionSpindleDef);
							postProcessor_0.TDef = new CharDefinitions(Cams[k].Post.Region3.RegionTDef);
							postProcessor_0.SDef = new CharDefinitions(Cams[k].Post.Region3.RegionSDef);
							postProcessor_0.XDef = new CharDefinitions(Cams[k].Post.Region3.RegionXDef);
							postProcessor_0.YDef = new CharDefinitions(Cams[k].Post.Region3.RegionYDef);
							postProcessor_0.ZDef = new CharDefinitions(Cams[k].Post.Region3.RegionZDef);
							postProcessor_0.ADef = new CharDefinitions(Cams[k].Post.Region3.RegionADef);
							postProcessor_0.BDef = new CharDefinitions(Cams[k].Post.Region3.RegionBDef);
							postProcessor_0.CDef = new CharDefinitions(Cams[k].Post.Region3.RegionCDef);
						}
						if (Cams[k].RegionIndex == 4)
						{
							postProcessor_0.ToolDef = new ToolPost(Cams[k].Post.Region4.RegionToolDef);
							postProcessor_0.SpindleDef = new SpindlePost(Cams[k].Post.Region4.RegionSpindleDef);
							postProcessor_0.TDef = new CharDefinitions(Cams[k].Post.Region4.RegionTDef);
							postProcessor_0.SDef = new CharDefinitions(Cams[k].Post.Region4.RegionSDef);
							postProcessor_0.XDef = new CharDefinitions(Cams[k].Post.Region4.RegionXDef);
							postProcessor_0.YDef = new CharDefinitions(Cams[k].Post.Region4.RegionYDef);
							postProcessor_0.ZDef = new CharDefinitions(Cams[k].Post.Region4.RegionZDef);
							postProcessor_0.ADef = new CharDefinitions(Cams[k].Post.Region4.RegionADef);
							postProcessor_0.BDef = new CharDefinitions(Cams[k].Post.Region4.RegionBDef);
							postProcessor_0.CDef = new CharDefinitions(Cams[k].Post.Region4.RegionCDef);
						}
						if (Cams[k].RegionIndex == 5)
						{
							postProcessor_0.ToolDef = new ToolPost(Cams[k].Post.Region5.RegionToolDef);
							postProcessor_0.SpindleDef = new SpindlePost(Cams[k].Post.Region5.RegionSpindleDef);
							postProcessor_0.TDef = new CharDefinitions(Cams[k].Post.Region5.RegionTDef);
							postProcessor_0.SDef = new CharDefinitions(Cams[k].Post.Region5.RegionSDef);
							postProcessor_0.XDef = new CharDefinitions(Cams[k].Post.Region5.RegionXDef);
							postProcessor_0.YDef = new CharDefinitions(Cams[k].Post.Region5.RegionYDef);
							postProcessor_0.ZDef = new CharDefinitions(Cams[k].Post.Region5.RegionZDef);
							postProcessor_0.ADef = new CharDefinitions(Cams[k].Post.Region5.RegionADef);
							postProcessor_0.BDef = new CharDefinitions(Cams[k].Post.Region5.RegionBDef);
							postProcessor_0.CDef = new CharDefinitions(Cams[k].Post.Region5.RegionCDef);
						}
						if (Cams[k].RegionIndex == 6)
						{
							postProcessor_0.ToolDef = new ToolPost(Cams[k].Post.Region6.RegionToolDef);
							postProcessor_0.SpindleDef = new SpindlePost(Cams[k].Post.Region6.RegionSpindleDef);
							postProcessor_0.TDef = new CharDefinitions(Cams[k].Post.Region6.RegionTDef);
							postProcessor_0.SDef = new CharDefinitions(Cams[k].Post.Region6.RegionSDef);
							postProcessor_0.XDef = new CharDefinitions(Cams[k].Post.Region6.RegionXDef);
							postProcessor_0.YDef = new CharDefinitions(Cams[k].Post.Region6.RegionYDef);
							postProcessor_0.ZDef = new CharDefinitions(Cams[k].Post.Region6.RegionZDef);
							postProcessor_0.ADef = new CharDefinitions(Cams[k].Post.Region6.RegionADef);
							postProcessor_0.BDef = new CharDefinitions(Cams[k].Post.Region6.RegionBDef);
							postProcessor_0.CDef = new CharDefinitions(Cams[k].Post.Region6.RegionCDef);
						}
					}
				}
				for (int m = 0; m <= postProcessor_0.StartLinesEachBlock.Count - 1; m++)
				{
					string text17 = postProcessor_0.StartLinesEachBlock[m].ToString().Trim();
					if (text17.Length > 0)
					{
						AddCode(ref Codes, text17, postProcessor_0, pnt9D);
					}
				}
				if (Cams[k].PreCodes.Count > 0)
				{
					for (int n = 0; n <= Cams[k].PreCodes.Count - 1; n++)
					{
						string text18 = Cams[k].PreCodes[n].ToString().Trim();
						if (text18.Length > 0)
						{
							AddCode(ref Codes, text18, postProcessor_0, pnt9D);
							if (Codes.Length > 1000)
							{
								CodeLists.Add(Codes);
								Codes = "";
							}
						}
					}
				}
				ToolAndSpindle(ref Codes, ref CodeLists, pnt9D, k, Cams);
				Pnt9DCam pnt9DCam = new Pnt9DCam(double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue);
				pnt9DCam.Type = -1;
				int num7 = 0;
				int num8 = 0;
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
				for (int num9 = 0; num9 <= Cams[k].CamPoints.Count - 1; num9++)
				{
					num4 = 0;
					num5 = 0;
					num = Cams[k].CamPoints[num9].Feed;
					for (int num10 = 0; num10 <= Cams[k].CamPoints[num9].PreCodes.Count - 1; num10++)
					{
						string text19 = Cams[k].CamPoints[num9].PreCodes[num10].ToString().Trim();
						if (text19.Length > 0)
						{
							AddCode(ref Codes, text19, postProcessor_0, pnt9D);
						}
					}
					if (Cams[k].CamPoints[num9].PreCodes.Count > 0)
					{
						pnt9DCam.Type = -1;
						pnt9DCam.Feed = -1.0;
						pnt9DCam.P9 = new Pnt9D(999999999.0, 999999999.0, 999999999.0, 999999999.0, 999999999.0, 999999999.0);
					}
					text12 = "";
					text13 = "";
					text14 = "";
					text15 = "";
					text11 = ValueFormat(postProcessor_0, "F", num, 0.0, 0, Cams[k]);
					string text20 = "";
					string text21 = "";
					eEntities gCodeEntity = new eEntities();
					List<TpPnt9D> list = new List<TpPnt9D>();
					if (postProcessor_0.CircularDef.Type != CircularPostType.DevidedLine)
					{
						list = Cams[k].CamPoints[num9].Points;
					}
					else
					{
						for (int num11 = 0; num11 <= Cams[k].CamPoints[num9].Points.Count - 1; num11++)
						{
							if (!((Cams[k].CamPoints[num9].Points[num11].Type == 2) | (Cams[k].CamPoints[num9].Points[num11].Type == 3)))
							{
								list.Add(new TpPnt9D(Cams[k].CamPoints[num9].Points[num11]));
								continue;
							}
							TpArcData arcData = Cams[k].CamPoints[num9].Points[num11].ArcData;
							List<Pnt3D> Vertices = new List<Pnt3D>();
							buCall.buVector5_0.ArcToLineer(new Pnt3D(arcData.CenterPoint.X, arcData.CenterPoint.Y, arcData.CenterPoint.Z), arcData.Radius, arcData.StartAngle, arcData.EndAngle, postProcessor_0.CircularDef.DevideLength, new WorkPlane(), ref Vertices);
							if (Cams[k].CamPoints[num9].Points[num11].Type == 2)
							{
								Vertices.Reverse();
							}
							for (int num12 = 1; num12 <= Vertices.Count - 1; num12++)
							{
								TpPnt9D tpPnt9D = new TpPnt9D();
								tpPnt9D.P9.X = Vertices[num12].X;
								tpPnt9D.P9.Y = Vertices[num12].Y;
								tpPnt9D.P9.Z = Vertices[num12].Z;
								list.Add(tpPnt9D);
							}
						}
					}
					for (int num13 = 0; num13 <= list.Count - 1; num13++)
					{
						pnt9D = new Pnt9D(list[num13].P9);
						num8 = list[num13].PreCodes.Count;
						num3++;
						if (list[num13].Type == 0)
						{
							text10 = ValueFormat(postProcessor_0, "G", list[num13].Type);
						}
						if (list[num13].Type == 1)
						{
							text10 = ValueFormat(postProcessor_0, "G", list[num13].Type);
						}
						if (((list[num13].Type == 2) | (list[num13].Type == 3)) & (postProcessor_0.CircularDef.Type == CircularPostType.DevidedLine))
						{
							text10 = ValueFormat(postProcessor_0, "G", 1);
						}
						if (((list[num13].Type == 2) | (list[num13].Type == 3)) & (postProcessor_0.CircularDef.Type == CircularPostType.Arc))
						{
							text10 = ValueFormat(postProcessor_0, "G", list[num13].Type);
							if (postProcessor_0.CircularDef.Mode == CircularMode.R)
							{
								text12 = ValueFormat(postProcessor_0, "R", list[num13].ArcData.Radius, 0.0, 0, Cams[k]);
								if ((postProcessor_0.RDef.AdditionalData.Length > 0) & !list[num13].DontUseAdditionalCommand)
								{
									string text22 = new string(' ', postProcessor_0.RDef.SpaceWithAdditionalData);
									string AddtionalString = postProcessor_0.RDef.AdditionalData;
									GetPostParameter(ref AddtionalString, list[num13]);
									text12 = text12 + AddtionalString + text22;
								}
							}
							if (postProcessor_0.CircularDef.Mode == CircularMode.IJK)
							{
								double value = 0.0;
								double value2 = 0.0;
								double value3 = 0.0;
								if (postProcessor_0.CircularDef.IJKMode == CircularIJKMode.OffsetFromStartToCenter)
								{
									value = list[num13].ArcData.CenterPoint.X - list[0].P9.X;
									value2 = list[num13].ArcData.CenterPoint.Y - list[0].P9.Y;
									value3 = list[num13].ArcData.CenterPoint.Z - list[0].P9.Z;
								}
								if (postProcessor_0.CircularDef.IJKMode == CircularIJKMode.Center)
								{
									value = list[num13].ArcData.CenterPoint.X;
									value2 = list[num13].ArcData.CenterPoint.Y;
									value3 = list[num13].ArcData.CenterPoint.Z;
								}
								text13 = ValueFormat(postProcessor_0, "I", value, 0.0, 0, Cams[k]);
								text14 = ValueFormat(postProcessor_0, "J", value2, 0.0, 0, Cams[k]);
								text15 = ValueFormat(postProcessor_0, "K", value3, 0.0, 0, Cams[k]);
								if (Cams[k].Plane.PlaneType == planeType.XY)
								{
									text15 = "";
								}
								if (Cams[k].Plane.PlaneType == planeType.XZ)
								{
									text14 = "";
								}
								if (Cams[k].Plane.PlaneType == planeType.YZ)
								{
									text13 = "";
								}
							}
						}
						if (list[num13].Feed > 0.0)
						{
							num = list[num13].Feed;
							text11 = ValueFormat(postProcessor_0, "F", num, 0.0, 0, Cams[k]);
						}
						if (postProcessor_0.PositionDef.PositionType == PositionPostType.G91AfterG0)
						{
							if (num13 > 0 && (((list[num13].Type == 1) | (list[num13].Type == 2) | (list[num13].Type == 3)) & (list[num13 - 1].Type == 0)))
							{
								for (int num14 = 0; num14 <= postProcessor_0.PositionDef.G91Def.Count - 1; num14++)
								{
									AddCode(ref Codes, postProcessor_0.PositionDef.G91Def[num14], postProcessor_0, pnt9D);
								}
								flag6 = true;
							}
							if (list[num13].Type == 0)
							{
								if (flag6)
								{
									for (int num15 = 0; num15 <= postProcessor_0.PositionDef.G90Def.Count - 1; num15++)
									{
										AddCode(ref Codes, postProcessor_0.PositionDef.G90Def[num15], postProcessor_0, pnt9D);
									}
								}
								flag6 = false;
							}
						}
						for (int num16 = 0; num16 <= list[num13].PreCodes.Count - 1; num16++)
						{
							string text23 = list[num13].PreCodes[num16].ToString().Trim();
							if (text23.Length > 0)
							{
								AddCode(ref Codes, text23, postProcessor_0, pnt9D);
							}
						}
						if (list[num13].PreCodes.Count > 0)
						{
							pnt9DCam.Type = -1;
							pnt9DCam.Feed = -1.0;
							pnt9DCam.P9 = new Pnt9D(999999999.0, 999999999.0, 999999999.0, 999999999.0, 999999999.0, 999999999.0);
						}
						if (!postProcessor_0.AxesUsing.X)
						{
							text = "";
							pnt9DCam.P9.X = 0.0;
						}
						else
						{
							string charAxis = null;
							if (list[num13].XChar != null && list[num13].XChar.Length > 0)
							{
								charAxis = list[num13].XChar;
							}
							text = ValueFormat(postProcessor_0, "X", list[num13].P9.X + Cams[k].CamPoints[num9].GCodeOffset.X + Cams[k].PositionOffset.X, MoveDistance.X + Cams[k].MoveOffset.X, 0, Cams[k], charAxis);
							if (flag6)
							{
								double num17 = list[num13].P9.X + Cams[k].CamPoints[num9].GCodeOffset.X - list[num13 - 1].P9.X;
								text = ((!buCompare5.EQ(num17, 0.0)) ? ValueFormat(postProcessor_0, "X", num17, MoveDistance.X + Cams[k].MoveOffset.X, 0, Cams[k]) : "");
							}
							if ((postProcessor_0.XDef.AdditionalData.Length > 0) & !list[num13].DontUseAdditionalCommand)
							{
								string text24 = new string(' ', postProcessor_0.XDef.SpaceWithAdditionalData);
								string AddtionalString2 = postProcessor_0.XDef.AdditionalData;
								GetPostParameter(ref AddtionalString2, list[num13]);
								text = text + AddtionalString2 + text24;
							}
						}
						if (!postProcessor_0.AxesUsing.Y)
						{
							text2 = "";
							pnt9DCam.P9.Y = 0.0;
						}
						else
						{
							string charAxis2 = null;
							if (list[num13].YChar != null && list[num13].YChar.Length > 0)
							{
								charAxis2 = list[num13].YChar;
							}
							text2 = ValueFormat(postProcessor_0, "Y", list[num13].P9.Y + Cams[k].CamPoints[num9].GCodeOffset.Y + Cams[k].PositionOffset.Y, MoveDistance.Y + Cams[k].MoveOffset.Y, 0, Cams[k], charAxis2);
							if (flag6)
							{
								double num18 = list[num13].P9.Y + Cams[k].CamPoints[num9].GCodeOffset.Y - list[num13 - 1].P9.Y;
								text2 = ((!buCompare5.EQ(num18, 0.0)) ? ValueFormat(postProcessor_0, "Y", num18, MoveDistance.Y + Cams[k].MoveOffset.Y, 0, Cams[k]) : "");
							}
							if ((postProcessor_0.YDef.AdditionalData.Length > 0) & !list[num13].DontUseAdditionalCommand)
							{
								string text25 = new string(' ', postProcessor_0.YDef.SpaceWithAdditionalData);
								string AddtionalString3 = postProcessor_0.YDef.AdditionalData;
								GetPostParameter(ref AddtionalString3, list[num13]);
								text2 = text2 + AddtionalString3 + text25;
							}
						}
						if (!postProcessor_0.AxesUsing.Z)
						{
							text3 = "";
							pnt9DCam.P9.Z = 0.0;
						}
						else
						{
							string charAxis3 = null;
							if (list[num13].ZChar != null && list[num13].ZChar.Length > 0)
							{
								charAxis3 = list[num13].ZChar;
							}
							text3 = ValueFormat(postProcessor_0, "Z", list[num13].P9.Z + Cams[k].CamPoints[num9].GCodeOffset.Z + Cams[k].PositionOffset.Z + list[num13].PostOffsets.Z, MoveDistance.Z + Cams[k].MoveOffset.Z, Cams[k].ZAxisIndex, Cams[k], charAxis3);
							if (flag6)
							{
								double num19 = list[num13].P9.Z + Cams[k].CamPoints[num9].GCodeOffset.Z + list[num13].PostOffsets.Z - (list[num13 - 1].P9.Z + Cams[k].CamPoints[num9].GCodeOffset.Z + list[num13 - 1].PostOffsets.Z);
								text3 = ((!buCompare5.EQ(num19, 0.0)) ? ValueFormat(postProcessor_0, "Z", num19, MoveDistance.Z + Cams[k].MoveOffset.Z, 0, Cams[k]) : "");
							}
							if ((postProcessor_0.ZDef.AdditionalData.Length > 0) & !list[num13].DontUseAdditionalCommand)
							{
								string text26 = new string(' ', postProcessor_0.ZDef.SpaceWithAdditionalData);
								string AddtionalString4 = postProcessor_0.ZDef.AdditionalData;
								GetPostParameter(ref AddtionalString4, list[num13]);
								text3 = text3 + AddtionalString4 + text26;
							}
						}
						if (!postProcessor_0.AxesUsing.A)
						{
							text4 = "";
						}
						else
						{
							text4 = ValueFormat(postProcessor_0, "A", list[num13].P9.A + Cams[k].CamPoints[num9].GCodeOffset.A + Cams[k].PositionOffset.A, 0.0, 0, Cams[k]);
							if (flag6)
							{
								double num20 = list[num13].P9.A + Cams[k].CamPoints[num9].GCodeOffset.A - list[num13 - 1].P9.A;
								text4 = ((!buCompare5.EQ(num20, 0.0)) ? ValueFormat(postProcessor_0, "A", num20, 0.0, 0, Cams[k]) : "");
							}
							if ((postProcessor_0.ADef.AdditionalData.Length > 0) & !list[num13].DontUseAdditionalCommand)
							{
								string text27 = new string(' ', postProcessor_0.ADef.SpaceWithAdditionalData);
								string AddtionalString5 = postProcessor_0.ADef.AdditionalData;
								GetPostParameter(ref AddtionalString5, list[num13]);
								text4 = text4 + AddtionalString5 + text27;
							}
						}
						if (!postProcessor_0.AxesUsing.B)
						{
							text5 = "";
							pnt9DCam.P9.B = 0.0;
						}
						else
						{
							text5 = ValueFormat(postProcessor_0, "B", list[num13].P9.B + Cams[k].CamPoints[num9].GCodeOffset.B + Cams[k].PositionOffset.B, 0.0, 0, Cams[k]);
							if (flag6)
							{
								double num21 = list[num13].P9.B + Cams[k].CamPoints[num9].GCodeOffset.B - list[num13 - 1].P9.B;
								text5 = ((!buCompare5.EQ(num21, 0.0)) ? ValueFormat(postProcessor_0, "B", num21, 0.0, 0, Cams[k]) : "");
							}
							if ((postProcessor_0.BDef.AdditionalData.Length > 0) & !list[num13].DontUseAdditionalCommand)
							{
								string text28 = new string(' ', postProcessor_0.BDef.SpaceWithAdditionalData);
								string AddtionalString6 = postProcessor_0.BDef.AdditionalData;
								GetPostParameter(ref AddtionalString6, list[num13]);
								text5 = text5 + AddtionalString6 + text28;
							}
						}
						if (!postProcessor_0.AxesUsing.C)
						{
							text6 = "";
							pnt9DCam.P9.C = 0.0;
						}
						else
						{
							text6 = ValueFormat(postProcessor_0, "C", list[num13].P9.C + Cams[k].CamPoints[num9].GCodeOffset.C + Cams[k].PositionOffset.C, 0.0, 0, Cams[k]);
							if (flag6)
							{
								double num22 = list[num13].P9.C + Cams[k].CamPoints[num9].GCodeOffset.C - list[num13 - 1].P9.C;
								text6 = ((!buCompare5.EQ(num22, 0.0)) ? ValueFormat(postProcessor_0, "C", num22, 0.0, 0, Cams[k]) : "");
							}
							if ((postProcessor_0.CDef.AdditionalData.Length > 0) & !list[num13].DontUseAdditionalCommand)
							{
								string text29 = new string(' ', postProcessor_0.CDef.SpaceWithAdditionalData);
								string AddtionalString7 = postProcessor_0.CDef.AdditionalData;
								GetPostParameter(ref AddtionalString7, list[num13]);
								text6 = text6 + AddtionalString7 + text29;
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
								text7 = ValueFormat(postProcessor_0, "U", list[num13].P9.U + Cams[k].CamPoints[num9].GCodeOffset.U, 0.0, 0, Cams[k]);
								if ((postProcessor_0.UDef.AdditionalData.Length > 0) & !list[num13].DontUseAdditionalCommand)
								{
									string text30 = new string(' ', postProcessor_0.UDef.SpaceWithAdditionalData);
									string AddtionalString8 = postProcessor_0.UDef.AdditionalData;
									GetPostParameter(ref AddtionalString8, list[num13]);
									text7 = text7 + AddtionalString8 + text30;
								}
							}
							if (!postProcessor_0.AxesUsing.V)
							{
								text8 = "";
								pnt9DCam.P9.V = 0.0;
							}
							else
							{
								text8 = ValueFormat(postProcessor_0, "V", list[num13].P9.V + Cams[k].CamPoints[num9].GCodeOffset.V, 0.0, 0, Cams[k]);
								if ((postProcessor_0.VDef.AdditionalData.Length > 0) & !list[num13].DontUseAdditionalCommand)
								{
									string text31 = new string(' ', postProcessor_0.VDef.SpaceWithAdditionalData);
									string AddtionalString9 = postProcessor_0.VDef.AdditionalData;
									GetPostParameter(ref AddtionalString9, list[num13]);
									text8 = text8 + AddtionalString9 + text31;
								}
							}
							if (!postProcessor_0.AxesUsing.W)
							{
								text9 = "";
								pnt9DCam.P9.W = 0.0;
							}
							else
							{
								text9 = ValueFormat(postProcessor_0, "W", list[num13].P9.W + Cams[k].CamPoints[num9].GCodeOffset.W, 0.0, 0, Cams[k]);
								if ((postProcessor_0.WDef.AdditionalData.Length > 0) & !list[num13].DontUseAdditionalCommand)
								{
									string text32 = new string(' ', postProcessor_0.WDef.SpaceWithAdditionalData);
									string AddtionalString10 = postProcessor_0.WDef.AdditionalData;
									GetPostParameter(ref AddtionalString10, list[num13]);
									text9 = text9 + AddtionalString10 + text32;
								}
							}
						}
						if (!list[num13].EnableAxes.X)
						{
							text = "";
							pnt9DCam.P9.X = 0.0;
						}
						if (!list[num13].EnableAxes.Y)
						{
							text2 = "";
							pnt9DCam.P9.Y = 0.0;
						}
						if (!list[num13].EnableAxes.Z)
						{
							text3 = "";
							pnt9DCam.P9.Z = 0.0;
						}
						if (!list[num13].EnableAxes.A)
						{
							text4 = "";
						}
						if (!list[num13].EnableAxes.B)
						{
							text5 = "";
							pnt9DCam.P9.B = 0.0;
						}
						if (!list[num13].EnableAxes.C)
						{
							text6 = "";
							pnt9DCam.P9.C = 0.0;
						}
						if (!list[num13].EnableAxes.U)
						{
							text7 = "";
							pnt9DCam.P9.U = 0.0;
						}
						if (!list[num13].EnableAxes.V)
						{
							text8 = "";
							pnt9DCam.P9.V = 0.0;
						}
						if (!list[num13].EnableAxes.W)
						{
							text9 = "";
							pnt9DCam.P9.W = 0.0;
						}
						if (pnt9DCam != null)
						{
							if (!postProcessor_0.RepetitionDef.Command && list[num13].Type == pnt9DCam.Type)
							{
								if (list[num13].Type == 2)
								{
									if (list[num13].ArcType == pnt9DCam.ArcType && num7 == 0 && num8 == 0)
									{
										text10 = "";
									}
								}
								else if (num7 == 0 && num8 == 0)
								{
									text10 = "";
								}
							}
							if (!postProcessor_0.RepetitionDef.Feed && ((num == pnt9DCam.Feed) & (list[num13].Type == pnt9DCam.Type)))
							{
								text11 = "";
							}
							if (!postProcessor_0.G0Propery.UseFeedSpeed && list[num13].Type == 0)
							{
								text11 = "";
							}
							if (!postProcessor_0.RepetitionDef.Coordinate & !Cams[k].CamPoints[num9].ForceWriteAllCoordinate)
							{
								if (buCompare5.EQ(list[num13].P9.X, pnt9DCam.P9.X, resolution) & !postProcessor_0.RepetitionDef.AxesRepetation.X)
								{
									text = "";
								}
								if (buCompare5.EQ(list[num13].P9.Y, pnt9DCam.P9.Y, resolution2) & !postProcessor_0.RepetitionDef.AxesRepetation.Y)
								{
									text2 = "";
								}
								if (buCompare5.EQ(list[num13].P9.Z, pnt9DCam.P9.Z, resolution3) & !postProcessor_0.RepetitionDef.AxesRepetation.Z)
								{
									text3 = "";
								}
								if (buCompare5.EQ(list[num13].P9.A, pnt9DCam.P9.A, resolution4) & !postProcessor_0.RepetitionDef.AxesRepetation.A)
								{
									text4 = "";
								}
								if (buCompare5.EQ(list[num13].P9.B, pnt9DCam.P9.B, resolution5) & !postProcessor_0.RepetitionDef.AxesRepetation.B)
								{
									text5 = "";
								}
								if (buCompare5.EQ(list[num13].P9.C, pnt9DCam.P9.C, resolution6) & !postProcessor_0.RepetitionDef.AxesRepetation.C)
								{
									text6 = "";
								}
								if (flag)
								{
									if (buCompare5.EQ(list[num13].P9.U, pnt9DCam.P9.U, resolution7) & !postProcessor_0.RepetitionDef.AxesRepetation.U)
									{
										text7 = "";
									}
									if (buCompare5.EQ(list[num13].P9.V, pnt9DCam.P9.V, resolution8) & !postProcessor_0.RepetitionDef.AxesRepetation.V)
									{
										text8 = "";
									}
									if (buCompare5.EQ(list[num13].P9.W, pnt9DCam.P9.W, resolution9) & !postProcessor_0.RepetitionDef.AxesRepetation.W)
									{
										text9 = "";
									}
								}
							}
						}
						if (!flag)
						{
							if (buCompare5.EQ(new Pnt6D(list[num13].P9), new Pnt6D(pnt9DCam.P9)))
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
						else if (buCompare5.EQ(list[num13].P9, pnt9DCam.P9))
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
							text11 = "";
						}
						if ((list[num13].Type != 2) & (list[num13].Type != 3))
						{
							text12 = "";
							text13 = "";
							text14 = "";
							text15 = "";
						}
						if (list[num13].PlungeAxisMovement)
						{
							if (list[num13].PlungeAxis == "Z")
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
							if (list[num13].PlungeAxis == "X")
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
							if (list[num13].PlungeAxis == "Y")
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
						if (list[num13].LeaveAxisMovement)
						{
							if (list[num13].LeaveAxis == "Z")
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
							if (list[num13].LeaveAxis == "X")
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
							if (list[num13].LeaveAxis == "Y")
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
						text20 = text + text2 + text3 + text4 + text5 + text6 + text7 + text8 + text9;
						text21 = text10 + text20 + text12 + text13 + text14 + text15 + text11 + list[num13].GCodeExtraLine;
						if (num4 == 1 && !flag2)
						{
							for (int num23 = 0; num23 <= postProcessor_0.FirstPlungePreCodes.Count - 1; num23++)
							{
								string text33 = postProcessor_0.FirstPlungePreCodes[num23].ToString().Trim();
								if (text33.Length > 0)
								{
									AddCode(ref Codes, text33, postProcessor_0, pnt9D);
									flag2 = true;
								}
							}
						}
						if (num5 == Cams[k].CamPoints[num9].NumberOfLeaveMovement && !flag4)
						{
							for (int num24 = 0; num24 <= postProcessor_0.LastLeavePreCodes.Count - 1; num24++)
							{
								string text34 = postProcessor_0.LastLeavePreCodes[num24].ToString().Trim();
								if (text34.Length > 0)
								{
									AddCode(ref Codes, text34, postProcessor_0, pnt9D);
									flag4 = true;
								}
							}
						}
						if (text.Length > 0)
						{
							pnt9DCam.P9.X = list[num13].P9.X;
						}
						if (text2.Length > 0)
						{
							pnt9DCam.P9.Y = list[num13].P9.Y;
						}
						if (text3.Length > 0)
						{
							pnt9DCam.P9.Z = list[num13].P9.Z;
						}
						if (text4.Length > 0 && list[num13].EnableAxes.A)
						{
							pnt9DCam.P9.A = list[num13].P9.A;
						}
						if (text5.Length > 0)
						{
							pnt9DCam.P9.B = list[num13].P9.B;
						}
						if (text6.Length > 0)
						{
							pnt9DCam.P9.C = list[num13].P9.C;
						}
						if (flag)
						{
							if (text7.Length > 0)
							{
								pnt9DCam.P9.U = list[num13].P9.U;
							}
							if (text8.Length > 0)
							{
								pnt9DCam.P9.V = list[num13].P9.V;
							}
							if (text9.Length > 0)
							{
								pnt9DCam.P9.W = list[num13].P9.W;
							}
						}
						if (text20.Length > 0)
						{
							if (pnt9DCam != null)
							{
								if (num13 > 0 && ((list[num13].Type != 0) & (pnt9DCam.Type == 0) & postProcessor_0.G0Propery.AuxCodeForLastFallingG0.Enable & (postProcessor_0.G0Propery.AuxCodeForLastFallingG0.PreCode.Count > 0)))
								{
									for (int num25 = 0; num25 <= postProcessor_0.G0Propery.AuxCodeForLastFallingG0.PreCode.Count - 1; num25++)
									{
										string text35 = postProcessor_0.G0Propery.AuxCodeForLastFallingG0.PreCode[num25].ToString().Trim();
										if (text35.Length > 0)
										{
											AddCode(ref Codes, text35, postProcessor_0, pnt9D);
										}
									}
								}
								if ((list[num13].Type == 0) & (pnt9DCam.Type != 0) & postProcessor_0.G0Propery.AuxCodeForFirstRisingG0.Enable & (postProcessor_0.G0Propery.AuxCodeForFirstRisingG0.PreCode.Count > 0))
								{
									for (int num26 = 0; num26 <= postProcessor_0.G0Propery.AuxCodeForFirstRisingG0.PreCode.Count - 1; num26++)
									{
										string text36 = postProcessor_0.G0Propery.AuxCodeForFirstRisingG0.PreCode[num26].ToString().Trim();
										if (text36.Length > 0)
										{
											AddCode(ref Codes, text36, postProcessor_0, pnt9D);
										}
									}
								}
								if ((list[num13].Type == 0) & postProcessor_0.G0Propery.AuxCodeForAllG0.Enable & (postProcessor_0.G0Propery.AuxCodeForAllG0.PreCode.Count > 0))
								{
									for (int num27 = 0; num27 <= postProcessor_0.G0Propery.AuxCodeForAllG0.PreCode.Count - 1; num27++)
									{
										string text37 = postProcessor_0.G0Propery.AuxCodeForAllG0.PreCode[num27].ToString().Trim();
										if (text37.Length > 0)
										{
											AddCode(ref Codes, text37, postProcessor_0, pnt9D);
										}
									}
								}
								if (((list[num13].Type == 1) | (list[num13].Type == 2) | (list[num13].Type == 3)) & ((pnt9DCam.Type != 1) & (pnt9DCam.Type != 2) & (pnt9DCam.Type != 3)) & postProcessor_0.G1G2G3Propery.AuxCodeForFirstRisingG1G2G3.Enable & (postProcessor_0.G1G2G3Propery.AuxCodeForFirstRisingG1G2G3.PreCode.Count > 0))
								{
									for (int num28 = 0; num28 <= postProcessor_0.G1G2G3Propery.AuxCodeForFirstRisingG1G2G3.PreCode.Count - 1; num28++)
									{
										string text38 = postProcessor_0.G1G2G3Propery.AuxCodeForFirstRisingG1G2G3.PreCode[num28].ToString().Trim();
										if (text38.Length > 0)
										{
											AddCode(ref Codes, text38, postProcessor_0, pnt9D);
										}
									}
								}
								if (((list[num13].Type == 1) | (list[num13].Type == 2) | (list[num13].Type == 3)) & postProcessor_0.G1G2G3Propery.AuxCodeForAllG1G2G3.Enable & (postProcessor_0.G1G2G3Propery.AuxCodeForAllG1G2G3.PreCode.Count > 0))
								{
									for (int num29 = 0; num29 <= postProcessor_0.G1G2G3Propery.AuxCodeForAllG1G2G3.PreCode.Count - 1; num29++)
									{
										string text39 = postProcessor_0.G1G2G3Propery.AuxCodeForAllG1G2G3.PreCode[num29].ToString().Trim();
										if (text39.Length > 0)
										{
											AddCode(ref Codes, text39, postProcessor_0, pnt9D);
										}
									}
								}
								if ((list[num13].Type == 1) & (pnt9DCam.Type != 1) & postProcessor_0.G1Propery.AuxCodeForFirstRisingG1.Enable & (postProcessor_0.G1Propery.AuxCodeForFirstRisingG1.PreCode.Count > 0))
								{
									for (int num30 = 0; num30 <= postProcessor_0.G1Propery.AuxCodeForFirstRisingG1.PreCode.Count - 1; num30++)
									{
										string text40 = postProcessor_0.G1Propery.AuxCodeForFirstRisingG1.PreCode[num30].ToString().Trim();
										if (text40.Length > 0)
										{
											AddCode(ref Codes, text40, postProcessor_0, pnt9D);
										}
									}
								}
								if ((list[num13].Type == 1) & postProcessor_0.G1Propery.AuxCodeForAllG1.Enable & (postProcessor_0.G1Propery.AuxCodeForAllG1.PreCode.Count > 0))
								{
									for (int num31 = 0; num31 <= postProcessor_0.G1Propery.AuxCodeForAllG1.PreCode.Count - 1; num31++)
									{
										string text41 = postProcessor_0.G1Propery.AuxCodeForAllG1.PreCode[num31].ToString().Trim();
										if (text41.Length > 0)
										{
											AddCode(ref Codes, text41, postProcessor_0, pnt9D);
										}
									}
								}
								if ((list[num13].Type == 2) & (pnt9DCam.Type != 2) & postProcessor_0.G2Propery.AuxCodeForFirstRisingG2.Enable & (postProcessor_0.G2Propery.AuxCodeForFirstRisingG2.PreCode.Count > 0))
								{
									for (int num32 = 0; num32 <= postProcessor_0.G2Propery.AuxCodeForFirstRisingG2.PreCode.Count - 1; num32++)
									{
										string text42 = postProcessor_0.G2Propery.AuxCodeForFirstRisingG2.PreCode[num32].ToString().Trim();
										if (text42.Length > 0)
										{
											AddCode(ref Codes, text42, postProcessor_0, pnt9D);
										}
									}
								}
								if ((list[num13].Type == 2) & postProcessor_0.G2Propery.AuxCodeForAllG2.Enable & (postProcessor_0.G2Propery.AuxCodeForAllG2.PreCode.Count > 0))
								{
									for (int num33 = 0; num33 <= postProcessor_0.G2Propery.AuxCodeForAllG2.PreCode.Count - 1; num33++)
									{
										string text43 = postProcessor_0.G2Propery.AuxCodeForAllG2.PreCode[num33].ToString().Trim();
										if (text43.Length > 0)
										{
											AddCode(ref Codes, text43, postProcessor_0, pnt9D);
										}
									}
								}
								if ((list[num13].Type == 3) & (pnt9DCam.Type != 3) & postProcessor_0.G3Propery.AuxCodeForFirstRisingG3.Enable & (postProcessor_0.G3Propery.AuxCodeForFirstRisingG3.PreCode.Count > 0))
								{
									for (int num34 = 0; num34 <= postProcessor_0.G3Propery.AuxCodeForFirstRisingG3.PreCode.Count - 1; num34++)
									{
										string text44 = postProcessor_0.G3Propery.AuxCodeForFirstRisingG3.PreCode[num34].ToString().Trim();
										if (text44.Length > 0)
										{
											AddCode(ref Codes, text44, postProcessor_0, pnt9D);
										}
									}
								}
								if ((list[num13].Type == 3) & postProcessor_0.G3Propery.AuxCodeForAllG3.Enable & (postProcessor_0.G3Propery.AuxCodeForAllG3.PreCode.Count > 0))
								{
									for (int num35 = 0; num35 <= postProcessor_0.G3Propery.AuxCodeForAllG3.PreCode.Count - 1; num35++)
									{
										string text45 = postProcessor_0.G3Propery.AuxCodeForAllG3.PreCode[num35].ToString().Trim();
										if (text45.Length > 0)
										{
											AddCode(ref Codes, text45, postProcessor_0, pnt9D);
										}
									}
								}
							}
							if (list[num13].OverWriteString != null && list[num13].OverWriteString.Trim().Length > 0)
							{
								text21 = list[num13].OverWriteString;
							}
							AddCode(ref Codes, text21, postProcessor_0, gCodeEntity, pnt9D);
							if (text3.Length > 0 && postProcessor_0.UseToolHeightOffsetAfterZMove)
							{
								if (num9 < Cams[k].CamPoints.Count - 1)
								{
									AddCode(ref Codes, "M75", postProcessor_0, pnt9D);
								}
								AddCode(ref Codes, "G43 H" + Cams[k].Tool.Data.HeightOffsetIndex + " " + text3, postProcessor_0, pnt9D);
							}
							if (pnt9DCam == null)
							{
								pnt9DCam = new Pnt9DCam();
							}
							if (pnt9DCam != null)
							{
								if ((list[num13].Type == 0) & (pnt9DCam.Type != 0) & postProcessor_0.G0Propery.AuxCodeForFirstRisingG0.Enable & (postProcessor_0.G0Propery.AuxCodeForFirstRisingG0.AfterCode.Count > 0))
								{
									for (int num36 = 0; num36 <= postProcessor_0.G0Propery.AuxCodeForFirstRisingG0.AfterCode.Count - 1; num36++)
									{
										string text46 = postProcessor_0.G0Propery.AuxCodeForFirstRisingG0.AfterCode[num36].ToString().Trim();
										if (text46.Length > 0)
										{
											AddCode(ref Codes, text46, postProcessor_0, pnt9D);
										}
									}
								}
								if ((list[num13].Type != 0) & (pnt9DCam.Type == 0) & postProcessor_0.G0Propery.AuxCodeForLastFallingG0.Enable & (postProcessor_0.G0Propery.AuxCodeForLastFallingG0.AfterCode.Count > 0))
								{
									for (int num37 = 0; num37 <= postProcessor_0.G0Propery.AuxCodeForLastFallingG0.AfterCode.Count - 1; num37++)
									{
										string text47 = postProcessor_0.G0Propery.AuxCodeForLastFallingG0.AfterCode[num37].ToString().Trim();
										if (text47.Length > 0)
										{
											AddCode(ref Codes, text47, postProcessor_0, pnt9D);
										}
									}
								}
								if ((list[num13].Type == 0) & postProcessor_0.G0Propery.AuxCodeForAllG0.Enable & (postProcessor_0.G0Propery.AuxCodeForAllG0.AfterCode.Count > 0))
								{
									for (int num38 = 0; num38 <= postProcessor_0.G0Propery.AuxCodeForAllG0.AfterCode.Count - 1; num38++)
									{
										string text48 = postProcessor_0.G0Propery.AuxCodeForAllG0.AfterCode[num38].ToString().Trim();
										if (text48.Length > 0)
										{
											AddCode(ref Codes, text48, postProcessor_0, pnt9D);
										}
									}
								}
								if (((list[num13].Type == 1) | (list[num13].Type == 2) | (list[num13].Type == 3)) & ((pnt9DCam.Type != 1) & (pnt9DCam.Type != 2) & (pnt9DCam.Type != 3)) & postProcessor_0.G1G2G3Propery.AuxCodeForFirstRisingG1G2G3.Enable & (postProcessor_0.G1G2G3Propery.AuxCodeForFirstRisingG1G2G3.AfterCode.Count > 0))
								{
									for (int num39 = 0; num39 <= postProcessor_0.G1G2G3Propery.AuxCodeForFirstRisingG1G2G3.AfterCode.Count - 1; num39++)
									{
										string text49 = postProcessor_0.G1G2G3Propery.AuxCodeForFirstRisingG1G2G3.AfterCode[num39].ToString().Trim();
										if (text49.Length > 0)
										{
											AddCode(ref Codes, text49, postProcessor_0, pnt9D);
										}
									}
								}
								if (((list[num13].Type == 1) | (list[num13].Type == 2) | (list[num13].Type == 3)) & postProcessor_0.G1G2G3Propery.AuxCodeForAllG1G2G3.Enable & (postProcessor_0.G1G2G3Propery.AuxCodeForAllG1G2G3.AfterCode.Count > 0))
								{
									for (int num40 = 0; num40 <= postProcessor_0.G1G2G3Propery.AuxCodeForAllG1G2G3.AfterCode.Count - 1; num40++)
									{
										string text50 = postProcessor_0.G1G2G3Propery.AuxCodeForAllG1G2G3.AfterCode[num40].ToString().Trim();
										if (text50.Length > 0)
										{
											AddCode(ref Codes, text50, postProcessor_0, pnt9D);
										}
									}
								}
								if ((list[num13].Type == 1) & (pnt9DCam.Type != 1) & postProcessor_0.G1Propery.AuxCodeForFirstRisingG1.Enable & (postProcessor_0.G1Propery.AuxCodeForFirstRisingG1.AfterCode.Count > 0))
								{
									for (int num41 = 0; num41 <= postProcessor_0.G1Propery.AuxCodeForFirstRisingG1.AfterCode.Count - 1; num41++)
									{
										string text51 = postProcessor_0.G1Propery.AuxCodeForFirstRisingG1.AfterCode[num41].ToString().Trim();
										if (text51.Length > 0)
										{
											AddCode(ref Codes, text51, postProcessor_0, pnt9D);
										}
									}
								}
								if ((list[num13].Type == 1) & postProcessor_0.G1Propery.AuxCodeForAllG1.Enable & (postProcessor_0.G1Propery.AuxCodeForAllG1.AfterCode.Count > 0))
								{
									for (int num42 = 0; num42 <= postProcessor_0.G1Propery.AuxCodeForAllG1.AfterCode.Count - 1; num42++)
									{
										string text52 = postProcessor_0.G1Propery.AuxCodeForAllG1.AfterCode[num42].ToString().Trim();
										if (text52.Length > 0)
										{
											AddCode(ref Codes, text52, postProcessor_0, pnt9D);
										}
									}
								}
								if ((list[num13].Type == 2) & (pnt9DCam.Type != 2) & postProcessor_0.G2Propery.AuxCodeForFirstRisingG2.Enable & (postProcessor_0.G2Propery.AuxCodeForFirstRisingG2.AfterCode.Count > 0))
								{
									for (int num43 = 0; num43 <= postProcessor_0.G2Propery.AuxCodeForFirstRisingG2.AfterCode.Count - 1; num43++)
									{
										string text53 = postProcessor_0.G2Propery.AuxCodeForFirstRisingG2.AfterCode[num43].ToString().Trim();
										if (text53.Length > 0)
										{
											AddCode(ref Codes, text53, postProcessor_0, pnt9D);
										}
									}
								}
								if ((list[num13].Type == 2) & postProcessor_0.G2Propery.AuxCodeForAllG2.Enable & (postProcessor_0.G2Propery.AuxCodeForAllG2.AfterCode.Count > 0))
								{
									for (int num44 = 0; num44 <= postProcessor_0.G2Propery.AuxCodeForAllG2.AfterCode.Count - 1; num44++)
									{
										string text54 = postProcessor_0.G2Propery.AuxCodeForAllG2.AfterCode[num44].ToString().Trim();
										if (text54.Length > 0)
										{
											AddCode(ref Codes, text54, postProcessor_0, pnt9D);
										}
									}
								}
								if ((list[num13].Type == 3) & (pnt9DCam.Type != 3) & postProcessor_0.G3Propery.AuxCodeForFirstRisingG3.Enable & (postProcessor_0.G3Propery.AuxCodeForFirstRisingG3.AfterCode.Count > 0))
								{
									for (int num45 = 0; num45 <= postProcessor_0.G3Propery.AuxCodeForFirstRisingG3.AfterCode.Count - 1; num45++)
									{
										string text55 = postProcessor_0.G3Propery.AuxCodeForFirstRisingG3.AfterCode[num45].ToString().Trim();
										if (text55.Length > 0)
										{
											AddCode(ref Codes, text55, postProcessor_0, pnt9D);
										}
									}
								}
								if ((list[num13].Type == 3) & postProcessor_0.G3Propery.AuxCodeForAllG3.Enable & (postProcessor_0.G3Propery.AuxCodeForAllG3.AfterCode.Count > 0))
								{
									for (int num46 = 0; num46 <= postProcessor_0.G3Propery.AuxCodeForAllG3.AfterCode.Count - 1; num46++)
									{
										string text56 = postProcessor_0.G3Propery.AuxCodeForAllG3.AfterCode[num46].ToString().Trim();
										if (text56.Length > 0)
										{
											AddCode(ref Codes, text56, postProcessor_0, pnt9D);
										}
									}
								}
							}
							pnt9DCam.Type = list[num13].Type;
							pnt9DCam.ArcType = list[num13].ArcType;
							pnt9DCam.Feed = num;
						}
						for (int num47 = 0; num47 <= list[num13].AfterCodes.Count - 1; num47++)
						{
							string text57 = list[num13].AfterCodes[num47].ToString().Trim();
							if (text57.Length > 0)
							{
								AddCode(ref Codes, text57, postProcessor_0, pnt9D);
							}
						}
						if ((list[num13].AfterCodes.Count > 0) & Post.PreCoordinateClearAfterCodes)
						{
							pnt9DCam.Type = -1;
							pnt9DCam.Feed = -1.0;
							pnt9DCam.P9 = new Pnt9D(999999999.0, 999999999.0, 999999999.0, 999999999.0, 999999999.0, 999999999.0);
						}
						if (num4 == 1 && !flag3)
						{
							for (int num48 = 0; num48 <= postProcessor_0.FirstPlungeAfterCodes.Count - 1; num48++)
							{
								string text58 = postProcessor_0.FirstPlungeAfterCodes[num48].ToString().Trim();
								if (text58.Length > 0)
								{
									AddCode(ref Codes, text58, postProcessor_0, pnt9D);
									flag3 = true;
								}
							}
						}
						if (num5 == Cams[k].CamPoints[num9].NumberOfLeaveMovement && !flag5)
						{
							for (int num49 = 0; num49 <= postProcessor_0.LastLeaveAfterCodes.Count - 1; num49++)
							{
								string text59 = postProcessor_0.LastLeaveAfterCodes[num49].ToString().Trim();
								if (text59.Length > 0)
								{
									AddCode(ref Codes, text59, postProcessor_0, pnt9D);
									flag5 = true;
								}
							}
						}
						if (Codes.Length > 1000)
						{
							CodeLists.Add(Codes);
							Codes = "";
						}
						if (buSystem.DoEventEnable && num6 > 0 && num3 > 0 && num3 % num6 == 0 && buSystem.ProgressControlEnable && calculationEventHandler_0 != null)
						{
							calculationEventHandler_0(new CalculationEventArg(100.0, Convert.ToDouble((double)num3 / (double)num2) * 100.0, 0, buLangTranslate.preDef.GCode + " " + buLangTranslate.preDef.Creating, ""));
						}
						if (!buSystem.Cancel)
						{
							num7 = list[num13].AfterCodes.Count;
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
					for (int num50 = 0; num50 <= Cams[k].CamPoints[num9].AfterCodes.Count - 1; num50++)
					{
						string text60 = Cams[k].CamPoints[num9].AfterCodes[num50].ToString().Trim();
						if (text60.Length > 0)
						{
							AddCode(ref Codes, text60, postProcessor_0, pnt9D);
						}
					}
					if (Cams[k].CamPoints[num9].AfterCodes.Count > 0)
					{
						pnt9DCam.Type = -1;
						pnt9DCam.Feed = -1.0;
						pnt9DCam.P9 = new Pnt9D(999999999.0, 999999999.0, 999999999.0, 999999999.0, 999999999.0, 999999999.0);
					}
					CodeLists.Add(Codes);
					Codes = "";
				}
				if (Cams[k].AfterCodes.Count > 0)
				{
					for (int num51 = 0; num51 <= Cams[k].AfterCodes.Count - 1; num51++)
					{
						string text61 = Cams[k].AfterCodes[num51].ToString().Trim();
						if (text61.Length > 0)
						{
							AddCode(ref Codes, text61, postProcessor_0, pnt9D);
							if (Codes.Length > 1000)
							{
								CodeLists.Add(Codes);
								Codes = "";
							}
						}
					}
				}
				for (int num52 = 0; num52 <= postProcessor_0.EndLinesEachBlock.Count - 1; num52++)
				{
					string text62 = postProcessor_0.EndLinesEachBlock[num52].ToString().Trim();
					if (text62.Length > 0)
					{
						AddCode(ref Codes, text62, postProcessor_0, pnt9D);
					}
				}
				if (Cams[k].AfterCodesWithoutNo.Count <= 0)
				{
					continue;
				}
				bool enable2 = postProcessor_0.NumberDef.Enable;
				postProcessor_0.NumberDef.Enable = false;
				for (int num53 = 0; num53 <= Cams[k].AfterCodesWithoutNo.Count - 1; num53++)
				{
					string text63 = Cams[k].AfterCodesWithoutNo[num53].ToString().Trim();
					if (text63.Length > 0)
					{
						AddCode(ref Codes, text63, postProcessor_0, pnt9D);
						if (Codes.Length > 1000)
						{
							CodeLists.Add(Codes);
							Codes = "";
						}
					}
				}
				postProcessor_0.NumberDef.Enable = enable2;
			}
			postProcessor_0 = new PostProcessor(Post);
			EndLines(ref Codes, ref CodeLists, pnt9D);
			Lines = buString5.ArrayListToString(CodeLists);
			if (bool_0 && AppLanguage.SystemMessages.Count > 9)
			{
				buString5.MessageBoxWarning(AppLanguage.SystemMessages[9]);
			}
		}
		catch (Exception mSException)
		{
			string text64 = "";
			buLog.addLog(text64, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text64);
		}
	}

	public void ToolAndSpindle(ref string Codes, ref ArrayList CodeLists, Pnt9D pnt9CurrentPos, int i, List<camTp> Cams)
	{
		string text = "";
		string text2 = "";
		string text3 = "";
		if (!postProcessor_0.SpindleDef.UseSpindle)
		{
			text = "";
		}
		else
		{
			text = ValueFormat(postProcessor_0, postProcessor_0.SDef.Char, Cams[i].Tool.CamData.SpindleSpeed, 0.0, 0, Cams[i]);
			text = ((!postProcessor_0.SpindleDef.SpindleMCommandFirst) ? ((Cams[i].Tool.CamData.SpindleDirection == ClockDirectionType.CW) ? (text + postProcessor_0.SpindleDef.SpindleCWCode) : (text + postProcessor_0.SpindleDef.SpindleCCWCode)) : ((Cams[i].Tool.CamData.SpindleDirection == ClockDirectionType.CW) ? (postProcessor_0.SpindleDef.SpindleCWCode + " " + text) : (postProcessor_0.SpindleDef.SpindleCCWCode + " " + text)));
		}
		if (!((i == 0) | ((i > 0) & !postProcessor_0.ToolNextDef.ToolData.Enable)))
		{
			return;
		}
		if (!postProcessor_0.ToolDef.ToolData.Enable)
		{
			text3 = "";
			if (!(postProcessor_0.SpindleDef.UseSpindle & !postProcessor_0.Tool1.ToolData.Enable & !postProcessor_0.Tool2.ToolData.Enable & !postProcessor_0.Tool3.ToolData.Enable & !postProcessor_0.Tool4.ToolData.Enable & !postProcessor_0.Tool5.ToolData.Enable))
			{
				return;
			}
			if (postProcessor_0.SpindleDef.PreCode.Count > 0)
			{
				for (int j = 0; j <= postProcessor_0.SpindleDef.PreCode.Count - 1; j++)
				{
					string text4 = postProcessor_0.SpindleDef.PreCode[j].ToString().Trim();
					if (text4.Length > 0)
					{
						AddCode(ref Codes, text4, postProcessor_0, pnt9CurrentPos);
					}
				}
			}
			for (int k = 0; k <= Cams[i].SpindlePreCodes.Count - 1; k++)
			{
				string text5 = Cams[i].SpindlePreCodes[k].ToString().Trim();
				if (text5.Length > 0)
				{
					AddCode(ref Codes, text5, postProcessor_0, pnt9CurrentPos);
				}
			}
			AddCode(ref Codes, text, postProcessor_0, pnt9CurrentPos);
			if (postProcessor_0.SpindleDef.AfterCode.Count > 0)
			{
				for (int l = 0; l <= postProcessor_0.SpindleDef.AfterCode.Count - 1; l++)
				{
					string text6 = postProcessor_0.SpindleDef.AfterCode[l].ToString().Trim();
					if (text6.Length > 0)
					{
						AddCode(ref Codes, text6, postProcessor_0, pnt9CurrentPos);
					}
				}
			}
			for (int m = 0; m <= Cams[i].SpindleAfterCodes.Count - 1; m++)
			{
				string text7 = Cams[i].SpindleAfterCodes[m].ToString().Trim();
				if (text7.Length > 0)
				{
					AddCode(ref Codes, text7, postProcessor_0, pnt9CurrentPos);
				}
			}
			return;
		}
		bool flag = true;
		string text8 = "";
		if (postProcessor_0.ToolDef.UseToolWithComment)
		{
			text8 = postProcessor_0.CommentChar;
		}
		if (((i > 0) & !postProcessor_0.RepetitionDef.Tool) && Cams[i - 1].Tool.Data.No == Cams[i].Tool.Data.No)
		{
			flag = false;
		}
		if (flag)
		{
			if (postProcessor_0.ToolDef.UseToolInfo)
			{
				string newCommand = postProcessor_0.CommentChar + " Name : " + Cams[i].Tool.Data.Name + " , Diameter : " + Cams[i].Tool.Geometry.Diameter + " , Length: " + Cams[i].Tool.Geometry.Length;
				AddCode(ref Codes, newCommand, postProcessor_0, pnt9CurrentPos);
			}
			if ((i > 0) & postProcessor_0.ToolDef.MoveSafeBeforeToolChange)
			{
				text2 = (postProcessor_0.AxesUsing.Z ? ValueFormat(postProcessor_0, "Z", Cams[i - 1].ZSafeDistance, MoveDistance.Z + Cams[i - 1].MoveOffset.Z, Cams[i - 1].ZAxisIndex, Cams[i - 1]) : "");
				if (Cams[i - 1].Tool.Data.No != Cams[i].Tool.Data.No)
				{
					string newCommand2 = "G0 " + text2;
					AddCode(ref Codes, newCommand2, postProcessor_0, pnt9CurrentPos);
				}
			}
			for (int n = 0; n <= postProcessor_0.ToolDef.ToolData.PreCode.Count - 1; n++)
			{
				string text9 = postProcessor_0.ToolDef.ToolData.PreCode[n].ToString().Trim();
				if (text9.Length > 0)
				{
					AddCode(ref Codes, text9, postProcessor_0, pnt9CurrentPos);
				}
			}
			for (int num = 0; num <= Cams[i].ToolPreCodes.Count - 1; num++)
			{
				string text10 = Cams[i].ToolPreCodes[num].ToString().Trim();
				if (text10.Length > 0)
				{
					AddCode(ref Codes, text10, postProcessor_0, pnt9CurrentPos);
				}
			}
		}
		text3 = ValueFormat(postProcessor_0, "T", Cams[i].Tool.Data.No);
		if (postProcessor_0.ToolDef.UseToolSector)
		{
			text3 = text3.TrimEnd();
			text3 = ((!postProcessor_0.ToolDef.ToolSectorDataNextLine) ? (text3 + postProcessor_0.ToolDef.ToolSectorSeperateChar + Cams[i].Tool.Data.Sector + " ") : (text3 + Environment.NewLine + postProcessor_0.ToolDef.ToolSectorSeperateChar + Cams[i].Tool.Data.Sector + " "));
		}
		if (postProcessor_0.ToolDef.ToolChangeCode.Trim().Length > 0)
		{
			text3 = ((!postProcessor_0.ToolDef.ToolChangeMCommandFirst) ? (text3 + postProcessor_0.ToolDef.ToolChangeCode + " ") : (postProcessor_0.ToolDef.ToolChangeCode + " " + text3));
		}
		if (postProcessor_0.ToolDef.UseToolDChar)
		{
			text3 = text3 + "D" + Cams[i].Tool.Data.No + " ";
		}
		text3 += postProcessor_0.ToolDef.ToolAdditionalString;
		if (!flag)
		{
			return;
		}
		if (!postProcessor_0.SpindleDef.SpindleAtToolLine)
		{
			if (text3.Trim().Length > 0)
			{
				AddCode(ref Codes, text8 + text3, postProcessor_0, pnt9CurrentPos);
			}
			if (postProcessor_0.ToolDef.UseToolLengthCompensation)
			{
				string text11 = postProcessor_0.ToolDef.ToolLengthCompensationChar;
				if (postProcessor_0.ToolDef.UseToolLengthCompensationHeight)
				{
					int num2 = Cams[i].Tool.Data.HeightOffsetIndex;
					if (num2 <= 0)
					{
						num2 = Cams[i].Tool.Data.No;
					}
					text11 = text11 + " " + postProcessor_0.ToolDef.ToolLengthCompensationHeightChar + num2 + " " + postProcessor_0.ToolDef.ToolLengthCompensationZChar;
				}
				AddCode(ref Codes, text11, postProcessor_0, pnt9CurrentPos);
			}
			if (!postProcessor_0.ToolDef.UseToolLengthCompensation & postProcessor_0.ToolDef.UseToolLengthCompensationHeight)
			{
				string text12 = "";
				int num3 = Cams[i].Tool.Data.HeightOffsetIndex;
				if (num3 <= 0)
				{
					num3 = Cams[i].Tool.Data.No;
				}
				text12 = postProcessor_0.ToolDef.ToolLengthCompensationHeightChar + num3 + " " + postProcessor_0.ToolDef.ToolLengthCompensationZChar;
				AddCode(ref Codes, text12, postProcessor_0, pnt9CurrentPos);
			}
			if (flag)
			{
				for (int num4 = 0; num4 <= postProcessor_0.ToolDef.ToolData.AfterCode.Count - 1; num4++)
				{
					string text13 = postProcessor_0.ToolDef.ToolData.AfterCode[num4].ToString().Trim();
					if (text13.Length > 0)
					{
						AddCode(ref Codes, text13, postProcessor_0, pnt9CurrentPos);
					}
				}
				for (int num5 = 0; num5 <= Cams[i].ToolAfterCodes.Count - 1; num5++)
				{
					string text14 = Cams[i].ToolAfterCodes[num5].ToString().Trim();
					if (text14.Length > 0)
					{
						AddCode(ref Codes, text14, postProcessor_0, pnt9CurrentPos);
					}
				}
			}
			if (postProcessor_0.SpindleDef.PreCode.Count > 0)
			{
				for (int num6 = 0; num6 <= postProcessor_0.SpindleDef.PreCode.Count - 1; num6++)
				{
					string text15 = postProcessor_0.SpindleDef.PreCode[num6].ToString().Trim();
					if (text15.Length > 0)
					{
						AddCode(ref Codes, text15, postProcessor_0, pnt9CurrentPos);
					}
				}
			}
			for (int num7 = 0; num7 <= Cams[i].SpindlePreCodes.Count - 1; num7++)
			{
				string text16 = Cams[i].SpindlePreCodes[num7].ToString().Trim();
				if (text16.Length > 0)
				{
					AddCode(ref Codes, text16, postProcessor_0, pnt9CurrentPos);
				}
			}
			if (text.Length > 0)
			{
				AddCode(ref Codes, text, postProcessor_0, pnt9CurrentPos);
			}
			if (postProcessor_0.SpindleDef.AfterCode.Count > 0)
			{
				for (int num8 = 0; num8 <= postProcessor_0.SpindleDef.AfterCode.Count - 1; num8++)
				{
					string text17 = postProcessor_0.SpindleDef.AfterCode[num8].ToString().Trim();
					if (text17.Length > 0)
					{
						AddCode(ref Codes, text17, postProcessor_0, pnt9CurrentPos);
					}
				}
			}
			for (int num9 = 0; num9 <= Cams[i].SpindleAfterCodes.Count - 1; num9++)
			{
				string text18 = Cams[i].SpindleAfterCodes[num9].ToString().Trim();
				if (text18.Length > 0)
				{
					AddCode(ref Codes, text18, postProcessor_0, pnt9CurrentPos);
				}
			}
		}
		else
		{
			if (text3.Trim().Length > 0)
			{
				AddCode(ref Codes, text8 + text3 + text, postProcessor_0, pnt9CurrentPos);
			}
			if (postProcessor_0.ToolDef.UseToolLengthCompensation)
			{
				string text19 = postProcessor_0.ToolDef.ToolLengthCompensationChar;
				if (postProcessor_0.ToolDef.UseToolLengthCompensationHeight)
				{
					int num10 = Cams[i].Tool.Data.HeightOffsetIndex;
					if (num10 <= 0)
					{
						num10 = Cams[i].Tool.Data.No;
					}
					text19 = text19 + " " + postProcessor_0.ToolDef.ToolLengthCompensationHeightChar + num10 + " " + postProcessor_0.ToolDef.ToolLengthCompensationZChar;
				}
				AddCode(ref Codes, text19, postProcessor_0, pnt9CurrentPos);
			}
			if (!postProcessor_0.ToolDef.UseToolLengthCompensation & postProcessor_0.ToolDef.UseToolLengthCompensationHeight)
			{
				string text20 = "";
				int num11 = Cams[i].Tool.Data.HeightOffsetIndex;
				if (num11 <= 0)
				{
					num11 = Cams[i].Tool.Data.No;
				}
				text20 = postProcessor_0.ToolDef.ToolLengthCompensationHeightChar + num11 + " " + postProcessor_0.ToolDef.ToolLengthCompensationZChar;
				AddCode(ref Codes, text20, postProcessor_0, pnt9CurrentPos);
			}
			if (flag)
			{
				for (int num12 = 0; num12 <= postProcessor_0.ToolDef.ToolData.AfterCode.Count - 1; num12++)
				{
					string text21 = postProcessor_0.ToolDef.ToolData.AfterCode[num12].ToString().Trim();
					if (text21.Length > 0)
					{
						AddCode(ref Codes, text21, postProcessor_0, pnt9CurrentPos);
					}
				}
				for (int num13 = 0; num13 <= Cams[i].ToolAfterCodes.Count - 1; num13++)
				{
					string text22 = Cams[i].ToolAfterCodes[num13].ToString().Trim();
					if (text22.Length > 0)
					{
						AddCode(ref Codes, text22, postProcessor_0, pnt9CurrentPos);
					}
				}
			}
		}
		if (!postProcessor_0.ToolDef.UseToolAuxCodes || Cams[i].Tool.Aux.Count <= 0)
		{
			return;
		}
		for (int num14 = 0; num14 <= Cams[i].Tool.Aux.Count - 1; num14++)
		{
			if (Cams[i].Tool.Aux[num14].ToString().Length > 0)
			{
				AddCode(ref Codes, Cams[i].Tool.Aux[num14].ToString(), postProcessor_0, pnt9CurrentPos);
			}
		}
	}

	public void StartLines(ref string Codes, ref ArrayList CodeLists, Pnt9D pnt9CurrentPos)
	{
		for (int i = 0; i <= postProcessor_0.StartLinesWithoutProcess.Count - 1; i++)
		{
			if (postProcessor_0.StartLinesWithoutProcess[i].ToString().Trim().Length > 0)
			{
				CodeLists.Add(postProcessor_0.StartLinesWithoutProcess[i].ToString().Trim() + Environment.NewLine);
			}
		}
		if (postProcessor_0.PostVariables.Count > 0)
		{
			ArrayList arrayList = new ArrayList();
			for (int j = 0; j <= postProcessor_0.StartLines.Count - 1; j++)
			{
				string text = postProcessor_0.StartLines[j].ToString();
				bool flag = false;
				ArrayList Lines = new ArrayList();
				for (int k = 0; k <= postProcessor_0.PostVariables.Count - 1; k++)
				{
					string variableName = postProcessor_0.PostVariables[k].VariableName;
					if (!(variableName.Trim().ToLower() == text.Trim().ToLower()))
					{
						continue;
					}
					buString5.StringToArrayListByNewLine(postProcessor_0.PostVariables[k].Value, ref Lines);
					flag = true;
					if (postProcessor_0.PostVariables[k].ValueList.Count > 0)
					{
						for (int l = 0; l <= postProcessor_0.PostVariables[k].ValueList.Count - 1; l++)
						{
							Lines.Add(postProcessor_0.PostVariables[k].ValueList[l]);
						}
					}
				}
				if (Lines.Count != 0)
				{
					for (int m = 0; m <= Lines.Count - 1; m++)
					{
						if (Lines[m].ToString().Trim().Length > 0)
						{
							arrayList.Add(Lines[m]);
						}
					}
				}
				else if (!flag)
				{
					arrayList.Add(text);
				}
			}
			postProcessor_0.StartLines.Clear();
			postProcessor_0.StartLines.AddRange(arrayList);
		}
		for (int n = 0; n <= postProcessor_0.StartLines.Count - 1; n++)
		{
			string newCommand = postProcessor_0.StartLines[n].ToString();
			AddCode(ref Codes, newCommand, postProcessor_0, pnt9CurrentPos);
		}
		CodeLists.Add(Codes);
		Codes = "";
	}

	public void EndLines(ref string Codes, ref ArrayList CodeLists, Pnt9D pnt9CurrentPos)
	{
		for (int i = 0; i <= postProcessor_0.EndLines.Count - 1; i++)
		{
			AddCode(ref Codes, postProcessor_0.EndLines[i].ToString(), postProcessor_0, pnt9CurrentPos);
		}
		CodeLists.Add(Codes);
		Codes = "";
		for (int j = 0; j <= postProcessor_0.EndLinesWithoutProcess.Count - 1; j++)
		{
			if (postProcessor_0.EndLinesWithoutProcess[j].ToString().Trim().Length > 0)
			{
				string text = postProcessor_0.EndLinesWithoutProcess[j].ToString().Trim();
				if (j < postProcessor_0.EndLinesWithoutProcess.Count - 1)
				{
					text += Environment.NewLine;
				}
				CodeLists.Add(text);
			}
		}
	}

	public string ValueFormat(PostProcessor P, string Code, double Value, double MoveDistance, int AxisDefIndex, camTp Cam, string CharAxis = null)
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
											string text17 = P.WDef.Char;
											if (CharAxis != null && CharAxis.Length > 0)
											{
												text17 = CharAxis;
											}
											return text17 + text15 + num8.ToString("f" + P.WDef.Decimal, buSystem.CI) + text16;
										}
										double num9 = Math.Round(Value * P.VDef.Multiply + MoveDistance, P.VDef.RoundCount);
										string text18 = new string(' ', P.VDef.SpaceWithCharAndValue);
										string text19 = new string(' ', P.VDef.SpaceWithNextCommandAndValue);
										string text20 = P.VDef.Char;
										if (CharAxis != null && CharAxis.Length > 0)
										{
											text20 = CharAxis;
										}
										return text20 + text18 + num9.ToString("f" + P.VDef.Decimal, buSystem.CI) + text19;
									}
									double num10 = Math.Round(Value * P.UDef.Multiply + MoveDistance, P.UDef.RoundCount);
									string text21 = new string(' ', P.UDef.SpaceWithCharAndValue);
									string text22 = new string(' ', P.UDef.SpaceWithNextCommandAndValue);
									string text23 = P.UDef.Char;
									if (CharAxis != null && CharAxis.Length > 0)
									{
										text23 = CharAxis;
									}
									return text23 + text21 + num10.ToString("f" + P.UDef.Decimal, buSystem.CI) + text22;
								}
								double num11 = Math.Round(Value * P.CDef.Multiply + MoveDistance, P.CDef.RoundCount);
								string text24 = new string(' ', P.CDef.SpaceWithCharAndValue);
								string text25 = new string(' ', P.CDef.SpaceWithNextCommandAndValue);
								string text26 = P.CDef.Char;
								if (CharAxis != null && CharAxis.Length > 0)
								{
									text26 = CharAxis;
								}
								return text26 + text24 + num11.ToString("f" + P.CDef.Decimal, buSystem.CI) + text25;
							}
							double num12 = Math.Round(Value * P.BDef.Multiply + MoveDistance, P.BDef.RoundCount);
							string text27 = new string(' ', P.BDef.SpaceWithCharAndValue);
							string text28 = new string(' ', P.BDef.SpaceWithNextCommandAndValue);
							string text29 = P.BDef.Char;
							if (CharAxis != null && CharAxis.Length > 0)
							{
								text29 = CharAxis;
							}
							return text29 + text27 + num12.ToString("f" + P.BDef.Decimal, buSystem.CI) + text28;
						}
						double num13 = Math.Round(Value * P.ADef.Multiply + MoveDistance, P.ADef.RoundCount);
						string text30 = new string(' ', P.ADef.SpaceWithCharAndValue);
						string text31 = new string(' ', P.ADef.SpaceWithNextCommandAndValue);
						string text32 = P.ADef.Char;
						if (CharAxis != null && CharAxis.Length > 0)
						{
							text32 = CharAxis;
						}
						return text32 + text30 + num13.ToString("f" + P.ADef.Decimal, buSystem.CI) + text31;
					}
					if (AxisDefIndex == 0)
					{
						double num14 = Math.Round(Value * P.ZDef.Multiply + MoveDistance, P.ZDef.RoundCount);
						string text33 = new string(' ', P.ZDef.SpaceWithCharAndValue);
						string text34 = new string(' ', P.ZDef.SpaceWithNextCommandAndValue);
						string text35 = P.ZDef.Char;
						if (CharAxis != null && CharAxis.Length > 0)
						{
							text35 = CharAxis;
						}
						result = text35 + text33 + num14.ToString("f" + P.ZDef.Decimal, buSystem.CI) + text34;
					}
					if (AxisDefIndex == 1)
					{
						double num15 = Math.Round(Value * P.Z2Def.Multiply + MoveDistance, P.ZDef.RoundCount);
						string text36 = new string(' ', P.Z2Def.SpaceWithCharAndValue);
						string text37 = new string(' ', P.Z2Def.SpaceWithNextCommandAndValue);
						string text38 = P.Z2Def.Char;
						if (CharAxis != null && CharAxis.Length > 0)
						{
							text38 = CharAxis;
						}
						result = text38 + text36 + num15.ToString("f" + P.Z2Def.Decimal, buSystem.CI) + text37;
					}
					if (AxisDefIndex == 2)
					{
						double num16 = Math.Round(Value * P.Z3Def.Multiply + MoveDistance, P.ZDef.RoundCount);
						string text39 = new string(' ', P.Z3Def.SpaceWithCharAndValue);
						string text40 = new string(' ', P.Z3Def.SpaceWithNextCommandAndValue);
						string text41 = P.Z3Def.Char;
						if (CharAxis != null && CharAxis.Length > 0)
						{
							text41 = CharAxis;
						}
						result = text41 + text39 + num16.ToString("f" + P.Z3Def.Decimal, buSystem.CI) + text40;
					}
					if (AxisDefIndex == 3)
					{
						double num17 = Math.Round(Value * P.Z4Def.Multiply + MoveDistance, P.ZDef.RoundCount);
						string text42 = new string(' ', P.Z4Def.SpaceWithCharAndValue);
						string text43 = new string(' ', P.Z4Def.SpaceWithNextCommandAndValue);
						string text44 = P.Z4Def.Char;
						if (CharAxis != null && CharAxis.Length > 0)
						{
							text44 = CharAxis;
						}
						result = text44 + text42 + num17.ToString("f" + P.Z4Def.Decimal, buSystem.CI) + text43;
					}
					return result;
				}
				if (AxisDefIndex == 0)
				{
					double num18 = Math.Round(Value * P.YDef.Multiply + MoveDistance, P.YDef.RoundCount);
					string text45 = new string(' ', P.YDef.SpaceWithCharAndValue);
					string text46 = new string(' ', P.YDef.SpaceWithNextCommandAndValue);
					string text47 = P.YDef.Char;
					if (CharAxis != null && CharAxis.Length > 0)
					{
						text47 = CharAxis;
					}
					result = text47 + text45 + num18.ToString("f" + P.YDef.Decimal, buSystem.CI) + text46;
				}
				if (AxisDefIndex == 1)
				{
					double num19 = Math.Round(Value * P.Y2Def.Multiply + MoveDistance, P.YDef.RoundCount);
					string text48 = new string(' ', P.Y2Def.SpaceWithCharAndValue);
					string text49 = new string(' ', P.Y2Def.SpaceWithNextCommandAndValue);
					string text50 = P.Y2Def.Char;
					if (CharAxis != null && CharAxis.Length > 0)
					{
						text50 = CharAxis;
					}
					result = text50 + text48 + num19.ToString("f" + P.Y2Def.Decimal, buSystem.CI) + text49;
				}
				if (AxisDefIndex == 2)
				{
					double num20 = Math.Round(Value * P.Y3Def.Multiply + MoveDistance, P.YDef.RoundCount);
					string text51 = new string(' ', P.Y3Def.SpaceWithCharAndValue);
					string text52 = new string(' ', P.Y3Def.SpaceWithNextCommandAndValue);
					string text53 = P.Y3Def.Char;
					if (CharAxis != null && CharAxis.Length > 0)
					{
						text53 = CharAxis;
					}
					result = text53 + text51 + num20.ToString("f" + P.Y3Def.Decimal, buSystem.CI) + text52;
				}
				if (AxisDefIndex == 3)
				{
					double num21 = Math.Round(Value * P.Y4Def.Multiply + MoveDistance, P.YDef.RoundCount);
					string text54 = new string(' ', P.Y4Def.SpaceWithCharAndValue);
					string text55 = new string(' ', P.Y4Def.SpaceWithNextCommandAndValue);
					string text56 = P.Y4Def.Char;
					if (CharAxis != null && CharAxis.Length > 0)
					{
						text56 = CharAxis;
					}
					result = text56 + text54 + num21.ToString("f" + P.Y4Def.Decimal, buSystem.CI) + text55;
				}
				return result;
			}
			if (AxisDefIndex == 0)
			{
				double num22 = Math.Round(Value * P.XDef.Multiply + MoveDistance, P.XDef.RoundCount);
				string text57 = new string(' ', P.XDef.SpaceWithCharAndValue);
				string text58 = new string(' ', P.XDef.SpaceWithNextCommandAndValue);
				string text59 = P.XDef.Char;
				if (CharAxis != null && CharAxis.Length > 0)
				{
					text59 = CharAxis;
				}
				result = text59 + text57 + num22.ToString("f" + P.XDef.Decimal, buSystem.CI) + text58;
			}
			if (AxisDefIndex == 1)
			{
				double num23 = Math.Round(Value * P.X2Def.Multiply + MoveDistance, P.XDef.RoundCount);
				string text60 = new string(' ', P.X2Def.SpaceWithCharAndValue);
				string text61 = new string(' ', P.X2Def.SpaceWithNextCommandAndValue);
				string text62 = P.X2Def.Char;
				if (CharAxis != null && CharAxis.Length > 0)
				{
					text62 = CharAxis;
				}
				result = text62 + text60 + num23.ToString("f" + P.X2Def.Decimal, buSystem.CI) + text61;
			}
			if (AxisDefIndex == 2)
			{
				double num24 = Math.Round(Value * P.X3Def.Multiply + MoveDistance, P.XDef.RoundCount);
				string text63 = new string(' ', P.X3Def.SpaceWithCharAndValue);
				string text64 = new string(' ', P.X3Def.SpaceWithNextCommandAndValue);
				string text65 = P.X3Def.Char;
				if (CharAxis != null && CharAxis.Length > 0)
				{
					text65 = CharAxis;
				}
				result = text65 + text63 + num24.ToString("f" + P.X3Def.Decimal, buSystem.CI) + text64;
			}
			if (AxisDefIndex == 3)
			{
				double num25 = Math.Round(Value * P.X4Def.Multiply + MoveDistance, P.XDef.RoundCount);
				string text66 = new string(' ', P.X4Def.SpaceWithCharAndValue);
				string text67 = new string(' ', P.X4Def.SpaceWithNextCommandAndValue);
				string text68 = P.X4Def.Char;
				if (CharAxis != null && CharAxis.Length > 0)
				{
					text68 = CharAxis;
				}
				result = text68 + text66 + num25.ToString("f" + P.X4Def.Decimal, buSystem.CI) + text67;
			}
			return result;
		}
		catch (Exception mSException)
		{
			string text69 = "Post: " + P.ToString() + " - Code: " + Code.ToString() + " - Value: " + Value + " - MoveDistance: " + MoveDistance + " - AxisDefIndex: " + AxisDefIndex;
			buLog.addLog(text69, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text69);
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
			buString5.StringToArrayByNewLine(RefCode, ref Lines);
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
				buString5.ReadCharValue(text, "N", ref Value);
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

	public void GetPostParameter(ref string AddtionalString, TpPnt9D CamPoint)
	{
		string text = "";
		if (AddtionalString.IndexOf("{") < 0)
		{
			return;
		}
		text = buString5.FindStringBetweenTwoChar(AddtionalString, "{", "}");
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
