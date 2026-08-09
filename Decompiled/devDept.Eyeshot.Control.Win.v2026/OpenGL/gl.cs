using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using OpenGL.Delegates;
using devDept;
using devDept.Diagnostic;
using devDept.Graphics;

namespace OpenGL;

[CLSCompliant(false)]
public class gl
{
	public const string DLLName = "OPENGL32.DLL";

	public const int VERSION_1_1 = 1;

	public const int VERSION_1_2 = 1;

	public const int NEVER = 512;

	public const int LESS = 513;

	public const int EQUAL = 514;

	public const int LEQUAL = 515;

	public const int GREATER = 516;

	public const int NOTEQUAL = 517;

	public const int GEQUAL = 518;

	public const int ALWAYS = 519;

	public const int DEPTH_BUFFER_BIT = 256;

	public const int STENCIL_BUFFER_BIT = 1024;

	public const int COLOR_BUFFER_BIT = 16384;

	public const int POINTS = 0;

	public const int LINES = 1;

	public const int LINE_LOOP = 2;

	public const int LINE_STRIP = 3;

	public const int TRIANGLES = 4;

	public const int TRIANGLE_STRIP = 5;

	public const int TRIANGLE_FAN = 6;

	public const int ZERO = 0;

	public const int ONE = 1;

	public const int SRC_COLOR = 768;

	public const int ONE_MINUS_SRC_COLOR = 769;

	public const int SRC_ALPHA = 770;

	public const int ONE_MINUS_SRC_ALPHA = 771;

	public const int DST_ALPHA = 772;

	public const int ONE_MINUS_DST_ALPHA = 773;

	public const int DST_COLOR = 774;

	public const int ONE_MINUS_DST_COLOR = 775;

	public const int SRC_ALPHA_SATURATE = 776;

	public const int TRUE = 1;

	public const int FALSE = 0;

	public const int CLIP_PLANE0 = 12288;

	public const int CLIP_PLANE1 = 12289;

	public const int CLIP_PLANE2 = 12290;

	public const int CLIP_PLANE3 = 12291;

	public const int CLIP_PLANE4 = 12292;

	public const int CLIP_PLANE5 = 12293;

	public const int BYTE = 5120;

	public const int UNSIGNED_BYTE = 5121;

	public const int SHORT = 5122;

	public const int UNSIGNED_SHORT = 5123;

	public const int INT = 5124;

	public const int UNSIGNED_INT = 5125;

	public const int FLOAT = 5126;

	public const int DOUBLE = 5130;

	public const int NONE = 0;

	public const int FRONT_LEFT = 1024;

	public const int FRONT_RIGHT = 1025;

	public const int BACK_LEFT = 1026;

	public const int BACK_RIGHT = 1027;

	public const int FRONT = 1028;

	public const int BACK = 1029;

	public const int LEFT = 1030;

	public const int RIGHT = 1031;

	public const int FRONT_AND_BACK = 1032;

	public const int NO_ERROR = 0;

	public const int INVALID_ENUM = 1280;

	public const int INVALID_VALUE = 1281;

	public const int INVALID_OPERATION = 1282;

	public const int STACK_OVERFLOW = 1283;

	public const int STACK_UNDERFLOW = 1284;

	public const int OUT_OF_MEMORY = 1285;

	public const int INVALID_FRAMEBUFFER_OPERATION = 1286;

	public const int CW = 2304;

	public const int CCW = 2305;

	public const int POINT_SIZE = 2833;

	public const int POINT_SIZE_RANGE = 2834;

	public const int POINT_SIZE_GRANULARITY = 2835;

	public const int LINE_SMOOTH = 2848;

	public const int LINE_WIDTH = 2849;

	public const int LINE_WIDTH_RANGE = 2850;

	public const int LINE_WIDTH_GRANULARITY = 2851;

	public const int POLYGON_MODE = 2880;

	public const int POLYGON_SMOOTH = 2881;

	public const int CULL_FACE = 2884;

	public const int CULL_FACE_MODE = 2885;

	public const int FRONT_FACE = 2886;

	public const int DEPTH_RANGE = 2928;

	public const int DEPTH_TEST = 2929;

	public const int DEPTH_WRITEMASK = 2930;

	public const int DEPTH_CLEAR_VALUE = 2931;

	public const int DEPTH_FUNC = 2932;

	public const int STENCIL_TEST = 2960;

	public const int STENCIL_CLEAR_VALUE = 2961;

	public const int STENCIL_FUNC = 2962;

	public const int STENCIL_VALUE_MASK = 2963;

	public const int STENCIL_FAIL = 2964;

	public const int STENCIL_PASS_DEPTH_FAIL = 2965;

	public const int STENCIL_PASS_DEPTH_PASS = 2966;

	public const int STENCIL_REF = 2967;

	public const int STENCIL_WRITEMASK = 2968;

	public const int VIEWPORT = 2978;

	public const int DITHER = 3024;

	public const int BLEND_DST = 3040;

	public const int BLEND_SRC = 3041;

	public const int GL_BLEND_SRC_RGB = 32969;

	public const int GL_BLEND_SRC_ALPHA = 32971;

	public const int GL_BLEND_DST_RGB = 32968;

	public const int GL_BLEND_DST_ALPHA = 32970;

	public const int BLEND = 3042;

	public const int LOGIC_OP_MODE = 3056;

	public const int COLOR_LOGIC_OP = 3058;

	public const int DRAW_BUFFER = 3073;

	public const int READ_BUFFER = 3074;

	public const int SCISSOR_BOX = 3088;

	public const int SCISSOR_TEST = 3089;

	public const int COLOR_CLEAR_VALUE = 3106;

	public const int COLOR_WRITEMASK = 3107;

	public const int DOUBLEBUFFER = 3122;

	public const int STEREO = 3123;

	public const int LINE_SMOOTH_HINT = 3154;

	public const int POLYGON_SMOOTH_HINT = 3155;

	public const int UNPACK_SWAP_BYTES = 3312;

	public const int UNPACK_LSB_FIRST = 3313;

	public const int UNPACK_ROW_LENGTH = 3314;

	public const int UNPACK_SKIP_ROWS = 3315;

	public const int UNPACK_SKIP_PIXELS = 3316;

	public const int UNPACK_ALIGNMENT = 3317;

	public const int PACK_SWAP_BYTES = 3328;

	public const int PACK_LSB_FIRST = 3329;

	public const int PACK_ROW_LENGTH = 3330;

	public const int PACK_SKIP_ROWS = 3331;

	public const int PACK_SKIP_PIXELS = 3332;

	public const int PACK_ALIGNMENT = 3333;

	public const int MAX_CLIP_DISTANCES = 3378;

	public const int MAX_TEXTURE_SIZE = 3379;

	public const int MAX_VIEWPORT_DIMS = 3386;

	public const int SUBPIXEL_BITS = 3408;

	public const int TEXTURE_1D = 3552;

	public const int TEXTURE_2D = 3553;

	public const int TEXTURE_WIDTH = 4096;

	public const int TEXTURE_HEIGHT = 4097;

	public const int TEXTURE_INTERNAL_FORMAT = 4099;

	public const int TEXTURE_BORDER_COLOR = 4100;

	public const int DONT_CARE = 4352;

	public const int FASTEST = 4353;

	public const int NICEST = 4354;

	public const int CLEAR = 5376;

	public const int AND = 5377;

	public const int AND_REVERSE = 5378;

	public const int COPY = 5379;

	public const int AND_INVERTED = 5380;

	public const int NOOP = 5381;

	public const int XOR = 5382;

	public const int OR = 5383;

	public const int NOR = 5384;

	public const int EQUIV = 5385;

	public const int INVERT = 5386;

	public const int OR_REVERSE = 5387;

	public const int COPY_INVERTED = 5388;

	public const int OR_INVERTED = 5389;

	public const int NAND = 5390;

	public const int SET = 5391;

	public const int TEXTURE = 5890;

	public const int COLOR = 6144;

	public const int DEPTH = 6145;

	public const int STENCIL = 6146;

	public const int STENCIL_INDEX = 6401;

	public const int DEPTH_COMPONENT = 6402;

	public const int RED = 6403;

	public const int RED_INTEGER = 36244;

	public const int GREEN = 6404;

	public const int BLUE = 6405;

	public const int ALPHA = 6406;

	public const int RGB = 6407;

	public const int RGBA = 6408;

	public const int POINT = 6912;

	public const int LINE = 6913;

	public const int FILL = 6914;

	public const int KEEP = 7680;

	public const int REPLACE = 7681;

	public const int INCR = 7682;

	public const int DECR = 7683;

	public const int VENDOR = 7936;

	public const int RENDERER = 7937;

	public const int VERSION = 7938;

	public const int EXTENSIONS = 7939;

	public const int NEAREST = 9728;

	public const int LINEAR = 9729;

	public const int NEAREST_MIPMAP_NEAREST = 9984;

	public const int LINEAR_MIPMAP_NEAREST = 9985;

	public const int NEAREST_MIPMAP_LINEAR = 9986;

	public const int LINEAR_MIPMAP_LINEAR = 9987;

	public const int TEXTURE_MAG_FILTER = 10240;

	public const int TEXTURE_MIN_FILTER = 10241;

	public const int TEXTURE_WRAP_S = 10242;

	public const int TEXTURE_WRAP_T = 10243;

	public const int REPEAT = 10497;

	public const int POLYGON_OFFSET_FACTOR = 32824;

	public const int POLYGON_OFFSET_UNITS = 10752;

	public const int POLYGON_OFFSET_POINT = 10753;

	public const int POLYGON_OFFSET_LINE = 10754;

	public const int POLYGON_OFFSET_FILL = 32823;

	public const int R3_G3_B2 = 10768;

	public const int R8 = 33321;

	public const int R16F = 33325;

	public const int R16UI = 33332;

	public const int R32F = 33326;

	public const int RGB4 = 32847;

	public const int RGB5 = 32848;

	public const int RGB8 = 32849;

	public const int RGB10 = 32850;

	public const int RGB12 = 32851;

	public const int RGB16 = 32852;

	public const int RGBA2 = 32853;

	public const int RGBA4 = 32854;

	public const int RGB5_A1 = 32855;

	public const int RGBA8 = 32856;

	public const int RGB10_A2 = 32857;

	public const int RGBA12 = 32858;

	public const int RGBA16 = 32859;

	public const int RGBA16F = 34842;

	public const int TEXTURE_RED_SIZE = 32860;

	public const int TEXTURE_GREEN_SIZE = 32861;

	public const int TEXTURE_BLUE_SIZE = 32862;

	public const int TEXTURE_ALPHA_SIZE = 32863;

	public const int PROXY_TEXTURE_1D = 32867;

	public const int PROXY_TEXTURE_2D = 32868;

	public const int TEXTURE_BINDING_1D = 32872;

	public const int TEXTURE_BINDING_2D = 32873;

	public const int TEXTURE_BINDING_3D = 32874;

	public const int VERTEX_ARRAY = 32884;

	public const int NORMAL_ARRAY = 32885;

	public const int COLOR_ARRAY = 32886;

	public const int INDEX_ARRAY = 32887;

	public const int TEXTURE_COORD_ARRAY = 32888;

	public const int EDGE_FLAG_ARRAY = 32889;

	public const int VERTEX_ARRAY_SIZE = 32890;

	public const int VERTEX_ARRAY_TYPE = 32891;

	public const int VERTEX_ARRAY_STRIDE = 32892;

	public const int NORMAL_ARRAY_TYPE = 32894;

	public const int NORMAL_ARRAY_STRIDE = 32895;

