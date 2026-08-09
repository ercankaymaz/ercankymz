using System;

namespace SharpGLTF.Schema2;

public delegate void FileWriterCallback(string assetName, ArraySegment<byte> assetData);
