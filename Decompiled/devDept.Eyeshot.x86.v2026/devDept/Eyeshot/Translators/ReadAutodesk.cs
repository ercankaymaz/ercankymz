using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using ODA.Drawings.TD_DbCoreIntegrated;
using ODA.Kernel.TD_BrepBuilderFiller;
using ODA.Kernel.TD_RootIntegrated;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class ReadAutodesk : ReadFileAsyncWithDrawing
{
	private sealed class _0023_003Dz1VSuB38_HHzIGQjEcDMY_AU_003D
	{
		public int[] _0023_003DzYhTOc6EvKBAh;

		public Func<int, int> _0023_003Dz_SFJMhn_bGRe;

		internal int _0023_003Dz2fGQqCES7fiKb2Hfy5vGriU_003D(int _0023_003DzyRnBcBo_003D)
		{
			return _0023_003DzYhTOc6EvKBAh[_0023_003DzyRnBcBo_003D];
		}
	}

	private struct _0023_003Dz8yEBIUw_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Vector3D _0023_003DzqwjRtc4_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Point3D _0023_003Dz_8qkpR8_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Quaternion _0023_003DzAYx9Z5A_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Vector3D _0023_003DzlIUGZKw_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public projectionType _0023_003DzRMsJ77myYf6B;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzGIOjdZFVwcx_0024Ivu3jw_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzUiEKVrs_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public SizeF _0023_003Dza9v8qfWmqzIi;

		public bool _0023_003DznJnOZYQ_003D(Camera _0023_003Dz7q7IXb5RJSRK, Size _0023_003DztM0ty0k_003D)
		{
			if (_0023_003DzqwjRtc4_003D == null)
			{
				return false;
			}
			Vector3D viewNormal = _0023_003Dz7q7IXb5RJSRK.ViewNormal;
			Transformation.AutocadOCS(_0023_003DzqwjRtc4_003D, out var _, out var _);
			Utility.GetRotationAxisAndAngle(viewNormal, _0023_003DzqwjRtc4_003D, out var rotAxis, out var angleInDegrees);
			if (rotAxis != null)
			{
				_0023_003Dz7q7IXb5RJSRK.Rotation = new Quaternion(rotAxis, angleInDegrees) * _0023_003Dz7q7IXb5RJSRK.Rotation;
			}
			_0023_003Dz7q7IXb5RJSRK.Tilt(_0023_003DzlIUGZKw_003D);
			_0023_003Dz7q7IXb5RJSRK.ProjectionMode = _0023_003DzRMsJ77myYf6B;
			if (_0023_003Dz7q7IXb5RJSRK.ProjectionMode == projectionType.Orthographic)
			{
				double val = (float)_0023_003DztM0ty0k_003D.Width / _0023_003Dza9v8qfWmqzIi.Width;
				double val2 = (float)_0023_003DztM0ty0k_003D.Height / _0023_003Dza9v8qfWmqzIi.Height;
				_0023_003Dz7q7IXb5RJSRK.ZoomFactor = Math.Max(val, val2);
			}
			else
			{
				_0023_003Dz7q7IXb5RJSRK.FocalLength = _0023_003DzGIOjdZFVwcx_0024Ivu3jw_003D_003D;
				_0023_003Dz7q7IXb5RJSRK.Distance = _0023_003DzUiEKVrs_003D;
			}
			_0023_003Dz7q7IXb5RJSRK.Target = _0023_003Dz_8qkpR8_003D;
			return true;
		}
	}

	[Serializable]
	private sealed class _0023_003DzE18LVS0_003D
	{
		public static readonly _0023_003DzE18LVS0_003D _0023_003Dz8VglJ9E_003D = new _0023_003DzE18LVS0_003D();

		public static Func<ICurve, double> _0023_003Dzx6USMvoaWaqpB3K0nA_003D_003D;

		public static Predicate<double> _0023_003DzQ25BlhP9tbFcUwDJgA_003D_003D;

		public static Func<int, bool> _0023_003DzolvbVbTbOIBk1u1ymA_003D_003D;

		internal double _0023_003Dzsv64DXxQEDmtzN3FPVNkJiI_003D(ICurve _0023_003DzcYe68Yw_003D)
		{
			return _0023_003DzcYe68Yw_003D.Length();
		}

		internal bool _0023_003DzA1uQBd3VwEvI_P9_00249kYo0NA_003D(double _0023_003DzeJLIX5w_003D)
		{
			return _0023_003DzeJLIX5w_003D == 0.0;
		}

		internal bool _0023_003DzG2yJ04EO1bbUJ0HjFIFXX1hQOknL(int _0023_003DzyRnBcBo_003D)
		{
			return _0023_003DzyRnBcBo_003D != -1;
		}
	}

	private sealed class _0023_003DzN4_0024Qlp5_0024ZGLsgB9DmA_003D_003D : OdDbAuditInfo
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private StringBuilder _0023_003DzWfEJJHg_003D;

		public _0023_003DzN4_0024Qlp5_0024ZGLsgB9DmA_003D_003D(StringBuilder _0023_003DzWfEJJHg_003D)
		{
			this._0023_003DzWfEJJHg_003D = _0023_003DzWfEJJHg_003D;
		}

		public override void printError(string _0023_003DztsD6LMU_003D, string _0023_003Dz_0024n93vrs_003D, string _0023_003DzF_00249vp_0024VH6HRg, string _0023_003DzCtz8aznU8hjr)
		{
			string value = string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355530533), _0023_003DztsD6LMU_003D, _0023_003Dz_0024n93vrs_003D, _0023_003DzF_00249vp_0024VH6HRg, _0023_003DzCtz8aznU8hjr);
			_0023_003DzWfEJJHg_003D.AppendLine(value);
		}

		public override void printInfo(string _0023_003Dz5348aqE_003D)
		{
			_0023_003DzWfEJJHg_003D.AppendLine(_0023_003Dz5348aqE_003D);
		}
	}

	private delegate OdResult _0023_003DzWg_GllqbCaSBVuqy5w_003D_003D(OdRxObjectPtrArray _0023_003DzowwVrrs_003D);

	private sealed class _0023_003DzZ6H8Nz1428SdwkYR9QVZr9w_003D
	{
		public int _0023_003DzcFZaF7l5IFNg;

		public Func<Brep.OrientedEdge, bool> _0023_003Dz_SFJMhn_bGRe;

		internal bool _0023_003Dz9IaAjRPz2DrjstIVZqFkX1k_003D(Brep.OrientedEdge _0023_003DzaG3DPu0_003D)
		{
			return _0023_003DzaG3DPu0_003D.CurveIndex != _0023_003DzcFZaF7l5IFNg;
		}
	}

	internal sealed class _0023_003DzxnSsn_sGLe2l4Q46OzRouPQ_003D
	{
		private OdDbEntity _0023_003DzucnCzB1MUkys;

		private bool _0023_003DzU4TFOec_003D;

		private string _0023_003DzTsaWRwM_003D;

		private LineWeight _0023_003DzS_B3m2W1VUfS;

		private OdCmColor _0023_003DzhS3IjO0_003D;

		private OdCmTransparency _0023_003DzQNd7S9oqTKEejIjGJkVMj4w_003D;

		private string _0023_003DzFgLmCWDyJ0uwdlIuMQ_003D_003D;

		private double _0023_003Dz_SaJA9v6PCBny_o0oQ_003D_003D;

		private string _0023_003Dz4Cp2tFjINgjj7RcMLQ_003D_003D;

		private OdResBuf _0023_003Dzp4mzuP0_003D;

		private string _0023_003DzcclnMvrM7_CPS1nuq7waI4Q_003D;

		public _0023_003DzxnSsn_sGLe2l4Q46OzRouPQ_003D()
		{
		}

		public _0023_003DzxnSsn_sGLe2l4Q46OzRouPQ_003D(OdDbEntity _0023_003DzucnCzB1MUkys)
		{
			this._0023_003DzucnCzB1MUkys = _0023_003DzucnCzB1MUkys;
		}

		public bool _0023_003DzxAeEK06E9wHg()
		{
			if (_0023_003DzucnCzB1MUkys == null)
			{
				return _0023_003DzU4TFOec_003D;
			}
			return _0023_003DzucnCzB1MUkys.visibility() == OdDb_Visibility.kVisible;
		}

		public void _0023_003DzXYcPJRPM35aw(bool _0023_003Dzdc1k2Kc_003D)
		{
			_0023_003DzU4TFOec_003D = _0023_003Dzdc1k2Kc_003D;
		}

		public string _0023_003Dz1CiOgMhN_w8L()
		{
			if (_0023_003DzucnCzB1MUkys == null)
			{
				return _0023_003DzTsaWRwM_003D;
			}
			return _0023_003DzucnCzB1MUkys.layer();
		}

		public void _0023_003DzleNg5Em6YSE_0024(string _0023_003Dzdc1k2Kc_003D)
		{
			_0023_003DzTsaWRwM_003D = _0023_003Dzdc1k2Kc_003D;
		}

		public LineWeight _0023_003DzP91cXDJzQgAq()
		{
			if (_0023_003DzucnCzB1MUkys == null)
			{
				return _0023_003DzS_B3m2W1VUfS;
			}
			return _0023_003DzucnCzB1MUkys.lineWeight();
		}

		public void _0023_003DzzTOtGyPAPXGc(LineWeight _0023_003Dzdc1k2Kc_003D)
		{
			_0023_003DzS_B3m2W1VUfS = _0023_003Dzdc1k2Kc_003D;
		}

		public OdCmColor _0023_003Dz_0024dvPXS0_003D()
		{
			if (_0023_003DzucnCzB1MUkys == null)
			{
				return _0023_003DzhS3IjO0_003D;
			}
			return _0023_003DzucnCzB1MUkys.color();
		}

		public void _0023_003Dz5gF8z7A_003D(OdCmColor _0023_003Dzdc1k2Kc_003D)
		{
			_0023_003DzhS3IjO0_003D = _0023_003Dzdc1k2Kc_003D;
		}

		public OdCmTransparency _0023_003Dzk0q7DRmuI7_7()
		{
			if (_0023_003DzucnCzB1MUkys == null)
			{
				return _0023_003DzQNd7S9oqTKEejIjGJkVMj4w_003D;
			}
			return _0023_003DzucnCzB1MUkys.transparency();
		}

		public void _0023_003DzEVo9nPrbakbF(OdCmTransparency _0023_003Dzdc1k2Kc_003D)
		{
			_0023_003DzQNd7S9oqTKEejIjGJkVMj4w_003D = _0023_003Dzdc1k2Kc_003D;
		}

		public string _0023_003DzinaallCRnjSTfB3CeA_003D_003D()
		{
			if (_0023_003DzucnCzB1MUkys == null)
			{
				return _0023_003DzFgLmCWDyJ0uwdlIuMQ_003D_003D;
			}
			return _0023_003DzucnCzB1MUkys.linetype();
		}

		public void _0023_003DzX9y8Y5w067tE1n4xLQ_003D_003D(string _0023_003Dzdc1k2Kc_003D)
		{
			_0023_003DzFgLmCWDyJ0uwdlIuMQ_003D_003D = _0023_003Dzdc1k2Kc_003D;
		}

		public double _0023_003Dz2QeL7AVgUMLR4fA2YyzdfIM_003D()
		{
			if (_0023_003DzucnCzB1MUkys == null)
			{
				return _0023_003Dz_SaJA9v6PCBny_o0oQ_003D_003D;
			}
			return _0023_003DzucnCzB1MUkys.linetypeScale();
		}

		public void _0023_003Dz0N7ifmvxkEoNnjBfDIuju_0024g_003D(double _0023_003Dzdc1k2Kc_003D)
		{
			_0023_003Dz_SaJA9v6PCBny_o0oQ_003D_003D = _0023_003Dzdc1k2Kc_003D;
		}

		public string _0023_003DzaV2RyyH8SWiU()
		{
			if (_0023_003DzucnCzB1MUkys == null)
			{
				return _0023_003Dz4Cp2tFjINgjj7RcMLQ_003D_003D;
			}
			return _0023_003DzucnCzB1MUkys.material();
		}

		public void _0023_003DzmbWnSz8zoNub(string _0023_003Dzdc1k2Kc_003D)
		{
			_0023_003Dz4Cp2tFjINgjj7RcMLQ_003D_003D = _0023_003Dzdc1k2Kc_003D;
		}

		public OdResBuf _0023_003Dz88LgRmrB_kny()
		{
			if (_0023_003DzucnCzB1MUkys == null)
			{
				return _0023_003Dzp4mzuP0_003D;
			}
			return _0023_003DzucnCzB1MUkys.xData(string.Empty);
		}

		public void _0023_003DzEeqPm0i0GlUJ(OdResBuf _0023_003Dzdc1k2Kc_003D)
		{
			_0023_003Dzp4mzuP0_003D = _0023_003Dzdc1k2Kc_003D;
		}

		public string _0023_003Dzlhs_0024msE8QJhg()
		{
			if (_0023_003DzucnCzB1MUkys == null || !(_0023_003DzucnCzB1MUkys is OdDbDimension))
			{
				return _0023_003DzcclnMvrM7_CPS1nuq7waI4Q_003D;
			}
			return ((OdDbDimension)_0023_003DzucnCzB1MUkys).dimensionText();
		}

		public void _0023_003DzfD1ryVQudP0q(string _0023_003Dzdc1k2Kc_003D)
		{
			_0023_003DzcclnMvrM7_CPS1nuq7waI4Q_003D = _0023_003Dzdc1k2Kc_003D;
		}

		public OdResBuf _0023_003Dz6mhCO5QZ3ueJ(string _0023_003DzhOsgi_0024Q_003D)
		{
			if (_0023_003DzucnCzB1MUkys == null)
			{
				return _0023_003Dzp4mzuP0_003D;
			}
			return _0023_003DzucnCzB1MUkys.xData(_0023_003DzhOsgi_0024Q_003D);
		}
	}

	public class ReadEntityData
	{
		public string xrefPrefix;

		public Dictionary<string, string> duplicatedBlockNamesConversionTable;

		public Layer testLayer;

		public BlockKeyedCollection importedBlocks;

		public bool skipProxies;

		public bool skipOleObjects;

		public Block currentBlock;

		public TextStyleKeyedCollection importedTextStyles;

		public LineTypeKeyedCollection importedLinetypes;

		public OdDbDatabase database;

		public Sheet sheet;

		public double layoutPlotScale;

		public OdDbObjectId overallVportId;

		[Obsolete("Use the constructor that accepts the hatchImportMode instead.")]
		public ReadEntityData(string xrefPrefix, Dictionary<string, string> duplicatedBlockNamesConversionTable, Layer testLayer, BlockKeyedCollection importedBlocks, bool skipProxies, bool skipOleObjects, Block currentBlock, TextStyleKeyedCollection importedTextStyles, LineTypeKeyedCollection importedLineTypes)
		{
			this.xrefPrefix = xrefPrefix;
			this.duplicatedBlockNamesConversionTable = duplicatedBlockNamesConversionTable;
			importedLinetypes = importedLineTypes;
			this.testLayer = testLayer;
			this.importedBlocks = importedBlocks;
			this.skipProxies = skipProxies;
			this.skipOleObjects = skipOleObjects;
			this.currentBlock = currentBlock;
			this.importedTextStyles = importedTextStyles;
		}

		public ReadEntityData(string xrefPrefix, Dictionary<string, string> duplicatedBlockNamesConversionTable, Layer testLayer, BlockKeyedCollection importedBlocks, bool skipProxies, bool skipOleObjects, Block currentBlock, TextStyleKeyedCollection importedTextStyles, LineTypeKeyedCollection importedLineTypes, OdDbDatabase database)
		{
			this.xrefPrefix = xrefPrefix;
			this.duplicatedBlockNamesConversionTable = duplicatedBlockNamesConversionTable;
			importedLinetypes = importedLineTypes;
			this.testLayer = testLayer;
			this.importedBlocks = importedBlocks;
			this.skipProxies = skipProxies;
			this.skipOleObjects = skipOleObjects;
			this.currentBlock = currentBlock;
			this.importedTextStyles = importedTextStyles;
			this.database = database;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BlockReference[] _0023_003DzBPfEftAqO5aB;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point3D _0023_003DzLRp3iWk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point3D _0023_003DzX347P_0024c_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point2D _0023_003DzumuYfS9OxfP_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point2D _0023_003DzbP_0say6lVhp;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz6UYioyW4TUAn;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<string> _0023_003DzkST_ckyNT91GYYgzDhUbTa4_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzekooAc_0024gVnrxj8yy9Q_003D_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzcBROoktcgCNFioS7Zzkiz_0024E_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzpfUJ5EuNpETIHbtAVWqOLFg_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzIxOUab6EkpjKfDx_tSD7ua8ouhH9 = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzdYB9aTgianRoqIrJVJfQbrs_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dzi6OJtJ61N1XdzHT4v2asKNM_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzeX95G209RWwrGYMYtQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzCGlwdRrPyP6i = Color.White;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzQq8jJXDX1T8PMw79RFvVz_c_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<KeyValuePair<short, object>> _0023_003Dzk0Abw9AKbx_0024AKtVVsA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal autodeskVersionType _0023_003DzbX1f48x0MIYi;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Dictionary<string, Transformation> _0023_003DzWAYJkgumeFe34ZOp7NtTXY6DBcB898_0024tLL0m_0024oU_003D = new Dictionary<string, Transformation>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private attributeReferenceVisibilityType _0023_003Dz_LB3At_zzMT0HzTTkof9Ctw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<string> _0023_003Dzy8c7eEQSoRod;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private StreamWriter _0023_003DzNmFg3E4ZSEJ_0024;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point3D _0023_003Dz2GXSdJMqeBe7 = Point3D.Origin;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003Dz8yEBIUw_003D _0023_003DzQSyYVcquy00G;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dzxx2uNQo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<string> _0023_003DzcFaBK746xkKQ = new List<string>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<string> _0023_003DzXJFc_00242a3weYa;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static double _0023_003DzR4ocvc6x1MsH = 100000000000000.0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DztF62MAlgyKUA9UNRPP8gab3t6Fsu;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzuaLf3yNthtAeJvnk0GJ7Oj3Cx7r8Ul_0024W_0024Q_003D_003D;

	public override supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.All;

	public List<string> LayersToLoad
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzkST_ckyNT91GYYgzDhUbTa4_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzkST_ckyNT91GYYgzDhUbTa4_003D = value;
		}
	}

	public bool Simplify
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzekooAc_0024gVnrxj8yy9Q_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzekooAc_0024gVnrxj8yy9Q_003D_003D = value;
		}
	}

	public bool SkipLayouts
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzcBROoktcgCNFioS7Zzkiz_0024E_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzcBROoktcgCNFioS7Zzkiz_0024E_003D = value;
		}
	}

	public bool SkipOleObjects
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzpfUJ5EuNpETIHbtAVWqOLFg_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzpfUJ5EuNpETIHbtAVWqOLFg_003D = value;
		}
	}

	public bool ExtrudeByThickness
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzIxOUab6EkpjKfDx_tSD7ua8ouhH9;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzIxOUab6EkpjKfDx_tSD7ua8ouhH9 = value;
		}
	}

	public bool SkipProxies
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzdYB9aTgianRoqIrJVJfQbrs_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzdYB9aTgianRoqIrJVJfQbrs_003D = value;
		}
	}

	public bool FixErrors
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzi6OJtJ61N1XdzHT4v2asKNM_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzi6OJtJ61N1XdzHT4v2asKNM_003D = value;
		}
	}

	public string Password
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzeX95G209RWwrGYMYtQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzeX95G209RWwrGYMYtQ_003D_003D = value;
		}
	}

	public Color ForegroundColor
	{
		get
		{
			return _0023_003DzCGlwdRrPyP6i;
		}
		set
		{
			if (value.ToArgb() != Color.White.ToArgb() && value.ToArgb() != Color.Black.ToArgb())
			{
				throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526864));
			}
			_0023_003DzCGlwdRrPyP6i = value;
		}
	}

	public bool SkipExternalReferences
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzQq8jJXDX1T8PMw79RFvVz_c_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzQq8jJXDX1T8PMw79RFvVz_c_003D = value;
		}
	}

	public List<KeyValuePair<short, object>> ModelXData
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzk0Abw9AKbx_0024AKtVVsA_003D_003D;
		}
	}

	public autodeskVersionType OriginalFileVersion => _0023_003DzbX1f48x0MIYi;

	public BlockReference[] FailedToLoad => _0023_003DzBPfEftAqO5aB;

	public Point3D Min => _0023_003DzLRp3iWk_003D;

	public Point3D Max => _0023_003DzX347P_0024c_003D;

	public Point2D MinLimit => _0023_003DzumuYfS9OxfP_;

	public Point2D MaxLimit => _0023_003DzbP_0say6lVhp;

	public bool CheckLimit => _0023_003Dz6UYioyW4TUAn;

	public Dictionary<string, Transformation> PlotTransformations
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzWAYJkgumeFe34ZOp7NtTXY6DBcB898_0024tLL0m_0024oU_003D;
		}
	}

	protected virtual bool buildDefaultDrawing => false;

	protected virtual bool noDocument => false;

	public attributeReferenceVisibilityType AttributeReferenceVisibilityMode
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz_LB3At_zzMT0HzTTkof9Ctw_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz_LB3At_zzMT0HzTTkof9Ctw_003D = value;
		}
	}

	public Point3D BasePoint => _0023_003Dz2GXSdJMqeBe7;

	public List<string> SearchFolders => _0023_003DzcFaBK746xkKQ;

	public bool ExplodeDimensions
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DztF62MAlgyKUA9UNRPP8gab3t6Fsu;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DztF62MAlgyKUA9UNRPP8gab3t6Fsu = value;
		}
	}

	public bool ExplodeHatches
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzuaLf3yNthtAeJvnk0GJ7Oj3Cx7r8Ul_0024W_0024Q_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzuaLf3yNthtAeJvnk0GJ7Oj3Cx7r8Ul_0024W_0024Q_003D_003D = value;
		}
	}

	public ReadAutodesk(string filePath, string password = null, bool fixErrors = false, bool skipProxies = true)
		: base(filePath)
	{
		SkipProxies = skipProxies;
		_0023_003Dz4J_0024DYXY_003D(password, fixErrors);
		_0023_003DzXJFc_00242a3weYa.Add(System.IO.Path.GetFileName(filePath));
	}

	public ReadAutodesk(Stream stream, string password = null, bool fixErrors = false, bool skipProxies = true)
		: base(stream)
	{
		SkipProxies = skipProxies;
		_0023_003Dz4J_0024DYXY_003D(password, fixErrors);
	}

	private void _0023_003DzgQ5QMXN_0024CasJ(List<KeyValuePair<short, object>> _0023_003Dzdc1k2Kc_003D)
	{
		_0023_003Dzk0Abw9AKbx_0024AKtVVsA_003D_003D = _0023_003Dzdc1k2Kc_003D;
	}

	private void _0023_003Dz4J_0024DYXY_003D(string _0023_003Dz1wCue9hQz1OC, bool _0023_003Dzw_bSHlSeqJi7)
	{
		Password = _0023_003Dz1wCue9hQz1OC;
		FixErrors = _0023_003Dzw_bSHlSeqJi7;
		_0023_003DzXJFc_00242a3weYa = new List<string>();
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003Dz59lijRsT8LI_0024XHJOQ_0024AIGNJAuo4Gno8YZbyXhC6NbIN90_6Sbg_003D_003D._0023_003DzdzZLZbiwVTg1a0D6OXj_pZ7Vxsm1I1oH6u_0024_fyl4AGtqqQqxXQ_003D_003D()._0023_003DzcuxJrsHQF_Rj5c_67u2AJCIjdCLa(_0023_003Dz59lijRsT8LI_0024XHJOQ_0024AIGNJAuo4Gno8YZbyXhC6NbIN90_6Sbg_003D_003D._0023_003Dz9h7prLD836B0_0024F42nFw7qcyRyorkXYYKZ0vX9bIws0q0ILDt6g_003D_003D(), "p&4miq\"adM", array);
		_0023_003Dzxx2uNQo_003D = false;
		_0023_003DzGl6yLvQ_003D(base.Stream, out var _0023_003DzEHxwjvyQNA, out var _0023_003DziUdFLu7DM8yM, out _0023_003DzBPfEftAqO5aB, out _0023_003DzLRp3iWk_003D, out _0023_003DzX347P_0024c_003D, out _0023_003DzumuYfS9OxfP_, out _0023_003DzbP_0say6lVhp, out _0023_003Dz6UYioyW4TUAn, progress, ct);
		base.Units = _0023_003DziUdFLu7DM8yM;
		if (_0023_003DzEHxwjvyQNA != null)
		{
			base.Entities.AddRange(_0023_003DzEHxwjvyQNA);
		}
	}

	public override void ImportSettings(Document document)
	{
		document.AttributeReferenceVisibilityMode = AttributeReferenceVisibilityMode;
		if (base.HatchPatterns != null)
		{
			document.HatchPatterns.Measurement = base.HatchPatterns.Measurement;
		}
		base.ImportSettings(document);
	}

	internal static void _0023_003Dz5xnwH__0024EKwyi<T>(EyeshotKeyedCollection<T> _0023_003DzOgOpSZg_003D, EyeshotKeyedCollection<T> _0023_003Dz_thW_p0_003D) where T : IKeyedCollectionItem<T>
	{
		if (_0023_003DzOgOpSZg_003D == null)
		{
			return;
		}
		foreach (T item in _0023_003DzOgOpSZg_003D)
		{
			if (!_0023_003Dz_thW_p0_003D.Contains(item.GetKey()))
			{
				_0023_003Dz_thW_p0_003D.Add(item);
			}
		}
	}

	private void _0023_003DzGl6yLvQ_003D(Stream _0023_003DzFjm4l2xeIERx, out Entity[] _0023_003DzEHxwjvyQNA39, out linearUnitsType _0023_003DziUdFLu7DM8yM, out BlockReference[] _0023_003DzLytbDApFrGRv, out Point3D _0023_003DzyHsnlWIJMfQY, out Point3D _0023_003DzGzGDbQK7gG2H, out Point2D _0023_003Dzl30fPoKrRg7J, out Point2D _0023_003DzbDPeJXcCFu7n, out bool _0023_003DzAkdKkjuQJu0t, IProgress<ProgressChangedEventArgs> _0023_003DzIzeJ4Qs_003D, CancellationToken _0023_003Dz_0024cU8x9g_003D)
	{
		MemoryTransaction memoryTransaction = MemoryManager.GetMemoryManager().StartTransaction();
		_0023_003DzEHxwjvyQNA39 = null;
		_0023_003DzyHsnlWIJMfQY = Point3D.MaxValue;
		_0023_003DzGzGDbQK7gG2H = Point3D.MinValue;
		base.Result = false;
		_0023_003Dzl30fPoKrRg7J = null;
		_0023_003DzbDPeJXcCFu7n = null;
		_0023_003DzAkdKkjuQJu0t = false;
		try
		{
			_0023_003DzOVeHqZZ1dKaNw3eSn8krhVk_003D _0023_003DzOVeHqZZ1dKaNw3eSn8krhVk_003D2 = new _0023_003DzOVeHqZZ1dKaNw3eSn8krhVk_003D();
			try
			{
				StartContinuousAnimation(base.ReadingText, _0023_003DzIzeJ4Qs_003D);
				Autodesk.InitializeServices();
				TD_RootIntegrated_Globals.odrxDynamicLinker().loadModule(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355530508));
				if (!SkipOleObjects)
				{
					TD_RootIntegrated_Globals.odrxDynamicLinker().loadModule(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355530523));
				}
				ExHostAppServices exHostAppServices = new ExHostAppServices();
				memoryTransaction.AddObject(exHostAppServices);
				exHostAppServices.disableOutput(disable: true);
				if (string.IsNullOrEmpty(Password))
				{
					Password = string.Empty;
				}
				if (_0023_003DzJa3j1wQ3AeK7(exHostAppServices, _0023_003DzFjm4l2xeIERx, out _0023_003DziUdFLu7DM8yM, out _0023_003DzEHxwjvyQNA39, out _0023_003DzLytbDApFrGRv, ref _0023_003DzyHsnlWIJMfQY, ref _0023_003DzGzGDbQK7gG2H, ref _0023_003Dzl30fPoKrRg7J, ref _0023_003DzbDPeJXcCFu7n, ref _0023_003DzAkdKkjuQJu0t, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D))
				{
					base.Result = true;
				}
			}
			finally
			{
				((IDisposable)_0023_003DzOVeHqZZ1dKaNw3eSn8krhVk_003D2).Dispose();
			}
		}
		catch (Exception ex)
		{
			_0023_003DzLytbDApFrGRv = new BlockReference[0];
			_0023_003DziUdFLu7DM8yM = linearUnitsType.Unitless;
			base.Result = false;
			log.AppendLine(ex.Message);
			log.AppendLine();
		}
		finally
		{
			MemoryManager.GetMemoryManager().StopTransaction(memoryTransaction);
			CloseStream();
			StopContinuousAnimation(_0023_003DzIzeJ4Qs_003D);
		}
	}

	internal virtual bool _0023_003DzJa3j1wQ3AeK7(ExHostAppServices _0023_003DzkiD5er_7LNMn, Stream _0023_003DzFjm4l2xeIERx, out linearUnitsType _0023_003DziUdFLu7DM8yM, out Entity[] _0023_003DzEHxwjvyQNA39, out BlockReference[] _0023_003DzLytbDApFrGRv, ref Point3D _0023_003DzyHsnlWIJMfQY, ref Point3D _0023_003DzGzGDbQK7gG2H, ref Point2D _0023_003Dzl30fPoKrRg7J, ref Point2D _0023_003DzbDPeJXcCFu7n, ref bool _0023_003DzAkdKkjuQJu0t, IProgress<ProgressChangedEventArgs> _0023_003DzIzeJ4Qs_003D, CancellationToken _0023_003Dz_0024cU8x9g_003D)
	{
		MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
		OdMemoryStream odMemoryStream = OdMemoryStream.createNew();
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003Dz_0024Ri82GA5O_VX(_0023_003DzFjm4l2xeIERx, odMemoryStream);
		OdDbDatabase odDbDatabase;
		if (FixErrors)
		{
			_0023_003DzN4_0024Qlp5_0024ZGLsgB9DmA_003D_003D pAuditInfo = new _0023_003DzN4_0024Qlp5_0024ZGLsgB9DmA_003D_003D(log);
			odDbDatabase = _0023_003DzkiD5er_7LNMn.recoverFile(odMemoryStream, pAuditInfo, Password);
		}
		else
		{
			odDbDatabase = _0023_003DzkiD5er_7LNMn.readFile(odMemoryStream, allowCPConversion: false, partialLoad: false, Password);
		}
		if (!_0023_003DzJa3j1wQ3AeK7(out _0023_003DzEHxwjvyQNA39, out _0023_003DzLytbDApFrGRv, ref _0023_003DzyHsnlWIJMfQY, ref _0023_003DzGzGDbQK7gG2H, ref _0023_003Dzl30fPoKrRg7J, ref _0023_003DzbDPeJXcCFu7n, ref _0023_003DzAkdKkjuQJu0t, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D, odDbDatabase))
		{
			_0023_003DziUdFLu7DM8yM = linearUnitsType.Unitless;
			return false;
		}
		_0023_003DzbX1f48x0MIYi = WriteAutodesk._0023_003DzILmOAAaXA_EU8Ikxh34yB6I_003D(odDbDatabase.originalFileVersion());
		if (_0023_003DzbX1f48x0MIYi == autodeskVersionType.Release12 || _0023_003DzbX1f48x0MIYi == autodeskVersionType.Release13 || _0023_003DzbX1f48x0MIYi == autodeskVersionType.Release14)
		{
			_0023_003DziUdFLu7DM8yM = linearUnitsType.Unitless;
		}
		else
		{
			_0023_003DziUdFLu7DM8yM = WriteDatabase._0023_003DzCpSZHkwMYNQHhZOwlA_003D_003D(odDbDatabase.getINSUNITS());
		}
		MemoryManager.GetMemoryManager().StopTransaction(value);
		return true;
	}

	internal bool _0023_003DzJa3j1wQ3AeK7(out Entity[] _0023_003DzEHxwjvyQNA39, out BlockReference[] _0023_003DzLytbDApFrGRv, ref Point3D _0023_003DzLRp3iWk_003D, ref Point3D _0023_003DzX347P_0024c_003D, ref Point2D _0023_003Dzl30fPoKrRg7J, ref Point2D _0023_003DzbDPeJXcCFu7n, ref bool _0023_003DzAkdKkjuQJu0t, IProgress<ProgressChangedEventArgs> _0023_003DzIzeJ4Qs_003D, CancellationToken _0023_003Dz_0024cU8x9g_003D, OdDbDatabase _0023_003DzR8GRspk_003D)
	{
		OdGePoint2d lIMMIN = _0023_003DzR8GRspk_003D.getLIMMIN();
		OdGePoint2d lIMMAX = _0023_003DzR8GRspk_003D.getLIMMAX();
		_0023_003Dzl30fPoKrRg7J = new Point2D(lIMMIN.x, lIMMIN.y);
		_0023_003DzbDPeJXcCFu7n = new Point2D(lIMMAX.x, lIMMAX.y);
		_0023_003DzAkdKkjuQJu0t = _0023_003DzR8GRspk_003D.getLIMCHECK();
		_0023_003DzEHxwjvyQNA39 = null;
		base.HatchPatterns = new HatchPatternKeyedCollection();
		Dictionary<string, string> _0023_003DzxVStmqc0kqZj = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
		Dictionary<string, string> _0023_003DzXjg1oKDenjnEUZagAx9QPGzPH_0024iX = new Dictionary<string, string>();
		BlockKeyedCollection _0023_003DzsNshVQ1ppgcE;
		TextStyleKeyedCollection _0023_003Dz0HOOXWcqzDy;
		LineTypeKeyedCollection _0023_003Dz8aC_00248_e9phd;
		float _0023_003DzH_5xWVG67Bgs;
		List<Entity> list = _0023_003DzO0pDWDs_003D(null, _0023_003DzXjg1oKDenjnEUZagAx9QPGzPH_0024iX, _0023_003DzR8GRspk_003D, _0023_003DzxVStmqc0kqZj, out _0023_003DzsNshVQ1ppgcE, out _0023_003Dz0HOOXWcqzDy, out _0023_003Dz8aC_00248_e9phd, out _0023_003DzH_5xWVG67Bgs, out _0023_003DzLRp3iWk_003D, out _0023_003DzX347P_0024c_003D, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D);
		base.TextStyles = _0023_003Dz0HOOXWcqzDy;
		base.LineTypes = _0023_003Dz8aC_00248_e9phd;
		base.LineTypeScale = _0023_003DzH_5xWVG67Bgs;
		if (_0023_003Dzxx2uNQo_003D)
		{
			_0023_003DzLytbDApFrGRv = null;
			return false;
		}
		AttributeReferenceVisibilityMode = _0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003Dz9mZVFGzYrhJhKBqejt_VXZI6XVrfRahCFA_003D_003D(_0023_003DzR8GRspk_003D.getATTMODE());
		base.HatchPatterns.Measurement = ((_0023_003DzR8GRspk_003D.getMEASUREMENT() != MeasurementValue.kEnglish) ? HatchPatternKeyedCollection.measurementType.Metric : HatchPatternKeyedCollection.measurementType.Imperial);
		if (base.DrawingHatchPatterns != null)
		{
			base.DrawingHatchPatterns.Measurement = base.HatchPatterns.Measurement;
		}
		_0023_003DzXAEydxMw3LhHEXHKxQ_003D_003D(_0023_003DzxVStmqc0kqZj, _0023_003DzsNshVQ1ppgcE, base.DrawingSheets, list, out var _0023_003Dziiyqzz5rUNznJr4Afw_003D_003D, out var _0023_003DzI6eih45hqiVJ);
		_0023_003DzAR8xzTw6Hvck(list, _0023_003DzsNshVQ1ppgcE);
		if (!SkipLayouts)
		{
			foreach (Sheet drawingSheet in base.DrawingSheets)
			{
				_0023_003DzAR8xzTw6Hvck(drawingSheet.Entities, _0023_003DzsNshVQ1ppgcE);
			}
		}
		foreach (Block item in _0023_003DzsNshVQ1ppgcE)
		{
			_0023_003DzAR8xzTw6Hvck(item.Entities, _0023_003DzsNshVQ1ppgcE);
		}
		_0023_003DzEHxwjvyQNA39 = list.ToArray();
		_0023_003DzLytbDApFrGRv = _0023_003Dziiyqzz5rUNznJr4Afw_003D_003D.ToArray();
		foreach (Block item2 in _0023_003DzsNshVQ1ppgcE)
		{
			if (!base.Blocks.Contains(item2.Name) && (item2.BlockSource != autodeskSourceType.Anonymous || _0023_003DzI6eih45hqiVJ.Contains(item2.Name)))
			{
				base.Blocks.Add(item2);
			}
		}
		return true;
	}

	private void _0023_003DzAR8xzTw6Hvck(IList<Entity> _0023_003DzLpVMKc8_003D, BlockKeyedCollection _0023_003DziXS7DNI_003D)
	{
		foreach (Entity item in _0023_003DzLpVMKc8_003D)
		{
			if (!(item is BlockReference))
			{
				continue;
			}
			BlockReference blockReference = (BlockReference)item;
			if (blockReference.Attributes.Count <= 0)
			{
				continue;
			}
			Transformation transformation = (Transformation)blockReference.GetFullTransformation(_0023_003DziXS7DNI_003D).Clone();
			transformation.Invert();
			foreach (KeyValuePair<string, AttributeReference> attribute in blockReference.Attributes)
			{
				Plane plane = attribute.Value.Plane;
				attribute.Value.Plane = new Plane(transformation * plane.Origin, transformation * plane.AxisX, transformation * plane.AxisY);
			}
		}
	}

	internal static string _0023_003Dzli9Jb73zdkV_0024nQKoAg_003D_003D(object _0023_003Dz_dt6cCI_003D, int _0023_003DzYyzOO6N5bbih)
	{
		StackTrace stackTrace = new StackTrace();
		return _0023_003Dz_dt6cCI_003D.GetType()?.ToString() + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526571) + stackTrace.GetFrame(_0023_003DzYyzOO6N5bbih).GetMethod().Name + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355530592);
	}

	internal static string _0023_003DzjNg2FLLUzkz4Uza9SvfS_0024Sc_003D(object _0023_003Dz_dt6cCI_003D)
	{
		return _0023_003Dz_dt6cCI_003D.GetType()?.ToString() + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355530691);
	}

	private void _0023_003DzXAEydxMw3LhHEXHKxQ_003D_003D(Dictionary<string, string> _0023_003DzxVStmqc0kqZj, BlockKeyedCollection _0023_003DziXS7DNI_003D, SheetKeyedCollection _0023_003DzoOEcg_9ppNWM, IList<Entity> _0023_003DzpkkMl6rw3_uQ, out List<BlockReference> _0023_003Dziiyqzz5rUNznJr4Afw_003D_003D, out HashSet<string> _0023_003DzI6eih45hqiVJ)
	{
		_0023_003Dziiyqzz5rUNznJr4Afw_003D_003D = new List<BlockReference>();
		_0023_003DzI6eih45hqiVJ = new HashSet<string>();
		foreach (Block item in _0023_003DziXS7DNI_003D)
		{
			_0023_003DzXAEydxMw3LhHEXHKxQ_003D_003D(_0023_003DzxVStmqc0kqZj, _0023_003DziXS7DNI_003D, item.Entities, _0023_003Dziiyqzz5rUNznJr4Afw_003D_003D, _0023_003DzI6eih45hqiVJ);
		}
		if (!SkipLayouts)
		{
			foreach (Sheet item2 in _0023_003DzoOEcg_9ppNWM)
			{
				_0023_003DzXAEydxMw3LhHEXHKxQ_003D_003D(_0023_003DzxVStmqc0kqZj, _0023_003DziXS7DNI_003D, item2.Entities, _0023_003Dziiyqzz5rUNznJr4Afw_003D_003D, _0023_003DzI6eih45hqiVJ);
			}
		}
		_0023_003DzXAEydxMw3LhHEXHKxQ_003D_003D(_0023_003DzxVStmqc0kqZj, _0023_003DziXS7DNI_003D, _0023_003DzpkkMl6rw3_uQ, _0023_003Dziiyqzz5rUNznJr4Afw_003D_003D, _0023_003DzI6eih45hqiVJ);
	}

	private void _0023_003DzXAEydxMw3LhHEXHKxQ_003D_003D(Dictionary<string, string> _0023_003DzxVStmqc0kqZj, BlockKeyedCollection _0023_003DziXS7DNI_003D, IList<Entity> _0023_003DzpkkMl6rw3_uQ, List<BlockReference> _0023_003Dziiyqzz5rUNznJr4Afw_003D_003D, HashSet<string> _0023_003DzI6eih45hqiVJ)
	{
		for (int i = 0; i < _0023_003DzpkkMl6rw3_uQ.Count; i++)
		{
			if (_0023_003DzpkkMl6rw3_uQ[i] is View || !(_0023_003DzpkkMl6rw3_uQ[i] is BlockReference blockReference))
			{
				continue;
			}
			bool flag = _0023_003DzxVStmqc0kqZj.ContainsKey(blockReference.BlockName);
			if (flag || !_0023_003DziXS7DNI_003D.Contains(blockReference.BlockName))
			{
				if (flag)
				{
					blockReference.EntityData = _0023_003DzxVStmqc0kqZj[blockReference.BlockName];
				}
				_0023_003Dziiyqzz5rUNznJr4Afw_003D_003D.Add(blockReference);
				_0023_003DzpkkMl6rw3_uQ.RemoveAt(i);
				i--;
			}
			else
			{
				_0023_003DzI6eih45hqiVJ.Add(blockReference.BlockName);
			}
		}
	}

	[Conditional("PRINT_AUTODESK")]
	private void _0023_003Dz3JiMSCI_003D(string _0023_003DzKyPCKaY_003D)
	{
		_0023_003DzNmFg3E4ZSEJ_0024.WriteLine(_0023_003DzKyPCKaY_003D);
	}

	[Conditional("PRINT_AUTODESK")]
	private void _0023_003DzHU7DvQfFKQV8()
	{
		_0023_003DzNmFg3E4ZSEJ_0024 = new StreamWriter(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355530404));
	}

	[Conditional("PRINT_AUTODESK")]
	private void _0023_003DzkwaMph_210M2()
	{
		_0023_003DzNmFg3E4ZSEJ_0024.Close();
	}

	internal void _0023_003Dz6Ean6jyDKTRL(Point3D _0023_003Dzdc1k2Kc_003D)
	{
		_0023_003Dz2GXSdJMqeBe7 = _0023_003Dzdc1k2Kc_003D;
	}

	private List<Entity> _0023_003DzO0pDWDs_003D(string _0023_003DziFKy3_Jdw399, Dictionary<string, string> _0023_003DzXjg1oKDenjnEUZagAx9QPGzPH_0024iX, OdDbDatabase _0023_003Dzd2hFvl0_003D, Dictionary<string, string> _0023_003DzxVStmqc0kqZj, out BlockKeyedCollection _0023_003DzsNshVQ1ppgcE, out TextStyleKeyedCollection _0023_003Dz0HOOXWcqzDy7, out LineTypeKeyedCollection _0023_003Dz8aC_00248_e9phd4, out float _0023_003DzH_5xWVG67Bgs, out Point3D _0023_003DzLRp3iWk_003D, out Point3D _0023_003DzX347P_0024c_003D, IProgress<ProgressChangedEventArgs> _0023_003DzIzeJ4Qs_003D, CancellationToken _0023_003Dz_0024cU8x9g_003D)
	{
		MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
		_0023_003Dz0HOOXWcqzDy7 = new TextStyleKeyedCollection();
		_0023_003DzsNshVQ1ppgcE = new BlockKeyedCollection();
		if (string.IsNullOrEmpty(_0023_003DziFKy3_Jdw399))
		{
			_0023_003DziFKy3_Jdw399 = string.Empty;
			OdGePoint3d iNSBASE = _0023_003Dzd2hFvl0_003D.getINSBASE();
			_0023_003Dz6Ean6jyDKTRL(new Point3D(iNSBASE.x, iNSBASE.y, iNSBASE.z));
		}
		_0023_003DzLRp3iWk_003D = Point3D.MaxValue;
		_0023_003DzX347P_0024c_003D = Point3D.MinValue;
		_0023_003DzH_5xWVG67Bgs = (float)_0023_003Dzd2hFvl0_003D.getLTSCALE();
		bool flag = !string.IsNullOrEmpty(_0023_003DziFKy3_Jdw399);
		string _0023_003Dz0EA0NeSD2dKB = string.Empty;
		if (flag)
		{
			_0023_003Dz0EA0NeSD2dKB = _0023_003DziFKy3_Jdw399.Substring(0, _0023_003DziFKy3_Jdw399.Length - 1);
		}
		_0023_003Dzag5jBBQCKrgNUHKN0g_003D_003D(_0023_003Dzd2hFvl0_003D);
		_0023_003Dzd_0024tFz6cjDALc(_0023_003Dzd2hFvl0_003D, _0023_003Dz0EA0NeSD2dKB, out _0023_003Dz8aC_00248_e9phd4);
		_0023_003DzC2R_0024LIo_003D(_0023_003Dzd2hFvl0_003D, flag, _0023_003DziFKy3_Jdw399, _0023_003Dz0EA0NeSD2dKB, _0023_003Dz8aC_00248_e9phd4);
		_0023_003Dz9lIQlEle8Csl(_0023_003Dzd2hFvl0_003D, out _0023_003Dz0HOOXWcqzDy7, _0023_003Dz0EA0NeSD2dKB);
		List<Entity> list = new List<Entity>();
		_0023_003DzsNshVQ1ppgcE = new BlockKeyedCollection(StringComparer.CurrentCultureIgnoreCase);
		ReadEntityData _0023_003DzbONi0CI_003D = new ReadEntityData(_0023_003DziFKy3_Jdw399, _0023_003DzXjg1oKDenjnEUZagAx9QPGzPH_0024iX, new Layer(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355530418)), _0023_003DzsNshVQ1ppgcE, SkipProxies, SkipOleObjects, null, _0023_003Dz0HOOXWcqzDy7, _0023_003Dz8aC_00248_e9phd4, _0023_003Dzd2hFvl0_003D);
		StopContinuousAnimation(_0023_003DzIzeJ4Qs_003D);
		_0023_003DzwzgrlVKnBi9t(_0023_003Dzd2hFvl0_003D, _0023_003DzbONi0CI_003D, _0023_003DzxVStmqc0kqZj, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D);
		if (!flag)
		{
			_0023_003DzALUk8WmyJR_4(_0023_003Dzd2hFvl0_003D);
		}
		OdDbViewportTable obj = (OdDbViewportTable)_0023_003Dzd2hFvl0_003D.getViewportTableId().openObject(OdDb_OpenMode.kForRead);
		int num = 0;
		OdDbSymbolTableIterator odDbSymbolTableIterator = obj.newIterator();
		odDbSymbolTableIterator.start();
		while (!odDbSymbolTableIterator.done())
		{
			num++;
			odDbSymbolTableIterator.step();
		}
		if (num > 1)
		{
			log.AppendLine(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355530377));
		}
		if (_0023_003Dzxx2uNQo_003D)
		{
			list = null;
		}
		else
		{
			OdDbBlockTableRecord odDbBlockTableRecord = (OdDbBlockTableRecord)_0023_003Dzd2hFvl0_003D.getModelSpaceId().safeOpenObject();
			if (!flag)
			{
				string name = odDbBlockTableRecord.getName().TrimStart('*');
				base.Blocks.RootBlock.Name = name;
			}
			_0023_003Dz7nbBCJ01TbI_0024(odDbBlockTableRecord, list, _0023_003DzLRp3iWk_003D, _0023_003DzX347P_0024c_003D, _0023_003DzbONi0CI_003D, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D);
			OdResBuf odResBuf = odDbBlockTableRecord.xData(string.Empty);
			if (odResBuf != null)
			{
				List<KeyValuePair<short, object>> list2 = _0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003Dztyuk6QQ_003D(odResBuf);
				if (list2.Count > 0)
				{
					_0023_003DzgQ5QMXN_0024CasJ(list2);
				}
			}
			if (!SkipLayouts && !flag)
			{
				_0023_003DzIspX74k_003D(_0023_003DzbONi0CI_003D, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D);
			}
		}
		MemoryManager.GetMemoryManager().StopTransaction(value);
		return list;
	}

	private void _0023_003Dzag5jBBQCKrgNUHKN0g_003D_003D(OdDbDatabase _0023_003DzR8GRspk_003D)
	{
		MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
		base.Materials = new MaterialKeyedCollection();
		OdDbDictionaryIterator odDbDictionaryIterator = ((OdDbDictionary)_0023_003DzR8GRspk_003D.getMaterialDictionaryId().openObject(OdDb_OpenMode.kForRead, openErasedOne: false)).newIterator();
		while (!odDbDictionaryIterator.done())
		{
			OdDbMaterial odDbMaterial = (OdDbMaterial)odDbDictionaryIterator.objectId().openObject(OdDb_OpenMode.kForRead, openErasedOne: false);
			string text = odDbDictionaryIterator.name();
			if (!text.Equals(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355530463)) && !text.Equals(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355530449)) && !text.Equals(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528995)))
			{
				Material material = new Material(text);
				material.Description = odDbMaterial.description();
				OdGiMaterialColor odGiMaterialColor = new OdGiMaterialColor();
				odDbMaterial.ambient(odGiMaterialColor);
				OdCmEntityColor odCmEntityColor = odGiMaterialColor.color();
				material.Ambient = Color.FromArgb(odCmEntityColor.red(), odCmEntityColor.green(), odCmEntityColor.blue());
				OdGiMaterialMap odGiMaterialMap = new OdGiMaterialMap();
				odDbMaterial.diffuse(odGiMaterialColor, odGiMaterialMap);
				odCmEntityColor = odGiMaterialColor.color();
				odDbMaterial.opacity(out var opacityPercentage, new OdGiMaterialMap());
				material.Diffuse = Color.FromArgb((int)(opacityPercentage * 255.0), odCmEntityColor.red(), odCmEntityColor.green(), odCmEntityColor.blue());
				string text2 = odGiMaterialMap.sourceFileName();
				if (!string.IsNullOrEmpty(text2))
				{
					try
					{
						if (File.Exists(text2))
						{
							Bitmap bitmap = new Bitmap(text2);
							try
							{
								material.TextureImage = _0023_003Dz0UqjDJRVjznU032ZobZyG6sRUxOwSxYhJCJ1_WxsRxkgAkSSjABO220_003D._0023_003DzaVgi1iC1WyuS(bitmap);
							}
							finally
							{
								((IDisposable)bitmap).Dispose();
							}
						}
						else
						{
							text2 = ((!string.IsNullOrEmpty(base.Path)) ? System.IO.Path.Combine(base.Path, System.IO.Path.GetFileName(text2)) : System.IO.Path.GetFileName(text2));
							if (File.Exists(text2))
							{
								Bitmap bitmap2 = new Bitmap(text2);
								try
								{
									material.TextureImage = _0023_003Dz0UqjDJRVjznU032ZobZyG6sRUxOwSxYhJCJ1_WxsRxkgAkSSjABO220_003D._0023_003DzaVgi1iC1WyuS(bitmap2);
								}
								finally
								{
									((IDisposable)bitmap2).Dispose();
								}
							}
						}
					}
					catch
					{
					}
				}
				odDbMaterial.specular(odGiMaterialColor, new OdGiMaterialMap(), out var _);
				odCmEntityColor = odGiMaterialColor.color();
				material.Specular = Color.FromArgb(odCmEntityColor.red(), odCmEntityColor.green(), odCmEntityColor.blue());
				if (!base.Materials.Contains(material.Name))
				{
					base.Materials.Add(material);
				}
			}
			odDbDictionaryIterator.next();
		}
		MemoryManager.GetMemoryManager().StopTransaction(value);
	}

	private void _0023_003Dz9lIQlEle8Csl(OdDbDatabase _0023_003Dzd2hFvl0_003D, out TextStyleKeyedCollection _0023_003Dz0HOOXWcqzDy7, string _0023_003Dz0EA0NeSD2dKB)
	{
		MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
		_0023_003Dz0HOOXWcqzDy7 = new TextStyleKeyedCollection();
		OdDbSymbolTableIterator odDbSymbolTableIterator = ((OdDbTextStyleTable)_0023_003Dzd2hFvl0_003D.getTextStyleTableId().openObject(OdDb_OpenMode.kForRead)).newIterator();
		odDbSymbolTableIterator.start();
		while (!odDbSymbolTableIterator.done())
		{
			OdDbTextStyleTableRecord odDbTextStyleTableRecord = (OdDbTextStyleTableRecord)odDbSymbolTableIterator.getRecord(OdDb_OpenMode.kForRead);
			if ((!odDbTextStyleTableRecord.isDependent() || (!string.IsNullOrEmpty(_0023_003Dz0EA0NeSD2dKB) && odDbTextStyleTableRecord.getName().StartsWith(_0023_003Dz0EA0NeSD2dKB))) && !string.IsNullOrEmpty(odDbTextStyleTableRecord.getName()) && !_0023_003Dz0HOOXWcqzDy7.Contains(odDbTextStyleTableRecord.getName()))
			{
				_0023_003Dz0HOOXWcqzDy7.Add(_0023_003Dz_v_00241xndtgvraS2Ang3uikzr1Ezew(odDbTextStyleTableRecord, _0023_003Dz0EA0NeSD2dKB));
			}
			odDbSymbolTableIterator.step();
		}
		MemoryManager.GetMemoryManager().StopTransaction(value);
	}

	private void _0023_003Dzd_0024tFz6cjDALc(OdDbDatabase _0023_003Dzd2hFvl0_003D, string _0023_003Dz0EA0NeSD2dKB, out LineTypeKeyedCollection _0023_003Dz8aC_00248_e9phd4)
	{
		MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
		_0023_003Dz8aC_00248_e9phd4 = new LineTypeKeyedCollection();
		OdDbSymbolTableIterator odDbSymbolTableIterator = ((OdDbLinetypeTable)_0023_003Dzd2hFvl0_003D.getLinetypeTableId().openObject(OdDb_OpenMode.kForRead, openErasedOne: false)).newIterator();
		odDbSymbolTableIterator.start();
		while (!odDbSymbolTableIterator.done())
		{
			OdDbLinetypeTableRecord odDbLinetypeTableRecord = (OdDbLinetypeTableRecord)odDbSymbolTableIterator.getRecord(OdDb_OpenMode.kForRead, openErasedRecord: false);
			if ((!odDbLinetypeTableRecord.isDependent() || (!string.IsNullOrEmpty(_0023_003Dz0EA0NeSD2dKB) && odDbLinetypeTableRecord.getName().StartsWith(_0023_003Dz0EA0NeSD2dKB))) && !LineTypeKeyedCollection.IsReservedName(odDbLinetypeTableRecord.getName()))
			{
				float[] array = new float[odDbLinetypeTableRecord.numDashes()];
				for (int i = 0; i < odDbLinetypeTableRecord.numDashes(); i++)
				{
					array[i] = (float)odDbLinetypeTableRecord.dashLengthAt(i);
				}
				if (LineType.CheckPattern(array, throwEx: false, out var _) && !_0023_003Dz8aC_00248_e9phd4.Contains(odDbLinetypeTableRecord.getName()))
				{
					_0023_003Dz8aC_00248_e9phd4.Add(new LineType(odDbLinetypeTableRecord.getName(), array)
					{
						XRefName = _0023_003Dz0EA0NeSD2dKB,
						Description = odDbLinetypeTableRecord.comments()
					});
				}
			}
			odDbSymbolTableIterator.step();
		}
		MemoryManager.GetMemoryManager().StopTransaction(value);
	}

	private void _0023_003DzC2R_0024LIo_003D(OdDbDatabase _0023_003Dzd2hFvl0_003D, bool _0023_003DzsMEmUGI_003D, string _0023_003DziFKy3_Jdw399, string _0023_003Dz0EA0NeSD2dKB, LineTypeKeyedCollection _0023_003Dz8aC_00248_e9phd4)
	{
		MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
		OdDbSymbolTableIterator odDbSymbolTableIterator = ((OdDbLayerTable)_0023_003Dzd2hFvl0_003D.getLayerTableId().openObject(OdDb_OpenMode.kForRead, openErasedOne: false)).newIterator();
		odDbSymbolTableIterator.start();
		while (!odDbSymbolTableIterator.done())
		{
			OdDbLayerTableRecord odDbLayerTableRecord = (OdDbLayerTableRecord)odDbSymbolTableIterator.getRecord(OdDb_OpenMode.kForRead, openErasedRecord: false);
			if (!odDbLayerTableRecord.isHidden() && (LayersToLoad == null || LayersToLoad.Contains(odDbLayerTableRecord.getName())) && (!odDbLayerTableRecord.isDependent() || (!string.IsNullOrEmpty(_0023_003DziFKy3_Jdw399) && odDbLayerTableRecord.getName().StartsWith(_0023_003DziFKy3_Jdw399))))
			{
				OdCmColor odCmColor = odDbLayerTableRecord.color();
				int alpha = odDbLayerTableRecord.transparency().alpha();
				Color color = ((!odCmColor.isForeground()) ? Color.FromArgb(alpha, odCmColor.red(), odCmColor.green(), odCmColor.blue()) : Color.FromArgb(alpha, ForegroundColor));
				bool visible = false;
				if (!odDbLayerTableRecord.isOff() && !odDbLayerTableRecord.isFrozen())
				{
					visible = true;
				}
				string lineTypeName = null;
				OdDbObjectId odDbObjectId = odDbLayerTableRecord.linetypeObjectId();
				if (!odDbObjectId.isNull() && !odDbObjectId.isErased())
				{
					OdDbLinetypeTableRecord odDbLinetypeTableRecord = (OdDbLinetypeTableRecord)odDbObjectId.openObject(OdDb_OpenMode.kForRead, openErasedOne: false);
					lineTypeName = (_0023_003Dz8aC_00248_e9phd4.Contains(odDbLinetypeTableRecord.getName()) ? odDbLinetypeTableRecord.getName() : null);
				}
				Layer layer = new Layer(odDbLayerTableRecord.getName(), color, lineTypeName, WriteDatabase._0023_003DzCO9z9YG_0024A6qTfyILw2qCj_0024c7cI9_0024(odDbLayerTableRecord.lineWeight()), visible, odDbLayerTableRecord.isLocked());
				OdDbObjectId odDbObjectId2 = odDbLayerTableRecord.materialId();
				if (odDbObjectId2.isValid())
				{
					OdDbMaterial odDbMaterial = (OdDbMaterial)odDbObjectId2.safeOpenObject(OdDb_OpenMode.kForRead);
					if (!odDbMaterial.name().Equals(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528995)))
					{
						layer.MaterialName = odDbMaterial.name();
					}
				}
				if (_0023_003DzsMEmUGI_003D)
				{
					layer.XRefName = _0023_003Dz0EA0NeSD2dKB;
				}
				OdResBuf odResBuf = odDbLayerTableRecord.xData(string.Empty);
				if (odResBuf != null)
				{
					List<KeyValuePair<short, object>> list = _0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003Dztyuk6QQ_003D(odResBuf);
					if (list.Count > 0)
					{
						layer.XData = list;
					}
				}
				if (base.Layers.IndexOf(layer) == -1)
				{
					base.Layers.Add(layer);
				}
			}
			odDbSymbolTableIterator.step();
		}
		MemoryManager.GetMemoryManager().StopTransaction(value);
	}

	private void _0023_003DzIspX74k_003D(ReadEntityData _0023_003DzbONi0CI_003D, IProgress<ProgressChangedEventArgs> _0023_003DzIzeJ4Qs_003D, CancellationToken _0023_003Dz_0024cU8x9g_003D)
	{
		MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
		OdDbDictionaryIterator odDbDictionaryIterator = ((OdDbDictionary)_0023_003DzbONi0CI_003D.database.getLayoutDictionaryId().safeOpenObject()).newIterator();
		while (!odDbDictionaryIterator.done())
		{
			OdDbLayout odDbLayout = OdDbLayout.cast(odDbDictionaryIterator.objectId().safeOpenObject());
			if (odDbLayout != null)
			{
				OdDbBlockTableRecord odDbBlockTableRecord = (OdDbBlockTableRecord)odDbLayout.getBlockTableRecordId().safeOpenObject();
				if (!(odDbBlockTableRecord.getName().TrimStart('*').ToUpper() == _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355529012)))
				{
					string layoutName = odDbLayout.getLayoutName();
					odDbLayout.getPlotPaperSize(out var paperWidth, out var paperHeight);
					double num = odDbLayout.getLeftMargin();
					double num2 = odDbLayout.getBottomMargin();
					odDbLayout.getPlotOrigin(out var xCoordinate, out var yCoordinate);
					OdGePoint2d paperImageOrigin = odDbLayout.getPaperImageOrigin();
					OdDbPlotSettings_PlotRotation odDbPlotSettings_PlotRotation = odDbLayout.plotRotation();
					if (odDbPlotSettings_PlotRotation == OdDbPlotSettings_PlotRotation.k90degrees || odDbPlotSettings_PlotRotation == OdDbPlotSettings_PlotRotation.k270degrees)
					{
						double num3 = paperWidth;
						paperWidth = paperHeight;
						paperHeight = num3;
						double num4 = num;
						num = num2;
						num2 = num4;
						double num5 = xCoordinate;
						xCoordinate = yCoordinate;
						yCoordinate = num5;
					}
					linearUnitsType linearUnitsType2 = ((odDbLayout.plotPaperUnits() == OdDbPlotSettings_PlotPaperUnits.kInches) ? linearUnitsType.Inches : linearUnitsType.Millimeters);
					if (linearUnitsType2 == linearUnitsType.Inches)
					{
						double linearUnitsConversionFactor = Utility.GetLinearUnitsConversionFactor(linearUnitsType.Millimeters, linearUnitsType2);
						paperWidth *= linearUnitsConversionFactor;
						paperHeight *= linearUnitsConversionFactor;
						num *= linearUnitsConversionFactor;
						num2 *= linearUnitsConversionFactor;
						xCoordinate *= linearUnitsConversionFactor;
						yCoordinate *= linearUnitsConversionFactor;
						paperImageOrigin *= linearUnitsConversionFactor;
					}
					odDbLayout.getCustomPrintScale(out var numerator, out var denominator);
					double num6 = (_0023_003DzbONi0CI_003D.layoutPlotScale = numerator / denominator);
					Vector3D vector3D = new Vector3D(num + xCoordinate, num2 + yCoordinate, 0.0);
					Vector3D vector3D2 = new Vector3D(paperImageOrigin.x * num6, paperImageOrigin.y * num6);
					Vector3D vector3D3 = vector3D + vector3D2;
					Transformation transformation = new Translation(vector3D3) * new Scaling(num6);
					PlotTransformations.Add(layoutName, transformation);
					Sheet sheet = (_0023_003DzbONi0CI_003D.sheet = new Sheet(linearUnitsType2, paperWidth, paperHeight, layoutName, angleProjectionType.FirstAngle));
					_0023_003DzbONi0CI_003D.overallVportId = odDbLayout.overallVportId();
					List<Entity> list = new List<Entity>();
					_0023_003Dz7nbBCJ01TbI_0024(odDbBlockTableRecord, list, _0023_003DzLRp3iWk_003D, _0023_003DzX347P_0024c_003D, _0023_003DzbONi0CI_003D, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D);
					foreach (Entity item in list)
					{
						_0023_003DzyxPkjece4fuZ(item, _0023_003DzbONi0CI_003D);
						if (item is View view)
						{
							view.X += vector3D3.X;
							view.Y += vector3D3.Y;
							continue;
						}
						item.TransformBy(transformation);
						if (item is Dimension dimension)
						{
							dimension.LinearScale /= num6;
						}
						if (!(item is BlockReference blockReference))
						{
							continue;
						}
						foreach (KeyValuePair<string, AttributeReference> attribute in blockReference.Attributes)
						{
							Plane plane = attribute.Value.Plane;
							attribute.Value.Plane = new Plane(transformation * plane.Origin, transformation * plane.AxisX, transformation * plane.AxisY);
						}
					}
					sheet.Entities.AddRange(list);
					base.DrawingSheets.Add(sheet);
				}
			}
			odDbDictionaryIterator.next();
		}
		MemoryManager.GetMemoryManager().StopTransaction(value);
	}

	private void _0023_003DzyxPkjece4fuZ(Entity _0023_003Dzvyf_UNM_003D, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		if (_0023_003Dzvyf_UNM_003D.LineTypeName != null && !base.DrawingLineTypes.Contains(_0023_003Dzvyf_UNM_003D.LineTypeName))
		{
			base.DrawingLineTypes.Add((LineType)_0023_003DzbONi0CI_003D.importedLinetypes[_0023_003Dzvyf_UNM_003D.LineTypeName].Clone());
		}
		if (_0023_003Dzvyf_UNM_003D is Hatch { IsUserDefinedPattern: false } hatch && !hatch.PatternName.Equals(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528962)) && !base.DrawingHatchPatterns.Contains(hatch.PatternName))
		{
			base.DrawingHatchPatterns.Add((HatchPattern)base.HatchPatterns[hatch.PatternName].Clone());
		}
		else if (_0023_003Dzvyf_UNM_003D is Text text && !string.IsNullOrEmpty(text.StyleName) && !base.DrawingTextStyles.Contains(text.StyleName))
		{
			base.DrawingTextStyles.Add((TextStyle)_0023_003DzbONi0CI_003D.importedTextStyles[text.StyleName].Clone());
		}
		else if (_0023_003Dzvyf_UNM_003D is Table table)
		{
			for (int i = 0; i < table.RowsNum; i++)
			{
				for (int j = 0; j < table.ColumnsNum; j++)
				{
					string styleName = table.GetStyleName(i, j);
					if (!string.IsNullOrEmpty(styleName) && !base.DrawingTextStyles.Contains(styleName))
					{
						base.DrawingTextStyles.Add((TextStyle)_0023_003DzbONi0CI_003D.importedTextStyles[styleName].Clone());
					}
				}
			}
		}
		if (!base.DrawingLayers.Contains(_0023_003Dzvyf_UNM_003D.LayerName))
		{
			Layer layer = base.Layers[_0023_003Dzvyf_UNM_003D.LayerName];
			base.DrawingLayers.Add((Layer)layer.Clone());
			if (layer.LineTypeName != null && !base.DrawingLineTypes.Contains(layer.LineTypeName))
			{
				base.DrawingLineTypes.Add((LineType)_0023_003DzbONi0CI_003D.importedLinetypes[layer.LineTypeName].Clone());
			}
		}
		if (!(_0023_003Dzvyf_UNM_003D is BlockReference blockReference))
		{
			return;
		}
		foreach (KeyValuePair<string, AttributeReference> attribute in blockReference.Attributes)
		{
			AttributeReference value = attribute.Value;
			if (value.LineTypeName != null && !base.DrawingLineTypes.Contains(value.LineTypeName))
			{
				base.DrawingLineTypes.Add((LineType)_0023_003DzbONi0CI_003D.importedLinetypes[value.LineTypeName].Clone());
			}
			if (!string.IsNullOrEmpty(value.StyleName) && !base.DrawingTextStyles.Contains(value.StyleName))
			{
				base.DrawingTextStyles.Add((TextStyle)_0023_003DzbONi0CI_003D.importedTextStyles[value.StyleName].Clone());
			}
			if (!base.DrawingLayers.Contains(value.LayerName))
			{
				base.DrawingLayers.Add((Layer)base.Layers[value.LayerName].Clone());
			}
		}
		_0023_003DzWL92rfZQj0uS(blockReference, _0023_003DzbONi0CI_003D);
	}

	private void _0023_003DzWL92rfZQj0uS(BlockReference _0023_003Dzjo8uZtc_003D, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		if (_0023_003DzbONi0CI_003D.importedBlocks.TryGetValue(_0023_003Dzjo8uZtc_003D.BlockName, out var value))
		{
			if (!base.DrawingBlocks.Contains(value.Name))
			{
				base.DrawingBlocks.Add((Block)value.Clone());
			}
			for (int i = 0; i < value.Entities.Count; i++)
			{
				Entity entity = value.Entities[i];
				base.DrawingBlocks[value.Name].Entities[i].TranslationID = entity.TranslationID;
				_0023_003DzyxPkjece4fuZ(entity, _0023_003DzbONi0CI_003D);
			}
		}
	}

	private void _0023_003DzALUk8WmyJR_4(OdDbDatabase _0023_003Dzd2hFvl0_003D)
	{
		MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
		OdDbViewportTableRecord odDbViewportTableRecord = (OdDbViewportTableRecord)((OdDbViewportTable)_0023_003Dzd2hFvl0_003D.getViewportTableId().safeOpenObject()).getActiveViewportId().openObject(OdDb_OpenMode.kForRead, openErasedOne: false);
		_0023_003DzQSyYVcquy00G._0023_003DzqwjRtc4_003D = new Vector3D(_0023_003Dzw_7skJnLqq6B(odDbViewportTableRecord.viewDirection()));
		_0023_003DzQSyYVcquy00G._0023_003DzqwjRtc4_003D.Normalize();
		Transformation.AutocadOCS(_0023_003DzQSyYVcquy00G._0023_003DzqwjRtc4_003D, out var xAxis, out var yAxis);
		yAxis.TransformBy(new Rotation(0.0 - odDbViewportTableRecord.viewTwist(), _0023_003DzQSyYVcquy00G._0023_003DzqwjRtc4_003D));
		_0023_003DzQSyYVcquy00G._0023_003DzGIOjdZFVwcx_0024Ivu3jw_003D_003D = odDbViewportTableRecord.lensLength();
		_0023_003DzQSyYVcquy00G._0023_003DzUiEKVrs_003D = odDbViewportTableRecord.viewDirection().length();
		_0023_003DzQSyYVcquy00G._0023_003Dz_8qkpR8_003D = new Point3D(_0023_003DzGa_t9CAQQGhs(odDbViewportTableRecord.target())) + odDbViewportTableRecord.centerPoint().x * xAxis + odDbViewportTableRecord.centerPoint().y * yAxis;
		_0023_003DzQSyYVcquy00G._0023_003DzlIUGZKw_003D = new Vector3D(yAxis.ToArray());
		_0023_003DzQSyYVcquy00G._0023_003DzRMsJ77myYf6B = (odDbViewportTableRecord.perspectiveEnabled() ? projectionType.Perspective : projectionType.Orthographic);
		_0023_003DzQSyYVcquy00G._0023_003Dza9v8qfWmqzIi = new SizeF((float)odDbViewportTableRecord.width(), (float)odDbViewportTableRecord.height());
		MemoryManager.GetMemoryManager().StopTransaction(value);
	}

	private TextStyle _0023_003Dz_v_00241xndtgvraS2Ang3uikzr1Ezew(OdDbTextStyleTableRecord _0023_003DzeRStL5A_003D, string _0023_003Dz0EA0NeSD2dKB)
	{
		fontStyle fontStyle2 = fontStyle.Regular;
		string typeface = null;
		_0023_003DzeRStL5A_003D.font(ref typeface, out var bold, out var italic, out var _, out var _);
		if (bold)
		{
			fontStyle2 |= fontStyle.Bold;
		}
		if (italic)
		{
			fontStyle2 |= fontStyle.Italic;
		}
		return new TextStyle(_0023_003DzeRStL5A_003D.getName(), typeface, fontStyle2, _0023_003DzeRStL5A_003D.xScale())
		{
			FileName = (string.IsNullOrEmpty(typeface) ? _0023_003DzeRStL5A_003D.fileName() : null),
			XRefName = _0023_003Dz0EA0NeSD2dKB
		};
	}

	private void _0023_003DzwzgrlVKnBi9t(OdDbDatabase _0023_003Dzd2hFvl0_003D, ReadEntityData _0023_003DzbONi0CI_003D, Dictionary<string, string> _0023_003DzxVStmqc0kqZj, IProgress<ProgressChangedEventArgs> _0023_003DzIzeJ4Qs_003D, CancellationToken _0023_003Dz_0024cU8x9g_003D)
	{
		MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
		OdDbBlockTable obj = (OdDbBlockTable)_0023_003Dzd2hFvl0_003D.getBlockTableId().safeOpenObject();
		int num = 0;
		int num2 = 0;
		OdDbSymbolTableIterator odDbSymbolTableIterator = obj.newIterator();
		if (string.IsNullOrEmpty(_0023_003DzbONi0CI_003D.xrefPrefix))
		{
			odDbSymbolTableIterator.start();
			while (!odDbSymbolTableIterator.done())
			{
				num2++;
				odDbSymbolTableIterator.step();
			}
		}
		odDbSymbolTableIterator.start(atBeginning: true);
		for (; !odDbSymbolTableIterator.done(); odDbSymbolTableIterator.step())
		{
			OdDbBlockTableRecord odDbBlockTableRecord = (OdDbBlockTableRecord)odDbSymbolTableIterator.getRecordId().safeOpenObject();
			num++;
			string text = odDbBlockTableRecord.getName().TrimStart('*');
			if (text.ToUpper() == _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355529012) || text.ToUpper().StartsWith(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528982)))
			{
				continue;
			}
			string text2 = _0023_003DzbONi0CI_003D.xrefPrefix + text;
			string text3 = text;
			if (_0023_003DzbONi0CI_003D.importedBlocks.Contains(text2))
			{
				if (_0023_003DzbONi0CI_003D.duplicatedBlockNamesConversionTable.ContainsKey(text2))
				{
					continue;
				}
				text3 = Utility.GetUnusedBlockName(text2, _0023_003DzbONi0CI_003D.importedBlocks).Substring(_0023_003DzbONi0CI_003D.xrefPrefix.Length);
				_0023_003DzbONi0CI_003D.duplicatedBlockNamesConversionTable.Add(text2, text3);
			}
			_0023_003DzokfWWuOR4byZ(_0023_003Dzd2hFvl0_003D, odDbBlockTableRecord, text3, _0023_003DzbONi0CI_003D, _0023_003DzxVStmqc0kqZj, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D);
			if (_0023_003Dzxx2uNQo_003D)
			{
				break;
			}
			if (!UpdateProgressAndCheckCancelled(num, num2, base.ParsingBlocksText, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D))
			{
				_0023_003Dzxx2uNQo_003D = true;
				break;
			}
			if (num == num2)
			{
				break;
			}
		}
		MemoryManager.GetMemoryManager().StopTransaction(value);
		UpdateProgressTo100(base.ParsingBlocksText, _0023_003DzIzeJ4Qs_003D);
	}

	private void _0023_003Dz7nbBCJ01TbI_0024(OdDbBlockTableRecord _0023_003Dz1EtocfNGByJv, List<Entity> _0023_003DzhytBlFc_003D, Point3D _0023_003DzLRp3iWk_003D, Point3D _0023_003DzX347P_0024c_003D, ReadEntityData _0023_003DzbONi0CI_003D, IProgress<ProgressChangedEventArgs> _0023_003DzIzeJ4Qs_003D, CancellationToken _0023_003Dz_0024cU8x9g_003D)
	{
		MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
		short pDMODE = _0023_003DzbONi0CI_003D.database.getPDMODE();
		_0023_003DzbONi0CI_003D.database.setPDMODE(0);
		int num = 0;
		OdDbObjectIterator odDbObjectIterator = _0023_003Dz1EtocfNGByJv.newIterator();
		if (string.IsNullOrEmpty(_0023_003DzbONi0CI_003D.xrefPrefix))
		{
			odDbObjectIterator.start();
			while (!odDbObjectIterator.done())
			{
				num++;
				odDbObjectIterator.step();
			}
		}
		int num2 = num;
		num = 0;
		odDbObjectIterator.start(atBeginning: true);
		for (; !odDbObjectIterator.done(); odDbObjectIterator.step())
		{
			OdDbEntity odDbEntity = odDbObjectIterator.entity(OdDb_OpenMode.kForWrite, openErasedEntity: false);
			if (LayersToLoad != null && !LayersToLoad.Contains(odDbEntity.layer()))
			{
				continue;
			}
			if (!(odDbEntity is OdDbRay) && !(odDbEntity is OdDbXline))
			{
				OdResult odResult = _0023_003DzEQYlNre9GI34(odDbEntity);
				switch (odResult)
				{
				case OdResult.eInvalidExtents:
				case OdResult.eNullExtents:
					if (!(odDbEntity is OdDbHatch _0023_003Dzc3fL4NWp3aL))
					{
						continue;
					}
					_0023_003DzWPDMCrM6XoprC621Cg_003D_003D(_0023_003Dzc3fL4NWp3aL);
					odResult = _0023_003DzEQYlNre9GI34(odDbEntity);
					if (odResult == OdResult.eNullExtents || odResult == OdResult.eInvalidExtents)
					{
						continue;
					}
					break;
				default:
					throw new OdError(odResult);
				case OdResult.eOk:
					break;
				}
			}
			IEnumerable<Entity> enumerable = ReadEntity(odDbEntity, _0023_003DzbONi0CI_003D);
			if (enumerable != null)
			{
				_0023_003DzhytBlFc_003D.AddRange(enumerable);
			}
			if (!UpdateProgressAndCheckCancelled(++num, num2, base.ParsingEntitiesText, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D))
			{
				_0023_003Dzxx2uNQo_003D = true;
				break;
			}
		}
		_0023_003DzbONi0CI_003D.database.setPDMODE(pDMODE);
		MemoryManager.GetMemoryManager().StopTransaction(value);
		UpdateProgressTo100(base.ParsingEntitiesText, _0023_003DzIzeJ4Qs_003D);
	}

	private OdResult _0023_003DzEQYlNre9GI34(OdDbEntity _0023_003DzkeRlGGg30I6n)
	{
		OdGeExtents3d odGeExtents3d = new OdGeExtents3d();
		OdResult geomExtents = _0023_003DzkeRlGGg30I6n.getGeomExtents(odGeExtents3d);
		if (geomExtents == OdResult.eOk)
		{
			Utility.UpdateMinMaxSlow(new Point3D(_0023_003DzGa_t9CAQQGhs(odGeExtents3d.minPoint())), _0023_003DzLRp3iWk_003D, _0023_003DzX347P_0024c_003D);
			Utility.UpdateMinMaxQuick(new Point3D(_0023_003DzGa_t9CAQQGhs(odGeExtents3d.maxPoint())), _0023_003DzLRp3iWk_003D, _0023_003DzX347P_0024c_003D);
		}
		return geomExtents;
	}

	private void _0023_003DzokfWWuOR4byZ(OdDbDatabase _0023_003Dzd2hFvl0_003D, OdDbBlockTableRecord _0023_003Dz9uVhDi0_003D, string _0023_003Dzxaw56Ac_003D, ReadEntityData _0023_003DzbONi0CI_003D, Dictionary<string, string> _0023_003DzxVStmqc0kqZj, IProgress<ProgressChangedEventArgs> _0023_003DzIzeJ4Qs_003D, CancellationToken _0023_003Dz_0024cU8x9g_003D)
	{
		double[] coords = new double[3]
		{
			_0023_003Dz9uVhDi0_003D.origin().x,
			_0023_003Dz9uVhDi0_003D.origin().y,
			_0023_003Dz9uVhDi0_003D.origin().z
		};
		string text = _0023_003DzbONi0CI_003D.xrefPrefix + _0023_003Dzxaw56Ac_003D;
		Block block = new Block(text, new Point3D(coords));
		block.Description = _0023_003Dz9uVhDi0_003D.comments();
		block.Units = WriteDatabase._0023_003DzCpSZHkwMYNQHhZOwlA_003D_003D(_0023_003Dz9uVhDi0_003D.blockInsertUnits());
		if (_0023_003Dz9uVhDi0_003D.isAnonymous())
		{
			block.BlockSource = autodeskSourceType.Anonymous;
		}
		block._exportMode = ((_0023_003Dz9uVhDi0_003D.xrefStatus() != OdDb_XrefStatus.kXrfNotAnXref) ? autodeskExportType.ExternalReference : autodeskExportType.Embedded);
		if (block.ExportMode == autodeskExportType.ExternalReference)
		{
			string text2 = _0023_003Dz9uVhDi0_003D.pathName();
			string fileName = System.IO.Path.GetFileName(text2);
			if (_0023_003DzXJFc_00242a3weYa.Contains(fileName) || SkipExternalReferences)
			{
				return;
			}
			_0023_003DzXJFc_00242a3weYa.Add(fileName);
			OdDbObjectIdArray odDbObjectIdArray = new OdDbObjectIdArray();
			odDbObjectIdArray.Add(_0023_003Dz9uVhDi0_003D.objectId());
			OdDbXRefMan.unload(odDbObjectIdArray);
			OdDbXRefMan.load(odDbObjectIdArray);
			if (_0023_003Dz9uVhDi0_003D.xrefStatus() != OdDb_XrefStatus.kXrfResolved)
			{
				if (!string.IsNullOrEmpty(base.Path))
				{
					_0023_003Dz9uVhDi0_003D.setPathName(System.IO.Path.Combine(base.Path, text2));
					OdDbXRefMan.unload(odDbObjectIdArray);
					OdDbXRefMan.load(odDbObjectIdArray);
					if (_0023_003Dz9uVhDi0_003D.xrefStatus() != OdDb_XrefStatus.kXrfResolved)
					{
						_0023_003Dz9uVhDi0_003D.setPathName(System.IO.Path.Combine(base.Path, fileName));
						OdDbXRefMan.unload(odDbObjectIdArray);
						OdDbXRefMan.load(odDbObjectIdArray);
					}
				}
				if (_0023_003Dz9uVhDi0_003D.xrefStatus() != OdDb_XrefStatus.kXrfResolved && SearchFolders != null)
				{
					for (int i = 0; i < SearchFolders.Count; i++)
					{
						string path = SearchFolders[i];
						_0023_003Dz9uVhDi0_003D.setPathName(System.IO.Path.Combine(path, fileName));
						OdDbXRefMan.unload(odDbObjectIdArray);
						OdDbXRefMan.load(odDbObjectIdArray);
						if (_0023_003Dz9uVhDi0_003D.xrefStatus() == OdDb_XrefStatus.kXrfResolved)
						{
							break;
						}
					}
				}
			}
			OdDbDatabase odDbDatabase = _0023_003Dz9uVhDi0_003D.xrefDatabase(includeUnresolved: true);
			if (_0023_003Dz9uVhDi0_003D.xrefStatus() == OdDb_XrefStatus.kXrfResolved && odDbDatabase != null)
			{
				string text3 = _0023_003Dzxaw56Ac_003D + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355529060);
				BlockKeyedCollection _0023_003DzsNshVQ1ppgcE;
				TextStyleKeyedCollection _0023_003Dz0HOOXWcqzDy;
				LineTypeKeyedCollection _0023_003Dz8aC_00248_e9phd;
				float _0023_003DzH_5xWVG67Bgs;
				Point3D point3D;
				Point3D point3D2;
				IEnumerable<Entity> collection = _0023_003DzO0pDWDs_003D(text3, _0023_003DzbONi0CI_003D.duplicatedBlockNamesConversionTable, odDbDatabase, _0023_003DzxVStmqc0kqZj, out _0023_003DzsNshVQ1ppgcE, out _0023_003Dz0HOOXWcqzDy, out _0023_003Dz8aC_00248_e9phd, out _0023_003DzH_5xWVG67Bgs, out point3D, out point3D2, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D);
				if (_0023_003Dzxx2uNQo_003D)
				{
					return;
				}
				block.Entities.AddRange(collection);
				block._filePath = text2;
				if (!string.IsNullOrEmpty(_0023_003DzbONi0CI_003D.xrefPrefix))
				{
					block.XRefName = _0023_003DzbONi0CI_003D.xrefPrefix.Substring(0, _0023_003DzbONi0CI_003D.xrefPrefix.Length - 1);
				}
				foreach (Block item in _0023_003DzsNshVQ1ppgcE)
				{
					if (!_0023_003DzbONi0CI_003D.importedBlocks.Contains(item.Name))
					{
						_0023_003DzbONi0CI_003D.importedBlocks.Add(item);
						if (string.IsNullOrEmpty(item.XRefName))
						{
							item.XRefName = text;
						}
						else
						{
							item.XRefName = text3 + item.XRefName;
						}
					}
				}
				_0023_003Dz5xnwH__0024EKwyi(_0023_003Dz0HOOXWcqzDy, _0023_003DzbONi0CI_003D.importedTextStyles);
				_0023_003Dz5xnwH__0024EKwyi(_0023_003Dz8aC_00248_e9phd, _0023_003DzbONi0CI_003D.importedLinetypes);
			}
			else if (!_0023_003DzxVStmqc0kqZj.ContainsKey(text))
			{
				_0023_003DzxVStmqc0kqZj.Add(text, text2);
			}
		}
		else
		{
			Block currentBlock = _0023_003DzbONi0CI_003D.currentBlock;
			_0023_003DzbONi0CI_003D.currentBlock = block;
			OdDbObjectIterator odDbObjectIterator = _0023_003Dz9uVhDi0_003D.newIterator();
			odDbObjectIterator.start();
			while (!odDbObjectIterator.done())
			{
				_0023_003DzMByt481GxVcJ(odDbObjectIterator.objectId(), _0023_003DzbONi0CI_003D);
				odDbObjectIterator.step();
			}
			_0023_003DzbONi0CI_003D.currentBlock = currentBlock;
		}
		block.IsResolved = _0023_003Dz9uVhDi0_003D.isResolved();
		if ((block.ExportMode == autodeskExportType.Embedded || block.IsResolved) && !string.IsNullOrEmpty(text) && !_0023_003DzbONi0CI_003D.importedBlocks.Contains(text))
		{
			_0023_003DzbONi0CI_003D.importedBlocks.Add(block);
		}
	}

	private double _0023_003DzN3nql_0024PPNCu0S7dsKbxuSaw_003D(OdDbEntity _0023_003Dzvyf_UNM_003D)
	{
		double result = 0.005;
		OdGeExtents3d odGeExtents3d = new OdGeExtents3d();
		if (_0023_003Dzvyf_UNM_003D.getGeomExtents(odGeExtents3d) == OdResult.eOk)
		{
			Point3D minCorner = new Point3D(_0023_003DzGa_t9CAQQGhs(odGeExtents3d.minPoint()));
			Point3D maxCorner = new Point3D(_0023_003DzGa_t9CAQQGhs(odGeExtents3d.maxPoint()));
			result = new Size3D(minCorner, maxCorner).Diagonal * 0.005;
		}
		return result;
	}

	private void _0023_003DzMByt481GxVcJ(OdDbObjectId _0023_003DzreBja6g_003D, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
		OdDbEntity acadEnt = (OdDbEntity)_0023_003DzreBja6g_003D.openObject(OdDb_OpenMode.kForRead, openErasedOne: false);
		IEnumerable<Entity> enumerable = ReadEntity(acadEnt, _0023_003DzbONi0CI_003D);
		if (enumerable != null)
		{
			_0023_003DzbONi0CI_003D.currentBlock.Entities.AddRange(enumerable);
		}
		MemoryManager.GetMemoryManager().StopTransaction(value);
	}

	protected virtual IEnumerable<Entity> ReadEntity(OdDbEntity acadEnt, ReadEntityData data)
	{
		List<Entity> list = new List<Entity>();
		Entity entity = null;
		if (LayersToLoad != null && !LayersToLoad.Contains(acadEnt.layer()))
		{
			return list;
		}
		MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
		try
		{
			if (!(acadEnt is OdDbPoint))
			{
				if (!(acadEnt is OdDbLine))
				{
					if (!(acadEnt is OdDbXline))
					{
						if (!(acadEnt is OdDbArc))
						{
							if (!(acadEnt is OdDbCircle))
							{
								if (!(acadEnt is OdDbEllipse))
								{
									if (!(acadEnt is OdDbAttributeDefinition))
									{
										if (!(acadEnt is OdDbText))
										{
											if (!(acadEnt is OdDbMText))
											{
												if (!(acadEnt is OdDbLeader))
												{
													if (!(acadEnt is OdDbMLeader))
													{
														if (!(acadEnt is OdDbFcf))
														{
															if (!(acadEnt is OdDbPolyline))
															{
																if (!(acadEnt is OdDb2dPolyline))
																{
																	if (!(acadEnt is OdDb3dPolyline))
																	{
																		if (!(acadEnt is OdDbSpline))
																		{
																			if (!(acadEnt is OdDbFace))
																			{
																				if (!(acadEnt is OdDbPolyFaceMesh))
																				{
																					if (!(acadEnt is OdDbPolygonMesh))
																					{
																						if (acadEnt is OdDbMInsertBlock)
																						{
																							return _0023_003Dze_00246PNCw_003D(acadEnt, list, _0023_003Dzu0K6_fhNncbf(acadEnt, data));
																						}
																						if (!(acadEnt is OdDbTable))
																						{
																							if (!(acadEnt is OdDbBlockReference))
																							{
																								if (!(acadEnt is OdDbRotatedDimension))
																								{
																									if (!(acadEnt is OdDbAlignedDimension))
																									{
																										if (!(acadEnt is OdDbOrdinateDimension))
																										{
																											if (!(acadEnt is OdDbRadialDimension))
																											{
																												if (!(acadEnt is OdDbDiametricDimension))
																												{
																													if (!(acadEnt is OdDb3PointAngularDimension))
																													{
																														if (!(acadEnt is OdDb2LineAngularDimension))
																														{
																															if (!(acadEnt is OdDbArcDimension))
																															{
																																if (!(acadEnt is OdDbSolid))
																																{
																																	if (!(acadEnt is OdDb3dSolid))
																																	{
																																		if (!(acadEnt is OdDbNurbSurface))
																																		{
																																			if (!(acadEnt is OdDbLoftedSurface))
																																			{
																																				if (!(acadEnt is OdDbRegion))
																																				{
																																					if (acadEnt is OdDbMline)
																																					{
																																						return _0023_003Dze_00246PNCw_003D(acadEnt, list, _0023_003DzF_Uo3rSbkPr8(acadEnt, data));
																																					}
																																					if (!(acadEnt is OdDbHatch))
																																					{
																																						if (!(acadEnt is OdDbTrace))
																																						{
																																							if (!(acadEnt is OdDbProxyEntity))
																																							{
																																								if (!(acadEnt is OdDbSubDMesh))
																																								{
																																									if (!(acadEnt is OdDbWipeout))
																																									{
																																										if (!(acadEnt is OdDbRasterImage))
																																										{
																																											if (!(acadEnt is OdDbBody))
																																											{
																																												if (!(acadEnt is OdDbExtrudedSurface))
																																												{
																																													if (!(acadEnt is OdDbSurface))
																																													{
																																														if (!(acadEnt is OdDbViewport))
																																														{
																																															if (acadEnt is OdDbOle2Frame)
																																															{
																																																if (!data.skipOleObjects)
																																																{
																																																	entity = _0023_003Dzh7bgWrunoTj3(acadEnt, data);
																																																}
																																															}
																																															else
																																															{
																																																log.AppendLine(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355529084), acadEnt.GetType(), _0023_003Dz2jlzUDbXSA47Py_0024dGg_003D_003D(acadEnt)));
																																															}
																																														}
																																														else
																																														{
																																															entity = _0023_003DzIJwwhE0_003D(acadEnt, data);
																																														}
																																													}
																																													else
																																													{
																																														entity = _0023_003DzUHsXPSh3Hpw_0024yNpTeA_003D_003D(acadEnt, data);
																																													}
																																												}
																																												else
																																												{
																																													entity = _0023_003DzZOLoqtN6sniqwwNb_0024A_003D_003D(acadEnt, data);
																																												}
																																											}
																																											else
																																											{
																																												entity = _0023_003DzfPmt5avcUJNg(acadEnt, data);
																																											}
																																										}
																																										else
																																										{
																																											entity = _0023_003DzcnV3Yqk_4GfJfeIJ_0024Q_003D_003D(acadEnt, data, log);
																																										}
																																									}
																																									else
																																									{
																																										log.AppendLine(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355529084), acadEnt.GetType(), _0023_003Dz2jlzUDbXSA47Py_0024dGg_003D_003D(acadEnt)));
																																									}
																																								}
																																								else
																																								{
																																									entity = _0023_003Dzme9MJA7SX8i7(acadEnt, data);
																																								}
																																							}
																																							else if (!data.skipProxies)
																																							{
																																								entity = _0023_003DzQ2b3U6k1x__h(acadEnt, data);
																																							}
																																						}
																																						else
																																						{
																																							entity = _0023_003DzHAL6kVk_003D(acadEnt, data);
																																						}
																																					}
																																					else
																																					{
																																						entity = _0023_003Dz_99JNGI_003D(acadEnt, data);
																																					}
																																				}
																																				else
																																				{
																																					entity = _0023_003DzWIlB49Q_003D(acadEnt, data);
																																				}
																																			}
																																			else
																																			{
																																				entity = _0023_003Dzt9ZNO0vL5C9tMlyvVw_003D_003D(acadEnt, data);
																																			}
																																		}
																																		else
																																		{
																																			entity = _0023_003DzUHsXPSh3Hpw_0024yNpTeA_003D_003D(acadEnt, data);
																																		}
																																	}
																																	else
																																	{
																																		entity = _0023_003DzfPmt5avcUJNg(acadEnt, data);
																																	}
																																}
																																else
																																{
																																	entity = _0023_003Dztdf8kWM_003D(acadEnt, data, log);
																																}
																															}
																															else
																															{
																																entity = _0023_003DzHXJNPIXUIlLX(acadEnt, data);
																															}
																														}
																														else
																														{
																															entity = _0023_003DzCyLjU7kvklZXzKoc1tvIbqI_003D(acadEnt, data);
																														}
																													}
																													else
																													{
																														entity = _0023_003DzXLLKSOs6xdvhYPXYbEPxBzY_003D(acadEnt, data);
																													}
																												}
																												else
																												{
																													entity = _0023_003DzupvYi0kCH_ek2UKtrcJjEYE_003D(acadEnt, data);
																												}
																											}
																											else
																											{
																												entity = _0023_003Dz8o9K3AQsX_Pg(acadEnt, data);
																											}
																										}
																										else
																										{
																											entity = _0023_003DzqU4SkO0ywgTRXO8Juw_003D_003D(acadEnt, data);
																										}
																									}
																									else
																									{
																										entity = _0023_003Dz0n90n2mwIcfa(acadEnt, data);
																									}
																								}
																								else
																								{
																									entity = _0023_003Dzv9rB_Zczmw_00241AlsB4A_003D_003D(acadEnt, data);
																								}
																							}
																							else
																							{
																								entity = _0023_003DzE2cDbKNHwfao(acadEnt, data);
																							}
																						}
																						else
																						{
																							entity = _0023_003DzSXMU0dQ_003D(acadEnt, data);
																						}
																					}
																					else
																					{
																						entity = _0023_003Dzzfv5ud5Q7Vjx(acadEnt, data);
																					}
																				}
																				else
																				{
																					entity = _0023_003Dz2yNAXYFMS7cC(acadEnt, data);
																				}
																			}
																			else
																			{
																				entity = _0023_003Dzwf1AJds_003D(acadEnt, data);
																			}
																		}
																		else
																		{
																			entity = _0023_003Dz91Oip9I_003D(acadEnt, data);
																		}
																	}
																	else
																	{
																		entity = _0023_003DzGwaiBnjz_0024xA325bJqA_003D_003D(acadEnt, data);
																	}
																}
																else
																{
																	entity = _0023_003Dzmlxh6Zp7VTDY9s7TqA_003D_003D(acadEnt, 3, data);
																}
															}
															else
															{
																entity = _0023_003DzOKC_0024IVHoTSQTS_0024JjXQ_003D_003D(acadEnt, 2, data, null);
															}
														}
														else
														{
															entity = _0023_003Dz3s5b9FD9vpP9(acadEnt, data);
														}
													}
													else
													{
														entity = _0023_003Dz5CdLd7v7OGLN(acadEnt, data);
													}
												}
												else
												{
													entity = _0023_003DzGAqoqC0_003D(acadEnt, data);
												}
											}
											else
											{
												entity = _0023_003Dzu6ita20_003D(acadEnt, data);
											}
										}
										else
										{
											entity = _0023_003DzqARDB78_003D(acadEnt, data);
										}
									}
									else
									{
										entity = _0023_003DzUSSsvI8_003D(acadEnt, data);
									}
								}
								else
								{
									entity = _0023_003Dz82yjbJQ_003D(acadEnt, data);
								}
							}
							else
							{
								entity = _0023_003Dzxa8DEC1aew7G(acadEnt, data);
							}
						}
						else
						{
							entity = _0023_003DzvbtMFR4_003D(acadEnt, data);
						}
					}
					else
					{
						entity = _0023_003DzTzXUPNdaO6lx(acadEnt, data);
					}
				}
				else
				{
					entity = _0023_003Dz4fs2aIs_003D(acadEnt, data);
				}
			}
			else
			{
				entity = _0023_003DzgfcWre0_003D(acadEnt, data);
			}
			if (entity != null)
			{
				if (entity.TranslationID == null)
				{
					entity.TranslationID = new TranslationIdentifier(acadEnt.handle().ToUInt64());
				}
				list.Add(entity);
			}
		}
		catch (Exception ex)
		{
			log.AppendLine(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355529123), acadEnt.GetType(), _0023_003Dz2jlzUDbXSA47Py_0024dGg_003D_003D(acadEnt)));
			log.AppendLine(ex.Message);
		}
		finally
		{
			MemoryManager.GetMemoryManager().StopTransaction(value);
		}
		return list;
	}

	private Entity _0023_003Dzh7bgWrunoTj3(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDbOle2Frame odDbOle2Frame = _0023_003DzkeRlGGg30I6n as OdDbOle2Frame;
		OdRectangle3d odRectangle3d = new OdRectangle3d();
		odDbOle2Frame.position(odRectangle3d);
		Plane xY = Plane.XY;
		xY.Origin = new Point3D(_0023_003DzGa_t9CAQQGhs(odRectangle3d.lowLeft));
		Ole2Frame ole2Frame;
		if (_0023_003DzeKBoJ8x7l7lu06ydfA_003D_003D(odDbOle2Frame, out var _0023_003DzWMzhDlA_003D))
		{
			ole2Frame = new Ole2Frame(xY, odDbOle2Frame.wcsWidth(), odDbOle2Frame.wcsHeight(), _0023_003Dz0UqjDJRVjznU032ZobZyG6sRUxOwSxYhJCJ1_WxsRxkgAkSSjABO220_003D._0023_003DzaVgi1iC1WyuS(_0023_003DzWMzhDlA_003D));
			_0023_003DzWMzhDlA_003D.Dispose();
		}
		else
		{
			ole2Frame = new Ole2Frame(xY, odDbOle2Frame.wcsWidth(), odDbOle2Frame.wcsHeight(), _0023_003Dz0UqjDJRVjznU032ZobZyG6sRUxOwSxYhJCJ1_WxsRxkgAkSSjABO220_003D._0023_003DzaVgi1iC1WyuS(_0023_003DzNGJdu02KWVn_00241Ytyrg_003D_003D()));
		}
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(ole2Frame, _0023_003DzkeRlGGg30I6n, _0023_003DzbONi0CI_003D);
		return ole2Frame;
	}

	private static Bitmap _0023_003DzNGJdu02KWVn_00241Ytyrg_003D_003D()
	{
		int num = 256;
		Bitmap bitmap = new Bitmap(num, num, PixelFormat.Format24bppRgb);
		using System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap);
		Font font = new Font(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355529106), 10f, FontStyle.Regular);
		try
		{
			Rectangle rectangle = new Rectangle(0, 0, num, num);
			StringFormat format = new StringFormat
			{
				Alignment = StringAlignment.Center,
				LineAlignment = StringAlignment.Center
			};
			graphics.FillRectangle(Brushes.White, rectangle);
			graphics.DrawString(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355529190), font, Brushes.Black, rectangle, format);
			return bitmap;
		}
		finally
		{
			((IDisposable)font).Dispose();
		}
	}

	private bool _0023_003DzeKBoJ8x7l7lu06ydfA_003D_003D(OdDbOle2Frame _0023_003DzrDeXy7Ygh9bN, out Image _0023_003DzWMzhDlA_003D)
	{
		MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
		bool result = false;
		_0023_003DzWMzhDlA_003D = null;
		OdOleItemHandler itemHandler = _0023_003DzrDeXy7Ygh9bN.getItemHandler();
		if (itemHandler != null)
		{
			OdGiRasterImage raster = itemHandler.getRaster();
			if (raster != null)
			{
				OdRxRasterServices odRxRasterServices = (OdRxRasterServices)TD_RootIntegrated_Globals.odrxDynamicLinker().loadModule(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355529201));
				if (odRxRasterServices.isRasterImageTypeSupported(541544016u))
				{
					MemoryStream memoryStream = new MemoryStream();
					OdMemoryStream odMemoryStream = OdMemoryStream.createNew();
					odRxRasterServices.convertRasterImage(raster, 541544016u, odMemoryStream);
					_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003Dz_0024Ri82GA5O_VX(odMemoryStream, memoryStream);
					_0023_003DzWMzhDlA_003D = new Bitmap(memoryStream);
					result = true;
				}
			}
			else
			{
				OdBinaryData odBinaryData = new OdBinaryData();
				if (OdOleItemHandlerBase.cast(itemHandler).getWmfData(odBinaryData))
				{
					MemoryStream stream = new MemoryStream(odBinaryData.ToArray());
					_0023_003DzWMzhDlA_003D = new Bitmap(stream);
					result = true;
				}
			}
		}
		MemoryManager.GetMemoryManager().StopTransaction(value);
		return result;
	}

	private Entity _0023_003DzSXMU0dQ_003D(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDbTable odDbTable = (OdDbTable)_0023_003DzkeRlGGg30I6n;
		Vector3D vector3D = new Vector3D(_0023_003Dzw_7skJnLqq6B(odDbTable.direction()));
		Vector3D a = new Vector3D(_0023_003Dzw_7skJnLqq6B(odDbTable.normal()));
		Plane plane = new Plane(Point3D.Origin, vector3D, Vector3D.Cross(a, vector3D));
		Point3D origin = new Point3D(_0023_003DzGa_t9CAQQGhs(odDbTable.position()));
		plane.Origin = origin;
		Table.flowDirection direction = ((odDbTable.flowDirection() == OdDb_FlowDirection.kBtoT) ? Table.flowDirection.Up : Table.flowDirection.Down);
		int num = (int)odDbTable.numRows();
		int num2 = (int)odDbTable.numColumns();
		double[] array = new double[num];
		for (uint num3 = 0u; num3 < num; num3++)
		{
			array[num3] = odDbTable.rowHeight(num3);
		}
		double[] array2 = new double[num2];
		for (uint num4 = 0u; num4 < num2; num4++)
		{
			array2[num4] = odDbTable.columnWidth(num4);
		}
		Table table = new Table(plane, num, num2, array, array2, odDbTable.height(), direction);
		table.HorCellMargin = odDbTable.horzCellMargin();
		table.VerCellMargin = odDbTable.vertCellMargin();
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				_0023_003Dz6oQ7E7o_003D(odDbTable.textString(i, j, OdValue_FormatOption.kFormatOptionNone), out var _0023_003DzkfAOhIE_003D, out var _, out var _);
				table.SetTextString(i, j, _0023_003DzXWCKMf0_003D(_0023_003DzkfAOhIE_003D[0]));
				double num5 = odDbTable.textHeight((uint)i, (uint)j);
				table.SetTextHeight(i, j, num5);
				table.SetLineSpaceDistance(i, j, num5 * 5.0 / 3.0);
				string styleName = string.Empty;
				try
				{
					OdDbObjectId odDbObjectId = odDbTable.textStyle((uint)i, (uint)j);
					if (odDbObjectId != null && odDbObjectId.isValid())
					{
						OdDbObject odDbObject = odDbObjectId.safeOpenObject();
						if (odDbObject != null)
						{
							OdDbTextStyleTableRecord odDbTextStyleTableRecord = OdDbTextStyleTableRecord.cast(odDbObject);
							if (odDbTextStyleTableRecord != null)
							{
								styleName = odDbTextStyleTableRecord.getName();
							}
						}
					}
				}
				catch (Exception ex)
				{
					log.AppendLine(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355529176) + _0023_003Dz2jlzUDbXSA47Py_0024dGg_003D_003D(_0023_003DzkeRlGGg30I6n) + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528761) + ex.Message);
				}
				table.SetStyleName(i, j, styleName);
				OdDb_CellAlignment _0023_003Dz7_NmwEw_003D = odDbTable.alignment((uint)i, (uint)j);
				table.SetAlignment(i, j, WriteDatabase._0023_003DzdLpU2S3dmXwJOMRc8w_003D_003D(_0023_003Dz7_NmwEw_003D));
				if (odDbTable.isMergedCell((uint)i, (uint)j) && !table.IsMerged(i, j))
				{
					OdCellRange mergeRange = odDbTable.getMergeRange(i, j);
					table.MergeCells(mergeRange.m_topRow, mergeRange.m_leftColumn, mergeRange.m_bottomRow, mergeRange.m_rightColumn);
				}
			}
		}
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(table, odDbTable, _0023_003DzbONi0CI_003D);
		return table;
	}

	private static string _0023_003Dz2jlzUDbXSA47Py_0024dGg_003D_003D(OdDbEntity _0023_003DzkeRlGGg30I6n)
	{
		return _0023_003DzkeRlGGg30I6n.handle().ToString();
	}

	private Entity _0023_003DzZOLoqtN6sniqwwNb_0024A_003D_003D(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDbExtrudedSurface odDbExtrudedSurface = (OdDbExtrudedSurface)_0023_003DzkeRlGGg30I6n;
		ICurve obj = (ICurve)ReadEntity(odDbExtrudedSurface.getSweepEntity(), _0023_003DzbONi0CI_003D).First();
		Vector3D amount = new Vector3D(_0023_003Dzw_7skJnLqq6B(odDbExtrudedSurface.getSweepVec()));
		OdGeExtents3d odGeExtents3d = new OdGeExtents3d();
		_0023_003DzkeRlGGg30I6n.getGeomExtents(odGeExtents3d);
		Point3D minCorner = new Point3D(_0023_003DzGa_t9CAQQGhs(odGeExtents3d.minPoint()));
		Point3D maxCorner = new Point3D(_0023_003DzGa_t9CAQQGhs(odGeExtents3d.maxPoint()));
		double tolerance = new Size3D(minCorner, maxCorner).Diagonal * 0.001;
		OdDbSweepOptions odDbSweepOptions = new OdDbSweepOptions();
		odDbExtrudedSurface.getSweepOptions(odDbSweepOptions);
		Entity entity = obj.ExtrudeAsBrep(amount, odDbSweepOptions.draftAngle(), tolerance);
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(entity, _0023_003DzkeRlGGg30I6n, _0023_003DzbONi0CI_003D);
		return entity;
	}

	private Entity _0023_003DzIJwwhE0_003D(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		if (_0023_003DzbONi0CI_003D.overallVportId == null || _0023_003DzbONi0CI_003D.overallVportId.Equals(_0023_003DzkeRlGGg30I6n.objectId()))
		{
			return null;
		}
		OdDbViewport odDbViewport = (OdDbViewport)_0023_003DzkeRlGGg30I6n;
		_0023_003Dz8yEBIUw_003D _0023_003Dz8yEBIUw_003D2 = default(_0023_003Dz8yEBIUw_003D);
		_0023_003Dz8yEBIUw_003D2._0023_003DzqwjRtc4_003D = new Vector3D(_0023_003Dzw_7skJnLqq6B(odDbViewport.viewDirection()));
		_0023_003Dz8yEBIUw_003D2._0023_003DzqwjRtc4_003D.Normalize();
		Transformation.AutocadOCS(_0023_003Dz8yEBIUw_003D2._0023_003DzqwjRtc4_003D, out var xAxis, out var yAxis);
		yAxis.TransformBy(new Rotation(0.0 - odDbViewport.twistAngle(), _0023_003Dz8yEBIUw_003D2._0023_003DzqwjRtc4_003D));
		_0023_003Dz8yEBIUw_003D2._0023_003DzGIOjdZFVwcx_0024Ivu3jw_003D_003D = odDbViewport.lensLength();
		_0023_003Dz8yEBIUw_003D2._0023_003DzUiEKVrs_003D = odDbViewport.viewDirection().length();
		_0023_003Dz8yEBIUw_003D2._0023_003Dz_8qkpR8_003D = new Point3D(_0023_003DzGa_t9CAQQGhs(odDbViewport.viewTarget())) + odDbViewport.viewCenter().x * xAxis + odDbViewport.viewCenter().y * yAxis;
		_0023_003Dz8yEBIUw_003D2._0023_003DzlIUGZKw_003D = new Vector3D(yAxis.ToArray());
		_0023_003Dz8yEBIUw_003D2._0023_003DzRMsJ77myYf6B = (odDbViewport.isPerspectiveOn() ? projectionType.Perspective : projectionType.Orthographic);
		double num = odDbViewport.width();
		double num2 = odDbViewport.height();
		_0023_003Dz8yEBIUw_003D2._0023_003Dza9v8qfWmqzIi = new SizeF(100f, 100f);
		Size _0023_003DztM0ty0k_003D = new Size(100, 100);
		Camera camera = new Camera();
		_0023_003Dz8yEBIUw_003D2._0023_003DznJnOZYQ_003D(camera, _0023_003DztM0ty0k_003D);
		Point3D point3D = new Point3D(_0023_003DzGa_t9CAQQGhs(odDbViewport.centerPoint()));
		linearUnitsType toUnits = WriteDatabase._0023_003DzCpSZHkwMYNQHhZOwlA_003D_003D(_0023_003DzbONi0CI_003D.database.getINSUNITS());
		double linearUnitsConversionFactor = Utility.GetLinearUnitsConversionFactor(_0023_003DzbONi0CI_003D.sheet.Units, toUnits);
		double num3 = odDbViewport.customScale() * linearUnitsConversionFactor;
		if (_0023_003DzbONi0CI_003D.layoutPlotScale != 1.0)
		{
			num3 *= _0023_003DzbONi0CI_003D.layoutPlotScale;
			point3D *= _0023_003DzbONi0CI_003D.layoutPlotScale;
			num *= _0023_003DzbONi0CI_003D.layoutPlotScale;
			num2 *= _0023_003DzbONi0CI_003D.layoutPlotScale;
		}
		OdGiVisualStyle_Type odGiVisualStyle_Type = ((OdDbVisualStyle)odDbViewport.visualStyle().safeOpenObject(OdDb_OpenMode.kForRead)).type();
		VectorView vectorView = new VectorView(point3D.X, point3D.Y, camera, num3, odDbViewport.getDbHandle().ToString(), num, num2);
		switch (odGiVisualStyle_Type)
		{
		case OdGiVisualStyle_Type.k2DWireframe:
		case OdGiVisualStyle_Type.k3DWireframe:
		case OdGiVisualStyle_Type.kHidden:
			vectorView.HiddenSegments = true;
			break;
		case OdGiVisualStyle_Type.kFlat:
		case OdGiVisualStyle_Type.kFlatWithEdges:
		case OdGiVisualStyle_Type.kRealistic:
		case OdGiVisualStyle_Type.kConceptual:
		case OdGiVisualStyle_Type.kShadedWithEdges:
		case OdGiVisualStyle_Type.kShaded:
			vectorView.Shaded = true;
			break;
		}
		vectorView.visualStyleMode = _0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzzNCQc50QBJ_Z(odGiVisualStyle_Type);
		vectorView.CenterlinesExtensionAmount = Math.Min(_0023_003DzbONi0CI_003D.sheet.Width, _0023_003DzbONi0CI_003D.sheet.Height) / 200.0;
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(vectorView, _0023_003DzkeRlGGg30I6n, _0023_003DzbONi0CI_003D);
		return vectorView;
	}

	private Entity _0023_003Dzu6ita20_003D(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDbMText odDbMText = (OdDbMText)_0023_003DzkeRlGGg30I6n;
		string _0023_003DznhuxS9c_003D = odDbMText.contents();
		double num = odDbMText.textHeight();
		double[] coords = _0023_003DzGa_t9CAQQGhs(odDbMText.location());
		_0023_003Dz6oQ7E7o_003D(_0023_003DznhuxS9c_003D, out var _0023_003DzkfAOhIE_003D, out var _0023_003DzTVQPgYS29BHqNSYpYg_003D_003D, out var _0023_003Dz_YsdXPvAzPPU);
		_0023_003DzkfAOhIE_003D[0] = _0023_003Dz4cn91DTf979eZenc8x6vkCA_003D(_0023_003DzkfAOhIE_003D[0]);
		double lineSpaceDistance = odDbMText.lineSpacingFactor() * num * 5.0 / 3.0;
		Text.alignmentType alignment = WriteDatabase._0023_003DzdLpU2S3dmXwJOMRc8w_003D_003D(odDbMText.attachment());
		double num2 = odDbMText.rotation();
		Point3D insPoint = new Point3D(coords);
		if (odDbMText.flowDirection() == OdDbMText_FlowDirection.kBtoT)
		{
			num2 += Math.PI / 2.0;
		}
		Plane plane = _0023_003DzH0a_I2VUM1u4(_0023_003Dzw_7skJnLqq6B(odDbMText.normal()));
		plane.Rotate(num2, plane.AxisZ, plane.Origin);
		string styleName = OdDbTextStyleTableRecord.cast(odDbMText.textStyle().safeOpenObject()).getName();
		if (!string.IsNullOrEmpty(_0023_003Dz_YsdXPvAzPPU))
		{
			string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(_0023_003Dz_YsdXPvAzPPU);
			if (!_0023_003DzbONi0CI_003D.importedTextStyles.Contains(fileNameWithoutExtension))
			{
				string xRefName = string.Empty;
				if (!string.IsNullOrEmpty(_0023_003DzbONi0CI_003D.xrefPrefix))
				{
					xRefName = _0023_003DzbONi0CI_003D.xrefPrefix.Substring(0, _0023_003DzbONi0CI_003D.xrefPrefix.Length - 1);
				}
				_0023_003DzbONi0CI_003D.importedTextStyles.Add(new TextStyle(fileNameWithoutExtension, string.Empty, fontStyle.Regular)
				{
					FileName = _0023_003Dz_YsdXPvAzPPU,
					XRefName = xRefName
				});
			}
			styleName = fileNameWithoutExtension;
		}
		MultilineText multilineText = new MultilineText(plane, insPoint, _0023_003DzXWCKMf0_003D(_0023_003DzkfAOhIE_003D[0]), odDbMText.width(), num, lineSpaceDistance, alignment, styleName);
		multilineText.RectHeight = odDbMText.height();
		multilineText.Contents = odDbMText.contents();
		if (_0023_003DzTVQPgYS29BHqNSYpYg_003D_003D != null)
		{
			multilineText.WidthFactors = _0023_003DzTVQPgYS29BHqNSYpYg_003D_003D;
		}
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(multilineText, odDbMText, _0023_003DzbONi0CI_003D);
		if (multilineText.TextString.Trim().Length > 0)
		{
			return multilineText;
		}
		log.AppendLine(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528718), _0023_003Dz2jlzUDbXSA47Py_0024dGg_003D_003D(_0023_003DzkeRlGGg30I6n)));
		return null;
	}

	private Entity _0023_003DzcnV3Yqk_4GfJfeIJ_0024Q_003D_003D(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D, StringBuilder _0023_003DzzrdjZl2m7SBp)
	{
		OdDbRasterImage odDbRasterImage = _0023_003DzkeRlGGg30I6n as OdDbRasterImage;
		Image image = null;
		OdDbObjectId odDbObjectId = odDbRasterImage.imageDefId();
		if (odDbObjectId.isNull())
		{
			log.AppendLine(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528769), _0023_003Dz2jlzUDbXSA47Py_0024dGg_003D_003D(_0023_003DzkeRlGGg30I6n)));
			return null;
		}
		if (!(odDbObjectId.openObject() is OdDbRasterImageDef odDbRasterImageDef))
		{
			log.AppendLine(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528769), _0023_003Dz2jlzUDbXSA47Py_0024dGg_003D_003D(_0023_003DzkeRlGGg30I6n)));
			return null;
		}
		string text = null;
		if (!SkipExternalReferences)
		{
			text = _0023_003DzqDR_0024H00_003D(odDbRasterImageDef.sourceFileName());
		}
		if (text != null)
		{
			image = _0023_003Dz0UqjDJRVjznU032ZobZyG6sRUxOwSxYhJCJ1_WxsRxkgAkSSjABO220_003D._0023_003DzHqA41XsvbPrvw10xf4xdAeg_003D(text);
		}
		else
		{
			OdGiRasterImage odGiRasterImage = odDbRasterImageDef.image();
			if (odGiRasterImage == null)
			{
				log.AppendLine(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528769), _0023_003Dz2jlzUDbXSA47Py_0024dGg_003D_003D(_0023_003DzkeRlGGg30I6n)));
				return null;
			}
			OdRxRasterServices odRxRasterServices = (OdRxRasterServices)TD_RootIntegrated_Globals.odrxDynamicLinker().loadModule(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355529201));
			if (odRxRasterServices.isRasterImageTypeSupported(541544016u))
			{
				MemoryStream memoryStream = new MemoryStream();
				OdMemoryStream odMemoryStream = OdMemoryStream.createNew();
				odRxRasterServices.convertRasterImage(odGiRasterImage, 541544016u, odMemoryStream);
				_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003Dz_0024Ri82GA5O_VX(odMemoryStream, memoryStream);
				image = new Bitmap(memoryStream);
			}
		}
		OdGePoint3d odGePoint3d = new OdGePoint3d();
		OdGeVector3d odGeVector3d = new OdGeVector3d();
		OdGeVector3d odGeVector3d2 = new OdGeVector3d();
		odDbRasterImage.getOrientation(odGePoint3d, odGeVector3d, odGeVector3d2);
		Plane plane = new Plane(new Point3D(_0023_003DzGa_t9CAQQGhs(odGePoint3d)), new Vector3D(_0023_003Dzw_7skJnLqq6B(odGeVector3d)), new Vector3D(_0023_003Dzw_7skJnLqq6B(odGeVector3d2)));
		Picture picture = new Picture(plane, odGeVector3d.length(), odGeVector3d2.length(), _0023_003Dz0UqjDJRVjznU032ZobZyG6sRUxOwSxYhJCJ1_WxsRxkgAkSSjABO220_003D._0023_003DzaVgi1iC1WyuS(image))
		{
			FilePath = text
		};
		picture.Lighted = false;
		if (odDbRasterImage.isClipped() && odDbRasterImage.clipBoundaryType() != OdDbRasterImage_ClipBoundaryType.kInvalid)
		{
			_0023_003DzkF84oEO3Z3Qv(odDbRasterImage, plane, out var _0023_003DzskxOEYNUHHY7siOxtA29cx_0024WA4nT);
			picture.ClippingBoundary = new Polygon2D(_0023_003DzskxOEYNUHHY7siOxtA29cx_0024WA4nT);
			picture.ShowClipped = true;
		}
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(picture, odDbRasterImage, _0023_003DzbONi0CI_003D);
		if (_0023_003DzMURU_tpi4kUl((Bitmap)image))
		{
			picture.Color = Color.FromArgb(254, picture.Color);
		}
		image?.Dispose();
		return picture;
	}

	private string _0023_003DzqDR_0024H00_003D(string _0023_003DzyTMhpZk_003D)
	{
		if (string.IsNullOrEmpty(_0023_003DzyTMhpZk_003D))
		{
			return null;
		}
		if (File.Exists(_0023_003DzyTMhpZk_003D))
		{
			return _0023_003DzyTMhpZk_003D;
		}
		string fileName = System.IO.Path.GetFileName(_0023_003DzyTMhpZk_003D);
		if (File.Exists(fileName))
		{
			return fileName;
		}
		if (!string.IsNullOrEmpty(base.Path))
		{
			string text = System.IO.Path.Combine(base.Path, _0023_003DzyTMhpZk_003D);
			if (File.Exists(text))
			{
				return text;
			}
			text = System.IO.Path.Combine(base.Path, fileName);
			if (File.Exists(text))
			{
				return text;
			}
		}
		if (SearchFolders != null)
		{
			foreach (string searchFolder in SearchFolders)
			{
				if (!string.IsNullOrEmpty(searchFolder))
				{
					string text2 = System.IO.Path.Combine(searchFolder, _0023_003DzyTMhpZk_003D);
					if (File.Exists(text2))
					{
						return text2;
					}
					text2 = System.IO.Path.Combine(searchFolder, fileName);
					if (File.Exists(text2))
					{
						return text2;
					}
				}
			}
		}
		return null;
	}

	private void _0023_003DzkF84oEO3Z3Qv(OdDbRasterImage _0023_003Dz_Rb8fcgtWILR, Plane _0023_003Dzo8w7NkRh8mbR, out List<Point2D> _0023_003DzskxOEYNUHHY7siOxtA29cx_0024WA4nT)
	{
		List<OdGePoint2d> list = _0023_003Dz_Rb8fcgtWILR.clipBoundary().ToList();
		if (list.Count == 2)
		{
			list.Insert(1, new OdGePoint2d(list[0].x, list[1].y));
			list.Add(new OdGePoint2d(list[2].x, list[0].y));
			list.Add(list[0]);
		}
		List<Point3D> list2 = new List<Point3D>();
		List<System.Drawing.Point> list3 = new List<System.Drawing.Point>();
		OdGeMatrix3d pixelToModelTransform = _0023_003Dz_Rb8fcgtWILR.getPixelToModelTransform();
		for (int i = 0; i < list.Count; i++)
		{
			list3.Add(new System.Drawing.Point((int)list[i].x, (int)list[i].y));
			OdGePoint3d odGePoint3d = new OdGePoint3d(list[i].x, list[i].y, 0.0);
			odGePoint3d = pixelToModelTransform * odGePoint3d;
			list2.Add(new Point3D(odGePoint3d.x, odGePoint3d.y, odGePoint3d.z));
		}
		_0023_003DzskxOEYNUHHY7siOxtA29cx_0024WA4nT = new List<Point2D>();
		foreach (Point3D item in list2)
		{
			_0023_003DzskxOEYNUHHY7siOxtA29cx_0024WA4nT.Add(_0023_003Dzo8w7NkRh8mbR.Project(item));
		}
	}

	private static bool _0023_003DzMURU_tpi4kUl(Bitmap _0023_003DzWMzhDlA_003D)
	{
		for (int i = 0; i < _0023_003DzWMzhDlA_003D.Height; i++)
		{
			for (int j = 0; j < _0023_003DzWMzhDlA_003D.Width; j++)
			{
				if (_0023_003DzWMzhDlA_003D.GetPixel(j, i).A != byte.MaxValue)
				{
					return true;
				}
			}
		}
		return false;
	}

	private static IEnumerable<Entity> _0023_003Dze_00246PNCw_003D(OdDbEntity _0023_003DzkeRlGGg30I6n, List<Entity> _0023_003DzhytBlFc_003D, IList<Entity> _0023_003DzYKrMumHnP74y)
	{
		if (_0023_003DzYKrMumHnP74y != null && _0023_003DzYKrMumHnP74y.Count > 0)
		{
			foreach (Entity item in _0023_003DzYKrMumHnP74y)
			{
				item.TranslationID = new TranslationIdentifier(_0023_003DzkeRlGGg30I6n.handle().ToUInt64());
			}
			_0023_003DzhytBlFc_003D.AddRange(_0023_003DzYKrMumHnP74y);
		}
		return _0023_003DzhytBlFc_003D;
	}

	private Entity _0023_003Dzme9MJA7SX8i7(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDbSubDMesh obj = (OdDbSubDMesh)_0023_003DzkeRlGGg30I6n;
		OdInt32Array odInt32Array = new OdInt32Array();
		obj.getFaceArray(odInt32Array);
		OdGePoint3dArray odGePoint3dArray = new OdGePoint3dArray();
		obj.getVertices(odGePoint3dArray);
		OdGePoint3dArray odGePoint3dArray2 = new OdGePoint3dArray();
		obj.getVertexTextureArray(odGePoint3dArray2);
		OdCmEntityColorArray odCmEntityColorArray = new OdCmEntityColorArray();
		obj.getVertexColorArray(odCmEntityColorArray);
		bool flag = odGePoint3dArray2.Count > 0;
		bool flag2 = odCmEntityColorArray.Count > 0;
		Dictionary<int, int> dictionary = null;
		List<IndexTriangle> list = new List<IndexTriangle>();
		Point3D[] array;
		if (flag)
		{
			List<Point3D> list2 = new List<Point3D>(odGePoint3dArray.Count);
			Dictionary<Point3D, int> dictionary2 = new Dictionary<Point3D, int>(odGePoint3dArray.Count);
			dictionary = new Dictionary<int, int>();
			for (int i = 0; i < odGePoint3dArray.Count; i++)
			{
				Point3D point3D = _0023_003DzHLWQmn1CvBx2(odGePoint3dArray[i]);
				if (!dictionary2.TryGetValue(point3D, out var value))
				{
					list2.Add(point3D);
					value = list2.Count - 1;
					dictionary2.Add(point3D, value);
				}
				dictionary.Add(i, value);
			}
			array = list2.ToArray();
		}
		else
		{
			array = new Point3D[odGePoint3dArray.Count];
			for (int j = 0; j < odGePoint3dArray.Count; j++)
			{
				Point3D point3D2 = _0023_003DzHLWQmn1CvBx2(odGePoint3dArray[j]);
				if (flag2)
				{
					OdCmEntityColor odCmEntityColor = odCmEntityColorArray[j];
					point3D2 = new PointRGB(point3D2.X, point3D2.Y, point3D2.Z, odCmEntityColor.red(), odCmEntityColor.green(), odCmEntityColor.blue());
				}
				array[j] = point3D2;
			}
		}
		int num;
		for (int k = 0; k < odInt32Array.Count; k += num + 1)
		{
			num = odInt32Array[k];
			switch (num)
			{
			case 3:
				if (flag)
				{
					list.Add(new RichTriangle(dictionary[odInt32Array[k + 1]], dictionary[odInt32Array[k + 2]], dictionary[odInt32Array[k + 3]], odInt32Array[k + 1], odInt32Array[k + 2], odInt32Array[k + 3]));
				}
				else
				{
					list.Add(new IndexTriangle(odInt32Array[k + 1], odInt32Array[k + 2], odInt32Array[k + 3]));
				}
				continue;
			case 4:
				if (flag)
				{
					list.Add(new RichTriangle(dictionary[odInt32Array[k + 1]], dictionary[odInt32Array[k + 2]], dictionary[odInt32Array[k + 3]], odInt32Array[k + 1], odInt32Array[k + 2], odInt32Array[k + 3]));
					list.Add(new RichTriangle(dictionary[odInt32Array[k + 1]], dictionary[odInt32Array[k + 3]], dictionary[odInt32Array[k + 4]], odInt32Array[k + 1], odInt32Array[k + 3], odInt32Array[k + 4]));
				}
				else
				{
					list.Add(new IndexTriangle(odInt32Array[k + 1], odInt32Array[k + 2], odInt32Array[k + 3]));
					list.Add(new IndexTriangle(odInt32Array[k + 1], odInt32Array[k + 3], odInt32Array[k + 4]));
				}
				continue;
			}
			Point3D[] array2 = new Point3D[num + 1];
			int[] array3 = new int[num];
			for (int l = 0; l < num; l++)
			{
				array2[l] = array[array3[l] = odInt32Array[k + 1 + l]];
			}
			array2[num] = (Point3D)array2[0].Clone();
			Mesh mesh = Mesh.CreatePlanar(array2, Mesh.natureType.Plain);
			for (int m = 0; m < mesh.Triangles.Length; m++)
			{
				IndexTriangle indexTriangle = mesh.Triangles[m];
				if (flag)
				{
					list.Add(new RichTriangle(array3[indexTriangle.V1], array3[indexTriangle.V2], array3[indexTriangle.V3], array3[indexTriangle.V1], array3[indexTriangle.V2], array3[indexTriangle.V3]));
				}
				else
				{
					list.Add(new IndexTriangle(array3[indexTriangle.V1], array3[indexTriangle.V2], array3[indexTriangle.V3]));
				}
			}
		}
		if (array.Length == 0)
		{
			throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528881));
		}
		if (list.Count == 0)
		{
			throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528939));
		}
		Mesh mesh2 = new Mesh(array, list);
		if (flag)
		{
			PointF[] array4 = new PointF[odGePoint3dArray2.Count];
			for (int n = 0; n < odGePoint3dArray2.Count; n++)
			{
				OdGePoint3d odGePoint3d = odGePoint3dArray2[n];
				array4[n] = new PointF((float)odGePoint3d.x, 0f - (float)odGePoint3d.y);
			}
			mesh2.TextureCoords = array4;
		}
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(mesh2, _0023_003DzkeRlGGg30I6n, _0023_003DzbONi0CI_003D);
		return mesh2;
	}

	private IList<Entity> _0023_003Dzu0K6_fhNncbf(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDbMInsertBlock odDbMInsertBlock = (OdDbMInsertBlock)_0023_003DzkeRlGGg30I6n;
		IList<Entity> list = new List<Entity>(odDbMInsertBlock.rows() * odDbMInsertBlock.columns());
		Plane plane = _0023_003DzH0a_I2VUM1u4(_0023_003Dzw_7skJnLqq6B(odDbMInsertBlock.normal()));
		Entity entity = _0023_003DzE2cDbKNHwfao(_0023_003DzkeRlGGg30I6n, _0023_003DzbONi0CI_003D);
		Vector3D vector3D = new Vector3D((plane.AxisX * odDbMInsertBlock.columnSpacing()).ToArray());
		Vector3D vector3D2 = new Vector3D((plane.AxisY * odDbMInsertBlock.rowSpacing()).ToArray());
		for (int i = 0; i < odDbMInsertBlock.rows(); i++)
		{
			for (int j = 0; j < odDbMInsertBlock.columns(); j++)
			{
				Entity entity2 = (Entity)entity.Clone();
				Vector3D v = new Vector3D((vector3D2 * i + vector3D * j).ToArray());
				entity2.Translate(v);
				list.Add(entity2);
			}
		}
		return list;
	}

	private Entity _0023_003DzWIlB49Q_003D(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		string unusedBlockName = Utility.GetUnusedBlockName(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528898), _0023_003DzbONi0CI_003D.importedBlocks);
		Block block = new Block(unusedBlockName);
		bool _0023_003DzKCTdf4c3hOS;
		Transformation _0023_003Dz48r_sMY_003D;
		OdBrBrep brep = _0023_003DzEwYKhLt7NDCd(_0023_003DzkeRlGGg30I6n, out _0023_003DzKCTdf4c3hOS, out _0023_003Dz48r_sMY_003D);
		try
		{
			OdBrBrepComplexTraverser odBrBrepComplexTraverser = new OdBrBrepComplexTraverser();
			odBrBrepComplexTraverser.setBrep(brep);
			while (!odBrBrepComplexTraverser.done())
			{
				OdBrComplex complex = odBrBrepComplexTraverser.getComplex();
				OdBrComplexShellTraverser odBrComplexShellTraverser = new OdBrComplexShellTraverser();
				odBrComplexShellTraverser.setComplex(complex);
				while (!odBrComplexShellTraverser.done())
				{
					OdBrShell shell = odBrComplexShellTraverser.getShell();
					OdBrShellFaceTraverser odBrShellFaceTraverser = new OdBrShellFaceTraverser();
					odBrShellFaceTraverser.setShell(shell);
					while (!odBrShellFaceTraverser.done())
					{
						OdBrFace face = odBrShellFaceTraverser.getFace();
						try
						{
							List<ICurve> list = new List<ICurve>();
							if (_0023_003DzNP_0024lO5Q_003D(face, list, Simplify, log, _0023_003Dz2jlzUDbXSA47Py_0024dGg_003D_003D(_0023_003DzkeRlGGg30I6n)))
							{
								Plane plane = _0023_003DziAN0in7_0024XoL67A4_3ga535k_003D(face, list);
								if (plane != null)
								{
									for (int i = 0; i < list.Count; i++)
									{
										ICurve[] individualCurves = list[i].GetIndividualCurves();
										double num = ((IEnumerable<ICurve>)individualCurves).Min((Func<ICurve, double>)_0023_003DzE18LVS0_003D._0023_003Dz8VglJ9E_003D._0023_003Dzsv64DXxQEDmtzN3FPVNkJiI_003D) / 10.0;
										if (individualCurves.Length >= 2 && individualCurves[0].StartPoint.DistanceTo(individualCurves[1].EndPoint) < num)
										{
											individualCurves[1].Reverse();
										}
										for (int j = 0; j < individualCurves.Length; j++)
										{
											ICurve curve = individualCurves[j];
											ICurve curve2 = individualCurves[(j + 1) % individualCurves.Length];
											if (curve.EndPoint.DistanceTo(curve2.EndPoint) < num)
											{
												curve2.Reverse();
											}
											if (curve.StartPoint.DistanceTo(curve2.StartPoint) < num)
											{
												curve.Reverse();
											}
										}
										list[i] = Utility.SmartAdd(individualCurves);
									}
									if (face.getOrientToSurface())
									{
										foreach (ICurve item2 in list)
										{
											item2.Reverse();
										}
									}
									devDept.Eyeshot.Entities.Region item = new devDept.Eyeshot.Entities.Region(list, plane);
									block.Entities.Add(item);
								}
							}
						}
						catch
						{
						}
						odBrShellFaceTraverser.next();
					}
					odBrComplexShellTraverser.next();
				}
				odBrBrepComplexTraverser.next();
			}
		}
		catch
		{
		}
		if (_0023_003DzKCTdf4c3hOS)
		{
			foreach (Entity entity in block.Entities)
			{
				entity.TransformBy(_0023_003Dz48r_sMY_003D);
			}
		}
		if (block.Entities.Count > 1)
		{
			_0023_003DzbONi0CI_003D.importedBlocks.Add(block);
			BlockReferenceEx blockReferenceEx = new BlockReferenceEx(0.0, 0.0, 0.0, unusedBlockName, 1.0, 1.0, 1.0, 0.0);
			_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(blockReferenceEx, _0023_003DzkeRlGGg30I6n, _0023_003DzbONi0CI_003D);
			return blockReferenceEx;
		}
		if (block.Entities.Count == 1)
		{
			_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(block.Entities[0], _0023_003DzkeRlGGg30I6n, _0023_003DzbONi0CI_003D);
			return block.Entities[0];
		}
		log.AppendLine(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528919), _0023_003Dz2jlzUDbXSA47Py_0024dGg_003D_003D(_0023_003DzkeRlGGg30I6n)));
		return null;
	}

	private Plane _0023_003DziAN0in7_0024XoL67A4_3ga535k_003D(OdBrFace _0023_003DzILwyq_00243CBdkJ, List<ICurve> _0023_003DzNvMb1bmdJzAs)
	{
		OdGeSurface surface = _0023_003DzILwyq_00243CBdkJ.getSurface();
		if (surface == null)
		{
			return null;
		}
		using OdGeExternalBoundedSurface odGeExternalBoundedSurface = new OdGeExternalBoundedSurface();
		odGeExternalBoundedSurface.Assign(surface);
		OdGeSurface baseSurfaceEx = odGeExternalBoundedSurface.getBaseSurfaceEx();
		bool orientToSurface = _0023_003DzILwyq_00243CBdkJ.getOrientToSurface();
		OdGe_EntityId num = baseSurfaceEx.type();
		Surface[] array = null;
		if (num == OdGe_EntityId.kPlane)
		{
			array = _0023_003DzksommBsQBI_0024jVfIvTg_003D_003D(baseSurfaceEx, _0023_003DzNvMb1bmdJzAs, orientToSurface);
		}
		Plane result = null;
		if (array != null && array[0] is PlanarSurface planarSurface)
		{
			result = planarSurface.Plane;
		}
		return result;
	}

	private List<Entity> _0023_003DzF_Uo3rSbkPr8(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDbMline obj = _0023_003DzkeRlGGg30I6n as OdDbMline;
		OdRxObjectPtrArray odRxObjectPtrArray = new OdRxObjectPtrArray();
		obj.explode(odRxObjectPtrArray);
		return _0023_003Dzf3Sn_0024qY_003D(odRxObjectPtrArray, _0023_003DzbONi0CI_003D);
	}

	private BlockReference _0023_003Dzp1f0xCzNeiq3Mm1muA_003D_003D(ReadEntityData _0023_003DzbONi0CI_003D, OdDbEntity _0023_003DzkeRlGGg30I6n, string _0023_003Dzxaw56Ac_003D, _0023_003DzWg_GllqbCaSBVuqy5w_003D_003D _0023_003DzZgDnC_EYv4azzQnpnQ_003D_003D, bool _0023_003DzdwSdD4s_003D)
	{
		OdRxObjectPtrArray _0023_003DzowwVrrs_003D = new OdRxObjectPtrArray();
		if (_0023_003DzZgDnC_EYv4azzQnpnQ_003D_003D(_0023_003DzowwVrrs_003D) == OdResult.eOk)
		{
			List<Entity> collection = _0023_003Dz5yJkLxTlLY0bLFiPag_003D_003D(_0023_003DzowwVrrs_003D, _0023_003DzbONi0CI_003D);
			string text = _0023_003Dzxaw56Ac_003D + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355529482) + _0023_003Dz2jlzUDbXSA47Py_0024dGg_003D_003D(_0023_003DzkeRlGGg30I6n);
			Block block = new Block(text);
			block.BlockSource = autodeskSourceType.Exploded;
			block.Entities.AddRange(collection);
			_0023_003DzbONi0CI_003D.importedBlocks.Add(block);
			BlockReferenceEx blockReferenceEx = new BlockReferenceEx(0.0, 0.0, 0.0, text, 1.0, 1.0, 1.0, 0.0);
			_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(blockReferenceEx, _0023_003DzkeRlGGg30I6n, _0023_003DzbONi0CI_003D);
			return blockReferenceEx;
		}
		return null;
	}

	private List<Entity> _0023_003Dz5yJkLxTlLY0bLFiPag_003D_003D(OdRxObjectPtrArray _0023_003DzowwVrrs_003D, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		List<Entity> list = new List<Entity>();
		foreach (OdRxObject item in _0023_003DzowwVrrs_003D)
		{
			IEnumerable<Entity> enumerable = null;
			enumerable = ((item is OdDb2dPolyline) ? new List<Entity>(new Entity[1] { _0023_003Dz_0024C7gR8uKJx_0OL4Gkt2pTMM7BrDT((OdDb2dPolyline)item, 2, _0023_003DzbONi0CI_003D) }) : ((!(item is OdDbPolyline)) ? ReadEntity((OdDbEntity)item, _0023_003DzbONi0CI_003D) : new List<Entity>(new Entity[1] { _0023_003DzOKC_0024IVHoTSQTS_0024JjXQ_003D_003D((OdDbPolyline)item, 2, _0023_003DzbONi0CI_003D, null) })));
			if (enumerable != null && enumerable.Any())
			{
				list.AddRange(enumerable);
			}
			item.Dispose();
		}
		return list;
	}

	private List<Entity> _0023_003Dzf3Sn_0024qY_003D(OdRxObjectPtrArray _0023_003DzowwVrrs_003D, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		List<Entity> list = new List<Entity>();
		foreach (OdRxObject item in _0023_003DzowwVrrs_003D)
		{
			List<Entity> list2 = (List<Entity>)ReadEntity((OdDbEntity)item, _0023_003DzbONi0CI_003D);
			if (list2 != null && list2.Count > 0)
			{
				list.AddRange(list2);
			}
			item.Dispose();
		}
		return list;
	}

	private Entity _0023_003DzHAL6kVk_003D(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDbTrace odDbTrace = _0023_003DzkeRlGGg30I6n as OdDbTrace;
		List<Point3D> list = new List<Point3D>(5);
		OdGePoint3d odGePoint3d = new OdGePoint3d();
		odDbTrace.getPointAt(0, odGePoint3d);
		list.Add(_0023_003DzHLWQmn1CvBx2(odGePoint3d));
		odGePoint3d = new OdGePoint3d();
		odDbTrace.getPointAt(1, odGePoint3d);
		Point3D point3D = _0023_003DzHLWQmn1CvBx2(odGePoint3d);
		if (!(list.Last().DistanceTo(point3D) <= 1E-12))
		{
			list.Add(point3D);
		}
		odGePoint3d = new OdGePoint3d();
		odDbTrace.getPointAt(3, odGePoint3d);
		point3D = _0023_003DzHLWQmn1CvBx2(odGePoint3d);
		if (!(list.Last().DistanceTo(point3D) <= 1E-12))
		{
			list.Add(point3D);
		}
		odGePoint3d = new OdGePoint3d();
		odDbTrace.getPointAt(2, odGePoint3d);
		point3D = _0023_003DzHLWQmn1CvBx2(odGePoint3d);
		if (!(list.Last().DistanceTo(point3D) <= 1E-12))
		{
			list.Add(point3D);
		}
		LinearPath outer = new LinearPath(list);
		Hatch hatch = new Hatch(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528962), outer);
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(hatch, odDbTrace, _0023_003DzbONi0CI_003D);
		return hatch;
	}

	private Entity _0023_003Dz_99JNGI_003D(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		if (ExplodeHatches)
		{
			return _0023_003Dzp1f0xCzNeiq3Mm1muA_003D_003D(_0023_003DzbONi0CI_003D, _0023_003DzkeRlGGg30I6n, _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355529472), _0023_003DzkeRlGGg30I6n.explodeGeometry, _0023_003DzdwSdD4s_003D: false);
		}
		OdDbHatch odDbHatch = _0023_003DzkeRlGGg30I6n as OdDbHatch;
		string text;
		if (odDbHatch.isGradient())
		{
			text = _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528962);
		}
		else
		{
			text = odDbHatch.patternName();
			OdDbHatch_HatchPatternType odDbHatch_HatchPatternType = odDbHatch.patternType();
			if (odDbHatch_HatchPatternType != OdDbHatch_HatchPatternType.kUserDefined && !base.HatchPatterns.Contains(text))
			{
				OdHatchPattern odHatchPattern = new OdHatchPattern();
				MeasurementValue mEASUREMENT = _0023_003DzbONi0CI_003D.database.getMEASUREMENT();
				if (_0023_003DzbONi0CI_003D.database.appServices().patternManager().retrievePattern(odDbHatch_HatchPatternType, text, mEASUREMENT, odHatchPattern) != OdResult.eOk)
				{
					odHatchPattern = odDbHatch.getPattern();
				}
				base.HatchPatterns.Add(_0023_003DznWm91K7jiDDU(text, odHatchPattern));
			}
		}
		List<ICurve> list = new List<ICurve>();
		OdGePlane odGePlane = new OdGePlane();
		odDbHatch.getPlane(odGePlane, out var _);
		Plane plane = _0023_003DzcZqeHueEnhjO(odGePlane);
		for (int i = 0; i < odDbHatch.numLoops(); i++)
		{
			OdDbHatch_HatchLoopType odDbHatch_HatchLoopType = (OdDbHatch_HatchLoopType)odDbHatch.loopTypeAt(i);
			if ((odDbHatch_HatchLoopType & OdDbHatch_HatchLoopType.kPolyline) == OdDbHatch_HatchLoopType.kPolyline)
			{
				OdGePoint2dArray odGePoint2dArray = new OdGePoint2dArray();
				OdDoubleArray odDoubleArray = new OdDoubleArray();
				odDbHatch.getLoopAt(i, odGePoint2dArray, odDoubleArray);
				OdDbPolyline odDbPolyline = OdDbPolyline.createObject();
				odDbPolyline.reset(reuse: false, (uint)(odGePoint2dArray.Count + 1));
				OdGePoint2d odGePoint2d = new OdGePoint2d();
				if (odDoubleArray.Count > 0)
				{
					double bulge = double.NaN;
					for (int j = 0; j < odGePoint2dArray.Count; j++)
					{
						odDbPolyline.addVertexAt((uint)j, odGePoint2dArray[j], odDoubleArray[j], 0.0, 0.0);
						if (j == 0)
						{
							odGePoint2d = new OdGePoint2d(odGePoint2dArray[j]);
							bulge = odDoubleArray[j];
						}
					}
					if (odGePoint2d != null)
					{
						odDbPolyline.addVertexAt((uint)odGePoint2dArray.Count, odGePoint2d, bulge, 0.0, 0.0);
					}
				}
				else
				{
					for (int k = 0; k < odGePoint2dArray.Count; k++)
					{
						odDbPolyline.addVertexAt((uint)k, odGePoint2dArray[k]);
						if (k == 0)
						{
							odGePoint2d = new OdGePoint2d(odGePoint2dArray[k]);
						}
					}
					if (odGePoint2d != null)
					{
						odDbPolyline.addVertexAt((uint)odGePoint2dArray.Count, odGePoint2d);
					}
				}
				ICurve item = _0023_003DzOKC_0024IVHoTSQTS_0024JjXQ_003D_003D(odDbPolyline, 2, _0023_003DzbONi0CI_003D, plane) as ICurve;
				list.Add(item);
				continue;
			}
			OdArray_OdGeCurve2d__p_OdObjectsAllocator odArray_OdGeCurve2d__p_OdObjectsAllocator = new OdArray_OdGeCurve2d__p_OdObjectsAllocator();
			odDbHatch.getLoopAt(i, odArray_OdGeCurve2d__p_OdObjectsAllocator);
			List<ICurve> list2 = new List<ICurve>();
			for (int l = 0; l < odArray_OdGeCurve2d__p_OdObjectsAllocator.Count; l++)
			{
				OdGeCurve2d odGeCurve2d = odArray_OdGeCurve2d__p_OdObjectsAllocator[l];
				switch (odGeCurve2d.type())
				{
				case OdGe_EntityId.kLineSeg2d:
				{
					OdGeLineSeg2d odGeLineSeg2d = new OdGeLineSeg2d(OdGeCurve2d.getCPtr(odGeCurve2d).Handle, cMemoryOwn: false);
					Point2D point2D = new Point2D(odGeLineSeg2d.startPoint().x, odGeLineSeg2d.startPoint().y);
					Point2D point2D2 = new Point2D(odGeLineSeg2d.endPoint().x, odGeLineSeg2d.endPoint().y);
					if (Point2D.DistanceSquared(point2D, point2D2) < 1E-12)
					{
						break;
					}
					Line line = new Line(plane.PointAt(point2D), plane.PointAt(point2D2));
					foreach (ICurve item2 in list2)
					{
						if (item2 is Line && Point3D.Distance(item2.StartPoint, line.StartPoint) < 1E-12 && Point3D.Distance(item2.EndPoint, line.EndPoint) < 1E-12)
						{
							log.AppendLine(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355529492), _0023_003Dz2jlzUDbXSA47Py_0024dGg_003D_003D(odDbHatch), odGeCurve2d));
							return null;
						}
					}
					list2.Add(line);
					break;
				}
				case OdGe_EntityId.kCircArc2d:
				{
					OdGeCircArc2d odGeCircArc2d = new OdGeCircArc2d(OdGeCurve2d.getCPtr(odGeCurve2d).Handle, cMemoryOwn: false);
					Point2D point2D3 = new Point2D(odGeCircArc2d.center().x, odGeCircArc2d.center().y);
					Plane plane3 = plane;
					double startAngleInRadians = odGeCircArc2d.startAng();
					double endAngleInRadians = odGeCircArc2d.endAng();
					if (odGeCircArc2d.isClockWise())
					{
						plane3 = new Plane(plane.Origin, plane.AxisX, -1.0 * plane.AxisY);
						point2D3 = plane3.Project(plane.PointAt(point2D3));
					}
					if (Utility.AreEqual(odGeCircArc2d.endAng() - odGeCircArc2d.startAng(), Math.PI * 2.0, Math.PI * 2.0))
					{
						list2.Add(new Circle(plane3, point2D3, odGeCircArc2d.radius()));
					}
					else
					{
						list2.Add(new Arc(plane3, point2D3, odGeCircArc2d.radius(), startAngleInRadians, endAngleInRadians));
					}
					break;
				}
				case OdGe_EntityId.kEllipArc2d:
				{
					OdGeEllipArc2d odGeEllipArc2d = new OdGeEllipArc2d(OdGeCurve2d.getCPtr(odGeCurve2d).Handle, cMemoryOwn: false);
					Point2D pt = new Point2D(odGeEllipArc2d.center().x, odGeEllipArc2d.center().y);
					Point2D pt2 = new Point2D(odGeEllipArc2d.majorAxis().x, odGeEllipArc2d.majorAxis().y);
					Point2D pt3 = new Point2D(odGeEllipArc2d.minorAxis().x, odGeEllipArc2d.minorAxis().y);
					Vector3D vector3D = Vector3D.Subtract(plane.PointAt(pt2), plane.Origin);
					Vector3D vector3D2 = Vector3D.Subtract(plane.PointAt(pt3), plane.Origin);
					vector3D.Normalize();
					vector3D2.Normalize();
					Plane plane2 = new Plane(plane.Origin, vector3D, vector3D2);
					pt = plane2.Project(plane.PointAt(pt));
					if (Utility.AreEqual(odGeEllipArc2d.endAng() - odGeEllipArc2d.startAng(), Math.PI * 2.0, Math.PI * 2.0))
					{
						list2.Add(new Ellipse(plane2, pt, odGeEllipArc2d.majorRadius(), odGeEllipArc2d.minorRadius()));
					}
					else
					{
						list2.Add(new EllipticalArc(plane2, pt, odGeEllipArc2d.majorRadius(), odGeEllipArc2d.minorRadius(), odGeEllipArc2d.startAng(), odGeEllipArc2d.endAng()));
					}
					break;
				}
				case OdGe_EntityId.kNurbCurve2d:
				{
					OdGeNurbCurve2d odGeNurbCurve2d = new OdGeNurbCurve2d(OdGeCurve2d.getCPtr(odGeCurve2d).Handle, cMemoryOwn: false);
					Point4D[] array = new Point4D[odGeNurbCurve2d.numControlPoints()];
					if (odGeNurbCurve2d.isRational())
					{
						for (int m = 0; m < array.Length; m++)
						{
							OdGePoint2d odGePoint2d2 = odGeNurbCurve2d.controlPointAt(m);
							double num = odGeNurbCurve2d.weightAt(m);
							Point3D point3D = plane.PointAt(odGePoint2d2.x, odGePoint2d2.y);
							array[m] = new Point4D(point3D.X * num, point3D.Y * num, point3D.Z * num, num);
						}
					}
					else
					{
						for (int n = 0; n < array.Length; n++)
						{
							OdGePoint2d odGePoint2d3 = odGeNurbCurve2d.controlPointAt(n);
							Point3D point3D2 = plane.PointAt(odGePoint2d3.x, odGePoint2d3.y);
							array[n] = new Point4D(point3D2.X, point3D2.Y, point3D2.Z);
						}
					}
					double[] array2 = new double[odGeNurbCurve2d.knots().length()];
					for (int num2 = 0; num2 < array2.Length; num2++)
					{
						array2[num2] = odGeNurbCurve2d.knots()[num2];
					}
					_0023_003DzCYNh9Kcs3g2AT3oIATp8_dIpegIE(odGeNurbCurve2d.degree(), array2, array, odGeNurbCurve2d.knots().tolerance(), out var _0023_003DzBz11kfnlOncl, out var _0023_003DzsZdQ_0024gi5lfQV);
					Entity entity = new Curve(odGeNurbCurve2d.degree(), _0023_003DzBz11kfnlOncl.ToArray(), _0023_003DzsZdQ_0024gi5lfQV.ToArray());
					list2.Add((ICurve)entity);
					break;
				}
				default:
					log.AppendLine(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355529647), _0023_003Dz2jlzUDbXSA47Py_0024dGg_003D_003D(_0023_003DzkeRlGGg30I6n), odGeCurve2d));
					return null;
				}
			}
			if (list2.Count > 1)
			{
				list.Add(new CompositeCurve(list2));
			}
			else if (list2.Count == 1)
			{
				list.Add(list2[0]);
			}
		}
		if (list.Count > 0)
		{
			Entity entity2 = new Hatch(text, list, plane)
			{
				PatternScale = (float)odDbHatch.patternScale(),
				PatternAngle = odDbHatch.patternAngle(),
				PatternOrigin = new Point2D(odDbHatch.originPoint().x, odDbHatch.originPoint().y),
				PatternSpacing = odDbHatch.patternSpace(),
				PatternDouble = odDbHatch.patternDouble(),
				IsUserDefinedPattern = (odDbHatch.patternType() == OdDbHatch_HatchPatternType.kUserDefined)
			};
			_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(entity2, odDbHatch, _0023_003DzbONi0CI_003D);
			return entity2;
		}
		log.AppendLine(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355529721), _0023_003Dz2jlzUDbXSA47Py_0024dGg_003D_003D(_0023_003DzkeRlGGg30I6n)));
		return null;
	}

	private HatchPattern _0023_003DznWm91K7jiDDU(string _0023_003Dzkwy7OiA_003D, OdHatchPattern _0023_003DzF88_auALWKXwXnd20A_003D_003D)
	{
		HatchPatternLine[] array = new HatchPatternLine[_0023_003DzF88_auALWKXwXnd20A_003D_003D.Count];
		for (int i = 0; i < array.Length; i++)
		{
			OdHatchPatternLine odHatchPatternLine = _0023_003DzF88_auALWKXwXnd20A_003D_003D[i];
			OdDoubleArray dashes = odHatchPatternLine.m_dashes;
			float[] array2 = new float[dashes.Count];
			for (int j = 0; j < dashes.Count; j++)
			{
				array2[j] = (float)dashes[j];
			}
			if (!LineType.CheckPattern(array2, throwEx: false, out var _))
			{
				array2 = new float[0];
			}
			OdGePoint2d basePoint = odHatchPatternLine.m_basePoint;
			array[i] = new HatchPatternLine(odHatchPatternLine.m_dLineAngle, new Point2D(basePoint.x, basePoint.y), odHatchPatternLine.m_patternOffset.x, odHatchPatternLine.m_patternOffset.y, array2);
		}
		return new HatchPattern(_0023_003Dzkwy7OiA_003D, array);
	}

	private void _0023_003DzWPDMCrM6XoprC621Cg_003D_003D(OdDbHatch _0023_003Dzc3fL4NWp3aL5)
	{
		if (!_0023_003Dzc3fL4NWp3aL5.associative())
		{
			return;
		}
		for (int i = 0; i < _0023_003Dzc3fL4NWp3aL5.numLoops(); i++)
		{
			OdDbObjectIdArray odDbObjectIdArray = new OdDbObjectIdArray();
			_0023_003Dzc3fL4NWp3aL5.getAssocObjIdsAt(i, odDbObjectIdArray);
			for (int j = 0; j < odDbObjectIdArray.Count; j++)
			{
				_0023_003Dzc3fL4NWp3aL5.markModifiedLoop(odDbObjectIdArray[j].getHandle());
			}
		}
		_0023_003Dzc3fL4NWp3aL5.updateMarkedLoops();
	}

	private Entity _0023_003DzQ2b3U6k1x__h(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		return _0023_003Dzp1f0xCzNeiq3Mm1muA_003D_003D(_0023_003DzbONi0CI_003D, _0023_003DzkeRlGGg30I6n, _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355529268), _0023_003DzkeRlGGg30I6n.explodeGeometry, _0023_003DzdwSdD4s_003D: true);
	}

	private Entity _0023_003DzgfcWre0_003D(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDbPoint odDbPoint = _0023_003DzkeRlGGg30I6n as OdDbPoint;
		double[] array = _0023_003DzGa_t9CAQQGhs(odDbPoint.position());
		devDept.Eyeshot.Entities.Point point = new devDept.Eyeshot.Entities.Point(array[0], array[1], array[2]);
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(point, odDbPoint, _0023_003DzbONi0CI_003D);
		return point;
	}

	private Entity _0023_003Dz4fs2aIs_003D(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDbLine odDbLine = _0023_003DzkeRlGGg30I6n as OdDbLine;
		double[] array = _0023_003DzGa_t9CAQQGhs(odDbLine.startPoint());
		double[] array2 = _0023_003DzGa_t9CAQQGhs(odDbLine.endPoint());
		Line line = new Line(array[0], array[1], array[2], array2[0], array2[1], array2[2]);
		Vector3D vector3D = new Vector3D(_0023_003Dzw_7skJnLqq6B(odDbLine.normal()));
		if (line.Length() < 1E-09)
		{
			devDept.Eyeshot.Entities.Point point = new devDept.Eyeshot.Entities.Point(line.StartPoint);
			_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(point, odDbLine, _0023_003DzbONi0CI_003D);
			point.AutodeskProperties.Thickness = odDbLine.thickness();
			point.AutodeskProperties.ExtrusionDir = vector3D;
			return point;
		}
		if (odDbLine.thickness() == 0.0 || !ExtrudeByThickness)
		{
			_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(line, odDbLine, _0023_003DzbONi0CI_003D);
			line.AutodeskProperties.Thickness = odDbLine.thickness();
			line.AutodeskProperties.ExtrusionDir = vector3D;
			return line;
		}
		Entity entity = line.ExtrudeAsBrep(vector3D * odDbLine.thickness());
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(entity, odDbLine, _0023_003DzbONi0CI_003D);
		return entity;
	}

	private Entity _0023_003DzTzXUPNdaO6lx(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDbXline odDbXline = _0023_003DzkeRlGGg30I6n as OdDbXline;
		Vector3D vector3D = new Vector3D(_0023_003Dzw_7skJnLqq6B(odDbXline.unitDir()));
		LinearEntity linearEntity = new LinearEntity(new Point3D(_0023_003DzGa_t9CAQQGhs(odDbXline.basePoint())), vector3D, vector3D.Length);
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(linearEntity, odDbXline, _0023_003DzbONi0CI_003D);
		return linearEntity;
	}

	private Entity _0023_003DzvbtMFR4_003D(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDbArc odDbArc = _0023_003DzkeRlGGg30I6n as OdDbArc;
		Plane arcPlane = _0023_003DzH0a_I2VUM1u4(_0023_003Dzw_7skJnLqq6B(odDbArc.normal()));
		double _0023_003DzONzW6RWWNdiX = odDbArc.endAngle();
		odDbArc.getArea(out var area);
		_0023_003DzmzlIUyaAej2P(odDbArc.startAngle(), ref _0023_003DzONzW6RWWNdiX, area);
		if (odDbArc.radius() > 1E-12)
		{
			Arc arc = new Arc(arcPlane, new Point3D(_0023_003DzGa_t9CAQQGhs(odDbArc.center())), odDbArc.radius(), odDbArc.startAngle(), _0023_003DzONzW6RWWNdiX);
			_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(arc, odDbArc, _0023_003DzbONi0CI_003D);
			Vector3D vector3D = new Vector3D(_0023_003Dzw_7skJnLqq6B(odDbArc.normal()));
			if (odDbArc.thickness() == 0.0 || !ExtrudeByThickness)
			{
				_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(arc, odDbArc, _0023_003DzbONi0CI_003D);
				arc.AutodeskProperties.Thickness = odDbArc.thickness();
				arc.AutodeskProperties.ExtrusionDir = vector3D;
				return arc;
			}
			Entity entity = arc.ExtrudeAsBrep(vector3D * odDbArc.thickness());
			_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(entity, odDbArc, _0023_003DzbONi0CI_003D);
			return entity;
		}
		log.AppendLine(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355529224), _0023_003Dz2jlzUDbXSA47Py_0024dGg_003D_003D(_0023_003DzkeRlGGg30I6n)));
		return null;
	}

	private static void _0023_003DzmzlIUyaAej2P(double _0023_003DzYBvuHTaq5ut2, ref double _0023_003DzONzW6RWWNdiX, double _0023_003DzC_0024gWkrs_003D)
	{
		if (_0023_003DzONzW6RWWNdiX < _0023_003DzYBvuHTaq5ut2)
		{
			_0023_003DzONzW6RWWNdiX += Math.PI * 2.0;
		}
		else if (Math.Abs(_0023_003DzONzW6RWWNdiX - _0023_003DzYBvuHTaq5ut2) < 1E-12)
		{
			if (!(_0023_003DzC_0024gWkrs_003D > 0.0))
			{
				throw new ArgumentException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355529284));
			}
			_0023_003DzONzW6RWWNdiX += Math.PI * 2.0;
		}
	}

	private Entity _0023_003Dzxa8DEC1aew7G(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDbCircle odDbCircle = _0023_003DzkeRlGGg30I6n as OdDbCircle;
		Plane plane = _0023_003DzH0a_I2VUM1u4(_0023_003Dzw_7skJnLqq6B(odDbCircle.normal()));
		if (odDbCircle.radius() > 1E-12)
		{
			Circle circle = new Circle(plane, new Point3D(_0023_003DzGa_t9CAQQGhs(odDbCircle.center())), odDbCircle.radius());
			Vector3D vector3D = new Vector3D(_0023_003Dzw_7skJnLqq6B(odDbCircle.normal()));
			_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(circle, odDbCircle, _0023_003DzbONi0CI_003D);
			if (odDbCircle.thickness() == 0.0 || !ExtrudeByThickness)
			{
				_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(circle, odDbCircle, _0023_003DzbONi0CI_003D);
				circle.AutodeskProperties.Thickness = odDbCircle.thickness();
				circle.AutodeskProperties.ExtrusionDir = vector3D;
				return circle;
			}
			Entity entity = circle.ExtrudeAsBrep(vector3D * odDbCircle.thickness());
			_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(entity, odDbCircle, _0023_003DzbONi0CI_003D);
			return entity;
		}
		log.AppendLine(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355529382), _0023_003Dz2jlzUDbXSA47Py_0024dGg_003D_003D(_0023_003DzkeRlGGg30I6n)));
		return null;
	}

	private Entity _0023_003Dz82yjbJQ_003D(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDbEllipse odDbEllipse = _0023_003DzkeRlGGg30I6n as OdDbEllipse;
		Vector3D xAxis = new Vector3D();
		Vector3D yAxis = new Vector3D();
		Transformation.AutocadOCS(new Vector3D(_0023_003Dzw_7skJnLqq6B(odDbEllipse.normal())), out xAxis, out yAxis);
		Vector3D vector3D = new Vector3D(_0023_003Dzw_7skJnLqq6B(odDbEllipse.majorAxis()));
		Vector3D vector3D2 = new Vector3D(_0023_003Dzw_7skJnLqq6B(odDbEllipse.minorAxis()));
		Plane arcPlane = new Plane(Point3D.Origin, vector3D, vector3D2);
		odDbEllipse.getEndParam(out var endParam);
		odDbEllipse.getStartParam(out var startParam);
		Utility.FixEndAngle(startParam, ref endParam);
		double length = vector3D.Length;
		double length2 = vector3D2.Length;
		if (length > 1E-12 && length2 > 1E-12)
		{
			EllipticalArc ellipticalArc = new EllipticalArc(arcPlane, new Point3D(_0023_003DzGa_t9CAQQGhs(odDbEllipse.center())), length, length2, startParam, endParam);
			_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(ellipticalArc, odDbEllipse, _0023_003DzbONi0CI_003D);
			return ellipticalArc;
		}
		log.AppendLine(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355529441), _0023_003Dz2jlzUDbXSA47Py_0024dGg_003D_003D(_0023_003DzkeRlGGg30I6n)));
		return null;
	}

	private Entity _0023_003DzqARDB78_003D(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDbText odDbText = _0023_003DzkeRlGGg30I6n as OdDbText;
		string _0023_003Dz20iFUs4_003D = odDbText.textString();
		double height = odDbText.height();
		OdDbMText_AttachmentPoint odDbMText_AttachmentPoint = WriteDatabase._0023_003DzJnBzRfvPGuCd(odDbText.horizontalMode(), odDbText.verticalMode());
		Text.alignmentType alignment = WriteDatabase._0023_003DzdLpU2S3dmXwJOMRc8w_003D_003D(odDbMText_AttachmentPoint);
		Plane plane = _0023_003DzH0a_I2VUM1u4(_0023_003Dzw_7skJnLqq6B(odDbText.normal()));
		plane.Rotate(odDbText.rotation(), plane.AxisZ, Point3D.Origin);
		double[] coords = _0023_003DzGa_t9CAQQGhs(odDbText.position());
		if (odDbMText_AttachmentPoint != OdDbMText_AttachmentPoint.kBaseLeft && odDbMText_AttachmentPoint != OdDbMText_AttachmentPoint.kBaseAlign && odDbMText_AttachmentPoint != OdDbMText_AttachmentPoint.kBaseFit)
		{
			coords = _0023_003DzGa_t9CAQQGhs(odDbText.alignmentPoint());
		}
		string name = OdDbTextStyleTableRecord.cast(odDbText.textStyle().safeOpenObject()).getName();
		Text text = new Text(plane, new Point3D(coords), _0023_003DzXWCKMf0_003D(_0023_003Dz20iFUs4_003D), height, alignment, name);
		text.Backward = odDbText.isMirroredInX();
		text.UpsideDown = odDbText.isMirroredInY();
		text.WidthFactor = odDbText.widthFactor();
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(text, odDbText, _0023_003DzbONi0CI_003D);
		if (text.TextString.Trim().Length > 0)
		{
			return text;
		}
		log.AppendLine(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532089), _0023_003Dz2jlzUDbXSA47Py_0024dGg_003D_003D(_0023_003DzkeRlGGg30I6n)));
		return null;
	}

	private string _0023_003Dz4cn91DTf979eZenc8x6vkCA_003D(string _0023_003DznhuxS9c_003D)
	{
		while (true)
		{
			int num = _0023_003DznhuxS9c_003D.IndexOf(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532147));
			if (num < 0)
			{
				break;
			}
			_0023_003DznhuxS9c_003D = string.Concat(_0023_003DznhuxS9c_003D.Substring(0, num), str2: _0023_003DznhuxS9c_003D.Substring(num + 2, _0023_003DznhuxS9c_003D.Length - num - 2), str1: Environment.NewLine);
		}
		return _0023_003DznhuxS9c_003D;
	}

	private AttributeReference _0023_003Dz1Ohp13c_003D(OdDbAttribute _0023_003DziC7BH_0024_00242YMJp, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		double height = _0023_003DziC7BH_0024_00242YMJp.height();
		OdDbMText_AttachmentPoint odDbMText_AttachmentPoint = WriteDatabase._0023_003DzJnBzRfvPGuCd(_0023_003DziC7BH_0024_00242YMJp.horizontalMode(), _0023_003DziC7BH_0024_00242YMJp.verticalMode());
		Text.alignmentType alignment = WriteDatabase._0023_003DzdLpU2S3dmXwJOMRc8w_003D_003D(odDbMText_AttachmentPoint);
		Plane plane = _0023_003DzH0a_I2VUM1u4(_0023_003Dzw_7skJnLqq6B(_0023_003DziC7BH_0024_00242YMJp.normal()));
		plane.Rotate(_0023_003DziC7BH_0024_00242YMJp.rotation(), plane.AxisZ, Point3D.Origin);
		Point3D insPoint = new Point3D(_0023_003DzGa_t9CAQQGhs(_0023_003DziC7BH_0024_00242YMJp.position()));
		if (odDbMText_AttachmentPoint != OdDbMText_AttachmentPoint.kBaseLeft && odDbMText_AttachmentPoint != OdDbMText_AttachmentPoint.kBaseAlign && odDbMText_AttachmentPoint != OdDbMText_AttachmentPoint.kBaseFit)
		{
			insPoint = new Point3D(_0023_003DzGa_t9CAQQGhs(_0023_003DziC7BH_0024_00242YMJp.alignmentPoint()));
		}
		AttributeReference attributeReference = new AttributeReference(plane, insPoint, _0023_003DzXWCKMf0_003D(_0023_003DziC7BH_0024_00242YMJp.textString()), height);
		attributeReference.Alignment = alignment;
		attributeReference.Backward = _0023_003DziC7BH_0024_00242YMJp.isMirroredInX();
		attributeReference.UpsideDown = _0023_003DziC7BH_0024_00242YMJp.isMirroredInY();
		attributeReference.WidthFactor = _0023_003DziC7BH_0024_00242YMJp.widthFactor();
		attributeReference.Constant = _0023_003DziC7BH_0024_00242YMJp.isConstant();
		attributeReference.Verify = _0023_003DziC7BH_0024_00242YMJp.isVerifiable();
		attributeReference.Preset = _0023_003DziC7BH_0024_00242YMJp.isPreset();
		OdDbTextStyleTableRecord odDbTextStyleTableRecord = OdDbTextStyleTableRecord.cast(_0023_003DziC7BH_0024_00242YMJp.textStyle().safeOpenObject());
		attributeReference.StyleName = odDbTextStyleTableRecord.getName();
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(attributeReference, _0023_003DziC7BH_0024_00242YMJp, _0023_003DzbONi0CI_003D);
		attributeReference.Invisible = _0023_003DziC7BH_0024_00242YMJp.isInvisible();
		return attributeReference;
	}

	private Entity _0023_003DzUSSsvI8_003D(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDbAttributeDefinition odDbAttributeDefinition = _0023_003DzkeRlGGg30I6n as OdDbAttributeDefinition;
		double height = odDbAttributeDefinition.height();
		OdDbMText_AttachmentPoint odDbMText_AttachmentPoint = WriteDatabase._0023_003DzJnBzRfvPGuCd(odDbAttributeDefinition.horizontalMode(), odDbAttributeDefinition.verticalMode());
		Text.alignmentType alignment = WriteDatabase._0023_003DzdLpU2S3dmXwJOMRc8w_003D_003D(odDbMText_AttachmentPoint);
		Plane plane = _0023_003DzH0a_I2VUM1u4(_0023_003Dzw_7skJnLqq6B(odDbAttributeDefinition.normal()));
		plane.Rotate(odDbAttributeDefinition.rotation(), plane.AxisZ, Point3D.Origin);
		double[] coords = _0023_003DzGa_t9CAQQGhs(odDbAttributeDefinition.position());
		if (odDbMText_AttachmentPoint != OdDbMText_AttachmentPoint.kBaseLeft && odDbMText_AttachmentPoint != OdDbMText_AttachmentPoint.kBaseAlign && odDbMText_AttachmentPoint != OdDbMText_AttachmentPoint.kBaseFit)
		{
			coords = _0023_003DzGa_t9CAQQGhs(odDbAttributeDefinition.alignmentPoint());
		}
		devDept.Eyeshot.Entities.Attribute attribute = new devDept.Eyeshot.Entities.Attribute(plane, new Point3D(coords), odDbAttributeDefinition.tag(), _0023_003DzXWCKMf0_003D(odDbAttributeDefinition.textString()), height);
		attribute.Alignment = alignment;
		attribute.Backward = odDbAttributeDefinition.isMirroredInX();
		attribute.UpsideDown = odDbAttributeDefinition.isMirroredInY();
		attribute.WidthFactor = odDbAttributeDefinition.widthFactor();
		attribute.Prompt = odDbAttributeDefinition.prompt();
		attribute.Constant = odDbAttributeDefinition.isConstant();
		attribute.Verify = odDbAttributeDefinition.isVerifiable();
		attribute.Preset = odDbAttributeDefinition.isPreset();
		OdDbTextStyleTableRecord odDbTextStyleTableRecord = OdDbTextStyleTableRecord.cast(odDbAttributeDefinition.textStyle().safeOpenObject());
		attribute.StyleName = odDbTextStyleTableRecord.getName();
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(attribute, odDbAttributeDefinition, _0023_003DzbONi0CI_003D);
		attribute.Invisible = odDbAttributeDefinition.isInvisible();
		return attribute;
	}

	private Entity _0023_003DzOKC_0024IVHoTSQTS_0024JjXQ_003D_003D(OdDbEntity _0023_003DzkeRlGGg30I6n, int _0023_003DzEfZmmLk_003D, ReadEntityData _0023_003DzbONi0CI_003D, Plane _0023_003DzSC8v7_00243sZDWr3FA0lg_003D_003D)
	{
		OdDbPolyline odDbPolyline = _0023_003DzkeRlGGg30I6n as OdDbPolyline;
		Plane plane = _0023_003DzSC8v7_00243sZDWr3FA0lg_003D_003D;
		if (plane == null)
		{
			plane = _0023_003DzH0a_I2VUM1u4(_0023_003Dzw_7skJnLqq6B(odDbPolyline.normal()));
		}
		bool _0023_003Dzkj9WVZBU2VIf = odDbPolyline.hasBulges();
		bool flag = odDbPolyline.thickness() != 0.0 && ExtrudeByThickness;
		ICurve curve = _0023_003DzOjD0VMDj5l0sOBc3OQ_003D_003D(odDbPolyline, _0023_003DzEfZmmLk_003D, (int)odDbPolyline.numVerts(), plane, _0023_003Dzkj9WVZBU2VIf, _0023_003DzbONi0CI_003D, flag);
		Vector3D vector3D = new Vector3D(_0023_003Dzw_7skJnLqq6B(odDbPolyline.normal()));
		if (!flag)
		{
			((Entity)curve).AutodeskProperties.Thickness = odDbPolyline.thickness();
			((Entity)curve).AutodeskProperties.ExtrusionDir = vector3D;
			_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(curve as Entity, odDbPolyline, _0023_003DzbONi0CI_003D);
			return (Entity)curve;
		}
		Entity entity = curve.ExtrudeAsBrep(vector3D * odDbPolyline.thickness());
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(entity, odDbPolyline, _0023_003DzbONi0CI_003D);
		return entity;
	}

	private Entity _0023_003Dz_0024C7gR8uKJx_0OL4Gkt2pTMM7BrDT(OdDb2dPolyline _0023_003DzsevUdI_0xNxAh3DB8g_003D_003D, int _0023_003DzEfZmmLk_003D, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		Plane plane = _0023_003DzH0a_I2VUM1u4(_0023_003Dzw_7skJnLqq6B(_0023_003DzsevUdI_0xNxAh3DB8g_003D_003D.normal()));
		int _0023_003DzU8E23YYcZBXYJ2E4ATB_00248hfmQR4C = 0;
		List<Point3D> list = new List<Point3D>();
		if (_0023_003DzN1YwVPg07UUt(_0023_003DzsevUdI_0xNxAh3DB8g_003D_003D, ref _0023_003DzU8E23YYcZBXYJ2E4ATB_00248hfmQR4C))
		{
			throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532104));
		}
		OdDbObjectIterator odDbObjectIterator = _0023_003DzsevUdI_0xNxAh3DB8g_003D_003D.vertexIterator();
		odDbObjectIterator.start();
		while (!odDbObjectIterator.done())
		{
			if (odDbObjectIterator.entity() is OdDb2dVertex odDb2dVertex)
			{
				_0023_003DzU8E23YYcZBXYJ2E4ATB_00248hfmQR4C++;
				list.Add(plane.PointAt(_0023_003DzbrHOvqc_003D(odDb2dVertex.position().x), _0023_003DzbrHOvqc_003D(odDb2dVertex.position().y), _0023_003DzbrHOvqc_003D(_0023_003DzsevUdI_0xNxAh3DB8g_003D_003D.elevation())));
			}
			odDbObjectIterator.step();
		}
		if (_0023_003DzsevUdI_0xNxAh3DB8g_003D_003D.isClosed())
		{
			list.Add((Point3D)list[0].Clone());
		}
		LinearPath linearPath = new LinearPath(list);
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(linearPath, _0023_003DzsevUdI_0xNxAh3DB8g_003D_003D, _0023_003DzbONi0CI_003D);
		if (_0023_003DzsevUdI_0xNxAh3DB8g_003D_003D.thickness() != 0.0)
		{
			linearPath.AutodeskProperties.Thickness = _0023_003DzsevUdI_0xNxAh3DB8g_003D_003D.thickness();
			Vector3D extrusionDir = new Vector3D(_0023_003Dzw_7skJnLqq6B(_0023_003DzsevUdI_0xNxAh3DB8g_003D_003D.normal()));
			linearPath.AutodeskProperties.ExtrusionDir = extrusionDir;
		}
		return linearPath;
	}

	private static bool _0023_003DzN1YwVPg07UUt(OdDb2dPolyline _0023_003DzAlG5XpA_003D, ref int _0023_003DzU8E23YYcZBXYJ2E4ATB_00248hfmQR4C)
	{
		bool result = false;
		OdDbObjectIterator odDbObjectIterator = _0023_003DzAlG5XpA_003D.vertexIterator();
		odDbObjectIterator.start();
		while (!odDbObjectIterator.done())
		{
			if (odDbObjectIterator.entity() is OdDb2dVertex odDb2dVertex)
			{
				_0023_003DzU8E23YYcZBXYJ2E4ATB_00248hfmQR4C++;
				if (odDb2dVertex.bulge() != 0.0)
				{
					result = true;
					break;
				}
			}
			odDbObjectIterator.step();
		}
		return result;
	}

	private Entity _0023_003Dzmlxh6Zp7VTDY9s7TqA_003D_003D(OdDbEntity _0023_003DzkeRlGGg30I6n, int _0023_003DzEfZmmLk_003D, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDb2dPolyline odDb2dPolyline = _0023_003DzkeRlGGg30I6n as OdDb2dPolyline;
		Plane _0023_003DzLodaGjk_003D = _0023_003DzH0a_I2VUM1u4(_0023_003Dzw_7skJnLqq6B(odDb2dPolyline.normal()));
		bool _0023_003Dzkj9WVZBU2VIf = false;
		int num = 0;
		OdDbObjectIterator odDbObjectIterator = odDb2dPolyline.vertexIterator();
		odDbObjectIterator.start();
		while (!odDbObjectIterator.done())
		{
			if (odDbObjectIterator.entity() is OdDb2dVertex odDb2dVertex && odDb2dVertex.vertexType() != OdDb_Vertex2dType.k2dSplineCtlVertex)
			{
				num++;
				if (odDb2dVertex.bulge() != 0.0)
				{
					_0023_003Dzkj9WVZBU2VIf = true;
				}
			}
			odDbObjectIterator.step();
		}
		bool flag = odDb2dPolyline.thickness() != 0.0 && ExtrudeByThickness;
		ICurve curve = _0023_003DzOjD0VMDj5l0sOBc3OQ_003D_003D(odDb2dPolyline, _0023_003DzEfZmmLk_003D, num, _0023_003DzLodaGjk_003D, _0023_003Dzkj9WVZBU2VIf, _0023_003DzbONi0CI_003D, flag);
		Vector3D vector3D = new Vector3D(_0023_003Dzw_7skJnLqq6B(odDb2dPolyline.normal()));
		if (!flag)
		{
			_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(curve as Entity, odDb2dPolyline, _0023_003DzbONi0CI_003D);
			((Entity)curve).AutodeskProperties.Thickness = odDb2dPolyline.thickness();
			((Entity)curve).AutodeskProperties.ExtrusionDir = vector3D;
			return curve as Entity;
		}
		Entity entity = curve.ExtrudeAsBrep(vector3D * odDb2dPolyline.thickness());
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(entity, odDb2dPolyline, _0023_003DzbONi0CI_003D);
		return entity;
	}

	private ICurve _0023_003DzOjD0VMDj5l0sOBc3OQ_003D_003D(OdDbCurve _0023_003Dz2sGQlCl4Dn5kRUYgHg_003D_003D, int _0023_003DzEfZmmLk_003D, int _0023_003DzAz2pnjDjhARR_0024_0024lPbw_003D_003D, Plane _0023_003DzLodaGjk_003D, bool _0023_003Dzkj9WVZBU2VIf, ReadEntityData _0023_003DzbONi0CI_003D, bool _0023_003DzL04pSrB_0024Upb_7Vp1JQ_003D_003D)
	{
		OdGeExtents3d odGeExtents3d = new OdGeExtents3d();
		_0023_003Dz2sGQlCl4Dn5kRUYgHg_003D_003D.getGeomExtents(odGeExtents3d);
		double domainSize = Point3D.Distance(_0023_003DzHLWQmn1CvBx2(odGeExtents3d.minPoint()), _0023_003DzHLWQmn1CvBx2(odGeExtents3d.maxPoint()));
		if (!_0023_003Dzkj9WVZBU2VIf)
		{
			List<Point3D> list = new List<Point3D>();
			double globalWidth;
			if (_0023_003DzEfZmmLk_003D == 2)
			{
				OdDbPolyline odDbPolyline = _0023_003Dz2sGQlCl4Dn5kRUYgHg_003D_003D as OdDbPolyline;
				globalWidth = odDbPolyline.getConstantWidth();
				for (int i = 0; i < _0023_003DzAz2pnjDjhARR_0024_0024lPbw_003D_003D; i++)
				{
					OdGePoint2d odGePoint2d = new OdGePoint2d();
					odDbPolyline.getPointAt((uint)(i % _0023_003DzAz2pnjDjhARR_0024_0024lPbw_003D_003D), odGePoint2d);
					list.Add(_0023_003DzLodaGjk_003D.PointAt(_0023_003DzbrHOvqc_003D(odGePoint2d.x), _0023_003DzbrHOvqc_003D(odGePoint2d.y), _0023_003DzbrHOvqc_003D(odDbPolyline.elevation())));
				}
			}
			else
			{
				OdDb2dPolyline odDb2dPolyline = _0023_003Dz2sGQlCl4Dn5kRUYgHg_003D_003D as OdDb2dPolyline;
				globalWidth = odDb2dPolyline.defaultStartWidth();
				OdDbObjectIterator odDbObjectIterator = odDb2dPolyline.vertexIterator();
				odDbObjectIterator.start();
				while (!odDbObjectIterator.done())
				{
					if (odDbObjectIterator.entity() is OdDb2dVertex odDb2dVertex && odDb2dVertex.vertexType() != OdDb_Vertex2dType.k2dSplineCtlVertex)
					{
						globalWidth = odDb2dVertex.startWidth();
						OdGePoint3d odGePoint3d = odDb2dVertex.position();
						list.Add(_0023_003DzLodaGjk_003D.PointAt(_0023_003DzbrHOvqc_003D(odGePoint3d.x), _0023_003DzbrHOvqc_003D(odGePoint3d.y), _0023_003DzbrHOvqc_003D(odDb2dPolyline.elevation())));
					}
					odDbObjectIterator.step();
				}
			}
			if (_0023_003DzL04pSrB_0024Upb_7Vp1JQ_003D_003D)
			{
				list = Utility.RemoveDuplicates(list).ToList();
			}
			LinearPath linearPath = new LinearPath(list);
			if (_0023_003Dz2sGQlCl4Dn5kRUYgHg_003D_003D.isClosed() && !linearPath.IsClosed)
			{
				list.Add((Point3D)list[0].Clone());
				linearPath.Vertices = list.ToArray();
			}
			linearPath.GlobalWidth = globalWidth;
			_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(linearPath, _0023_003Dz2sGQlCl4Dn5kRUYgHg_003D_003D, _0023_003DzbONi0CI_003D);
			return linearPath;
		}
		List<ICurve> list2 = new List<ICurve>();
		OdGePoint2d[] array = null;
		OdGePoint3d[] array2 = null;
		double[] array3 = new double[_0023_003DzAz2pnjDjhARR_0024_0024lPbw_003D_003D];
		double _0023_003Dzdc1k2Kc_003D;
		if (_0023_003DzEfZmmLk_003D == 2)
		{
			OdDbPolyline odDbPolyline2 = _0023_003Dz2sGQlCl4Dn5kRUYgHg_003D_003D as OdDbPolyline;
			_0023_003Dzdc1k2Kc_003D = odDbPolyline2.elevation();
			array = new OdGePoint2d[_0023_003DzAz2pnjDjhARR_0024_0024lPbw_003D_003D];
			for (int j = 0; j < _0023_003DzAz2pnjDjhARR_0024_0024lPbw_003D_003D; j++)
			{
				array[j] = new OdGePoint2d();
				odDbPolyline2.getPointAt((uint)j, array[j]);
				array3[j] = odDbPolyline2.getBulgeAt((uint)j);
			}
		}
		else
		{
			OdDb2dPolyline obj = _0023_003Dz2sGQlCl4Dn5kRUYgHg_003D_003D as OdDb2dPolyline;
			_0023_003Dzdc1k2Kc_003D = obj.elevation();
			int num = 0;
			array2 = new OdGePoint3d[_0023_003DzAz2pnjDjhARR_0024_0024lPbw_003D_003D];
			OdDbObjectIterator odDbObjectIterator2 = obj.vertexIterator();
			odDbObjectIterator2.start();
			while (!odDbObjectIterator2.done())
			{
				if (odDbObjectIterator2.objectId().openObject(OdDb_OpenMode.kForRead, openErasedOne: false) is OdDb2dVertex odDb2dVertex2 && odDb2dVertex2.vertexType() != OdDb_Vertex2dType.k2dSplineCtlVertex)
				{
					array2[num] = odDb2dVertex2.position();
					array3[num++] = odDb2dVertex2.bulge();
				}
				odDbObjectIterator2.step();
			}
		}
		int num2 = (_0023_003Dz2sGQlCl4Dn5kRUYgHg_003D_003D.isClosed() ? (_0023_003DzAz2pnjDjhARR_0024_0024lPbw_003D_003D + 1) : _0023_003DzAz2pnjDjhARR_0024_0024lPbw_003D_003D);
		for (int k = 0; k < num2 - 1; k++)
		{
			Point2D point2D;
			Point2D point2D2;
			if (_0023_003DzEfZmmLk_003D == 2)
			{
				point2D = new Point2D(_0023_003DzGa_t9CAQQGhs(array[k]));
				point2D2 = new Point2D(_0023_003DzGa_t9CAQQGhs(array[(k + 1) % _0023_003DzAz2pnjDjhARR_0024_0024lPbw_003D_003D]));
			}
			else
			{
				point2D = new Point2D(_0023_003DzGa_t9CAQQGhs(array2[k]));
				point2D2 = new Point2D(_0023_003DzGa_t9CAQQGhs(array2[(k + 1) % _0023_003DzAz2pnjDjhARR_0024_0024lPbw_003D_003D]));
			}
			if (Point2D.AreEqual(point2D, point2D2, domainSize))
			{
				continue;
			}
			double num3 = array3[k];
			if (Math.Abs(num3) < 1E-12)
			{
				Line item = new Line(_0023_003DzLodaGjk_003D.PointAt(_0023_003DzbrHOvqc_003D(point2D.X), _0023_003DzbrHOvqc_003D(point2D.Y), _0023_003DzbrHOvqc_003D(_0023_003Dzdc1k2Kc_003D)), _0023_003DzLodaGjk_003D.PointAt(_0023_003DzbrHOvqc_003D(point2D2.X), _0023_003DzbrHOvqc_003D(point2D2.Y), _0023_003DzbrHOvqc_003D(_0023_003Dzdc1k2Kc_003D)));
				list2.Add(item);
				continue;
			}
			double length = Vector2D.Subtract(point2D2, point2D).Length;
			if (length > 0.0)
			{
				double num4 = length / 2.0 * num3;
				double num5 = (length / 2.0 * (length / 2.0) + num4 * num4) / (2.0 * num4);
				double num6 = num5 - num4;
				double num7 = Math.Atan(num3) * 4.0;
				Point2D point2D3 = point2D + 0.5 * (point2D2 - point2D);
				Vector2D vector2D = new Vector2D(0.0 - (point2D2.Y - point2D.Y), point2D2.X - point2D.X);
				vector2D.Normalize();
				Vector2D vector2D2 = num6 * vector2D;
				Point2D point2D4 = new Point2D(point2D3.X + vector2D2.X, point2D3.Y + vector2D2.Y);
				double num8 = Utility.ArcTanProblem(point2D.X - point2D4.X, point2D.Y - point2D4.Y);
				if (Math.Abs(num5) > 1E-12 && Math.Abs(num7) > 1E-12)
				{
					Arc item2 = new Arc(_0023_003DzLodaGjk_003D, _0023_003DzLodaGjk_003D.PointAt(_0023_003DzbrHOvqc_003D(point2D4.X), _0023_003DzbrHOvqc_003D(point2D4.Y), _0023_003DzbrHOvqc_003D(_0023_003Dzdc1k2Kc_003D)), Math.Abs(num5), num8, num8 + num7);
					list2.Add(item2);
				}
			}
		}
		if (list2.Count == 0)
		{
			return null;
		}
		CompositeCurve compositeCurve = new CompositeCurve(list2, sortAndOrient: false);
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(compositeCurve, _0023_003Dz2sGQlCl4Dn5kRUYgHg_003D_003D, _0023_003DzbONi0CI_003D);
		return compositeCurve;
	}

	private Entity _0023_003DzGwaiBnjz_0024xA325bJqA_003D_003D(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDb3dPolyline odDb3dPolyline = _0023_003DzkeRlGGg30I6n as OdDb3dPolyline;
		OdDb_Poly3dType odDb_Poly3dType = odDb3dPolyline.polyType();
		List<Point3D> list = new List<Point3D>();
		List<Point3D> list2 = new List<Point3D>();
		OdDbObjectIterator odDbObjectIterator = odDb3dPolyline.vertexIterator();
		odDbObjectIterator.start();
		while (!odDbObjectIterator.done())
		{
			if (odDbObjectIterator.entity() is OdDb3dPolylineVertex odDb3dPolylineVertex)
			{
				if (odDb3dPolylineVertex.vertexType() == OdDb_Vertex3dType.k3dControlVertex)
				{
					list.Add(new Point3D(_0023_003DzGa_t9CAQQGhs(odDb3dPolylineVertex.position())));
				}
				else
				{
					list2.Add(new Point3D(_0023_003DzGa_t9CAQQGhs(odDb3dPolylineVertex.position())));
				}
			}
			odDbObjectIterator.step();
		}
		if (odDb3dPolyline.isClosed())
		{
			odDb_Poly3dType = OdDb_Poly3dType.k3dSimplePoly;
			if (list2.Count > 0 && !list2[0].Equals(list2.Last()))
			{
				list2.Add((Point3D)list2[0].Clone());
			}
		}
		int num = 0;
		int count = list.Count;
		if (count == 0)
		{
			odDb_Poly3dType = OdDb_Poly3dType.k3dSimplePoly;
			if (list2.Count < 2)
			{
				throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532115));
			}
		}
		switch (odDb_Poly3dType)
		{
		case OdDb_Poly3dType.k3dQuadSplinePoly:
		{
			num = ((count == 2) ? 1 : 2);
			double[] knotVector = NurbsBase.UniformKnotVector(num, count);
			Point4D[] array = new Point4D[count];
			for (int j = 0; j < list.Count; j++)
			{
				array[j] = new Point4D(list[j].X, list[j].Y, list[j].Z);
			}
			Curve curve = new CurveEx(num, knotVector, array);
			_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(curve, odDb3dPolyline, _0023_003DzbONi0CI_003D);
			return curve;
		}
		case OdDb_Poly3dType.k3dCubicSplinePoly:
		{
			num = count switch
			{
				2 => 1, 
				3 => 2, 
				_ => 3, 
			};
			double[] knotVector = NurbsBase.UniformKnotVector(num, count);
			Point4D[] array = new Point4D[count];
			for (int i = 0; i < list.Count; i++)
			{
				array[i] = new Point4D(list[i].X, list[i].Y, list[i].Z);
			}
			Curve curve = new CurveEx(num, knotVector, array);
			_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(curve, odDb3dPolyline, _0023_003DzbONi0CI_003D);
			return curve;
		}
		default:
		{
			LinearPathEx linearPathEx = new LinearPathEx(list2);
			_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(linearPathEx, odDb3dPolyline, _0023_003DzbONi0CI_003D);
			return linearPathEx;
		}
		}
	}

	private Entity _0023_003Dz91Oip9I_003D(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDbSpline odDbSpline = _0023_003DzkeRlGGg30I6n as OdDbSpline;
		Point4D[] array = new Point4D[odDbSpline.numControlPoints()];
		OdGePoint3dArray odGePoint3dArray = new OdGePoint3dArray();
		OdDoubleArray odDoubleArray = new OdDoubleArray();
		OdDoubleArray odDoubleArray2 = new OdDoubleArray();
		odDbSpline.getNurbsData(out var degree, out var _, out var _, out var _, odGePoint3dArray, odDoubleArray2, odDoubleArray, out var _, out var knotTol);
		if (odDbSpline.isRational())
		{
			for (int i = 0; i < array.Length; i++)
			{
				OdGePoint3d odGePoint3d = odGePoint3dArray[i];
				double num = odDoubleArray[i];
				array[i] = new Point4D(_0023_003DzbrHOvqc_003D(odGePoint3d.x) * num, _0023_003DzbrHOvqc_003D(odGePoint3d.y) * num, _0023_003DzbrHOvqc_003D(odGePoint3d.z) * num, num);
			}
		}
		else
		{
			for (int j = 0; j < array.Length; j++)
			{
				OdGePoint3d odGePoint3d2 = odGePoint3dArray[j];
				array[j] = new Point4D(_0023_003DzbrHOvqc_003D(odGePoint3d2.x), _0023_003DzbrHOvqc_003D(odGePoint3d2.y), _0023_003DzbrHOvqc_003D(odGePoint3d2.z));
			}
		}
		_0023_003DzCYNh9Kcs3g2AT3oIATp8_dIpegIE(degree, odDoubleArray2.ToArray(), array, knotTol * 10.0, out var _0023_003DzBz11kfnlOncl, out var _0023_003DzsZdQ_0024gi5lfQV);
		Entity entity = new Curve(degree, _0023_003DzBz11kfnlOncl.ToArray(), _0023_003DzsZdQ_0024gi5lfQV.ToArray());
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(entity, odDbSpline, _0023_003DzbONi0CI_003D);
		return entity;
	}

	private static void _0023_003DzCYNh9Kcs3g2AT3oIATp8_dIpegIE(int _0023_003Dzzkz90iI_003D, double[] _0023_003Dzu3hLSrJ5UneC, Point4D[] _0023_003Dz5h7TZSDcx2Yu, double _0023_003Dz3ENh_9l9CeLn, out List<double> _0023_003DzBz11kfnlOncl, out List<Point4D> _0023_003DzsZdQ_0024gi5lfQV)
	{
		int num = _0023_003Dzu3hLSrJ5UneC.Length - _0023_003Dzzkz90iI_003D;
		_0023_003DzBz11kfnlOncl = new List<double>();
		_0023_003DzsZdQ_0024gi5lfQV = new List<Point4D>();
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i <= _0023_003Dzzkz90iI_003D; i++)
		{
			_0023_003DzBz11kfnlOncl.Add(_0023_003Dzu3hLSrJ5UneC[0]);
		}
		for (int j = _0023_003Dzzkz90iI_003D + 1; j < num - 1; j++)
		{
			double num4 = _0023_003Dzu3hLSrJ5UneC[j];
			if (num4 == _0023_003Dzu3hLSrJ5UneC[j + _0023_003Dzzkz90iI_003D] || num4 == _0023_003Dzu3hLSrJ5UneC[j + _0023_003Dzzkz90iI_003D] - _0023_003Dz3ENh_9l9CeLn)
			{
				for (int k = 0; k < _0023_003Dzzkz90iI_003D; k++)
				{
					_0023_003DzBz11kfnlOncl.Add(num4);
				}
				for (int l = num3; l < num3 + j - num2 - 1; l++)
				{
					_0023_003DzsZdQ_0024gi5lfQV.Add(_0023_003Dz5h7TZSDcx2Yu[l]);
				}
				num3 += j - num2;
				num2 = j;
				j += _0023_003Dzzkz90iI_003D;
			}
			else
			{
				_0023_003DzBz11kfnlOncl.Add(num4);
			}
		}
		for (int m = 0; m <= _0023_003Dzzkz90iI_003D; m++)
		{
			_0023_003DzBz11kfnlOncl.Add(_0023_003Dzu3hLSrJ5UneC[num]);
		}
		for (int n = num3; n < _0023_003Dz5h7TZSDcx2Yu.Length; n++)
		{
			_0023_003DzsZdQ_0024gi5lfQV.Add(_0023_003Dz5h7TZSDcx2Yu[n]);
		}
	}

	private Entity _0023_003Dzwf1AJds_003D(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDbFace odDbFace = _0023_003DzkeRlGGg30I6n as OdDbFace;
		Point3D[] array = new Point3D[4];
		for (ushort num = 0; num < 4; num++)
		{
			OdGePoint3d odGePoint3d = new OdGePoint3d();
			odDbFace.getVertexAt(num, odGePoint3d);
			array[num] = new Point3D(_0023_003DzGa_t9CAQQGhs(odGePoint3d));
		}
		if (array[2] == array[3])
		{
			Triangle triangle = new Triangle(array[0], array[1], array[2]);
			triangle.VisibleEdgeFlag = 0;
			if (odDbFace.isEdgeVisibleAt(0))
			{
				triangle.VisibleEdgeFlag |= 1;
			}
			if (odDbFace.isEdgeVisibleAt(1))
			{
				triangle.VisibleEdgeFlag |= 2;
			}
			if (odDbFace.isEdgeVisibleAt(2))
			{
				triangle.VisibleEdgeFlag |= 4;
			}
			_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(triangle, odDbFace, _0023_003DzbONi0CI_003D);
			return triangle;
		}
		Quad quad = new Quad(array[0], array[1], array[2], array[3]);
		quad.VisibleEdgeFlag = 0;
		if (odDbFace.isEdgeVisibleAt(0))
		{
			quad.VisibleEdgeFlag |= 1;
		}
		if (odDbFace.isEdgeVisibleAt(1))
		{
			quad.VisibleEdgeFlag |= 2;
		}
		if (odDbFace.isEdgeVisibleAt(2))
		{
			quad.VisibleEdgeFlag |= 4;
		}
		if (odDbFace.isEdgeVisibleAt(3))
		{
			quad.VisibleEdgeFlag |= 8;
		}
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(quad, odDbFace, _0023_003DzbONi0CI_003D);
		return quad;
	}

	private Entity _0023_003Dz2yNAXYFMS7cC(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDbPolyFaceMesh odDbPolyFaceMesh = _0023_003DzkeRlGGg30I6n as OdDbPolyFaceMesh;
		Mesh mesh = _0023_003DzD_bI9sqtc0ctToIGPGKy0Zw_003D(odDbPolyFaceMesh);
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(mesh, odDbPolyFaceMesh, _0023_003DzbONi0CI_003D);
		return mesh;
	}

	private Mesh _0023_003DzD_bI9sqtc0ctToIGPGKy0Zw_003D(OdDbPolyFaceMesh _0023_003DzsLDNwk0SJiqS)
	{
		List<Point3D> list = new List<Point3D>(_0023_003DzsLDNwk0SJiqS.numVertices());
		List<IndexTriangle> list2 = new List<IndexTriangle>();
		OdDbObjectIterator odDbObjectIterator = _0023_003DzsLDNwk0SJiqS.vertexIterator();
		odDbObjectIterator.start();
		while (!odDbObjectIterator.done())
		{
			OdDbObject odDbObject = odDbObjectIterator.entity();
			if (odDbObject is OdDbPolyFaceMeshVertex)
			{
				OdGePoint3d _0023_003DzpaJGiAY_003D = ((OdDbPolyFaceMeshVertex)odDbObject).position();
				list.Add(new Point3D(_0023_003DzGa_t9CAQQGhs(_0023_003DzpaJGiAY_003D)));
			}
			else if (odDbObject is OdDbFaceRecord)
			{
				OdDbFaceRecord obj = (OdDbFaceRecord)odDbObject;
				int vertexAt = obj.getVertexAt(0);
				int vertexAt2 = obj.getVertexAt(1);
				int vertexAt3 = obj.getVertexAt(2);
				int vertexAt4 = obj.getVertexAt(3);
				int num = Math.Abs(vertexAt) - 1;
				int num2 = Math.Abs(vertexAt2) - 1;
				int num3 = Math.Abs(vertexAt3) - 1;
				int num4 = Math.Abs(vertexAt4) - 1;
				if (vertexAt != 0 && vertexAt2 != 0 && vertexAt3 != 0 && num < list.Count && num2 < list.Count && num3 < list.Count && num4 < list.Count)
				{
					if (Math.Abs(vertexAt) != Math.Abs(vertexAt2) && Math.Abs(vertexAt) != Math.Abs(vertexAt3) && Math.Abs(vertexAt2) != Math.Abs(vertexAt3))
					{
						list2.Add(new SmoothTriangle(num, num2, num3));
					}
					if (vertexAt3 != vertexAt4 && vertexAt4 != 0 && Math.Abs(vertexAt) != Math.Abs(vertexAt3) && Math.Abs(vertexAt) != Math.Abs(vertexAt4) && Math.Abs(vertexAt3) != Math.Abs(vertexAt4))
					{
						list2.Add(new SmoothTriangle(num, num3, num4));
					}
				}
			}
			odDbObjectIterator.step();
		}
		if (list.Count == 0)
		{
			throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528881));
		}
		if (list2.Count == 0)
		{
			throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528939));
		}
		return new Mesh(list, list2);
	}

	private Entity _0023_003Dzzfv5ud5Q7Vjx(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDbPolygonMesh odDbPolygonMesh = _0023_003DzkeRlGGg30I6n as OdDbPolygonMesh;
		int num = odDbPolygonMesh.mSize();
		int num2 = odDbPolygonMesh.nSize();
		Mesh mesh = new Mesh();
		int num3 = num;
		int num4 = num2;
		if (odDbPolygonMesh.isMClosed())
		{
			num3++;
		}
		if (odDbPolygonMesh.isNClosed())
		{
			num4++;
		}
		mesh.Triangles = new IndexTriangle[(num3 - 1) * (num4 - 1) * 2];
		List<Point3D> list = new List<Point3D>();
		OdDbObjectIterator odDbObjectIterator = odDbPolygonMesh.vertexIterator();
		odDbObjectIterator.start();
		while (!odDbObjectIterator.done())
		{
			OdDbPolygonMeshVertex odDbPolygonMeshVertex = (OdDbPolygonMeshVertex)odDbObjectIterator.entity();
			list.Add(new Point3D(_0023_003DzGa_t9CAQQGhs(odDbPolygonMeshVertex.position())));
			odDbObjectIterator.step();
		}
		mesh.Vertices = list.ToArray();
		int num5 = 0;
		for (int i = 0; i < num3 - 1; i++)
		{
			for (int j = 0; j < num4 - 1; j++)
			{
				int num6 = (i + 1) % num;
				int num7 = (j + 1) % num2;
				mesh.Triangles[num5++] = new IndexTriangle(j + num2 * i, num7 + num2 * i, num7 + num2 * num6);
				mesh.Triangles[num5++] = new IndexTriangle(j + num2 * i, num7 + num2 * num6, j + num2 * num6);
			}
		}
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(mesh, odDbPolygonMesh, _0023_003DzbONi0CI_003D);
		return mesh;
	}

	private Entity _0023_003DzE2cDbKNHwfao(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDbBlockReference odDbBlockReference = _0023_003DzkeRlGGg30I6n as OdDbBlockReference;
		string text = _0023_003DztCL58Rw_003D(odDbBlockReference.blockTableRecord());
		string text2 = _0023_003DzbONi0CI_003D.xrefPrefix + text.TrimStart('*');
		if (_0023_003DzbONi0CI_003D.duplicatedBlockNamesConversionTable.ContainsKey(text2))
		{
			text2 = _0023_003DzbONi0CI_003D.duplicatedBlockNamesConversionTable[text2];
		}
		double[] array = _0023_003DzGa_t9CAQQGhs(odDbBlockReference.position());
		OdGeScale3d odGeScale3d = odDbBlockReference.scaleFactors();
		BlockReferenceEx blockReferenceEx = new BlockReferenceEx(array[0], array[1], array[2], text2, odGeScale3d.sx, odGeScale3d.sy, odGeScale3d.sz, odDbBlockReference.rotation());
		OdDbDynBlockReference odDbDynBlockReference = new OdDbDynBlockReference(odDbBlockReference.objectId());
		if (odDbDynBlockReference.isDynamicBlock())
		{
			blockReferenceEx.CustomProperties = new List<KeyValuePair<string, object>>();
			OdDbDynBlockReferencePropertyArray odDbDynBlockReferencePropertyArray = new OdDbDynBlockReferencePropertyArray();
			odDbDynBlockReference.getBlockProperties(odDbDynBlockReferencePropertyArray);
			foreach (OdDbDynBlockReferenceProperty item in odDbDynBlockReferencePropertyArray)
			{
				blockReferenceEx.CustomProperties.Add(new KeyValuePair<string, object>(item.propertyName(), _0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzYsPrEi_0024RdyUL(item.value())));
			}
		}
		OdDbSpatialFilter filter = OdDbSpatialFilter.getFilter(odDbBlockReference, OdDb_OpenMode.kForRead);
		if (filter != null)
		{
			OdGePoint2dArray odGePoint2dArray = new OdGePoint2dArray();
			OdGeVector3d normal = new OdGeVector3d();
			filter.getDefinition(odGePoint2dArray, normal, out var _, out var _, out var _, out var enabled);
			if (enabled)
			{
				Point3D[] array2 = new Point3D[odGePoint2dArray.Count];
				for (int i = 0; i < odGePoint2dArray.Count; i++)
				{
					array2[i] = new Point3D(_0023_003DzbrHOvqc_003D(odGePoint2dArray[i].x), _0023_003DzbrHOvqc_003D(odGePoint2dArray[i].y));
				}
				if (blockReferenceEx.AutodeskProperties == null)
				{
					blockReferenceEx.AutodeskProperties = new AutodeskProperties();
				}
				blockReferenceEx.AutodeskProperties.XClip = array2;
			}
		}
		double[] array3 = _0023_003Dzw_7skJnLqq6B(odDbBlockReference.normal());
		if (array3[2] != 1.0)
		{
			Plane xY = Plane.XY;
			Plane plane = _0023_003DzH0a_I2VUM1u4(array3);
			Transformation transformation = new Transformation();
			transformation.Translation(0.0 - array[0], 0.0 - array[1], 0.0 - array[2]);
			Transformation transformation2 = new Transformation();
			transformation2.Rotation(xY.AxisX, xY.AxisY, xY.AxisZ, plane.AxisX, plane.AxisY, plane.AxisZ);
			Transformation transformation3 = new Transformation();
			transformation3.Translation(array[0], array[1], array[2]);
			blockReferenceEx.TransformBy(transformation3 * transformation2 * transformation);
		}
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(blockReferenceEx, odDbBlockReference, _0023_003DzbONi0CI_003D);
		OdDbObjectIterator odDbObjectIterator = odDbBlockReference.attributeIterator();
		odDbObjectIterator.start();
		while (!odDbObjectIterator.done())
		{
			OdDbAttribute odDbAttribute = (OdDbAttribute)odDbObjectIterator.entity(OdDb_OpenMode.kForRead);
			AttributeReference attributeReference = _0023_003Dz1Ohp13c_003D(odDbAttribute, _0023_003DzbONi0CI_003D);
			attributeReference.WidthFactor *= Math.Abs(odGeScale3d.sy / odGeScale3d.sx);
			attributeReference.Height /= Math.Abs(odGeScale3d.sy);
			string text3 = odDbAttribute.tag();
			if (blockReferenceEx.Attributes.ContainsKey(odDbAttribute.tag()))
			{
				text3 = _0023_003DzQO4YOkEq_0024Y0i(blockReferenceEx.Attributes, text3);
			}
			blockReferenceEx.Attributes.Add(text3, attributeReference);
			odDbObjectIterator.step();
		}
		return blockReferenceEx;
	}

	private string _0023_003DzQO4YOkEq_0024Y0i(AttributeReferenceDictionary _0023_003Dzq8tfl1Y_003D, string _0023_003Dzavcdj6I_003D)
	{
		int num = 1;
		string text = _0023_003Dzavcdj6I_003D + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532163);
		while (_0023_003Dzq8tfl1Y_003D.ContainsKey(text + num))
		{
			num++;
		}
		return text + num;
	}

	private Entity _0023_003Dz0n90n2mwIcfa(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDbAlignedDimension odDbAlignedDimension = _0023_003DzkeRlGGg30I6n as OdDbAlignedDimension;
		if (_0023_003DzecUx5V2_jZGI2ijxAA_003D_003D(_0023_003DzbONi0CI_003D, out var _0023_003Dzvyf_UNM_003D, odDbAlignedDimension))
		{
			return _0023_003Dzvyf_UNM_003D;
		}
		Point3D _0023_003Dz09_p21WQLJng = new Point3D(_0023_003DzGa_t9CAQQGhs(odDbAlignedDimension.xLine1Point()));
		Point3D _0023_003Dz9_OZnpoBJU_p = new Point3D(_0023_003DzGa_t9CAQQGhs(odDbAlignedDimension.xLine2Point()));
		Point3D _0023_003Dz_wzOG0JGsbOE = new Point3D(_0023_003DzGa_t9CAQQGhs(odDbAlignedDimension.dimLinePoint()));
		Plane _0023_003DzLodaGjk_003D = _0023_003DzH0a_I2VUM1u4(_0023_003Dzw_7skJnLqq6B(odDbAlignedDimension.normal()));
		_0023_003DzP2egK5UEyMr9tbPzZQ_003D_003D(_0023_003DzLodaGjk_003D, _0023_003Dz09_p21WQLJng, _0023_003Dz9_OZnpoBJU_p, _0023_003Dz_wzOG0JGsbOE);
		return _0023_003DzB5tmU3NMsRNN(odDbAlignedDimension, _0023_003DzLodaGjk_003D, _0023_003Dz09_p21WQLJng, _0023_003Dz9_OZnpoBJU_p, _0023_003Dz_wzOG0JGsbOE, _0023_003DzbONi0CI_003D, _0023_003Dzn_0024flvyZ1GFk6: false);
	}

	private Entity _0023_003Dzv9rB_Zczmw_00241AlsB4A_003D_003D(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDbRotatedDimension odDbRotatedDimension = _0023_003DzkeRlGGg30I6n as OdDbRotatedDimension;
		if (_0023_003DzecUx5V2_jZGI2ijxAA_003D_003D(_0023_003DzbONi0CI_003D, out var _0023_003Dzvyf_UNM_003D, odDbRotatedDimension))
		{
			return _0023_003Dzvyf_UNM_003D;
		}
		Point3D _0023_003Dz09_p21WQLJng = new Point3D(_0023_003DzGa_t9CAQQGhs(odDbRotatedDimension.xLine1Point()));
		Point3D _0023_003Dz9_OZnpoBJU_p = new Point3D(_0023_003DzGa_t9CAQQGhs(odDbRotatedDimension.xLine2Point()));
		Point3D _0023_003Dz_wzOG0JGsbOE = new Point3D(_0023_003DzGa_t9CAQQGhs(odDbRotatedDimension.dimLinePoint()));
		Plane plane = _0023_003DzH0a_I2VUM1u4(_0023_003Dzw_7skJnLqq6B(odDbRotatedDimension.normal()));
		double num = odDbRotatedDimension.rotation();
		bool _0023_003Dzn_0024flvyZ1GFk = false;
		if (!Utility.AreEqual(num, Math.PI, Math.PI * 2.0))
		{
			plane.Rotate(num, plane.AxisZ, Point3D.Origin);
			_0023_003Dzn_0024flvyZ1GFk = true;
		}
		return _0023_003DzB5tmU3NMsRNN(odDbRotatedDimension, plane, _0023_003Dz09_p21WQLJng, _0023_003Dz9_OZnpoBJU_p, _0023_003Dz_wzOG0JGsbOE, _0023_003DzbONi0CI_003D, _0023_003Dzn_0024flvyZ1GFk);
	}

	private bool _0023_003DzecUx5V2_jZGI2ijxAA_003D_003D(ReadEntityData _0023_003DzbONi0CI_003D, out Entity _0023_003Dzvyf_UNM_003D, OdDbEntity _0023_003DzkeRlGGg30I6n)
	{
		if (ExplodeDimensions)
		{
			_0023_003Dzvyf_UNM_003D = _0023_003Dzp1f0xCzNeiq3Mm1muA_003D_003D(_0023_003DzbONi0CI_003D, _0023_003DzkeRlGGg30I6n, _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532187), _0023_003DzkeRlGGg30I6n.explodeGeometry, _0023_003DzdwSdD4s_003D: false);
			return true;
		}
		_0023_003Dzvyf_UNM_003D = null;
		return false;
	}

	private Entity _0023_003DzB5tmU3NMsRNN(OdDbDimension _0023_003DzCPdvaZCXbT3o, Plane _0023_003DzLodaGjk_003D, Point3D _0023_003Dz09_p21WQLJng, Point3D _0023_003Dz9_OZnpoBJU_p, Point3D _0023_003Dz_wzOG0JGsbOE, ReadEntityData _0023_003DzbONi0CI_003D, bool _0023_003Dzn_0024flvyZ1GFk6)
	{
		_0023_003DzC69xlPpZpEfZ(_0023_003DzCPdvaZCXbT3o);
		Point3D _0023_003DzOQElLHA47MSc = new Point3D(_0023_003DzGa_t9CAQQGhs(_0023_003DzCPdvaZCXbT3o.textPosition()));
		Point3D dimLinePos = _0023_003DziNux3j6suL7r(_0023_003DzLodaGjk_003D, _0023_003Dz9_OZnpoBJU_p, _0023_003Dz_wzOG0JGsbOE, _0023_003DzOQElLHA47MSc);
		LinearDim linearDim = new LinearDim(_0023_003DzLodaGjk_003D, _0023_003Dz09_p21WQLJng, _0023_003Dz9_OZnpoBJU_p, dimLinePos, _0023_003DzCPdvaZCXbT3o.dimtxt());
		OdDbDimStyleTableRecord odDbDimStyleTableRecord = _0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzzCUl9noIHm5A2CdO2YRZsvQ_003D(linearDim, _0023_003DzCPdvaZCXbT3o);
		linearDim.Precision = odDbDimStyleTableRecord.dimdec();
		linearDim.ExtLineOffset = odDbDimStyleTableRecord.dimexo();
		linearDim.ExtLineExt = odDbDimStyleTableRecord.dimexe();
		linearDim.ShowExtLine1 = !odDbDimStyleTableRecord.dimse1();
		linearDim.ShowExtLine2 = !odDbDimStyleTableRecord.dimse2();
		if (_0023_003DzCPdvaZCXbT3o.dimsah())
		{
			linearDim.LeftArrowhead = _0023_003DzpwyujuBAexTwPi5cJ7jIv8JlJvkt(_0023_003DztCL58Rw_003D(odDbDimStyleTableRecord.dimblk1()));
			linearDim.RightArrowhead = _0023_003DzpwyujuBAexTwPi5cJ7jIv8JlJvkt(_0023_003DztCL58Rw_003D(odDbDimStyleTableRecord.dimblk2()));
		}
		else
		{
			arrowheadType leftArrowhead = (linearDim.RightArrowhead = _0023_003DzpwyujuBAexTwPi5cJ7jIv8JlJvkt(_0023_003DztCL58Rw_003D(odDbDimStyleTableRecord.dimblk())));
			linearDim.LeftArrowhead = leftArrowhead;
		}
		linearDim.LinearScale = odDbDimStyleTableRecord.dimlfac();
		_0023_003DzA3FnfbUjZ3OT(linearDim, _0023_003DzCPdvaZCXbT3o.dimensionText(), _0023_003DzCPdvaZCXbT3o.dimpost());
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(linearDim, _0023_003DzCPdvaZCXbT3o, _0023_003DzbONi0CI_003D);
		return linearDim;
	}

	private Entity _0023_003DzqU4SkO0ywgTRXO8Juw_003D_003D(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDbOrdinateDimension odDbOrdinateDimension = _0023_003DzkeRlGGg30I6n as OdDbOrdinateDimension;
		if (_0023_003DzecUx5V2_jZGI2ijxAA_003D_003D(_0023_003DzbONi0CI_003D, out var _0023_003Dzvyf_UNM_003D, odDbOrdinateDimension))
		{
			return _0023_003Dzvyf_UNM_003D;
		}
		Point3D origin = new Point3D(_0023_003DzGa_t9CAQQGhs(odDbOrdinateDimension.origin()));
		Point3D point3D = new Point3D(_0023_003DzGa_t9CAQQGhs(odDbOrdinateDimension.definingPoint()));
		Point3D point3D2 = new Point3D(_0023_003DzGa_t9CAQQGhs(odDbOrdinateDimension.leaderEndPoint()));
		_0023_003DzC69xlPpZpEfZ(odDbOrdinateDimension);
		Point3D point3D3 = new Point3D(_0023_003DzGa_t9CAQQGhs(odDbOrdinateDimension.textPosition()));
		OdGePlane odGePlane = new OdGePlane();
		odDbOrdinateDimension.getPlane(odGePlane, out var _);
		Plane plane = _0023_003DzcZqeHueEnhjO(odGePlane);
		if (odDbOrdinateDimension.horizontalRotation() != 0.0)
		{
			plane.Rotate(0.0 - odDbOrdinateDimension.horizontalRotation(), plane.AxisZ, point3D);
		}
		plane.Origin = origin;
		bool flag = odDbOrdinateDimension.isUsingXAxis();
		Vector3D vector3D = (flag ? plane.AxisY : plane.AxisX);
		Segment3D seg = new Segment3D(point3D2, point3D2 + vector3D);
		Point3D dimLinePos = point3D3.ProjectTo(seg);
		OrdinateDim ordinateDim = new OrdinateDim(plane, point3D, dimLinePos, flag, odDbOrdinateDimension.dimtxt());
		OdDbDimStyleTableRecord odDbDimStyleTableRecord = _0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzzCUl9noIHm5A2CdO2YRZsvQ_003D(ordinateDim, odDbOrdinateDimension);
		ordinateDim.Precision = odDbDimStyleTableRecord.dimdec();
		ordinateDim.ExtLineOffset = odDbDimStyleTableRecord.dimexo();
		ordinateDim.LinearScale = odDbDimStyleTableRecord.dimlfac();
		_0023_003DzA3FnfbUjZ3OT(ordinateDim, odDbOrdinateDimension.dimensionText(), odDbOrdinateDimension.dimpost());
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(ordinateDim, odDbOrdinateDimension, _0023_003DzbONi0CI_003D);
		return ordinateDim;
	}

	private Entity _0023_003Dz3s5b9FD9vpP9(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		return _0023_003Dzp1f0xCzNeiq3Mm1muA_003D_003D(_0023_003DzbONi0CI_003D, _0023_003DzkeRlGGg30I6n, _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532267), _0023_003DzkeRlGGg30I6n.explodeGeometry, _0023_003DzdwSdD4s_003D: false);
	}

	private Entity _0023_003Dz5CdLd7v7OGLN(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		return _0023_003Dzp1f0xCzNeiq3Mm1muA_003D_003D(_0023_003DzbONi0CI_003D, _0023_003DzkeRlGGg30I6n, _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532273), _0023_003DzkeRlGGg30I6n.explodeGeometry, _0023_003DzdwSdD4s_003D: false);
	}

	private Entity _0023_003DzGAqoqC0_003D(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDbLeader odDbLeader = _0023_003DzkeRlGGg30I6n as OdDbLeader;
		if (ExplodeDimensions && _0023_003DzecUx5V2_jZGI2ijxAA_003D_003D(_0023_003DzbONi0CI_003D, out var _0023_003Dzvyf_UNM_003D, odDbLeader))
		{
			return _0023_003Dzvyf_UNM_003D;
		}
		OdGePlane odGePlane = new OdGePlane();
		odDbLeader.getPlane(odGePlane, out var planarity);
		if (!odDbLeader.annotationObjId().isNull())
		{
			OdDbObject odDbObject = odDbLeader.annotationObjId().openObject(OdDb_OpenMode.kForRead);
			if (odDbObject is OdDbMText)
			{
				((OdDbMText)odDbObject).getPlane(odGePlane, out planarity);
			}
			else if (odDbObject is OdDbBlockReference)
			{
				((OdDbBlockReference)odDbObject).getPlane(odGePlane, out planarity);
			}
		}
		Plane pln = _0023_003DzcZqeHueEnhjO(odGePlane);
		List<Point3D> list = new List<Point3D>();
		int num = odDbLeader.numVertices();
		if (num < 2)
		{
			throw new Exception(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532227));
		}
		for (int i = 0; i < num; i++)
		{
			list.Add(new Point3D(_0023_003DzGa_t9CAQQGhs(odDbLeader.vertexAt(i))));
		}
		OdDbDimStyleTableRecord odDbDimStyleTableRecord = OdDbDimStyleTableRecord.createObject();
		odDbLeader.getDimstyleData(odDbDimStyleTableRecord);
		arrowheadType arrowhead = _0023_003DzpwyujuBAexTwPi5cJ7jIv8JlJvkt(_0023_003DztCL58Rw_003D(odDbDimStyleTableRecord.dimldrblk()));
		odDbLeader.isSplined();
		Leader leader = new Leader(pln, list.ToArray(), odDbLeader.hasHookLine(), odDbLeader.isHookLineOnXDir(), arrowhead, odDbLeader.dimasz(), odDbLeader.dimscale())
		{
			ShowArrowHead = odDbLeader.hasArrowHead()
		};
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(leader, odDbLeader, _0023_003DzbONi0CI_003D);
		return leader;
	}

	private static string _0023_003DztCL58Rw_003D(OdDbObjectId _0023_003DznAdwHsY_003D)
	{
		MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
		OdDbObject odDbObject = _0023_003DznAdwHsY_003D.openObject();
		string result = ((odDbObject == null) ? string.Empty : ((odDbObject is OdDbSymbolTableRecord) ? ((OdDbSymbolTableRecord)odDbObject).getName() : ((odDbObject is OdDbMlineStyle) ? ((OdDbMlineStyle)odDbObject).name() : ((odDbObject is OdDbPlaceHolder) ? ((OdDbDictionary)_0023_003DznAdwHsY_003D.database().getPlotStyleNameDictionaryId().openObject()).nameAt(_0023_003DznAdwHsY_003D) : ((!(odDbObject is OdDbMaterial)) ? odDbObject.isA().name() : ((OdDbMaterial)odDbObject).name())))));
		MemoryManager.GetMemoryManager().StopTransaction(value);
		return result;
	}

	private static double[] _0023_003DzGa_t9CAQQGhs(OdGePoint2d _0023_003DzpaJGiAY_003D)
	{
		return new double[2]
		{
			_0023_003DzbrHOvqc_003D(_0023_003DzpaJGiAY_003D.x),
			_0023_003DzbrHOvqc_003D(_0023_003DzpaJGiAY_003D.y)
		};
	}

	private static double[] _0023_003Dzw_7skJnLqq6B(OdGeVector3d _0023_003Dz6n68ZStGtLBM)
	{
		return new double[3]
		{
			_0023_003DzbrHOvqc_003D(_0023_003Dz6n68ZStGtLBM.x),
			_0023_003DzbrHOvqc_003D(_0023_003Dz6n68ZStGtLBM.y),
			_0023_003DzbrHOvqc_003D(_0023_003Dz6n68ZStGtLBM.z)
		};
	}

	internal static Vector3D _0023_003DzBTaQ_0024K9mCK1O(OdGeVector3d _0023_003Dz6n68ZStGtLBM)
	{
		return new Vector3D(_0023_003Dzw_7skJnLqq6B(_0023_003Dz6n68ZStGtLBM));
	}

	internal static double[] _0023_003DzGa_t9CAQQGhs(OdGePoint3d _0023_003DzpaJGiAY_003D)
	{
		return new double[3]
		{
			_0023_003DzbrHOvqc_003D(_0023_003DzpaJGiAY_003D.x),
			_0023_003DzbrHOvqc_003D(_0023_003DzpaJGiAY_003D.y),
			_0023_003DzbrHOvqc_003D(_0023_003DzpaJGiAY_003D.z)
		};
	}

	internal static Point3D _0023_003DzHLWQmn1CvBx2(OdGePoint3d _0023_003DzpaJGiAY_003D)
	{
		return new Point3D(_0023_003DzGa_t9CAQQGhs(_0023_003DzpaJGiAY_003D));
	}

	internal static Plane _0023_003DzcZqeHueEnhjO(OdGePlane _0023_003DzbZECEX_0024JQxCqnrh_LQ_003D_003D)
	{
		OdGePoint3d odGePoint3d = new OdGePoint3d();
		OdGeVector3d odGeVector3d = new OdGeVector3d();
		OdGeVector3d odGeVector3d2 = new OdGeVector3d();
		_0023_003DzbZECEX_0024JQxCqnrh_LQ_003D_003D.getCoordSystem(odGePoint3d, odGeVector3d, odGeVector3d2);
		return new Plane(new Point3D(_0023_003DzGa_t9CAQQGhs(odGePoint3d)), new Vector3D(_0023_003Dzw_7skJnLqq6B(odGeVector3d)), new Vector3D(_0023_003Dzw_7skJnLqq6B(odGeVector3d2)));
	}

	private static double _0023_003DzbrHOvqc_003D(double _0023_003Dzdc1k2Kc_003D)
	{
		if (Math.Abs(_0023_003Dzdc1k2Kc_003D) > _0023_003DzR4ocvc6x1MsH)
		{
			return 0.0;
		}
		return _0023_003Dzdc1k2Kc_003D;
	}

	private static arrowheadType _0023_003DzpwyujuBAexTwPi5cJ7jIv8JlJvkt(string _0023_003Dzv0iXCdI_003D)
	{
		string text = _0023_003Dzv0iXCdI_003D.ToUpper();
		if (!(text == _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531824)))
		{
			if (!(text == _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531776)))
			{
				if (text == _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531799))
				{
					return arrowheadType.Oblique;
				}
				return arrowheadType.Arrow;
			}
			return arrowheadType.Dot;
		}
		return arrowheadType.Tick;
	}

	internal static string _0023_003DzCpMAPMCSIWkbPePIPnwPrXvcxGji(arrowheadType _0023_003DzoWh_0024Huc_003D)
	{
		return _0023_003DzoWh_0024Huc_003D switch
		{
			arrowheadType.Tick => _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531824), 
			arrowheadType.Dot => _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531776), 
			arrowheadType.Oblique => _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531799), 
			_ => string.Empty, 
		};
	}

	private static Point3D _0023_003DziNux3j6suL7r(Plane _0023_003DzLodaGjk_003D, Point3D _0023_003Dz2MX1ehZ3xd_00245, Point3D _0023_003Dz_wzOG0JGsbOE, Point3D _0023_003DzOQElLHA47MSc)
	{
		Segment3D seg = new Segment3D(_0023_003Dz2MX1ehZ3xd_00245, _0023_003Dz2MX1ehZ3xd_00245 + _0023_003DzLodaGjk_003D.AxisY);
		Point3D b = _0023_003DzOQElLHA47MSc.ProjectTo(seg);
		return _0023_003DzOQElLHA47MSc + Vector3D.Dot(Vector3D.Subtract(_0023_003Dz_wzOG0JGsbOE, b), _0023_003DzLodaGjk_003D.AxisY) * _0023_003DzLodaGjk_003D.AxisY;
	}

	private void _0023_003DzC69xlPpZpEfZ(OdDbDimension _0023_003Dz5XGM1CQ_003D)
	{
		double[] array = _0023_003DzGa_t9CAQQGhs(_0023_003Dz5XGM1CQ_003D.textPosition());
		if (_0023_003Dz5XGM1CQ_003D.isUsingDefaultTextPosition() && Array.TrueForAll(array, (double _0023_003DzeJLIX5w_003D) => _0023_003DzeJLIX5w_003D == 0.0))
		{
			_0023_003Dz5XGM1CQ_003D.recomputeDimBlock(forceUpdate: true);
		}
	}

	private Entity _0023_003Dz8o9K3AQsX_Pg(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDbRadialDimension odDbRadialDimension = _0023_003DzkeRlGGg30I6n as OdDbRadialDimension;
		if (_0023_003DzecUx5V2_jZGI2ijxAA_003D_003D(_0023_003DzbONi0CI_003D, out var _0023_003Dzvyf_UNM_003D, odDbRadialDimension))
		{
			return _0023_003Dzvyf_UNM_003D;
		}
		Point3D point3D = new Point3D(_0023_003DzGa_t9CAQQGhs(odDbRadialDimension.center()));
		Point3D b = new Point3D(_0023_003DzGa_t9CAQQGhs(odDbRadialDimension.chordPoint()));
		_0023_003DzC69xlPpZpEfZ(odDbRadialDimension);
		Point3D dimLinePos = new Point3D(_0023_003DzGa_t9CAQQGhs(odDbRadialDimension.textPosition()));
		Plane plane = _0023_003DzH0a_I2VUM1u4(_0023_003Dzw_7skJnLqq6B(odDbRadialDimension.normal()));
		double num = Point3D.Distance(point3D, b);
		if (num < 1E-12)
		{
			log.AppendLine(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531878), _0023_003Dz2jlzUDbXSA47Py_0024dGg_003D_003D(_0023_003DzkeRlGGg30I6n)));
			return null;
		}
		RadialDim radialDim = new RadialDim(new Circle(plane, point3D, num), dimLinePos, odDbRadialDimension.dimtxt());
		OdDbDimStyleTableRecord odDbDimStyleTableRecord = _0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzzCUl9noIHm5A2CdO2YRZsvQ_003D(radialDim, odDbRadialDimension);
		radialDim.Precision = odDbDimStyleTableRecord.dimdec();
		radialDim.Arrowhead = _0023_003DzpwyujuBAexTwPi5cJ7jIv8JlJvkt(_0023_003DztCL58Rw_003D(odDbDimStyleTableRecord.dimblk2()));
		radialDim.LinearScale = odDbDimStyleTableRecord.dimlfac();
		radialDim.CenterMarkSize = Math.Abs(odDbRadialDimension.dimcen());
		radialDim.TrimLeader = odDbRadialDimension.dimtmove() != 2;
		_0023_003DzA3FnfbUjZ3OT(radialDim, odDbRadialDimension.dimensionText(), odDbRadialDimension.dimpost());
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(radialDim, odDbRadialDimension, _0023_003DzbONi0CI_003D);
		return radialDim;
	}

	private Entity _0023_003DzupvYi0kCH_ek2UKtrcJjEYE_003D(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDbDiametricDimension odDbDiametricDimension = _0023_003DzkeRlGGg30I6n as OdDbDiametricDimension;
		if (_0023_003DzecUx5V2_jZGI2ijxAA_003D_003D(_0023_003DzbONi0CI_003D, out var _0023_003Dzvyf_UNM_003D, odDbDiametricDimension))
		{
			return _0023_003Dzvyf_UNM_003D;
		}
		Point3D point3D = new Point3D(_0023_003DzGa_t9CAQQGhs(odDbDiametricDimension.chordPoint()));
		Point3D b = new Point3D(_0023_003DzGa_t9CAQQGhs(odDbDiametricDimension.farChordPoint()));
		Point3D dimLinePos = new Point3D(_0023_003DzGa_t9CAQQGhs(odDbDiametricDimension.textPosition()));
		Point3D point3D2 = Point3D.MidPoint(point3D, b);
		Plane plane = _0023_003DzH0a_I2VUM1u4(_0023_003Dzw_7skJnLqq6B(odDbDiametricDimension.normal()));
		double num = Point3D.Distance(point3D2, point3D);
		if (num < 1E-12)
		{
			log.AppendLine(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531859), _0023_003Dz2jlzUDbXSA47Py_0024dGg_003D_003D(_0023_003DzkeRlGGg30I6n)));
			return null;
		}
		DiametricDim diametricDim = new DiametricDim(new Circle(plane, point3D2, num), dimLinePos, odDbDiametricDimension.dimtxt());
		OdDbDimStyleTableRecord odDbDimStyleTableRecord = _0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzzCUl9noIHm5A2CdO2YRZsvQ_003D(diametricDim, odDbDiametricDimension);
		diametricDim.Precision = odDbDimStyleTableRecord.dimdec();
		diametricDim.LeftArrowhead = _0023_003DzpwyujuBAexTwPi5cJ7jIv8JlJvkt(_0023_003DztCL58Rw_003D(odDbDimStyleTableRecord.dimblk2()));
		diametricDim.RightArrowhead = _0023_003DzpwyujuBAexTwPi5cJ7jIv8JlJvkt(_0023_003DztCL58Rw_003D(odDbDimStyleTableRecord.dimblk1()));
		diametricDim.LinearScale = odDbDimStyleTableRecord.dimlfac();
		diametricDim.CenterMarkSize = Math.Abs(odDbDiametricDimension.dimcen());
		_0023_003DzA3FnfbUjZ3OT(diametricDim, odDbDiametricDimension.dimensionText(), odDbDiametricDimension.dimpost());
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(diametricDim, odDbDiametricDimension, _0023_003DzbONi0CI_003D);
		return diametricDim;
	}

	private void _0023_003DzS6kCEm9aavkC(int _0023_003Dz4yrmyu9qffaT, ref AngularDim _0023_003DzadqLWg0fxGf5)
	{
		switch (_0023_003Dz4yrmyu9qffaT)
		{
		case 0:
			_0023_003DzadqLWg0fxGf5.AngleFormat = angleFormatType.DecimalDegrees;
			break;
		case 1:
			_0023_003DzadqLWg0fxGf5.AngleFormat = angleFormatType.DegMinSec;
			break;
		case 2:
			_0023_003DzadqLWg0fxGf5.AngleFormat = angleFormatType.Gradians;
			break;
		case 3:
			_0023_003DzadqLWg0fxGf5.AngleFormat = angleFormatType.Radians;
			break;
		}
	}

	private Entity _0023_003DzXLLKSOs6xdvhYPXYbEPxBzY_003D(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDb3PointAngularDimension odDb3PointAngularDimension = _0023_003DzkeRlGGg30I6n as OdDb3PointAngularDimension;
		if (_0023_003DzecUx5V2_jZGI2ijxAA_003D_003D(_0023_003DzbONi0CI_003D, out var _0023_003Dzvyf_UNM_003D, odDb3PointAngularDimension))
		{
			return _0023_003Dzvyf_UNM_003D;
		}
		Point3D point3D = new Point3D(_0023_003DzGa_t9CAQQGhs(odDb3PointAngularDimension.centerPoint()));
		Point3D point3D2 = new Point3D(_0023_003DzGa_t9CAQQGhs(odDb3PointAngularDimension.xLine1Point()));
		Point3D point3D3 = new Point3D(_0023_003DzGa_t9CAQQGhs(odDb3PointAngularDimension.xLine2Point()));
		Point3D dimLinePos = new Point3D(_0023_003DzGa_t9CAQQGhs(odDb3PointAngularDimension.textPosition()));
		double num = point3D.DistanceTo(point3D2);
		if (num == 0.0 || Point3D.AreEqual(point3D2, point3D3, num))
		{
			log.AppendLine(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531931), _0023_003Dz2jlzUDbXSA47Py_0024dGg_003D_003D(_0023_003DzkeRlGGg30I6n)));
			return null;
		}
		OdGePlane odGePlane = new OdGePlane();
		odDb3PointAngularDimension.getPlane(odGePlane, out var _);
		Plane plane = _0023_003DzcZqeHueEnhjO(odGePlane);
		plane.Origin = point3D;
		AngularDim _0023_003DzadqLWg0fxGf = new AngularDim(plane, point3D2, point3D3, dimLinePos, odDb3PointAngularDimension.dimtxt());
		_0023_003DzadqLWg0fxGf.ShowExtLine1 = !odDb3PointAngularDimension.dimse1();
		_0023_003DzadqLWg0fxGf.ShowExtLine2 = !odDb3PointAngularDimension.dimse2();
		_0023_003DzS6kCEm9aavkC(odDb3PointAngularDimension.dimaunit(), ref _0023_003DzadqLWg0fxGf);
		OdDbDimStyleTableRecord odDbDimStyleTableRecord = _0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzzCUl9noIHm5A2CdO2YRZsvQ_003D(_0023_003DzadqLWg0fxGf, odDb3PointAngularDimension);
		_0023_003DzadqLWg0fxGf.Precision = odDbDimStyleTableRecord.dimadec();
		_0023_003DzadqLWg0fxGf.LinearScale = odDbDimStyleTableRecord.dimlfac();
		_0023_003DzA3FnfbUjZ3OT(_0023_003DzadqLWg0fxGf, odDb3PointAngularDimension.dimensionText(), odDb3PointAngularDimension.dimpost());
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(_0023_003DzadqLWg0fxGf, odDb3PointAngularDimension, _0023_003DzbONi0CI_003D);
		return _0023_003DzadqLWg0fxGf;
	}

	private Entity _0023_003DzCyLjU7kvklZXzKoc1tvIbqI_003D(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDb2LineAngularDimension odDb2LineAngularDimension = _0023_003DzkeRlGGg30I6n as OdDb2LineAngularDimension;
		if (_0023_003DzecUx5V2_jZGI2ijxAA_003D_003D(_0023_003DzbONi0CI_003D, out var _0023_003Dzvyf_UNM_003D, odDb2LineAngularDimension))
		{
			return _0023_003Dzvyf_UNM_003D;
		}
		Point3D quadrantPoint = new Point3D(_0023_003DzGa_t9CAQQGhs(odDb2LineAngularDimension.arcPoint()));
		Point3D start = new Point3D(_0023_003DzGa_t9CAQQGhs(odDb2LineAngularDimension.xLine1Start()));
		Point3D end = new Point3D(_0023_003DzGa_t9CAQQGhs(odDb2LineAngularDimension.xLine1End()));
		Point3D start2 = new Point3D(_0023_003DzGa_t9CAQQGhs(odDb2LineAngularDimension.xLine2Start()));
		Point3D end2 = new Point3D(_0023_003DzGa_t9CAQQGhs(odDb2LineAngularDimension.xLine2End()));
		_0023_003DzC69xlPpZpEfZ(odDb2LineAngularDimension);
		Point3D dimLinePos = new Point3D(_0023_003DzGa_t9CAQQGhs(odDb2LineAngularDimension.textPosition()));
		OdGePlane odGePlane = new OdGePlane();
		odDb2LineAngularDimension.getPlane(odGePlane, out var _);
		Plane dimPlane = _0023_003DzcZqeHueEnhjO(odGePlane);
		Line line = new Line(start, end);
		Line line2 = new Line(start2, end2);
		AngularDim _0023_003DzadqLWg0fxGf = new AngularDim(dimPlane, line, line2, quadrantPoint, dimLinePos, odDb2LineAngularDimension.dimtxt());
		_0023_003DzS6kCEm9aavkC(odDb2LineAngularDimension.dimaunit(), ref _0023_003DzadqLWg0fxGf);
		_0023_003DzadqLWg0fxGf.ShowExtLine1 = !odDb2LineAngularDimension.dimse1();
		_0023_003DzadqLWg0fxGf.ShowExtLine2 = !odDb2LineAngularDimension.dimse2();
		OdDbDimStyleTableRecord odDbDimStyleTableRecord = _0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzzCUl9noIHm5A2CdO2YRZsvQ_003D(_0023_003DzadqLWg0fxGf, odDb2LineAngularDimension);
		_0023_003DzadqLWg0fxGf.Precision = odDbDimStyleTableRecord.dimadec();
		_0023_003DzadqLWg0fxGf.LinearScale = odDbDimStyleTableRecord.dimlfac();
		_0023_003DzA3FnfbUjZ3OT(_0023_003DzadqLWg0fxGf, odDb2LineAngularDimension.dimensionText(), odDb2LineAngularDimension.dimpost());
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(_0023_003DzadqLWg0fxGf, odDb2LineAngularDimension, _0023_003DzbONi0CI_003D);
		return _0023_003DzadqLWg0fxGf;
	}

	private Entity _0023_003DzHXJNPIXUIlLX(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		OdDbArcDimension odDbArcDimension = _0023_003DzkeRlGGg30I6n as OdDbArcDimension;
		if (_0023_003DzecUx5V2_jZGI2ijxAA_003D_003D(_0023_003DzbONi0CI_003D, out var _0023_003Dzvyf_UNM_003D, odDbArcDimension))
		{
			return _0023_003Dzvyf_UNM_003D;
		}
		Point3D point3D = new Point3D(_0023_003DzGa_t9CAQQGhs(odDbArcDimension.centerPoint()));
		Point3D point3D2 = new Point3D(_0023_003DzGa_t9CAQQGhs(odDbArcDimension.xLine1Point()));
		Point3D point3D3 = new Point3D(_0023_003DzGa_t9CAQQGhs(odDbArcDimension.xLine2Point()));
		Point3D dimLinePos = new Point3D(_0023_003DzGa_t9CAQQGhs(odDbArcDimension.textPosition()));
		double num = point3D.DistanceTo(point3D2);
		if (num == 0.0 || Point3D.AreEqual(point3D2, point3D3, num))
		{
			log.AppendLine(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531931), _0023_003Dz2jlzUDbXSA47Py_0024dGg_003D_003D(_0023_003DzkeRlGGg30I6n)));
			return null;
		}
		OdGePlane odGePlane = new OdGePlane();
		odDbArcDimension.getPlane(odGePlane, out var _);
		Plane plane = _0023_003DzcZqeHueEnhjO(odGePlane);
		plane.Origin = point3D;
		AngularDim _0023_003DzadqLWg0fxGf = new AngularDim(plane, point3D2, point3D3, dimLinePos, odDbArcDimension.dimtxt());
		_0023_003DzadqLWg0fxGf.ShowExtLine1 = !odDbArcDimension.dimse1();
		_0023_003DzadqLWg0fxGf.ShowExtLine2 = !odDbArcDimension.dimse2();
		_0023_003DzS6kCEm9aavkC(odDbArcDimension.dimaunit(), ref _0023_003DzadqLWg0fxGf);
		OdDbDimStyleTableRecord odDbDimStyleTableRecord = _0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzzCUl9noIHm5A2CdO2YRZsvQ_003D(_0023_003DzadqLWg0fxGf, odDbArcDimension);
		_0023_003DzadqLWg0fxGf.Precision = odDbDimStyleTableRecord.dimadec();
		_0023_003DzadqLWg0fxGf.LinearScale = odDbDimStyleTableRecord.dimlfac();
		string formattedMeasurement = string.Empty;
		odDbArcDimension.formatMeasurement(ref formattedMeasurement, odDbArcDimension.getMeasurement(), odDbArcDimension.dimensionText());
		_0023_003Dz6oQ7E7o_003D(formattedMeasurement, out var _0023_003DzkfAOhIE_003D, out var _, out var _);
		_0023_003DzadqLWg0fxGf.TextOverride = _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531968) + _0023_003DzkfAOhIE_003D[0];
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(_0023_003DzadqLWg0fxGf, odDbArcDimension, _0023_003DzbONi0CI_003D);
		return _0023_003DzadqLWg0fxGf;
	}

	internal void _0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(IEntity _0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D, OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		_0023_003DzxnSsn_sGLe2l4Q46OzRouPQ_003D _0023_003DzkeRlGGg30I6n2 = new _0023_003DzxnSsn_sGLe2l4Q46OzRouPQ_003D(_0023_003DzkeRlGGg30I6n);
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D, _0023_003DzkeRlGGg30I6n2, _0023_003DzbONi0CI_003D);
	}

	internal void _0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(IEntity _0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D, _0023_003DzxnSsn_sGLe2l4Q46OzRouPQ_003D _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		if (_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.AutodeskProperties == null)
		{
			_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.AutodeskProperties = new AutodeskProperties();
		}
		_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.Visible = _0023_003DzkeRlGGg30I6n._0023_003DzxAeEK06E9wHg();
		string layerName = (_0023_003DzbONi0CI_003D.testLayer.Name = _0023_003DzkeRlGGg30I6n._0023_003Dz1CiOgMhN_w8L());
		_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.LayerName = layerName;
		if (!base.Layers.Contains(_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.LayerName))
		{
			_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.LayerName = base.Layers[0].Name;
		}
		if (_0023_003DzkeRlGGg30I6n._0023_003DzP91cXDJzQgAq() == LineWeight.kLnWtByBlock)
		{
			_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.LineWeightMethod = colorMethodType.byParent;
		}
		else if (_0023_003DzkeRlGGg30I6n._0023_003DzP91cXDJzQgAq() == LineWeight.kLnWtByLayer)
		{
			_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.LineWeightMethod = colorMethodType.byLayer;
		}
		else
		{
			_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.LineWeightMethod = colorMethodType.byEntity;
			_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.LineWeight = WriteDatabase._0023_003DzCO9z9YG_0024A6qTfyILw2qCj_0024c7cI9_0024(_0023_003DzkeRlGGg30I6n._0023_003DzP91cXDJzQgAq());
		}
		if (_0023_003DzkeRlGGg30I6n._0023_003Dz_0024dvPXS0_003D().isByBlock())
		{
			_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.ColorMethod = colorMethodType.byParent;
		}
		else if (_0023_003DzkeRlGGg30I6n._0023_003Dz_0024dvPXS0_003D().isByLayer())
		{
			_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.ColorMethod = colorMethodType.byLayer;
		}
		else
		{
			_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.ColorMethod = colorMethodType.byEntity;
			OdCmColor odCmColor = _0023_003DzkeRlGGg30I6n._0023_003Dz_0024dvPXS0_003D();
			OdCmTransparency odCmTransparency = _0023_003DzkeRlGGg30I6n._0023_003Dzk0q7DRmuI7_7();
			if (odCmColor.isForeground())
			{
				_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.Color = Color.FromArgb(odCmTransparency.alpha(), ForegroundColor);
			}
			else
			{
				_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.Color = Color.FromArgb(odCmTransparency.alpha(), odCmColor.red(), odCmColor.green(), odCmColor.blue());
			}
		}
		string text2 = _0023_003DzkeRlGGg30I6n._0023_003DzinaallCRnjSTfB3CeA_003D_003D().ToUpper();
		if (text2 == _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531993))
		{
			_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.LineTypeMethod = colorMethodType.byParent;
		}
		else if (text2 == _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532587))
		{
			_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.LineTypeMethod = colorMethodType.byLayer;
		}
		else if (text2 == _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532605))
		{
			_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.LineTypeMethod = colorMethodType.byEntity;
			_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.LineTypeName = null;
		}
		else if (_0023_003DzbONi0CI_003D.importedLinetypes.Contains(_0023_003DzkeRlGGg30I6n._0023_003DzinaallCRnjSTfB3CeA_003D_003D()))
		{
			_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.LineTypeMethod = colorMethodType.byEntity;
			_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.LineTypeName = _0023_003DzkeRlGGg30I6n._0023_003DzinaallCRnjSTfB3CeA_003D_003D();
		}
		_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.LineTypeScale = (float)_0023_003DzkeRlGGg30I6n._0023_003Dz2QeL7AVgUMLR4fA2YyzdfIM_003D();
		if (_0023_003DzkeRlGGg30I6n._0023_003Dz88LgRmrB_kny() != null)
		{
			List<KeyValuePair<short, object>> list = _0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003Dztyuk6QQ_003D(_0023_003DzkeRlGGg30I6n._0023_003Dz6mhCO5QZ3ueJ(string.Empty));
			if (list.Count > 0)
			{
				_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.AutodeskProperties.XData = list;
			}
		}
		_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D.AutodeskProperties.UnparsedDimensionText = _0023_003DzkeRlGGg30I6n._0023_003Dzlhs_0024msE8QJhg();
		if (_0023_003DzTF6VxYwN0Yi5DFhN4A_003D_003D is Entity entity && !_0023_003DzkeRlGGg30I6n._0023_003DzaV2RyyH8SWiU().Equals(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355530463)) && !_0023_003DzkeRlGGg30I6n._0023_003DzaV2RyyH8SWiU().Equals(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355530449)) && !_0023_003DzkeRlGGg30I6n._0023_003DzaV2RyyH8SWiU().Equals(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528995)))
		{
			entity.MaterialName = _0023_003DzkeRlGGg30I6n._0023_003DzaV2RyyH8SWiU();
			if (entity is Brep)
			{
				entity.ColorMethod = colorMethodType.byEntity;
			}
		}
	}

	private Entity _0023_003Dztdf8kWM_003D(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D, StringBuilder _0023_003DzzrdjZl2m7SBp)
	{
		OdDbSolid odDbSolid = _0023_003DzkeRlGGg30I6n as OdDbSolid;
		Point3D[] array = new Point3D[4];
		for (short num = 0; num < 4; num++)
		{
			OdGePoint3d odGePoint3d = new OdGePoint3d();
			odDbSolid.getPointAt(num, odGePoint3d);
			array[num] = new Point3D(_0023_003DzGa_t9CAQQGhs(odGePoint3d));
		}
		Vector3D _0023_003DzZbOaTIM_003D = new Vector3D(_0023_003Dzw_7skJnLqq6B(odDbSolid.normal()));
		Entity entity = AutodeskUtility.ReadSolid(array, _0023_003DzZbOaTIM_003D, odDbSolid.thickness(), _0023_003Dz2jlzUDbXSA47Py_0024dGg_003D_003D(_0023_003DzkeRlGGg30I6n), log);
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(entity, odDbSolid, _0023_003DzbONi0CI_003D);
		return entity;
	}

	internal static void _0023_003DzA3FnfbUjZ3OT(Dimension _0023_003Dz5XGM1CQ_003D, string _0023_003Dz72Nm_0024wP0Ra0L, string _0023_003DzNno9yiyZGalN)
	{
		string _0023_003Dz_YsdXPvAzPPU;
		if (!string.IsNullOrEmpty(_0023_003DzNno9yiyZGalN))
		{
			_0023_003Dz6oQ7E7o_003D(_0023_003DzNno9yiyZGalN, out var _0023_003DzkfAOhIE_003D, out var _, out _0023_003Dz_YsdXPvAzPPU);
			if (_0023_003DzkfAOhIE_003D != null && _0023_003DzkfAOhIE_003D.Count > 0)
			{
				_0023_003DzNno9yiyZGalN = _0023_003DzkfAOhIE_003D[0];
			}
			if (_0023_003DzNno9yiyZGalN.Contains(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532554)))
			{
				string[] array = _0023_003DzNno9yiyZGalN.Split(new string[1] { _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532554) }, 2, StringSplitOptions.None);
				_0023_003Dz5XGM1CQ_003D.TextPrefix = _0023_003DzXWCKMf0_003D(array[0]);
				_0023_003Dz5XGM1CQ_003D.TextSuffix = _0023_003DzXWCKMf0_003D(array[1]);
			}
			else
			{
				_0023_003Dz5XGM1CQ_003D.TextSuffix = _0023_003DzXWCKMf0_003D(_0023_003DzNno9yiyZGalN);
			}
		}
		if (_0023_003Dz72Nm_0024wP0Ra0L.Length > 0)
		{
			_0023_003Dz6oQ7E7o_003D(_0023_003Dz72Nm_0024wP0Ra0L, out var _0023_003DzkfAOhIE_003D2, out var _0023_003DzTVQPgYS29BHqNSYpYg_003D_003D2, out _0023_003Dz_YsdXPvAzPPU);
			if (_0023_003DzkfAOhIE_003D2 != null && _0023_003DzkfAOhIE_003D2.Count > 0)
			{
				_0023_003Dz72Nm_0024wP0Ra0L = _0023_003DzkfAOhIE_003D2[0];
			}
			if (_0023_003DzTVQPgYS29BHqNSYpYg_003D_003D2 != null && _0023_003DzTVQPgYS29BHqNSYpYg_003D_003D2.Length != 0)
			{
				_0023_003Dz5XGM1CQ_003D.WidthFactor = _0023_003DzTVQPgYS29BHqNSYpYg_003D_003D2[0];
			}
			_0023_003Dz5XGM1CQ_003D.TextOverride = _0023_003DzXWCKMf0_003D(_0023_003Dz72Nm_0024wP0Ra0L);
		}
	}

	internal static string _0023_003DzXWCKMf0_003D(string _0023_003Dz20iFUs4_003D)
	{
		if (_0023_003Dz20iFUs4_003D.Contains(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532547)))
		{
			_0023_003Dz20iFUs4_003D = _0023_003Dz20iFUs4_003D.Replace(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532547), _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532569));
		}
		if (_0023_003Dz20iFUs4_003D.Contains(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532561)))
		{
			_0023_003Dz20iFUs4_003D = _0023_003Dz20iFUs4_003D.Replace(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532561), _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532569));
		}
		if (_0023_003Dz20iFUs4_003D.Contains(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532647)))
		{
			_0023_003Dz20iFUs4_003D = _0023_003Dz20iFUs4_003D.Replace(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532647), _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532669));
		}
		if (_0023_003Dz20iFUs4_003D.Contains(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532661)))
		{
			_0023_003Dz20iFUs4_003D = _0023_003Dz20iFUs4_003D.Replace(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532661), _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532669));
		}
		if (_0023_003Dz20iFUs4_003D.Contains(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532619)))
		{
			_0023_003Dz20iFUs4_003D = _0023_003Dz20iFUs4_003D.Replace(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532619), _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532609));
		}
		if (_0023_003Dz20iFUs4_003D.Contains(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532633)))
		{
			_0023_003Dz20iFUs4_003D = _0023_003Dz20iFUs4_003D.Replace(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532633), _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532609));
		}
		if (_0023_003Dz20iFUs4_003D.Contains(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532719)))
		{
			_0023_003Dz20iFUs4_003D = _0023_003Dz20iFUs4_003D.Replace(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532719), _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532709));
		}
		if (_0023_003Dz20iFUs4_003D.Contains(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532733)))
		{
			_0023_003Dz20iFUs4_003D = _0023_003Dz20iFUs4_003D.Replace(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532733), string.Empty);
		}
		if (_0023_003Dz20iFUs4_003D.Contains(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532723)))
		{
			_0023_003Dz20iFUs4_003D = _0023_003Dz20iFUs4_003D.Replace(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532723), string.Empty);
		}
		if (_0023_003Dz20iFUs4_003D.Contains(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532681)))
		{
			_0023_003Dz20iFUs4_003D = _0023_003Dz20iFUs4_003D.Replace(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532681), string.Empty);
		}
		if (_0023_003Dz20iFUs4_003D.Contains(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532703)))
		{
			_0023_003Dz20iFUs4_003D = _0023_003Dz20iFUs4_003D.Replace(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532703), string.Empty);
		}
		int num = _0023_003Dz20iFUs4_003D.IndexOf(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532693));
		if (num != -1 && _0023_003Dz20iFUs4_003D.Length > num + 4)
		{
			string text = _0023_003Dz20iFUs4_003D.Substring(num + 2, 3);
			if (int.TryParse(text, out var result))
			{
				switch (result)
				{
				case 131:
					_0023_003Dz20iFUs4_003D = _0023_003Dz20iFUs4_003D.Replace(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532693) + text, _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532778));
					break;
				case 223:
					_0023_003Dz20iFUs4_003D = _0023_003Dz20iFUs4_003D.Replace(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532693) + text, _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532770));
					break;
				}
			}
		}
		return _0023_003Dz20iFUs4_003D;
	}

	internal static void _0023_003Dz6oQ7E7o_003D(string _0023_003DznhuxS9c_003D, out List<string> _0023_003DzkfAOhIE_003D, out double[] _0023_003DzTVQPgYS29BHqNSYpYg_003D_003D, out string _0023_003Dz_YsdXPvAzPPU)
	{
		_0023_003DzkfAOhIE_003D = new List<string>();
		bool flag = false;
		string text = string.Empty;
		List<double> list = new List<double>();
		_0023_003Dz_YsdXPvAzPPU = string.Empty;
		bool flag2 = true;
		int num = 1;
		for (int i = 0; i < _0023_003DznhuxS9c_003D.Length; i++)
		{
			char c = _0023_003DznhuxS9c_003D[i];
			if ((uint)c <= 92u)
			{
				switch (c)
				{
				case '\\':
					if (i >= _0023_003DznhuxS9c_003D.Length - 1)
					{
						break;
					}
					switch (_0023_003DznhuxS9c_003D[i + 1])
					{
					case 'F':
					case 'f':
					{
						flag = true;
						int num3 = i + 2;
						int num4 = _0023_003DznhuxS9c_003D.IndexOf(';', num3);
						if (num4 >= 0)
						{
							string text2 = _0023_003DznhuxS9c_003D.Substring(num3, num4 - num3);
							if (text2.EndsWith(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532795)))
							{
								_0023_003Dz_YsdXPvAzPPU = text2;
								i = num4 - 1;
							}
						}
						break;
					}
					case 'H':
						flag = true;
						break;
					case 'W':
					{
						flag = true;
						int num5 = i + 2;
						if (num5 < _0023_003DznhuxS9c_003D.Length)
						{
							string text3 = _0023_003DznhuxS9c_003D.Substring(num5, _0023_003DznhuxS9c_003D.IndexOf(';', num5) - num5);
							if (!flag2)
							{
								num--;
								_0023_003Dz2LPVyEbFqrvnUgHYLg_003D_003D(list, num);
							}
							num = 0;
							flag2 = false;
							if (text3[text3.Length - 1] == 'x')
							{
								text3 = text3.Substring(0, text3.Length - 1);
							}
							double num6 = Utility.DoubleParse(text3);
							list.Add((num6 > 10.0) ? 10.0 : num6);
						}
						break;
					}
					case 'T':
						flag = true;
						break;
					case 'C':
					case 'c':
						flag = true;
						break;
					case 'S':
						flag = true;
						break;
					case 'Q':
						flag = true;
						break;
					case 'A':
						flag = true;
						break;
					case 'L':
					case 'l':
						i++;
						continue;
					case 'O':
					case 'o':
						i++;
						continue;
					case 'P':
						flag2 = false;
						num++;
						break;
					case 'p':
						if (i == 0 || _0023_003DznhuxS9c_003D[i - 1] != '\\')
						{
							int num2 = _0023_003DznhuxS9c_003D.IndexOf(';', i) - (i + 1);
							i += num2;
							flag = true;
						}
						continue;
					case '~':
						text += _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532750);
						i++;
						continue;
					}
					break;
				case ';':
					if (flag)
					{
						flag = false;
						continue;
					}
					break;
				}
			}
			else if (c == '{' || c == '}')
			{
				continue;
			}
			if (!flag)
			{
				text += _0023_003DznhuxS9c_003D[i];
			}
		}
		_0023_003Dz2LPVyEbFqrvnUgHYLg_003D_003D(list, num);
		_0023_003DzkfAOhIE_003D.Add(text);
		if (list.Count > 0)
		{
			_0023_003DzTVQPgYS29BHqNSYpYg_003D_003D = list.ToArray();
		}
		else
		{
			_0023_003DzTVQPgYS29BHqNSYpYg_003D_003D = null;
		}
	}

	private static bool _0023_003Dz49ETy4A_003D(int _0023_003DzB_0024xYIw4_003D, string _0023_003Dz20iFUs4_003D, string _0023_003DzZSXPFe4_003D)
	{
		if (_0023_003Dz20iFUs4_003D.Length - _0023_003DzB_0024xYIw4_003D <= _0023_003DzZSXPFe4_003D.Length)
		{
			return false;
		}
		for (int i = 0; i < _0023_003DzZSXPFe4_003D.Length; i++)
		{
			if (_0023_003Dz20iFUs4_003D[_0023_003DzB_0024xYIw4_003D + i] != _0023_003DzZSXPFe4_003D[i])
			{
				return false;
			}
		}
		return true;
	}

	private static void _0023_003Dz2LPVyEbFqrvnUgHYLg_003D_003D(List<double> _0023_003DzDv9yZzf0_MSu, int _0023_003Dziqjxg9HnnzTEjfX3uw_003D_003D)
	{
		if (_0023_003Dziqjxg9HnnzTEjfX3uw_003D_003D > 0)
		{
			double item = -1.0;
			if (_0023_003DzDv9yZzf0_MSu.Count > 0)
			{
				item = _0023_003DzDv9yZzf0_MSu.Last();
			}
			for (int i = 0; i < _0023_003Dziqjxg9HnnzTEjfX3uw_003D_003D; i++)
			{
				_0023_003DzDv9yZzf0_MSu.Add(item);
			}
		}
	}

	private static void _0023_003DzP2egK5UEyMr9tbPzZQ_003D_003D(Plane _0023_003DzLodaGjk_003D, Point3D _0023_003Dz09_p21WQLJng, Point3D _0023_003Dz9_OZnpoBJU_p, Point3D _0023_003Dz_wzOG0JGsbOE)
	{
		double num = Vector3D.Subtract(_0023_003Dz9_OZnpoBJU_p, _0023_003Dz09_p21WQLJng).AngleInXY;
		if (num < 0.0)
		{
			num += Math.Ceiling((0.0 - num) / (Math.PI * 2.0)) * (Math.PI * 2.0);
		}
		if (num > Math.PI * 2.0)
		{
			num -= Math.Floor(num / (Math.PI * 2.0)) * (Math.PI * 2.0);
		}
		if (num > Math.PI * 3.0 / 4.0 && num < 5.497787143782138)
		{
			_0023_003DzLodaGjk_003D.Rotate(num + Math.PI, _0023_003DzLodaGjk_003D.AxisZ, _0023_003DzLodaGjk_003D.Origin);
		}
		else if (num != 0.0)
		{
			_0023_003DzLodaGjk_003D.Rotate(num, _0023_003DzLodaGjk_003D.AxisZ, _0023_003DzLodaGjk_003D.Origin);
		}
	}

	internal static Plane _0023_003DzH0a_I2VUM1u4(double[] _0023_003DztAbGEFA_003D)
	{
		Transformation.AutocadOCS(new Vector3D(_0023_003DztAbGEFA_003D), out var xAxis, out var yAxis);
		return new Plane(Point3D.Origin, xAxis, yAxis);
	}

	private Entity _0023_003Dzt9ZNO0vL5C9tMlyvVw_003D_003D(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		string unusedBlockName = Utility.GetUnusedBlockName(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532742), _0023_003DzbONi0CI_003D.importedBlocks);
		Block block = new Block(unusedBlockName);
		bool _0023_003DzKCTdf4c3hOS;
		Transformation _0023_003Dz48r_sMY_003D;
		OdBrBrep brep = _0023_003DzEwYKhLt7NDCd(_0023_003DzkeRlGGg30I6n, out _0023_003DzKCTdf4c3hOS, out _0023_003Dz48r_sMY_003D);
		OdBrBrepComplexTraverser odBrBrepComplexTraverser = new OdBrBrepComplexTraverser();
		odBrBrepComplexTraverser.setBrep(brep);
		while (!odBrBrepComplexTraverser.done())
		{
			OdBrComplex complex = odBrBrepComplexTraverser.getComplex();
			OdBrComplexShellTraverser odBrComplexShellTraverser = new OdBrComplexShellTraverser();
			odBrComplexShellTraverser.setComplex(complex);
			while (!odBrComplexShellTraverser.done())
			{
				OdBrShell shell = odBrComplexShellTraverser.getShell();
				OdBrShellFaceTraverser odBrShellFaceTraverser = new OdBrShellFaceTraverser();
				odBrShellFaceTraverser.setShell(shell);
				while (!odBrShellFaceTraverser.done())
				{
					OdBrFace face = odBrShellFaceTraverser.getFace();
					List<ICurve> list = new List<ICurve>();
					_0023_003DzNP_0024lO5Q_003D(face, list, Simplify, log, _0023_003Dz2jlzUDbXSA47Py_0024dGg_003D_003D(_0023_003DzkeRlGGg30I6n));
					if (!list[0].IsClosed)
					{
						list = new List<ICurve>();
					}
					OdGeNurbSurface odGeNurbSurface = new OdGeNurbSurface();
					face.getSurfaceAsNurb(odGeNurbSurface);
					Surface[] array = _0023_003Dz66XD8t08FzmtwMvk2g_003D_003D(odGeNurbSurface, list);
					if (array != null)
					{
						Surface[] array2 = array;
						foreach (Surface surface in array2)
						{
							if (_0023_003DzKCTdf4c3hOS)
							{
								surface.TransformBy(_0023_003Dz48r_sMY_003D);
							}
						}
						block.Entities.AddRange(array);
					}
					odBrShellFaceTraverser.next();
				}
				odBrComplexShellTraverser.next();
			}
			odBrBrepComplexTraverser.next();
		}
		if (block.Entities.Count > 1)
		{
			_0023_003DzbONi0CI_003D.importedBlocks.Add(block);
			BlockReferenceEx blockReferenceEx = new BlockReferenceEx(0.0, 0.0, 0.0, unusedBlockName, 1.0, 1.0, 1.0, 0.0);
			_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(blockReferenceEx, _0023_003DzkeRlGGg30I6n, _0023_003DzbONi0CI_003D);
			return blockReferenceEx;
		}
		if (block.Entities.Count == 1)
		{
			_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(block.Entities[0], _0023_003DzkeRlGGg30I6n, _0023_003DzbONi0CI_003D);
			return block.Entities[0];
		}
		log.AppendLine(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532754), _0023_003Dz2jlzUDbXSA47Py_0024dGg_003D_003D(_0023_003DzkeRlGGg30I6n)));
		return null;
	}

	private static OdBrBrep _0023_003DzEwYKhLt7NDCd(OdDbEntity _0023_003DzkeRlGGg30I6n, out bool _0023_003DzKCTdf4c3hOS4, out Transformation _0023_003Dz48r_sMY_003D)
	{
		OdBrBrep odBrBrep = new OdBrBrep();
		if (_0023_003DzkeRlGGg30I6n.isKindOf(OdDb3dSolid.desc()))
		{
			((OdDb3dSolid)_0023_003DzkeRlGGg30I6n).brep(odBrBrep);
		}
		else if (_0023_003DzkeRlGGg30I6n.isKindOf(OdDbBody.desc()))
		{
			((OdDbBody)_0023_003DzkeRlGGg30I6n).brep(odBrBrep);
		}
		else if (_0023_003DzkeRlGGg30I6n.isKindOf(OdDbRegion.desc()))
		{
			((OdDbRegion)_0023_003DzkeRlGGg30I6n).brep(odBrBrep);
		}
		else if (_0023_003DzkeRlGGg30I6n.isKindOf(OdDbSurface.desc()))
		{
			((OdDbSurface)_0023_003DzkeRlGGg30I6n).brep(odBrBrep);
		}
		_0023_003Dz48r_sMY_003D = null;
		OdGeMatrix3d odGeMatrix3d = new OdGeMatrix3d();
		_0023_003DzKCTdf4c3hOS4 = odBrBrep.getTransformation(odGeMatrix3d);
		if (_0023_003DzKCTdf4c3hOS4)
		{
			_0023_003Dz48r_sMY_003D = new Transformation();
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					_0023_003Dz48r_sMY_003D[j, i] = odGeMatrix3d[j, i];
				}
			}
		}
		return odBrBrep;
	}

	private Entity _0023_003DzfPmt5avcUJNg(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		Entity entity = null;
		bool _0023_003DzKCTdf4c3hOS;
		Transformation _0023_003Dz48r_sMY_003D;
		OdBrBrep _0023_003DzdD9bnvfI32yn = _0023_003DzEwYKhLt7NDCd(_0023_003DzkeRlGGg30I6n, out _0023_003DzKCTdf4c3hOS, out _0023_003Dz48r_sMY_003D);
		_ = _0023_003DzbONi0CI_003D.database;
		BrepBuilderInitialData _0023_003DzelFfqwk_003D = new BrepBuilderInitialData();
		OdBaseMaterialAndColorHelper odBaseMaterialAndColorHelper = new OdBaseMaterialAndColorHelper(_0023_003DzkeRlGGg30I6n.materialId().AsOdDbStubPointer());
		try
		{
			new OdBrepBuilderFiller();
			OdResult odResult = new _0023_003DzneMGJb_0024OxcpQ()._0023_003Dznx0nwVk_003D(_0023_003DzdD9bnvfI32yn, ref _0023_003DzelFfqwk_003D);
			if (odResult != OdResult.eOk)
			{
				throw new OdError(odResult);
			}
			entity = _0023_003DzC4WlF7rhTfMA(_0023_003DzelFfqwk_003D);
		}
		finally
		{
			((IDisposable)odBaseMaterialAndColorHelper).Dispose();
		}
		if (_0023_003DzKCTdf4c3hOS)
		{
			entity.TransformBy(_0023_003Dz48r_sMY_003D);
		}
		_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(entity, _0023_003DzkeRlGGg30I6n, _0023_003DzbONi0CI_003D);
		return entity;
	}

	private static ICurve _0023_003DzylKJIJjtulYa(OdGeCurve3d _0023_003Dz_0024Ac0hXouoPj_, bool _0023_003DzzpZimw8lXvV0ZYCOCw_003D_003D)
	{
		switch (_0023_003Dz_0024Ac0hXouoPj_.type())
		{
		case OdGe_EntityId.kCircArc3d:
		{
			OdGeCircArc3d odGeCircArc3d = new OdGeCircArc3d();
			odGeCircArc3d.Assign(_0023_003Dz_0024Ac0hXouoPj_);
			OdGePlane odGePlane = new OdGePlane();
			odGeCircArc3d.getPlane(odGePlane);
			return new Arc(_0023_003DzcZqeHueEnhjO(odGePlane), _0023_003DzHLWQmn1CvBx2(odGeCircArc3d.center()), odGeCircArc3d.radius(), odGeCircArc3d.startAng(), odGeCircArc3d.endAng());
		}
		case OdGe_EntityId.kEllipArc3d:
		{
			OdGeEllipArc3d odGeEllipArc3d = new OdGeEllipArc3d();
			odGeEllipArc3d.Assign(_0023_003Dz_0024Ac0hXouoPj_);
			OdGePlane odGePlane2 = new OdGePlane();
			odGeEllipArc3d.getPlane(odGePlane2);
			EllipticalArc ellipticalArc = new EllipticalArc(_0023_003DzcZqeHueEnhjO(odGePlane2), _0023_003DzHLWQmn1CvBx2(odGeEllipArc3d.center()), odGeEllipArc3d.majorRadius(), odGeEllipArc3d.minorRadius(), odGeEllipArc3d.startAng(), odGeEllipArc3d.endAng());
			ICurve result = ellipticalArc;
			if (_0023_003DzzpZimw8lXvV0ZYCOCw_003D_003D && ellipticalArc.IsCircle)
			{
				result = new Arc(ellipticalArc.Plane, Point2D.Origin, ellipticalArc.RadiusX, ellipticalArc.Domain.Low, ellipticalArc.Domain.High);
			}
			return result;
		}
		case OdGe_EntityId.kLineSeg3d:
		{
			OdGeLineSeg3d odGeLineSeg3d = new OdGeLineSeg3d();
			odGeLineSeg3d.Assign(_0023_003Dz_0024Ac0hXouoPj_);
			return new Line(_0023_003DzHLWQmn1CvBx2(odGeLineSeg3d.startPoint()), _0023_003DzHLWQmn1CvBx2(odGeLineSeg3d.endPoint()));
		}
		case OdGe_EntityId.kNurbCurve3d:
		{
			OdGeNurbCurve3d odGeNurbCurve3d = new OdGeNurbCurve3d();
			odGeNurbCurve3d.Assign(_0023_003Dz_0024Ac0hXouoPj_);
			bool flag = odGeNurbCurve3d.isRational();
			int num = odGeNurbCurve3d.numKnots();
			Point4D[] array = new Point4D[odGeNurbCurve3d.numControlPoints()];
			for (int i = 0; i < array.Length; i++)
			{
				double[] array2 = _0023_003DzGa_t9CAQQGhs(odGeNurbCurve3d.controlPointAt(i));
				double num2 = (flag ? odGeNurbCurve3d.weightAt(i) : 1.0);
				array[i] = new Point4D(array2[0] * num2, array2[1] * num2, array2[2] * num2, num2);
			}
			double[] array3 = new double[num];
			for (int j = 0; j < num; j++)
			{
				array3[j] = odGeNurbCurve3d.knotAt(j);
			}
			Curve curve = new Curve(odGeNurbCurve3d.degree(), array3, array);
			ICurve curve2 = curve;
			if (_0023_003DzzpZimw8lXvV0ZYCOCw_003D_003D)
			{
				ICurve curve3 = curve.Promote();
				if (curve3 != null)
				{
					curve2 = curve3;
				}
			}
			OdGePoint3d odGePoint3d = new OdGePoint3d();
			OdGePoint3d odGePoint3d2 = new OdGePoint3d();
			if (_0023_003Dz_0024Ac0hXouoPj_.hasStartPoint(odGePoint3d) && _0023_003Dz_0024Ac0hXouoPj_.hasEndPoint(odGePoint3d2))
			{
				Point3D point3D = new Point3D(_0023_003DzGa_t9CAQQGhs(odGePoint3d));
				Point3D point3D2 = new Point3D(_0023_003DzGa_t9CAQQGhs(odGePoint3d2));
				curve2.ClosestPointTo(point3D, out var t);
				curve2.ClosestPointTo(point3D2, out var t2);
				ICurve sub3;
				if (curve2 is Curve { IsClosed: not false } curve4 && t > t2)
				{
					if (curve4.SubCurve(t, curve4.Domain.High, out var sub) && curve4.SubCurve(curve4.Domain.Low, t2, out var sub2))
					{
						curve2 = Curve.Merge(sub, sub2);
					}
				}
				else if (curve2.SubCurve(point3D, point3D2, out sub3))
				{
					curve2 = sub3;
				}
			}
			return curve2;
		}
		default:
			return null;
		}
	}

	private Entity _0023_003DzUHsXPSh3Hpw_0024yNpTeA_003D_003D(OdDbEntity _0023_003DzkeRlGGg30I6n, ReadEntityData _0023_003DzbONi0CI_003D)
	{
		string text = _0023_003Dz2jlzUDbXSA47Py_0024dGg_003D_003D(_0023_003DzkeRlGGg30I6n);
		string text2 = _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532289) + text;
		Block block = new Block(text2);
		bool _0023_003DzKCTdf4c3hOS;
		Transformation _0023_003Dz48r_sMY_003D;
		OdBrBrep brep = _0023_003DzEwYKhLt7NDCd(_0023_003DzkeRlGGg30I6n, out _0023_003DzKCTdf4c3hOS, out _0023_003Dz48r_sMY_003D);
		int num = 0;
		OdBrBrepComplexTraverser odBrBrepComplexTraverser = new OdBrBrepComplexTraverser();
		odBrBrepComplexTraverser.setBrep(brep);
		while (!odBrBrepComplexTraverser.done())
		{
			try
			{
				int num2 = 0;
				OdBrComplex complex = odBrBrepComplexTraverser.getComplex();
				OdBrComplexShellTraverser odBrComplexShellTraverser = new OdBrComplexShellTraverser();
				odBrComplexShellTraverser.setComplex(complex);
				while (!odBrComplexShellTraverser.done())
				{
					try
					{
						int num3 = 0;
						OdBrShell shell = odBrComplexShellTraverser.getShell();
						OdBrShellFaceTraverser odBrShellFaceTraverser = new OdBrShellFaceTraverser();
						odBrShellFaceTraverser.setShell(shell);
						while (!odBrShellFaceTraverser.done())
						{
							OdBrFace face = odBrShellFaceTraverser.getFace();
							try
							{
								List<ICurve> _0023_003DzNvMb1bmdJzAs = new List<ICurve>();
								_0023_003DzNP_0024lO5Q_003D(face, _0023_003DzNvMb1bmdJzAs, Simplify, log, text);
								Surface[] array = _0023_003DzJId9tqPVcW7j(face, _0023_003DzNvMb1bmdJzAs);
								if (array != null)
								{
									Surface[] array2 = array;
									foreach (Surface surface in array2)
									{
										if (_0023_003DzKCTdf4c3hOS)
										{
											surface.TransformBy(_0023_003Dz48r_sMY_003D);
										}
										surface.ColorMethod = colorMethodType.byParent;
									}
									block.Entities.AddRange(array);
								}
								else
								{
									log.AppendLine(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532309), text, num3));
								}
							}
							catch (Exception)
							{
								log.AppendLine(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532354), text, num3));
							}
							num3++;
							odBrShellFaceTraverser.next();
						}
					}
					catch (Exception)
					{
						log.AppendLine(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532470), text, num2));
					}
					num2++;
					odBrComplexShellTraverser.next();
				}
			}
			catch (Exception)
			{
				log.AppendLine(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532524), text, num));
			}
			num++;
			odBrBrepComplexTraverser.next();
		}
		if (block.Entities.Count > 1)
		{
			_0023_003DzbONi0CI_003D.importedBlocks.Add(block);
			BlockReferenceEx blockReferenceEx = new BlockReferenceEx(0.0, 0.0, 0.0, text2, 1.0, 1.0, 1.0, 0.0);
			_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(blockReferenceEx, _0023_003DzkeRlGGg30I6n, _0023_003DzbONi0CI_003D);
			return blockReferenceEx;
		}
		if (block.Entities.Count == 1)
		{
			_0023_003Dz_n6IabwcGCM0nUB3_0024w_003D_003D(block.Entities[0], _0023_003DzkeRlGGg30I6n, _0023_003DzbONi0CI_003D);
			return block.Entities[0];
		}
		log.AppendLine(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532480), _0023_003Dz2jlzUDbXSA47Py_0024dGg_003D_003D(_0023_003DzkeRlGGg30I6n)));
		return null;
	}

	private Brep _0023_003DzC4WlF7rhTfMA(BrepBuilderInitialData _0023_003DzelFfqwk_003D)
	{
		List<Point3D> list = new List<Point3D>();
		List<Brep.Edge> list2 = new List<Brep.Edge>();
		List<Brep.Face> list3 = new List<Brep.Face>();
		List<List<Brep.Face>> list4 = new List<List<Brep.Face>>();
		BrepBuilderComplexArray complexes = _0023_003DzelFfqwk_003D.complexes;
		BrepBuilderInitialEdgeArray edges = _0023_003DzelFfqwk_003D.edges;
		for (int i = 0; i < edges.Count; i++)
		{
			OdGeCurve3d curve = edges[i].GetCurve();
			GC.SuppressFinalize(curve);
			ICurve curve2 = _0023_003DzylKJIJjtulYa(curve, Simplify);
			int num = list.IndexOf(curve2.StartPoint);
			if (num < 0)
			{
				list.Add(new Brep.Vertex(curve2.StartPoint.ToArray()));
				num = list.Count - 1;
			}
			int num2 = list.IndexOf(curve2.EndPoint);
			if (num2 < 0)
			{
				list.Add(new Brep.Vertex(curve2.EndPoint.ToArray()));
				num2 = list.Count - 1;
			}
			list2.Add(new Brep.Edge(curve2, num, num2));
		}
		for (int j = 0; j < complexes.Count; j++)
		{
			BrepBuilderShellsArray brepBuilderShellsArray = complexes[j];
			for (int k = 0; k < brepBuilderShellsArray.Count; k++)
			{
				BrepBuilderInitialSurfaceArray brepBuilderInitialSurfaceArray = brepBuilderShellsArray[k];
				List<Brep.Face> list5;
				if (k == 0)
				{
					list5 = list3;
				}
				else
				{
					list4.Add(new List<Brep.Face>());
					list5 = list4.Last();
				}
				for (int l = 0; l < brepBuilderInitialSurfaceArray.Count; l++)
				{
					BrepBuilderInitialSurface brepBuilderInitialSurface = brepBuilderInitialSurfaceArray[l];
					OdGeSurface pSurf = brepBuilderInitialSurface.get_pSurf();
					GC.SuppressFinalize(pSurf);
					bool _0023_003DzBrD_00240LVbUO_e;
					AnalyticSurf analyticSurf = _0023_003DzVeIp_0024T8pnT6ecvqOPy_0024qDi0_003D(pSurf, l, out _0023_003DzBrD_00240LVbUO_e);
					if (analyticSurf == null)
					{
						continue;
					}
					Brep.Loop[] array = new Brep.Loop[brepBuilderInitialSurface.loops.Count];
					if (brepBuilderInitialSurface.loops.Count == 0)
					{
						if (analyticSurf is ToroidalSurf toroidalSurf)
						{
							Plane plane = (Plane)toroidalSurf.Plane.Clone();
							Point3D point3D = plane.Origin + plane.AxisX * (toroidalSurf.MajorRadius + toroidalSurf.MinorRadius);
							list.Add(new Brep.Vertex(point3D.ToArray()));
							Circle curve3 = new Circle(plane, toroidalSurf.MajorRadius + toroidalSurf.MinorRadius);
							list2.Add(new Brep.Edge(curve3, 0, 0));
							int curveIndex = list2.Count - 1;
							Plane plane2 = new Plane(plane.Origin, plane.AxisX, plane.AxisZ);
							Point3D center = plane.Origin + plane.AxisX * toroidalSurf.MajorRadius;
							Circle curve4 = new Circle(plane2, center, toroidalSurf.MinorRadius);
							list2.Add(new Brep.Edge(curve4, 0, 0));
							int curveIndex2 = list2.Count - 1;
							Brep.OrientedEdge[] segments = new Brep.OrientedEdge[4]
							{
								new Brep.OrientedEdge(curveIndex),
								new Brep.OrientedEdge(curveIndex2),
								new Brep.OrientedEdge(curveIndex, sense: false),
								new Brep.OrientedEdge(curveIndex2, sense: false)
							};
							array = new Brep.Loop[1]
							{
								new Brep.Loop(segments)
							};
						}
						else if (analyticSurf is SphericalSurf { Plane: var plane3 } sphericalSurf)
						{
							Point3D point3D2 = plane3.Origin - plane3.AxisZ * sphericalSurf.Radius;
							Point3D point3D3 = plane3.Origin + plane3.AxisZ * sphericalSurf.Radius;
							list.Add(new Brep.Vertex(point3D2.ToArray()));
							list.Add(new Brep.Vertex(point3D3.ToArray()));
							Plane plane4 = new Plane(plane3.Origin, plane3.AxisX, plane3.AxisZ);
							Arc curve5 = new Arc(plane4, plane4.Origin, sphericalSurf.Radius, 4.71238898038469, 7.853981633974483);
							list2.Add(new Brep.Edge(curve5, 0, 1));
							int curveIndex3 = list2.Count - 1;
							Brep.OrientedEdge[] segments2 = new Brep.OrientedEdge[2]
							{
								new Brep.OrientedEdge(curveIndex3),
								new Brep.OrientedEdge(curveIndex3, sense: false)
							};
							array = new Brep.Loop[1]
							{
								new Brep.Loop(segments2)
							};
						}
					}
					else
					{
						for (int m = 0; m < brepBuilderInitialSurface.loops.Count; m++)
						{
							BrepBuilderInitialLoop brepBuilderInitialLoop = brepBuilderInitialSurface.loops[m];
							Brep.OrientedEdge[] array2 = new Brep.OrientedEdge[brepBuilderInitialLoop.coedges.Count];
							for (int n = 0; n < brepBuilderInitialLoop.coedges.Count; n++)
							{
								BrepBuilderInitialCoedge brepBuilderInitialCoedge = brepBuilderInitialLoop.coedges[n];
								array2[n] = new Brep.OrientedEdge((int)brepBuilderInitialCoedge.GetEdgeIndex(), brepBuilderInitialCoedge.direction == OdBrepBuilder_EntityDirection.kForward);
							}
							array[m] = new Brep.Loop(array2);
						}
					}
					bool flag = brepBuilderInitialSurface.direction == OdBrepBuilder_EntityDirection.kForward;
					if (_0023_003DzBrD_00240LVbUO_e)
					{
						flag = !flag;
					}
					list5.Add(new Brep.Face(analyticSurf, array, flag));
				}
			}
		}
		Brep.Face[][] array3 = new Brep.Face[list4.Count][];
		for (int num3 = 0; num3 < list4.Count; num3++)
		{
			array3[num3] = list4[num3].ToArray();
		}
		Brep brep = new Brep(list.ToArray(), list2.ToArray(), list3.ToArray(), array3);
		_0023_003DzgEsgsgpxzw1I99JWbq_0024mh84_003D(brep);
		brep.FixFaces(log);
		Utility.SplitEdgeOnSurfaceSeams(brep, log);
		return brep;
	}

	private void _0023_003DzgEsgsgpxzw1I99JWbq_0024mh84_003D(Brep _0023_003DzdD9bnvfI32yn)
	{
		Brep.Edge[] edges = _0023_003DzdD9bnvfI32yn.Edges;
		Point3D[] vertices = _0023_003DzdD9bnvfI32yn.Vertices;
		bool flag = false;
		bool[] array = new bool[edges.Length];
		bool[] array2 = new bool[vertices.Length];
		for (int i = 0; i < edges.Length; i++)
		{
			Brep.Edge edge = edges[i];
			if (edge.Parents != null && edge.Parents.Length == 2 && edge.Parents[0] == edge.Parents[1] && !_0023_003DzsEHBNxGd7w5t(_0023_003DzdD9bnvfI32yn.Faces[edge.Parents[0]], i) && edge.StartPointIndex != edge.EndPointIndex && ((Brep.Vertex)vertices[edge.StartPointIndex]).Parents.Length < 2 && ((Brep.Vertex)vertices[edge.EndPointIndex]).Parents.Length < 2)
			{
				_0023_003DzdPsrCM4PafTubEyrVA_003D_003D(_0023_003DzdD9bnvfI32yn.Faces[edge.Parents[0]], i);
				array[i] = true;
				array2[edge.StartPointIndex] = true;
				array2[edge.EndPointIndex] = true;
				flag = true;
			}
		}
		if (!flag)
		{
			return;
		}
		int[] array3 = new int[vertices.Length];
		int[] array4 = new int[edges.Length];
		List<Brep.Edge> list = new List<Brep.Edge>(edges.Length);
		List<Point3D> list2 = new List<Point3D>(vertices.Length);
		int j = 0;
		int num = 0;
		for (; j < vertices.Length; j++)
		{
			if (!array2[j])
			{
				list2.Add(vertices[j]);
				array3[j] = num;
				num++;
			}
			else
			{
				array3[j] = -1;
			}
		}
		int k = 0;
		int num2 = 0;
		for (; k < edges.Length; k++)
		{
			if (!array[k])
			{
				Brep.Edge edge2 = edges[k];
				edge2.StartPointIndex = array3[edge2.StartPointIndex];
				edge2.EndPointIndex = array3[edge2.EndPointIndex];
				list.Add(edge2);
				array4[k] = num2;
				num2++;
			}
			else
			{
				array4[k] = -1;
			}
		}
		_0023_003DzdD9bnvfI32yn.Faces = _0023_003Dzfwa3syJ_0024yawCMCHadg_003D_003D(_0023_003DzdD9bnvfI32yn.Faces, _0023_003DzdD9bnvfI32yn.Edges, array4);
		for (int l = 0; l < _0023_003DzdD9bnvfI32yn.Inners.Length; l++)
		{
			_0023_003DzdD9bnvfI32yn.Inners[l] = _0023_003Dzfwa3syJ_0024yawCMCHadg_003D_003D(_0023_003DzdD9bnvfI32yn.Inners[l], _0023_003DzdD9bnvfI32yn.Edges, array4);
		}
		_0023_003DzdD9bnvfI32yn.Edges = list.ToArray();
		_0023_003DzdD9bnvfI32yn.Vertices = list2.ToArray();
	}

	private bool _0023_003DzsEHBNxGd7w5t(Brep.Face _0023_003DzILwyq_00243CBdkJ, int _0023_003DzcFZaF7l5IFNg)
	{
		Brep.Loop[] loops = _0023_003DzILwyq_00243CBdkJ.Loops;
		for (int i = 0; i < loops.Length; i++)
		{
			Brep.OrientedEdge[] segments = loops[i].Segments;
			if (segments[0].CurveIndex == _0023_003DzcFZaF7l5IFNg && segments[segments.Length - 1].CurveIndex == _0023_003DzcFZaF7l5IFNg)
			{
				return true;
			}
			for (int j = 0; j < segments.Length - 1; j++)
			{
				if (segments[j].CurveIndex == _0023_003DzcFZaF7l5IFNg && segments[j + 1].CurveIndex == _0023_003DzcFZaF7l5IFNg)
				{
					return true;
				}
			}
		}
		return false;
	}

	private static void _0023_003DzdPsrCM4PafTubEyrVA_003D_003D(Brep.Face _0023_003DzILwyq_00243CBdkJ, int _0023_003DzcFZaF7l5IFNg)
	{
		_0023_003DzZ6H8Nz1428SdwkYR9QVZr9w_003D _0023_003DzZ6H8Nz1428SdwkYR9QVZr9w_003D2 = new _0023_003DzZ6H8Nz1428SdwkYR9QVZr9w_003D();
		_0023_003DzZ6H8Nz1428SdwkYR9QVZr9w_003D2._0023_003DzcFZaF7l5IFNg = _0023_003DzcFZaF7l5IFNg;
		Brep.Loop[] array = new Brep.Loop[_0023_003DzILwyq_00243CBdkJ.Loops.Length + 1];
		int num = 0;
		for (int i = 0; i < _0023_003DzILwyq_00243CBdkJ.Loops.Length; i++)
		{
			Brep.Loop loop = _0023_003DzILwyq_00243CBdkJ.Loops[i];
			if (loop.Segments.All(_0023_003DzZ6H8Nz1428SdwkYR9QVZr9w_003D2._0023_003Dz9IaAjRPz2DrjstIVZqFkX1k_003D))
			{
				array[num++] = loop;
				continue;
			}
			List<Brep.OrientedEdge> list = new List<Brep.OrientedEdge>();
			List<Brep.OrientedEdge> list2 = new List<Brep.OrientedEdge>();
			Brep.OrientedEdge[] segments = loop.Segments;
			bool flag = true;
			for (int j = 0; j < segments.Length; j++)
			{
				if (segments[j].CurveIndex == _0023_003DzZ6H8Nz1428SdwkYR9QVZr9w_003D2._0023_003DzcFZaF7l5IFNg)
				{
					flag = !flag;
				}
				else if (flag)
				{
					list.Add(segments[j]);
				}
				else
				{
					list2.Add(segments[j]);
				}
			}
			array[num++] = new Brep.Loop(list.ToArray(), loop.Sense);
			array[num++] = new Brep.Loop(list2.ToArray(), loop.Sense);
		}
		_0023_003DzILwyq_00243CBdkJ.Loops = array;
	}

	private static Brep.Face[] _0023_003Dzfwa3syJ_0024yawCMCHadg_003D_003D(IList<Brep.Face> _0023_003Dzc5z5LhvKRCL9, IList<Brep.Edge> _0023_003Dzn_l0R8cXPUy4, int[] _0023_003DzCS02Bu0_003D)
	{
		_0023_003Dz1VSuB38_HHzIGQjEcDMY_AU_003D _0023_003Dz1VSuB38_HHzIGQjEcDMY_AU_003D2 = new _0023_003Dz1VSuB38_HHzIGQjEcDMY_AU_003D();
		List<Brep.Face> list = new List<Brep.Face>(_0023_003Dzc5z5LhvKRCL9.Count);
		_0023_003Dz1VSuB38_HHzIGQjEcDMY_AU_003D2._0023_003DzYhTOc6EvKBAh = new int[_0023_003Dzc5z5LhvKRCL9.Count];
		bool flag = false;
		for (int i = 0; i < _0023_003Dzc5z5LhvKRCL9.Count; i++)
		{
			Brep.Face face = _0023_003Dzc5z5LhvKRCL9[i];
			bool flag2 = true;
			Brep.Loop[] loops = face.Loops;
			foreach (Brep.Loop loop in loops)
			{
				for (int k = 0; k < loop.Segments.Length; k++)
				{
					loop.Segments[k].CurveIndex = _0023_003DzCS02Bu0_003D[loop.Segments[k].CurveIndex];
					if (loop.Segments[k].CurveIndex == -1)
					{
						flag2 = false;
						flag = true;
						break;
					}
				}
			}
			if (flag2)
			{
				_0023_003Dz1VSuB38_HHzIGQjEcDMY_AU_003D2._0023_003DzYhTOc6EvKBAh[i] = list.Count;
				list.Add(face);
			}
			else
			{
				_0023_003Dz1VSuB38_HHzIGQjEcDMY_AU_003D2._0023_003DzYhTOc6EvKBAh[i] = -1;
			}
		}
		if (flag)
		{
			foreach (Brep.Edge item in _0023_003Dzn_l0R8cXPUy4)
			{
				item.Parents = item.Parents.Select(_0023_003Dz1VSuB38_HHzIGQjEcDMY_AU_003D2._0023_003Dz2fGQqCES7fiKb2Hfy5vGriU_003D).Where(_0023_003DzE18LVS0_003D._0023_003Dz8VglJ9E_003D._0023_003DzG2yJ04EO1bbUJ0HjFIFXX1hQOknL).ToArray();
			}
		}
		return list.ToArray();
	}

	private AnalyticSurf _0023_003DzVeIp_0024T8pnT6ecvqOPy_0024qDi0_003D(OdGeSurface _0023_003DzqtHH7_trVBOvM0VzCg_003D_003D, int _0023_003DzPqe3X00_003D, out bool _0023_003DzBrD_00240LVbUO_e)
	{
		_0023_003DzBrD_00240LVbUO_e = false;
		switch (_0023_003DzqtHH7_trVBOvM0VzCg_003D_003D.type())
		{
		case OdGe_EntityId.kCone:
		{
			OdGeCone odGeCone = new OdGeCone();
			odGeCone.Assign(_0023_003DzqtHH7_trVBOvM0VzCg_003D_003D);
			_0023_003DzBrD_00240LVbUO_e = !odGeCone.isOuterNormal();
			Vector3D vector3D = _0023_003DzBTaQ_0024K9mCK1O(odGeCone.axisOfSymmetry());
			Vector3D vector3D2 = _0023_003DzBTaQ_0024K9mCK1O(odGeCone.refAxis());
			Point3D point3D = _0023_003DzHLWQmn1CvBx2(odGeCone.baseCenter());
			double num = new Plane(point3D, vector3D2, Vector3D.Cross(vector3D, vector3D2)).DistanceTo(new Point3D(_0023_003DzGa_t9CAQQGhs(odGeCone.apex())));
			double num2 = odGeCone.halfAngle();
			if ((num > 0.0 && num2 > 0.0) || (num < 0.0 && num2 < 0.0))
			{
				vector3D.Negate();
			}
			if (num2 < 1E-06 || odGeCone.baseRadius() < 1E-06)
			{
				return null;
			}
			return new ConicalSurf(point3D, vector3D, vector3D2, odGeCone.baseRadius(), num2, _0023_003DzPqe3X00_003D);
		}
		case OdGe_EntityId.kCylinder:
		{
			OdGeCylinder odGeCylinder = new OdGeCylinder();
			odGeCylinder.Assign(_0023_003DzqtHH7_trVBOvM0VzCg_003D_003D);
			_0023_003DzBrD_00240LVbUO_e = !odGeCylinder.isOuterNormal();
			return new CylindricalSurf(_0023_003DzHLWQmn1CvBx2(odGeCylinder.origin()), _0023_003DzBTaQ_0024K9mCK1O(odGeCylinder.axisOfSymmetry()), _0023_003DzBTaQ_0024K9mCK1O(odGeCylinder.refAxis()), odGeCylinder.radius(), _0023_003DzPqe3X00_003D);
		}
		case OdGe_EntityId.kEllipCylinder:
		{
			OdGeEllipCylinder odGeEllipCylinder = new OdGeEllipCylinder();
			odGeEllipCylinder.Assign(_0023_003DzqtHH7_trVBOvM0VzCg_003D_003D);
			_0023_003DzBrD_00240LVbUO_e = !odGeEllipCylinder.isOuterNormal();
			Plane plane2 = new Plane(_0023_003DzHLWQmn1CvBx2(odGeEllipCylinder.origin()), _0023_003DzBTaQ_0024K9mCK1O(odGeEllipCylinder.majorAxis()), _0023_003DzBTaQ_0024K9mCK1O(odGeEllipCylinder.minorAxis()));
			odGeEllipCylinder.getAngles(out var startAng, out var endAng);
			return new TabulatedSurf(new EllipticalArc(plane2, plane2.Origin, odGeEllipCylinder.majorRadius(), odGeEllipCylinder.minorRadius(), startAng, endAng), _0023_003DzBTaQ_0024K9mCK1O(odGeEllipCylinder.axisOfSymmetry()));
		}
		case OdGe_EntityId.kEllipCone:
		{
			OdGeEllipCone odGeEllipCone = new OdGeEllipCone();
			odGeEllipCone.Assign(_0023_003DzqtHH7_trVBOvM0VzCg_003D_003D);
			_0023_003DzBrD_00240LVbUO_e = !odGeEllipCone.isOuterNormal();
			return null;
		}
		case OdGe_EntityId.kNurbSurface:
		{
			OdGeNurbSurface odGeNurbSurface = new OdGeNurbSurface();
			odGeNurbSurface.Assign(_0023_003DzqtHH7_trVBOvM0VzCg_003D_003D);
			return _0023_003Dz66XD8t08FzmtwMvk2g_003D_003D(odGeNurbSurface);
		}
		case OdGe_EntityId.kPlane:
		{
			OdGePlane odGePlane = new OdGePlane();
			odGePlane.Assign(_0023_003DzqtHH7_trVBOvM0VzCg_003D_003D);
			Plane plane = new Plane(_0023_003DzHLWQmn1CvBx2(odGePlane.pointOnPlane()), _0023_003DzBTaQ_0024K9mCK1O(odGePlane.normal()));
			return new PlanarSurf(plane.Origin, plane.AxisZ, plane.AxisX, _0023_003DzPqe3X00_003D);
		}
		case OdGe_EntityId.kSphere:
		{
			OdGeSphere odGeSphere = new OdGeSphere();
			odGeSphere.Assign(_0023_003DzqtHH7_trVBOvM0VzCg_003D_003D);
			_0023_003DzBrD_00240LVbUO_e = !odGeSphere.isOuterNormal();
			return new SphericalSurf(_0023_003DzHLWQmn1CvBx2(odGeSphere.center()), _0023_003DzBTaQ_0024K9mCK1O(odGeSphere.northAxis()), _0023_003DzBTaQ_0024K9mCK1O(odGeSphere.refAxis()), odGeSphere.radius(), _0023_003DzPqe3X00_003D);
		}
		case OdGe_EntityId.kTorus:
		{
			OdGeTorus odGeTorus = new OdGeTorus();
			odGeTorus.Assign(_0023_003DzqtHH7_trVBOvM0VzCg_003D_003D);
			_0023_003DzBrD_00240LVbUO_e = !odGeTorus.isOuterNormal();
			return new ToroidalSurf(_0023_003DzHLWQmn1CvBx2(odGeTorus.center()), _0023_003DzBTaQ_0024K9mCK1O(odGeTorus.axisOfSymmetry()), _0023_003DzBTaQ_0024K9mCK1O(odGeTorus.refAxis()), odGeTorus.majorRadius(), Math.Abs(odGeTorus.minorRadius()), _0023_003DzPqe3X00_003D);
		}
		default:
			return null;
		}
	}

	private Surface[] _0023_003Dz66XD8t08FzmtwMvk2g_003D_003D(OdGeNurbSurface _0023_003Dzf002XZOYhcNp, List<ICurve> _0023_003DzNvMb1bmdJzAs)
	{
		return _0023_003Dz66XD8t08FzmtwMvk2g_003D_003D(_0023_003Dzf002XZOYhcNp).GetSurface(_0023_003DzNvMb1bmdJzAs.ToArray());
	}

	private NurbsSurf _0023_003Dz66XD8t08FzmtwMvk2g_003D_003D(OdGeNurbSurface _0023_003Dzf002XZOYhcNp)
	{
		OdGePoint3dArray odGePoint3dArray = new OdGePoint3dArray();
		OdDoubleArray odDoubleArray = new OdDoubleArray();
		OdGeKnotVector odGeKnotVector = new OdGeKnotVector();
		OdGeKnotVector odGeKnotVector2 = new OdGeKnotVector();
		_0023_003Dzf002XZOYhcNp.getDefinition(out var degreeInU, out var degreeInV, out var _, out var _, out var numControlPointsInU, out var numControlPointsInV, odGePoint3dArray, odDoubleArray, odGeKnotVector, odGeKnotVector2);
		Point4D[,] array = new Point4D[numControlPointsInU, numControlPointsInV];
		int num = 0;
		int num2 = 0;
		int num3 = numControlPointsInU * numControlPointsInV;
		for (int i = 0; i < num3; i++)
		{
			OdGePoint3d odGePoint3d = odGePoint3dArray[i];
			double num4 = ((odDoubleArray.Count > 0) ? odDoubleArray[i] : 1.0);
			array[num2, num] = new Point4D(odGePoint3d.x * num4, odGePoint3d.y * num4, odGePoint3d.z * num4, num4);
			if (num > numControlPointsInV - 2)
			{
				num = -1;
				num2++;
			}
			num++;
		}
		double[] array2 = new double[odGeKnotVector.length()];
		for (int j = 0; j < array2.Length; j++)
		{
			array2[j] = odGeKnotVector[j];
		}
		double[] array3 = new double[odGeKnotVector2.length()];
		for (int k = 0; k < array3.Length; k++)
		{
			array3[k] = odGeKnotVector2[k];
		}
		return new NurbsSurf(degreeInU, array2, degreeInV, array3, array);
	}

	private Surface[] _0023_003DzJId9tqPVcW7j(OdBrFace _0023_003DzILwyq_00243CBdkJ, List<ICurve> _0023_003DzNvMb1bmdJzAs)
	{
		OdGeExternalBoundedSurface odGeExternalBoundedSurface = new OdGeExternalBoundedSurface();
		OdGeSurface surface = _0023_003DzILwyq_00243CBdkJ.getSurface();
		if (surface == null)
		{
			return null;
		}
		odGeExternalBoundedSurface.Assign(surface);
		OdGeSurface baseSurfaceEx = odGeExternalBoundedSurface.getBaseSurfaceEx();
		bool orientToSurface = _0023_003DzILwyq_00243CBdkJ.getOrientToSurface();
		switch (baseSurfaceEx.type())
		{
		case OdGe_EntityId.kPlane:
			return _0023_003DzksommBsQBI_0024jVfIvTg_003D_003D(baseSurfaceEx, _0023_003DzNvMb1bmdJzAs, orientToSurface);
		case OdGe_EntityId.kCylinder:
			return _0023_003DznRjqlDyqP0IjACnn4A_003D_003D(baseSurfaceEx, _0023_003DzNvMb1bmdJzAs, orientToSurface);
		case OdGe_EntityId.kCone:
			return _0023_003DzkWbcC6gw2rEn(baseSurfaceEx, _0023_003DzNvMb1bmdJzAs, orientToSurface);
		case OdGe_EntityId.kSphere:
			return _0023_003Dz74n5tjI6X6FAvXw_Hg_003D_003D(baseSurfaceEx, _0023_003DzNvMb1bmdJzAs, orientToSurface);
		case OdGe_EntityId.kTorus:
			return _0023_003Dz62Ie0upz7o8xgdAxzQ_003D_003D(baseSurfaceEx, _0023_003DzNvMb1bmdJzAs, orientToSurface);
		case OdGe_EntityId.kEllipCylinder:
		{
			OdGeEllipCylinder odGeEllipCylinder = new OdGeEllipCylinder();
			odGeEllipCylinder.Assign(baseSurfaceEx);
			Plane plane2 = new Plane(new Point3D(_0023_003DzGa_t9CAQQGhs(odGeEllipCylinder.origin())), new Vector3D(_0023_003Dzw_7skJnLqq6B(odGeEllipCylinder.majorAxis())), new Vector3D(_0023_003Dzw_7skJnLqq6B(odGeEllipCylinder.minorAxis())));
			Ellipse ellipse2 = new Ellipse(plane2, Point2D.Origin, odGeEllipCylinder.majorRadius(), odGeEllipCylinder.minorRadius());
			OdGeInterval odGeInterval2 = new OdGeInterval();
			odGeEllipCylinder.getHeight(odGeInterval2);
			Surface[] array2 = ellipse2.ExtrudeAsSurface(plane2.AxisZ * odGeInterval2.length());
			Surface[] array3 = array2;
			for (int i = 0; i < array3.Length; i++)
			{
				array3[i].Translate(plane2.AxisZ * odGeInterval2.lowerBound());
			}
			return array2;
		}
		case OdGe_EntityId.kEllipCone:
		{
			OdGeEllipCone odGeEllipCone = new OdGeEllipCone();
			odGeEllipCone.Assign(baseSurfaceEx);
			Plane plane = new Plane(new Point3D(_0023_003DzGa_t9CAQQGhs(odGeEllipCone.baseCenter())), new Vector3D(_0023_003Dzw_7skJnLqq6B(odGeEllipCone.majorAxis())), new Vector3D(_0023_003Dzw_7skJnLqq6B(odGeEllipCone.minorAxis())));
			Ellipse ellipse = new Ellipse(plane, Point2D.Origin, odGeEllipCone.majorRadius(), odGeEllipCone.minorRadius());
			OdGeInterval odGeInterval = new OdGeInterval();
			odGeEllipCone.getHeight(odGeInterval);
			double amount = Math.Tan(odGeEllipCone.halfAngle()) * odGeInterval.length();
			ICurve[] array = ellipse.Offset(amount, plane.AxisZ);
			Curve curve = (Curve)((array != null) ? array[0] : null);
			ellipse.Translate(plane.AxisZ * odGeInterval.lowerBound());
			curve.Translate(plane.AxisZ * odGeInterval.upperBound());
			return new Surface[1] { Surface.Ruled(ellipse, curve) };
		}
		case OdGe_EntityId.kNurbSurface:
		{
			OdGeNurbSurface odGeNurbSurface2 = new OdGeNurbSurface();
			odGeNurbSurface2.Assign(baseSurfaceEx);
			return _0023_003Dz66XD8t08FzmtwMvk2g_003D_003D(odGeNurbSurface2, _0023_003DzNvMb1bmdJzAs);
		}
		default:
		{
			OdGeNurbSurface odGeNurbSurface = new OdGeNurbSurface();
			if (_0023_003DzILwyq_00243CBdkJ.getSurfaceAsNurb(odGeNurbSurface) == OdBrErrorStatus.odbrOK)
			{
				return _0023_003Dz66XD8t08FzmtwMvk2g_003D_003D(odGeNurbSurface, _0023_003DzNvMb1bmdJzAs);
			}
			return null;
		}
		}
	}

	private Surface[] _0023_003Dz62Ie0upz7o8xgdAxzQ_003D_003D(OdGeSurface _0023_003DzAE0Sk_0024SHfgoJ, List<ICurve> _0023_003DzNvMb1bmdJzAs, bool _0023_003DzAwUPzmXvKx_0024n)
	{
		OdGeTorus odGeTorus = new OdGeTorus();
		odGeTorus.Assign(_0023_003DzAE0Sk_0024SHfgoJ);
		bool reverse = odGeTorus.isOuterNormal() != _0023_003DzAwUPzmXvKx_0024n;
		return new ToroidalSurf(new Point3D(_0023_003DzGa_t9CAQQGhs(odGeTorus.center())), new Vector3D(_0023_003Dzw_7skJnLqq6B(odGeTorus.axisOfSymmetry())), new Vector3D(_0023_003Dzw_7skJnLqq6B(odGeTorus.refAxis())), odGeTorus.majorRadius(), odGeTorus.minorRadius()).GetSurface(_0023_003DzNvMb1bmdJzAs.ToArray(), reverse);
	}

	private Surface[] _0023_003DzkWbcC6gw2rEn(OdGeSurface _0023_003DzAE0Sk_0024SHfgoJ, List<ICurve> _0023_003DzNvMb1bmdJzAs, bool _0023_003DzAwUPzmXvKx_0024n)
	{
		OdGeCone odGeCone = new OdGeCone();
		odGeCone.Assign(_0023_003DzAE0Sk_0024SHfgoJ);
		bool reverse = odGeCone.isOuterNormal() != _0023_003DzAwUPzmXvKx_0024n;
		Vector3D vector3D = new Vector3D(_0023_003Dzw_7skJnLqq6B(odGeCone.axisOfSymmetry()));
		Vector3D vector3D2 = new Vector3D(_0023_003Dzw_7skJnLqq6B(odGeCone.refAxis()));
		Point3D point3D = new Point3D(_0023_003DzGa_t9CAQQGhs(odGeCone.baseCenter()));
		double num = new Plane(point3D, vector3D2, Vector3D.Cross(vector3D, vector3D2)).DistanceTo(new Point3D(_0023_003DzGa_t9CAQQGhs(odGeCone.apex())));
		double num2 = odGeCone.halfAngle();
		if ((num > 0.0 && num2 > 0.0) || (num < 0.0 && num2 < 0.0))
		{
			vector3D.Negate();
		}
		return new ConicalSurf(point3D, vector3D, vector3D2, odGeCone.baseRadius(), num2).GetSurface(_0023_003DzNvMb1bmdJzAs.ToArray(), reverse);
	}

	private Surface[] _0023_003Dz74n5tjI6X6FAvXw_Hg_003D_003D(OdGeSurface _0023_003DzAE0Sk_0024SHfgoJ, List<ICurve> _0023_003DzNvMb1bmdJzAs, bool _0023_003DzAwUPzmXvKx_0024n)
	{
		OdGeSphere odGeSphere = new OdGeSphere();
		odGeSphere.Assign(_0023_003DzAE0Sk_0024SHfgoJ);
		bool reverse = odGeSphere.isOuterNormal() != _0023_003DzAwUPzmXvKx_0024n;
		return new SphericalSurf(new Point3D(_0023_003DzGa_t9CAQQGhs(odGeSphere.center())), new Vector3D(_0023_003Dzw_7skJnLqq6B(odGeSphere.northAxis())), new Vector3D(_0023_003Dzw_7skJnLqq6B(odGeSphere.refAxis())), Math.Abs(odGeSphere.radius())).GetSurface(_0023_003DzNvMb1bmdJzAs.ToArray(), reverse);
	}

	private Surface[] _0023_003DzksommBsQBI_0024jVfIvTg_003D_003D(OdGeSurface _0023_003DzAE0Sk_0024SHfgoJ, List<ICurve> _0023_003DzNvMb1bmdJzAs, bool _0023_003DzAwUPzmXvKx_0024n)
	{
		OdGePlane odGePlane = new OdGePlane();
		odGePlane.Assign(_0023_003DzAE0Sk_0024SHfgoJ);
		OdGePoint3d odGePoint3d = new OdGePoint3d();
		OdGeVector3d odGeVector3d = new OdGeVector3d();
		OdGeVector3d odGeVector3d2 = new OdGeVector3d();
		odGePlane.getCoordSystem(odGePoint3d, odGeVector3d, odGeVector3d2);
		int outerIndex = Utility.GetOuterIndex(_0023_003DzNvMb1bmdJzAs, 1.0);
		ICurve value = _0023_003DzNvMb1bmdJzAs[0];
		_0023_003DzNvMb1bmdJzAs[0] = _0023_003DzNvMb1bmdJzAs[outerIndex];
		_0023_003DzNvMb1bmdJzAs[outerIndex] = value;
		Vector3D vector3D = new Vector3D(_0023_003Dzw_7skJnLqq6B(odGeVector3d));
		Vector3D b = new Vector3D(_0023_003Dzw_7skJnLqq6B(odGeVector3d2));
		Vector3D normal = Vector3D.Cross(vector3D, b);
		return new PlanarSurf(new Point3D(_0023_003DzGa_t9CAQQGhs(odGePoint3d)), normal, vector3D).GetSurface(_0023_003DzNvMb1bmdJzAs.ToArray(), odGePlane.isNormalReversed() == _0023_003DzAwUPzmXvKx_0024n);
	}

	private Surface[] _0023_003DznRjqlDyqP0IjACnn4A_003D_003D(OdGeSurface _0023_003DzAE0Sk_0024SHfgoJ, List<ICurve> _0023_003DzNvMb1bmdJzAs, bool _0023_003DzAwUPzmXvKx_0024n)
	{
		OdGeCylinder odGeCylinder = new OdGeCylinder();
		odGeCylinder.Assign(_0023_003DzAE0Sk_0024SHfgoJ);
		bool reverse = odGeCylinder.isOuterNormal() != _0023_003DzAwUPzmXvKx_0024n;
		Vector3D axis = new Vector3D(_0023_003Dzw_7skJnLqq6B(odGeCylinder.axisOfSymmetry()));
		Vector3D refDir = new Vector3D(_0023_003Dzw_7skJnLqq6B(odGeCylinder.refAxis()));
		return new CylindricalSurf(new Point3D(_0023_003DzGa_t9CAQQGhs(odGeCylinder.origin())), axis, refDir, odGeCylinder.radius()).GetSurface(_0023_003DzNvMb1bmdJzAs.ToArray(), reverse);
	}

	[DebuggerStepThrough]
	private static bool _0023_003DzNP_0024lO5Q_003D(OdBrFace _0023_003DzILwyq_00243CBdkJ, IList<ICurve> _0023_003DzNvMb1bmdJzAs, bool _0023_003DzzpZimw8lXvV0ZYCOCw_003D_003D, StringBuilder _0023_003DzWfEJJHg_003D, string _0023_003Dz9jAe__Y_003D)
	{
		try
		{
			OdBrFaceLoopTraverser odBrFaceLoopTraverser = new OdBrFaceLoopTraverser();
			odBrFaceLoopTraverser.setFace(_0023_003DzILwyq_00243CBdkJ);
			while (!odBrFaceLoopTraverser.done())
			{
				OdBrLoop loop = odBrFaceLoopTraverser.getLoop();
				List<ICurve> list = new List<ICurve>();
				try
				{
					OdBrLoopEdgeTraverser odBrLoopEdgeTraverser = new OdBrLoopEdgeTraverser();
					odBrLoopEdgeTraverser.setLoop(loop);
					while (!odBrLoopEdgeTraverser.done())
					{
						bool edgeOrientToLoop = odBrLoopEdgeTraverser.getEdgeOrientToLoop();
						OdGeCurve3d curve = odBrLoopEdgeTraverser.getEdge().getCurve();
						ICurve curve2 = _0023_003DzylKJIJjtulYa(curve, _0023_003DzzpZimw8lXvV0ZYCOCw_003D_003D);
						if (curve2 == null)
						{
							_0023_003DzWfEJJHg_003D.AppendLine(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531060), _0023_003Dz9jAe__Y_003D, curve));
							return false;
						}
						if (!edgeOrientToLoop)
						{
							curve2.Reverse();
						}
						list.Add(curve2);
						odBrLoopEdgeTraverser.next();
					}
				}
				catch (Exception)
				{
				}
				if (list.Count == 1)
				{
					_0023_003DzNvMb1bmdJzAs.Add(list[0]);
				}
				else if (list.Count > 1)
				{
					_0023_003DzNvMb1bmdJzAs.Add(new CompositeCurve(list, sortAndOrient: false));
				}
				odBrFaceLoopTraverser.next();
			}
		}
		catch
		{
		}
		return true;
	}

	public BlockReference CreateXRef(string blockName, Point3D basePoint, IWorkspace workspace, string exportFilePath = null, autodeskExportType exportMode = autodeskExportType.ExternalReference)
	{
		return CreateXRef(blockName, basePoint, workspace.Document, exportFilePath, exportMode);
	}

	public BlockReference CreateXRef(string blockName, Point3D basePoint, Document document, string exportFilePath = null, autodeskExportType exportMode = autodeskExportType.ExternalReference)
	{
		if (document.Blocks.Contains(blockName))
		{
			throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531126));
		}
		if (exportMode == autodeskExportType.Embedded)
		{
			throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531173));
		}
		Block block = new Block(blockName);
		if (string.IsNullOrEmpty(exportFilePath))
		{
			block._filePath = base.FilePath;
		}
		else
		{
			block._filePath = exportFilePath;
		}
		block._exportMode = exportMode;
		string text = blockName + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355529060);
		Dictionary<string, string> _0023_003Dz_LDkGmjANHG = new Dictionary<string, string>();
		for (int i = 0; i < base.Layers.Count; i++)
		{
			Layer layer = base.Layers[i];
			if (layer.Name != _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525371))
			{
				if (string.IsNullOrEmpty(layer.XRefName))
				{
					layer.XRefName = blockName;
				}
				else
				{
					layer.XRefName = text + layer.XRefName;
				}
				string text2 = text + layer.Name;
				_0023_003Dz_LDkGmjANHG.Add(layer.Name, text2);
				layer.Name = text2;
			}
		}
		_0023_003Dzj1sOdnkOR22w(_0023_003Dz_LDkGmjANHG);
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (Block block2 in base.Blocks)
		{
			string value = text + block2.Name;
			dictionary.Add(block2.Name, value);
		}
		string rootBlockName = base.Blocks.RootBlockName;
		BlockKeyedCollection blocks = base.Blocks;
		EntityList.ReplaceBlockNames<Block>(dictionary, base.Entities, ref blocks);
		base.Blocks = blocks;
		rootBlockName = dictionary[rootBlockName];
		base.Blocks.SetRootBlock(rootBlockName);
		foreach (Block block3 in base.Blocks)
		{
			if (string.IsNullOrEmpty(block3.XRefName))
			{
				block3.XRefName = blockName;
			}
			else
			{
				block3.XRefName = text + block3.XRefName;
			}
		}
		base.TextStyles = _0023_003Dz94gFOAYRp7WU<TextStyleKeyedCollection, TextStyle>(base.TextStyles, blockName, text, out _0023_003Dz_LDkGmjANHG);
		_0023_003DzKXsL4qSp01z9(_0023_003Dz_LDkGmjANHG);
		base.LineTypes = _0023_003Dz94gFOAYRp7WU<LineTypeKeyedCollection, LineType>(base.LineTypes, blockName, text, out _0023_003Dz_LDkGmjANHG);
		_0023_003DzR8LczVNo1gKC(_0023_003Dz_LDkGmjANHG);
		foreach (Layer layer2 in base.Layers)
		{
			if (!string.IsNullOrEmpty(layer2.LineTypeName))
			{
				layer2.LineTypeName = _0023_003Dz_LDkGmjANHG[layer2.LineTypeName];
			}
		}
		ImportSettings(document);
		FillAllCollectionsData(document);
		block.Entities.AddRange(base.Entities);
		block.BasePoint = BasePoint;
		document.Blocks.Add(block);
		base.Layers.Clear(addDefaultLayer: false);
		base.TextStyles.Clear(addDefaultTextStyle: false);
		base.Blocks.Clear();
		return new BlockReferenceEx(new Translation(0.0 - basePoint.X, 0.0 - basePoint.Y, 0.0 - basePoint.Z), blockName);
	}

	private void _0023_003DzKXsL4qSp01z9(Dictionary<string, string> _0023_003Dzv7XKd3qNFbVt)
	{
		foreach (Block block in base.Blocks)
		{
			_0023_003DzKXsL4qSp01z9(_0023_003Dzv7XKd3qNFbVt, block.Entities);
		}
	}

	private void _0023_003DzR8LczVNo1gKC(Dictionary<string, string> _0023_003Dzv7XKd3qNFbVt)
	{
		foreach (Block block in base.Blocks)
		{
			_0023_003DzR8LczVNo1gKC(_0023_003Dzv7XKd3qNFbVt, block.Entities);
		}
	}

	private void _0023_003Dzj1sOdnkOR22w(Dictionary<string, string> _0023_003Dzv7XKd3qNFbVt)
	{
		foreach (Block block in base.Blocks)
		{
			_0023_003Dzj1sOdnkOR22w(_0023_003Dzv7XKd3qNFbVt, block.Entities);
		}
	}

	private T _0023_003Dz94gFOAYRp7WU<T, Q>(T _0023_003DzbONi0CI_003D, string _0023_003Dzxaw56Ac_003D, string _0023_003Dz9T5rkrs_003D, out Dictionary<string, string> _0023_003Dz_LDkGmjANHG5) where T : EyeshotKeyedCollection<Q>, new() where Q : IKeyedCollectionItem<Q>
	{
		T val = new T();
		_0023_003Dz_LDkGmjANHG5 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		foreach (Q item in _0023_003DzbONi0CI_003D)
		{
			string text = _0023_003Dz9T5rkrs_003D + item.GetKey();
			_0023_003Dz_LDkGmjANHG5.Add(item.GetKey(), text);
			item.SetKey(text);
			val.Add(item);
			if (!(item is IReadWriteDataEx))
			{
				throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531258));
			}
			IReadWriteDataEx readWriteDataEx = (IReadWriteDataEx)(object)item;
			if (string.IsNullOrEmpty(((IDataEx)readWriteDataEx).XRefName))
			{
				((IWriteDataEx)readWriteDataEx).XRefName = _0023_003Dzxaw56Ac_003D;
			}
			else
			{
				((IWriteDataEx)readWriteDataEx).XRefName = _0023_003Dz9T5rkrs_003D + ((IDataEx)readWriteDataEx).XRefName;
			}
		}
		return val;
	}

	internal static void _0023_003DzKXsL4qSp01z9(Dictionary<string, string> _0023_003Dzv7XKd3qNFbVt, IList<Entity> _0023_003DzLpVMKc8_003D)
	{
		foreach (Entity item in _0023_003DzLpVMKc8_003D)
		{
			if (item is Text text)
			{
				if (!string.IsNullOrEmpty(text.StyleName) && _0023_003Dzv7XKd3qNFbVt.ContainsKey(text.StyleName))
				{
					text.StyleName = _0023_003Dzv7XKd3qNFbVt[text.StyleName];
				}
			}
			else if (item is BlockReference blockReference)
			{
				foreach (KeyValuePair<string, AttributeReference> attribute in blockReference.Attributes)
				{
					string styleName = attribute.Value.StyleName;
					if (!string.IsNullOrEmpty(styleName) && _0023_003Dzv7XKd3qNFbVt.ContainsKey(styleName))
					{
						attribute.Value.StyleName = _0023_003Dzv7XKd3qNFbVt[styleName];
					}
				}
			}
			else
			{
				if (!(item is Table table))
				{
					continue;
				}
				double num = table.RowsNum;
				double num2 = table.ColumnsNum;
				for (int i = 0; (double)i < num; i++)
				{
					for (int j = 0; (double)j < num2; j++)
					{
						string styleName2 = table.GetStyleName(i, j);
						if (!string.IsNullOrEmpty(styleName2) && _0023_003Dzv7XKd3qNFbVt.ContainsKey(styleName2))
						{
							table.SetStyleName(i, j, _0023_003Dzv7XKd3qNFbVt[styleName2]);
						}
					}
				}
			}
		}
	}

	internal static void _0023_003DzR8LczVNo1gKC(Dictionary<string, string> _0023_003Dzv7XKd3qNFbVt, IList<Entity> _0023_003DzLpVMKc8_003D)
	{
		foreach (Entity item in _0023_003DzLpVMKc8_003D)
		{
			if (!string.IsNullOrEmpty(item.LineTypeName))
			{
				item.LineTypeName = _0023_003Dzv7XKd3qNFbVt[item.LineTypeName];
			}
		}
	}

	internal static void _0023_003Dzj1sOdnkOR22w(Dictionary<string, string> _0023_003Dzv7XKd3qNFbVt, IList<Entity> _0023_003DzLpVMKc8_003D)
	{
		if (_0023_003DzLpVMKc8_003D == null)
		{
			return;
		}
		foreach (Entity item in _0023_003DzLpVMKc8_003D)
		{
			if (_0023_003Dzv7XKd3qNFbVt.ContainsKey(item.LayerName))
			{
				item.LayerName = _0023_003Dzv7XKd3qNFbVt[item.LayerName];
			}
			if (!(item is BlockReference blockReference))
			{
				continue;
			}
			foreach (KeyValuePair<string, AttributeReference> attribute in blockReference.Attributes)
			{
				if (_0023_003Dzv7XKd3qNFbVt.ContainsKey(attribute.Value.LayerName))
				{
					attribute.Value.LayerName = _0023_003Dzv7XKd3qNFbVt[attribute.Value.LayerName];
				}
			}
		}
	}

	public bool SetView(IViewport viewport)
	{
		return _0023_003DzQSyYVcquy00G._0023_003DznJnOZYQ_003D(viewport.Camera, viewport.Size);
	}

	public Image GetThumbnail()
	{
		MemoryTransaction memoryTransaction = MemoryManager.GetMemoryManager().StartTransaction();
		Autodesk.InitializeServices();
		ExHostAppServices exHostAppServices = new ExHostAppServices();
		memoryTransaction.AddObject(exHostAppServices);
		exHostAppServices.disableOutput(disable: true);
		if (string.IsNullOrEmpty(Password))
		{
			Password = string.Empty;
		}
		OdMemoryStream odMemoryStream = OdMemoryStream.createNew();
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003Dz_0024Ri82GA5O_VX(base.Stream, odMemoryStream);
		base.Stream.Position = 0L;
		uint dataLength;
		IntPtr pData = exHostAppServices.readFile(odMemoryStream, allowCPConversion: false, partialLoad: false, Password).thumbnailBitmap(out dataLength);
		OdThumbnailImage odThumbnailImage = new OdThumbnailImage();
		odThumbnailImage.setImageData(pData, dataLength);
		OdGiRasterImage rasterImage = odThumbnailImage.getRasterImage();
		Image result = null;
		if (rasterImage != null)
		{
			result = Image.FromStream(_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzUgzHlB5nH4GA(rasterImage));
		}
		MemoryManager.GetMemoryManager().StopTransaction(memoryTransaction);
		return result;
	}
}
