using CSMath;

namespace ACadSharp;

public static class GroupCodeValue
{
	public static bool IsValid(this DxfCode code, object value)
	{
		return TransformValue((int)code).IsValid(value);
	}

	public static bool IsValid(this GroupCodeValueType groupCode, object value)
	{
		switch (groupCode)
		{
		case GroupCodeValueType.String:
			if (!(value is string))
			{
				break;
			}
			goto IL_0129;
		case GroupCodeValueType.ExtendedDataString:
			if (!(value is string))
			{
				break;
			}
			goto IL_0129;
		case GroupCodeValueType.Comment:
			if (!(value is string))
			{
				break;
			}
			goto IL_0129;
		case GroupCodeValueType.Point3D:
			if (!(value is IVector))
			{
				break;
			}
			goto IL_0129;
		case GroupCodeValueType.Double:
			if (!(value is double))
			{
				break;
			}
			goto IL_0129;
		case GroupCodeValueType.ExtendedDataDouble:
			if (!(value is double))
			{
				break;
			}
			goto IL_0129;
		case GroupCodeValueType.Byte:
			if (!(value is byte))
			{
				break;
			}
			goto IL_0129;
		case GroupCodeValueType.Int16:
			if (!(value is short))
			{
				break;
			}
			goto IL_0129;
		case GroupCodeValueType.ExtendedDataInt16:
			if (!(value is short))
			{
				break;
			}
			goto IL_0129;
		case GroupCodeValueType.Int32:
			if (!(value is int))
			{
				break;
			}
			goto IL_0129;
		case GroupCodeValueType.ExtendedDataInt32:
			if (!(value is int))
			{
				break;
			}
			goto IL_0129;
		case GroupCodeValueType.Int64:
			if (!(value is long))
			{
				break;
			}
			goto IL_0129;
		case GroupCodeValueType.Handle:
			if (!(value is ulong))
			{
				break;
			}
			goto IL_0129;
		case GroupCodeValueType.ObjectId:
			if (!(value is ulong))
			{
				break;
			}
			goto IL_0129;
		case GroupCodeValueType.ExtendedDataHandle:
			if (!(value is ulong))
			{
				break;
			}
			goto IL_0129;
		case GroupCodeValueType.Bool:
			if (!(value is bool))
			{
				break;
			}
			goto IL_0129;
		case GroupCodeValueType.Chunk:
			if (!(value is byte[]))
			{
				break;
			}
			goto IL_0129;
		case GroupCodeValueType.ExtendedDataChunk:
			{
				if (!(value is byte[]))
				{
					break;
				}
				goto IL_0129;
			}
			IL_0129:
			return true;
		}
		return false;
	}

	public static GroupCodeValueType TransformValue(int code)
	{
		if (code >= 0 && code <= 4)
		{
			return GroupCodeValueType.String;
		}
		switch (code)
		{
		case 5:
			return GroupCodeValueType.Handle;
		case 6:
		case 7:
		case 8:
		case 9:
			return GroupCodeValueType.String;
		default:
			if (code >= 10 && code <= 39)
			{
				return GroupCodeValueType.Point3D;
			}
			if (code >= 40 && code <= 59)
			{
				return GroupCodeValueType.Double;
			}
			if (code >= 60 && code <= 79)
			{
				return GroupCodeValueType.Int16;
			}
			if (code >= 90 && code <= 99)
			{
				return GroupCodeValueType.Int32;
			}
			switch (code)
			{
			case 100:
				return GroupCodeValueType.String;
			case 101:
				return GroupCodeValueType.String;
			case 102:
				return GroupCodeValueType.String;
			case 105:
				return GroupCodeValueType.Handle;
			case 110:
			case 111:
			case 112:
			case 113:
			case 114:
			case 115:
			case 116:
			case 117:
			case 118:
			case 119:
				return GroupCodeValueType.Double;
			default:
				if (code >= 120 && code <= 129)
				{
					return GroupCodeValueType.Double;
				}
				if (code >= 130 && code <= 139)
				{
					return GroupCodeValueType.Double;
				}
				if (code >= 140 && code <= 149)
				{
					return GroupCodeValueType.Double;
				}
				if (code >= 160 && code <= 169)
				{
					return GroupCodeValueType.Int64;
				}
				if (code >= 170 && code <= 179)
				{
					return GroupCodeValueType.Int16;
				}
				if (code >= 210 && code <= 239)
				{
					return GroupCodeValueType.Double;
				}
				if (code >= 270 && code <= 279)
				{
					return GroupCodeValueType.Int16;
				}
				if (code >= 280 && code <= 289)
				{
					return GroupCodeValueType.Byte;
				}
				if (code >= 290 && code <= 299)
				{
					return GroupCodeValueType.Bool;
				}
				if (code >= 300 && code <= 309)
				{
					return GroupCodeValueType.String;
				}
				if (code >= 310 && code <= 319)
				{
					return GroupCodeValueType.Chunk;
				}
				if (code >= 320 && code <= 329)
				{
					return GroupCodeValueType.Handle;
				}
				if (code >= 330 && code <= 369)
				{
					return GroupCodeValueType.ObjectId;
				}
				if (code >= 370 && code <= 379)
				{
					return GroupCodeValueType.Int16;
				}
				if (code >= 380 && code <= 389)
				{
					return GroupCodeValueType.Int16;
				}
				if (code >= 390 && code <= 399)
				{
					return GroupCodeValueType.ObjectId;
				}
				if (code >= 400 && code <= 409)
				{
					return GroupCodeValueType.Int16;
				}
				if (code >= 410 && code <= 419)
				{
					return GroupCodeValueType.String;
				}
				if (code >= 420 && code <= 429)
				{
					return GroupCodeValueType.Int32;
				}
				if (code >= 430 && code <= 439)
				{
					return GroupCodeValueType.String;
				}
				if (code >= 440 && code <= 449)
				{
					return GroupCodeValueType.Int32;
				}
				if (code >= 450 && code <= 459)
				{
					return GroupCodeValueType.Int32;
				}
				if (code >= 460 && code <= 469)
				{
					return GroupCodeValueType.Double;
				}
				if (code >= 470 && code <= 479)
				{
					return GroupCodeValueType.String;
				}
				if (code >= 480 && code <= 481)
				{
					return GroupCodeValueType.Handle;
				}
				switch (code)
				{
				case 999:
					return GroupCodeValueType.Comment;
				case 1000:
				case 1001:
				case 1002:
				case 1003:
					return GroupCodeValueType.ExtendedDataString;
				default:
					switch (code)
					{
					case 1004:
						return GroupCodeValueType.ExtendedDataChunk;
					case 1005:
					case 1006:
					case 1007:
					case 1008:
					case 1009:
						return GroupCodeValueType.ExtendedDataHandle;
					default:
						if (code >= 1010 && code <= 1059)
						{
							return GroupCodeValueType.ExtendedDataDouble;
						}
						if (code >= 1060 && code <= 1070)
						{
							return GroupCodeValueType.ExtendedDataInt16;
						}
						if (code == 1071)
						{
							return GroupCodeValueType.ExtendedDataInt32;
						}
						return GroupCodeValueType.None;
					}
				}
			}
		}
	}
}
