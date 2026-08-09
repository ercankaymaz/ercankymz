using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using ODA.Drawings.TD_DbCoreIntegrated;
using ODA.Kernel.TD_RootIntegrated;
using devDept.Diagnostic;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class WriteAutodesk : WriteDatabase
{
	private sealed class _0023_003DzLt17AE16qNB4oT7gNOy1ewQ_003D
	{
		public VectorView _0023_003DzJBGhmy8_003D;

		public _0023_003DzYmQcuf2fAnGk_V23PVb7Q_c_003D _0023_003DqR9lXJ4VlQb2pedCurok972eKGMHhTmxiou6EfYlbocw_003D;

		internal bool _0023_003DzabQVKat4ijiSgYxNxw_003D_003D(Entity _0023_003DzaG3DPu0_003D)
		{
			if (!_0023_003DqR9lXJ4VlQb2pedCurok972eKGMHhTmxiou6EfYlbocw_003D._0023_003DzMH1e7IJCRnTm.Contains(_0023_003DzaG3DPu0_003D.LayerName))
			{
				if (_0023_003DzJBGhmy8_003D.Shaded)
				{
					return !(_0023_003DzaG3DPu0_003D is Picture);
				}
				return true;
			}
			return false;
		}
	}

	private sealed class _0023_003DzYmQcuf2fAnGk_V23PVb7Q_c_003D
	{
		public string[] _0023_003DzMH1e7IJCRnTm;
	}

	public enum formatType
	{
		DWG,
		DXF
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static autodeskVersionType _0023_003Dz3jripO4_003D = Enum.GetValues(typeof(autodeskVersionType)).Cast<autodeskVersionType>().Last();

	protected autodeskVersionType version = _0023_003Dz3jripO4_003D;

	protected formatType format;

	protected string password = string.Empty;

	public WriteAutodesk(Document document, Stream stream, bool aciColors = true, bool asciiStream = false, bool selectedOnly = false, lineWeightUnitsType lineWeightUnits = lineWeightUnitsType.Millimeters, bool purge = false)
		: this(document, stream, _0023_003Dz3jripO4_003D, 0.0, aciColors, asciiStream, selectedOnly, lineWeightUnits, purge)
	{
	}

	public WriteAutodesk(Document document, Stream stream, autodeskVersionType version, bool aciColors = true, bool asciiStream = false, bool selectedOnly = false, lineWeightUnitsType lineWeightUnits = lineWeightUnitsType.Millimeters, bool purge = false)
		: this(document, stream, version, 0.0, aciColors, asciiStream, selectedOnly, lineWeightUnits, purge)
	{
	}

	public WriteAutodesk(Document document, Stream stream, autodeskVersionType version, double deviation, bool aciColors = true, bool asciiStream = false, bool selectedOnly = false, lineWeightUnitsType lineWeightUnits = lineWeightUnitsType.Millimeters, bool purge = false)
		: this((document is DesignDocument) ? new WriteAutodeskParams((DesignDocument)document, null, selectedOnly, explodeViews: false, deviation)
		{
			AciColors = aciColors,
			Version = version,
			LineWeightUnits = lineWeightUnits,
			Purge = purge,
			Format = (asciiStream ? formatType.DXF : formatType.DWG)
		} : new WriteAutodeskParams((DrawingDocument)document, selectedOnly, deviation)
		{
			AciColors = aciColors,
			Version = version,
			LineWeightUnits = lineWeightUnits,
			Purge = purge,
			Format = (asciiStream ? formatType.DXF : formatType.DWG)
		}, stream)
	{
	}

	public WriteAutodesk(DesignDocument design, string filePath, bool aciColors = true, bool selectedOnly = false, lineWeightUnitsType lineWeightUnits = lineWeightUnitsType.Millimeters, bool purge = false)
		: this(design, filePath, _0023_003Dz3jripO4_003D, null, 0.0, aciColors, selectedOnly, lineWeightUnits, purge)
	{
	}

	public WriteAutodesk(DesignDocument design, string filePath, autodeskVersionType version, bool aciColors = true, bool selectedOnly = false, lineWeightUnitsType lineWeightUnits = lineWeightUnitsType.Millimeters, bool purge = false)
		: this(design, filePath, version, null, 0.0, aciColors, selectedOnly, lineWeightUnits, purge)
	{
	}

	public WriteAutodesk(DesignDocument design, string filePath, autodeskVersionType version, string password, double deviation, bool aciColors = true, bool selectedOnly = false, lineWeightUnitsType lineWeightUnits = lineWeightUnitsType.Millimeters, bool purge = false)
		: this(new WriteAutodeskParams(design, null, selectedOnly, explodeViews: false, deviation)
		{
			Version = version,
			Password = password,
			AciColors = aciColors,
			LineWeightUnits = lineWeightUnits,
			Purge = purge
		}, filePath)
	{
	}

	public WriteAutodesk(IDesign design, string filePath, IDrawing drawing = null)
		: this(new WriteAutodeskParams(design.Document, drawing?.Document), filePath)
	{
	}

	public WriteAutodesk(IDesign design, Stream stream, IDrawing drawing = null)
		: this(new WriteAutodeskParams(design.Document, drawing?.Document), stream)
	{
	}

	internal WriteAutodesk(string _0023_003Dzi_0024GqBs8_003D, autodeskVersionType _0023_003Dz2lUs5iI_003D, string _0023_003Dzr8rfJIs_003D, double _0023_003DzQGIgnLa9AaT7Qt_G1w_003D_003D, bool _0023_003Dz_sf9dBZZ1poK = true, bool _0023_003Dz8PMCTH_0024Bkfwq = false, lineWeightUnitsType _0023_003DztO5OPB0oehHq = lineWeightUnitsType.Millimeters, bool _0023_003DzUCZ_2BiMVRwN = false)
		: base(_0023_003Dzi_0024GqBs8_003D, _0023_003Dz8PMCTH_0024Bkfwq)
	{
		lineWeightUnits = _0023_003DztO5OPB0oehHq;
		password = _0023_003Dzr8rfJIs_003D;
		attributeReferenceVisibilityType _0023_003DzptDEYWRLdwXY = attributeReferenceVisibilityType.Normal;
		base.Deviation = _0023_003DzQGIgnLa9AaT7Qt_G1w_003D_003D;
		_0023_003Dz4J_0024DYXY_003D(_0023_003Dz2lUs5iI_003D, null, null, _0023_003DzptDEYWRLdwXY, _0023_003Dz_sf9dBZZ1poK, _0023_003DzUCZ_2BiMVRwN, string.Empty, lineWeightUnitsType.Millimeters, null, null, null);
	}

	public WriteAutodesk(WriteAutodeskParams writeParams, Stream stream)
		: base(writeParams, stream)
	{
		format = writeParams.Format;
		_0023_003Dz6mPZHDwiRWauMjIqtbOdNf0_003D(writeParams);
	}

	public WriteAutodesk(WriteAutodeskParams writeParams, string filePath)
		: base(writeParams, filePath)
	{
		_0023_003Dz6mPZHDwiRWauMjIqtbOdNf0_003D(writeParams);
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public WriteAutodesk(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, IDictionary<string, TextStyle> textStyleDict, IDictionary<string, LineType> lineTypes, Stream stream, linearUnitsType insUnits, bool aciColors = true, bool asciiStream = false, bool selectedOnly = false, lineWeightUnitsType lineWeightUnits = lineWeightUnitsType.Millimeters, bool purge = false)
		: this(entList, layerList, blockDict, textStyleDict, lineTypes, null, stream, insUnits, _0023_003Dz3jripO4_003D, 0.0, aciColors, asciiStream, selectedOnly, lineWeightUnits, purge)
	{
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public WriteAutodesk(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, IDictionary<string, TextStyle> textStyleDict, IDictionary<string, LineType> lineTypes, Stream stream, linearUnitsType insUnits, autodeskVersionType version, bool aciColors = true, bool asciiStream = false, bool selectedOnly = false, lineWeightUnitsType lineWeightUnits = lineWeightUnitsType.Millimeters, bool purge = false)
		: this(entList, layerList, blockDict, textStyleDict, lineTypes, null, stream, insUnits, version, 0.0, aciColors, asciiStream, selectedOnly, lineWeightUnits, purge)
	{
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public WriteAutodesk(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, IDictionary<string, TextStyle> textStyleDict, Stream stream, linearUnitsType insUnits, autodeskVersionType version, double deviation = 0.0, bool aciColors = true, bool asciiStream = false, bool selectedOnly = false, lineWeightUnitsType lineWeightUnits = lineWeightUnitsType.Millimeters, bool purge = false)
		: this(entList, layerList, blockDict, textStyleDict, null, null, stream, insUnits, version, deviation, aciColors, asciiStream, selectedOnly, lineWeightUnits, purge)
	{
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public WriteAutodesk(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, IDictionary<string, TextStyle> textStyleDict, IDictionary<string, LineType> lineTypes, MaterialKeyedCollection materials, Stream stream, linearUnitsType insUnits, autodeskVersionType version, double deviation = 0.0, bool aciColors = true, bool asciiStream = false, bool selectedOnly = false, lineWeightUnitsType lineWeightUnits = lineWeightUnitsType.Millimeters, bool purge = false)
		: base(entList, layerList, blockDict, stream, insUnits)
	{
		base.lineWeightUnits = lineWeightUnits;
		this.version = version;
		format = (asciiStream ? formatType.DXF : formatType.DWG);
		base.Deviation = deviation;
		_0023_003Dz4J_0024DYXY_003D(version, aciColors, selectedOnly, textStyleDict, lineTypes, attributeReferenceVisibilityType.Normal, purge, materials, null);
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public WriteAutodesk(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, IDictionary<string, TextStyle> textStyleDict, IDictionary<string, LineType> lineTypes, string filePath, linearUnitsType insUnits, bool aciColors = true, bool selectedOnly = false, lineWeightUnitsType lineWeightUnits = lineWeightUnitsType.Millimeters, bool purge = false)
		: this(entList, layerList, blockDict, textStyleDict, lineTypes, null, filePath, insUnits, _0023_003Dz3jripO4_003D, null, 0.0, aciColors, selectedOnly, lineWeightUnits, purge)
	{
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public WriteAutodesk(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, IDictionary<string, TextStyle> textStyleDict, IDictionary<string, LineType> lineTypes, string filePath, linearUnitsType insUnits, autodeskVersionType version, bool aciColors = true, bool selectedOnly = false, lineWeightUnitsType lineWeightUnits = lineWeightUnitsType.Millimeters, bool purge = false)
		: this(entList, layerList, blockDict, textStyleDict, lineTypes, null, filePath, insUnits, version, null, 0.0, aciColors, selectedOnly, lineWeightUnits, purge)
	{
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public WriteAutodesk(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, IDictionary<string, TextStyle> textStyleDict, string filePath, linearUnitsType insUnits, autodeskVersionType version, string password, double tol, bool aciColors = true, bool selectedOnly = false, lineWeightUnitsType lineWeightUnits = lineWeightUnitsType.Millimeters, bool purge = false)
		: this(entList, layerList, blockDict, textStyleDict, null, null, filePath, insUnits, version, password, tol, aciColors, selectedOnly, lineWeightUnits, purge)
	{
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public WriteAutodesk(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, IDictionary<string, TextStyle> textStyleDict, IDictionary<string, LineType> lineTypes, MaterialKeyedCollection materials, string filePath, linearUnitsType insUnits, autodeskVersionType version, string password, double deviation, bool aciColors = true, bool selectedOnly = false, lineWeightUnitsType lineWeightUnits = lineWeightUnitsType.Millimeters, bool purge = false)
		: base(entList, layerList, blockDict, filePath, insUnits)
	{
		base.lineWeightUnits = lineWeightUnits;
		this.password = password;
		base.Deviation = deviation;
		_0023_003Dz4J_0024DYXY_003D(version, aciColors, selectedOnly, textStyleDict, lineTypes, attributeReferenceVisibilityType.Normal, purge, materials, null);
	}

	private void _0023_003Dz4J_0024DYXY_003D(autodeskVersionType _0023_003Dz2lUs5iI_003D, bool _0023_003Dz_sf9dBZZ1poK, bool _0023_003Dz8PMCTH_0024Bkfwq, IDictionary<string, TextStyle> _0023_003DzePmaDhLbnNzT, IDictionary<string, LineType> _0023_003DziPRKwWQe7kgG, attributeReferenceVisibilityType _0023_003DzptDEYWRLdwXY, bool _0023_003DzUCZ_2BiMVRwN, MaterialKeyedCollection _0023_003DzmQzBmUxRsGtswIuVtQ_003D_003D, string _0023_003Dze_FK0WaY6acJ)
	{
		version = _0023_003Dz2lUs5iI_003D;
		aciColors = _0023_003Dz_sf9dBZZ1poK;
		selectedOnly = _0023_003Dz8PMCTH_0024Bkfwq;
		if (_0023_003DzePmaDhLbnNzT != null)
		{
			textStyles = new TextStyleKeyedCollection();
			foreach (KeyValuePair<string, TextStyle> item in _0023_003DzePmaDhLbnNzT)
			{
				textStyles.Add(item.Value);
			}
		}
		if (_0023_003DzmQzBmUxRsGtswIuVtQ_003D_003D != null)
		{
			materials = new MaterialKeyedCollection(_0023_003DzmQzBmUxRsGtswIuVtQ_003D_003D);
		}
		if (_0023_003DziPRKwWQe7kgG != null)
		{
			lineTypes = new LineTypeKeyedCollection();
			foreach (KeyValuePair<string, LineType> item2 in _0023_003DziPRKwWQe7kgG)
			{
				lineTypes.Add((LineType)item2.Value.Clone());
			}
		}
		attributeReferenceVisibilityMode = _0023_003DzptDEYWRLdwXY;
		purge = _0023_003DzUCZ_2BiMVRwN;
		textureImagesPath = _0023_003Dze_FK0WaY6acJ;
	}

	private void _0023_003Dz4J_0024DYXY_003D(autodeskVersionType _0023_003Dz2lUs5iI_003D, TextStyleKeyedCollection _0023_003DzePmaDhLbnNzT, LineTypeKeyedCollection _0023_003Dz6ie82Wbc_6YE, attributeReferenceVisibilityType _0023_003DzptDEYWRLdwXY, bool _0023_003Dz_sf9dBZZ1poK, bool _0023_003DzUCZ_2BiMVRwN, string _0023_003Dzr8rfJIs_003D, lineWeightUnitsType _0023_003DztO5OPB0oehHq, IViewport _0023_003Dzl6kX9CI_003D, MaterialKeyedCollection _0023_003DzmQzBmUxRsGtswIuVtQ_003D_003D, string _0023_003Dze_FK0WaY6acJ)
	{
		version = _0023_003Dz2lUs5iI_003D;
		password = _0023_003Dzr8rfJIs_003D;
		aciColors = _0023_003Dz_sf9dBZZ1poK;
		lineWeightUnits = _0023_003DztO5OPB0oehHq;
		viewport = _0023_003Dzl6kX9CI_003D;
		if (_0023_003DzePmaDhLbnNzT != null)
		{
			textStyles = new TextStyleKeyedCollection(_0023_003DzePmaDhLbnNzT);
		}
		if (_0023_003DzmQzBmUxRsGtswIuVtQ_003D_003D != null)
		{
			materials = new MaterialKeyedCollection(_0023_003DzmQzBmUxRsGtswIuVtQ_003D_003D);
		}
		lineTypes = _0023_003Dz6ie82Wbc_6YE;
		attributeReferenceVisibilityMode = _0023_003DzptDEYWRLdwXY;
		purge = _0023_003DzUCZ_2BiMVRwN;
		textureImagesPath = _0023_003Dze_FK0WaY6acJ;
	}

	private void _0023_003Dz6mPZHDwiRWauMjIqtbOdNf0_003D(WriteAutodeskParams _0023_003DzR_g2zoU_003D)
	{
		base.Deviation = _0023_003DzR_g2zoU_003D.Deviation;
		version = _0023_003DzR_g2zoU_003D.Version;
		password = _0023_003DzR_g2zoU_003D.Password;
		curvesAsFitSpline = _0023_003DzR_g2zoU_003D.CurveAsFitSpline;
		aciColors = _0023_003DzR_g2zoU_003D.AciColors;
		foregroundColor = _0023_003DzR_g2zoU_003D.ForegroundColor;
		textureImagesPath = _0023_003DzR_g2zoU_003D.TextureImagesPath;
		modelXData = _0023_003DzR_g2zoU_003D.ModelXData;
		_0023_003DzognsFWIgVngN(_0023_003DzR_g2zoU_003D);
	}

	private void _0023_003DzognsFWIgVngN(WriteAutodeskParams _0023_003DzR_g2zoU_003D)
	{
		_explodeViews = _0023_003DzR_g2zoU_003D.ExplodeViews;
		if (_0023_003DzR_g2zoU_003D.Drawing == null)
		{
			return;
		}
		foreach (LineType lineType in _0023_003DzR_g2zoU_003D.Drawing.LineTypes)
		{
			if (!lineTypes.Contains(lineType.Name))
			{
				lineTypes.Add(lineType);
			}
		}
		foreach (HatchPattern hatchPattern in _0023_003DzR_g2zoU_003D.Drawing.HatchPatterns)
		{
			if (!hatchPatterns.Contains(hatchPattern.Name))
			{
				hatchPatterns.Add(hatchPattern);
			}
		}
		foreach (TextStyle textStyle in _0023_003DzR_g2zoU_003D.Drawing.TextStyles)
		{
			if (!textStyles.Contains(textStyle.Name))
			{
				textStyles.Add(textStyle);
			}
		}
		foreach (Layer layer in _0023_003DzR_g2zoU_003D.Drawing.Layers)
		{
			if (!layers.Contains(layer.Name))
			{
				layers.Add(layer);
			}
		}
		foreach (Block block in _0023_003DzR_g2zoU_003D.Drawing.Blocks)
		{
			if (!block.Name.Equals(_0023_003DzR_g2zoU_003D.Blocks.RootBlockName) && !blocks.Contains(block.Name))
			{
				blocks.Add(block.GetShallowCopy());
			}
		}
		sheets = new SheetKeyedCollection(_0023_003DzR_g2zoU_003D.Drawing.Sheets);
		sheetsExtraEntities = new Dictionary<string, IList<Entity>>();
		if (_explodeViews)
		{
			return;
		}
		_0023_003DzYmQcuf2fAnGk_V23PVb7Q_c_003D _0023_003DzYmQcuf2fAnGk_V23PVb7Q_c_003D2 = new _0023_003DzYmQcuf2fAnGk_V23PVb7Q_c_003D();
		_0023_003DzYmQcuf2fAnGk_V23PVb7Q_c_003D2._0023_003DzMH1e7IJCRnTm = new string[7];
		_0023_003DzYmQcuf2fAnGk_V23PVb7Q_c_003D2._0023_003DzMH1e7IJCRnTm[0] = _0023_003DzR_g2zoU_003D.Drawing.SilhouettesLayerName;
		_0023_003DzYmQcuf2fAnGk_V23PVb7Q_c_003D2._0023_003DzMH1e7IJCRnTm[1] = _0023_003DzR_g2zoU_003D.Drawing.EdgesLayerName;
		_0023_003DzYmQcuf2fAnGk_V23PVb7Q_c_003D2._0023_003DzMH1e7IJCRnTm[2] = _0023_003DzR_g2zoU_003D.Drawing.WiresLayerName;
		_0023_003DzYmQcuf2fAnGk_V23PVb7Q_c_003D2._0023_003DzMH1e7IJCRnTm[3] = _0023_003DzR_g2zoU_003D.Drawing.HiddenSilhouettesLayerName;
		_0023_003DzYmQcuf2fAnGk_V23PVb7Q_c_003D2._0023_003DzMH1e7IJCRnTm[4] = _0023_003DzR_g2zoU_003D.Drawing.HiddenEdgesLayerName;
		_0023_003DzYmQcuf2fAnGk_V23PVb7Q_c_003D2._0023_003DzMH1e7IJCRnTm[5] = _0023_003DzR_g2zoU_003D.Drawing.HiddenWiresLayerName;
		_0023_003DzYmQcuf2fAnGk_V23PVb7Q_c_003D2._0023_003DzMH1e7IJCRnTm[6] = _0023_003DzR_g2zoU_003D.Drawing.SectionsLayerName;
		foreach (Sheet sheet in sheets)
		{
			List<Entity> list = new List<Entity>();
			foreach (Entity entity in sheet.Entities)
			{
				if (!(entity is View view))
				{
					continue;
				}
				_0023_003DzLt17AE16qNB4oT7gNOy1ewQ_003D _0023_003DzLt17AE16qNB4oT7gNOy1ewQ_003D2 = new _0023_003DzLt17AE16qNB4oT7gNOy1ewQ_003D();
				_0023_003DzLt17AE16qNB4oT7gNOy1ewQ_003D2._0023_003DqR9lXJ4VlQb2pedCurok972eKGMHhTmxiou6EfYlbocw_003D = _0023_003DzYmQcuf2fAnGk_V23PVb7Q_c_003D2;
				_0023_003DzLt17AE16qNB4oT7gNOy1ewQ_003D2._0023_003DzJBGhmy8_003D = view as VectorView;
				if (_0023_003DzLt17AE16qNB4oT7gNOy1ewQ_003D2._0023_003DzJBGhmy8_003D != null && blocks.Contains(view.BlockName))
				{
					IList<Entity> source = view.Explode(blocks);
					source = source.Where(_0023_003DzLt17AE16qNB4oT7gNOy1ewQ_003D2._0023_003DzabQVKat4ijiSgYxNxw_003D_003D).ToList();
					foreach (Entity item in source)
					{
						item.Regen(new RegenParams(_0023_003DzR_g2zoU_003D.Deviation, _0023_003DzR_g2zoU_003D.Drawing));
					}
					list.AddRange(source);
				}
				blocks.Remove(view.BlockName);
			}
			sheetsExtraEntities.Add(sheet.Name, list);
		}
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003Dz59lijRsT8LI_0024XHJOQ_0024AIGNJAuo4Gno8YZbyXhC6NbIN90_6Sbg_003D_003D._0023_003DzdzZLZbiwVTg1a0D6OXj_pZ7Vxsm1I1oH6u_0024_fyl4AGtqqQqxXQ_003D_003D()._0023_003DzcuxJrsHQF_Rj5c_67u2AJCIjdCLa(_0023_003Dz59lijRsT8LI_0024XHJOQ_0024AIGNJAuo4Gno8YZbyXhC6NbIN90_6Sbg_003D_003D._0023_003Dz9h7prLD836B0_0024F42nFw7qcyRyorkXYYKZ0vX9bIws0q0ILDt6g_003D_003D(), "p&4miq\"adM", array);
		if (!WriteDatabase.SupportedLinearUnitsType.HasFlag(Utility.GetSupportedLinearUnits(units)))
		{
			throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518314) + units);
		}
		_0023_003DzLnLXrn_6XxxZp534uQ_003D_003D(null, null, GetEntities(), layers, blocks, textStyles, lineTypes, materials, units, attributeReferenceVisibilityMode, progress, ct);
	}

	protected override void WriteFile(OdDbDatabase pDb)
	{
		if (version == autodeskVersionType.Release12)
		{
			OdResBuf odResBuf = OdResBuf.newRb(5001);
			odResBuf.setDouble(base.Deviation);
			pDb.setSysVar(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518278), odResBuf);
		}
		if (base.Stream != null)
		{
			OdMemoryStream odMemoryStream = OdMemoryStream.createNew();
			if (format == formatType.DXF)
			{
				pDb.writeFile(odMemoryStream, OdDb_SaveType.kDxf, _0023_003DzzeXa96gAc7VcPZ2UkHEbJi0_003D(version), saveThumbnailImage: false, 16);
			}
			else
			{
				pDb.writeFile(odMemoryStream, OdDb_SaveType.kDwg, _0023_003DzzeXa96gAc7VcPZ2UkHEbJi0_003D(version), saveThumbnailImage: false, 16);
			}
			int num = (int)odMemoryStream.length();
			OdUInt8Array odUInt8Array = new OdUInt8Array(num);
			odMemoryStream.getBytesByNum(odUInt8Array, 0uL, (uint)num);
			base.Stream.Write(odUInt8Array.ToArray(), 0, num);
			return;
		}
		OdSecurityParams odSecurityParams = new OdSecurityParams();
		pDb.securityParams(odSecurityParams);
		odSecurityParams.password = password;
		string extension = Path.GetExtension(base.FilePath);
		if (!string.Equals(extension, _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527427), StringComparison.InvariantCultureIgnoreCase) && !string.Equals(extension, _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527446), StringComparison.InvariantCultureIgnoreCase))
		{
			throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527533));
		}
		try
		{
			if (string.Equals(extension, _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527427), StringComparison.InvariantCultureIgnoreCase))
			{
				pDb.writeFile(base.FilePath, OdDb_SaveType.kDwg, _0023_003DzzeXa96gAc7VcPZ2UkHEbJi0_003D(version), saveThumbnailImage: false, 16);
			}
			else
			{
				pDb.writeFile(base.FilePath, OdDb_SaveType.kDxf, _0023_003DzzeXa96gAc7VcPZ2UkHEbJi0_003D(version), saveThumbnailImage: false, 16);
			}
		}
		catch (OdError odError)
		{
			throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517646) + base.FilePath + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517656) + odError.code().ToString() + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518289) + odError.description());
		}
	}

	internal void _0023_003DzLnLXrn_6XxxZp534uQ_003D_003D(Dictionary<string, string> _0023_003DzdNYeaZAGbegf, string _0023_003Dz0EA0NeSD2dKB, IList<Entity> _0023_003DzmK54snhR6Xwp, LayerKeyedCollection _0023_003Dz68IvW_AooqDP, BlockKeyedCollection _0023_003DzFyBLmv3KS6Nt, TextStyleKeyedCollection _0023_003Dzc3aLSLYhP84G, LineTypeKeyedCollection _0023_003Dziw5fCBSsasyX, MaterialKeyedCollection _0023_003DzN0ZWdMqGnIFK8BemCQ_003D_003D, linearUnitsType _0023_003DzXGJYGx3YyV6n, attributeReferenceVisibilityType _0023_003DziDnIAtVXXunH, IProgress<ProgressChangedEventArgs> _0023_003DzIzeJ4Qs_003D, CancellationToken _0023_003Dz_0024cU8x9g_003D)
	{
		MemoryTransaction memoryTransaction = MemoryManager.GetMemoryManager().StartTransaction();
		try
		{
			units = _0023_003DzXGJYGx3YyV6n;
			PrepareForWriting(_0023_003Dz0EA0NeSD2dKB, _0023_003DzdNYeaZAGbegf, _0023_003DzmK54snhR6Xwp, _0023_003Dz68IvW_AooqDP, _0023_003DzFyBLmv3KS6Nt, _0023_003Dzc3aLSLYhP84G, _0023_003Dziw5fCBSsasyX, _0023_003DzN0ZWdMqGnIFK8BemCQ_003D_003D, out var layersToSave, out var textStylesToSave, out var lineTypesToSave, out var materialsToSave, out var _, out var currXRefPaths, out var blocksToSave);
			SynchronizeAttributeReference(blocksToSave, _0023_003DzmK54snhR6Xwp);
			if (sheets != null)
			{
				foreach (Sheet sheet in sheets)
				{
					SynchronizeAttributeReference(blocksToSave, sheet.Entities);
				}
			}
			if (layersToSave.Count == 0)
			{
				throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518377));
			}
			ExHostAppServices exHostAppServices = new ExHostAppServices();
			memoryTransaction.AddObject(exHostAppServices);
			exHostAppServices.disableOutput(disable: true);
			OdDbDatabase pDb = exHostAppServices.createDatabase(createDefault: true);
			WriteDatabaseInternal(_0023_003Dz0EA0NeSD2dKB, _0023_003DzmK54snhR6Xwp, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D, pDb, layersToSave, blocksToSave, currXRefPaths, textStylesToSave, lineTypesToSave, materialsToSave, _0023_003DziDnIAtVXXunH, lineTypeScale, append: false, textureImagesPath);
		}
		catch (Exception ex)
		{
			log.AppendLine(ex.Message);
			throw new EyeshotException(ex.Message, ex);
		}
		finally
		{
			MemoryManager.GetMemoryManager().StopTransaction(memoryTransaction);
		}
	}

	protected void PrepareForWriting(string xRefName, Dictionary<string, string> savedXRefPaths, IList<Entity> myEntities, LayerKeyedCollection myLayers, BlockKeyedCollection myBlocks, TextStyleKeyedCollection myTextStyles, LineTypeKeyedCollection myLineTypes, MaterialKeyedCollection myMaterials, out LayerKeyedCollection layersToSave, out TextStyleKeyedCollection textStylesToSave, out LineTypeKeyedCollection lineTypesToSave, out MaterialKeyedCollection materialsToSave, out Dictionary<string, string> mapLayersOldNew, out Dictionary<string, string> currXRefPaths, out BlockKeyedCollection blocksToSave)
	{
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzSothfIG2mlbP();
		blocksToSave = myBlocks;
		layersToSave = myLayers;
		textStylesToSave = myTextStyles;
		lineTypesToSave = myLineTypes;
		materialsToSave = myMaterials;
		mapLayersOldNew = null;
		if (savedXRefPaths == null)
		{
			savedXRefPaths = new Dictionary<string, string>();
		}
		currXRefPaths = _0023_003Dzz_0024F_Y9kGxUZL(savedXRefPaths, base.FilePath, version, password, base.Deviation, myLayers, myBlocks, myTextStyles, myLineTypes, materialsToSave, aciColors);
		if (string.IsNullOrEmpty(xRefName))
		{
			blocksToSave = WriteDatabase._0023_003DzobR8DJrUi6Yu(null, string.Empty, myBlocks, myEntities, _0023_003DzEoO49dsZOP0E: false);
			foreach (KeyValuePair<string, string> currXRefPath in currXRefPaths)
			{
				if (!blocksToSave.Contains(currXRefPath.Key))
				{
					blocksToSave.Add(myBlocks[currXRefPath.Key]);
				}
			}
			layersToSave = WriteDatabase._0023_003DzBBXKkG65XrJN(string.Empty, string.Empty, myLayers, myBlocks, myEntities, out mapLayersOldNew);
			textStylesToSave = WriteDatabase._0023_003Dz3WHYiTYwY2ClnmiJ6A_003D_003D<TextStyleKeyedCollection, TextStyle>(string.Empty, string.Empty, myTextStyles);
			lineTypesToSave = WriteDatabase._0023_003Dz3WHYiTYwY2ClnmiJ6A_003D_003D<LineTypeKeyedCollection, LineType>(string.Empty, string.Empty, myLineTypes);
			materialsToSave = myMaterials;
		}
		Autodesk.InitializeServices();
		Logger.Instance.Trace(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518365));
		TD_RootIntegrated_Globals.odrxDynamicLinker().loadModule(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355530523)).Dispose();
		if (_0023_003DzP5BxsHqkgBUsubhPkA_003D_003D._0023_003Dzun1LQstwai0q())
		{
			TD_RootIntegrated_Globals.odrxDynamicLinker().loadApp(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518414)).Dispose();
			Logger.Instance.Trace(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518424));
		}
	}

	private Dictionary<string, string> _0023_003Dzz_0024F_Y9kGxUZL(Dictionary<string, string> _0023_003DzfzI8lTwK6mEA, string _0023_003Dzi_0024GqBs8_003D, autodeskVersionType _0023_003Dz2lUs5iI_003D, string _0023_003Dzr8rfJIs_003D, double _0023_003DzQGIgnLa9AaT7Qt_G1w_003D_003D, LayerKeyedCollection _0023_003Dz68IvW_AooqDP, BlockKeyedCollection _0023_003DzFyBLmv3KS6Nt, TextStyleKeyedCollection _0023_003Dzc3aLSLYhP84G, LineTypeKeyedCollection _0023_003Dziw5fCBSsasyX, MaterialKeyedCollection _0023_003DzN0ZWdMqGnIFK8BemCQ_003D_003D, bool _0023_003Dz_sf9dBZZ1poK)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		_0023_003DzKyfEzVn70e7f._0023_003DzKF8MVuFZC92h(_0023_003Dzi_0024GqBs8_003D, out var _0023_003DzyTMhpZk_003D, out var _, out var _);
		string text = Path.GetExtension(_0023_003Dzi_0024GqBs8_003D);
		if (string.IsNullOrEmpty(text))
		{
			text = _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527427);
		}
		foreach (Block item in _0023_003DzFyBLmv3KS6Nt)
		{
			Block block = item;
			if (block != null && block.ExportMode != autodeskExportType.Embedded && !item.Name.Contains(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355529060)))
			{
				_0023_003DzAUcj8HH_HzBU(item.Name, _0023_003DzyTMhpZk_003D, text, _0023_003DzfzI8lTwK6mEA, dictionary, _0023_003Dz2lUs5iI_003D, _0023_003Dzr8rfJIs_003D, _0023_003DzQGIgnLa9AaT7Qt_G1w_003D_003D, _0023_003Dz68IvW_AooqDP, _0023_003DzFyBLmv3KS6Nt, _0023_003Dzc3aLSLYhP84G, _0023_003Dziw5fCBSsasyX, _0023_003DzN0ZWdMqGnIFK8BemCQ_003D_003D, _0023_003Dz_sf9dBZZ1poK);
			}
		}
		return dictionary;
	}

	private void _0023_003DzAUcj8HH_HzBU(string _0023_003Dzxaw56Ac_003D, string _0023_003DzyTMhpZk_003D, string _0023_003Dzb7I0m7A_003D, Dictionary<string, string> _0023_003DzfzI8lTwK6mEA, Dictionary<string, string> _0023_003Dzz7_0024obinCIni7, autodeskVersionType _0023_003Dz2lUs5iI_003D, string _0023_003Dzr8rfJIs_003D, double _0023_003DzgAG3_0024qr8f0qqs6z5vQ_003D_003D, LayerKeyedCollection _0023_003Dz68IvW_AooqDP, BlockKeyedCollection _0023_003DzFyBLmv3KS6Nt, TextStyleKeyedCollection _0023_003Dzc3aLSLYhP84G, LineTypeKeyedCollection _0023_003Dziw5fCBSsasyX, MaterialKeyedCollection _0023_003DzN0ZWdMqGnIFK8BemCQ_003D_003D, bool _0023_003Dz_sf9dBZZ1poK)
	{
		if (!_0023_003DzfzI8lTwK6mEA.ContainsKey(_0023_003Dzxaw56Ac_003D))
		{
			Block block = _0023_003DzFyBLmv3KS6Nt[_0023_003Dzxaw56Ac_003D];
			string text = _0023_003Dzzh5VcS4KZoiIBUTAU9kkMuKCym7v_cHtxoIgjHLVjw33._0023_003DzhLvZ3_00245VjPWh(block, _0023_003DzyTMhpZk_003D, _0023_003Dzxaw56Ac_003D, _0023_003Dzb7I0m7A_003D);
			_0023_003DzfzI8lTwK6mEA.Add(_0023_003Dzxaw56Ac_003D, text);
			_0023_003Dzz7_0024obinCIni7.Add(_0023_003Dzxaw56Ac_003D, text);
			if (block.ExportMode == autodeskExportType.ExternalReferenceOverwrite)
			{
				_0023_003Dzzh5VcS4KZoiIBUTAU9kkMuKCym7v_cHtxoIgjHLVjw33._0023_003DzgJEJwi0_003D(block, _0023_003DzfzI8lTwK6mEA, _0023_003Dzxaw56Ac_003D + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355529060), text, _0023_003Dz2lUs5iI_003D, _0023_003Dzr8rfJIs_003D, _0023_003DzgAG3_0024qr8f0qqs6z5vQ_003D_003D, _0023_003Dz68IvW_AooqDP, _0023_003DzFyBLmv3KS6Nt, _0023_003Dzc3aLSLYhP84G, _0023_003Dziw5fCBSsasyX, _0023_003DzN0ZWdMqGnIFK8BemCQ_003D_003D, attributeReferenceVisibilityMode, _0023_003Dz_sf9dBZZ1poK);
			}
		}
	}

	internal static DwgVersion _0023_003DzzeXa96gAc7VcPZ2UkHEbJi0_003D(autodeskVersionType _0023_003Dz2lUs5iI_003D)
	{
		return _0023_003Dz2lUs5iI_003D switch
		{
			autodeskVersionType.Release12 => DwgVersion.kDHL_1009, 
			autodeskVersionType.Release13 => DwgVersion.kDHL_1012, 
			autodeskVersionType.Release14 => DwgVersion.kDHL_1014, 
			autodeskVersionType.Acad2000 => DwgVersion.kDHL_1015, 
			autodeskVersionType.Acad2004 => DwgVersion.kDHL_1800, 
			autodeskVersionType.Acad2007 => DwgVersion.kDHL_1021, 
			autodeskVersionType.Acad2010 => DwgVersion.kDHL_1024, 
			autodeskVersionType.Acad2013 => DwgVersion.kDHL_1027, 
			autodeskVersionType.Acad2018 => DwgVersion.kDHL_1032, 
			_ => DwgVersion.kDHL_1032, 
		};
	}

	internal static autodeskVersionType _0023_003DzILmOAAaXA_EU8Ikxh34yB6I_003D(DwgVersion _0023_003Dz2lUs5iI_003D)
	{
		return _0023_003Dz2lUs5iI_003D switch
		{
			DwgVersion.kDHL_1009 => autodeskVersionType.Release12, 
			DwgVersion.kDHL_1014 => autodeskVersionType.Release14, 
			DwgVersion.kDHL_1015 => autodeskVersionType.Acad2000, 
			DwgVersion.kDHL_1800 => autodeskVersionType.Acad2004, 
			DwgVersion.kDHL_1021 => autodeskVersionType.Acad2007, 
			DwgVersion.kDHL_1024 => autodeskVersionType.Acad2010, 
			DwgVersion.kDHL_1027 => autodeskVersionType.Acad2013, 
			DwgVersion.kDHL_1032 => autodeskVersionType.Acad2018, 
			_ => _0023_003Dz3jripO4_003D, 
		};
	}
}
