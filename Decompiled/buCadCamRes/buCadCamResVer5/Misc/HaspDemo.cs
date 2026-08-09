using System;
using System.Collections.Specialized;
using System.Windows.Forms;
using Aladdin.HASP;

namespace buCadCamResVer5.Misc;

public class HaspDemo
{
	public static string KeyCode = "";

	protected StringCollection stringCollection;

	protected TextBox textHistory;

	public const string localScope = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?> <haspscope>    <license_manager hostname =\"localhost\" /> </haspscope>";

	public const string defaultScope = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?> <haspscope/> ";

	private string string_0;

	public HaspDemo(TextBox textHistory)
	{
		this.textHistory = textHistory;
		string[] value = new string[62]
		{
			"Success.", "Invalid memory address.", "Unknown/invalid feature id option.", "Memory allocation failed.", "Too many open features.", "Feature access denied.", "Incompatible feature.", "HASP not found.", "En-/decryption length too short.", "Invalid handle.",
			"Invalid file id / memory descriptor.", "Driver or support daemon version too old.", "Real time support not available.", "Generic error from host system call.", "Hardware key driver not found.", "Unrecognized info format.", "Request not supported.", "Invalid update object.", "Key with requested id was not found.", "Update data consistency check failed.",
			"Update not supported by this key.", "Update counter mismatch.", "Invalid vendor code.", "Requested encryption algorithm not supported.", "Invalid date / time.", "Clock out of power.", "Update requested ack., but no area to return it.", "Terminal services (remote terminal) detected.", "Feature type not implemented.", "Unknown algorithm.",
			"Signature check failed.", "Feature not found", "Trace log not enabled.", "Communication error between application and local LM", "Vendor code unknown to API library (run apigen to make it known)", "Invalid XML spec", "Invalid XML scope", "Too many keys connected", "Too many users", "Broken session",
			"Communication error between local and remote LM", "The feature is expired", "HASP LM version too old", "HASP SL secure storage I/O error or USB request error", "Update installation not allowed", "System time has been tampered", "Secure channel communication error", "Secure storage contains garbage", "Vendor lib cannot be found", "Vendor lib cannot be loaded",
			"No feature matching scope found", "Virtual machine detected", "HASP update incompatible with this hardware; HASP key is locked to other hardware", "Login denied because of user restrictions", "Update was already installed", "Another update must be installed first", "Vendor library version too old", "Upload error", "Invalid XML recipient parameter for hasp_detach", "Invalid XML action parameter for hasp_detach",
			"Scope for hasp_detach does not select a unique Product", "Invalid Product information"
		};
		stringCollection = new StringCollection();
		stringCollection.AddRange(value);
		for (int i = stringCollection.Count; i < 400; i++)
		{
			stringCollection.Insert(i, "");
		}
		value = new string[2] { "A required API dynamic library was not found", "The found and assigned API dynamic library could not be verified" };
		stringCollection.AddRange(value);
		for (int j = stringCollection.Count; j < 500; j++)
		{
			stringCollection.Insert(j, "");
		}
		value = new string[4] { "Calling invalid object.", "A parameter is invalid.", "Already logged in.", "Already logged out." };
		stringCollection.AddRange(value);
		for (int k = stringCollection.Count; k < 525; k++)
		{
			stringCollection.Insert(k, "");
		}
		stringCollection.Insert(525, "Unable to excecute/complete the operation.");
		for (int l = stringCollection.Count; l < 600; l++)
		{
			stringCollection.Insert(l, "");
		}
		stringCollection.Insert(600, "No classic memory extension block available.");
		for (int m = stringCollection.Count; m < 650; m++)
		{
			stringCollection.Insert(m, "");
		}
		stringCollection.Insert(650, "Invalid port type.");
		stringCollection.Insert(651, "Invalid port.");
		for (int n = stringCollection.Count; n < 698; n++)
		{
			stringCollection.Insert(n, "");
		}
		stringCollection.Insert(698, "Capability is not available.");
		stringCollection.Insert(699, "Internal API error.");
	}

