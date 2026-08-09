using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot;

public class DrawingDocument : Document
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzsvoDs1G4XfgTLK_0024dfZCsnPghPJ24Rxa_JQ_003D_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954208);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzYcE1w5v5smEdW2IHUG2TIaw_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954162);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzDFYueR9OglFU9Oxik4DzExchf08m = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954174);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dzwgycel0imRZlmgV_0024Ce8hfGGp4v9sL6xZYctdlOQ_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954154);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzYXx0HmTchQ8IiN27GYNlKg4_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954114);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzaCDuTVb0fC9bH21symgXBsUrrHWD = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954868);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzT6BnZZGwRTXWymXTaFmESSo_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954854);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzNI1Yiw_0024rUt4u_2RISkGg_6tWPPUFlZIsLg_003D_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954835);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz_k6BdBW8VAYLzpvfWGXLj9k_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954821);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzrXabdJrIHL4VNNFtN8FNPUFn1u56_twSBQ_003D_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954835);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SheetKeyedCollection _0023_003DzH8f2IiQW3wuu;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Sheet _0023_003DzMwYErLuG8m7e;

	public string SilhouettesLayerName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzsvoDs1G4XfgTLK_0024dfZCsnPghPJ24Rxa_JQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzsvoDs1G4XfgTLK_0024dfZCsnPghPJ24Rxa_JQ_003D_003D = value;
		}
	}

	public string EdgesLayerName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzYcE1w5v5smEdW2IHUG2TIaw_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzYcE1w5v5smEdW2IHUG2TIaw_003D = value;
		}
	}

	public string WiresLayerName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzDFYueR9OglFU9Oxik4DzExchf08m;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzDFYueR9OglFU9Oxik4DzExchf08m = value;
		}
	}

	public string HiddenSilhouettesLayerName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzwgycel0imRZlmgV_0024Ce8hfGGp4v9sL6xZYctdlOQ_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzwgycel0imRZlmgV_0024Ce8hfGGp4v9sL6xZYctdlOQ_003D = value;
		}
	}

	public string HiddenEdgesLayerName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzYXx0HmTchQ8IiN27GYNlKg4_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzYXx0HmTchQ8IiN27GYNlKg4_003D = value;
		}
	}

	public string HiddenWiresLayerName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzaCDuTVb0fC9bH21symgXBsUrrHWD;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzaCDuTVb0fC9bH21symgXBsUrrHWD = value;
		}
	}

	public string SectionsLayerName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzT6BnZZGwRTXWymXTaFmESSo_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzT6BnZZGwRTXWymXTaFmESSo_003D = value;
		}
	}

	public string CenterlinesLayerName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzNI1Yiw_0024rUt4u_2RISkGg_6tWPPUFlZIsLg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzNI1Yiw_0024rUt4u_2RISkGg_6tWPPUFlZIsLg_003D_003D = value;
		}
	}

	public string HiddenSegmentsLineTypeName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz_k6BdBW8VAYLzpvfWGXLj9k_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz_k6BdBW8VAYLzpvfWGXLj9k_003D = value;
		}
	}

	public string CenterlinesLineTypeName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzrXabdJrIHL4VNNFtN8FNPUFn1u56_twSBQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzrXabdJrIHL4VNNFtN8FNPUFn1u56_twSBQ_003D_003D = value;
		}
	}

	public SheetKeyedCollection Sheets
	{
		get
		{
			return _0023_003DzH8f2IiQW3wuu;
		}
		set
		{
			if (value.Document != null)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954417));
			}
			_0023_003DzH8f2IiQW3wuu?._0023_003DzOcZnt98_003D(null);
			_0023_003DzH8f2IiQW3wuu = value;
			_0023_003DzH8f2IiQW3wuu._0023_003DzOcZnt98_003D(this);
		}
	}

	public Sheet ActiveSheet
	{
		get
		{
			return _0023_003DzMwYErLuG8m7e;
		}
		set
		{
			if (value != null && (string.IsNullOrEmpty(value.Name) || !Sheets.Contains(value.Name)))
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954807) + value.Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954772));
			}
			if (_0023_003DzMwYErLuG8m7e != null)
			{
				if (value != null && _0023_003DzMwYErLuG8m7e.Name.Equals(value.Name, StringComparison.InvariantCultureIgnoreCase))
				{
					return;
				}
				if (workspace != null && !workspace.IsDesignMode())
				{
					workspace.SaveView(out var saved);
					_0023_003DzMwYErLuG8m7e.Camera = saved;
				}
				_0023_003DzMwYErLuG8m7e.Entities = new List<Entity>(base.Entities.baseList);
			}
			_0023_003DzMwYErLuG8m7e = value;
			base.Entities.Clear();
			UpdateBoundingBox();
			if (_0023_003DzMwYErLuG8m7e != null)
			{
				base.Entities.AddRange(_0023_003DzMwYErLuG8m7e.Entities);
				_0023_003DzMwYErLuG8m7e.Entities = base.Entities.baseList;
			}
			if (workspace?.RenderContext != null)
			{
				if (_0023_003DzMwYErLuG8m7e?.Camera == null)
				{
					workspace.UpdateBoundingBox();
					workspace.ZoomFit();
				}
				else
				{
					workspace.RestoreView(_0023_003DzMwYErLuG8m7e.Camera);
				}
			}
		}
	}

	public int ActiveSheetIndex
	{
		get
		{
			if (Sheets == null || ActiveSheet == null)
			{
				return -1;
			}
			return Sheets.IndexOf(ActiveSheet);
		}
		set
		{
			if (Sheets != null)
			{
				if (value >= Sheets.Count || value < 0)
				{
					throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954764));
				}
				ActiveSheet = Sheets[value];
			}
		}
	}

	public DrawingDocument()
	{
		AddDefaultLayersAndLineTypes();
		Sheets = new SheetKeyedCollection();
	}

	internal override void SetWorkspace(IWorkspaceInternal _0023_003DzImQx0os_003D)
	{
		if (_0023_003DzImQx0os_003D == null)
		{
			Sheets._0023_003DzhM3qURBkRYYd();
		}
		base.SetWorkspace(_0023_003DzImQx0os_003D);
	}

	internal List<string> _0023_003DzCNALh1hLtZgVoOuxrA_003D_003D()
	{
		return new List<string> { SilhouettesLayerName, EdgesLayerName, WiresLayerName, HiddenSilhouettesLayerName, HiddenEdgesLayerName, HiddenWiresLayerName, SectionsLayerName, CenterlinesLayerName };
	}

	public void AddDefaultLayersAndLineTypes()
	{
		if (!base.Layers.Contains(SilhouettesLayerName))
		{
			base.Layers.Add(new Layer(SilhouettesLayerName, Color.Black, null, 0.5f, visible: true));
		}
		if (!base.Layers.Contains(EdgesLayerName))
		{
			base.Layers.Add(new Layer(EdgesLayerName, Color.Black, null, 0.15f, visible: true));
		}
		if (!base.Layers.Contains(WiresLayerName))
		{
			base.Layers.Add(new Layer(WiresLayerName, Color.Black, null, 0.15f, visible: true));
		}
		AddDefaultLineTypes();
		if (!base.Layers.Contains(HiddenSilhouettesLayerName))
		{
			base.Layers.Add(new Layer(HiddenSilhouettesLayerName, Color.Black, HiddenSegmentsLineTypeName, 0.15f, visible: true));
		}
		if (!base.Layers.Contains(HiddenEdgesLayerName))
		{
			base.Layers.Add(new Layer(HiddenEdgesLayerName, Color.Black, HiddenSegmentsLineTypeName, 0.15f, visible: true));
		}
		if (!base.Layers.Contains(HiddenWiresLayerName))
		{
			base.Layers.Add(new Layer(HiddenWiresLayerName, Color.Black, HiddenSegmentsLineTypeName, 0.15f, visible: true));
		}
		if (!base.Layers.Contains(CenterlinesLayerName))
		{
			base.Layers.Add(new Layer(CenterlinesLayerName, Color.DarkCyan, CenterlinesLineTypeName, 0.15f, visible: true));
		}
		if (!base.Layers.Contains(SectionsLayerName))
		{
			base.Layers.Add(new Layer(SectionsLayerName, Color.Black, null, 0.15f, visible: true));
		}
		base.HatchPatterns.AddDefaultPattern();
	}

	internal List<string> _0023_003Dz9BINOkUrYme4uAPe4g_003D_003D()
	{
		return new List<string> { HiddenSegmentsLineTypeName, CenterlinesLineTypeName };
	}

	public void AddDefaultLineTypes()
	{
		if (!base.LineTypes.Contains(HiddenSegmentsLineTypeName))
		{
			base.LineTypes.Add(HiddenSegmentsLineTypeName, new float[2] { 1.5f, -0.6f });
		}
		if (!base.LineTypes.Contains(CenterlinesLineTypeName))
		{
			base.LineTypes.Add(CenterlinesLineTypeName, new float[4] { 2f, -0.4f, 0.2f, -0.4f });
		}
	}

	public override RegenParams GetVisualRefinement()
	{
		double num = 1.0;
		if (ActiveSheet != null)
		{
			num = Utility.GetLinearUnitsConversionFactor(ActiveSheet.Units, linearUnitsType.Millimeters);
		}
		RegenParams visualRefinement = base.GetVisualRefinement();
		return new RegenParams(visualRefinement.Deviation / 100.0 / num, visualRefinement.Angle);
	}

	public override void Clear()
	{
		base.Clear();
		Sheets.Clear();
		ActiveSheet = null;
	}

	private protected override void _0023_003Dz_JVSrE__e8Wu()
	{
		List<Entity> list = new List<Entity>(base.Entities);
		if (Sheets.Count > 0)
		{
			foreach (Sheet sheet in Sheets)
			{
				if (ActiveSheet != sheet)
				{
					list.AddRange(sheet.Entities);
				}
			}
		}
		Utility.Purge(list, base.Layers, base.Blocks, base.Materials, base.TextStyles, base.LineTypes, base.HatchPatterns, out var _0023_003DzfchAzPg_003D, out var _0023_003DzTKSsuc0_003D, out var _0023_003DzvEAegzCu5KMnKFso0g_003D_003D, out var _0023_003DzIm3oyxMBrWGo, out var _0023_003Dzl0O9h6oxpm0u, out var _0023_003Dz3b479cSvol0G, _0023_003DzkiaObrihH2G4: true, _0023_003DzVUweAlrIUUDr: true);
		base.Layers = _0023_003DzfchAzPg_003D;
		base.Blocks = _0023_003DzTKSsuc0_003D;
		base.TextStyles = _0023_003DzIm3oyxMBrWGo;
		base.LineTypes = _0023_003Dzl0O9h6oxpm0u;
		base.HatchPatterns = _0023_003Dz3b479cSvol0G;
		base.Materials = _0023_003DzvEAegzCu5KMnKFso0g_003D_003D;
		AddDefaultLayersAndLineTypes();
	}

	public void CopyTo(Document destination, bool replaceRootBlock = true, bool skipSheets = false, bool keepTessellation = false)
	{
		if (destination is DrawingDocument drawingDocument && !skipSheets)
		{
			foreach (Sheet sheet in Sheets)
			{
				if (!drawingDocument.Sheets.Contains(sheet))
				{
					Sheet item = (Sheet)(keepTessellation ? sheet.CloneWithTessellation() : sheet.Clone());
					drawingDocument.Sheets.Add(item);
				}
			}
		}
		base.CopyTo(destination, replaceRootBlock: false, keepTessellation);
		if (!(destination is DesignDocument designDocument) || !replaceRootBlock || !base.Blocks.hasRootBlock)
		{
			return;
		}
		Block block = new Block(base.Blocks.RootBlock.Name);
		block.CloneBlock(base.Blocks.RootBlock, _0023_003DzQmmjROxvNJdJ: false);
		foreach (Entity entity in base.Blocks.RootBlock.Entities)
		{
			if (entity is View view)
			{
				BlockReference item2 = new BlockReference(view.InsertionPoint, view.BlockName, 0.0)
				{
					Transformation = (Transformation)view.Transformation.Clone()
				};
				block.Entities.Add(item2);
			}
			else
			{
				Entity item3 = (Entity)(keepTessellation ? entity.CloneWithTessellation() : entity.Clone());
				block.Entities.Add(item3);
			}
		}
		designDocument.Blocks[designDocument.Blocks.IndexOf(designDocument.RootBlock)] = block;
		if (destination.workspace != null)
		{
			destination.workspace.UpdateBoundingBox();
		}
		else
		{
			destination.UpdateBoundingBox();
		}
	}

	public virtual void SaveFile(string filePath, DesignDocument designDoc, FileSerializer fileSerializer = null)
	{
		try
		{
			Document._0023_003DzRiqmF0HlYfrG(null, filePath, designDoc, this, contentType.GeometryAndTessellation, fileSerializer);
		}
		catch (Exception ex)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954355) + ex);
		}
	}

	public virtual void SaveFile(Stream stream, DesignDocument designDoc, FileSerializer fileSerializer = null)
	{
		try
		{
			Document._0023_003DzRiqmF0HlYfrG(stream, null, designDoc, this, contentType.GeometryAndTessellation, fileSerializer);
		}
		catch (Exception ex)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954355) + ex);
		}
	}

	public virtual void OpenFile(string filePath, DesignDocument design, FileSerializer fileSerializer = null)
	{
		Document._0023_003DzEnNVXbF4jXkn(new ReadMultiFile(filePath, fileSerializer), design, this);
	}

	public virtual void OpenFile(Stream stream, DesignDocument design, FileSerializer fileSerializer = null)
	{
		Document._0023_003DzEnNVXbF4jXkn(new ReadFile(stream, fileSerializer), design, this);
	}

	internal void _0023_003Dz3nSNv4s_003D(ReadFileAsyncWithDrawing _0023_003DzQZpgnjI_003D)
	{
		Clear();
		_0023_003Dz22bHhhvnMtkUdwafYg_003D_003D(_0023_003DzQZpgnjI_003D, conflictPolicy.Overwrite);
	}

	internal void _0023_003DzVpMLeQA_003D(ReadFileAsyncWithDrawing _0023_003DzQZpgnjI_003D, conflictPolicy _0023_003DzkDT_0024HYsJqA7X)
	{
		_0023_003Dz22bHhhvnMtkUdwafYg_003D_003D(_0023_003DzQZpgnjI_003D, _0023_003DzkDT_0024HYsJqA7X);
	}

	private void _0023_003Dz22bHhhvnMtkUdwafYg_003D_003D(ReadFileAsyncWithDrawing _0023_003DzQZpgnjI_003D, conflictPolicy _0023_003DzkDT_0024HYsJqA7X)
	{
		_0023_003DzOcgHUDvnU3Y6Js8nxw_003D_003D(_0023_003DzQZpgnjI_003D, _0023_003DzkDT_0024HYsJqA7X);
		if (_0023_003DzkDT_0024HYsJqA7X == conflictPolicy.Overwrite)
		{
			_0023_003DzQZpgnjI_003D.ImportSettings(this);
		}
	}

	internal void _0023_003DzOcgHUDvnU3Y6Js8nxw_003D_003D(ReadFileAsyncWithDrawing _0023_003DzQZpgnjI_003D, conflictPolicy _0023_003DzkDT_0024HYsJqA7X)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"ac>", array);
		bool isOffline = base.Blocks.isOffline;
		if (!isOffline)
		{
			base.Blocks.TakeOffline();
		}
		Document._0023_003DzBlcGo_o_003D(_0023_003DzQZpgnjI_003D.DrawingLineTypes, base.LineTypes, _0023_003DzkDT_0024HYsJqA7X, out var _0023_003Dz3NG5ssEa1dcm, null);
		Document._0023_003DzBlcGo_o_003D(_0023_003DzQZpgnjI_003D.DrawingHatchPatterns, base.HatchPatterns, _0023_003DzkDT_0024HYsJqA7X, out var _0023_003Dz3NG5ssEa1dcm2, null);
		Document._0023_003DzBlcGo_o_003D(_0023_003DzQZpgnjI_003D.DrawingTextStyles, base.TextStyles, _0023_003DzkDT_0024HYsJqA7X, out var _0023_003Dz3NG5ssEa1dcm3, null);
		Document._0023_003DzBlcGo_o_003D(_0023_003DzQZpgnjI_003D.DrawingLayers, base.Layers, _0023_003DzkDT_0024HYsJqA7X, out var _0023_003Dz3NG5ssEa1dcm4, null);
		Document._0023_003DzBlcGo_o_003D(_0023_003DzQZpgnjI_003D.DrawingBlocks, base.Blocks, _0023_003DzkDT_0024HYsJqA7X, out var _0023_003Dz3NG5ssEa1dcm5, _0023_003DzQZpgnjI_003D.Blocks.RootBlockName);
		Document._0023_003DzBlcGo_o_003D(_0023_003DzQZpgnjI_003D.DrawingSheets, Sheets, _0023_003DzkDT_0024HYsJqA7X, out var _, null);
		if (_0023_003DzkDT_0024HYsJqA7X == conflictPolicy.Rename)
		{
			foreach (Block block in _0023_003DzQZpgnjI_003D.Blocks)
			{
				foreach (Entity entity in block.Entities)
				{
					Document._0023_003DzmyAS8bZ2UOeQ(entity, new Dictionary<string, string>(), _0023_003Dz3NG5ssEa1dcm, _0023_003Dz3NG5ssEa1dcm2, _0023_003Dz3NG5ssEa1dcm4, _0023_003Dz3NG5ssEa1dcm3, _0023_003Dz3NG5ssEa1dcm5);
				}
			}
			foreach (Sheet drawingSheet in _0023_003DzQZpgnjI_003D.DrawingSheets)
			{
				foreach (Entity entity2 in drawingSheet.Entities)
				{
					Document._0023_003DzmyAS8bZ2UOeQ(entity2, new Dictionary<string, string>(), _0023_003Dz3NG5ssEa1dcm, _0023_003Dz3NG5ssEa1dcm2, _0023_003Dz3NG5ssEa1dcm4, _0023_003Dz3NG5ssEa1dcm3, _0023_003Dz3NG5ssEa1dcm5);
				}
			}
		}
		if (!isOffline)
		{
			base.Blocks._0023_003DzZZyHHbYfXKAk(_0023_003DzyGOerBkWPM27: false);
		}
	}
}
