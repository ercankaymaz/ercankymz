using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

public class ReadContext : ReadSettings
{
	private UriResolver _UriResolver;

	private FileReaderCallback _FileReader;

	private byte[] _BinaryChunk;

	internal bool _CheckSupportedExtensions { get; private set; } = true;

	public static ReadContext Create(FileReaderCallback callback)
	{
		Guard.NotNull(callback, "callback");
		return new ReadContext(callback);
	}

	public static ReadContext CreateFromDirectory(DirectoryInfo dinfo)
	{
		Guard.NotNull(dinfo, "dinfo");
		Guard.MustExist(dinfo, "dinfo");
		return new ReadContext(_loadFile, _uriSolver);
		ArraySegment<byte> _loadFile(string rawUri)
		{
			string path = _uriSolver(rawUri);
			byte[] array = File.ReadAllBytes(path);
			return new ArraySegment<byte>(array);
		}
		string _uriSolver(string rawUri)
		{
			string path = Uri.UnescapeDataString(rawUri);
			return Path.Combine(dinfo.FullName, path);
		}
	}

	public static ReadContext CreateFromDictionary(IReadOnlyDictionary<string, ArraySegment<byte>> dictionary, bool checkExtensions = true)
	{
		return new ReadContext((string rawUri) => dictionary[rawUri], null, checkExtensions);
	}

	private ReadContext(FileReaderCallback reader, UriResolver uriResolver = null, bool checkExtensions = true)
	{
		_FileReader = reader;
		_UriResolver = uriResolver;
		_CheckSupportedExtensions = checkExtensions;
	}

	public ReadContext WithSettingsFrom(ReadSettings settings)
	{
		settings?.CopyTo(this);
		return this;
	}

	internal ReadContext(ReadContext other)
		: base(other)
	{
		_FileReader = other._FileReader;
		base.ImageDecoder = other.ImageDecoder;
	}

	public bool TryGetFullPath(string relativeUri, out string fullPath)
	{
		if (_UriResolver == null)
		{
			fullPath = null;
			return false;
		}
		fullPath = _UriResolver(relativeUri);
		return true;
	}

	public Stream OpenFile(string resourceName)
	{
		ArraySegment<byte> arraySegment = ReadAllBytesToEnd(resourceName);
		return new MemoryStream(arraySegment.Array, arraySegment.Offset, arraySegment.Count);
	}

	public ArraySegment<byte> ReadAllBytesToEnd(string resourceName)
	{
		if (_BinaryChunk != null && string.IsNullOrEmpty(resourceName))
		{
			return new ArraySegment<byte>(_BinaryChunk);
		}
		return _FileReader(resourceName);
	}

	public ValidationResult Validate(string resourceName)
	{
		Guard.FilePathMustBeValid(resourceName, "resourceName");
		if (Path.IsPathRooted(resourceName))
		{
			throw new ArgumentException("path must be relative", "resourceName");
		}
		ArraySegment<byte> arraySegment = ReadAllBytesToEnd(resourceName);
		if (!_BinarySerialization.IsBinaryHeader(arraySegment))
		{
			return _Read(arraySegment).Validation;
		}
		using MemoryStream stream = new MemoryStream(arraySegment.Array, arraySegment.Offset, arraySegment.Count, writable: false);
		return _ReadGLB(stream).Validation;
	}

	public ModelRoot ReadSchema2(string resourceName)
	{
		Guard.FilePathMustBeValid(resourceName, "resourceName");
		if (Path.IsPathRooted(resourceName))
		{
			throw new ArgumentException("path must be relative", "resourceName");
		}
		ArraySegment<byte> arraySegment = ReadAllBytesToEnd(resourceName);
		using MemoryStream stream = new MemoryStream(arraySegment.Array, arraySegment.Offset, arraySegment.Count, writable: false);
		return ReadSchema2(stream);
	}

	public ModelRoot ReadSchema2(Stream stream)
	{
		Guard.NotNull(stream, "stream");
		Guard.IsTrue(stream.CanRead, "stream");
		if (!_BinarySerialization._Identify(stream))
		{
			return ReadTextSchema2(stream);
		}
		return ReadBinarySchema2(stream);
	}

	public ModelRoot ReadTextSchema2(Stream stream)
	{
		Guard.NotNull(stream, "stream");
		Guard.IsTrue(stream.CanRead, "stream");
		Memory<byte> memory = stream.ReadBytesToEnd();
		return _FilterErrors(_Read(memory));
	}

	public ModelRoot ReadBinarySchema2(Stream stream)
	{
		Guard.NotNull(stream, "stream");
		Guard.IsTrue(stream.CanRead, "stream");
		return _FilterErrors(_ReadGLB(stream));
	}

	private static ModelRoot _FilterErrors((ModelRoot Model, ValidationResult Validation) mv)
	{
		if (mv.Validation.HasErrors)
		{
			Exception ex = mv.Validation.Errors.FirstOrDefault();
			ModelException._Decorate(ex);
			throw ex;
		}
		return mv.Model;
	}

