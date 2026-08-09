using System;
using System.Runtime.InteropServices;

namespace OpenGL;

[CLSCompliant(false)]
public class glu
{
	public delegate void NurbsErrorCallback(uint error);

	public delegate void NurbsVertexCallback(float[] vertexData);

	public delegate void vertexCallback(float[] v);

	public const int FALSE = 0;

	public const int TRUE = 1;

	public const int VERSION_1_1 = 1;

	public const int VERSION_1_2 = 1;

	public const int VERSION = 100800;

	public const int EXTENSIONS = 100801;

	public const int INVALID_ENUM = 100900;

	public const int INVALID_VALUE = 100901;

	public const int OUT_OF_MEMORY = 100902;

	public const int INCOMPATIBLE_GL_VERSION = 100903;

	public const int OUTLINE_POLYGON = 100240;

	public const int OUTLINE_PATCH = 100241;

	public const int ERROR = 100103;

	public const int NURBS_ERROR1 = 100251;

	public const int NURBS_ERROR2 = 100252;

	public const int NURBS_ERROR3 = 100253;

	public const int NURBS_ERROR4 = 100254;

	public const int NURBS_ERROR5 = 100255;

	public const int NURBS_ERROR6 = 100256;

	public const int NURBS_ERROR7 = 100257;

	public const int NURBS_ERROR8 = 100258;

	public const int NURBS_ERROR9 = 100259;

	public const int NURBS_ERROR10 = 100260;

	public const int NURBS_ERROR11 = 100261;

	public const int NURBS_ERROR12 = 100262;

	public const int NURBS_ERROR13 = 100263;

	public const int NURBS_ERROR14 = 100264;

	public const int NURBS_ERROR15 = 100265;

	public const int NURBS_ERROR16 = 100266;

	public const int NURBS_ERROR17 = 100267;

	public const int NURBS_ERROR18 = 100268;

	public const int NURBS_ERROR19 = 100269;

	public const int NURBS_ERROR20 = 100270;

	public const int NURBS_ERROR21 = 100271;

	public const int NURBS_ERROR22 = 100272;

	public const int NURBS_ERROR23 = 100273;

	public const int NURBS_ERROR24 = 100274;

	public const int NURBS_ERROR25 = 100275;

	public const int NURBS_ERROR26 = 100276;

	public const int NURBS_ERROR27 = 100277;

	public const int NURBS_ERROR28 = 100278;

	public const int NURBS_ERROR29 = 100279;

	public const int NURBS_ERROR30 = 100280;

	public const int NURBS_ERROR31 = 100281;

	public const int NURBS_ERROR32 = 100282;

	public const int NURBS_ERROR33 = 100283;

	public const int NURBS_ERROR34 = 100284;

	public const int NURBS_ERROR35 = 100285;

	public const int NURBS_ERROR36 = 100286;

	public const int NURBS_ERROR37 = 100287;

	public const int AUTO_LOAD_MATRIX = 100200;

	public const int CULLING = 100201;

	public const int SAMPLING_TOLERANCE = 100203;

	public const int DISPLAY_MODE = 100204;

	public const int PARAMETRIC_TOLERANCE = 100202;

	public const int SAMPLING_METHOD = 100205;

	public const int U_STEP = 100206;

	public const int V_STEP = 100207;

	public const int OBJECT_SPACE_ERROR_TOLERANCE = 100208;

	public const int PATH_LENGTH = 100215;

	public const int PARAMETRIC_ERROR = 100216;

	public const int DOMAIN_DISTANCE = 100217;

	public const int OBJECT_SPACE = 100218;

	public const int MAP1_TRIM_2 = 100210;

	public const int MAP1_TRIM_3 = 100211;

	public const int POINT = 100010;

	public const int LINE = 100011;

	public const int FILL = 100012;

	public const int SILHOUETTE = 100013;

	public const int SMOOTH = 100000;

	public const int FLAT = 100001;

	public const int NONE = 100002;

	public const int OUTSIDE = 100020;

	public const int INSIDE = 100021;

	public const int TESS_BEGIN = 100100;

	public const int BEGIN = 100100;