	protected Hasp LoginDefaultDemo(ref bool LoginStatus)
	{
		LoginStatus = false;
		HaspFeature feature = HaspFeature.Default;
		Hasp hasp = new Hasp(feature);
		if (hasp.Login("WSwMmUVgIvID2im4BqBC9SDKxgdY9uPDb6BsB1esD6WChiUCC4UnFDl4jmg2TImue3Emn4Aum9MCfrB7kntl04VE/AbxirSvTmqG3/9lUataxj24Fzzcis2rKPU6jFtrdmpyBzc1lXSq2gspBd3VBizusnBXlTJwqCioCRthvmL4YtzSmjVxjK9z2wq2OmFL0frKoCSKzepqxmu6oxvNoZCBSp4XDB2sRCpCAVNYS2uIRgp3JtLM14Dhjr4dn4Stm3O4xnbHm6g3mx19pFa6BcwKRWbuY7gPOfkRh1qTRwDZI0/AYqNJj4aJwyr14E814vARkL5yn2d73ncoOjAzSsQSiSoXz1g5DWFweyX4gFyrc5ABPZF57utx6ptOm9jbpmCCTs68Q2Q/25km2UqRBiU18BACCMvw5G3fzykY0wyltXFj/Kd1+F97vH+Q8ho++X/FvdH11JkhQYwFpOis6wQg0LnyxDIB+69ow8t0jDlypWiMXsLe2gYhkbKzNGqm+mrm4YhYP4ZEtXD6FwA035liWk6KF3ab+VFqZVua7XLwwy7pQo7EqKwzE9x8C3Fa0qUa7jkKtpRLd1b0htqIbLz2aZ9f63UrdbvQlCA8mWoqq8xe2O1GKbPk7wYOSqm5is8N+U/OasWg4z0pEbVWj4BhYwDfpI8CGrori2pMLxCR0W35nK5Vuv8WKSYVD7Pxf0ia0Zz6E/n1T/y/T80X8fBibWasyE7a701QNTocMA6XoaaVJtBAIz7M62/0AkK+7Mtweqo0zFygROXcosjtWnwNzlrPd3rTwxAZnDk/IFXoAaVnNEz8aa4wtmpTc4uqmU/q80eAYt7VUB4k+A86nOgPCmmpldJ2aQi7blOcw1aQDDC/FF5GQt+CikInnIKamYvswbFzZxCrN3fYLDZYjhv0Qyd0kUcKKlmhDATCjh13PzjZQNRX4tX/ug0srYDqiSxZQpPIQawe9n2WFs8w3w==", string_0) == HaspStatus.StatusOk)
		{
			LoginStatus = true;
		}
		return (!hasp.IsLoggedIn()) ? null : hasp;
	}

	protected void LogoutDemo(ref Hasp hasp)
	{
		if (!(null == hasp) && hasp.IsLoggedIn())
		{
			hasp.Logout();
			hasp.Dispose();
			hasp = null;
		}
	}

	protected void ReadWriteDemo(Hasp hasp, HaspFileId fileId)
	{
		if (null == hasp || !hasp.IsLoggedIn())
		{
			return;
		}
		HaspFile file = hasp.GetFile(fileId);
		if (!file.IsLoggedIn())
		{
			return;
		}
		int size = 0;
		if (file.FileSize(ref size) != HaspStatus.StatusOk)
		{
			return;
		}
		byte[] array = new byte[size];
		if (file.Read(array, 0, 0) != HaspStatus.StatusOk)
		{
			return;
		}
		KeyCode = "";
		for (int i = 0; i <= array.Length - 1; i++)
		{
			if (array[i] > 0)
			{
				KeyCode += Convert.ToString((char)array[i]);
			}
		}
	}

	public void RunDemo(string scope, ref bool LoginStatus, ref string KeyCode)
	{
		try
		{
			string_0 = scope;
			Hasp hasp = LoginDefaultDemo(ref LoginStatus);
			ReadWriteDemo(hasp, HaspFileId.ReadWrite);
			KeyCode = HaspDemo.KeyCode;
			LogoutDemo(ref hasp);
		}
		catch (Exception ex)
		{
			if (textHistory != null)
			{
				MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK);
			}
			else
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
