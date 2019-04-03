// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="GlowButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.Button
{

    #region Glow Button

    // HCGlowButton - (c)Arkphaze
    // Released: May 11/2013
    // http://hackcommunity.net

    /// <summary>
    /// A class collection for rendering Glow Button
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Button" />
    [Designer(typeof(GlowButtonDesigner))]
    public class ZeroitGlowButton : System.Windows.Forms.Button
    {

        #region Image Designer

        #region Include in paint method

        ///////////////////////////////////////////////////////////////////////////////////////////////// 
        //                                                                                             //                                                                     
        //         ------------------------Add this to the Paint Method ------------------------       //
        //                                                                                             //
        // Rectangle R1 = new Rectangle(0, 0, Width, Height);                                          //
        //                                                                                             //
        // PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);                   //
        //                                                                                             //
        // if ((Image == null))                                                                        //
        //     {                                                                                       //
        //         G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat           //
        //             {                                                                               //
        //                 Alignment = _TextAlignment,                                                 //
        //                 LineAlignment = StringAlignment.Center                                      //
        //             });                                                                             //
        //      }                                                                                      //
        // else                                                                                        //
        //      {                                                                                      //
        //         G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);              //
        //          G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat          //
        //             {                                                                               //
        //                 Alignment = _TextAlignment,                                                 //
        //                 LineAlignment = StringAlignment.Center                                      //
        //             });                                                                             //
        //      }                                                                                      //
        //                                                                                             //
        /////////////////////////////////////////////////////////////////////////////////////////////////

        #endregion

        #region Include in Private Methods
        /// <summary>
        /// Images the location.
        /// </summary>
        /// <param name="SF">The sf.</param>
        /// <param name="Area">The area.</param>
        /// <param name="ImageArea">The image area.</param>
        /// <returns>PointF.</returns>
        private static PointF ImageLocation(StringFormat SF, SizeF Area, SizeF ImageArea)
        {
            PointF MyPoint = default(PointF);
            switch (SF.Alignment)
            {
                case StringAlignment.Center:
                    MyPoint.X = Convert.ToSingle((Area.Width - ImageArea.Width) / 2);
                    break;
                case StringAlignment.Near:
                    MyPoint.X = 2;
                    break;
                case StringAlignment.Far:
                    MyPoint.X = Area.Width - ImageArea.Width - 2;
                    break;
            }

            switch (SF.LineAlignment)
            {
                case StringAlignment.Center:
                    MyPoint.Y = Convert.ToSingle((Area.Height - ImageArea.Height) / 2);
                    break;
                case StringAlignment.Near:
                    MyPoint.Y = 2;
                    break;
                case StringAlignment.Far:
                    MyPoint.Y = Area.Height - ImageArea.Height - 2;
                    break;
            }
            return MyPoint;
        }

        /// <summary>
        /// Gets the string format.
        /// </summary>
        /// <param name="_ContentAlignment">The content alignment.</param>
        /// <returns>StringFormat.</returns>
        private StringFormat GetStringFormat(ContentAlignment _ContentAlignment)
        {
            StringFormat SF = new StringFormat();
            switch (_ContentAlignment)
            {
                case ContentAlignment.MiddleCenter:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleLeft:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleRight:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.TopCenter:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopLeft:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopRight:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomCenter:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.BottomRight:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Far;
                    break;
            }
            return SF;
        }

        #endregion

        #endregion              

        #region Private Fields
        /// <summary>
        /// The image
        /// </summary>
        private Image _Image;
        /// <summary>
        /// The image size
        /// </summary>
        private Size _ImageSize;
        /// <summary>
        /// The image align
        /// </summary>
        private ContentAlignment _ImageAlign = ContentAlignment.MiddleCenter;
        /// <summary>
        /// The text alignment
        /// </summary>
        private StringAlignment _TextAlignment = StringAlignment.Center;

        /// <summary>
        /// The flat bg brush
        /// </summary>
        private SolidBrush _flatBgBrush = new SolidBrush(Color.FromArgb(20, 20, 20));
        /// <summary>
        /// The pen top line
        /// </summary>
        private Pen _penTopLine = new Pen(Color.FromArgb(77, 77, 77));
        /// <summary>
        /// The pen outer border
        /// </summary>
        private Pen _penOuterBorder = new Pen(Color.FromArgb(40, 40, 40));

        /// <summary>
        /// The text brush
        /// </summary>
        private SolidBrush _textBrush = new SolidBrush(Color.White);

        /// <summary>
        /// The flat bg color
        /// </summary>
        private Color flatBgColor = Color.FromArgb(20, 20, 20);

        /// <summary>
        /// The gradient1
        /// </summary>
        private Color _gradient1 = Color.FromArgb(30, 30, 30);
        /// <summary>
        /// The gradient2
        /// </summary>
        private Color _gradient2 = Color.FromArgb(5, 5, 5);

        /// <summary>
        /// The text hover
        /// </summary>
        private Color textHover = Color.Yellow;
        /// <summary>
        /// The text default
        /// </summary>
        private Color textDefault = Color.Wheat;
        /// <summary>
        /// The text pressed
        /// </summary>
        private Color textPressed = Color.FromArgb(145, 145, 145);
        /// <summary>
        /// The center color
        /// </summary>
        private Color centerColor = Color.White;

        /// <summary>
        /// The mouse state
        /// </summary>
        private MouseState _mouseState = MouseState.Normal;
        /// <summary>
        /// Enum MouseState
        /// </summary>
        enum MouseState
        {
            /// <summary>
            /// The normal
            /// </summary>
            Normal, Hover, Pressed
        }

        /// <summary>
        /// The maximum glow alpha
        /// </summary>
        private const int MaxGlowAlpha = 100;
        /// <summary>
        /// The glow speed
        /// </summary>
        private const int GlowSpeed = 5;
        /// <summary>
        /// The glow alpha
        /// </summary>
        private int _glowAlpha;
        /// <summary>
        /// The glow brighter
        /// </summary>
        private bool _glowBrighter;
        /// <summary>
        /// The show glow
        /// </summary>
        private bool _showGlow;
        /// <summary>
        /// The timer
        /// </summary>
        private readonly System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();

        #endregion

        #region Public Properties

        /// <summary>
        /// Sets the Image size.
        /// </summary>
        /// <value>The size of the image.</value>
        public Size ImageSize
        {
            get { return _ImageSize; }
            set
            {
                _ImageSize = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Image.
        /// </summary>
        /// <value>The image.</value>
        public Image Image
        {
            get { return _Image; }
            set
            {
                if (value == null)
                {
                    _ImageSize = Size.Empty;
                }
                else
                {
                    _ImageSize = value.Size;
                }

                _Image = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Image alignment.
        /// </summary>
        /// <value>The image align.</value>
        public ContentAlignment ImageAlign
        {
            get { return _ImageAlign; }
            set
            {
                _ImageAlign = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Gradient color.
        /// </summary>
        /// <value>The gradient1.</value>
        /// <remarks>This is a gradient color for Gradient 1</remarks>
        public Color Gradient1
        {
            get { return _gradient1; }
            set { _gradient1 = value; Invalidate(); }
        }

        /// <summary>
        /// Sets the Gradient color.
        /// </summary>
        /// <value>The gradient2.</value>
        /// <remarks>This is a gradient color for Gradient 2</remarks>
        public Color Gradient2
        {
            get { return _gradient2; }
            set { _gradient2 = value; Invalidate(); }
        }

        /// <summary>
        /// Sets the Text color when the button is Hovered.
        /// </summary>
        /// <value>The text hover.</value>
        public Color TextHover
        {
            get { return textHover; }
            set { textHover = value; Invalidate(); }
        }

        /// <summary>
        /// Sets the default Text color.
        /// </summary>
        /// <value>The text default.</value>
        public Color TextDefault
        {
            get { return textDefault; }
            set { textDefault = value; Invalidate(); }
        }

        /// <summary>
        /// Sets the Text color when the button is Pressed.
        /// </summary>
        /// <value>The text pressed.</value>
        public Color TextPressed
        {
            get { return textPressed; }
            set { textPressed = value; Invalidate(); }
        }

        /// <summary>
        /// Sets the Background color when the button is Clicked.
        /// </summary>
        /// <value>The color of the flat bg.</value>
        public Color FlatBgColor
        {
            get { return flatBgColor; }
            set { flatBgColor = value; Invalidate(); }
        }

        /// <summary>
        /// Sets the Center color
        /// </summary>
        /// <value>The color of the g low.</value>
        public Color GLowColor
        {
            get { return centerColor; }
            set
            {
                centerColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Top line color
        /// </summary>
        /// <value>The top line.</value>
        public Color TopLine
        {
            get { return _penTopLine.Color; }
            set { _penTopLine.Color = value; Invalidate(); }
        }

        /// <summary>
        /// Sets the Border color
        /// </summary>
        /// <value>The border.</value>
        public Color Border
        {
            get { return _penOuterBorder.Color; }
            set { _penOuterBorder.Color = value; Invalidate(); }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitGlowButton"/> class.
        /// </summary>
        public ZeroitGlowButton()
        {
            DoubleBuffered = true;
            _timer.Interval = 1;
            _timer.Tick += _timer_Tick;
            _showGlow = true;

            IncludeInConstructor();
        }
        #endregion

        #region Transparency

        #region Include in Paint

        private void TransparentInPaint(Graphics g)
        {
            if (AllowTransparency)
            {
                MakeTransparent(this, g);
            }
        }

        #endregion

        #region Include in Private Field

        private bool allowTransparency = true;

        #endregion

        #region Include in Public Properties

        public bool AllowTransparency
        {
            get { return allowTransparency; }
            set
            {
                allowTransparency = value;

                Invalidate();
            }
        }

        #endregion

        #region Method


        private static void MakeTransparent(Control control, Graphics g)
        {
            var parent = control.Parent;
            if (parent == null) return;
            var bounds = control.Bounds;
            var siblings = parent.Controls;
            int index = siblings.IndexOf(control);
            Bitmap behind = null;
            for (int i = siblings.Count - 1; i > index; i--)
            {
                var c = siblings[i];
                if (!c.Bounds.IntersectsWith(bounds)) continue;
                if (behind == null)
                    behind = new Bitmap(control.Parent.ClientSize.Width, control.Parent.ClientSize.Height);
                c.DrawToBitmap(behind, c.Bounds);
            }
            if (behind == null) return;
            g.DrawImage(behind, control.ClientRectangle, bounds, GraphicsUnit.Pixel);
            behind.Dispose();
        }

        #endregion

        #endregion

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            TransparentInPaint(e.Graphics);

            base.OnPaint(e);

            Graphics G = e.Graphics;
            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.HighQuality;

            Rectangle R1 = new Rectangle(0, 0, Width, Height);                                          //
                                                                                                        //
            PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);

            _flatBgBrush.Color = flatBgColor;
                                                                                                       //

            switch (_mouseState)
            {
                case MouseState.Hover:
                    using (
                        LinearGradientBrush lgb = new LinearGradientBrush(Point.Empty, new Point(0, Height),
                                                                          _gradient2, _gradient1))
                    {
                        G.FillRectangle(lgb, DisplayRectangle);
                    }
                    _textBrush.Color = textHover;

                    if ((Image == null))                                                                        //
                    {                                                                                       //
                        //G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat           //
                        //{                                                                               //
                        //    Alignment = _TextAlignment,                                                 //
                        //    LineAlignment = StringAlignment.Center                                      //
                        //});                                                                             //
                    }                                                                                      //
                    else                                                                                        //
                    {                                                                                      //
                        G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);              //
                        //G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat          //
                        //{                                                                               //
                        //    Alignment = _TextAlignment,                                                 //
                        //    LineAlignment = StringAlignment.Center                                      //
                        //});                                                                             //
                    }


                    break;
                case MouseState.Pressed:
                    e.Graphics.FillRectangle(_flatBgBrush, DisplayRectangle);
                    _textBrush.Color = textPressed;

                    if ((Image == null))                                                                        //
                    {                                                                                       //
                        //G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat           //
                        //{                                                                               //
                        //    Alignment = _TextAlignment,                                                 //
                        //    LineAlignment = StringAlignment.Center                                      //
                        //});                                                                             //
                    }                                                                                      //
                    else                                                                                        //
                    {                                                                                      //
                        G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);              //
                        //G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat          //
                        //{                                                                               //
                        //    Alignment = _TextAlignment,                                                 //
                        //    LineAlignment = StringAlignment.Center                                      //
                        //});                                                                             //
                    }
                    break;
                default: // Normal
                    using (
                        LinearGradientBrush lgb = new LinearGradientBrush(Point.Empty, new Point(0, Height),
                                                                          _gradient1, _gradient2))
                    {
                        e.Graphics.FillRectangle(lgb, DisplayRectangle);
                    }
                    _textBrush.Color = textDefault;

                    if ((Image == null))                                                                        //
                    {                                                                                       //
                        //G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat           //
                        //{                                                                               //
                        //    Alignment = _TextAlignment,                                                 //
                        //    LineAlignment = StringAlignment.Center                                      //
                        //});                                                                             //
                    }                                                                                      //
                    else                                                                                        //
                    {                                                                                      //
                        G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);              //
                        //G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat          //
                        //{                                                                               //
                        //    Alignment = _TextAlignment,                                                 //
                        //    LineAlignment = StringAlignment.Center                                      //
                        //});                                                                             //
                    }
                    break;
            }

            // Draw top line
            e.Graphics.DrawLine(_penTopLine, 0f, 0f, Width, 0f);

            // Draw other border lines
            e.Graphics.DrawLine(_penOuterBorder, 0f, 0f, 0f, Height - 1); // Left
            e.Graphics.DrawLine(_penOuterBorder, 0f, Height - 1, Width - 1, Height - 1); // Bottom
            e.Graphics.DrawLine(_penOuterBorder, Width - 1, 0f, Width - 1, Height - 1); // Right

            // Draw text
            DrawText(e.Graphics);
        }

        #region Overrided Mouse Event Methods
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _mouseState = MouseState.Pressed;
            _showGlow = false;

            ClickOnMouseDown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _mouseState = MouseState.Hover;
            _showGlow = true;

            ClickOnMouseUp(e);

            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.Control.OnMouseMove(System.Windows.Forms.MouseEventArgs)" /> event.
        /// </summary>
        /// <param name="mevent">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs mevent)
        {
            base.OnMouseMove(mevent);
            _mouseState = MouseState.Hover;
            _showGlow = true;
            _glowBrighter = true;
            if (_glowAlpha < MaxGlowAlpha)
            {
                _timer.Start();
            }
        }

        /// <summary>
        /// Handles the <see cref="E:MouseLeave" /> event.
        /// </summary>
        /// <param name="e">Provides missing information for the event.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _mouseState = MouseState.Normal;
            _showGlow = true;
            _glowBrighter = false;
            if (_glowAlpha > 0)
            {
                _timer.Start();
            }
        }
        #endregion

        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        private void DrawText(Graphics graphics)
        {
            string text = Text.ToUpper();
            SizeF textSize = graphics.MeasureString(text, Font);
            float x = (Width / 2) - (textSize.Width / 2);
            float y = (Height / 2) - (textSize.Height / 2);
            graphics.DrawString(text, Font, _textBrush, x, y);

            if (_showGlow)
            {
                // Draw text glow
                DrawGlow(graphics, new Rectangle((int)x, (int)y, (int)textSize.Width, (int)textSize.Height));
            }
        }

        /// <summary>
        /// Draws the glow.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="textRect">The text rect.</param>
        private void DrawGlow(Graphics graphics, Rectangle textRect)
        {
            Rectangle glowRect = ExpandRectangle(textRect, 2);
            Point[] pts = new[]
                {
                new Point(glowRect.X, glowRect.Y),
                new Point(glowRect.X + glowRect.Width, glowRect.Y),
                new Point(glowRect.X + glowRect.Width, glowRect.Y + glowRect.Height),
                new Point(glowRect.X, glowRect.Y + glowRect.Height)
            };
            using (PathGradientBrush pgb = new PathGradientBrush(pts))
            {
                pgb.CenterPoint = new PointF(Width / 2, Height / 2);
                pgb.CenterColor = Color.FromArgb(_glowAlpha, centerColor);
                pgb.SurroundColors = new[] { Color.Transparent };
                pgb.FocusScales = new PointF(0.25f, 0.25f);
                graphics.FillRectangle(pgb, glowRect);
            }
        }

        /// <summary>
        /// Handles the Tick event of the _timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void _timer_Tick(object sender, EventArgs e)
        {
            if (_glowBrighter)
            {
                if ((_glowAlpha += GlowSpeed) >= MaxGlowAlpha)
                {
                    _timer.Stop();
                    _glowAlpha = MaxGlowAlpha;
                }
            }
            else
            {
                if ((_glowAlpha -= GlowSpeed) <= 0)
                {
                    _timer.Stop();
                    _glowAlpha = 0;
                }
            }
            Invalidate();
        }

        /// <summary>
        /// Expands the rectangle.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <param name="expansion">The expansion.</param>
        /// <returns>Rectangle.</returns>
        private Rectangle ExpandRectangle(Rectangle rect, int expansion)
        {
            const int extraWidth = 4;
            return new Rectangle(rect.X - expansion - extraWidth, rect.Y - expansion,
                                 rect.Width + (expansion * 2) + (extraWidth * 2), rect.Height + (expansion * 2));
        }

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

        private void ClickOnMouseDown(MouseEventArgs e)
        {
            locate = new Point(Location.X, Location.Y);
            clicked = true;

            xx = e.X;
            yy = e.Y;
            //Focus = true;
            //AnimationTimer.Start();

            ClickTimer.Start();

            Invalidate();
        }

        private void ClickOnMouseUp(MouseEventArgs e)
        {
            
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


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class GlowButtonDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class GlowButtonDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        /// <summary>
        /// The action lists
        /// </summary>
        private DesignerActionListCollection actionLists;

        // Use pull model to populate smart tag menu.
        /// <summary>
        /// Gets the design-time action lists supported by the component associated with the designer.
        /// </summary>
        /// <value>The action lists.</value>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == actionLists)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new GlowButtonSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }

        #region Zeroit Filter (Remove Properties)
        /// <summary>
        /// Remove Button and Control properties that are
        /// not supported by the <see cref="MACButton" />.
        /// </summary>
        /// <param name="Properties">The properties.</param>
        protected override void PostFilterProperties(IDictionary Properties)
        {
            //Properties.Remove("AllowDrop");
            //Properties.Remove("FlatStyle");
            //Properties.Remove("ForeColor");
            //Properties.Remove("ImageIndex");
            //Properties.Remove("ImageList");
        }
        #endregion

    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class GlowButtonSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class GlowButtonSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitGlowButton colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="GlowButtonSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public GlowButtonSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitGlowButton;

            // Cache a reference to DesignerActionUIService, so the 
            // DesigneractionList can be refreshed. 
            this.designerActionUISvc = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
        }

        // Helper method to retrieve control properties. Use of GetProperties enables undo and menu updates to work properly.
        /// <summary>
        /// Gets the name of the property by.
        /// </summary>
        /// <param name="propName">Name of the property.</param>
        /// <returns>PropertyDescriptor.</returns>
        /// <exception cref="System.ArgumentException">Matching ColorLabel property not found!</exception>
        private PropertyDescriptor GetPropertyByName(String propName)
        {
            PropertyDescriptor prop;
            prop = TypeDescriptor.GetProperties(colUserControl)[propName];
            if (null == prop)
                throw new ArgumentException("Matching ColorLabel property not found!", propName);
            else
                return prop;
        }

        #region Properties that are targets of DesignerActionPropertyItem entries.

        /// <summary>
        /// Gets or sets the color of the back.
        /// </summary>
        /// <value>The color of the back.</value>
        public Color BackColor
        {
            get
            {
                return colUserControl.BackColor;
            }
            set
            {
                GetPropertyByName("BackColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor
        {
            get
            {
                return colUserControl.ForeColor;
            }
            set
            {
                GetPropertyByName("ForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        public Image Image
        {
            get
            {
                return colUserControl.Image;
            }
            set
            {
                GetPropertyByName("Image").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the image align.
        /// </summary>
        /// <value>The image align.</value>
        public ContentAlignment ImageAlign
        {
            get
            {
                return colUserControl.ImageAlign;
            }
            set
            {
                GetPropertyByName("ImageAlign").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the gradient1.
        /// </summary>
        /// <value>The gradient1.</value>
        public Color Gradient1
        {
            get
            {
                return colUserControl.Gradient1;
            }
            set
            {
                GetPropertyByName("Gradient1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the gradient2.
        /// </summary>
        /// <value>The gradient2.</value>
        public Color Gradient2
        {
            get
            {
                return colUserControl.Gradient2;
            }
            set
            {
                GetPropertyByName("Gradient2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text hover.
        /// </summary>
        /// <value>The text hover.</value>
        public Color TextHover
        {
            get
            {
                return colUserControl.TextHover;
            }
            set
            {
                GetPropertyByName("TextHover").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text default.
        /// </summary>
        /// <value>The text default.</value>
        public Color TextDefault
        {
            get
            {
                return colUserControl.TextDefault;
            }
            set
            {
                GetPropertyByName("TextDefault").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text pressed.
        /// </summary>
        /// <value>The text pressed.</value>
        public Color TextPressed
        {
            get
            {
                return colUserControl.TextPressed;
            }
            set
            {
                GetPropertyByName("TextPressed").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the flat bg.
        /// </summary>
        /// <value>The color of the flat bg.</value>
        public Color FlatBgColor
        {
            get
            {
                return colUserControl.FlatBgColor;
            }
            set
            {
                GetPropertyByName("FlatBgColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the g low.
        /// </summary>
        /// <value>The color of the g low.</value>
        public Color GLowColor
        {
            get
            {
                return colUserControl.GLowColor;
            }
            set
            {
                GetPropertyByName("GLowColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the top line.
        /// </summary>
        /// <value>The top line.</value>
        public Color TopLine
        {
            get
            {
                return colUserControl.TopLine;
            }
            set
            {
                GetPropertyByName("TopLine").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the border.
        /// </summary>
        /// <value>The border.</value>
        public Color Border
        {
            get
            {
                return colUserControl.Border;
            }
            set
            {
                GetPropertyByName("Border").SetValue(colUserControl, value);
            }
        }

        #endregion

        #region DesignerActionItemCollection

        /// <summary>
        /// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> objects contained in the list.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Appearance"));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("Image",
                                 "Image", "Appearance",
                                 "Sets the image of the control."));

            items.Add(new DesignerActionPropertyItem("ImageAlign",
                                 "Image Align", "Appearance",
                                 "Sets the image alignment."));

            items.Add(new DesignerActionPropertyItem("Gradient1",
                "Gradient1", "Appearance",
                "Sets the Gradient Color."));

            items.Add(new DesignerActionPropertyItem("Gradient2",
                "Gradient2", "Appearance",
                "Sets the Gradient Color."));

            items.Add(new DesignerActionPropertyItem("TextHover",
                "Text Hover", "Appearance",
                "Sets the text hover color."));

            items.Add(new DesignerActionPropertyItem("TextDefault",
                "Text Default", "Appearance",
                "Sets the default text Color."));

            items.Add(new DesignerActionPropertyItem("TextPressed",
                "Text Pressed", "Appearance",
                "Sets the text pressed Color."));

            items.Add(new DesignerActionPropertyItem("FlatBgColor",
                "Flat Background Color", "Appearance",
                "Sets the flat background color."));

            items.Add(new DesignerActionPropertyItem("GLowColor",
                "Glow Color", "Appearance",
                "Sets the centre color."));

            items.Add(new DesignerActionPropertyItem("TopLine",
                "Top Line", "Appearance",
                "Sets the top Line."));

            items.Add(new DesignerActionPropertyItem("Border",
                "Border", "Appearance",
                "Sets the border color."));

            //Create entries for static Information section.
            StringBuilder location = new StringBuilder("Product: ");
            location.Append(colUserControl.ProductName);
            StringBuilder size = new StringBuilder("Version: ");
            size.Append(colUserControl.ProductVersion);
            items.Add(new DesignerActionTextItem(location.ToString(),
                             "Information"));
            items.Add(new DesignerActionTextItem(size.ToString(),
                             "Information"));

            return items;
        }

        #endregion




    }

    #endregion

    #endregion


    #endregion

}
