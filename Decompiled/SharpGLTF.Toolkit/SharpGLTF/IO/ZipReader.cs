using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using SharpGLTF.Schema2;

namespace SharpGLTF.IO;

public sealed class ZipReader : IDisposable
{
	private ZipArchive _Archive;

	public IEnumerable<string> ModelFiles => from item in _GetEntries()
		select item.FullName;

	public static ModelRoot LoadModelFromZip(string zipPath, ReadSettings settings = null)
	{
		using ZipReader zipReader = new ZipReader(zipPath);
		return zipReader.LoadModel(settings);
	}

	public ZipReader(string zipPath, Encoding encoding = null)
	{
		_Archive = ((encoding == null) ? ZipFile.Open(zipPath, ZipArchiveMode.Read) : ZipFile.Open(zipPath, ZipArchiveMode.Read, encoding));
	}

	public ZipReader(Stream zipStream, bool leaveOpen = false, Encoding encoding = null)
	{
		_Archive = ((encoding == null) ? new ZipArchive(zipStream, ZipArchiveMode.Read, leaveOpen) : new ZipArchive(zipStream, ZipArchiveMode.Read, leaveOpen, encoding));
	}

	public void Dispose()
	{
		Interlocked.Exchange(ref _Archive, null)?.Dispose();
	}

	private IEnumerable<ZipArchiveEntry> _GetEntries()
	{
		return from item in _Archive.Entries
			where item.FullName.EndsWith(".gltf", StringComparison.OrdinalIgnoreCase) || item.FullName.EndsWith(".glb", StringComparison.OrdinalIgnoreCase)
			orderby item.FullName
			select item;
	}

	public ModelRoot LoadModel(ReadSettings settings = null)
	{
		string gltfFile = ModelFiles.First();
		return LoadModel(gltfFile, settings);
	}

	public ModelRoot LoadModel(string gltfFile, ReadSettings settings = null)
	{
		ReadContext readContext = ReadContext.Create(_ReadAsset).WithSettingsFrom(settings);
		return readContext.ReadSchema2(gltfFile);
	}

	private ArraySegment<byte> _ReadAsset(string rawUri)
	{
		string filePath = Uri.UnescapeDataString(rawUri);
		ZipArchiveEntry zipArchiveEntry = _FindEntry(filePath);
		using Stream stream = zipArchiveEntry.Open();
		using MemoryStream memoryStream = new MemoryStream();
		stream.CopyTo(memoryStream);
		if (memoryStream.TryGetBuffer(out var buffer))
		{
			return buffer;
		}
		return new ArraySegment<byte>(memoryStream.ToArray());
	}

	private ZipArchiveEntry _FindEntry(string filePath)
	{
		ZipArchiveEntry zipArchiveEntry = _Archive.Entries.FirstOrDefault((ZipArchiveEntry item) => item.FullName.Equals(filePath, StringComparison.OrdinalIgnoreCase));
		if (zipArchiveEntry == null)
		{
			throw new FileNotFoundException(filePath);
		}
		return zipArchiveEntry;
	}
}
