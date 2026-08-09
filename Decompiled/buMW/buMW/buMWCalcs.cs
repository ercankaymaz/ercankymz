using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using _0002;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.buEntities;
using buMW.CamForms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buMW;

public class buMWCalcs
{
	public static bool AdvancedTriMesh;

	public static bool GetProgressUpdating;

	public static MWParameters varCamMeshRoughPars;

	public static MWParameters varCamMeshParalelPars;

	public static MWParameters varCamMeshContantZPars;

	public static MWParameters varCamMeshPencilPars;

	public static MWParameters varCamMeshProjectionPars;

	public static MWParameters varCamMeshFlatlandPars;

	public static MWParameters varCamMeshContantCuspPars;

	public static MWParameters varCamWFPocketPars;

	public static MWParameters varCamWFContourPars;

	public static MWParameters varCamWFContour4XPars;

	public static MWParameters varCamDrillPars;

	public static MWParameters varCamContouringPars;

	public static MWParameters varCamSurfacePars;

	public static MWParameters varCam3AXTo5AXPars;

	public static MWParameters varCamGeodesicPars;

	public static List<Entity> OrientationLines;

	public static List<Entity> CamEntities;

	public static List<List<Entity>> entityProjection;

	public buMWUpdateHandler updateHandler = null;

	public List<Meshd> Stock = null;

	public GeoLib mwCamDataParameter = null;

	public camParameters5 buCamDataParameter = null;

	[CompilerGenerated]
	private CalculationEventHandler m__0001;

	[CompilerGenerated]
	private CalculationEventHandler _0002;

	[CompilerGenerated]
	private CalculationEventHandler _0003;

	[CompilerGenerated]
	private CalculationEventHandler _0004;

	[CompilerGenerated]
	private CalculationErrorEventHandler m__0001;

	[CompilerGenerated]
	private MWCalculationResultHandler m__0001;

	public buCamCalcSettings Settings = new buCamCalcSettings();

	public buCamCalcRuntimeSettings SettingsRuntime = new buCamCalcRuntimeSettings();

	public List<List<eEntities>> ProjectionCurves = new List<List<eEntities>>();

	public List<ModuleWorksMeshData> MeshEntities = new List<ModuleWorksMeshData>();

	[NonSerialized]
	internal static GetString _0001;

