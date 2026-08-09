using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Translators;

public class WriteFile : WriteFileAsyncWithDrawings
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<Entity, bool> _0023_003DzXxUuNy3uXlhVbmH2Yw_003D_003D;

		internal bool _0023_003Dzc8jGYPUx71p_5_0024Hzy8V_0024WiiGuQrniXqL_A_003D_003D(Entity _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.Selected;
		}
	}

	protected MaterialKeyedCollection materials;

	protected contentType content = contentType.GeometryAndTessellation;

	protected serializationType serializationMode;

	protected int version = Serializer.LastVersion;

	protected FileSerializer FileSerializer;

	protected string tag;

	protected bool purge;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Block _0023_003DzK8Kwyo8MF5AD;

	protected internal bool saveThumbnail;

	protected internal Color thumbnailBackgroundColor;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal byte[] _0023_003Dzes3OoosNHoOi6yRH1w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Camera _0023_003Dz10qtbIGWAWjL;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal DesignDocument _0023_003DzcoG1S4w_003D;

	public static supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.All;

	public WriteFile(WriteFileParams writeFileParams, string filePath, FileSerializer fileSerializer = null)
		: base(writeFileParams, filePath)
	{
		_0023_003DzVnfAoovaoMa7(writeFileParams, fileSerializer);
	}

	public WriteFile(DesignDocument designDocument, string filePath, FileSerializer fileSerializer = null)
		: this(new WriteFileParams(designDocument), filePath, fileSerializer)
	{
	}

	public WriteFile(IDesign design, string filePath, FileSerializer fileSerializer = null)
		: this(design.Document, filePath, fileSerializer)
	{
	}

	public WriteFile(DesignDocument designDocument, DrawingDocument drawingDocument, string filePath, FileSerializer fileSerializer = null)
		: this(new WriteFileParams(designDocument, drawingDocument), filePath, fileSerializer)
	{
	}

	public WriteFile(IDesign design, IDrawing drawing, string filePath, FileSerializer fileSerializer = null)
		: this(design.Document, drawing.Document, filePath, fileSerializer)
	{
	}

	public WriteFile(WriteFileParams writeFileParams, Stream stream, FileSerializer fileSerializer = null)
		: base(writeFileParams, stream)
	{
		_0023_003DzVnfAoovaoMa7(writeFileParams, fileSerializer);
	}

	public WriteFile(DesignDocument designDocument, Stream stream, FileSerializer fileSerializer = null)
		: this(new WriteFileParams(designDocument), stream, fileSerializer)
	{
	}

	public WriteFile(IDesign design, Stream stream, FileSerializer fileSerializer = null)
		: this(design.Document, stream, fileSerializer)
	{
	}

	public WriteFile(DesignDocument designDocument, DrawingDocument drawingDocument, Stream stream, FileSerializer fileSerializer = null)
		: this(new WriteFileParams(designDocument, drawingDocument), stream, fileSerializer)
	{
	}

	public WriteFile(IDesign design, IDrawing drawing, Stream stream, FileSerializer fileSerializer = null)
		: this(design.Document, drawing.Document, stream, fileSerializer)
	{
	}

	private void _0023_003DzVnfAoovaoMa7(WriteFileParams _0023_003DzRZgBnidtSRIp, FileSerializer _0023_003DzMTgjTZQ_003D)
	{
		version = _0023_003DzRZgBnidtSRIp.Version;
		content = _0023_003DzRZgBnidtSRIp.Content;
		serializationMode = _0023_003DzRZgBnidtSRIp.SerializationMode;
		tag = _0023_003DzRZgBnidtSRIp.Tag;
		materials = new MaterialKeyedCollection(_0023_003DzRZgBnidtSRIp.Materials);
		FileSerializer = _0023_003DzMTgjTZQ_003D;
		purge = _0023_003DzRZgBnidtSRIp.Purge;
		saveThumbnail = _0023_003DzRZgBnidtSRIp.SaveThumbnail;
		thumbnailBackgroundColor = _0023_003DzRZgBnidtSRIp.ThumbnailBackgroundColor;
		_0023_003DzcoG1S4w_003D = _0023_003DzRZgBnidtSRIp._0023_003DzcoG1S4w_003D;
		lineTypeScale = _0023_003DzRZgBnidtSRIp.LineTypeScale;
		PurgeCollectionsForOpenBlock(ref materials, ref textStyles, ref lineTypes, ref hatchPatterns);
	}

	protected override void InitLayers(LayerKeyedCollection layerCollection)
	{
		layers = new LayerKeyedCollection(layerCollection);
	}

	internal void PrepareEnvironmentData()
	{
		if (_0023_003DzcoG1S4w_003D?.workspace == null)
		{
			return;
		}
		if (_0023_003DzcoG1S4w_003D.workspace.Viewports.Count > 0)
		{
			_0023_003Dz10qtbIGWAWjL = _0023_003DzcoG1S4w_003D.workspace.ActiveViewport.Camera;
		}
		if (_0023_003Dz10qtbIGWAWjL == null)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011349));
		}
		if (saveThumbnail)
		{
			_0023_003Dzes3OoosNHoOi6yRH1w_003D_003D = _0023_003Dzq6bQ7tI_003D(_0023_003DzcoG1S4w_003D.workspace, thumbnailBackgroundColor);
			if (_0023_003Dzes3OoosNHoOi6yRH1w_003D_003D == null)
			{
				log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011522));
			}
		}
	}

	internal static byte[] _0023_003Dzq6bQ7tI_003D(IWorkspaceInternal _0023_003DzDh_00246Paw_003D, Color _0023_003DzuWsJo1NcW_0024DNwggNZAu8vnY_003D)
	{
		return _0023_003DzDh_00246Paw_003D.GetThumbnailBytes(256, _0023_003DzuWsJo1NcW_0024DNwggNZAu8vnY_003D.IsEmpty ? Color.White : _0023_003DzuWsJo1NcW_0024DNwggNZAu8vnY_003D);
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"ac>", array);
		if (!SupportedLinearUnitsType.HasFlag(Utility.GetSupportedLinearUnits(units)))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302925401) + units);
		}
		_0023_003DzyypUlU_QQEqN(progress, ct);
	}

	internal virtual void _0023_003DzyypUlU_QQEqN(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		try
		{
			if (_0023_003Dzes3OoosNHoOi6yRH1w_003D_003D == null)
			{
				PrepareEnvironmentData();
			}
			Stream stream = base.Stream ?? File.Open(base.FilePath, FileMode.Create, FileAccess.Write);
			SetWriter(new StreamWriter(stream));
			FileHeader fileHeader = new FileHeader(version, content, serializationMode, _0023_003Dz_EydSol_JO59(), units);
			fileHeader.Author = author;
			fileHeader.Organization = organization;
			fileHeader.OriginatingSystem = originatingSystem;
			fileHeader.Tag = tag;
			fileHeader._0023_003Dz9TTXsLAw_0024c31(_0023_003Dzes3OoosNHoOi6yRH1w_003D_003D);
			fileHeader._0023_003Dz4Xm4mt_0024I0cX4 = base.FilePath;
			FileHeader header = fileHeader;
			IList<Entity> _0023_003Dzv7xH9gk_003D = _0023_003Dz2C9s0fA51oG9W2QlBcjjQew_003D();
			SynchronizeAttributeReference(blocks, _0023_003Dzv7xH9gk_003D);
			SynchronizeAttributeReference(Drawing);
			FileBody fileBody = new FileBody(_0023_003Dzv7xH9gk_003D, layers, blocks, materials, textStyles, lineTypes, hatchPatterns, _0023_003Dz10qtbIGWAWjL, lineTypeScale, content, Drawing);
			_0023_003DzZag1e9zhSIvR(fileBody);
			if (FileSerializer == null)
			{
				FileSerializer = new FileSerializer();
			}
			FileSerializer.SerializeFile(header, fileBody, stream);
			if (!string.IsNullOrEmpty(FileSerializer.Log))
			{
				log.AppendLine(FileSerializer.Log);
			}
		}
		catch (Exception ex)
		{
			if (FileSerializer != null && !string.IsNullOrEmpty(FileSerializer.Log))
			{
				log.AppendLine(FileSerializer.Log);
			}
			string message = ex.Message;
			log.AppendLine(message);
			throw new EyeshotException(message, ex);
		}
		finally
		{
			CloseStream();
		}
	}

	internal virtual void _0023_003DzZag1e9zhSIvR(FileBody _0023_003Dzk347ngQ_003D)
	{
	}

	internal virtual fileType _0023_003Dz_EydSol_JO59()
	{
		return fileType.Standard;
	}

	internal IList<Entity> _0023_003Dz2C9s0fA51oG9W2QlBcjjQew_003D()
	{
		IList<Entity> list = entities;
		if (selectedOnly || purge)
		{
			list = GetEntities().ToList();
			if (selectedOnly)
			{
				list = list.Where((Entity _0023_003DzBJFJHwk_003D) => _0023_003DzBJFJHwk_003D.Selected).ToList();
			}
			if (purge)
			{
				if (_0023_003DzK8Kwyo8MF5AD != null)
				{
					list.Add(new BlockReference(new Identity(), _0023_003DzK8Kwyo8MF5AD.Name));
				}
				Utility.Purge(list, layers, blocks, materials, textStyles, lineTypes, hatchPatterns, out var _0023_003DzfchAzPg_003D, out var _0023_003DzTKSsuc0_003D, out var _0023_003DzvEAegzCu5KMnKFso0g_003D_003D, out var _0023_003DzIm3oyxMBrWGo, out var _0023_003Dzl0O9h6oxpm0u, out var _0023_003Dz3b479cSvol0G);
				if (_0023_003DzK8Kwyo8MF5AD != null)
				{
					list.RemoveAt(list.Count - 1);
				}
				layers = _0023_003DzfchAzPg_003D;
				blocks = _0023_003DzTKSsuc0_003D;
				materials = _0023_003DzvEAegzCu5KMnKFso0g_003D_003D;
				textStyles = _0023_003DzIm3oyxMBrWGo;
				lineTypes = _0023_003Dzl0O9h6oxpm0u;
				hatchPatterns = _0023_003Dz3b479cSvol0G;
			}
			if (entities.Count == 0 && blocks.hasRootBlock)
			{
				blocks.RootBlock.Entities.ClearNoDispose();
				blocks.RootBlock.Entities.baseList.AddRange(list);
				list.Clear();
			}
		}
		return list;
	}
}
