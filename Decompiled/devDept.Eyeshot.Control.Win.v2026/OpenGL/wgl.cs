using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using OpenGL.Delegates;

namespace OpenGL;

public class wgl
{
	public const int WGLEXT_VERSION = 4;

	public const int FRONT_COLOR_BUFFER_BIT_ARB = 1;

	public const int BACK_COLOR_BUFFER_BIT_ARB = 2;

	public const int DEPTH_BUFFER_BIT_ARB = 4;

	public const int STENCIL_BUFFER_BIT_ARB = 8;

	public const int SAMPLE_BUFFERS_ARB = 8257;

	public const int SAMPLES_ARB = 8258;

	public const int NUMBER_PIXEL_FORMATS_ARB = 8192;

	public const int DRAW_TO_WINDOW_ARB = 8193;

	public const int DRAW_TO_BITMAP_ARB = 8194;

	public const int ACCELERATION_ARB = 8195;

	public const int NEED_PALETTE_ARB = 8196;

	public const int NEED_SYSTEM_PALETTE_ARB = 8197;

	public const int SWAP_LAYER_BUFFERS_ARB = 8198;

	public const int SWAP_METHOD_ARB = 8199;

	public const int NUMBER_OVERLAYS_ARB = 8200;

	public const int NUMBER_UNDERLAYS_ARB = 8201;

	public const int TRANSPARENT_ARB = 8202;

	public const int TRANSPARENT_RED_VALUE_ARB = 8247;

	public const int TRANSPARENT_GREEN_VALUE_ARB = 8248;

	public const int TRANSPARENT_BLUE_VALUE_ARB = 8249;

	public const int TRANSPARENT_ALPHA_VALUE_ARB = 8250;

	public const int TRANSPARENT_INDEX_VALUE_ARB = 8251;

	public const int SHARE_DEPTH_ARB = 8204;

	public const int SHARE_STENCIL_ARB = 8205;

	public const int SHARE_ACCUM_ARB = 8206;

	public const int SUPPORT_GDI_ARB = 8207;

	public const int SUPPORT_OPENGL_ARB = 8208;

	public const int DOUBLE_BUFFER_ARB = 8209;

	public const int STEREO_ARB = 8210;

	public const int PIXEL_TYPE_ARB = 8211;

	public const int COLOR_BITS_ARB = 8212;

	public const int RED_BITS_ARB = 8213;

	public const int RED_SHIFT_ARB = 8214;

	public const int GREEN_BITS_ARB = 8215;

	public const int GREEN_SHIFT_ARB = 8216;

	public const int BLUE_BITS_ARB = 8217;

	public const int BLUE_SHIFT_ARB = 8218;

	public const int ALPHA_BITS_ARB = 8219;

	public const int ALPHA_SHIFT_ARB = 8220;

	public const int ACCUM_BITS_ARB = 8221;

	public const int ACCUM_RED_BITS_ARB = 8222;

	public const int ACCUM_GREEN_BITS_ARB = 8223;

	public const int ACCUM_BLUE_BITS_ARB = 8224;

	public const int ACCUM_ALPHA_BITS_ARB = 8225;

	public const int DEPTH_BITS_ARB = 8226;

	public const int STENCIL_BITS_ARB = 8227;

	public const int AUX_BUFFERS_ARB = 8228;

	public const int NO_ACCELERATION_ARB = 8229;

	public const int GENERIC_ACCELERATION_ARB = 8230;

	public const int FULL_ACCELERATION_ARB = 8231;

	public const int SWAP_EXCHANGE_ARB = 8232;

	public const int SWAP_COPY_ARB = 8233;

	public const int SWAP_UNDEFINED_ARB = 8234;

	public const int TYPE_RGBA_ARB = 8235;

	public const int TYPE_COLORINDEX_ARB = 8236;

	public const int ERROR_INVALID_PIXEL_TYPE_ARB = 8259;

	public const int ERROR_INCOMPATIBLE_DEVICE_CONTEXTS_ARB = 8276;

	public const int DRAW_TO_PBUFFER_ARB = 8237;

	public const int MAX_PBUFFER_PIXELS_ARB = 8238;

	public const int MAX_PBUFFER_WIDTH_ARB = 8239;

	public const int MAX_PBUFFER_HEIGHT_ARB = 8240;

	public const int PBUFFER_LARGEST_ARB = 8243;

	public const int PBUFFER_WIDTH_ARB = 8244;

	public const int PBUFFER_HEIGHT_ARB = 8245;

