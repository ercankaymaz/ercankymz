// Decompiled with JetBrains decompiler
// Type: StPictureBox.StPictureBox
// Assembly: buCamera, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 458B46D1-65F2-4D88-8223-244FCE315356
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\Camera\Canon\buCamera.dll

using Sentech.StApiDotNET;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace StPictureBox;

public class StPictureBox : PictureBox
{
  private int m_RefreshInterval = 33;
  protected CImageData m_CImageData = new CImageData();
  protected CStImageBuffer[] m_aImageBuffer = new CStImageBuffer[3];
  private StPictureBox.StPictureBox.CBufferIndex m_BufferIndex = new StPictureBox.StPictureBox.CBufferIndex();
  private IContainer components = (IContainer) null;
  private System.Windows.Forms.Timer timer;

  public StPictureBox()
  {
    this.InitializeComponent();
    this.timer.Interval = this.RefreshInterval;
    this.timer.Start();
  }

  public int RefreshInterval
  {
    get => this.m_RefreshInterval;
    set => this.m_RefreshInterval = value;
  }

  public void SetLatestImage(IStImage stImage)
  {
    int blankBufferIndex = this.m_BufferIndex.GetBlankBufferIndex();
    if (this.m_aImageBuffer[blankBufferIndex] == null)
      this.m_aImageBuffer[blankBufferIndex] = CStApiDotNet.CreateStImageBuffer();
    this.m_aImageBuffer[blankBufferIndex].CopyImage(stImage);
    this.m_BufferIndex.SetLatestBufferIndex(blankBufferIndex);
  }

  protected IStImage GetLatestImage(out bool isUpdated)
  {
    int latestBufferIndex = this.m_BufferIndex.GetLatestBufferIndex(out isUpdated);
    return latestBufferIndex < 0 ? (IStImage) null : this.m_aImageBuffer[latestBufferIndex].GetIStImage();
  }

  public void timer_Tick(object sender, EventArgs e)
  {
    bool isUpdated;
    IStImage latestImage = this.GetLatestImage(out isUpdated);
    if (!isUpdated)
      return;
    this.Image = (Image) this.m_CImageData.CreateBitmap(latestImage);
  }

  protected override void Dispose(bool disposing)
  {
    this.timer.Stop();
    for (int index = 0; index < this.m_aImageBuffer.Length; ++index)
    {
      if (this.m_aImageBuffer[index] != null)
      {
        this.m_aImageBuffer[index].Dispose();
        this.m_aImageBuffer[index] = (CStImageBuffer) null;
      }
    }
    if (this.m_CImageData != null)
    {
      this.m_CImageData.Dispose();
      this.m_CImageData = (CImageData) null;
    }
    if (this.m_BufferIndex != null)
    {
      this.m_BufferIndex.Dispose();
      this.m_BufferIndex = (StPictureBox.StPictureBox.CBufferIndex) null;
    }
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    this.components = (IContainer) new System.ComponentModel.Container();
    this.timer = new System.Windows.Forms.Timer(this.components);
    ((ISupportInitialize) this).BeginInit();
    this.SuspendLayout();
    this.timer.Interval = 33;
    this.timer.Tick += new EventHandler(this.timer_Tick);
    this.SizeMode = PictureBoxSizeMode.AutoSize;
    ((ISupportInitialize) this).EndInit();
    this.ResumeLayout(false);
  }

  private class CBufferIndex : IDisposable
  {
    private Mutex m_Mutex = (Mutex) null;
    private int m_nUsingBufferIndex = -1;
    private int m_nLatestBufferIndex = -1;

    public CBufferIndex() => this.m_Mutex = new Mutex();

    public int GetLatestBufferIndex(out bool isUpdated)
    {
      isUpdated = false;
      this.m_Mutex.WaitOne();
      if (this.m_nUsingBufferIndex != this.m_nLatestBufferIndex)
      {
        isUpdated = true;
        this.m_nUsingBufferIndex = this.m_nLatestBufferIndex;
      }
      this.m_Mutex.ReleaseMutex();
      return this.m_nUsingBufferIndex;
    }

    public int GetBlankBufferIndex()
    {
      int blankBufferIndex = 0;
      this.m_Mutex.WaitOne();
      while (this.m_nUsingBufferIndex == blankBufferIndex || this.m_nLatestBufferIndex == blankBufferIndex)
        ++blankBufferIndex;
      this.m_Mutex.ReleaseMutex();
      return blankBufferIndex;
    }

    public void SetLatestBufferIndex(int index)
    {
      this.m_Mutex.WaitOne();
      this.m_nLatestBufferIndex = index;
      this.m_Mutex.ReleaseMutex();
    }

    public void Dispose()
    {
      if (this.m_Mutex == null)
        return;
      this.m_Mutex.Close();
      this.m_Mutex = (Mutex) null;
    }
  }
}