	public const int COLOR_ARRAY_SIZE = 32897;

	public const int COLOR_ARRAY_TYPE = 32898;

	public const int COLOR_ARRAY_STRIDE = 32899;

	public const int INDEX_ARRAY_TYPE = 32901;

	public const int INDEX_ARRAY_STRIDE = 32902;

	public const int TEXTURE_COORD_ARRAY_SIZE = 32904;

	public const int TEXTURE_COORD_ARRAY_TYPE = 32905;

	public const int TEXTURE_COORD_ARRAY_STRIDE = 32906;

	public const int EDGE_FLAG_ARRAY_STRIDE = 32908;

	public const int VERTEX_ARRAY_POINTER = 32910;

	public const int NORMAL_ARRAY_POINTER = 32911;

	public const int COLOR_ARRAY_POINTER = 32912;

	public const int INDEX_ARRAY_POINTER = 32913;

	public const int TEXTURE_COORD_ARRAY_POINTER = 32914;

	public const int EDGE_FLAG_ARRAY_POINTER = 32915;

	public const int BGR = 32992;

	public const int BGRA = 32993;

	public const int CONSTANT_COLOR = 32769;

	public const int ONE_MINUS_CONSTANT_COLOR = 32770;

	public const int CONSTANT_ALPHA = 32771;

	public const int ONE_MINUS_CONSTANT_ALPHA = 32772;

	public const int BLEND_COLOR = 32773;

	public const int FUNC_ADD = 32774;

	public const int MIN = 32775;

	public const int MAX = 32776;

	public const int BLEND_EQUATION = 32777;

	public const int FUNC_SUBTRACT = 32778;

	public const int FUNC_REVERSE_SUBTRACT = 32779;

	public const int MAX_ELEMENTS_VERTICES = 33000;

	public const int MAX_ELEMENTS_INDICES = 33001;

	public const int UNSIGNED_BYTE_3_3_2 = 32818;

	public const int UNSIGNED_SHORT_4_4_4_4 = 32819;

	public const int UNSIGNED_SHORT_5_5_5_1 = 32820;

	public const int UNSIGNED_INT_8_8_8_8 = 32821;

	public const int UNSIGNED_INT_10_10_10_2 = 32822;

	public const int UNSIGNED_BYTE_2_3_3_REV = 33634;

	public const int UNSIGNED_SHORT_5_6_5 = 33635;

	public const int UNSIGNED_SHORT_5_6_5_REV = 33636;

	public const int UNSIGNED_SHORT_4_4_4_4_REV = 33637;

	public const int UNSIGNED_SHORT_1_5_5_5_REV = 33638;

	public const int UNSIGNED_INT_8_8_8_8_REV = 33639;

	public const int UNSIGNED_INT_2_10_10_10_REV = 33640;

	public const int PACK_SKIP_IMAGES = 32875;

	public const int PACK_IMAGE_HEIGHT = 32876;

	public const int UNPACK_SKIP_IMAGES = 32877;

	public const int UNPACK_IMAGE_HEIGHT = 32878;

	public const int TEXTURE_3D = 32879;

	public const int PROXY_TEXTURE_3D = 32880;

	public const int TEXTURE_DEPTH = 32881;

	public const int TEXTURE_WRAP_R = 32882;

	public const int MAX_3D_TEXTURE_SIZE = 32883;

	public static int CLAMP_TO_EDGE = 33071;

	public const int MIRRORED_REPEAT = 33648;

	public const int TEXTURE_MIN_LOD = 33082;

	public const int TEXTURE_MAX_LOD = 33083;

	public const int TEXTURE_BASE_LEVEL = 33084;

	public const int TEXTURE_MAX_LEVEL = 33085;

	public const int SMOOTH_POINT_SIZE_RANGE = 2834;

	public const int SMOOTH_POINT_SIZE_GRANULARITY = 2835;

	public const int SMOOTH_LINE_WIDTH_RANGE = 2850;

	public const int SMOOTH_LINE_WIDTH_GRANULARITY = 2851;

	public const int TEXTURE0_ARB = 33984;

	public const int TEXTURE1_ARB = 33985;

	public const int TEXTURE2_ARB = 33986;

	public const int TEXTURE3_ARB = 33987;

	public const int TEXTURE4_ARB = 33988;

	public const int TEXTURE5_ARB = 33989;

	public const int TEXTURE6_ARB = 33990;

	public const int TEXTURE7_ARB = 33991;

	public const int TEXTURE8_ARB = 33992;

	public const int TEXTURE9_ARB = 33993;

	public const int TEXTURE10_ARB = 33994;

	public const int TEXTURE11_ARB = 33995;

	public const int TEXTURE12_ARB = 33996;

	public const int TEXTURE13_ARB = 33997;

	public const int TEXTURE14_ARB = 33998;

	public const int TEXTURE15_ARB = 33999;

	public const int TEXTURE16_ARB = 34000;

	public const int TEXTURE17_ARB = 34001;

	public const int TEXTURE18_ARB = 34002;

	public const int TEXTURE19_ARB = 34003;

	public const int TEXTURE20_ARB = 34004;

	public const int TEXTURE21_ARB = 34005;

	public const int TEXTURE22_ARB = 34006;

	public const int TEXTURE23_ARB = 34007;

	public const int TEXTURE24_ARB = 34008;

	public const int TEXTURE25_ARB = 34009;

	public const int TEXTURE26_ARB = 34010;

	public const int TEXTURE27_ARB = 34011;

	public const int TEXTURE28_ARB = 34012;

	public const int TEXTURE29_ARB = 34013;

	public const int TEXTURE30_ARB = 34014;

	public const int TEXTURE31_ARB = 34015;

	public const int ACTIVE_TEXTURE_ARB = 34016;

	public const int CLIENT_ACTIVE_TEXTURE_ARB = 34017;

	public const int MAX_TEXTURE_UNITS_ARB = 34018;

	public const int CONSTANT_COLOR_EXT = 32769;

	public const int ONE_MINUS_CONSTANT_COLOR_EXT = 32770;

	public const int CONSTANT_ALPHA_EXT = 32771;

	public const int ONE_MINUS_CONSTANT_ALPHA_EXT = 32772;

	public const int BLEND_COLOR_EXT = 32773;

	public const int FUNC_ADD_EXT = 32774;

	public const int MIN_EXT = 32775;

	public const int MAX_EXT = 32776;

	public const int BLEND_EQUATION_EXT = 32777;

	public const int FUNC_SUBTRACT_EXT = 32778;

	public const int FUNC_REVERSE_SUBTRACT_EXT = 32779;

	public const int COMBINE_EXT = 34160;

	public const int COMBINE_RGB_EXT = 34161;

	public const int COMBINE_ALPHA_EXT = 34162;

	public const int RGB_SCALE_EXT = 34163;

	public const int ADD_SIGNED_EXT = 34164;

	public const int INTERPOLATE_EXT = 34165;

	public const int CONSTANT_EXT = 34166;

	public const int PRIMARY_COLOR_EXT = 34167;

	public const int PREVIOUS_EXT = 34168;

	public const int SOURCE0_RGB_EXT = 34176;

	public const int SOURCE1_RGB_EXT = 34177;

	public const int SOURCE2_RGB_EXT = 34178;

	public const int SOURCE0_ALPHA_EXT = 34184;

	public const int SOURCE1_ALPHA_EXT = 34185;

	public const int SOURCE2_ALPHA_EXT = 34186;

	public const int OPERAND0_RGB_EXT = 34192;

	public const int OPERAND1_RGB_EXT = 34193;

	public const int OPERAND2_RGB_EXT = 34194;

	public const int OPERAND0_ALPHA_EXT = 34200;

	public const int OPERAND1_ALPHA_EXT = 34201;

	public const int OPERAND2_ALPHA_EXT = 34202;

	public const int TEXTURE_COMPONENTS = 4099;

	public const int ARRAY_BUFFER_ARB = 34962;

	public const int ELEMENT_ARRAY_BUFFER_ARB = 34963;

	public const int ARRAY_BUFFER_BINDING_ARB = 34964;

	public const int ELEMENT_ARRAY_BUFFER_BINDING_ARB = 34965;

	public const int VERTEX_ARRAY_BUFFER_BINDING_ARB = 34966;

	public const int NORMAL_ARRAY_BUFFER_BINDING_ARB = 34967;

	public const int COLOR_ARRAY_BUFFER_BINDING_ARB = 34968;

	public const int INDEX_ARRAY_BUFFER_BINDING_ARB = 34969;

	public const int TEXTURE_COORD_ARRAY_BUFFER_BINDING_ARB = 34970;

	public const int EDGE_FLAG_ARRAY_BUFFER_BINDING_ARB = 34971;

	public const int SECONDARY_COLOR_ARRAY_BUFFER_BINDING_ARB = 34972;

	public const int FOG_COORDINATE_ARRAY_BUFFER_BINDING_ARB = 34973;

	public const int WEIGHT_ARRAY_BUFFER_BINDING_ARB = 34974;

	public const int VERTEX_ATTRIB_ARRAY_BUFFER_BINDING_ARB = 34975;

	public const int STREAM_DRAW_ARB = 35040;

	public const int STREAM_READ_ARB = 35041;

	public const int STREAM_COPY_ARB = 35042;

	public const int STATIC_DRAW_ARB = 35044;

	public const int STATIC_READ_ARB = 35045;

	public const int STATIC_COPY_ARB = 35046;

	public const int DYNAMIC_DRAW_ARB = 35048;

	public const int DYNAMIC_READ_ARB = 35049;

	public const int DYNAMIC_COPY_ARB = 35050;

	public const int READ_ONLY_ARB = 35000;

	public const int WRITE_ONLY_ARB = 35001;

	public const int READ_WRITE_ARB = 35002;

	public const int BUFFER_SIZE_ARB = 34660;

	public const int BUFFER_USAGE_ARB = 34661;

	public const int BUFFER_ACCESS_ARB = 35003;

	public const int BUFFER_MAPPED_ARB = 35004;

	public const int BUFFER_MAP_POINTER_ARB = 35005;

	public const int SAMPLES_PASSED_ARB = 35092;

	public const int QUERY_COUNTER_BITS_ARB = 34916;

	public const int CURRENT_QUERY_ARB = 34917;

	public const int QUERY_RESULT_ARB = 34918;

	public const int QUERY_RESULT_AVAILABLE_ARB = 34919;

	public const int PROGRAM_POINT_SIZE_ARB = 34370;

	public const int VERTEX_ATTRIB_ARRAY_ENABLED_ARB = 34338;

	public const int VERTEX_ATTRIB_ARRAY_SIZE_ARB = 34339;

	public const int VERTEX_ATTRIB_ARRAY_STRIDE_ARB = 34340;

	public const int VERTEX_ATTRIB_ARRAY_TYPE_ARB = 34341;

	public const int VERTEX_ATTRIB_ARRAY_NORMALIZED_ARB = 34922;

	public const int CURRENT_VERTEX_ATTRIB_ARB = 34342;

	public const int VERTEX_ATTRIB_ARRAY_POINTER_ARB = 34373;

	public const int MAX_VERTEX_ATTRIBS_ARB = 34921;

	public const int INCR_WRAP_EXT = 34055;

	public const int GL_DECR_WRAP_EXT = 8508;

	public const int COMPRESSED_RGB_ARB = 34029;

	public const int COMPRESSED_RGBA_ARB = 34030;

	public const int TEXTURE_COMPRESSION_HINT_ARB = 34031;