	public const int PBUFFER_LOST_ARB = 8246;

	public const int BIND_TO_TEXTURE_RGB_ARB = 8304;

	public const int BIND_TO_TEXTURE_RGBA_ARB = 8305;

	public const int TEXTURE_FORMAT_ARB = 8306;

	public const int TEXTURE_TARGET_ARB = 8307;

	public const int MIPMAP_TEXTURE_ARB = 8308;

	public const int TEXTURE_RGB_ARB = 8309;

	public const int TEXTURE_RGBA_ARB = 8310;

	public const int NO_TEXTURE_ARB = 8311;

	public const int TEXTURE_CUBE_MAP_ARB = 8312;

	public const int TEXTURE_1D_ARB = 8313;

	public const int TEXTURE_2D_ARB = 8314;

	public const int MIPMAP_LEVEL_ARB = 8315;

	public const int CUBE_MAP_FACE_ARB = 8316;

	public const int TEXTURE_CUBE_MAP_POSITIVE_X_ARB = 8317;

	public const int TEXTURE_CUBE_MAP_NEGATIVE_X_ARB = 8318;

	public const int TEXTURE_CUBE_MAP_POSITIVE_Y_ARB = 8319;

	public const int TEXTURE_CUBE_MAP_NEGATIVE_Y_ARB = 8320;

	public const int TEXTURE_CUBE_MAP_POSITIVE_Z_ARB = 8321;

	public const int TEXTURE_CUBE_MAP_NEGATIVE_Z_ARB = 8322;

	public const int FRONT_LEFT_ARB = 8323;

	public const int FRONT_RIGHT_ARB = 8324;

	public const int BACK_LEFT_ARB = 8325;

	public const int BACK_RIGHT_ARB = 8326;

	public const int AUX0_ARB = 8327;

	public const int AUX1_ARB = 8328;

	public const int AUX2_ARB = 8329;

	public const int AUX3_ARB = 8330;

	public const int AUX4_ARB = 8331;

	public const int AUX5_ARB = 8332;

	public const int AUX6_ARB = 8333;

	public const int AUX7_ARB = 8334;

	public const int AUX8_ARB = 8335;

	public const int AUX9_ARB = 8336;

	public const int ERROR_INVALID_PIXEL_TYPE_EXT = 8259;

	public const int NUMBER_PIXEL_FORMATS_EXT = 8192;

	public const int DRAW_TO_WINDOW_EXT = 8193;

	public const int DRAW_TO_BITMAP_EXT = 8194;

	public const int ACCELERATION_EXT = 8195;

	public const int NEED_PALETTE_EXT = 8196;

	public const int NEED_SYSTEM_PALETTE_EXT = 8197;

	public const int SWAP_LAYER_BUFFERS_EXT = 8198;

	public const int SWAP_METHOD_EXT = 8199;

	public const int NUMBER_OVERLAYS_EXT = 8200;

	public const int NUMBER_UNDERLAYS_EXT = 8201;

	public const int TRANSPARENT_EXT = 8202;

	public const int TRANSPARENT_VALUE_EXT = 8203;

	public const int SHARE_DEPTH_EXT = 8204;

	public const int SHARE_STENCIL_EXT = 8205;

	public const int SHARE_ACCUM_EXT = 8206;

	public const int SUPPORT_GDI_EXT = 8207;

	public const int SUPPORT_OPENGL_EXT = 8208;

	public const int DOUBLE_BUFFER_EXT = 8209;

	public const int STEREO_EXT = 8210;

	public const int PIXEL_TYPE_EXT = 8211;

	public const int COLOR_BITS_EXT = 8212;

	public const int RED_BITS_EXT = 8213;

	public const int RED_SHIFT_EXT = 8214;

	public const int GREEN_BITS_EXT = 8215;

	public const int GREEN_SHIFT_EXT = 8216;

	public const int BLUE_BITS_EXT = 8217;

	public const int BLUE_SHIFT_EXT = 8218;

	public const int ALPHA_BITS_EXT = 8219;

	public const int ALPHA_SHIFT_EXT = 8220;

	public const int ACCUM_BITS_EXT = 8221;

	public const int ACCUM_RED_BITS_EXT = 8222;

	public const int ACCUM_GREEN_BITS_EXT = 8223;

	public const int ACCUM_BLUE_BITS_EXT = 8224;

	public const int ACCUM_ALPHA_BITS_EXT = 8225;

	public const int DEPTH_BITS_EXT = 8226;

