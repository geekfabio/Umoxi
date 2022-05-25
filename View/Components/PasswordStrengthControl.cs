using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace PasswordStrengthControlLib
{

    #region Utilty types

    public enum StrengthStyle
    {
        Solid = 0,
        Gradient = 1,
        Wire = 2,
        Imaged = 3,

    };


    public enum TextStyle
    {
        None = 0,
        Right = 1,
        Left = 2,
        Center = 3,
    };


    public class StrengthChangedEventArgs : EventArgs
    {

        public StrengthChangedEventArgs(int level, string txt)
            : base()
        {
            this.level = level;
            this.text = txt;
        }

        int level = -1;

        public int Level
        {
            get { return level; }

        }

        string text = string.Empty;

        public string Text
        {
            get { return text; }

        }

    }

    public delegate void PasswordStrengthChangedEventHandler(object sender, StrengthChangedEventArgs e);

    #endregion

    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(ProgressBar))]
    [Description("Password Strength Control with different styles.")]
    public class PasswordStrengthControl : Control
    {
        
        public event PasswordStrengthChangedEventHandler StrengthChangedEventHandler;
        BorderStyle borderStyle = BorderStyle.FixedSingle;
        StrengthStyle style = StrengthStyle.Solid;
        TextStyle textStyle = TextStyle.Left;
        bool isSemenged = false;
        int gap = 1;
        int swidth = 10;
        int maxStrength = 100;
        int newStrength = 0;
        string newText = "Short";
        Image foreGroundImage = null;
        Color borderColor = Color.Black;
        Color gradientStratColor = Color.Red;
        Color gradientEndColor = Color.Green;
        Color solidColor = Color.Green;
        Color foreGroundColor = SystemColors.Control;


        [Category("Appearance")]
        [DefaultValue(StrengthStyle.Solid)]
        [Description("The syle of the strength control.")]
        public StrengthStyle ControlStyle
        {
            get
            {
                return style;
            }
            set
            {
                style = value;
            }
        }

        [Category("Behavior")]
        [DefaultValue(0)]
        [Description("Gets or Sets the current password strength.")]
        public int Strength
        {
            get
            {
                return newStrength;
            }
            set
            {
                newStrength = value;
                if (StrengthChangedEventHandler != null)
                    StrengthChangedEventHandler(this, new StrengthChangedEventArgs(value, this.StrengthText));
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(TextStyle.Left)]
        [Description("Gets or Sets the text alignment.")]
        public TextStyle TextAlignment
        {
            get { return textStyle; }
            set { textStyle = value; }
        }


        [Category("Behavior")]
        [DefaultValue("")]
        [Description("Gets or Sets the current password strength text.")]
        public string StrengthText
        {
            get
            {
                
                return newText;
            }
            set
            {
                newText = value;
                if (StrengthChangedEventHandler != null)
                    StrengthChangedEventHandler(this, new StrengthChangedEventArgs(this.newStrength, value));
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(System.Drawing.Color), "Silver")]
        [Description("Gets or Sets the color of the fore ground.")]
        public Color ForeGroundColor
        {
            get { return foreGroundColor; }
            set
            {
                foreGroundColor = value;
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(System.Drawing.Color), "Green")]
        [Description("Gets or Sets the color of the strength level when cotrol style is solid.")]
        public Color SolidColor
        {
            get { return solidColor; }
            set
            {
                solidColor = value;
                this.Invalidate();

            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(System.Drawing.Color), "Red")]
        [Description("Gets or Sets the start color of the gradient when cotrol style is Gradient/Wire.")]
        public Color GradientStratColor
        {
            get { return gradientStratColor; }
            set
            {
                gradientStratColor = value;
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(System.Drawing.Color), "Green")]
        [Description("Gets or Sets the end color of the gradient when cotrol style is Gradient/Wire.")]
        public Color GradientEndColor
        {
            get { return gradientEndColor; }
            set
            {
                gradientEndColor = value;
                this.Invalidate();
            }
        }

        [Category("Behavior")]
        [DefaultValue(100)]
        [Description("Gets or Sets maximum strength level.")]
        public int MaxStrength
        {
            get { return maxStrength; }
            set { maxStrength = value; }
        }

        [Category("Behavior")]
        [DefaultValue(10)]
        [Description("Gets or Sets maximum segment width.")]
        public int SegmentWidth
        {
            get { return swidth; }
            set
            {
                if (swidth != value && swidth != 0)
                    swidth = value;
            }
        }

        [Category("Behavior")]
        [DefaultValue(1)]
        [Description("Gets or Sets gab in between segments.")]
        public int SegmentationGap
        {
            get
            {

                if (this.isSemenged)
                {
                    if (gap <= 3)
                        return gap;
                    else
                        return 3;
                }
                else
                    return 0;
            }
            set
            {
                gap = value;
            }

        }

        [Category("Appearance")]
        [DefaultValue(BorderStyle.FixedSingle)]
        [Description("Gets or Sets border style of the cotrol.")]
        public BorderStyle BorderStyle
        {
            get { return borderStyle; }
            set { borderStyle = value; }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(System.Drawing.Color), "Black")]
        [Description("Gets or Sets border color.")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        [Category("Behavior")]
        [DefaultValue(false)]
        [Description("Gets or Sets control is showing segments for the stength levels.")]
        public bool EnableSegments
        {
            get { return isSemenged; }
            set { isSemenged = value; }
        }

        [Category("Appearance")]
        [DefaultValue(null)]
        [Description("Gets or Sets the imaage of the strength Level when the cotrol style is Imaged.")]
        public Image ForeGroundImage
        {
            get { return foreGroundImage; }
            set
            {
                foreGroundImage = value;
                if (foreGroundImage != null)
                {

                    imageB = new TextureBrush(this.foreGroundImage);
                }
                else
                {
                    imageB = new TextureBrush(new Bitmap(1, 1));
                }
                this.Invalidate();
            }
        }

      
        private Rectangle OuterRectangle
        {
            get
            {
                Rectangle rect = this.ClientRectangle;

                if (this.BorderStyle != BorderStyle.None)
                {
                    rect.Inflate(-1, -1);
                }
                return rect;
            }
        }
       
        private Rectangle InnerRectangle
        {
            get
            {
                Rectangle rect = this.ClientRectangle;
                if (this.BorderStyle != BorderStyle.None)
                {
                    rect.Inflate(-2, -2);
                    rect.Offset(1, 1);
                }

                return rect;
            }
        }



        public PasswordStrengthControl()
        {
            // this will reduce the flickering.
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
        }

        protected override void  OnPaint(PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

        /// <summary>
        /// Main drawing method
        /// </summary>
        /// <param name="g"></param>
        protected virtual void Draw(Graphics g)
        {
            DrawBorder(g);
            DrawBackground(g);
            DrawText(g);
        }

        /// <summary>
        /// Draw the background and foreground of the control
        /// </summary>
        /// <param name="g"></param>
        protected virtual void DrawBackground(Graphics g)
        {
            Rectangle rect = this.InnerRectangle;
            SolidBrush backB = new SolidBrush(this.BackColor);
            SolidBrush foreGB = new SolidBrush(this.foreGroundColor);
            SolidBrush solidBrush = new SolidBrush(this.solidColor);
            //g.FillRectangle(backB, rect);

            if (!isSemenged)
            {

                int nw = (int)GetStrengthWidth();
                Rectangle srect = new Rectangle(rect.X, rect.Y, nw, rect.Height - 1);
                if (ControlStyle == StrengthStyle.Solid)
                    g.FillRectangle(solidBrush, srect);
                else if (ControlStyle == StrengthStyle.Gradient)
                    DrawGradient(g, srect);
                else if (ControlStyle == StrengthStyle.Wire)
                    DraWire(g, srect);
                else if (ControlStyle == StrengthStyle.Imaged)
                    DrawImage(g, srect);

            }
            else
            {
                //g.FillRectangle(backB, rect);
                g.FillRegion(foreGB, GetSegmentRegion());

                if (ControlStyle == StrengthStyle.Solid)
                    g.FillRegion(solidBrush, GetSegmentStregthRegion());
                else if (ControlStyle == StrengthStyle.Gradient)
                    DrawGradient(g, this.InnerRectangle);
                else if (ControlStyle == StrengthStyle.Wire)
                    DraWire(g, this.InnerRectangle);
                else if (ControlStyle == StrengthStyle.Imaged)
                    DrawImage(g, this.InnerRectangle);

            }


        }

        /// <summary>
        /// Draw the strength indicator level using an image
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rc"></param>
        /// 
        TextureBrush imageB = null;
        protected virtual void DrawImage(Graphics g, Rectangle rc)
        {
            if (this.foreGroundImage == null && imageB != null)
                return;
            if (rc.Width > 0 && rc.Height > 0)
            {
                if (!isSemenged)
                {
                    g.FillRectangle(imageB, rc);
                }
                else
                {
                    if(imageB != null)
                        g.FillRegion(imageB, GetSegmentStregthRegion());
                }
            }
        }

        /// <summary>
        /// Draw the strength indicator level using an vertical gradient
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rc"></param>
        protected virtual void DraWire(Graphics g, Rectangle rc)
        {

            LinearGradientBrush gradientBrush = new LinearGradientBrush(
                new Point(InnerRectangle.X, InnerRectangle.Y),
                new Point(InnerRectangle.X, InnerRectangle.Y + InnerRectangle.Height),
                this.gradientStratColor,
                this.gradientEndColor);

            ColorBlend colorblend = new ColorBlend(3);
            colorblend.Colors = new Color[] { this.gradientEndColor, this.gradientStratColor, this.gradientEndColor };
            colorblend.Positions = new float[] { 0, (float)0.4, 1 };

            gradientBrush.InterpolationColors = colorblend;

            if (!isSemenged)
            {
                g.FillRectangle(gradientBrush, rc);
            }
            else
            {
                g.FillRegion(gradientBrush, GetSegmentStregthRegion());
            }

        }

        /// <summary>
        /// Draw the strength indicator level using an horizontal gradient
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rc"></param>
        protected virtual void DrawGradient(Graphics g, Rectangle rc)
        {
            Brush gradientBrush;
            if (rc.Width > 0)
            {
                 gradientBrush = new LinearGradientBrush(
                      new Point(InnerRectangle.X, InnerRectangle.Y),
                      new Point(InnerRectangle.X + InnerRectangle.Width, rc.Y),
                      this.gradientStratColor,
                      this.gradientEndColor);
            }
            else
            {
                gradientBrush = new SolidBrush(Color.Empty);
            }


            if (!isSemenged)
            {
                g.FillRectangle(gradientBrush, new Rectangle(rc.X, rc.Y, rc.Width, rc.Height));
            }
            else
            {
                g.FillRegion(gradientBrush, GetSegmentStregthRegion());
            }

        }

        /// <summary>
        /// Draw the strength text
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rc"></param>
        protected virtual void DrawText(Graphics g)
        {
            if (textStyle != TextStyle.None)
            {
                SolidBrush foreB = new SolidBrush(this.ForeColor);
                g.DrawString(newText, this.Font, foreB, GetTextRectOAnlignment(g));
            }
        }

        /// <summary>
        /// Calculates the text position according to the Text anlignment
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rc"></param>
        private Rectangle GetTextRectOAnlignment(Graphics g)
        {
            SizeF efSize = g.MeasureString(this.newText, this.Font);

            Size textSize = Size.Ceiling(efSize);

            int pos = this.InnerRectangle.Y + (this.InnerRectangle.Height / 2) - (textSize.Height / 2);

            Rectangle rect = new Rectangle(this.InnerRectangle.X, pos, this.InnerRectangle.Width, textSize.Height);

            if (this.textStyle == TextStyle.Right)
            {
                rect.X += rect.Width - textSize.Width;
            }
            else if (this.textStyle == TextStyle.Center)
            {
                rect.X += (rect.Width - textSize.Width) / 2;
            }
            else if (this.textStyle == TextStyle.Left)
            {
                rect.Width = textSize.Width;
            }

            return rect;
        }

        /// <summary>
        /// Draw the border of the control
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rc"></param>
        protected virtual void DrawBorder(Graphics g)
        {
            Rectangle rect = this.OuterRectangle;
            if (this.BorderStyle != BorderStyle.None)
            {
                //rect.Inflate(-1, -1);
                Pen p = new Pen(new SolidBrush(borderColor));
                g.DrawRectangle(p, rect);
            }
        }

        /// <summary>
        /// Calculates the segmented region for the background
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rc"></param>
        private Region GetSegmentRegion()
        {
            Region region = new Region();
            region.MakeEmpty();

            int segmentNumber = ((InnerRectangle.Width) / (swidth));
            if (segmentNumber <= 0)
                segmentNumber = 0;


            Rectangle segmentRect = new Rectangle(InnerRectangle.Left, InnerRectangle.Top, swidth, InnerRectangle.Height);

            for (int i = 0; i < segmentNumber; i++)
            {
                region.Union(segmentRect);
                segmentRect.Offset(swidth + gap, 0);
            }

            segmentRect = this.OuterRectangle;
            segmentRect.Offset(gap, gap);
            segmentRect.Width -= gap * 2;
            segmentRect.Height -= gap * 2;
            region.Intersect(segmentRect);

            return region;
        }

        /// <summary>
        /// Calculates the segmented region for the stength indicator
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rc"></param>
        private Region GetSegmentStregthRegion()
        {
            Region region = new Region();
            region.MakeEmpty();

            int segmentNumber = ((int)GetStrengthWidth() / (swidth));
            if (segmentNumber <= 0)
                segmentNumber = 0;


            Rectangle segmentRect = new Rectangle(InnerRectangle.Left, InnerRectangle.Top, swidth, InnerRectangle.Height);

            for (int i = 0; i < segmentNumber; i++)
            {
                region.Union(segmentRect);
                segmentRect.Offset(swidth + gap, 0);
            }

            segmentRect = this.OuterRectangle;
            segmentRect.Offset(gap, gap);
            segmentRect.Width -= gap * 2;
            segmentRect.Height -= gap * 2;
            region.Intersect(segmentRect);

            return region;
        }

        /// <summary>
        /// Calculates width of the strength indicator using the MaxStrength and the newStrength value
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rc"></param>
        private double GetStrengthWidth()
        {
            double rate = 1;
            try
            {
                if (this.newStrength > 0)
                {
                    rate = (this.MaxStrength) / (double)(this.newStrength);
                    if (rate <= 0)
                        rate = 1;

                    rate = InnerRectangle.Width / rate;
                }
                else
                {
                    rate = 0;
                }
            }
            catch
            {

            }
            return rate;
        }
    }
}
