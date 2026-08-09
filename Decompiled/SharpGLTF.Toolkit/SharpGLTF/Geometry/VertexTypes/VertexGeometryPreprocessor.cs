namespace SharpGLTF.Geometry.VertexTypes;

public delegate TvG? VertexGeometryPreprocessor<TvG>(TvG arg) where TvG : struct, IVertexGeometry;
