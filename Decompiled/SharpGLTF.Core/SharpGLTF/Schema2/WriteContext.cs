using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SharpGLTF.Memory;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

public class WriteContext : WriteSettings
{
	private readonly FileWriterCallback _ByteWriter;

	private readonly Func<string, Stream> _StreamWriter;

	public DirectoryInfo CurrentDirectory { get; private set; }

	internal bool _UpdateSupportedExtensions { get; private set; } = true;

	internal bool _NoCloneWatchdog { get; private set; }

	public static WriteContext Create(FileWriterCallback fileCallback, Func<string, Stream> streamWriteCallback = null)
	{
		Guard.NotNull(fileCallback, "fileCallback");
		return new WriteContext(fileCallback, streamWriteCallback)
		{
			_UpdateSupportedExtensions = true
		};
	}

	public static WriteContext CreateFromDirectory(DirectoryInfo dinfo)
	{
		Guard.NotNull(dinfo, "dinfo");
		Guard.MustExist(dinfo, "dinfo");
		WriteContext writeContext = Create(_writeBytes, _OpenStream);
		writeContext.ImageWriting = ResourceWriteMode.Default;
		writeContext.JsonIndented = true;
		writeContext.CurrentDirectory = dinfo;
		return writeContext;
		Stream _OpenStream(string rawUri)
		{
			string path = Uri.UnescapeDataString(rawUri);
			path = Path.Combine(dinfo.FullName, path);
			return File.Create(path);
		}
		void _writeBytes(string rawUri, ArraySegment<byte> data)
		{
			string path = Uri.UnescapeDataString(rawUri);
			path = Path.Combine(dinfo.FullName, path);
			using FileStream fileStream = File.Create(path);
			fileStream.Write(data.Array, data.Offset, data.Count);
		}
	}

	public static WriteContext CreateFromDictionary(IDictionary<string, ArraySegment<byte>> dict)
	{
		Guard.NotNull(dict, "dict");
		WriteContext writeContext = Create(delegate(string rawUri, ArraySegment<byte> data)
		{
			dict[rawUri] = data;
		});
		writeContext.ImageWriting = ResourceWriteMode.SatelliteFile;
		writeContext.MergeBuffers = false;
		writeContext.JsonIndented = false;
		return writeContext;
	}

	public static WriteContext CreateFromStream(Stream stream)
	{
		Guard.NotNull(stream, "stream");
		Guard.IsTrue(stream.CanWrite, "stream");
		WriteContext writeContext = Create(delegate(string fn, ArraySegment<byte> d)
		{
			stream.Write(d.Array, d.Offset, d.Count);
		});
		writeContext.ImageWriting = ResourceWriteMode.Default;
		writeContext.MergeBuffers = true;
		writeContext.JsonIndented = false;
		return writeContext.WithBinarySettings();
	}

	public WriteContext WithTextSettings()
	{
		if (base.ImageWriting == ResourceWriteMode.Default)
		{
			base.ImageWriting = ResourceWriteMode.SatelliteFile;
		}
		if (base.ImageWriting == ResourceWriteMode.BufferView)
		{
			base.ImageWriting = ResourceWriteMode.SatelliteFile;
		}
		return this;
	}

	public WriteContext WithBinarySettings()
	{
		if (base.ImageWriting == ResourceWriteMode.Default)
		{
			base.ImageWriting = ResourceWriteMode.BufferView;
		}
		if (base.ImageWriting == ResourceWriteMode.EmbeddedAsBase64)
		{
			base.ImageWriting = ResourceWriteMode.BufferView;
		}
		base.MergeBuffers = true;
		base.JsonIndented = false;
		return this;
	}

	public WriteContext WithSettingsFrom(WriteSettings settings)
	{
		settings?.CopyTo(this);
		return this;
	}

	internal WriteContext WithDeepCloneSettings()
	{
		_UpdateSupportedExtensions = false;
		_NoCloneWatchdog = true;
		base.MergeBuffers = false;
		return this;
	}

	private WriteContext(FileWriterCallback byteWriteCallback, Func<string, Stream> streamWriteCallback)
	{
		_ByteWriter = byteWriteCallback;
		_StreamWriter = streamWriteCallback;
	}

	public void WriteAllBytesToEnd(string fileName, ArraySegment<byte> data)
	{
		_ByteWriter(fileName, data);
	}

	public string WriteImage(string assetName, MemoryImage image)
	{
		ImageWriterCallback imageWriterCallback = base.ImageWriteCallback;
		if (imageWriterCallback == null)
		{
			imageWriterCallback = delegate(WriteContext ctx, string apath, MemoryImage img)
			{
				ctx.WriteAllBytesToEnd(apath, img._GetBuffer());
				return apath;
			};
		}
		return imageWriterCallback(this, assetName, image);
	}

