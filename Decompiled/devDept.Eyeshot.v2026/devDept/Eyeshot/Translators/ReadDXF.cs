using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using ACadSharp;
using ACadSharp.Blocks;
using ACadSharp.Entities;
using ACadSharp.IO;
using ACadSharp.Objects;
using ACadSharp.Tables;
using ACadSharp.Tables.Collections;
using ACadSharp.Types.Units;
using ACadSharp.XData;
using CSMath;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class ReadDXF : ReadFileAsyncWithDrawing
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<Layout, bool> _0023_003Dz_hdJXa8rSOqHcmZ37Q_003D_003D;

		public static MatchEvaluator _0023_003DzxEGf1yxnyTjjzqm72A_003D_003D;

		public static Func<ACadSharp.Entities.IVertex, bool> _0023_003Dz7XHJQY4rQnXcZT0M1A_003D_003D;

		public static Func<ACadSharp.Entities.IVertex, Point3D> _0023_003DzWHw_QWJNxLcC0IWW1w_003D_003D;

		public static Func<double, bool> _0023_003Dz4lj2lj3BgAvGEtmmqA_003D_003D;

		public static Predicate<double> _0023_003Dzm5k9_2WgmyZGw7SyBQ_003D_003D;

		internal bool _0023_003Dzdse_0024hdDX3MusvhPnH3SkBTg_003D(Layout _0023_003DzGcl_0024E9o_003D)
		{
			return _0023_003DzGcl_0024E9o_003D.Document.VPorts != null;
		}

		internal string _0023_003DzVoXsyCzmqvHYgVQ_0024WMYACvw_003D(Match _0023_003DzkKfJheA_003D)
		{
			return char.ConvertFromUtf32(int.Parse(_0023_003DzkKfJheA_003D.Groups[1].Value, NumberStyles.HexNumber));
		}

		internal bool _0023_003Dz3qa8MKPa5BQ9xfUZN8fnu1s42zW7(ACadSharp.Entities.IVertex _0023_003Dz77g161c_003D)
		{
			return _0023_003Dz77g161c_003D.Bulge != 0.0;
		}

		internal Point3D _0023_003Dzs6xj7qS4fX4acQMS_0024foLGJUM6Wecyrvz0g_003D_003D(ACadSharp.Entities.IVertex _0023_003DzMlCq3wk_003D)
		{
			return new Point3D(_0023_003DzMlCq3wk_003D.Location[0], _0023_003DzMlCq3wk_003D.Location[1]);
		}

		internal bool _0023_003DzZ6BdCMjKikJjit2Hjcjk_mA_003D(double _0023_003DzAvn2b38_003D)
		{
			return _0023_003DzAvn2b38_003D != 1.0;
		}

		internal bool _0023_003DzlNBwg9ygISZi_0024qhHQO50EMs_003D(double _0023_003DzXrexKjY_003D)
		{
			return _0023_003DzXrexKjY_003D == 0.0;
		}
	}

	private struct _0023_003Dz62alrNM_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Vector3D _0023_003DziWEQWvc_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Point3D _0023_003Dzzo8RvXc_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public devDept.Geometry.Quaternion _0023_003DzVvkLpZU_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Vector3D _0023_003DzCBEAoWM_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public projectionType _0023_003Dzbl24fQDH5pP9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzG5DcWQMkTDXTkYfv5A_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzYUMqwZQ_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public SizeF _0023_003DzeYC4yc0gvh69;

		public bool _0023_003Dzvk_j02M_003D(Camera _0023_003Dz10qtbIGWAWjL, Size _0023_003Dz4BrWeV0_003D)
		{
			if (_0023_003DziWEQWvc_003D == null)
			{
				return false;
			}
			Vector3D viewNormal = _0023_003Dz10qtbIGWAWjL.ViewNormal;
			Transformation.AutocadOCS(_0023_003DziWEQWvc_003D, out var _, out var _);
			Utility.GetRotationAxisAndAngle(viewNormal, _0023_003DziWEQWvc_003D, out var rotAxis, out var angleInDegrees);
			if (rotAxis != null)
			{
				_0023_003Dz10qtbIGWAWjL.Rotation = new devDept.Geometry.Quaternion(rotAxis, angleInDegrees) * _0023_003Dz10qtbIGWAWjL.Rotation;
			}
			_0023_003Dz10qtbIGWAWjL.Tilt(_0023_003DzCBEAoWM_003D);
			_0023_003Dz10qtbIGWAWjL.ProjectionMode = _0023_003Dzbl24fQDH5pP9;
			if (_0023_003Dz10qtbIGWAWjL.ProjectionMode == projectionType.Orthographic)
			{
				double val = (float)_0023_003Dz4BrWeV0_003D.Width / _0023_003DzeYC4yc0gvh69.Width;
				double val2 = (float)_0023_003Dz4BrWeV0_003D.Height / _0023_003DzeYC4yc0gvh69.Height;
				_0023_003Dz10qtbIGWAWjL.ZoomFactor = Math.Max(val, val2);
			}
			else
			{
				_0023_003Dz10qtbIGWAWjL.FocalLength = _0023_003DzG5DcWQMkTDXTkYfv5A_003D_003D;
				_0023_003Dz10qtbIGWAWjL.Distance = _0023_003DzYUMqwZQ_003D;
			}
			_0023_003Dz10qtbIGWAWjL.Target = _0023_003Dzzo8RvXc_003D;
			return true;
		}
	}

	private enum _0023_003DziNJCUHDcmFST3zrMfA_003D_003D
	{

	}

	public class ReadEntityData
	{
		public string xrefPrefix;

		public Dictionary<string, string> duplicatedBlockNamesConversionTable;

		public Layer testLayer;

		public BlockKeyedCollection importedBlocks;

		public Block currentBlock;

		public TextStyleKeyedCollection importedTextStyles;

		public LineTypeKeyedCollection importedLinetypes;

		public CadDocument dxfDoc;

		public Sheet sheet;

		public double layoutPlotScale;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal Viewport _0023_003DzkabH3a5uOAQQ8hRWIg_003D_003D;

		[Obsolete("Use the constructor that accepts the hatchImportMode instead.")]
		public ReadEntityData(string xrefPrefix, Dictionary<string, string> duplicatedBlockNamesConversionTable, Layer testLayer, BlockKeyedCollection importedBlocks, Block currentBlock, TextStyleKeyedCollection importedTextStyles, LineTypeKeyedCollection importedLineTypes)
		{
			this.xrefPrefix = xrefPrefix;
			this.duplicatedBlockNamesConversionTable = duplicatedBlockNamesConversionTable;
			importedLinetypes = importedLineTypes;
			this.testLayer = testLayer;
			this.importedBlocks = importedBlocks;
			this.currentBlock = currentBlock;
			this.importedTextStyles = importedTextStyles;
		}

		public ReadEntityData(string xrefPrefix, Dictionary<string, string> duplicatedBlockNamesConversionTable, Layer testLayer, BlockKeyedCollection importedBlocks, Block currentBlock, TextStyleKeyedCollection importedTextStyles, LineTypeKeyedCollection importedLineTypes, CadDocument dxfDoc)
		{
			this.xrefPrefix = xrefPrefix;
			this.duplicatedBlockNamesConversionTable = duplicatedBlockNamesConversionTable;
			importedLinetypes = importedLineTypes;
			this.testLayer = testLayer;
			this.importedBlocks = importedBlocks;
			this.currentBlock = currentBlock;
			this.importedTextStyles = importedTextStyles;
			this.dxfDoc = dxfDoc;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BlockReference[] _0023_003Dz8u4e0G0ssApZ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point3D _0023_003DzAZT6BTk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point3D _0023_003Dz0Jn_0024JRQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point2D _0023_003DzVAFbYEoSaZBi;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point2D _0023_003DzNS4zHmODUFRu;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz_0024zpG__0024iX4elX;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<string> _0023_003DzMLT9unuFCQa2775en7mFkfw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzCyyiD7aM9LW3tHdOag_003D_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzhEy9mmWqR3IsxTmAuz4mk2E_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz5indGmK8tGyPjosjB9p3oqVUYSf6 = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private System.Drawing.Color _0023_003DzHP6drmy_00244Ugs = System.Drawing.Color.White;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz0TGiFFPvnr_hM6xKTx_PXAM_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<KeyValuePair<short, object>> _0023_003DzJTv9lwiDNSb_0024LK7fCQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private autodeskVersionType _0023_003DzKeI3OEP6t3nX;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly byte[][] _0023_003Dz49SxdTbLRNQ4EW5z0A_003D_003D = new byte[256][]
	{
		new byte[3],
		new byte[3] { 255, 0, 0 },
		new byte[3] { 255, 255, 0 },
		new byte[3] { 0, 255, 0 },
		new byte[3] { 0, 255, 255 },
		new byte[3] { 0, 0, 255 },
		new byte[3] { 255, 0, 255 },
		new byte[3] { 255, 255, 255 },
		new byte[3] { 128, 128, 128 },
		new byte[3] { 192, 192, 192 },
		new byte[3] { 255, 0, 0 },
		new byte[3] { 255, 127, 127 },
		new byte[3] { 204, 0, 0 },
		new byte[3] { 204, 102, 102 },
		new byte[3] { 153, 0, 0 },
		new byte[3] { 153, 76, 76 },
		new byte[3] { 127, 0, 0 },
		new byte[3] { 127, 63, 63 },
		new byte[3] { 76, 0, 0 },
		new byte[3] { 76, 38, 38 },
		new byte[3] { 255, 63, 0 },
		new byte[3] { 255, 159, 127 },
		new byte[3] { 204, 51, 0 },
		new byte[3] { 204, 127, 102 },
		new byte[3] { 153, 38, 0 },
		new byte[3] { 153, 95, 76 },
		new byte[3] { 127, 31, 0 },
		new byte[3] { 127, 79, 63 },
		new byte[3] { 76, 19, 0 },
		new byte[3] { 76, 47, 38 },
		new byte[3] { 255, 127, 0 },
		new byte[3] { 255, 191, 127 },
		new byte[3] { 204, 102, 0 },
		new byte[3] { 204, 153, 102 },
		new byte[3] { 153, 76, 0 },
		new byte[3] { 153, 114, 76 },
		new byte[3] { 127, 63, 0 },
		new byte[3] { 127, 95, 63 },
		new byte[3] { 76, 38, 0 },
		new byte[3] { 76, 57, 38 },
		new byte[3] { 255, 191, 0 },
		new byte[3] { 255, 223, 127 },
		new byte[3] { 204, 153, 0 },
		new byte[3] { 204, 178, 102 },
		new byte[3] { 153, 114, 0 },
		new byte[3] { 153, 133, 76 },
		new byte[3] { 127, 95, 0 },
		new byte[3] { 127, 111, 63 },
		new byte[3] { 76, 57, 0 },
		new byte[3] { 76, 66, 38 },
		new byte[3] { 255, 255, 0 },
		new byte[3] { 255, 255, 127 },
		new byte[3] { 204, 204, 0 },
		new byte[3] { 204, 204, 102 },
		new byte[3] { 153, 153, 0 },
		new byte[3] { 153, 153, 76 },
		new byte[3] { 127, 127, 0 },
		new byte[3] { 127, 127, 63 },
		new byte[3] { 76, 76, 0 },
		new byte[3] { 76, 76, 38 },
		new byte[3] { 191, 255, 0 },
		new byte[3] { 223, 255, 127 },
		new byte[3] { 153, 204, 0 },
		new byte[3] { 178, 204, 102 },
		new byte[3] { 114, 153, 0 },
		new byte[3] { 133, 153, 76 },
		new byte[3] { 95, 127, 0 },
		new byte[3] { 111, 127, 63 },
		new byte[3] { 57, 76, 0 },
		new byte[3] { 66, 76, 38 },
		new byte[3] { 127, 255, 0 },
		new byte[3] { 191, 255, 127 },
		new byte[3] { 102, 204, 0 },
		new byte[3] { 153, 204, 102 },
		new byte[3] { 76, 153, 0 },
		new byte[3] { 114, 153, 76 },
		new byte[3] { 63, 127, 0 },
		new byte[3] { 95, 127, 63 },
		new byte[3] { 38, 76, 0 },
		new byte[3] { 57, 76, 38 },
		new byte[3] { 63, 255, 0 },
		new byte[3] { 159, 255, 127 },
		new byte[3] { 51, 204, 0 },
		new byte[3] { 127, 204, 102 },
		new byte[3] { 38, 153, 0 },
		new byte[3] { 95, 153, 76 },
		new byte[3] { 31, 127, 0 },
		new byte[3] { 79, 127, 63 },
		new byte[3] { 19, 76, 0 },
		new byte[3] { 47, 76, 38 },
		new byte[3] { 0, 255, 0 },
		new byte[3] { 127, 255, 127 },
		new byte[3] { 0, 204, 0 },
		new byte[3] { 102, 204, 102 },
		new byte[3] { 0, 153, 0 },
		new byte[3] { 76, 153, 76 },
		new byte[3] { 0, 127, 0 },
		new byte[3] { 63, 127, 63 },
		new byte[3] { 0, 76, 0 },
		new byte[3] { 38, 76, 38 },
		new byte[3] { 0, 255, 63 },
		new byte[3] { 127, 255, 159 },
		new byte[3] { 0, 204, 51 },
		new byte[3] { 102, 204, 127 },
		new byte[3] { 0, 153, 38 },
		new byte[3] { 76, 153, 95 },
		new byte[3] { 0, 127, 31 },
		new byte[3] { 63, 127, 79 },
		new byte[3] { 0, 76, 19 },
		new byte[3] { 38, 76, 47 },
		new byte[3] { 0, 255, 127 },
		new byte[3] { 127, 255, 191 },
		new byte[3] { 0, 204, 102 },
		new byte[3] { 102, 204, 153 },
		new byte[3] { 0, 153, 76 },
		new byte[3] { 76, 153, 114 },
		new byte[3] { 0, 127, 63 },
		new byte[3] { 63, 127, 95 },
		new byte[3] { 0, 76, 38 },
		new byte[3] { 38, 76, 57 },
		new byte[3] { 0, 255, 191 },
		new byte[3] { 127, 255, 223 },
		new byte[3] { 0, 204, 153 },
		new byte[3] { 102, 204, 178 },
		new byte[3] { 0, 153, 114 },
		new byte[3] { 76, 153, 133 },
		new byte[3] { 0, 127, 95 },
		new byte[3] { 63, 127, 111 },
		new byte[3] { 0, 76, 57 },
		new byte[3] { 38, 76, 66 },
		new byte[3] { 0, 255, 255 },
		new byte[3] { 127, 255, 255 },
		new byte[3] { 0, 204, 204 },
		new byte[3] { 102, 204, 204 },
		new byte[3] { 0, 153, 153 },
		new byte[3] { 76, 153, 153 },
		new byte[3] { 0, 127, 127 },
		new byte[3] { 63, 127, 127 },
		new byte[3] { 0, 76, 76 },
		new byte[3] { 38, 76, 76 },
		new byte[3] { 0, 191, 255 },
		new byte[3] { 127, 223, 255 },
		new byte[3] { 0, 153, 204 },
		new byte[3] { 102, 178, 204 },
		new byte[3] { 0, 114, 153 },
		new byte[3] { 76, 133, 153 },
		new byte[3] { 0, 95, 127 },
		new byte[3] { 63, 111, 127 },
		new byte[3] { 0, 57, 76 },
		new byte[3] { 38, 66, 76 },
		new byte[3] { 0, 127, 255 },
		new byte[3] { 127, 191, 255 },
		new byte[3] { 0, 102, 204 },
		new byte[3] { 102, 153, 204 },
		new byte[3] { 0, 76, 153 },
		new byte[3] { 76, 114, 153 },
		new byte[3] { 0, 63, 127 },
		new byte[3] { 63, 95, 127 },
		new byte[3] { 0, 38, 76 },
		new byte[3] { 38, 57, 76 },
		new byte[3] { 0, 63, 255 },
		new byte[3] { 127, 159, 255 },
		new byte[3] { 0, 51, 204 },
		new byte[3] { 102, 127, 204 },
		new byte[3] { 0, 38, 153 },
		new byte[3] { 76, 95, 153 },
		new byte[3] { 0, 31, 127 },
		new byte[3] { 63, 79, 127 },
		new byte[3] { 0, 19, 76 },
		new byte[3] { 38, 47, 76 },
		new byte[3] { 0, 0, 255 },
		new byte[3] { 127, 127, 255 },
		new byte[3] { 0, 0, 204 },
		new byte[3] { 102, 102, 204 },
		new byte[3] { 0, 0, 153 },
		new byte[3] { 76, 76, 153 },
		new byte[3] { 0, 0, 127 },
		new byte[3] { 63, 63, 127 },
		new byte[3] { 0, 0, 76 },
		new byte[3] { 38, 38, 76 },
		new byte[3] { 63, 0, 255 },
		new byte[3] { 159, 127, 255 },
		new byte[3] { 51, 0, 204 },
		new byte[3] { 127, 102, 204 },
		new byte[3] { 38, 0, 153 },
		new byte[3] { 95, 76, 153 },
		new byte[3] { 31, 0, 127 },
		new byte[3] { 79, 63, 127 },
		new byte[3] { 19, 0, 76 },
		new byte[3] { 47, 38, 76 },
		new byte[3] { 127, 0, 255 },
		new byte[3] { 191, 127, 255 },
		new byte[3] { 102, 0, 204 },
		new byte[3] { 153, 102, 204 },
		new byte[3] { 76, 0, 153 },
		new byte[3] { 114, 76, 153 },
		new byte[3] { 63, 0, 127 },
		new byte[3] { 95, 63, 127 },
		new byte[3] { 38, 0, 76 },
		new byte[3] { 57, 38, 76 },
		new byte[3] { 191, 0, 255 },
		new byte[3] { 223, 127, 255 },
		new byte[3] { 153, 0, 204 },
		new byte[3] { 178, 102, 204 },
		new byte[3] { 114, 0, 153 },
		new byte[3] { 133, 76, 153 },
		new byte[3] { 95, 0, 127 },
		new byte[3] { 111, 63, 127 },
		new byte[3] { 57, 0, 76 },
		new byte[3] { 66, 38, 76 },
		new byte[3] { 255, 0, 255 },
		new byte[3] { 255, 127, 255 },
		new byte[3] { 204, 0, 204 },
		new byte[3] { 204, 102, 204 },
		new byte[3] { 153, 0, 153 },
		new byte[3] { 153, 76, 153 },
		new byte[3] { 127, 0, 127 },
		new byte[3] { 127, 63, 127 },
		new byte[3] { 76, 0, 76 },
		new byte[3] { 76, 38, 76 },
		new byte[3] { 255, 0, 191 },
		new byte[3] { 255, 127, 223 },
		new byte[3] { 204, 0, 153 },
		new byte[3] { 204, 102, 178 },
		new byte[3] { 153, 0, 114 },
		new byte[3] { 153, 76, 133 },
		new byte[3] { 127, 0, 95 },
		new byte[3] { 127, 63, 111 },
		new byte[3] { 76, 0, 57 },
		new byte[3] { 76, 38, 66 },
		new byte[3] { 255, 0, 127 },
		new byte[3] { 255, 127, 191 },
		new byte[3] { 204, 0, 102 },
		new byte[3] { 204, 102, 153 },
		new byte[3] { 153, 0, 76 },
		new byte[3] { 153, 76, 114 },
		new byte[3] { 127, 0, 63 },
		new byte[3] { 127, 63, 95 },
		new byte[3] { 76, 0, 38 },
		new byte[3] { 76, 38, 57 },
		new byte[3] { 255, 0, 63 },
		new byte[3] { 255, 127, 159 },
		new byte[3] { 204, 0, 51 },
		new byte[3] { 204, 102, 127 },
		new byte[3] { 153, 0, 38 },
		new byte[3] { 153, 76, 95 },
		new byte[3] { 127, 0, 31 },
		new byte[3] { 127, 63, 79 },
		new byte[3] { 76, 0, 19 },
		new byte[3] { 76, 38, 47 },
		new byte[3] { 51, 51, 51 },
		new byte[3] { 91, 91, 91 },
		new byte[3] { 132, 132, 132 },
		new byte[3] { 173, 173, 173 },
		new byte[3] { 214, 214, 214 },
		new byte[3] { 255, 255, 255 }
	};

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Dictionary<string, Transformation> _0023_003DzITXpfHxrZadmFvP45uqDMLZnKO0F3aPhN8xP52E_003D = new Dictionary<string, Transformation>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private attributeReferenceVisibilityType _0023_003DzJZfO4uz59vBX5V2TVavwutQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<string> _0023_003DziXfogF_pa_0024Ze;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private StreamWriter _0023_003DzL488Qn1BVJw5;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point3D _0023_003DzMUz8vbaWBbHG = Point3D.Origin;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003Dz62alrNM_003D _0023_003DzAbd0a0sUY4t0eHwgcQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz_0024Fk5VPw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<string> _0023_003DzpNTDgxIpPHS2 = new List<string>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<string> _0023_003Dzi1RitS6Kazvm;

	public static Dictionary<string, int> DebugCountMissingByType = new Dictionary<string, int>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<ACadSharp.Entities.Dimension, Dictionary<short, object>> _0023_003DzZEXNeXDb73Ak;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzEOCbnTbp11XugOEoecv8QbaozcO1;

	public override supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.All;

	public List<string> LayersToLoad
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzMLT9unuFCQa2775en7mFkfw_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzMLT9unuFCQa2775en7mFkfw_003D = value;
		}
	}

	public bool Simplify
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzCyyiD7aM9LW3tHdOag_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzCyyiD7aM9LW3tHdOag_003D_003D = value;
		}
	}

	public bool SkipLayouts
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzhEy9mmWqR3IsxTmAuz4mk2E_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzhEy9mmWqR3IsxTmAuz4mk2E_003D = value;
		}
	}

	public bool ExtrudeByThickness
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz5indGmK8tGyPjosjB9p3oqVUYSf6;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz5indGmK8tGyPjosjB9p3oqVUYSf6 = value;
		}
	}

	public System.Drawing.Color ForegroundColor
	{
		get
		{
			return _0023_003DzHP6drmy_00244Ugs;
		}
		set
		{
			if (value.ToArgb() != System.Drawing.Color.White.ToArgb() && value.ToArgb() != System.Drawing.Color.Black.ToArgb())
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999151));
			}
			_0023_003DzHP6drmy_00244Ugs = value;
		}
	}

	public bool SkipExternalReferences
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz0TGiFFPvnr_hM6xKTx_PXAM_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz0TGiFFPvnr_hM6xKTx_PXAM_003D = value;
		}
	}

	public List<KeyValuePair<short, object>> ModelXData
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzJTv9lwiDNSb_0024LK7fCQ_003D_003D;
		}
	}

	public autodeskVersionType OriginalFileVersion => _0023_003DzKeI3OEP6t3nX;

	public BlockReference[] FailedToLoad => _0023_003Dz8u4e0G0ssApZ;

	public Point3D Min => _0023_003DzAZT6BTk_003D;

	public Point3D Max => _0023_003Dz0Jn_0024JRQ_003D;

	public Point2D MinLimit => _0023_003DzVAFbYEoSaZBi;

	public Point2D MaxLimit => _0023_003DzNS4zHmODUFRu;

	public bool CheckLimit => _0023_003Dz_0024zpG__0024iX4elX;

	public Dictionary<string, Transformation> PlotTransformations
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzITXpfHxrZadmFvP45uqDMLZnKO0F3aPhN8xP52E_003D;
		}
	}

	public attributeReferenceVisibilityType AttributeReferenceVisibilityMode
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzJZfO4uz59vBX5V2TVavwutQ_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzJZfO4uz59vBX5V2TVavwutQ_003D = value;
		}
	}

	public Point3D BasePoint => _0023_003DzMUz8vbaWBbHG;

	public List<string> SearchFolders => _0023_003DzpNTDgxIpPHS2;

	public bool ExplodeDimensions
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzEOCbnTbp11XugOEoecv8QbaozcO1;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzEOCbnTbp11XugOEoecv8QbaozcO1 = value;
		}
	}

	public ReadDXF(string filePath)
		: base(filePath)
	{
		_0023_003DztGdcVOA_003D();
		_0023_003Dzi1RitS6Kazvm.Add(System.IO.Path.GetFileName(filePath));
	}

	public ReadDXF(Stream stream)
		: base(stream)
	{
		_0023_003DztGdcVOA_003D();
	}

	private void _0023_003Dzg_gOAs0z3hYG(List<KeyValuePair<short, object>> _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzJTv9lwiDNSb_0024LK7fCQ_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private autodeskVersionType _0023_003DzVIPEcDE_003D(ACadVersion _0023_003Dz5C8yykUpUzyh)
	{
		return _0023_003Dz5C8yykUpUzyh switch
		{
			ACadVersion.AC1009 => autodeskVersionType.Release12, 
			ACadVersion.AC1012 => autodeskVersionType.Release13, 
			ACadVersion.AC1014 => autodeskVersionType.Release14, 
			ACadVersion.AC1015 => autodeskVersionType.Acad2000, 
			ACadVersion.AC1018 => autodeskVersionType.Acad2004, 
			ACadVersion.AC1021 => autodeskVersionType.Acad2007, 
			ACadVersion.AC1024 => autodeskVersionType.Acad2010, 
			ACadVersion.AC1027 => autodeskVersionType.Acad2013, 
			ACadVersion.AC1032 => autodeskVersionType.Acad2018, 
			_ => autodeskVersionType.Release12, 
		};
	}

	private void _0023_003DztGdcVOA_003D()
	{
		_0023_003DzZEXNeXDb73Ak = new Dictionary<ACadSharp.Entities.Dimension, Dictionary<short, object>>();
		_0023_003Dzi1RitS6Kazvm = new List<string>();
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"ac>", array);
		_0023_003Dz_0024Fk5VPw_003D = false;
		_0023_003DzoJlqvtM_003D(base.Stream, out var _0023_003DzrxLRsss3tg, out var _0023_003Dz4ic8Qw6f1Sz, out _0023_003Dz8u4e0G0ssApZ, out _0023_003DzAZT6BTk_003D, out _0023_003Dz0Jn_0024JRQ_003D, out _0023_003DzVAFbYEoSaZBi, out _0023_003DzNS4zHmODUFRu, out _0023_003Dz_0024zpG__0024iX4elX, progress, ct);
		base.Units = _0023_003Dz4ic8Qw6f1Sz;
		if (_0023_003DzrxLRsss3tg != null)
		{
			base.Entities.AddRange(_0023_003DzrxLRsss3tg);
		}
	}

	private static void _0023_003DzD_b88_0024aSBUyV<T>(EyeshotKeyedCollection<T> _0023_003DzqjMrmuo_003D, EyeshotKeyedCollection<T> _0023_003DzaoQTclc_003D) where T : IKeyedCollectionItem<T>
	{
		if (_0023_003DzqjMrmuo_003D == null)
		{
			return;
		}
		foreach (T item in _0023_003DzqjMrmuo_003D)
		{
			if (!_0023_003DzaoQTclc_003D.Contains(item.GetKey()))
			{
				_0023_003DzaoQTclc_003D.Add(item);
			}
		}
	}

	private void _0023_003DzoJlqvtM_003D(Stream _0023_003Dz98C1PIe_70FL, out devDept.Eyeshot.Entities.Entity[] _0023_003DzrxLRsss3tg14, out linearUnitsType _0023_003Dz4ic8Qw6f1Sz9, out BlockReference[] _0023_003DzFP1zNm5aIpvo, out Point3D _0023_003DzqWHpvmQvMwHz, out Point3D _0023_003Dz6ess2JBT2mRt, out Point2D _0023_003DzR5VQfyZ_0024ynIe, out Point2D _0023_003DzDg4PnRgsENxJ, out bool _0023_003DzDQBgVUlXFc12, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		_0023_003DzrxLRsss3tg14 = null;
		_0023_003DzqWHpvmQvMwHz = Point3D.MaxValue;
		_0023_003Dz6ess2JBT2mRt = Point3D.MinValue;
		base.Result = false;
		_0023_003DzR5VQfyZ_0024ynIe = null;
		_0023_003DzDg4PnRgsENxJ = null;
		_0023_003DzDQBgVUlXFc12 = false;
		try
		{
			_0023_003DzspExml1j72mr_FI04NKW780_003D _0023_003DzspExml1j72mr_FI04NKW780_003D2 = new _0023_003DzspExml1j72mr_FI04NKW780_003D();
			try
			{
				StartContinuousAnimation(base.ReadingText, _0023_003DzmHS7frs_003D);
				if (_0023_003DziovQPjxLLGlj(_0023_003Dz98C1PIe_70FL, out _0023_003Dz4ic8Qw6f1Sz9, out _0023_003DzrxLRsss3tg14, out _0023_003DzFP1zNm5aIpvo, ref _0023_003DzqWHpvmQvMwHz, ref _0023_003Dz6ess2JBT2mRt, ref _0023_003DzR5VQfyZ_0024ynIe, ref _0023_003DzDg4PnRgsENxJ, ref _0023_003DzDQBgVUlXFc12, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
				{
					base.Result = true;
				}
			}
			finally
			{
				((IDisposable)_0023_003DzspExml1j72mr_FI04NKW780_003D2).Dispose();
			}
		}
		catch (Exception ex)
		{
			_0023_003DzFP1zNm5aIpvo = new BlockReference[0];
			_0023_003Dz4ic8Qw6f1Sz9 = linearUnitsType.Unitless;
			base.Result = false;
			log.AppendLine(ex.Message);
			log.AppendLine();
		}
		finally
		{
			CloseStream();
			StopContinuousAnimation(_0023_003DzmHS7frs_003D);
		}
	}

	internal virtual bool _0023_003DziovQPjxLLGlj(Stream _0023_003Dz98C1PIe_70FL, out linearUnitsType _0023_003Dz4ic8Qw6f1Sz9, out devDept.Eyeshot.Entities.Entity[] _0023_003DzrxLRsss3tg14, out BlockReference[] _0023_003DzFP1zNm5aIpvo, ref Point3D _0023_003DzqWHpvmQvMwHz, ref Point3D _0023_003Dz6ess2JBT2mRt, ref Point2D _0023_003DzR5VQfyZ_0024ynIe, ref Point2D _0023_003DzDg4PnRgsENxJ, ref bool _0023_003DzDQBgVUlXFc12, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		CadDocument cadDocument = DxfReader.Read(_0023_003Dz98C1PIe_70FL);
		ACadVersion version = cadDocument.Header.Version;
		if (version < ACadVersion.AC1009)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003932));
		}
		_0023_003DzKeI3OEP6t3nX = _0023_003DzVIPEcDE_003D(version);
		if (cadDocument == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004097));
		}
		if (!_0023_003DziovQPjxLLGlj(out _0023_003DzrxLRsss3tg14, out _0023_003DzFP1zNm5aIpvo, ref _0023_003DzqWHpvmQvMwHz, ref _0023_003Dz6ess2JBT2mRt, ref _0023_003DzR5VQfyZ_0024ynIe, ref _0023_003DzDg4PnRgsENxJ, ref _0023_003DzDQBgVUlXFc12, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D, cadDocument))
		{
			_0023_003Dz4ic8Qw6f1Sz9 = linearUnitsType.Unitless;
			return false;
		}
		if (_0023_003DzKeI3OEP6t3nX <= autodeskVersionType.Release14)
		{
			_0023_003Dz4ic8Qw6f1Sz9 = linearUnitsType.Unitless;
		}
		else
		{
			_0023_003Dz4ic8Qw6f1Sz9 = _0023_003Dz8xTAk74d3tW9uU39Bg_003D_003D(cadDocument.Header.InsUnits);
		}
		return true;
	}

	internal bool _0023_003DziovQPjxLLGlj(out devDept.Eyeshot.Entities.Entity[] _0023_003DzrxLRsss3tg14, out BlockReference[] _0023_003DzFP1zNm5aIpvo, ref Point3D _0023_003DzF7v9r2A_003D, ref Point3D _0023_003Dz8dK2uhU_003D, ref Point2D _0023_003DzR5VQfyZ_0024ynIe, ref Point2D _0023_003DzDg4PnRgsENxJ, ref bool _0023_003DzDQBgVUlXFc12, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D, CadDocument _0023_003DzzNwbNAz1GMVr)
	{
		_0023_003DzR5VQfyZ_0024ynIe = _0023_003DzUnxHUznPiV7g(_0023_003DzzNwbNAz1GMVr.Header.ModelSpaceLimitsMin);
		_0023_003DzDg4PnRgsENxJ = _0023_003DzUnxHUznPiV7g(_0023_003DzzNwbNAz1GMVr.Header.ModelSpaceLimitsMax);
		_0023_003DzDQBgVUlXFc12 = _0023_003DzzNwbNAz1GMVr.Header.LimitCheckingOn;
		_0023_003DzrxLRsss3tg14 = null;
		base.HatchPatterns = new HatchPatternKeyedCollection();
		Dictionary<string, string> _0023_003Dz47HBQmYeh1Ai = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
		Dictionary<string, string> _0023_003DzVI3kxwXaiZh7twr0r_5Zn_gEGRNB = new Dictionary<string, string>();
		BlockKeyedCollection _0023_003Dza0EiICLV_0024jmu;
		TextStyleKeyedCollection _0023_003DzUkGYUZOWpxG;
		LineTypeKeyedCollection _0023_003Dzr0vuHde1OVHk;
		float _0023_003Dz8oMsDcyNkuDg;
		List<devDept.Eyeshot.Entities.Entity> list = _0023_003DzbezkkWk_003D(null, _0023_003DzVI3kxwXaiZh7twr0r_5Zn_gEGRNB, _0023_003DzzNwbNAz1GMVr, _0023_003Dz47HBQmYeh1Ai, out _0023_003Dza0EiICLV_0024jmu, out _0023_003DzUkGYUZOWpxG, out _0023_003Dzr0vuHde1OVHk, out _0023_003Dz8oMsDcyNkuDg, out _0023_003DzF7v9r2A_003D, out _0023_003Dz8dK2uhU_003D, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
		base.TextStyles = _0023_003DzUkGYUZOWpxG;
		base.LineTypes = _0023_003Dzr0vuHde1OVHk;
		base.LineTypeScale = _0023_003Dz8oMsDcyNkuDg;
		if (_0023_003Dz_0024Fk5VPw_003D)
		{
			_0023_003DzFP1zNm5aIpvo = null;
			return false;
		}
		AttributeReferenceVisibilityMode = (attributeReferenceVisibilityType)_0023_003DzzNwbNAz1GMVr.Header.AttributeVisibility;
		base.HatchPatterns.Measurement = (HatchPatternKeyedCollection.measurementType)_0023_003DzzNwbNAz1GMVr.Header.MeasurementUnits;
		if (base.DrawingHatchPatterns != null)
		{
			base.DrawingHatchPatterns.Measurement = base.HatchPatterns.Measurement;
		}
		_0023_003Dz7XjdhNvt8J0WiIzNng_003D_003D(_0023_003Dz47HBQmYeh1Ai, _0023_003Dza0EiICLV_0024jmu, base.DrawingSheets, list, out var _0023_003DzmHKZHuZxh7vMyI8FUA_003D_003D, out var _0023_003Dz25nZSuNUZn5v);
		_0023_003DzrBeU_f_Ge5Om(list, _0023_003Dza0EiICLV_0024jmu);
		if (!SkipLayouts)
		{
			foreach (Sheet drawingSheet in base.DrawingSheets)
			{
				_0023_003DzrBeU_f_Ge5Om(drawingSheet.Entities, _0023_003Dza0EiICLV_0024jmu);
			}
		}
		foreach (Block item in _0023_003Dza0EiICLV_0024jmu)
		{
			_0023_003DzrBeU_f_Ge5Om(item.Entities, _0023_003Dza0EiICLV_0024jmu);
		}
		_0023_003DzrxLRsss3tg14 = list.ToArray();
		_0023_003DzFP1zNm5aIpvo = _0023_003DzmHKZHuZxh7vMyI8FUA_003D_003D.ToArray();
		foreach (Block item2 in _0023_003Dza0EiICLV_0024jmu)
		{
			bool flag = item2.BlockSource != autodeskSourceType.Anonymous;
			if (!base.Blocks.Contains(item2.Name) && (flag || _0023_003Dz25nZSuNUZn5v.Contains(item2.Name)))
			{
				base.Blocks.Add(item2);
			}
		}
		return true;
	}

	private void _0023_003DzrBeU_f_Ge5Om(IList<devDept.Eyeshot.Entities.Entity> _0023_003Dzv7xH9gk_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D)
	{
		foreach (devDept.Eyeshot.Entities.Entity item in _0023_003Dzv7xH9gk_003D)
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
			Transformation transformation = (Transformation)blockReference.GetFullTransformation(_0023_003DzJO1FWlQ_003D).Clone();
			transformation.Invert();
			foreach (KeyValuePair<string, AttributeReference> attribute in blockReference.Attributes)
			{
				Plane plane = attribute.Value.Plane;
				attribute.Value.Plane = new Plane(transformation * plane.Origin, transformation * plane.AxisX, transformation * plane.AxisY);
			}
		}
	}

	private void _0023_003Dz7XjdhNvt8J0WiIzNng_003D_003D(Dictionary<string, string> _0023_003Dz47HBQmYeh1Ai, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, SheetKeyedCollection _0023_003DzqGLs6NnUvrRQ, IList<devDept.Eyeshot.Entities.Entity> _0023_003DzWc9WmS8VMsuA, out List<BlockReference> _0023_003DzmHKZHuZxh7vMyI8FUA_003D_003D, out HashSet<string> _0023_003Dz25nZSuNUZn5v)
	{
		_0023_003DzmHKZHuZxh7vMyI8FUA_003D_003D = new List<BlockReference>();
		_0023_003Dz25nZSuNUZn5v = new HashSet<string>();
		foreach (Block item in _0023_003DzJO1FWlQ_003D)
		{
			_0023_003Dz7XjdhNvt8J0WiIzNng_003D_003D(_0023_003Dz47HBQmYeh1Ai, _0023_003DzJO1FWlQ_003D, item.Entities, _0023_003DzmHKZHuZxh7vMyI8FUA_003D_003D, _0023_003Dz25nZSuNUZn5v);
		}
		if (!SkipLayouts)
		{
			foreach (Sheet item2 in _0023_003DzqGLs6NnUvrRQ)
			{
				_0023_003Dz7XjdhNvt8J0WiIzNng_003D_003D(_0023_003Dz47HBQmYeh1Ai, _0023_003DzJO1FWlQ_003D, item2.Entities, _0023_003DzmHKZHuZxh7vMyI8FUA_003D_003D, _0023_003Dz25nZSuNUZn5v);
			}
		}
		_0023_003Dz7XjdhNvt8J0WiIzNng_003D_003D(_0023_003Dz47HBQmYeh1Ai, _0023_003DzJO1FWlQ_003D, _0023_003DzWc9WmS8VMsuA, _0023_003DzmHKZHuZxh7vMyI8FUA_003D_003D, _0023_003Dz25nZSuNUZn5v);
	}

	private void _0023_003Dz7XjdhNvt8J0WiIzNng_003D_003D(Dictionary<string, string> _0023_003Dz47HBQmYeh1Ai, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, IList<devDept.Eyeshot.Entities.Entity> _0023_003DzWc9WmS8VMsuA, List<BlockReference> _0023_003DzmHKZHuZxh7vMyI8FUA_003D_003D, HashSet<string> _0023_003Dz25nZSuNUZn5v)
	{
		for (int i = 0; i < _0023_003DzWc9WmS8VMsuA.Count; i++)
		{
			if (_0023_003DzWc9WmS8VMsuA[i] is devDept.Eyeshot.Entities.View || !(_0023_003DzWc9WmS8VMsuA[i] is BlockReference blockReference))
			{
				continue;
			}
			bool flag = _0023_003Dz47HBQmYeh1Ai.ContainsKey(blockReference.BlockName);
			if (flag || !_0023_003DzJO1FWlQ_003D.Contains(blockReference.BlockName))
			{
				if (flag)
				{
					blockReference.EntityData = _0023_003Dz47HBQmYeh1Ai[blockReference.BlockName];
				}
				_0023_003DzmHKZHuZxh7vMyI8FUA_003D_003D.Add(blockReference);
				_0023_003DzWc9WmS8VMsuA.RemoveAt(i);
				i--;
			}
			else
			{
				_0023_003Dz25nZSuNUZn5v.Add(blockReference.BlockName);
			}
		}
	}

	[Conditional("PRINT_AUTODESK")]
	private void _0023_003Dz3j2MWyc_003D(string _0023_003DzkKfJheA_003D)
	{
		_0023_003DzL488Qn1BVJw5.WriteLine(_0023_003DzkKfJheA_003D);
	}

	[Conditional("PRINT_AUTODESK")]
	private void _0023_003DzXtPp1L_C8leT()
	{
		_0023_003DzL488Qn1BVJw5 = new StreamWriter(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999798));
	}

	[Conditional("PRINT_AUTODESK")]
	private void _0023_003Dz6edkzof72BT6()
	{
		_0023_003DzL488Qn1BVJw5.Close();
	}

	internal void _0023_003DzzDW8Nhhc76Dg(Point3D _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzMUz8vbaWBbHG = _0023_003DzPzO_0024GUk_003D;
	}

	private List<devDept.Eyeshot.Entities.Entity> _0023_003DzbezkkWk_003D(string _0023_003Dzi_i_00249LM56LFZ, Dictionary<string, string> _0023_003DzVI3kxwXaiZh7twr0r_5Zn_gEGRNB, CadDocument _0023_003DzzNwbNAz1GMVr, Dictionary<string, string> _0023_003Dz47HBQmYeh1Ai, out BlockKeyedCollection _0023_003Dza0EiICLV_0024jmu, out TextStyleKeyedCollection _0023_003DzUkGYUZOWpxG4, out LineTypeKeyedCollection _0023_003Dzr0vuHde1OVHk, out float _0023_003Dz8oMsDcyNkuDg, out Point3D _0023_003DzF7v9r2A_003D, out Point3D _0023_003Dz8dK2uhU_003D, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		_0023_003DzUkGYUZOWpxG4 = new TextStyleKeyedCollection();
		_0023_003Dza0EiICLV_0024jmu = new BlockKeyedCollection();
		if (string.IsNullOrEmpty(_0023_003Dzi_i_00249LM56LFZ))
		{
			_0023_003Dzi_i_00249LM56LFZ = string.Empty;
			_0023_003DzzDW8Nhhc76Dg(new Point3D(_0023_003DzzNwbNAz1GMVr.Header.ModelSpaceInsertionBase.X, _0023_003DzzNwbNAz1GMVr.Header.ModelSpaceInsertionBase.Y, _0023_003DzzNwbNAz1GMVr.Header.ModelSpaceInsertionBase.Z));
		}
		_0023_003DzF7v9r2A_003D = Point3D.MaxValue;
		_0023_003Dz8dK2uhU_003D = Point3D.MinValue;
		_0023_003Dz8oMsDcyNkuDg = (float)_0023_003DzzNwbNAz1GMVr.Header.LineTypeScale;
		bool flag = !string.IsNullOrEmpty(_0023_003Dzi_i_00249LM56LFZ);
		string _0023_003DzUPTg1DPlXSwL = string.Empty;
		if (flag)
		{
			_0023_003DzUPTg1DPlXSwL = _0023_003Dzi_i_00249LM56LFZ.Substring(0, _0023_003Dzi_i_00249LM56LFZ.Length - 1);
		}
		_0023_003DzzgJ0_0024bS_0024T6DyaeQm_0024A_003D_003D(_0023_003DzzNwbNAz1GMVr);
		_0023_003Dzi605dMOp2r3T(_0023_003DzzNwbNAz1GMVr, _0023_003DzUPTg1DPlXSwL, out _0023_003Dzr0vuHde1OVHk);
		_0023_003DzdEWsLrg_003D(_0023_003DzzNwbNAz1GMVr, flag, _0023_003Dzi_i_00249LM56LFZ, _0023_003DzUPTg1DPlXSwL, _0023_003Dzr0vuHde1OVHk);
		_0023_003DzorzoAewfz7D_(_0023_003DzzNwbNAz1GMVr, out _0023_003DzUkGYUZOWpxG4, _0023_003DzUPTg1DPlXSwL);
		List<devDept.Eyeshot.Entities.Entity> list = new List<devDept.Eyeshot.Entities.Entity>();
		_0023_003Dza0EiICLV_0024jmu = new BlockKeyedCollection(StringComparer.CurrentCultureIgnoreCase);
		ReadEntityData _0023_003DzELu0Pss_003D = new ReadEntityData(_0023_003Dzi_i_00249LM56LFZ, _0023_003DzVI3kxwXaiZh7twr0r_5Zn_gEGRNB, new Layer(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999784)), _0023_003Dza0EiICLV_0024jmu, null, _0023_003DzUkGYUZOWpxG4, _0023_003Dzr0vuHde1OVHk, _0023_003DzzNwbNAz1GMVr);
		StopContinuousAnimation(_0023_003DzmHS7frs_003D);
		_0023_003Dz_WPSEfrCWp3R(_0023_003DzzNwbNAz1GMVr, _0023_003DzELu0Pss_003D, _0023_003Dz47HBQmYeh1Ai, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
		if (!flag)
		{
			_0023_003DzwXaUSxTMziQA(_0023_003DzzNwbNAz1GMVr);
		}
		if (_0023_003DzzNwbNAz1GMVr.VPorts.Count > 1)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999761));
		}
		if (_0023_003Dz_0024Fk5VPw_003D)
		{
			list = null;
		}
		else
		{
			BlockRecord modelSpace = _0023_003DzzNwbNAz1GMVr.ModelSpace;
			_0023_003DzfOBDTtTFrTm5(modelSpace, list, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D, _0023_003DzELu0Pss_003D, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
			if (modelSpace.ExtendedData != null)
			{
				List<KeyValuePair<short, object>> list2 = _0023_003DzFXVV5876DzAvpbgquA_003D_003D(modelSpace.ExtendedData);
				if (list2.Count > 0)
				{
					_0023_003Dzg_gOAs0z3hYG(list2);
				}
			}
			if (!SkipLayouts && !flag)
			{
				base.DrawingSheets = new SheetKeyedCollection();
				base.DrawingLineTypes = new LineTypeKeyedCollection();
				base.DrawingHatchPatterns = new HatchPatternKeyedCollection();
				base.DrawingTextStyles = new TextStyleKeyedCollection();
				base.DrawingLayers = new LayerKeyedCollection();
				base.DrawingBlocks = new BlockKeyedCollection();
				_0023_003DzVXwZYbg_003D(_0023_003DzELu0Pss_003D, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
			}
		}
		return list;
	}

	private void _0023_003DzzgJ0_0024bS_0024T6DyaeQm_0024A_003D_003D(CadDocument _0023_003DzzNwbNAz1GMVr)
	{
	}

	private void _0023_003DzorzoAewfz7D_(CadDocument _0023_003DzzNwbNAz1GMVr, out TextStyleKeyedCollection _0023_003DzUkGYUZOWpxG4, string _0023_003DzUPTg1DPlXSwL)
	{
		_0023_003DzUkGYUZOWpxG4 = new TextStyleKeyedCollection();
		foreach (ACadSharp.Tables.TextStyle textStyle in _0023_003DzzNwbNAz1GMVr.TextStyles)
		{
			if (!string.IsNullOrEmpty(textStyle.Name) && !_0023_003DzUkGYUZOWpxG4.Contains(textStyle.Name))
			{
				_0023_003DzUkGYUZOWpxG4.Add(_0023_003Dz6ZIsoVdTO_jk90za3Vza19TgahMi(textStyle, _0023_003DzUPTg1DPlXSwL));
			}
		}
	}

	private void _0023_003Dzi605dMOp2r3T(CadDocument _0023_003DzzNwbNAz1GMVr, string _0023_003DzUPTg1DPlXSwL, out LineTypeKeyedCollection _0023_003Dzr0vuHde1OVHk)
	{
		_0023_003Dzr0vuHde1OVHk = new LineTypeKeyedCollection();
		foreach (ACadSharp.Tables.LineType lineType in _0023_003DzzNwbNAz1GMVr.LineTypes)
		{
			if (((lineType.Flags & StandardFlags.XrefDependent) == 0 || (!string.IsNullOrEmpty(_0023_003DzUPTg1DPlXSwL) && lineType.Name.StartsWith(_0023_003DzUPTg1DPlXSwL))) && !LineTypeKeyedCollection.IsReservedName(lineType.Name))
			{
				float[] array = new float[lineType.Segments.Count()];
				for (int i = 0; i < lineType.Segments.Count(); i++)
				{
					array[i] = (float)lineType.Segments.ToList()[i].Length;
				}
				if (LineType.CheckPattern(array, throwEx: false, out var _) && !_0023_003Dzr0vuHde1OVHk.Contains(lineType.Name))
				{
					_0023_003Dzr0vuHde1OVHk.Add(new LineType(lineType.Name, array, _0023_003DzUPTg1DPlXSwL));
				}
			}
		}
	}

	private static int _0023_003DzQxq0CDHnkW4A(Transparency _0023_003Dzq20_0024F4aKWDHq5pohIqPx2Bo_003D)
	{
		if (_0023_003Dzq20_0024F4aKWDHq5pohIqPx2Bo_003D.IsByBlock || _0023_003Dzq20_0024F4aKWDHq5pohIqPx2Bo_003D.IsByLayer)
		{
			return 255;
		}
		return (int)Math.Floor((1.0 - (double)_0023_003Dzq20_0024F4aKWDHq5pohIqPx2Bo_003D.Value * 0.01) * 255.0);
	}

	private static bool _0023_003DzpCJKNlLmkV2U(string _0023_003DzaROjBYA_003D)
	{
		return _0023_003DzaROjBYA_003D.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909683));
	}

	private void _0023_003DzdEWsLrg_003D(CadDocument _0023_003DzzNwbNAz1GMVr, bool _0023_003DzBSmc6k0_003D, string _0023_003Dzi_i_00249LM56LFZ, string _0023_003DzUPTg1DPlXSwL, LineTypeKeyedCollection _0023_003Dzr0vuHde1OVHk)
	{
		foreach (ACadSharp.Tables.Layer layer2 in _0023_003DzzNwbNAz1GMVr.Layers)
		{
			if (_0023_003DzpCJKNlLmkV2U(layer2.Name) || (LayersToLoad != null && !LayersToLoad.Contains(layer2.Name)) || ((layer2.Flags & LayerFlags.XrefDependent) != LayerFlags.None && (string.IsNullOrEmpty(_0023_003Dzi_i_00249LM56LFZ) || !layer2.Name.StartsWith(_0023_003Dzi_i_00249LM56LFZ))))
			{
				continue;
			}
			int alpha = _0023_003DzZpG9HHAj6jU6(layer2);
			ACadSharp.Color color = layer2.Color;
			System.Drawing.Color color2;
			if (color.IsTrueColor)
			{
				color2 = System.Drawing.Color.FromArgb(alpha, layer2.Color.R, layer2.Color.G, layer2.Color.B);
			}
			else if (color.Index == 7)
			{
				color2 = System.Drawing.Color.FromArgb(alpha, ForegroundColor);
			}
			else
			{
				byte[][] array = _0023_003Dz49SxdTbLRNQ4EW5z0A_003D_003D;
				color2 = System.Drawing.Color.FromArgb(array[color.Index][0], array[color.Index][1], array[color.Index][2]);
			}
			bool visible = layer2.IsOn && (layer2.Flags & LayerFlags.Frozen) == 0;
			string lineTypeName = null;
			if (layer2.LineType != null)
			{
				lineTypeName = (_0023_003Dzr0vuHde1OVHk.Contains(layer2.LineType.Name) ? layer2.LineType.Name : null);
			}
			Layer layer = new Layer(layer2.Name, color2, lineTypeName, _0023_003DznZ_0024c4UJBVHLK3svo29coD_0024wi12Ua(layer2.LineWeight), visible, (layer2.Flags & LayerFlags.Locked) != 0);
			if (_0023_003DzBSmc6k0_003D)
			{
				layer.XRefName = _0023_003DzUPTg1DPlXSwL;
			}
			if (layer2.ExtendedData != null)
			{
				List<KeyValuePair<short, object>> list = _0023_003DzFXVV5876DzAvpbgquA_003D_003D(layer2.ExtendedData);
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
	}

	private int _0023_003DzZpG9HHAj6jU6(ACadSharp.Tables.Layer _0023_003DztIaJjPw_003D)
	{
		int result = 255;
		if (_0023_003DztIaJjPw_003D.ExtendedData.TryGet(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000135), out var value))
		{
			for (int i = 0; i < value.Records.Count; i++)
			{
				if (value.Records[i].Code == DxfCode.ExtendedDataInteger32 && value.Records[i].RawValue != null)
				{
					result = Transparency.FromAlphaValue((int)value.Records[i].RawValue).Value;
					return (int)Math.Floor((1.0 - (double)result * 0.01) * 255.0);
				}
			}
		}
		return result;
	}

	private List<KeyValuePair<short, object>> _0023_003DzFXVV5876DzAvpbgquA_003D_003D(ExtendedDataDictionary _0023_003DzPo7kT1laufTn)
	{
		List<KeyValuePair<short, object>> list = new List<KeyValuePair<short, object>>(_0023_003DzPo7kT1laufTn.Count());
		foreach (KeyValuePair<AppId, ExtendedData> item in _0023_003DzPo7kT1laufTn)
		{
			if (short.TryParse(item.Key.Name, out var result))
			{
				list.Add(new KeyValuePair<short, object>(result, item.Value));
			}
			else
			{
				AppendToLog(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004066), item.Key));
			}
		}
		return list;
	}

	private void _0023_003DzVXwZYbg_003D(ReadEntityData _0023_003DzELu0Pss_003D, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		int num = _0023_003DzELu0Pss_003D.dxfDoc.Layouts.Count();
		for (int i = 0; i < num; i++)
		{
			Layout layout = _0023_003DzELu0Pss_003D.dxfDoc.Layouts.ElementAt(i);
			if (layout == null)
			{
				continue;
			}
			BlockRecord associatedBlock = layout.AssociatedBlock;
			if (associatedBlock.Name.TrimStart('*').ToUpper() == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000073))
			{
				continue;
			}
			string name = layout.Name;
			_ = layout.PaperSize;
			double num2 = layout.PaperWidth;
			double num3 = layout.PaperHeight;
			double num4 = layout.UnprintableMargin.Left;
			double num5 = layout.UnprintableMargin.Bottom;
			XYZ origin = layout.Origin;
			double num6 = origin.X;
			double num7 = origin.Y;
			XY paperImageOrigin = layout.PaperImageOrigin;
			PlotRotation paperRotation = layout.PaperRotation;
			if (paperRotation == PlotRotation.Degrees90 || paperRotation == PlotRotation.Degrees270)
			{
				double num8 = num2;
				num2 = num3;
				num3 = num8;
				double num9 = num4;
				num4 = num5;
				num5 = num9;
				double num10 = num6;
				num6 = num7;
				num7 = num10;
			}
			linearUnitsType linearUnitsType2 = ((layout.PaperUnits == PlotPaperUnits.Inches) ? linearUnitsType.Inches : linearUnitsType.Millimeters);
			if (linearUnitsType2 == linearUnitsType.Inches)
			{
				double linearUnitsConversionFactor = Utility.GetLinearUnitsConversionFactor(linearUnitsType.Millimeters, linearUnitsType2);
				num2 *= linearUnitsConversionFactor;
				num3 *= linearUnitsConversionFactor;
				num4 *= linearUnitsConversionFactor;
				num5 *= linearUnitsConversionFactor;
				num6 *= linearUnitsConversionFactor;
				num7 *= linearUnitsConversionFactor;
				paperImageOrigin *= linearUnitsConversionFactor;
			}
			double num11 = (_0023_003DzELu0Pss_003D.layoutPlotScale = layout.PrintScale);
			Vector3D vector3D = new Vector3D(num4 + num6, num5 + num7, 0.0);
			Vector3D vector3D2 = new Vector3D(paperImageOrigin.X * num11, paperImageOrigin.Y * num11);
			Vector3D vector3D3 = vector3D + vector3D2;
			Transformation transformation = new Translation(vector3D3) * new Scaling(num11);
			PlotTransformations.Add(name, transformation);
			Sheet sheet = (_0023_003DzELu0Pss_003D.sheet = new Sheet(linearUnitsType2, num2, num3, name, angleProjectionType.FirstAngle));
			_0023_003DzELu0Pss_003D._0023_003DzkabH3a5uOAQQ8hRWIg_003D_003D = layout.Viewport;
			List<devDept.Eyeshot.Entities.Entity> list = new List<devDept.Eyeshot.Entities.Entity>();
			_0023_003DzfOBDTtTFrTm5(associatedBlock, list, _0023_003DzAZT6BTk_003D, _0023_003Dz0Jn_0024JRQ_003D, _0023_003DzELu0Pss_003D, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
			foreach (devDept.Eyeshot.Entities.Entity item in list)
			{
				_0023_003Dzu_0024TNsbNoY0XE(item, _0023_003DzELu0Pss_003D);
				if (item is devDept.Eyeshot.Entities.View view)
				{
					view.X += vector3D3.X;
					view.Y += vector3D3.Y;
					continue;
				}
				item.TransformBy(transformation);
				if (item is devDept.Eyeshot.Entities.Dimension dimension)
				{
					dimension.LinearScale /= num11;
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

	private void _0023_003Dzu_0024TNsbNoY0XE(devDept.Eyeshot.Entities.Entity _0023_003Dzs_0024uS8LA_003D, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		if (_0023_003Dzs_0024uS8LA_003D.LineTypeName != null && !base.DrawingLineTypes.Contains(_0023_003Dzs_0024uS8LA_003D.LineTypeName))
		{
			base.DrawingLineTypes.Add((LineType)_0023_003DzELu0Pss_003D.importedLinetypes[_0023_003Dzs_0024uS8LA_003D.LineTypeName].Clone());
		}
		if (_0023_003Dzs_0024uS8LA_003D is devDept.Eyeshot.Entities.Hatch { IsUserDefinedPattern: false } hatch && !hatch.PatternName.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970485)) && !base.DrawingHatchPatterns.Contains(hatch.PatternName))
		{
			base.DrawingHatchPatterns.Add((HatchPattern)base.HatchPatterns[hatch.PatternName].Clone());
		}
		else if (_0023_003Dzs_0024uS8LA_003D is Text text && !string.IsNullOrEmpty(text.StyleName) && !base.DrawingTextStyles.Contains(text.StyleName))
		{
			base.DrawingTextStyles.Add((TextStyle)_0023_003DzELu0Pss_003D.importedTextStyles[text.StyleName].Clone());
		}
		else if (_0023_003Dzs_0024uS8LA_003D is Table table)
		{
			for (int i = 0; i < table.RowsNum; i++)
			{
				for (int j = 0; j < table.ColumnsNum; j++)
				{
					string styleName = table.GetStyleName(i, j);
					if (!string.IsNullOrEmpty(styleName) && !base.DrawingTextStyles.Contains(styleName))
					{
						base.DrawingTextStyles.Add((TextStyle)_0023_003DzELu0Pss_003D.importedTextStyles[styleName].Clone());
					}
				}
			}
		}
		if (!base.DrawingLayers.Contains(_0023_003Dzs_0024uS8LA_003D.LayerName))
		{
			Layer layer = base.Layers[_0023_003Dzs_0024uS8LA_003D.LayerName];
			base.DrawingLayers.Add((Layer)layer.Clone());
			if (layer.LineTypeName != null && !base.DrawingLineTypes.Contains(layer.LineTypeName))
			{
				base.DrawingLineTypes.Add((LineType)_0023_003DzELu0Pss_003D.importedLinetypes[layer.LineTypeName].Clone());
			}
		}
		if (!(_0023_003Dzs_0024uS8LA_003D is BlockReference blockReference))
		{
			return;
		}
		foreach (KeyValuePair<string, AttributeReference> attribute in blockReference.Attributes)
		{
			AttributeReference value = attribute.Value;
			if (value.LineTypeName != null && !base.DrawingLineTypes.Contains(value.LineTypeName))
			{
				base.DrawingLineTypes.Add((LineType)_0023_003DzELu0Pss_003D.importedLinetypes[value.LineTypeName].Clone());
			}
			if (!string.IsNullOrEmpty(value.StyleName) && !base.DrawingTextStyles.Contains(value.StyleName))
			{
				base.DrawingTextStyles.Add((TextStyle)_0023_003DzELu0Pss_003D.importedTextStyles[value.StyleName].Clone());
			}
			if (!base.DrawingLayers.Contains(value.LayerName))
			{
				base.DrawingLayers.Add((Layer)base.Layers[value.LayerName].Clone());
			}
		}
		_0023_003DzlT8V84X_AO1t(blockReference, _0023_003DzELu0Pss_003D);
	}

	private void _0023_003DzlT8V84X_AO1t(BlockReference _0023_003Dz5I3b_GM_003D, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		if (!_0023_003DzELu0Pss_003D.importedBlocks.TryGetValue(_0023_003Dz5I3b_GM_003D.BlockName, out var value))
		{
			return;
		}
		if (!base.DrawingBlocks.Contains(value.Name))
		{
			base.DrawingBlocks.Add((Block)value.Clone());
		}
		foreach (devDept.Eyeshot.Entities.Entity entity in value.Entities)
		{
			_0023_003Dzu_0024TNsbNoY0XE(entity, _0023_003DzELu0Pss_003D);
		}
	}

	private void _0023_003DzwXaUSxTMziQA(CadDocument _0023_003DzgMQGXTZ6Jdhs)
	{
		VPort vPort = _0023_003DzgMQGXTZ6Jdhs.Layouts.FirstOrDefault((Layout _0023_003DzGcl_0024E9o_003D) => _0023_003DzGcl_0024E9o_003D.Document.VPorts != null)?.Document.VPorts.FirstOrDefault() ?? _0023_003DzgMQGXTZ6Jdhs.VPorts?.FirstOrDefault();
		if (vPort == null)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004059));
			return;
		}
		_0023_003DzAbd0a0sUY4t0eHwgcQ_003D_003D._0023_003DziWEQWvc_003D = _0023_003DzlvGiL_QdgBbL(vPort.Direction);
		_0023_003DzAbd0a0sUY4t0eHwgcQ_003D_003D._0023_003DziWEQWvc_003D.Normalize();
		Transformation.AutocadOCS(_0023_003DzAbd0a0sUY4t0eHwgcQ_003D_003D._0023_003DziWEQWvc_003D, out var xAxis, out var yAxis);
		yAxis.TransformBy(new Rotation(0.0 - vPort.TwistAngle, _0023_003DzAbd0a0sUY4t0eHwgcQ_003D_003D._0023_003DziWEQWvc_003D));
		_0023_003DzAbd0a0sUY4t0eHwgcQ_003D_003D._0023_003DzG5DcWQMkTDXTkYfv5A_003D_003D = vPort.LensLength;
		_0023_003DzAbd0a0sUY4t0eHwgcQ_003D_003D._0023_003DzYUMqwZQ_003D = vPort.Direction.Dimension;
		_0023_003DzAbd0a0sUY4t0eHwgcQ_003D_003D._0023_003Dzzo8RvXc_003D = new Point3D(_0023_003Dzh4Wf7tlUUlDt(vPort.Target)) + vPort.Center.X * xAxis + vPort.Center.Y * yAxis;
		_0023_003DzAbd0a0sUY4t0eHwgcQ_003D_003D._0023_003DzCBEAoWM_003D = new Vector3D(yAxis.ToArray());
		_0023_003DzAbd0a0sUY4t0eHwgcQ_003D_003D._0023_003Dzbl24fQDH5pP9 = projectionType.Orthographic;
		_0023_003DzAbd0a0sUY4t0eHwgcQ_003D_003D._0023_003DzeYC4yc0gvh69 = new SizeF((float)vPort.ViewHeight, (float)vPort.ViewHeight);
	}

	private TextStyle _0023_003Dz6ZIsoVdTO_jk90za3Vza19TgahMi(ACadSharp.Tables.TextStyle _0023_003DzfsiK9NAOE8Zq, string _0023_003DzUPTg1DPlXSwL)
	{
		fontStyle fontStyle2 = fontStyle.Regular;
		string text = null;
		if (_0023_003DzfsiK9NAOE8Zq.ExtendedData.TryGet(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003763), out var value))
		{
			for (int i = 0; i < value.Records.Count; i++)
			{
				if (value.Records[i].Code == DxfCode.ExtendedDataAsciiString)
				{
					text = (string)value.Records[i].RawValue;
				}
			}
		}
		if ((_0023_003DzfsiK9NAOE8Zq.TrueType & FontFlags.Bold) != FontFlags.Regular)
		{
			fontStyle2 |= fontStyle.Bold;
		}
		if ((_0023_003DzfsiK9NAOE8Zq.TrueType & FontFlags.Italic) != FontFlags.Regular)
		{
			fontStyle2 |= fontStyle.Italic;
		}
		return new TextStyle(_0023_003DzfsiK9NAOE8Zq.Name, text, fontStyle2, _0023_003DzfsiK9NAOE8Zq.Width)
		{
			FileName = (string.IsNullOrEmpty(text) ? _0023_003DzfsiK9NAOE8Zq.Filename : null),
			XRefName = _0023_003DzUPTg1DPlXSwL
		};
	}

	private void _0023_003Dz_WPSEfrCWp3R(CadDocument _0023_003DzzNwbNAz1GMVr, ReadEntityData _0023_003DzELu0Pss_003D, Dictionary<string, string> _0023_003Dz47HBQmYeh1Ai, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		BlockRecordsTable blockRecords = _0023_003DzzNwbNAz1GMVr.BlockRecords;
		int num = 0;
		int num2 = 0;
		if (string.IsNullOrEmpty(_0023_003DzELu0Pss_003D.xrefPrefix))
		{
			num2 = blockRecords.Count;
		}
		foreach (BlockRecord item in blockRecords)
		{
			num++;
			string text = item.Name.TrimStart('*');
			if (text.ToUpper() == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000073) || text.ToUpper().StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000840)))
			{
				continue;
			}
			string text2 = _0023_003DzELu0Pss_003D.xrefPrefix + text;
			string text3 = text;
			if (_0023_003DzELu0Pss_003D.importedBlocks.Contains(text2))
			{
				if (_0023_003DzELu0Pss_003D.duplicatedBlockNamesConversionTable.ContainsKey(text2))
				{
					continue;
				}
				text3 = Utility.GetUnusedBlockName(text2, _0023_003DzELu0Pss_003D.importedBlocks).Substring(_0023_003DzELu0Pss_003D.xrefPrefix.Length);
				_0023_003DzELu0Pss_003D.duplicatedBlockNamesConversionTable.Add(text2, text3);
			}
			_0023_003DzKu_0024hv_0024Sj4CMJ(_0023_003DzzNwbNAz1GMVr, item, text3, _0023_003DzELu0Pss_003D, _0023_003Dz47HBQmYeh1Ai, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
			if (_0023_003Dz_0024Fk5VPw_003D)
			{
				break;
			}
			if (!UpdateProgressAndCheckCancelled(num, num2, base.ParsingBlocksText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
			{
				_0023_003Dz_0024Fk5VPw_003D = true;
				break;
			}
			if (num == num2)
			{
				break;
			}
		}
		UpdateProgressTo100(base.ParsingBlocksText, _0023_003DzmHS7frs_003D);
	}

	private void _0023_003DzfOBDTtTFrTm5(BlockRecord _0023_003Dz01mUWES9Hyus, List<devDept.Eyeshot.Entities.Entity> _0023_003DzuAKPwfU_003D, Point3D _0023_003DzF7v9r2A_003D, Point3D _0023_003Dz8dK2uhU_003D, ReadEntityData _0023_003DzELu0Pss_003D, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		int num = 0;
		if (string.IsNullOrEmpty(_0023_003DzELu0Pss_003D.xrefPrefix))
		{
			num = _0023_003Dz01mUWES9Hyus.Entities.Count;
		}
		int num2 = num;
		num = 0;
		foreach (ACadSharp.Entities.Entity entity in _0023_003Dz01mUWES9Hyus.Entities)
		{
			if (LayersToLoad == null || LayersToLoad.Contains(entity.Layer.Name))
			{
				IEnumerable<devDept.Eyeshot.Entities.Entity> enumerable = _0023_003Dz3u_0Ozo_003D(entity, _0023_003DzELu0Pss_003D);
				if (enumerable != null)
				{
					_0023_003DzuAKPwfU_003D.AddRange(enumerable);
				}
				if (!UpdateProgressAndCheckCancelled(++num, num2, base.ParsingEntitiesText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
				{
					_0023_003Dz_0024Fk5VPw_003D = true;
					break;
				}
			}
		}
		UpdateProgressTo100(base.ParsingEntitiesText, _0023_003DzmHS7frs_003D);
	}

	internal static linearUnitsType _0023_003Dz8xTAk74d3tW9uU39Bg_003D_003D(UnitsType _0023_003Dzk5tMGRZ53Ii_Tafrlw_003D_003D)
	{
		return _0023_003Dzk5tMGRZ53Ii_Tafrlw_003D_003D switch
		{
			UnitsType.Unitless => linearUnitsType.Unitless, 
			UnitsType.Inches => linearUnitsType.Inches, 
			UnitsType.Feet => linearUnitsType.Feet, 
			UnitsType.Miles => linearUnitsType.Miles, 
			UnitsType.Millimeters => linearUnitsType.Millimeters, 
			UnitsType.Centimeters => linearUnitsType.Centimeters, 
			UnitsType.Meters => linearUnitsType.Meters, 
			UnitsType.Kilometers => linearUnitsType.Kilometers, 
			UnitsType.Microinches => linearUnitsType.Microinches, 
			UnitsType.Mils => linearUnitsType.Mils, 
			UnitsType.Yards => linearUnitsType.Yards, 
			UnitsType.Angstroms => linearUnitsType.Angstroms, 
			UnitsType.Nanometers => linearUnitsType.Nanometers, 
			UnitsType.Microns => linearUnitsType.Microns, 
			UnitsType.Decimeters => linearUnitsType.Decimeters, 
			UnitsType.Decameters => linearUnitsType.Decameters, 
			UnitsType.Hectometers => linearUnitsType.Hectometers, 
			UnitsType.Gigameters => linearUnitsType.Gigameters, 
			UnitsType.AstronomicalUnits => linearUnitsType.Astronomical, 
			UnitsType.LightYears => linearUnitsType.LightYears, 
			UnitsType.Parsecs => linearUnitsType.Parsecs, 
			UnitsType.USSurveyFeet => linearUnitsType.Feet, 
			UnitsType.USSurveyInches => linearUnitsType.Inches, 
			UnitsType.USSurveyYards => linearUnitsType.Yards, 
			UnitsType.USSurveyMiles => linearUnitsType.Miles, 
			_ => linearUnitsType.NotSupported, 
		};
	}

	private void _0023_003DzKu_0024hv_0024Sj4CMJ(CadDocument _0023_003DzzNwbNAz1GMVr, BlockRecord _0023_003DzLeyHB00_003D, string _0023_003DznkMU43c_003D, ReadEntityData _0023_003DzELu0Pss_003D, Dictionary<string, string> _0023_003Dz47HBQmYeh1Ai, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		double[] coords = _0023_003Dzh4Wf7tlUUlDt(_0023_003DzLeyHB00_003D.BlockEntity.BasePoint);
		string text = _0023_003DzELu0Pss_003D.xrefPrefix + _0023_003DznkMU43c_003D;
		Block block = new Block(text, new Point3D(coords));
		block.Description = _0023_003DzLeyHB00_003D.BlockEntity.Comments;
		block.Units = _0023_003Dz8xTAk74d3tW9uU39Bg_003D_003D(_0023_003DzLeyHB00_003D.Units);
		if ((_0023_003DzLeyHB00_003D.Flags & BlockTypeFlags.Anonymous) != BlockTypeFlags.None)
		{
			block.BlockSource = autodeskSourceType.Anonymous;
		}
		block._exportMode = (((_0023_003DzLeyHB00_003D.Flags & BlockTypeFlags.XRef) != BlockTypeFlags.None) ? autodeskExportType.ExternalReference : autodeskExportType.Embedded);
		if (block.ExportMode == autodeskExportType.ExternalReference)
		{
			string xRefPath = _0023_003DzLeyHB00_003D.BlockEntity.XRefPath;
			string fileName = System.IO.Path.GetFileName(xRefPath);
			if (_0023_003Dzi1RitS6Kazvm.Contains(fileName) || SkipExternalReferences)
			{
				return;
			}
			_0023_003Dzi1RitS6Kazvm.Add(fileName);
			string text2 = fileName;
			if (!File.Exists(text2))
			{
				if (!string.IsNullOrEmpty(base.Path))
				{
					text2 = _0023_003DzHg_0024BPP4dJ1M_YPc_0024U3Hw5iGNjzzwMvEg8YR8GcmF6Kn6._0023_003Dz1iP7XTo_003D(base.Path, new string[1] { xRefPath });
				}
				if (!File.Exists(text2) && SearchFolders != null)
				{
					for (int i = 0; i < SearchFolders.Count; i++)
					{
						text2 = _0023_003DzHg_0024BPP4dJ1M_YPc_0024U3Hw5iGNjzzwMvEg8YR8GcmF6Kn6._0023_003Dz1iP7XTo_003D(SearchFolders[i], new string[1] { fileName });
						if (!File.Exists(text2))
						{
							break;
						}
					}
				}
			}
			if (File.Exists(text2))
			{
				CadDocument cadDocument = new CadDocument();
				cadDocument = new DxfReader(text2).Read();
				string text3 = _0023_003DznkMU43c_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942697);
				BlockKeyedCollection _0023_003Dza0EiICLV_0024jmu;
				TextStyleKeyedCollection _0023_003DzUkGYUZOWpxG;
				LineTypeKeyedCollection _0023_003Dzr0vuHde1OVHk;
				float _0023_003Dz8oMsDcyNkuDg;
				Point3D _0023_003DzF7v9r2A_003D;
				Point3D _0023_003Dz8dK2uhU_003D;
				IEnumerable<devDept.Eyeshot.Entities.Entity> collection = _0023_003DzbezkkWk_003D(text3, _0023_003DzELu0Pss_003D.duplicatedBlockNamesConversionTable, cadDocument, _0023_003Dz47HBQmYeh1Ai, out _0023_003Dza0EiICLV_0024jmu, out _0023_003DzUkGYUZOWpxG, out _0023_003Dzr0vuHde1OVHk, out _0023_003Dz8oMsDcyNkuDg, out _0023_003DzF7v9r2A_003D, out _0023_003Dz8dK2uhU_003D, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
				if (_0023_003Dz_0024Fk5VPw_003D)
				{
					return;
				}
				block.Entities.AddRange(collection);
				block._filePath = xRefPath;
				if (!string.IsNullOrEmpty(_0023_003DzELu0Pss_003D.xrefPrefix))
				{
					block.XRefName = _0023_003DzELu0Pss_003D.xrefPrefix.Substring(0, _0023_003DzELu0Pss_003D.xrefPrefix.Length - 1);
				}
				foreach (Block item in _0023_003Dza0EiICLV_0024jmu)
				{
					if (!_0023_003DzELu0Pss_003D.importedBlocks.Contains(item.Name))
					{
						_0023_003DzELu0Pss_003D.importedBlocks.Add(item);
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
				_0023_003DzD_b88_0024aSBUyV(_0023_003DzUkGYUZOWpxG, _0023_003DzELu0Pss_003D.importedTextStyles);
				_0023_003DzD_b88_0024aSBUyV(_0023_003Dzr0vuHde1OVHk, _0023_003DzELu0Pss_003D.importedLinetypes);
			}
			else if (!_0023_003Dz47HBQmYeh1Ai.ContainsKey(text))
			{
				_0023_003Dz47HBQmYeh1Ai.Add(text, xRefPath);
			}
		}
		else
		{
			Block currentBlock = _0023_003DzELu0Pss_003D.currentBlock;
			_0023_003DzELu0Pss_003D.currentBlock = block;
			_0023_003DzOI_VfczqNrG7(_0023_003DzLeyHB00_003D, _0023_003DzELu0Pss_003D);
			_0023_003DzELu0Pss_003D.currentBlock = currentBlock;
		}
		block.IsResolved = (_0023_003DzLeyHB00_003D.Flags & BlockTypeFlags.XRefResolved) != 0;
		if ((block.ExportMode == autodeskExportType.Embedded || block.IsResolved) && !string.IsNullOrEmpty(text) && !_0023_003DzELu0Pss_003D.importedBlocks.Contains(text))
		{
			_0023_003DzELu0Pss_003D.importedBlocks.Add(block);
		}
	}

	private void _0023_003DzOI_VfczqNrG7(BlockRecord _0023_003DzLeyHB00_003D, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		foreach (ACadSharp.Entities.Entity entity in _0023_003DzLeyHB00_003D.Entities)
		{
			IEnumerable<devDept.Eyeshot.Entities.Entity> enumerable = _0023_003Dz3u_0Ozo_003D(entity, _0023_003DzELu0Pss_003D);
			if (enumerable != null)
			{
				_0023_003DzELu0Pss_003D.currentBlock.Entities.AddRange(enumerable);
			}
		}
	}

	private protected virtual IEnumerable<devDept.Eyeshot.Entities.Entity> _0023_003Dz3u_0Ozo_003D(ACadSharp.Entities.Entity _0023_003DzfpN7pnryJplL, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		List<devDept.Eyeshot.Entities.Entity> list = new List<devDept.Eyeshot.Entities.Entity>();
		devDept.Eyeshot.Entities.Entity entity = null;
		if (LayersToLoad != null && !LayersToLoad.Contains(_0023_003DzfpN7pnryJplL.Layer.Name))
		{
			return list;
		}
		try
		{
			if (!(_0023_003DzfpN7pnryJplL is ACadSharp.Entities.Point))
			{
				if (!(_0023_003DzfpN7pnryJplL is ACadSharp.Entities.Line))
				{
					if (!(_0023_003DzfpN7pnryJplL is XLine))
					{
						if (!(_0023_003DzfpN7pnryJplL is ACadSharp.Entities.Arc))
						{
							if (!(_0023_003DzfpN7pnryJplL is ACadSharp.Entities.Circle))
							{
								if (!(_0023_003DzfpN7pnryJplL is ACadSharp.Entities.Ellipse))
								{
									if (!(_0023_003DzfpN7pnryJplL is AttributeEntity))
									{
										if (!(_0023_003DzfpN7pnryJplL is AttributeDefinition))
										{
											if (!(_0023_003DzfpN7pnryJplL is TextEntity))
											{
												if (!(_0023_003DzfpN7pnryJplL is MText))
												{
													if (!(_0023_003DzfpN7pnryJplL is ACadSharp.Entities.Leader))
													{
														if (!(_0023_003DzfpN7pnryJplL is LwPolyline) && !(_0023_003DzfpN7pnryJplL is Polyline2D))
														{
															if (!(_0023_003DzfpN7pnryJplL is Polyline3D))
															{
																if (!(_0023_003DzfpN7pnryJplL is Spline))
																{
																	if (!(_0023_003DzfpN7pnryJplL is Face3D))
																	{
																		if (!(_0023_003DzfpN7pnryJplL is PolyfaceMesh))
																		{
																			if (!(_0023_003DzfpN7pnryJplL is Insert))
																			{
																				if (!(_0023_003DzfpN7pnryJplL is DimensionAligned _0023_003Dzow04lCuzeeUF))
																				{
																					if (!(_0023_003DzfpN7pnryJplL is DimensionOrdinate _0023_003Dzow04lCuzeeUF2))
																					{
																						if (!(_0023_003DzfpN7pnryJplL is DimensionRadius _0023_003Dzow04lCuzeeUF3))
																						{
																							if (!(_0023_003DzfpN7pnryJplL is DimensionDiameter _0023_003Dzow04lCuzeeUF4))
																							{
																								if (!(_0023_003DzfpN7pnryJplL is DimensionAngular3Pt _0023_003Dzow04lCuzeeUF5))
																								{
																									if (!(_0023_003DzfpN7pnryJplL is DimensionAngular2Line _0023_003Dzow04lCuzeeUF6))
																									{
																										if (!(_0023_003DzfpN7pnryJplL is ACadSharp.Entities.Solid))
																										{
																											if (!(_0023_003DzfpN7pnryJplL is MLine))
																											{
																												if (!(_0023_003DzfpN7pnryJplL is ACadSharp.Entities.Hatch))
																												{
																													if (!(_0023_003DzfpN7pnryJplL is Wipeout))
																													{
																														if (!(_0023_003DzfpN7pnryJplL is RasterImage))
																														{
																															if (!(_0023_003DzfpN7pnryJplL is Viewport))
																															{
																																if (!(_0023_003DzfpN7pnryJplL is ACadSharp.Entities.Mesh _0023_003DzmOGZ1mt5Embrff5clA_003D_003D))
																																{
																																	if (_0023_003DzfpN7pnryJplL is ACadSharp.Entities.Region _0023_003DzfpN7pnryJplL2)
																																	{
																																		entity = _0023_003DzlmftVwI_003D(_0023_003DzfpN7pnryJplL2, _0023_003DzELu0Pss_003D);
																																	}
																																	else
																																	{
																																		log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001030), _0023_003DzfpN7pnryJplL.GetType(), _0023_003DzfpN7pnryJplL.Handle));
																																	}
																																}
																																else
																																{
																																	entity = _0023_003DzMjyFtqiji3qL(_0023_003DzmOGZ1mt5Embrff5clA_003D_003D, _0023_003DzELu0Pss_003D);
																																}
																															}
																															else
																															{
																																entity = _0023_003DzrhdupuI_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
																															}
																														}
																														else
																														{
																															entity = _0023_003DzlnkplwW5eb4jKSLHlA_003D_003D((RasterImage)_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D, log);
																														}
																													}
																													else
																													{
																														log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001030), _0023_003DzfpN7pnryJplL.GetType(), _0023_003DzfpN7pnryJplL.Handle));
																													}
																												}
																												else
																												{
																													entity = _0023_003DzDRBMPy0_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
																												}
																											}
																											else
																											{
																												List<devDept.Eyeshot.Entities.Entity> list2 = _0023_003Dz047xcxuVWS6B(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
																												if (list2 != null && list2.Count > 0)
																												{
																													foreach (devDept.Eyeshot.Entities.Entity item in list2)
																													{
																														item.TranslationID = new TranslationIdentifier(_0023_003DzfpN7pnryJplL.Handle);
																													}
																													list.AddRange(list2);
																												}
																											}
																										}
																										else
																										{
																											entity = _0023_003Dz1vzybyo_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D, log);
																										}
																									}
																									else
																									{
																										entity = _0023_003DzOLOdi926iMAO4DSdUNx4mF0_003D(_0023_003Dzow04lCuzeeUF6, _0023_003DzELu0Pss_003D);
																									}
																								}
																								else
																								{
																									entity = _0023_003DzyXtdDh_3bSdUtCBHlX3aq10_003D(_0023_003Dzow04lCuzeeUF5, _0023_003DzELu0Pss_003D);
																								}
																							}
																							else
																							{
																								entity = _0023_003DzuRzGetAm14NIaaQeYNyCkHE_003D(_0023_003Dzow04lCuzeeUF4, _0023_003DzELu0Pss_003D);
																							}
																						}
																						else
																						{
																							entity = _0023_003DznW93rAUBvf38(_0023_003Dzow04lCuzeeUF3, _0023_003DzELu0Pss_003D);
																						}
																					}
																					else
																					{
																						entity = _0023_003DzoOHtxsENBiu8bEHdgg_003D_003D(_0023_003Dzow04lCuzeeUF2, _0023_003DzELu0Pss_003D);
																					}
																				}
																				else
																				{
																					entity = _0023_003DzB8B0nHKDPlI6(_0023_003Dzow04lCuzeeUF, _0023_003DzELu0Pss_003D);
																				}
																			}
																			else
																			{
																				entity = _0023_003DzTV0E4RQU4BKB(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
																			}
																		}
																		else
																		{
																			entity = _0023_003DzfLPBio4Tv0xc(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
																		}
																	}
																	else
																	{
																		entity = _0023_003Dzg4ddAVY_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
																	}
																}
																else
																{
																	entity = _0023_003Dzl6LkJd4_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
																}
															}
															else
															{
																entity = _0023_003DzT7JvkYG2_e5DlNpugQ_003D_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
															}
														}
														else
														{
															entity = _0023_003DzUc1T0QlYOb0H29091w_003D_003D((IPolyline)_0023_003DzfpN7pnryJplL, 3, _0023_003DzELu0Pss_003D);
														}
													}
													else
													{
														entity = _0023_003DzkLREJtM_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
													}
												}
												else
												{
													entity = _0023_003DzDYm8KNE_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
												}
											}
											else
											{
												entity = _0023_003Dzfpt8uoA_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
											}
										}
										else
										{
											entity = _0023_003DzpMg88rY7dqeU(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
										}
									}
									else
									{
										entity = _0023_003DzCGAW_0024kk_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
									}
								}
								else
								{
									entity = _0023_003DzHBlwxd8_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
								}
							}
							else
							{
								entity = _0023_003Dzbp0VrpRnjEGL(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
							}
						}
						else
						{
							entity = _0023_003DzNc2BB00_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
						}
					}
					else
					{
						entity = _0023_003Dz_00249dhb4DTUG2p(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
					}
				}
				else
				{
					entity = _0023_003DzcvG8EU4_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
				}
			}
			else
			{
				entity = _0023_003DzYW8_fbk_003D(_0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
			}
			if (entity != null)
			{
				if (entity.TranslationID == null)
				{
					entity.TranslationID = new TranslationIdentifier(_0023_003DzfpN7pnryJplL.Handle);
				}
				list.Add(entity);
			}
		}
		catch (Exception ex)
		{
			log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000991), _0023_003DzfpN7pnryJplL.GetType(), _0023_003DzfpN7pnryJplL.Handle));
			log.AppendLine(ex.Message);
		}
		return list;
	}

	private devDept.Eyeshot.Entities.Entity _0023_003DzFtZzkWs_003D(ACadSharp.Entities.Entity _0023_003DzfpN7pnryJplL, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		throw new NotImplementedException();
	}

	private devDept.Eyeshot.Entities.Entity _0023_003DzrhdupuI_003D(ACadSharp.Entities.Entity _0023_003DzfpN7pnryJplL, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		if (_0023_003DzELu0Pss_003D._0023_003DzkabH3a5uOAQQ8hRWIg_003D_003D == null || _0023_003DzELu0Pss_003D._0023_003DzkabH3a5uOAQQ8hRWIg_003D_003D.Equals(_0023_003DzfpN7pnryJplL))
		{
			return null;
		}
		Viewport viewport = (Viewport)_0023_003DzfpN7pnryJplL;
		_0023_003Dz62alrNM_003D _0023_003Dz62alrNM_003D2 = default(_0023_003Dz62alrNM_003D);
		_0023_003Dz62alrNM_003D2._0023_003DziWEQWvc_003D = new Vector3D(_0023_003DzdZJdWj61QN4u(viewport.ViewDirection));
		_0023_003Dz62alrNM_003D2._0023_003DziWEQWvc_003D.Normalize();
		Transformation.AutocadOCS(_0023_003Dz62alrNM_003D2._0023_003DziWEQWvc_003D, out var xAxis, out var yAxis);
		yAxis.TransformBy(new Rotation(0.0 - viewport.TwistAngle, _0023_003Dz62alrNM_003D2._0023_003DziWEQWvc_003D));
		_0023_003Dz62alrNM_003D2._0023_003DzG5DcWQMkTDXTkYfv5A_003D_003D = viewport.LensLength;
		_0023_003Dz62alrNM_003D2._0023_003DzYUMqwZQ_003D = viewport.ViewDirection.Dimension;
		_0023_003Dz62alrNM_003D2._0023_003Dzzo8RvXc_003D = new Point3D(_0023_003Dzh4Wf7tlUUlDt(viewport.ViewTarget)) + viewport.ViewCenter.X * xAxis + viewport.ViewCenter.Y * yAxis;
		_0023_003Dz62alrNM_003D2._0023_003DzCBEAoWM_003D = new Vector3D(yAxis.ToArray());
		_0023_003Dz62alrNM_003D2._0023_003Dzbl24fQDH5pP9 = projectionType.Orthographic;
		double width = viewport.Width;
		double height = viewport.Height;
		_0023_003Dz62alrNM_003D2._0023_003DzeYC4yc0gvh69 = new SizeF(100f, 100f);
		Size _0023_003Dz4BrWeV0_003D = new Size(100, 100);
		Camera camera = new Camera();
		_0023_003Dz62alrNM_003D2._0023_003Dzvk_j02M_003D(camera, _0023_003Dz4BrWeV0_003D);
		Point3D point3D = new Point3D(_0023_003Dzh4Wf7tlUUlDt(viewport.Center));
		devDept.Eyeshot.Entities.View view = new VectorView(point3D.X, point3D.Y, camera, 1.0, viewport.ObjectName, width, height);
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(view, _0023_003DzfpN7pnryJplL, _0023_003DzELu0Pss_003D);
		return view;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static string _0023_003DzL45T4VVneDmq(string _0023_003DzAixUVp4_003D)
	{
		return Regex.Replace(_0023_003DzAixUVp4_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003776), (Match _0023_003DzkKfJheA_003D) => char.ConvertFromUtf32(int.Parse(_0023_003DzkKfJheA_003D.Groups[1].Value, NumberStyles.HexNumber)));
	}

	private devDept.Eyeshot.Entities.Entity _0023_003DzDYm8KNE_003D(ACadSharp.Entities.Entity _0023_003DzfpN7pnryJplL, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		MText mText = (MText)_0023_003DzfpN7pnryJplL;
		string _0023_003DzlUfsUzo_003D = _0023_003DzL45T4VVneDmq(mText.Value);
		double height = mText.Height;
		double[] coords = _0023_003Dzh4Wf7tlUUlDt(mText.InsertPoint);
		ReadDWG._0023_003DzzLIUnNo_003D(_0023_003DzlUfsUzo_003D, out var _0023_003DzyIUKu5w_003D, out var _0023_003DzOIz86cBB_0024mgXuDVmhQ_003D_003D, out var _0023_003DzQdxCPUCTIzyF);
		_0023_003DzyIUKu5w_003D[0] = ReadDWG._0023_003DzmD2fQ5da9CZSb36vG_0024I5QCI_003D(_0023_003DzyIUKu5w_003D[0]);
		double lineSpaceDistance = mText.LineSpacing * height * 5.0 / 3.0;
		Text.alignmentType alignment = _0023_003DzchWitWWfcbIf_EiN7Q_003D_003D(mText.AttachmentPoint);
		double num = mText.Rotation;
		Point3D insPoint = new Point3D(coords);
		if ((mText.DrawingDirection & DrawingDirectionType.TopToBottom) == 0)
		{
			num += Math.PI / 2.0;
		}
		Plane plane = ReadDWG._0023_003DztIc79mb2zQ0f(_0023_003DzdZJdWj61QN4u(mText.Normal), 0.0);
		plane.Rotate(num, plane.AxisZ, plane.Origin);
		string text = mText.Style.Name;
		if (!string.IsNullOrEmpty(_0023_003DzQdxCPUCTIzyF))
		{
			string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(_0023_003DzQdxCPUCTIzyF);
			if (!_0023_003DzELu0Pss_003D.importedTextStyles.Contains(fileNameWithoutExtension))
			{
				if (!string.IsNullOrEmpty(_0023_003DzELu0Pss_003D.xrefPrefix))
				{
					_0023_003DzELu0Pss_003D.xrefPrefix.Substring(0, _0023_003DzELu0Pss_003D.xrefPrefix.Length - 1);
				}
				_0023_003DzELu0Pss_003D.importedTextStyles.Add(new TextStyle(fileNameWithoutExtension, string.Empty, fontStyle.Regular)
				{
					FileName = _0023_003DzQdxCPUCTIzyF
				});
			}
			text = fileNameWithoutExtension;
		}
		MultilineText multilineText = new MultilineText(plane, insPoint, ReadDWG._0023_003Dz3lOHLrA_003D(_0023_003DzyIUKu5w_003D[0]), mText.RectangleWidth, height, lineSpaceDistance, alignment, (text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963495)) ? string.Empty : text);
		multilineText.RectHeight = mText.Height;
		multilineText.Contents = mText.Value;
		if (_0023_003DzOIz86cBB_0024mgXuDVmhQ_003D_003D != null)
		{
			multilineText.WidthFactors = _0023_003DzOIz86cBB_0024mgXuDVmhQ_003D_003D;
		}
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(multilineText, mText, _0023_003DzELu0Pss_003D);
		if (multilineText.TextString.Trim().Length > 0)
		{
			return multilineText;
		}
		log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000669), _0023_003DzfpN7pnryJplL.Handle));
		return null;
	}

	private devDept.Eyeshot.Entities.Entity _0023_003DzlnkplwW5eb4jKSLHlA_003D_003D(RasterImage _0023_003DzfpN7pnryJplL, ReadEntityData _0023_003DzELu0Pss_003D, StringBuilder _0023_003DzFdTKfve582KK)
	{
		throw new NotImplementedException();
	}

	private devDept.Eyeshot.Entities.Entity _0023_003DzMjyFtqiji3qL(ACadSharp.Entities.Mesh _0023_003DzmOGZ1mt5Embrff5clA_003D_003D, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		List<int[]> faces = _0023_003DzmOGZ1mt5Embrff5clA_003D_003D.Faces;
		List<XYZ> vertices = _0023_003DzmOGZ1mt5Embrff5clA_003D_003D.Vertices;
		XYZ[] array = new XYZ[0];
		System.Drawing.Color[] array2 = new System.Drawing.Color[0];
		bool flag = array.Length != 0;
		bool flag2 = array2.Length != 0;
		Dictionary<int, int> dictionary = null;
		List<IndexTriangle> list = new List<IndexTriangle>();
		Point3D[] array3;
		if (flag)
		{
			List<Point3D> list2 = new List<Point3D>(vertices.Count);
			Dictionary<Point3D, int> dictionary2 = new Dictionary<Point3D, int>(vertices.Count);
			dictionary = new Dictionary<int, int>();
			for (int i = 0; i < vertices.Count; i++)
			{
				Point3D point3D = _0023_003Dzmq2_arBswhAA(vertices[i]);
				if (!dictionary2.TryGetValue(point3D, out var value))
				{
					list2.Add(point3D);
					value = list2.Count - 1;
					dictionary2.Add(point3D, value);
				}
				dictionary.Add(i, value);
			}
			array3 = list2.ToArray();
		}
		else
		{
			array3 = new Point3D[vertices.Count];
			for (int j = 0; j < vertices.Count; j++)
			{
				Point3D point3D2 = _0023_003Dzmq2_arBswhAA(vertices[j]);
				if (flag2)
				{
					ACadSharp.Color color = _0023_003DzmOGZ1mt5Embrff5clA_003D_003D.Color;
					point3D2 = new PointRGB(point3D2.X, point3D2.Y, point3D2.Z, color.R, color.G, color.B);
				}
				array3[j] = point3D2;
			}
		}
		for (int k = 0; k < faces.Count; k++)
		{
			int[] array4 = faces[k];
			int num = array4.Length;
			switch (num)
			{
			case 3:
				if (flag)
				{
					list.Add(new RichTriangle(dictionary[array4[0]], dictionary[array4[1]], dictionary[array4[2]], array4[0], array4[1], array4[2]));
				}
				else
				{
					list.Add(new IndexTriangle(array4[0], array4[1], array4[2]));
				}
				continue;
			case 4:
				if (flag)
				{
					list.Add(new RichTriangle(dictionary[array4[0]], dictionary[array4[1]], dictionary[array4[2]], array4[0], array4[1], array4[2]));
					list.Add(new RichTriangle(dictionary[array4[0]], dictionary[array4[2]], dictionary[array4[3]], array4[0], array4[2], array4[3]));
				}
				else
				{
					list.Add(new IndexTriangle(array4[0], array4[1], array4[2]));
					list.Add(new IndexTriangle(array4[0], array4[2], array4[3]));
				}
				continue;
			}
			Point3D[] array5 = new Point3D[num + 1];
			int[] array6 = new int[num];
			for (int l = 0; l < num; l++)
			{
				array5[l] = array3[array6[l] = array4[l]];
			}
			array5[num] = (Point3D)array5[0].Clone();
			devDept.Eyeshot.Entities.Mesh mesh = devDept.Eyeshot.Entities.Mesh.CreatePlanar(array5, devDept.Eyeshot.Entities.Mesh.natureType.Plain);
			for (int m = 0; m < mesh.Triangles.Length; m++)
			{
				IndexTriangle indexTriangle = mesh.Triangles[m];
				if (flag)
				{
					list.Add(new RichTriangle(array6[indexTriangle.V1], array6[indexTriangle.V2], array6[indexTriangle.V3], array6[indexTriangle.V1], array6[indexTriangle.V2], array6[indexTriangle.V3]));
				}
				else
				{
					list.Add(new IndexTriangle(array6[indexTriangle.V1], array6[indexTriangle.V2], array6[indexTriangle.V3]));
				}
			}
		}
		if (array3.Length == 0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003735));
		}
		if (list.Count == 0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003709));
		}
		devDept.Eyeshot.Entities.Mesh mesh2 = new devDept.Eyeshot.Entities.Mesh(array3, list);
		if (flag)
		{
			PointF[] array7 = new PointF[array.Length];
			for (int n = 0; n < array.Length; n++)
			{
				XYZ xYZ = array[n];
				array7[n] = new PointF((float)xYZ.X, 0f - (float)xYZ.Y);
			}
			mesh2.TextureCoords = array7;
		}
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(mesh2, _0023_003DzmOGZ1mt5Embrff5clA_003D_003D, _0023_003DzELu0Pss_003D);
		return mesh2;
	}

	private IList<devDept.Eyeshot.Entities.Entity> _0023_003DzLpWyOE7im5SP(ACadSharp.Entities.Entity _0023_003DzfpN7pnryJplL, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		throw new NotImplementedException();
	}

	private devDept.Eyeshot.Entities.Entity _0023_003DzlmftVwI_003D(ACadSharp.Entities.Entity _0023_003DzfpN7pnryJplL, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		throw new NotImplementedException();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static XYZ _0023_003DzGPXnbB1kFi6U(XYZ _0023_003DzCJkr8nY_003D)
	{
		return new XYZ(_0023_003DzCJkr8nY_003D.Y, 0.0 - _0023_003DzCJkr8nY_003D.X, 0.0);
	}

	private List<devDept.Eyeshot.Entities.Entity> _0023_003Dz047xcxuVWS6B(ACadSharp.Entities.Entity _0023_003DzfpN7pnryJplL, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		MLine mLine = (MLine)_0023_003DzfpN7pnryJplL;
		List<devDept.Eyeshot.Entities.Entity> list = new List<devDept.Eyeshot.Entities.Entity>();
		List<MLine.Vertex> vertices = mLine.Vertices;
		if (vertices.Count < 2)
		{
			return list;
		}
		double num = 0.0;
		switch (mLine.Justification)
		{
		case MLineJustification.Top:
			num = (mLine.ScaleFactor * mLine.Style.Elements.FirstOrDefault()?.Offset).GetValueOrDefault();
			break;
		case MLineJustification.Bottom:
			num = (mLine.ScaleFactor * mLine.Style.Elements.LastOrDefault()?.Offset).GetValueOrDefault();
			break;
		}
		foreach (MLineStyle.Element element in mLine.Style.Elements)
		{
			double num2 = num - mLine.ScaleFactor * element.Offset;
			List<XYZ> list2 = new List<XYZ>();
			for (int i = 0; i < vertices.Count; i++)
			{
				XYZ position = vertices[i].Position;
				if (i == 0)
				{
					XYZ xYZ = _0023_003DzGPXnbB1kFi6U(vertices[i].Direction);
					list2.Add(position + xYZ * num2);
					continue;
				}
				if (i == vertices.Count - 1)
				{
					XYZ xYZ2 = _0023_003DzGPXnbB1kFi6U(vertices[i - 1].Direction);
					list2.Add(position + xYZ2 * num2);
					continue;
				}
				XYZ direction = vertices[i - 1].Direction;
				XYZ direction2 = vertices[i].Direction;
				XYZ xYZ3 = _0023_003DzGPXnbB1kFi6U(direction);
				XYZ xYZ4 = _0023_003DzGPXnbB1kFi6U(direction2);
				XYZ xYZ5 = (xYZ3 + xYZ4).Normalize();
				double num3 = Math.Sin(Vector2D.AngleBetween(new Vector2D(xYZ5.X, xYZ5.Y), new Vector2D(direction2.X, direction2.Y)));
				if (Math.Abs(num3) < 1E-09)
				{
					num3 = 1.0;
				}
				list2.Add(position + xYZ5 * (num2 / num3));
			}
			for (int j = 0; j < list2.Count - 1; j++)
			{
				list.Add(_0023_003DzcvG8EU4_003D(new ACadSharp.Entities.Line(list2[j], list2[j + 1])
				{
					Color = element.Color,
					LineType = element.LineType
				}, _0023_003DzELu0Pss_003D));
			}
		}
		return list;
	}

	private devDept.Eyeshot.Entities.Entity _0023_003DzDRBMPy0_003D(ACadSharp.Entities.Entity _0023_003DzfpN7pnryJplL, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		ACadSharp.Entities.Hatch hatch = (ACadSharp.Entities.Hatch)_0023_003DzfpN7pnryJplL;
		Point2D point2D = new Point2D();
		if (hatch.ExtendedData.TryGet(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003763), out var value))
		{
			for (int i = 0; i < value.Records.Count; i++)
			{
				if (value.Records[i].Code == DxfCode.ExtendedDataXCoordinate)
				{
					point2D.X = ((XYZ)value.Records[i].RawValue).X;
					point2D.Y = ((XYZ)value.Records[i].RawValue).Y;
				}
			}
		}
		_ = hatch.Pattern;
		string name = hatch.Pattern.Name;
		if (hatch.PatternType != HatchPatternType.PatternFill && !base.HatchPatterns.Contains(name))
		{
			base.HatchPatterns.Add(_0023_003DzHSqIboHDImSB(name, hatch));
		}
		List<ICurve> list = new List<ICurve>();
		Plane plane = ReadDWG._0023_003DztIc79mb2zQ0f(new double[3]
		{
			hatch.Normal.X,
			hatch.Normal.Y,
			hatch.Normal.Z
		}, hatch.Elevation);
		for (int j = 0; j < hatch.Paths.Count; j++)
		{
			foreach (ACadSharp.Entities.Entity entity3 in hatch.Paths[j].Entities)
			{
				IEnumerable<ICurve> collection = _0023_003Dz3u_0Ozo_003D(entity3, _0023_003DzELu0Pss_003D).Cast<ICurve>();
				list.AddRange(collection);
			}
			if ((hatch.Paths[j].Flags & BoundaryPathFlags.Polyline) != BoundaryPathFlags.Default)
			{
				ACadSharp.Entities.Hatch.BoundaryPath.Polyline _0023_003DzKFOHiHw8_0024GRYx8cFJg_003D_003D = (ACadSharp.Entities.Hatch.BoundaryPath.Polyline)hatch.Paths[j].Edges[0];
				ICurve item = (ICurve)_0023_003DzUc1T0QlYOb0H29091w_003D_003D(_0023_003DzKFOHiHw8_0024GRYx8cFJg_003D_003D, 2, _0023_003DzELu0Pss_003D, plane);
				list.Add(item);
				continue;
			}
			ObservableCollection<ACadSharp.Entities.Hatch.BoundaryPath.Edge> edges = hatch.Paths[j].Edges;
			List<ICurve> list2 = new List<ICurve>();
			foreach (ACadSharp.Entities.Hatch.BoundaryPath.Edge item2 in (IEnumerable<ACadSharp.Entities.Hatch.BoundaryPath.Edge>)edges)
			{
				if (!(item2 is ACadSharp.Entities.Hatch.BoundaryPath.Line line))
				{
					if (!(item2 is ACadSharp.Entities.Hatch.BoundaryPath.Arc arc))
					{
						if (!(item2 is ACadSharp.Entities.Hatch.BoundaryPath.Ellipse ellipse))
						{
							if (!(item2 is ACadSharp.Entities.Hatch.BoundaryPath.Spline spline))
							{
								log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003851), _0023_003DzfpN7pnryJplL.Handle, item2));
								return null;
							}
							Point4D[] array = new Point4D[spline.ControlPoints.Count];
							if (spline.Rational)
							{
								for (int k = 0; k < array.Length; k++)
								{
									XYZ xYZ = spline.ControlPoints[k];
									double num = xYZ[2];
									Point3D point3D = plane.PointAt(xYZ[0], xYZ[1]);
									array[k] = new Point4D(point3D.X * num, point3D.Y * num, point3D.Z * num, num);
								}
							}
							else
							{
								for (int l = 0; l < array.Length; l++)
								{
									XYZ xYZ2 = spline.ControlPoints[l];
									Point3D point3D2 = plane.PointAt(xYZ2[0], xYZ2[1]);
									array[l] = new Point4D(point3D2.X, point3D2.Y, point3D2.Z);
								}
							}
							double[] array2 = new double[spline.Knots.Count];
							for (int m = 0; m < array2.Length; m++)
							{
								array2[m] = spline.Knots[m];
							}
							ReadDWG._0023_003DzlsAvovRYD7jjgMUyL9PP3KRrV9Mi(spline.Degree, array2, array, 0.001, out var _0023_003DzXptaNUPHdku, out var _0023_003DzHZhKOsqm4tXS);
							devDept.Eyeshot.Entities.Entity entity = new Curve(spline.Degree, _0023_003DzXptaNUPHdku.ToArray(), _0023_003DzHZhKOsqm4tXS.ToArray());
							list2.Add((ICurve)entity);
						}
						else
						{
							Point2D pt = _0023_003DzUnxHUznPiV7g(ellipse.Center);
							Point2D pt2 = _0023_003DzUnxHUznPiV7g(ellipse.MajorAxisEndPoint);
							Vector3D vector3D = Vector3D.Subtract(plane.PointAt(pt2), plane.Origin);
							double length = vector3D.Length;
							double ry = length * ellipse.MinorToMajorRatio;
							vector3D.Normalize();
							Vector3D y = Vector3D.Cross(_0023_003DzlvGiL_QdgBbL(hatch.Normal), vector3D);
							Plane plane2 = new Plane(plane.Origin, vector3D, y);
							pt = plane2.Project(plane.PointAt(pt));
							double endAngle = ellipse.EndAngle;
							double startAngle = ellipse.StartAngle;
							if (Utility.AreEqual(endAngle - startAngle, Math.PI * 2.0, Math.PI * 2.0))
							{
								list2.Add(new devDept.Eyeshot.Entities.Ellipse(plane2, pt, length, ry));
							}
							else
							{
								list2.Add(new EllipticalArc(plane2, pt, length, ry, startAngle, endAngle));
							}
						}
					}
					else
					{
						Point2D point2D2 = _0023_003DzUnxHUznPiV7g(arc.Center);
						Plane plane3 = plane;
						double num2 = Utility.DegToRad(arc.StartAngle);
						double endAngle2 = Utility.DegToRad(arc.EndAngle);
						Utility.FixEndAngle(num2, ref endAngle2);
						if (!arc.CounterClockWise)
						{
							plane3 = new Plane(plane.Origin, plane.AxisX, -1.0 * plane.AxisY);
							point2D2 = plane3.Project(plane.PointAt(point2D2));
						}
						if (Utility.AreEqual(endAngle2 - num2, Math.PI * 2.0, Math.PI * 2.0))
						{
							list2.Add(new devDept.Eyeshot.Entities.Circle(plane3, point2D2, arc.Radius));
						}
						else
						{
							list2.Add(new devDept.Eyeshot.Entities.Arc(plane3, point2D2, arc.Radius, num2, endAngle2));
						}
					}
					continue;
				}
				Point2D point2D3 = _0023_003DzUnxHUznPiV7g(line.Start);
				Point2D point2D4 = _0023_003DzUnxHUznPiV7g(line.End);
				if (Point2D.DistanceSquared(point2D3, point2D4) < 1E-12)
				{
					continue;
				}
				devDept.Eyeshot.Entities.Line line2 = new devDept.Eyeshot.Entities.Line(point2D3.X, point2D3.Y, point2D4.X, point2D4.Y);
				foreach (ICurve item3 in list2)
				{
					if (item3 is devDept.Eyeshot.Entities.Line && Point3D.Distance(item3.StartPoint, line2.StartPoint) < 1E-12 && Point3D.Distance(item3.EndPoint, line2.EndPoint) < 1E-12)
					{
						log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003654), _0023_003DzfpN7pnryJplL.Handle, item2));
						return null;
					}
				}
				list2.Add(line2);
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
			devDept.Eyeshot.Entities.Entity entity2 = new devDept.Eyeshot.Entities.Hatch(name, list.Cast<ICurve>().ToArray(), plane)
			{
				PatternScale = (float)((hatch.PatternScale != 0.0) ? hatch.PatternScale : 1.0),
				PatternAngle = hatch.PatternAngle,
				PatternOrigin = point2D,
				PatternSpacing = hatch.PatternScale,
				PatternDouble = hatch.IsDouble,
				IsUserDefinedPattern = (hatch.PatternType == HatchPatternType.PatternFill)
			};
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(entity2, hatch, _0023_003DzELu0Pss_003D);
			return entity2;
		}
		log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000720), _0023_003DzfpN7pnryJplL.Handle));
		return null;
	}

	private HatchPattern _0023_003DzHSqIboHDImSB(string _0023_003DzS5V6fD8_003D, ACadSharp.Entities.Hatch _0023_003DzARMr0XOa9k_00249)
	{
		ACadSharp.Entities.HatchPattern pattern = _0023_003DzARMr0XOa9k_00249.Pattern;
		HatchPatternLine[] array = new HatchPatternLine[pattern.Lines.Count];
		double num = Math.Sin(_0023_003DzARMr0XOa9k_00249.PatternAngle);
		double num2 = Math.Cos(_0023_003DzARMr0XOa9k_00249.PatternAngle);
		Point3D point3D = new Point3D();
		if (_0023_003DzARMr0XOa9k_00249.ExtendedData.TryGet(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003763), out var value))
		{
			foreach (ExtendedDataRecord record in value.Records)
			{
				if (record.Code == DxfCode.ExtendedDataXCoordinate)
				{
					XYZ xYZ = (XYZ)record.RawValue;
					point3D.X = xYZ.X;
					point3D.Y = xYZ.Y;
					break;
				}
			}
		}
		for (int i = 0; i < array.Length; i++)
		{
			ACadSharp.Entities.HatchPattern.Line line = pattern.Lines[i];
			List<double> dashLengths = line.DashLengths;
			float[] array2 = new float[dashLengths.Count];
			for (int j = 0; j < dashLengths.Count; j++)
			{
				array2[j] = (float)((double)(float)dashLengths[j] / _0023_003DzARMr0XOa9k_00249.PatternScale);
			}
			if (!LineType.CheckPattern(array2, throwEx: false, out var _))
			{
				array2 = new float[0];
			}
			XY xY = new XY(num2 * line.BasePoint.X / _0023_003DzARMr0XOa9k_00249.PatternScale + num * line.BasePoint.Y / _0023_003DzARMr0XOa9k_00249.PatternScale, (0.0 - num) * line.BasePoint.X / _0023_003DzARMr0XOa9k_00249.PatternScale + num2 * line.BasePoint.Y / _0023_003DzARMr0XOa9k_00249.PatternScale);
			Point3D point3D2 = new Point3D(point3D.X, point3D.Y);
			Point3D point3D3 = new Point3D(xY.X, xY.Y);
			double num3 = ReadDWG._0023_003DzgRf1Kl0_003D(_0023_003DzARMr0XOa9k_00249.PatternScale);
			Scaling scaling = new Scaling(1.0 / num3);
			Transformation transformation = Transformation.CreateRotation(_0023_003DzARMr0XOa9k_00249.PatternAngle, Vector3D.AxisMinusZ);
			point3D2.TransformBy(scaling * transformation);
			point3D3.TransformBy(new Translation(-1.0 * point3D2.AsVector));
			array[i] = new HatchPatternLine(line.Angle - _0023_003DzARMr0XOa9k_00249.PatternAngle, new Point2D(point3D3.X, point3D3.Y), line.Shift / _0023_003DzARMr0XOa9k_00249.PatternScale, line.LineOffset / _0023_003DzARMr0XOa9k_00249.PatternScale, array2);
		}
		return new HatchPattern(_0023_003DzS5V6fD8_003D, array);
	}

	private devDept.Eyeshot.Entities.Entity _0023_003DzYW8_fbk_003D(ACadSharp.Entities.Entity _0023_003DzfpN7pnryJplL, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		ACadSharp.Entities.Point point = (ACadSharp.Entities.Point)_0023_003DzfpN7pnryJplL;
		devDept.Eyeshot.Entities.Point point2 = new devDept.Eyeshot.Entities.Point(point.Location.X, point.Location.Y, point.Location.Z);
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(point2, point, _0023_003DzELu0Pss_003D);
		return point2;
	}

	private devDept.Eyeshot.Entities.Entity _0023_003DzcvG8EU4_003D(ACadSharp.Entities.Entity _0023_003DzfpN7pnryJplL, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		ACadSharp.Entities.Line line = (ACadSharp.Entities.Line)_0023_003DzfpN7pnryJplL;
		double[] array = _0023_003Dzh4Wf7tlUUlDt(line.StartPoint);
		double[] array2 = _0023_003Dzh4Wf7tlUUlDt(line.EndPoint);
		devDept.Eyeshot.Entities.Line line2 = new devDept.Eyeshot.Entities.Line(array[0], array[1], array[2], array2[0], array2[1], array2[2]);
		Vector3D vector3D = new Vector3D(_0023_003DzdZJdWj61QN4u(line.Normal));
		if (line2.Length() < Utility._0023_003DzheSR8QM7q9ya)
		{
			devDept.Eyeshot.Entities.Point point = new devDept.Eyeshot.Entities.Point(line2.StartPoint);
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(point, line, _0023_003DzELu0Pss_003D);
			point.AutodeskProperties.Thickness = line.Thickness;
			point.AutodeskProperties.ExtrusionDir = vector3D;
			return point;
		}
		if (line.Thickness == 0.0 || !ExtrudeByThickness)
		{
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(line2, line, _0023_003DzELu0Pss_003D);
			line2.AutodeskProperties.Thickness = line.Thickness;
			line2.AutodeskProperties.ExtrusionDir = vector3D;
			return line2;
		}
		devDept.Eyeshot.Entities.Entity entity = line2.ExtrudeAsBrep(vector3D * line.Thickness);
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(entity, line, _0023_003DzELu0Pss_003D);
		return entity;
	}

	private devDept.Eyeshot.Entities.Entity _0023_003Dz_00249dhb4DTUG2p(ACadSharp.Entities.Entity _0023_003DzfpN7pnryJplL, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		XLine xLine = (XLine)_0023_003DzfpN7pnryJplL;
		Vector3D vector3D = new Vector3D(_0023_003DzdZJdWj61QN4u(xLine.Direction));
		LinearEntity linearEntity = new LinearEntity(new Point3D(_0023_003Dzh4Wf7tlUUlDt(xLine.FirstPoint)), vector3D, vector3D.Length);
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(linearEntity, xLine, _0023_003DzELu0Pss_003D);
		return linearEntity;
	}

	private devDept.Eyeshot.Entities.Entity _0023_003DzNc2BB00_003D(ACadSharp.Entities.Entity _0023_003DzfpN7pnryJplL, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		ACadSharp.Entities.Arc arc = (ACadSharp.Entities.Arc)_0023_003DzfpN7pnryJplL;
		Plane plane = ReadDWG._0023_003DztIc79mb2zQ0f(_0023_003DzdZJdWj61QN4u(arc.Normal), 0.0);
		Point3D center = plane.PointAt(arc.Center.X, arc.Center.Y, arc.Center.Z);
		double endAngle = arc.EndAngle;
		double startAngle = arc.StartAngle;
		Utility.FixEndAngle(startAngle, ref endAngle);
		if (arc.Radius > 1E-12)
		{
			devDept.Eyeshot.Entities.Arc arc2 = new devDept.Eyeshot.Entities.Arc(plane, center, arc.Radius, startAngle, endAngle);
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(arc2, arc, _0023_003DzELu0Pss_003D);
			Vector3D vector3D = _0023_003DzlvGiL_QdgBbL(arc.Normal);
			if (arc.Thickness == 0.0 || !ExtrudeByThickness)
			{
				_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(arc2, arc, _0023_003DzELu0Pss_003D);
				arc2.AutodeskProperties.Thickness = arc.Thickness;
				arc2.AutodeskProperties.ExtrusionDir = vector3D;
				return arc2;
			}
			devDept.Eyeshot.Entities.Entity entity = arc2.ExtrudeAsBrep(vector3D * arc.Thickness);
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(entity, arc, _0023_003DzELu0Pss_003D);
			return entity;
		}
		log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001393), _0023_003DzfpN7pnryJplL.Handle));
		return null;
	}

	private devDept.Eyeshot.Entities.Entity _0023_003Dzbp0VrpRnjEGL(ACadSharp.Entities.Entity _0023_003DzfpN7pnryJplL, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		ACadSharp.Entities.Circle circle = (ACadSharp.Entities.Circle)_0023_003DzfpN7pnryJplL;
		Plane plane = ReadDWG._0023_003DztIc79mb2zQ0f(_0023_003DzdZJdWj61QN4u(circle.Normal), 0.0);
		Point3D center = plane.PointAt(circle.Center.X, circle.Center.Y, circle.Center.Z);
		if (circle.Radius > 1E-12)
		{
			devDept.Eyeshot.Entities.Circle circle2 = new devDept.Eyeshot.Entities.Circle(plane, center, circle.Radius);
			Vector3D vector3D = new Vector3D(_0023_003DzdZJdWj61QN4u(circle.Normal));
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(circle2, circle, _0023_003DzELu0Pss_003D);
			if (circle.Thickness == 0.0 || !ExtrudeByThickness)
			{
				_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(circle2, circle, _0023_003DzELu0Pss_003D);
				circle2.AutodeskProperties.Thickness = circle.Thickness;
				circle2.AutodeskProperties.ExtrusionDir = vector3D;
				return circle2;
			}
			devDept.Eyeshot.Entities.Entity entity = circle2.ExtrudeAsBrep(vector3D * circle.Thickness);
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(entity, circle, _0023_003DzELu0Pss_003D);
			return entity;
		}
		log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001589), _0023_003DzfpN7pnryJplL.Handle));
		return null;
	}

	private devDept.Eyeshot.Entities.Entity _0023_003DzHBlwxd8_003D(ACadSharp.Entities.Entity _0023_003DzfpN7pnryJplL, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		ACadSharp.Entities.Ellipse ellipse = (ACadSharp.Entities.Ellipse)_0023_003DzfpN7pnryJplL;
		Vector3D xAxis = new Vector3D();
		Vector3D yAxis = new Vector3D();
		Vector3D vector3D = new Vector3D(_0023_003DzdZJdWj61QN4u(ellipse.Normal));
		Transformation.AutocadOCS(vector3D, out xAxis, out yAxis);
		Point3D center = _0023_003Dzmq2_arBswhAA(ellipse.Center);
		Transformation xform = Transformation.CreateRotation(ellipse.Rotation, vector3D, center);
		xAxis.TransformBy(xform);
		yAxis.TransformBy(xform);
		xAxis *= 0.5 * ellipse.MajorAxis;
		yAxis *= 0.5 * ellipse.MinorAxis;
		Vector3D vector3D2 = xAxis;
		Vector3D vector3D3 = yAxis;
		Plane arcPlane = new Plane(Point3D.Origin, vector3D2, vector3D3);
		double endAngle = ellipse.EndParameter;
		Utility.FixEndAngle(ellipse.StartParameter, ref endAngle);
		double length = vector3D2.Length;
		double length2 = vector3D3.Length;
		if (length > 1E-12 && length2 > 1E-12)
		{
			EllipticalArc ellipticalArc = new EllipticalArc(arcPlane, center, length, length2, ellipse.StartParameter, endAngle);
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(ellipticalArc, ellipse, _0023_003DzELu0Pss_003D);
			return ellipticalArc;
		}
		log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001534), _0023_003DzfpN7pnryJplL.Handle));
		return null;
	}

	private static Text.alignmentType _0023_003DzchWitWWfcbIf_EiN7Q_003D_003D(TextVerticalAlignmentType _0023_003DzXD_00245D6k1e_0024_0024n, TextHorizontalAlignment _0023_003Dz0z2C5XxISN_Q)
	{
		Text.alignmentType result = Text.alignmentType.BaselineLeft;
		switch (_0023_003DzXD_00245D6k1e_0024_0024n)
		{
		case TextVerticalAlignmentType.Bottom:
			switch (_0023_003Dz0z2C5XxISN_Q)
			{
			case TextHorizontalAlignment.Left:
				result = Text.alignmentType.BottomLeft;
				break;
			case TextHorizontalAlignment.Center:
				result = Text.alignmentType.BottomCenter;
				break;
			case TextHorizontalAlignment.Right:
				result = Text.alignmentType.BottomRight;
				break;
			}
			break;
		case TextVerticalAlignmentType.Baseline:
			switch (_0023_003Dz0z2C5XxISN_Q)
			{
			case TextHorizontalAlignment.Left:
				result = Text.alignmentType.BaselineLeft;
				goto end_IL_0004;
			case TextHorizontalAlignment.Center:
				result = Text.alignmentType.BaselineCenter;
				goto end_IL_0004;
			case TextHorizontalAlignment.Right:
				result = Text.alignmentType.BaselineRight;
				goto end_IL_0004;
			case TextHorizontalAlignment.Middle:
				break;
			default:
				goto end_IL_0004;
			}
			goto IL_0095;
		case TextVerticalAlignmentType.Middle:
			switch (_0023_003Dz0z2C5XxISN_Q)
			{
			case TextHorizontalAlignment.Left:
				result = Text.alignmentType.MiddleLeft;
				goto end_IL_0004;
			case TextHorizontalAlignment.Center:
				break;
			case TextHorizontalAlignment.Right:
				result = Text.alignmentType.MiddleRight;
				goto end_IL_0004;
			default:
				goto end_IL_0004;
			}
			goto IL_0095;
		case TextVerticalAlignmentType.Top:
			{
				switch (_0023_003Dz0z2C5XxISN_Q)
				{
				case TextHorizontalAlignment.Left:
					result = Text.alignmentType.TopLeft;
					break;
				case TextHorizontalAlignment.Center:
					result = Text.alignmentType.TopCenter;
					break;
				case TextHorizontalAlignment.Right:
					result = Text.alignmentType.TopRight;
					break;
				}
				break;
			}
			IL_0095:
			result = Text.alignmentType.MiddleCenter;
			break;
			end_IL_0004:
			break;
		}
		return result;
	}

	private static Text.alignmentType _0023_003DzchWitWWfcbIf_EiN7Q_003D_003D(AttachmentPointType _0023_003Dz1pzzCsQ_003D)
	{
		Text.alignmentType result = Text.alignmentType.BaselineLeft;
		switch (_0023_003Dz1pzzCsQ_003D)
		{
		case AttachmentPointType.BottomLeft:
			result = Text.alignmentType.BottomLeft;
			break;
		case AttachmentPointType.BottomCenter:
			result = Text.alignmentType.BottomCenter;
			break;
		case AttachmentPointType.BottomRight:
			result = Text.alignmentType.BottomRight;
			break;
		case AttachmentPointType.MiddleLeft:
			result = Text.alignmentType.MiddleLeft;
			break;
		case AttachmentPointType.MiddleCenter:
			result = Text.alignmentType.MiddleCenter;
			break;
		case AttachmentPointType.MiddleRight:
			result = Text.alignmentType.MiddleRight;
			break;
		case AttachmentPointType.TopLeft:
			result = Text.alignmentType.TopLeft;
			break;
		case AttachmentPointType.TopCenter:
			result = Text.alignmentType.TopCenter;
			break;
		case AttachmentPointType.TopRight:
			result = Text.alignmentType.TopRight;
			break;
		}
		return result;
	}

	private static devDept.Eyeshot.Entities.Dimension.horizontalAlignmentType _0023_003DzF8RvkF_0024sf1_0024zpxq4G_00242gJvo_003D(DimensionTextHorizontalAlignment _0023_003DzjN7uSQk_003D)
	{
		return _0023_003DzjN7uSQk_003D switch
		{
			DimensionTextHorizontalAlignment.Centered => devDept.Eyeshot.Entities.Dimension.horizontalAlignmentType.Centered, 
			DimensionTextHorizontalAlignment.OverFirstExtLine => devDept.Eyeshot.Entities.Dimension.horizontalAlignmentType.FirstExtensionLine, 
			DimensionTextHorizontalAlignment.OverSecondExtLine => devDept.Eyeshot.Entities.Dimension.horizontalAlignmentType.SecondExtensionLine, 
			_ => devDept.Eyeshot.Entities.Dimension.horizontalAlignmentType.Centered, 
		};
	}

	private static devDept.Eyeshot.Entities.Dimension.verticalAlignmentType _0023_003Dz0yOsiWvhZV7rteWmhwgDe9k_003D(DimensionTextVerticalAlignment _0023_003DzjN7uSQk_003D)
	{
		return _0023_003DzjN7uSQk_003D switch
		{
			DimensionTextVerticalAlignment.Centered => devDept.Eyeshot.Entities.Dimension.verticalAlignmentType.Centered, 
			DimensionTextVerticalAlignment.Above => devDept.Eyeshot.Entities.Dimension.verticalAlignmentType.Above, 
			DimensionTextVerticalAlignment.Below => devDept.Eyeshot.Entities.Dimension.verticalAlignmentType.Below, 
			_ => devDept.Eyeshot.Entities.Dimension.verticalAlignmentType.Centered, 
		};
	}

	private devDept.Eyeshot.Entities.Entity _0023_003Dzfpt8uoA_003D(ACadSharp.Entities.Entity _0023_003DzfpN7pnryJplL, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		TextEntity textEntity = (TextEntity)_0023_003DzfpN7pnryJplL;
		string value = textEntity.Value;
		double height = textEntity.Height;
		Text.alignmentType alignmentType = _0023_003DzchWitWWfcbIf_EiN7Q_003D_003D(textEntity.VerticalAlignment, textEntity.HorizontalAlignment);
		Plane plane = ReadDWG._0023_003DztIc79mb2zQ0f(_0023_003DzdZJdWj61QN4u(textEntity.Normal), 0.0);
		plane.Rotate(textEntity.Rotation, plane.AxisZ, Point3D.Origin);
		double[] array = Array.Empty<double>();
		array = ((alignmentType == Text.alignmentType.BaselineLeft) ? _0023_003Dzh4Wf7tlUUlDt(textEntity.InsertPoint) : _0023_003Dzh4Wf7tlUUlDt(textEntity.AlignmentPoint));
		string name = textEntity.Style.Name;
		Text text = new Text(plane, new Point3D(array), ReadDWG._0023_003Dz3lOHLrA_003D(value), height, alignmentType, (name == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963495)) ? string.Empty : name);
		text.Backward = (textEntity.Mirror & TextMirrorFlag.Backward) != 0;
		text.UpsideDown = (textEntity.Mirror & TextMirrorFlag.UpsideDown) != 0;
		text.WidthFactor = textEntity.WidthFactor;
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(text, textEntity, _0023_003DzELu0Pss_003D);
		if (text.TextString.Trim().Length > 0)
		{
			return text;
		}
		log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001190), _0023_003DzfpN7pnryJplL.Handle));
		return null;
	}

	private AttributeReference _0023_003DzFdchMug_003D(AttributeEntity _0023_003DzIK82uaIA7QMG, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		double height = _0023_003DzIK82uaIA7QMG.Height;
		Text.alignmentType alignmentType = _0023_003DzchWitWWfcbIf_EiN7Q_003D_003D(_0023_003DzIK82uaIA7QMG.VerticalAlignment, _0023_003DzIK82uaIA7QMG.HorizontalAlignment);
		Text.alignmentType alignment = alignmentType;
		Plane plane = ReadDWG._0023_003DztIc79mb2zQ0f(_0023_003DzdZJdWj61QN4u(_0023_003DzIK82uaIA7QMG.Normal), 0.0);
		plane.Rotate(_0023_003DzIK82uaIA7QMG.Rotation, plane.AxisZ, Point3D.Origin);
		Point3D insPoint = new Point3D(_0023_003Dzh4Wf7tlUUlDt(_0023_003DzIK82uaIA7QMG.InsertPoint));
		if (alignmentType != Text.alignmentType.BaselineLeft && alignmentType != Text.alignmentType.BaselineCenter && alignmentType != Text.alignmentType.BaselineRight)
		{
			insPoint = new Point3D(_0023_003Dzh4Wf7tlUUlDt(_0023_003DzIK82uaIA7QMG.AlignmentPoint));
		}
		AttributeReference attributeReference = new AttributeReference(plane, insPoint, ReadDWG._0023_003Dz3lOHLrA_003D(_0023_003DzIK82uaIA7QMG.Value), height);
		attributeReference.Alignment = alignment;
		attributeReference.Backward = (_0023_003DzIK82uaIA7QMG.Mirror & TextMirrorFlag.Backward) != 0;
		attributeReference.UpsideDown = (_0023_003DzIK82uaIA7QMG.Mirror & TextMirrorFlag.UpsideDown) != 0;
		attributeReference.WidthFactor = _0023_003DzIK82uaIA7QMG.WidthFactor;
		attributeReference.Constant = (_0023_003DzIK82uaIA7QMG.Flags & AttributeFlags.Constant) != 0;
		attributeReference.Verify = (_0023_003DzIK82uaIA7QMG.Flags & AttributeFlags.Verify) != 0;
		attributeReference.Preset = (_0023_003DzIK82uaIA7QMG.Flags & AttributeFlags.Preset) != 0;
		attributeReference.StyleName = ((_0023_003DzIK82uaIA7QMG.Style.Name == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963495)) ? string.Empty : _0023_003DzIK82uaIA7QMG.Style.Name);
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(attributeReference, _0023_003DzIK82uaIA7QMG, _0023_003DzELu0Pss_003D);
		attributeReference.Invisible = _0023_003DzIK82uaIA7QMG.IsInvisible;
		return attributeReference;
	}

	private devDept.Eyeshot.Entities.Entity _0023_003DzCGAW_0024kk_003D(ACadSharp.Entities.Entity _0023_003DzfpN7pnryJplL, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		AttributeEntity attributeEntity = (AttributeEntity)_0023_003DzfpN7pnryJplL;
		double height = attributeEntity.Height;
		_0023_003DzchWitWWfcbIf_EiN7Q_003D_003D(attributeEntity.MText.AttachmentPoint);
		Plane plane = ReadDWG._0023_003DztIc79mb2zQ0f(_0023_003DzdZJdWj61QN4u(attributeEntity.Normal), 0.0);
		plane.Rotate(attributeEntity.Rotation, plane.AxisZ, Point3D.Origin);
		double[] coords = _0023_003Dzh4Wf7tlUUlDt(attributeEntity.InsertPoint);
		if (attributeEntity.HorizontalAlignment != TextHorizontalAlignment.Left || attributeEntity.VerticalAlignment != TextVerticalAlignmentType.Baseline)
		{
			coords = _0023_003Dzh4Wf7tlUUlDt(attributeEntity.AlignmentPoint);
		}
		devDept.Eyeshot.Entities.Attribute attribute = new devDept.Eyeshot.Entities.Attribute(plane, new Point3D(coords), attributeEntity.Tag, ReadDWG._0023_003Dz3lOHLrA_003D(attributeEntity.MText.PlainText), height);
		attribute.Alignment = _0023_003DzchWitWWfcbIf_EiN7Q_003D_003D(attributeEntity.VerticalAlignment, attributeEntity.HorizontalAlignment);
		attribute.Backward = (attributeEntity.Mirror & TextMirrorFlag.Backward) != 0;
		attribute.UpsideDown = (attributeEntity.Mirror & TextMirrorFlag.UpsideDown) != 0;
		attribute.WidthFactor = attributeEntity.WidthFactor;
		attribute.Constant = (attributeEntity.Flags & AttributeFlags.Constant) != 0;
		attribute.Verify = (attributeEntity.Flags & AttributeFlags.Verify) != 0;
		attribute.Preset = (attributeEntity.Flags & AttributeFlags.Preset) != 0;
		attribute.StyleName = attributeEntity.Style.Name;
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(attribute, attributeEntity, _0023_003DzELu0Pss_003D);
		attribute.Invisible = attributeEntity.IsInvisible;
		return attribute;
	}

	private devDept.Eyeshot.Entities.Entity _0023_003DzpMg88rY7dqeU(ACadSharp.Entities.Entity _0023_003DzfpN7pnryJplL, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		AttributeDefinition attributeDefinition = (AttributeDefinition)_0023_003DzfpN7pnryJplL;
		double height = attributeDefinition.Height;
		Plane plane = ReadDWG._0023_003DztIc79mb2zQ0f(_0023_003DzdZJdWj61QN4u(attributeDefinition.Normal), 0.0);
		plane.Rotate(attributeDefinition.Rotation, plane.AxisZ, Point3D.Origin);
		double[] coords = _0023_003Dzh4Wf7tlUUlDt(attributeDefinition.InsertPoint);
		if (attributeDefinition.HorizontalAlignment != TextHorizontalAlignment.Left || attributeDefinition.VerticalAlignment != TextVerticalAlignmentType.Baseline)
		{
			coords = _0023_003Dzh4Wf7tlUUlDt(attributeDefinition.AlignmentPoint);
		}
		devDept.Eyeshot.Entities.Attribute attribute = new devDept.Eyeshot.Entities.Attribute(plane, new Point3D(coords), attributeDefinition.Tag, ReadDWG._0023_003Dz3lOHLrA_003D(attributeDefinition.Value), height);
		attribute.alignment = _0023_003DzchWitWWfcbIf_EiN7Q_003D_003D(attributeDefinition.VerticalAlignment, attributeDefinition.HorizontalAlignment);
		attribute.Backward = (attributeDefinition.Mirror & TextMirrorFlag.Backward) != 0;
		attribute.UpsideDown = (attributeDefinition.Mirror & TextMirrorFlag.UpsideDown) != 0;
		attribute.WidthFactor = attributeDefinition.WidthFactor;
		attribute.Prompt = attributeDefinition.Prompt;
		attribute.Constant = (attributeDefinition.Flags & AttributeFlags.Constant) != 0;
		attribute.Verify = (attributeDefinition.Flags & AttributeFlags.Verify) != 0;
		attribute.Preset = (attributeDefinition.Flags & AttributeFlags.Preset) != 0;
		attribute.StyleName = attributeDefinition.Style.Name;
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(attribute, attributeDefinition, _0023_003DzELu0Pss_003D);
		attribute.Invisible = attributeDefinition.IsInvisible;
		return attribute;
	}

	private devDept.Eyeshot.Entities.Entity _0023_003DzUc1T0QlYOb0H29091w_003D_003D(ACadSharp.Entities.Hatch.BoundaryPath.Polyline _0023_003DzKFOHiHw8_0024GRYx8cFJg_003D_003D, int _0023_003DzfBEBL_o_003D, ReadEntityData _0023_003DzELu0Pss_003D, Plane _0023_003Dz7BYIGZMHUBv_0024qJaOYQ_003D_003D)
	{
		Plane _0023_003Dzpyw2kZk_003D = _0023_003Dz7BYIGZMHUBv_0024qJaOYQ_003D_003D ?? Plane.XY;
		bool hasBulge = _0023_003DzKFOHiHw8_0024GRYx8cFJg_003D_003D.HasBulge;
		List<Vertex2D> list = new List<Vertex2D>();
		for (int i = 0; i < _0023_003DzKFOHiHw8_0024GRYx8cFJg_003D_003D.Vertices.Count; i++)
		{
			Vertex2D vertex2D = new Vertex2D(_0023_003DzKFOHiHw8_0024GRYx8cFJg_003D_003D.Vertices[i]);
			vertex2D.Bulge = _0023_003DzKFOHiHw8_0024GRYx8cFJg_003D_003D.Bulges.ElementAt(i);
			list.Add(vertex2D);
		}
		list.Add((Vertex2D)list[0].Clone());
		Polyline2D polyline2D = new Polyline2D(list, isClosed: true);
		bool flag = polyline2D.Thickness != 0.0 && ExtrudeByThickness;
		ICurve curve = _0023_003DzDIfQPmvb7H4x7wBlCQ_003D_003D(polyline2D, _0023_003DzfBEBL_o_003D, _0023_003Dzpyw2kZk_003D, hasBulge, _0023_003DzELu0Pss_003D, flag);
		Vector3D vector3D = new Vector3D(_0023_003DzdZJdWj61QN4u(polyline2D.Normal));
		if (!flag)
		{
			((devDept.Eyeshot.Entities.Entity)curve).AutodeskProperties.Thickness = polyline2D.Thickness;
			((devDept.Eyeshot.Entities.Entity)curve).AutodeskProperties.ExtrusionDir = vector3D;
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(curve as devDept.Eyeshot.Entities.Entity, polyline2D, _0023_003DzELu0Pss_003D);
			return (devDept.Eyeshot.Entities.Entity)curve;
		}
		devDept.Eyeshot.Entities.Entity entity = curve.ExtrudeAsBrep(vector3D * polyline2D.Thickness);
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(entity, polyline2D, _0023_003DzELu0Pss_003D);
		return entity;
	}

	private devDept.Eyeshot.Entities.Entity _0023_003DzUc1T0QlYOb0H29091w_003D_003D(IPolyline _0023_003DzKFOHiHw8_0024GRYx8cFJg_003D_003D, int _0023_003DzfBEBL_o_003D, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		Plane _0023_003Dzpyw2kZk_003D = ReadDWG._0023_003DztIc79mb2zQ0f(_0023_003DzdZJdWj61QN4u(_0023_003DzKFOHiHw8_0024GRYx8cFJg_003D_003D.Normal), 0.0);
		bool flag = _0023_003DzKFOHiHw8_0024GRYx8cFJg_003D_003D.Thickness != 0.0 && ExtrudeByThickness;
		ICurve curve = _0023_003DzDIfQPmvb7H4x7wBlCQ_003D_003D(_0023_003DzKFOHiHw8_0024GRYx8cFJg_003D_003D, _0023_003DzfBEBL_o_003D, _0023_003Dzpyw2kZk_003D, _0023_003DzKFOHiHw8_0024GRYx8cFJg_003D_003D.Vertices.Any(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz3qa8MKPa5BQ9xfUZN8fnu1s42zW7), _0023_003DzELu0Pss_003D, flag);
		Vector3D vector3D = new Vector3D(_0023_003DzdZJdWj61QN4u(_0023_003DzKFOHiHw8_0024GRYx8cFJg_003D_003D.Normal));
		if (!flag)
		{
			((devDept.Eyeshot.Entities.Entity)curve).AutodeskProperties.Thickness = _0023_003DzKFOHiHw8_0024GRYx8cFJg_003D_003D.Thickness;
			((devDept.Eyeshot.Entities.Entity)curve).AutodeskProperties.ExtrusionDir = vector3D;
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(curve as devDept.Eyeshot.Entities.Entity, (ACadSharp.Entities.Entity)_0023_003DzKFOHiHw8_0024GRYx8cFJg_003D_003D, _0023_003DzELu0Pss_003D);
			return (devDept.Eyeshot.Entities.Entity)curve;
		}
		devDept.Eyeshot.Entities.Entity entity = curve.ExtrudeAsBrep(vector3D * _0023_003DzKFOHiHw8_0024GRYx8cFJg_003D_003D.Thickness);
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(entity, (ACadSharp.Entities.Entity)_0023_003DzKFOHiHw8_0024GRYx8cFJg_003D_003D, _0023_003DzELu0Pss_003D);
		return entity;
	}

	private ICurve _0023_003DzDIfQPmvb7H4x7wBlCQ_003D_003D(IPolyline _0023_003DzRStSB1rsoNKYaya4kg_003D_003D, int _0023_003DzfBEBL_o_003D, Plane _0023_003Dzpyw2kZk_003D, bool _0023_003Dz_0024INsivcUOnm1, ReadEntityData _0023_003DzELu0Pss_003D, bool _0023_003DzlQ_1bygDZUc_0024BU6OAw_003D_003D)
	{
		int num = _0023_003DzRStSB1rsoNKYaya4kg_003D_003D.Vertices.Count();
		Utility.BoundingBox(_0023_003DzRStSB1rsoNKYaya4kg_003D_003D.Vertices.Select((ACadSharp.Entities.IVertex _0023_003DzMlCq3wk_003D) => new Point3D(_0023_003DzMlCq3wk_003D.Location[0], _0023_003DzMlCq3wk_003D.Location[1])).ToArray(), out var min, out var max);
		double domainSize = Point3D.Distance(min, max);
		if (!_0023_003Dz_0024INsivcUOnm1)
		{
			List<Point3D> list = new List<Point3D>();
			double num2 = 0.0;
			if (_0023_003DzfBEBL_o_003D == 2)
			{
				num2 = _0023_003DzcUIwgTwMj_5Y(_0023_003DzRStSB1rsoNKYaya4kg_003D_003D.Vertices.FirstOrDefault());
				foreach (ACadSharp.Entities.IVertex vertex2 in _0023_003DzRStSB1rsoNKYaya4kg_003D_003D.Vertices)
				{
					IVector location = vertex2.Location;
					list.Add(_0023_003Dzpyw2kZk_003D.PointAt(ReadDWG._0023_003DzgRf1Kl0_003D(location[0]), ReadDWG._0023_003DzgRf1Kl0_003D(location[1]), ReadDWG._0023_003DzgRf1Kl0_003D(_0023_003DzRStSB1rsoNKYaya4kg_003D_003D.Elevation)));
				}
			}
			else
			{
				num2 = 0.0;
				foreach (ACadSharp.Entities.IVertex vertex3 in _0023_003DzRStSB1rsoNKYaya4kg_003D_003D.Vertices)
				{
					num2 = _0023_003DzcUIwgTwMj_5Y(vertex3);
					IVector location2 = vertex3.Location;
					list.Add(_0023_003Dzpyw2kZk_003D.PointAt(ReadDWG._0023_003DzgRf1Kl0_003D(location2[0]), ReadDWG._0023_003DzgRf1Kl0_003D(location2[1]), ReadDWG._0023_003DzgRf1Kl0_003D(_0023_003DzRStSB1rsoNKYaya4kg_003D_003D.Elevation)));
				}
			}
			if (_0023_003DzlQ_1bygDZUc_0024BU6OAw_003D_003D)
			{
				list = Utility.RemoveDuplicates(list).ToList();
			}
			LinearPath linearPath = new LinearPath(list);
			if (_0023_003DzRStSB1rsoNKYaya4kg_003D_003D.IsClosed && !linearPath.IsClosed)
			{
				list.Add((Point3D)list[0].Clone());
				linearPath.Vertices = list.ToArray();
			}
			linearPath.GlobalWidth = num2;
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(linearPath, (ACadSharp.Entities.Entity)_0023_003DzRStSB1rsoNKYaya4kg_003D_003D, _0023_003DzELu0Pss_003D);
			return linearPath;
		}
		List<ICurve> list2 = new List<ICurve>();
		XY[] array = null;
		XYZ[] array2 = null;
		double[] array3 = new double[num];
		double elevation;
		if (_0023_003DzfBEBL_o_003D == 2)
		{
			elevation = _0023_003DzRStSB1rsoNKYaya4kg_003D_003D.Elevation;
			array = new XY[num];
			for (int num3 = 0; num3 < num; num3++)
			{
				ACadSharp.Entities.IVertex vertex = _0023_003DzRStSB1rsoNKYaya4kg_003D_003D.Vertices.ElementAt(num3);
				array[num3] = new XY(vertex.Location[0], vertex.Location[1]);
				array3[num3] = vertex.Bulge;
			}
		}
		else
		{
			elevation = _0023_003DzRStSB1rsoNKYaya4kg_003D_003D.Elevation;
			int num4 = 0;
			array2 = new XYZ[num];
			foreach (ACadSharp.Entities.IVertex vertex4 in _0023_003DzRStSB1rsoNKYaya4kg_003D_003D.Vertices)
			{
				array2[num4] = new XYZ(vertex4.Location[0], vertex4.Location[1], 0.0);
				array3[num4++] = vertex4.Bulge;
			}
		}
		int num5 = (_0023_003DzRStSB1rsoNKYaya4kg_003D_003D.IsClosed ? (num + 1) : num);
		for (int num6 = 0; num6 < num5 - 1; num6++)
		{
			Point2D point2D;
			Point2D point2D2;
			if (_0023_003DzfBEBL_o_003D == 2)
			{
				point2D = new Point2D(_0023_003Dzh4Wf7tlUUlDt(array[num6]));
				point2D2 = new Point2D(_0023_003Dzh4Wf7tlUUlDt(array[(num6 + 1) % num]));
			}
			else
			{
				point2D = new Point2D(_0023_003Dzh4Wf7tlUUlDt(array2[num6]));
				point2D2 = new Point2D(_0023_003Dzh4Wf7tlUUlDt(array2[(num6 + 1) % num]));
			}
			if (Point2D.AreEqual(point2D, point2D2, domainSize))
			{
				continue;
			}
			double num7 = array3[num6];
			if (Math.Abs(num7) < 1E-12)
			{
				devDept.Eyeshot.Entities.Line item = new devDept.Eyeshot.Entities.Line(_0023_003Dzpyw2kZk_003D.PointAt(ReadDWG._0023_003DzgRf1Kl0_003D(point2D.X), ReadDWG._0023_003DzgRf1Kl0_003D(point2D.Y), ReadDWG._0023_003DzgRf1Kl0_003D(elevation)), _0023_003Dzpyw2kZk_003D.PointAt(ReadDWG._0023_003DzgRf1Kl0_003D(point2D2.X), ReadDWG._0023_003DzgRf1Kl0_003D(point2D2.Y), ReadDWG._0023_003DzgRf1Kl0_003D(elevation)));
				list2.Add(item);
				continue;
			}
			double length = Vector2D.Subtract(point2D2, point2D).Length;
			if (length > 0.0)
			{
				double num8 = length / 2.0 * num7;
				double num9 = (length / 2.0 * (length / 2.0) + num8 * num8) / (2.0 * num8);
				double num10 = num9 - num8;
				double num11 = Math.Atan(num7) * 4.0;
				Point2D point2D3 = point2D + 0.5 * (point2D2 - point2D);
				Vector2D vector2D = new Vector2D(0.0 - (point2D2.Y - point2D.Y), point2D2.X - point2D.X);
				vector2D.Normalize();
				Vector2D vector2D2 = num10 * vector2D;
				Point2D point2D4 = new Point2D(point2D3.X + vector2D2.X, point2D3.Y + vector2D2.Y);
				double num12 = Utility.ArcTanProblem(point2D.X - point2D4.X, point2D.Y - point2D4.Y);
				if (Math.Abs(num9) > 1E-12 && Math.Abs(num11) > 1E-12)
				{
					devDept.Eyeshot.Entities.Arc item2 = new devDept.Eyeshot.Entities.Arc(_0023_003Dzpyw2kZk_003D, _0023_003Dzpyw2kZk_003D.PointAt(ReadDWG._0023_003DzgRf1Kl0_003D(point2D4.X), ReadDWG._0023_003DzgRf1Kl0_003D(point2D4.Y), ReadDWG._0023_003DzgRf1Kl0_003D(elevation)), Math.Abs(num9), num12, num12 + num11);
					list2.Add(item2);
				}
			}
		}
		if (list2.Count == 0)
		{
			return null;
		}
		CompositeCurve compositeCurve = new CompositeCurve(list2, sortAndOrient: false);
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(compositeCurve, (ACadSharp.Entities.Entity)_0023_003DzRStSB1rsoNKYaya4kg_003D_003D, _0023_003DzELu0Pss_003D);
		return compositeCurve;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static double _0023_003DzcUIwgTwMj_5Y(ACadSharp.Entities.IVertex _0023_003DzkEYxO1SuR1Kw)
	{
		if (!(_0023_003DzkEYxO1SuR1Kw is LwPolyline.Vertex { StartWidth: var startWidth }))
		{
			if (!(_0023_003DzkEYxO1SuR1Kw is Vertex { StartWidth: var startWidth2 }))
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004513));
			}
			return startWidth2;
		}
		return startWidth;
	}

	private devDept.Eyeshot.Entities.Entity _0023_003DzT7JvkYG2_e5DlNpugQ_003D_003D(ACadSharp.Entities.Entity _0023_003DzfpN7pnryJplL, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		Polyline3D polyline3D = (Polyline3D)_0023_003DzfpN7pnryJplL;
		SmoothSurfaceType smoothSurfaceType = polyline3D.SmoothSurface;
		List<Point3D> list = new List<Point3D>(polyline3D.Vertices.Count);
		List<Point3D> list2 = new List<Point3D>(polyline3D.Vertices.Count);
		for (int i = 0; i < polyline3D.Vertices.Count; i++)
		{
			Vertex3D _0023_003DzlY77YgY_003D = polyline3D.Vertices[i];
			list[i] = new Point3D(_0023_003Dzh4Wf7tlUUlDt(_0023_003DzlY77YgY_003D));
		}
		if (polyline3D.IsClosed)
		{
			smoothSurfaceType = SmoothSurfaceType.NoSmooth;
			if (list2.Count > 0 && !list2[0].Equals(list2.Last()))
			{
				list2.Add((Point3D)list2[0].Clone());
			}
		}
		int num = 0;
		int count = list.Count;
		if (count == 0)
		{
			smoothSurfaceType = SmoothSurfaceType.NoSmooth;
			if (list2.Count < 2)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303001282));
			}
		}
		switch (smoothSurfaceType)
		{
		case SmoothSurfaceType.Quadratic:
		{
			num = ((count == 2) ? 1 : 2);
			double[] knotVector = NurbsBase.UniformKnotVector(num, count);
			Point4D[] array = new Point4D[count];
			for (int k = 0; k < list.Count; k++)
			{
				array[k] = new Point4D(list[k].X, list[k].Y, list[k].Z);
			}
			Curve curve = new Curve(num, knotVector, array);
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(curve, polyline3D, _0023_003DzELu0Pss_003D);
			return curve;
		}
		case SmoothSurfaceType.Cubic:
		{
			num = count switch
			{
				2 => 1, 
				3 => 2, 
				_ => 3, 
			};
			double[] knotVector = NurbsBase.UniformKnotVector(num, count);
			Point4D[] array = new Point4D[count];
			for (int j = 0; j < list.Count; j++)
			{
				array[j] = new Point4D(list[j].X, list[j].Y, list[j].Z);
			}
			Curve curve = new Curve(num, knotVector, array);
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(curve, polyline3D, _0023_003DzELu0Pss_003D);
			return curve;
		}
		default:
		{
			LinearPath linearPath = new LinearPath(list);
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(linearPath, polyline3D, _0023_003DzELu0Pss_003D);
			return linearPath;
		}
		}
	}

	private devDept.Eyeshot.Entities.Entity _0023_003Dzl6LkJd4_003D(ACadSharp.Entities.Entity _0023_003DzfpN7pnryJplL, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		Spline spline = (Spline)_0023_003DzfpN7pnryJplL;
		Point4D[] array = new Point4D[spline.ControlPoints.Count];
		int degree = spline.Degree;
		bool num = spline.Weights.Any(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzZ6BdCMjKikJjit2Hjcjk_mA_003D);
		_ = spline.IsClosed;
		_ = spline.IsPeriodic;
		_ = spline.ControlPointTolerance;
		_ = spline.KnotTolerance;
		if (num)
		{
			for (int i = 0; i < array.Length; i++)
			{
				XYZ xYZ = spline.ControlPoints[i];
				double num2 = spline.Weights[i];
				array[i] = new Point4D(ReadDWG._0023_003DzgRf1Kl0_003D(xYZ.X) * num2, ReadDWG._0023_003DzgRf1Kl0_003D(xYZ.Y) * num2, ReadDWG._0023_003DzgRf1Kl0_003D(xYZ.Z) * num2, num2);
			}
		}
		else
		{
			for (int j = 0; j < array.Length; j++)
			{
				XYZ xYZ2 = spline.ControlPoints[j];
				array[j] = new Point4D(ReadDWG._0023_003DzgRf1Kl0_003D(xYZ2.X), ReadDWG._0023_003DzgRf1Kl0_003D(xYZ2.Y), ReadDWG._0023_003DzgRf1Kl0_003D(xYZ2.Z));
			}
		}
		devDept.Eyeshot.Entities.Entity entity = new Curve(degree, spline.Knots.ToArray(), array);
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(entity, spline, _0023_003DzELu0Pss_003D);
		return entity;
	}

	private devDept.Eyeshot.Entities.Entity _0023_003Dzg4ddAVY_003D(ACadSharp.Entities.Entity _0023_003DzfpN7pnryJplL, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		Face3D face3D = (Face3D)_0023_003DzfpN7pnryJplL;
		Point3D[] array = new Point3D[4];
		XYZ[] array2 = new XYZ[4] { face3D.FirstCorner, face3D.SecondCorner, face3D.ThirdCorner, face3D.FourthCorner };
		for (ushort num = 0; num < 4; num++)
		{
			array[num] = new Point3D(_0023_003Dzh4Wf7tlUUlDt(array2[num]));
		}
		if (array[2] == array[3])
		{
			Triangle triangle = new Triangle(array[0], array[1], array[2]);
			triangle.VisibleEdgeFlag = 0;
			if ((face3D.Flags & InvisibleEdgeFlags.First) != InvisibleEdgeFlags.None)
			{
				triangle.VisibleEdgeFlag |= 1;
			}
			if ((face3D.Flags & InvisibleEdgeFlags.Second) != InvisibleEdgeFlags.None)
			{
				triangle.VisibleEdgeFlag |= 2;
			}
			if ((face3D.Flags & InvisibleEdgeFlags.Third) != InvisibleEdgeFlags.None)
			{
				triangle.VisibleEdgeFlag |= 4;
			}
			_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(triangle, face3D, _0023_003DzELu0Pss_003D);
			return triangle;
		}
		Quad quad = new Quad(array[0], array[1], array[2], array[3]);
		quad.VisibleEdgeFlag = 0;
		if ((face3D.Flags & InvisibleEdgeFlags.First) != InvisibleEdgeFlags.None)
		{
			quad.VisibleEdgeFlag |= 1;
		}
		if ((face3D.Flags & InvisibleEdgeFlags.Second) != InvisibleEdgeFlags.None)
		{
			quad.VisibleEdgeFlag |= 2;
		}
		if ((face3D.Flags & InvisibleEdgeFlags.Third) != InvisibleEdgeFlags.None)
		{
			quad.VisibleEdgeFlag |= 4;
		}
		if ((face3D.Flags & InvisibleEdgeFlags.Fourth) != InvisibleEdgeFlags.None)
		{
			quad.VisibleEdgeFlag |= 8;
		}
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(quad, face3D, _0023_003DzELu0Pss_003D);
		return quad;
	}

	private devDept.Eyeshot.Entities.Entity _0023_003DzfLPBio4Tv0xc(ACadSharp.Entities.Entity _0023_003DzfpN7pnryJplL, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		PolyfaceMesh polyfaceMesh = (PolyfaceMesh)_0023_003DzfpN7pnryJplL;
		devDept.Eyeshot.Entities.Mesh mesh = _0023_003DzqyEDItIHfCqH74lqXwKNTQc_003D(polyfaceMesh);
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(mesh, polyfaceMesh, _0023_003DzELu0Pss_003D);
		return mesh;
	}

	private devDept.Eyeshot.Entities.Mesh _0023_003DzqyEDItIHfCqH74lqXwKNTQc_003D(PolyfaceMesh _0023_003DzhENEtLLHryGA)
	{
		List<Point3D> list = new List<Point3D>(_0023_003DzhENEtLLHryGA.Vertices.Count);
		List<IndexTriangle> list2 = new List<IndexTriangle>();
		foreach (VertexFaceMesh vertex in _0023_003DzhENEtLLHryGA.Vertices)
		{
			list.Add(new Point3D(_0023_003Dzh4Wf7tlUUlDt(vertex)));
		}
		foreach (VertexFaceRecord face in _0023_003DzhENEtLLHryGA.Faces)
		{
			int index = face.Index1;
			int index2 = face.Index2;
			int index3 = face.Index3;
			int index4 = face.Index4;
			if (index != 0 && index2 != 0 && index3 != 0 && index < list.Count && index2 < list.Count && index3 < list.Count)
			{
				if (Math.Abs(index) != Math.Abs(index2) && Math.Abs(index) != Math.Abs(index3) && Math.Abs(index2) != Math.Abs(index3))
				{
					list2.Add(new SmoothTriangle(Math.Abs(index), Math.Abs(index2), Math.Abs(index3)));
				}
				if (index3 != index4 && index4 != 0 && Math.Abs(index) != Math.Abs(index3) && Math.Abs(index) != Math.Abs(index4) && Math.Abs(index3) != Math.Abs(index4))
				{
					list2.Add(new SmoothTriangle(Math.Abs(index), Math.Abs(index3), Math.Abs(index4)));
				}
			}
		}
		if (list.Count == 0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003735));
		}
		if (list2.Count == 0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003709));
		}
		return new devDept.Eyeshot.Entities.Mesh(list, list2);
	}

	private devDept.Eyeshot.Entities.Entity _0023_003DzTV0E4RQU4BKB(ACadSharp.Entities.Entity _0023_003DzfpN7pnryJplL, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		Insert insert = (Insert)_0023_003DzfpN7pnryJplL;
		string name = insert.Block.Name;
		string text = _0023_003DzELu0Pss_003D.xrefPrefix + name.TrimStart('*');
		Plane plane = ReadDWG._0023_003DztIc79mb2zQ0f(new double[3]
		{
			insert.Normal.X,
			insert.Normal.Y,
			insert.Normal.Z
		}, 0.0);
		if (_0023_003DzELu0Pss_003D.duplicatedBlockNamesConversionTable.ContainsKey(text))
		{
			text = _0023_003DzELu0Pss_003D.duplicatedBlockNamesConversionTable[text];
		}
		Point3D point3D = plane.PointAt(new Point3D(insert.InsertPoint.X, insert.InsertPoint.Y, insert.InsertPoint.Z));
		double[] array = _0023_003Dzh4Wf7tlUUlDt(new XYZ(point3D.X, point3D.Y, point3D.Z));
		BlockReferenceEx blockReferenceEx = new BlockReferenceEx(array[0], array[1], array[2], text, insert.XScale, insert.YScale, insert.ZScale, insert.Rotation);
		double[] array2 = _0023_003DzdZJdWj61QN4u(insert.Normal);
		if (array2[2] != 1.0)
		{
			Plane xY = Plane.XY;
			Plane plane2 = ReadDWG._0023_003DztIc79mb2zQ0f(array2, 0.0);
			Transformation transformation = new Transformation();
			transformation.Translation(0.0 - array[0], 0.0 - array[1], 0.0 - array[2]);
			Transformation transformation2 = new Transformation();
			transformation2.Rotation(xY.AxisX, xY.AxisY, xY.AxisZ, plane2.AxisX, plane2.AxisY, plane2.AxisZ);
			Transformation transformation3 = new Transformation();
			transformation3.Translation(array[0], array[1], array[2]);
			blockReferenceEx.TransformBy(transformation3 * transformation2 * transformation);
		}
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(blockReferenceEx, insert, _0023_003DzELu0Pss_003D);
		foreach (AttributeEntity attribute in insert.Attributes)
		{
			AttributeReference attributeReference = _0023_003DzFdchMug_003D(attribute, _0023_003DzELu0Pss_003D);
			attributeReference.WidthFactor *= Math.Abs(insert.YScale / insert.XScale);
			attributeReference.Height /= Math.Abs(insert.YScale);
			string text2 = attribute.Tag;
			if (blockReferenceEx.Attributes.ContainsKey(text2))
			{
				text2 = ReadDWG._0023_003DzRCP_0024_DgLkyfr(blockReferenceEx.Attributes, text2);
			}
			blockReferenceEx.Attributes.Add(text2, attributeReference);
		}
		return blockReferenceEx;
	}

	private devDept.Eyeshot.Entities.Entity _0023_003DzB8B0nHKDPlI6(DimensionAligned _0023_003Dzow04lCuzeeUF, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		if (_0023_003DzLhcuMaKxrATVOuEc6w_003D_003D(_0023_003DzELu0Pss_003D, out var _0023_003Dzs_0024uS8LA_003D, _0023_003Dzow04lCuzeeUF))
		{
			return _0023_003Dzs_0024uS8LA_003D;
		}
		double[] array = _0023_003Dzh4Wf7tlUUlDt(_0023_003Dzow04lCuzeeUF.FirstPoint);
		double[] array2 = _0023_003Dzh4Wf7tlUUlDt(_0023_003Dzow04lCuzeeUF.SecondPoint);
		double[] array3 = _0023_003Dzh4Wf7tlUUlDt(_0023_003Dzow04lCuzeeUF.DefinitionPoint);
		Point3D _0023_003DzO97ip_0024TQ_0024juS = new Point3D(array[0], array[1]);
		Point3D _0023_003DzM7o0gT3hjI = new Point3D(array2[0], array2[1]);
		Point3D _0023_003Dz2AZWQ2NrfVgE = new Point3D(array3[0], array3[1]);
		Plane plane = ReadDWG._0023_003DztIc79mb2zQ0f(_0023_003DzdZJdWj61QN4u(_0023_003Dzow04lCuzeeUF.Normal), 0.0);
		double num = 0.0;
		if (_0023_003Dzow04lCuzeeUF is DimensionLinear)
		{
			num = ((DimensionLinear)_0023_003Dzow04lCuzeeUF).Rotation;
		}
		if ((_0023_003Dzow04lCuzeeUF.Flags & DimensionType.Aligned) != DimensionType.Linear || num == 0.0)
		{
			ReadDWG._0023_003DzLqECXomsH96v5omFVw_003D_003D(plane, _0023_003DzO97ip_0024TQ_0024juS, _0023_003DzM7o0gT3hjI, _0023_003Dz2AZWQ2NrfVgE);
		}
		else
		{
			double rotation = ((DimensionLinear)_0023_003Dzow04lCuzeeUF).Rotation;
			rotation *= (double)((!(Utility.RadToDeg(((DimensionLinear)_0023_003Dzow04lCuzeeUF).Rotation) > 180.0)) ? 1 : (-1));
			if (!Utility.AreEqual(rotation, Math.PI, Math.PI * 2.0))
			{
				plane.Rotate(rotation, plane.AxisZ, Point3D.Origin);
			}
		}
		return _0023_003Dz02YZjgyIS01t(_0023_003Dzow04lCuzeeUF, plane, _0023_003DzO97ip_0024TQ_0024juS, _0023_003DzM7o0gT3hjI, _0023_003Dz2AZWQ2NrfVgE, _0023_003DzELu0Pss_003D, _0023_003DzL7uQ2E_DVkh2: false);
	}

	private devDept.Eyeshot.Entities.Entity _0023_003Dz02YZjgyIS01t(DimensionLinear _0023_003Dzow04lCuzeeUF, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		if (_0023_003DzLhcuMaKxrATVOuEc6w_003D_003D(_0023_003DzELu0Pss_003D, out var _0023_003Dzs_0024uS8LA_003D, _0023_003Dzow04lCuzeeUF))
		{
			return _0023_003Dzs_0024uS8LA_003D;
		}
		Point3D _0023_003DzO97ip_0024TQ_0024juS = _0023_003Dzmq2_arBswhAA(_0023_003Dzow04lCuzeeUF.FirstPoint);
		Point3D _0023_003DzM7o0gT3hjI = _0023_003Dzmq2_arBswhAA(_0023_003Dzow04lCuzeeUF.SecondPoint);
		Point3D _0023_003Dz2AZWQ2NrfVgE = _0023_003Dzmq2_arBswhAA(_0023_003Dzow04lCuzeeUF.DefinitionPoint);
		Plane plane = ReadDWG._0023_003DztIc79mb2zQ0f(_0023_003DzdZJdWj61QN4u(_0023_003Dzow04lCuzeeUF.Normal), 0.0);
		double rotation = _0023_003Dzow04lCuzeeUF.Rotation;
		rotation *= (double)((!(_0023_003Dzow04lCuzeeUF.Rotation > 180.0)) ? 1 : (-1));
		bool _0023_003DzL7uQ2E_DVkh = false;
		if (!Utility.AreEqual(rotation, Math.PI, Math.PI * 2.0))
		{
			plane.Rotate(rotation, plane.AxisZ, Point3D.Origin);
			_0023_003DzL7uQ2E_DVkh = true;
		}
		return _0023_003Dz02YZjgyIS01t(_0023_003Dzow04lCuzeeUF, plane, _0023_003DzO97ip_0024TQ_0024juS, _0023_003DzM7o0gT3hjI, _0023_003Dz2AZWQ2NrfVgE, _0023_003DzELu0Pss_003D, _0023_003DzL7uQ2E_DVkh);
	}

	private bool _0023_003DzLhcuMaKxrATVOuEc6w_003D_003D(ReadEntityData _0023_003DzELu0Pss_003D, out devDept.Eyeshot.Entities.Entity _0023_003Dzs_0024uS8LA_003D, ACadSharp.Entities.Entity _0023_003DzfpN7pnryJplL)
	{
		if (ExplodeDimensions)
		{
			throw new NotImplementedException();
		}
		_0023_003Dzs_0024uS8LA_003D = null;
		return false;
	}

	private T _0023_003Dzgd2KpODqkpON<T>(ACadSharp.Entities.Dimension _0023_003DzmTIZ8Fc_003D, _0023_003DziNJCUHDcmFST3zrMfA_003D_003D _0023_003Dz0G9lKNk_003D, T _0023_003Dz0eSiJtQ_003D)
	{
		if (!_0023_003DzZEXNeXDb73Ak.ContainsKey(_0023_003DzmTIZ8Fc_003D))
		{
			_0023_003DzZEXNeXDb73Ak[_0023_003DzmTIZ8Fc_003D] = new Dictionary<short, object>();
			if (_0023_003DzmTIZ8Fc_003D.ExtendedData.TryGet(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003763), out var value))
			{
				int i;
				for (i = 0; i < value.Records.Count && (value.Records[i].Code != DxfCode.ExtendedDataControlString || !value.Records[i].RawValue.ToString().Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941671))); i++)
				{
				}
				i++;
				while (i < value.Records.Count && (value.Records[i].Code != DxfCode.ExtendedDataControlString || !value.Records[i].RawValue.ToString().Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941679))))
				{
					int index = i++;
					int index2 = i++;
					_0023_003DzZEXNeXDb73Ak[_0023_003DzmTIZ8Fc_003D][(short)value.Records[index].RawValue] = value.Records[index2].RawValue;
				}
			}
		}
		if (_0023_003DzZEXNeXDb73Ak[_0023_003DzmTIZ8Fc_003D].TryGetValue((short)_0023_003Dz0G9lKNk_003D, out var value2))
		{
			try
			{
				if (typeof(T).IsEnum)
				{
					short value3 = Convert.ToInt16(value2);
					return (T)Enum.ToObject(typeof(T), value3);
				}
				return (T)value2;
			}
			catch (InvalidCastException)
			{
				try
				{
					return (T)Convert.ChangeType(value2, typeof(T));
				}
				catch (InvalidCastException)
				{
				}
			}
		}
		return _0023_003Dz0eSiJtQ_003D;
	}

	private void _0023_003DzqPyGv9DziUTibXMhQlUSlS0_003D(devDept.Eyeshot.Entities.Dimension _0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D, ACadSharp.Entities.Dimension _0023_003DzbL11LX8YnXah)
	{
		int dimensionUnit = _0023_003DzbL11LX8YnXah.Style.DimensionUnit;
		if (dimensionUnit < 7)
		{
			_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.LinearDimensionUnits = (linearDimensionUnitsType)dimensionUnit;
		}
		else
		{
			_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.LinearDimensionUnits = linearDimensionUnitsType.Decimal;
		}
		_0023_003Dzfyln692eNua6(_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D, _0023_003DzbL11LX8YnXah);
		_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.ArrowheadSize = _0023_003Dzgd2KpODqkpON(_0023_003DzbL11LX8YnXah, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)41, _0023_003DzbL11LX8YnXah.Style.ArrowSize);
		_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.TextGap = _0023_003Dzgd2KpODqkpON(_0023_003DzbL11LX8YnXah, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)147, _0023_003DzbL11LX8YnXah.Style.DimensionLineGap);
		_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.TextHorizontalPosition = _0023_003DzF8RvkF_0024sf1_0024zpxq4G_00242gJvo_003D(_0023_003DzbL11LX8YnXah.Style.TextHorizontalAlignment);
		_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.TextVerticalPosition = _0023_003Dz0yOsiWvhZV7rteWmhwgDe9k_003D(_0023_003Dzgd2KpODqkpON(_0023_003DzbL11LX8YnXah, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)77, _0023_003DzbL11LX8YnXah.Style.TextVerticalAlignment));
		_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.UseDefaultTextPosition = _0023_003DzbL11LX8YnXah.IsTextUserDefinedLocation;
		short num = _0023_003Dzgd2KpODqkpON(_0023_003DzbL11LX8YnXah, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)178, (short)(-1));
		ACadSharp.Color color = ((num == -1) ? _0023_003DzbL11LX8YnXah.Style.TextColor : new ACadSharp.Color(num));
		if (color.IsByBlock)
		{
			_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.TextColorMethod = colorMethodType.byParent;
		}
		else if (color.IsByLayer)
		{
			_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.TextColorMethod = colorMethodType.byLayer;
		}
		else
		{
			_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.TextColorMethod = colorMethodType.byEntity;
			ACadSharp.Color color2 = color;
			if (color2.Index != -1)
			{
				_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.TextColor = System.Drawing.Color.FromArgb(_0023_003Dz49SxdTbLRNQ4EW5z0A_003D_003D[color2.Index][0], _0023_003Dz49SxdTbLRNQ4EW5z0A_003D_003D[color2.Index][1], _0023_003Dz49SxdTbLRNQ4EW5z0A_003D_003D[color2.Index][2]);
			}
			else
			{
				_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.TextColor = System.Drawing.Color.FromArgb(color2.R, color2.G, color2.B);
			}
		}
		_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.UpperValue = _0023_003Dzgd2KpODqkpON(_0023_003DzbL11LX8YnXah, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)47, _0023_003DzbL11LX8YnXah.Style.PlusTolerance);
		_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.LowerValue = _0023_003Dzgd2KpODqkpON(_0023_003DzbL11LX8YnXah, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)48, _0023_003DzbL11LX8YnXah.Style.MinusTolerance);
		short num2 = _0023_003Dzgd2KpODqkpON(_0023_003DzbL11LX8YnXah, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)71, _0023_003DzbL11LX8YnXah.Style.GenerateTolerances ? ((short)1) : ((short)0));
		short num3 = _0023_003Dzgd2KpODqkpON(_0023_003DzbL11LX8YnXah, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)72, _0023_003DzbL11LX8YnXah.Style.LimitsGeneration ? ((short)1) : ((short)0));
		_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.ToleranceMode = ReadDWG._0023_003DzFEqYFvyI9Oqw((char)num2, (char)num3, _0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.UpperValue, _0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.LowerValue, _0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.TextGap);
		_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.ScalingForHeight = _0023_003DzbL11LX8YnXah.Style.ToleranceScaleFactor;
		if (_0023_003DzbL11LX8YnXah.ExtendedData.TryGet(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004506), out var value))
		{
			for (int i = 0; i < value.Records.Count; i += 2)
			{
				ExtendedDataRecord extendedDataRecord = value.Records[i];
				if (extendedDataRecord.Code == DxfCode.ExtendedDataInteger16 && (short)extendedDataRecord.RawValue == 392)
				{
					_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.ToleranceAlignment = (short)value.Records[i + 1].RawValue == 1;
				}
			}
		}
		_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.ToleranceSuppressLeadingZeros = _0023_003DzbL11LX8YnXah.Style.ToleranceZeroHandling == ZeroHandling.SuppressDecimalLeadingZeroes;
		_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.ToleranceSuppressTralingZeros = _0023_003DzbL11LX8YnXah.Style.ToleranceZeroHandling == ZeroHandling.SuppressDecimalTrailingZeroes;
		_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.TolerancePrecision = _0023_003DzbL11LX8YnXah.Style.AlternateUnitToleranceDecimalPlaces;
		double scaleFactor = _0023_003DzbL11LX8YnXah.Style.ScaleFactor;
		if (scaleFactor != 0.0)
		{
			_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.ScaleOverall = scaleFactor;
		}
		_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.DimStyle = ((_0023_003DzbL11LX8YnXah.Style.Name == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000688)) ? string.Empty : _0023_003DzbL11LX8YnXah.Style.Name);
		if (_0023_003DzbL11LX8YnXah.Style.Style != null)
		{
			_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.StyleName = _0023_003DzbL11LX8YnXah.Style.Style.Name;
			double num4 = _0023_003Dzgd2KpODqkpON(_0023_003DzbL11LX8YnXah, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)4, _0023_003DzbL11LX8YnXah.Style.Style.Height);
			if (num4 != 0.0 && scaleFactor != 0.0)
			{
				_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.Height = num4 / scaleFactor;
			}
		}
	}

	private void _0023_003Dzfyln692eNua6(devDept.Eyeshot.Entities.Dimension _0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D, ACadSharp.Entities.Dimension _0023_003DzbL11LX8YnXah)
	{
		if (_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D is AngularDim)
		{
			int num = _0023_003Dzgd2KpODqkpON(_0023_003DzbL11LX8YnXah, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)79, -1);
			_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.SuppressLeadingZeros = (num & 1) != 0;
			_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.SuppressTrailingZeros = (num & 2) != 0;
		}
		else
		{
			int num2 = (int)_0023_003Dzgd2KpODqkpON(_0023_003DzbL11LX8YnXah, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)78, _0023_003DzbL11LX8YnXah.Style.ZeroHandling);
			_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.SuppressLeadingZeros = ((num2 >> 2) & 1) != 0;
			_0023_003DzLtzEBb4_0024IS7z8hBlzw_003D_003D.SuppressTrailingZeros = ((num2 >> 3) & 1) != 0;
		}
	}

	private devDept.Eyeshot.Entities.Entity _0023_003Dz02YZjgyIS01t(ACadSharp.Entities.Dimension _0023_003Dzow04lCuzeeUF, Plane _0023_003Dzpyw2kZk_003D, Point3D _0023_003DzO97ip_0024TQ_0024juS, Point3D _0023_003DzM7o0gT3hjI42, Point3D _0023_003Dz2AZWQ2NrfVgE, ReadEntityData _0023_003DzELu0Pss_003D, bool _0023_003DzL7uQ2E_DVkh2)
	{
		_0023_003DztCFdmp_0024mpA4_0024(_0023_003Dzow04lCuzeeUF);
		Point3D _0023_003Dzrp9kE6WEdfd = _0023_003Dzmq2_arBswhAA(_0023_003Dzow04lCuzeeUF.TextMiddlePoint);
		Point3D dimLinePos = ReadDWG._0023_003Dz42rkBhNtmyOU(_0023_003Dzpyw2kZk_003D, _0023_003DzM7o0gT3hjI42, _0023_003Dz2AZWQ2NrfVgE, _0023_003Dzrp9kE6WEdfd);
		double textHeight = _0023_003Dzgd2KpODqkpON(_0023_003Dzow04lCuzeeUF, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)140, _0023_003Dzow04lCuzeeUF.Style.TextHeight);
		LinearDim linearDim = new LinearDim(_0023_003Dzpyw2kZk_003D, _0023_003DzO97ip_0024TQ_0024juS, _0023_003DzM7o0gT3hjI42, dimLinePos, textHeight);
		_0023_003DzqPyGv9DziUTibXMhQlUSlS0_003D(linearDim, _0023_003Dzow04lCuzeeUF);
		linearDim.Precision = _0023_003Dzgd2KpODqkpON(_0023_003Dzow04lCuzeeUF, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)271, _0023_003Dzow04lCuzeeUF.Style.DecimalPlaces);
		linearDim.ExtLineOffset = _0023_003Dzgd2KpODqkpON(_0023_003Dzow04lCuzeeUF, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)42, _0023_003Dzow04lCuzeeUF.Style.ExtensionLineOffset);
		linearDim.ExtLineExt = _0023_003Dzgd2KpODqkpON(_0023_003Dzow04lCuzeeUF, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)44, _0023_003Dzow04lCuzeeUF.Style.ExtensionLineExtension);
		linearDim.ShowExtLine1 = !_0023_003Dzow04lCuzeeUF.Style.SuppressFirstExtensionLine;
		linearDim.ShowExtLine2 = !_0023_003Dzow04lCuzeeUF.Style.SuppressSecondExtensionLine;
		linearDim.LeftArrowhead = ReadDWG._0023_003DztE3D9T5XFWfKUjeyuOj6URovAaiP((_0023_003Dzow04lCuzeeUF.Style.DimArrow1 == null) ? string.Empty : _0023_003Dzow04lCuzeeUF.Style.DimArrow1.ToString());
		linearDim.RightArrowhead = ReadDWG._0023_003DztE3D9T5XFWfKUjeyuOj6URovAaiP((_0023_003Dzow04lCuzeeUF.Style.DimArrow2 == null) ? string.Empty : _0023_003Dzow04lCuzeeUF.Style.DimArrow2.ToString());
		linearDim.LinearScale = _0023_003Dzgd2KpODqkpON(_0023_003Dzow04lCuzeeUF, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)144, _0023_003Dzow04lCuzeeUF.Style.LinearScaleFactor);
		ReadDWG._0023_003Dz65vloBQS4N5h(linearDim, _0023_003Dzow04lCuzeeUF.Text, _0023_003Dzgd2KpODqkpON(_0023_003Dzow04lCuzeeUF, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)3, _0023_003Dzow04lCuzeeUF.Style.Prefix));
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(linearDim, _0023_003Dzow04lCuzeeUF, _0023_003DzELu0Pss_003D);
		return linearDim;
	}

	private devDept.Eyeshot.Entities.Entity _0023_003DzoOHtxsENBiu8bEHdgg_003D_003D(DimensionOrdinate _0023_003Dzow04lCuzeeUF, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		if (_0023_003DzLhcuMaKxrATVOuEc6w_003D_003D(_0023_003DzELu0Pss_003D, out var _0023_003Dzs_0024uS8LA_003D, _0023_003Dzow04lCuzeeUF))
		{
			return _0023_003Dzs_0024uS8LA_003D;
		}
		double[] array = _0023_003Dzh4Wf7tlUUlDt(_0023_003Dzow04lCuzeeUF.DefinitionPoint);
		Point3D origin = new Point3D(array);
		Point3D point3D = new Point3D(_0023_003Dzh4Wf7tlUUlDt(_0023_003Dzow04lCuzeeUF.FeatureLocation));
		Point3D point3D2 = new Point3D(_0023_003Dzh4Wf7tlUUlDt(_0023_003Dzow04lCuzeeUF.LeaderEndpoint));
		_0023_003DztCFdmp_0024mpA4_0024(_0023_003Dzow04lCuzeeUF);
		Point3D point3D3 = new Point3D(_0023_003Dzh4Wf7tlUUlDt(_0023_003Dzow04lCuzeeUF.TextMiddlePoint));
		Plane plane = new Plane(new Point3D(array[0], array[1]), Vector3D.AxisX, Vector3D.AxisY);
		if (_0023_003Dzow04lCuzeeUF.TextRotation != 0.0)
		{
			plane.Rotate(0.0 - _0023_003Dzow04lCuzeeUF.TextRotation, plane.AxisZ, point3D);
		}
		plane.Origin = origin;
		Vector3D vector3D = (_0023_003Dzow04lCuzeeUF.IsOrdinateTypeX ? plane.AxisY : plane.AxisX);
		Segment3D seg = new Segment3D(point3D2, point3D2 + vector3D);
		point3D3.ProjectTo(seg);
		OrdinateDim ordinateDim = new OrdinateDim(plane, point3D, point3D3, _0023_003Dzow04lCuzeeUF.IsOrdinateTypeX, _0023_003Dzgd2KpODqkpON(_0023_003Dzow04lCuzeeUF, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)140, _0023_003Dzow04lCuzeeUF.Style.TextHeight));
		_0023_003DzqPyGv9DziUTibXMhQlUSlS0_003D(ordinateDim, _0023_003Dzow04lCuzeeUF);
		ordinateDim.Precision = _0023_003Dzgd2KpODqkpON(_0023_003Dzow04lCuzeeUF, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)271, _0023_003Dzow04lCuzeeUF.Style.DecimalPlaces);
		ordinateDim.ExtLineOffset = _0023_003Dzgd2KpODqkpON(_0023_003Dzow04lCuzeeUF, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)42, _0023_003Dzow04lCuzeeUF.Style.ExtensionLineOffset);
		ordinateDim.LinearScale = _0023_003Dzgd2KpODqkpON(_0023_003Dzow04lCuzeeUF, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)144, _0023_003Dzow04lCuzeeUF.Style.LinearScaleFactor);
		ReadDWG._0023_003Dz65vloBQS4N5h(ordinateDim, _0023_003Dzow04lCuzeeUF.Text, _0023_003Dzgd2KpODqkpON(_0023_003Dzow04lCuzeeUF, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)4, _0023_003Dzow04lCuzeeUF.Style.Prefix));
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(ordinateDim, _0023_003Dzow04lCuzeeUF, _0023_003DzELu0Pss_003D);
		return ordinateDim;
	}

	private bool _0023_003Dzb4pmaVa0CYee(ACadSharp.Entities.Leader _0023_003DzvTsqRaNPdogg)
	{
		bool result = false;
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		ExtendedData extendedData = _0023_003DzvTsqRaNPdogg.ExtendedData.Get(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003763));
		for (int i = 0; i < extendedData.Records.Count; i++)
		{
			if (extendedData.Records[i].Code.GetHashCode() == 40)
			{
				if (extendedData.Records[i + 1].Code == DxfCode.ExtendedDataReal && (short)extendedData.Records[i].RawValue != 0)
				{
					num = (double)extendedData.Records[i + 1].RawValue;
				}
			}
			else if (extendedData.Records[i].Code.GetHashCode() == 41 && extendedData.Records[i + 1].Code == DxfCode.ExtendedDataReal && (short)extendedData.Records[i].RawValue != 0)
			{
				num2 = (double)extendedData.Records[i + 1].RawValue;
			}
		}
		num3 = _0023_003DzvTsqRaNPdogg.Vertices[0].DistanceFrom(_0023_003DzvTsqRaNPdogg.Vertices[1]);
		if (_0023_003DzvTsqRaNPdogg.ArrowHeadEnabled || num2 != 0.0 || num3 >= num2 * num * 2.0)
		{
			result = true;
		}
		return result;
	}

	private devDept.Eyeshot.Entities.Entity _0023_003DzkLREJtM_003D(ACadSharp.Entities.Entity _0023_003DzfpN7pnryJplL, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		ACadSharp.Entities.Leader leader = (ACadSharp.Entities.Leader)_0023_003DzfpN7pnryJplL;
		if (ExplodeDimensions && _0023_003DzLhcuMaKxrATVOuEc6w_003D_003D(_0023_003DzELu0Pss_003D, out var _0023_003Dzs_0024uS8LA_003D, leader))
		{
			return _0023_003Dzs_0024uS8LA_003D;
		}
		Plane pln = _0023_003DzNY5YUv279_SW(leader.BlockOffset, leader.Normal);
		if (leader.AssociatedAnnotation != null)
		{
			ACadSharp.Entities.Entity associatedAnnotation = leader.AssociatedAnnotation;
			if (associatedAnnotation is MText mText)
			{
				pln = new Plane(_0023_003Dzmq2_arBswhAA(mText.InsertPoint), _0023_003DzlvGiL_QdgBbL(mText.Normal));
			}
			else
			{
				if (!(associatedAnnotation is Insert insert))
				{
					throw new NotImplementedException();
				}
				pln = new Plane(_0023_003Dzmq2_arBswhAA(insert.InsertPoint), _0023_003DzlvGiL_QdgBbL(insert.Normal));
			}
		}
		List<Point3D> list = new List<Point3D>();
		int count = leader.Vertices.Count;
		if (count < 2)
		{
			throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303002331));
		}
		for (int i = 0; i < count; i++)
		{
			list.Add(_0023_003Dzmq2_arBswhAA(leader.Vertices[i]));
		}
		arrowheadType arrowhead = ReadDWG._0023_003DztE3D9T5XFWfKUjeyuOj6URovAaiP(leader.Style.Name);
		devDept.Eyeshot.Entities.Leader leader2 = new devDept.Eyeshot.Entities.Leader(pln, list.ToArray(), leader.HasHookline, hookLineOnXDir: false, arrowhead, leader.Style.ArrowSize, leader.Style.ScaleFactor)
		{
			ShowArrowHead = _0023_003Dzb4pmaVa0CYee(leader)
		};
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(leader2, leader, _0023_003DzELu0Pss_003D);
		return leader2;
	}

	private static double[] _0023_003Dzh4Wf7tlUUlDt(XY _0023_003DzlY77YgY_003D)
	{
		return new double[2]
		{
			ReadDWG._0023_003DzgRf1Kl0_003D(_0023_003DzlY77YgY_003D.X),
			ReadDWG._0023_003DzgRf1Kl0_003D(_0023_003DzlY77YgY_003D.Y)
		};
	}

	private static double[] _0023_003DzdZJdWj61QN4u(XYZ _0023_003DzhLyxqqrgjQmH)
	{
		return new double[3]
		{
			ReadDWG._0023_003DzgRf1Kl0_003D(_0023_003DzhLyxqqrgjQmH.X),
			ReadDWG._0023_003DzgRf1Kl0_003D(_0023_003DzhLyxqqrgjQmH.Y),
			ReadDWG._0023_003DzgRf1Kl0_003D(_0023_003DzhLyxqqrgjQmH.Z)
		};
	}

	internal static Vector3D _0023_003DzlvGiL_QdgBbL(XYZ _0023_003DzhLyxqqrgjQmH)
	{
		return new Vector3D(_0023_003DzdZJdWj61QN4u(_0023_003DzhLyxqqrgjQmH));
	}

	internal static double[] _0023_003Dzh4Wf7tlUUlDt(XYZ _0023_003DzlY77YgY_003D)
	{
		return new double[3]
		{
			ReadDWG._0023_003DzgRf1Kl0_003D(_0023_003DzlY77YgY_003D.X),
			ReadDWG._0023_003DzgRf1Kl0_003D(_0023_003DzlY77YgY_003D.Y),
			ReadDWG._0023_003DzgRf1Kl0_003D(_0023_003DzlY77YgY_003D.Z)
		};
	}

	internal static double[] _0023_003Dzh4Wf7tlUUlDt(VertexFaceMesh _0023_003DzlY77YgY_003D)
	{
		return new double[3]
		{
			ReadDWG._0023_003DzgRf1Kl0_003D(_0023_003DzlY77YgY_003D.Location.X),
			ReadDWG._0023_003DzgRf1Kl0_003D(_0023_003DzlY77YgY_003D.Location.Y),
			ReadDWG._0023_003DzgRf1Kl0_003D(_0023_003DzlY77YgY_003D.Location.Z)
		};
	}

	internal static double[] _0023_003Dzh4Wf7tlUUlDt(Vertex3D _0023_003DzlY77YgY_003D)
	{
		return new double[3]
		{
			ReadDWG._0023_003DzgRf1Kl0_003D(_0023_003DzlY77YgY_003D.Location.X),
			ReadDWG._0023_003DzgRf1Kl0_003D(_0023_003DzlY77YgY_003D.Location.Y),
			ReadDWG._0023_003DzgRf1Kl0_003D(_0023_003DzlY77YgY_003D.Location.Z)
		};
	}

	internal static Point3D _0023_003Dzmq2_arBswhAA(XYZ _0023_003DzlY77YgY_003D)
	{
		return new Point3D(_0023_003Dzh4Wf7tlUUlDt(_0023_003DzlY77YgY_003D));
	}

	internal static Point3D _0023_003Dzmq2_arBswhAA(XY _0023_003DzlY77YgY_003D)
	{
		double[] array = _0023_003Dzh4Wf7tlUUlDt(_0023_003DzlY77YgY_003D);
		return new Point3D(array[0], array[1]);
	}

	internal static Point2D _0023_003DzUnxHUznPiV7g(XY _0023_003DzlY77YgY_003D)
	{
		return new Point2D(_0023_003Dzh4Wf7tlUUlDt(_0023_003DzlY77YgY_003D));
	}

	internal static Plane _0023_003DzNY5YUv279_SW(XYZ _0023_003DzeoY7iyo_003D, XYZ _0023_003DzZbOaTIM_003D)
	{
		XYZ _0023_003DzhLyxqqrgjQmH = Matrix3.ArbitraryAxis(_0023_003DzZbOaTIM_003D) * new XYZ(1.0, 0.0, 0.0);
		XYZ _0023_003DzhLyxqqrgjQmH2 = Matrix3.ArbitraryAxis(_0023_003DzZbOaTIM_003D) * new XYZ(0.0, 1.0, 0.0);
		return new Plane(_0023_003Dzmq2_arBswhAA(_0023_003DzeoY7iyo_003D), _0023_003DzlvGiL_QdgBbL(_0023_003DzhLyxqqrgjQmH), _0023_003DzlvGiL_QdgBbL(_0023_003DzhLyxqqrgjQmH2));
	}

	private void _0023_003DztCFdmp_0024mpA4_0024(ACadSharp.Entities.Dimension _0023_003Dzr_3OnS8_003D)
	{
		double[] array = _0023_003Dzh4Wf7tlUUlDt(_0023_003Dzr_3OnS8_003D.TextMiddlePoint);
		if (!_0023_003Dzr_3OnS8_003D.IsTextUserDefinedLocation && Array.TrueForAll(array, (double _0023_003DzXrexKjY_003D) => _0023_003DzXrexKjY_003D == 0.0))
		{
			_0023_003Dzr_3OnS8_003D.UpdateBlock();
		}
	}

	private devDept.Eyeshot.Entities.Entity _0023_003DznW93rAUBvf38(DimensionRadius _0023_003Dzow04lCuzeeUF, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		if (_0023_003DzLhcuMaKxrATVOuEc6w_003D_003D(_0023_003DzELu0Pss_003D, out var _0023_003Dzs_0024uS8LA_003D, _0023_003Dzow04lCuzeeUF))
		{
			return _0023_003Dzs_0024uS8LA_003D;
		}
		Point3D point3D = _0023_003Dzmq2_arBswhAA(_0023_003Dzow04lCuzeeUF.DefinitionPoint);
		Point3D b = _0023_003Dzmq2_arBswhAA(_0023_003Dzow04lCuzeeUF.AngleVertex);
		_0023_003DztCFdmp_0024mpA4_0024(_0023_003Dzow04lCuzeeUF);
		Point3D dimLinePos = _0023_003Dzmq2_arBswhAA(_0023_003Dzow04lCuzeeUF.TextMiddlePoint);
		Plane plane = ReadDWG._0023_003DztIc79mb2zQ0f(_0023_003DzdZJdWj61QN4u(_0023_003Dzow04lCuzeeUF.Normal), 0.0);
		double num = Point3D.Distance(point3D, b);
		if (num < 1E-12)
		{
			log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003092), _0023_003Dzow04lCuzeeUF.Handle));
			return null;
		}
		RadialDim radialDim = new RadialDim(new devDept.Eyeshot.Entities.Circle(plane, point3D, num), dimLinePos, _0023_003Dzgd2KpODqkpON(_0023_003Dzow04lCuzeeUF, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)140, _0023_003Dzow04lCuzeeUF.Style.TextHeight));
		_0023_003DzqPyGv9DziUTibXMhQlUSlS0_003D(radialDim, _0023_003Dzow04lCuzeeUF);
		radialDim.Precision = _0023_003Dzgd2KpODqkpON(_0023_003Dzow04lCuzeeUF, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)271, _0023_003Dzow04lCuzeeUF.Style.DecimalPlaces);
		radialDim.LinearScale = _0023_003Dzgd2KpODqkpON(_0023_003Dzow04lCuzeeUF, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)144, _0023_003Dzow04lCuzeeUF.Style.LinearScaleFactor);
		radialDim.CenterMarkSize = Math.Abs(_0023_003Dzgd2KpODqkpON(_0023_003Dzow04lCuzeeUF, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)141, _0023_003Dzow04lCuzeeUF.Style.CenterMarkSize));
		radialDim.TrimLeader = !_0023_003Dzow04lCuzeeUF.Style.IsExtensionLineLengthFixed;
		ReadDWG._0023_003Dz65vloBQS4N5h(radialDim, _0023_003Dzow04lCuzeeUF.Text, _0023_003Dzgd2KpODqkpON(_0023_003Dzow04lCuzeeUF, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)3, _0023_003Dzow04lCuzeeUF.Style.Prefix));
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(radialDim, _0023_003Dzow04lCuzeeUF, _0023_003DzELu0Pss_003D);
		return radialDim;
	}

	private devDept.Eyeshot.Entities.Entity _0023_003DzuRzGetAm14NIaaQeYNyCkHE_003D(DimensionDiameter _0023_003Dzow04lCuzeeUF, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		if (_0023_003DzLhcuMaKxrATVOuEc6w_003D_003D(_0023_003DzELu0Pss_003D, out var _0023_003Dzs_0024uS8LA_003D, _0023_003Dzow04lCuzeeUF))
		{
			return _0023_003Dzs_0024uS8LA_003D;
		}
		Plane plane = ReadDWG._0023_003DztIc79mb2zQ0f(_0023_003DzdZJdWj61QN4u(_0023_003Dzow04lCuzeeUF.Normal), 0.0);
		plane.Translate(plane.AxisZ * _0023_003Dzow04lCuzeeUF.TextMiddlePoint.Z);
		Point3D point3D = _0023_003Dzmq2_arBswhAA(_0023_003Dzow04lCuzeeUF.AngleVertex);
		Point3D b = _0023_003Dzmq2_arBswhAA(_0023_003Dzow04lCuzeeUF.DefinitionPoint);
		Point3D dimLinePos = plane.PointAt(new Point2D(_0023_003Dzow04lCuzeeUF.TextMiddlePoint.X, _0023_003Dzow04lCuzeeUF.TextMiddlePoint.Y));
		Point3D point3D2 = Point3D.MidPoint(point3D, b);
		double num = Point3D.Distance(point3D2, point3D);
		if (num < 1E-12)
		{
			log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004468), _0023_003Dzow04lCuzeeUF.Handle));
			return null;
		}
		DiametricDim diametricDim = new DiametricDim(new devDept.Eyeshot.Entities.Circle(plane, point3D2, num), dimLinePos, _0023_003Dzgd2KpODqkpON(_0023_003Dzow04lCuzeeUF, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)140, _0023_003Dzow04lCuzeeUF.Style.TextHeight));
		_0023_003DzqPyGv9DziUTibXMhQlUSlS0_003D(diametricDim, _0023_003Dzow04lCuzeeUF);
		diametricDim.Precision = _0023_003Dzgd2KpODqkpON(_0023_003Dzow04lCuzeeUF, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)271, _0023_003Dzow04lCuzeeUF.Style.DecimalPlaces);
		diametricDim.LeftArrowhead = ReadDWG._0023_003DztE3D9T5XFWfKUjeyuOj6URovAaiP((_0023_003Dzow04lCuzeeUF.Style.DimArrow1 == null) ? string.Empty : _0023_003Dzow04lCuzeeUF.Style.DimArrow1.ToString());
		diametricDim.RightArrowhead = ReadDWG._0023_003DztE3D9T5XFWfKUjeyuOj6URovAaiP((_0023_003Dzow04lCuzeeUF.Style.DimArrow2 == null) ? string.Empty : _0023_003Dzow04lCuzeeUF.Style.DimArrow2.ToString());
		diametricDim.LinearScale = _0023_003Dzow04lCuzeeUF.Style.LinearScaleFactor;
		diametricDim.CenterMarkSize = _0023_003Dzgd2KpODqkpON(_0023_003Dzow04lCuzeeUF, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)141, _0023_003Dzow04lCuzeeUF.Style.CenterMarkSize);
		ReadDWG._0023_003Dz65vloBQS4N5h(diametricDim, _0023_003Dzow04lCuzeeUF.Text, _0023_003Dzgd2KpODqkpON(_0023_003Dzow04lCuzeeUF, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)3, _0023_003Dzow04lCuzeeUF.Style.PostFix));
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(diametricDim, _0023_003Dzow04lCuzeeUF, _0023_003DzELu0Pss_003D);
		return diametricDim;
	}

	private void _0023_003Dz6LGpzi9Ck1X_0024(AngularUnitFormat _0023_003DzXD9Cqyhrz4iU, ref AngularDim _0023_003DzaVdSMzhr5rnc)
	{
		switch (_0023_003DzXD9Cqyhrz4iU)
		{
		case AngularUnitFormat.DecimalDegrees:
			_0023_003DzaVdSMzhr5rnc.AngleFormat = angleFormatType.DecimalDegrees;
			break;
		case AngularUnitFormat.DegreesMinutesSeconds:
			_0023_003DzaVdSMzhr5rnc.AngleFormat = angleFormatType.DegMinSec;
			break;
		case AngularUnitFormat.Gradians:
			_0023_003DzaVdSMzhr5rnc.AngleFormat = angleFormatType.Gradians;
			break;
		case AngularUnitFormat.Radians:
			_0023_003DzaVdSMzhr5rnc.AngleFormat = angleFormatType.Radians;
			break;
		}
	}

	private devDept.Eyeshot.Entities.Entity _0023_003DzyXtdDh_3bSdUtCBHlX3aq10_003D(DimensionAngular3Pt _0023_003Dzow04lCuzeeUF, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		if (_0023_003DzLhcuMaKxrATVOuEc6w_003D_003D(_0023_003DzELu0Pss_003D, out var _0023_003Dzs_0024uS8LA_003D, _0023_003Dzow04lCuzeeUF))
		{
			return _0023_003Dzs_0024uS8LA_003D;
		}
		Point3D point3D = _0023_003Dzmq2_arBswhAA(_0023_003Dzow04lCuzeeUF.InsertionPoint);
		Point3D point3D2 = _0023_003Dzmq2_arBswhAA(_0023_003Dzow04lCuzeeUF.FirstPoint);
		Point3D point3D3 = _0023_003Dzmq2_arBswhAA(_0023_003Dzow04lCuzeeUF.SecondPoint);
		Point3D dimLinePos = _0023_003Dzmq2_arBswhAA(_0023_003Dzow04lCuzeeUF.TextMiddlePoint);
		double num = point3D.DistanceTo(point3D2);
		if (num == 0.0 || Point3D.AreEqual(point3D2, point3D3, num))
		{
			log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004428), _0023_003Dzow04lCuzeeUF.Handle));
			return null;
		}
		AngularDim _0023_003DzaVdSMzhr5rnc = new AngularDim(new Plane(point3D, _0023_003DzlvGiL_QdgBbL(_0023_003Dzow04lCuzeeUF.Normal)), point3D2, point3D3, dimLinePos, _0023_003Dzgd2KpODqkpON(_0023_003Dzow04lCuzeeUF, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)140, _0023_003Dzow04lCuzeeUF.Style.TextHeight));
		_0023_003DzaVdSMzhr5rnc.ShowExtLine1 = !_0023_003Dzow04lCuzeeUF.Style.SuppressFirstExtensionLine;
		_0023_003DzaVdSMzhr5rnc.ShowExtLine2 = !_0023_003Dzow04lCuzeeUF.Style.SuppressSecondExtensionLine;
		_0023_003Dz6LGpzi9Ck1X_0024(_0023_003Dzow04lCuzeeUF.Style.AngularUnit, ref _0023_003DzaVdSMzhr5rnc);
		_0023_003DzqPyGv9DziUTibXMhQlUSlS0_003D(_0023_003DzaVdSMzhr5rnc, _0023_003Dzow04lCuzeeUF);
		_0023_003DzaVdSMzhr5rnc.Precision = _0023_003Dzgd2KpODqkpON(_0023_003Dzow04lCuzeeUF, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)271, _0023_003Dzow04lCuzeeUF.Style.DecimalPlaces);
		_0023_003DzaVdSMzhr5rnc.LinearScale = _0023_003Dzow04lCuzeeUF.Style.LinearScaleFactor;
		ReadDWG._0023_003Dz65vloBQS4N5h(_0023_003DzaVdSMzhr5rnc, _0023_003Dzow04lCuzeeUF.Text, _0023_003Dzgd2KpODqkpON(_0023_003Dzow04lCuzeeUF, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)3, _0023_003Dzow04lCuzeeUF.Style.Prefix));
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(_0023_003DzaVdSMzhr5rnc, _0023_003Dzow04lCuzeeUF, _0023_003DzELu0Pss_003D);
		return _0023_003DzaVdSMzhr5rnc;
	}

	private devDept.Eyeshot.Entities.Entity _0023_003DzOLOdi926iMAO4DSdUNx4mF0_003D(DimensionAngular2Line _0023_003Dzow04lCuzeeUF, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		if (_0023_003DzLhcuMaKxrATVOuEc6w_003D_003D(_0023_003DzELu0Pss_003D, out var _0023_003Dzs_0024uS8LA_003D, _0023_003Dzow04lCuzeeUF))
		{
			return _0023_003Dzs_0024uS8LA_003D;
		}
		Point3D quadrantPoint = new Point3D(_0023_003Dzh4Wf7tlUUlDt(_0023_003Dzow04lCuzeeUF.DefinitionPoint));
		Point3D start = new Point3D(_0023_003Dzh4Wf7tlUUlDt(_0023_003Dzow04lCuzeeUF.Center));
		Point3D end = new Point3D(_0023_003Dzh4Wf7tlUUlDt(_0023_003Dzow04lCuzeeUF.FirstPoint));
		Point3D start2 = new Point3D(_0023_003Dzh4Wf7tlUUlDt(_0023_003Dzow04lCuzeeUF.Center));
		Point3D end2 = new Point3D(_0023_003Dzh4Wf7tlUUlDt(_0023_003Dzow04lCuzeeUF.SecondPoint));
		_0023_003DztCFdmp_0024mpA4_0024(_0023_003Dzow04lCuzeeUF);
		Point3D dimLinePos = new Point3D(_0023_003Dzh4Wf7tlUUlDt(_0023_003Dzow04lCuzeeUF.TextMiddlePoint));
		Plane xY = Plane.XY;
		devDept.Eyeshot.Entities.Line line = new devDept.Eyeshot.Entities.Line(start, end);
		devDept.Eyeshot.Entities.Line line2 = new devDept.Eyeshot.Entities.Line(start2, end2);
		AngularDim _0023_003DzaVdSMzhr5rnc = new AngularDim(xY, line, line2, quadrantPoint, dimLinePos, _0023_003Dzow04lCuzeeUF.Style.TextHeight);
		_0023_003Dz6LGpzi9Ck1X_0024(_0023_003Dzow04lCuzeeUF.Style.AngularUnit, ref _0023_003DzaVdSMzhr5rnc);
		_0023_003DzaVdSMzhr5rnc.ShowExtLine1 = !_0023_003Dzow04lCuzeeUF.Style.SuppressFirstExtensionLine;
		_0023_003DzaVdSMzhr5rnc.ShowExtLine2 = !_0023_003Dzow04lCuzeeUF.Style.SuppressSecondExtensionLine;
		_0023_003DzqPyGv9DziUTibXMhQlUSlS0_003D(_0023_003DzaVdSMzhr5rnc, _0023_003Dzow04lCuzeeUF);
		_0023_003DzaVdSMzhr5rnc.Precision = _0023_003Dzgd2KpODqkpON(_0023_003Dzow04lCuzeeUF, (_0023_003DziNJCUHDcmFST3zrMfA_003D_003D)271, _0023_003Dzow04lCuzeeUF.Style.DecimalPlaces);
		_0023_003DzaVdSMzhr5rnc.LinearScale = _0023_003Dzow04lCuzeeUF.Style.LinearScaleFactor;
		ReadDWG._0023_003Dz65vloBQS4N5h(_0023_003DzaVdSMzhr5rnc, _0023_003Dzow04lCuzeeUF.Text, _0023_003Dzow04lCuzeeUF.Style.Prefix);
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(_0023_003DzaVdSMzhr5rnc, _0023_003Dzow04lCuzeeUF, _0023_003DzELu0Pss_003D);
		return _0023_003DzaVdSMzhr5rnc;
	}

	internal static float _0023_003DznZ_0024c4UJBVHLK3svo29coD_0024wi12Ua(LineWeightType _0023_003DzLs5VuQY_003D)
	{
		float result = 0.5f;
		switch (_0023_003DzLs5VuQY_003D)
		{
		case LineWeightType.W0:
			result = 0.01f;
			break;
		case LineWeightType.W5:
			result = 0.05f;
			break;
		case LineWeightType.W9:
			result = 0.09f;
			break;
		case LineWeightType.W13:
			result = 0.13f;
			break;
		case LineWeightType.W15:
			result = 0.15f;
			break;
		case LineWeightType.W18:
			result = 0.18f;
			break;
		case LineWeightType.W20:
			result = 0.2f;
			break;
		case LineWeightType.W25:
			result = 0.25f;
			break;
		case LineWeightType.W30:
			result = 0.3f;
			break;
		case LineWeightType.W35:
			result = 0.35f;
			break;
		case LineWeightType.W40:
			result = 0.4f;
			break;
		case LineWeightType.W50:
			result = 0.5f;
			break;
		case LineWeightType.W53:
			result = 0.53f;
			break;
		case LineWeightType.W60:
			result = 0.6f;
			break;
		case LineWeightType.W70:
			result = 0.7f;
			break;
		case LineWeightType.W80:
			result = 0.8f;
			break;
		case LineWeightType.W100:
			result = 1f;
			break;
		case LineWeightType.W106:
			result = 1.06f;
			break;
		case LineWeightType.W120:
			result = 1.2f;
			break;
		case LineWeightType.W140:
			result = 1.4f;
			break;
		case LineWeightType.W158:
			result = 1.58f;
			break;
		case LineWeightType.W200:
			result = 2f;
			break;
		case LineWeightType.W211:
			result = 2.11f;
			break;
		case LineWeightType.Default:
			result = 0.25f;
			break;
		}
		return result;
	}

	private void _0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(devDept.Eyeshot.Entities.IEntity _0023_003DzTb8sVfuysOroSa7Xag_003D_003D, AttributeEntity _0023_003Dzsfha7fxK63yo, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		if (_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.AutodeskProperties == null)
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.AutodeskProperties = new AutodeskProperties();
		}
		_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.Visible = !_0023_003Dzsfha7fxK63yo.IsInvisible;
		string layerName = (_0023_003DzELu0Pss_003D.testLayer.Name = _0023_003Dzsfha7fxK63yo.Layer.Name);
		_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LayerName = layerName;
		if (!base.Layers.Contains(_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LayerName))
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LayerName = base.Layers[0].Name;
		}
		if (_0023_003Dzsfha7fxK63yo.LineWeight == LineWeightType.ByBlock)
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineWeightMethod = colorMethodType.byParent;
		}
		else if (_0023_003Dzsfha7fxK63yo.LineWeight == LineWeightType.ByLayer)
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineWeightMethod = colorMethodType.byLayer;
		}
		else
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineWeightMethod = colorMethodType.byEntity;
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineWeight = _0023_003DznZ_0024c4UJBVHLK3svo29coD_0024wi12Ua(_0023_003Dzsfha7fxK63yo.LineWeight);
		}
		if (_0023_003Dzsfha7fxK63yo.Color.IsByBlock)
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.ColorMethod = colorMethodType.byParent;
		}
		else if (_0023_003Dzsfha7fxK63yo.Color.IsByLayer)
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.ColorMethod = colorMethodType.byLayer;
		}
		else
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.ColorMethod = colorMethodType.byEntity;
			ACadSharp.Color color = _0023_003Dzsfha7fxK63yo.Color;
			short num = _0023_003Dzsfha7fxK63yo.Transparency.Value;
			if (num < 0 || num > 255)
			{
				num = 255;
			}
			if (color.IsTrueColor)
			{
				_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.Color = System.Drawing.Color.FromArgb(num, color.R, color.G, color.B);
			}
			else if (color.Index == 7)
			{
				_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.Color = System.Drawing.Color.FromArgb(num, ForegroundColor);
			}
			else
			{
				byte[] array = _0023_003Dz49SxdTbLRNQ4EW5z0A_003D_003D[color.Index];
				_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.Color = System.Drawing.Color.FromArgb(array[0], array[1], array[2]);
			}
		}
		if (_0023_003Dzsfha7fxK63yo.LineType?.Name == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988767))
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineTypeMethod = colorMethodType.byParent;
		}
		else if (_0023_003Dzsfha7fxK63yo.LineType?.Name == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988749))
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineTypeMethod = colorMethodType.byLayer;
		}
		else if (_0023_003Dzsfha7fxK63yo.LineType?.Name == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988731))
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineTypeMethod = colorMethodType.byEntity;
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineTypeName = null;
		}
		else if (_0023_003DzELu0Pss_003D.importedLinetypes.Contains(_0023_003Dzsfha7fxK63yo.LineType.Name))
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineTypeMethod = colorMethodType.byEntity;
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineTypeName = _0023_003Dzsfha7fxK63yo.LineType.Name;
		}
		_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineTypeScale = (float)_0023_003Dzsfha7fxK63yo.LineTypeScale;
		if (_0023_003Dzsfha7fxK63yo.ExtendedData != null)
		{
			List<KeyValuePair<short, object>> list = _0023_003DzFXVV5876DzAvpbgquA_003D_003D(_0023_003Dzsfha7fxK63yo.ExtendedData);
			if (list.Count > 0)
			{
				_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.AutodeskProperties.XData = list;
			}
		}
	}

	private void _0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(devDept.Eyeshot.Entities.IEntity _0023_003DzTb8sVfuysOroSa7Xag_003D_003D, ACadSharp.Entities.Entity _0023_003DzfpN7pnryJplL, ReadEntityData _0023_003DzELu0Pss_003D)
	{
		if (_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.AutodeskProperties == null)
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.AutodeskProperties = new AutodeskProperties();
		}
		_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.Visible = !_0023_003DzfpN7pnryJplL.IsInvisible;
		string layerName = (_0023_003DzELu0Pss_003D.testLayer.Name = _0023_003DzfpN7pnryJplL.Layer.Name);
		_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LayerName = layerName;
		if (!base.Layers.Contains(_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LayerName))
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LayerName = base.Layers[0].Name;
		}
		if (_0023_003DzfpN7pnryJplL.LineWeight == LineWeightType.ByBlock)
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineWeightMethod = colorMethodType.byParent;
		}
		else if (_0023_003DzfpN7pnryJplL.LineWeight == LineWeightType.ByLayer)
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineWeightMethod = colorMethodType.byLayer;
		}
		else
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineWeightMethod = colorMethodType.byEntity;
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineWeight = _0023_003DznZ_0024c4UJBVHLK3svo29coD_0024wi12Ua(_0023_003DzfpN7pnryJplL.LineWeight);
		}
		if (_0023_003DzfpN7pnryJplL.Color.IsByBlock)
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.ColorMethod = colorMethodType.byParent;
		}
		else if (_0023_003DzfpN7pnryJplL.Color.IsByLayer)
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.ColorMethod = colorMethodType.byLayer;
		}
		else
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.ColorMethod = colorMethodType.byEntity;
			ACadSharp.Color color = _0023_003DzfpN7pnryJplL.Color;
			int alpha = _0023_003DzQxq0CDHnkW4A(_0023_003DzfpN7pnryJplL.Transparency);
			if (color.IsTrueColor)
			{
				_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.Color = System.Drawing.Color.FromArgb(alpha, color.R, color.G, color.B);
			}
			else if (color.Index == 7)
			{
				_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.Color = System.Drawing.Color.FromArgb(alpha, ForegroundColor);
			}
			else
			{
				byte[] array = _0023_003Dz49SxdTbLRNQ4EW5z0A_003D_003D[color.Index];
				_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.Color = System.Drawing.Color.FromArgb(array[0], array[1], array[2]);
			}
		}
		if (string.Equals(_0023_003DzfpN7pnryJplL.LineType.Name, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000377), StringComparison.OrdinalIgnoreCase))
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineTypeMethod = colorMethodType.byParent;
		}
		else if (string.Equals(_0023_003DzfpN7pnryJplL.LineType.Name, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303000359), StringComparison.OrdinalIgnoreCase))
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineTypeMethod = colorMethodType.byLayer;
		}
		else if (string.Equals(_0023_003DzfpN7pnryJplL.LineType.Name, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004611), StringComparison.OrdinalIgnoreCase))
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineTypeMethod = colorMethodType.byEntity;
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineTypeName = null;
		}
		else if (_0023_003DzELu0Pss_003D.importedLinetypes.Contains(_0023_003DzfpN7pnryJplL.LineType.Name))
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineTypeMethod = colorMethodType.byEntity;
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineTypeName = _0023_003DzfpN7pnryJplL.LineType.Name;
		}
		_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LineTypeScale = (float)_0023_003DzfpN7pnryJplL.LineTypeScale;
		if (_0023_003DzfpN7pnryJplL.ExtendedData.Count() != 0)
		{
			List<KeyValuePair<short, object>> list = _0023_003DzFXVV5876DzAvpbgquA_003D_003D(_0023_003DzfpN7pnryJplL.ExtendedData);
			if (list.Count > 0)
			{
				_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.AutodeskProperties.XData = list;
			}
		}
	}

	private devDept.Eyeshot.Entities.Entity _0023_003Dz1vzybyo_003D(ACadSharp.Entities.Entity _0023_003DzfpN7pnryJplL, ReadEntityData _0023_003DzELu0Pss_003D, StringBuilder _0023_003DzFdTKfve582KK)
	{
		ACadSharp.Entities.Solid solid = (ACadSharp.Entities.Solid)_0023_003DzfpN7pnryJplL;
		XYZ[] array = new XYZ[4] { solid.FirstCorner, solid.SecondCorner, solid.ThirdCorner, solid.FourthCorner };
		Point3D[] array2 = new Point3D[4];
		for (short num = 0; num < 4; num++)
		{
			array2[num] = _0023_003Dzmq2_arBswhAA(array[num]);
		}
		Vector3D _0023_003DzZbOaTIM_003D = new Vector3D(_0023_003DzdZJdWj61QN4u(solid.Normal));
		devDept.Eyeshot.Entities.Entity entity = AutodeskUtility.ReadSolid(array2, _0023_003DzZbOaTIM_003D, solid.Thickness, _0023_003DzfpN7pnryJplL.Handle.ToString(), log);
		_0023_003DzyafclRO7C1wbmLZDCQ_003D_003D(entity, solid, _0023_003DzELu0Pss_003D);
		return entity;
	}

	public bool SetView(IViewport viewport)
	{
		return _0023_003DzAbd0a0sUY4t0eHwgcQ_003D_003D._0023_003Dzvk_j02M_003D(viewport.Camera, viewport.Size);
	}
}