	public const int TEXTURE_COMPRESSED_IMAGE_SIZE_ARB = 34464;

	public const int TEXTURE_COMPRESSED_ARB = 34465;

	public const int NUM_COMPRESSED_TEXTURE_FORMATS_ARB = 34466;

	public const int COMPRESSED_TEXTURE_FORMATS_ARB = 34467;

	public const int TEXTURE_LOD_BIAS_EXT = 34049;

	public const int MAX_TEXTURE_LOD_BIAS_EXT = 34045;

	public const int TEXTURE_MIN_LOD_SGIS = 33082;

	public const int EXTURE_MAX_LOD_SGIS = 33083;

	public const int TEXTURE_BASE_LEVEL_SGIS = 33084;

	public const int TEXTURE_MAX_LEVEL_SGIS = 33085;

	public const int GENERATE_MIPMAP_SGIS = 33169;

	public const int GL_MIRRORED_REPEAT_ARB = 33648;

	public const int TEXTURE_3D_ARB = 32879;

	public const int TEXTURE_WRAP_R_ARB = 32882;

	public const int OBJECT_SUBTYPE_ARB = 35663;

	public const int BUFFER = 33504;

	public const int SHADER = 33505;

	public const int PROGRAM = 33506;

	public const int QUERY = 33507;

	public const int PROGRAM_PIPELINE = 33508;

	public const int SAMPLER = 33510;

	public const int FLOAT_VEC2_ARB = 35664;

	public const int FLOAT_VEC3_ARB = 35665;

	public const int FLOAT_VEC4_ARB = 35666;

	public const int INT_VEC2_ARB = 35667;

	public const int INT_VEC3_ARB = 35668;

	public const int INT_VEC4_ARB = 35669;

	public const int BOOL_ARB = 35670;

	public const int BOOL_VEC2_ARB = 35671;

	public const int BOOL_VEC3_ARB = 35672;

	public const int BOOL_VEC4_ARB = 35673;

	public const int FLOAT_MAT2_ARB = 35674;

	public const int FLOAT_MAT3_ARB = 35675;

	public const int FLOAT_MAT4_ARB = 35676;

	public const int VERTEX_SHADER_ARB = 35633;

	public const int MAX_VERTEX_UNIFORM_COMPONENTS_ARB = 35658;

	public const int MAX_TEXTURE_IMAGE_UNITS_ARB = 34930;

	public const int MAX_VERTEX_TEXTURE_IMAGE_UNITS_ARB = 35660;

	public const int MAX_COMBINED_TEXTURE_IMAGE_UNITS_ARB = 35661;

	public const int FRAGMENT_SHADER_ARB = 35632;

	public const int MAX_FRAGMENT_UNIFORM_COMPONENTS_ARB = 35657;

	public const int MAX_GEOMETRY_UNIFORM_COMPONENTS_ARB = 36319;

	public const int MAX_VARYING_FLOATS_ARB = 35659;

	public const int OBJECT_DELETE_STATUS_ARB = 35712;

	public const int OBJECT_COMPILE_STATUS_ARB = 35713;

	public const int OBJECT_LINK_STATUS_ARB = 35714;

	public const int OBJECT_VALIDATE_STATUS_ARB = 35715;

	public const int OBJECT_INFO_LOG_LENGTH_ARB = 35716;

	public const int OBJECT_ATTACHED_OBJECTS_ARB = 35717;

	public const int OBJECT_ACTIVE_UNIFORMS_ARB = 35718;

	public const int OBJECT_ACTIVE_UNIFORM_MAX_LENGTH_ARB = 35719;

	public const int OBJECT_SHADER_SOURCE_LENGTH_ARB = 35720;

	public const int OBJECT_ACTIVE_ATTRIBUTE_MAX_LENGTH_ARB = 35722;

	public const int OBJECT_ACTIVE_ATTRIBUTES_ARB = 35721;

	public const int TEXTURE_CUBE_MAP_ARB = 34067;

	public const int TEXTURE_BINDING_CUBE_MAP_ARB = 34068;

	public const int TEXTURE_CUBE_MAP_POSITIVE_X_ARB = 34069;

	public const int TEXTURE_CUBE_MAP_NEGATIVE_X_ARB = 34070;

	public const int TEXTURE_CUBE_MAP_POSITIVE_Y_ARB = 34071;

	public const int TEXTURE_CUBE_MAP_NEGATIVE_Y_ARB = 34072;

	public const int TEXTURE_CUBE_MAP_POSITIVE_Z_ARB = 34073;

	public const int TEXTURE_CUBE_MAP_NEGATIVE_Z_ARB = 34074;

	public const int PROXY_TEXTURE_CUBE_MAP_ARB = 34075;

	public const int MAX_CUBE_MAP_TEXTURE_SIZE_ARB = 34076;

	public const int FRAMEBUFFER_EXT = 36160;

	public const int RENDERBUFFER_EXT = 36161;

	public const int STENCIL_INDEX1_EXT = 36166;

	public const int STENCIL_INDEX4_EXT = 36167;

	public const int STENCIL_INDEX8_EXT = 36168;

	public const int STENCIL_INDEX16_EXT = 36169;

	public const int RENDERBUFFER_WIDTH_EXT = 36162;

	public const int RENDERBUFFER_HEIGHT_EXT = 36163;

	public const int RENDERBUFFER_INTERNAL_FORMAT_EXT = 36164;

	public const int FRAMEBUFFER_ATTACHMENT_STENCIL_SIZE_EXT = 33303;

	public const int FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE_EXT = 36048;

	public const int FRAMEBUFFER_ATTACHMENT_OBJECT_NAME_EXT = 36049;

	public const int FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL_EXT = 36050;

	public const int FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE_EXT = 36051;

	public const int FRAMEBUFFER_ATTACHMENT_TEXTURE_3D_ZOFFSET_EXT = 36052;

	public const int COLOR_ATTACHMENT0_EXT = 36064;

	public const int COLOR_ATTACHMENT1_EXT = 36065;

	public const int COLOR_ATTACHMENT2_EXT = 36066;

	public const int COLOR_ATTACHMENT3_EXT = 36067;

	public const int COLOR_ATTACHMENT4_EXT = 36068;

	public const int COLOR_ATTACHMENT5_EXT = 36069;

	public const int COLOR_ATTACHMENT6_EXT = 36070;

	public const int COLOR_ATTACHMENT7_EXT = 36071;

	public const int COLOR_ATTACHMENT8_EXT = 36072;

	public const int COLOR_ATTACHMENT9_EXT = 36073;

	public const int COLOR_ATTACHMENT10_EXT = 36074;

	public const int COLOR_ATTACHMENT11_EXT = 36075;

	public const int COLOR_ATTACHMENT12_EXT = 36076;

	public const int COLOR_ATTACHMENT13_EXT = 36077;

	public const int COLOR_ATTACHMENT14_EXT = 36078;

	public const int COLOR_ATTACHMENT15_EXT = 36079;

	public const int DEPTH_ATTACHMENT_EXT = 36096;

	public const int STENCIL_ATTACHMENT_EXT = 36128;

	public const int DEPTH_STENCIL_EXT = 34041;

	public const int UNSIGNED_INT_24_8_EXT = 34042;

	public const int DEPTH24_STENCIL8_EXT = 35056;

	public const int TEXTURE_STENCIL_SIZE_EXT = 35057;

	public const int DEPTH_COMPONENT16 = 33189;

	public const int DEPTH_COMPONENT24 = 33190;

	public const int DEPTH_COMPONENT32 = 33191;

	public const int DRAW_FRAMEBUFFER_EXT = 36009;

	public const int READ_FRAMEBUFFER_EXT = 36008;

	public const int TEXTURE_RECTANGLE_ARB = 34037;

	public const int MAX_RECTANGLE_TEXTURE_SIZE_ARB = 34040;

	public const int FRAMEBUFFER_COMPLETE_EXT = 36053;

	public const int FRAMEBUFFER_INCOMPLETE_ATTACHMENT_EXT = 36054;

	public const int FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT_EXT = 36055;

	public const int FRAMEBUFFER_INCOMPLETE_DIMENSIONS_EXT = 36057;

	public const int FRAMEBUFFER_INCOMPLETE_FORMATS_EXT = 36058;

	public const int FRAMEBUFFER_INCOMPLETE_DRAW_BUFFER_EXT = 36059;

	public const int FRAMEBUFFER_INCOMPLETE_READ_BUFFER_EXT = 36060;

	public const int FRAMEBUFFER_UNSUPPORTED_EXT = 36061;

	public const int FRAMEBUFFER_BINDING_EXT = 36006;

	public const int RENDERBUFFER_BINDING_EXT = 36007;

	public const int MAX_COLOR_ATTACHMENTS_EXT = 36063;

	public const int MAX_RENDERBUFFER_SIZE_EXT = 34024;

	public const int INVALID_FRAMEBUFFER_OPERATION_EXT = 1286;

	public const int BGR_EXT = 32992;

	public const int BGRA_EXT = 32993;

	public const int SHADING_LANGUAGE_VERSION = 35724;

	public const int FRAGMENT_SHADER = 35632;

	public const int GEOMETRY_SHADER = 36313;

	public const int VERTEX_SHADER = 35633;

	public const int INFO_LOG_LENGTH = 35716;

	public const int COMPILE_STATUS = 35713;

	public const int LINK_STATUS = 35714;

	public const int CURRENT_PROGRAM = 35725;

	public const int TEXTURE0 = 33984;

	public const int TEXTURE_MAX_ANISOTROPY_EXT = 34046;

	public const int MAX_TEXTURE_MAX_ANISOTROPY_EXT = 34047;

	public const int MAX_SAMPLES_EXT = 36183;

	public const int MULTISAMPLE_ARB = 32925;

	public const int SAMPLE_BUFFERS_ARB = 32936;

	public const int SAMPLES = 32937;

	public const int VERTEX_PROGRAM_POINT_SIZE_NV = 34370;

	public const int FOG_COORDINATE_SOURCE_EXT = 33872;

	public const int FOG_COORDINATE_EXT = 33873;

	public const int FRAGMENT_DEPTH_EXT = 33874;

	public const int CURRENT_FOG_COORDINATE_EXT = 33875;

	public const int FOG_COORDINATE_ARRAY_TYPE_EXT = 33876;

	public const int FOG_COORDINATE_ARRAY_STRIDE_EXT = 33877;

	public const int FOG_COORDINATE_ARRAY_POINTER_EXT = 33878;

	public const int FOG_COORDINATE_ARRAY_EXT = 33879;

	public const int DEPTH_COMPONENT16_ARB = 33189;

	public const int DEPTH_COMPONENT24_ARB = 33190;

	public const int DEPTH_COMPONENT32_ARB = 33191;

	public const int DEPTH_TEXTURE_MODE_ARB = 34891;

	public const int TEXTURE_DEPTH_SIZE_ARB = 34890;

	public const int TEXTURE_COMPARE_MODE_ARB = 34892;

	public const int TEXTURE_COMPARE_FUNC_ARB = 34893;

	public const int COMPARE_R_TO_TEXTURE_ARB = 34894;

	public const int NUM_EXTENSIONS = 33309;

	public const int ALIASED_LINE_WIDTH_RANGE = 33902;

	public static IntPtr Handle;

	public static glActiveTexture ActiveTexture;

	public static glClientActiveTexture ClientActiveTexture;

	public static glMultiTexCoord1d MultiTexCoord1d;

	public static glMultiTexCoord1dv MultiTexCoord1dv;

	public static glMultiTexCoord1f MultiTexCoord1f;

	public static glMultiTexCoord1fv MultiTexCoord1fv;

