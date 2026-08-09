namespace Xbim.Ifc4;

public interface IXbimMeshReceiver
{
	SurfaceStyling SurfaceStyling { get; set; }

	void BeginUpdate();

	void EndUpdate();

	int AddFace();

	int AddNode(int face, double px, double py, double pz, double nx, double ny, double nz, double u, double v);

	int AddNode(int face, double px, double py, double pz, double nx, double ny, double nz);

	int AddNode(int face, double px, double py, double pz);

	void AddTriangle(int face, int a, int b, int c);

	void AddQuad(int face, int a, int b, int c, int d);
}
