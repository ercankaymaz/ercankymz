using System;
using System.Collections.Generic;
using Org.BouncyCastle.Crypto.Utilities;

namespace Org.BouncyCastle.Pqc.Crypto.SphincsPlus;

public sealed class SphincsPlusParameters
{
	public static SphincsPlusParameters sha2_128f;

	public static SphincsPlusParameters sha2_128s;

	public static SphincsPlusParameters sha2_192f;

	public static SphincsPlusParameters sha2_192s;

	public static SphincsPlusParameters sha2_256f;

	public static SphincsPlusParameters sha2_256s;

	public static SphincsPlusParameters sha2_128f_simple;

	public static SphincsPlusParameters sha2_128s_simple;

	public static SphincsPlusParameters sha2_192f_simple;

	public static SphincsPlusParameters sha2_192s_simple;

	public static SphincsPlusParameters sha2_256f_simple;

	public static SphincsPlusParameters sha2_256s_simple;

	public static SphincsPlusParameters shake_128f;

	public static SphincsPlusParameters shake_128s;

	public static SphincsPlusParameters shake_192f;

	public static SphincsPlusParameters shake_192s;

	public static SphincsPlusParameters shake_256f;

	public static SphincsPlusParameters shake_256s;

	public static SphincsPlusParameters shake_128f_simple;

	public static SphincsPlusParameters shake_128s_simple;

	public static SphincsPlusParameters shake_192f_simple;

	public static SphincsPlusParameters shake_192s_simple;

	public static SphincsPlusParameters shake_256f_simple;

	public static SphincsPlusParameters shake_256s_simple;

	public static SphincsPlusParameters haraka_128f;

	public static SphincsPlusParameters haraka_128s;

	public static SphincsPlusParameters haraka_256f;

	public static SphincsPlusParameters haraka_256s;

	public static SphincsPlusParameters haraka_192f;

	public static SphincsPlusParameters haraka_192s;

	public static SphincsPlusParameters haraka_128f_simple;

	public static SphincsPlusParameters haraka_128s_simple;

	public static SphincsPlusParameters haraka_192f_simple;

	public static SphincsPlusParameters haraka_192s_simple;

	public static SphincsPlusParameters haraka_256f_simple;

	public static SphincsPlusParameters haraka_256s_simple;

	private static uint sphincsPlus_sha2_128f_robust;

	private static uint sphincsPlus_sha2_128s_robust;

	private static uint sphincsPlus_sha2_192f_robust;

	private static uint sphincsPlus_sha2_192s_robust;

	private static uint sphincsPlus_sha2_256f_robust;

	private static uint sphincsPlus_sha2_256s_robust;

	private static uint sphincsPlus_sha2_128f_simple;

	private static uint sphincsPlus_sha2_128s_simple;

	private static uint sphincsPlus_sha2_192f_simple;

	private static uint sphincsPlus_sha2_192s_simple;

	private static uint sphincsPlus_sha2_256f_simple;

	private static uint sphincsPlus_sha2_256s_simple;

	private static uint sphincsPlus_shake_128f_robust;

	private static uint sphincsPlus_shake_128s_robust;

	private static uint sphincsPlus_shake_192f_robust;

	private static uint sphincsPlus_shake_192s_robust;

	private static uint sphincsPlus_shake_256f_robust;

	private static uint sphincsPlus_shake_256s_robust;

	private static uint sphincsPlus_shake_128f_simple;

	private static uint sphincsPlus_shake_128s_simple;

	private static uint sphincsPlus_shake_192f_simple;

	private static uint sphincsPlus_shake_192s_simple;

	private static uint sphincsPlus_shake_256f_simple;

	private static uint sphincsPlus_shake_256s_simple;

	private static uint sphincsPlus_haraka_128f_robust;

	private static uint sphincsPlus_haraka_128s_robust;

	private static uint sphincsPlus_haraka_192f_robust;

	private static uint sphincsPlus_haraka_192s_robust;

	private static uint sphincsPlus_haraka_256f_robust;

	private static uint sphincsPlus_haraka_256s_robust;

	private static uint sphincsPlus_haraka_128f_simple;

