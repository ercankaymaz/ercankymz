using System;
using devDept.Geometry;

namespace devDept.Serialization;

public sealed class FileHeaderSurrogate : Surrogate<FileHeader>
{
	public byte SerializationMode;

	public byte FileMode;

	public byte Units;

	public string Author;

	public string Organization;

	public string OriginatingSystem;

	public byte ContentType;

	public string EyeshotBuild;

	public DateTime Timestamp;

	public ProtoBitmap Thumbnail;

	public string FileName;

	public FileHeaderSurrogate(FileHeader fileHeader)
		: base(fileHeader)
	{
	}

	protected override FileHeader ConvertToObject()
	{
		FileHeader fileHeader = new FileHeader(base.Version, (contentType)ContentType, (serializationType)SerializationMode, (fileType)FileMode, (linearUnitsType)Units);
		if (!Serializer.IsValidVersion(fileHeader.Version))
		{
			WriteLog(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671124), fileHeader.Version));
		}
		CopyDataToObject(fileHeader);
		return fileHeader;
	}

	protected override void CopyDataToObject(FileHeader fileHeader)
	{
		fileHeader.Author = Author;
		fileHeader.Organization = Organization;
		fileHeader.OriginatingSystem = OriginatingSystem;
		fileHeader._0023_003DzmNWLvYCqfoy6snwXiw_003D_003D(EyeshotBuild);
		fileHeader._0023_003DzrqzVY_0024yjCIPY(Timestamp);
		fileHeader.Tag = Tag;
		if (base.Version > 4)
		{
			if (Thumbnail != null)
			{
				fileHeader._0023_003Dz9TTXsLAw_0024c31(Thumbnail?.Data);
			}
		}
		else
		{
			fileHeader._0023_003Dz9TTXsLAw_0024c31(null);
		}
		fileHeader._0023_003Dz4Xm4mt_0024I0cX4 = FileName;
	}

	protected override void CopyDataFromObject(FileHeader fileHeader)
	{
		base.Version = fileHeader.Version;
		SerializationMode = (byte)fileHeader.SerializationMode;
		FileMode = (byte)fileHeader.FileMode;
		Units = (byte)fileHeader.Units;
		Author = fileHeader.Author;
		Organization = fileHeader.Organization;
		OriginatingSystem = fileHeader.OriginatingSystem;
		ContentType = (byte)fileHeader.Content;
		EyeshotBuild = fileHeader.EyeshotBuild;
		Timestamp = fileHeader.Timestamp;
		Tag = fileHeader.Tag;
		Thumbnail = new ProtoBitmap(fileHeader.Thumbnail);
		FileName = fileHeader._0023_003Dz4Xm4mt_0024I0cX4;
	}

	public static implicit operator FileHeader(FileHeaderSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator FileHeaderSurrogate(FileHeader source)
	{
		return source?.ConvertToSurrogate();
	}
}
