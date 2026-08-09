using System.Runtime.CompilerServices;
using System.Threading;
using ModuleWorks;

namespace buMW;

public class buMWUpdateHandler : UpdateHandler
{
	public static bool CancelOperation;

	[CompilerGenerated]
	private MWCalculationUpdateHandler _0001;

	public event MWCalculationUpdateHandler CalculationUpdate
	{
		[CompilerGenerated]
		add
		{
			MWCalculationUpdateHandler mWCalculationUpdateHandler = _0001;
			while (true)
			{
				MWCalculationUpdateHandler mWCalculationUpdateHandler2 = mWCalculationUpdateHandler;
				while (true)
				{
					MWCalculationUpdateHandler obj = (MWCalculationUpdateHandler)_0016._008D_0006(mWCalculationUpdateHandler2, value);
					MWCalculationUpdateHandler value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					mWCalculationUpdateHandler = Interlocked.CompareExchange(ref _0001, value2, mWCalculationUpdateHandler2);
					if ((object)mWCalculationUpdateHandler != mWCalculationUpdateHandler2)
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
			MWCalculationUpdateHandler mWCalculationUpdateHandler = _0001;
			while (true)
			{
				MWCalculationUpdateHandler mWCalculationUpdateHandler2 = mWCalculationUpdateHandler;
				while (true)
				{
					MWCalculationUpdateHandler obj = (MWCalculationUpdateHandler)_0016._008E_0006(mWCalculationUpdateHandler2, value);
					MWCalculationUpdateHandler value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					mWCalculationUpdateHandler = Interlocked.CompareExchange(ref _0001, value2, mWCalculationUpdateHandler2);
					if ((object)mWCalculationUpdateHandler != mWCalculationUpdateHandler2)
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

	public override bool IsCanceled()
	{
		return CancelOperation;
	}

	public override void SetProgress(ProgressDescription rProgress, OverallProgressDescription rOverAllProgress)
	{
		if (false)
		{
			return;
		}
		bool flag = _0001 != null;
		bool num = flag;
		while (true)
		{
			if (num)
			{
				if (8 == 0)
				{
					break;
				}
				_0001(rProgress, rOverAllProgress);
			}
			do
			{
				if (-1 == 0)
				{
					return;
				}
			}
			while (false);
			bool flag2 = global::_000E._007E_009B_0005(rOverAllProgress) >= 100;
			num = flag2;
			if (0 == 0)
			{
				if (!num)
				{
				}
				break;
			}
		}
	}

	public override void VisualUpdate(CNCMove lastCalculated, uint cutNumber)
	{
	}
}