	public const int TESS_VERTEX = 100101;

	public const int VERTEX = 100101;

	public const int TESS_END = 100102;

	public const int END = 100102;

	public const int TESS_ERROR = 100103;

	public const int TESS_EDGE_FLAG = 100104;

	public const int EDGE_FLAG = 100104;

	public const int TESS_COMBINE = 100105;

	public const int TESS_BEGIN_DATA = 100106;

	public const int TESS_VERTEX_DATA = 100107;

	public const int TESS_END_DATA = 100108;

	public const int TESS_ERROR_DATA = 100109;

	public const int TESS_EDGE_FLAG_DATA = 100110;

	public const int TESS_COMBINE_DATA = 100111;

	public const int CW = 100120;

	public const int CCW = 100121;

	public const int INTERIOR = 100122;

	public const int EXTERIOR = 100123;

	public const int UNKNOWN = 100124;

	public const int TESS_WINDING_RULE = 100140;

	public const int TESS_BOUNDARY_ONLY = 100141;

	public const int TESS_TOLERANCE = 100142;

	public const int TESS_ERROR1 = 100151;

	public const int TESS_ERROR2 = 100152;

	public const int TESS_ERROR3 = 100153;

	public const int TESS_ERROR4 = 100154;

	public const int TESS_ERROR5 = 100155;

	public const int TESS_ERROR6 = 100156;

	public const int TESS_ERROR7 = 100157;

	public const int TESS_ERROR8 = 100158;

	public const int TESS_MISSING_BEGIN_POLYGON = 100151;

	public const int TESS_MISSING_BEGIN_CONTOUR = 100152;

	public const int TESS_MISSING_END_POLYGON = 100153;

	public const int TESS_MISSING_END_CONTOUR = 100154;

	public const int TESS_COORD_TOO_LARGE = 100155;

	public const int TESS_NEED_COMBINE_CALLBACK = 100156;

	public const int TESS_WINDING_ODD = 100130;

	public const int TESS_WINDING_NONZERO = 100131;

	public const int TESS_WINDING_POSITIVE = 100132;

	public const int TESS_WINDING_NEGATIVE = 100133;

	public const int TESS_WINDING_ABS_GEQ_TWO = 100134;

	public const int NURBS_ERROR = 100103;

	public const int NURBS_BEGIN = 100164;

	public const int NURBS_BEGIN_EXT = 100164;

	public const int NURBS_VERTEX = 100165;

	public const int NURBS_VERTEX_EXT = 100165;

	public const int NURBS_NORMAL = 100166;

	public const int NURBS_NORMAL_EXT = 100166;

	public const int NURBS_COLOR = 100167;

	public const int NURBS_COLOR_EXT = 100167;

	public const int NURBS_TEXTURE_COORD = 100168;

	public const int NURBS_TEX_COORD_EXT = 100168;

	public const int NURBS_END = 100169;

	public const int NURBS_END_EXT = 100169;

	public const int NURBS_BEGIN_DATA = 100170;

	public const int NURBS_BEGIN_DATA_EXT = 100170;

	public const int NURBS_VERTEX_DATA = 100171;

	public const int NURBS_VERTEX_DATA_EXT = 100171;

	public const int NURBS_NORMAL_DATA = 100172;

	public const int NURBS_NORMAL_DATA_EXT = 100172;

	public const int NURBS_COLOR_DATA = 100173;

	public const int NURBS_COLOR_DATA_EXT = 100173;

	public const int NURBS_TEXTURE_COORD_DATA = 100174;

	public const int NURBS_TEX_COORD_DATA_EXT = 100174;

	public const int NURBS_END_DATA = 100175;

	public const int NURBS_END_DATA_EXT = 100175;

	public const int NURBS_MODE = 100160;

	public const int NURBS_MODE_EXT = 100160;

	public const int NURBS_TESSELLATOR = 100161;

	public const int NURBS_TESSELLATOR_EXT = 100161;

	public const int NURBS_RENDERER = 100162;

	public const int NURBS_RENDERER_EXT = 100162;

	public const int OBJECT_PARAMETRIC_ERROR = 100208;

