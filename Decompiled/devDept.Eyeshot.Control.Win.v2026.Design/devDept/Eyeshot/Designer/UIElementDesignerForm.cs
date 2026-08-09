using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using devDept.Eyeshot.Control;

namespace devDept.Eyeshot.Designer;

public class UIElementDesignerForm<T> : Form where T : class, IUserInterfaceElement, ICloneable
{
	protected T originalUIElement;

	protected Viewport viewport;

	protected T relatedElement;

	protected bool buttonOk;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolStripItem _0023_003DzxI5jKx22zKNzkOLSjA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IContainer _0023_003Dzg7NzHjo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal PropertyGrid _0023_003Dz8XjYxVRNAP4c;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button _0023_003DzZAtBlYd3EqsA;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button _0023_003DzyCS_0024Ea_FNZbs;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label _0023_003DzPTI_0024LCE_003D;

	protected SplitContainer splitContainer1;

	protected PictureBox pictureBox1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ColorPicker _0023_003DzYHiFEXdPz_0024n3;

	protected CheckBox checkBoxTransparentBackground;

	protected Panel panel1;

	protected virtual Size ImageSize
	{
		get
		{
			if (typeof(T) == typeof(devDept.Eyeshot.Control.ToolBar) || typeof(T) == typeof(System.Windows.Forms.ProgressBar) || typeof(T) == typeof(ScaleBar))
			{
				return relatedElement.GetBounds(viewport).Size;
			}
			if (typeof(T) == typeof(Legend))
			{
				return new Size(pictureBox1.Size.Width - 2, pictureBox1.Size.Height - 2);
			}
			return new Size(panel1.Size.Width - 2, panel1.Size.Height - 2);
		}
	}

	public UIElementDesignerForm(Viewport design, T element, ISite site)
	{
		_0023_003Dz_Y_0024H3f68zohJ();
		base.Icon = _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzEq19E6zMfrOrPjwJIA_003D_003D();
		base.Size = new Size(1130, 600);
		splitContainer1.SplitterDistance = 700;
		splitContainer1.Panel1.AutoScroll = true;
		if (element != null)
		{
			viewport = design;
			design.UpdateGraphics += UpdatePicture;
			originalUIElement = (T)VisualControlDesigner._0023_003DzjKucw_SOIA1l._0023_003DzhL8JyLIuKkZd(element);
			relatedElement = element;
			_0023_003Dz8XjYxVRNAP4c.SelectedObject = element;
			_0023_003Dz8XjYxVRNAP4c.Site = site;
			_0023_003DzYHiFEXdPz_0024n3.Color = BackColor;
			_0023_003DzisWXpO8vO50RcQdswsH4ivEOd0ef696J_TQcFtA_003D._0023_003DzHDE0E4BX9W_c(pictureBox1, panel1);
		}
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		_0023_003DzisWXpO8vO50RcQdswsH4ivEOd0ef696J_TQcFtA_003D._0023_003DzHDE0E4BX9W_c(pictureBox1, panel1);
	}

