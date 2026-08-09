using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using ODA.Drawings.TD_DbCoreIntegrated;
using ODA.Kernel.TD_RootIntegrated;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class AppendAutodesk : WriteAutodesk
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Stream _0023_003DztLLy0oEAfLTc;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly string _0023_003DzYkXw7UFfGS38;

	public AppendAutodesk(Document document, Stream inputStream, Stream outputStream, bool aciColors = true, bool asciiStream = false, bool selectedOnly = false)
		: base(document, outputStream, WriteAutodesk._0023_003Dz3jripO4_003D, aciColors, asciiStream, selectedOnly)
	{
		_0023_003DztLLy0oEAfLTc = inputStream;
	}

	public AppendAutodesk(DesignDocument design, Stream inputStream, Stream outputStream, autodeskVersionType version, bool aciColors = true, bool asciiStream = false, bool selectedOnly = false)
		: base(design, outputStream, version, aciColors, asciiStream, selectedOnly)
	{
		_0023_003DztLLy0oEAfLTc = inputStream;
	}

	public AppendAutodesk(DesignDocument design, Stream inputStream, Stream outputStream, autodeskVersionType version, double deviation, bool aciColors = true, bool asciiStream = false, bool selectedOnly = false)
		: base(design, outputStream, version, deviation, aciColors, asciiStream, selectedOnly)
	{
		_0023_003DztLLy0oEAfLTc = inputStream;
	}

	public AppendAutodesk(DesignDocument design, string inputFilePath, string outputFilePath, bool aciColors = true, bool selectedOnly = false)
		: base(design, outputFilePath, aciColors, selectedOnly)
	{
		_0023_003DzYkXw7UFfGS38 = inputFilePath;
	}

	public AppendAutodesk(DesignDocument design, string inputFilePath, string outputFilePath, autodeskVersionType version, bool aciColors = true, bool selectedOnly = false)
		: base(design, outputFilePath, version, aciColors, selectedOnly)
	{
		_0023_003DzYkXw7UFfGS38 = inputFilePath;
	}

	public AppendAutodesk(DesignDocument design, string inputFilePath, string outputFilePath, autodeskVersionType version, string password, double deviation, bool aciColors = true, bool selectedOnly = false)
		: base(design, outputFilePath, version, password, deviation, aciColors, selectedOnly)
	{
		_0023_003DzYkXw7UFfGS38 = inputFilePath;
	}

	public AppendAutodesk(IDesign design, string inputFilePath, string outputFilePath, IDrawing drawing = null)
		: this(new WriteAutodeskParams(design.Document, drawing?.Document), inputFilePath, outputFilePath)
	{
	}

	public AppendAutodesk(IDesign design, Stream inputStream, Stream outputStream, IDrawing drawing = null)
		: this(new WriteAutodeskParams(design.Document, drawing?.Document), inputStream, outputStream)
	{
	}

	public AppendAutodesk(WriteAutodeskParams writeAutodeskParams, Stream inputStream, Stream outputStream)
		: base(writeAutodeskParams, outputStream)
	{
		_0023_003DztLLy0oEAfLTc = inputStream;
	}

	public AppendAutodesk(WriteAutodeskParams writeAutodeskParams, string inputFilePath, string outputFilePath)
		: base(writeAutodeskParams, outputFilePath)
	{
		_0023_003DzYkXw7UFfGS38 = inputFilePath;
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public AppendAutodesk(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, IDictionary<string, TextStyle> textStyleDict, IDictionary<string, LineType> lineTypes, Stream inputStream, Stream outputStream, bool aciColors = true, bool asciiStream = false, bool selectedOnly = false)
		: base(entList, layerList, blockDict, textStyleDict, lineTypes, outputStream, linearUnitsType.Centimeters, aciColors, asciiStream, selectedOnly)
	{
		_0023_003DztLLy0oEAfLTc = inputStream;
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public AppendAutodesk(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, IDictionary<string, TextStyle> textStyleDict, IDictionary<string, LineType> lineTypes, Stream inputStream, Stream outputStream, autodeskVersionType version, bool aciColors = true, bool asciiStream = false, bool selectedOnly = false)
		: base(entList, layerList, blockDict, textStyleDict, lineTypes, outputStream, linearUnitsType.Centimeters, version, aciColors, asciiStream, selectedOnly)
	{
		_0023_003DztLLy0oEAfLTc = inputStream;
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public AppendAutodesk(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, IDictionary<string, TextStyle> textStyleDict, IDictionary<string, LineType> lineTypes, Stream inputStream, Stream outputStream, autodeskVersionType version = autodeskVersionType.Release12, double deviation = 0.01, bool aciColors = true, bool asciiStream = false, bool selectedOnly = false)
		: base(entList, layerList, blockDict, textStyleDict, lineTypes, null, outputStream, linearUnitsType.Centimeters, version, deviation, aciColors, asciiStream, selectedOnly)
	{
		_0023_003DztLLy0oEAfLTc = inputStream;
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public AppendAutodesk(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, IDictionary<string, TextStyle> textStyleDict, IDictionary<string, LineType> lineTypes, string inputFilePath, string outputFilePath, bool aciColors = true, bool selectedOnly = false)
		: base(entList, layerList, blockDict, textStyleDict, lineTypes, outputFilePath, linearUnitsType.Centimeters, aciColors, selectedOnly)
	{
		_0023_003DzYkXw7UFfGS38 = inputFilePath;
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public AppendAutodesk(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, IDictionary<string, TextStyle> textStyleDict, IDictionary<string, LineType> lineTypes, string inputFilePath, string outputFilePath, autodeskVersionType version, bool aciColors = true, bool selectedOnly = false)
		: base(entList, layerList, blockDict, textStyleDict, lineTypes, outputFilePath, linearUnitsType.Centimeters, version, aciColors, selectedOnly)
	{
		_0023_003DzYkXw7UFfGS38 = inputFilePath;
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public AppendAutodesk(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, IDictionary<string, TextStyle> textStyleDict, IDictionary<string, LineType> lineTypes, string inputFilePath, string outputFilePath, autodeskVersionType version, string password, double deviation, bool aciColors = true, bool selectedOnly = false)
		: base(entList, layerList, blockDict, textStyleDict, lineTypes, null, outputFilePath, linearUnitsType.Centimeters, version, password, deviation, aciColors, selectedOnly)
	{
		_0023_003DzYkXw7UFfGS38 = inputFilePath;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003Dz59lijRsT8LI_0024XHJOQ_0024AIGNJAuo4Gno8YZbyXhC6NbIN90_6Sbg_003D_003D._0023_003DzdzZLZbiwVTg1a0D6OXj_pZ7Vxsm1I1oH6u_0024_fyl4AGtqqQqxXQ_003D_003D()._0023_003DzcuxJrsHQF_Rj5c_67u2AJCIjdCLa(_0023_003Dz59lijRsT8LI_0024XHJOQ_0024AIGNJAuo4Gno8YZbyXhC6NbIN90_6Sbg_003D_003D._0023_003Dz9h7prLD836B0_0024F42nFw7qcyRyorkXYYKZ0vX9bIws0q0ILDt6g_003D_003D(), "p&4miq\"adM", array);
		MemoryTransaction memoryTransaction = MemoryManager.GetMemoryManager().StartTransaction();
		try
		{
			string empty = string.Empty;
			IList<Entity> myEntities = GetEntities();
			PrepareForWriting(empty, null, myEntities, layers, blocks, textStyles, lineTypes, materials, out var _, out var textStylesToSave, out var lineTypesToSave, out var materialsToSave, out var _, out var currXRefPaths, out var blocksToSave);
			ExHostAppServices exHostAppServices = new ExHostAppServices();
			memoryTransaction.AddObject(exHostAppServices);
			exHostAppServices.disableOutput(disable: true);
			OdDbDatabase odDbDatabase = exHostAppServices.createDatabase(createDefault: false);
			bool flag2 = false;
			Stream stream;
			if (!string.IsNullOrEmpty(_0023_003DzYkXw7UFfGS38))
			{
				stream = new FileStream(_0023_003DzYkXw7UFfGS38, FileMode.Open, FileAccess.Read, FileShare.Read);
				flag2 = true;
			}
			else
			{
				stream = _0023_003DztLLy0oEAfLTc;
			}
			try
			{
				OdMemoryStream odMemoryStream = OdMemoryStream.createNew();
				_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003Dz_0024Ri82GA5O_VX(stream, odMemoryStream);
				OdDbAuditInfo odDbAuditInfo = new OdDbAuditInfo();
				odDbDatabase.readFile(odMemoryStream, partialLoad: false, odDbAuditInfo, password, allowCPConversion: false);
				odDbAuditInfo.Dispose();
				units = WriteDatabase._0023_003DzCpSZHkwMYNQHhZOwlA_003D_003D(odDbDatabase.getINSUNITS());
			}
			catch (Exception ex)
			{
				log.AppendLine(ex.Message);
				log.AppendLine();
			}
			finally
			{
				if (flag2)
				{
					stream.Close();
				}
			}
			_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzSothfIG2mlbP();
			WriteDatabaseInternal(empty, myEntities, progress, ct, odDbDatabase, layers, blocksToSave, currXRefPaths, textStylesToSave, lineTypesToSave, materialsToSave, attributeReferenceVisibilityMode, lineTypeScale, append: true);
		}
		catch (Exception ex2)
		{
			log.AppendLine(ex2.Message);
			throw new EyeshotException(ex2.Message, ex2);
		}
		finally
		{
			MemoryManager.GetMemoryManager().StopTransaction(memoryTransaction);
		}
	}
}
