using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;

namespace devDept.Serialization;

public sealed class FileBody
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<Entity, bool> _0023_003DzbGEok_27Y1wKUTt_8Q_003D_003D;

		public static Func<Entity, bool> _0023_003DzKaqRotJmxEFx6dMXbQ_003D_003D;

		public static Predicate<Entity> _0023_003DzbvtUvRmE4OYMjCbAKg_003D_003D;

		public static Func<Entity, bool> _0023_003DzCpLew4mwS7bPbmh1ng_003D_003D;

		public static Func<Entity, bool> _0023_003DzFh8WCHOL1C9_hSlg5w_003D_003D;

		public static Func<Entity, bool> _0023_003Dzy2jp6HB_JpIFtPLmhw_003D_003D;

		internal bool _0023_003DzubT_0024T7mbIl18yP9Gk9YcO_4_003D(Entity _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D != null;
		}

		internal bool _0023_003Dz624gvMMZ3xVWorrrVf7B2M4_003D(Entity _0023_003DzBJFJHwk_003D)
		{
			if (!(_0023_003DzBJFJHwk_003D is Text))
			{
				return !(_0023_003DzBJFJHwk_003D is Leader);
			}
			return false;
		}

		internal bool _0023_003DzLiQ4Jse2hYq22BZORpdVNRU_003D(Entity _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D == null;
		}

		internal bool _0023_003DzpWBaMddKdD9pkRc_8jdq4j8_003D(Entity _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D is Hatch;
		}

		internal bool _0023_003DzzVCRpCVAnCZ8kDpIZQ3lCwY_003D(Entity _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D is Hatch;
		}

		internal bool _0023_003Dz9bW_0024FHmpqbyK_fk2T_F4XAo_003D(Entity _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D is Hatch;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IList<Entity> _0023_003DzirHP2g6iDbM7YBocSw_003D_003D = new List<Entity>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BlockKeyedCollection _0023_003DzF97WMq_0024wP8gY4FUd3g_003D_003D = new BlockKeyedCollection();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private LayerKeyedCollection _0023_003DzSolg7xy8nvImQawkYg_003D_003D = new LayerKeyedCollection();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private MaterialKeyedCollection _0023_003Dz3LjsdFNpuYbi3t4cdInWH3BVys6B = new MaterialKeyedCollection();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private LineTypeKeyedCollection _0023_003DzDuFrfh82AJ9_0024N05F5w_003D_003D = new LineTypeKeyedCollection();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private HatchPatternKeyedCollection _0023_003DzvIp358N6rMgkJ7PYLL0OJ9c_003D = new HatchPatternKeyedCollection();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextStyleKeyedCollection _0023_003DzOdpS5s330wsiSi_tbQ_003D_003D = new TextStyleKeyedCollection();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Camera _0023_003DzGyIsDk_u4amx6yBl9w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003DzO36PKpaF4knnuUUxHLXY5y8_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private contentType _0023_003Dz0_TuQIYhGWxtNwupNyBJaSQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzO4HJO4bI__0024LFq83YeA3_0024z3PJDXC3xJQrgQiUTUk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dzar6tca88bHRLw_DiNJ4hJBg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzEwiUy0ySXtZ_0024PnnW__0024JW2z2N7zTO;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dzzba8S9fyOSLMC288rurRzwYuPPkx2YJVriGhOAY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DztqQi3rjrbrPqlzF8s9ElMEIXWcEn;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dzjt2t9kUhkC6jvrneQJ4hOjyv3MetYyqTXQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz2z7Y6AOePbhtTWp0EhyRf9c_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dzn6dMPg9MBadg7t211ytUh2MYBp3gQoXh9w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzSscRYVy5HHjjWNkyUOKjmW3sT_002405UuJREKoLO4E_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz0xTUSTe5Zlvk9iiSt_0024ZeS4C0LZQ2;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz7ZePTfmbXLD7iZjJNOFmuXI06uADhK2j0I9vdZo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SheetKeyedCollection _0023_003Dzg8nlmv0eKohsdiB_xSf9Bbk_003D = new SheetKeyedCollection();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BlockKeyedCollection _0023_003DzOn1sTM3P_00245F7GzXfR0Bp7ag_003D = new BlockKeyedCollection();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private LayerKeyedCollection _0023_003DziTDLtPhuGDW4gtvgqMzp_0024_s_003D = new LayerKeyedCollection();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private LineTypeKeyedCollection _0023_003DzaLJz2KfS5zFOSDw92P1te_w_003D = new LineTypeKeyedCollection();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private HatchPatternKeyedCollection _0023_003DzPN6S75HNamFqkaKAlaLmsjE_003D = new HatchPatternKeyedCollection();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextStyleKeyedCollection _0023_003DzS_tNlfBCYbK9eI17OFSvzIk_003D = new TextStyleKeyedCollection();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string[] _0023_003Dzh2fc4Px1d96Izw29vg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private fileType[] _0023_003DzF0pJQYivdRevJaPuYQ_003D_003D;

	public IList<Entity> Entities
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzirHP2g6iDbM7YBocSw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzirHP2g6iDbM7YBocSw_003D_003D = value;
		}
	}

	public BlockKeyedCollection Blocks
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzF97WMq_0024wP8gY4FUd3g_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzF97WMq_0024wP8gY4FUd3g_003D_003D = value;
		}
	}

	public LayerKeyedCollection Layers
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzSolg7xy8nvImQawkYg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzSolg7xy8nvImQawkYg_003D_003D = value;
		}
	}

	public MaterialKeyedCollection Materials
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz3LjsdFNpuYbi3t4cdInWH3BVys6B;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz3LjsdFNpuYbi3t4cdInWH3BVys6B = value;
		}
	}

	public LineTypeKeyedCollection LineTypes
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzDuFrfh82AJ9_0024N05F5w_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzDuFrfh82AJ9_0024N05F5w_003D_003D = value;
		}
	}

	public HatchPatternKeyedCollection HatchPatterns
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzvIp358N6rMgkJ7PYLL0OJ9c_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzvIp358N6rMgkJ7PYLL0OJ9c_003D = value;
		}
	}

	public TextStyleKeyedCollection TextStyles
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzOdpS5s330wsiSi_tbQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzOdpS5s330wsiSi_tbQ_003D_003D = value;
		}
	}

	public Camera Camera
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzGyIsDk_u4amx6yBl9w_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzGyIsDk_u4amx6yBl9w_003D_003D = value;
		}
	}

	public float LineTypeScale
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzO36PKpaF4knnuUUxHLXY5y8_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzO36PKpaF4knnuUUxHLXY5y8_003D = value;
		}
	}

	public string DrawingSilhouettesLayerName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzO4HJO4bI__0024LFq83YeA3_0024z3PJDXC3xJQrgQiUTUk_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzO4HJO4bI__0024LFq83YeA3_0024z3PJDXC3xJQrgQiUTUk_003D = value;
		}
	}

	public string DrawingEdgesLayerName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzar6tca88bHRLw_DiNJ4hJBg_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzar6tca88bHRLw_DiNJ4hJBg_003D = value;
		}
	}

	public string DrawingWiresLayerName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzEwiUy0ySXtZ_0024PnnW__0024JW2z2N7zTO;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzEwiUy0ySXtZ_0024PnnW__0024JW2z2N7zTO = value;
		}
	}

	public string DrawingHiddenSilhouettesLayerName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzzba8S9fyOSLMC288rurRzwYuPPkx2YJVriGhOAY_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzzba8S9fyOSLMC288rurRzwYuPPkx2YJVriGhOAY_003D = value;
		}
	}

	public string DrawingHiddenEdgesLayerName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DztqQi3rjrbrPqlzF8s9ElMEIXWcEn;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DztqQi3rjrbrPqlzF8s9ElMEIXWcEn = value;
		}
	}

	public string DrawingHiddenWiresLayerName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzjt2t9kUhkC6jvrneQJ4hOjyv3MetYyqTXQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzjt2t9kUhkC6jvrneQJ4hOjyv3MetYyqTXQ_003D_003D = value;
		}
	}

	public string DrawingSectionsLayerName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz2z7Y6AOePbhtTWp0EhyRf9c_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz2z7Y6AOePbhtTWp0EhyRf9c_003D = value;
		}
	}

	public string DrawingGhostCirclesLayerName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzn6dMPg9MBadg7t211ytUh2MYBp3gQoXh9w_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzn6dMPg9MBadg7t211ytUh2MYBp3gQoXh9w_003D_003D = value;
		}
	}

	public string DrawingCenterlinesLayerName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzSscRYVy5HHjjWNkyUOKjmW3sT_002405UuJREKoLO4E_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzSscRYVy5HHjjWNkyUOKjmW3sT_002405UuJREKoLO4E_003D = value;
		}
	}

	public string DrawingHiddenSegmentsLineTypeName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz0xTUSTe5Zlvk9iiSt_0024ZeS4C0LZQ2;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz0xTUSTe5Zlvk9iiSt_0024ZeS4C0LZQ2 = value;
		}
	}

	public string DrawingCenterlinesLineTypeName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz7ZePTfmbXLD7iZjJNOFmuXI06uADhK2j0I9vdZo_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz7ZePTfmbXLD7iZjJNOFmuXI06uADhK2j0I9vdZo_003D = value;
		}
	}

	public SheetKeyedCollection DrawingSheets
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzg8nlmv0eKohsdiB_xSf9Bbk_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzg8nlmv0eKohsdiB_xSf9Bbk_003D = value;
		}
	}

	public BlockKeyedCollection DrawingBlocks
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzOn1sTM3P_00245F7GzXfR0Bp7ag_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzOn1sTM3P_00245F7GzXfR0Bp7ag_003D = value;
		}
	}

	public LayerKeyedCollection DrawingLayers
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DziTDLtPhuGDW4gtvgqMzp_0024_s_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DziTDLtPhuGDW4gtvgqMzp_0024_s_003D = value;
		}
	}

	public LineTypeKeyedCollection DrawingLineTypes
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzaLJz2KfS5zFOSDw92P1te_w_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzaLJz2KfS5zFOSDw92P1te_w_003D = value;
		}
	}

	public HatchPatternKeyedCollection DrawingHatchPatterns
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzPN6S75HNamFqkaKAlaLmsjE_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzPN6S75HNamFqkaKAlaLmsjE_003D = value;
		}
	}

	public TextStyleKeyedCollection DrawingTextStyles
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzS_tNlfBCYbK9eI17OFSvzIk_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzS_tNlfBCYbK9eI17OFSvzIk_003D = value;
		}
	}

	public string[] Paths
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzh2fc4Px1d96Izw29vg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzh2fc4Px1d96Izw29vg_003D_003D = value;
		}
	}

	public fileType[] Types
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzF0pJQYivdRevJaPuYQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzF0pJQYivdRevJaPuYQ_003D_003D = value;
		}
	}

	public FileBody(WriteFileParams writeParams)
		: this(writeParams.Entities, writeParams.Layers, writeParams.Blocks, writeParams.Materials, writeParams.TextStyles, writeParams.LineTypes, writeParams.HatchPatterns, null, writeParams.LineTypeScale, writeParams.Content, writeParams.Drawing)
	{
	}

	internal FileBody(IList<Entity> _0023_003Dzv7xH9gk_003D = null, LayerKeyedCollection _0023_003DzeWJg3NJnk3WA = null, BlockKeyedCollection _0023_003DzJO1FWlQ_003D = null, MaterialKeyedCollection _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D = null, TextStyleKeyedCollection _0023_003Dz9LJ7v7xBdLfO = null, LineTypeKeyedCollection _0023_003DzA3_0024EZ731xRIG = null, HatchPatternKeyedCollection _0023_003DzzX6rzVb3Ybsi = null, Camera _0023_003Dz10qtbIGWAWjL = null, float _0023_003DzgvoDUidltBEx = 1f, contentType _0023_003DzB5M5dYA_003D = contentType.GeometryAndTessellation, DrawingDocument _0023_003Dzu9im1ZQ_003D = null)
	{
		if (_0023_003Dzv7xH9gk_003D != null)
		{
			Entities = _0023_003Dzv7xH9gk_003D;
		}
		if (_0023_003DzeWJg3NJnk3WA != null)
		{
			Layers = _0023_003DzeWJg3NJnk3WA;
		}
		if (_0023_003DzJO1FWlQ_003D != null)
		{
			Blocks = _0023_003DzJO1FWlQ_003D;
		}
		if (_0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D != null)
		{
			Materials = _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D;
		}
		if (_0023_003Dz9LJ7v7xBdLfO != null)
		{
			TextStyles = _0023_003Dz9LJ7v7xBdLfO;
		}
		if (_0023_003DzA3_0024EZ731xRIG != null)
		{
			LineTypes = _0023_003DzA3_0024EZ731xRIG;
		}
		if (_0023_003DzzX6rzVb3Ybsi != null)
		{
			HatchPatterns = _0023_003DzzX6rzVb3Ybsi;
		}
		if (_0023_003Dz10qtbIGWAWjL != null)
		{
			Camera = _0023_003Dz10qtbIGWAWjL;
		}
		LineTypeScale = _0023_003DzgvoDUidltBEx;
		_0023_003Dzna2pNJsJvtEdBGg_0024mQ_003D_003D(_0023_003Dzu9im1ZQ_003D, _0023_003DzB5M5dYA_003D);
	}

	private void _0023_003Dzna2pNJsJvtEdBGg_0024mQ_003D_003D(DrawingDocument _0023_003Dzu9im1ZQ_003D, contentType _0023_003DzB5M5dYA_003D)
	{
		if (_0023_003Dzu9im1ZQ_003D == null)
		{
			return;
		}
		DrawingSilhouettesLayerName = _0023_003Dzu9im1ZQ_003D.SilhouettesLayerName;
		DrawingEdgesLayerName = _0023_003Dzu9im1ZQ_003D.EdgesLayerName;
		DrawingWiresLayerName = _0023_003Dzu9im1ZQ_003D.WiresLayerName;
		DrawingHiddenSilhouettesLayerName = _0023_003Dzu9im1ZQ_003D.HiddenSilhouettesLayerName;
		DrawingHiddenEdgesLayerName = _0023_003Dzu9im1ZQ_003D.HiddenEdgesLayerName;
		DrawingHiddenWiresLayerName = _0023_003Dzu9im1ZQ_003D.HiddenWiresLayerName;
		DrawingSectionsLayerName = _0023_003Dzu9im1ZQ_003D.SectionsLayerName;
		DrawingCenterlinesLayerName = _0023_003Dzu9im1ZQ_003D.CenterlinesLayerName;
		DrawingHiddenSegmentsLineTypeName = _0023_003Dzu9im1ZQ_003D.HiddenSegmentsLineTypeName;
		DrawingCenterlinesLineTypeName = _0023_003Dzu9im1ZQ_003D.CenterlinesLineTypeName;
		DrawingSheets = _0023_003Dzu9im1ZQ_003D.Sheets;
		DrawingBlocks = new BlockKeyedCollection(_0023_003Dzu9im1ZQ_003D.Blocks);
		if (_0023_003DzB5M5dYA_003D == contentType.Geometry)
		{
			int num = DrawingBlocks.IndexOf(_0023_003Dzu9im1ZQ_003D.RootBlock);
			if (num >= 0)
			{
				DrawingBlocks.RemoveAt(num);
			}
			foreach (Sheet drawingSheet in DrawingSheets)
			{
				foreach (Entity entity in drawingSheet.Entities)
				{
					if (entity is View view && DrawingBlocks.TryGetValue(view.BlockName, out var value))
					{
						int num2 = DrawingBlocks.IndexOf(value);
						if (num2 < num)
						{
							num--;
						}
						DrawingBlocks.RemoveAt(num2);
					}
				}
			}
			if (num >= 0)
			{
				DrawingBlocks.Insert(num, _0023_003Dzu9im1ZQ_003D.RootBlock);
			}
		}
		DrawingLayers = _0023_003Dzu9im1ZQ_003D.Layers;
		DrawingLineTypes = _0023_003Dzu9im1ZQ_003D.LineTypes;
		DrawingHatchPatterns = _0023_003Dzu9im1ZQ_003D.HatchPatterns;
		DrawingTextStyles = _0023_003Dzu9im1ZQ_003D.TextStyles;
	}

	internal contentType _0023_003Dza7hr5mLPdEIJ()
	{
		return _0023_003Dz0_TuQIYhGWxtNwupNyBJaSQ_003D;
	}

	internal void _0023_003DzbT1s7HaLJi_a(contentType _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dz0_TuQIYhGWxtNwupNyBJaSQ_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public FileBodySurrogate ConvertToSurrogate()
	{
		return new FileBodySurrogate(this);
	}

	internal void _0023_003DzjxMrVLP5c_wq(contentType _0023_003DzB5M5dYA_003D, bool _0023_003DzSGOANnwavSFDNqyIWLedlKk_003D, StringBuilder _0023_003DzZ9xh1dFMrWh_0024)
	{
		Entities = Entities.Where((Entity _0023_003DzBJFJHwk_003D) => _0023_003DzBJFJHwk_003D != null).ToList();
		Func<Entity, bool> func = null;
		if (_0023_003DzB5M5dYA_003D == contentType.Tessellation)
		{
			func = _0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz624gvMMZ3xVWorrrVf7B2M4_003D;
		}
		if (func != null)
		{
			Entities = Entities.Where(func).ToList();
		}
		foreach (Block block in Blocks)
		{
			block.Entities.baseList.RemoveAll(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzLiQ4Jse2hYq22BZORpdVNRU_003D);
			if (func != null)
			{
				List<Entity> collection = block.Entities.Where(func).ToList();
				block.Entities.ClearNoDispose();
				block.Entities.baseList.AddRange(collection);
			}
		}
		if (!_0023_003DzSGOANnwavSFDNqyIWLedlKk_003D || _0023_003DzB5M5dYA_003D != contentType.Tessellation)
		{
			return;
		}
		foreach (Sheet drawingSheet in DrawingSheets)
		{
			for (int num = 0; num < drawingSheet.Entities.Count; num++)
			{
				if (drawingSheet.Entities[num] is BlockReference blockReference && !DrawingBlocks.Contains(blockReference.BlockName))
				{
					_0023_003DzZ9xh1dFMrWh_0024.AppendLine(blockReference.BlockName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302670722));
					drawingSheet.Entities[num] = new Ghost(blockReference.BlockName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302670410));
				}
			}
		}
	}

	internal void _0023_003DzIOhKPiQEryDf()
	{
		foreach (Block block in Blocks)
		{
			foreach (Hatch item4 in block.Entities.Where(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzpWBaMddKdD9pkRc_8jdq4j8_003D))
			{
				string patternName = item4.PatternName;
				if (!HatchPatterns.Contains(patternName))
				{
					HatchPattern item = new HatchPattern(patternName, new HatchPatternLine[1]
					{
						new HatchPatternLine(Math.PI / 4.0, Point2D.Origin, 0.0, 1.0, new float[0])
					});
					HatchPatterns.Add(item);
				}
			}
		}
		foreach (Block drawingBlock in DrawingBlocks)
		{
			foreach (Hatch item5 in drawingBlock.Entities.Where(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzzVCRpCVAnCZ8kDpIZQ3lCwY_003D))
			{
				string patternName2 = item5.PatternName;
				if (!DrawingHatchPatterns.Contains(patternName2))
				{
					HatchPattern item2 = new HatchPattern(patternName2, new HatchPatternLine[1]
					{
						new HatchPatternLine(Math.PI / 4.0, Point2D.Origin, 0.0, 1.0, new float[0])
					});
					DrawingHatchPatterns.Add(item2);
				}
			}
		}
		foreach (Sheet drawingSheet in DrawingSheets)
		{
			foreach (Hatch item6 in drawingSheet.Entities.Where((Entity _0023_003DzBJFJHwk_003D) => _0023_003DzBJFJHwk_003D is Hatch))
			{
				string patternName3 = item6.PatternName;
				if (!DrawingHatchPatterns.Contains(patternName3))
				{
					HatchPattern item3 = new HatchPattern(patternName3, new HatchPatternLine[1]
					{
						new HatchPatternLine(Math.PI / 4.0, Point2D.Origin, 0.0, 1.0, new float[0])
					});
					DrawingHatchPatterns.Add(item3);
				}
			}
		}
	}
}
