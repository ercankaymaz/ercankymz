namespace ACadSharp.IO.DWG;

internal static class DwgLZ77AC21Decompressor
{
	private delegate void copyDelegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex);

	private static uint m_sourceOffset = 0u;

	private static uint m_length = 0u;

	private static uint m_sourceIndex;

	private static uint m_opCode = 0u;

	private static readonly copyDelegate[] m_copyMethods = new copyDelegate[32]
	{
		null,
		delegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
		{
			copy1b(src, srcIndex, dst, dstIndex);
		},
		delegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
		{
			copy2b(src, srcIndex, dst, dstIndex);
		},
		delegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
		{
			copy3b(src, srcIndex, dst, dstIndex);
		},
		delegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
		{
			copy4b(src, srcIndex, dst, dstIndex);
		},
		delegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
		{
			copy1b(src, srcIndex + 4, dst, dstIndex);
			copy4b(src, srcIndex, dst, dstIndex + 1);
		},
		delegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
		{
			copy1b(src, srcIndex + 5, dst, dstIndex);
			copy4b(src, srcIndex + 1, dst, dstIndex + 1);
			copy1b(src, srcIndex, dst, dstIndex + 5);
		},
		delegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
		{
			copy2b(src, srcIndex + 5, dst, dstIndex);
			copy4b(src, srcIndex + 1, dst, dstIndex + 2);
			copy1b(src, srcIndex, dst, dstIndex + 6);
		},
		copy8b,
		delegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
		{
			copy1b(src, srcIndex + 8, dst, dstIndex);
			copy8b(src, srcIndex, dst, dstIndex + 1);
		},
		delegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
		{
			copy1b(src, srcIndex + 9, dst, dstIndex);
			copy8b(src, srcIndex + 1, dst, dstIndex + 1);
			copy1b(src, srcIndex, dst, dstIndex + 9);
		},
		delegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
		{
			copy2b(src, srcIndex + 9, dst, dstIndex);
			copy8b(src, srcIndex + 1, dst, dstIndex + 2);
			copy1b(src, srcIndex, dst, dstIndex + 10);
		},
		delegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
		{
			copy4b(src, srcIndex + 8, dst, dstIndex);
			copy8b(src, srcIndex, dst, dstIndex + 4);
		},
		delegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
		{
			copy1b(src, srcIndex + 12, dst, dstIndex);
			copy4b(src, srcIndex + 8, dst, dstIndex + 1);
			copy8b(src, srcIndex, dst, dstIndex + 5);
		},
		delegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
		{
			copy1b(src, srcIndex + 13, dst, dstIndex);
			copy4b(src, srcIndex + 9, dst, dstIndex + 1);
			copy8b(src, srcIndex + 1, dst, dstIndex + 5);
			copy1b(src, srcIndex, dst, dstIndex + 13);
		},
		delegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
		{
			copy2b(src, srcIndex + 13, dst, dstIndex);
			copy4b(src, srcIndex + 9, dst, dstIndex + 2);
			copy8b(src, srcIndex + 1, dst, dstIndex + 6);
			copy1b(src, srcIndex, dst, dstIndex + 14);
		},
		copy16b,
		delegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
		{
			copy8b(src, srcIndex + 9, dst, dstIndex);
			copy1b(src, srcIndex + 8, dst, dstIndex + 8);
			copy8b(src, srcIndex, dst, dstIndex + 9);
		},
		delegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
		{
			copy1b(src, srcIndex + 17, dst, dstIndex);
			copy16b(src, srcIndex + 1, dst, dstIndex + 1);
			copy1b(src, srcIndex, dst, dstIndex + 17);
		},
		delegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
		{
			copy3b(src, srcIndex + 16, dst, dstIndex);
			copy16b(src, srcIndex, dst, dstIndex + 3);
		},
		delegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
		{
			copy4b(src, srcIndex + 16, dst, dstIndex);
			copy8b(src, srcIndex + 8, dst, dstIndex + 4);
			copy8b(src, srcIndex, dst, dstIndex + 12);
		},
		delegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
		{
			copy1b(src, srcIndex + 20, dst, dstIndex);
			copy4b(src, srcIndex + 16, dst, dstIndex + 1);
			copy8b(src, srcIndex + 8, dst, dstIndex + 5);
			copy8b(src, srcIndex, dst, dstIndex + 13);
		},
		delegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
		{
			copy2b(src, srcIndex + 20, dst, dstIndex);
			copy4b(src, srcIndex + 16, dst, dstIndex + 2);
			copy8b(src, srcIndex + 8, dst, dstIndex + 6);
			copy8b(src, srcIndex, dst, dstIndex + 14);
		},
		delegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
		{
			copy3b(src, srcIndex + 20, dst, dstIndex);
			copy4b(src, srcIndex + 16, dst, dstIndex + 3);
			copy8b(src, srcIndex + 8, dst, dstIndex + 7);
			copy8b(src, srcIndex, dst, dstIndex + 15);
		},
		delegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
		{
			copy8b(src, srcIndex + 16, dst, dstIndex);
			copy16b(src, srcIndex, dst, dstIndex + 8);
		},
		delegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
		{
			copy8b(src, srcIndex + 17, dst, dstIndex);
			copy1b(src, srcIndex + 16, dst, dstIndex + 8);
			copy16b(src, srcIndex, dst, dstIndex + 9);
		},
		delegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
		{
			copy1b(src, srcIndex + 25, dst, dstIndex);
			copy8b(src, srcIndex + 17, dst, dstIndex + 1);
			copy1b(src, srcIndex + 16, dst, dstIndex + 9);
			copy16b(src, srcIndex, dst, dstIndex + 10);
		},
		delegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
		{
			copy2b(src, srcIndex + 25, dst, dstIndex);
			copy8b(src, srcIndex + 17, dst, dstIndex + 2);
			copy1b(src, srcIndex + 16, dst, dstIndex + 10);
			copy16b(src, srcIndex, dst, dstIndex + 11);
		},
		delegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
		{
			copy4b(src, srcIndex + 24, dst, dstIndex);
			copy8b(src, srcIndex + 16, dst, dstIndex + 4);
			copy8b(src, srcIndex + 8, dst, dstIndex + 12);
			copy8b(src, srcIndex, dst, dstIndex + 20);
		},
		delegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
		{
			copy1b(src, srcIndex + 28, dst, dstIndex);
			copy4b(src, srcIndex + 24, dst, dstIndex + 1);
			copy8b(src, srcIndex + 16, dst, dstIndex + 5);
			copy8b(src, srcIndex + 8, dst, dstIndex + 13);
			copy8b(src, srcIndex, dst, dstIndex + 21);
		},
		delegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
		{
			copy2b(src, srcIndex + 28, dst, dstIndex);
			copy4b(src, srcIndex + 24, dst, dstIndex + 2);
			copy8b(src, srcIndex + 16, dst, dstIndex + 6);
			copy8b(src, srcIndex + 8, dst, dstIndex + 14);
			copy8b(src, srcIndex, dst, dstIndex + 22);
		},
		delegate(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
		{
			copy1b(src, srcIndex + 30, dst, dstIndex);
			copy4b(src, srcIndex + 26, dst, dstIndex + 1);
			copy8b(src, srcIndex + 18, dst, dstIndex + 5);
			copy8b(src, srcIndex + 10, dst, dstIndex + 13);
			copy8b(src, srcIndex + 2, dst, dstIndex + 21);
			copy2b(src, srcIndex, dst, dstIndex + 29);
		}
	};

	public static void Decompress(byte[] source, uint initialOffset, uint length, byte[] buffer)
	{
		m_sourceOffset = 0u;
		m_length = 0u;
		m_sourceIndex = initialOffset;
		m_opCode = source[m_sourceIndex];
		uint index = 0u;
		uint num = m_sourceIndex + length;
		m_sourceIndex++;
		if (m_sourceIndex >= num)
		{
			return;
		}
		if ((m_opCode & 0xF0) == 32)
		{
			m_sourceIndex += 3u;
			m_length = source[m_sourceIndex - 1];
			m_length &= 7u;
		}
		while (m_sourceIndex < num)
		{
			nextIndex(source, buffer, ref index);
			if (m_sourceIndex < num)
			{
				index = copyDecompressedChunks(source, num, buffer, index);
				continue;
			}
			break;
		}
	}

	private static void nextIndex(byte[] source, byte[] dest, ref uint index)
	{
		if (m_length == 0)
		{
			readLiteralLength(source);
		}
		copy(source, m_sourceIndex, dest, index, m_length);
		m_sourceIndex += m_length;
		index += m_length;
	}

	private static uint copyDecompressedChunks(byte[] src, uint endIndex, byte[] dst, uint destIndex)
	{
		m_length = 0u;
		m_opCode = src[m_sourceIndex];
		m_sourceIndex++;
		readInstructions(src);
		while (true)
		{
			copyBytes(dst, destIndex, m_length, m_sourceOffset);
			destIndex += m_length;
			m_length = m_opCode & 7;
			if (m_length != 0 || m_sourceIndex >= endIndex)
			{
				break;
			}
			m_opCode = src[m_sourceIndex];
			m_sourceIndex++;
			if (m_opCode >> 4 == 0)
			{
				break;
			}
			if (m_opCode >> 4 == 15)
			{
				m_opCode &= 15u;
			}
			readInstructions(src);
		}
		return destIndex;
	}

	private static void readInstructions(byte[] buffer)
	{
		switch (m_opCode >> 4)
		{
		case 0u:
			m_length = (m_opCode & 0xF) + 19;
			m_sourceOffset = buffer[m_sourceIndex];
			m_sourceIndex++;
			m_opCode = buffer[m_sourceIndex];
			m_sourceIndex++;
			m_length = ((m_opCode >> 3) & 0x10) + m_length;
			m_sourceOffset = ((m_opCode & 0x78) << 5) + 1 + m_sourceOffset;
			break;
		case 1u:
			m_length = (m_opCode & 0xF) + 3;
			m_sourceOffset = buffer[m_sourceIndex];
			m_sourceIndex++;
			m_opCode = buffer[m_sourceIndex];
			m_sourceIndex++;
			m_sourceOffset = ((m_opCode & 0xF8) << 5) + 1 + m_sourceOffset;
			break;
		case 2u:
			m_sourceOffset = buffer[m_sourceIndex];
			m_sourceIndex++;
			m_sourceOffset = (uint)((buffer[m_sourceIndex] << 8) & 0xFF00) | m_sourceOffset;
			m_sourceIndex++;
			m_length = m_opCode & 7;
			if ((m_opCode & 8) == 0)
			{
				m_opCode = buffer[m_sourceIndex];
				m_sourceIndex++;
				m_length = (m_opCode & 0xF8) + m_length;
				break;
			}
			m_sourceOffset++;
			m_length = (uint)((buffer[m_sourceIndex] << 3) + m_length);
			m_sourceIndex++;
			m_opCode = buffer[m_sourceIndex];
			m_sourceIndex++;
			m_length = ((m_opCode & 0xF8) << 8) + m_length + 256;
			break;
		default:
			m_length = m_opCode >> 4;
			m_sourceOffset = m_opCode & 0xF;
			m_opCode = buffer[m_sourceIndex];
			m_sourceIndex++;
			m_sourceOffset = ((m_opCode & 0xF8) << 1) + m_sourceOffset + 1;
			break;
		}
	}

	private static void readLiteralLength(byte[] buffer)
	{
		m_length = m_opCode + 8;
		if (m_length != 23)
		{
			return;
		}
		uint num = buffer[m_sourceIndex];
		m_sourceIndex++;
		m_length += num;
		if (num == 255)
		{
			do
			{
				num = buffer[m_sourceIndex];
				m_sourceIndex++;
				num |= (uint)(buffer[m_sourceIndex] << 8);
				m_sourceIndex++;
				m_length += num;
			}
			while (num == 65535);
		}
	}

	private static void copyBytes(byte[] dst, uint dstIndex, uint length, uint srcOffset)
	{
		uint num = dstIndex - srcOffset;
		uint num2 = num + length;
		while (num < num2)
		{
			dst[dstIndex++] = dst[num++];
		}
	}

	private static void copy(byte[] src, uint srcIndex, byte[] dst, uint dstIndex, uint length)
	{
		while (true)
		{
			switch (length)
			{
			case 0u:
				return;
			case 1u:
			case 2u:
			case 3u:
			case 4u:
			case 5u:
			case 6u:
			case 7u:
			case 8u:
			case 9u:
			case 10u:
			case 11u:
			case 12u:
			case 13u:
			case 14u:
			case 15u:
			case 16u:
			case 17u:
			case 18u:
			case 19u:
			case 20u:
			case 21u:
			case 22u:
			case 23u:
			case 24u:
			case 25u:
			case 26u:
			case 27u:
			case 28u:
			case 29u:
			case 30u:
			case 31u:
				m_copyMethods[length](src, srcIndex, dst, dstIndex);
				return;
			}
			copy4b(src, srcIndex + 24, dst, dstIndex);
			copy4b(src, srcIndex + 28, dst, dstIndex + 4);
			copy4b(src, srcIndex + 16, dst, dstIndex + 8);
			copy4b(src, srcIndex + 20, dst, dstIndex + 12);
			copy4b(src, srcIndex + 8, dst, dstIndex + 16);
			copy4b(src, srcIndex + 12, dst, dstIndex + 20);
			copy4b(src, srcIndex, dst, dstIndex + 24);
			copy4b(src, srcIndex + 4, dst, dstIndex + 28);
			srcIndex += 32;
			dstIndex += 32;
			length -= 32;
		}
	}

	private static void copy1b(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
	{
		dst[dstIndex] = src[srcIndex];
	}

	private static void copy2b(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
	{
		dst[dstIndex] = src[srcIndex + 1];
		dst[dstIndex + 1] = src[srcIndex];
	}

	private static void copy3b(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
	{
		dst[dstIndex] = src[srcIndex + 2];
		dst[dstIndex + 1] = src[srcIndex + 1];
		dst[dstIndex + 2] = src[srcIndex];
	}

	private static void copy4b(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
	{
		dst[dstIndex] = src[srcIndex];
		dst[dstIndex + 1] = src[srcIndex + 1];
		dst[dstIndex + 2] = src[srcIndex + 2];
		dst[dstIndex + 3] = src[srcIndex + 3];
	}

	private static void copy8b(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
	{
		copy4b(src, srcIndex, dst, dstIndex);
		copy4b(src, srcIndex + 4, dst, dstIndex + 4);
	}

	private static void copy16b(byte[] src, uint srcIndex, byte[] dst, uint dstIndex)
	{
		copy8b(src, srcIndex + 8, dst, dstIndex);
		copy8b(src, srcIndex, dst, dstIndex + 8);
	}
}
