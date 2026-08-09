using SharpGLTF.Memory;

namespace SharpGLTF.Schema2;

public delegate string ImageWriterCallback(WriteContext context, string assetName, MemoryImage image);
