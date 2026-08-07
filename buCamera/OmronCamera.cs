// Decompiled with JetBrains decompiler
// Type: buCamera.OmronCamera.OmronCamera
// Assembly: buCamera, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 458B46D1-65F2-4D88-8223-244FCE315356
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\Camera\Canon\buCamera.dll

using Sentech.GenApiDotNET;
using Sentech.StApiDotNET;
using System;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buCamera.OmronCamera;

public class OmronCamera
{
  private CStApiAutoInit api = (CStApiAutoInit) null;
  private CStSystem system = (CStSystem) null;
  public CStDevice device = (CStDevice) null;
  private CStDataStream m_DataStream = (CStDataStream) null;
  public StPictureBox.StPictureBox pbox = new StPictureBox.StPictureBox();

  public event Action<Bitmap> ImageUpdated;

  public void Omron_Setup(double shutterSpd)
  {
    try
    {
      this.api = new CStApiAutoInit();
      this.system = new CStSystem();
      this.device = this.system.CreateFirstStDevice();
      INodeMap inodeMap = this.device.GetRemoteIStPort().GetINodeMap();
      this.NumericF<FloatNode>(inodeMap, "ExposureTime", shutterSpd);
      ((FloatNode) inodeMap["ExposureTime"]).Value = Convert.ToDouble(shutterSpd);
    }
    catch (Exception ex)
    {
      this.ShowException(ex);
    }
  }

  public void Omron_Start()
  {
    try
    {
      if (this.device == null)
      {
        int num = (int) MessageBox.Show("No Omron camera connected");
      }
      else
      {
        this.m_DataStream = this.device.CreateStDataStream(0U);
        this.m_DataStream.RegisterCallbackMethod(new CallbackEventHandler(this.OnCallback));
        this.m_DataStream.StartAcquisition();
        this.device.AcquisitionStart();
      }
    }
    catch (Exception ex)
    {
      this.ShowException(ex);
    }
  }

  public void Omron_Stop()
  {
    try
    {
      this.device.AcquisitionStop();
      this.m_DataStream.StopAcquisition();
      this.m_DataStream.Dispose();
      this.m_DataStream = (CStDataStream) null;
    }
    catch (Exception ex)
    {
      this.ShowException(ex);
    }
  }

  private void OnCallback(IStCallbackParamBase paramBase, object[] param)
  {
    if (paramBase.CallbackType != eStCallbackType.TL_DataStreamNewBuffer)
      return;
    IStCallbackParamGenTLEventNewBuffer tlEventNewBuffer = paramBase as IStCallbackParamGenTLEventNewBuffer;
    try
    {
      using (CStStreamBuffer cstStreamBuffer = tlEventNewBuffer.GetIStDataStream().RetrieveBuffer(0U))
      {
        if (cstStreamBuffer.GetIStStreamBufferInfo().IsImagePresent)
        {
          this.pbox.SetLatestImage(cstStreamBuffer.GetIStImage());
          Bitmap image = (Bitmap) this.pbox.Image;
          Action<Bitmap> imageUpdated = this.ImageUpdated;
          if (imageUpdated != null)
            imageUpdated(image);
        }
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("An exception occurred. \r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  public void NumericF<NODE_TYPE>(INodeMap nodeMap, string nodeName, double shutterSpd) where NODE_TYPE : IFloat
  {
    NODE_TYPE node = (NODE_TYPE) nodeMap[nodeName];
    if (!node.IsWritable)
      return;
    double num = Convert.ToDouble(shutterSpd);
    if (node.Minimum <= num && num <= node.Maximum)
      node.Value = num;
  }

  private void ShowException(Exception e)
  {
    int num = (int) MessageBox.Show("An exception occurred. \r\n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
  }
}
