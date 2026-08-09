using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading;
using SharpGLTF.Schema2;

namespace SharpGLTF.IO;

public sealed class ZipWriter : IDisposable
{
	private ZipArchive _Archive;

	public ZipWriter(string zipPath, Encoding encoding = null)
	{
		_Archive = ((encoding == null) ? ZipFile.Open(zipPath, ZipArchiveMode.Create) : ZipFile.Open(zipPath, ZipArchiveMode.Create, encoding));
	}

	public ZipWriter(Stream zipStream, bool leaveOpen = false, Encoding encoding = null)
	{
		_Archive = ((encoding == null) ? new ZipArchive(zipStream, ZipArchiveMode.Create, leaveOpen) : new ZipArchive(zipStream, ZipArchiveMode.Create, leaveOpen, encoding));
	}

	public void Dispose()
	{
		Interlocked.Exchange(ref _Archive, null)?.Dispose();
	}

	public void AddModel(string filePath, ModelRoot model, WriteSettings settings = null)
	{
		SharpGLTF.Guard.NotNullOrEmpty(filePath, "filePath");
		SharpGLTF.Guard.NotNull(model, "model");
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
		bool flag = filePath.EndsWith(".GLTF", StringComparison.OrdinalIgnoreCase);
		WriteContext writeContext = WriteContext.Create(_WriteAsset);
		if (flag)
		{
			writeContext.WithTextSettings();
		}
		else
		{
			writeContext.WithBinarySettings();
		}
		settings?.CopyTo(writeContext);
		if (flag)
		{
			writeContext.WriteTextSchema2(fileNameWithoutExtension, model);
		}
		else
		{
			writeContext.WriteBinarySchema2(fileNameWithoutExtension, model);
		}
	}

	private void _WriteAsset(string filePath, ArraySegment<byte> bytes)
	{
		ZipArchiveEntry zipArchiveEntry = _Archive.CreateEntry(filePath);
		using Stream stream = zipArchiveEntry.Open();
		stream.Write(bytes.Array, bytes.Offset, bytes.Count);
	}
}