	public const int OBJECT_PARAMETRIC_ERROR_EXT = 100208;

	public const int OBJECT_PATH_LENGTH = 100209;

	public const int OBJECT_PATH_LENGTH_EXT = 100209;

	[DllImport("GLU32.DLL", EntryPoint = "gluErrorString")]
	private static extern IntPtr _0023_003DzdyAhqkw_003D(uint _0023_003DzEbgm5tQ_003D);

	[DllImport("GLU32.DLL", EntryPoint = "gluGetString")]
	private static extern IntPtr _0023_003DzVUf9SZI_003D(int _0023_003DzEbgm5tQ_003D);

	[DllImport("GLU32.DLL", EntryPoint = "gluOrtho2D")]
	public static extern void Ortho2D(double left, double right, double bottom, double top);

	[DllImport("GLU32.DLL", EntryPoint = "gluPerspective")]
	public static extern void Perspective(double fovy, double aspect, double zNear, double zFar);

	[DllImport("GLU32.DLL", EntryPoint = "gluPickMatrix")]
	public static extern void PickMatrix(double x, double y, double width, double height, int[] viewport);

	[DllImport("GLU32.DLL", EntryPoint = "gluLookAt")]
	public static extern void LookAt(double eyex, double eyey, double eyez, double centerx, double centery, double centerz, double upx, double upy, double upz);

	[DllImport("GLU32.DLL", EntryPoint = "gluProject")]
	public static extern int Project(double objx, double objy, double objz, double[] modelMatrix, double[] projMatrix, int[] viewport, out double winx, out double winy, out double winz);

	[DllImport("GLU32.DLL", EntryPoint = "gluUnProject")]
	public static extern int UnProject(double winx, double winy, double winz, double[] modelMatrix, double[] projMatrix, int[] viewport, out double objx, out double objy, out double objz);

	[DllImport("GLU32.DLL", EntryPoint = "gluScaleImage")]
	public static extern void ScaleImage(int format, int widthin, int heightin, int typein, IntPtr datain, int widthout, int heightout, int typeout, IntPtr dataout);

	[DllImport("GLU32.DLL", EntryPoint = "gluBuild1DMipmaps")]
	public static extern int Build1DMipmaps(int target, int components, int width, int format, int type, IntPtr data);

	[DllImport("GLU32.DLL", EntryPoint = "gluBuild2DMipmaps")]
	public static extern int Build2DMipmaps(int target, int components, int width, int height, int format, int type, IntPtr data);

	public static string GetString(int name)
	{
		return Marshal.PtrToStringAnsi(_0023_003DzVUf9SZI_003D(name));
	}

	public static string ErrorString(uint name)
	{
		return Marshal.PtrToStringAnsi(_0023_003DzdyAhqkw_003D(name));
	}

	[DllImport("GLU32.DLL", EntryPoint = "gluNewQuadric")]
	public static extern IntPtr NewQuadric();

	[DllImport("GLU32.DLL", EntryPoint = "gluSphere")]
	public static extern void Sphere(IntPtr qObj, double radius, int slices, int stacks);

	[DllImport("GLU32.DLL", EntryPoint = "gluCylinder")]
	public static extern void Cylinder(IntPtr qObj, double baseRadius, double topRadius, double height, int slices, int stacks);

	[DllImport("GLU32.DLL", EntryPoint = "gluDisk")]
	public static extern void Disk(IntPtr qObj, double innerRadius, double outerRadius, int slices, int loops);

	[DllImport("GLU32.DLL", EntryPoint = "gluQuadricDrawStyle")]
	public static extern void QuadricDrawStyle(IntPtr qObj, uint drawStyle);

	[DllImport("GLU32.DLL", EntryPoint = "gluQuadricOrientation")]
	public static extern void QuadricOrientation(IntPtr qObj, uint orientation);

	[DllImport("GLU32.DLL", EntryPoint = "gluQuadricNormals")]
	public static extern void QuadricNormals(IntPtr qObj, uint drawStyle);

