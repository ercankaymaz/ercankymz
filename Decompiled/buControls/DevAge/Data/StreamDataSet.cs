using System;
using System.Data;
using System.IO;
using ns27;

namespace DevAge.Data;

public static class StreamDataSet
{
	public static void Write(Stream destination, DataSet source, StreamDataSetFormat format)
	{
		switch (format)
		{
		case StreamDataSetFormat.XML:
			source.WriteXml(destination, XmlWriteMode.WriteSchema);
			break;
		case StreamDataSetFormat.Binary:
			Class76.smethod_764(destination, source);
			break;
		default:
			throw new ApplicationException("StreamDataSet Format not supported");
		}
	}

	public static void Read(Stream source, DataSet destination, StreamDataSetFormat format, bool mergeSchema)
	{
		bool enforceConstraints = destination.EnforceConstraints;
		destination.EnforceConstraints = false;
		try
		{
			switch (format)
			{
			case StreamDataSetFormat.XML:
				if (!mergeSchema)
				{
					destination.ReadXml(source, XmlReadMode.IgnoreSchema);
				}
				else
				{
					destination.ReadXml(source, XmlReadMode.ReadSchema);
				}
				break;
			case StreamDataSetFormat.Binary:
				Class76.smethod_756(source, destination, mergeSchema);
				break;
			default:
				throw new ApplicationException("StreamDataSet Format not supported");
			}
		}
		finally
		{
			destination.EnforceConstraints = enforceConstraints;
		}
	}
}
