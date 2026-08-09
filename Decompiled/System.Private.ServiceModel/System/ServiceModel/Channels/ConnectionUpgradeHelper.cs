using System.IO;
using System.Runtime;
using System.ServiceModel.Channels.ConnectionHelpers;
using System.ServiceModel.Security;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal class ConnectionUpgradeHelper
{
	public static async Task DecodeFramingFaultAsync(ClientFramingDecoder decoder, IConnection connection, Uri via, string contentType, TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		ValidateReadingFaultString(decoder);
		int num = await connection.ReadAsync(0, Math.Min(256, connection.AsyncReadBufferSize), timeoutHelper.RemainingTime());
		int offset = 0;
		while (num > 0)
		{
			int num2 = decoder.Decode(connection.AsyncReadBuffer, offset, num);
			offset += num2;
			num -= num2;
			if (decoder.CurrentState == ClientFramingDecoderState.Fault)
			{
				ConnectionUtilities.CloseNoThrow(connection, timeoutHelper.RemainingTime());
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(FaultStringDecoder.GetFaultException(decoder.Fault, via.ToString(), contentType));
			}
			if (decoder.CurrentState != ClientFramingDecoderState.ReadingFaultString)
			{
				throw new Exception("invalid framing client state machine");
			}
			if (num == 0)
			{
				offset = 0;
				num = await connection.ReadAsync(0, Math.Min(256, connection.AsyncReadBufferSize), timeoutHelper.RemainingTime());
			}
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(decoder.CreatePrematureEOFException());
	}

	public static void DecodeFramingFault(ClientFramingDecoder decoder, IConnection connection, Uri via, string contentType, ref TimeoutHelper timeoutHelper)
	{
		ValidateReadingFaultString(decoder);
		int num = 0;
		byte[] array = Fx.AllocateByteArray(256);
		int num2 = connection.Read(array, num, array.Length, timeoutHelper.RemainingTime());
		while (num2 > 0)
		{
			int num3 = decoder.Decode(array, num, num2);
			num += num3;
			num2 -= num3;
			if (decoder.CurrentState == ClientFramingDecoderState.Fault)
			{
				ConnectionUtilities.CloseNoThrow(connection, timeoutHelper.RemainingTime());
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(FaultStringDecoder.GetFaultException(decoder.Fault, via.ToString(), contentType));
			}
			if (decoder.CurrentState != ClientFramingDecoderState.ReadingFaultString)
			{
				throw new Exception("invalid framing client state machine");
			}
			if (num2 == 0)
			{
				num = 0;
				num2 = connection.Read(array, num, array.Length, timeoutHelper.RemainingTime());
			}
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(decoder.CreatePrematureEOFException());
	}

	public static bool InitiateUpgrade(StreamUpgradeInitiator upgradeInitiator, ref IConnection connection, ClientFramingDecoder decoder, IDefaultCommunicationTimeouts defaultTimeouts, ref TimeoutHelper timeoutHelper)
	{
		for (string nextUpgrade = upgradeInitiator.GetNextUpgrade(); nextUpgrade != null; nextUpgrade = upgradeInitiator.GetNextUpgrade())
		{
			EncodedUpgrade encodedUpgrade = new EncodedUpgrade(nextUpgrade);
			connection.Write(encodedUpgrade.EncodedBytes, 0, encodedUpgrade.EncodedBytes.Length, immediate: true, timeoutHelper.RemainingTime());
			byte[] array = new byte[1];
			int count = connection.Read(array, 0, array.Length, timeoutHelper.RemainingTime());
			if (!ValidateUpgradeResponse(array, count, decoder))
			{
				return false;
			}
			ConnectionStream connectionStream = new ConnectionStream(connection, defaultTimeouts);
			Stream stream = upgradeInitiator.InitiateUpgrade(connectionStream);
			connection = new StreamConnection(stream, connectionStream);
		}
		return true;
	}

	public static async Task<bool> InitiateUpgradeAsync(StreamUpgradeInitiator upgradeInitiator, OutWrapper<IConnection> connectionWrapper, ClientFramingDecoder decoder, IDefaultCommunicationTimeouts defaultTimeouts, TimeSpan timeout)
	{
		IConnection connection = connectionWrapper.Value;
		for (string nextUpgrade = upgradeInitiator.GetNextUpgrade(); nextUpgrade != null; nextUpgrade = upgradeInitiator.GetNextUpgrade())
		{
			EncodedUpgrade encodedUpgrade = new EncodedUpgrade(nextUpgrade);
			await connection.WriteAsync(encodedUpgrade.EncodedBytes, 0, encodedUpgrade.EncodedBytes.Length, immediate: true, timeout);
			byte[] buffer = new byte[1];
			if (!ValidateUpgradeResponse(buffer, await connection.ReadAsync(buffer, 0, buffer.Length, timeout), decoder))
			{
				return false;
			}
			ConnectionStream connectionStream = new ConnectionStream(connection, defaultTimeouts);
			connection = (connectionWrapper.Value = new StreamConnection(await upgradeInitiator.InitiateUpgradeAsync(connectionStream), connectionStream));
		}
		return true;
	}

	private static void ValidateReadingFaultString(ClientFramingDecoder decoder)
	{
		if (decoder.CurrentState != ClientFramingDecoderState.ReadingFaultString)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.ServerRejectedUpgradeRequest));
		}
	}

	public static bool ValidatePreambleResponse(byte[] buffer, int count, ClientFramingDecoder decoder, Uri via)
	{
		if (count == 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ProtocolException(System.SR.Format(System.SR.ServerRejectedSessionPreamble, via), decoder.CreatePrematureEOFException()));
		}
		while (decoder.Decode(buffer, 0, count) == 0)
		{
		}
		if (decoder.CurrentState != ClientFramingDecoderState.Start)
		{
			return false;
		}
		return true;
	}

	private static bool ValidateUpgradeResponse(byte[] buffer, int count, ClientFramingDecoder decoder)
	{
		if (count == 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.ServerRejectedUpgradeRequest, decoder.CreatePrematureEOFException()));
		}
		while (decoder.Decode(buffer, 0, count) == 0)
		{
		}
		if (decoder.CurrentState != ClientFramingDecoderState.UpgradeResponse)
		{
			return false;
		}
		return true;
	}
}
