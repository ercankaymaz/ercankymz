using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace devDept.Eyeshot.Translators;

public abstract class ReadFileAsyncWithDrawing : ReadFileAsync
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private LayerKeyedCollection _0023_003DziTDLtPhuGDW4gtvgqMzp_0024_s_003D = new LayerKeyedCollection();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BlockKeyedCollection _0023_003DzOn1sTM3P_00245F7GzXfR0Bp7ag_003D = new BlockKeyedCollection();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SheetKeyedCollection _0023_003Dzg8nlmv0eKohsdiB_xSf9Bbk_003D = new SheetKeyedCollection();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private LineTypeKeyedCollection _0023_003DzaLJz2KfS5zFOSDw92P1te_w_003D = new LineTypeKeyedCollection();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private HatchPatternKeyedCollection _0023_003DzPN6S75HNamFqkaKAlaLmsjE_003D = new HatchPatternKeyedCollection();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextStyleKeyedCollection _0023_003DzS_tNlfBCYbK9eI17OFSvzIk_003D = new TextStyleKeyedCollection();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003DzO36PKpaF4knnuUUxHLXY5y8_003D = 1f;

	public LayerKeyedCollection DrawingLayers
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DziTDLtPhuGDW4gtvgqMzp_0024_s_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003DziTDLtPhuGDW4gtvgqMzp_0024_s_003D = value;
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
		protected set
		{
			_0023_003DzOn1sTM3P_00245F7GzXfR0Bp7ag_003D = value;
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
		protected set
		{
			_0023_003Dzg8nlmv0eKohsdiB_xSf9Bbk_003D = value;
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
		protected set
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
		protected set
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
		protected set
		{
			_0023_003DzS_tNlfBCYbK9eI17OFSvzIk_003D = value;
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
		protected set
		{
			_0023_003DzO36PKpaF4knnuUUxHLXY5y8_003D = value;
		}
	}

	protected ReadFileAsyncWithDrawing(Stream stream)
		: base(stream)
	{
	}

	protected ReadFileAsyncWithDrawing(string filePath)
		: base(filePath)
	{
	}

	public override void ImportSettings(Document document)
	{
		document.LineTypeScale = LineTypeScale;
		base.ImportSettings(document);
	}

	public void OpenTo(IDrawing drawing)
	{
		drawing.Document._0023_003Dz3nSNv4s_003D(this);
	}

	public void OpenTo(DrawingDocument drawingDoc)
	{
		drawingDoc._0023_003Dz3nSNv4s_003D(this);
	}

	public void AppendTo(IDrawing drawing, conflictPolicy conflictPolicy = conflictPolicy.Rename)
	{
		drawing.Document._0023_003DzVpMLeQA_003D(this, conflictPolicy);
	}

	public void AppendTo(DrawingDocument drawingDoc, conflictPolicy conflictPolicy = conflictPolicy.Rename)
	{
		drawingDoc._0023_003DzVpMLeQA_003D(this, conflictPolicy);
	}

	public void FillAllDrawingCollectionsData(IDrawing drawing, conflictPolicy conflictPolicy = conflictPolicy.Rename)
	{
		FillAllDrawingCollectionsData(drawing.Document, conflictPolicy.KeepExisting);
	}

	public void FillAllDrawingCollectionsData(DrawingDocument drawingDoc, conflictPolicy conflictPolicy = conflictPolicy.Rename)
	{
		drawingDoc._0023_003DzOcgHUDvnU3Y6Js8nxw_003D_003D(this, conflictPolicy.KeepExisting);
	}

	public void FillDrawingCollection<T>(EyeshotKeyedCollection<T> dest, conflictPolicy conflictPolicy = conflictPolicy.Rename) where T : IKeyedCollectionItem<T>
	{
		FillCollection(dest, conflictPolicy, out var _);
	}

	public void FillDrawingCollection<T>(EyeshotKeyedCollection<T> dest, conflictPolicy conflictPolicy, out Dictionary<string, string> oldNewMapping) where T : IKeyedCollectionItem<T>
	{
		Type typeFromHandle = typeof(T);
		EyeshotKeyedCollection<T> _0023_003DzqjMrmuo_003D;
		if (typeFromHandle == typeof(Block))
		{
			_0023_003DzqjMrmuo_003D = (EyeshotKeyedCollection<T>)(object)DrawingBlocks;
		}
		else if (typeFromHandle == typeof(Layer))
		{
			_0023_003DzqjMrmuo_003D = (EyeshotKeyedCollection<T>)(object)DrawingLayers;
		}
		else if (typeFromHandle == typeof(TextStyle))
		{
			_0023_003DzqjMrmuo_003D = (EyeshotKeyedCollection<T>)(object)DrawingTextStyles;
		}
		else if (typeFromHandle == typeof(HatchPattern))
		{
			_0023_003DzqjMrmuo_003D = (EyeshotKeyedCollection<T>)(object)DrawingHatchPatterns;
		}
		else if (typeFromHandle == typeof(LineType))
		{
			_0023_003DzqjMrmuo_003D = (EyeshotKeyedCollection<T>)(object)DrawingLineTypes;
		}
		else
		{
			if (!(typeFromHandle == typeof(Material)))
			{
				throw new InvalidOperationException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004267) + typeFromHandle.Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290));
			}
			_0023_003DzqjMrmuo_003D = (EyeshotKeyedCollection<T>)(object)DrawingSheets;
		}
		Document._0023_003DzBlcGo_o_003D(_0023_003DzqjMrmuo_003D, dest, conflictPolicy, out oldNewMapping, null);
	}
}
