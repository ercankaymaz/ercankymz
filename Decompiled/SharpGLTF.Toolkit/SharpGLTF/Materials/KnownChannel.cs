using System;

namespace SharpGLTF.Materials;

public enum KnownChannel
{
	Normal,
	Occlusion,
	Emissive,
	BaseColor,
	MetallicRoughness,
	[Obsolete("This channel is used by KHR_materials_pbrSpecularGlossiness extension, which has been deprecated by Khronos; use BaseColor instead.")]
	Diffuse,
	[Obsolete("This channel is used by KHR_materials_pbrSpecularGlossiness extension, which has been deprecated by Khronos; use SpecularColor instead.")]
	SpecularGlossiness,
	ClearCoat,
	ClearCoatNormal,
	ClearCoatRoughness,
	Transmission,
	SheenColor,
	SheenRoughness,
	SpecularColor,
	SpecularFactor,
	VolumeThickness,
	VolumeAttenuation,
	Iridescence,
	IridescenceThickness,
	Anisotropy,
	DiffuseTransmissionColor,
	DiffuseTransmissionFactor
}
