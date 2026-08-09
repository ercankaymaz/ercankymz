using System.CodeDom.Compiler;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public static class Attributes
{
	public const uint NodeId = 1u;

	public const uint NodeClass = 2u;

	public const uint BrowseName = 3u;

	public const uint DisplayName = 4u;

	public const uint Description = 5u;

	public const uint WriteMask = 6u;

	public const uint UserWriteMask = 7u;

	public const uint IsAbstract = 8u;

	public const uint Symmetric = 9u;

	public const uint InverseName = 10u;

	public const uint ContainsNoLoops = 11u;

	public const uint EventNotifier = 12u;

	public const uint Value = 13u;

	public const uint DataType = 14u;

	public const uint ValueRank = 15u;

	public const uint ArrayDimensions = 16u;

	public const uint AccessLevel = 17u;

	public const uint UserAccessLevel = 18u;

	public const uint MinimumSamplingInterval = 19u;

	public const uint Historizing = 20u;

	public const uint Executable = 21u;

	public const uint UserExecutable = 22u;

	public const uint DataTypeDefinition = 23u;

	public const uint RolePermissions = 24u;

	public const uint UserRolePermissions = 25u;

	public const uint AccessRestrictions = 26u;

	public const uint AccessLevelEx = 27u;

	public static bool IsValid(uint attributeId)
	{
		if (attributeId >= 1)
		{
			return attributeId <= 27;
		}
		return false;
	}

	public static string GetBrowseName(uint identifier)
	{
		FieldInfo[] fields = typeof(Attributes).GetFields(BindingFlags.Static | BindingFlags.Public);
		foreach (FieldInfo fieldInfo in fields)
		{
			if (identifier == (uint)fieldInfo.GetValue(typeof(Attributes)))
			{
				return fieldInfo.Name;
			}
		}
		return string.Empty;
	}

	public static string[] GetBrowseNames()
	{
		FieldInfo[] fields = typeof(Attributes).GetFields(BindingFlags.Static | BindingFlags.Public);
		int num = 0;
		string[] array = new string[fields.Length];
		FieldInfo[] array2 = fields;
		foreach (FieldInfo fieldInfo in array2)
		{
			array[num++] = fieldInfo.Name;
		}
		return array;
	}

	public static uint GetIdentifier(string browseName)
	{
		FieldInfo[] fields = typeof(Attributes).GetFields(BindingFlags.Static | BindingFlags.Public);
		foreach (FieldInfo fieldInfo in fields)
		{
			if (fieldInfo.Name == browseName)
			{
				return (uint)fieldInfo.GetValue(typeof(Attributes));
			}
		}
		return 0u;
	}

	public static uint[] GetIdentifiers()
	{
		FieldInfo[] fields = typeof(Attributes).GetFields(BindingFlags.Static | BindingFlags.Public);
		int num = 0;
		uint[] array = new uint[fields.Length];
		FieldInfo[] array2 = fields;
		foreach (FieldInfo fieldInfo in array2)
		{
			array[num++] = (uint)fieldInfo.GetValue(typeof(Attributes));
		}
		return array;
	}

	public static UInt32Collection GetIdentifiers(NodeClass nodeClass)
	{
		FieldInfo[] fields = typeof(Attributes).GetFields(BindingFlags.Static | BindingFlags.Public);
		UInt32Collection uInt32Collection = new UInt32Collection(fields.Length);
		FieldInfo[] array = fields;
		for (int i = 0; i < array.Length; i++)
		{
			uint num = (uint)array[i].GetValue(typeof(Attributes));
			if (IsValid(nodeClass, num))
			{
				uInt32Collection.Add(num);
			}
		}
		return uInt32Collection;
	}

	public static BuiltInType GetBuiltInType(uint attributeId)
	{
		return attributeId switch
		{
			13u => BuiltInType.Variant, 
			4u => BuiltInType.LocalizedText, 
			5u => BuiltInType.LocalizedText, 
			6u => BuiltInType.UInt32, 
			7u => BuiltInType.UInt32, 
			1u => BuiltInType.NodeId, 
			2u => BuiltInType.Int32, 
			3u => BuiltInType.QualifiedName, 
			8u => BuiltInType.Boolean, 
			9u => BuiltInType.Boolean, 
			10u => BuiltInType.LocalizedText, 
			11u => BuiltInType.Boolean, 
			12u => BuiltInType.Byte, 
			14u => BuiltInType.NodeId, 
			15u => BuiltInType.Int32, 
			17u => BuiltInType.Byte, 
			18u => BuiltInType.Byte, 
			19u => BuiltInType.Double, 
			20u => BuiltInType.Boolean, 
			21u => BuiltInType.Boolean, 
			22u => BuiltInType.Boolean, 
			16u => BuiltInType.UInt32, 
			23u => BuiltInType.ExtensionObject, 
			24u => BuiltInType.Variant, 
			25u => BuiltInType.Variant, 
			26u => BuiltInType.UInt16, 
			27u => BuiltInType.UInt32, 
			_ => BuiltInType.Null, 
		};
	}

	public static NodeId GetDataTypeId(uint attributeId)
	{
		return attributeId switch
		{
			13u => 24u, 
			4u => 21u, 
			5u => 21u, 
			6u => 7u, 
			7u => 7u, 
			1u => 17u, 
			2u => 29u, 
			3u => 20u, 
			8u => 1u, 
			9u => 1u, 
			10u => 21u, 
			11u => 1u, 
			12u => 3u, 
			14u => 17u, 
			15u => 6u, 
			17u => 3u, 
			18u => 3u, 
			19u => 290u, 
			20u => 1u, 
			21u => 1u, 
			22u => 1u, 
			16u => 7u, 
			23u => 22u, 
			24u => 96u, 
			25u => 96u, 
			26u => 5u, 
			27u => 7u, 
			_ => null, 
		};
	}

	public static bool IsWriteable(uint attributeId, uint writeMask)
	{
		return attributeId switch
		{
			13u => (writeMask & 0x200000) != 0, 
			4u => (writeMask & 0x40) != 0, 
			5u => (writeMask & 0x20) != 0, 
			6u => (writeMask & 0x100000) != 0, 
			7u => (writeMask & 0x40000) != 0, 
			1u => (writeMask & 0x4000) != 0, 
			2u => (writeMask & 0x2000) != 0, 
			3u => (writeMask & 4) != 0, 
			8u => (writeMask & 0x800) != 0, 
			9u => (writeMask & 0x8000) != 0, 
			10u => (writeMask & 0x400) != 0, 
			11u => (writeMask & 8) != 0, 
			12u => (writeMask & 0x80) != 0, 
			14u => (writeMask & 0x10) != 0, 
			15u => (writeMask & 0x80000) != 0, 
			17u => (writeMask & 1) != 0, 
			18u => (writeMask & 0x10000) != 0, 
			19u => (writeMask & 0x1000) != 0, 
			20u => (writeMask & 0x200) != 0, 
			21u => (writeMask & 0x100) != 0, 
			22u => (writeMask & 0x20000) != 0, 
			16u => (writeMask & 2) != 0, 
			23u => (writeMask & 0x400000) != 0, 
			24u => (writeMask & 0x800000) != 0, 
			26u => (writeMask & 0x1000000) != 0, 
			27u => (writeMask & 0x2000000) != 0, 
			_ => false, 
		};
	}

	public static uint SetWriteable(uint attributeId, uint writeMask)
	{
		return attributeId switch
		{
			13u => writeMask | 0x200000, 
			4u => writeMask | 0x40, 
			5u => writeMask | 0x20, 
			6u => writeMask | 0x100000, 
			7u => writeMask | 0x40000, 
			1u => writeMask | 0x4000, 
			2u => writeMask | 0x2000, 
			3u => writeMask | 4, 
			8u => writeMask | 0x800, 
			9u => writeMask | 0x8000, 
			10u => writeMask | 0x400, 
			11u => writeMask | 8, 
			12u => writeMask | 0x80, 
			14u => writeMask | 0x10, 
			15u => writeMask | 0x80000, 
			17u => writeMask | 1, 
			18u => writeMask | 0x10000, 
			19u => writeMask | 0x1000, 
			20u => writeMask | 0x200, 
			21u => writeMask | 0x100, 
			22u => writeMask | 0x20000, 
			16u => writeMask | 2, 
			23u => writeMask | 0x400000, 
			24u => writeMask | 0x800000, 
			26u => writeMask | 0x1000000, 
			27u => writeMask | 0x2000000, 
			_ => writeMask, 
		};
	}

	public static int GetValueRank(uint attributeId)
	{
		return attributeId switch
		{
			13u => -2, 
			16u => 1, 
			_ => -1, 
		};
	}

	public static bool IsValid(NodeClass nodeClass, uint attributeId)
	{
		switch (attributeId)
		{
		case 1u:
		case 2u:
		case 3u:
		case 4u:
		case 5u:
		case 6u:
		case 7u:
		case 24u:
		case 25u:
		case 26u:
			return true;
		case 13u:
		case 14u:
		case 15u:
		case 16u:
			return (nodeClass & (NodeClass)18) != 0;
		case 8u:
			return (nodeClass & (NodeClass)120) != 0;
		case 9u:
		case 10u:
			return (nodeClass & Opc.Ua.NodeClass.ReferenceType) != 0;
		case 11u:
			return (nodeClass & Opc.Ua.NodeClass.View) != 0;
		case 12u:
			return (nodeClass & (NodeClass)129) != 0;
		case 17u:
		case 18u:
		case 19u:
		case 20u:
		case 27u:
			return (nodeClass & Opc.Ua.NodeClass.Variable) != 0;
		case 21u:
		case 22u:
			return (nodeClass & Opc.Ua.NodeClass.Method) != 0;
		case 23u:
			return (nodeClass & Opc.Ua.NodeClass.DataType) != 0;
		default:
			return false;
		}
	}

	public static AttributeWriteMask GetMask(uint attributeId)
	{
		return attributeId switch
		{
			1u => AttributeWriteMask.NodeId, 
			2u => AttributeWriteMask.NodeClass, 
			3u => AttributeWriteMask.BrowseName, 
			4u => AttributeWriteMask.DisplayName, 
			5u => AttributeWriteMask.Description, 
			6u => AttributeWriteMask.WriteMask, 
			7u => AttributeWriteMask.UserWriteMask, 
			14u => AttributeWriteMask.DataType, 
			15u => AttributeWriteMask.ValueRank, 
			16u => AttributeWriteMask.ArrayDimensions, 
			8u => AttributeWriteMask.IsAbstract, 
			9u => AttributeWriteMask.Symmetric, 
			10u => AttributeWriteMask.InverseName, 
			11u => AttributeWriteMask.ContainsNoLoops, 
			12u => AttributeWriteMask.EventNotifier, 
			17u => AttributeWriteMask.AccessLevel, 
			18u => AttributeWriteMask.UserAccessLevel, 
			19u => AttributeWriteMask.MinimumSamplingInterval, 
			20u => AttributeWriteMask.Historizing, 
			21u => AttributeWriteMask.Executable, 
			22u => AttributeWriteMask.UserExecutable, 
			23u => AttributeWriteMask.DataTypeDefinition, 
			24u => AttributeWriteMask.RolePermissions, 
			26u => AttributeWriteMask.AccessRestrictions, 
			27u => AttributeWriteMask.AccessLevelEx, 
			_ => AttributeWriteMask.None, 
		};
	}
}