	public static glMultiTexCoord1i MultiTexCoord1i;

	public static glMultiTexCoord1iv MultiTexCoord1iv;

	public static glMultiTexCoord1s MultiTexCoord1s;

	public static glMultiTexCoord1sv MultiTexCoord1sv;

	public static glMultiTexCoord2d MultiTexCoord2d;

	public static glMultiTexCoord2dv MultiTexCoord2dv;

	public static glMultiTexCoord2f MultiTexCoord2f;

	public static glMultiTexCoord2fv MultiTexCoord2fv;

	public static glMultiTexCoord2i MultiTexCoord2i;

	public static glMultiTexCoord2iv MultiTexCoord2iv;

	public static glMultiTexCoord2s MultiTexCoord2s;

	public static glMultiTexCoord2sv MultiTexCoord2sv;

	public static glMultiTexCoord3d MultiTexCoord3d;

	public static glMultiTexCoord3dv MultiTexCoord3dv;

	public static glMultiTexCoord3f MultiTexCoord3f;

	public static glMultiTexCoord3fv MultiTexCoord3fv;

	public static glMultiTexCoord3i MultiTexCoord3i;

	public static glMultiTexCoord3iv MultiTexCoord3iv;

	public static glMultiTexCoord3s MultiTexCoord3s;

	public static glMultiTexCoord3sv MultiTexCoord3sv;

	public static glMultiTexCoord4d MultiTexCoord4d;

	public static glMultiTexCoord4dv MultiTexCoord4dv;

	public static glMultiTexCoord4f MultiTexCoord4f;

	public static glMultiTexCoord4fv MultiTexCoord4fv;

	public static glMultiTexCoord4i MultiTexCoord4i;

	public static glMultiTexCoord4iv MultiTexCoord4iv;

	public static glMultiTexCoord4s MultiTexCoord4s;

	public static glMultiTexCoord4sv MultiTexCoord4sv;

	public static glBindBufferARB BindBufferARB;

	public static glDeleteBuffersARB DeleteBuffersARB_;

	public static glGenBuffersARB GenBuffersARB_;

	public static glGenVertexArrays GenVertexArrays_;

	public static glDeleteVertexArrays DeleteVertexArrays_;

	public static glBindVertexArray BindVertexArrays_;

	public static glIsBufferARB IsBufferARB;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static glBufferData _0023_003Dz8M_0024ZTKaQ2HOY;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static glBufferSubData _0023_003DzDLfYxA2eMXSw;

	public static glGetBufferSubDataARB GetBufferSubDataARB;

	public static glMapBufferARB MapBufferARB;

	public static glUnmapBufferARB UnmapBufferARB;

	public static glGetBufferParameterivARB GetBufferParameterivARB;

	public static glGetBufferPointervARB GetBufferPointervARB;

	public static glGenQueriesARB GenQueriesARB_;

	public static glDeleteQueriesARB DeleteQueriesARB_;

	public static glIsQueryARB IsQueryARB;

	public static glBeginQueryARB BeginQueryARB;

	public static glEndQueryARB EndQueryARB;

	public static glGetQueryivARB GetQueryivARB;

	public static glGetQueryObjectivARB GetQueryObjectivARB;

	public static glGetQueryObjectuivARB GetQueryObjectuivARB;

	public static glVertexAttribPointerARB VertexAttribPointerARB;

	public static glEnableVertexAttribArrayARB EnableVertexAttribArrayARB;

	public static glDisableVertexAttribArrayARB DisableVertexAttribArrayARB;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static glProgramStringARB _0023_003Dz7x3NK7J2LBuZ;

	public static glBindProgramARB BindProgramARB;

	public static glDeleteProgramsARB DeleteProgramsARB_;

	public static glGenProgramsARB GenProgramsARB_;

	public static glProgramLocalParameter4fARB ProgramLocalParameter4fARB;

	public static glProgramEnvParameter4fARB ProgramEnvParameter4fARB;

	public static glGetProgramivARB _GetProgramivARB;

	public static glGetProgramEnvParameterfvARB GetProgramEnvParameterfvARB;

	public static glGetProgramLocalParameterfvARB GetProgramLocalParameterfvARB;

	public static glVertexAttrib2fARB VertexAttrib2fARB;

	public static glVertexAttrib3fARB VertexAttrib3fARB;

	public static glVertexAttrib4fARB VertexAttrib4fARB;

	public static glStencilOpSeparateATI StencilOpSeparateATI;

	public static glStencilFuncSeparateATI StencilFuncSeparateATI;

	public static glGetCompressedTexImageARB GetCompressedTexImageARB;

	public static glCompressedTexImage2DARB CompressedTexImage2DARB;

	public static glTexImage3D _TexImage3D;

	public static glBlendEquation BlendEquation;

	public static glBlendFuncSeparate BlendFuncSeparate;

	public static glBlendColor BlendColor;

	public static glWindowPos2f WindowPos2f;

	public static glCreateShader CreateShader;

	public static glShaderSource ShaderSource;

	public static glCompileShader CompileShader;

	public static glGetShaderInfoLog GetShaderInfoLog;

	public static glGetShaderiv GetShaderiv;

	public static glGetProgramiv GetProgramiv;

	public static glCreateProgram CreateProgram;

	public static glAttachShader AttachShader;

	public static glLinkProgram LinkProgram;

	public static glUseProgram UseProgram;

	public static glDetachShader DetachShader;

	public static glGetUniformLocation GetUniformLocation;

	public static glUniform1i Uniform1i;

	public static glUniform1ui Uniform1ui;

	public static glUniform1f Uniform1f;

	public static glUniform2f Uniform2f;

	public static glUniform2ui Uniform2ui;

	public static glUniform3f Uniform3f;

	public static glUniform4f Uniform4f;

	public static glUniform1iv Uniform1iv;

	public static glUniform2iv Uniform2iv;

	public static glUniform4iv Uniform4iv;

	public static glUniform1fv Uniform1fv;

	public static glUniform2fv Uniform2fv;

	public static glUniform3fv Uniform3fv;

	public static glUniform4fv Uniform4fv;

	public static glGetUniformiv GetUniformiv;

	public static glGetUniformfv GetUniformfv;

	public static glDeleteShader DeleteShader;

	public static glDeleteProgram DeleteProgram;

	public static glCreateShaderObjectARB CreateShaderObjectARB;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static glShaderSourceARB _0023_003Dz1BW_0024ax28y94K;

	public static glCompileShaderARB CompileShaderARB;

	public static glDeleteObjectARB DeleteObjectARB;

	public static glGetHandleARB GetHandleARB;

	public static glDetachObjectARB DetachObjectARB;

	public static glCreateProgramObjectARB CreateProgramObjectARB;

	public static glAttachObjectARB AttachObjectARB;

	public static glLinkProgramARB LinkProgramARB;

	public static glUseProgramObjectARB UseProgramObjectARB;

	public static glValidateProgramARB ValidateProgramARB;

	public static glGetObjectParameterfvARB GetObjectParameterfvARB;

	public static glGetObjectParameterivARB GetObjectParameterivARB;

	public static glGetActiveAttribARB GetActiveAttribARB;

	public static glGetActiveUniformARB GetActiveUniformARB;

	public static glGetAttachedObjectsARB GetAttachedObjectsARB;

	public static glGetAttribLocationARB GetAttribLocationARB;

	public static glGetShaderSourceARB GetShaderSourceARB;

	public static glGetUniformfvARB GetUniformfvARB;

	public static glGetUniformivARB GetUniformivARB;

	public static glGetUniformLocationARB GetUniformLocationARB;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static glGetInfoLogARB _0023_003DzQwSKdk0lhBJ3qTJahw_003D_003D;

	public static glBindAttribLocationARB BindAttribLocationARB;

	public static glUniform1fARB Uniform1fARB;

	public static glUniform2fARB Uniform2fARB;

	public static glUniform3fARB Uniform3fARB;

	public static glUniform4fARB Uniform4fARB;

	public static glUniform1iARB Uniform1iARB;

	public static glUniform2iARB Uniform2iARB;

	public static glUniform3iARB Uniform3iARB;

	public static glUniform4iARB Uniform4iARB;

	public static glUniform1fvARB Uniform1fvARB;

	public static glUniform2fvARB Uniform2fvARB;

	public static glUniform3fvARB Uniform3fvARB;

	public static glUniform4fvARB Uniform4fvARB;

	public static glUniform1ivARB Uniform1ivARB;

	public static glUniform2ivARB Uniform2ivARB;

	public static glUniform3ivARB Uniform3ivARB;

	public static glUniform4ivARB Uniform4ivARB;

	public static glUniformMatrix2fvARB UniformMatrix2fvARB;

	public static glUniformMatrix3fvARB UniformMatrix3fvARB;

	public static glUniformMatrix4fvARB UniformMatrix4fvARB;

	public static glVertexAttrib1fARB VertexAttrib1fARB;

	public static glGetProgramInfoLog GetProgramInfoLog;

	public static glIsRenderbufferEXT IsRenderbufferEXT;

	public static glBindRenderbufferEXT BindRenderbufferEXT;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static glDeleteRenderbuffersEXT _0023_003Dz_0024C0AoEFJNqHR0WDTP8u8VJ3I2Y2q;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static glGenRenderbuffersEXT _0023_003Dz6yheWp6KHAYAOOgyjIMalz3DQJGE;

	public static glRenderbufferStorageEXT RenderbufferStorageEXT;

	public static glRenderbufferStorageMultisampleEXT RenderbufferStorageMultisampleEXT;

	public static glBlitFramebufferEXT BlitFramebufferEXT;

	public static glGetRenderbufferParameterivEXT GetRenderbufferParameterivEXT;

	public static glIsFramebufferEXT IsFramebufferEXT;

	public static glBindFramebufferEXT BindFramebufferEXT;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static glDeleteFramebuffersEXT _0023_003DzPOKmjNdF341uez7vyvrkxEY6ZMDX;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static glGenFramebuffersEXT _0023_003DzIR1heqj3oOuC_8239J0YZLKR8IM6;

	public static glCheckFramebufferStatusEXT CheckFramebufferStatusEXT;

	public static glFramebufferTexture1DEXT FramebufferTexture1DEXT;

	public static glFramebufferTexture2DEXT FramebufferTexture2DEXT;

	public static glFramebufferTexture3DEXT FramebufferTexture3DEXT;

	public static glFramebufferRenderbufferEXT FramebufferRenderbufferEXT;

	public static glGetFramebufferAttachmentParameterivEXT GetFramebufferAttachmentParameterivEXT;

	public static glGenerateMipmapEXT GenerateMipmapEXT;

	public static glFogCoordfEXT FogCoordfEXT;

	public static glFogCoorddEXT FogCoorddEXT;

	public static glFogCoordfvEXT FogCoordfvEXT;

	public static glFogCoorddvEXT FogCoorddvEXT;

	public static glFogCoordPointerEXT FogCoordPointerEXT;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static glGetStringi _0023_003DzkMfUu_rnStZ2rxHIvg_003D_003D;

	public static glCreateTextures CreateTextures;

	public static glDrawElementsBaseVertex DrawElementsBaseVertex;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static bool _0023_003Dzhz_0024YecXRoZOs = false;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Version _0023_003DzQlU53AFjJmCgCfoa_0024Q_003D_003D = new Version();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzZDiieO9ddvkanBLIXDVvdQk_003D;

	public bool EXT_framebuffer_object;

	public bool EXT_framebuffer_blit;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003Dzk4W_3C9jG_0024EAZx0nEMCpDzB6m0Ds_9GeMrw2WYo_003D;

