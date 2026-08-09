using System.IO;
using System.Runtime;
using System.Text;

namespace System.ServiceModel.Channels;

internal abstract class StringDecoder
{
	private enum State
	{
		ReadingSize,
		ReadingBytes,
		Done
	}

	private int _encodedSize;

	private byte[] _encodedBytes;

	private int _bytesNeeded;

	private string _value;

	private State _currentState;

	private IntDecoder _sizeDecoder;

	private int _sizeQuota;

	private int _valueLengthInBytes;

	public bool IsValueDecoded => _currentState == State.Done;

	public string Value
	{
		get
		{
			if (_currentState != State.Done)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.FramingValueNotAvailable));
			}
			return _value;
		}
	}

	public StringDecoder(int sizeQuota)
	{
		_sizeQuota = sizeQuota;
		_sizeDecoder = default(IntDecoder);
		_currentState = State.ReadingSize;
		Reset();
	}

	public int Decode(byte[] buffer, int offset, int size)
	{
		DecoderHelper.ValidateSize(size);
		int num;
		switch (_currentState)
		{
		case State.ReadingSize:
			num = _sizeDecoder.Decode(buffer, offset, size);
			if (_sizeDecoder.IsValueDecoded)
			{
				_encodedSize = _sizeDecoder.Value;
				if (_encodedSize > _sizeQuota)
				{
					Exception exception = OnSizeQuotaExceeded(_encodedSize);
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(exception);
				}
				if (_encodedBytes == null || _encodedBytes.Length < _encodedSize)
				{
					_encodedBytes = Fx.AllocateByteArray(_encodedSize);
					_value = null;
				}
				_currentState = State.ReadingBytes;
				_bytesNeeded = _encodedSize;
			}
			break;
		case State.ReadingBytes:
			if (_value != null && _valueLengthInBytes == _encodedSize && _bytesNeeded == _encodedSize && size >= _encodedSize && CompareBuffers(_encodedBytes, buffer, offset))
			{
				num = _bytesNeeded;
				OnComplete(_value);
				break;
			}
			num = _bytesNeeded;
			if (size < _bytesNeeded)
			{
				num = size;
			}
			Buffer.BlockCopy(buffer, offset, _encodedBytes, _encodedSize - _bytesNeeded, num);
			_bytesNeeded -= num;
			if (_bytesNeeded == 0)
			{
				_value = Encoding.UTF8.GetString(_encodedBytes, 0, _encodedSize);
				_valueLengthInBytes = _encodedSize;
				OnComplete(_value);
			}
			break;
		default:
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidDataException(System.SR.InvalidDecoderStateMachine));
		}
		return num;
	}

	protected virtual void OnComplete(string value)
	{
		_currentState = State.Done;
	}

	private static bool CompareBuffers(byte[] buffer1, byte[] buffer2, int offset)
	{
		for (int i = 0; i < buffer1.Length; i++)
		{
			if (buffer1[i] != buffer2[i + offset])
			{
				return false;
			}
		}
		return true;
	}

	protected abstract Exception OnSizeQuotaExceeded(int size);

	public void Reset()
	{
		_currentState = State.ReadingSize;
		_sizeDecoder.Reset();
	}
}