	private static uint sphincsPlus_haraka_128s_simple;

	private static uint sphincsPlus_haraka_192f_simple;

	private static uint sphincsPlus_haraka_192s_simple;

	private static uint sphincsPlus_haraka_256f_simple;

	private static uint sphincsPlus_haraka_256s_simple;

	private static Dictionary<uint, SphincsPlusParameters> oidToParams;

	private static Dictionary<SphincsPlusParameters, uint> paramsToOid;

	private readonly string m_name;

	private readonly ISphincsPlusEngineProvider m_engineProvider;

	public string Name => m_name;

	internal int N => m_engineProvider.N;

	static SphincsPlusParameters()
	{
		sha2_128f = new SphincsPlusParameters("sha2-128f-robust", new Sha2EngineProvider(robust: true, 16, 16u, 22u, 6, 33, 66u));
		sha2_128s = new SphincsPlusParameters("sha2-128s-robust", new Sha2EngineProvider(robust: true, 16, 16u, 7u, 12, 14, 63u));
		sha2_192f = new SphincsPlusParameters("sha2-192f-robust", new Sha2EngineProvider(robust: true, 24, 16u, 22u, 8, 33, 66u));
		sha2_192s = new SphincsPlusParameters("sha2-192s-robust", new Sha2EngineProvider(robust: true, 24, 16u, 7u, 14, 17, 63u));
		sha2_256f = new SphincsPlusParameters("sha2-256f-robust", new Sha2EngineProvider(robust: true, 32, 16u, 17u, 9, 35, 68u));
		sha2_256s = new SphincsPlusParameters("sha2-256s-robust", new Sha2EngineProvider(robust: true, 32, 16u, 8u, 14, 22, 64u));
		sha2_128f_simple = new SphincsPlusParameters("sha2-128f-simple", new Sha2EngineProvider(robust: false, 16, 16u, 22u, 6, 33, 66u));
		sha2_128s_simple = new SphincsPlusParameters("sha2-128s-simple", new Sha2EngineProvider(robust: false, 16, 16u, 7u, 12, 14, 63u));
		sha2_192f_simple = new SphincsPlusParameters("sha2-192f-simple", new Sha2EngineProvider(robust: false, 24, 16u, 22u, 8, 33, 66u));
		sha2_192s_simple = new SphincsPlusParameters("sha2-192s-simple", new Sha2EngineProvider(robust: false, 24, 16u, 7u, 14, 17, 63u));
		sha2_256f_simple = new SphincsPlusParameters("sha2-256f-simple", new Sha2EngineProvider(robust: false, 32, 16u, 17u, 9, 35, 68u));
		sha2_256s_simple = new SphincsPlusParameters("sha2-256s-simple", new Sha2EngineProvider(robust: false, 32, 16u, 8u, 14, 22, 64u));
		shake_128f = new SphincsPlusParameters("shake-128f-robust", new Shake256EngineProvider(robust: true, 16, 16u, 22u, 6, 33, 66u));
		shake_128s = new SphincsPlusParameters("shake-128s-robust", new Shake256EngineProvider(robust: true, 16, 16u, 7u, 12, 14, 63u));
		shake_192f = new SphincsPlusParameters("shake-192f-robust", new Shake256EngineProvider(robust: true, 24, 16u, 22u, 8, 33, 66u));
		shake_192s = new SphincsPlusParameters("shake-192s-robust", new Shake256EngineProvider(robust: true, 24, 16u, 7u, 14, 17, 63u));
		shake_256f = new SphincsPlusParameters("shake-256f-robust", new Shake256EngineProvider(robust: true, 32, 16u, 17u, 9, 35, 68u));
		shake_256s = new SphincsPlusParameters("shake-256s-robust", new Shake256EngineProvider(robust: true, 32, 16u, 8u, 14, 22, 64u));
		shake_128f_simple = new SphincsPlusParameters("shake-128f-simple", new Shake256EngineProvider(robust: false, 16, 16u, 22u, 6, 33, 66u));
		shake_128s_simple = new SphincsPlusParameters("shake-128s-simple", new Shake256EngineProvider(robust: false, 16, 16u, 7u, 12, 14, 63u));
		shake_192f_simple = new SphincsPlusParameters("shake-192f-simple", new Shake256EngineProvider(robust: false, 24, 16u, 22u, 8, 33, 66u));
		shake_192s_simple = new SphincsPlusParameters("shake-192s-simple", new Shake256EngineProvider(robust: false, 24, 16u, 7u, 14, 17, 63u));
		shake_256f_simple = new SphincsPlusParameters("shake-256f-simple", new Shake256EngineProvider(robust: false, 32, 16u, 17u, 9, 35, 68u));
		shake_256s_simple = new SphincsPlusParameters("shake-256s-simple", new Shake256EngineProvider(robust: false, 32, 16u, 8u, 14, 22, 64u));
		haraka_128f = new SphincsPlusParameters("haraka-128f-robust", new Haraka256EngineProvider(robust: true, 16, 16u, 22u, 6, 33, 66u));
		haraka_128s = new SphincsPlusParameters("haraka-128s-robust", new Haraka256EngineProvider(robust: true, 16, 16u, 7u, 12, 14, 63u));
		haraka_256f = new SphincsPlusParameters("haraka-256f-robust", new Haraka256EngineProvider(robust: true, 32, 16u, 17u, 9, 35, 68u));
		haraka_256s = new SphincsPlusParameters("haraka-256s-robust", new Haraka256EngineProvider(robust: true, 32, 16u, 8u, 14, 22, 64u));
		haraka_192f = new SphincsPlusParameters("haraka-192f-robust", new Haraka256EngineProvider(robust: true, 24, 16u, 22u, 8, 33, 66u));
		haraka_192s = new SphincsPlusParameters("haraka-192s-robust", new Haraka256EngineProvider(robust: true, 24, 16u, 7u, 14, 17, 63u));
		haraka_128f_simple = new SphincsPlusParameters("haraka-128f-simple", new Haraka256EngineProvider(robust: false, 16, 16u, 22u, 6, 33, 66u));
		haraka_128s_simple = new SphincsPlusParameters("haraka-128s-simple", new Haraka256EngineProvider(robust: false, 16, 16u, 7u, 12, 14, 63u));
		haraka_192f_simple = new SphincsPlusParameters("haraka-192f-simple", new Haraka256EngineProvider(robust: false, 24, 16u, 22u, 8, 33, 66u));
		haraka_192s_simple = new SphincsPlusParameters("haraka-192s-simple", new Haraka256EngineProvider(robust: false, 24, 16u, 7u, 14, 17, 63u));
		haraka_256f_simple = new SphincsPlusParameters("haraka-256f-simple", new Haraka256EngineProvider(robust: false, 32, 16u, 17u, 9, 35, 68u));
		haraka_256s_simple = new SphincsPlusParameters("haraka-256s-simple", new Haraka256EngineProvider(robust: false, 32, 16u, 8u, 14, 22, 64u));
		sphincsPlus_sha2_128f_robust = 65793u;
		sphincsPlus_sha2_128s_robust = 65794u;
		sphincsPlus_sha2_192f_robust = 65795u;
		sphincsPlus_sha2_192s_robust = 65796u;
		sphincsPlus_sha2_256f_robust = 65797u;
		sphincsPlus_sha2_256s_robust = 65798u;
		sphincsPlus_sha2_128f_simple = 66049u;
		sphincsPlus_sha2_128s_simple = 66050u;
		sphincsPlus_sha2_192f_simple = 66051u;
		sphincsPlus_sha2_192s_simple = 66052u;
		sphincsPlus_sha2_256f_simple = 66053u;
		sphincsPlus_sha2_256s_simple = 66054u;
		sphincsPlus_shake_128f_robust = 131329u;
		sphincsPlus_shake_128s_robust = 131330u;
		sphincsPlus_shake_192f_robust = 131331u;
		sphincsPlus_shake_192s_robust = 131332u;
		sphincsPlus_shake_256f_robust = 131333u;
		sphincsPlus_shake_256s_robust = 131334u;
		sphincsPlus_shake_128f_simple = 131585u;
		sphincsPlus_shake_128s_simple = 131586u;
		sphincsPlus_shake_192f_simple = 131587u;
		sphincsPlus_shake_192s_simple = 131588u;
		sphincsPlus_shake_256f_simple = 131589u;
		sphincsPlus_shake_256s_simple = 131590u;
		sphincsPlus_haraka_128f_robust = 196865u;
		sphincsPlus_haraka_128s_robust = 196866u;
		sphincsPlus_haraka_192f_robust = 196867u;
		sphincsPlus_haraka_192s_robust = 196868u;
		sphincsPlus_haraka_256f_robust = 196869u;
		sphincsPlus_haraka_256s_robust = 196870u;
		sphincsPlus_haraka_128f_simple = 197121u;
		sphincsPlus_haraka_128s_simple = 197122u;
		sphincsPlus_haraka_192f_simple = 197123u;
		sphincsPlus_haraka_192s_simple = 197124u;
		sphincsPlus_haraka_256f_simple = 197125u;
		sphincsPlus_haraka_256s_simple = 197126u;
		oidToParams = new Dictionary<uint, SphincsPlusParameters>();
		paramsToOid = new Dictionary<SphincsPlusParameters, uint>();
		oidToParams[sphincsPlus_sha2_128f_robust] = sha2_128f;
		oidToParams[sphincsPlus_sha2_128s_robust] = sha2_128s;
		oidToParams[sphincsPlus_sha2_192f_robust] = sha2_192f;
		oidToParams[sphincsPlus_sha2_192s_robust] = sha2_192s;
		oidToParams[sphincsPlus_sha2_256f_robust] = sha2_256f;
		oidToParams[sphincsPlus_sha2_256s_robust] = sha2_256s;
		oidToParams[sphincsPlus_sha2_128f_simple] = sha2_128f_simple;
		oidToParams[sphincsPlus_sha2_128s_simple] = sha2_128s_simple;
		oidToParams[sphincsPlus_sha2_192f_simple] = sha2_192f_simple;
		oidToParams[sphincsPlus_sha2_192s_simple] = sha2_192s_simple;
		oidToParams[sphincsPlus_sha2_256f_simple] = sha2_256f_simple;
		oidToParams[sphincsPlus_sha2_256s_simple] = sha2_256s_simple;
		oidToParams[sphincsPlus_shake_128f_robust] = shake_128f;
		oidToParams[sphincsPlus_shake_128s_robust] = shake_128s;
		oidToParams[sphincsPlus_shake_192f_robust] = shake_192f;
		oidToParams[sphincsPlus_shake_192s_robust] = shake_192s;
		oidToParams[sphincsPlus_shake_256f_robust] = shake_256f;
		oidToParams[sphincsPlus_shake_256s_robust] = shake_256s;
		oidToParams[sphincsPlus_shake_128f_simple] = shake_128f_simple;
		oidToParams[sphincsPlus_shake_128s_simple] = shake_128s_simple;
		oidToParams[sphincsPlus_shake_192f_simple] = shake_192f_simple;
		oidToParams[sphincsPlus_shake_192s_simple] = shake_192s_simple;
		oidToParams[sphincsPlus_shake_256f_simple] = shake_256f_simple;
		oidToParams[sphincsPlus_shake_256s_simple] = shake_256s_simple;
		oidToParams[sphincsPlus_haraka_128f_simple] = haraka_128f_simple;
		oidToParams[sphincsPlus_haraka_128f_robust] = haraka_128f;
		oidToParams[sphincsPlus_haraka_192f_simple] = haraka_192f_simple;
		oidToParams[sphincsPlus_haraka_192f_robust] = haraka_192f;
		oidToParams[sphincsPlus_haraka_256f_simple] = haraka_256f_simple;
		oidToParams[sphincsPlus_haraka_256f_robust] = haraka_256f;
		oidToParams[sphincsPlus_haraka_128s_simple] = haraka_128s_simple;
		oidToParams[sphincsPlus_haraka_128s_robust] = haraka_128s;
		oidToParams[sphincsPlus_haraka_192s_simple] = haraka_192s_simple;
		oidToParams[sphincsPlus_haraka_192s_robust] = haraka_192s;
		oidToParams[sphincsPlus_haraka_256s_simple] = haraka_256s_simple;
		oidToParams[sphincsPlus_haraka_256s_robust] = haraka_256s;
		paramsToOid[sha2_128f] = sphincsPlus_sha2_128f_robust;
		paramsToOid[sha2_128s] = sphincsPlus_sha2_128s_robust;
		paramsToOid[sha2_192f] = sphincsPlus_sha2_192f_robust;
		paramsToOid[sha2_192s] = sphincsPlus_sha2_192s_robust;
		paramsToOid[sha2_256f] = sphincsPlus_sha2_256f_robust;
		paramsToOid[sha2_256s] = sphincsPlus_sha2_256s_robust;
		paramsToOid[sha2_128f_simple] = sphincsPlus_sha2_128f_simple;
		paramsToOid[sha2_128s_simple] = sphincsPlus_sha2_128s_simple;
		paramsToOid[sha2_192f_simple] = sphincsPlus_sha2_192f_simple;
		paramsToOid[sha2_192s_simple] = sphincsPlus_sha2_192s_simple;
		paramsToOid[sha2_256f_simple] = sphincsPlus_sha2_256f_simple;
		paramsToOid[sha2_256s_simple] = sphincsPlus_sha2_256s_simple;
		paramsToOid[shake_128f] = sphincsPlus_shake_128f_robust;
		paramsToOid[shake_128s] = sphincsPlus_shake_128s_robust;
		paramsToOid[shake_192f] = sphincsPlus_shake_192f_robust;
		paramsToOid[shake_192s] = sphincsPlus_shake_192s_robust;
		paramsToOid[shake_256f] = sphincsPlus_shake_256f_robust;
		paramsToOid[shake_256s] = sphincsPlus_shake_256s_robust;
		paramsToOid[shake_128f_simple] = sphincsPlus_shake_128f_simple;
		paramsToOid[shake_128s_simple] = sphincsPlus_shake_128s_simple;
		paramsToOid[shake_192f_simple] = sphincsPlus_shake_192f_simple;
		paramsToOid[shake_192s_simple] = sphincsPlus_shake_192s_simple;
		paramsToOid[shake_256f_simple] = sphincsPlus_shake_256f_simple;
		paramsToOid[shake_256s_simple] = sphincsPlus_shake_256s_simple;
		paramsToOid[haraka_128f_simple] = sphincsPlus_haraka_128f_simple;
		paramsToOid[haraka_192f_simple] = sphincsPlus_haraka_192f_simple;
		paramsToOid[haraka_256f_simple] = sphincsPlus_haraka_256f_simple;
		paramsToOid[haraka_128s_simple] = sphincsPlus_haraka_128s_simple;
		paramsToOid[haraka_192s_simple] = sphincsPlus_haraka_192s_simple;
		paramsToOid[haraka_256s_simple] = sphincsPlus_haraka_256s_simple;
		paramsToOid[haraka_128f] = sphincsPlus_haraka_128f_robust;
		paramsToOid[haraka_192f] = sphincsPlus_haraka_192f_robust;
		paramsToOid[haraka_256f] = sphincsPlus_haraka_256f_robust;
		paramsToOid[haraka_128s] = sphincsPlus_haraka_128s_robust;
		paramsToOid[haraka_192s] = sphincsPlus_haraka_192s_robust;
		paramsToOid[haraka_256s] = sphincsPlus_haraka_256s_robust;
	}

	private SphincsPlusParameters(string name, ISphincsPlusEngineProvider engineProvider)
	{
		m_name = name;
		m_engineProvider = engineProvider;
	}

	internal SphincsPlusEngine GetEngine()
	{
		return m_engineProvider.Get();
	}

	public static SphincsPlusParameters GetParams(int id)
	{
		return oidToParams[Convert.ToUInt32(id)];
	}

	public static int GetID(SphincsPlusParameters parameters)
	{
		return Convert.ToInt32(paramsToOid[parameters]);
	}

	public byte[] GetEncoded()
	{
		return Pack.UInt32_To_BE((uint)GetID(this));
	}
}
