using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MMS
{
    [DefaultEvent("_TextChanged")]
    public partial class RoundedTextBox : UserControl
    {
        private Color borderColor = Color.MediumSlateBlue;
        private Color borderFocusColor = Color.HotPink;
        private int borderSize = 2;
        private bool underlineStyle = false;        
        private bool isFocused = false;

        private int borderRadius = 0;
        private Color placeholderColor = Color.DarkGray;
        private string placeholderText = "";
        private bool isPlaceholder = false;
        private bool isPasswordChar = false;
        public RoundedTextBox()
        {
            InitializeComponent();
        }

        public event EventHandler _TextChanged;

        [Category("Extension")]
        public bool UnderlineStyle 
        { 
            get => underlineStyle;
            set
            {
                underlineStyle = value;
                this.Invalidate();
            } 
        }
        [Category("Extension")]
        public int BorderSize
        {
            get => borderSize;
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }
        [Category("Extension")]
        public Color BorderColor 
        { 
            get => borderColor;
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }
        [Category("Extension")]
        public bool PasswordChar
        {
            get { return isPasswordChar; }
            set 
            {
                isPasswordChar = value;
                textBox1.UseSystemPasswordChar = value;
            }
        }
        [Category("Extension")]
        public bool Multiline
        {
            get { return textBox1.Multiline; }
            set 
            { 
                textBox1.Multiline = value;
                UpdateControlHeight();
            }
        }
        [Category("Extension")]
        public override Color BackColor 
        {
            get => base.BackColor; 
            set 
            { 
                base.BackColor = value;
                textBox1.BackColor = value;
            }
        }
        [Category("Extension")]
        public override Color ForeColor 
        {
            get => base.ForeColor;
            set 
            { 
                base.ForeColor = value;
                textBox1.ForeColor = value;
            }
        }
        [Category("Extension")]
        public override Font Font 
        {
            get => base.Font;
            set
            {
                base.Font = value;
                textBox1.Font = value;
                if (this.DesignMode)
                {
                    UpdateControlHeight();
                }
            }
        }

        [Category("Extension")]
        public string Texts
        {
            get 
            {
                if (isPlaceholder == true) return "";
                else
                    return textBox1.Text; 
            }
            set 
            { 
                textBox1.Text = value;
                SetPlaceholder();
            }
        }

        [Category("Extension")]
        public Color BorderFocusColor 
        { 
            get => borderFocusColor;
            set
            {
                borderFocusColor = value;
            }
        }

        [Category("Extension")]
        public int BorderRadius 
        { 
            get => borderRadius;
            set
            {
                if (value >= 0)
                {
                    borderRadius = value;
                    this.Invalidate();
                }
            }
        }

        [Category("Extension")]
        public Color PlaceholderColor 
        { 
            get => placeholderColor;
            set
            {
                placeholderColor = value;
                if (isPlaceholder)
                    textBox1.ForeColor = value;
            }
        }

        [Category("Extension")]
        public string PlaceholderText 
        { 
            get => placeholderText;
            set
            {
                placeholderText = value;
                textBox1.Text = "";
                SetPlaceholder();
            }
        }

        private void SetPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) && placeholderText != "")
            {
                isPlaceholder = true;
                textBox1.Text = placeholderText;
                textBox1.ForeColor = PlaceholderColor;
                if (isPasswordChar)
                {
                    textBox1.UseSystemPasswordChar = false;
                }
            }
        }

        private void RemovePlaceholder()
        {
            if (isPlaceholder && placeholderText != "")
            {
                isPlaceholder = false;
                textBox1.Text = "";
                textBox1.ForeColor = this.ForeColor;
                if (isPasswordChar)
                {
                    textBox1.UseSystemPasswordChar = true;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            if (BorderRadius > 1)
            {
                var rectBorderSmooth = this.ClientRectangle;
                var rectBorder = Rectangle.Inflate(rectBorderSmooth, -BorderSize, -BorderSize);
                int smoothSize = BorderSize > 0 ? BorderSize : 1;

                using (GraphicsPath pathBorderSmooth = GetFigurePath(rectBorderSmooth, BorderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - BorderSize))
                using (Pen penBorderSmooth = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    this.Region = new Region(pathBorderSmooth);
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    penBorder.Alignment = PenAlignment.Center;
                    if (borderRadius > 15) SetTextBoxRoundedRegin();
                    if (isFocused == true) penBorder.Color = borderFocusColor;
                    if (underlineStyle == true)
                    {
                        graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                        graph.SmoothingMode = SmoothingMode.None;
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    }
                    else
                    {
                        graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                        graph.DrawPath(penBorder, pathBorder);
                    }
                }
            }
            else
            {
                using (Pen penBorder = new Pen(borderColor, BorderSize))
                {
                    this.Region = new Region(this.ClientRectangle);
                    if (isFocused == true)  penBorder.Color = borderFocusColor;                    
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                    if (underlineStyle == true)
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    else
                        graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                }
            }
        }

        private void SetTextBoxRoundedRegin()
        {
            GraphicsPath pathTxt;
            if (Multiline)
            {
                pathTxt = GetFigurePath(textBox1.ClientRectangle, borderRadius - borderSize);
                textBox1.Region = new Region(pathTxt);
            }
            else
            {
                pathTxt = GetFigurePath(textBox1.ClientRectangle, borderSize * 2);
                textBox1.Region = new Region(pathTxt);
            }
        }

        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();

            return path;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
            {
                UpdateControlHeight();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }

        private void UpdateControlHeight()
        {
            if (textBox1.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(0, txtHeight);
                textBox1.Multiline = false;

                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (_TextChanged != null)
            {
                _TextChanged.Invoke(sender, e);
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            this.OnKeyDown(e);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            this.OnKeyUp(e); 
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            this.Invalidate();
            RemovePlaceholder();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            this.Invalidate();
            SetPlaceholder();
        }
    }
}
