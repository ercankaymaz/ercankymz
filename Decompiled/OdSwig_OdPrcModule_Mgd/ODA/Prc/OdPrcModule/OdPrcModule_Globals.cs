using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcModule_Globals
{
	public static readonly uint UINT_MAX = OdPrcModule_GlobalsPINVOKE.UINT_MAX_get();

	public static readonly uint ULONG_MAX = OdPrcModule_GlobalsPINVOKE.ULONG_MAX_get();

	public static readonly int _MSC_VER = OdPrcModule_GlobalsPINVOKE._MSC_VER_get();

	public static readonly int ODCHAR_IS_INT16LE = OdPrcModule_GlobalsPINVOKE.ODCHAR_IS_INT16LE_get();

	public static readonly int OD_SIZEOF_INT = OdPrcModule_GlobalsPINVOKE.OD_SIZEOF_INT_get();

	public static readonly int OD_SIZEOF_LONG = OdPrcModule_GlobalsPINVOKE.OD_SIZEOF_LONG_get();

	public static readonly string PERCENT18LONG = OdPrcModule_GlobalsPINVOKE.PERCENT18LONG_get();

	public static readonly string HANDLEFORMAT = OdPrcModule_GlobalsPINVOKE.HANDLEFORMAT_get();

	public static readonly string PRId64 = OdPrcModule_GlobalsPINVOKE.PRId64_get();

	public static readonly string PRIu64 = OdPrcModule_GlobalsPINVOKE.PRIu64_get();

	public static readonly string PRIx64 = OdPrcModule_GlobalsPINVOKE.PRIx64_get();

	public static readonly string PRIX64 = OdPrcModule_GlobalsPINVOKE.PRIX64_get();

	public static readonly int OD_SIZEOF_PTR = OdPrcModule_GlobalsPINVOKE.OD_SIZEOF_PTR_get();

	public const int PRC_TYPE_ROOT = 0;

	public const int PRC_TYPE_ROOT_PRCBase = 1;

	public const int PRC_TYPE_ROOT_PRCBaseWithGraphics = 2;

	public const int PRC_TYPE_CRV = 10;

	public const int PRC_TYPE_SURF = 75;

	public const int PRC_TYPE_TOPO = 140;

	public const int PRC_TYPE_TESS = 170;

	public const int PRC_TYPE_MISC = 200;

	public const int PRC_TYPE_RI = 230;

	public const int PRC_TYPE_ASM = 300;

	public const int PRC_TYPE_MKP = 500;

	public const int PRC_TYPE_GRAPH = 700;

	public const int PRC_TYPE_MATH = 900;

	public const int PRC_TYPE_CRV_Base = 11;

	public const int PRC_TYPE_CRV_Blend02Boundary = 12;

	public const int PRC_TYPE_CRV_NURBS = 13;

	public const int PRC_TYPE_CRV_Circle = 14;

	public const int PRC_TYPE_CRV_Composite = 15;

	public const int PRC_TYPE_CRV_OnSurf = 16;

	public const int PRC_TYPE_CRV_Ellipse = 17;

	public const int PRC_TYPE_CRV_Equation = 18;

	public const int PRC_TYPE_CRV_Helix = 19;

	public const int PRC_TYPE_CRV_Hyperbola = 20;

	public const int PRC_TYPE_CRV_Intersection = 21;

	public const int PRC_TYPE_CRV_Line = 22;

	public const int PRC_TYPE_CRV_Offset = 23;

	public const int PRC_TYPE_CRV_Parabola = 24;

	public const int PRC_TYPE_CRV_PolyLine = 25;

	public const int PRC_TYPE_CRV_Transform = 26;

	public const int PRC_TYPE_SURF_Base = 76;

	public const int PRC_TYPE_SURF_Blend01 = 77;

	public const int PRC_TYPE_SURF_Blend02 = 78;

	public const int PRC_TYPE_SURF_Blend03 = 79;

	public const int PRC_TYPE_SURF_NURBS = 80;

	public const int PRC_TYPE_SURF_Cone = 81;

	public const int PRC_TYPE_SURF_Cylinder = 82;

	public const int PRC_TYPE_SURF_Cylindrical = 83;

	public const int PRC_TYPE_SURF_Offset = 84;

	public const int PRC_TYPE_SURF_Pipe = 85;

	public const int PRC_TYPE_SURF_Plane = 86;

	public const int PRC_TYPE_SURF_Ruled = 87;

	public const int PRC_TYPE_SURF_Sphere = 88;

	public const int PRC_TYPE_SURF_Revolution = 89;

	public const int PRC_TYPE_SURF_Extrusion = 90;

	public const int PRC_TYPE_SURF_FromCurves = 91;

	public const int PRC_TYPE_SURF_Torus = 92;

	public const int PRC_TYPE_SURF_Transform = 93;

	public const int PRC_TYPE_SURF_Blend04 = 94;

	public const int PRC_TYPE_TOPO_Context = 141;

	public const int PRC_TYPE_TOPO_Item = 142;

	public const int PRC_TYPE_TOPO_MultipleVertex = 143;

	public const int PRC_TYPE_TOPO_UniqueVertex = 144;

	public const int PRC_TYPE_TOPO_WireEdge = 145;

	public const int PRC_TYPE_TOPO_Edge = 146;

	public const int PRC_TYPE_TOPO_CoEdge = 147;

	public const int PRC_TYPE_TOPO_Loop = 148;

	public const int PRC_TYPE_TOPO_Face = 149;

	public const int PRC_TYPE_TOPO_Shell = 150;

	public const int PRC_TYPE_TOPO_Connex = 151;

	public const int PRC_TYPE_TOPO_Body = 152;

	public const int PRC_TYPE_TOPO_SingleWireBody = 153;

	public const int PRC_TYPE_TOPO_BrepData = 154;

	public const int PRC_TYPE_TOPO_SingleWireBodyCompress = 155;

	public const int PRC_TYPE_TOPO_BrepDataCompress = 156;

	public const int PRC_TYPE_TOPO_WireBody = 157;

	public const int PRC_TYPE_TESS_Base = 171;

	public const int PRC_TYPE_TESS_3D = 172;

	public const int PRC_TYPE_TESS_3D_Compressed = 173;

	public const int PRC_TYPE_TESS_Face = 174;

	public const int PRC_TYPE_TESS_3D_Wire = 175;

	public const int PRC_TYPE_TESS_Markup = 176;

	public const int PRC_TYPE_MISC_Attribute = 201;

	public const int PRC_TYPE_MISC_CartesianTransformation = 202;

	public const int PRC_TYPE_MISC_EntityReference = 203;

	public const int PRC_TYPE_MISC_MarkupLinkedItem = 204;

	public const int PRC_TYPE_MISC_ReferenceOnPRCBase = 205;

	public const int PRC_TYPE_MISC_ReferenceOnTopology = 206;

	public const int PRC_TYPE_MISC_GeneralTransformation = 207;

	public const int PRC_TYPE_RI_RepresentationItem = 231;

	public const int PRC_TYPE_RI_BrepModel = 232;

	public const int PRC_TYPE_RI_Curve = 233;

	public const int PRC_TYPE_RI_Direction = 234;

	public const int PRC_TYPE_RI_Plane = 235;

	public const int PRC_TYPE_RI_PointSet = 236;

	public const int PRC_TYPE_RI_PolyBrepModel = 237;

	public const int PRC_TYPE_RI_PolyWire = 238;

	public const int PRC_TYPE_RI_Set = 239;

	public const int PRC_TYPE_RI_CoordinateSystem = 240;

	public const int PRC_TYPE_ASM_ModelFile = 301;

	public const int PRC_TYPE_ASM_FileStructure = 302;

	public const int PRC_TYPE_ASM_FileStructureGlobals = 303;

	public const int PRC_TYPE_ASM_FileStructureTree = 304;

	public const int PRC_TYPE_ASM_FileStructureTessellation = 305;

	public const int PRC_TYPE_ASM_FileStructureGeometry = 306;

	public const int PRC_TYPE_ASM_FileStructureExtraGeometry = 307;

	public const int PRC_TYPE_ASM_ProductOccurrence = 310;

	public const int PRC_TYPE_ASM_PartDefinition = 311;

	public const int PRC_TYPE_ASM_Filter = 320;

	public const int PRC_TYPE_MKP_View = 501;

	public const int PRC_TYPE_MKP_Markup = 502;

	public const int PRC_TYPE_MKP_Leader = 503;

	public const int PRC_TYPE_MKP_AnnotationItem = 504;

	public const int PRC_TYPE_MKP_AnnotationSet = 505;

	public const int PRC_TYPE_MKP_AnnotationReference = 506;

	public const int PRC_TYPE_GRAPH_Style = 701;

	public const int PRC_TYPE_GRAPH_Material = 702;

	public const int PRC_TYPE_GRAPH_Picture = 703;

	public const int PRC_TYPE_GRAPH_TextureApplication = 711;

	public const int PRC_TYPE_GRAPH_TextureDefinition = 712;

	public const int PRC_TYPE_GRAPH_TextureTransformation = 713;

	public const int PRC_TYPE_GRAPH_LinePattern = 721;

	public const int PRC_TYPE_GRAPH_FillPattern = 722;

	public const int PRC_TYPE_GRAPH_DottingPattern = 723;

	public const int PRC_TYPE_GRAPH_HatchingPattern = 724;

	public const int PRC_TYPE_GRAPH_SolidPattern = 725;

	public const int PRC_TYPE_GRAPH_VPicturePattern = 726;

	public const int PRC_TYPE_GRAPH_AmbientLight = 731;

	public const int PRC_TYPE_GRAPH_PointLight = 732;

	public const int PRC_TYPE_GRAPH_DirectionalLight = 733;

	public const int PRC_TYPE_GRAPH_SpotLight = 734;

	public const int PRC_TYPE_GRAPH_SceneDisplayParameters = 741;

	public const int PRC_TYPE_GRAPH_Camera = 742;

	public const int PRC_TYPE_MATH_FCT_1D = 901;

	public const int PRC_TYPE_MATH_FCT_1D_Polynom = 902;

	public const int PRC_TYPE_MATH_FCT_1D_Trigonometric = 903;

	public const int PRC_TYPE_MATH_FCT_1D_Fraction = 904;

	public const int PRC_TYPE_MATH_FCT_1D_ArctanCos = 905;

	public const int PRC_TYPE_MATH_FCT_1D_Combination = 906;

	public const int PRC_TYPE_MATH_FCT_3D = 910;

	public const int PRC_TYPE_MATH_FCT_3D_Linear = 911;

	public const int PRC_TYPE_MATH_FCT_3D_NonLinear = 912;

	public const int PRC_PRODUCT_FLAG_DEFAULT = 1;

	public const int PRC_PRODUCT_FLAG_INTERNAL = 2;

	public const int PRC_PRODUCT_FLAG_CONTAINER = 4;

	public const int PRC_PRODUCT_FLAG_CONFIG = 8;

	public const int PRC_PRODUCT_FLAG_VIEW = 16;

	public const int PRC_TRANSFORMATION_Identity = 0;

	public const int PRC_TRANSFORMATION_Translate = 1;

	public const int PRC_TRANSFORMATION_Rotate = 2;

	public const int PRC_TRANSFORMATION_Mirror = 4;

	public const int PRC_TRANSFORMATION_Scale = 8;

	public const int PRC_TRANSFORMATION_NonUniformScale = 16;

	public const int PRC_TRANSFORMATION_NonOrtho = 32;

	public const int PRC_TRANSFORMATION_Homogeneous = 64;

	public const int PRC_FACETESSDATA_Polyface = 1;

	public const int PRC_FACETESSDATA_Triangle = 2;

	public const int PRC_FACETESSDATA_TriangleFan = 4;

	public const int PRC_FACETESSDATA_TriangleStripe = 8;

	public const int PRC_FACETESSDATA_PolyfaceOneNormal = 16;

	public const int PRC_FACETESSDATA_TriangleOneNormal = 32;

	public const int PRC_FACETESSDATA_TriangleFanOneNormal = 64;

	public const int PRC_FACETESSDATA_TriangleStripeOneNormal = 128;

	public const int PRC_FACETESSDATA_PolyfaceTextured = 256;

	public const int PRC_FACETESSDATA_TriangleTextured = 512;

	public const int PRC_FACETESSDATA_TriangleFanTextured = 1024;

	public const int PRC_FACETESSDATA_TriangleStripeTextured = 2048;

	public const int PRC_FACETESSDATA_PolyfaceOneNormalTextured = 4096;

	public const int PRC_FACETESSDATA_TriangleOneNormalTextured = 8192;

	public const int PRC_FACETESSDATA_TriangleFanOneNormalTextured = 16384;

	public const int PRC_FACETESSDATA_TriangleStripeOneNormalTextured = 32768;

	public const int PRC_FACETESSDATA_NORMAL_Single = 1073741824;

	public const int PRC_FACETESSDATA_NORMAL_Mask = 1073741823;

	public const int PRC_FACETESSDATA_WIRE_IsNotDrawn = 16384;

	public const int PRC_FACETESSDATA_WIRE_IsClosing = 32768;

	public const int PRC_3DWIRETESSDATA_IsClosing = 268435456;

	public const int PRC_3DWIRETESSDATA_IsContinuous = 536870912;

	public const int PRC_TEXTURE_MAPPING_DIFFUSE = 1;

	public const int PRC_TEXTURE_MAPPING_BUMP = 2;

	public const int PRC_TEXTURE_MAPPING_OPACITY = 4;

	public const int PRC_TEXTURE_MAPPING_SPHERICAL_REFLECTION = 8;

	public const int PRC_TEXTURE_MAPPING_CUBICAL_REFLECTION = 16;

	public const int PRC_TEXTURE_MAPPING_REFRACTION = 32;

	public const int PRC_TEXTURE_MAPPING_SPECULAR = 64;

	public const int PRC_TEXTURE_MAPPING_AMBIENT = 128;

	public const int PRC_TEXTURE_MAPPING_EMISSION = 256;

	public const int PRC_TEXTURE_APPLYING_MODE_NONE = 0;

	public const int PRC_TEXTURE_APPLYING_MODE_LIGHTING = 1;

	public const int PRC_TEXTURE_APPLYING_MODE_ALPHATEST = 2;

	public const int PRC_TEXTURE_APPLYING_MODE_VERTEXCOLOR = 4;

	public const int PRC_TEXTURE_MAPPING_COMPONENTS_RED = 1;

	public const int PRC_TEXTURE_MAPPING_COMPONENTS_GREEN = 2;

	public const int PRC_TEXTURE_MAPPING_COMPONENTS_BLUE = 4;

	public const int PRC_TEXTURE_MAPPING_COMPONENTS_RGB = 7;

	public const int PRC_TEXTURE_MAPPING_COMPONENTS_ALPHA = 8;

	public const int PRC_TEXTURE_MAPPING_COMPONENTS_RGBA = 15;

	public const int PRC_GRAPHICS_Show = 1;

	public const int PRC_GRAPHICS_SonHeritShow = 2;

	public const int PRC_GRAPHICS_FatherHeritShow = 4;

	public const int PRC_GRAPHICS_SonHeritColor = 8;

	public const int PRC_GRAPHICS_FatherHeritColor = 16;

	public const int PRC_GRAPHICS_SonHeritLayer = 32;

	public const int PRC_GRAPHICS_FatherHeritLayer = 64;

	public const int PRC_GRAPHICS_SonHeritTransparency = 128;

	public const int PRC_GRAPHICS_FatherHeritTransparency = 256;

	public const int PRC_GRAPHICS_SonHeritLinePattern = 512;

	public const int PRC_GRAPHICS_FatherHeritLinePattern = 1024;

	public const int PRC_GRAPHICS_SonHeritLineWidth = 2048;

	public const int PRC_GRAPHICS_FatherHeritLineWidth = 4096;

	public const int PRC_GRAPHICS_Removed = 8192;

	public const int PRC_MARKUP_IsHidden = 1;

	public const int PRC_MARKUP_HasFrame = 2;

	public const int PRC_MARKUP_IsNotModifiable = 4;

	public const int PRC_MARKUP_IsZoomable = 8;

	public const int PRC_MARKUP_IsOnTop = 16;

	public const int PRC_MARKUP_IsFlipable = 32;

	public const int PRC_RENDERING_PARAMETER_SPECIAL_CULLING = 1;

	public const int PRC_RENDERING_PARAMETER_FRONT_CULLING = 2;

	public const int PRC_RENDERING_PARAMETER_BACK_CULLING = 4;

	public const int PRC_RENDERING_PARAMETER_NO_LIGHT = 8;

	public const int PRC_MARKUP_IsMatrix = 134217728;

	public const int PRC_MARKUP_IsExtraData = 67108864;

	public const int PRC_MARKUP_IntegerMask = 1048575;

	public const int PRC_MARKUP_ExtraDataType = 65011712;

	public const int PRC_MARKUP_ExtraDataType_Pattern = 67108864;

	public const int PRC_MARKUP_ExtraDataType_Picture = 69206016;

	public const int PRC_MARKUP_ExtraDataType_Triangles = 71303168;

	public const int PRC_MARKUP_ExtraDataType_Quads = 73400320;

	public const int PRC_MARKUP_ExtraDataType_FaceViewMode = 79691776;

	public const int PRC_MARKUP_ExtraDataType_FrameDrawMode = 81788928;

	public const int PRC_MARKUP_ExtraDataType_FixedSizeMode = 83886080;

	public const int PRC_MARKUP_ExtraDataType_Symbol = 85983232;

	public const int PRC_MARKUP_ExtraDataType_Cylinder = 88080384;

	public const int PRC_MARKUP_ExtraDataType_Color = 90177536;

	public const int PRC_MARKUP_ExtraDataType_LineStipple = 92274688;

	public const int PRC_MARKUP_ExtraDataType_Font = 94371840;

	public const int PRC_MARKUP_ExtraDataType_Text = 96468992;

	public const int PRC_MARKUP_ExtraDataType_Points = 98566144;

	public const int PRC_MARKUP_ExtraDataType_Polygon = 100663296;

	public const int PRC_MARKUP_ExtraDataType_LineWidth = 102760448;

	public const int PRC_Font_Bold = 2;

	public const int PRC_Font_Italic = 4;

	public const int PRC_Font_Underlined = 8;

	public const int PRC_Font_StrikedOut = 16;

	public const int PRC_Font_Overlined = 32;

	public const int PRC_Font_Streched = 64;

	public const int PRC_Font_Wired = 128;

	public const int PRC_Font_FixedWidth = 256;

	public const int PRC_CONTEXT_OuterLoopFirst = 1;

	public const int PRC_CONTEXT_NoClamp = 2;

	public const int PRC_CONTEXT_NoSplit = 4;

	public const int PRC_BODY_BBOX_Evaluation = 1;

	public const int PRC_BODY_BBOX_Precise = 2;

	public const int PRC_BODY_BBOX_CADData = 3;

	public const int PRC_HCG_NewLoop = 0;

	public const int PRC_HCG_EndLoop = 1;

	public const int PRC_HCG_IsoPlane = 2;

	public const int PRC_HCG_IsoCylinder = 3;

	public const int PRC_HCG_IsoTorus = 4;

	public const int PRC_HCG_IsoSphere = 5;

	public const int PRC_HCG_IsoCone = 6;

	public const int PRC_HCG_IsoNurbs = 7;

	public const int PRC_HCG_AnaPlane = 8;

	public const int PRC_HCG_AnaCylinder = 9;

	public const int PRC_HCG_AnaTorus = 10;

	public const int PRC_HCG_AnaSphere = 11;

	public const int PRC_HCG_AnaCone = 12;

	public const int PRC_HCG_AnaNurbs = 13;

	public const int PRC_HCG_AnaGenericFace = 14;

	public const int PRC_HCG_Line = 0;

	public const int PRC_HCG_Circle = 1;

	public const int PRC_HCG_BsplineHermiteCurve = 2;

	public const int PRC_HCG_Ellipse = 12;

	public const int PRC_HCG_CompositeCurve = 13;

	public const int PRC_Teigha_Application_ID_1 = 0;

	public const int PRC_Teigha_Application_ID_2 = 0;

	public const int PRC_Teigha_Application_ID_3 = 0;

	public const int PRC_Teigha_Application_ID_4 = 0;

	public const int PRC_INTERSECTION_CROSS_POINT_SURFACE1 = 1;

	public const int PRC_INTERSECTION_CROSS_POINT_SURFACE2 = 2;

	public const int PRC_INTERSECTION_CROSS_POINT_INSIDE_CURVE_INTERVAL = 4;

	public static uint OdPrcVersion
	{
		get
		{
			uint result = OdPrcModule_GlobalsPINVOKE.OdPrcVersion_get();
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public static void throw_native_exception_string(string msg)
	{
		OdPrcModule_GlobalsPINVOKE.throw_native_exception_string(msg);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void throw_native_OdError(OdEdEmptyInput err)
	{
		OdPrcModule_GlobalsPINVOKE.throw_native_OdError__SWIG_0(OdEdEmptyInput.getCPtr(err));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void throw_native_OdError(OdEdOtherInput err)
	{
		OdPrcModule_GlobalsPINVOKE.throw_native_OdError__SWIG_1(OdEdOtherInput.getCPtr(err));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void throw_native_OdError(OdError err)
	{
		OdPrcModule_GlobalsPINVOKE.throw_native_OdError__SWIG_2(OdError.getCPtr(err));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void odbmPrintConsoleString(string fmt)
	{
		OdPrcModule_GlobalsPINVOKE.odbmPrintConsoleString(fmt);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdResult createBrepBuilder(OdBrepBuilder bbuilder, BrepType bbType)
	{
		int result = OdPrcModule_GlobalsPINVOKE.createBrepBuilder(OdBrepBuilder.getCPtr(bbuilder), (int)bbType);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdGeExtents3d OdPrcExtentsCalculator_calculateExtents(OdPrcFile pPRCFile)
	{
		OdGeExtents3d result = new OdGeExtents3d(OdPrcModule_GlobalsPINVOKE.OdPrcExtentsCalculator_calculateExtents(OdPrcFile.getCPtr(pPRCFile)), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGsPrcLayoutHelper OdPrcGsManager_setupActiveLayoutViews(OdGsDevice pDevice, OdGiContextForPrcDatabase pGiCtx)
	{
		OdGsPrcLayoutHelper rXObject = Helpers.GetRXObject<OdGsPrcLayoutHelper>(OdPrcModule_GlobalsPINVOKE.OdPrcGsManager_setupActiveLayoutViews(OdGsDevice.getCPtr(pDevice), OdGiContextForPrcDatabase.getCPtr(pGiCtx)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}
}
