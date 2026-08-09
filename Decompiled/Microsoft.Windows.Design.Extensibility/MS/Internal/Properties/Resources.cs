using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace MS.Internal.Properties;

[CompilerGenerated]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
[DebuggerNonUserCode]
internal class Resources
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (object.ReferenceEquals(resourceMan, null))
			{
				ResourceManager resourceManager = new ResourceManager("MS.Internal.Properties.Resources", typeof(Resources).Assembly);
				resourceMan = resourceManager;
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	internal static string Error_ArgIncorrectType => ResourceManager.GetString("Error_ArgIncorrectType", resourceCulture);

	internal static string Error_ArgIncorrectTypeValue => ResourceManager.GetString("Error_ArgIncorrectTypeValue", resourceCulture);

	internal static string Error_CannotConvertValueToString => ResourceManager.GetString("Error_CannotConvertValueToString", resourceCulture);

	internal static string Error_CannotUpdateValueFromStringValue => ResourceManager.GetString("Error_CannotUpdateValueFromStringValue", resourceCulture);

	internal static string Error_DerivedContextItem => ResourceManager.GetString("Error_DerivedContextItem", resourceCulture);

	internal static string Error_DesignerActionItemSharing => ResourceManager.GetString("Error_DesignerActionItemSharing", resourceCulture);

	internal static string Error_DuplicateItem => ResourceManager.GetString("Error_DuplicateItem", resourceCulture);

	internal static string Error_DuplicateService => ResourceManager.GetString("Error_DuplicateService", resourceCulture);

	internal static string Error_EnumerationNotReady => ResourceManager.GetString("Error_EnumerationNotReady", resourceCulture);

	internal static string Error_IncompatiblePositionReference => ResourceManager.GetString("Error_IncompatiblePositionReference", resourceCulture);

	internal static string Error_IncorrectServiceType => ResourceManager.GetString("Error_IncorrectServiceType", resourceCulture);

	internal static string Error_IncorrectTypePassed => ResourceManager.GetString("Error_IncorrectTypePassed", resourceCulture);

	internal static string Error_InvalidArrayIndex => ResourceManager.GetString("Error_InvalidArrayIndex", resourceCulture);

	internal static string Error_InvalidFactoryType => ResourceManager.GetString("Error_InvalidFactoryType", resourceCulture);

	internal static string Error_InvalidRedirectParent => ResourceManager.GetString("Error_InvalidRedirectParent", resourceCulture);

	internal static string Error_LocalAssemblyNameChanged => ResourceManager.GetString("Error_LocalAssemblyNameChanged", resourceCulture);

	internal static string Error_NoCreationType => ResourceManager.GetString("Error_NoCreationType", resourceCulture);

	internal static string Error_NoPropertyValue => ResourceManager.GetString("Error_NoPropertyValue", resourceCulture);

	internal static string Error_NullImplementation => ResourceManager.GetString("Error_NullImplementation", resourceCulture);

	internal static string Error_NullService => ResourceManager.GetString("Error_NullService", resourceCulture);

	internal static string Error_ObjectAlreadyActive => ResourceManager.GetString("Error_ObjectAlreadyActive", resourceCulture);

	internal static string Error_ObjectNotActive => ResourceManager.GetString("Error_ObjectNotActive", resourceCulture);

	internal static string Error_ParentNotSupported => ResourceManager.GetString("Error_ParentNotSupported", resourceCulture);

	internal static string Error_PropertyIsReadOnly => ResourceManager.GetString("Error_PropertyIsReadOnly", resourceCulture);

	internal static string Error_PropertyNotFound => ResourceManager.GetString("Error_PropertyNotFound", resourceCulture);

	internal static string Error_PropertyValueEditor_InvalidDialogValueEditorCommandInvocation => ResourceManager.GetString("Error_PropertyValueEditor_InvalidDialogValueEditorCommandInvocation", resourceCulture);

	internal static string Error_PropertyValueEditor_InvalidDialogValueEditorEditorValue => ResourceManager.GetString("Error_PropertyValueEditor_InvalidDialogValueEditorEditorValue", resourceCulture);

	internal static string Error_RecursionResolvingService => ResourceManager.GetString("Error_RecursionResolvingService", resourceCulture);

	internal static string Error_RequiredService => ResourceManager.GetString("Error_RequiredService", resourceCulture);

	internal static string Error_TableValidationFailed => ResourceManager.GetString("Error_TableValidationFailed", resourceCulture);

	internal static string Error_ToolAlreadyActive => ResourceManager.GetString("Error_ToolAlreadyActive", resourceCulture);

	internal static string Error_UnknownMemberDescriptor => ResourceManager.GetString("Error_UnknownMemberDescriptor", resourceCulture);

	internal static string Error_ValidationAmbiguousMember => ResourceManager.GetString("Error_ValidationAmbiguousMember", resourceCulture);

	internal static string Error_ValidationNoMatchingMember => ResourceManager.GetString("Error_ValidationNoMatchingMember", resourceCulture);

	internal static string Error_ValueGetFailed => ResourceManager.GetString("Error_ValueGetFailed", resourceCulture);

	internal static string Error_ValueSetFailed => ResourceManager.GetString("Error_ValueSetFailed", resourceCulture);

	internal static string ToolDescription_CreateInstance => ResourceManager.GetString("ToolDescription_CreateInstance", resourceCulture);

	internal Resources()
	{
	}
}
