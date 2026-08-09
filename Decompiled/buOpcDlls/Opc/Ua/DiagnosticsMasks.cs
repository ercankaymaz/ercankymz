using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[Flags]
[ComVisible(true)]
public enum DiagnosticsMasks : uint
{
	None = 0u,
	ServiceSymbolicId = 1u,
	ServiceLocalizedText = 2u,
	ServiceAdditionalInfo = 4u,
	ServiceInnerStatusCode = 8u,
	ServiceInnerDiagnostics = 0x10u,
	ServiceSymbolicIdAndText = 3u,
	ServiceNoInnerStatus = 0xFu,
	ServiceAll = 0x1Fu,
	OperationSymbolicId = 0x20u,
	OperationLocalizedText = 0x40u,
	OperationAdditionalInfo = 0x80u,
	OperationInnerStatusCode = 0x100u,
	OperationInnerDiagnostics = 0x200u,
	OperationSymbolicIdAndText = 0x60u,
	OperationNoInnerStatus = 0xE0u,
	OperationAll = 0x3E0u,
	SymbolicId = 0x21u,
	LocalizedText = 0x42u,
	AdditionalInfo = 0x84u,
	InnerStatusCode = 0x108u,
	InnerDiagnostics = 0x210u,
	SymbolicIdAndText = 0x63u,
	NoInnerStatus = 0xEFu,
	All = 0x3FFu,
	UserPermissionAdditionalInfo = 0x80000000u
}
