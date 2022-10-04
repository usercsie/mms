using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Design;

namespace MMS.Extensions.Controls
{
    [DefaultEvent("OnSelectedIndexChanged")]
    class CustomCombobox : UserControl
    {
        private Color backColor = Color.WhiteSmoke;
        private Color iconColor = Color.MediumSlateBlue;
        private Color listBackColor = Color.FromArgb(230, 228, 245);
        private Color listTextColor = Color.DimGray;
        private Color borderColor = Color.MediumSlateBlue;
        private int borderSize = 1;

        private ComboBox cmbList;
        private Label lblText;
        private Button btnIcon;

        [Category("Extension - Appearance")]
        public new Color BackColor
        {
            get => backColor;
            set
            {
                backColor = value;
                lblText.BackColor = backColor;
                btnIcon.BackColor = backColor;
            }
        }
        [Category("Extension - Appearance")]
        public Color IconColor 
        { 
            get => iconColor;
            set
            {
                iconColor = value;
                btnIcon.Invalidate();
            }
        }
        [Category("Extension - Appearance")]
        public Color ListBackColor 
        {
            get => listBackColor;
            set
            {
                listBackColor = value;
                cmbList.BackColor = listBackColor;
            }
        }
        [Category("Extension - Appearance")]
        public Color ListTextColor 
        { 
            get => listTextColor;
            set
            {
                listTextColor = value;
                cmbList.ForeColor = listTextColor;
            }
        }
        [Category("Extension - Appearance")]
        public Color BorderColor 
        { 
            get => borderColor;
            set
            {
                borderColor = value;
                base.BackColor = borderColor;
            }
        }
        [Category("Extension - Appearance")]
        public int BorderSize 
        {
            get => borderSize;
            set
            {
                borderSize = value;
                this.Padding = new Padding(borderSize);
                AdjustComboBoxDimension();
            }
        }
        [Category("Extension - Appearance")]
        public override Color ForeColor 
        {
            get => base.ForeColor;
            set
            {
                base.ForeColor = value;
                lblText.ForeColor = value;
            }
        }
        [Category("Extension - Appearance")]
        public override Font Font 
        {
            get => base.Font;
            set
            {
                base.Font = value;
                lblText.Font = value;
                cmbList.Font = value;
            }
        }
        [Category("Extension - Appearance")]
        public string Texts
        {
            get { return lblText.Text; }
            set { lblText.Text = value; }
        }
        [Category("Extension - Appearance")]
        public ComboBoxStyle DropDownStyle
        {
            get { return cmbList.DropDownStyle; }
            set
            {
                if (cmbList.DropDownStyle != ComboBoxStyle.Simple)
                    cmbList.DropDownStyle = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Localizable(true)]
        [MergableProperty(false)]
        [Category("Extension - Data")]
        public ComboBox.ObjectCollection Items { get { return cmbList.Items; } }

        [AttributeProvider(typeof(IListSource))]
        [DefaultValue(null)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category("Extension - Data")]
        public object DataSource { get => cmbList.DataSource; set => cmbList.DataSource = value; }

        [Bindable(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category("Extension - Data")]
        public object SelectedItem { get => cmbList.SelectedItem; set => cmbList.SelectedItem = value; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category("Extension - Data")]
        public int SelectedIndex { get => cmbList.SelectedIndex; set => cmbList.SelectedIndex = value; }

      
        [Browsable(true)]
        [DefaultValue(AutoCompleteMode.None)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Extension - Data")]
        public AutoCompleteMode AutoCompleteMode { get => cmbList.AutoCompleteMode; set => cmbList.AutoCompleteMode = value; }

        [Browsable(true)]
        [DefaultValue(AutoCompleteSource.None)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Extension - Data")]
        public AutoCompleteSource AutoCompleteSource { get => cmbList.AutoCompleteSource; set => cmbList.AutoCompleteSource = value; }
 

        public event EventHandler OnSelectedIndexChanged;

        public CustomCombobox()
        {
            cmbList = new ComboBox();
            lblText = new Label();
            btnIcon = new Button();
            this.SuspendLayout();

            cmbList.BackColor = backColor;
            cmbList.Font = new Font(this.Font.Name, 10F);
            cmbList.ForeColor = listTextColor;
            cmbList.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
            cmbList.TextChanged += new EventHandler(ComboBox_TextChanged);
            cmbList.Visible = false;

            btnIcon.Dock = DockStyle.Right;
            btnIcon.FlatStyle = FlatStyle.Flat;
            btnIcon.FlatAppearance.BorderSize = 0;
            btnIcon.BackColor = backColor;
            btnIcon.Size = new Size(30, 30);
            btnIcon.Cursor = Cursors.Hand;
            btnIcon.Click += new EventHandler(Icon_Click);
            btnIcon.Paint += new PaintEventHandler(Icon_Paint);

            lblText.Dock = DockStyle.Fill;
            lblText.AutoSize = false;
            lblText.BackColor = backColor;
            lblText.TextAlign = ContentAlignment.MiddleLeft;
            lblText.Padding = new Padding(8, 0, 0, 0);
            lblText.Font = new Font(Font.Name, 10F);
            lblText.Click += new EventHandler(Surface_Click);
            lblText.MouseEnter += new EventHandler(Surface_MouseEnter);
            lblText.MouseLeave += new EventHandler(Surface_MouseLeave);

            this.Controls.Add(lblText);
            this.Controls.Add(btnIcon);
            this.Controls.Add(cmbList);
            this.MinimumSize = new Size(200, 30);
            this.Size = new Size(200, 30);
            this.ForeColor = Color.DimGray;
            this.Padding = new Padding(borderSize);
            base.BackColor = borderColor;
            this.ResumeLayout();
            AdjustComboBoxDimension();
        }

        private void Surface_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void Surface_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void AdjustComboBoxDimension()
        {
            cmbList.Width = lblText.Width;
            cmbList.Location = new Point()
            {
                X = this.Width - this.Padding.Right - cmbList.Width,
                Y = lblText.Bottom - cmbList.Height
            };
        }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnSelectedIndexChanged != null)
            {
                OnSelectedIndexChanged.Invoke(sender, e);
            }
            lblText.Text = cmbList.Text;
        }
        private void Icon_Paint(object sender, PaintEventArgs e)
        {
            int iconWidth = 14;
            int iconHeight = 6;
            var rectIcon = new Rectangle((btnIcon.Width - iconWidth) / 2, (btnIcon.Height - iconHeight) / 2, iconWidth, iconHeight);
            Graphics graph = e.Graphics;

            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(iconColor, 2))
            {
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                path.AddLine(rectIcon.X, rectIcon.Y, rectIcon.X + (iconWidth / 2), rectIcon.Bottom);
                path.AddLine(rectIcon.X + (iconWidth / 2), rectIcon.Bottom, rectIcon.Right, rectIcon.Y);
                graph.DrawPath(pen, path);
            }
        }

        private void Surface_Click(object sender, EventArgs e)
        {
            this.OnClick(e);

            cmbList.Select();
            if (cmbList.DropDownStyle == ComboBoxStyle.DropDownList)
            {
                cmbList.DroppedDown = true;//open dropdown list
            }
        }

        private void Icon_Click(object sender, EventArgs e)
        {
            cmbList.Select();
            cmbList.DroppedDown = true;
        }

        private void ComboBox_TextChanged(object sender, EventArgs e)
        {
            lblText.Text = cmbList.Text;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AdjustComboBoxDimension();
        }

    }
}
