using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using _0005;
using ModuleWorks;
using ModuleWorks.Graphics;
using ModuleWorks.Graphics.OpenGL;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;

namespace buMW;

public class buMwCutSim
{
	public AsyncRenderer ARender;

	public IndexedAbstractRenderer AbsRender;

	public static List<List<Triangle3D>> CutSimTri;

	[CompilerGenerated]
	private MWCalculationResultHandler _0001;

	public static List<Triangle3D> ListTRi;

	public AsyncRenderer RenderD = (AsyncRenderer)new AsyncVBORenderer();

	public Verification Verify = null;

	public int MoveID = 1;

	public int CutSimStep = 10;

	public int CutSimCount = 0;

	[NonSerialized]
	internal static GetString _0011;

	public event MWCalculationResultHandler GetCalculations
	{
		[CompilerGenerated]
		add
		{
			MWCalculationResultHandler mWCalculationResultHandler = _0001;
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
					mWCalculationResultHandler = Interlocked.CompareExchange(ref _0001, value2, mWCalculationResultHandler2);
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
			MWCalculationResultHandler mWCalculationResultHandler = _0001;
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
					mWCalculationResultHandler = Interlocked.CompareExchange(ref _0001, value2, mWCalculationResultHandler2);
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

	public void DefineCutSim()
	{
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		Unit unit = Unit.Metric;
		AbsRender = (IndexedAbstractRenderer)(object)new AbsRenderr();
		Verify = new Verification();
		_0017_0003._007E_0094_0013(Verify, WorkpieceRepresentation.DexelBlock);
		_0018_0003._007E_0095_0013(Verify, WorkpieceDrawMode.Tool);
		_001A_0003._007E_0001_0014(Verify, _0019_0003._0096_0013());
		ColorScheme val = _001B_0003._007E_0004_0014(Verify, WorkpieceDrawMode.Tool);
		_001C_0003._007E_0005_0014(Verify, 10f);
		_001D_0003._007E_0007_0014(Verify, new Vectorf(0f, 0f, 0f), new Vectorf(500f, 500f, 50f));
		ToolHolder val2 = _0017._008F_0006(5.0, 5.0, unit);
		ToolArbor val3 = _0019._0091_0006(5.0, 5.0, unit);
		EndMill val4 = new EndMill(10.0, val2, 80.0, 50.0, val3, unit);
		_001E_0003._007E_0008_0014(Verify, (Tool)(object)val4, 0);
		VerifierToolBehavior verifierToolBehavior = _0005._0002._0001();
		_001F_0003._007E_000E_0014(Verify, verifierToolBehavior, false);
		MoveID = 1;
		CutSimCount = 0;
	}

	public void MoveCutSim(Pnt3D MoveFrom, Pnt3D MoveTo, bool GetTriangles, ref eEntities StockMesh)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		while (true)
		{
			Vectorf vectorf = new Vectorf(0f, 0f, 1f);
			Quaternion val = _007F_0003._000F_0014(vectorf, 0f);
			Frame val2 = new Frame(new Vectorf((float)MoveFrom.X, (float)MoveFrom.Y, (float)MoveFrom.Z), val);
			Frame val3 = new Frame(new Vectorf((float)MoveTo.X, (float)MoveTo.Y, (float)MoveTo.Z), val);
			_001C_0003._007E_0006_0014(Verify, MoveID);
			_0080_0003._007E_0010_0014(Verify, val2, val3, false);
			while (true)
			{
				MoveID++;
				bool num = GetTriangles;
				if (false)
				{
					goto IL_0128;
				}
				if (num)
				{
					if (false)
					{
						break;
					}
					if (1 == 0)
					{
						continue;
					}
					AbsRenderr.MeshTri.Clear();
					if (0 == 0)
					{
						AbsRenderr.MeshTriangles = new List<TriangleIndex>();
						AbsRenderr.MeshVertices = new List<Pnt3D>();
						_0081_0003._007E_0011_0014(Verify, (InteropAbstractRendererBase)(object)AbsRender);
						goto IL_010b;
					}
				}
				goto IL_0148;
				IL_010b:
				do
				{
					AbsRenderr.Draw();
				}
				while (6 == 0);
				List<Triangle3D> list = new List<Triangle3D>();
				num = AbsRenderr.MeshTri.Count > 0;
				goto IL_0128;
				IL_0148:
				CutSimCount++;
				if (0 == 0)
				{
					if (false)
					{
						break;
					}
					return;
				}
				goto IL_010b;
				IL_0128:
				if (num)
				{
					StockMesh = new eSurface(AbsRenderr.MeshTri, _0019_0003._0097_0013());
				}
				goto IL_0148;
			}
		}
	}

	public void MoveSim()
	{
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Expected O, but got Unknown
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected O, but got Unknown
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Expected O, but got Unknown
		Unit unit = Unit.Metric;
		AbsRender = (IndexedAbstractRenderer)(object)new AbsRenderr();
		Verify = new Verification();
		if (4u != 0)
		{
			StartRecord();
		}
		_0017_0003 obj = _0017_0003._007E_0094_0013;
		Verification verify = Verify;
		if (2u != 0)
		{
			obj(verify, WorkpieceRepresentation.DexelBlock);
		}
		_0018_0003._007E_0095_0013(Verify, WorkpieceDrawMode.Tool);
		_001A_0003._007E_0001_0014(Verify, _0019_0003._0096_0013());
		ColorScheme val = _001B_0003._007E_0004_0014(Verify, WorkpieceDrawMode.Tool);
		_001C_0003._007E_0005_0014(Verify, 0.1f);
		_001D_0003._007E_0007_0014(Verify, new Vectorf(-10f, -10f, 0f), new Vectorf(10f, 10f, 10f));
		ToolHolder val2 = _0017._008F_0006(5.0, 5.0, unit);
		ToolArbor val3 = _0019._0091_0006(5.0, 5.0, unit);
		EndMill val4 = new EndMill(2.0, val2, 20.0, 5.0, val3, unit);
		_001E_0003._007E_0008_0014(Verify, (Tool)(object)val4, 0);
		Meshf val5 = _0082_0003._007E_0012_0014(Verify);
		VerifierToolBehavior verifierToolBehavior = _0005._0002._0001();
		_001F_0003._007E_000E_0014(Verify, verifierToolBehavior, false);
		Vectorf vectorf = new Vectorf(0f, 0f, 1f);
		Quaternion val6 = _007F_0003._000F_0014(vectorf, 0f);
		Frame val7;
		Frame val8;
		Frame val9;
		do
		{
			val7 = new Frame(new Vectorf(-10f, -10f, 9f), val6);
			val8 = new Frame(new Vectorf(0f, 0f, 5f), val6);
			val9 = new Frame(new Vectorf(10f, 10f, 0f), val6);
		}
		while (7 == 0);
		_001C_0003._007E_0006_0014(Verify, 1f);
		_0080_0003._007E_0010_0014(Verify, val7, val8, false);
		_001C_0003._007E_0006_0014(Verify, 2f);
		_0080_0003._007E_0010_0014(Verify, val8, val9, false);
		StopRecord();
		Meshf val10 = _0082_0003._007E_0012_0014(Verify);
	}

	public void Sim()
	{
		_0081_0003._007E_0011_0014(Verify, (InteropAbstractRendererBase)(object)AbsRender);
	}

	public void DrawRender()
	{
		global::_0011._007E_001A_0006(RenderD);
	}

	public void StartRecord()
	{
		if (-1 == 0 || 8 == 0)
		{
			return;
		}
		string text;
		if (true)
		{
			if (7 == 0)
			{
				return;
			}
			text = global::_0002._0003(_0083_0003._0013_0014(), _0011(107396461));
		}
		_0084_0003._007E_0014_0014(Verify, text);
	}

	public void StopRecord()
	{
		global::_0011._007E_001B_0006(Verify);
	}

	static buMwCutSim()
	{
		Strings.CreateGetStringDelegate(typeof(buMwCutSim));
		CutSimTri = new List<List<Triangle3D>>();
		ListTRi = new List<Triangle3D>();
	}
}
