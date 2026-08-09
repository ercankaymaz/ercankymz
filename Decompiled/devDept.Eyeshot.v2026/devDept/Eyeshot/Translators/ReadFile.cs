using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Translators;

public class ReadFile : ReadFileAsyncWithDrawing, IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private FileSerializer _0023_003DzkKL7BMiINe9Raf1VgQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzkFtH0pRJB_bPYCDMHVkiNfw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Camera _0023_003DzGyIsDk_u4amx6yBl9w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz26_00248B_0024PgVWAku_Pja4AmkCI_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private FileHeader _0023_003Dz7Qy7DSdFKkvzGd2oiw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dzytdi0LcbNcuRtTlS0SF6P5CorCz1r2T5lN11lhWdviYJ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzAxOQKaPza_00249KGtkJ0XCpouGIbiEpot7g_g_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz347mOYRr_SPguA3bbeCNfYctO6i0xIf7eSFmM6E_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dzv_0024NMia8SXs8HcYske48DPemimubnoo99EUrHmTOlUp9mgKkTCQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzdMNwkSoQEg4AaYXugERpTiVDQawjl5lduQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzAUbpFSWC_0024OidyrpyBGbUrGOSBc7SxCH72r_0024Pa_A_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzLceB1A3KI_0024PNoig4RLUXw7x6d7cPZrXOuQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzTvpoLe3UyuYYci4P85cixDlAShTflt6UW8lrIxEuImba;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzVhVJd2rl0uS92aRwhnVqij_0024Lo0RlI5l0nwB5TyaqOXIi;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzbjPJjH_0024aHCcGsGDREOidYvF0_0024Kpi8ME9Cg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzXU5AYIy5b42vDm_zLgv1Zct4LsalEF4pqhC6A0qoX9G9;

	public override supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.All;

	public FileSerializer FileSerializer
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzkKL7BMiINe9Raf1VgQ_003D_003D;
		}
	}

	public bool HeaderOnly
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzkFtH0pRJB_bPYCDMHVkiNfw_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzkFtH0pRJB_bPYCDMHVkiNfw_003D = value;
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
		protected set
		{
			_0023_003DzGyIsDk_u4amx6yBl9w_003D_003D = value;
		}
	}

	public bool RestoreCamera
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz26_00248B_0024PgVWAku_Pja4AmkCI_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz26_00248B_0024PgVWAku_Pja4AmkCI_003D = value;
		}
	}

	public FileHeader FileHeader
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz7Qy7DSdFKkvzGd2oiw_003D_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003Dz7Qy7DSdFKkvzGd2oiw_003D_003D = value;
		}
	}

	public string DrawingsSilhouettesLayerName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzytdi0LcbNcuRtTlS0SF6P5CorCz1r2T5lN11lhWdviYJ;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzytdi0LcbNcuRtTlS0SF6P5CorCz1r2T5lN11lhWdviYJ = value;
		}
	}

	public string DrawingsEdgesLayerName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzAxOQKaPza_00249KGtkJ0XCpouGIbiEpot7g_g_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzAxOQKaPza_00249KGtkJ0XCpouGIbiEpot7g_g_003D_003D = value;
		}
	}

	public string DrawingsWiresLayerName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz347mOYRr_SPguA3bbeCNfYctO6i0xIf7eSFmM6E_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz347mOYRr_SPguA3bbeCNfYctO6i0xIf7eSFmM6E_003D = value;
		}
	}

	public string DrawingsHiddenSilhouettesLayerName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzv_0024NMia8SXs8HcYske48DPemimubnoo99EUrHmTOlUp9mgKkTCQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzv_0024NMia8SXs8HcYske48DPemimubnoo99EUrHmTOlUp9mgKkTCQ_003D_003D = value;
		}
	}

	public string DrawingsHiddenEdgesLayerName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzdMNwkSoQEg4AaYXugERpTiVDQawjl5lduQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzdMNwkSoQEg4AaYXugERpTiVDQawjl5lduQ_003D_003D = value;
		}
	}

	public string DrawingsHiddenWiresLayerName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzAUbpFSWC_0024OidyrpyBGbUrGOSBc7SxCH72r_0024Pa_A_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzAUbpFSWC_0024OidyrpyBGbUrGOSBc7SxCH72r_0024Pa_A_003D = value;
		}
	}

	public string DrawingsSectionsLayerName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzLceB1A3KI_0024PNoig4RLUXw7x6d7cPZrXOuQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzLceB1A3KI_0024PNoig4RLUXw7x6d7cPZrXOuQ_003D_003D = value;
		}
	}

	public string DrawingsGhostCirclesLayerName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzTvpoLe3UyuYYci4P85cixDlAShTflt6UW8lrIxEuImba;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzTvpoLe3UyuYYci4P85cixDlAShTflt6UW8lrIxEuImba = value;
		}
	}

	public string DrawingsCenterlinesLayerName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzVhVJd2rl0uS92aRwhnVqij_0024Lo0RlI5l0nwB5TyaqOXIi;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzVhVJd2rl0uS92aRwhnVqij_0024Lo0RlI5l0nwB5TyaqOXIi = value;
		}
	}

	public string DrawingsHiddenSegmentsLineTypeName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzbjPJjH_0024aHCcGsGDREOidYvF0_0024Kpi8ME9Cg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzbjPJjH_0024aHCcGsGDREOidYvF0_0024Kpi8ME9Cg_003D_003D = value;
		}
	}

	public string DrawingsCenterlinesLineTypeName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzXU5AYIy5b42vDm_zLgv1Zct4LsalEF4pqhC6A0qoX9G9;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzXU5AYIy5b42vDm_zLgv1Zct4LsalEF4pqhC6A0qoX9G9 = value;
		}
	}

	public ReadFile(string filePath, bool headerOnly = false, contentType deserializationType = contentType.GeometryAndTessellation)
		: base(filePath)
	{
		_0023_003DzNUNzgvVNEKvS(deserializationType, headerOnly);
	}

	public ReadFile(string filePath, contentType deserializationType)
		: this(filePath, headerOnly: false, deserializationType)
	{
	}

	public ReadFile(string filePath, FileSerializer fileSerializer, bool headerOnly = false)
		: base(filePath)
	{
		if (fileSerializer == null)
		{
			_0023_003DzNUNzgvVNEKvS(contentType.GeometryAndTessellation, headerOnly);
			return;
		}
		_0023_003Dzbn_00246tJWR1oBQ(fileSerializer);
		HeaderOnly = headerOnly;
	}

	public ReadFile(Stream stream, bool headerOnly = false, contentType deserializationType = contentType.GeometryAndTessellation)
		: base(stream)
	{
		_0023_003DzNUNzgvVNEKvS(deserializationType, headerOnly);
	}

	public ReadFile(Stream stream, contentType deserializationType)
		: this(stream, headerOnly: false, deserializationType)
	{
	}

	public ReadFile(Stream stream, FileSerializer fileSerializer, bool headerOnly = false)
		: base(stream)
	{
		if (fileSerializer == null)
		{
			_0023_003DzNUNzgvVNEKvS(contentType.GeometryAndTessellation, headerOnly);
			return;
		}
		_0023_003Dzbn_00246tJWR1oBQ(fileSerializer);
		HeaderOnly = headerOnly;
	}

	private void _0023_003Dzbn_00246tJWR1oBQ(FileSerializer _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzkKL7BMiINe9Raf1VgQ_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public string GetFileInfo()
	{
		return GetHeader()?.Dump();
	}

	public FileHeader GetHeader()
	{
		if (FileHeader == null)
		{
			if (FileSerializer?.FileHeader == null)
			{
				bool headerOnly = HeaderOnly;
				HeaderOnly = true;
				_0023_003DzQmK9lgk_003D();
				HeaderOnly = headerOnly;
			}
			FileHeader = FileSerializer.FileHeader;
		}
		return FileHeader;
	}

	public int GetVersion()
	{
		GetHeader();
		if (FileHeader != null)
		{
			return FileHeader.Version;
		}
		return FileSerializer.HeaderVersion;
	}

	public byte[] GetThumbnail()
	{
		GetFileInfo();
		if (FileHeader?.Thumbnail == null)
		{
			return null;
		}
		return FileHeader?.Thumbnail;
	}

	public static string GetFileInfo(string filePath)
	{
		ReadMultiFile readMultiFile = new ReadMultiFile(filePath, headerOnly: true);
		try
		{
			return readMultiFile.GetFileInfo();
		}
		finally
		{
			((IDisposable)readMultiFile).Dispose();
		}
	}

	public static FileHeader GetHeader(string filePath)
	{
		ReadMultiFile readMultiFile = new ReadMultiFile(filePath, headerOnly: true);
		try
		{
			return readMultiFile.GetHeader();
		}
		finally
		{
			((IDisposable)readMultiFile).Dispose();
		}
	}

	public static int GetVersion(string filePath)
	{
		ReadMultiFile readMultiFile = new ReadMultiFile(filePath, headerOnly: true);
		try
		{
			return readMultiFile.GetVersion();
		}
		finally
		{
			((IDisposable)readMultiFile).Dispose();
		}
	}

	public static byte[] GetThumbnail(string filePath)
	{
		ReadMultiFile readMultiFile = new ReadMultiFile(filePath, headerOnly: true);
		try
		{
			return readMultiFile.GetThumbnail();
		}
		finally
		{
			((IDisposable)readMultiFile).Dispose();
		}
	}

	private void _0023_003DzNUNzgvVNEKvS(contentType _0023_003DzrYFEu6aczQ_00244OD90yksFbh_00240gUFi, bool _0023_003DzV4vJqyK_WX_B)
	{
		_0023_003Dzbn_00246tJWR1oBQ(new FileSerializer(_0023_003DzrYFEu6aczQ_00244OD90yksFbh_00240gUFi));
		HeaderOnly = _0023_003DzV4vJqyK_WX_B;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"ac>", array);
		_0023_003DziovQPjxLLGlj(progress, ct);
	}

	internal void _0023_003DzQmK9lgk_003D()
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"ac>", array);
		_0023_003DziovQPjxLLGlj(null, default(CancellationToken));
	}

	internal virtual void _0023_003DziovQPjxLLGlj(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		bool result = false;
		try
		{
			_0023_003DzspExml1j72mr_FI04NKW780_003D _0023_003DzspExml1j72mr_FI04NKW780_003D2 = new _0023_003DzspExml1j72mr_FI04NKW780_003D();
			try
			{
				StartContinuousAnimation(base.ReadingText, _0023_003DzmHS7frs_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + System.IO.Path.GetFileName(base.FilePath));
				if (HeaderOnly)
				{
					FileSerializer._0023_003DzXNfmF6NWSjv_0024(base.Stream);
				}
				else
				{
					FileSerializer.Deserialize(base.Stream);
					base.Blocks = FileSerializer.FileBody.Blocks;
					base.Layers = FileSerializer.FileBody.Layers;
					base.Materials = FileSerializer.FileBody.Materials;
					base.LineTypes = FileSerializer.FileBody.LineTypes;
					base.HatchPatterns = FileSerializer.FileBody.HatchPatterns;
					base.TextStyles = FileSerializer.FileBody.TextStyles;
					if (!base.Blocks.hasRootBlock)
					{
						base.Blocks._0023_003Dz2tUjc04_003D();
					}
					IList<Entity> entities = FileSerializer.FileBody.Entities;
					if (entities != null && entities.Count > 0)
					{
						base.Blocks.RootBlock.Entities.AddRange(FileSerializer.FileBody.Entities);
					}
					Camera = FileSerializer.FileBody.Camera;
					base.LineTypeScale = FileSerializer.FileBody.LineTypeScale;
					DrawingsSilhouettesLayerName = FileSerializer.FileBody.DrawingSilhouettesLayerName;
					DrawingsEdgesLayerName = FileSerializer.FileBody.DrawingEdgesLayerName;
					DrawingsWiresLayerName = FileSerializer.FileBody.DrawingWiresLayerName;
					DrawingsHiddenSilhouettesLayerName = FileSerializer.FileBody.DrawingHiddenSilhouettesLayerName;
					DrawingsHiddenEdgesLayerName = FileSerializer.FileBody.DrawingHiddenEdgesLayerName;
					DrawingsHiddenWiresLayerName = FileSerializer.FileBody.DrawingHiddenWiresLayerName;
					DrawingsSectionsLayerName = FileSerializer.FileBody.DrawingSectionsLayerName;
					DrawingsCenterlinesLayerName = FileSerializer.FileBody.DrawingCenterlinesLayerName;
					DrawingsHiddenSegmentsLineTypeName = FileSerializer.FileBody.DrawingHiddenSegmentsLineTypeName;
					DrawingsCenterlinesLineTypeName = FileSerializer.FileBody.DrawingCenterlinesLineTypeName;
					base.DrawingSheets = FileSerializer.FileBody.DrawingSheets;
					base.DrawingBlocks = FileSerializer.FileBody.DrawingBlocks;
					base.DrawingLayers = FileSerializer.FileBody.DrawingLayers;
					base.DrawingLineTypes = FileSerializer.FileBody.DrawingLineTypes;
					base.DrawingHatchPatterns = FileSerializer.FileBody.DrawingHatchPatterns;
					base.DrawingTextStyles = FileSerializer.FileBody.DrawingTextStyles;
				}
				FileHeader = FileSerializer.FileHeader;
				base.Units = FileHeader.Units;
				if (!string.IsNullOrEmpty(FileSerializer.Log))
				{
					log.AppendLine(FileSerializer.Log);
				}
				result = true;
			}
			finally
			{
				((IDisposable)_0023_003DzspExml1j72mr_FI04NKW780_003D2).Dispose();
			}
		}
		catch (Exception ex)
		{
			if (!string.IsNullOrEmpty(FileSerializer.Log))
			{
				log.AppendLine(FileSerializer.Log);
			}
			log.AppendLine(ex.Message);
		}
		finally
		{
			if (HeaderOnly)
			{
				base.Stream.Seek(0L, SeekOrigin.Begin);
			}
			else
			{
				CloseStream();
			}
		}
		base.Result = result;
	}

	public override void ImportSettings(Document document)
	{
		if (Camera != null && RestoreCamera && document is DesignDocument)
		{
			document.workspace?.RestoreView(Camera);
		}
		base.ImportSettings(document);
	}

	public void Dispose()
	{
		CloseStream();
	}
}