	public const int STENCIL_BITS_EXT = 8227;

	public const int AUX_BUFFERS_EXT = 8228;

	public const int NO_ACCELERATION_EXT = 8229;

	public const int GENERIC_ACCELERATION_EXT = 8230;

	public const int FULL_ACCELERATION_EXT = 8231;

	public const int SWAP_EXCHANGE_EXT = 8232;

	public const int SWAP_COPY_EXT = 8233;

	public const int SWAP_UNDEFINED_EXT = 8234;

	public const int TYPE_RGBA_EXT = 8235;

	public const int TYPE_COLORINDEX_EXT = 8236;

	public const int DRAW_TO_PBUFFER_EXT = 8237;

	public const int MAX_PBUFFER_PIXELS_EXT = 8238;

	public const int MAX_PBUFFER_WIDTH_EXT = 8239;

	public const int MAX_PBUFFER_HEIGHT_EXT = 8240;

	public const int OPTIMAL_PBUFFER_WIDTH_EXT = 8241;

	public const int OPTIMAL_PBUFFER_HEIGHT_EXT = 8242;

	public const int PBUFFER_LARGEST_EXT = 8243;

	public const int PBUFFER_WIDTH_EXT = 8244;

	public const int PBUFFER_HEIGHT_EXT = 8245;

	public const int DEPTH_FLOAT_EXT = 8256;

	public const int SAMPLE_BUFFERS_3DFX = 8288;

	public const int SAMPLES_3DFX = 8289;

	public const int SAMPLE_BUFFERS_EXT = 8257;

	public const int SAMPLES_EXT = 8258;

	public const int DIGITAL_VIDEO_CURSOR_ALPHA_VALUE_I3D = 8273;

	public const int DIGITAL_VIDEO_CURSOR_INCLUDED_I3D = 8274;

	public const int DIGITAL_VIDEO_GAMMA_CORRECTED_I3D = 8275;

	public const int GAMMA_TABLE_SIZE_I3D = 8270;

	public const int GAMMA_EXCLUDE_DESKTOP_I3D = 8271;

	public const int GENLOCK_SOURCE_MULTIVIEW_I3D = 8260;

	public const int GENLOCK_SOURCE_EXTENAL_SYNC_I3D = 8261;

	public const int GENLOCK_SOURCE_EXTENAL_FIELD_I3D = 8262;

	public const int GENLOCK_SOURCE_EXTENAL_TTL_I3D = 8263;

	public const int GENLOCK_SOURCE_DIGITAL_SYNC_I3D = 8264;

	public const int GENLOCK_SOURCE_DIGITAL_FIELD_I3D = 8265;

	public const int GENLOCK_SOURCE_EDGE_FALLING_I3D = 8266;

	public const int GENLOCK_SOURCE_EDGE_RISING_I3D = 8267;

	public const int GENLOCK_SOURCE_EDGE_BOTH_I3D = 8268;

	public const int IMAGE_BUFFER_MIN_ACCESS_I3D = 1;

	public const int IMAGE_BUFFER_LOCK_I3D = 2;

	public const int BIND_TO_TEXTURE_DEPTH_NV = 8355;

	public const int BIND_TO_TEXTURE_RECTANGLE_DEPTH_NV = 8356;

	public const int DEPTH_TEXTURE_FORMAT_NV = 8357;

	public const int TEXTURE_DEPTH_COMPONENT_NV = 8358;

	public const int DEPTH_COMPONENT_NV = 8359;

	public const int BIND_TO_TEXTURE_RECTANGLE_RGB_NV = 8352;

	public const int BIND_TO_TEXTURE_RECTANGLE_RGBA_NV = 8353;

	public const int TEXTURE_RECTANGLE_NV = 8354;

	public const int FLOAT_COMPONENTS_NV = 8368;

	public const int TEXTURE_FLOAT_R_NV = 8373;

	public const int TEXTURE_FLOAT_RG_NV = 8374;

	public const int TEXTURE_FLOAT_RGB_NV = 8375;

	public const int TEXTURE_FLOAT_RGBA_NV = 8376;

	public const int CONTEXT_MAJOR_VERSION_ARB = 8337;

	public const int CONTEXT_MINOR_VERSION_ARB = 8338;

	public const int CONTEXT_LAYER_PLANE_ARB = 8339;

	public const int CONTEXT_FLAGS_ARB = 8340;

	public const int CONTEXT_PROFILE_MASK_ARB = 37158;

	public const int CONTEXT_DEBUG_BIT_ARB = 1;