	protected override void OnShown(EventArgs e)
	{
		base.OnShown(e);
		buttonOk = false;
		_0023_003Dz8XjYxVRNAP4c.ContextMenuStrip = new ContextMenuStrip();
		_0023_003DzxI5jKx22zKNzkOLSjA_003D_003D = new ToolStripButton(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313345));
		_0023_003Dz8XjYxVRNAP4c.ContextMenuStrip.Items.Add(_0023_003DzxI5jKx22zKNzkOLSjA_003D_003D);
		_0023_003Dz8XjYxVRNAP4c.ContextMenuStrip.Opening += _0023_003DzPxYLw0MXKNQlqMRuSw_003D_003D;
		_0023_003DzxI5jKx22zKNzkOLSjA_003D_003D.Click += delegate
		{
			GridItem selectedGridItem = _0023_003Dz8XjYxVRNAP4c.SelectedGridItem;
			selectedGridItem.PropertyDescriptor.ResetValue(selectedGridItem.Parent.Value ?? _0023_003Dz8XjYxVRNAP4c.SelectedObject);
			_0023_003Dz8XjYxVRNAP4c.Refresh();
			_0023_003DzIq_00242jmT_QH0i();
		};
		_0023_003DzxI5jKx22zKNzkOLSjA_003D_003D.AutoToolTip = false;
		_0023_003DzxI5jKx22zKNzkOLSjA_003D_003D.DisplayStyle = ToolStripItemDisplayStyle.Text;
	}

	private void _0023_003DzPxYLw0MXKNQlqMRuSw_003D_003D(object _0023_003DzUNNLWvM_003D, CancelEventArgs _0023_003Dz9I8ZVlc_003D)
	{
		GridItem selectedGridItem = _0023_003Dz8XjYxVRNAP4c.SelectedGridItem;
		if (selectedGridItem.Value == null)
		{
			_0023_003DzxI5jKx22zKNzkOLSjA_003D_003D.Enabled = false;
			return;
		}
		try
		{
			_0023_003DzxI5jKx22zKNzkOLSjA_003D_003D.Enabled = selectedGridItem.PropertyDescriptor.CanResetValue(selectedGridItem.Parent.Value ?? _0023_003Dz8XjYxVRNAP4c.SelectedObject);
		}
		catch (Exception)
		{
			_0023_003DzxI5jKx22zKNzkOLSjA_003D_003D.Enabled = false;
		}
	}

	private void _0023_003DzEe_0024WeFH_0024PTw4lqQecolJxtc_003D(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz9I8ZVlc_003D)
	{
		GridItem selectedGridItem = _0023_003Dz8XjYxVRNAP4c.SelectedGridItem;
		selectedGridItem.PropertyDescriptor.ResetValue(selectedGridItem.Parent.Value ?? _0023_003Dz8XjYxVRNAP4c.SelectedObject);
		_0023_003Dz8XjYxVRNAP4c.Refresh();
		_0023_003DzIq_00242jmT_QH0i();
	}

	private void _0023_003DzIq_00242jmT_QH0i()
	{
		T another = (T)_0023_003Dz8XjYxVRNAP4c.SelectedObject;
		relatedElement.Update(another);
		viewport.CompileUserInterfaceElements();
		UpdatePicture();
	}

	protected virtual void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
	{
		_0023_003DzIq_00242jmT_QH0i();
	}

	protected void UpdatePicture()
	{
		bool num = typeof(T) == typeof(System.Windows.Forms.ProgressBar);
		if (num)
		{
			(relatedElement as System.Windows.Forms.ProgressBar).Value = 60;
		}
		if (typeof(T) == typeof(Legend) || typeof(T) == typeof(ScaleBar))
		{
			relatedElement.GetThumbnail(viewport, ImageSize, checkBoxTransparentBackground.Checked ? Color.Empty : _0023_003DzYHiFEXdPz_0024n3.Color);
		}
		pictureBox1.Image = relatedElement.GetThumbnail(viewport, ImageSize, checkBoxTransparentBackground.Checked ? Color.Empty : _0023_003DzYHiFEXdPz_0024n3.Color);
		if (num)
		{
			(relatedElement as System.Windows.Forms.ProgressBar).Value = 0;
		}
		_0023_003DzisWXpO8vO50RcQdswsH4ivEOd0ef696J_TQcFtA_003D._0023_003DzHDE0E4BX9W_c(pictureBox1, panel1);
		pictureBox1.Invalidate();
	}

	protected override void OnClosing(CancelEventArgs e)
	{
		if (!buttonOk)
		{
			if (relatedElement != originalUIElement)
			{
				relatedElement.Update(originalUIElement);
			}
			viewport.CompileUserInterfaceElements();
		}
	}

	protected virtual void buttonOK_Click(object sender, EventArgs e)
	{
		buttonOk = true;
		relatedElement.Update((IUserInterfaceElement)_0023_003Dz8XjYxVRNAP4c.SelectedObject);
		viewport.CompileUserInterfaceElements();
		Close();
	}

	private void _0023_003DzNS1SzwDNYeX3(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz9I8ZVlc_003D)
	{
		relatedElement.Update(originalUIElement);
		Close();
	}

	private void _0023_003DzbCqV_RV4bN_6wtgXSQ_003D_003D(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz9I8ZVlc_003D)
	{
		UpdatePicture();
	}

	private void _0023_003DzDFRDXljVGFWJfPrgrwv2_0024b4_003D(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz9I8ZVlc_003D)
	{
		UpdatePicture();
	}

	internal void _0023_003DzUTc9_dmeZ1_E()
	{
		Size size = pictureBox1.Size;
		PresetManager.AdjustScalingLevel(this);
		pictureBox1.Size = size;
		_0023_003DzisWXpO8vO50RcQdswsH4ivEOd0ef696J_TQcFtA_003D._0023_003DzHDE0E4BX9W_c(pictureBox1, panel1);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _0023_003Dzg7NzHjo_003D != null)
		{
			_0023_003Dzg7NzHjo_003D.Dispose();
		}
		base.Dispose(disposing);
	}

	private void _0023_003Dz_Y_0024H3f68zohJ()
	{
		_0023_003Dz8XjYxVRNAP4c = new PropertyGrid();
		_0023_003DzZAtBlYd3EqsA = new Button();
		_0023_003DzyCS_0024Ea_FNZbs = new Button();
		_0023_003DzPTI_0024LCE_003D = new Label();
		splitContainer1 = new SplitContainer();
		panel1 = new Panel();
		pictureBox1 = new PictureBox();
		checkBoxTransparentBackground = new CheckBox();
		_0023_003DzYHiFEXdPz_0024n3 = new ColorPicker();
		((ISupportInitialize)splitContainer1).BeginInit();
		splitContainer1.Panel1.SuspendLayout();
		splitContainer1.Panel2.SuspendLayout();
		splitContainer1.SuspendLayout();
		panel1.SuspendLayout();
		((ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		_0023_003Dz8XjYxVRNAP4c.Dock = DockStyle.Fill;
		_0023_003Dz8XjYxVRNAP4c.Location = new Point(0, 0);
		_0023_003Dz8XjYxVRNAP4c.Name = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318577);
		_0023_003Dz8XjYxVRNAP4c.Size = new Size(370, 513);
		_0023_003Dz8XjYxVRNAP4c.TabIndex = 0;
		_0023_003Dz8XjYxVRNAP4c.PropertyValueChanged += propertyGrid1_PropertyValueChanged;
		_0023_003DzZAtBlYd3EqsA.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		_0023_003DzZAtBlYd3EqsA.DialogResult = DialogResult.OK;
		_0023_003DzZAtBlYd3EqsA.Location = new Point(619, 531);
		_0023_003DzZAtBlYd3EqsA.Name = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318573);
		_0023_003DzZAtBlYd3EqsA.Size = new Size(75, 23);
		_0023_003DzZAtBlYd3EqsA.TabIndex = 2;
		_0023_003DzZAtBlYd3EqsA.Text = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318558);
		_0023_003DzZAtBlYd3EqsA.UseVisualStyleBackColor = true;
		_0023_003DzZAtBlYd3EqsA.Click += buttonOK_Click;
		_0023_003DzyCS_0024Ea_FNZbs.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		_0023_003DzyCS_0024Ea_FNZbs.DialogResult = DialogResult.Cancel;
		_0023_003DzyCS_0024Ea_FNZbs.Location = new Point(700, 531);
		_0023_003DzyCS_0024Ea_FNZbs.Name = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318533);
		_0023_003DzyCS_0024Ea_FNZbs.Size = new Size(75, 23);
		_0023_003DzyCS_0024Ea_FNZbs.TabIndex = 3;
		_0023_003DzyCS_0024Ea_FNZbs.Text = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318386);
		_0023_003DzyCS_0024Ea_FNZbs.UseVisualStyleBackColor = true;
		_0023_003DzyCS_0024Ea_FNZbs.Click += _0023_003DzNS1SzwDNYeX3;
		_0023_003DzPTI_0024LCE_003D.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		_0023_003DzPTI_0024LCE_003D.AutoSize = true;
		_0023_003DzPTI_0024LCE_003D.Location = new Point(35, 495);
		_0023_003DzPTI_0024LCE_003D.Name = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318373);
		_0023_003DzPTI_0024LCE_003D.Size = new Size(59, 13);
		_0023_003DzPTI_0024LCE_003D.TabIndex = 8;
		_0023_003DzPTI_0024LCE_003D.Text = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318360);
		splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		splitContainer1.Location = new Point(12, 12);
		splitContainer1.Name = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318342);
		splitContainer1.Panel1.AutoScroll = true;
		splitContainer1.Panel1.Controls.Add(panel1);
		splitContainer1.Panel1.Controls.Add(checkBoxTransparentBackground);
		splitContainer1.Panel1.Controls.Add(_0023_003DzYHiFEXdPz_0024n3);
		splitContainer1.Panel1.Controls.Add(_0023_003DzPTI_0024LCE_003D);
		splitContainer1.Panel2.Controls.Add(_0023_003Dz8XjYxVRNAP4c);
		splitContainer1.Size = new Size(763, 513);
		splitContainer1.SplitterDistance = 389;
		splitContainer1.TabIndex = 10;
		panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		panel1.AutoScroll = true;
		panel1.Controls.Add(pictureBox1);
		panel1.Location = new Point(3, 3);
		panel1.Name = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318464);
		panel1.Size = new Size(383, 480);
		panel1.TabIndex = 13;
		pictureBox1.BorderStyle = BorderStyle.FixedSingle;
		pictureBox1.InitialImage = null;
		pictureBox1.Location = new Point(0, 0);
		pictureBox1.Margin = new Padding(0);
		pictureBox1.Name = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318435);
		pictureBox1.Size = new Size(430, 370);
		pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
		pictureBox1.TabIndex = 10;
		pictureBox1.TabStop = false;
		checkBoxTransparentBackground.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		checkBoxTransparentBackground.Appearance = Appearance.Button;
		checkBoxTransparentBackground.Image = _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzQk5ptKRUh0mB();
		checkBoxTransparentBackground.Location = new Point(0, 489);
		checkBoxTransparentBackground.Name = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318417);
		checkBoxTransparentBackground.Size = new Size(24, 24);
		checkBoxTransparentBackground.TabIndex = 12;
		checkBoxTransparentBackground.UseVisualStyleBackColor = true;
		checkBoxTransparentBackground.CheckedChanged += delegate
		{
			UpdatePicture();
		};
		_0023_003DzYHiFEXdPz_0024n3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		_0023_003DzYHiFEXdPz_0024n3.Location = new Point(90, 490);
		_0023_003DzYHiFEXdPz_0024n3.Name = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318269);
		_0023_003DzYHiFEXdPz_0024n3.Size = new Size(75, 23);
		_0023_003DzYHiFEXdPz_0024n3.TabIndex = 11;
		_0023_003DzYHiFEXdPz_0024n3.ColorChanged += _0023_003DzbCqV_RV4bN_6wtgXSQ_003D_003D;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(784, 561);
		base.Controls.Add(splitContainer1);
		base.Controls.Add(_0023_003DzyCS_0024Ea_FNZbs);
		base.Controls.Add(_0023_003DzZAtBlYd3EqsA);
		Font = new Font(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318250), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		base.Name = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318237);
		Text = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318321);
		base.StartPosition = FormStartPosition.CenterScreen;
		splitContainer1.Panel1.ResumeLayout(performLayout: false);
		splitContainer1.Panel1.PerformLayout();
		splitContainer1.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)splitContainer1).EndInit();
		splitContainer1.ResumeLayout(performLayout: false);
		panel1.ResumeLayout(performLayout: false);
		panel1.PerformLayout();
		((ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(performLayout: false);
	}
}