	public void WriteTextSchema2(string name, ModelRoot model)
	{
		Guard.NotNullOrEmpty(name, "name");
		Guard.FilePathMustBeValid(name, "name");
		if (Path.IsPathRooted(name))
		{
			throw new ArgumentException("path must be relative", "name");
		}
		Guard.NotNull(model, "model");
		bool imagesAsBufferViews = base.ImageWriting == ResourceWriteMode.BufferView;
		model = _PreprocessSchema2(model, imagesAsBufferViews, base.MergeBuffers, base.BuffersMaxSize);
		Guard.NotNull(model, "model");
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(name);
		model._PrepareBuffersForSatelliteWriting(this, fileNameWithoutExtension);
		model._PrepareImagesForWriting(this, fileNameWithoutExtension, isBinary: false, ResourceWriteMode.SatelliteFile);
		_ValidateBeforeWriting(model);
		string text = (Path.HasExtension(name) ? name : (name + ".gltf"));
		if (_StreamWriter != null)
		{
			using Stream sw = _StreamWriter(text);
			model._WriteJSON(sw, base.JsonOptions, base.JsonPostprocessor);
		}
		else
		{
			using MemoryStream memoryStream = new MemoryStream();
			model._WriteJSON(memoryStream, base.JsonOptions, base.JsonPostprocessor);
			WriteAllBytesToEnd(text, memoryStream.ToArraySegment());
		}
		model._AfterWriting();
	}

	public void WriteBinarySchema2(string name, ModelRoot model)
	{
		Guard.NotNullOrEmpty(name, "name");
		Guard.FilePathMustBeValid(name, "name");
		if (Path.IsPathRooted(name))
		{
			throw new ArgumentException("path must be relative", "name");
		}
		Guard.NotNull(model, "model");
		bool imagesAsBufferViews = base.ImageWriting != ResourceWriteMode.SatelliteFile;
		model = _PreprocessSchema2(model, imagesAsBufferViews, mergeBuffers: true, int.MaxValue);
		Guard.NotNull(model, "model");
		Exception ex = _BinarySerialization.IsBinaryCompatible(model);
		if (ex != null)
		{
			throw ex;
		}
		model._PrepareBuffersForInternalWriting();
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(name);
		model._PrepareImagesForWriting(this, fileNameWithoutExtension, isBinary: true, ResourceWriteMode.BufferView);
		_ValidateBeforeWriting(model);
		string text = (Path.HasExtension(name) ? name : (name + ".glb"));
		if (_StreamWriter != null)
		{
			using Stream output = _StreamWriter(text);
			using BinaryWriter binaryWriter = new BinaryWriter(output);
			binaryWriter.WriteBinaryModel(model);
		}
		else
		{
			using MemoryStream memoryStream = new MemoryStream();
			using (BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream))
			{
				binaryWriter2.WriteBinaryModel(model);
			}
			WriteAllBytesToEnd(text, memoryStream.ToArraySegment());
		}
		model._AfterWriting();
	}

	private void _ValidateBeforeWriting(ModelRoot model)
	{
		if (!_NoCloneWatchdog && base.Validation != ValidationMode.Skip)
		{
			ValidationResult validationResult = new ValidationResult(model, base.Validation);
			model.ValidateReferences(validationResult.GetContext());
			Exception ex = validationResult.Errors.FirstOrDefault();
			if (ex != null)
			{
				throw ex;
			}
			model.ValidateContent(validationResult.GetContext());
			ex = validationResult.Errors.FirstOrDefault();
			if (ex != null)
			{
				throw ex;
			}
		}
	}

	private ModelRoot _PreprocessSchema2(ModelRoot model, bool imagesAsBufferViews, bool mergeBuffers, int buffersMaxSize)
	{
		Guard.NotNull(model, "model");
		foreach (Image logicalImage in model.LogicalImages)
		{
			if (!logicalImage._HasContent)
			{
				throw new DataException(logicalImage, "Image Content is missing.");
			}
		}
		if (model.LogicalImages.Count == 0)
		{
			imagesAsBufferViews = false;
		}
		if (model.LogicalBuffers.Count <= 1 && !imagesAsBufferViews)
		{
			mergeBuffers = false;
		}
		if (mergeBuffers || imagesAsBufferViews)
		{
			if (_NoCloneWatchdog)
			{
				throw new InvalidOperationException("Current settings require creating a densive copy before model modification, but calling DeepClone is not allowed with the current settings.");
			}
			model = model.DeepClone();
		}
		if (imagesAsBufferViews)
		{
			model.MergeImages();
		}
		if (mergeBuffers)
		{
			if (buffersMaxSize == int.MaxValue)
			{
				model.MergeBuffers();
			}
			else
			{
				model.MergeBuffers(buffersMaxSize);
			}
		}
		if (_UpdateSupportedExtensions)
		{
			model.UpdateExtensionsSupport();
		}
		return model;
	}
}
