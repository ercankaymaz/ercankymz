using System;
using Aladdin.HASP.Internal;
using HEDS;

namespace Aladdin.HASP;

public class Hasp : ICloneable, IDisposable, IComparable<Hasp>
{
	internal class HaspBase
	{
		public int handle = 0;

		public bool loggedOut = false;

		public HaspFeature feature;

		private bool loggedIn = false;

		private int refCount = 1;

		public bool IsLoggedIn
		{
			get
			{
				return loggedIn;
			}
			set
			{
				loggedIn = value;
			}
		}

		public int RefCount
		{
			get
			{
				return refCount;
			}
			set
			{
				refCount = value;
			}
		}

		public HaspBase(HaspFeature feature)
		{
			this.feature = feature;
		}
	}

	internal HaspBase key;

	private bool isFeatureSet = false;

	private bool isDisposed = false;

	private static string libPath;

	private static bool tested;

	public HaspFeature Feature => key.feature;

	public HaspLegacy Legacy => new HaspLegacy(HasLegacy ? this : new Hasp());

	public bool HasLegacy
	{
		get
		{
			if (isDisposed)
			{
				return false;
			}
			return key.feature.IsProgNum;
		}
	}

	public static string KeyInfo => "<haspformat format=\"keyinfo\"/>";

	public static string SessionInfo => "<haspformat format=\"sessioninfo\"/>";

	public static string UpdateInfo => "<haspformat format=\"updateinfo\"/>";

	public static string Recipient => "<haspformat root=\"location\">  <license_manager>    <attribute name=\"id\" />    <attribute name=\"time\" />    <element name=\"hostname\" />    <element name=\"version\" />    <element name=\"host_fingerprint\" />  </license_manager></haspformat>";

	public static string Fingerprint => "<haspformat format=\"host_fingerprint\"/>";

	public Hasp()
	{
		SetKey(HaspFeature.Default);
		isFeatureSet = true;
	}

	public Hasp(HaspFeature feature)
	{
		SetKey(feature);
		isFeatureSet = true;
	}

	private void SetKey(HaspFeature feature)
	{
		key = new HaspBase(feature);
	}

	public Hasp(Hasp other)
	{
		if (other == null)
		{
			SetKey(HaspFeature.Default);
			return;
		}
		key = other.key;
		key.RefCount++;
		isFeatureSet = other.isFeatureSet;
	}

	~Hasp()
	{
		Dispose(disposing: false);
	}

	public HaspStatus Decrypt(byte[] data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.decrypt(key.handle, data);
	}

	public HaspStatus Decrypt(char[] data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.decrypt(key.handle, data);
	}

	public HaspStatus Decrypt(double[] data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.decrypt(key.handle, data);
	}

	public HaspStatus Decrypt(short[] data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.decrypt(key.handle, data);
	}

	public HaspStatus Decrypt(int[] data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.decrypt(key.handle, data);
	}

	public HaspStatus Decrypt(long[] data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.decrypt(key.handle, data);
	}

	public HaspStatus Decrypt(float[] data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.decrypt(key.handle, data);
	}

	public HaspStatus Decrypt(ref string data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.decrypt(key.handle, ref data);
	}

	public HaspStatus Encrypt(byte[] data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.encrypt(key.handle, data);
	}

	public HaspStatus Encrypt(char[] data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.encrypt(key.handle, data);
	}

	public HaspStatus Encrypt(double[] data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.encrypt(key.handle, data);
	}

	public HaspStatus Encrypt(short[] data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.encrypt(key.handle, data);
	}

	public HaspStatus Encrypt(int[] data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.encrypt(key.handle, data);
	}

	public HaspStatus Encrypt(long[] data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.encrypt(key.handle, data);
	}

	public HaspStatus Encrypt(float[] data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.encrypt(key.handle, data);
	}

	public HaspStatus Encrypt(ref string data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.encrypt(key.handle, ref data);
	}

	public HaspFile GetFile()
	{
		return GetFile(HaspFileId.Main);
	}

	public HaspFile GetFile(HaspFileId fileId)
	{
		return new HaspFile(fileId, IsValid() ? this : new Hasp());
	}

