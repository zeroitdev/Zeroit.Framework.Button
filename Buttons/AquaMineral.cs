// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="AquaMineral.cs" company="Zeroit Dev Technologies">
//    This program is for creating a Button controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.Button
{

    #region Aqua Button

    #region Class AquaButton
    /// <summary>
    /// A class collection for rendering an aqua button.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public class ZeroitAcquaMineralButton : System.Windows.Forms.UserControl
    {
        #region Generated
        /// <summary>
        /// The picture box
        /// </summary>
        private System.Windows.Forms.PictureBox pictureBox;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(150, 150);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            this.pictureBox.Resize += new System.EventHandler(this.pictureBox_Resize);
            this.pictureBox.MouseEnter += new System.EventHandler(this.pictureBox_MouseEnter);
            this.pictureBox.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            // 
            // AquaButton
            // 
            this.Controls.Add(this.pictureBox);
            this.Name = "AquaButton";
            this.FontChanged += new System.EventHandler(this.AquaButton_FontChanged);
            this.ResumeLayout(false);

        }
        #endregion
        #endregion

        #region Constructor AquaButton        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitAcquaMineralButton" /> class.
        /// </summary>
        public ZeroitAcquaMineralButton()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            initialise();
            redrawButton();
            this.ButtonText = "Sample";

            IncludeInConstructor();
        }
        #endregion AquaButton

        #region Class Privates

        //Initial values

        /// <summary>
        /// The m text
        /// </summary>
        private String m_text = "Not Set";
        /// <summary>
        /// The texttrans
        /// </summary>
        private Double texttrans = 0.75;
        /// <summary>
        /// The bkcolor
        /// </summary>
        private Color bkcolor = Color.White;
        /// <summary>
        /// The bordercolor
        /// </summary>
        private Color bordercolor = Color.FromArgb(143, 190, 232);
        /// <summary>
        /// The m text colour
        /// </summary>
        private Color m_textColour = Color.Black;
        /// <summary>
        /// The fontface
        /// </summary>
        private String fontface = "Arial";
        /// <summary>
        /// The fontstyle
        /// </summary>
        private String fontstyle = "";
        /// <summary>
        /// The dropshadow
        /// </summary>
        Boolean dropshadow = true;


        // Set up the initial positions

        /// <summary>
        /// The blurx
        /// </summary>
        private Int32 blurx = 8;
        /// <summary>
        /// The blury
        /// </summary>
        private Int32 blury = 8;
        /// <summary>
        /// The shadowoffsetx
        /// </summary>
        private Int32 shadowoffsetx = 4;
        /// <summary>
        /// The shadowoffsety
        /// </summary>
        private Int32 shadowoffsety = 4;
        /// <summary>
        /// The margin
        /// </summary>
        private Int32 margin;
        /// <summary>
        /// The buttonwidth
        /// </summary>
        private Int32 buttonwidth;
        /// <summary>
        /// The buttonheight
        /// </summary>
        private Int32 buttonheight;
        /// <summary>
        /// The width
        /// </summary>
        private Int32 width;
        /// <summary>
        /// The height
        /// </summary>
        private Int32 height;
        /// <summary>
        /// The borderwidth
        /// </summary>
        private Int32 borderwidth = 5;
        /// <summary>
        /// The shadowopacity
        /// </summary>
        private Double shadowopacity = 0.75;
        /// <summary>
        /// The borderfillx0
        /// </summary>
        private Int32 borderfillx0;
        /// <summary>
        /// The borderfilly0
        /// </summary>
        private Int32 borderfilly0;
        /// <summary>
        /// The borderfillx1
        /// </summary>
        private Int32 borderfillx1;
        /// <summary>
        /// The borderfilly1
        /// </summary>
        private Int32 borderfilly1;
        /// <summary>
        /// The buttoncolorx
        /// </summary>
        private Int32 buttoncolorx;
        /// <summary>
        /// The buttoncolory
        /// </summary>
        private Int32 buttoncolory;
        /// <summary>
        /// The buttoncolorwidth
        /// </summary>
        private Int32 buttoncolorwidth;
        /// <summary>
        /// The buttoncolorheight
        /// </summary>
        private Int32 buttoncolorheight;
        /// <summary>
        /// The shadeleftx
        /// </summary>
        private Int32 shadeleftx;
        /// <summary>
        /// The shadelefty
        /// </summary>
        private Int32 shadelefty;
        /// <summary>
        /// The shadeleftwidth
        /// </summary>
        private Int32 shadeleftwidth;
        /// <summary>
        /// The shadeleftheight
        /// </summary>
        private Int32 shadeleftheight;
        /// <summary>
        /// The shadeopacity
        /// </summary>
        private Double shadeopacity = 0.3;
        /// <summary>
        /// The featherleft
        /// </summary>
        private Int32 featherleft = 10;
        /// <summary>
        /// The feathertop
        /// </summary>
        private Int32 feathertop = 24;
        /// <summary>
        /// The shadetopx
        /// </summary>
        private Int32 shadetopx;
        /// <summary>
        /// The shadetopy
        /// </summary>
        private Int32 shadetopy;
        /// <summary>
        /// The shadetopwidth
        /// </summary>
        private Int32 shadetopwidth;
        /// <summary>
        /// The shadetopheight
        /// </summary>
        private Int32 shadetopheight;
        /// <summary>
        /// The highlightx
        /// </summary>
        private Int32 highlightx;
        /// <summary>
        /// The highlighty
        /// </summary>
        private Int32 highlighty;
        /// <summary>
        /// The highlightwidth
        /// </summary>
        private Int32 highlightwidth;
        /// <summary>
        /// The highlightheight
        /// </summary>
        private Int32 highlightheight;
        /// <summary>
        /// The highlightfilly0
        /// </summary>
        private Int32 highlightfilly0;
        /// <summary>
        /// The highlightfilly1
        /// </summary>
        private Int32 highlightfilly1;
        /// <summary>
        /// The fontsize
        /// </summary>
        private Int32 fontsize = 12;

        /// <summary>
        /// The m image
        /// </summary>
        protected Image m_image;
        /// <summary>
        /// The m nofocus image
        /// </summary>
        protected Image m_nofocusImage;
        #endregion

        #region initialise

        /// <summary>
        /// Initialises the values for redrawing the button
        /// </summary>

        private void initialise()
        {
            //size = "large";
            // m_text = "Not Set";
            texttrans = 0.75;
            bkcolor = Color.White;
            bordercolor = Color.FromArgb(143, 190, 232);
            //m_buttonColour= Color.FromArgb(163, 219, 29);
            //textcolor = Color.Black;
            fontface = "Arial";
            fontstyle = "";
            dropshadow = false;
            //outputfile = "";

            // 100x100 (large)
            blurx = 8;
            blury = 8;
            shadowoffsetx = 4;
            shadowoffsety = 4;
            margin = 1;//Math.Max(blurx, blury) + Math.Max(shadowoffsetx, shadowoffsety) + 1;
            margin = 1;//Math.Max(blurx, blury) + Math.Max(shadowoffsetx, shadowoffsety) + 1;
            width = base.Width;
            height = base.Height;
            buttonwidth = width - (margin * 2);
            buttonheight = height - (margin * 2);
            borderwidth = Math.Min(width, height) / 20;
            shadowopacity = 0.75;
            borderfillx0 = margin + width / 4;
            borderfilly0 = margin + height / 4;
            borderfillx1 = width - margin;
            borderfilly1 = height - margin;
            buttoncolorx = margin + borderwidth;
            buttoncolory = margin + borderwidth;
            buttoncolorwidth = buttonwidth - borderwidth * 2;
            buttoncolorheight = buttonheight - borderwidth * 2;
            shadeleftx = margin + 10;
            shadelefty = margin + borderwidth;
            shadeleftwidth = buttoncolorwidth;
            shadeleftheight = buttoncolorheight;
            shadeopacity = 0.3;
            featherleft = 10;
            feathertop = 24;

            shadetopx = margin + borderwidth;
            shadetopy = margin + borderwidth + 20;
            shadetopwidth = buttoncolorwidth;
            shadetopheight = buttoncolorheight; // <--

            highlightx = width / 4;
            highlighty = borderwidth + (height - 2 * borderwidth) / 8;
            highlightwidth = width / 2;
            highlightheight = (height - 2 * borderwidth) * 3 / 8 - highlighty;

            highlightfilly0 = highlighty;
            highlightfilly1 = highlightfilly0 + highlightheight - 4;
            fontsize = 12;
        }
        
        #endregion initialise

        #region ButtonText

        /// <summary>
        /// Property for setting the value of the text
        /// </summary>
        /// <value>The button text.</value>
        [Description("The text visible on the control. Use \\n for line breaks")]
        [DefaultValue("Not Set")]
        [Browsable(true)]
        public string ButtonText
        {
            set
            {
                base.Text = "not set";
                initialise();
                m_text = value;
                redrawButton();
            }
            get
            {
                return m_text;
            }
        }
        #endregion ButtonText

        #region ButtonColour
        /// <summary>
        /// The m button colour
        /// </summary>
        private Color m_buttonColour = Color.FromArgb(163, 219, 29);

        /// <summary>
        /// Sets the colour of the button
        /// </summary>
        /// <value>The button colour.</value>
        public Color ButtonColour
        {
            set
            {
                m_buttonColour = value;
                redrawButton();
            }
            get
            {
                return m_buttonColour;
            }
        }
        #endregion ButtonColour

        #region FontSize

        /// <summary>
        /// Sets and gets the size of the button text
        /// </summary>
        /// <value>The size of the font.</value>

        [Description("Sets and gets size of the text")]
        [Browsable(true)]
        public float FontSize
        {
            set
            {
                this.Font = new Font(this.Font.FontFamily.Name, value);
                redrawButton();
            }
            get
            {
                return this.Font.Size;
            }
        }
        #endregion FontSize

        #region TextColour

        /// <summary>
        /// Sets the colour of the buttons text
        /// </summary>
        /// <value>The text colour.</value>

        [Description("The colour of the text")]
        [Browsable(true)]
        public Color TextColour
        {
            set
            {
                m_textColour = value;
                redrawButton();
            }
            get
            {
                return m_textColour;
            }
        }
        #endregion TextColour

        #region cleanedName

        /// <summary>
        /// Cleans the text of later display
        /// </summary>
        /// <value>The name of the cleaned.</value>

        private string cleanedName
        {
            get { return m_text.Replace("\\n", " "); }
        }
        #endregion cleanedName

        #region CreateBaseImages

        /// <summary>
        /// Creates the base images.
        /// </summary>

        protected virtual void CreateBaseImages()
        {
            // Call the overrideable CreateImage routines to get the bitmaps/images
            m_image = CreateImage(m_buttonColour);
            m_nofocusImage = CreateImage(Color.White);
            this.Image = m_image;
        }
        #endregion

        #region CreateImage

        /// <summary>
        /// Creates the image.
        /// </summary>
        /// <param name="colour">The colour.</param>
        /// <returns>Bitmap.</returns>

        protected virtual Bitmap CreateImage(Color colour)
        {
            // Don't render until the text has been set or we will be inundated with Png files
            if (m_text == "Not Set") return null;

            string directory = System.Environment.GetEnvironmentVariable("TEMP") + "\\Aqua\\";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string filename = directory + cleanedName + this.width + "x" + this.height + "_" + colour.ToString() + "-" + this.Font.Size + m_textColour.ToString() + ".Png";
            if (File.Exists(filename))
            // if (false)
            {
                return new Bitmap(filename);
            }
            else
            {
                // The following code is based on the button rendering of q123456789 used in the "Aqualiser stricks back article"

                // create image
                LayeredImage image = new LayeredImage(width, height);

                // background
                Layer bkgnd = image.Layers.Add();
                bkgnd.Clear(this.BackColor);

                if (dropshadow)
                {
                    // shadow
                    Layer shadow = image.Layers.Add();
                    image.ActiveLayer = shadow;
                    image.BackColor = Color.Black;
                    image.Selection.SelectEllipse(
                        margin,
                        margin,
                        buttonwidth,
                        buttonheight,
                        SelectionMode.Replace);
                    image.Fill();
                    Blur.ApplyTo(shadow.Bitmap, blurx, blury);
                    shadow.OffsetX = shadowoffsetx;
                    shadow.OffsetY = shadowoffsety;
                    shadow.Opacity = shadowopacity;
                }

                // border
                Layer borderlayer = image.Layers.Add();
                image.Selection.SelectEllipse(
                    margin,
                    margin,
                    buttonwidth,
                    buttonheight,
                    SelectionMode.Replace);
                image.ActiveLayer = borderlayer;
                image.ForeColor = bordercolor;
                image.BackColor = Color.Black;
                image.Fill(
                    borderfillx0,
                    borderfilly0,
                    borderfillx1,
                    borderfilly1,
                    FillType.Radial);

                // button color
                image.Selection.SelectEllipse(
                    buttoncolorx,
                    buttoncolory,
                    buttoncolorwidth,
                    buttoncolorheight,
                    SelectionMode.Replace);
                image.BackColor = colour;
                image.Fill();

                // shade
                Layer shadelayer = image.Layers.Add();
                image.ActiveLayer = shadelayer;
                image.Selection.SelectEllipse(
                    buttoncolorx - 2,
                    buttoncolory - 2,
                    buttoncolorwidth + 4,
                    buttoncolorheight + 4,
                    SelectionMode.Replace);
                image.Selection.SelectEllipse(
                    shadeleftx,
                    shadelefty,
                    shadeleftwidth,
                    shadeleftheight,
                    SelectionMode.Subtract);
                image.Selection.Feather(featherleft);
                image.BackColor = Color.Black;
                image.Fill();
                shadelayer.Opacity = shadeopacity;
                image.Selection.SelectEllipse(
                    buttoncolorx - 2,
                    buttoncolory - 2,
                    buttoncolorwidth + 4,
                    buttoncolorheight + 4,
                    SelectionMode.Replace);
                image.Selection.SelectEllipse(
                    shadetopx,
                    shadetopy,
                    shadetopwidth,
                    shadetopheight,
                    SelectionMode.Subtract);
                image.Selection.Feather(feathertop);
                image.Fill();

                // shade mask -- set smoothing mode !!!
                FastBitmap mask = new FastBitmap(width, height, PixelFormat.Format24bppRgb);
                Graphics g = Graphics.FromImage(mask._bitmap);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                SolidBrush blackbrush = new SolidBrush(Color.Black);
                SolidBrush whitebrush = new SolidBrush(Color.White);
                g.FillRectangle(
                    blackbrush,
                    0,
                    0,
                    width,
                    height);
                g.FillEllipse(
                    whitebrush,
                    buttoncolorx,
                    buttoncolory,
                    buttoncolorwidth,
                    buttoncolorheight);
                whitebrush.Dispose();
                blackbrush.Dispose();
                g.Dispose();
                shadelayer.Mask = mask;

                // text
                Layer textlayer = image.Layers.Add();
                FontStyle fs = FontStyle.Regular;
                for (Int32 i = 0; i < fontstyle.Length; i++)
                {
                    switch (fontstyle[i])
                    {
                        case 'b':
                            fs |= FontStyle.Bold;
                            break;
                        case 'i':
                            fs |= FontStyle.Italic;
                            break;
                        case 'r':
                            fs |= FontStyle.Regular;
                            break;
                        case 's':
                            fs |= FontStyle.Strikeout;
                            break;
                        case 'u':
                            fs |= FontStyle.Underline;
                            break;
                    }
                }
                Font f = new Font(fontface, fontsize, fs);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                format.Trimming = StringTrimming.None;
                SolidBrush brush = new SolidBrush(m_textColour);
                StringBuilder sb = new StringBuilder(m_text.Length);
                //text=Text;
                for (Int32 i = 0; i < m_text.Length; i++)
                {
                    if (m_text[i] == '\\')
                    {
                        if (i + 1 < m_text.Length)
                        {
                            if (m_text[i + 1] == 'n')
                            {
                                sb.Append(Environment.NewLine);
                                i++;
                            }
                            else if (m_text[i + 1] == '\\')
                            {
                                sb.Append('\\');
                                i++;
                            }
                            else
                            {
                                sb.Append('\\');
                            }
                        }
                        else
                        {
                            sb.Append('\\');
                        }
                    }
                    else
                    {
                        sb.Append(m_text[i]);
                    }
                }
                textlayer.DrawText(0, 0, width, height, sb.ToString(), base.Font, brush, format);
                brush.Dispose();
                f.Dispose();
                textlayer.Opacity = 1.0 - texttrans;

                // highlight
                Layer highlightlayer = image.Layers.Add();
                image.ActiveLayer = highlightlayer;
                image.ForeColor = Color.White;
                image.BackColor = Color.Transparent;
                image.Selection.SelectEllipse(
                    highlightx,
                    highlighty,
                    highlightwidth,
                    highlightheight,
                    SelectionMode.Replace);
                image.Fill(
                    0,
                    highlightfilly0,
                    0,
                    highlightfilly1,
                    FillType.Linear);

                // result
                FastBitmap result = image.Flatten();

                // save
                ImageFormat imgf = ImageFormat.Png; // Best for transparancies

                // Save the file to speed things up next time. Swallow the exception as 
                // not too worried if the file write fails - should work next time.
                try
                {
                    result.Save(filename, imgf);
                }
                catch (Exception ex)
                { ex = ex; }
                return result._bitmap;
            }
        }
        
        #endregion CreateImage

        #region pictureBox_Resize

        /// <summary>
        /// Redraws the image on resizing
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>

        private void pictureBox_Resize(object sender, System.EventArgs e)
        {
            redrawButton();
        }
        #endregion pictureBox_Resize

        #region pictureBox_Click
        /// <summary>
        /// Occurs when the control is clicked.
        /// </summary>
        public new event EventHandler Click = null;

        /// <summary>
        /// Picturebox click event - passes this on to extenal listeners
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>

        private void pictureBox_Click(object sender, System.EventArgs e)
        {
            if (this.Click != null)
            {
                this.Click(this, new EventArgs());
            }
        }
        #endregion pictureBox_Click

        #region AquaButton_FontChanged

        /// <summary>
        /// If the font changes redraw the button - used by the IDE
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>

        private void AquaButton_FontChanged(object sender, System.EventArgs e)
        {
            redrawButton();
        }
        #endregion AquaButton_FontChanged

        #region redrawButton

        /// <summary>
        /// Generalised button redraw
        /// </summary>

        private void redrawButton()
        {
            initialise();
            CreateBaseImages();
        }
        #endregion redrawButton

        #region pictureBox_MouseEnter

        /// <summary>
        /// Sets  the focused image when the bitmap is entered
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>

        private void pictureBox_MouseEnter(object sender, System.EventArgs e)
        {
            this.Image = m_nofocusImage;
        }
        #endregion pictureBox_MouseEnter

        #region pictureBox_MouseLeave

        /// <summary>
        /// Sets  the focused image when the mouse leaves the bitmap
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>

        private void pictureBox_MouseLeave(object sender, System.EventArgs e)
        {
            this.Image = m_image;
        }
        #endregion pictureBox_MouseLeave

        #region Image

        /// <summary>
        /// Sets the picture box to the given image - ie. that derived in CreateBaseImages
        /// </summary>
        /// <value>The image.</value>
        public System.Drawing.Image Image
        {
            set
            {
                this.pictureBox.Image = value;
            }
        }
        #endregion Image

        #region Click Animation

        #region Include in Constructor

        private void IncludeInConstructor()
        {
            locate = new Point(Location.X, Location.Y);
            ClickTimer.Tick += ClickTimer_Tick;
        }

        #endregion

        #region Fields
        int xx;
        int yy;
        private bool clicked = false;
        private Point locate;
        Timer ClickTimer = new Timer();
        private bool allowClickAnimation = true;
        private int clickinterval = 1;
        private int offset = 1;
        private int maxOffset = 10;
        #endregion

        #region Properties

        public int ClickOffset
        {
            get { return offset; }
            set
            {
                offset = value;
                Invalidate();
            }
        }

        public int ClickMaxOffset
        {
            get { return maxOffset; }
            set
            {
                maxOffset = value;
                Invalidate();
            }
        }

        public int ClickSpeed
        {
            get { return clickinterval; }
            set
            {
                clickinterval = value;
                Invalidate();
            }
        }

        public bool AllowClickAnimation
        {
            get { return allowClickAnimation; }
            set { allowClickAnimation = value; }
        }

        #endregion

        #region Events

        private void ClickTimer_Tick(object sender, EventArgs e)
        {

            if (clicked)
            {
                this.Location = new Point(Location.X, Location.Y + ClickOffset);
                //this.Location = new Point(Location.X, Location.Y - 10);
            }
            else
            {
                this.Location = locate;
            }

            if (Location.Y > locate.Y + ClickMaxOffset)
            {
                this.Location = locate;
                ClickTimer.Stop();
            }

            Invalidate();

        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            locate = new Point(Location.X, Location.Y);
            clicked = true;

            xx = e.X;
            yy = e.Y;
            //Focus = true;
            //AnimationTimer.Start();

            ClickTimer.Start();

            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            clicked = false;

            //Focus = false;
            //AnimationTimer.Start();
            if (allowClickAnimation)
            {
                ClickTimer.Start();
            }

            Invalidate();
        }

        #endregion

        #endregion

        

    }
    #endregion AquaButton

    // The following classes are picked up directly from q123456789 "Aqualiser stricks back article"
    #region Class FastBitmap

    /// <summary>
    /// Class Fastbitmap
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    /// <seealso cref="System.ICloneable" />

    class FastBitmap : IDisposable, ICloneable
    {
        /// <summary>
        /// The bitmap
        /// </summary>
        internal Bitmap _bitmap;
        /// <summary>
        /// The bitmap data
        /// </summary>
        private BitmapData _bitmapData;


        /// <summary>
        /// Initializes a new instance of the <see cref="FastBitmap"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="fmt">The FMT.</param>
        public FastBitmap(Int32 width, Int32 height, PixelFormat fmt)
        {
            _bitmap = new Bitmap(width, height, fmt);
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="FastBitmap"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public FastBitmap(String filename)
        {
            _bitmap = new Bitmap(filename);
        }


        /// <summary>
        /// Finalizes an instance of the <see cref="FastBitmap"/> class.
        /// </summary>
        ~FastBitmap()
        {
            Dispose(false);
        }


        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }


        /// <summary>
        /// Disposes the specified disposing.
        /// </summary>
        /// <param name="disposing">The disposing.</param>
        protected virtual void Dispose(Boolean disposing)
        {
            Unlock();
            if (disposing)
            {
                _bitmap.Dispose();
            }
        }


        /// <summary>
        /// Prevents a default instance of the <see cref="FastBitmap"/> class from being created.
        /// </summary>
        private FastBitmap()
        {
        }


        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public Object Clone()
        {
            FastBitmap clone = new FastBitmap();
            clone._bitmap = (Bitmap)_bitmap.Clone();
            return clone;
        }


        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>The width.</value>
        public Int32 Width
        {
            get { return _bitmap.Width; }
        }


        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>The height.</value>
        public Int32 Height
        {
            get { return _bitmap.Height; }
        }


        /// <summary>
        /// Gets the has alpha.
        /// </summary>
        /// <value>The has alpha.</value>
        public Boolean HasAlpha
        {
            get { return _bitmap.PixelFormat == PixelFormat.Format32bppArgb; }
        }


        /// <summary>
        /// Locks this instance.
        /// </summary>
        public void Lock()
        {
            _bitmapData = _bitmap.LockBits(
                new Rectangle(0, 0, _bitmap.Width, _bitmap.Height),
                ImageLockMode.ReadWrite,
                _bitmap.PixelFormat
                );
        }


        /// <summary>
        /// Gets the pixel.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>Color.</returns>
        unsafe public Color GetPixel(Int32 x, Int32 y)
        {
            if (_bitmapData.PixelFormat == PixelFormat.Format32bppArgb)
            {
                Byte* b = (Byte*)_bitmapData.Scan0 + (y * _bitmapData.Stride) + (x * 4);
                return Color.FromArgb(*(b + 3), *(b + 2), *(b + 1), *b);
            }
            if (_bitmapData.PixelFormat == PixelFormat.Format24bppRgb)
            {
                Byte* b = (Byte*)_bitmapData.Scan0 + (y * _bitmapData.Stride) + (x * 3);
                return Color.FromArgb(*(b + 2), *(b + 1), *b);
            }
            return Color.Empty;
        }


        /// <summary>
        /// Gets the pixel int32.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>Int32.</returns>
        unsafe public Int32 GetPixelInt32(Int32 x, Int32 y)
        {
            if (_bitmapData.PixelFormat == PixelFormat.Format32bppArgb)
            {
                Byte* b = (Byte*)_bitmapData.Scan0 + (y * _bitmapData.Stride) + (x * 4);
                Int32 color = *(b + 3);
                color <<= 8;
                color |= *(b + 2);
                color <<= 8;
                color |= *(b + 1);
                color <<= 8;
                color |= *b;
                return color;
            }
            if (_bitmapData.PixelFormat == PixelFormat.Format24bppRgb)
            {
                Byte* b = (Byte*)_bitmapData.Scan0 + (y * _bitmapData.Stride) + (x * 3);
                Int32 color = *(b + 2);
                color <<= 8;
                color |= *(b + 1);
                color <<= 8;
                color |= *b;
                return color;
            }
            return -1;
        }


        /// <summary>
        /// Sets the pixel.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="c">The c.</param>
        unsafe public void SetPixel(Int32 x, Int32 y, Color c)
        {
            if (_bitmapData.PixelFormat == PixelFormat.Format32bppArgb)
            {
                Byte* b = (Byte*)_bitmapData.Scan0 + (y * _bitmapData.Stride) + (x * 4);
                *b = c.B;
                *(b + 1) = c.G;
                *(b + 2) = c.R;
                *(b + 3) = c.A;
            }
            if (_bitmapData.PixelFormat == PixelFormat.Format24bppRgb)
            {
                Byte* b = (Byte*)_bitmapData.Scan0 + (y * _bitmapData.Stride) + (x * 3);
                *b = c.B;
                *(b + 1) = c.G;
                *(b + 2) = c.R;
            }
        }


        /// <summary>
        /// Sets the pixel int32.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="color">The color.</param>
        unsafe public void SetPixelInt32(Int32 x, Int32 y, Int32 color)
        {
            if (_bitmapData.PixelFormat == PixelFormat.Format32bppArgb)
            {
                Byte* b = (Byte*)_bitmapData.Scan0 + (y * _bitmapData.Stride) + (x * 4);
                *b = (Byte)((color >> (8 * 0)) & 0x000000FF);
                *(b + 1) = (Byte)((color >> (8 * 1)) & 0x000000FF);
                *(b + 2) = (Byte)((color >> (8 * 2)) & 0x000000FF);
                *(b + 3) = (Byte)((color >> (8 * 3)) & 0x000000FF);
            }
            if (_bitmapData.PixelFormat == PixelFormat.Format24bppRgb)
            {
                Byte* b = (Byte*)_bitmapData.Scan0 + (y * _bitmapData.Stride) + (x * 3);
                *b = (Byte)((color >> (8 * 0)) & 0x000000FF);
                *(b + 1) = (Byte)((color >> (8 * 1)) & 0x000000FF);
                *(b + 2) = (Byte)((color >> (8 * 2)) & 0x000000FF);
            }
        }


        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="destx">The destx.</param>
        /// <param name="desty">The desty.</param>
        /// <param name="srcx">The SRCX.</param>
        /// <param name="srcy">The srcy.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public void CopyTo(FastBitmap bitmap, Int32 destx, Int32 desty, Int32 srcx, Int32 srcy,
            Int32 width, Int32 height)
        {
            try
            {
                Lock();
                bitmap.Lock();
                for (Int32 y = 0; y < height; y++)
                {
                    for (Int32 x = 0; x < width; x++)
                    {
                        Color c = GetPixel(srcx + x, srcy + y);
                        bitmap.SetPixel(destx + x, desty + y, c);
                    }
                }
            }
            finally
            {
                Unlock();
                bitmap.Unlock();
            }
        }


        /// <summary>
        /// Gets the intensity.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>Byte.</returns>
        public Byte GetIntensity(Int32 x, Int32 y)
        {
            Color c = GetPixel(x, y);
            return (Byte)((c.R * 0.30 + c.G * 0.59 + c.B * 0.11) + 0.5);
        }


        /// <summary>
        /// Unlocks this instance.
        /// </summary>
        public void Unlock()
        {
            if (_bitmapData != null)
            {
                _bitmap.UnlockBits(_bitmapData);
                _bitmapData = null;
            }
        }


        /// <summary>
        /// Saves the specified filename.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="format">The format.</param>
        public void Save(String filename, ImageFormat format)
        {
            _bitmap.Save(filename, format);
        }


        /// <summary>
        /// Saves the specified filename.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public void Save(String filename)
        {
            _bitmap.Save(filename);
        }
    }
    #endregion FastBitmap

    #region Class Blur

    /// <summary>
    /// Class Blur
    /// </summary>

    class Blur
    {

        /// <summary>
        /// Sigmoids the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="alpha">The alpha.</param>
        /// <param name="beta">The beta.</param>
        /// <param name="gamma">The gamma.</param>
        /// <returns>Single.</returns>
        private static Single Sigmoid(Single x, Single alpha, Single beta, Single gamma)
        {
            if (x <= alpha)
                return 0;

            if (x >= alpha && x <= beta)
                return 2 * (((x - alpha) / (gamma - alpha)) * ((x - alpha) / (gamma - alpha)));

            if (x >= beta && x <= gamma)
                return 1 - (2 * (((x - gamma) / (gamma - alpha)) * ((x - gamma) / (gamma - alpha))));

            return 1F;
        }


        /// <summary>
        /// Applies to.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="horz">The horz.</param>
        /// <param name="vert">The vert.</param>
        public static void ApplyTo(FastBitmap bitmap, Int32 horz, Int32 vert)
        {
            Single weightsum;
            Single[] weights;

            FastBitmap t = (FastBitmap)bitmap.Clone();

            bitmap.Lock();
            t.Lock();

            Int32 width = bitmap.Width;
            Int32 height = bitmap.Height;

            Double r = 0;
            Double g = 0;
            Double b = 0;
            Double a = 0;
            Int32 c, newcolor;
            Int32 alpha;
            Single weight;
            Boolean hasalpha = bitmap.HasAlpha;

            // horizontal blur

            weights = new Single[horz * 2 + 1];

            weights[horz] = 1.0f;
            for (Int32 i = 0; i < horz; i++)
            {
                Single y = Sigmoid(i, 0, (horz + 1) / 2, horz + 1);
                weights[i] = y;
                weights[horz * 2 - i] = y;
            }

            for (Int32 row = 0; row < bitmap.Height; row++)
            {
                for (Int32 col = 0; col < bitmap.Width; col++)
                {
                    r = 0;
                    g = 0;
                    b = 0;
                    a = 0;
                    weightsum = 0;
                    for (Int32 i = 0; i < horz * 2 + 1; i++)
                    {
                        Int32 x = col - horz + i;
                        if (x < 0)
                        {
                            i += -x;
                            x = 0;
                        }
                        if (x > width - 1)
                            break;
                        c = bitmap.GetPixelInt32(x, row);
                        weight = weights[i];
                        r += ((c >> 16) & 0x000000FF) * weight;
                        g += ((c >> 8) & 0x000000FF) * weight;
                        b += (c & 0x000000FF) * weight;
                        if (hasalpha)
                        {
                            alpha = ((c >> 24) & 0x000000FF);
                            r /= 255.0 * alpha;
                            g /= 255.0 * alpha;
                            b /= 255.0 * alpha;
                            a += alpha * weight;
                        }
                        weightsum += weight;
                    }
                    r /= weightsum;
                    g /= weightsum;
                    b /= weightsum;
                    a /= weightsum;
                    Byte br = (Byte)Math.Round(r);
                    Byte bg = (Byte)Math.Round(g);
                    Byte bb = (Byte)Math.Round(b);
                    Byte ba = (Byte)Math.Round(a);
                    if (br > 255) br = 255;
                    if (bg > 255) bg = 255;
                    if (bb > 255) bb = 255;
                    if (ba > 255) ba = 255;
                    newcolor = ba;		// ignored if 24-bit colors
                    newcolor <<= 8;
                    newcolor |= br;
                    newcolor <<= 8;
                    newcolor |= bg;
                    newcolor <<= 8;
                    newcolor |= bb;
                    t.SetPixelInt32(col, row, newcolor);
                }
            }

            // vertical blur

            weights = new Single[vert * 2 + 1];

            weights[vert] = 1.0f;
            for (Int32 i = 0; i < vert; i++)
            {
                Single y = Sigmoid(i, 0, (vert + 1) / 2, vert + 1);
                weights[i] = y;
                weights[vert * 2 - i] = y;
            }

            for (Int32 col = 0; col < bitmap.Width; col++)
            {
                for (Int32 row = 0; row < bitmap.Height; row++)
                {
                    r = 0;
                    g = 0;
                    b = 0;
                    a = 0;
                    weightsum = 0;
                    for (Int32 i = 0; i < vert * 2 + 1; i++)
                    {
                        Int32 y = row - vert + i;
                        if (y < 0)
                        {
                            i += -y;
                            y = 0;
                        }
                        if (y > height - 1)
                            break;
                        c = t.GetPixelInt32(col, y);
                        weight = weights[i];
                        r += ((c >> 16) & 0x000000FF) * weight;
                        g += ((c >> 8) & 0x000000FF) * weight;
                        b += (c & 0x000000FF) * weight;
                        if (hasalpha)
                        {
                            alpha = ((c >> 24) & 0x000000FF);
                            r /= 255.0 * alpha;
                            g /= 255.0 * alpha;
                            b /= 255.0 * alpha;
                            a += alpha * weight;
                        }
                        weightsum += weight;
                    }
                    r /= weightsum;
                    g /= weightsum;
                    b /= weightsum;
                    a /= weightsum;
                    Byte br = (Byte)Math.Round(r);
                    Byte bg = (Byte)Math.Round(g);
                    Byte bb = (Byte)Math.Round(b);
                    Byte ba = (Byte)Math.Round(a);
                    if (br > 255) br = 255;
                    if (bg > 255) bg = 255;
                    if (bb > 255) bb = 255;
                    if (ba > 255) ba = 255;
                    newcolor = ba;
                    newcolor <<= 8;
                    newcolor |= br;
                    newcolor <<= 8;
                    newcolor |= bg;
                    newcolor <<= 8;
                    newcolor |= bb;
                    bitmap.SetPixelInt32(col, row, newcolor);
                }
            }

            t.Dispose();		// will unlock
            bitmap.Unlock();
        }
    }
    #endregion Blur

    #region Class Layer

    /// <summary>
    /// Class Layer
    /// </summary>
    /// <seealso cref="System.ICloneable" />

    class Layer : ICloneable
    {
        /// <summary>
        /// The bitmap
        /// </summary>
        internal FastBitmap _bitmap;
        /// <summary>
        /// The mask
        /// </summary>
        private FastBitmap _mask;
        /// <summary>
        /// The opacity
        /// </summary>
        public Double _opacity;
        /// <summary>
        /// The offsetx
        /// </summary>
        private Int32 _offsetx, _offsety;


        /// <summary>
        /// Initializes a new instance of the <see cref="Layer"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public Layer(Int32 width, Int32 height)
        {
            _bitmap = new FastBitmap(width, height, PixelFormat.Format32bppArgb);
            Clear(Color.Transparent);
            _opacity = 1.0;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Layer"/> class.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        public Layer(FastBitmap bitmap)
        {
            _bitmap = bitmap;
            _opacity = 1.0;
        }


        /// <summary>
        /// Gets or sets the opacity.
        /// </summary>
        /// <value>The opacity.</value>
        public Double Opacity
        {
            get { return _opacity; }
            set { _opacity = value; }
        }


        /// <summary>
        /// Gets the bitmap.
        /// </summary>
        /// <value>The bitmap.</value>
        public FastBitmap Bitmap
        {
            get { return _bitmap; }
        }


        /// <summary>
        /// Gets or sets the mask.
        /// </summary>
        /// <value>The mask.</value>
        public FastBitmap Mask
        {
            get { return _mask; }
            set { _mask = value; }
        }


        /// <summary>
        /// Gets or sets the offset x.
        /// </summary>
        /// <value>The offset x.</value>
        public Int32 OffsetX
        {
            get { return _offsetx; }
            set { _offsetx = value; }
        }


        /// <summary>
        /// Gets or sets the offset y.
        /// </summary>
        /// <value>The offset y.</value>
        public Int32 OffsetY
        {
            get { return _offsety; }
            set { _offsety = value; }
        }


        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public Object Clone()
        {
            Layer clone = new Layer(_bitmap.Width, _bitmap.Height);
            clone._bitmap = (FastBitmap)_bitmap.Clone();
            return clone;
        }


        /// <summary>
        /// Clears the specified c.
        /// </summary>
        /// <param name="c">The c.</param>
        public void Clear(Color c)
        {
            _bitmap.Lock();
            for (Int32 y = 0; y < _bitmap.Height; y++)
                for (Int32 x = 0; x < _bitmap.Width; x++)
                    _bitmap.SetPixel(x, y, c);
            _bitmap.Unlock();
        }


        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        public void DrawText(Int32 x, Int32 y, String text, Font font,
            Brush brush)
        {
            Graphics g = Graphics.FromImage(_bitmap._bitmap);
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            g.DrawString(text, font, brush, x, y, StringFormat.GenericTypographic);
            g.Dispose();
        }


        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="format">The format.</param>
        public void DrawText(Int32 x, Int32 y, Int32 width, Int32 height,
            String text, Font font, Brush brush, StringFormat format)
        {
            Graphics g = Graphics.FromImage(_bitmap._bitmap);
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            RectangleF layout = new RectangleF(x, y, width, height);
            g.DrawString(text, font, brush, layout, format);
            g.Dispose();
        }


        /// <summary>
        /// Fills the rectangle.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="brush">The brush.</param>
        public void FillRectangle(Int32 x, Int32 y, Int32 width,
            Int32 height, Brush brush)
        {
            Graphics g = Graphics.FromImage(_bitmap._bitmap);
            g.FillRectangle(brush, x, y, width, height);
            g.Dispose();
        }


        /// <summary>
        /// Fills the ellipse.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="brush">The brush.</param>
        public void FillEllipse(Int32 x, Int32 y, Int32 width,
            Int32 height, Brush brush)
        {
            Graphics g = Graphics.FromImage(_bitmap._bitmap);
            g.FillEllipse(brush, x, y, width, height);
            g.Dispose();
        }


        /// <summary>
        /// Gets the pixel.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>Color.</returns>
        public Color GetPixel(Int32 x, Int32 y)
        {
            return _bitmap.GetPixel(x, y);
        }


        /// <summary>
        /// Inverts this instance.
        /// </summary>
        public void Invert()
        {
            _bitmap.Lock();
            for (Int32 y = 0; y < _bitmap.Height; y++)
            {
                for (Int32 x = 0; x < _bitmap.Width; x++)
                {
                    Color c = _bitmap.GetPixel(x, y);
                    _bitmap.SetPixel(x, y, Color.FromArgb(c.A,
                        255 - c.R, 255 - c.G, 255 - c.B));
                }
            }
            _bitmap.Unlock();
        }


        /// <summary>
        /// Gets the bump map pixel.
        /// </summary>
        /// <param name="bmp">The BMP.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>Byte.</returns>
        private Byte GetBumpMapPixel(FastBitmap bmp, Int32 x, Int32 y)
        {
            // create a single number from R, G and B values at point (x, y)
            // if point (x, y) lays outside the bitmap, GetBumpMapPixel()
            // returns the closest pixel within the bitmap

            if (x < 0)
                x = 0;
            if (x > _bitmap.Width - 1)
                x = _bitmap.Width - 1;

            if (y < 0)
                y = 0;
            if (y > _bitmap.Height - 1)
                y = _bitmap.Height - 1;

            return bmp.GetIntensity(x, y);
        }


        /// <summary>
        /// Bumps the map.
        /// </summary>
        /// <param name="bumpmap">The bumpmap.</param>
        /// <param name="azimuth">The azimuth.</param>
        /// <param name="elevation">The elevation.</param>
        /// <param name="bevelwidth">The bevelwidth.</param>
        /// <param name="lightzalways1">The lightzalways1.</param>
        public void BumpMap(Layer bumpmap, Int32 azimuth, Int32 elevation,
            Int32 bevelwidth, Boolean lightzalways1)
        {
            bumpmap._bitmap.Lock();
            _bitmap.Lock();

            for (Int32 row = 0; row < _bitmap.Height; row++)
            {
                for (Int32 col = 0; col < _bitmap.Width; col++)
                {

                    // calculate normal for point (col, row)
                    // this is an approximation of the derivative
                    // I personally haven't figured out why it's
                    // the way it is
                    // normal_z is constant, I think this means
                    // the longer the vector is, the more it lays
                    // in the xy plane

                    Byte[] x = new Byte[6];

                    x[0] = GetBumpMapPixel(bumpmap._bitmap, col - 1, row - 1);
                    x[1] = GetBumpMapPixel(bumpmap._bitmap, col - 1, row - 0);
                    x[2] = GetBumpMapPixel(bumpmap._bitmap, col - 1, row + 1);
                    x[3] = GetBumpMapPixel(bumpmap._bitmap, col + 1, row - 1);
                    x[4] = GetBumpMapPixel(bumpmap._bitmap, col + 1, row - 0);
                    x[5] = GetBumpMapPixel(bumpmap._bitmap, col + 1, row + 1);

                    Single normal_x = x[0] + x[1] + x[2] - x[3] - x[4] - x[5];

                    x[0] = GetBumpMapPixel(bumpmap._bitmap, col - 1, row + 1);
                    x[1] = GetBumpMapPixel(bumpmap._bitmap, col - 0, row + 1);
                    x[2] = GetBumpMapPixel(bumpmap._bitmap, col + 1, row + 1);
                    x[3] = GetBumpMapPixel(bumpmap._bitmap, col - 1, row - 1);
                    x[4] = GetBumpMapPixel(bumpmap._bitmap, col - 0, row - 1);
                    x[5] = GetBumpMapPixel(bumpmap._bitmap, col + 1, row - 1);

                    Single normal_y = x[0] + x[1] + x[2] - x[3] - x[4] - x[5];

                    Single normal_z = (6F * 255F) / bevelwidth;

                    Single length = (Single)Math.Sqrt(
                        normal_x * normal_x +
                        normal_y * normal_y +
                        normal_z * normal_z);

                    if (length != 0)
                    {
                        normal_x /= length;
                        normal_y /= length;
                        normal_z /= length;
                    }

                    // convert to radians

                    Double azimuth_rad = azimuth / 180.0 * Math.PI;
                    Double elevation_rad = elevation / 180.0 * Math.PI;

                    // light vector -- this is the location of the light
                    // source but it also serves as the direction with
                    // origin <0, 0, 0>
                    // the formulas to calculate x, y and z are those to
                    // rotate a point in 3D space
                    // if lightzalways1 is true, light_z is set to 1
                    // because we want full color intensity for that pixel;
                    // if we set light_z to (Single)Math.Sin(elevation_rad),
                    // which is the correct way to calculate light_z, the
                    // color is more dark, but when we ignore light_z, the
                    // light source is straight above the pixel and
                    // therefore sin(elevation_rad) is always 1

                    Single light_x = (Single)(Math.Cos(azimuth_rad) *
                        Math.Cos(elevation_rad));
                    Single light_y = (Single)(Math.Sin(azimuth_rad) *
                        Math.Cos(elevation_rad));
                    Single light_z = 1F;
                    if (!lightzalways1)
                        light_z = (Single)Math.Sin(elevation_rad);

                    // the normal and light vector are unit vectors, so
                    // taking the dot product of these two yields the
                    // cosine of the angle between them

                    Single cos_light_normal = 0;
                    cos_light_normal += normal_x * light_x;
                    cos_light_normal += normal_y * light_y;
                    cos_light_normal += normal_z * light_z;

                    // get pixel (col, row) of this layer, calculate color
                    // and set pixel back with new color

                    Color c = _bitmap.GetPixel(col, row);
                    Single r = c.R;
                    Single g = c.G;
                    Single b = c.B;
                    r *= cos_light_normal;
                    g *= cos_light_normal;
                    b *= cos_light_normal;
                    Byte red = (Byte)Math.Min(Math.Round(r), 255);
                    Byte green = (Byte)Math.Min(Math.Round(g), 255);
                    Byte blue = (Byte)Math.Min(Math.Round(b), 255);
                    _bitmap.SetPixel(col, row, Color.FromArgb(red, green, blue));
                }
            }

            _bitmap.Unlock();
            bumpmap._bitmap.Unlock();
        }
    }
    #endregion Layer

    #region Class Layers

    /// <summary>
    /// Class Layers
    /// </summary>

    class Layers
    {
        /// <summary>
        /// The image
        /// </summary>
        LayeredImage _image;
        /// <summary>
        /// The layers
        /// </summary>
        ArrayList _layers = new ArrayList();


        /// <summary>
        /// Initializes a new instance of the <see cref="Layers"/> class.
        /// </summary>
        /// <param name="image">The image.</param>
        public Layers(LayeredImage image)
        {
            _image = image;
        }


        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public Int32 Count
        {
            get { return _layers.Count; }
        }


        /// <summary>
        /// Adds this instance.
        /// </summary>
        /// <returns>Layer.</returns>
        public Layer Add()
        {
            Layer layer = new Layer(_image.Width, _image.Height);
            _layers.Add(layer);
            return layer;
        }


        /// <summary>
        /// Adds the specified bitmap.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <returns>Layer.</returns>
        public Layer Add(FastBitmap bitmap)
        {
            Layer layer = new Layer(bitmap);
            _layers.Add(layer);
            return layer;
        }


        /// <summary>
        /// Adds the specified width.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns>Layer.</returns>
        public Layer Add(Int32 width, Int32 height)
        {
            Layer layer = new Layer(width, height);
            _layers.Add(layer);
            return layer;
        }


        /// <summary>
        /// Copies the specified layer.
        /// </summary>
        /// <param name="layer">The layer.</param>
        /// <returns>Layer.</returns>
        public Layer Copy(Layer layer)
        {
            Layer copy = (Layer)layer.Clone();
            _layers.Add(copy);
            return copy;
        }

        /// <summary>
        /// Gets the <see cref="Layer"/> with the specified i.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns>Layer.</returns>
        public Layer this[Int32 i]
        {
            get { return (Layer)_layers[i]; }
        }
    }
    #endregion Layers

    #region SelectionMode

    /// <summary>
    /// Selection Mode
    /// </summary>

    enum SelectionMode
    {
        /// <summary>
        /// The replace
        /// </summary>
        Replace,
        /// <summary>
        /// The add
        /// </summary>
        Add,
        /// <summary>
        /// The subtract
        /// </summary>
        Subtract
    }
    #endregion SelectionMode

    #region Class Selection

    /// <summary>
    /// Class Selection
    /// </summary>

    internal class Selection
    {
        /// <summary>
        /// The bitmap
        /// </summary>
        internal FastBitmap _bitmap;


        /// <summary>
        /// Initializes a new instance of the <see cref="Selection"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public Selection(Int32 width, Int32 height)
        {
            _bitmap = new FastBitmap(width, height, PixelFormat.Format24bppRgb);
            Clear();
        }


        /// <summary>
        /// Selects the rectangle.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public void SelectRectangle(Int32 x, Int32 y, Int32 width, Int32 height)
        {
            Clear();
            Graphics g = Graphics.FromImage(_bitmap._bitmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            SolidBrush brush = new SolidBrush(Color.Black);
            g.FillRectangle(brush, x, y, width, height);
            brush.Dispose();
            g.Dispose();
        }


        /// <summary>
        /// Selects the ellipse.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="mode">The mode.</param>
        public void SelectEllipse(Int32 x, Int32 y, Int32 width, Int32 height, SelectionMode mode)
        {
            if (mode == SelectionMode.Replace)
                Clear();
            Graphics g = Graphics.FromImage(_bitmap._bitmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            SolidBrush brush = new SolidBrush(
                mode == SelectionMode.Subtract ? Color.Black : Color.White);
            g.FillEllipse(brush, x, y, width, height);
            brush.Dispose();
            g.Dispose();
        }


        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            try
            {
                _bitmap.Lock();
                for (Int32 y = 0; y < _bitmap.Height; y++)
                    for (Int32 x = 0; x < _bitmap.Width; x++)
                        _bitmap.SetPixel(x, y, Color.Black);
            }
            finally
            {
                _bitmap.Unlock();
            }
        }


        /// <summary>
        /// Feathers the specified radius.
        /// </summary>
        /// <param name="radius">The radius.</param>
        public void Feather(Int32 radius)
        {
            Blur.ApplyTo(_bitmap, radius, radius);
        }
    }
    #endregion Selection

    #region Enum FillType

    /// <summary>
    /// Enum FillType
    /// </summary>

    enum FillType
    {
        /// <summary>
        /// The normal
        /// </summary>
        Normal,
        /// <summary>
        /// The linear
        /// </summary>
        Linear,
        /// <summary>
        /// The radial
        /// </summary>
        Radial
    }
    #endregion FillType

    #region Class LayeredImage

    /// <summary>
    /// Class LayeredImage
    /// </summary>

    class LayeredImage
    {
        /// <summary>
        /// The width
        /// </summary>
        Int32 _width, _height;
        /// <summary>
        /// The checkerboard
        /// </summary>
        Bitmap _checkerboard;
        /// <summary>
        /// The layers
        /// </summary>
        Layers _layers;
        /// <summary>
        /// The selection
        /// </summary>
        Selection _selection;
        /// <summary>
        /// The activelayer
        /// </summary>
        Layer _activelayer;
        /// <summary>
        /// The forecolor
        /// </summary>
        Color _forecolor;
        /// <summary>
        /// The backcolor
        /// </summary>
        Color _backcolor;


        /// <summary>
        /// Initializes a new instance of the <see cref="LayeredImage"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public LayeredImage(Int32 width, Int32 height)
        {
            _width = width;
            _height = height;
            _layers = new Layers(this);
            _selection = new Selection(width, height);
            _activelayer = null;
            _forecolor = Color.Black;
            _backcolor = Color.White;

            // checker board brush

            _checkerboard = new Bitmap(32, 32, PixelFormat.Format24bppRgb);
            Color darkgray = Color.FromArgb(102, 102, 102);
            Color lightgray = Color.FromArgb(153, 153, 153);
            for (Int32 i = 0; i < 32; i++)
            {
                for (Int32 j = 0; j < 32; j++)
                {
                    if ((i < 16 && j < 16) || (i >= 16 && j >= 16))
                        _checkerboard.SetPixel(j, i, lightgray);
                    else
                        _checkerboard.SetPixel(j, i, darkgray);
                }
            }

            // background layer

            Layer bglayer = _layers.Add();
            Graphics g = Graphics.FromImage(bglayer._bitmap._bitmap);
            TextureBrush brush = new TextureBrush(_checkerboard);
            g.FillRectangle(brush, 0, 0, _width, _height);
            brush.Dispose();
            g.Dispose();
        }


        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>The width.</value>
        public Int32 Width
        {
            get { return _width; }
        }


        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>The height.</value>
        public Int32 Height
        {
            get { return _height; }
        }


        /// <summary>
        /// Gets the layers.
        /// </summary>
        /// <value>The layers.</value>
        public Layers Layers
        {
            get { return _layers; }
        }


        /// <summary>
        /// Gets the selection.
        /// </summary>
        /// <value>The selection.</value>
        public Selection Selection
        {
            get { return _selection; }
        }


        /// <summary>
        /// Gets or sets the active layer.
        /// </summary>
        /// <value>The active layer.</value>
        public Layer ActiveLayer
        {
            get { return _activelayer; }
            set { _activelayer = value; }
        }


        /// <summary>
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor
        {
            get { return _forecolor; }
            set { _forecolor = value; }
        }


        /// <summary>
        /// Gets or sets the color of the back.
        /// </summary>
        /// <value>The color of the back.</value>
        public Color BackColor
        {
            get { return _backcolor; }
            set { _backcolor = value; }
        }


        /// <summary>
        /// Fills the radial.
        /// </summary>
        /// <param name="x0">The x0.</param>
        /// <param name="y0">The y0.</param>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>Color.</returns>
        private Color FillRadial(Int32 x0, Int32 y0, Int32 x1, Int32 y1, Int32 x, Int32 y)
        {
            Double maxdistance = Math.Sqrt((x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0));
            Double distance = Math.Sqrt((x - x0) * (x - x0) + (y - y0) * (y - y0));

            distance /= maxdistance;	// range 0.0 - 1.0

            Double r = this._forecolor.R * (1.0 - distance) + this._backcolor.R * distance;
            Double g = this._forecolor.G * (1.0 - distance) + this._backcolor.G * distance;
            Double b = this._forecolor.B * (1.0 - distance) + this._backcolor.B * distance;
            // alpha?
            if (r > 255.0) r = 255.0;
            if (g > 255.0) g = 255.0;
            if (b > 255.0) b = 255.0;

            return Color.FromArgb((Byte)r, (Byte)g, (Byte)b);
        }


        /// <summary>
        /// Fills the linear.
        /// </summary>
        /// <param name="x0">The x0.</param>
        /// <param name="y0">The y0.</param>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>Color.</returns>
        private Color FillLinear(Int32 x0, Int32 y0, Int32 x1, Int32 y1, Int32 x, Int32 y)
        {
            Double maxdistance = Math.Sqrt((x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0));

            // used in determining on which side point is
            Int32 sign = +1;
            if ((x1 > x0 && y1 < y0) || (x0 > x1 && y1 > y0))
                sign = -1;

            // line perpendicular to line by points (x0, y0) and (x1, y1)
            if (x1 == x0)
            {
                x1 += y1 - y0;	// only sign is important
                y1 = y0;
            }
            else if (y1 == y0)
            {
                y1 += x0 - x1;	// only sign is important
                x1 = x0;
            }
            else
            {
                Double slope = -1.0 / ((y1 - y0) / (x1 - x0));

                // calculate a new point on perpendicular line;
                // convert to y = ax + b
                y1 = (Int32)Math.Round(x1 * slope + (y0 - x0 * slope));
            }

            // if point is "in front" of first point, return forecolor
            if (sign * (((y0 - y1) * x + (x1 - x0) * y + (x0 * y1 - x1 * y0))) < 0)
                return this._forecolor;

            // distance from point (x,y) to line
            Double distance = Math.Abs((x1 - x0) * (y0 - y) - (x0 - x) * (y1 - y0));
            distance /= Math.Sqrt((x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0));

            distance /= maxdistance;	// range 0.0 - 1.0
            if (distance > 1.0)
            {
                return this._backcolor;
            }

            Double r = this._forecolor.R * (1.0 - distance) + this._backcolor.R * distance;
            Double g = this._forecolor.G * (1.0 - distance) + this._backcolor.G * distance;
            Double b = this._forecolor.B * (1.0 - distance) + this._backcolor.B * distance;
            Double a = this._forecolor.A * (1.0 - distance) + this._backcolor.A * distance;

            if (r > 255.0) r = 255.0;
            if (g > 255.0) g = 255.0;
            if (b > 255.0) b = 255.0;
            if (a > 255.0) a = 255.0;

            return Color.FromArgb((Byte)a, (Byte)r, (Byte)g, (Byte)b);
        }


        /// <summary>
        /// Fills this instance.
        /// </summary>
        public void Fill()
        {
            Fill(0, 0, 0, 0, FillType.Normal);
        }


        /// <summary>
        /// Fills the specified x0.
        /// </summary>
        /// <param name="x0">The x0.</param>
        /// <param name="y0">The y0.</param>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="type">The type.</param>
        public void Fill(Int32 x0, Int32 y0, Int32 x1, Int32 y1, FillType type)
        {
            try
            {
                _selection._bitmap.Lock();
                _activelayer._bitmap.Lock();
                for (Int32 y = 0; y < _selection._bitmap.Height; y++)
                {
                    for (Int32 x = 0; x < _selection._bitmap.Width; x++)
                    {
                        Color c = _selection._bitmap.GetPixel(x, y);
                        // if pixel is in selection (c.G and c.B should equal c.R)
                        if (c.R != 0)
                        {
                            // if pixel is in layer
                            if (x >= _activelayer.OffsetX &&
                                x <= _activelayer.OffsetX + _activelayer._bitmap.Width - 1 &&
                                y >= _activelayer.OffsetY &&
                                y <= _activelayer.OffsetY + _activelayer._bitmap.Height - 1)
                            {
                                Color c0 = Color.Transparent;
                                switch (type)
                                {
                                    case FillType.Normal:
                                        c0 = _backcolor;
                                        break;
                                    case FillType.Linear:
                                        c0 = FillLinear(x0, y0, x1, y1, x, y);
                                        break;
                                    case FillType.Radial:
                                        c0 = FillRadial(x0, y0, x1, y1, x, y);
                                        break;
                                }
                                Color c1 = _activelayer._bitmap.GetPixel(
                                    x - _activelayer.OffsetX,
                                    y - _activelayer.OffsetY);
                                // calculate color -- this works for opaque colors
                                // but not (?) for transparent ones
                                Double r = 0, g = 0, b = 0, a = 0;
                                Double backalpha = c1.A / 255.0;
                                Double forealpha = c0.A / 255.0;
                                forealpha *= c.R / 255.0;	// anti-aliased edges
                                if (c1.A == 0)
                                {
                                    r = c0.R;
                                    g = c0.G;
                                    b = c0.B;
                                }
                                else
                                {
                                    r = c1.R * (1.0 - forealpha) + c0.R * forealpha;
                                    g = c1.G * (1.0 - forealpha) + c0.G * forealpha;
                                    b = c1.B * (1.0 - forealpha) + c0.B * forealpha;
                                }
                                // opacity increases when painting on paint
                                a = backalpha + ((1.0 - backalpha) * forealpha);
                                a *= 255.0;
                                if (a > 255.0) a = 255.0;
                                if (r > 255.0) r = 255.0;
                                if (g > 255.0) g = 255.0;
                                if (b > 255.0) b = 255.0;
                                Color newcolor = Color.FromArgb(
                                    (Byte)a,
                                    (Byte)r,
                                    (Byte)g,
                                    (Byte)b);
                                _activelayer._bitmap.SetPixel(x, y, newcolor);
                            }
                        }
                    }
                }
            }
            finally
            {
                _selection._bitmap.Unlock();
                _activelayer._bitmap.Unlock();
            }
        }


        /// <summary>
        /// Flattens this instance.
        /// </summary>
        /// <returns>FastBitmap.</returns>
        internal FastBitmap Flatten()
        {
            // create a bitmap for result image

            FastBitmap final = new FastBitmap(_width, _height,
                PixelFormat.Format24bppRgb);

            // lock all bitmaps

            final.Lock();
            for (Int32 i = 0; i < _layers.Count; i++)
            {
                Layer l = _layers[i];
                l._bitmap.Lock();
                if (l.Mask != null)
                    l.Mask.Lock();
            }

            // calculate colors of flattened image
            // 1. take offsetx, offsety into consideration
            // 2. calculate alpha of color (alpha, opacity, mask)
            // 3. mix colors of current layer and layer below

            for (Int32 y = 0; y < _height; y++)
            {
                for (Int32 x = 0; x < _width; x++)
                {
                    Color c0 = _layers[0]._bitmap.GetPixel(x, y);
                    for (Int32 i = 1; i < _layers.Count; i++)
                    {
                        Layer layer = _layers[i];
                        Color c1 = Color.Transparent;
                        if (x >= layer.OffsetX &&
                            x <= layer.OffsetX + layer._bitmap.Width - 1 &&
                            y >= layer.OffsetY &&
                            y <= layer.OffsetY + layer._bitmap.Height - 1)
                        {
                            c1 = layer._bitmap.GetPixel(x - layer.OffsetX,
                                y - layer.OffsetY);
                        }
                        if (c1.A == 255 && layer.Opacity == 1.0 &&
                            layer.Mask == null)
                        {
                            c0 = c1;
                        }
                        else
                        {
                            Double tr, tg, tb, a;
                            a = c1.A / 255.0 * layer.Opacity;
                            if (layer.Mask != null)
                            {
                                a *= layer.Mask.GetIntensity(x, y) / 255.0;
                            }
                            tr = c1.R * a + c0.R * (1.0 - a);
                            tg = c1.G * a + c0.G * (1.0 - a);
                            tb = c1.B * a + c0.B * (1.0 - a);
                            tr = Math.Round(tr);
                            tg = Math.Round(tg);
                            tb = Math.Round(tb);
                            tr = Math.Min(tr, 255);
                            tg = Math.Min(tg, 255);
                            tb = Math.Min(tb, 255);
                            c0 = Color.FromArgb((Byte)tr, (Byte)tg, (Byte)tb);
                        }
                    }
                    final.SetPixel(x, y, c0);
                }
            }

            // unlock all bitmaps

            for (Int32 i = 0; i < _layers.Count; i++)
            {
                Layer l = _layers[i];
                l._bitmap.Unlock();
                if (l.Mask != null)
                    l.Mask.Unlock();
            }
            final.Unlock();

            return final;
        }
    }
    #endregion LayeredImage

    #endregion


}
