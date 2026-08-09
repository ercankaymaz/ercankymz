using System;

namespace ODA.Publish.PdfPublish;

[Flags]
public enum OdPdfPublish_CollectionSchema_ColumnType
{
	kString = 0,
	kDate = 1,
	kNumber = 2,
	kFileName = 3,
	kDescription = 4,
	kModDate = 5,
	kCreationDate = 6,
	kSize = 7,
	kCompressedSize = 8
}