	public HaspFile GetFile(int fileId)
	{
		return new HaspFile(fileId, IsValid() ? this : new Hasp());
	}

	public static HaspStatus GetInfo(string query, string format, byte[] vendorCode, ref string info)
	{
		try
		{
			TestSignature();
		}
		catch (DllBrokenException)
		{
			return HaspStatus.HaspDotNetDllBroken;
		}
		if (query == null || format == null || vendorCode == null)
		{
			return HaspStatus.InvalidParameter;
		}
		info = "";
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.get_info(query, format, vendorCode, ref info);
	}

	public static HaspStatus GetInfo(string query, string format, string vendorCode, ref string info)
	{
		try
		{
			TestSignature();
		}
		catch (DllBrokenException)
		{
			return HaspStatus.HaspDotNetDllBroken;
		}
		if (query == null || format == null || vendorCode == null)
		{
			return HaspStatus.InvalidParameter;
		}
		info = "";
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.get_info(query, format, vendorCode, ref info);
	}

	public HaspStatus GetRtc(ref DateTime rtc)
	{
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		long time = 0L;
		haspStatus = ApiDisp.get_rtc(key.handle, ref time);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		DateTime dateTime = new DateTime(1970, 1, 1);
		rtc = new DateTime(time * 10 * 1000 * 1000 + dateTime.Ticks);
		return haspStatus;
	}

	public HaspStatus GetSessionInfo(string format, ref string info)
	{
		HaspStatus haspStatus = Hasp_Prologue(key);
		info = "";
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.get_sessioninfo(key.handle, format, ref info);
	}

	public static HaspStatus GetApiVersion(byte[] vendorCode, ref HaspVersion version)
	{
		try
		{
			TestSignature();
		}
		catch (DllBrokenException)
		{
			return HaspStatus.HaspDotNetDllBroken;
		}
		int major_version = 0;
		int minor_version = 0;
		int build_server = 0;
		int build_number = 0;
		version = default(HaspVersion);
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		haspStatus = ApiDisp.get_version(ref major_version, ref minor_version, ref build_server, ref build_number, vendorCode);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		version = new HaspVersion(major_version, minor_version, build_server, build_number);
		return HaspStatus.StatusOk;
	}

	public static HaspStatus GetApiVersion(string vendorCode, ref HaspVersion version)
	{
		try
		{
			TestSignature();
		}
		catch (DllBrokenException)
		{
			return HaspStatus.HaspDotNetDllBroken;
		}
		int major_version = 0;
		int minor_version = 0;
		int build_server = 0;
		int build_number = 0;
		version = default(HaspVersion);
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		haspStatus = ApiDisp.get_version(ref major_version, ref minor_version, ref build_server, ref build_number, vendorCode);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		version = new HaspVersion(major_version, minor_version, build_server, build_number);
		return HaspStatus.StatusOk;
	}

	public HaspStatus Login(byte[] vendorCode)
	{
		if (isDisposed)
		{
			return HaspStatus.InvalidObject;
		}
		try
		{
			TestSignature();
		}
		catch (DllBrokenException)
		{
			return HaspStatus.HaspDotNetDllBroken;
		}
		if (key.IsLoggedIn)
		{
			return HaspStatus.AlreadyLoggedIn;
		}
		HaspStatus haspStatus = ApiDisp.login(key.feature.Feature, vendorCode, ref key.handle);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		key.IsLoggedIn = true;
		return HaspStatus.StatusOk;
	}

	public HaspStatus Login(string vendorCode)
	{
		if (isDisposed)
		{
			return HaspStatus.InvalidObject;
		}
		try
		{
			TestSignature();
		}
		catch (DllBrokenException)
		{
			return HaspStatus.HaspDotNetDllBroken;
		}
		if (key.IsLoggedIn)
		{
			return HaspStatus.AlreadyLoggedIn;
		}
		HaspStatus haspStatus = ApiDisp.login(key.feature.Feature, vendorCode, ref key.handle);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		key.IsLoggedIn = true;
		return HaspStatus.StatusOk;
	}

