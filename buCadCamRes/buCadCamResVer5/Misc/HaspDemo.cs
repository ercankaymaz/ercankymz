// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Misc.HaspDemo
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using Aladdin.HASP;
using System;
using System.Collections.Specialized;
using System.Windows.Forms;

#nullable disable
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
    string[] strArray = new string[62]
    {
      "Success.",
      "Invalid memory address.",
      "Unknown/invalid feature id option.",
      "Memory allocation failed.",
      "Too many open features.",
      "Feature access denied.",
      "Incompatible feature.",
      "HASP not found.",
      "En-/decryption length too short.",
      "Invalid handle.",
      "Invalid file id / memory descriptor.",
      "Driver or support daemon version too old.",
      "Real time support not available.",
      "Generic error from host system call.",
      "Hardware key driver not found.",
      "Unrecognized info format.",
      "Request not supported.",
      "Invalid update object.",
      "Key with requested id was not found.",
      "Update data consistency check failed.",
      "Update not supported by this key.",
      "Update counter mismatch.",
      "Invalid vendor code.",
      "Requested encryption algorithm not supported.",
      "Invalid date / time.",
      "Clock out of power.",
      "Update requested ack., but no area to return it.",
      "Terminal services (remote terminal) detected.",
      "Feature type not implemented.",
      "Unknown algorithm.",
      "Signature check failed.",
      "Feature not found",
      "Trace log not enabled.",
      "Communication error between application and local LM",
      "Vendor code unknown to API library (run apigen to make it known)",
      "Invalid XML spec",
      "Invalid XML scope",
      "Too many keys connected",
      "Too many users",
      "Broken session",
      "Communication error between local and remote LM",
      "The feature is expired",
      "HASP LM version too old",
      "HASP SL secure storage I/O error or USB request error",
      "Update installation not allowed",
      "System time has been tampered",
      "Secure channel communication error",
      "Secure storage contains garbage",
      "Vendor lib cannot be found",
      "Vendor lib cannot be loaded",
      "No feature matching scope found",
      "Virtual machine detected",
      "HASP update incompatible with this hardware; HASP key is locked to other hardware",
      "Login denied because of user restrictions",
      "Update was already installed",
      "Another update must be installed first",
      "Vendor library version too old",
      "Upload error",
      "Invalid XML recipient parameter for hasp_detach",
      "Invalid XML action parameter for hasp_detach",
      "Scope for hasp_detach does not select a unique Product",
      "Invalid Product information"
    };
    this.stringCollection = new StringCollection();
    this.stringCollection.AddRange(strArray);
    for (int count = this.stringCollection.Count; count < 400; ++count)
      this.stringCollection.Insert(count, "");
    this.stringCollection.AddRange(new string[2]
    {
      "A required API dynamic library was not found",
      "The found and assigned API dynamic library could not be verified"
    });
    for (int count = this.stringCollection.Count; count < 500; ++count)
      this.stringCollection.Insert(count, "");
    this.stringCollection.AddRange(new string[4]
    {
      "Calling invalid object.",
      "A parameter is invalid.",
      "Already logged in.",
      "Already logged out."
    });
    for (int count = this.stringCollection.Count; count < 525; ++count)
      this.stringCollection.Insert(count, "");
    this.stringCollection.Insert(525, "Unable to excecute/complete the operation.");
    for (int count = this.stringCollection.Count; count < 600; ++count)
      this.stringCollection.Insert(count, "");
    this.stringCollection.Insert(600, "No classic memory extension block available.");
    for (int count = this.stringCollection.Count; count < 650; ++count)
      this.stringCollection.Insert(count, "");
    this.stringCollection.Insert(650, "Invalid port type.");
    this.stringCollection.Insert(651, "Invalid port.");
    for (int count = this.stringCollection.Count; count < 698; ++count)
      this.stringCollection.Insert(count, "");
    this.stringCollection.Insert(698, "Capability is not available.");
    this.stringCollection.Insert(699, "Internal API error.");
  }

  protected Hasp LoginDefaultDemo(ref bool LoginStatus)
  {
    LoginStatus = false;
    Hasp hasp = new Hasp(HaspFeature.Default);
    if (hasp.Login("WSwMmUVgIvID2im4BqBC9SDKxgdY9uPDb6BsB1esD6WChiUCC4UnFDl4jmg2TImue3Emn4Aum9MCfrB7kntl04VE/AbxirSvTmqG3/9lUataxj24Fzzcis2rKPU6jFtrdmpyBzc1lXSq2gspBd3VBizusnBXlTJwqCioCRthvmL4YtzSmjVxjK9z2wq2OmFL0frKoCSKzepqxmu6oxvNoZCBSp4XDB2sRCpCAVNYS2uIRgp3JtLM14Dhjr4dn4Stm3O4xnbHm6g3mx19pFa6BcwKRWbuY7gPOfkRh1qTRwDZI0/AYqNJj4aJwyr14E814vARkL5yn2d73ncoOjAzSsQSiSoXz1g5DWFweyX4gFyrc5ABPZF57utx6ptOm9jbpmCCTs68Q2Q/25km2UqRBiU18BACCMvw5G3fzykY0wyltXFj/Kd1+F97vH+Q8ho++X/FvdH11JkhQYwFpOis6wQg0LnyxDIB+69ow8t0jDlypWiMXsLe2gYhkbKzNGqm+mrm4YhYP4ZEtXD6FwA035liWk6KF3ab+VFqZVua7XLwwy7pQo7EqKwzE9x8C3Fa0qUa7jkKtpRLd1b0htqIbLz2aZ9f63UrdbvQlCA8mWoqq8xe2O1GKbPk7wYOSqm5is8N+U/OasWg4z0pEbVWj4BhYwDfpI8CGrori2pMLxCR0W35nK5Vuv8WKSYVD7Pxf0ia0Zz6E/n1T/y/T80X8fBibWasyE7a701QNTocMA6XoaaVJtBAIz7M62/0AkK+7Mtweqo0zFygROXcosjtWnwNzlrPd3rTwxAZnDk/IFXoAaVnNEz8aa4wtmpTc4uqmU/q80eAYt7VUB4k+A86nOgPCmmpldJ2aQi7blOcw1aQDDC/FF5GQt+CikInnIKamYvswbFzZxCrN3fYLDZYjhv0Qyd0kUcKKlmhDATCjh13PzjZQNRX4tX/ug0srYDqiSxZQpPIQawe9n2WFs8w3w==", this.string_0) == HaspStatus.StatusOk)
      LoginStatus = true;
    return hasp.IsLoggedIn() ? hasp : (Hasp) null;
  }

  protected void LogoutDemo(ref Hasp hasp)
  {
    if (((Hasp) null == (object) hasp ? 1 : (!hasp.IsLoggedIn() ? 1 : 0)) != 0)
      return;
    int num = (int) hasp.Logout();
    hasp.Dispose();
    hasp = (Hasp) null;
  }

  protected void ReadWriteDemo(Hasp hasp, HaspFileId fileId)
  {
    if (((Hasp) null == (object) hasp ? 1 : (!hasp.IsLoggedIn() ? 1 : 0)) != 0)
      return;
    HaspFile file = hasp.GetFile(fileId);
    if (!file.IsLoggedIn())
      return;
    int size = 0;
    if (file.FileSize(ref size) != 0)
      return;
    byte[] buffer = new byte[size];
    if (file.Read(buffer, 0, buffer.Length) != 0)
      return;
    HaspDemo.KeyCode = "";
    for (int index = 0; index <= buffer.Length - 1; ++index)
    {
      if (buffer[index] > (byte) 0)
        HaspDemo.KeyCode += Convert.ToString((char) buffer[index]);
    }
  }

  public void RunDemo(string scope, ref bool LoginStatus, ref string KeyCode)
  {
    try
    {
      this.string_0 = scope;
      Hasp hasp = this.LoginDefaultDemo(ref LoginStatus);
      this.ReadWriteDemo(hasp, HaspFileId.ReadWrite);
      KeyCode = HaspDemo.KeyCode;
      this.LogoutDemo(ref hasp);
    }
    catch (Exception ex)
    {
      if (this.textHistory == null)
      {
        Console.WriteLine(ex.Message);
      }
      else
      {
        int num = (int) MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK);
      }
    }
  }
}
