using System;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;

namespace DevAge.Data;

public abstract class FileDataSet
{
	private StreamDataSetFormat streamDataSetFormat_0 = StreamDataSetFormat.Binary;

	private StreamDataSetFormat streamDataSetFormat_1;

	private bool bool_0 = false;

	private string string_0;

	protected StreamDataSetFormat SaveDataFormat
	{
		get
		{
			return streamDataSetFormat_0;
		}
		set
		{
			streamDataSetFormat_0 = value;
		}
	}

	protected StreamDataSetFormat FileDataFormat => streamDataSetFormat_1;

	protected bool MergeReadedSchema
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public string FileName
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public FileDataSet()
	{
	}

	protected abstract int GetDataVersion();

	protected abstract DataSet CreateData(int version);

	protected virtual void SaveToFile(DataSet pDataSet)
	{
		if (string_0 != null)
		{
			byte[] array2;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
				xmlTextWriter.WriteStartDocument();
				xmlTextWriter.WriteStartElement("filedataset", "http://www.devage.com/FileDataSet");
				xmlTextWriter.WriteStartElement("header", "http://www.devage.com/FileDataSet");
				xmlTextWriter.WriteAttributeString("fileversion", 1.ToString());
				xmlTextWriter.WriteAttributeString("dataversion", GetDataVersion().ToString());
				int num = (int)streamDataSetFormat_0;
				xmlTextWriter.WriteAttributeString("dataformat", num.ToString());
				xmlTextWriter.WriteEndElement();
				xmlTextWriter.WriteStartElement("data", "http://www.devage.com/FileDataSet");
				byte[] array;
				using (MemoryStream memoryStream2 = new MemoryStream())
				{
					StreamDataSet.Write(memoryStream2, pDataSet, streamDataSetFormat_0);
					array = memoryStream2.ToArray();
					memoryStream2.Close();
				}
				xmlTextWriter.WriteBase64(array, 0, array.Length);
				xmlTextWriter.WriteEndElement();
				xmlTextWriter.WriteEndElement();
				xmlTextWriter.WriteEndDocument();
				xmlTextWriter.Flush();
				array2 = memoryStream.ToArray();
				memoryStream.Close();
			}
			using FileStream fileStream = new FileStream(string_0, FileMode.Create, FileAccess.Write);
			fileStream.Write(array2, 0, array2.Length);
			fileStream.Close();
			return;
		}
		throw new ApplicationException("FileName is null");
	}

	protected virtual DataSet LoadFromFile()
	{
		if (string_0 != null)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(string_0);
			XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
			xmlNamespaceManager.AddNamespace("fileds", "http://www.devage.com/FileDataSet");
			XmlNode xmlNode = xmlDocument.DocumentElement.SelectSingleNode("fileds:header", xmlNamespaceManager);
			if (xmlNode != null)
			{
				XmlElement xmlElement = (XmlElement)xmlNode;
				string attribute = xmlElement.GetAttribute("fileversion");
				int num = int.Parse(attribute);
				if (num != 1)
				{
					if (num != 0)
					{
						if (num > 1)
						{
							throw new ApplicationException("File Version not supported, expected: " + 1);
						}
					}
					else
					{
						streamDataSetFormat_1 = StreamDataSetFormat.XML;
					}
				}
				else
				{
					string attribute2 = xmlElement.GetAttribute("dataformat");
					streamDataSetFormat_1 = (StreamDataSetFormat)int.Parse(attribute2);
				}
				string attribute3 = xmlElement.GetAttribute("dataversion");
				int version = int.Parse(attribute3);
				DataSet dataSet = CreateData(version);
				xmlNode = xmlDocument.DocumentElement.SelectSingleNode("fileds:data", xmlNamespaceManager);
				if (xmlNode != null)
				{
					XmlElement xmlElement2 = (XmlElement)xmlNode;
					byte[] buffer = Convert.FromBase64String(xmlElement2.InnerText);
					using (MemoryStream source = new MemoryStream(buffer))
					{
						StreamDataSet.Read(source, dataSet, streamDataSetFormat_1, MergeReadedSchema);
					}
					return dataSet;
				}
				throw new ApplicationException("File data not found");
			}
			throw new ApplicationException("File header not found");
		}
		throw new ApplicationException("FileName is null");
	}
}