	private (ModelRoot Model, ValidationResult Validation) _ReadGLB(Stream stream)
	{
		Guard.NotNull(stream, "stream");
		IReadOnlyDictionary<uint, byte[]> readOnlyDictionary;
		try
		{
			readOnlyDictionary = _BinarySerialization.ReadBinaryFile(stream);
		}
		catch (EndOfStreamException schemaError)
		{
			ValidationResult validationResult = new ValidationResult(null, base.Validation);
			validationResult.SetSchemaError(schemaError);
			return (Model: null, Validation: validationResult);
		}
		catch (SchemaException error)
		{
			ValidationResult validationResult2 = new ValidationResult(null, base.Validation);
			validationResult2.SetError(error);
			return (Model: null, Validation: validationResult2);
		}
		ReadContext readContext = this;
		if (readOnlyDictionary.ContainsKey(5130562u))
		{
			byte[] binaryChunk = readOnlyDictionary[5130562u];
			readContext = new ReadContext(readContext);
			readContext._BinaryChunk = binaryChunk;
		}
		byte[] array = readOnlyDictionary[1313821514u];
		return readContext._Read(array);
	}

	private (ModelRoot Model, ValidationResult Validation) _Read(ReadOnlyMemory<byte> jsonUtf8Bytes)
	{
		ModelRoot modelRoot = new ModelRoot();
		ValidationResult validationResult = new ValidationResult(modelRoot, base.Validation);
		try
		{
			if (jsonUtf8Bytes.IsEmpty)
			{
				throw new JsonException("JSon is empty.");
			}
			jsonUtf8Bytes = _Preprocess(jsonUtf8Bytes);
			Utf8JsonReader reader = new Utf8JsonReader(jsonUtf8Bytes.Span);
			if (!reader.Read())
			{
				validationResult.SetSchemaError(modelRoot, "Json is empty");
				return (Model: null, Validation: validationResult);
			}
			modelRoot.Deserialize(ref reader);
			modelRoot.OnDeserializationCompleted();
			foreach (Buffer logicalBuffer in modelRoot.LogicalBuffers)
			{
				logicalBuffer.OnValidateBinaryChunk(validationResult.GetContext(), _BinaryChunk);
			}
			if (_CheckSupportedExtensions)
			{
				modelRoot._ValidateExtensions(validationResult.GetContext());
				Exception ex = validationResult.Errors.FirstOrDefault();
				if (ex != null)
				{
					return (Model: null, Validation: validationResult);
				}
			}
			if (base.Validation != ValidationMode.Skip)
			{
				modelRoot.ValidateReferences(validationResult.GetContext());
				Exception ex2 = validationResult.Errors.FirstOrDefault();
				if (ex2 != null)
				{
					return (Model: null, Validation: validationResult);
				}
			}
			modelRoot._ResolveSatelliteDependencies(this);
			if (base.Validation != ValidationMode.Skip)
			{
				modelRoot.ValidateContent(validationResult.GetContext());
				Exception ex3 = validationResult.Errors.FirstOrDefault();
				if (ex3 != null)
				{
					return (Model: null, Validation: validationResult);
				}
			}
		}
		catch (JsonException ex4)
		{
			validationResult.SetSchemaError(modelRoot, ex4);
			return (Model: null, Validation: validationResult);
		}
		catch (FormatException modelError)
		{
			validationResult.SetModelError(modelError);
			return (Model: null, Validation: validationResult);
		}
		catch (ArgumentException ex5)
		{
			validationResult.SetModelError(modelRoot, ex5);
			return (Model: null, Validation: validationResult);
		}
		catch (ModelException error)
		{
			validationResult.SetError(error);
			return (Model: null, Validation: validationResult);
		}
		return (Model: modelRoot, Validation: validationResult);
	}

	private ReadOnlyMemory<byte> _Preprocess(ReadOnlyMemory<byte> jsonUtf8Bytes)
	{
		if (base.JsonPreprocessor == null)
		{
			return jsonUtf8Bytes;
		}
		string json = Encoding.UTF8.GetString(jsonUtf8Bytes.ToArray());
		json = base.JsonPreprocessor(json);
		return new ReadOnlyMemory<byte>(Encoding.UTF8.GetBytes(json));
	}

	public static bool IdentifyBinaryContainer(Stream stream)
	{
		Guard.NotNull(stream, "stream");
		return _BinarySerialization._Identify(stream);
	}

	public static string ReadJson(Stream stream)
	{
		Guard.NotNull(stream, "stream");
		if (IdentifyBinaryContainer(stream))
		{
			IReadOnlyDictionary<uint, byte[]> readOnlyDictionary = _BinarySerialization.ReadBinaryFile(stream);
			return Encoding.UTF8.GetString(readOnlyDictionary[1313821514u]);
		}
		using StreamReader streamReader = new StreamReader(stream);
		return streamReader.ReadToEnd();
	}

	public static ReadOnlyMemory<byte> ReadJsonBytes(Stream stream)
	{
		Guard.NotNull(stream, "stream");
		if (IdentifyBinaryContainer(stream))
		{
			IReadOnlyDictionary<uint, byte[]> readOnlyDictionary = _BinarySerialization.ReadBinaryFile(stream);
			return readOnlyDictionary[1313821514u];
		}
		return stream.ReadBytesToEnd();
	}
}
