using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Serialization;

namespace Opc.Ua.Schema;

[ComVisible(true)]
public class SchemaValidator
{
	private IDictionary<string, string> m_knownFiles;

	private IDictionary<string, object> m_loadedFiles;

	private IDictionary<string, byte[]> m_importFiles;

	public string FilePath { get; private set; }

	public IDictionary<string, string> KnownFiles => m_knownFiles;

	public IDictionary<string, object> LoadedFiles => m_loadedFiles;

	public IDictionary<string, byte[]> ImportFiles => m_importFiles;

	public SchemaValidator()
	{
		m_knownFiles = new Dictionary<string, string>();
		m_loadedFiles = new Dictionary<string, object>();
		m_importFiles = new Dictionary<string, byte[]>();
	}

	public SchemaValidator(IDictionary<string, string> knownFiles)
	{
		m_knownFiles = knownFiles ?? new Dictionary<string, string>();
		m_loadedFiles = new Dictionary<string, object>();
		m_importFiles = new Dictionary<string, byte[]>();
	}

	public SchemaValidator(IDictionary<string, byte[]> importFiles)
	{
		m_knownFiles = new Dictionary<string, string>();
		m_loadedFiles = new Dictionary<string, object>();
		m_importFiles = importFiles ?? new Dictionary<string, byte[]>();
	}

	protected static bool IsNull(XmlQualifiedName name)
	{
		if (name != null && !string.IsNullOrEmpty(name.Name))
		{
			return false;
		}
		return true;
	}

	protected static Exception Exception(string format)
	{
		throw new FormatException(format);
	}

	protected static Exception Exception(string format, object arg1)
	{
		return new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, format, arg1));
	}

	protected static Exception Exception(string format, object arg1, object arg2)
	{
		return new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, format, arg1, arg2));
	}

	protected static Exception Exception(string format, object arg1, object arg2, object arg3)
	{
		return new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, format, arg1, arg2, arg3));
	}

	protected object LoadInput(Type type, Stream stream)
	{
		m_loadedFiles.Clear();
		object result = LoadFile(type, stream);
		FilePath = null;
		return result;
	}

	protected object LoadInput(Type type, string path)
	{
		m_loadedFiles.Clear();
		object result = LoadFile(type, path);
		FilePath = path;
		return result;
	}

	protected object Load(Type type, string namespaceUri, string path, Assembly assembly = null)
	{
		if (m_loadedFiles.ContainsKey(namespaceUri))
		{
			return m_loadedFiles[namespaceUri];
		}
		if (m_importFiles.TryGetValue(namespaceUri, out var value))
		{
			using (Stream stream = new MemoryStream(value))
			{
				return LoadFile(type, stream);
			}
		}
		FileInfo fileInfo = null;
		if (!string.IsNullOrEmpty(path))
		{
			fileInfo = new FileInfo(path);
			if (fileInfo.Exists)
			{
				return LoadFile(type, path);
			}
		}
		string value2 = null;
		if (m_knownFiles.TryGetValue(namespaceUri, out value2))
		{
			fileInfo = new FileInfo(value2);
			if (fileInfo.Exists)
			{
				return LoadFile(type, value2);
			}
			return LoadResource(type, value2, assembly);
		}
		if (!string.IsNullOrEmpty(path))
		{
			if (!File.Exists(path))
			{
				return LoadResource(type, path, assembly);
			}
			fileInfo = new FileInfo(new FileInfo(FilePath).DirectoryName + Path.DirectorySeparatorChar + fileInfo.Name);
			if (fileInfo.Exists)
			{
				return LoadFile(type, fileInfo.FullName);
			}
			fileInfo = new FileInfo(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + fileInfo.Name);
			if (fileInfo.Exists)
			{
				return LoadFile(type, fileInfo.FullName);
			}
		}
		throw Exception("Cannot import namespace '{0}' from '{1}'.", namespaceUri, path);
	}

	protected static object LoadFile(Type type, string path)
	{
		using StreamReader input = new StreamReader(new FileStream(path, FileMode.Open));
		using XmlReader xmlReader = XmlReader.Create(input, Utils.DefaultXmlReaderSettings());
		return new XmlSerializer(type).Deserialize(xmlReader);
	}

	protected static object LoadFile(Type type, Stream stream)
	{
		using StreamReader input = new StreamReader(stream);
		using XmlReader xmlReader = XmlReader.Create(input, Utils.DefaultXmlReaderSettings());
		return new XmlSerializer(type).Deserialize(xmlReader);
	}

	protected static object LoadResource(Type type, string path, Assembly assembly)
	{
		try
		{
			if (assembly == null)
			{
				assembly = typeof(SchemaValidator).GetTypeInfo().Assembly;
			}
			using StreamReader input = new StreamReader(assembly.GetManifestResourceStream(path));
			using XmlReader xmlReader = XmlReader.Create(input, Utils.DefaultXmlReaderSettings());
			return new XmlSerializer(type).Deserialize(xmlReader);
		}
		catch (Exception innerException)
		{
			throw new FileNotFoundException(string.Format(CultureInfo.InvariantCulture, "Could not load resource '{0}'.", path), innerException);
		}
	}

	protected void SetResourcePaths(string[][] resources)
	{
		if (resources == null)
		{
			return;
		}
		for (int i = 0; i < resources.Length; i++)
		{
			if (!m_knownFiles.ContainsKey(resources[i][0]))
			{
				m_knownFiles.Add(resources[i][0], resources[i][1]);
			}
		}
	}

	public virtual string GetSchema(string typeName)
	{
		return null;
	}
}
