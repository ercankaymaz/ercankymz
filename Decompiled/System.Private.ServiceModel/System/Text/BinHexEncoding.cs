using System.Globalization;
using System.ServiceModel;

namespace System.Text;

internal class BinHexEncoding : Encoding
{
	private static byte[] s_char2val = new byte[128]
	{
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 0, 1,
		2, 3, 4, 5, 6, 7, 8, 9, 255, 255,
		255, 255, 255, 255, 255, 10, 11, 12, 13, 14,
		15, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 10, 11, 12,
		13, 14, 15, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
		255, 255, 255, 255, 255, 255, 255, 255
	};

	private static string s_val2char = "0123456789ABCDEF";

	public override int GetMaxByteCount(int charCount)
	{
		if (charCount < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("charCount", System.SR.ValueMustBeNonNegative));
		}
		if (charCount % 2 != 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new FormatException(System.SR.Format(System.SR.XmlInvalidBinHexLength, charCount.ToString(NumberFormatInfo.CurrentInfo))));
		}
		return charCount / 2;
	}

	public override int GetByteCount(char[] chars, int index, int count)
	{
		return GetMaxByteCount(count);
	}

	public unsafe override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
	{
		if (chars == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("chars"));
		}
		if (charIndex < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("charIndex", System.SR.ValueMustBeNonNegative));
		}
		if (charIndex > chars.Length)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("charIndex", System.SR.Format(System.SR.OffsetExceedsBufferSize, chars.Length)));
		}
		if (charCount < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("charCount", System.SR.ValueMustBeNonNegative));
		}
		if (charCount > chars.Length - charIndex)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("charCount", System.SR.Format(System.SR.SizeExceedsRemainingBufferSpace, chars.Length - charIndex)));
		}
		if (bytes == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("bytes"));
		}
		if (byteIndex < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("byteIndex", System.SR.ValueMustBeNonNegative));
		}
		if (byteIndex > bytes.Length)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("byteIndex", System.SR.Format(System.SR.OffsetExceedsBufferSize, bytes.Length)));
		}
		int byteCount = GetByteCount(chars, charIndex, charCount);
		if (byteCount < 0 || byteCount > bytes.Length - byteIndex)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.XmlArrayTooSmall, "bytes"));
		}
		if (charCount > 0)
		{
			fixed (byte* ptr = s_char2val)
			{
				fixed (byte* ptr2 = &bytes[byteIndex])
				{
					fixed (char* ptr3 = &chars[charIndex])
					{
						char* ptr4 = ptr3;
						char* ptr5 = ptr3 + charCount;
						byte* ptr6 = ptr2;
						while (ptr4 < ptr5)
						{
							char c = *ptr4;
							char c2 = ptr4[1];
							if ((c | c2) >= 128)
							{
								throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new FormatException(System.SR.Format(System.SR.XmlInvalidBinHexSequence, new string(ptr4, 0, 2), charIndex + (int)(ptr4 - ptr3))));
							}
							byte b = ptr[(int)c];
							byte b2 = ptr[(int)c2];
							if ((b | b2) == 255)
							{
								throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new FormatException(System.SR.Format(System.SR.XmlInvalidBinHexSequence, new string(ptr4, 0, 2), charIndex + (int)(ptr4 - ptr3))));
							}
							*ptr6 = (byte)((b << 4) + b2);
							ptr4 += 2;
							ptr6++;
						}
					}
				}
			}
		}
		return byteCount;
	}

	public override int GetMaxCharCount(int byteCount)
	{
		if (byteCount < 0 || byteCount > 1073741823)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("byteCount", System.SR.Format(System.SR.ValueMustBeInRange, 0, 1073741823)));
		}
		return byteCount * 2;
	}

	public override int GetCharCount(byte[] bytes, int index, int count)
	{
		return GetMaxCharCount(count);
	}

	public unsafe override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
	{
		if (bytes == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("bytes"));
		}
		if (byteIndex < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("byteIndex", System.SR.ValueMustBeNonNegative));
		}
		if (byteIndex > bytes.Length)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("byteIndex", System.SR.Format(System.SR.OffsetExceedsBufferSize, bytes.Length)));
		}
		if (byteCount < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("byteCount", System.SR.ValueMustBeNonNegative));
		}
		if (byteCount > bytes.Length - byteIndex)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("byteCount", System.SR.Format(System.SR.SizeExceedsRemainingBufferSpace, bytes.Length - byteIndex)));
		}
		int charCount = GetCharCount(bytes, byteIndex, byteCount);
		if (chars == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("chars"));
		}
		if (charIndex < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("charIndex", System.SR.ValueMustBeNonNegative));
		}
		if (charIndex > chars.Length)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("charIndex", System.SR.Format(System.SR.OffsetExceedsBufferSize, chars.Length)));
		}
		if (charCount < 0 || charCount > chars.Length - charIndex)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.XmlArrayTooSmall, "chars"));
		}
		if (byteCount > 0)
		{
			fixed (char* ptr = s_val2char)
			{
				fixed (byte* ptr2 = &bytes[byteIndex])
				{
					fixed (char* ptr3 = &chars[charIndex])
					{
						char* ptr4 = ptr3;
						byte* ptr5 = ptr2;
						byte* ptr6 = ptr2 + byteCount;
						while (ptr5 < ptr6)
						{
							*ptr4 = ptr[*ptr5 >> 4];
							ptr4[1] = ptr[*ptr5 & 0xF];
							ptr5++;
							ptr4 += 2;
						}
					}
				}
			}
		}
		return charCount;
	}
}