	public bool ARB_texture_non_power_of_two;

	public bool ARB_multitexture;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003Dz2uY0e4p5FrZxN0HqcGpT2svUVf0k;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzqbcASXMeLKEGfrhNtZDvGAk_003D;

	public bool ARB_shadow;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzR0uW4gkobr0QHflnvg_003D_003D;

	public bool EXT_vertex_array;

	public bool EXT_packed_depth_stencil;

	public bool ARB_vertex_buffer_object;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int _0023_003Dzs4SqNRf4FWbVcf1hLg_003D_003D;

	[DllImport("OPENGL32.DLL", EntryPoint = "glBindTexture")]
	public static extern void BindTexture(int target, uint texture);

	[DllImport("OPENGL32.DLL", EntryPoint = "glBlendFunc")]
	public static extern void BlendFunc(int sfactor, int dfactor);

	[DllImport("OPENGL32.DLL", EntryPoint = "glClear")]
	public static extern void Clear(int mask);

	[DllImport("OPENGL32.DLL", EntryPoint = "glClearColor")]
	public static extern void ClearColor(float red, float green, float blue, float alpha);

	[DllImport("OPENGL32.DLL", EntryPoint = "glClearDepth")]
	public static extern void ClearDepth(double depth);

	[DllImport("OPENGL32.DLL", EntryPoint = "glClearStencil")]
	public static extern void ClearStencil(int s);

	[DllImport("OPENGL32.DLL", EntryPoint = "glColorMask")]
	public static extern void ColorMask(bool red, bool green, bool blue, bool alpha);

	[DllImport("OPENGL32.DLL", EntryPoint = "glCopyTexImage1D")]
	public static extern void CopyTexImage1D(int target, int level, int internalformat, int x, int y, int width, int border);

	[DllImport("OPENGL32.DLL", EntryPoint = "glCopyTexImage2D")]
	public static extern void CopyTexImage2D(uint target, int level, int internalformat, int x, int y, int width, int height, int border);

	[DllImport("OPENGL32.DLL", EntryPoint = "glCopyTexSubImage1D")]
	public static extern void CopyTexSubImage1D(int target, int level, int xoffset, int x, int y, int width);

	[DllImport("OPENGL32.DLL", EntryPoint = "glCopyTexSubImage2D")]
	public static extern void CopyTexSubImage2D(int target, int level, int xoffset, int yoffset, int x, int y, int width, int height);

	[DllImport("OPENGL32.DLL", EntryPoint = "glCullFace")]
	public static extern void CullFace(int mode);

	[DllImport("OPENGL32.DLL", EntryPoint = "glDeleteTextures")]
	private static extern void _0023_003DzwnfT1sfnCBiJfFR3LA_003D_003D(int _0023_003DzoMNiNRw_003D, uint[] _0023_003DzgdKh98qvX0zGoYtA3g_003D_003D);

	[DllImport("OPENGL32.DLL", EntryPoint = "glDeleteTextures")]
	private static extern void _0023_003DzwnfT1sfnCBiJfFR3LA_003D_003D(int _0023_003DzoMNiNRw_003D, ref uint _0023_003Dz_IfKSJY_003D);

	public static void DeleteTexture(uint texture)
	{
		_0023_003DzwnfT1sfnCBiJfFR3LA_003D_003D(1, ref texture);
	}

	public static void DeleteTextures(uint[] Textures)
	{
		_0023_003DzwnfT1sfnCBiJfFR3LA_003D_003D(Textures.Length, Textures);
	}

	[DllImport("OPENGL32.DLL", EntryPoint = "glDepthFunc")]
	public static extern void DepthFunc(int func);

	[DllImport("OPENGL32.DLL", EntryPoint = "glDepthMask")]
	public static extern void DepthMask(bool flag);

	[DllImport("OPENGL32.DLL", EntryPoint = "glDepthRange")]
	public static extern void DepthRange(double zNear, double zFar);

	[DllImport("OPENGL32.DLL", EntryPoint = "glDisable")]
	public static extern void Disable(int cap);

	[DllImport("OPENGL32.DLL", EntryPoint = "glDrawArrays")]
	public static extern void DrawArrays(int mode, int first, int count);

	[DllImport("OPENGL32.DLL", EntryPoint = "glDrawBuffer")]
	public static extern void DrawBuffer(int mode);

	[DllImport("OPENGL32.DLL", EntryPoint = "glDrawElements")]
	public static extern void DrawElements(int mode, int count, int type, int[] indices);

	[DllImport("OPENGL32.DLL", EntryPoint = "glDrawElements")]
	public static extern void DrawElements(int mode, int count, int type, int[,] indices);

	[DllImport("OPENGL32.DLL", EntryPoint = "glDrawElements")]
	public static extern void DrawElements(int mode, int count, int type, IntPtr indices);

	[DllImport("OPENGL32.DLL", EntryPoint = "glDrawElements")]
	public static extern void DrawElements(int mode, int count, int type, int offset);

	[DllImport("OPENGL32.DLL", EntryPoint = "glEnable")]
	public static extern void Enable(int cap);

	[DllImport("OPENGL32.DLL", EntryPoint = "glFinish")]
	public static extern void Finish();

	[DllImport("OPENGL32.DLL", EntryPoint = "glFlush")]
	public static extern void Flush();

	[DllImport("OPENGL32.DLL", EntryPoint = "glFrontFace")]
	public static extern void FrontFace(int mode);

	[DllImport("OPENGL32.DLL", EntryPoint = "glGenTextures")]
	public static extern void GenTextures(int n, uint[] Textures);

	[DllImport("OPENGL32.DLL", EntryPoint = "glGenTextures")]
	public static extern void GenTextures(int n, ref uint texture);

	[DllImport("OPENGL32.DLL", EntryPoint = "glGetBooleanv")]
	public static extern void GetBooleanv(int pname, int[] bparams);

	[DllImport("OPENGL32.DLL", EntryPoint = "glGetDoublev")]
	public static extern void GetDoublev(int pname, double[] dparams);

	[DllImport("OPENGL32.DLL", EntryPoint = "glGetError")]
	public static extern int GetError();

	[DllImport("OPENGL32.DLL", EntryPoint = "glGetFloatv")]
	public static extern void GetFloatv(int pname, float[] fparams);

	[DllImport("OPENGL32.DLL", EntryPoint = "glGetIntegerv")]
	public static extern void GetIntegerv(int pname, int[] fparams);

	[DllImport("OPENGL32.DLL", EntryPoint = "glGetString")]
	private static extern IntPtr _0023_003DzVUf9SZI_003D(int _0023_003DzYQvHPFc_003D);

	[DllImport("OPENGL32.DLL", EntryPoint = "glGetTexImage")]
	public static extern void GetTexImage(int target, int level, int format, int type, IntPtr pixels);

	[DllImport("OPENGL32.DLL", EntryPoint = "glGetTexLevelParameterfv")]
	public static extern void GetTexLevelParameterfv(int target, int level, int pname, float[] fparams);

	[DllImport("OPENGL32.DLL", EntryPoint = "glGetTexLevelParameteriv")]
	public static extern void GetTexLevelParameteriv(int target, int level, int pname, int[] iparams);

	[DllImport("OPENGL32.DLL", EntryPoint = "glGetTexParameterfv")]
	public static extern void GetTexParameterfv(int target, int pname, float[] fparams);

	[DllImport("OPENGL32.DLL", EntryPoint = "glGetTexParameteriv")]
	public static extern void GetTexParameteriv(int target, int pname, int[] iparams);

	[DllImport("OPENGL32.DLL", EntryPoint = "glHint")]
	public static extern void Hint(int target, int mode);

	[DllImport("OPENGL32.DLL", EntryPoint = "glIsEnabled")]
	public static extern byte IsEnabled(int cap);

	[DllImport("OPENGL32.DLL", EntryPoint = "glIsTexture")]
	public static extern byte IsTexture(uint texture);

	[DllImport("OPENGL32.DLL", EntryPoint = "glLineWidth")]
	public static extern void LineWidth(float width);

	[DllImport("OPENGL32.DLL", EntryPoint = "glLogicOp")]
	public static extern void LogicOp(int opcode);

	[DllImport("OPENGL32.DLL", EntryPoint = "glPixelStoref")]
	public static extern void PixelStoref(int pname, float param);

	[DllImport("OPENGL32.DLL", EntryPoint = "glPixelStorei")]
	public static extern void PixelStorei(int pname, int param);

	[DllImport("OPENGL32.DLL", EntryPoint = "glPointSize")]
	public static extern void PointSize(float size);

	[DllImport("OPENGL32.DLL", EntryPoint = "glPolygonMode")]
	public static extern void PolygonMode(int face, int mode);

	[DllImport("OPENGL32.DLL", EntryPoint = "glPolygonOffset")]
	public static extern void PolygonOffset(float factor, float units);

	[DllImport("OPENGL32.DLL", EntryPoint = "glReadBuffer")]
	public static extern void ReadBuffer(int mode);

	[DllImport("OPENGL32.DLL", EntryPoint = "glReadPixels")]
	public static extern void ReadPixels(int x, int y, int width, int height, int format, int type, [In][Out] IntPtr pixels);

	[DllImport("OPENGL32.DLL", EntryPoint = "glScissor")]
	public static extern void Scissor(int x, int y, int width, int height);

	[DllImport("OPENGL32.DLL", EntryPoint = "glStencilFunc")]
	public static extern void StencilFunc(int func, int refvalue, uint mask);

	[DllImport("OPENGL32.DLL", EntryPoint = "glStencilMask")]
	public static extern void StencilMask(uint mask);

	[DllImport("OPENGL32.DLL", EntryPoint = "glStencilOp")]
	public static extern void StencilOp(int fail, int zfail, int zpass);

	[DllImport("OPENGL32.DLL", EntryPoint = "glTexImage1D")]
	public static extern void TexImage1D(int target, int level, int internalformat, int width, int border, int format, int type, IntPtr pixels);

	[DllImport("OPENGL32.DLL", EntryPoint = "glTexImage1D")]
	public static extern void TexImage1D(int target, int level, int internalformat, int width, int border, int format, int type, byte[] pixels);

	[DllImport("OPENGL32.DLL", EntryPoint = "glTexImage2D")]
	public static extern void TexImage2D(int target, int level, int internalformat, int width, int height, int border, int format, int type, IntPtr pixels);

	[DllImport("OPENGL32.DLL", EntryPoint = "glTexImage2D")]
	public static extern void TexImage2D(int target, int level, int internalformat, int width, int height, int border, int format, int type, byte[] pixels);

	[DllImport("OPENGL32.DLL", EntryPoint = "glTexParameterf")]
	public static extern void TexParameterf(int target, int pname, float param);

	[DllImport("OPENGL32.DLL", EntryPoint = "glTexParameterfv")]
	public static extern void TexParameterfv(int target, int pname, float[] fparams);

	[DllImport("OPENGL32.DLL", EntryPoint = "glTexParameteri")]
	public static extern void TexParameteri(int target, int pname, int param);

	[DllImport("OPENGL32.DLL", EntryPoint = "glTexParameteriv")]
	public static extern void TexParameteriv(int target, int pname, int[] iparams);

	[DllImport("OPENGL32.DLL", EntryPoint = "glTexSubImage1D")]
	public static extern void TexSubImage1D(int target, int level, int xoffset, int width, int format, int type, byte[] pixels);

