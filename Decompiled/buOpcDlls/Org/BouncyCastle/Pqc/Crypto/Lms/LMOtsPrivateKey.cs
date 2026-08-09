using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public sealed class LMOtsPrivateKey
{
	private readonly LMOtsParameters m_parameters;

	private readonly byte[] m_I;

	private readonly int m_q;

	private readonly byte[] m_masterSecret;

	public LMOtsParameters Parameters => m_parameters;

	public byte[] I => m_I;

	public int Q => m_q;

	public byte[] MasterSecret => m_masterSecret;

	public LMOtsPrivateKey(LMOtsParameters parameters, byte[] i, int q, byte[] masterSecret)
	{
		m_parameters = parameters;
		m_I = i;
		m_q = q;
		m_masterSecret = masterSecret;
	}

	public LmsContext GetSignatureContext(LMSigParameters sigParams, byte[][] path)
	{
		byte[] array = new byte[LMOts.SEED_LEN];
		SeedDerive derivationFunction = GetDerivationFunction();
		derivationFunction.J = LMOts.SEED_RANDOMISER_INDEX;
		derivationFunction.DeriveSeed(incJ: false, array, 0);
		IDigest digest = DigestUtilities.GetDigest(m_parameters.DigestOid);
		LmsUtilities.ByteArray(m_I, digest);
		LmsUtilities.U32Str(m_q, digest);
		LmsUtilities.U16Str((short)LMOts.D_MESG, digest);
		LmsUtilities.ByteArray(array, digest);
		return new LmsContext(this, sigParams, digest, array, path);
	}

	internal SeedDerive GetDerivationFunction()
	{
		return new SeedDerive(m_I, m_masterSecret, DigestUtilities.GetDigest(m_parameters.DigestOid))
		{
			Q = m_q,
			J = 0
		};
	}
}
