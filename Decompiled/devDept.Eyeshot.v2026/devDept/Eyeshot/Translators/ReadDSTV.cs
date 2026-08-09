using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using DSTV.Net.Contracts;
using DSTV.Net.Data;
using DSTV.Net.Enums;
using DSTV.Net.Implementations;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class ReadDSTV : ReadFileAsync
{
	public enum profileType
	{
		I,
		L,
		U,
		B,
		RU,
		RO,
		M,
		C,
		T,
		SO
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IDstv _0023_003DzLleEUYE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzPF_3hpnNaUp4dm3m7PdGTh0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz0zh7HD8YxvHXWiJaxgm8EWLR_6gwZYObFbjd1tg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz0P9603fAiLXv8whlgTs3DNuL5oLh5aiN4PoZSow_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzMYubkj58i_zwVrgdTohwIOgHB6UNr3fwO2WZpeg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzyqNrpTTvAg1qPP2peWAa6pSqMk2pA0x6YJsGQrA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzXqxZSnFI0lIVJl_aWyNW7GE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzlUT5II06b1m0EQ2_0024DPH86pxVwLkt;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzIYHzrbWVd76vVMSOMg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private profileType _0023_003DzX16azd7Pjte3UUl79A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzQj83NF0ittsBZl079w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double? _0023_003Dz7_7pA2RHqoRwMQyHPMfxbcY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzeeN2kx4NnMEdk2waFcrqXAM_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzIHuKgf924p_0024Ugb_0024N0lHpOMD8vpTn;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzutULlyT0ePKaooPmQqwnyeo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzGoU_JoL93mRxGRLAhw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dz24tHqIekxDYD3wkRxSxE6oU_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dza2MIRFx3_s3_0024tXuhg0iRgMXkLBtg_0jHaQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzRFPIQwtYS_0024kQc_0024L2p_0024eSkdw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dz9kdgIb5xsd3GMW_0024K11IYNNc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzFrJd_0024pC_0024Qsubcp5vXiXz9U2DagL_0024;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzjHVhjSvcMBg7gvpIyPMQ9ZvaA9L3;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string? _0023_003DzQGoQisCH7ousNUudlbFr4gy9B2HN;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string? _0023_003Dzrn0G1SWhqhaByaHMZOkiwf1Roq7t;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string? _0023_003DzPRfmN3LWT6WT_Z4bpBSYbB5tiBJv;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string? _0023_003DzhEH_9sIRTP62STljIsaeCZqdcr66;

	public override supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.Unitless;

	public bool AsRegion
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzPF_3hpnNaUp4dm3m7PdGTh0_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzPF_3hpnNaUp4dm3m7PdGTh0_003D = value;
		}
	}

	public string OrderIdentification
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz0zh7HD8YxvHXWiJaxgm8EWLR_6gwZYObFbjd1tg_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz0zh7HD8YxvHXWiJaxgm8EWLR_6gwZYObFbjd1tg_003D = value;
		}
	}

	public string DrawingIdentification
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz0P9603fAiLXv8whlgTs3DNuL5oLh5aiN4PoZSow_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz0P9603fAiLXv8whlgTs3DNuL5oLh5aiN4PoZSow_003D = value;
		}
	}

	public string PhaseIdentification
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzMYubkj58i_zwVrgdTohwIOgHB6UNr3fwO2WZpeg_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzMYubkj58i_zwVrgdTohwIOgHB6UNr3fwO2WZpeg_003D = value;
		}
	}

	public string PieceIdentification
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzyqNrpTTvAg1qPP2peWAa6pSqMk2pA0x6YJsGQrA_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzyqNrpTTvAg1qPP2peWAa6pSqMk2pA0x6YJsGQrA_003D = value;
		}
	}

	public string SteelQuality
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzXqxZSnFI0lIVJl_aWyNW7GE_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzXqxZSnFI0lIVJl_aWyNW7GE_003D = value;
		}
	}

	public int QuantityOfPieces
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzlUT5II06b1m0EQ2_0024DPH86pxVwLkt;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzlUT5II06b1m0EQ2_0024DPH86pxVwLkt = value;
		}
	}

	public string Profile
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzIYHzrbWVd76vVMSOMg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzIYHzrbWVd76vVMSOMg_003D_003D = value;
		}
	}

	public profileType ProfileCode
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzX16azd7Pjte3UUl79A_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzX16azd7Pjte3UUl79A_003D_003D = value;
		}
	}

	public double Length
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzQj83NF0ittsBZl079w_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzQj83NF0ittsBZl079w_003D_003D = value;
		}
	}

	public double? SawLength
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz7_7pA2RHqoRwMQyHPMfxbcY_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz7_7pA2RHqoRwMQyHPMfxbcY_003D = value;
		}
	}

	public double ProfileHeight
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzeeN2kx4NnMEdk2waFcrqXAM_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzeeN2kx4NnMEdk2waFcrqXAM_003D = value;
		}
	}

	public double FlangeWidth
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzIHuKgf924p_0024Ugb_0024N0lHpOMD8vpTn;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzIHuKgf924p_0024Ugb_0024N0lHpOMD8vpTn = value;
		}
	}

	public double WebThickness
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzutULlyT0ePKaooPmQqwnyeo_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzutULlyT0ePKaooPmQqwnyeo_003D = value;
		}
	}

	public double Radius
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzGoU_JoL93mRxGRLAhw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzGoU_JoL93mRxGRLAhw_003D_003D = value;
		}
	}

	public double WeightByMeter
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz24tHqIekxDYD3wkRxSxE6oU_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz24tHqIekxDYD3wkRxSxE6oU_003D = value;
		}
	}

	public double PaintingSurfaceByMeter
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dza2MIRFx3_s3_0024tXuhg0iRgMXkLBtg_0jHaQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dza2MIRFx3_s3_0024tXuhg0iRgMXkLBtg_0jHaQ_003D_003D = value;
		}
	}

	public double WebStartCut
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzRFPIQwtYS_0024kQc_0024L2p_0024eSkdw_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzRFPIQwtYS_0024kQc_0024L2p_0024eSkdw_003D = value;
		}
	}

	public double WebEndCut
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz9kdgIb5xsd3GMW_0024K11IYNNc_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz9kdgIb5xsd3GMW_0024K11IYNNc_003D = value;
		}
	}

	public double FlangeStartCut
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzFrJd_0024pC_0024Qsubcp5vXiXz9U2DagL_0024;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzFrJd_0024pC_0024Qsubcp5vXiXz9U2DagL_0024 = value;
		}
	}

	public double FlangeEndCut
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzjHVhjSvcMBg7gvpIyPMQ9ZvaA9L3;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzjHVhjSvcMBg7gvpIyPMQ9ZvaA9L3 = value;
		}
	}

	public string? Text1InfoOnPiece
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzQGoQisCH7ousNUudlbFr4gy9B2HN;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzQGoQisCH7ousNUudlbFr4gy9B2HN = value;
		}
	}

	public string? Text2InfoOnPiece
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzrn0G1SWhqhaByaHMZOkiwf1Roq7t;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzrn0G1SWhqhaByaHMZOkiwf1Roq7t = value;
		}
	}

	public string? Text3InfoOnPiece
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzPRfmN3LWT6WT_Z4bpBSYbB5tiBJv;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzPRfmN3LWT6WT_Z4bpBSYbB5tiBJv = value;
		}
	}

	public string? Text4InfoOnPiece
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzhEH_9sIRTP62STljIsaeCZqdcr66;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzhEH_9sIRTP62STljIsaeCZqdcr66 = value;
		}
	}

	public ReadDSTV(string filePath, bool asRegion = true)
		: base(filePath)
	{
		AsRegion = asRegion;
	}

	public ReadDSTV(Stream stream, bool asRegion = true)
		: base(stream)
	{
		AsRegion = asRegion;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		byte b = 3;
		object[] array = null;
		array = new object[3] { b, this, flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "$N9u(q\"acA", array);
		_0023_003DzS9L7kLn8lYXX(progress, ct);
	}

	private void _0023_003DzS9L7kLn8lYXX(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		try
		{
			StreamReader reader = ((base.Stream == null) ? new StreamReader(base.FilePath) : new StreamReader(base.Stream));
			ConfiguredTaskAwaitable<IDstv>.ConfiguredTaskAwaiter awaiter = new DstvReader().ParseAsync(reader).ConfigureAwait(continueOnCapturedContext: true).GetAwaiter();
			while (!awaiter.IsCompleted)
			{
			}
			_0023_003DzLleEUYE_003D = awaiter.GetResult();
			OrderIdentification = _0023_003DzLleEUYE_003D.Header.OrderIdentification;
			DrawingIdentification = _0023_003DzLleEUYE_003D.Header.DrawingIdentification;
			PhaseIdentification = _0023_003DzLleEUYE_003D.Header.PhaseIdentification;
			PieceIdentification = _0023_003DzLleEUYE_003D.Header.PieceIdentification;
			SteelQuality = _0023_003DzLleEUYE_003D.Header.SteelQuality;
			QuantityOfPieces = _0023_003DzLleEUYE_003D.Header.QuantityOfPieces;
			Profile = _0023_003DzLleEUYE_003D.Header.Profile;
			ProfileCode = (profileType)_0023_003DzLleEUYE_003D.Header.CodeProfile;
			Length = _0023_003DzLleEUYE_003D.Header.Length;
			SawLength = _0023_003DzLleEUYE_003D.Header.SawLength;
			ProfileHeight = _0023_003DzLleEUYE_003D.Header.ProfileHeight;
			FlangeWidth = _0023_003DzLleEUYE_003D.Header.FlangeWidth;
			WebThickness = _0023_003DzLleEUYE_003D.Header.WebThickness;
			Radius = _0023_003DzLleEUYE_003D.Header.Radius;
			WeightByMeter = _0023_003DzLleEUYE_003D.Header.WeightByMeter;
			PaintingSurfaceByMeter = _0023_003DzLleEUYE_003D.Header.PaintingSurfaceByMeter;
			WebStartCut = _0023_003DzLleEUYE_003D.Header.WebStartCut;
			WebEndCut = _0023_003DzLleEUYE_003D.Header.WebEndCut;
			FlangeStartCut = _0023_003DzLleEUYE_003D.Header.FlangeStartCut;
			FlangeEndCut = _0023_003DzLleEUYE_003D.Header.FlangeEndCut;
			Text1InfoOnPiece = _0023_003DzLleEUYE_003D.Header.Text1InfoOnPiece;
			Text2InfoOnPiece = _0023_003DzLleEUYE_003D.Header.Text2InfoOnPiece;
			Text3InfoOnPiece = _0023_003DzLleEUYE_003D.Header.Text3InfoOnPiece;
			Text4InfoOnPiece = _0023_003DzLleEUYE_003D.Header.Text4InfoOnPiece;
			CompositeCurve compositeCurve = null;
			List<ICurve> list = new List<ICurve>();
			foreach (DstvElement element in _0023_003DzLleEUYE_003D.Elements)
			{
				if (element is Contour contour)
				{
					CompositeCurve compositeCurve2 = _0023_003DzjUuima_KBfFh_8Ax1w_003D_003D(contour.PointList);
					if (contour.Type == ContourType.AK)
					{
						if (compositeCurve != null)
						{
							throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999479));
						}
						compositeCurve = compositeCurve2;
					}
					else if (contour.Type == ContourType.IK)
					{
						list.Add(compositeCurve2);
					}
				}
				else if (element is DstvHole dstvHole)
				{
					double radius = dstvHole.Diameter / 2.0;
					Circle circle = new Circle(dstvHole.XCoord, dstvHole.YCoord, 0.0, radius);
					circle.Reverse();
					list.Add(circle);
				}
			}
			if (compositeCurve == null)
			{
				throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999434));
			}
			List<ICurve> list2 = new List<ICurve>();
			list2.Add(compositeCurve);
			list2.AddRange(list);
			devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(list2, Plane.XY, sortAndOrient: false);
			region.ColorMethod = colorMethodType.byEntity;
			region.Color = Color.LightGray;
			if (AsRegion)
			{
				base.Entities.Add(region);
			}
			else
			{
				Brep brep = region.ExtrudeAsBrep(WebThickness);
				brep.ColorMethod = colorMethodType.byEntity;
				brep.Color = Color.LightGray;
				base.Entities.Add(brep);
			}
			base.Result = true;
		}
		catch (Exception ex)
		{
			log.AppendLine(ex.Message);
			log.AppendLine();
		}
	}

	public string ToSvg()
	{
		if (_0023_003DzLleEUYE_003D != null)
		{
			return _0023_003DzLleEUYE_003D.ToSvg();
		}
		return string.Empty;
	}

	private CompositeCurve _0023_003DzjUuima_KBfFh_8Ax1w_003D_003D(IReadOnlyList<DstvContourPoint> _0023_003DzTyB0NW0_003D)
	{
		List<ICurve> list = new List<ICurve>();
		for (int i = 0; i < _0023_003DzTyB0NW0_003D.Count - 1; i++)
		{
			DstvContourPoint dstvContourPoint = _0023_003DzTyB0NW0_003D[i];
			DstvContourPoint dstvContourPoint2 = _0023_003DzTyB0NW0_003D[i + 1];
			if (dstvContourPoint.XCoord == dstvContourPoint2.XCoord && dstvContourPoint.YCoord == dstvContourPoint2.YCoord)
			{
				continue;
			}
			Point2D point2D = new Point2D(dstvContourPoint.XCoord, dstvContourPoint.YCoord);
			Point2D point2D2 = new Point2D(dstvContourPoint2.XCoord, dstvContourPoint2.YCoord);
			if (dstvContourPoint.Radius == 0.0)
			{
				Line item = new Line(dstvContourPoint.XCoord, dstvContourPoint.YCoord, dstvContourPoint2.XCoord, dstvContourPoint2.YCoord);
				list.Add(item);
				continue;
			}
			Point2D center = ((dstvContourPoint.XCoord == dstvContourPoint2.XCoord || dstvContourPoint.YCoord == dstvContourPoint2.YCoord) ? Point2D.MidPoint(new Point2D(dstvContourPoint.XCoord, dstvContourPoint.YCoord), new Point2D(dstvContourPoint2.XCoord, dstvContourPoint2.YCoord)) : ((dstvContourPoint.XCoord < dstvContourPoint2.XCoord && dstvContourPoint.YCoord < dstvContourPoint2.YCoord) ? ((!(dstvContourPoint.Radius > 0.0)) ? new Point2D(dstvContourPoint2.XCoord, dstvContourPoint.YCoord) : new Point2D(dstvContourPoint.XCoord, dstvContourPoint2.YCoord)) : ((dstvContourPoint.XCoord < dstvContourPoint2.XCoord && dstvContourPoint.YCoord > dstvContourPoint2.YCoord) ? ((!(dstvContourPoint.Radius > 0.0)) ? new Point2D(dstvContourPoint.XCoord, dstvContourPoint2.YCoord) : new Point2D(dstvContourPoint2.XCoord, dstvContourPoint.YCoord)) : ((dstvContourPoint.XCoord > dstvContourPoint2.XCoord && dstvContourPoint.YCoord < dstvContourPoint2.YCoord) ? ((!(dstvContourPoint.Radius > 0.0)) ? new Point2D(dstvContourPoint.XCoord, dstvContourPoint2.YCoord) : new Point2D(dstvContourPoint2.XCoord, dstvContourPoint.YCoord)) : ((!(dstvContourPoint.Radius > 0.0)) ? new Point2D(dstvContourPoint2.XCoord, dstvContourPoint.YCoord) : new Point2D(dstvContourPoint.XCoord, dstvContourPoint2.YCoord))))));
			Arc arc;
			if (dstvContourPoint.Radius > 0.0)
			{
				arc = new Arc(Plane.XY, center, point2D, point2D2);
			}
			else
			{
				arc = new Arc(Plane.XY, center, point2D2, point2D);
				arc.Reverse();
			}
			list.Add(arc);
		}
		return new CompositeCurve(list, 0.0, sortAndOrient: false);
	}
}