	[DllImport("OPENGL32.DLL", EntryPoint = "glTexSubImage2D")]
	public static extern void TexSubImage2D(int target, int level, int xoffset, int yoffset, int width, int height, int format, int type, IntPtr pixels);

	[DllImport("OPENGL32.DLL", EntryPoint = "glTexSubImage2D")]
	public static extern void TexSubImage2D(int target, int level, int xoffset, int yoffset, int width, int height, int format, int type, byte[] pixels);

	[DllImport("OPENGL32.DLL", EntryPoint = "glViewport")]
	public static extern void Viewport(int x, int y, int width, int height);

	public static void TexImage2D(int target, int level, int internalformat, int border, Bitmap bmp)
	{
		BitmapData bitmapData = bmp.LockBits(new Rectangle(0, 0, bmp.Size.Width, bmp.Size.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
		TexImage2D(target, level, internalformat, bmp.Size.Width, bmp.Size.Height, border, 32993, 5121, bitmapData.Scan0);
		bmp.UnlockBits(bitmapData);
	}

	public static void TexImage2D(int target, int level, int internalformat, int border, string filePath)
	{
		Bitmap bitmap = new Bitmap(filePath);
		try
		{
			TexImage2D(3553, 0, 32856, 0, bitmap);
		}
		finally
		{
			((IDisposable)bitmap).Dispose();
		}
	}

	public static void TexImage2D(int target, int level, int internalformat, int border, Stream st)
	{
		Bitmap bitmap = new Bitmap(st);
		try
		{
			TexImage2D(3553, 0, 32856, 0, bitmap);
		}
		finally
		{
			((IDisposable)bitmap).Dispose();
		}
	}

	public static void TexImage3D(int target, int level, int internalformat, int width, int height, int depth, int border, int format, int type, IntPtr pixels)
	{
		_TexImage3D(target, level, internalformat, width, height, depth, border, format, type, pixels);
	}

	public static void TexImage3D(int target, int level, int internalformat, int width, int height, int depth, int border, int format, int type, Array data)
	{
		GCHandle gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
		try
		{
			_TexImage3D(target, level, internalformat, width, height, depth, border, format, type, gCHandle.AddrOfPinnedObject());
		}
		finally
		{
			gCHandle.Free();
		}
	}

	public static void BufferData(int target, int size, IntPtr data, int usage)
	{
		_0023_003Dz8M_0024ZTKaQ2HOY(target, size, data, usage);
	}

	public static void BufferData(int target, int size, Array data, int usage)
	{
		GCHandle gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
		try
		{
			BufferData(target, size, gCHandle.AddrOfPinnedObject(), usage);
		}
		finally
		{
			gCHandle.Free();
		}
	}

	public static void BufferSubData(int target, int offset, int size, IntPtr data)
	{
		_0023_003DzDLfYxA2eMXSw(target, offset, size, data);
	}

	public static void BufferSubData(int target, int offset, int size, Array data)
	{
		GCHandle gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
		try
		{
			BufferSubData(target, offset, size, gCHandle.AddrOfPinnedObject());
		}
		finally
		{
			gCHandle.Free();
		}
	}

	public static string GetInfoLog(uint obj)
	{
		StringBuilder stringBuilder = new StringBuilder(1024);
		int length = 1024;
		_0023_003DzQwSKdk0lhBJ3qTJahw_003D_003D(obj, 1024, ref length, stringBuilder);
		return stringBuilder.ToString();
	}

	public static string GetString(int name)
	{
		return Marshal.PtrToStringAnsi(_0023_003DzVUf9SZI_003D(name));
	}

	public static string GetStringi(int name, int index)
	{
		return Marshal.PtrToStringAnsi(_0023_003DzkMfUu_rnStZ2rxHIvg_003D_003D(name, index));
	}

	public static bool[] GetBooleanv(int name, int size)
	{
		int[] array = new int[size];
		GetBooleanv(name, array);
		bool[] array2 = new bool[size];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = array[i] == 1;
		}
		return array2;
	}

	public static int[] GetIntegerv(int name, int size)
	{
		int[] array = new int[size];
		GetIntegerv(name, array);
		return array;
	}

	public static bool GetBooleanv(int name)
	{
		return GetBooleanv(name, 1)[0];
	}

	public static int GetIntegerv(int name)
	{
		return GetIntegerv(name, 1)[0];
	}

	public static float[] GetFloatv(int name, int size)
	{
		float[] array = new float[size];
		GetFloatv(name, array);
		return array;
	}

	public static double[] GetDoublev(int name, int size)
	{
		double[] array = new double[size];
		GetDoublev(name, array);
		return array;
	}

	public static void Viewport(Rectangle r)
	{
		Viewport(r.Left, r.Top, r.Width, r.Height);
	}

	public static void GenBuffersARB(int n, int[] buffers)
	{
		GenBuffersARB_(n, buffers);
	}

	public static int[] GenBuffersARB(int n)
	{
		int[] array = new int[n];
		GenBuffersARB_(n, array);
		return array;
	}

	public static int GenBufferARB()
	{
		int[] array = new int[1];
		GenBuffersARB_(1, array);
		return array[0];
	}

	public static void GenVertexArrays(int n, int[] buffers)
	{
		GenVertexArrays_(n, buffers);
	}

	public static int GenVertexArrays()
	{
		int[] array = new int[1];
		GenVertexArrays_(1, array);
		return array[0];
	}

	public static void DeleteVertexArrays(int[] buffers)
	{
		DeleteVertexArrays_(buffers.Length, buffers);
	}

	public static void DeleteVertexArrays(int buffer)
	{
		int[] buffers = new int[1] { buffer };
		DeleteVertexArrays_(1, buffers);
	}

	public static void DeleteBuffersARB(int n, int[] buffers)
	{
		DeleteBuffersARB_(n, buffers);
	}

	public static void DeleteBuffersARB(int[] buffers)
	{
		DeleteBuffersARB_(buffers.Length, buffers);
	}

	public static void GenQueriesARB(int n, int[] queries)
	{
		GenQueriesARB_(n, queries);
	}

	public static int[] GenQueriesARB(int n)
	{
		int[] array = new int[n];
		GenQueriesARB_(n, array);
		return array;
	}

	public static int GenQueryARB()
	{
		int[] array = new int[1];
		GenQueriesARB_(1, array);
		return array[0];
	}

	public static void DeleteQueriesARB(int n, int[] queries)
	{
		DeleteQueriesARB_(n, queries);
	}

	public static void DeleteQueriesARB(int[] queries)
	{
		DeleteQueriesARB_(queries.Length, queries);
	}

	public static void GenProgramsARB(int n, int[] progs)
	{
		GenProgramsARB_(n, progs);
	}

	public static int[] GenProgramsARB(int n)
	{
		int[] array = new int[n];
		GenProgramsARB_(n, array);
		return array;
	}

	public static int GenProgramARB()
	{
		int[] array = new int[1];
		GenProgramsARB_(1, array);
		return array[0];
	}

	public static void DeleteProgramsARB(int n, int[] progs)
	{
		DeleteProgramsARB_(n, progs);
	}

	public static void DeleteProgramsARB(int[] progs)
	{
		DeleteProgramsARB_(progs.Length, progs);
	}

	public static void DeleteProgramARB(int prog)
	{
		int[] programs = new int[1] { prog };
		DeleteProgramsARB_(1, programs);
	}

	public static void GetProgramivARB(int target, int pname, int[] iparams)
	{
		_GetProgramivARB(target, pname, iparams);
	}

	public static int GetProgramivARB(int target, int pname)
	{
		int[] array = new int[1];
		GetProgramivARB(target, pname, array);
		return array[0];
	}

	public static uint[] GenRenderbuffersEXT(int n)
	{
		uint[] array = new uint[n];
		_0023_003Dz6yheWp6KHAYAOOgyjIMalz3DQJGE(n, array);
		return array;
	}

	public static uint GenRenderbuffersEXT()
	{
		uint[] array = new uint[1];
		_0023_003Dz6yheWp6KHAYAOOgyjIMalz3DQJGE(1, array);
		return array[0];
	}

	public static void GenRenderbuffersEXT(int n, uint[] renderbuffers)
	{
		_0023_003Dz6yheWp6KHAYAOOgyjIMalz3DQJGE(n, renderbuffers);
	}

	public static uint[] GenFramebuffersEXT(int n)
	{
		uint[] array = new uint[n];
		_0023_003DzIR1heqj3oOuC_8239J0YZLKR8IM6(n, array);
		return array;
	}

	public static uint GenFramebuffersEXT()
	{
		uint[] array = new uint[1];
		_0023_003DzIR1heqj3oOuC_8239J0YZLKR8IM6(1, array);
		return array[0];
	}

	public static void GenFramebuffersEXT(int n, uint[] framebuffers)
	{
		_0023_003DzIR1heqj3oOuC_8239J0YZLKR8IM6(n, framebuffers);
	}

	public static void DeleteFramebuffersEXT(uint framebuffer)
	{
		uint[] framebuffers = new uint[1] { framebuffer };
		_0023_003DzPOKmjNdF341uez7vyvrkxEY6ZMDX(1, framebuffers);
	}

	public static void DeleteRenderbuffersEXT(uint renderbuffer)
	{
		uint[] renderbuffers = new uint[1] { renderbuffer };
		_0023_003Dz_0024C0AoEFJNqHR0WDTP8u8VJ3I2Y2q(1, renderbuffers);
	}

	internal static Delegate _0023_003Dzb3sZvEk_003D(string _0023_003DzYQvHPFc_003D, Type _0023_003Dz7mKSiLg_003D)
	{
		IntPtr procAddress = wgl.GetProcAddress(_0023_003DzYQvHPFc_003D);
		if (procAddress == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.GetDelegateForFunctionPointer(procAddress, _0023_003Dz7mKSiLg_003D);
	}

	public static void LoadExtensions()
	{
		if (!_0023_003Dzhz_0024YecXRoZOs)
		{
			_0023_003Dzhz_0024YecXRoZOs = true;
			ActiveTexture = (glActiveTexture)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348640617), typeof(glActiveTexture));
			ClientActiveTexture = (glClientActiveTexture)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348640627), typeof(glClientActiveTexture));
			MultiTexCoord1d = (glMultiTexCoord1d)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646039), typeof(glMultiTexCoord1d));
			MultiTexCoord1dv = (glMultiTexCoord1dv)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646079), typeof(glMultiTexCoord1dv));
			MultiTexCoord1f = (glMultiTexCoord1f)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646086), typeof(glMultiTexCoord1f));
			MultiTexCoord1fv = (glMultiTexCoord1fv)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646126), typeof(glMultiTexCoord1fv));
			MultiTexCoord1i = (glMultiTexCoord1i)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646133), typeof(glMultiTexCoord1i));
			MultiTexCoord1iv = (glMultiTexCoord1iv)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645917), typeof(glMultiTexCoord1iv));
			MultiTexCoord1s = (glMultiTexCoord1s)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645924), typeof(glMultiTexCoord1s));
			MultiTexCoord1sv = (glMultiTexCoord1sv)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645964), typeof(glMultiTexCoord1sv));
			MultiTexCoord2d = (glMultiTexCoord2d)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645971), typeof(glMultiTexCoord2d));
			MultiTexCoord2dv = (glMultiTexCoord2dv)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646011), typeof(glMultiTexCoord2dv));
			MultiTexCoord2f = (glMultiTexCoord2f)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646274), typeof(glMultiTexCoord2f));
			MultiTexCoord2fv = (glMultiTexCoord2fv)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646314), typeof(glMultiTexCoord2fv));
			MultiTexCoord2i = (glMultiTexCoord2i)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646321), typeof(glMultiTexCoord2i));
			MultiTexCoord2iv = (glMultiTexCoord2iv)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646361), typeof(glMultiTexCoord2iv));
			MultiTexCoord2s = (glMultiTexCoord2s)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646368), typeof(glMultiTexCoord2s));
			MultiTexCoord2sv = (glMultiTexCoord2sv)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646152), typeof(glMultiTexCoord2sv));
			MultiTexCoord3d = (glMultiTexCoord3d)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646191), typeof(glMultiTexCoord3d));
			MultiTexCoord3dv = (glMultiTexCoord3dv)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646199), typeof(glMultiTexCoord3dv));
			MultiTexCoord3f = (glMultiTexCoord3f)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646238), typeof(glMultiTexCoord3f));
			MultiTexCoord3fv = (glMultiTexCoord3fv)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646246), typeof(glMultiTexCoord3fv));
			MultiTexCoord3i = (glMultiTexCoord3i)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645517), typeof(glMultiTexCoord3i));
			MultiTexCoord3iv = (glMultiTexCoord3iv)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645525), typeof(glMultiTexCoord3iv));
			MultiTexCoord3s = (glMultiTexCoord3s)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645564), typeof(glMultiTexCoord3s));
			MultiTexCoord3sv = (glMultiTexCoord3sv)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645572), typeof(glMultiTexCoord3sv));
			MultiTexCoord4d = (glMultiTexCoord4d)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645611), typeof(glMultiTexCoord4d));
			MultiTexCoord4dv = (glMultiTexCoord4dv)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645619), typeof(glMultiTexCoord4dv));
			MultiTexCoord4f = (glMultiTexCoord4f)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645402), typeof(glMultiTexCoord4f));
			MultiTexCoord4fv = (glMultiTexCoord4fv)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645410), typeof(glMultiTexCoord4fv));
			MultiTexCoord4i = (glMultiTexCoord4i)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645449), typeof(glMultiTexCoord4i));
			MultiTexCoord4iv = (glMultiTexCoord4iv)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645457), typeof(glMultiTexCoord4iv));
			MultiTexCoord4s = (glMultiTexCoord4s)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645496), typeof(glMultiTexCoord4s));
			MultiTexCoord4sv = (glMultiTexCoord4sv)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645760), typeof(glMultiTexCoord4sv));
			BindBufferARB = (glBindBufferARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645799), typeof(glBindBufferARB));
			DeleteBuffersARB_ = (glDeleteBuffersARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645809), typeof(glDeleteBuffersARB));
			GenBuffersARB_ = (glGenBuffersARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645848), typeof(glGenBuffersARB));
			GenVertexArrays_ = (glGenVertexArrays)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645858), typeof(glGenVertexArrays));
			DeleteVertexArrays_ = (glDeleteVertexArrays)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645642), typeof(glDeleteVertexArrays));
			BindVertexArrays_ = (glBindVertexArray)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645679), typeof(glBindVertexArray));
			IsBufferARB = (glIsBufferARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645687), typeof(glIsBufferARB));
			_0023_003Dz8M_0024ZTKaQ2HOY = (glBufferData)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645699), typeof(glBufferData));
			_0023_003DzDLfYxA2eMXSw = (glBufferSubData)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645712), typeof(glBufferSubData));
			GetBufferSubDataARB = (glGetBufferSubDataARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645754), typeof(glGetBufferSubDataARB));
			MapBufferARB = (glMapBufferARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647070), typeof(glMapBufferARB));
			UnmapBufferARB = (glUnmapBufferARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647081), typeof(glUnmapBufferARB));
			GetBufferParameterivARB = (glGetBufferParameterivARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647090), typeof(glGetBufferParameterivARB));
			GetBufferPointervARB = (glGetBufferPointervARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647122), typeof(glGetBufferPointervARB));
			GenQueriesARB_ = (glGenQueriesARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647157), typeof(glGenQueriesARB));
			DeleteQueriesARB_ = (glDeleteQueriesARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646943), typeof(glDeleteQueriesARB));
			IsQueryARB = (glIsQueryARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646950), typeof(glIsQueryARB));
			BeginQueryARB = (glBeginQueryARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646963), typeof(glBeginQueryARB));
			EndQueryARB = (glEndQueryARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647005), typeof(glEndQueryARB));
			GetQueryivARB = (glGetQueryivARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647017), typeof(glGetQueryivARB));
			GetQueryObjectivARB = (glGetQueryObjectivARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647027), typeof(glGetQueryObjectivARB));
			GetQueryObjectuivARB = (glGetQueryObjectuivARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647319), typeof(glGetQueryObjectuivARB));
			VertexAttribPointerARB = (glVertexAttribPointerARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647354), typeof(glVertexAttribPointerARB));
			EnableVertexAttribArrayARB = (glEnableVertexAttribArrayARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647387), typeof(glEnableVertexAttribArrayARB));
			DisableVertexAttribArrayARB = (glDisableVertexAttribArrayARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647416), typeof(glDisableVertexAttribArrayARB));
			_0023_003Dz7x3NK7J2LBuZ = (glProgramStringARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647188), typeof(glProgramStringARB));
			BindProgramARB = (glBindProgramARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647227), typeof(glBindProgramARB));
			DeleteProgramsARB_ = (glDeleteProgramsARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647236), typeof(glDeleteProgramsARB));
			GenProgramsARB_ = (glGenProgramsARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647274), typeof(glGenProgramsARB));
			ProgramLocalParameter4fARB = (glProgramLocalParameter4fARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647283), typeof(glProgramLocalParameter4fARB));
			ProgramEnvParameter4fARB = (glProgramEnvParameter4fARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646544), typeof(glProgramEnvParameter4fARB));
			_GetProgramivARB = (glGetProgramivARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646607), typeof(glGetProgramivARB));
			GetProgramEnvParameterfvARB = (glGetProgramEnvParameterfvARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646615), typeof(glGetProgramEnvParameterfvARB));
			GetProgramLocalParameterfvARB = (glGetProgramLocalParameterfvARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646643), typeof(glGetProgramLocalParameterfvARB));
			VertexAttrib2fARB = (glVertexAttrib2fARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646445), typeof(glVertexAttrib2fARB));
			VertexAttrib3fARB = (glVertexAttrib3fARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646451), typeof(glVertexAttrib3fARB));
			VertexAttrib4fARB = (glVertexAttrib4fARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646489), typeof(glVertexAttrib4fARB));
			GetCompressedTexImageARB = (glGetCompressedTexImageARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646527), typeof(glGetCompressedTexImageARB));
			CompressedTexImage2DARB = (glCompressedTexImage2DARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646814), typeof(glCompressedTexImage2DARB));
			_TexImage3D = (glTexImage3D)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646846), typeof(glTexImage3D));
			BlendEquation = (glBlendEquation)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646859), typeof(glBlendEquation));
			BlendFuncSeparate = (glBlendFuncSeparate)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646869), typeof(glBlendFuncSeparate));
			BlendColor = (glBlendColor)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646907), typeof(glBlendColor));
			WindowPos2f = (glWindowPos2f)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646664), typeof(glWindowPos2f));
			CreateShader = (glCreateShader)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646676), typeof(glCreateShader));
			ShaderSource = (glShaderSource)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646719), typeof(glShaderSource));
			CompileShader = (glCompileShader)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646730), typeof(glCompileShader));
			GetShaderInfoLog = (glGetShaderInfoLog)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646740), typeof(glGetShaderInfoLog));
			CompileShader = (glCompileShader)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646730), typeof(glCompileShader));
			GetShaderiv = (glGetShaderiv)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348646779), typeof(glGetShaderiv));
			GetProgramiv = (glGetProgramiv)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348643975), typeof(glGetProgramiv));
			CreateProgram = (glCreateProgram)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348643986), typeof(glCreateProgram));
			AttachShader = (glAttachShader)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644028), typeof(glAttachShader));
			LinkProgram = (glLinkProgram)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644039), typeof(glLinkProgram));
			UseProgram = (glUseProgram)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644051), typeof(glUseProgram));
			DetachShader = (glDetachShader)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644064), typeof(glDetachShader));
			GetUniformLocation = (glGetUniformLocation)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348643851), typeof(glGetUniformLocation));
			Uniform1i = (glUniform1i)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348643856), typeof(glUniform1i));
			Uniform1ui = (glUniform1ui)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348643902), typeof(glUniform1ui));
			Uniform1iv = (glUniform1iv)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348643915), typeof(glUniform1iv));
			Uniform2iv = (glUniform2iv)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348643928), typeof(glUniform2iv));
			Uniform4iv = (glUniform4iv)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348643941), typeof(glUniform4iv));
			Uniform1f = (glUniform1f)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348643954), typeof(glUniform1f));
			Uniform2f = (glUniform2f)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644224), typeof(glUniform2f));
			Uniform2ui = (glUniform2ui)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644270), typeof(glUniform2ui));
			Uniform3f = (glUniform3f)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644283), typeof(glUniform3f));
			Uniform4f = (glUniform4f)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644297), typeof(glUniform4f));
			Uniform1fv = (glUniform1fv)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644311), typeof(glUniform1fv));
			Uniform2fv = (glUniform2fv)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644324), typeof(glUniform2fv));
			Uniform3fv = (glUniform3fv)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644337), typeof(glUniform3fv));
			Uniform4fv = (glUniform4fv)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644126), typeof(glUniform4fv));
			GetUniformiv = (glGetUniformiv)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644139), typeof(glGetUniformiv));
			GetUniformfv = (glGetUniformfv)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644150), typeof(glGetUniformfv));
			DeleteShader = (glDeleteShader)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644161), typeof(glDeleteShader));
			DeleteProgram = (glDeleteProgram)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644204), typeof(glDeleteProgram));
			CreateShaderObjectARB = (glCreateShaderObjectARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644214), typeof(glCreateShaderObjectARB));
			_0023_003Dz1BW_0024ax28y94K = (glShaderSourceARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348643480), typeof(glShaderSourceARB));
			CompileShaderARB = (glCompileShaderARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348643488), typeof(glCompileShaderARB));
			DeleteObjectARB = (glDeleteObjectARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348643527), typeof(glDeleteObjectARB));
			GetHandleARB = (glGetHandleARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348643567), typeof(glGetHandleARB));
			DetachObjectARB = (glDetachObjectARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348643578), typeof(glDetachObjectARB));
			CreateProgramObjectARB = (glCreateProgramObjectARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348643330), typeof(glCreateProgramObjectARB));
			AttachObjectARB = (glAttachObjectARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348643363), typeof(glAttachObjectARB));
			LinkProgramARB = (glLinkProgramARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348643403), typeof(glLinkProgramARB));
			UseProgramObjectARB = (glUseProgramObjectARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348643412), typeof(glUseProgramObjectARB));
			ValidateProgramARB = (glValidateProgramARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348643448), typeof(glValidateProgramARB));
			GetObjectParameterfvARB = (glGetObjectParameterfvARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348643741), typeof(glGetObjectParameterfvARB));
			GetObjectParameterivARB = (glGetObjectParameterivARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348643773), typeof(glGetObjectParameterivARB));
			GetActiveAttribARB = (glGetActiveAttribARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348643805), typeof(glGetActiveAttribARB));
			GetActiveUniformARB = (glGetActiveUniformARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348643810), typeof(glGetActiveUniformARB));
			GetAttachedObjectsARB = (glGetAttachedObjectsARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348643590), typeof(glGetAttachedObjectsARB));
			GetAttribLocationARB = (glGetAttribLocationARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348643624), typeof(glGetAttribLocationARB));
			GetShaderSourceARB = (glGetShaderSourceARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348643659), typeof(glGetShaderSourceARB));
			GetUniformfvARB = (glGetUniformfvARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348643664), typeof(glGetUniformfvARB));
			GetUniformivARB = (glGetUniformivARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348643704), typeof(glGetUniformivARB));
			GetUniformLocationARB = (glGetUniformLocationARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644992), typeof(glGetUniformLocationARB));
			_0023_003DzQwSKdk0lhBJ3qTJahw_003D_003D = (glGetInfoLogARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645026), typeof(glGetInfoLogARB));
			BindAttribLocationARB = (glBindAttribLocationARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645068), typeof(glBindAttribLocationARB));
			Uniform1fARB = (glUniform1fARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645102), typeof(glUniform1fARB));
			Uniform2fARB = (glUniform2fARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645113), typeof(glUniform2fARB));
			Uniform3fARB = (glUniform3fARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644868), typeof(glUniform3fARB));
			Uniform4fARB = (glUniform4fARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644911), typeof(glUniform4fARB));
			Uniform1iARB = (glUniform1iARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644922), typeof(glUniform1iARB));
			Uniform2iARB = (glUniform2iARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644933), typeof(glUniform2iARB));
			Uniform3iARB = (glUniform3iARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644944), typeof(glUniform3iARB));
			Uniform4iARB = (glUniform4iARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644987), typeof(glUniform4iARB));
			Uniform1fvARB = (glUniform1fvARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645254), typeof(glUniform1fvARB));
			Uniform2fvARB = (glUniform2fvARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645264), typeof(glUniform2fvARB));
			Uniform3fvARB = (glUniform3fvARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645306), typeof(glUniform3fvARB));
			Uniform4fvARB = (glUniform4fvARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645316), typeof(glUniform4fvARB));
			Uniform1ivARB = (glUniform1ivARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645358), typeof(glUniform1ivARB));
			Uniform2ivARB = (glUniform2ivARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645368), typeof(glUniform2ivARB));
			Uniform3ivARB = (glUniform3ivARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645122), typeof(glUniform3ivARB));
			Uniform4ivARB = (glUniform4ivARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645164), typeof(glUniform4ivARB));
			UniformMatrix2fvARB = (glUniformMatrix2fvARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645174), typeof(glUniformMatrix2fvARB));
			UniformMatrix3fvARB = (glUniformMatrix3fvARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645210), typeof(glUniformMatrix3fvARB));
			UniformMatrix4fvARB = (glUniformMatrix4fvARB)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348645246), typeof(glUniformMatrix4fvARB));
			GetProgramInfoLog = (glGetProgramInfoLog)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644482), typeof(glGetProgramInfoLog));
			IsRenderbufferEXT = (glIsRenderbufferEXT)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644520), typeof(glIsRenderbufferEXT));
			BindRenderbufferEXT = (glBindRenderbufferEXT)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644558), typeof(glBindRenderbufferEXT));
			_0023_003Dz_0024C0AoEFJNqHR0WDTP8u8VJ3I2Y2q = (glDeleteRenderbuffersEXT)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644562), typeof(glDeleteRenderbuffersEXT));
			_0023_003Dz6yheWp6KHAYAOOgyjIMalz3DQJGE = (glGenRenderbuffersEXT)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644595), typeof(glGenRenderbuffersEXT));
			RenderbufferStorageEXT = (glRenderbufferStorageEXT)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644375), typeof(glRenderbufferStorageEXT));
			GetRenderbufferParameterivEXT = (glGetRenderbufferParameterivEXT)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644408), typeof(glGetRenderbufferParameterivEXT));
			IsFramebufferEXT = (glIsFramebufferEXT)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644434), typeof(glIsFramebufferEXT));
			BindFramebufferEXT = (glBindFramebufferEXT)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644473), typeof(glBindFramebufferEXT));
			_0023_003DzPOKmjNdF341uez7vyvrkxEY6ZMDX = (glDeleteFramebuffersEXT)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644766), typeof(glDeleteFramebuffersEXT));
			_0023_003DzIR1heqj3oOuC_8239J0YZLKR8IM6 = (glGenFramebuffersEXT)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644768), typeof(glGenFramebuffersEXT));
			CheckFramebufferStatusEXT = (glCheckFramebufferStatusEXT)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644805), typeof(glCheckFramebufferStatusEXT));
			FramebufferTexture1DEXT = (glFramebufferTexture1DEXT)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644835), typeof(glFramebufferTexture1DEXT));
			FramebufferTexture2DEXT = (glFramebufferTexture2DEXT)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644611), typeof(glFramebufferTexture2DEXT));
			FramebufferTexture3DEXT = (glFramebufferTexture3DEXT)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644643), typeof(glFramebufferTexture3DEXT));
			FramebufferRenderbufferEXT = (glFramebufferRenderbufferEXT)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644675), typeof(glFramebufferRenderbufferEXT));
			GetFramebufferAttachmentParameterivEXT = (glGetFramebufferAttachmentParameterivEXT)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348644704), typeof(glGetFramebufferAttachmentParameterivEXT));
			GenerateMipmapEXT = (glGenerateMipmapEXT)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650129), typeof(glGenerateMipmapEXT));
			RenderbufferStorageMultisampleEXT = (glRenderbufferStorageMultisampleEXT)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650167), typeof(glRenderbufferStorageMultisampleEXT));
			BlitFramebufferEXT = (glBlitFramebufferEXT)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650221), typeof(glBlitFramebufferEXT));
			FogCoordfEXT = (glFogCoordfEXT)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650226), typeof(glFogCoordfEXT));
			FogCoorddEXT = (glFogCoorddEXT)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650013), typeof(glFogCoorddEXT));
			FogCoordfvEXT = (glFogCoordfvEXT)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650024), typeof(glFogCoordfvEXT));
			FogCoorddvEXT = (glFogCoorddvEXT)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650033), typeof(glFogCoorddvEXT));
			FogCoordPointerEXT = (glFogCoordPointerEXT)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650076), typeof(glFogCoordPointerEXT));
			_0023_003DzkMfUu_rnStZ2rxHIvg_003D_003D = (glGetStringi)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650081), typeof(glGetStringi));
			CreateTextures = (glCreateTextures)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650382), typeof(glCreateTextures));
			DrawElementsBaseVertex = (glDrawElementsBaseVertex)_0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650391), typeof(glDrawElementsBaseVertex));
		}
	}

	internal void _0023_003DzQf1vAk0_003D(string _0023_003Dz5R27O6tttaspwzm_0024bQ_003D_003D)
	{
		_0023_003DzZDiieO9ddvkanBLIXDVvdQk_003D = OglRenderContext._0023_003DzOXLy_002480Tg5GP(new string[1] { _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650424) }, _0023_003Dz5R27O6tttaspwzm_0024bQ_003D_003D);
		EXT_framebuffer_object = OglRenderContext._0023_003DzOXLy_002480Tg5GP(new string[1] { _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650458) }, _0023_003Dz5R27O6tttaspwzm_0024bQ_003D_003D);
		EXT_framebuffer_blit = OglRenderContext._0023_003DzOXLy_002480Tg5GP(new string[1] { _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650490) }, _0023_003Dz5R27O6tttaspwzm_0024bQ_003D_003D);
		_0023_003Dzk4W_3C9jG_0024EAZx0nEMCpDzB6m0Ds_9GeMrw2WYo_003D = OglRenderContext._0023_003DzOXLy_002480Tg5GP(new string[1] { _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650268) }, _0023_003Dz5R27O6tttaspwzm_0024bQ_003D_003D);
		ARB_texture_non_power_of_two = OglRenderContext._0023_003DzOXLy_002480Tg5GP(new string[1] { _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650295) }, _0023_003Dz5R27O6tttaspwzm_0024bQ_003D_003D);
		ARB_multitexture = OglRenderContext._0023_003DzOXLy_002480Tg5GP(new string[1] { _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650321) }, _0023_003Dz5R27O6tttaspwzm_0024bQ_003D_003D);
		_0023_003Dz2uY0e4p5FrZxN0HqcGpT2svUVf0k = OglRenderContext._0023_003DzOXLy_002480Tg5GP(new string[1] { _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650359) }, _0023_003Dz5R27O6tttaspwzm_0024bQ_003D_003D);
		_0023_003DzqbcASXMeLKEGfrhNtZDvGAk_003D = OglRenderContext._0023_003DzOXLy_002480Tg5GP(new string[1] { _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649622) }, _0023_003Dz5R27O6tttaspwzm_0024bQ_003D_003D);
		ARB_shadow = OglRenderContext._0023_003DzOXLy_002480Tg5GP(new string[1] { _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649663) }, _0023_003Dz5R27O6tttaspwzm_0024bQ_003D_003D);
		_0023_003DzR0uW4gkobr0QHflnvg_003D_003D = OglRenderContext._0023_003DzOXLy_002480Tg5GP(new string[1] { _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649675) }, _0023_003Dz5R27O6tttaspwzm_0024bQ_003D_003D);
		EXT_vertex_array = OglRenderContext._0023_003DzOXLy_002480Tg5GP(new string[1] { _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649680) }, _0023_003Dz5R27O6tttaspwzm_0024bQ_003D_003D);
		ARB_vertex_buffer_object = OglRenderContext._0023_003DzOXLy_002480Tg5GP(new string[1] { _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649721) }, _0023_003Dz5R27O6tttaspwzm_0024bQ_003D_003D);
		EXT_packed_depth_stencil = OglRenderContext._0023_003DzOXLy_002480Tg5GP(new string[1] { _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649498) }, _0023_003Dz5R27O6tttaspwzm_0024bQ_003D_003D);
	}

	internal void _0023_003Dz97vvoZugIxL1()
	{
		string _0023_003DzT5a7mCU_003D = GetString(7938);
		_0023_003DzQlU53AFjJmCgCfoa_0024Q_003D_003D = _0023_003DzEDLTT7s_003D(_0023_003DzT5a7mCU_003D);
		Version version = new Version(3, 3);
		if (_0023_003DzQlU53AFjJmCgCfoa_0024Q_003D_003D < version)
		{
			throw new UnsupportedOglVersionException(_0023_003DzQlU53AFjJmCgCfoa_0024Q_003D_003D);
		}
		if (_0023_003DzQlU53AFjJmCgCfoa_0024Q_003D_003D != version)
		{
			Logger.Instance.Warn(string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649528), _0023_003DzQlU53AFjJmCgCfoa_0024Q_003D_003D, version), null, Array.Empty<object>());
		}
	}

	internal static Version _0023_003DzEDLTT7s_003D(string _0023_003DzT5a7mCU_003D)
	{
		Version result = new Version(0, 0);
		if (_0023_003DzT5a7mCU_003D != null)
		{
			string[] array = _0023_003DzT5a7mCU_003D.Split(' ')[0].Split('.');
			switch (array.Length)
			{
			case 2:
				result = new Version(int.Parse(array[0]), int.Parse(array[1]));
				break;
			case 3:
				result = new Version(int.Parse(array[0]), int.Parse(array[1]), int.Parse(array[2]));
				break;
			}
		}
		return result;
	}

	internal bool _0023_003Dz_sIl5y0_003D()
	{
		return _0023_003Dzs4SqNRf4FWbVcf1hLg_003D_003D > 0;
	}
}