	public event CalculationEventHandler CalculationInProgressMwCalc
	{
		[CompilerGenerated]
		add
		{
			CalculationEventHandler calculationEventHandler = this.m__0001;
			while (true)
			{
				CalculationEventHandler calculationEventHandler2 = calculationEventHandler;
				while (true)
				{
					CalculationEventHandler obj = (CalculationEventHandler)_0016._008D_0006(calculationEventHandler2, value);
					CalculationEventHandler value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					calculationEventHandler = Interlocked.CompareExchange(ref this.m__0001, value2, calculationEventHandler2);
					if ((object)calculationEventHandler != calculationEventHandler2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
		[CompilerGenerated]
		remove
		{
			CalculationEventHandler calculationEventHandler = this.m__0001;
			while (true)
			{
				CalculationEventHandler calculationEventHandler2 = calculationEventHandler;
				while (true)
				{
					CalculationEventHandler obj = (CalculationEventHandler)_0016._008E_0006(calculationEventHandler2, value);
					CalculationEventHandler value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					calculationEventHandler = Interlocked.CompareExchange(ref this.m__0001, value2, calculationEventHandler2);
					if ((object)calculationEventHandler != calculationEventHandler2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
	}

	public event CalculationEventHandler CalculationStarted
	{
		[CompilerGenerated]
		add
		{
			CalculationEventHandler calculationEventHandler = _0002;
			while (true)
			{
				CalculationEventHandler calculationEventHandler2 = calculationEventHandler;
				while (true)
				{
					CalculationEventHandler obj = (CalculationEventHandler)_0016._008D_0006(calculationEventHandler2, value);
					CalculationEventHandler value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					calculationEventHandler = Interlocked.CompareExchange(ref _0002, value2, calculationEventHandler2);
					if ((object)calculationEventHandler != calculationEventHandler2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
		[CompilerGenerated]
		remove
		{
			CalculationEventHandler calculationEventHandler = _0002;
			while (true)
			{
				CalculationEventHandler calculationEventHandler2 = calculationEventHandler;
				while (true)
				{
					CalculationEventHandler obj = (CalculationEventHandler)_0016._008E_0006(calculationEventHandler2, value);
					CalculationEventHandler value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					calculationEventHandler = Interlocked.CompareExchange(ref _0002, value2, calculationEventHandler2);
					if ((object)calculationEventHandler != calculationEventHandler2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
	}

	public event CalculationEventHandler CalculationEnded
	{
		[CompilerGenerated]
		add
		{
			CalculationEventHandler calculationEventHandler = _0003;
			while (true)
			{
				CalculationEventHandler calculationEventHandler2 = calculationEventHandler;
				while (true)
				{
					CalculationEventHandler obj = (CalculationEventHandler)_0016._008D_0006(calculationEventHandler2, value);
					CalculationEventHandler value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					calculationEventHandler = Interlocked.CompareExchange(ref _0003, value2, calculationEventHandler2);
					if ((object)calculationEventHandler != calculationEventHandler2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
		[CompilerGenerated]
		remove
		{
			CalculationEventHandler calculationEventHandler = _0003;
			while (true)
			{
				CalculationEventHandler calculationEventHandler2 = calculationEventHandler;
				while (true)
				{
					CalculationEventHandler obj = (CalculationEventHandler)_0016._008E_0006(calculationEventHandler2, value);
					CalculationEventHandler value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					calculationEventHandler = Interlocked.CompareExchange(ref _0003, value2, calculationEventHandler2);
					if ((object)calculationEventHandler != calculationEventHandler2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
	}

	public event CalculationEventHandler CalculationCanceled
	{
		[CompilerGenerated]
		add
		{
			CalculationEventHandler calculationEventHandler = _0004;
			while (true)
			{
				CalculationEventHandler calculationEventHandler2 = calculationEventHandler;
				while (true)
				{
					CalculationEventHandler obj = (CalculationEventHandler)_0016._008D_0006(calculationEventHandler2, value);
					CalculationEventHandler value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					calculationEventHandler = Interlocked.CompareExchange(ref _0004, value2, calculationEventHandler2);
					if ((object)calculationEventHandler != calculationEventHandler2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
		[CompilerGenerated]
		remove
		{
			CalculationEventHandler calculationEventHandler = _0004;
			while (true)
			{
				CalculationEventHandler calculationEventHandler2 = calculationEventHandler;
				while (true)
				{
					CalculationEventHandler obj = (CalculationEventHandler)_0016._008E_0006(calculationEventHandler2, value);
					CalculationEventHandler value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					calculationEventHandler = Interlocked.CompareExchange(ref _0004, value2, calculationEventHandler2);
					if ((object)calculationEventHandler != calculationEventHandler2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
	}

	public event CalculationErrorEventHandler CalculationError
	{
		[CompilerGenerated]
		add
		{
			CalculationErrorEventHandler calculationErrorEventHandler = this.m__0001;
			while (true)
			{
				CalculationErrorEventHandler calculationErrorEventHandler2 = calculationErrorEventHandler;
				while (true)
				{
					CalculationErrorEventHandler obj = (CalculationErrorEventHandler)_0016._008D_0006(calculationErrorEventHandler2, value);
					CalculationErrorEventHandler value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					calculationErrorEventHandler = Interlocked.CompareExchange(ref this.m__0001, value2, calculationErrorEventHandler2);
					if ((object)calculationErrorEventHandler != calculationErrorEventHandler2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
		[CompilerGenerated]
		remove
		{
			CalculationErrorEventHandler calculationErrorEventHandler = this.m__0001;
			while (true)
			{
				CalculationErrorEventHandler calculationErrorEventHandler2 = calculationErrorEventHandler;
				while (true)
				{
					CalculationErrorEventHandler obj = (CalculationErrorEventHandler)_0016._008E_0006(calculationErrorEventHandler2, value);
					CalculationErrorEventHandler value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					calculationErrorEventHandler = Interlocked.CompareExchange(ref this.m__0001, value2, calculationErrorEventHandler2);
					if ((object)calculationErrorEventHandler != calculationErrorEventHandler2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
	}

	public event MWCalculationResultHandler GetCalculations
	{
		[CompilerGenerated]
		add
		{
			MWCalculationResultHandler mWCalculationResultHandler = this.m__0001;
			while (true)
			{
				MWCalculationResultHandler mWCalculationResultHandler2 = mWCalculationResultHandler;
				while (true)
				{
					MWCalculationResultHandler obj = (MWCalculationResultHandler)_0016._008D_0006(mWCalculationResultHandler2, value);
					MWCalculationResultHandler value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					mWCalculationResultHandler = Interlocked.CompareExchange(ref this.m__0001, value2, mWCalculationResultHandler2);
					if ((object)mWCalculationResultHandler != mWCalculationResultHandler2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
		[CompilerGenerated]
		remove
		{
			MWCalculationResultHandler mWCalculationResultHandler = this.m__0001;
			while (true)
			{
				MWCalculationResultHandler mWCalculationResultHandler2 = mWCalculationResultHandler;
				while (true)
				{
					MWCalculationResultHandler obj = (MWCalculationResultHandler)_0016._008E_0006(mWCalculationResultHandler2, value);
					MWCalculationResultHandler value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					mWCalculationResultHandler = Interlocked.CompareExchange(ref this.m__0001, value2, mWCalculationResultHandler2);
					if ((object)mWCalculationResultHandler != mWCalculationResultHandler2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
	}

	public buMWCalcs()
	{
		if (!_0001(buMWCalcs._0001(107396763)))
		{
			throw new RegisterException(buMWCalcs._0001(107396763));
		}
		if (this.m__0001 != null)
		{
			this.m__0001(new CalculationEventArg(0.0, 0.0, 0, buMWCalcs._0001(107396718), buMWCalcs._0001(107396718)));
		}
		if (_0002 != null)
		{
			_0002(new CalculationEventArg(0.0, 0.0, 0, buMWCalcs._0001(107396718), buMWCalcs._0001(107396718)));
		}
		if (_0003 != null)
		{
			_0003(new CalculationEventArg(0.0, 0.0, 0, buMWCalcs._0001(107396718), buMWCalcs._0001(107396718)));
		}
		if (_0004 != null)
		{
			_0004(new CalculationEventArg(0.0, 0.0, 0, buMWCalcs._0001(107396718), buMWCalcs._0001(107396718)));
		}
		if (this.m__0001 != null)
		{
			this.m__0001(new CalculationErrorEventArg(buMWCalcs._0001(107396718), buMWCalcs._0001(107396718), buMWCalcs._0001(107396718), 0));
		}
	}

	internal static bool _0001(string P_0)
	{
		if (global::_0001._0001(buVector5.AskMeResult, buMWCalcs._0001(107396717)) | (buVector5.AskMeValue != -5861345679435.912))
		{
			BinaryReader binaryReader = null;
			try
			{
				FileInfo fileInfo = new FileInfo(global::_0002._0003(AppPath.Base, buMWCalcs._0001(107396660)));
				if (!global::_0003._007E_0004(fileInfo))
				{
					throw new RegisterException(P_0);
				}
				if (global::_0003._007E_0004(fileInfo))
				{
					List<double> list = new List<double>();
					List<string> list2 = new List<string>();
					List<string> list3 = new List<string>();
					bool flag = false;
					bool flag2 = false;
					try
					{
						global::_0004._0010_0003(buMWCalcs._0001(107397123), buMWCalcs._0001(107397146), buMWCalcs._0001(107397097), buMWCalcs._0001(107397092), 0.0, 0.0, false);
						FileStream input = new FileStream(global::_0005._007E_0011_0003(fileInfo), FileMode.Open, FileAccess.Read, FileShare.None);
						binaryReader = new BinaryReader(input);
						int num = 0;
						string text = buMWCalcs._0001(107396718);
						string text2 = buMWCalcs._0001(107396718);
						string text3 = buMWCalcs._0001(107396718);
						string text4 = buMWCalcs._0001(107396718);
						string text5 = buMWCalcs._0001(107396718);
						string text6 = buMWCalcs._0001(107396718);
						string text7 = buMWCalcs._0001(107396718);
						string text8 = buMWCalcs._0001(107396718);
						string text9 = buMWCalcs._0001(107396718);
						string text10 = buMWCalcs._0001(107396718);
						string text11 = buMWCalcs._0001(107396718);
						string text12 = buMWCalcs._0001(107396718);
						string text13 = buMWCalcs._0001(107396718);
						string text14 = buMWCalcs._0001(107396718);
						float num2 = 0f;
						double num3 = 0.0;
						while (true)
						{
							double num4 = num3;
							decimal num5 = default(decimal);
							int num6 = 0;
							for (int i = 0; i < 755; i++)
							{
								num2 = global::_0006._007E_0015_0003(binaryReader);
							}
							int num7 = 0;
							while (true)
							{
								int num8;
								if (num7 < 1274)
								{
									num4 = global::_0007._007E_0016_0003(binaryReader);
									num8 = num7 + 1;
									if (6u != 0)
									{
										num7 = num8;
										continue;
									}
									goto IL_05b6;
								}
								for (int j = 0; j < 1498; j++)
								{
									num5 = global::_0008._007E_0098_0005(binaryReader);
								}
								int num9 = 0;
								goto IL_02e4;
								IL_0b74:
								int num11;
								int num10 = num11;
								if (8 == 0)
								{
									goto IL_0508;
								}
								int num12 = num;
								goto IL_0b7e;
								IL_02e4:
								int num13;
								if (num9 < 5614)
								{
									num4 = global::_000E._007E_009A_0005(binaryReader);
									if (3u != 0)
									{
										num13 = num9 + 1;
										goto IL_02e2;
									}
									goto IL_083a;
								}
								for (int k = 0; k < 4243; k++)
								{
									num2 = global::_0006._007E_0015_0003(binaryReader);
								}
								int num14 = 0;
								while (true)
								{
									int num15 = ((num14 < 9867) ? 1 : 0);
									if (false)
									{
										goto IL_035e;
									}
									if (num15 != 0)
									{
										num4 = global::_0007._007E_0016_0003(binaryReader);
										num14++;
										continue;
									}
									int num16 = 0;
									goto IL_0362;
									IL_0362:
									if (num16 >= 3886)
									{
										break;
									}
									num5 = global::_0008._007E_0098_0005(binaryReader);
									num15 = num16;
									goto IL_035e;
									IL_035e:
									num16 = num15 + 1;
									goto IL_0362;
								}
								for (int l = 0; l < 5765; l++)
								{
									num4 = global::_000E._007E_009A_0005(binaryReader);
								}
								num6 = global::_000E._007E_009A_0005(binaryReader);
								list.Clear();
								list2.Clear();
								list3.Clear();
								int num17 = 0;
								goto IL_0506;
								IL_08e0:
								global::_0007._007E_0016_0003(binaryReader);
								global::_0007._007E_0016_0003(binaryReader);
								num3 = global::_0007._007E_0016_0003(binaryReader);
								if (false)
								{
									break;
								}
								global::_0007._007E_0016_0003(binaryReader);
								global::_0007._007E_0016_0003(binaryReader);
								global::_0007._007E_0016_0003(binaryReader);
								global::_0007._007E_0016_0003(binaryReader);
								global::_0007._007E_0016_0003(binaryReader);
								global::_0007._007E_0016_0003(binaryReader);
								num = global::_000E._007E_009A_0005(binaryReader);
								for (int m = 0; m < num; m++)
								{
									byte b = _000F._0015_0006(global::_0007._007E_0016_0003(binaryReader) / 64.3685);
									text10 = global::_0002._0003(text10, _0010._0016_0006(b).ToString());
								}
								string text15 = text10;
								num = global::_000E._007E_009A_0005(binaryReader);
								int num18 = 0;
								while (true)
								{
									num10 = num18;
									num12 = num;
									if (false)
									{
										break;
									}
									if (num10 < num12)
									{
										byte b2 = _000F._0015_0006(global::_0007._007E_0016_0003(binaryReader) / 64.3685);
										text11 = global::_0002._0003(text11, _0010._0016_0006(b2).ToString());
										num18++;
										continue;
									}
									goto IL_0a30;
								}
								goto IL_0b7e;
								IL_02e2:
								num9 = num13;
								goto IL_02e4;
								IL_0b7e:
								if (num10 < num12)
								{
									byte b3 = _000F._0015_0006(global::_0007._007E_0016_0003(binaryReader) / 64.3685);
									text14 = global::_0002._0003(text14, _0010._0016_0006(b3).ToString());
									num11++;
									goto IL_0b74;
								}
								string text16 = text14;
								global::_0007._007E_0016_0003(binaryReader);
								global::_0007._007E_0016_0003(binaryReader);
								global::_0007._007E_0016_0003(binaryReader);
								global::_0003._007E_0005(binaryReader);
								global::_0003._007E_0005(binaryReader);
								flag = global::_0003._007E_0005(binaryReader);
								global::_0003._007E_0005(binaryReader);
								global::_0003._007E_0005(binaryReader);
								bool flag3 = global::_0003._007E_0005(binaryReader);
								global::_0003._007E_0005(binaryReader);
								flag2 = global::_0003._007E_0005(binaryReader);
								global::_0003._007E_0005(binaryReader);
								global::_0003._007E_0005(binaryReader);
								global::_0003._007E_0005(binaryReader);
								global::_0003._007E_0005(binaryReader);
								global::_0003._007E_0005(binaryReader);
								global::_0007._007E_0016_0003(binaryReader);
								global::_0007._007E_0016_0003(binaryReader);
								global::_0007._007E_0016_0003(binaryReader);
								global::_0011._007E_0017_0006(binaryReader);
								global::_0004._0010_0003(buMWCalcs._0001(107397123), buMWCalcs._0001(107397119), buMWCalcs._0001(107397097), buMWCalcs._0001(107397070), 0.0, 0.0, false);
								goto end_IL_0235;
								IL_05b6:
								byte b4 = (byte)num8;
								text2 = global::_0002._0003(text2, _0010._0016_0006(b4).ToString());
								int num19 = num19 + 1;
								goto IL_05e2;
								IL_05e2:
								if (num19 < num)
								{
									num8 = _000F._0015_0006(global::_0007._007E_0016_0003(binaryReader) / 54.3685);
									goto IL_05b6;
								}
								num = global::_000E._007E_009A_0005(binaryReader);
								int num20 = 0;
								while (true)
								{
									num13 = num20;
									if (5 == 0)
									{
										break;
									}
									if (num13 < num)
									{
										byte b5 = _000F._0015_0006(global::_0007._007E_0016_0003(binaryReader) / 54.3685);
										text3 = global::_0002._0003(text3, _0010._0016_0006(b5).ToString());
										num20++;
										continue;
									}
									goto IL_065e;
								}
								goto IL_02e2;
								IL_04f5:
								string text17;
								list3.Add(text17);
								num17++;
								goto IL_0506;
								IL_0a30:
								string text18 = text11;
								num = global::_000E._007E_009A_0005(binaryReader);
								int num21 = 0;
								while (true)
								{
									bool flag4 = num21 < num;
									if (false)
									{
										break;
									}
									if (flag4)
									{
										byte b6 = _000F._0015_0006(global::_0007._007E_0016_0003(binaryReader) / 64.3685);
										text12 = global::_0002._0003(text12, _0010._0016_0006(b6).ToString());
										num21++;
										continue;
									}
									goto IL_0aa4;
								}
								goto IL_04f5;
								IL_065e:
								num = global::_000E._007E_009A_0005(binaryReader);
								for (int n = 0; n < num; n++)
								{
									byte b7 = _000F._0015_0006(global::_0007._007E_0016_0003(binaryReader) / 54.3685);
									text4 = global::_0002._0003(text4, _0010._0016_0006(b7).ToString());
								}
								num = global::_000E._007E_009A_0005(binaryReader);
								for (int num22 = 0; num22 < num; num22++)
								{
									byte b8 = _000F._0015_0006(global::_0007._007E_0016_0003(binaryReader) / 54.3685);
									text5 = global::_0002._0003(text5, _0010._0016_0006(b8).ToString());
								}
								num = global::_000E._007E_009A_0005(binaryReader);
								for (int num23 = 0; num23 < num; num23++)
								{
									byte b9 = _000F._0015_0006(global::_0007._007E_0016_0003(binaryReader) / 54.3685);
									text6 = global::_0002._0003(text6, _0010._0016_0006(b9).ToString());
								}
								num = global::_000E._007E_009A_0005(binaryReader);
								for (int num24 = 0; num24 < num; num24++)
								{
									byte b10 = _000F._0015_0006(global::_0007._007E_0016_0003(binaryReader) / 54.3685);
									text7 = global::_0002._0003(text7, _0010._0016_0006(b10).ToString());
								}
								num = global::_000E._007E_009A_0005(binaryReader);
								int num25 = 0;
								goto IL_0864;
								IL_0508:
								if (num10 <= num6 - 1)
								{
									double num26 = 0.0;
									num26 = global::_0007._007E_0016_0003(binaryReader) / 65.87;
									list.Add(num26);
									int num27 = global::_000E._007E_009A_0005(binaryReader);
									string text19 = buMWCalcs._0001(107396718);
									for (int num28 = 0; num28 < num27; num28++)
									{
										byte b11 = _000F._0015_0006(global::_0007._007E_0016_0003(binaryReader) / 46.8613);
										text19 = global::_0002._0003(text19, _0010._0016_0006(b11).ToString());
									}
									list2.Add(text19);
									num27 = global::_000E._007E_009A_0005(binaryReader);
									text17 = buMWCalcs._0001(107396718);
									for (int num29 = 0; num29 < num27; num29++)
									{
										byte b12 = _000F._0015_0006(global::_0007._007E_0016_0003(binaryReader) / 86.3456);
										text17 = global::_0002._0003(text17, _0010._0016_0006(b12).ToString());
									}
									goto IL_04f5;
								}
								num = global::_000E._007E_009A_0005(binaryReader);
								for (int num30 = 0; num30 < num; num30++)
								{
									byte b13 = _000F._0015_0006(global::_0007._007E_0016_0003(binaryReader) / 54.3685);
									text = global::_0002._0003(text, _0010._0016_0006(b13).ToString());
								}
								num = global::_000E._007E_009A_0005(binaryReader);
								num19 = 0;
								goto IL_05e2;
								IL_0aa4:
								string text20 = text12;
								num = global::_000E._007E_009A_0005(binaryReader);
								int num31 = 0;
								goto IL_0b06;
								IL_0506:
								num10 = num17;
								goto IL_0508;
								IL_0b02:
								int num32;
								num31 = num32 + 1;
								goto IL_0b06;
								IL_083a:
								byte b14;
								text8 = global::_0002._0003(text8, _0010._0016_0006(b14).ToString());
								num25++;
								goto IL_0864;
								IL_0864:
								if (num25 < num)
								{
									b14 = _000F._0015_0006(global::_0007._007E_0016_0003(binaryReader) / 54.3685);
									goto IL_083a;
								}
								num = global::_000E._007E_009A_0005(binaryReader);
								int num33 = 0;
								while (true)
								{
									num32 = num33;
									if (false)
									{
										break;
									}
									if (num32 < num)
									{
										byte b15 = _000F._0015_0006(global::_0007._007E_0016_0003(binaryReader) / 54.3685);
										text9 = global::_0002._0003(text9, _0010._0016_0006(b15).ToString());
										num33++;
										continue;
									}
									goto IL_08e0;
								}
								goto IL_0b02;
								IL_0b06:
								if (num31 < num)
								{
									byte b16 = _000F._0015_0006(global::_0007._007E_0016_0003(binaryReader) / 64.3685);
									text13 = global::_0002._0003(text13, _0010._0016_0006(b16).ToString());
									num32 = num31;
									goto IL_0b02;
								}
								string text21 = text13;
								num = global::_000E._007E_009A_0005(binaryReader);
								num11 = 0;
								goto IL_0b74;
							}
							continue;
							end_IL_0235:
							break;
						}
					}
					catch (Exception ex)
					{
						_0012._0089_0006(global::_0005._007E_0012_0003(ex));
						global::_0011._007E_0017_0006(binaryReader);
						throw new RegisterException(P_0);
					}
					List<string> list4;
					if (5u != 0)
					{
						list4 = new List<string>();
					}
					List<string> list5 = new List<string>();
					string text22 = buMWCalcs._0001(107396718);
					_0013._008A_0006(ref list4);
					global::_0004._0010_0003(buMWCalcs._0001(107397123), buMWCalcs._0001(107397065), buMWCalcs._0001(107397097), buMWCalcs._0001(107397070), 0.0, 0.0, false);
					_0014._008B_0006(ref list5);
					global::_0004._0010_0003(buMWCalcs._0001(107397123), buMWCalcs._0001(107397080), buMWCalcs._0001(107397097), buMWCalcs._0001(107397070), 0.0, 0.0, false);
					_0015._008C_0006(ref text22);
					global::_0004._0010_0003(buMWCalcs._0001(107397123), buMWCalcs._0001(107397031), buMWCalcs._0001(107397097), buMWCalcs._0001(107397070), 0.0, 0.0, false);
					if (!flag && !flag2)
					{
						bool flag5 = _0005._0002._0001(list4, list5, P_0, text22, list);
						global::_0004._0010_0003(buMWCalcs._0001(107397123), buMWCalcs._0001(107397031), buMWCalcs._0001(107397097), buMWCalcs._0001(107397070), 0.0, 0.0, false);
						if (flag5)
						{
							return true;
						}
					}
					throw new RegisterException(P_0);
				}
				throw new RegisterException(P_0);
			}
			catch (Exception)
			{
				throw new RegisterException(P_0);
			}
		}
		return true;
	}

	public void Init()
	{
		updateHandler.CalculationUpdate += GetProgress;
	}

	public bool CalculateWireframe(ToolBase5 Tool, List<buMWCurveEntities> CurveEntities, WireframeBasedTpCalcParamsPattern CalcType, MWCalculationOptions Option, ref MWCalculationResult camResult)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Expected O, but got Unknown
		//IL_0831: Unknown result type (might be due to invalid IL or missing references)
		//IL_0838: Expected O, but got Unknown
		//IL_0949: Unknown result type (might be due to invalid IL or missing references)
		//IL_0953: Expected O, but got Unknown
		//IL_096b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0975: Expected O, but got Unknown
		//IL_0983: Unknown result type (might be due to invalid IL or missing references)
		//IL_098d: Expected O, but got Unknown
		//IL_08b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08be: Expected O, but got Unknown
		try
		{
			if (mwCamDataParameter != null)
			{
				if (updateHandler != null)
				{
					goto IL_006b;
				}
				goto IL_0a4b;
			}
			if (3u != 0)
			{
				return false;
			}
			goto end_IL_0001;
			IL_006b:
			Tool mwTool = null;
			GeoLib val = new GeoLib(Unit.Metric);
			buMWUpdateHandler.CancelOperation = false;
			int num = CreateMWTool(Tool, ref mwTool);
			if (num == 1)
			{
				val.ToolInfo = mwTool;
				val.MachParam = new MachiningParams(mwCamDataParameter.MachParam);
				CopyGeoLibProperties(mwCamDataParameter, val);
				val.MachParam.TpCalculationMethodsParams.Method = TpCalcMethodsParamsMethod.TcmWireframeBased;
				val.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.Pattern = CalcType;
				val.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType3axis;
				val.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.StartFromPosition = WireframeBasedTpCalcParamsStartFromPosition.SfpUserDefinedStartPoint;
				bool is5AxisWireframe = Option.is5AxisWireframe;
				if (7u != 0 && is5AxisWireframe)
				{
					val.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType5axis;
					val.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.Pattern = WireframeBasedTpCalcParamsPattern.Wfb5axisProfiling;
				}
				List<Point3d<double>> list = new List<Point3d<double>>();
				if (Option.UseConstantStartPoint)
				{
					list.Add(new Point3d<double>(Option.StartPointX, Option.StartPointY, 0.0));
				}
				List<Curve> list2 = new List<Curve>();
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = CurveEntities.Count;
					if (false)
					{
						goto IL_0223;
					}
					int num5 = ((num3 <= num4 - 1) ? 1 : 0);
					int num7;
					while (num5 == 0)
					{
						if (list.Count == 0)
						{
							list.Add(new Point3d<double>(0.0, 0.0, 0.0));
						}
						List<Curve> list3 = new List<Curve>();
						bool num6 = OrientationLines.Count > 0;
						if (5u != 0)
						{
							if (num6)
							{
								for (int i = 0; i <= OrientationLines.Count - 1; i++)
								{
									Curve mwEntity = null;
									ConvertWireEntity(OrientationLines[i], ref mwEntity);
									list3.Add(mwEntity);
								}
							}
							val.StartPoints = list;
							val.MachParam.StartPosFlag = Option.UseStartPoint;
							val.DriveCurves = list2;
							if (list3.Count > 0)
							{
								val.OrientationLines = list3;
							}
							val.SetUpdateHandler((UpdateHandler)(object)updateHandler);
							goto IL_035c;
						}
						goto IL_03bc;
						IL_0626:
						val.MachParam.LinkParams.FirstEntry.LeadController.UseDefaultLeadParams = false;
						val.MachParam.LinkParams.LastExit.LeadController.UseDefaultLeadParams = false;
						((InterlinkHandeler)val.MachParam.LinkParams.GapsAlongCut).SmallMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
						((InterlinkHandeler)val.MachParam.LinkParams.GapsAlongCut).SmallMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
						((InterlinkHandeler)val.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
						((InterlinkHandeler)val.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
						((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenSlices).SmallMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
						((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenSlices).SmallMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
						((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenSlices).LargeMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
						((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenSlices).LargeMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
						((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenPasses).SmallMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
						((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenPasses).SmallMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
						((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenPasses).LargeMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
						((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenPasses).LargeMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
						global::_0002._0001 obj = new global::_0002._0001(Unit.Metric);
						MachiningParameterDialog val2 = new MachiningParameterDialog(val, (ParamInteractor)(object)obj);
						bool flag = true;
						if (Settings.ShowMwDialogBox)
						{
							flag = val2.Show();
						}
						CollisionsReport val3;
						CutterRadiusCompParamsCompensationType compensationType;
						if (flag)
						{
							if (_0002 != null)
							{
								CalculationEventArg calculationEventArg = new CalculationEventArg();
								calculationEventArg.ShowForm = Option.ShowProgressForm;
								_0002(calculationEventArg);
							}
							val.Serialize(Application.StartupPath + buMWCalcs._0001(107397046));
							val3 = new CollisionsReport();
							val.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide.ToString();
							compensationType = val.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CutterRadiusCompParams.CompensationType;
							goto IL_08ff;
						}
						if (5 == 0)
						{
							goto end_IL_0251;
						}
						num5 = 0;
						if (num5 == 0)
						{
							return (byte)num5 != 0;
						}
						continue;
						IL_08ff:
						compensationType.ToString();
						val.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.Pattern.ToString();
						ToolPath val4 = val.CalcToolPath(val3);
						camResult = new MWCalculationResult();
						camResult.ToolPathCalc = new ToolPath(val4);
						camResult.Tool = new ToolBase5(Tool);
						camResult.geoLib = new GeoLib(val.Units, 0);
						camResult.geoLib.MachParam = new MachiningParams(val.MachParam);
						CopyGeoLibProperties(val, camResult.geoLib);
						camResult.buCamParamters = new camParameters5(buCamDataParameter);
						camResult.Tool.CamData.SpindleSpeed = camResult.buCamParamters.Speeds.SpindleSpeed;
						camResult.Tool.CamData.SpindleDirection = camResult.buCamParamters.Speeds.SpindleDirection;
						val.Dispose();
						return true;
						IL_03bc:
						if (num6)
						{
							val.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CutterRadiusCompParams.CompensationType = CutterRadiusCompParamsCompensationType.CtOff;
						}
						else
						{
							val.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CutterRadiusCompParams.CompensationType = CutterRadiusCompParamsCompensationType.CtInComputer;
						}
						if (val.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide == WireframeBasedTpCalcParamsCuttingSide.WfbCsRight)
						{
							val.MachParam.MachDirForOneWay = MachiningParamsDirection.DirConventional;
						}
						goto IL_05d7;
						IL_05d7:
						if (2 == 0)
						{
							goto IL_035c;
						}
						goto IL_0626;
						IL_035c:
						if (0 == 0)
						{
							if (Option.CamWireframeType != CamWireFrameType.Contour)
							{
								if (Option.CamWireframeType == CamWireFrameType.CenterPath)
								{
									val.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CutterRadiusCompParams.CompensationType = CutterRadiusCompParamsCompensationType.CtOff;
									val.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsCenter;
								}
								goto IL_0626;
							}
							if (!buCamDataParameter.Operations.isClosed)
							{
								val.MachParam.MachDirForOneWay = MachiningParamsDirection.DirClimb;
								bool flag2 = val.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide == WireframeBasedTpCalcParamsCuttingSide.WfbCsCenter;
								num6 = flag2;
								goto IL_03bc;
							}
							if (buCamDataParameter.Offsets.ClosedContour == CamClosedContourType.Center)
							{
								val.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CutterRadiusCompParams.CompensationType = CutterRadiusCompParamsCompensationType.CtOff;
								val.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsCenter;
							}
							else if (buCamDataParameter.Offsets.ClosedContour == CamClosedContourType.Inner)
							{
								val.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CutterRadiusCompParams.CompensationType = CutterRadiusCompParamsCompensationType.CtInComputer;
								if (buCamDataParameter.Operations.Direction == ClockDirectionType.CW)
								{
									val.MachParam.MachDirForOneWay = MachiningParamsDirection.DirConventional;
									val.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsRight;
								}
								else
								{
									val.MachParam.MachDirForOneWay = MachiningParamsDirection.DirClimb;
									val.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsLeft;
								}
							}
							else
							{
								num7 = ((buCamDataParameter.Offsets.ClosedContour == CamClosedContourType.Outter) ? 1 : 0);
								if (6 == 0)
								{
									goto IL_024d;
								}
								if (num7 != 0)
								{
									val.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CutterRadiusCompParams.CompensationType = CutterRadiusCompParamsCompensationType.CtInComputer;
									if (buCamDataParameter.Operations.Direction == ClockDirectionType.CW)
									{
										val.MachParam.MachDirForOneWay = MachiningParamsDirection.DirClimb;
										val.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsLeft;
									}
									else
									{
										val.MachParam.MachDirForOneWay = MachiningParamsDirection.DirConventional;
										val.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsRight;
									}
								}
							}
						}
						if (7u != 0)
						{
							goto IL_05d7;
						}
						goto IL_08ff;
					}
					if (Option.UseEachCurveStartPoint)
					{
						list.Add(new Point3d<double>(CurveEntities[num2].pntStart));
					}
					int num8 = 0;
					goto IL_0226;
					IL_024d:
					num2 = num7 + 1;
					continue;
					IL_0226:
					if (num8 <= CurveEntities[num2].CurveList.Count - 1)
					{
						if (CurveEntities[num2].CurveList[num8] != null)
						{
							Curve val5 = new Curve(CurveEntities[num2].CurveList[num8]);
							if (Option.Reverse)
							{
								val5.Reverse();
							}
							list2.Add(val5);
						}
						num3 = num8;
						num4 = 1;
						goto IL_0223;
					}
					num7 = num2;
					goto IL_024d;
					IL_0223:
					num8 = num3 + num4;
					goto IL_0226;
					continue;
					end_IL_0251:
					break;
				}
				goto IL_0a4b;
			}
			return false;
			IL_0a4b:
			updateHandler = new buMWUpdateHandler();
			updateHandler.CalculationUpdate += GetProgress;
			goto IL_006b;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			buString.MessageBoxError(ex.Message);
			return false;
		}
		bool result;
		return result;
	}

	public bool CalculateTriangleMesh(ToolBase5 Tool, List<Meshd> MeshEntities, List<buMWCurveEntities> Curve2dContainment, TriangleMeshBasedTpCalcParamsPattern CalcType, MWCalculationOptions Option, ref MWCalculationResult camResult)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected O, but got Unknown
		//IL_0662: Unknown result type (might be due to invalid IL or missing references)
		//IL_0669: Expected O, but got Unknown
		//IL_06a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06aa: Expected O, but got Unknown
		//IL_06c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cb: Expected O, but got Unknown
		//IL_06d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e3: Expected O, but got Unknown
		//IL_05d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d9: Expected O, but got Unknown
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Expected O, but got Unknown
		bool result = default(bool);
		int num5 = default(int);
		Curve val4 = default(Curve);
		do
		{
			try
			{
				if (mwCamDataParameter == null)
				{
					if (0 == 0)
					{
						result = false;
					}
					continue;
				}
				if (updateHandler != null)
				{
					goto IL_006b;
				}
				goto IL_07a1;
				IL_01bc:
				GeoLib val;
				val.MachiningSurfaces = MeshEntities;
				if (Stock != null)
				{
					goto IL_01d3;
				}
				goto IL_01e2;
				IL_07a1:
				updateHandler = new buMWUpdateHandler();
				updateHandler.CalculationUpdate += GetProgress;
				goto IL_006b;
				IL_006b:
				Tool mwTool = null;
				val = new GeoLib(Unit.Metric);
				buMWUpdateHandler.CancelOperation = false;
				int num = CreateMWTool(Tool, ref mwTool);
				List<Point3d<double>> list;
				if (num == 1)
				{
					val.ToolInfo = mwTool;
					val.MachParam = new MachiningParams(mwCamDataParameter.MachParam);
					CopyGeoLibProperties(mwCamDataParameter, val);
					val.MachParam.TpCalculationMethodsParams.Method = TpCalcMethodsParamsMethod.TcmTriangleMeshBased;
					val.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern = CalcType;
					val.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType3axis;
					if (Option.NumberofAxis == 4 && CalcType != TriangleMeshBasedTpCalcParamsPattern.TcTmbRough)
					{
						val.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType4axis;
					}
					if (Option.NumberofAxis == 5)
					{
						val.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType5axis;
					}
					list = new List<Point3d<double>>();
					if (Option.UseConstantStartPoint)
					{
						list.Add(new Point3d<double>(Option.StartPointX, Option.StartPointY, 0.0));
					}
					if (list.Count > 0)
					{
						val.StartPoints = list;
						goto IL_019b;
					}
					val.MachParam.StartPosFlag = false;
					goto IL_01bc;
				}
				result = false;
				if (false)
				{
					goto IL_019b;
				}
				goto end_IL_0001;
				IL_0769:
				int num2 = 0;
				if (num2 != 0)
				{
					goto IL_0340;
				}
				result = (byte)num2 != 0;
				goto end_IL_0001;
				IL_01e2:
				List<Curve> list2 = new List<Curve>();
				int num3 = 0;
				while (num3 <= Curve2dContainment.Count - 1)
				{
					if (3u != 0)
					{
						for (int i = 0; i <= Curve2dContainment[num3].CurveList.Count - 1; i++)
						{
							if (Curve2dContainment[num3].CurveList[i] != null)
							{
								Curve val2 = new Curve(Curve2dContainment[num3].CurveList[i]);
								if (Option.Reverse)
								{
									val2.Reverse();
								}
								list2.Add(val2);
							}
						}
						num3++;
						continue;
					}
					goto IL_0769;
				}
				val.ContainmentCurves2d = list2;
				val.UserDefinedContainment = list2;
				List<Curve> list3 = new List<Curve>();
				int num4 = 0;
				goto IL_02bf;
				IL_02bf:
				if (2u != 0)
				{
					goto IL_0393;
				}
				goto IL_0769;
				IL_0393:
				if (num4 <= Curve2dContainment.Count - 1)
				{
					if (1 == 0)
					{
						goto IL_07a1;
					}
					if (Option.UseEachCurveStartPoint)
					{
						list.Add(new Point3d<double>(Curve2dContainment[num4].pntStart));
					}
					num5 = 0;
					goto IL_0368;
				}
				val.DriveCurves = list3;
				val.SetUpdateHandler((UpdateHandler)(object)updateHandler);
				val.MachParam.LinkParams.FirstEntry.LeadController.UseDefaultLeadParams = false;
				val.MachParam.LinkParams.LastExit.LeadController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.GapsAlongCut).SmallMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.GapsAlongCut).SmallMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
				if (-1 == 0)
				{
					goto IL_02bf;
				}
				((InterlinkHandeler)val.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenSlices).SmallMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenSlices).SmallMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenSlices).LargeMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenSlices).LargeMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenPasses).SmallMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenPasses).SmallMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenPasses).LargeMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenPasses).LargeMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
				global::_0002._0001 obj = new global::_0002._0001(Unit.Metric);
				MachiningParameterDialog val3 = new MachiningParameterDialog(val, (ParamInteractor)(object)obj);
				bool flag = true;
				if (Settings.ShowMwDialogBox)
				{
					flag = val3.Show();
				}
				if (flag)
				{
					if (_0002 != null)
					{
						CalculationEventArg e = new CalculationEventArg();
						_0002(e);
					}
					goto IL_062a;
				}
				goto IL_0769;
				IL_01d3:
				val.StockDefinition = Stock;
				goto IL_01e2;
				IL_0368:
				if (num5 <= Curve2dContainment[num4].CurveList.Count - 1)
				{
					if (Curve2dContainment[num4].CurveList[num5] != null)
					{
						val4 = new Curve(Curve2dContainment[num4].CurveList[num5]);
						num2 = (Option.Reverse ? 1 : 0);
						goto IL_0340;
					}
					goto IL_0361;
				}
				num4++;
				goto IL_0393;
				IL_0361:
				num5++;
				goto IL_0368;
				IL_019b:
				val.MachParam.StartPosFlag = true;
				goto IL_01bc;
				IL_0340:
				bool flag2 = (byte)num2 != 0;
				if (0 == 0)
				{
					if (flag2)
					{
						val4.Reverse();
					}
					list3.Add(val4);
					goto IL_0361;
				}
				goto IL_062a;
				IL_062a:
				Settings.ShowProgressForm = Option.ShowProgressForm;
				if (false)
				{
					goto IL_01d3;
				}
				val.Serialize(Application.StartupPath + buMWCalcs._0001(107397046));
				CollisionsReport val5 = new CollisionsReport();
				ToolPath val6 = val.CalcToolPath(val5);
				val.Serialize(Application.StartupPath + buMWCalcs._0001(107397025));
				camResult = new MWCalculationResult();
				camResult.ToolPathCalc = new ToolPath(val6);
				camResult.Tool = new ToolBase5(Tool);
				camResult.geoLib = new GeoLib(val.Units);
				camResult.geoLib.MachParam = new MachiningParams(val.MachParam);
				CopyGeoLibProperties(val, camResult.geoLib);
				camResult.buCamParamters = new camParameters5(buCamDataParameter);
				camResult.Tool.CamData.SpindleSpeed = camResult.buCamParamters.Speeds.SpindleSpeed;
				camResult.Tool.CamData.SpindleDirection = camResult.buCamParamters.Speeds.SpindleDirection;
				val.Dispose();
				result = true;
				end_IL_0001:;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				result = false;
			}
		}
		while (7 == 0);
		return result;
	}

	public bool CalculateGeodesic(ToolBase5 Tool, List<Meshd> MeshEntities, List<buMWCurveEntities> Curve2dContainment, TriangleMeshBasedTpCalcParamsPattern CalcType, MWCalculationOptions Option, ref MWCalculationResult camResult)
	{
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_032d: Expected O, but got Unknown
		//IL_05c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c7: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_0656: Unknown result type (might be due to invalid IL or missing references)
		//IL_065d: Expected O, but got Unknown
		//IL_0674: Unknown result type (might be due to invalid IL or missing references)
		//IL_067e: Expected O, but got Unknown
		//IL_0696: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a0: Expected O, but got Unknown
		//IL_06ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b8: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		try
		{
			bool flag = mwCamDataParameter == null;
			bool num = flag;
			if (false)
			{
				goto IL_0334;
			}
			if (num)
			{
				return false;
			}
			goto IL_0756;
			IL_028b:
			int num2;
			int num3;
			if (num2 <= Curve2dContainment.Count - 1)
			{
				num3 = 0;
				goto IL_0260;
			}
			GeoLib val;
			List<Curve> list;
			val.ContainmentCurves2d = list;
			val.UserDefinedContainment = list;
			List<Curve> list2 = new List<Curve>();
			int num4 = 0;
			goto IL_02bd;
			IL_0756:
			bool flag2 = updateHandler == null;
			if (0 == 0)
			{
				if (flag2)
				{
					updateHandler = new buMWUpdateHandler();
					updateHandler.CalculationUpdate += GetProgress;
				}
				goto IL_0075;
			}
			goto IL_033a;
			IL_032d:
			num = Option.Reverse;
			goto IL_0334;
			IL_0334:
			if (num)
			{
				goto IL_033a;
			}
			goto IL_0344;
			IL_0075:
			Tool mwTool = null;
			val = new GeoLib(Unit.Metric, 1);
			buMWUpdateHandler.CancelOperation = false;
			int num5 = CreateMWTool(Tool, ref mwTool);
			if (num5 == 1)
			{
				val.ToolInfo = mwTool;
				val.MachParam = new MachiningParams(mwCamDataParameter.MachParam);
				CopyGeoLibProperties(mwCamDataParameter, val);
				val.MachParam.TpCalculationMethodsParams.Method = TpCalcMethodsParamsMethod.TcmGeodesicMachiningBased;
				goto IL_00dc;
			}
			return false;
			IL_034f:
			int num6 = num6 + 1;
			goto IL_0356;
			IL_0344:
			Curve val2 = default(Curve);
			list2.Add(val2);
			goto IL_034f;
			IL_00dc:
			val.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType3axis;
			if (Option.NumberofAxis == 4)
			{
				val.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType4axis;
			}
			if (Option.NumberofAxis == 5)
			{
				val.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType5axis;
			}
			List<Point3d<double>> list3 = new List<Point3d<double>>();
			if (Option.UseConstantStartPoint)
			{
				list3.Add(new Point3d<double>(Option.StartPointX, Option.StartPointY, 0.0));
			}
			num4 = list3.Count;
			bool num7;
			if (0 == 0)
			{
				num7 = num4 > 0;
				if (false)
				{
					goto IL_027f;
				}
				if (num7)
				{
					if (8 == 0)
					{
						goto IL_032d;
					}
					val.StartPoints = list3;
					val.MachParam.StartPosFlag = true;
				}
				else
				{
					val.MachParam.StartPosFlag = false;
				}
				val.MachiningSurfaces = MeshEntities;
				if (Stock != null)
				{
					val.StockDefinition = Stock;
				}
				list = new List<Curve>();
				num2 = 0;
				goto IL_028b;
			}
			goto IL_02bd;
			IL_02bd:
			int num8 = num4;
			goto IL_0381;
			IL_0356:
			if (num6 <= Curve2dContainment[num8].CurveList.Count - 1)
			{
				if (Curve2dContainment[num8].CurveList[num6] != null)
				{
					val2 = new Curve(Curve2dContainment[num8].CurveList[num6]);
					goto IL_032d;
				}
				goto IL_034f;
			}
			num8++;
			goto IL_0381;
			IL_0253:
			if (false)
			{
				goto IL_0075;
			}
			num3++;
			goto IL_0260;
			IL_0248:
			Curve val3;
			list.Add(val3);
			goto IL_0253;
			IL_0260:
			bool flag3 = num3 <= Curve2dContainment[num2].CurveList.Count - 1;
			num7 = flag3;
			goto IL_027f;
			IL_033a:
			val2.Reverse();
			goto IL_0344;
			IL_027f:
			if (num7)
			{
				if (Curve2dContainment[num2].CurveList[num3] != null)
				{
					val3 = new Curve(Curve2dContainment[num2].CurveList[num3]);
					if (Option.Reverse)
					{
						val3.Reverse();
					}
					goto IL_0248;
				}
				goto IL_0253;
			}
			num2++;
			goto IL_028b;
			IL_0381:
			if (num8 <= Curve2dContainment.Count - 1)
			{
				if (Option.UseEachCurveStartPoint)
				{
					list3.Add(new Point3d<double>(Curve2dContainment[num8].pntStart));
				}
				num6 = 0;
				goto IL_0356;
			}
			val.DriveCurves = list2;
			val.SetUpdateHandler((UpdateHandler)(object)updateHandler);
			val.MachParam.LinkParams.FirstEntry.LeadController.UseDefaultLeadParams = false;
			val.MachParam.LinkParams.LastExit.LeadController.UseDefaultLeadParams = false;
			if (0 == 0)
			{
				((InterlinkHandeler)val.MachParam.LinkParams.GapsAlongCut).SmallMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.GapsAlongCut).SmallMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenSlices).SmallMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenSlices).SmallMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenSlices).LargeMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenSlices).LargeMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenPasses).SmallMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenPasses).SmallMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenPasses).LargeMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenPasses).LargeMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
				global::_0002._0001 obj = new global::_0002._0001(Unit.Metric);
				MachiningParameterDialog val4 = new MachiningParameterDialog(val, (ParamInteractor)(object)obj);
				bool flag4 = true;
				if (Settings.ShowMwDialogBox)
				{
					if (false)
					{
						goto IL_0756;
					}
					flag4 = val4.Show();
				}
				if (flag4)
				{
					if (_0002 != null)
					{
						CalculationEventArg e = new CalculationEventArg();
						_0002(e);
						if (false)
						{
							goto IL_00dc;
						}
					}
					Settings.ShowProgressForm = Option.ShowProgressForm;
					val.Serialize(Application.StartupPath + buMWCalcs._0001(107397046));
					CollisionsReport val5 = new CollisionsReport();
					ToolPath val6 = val.CalcToolPath(val5);
					camResult = new MWCalculationResult();
					camResult.ToolPathCalc = new ToolPath(val6);
					camResult.Tool = new ToolBase5(Tool);
					camResult.geoLib = new GeoLib(val.Units, 0);
					camResult.geoLib.MachParam = new MachiningParams(val.MachParam);
					CopyGeoLibProperties(val, camResult.geoLib);
					camResult.buCamParamters = new camParameters5(buCamDataParameter);
					camResult.Tool.CamData.SpindleSpeed = camResult.buCamParamters.Speeds.SpindleSpeed;
					camResult.Tool.CamData.SpindleDirection = camResult.buCamParamters.Speeds.SpindleDirection;
					val.Dispose();
					return true;
				}
				return false;
			}
			goto IL_0248;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
			return false;
		}
	}

	public bool CalculateDrill(ToolBase5 Tool, List<Pnt3D> Points, DrillingBasedTpCalcParamsPattern CalcType, MWCalculationOptions Option, ref MWCalculationResult camResult)
	{
		//IL_0453: Unknown result type (might be due to invalid IL or missing references)
		//IL_045e: Expected O, but got Unknown
		//IL_0360: Unknown result type (might be due to invalid IL or missing references)
		//IL_036a: Expected O, but got Unknown
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Expected O, but got Unknown
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a4: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected O, but got Unknown
		//IL_0342: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Expected O, but got Unknown
		if (mwCamDataParameter == null)
		{
			return false;
		}
		Tool mwTool = null;
		bool flag = false;
		GeoLib val = new GeoLib(Unit.Metric, 1);
		buMWUpdateHandler.CancelOperation = false;
		int num = CreateMWTool(Tool, ref mwTool);
		bool num2;
		if (0 == 0)
		{
			bool flag2 = num == 1;
			num2 = flag2;
			goto IL_0060;
		}
		goto IL_02da;
		IL_0353:
		camResult = new MWCalculationResult();
		ToolPath val2;
		camResult.ToolPathCalc = new ToolPath(val2);
		camResult.Tool = new ToolBase5(Tool);
		camResult.geoLib = new GeoLib(val.Units, 0);
		camResult.geoLib.MachParam = new MachiningParams(val.MachParam);
		CopyGeoLibProperties(val, camResult.geoLib);
		camResult.buCamParamters = new camParameters5(buCamDataParameter);
		camResult.Tool.CamData.SpindleSpeed = camResult.buCamParamters.Speeds.SpindleSpeed;
		camResult.Tool.CamData.SpindleDirection = camResult.buCamParamters.Speeds.SpindleDirection;
		val.Dispose();
		return true;
		IL_02f5:
		bool flag3 = _0002 != null;
		if (false)
		{
			goto IL_0097;
		}
		if (flag3)
		{
			CalculationEventArg e = new CalculationEventArg();
			_0002(e);
		}
		val.Serialize(Application.StartupPath + buMWCalcs._0001(107397046));
		goto IL_0342;
		IL_0060:
		if (num2)
		{
			if (0 == 0)
			{
				val.ToolInfo = mwTool;
				val.MachParam = new MachiningParams(mwCamDataParameter.MachParam);
				CopyGeoLibProperties(mwCamDataParameter, val);
				goto IL_0097;
			}
			goto IL_0353;
		}
		return false;
		IL_02da:
		MachiningParameterDialog val3;
		num2 = val3.Show();
		if (false)
		{
			goto IL_0060;
		}
		bool flag4 = num2;
		goto IL_02ea;
		IL_0342:
		CollisionsReport val4 = new CollisionsReport();
		val2 = val.CalcToolPath(val4);
		goto IL_0353;
		IL_02ea:
		if (!flag4)
		{
			return false;
		}
		goto IL_02f5;
		IL_0097:
		val.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType3axis;
		val.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.StartFromPosition = WireframeBasedTpCalcParamsStartFromPosition.SfpUserDefinedStartPoint;
		if (0 == 0)
		{
			val.MachParam.TpCalculationMethodsParams.Method = TpCalcMethodsParamsMethod.TcmDrillingBased;
		}
		val.MachParam.TpCalculationMethodsParams.DrillingBasedTpCalcParams.Pattern = DrillingBasedTpCalcParamsPattern.TcDbPoints;
		List<Point3d<double>> list = new List<Point3d<double>>();
		list.Add(new Point3d<double>(100.0, 120.0, 0.0));
		val.DrillPoints = list;
		F_DrillLine f_DrillLine = new F_DrillLine();
		f_DrillLine.mwCamParameter = new GeoLib(val.Units, 0);
		f_DrillLine.mwCamParameter.MachParam = new MachiningParams(val.MachParam);
		CopyGeoLibProperties(val, f_DrillLine.mwCamParameter);
		bool showMwDialogBox;
		if (0 == 0)
		{
			f_DrillLine.mwCamParameter.TabsPoints = val.TabsPoints;
			f_DrillLine.buCamParameter = new camParameters5(buCamDataParameter);
			f_DrillLine.Init();
			f_DrillLine.ShowDialog();
			if (f_DrillLine.PropertiesForm.Result != DialogResult.OK)
			{
				if (0 == 0)
				{
					return false;
				}
				goto IL_0342;
			}
			val.MachParam = new MachiningParams(f_DrillLine.mwCamParameter.MachParam);
			if (4 == 0)
			{
				goto IL_02f5;
			}
			CopyGeoLibProperties(f_DrillLine.mwCamParameter, val);
			buCamDataParameter = new camParameters5(f_DrillLine.buCamParameter);
			List<Curve> list2 = new List<Curve>();
			for (int i = 0; i <= Points.Count - 1; i++)
			{
				list2.Add(Curve.FromLine(new Point3d<double>(Points[i].X, Points[i].Y, buCamDataParameter.Steps.StartValue), new Point3d<double>(Points[i].X, Points[i].Y, buCamDataParameter.Steps.EndValue)));
			}
			val.DrillHoleLines = list2;
			val.SetUpdateHandler((UpdateHandler)(object)updateHandler);
			global::_0002._0001 obj = new global::_0002._0001(Unit.Metric);
			val3 = new MachiningParameterDialog(val, (ParamInteractor)(object)obj);
			flag4 = true;
			showMwDialogBox = Settings.ShowMwDialogBox;
		}
		if (showMwDialogBox)
		{
			goto IL_02da;
		}
		goto IL_02ea;
	}

	public bool CalculateContouring(ToolBase5 Tool, List<Meshd> SurfaceEntities, List<buMWCurveEntities> EdgeCurves, TriangleMeshBasedTpCalcParamsPattern CalcType, MWCalculationOptions Option, ref MWCalculationResult camResult)
	{
		//IL_04bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c9: Expected O, but got Unknown
		//IL_04e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04eb: Expected O, but got Unknown
		//IL_04f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0503: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_04a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a8: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_0423: Unknown result type (might be due to invalid IL or missing references)
		//IL_042a: Expected O, but got Unknown
		try
		{
			int num = ((mwCamDataParameter == null) ? 1 : 0);
			GeoLib val;
			List<Curve> list;
			int num3;
			if (2u != 0)
			{
				if (num != 0)
				{
					return false;
				}
				if (updateHandler == null)
				{
					updateHandler = new buMWUpdateHandler();
					updateHandler.CalculationUpdate += GetProgress;
				}
				if (4u != 0)
				{
					Tool mwTool = null;
					val = new GeoLib(Unit.Metric, 1);
					buMWUpdateHandler.CancelOperation = false;
					int num2 = CreateMWTool(Tool, ref mwTool);
					if (num2 == 1)
					{
						val.ToolInfo = mwTool;
						val.MachParam = new MachiningParams(mwCamDataParameter.MachParam);
						CopyGeoLibProperties(mwCamDataParameter, val);
						val.MachParam.TpCalculationMethodsParams.Method = TpCalcMethodsParamsMethod.TcmContouringBased;
						if (0 == 0)
						{
							val.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern = CalcType;
							val.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType3axis;
							if (0 == 0)
							{
								val.MachiningSurfaces = SurfaceEntities;
								if (Stock != null)
								{
									val.StockDefinition = Stock;
									if (6 == 0)
									{
										goto IL_042a;
									}
								}
								list = new List<Curve>();
								num3 = 0;
								goto IL_01e1;
							}
							goto IL_043a;
						}
						goto IL_043e;
					}
					return false;
				}
				goto IL_04b2;
			}
			goto IL_05ab;
			IL_01e1:
			int num4 = num3;
			int count = EdgeCurves.Count;
			int num5 = 1;
			if (num5 == 0)
			{
				goto IL_01cb;
			}
			int num6 = default(int);
			if (num4 <= count - num5)
			{
				num6 = 0;
				goto IL_01b6;
			}
			val.EdgeCurves = list;
			val.SetUpdateHandler((UpdateHandler)(object)updateHandler);
			val.MachParam.LinkParams.FirstEntry.LeadController.UseDefaultLeadParams = false;
			MachiningParameterDialog val2 = default(MachiningParameterDialog);
			if (0 == 0)
			{
				val.MachParam.LinkParams.LastExit.LeadController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.GapsAlongCut).SmallMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.GapsAlongCut).SmallMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenSlices).SmallMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenSlices).SmallMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenSlices).LargeMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenSlices).LargeMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenPasses).SmallMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenPasses).SmallMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenPasses).LargeMoveHandling.MoveLeadController.LeadInController.UseDefaultLeadParams = false;
				((InterlinkHandeler)val.MachParam.LinkParams.LinkBetweenPasses).LargeMoveHandling.MoveLeadController.LeadOutController.UseDefaultLeadParams = false;
				global::_0002._0001 obj = new global::_0002._0001(Unit.Metric);
				val2 = new MachiningParameterDialog(val, (ParamInteractor)(object)obj);
				goto IL_042a;
			}
			goto IL_045a;
			IL_04b2:
			camResult = new MWCalculationResult();
			ToolPath val3;
			camResult.ToolPathCalc = new ToolPath(val3);
			camResult.Tool = new ToolBase5(Tool);
			camResult.geoLib = new GeoLib(val.Units, 0);
			camResult.geoLib.MachParam = new MachiningParams(val.MachParam);
			CopyGeoLibProperties(val, camResult.geoLib);
			double axialShift = camResult.geoLib.MachParam.TpCalculationMethodsParams.ContouringBasedTpCalcParams.AxialShift;
			double axialShift2 = val.MachParam.TpCalculationMethodsParams.ContouringBasedTpCalcParams.AxialShift;
			camResult.buCamParamters = new camParameters5(buCamDataParameter);
			camResult.Tool.CamData.SpindleSpeed = camResult.buCamParamters.Speeds.SpindleSpeed;
			camResult.Tool.CamData.SpindleDirection = camResult.buCamParamters.Speeds.SpindleDirection;
			val.Dispose();
			num = 1;
			goto IL_05ab;
			IL_05ab:
			return (byte)num != 0;
			IL_045a:
			if (_0002 != null)
			{
				CalculationEventArg e = new CalculationEventArg();
				_0002(e);
			}
			val.Serialize(Application.StartupPath + buMWCalcs._0001(107397046));
			CollisionsReport val4 = new CollisionsReport();
			val3 = val.CalcToolPath(val4);
			goto IL_04b2;
			IL_042a:
			bool flag = true;
			bool showMwDialogBox = Settings.ShowMwDialogBox;
			goto IL_043a;
			IL_043e:
			if (false)
			{
				goto IL_01af;
			}
			flag = val2.Show();
			goto IL_044f;
			IL_043a:
			if (showMwDialogBox)
			{
				goto IL_043e;
			}
			goto IL_044f;
			IL_01af:
			num6++;
			goto IL_01b6;
			IL_01b6:
			num4 = num6;
			count = EdgeCurves[num3].CurveList.Count;
			num5 = 1;
			goto IL_01cb;
			IL_044f:
			if (!flag)
			{
				return false;
			}
			goto IL_045a;
			IL_01cb:
			if (num4 <= count - num5)
			{
				if (EdgeCurves[num3].CurveList[num6] != null)
				{
					Curve val5 = new Curve(EdgeCurves[num3].CurveList[num6]);
					if (Option.Reverse)
					{
						val5.Reverse();
					}
					list.Add(val5);
				}
				goto IL_01af;
			}
			num3++;
			goto IL_01e1;
		}
		catch (Exception)
		{
			while (6 == 0)
			{
			}
			return false;
		}
	}

	public bool CalculateSurface(ToolBase5 Tool, List<Surface> SurfaceEntities, List<Meshd> Meshes, TriangleMeshBasedTpCalcParamsPattern CalcType, MWCalculationOptions Option, ref MWCalculationResult camResult)
	{
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Expected O, but got Unknown
		//IL_0348: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Expected O, but got Unknown
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Expected O, but got Unknown
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Expected O, but got Unknown
		//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		try
		{
			bool flag = mwCamDataParameter == null;
			GeoLib val = default(GeoLib);
			List<Curve> list = default(List<Curve>);
			int num4 = default(int);
			if (0 == 0)
			{
				if (flag)
				{
					return false;
				}
				if (1 == 0)
				{
					goto IL_0245;
				}
				if (updateHandler == null)
				{
					updateHandler = new buMWUpdateHandler();
					updateHandler.CalculationUpdate += GetProgress;
				}
				Tool mwTool = null;
				val = new GeoLib(Unit.Metric, 1);
				buMWUpdateHandler.CancelOperation = false;
				int num = CreateMWTool(Tool, ref mwTool);
				if (num != 1)
				{
					return false;
				}
				val.ToolInfo = mwTool;
				val.MachParam = new MachiningParams(mwCamDataParameter.MachParam);
				CopyGeoLibProperties(mwCamDataParameter, val);
				val.MachParam.TpCalculationMethodsParams.Method = TpCalcMethodsParamsMethod.TcmSurfaceBased;
				val.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern = TriangleMeshBasedTpCalcParamsPattern.TcTmbParallelCuts;
				val.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType5axis;
				int num2 = 0;
				int num3;
				while (true)
				{
					if (num2 <= SurfaceEntities.Count - 1)
					{
						num3 = num2;
						if (false)
						{
							break;
						}
						if (num3 <= Meshes.Count - 1)
						{
							SurfaceEntities[num2].SetMesh(Meshes[num2]);
						}
						else
						{
							Tesselator val2 = new Tesselator();
							Meshd tessellationFromSurface = val2.GetTessellationFromSurface(SurfaceEntities[num2], 0.01, Unit.Metric);
							SurfaceEntities[num2].SetMesh(tessellationFromSurface);
						}
						num2++;
						continue;
					}
					val.DriveSurfArray = SurfaceEntities;
					num3 = ((Stock != null) ? 1 : 0);
					break;
				}
				if (num3 != 0)
				{
					val.StockDefinition = Stock;
				}
				list = null;
				if (entityProjection != null && entityProjection.Count > 0)
				{
					list = new List<Curve>();
					num4 = 0;
					goto IL_0276;
				}
			}
			goto IL_02b8;
			IL_0245:
			int num5 = num5 + 1;
			goto IL_024c;
			IL_02b8:
			val.SetUpdateHandler((UpdateHandler)(object)updateHandler);
			global::_0002._0001 obj = new global::_0002._0001(Unit.Metric);
			MachiningParameterDialog val3 = new MachiningParameterDialog(val, (ParamInteractor)(object)obj);
			bool flag2 = true;
			if (Settings.ShowMwDialogBox)
			{
				flag2 = val3.Show();
			}
			if (flag2)
			{
				if (_0002 != null)
				{
					CalculationEventArg e = new CalculationEventArg();
					_0002(e);
				}
				val.Serialize(Application.StartupPath + buMWCalcs._0001(107397046));
				CollisionsReport val4 = new CollisionsReport();
				ToolPath val5 = val.CalcToolPath(val4);
				camResult = new MWCalculationResult();
				camResult.ToolPathCalc = new ToolPath(val5);
				camResult.Tool = new ToolBase5(Tool);
				camResult.geoLib = new GeoLib(val.Units, 0);
				camResult.geoLib.MachParam = new MachiningParams(val.MachParam);
				CopyGeoLibProperties(val, camResult.geoLib);
				double axialShift = camResult.geoLib.MachParam.TpCalculationMethodsParams.ContouringBasedTpCalcParams.AxialShift;
				double axialShift2 = val.MachParam.TpCalculationMethodsParams.ContouringBasedTpCalcParams.AxialShift;
				camResult.buCamParamters = new camParameters5(buCamDataParameter);
				do
				{
					camResult.Tool.CamData.SpindleSpeed = camResult.buCamParamters.Speeds.SpindleSpeed;
					camResult.Tool.CamData.SpindleDirection = camResult.buCamParamters.Speeds.SpindleDirection;
					val.Dispose();
				}
				while (6 == 0);
				return true;
			}
			return false;
			IL_0276:
			int num6 = ((num4 > entityProjection.Count - 1) ? 1 : 0);
			int num7 = 0;
			if (num7 != 0)
			{
				goto IL_0273;
			}
			if (num6 == num7)
			{
				num5 = 0;
				goto IL_024c;
			}
			if (list != null && list.Count > 0)
			{
				val.ProjectionCurves = list;
			}
			goto IL_02b8;
			IL_024c:
			if (num5 <= entityProjection[num4].Count - 1)
			{
				if (entityProjection[num4][num5] != null)
				{
					Curve mwEntity = null;
					ConvertWireEntity(entityProjection[num4][num5], ref mwEntity);
					if (mwEntity != null)
					{
						list.Add(mwEntity);
					}
				}
				goto IL_0245;
			}
			num6 = num4;
			num7 = 1;
			goto IL_0273;
			IL_0273:
			num4 = num6 + num7;
			goto IL_0276;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public bool CalculateExistingToolPath3To5Axis(ToolBase5 Tool, ToolPath OriginalToolPath, List<Meshd> CheckSurface, TriangleMeshBasedTpCalcParamsPattern CalcType, MWCalculationOptions Option, ref MWCalculationResult camResult)
	{
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Expected O, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		if (5 == 0)
		{
			goto IL_00f8;
		}
		if (mwCamDataParameter == null)
		{
			return false;
		}
		if (updateHandler == null)
		{
			updateHandler = new buMWUpdateHandler();
			updateHandler.CalculationUpdate += GetProgress;
		}
		Tool mwTool = null;
		if (5 == 0)
		{
			goto IL_00ed;
		}
		GeoLib val = new GeoLib(Unit.Metric, 1);
		buMWUpdateHandler.CancelOperation = false;
		int num = CreateMWTool(Tool, ref mwTool);
		if (num == 1)
		{
			val.ToolInfo = mwTool;
			goto IL_00a1;
		}
		int num2 = 0;
		if (num2 == 0)
		{
			return (byte)num2 != 0;
		}
		goto IL_0171;
		IL_01d2:
		camResult.Tool = new ToolBase5(Tool);
		camResult.geoLib = new GeoLib(val.Units, 0);
		camResult.geoLib.MachParam = new MachiningParams(val.MachParam);
		CopyGeoLibProperties(val, camResult.geoLib);
		if (0 == 0)
		{
			double axialShift = camResult.geoLib.MachParam.TpCalculationMethodsParams.ContouringBasedTpCalcParams.AxialShift;
			double axialShift2 = val.MachParam.TpCalculationMethodsParams.ContouringBasedTpCalcParams.AxialShift;
			camResult.buCamParamters = new camParameters5(buCamDataParameter);
			camResult.Tool.CamData.SpindleSpeed = camResult.buCamParamters.Speeds.SpindleSpeed;
			camResult.Tool.CamData.SpindleDirection = camResult.buCamParamters.Speeds.SpindleDirection;
			val.Dispose();
			return true;
		}
		goto IL_00c4;
		IL_00a1:
		val.MachParam = new MachiningParams(mwCamDataParameter.MachParam);
		CopyGeoLibProperties(mwCamDataParameter, val);
		goto IL_00c4;
		IL_00ed:
		bool flag = Stock != null;
		goto IL_00f8;
		IL_00c4:
		val.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern = CalcType;
		val.CheckSurfArray1 = CheckSurface;
		val.OriginalToolPath = OriginalToolPath;
		goto IL_00ed;
		IL_00f8:
		if (false)
		{
			goto IL_00a1;
		}
		if (flag)
		{
			val.StockDefinition = Stock;
		}
		if (6 == 0)
		{
			goto IL_00c4;
		}
		val.SetUpdateHandler((UpdateHandler)(object)updateHandler);
		if (0 == 0)
		{
			global::_0002._0001 obj = new global::_0002._0001(Unit.Metric);
			MachiningParameterDialog val2 = new MachiningParameterDialog(val, (ParamInteractor)(object)obj);
			bool flag2 = true;
			if (false)
			{
				goto IL_01d2;
			}
			if (Settings.ShowMwDialogBox)
			{
				flag2 = val2.Show();
			}
			if (!flag2)
			{
				return false;
			}
		}
		bool flag3 = _0002 != null;
		num2 = (flag3 ? 1 : 0);
		goto IL_0171;
		IL_0171:
		if (num2 != 0)
		{
			CalculationEventArg e = new CalculationEventArg();
			_0002(e);
		}
		val.Serialize(Application.StartupPath + buMWCalcs._0001(107397046));
		CollisionsReport val3 = new CollisionsReport();
		ToolPath val4 = val.CalcToolPath(val3);
		camResult = new MWCalculationResult();
		camResult.ToolPathCalc = new ToolPath(val4);
		goto IL_01d2;
	}

	public int CreateMWTool(ToolBase5 buTool, ref Tool mwTool)
	{
		if (6 == 0)
		{
			goto IL_00f3;
		}
		int num;
		if (buTool == null)
		{
			num = -1;
			goto IL_0216;
		}
		int num2 = ((buTool.Geometry.GeometryType == buClass.ToolType.Flat) ? 1 : 0);
		bool num3;
		if (8u != 0)
		{
			if (num2 != 0)
			{
				mwTool = CreateEndFlatMill(buTool);
			}
			else
			{
				if (buTool.Geometry.GeometryType == buClass.ToolType.Sphere)
				{
					goto IL_0075;
				}
				if (buTool.Geometry.GeometryType == buClass.ToolType.Bullnose)
				{
					mwTool = CreateBullMill(buTool);
				}
				else
				{
					if (buTool.Geometry.GeometryType != buClass.ToolType.Barrel)
					{
						num3 = buTool.Geometry.GeometryType == buClass.ToolType.Taper;
						if (3u != 0)
						{
							if (num3)
							{
								goto IL_00e5;
							}
							goto IL_00f3;
						}
						goto IL_0176;
					}
					mwTool = CreateBarrelMill(buTool);
				}
			}
			goto IL_020c;
		}
		goto IL_0217;
		IL_00f3:
		bool num4 = buTool.Geometry.GeometryType == buClass.ToolType.Dove;
		if (3u != 0)
		{
			bool flag = num4;
			num4 = flag;
		}
		if (num4)
		{
			mwTool = CreateDoveMill(buTool);
		}
		else
		{
			if (false)
			{
				goto IL_00e5;
			}
			if (1 == 0)
			{
				goto IL_01c1;
			}
			if (buTool.Geometry.GeometryType == buClass.ToolType.Chamfer)
			{
				mwTool = CreateChamferMill(buTool);
			}
			else
			{
				if (buTool.Geometry.GeometryType != buClass.ToolType.Lollipop)
				{
					num3 = buTool.Geometry.GeometryType == buClass.ToolType.Slot;
					goto IL_0176;
				}
				mwTool = CreateLollipop(buTool);
			}
		}
		goto IL_020c;
		IL_0216:
		num2 = num;
		goto IL_0217;
		IL_01c1:
		mwTool = CreateSaw(buTool);
		goto IL_020c;
		IL_00e5:
		mwTool = CreateTaperMill(buTool);
		goto IL_020c;
		IL_0217:
		return num2;
		IL_0176:
		if (num3)
		{
			mwTool = CreateSlotMill(buTool);
		}
		else if (buTool.Geometry.GeometryType == buClass.ToolType.ConvexTip)
		{
			mwTool = CreateConvexTipMill(buTool);
		}
		else
		{
			if (buTool.Geometry.GeometryType == buClass.ToolType.Saw)
			{
				goto IL_01c1;
			}
			if (buTool.Geometry.GeometryType == buClass.ToolType.WateJet)
			{
				mwTool = CreateEndFlatMill(buTool);
			}
			else if (buTool.Geometry.GeometryType == buClass.ToolType.Laser)
			{
				mwTool = CreateEndFlatMill(buTool);
			}
		}
		goto IL_020c;
		IL_020c:
		if (false)
		{
			goto IL_0075;
		}
		num = 1;
		goto IL_0216;
		IL_0075:
		mwTool = CreateSphereMill(buTool);
		goto IL_020c;
	}

	public static Tool CreateEndFlatMill(ToolBase5 Tool)
	{
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Expected O, but got Unknown
		try
		{
			List<Point2d<double>> list = default(List<Point2d<double>>);
			int num = default(int);
			if (Tool.Geometry.HolderPoints.Count != 0)
			{
				if (4 == 0)
				{
					goto IL_00ab;
				}
				list = new List<Point2d<double>>();
				num = 0;
				goto IL_00b7;
			}
			ToolHolder val = _0017._008F_0006(Tool.Geometry.HolderDiameter, Tool.Geometry.HolderLength, Unit.Metric);
			goto IL_00eb;
			IL_019b:
			int num3;
			int num4;
			int num2 = ((num3 > num4) ? 1 : 0);
			goto IL_019d;
			IL_019d:
			int num5 = default(int);
			List<Point2d<double>> list2 = default(List<Point2d<double>>);
			if (num2 == 0)
			{
				Point2d<double> item = new Point2d<double>(Tool.Geometry.ArborPoints[num5].X, Tool.Geometry.ArborPoints[num5].Y);
				list2.Add(item);
				num5++;
				goto IL_0187;
			}
			ToolArbor val2 = _001A._0092_0006(list2, Unit.Metric);
			if (7 == 0)
			{
				goto IL_00b7;
			}
			goto IL_01bb;
			IL_0189:
			num4 = Tool.Geometry.ArborPoints.Count - 1;
			goto IL_019b;
			IL_00eb:
			num2 = Tool.Geometry.ArborPoints.Count;
			if (false)
			{
				goto IL_019d;
			}
			if (num2 == 0)
			{
				val2 = _0019._0091_0006(Tool.Geometry.ArborTopDiameter, Tool.Geometry.ArborLength, Unit.Metric);
				goto IL_01bb;
			}
			list2 = new List<Point2d<double>>();
			num5 = 0;
			goto IL_0187;
			IL_0187:
			num3 = num5;
			goto IL_0189;
			IL_00ab:
			num3 = num + 1;
			if (0 == 0)
			{
				num = num3;
				goto IL_00b7;
			}
			goto IL_01d3;
			IL_00b7:
			num3 = num;
			num4 = Tool.Geometry.HolderPoints.Count;
			if (0 == 0)
			{
				if (num3 <= num4 - 1)
				{
					Point2d<double> item2 = new Point2d<double>(Tool.Geometry.HolderPoints[num].X, Tool.Geometry.HolderPoints[num].Y);
					list.Add(item2);
					goto IL_00ab;
				}
				val = _0018._0090_0006(list, Unit.Metric);
				goto IL_00eb;
			}
			goto IL_019b;
			IL_01bb:
			num3 = ((Tool.Geometry.CutLength > Tool.Geometry.Length) ? 1 : 0);
			goto IL_01d3;
			IL_01d3:
			if (2u != 0)
			{
				if (num3 != 0)
				{
					Tool.Geometry.CutLength = Tool.Geometry.Length - 0.2;
				}
				return (Tool)new EndMill(Tool.Geometry.Diameter, val, Tool.Geometry.Length, Tool.Geometry.CutLength, val2, Unit.Metric);
			}
			goto IL_0189;
		}
		catch (Exception ex)
		{
			_001B._0093_0006(global::_0005._007E_0012_0003(ex));
			if (0 == 0)
			{
				return null;
			}
		}
		Tool result;
		return result;
	}

	public static Tool CreateSphereMill(ToolBase5 Tool)
	{
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		try
		{
			ToolHolder val;
			if (Tool.Geometry.HolderPoints.Count == 0)
			{
				val = _0017._008F_0006(Tool.Geometry.HolderDiameter, Tool.Geometry.HolderLength, Unit.Metric);
			}
			else
			{
				List<Point2d<double>> list = new List<Point2d<double>>();
				for (int i = 0; i <= Tool.Geometry.HolderPoints.Count - 1; i++)
				{
					Point2d<double> item = new Point2d<double>(Tool.Geometry.HolderPoints[i].X, Tool.Geometry.HolderPoints[i].Y);
					list.Add(item);
				}
				val = _0018._0090_0006(list, Unit.Metric);
			}
			ToolArbor val2;
			if (Tool.Geometry.ArborPoints.Count == 0)
			{
				val2 = _0019._0091_0006(Tool.Geometry.ArborTopDiameter, Tool.Geometry.ArborLength, Unit.Metric);
			}
			else
			{
				List<Point2d<double>> list2 = new List<Point2d<double>>();
				for (int j = 0; j <= Tool.Geometry.ArborPoints.Count - 1; j++)
				{
					do
					{
						Point2d<double> item2 = new Point2d<double>(Tool.Geometry.ArborPoints[j].X, Tool.Geometry.ArborPoints[j].Y);
						list2.Add(item2);
					}
					while (7 == 0);
				}
				val2 = _001A._0092_0006(list2, Unit.Metric);
			}
			return (Tool)new SphereMill(Tool.Geometry.Diameter, val, Tool.Geometry.Length, Tool.Geometry.CutLength, val2, Unit.Metric);
		}
		catch (Exception ex)
		{
			_001B._0093_0006(global::_0005._007E_0012_0003(ex));
			return null;
		}
	}

	public static Tool CreateBullMill(ToolBase5 Tool)
	{
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		try
		{
			bool num = Tool.Geometry.HolderPoints.Count == 0;
			if (false)
			{
				goto IL_00d6;
			}
			List<Point2d<double>> list = default(List<Point2d<double>>);
			int num2 = default(int);
			if (!num)
			{
				list = new List<Point2d<double>>();
				num2 = 0;
				goto IL_00ba;
			}
			ToolHolder val = _0017._008F_0006(Tool.Geometry.HolderDiameter, Tool.Geometry.HolderLength, Unit.Metric);
			goto IL_00eb;
			IL_006d:
			double x = Tool.Geometry.HolderPoints[num2].X;
			if (4u != 0)
			{
				Point2d<double> item = new Point2d<double>(x, Tool.Geometry.HolderPoints[num2].Y);
				list.Add(item);
				num2++;
				goto IL_00ba;
			}
			goto IL_015b;
			IL_00ba:
			int num3 = num2;
			int num4 = Tool.Geometry.HolderPoints.Count;
			if (7u != 0)
			{
				num4--;
			}
			num = num3 <= num4;
			goto IL_00d6;
			IL_00d6:
			bool flag = num;
			bool num5 = flag;
			goto IL_00da;
			IL_00eb:
			int num6 = Tool.Geometry.ArborPoints.Count;
			if (uint.MaxValue != 0)
			{
				bool flag2 = num6 == 0;
				num6 = (flag2 ? 1 : 0);
			}
			goto IL_0105;
			IL_015b:
			int num7;
			Point2d<double> item2 = new Point2d<double>(x, Tool.Geometry.ArborPoints[num7].Y);
			List<Point2d<double>> list2;
			list2.Add(item2);
			num6 = num7;
			if (false)
			{
				goto IL_0105;
			}
			num7 = num6 + 1;
			goto IL_0190;
			IL_0105:
			ToolArbor val2;
			if (num6 != 0)
			{
				val2 = _0019._0091_0006(Tool.Geometry.ArborTopDiameter, Tool.Geometry.ArborLength, Unit.Metric);
				goto IL_01c4;
			}
			list2 = new List<Point2d<double>>();
			num7 = 0;
			if (4 == 0)
			{
				goto IL_006d;
			}
			goto IL_0190;
			IL_01c4:
			return (Tool)new BullMill(Tool.Geometry.Diameter, val, Tool.Geometry.Length, Tool.Geometry.CutLength, val2, Tool.Geometry.RoundRadius, Unit.Metric);
			IL_0190:
			num5 = num7 > Tool.Geometry.ArborPoints.Count - 1;
			if (false)
			{
				goto IL_00da;
			}
			if (!num5)
			{
				x = Tool.Geometry.ArborPoints[num7].X;
				goto IL_015b;
			}
			val2 = _001A._0092_0006(list2, Unit.Metric);
			goto IL_01c4;
			IL_00da:
			if (num5)
			{
				goto IL_006d;
			}
			val = _0018._0090_0006(list, Unit.Metric);
			goto IL_00eb;
		}
		catch (Exception ex)
		{
			_001B._0093_0006(global::_0005._007E_0012_0003(ex));
			return null;
		}
	}

	public static Tool CreateTaperMill(ToolBase5 Tool)
	{
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Expected O, but got Unknown
		try
		{
			List<Point2d<double>> list = default(List<Point2d<double>>);
			int num = default(int);
			if (Tool.Geometry.HolderPoints.Count != 0)
			{
				if (4 == 0)
				{
					goto IL_00ab;
				}
				list = new List<Point2d<double>>();
				num = 0;
				goto IL_00b7;
			}
			ToolHolder val = _0017._008F_0006(Tool.Geometry.HolderDiameter, Tool.Geometry.HolderLength, Unit.Metric);
			goto IL_00eb;
			IL_019b:
			int num3;
			int num4;
			int num2 = ((num3 <= num4) ? 1 : 0);
			goto IL_01a0;
			IL_01a0:
			double num5;
			int num6 = default(int);
			if (num2 != 0)
			{
				num5 = Tool.Geometry.ArborPoints[num6].X;
				goto IL_0158;
			}
			if (8 == 0)
			{
				goto IL_00a0;
			}
			List<Point2d<double>> list2 = default(List<Point2d<double>>);
			ToolArbor val2 = _001A._0092_0006(list2, Unit.Metric);
			if (7 == 0)
			{
				goto IL_00ab;
			}
			goto IL_01c1;
			IL_0187:
			num3 = num6;
			num4 = Tool.Geometry.ArborPoints.Count - 1;
			goto IL_019b;
			IL_00eb:
			int num7 = Tool.Geometry.ArborPoints.Count;
			if (false)
			{
				goto IL_0185;
			}
			if (num7 == 0)
			{
				val2 = _0019._0091_0006(Tool.Geometry.ArborTopDiameter, Tool.Geometry.ArborLength, Unit.Metric);
				goto IL_01c1;
			}
			list2 = new List<Point2d<double>>();
			num6 = 0;
			goto IL_0187;
			IL_00a0:
			Point2d<double> item = default(Point2d<double>);
			list.Add(item);
			goto IL_00ab;
			IL_00ab:
			num2 = num + 1;
			if (0 == 0)
			{
				num = num2;
				goto IL_00b7;
			}
			goto IL_01a0;
			IL_00b7:
			num3 = num;
			num4 = Tool.Geometry.HolderPoints.Count;
			if (0 == 0)
			{
				if (num3 <= num4 - 1)
				{
					item = new Point2d<double>(Tool.Geometry.HolderPoints[num].X, Tool.Geometry.HolderPoints[num].Y);
					goto IL_00a0;
				}
				val = _0018._0090_0006(list, Unit.Metric);
				goto IL_00eb;
			}
			goto IL_019b;
			IL_01c1:
			CornerRadiusType cornerRadiusType = (CornerRadiusType)_001E._0096_0006(_001C._0094_0006(typeof(CornerRadiusType).TypeHandle), _001D._0095_0006(Tool.Geometry.CornerRadiusType));
			num5 = Tool.Geometry.Diameter;
			if (7u != 0)
			{
				return (Tool)new TaperMill(num5, val, Tool.Geometry.Length, Tool.Geometry.CutLength, val2, Tool.Geometry.LowerRadius, cornerRadiusType, Tool.Geometry.TaperAngle, Unit.Metric);
			}
			goto IL_0158;
			IL_0158:
			Point2d<double> item2 = new Point2d<double>(num5, Tool.Geometry.ArborPoints[num6].Y);
			list2.Add(item2);
			num7 = num6 + 1;
			goto IL_0185;
			IL_0185:
			num6 = num7;
			goto IL_0187;
		}
		catch (Exception ex)
		{
			_001B._0093_0006(global::_0005._007E_0012_0003(ex));
			return null;
		}
	}

	public static Tool CreateLollipop(ToolBase5 Tool)
	{
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		try
		{
			bool num = Tool.Geometry.HolderPoints.Count == 0;
			if (false)
			{
				goto IL_00d6;
			}
			List<Point2d<double>> list = default(List<Point2d<double>>);
			int num2 = default(int);
			if (!num)
			{
				list = new List<Point2d<double>>();
				num2 = 0;
				goto IL_00ba;
			}
			ToolHolder val = _0017._008F_0006(Tool.Geometry.HolderDiameter, Tool.Geometry.HolderLength, Unit.Metric);
			goto IL_00eb;
			IL_006d:
			double x = Tool.Geometry.HolderPoints[num2].X;
			if (4u != 0)
			{
				Point2d<double> item = new Point2d<double>(x, Tool.Geometry.HolderPoints[num2].Y);
				list.Add(item);
				num2++;
				goto IL_00ba;
			}
			goto IL_015b;
			IL_00ba:
			int num3 = num2;
			int num4 = Tool.Geometry.HolderPoints.Count;
			if (7u != 0)
			{
				num4--;
			}
			num = num3 <= num4;
			goto IL_00d6;
			IL_00d6:
			bool flag = num;
			bool num5 = flag;
			goto IL_00da;
			IL_00eb:
			int num6 = Tool.Geometry.ArborPoints.Count;
			if (uint.MaxValue != 0)
			{
				bool flag2 = num6 == 0;
				num6 = (flag2 ? 1 : 0);
			}
			goto IL_0105;
			IL_015b:
			int num7;
			Point2d<double> item2 = new Point2d<double>(x, Tool.Geometry.ArborPoints[num7].Y);
			List<Point2d<double>> list2;
			list2.Add(item2);
			num6 = num7;
			if (false)
			{
				goto IL_0105;
			}
			num7 = num6 + 1;
			goto IL_0190;
			IL_0105:
			ToolArbor val2;
			if (num6 != 0)
			{
				val2 = _0019._0091_0006(Tool.Geometry.ArborTopDiameter, Tool.Geometry.ArborLength, Unit.Metric);
				goto IL_01c4;
			}
			list2 = new List<Point2d<double>>();
			num7 = 0;
			if (4 == 0)
			{
				goto IL_006d;
			}
			goto IL_0190;
			IL_01c4:
			return (Tool)new LollipopMill(Tool.Geometry.Diameter, val, Tool.Geometry.Length, Tool.Geometry.CutLength, val2, Tool.Geometry.OutsideDiameter, Unit.Metric);
			IL_0190:
			num5 = num7 > Tool.Geometry.ArborPoints.Count - 1;
			if (false)
			{
				goto IL_00da;
			}
			if (!num5)
			{
				x = Tool.Geometry.ArborPoints[num7].X;
				goto IL_015b;
			}
			val2 = _001A._0092_0006(list2, Unit.Metric);
			goto IL_01c4;
			IL_00da:
			if (num5)
			{
				goto IL_006d;
			}
			val = _0018._0090_0006(list, Unit.Metric);
			goto IL_00eb;
		}
		catch (Exception ex)
		{
			_001B._0093_0006(global::_0005._007E_0012_0003(ex));
			return null;
		}
	}

	public static Tool CreateSlotMill(ToolBase5 Tool)
	{
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Expected O, but got Unknown
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Expected O, but got Unknown
		try
		{
			ToolHolder val;
			if (Tool.Geometry.HolderPoints.Count == 0)
			{
				val = _0017._008F_0006(Tool.Geometry.HolderDiameter, Tool.Geometry.HolderLength, Unit.Metric);
			}
			else
			{
				List<Point2d<double>> list = new List<Point2d<double>>();
				int num = 0;
				while (true)
				{
					bool flag = num <= Tool.Geometry.HolderPoints.Count - 1;
					if (0 == 0)
					{
						if (!flag)
						{
							break;
						}
						Point2d<double> item = new Point2d<double>(Tool.Geometry.HolderPoints[num].X, Tool.Geometry.HolderPoints[num].Y);
						list.Add(item);
					}
					num++;
				}
				val = _0018._0090_0006(list, Unit.Metric);
				if (false)
				{
					goto IL_00fb;
				}
			}
			if (Tool.Geometry.ArborPoints.Count == 0)
			{
				goto IL_00fb;
			}
			List<Point2d<double>> list2 = new List<Point2d<double>>();
			for (int i = 0; i <= Tool.Geometry.ArborPoints.Count - 1; i++)
			{
				if (0 == 0)
				{
				}
				Point2d<double> item2 = new Point2d<double>(Tool.Geometry.ArborPoints[i].X, Tool.Geometry.ArborPoints[i].Y);
				list2.Add(item2);
			}
			ToolArbor val2 = _001A._0092_0006(list2, Unit.Metric);
			goto IL_01a9;
			IL_00fb:
			val2 = _0019._0091_0006(Tool.Geometry.ArborTopDiameter, Tool.Geometry.ArborLength, Unit.Metric);
			goto IL_01a9;
			IL_01a9:
			CornerRadiusType cornerRadiusType = (CornerRadiusType)_001E._0096_0006(_001C._0094_0006(typeof(CornerRadiusType).TypeHandle), _001D._0095_0006(Tool.Geometry.CornerRadiusType));
			SlotMill val3 = null;
			if ((Tool.Geometry.ShoulderDiameter <= 0.0) | (Tool.Geometry.ShoulderLength <= 0.0))
			{
				val3 = new SlotMill(Tool.Geometry.Diameter, val, Tool.Geometry.CutLength, val2, Tool.Geometry.LowerRadius, Tool.Geometry.UpperRadius, cornerRadiusType, Unit.Metric);
			}
			else
			{
				ShoulderExtension val4 = new ShoulderExtension(Tool.Geometry.ShoulderDiameter, Tool.Geometry.Length, Unit.Metric);
				val3 = new SlotMill(Tool.Geometry.Diameter, val, Tool.Geometry.CutLength, val2, Tool.Geometry.LowerRadius, Tool.Geometry.UpperRadius, cornerRadiusType, Tool.Geometry.Length, val4, Unit.Metric);
			}
			return (Tool)(object)val3;
		}
		catch (Exception ex)
		{
			_001B._0093_0006(global::_0005._007E_0012_0003(ex));
			return null;
		}
	}

	public static Tool CreateChamferMill(ToolBase5 Tool)
	{
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Expected O, but got Unknown
		ToolHolder val2 = default(ToolHolder);
		Tool result;
		do
		{
			try
			{
				int num;
				int num2;
				if (0 == 0)
				{
					num = Tool.Geometry.HolderPoints.Count;
					num2 = 0;
					goto IL_001a;
				}
				goto IL_0076;
				IL_018a:
				int num4;
				int num3 = num4;
				if (false)
				{
					goto IL_0107;
				}
				if (num3 <= Tool.Geometry.ArborPoints.Count - 1)
				{
					goto IL_0144;
				}
				List<Point2d<double>> list;
				ToolArbor val = _001A._0092_0006(list, Unit.Metric);
				goto IL_01be;
				IL_001a:
				if (num == num2)
				{
					if (0 == 0)
					{
						val2 = _0017._008F_0006(Tool.Geometry.HolderDiameter, Tool.Geometry.HolderLength, Unit.Metric);
						goto IL_00f4;
					}
					goto IL_018a;
				}
				List<Point2d<double>> list2 = new List<Point2d<double>>();
				int num5 = 0;
				if (0 == 0)
				{
					goto IL_00c3;
				}
				goto IL_0144;
				IL_01be:
				CornerRadiusType cornerRadiusType = (CornerRadiusType)_001E._0096_0006(_001C._0094_0006(typeof(CornerRadiusType).TypeHandle), _001D._0095_0006(Tool.Geometry.CornerRadiusType));
				ChamferMill val3 = new ChamferMill(Tool.Geometry.Diameter, val2, Tool.Geometry.Length, Tool.Geometry.CutLength, val, Tool.Geometry.LowerRadius, cornerRadiusType, Tool.Geometry.OutsideDiameter, Tool.Geometry.TaperAngle, Unit.Metric);
				result = (Tool)(object)val3;
				goto end_IL_0001;
				IL_00c3:
				if (num5 <= Tool.Geometry.HolderPoints.Count - 1)
				{
					goto IL_0076;
				}
				if (3u != 0)
				{
					val2 = _0018._0090_0006(list2, Unit.Metric);
					goto IL_00f4;
				}
				goto IL_010d;
				IL_0076:
				Point2d<double> item = new Point2d<double>(Tool.Geometry.HolderPoints[num5].X, Tool.Geometry.HolderPoints[num5].Y);
				list2.Add(item);
				num = num5;
				num2 = 1;
				if (num2 == 0)
				{
					goto IL_001a;
				}
				num5 = num + num2;
				goto IL_00c3;
				IL_00f4:
				num3 = ((Tool.Geometry.ArborPoints.Count == 0) ? 1 : 0);
				goto IL_0107;
				IL_010d:
				val = _0019._0091_0006(Tool.Geometry.ArborTopDiameter, Tool.Geometry.ArborLength, Unit.Metric);
				goto IL_01be;
				IL_0144:
				Point2d<double> item2 = new Point2d<double>(Tool.Geometry.ArborPoints[num4].X, Tool.Geometry.ArborPoints[num4].Y);
				list.Add(item2);
				num4++;
				goto IL_018a;
				IL_0107:
				if (num3 != 0)
				{
					goto IL_010d;
				}
				list = new List<Point2d<double>>();
				num4 = 0;
				goto IL_018a;
				end_IL_0001:;
			}
			catch (Exception ex)
			{
				_001B._0093_0006(global::_0005._007E_0012_0003(ex));
				result = null;
			}
		}
		while (false);
		return result;
	}

	public static Tool CreateDoveMill(ToolBase5 Tool)
	{
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Expected O, but got Unknown
		try
		{
			List<Point2d<double>> list = default(List<Point2d<double>>);
			int num = default(int);
			if (Tool.Geometry.HolderPoints.Count != 0)
			{
				if (4 == 0)
				{
					goto IL_00ab;
				}
				list = new List<Point2d<double>>();
				num = 0;
				goto IL_00b7;
			}
			ToolHolder val = _0017._008F_0006(Tool.Geometry.HolderDiameter, Tool.Geometry.HolderLength, Unit.Metric);
			goto IL_00eb;
			IL_019b:
			int num3;
			int num4;
			int num2 = ((num3 <= num4) ? 1 : 0);
			goto IL_01a0;
			IL_01a0:
			double num5;
			int num6 = default(int);
			if (num2 != 0)
			{
				num5 = Tool.Geometry.ArborPoints[num6].X;
				goto IL_0158;
			}
			if (8 == 0)
			{
				goto IL_00a0;
			}
			List<Point2d<double>> list2 = default(List<Point2d<double>>);
			ToolArbor val2 = _001A._0092_0006(list2, Unit.Metric);
			if (7 == 0)
			{
				goto IL_00ab;
			}
			goto IL_01c1;
			IL_0187:
			num3 = num6;
			num4 = Tool.Geometry.ArborPoints.Count - 1;
			goto IL_019b;
			IL_00eb:
			int num7 = Tool.Geometry.ArborPoints.Count;
			if (false)
			{
				goto IL_0185;
			}
			if (num7 == 0)
			{
				val2 = _0019._0091_0006(Tool.Geometry.ArborTopDiameter, Tool.Geometry.ArborLength, Unit.Metric);
				goto IL_01c1;
			}
			list2 = new List<Point2d<double>>();
			num6 = 0;
			goto IL_0187;
			IL_00a0:
			Point2d<double> item = default(Point2d<double>);
			list.Add(item);
			goto IL_00ab;
			IL_00ab:
			num2 = num + 1;
			if (0 == 0)
			{
				num = num2;
				goto IL_00b7;
			}
			goto IL_01a0;
			IL_00b7:
			num3 = num;
			num4 = Tool.Geometry.HolderPoints.Count;
			if (0 == 0)
			{
				if (num3 <= num4 - 1)
				{
					item = new Point2d<double>(Tool.Geometry.HolderPoints[num].X, Tool.Geometry.HolderPoints[num].Y);
					goto IL_00a0;
				}
				val = _0018._0090_0006(list, Unit.Metric);
				goto IL_00eb;
			}
			goto IL_019b;
			IL_01c1:
			CornerRadiusType cornerRadiusType = (CornerRadiusType)_001E._0096_0006(_001C._0094_0006(typeof(CornerRadiusType).TypeHandle), _001D._0095_0006(Tool.Geometry.CornerRadiusType));
			num5 = Tool.Geometry.Diameter;
			if (7u != 0)
			{
				return (Tool)new DoveMill(num5, val, Tool.Geometry.Length, Tool.Geometry.CutLength, val2, Tool.Geometry.LowerRadius, cornerRadiusType, Tool.Geometry.TaperAngle, Unit.Metric);
			}
			goto IL_0158;
			IL_0158:
			Point2d<double> item2 = new Point2d<double>(num5, Tool.Geometry.ArborPoints[num6].Y);
			list2.Add(item2);
			num7 = num6 + 1;
			goto IL_0185;
			IL_0185:
			num6 = num7;
			goto IL_0187;
		}
		catch (Exception ex)
		{
			_001B._0093_0006(global::_0005._007E_0012_0003(ex));
			return null;
		}
	}

	public static Tool CreateBarrelMill(ToolBase5 Tool)
	{
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected O, but got Unknown
		try
		{
			bool num = Tool.Geometry.HolderPoints.Count == 0;
			bool flag;
			if (6u != 0)
			{
				flag = num;
			}
			ToolHolder val = default(ToolHolder);
			if (flag)
			{
				val = _0017._008F_0006(Tool.Geometry.HolderDiameter, Tool.Geometry.HolderLength, Unit.Metric);
				goto IL_00f3;
			}
			List<Point2d<double>> list;
			if (8u != 0)
			{
				list = new List<Point2d<double>>();
				goto IL_006a;
			}
			goto IL_0178;
			IL_00e4:
			val = _0018._0090_0006(list, Unit.Metric);
			goto IL_00f3;
			IL_01a8:
			int num2;
			int count;
			int num3;
			Point2d<double> item;
			int num4 = default(int);
			if (num2 <= count - num3)
			{
				item = new Point2d<double>(Tool.Geometry.ArborPoints[num4].X, Tool.Geometry.ArborPoints[num4].Y);
				goto IL_0178;
			}
			List<Point2d<double>> list2 = default(List<Point2d<double>>);
			ToolArbor val2 = _001A._0092_0006(list2, Unit.Metric);
			goto IL_01c3;
			IL_006a:
			int num5 = 0;
			while (true)
			{
				num2 = num5;
				count = Tool.Geometry.HolderPoints.Count;
				num3 = 1;
				if (num3 == 0)
				{
					break;
				}
				int num6 = count - num3;
				if (uint.MaxValue != 0)
				{
					num2 = ((num2 > num6) ? 1 : 0);
					num6 = 0;
				}
				if (num2 != num6)
				{
					goto IL_00e4;
				}
				Point2d<double> item2 = new Point2d<double>(Tool.Geometry.HolderPoints[num5].X, Tool.Geometry.HolderPoints[num5].Y);
				if (true)
				{
					list.Add(item2);
					num5++;
					continue;
				}
				goto IL_0135;
			}
			goto IL_01a8;
			IL_01c3:
			if (true)
			{
				return (Tool)new BarrelMill(Tool.Geometry.UpperDiameter, Tool.Geometry.MaxDiameter, val, Tool.Geometry.Length, Tool.Geometry.CutLength, val2, Tool.Geometry.LowerRadius, Tool.Geometry.ProfileRadius, Unit.Metric);
			}
			goto IL_00e4;
			IL_0178:
			if (false)
			{
				goto IL_006a;
			}
			list2.Add(item);
			int num7 = num4 + 1;
			if (4 == 0)
			{
				goto IL_0106;
			}
			num4 = num7;
			goto IL_0195;
			IL_00f3:
			num7 = ((Tool.Geometry.ArborPoints.Count == 0) ? 1 : 0);
			goto IL_0106;
			IL_0106:
			if (num7 == 0)
			{
				goto IL_0135;
			}
			val2 = _0019._0091_0006(Tool.Geometry.ArborTopDiameter, Tool.Geometry.ArborLength, Unit.Metric);
			goto IL_01c3;
			IL_0135:
			list2 = new List<Point2d<double>>();
			num4 = 0;
			goto IL_0195;
			IL_0195:
			num2 = num4;
			count = Tool.Geometry.ArborPoints.Count;
			num3 = 1;
			goto IL_01a8;
		}
		catch (Exception ex)
		{
			_001B._0093_0006(global::_0005._007E_0012_0003(ex));
			return null;
		}
	}

	public static Tool CreateConvexTipMill(ToolBase5 Tool)
	{
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected O, but got Unknown
		try
		{
			bool num = Tool.Geometry.HolderPoints.Count == 0;
			bool flag;
			if (6u != 0)
			{
				flag = num;
			}
			ToolHolder val = default(ToolHolder);
			if (flag)
			{
				val = _0017._008F_0006(Tool.Geometry.HolderDiameter, Tool.Geometry.HolderLength, Unit.Metric);
				goto IL_00f3;
			}
			List<Point2d<double>> list;
			if (8u != 0)
			{
				list = new List<Point2d<double>>();
				goto IL_006a;
			}
			goto IL_0178;
			IL_00e4:
			val = _0018._0090_0006(list, Unit.Metric);
			goto IL_00f3;
			IL_01a8:
			int num2;
			int count;
			int num3;
			Point2d<double> item;
			int num4 = default(int);
			if (num2 <= count - num3)
			{
				item = new Point2d<double>(Tool.Geometry.ArborPoints[num4].X, Tool.Geometry.ArborPoints[num4].Y);
				goto IL_0178;
			}
			List<Point2d<double>> list2 = default(List<Point2d<double>>);
			ToolArbor val2 = _001A._0092_0006(list2, Unit.Metric);
			goto IL_01c3;
			IL_006a:
			int num5 = 0;
			while (true)
			{
				num2 = num5;
				count = Tool.Geometry.HolderPoints.Count;
				num3 = 1;
				if (num3 == 0)
				{
					break;
				}
				int num6 = count - num3;
				if (uint.MaxValue != 0)
				{
					num2 = ((num2 > num6) ? 1 : 0);
					num6 = 0;
				}
				if (num2 != num6)
				{
					goto IL_00e4;
				}
				Point2d<double> item2 = new Point2d<double>(Tool.Geometry.HolderPoints[num5].X, Tool.Geometry.HolderPoints[num5].Y);
				if (true)
				{
					list.Add(item2);
					num5++;
					continue;
				}
				goto IL_0135;
			}
			goto IL_01a8;
			IL_01c3:
			if (true)
			{
				return (Tool)new ConvexTipMill(Tool.Geometry.Diameter, val, Tool.Geometry.Length, Tool.Geometry.CutLength, val2, Tool.Geometry.LowerRadius, Tool.Geometry.ConvexTipRadius, Tool.Geometry.FlatnessDiameter, Unit.Metric);
			}
			goto IL_00e4;
			IL_0178:
			if (false)
			{
				goto IL_006a;
			}
			list2.Add(item);
			int num7 = num4 + 1;
			if (4 == 0)
			{
				goto IL_0106;
			}
			num4 = num7;
			goto IL_0195;
			IL_00f3:
			num7 = ((Tool.Geometry.ArborPoints.Count == 0) ? 1 : 0);
			goto IL_0106;
			IL_0106:
			if (num7 == 0)
			{
				goto IL_0135;
			}
			val2 = _0019._0091_0006(Tool.Geometry.ArborTopDiameter, Tool.Geometry.ArborLength, Unit.Metric);
			goto IL_01c3;
			IL_0135:
			list2 = new List<Point2d<double>>();
			num4 = 0;
			goto IL_0195;
			IL_0195:
			num2 = num4;
			count = Tool.Geometry.ArborPoints.Count;
			num3 = 1;
			goto IL_01a8;
		}
		catch (Exception ex)
		{
			_001B._0093_0006(global::_0005._007E_0012_0003(ex));
			return null;
		}
	}

	public static Tool CreateSaw(ToolBase5 Tool)
	{
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		try
		{
			List<Point2d<double>> list;
			int num;
			if (Tool.Geometry.HolderPoints.Count != 0)
			{
				list = new List<Point2d<double>>();
				num = 0;
				goto IL_00c5;
			}
			ToolHolder val = _0017._008F_0006(Tool.Geometry.HolderDiameter, Tool.Geometry.HolderLength, Unit.Metric);
			if (false)
			{
				goto IL_00bf;
			}
			goto IL_00f3;
			IL_01db:
			int num2 = 0;
			goto IL_01dc;
			IL_01dc:
			CornerRadiusType cornerRadiusType = (CornerRadiusType)num2;
			Tool.Geometry.LowerRadius = Tool.Geometry.Thickness / 8.0;
			Tool.Geometry.UpperRadius = Tool.Geometry.Thickness / 8.0;
			ToolArbor val2;
			return (Tool)new SlotMill(Tool.Geometry.Diameter, val, Tool.Geometry.Thickness, val2, Tool.Geometry.LowerRadius, Tool.Geometry.UpperRadius, cornerRadiusType, Unit.Metric);
			IL_00bf:
			num++;
			goto IL_00c5;
			IL_00c5:
			if (num <= Tool.Geometry.HolderPoints.Count - 1)
			{
				Point2d<double> item = new Point2d<double>(Tool.Geometry.HolderPoints[num].X, Tool.Geometry.HolderPoints[num].Y + 0.0 + 0.0);
				list.Add(item);
				goto IL_00bf;
			}
			val = _0018._0090_0006(list, Unit.Metric);
			goto IL_00f3;
			IL_01bd:
			int num3;
			num2 = ((num3 == 0) ? 1 : 0);
			int num4;
			List<Point2d<double>> list2;
			if (7u != 0)
			{
				if (num2 != 0)
				{
					Point2d<double> item2 = new Point2d<double>(Tool.Geometry.ArborPoints[num4].X, Tool.Geometry.ArborPoints[num4].Y + Tool.Geometry.Length - Tool.Geometry.Thickness);
					list2.Add(item2);
					num4++;
					goto IL_01a7;
				}
				val2 = _001A._0092_0006(list2, Unit.Metric);
				goto IL_01db;
			}
			goto IL_01dc;
			IL_01a7:
			num3 = ((num4 > Tool.Geometry.ArborPoints.Count - 1) ? 1 : 0);
			goto IL_01bd;
			IL_00f3:
			num3 = Tool.Geometry.ArborPoints.Count;
			if (false)
			{
				goto IL_01bd;
			}
			if (num3 == 0)
			{
				val2 = _0019._0091_0006(Tool.Geometry.ArborTopDiameter, Tool.Geometry.ArborLength, Unit.Metric);
				goto IL_01db;
			}
			list2 = new List<Point2d<double>>();
			num4 = 0;
			goto IL_01a7;
		}
		catch (Exception ex)
		{
			_001B._0093_0006(global::_0005._007E_0012_0003(ex));
			return null;
		}
	}

	public void GetProgress(ProgressDescription rProgress, OverallProgressDescription rOverAllProgress)
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Invalid comparison between Unknown and I4
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		if (this.m__0001 != null)
		{
			GetProgressUpdating = true;
			_001F._0097_0006();
			CalculationEventArg calculationEventArg = new CalculationEventArg();
			calculationEventArg.OverallProgressPercentage = global::_000E._007E_009B_0005(rOverAllProgress);
			calculationEventArg.ActiveProgressPercentage = global::_000E._007E_009C_0005(rProgress);
			calculationEventArg.ShowForm = Settings.ShowProgressForm;
			if ((int)_007F._007E_0098_0006(rProgress) > 0)
			{
				calculationEventArg.Job = _0081._009A_0006(new string[8]
				{
					((object)_0080._007E_0099_0006(rProgress)/*cast due to constrained. prefix*/).ToString(),
					buMWCalcs._0001(107396972),
					((object)_007F._007E_0098_0006(rProgress)/*cast due to constrained. prefix*/).ToString(),
					buMWCalcs._0001(107396963),
					global::_000E._007E_009D_0005(rProgress).ToString(),
					buMWCalcs._0001(107396990),
					global::_000E._007E_009E_0005(rProgress).ToString(),
					buMWCalcs._0001(107396985)
				});
			}
			else
			{
				calculationEventArg.Job = _0081._009A_0006(new string[6]
				{
					((object)_0080._007E_0099_0006(rProgress)/*cast due to constrained. prefix*/).ToString(),
					buMWCalcs._0001(107396963),
					global::_000E._007E_009D_0005(rProgress).ToString(),
					buMWCalcs._0001(107396990),
					global::_000E._007E_009E_0005(rProgress).ToString(),
					buMWCalcs._0001(107396985)
				});
			}
			_0082._007E_009B_0006(this.m__0001, calculationEventArg);
			GetProgressUpdating = false;
		}
	}

	public static GeoLib CopyCamParameter(GeoLib mainMW, camParameters5 mainBU, out camParameters5 copyBU)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		GeoLib result;
		if (0 == 0)
		{
			while (true)
			{
				GeoLib val = new GeoLib(_0083._007E_009C_0006(mainMW));
				_0086._007E_009E_0006(val, new MachiningParams(_0084._007E_009D_0006(mainMW)));
				if (7u != 0)
				{
					if (0 == 0)
					{
						CopyGeoLibProperties(mainMW, val);
					}
					do
					{
						copyBU = new camParameters5(mainBU);
					}
					while (2 == 0);
					result = val;
					if (3u != 0)
					{
						break;
					}
				}
			}
		}
		return result;
	}

	public static void CopyCamParameter(GeoLib mainMW, camParameters5 mainBU, ref MWParameters CopyPar)
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		if (4u != 0)
		{
			if (CopyPar == null)
			{
				CopyPar = new MWParameters(Unit.Metric, 0);
			}
			goto IL_0019;
		}
		goto IL_0036;
		IL_0019:
		_0086._007E_009E_0006(CopyPar.mwPar, new MachiningParams(_0084._007E_009D_0006(mainMW)));
		goto IL_0036;
		IL_0036:
		if (0 == 0)
		{
			CopyGeoLibProperties(mainMW, ref CopyPar.mwPar);
			CopyPar.buPar = new camParameters5(mainBU);
			return;
		}
		goto IL_0019;
	}

	public static void CopyCamParameter(MWParameters RefPar, ref MWParameters CopyPar)
	{
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		if (CopyPar == null)
		{
			CopyPar = new MWParameters(Unit.Metric, 0);
		}
		_0086._007E_009E_0006(CopyPar.mwPar, new MachiningParams(_0084._007E_009D_0006(RefPar.mwPar)));
		CopyGeoLibProperties(RefPar.mwPar, ref CopyPar.mwPar);
		CopyPar.buPar = new camParameters5(RefPar.buPar);
	}

	public static void CopyCamParameter(MWParameters RefPar, ref GeoLib copyMWPar, ref camParameters5 copyBUPar)
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		bool flag;
		do
		{
			if (false || uint.MaxValue != 0)
			{
				flag = copyMWPar == null;
			}
		}
		while (6 == 0);
		if (flag)
		{
			copyMWPar = new GeoLib(Unit.Metric);
		}
		do
		{
			_0086._007E_009E_0006(copyMWPar, new MachiningParams(_0084._007E_009D_0006(RefPar.mwPar)));
		}
		while (5 == 0 || 4 == 0);
		CopyGeoLibProperties(RefPar.mwPar, ref copyMWPar);
		copyBUPar = new camParameters5(RefPar.buPar);
	}

	public static void CopyGeoLibProperties(GeoLib main, GeoLib copy)
	{
		while (true)
		{
			if (7u != 0)
			{
				_0088._007E_0002_0007(copy, _0087._007E_009F_0006(main));
				if (6 == 0)
				{
					continue;
				}
				_0088._007E_0003_0007(copy, _0087._007E_0001_0007(main));
				if (false ? true : false)
				{
					break;
				}
			}
			_008A._007E_0006_0007(copy, _0089._007E_0004_0007(main));
			break;
		}
		if (6u != 0)
		{
			_008A._007E_0007_0007(copy, _0089._007E_0005_0007(main));
		}
	}

	public static void CopyGeoLibProperties(GeoLib main, ref GeoLib copy)
	{
		if (0 == 0)
		{
		}
		while (true)
		{
			_0088._007E_0002_0007(copy, _0087._007E_009F_0006(main));
			if (false)
			{
				continue;
			}
			while (0 == 0)
			{
				_0088 obj = _0088._007E_0003_0007;
				GeoLib obj2 = copy;
				IEnumerable<Point3d<double>> enumerable = _0087._007E_0001_0007(main);
				if (true)
				{
					obj(obj2, enumerable);
				}
				if (7u != 0)
				{
					if (0 == 0)
					{
						_008A._007E_0006_0007(copy, _0089._007E_0004_0007(main));
						_008A._007E_0007_0007(copy, _0089._007E_0005_0007(main));
						return;
					}
					continue;
				}
				return;
			}
		}
	}

	public static void ConvertFromMwCamParToBuCamPar(GeoLib MWPar, ref camParameters5 BUPar)
	{
		BUPar.Speeds.Feed = global::_0007._007E_0017_0003(_0084._007E_009D_0006(MWPar));
		BUPar.Speeds.Plunge = global::_0007._007E_0018_0003(_0084._007E_009D_0006(MWPar));
		BUPar.Speeds.Leave = global::_0007._007E_0019_0003(_0084._007E_009D_0006(MWPar));
		BUPar.Speeds.RapidEnable = global::_0003._007E_0006(_0084._007E_009D_0006(MWPar));
		BUPar.Speeds.Rapid = global::_0007._007E_001A_0003(_0084._007E_009D_0006(MWPar));
		BUPar.Distances.Air = global::_0007._007E_001B_0003(_008B._007E_0008_0007(_0084._007E_009D_0006(MWPar)));
		BUPar.Distances.Safe = global::_0007._007E_001C_0003(_008B._007E_0008_0007(_0084._007E_009D_0006(MWPar)));
		BUPar.Distances.Rapid = global::_0007._007E_001D_0003(_008B._007E_0008_0007(_0084._007E_009D_0006(MWPar)));
		BUPar.Distances.EntryAndExit = global::_0007._007E_001E_0003(_008B._007E_0008_0007(_0084._007E_009D_0006(MWPar)));
		BUPar.Distances.EntryAndExit = global::_0007._007E_001F_0003(_008B._007E_0008_0007(_0084._007E_009D_0006(MWPar)));
		BUPar.Distances.RapidRetract = global::_0003._007E_0007(_0084._007E_009D_0006(MWPar));
		BUPar.Steps.DepthStep = global::_0007._007E_007F_0003(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))));
		BUPar.Steps.NumberOfSlice = global::_000E._007E_009F_0005(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))));
		BUPar.Steps.DepthStepMode = (CamStepDepthMode)_001D._0095_0006(_008F._007E_0012_0007(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))))));
		if (3u != 0)
		{
			BUPar.Drill.PeckMode = global::_0003._007E_0008(_0090._007E_0014_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))));
			BUPar.Drill.PeckFullRetract = global::_0003._007E_000E(_0090._007E_0014_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))));
			BUPar.Drill.PeckDepth = global::_0007._007E_0080_0003(_0090._007E_0014_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))));
			BUPar.Drill.PeckMinRetractDistance = global::_0007._007E_0081_0003(_0090._007E_0014_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))));
			BUPar.Offsets.AdditionalOffset = global::_0007._007E_0082_0003(_0084._007E_009D_0006(MWPar));
			BUPar.Strategy.MachiningAreaMode = (CamMachiningAreaMode)_001D._0095_0006(_0091._007E_0015_0007(_0084._007E_009D_0006(MWPar)));
			BUPar.Strategy.CuttingMethod = (CamCuttingMethod)_001D._0095_0006(_0092._007E_0016_0007(_0084._007E_009D_0006(MWPar)));
			if (_0093._007E_0017_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))) == WireframeBasedTpCalcParamsCuttingSide.WfbCsLeft)
			{
				BUPar.Offsets.OpenContour = CamOpenContourType.Left;
				return;
			}
		}
		if (_0093._007E_0017_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))) == WireframeBasedTpCalcParamsCuttingSide.WfbCsRight)
		{
			BUPar.Offsets.OpenContour = CamOpenContourType.Right;
		}
		else if (_0093._007E_0017_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))) == WireframeBasedTpCalcParamsCuttingSide.WfbCsCenter)
		{
			BUPar.Offsets.OpenContour = CamOpenContourType.Center;
		}
	}

	public static GeoLib ConvertFromBuCamParToMwCamPar(GeoLib MWPar, camParameters5 BUPar)
	{
		_0094 obj = _0094._007E_0018_0007;
		MachiningParams obj2 = _0084._007E_009D_0006(MWPar);
		double feed = BUPar.Speeds.Feed;
		if (0 == 0)
		{
			obj(obj2, feed);
		}
		_0094._007E_0019_0007(_0084._007E_009D_0006(MWPar), BUPar.Speeds.Plunge);
		_0094._007E_001A_0007(_0084._007E_009D_0006(MWPar), BUPar.Speeds.Leave);
		_0095._007E_0006_000F(_0084._007E_009D_0006(MWPar), BUPar.Speeds.RapidEnable);
		bool flag = default(bool);
		if (4u != 0)
		{
			_0094._007E_001B_0007(_0084._007E_009D_0006(MWPar), BUPar.Speeds.Rapid);
			_0094._007E_001C_0007(_008B._007E_0008_0007(_0084._007E_009D_0006(MWPar)), BUPar.Distances.Air);
			_0094._007E_001D_0007(_008B._007E_0008_0007(_0084._007E_009D_0006(MWPar)), BUPar.Distances.Safe);
			_0094._007E_001E_0007(_008B._007E_0008_0007(_0084._007E_009D_0006(MWPar)), BUPar.Distances.Rapid);
			_0094._007E_001F_0007(_008B._007E_0008_0007(_0084._007E_009D_0006(MWPar)), BUPar.Distances.EntryAndExit);
			_0094._007E_007F_0007(_008B._007E_0008_0007(_0084._007E_009D_0006(MWPar)), BUPar.Distances.EntryAndExit);
			_0095._007E_0007_000F(_0084._007E_009D_0006(MWPar), BUPar.Distances.RapidRetract);
			if (BUPar.Steps.DepthStep <= 0.0)
			{
				BUPar.Steps.DepthStep = 1.0;
			}
			_0094._007E_0080_0007(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), _0096._0087_0011(BUPar.Steps.DepthStep));
			_0097._007E_0088_0011(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), BUPar.Steps.NumberOfSlice);
			_0098._007E_009A_0011(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), (MachiningAreaRoughingParamsDepthStepMode)_001D._0095_0006(BUPar.Steps.DepthStepMode));
			_0094._007E_0081_0007(_0099._007E_009C_0011(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), BUPar.Steps.EndValue);
			_0094._007E_0082_0007(_0099._007E_009C_0011(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), BUPar.Steps.StartValue);
			_0094._007E_0080_0007(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), _0096._0087_0011(BUPar.Steps.DepthStep));
			_0097._007E_0088_0011(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), BUPar.Steps.NumberOfSlice);
			_0098._007E_009A_0011(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), (MachiningAreaRoughingParamsDepthStepMode)_001D._0095_0006(BUPar.Steps.DepthStepMode));
			_0094._007E_0081_0007(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), BUPar.Steps.EndValue);
			_0094._007E_0082_0007(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), BUPar.Steps.StartValue);
			if ((BUPar.Steps.EndValue != BUPar.Steps.StartValue) & (BUPar.Steps.StartValue > BUPar.Steps.EndValue))
			{
				_009B._007E_009F_0011(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), MachiningAreaHeightsParamsHeightsType.ShpHtUserDefined);
			}
			else
			{
				_009B._007E_009F_0011(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), MachiningAreaHeightsParamsHeightsType.ShpHtAutomatic);
			}
			_0095._007E_0008_000F(_0090._007E_0014_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Drill.PeckMode);
			_0095._007E_000E_000F(_0090._007E_0014_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Drill.PeckFullRetract);
			if (0 == 0)
			{
				_0094._007E_0083_0007(_0090._007E_0014_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Drill.PeckDepth);
				_0094._007E_0084_0007(_0090._007E_0014_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Drill.PeckMinRetractDistance);
				_0094._007E_0086_0007(_0084._007E_009D_0006(MWPar), BUPar.Offsets.AdditionalOffset);
				_009C._007E_0001_0012(_0084._007E_009D_0006(MWPar), (MachiningParamsMachType)_001D._0095_0006(BUPar.Strategy.CuttingMethod));
				_009D._007E_0002_0012(_0084._007E_009D_0006(MWPar), (MachiningParamsMachiningAreaMode)_001D._0095_0006(BUPar.Strategy.MachiningAreaMode));
				if (BUPar.Offsets.OpenContour == CamOpenContourType.Left)
				{
					_009E._007E_0003_0012(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), WireframeBasedTpCalcParamsCuttingSide.WfbCsLeft);
					goto IL_0749;
				}
				flag = BUPar.Offsets.OpenContour == CamOpenContourType.Right;
			}
		}
		if (flag)
		{
			_009E._007E_0003_0012(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), WireframeBasedTpCalcParamsCuttingSide.WfbCsRight);
		}
		else
		{
			_009E._007E_0003_0012(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), WireframeBasedTpCalcParamsCuttingSide.WfbCsCenter);
		}
		goto IL_0749;
		IL_0749:
		return MWPar;
	}

	public static void ConvertFromMwCamParToBuCamParTriangleMesh(GeoLib MWPar, ref camParameters5 BUPar)
	{
		BUPar.Speeds.Feed = global::_0007._007E_0017_0003(_0084._007E_009D_0006(MWPar));
		BUPar.Speeds.Plunge = global::_0007._007E_0018_0003(_0084._007E_009D_0006(MWPar));
		BUPar.Speeds.Leave = global::_0007._007E_0019_0003(_0084._007E_009D_0006(MWPar));
		BUPar.Speeds.RapidEnable = global::_0003._007E_0006(_0084._007E_009D_0006(MWPar));
		BUPar.Speeds.Rapid = global::_0007._007E_001A_0003(_0084._007E_009D_0006(MWPar));
		BUPar.Distances.Air = global::_0007._007E_001B_0003(_008B._007E_0008_0007(_0084._007E_009D_0006(MWPar)));
		BUPar.Distances.Safe = global::_0007._007E_001C_0003(_008B._007E_0008_0007(_0084._007E_009D_0006(MWPar)));
		BUPar.Distances.Rapid = global::_0007._007E_001D_0003(_008B._007E_0008_0007(_0084._007E_009D_0006(MWPar)));
		BUPar.Distances.EntryAndExit = global::_0007._007E_001E_0003(_008B._007E_0008_0007(_0084._007E_009D_0006(MWPar)));
		BUPar.Distances.EntryAndExit = global::_0007._007E_001F_0003(_008B._007E_0008_0007(_0084._007E_009D_0006(MWPar)));
		BUPar.Distances.RapidRetract = global::_0003._007E_0007(_0084._007E_009D_0006(MWPar));
		BUPar.Strategy.UseRamp = global::_0003._007E_000F(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(MWPar)))));
		BUPar.Strategy.UseRamp = global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(MWPar)))))));
		BUPar.Strategy.CutTolerance = global::_0007._007E_0083_0003(_0084._007E_009D_0006(MWPar));
		BUPar.Steps.DepthStep = global::_0007._007E_007F_0003(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))));
		BUPar.Steps.NumberOfSlice = global::_000E._007E_009F_0005(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))));
		BUPar.Steps.DepthStepMode = (CamStepDepthMode)_001D._0095_0006(_008F._007E_0012_0007(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))))));
		BUPar.Steps.EndValue = global::_0007._007E_0084_0003(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))));
		BUPar.Steps.StartValue = global::_0007._007E_0086_0003(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))));
		BUPar.Steps.HeightType = (CamHeightsType)_001D._0095_0006(_0005_0002._007E_0012_0012(_0099._007E_009C_0011(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))))));
		BUPar.Operations.Stepover = global::_0007._007E_0087_0003(_0084._007E_009D_0006(MWPar));
		BUPar.Offsets.AdditionalOffset = global::_0007._007E_0082_0003(_0084._007E_009D_0006(MWPar));
		BUPar.Strategy.MachiningAreaMode = (CamMachiningAreaMode)_001D._0095_0006(_0091._007E_0015_0007(_0084._007E_009D_0006(MWPar)));
		BUPar.Strategy.CuttingMethod = (CamCuttingMethod)_001D._0095_0006(_0092._007E_0016_0007(_0084._007E_009D_0006(MWPar)));
		BUPar.Pockets.SharpCorner = global::_0003._007E_0010(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))));
		BUPar.Strategy.RoughLeadOut = global::_0003._007E_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))));
		BUPar.Strategy.MinimizeLink = global::_0003._007E_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))));
		BUPar.Strategy.RemoveCornerPeg = global::_0003._007E_0013(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))));
		BUPar.Strategy.RoughLeadOut = global::_0003._007E_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))));
		BUPar.Strategy.SilhouetteEnable = global::_0003._007E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))));
		BUPar.Strategy.SilhouetteTriangleMeshType = (CamSilhouetteContainmentTriangleMeshType)_001D._0095_0006(_0006_0002._007E_0013_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))));
		BUPar.Pockets.PocketType = (CamPocketType)_001D._0095_0006(_0007_0002._007E_0014_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))));
		BUPar.Strategy.RampTypeTriangleMesh = (CamRampTypeTriangleMeshType)_001D._0095_0006(_0008_0002._007E_0015_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))));
		BUPar.Strategy.RampModeTriangleMesh = (CamRampModeTriangleMeshType)_001D._0095_0006(_000E_0002._007E_0016_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))));
		BUPar.Strategy.RampPitch = global::_0007._007E_0088_0003(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))));
		BUPar.Strategy.RampAngle = global::_0007._007E_0089_0003(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))));
		BUPar.Strategy.RampMaxDiameterFromToolPerc = global::_0007._007E_008A_0003(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))));
		BUPar.Strategy.RampMinDiameterFromToolPerc = global::_0007._007E_008B_0003(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))));
		BUPar.Strategy.RampMinDiameterToolDiameterEnable = global::_0003._007E_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))));
		BUPar.Rotary.MaxAngleChange = global::_0007._007E_008C_0003(_0084._007E_009D_0006(MWPar));
		BUPar.Rotary.TiltStrategy = (CamTiltStrategy)_001D._0095_0006(_0010_0002._007E_0018_0012(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar))));
		BUPar.Rotary.SideTiltDefTypes = (CamSideTiltDefTypes)_001D._0095_0006(_0011_0002._007E_0019_0012(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar))));
		BUPar.Rotary.LagAngle = global::_0007._007E_008D_0003(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)));
		BUPar.Rotary.SideTiltAngle = global::_0007._007E_008E_0003(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)));
		BUPar.Rotary.SmoothingFlg = global::_0003._007E_0016(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)));
		BUPar.Rotary.LimitsFlg = global::_0003._007E_0017(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)));
		BUPar.Rotary.MaxAngleFromInitialToolOrientation = global::_0007._007E_008F_0003(_0012_0002._007E_001A_0012(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar))));
		BUPar.Rotary.BAngleLimitInXZPlaneFlg = global::_0003._007E_0018(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)));
		BUPar.Rotary.BAngleLimitStartInXZPlane = global::_0007._007E_0090_0003(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)));
		BUPar.Rotary.BAngleLimitEndInXZPlane = global::_0007._007E_0091_0003(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)));
		BUPar.Rotary.AAngleLimitInYZPlaneFlg = global::_0003._007E_0019(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)));
		BUPar.Rotary.AAngleLimitStartInYZPlane = global::_0007._007E_0092_0003(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)));
		BUPar.Rotary.AAngleLimitEndInYZPlane = global::_0007._007E_0093_0003(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)));
		BUPar.Rotary.CAngleLimitInXYPlaneFlg = global::_0003._007E_001A(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)));
		BUPar.Rotary.CAngleLimitStartInXYPlane = global::_0007._007E_0094_0003(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)));
		BUPar.Rotary.CAngleLimitEndInXYPlane = global::_0007._007E_0095_0003(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)));
		BUPar.Rotary.WOrtAngleLimitFlg = global::_0003._007E_001B(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)));
		BUPar.Rotary.WOrtAngleLimitStart = global::_0007._007E_0096_0003(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)));
		BUPar.Rotary.WOrtAngleLimitEnd = global::_0007._007E_0097_0003(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)));
	}

	public static GeoLib ConvertFromBuCamParToMwCamParTriangleMesh(GeoLib MWPar, camParameters5 BUPar)
	{
		_0094._007E_0018_0007(_0084._007E_009D_0006(MWPar), BUPar.Speeds.Feed);
		_0094 obj = _0094._007E_0019_0007;
		MachiningParams obj2 = _0084._007E_009D_0006(MWPar);
		double plunge = BUPar.Speeds.Plunge;
		if (3u != 0)
		{
			obj(obj2, plunge);
		}
		_0094._007E_001A_0007(_0084._007E_009D_0006(MWPar), BUPar.Speeds.Leave);
		_0095._007E_0006_000F(_0084._007E_009D_0006(MWPar), BUPar.Speeds.RapidEnable);
		_0094._007E_001B_0007(_0084._007E_009D_0006(MWPar), BUPar.Speeds.Rapid);
		if (((BUPar.Steps.EndValue != BUPar.Steps.StartValue) & (BUPar.Steps.StartValue > BUPar.Steps.EndValue)) && BUPar.Steps.StartValue + BUPar.Distances.Rapid > BUPar.Distances.Safe)
		{
			BUPar.Distances.Safe = BUPar.Steps.StartValue + BUPar.Distances.Rapid + 2.0;
		}
		if (BUPar.Distances.EntryAndExit > BUPar.Distances.Rapid)
		{
			BUPar.Distances.Rapid = BUPar.Distances.EntryAndExit;
		}
		if (BUPar.Distances.Air < BUPar.Distances.Safe)
		{
			BUPar.Distances.Air = BUPar.Distances.Safe;
		}
		_0094._007E_001C_0007(_008B._007E_0008_0007(_0084._007E_009D_0006(MWPar)), BUPar.Distances.Air);
		_0094._007E_001D_0007(_008B._007E_0008_0007(_0084._007E_009D_0006(MWPar)), BUPar.Distances.Safe);
		_0094._007E_001E_0007(_008B._007E_0008_0007(_0084._007E_009D_0006(MWPar)), BUPar.Distances.Rapid);
		_0094._007E_001F_0007(_008B._007E_0008_0007(_0084._007E_009D_0006(MWPar)), BUPar.Distances.EntryAndExit);
		_0094._007E_007F_0007(_008B._007E_0008_0007(_0084._007E_009D_0006(MWPar)), BUPar.Distances.EntryAndExit);
		_0095._007E_0007_000F(_0084._007E_009D_0006(MWPar), BUPar.Distances.RapidRetract);
		if (BUPar.Strategy.CutTolerance > 0.0)
		{
			_0094._007E_0087_0007(_0084._007E_009D_0006(MWPar), BUPar.Strategy.CutTolerance);
		}
		if (BUPar.Operations.Stepover > 0.0)
		{
			_0094._007E_0088_0007(_0084._007E_009D_0006(MWPar), BUPar.Operations.Stepover);
		}
		if (BUPar.Steps.DepthStep <= 0.0)
		{
			BUPar.Steps.DepthStep = 1.0;
		}
		_0094._007E_0089_0007(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), _0096._0087_0011(BUPar.Steps.FinalDepthStep));
		_0094._007E_0080_0007(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), _0096._0087_0011(BUPar.Steps.DepthStep));
		_0097._007E_0088_0011(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), BUPar.Steps.NumberOfSlice);
		_0098._007E_009A_0011(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), (MachiningAreaRoughingParamsDepthStepMode)_001D._0095_0006(BUPar.Steps.DepthStepMode));
		_0094._007E_0081_0007(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), BUPar.Steps.EndValue);
		_0094._007E_0082_0007(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), BUPar.Steps.StartValue);
		_0095._007E_000F_000F(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), BUPar.Steps.DepthStepEnable);
		if ((BUPar.Steps.EndValue != BUPar.Steps.StartValue) & (BUPar.Steps.StartValue > BUPar.Steps.EndValue))
		{
			_009B._007E_009F_0011(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), MachiningAreaHeightsParamsHeightsType.ShpHtUserDefined);
		}
		else
		{
			_009B._007E_009F_0011(_0099._007E_009D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), MachiningAreaHeightsParamsHeightsType.ShpHtAutomatic);
		}
		_0095._007E_0010_000F(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), BUPar.Strategy.SingleCut);
		_0013_0002._007E_001B_0012(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), (MachiningAreaRoughingParamsMachiningAreasType)_001D._0095_0006(BUPar.Strategy.MachiningAreaType));
		_0094._007E_0086_0007(_0084._007E_009D_0006(MWPar), BUPar.Offsets.AdditionalOffset);
		_009C._007E_0001_0012(_0084._007E_009D_0006(MWPar), (MachiningParamsMachType)_001D._0095_0006(BUPar.Strategy.CuttingMethod));
		_009D._007E_0002_0012(_0084._007E_009D_0006(MWPar), (MachiningParamsMachiningAreaMode)_001D._0095_0006(BUPar.Strategy.MachiningAreaMode));
		_0014_0002._007E_001C_0012(_0084._007E_009D_0006(MWPar), (MachiningParamsCutOrder)_001D._0095_0006(BUPar.Strategy.CutOrder));
		_0016_0002._007E_001E_0012(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(MWPar)), (CollCtrlOpStockParamsStockType)_001D._0095_0006(BUPar.Options.StockType));
		_0017_0002._007E_001F_0012(_0084._007E_009D_0006(MWPar), (MachiningParamsDirection)_001D._0095_0006(BUPar.Strategy.ClosedCutDirection));
		_0095._007E_0011_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Pockets.SharpCorner);
		_0095._007E_0012_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.RoughLeadOut);
		_0095._007E_0013_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.MinimizeLink);
		_0095._007E_0014_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.RemoveCornerPeg);
		_0095._007E_0015_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.ReverseCuttingOrder);
		_0095._007E_0016_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.ClosedOffset);
		_0095._007E_0017_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.EdgeRolling);
		_0095._007E_0018_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.VerticalWallExclude);
		_0095._007E_0019_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.VerticalWallMachine);
		_0094._007E_008A_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.FlatToleranceFactor);
		_0094._007E_008B_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.MinWidth);
		_0094._007E_008C_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.MaxWidth);
		_0095._007E_001A_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.MaxWidthFlg);
		_0094._007E_008D_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.ChainingDistanceInPercOfToolDiameter);
		_0095._007E_001B_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.MultiPencil);
		_0097._007E_0089_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.NumberOfCuts);
		_0095._007E_001C_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.CornerDetectionThresholdFlg);
		_0094._007E_008E_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.CornerDetectionThreshold);
		if (7u != 0)
		{
			_0095._007E_001D_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.SteepStepoverFlg);
			_0094._007E_008F_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.SteepStepover);
			_0095._007E_001E_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.CornerRefinementFlg);
			_0095._007E_001F_000F(_0018_0002._007E_007F_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), BUPar.Strategy.LeftDirNumberOfCutsFlg);
			_0097._007E_008A_0011(_0018_0002._007E_007F_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), BUPar.Strategy.LeftDirNumberOfCuts);
			_0095._007E_007F_000F(_0018_0002._007E_007F_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), BUPar.Strategy.RightDirNumberOfCutsFlg);
			_0097._007E_008B_0011(_0018_0002._007E_007F_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), BUPar.Strategy.RightDirNumberOfCuts);
			_0019_0002._007E_0081_0012(_0018_0002._007E_007F_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), (ProjectCurvesParamsOffsetDirection)_001D._0095_0006(BUPar.Strategy.StepDirection));
			_0095._007E_0080_000F(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), BUPar.Strategy.MaintainCuttingDirection);
			_0094._007E_0090_0007(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), BUPar.Operations.Overlap);
			_001B_0002._007E_0084_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), (TriangleMeshBasedTpCalcParamsRoughType)_001D._0095_0006(BUPar.Pockets.PocketType));
			_001C_0002._007E_0086_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), (TriangleMeshBasedTpCalcParamsParallelCutsStartCorner)_001D._0095_0006(BUPar.Strategy.ParallelCutStartCorner));
			_001D_0002._007E_0087_0012(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), (SharedMiscParamsConstantZStart)_001D._0095_0006(BUPar.Strategy.ConstantZStart));
			_0094._007E_0091_0007(_0084._007E_009D_0006(MWPar), BUPar.Strategy.ParallelCutAngleXY);
			_0094._007E_0092_0007(_0084._007E_009D_0006(MWPar), BUPar.Strategy.ParallelMachAngleFromZ);
			if (BUPar.Strategy.ParallelCutDireiton == CamParallelCutDirection.XDirection)
			{
				_0094._007E_0091_0007(_0084._007E_009D_0006(MWPar), 90.0);
			}
			else if (BUPar.Strategy.ParallelCutDireiton == CamParallelCutDirection.YDirection)
			{
				_0094._007E_0091_0007(_0084._007E_009D_0006(MWPar), 0.0);
			}
			_001E_0002._007E_0088_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), (TriangleMeshBasedTpCalcParamsRampType)_001D._0095_0006(BUPar.Strategy.RampTypeTriangleMesh));
			_001F_0002._007E_0089_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), (TriangleMeshBasedTpCalcParamsRampMode)_001D._0095_0006(BUPar.Strategy.RampModeTriangleMesh));
			_0095._007E_0081_000F(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(MWPar)))), BUPar.Strategy.UseRamp);
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(MWPar)))))), BUPar.Strategy.UseRamp & BUPar.Strategy.UseRampAreaLinks);
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(MWPar)))))), BUPar.Strategy.UseRamp & BUPar.Strategy.UseRampBetweenSlices);
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0080_0002._007E_008B_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(MWPar)))))), BUPar.Strategy.UseRamp & BUPar.Strategy.UseRampBetweenRegion);
			if (BUPar.Strategy.RampPitch > 0.0)
			{
				_0094._007E_0093_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.RampPitch);
			}
			if (BUPar.Strategy.RampAngle > 0.0)
			{
				_0094._007E_0094_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.RampAngle);
			}
			if (BUPar.Strategy.RampMaxDiameterFromToolPerc > 0.0)
			{
				_0094._007E_0095_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.RampMaxDiameterFromToolPerc);
			}
			if (BUPar.Strategy.RampMinDiameterFromToolPerc > 0.0)
			{
				_0094._007E_0096_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.RampMinDiameterFromToolPerc);
			}
			_0095._007E_0082_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.RampMinDiameterToolDiameterEnable);
			_0095._007E_0083_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.SilhouetteEnable);
			_0081_0002._007E_008C_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), (TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType)_001D._0095_0006(BUPar.Strategy.SilhouetteTriangleMeshType));
			_0094._007E_0097_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.SilhouetteStockRemain);
			_0082_0002._007E_008D_0012(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(MWPar)), (CollCtrlOpStockParamsSilhouetteType)_001D._0095_0006(BUPar.Options.StockSilhouetteType));
			if (!BUPar.Options.StockSilhouette)
			{
				global::_0011._007E_0018_0006(_0083_0002._007E_008E_0012(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(MWPar))));
			}
			_0095._007E_0084_000F(_0084_0002._007E_008F_0012(_0084._007E_009D_0006(MWPar)), BUPar.Strategy.AngleRangeEnable);
			_0094._007E_0098_0007(_0084_0002._007E_008F_0012(_0084._007E_009D_0006(MWPar)), BUPar.Strategy.AngleRangeSlopeAngleStart);
			_0094._007E_0099_0007(_0084_0002._007E_008F_0012(_0084._007E_009D_0006(MWPar)), BUPar.Strategy.AngleRangeSlopeAngleEnd);
			_0086_0002._007E_0090_0012(_0084_0002._007E_008F_0012(_0084._007E_009D_0006(MWPar)), (ShallowAndSteepAreaParamsMachiningAreaType)_001D._0095_0006(BUPar.Strategy.AngleRangeMachiningAreaType));
			_0095._007E_0086_000F(_0084._007E_009D_0006(MWPar), BUPar.Strategy.RadiuFitFlag);
			_0094._007E_009A_0007(_0084._007E_009D_0006(MWPar), BUPar.Strategy.SplineMaxDeviation);
			_0094._007E_009B_0007(_0084._007E_009D_0006(MWPar), BUPar.Rotary.MaxAngleChange);
			if (BUPar.Strategy.RotaryAxis == VectorType.XVector)
			{
				_0088_0002._007E_0092_0012(_0087_0002._007E_0091_0012(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar))), new Point3d<double>(0.0, 0.0, 0.0), new Point3d<double>(1.0, 0.0, 0.0));
			}
			if (BUPar.Strategy.RotaryAxis == VectorType.YVector)
			{
				_0088_0002._007E_0092_0012(_0087_0002._007E_0091_0012(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar))), new Point3d<double>(0.0, 0.0, 0.0), new Point3d<double>(0.0, 1.0, 0.0));
			}
			if (BUPar.Strategy.RotaryAxis == VectorType.ZVector)
			{
				_0088_0002._007E_0092_0012(_0087_0002._007E_0091_0012(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar))), new Point3d<double>(0.0, 0.0, 0.0), new Point3d<double>(0.0, 0.0, 1.0));
			}
			_0089_0002._007E_0093_0012(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)), MachiningParamsExtAxis.ExtAxisX);
			_008A_0002._007E_0094_0012(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)), (MachiningParamsTiltStrategy)_001D._0095_0006(BUPar.Rotary.TiltStrategy));
			_0094._007E_009C_0007(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)), BUPar.Rotary.LagAngle);
			_0094._007E_009D_0007(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)), BUPar.Rotary.SideTiltAngle);
			_008B_0002._007E_0095_0012(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)), (MachiningParamsSideTiltDefTypes)_001D._0095_0006(BUPar.Rotary.SideTiltDefTypes));
			_0095._007E_0087_000F(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)), BUPar.Rotary.SmoothingFlg);
			_0095._007E_0088_000F(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)), BUPar.Rotary.LimitsFlg);
			_0094._007E_009E_0007(_0012_0002._007E_001A_0012(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar))), BUPar.Rotary.MaxAngleFromInitialToolOrientation);
			_0095._007E_0089_000F(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)), BUPar.Rotary.BAngleLimitInXZPlaneFlg);
			_0094._007E_009F_0007(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)), BUPar.Rotary.BAngleLimitStartInXZPlane);
			_0094._007E_0001_0008(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)), BUPar.Rotary.BAngleLimitEndInXZPlane);
			_0095._007E_008A_000F(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)), BUPar.Rotary.AAngleLimitInYZPlaneFlg);
			_0094._007E_0002_0008(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)), BUPar.Rotary.AAngleLimitStartInYZPlane);
			_0094._007E_0003_0008(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)), BUPar.Rotary.AAngleLimitEndInYZPlane);
			_0095._007E_008B_000F(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)), BUPar.Rotary.CAngleLimitInXYPlaneFlg);
			_0094._007E_0004_0008(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)), BUPar.Rotary.CAngleLimitStartInXYPlane);
			_0094._007E_0005_0008(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)), BUPar.Rotary.CAngleLimitEndInXYPlane);
			_0095._007E_008C_000F(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)), BUPar.Rotary.WOrtAngleLimitFlg);
			_0094._007E_0006_0008(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)), BUPar.Rotary.WOrtAngleLimitStart);
			_0094._007E_0007_0008(_000F_0002._007E_0017_0012(_0084._007E_009D_0006(MWPar)), BUPar.Rotary.WOrtAngleLimitEnd);
			_0094._007E_0008_0008(_008D_0002._007E_0097_0012(_008C_0002._007E_0096_0012(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.MultiPassRoughPassSpacing);
			_008E_0002._007E_0098_0012(_008D_0002._007E_0097_0012(_008C_0002._007E_0096_0012(_0084._007E_009D_0006(MWPar))), (uint)BUPar.Strategy.MultiPassNumberOfRoughCuts);
			_0094._007E_000E_0008(_008D_0002._007E_0097_0012(_008C_0002._007E_0096_0012(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.MultiPassFinishPassSpacing);
			_008E_0002._007E_0099_0012(_008D_0002._007E_0097_0012(_008C_0002._007E_0096_0012(_0084._007E_009D_0006(MWPar))), (uint)BUPar.Strategy.MultiPassNumberOFinishCuts);
			_008F_0002._007E_009B_0012(_008D_0002._007E_0097_0012(_008C_0002._007E_0096_0012(_0084._007E_009D_0006(MWPar))), (MultiCutsRoughParamsSortType)_001D._0095_0006(BUPar.Strategy.MultiPassSortType));
			_0095._007E_008D_000F(_008D_0002._007E_0097_0012(_008C_0002._007E_0096_0012(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.MultiPass);
			_0094._007E_000F_0008(_0090_0002._007E_009C_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), BUPar.Strategy.CylinderRadiusAroundLine);
			_0094._007E_0010_0008(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.SideShift);
			_0094._007E_0011_0008(_0090_0002._007E_009C_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), BUPar.Strategy.ProjectionStartAngles);
		}
		_0094._007E_0012_0008(_0090_0002._007E_009C_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), BUPar.Strategy.ProjectionEndAngles);
		_0094._007E_0013_0008(_0090_0002._007E_009C_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), BUPar.Strategy.ProjectionStartHeight);
		_0094._007E_0014_0008(_0090_0002._007E_009C_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), BUPar.Strategy.ProjectionEndHeight);
		_0091_0002._007E_009D_0012(_0090_0002._007E_009C_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), new Point3d<double>(BUPar.Strategy.ProjectionLineX, BUPar.Strategy.ProjectionLineY, BUPar.Strategy.ProjectionLineZ));
		_0092_0002._007E_0001_0013(_0090_0002._007E_009C_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar)))), (ProjectionPatternTriMeshBasedParamsDirection)_001D._0095_0006(BUPar.Strategy.ProjectionDirection));
		_0095._007E_008E_000F(_0084._007E_009D_0006(MWPar), BUPar.Strategy.ReverseCut);
		_0095._007E_008F_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.MachiningDirectionAsReferenceForDirectionOfCutsFlg);
		_0095._007E_0090_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), BUPar.Strategy.OutputPatternFlag);
		_0093_0002._007E_0002_0013(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), (TriangleMeshBasedTpCalcParamsGeodesicType)_001D._0095_0006(BUPar.Strategy.GeodesicType));
		_0094_0002._007E_0003_0013(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), (TriangleMeshBasedTpCalcParamsGeodesicDriveInputType)_001D._0095_0006(BUPar.Strategy.GeodesicDriveInputType));
		_0095_0002._007E_0004_0013(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), (TriangleMeshBasedTpCalcParamsGeodesicContainmentType)_001D._0095_0006(BUPar.Strategy.GeodesicContainmetType));
		_0096_0002._007E_0005_0013(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(MWPar))), (TriangleMeshBasedTpCalcParamsGeodesicStepover)_001D._0095_0006(BUPar.Strategy.GeodesicStepoverType));
		return MWPar;
	}

	public static Point3d<double> Pnt3DToPnt3D(Point3D P)
	{
		Point3d<double> result;
		if (0 == 0)
		{
			try
			{
				Point3d<double> point3d = new Point3d<double>(P.X, P.Y, P.Z);
				do
				{
					result = point3d;
				}
				while (false);
			}
			catch (Exception mSException)
			{
				string text = buMWCalcs._0001(107396718);
				if (6u != 0)
				{
					buLog.addLog(text, buMWCalcs._0001(107396980), buMWCalcs._0001(107396939));
					buException.throwException(mSException, buMWCalcs._0001(107396939), ShowMessageBox: true, text);
				}
				result = new Point3d<double>();
			}
		}
		return result;
	}

	public static Point3D Pnt3DToPnt3D(Point3d<double> P)
	{
		Point3D result;
		if (0 == 0)
		{
			try
			{
				Point3D point3D = new Point3D(P.X, P.Y, P.Z);
				do
				{
					result = point3D;
				}
				while (false);
			}
			catch (Exception mSException)
			{
				string text = buMWCalcs._0001(107396718);
				if (6u != 0)
				{
					buLog.addLog(text, buMWCalcs._0001(107396980), buMWCalcs._0001(107396950));
					buException.throwException(mSException, buMWCalcs._0001(107396950), ShowMessageBox: true, text);
				}
				result = new Point3D();
			}
		}
		return result;
	}

	public static Vectord Vec3DToVec3D(Vector3D P)
	{
		try
		{
			return new Vectord(P.X, P.Y, P.Z);
		}
		catch (Exception ex)
		{
			string text = buMWCalcs._0001(107396718);
			_0097_0002._0006_0013(text, buMWCalcs._0001(107396980), buMWCalcs._0001(107396929));
			_0098_0002._0007_0013(ex, buMWCalcs._0001(107396929), true, text);
			return new Vectord();
		}
	}

	public static Vector3D Vec3DToVec3D(Vectord P)
	{
		try
		{
			return new Vector3D(P.X, P.Y, P.Z);
		}
		catch (Exception ex)
		{
			string text = buMWCalcs._0001(107396718);
			_0097_0002._0006_0013(text, buMWCalcs._0001(107396980), buMWCalcs._0001(107396364));
			_0098_0002._0007_0013(ex, buMWCalcs._0001(107396364), true, text);
			return new Vector3D();
		}
	}

	public static Surface ConvertToMWSurface(Surface surf)
	{
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Expected O, but got Unknown
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected O, but got Unknown
		int num = _009A_0002._007E_000E_0013(_0099_0002._007E_0008_0013(surf), 0);
		int num2 = _009A_0002._007E_000E_0013(_0099_0002._007E_0008_0013(surf), 1);
		WeightedPoint3d<double>[,] array = new WeightedPoint3d<double>[num, num2];
		UVKnotVector uVKnotVector = new UVKnotVector();
		_009B_0002._007E_000F_0013(uVKnotVector).AddRange(_009C_0002._007E_0011_0013(surf));
		_009B_0002._007E_0010_0013(uVKnotVector).AddRange(_009C_0002._007E_0012_0013(surf));
		int num3 = 0;
		int num4 = default(int);
		Surface result;
		while (true)
		{
			if (num3 < num)
			{
				num4 = 0;
				goto IL_00dd;
			}
			List<Curve> list = new List<Curve>();
			foreach (ICurve item2 in _009E_0002._007E_0015_0013(_009D_0002._007E_0014_0013(surf)))
			{
				Curve curve = _009F_0002._007E_0016_0013(item2);
				List<WeightedPoint2d<double>> list2 = new List<WeightedPoint2d<double>>(_0001_0003._007E_0017_0013(curve).Length);
				Point4D[] array2 = _0001_0003._007E_0017_0013(curve);
				foreach (Point4D point4D in array2)
				{
					list2.Add(new WeightedPoint2d<double>(point4D.X, point4D.Y, point4D.W));
				}
				Curve item = new Curve(list2.ToArray(), (short)global::_000E._007E_0001_0006(curve), _009C_0002._007E_0013_0013(curve));
				list.Add(item);
			}
			Surface val = new Surface(array, (short)global::_000E._007E_0002_0006(surf), (short)global::_000E._007E_0003_0006(surf), uVKnotVector, list, true);
			result = val;
			if (true && 0 == 0)
			{
				break;
			}
			goto IL_00d7;
			IL_00d7:
			num4++;
			goto IL_00dd;
			IL_00dd:
			if (num4 < num2)
			{
				Point4D point4D2 = _0099_0002._007E_0008_0013(surf)[num3, num4];
				array[num3, num4] = new WeightedPoint3d<double>(point4D2.X, point4D2.Y, point4D2.Z, point4D2.W);
				goto IL_00d7;
			}
			num3++;
		}
		return result;
	}

	public static Curve ConvertToMWCurve(ICurve curve, bool Reverse)
	{
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		Curve curve2 = _009F_0002._007E_0016_0013(curve);
		Curve curve3 = default(Curve);
		if (0 == 0)
		{
			curve3 = curve2;
		}
		nint num = (nint)_0001_0003._007E_0017_0013(curve3).LongLength;
		List<WeightedPoint3d<double>> list;
		if (true)
		{
			list = new List<WeightedPoint3d<double>>((int)num);
			goto IL_0035;
		}
		goto IL_008c;
		IL_00a4:
		return new Curve(list.ToArray(), (short)global::_000E._007E_0001_0006(curve3), _009C_0002._007E_0013_0013(curve3));
		IL_008c:
		Point4D[] array;
		int num2;
		if (num < array.Length)
		{
			Point4D point4D = array[num2];
			if (false)
			{
				Curve result;
				return result;
			}
			if (0 == 0)
			{
				list.Add(new WeightedPoint3d<double>(point4D.X, point4D.Y, point4D.Z, point4D.W));
				if (false)
				{
					goto IL_0035;
				}
				goto IL_0083;
			}
		}
		else if (!Reverse)
		{
			goto IL_00a4;
		}
		if (false)
		{
			goto IL_0083;
		}
		list.Reverse();
		goto IL_00a4;
		IL_0083:
		num2++;
		goto IL_008a;
		IL_0035:
		array = _0001_0003._007E_0017_0013(curve3);
		num2 = 0;
		goto IL_008a;
		IL_008a:
		num = num2;
		goto IL_008c;
	}

	public static Curve ConvertToMWLine(Line line, bool Reverse)
	{
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Expected O, but got Unknown
		List<WeightedPoint3d<double>> list = new List<WeightedPoint3d<double>>(2);
		bool num = !Reverse;
		bool flag;
		if (6u != 0)
		{
			flag = num;
		}
		while (true)
		{
			if (flag)
			{
				list.Add(new WeightedPoint3d<double>(_0002_0003._007E_0018_0013(line).X, _0002_0003._007E_0018_0013(line).Y, _0002_0003._007E_0018_0013(line).Z, 1.0));
				list.Add(new WeightedPoint3d<double>(_0002_0003._007E_0019_0013(line).X, _0002_0003._007E_0019_0013(line).Y, _0002_0003._007E_0019_0013(line).Z, 1.0));
				break;
			}
			list.Add(new WeightedPoint3d<double>(_0002_0003._007E_0019_0013(line).X, _0002_0003._007E_0019_0013(line).Y, _0002_0003._007E_0019_0013(line).Z, 1.0));
			if (false)
			{
				continue;
			}
			list.Add(new WeightedPoint3d<double>(_0002_0003._007E_0018_0013(line).X, _0002_0003._007E_0018_0013(line).Y, _0002_0003._007E_0018_0013(line).Z, 1.0));
			break;
		}
		double[] array = new double[4] { 0.0, 0.0, 1.0, 1.0 };
		short num2 = 1;
		return new Curve(list.ToArray(), num2, array);
	}

	public static Curve ConvertToMWArc(Arc arc, bool Reverse)
	{
		Curve result;
		if (6u != 0)
		{
			Curve result2;
			if (0 == 0)
			{
				bool flag = !Reverse;
				bool flag2;
				do
				{
					if (4u != 0 && !flag)
					{
						return _0007_0003._0081_0013(Pnt3DToPnt3D(_0002_0003._007E_001B_0013(arc)), Pnt3DToPnt3D(_0002_0003._007E_001A_0013(arc)), Pnt3DToPnt3D(_0002_0003._007E_001C_0013(arc)), new Point3d<double>(_0006_0003._007E_0080_0013(_0005_0003._007E_007F_0013(arc)).X, _0006_0003._007E_0080_0013(_0005_0003._007E_007F_0013(arc)).Y, _0006_0003._007E_0080_0013(_0005_0003._007E_007F_0013(arc)).Z), global::_0007._007E_0098_0003(arc));
					}
					flag2 = _0004_0003._007E_001F_0013((CustomData)_0003_0003._007E_001D_0013(arc)) == entitySortDirection.Normal;
				}
				while (false);
				if (!flag2)
				{
					result = _0007_0003._0081_0013(Pnt3DToPnt3D(_0002_0003._007E_001B_0013(arc)), Pnt3DToPnt3D(_0002_0003._007E_001A_0013(arc)), Pnt3DToPnt3D(_0002_0003._007E_001C_0013(arc)), new Point3d<double>(_0006_0003._007E_0080_0013(_0005_0003._007E_007F_0013(arc)).X, _0006_0003._007E_0080_0013(_0005_0003._007E_007F_0013(arc)).Y, _0006_0003._007E_0080_0013(_0005_0003._007E_007F_0013(arc)).Z * -1.0), global::_0007._007E_0098_0003(arc));
					goto IL_01a5;
				}
				result2 = _0007_0003._0081_0013(Pnt3DToPnt3D(_0002_0003._007E_001A_0013(arc)), Pnt3DToPnt3D(_0002_0003._007E_001B_0013(arc)), Pnt3DToPnt3D(_0002_0003._007E_001C_0013(arc)), new Point3d<double>(_0006_0003._007E_0080_0013(_0005_0003._007E_007F_0013(arc)).X, _0006_0003._007E_0080_0013(_0005_0003._007E_007F_0013(arc)).Y, _0006_0003._007E_0080_0013(_0005_0003._007E_007F_0013(arc)).Z), global::_0007._007E_0098_0003(arc));
			}
			return result2;
		}
		goto IL_01a5;
		IL_01a5:
		return result;
	}

	public static Curve ConvertToMWCircle(Circle circle, bool Reverse)
	{
		return _0007_0003._0081_0013(Pnt3DToPnt3D(_0002_0003._007E_001A_0013(circle)), Pnt3DToPnt3D(_0002_0003._007E_001A_0013(circle)), Pnt3DToPnt3D(_0002_0003._007E_001C_0013(circle)), new Point3d<double>(_0006_0003._007E_0080_0013(_0005_0003._007E_007F_0013(circle)).X, _0006_0003._007E_0080_0013(_0005_0003._007E_007F_0013(circle)).Y, _0006_0003._007E_0080_0013(_0005_0003._007E_007F_0013(circle)).Z), global::_0007._007E_0098_0003(circle));
	}

	public static Meshd ConvertToMWMesh(Mesh mesh)
	{
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Expected O, but got Unknown
		List<Triangled> list = new List<Triangled>(_0008_0003._007E_0082_0013(mesh).Length);
		nint num = (nint)_000E_0003._007E_0083_0013(mesh).LongLength;
		if (0 == 0)
		{
			num = (int)num;
		}
		List<Vectord> list2 = new List<Vectord>((int)num);
		int num2 = 0;
		while (true)
		{
			bool flag = num2 < _0008_0003._007E_0082_0013(mesh).Length;
			if (6u != 0)
			{
				bool num3 = flag;
				while (!num3)
				{
					int num4;
					if (_000F_0003._007E_0084_0013(mesh) != null)
					{
						if (false)
						{
							goto IL_00d0;
						}
						num4 = 0;
						goto IL_011d;
					}
					goto IL_0138;
					IL_00d0:
					bool flag2;
					if (flag2)
					{
						Vector3D vector3D = _000F_0003._007E_0084_0013(mesh)[num4];
						_0010_0003._007E_0086_0013(list[num4], new Vectord(vector3D.X, vector3D.Y, vector3D.Z));
					}
					int num5 = num4;
					if (8u != 0)
					{
						num4 = num5 + 1;
						goto IL_011d;
					}
					goto IL_011f;
					IL_011d:
					num5 = num4;
					goto IL_011f;
					IL_011f:
					if (num5 < _000F_0003._007E_0084_0013(mesh).Length)
					{
						num3 = num4 > list.Count - 1;
						if (6 == 0)
						{
							continue;
						}
						flag2 = !num3;
						goto IL_00d0;
					}
					goto IL_0138;
				}
				if (0 == 0)
				{
					IndexTriangle indexTriangle = _0008_0003._007E_0082_0013(mesh)[num2];
					Triangled item = new Triangled(indexTriangle.V1, indexTriangle.V2, indexTriangle.V3);
					list.Add(item);
				}
				num2++;
				continue;
			}
			goto IL_014e;
			IL_014e:
			if (false)
			{
				continue;
			}
			Point3D point3D;
			Vectord item2 = new Vectord(point3D.X, point3D.Y, point3D.Z);
			list2.Add(item2);
			int num6 = num6 + 1;
			goto IL_0180;
			IL_0180:
			if (num6 >= _000E_0003._007E_0083_0013(mesh).Length)
			{
				break;
			}
			point3D = _000E_0003._007E_0083_0013(mesh)[num6];
			goto IL_014e;
			IL_0138:
			num6 = 0;
			goto IL_0180;
		}
		return new Meshd(list, list2, Unit.Metric);
	}

	public static Mesh ConvertToDevDeptMesh(Meshd mesh)
	{
		List<Point3D> list;
		List<IndexTriangle> list2;
		while (true)
		{
			list = new List<Point3D>();
			if (6 == 0)
			{
				goto IL_00a5;
			}
			list2 = new List<IndexTriangle>();
			goto IL_0018;
			IL_0018:
			int num;
			if (2u != 0)
			{
				num = global::_000E._007E_0004_0006(mesh);
				if (false)
				{
					goto IL_00a7;
				}
				List<Triangled> list3 = new List<Triangled>(num);
			}
			List<Vectord> list4 = new List<Vectord>(global::_000E._007E_0005_0006(mesh));
			int num2 = 0;
			goto IL_00a5;
			IL_00a5:
			num = num2;
			goto IL_00a7;
			IL_00a7:
			bool flag = num < global::_000E._007E_0005_0006(mesh);
			if (false)
			{
				goto IL_0018;
			}
			if (!flag)
			{
				int i = 0;
				if (4 == 0)
				{
					continue;
				}
				for (; i < global::_000E._007E_0004_0006(mesh); i++)
				{
					IndexTriangle item = new IndexTriangle(global::_000E._007E_0006_0006(_0012_0003._007E_008A_0013(mesh, i)), global::_000E._007E_0007_0006(_0012_0003._007E_008A_0013(mesh, i)), global::_000E._007E_0008_0006(_0012_0003._007E_008A_0013(mesh, i)));
					list2.Add(item);
					if (0 == 0)
					{
					}
				}
				break;
			}
			if (false)
			{
				break;
			}
			Point3D item2 = new Point3D(_0011_0003._007E_0089_0013(mesh, num2).X, _0011_0003._007E_0089_0013(mesh, num2).Y, _0011_0003._007E_0089_0013(mesh, num2).Z);
			list.Add(item2);
			num2++;
			goto IL_00a5;
		}
		return new Mesh(list, list2);
	}

	public static void ConvertWireEntity(Entity buEntity, ref Curve mwEntity)
	{
		bool reverse = false;
		bool flag = buEntity is Line;
		bool num = flag;
		entitySortDirection sortDirection;
		while (true)
		{
			bool num2;
			if (0 == 0)
			{
				if (num)
				{
					sortDirection = GetSortDirection(buEntity);
					break;
				}
				num2 = buEntity is Arc;
				if (false)
				{
					goto IL_0148;
				}
				if (num2)
				{
					goto IL_0074;
				}
				bool flag2 = buEntity is Circle;
				num = flag2;
			}
			if (num)
			{
				entitySortDirection sortDirection2 = GetSortDirection(buEntity);
				if (sortDirection2 == entitySortDirection.Reverse)
				{
					reverse = false;
				}
				mwEntity = ConvertToMWCircle((Circle)buEntity, reverse);
				return;
			}
			if (buEntity is Curve)
			{
				entitySortDirection sortDirection3 = GetSortDirection(buEntity);
				if (sortDirection3 == entitySortDirection.Reverse)
				{
					reverse = true;
				}
				mwEntity = ConvertToMWCurve((Curve)buEntity, reverse);
				return;
			}
			if (4 == 0)
			{
				goto IL_0074;
			}
			if (buEntity is LinearPath)
			{
				entitySortDirection sortDirection4 = GetSortDirection(buEntity);
				bool flag3 = sortDirection4 == entitySortDirection.Reverse;
				num2 = flag3;
				goto IL_0148;
			}
			if (!(buEntity is CompositeCurve))
			{
				if (buEntity is Ellipse)
				{
					entitySortDirection sortDirection5 = GetSortDirection(buEntity);
					if (sortDirection5 == entitySortDirection.Reverse)
					{
						reverse = true;
					}
					mwEntity = ConvertToMWCurve((Ellipse)buEntity, reverse);
				}
				return;
			}
			goto IL_016f;
			IL_0148:
			if (num2)
			{
				reverse = true;
			}
			mwEntity = ConvertToMWCurve((LinearPath)buEntity, reverse);
			return;
			IL_0074:
			entitySortDirection sortDirection6 = GetSortDirection(buEntity);
			bool flag4 = sortDirection6 == entitySortDirection.Reverse;
			num = flag4;
			if (false)
			{
				continue;
			}
			if (num)
			{
				reverse = false;
				if (false)
				{
					break;
				}
			}
			if (true)
			{
				mwEntity = ConvertToMWArc((Arc)buEntity, reverse);
				return;
			}
			goto IL_016f;
			IL_016f:
			entitySortDirection sortDirection7 = GetSortDirection(buEntity);
			if (sortDirection7 == entitySortDirection.Reverse)
			{
				if (-1 == 0)
				{
					return;
				}
				reverse = true;
			}
			mwEntity = ConvertToMWCurve((CompositeCurve)buEntity, reverse);
			return;
		}
		if (sortDirection == entitySortDirection.Reverse)
		{
			reverse = true;
		}
		mwEntity = ConvertToMWCurve((ICurve)buEntity, reverse);
	}

	public static entitySortDirection GetSortDirection(Entity refEntity)
	{
		entitySortDirection result;
		while (true)
		{
			bool flag;
			if (8u != 0)
			{
				result = entitySortDirection.Normal;
				flag = _0003_0003._007E_001D_0013(refEntity) != null;
				goto IL_0015;
			}
			goto IL_001d;
			IL_0015:
			if (false || flag)
			{
				goto IL_001d;
			}
			goto IL_003b;
			IL_001d:
			if (false)
			{
				goto IL_0015;
			}
			result = _0004_0003._007E_001F_0013((CustomData)_0003_0003._007E_001D_0013(refEntity));
			if (false)
			{
				continue;
			}
			goto IL_003b;
			IL_003b:
			if (0 == 0)
			{
				break;
			}
			goto IL_001d;
		}
		return result;
	}

	static buMWCalcs()
	{
		do
		{
			Strings.CreateGetStringDelegate(typeof(buMWCalcs));
		}
		while (4 == 0);
		AdvancedTriMesh = false;
		GetProgressUpdating = false;
		varCamMeshRoughPars = null;
		varCamMeshParalelPars = null;
		varCamMeshContantZPars = null;
		varCamMeshPencilPars = null;
		if (3u != 0)
		{
			if (3u != 0)
			{
				varCamMeshProjectionPars = null;
				varCamMeshFlatlandPars = null;
				varCamMeshContantCuspPars = null;
				if (7 == 0)
				{
					goto IL_006f;
				}
				varCamWFPocketPars = null;
				varCamWFContourPars = null;
				varCamWFContour4XPars = null;
				varCamDrillPars = null;
			}
			varCamContouringPars = null;
			goto IL_006f;
		}
		goto IL_007e;
		IL_006f:
		if (8u != 0)
		{
			varCamSurfacePars = null;
		}
		varCam3AXTo5AXPars = null;
		goto IL_007e;
		IL_007e:
		varCamGeodesicPars = null;
		OrientationLines = new List<Entity>();
		CamEntities = new List<Entity>();
		entityProjection = null;
	}
}