	public const int CONTEXT_FORWARD_COMPATIBLE_BIT_ARB = 2;

	public const int CONTEXT_CORE_PROFILE_BIT_ARB = 1;

	public const int CONTEXT_COMPATIBILITY_PROFILE_BIT_ARB = 2;

	public const int ERROR_INVALID_VERSION_ARB = 8341;

	public const int ERROR_INVALID_PROFILE_ARB = 8342;

	public static wglCreateContextAttribsARB CreateContextAttribsARB;

	public static wglGetExtensionsStringARB GetExtensionsStringARB;

	public const int FONT_LINES = 0;

	public const int FONT_POLYGONS = 1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static bool _0023_003Dzhz_0024YecXRoZOs;

	[DllImport("OPENGL32.DLL")]
	public static extern int GetProcAddress(IntPtr hwnd);

	[DllImport("OPENGL32.DLL", EntryPoint = "wglCreateContext")]
	public static extern IntPtr CreateContext(IntPtr dc);

	[DllImport("OPENGL32.DLL", EntryPoint = "wglMakeCurrent")]
	public static extern int MakeCurrent(IntPtr dc, IntPtr rc);

	[DllImport("OPENGL32.DLL", EntryPoint = "wglDeleteContext")]
	public static extern int DeleteContext(IntPtr rc);

	[DllImport("OPENGL32.DLL", EntryPoint = "wglSwapLayerBuffers")]
	public static extern int SwapLayerBuffers(IntPtr rc, uint flags);

	[DllImport("OPENGL32.DLL", EntryPoint = "wglGetCurrentContext")]
	public static extern IntPtr GetCurrentContext();

	[DllImport("OPENGL32.DLL", EntryPoint = "wglGetCurrentDC")]
	public static extern int GetCurrentDC();

	[DllImport("OPENGL32.DLL", EntryPoint = "wglShareLists")]
	public static extern int ShareLists(int r1, int r2);

	[DllImport("OPENGL32.DLL", EntryPoint = "wglGetProcAddress")]
	[CLSCompliant(false)]
	public static extern IntPtr GetProcAddress(string funcname);

	[DllImport("OPENGL32.DLL", EntryPoint = "wglCreateBufferRegionARB")]
	[CLSCompliant(false)]
	public static extern IntPtr CreateBufferRegionARB(IntPtr dc, int layerPlane, uint uType);

	[DllImport("OPENGL32.DLL", EntryPoint = "wglSaveBufferRegionARB")]
	public static extern bool SaveBufferRegionARB(IntPtr hRegion, int x, int y, int width, int height);

	[DllImport("OPENGL32.DLL", EntryPoint = "wglRestoreBufferRegionARB")]
	public static extern bool RestoreBufferRegionARB(IntPtr hRegion, int x, int y, int width, int height, int xSrc, int ySrc);

	[DllImport("OPENGL32.DLL", EntryPoint = "wglDeleteBufferRegionARB")]
	public static extern void DeleteBufferRegionARB(IntPtr hRegion);

	[DllImport("OPENGL32.DLL", CharSet = CharSet.Unicode, EntryPoint = "wglUseFontBitmaps")]
	[CLSCompliant(false)]
	public static extern bool UseFontBitmaps(IntPtr dc, int start, int count, uint listbase);

	[DllImport("OPENGL32.DLL", CharSet = CharSet.Unicode, EntryPoint = "wglUseFontOutlines")]
	[CLSCompliant(false)]
	public static extern bool UseFontOutlines(IntPtr dc, uint start, uint count, uint listbase, float deviation, float extrusion, int format, [Out][MarshalAs(UnmanagedType.LPArray)] GlyphMetricsFloat[] gmf);

	internal static void _0023_003DzT0ja7F4mctzk()
	{
		if (!_0023_003Dzhz_0024YecXRoZOs)
		{
			_0023_003Dzhz_0024YecXRoZOs = true;
			CreateContextAttribsARB = (wglCreateContextAttribsARB)gl._0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649587), typeof(wglCreateContextAttribsARB));
			GetExtensionsStringARB = (wglGetExtensionsStringARB)gl._0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649874), typeof(wglGetExtensionsStringARB));
		}
	}

	internal static string _0023_003Dz_6Biob8_003D(IntPtr _0023_003DzMUy2r_A_003D)
	{
		return Marshal.PtrToStringAnsi(GetExtensionsStringARB(_0023_003DzMUy2r_A_003D));
	}
}