	public HaspStatus Login(byte[] vendorCode, string scope)
	{
		if (isDisposed)
		{
			return HaspStatus.InvalidObject;
		}
		try
		{
			TestSignature();
		}
		catch (DllBrokenException)
		{
			return HaspStatus.HaspDotNetDllBroken;
		}
		if (key.IsLoggedIn)
		{
			return HaspStatus.AlreadyLoggedIn;
		}
		if (vendorCode == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = ApiDisp.login_scope(key.feature.Feature, scope, vendorCode, ref key.handle);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		key.IsLoggedIn = true;
		return HaspStatus.StatusOk;
	}

	public HaspStatus Login(string vendorCode, string scope)
	{
		if (isDisposed)
		{
			return HaspStatus.InvalidObject;
		}
		try
		{
			TestSignature();
		}
		catch (DllBrokenException)
		{
			return HaspStatus.HaspDotNetDllBroken;
		}
		if (key.IsLoggedIn)
		{
			return HaspStatus.AlreadyLoggedIn;
		}
		if (vendorCode == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = ApiDisp.login_scope(key.feature.Feature, scope, vendorCode, ref key.handle);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		key.IsLoggedIn = true;
		return HaspStatus.StatusOk;
	}

	public HaspStatus Logout()
	{
		if (isDisposed)
		{
			return HaspStatus.InvalidObject;
		}
		if (!key.IsLoggedIn)
		{
			return HaspStatus.InvalidHandle;
		}
		HaspStatus haspStatus = ApiDisp.logout(key.handle);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		key.IsLoggedIn = false;
		key.handle = 0;
		key.loggedOut = true;
		return HaspStatus.StatusOk;
	}

	public override string ToString()
	{
		return key.handle.ToString();
	}

	public static HaspStatus Update(string updateXml, ref string acknowledgeXml)
	{
		try
		{
			TestSignature();
		}
		catch (DllBrokenException)
		{
			return HaspStatus.HaspDotNetDllBroken;
		}
		acknowledgeXml = "";
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.update(updateXml, ref acknowledgeXml);
	}

	[Obsolete("Starting from Sentinel LDK version 6.0, the \u0093Detach\u0094 method has been deprecated.SafeNet recommends that user should use the \u0093Transfer\u0094 method to perform the detach/cancel actions. This method has been retained for backward compatibility.")]
	public static HaspStatus Detach(string detach_action, string scope, string vendor_code, string recipient, ref string info)
	{
		try
		{
			TestSignature();
		}
		catch (DllBrokenException)
		{
			return HaspStatus.HaspDotNetDllBroken;
		}
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.detach(detach_action, scope, vendor_code, recipient, ref info);
	}

	[Obsolete("Starting from Sentinel LDK version 6.0, the \u0093Detach\u0094 method has been deprecated.SafeNet recommends that user should use the \u0093Transfer\u0094 method to perform the detach/cancel actions. This method has been retained for backward compatibility.")]
	public static HaspStatus Detach(string detach_action, string scope, byte[] vendor_code, string recipient, ref string info)
	{
		try
		{
			TestSignature();
		}
		catch (DllBrokenException)
		{
			return HaspStatus.HaspDotNetDllBroken;
		}
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.detach(detach_action, scope, vendor_code, recipient, ref info);
	}

	public static HaspStatus Transfer(string action, string scope, string vendor_code, string recipient, ref string info)
	{
		try
		{
			TestSignature();
		}
		catch (DllBrokenException)
		{
			return HaspStatus.HaspDotNetDllBroken;
		}
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.transfer(action, scope, vendor_code, recipient, ref info);
	}

	public static HaspStatus Transfer(string action, string scope, byte[] vendor_code, string recipient, ref string info)
	{
		try
		{
			TestSignature();
		}
		catch (DllBrokenException)
		{
			return HaspStatus.HaspDotNetDllBroken;
		}
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.transfer(action, scope, vendor_code, recipient, ref info);
	}

	internal HaspStatus Hasp_Prologue(HaspBase key)
	{
		if (isDisposed)
		{
			return HaspStatus.InvalidObject;
		}
		if (key.IsLoggedIn)
		{
			return HaspStatus.StatusOk;
		}
		if (key.loggedOut)
		{
			return HaspStatus.AlreadyLoggedOut;
		}
		return HaspStatus.InvalidHandle;
	}

	internal static HaspStatus Hasp_Prologue()
	{
		return HaspStatus.StatusOk;
	}

	public bool IsValid()
	{
		return isFeatureSet && !isDisposed;
	}

	public bool IsLoggedIn()
	{
		if (key == null)
		{
			return false;
		}
		return IsValid() && key.IsLoggedIn;
	}

	public object Clone()
	{
		return new Hasp(this);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (isDisposed)
		{
			return;
		}
		if (key != null)
		{
			key.RefCount--;
			if (key.RefCount == 0 && key.IsLoggedIn)
			{
				Logout();
			}
			key = null;
		}
		isDisposed = true;
	}

	public Hasp Assign(Hasp other)
	{
		if (isDisposed)
		{
			return null;
		}
		key.RefCount--;
		if (key.RefCount == 0 && key.IsLoggedIn)
		{
			Logout();
		}
		key = null;
		if (other == null)
		{
			return null;
		}
		key = other.key;
		key.RefCount++;
		isFeatureSet = other.isFeatureSet;
		return this;
	}

	public int CompareTo(Hasp other)
	{
		if (other == null)
		{
			return 1;
		}
		int num = key.feature.CompareTo(other.key.feature);
		if (num != 0)
		{
			return num;
		}
		return key.handle.CompareTo(other.key.handle);
	}

	public override bool Equals(object obj)
	{
		return this == obj;
	}

	public static bool operator ==(Hasp left, object right)
	{
		if ((object)left == null && right == null)
		{
			return true;
		}
		if ((object)left == null || right == null)
		{
			return false;
		}
		Hasp hasp = right as Hasp;
		if (hasp == null)
		{
			HaspFile haspFile = right as HaspFile;
			if (haspFile == null)
			{
				return false;
			}
			return haspFile == left;
		}
		return left.CompareTo(hasp) == 0;
	}

	public static bool operator !=(Hasp left, object right)
	{
		return !(left == right);
	}

	public override int GetHashCode()
	{
		return key.handle;
	}

	private static void TestSignature()
	{
		if (ApiDisp.IsRunningOnMono() <= 0 && !tested)
		{
			HedsCrypt hedsCrypt = new HedsCrypt();
			hedsCrypt.Init("<RSAKeyValue>  <Modulus>tPkMcaY3CO1MlQp+hShdu1MWrOkisuRmubklR4cxQt9JM1i6wPooMkeRXu62u/JyUk           IEe4Y45JFCZL5/dOBirs7dyMBM+a0umaANRQE1wvr+k7uQyXuTo8dNwFlZR4WShBD2           O/gv/QMfgYuJ0nm5P0IFGjJrx+K6oiMrRLBcg5E=  </Modulus><Exponent>AQAB</Exponent></RSAKeyValue>");
			HedsFile hedsFile = new HedsFile();
			hedsFile.hedsCrypt = hedsCrypt;
			hedsFile.strFileName = IntPtr.Size switch
			{
				4 => "apidsp_windows.dll", 
				8 => "apidsp_windows_x64.dll", 
				_ => throw new PlatformNotSupportedException(), 
			};
			HedsFile.heds_status heds_status = hedsFile.CheckSignature(hedsFile.FindFile(libPath), 1);
			if (heds_status != HedsFile.heds_status.HEDS_STATUS_OK)
			{
				throw new DllBrokenException(heds_status.ToString());
			}
			tested = true;
		}
	}

	public HaspStatus SetLibPath(string path)
	{
		if (isDisposed)
		{
			return HaspStatus.InvalidObject;
		}
		HaspStatus haspStatus;
		if (path != null)
		{
			string text = path;
			if (!text.EndsWith("\\"))
			{
				text += "\\";
			}
			haspStatus = ApiDisp.set_lib_path(text);
		}
		else
		{
			haspStatus = ApiDisp.set_lib_path(path);
		}
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		if (path != null)
		{
			libPath = path;
		}
		try
		{
			TestSignature();
		}
		catch (DllBrokenException)
		{
			return HaspStatus.HaspDotNetDllBroken;
		}
		return HaspStatus.StatusOk;
	}
}
