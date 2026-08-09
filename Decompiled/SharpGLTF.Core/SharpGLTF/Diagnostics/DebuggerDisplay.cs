using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SharpGLTF.Memory;
using SharpGLTF.Schema2;

namespace SharpGLTF.Diagnostics;

internal static class DebuggerDisplay
{
	internal static string GetAttributeShortName(string attributeName)
	{
		string text = string.Empty;
		if (attributeName.EndsWith("DELTA"))
		{
			attributeName = attributeName.Substring(0, attributeName.Length - 5);
			text = "Δ";
		}
		return attributeName switch
		{
			"POSITION" => "\ud835\udc0f", 
			"NORMAL" => "\ud835\udeb4", 
			"TANGENT" => "\ud835\udebb", 
			"COLOR_0" => "\ud835\udc02₀", 
			"COLOR_1" => "\ud835\udc02₁", 
			"TEXCOORD_0" => "\ud835\udc14\ud835\udc15₀", 
			"TEXCOORD_1" => "\ud835\udc14\ud835\udc15₁", 
			"TEXCOORD_2" => "\ud835\udc14\ud835\udc15₂", 
			"TEXCOORD_3" => "\ud835\udc14\ud835\udc15₃", 
			"TEXCOORD_4" => "\ud835\udc14\ud835\udc15₄", 
			"TEXCOORD_5" => "\ud835\udc14\ud835\udc15₅", 
			"TEXCOORD_6" => "\ud835\udc14\ud835\udc15₆", 
			"TEXCOORD_7" => "\ud835\udc14\ud835\udc15₇", 
			"JOINTS_0" => "\ud835\udc09₀", 
			"JOINTS_1" => "\ud835\udc09₁", 
			"WEIGHTS_0" => "\ud835\udc16₀", 
			"WEIGHTS_1" => "\ud835\udc16₁", 
			_ => attributeName + text, 
		};
	}

	public static string ToReport(this MemoryAccessInfo minfo)
	{
		string text = GetAttributeShortName(minfo.Name);
		if (minfo.ByteOffset != 0)
		{
			text += $" Offs:{minfo.ByteOffset}ᴮʸᵗᵉˢ";
		}
		if (minfo.ByteStride != 0)
		{
			text += $" Strd:{minfo.ByteStride}ᴮʸᵗᵉˢ";
		}
		return text + $" {minfo.Encoding.ToDebugString(minfo.Dimensions, minfo.Normalized)}[{minfo.ItemsCount}]";
	}

	public static string ToReport(this BufferView bv)
	{
		string empty = string.Empty;
		empty = (bv.IsVertexBuffer ? (empty + " VertexView") : ((!bv.IsIndexBuffer) ? (empty + " BufferView") : (empty + " IndexView")));
		ArraySegment<byte> content = bv.Content;
		empty += $"[{bv.LogicalIndex}ᴵᵈˣ]";
		empty += $"[{content.Count}ᴮʸᵗᵉˢ]";
		if (bv.ByteStride > 0)
		{
			empty += $" Stride:{bv.ByteStride}ᴮʸᵗᵉˢ";
		}
		return empty;
	}

	public static string ToReportShort(this Accessor accessor)
	{
		return $"{accessor.Encoding.ToDebugString(accessor.Dimensions, accessor.Normalized)}[{accessor.Count}ᴵᵗᵉᵐˢ]";
	}

	public static string ToReportLong(this Accessor accessor)
	{
		string text = string.Empty;
		if (accessor.TryGetBufferView(out var bv))
		{
			text = (bv.IsVertexBuffer ? (text + "VertexBuffer") : ((!bv.IsIndexBuffer) ? (text + "BufferView") : (text + "IndexBuffer")));
			text += $"[{bv.LogicalIndex}ᴵᵈˣ] ⇨";
		}
		text += $" Accessor[{accessor.LogicalIndex}ᴵᵈˣ] Offset:{accessor.ByteOffset}ᴮʸᵗᵉˢ ⇨";
		text += $" {accessor.Encoding.ToDebugString(accessor.Dimensions, accessor.Normalized)}[{accessor.Count}ᴵᵗᵉᵐˢ]";
		if (accessor.IsSparse)
		{
			text += " SPARSE";
		}
		return text;
	}

	public static string ToReport(this MeshPrimitive prim, string txt)
	{
		List<int> list = prim.VertexAccessors.Values.Select((Accessor item) => item.Count).Distinct().ToList();
		int num = list.First();
		if (list.Count > 1)
		{
			List<string> values = (from item in prim.VertexAccessors.OrderBy((KeyValuePair<string, Accessor> item) => item.Key, MemoryAccessInfo.NameComparer)
				select GetAttributeShortName(item.Key) + "=" + item.Value.ToReportShort()).ToList();
			txt = txt + " Vrts: " + string.Join(" ", values) + " ⚠\ufe0fVertex Count mismatch⚠\ufe0f";
		}
		else
		{
			List<string> values2 = (from item in prim.VertexAccessors.OrderBy((KeyValuePair<string, Accessor> item) => item.Key, MemoryAccessInfo.NameComparer)
				select toShort(item.Key, item.Value)).ToList();
			txt += string.Format(" Vrts: ( {0} )[{1}]", string.Join(" ", values2), num);
		}
		IAccessorArray<uint> accessorArray = prim.IndexAccessor?.AsIndicesArray();
		int num2 = 0;
		switch (prim.DrawPrimitiveType)
		{
		case PrimitiveType.POINTS:
			num2 = num;
			break;
		case PrimitiveType.LINES:
		case PrimitiveType.LINE_LOOP:
		case PrimitiveType.LINE_STRIP:
			num2 = ((accessorArray != null) ? prim.DrawPrimitiveType.GetLinesIndices(accessorArray).Count() : prim.DrawPrimitiveType.GetLinesIndices(num).Count());
			break;
		case PrimitiveType.TRIANGLES:
		case PrimitiveType.TRIANGLE_STRIP:
		case PrimitiveType.TRIANGLE_FAN:
			num2 = ((accessorArray != null) ? prim.DrawPrimitiveType.GetTrianglesIndices(accessorArray).Count() : prim.DrawPrimitiveType.GetTrianglesIndices(num).Count());
			break;
		}
		CultureInfo currentCulture = CultureInfo.CurrentCulture;
		string arg = currentCulture.TextInfo.ToTitleCase(prim.DrawPrimitiveType.ToString().ToLower(currentCulture));
		txt += $" {arg}[{num2}]";
		if (prim.MorphTargetsCount > 0)
		{
			txt += $" MorphTargets[{prim.MorphTargetsCount}]";
		}
		if (prim.Material != null)
		{
			txt = ((!string.IsNullOrWhiteSpace(prim.Material.Name)) ? (txt + "Material \"" + prim.Material.Name + "\"") : (txt + $" Material[{prim.Material.LogicalIndex}]"));
		}
		return txt;
		static string toShort(string name, Accessor accessor)
		{
			name = GetAttributeShortName(name);
			string text = accessor.Encoding.ToDebugString(accessor.Dimensions, accessor.Normalized);
			return name + "." + text;
		}
	}
}