	[DllImport("GLU32.DLL", EntryPoint = "gluQuadricTexture")]
	public static extern void QuadricTexture(IntPtr qObj, uint drawStyle);

	[DllImport("GLU32.DLL", EntryPoint = "gluDeleteQuadric")]
	public static extern void DeleteQuadric(IntPtr state);

	[DllImport("GLU32.DLL", EntryPoint = "gluNewNurbsRenderer")]
	public static extern IntPtr NewNurbsRenderer();

	[DllImport("GLU32.DLL", EntryPoint = "gluDeleteNurbsRenderer")]
	public static extern void DeleteNurbsRenderer(IntPtr nobj);

	[DllImport("GLU32.DLL", EntryPoint = "gluBeginCurve")]
	public static extern void BeginCurve(IntPtr nObj);

	[DllImport("GLU32.DLL", EntryPoint = "gluNurbsCurve")]
	public static extern void NurbsCurve(IntPtr nobj, int nknots, float[] knot, int stride, float[,] ctlarray, int order, uint type);

	[DllImport("GLU32.DLL", EntryPoint = "gluEndCurve")]
	public static extern void EndCurve(IntPtr nobj);

	[DllImport("GLU32.DLL", EntryPoint = "gluBeginSurface")]
	public static extern void BeginSurface(IntPtr nobj);

	[DllImport("GLU32.DLL", EntryPoint = "gluNurbsSurface")]
	public static extern void NurbsSurface(IntPtr nobj, int uknot_count, float[] uknot, int vknot_count, float[] vknot, int u_stride, int v_stride, float[,,] ctlarray, int uorder, int vorder, uint type);

	[DllImport("GLU32.DLL", EntryPoint = "gluEndSurface")]
	public static extern void EndSurface(IntPtr nobj);

	[DllImport("GLU32.DLL", EntryPoint = "gluNurbsProperty")]
	public static extern void NurbsProperty(IntPtr nobj, uint property, float value);

	[DllImport("GLU32.DLL", EntryPoint = "gluBeginTrim")]
	public static extern void BeginTrim(IntPtr nobj);

	[DllImport("GLU32.DLL", EntryPoint = "gluEndTrim")]
	public static extern void EndTrim(IntPtr nobj);

	[DllImport("GLU32.DLL", EntryPoint = "gluPwlCurve")]
	public static extern void PwlCurve(IntPtr nobj, int count, float[,] array, int stride, uint type);

	[DllImport("GLU32.DLL", EntryPoint = "gluNurbsCallback")]
	public static extern void NurbsCallback(IntPtr nobj, uint which, NurbsVertexCallback func);

	[DllImport("GLU32.DLL", EntryPoint = "gluNurbsCallback")]
	public static extern void NurbsCallback(IntPtr nobj, uint which, NurbsErrorCallback func);

	[DllImport("GLU32.DLL", EntryPoint = "gluTessCallback")]
	public static extern void TessCallback(IntPtr tobj, uint which, vertexCallback func);

	[DllImport("GLU32.DLL", EntryPoint = "gluTessVertex")]
	public static extern void TessVertex(IntPtr tobj, double[] v, vertexCallback func);

	[DllImport("GLU32.DLL", EntryPoint = "gluNewTess")]
	public static extern IntPtr NewTess();

	[DllImport("GLU32.DLL", EntryPoint = "gluBeginPolygon")]
	public static extern void BeginPolygon(IntPtr tobj);

	[DllImport("GLU32.DLL", EntryPoint = "gluEndPolygon")]
	public static extern void EndPolygon(IntPtr tobj);

	[DllImport("GLU32.DLL", EntryPoint = "gluBeginContour")]
	public static extern void TessBeginContour(IntPtr tobj);

	[DllImport("GLU32.DLL", EntryPoint = "gluEndContour")]
	public static extern void TessEndContour(IntPtr tobj);

	[DllImport("GLU32.DLL", EntryPoint = "gluGetTessProperty")]
	public static extern void GetTessProperty(IntPtr tobj, uint property, double[] value);

	[DllImport("GLU32.DLL", EntryPoint = "gluDeleteTess")]
	public static extern void DeleteTess(IntPtr tess);
}
